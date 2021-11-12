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
    public class StokNoTanimDal : IRepository<StokNoTanim>
    {
        static StokNoTanimDal stokNoTanimDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        bool result;
        private StokNoTanimDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(StokNoTanim entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("StokNoTanımEkle", new SqlParameter("@stokno", entity.Stokno),new SqlParameter("@tanim",entity.Tanim));
                if (dataReader.Read())
                {
                    result = dataReader[0].ConBool();
                }
                dataReader.Close();
                if (result)
                {
                    return entity.Stokno + " Eklemek İstediğiniz Stok Numarası Zaten Mevcut.";
                }
                return entity.Stokno + " Stok Numarası Başarıyla Kaydedildi";
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
                sqlServices.Stored("StokNoTanımSil", new SqlParameter("@id", id));
                return "Masraf Yeri Numarası Başarıyla Silindi.";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public StokNoTanim Get(int id)
        {
            return null;
        }

        public List<StokNoTanim> GetList()
        {
            try
            {
                List<StokNoTanim> stokNos = new List<StokNoTanim>();
                dataReader = sqlServices.StoreReader("StokNoTanımListele");
                while (dataReader.Read())
                {
                    stokNos.Add(new StokNoTanim(dataReader["ID"].ConInt(),dataReader["STOK_NO"].ToString(),dataReader["TANIM"].ToString()));
                }
                dataReader.Close();
                return stokNos;
            }
            catch
            {
                return new List<StokNoTanim>();
            }
        }

        public string Update(StokNoTanim entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("StokNoTanımGuncelle",new SqlParameter("@id",entity.Id),new SqlParameter("@stokno",entity.Stokno),
                    new SqlParameter("@tanim",entity.Tanim));

                dataReader.Close();
                return entity.Stokno + " Stok Numarası Başarıyla Güncellendi.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static StokNoTanimDal GetInstance()
        {
            if (stokNoTanimDal == null)
            {
                stokNoTanimDal = new StokNoTanimDal();
            }
            return stokNoTanimDal;
        }
    }
}
