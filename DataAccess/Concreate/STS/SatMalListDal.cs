using DataAccess.Abstract;
using DataAccess.Database;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate
{
    public class SatMalListDal : IRepository<SatMalList>
    {

        static SatMalListDal satMalListDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private SatMalListDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(SatMalList entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatMalListKaydet",new SqlParameter("@stokno",entity.Stokno),new SqlParameter("@tanım",entity.Tanim),
                    new SqlParameter("@miktar",entity.Miktar),new SqlParameter("@birim",entity.Birim));
                dataReader.Close();
                return entity.Stokno + " Stok Nolu Kayıt Başarıyla Kaydedildi";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                sqlServices.Stored("SatMalListSil", new SqlParameter("@id", id));
                return "Başarıyla Silindi.";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SatMalList Get(int id)
        {
            return null;
        }

        public List<SatMalList> GetList()
        {
            try
            {
                List<SatMalList> satMals = new List<SatMalList>();
                dataReader = sqlServices.StoreReader("SatMalListListele");
                while(dataReader.Read())
                {
                    satMals.Add(new SatMalList(dataReader["STOK_NO_ID"].ConInt(), dataReader["STOK_NO"].ToString(), dataReader["TANIM_ID"].ConInt(), 
                        dataReader["TANIM"].ToString(), dataReader["MIKTAR"].ConInt(), dataReader["BIRIM"].ToString()));
                }
                dataReader.Close();
                return satMals;
            }
            catch
            {
                return new List<SatMalList>();
            }
        }

        public string Update(SatMalList entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatMalListGuncelle", new SqlParameter("@id",entity.Id), new SqlParameter("@stokno", entity.Stokno),
                    new SqlParameter("@tanim",entity.Tanim),new SqlParameter("@miktar",entity.Miktar),new SqlParameter("@birim",entity.Birim));

                dataReader.Close();
                return entity.Stokno + " Nolu Stok Kaydı Başarıyla Güncelledi.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static SatMalListDal GetInstance()
        {
            if (satMalListDal == null)
            {
                satMalListDal = new SatMalListDal();
            }
            return satMalListDal;
        }
    }
}
