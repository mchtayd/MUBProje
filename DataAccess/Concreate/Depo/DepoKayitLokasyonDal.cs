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
    public class DepoKayitLokasyonDal // : IRepository<DepoKayitLokasyon>
    {
        static DepoKayitLokasyonDal depoKayitLokasyonDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private DepoKayitLokasyonDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(DepoKayitLokasyon entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoLokasyonEkle",
                    new SqlParameter("@depoId",entity.DepoId),
                    new SqlParameter("@lokasyon",entity.Lokasyon),
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
                sqlServices.Stored("DepoLokasyonDelete", new SqlParameter("@id",id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<DepoKayitLokasyon> GetListLokasyon(int depoId)
        {
            try
            {
                List<DepoKayitLokasyon> depoKayitLokasyons = new List<DepoKayitLokasyon>();
                dataReader = sqlServices.StoreReader("DepoLokasyonBilgileri",new SqlParameter("@depoId", depoId));
                
                while (dataReader.Read())
                {
                    depoKayitLokasyons.Add(new DepoKayitLokasyon(dataReader["LOKASYON"].ToString()));
                }
                dataReader.Close();
                return depoKayitLokasyons;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DepoKayitLokasyon> GetList()
        {
            try
            {
                List<DepoKayitLokasyon> depoKayitLokasyons = new List<DepoKayitLokasyon>();
                dataReader = sqlServices.StoreReader("DepoLokasyonList");
                while (dataReader.Read())
                {
                    depoKayitLokasyons.Add(new DepoKayitLokasyon(
                        dataReader["DEPO_BILGILERI_ID"].ConInt(),
                        dataReader["LOKASYON"].ToString(),
                        dataReader["ACIKLAMA"].ToString()));
                }
                dataReader.Close();
                return depoKayitLokasyons;
            }
            catch (Exception)
            {
                return new List<DepoKayitLokasyon>();
            }
        }

        public string Update(DepoKayitLokasyon entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoLokasyonGuncelle",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@depoId", entity.DepoId),
                    new SqlParameter("@lokasyon", entity.Lokasyon),
                    new SqlParameter("@aciklama", entity.Aciklama));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static DepoKayitLokasyonDal GetInstance()
        {
            if (depoKayitLokasyonDal == null)
            {
                depoKayitLokasyonDal = new DepoKayitLokasyonDal();
            }
            return depoKayitLokasyonDal;
        }
    }
}
