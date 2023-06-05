using DataAccess.Abstract;
using DataAccess.Database;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.AnaSayfa
{
    public class ArizaBildirimTuruDal //: IRepository<ArizaBildirimTuru>
    {
        static ArizaBildirimTuruDal arizaBildirimTuruDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private ArizaBildirimTuruDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static ArizaBildirimTuruDal GetInstance()
        {
            if (arizaBildirimTuruDal == null)
            {
                arizaBildirimTuruDal = new ArizaBildirimTuruDal();
            }
            return arizaBildirimTuruDal;
        }

        public string Add(ArizaBildirimTuru entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ArizaBildirimTuru Get()
        {
            try
            {
                dataReader = sqlServices.StoreReader("GrafikBildirimTuruList");
                ArizaBildirimTuru arizaBildirimTuru = null;
                while (dataReader.Read())
                {
                    arizaBildirimTuru = new ArizaBildirimTuru(
                        dataReader["SARF"].ConInt(),
                        dataReader["ENTEGRASYON"].ConInt(),
                        dataReader["ABF"].ConInt(),
                        dataReader["KISMI_CALISAN"].ConInt(),
                        dataReader["EKSTRA"].ConInt(),
                        dataReader["SAHA_KABUL"].ConInt(),
                        dataReader["ACMA_KAPATMA"].ConInt(),
                        dataReader["DIGER"].ConInt());
                }
                dataReader.Close();
                return arizaBildirimTuru;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ArizaBildirimTuru> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(ArizaBildirimTuru entity)
        {
            throw new NotImplementedException();
        }
    }
}
