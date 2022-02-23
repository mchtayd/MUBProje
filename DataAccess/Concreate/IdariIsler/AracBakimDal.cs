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
    public class AracBakimDal //: IRepository<AracBakim>
    {
        static AracBakimDal aracBakimDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AracBakimDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(AracBakim entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracBakimKayit",
                    new SqlParameter("@isAkisNo",entity.IsAkisNo),
                    new SqlParameter("@plaka",entity.Plaka),
                    new SqlParameter("@marka",entity.Marka),
                    new SqlParameter("@modelYili",entity.ModelYili),
                    new SqlParameter("@motorNo",entity.MotorNo),
                    new SqlParameter("@saseNo",entity.SaseNo),
                    new SqlParameter("@mulkiyet",entity.MulkiyetBilgileri),
                    new SqlParameter("@siparisNo",entity.SiparisNo),
                    new SqlParameter("@projeTahsisTarihi",entity.ProjeTahsisTarihi),
                    new SqlParameter("@kullanildigiBolum",entity.KullanildigiBolum),
                    new SqlParameter("@zimmetliPersonel",entity.ZimmetliPersonel),
                    new SqlParameter("@km",entity.Km),
                    new SqlParameter("@bakimNedeni",entity.BakimNedeni),
                    new SqlParameter("@talepTarihi",entity.TalepTarihi),
                    new SqlParameter("@arizaAciklama",entity.ArizaAciklamasi),
                    new SqlParameter("@dosyaYolu",entity.DosyaYolu),
                    new SqlParameter("@teslimPersonel",entity.TeslimPersonel),
                    new SqlParameter("@teslimPersonelBolum",entity.TeslimPersonelBolum));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string GecmisKayit(AracBakim entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracBakimGecmisKayit",
                    new SqlParameter("@isAkisNo", entity.IsAkisNo),
                    new SqlParameter("@plaka", entity.Plaka),
                    new SqlParameter("@marka", entity.Marka),
                    new SqlParameter("@modelYili", entity.ModelYili),
                    new SqlParameter("@motorNo", entity.MotorNo),
                    new SqlParameter("@saseNo", entity.SaseNo),
                    new SqlParameter("@mulkiyet", entity.MulkiyetBilgileri),
                    new SqlParameter("@siparisNo", entity.SiparisNo),
                    new SqlParameter("@projeTahsisTarihi", entity.ProjeTahsisTarihi),
                    new SqlParameter("@kullanildigiBolum", entity.KullanildigiBolum),
                    new SqlParameter("@zimmetliPersonel", entity.ZimmetliPersonel),
                    new SqlParameter("@km", entity.Km),
                    new SqlParameter("@bakimNedeni", entity.BakimNedeni),
                    new SqlParameter("@talepTarihi", entity.TalepTarihi),
                    new SqlParameter("@bakYapanFirma", entity.BakYapanFirma),
                    new SqlParameter("@arizaAciklama", entity.ArizaAciklamasi),
                    new SqlParameter("@tamamlanmaTarihi",entity.TamamlanmaTarih),
                    new SqlParameter("@sonucAciklama",entity.SonucAciklama),
                    new SqlParameter("@toplamTutar",entity.Tutar),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@teslimPersonel", entity.TeslimPersonel),
                    new SqlParameter("@teslimPersonelBolum", entity.TeslimPersonelBolum));
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
                dataReader = sqlServices.StoreReader("AracBakimKayitSil",new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public AracBakim Get(int isAkisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracBakimKayitList",new SqlParameter("@isAkisNo", isAkisNo));
                AracBakim item = null;
                while (dataReader.Read())
                {
                    item = new AracBakim(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["MARKA"].ToString(),
                        dataReader["MODEL_YILI"].ToString(),
                        dataReader["MOTOR_NO"].ToString(),
                        dataReader["SASE_NO"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["PROJE_TAHSIS_TARIHI"].ConDate(),
                        dataReader["KULLANILDIGI_BOLUM"].ToString(),
                        dataReader["ZIMMETLI_PERSONEL"].ToString(),
                        dataReader["ARAC_KM"].ConInt(),
                        dataReader["BAKIM_NEDENI"].ToString(),
                        dataReader["TALEP_TARIHI"].ConDate(),
                        dataReader["BAKIM_YAPAN_FIRMA"].ToString(),
                        dataReader["ARIZA_ACIKLAMASI"].ToString(),
                        dataReader["TAMAMLANMA_TARIHI"].ConDate(),
                        dataReader["SONUC_ACIKLAMA"].ToString(),
                        dataReader["TOPLAM_TUTAR"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["TESLIM_PERSONEL"].ToString(),
                        dataReader["TESLIM_PERSONEL_BOLUM"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public AracBakim AracBakimSonKayit(string plaka)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracBakimSonKayit", new SqlParameter("@plaka", plaka));
                AracBakim item = null;
                while (dataReader.Read())
                {
                    item = new AracBakim(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["MARKA"].ToString(),
                        dataReader["MODEL_YILI"].ToString(),
                        dataReader["MOTOR_NO"].ToString(),
                        dataReader["SASE_NO"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["PROJE_TAHSIS_TARIHI"].ConDate(),
                        dataReader["KULLANILDIGI_BOLUM"].ToString(),
                        dataReader["ZIMMETLI_PERSONEL"].ToString(),
                        dataReader["ARAC_KM"].ConInt(),
                        dataReader["BAKIM_NEDENI"].ToString(),
                        dataReader["TALEP_TARIHI"].ConDate(),
                        dataReader["BAKIM_YAPAN_FIRMA"].ToString(),
                        dataReader["ARIZA_ACIKLAMASI"].ToString(),
                        dataReader["TAMAMLANMA_TARIHI"].ConDate(),
                        dataReader["SONUC_ACIKLAMA"].ToString(),
                        dataReader["TOPLAM_TUTAR"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["TESLIM_PERSONEL"].ToString(),
                        dataReader["TESLIM_PERSONEL_BOLUM"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<AracBakim> DevamDevamsizlik()
        {
            try
            {
                List<AracBakim> aracBakims = new List<AracBakim>();
                dataReader = sqlServices.StoreReader("DevamAracBakimKayitList");
                while (dataReader.Read())
                {
                    DateTime startDate = dataReader["TALEP_TARIHI"].ConDate();
                    string gecenSure = (DateTime.Now.Subtract(startDate)).ToString();
                    gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.'));

                    aracBakims.Add(new AracBakim(
                        dataReader["PLAKA"].ToString(),
                        dataReader["MARKA"].ToString(),
                        dataReader["BAKIM_NEDENI"].ToString(),
                        dataReader["ARIZA_ACIKLAMASI"].ToString(),
                        startDate,
                        gecenSure));
                }
                dataReader.Close();
                return aracBakims;
            }
            catch (Exception)
            {
                return new List<AracBakim>();
            }
        }

        public List<AracBakim> GetList(int isAkisNo) // TIKLAMA VE LİSTELEME
        {
            try
            {
                List<AracBakim> aracBakims = new List<AracBakim>();
                dataReader = sqlServices.StoreReader("AracBakimKayitList",new SqlParameter("@isAkisNo",isAkisNo));
                while (dataReader.Read())
                {
                    aracBakims.Add(new AracBakim(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["MARKA"].ToString(),
                        dataReader["MODEL_YILI"].ToString(),
                        dataReader["MOTOR_NO"].ToString(),
                        dataReader["SASE_NO"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["PROJE_TAHSIS_TARIHI"].ConDate(),
                        dataReader["KULLANILDIGI_BOLUM"].ToString(),
                        dataReader["ZIMMETLI_PERSONEL"].ToString(),
                        dataReader["ARAC_KM"].ConInt(),
                        dataReader["BAKIM_NEDENI"].ToString(),
                        dataReader["TALEP_TARIHI"].ConDate(),
                        dataReader["BAKIM_YAPAN_FIRMA"].ToString(),
                        dataReader["ARIZA_ACIKLAMASI"].ToString(),
                        dataReader["TAMAMLANMA_TARIHI"].ConDate(),
                        dataReader["SONUC_ACIKLAMA"].ToString(),
                        dataReader["TOPLAM_TUTAR"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["TESLIM_PERSONEL"].ToString(),
                        dataReader["TESLIM_PERSONEL_BOLUM"].ToString()));
                }
                dataReader.Close();
                return aracBakims;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<AracBakim> AracBakimKayitListKapatilmis() // tamamlanan devam eden
        {
            try
            {
                List<AracBakim> aracBakims = new List<AracBakim>();
                dataReader = sqlServices.StoreReader("AracBakimKayitListKapatilmis");
                while (dataReader.Read())
                {
                    aracBakims.Add(new AracBakim(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["MARKA"].ToString(),
                        dataReader["MODEL_YILI"].ToString(),
                        dataReader["MOTOR_NO"].ToString(),
                        dataReader["SASE_NO"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["PROJE_TAHSIS_TARIHI"].ConDate(),
                        dataReader["KULLANILDIGI_BOLUM"].ToString(),
                        dataReader["ZIMMETLI_PERSONEL"].ToString(),
                        dataReader["ARAC_KM"].ConInt(),
                        dataReader["BAKIM_NEDENI"].ToString(),
                        dataReader["TALEP_TARIHI"].ConDate(),
                        dataReader["BAKIM_YAPAN_FIRMA"].ToString(),
                        dataReader["ARIZA_ACIKLAMASI"].ToString(),
                        dataReader["TAMAMLANMA_TARIHI"].ConDate(),
                        dataReader["SONUC_ACIKLAMA"].ToString(),
                        dataReader["TOPLAM_TUTAR"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["TESLIM_PERSONEL"].ToString(),
                        dataReader["TESLIM_PERSONEL_BOLUM"].ToString()));
                }
                dataReader.Close();
                return aracBakims;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Update(AracBakim entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracBakimKayitGuncelle",
                    new SqlParameter("@isAkisNo", entity.IsAkisNo),
                    new SqlParameter("@plaka", entity.Plaka),
                    new SqlParameter("@marka", entity.Marka),
                    new SqlParameter("@modelYili", entity.ModelYili),
                    new SqlParameter("@motorNo", entity.MotorNo),
                    new SqlParameter("@saseNo", entity.SaseNo),
                    new SqlParameter("@mulkiyet", entity.MulkiyetBilgileri),
                    new SqlParameter("@siparisNo", entity.SiparisNo),
                    new SqlParameter("@projeTahsisTarihi", entity.ProjeTahsisTarihi),
                    new SqlParameter("@kullanildigiBolum", entity.KullanildigiBolum),
                    new SqlParameter("@zimmetliPersonel", entity.ZimmetliPersonel),
                    new SqlParameter("@km", entity.Km),
                    new SqlParameter("@bakimNedeni", entity.BakimNedeni),
                    new SqlParameter("@talepTarihi", entity.TalepTarihi),
                    new SqlParameter("@bakimYapanFirma", entity.BakYapanFirma),
                    new SqlParameter("@arizaAciklama", entity.ArizaAciklamasi),
                    new SqlParameter("@tamamlanmaTarihi",entity.TamamlanmaTarih),
                    new SqlParameter("@sonucAciklama",entity.SonucAciklama),
                    new SqlParameter("@toplamTutar",entity.Tutar),
                    new SqlParameter("@teslimPersonel", entity.TeslimPersonel),
                    new SqlParameter("@teslimPersonelBolum", entity.TeslimPersonelBolum));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Kapat(AracBakim entity,int isAkisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracBakimKayitKapat",
                    new SqlParameter("@isAkisNo", isAkisNo),
                    new SqlParameter("@bakYapanFirma",entity.BakYapanFirma),
                    new SqlParameter("@sonucAciklama", entity.SonucAciklama),
                    new SqlParameter("@toplamTutar", entity.Tutar),
                    new SqlParameter("@tamamlanmaTarihi", entity.TamamlanmaTarih));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static AracBakimDal GetInstance()
        {
            if (aracBakimDal == null)
            {
                aracBakimDal = new AracBakimDal();
            }
            return aracBakimDal;
        }
    }
}
