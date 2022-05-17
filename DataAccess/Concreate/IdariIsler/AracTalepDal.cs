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
    public class AracTalepDal // : IRepository<AracTalep>
    {
        static AracTalepDal aracTalepDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AracTalepDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(AracTalep entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracTalepKayit",
                    new SqlParameter("@gorevEmriNo",entity.GorevEmriNo),
                    new SqlParameter("@butceKodu",entity.ButceKoduTanimi),
                    new SqlParameter("@aracTalepNedeni",entity.AracTalepNedeni),
                    new SqlParameter("@gidilecekYer",entity.GidilecekYer),
                    new SqlParameter("@baslamaTarihiSaati",entity.BaslamaTarihiSaati),
                    new SqlParameter("@bitisTarihiSaati",entity.BitisTarihiSaati),
                    new SqlParameter("@toplamSure",entity.ToplamSure),
                    new SqlParameter("@personelAdi",entity.PersonelAd),
                    new SqlParameter("@personelSiparis",entity.PersonelSiparis),
                    new SqlParameter("@unvani",entity.Unvani),
                    new SqlParameter("@personelMasYerNo",entity.PersonelMasYeriNo),
                    new SqlParameter("@personelMasYeri",entity.PersonelMasYeri),
                    new SqlParameter("@masrafYeriSorulusu",entity.MasrafYeriSorumlusu),
                    new SqlParameter("@plaka",entity.Plaka),
                    new SqlParameter("@aracSiparis",entity.AracSiparis),
                    new SqlParameter("@cikisKm",entity.CikisKm),
                    new SqlParameter("@donusKm",entity.DonusKm),
                    new SqlParameter("@aracZimmetliPersonel",entity.AracZimmetliPersonel),
                    new SqlParameter("@dosyaYolu",entity.DosyaYolu));

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
                sqlServices.Stored("AracTalepSil", new SqlParameter("@id",id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public AracTalep Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracTalepList",new SqlParameter("@id",id));
                AracTalep item = null;
                while (dataReader.Read())
                {
                    item = new AracTalep(
                        dataReader["ID"].ConInt(),
                        dataReader["GOREV_EMRI_NO"].ToString(),
                        dataReader["BUTCE_KODU_TANIMI"].ToString(),
                        dataReader["ARAC_TALEP_NEDENI"].ToString(),
                        dataReader["GIDILECEK_YER"].ToString(),
                        dataReader["BASLAMA_TARIHI_SAAT"].ConDate(),
                        dataReader["BITIS_TARIHI_SAATI"].ConDate(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["PERSONEL_ADI"].ToString(),
                        dataReader["PERSONEL_SIPARIS"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["PERSONEL_MAS_YERI_NO"].ToString(),
                        dataReader["PERSONEL_MAS_YERI"].ToString(),
                        dataReader["MASRAF_YERI_SORUMLUSU"].ToString(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["ARAC_SIPARIS"].ToString(),
                        dataReader["CIKIS_KM"].ConInt(),
                        dataReader["DONUS_KM"].ConInt(),
                        dataReader["ARAC_ZIMMET_PERSONELI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AracTalep> GetList()
        {
            try
            {
                List<AracTalep> aracTaleps = new List<AracTalep>();
                dataReader = sqlServices.StoreReader("AracTalepList");
                while (dataReader.Read())
                {
                    aracTaleps.Add(new AracTalep(
                        dataReader["ID"].ConInt(),
                        dataReader["GOREV_EMRI_NO"].ToString(),
                        dataReader["BUTCE_KODU_TANIMI"].ToString(),
                        dataReader["ARAC_TALEP_NEDENI"].ToString(),
                        dataReader["GIDILECEK_YER"].ToString(),
                        dataReader["BASLAMA_TARIHI_SAAT"].ConDate(),
                        dataReader["BITIS_TARIHI_SAATI"].ConDate(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["PERSONEL_ADI"].ToString(),
                        dataReader["PERSONEL_SIPARIS"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["PERSONEL_MAS_YERI_NO"].ToString(),
                        dataReader["PERSONEL_MAS_YERI"].ToString(),
                        dataReader["MASRAF_YERI_SORUMLUSU"].ToString(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["ARAC_SIPARIS"].ToString(),
                        dataReader["CIKIS_KM"].ConInt(),
                        dataReader["DONUS_KM"].ConInt(),
                        dataReader["ARAC_ZIMMET_PERSONELI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return aracTaleps;
            }
            catch (Exception)
            {
                return new List<AracTalep>();
            }
        }
        public List<AracTalep> GetListDevam(string durum)
        {
            try
            {
                List<AracTalep> aracTaleps = new List<AracTalep>();
                dataReader = sqlServices.StoreReader("AracTalepDevamList", new SqlParameter("@durum", durum));
                while (dataReader.Read())
                {
                    aracTaleps.Add(new AracTalep(
                        dataReader["ID"].ConInt(),
                        dataReader["GOREV_EMRI_NO"].ToString(),
                        dataReader["BUTCE_KODU_TANIMI"].ToString(),
                        dataReader["ARAC_TALEP_NEDENI"].ToString(),
                        dataReader["GIDILECEK_YER"].ToString(),
                        dataReader["BASLAMA_TARIHI_SAAT"].ConDate(),
                        dataReader["BITIS_TARIHI_SAATI"].ConDate(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["PERSONEL_ADI"].ToString(),
                        dataReader["PERSONEL_SIPARIS"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["PERSONEL_MAS_YERI_NO"].ToString(),
                        dataReader["PERSONEL_MAS_YERI"].ToString(),
                        dataReader["MASRAF_YERI_SORUMLUSU"].ToString(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["ARAC_SIPARIS"].ToString(),
                        dataReader["CIKIS_KM"].ConInt(),
                        dataReader["DONUS_KM"].ConInt(),
                        dataReader["ARAC_ZIMMET_PERSONELI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return aracTaleps;
            }
            catch (Exception)
            {
                return new List<AracTalep>();
            }
        }

        public string Update(AracTalep entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracTalepGuncelle",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@gorevEmriNo", entity.GorevEmriNo),
                    new SqlParameter("@butceKodu", entity.ButceKoduTanimi),
                    new SqlParameter("@aracTalepNedeni", entity.AracTalepNedeni),
                    new SqlParameter("@gidilecekYer", entity.GidilecekYer),
                    new SqlParameter("@baslamaTarihiSaati", entity.BaslamaTarihiSaati),
                    new SqlParameter("@bitisTarihiSaati", entity.BitisTarihiSaati),
                    new SqlParameter("@toplamSure", entity.ToplamSure),
                    new SqlParameter("@personelAdi", entity.PersonelAd),
                    new SqlParameter("@personelSiparis", entity.PersonelSiparis),
                    new SqlParameter("@unvani", entity.Unvani),
                    new SqlParameter("@personelMasYerNo", entity.PersonelMasYeriNo),
                    new SqlParameter("@personelMasYeri", entity.PersonelMasYeri),
                    new SqlParameter("@masrafYeriSorulusu", entity.MasrafYeriSorumlusu),
                    new SqlParameter("@plaka", entity.Plaka),
                    new SqlParameter("@aracSiparis", entity.AracSiparis),
                    new SqlParameter("@cikisKm", entity.CikisKm),
                    new SqlParameter("@donusKm", entity.DonusKm),
                    new SqlParameter("@aracZimmetliPersonel", entity.AracZimmetliPersonel),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string KayitKapat(DateTime donusTarihiSaati, int donusKm, int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracTalepKapat",
                    new SqlParameter("@id", id),
                    new SqlParameter("@donusTarihiSaati", donusTarihiSaati),
                    new SqlParameter("@donusKm", donusKm));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static AracTalepDal GetInstance()
        {
            if (aracTalepDal == null)
            {
                aracTalepDal = new AracTalepDal();
            }
            return aracTalepDal;
        }
    }
}
