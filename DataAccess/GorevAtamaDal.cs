using DataAccess.Abstract;
using DataAccess.Concreate;
using DataAccess.Database;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GorevAtamaDal //: IRepository<GorevAtama>
    {
        static GorevAtamaDal gorevAtamaDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private GorevAtamaDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(GorevAtama entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YoneticiGorevKayit",
                    new SqlParameter("@gorevAtananPersonel", entity.GorevAtananPersonel),
                    new SqlParameter("@bitisTarihi", entity.BitisTarihi),
                    new SqlParameter("@gorevinKonusu", entity.GorevinKonusu),
                    new SqlParameter("@gorevAtamaTarihi", entity.GorevAtamaTarihi),
                    new SqlParameter("@goreviAtayanPersonel", entity.GoreviAtayanPersonel),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@isAkisNo", entity.IsAkisNo));

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

        public GorevAtama Get(int id)
        {
            try
            {

                dataReader = sqlServices.StoreReader("YoneticiGorevList", new SqlParameter("@id", id));
                GorevAtama item = null;
                while (dataReader.Read())
                {

                    item = new GorevAtama(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["GOREV_ATANAN_PERSONEL"].ToString(),
                        dataReader["BITIS_TARIHI"].ConDate(),
                        dataReader["ATANAN_GOREVIN_KONUSU"].ToString(),
                        dataReader["GOREV_ATAMA_TARIHI"].ConDate(),
                        dataReader["GOREVI_ATAYAN_PERSONEL"].ToString(),
                        dataReader["GOREVIN_TAMAMLANDIGI_TARIH"].ConDate(),
                        dataReader["YAPILAN_ISLEM"].ToString(),
                        dataReader["TOPLAM_SURE_SAAT"].ToString(),
                        "",
                        dataReader["DOSYA_YOLU"].ToString());

                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GorevAtama> GetList(string durum, string goreviAtayanPersonel)
        {
            try
            {
                List<GorevAtama> gorevAtamas = new List<GorevAtama>();
                dataReader = sqlServices.StoreReader("YoneticiGorevList", new SqlParameter("@durum", durum), 
                    new SqlParameter("@gorevAtayanPersonel", goreviAtayanPersonel));
                while (dataReader.Read())
                {
                    DateTime startDate = dataReader["GOREV_ATAMA_TARIHI"].ConDate();
                    string gecenSure = (DateTime.Now.Subtract(startDate)).ToString();
                    gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.'));


                    gorevAtamas.Add(new GorevAtama(
                       dataReader["ID"].ConInt(),
                       dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["GOREV_ATANAN_PERSONEL"].ToString(),
                        dataReader["BITIS_TARIHI"].ConDate(),
                        dataReader["ATANAN_GOREVIN_KONUSU"].ToString(),
                        startDate,
                        dataReader["GOREVI_ATAYAN_PERSONEL"].ToString(),
                        dataReader["GOREVIN_TAMAMLANDIGI_TARIH"].ConDate(),
                        dataReader["YAPILAN_ISLEM"].ToString(),
                        dataReader["TOPLAM_SURE_SAAT"].ToString(),
                        gecenSure,
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return gorevAtamas;
            }
            catch (Exception)
            {
                return new List<GorevAtama>();
            }
        }
        public List<GorevAtama> GetListTamamlananlar(string adSoyad)
        {
            try
            {
                List<GorevAtama> gorevAtamas = new List<GorevAtama>();
                dataReader = sqlServices.StoreReader("YoneticiGorevList", new SqlParameter("@durum", "TAMAMLANANLAR"),
                    new SqlParameter("@gorevAtayanPersonel",adSoyad));
                while (dataReader.Read())
                {
                    DateTime startDate = dataReader["GOREV_ATAMA_TARIHI"].ConDate();
                    string gecenSure = (DateTime.Now.Subtract(startDate)).ToString();
                    gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.'));


                    gorevAtamas.Add(new GorevAtama(
                       dataReader["ID"].ConInt(),
                       dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["GOREV_ATANAN_PERSONEL"].ToString(),
                        dataReader["BITIS_TARIHI"].ConDate(),
                        dataReader["ATANAN_GOREVIN_KONUSU"].ToString(),
                        dataReader["GOREV_ATAMA_TARIHI"].ConDate(),
                        dataReader["GOREVI_ATAYAN_PERSONEL"].ToString(),
                        dataReader["GOREVIN_TAMAMLANDIGI_TARIH"].ConDate(),
                        dataReader["YAPILAN_ISLEM"].ToString(),
                        dataReader["TOPLAM_SURE_SAAT"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return gorevAtamas;
            }
            catch (Exception)
            {
                return new List<GorevAtama>();
            }
        }
        public string IsAkisNoDuzelt(int id, int isAkisNo, string dosyaYolu)
        {
            try
            {
                dataReader = sqlServices.StoreReader("GorevAtamaDuzelt",
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

        public List<GorevAtama> GorevlerList(int isAkisNo)
        {
            try
            {
                List<GorevAtama> gorevAtamas = new List<GorevAtama>();
                dataReader = sqlServices.StoreReader("YoneticiGorevleriList",
                    new SqlParameter("@isAkisNo", isAkisNo));
                while (dataReader.Read())
                {
                    gorevAtamas.Add(new GorevAtama(
                       dataReader["ID"].ConInt(),
                       dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["GOREV_ATANAN_PERSONEL"].ToString(),
                        dataReader["BITIS_TARIHI"].ConDate(),
                        dataReader["ATANAN_GOREVIN_KONUSU"].ToString(),
                        dataReader["GOREV_ATAMA_TARIHI"].ConDate(),
                        dataReader["GOREVI_ATAYAN_PERSONEL"].ToString(),
                        dataReader["GOREVIN_TAMAMLANDIGI_TARIH"].ConDate(),
                        dataReader["YAPILAN_ISLEM"].ToString(),
                        dataReader["TOPLAM_SURE_SAAT"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return gorevAtamas;
            }
            catch (Exception)
            {
                return new List<GorevAtama>();
            }
        }
        public List<GorevAtama> GetListGorevlerim(string adSoyad)
        {
            try
            {
                SqlDataReader dataReader;
                List<GorevAtama> gorevAtamas = new List<GorevAtama>();
                dataReader = sqlServices.StoreReader("YoneticiGorevlerimiGor", new SqlParameter("@adSoyad", adSoyad));
                while (dataReader.Read())
                {
                    DateTime startDate = dataReader["GOREV_ATAMA_TARIHI"].ConDate();
                    string gecenSure = (DateTime.Now.Subtract(startDate)).ToString();
                    gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.'));


                    gorevAtamas.Add(new GorevAtama(
                       dataReader["ID"].ConInt(),
                       dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["GOREV_ATANAN_PERSONEL"].ToString(),
                        dataReader["BITIS_TARIHI"].ConDate(),
                        dataReader["ATANAN_GOREVIN_KONUSU"].ToString(),
                        startDate,
                        dataReader["GOREVI_ATAYAN_PERSONEL"].ToString(),
                        dataReader["GOREVIN_TAMAMLANDIGI_TARIH"].ConDate(),
                        dataReader["YAPILAN_ISLEM"].ToString(),
                        dataReader["TOPLAM_SURE_SAAT"].ToString(),
                        gecenSure,
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return gorevAtamas;
            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<GorevAtama>();
            }
        }

        public string Update(GorevAtama entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YoneticiGorevKapat",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@tamamlanmaTarihi", entity.GorevinTamamlandigiTarih),
                    new SqlParameter("@yapilanIslem", entity.YapilanIslem),
                    new SqlParameter("@toplamSure", entity.ToplamSure),
                    new SqlParameter("@dosyaYolu",entity.DosyaYolu));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static GorevAtamaDal GetInstance()
        {
            if (gorevAtamaDal == null)
            {
                gorevAtamaDal = new GorevAtamaDal();
            }
            return gorevAtamaDal;
        }
    }
}
