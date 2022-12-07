using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Depo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Depo
{
    public class DepoKayitDal //: IRepository<DepoKayit>
    {
        static DepoKayitDal depoKayitDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private DepoKayitDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(DepoKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoEkle",
                    new SqlParameter("@depo",entity.Depo),
                    new SqlParameter("@aciklama",entity.Aciklama));

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
            try
            {
                sqlServices.Stored("DepoDelete",new SqlParameter("@id",id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DepoKayit Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoListeleAdres",new SqlParameter("@id",id));
                DepoKayit item = null;
                while (dataReader.Read())
                {
                    item = new DepoKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["DEPO"].ToString(),
                        dataReader["ACIKLAMA"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DepoKayit> GetList()
        {
            try
            {
                List<DepoKayit> depoKayits = new List<DepoKayit>();
                dataReader = sqlServices.StoreReader("DepoListele");
                while (dataReader.Read())
                {
                    depoKayits.Add(new DepoKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["DEPO"].ToString(),
                        dataReader["ACIKLAMA"].ToString()));
                }
                dataReader.Close();
                return depoKayits;
            }
            catch (Exception)
            {
                return new List<DepoKayit>();
            }
        }
        public List<DepoKayitLokasyon> GetListLokasyon(int depoId)
        {
            try
            {
                List<DepoKayitLokasyon> depoKayits = new List<DepoKayitLokasyon>();
                dataReader = sqlServices.StoreReader("DepoListele",new SqlParameter("@id",depoId));
                while (dataReader.Read())
                {
                    depoKayits.Add(new DepoKayitLokasyon(
                        dataReader["ID"].ConInt(),
                        dataReader["DEPO_BILGILERI_ID"].ConInt(),
                        dataReader["LOKASYON"].ToString(),
                        dataReader["ACIKLAMA"].ToString()));
                }
                dataReader.Close();
                return depoKayits;
            }
            catch (Exception)
            {
                return new List<DepoKayitLokasyon>();
            }
        }

        public string Update(DepoKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoGuncelle",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@depo",entity.Depo),
                    new SqlParameter("@aciklama",entity.Aciklama));
                dataReader.Close();
                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static DepoKayitDal GetInstance()
        {
            if (depoKayitDal == null)
            {
                depoKayitDal = new DepoKayitDal();
            }
            return depoKayitDal;
        }
    }
}
