using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Butce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Butce
{
    public class KasaDurumDal // : IRepository<KasaDurum>
    {
        static KasaDurumDal kasaDurumDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private KasaDurumDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(KasaDurum entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public KasaDurum Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("KasaDurumGor",new SqlParameter("@id",id));
                KasaDurum item = null;
                while (dataReader.Read())
                {
                    item = new KasaDurum(
                        dataReader["ID"].ConInt(),
                        dataReader["KASA_GELIR"].ConDouble(),
                        dataReader["KASA_GIDER"].ConDouble(),
                        dataReader["KASA_KALAN"].ConDouble());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<KasaDurum> GetList()
        {
            throw new NotImplementedException();
        }

        public string UpdateGelir(double kasaGelir)
        {
            try
            {
                dataReader = sqlServices.StoreReader("KasaGelirGuncelle",new SqlParameter("@kasaGelir", kasaGelir));
                dataReader.Close();
                return "OK";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string UpdateGider(double kasaGider)
        {
            try
            {
                dataReader = sqlServices.StoreReader("KasaGiderGuncelle", new SqlParameter("@kasaGider", kasaGider));
                dataReader.Close();
                return "OK";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static KasaDurumDal GetInstance()
        {
            if (kasaDurumDal == null)
            {
                kasaDurumDal = new KasaDurumDal();
            }
            return kasaDurumDal;
        }
    }
}
