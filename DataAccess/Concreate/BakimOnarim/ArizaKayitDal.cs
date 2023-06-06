using DataAccess.Abstract;
using DataAccess.Database;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace DataAccess.Concreate.BakimOnarim
{
    public class ArizaKayitDal //: IRepository<ArizaKayit>
    {
        static ArizaKayitDal arizaKayitDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private ArizaKayitDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(ArizaKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BakimOnarimArizaKayit",
                    new SqlParameter("@isAkisNo", entity.IsAkisNo),
                    new SqlParameter("@abfFormNo", entity.AbfFormNo),
                    new SqlParameter("@proje", entity.Proje),
                    new SqlParameter("@bolgeAdi", entity.BolgeAdi),
                    new SqlParameter("@bolukKomutani", entity.BolukKomutani),
                    new SqlParameter("@telefonNo", entity.TelefonNo),
                    new SqlParameter("@birlikAdresi", entity.BirlikAdresi),
                    new SqlParameter("@il", entity.Il),
                    new SqlParameter("@ilce", entity.Ilce),
                    new SqlParameter("@bildirilenAriza", entity.BildirilenAriza),
                    new SqlParameter("@arizayiBildirenPersonel", entity.ArizaiBildirenPersonel),
                    new SqlParameter("@abRutbesi", entity.AbRutbesi),
                    new SqlParameter("@abGorevi", entity.AbGorevi),
                    new SqlParameter("@abTelefon", entity.AbTelefon),
                    new SqlParameter("@abTarihSaat", entity.AbTarihSaat),
                    new SqlParameter("@ABAlanPersonel", entity.ABAlanPersonel),
                    new SqlParameter("@bildirimKanali", entity.BildirimKanali),
                    new SqlParameter("@arizaAciklama", entity.ArizaAciklama),
                    new SqlParameter("@gorevAtanacakPersonel", entity.GorevAtanacakPersonel),
                    new SqlParameter("@islemAdimi", entity.IslemAdimi),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@siparisNo", entity.SiparisNo),
                    new SqlParameter("@projeTanim", entity.ProjeTanimi),
                    new SqlParameter("@musteri", entity.Musteri));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string IslemAdimiGuncelle(int id, string islemAdimi, string gorevAtanacakPersonel, int arizaDurum = 0)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BakimOnarimIslemAdimiGuncelle",
                    new SqlParameter("@id", id), new SqlParameter("@islemAdimi", islemAdimi),
                    new SqlParameter("@gorevAtanacakPersonel", gorevAtanacakPersonel));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string AbfKapat(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BakimOnarimKayitKapat",
                    new SqlParameter("@id", id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ArizaMalzemeDurum(int id, string malzemeDurumu)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ArizaMalzemeDurum",
                    new SqlParameter("@id", id),
                    new SqlParameter("@malzemeDurumu", malzemeDurumu));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string BOEksikEvrakKayit(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BOEksikEvrakKayit",
                    new SqlParameter("@id", id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string ArizaSiparisOlustur(ArizaKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BakimOanrimSiparisOlustur",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@garantiDurumu", entity.GarantiDurumu),
                    new SqlParameter("@lojSorumlusu", entity.LojistikSorumluPersonel),
                    new SqlParameter("@lojRutbesi", entity.LojRutbesi),
                    new SqlParameter("@lojGorevi", entity.LojGorevi),
                    new SqlParameter("@lojTarihi", entity.LojTarihi),
                    new SqlParameter("@tespitEdilenAriza", entity.TespitEdilenAriza),
                    new SqlParameter("@acmaOnayiVeren", entity.AcmaOnayiVeren));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string CrmNoTanimla(ArizaKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BakimOnarimCrmNoTanimla",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@csSiparisNo", entity.CsSiparisNo),
                    new SqlParameter("@bildirimNo", entity.BildirimNo),
                    new SqlParameter("@crmNo", entity.CrmNo),
                    new SqlParameter("@mailTarihi", entity.BildirimMailTarihi),
                    new SqlParameter("@ekipmanNo", entity.EkipmanNo),
                    new SqlParameter("@okfBildirimNo", entity.OkfBildirimNo));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SistemCihazBilgileri(ArizaKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BakimOanrimSistemCihazBilgileri",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@seriNo", entity.SeriNo),
                    new SqlParameter("@kategori", entity.Kategori),
                    new SqlParameter("@ilgiliFirma", entity.IlgiliFirma),
                    new SqlParameter("@bildirimTuru", entity.BildirimTuru),
                    new SqlParameter("@pypNo", entity.PypNo),
                    new SqlParameter("@sorumluPersonel", entity.SorumluPersonel),
                    new SqlParameter("@siparisTuru", entity.SiparisTuru),
                    new SqlParameter("@islemTuru", entity.IslemTuru),
                    new SqlParameter("@hesaplama", entity.Hesaplama));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SistemCihazBilgileri2(ArizaKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BakimOanrimSistemCihazBilgileri2",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@seriNo", entity.SeriNo));

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
                sqlServices.Stored("BakimOnarimArizaKayitDelete", new SqlParameter("@id", id));
                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ArizaKayit Get(int abfFormNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BakimOnarimArizaKayitList", new SqlParameter("@abfFormNo", abfFormNo));
                ArizaKayit item = null;
                while (dataReader.Read())
                {
                    DateTime startDate = dataReader["AB_TARIH_SAAT"].ConDate();
                    string gecenSure = (DateTime.Now.Subtract(startDate)).ToString();
                    gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.')); //17:44:08

                    string[] array = gecenSure.Split('.');

                    gecenSure = array[0].ConInt().ToString();

                    item = new ArizaKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["PROJE"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["BOLUK_KOMUTANI"].ToString(),
                        dataReader["TELEFON_NO"].ToString(),
                        dataReader["BIRLIK_ADRESI"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["BILDIRILEN_ARIZA"].ToString(),
                        dataReader["ARIZAYI_BILDIREN_PERSONEL"].ToString(),
                        dataReader["AB_RUTBESI"].ToString(),
                        dataReader["AB_GOREVI"].ToString(),
                        dataReader["AB_TELEFON"].ToString(),
                        dataReader["AB_TARIH_SAAT"].ConDate(),
                        dataReader["A_B_ALAN_PERSONEL"].ToString(),
                        dataReader["BILDIRIM_KANALI"].ToString(),
                        dataReader["ARIZA_ACIKLAMA"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["LOJISTIK_SORUMLU_PERSONEL"].ToString(),
                        dataReader["LOJ_RUTBESI"].ToString(),
                        dataReader["LOJ_GOREVI"].ToString(),
                        dataReader["LOJ_TARIH"].ToString(),
                        dataReader["TESPIT_EDILEN_ARIZA"].ToString(),
                        dataReader["ARIZA_ACMA_ONAYI_VEREN"].ToString(),
                        dataReader["CS_SIPARIS_NO"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString(),
                        dataReader["CRM_NO"].ToString(),
                        dataReader["ASELSAN_BILDIRIM_TARIHI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["KATEGORI"].ToString(),
                        dataReader["ILGILI_FIRMA"].ToString(),
                        dataReader["BILDIRIM_TURU"].ToString(),
                        dataReader["PYP_NO"].ToString(),
                        dataReader["SORUMLU_PERSONEL"].ToString(),
                        dataReader["SIPARIS_TURU"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["HESAPLAMA"].ToString(),
                        dataReader["DURUM"].ConInt(),
                        dataReader["ONARIM_NOTU"].ToString(),
                        dataReader["TESLIM_EDEN_PERSONEL"].ToString(),
                        dataReader["TESLIM_ALAN_PERSONEL"].ToString(),
                        dataReader["TESLIM_TARIHI"].ConDate(),
                        dataReader["NESNE_TANIMI"].ToString(),
                        dataReader["HASAR_KODU"].ToString(),
                        dataReader["NEDEN_KODU"].ToString(),
                        dataReader["EKSIK_EVRAK"].ConInt(),
                        dataReader["EKIPMAN_NO"].ToString(),
                        dataReader["MALZEME_DURUMU"].ToString(),
                        gecenSure,
                        dataReader["OKF_BILDIRIM_NO"].ToString(),
                        dataReader["PROJE_TANIM"].ToString(),
                        dataReader["MUSTERI"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ArizaKayit GetBildirimNo(string bildirimNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BakimOnarimArizaBildirimList", new SqlParameter("@bildirimNo", bildirimNo));
                ArizaKayit item = null;
                while (dataReader.Read())
                {
                    DateTime startDate = dataReader["AB_TARIH_SAAT"].ConDate();
                    string gecenSure = (DateTime.Now.Subtract(startDate)).ToString();
                    gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.')); //17:44:08

                    string[] array = gecenSure.Split('.');

                    gecenSure = array[0].ConInt().ToString();

                    item = new ArizaKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["PROJE"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["BOLUK_KOMUTANI"].ToString(),
                        dataReader["TELEFON_NO"].ToString(),
                        dataReader["BIRLIK_ADRESI"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["BILDIRILEN_ARIZA"].ToString(),
                        dataReader["ARIZAYI_BILDIREN_PERSONEL"].ToString(),
                        dataReader["AB_RUTBESI"].ToString(),
                        dataReader["AB_GOREVI"].ToString(),
                        dataReader["AB_TELEFON"].ToString(),
                        dataReader["AB_TARIH_SAAT"].ConDate(),
                        dataReader["A_B_ALAN_PERSONEL"].ToString(),
                        dataReader["BILDIRIM_KANALI"].ToString(),
                        dataReader["ARIZA_ACIKLAMA"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["LOJISTIK_SORUMLU_PERSONEL"].ToString(),
                        dataReader["LOJ_RUTBESI"].ToString(),
                        dataReader["LOJ_GOREVI"].ToString(),
                        dataReader["LOJ_TARIH"].ToString(),
                        dataReader["TESPIT_EDILEN_ARIZA"].ToString(),
                        dataReader["ARIZA_ACMA_ONAYI_VEREN"].ToString(),
                        dataReader["CS_SIPARIS_NO"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString(),
                        dataReader["CRM_NO"].ToString(),
                        dataReader["ASELSAN_BILDIRIM_TARIHI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["KATEGORI"].ToString(),
                        dataReader["ILGILI_FIRMA"].ToString(),
                        dataReader["BILDIRIM_TURU"].ToString(),
                        dataReader["PYP_NO"].ToString(),
                        dataReader["SORUMLU_PERSONEL"].ToString(),
                        dataReader["SIPARIS_TURU"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["HESAPLAMA"].ToString(),
                        dataReader["DURUM"].ConInt(),
                        dataReader["ONARIM_NOTU"].ToString(),
                        dataReader["TESLIM_EDEN_PERSONEL"].ToString(),
                        dataReader["TESLIM_ALAN_PERSONEL"].ToString(),
                        dataReader["TESLIM_TARIHI"].ConDate(),
                        dataReader["NESNE_TANIMI"].ToString(),
                        dataReader["HASAR_KODU"].ToString(),
                        dataReader["NEDEN_KODU"].ToString(),
                        dataReader["EKSIK_EVRAK"].ConInt(),
                        dataReader["EKIPMAN_NO"].ToString(),
                        dataReader["MALZEME_DURUMU"].ToString(),
                        gecenSure,
                        dataReader["OKF_BILDIRIM_NO"].ToString(),
                        dataReader["PROJE_TANIM"].ToString(),
                        dataReader["MUSTERI"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ArizaKayit GetId(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ArizaGet", new SqlParameter("@id", id));
                ArizaKayit item = null;
                while (dataReader.Read())
                {
                    DateTime startDate = dataReader["AB_TARIH_SAAT"].ConDate();
                    string gecenSure = (DateTime.Now.Subtract(startDate)).ToString();
                    gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.')); //17:44:08

                    string[] array = gecenSure.Split('.');

                    gecenSure = array[0].ConInt().ToString();

                    item = new ArizaKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["PROJE"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["BOLUK_KOMUTANI"].ToString(),
                        dataReader["TELEFON_NO"].ToString(),
                        dataReader["BIRLIK_ADRESI"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["BILDIRILEN_ARIZA"].ToString(),
                        dataReader["ARIZAYI_BILDIREN_PERSONEL"].ToString(),
                        dataReader["AB_RUTBESI"].ToString(),
                        dataReader["AB_GOREVI"].ToString(),
                        dataReader["AB_TELEFON"].ToString(),
                        dataReader["AB_TARIH_SAAT"].ConDate(),
                        dataReader["A_B_ALAN_PERSONEL"].ToString(),
                        dataReader["BILDIRIM_KANALI"].ToString(),
                        dataReader["ARIZA_ACIKLAMA"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["LOJISTIK_SORUMLU_PERSONEL"].ToString(),
                        dataReader["LOJ_RUTBESI"].ToString(),
                        dataReader["LOJ_GOREVI"].ToString(),
                        dataReader["LOJ_TARIH"].ToString(),
                        dataReader["TESPIT_EDILEN_ARIZA"].ToString(),
                        dataReader["ARIZA_ACMA_ONAYI_VEREN"].ToString(),
                        dataReader["CS_SIPARIS_NO"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString(),
                        dataReader["CRM_NO"].ToString(),
                        dataReader["ASELSAN_BILDIRIM_TARIHI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["KATEGORI"].ToString(),
                        dataReader["ILGILI_FIRMA"].ToString(),
                        dataReader["BILDIRIM_TURU"].ToString(),
                        dataReader["PYP_NO"].ToString(),
                        dataReader["SORUMLU_PERSONEL"].ToString(),
                        dataReader["SIPARIS_TURU"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["HESAPLAMA"].ToString(),
                        dataReader["DURUM"].ConInt(),
                        dataReader["ONARIM_NOTU"].ToString(),
                        dataReader["TESLIM_EDEN_PERSONEL"].ToString(),
                        dataReader["TESLIM_ALAN_PERSONEL"].ToString(),
                        dataReader["TESLIM_TARIHI"].ConDate(),
                        dataReader["NESNE_TANIMI"].ToString(),
                        dataReader["HASAR_KODU"].ToString(),
                        dataReader["NEDEN_KODU"].ToString(),
                        dataReader["EKSIK_EVRAK"].ConInt(),
                        dataReader["EKIPMAN_NO"].ToString(),
                        dataReader["MALZEME_DURUMU"].ToString(),
                        gecenSure,
                        dataReader["OKF_BILDIRIM_NO"].ToString(),
                        dataReader["PROJE_TANIM"].ToString(),
                        dataReader["MUSTERI"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<ArizaKayit> MalzemeHazirlamaList()
        {
            try
            {
                List<ArizaKayit> arizaKayits = new List<ArizaKayit>();
                dataReader = sqlServices.StoreReader("MalzemeHazirlamaList");
                while (dataReader.Read())
                {
                    DateTime startDate = dataReader["AB_TARIH_SAAT"].ConDate();
                    string gecenSure = (DateTime.Now.Subtract(startDate)).ToString();
                    gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.')); //17:44:08

                    string[] array = gecenSure.Split('.');

                    gecenSure = array[0].ConInt().ToString();

                    arizaKayits.Add(new ArizaKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["PROJE"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["BOLUK_KOMUTANI"].ToString(),
                        dataReader["TELEFON_NO"].ToString(),
                        dataReader["BIRLIK_ADRESI"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["BILDIRILEN_ARIZA"].ToString(),
                        dataReader["ARIZAYI_BILDIREN_PERSONEL"].ToString(),
                        dataReader["AB_RUTBESI"].ToString(),
                        dataReader["AB_GOREVI"].ToString(),
                        dataReader["AB_TELEFON"].ToString(),
                        dataReader["AB_TARIH_SAAT"].ConDate(),
                        dataReader["A_B_ALAN_PERSONEL"].ToString(),
                        dataReader["BILDIRIM_KANALI"].ToString(),
                        dataReader["ARIZA_ACIKLAMA"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["LOJISTIK_SORUMLU_PERSONEL"].ToString(),
                        dataReader["LOJ_RUTBESI"].ToString(),
                        dataReader["LOJ_GOREVI"].ToString(),
                        dataReader["LOJ_TARIH"].ToString(),
                        dataReader["TESPIT_EDILEN_ARIZA"].ToString(),
                        dataReader["ARIZA_ACMA_ONAYI_VEREN"].ToString(),
                        dataReader["CS_SIPARIS_NO"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString(),
                        dataReader["CRM_NO"].ToString(),
                        dataReader["ASELSAN_BILDIRIM_TARIHI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["KATEGORI"].ToString(),
                        dataReader["ILGILI_FIRMA"].ToString(),
                        dataReader["BILDIRIM_TURU"].ToString(),
                        dataReader["PYP_NO"].ToString(),
                        dataReader["SORUMLU_PERSONEL"].ToString(),
                        dataReader["SIPARIS_TURU"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["HESAPLAMA"].ToString(),
                        dataReader["DURUM"].ConInt(),
                        dataReader["ONARIM_NOTU"].ToString(),
                        dataReader["TESLIM_EDEN_PERSONEL"].ToString(),
                        dataReader["TESLIM_ALAN_PERSONEL"].ToString(),
                        dataReader["TESLIM_TARIHI"].ConDate(),
                        dataReader["NESNE_TANIMI"].ToString(),
                        dataReader["HASAR_KODU"].ToString(),
                        dataReader["NEDEN_KODU"].ToString(),
                        dataReader["EKSIK_EVRAK"].ConInt(),
                        dataReader["EKIPMAN_NO"].ToString(),
                        dataReader["MALZEME_DURUMU"].ToString(),
                        gecenSure,
                        dataReader["OKF_BILDIRIM_NO"].ToString(),
                        dataReader["PROJE_TANIM"].ToString(),
                        dataReader["MUSTERI"].ToString()));
                }
                dataReader.Close();
                return arizaKayits;
            }
            catch (Exception ex)
            {
                return new List<ArizaKayit>();
            }
        }

        public List<ArizaKayit> GetList(string bolgeAdi)
        {
            try
            {
                List<ArizaKayit> arizaKayits = new List<ArizaKayit>();
                dataReader = sqlServices.StoreReader("BakimOnarimArizaKayitList", new SqlParameter("@usBolgesiAdi", bolgeAdi));
                while (dataReader.Read())
                {
                    DateTime startDate = dataReader["AB_TARIH_SAAT"].ConDate();
                    string gecenSure = (DateTime.Now.Subtract(startDate)).ToString();
                    gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.')); //17:44:08

                    string[] array = gecenSure.Split('.');

                    gecenSure = array[0].ConInt().ToString();

                    arizaKayits.Add(new ArizaKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["PROJE"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["BOLUK_KOMUTANI"].ToString(),
                        dataReader["TELEFON_NO"].ToString(),
                        dataReader["BIRLIK_ADRESI"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["BILDIRILEN_ARIZA"].ToString(),
                        dataReader["ARIZAYI_BILDIREN_PERSONEL"].ToString(),
                        dataReader["AB_RUTBESI"].ToString(),
                        dataReader["AB_GOREVI"].ToString(),
                        dataReader["AB_TELEFON"].ToString(),
                        dataReader["AB_TARIH_SAAT"].ConDate(),
                        dataReader["A_B_ALAN_PERSONEL"].ToString(),
                        dataReader["BILDIRIM_KANALI"].ToString(),
                        dataReader["ARIZA_ACIKLAMA"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["LOJISTIK_SORUMLU_PERSONEL"].ToString(),
                        dataReader["LOJ_RUTBESI"].ToString(),
                        dataReader["LOJ_GOREVI"].ToString(),
                        dataReader["LOJ_TARIH"].ToString(),
                        dataReader["TESPIT_EDILEN_ARIZA"].ToString(),
                        dataReader["ARIZA_ACMA_ONAYI_VEREN"].ToString(),
                        dataReader["CS_SIPARIS_NO"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString(),
                        dataReader["CRM_NO"].ToString(),
                        dataReader["ASELSAN_BILDIRIM_TARIHI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["KATEGORI"].ToString(),
                        dataReader["ILGILI_FIRMA"].ToString(),
                        dataReader["BILDIRIM_TURU"].ToString(),
                        dataReader["PYP_NO"].ToString(),
                        dataReader["SORUMLU_PERSONEL"].ToString(),
                        dataReader["SIPARIS_TURU"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["HESAPLAMA"].ToString(),
                        dataReader["DURUM"].ConInt(),
                        dataReader["ONARIM_NOTU"].ToString(),
                        dataReader["TESLIM_EDEN_PERSONEL"].ToString(),
                        dataReader["TESLIM_ALAN_PERSONEL"].ToString(),
                        dataReader["TESLIM_TARIHI"].ConDate(),
                        dataReader["NESNE_TANIMI"].ToString(),
                        dataReader["HASAR_KODU"].ToString(),
                        dataReader["NEDEN_KODU"].ToString(),
                        dataReader["EKSIK_EVRAK"].ConInt(),
                        dataReader["EKIPMAN_NO"].ToString(),
                        dataReader["MALZEME_DURUMU"].ToString(),
                        gecenSure,
                        dataReader["OKF_BILDIRIM_NO"].ToString(),
                        dataReader["PROJE_TANIM"].ToString(),
                        dataReader["MUSTERI"].ToString()));
                }
                dataReader.Close();
                return arizaKayits;
            }
            catch (Exception)
            {
                return new List<ArizaKayit>();
            }
        }
        public string IsAkisNoDuzelt(int id, int isAkisNo, string dosyaYolu)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BakimOnarimDuzelt",
                    new SqlParameter("@id", id),
                    new SqlParameter("@isAkisNo", isAkisNo),
                    new SqlParameter("@dosyaYolu", dosyaYolu));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<ArizaKayit> ArizalarList(int isAkisNo)
        {
            try
            {
                List<ArizaKayit> arizaKayits = new List<ArizaKayit>();
                dataReader = sqlServices.StoreReader("BakimOnarimList", new SqlParameter("@isAkisNo", isAkisNo));
                while (dataReader.Read())
                {
                    DateTime startDate = dataReader["AB_TARIH_SAAT"].ConDate();
                    string gecenSure = (DateTime.Now.Subtract(startDate)).ToString();
                    gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.')); //17:44:08

                    string[] array = gecenSure.Split('.');

                    gecenSure = array[0].ConInt().ToString();

                    arizaKayits.Add(new ArizaKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["PROJE"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["BOLUK_KOMUTANI"].ToString(),
                        dataReader["TELEFON_NO"].ToString(),
                        dataReader["BIRLIK_ADRESI"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["BILDIRILEN_ARIZA"].ToString(),
                        dataReader["ARIZAYI_BILDIREN_PERSONEL"].ToString(),
                        dataReader["AB_RUTBESI"].ToString(),
                        dataReader["AB_GOREVI"].ToString(),
                        dataReader["AB_TELEFON"].ToString(),
                        dataReader["AB_TARIH_SAAT"].ConDate(),
                        dataReader["A_B_ALAN_PERSONEL"].ToString(),
                        dataReader["BILDIRIM_KANALI"].ToString(),
                        dataReader["ARIZA_ACIKLAMA"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["LOJISTIK_SORUMLU_PERSONEL"].ToString(),
                        dataReader["LOJ_RUTBESI"].ToString(),
                        dataReader["LOJ_GOREVI"].ToString(),
                        dataReader["LOJ_TARIH"].ToString(),
                        dataReader["TESPIT_EDILEN_ARIZA"].ToString(),
                        dataReader["ARIZA_ACMA_ONAYI_VEREN"].ToString(),
                        dataReader["CS_SIPARIS_NO"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString(),
                        dataReader["CRM_NO"].ToString(),
                        dataReader["ASELSAN_BILDIRIM_TARIHI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["KATEGORI"].ToString(),
                        dataReader["ILGILI_FIRMA"].ToString(),
                        dataReader["BILDIRIM_TURU"].ToString(),
                        dataReader["PYP_NO"].ToString(),
                        dataReader["SORUMLU_PERSONEL"].ToString(),
                        dataReader["SIPARIS_TURU"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["HESAPLAMA"].ToString(),
                        dataReader["DURUM"].ConInt(),
                        dataReader["ONARIM_NOTU"].ToString(),
                        dataReader["TESLIM_EDEN_PERSONEL"].ToString(),
                        dataReader["TESLIM_ALAN_PERSONEL"].ToString(),
                        dataReader["TESLIM_TARIHI"].ConDate(),
                        dataReader["NESNE_TANIMI"].ToString(),
                        dataReader["HASAR_KODU"].ToString(),
                        dataReader["NEDEN_KODU"].ToString(),
                        dataReader["EKSIK_EVRAK"].ConInt(),
                        dataReader["EKIPMAN_NO"].ToString(),
                        dataReader["MALZEME_DURUMU"].ToString(),
                        gecenSure,
                        dataReader["OKF_BILDIRIM_NO"].ToString(),
                        dataReader["PROJE_TANIM"].ToString(),
                        dataReader["MUSTERI"].ToString()));
                }
                dataReader.Close();
                return arizaKayits;
            }
            catch (Exception)
            {
                return new List<ArizaKayit>();
            }
        }
        public List<ArizaKayit> DevamEdenlerGetList(string bolgeSorumlusu, string islemAdimiSorumlusu)
        {
            try
            {

                List<ArizaKayit> arizaKayits = new List<ArizaKayit>();
                dataReader = sqlServices.StoreReader("BakimOnarimDevamEdenler", new SqlParameter("@personelAd", bolgeSorumlusu), new SqlParameter("@islemAdimiSorumlusu", islemAdimiSorumlusu));
                while (dataReader.Read())
                {
                    DateTime startDate = dataReader["AB_TARIH_SAAT"].ConDate();
                    string gecenSure = (DateTime.Now.Subtract(startDate)).ToString();
                    gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.')); //17:44:08

                    string[] array = gecenSure.Split('.');

                    gecenSure = array[0].ConInt().ToString();

                    arizaKayits.Add(new ArizaKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["PROJE"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["BOLUK_KOMUTANI"].ToString(),
                        dataReader["TELEFON_NO"].ToString(),
                        dataReader["BIRLIK_ADRESI"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["BILDIRILEN_ARIZA"].ToString(),
                        dataReader["ARIZAYI_BILDIREN_PERSONEL"].ToString(),
                        dataReader["AB_RUTBESI"].ToString(),
                        dataReader["AB_GOREVI"].ToString(),
                        dataReader["AB_TELEFON"].ToString(),
                        dataReader["AB_TARIH_SAAT"].ConDate(),
                        dataReader["A_B_ALAN_PERSONEL"].ToString(),
                        dataReader["BILDIRIM_KANALI"].ToString(),
                        dataReader["ARIZA_ACIKLAMA"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["LOJISTIK_SORUMLU_PERSONEL"].ToString(),
                        dataReader["LOJ_RUTBESI"].ToString(),
                        dataReader["LOJ_GOREVI"].ToString(),
                        dataReader["LOJ_TARIH"].ToString(),
                        dataReader["TESPIT_EDILEN_ARIZA"].ToString(),
                        dataReader["ARIZA_ACMA_ONAYI_VEREN"].ToString(),
                        dataReader["CS_SIPARIS_NO"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString(),
                        dataReader["CRM_NO"].ToString(),
                        dataReader["ASELSAN_BILDIRIM_TARIHI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["KATEGORI"].ToString(),
                        dataReader["ILGILI_FIRMA"].ToString(),
                        dataReader["BILDIRIM_TURU"].ToString(),
                        dataReader["PYP_NO"].ToString(),
                        dataReader["SORUMLU_PERSONEL"].ToString(),
                        dataReader["SIPARIS_TURU"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["HESAPLAMA"].ToString(),
                        dataReader["DURUM"].ConInt(),
                        dataReader["ONARIM_NOTU"].ToString(),
                        dataReader["TESLIM_EDEN_PERSONEL"].ToString(),
                        dataReader["TESLIM_ALAN_PERSONEL"].ToString(),
                        dataReader["TESLIM_TARIHI"].ConDate(),
                        dataReader["NESNE_TANIMI"].ToString(),
                        dataReader["HASAR_KODU"].ToString(),
                        dataReader["NEDEN_KODU"].ToString(),
                        dataReader["EKSIK_EVRAK"].ConInt(),
                        dataReader["EKIPMAN_NO"].ToString(),
                        dataReader["MALZEME_DURUMU"].ToString(),
                        gecenSure,
                        dataReader["OKF_BILDIRIM_NO"].ToString(),
                        dataReader["PROJE_TANIM"].ToString(),
                        dataReader["MUSTERI"].ToString()));
                }
                dataReader.Close();
                return arizaKayits;
            }
            catch (Exception ex)
            {
                return new List<ArizaKayit>();
            }
        }

        public List<ArizaKayit> GetListTumu()
        {
            try
            {

                List<ArizaKayit> arizaKayits = new List<ArizaKayit>();
                dataReader = sqlServices.StoreReader("ArizaTumu");
                while (dataReader.Read())
                {
                    DateTime startDate = dataReader["AB_TARIH_SAAT"].ConDate();
                    string gecenSure = (DateTime.Now.Subtract(startDate)).ToString();
                    gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.')); //17:44:08

                    string[] array = gecenSure.Split('.');

                    gecenSure = array[0].ConInt().ToString();

                    arizaKayits.Add(new ArizaKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["PROJE"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["BOLUK_KOMUTANI"].ToString(),
                        dataReader["TELEFON_NO"].ToString(),
                        dataReader["BIRLIK_ADRESI"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["BILDIRILEN_ARIZA"].ToString(),
                        dataReader["ARIZAYI_BILDIREN_PERSONEL"].ToString(),
                        dataReader["AB_RUTBESI"].ToString(),
                        dataReader["AB_GOREVI"].ToString(),
                        dataReader["AB_TELEFON"].ToString(),
                        dataReader["AB_TARIH_SAAT"].ConDate(),
                        dataReader["A_B_ALAN_PERSONEL"].ToString(),
                        dataReader["BILDIRIM_KANALI"].ToString(),
                        dataReader["ARIZA_ACIKLAMA"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["LOJISTIK_SORUMLU_PERSONEL"].ToString(),
                        dataReader["LOJ_RUTBESI"].ToString(),
                        dataReader["LOJ_GOREVI"].ToString(),
                        dataReader["LOJ_TARIH"].ToString(),
                        dataReader["TESPIT_EDILEN_ARIZA"].ToString(),
                        dataReader["ARIZA_ACMA_ONAYI_VEREN"].ToString(),
                        dataReader["CS_SIPARIS_NO"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString(),
                        dataReader["CRM_NO"].ToString(),
                        dataReader["ASELSAN_BILDIRIM_TARIHI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["KATEGORI"].ToString(),
                        dataReader["ILGILI_FIRMA"].ToString(),
                        dataReader["BILDIRIM_TURU"].ToString(),
                        dataReader["PYP_NO"].ToString(),
                        dataReader["SORUMLU_PERSONEL"].ToString(),
                        dataReader["SIPARIS_TURU"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["HESAPLAMA"].ToString(),
                        dataReader["DURUM"].ConInt(),
                        dataReader["ONARIM_NOTU"].ToString(),
                        dataReader["TESLIM_EDEN_PERSONEL"].ToString(),
                        dataReader["TESLIM_ALAN_PERSONEL"].ToString(),
                        dataReader["TESLIM_TARIHI"].ConDate(),
                        dataReader["NESNE_TANIMI"].ToString(),
                        dataReader["HASAR_KODU"].ToString(),
                        dataReader["NEDEN_KODU"].ToString(),
                        dataReader["EKSIK_EVRAK"].ConInt(),
                        dataReader["EKIPMAN_NO"].ToString(),
                        dataReader["MALZEME_DURUMU"].ToString(),
                        gecenSure,
                        dataReader["OKF_BILDIRIM_NO"].ToString(),
                        dataReader["PROJE_TANIM"].ToString(),
                        dataReader["MUSTERI"].ToString()));
                }
                dataReader.Close();
                return arizaKayits;
            }
            catch (Exception ex)
            {
                return new List<ArizaKayit>();
            }
        }

        public List<ArizaKayit> TamamlananGetList()
        {
            try
            {
                List<ArizaKayit> arizaKayits = new List<ArizaKayit>();
                dataReader = sqlServices.StoreReader("BOTamamlananlar");
                while (dataReader.Read())
                {
                    DateTime startDate = dataReader["AB_TARIH_SAAT"].ConDate();
                    string gecenSure = (DateTime.Now.Subtract(startDate)).ToString();
                    gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.')); //17:44:08

                    string[] array = gecenSure.Split('.');

                    gecenSure = array[0].ConInt().ToString();

                    arizaKayits.Add(new ArizaKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["PROJE"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["BOLUK_KOMUTANI"].ToString(),
                        dataReader["TELEFON_NO"].ToString(),
                        dataReader["BIRLIK_ADRESI"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["BILDIRILEN_ARIZA"].ToString(),
                        dataReader["ARIZAYI_BILDIREN_PERSONEL"].ToString(),
                        dataReader["AB_RUTBESI"].ToString(),
                        dataReader["AB_GOREVI"].ToString(),
                        dataReader["AB_TELEFON"].ToString(),
                        dataReader["AB_TARIH_SAAT"].ConDate(),
                        dataReader["A_B_ALAN_PERSONEL"].ToString(),
                        dataReader["BILDIRIM_KANALI"].ToString(),
                        dataReader["ARIZA_ACIKLAMA"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["LOJISTIK_SORUMLU_PERSONEL"].ToString(),
                        dataReader["LOJ_RUTBESI"].ToString(),
                        dataReader["LOJ_GOREVI"].ToString(),
                        dataReader["LOJ_TARIH"].ToString(),
                        dataReader["TESPIT_EDILEN_ARIZA"].ToString(),
                        dataReader["ARIZA_ACMA_ONAYI_VEREN"].ToString(),
                        dataReader["CS_SIPARIS_NO"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString(),
                        dataReader["CRM_NO"].ToString(),
                        dataReader["ASELSAN_BILDIRIM_TARIHI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["KATEGORI"].ToString(),
                        dataReader["ILGILI_FIRMA"].ToString(),
                        dataReader["BILDIRIM_TURU"].ToString(),
                        dataReader["PYP_NO"].ToString(),
                        dataReader["SORUMLU_PERSONEL"].ToString(),
                        dataReader["SIPARIS_TURU"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["HESAPLAMA"].ToString(),
                        dataReader["DURUM"].ConInt(),
                        dataReader["ONARIM_NOTU"].ToString(),
                        dataReader["TESLIM_EDEN_PERSONEL"].ToString(),
                        dataReader["TESLIM_ALAN_PERSONEL"].ToString(),
                        dataReader["TESLIM_TARIHI"].ConDate(),
                        dataReader["NESNE_TANIMI"].ToString(),
                        dataReader["HASAR_KODU"].ToString(),
                        dataReader["NEDEN_KODU"].ToString(),
                        dataReader["EKSIK_EVRAK"].ConInt(),
                        dataReader["EKIPMAN_NO"].ToString(),
                        dataReader["MALZEME_DURUMU"].ToString(),
                        gecenSure,
                        dataReader["OKF_BILDIRIM_NO"].ToString(),
                        dataReader["PROJE_TANIM"].ToString(),
                        dataReader["MUSTERI"].ToString()));
                }
                dataReader.Close();
                return arizaKayits;
            }
            catch (Exception)
            {
                return new List<ArizaKayit>();
            }
        }
        public List<ArizaKayit> BildirimOnayiList()
        {
            try
            {
                List<ArizaKayit> arizaKayits = new List<ArizaKayit>();
                dataReader = sqlServices.StoreReader("BakimOnarimBildirimOnayiList");
                while (dataReader.Read())
                {
                    DateTime startDate = dataReader["AB_TARIH_SAAT"].ConDate();
                    string gecenSure = (DateTime.Now.Subtract(startDate)).ToString();
                    gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.')); //17:44:08

                    string[] array = gecenSure.Split('.');

                    gecenSure = array[0].ConInt().ToString();

                    arizaKayits.Add(new ArizaKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["PROJE"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["BOLUK_KOMUTANI"].ToString(),
                        dataReader["TELEFON_NO"].ToString(),
                        dataReader["BIRLIK_ADRESI"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["BILDIRILEN_ARIZA"].ToString(),
                        dataReader["ARIZAYI_BILDIREN_PERSONEL"].ToString(),
                        dataReader["AB_RUTBESI"].ToString(),
                        dataReader["AB_GOREVI"].ToString(),
                        dataReader["AB_TELEFON"].ToString(),
                        dataReader["AB_TARIH_SAAT"].ConDate(),
                        dataReader["A_B_ALAN_PERSONEL"].ToString(),
                        dataReader["BILDIRIM_KANALI"].ToString(),
                        dataReader["ARIZA_ACIKLAMA"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["LOJISTIK_SORUMLU_PERSONEL"].ToString(),
                        dataReader["LOJ_RUTBESI"].ToString(),
                        dataReader["LOJ_GOREVI"].ToString(),
                        dataReader["LOJ_TARIH"].ToString(),
                        dataReader["TESPIT_EDILEN_ARIZA"].ToString(),
                        dataReader["ARIZA_ACMA_ONAYI_VEREN"].ToString(),
                        dataReader["CS_SIPARIS_NO"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString(),
                        dataReader["CRM_NO"].ToString(),
                        dataReader["ASELSAN_BILDIRIM_TARIHI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["KATEGORI"].ToString(),
                        dataReader["ILGILI_FIRMA"].ToString(),
                        dataReader["BILDIRIM_TURU"].ToString(),
                        dataReader["PYP_NO"].ToString(),
                        dataReader["SORUMLU_PERSONEL"].ToString(),
                        dataReader["SIPARIS_TURU"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["HESAPLAMA"].ToString(),
                        dataReader["DURUM"].ConInt(),
                        dataReader["ONARIM_NOTU"].ToString(),
                        dataReader["TESLIM_EDEN_PERSONEL"].ToString(),
                        dataReader["TESLIM_ALAN_PERSONEL"].ToString(),
                        dataReader["TESLIM_TARIHI"].ConDate(),
                        dataReader["NESNE_TANIMI"].ToString(),
                        dataReader["HASAR_KODU"].ToString(),
                        dataReader["NEDEN_KODU"].ToString(),
                        dataReader["EKSIK_EVRAK"].ConInt(),
                        dataReader["EKIPMAN_NO"].ToString(),
                        dataReader["MALZEME_DURUMU"].ToString(),
                        gecenSure,
                        dataReader["OKF_BILDIRIM_NO"].ToString(),
                        dataReader["PROJE_TANIM"].ToString(),
                        dataReader["MUSTERI"].ToString()));
                }
                dataReader.Close();
                return arizaKayits;
            }
            catch (Exception)
            {
                return new List<ArizaKayit>();
            }
        }
        public List<ArizaKayit> BOEksikEvrakList()
        {
            try
            {
                List<ArizaKayit> arizaKayits = new List<ArizaKayit>();
                dataReader = sqlServices.StoreReader("BOEksikEvrakList");
                while (dataReader.Read())
                {
                    DateTime startDate = dataReader["AB_TARIH_SAAT"].ConDate();
                    string gecenSure = (DateTime.Now.Subtract(startDate)).ToString();
                    gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.')); //17:44:08

                    string[] array = gecenSure.Split('.');

                    gecenSure = array[0].ConInt().ToString();

                    arizaKayits.Add(new ArizaKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["PROJE"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["BOLUK_KOMUTANI"].ToString(),
                        dataReader["TELEFON_NO"].ToString(),
                        dataReader["BIRLIK_ADRESI"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["BILDIRILEN_ARIZA"].ToString(),
                        dataReader["ARIZAYI_BILDIREN_PERSONEL"].ToString(),
                        dataReader["AB_RUTBESI"].ToString(),
                        dataReader["AB_GOREVI"].ToString(),
                        dataReader["AB_TELEFON"].ToString(),
                        dataReader["AB_TARIH_SAAT"].ConDate(),
                        dataReader["A_B_ALAN_PERSONEL"].ToString(),
                        dataReader["BILDIRIM_KANALI"].ToString(),
                        dataReader["ARIZA_ACIKLAMA"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["LOJISTIK_SORUMLU_PERSONEL"].ToString(),
                        dataReader["LOJ_RUTBESI"].ToString(),
                        dataReader["LOJ_GOREVI"].ToString(),
                        dataReader["LOJ_TARIH"].ToString(),
                        dataReader["TESPIT_EDILEN_ARIZA"].ToString(),
                        dataReader["ARIZA_ACMA_ONAYI_VEREN"].ToString(),
                        dataReader["CS_SIPARIS_NO"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString(),
                        dataReader["CRM_NO"].ToString(),
                        dataReader["ASELSAN_BILDIRIM_TARIHI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["KATEGORI"].ToString(),
                        dataReader["ILGILI_FIRMA"].ToString(),
                        dataReader["BILDIRIM_TURU"].ToString(),
                        dataReader["PYP_NO"].ToString(),
                        dataReader["SORUMLU_PERSONEL"].ToString(),
                        dataReader["SIPARIS_TURU"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["HESAPLAMA"].ToString(),
                        dataReader["DURUM"].ConInt(),
                        dataReader["ONARIM_NOTU"].ToString(),
                        dataReader["TESLIM_EDEN_PERSONEL"].ToString(),
                        dataReader["TESLIM_ALAN_PERSONEL"].ToString(),
                        dataReader["TESLIM_TARIHI"].ConDate(),
                        dataReader["NESNE_TANIMI"].ToString(),
                        dataReader["HASAR_KODU"].ToString(),
                        dataReader["NEDEN_KODU"].ToString(),
                        dataReader["EKSIK_EVRAK"].ConInt(),
                        dataReader["EKIPMAN_NO"].ToString(),
                        dataReader["MALZEME_DURUMU"].ToString(),
                        gecenSure,
                        dataReader["OKF_BILDIRIM_NO"].ToString(),
                        dataReader["PROJE_TANIM"].ToString(),
                        dataReader["MUSTERI"].ToString()));
                }
                dataReader.Close();
                return arizaKayits;
            }
            catch (Exception)
            {
                return new List<ArizaKayit>();
            }
        }

        public string Update(ArizaKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BakimOnarimArizaKayitGuncelle",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@isAkisNo", entity.IsAkisNo),
                    new SqlParameter("@abfFormNo", entity.AbfFormNo),
                    new SqlParameter("@proje", entity.Proje),
                    new SqlParameter("@bolgeAdi", entity.BolgeAdi),
                    new SqlParameter("@bolukKomutani", entity.BolukKomutani),
                    new SqlParameter("@telefonNo", entity.TelefonNo),
                    new SqlParameter("@birlikAdresi", entity.BirlikAdresi),
                    new SqlParameter("@il", entity.Il),
                    new SqlParameter("@ilce", entity.Ilce),
                    new SqlParameter("@bildirilenAriza", entity.BildirilenAriza),
                    new SqlParameter("@arizayiBildirenPersonel", entity.ArizaiBildirenPersonel),
                    new SqlParameter("@abRutbesi", entity.AbRutbesi),
                    new SqlParameter("@abGorevi", entity.AbGorevi),
                    new SqlParameter("@abTelefon", entity.AbTelefon),
                    new SqlParameter("@abTarihSaat", entity.AbTarihSaat),
                    new SqlParameter("@ABAlanPersonel", entity.ABAlanPersonel),
                    new SqlParameter("@bildirimKanali", entity.BildirimKanali),
                    new SqlParameter("@arizaAciklama", entity.ArizaAciklama),
                    new SqlParameter("@gorevAtanacakPersonel", entity.GorevAtanacakPersonel),
                    new SqlParameter("@islemAdimi", entity.IslemAdimi),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@garantiDurumu", entity.GarantiDurumu),
                    new SqlParameter("@lojSorumlusu", entity.LojistikSorumluPersonel),
                    new SqlParameter("@lojRutbesi", entity.LojRutbesi),
                    new SqlParameter("@lojGorevi", entity.LojGorevi),
                    new SqlParameter("@lojTarihi", entity.LojTarihi),
                    new SqlParameter("@tespitEdilenAriza", entity.TespitEdilenAriza),
                    new SqlParameter("@acmaOnayiVeren", entity.AcmaOnayiVeren),
                    new SqlParameter("@csSiparisNo", entity.CsSiparisNo),
                    new SqlParameter("@bildirimNo", entity.BildirimNo),
                    new SqlParameter("@crmNo", entity.CrmNo),
                    new SqlParameter("@bildirimTarih", entity.BildirimMailTarihi),
                    new SqlParameter("@siparisNo", entity.SiparisNo),
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@seriNo", entity.SeriNo),
                    new SqlParameter("@kategori", entity.Kategori),
                    new SqlParameter("@ilgiliFirma", entity.IlgiliFirma),
                    new SqlParameter("@bildirimTuru", entity.BildirimTuru),
                    new SqlParameter("@pypNo", entity.PypNo),
                    new SqlParameter("@sorumluPersonel", entity.SorumluPersonel),
                    new SqlParameter("@siparisTuru", entity.SiparisTuru),
                    new SqlParameter("@islemTuru", entity.IslemTuru),
                    new SqlParameter("@hesaplama", entity.Hesaplama),
                    new SqlParameter("@durum", entity.Durum),
                    new SqlParameter("@onarimNotu", entity.OnarimNotu),
                    new SqlParameter("@teslimEdenPersonel", entity.TeslimEdenPersonel),
                    new SqlParameter("@teslimTarihi", entity.TeslimTarihi),
                    new SqlParameter("@nesneTanim", entity.NesneTanimi),
                    new SqlParameter("@hasarKodu", entity.HasarKodu),
                    new SqlParameter("@nedenKodu", entity.NedenKodu),
                    new SqlParameter("@eksikEvrak", entity.EksikEvrak),
                    new SqlParameter("@ekipmanNo", entity.EkipmanNo),
                    new SqlParameter("@malzemeDurum", entity.MalzemeDurum),
                    new SqlParameter("@okfBildirimNo", entity.OkfBildirimNo),
                    new SqlParameter("@projeTanim", entity.ProjeTanimi),
                    new SqlParameter("@musteri", entity.Musteri));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string KapatKayit(ArizaKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BakimOnarimKapatmaKayit",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@onarimNotu", entity.OnarimNotu),
                    new SqlParameter("@teslimEdenPersonel", entity.TeslimEdenPersonel),
                    new SqlParameter("@teslimAlanPersonel", entity.TeslimAlanPersonel),
                    new SqlParameter("@teslimTarihi", entity.TeslimTarihi),
                    new SqlParameter("@nesneTanimi", entity.NesneTanimi),
                    new SqlParameter("@hasarKodu", entity.HasarKodu),
                    new SqlParameter("@nedenKodu", entity.NedenKodu),
                    new SqlParameter("@eksikEvrak", entity.EksikEvrak),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@seriNo", entity.SeriNo),
                    new SqlParameter("@kategori", entity.Kategori),
                    new SqlParameter("@ilgiliFirma", entity.IlgiliFirma),
                    new SqlParameter("@bildirimTuru", entity.BildirimTuru),
                    new SqlParameter("@pypNo", entity.PypNo),
                    new SqlParameter("@sorumluPersonel", entity.SorumluPersonel),
                    new SqlParameter("@siparisTuru", entity.SiparisTuru),
                    new SqlParameter("@islemTuru", entity.IslemTuru),
                    new SqlParameter("@hesaplama", entity.Hesaplama),
                    new SqlParameter("@bildirimNo", entity.BildirimNo),
                    new SqlParameter("@aselsanMailTarihi", entity.BildirimMailTarihi));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ArizaDurumUpdate(int id,int durum)
        {
            try
            {
                sqlServices.Stored("ArizaDurumUpdate", new SqlParameter("@id", id), new SqlParameter("@durum", durum));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string ArizaIslemAdimiUpdate(int id, string islemAdimi)
        {
            try
            {
                sqlServices.Stored("IslemAdimiUpdate", new SqlParameter("@id", id), new SqlParameter("@islemAdimi", islemAdimi));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static ArizaKayitDal GetInstance()
        {
            if (arizaKayitDal == null)
            {
                arizaKayitDal = new ArizaKayitDal();
            }
            return arizaKayitDal;
        }
    }
}