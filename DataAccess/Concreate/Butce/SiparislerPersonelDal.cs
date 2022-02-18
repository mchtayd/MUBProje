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
    public class SiparislerPersonelDal // : IRepository<SiparislerPersonel>
    {
        static SiparislerPersonelDal siparislerPersonelDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private SiparislerPersonelDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(SiparislerPersonel entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SiparislerPersonelEkle",
                    new SqlParameter("@adiSoyadi",entity.PersonelAdi),
                    new SqlParameter("@unvani",entity.Unvani),
                    new SqlParameter("@bolumu",entity.Bolumu),
                    new SqlParameter("@masrafYeriSorumlusu",entity.MasrafYeriSorumlusu),
                    new SqlParameter("@durumu",entity.Durumu),
                    new SqlParameter("@siparis",entity.Siparis),
                    new SqlParameter("@tarih",entity.Tarih));

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

        public SiparislerPersonel Get(string siparis)
        {
            throw new NotImplementedException();
        }

        public List<SiparislerPersonel> GetList(string siparis)
        {
            try
            {
                List<SiparislerPersonel> siparislerPersonels = new List<SiparislerPersonel>();
                dataReader = sqlServices.StoreReader("SiparislerPersonelListele", new SqlParameter("@siparis", siparis));
                while (dataReader.Read())
                {
                    siparislerPersonels.Add(new SiparislerPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["AD_SOYADI"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["BOLUMU"].ToString(),
                        dataReader["MASRAF_YERI_SORUMLUSU"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["SIPARIS"].ToString(),
                        dataReader["TARIH"].ConDate()));
                }
                dataReader.Close();
                return siparislerPersonels;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string Update(SiparislerPersonel entity)
        {
            throw new NotImplementedException();
        }
        public static SiparislerPersonelDal GetInstance()
        {
            if (siparislerPersonelDal == null)
            {
                siparislerPersonelDal = new SiparislerPersonelDal();
            }
            return siparislerPersonelDal;
        }
    }
}
