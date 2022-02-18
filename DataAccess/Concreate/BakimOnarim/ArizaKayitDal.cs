using DataAccess.Abstract;
using DataAccess.Database;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    new SqlParameter("@isAkisNo",entity.IsAkisNo),
                    new SqlParameter("@abfFormNo",entity.AbfFormNo),
                    new SqlParameter("@proje",entity.Proje),
                    new SqlParameter("@bolgeAdi",entity.BolgeAdi),
                    new SqlParameter("@bolukKomutani",entity.BolukKomutani),
                    new SqlParameter("@telefonNo",entity.TelefonNo),
                    new SqlParameter("@birlikAdresi",entity.BirlikAdresi),
                    new SqlParameter("@il",entity.Il),
                    new SqlParameter("@ilce",entity.Ilce),
                    new SqlParameter("@bildirilenAriza",entity.BildirilenAriza),
                    new SqlParameter("@arizayiBildirenPersonel",entity.ArizaiBildirenPersonel),
                    new SqlParameter("@abRutbesi",entity.AbRutbesi),
                    new SqlParameter("@abGorevi",entity.AbGorevi),
                    new SqlParameter("@abTelefon",entity.AbTelefon),
                    new SqlParameter("@abTarihSaat",entity.AbTarihSaat),
                    new SqlParameter("@ABAlanPersonel",entity.ABAlanPersonel),
                    new SqlParameter("@bildirimKanali",entity.BildirimKanali),
                    new SqlParameter("@arizaAciklama",entity.ArizaAciklama),
                    new SqlParameter("@gorevAtanacakPersonel",entity.GorevAtanacakPersonel),
                    new SqlParameter("@islemAdimi",entity.IslemAdimi),
                    new SqlParameter("@dosyaYolu",entity.DosyaYolu),
                    new SqlParameter("@siparisNo",entity.SiparisNo));

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
                sqlServices.Stored("BakimOnarimArizaKayitDelete",new SqlParameter("@id",id));
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
                dataReader = sqlServices.StoreReader("BakimOnarimArizaKayitList",new SqlParameter("@abfFormNo", abfFormNo));
                ArizaKayit item = null;
                while (dataReader.Read())
                {
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
                        dataReader["SIPARIS_NO"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ArizaKayit> GetList()
        {
            try
            {
                List<ArizaKayit> arizaKayits = new List<ArizaKayit>();
                dataReader = sqlServices.StoreReader("BakimOnarimArizaKayitList");
                while (dataReader.Read())
                {
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
                        dataReader["SIPARIS_NO"].ToString()));
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
                    new SqlParameter("@siparisNo", entity.SiparisNo));

                dataReader.Close();
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
