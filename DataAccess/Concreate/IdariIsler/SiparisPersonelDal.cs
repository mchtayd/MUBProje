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
    public class SiparisPersonelDal
    {
        static SiparisPersonelDal siparisPersonelDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private SiparisPersonelDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(SiparisPersonel entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SiparisPersonel Get(string siparisno,string adsoyad)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SiparisPersonelListele", new SqlParameter("@siparis", siparisno),new SqlParameter("@adsoyad",adsoyad));
                SiparisPersonel item = null;
                while (dataReader.Read())
                {
                    item = new SiparisPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["SIPARIS"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["SIRKET_BOLUM"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["PROJE_KODU"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["TC"].ToString(),
                        dataReader["HES_KODU"].ToString(),
                        dataReader["SIRKET_MAIL"].ToString(),
                        dataReader["SIRKET_KISAKOD"].ToString(),
                        dataReader["IS_UNVANI"].ToString(),
                        dataReader["SICIL"].ToString(),
                        dataReader["MASRAF_YERI_SORUMLUSU"].ToString());
                }
                dataReader.Close();
                return item;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SiparisPersonel> GetList(string siparis,string adssoyad)
        {
            try
            {
                List<SiparisPersonel> siparisPersonels = new List<SiparisPersonel>();
                dataReader = sqlServices.StoreReader("SiparisPersonelListele", new SqlParameter("@siparis",siparis));
                while (dataReader.Read())
                {
                    siparisPersonels.Add(new SiparisPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["SIPARIS"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["SIRKET_BOLUM"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["PROJE_KODU"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["TC"].ToString(),
                        dataReader["HES_KODU"].ToString(),
                        dataReader["SIRKET_MAIL"].ToString(),
                        dataReader["SIRKET_KISAKOD"].ToString(),
                        dataReader["IS_UNVANI"].ToString(),
                        dataReader["SICIL"].ToString(),
                        dataReader["MASRAF_YERI_SORUMLUSU"].ToString()));
                }
                dataReader.Close();
                return siparisPersonels;
            }
            catch(Exception)
            {
                return new List<SiparisPersonel>();
            }
        }
        public List<SiparisPersonel> MasrafYeriSorumlusu()
        {
            try
            {
                List<SiparisPersonel> siparisPersonels = new List<SiparisPersonel>();
                dataReader = sqlServices.StoreReader("MasrafYeriSorumlusu");
                while (dataReader.Read())
                {
                    siparisPersonels.Add(new SiparisPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["SIPARIS"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["SIRKET_BOLUM"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["PROJE_KODU"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["TC"].ToString(),
                        dataReader["HES_KODU"].ToString(),
                        dataReader["SIRKET_MAIL"].ToString(),
                        dataReader["SIRKET_KISAKOD"].ToString(),
                        dataReader["IS_UNVANI"].ToString(),
                        dataReader["SICIL"].ToString(),
                        dataReader["MASRAF_YERI_SORUMLUSU"].ToString()));
                }
                dataReader.Close();
                return siparisPersonels;
            }
            catch (Exception)
            {
                return new List<SiparisPersonel>();
            }
        }
        public List<SiparisPersonel> IstekteBulunan(string siparis, string adsoyad)
        {
            try
            {
                List<SiparisPersonel> siparisPersonels = new List<SiparisPersonel>();
                dataReader = sqlServices.StoreReader("IstektekBulunan", new SqlParameter("@siparis", siparis),
                    new SqlParameter("@personelad", adsoyad));
                while (dataReader.Read())
                {
                    siparisPersonels.Add(new SiparisPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["SIPARIS"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["SIRKET_BOLUM"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["PROJE_KODU"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["TC"].ToString(),
                        dataReader["HES_KODU"].ToString(),
                        dataReader["SIRKET_MAIL"].ToString(),
                        dataReader["SIRKET_KISAKOD"].ToString(),
                        dataReader["IS_UNVANI"].ToString(),
                        dataReader["SICIL"].ToString(),
                        dataReader["MASRAF_YERI_SORUMLUSU"].ToString()));
                }
                dataReader.Close();
                return siparisPersonels;
            }
            catch(Exception)
            {
                return new List<SiparisPersonel>();
            }
        }

        public string Update(SiparisPersonel entity)
        {
            throw new NotImplementedException();
        }
        public static SiparisPersonelDal GetInstance()
        {
            if (siparisPersonelDal == null)
            {
                siparisPersonelDal = new SiparisPersonelDal();
            }
            return siparisPersonelDal;
        }
    }
}
