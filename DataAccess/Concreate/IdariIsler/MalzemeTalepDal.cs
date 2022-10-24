using DataAccess.Abstract;
using DataAccess.Database;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.IdariIsler
{
    public class MalzemeTalepDal //: IRepository<MalzemeTalep>
    {
        static MalzemeTalepDal malzemeTalepDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private MalzemeTalepDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(MalzemeTalep entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeTalepEkle",
                    new SqlParameter("@malzemeKategori", entity.MalzemeKategorisi),
                    new SqlParameter("@talepEdenPersonel", entity.TalepEdenPersonel),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@talebiOlusturan", entity.TalebiOlusturan),
                    new SqlParameter("@bolum", entity.Bolum),
                    new SqlParameter("@masrafYeri", entity.MasrafYeri));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public MalzemeTalep Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<MalzemeTalep> GetList()
        {
            try
            {
                List<MalzemeTalep> malzemeTaleps = new List<MalzemeTalep>();
                dataReader = sqlServices.StoreReader("MalzemeTalepList");
                while (dataReader.Read())
                {
                    malzemeTaleps.Add(new MalzemeTalep(
                        dataReader["ID"].ConInt(),
                        dataReader["MALZEME_KATEGORISI"].ToString(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["TALEBI_OLUSTURAN"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["SAT_BILGISI"].ConInt(),
                        dataReader["MASRAF_YERI"].ToString()));
                }
                dataReader.Close();
                return malzemeTaleps;
            }
            catch (Exception)
            {
                return new List<MalzemeTalep>();
            }
        }

        public string Update(MalzemeTalep entity)
        {
            throw new NotImplementedException();
        }
        public static MalzemeTalepDal GetInstance()
        {
            if (malzemeTalepDal == null)
            {
                malzemeTalepDal = new MalzemeTalepDal();
            }
            return malzemeTalepDal;
        }
    }
}
