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
    public class AracKmDal // : IRepository<AracKm>
    {
        static AracKmDal aracKmDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AracKmDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(AracKm entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracKmKayit",
                    new SqlParameter("@plaka", entity.Plaka),
                    new SqlParameter("@aracSiparis", entity.SiparisNo),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@donem", entity.Donem),
                    new SqlParameter("@baslangicKm", entity.BaslangicKm),
                    new SqlParameter("@personelAd", entity.PersonelAd),
                    new SqlParameter("@personelSiparis", entity.PersonelSiparis),
                    new SqlParameter("@personeUnvani", entity.PersonelUnvani),
                    new SqlParameter("@personelMasrafYeriNo", entity.PerMasYeriNo),
                    new SqlParameter("@personelMasrafYeri", entity.PerMasYeri),
                    new SqlParameter("@masYerSorumlusu", entity.PersMasYerSorumlusu),
                    new SqlParameter("@aracMulkiyet", entity.AracMulkiyet),
                    new SqlParameter("@kmBitisTarihi", entity.KmBitisTarihi),
                    new SqlParameter("@bitisKm", entity.BitisKm),
                    new SqlParameter("@toplamYapilanKm", entity.ToplamYapilanKm),
                    new SqlParameter("@sabitKm", entity.SabitKm),
                    new SqlParameter("@fark", entity.Fark),
                    new SqlParameter("@siparis", entity.Siparis));
                
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
                dataReader = sqlServices.StoreReader("AracKmSil", new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public AracKm Get(string plaka)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracKmList",new SqlParameter("@plaka", plaka));
                AracKm item = null;
                while (dataReader.Read())
                {
                    item = new AracKm(
                        dataReader["ID"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["ARAC_SIPARIS"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["DONEM"].ToString(),
                        dataReader["BASLANGIC_KM"].ConInt(),
                        dataReader["PERSONEL_AD"].ToString(),
                        dataReader["PERSONEL_SIPARIS"].ToString(),
                        dataReader["PERSONEL_UNVANI"].ToString(),
                        dataReader["PERSONEL_MASRAF_YERI_NO"].ToString(),
                        dataReader["PERSONEL_MASRAF_YERI"].ToString(),
                        dataReader["MAS_YER_SORUMLUSU"].ToString(),
                        dataReader["ARAC_MULKIYET"].ToString(),
                        dataReader["KM_BITIS_TARIHI"].ConDate(),
                        dataReader["BITIS_KM"].ConInt(),
                        dataReader["TOPLAM_YAPILAN_KM"].ConInt(),
                        dataReader["SABIT_KM"].ConInt(),
                        dataReader["FARK"].ConInt(),
                        dataReader["SIPARIS"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public AracKm GetGuncelle(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracKmGet", new SqlParameter("@id", id));
                AracKm item = null;
                while (dataReader.Read())
                {
                    item = new AracKm(
                        dataReader["ID"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["ARAC_SIPARIS"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["DONEM"].ToString(),
                        dataReader["BASLANGIC_KM"].ConInt(),
                        dataReader["PERSONEL_AD"].ToString(),
                        dataReader["PERSONEL_SIPARIS"].ToString(),
                        dataReader["PERSONEL_UNVANI"].ToString(),
                        dataReader["PERSONEL_MASRAF_YERI_NO"].ToString(),
                        dataReader["PERSONEL_MASRAF_YERI"].ToString(),
                        dataReader["MAS_YER_SORUMLUSU"].ToString(),
                        dataReader["ARAC_MULKIYET"].ToString(),
                        dataReader["KM_BITIS_TARIHI"].ConDate(),
                        dataReader["BITIS_KM"].ConInt(),
                        dataReader["TOPLAM_YAPILAN_KM"].ConInt(),
                        dataReader["SABIT_KM"].ConInt(),
                        dataReader["FARK"].ConInt(),
                        dataReader["SIPARIS"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AracKm> GetList()
        {
            try
            {
                List<AracKm> aracKms = new List<AracKm>();
                dataReader = sqlServices.StoreReader("AracKmList");
                while (dataReader.Read())
                {
                    aracKms.Add(new AracKm(
                        dataReader["ID"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["ARAC_SIPARIS"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["DONEM"].ToString(),
                        dataReader["BASLANGIC_KM"].ConInt(),
                        dataReader["PERSONEL_AD"].ToString(),
                        dataReader["PERSONEL_SIPARIS"].ToString(),
                        dataReader["PERSONEL_UNVANI"].ToString(),
                        dataReader["PERSONEL_MASRAF_YERI_NO"].ToString(),
                        dataReader["PERSONEL_MASRAF_YERI"].ToString(),
                        dataReader["MAS_YER_SORUMLUSU"].ToString(),
                        dataReader["ARAC_MULKIYET"].ToString(),
                        dataReader["KM_BITIS_TARIHI"].ConDate(),
                        dataReader["BITIS_KM"].ConInt(),
                        dataReader["TOPLAM_YAPILAN_KM"].ConInt(),
                        dataReader["SABIT_KM"].ConInt(),
                        dataReader["FARK"].ConInt(),
                        dataReader["SIPARIS"].ToString()));
                }
                dataReader.Close();
                return aracKms;
            }
            catch (Exception)
            {
                return new List<AracKm>();
            }
        }

        public string Update(AracKm entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracKmGuncelle",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@plaka",entity.Plaka),
                   new SqlParameter("@aracSiparis", entity.SiparisNo),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@donem", entity.Donem),
                    new SqlParameter("@baslangicKm", entity.BaslangicKm),
                    new SqlParameter("@personelAd", entity.PersonelAd),
                    new SqlParameter("@personelSiparis", entity.PersonelSiparis),
                    new SqlParameter("@personeUnvani", entity.PersonelUnvani),
                    new SqlParameter("@personelMasrafYeriNo", entity.PerMasYeriNo),
                    new SqlParameter("@personelMasrafYeri", entity.PerMasYeri),
                    new SqlParameter("@masYerSorumlusu", entity.PersMasYerSorumlusu),
                    new SqlParameter("@aracMulkiyet", entity.AracMulkiyet),
                    new SqlParameter("@kmBitisTarihi",entity.KmBitisTarihi),
                    new SqlParameter("@bitisKm",entity.BitisKm),
                    new SqlParameter("@toplamYapilanKm",entity.ToplamYapilanKm),
                    new SqlParameter("@sabitKm",entity.SabitKm),
                    new SqlParameter("@fark",entity.Fark));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static AracKmDal GetInstance()
        {
            if (aracKmDal == null)
            {
                aracKmDal = new AracKmDal();
            }
            return aracKmDal;
        }
    }
}
