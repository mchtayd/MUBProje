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
    public class YurtIciGorevDal //: IRepository<YurtIciGorev>
    {
        static YurtIciGorevDal yurtIciGorevDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private YurtIciGorevDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(YurtIciGorev entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YurtIciGorevEkle",
                    new SqlParameter("@isakisno", entity.Isakisno),
                    new SqlParameter("@gorevemrino", entity.Gorevemrino),
                    new SqlParameter("@gorevkonusu", entity.Gorevinkonusu),
                    new SqlParameter("@proje", entity.Proje),
                    new SqlParameter("@gidilecekyer", entity.Gidilecekyer),
                    new SqlParameter("@baslamatarihi", entity.Baslamatarihi),
                    new SqlParameter("@bitistarihi", entity.Bitistarihi),
                    new SqlParameter("@toplamsure", entity.Toplamsure),
                    new SqlParameter("@butcekodu", entity.Butcekodu),
                    new SqlParameter("@siparisno", entity.Siparisno),
                    new SqlParameter("@adsoyad", entity.Adsoyad),
                    new SqlParameter("@unvani", entity.Unvani),
                    new SqlParameter("@masrafyerino", entity.Masrafyerino),
                    new SqlParameter("@masrafyeri", entity.Masrafyeri),
                    new SqlParameter("@ulasimgidis", entity.Ulasimgidis),
                    new SqlParameter("@ulasimgorevyeri", entity.Ulasimgorevyeri),
                    new SqlParameter("@ulasimdonus", entity.Ulasimdonus),
                    new SqlParameter("@konaklamagun", entity.Konaklamagun),
                    new SqlParameter("@konaklamaguntl", entity.Konaklamaguntl),
                    new SqlParameter("@konaklamatoplam", entity.Konaklamatoplam),
                    new SqlParameter("@kiralamagun", entity.Kiralamagun),
                    new SqlParameter("@kiralamaguntl", entity.Kiralamaguntl),
                    new SqlParameter("@kiralamatoplam", entity.Kiralamatoplam),
                    new SqlParameter("@seyahatavansgun", entity.Seyahatavansgun),
                    new SqlParameter("@seyahatguntl", entity.Seyahatguntl),
                    new SqlParameter("@seyahattoplam", entity.Seyahattoplam),
                    new SqlParameter("@ucakbileti", entity.Ucakbileti),
                    new SqlParameter("@otobusbileti", entity.Otobusbileti),
                    new SqlParameter("@plaka", entity.Plaka),
                    new SqlParameter("@cikiskm", entity.Cikiskm),
                    new SqlParameter("@geneltoplam", entity.Geneltoplam),
                    new SqlParameter("@islemadimi", entity.Islemadimi),
                    new SqlParameter("@dosyayolu", entity.Dosyayolu),
                    new SqlParameter("@konaklamaTuru",entity.KonaklamaTuru),
                    new SqlParameter("@harcirahGun",entity.HarcirahGun),
                    new SqlParameter("@harcirahGunTl",entity.HarcirahGunTl),
                    new SqlParameter("@harcirahGunToplam",entity.HarcirahToplam),
                    new SqlParameter("@iaseGun",entity.IaseGun),
                    new SqlParameter("@iaseGunTl",entity.IaseGunTl),
                    new SqlParameter("@iaseToplam",entity.IaseToplam));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int isakisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YurtIciGorevSil", new SqlParameter("@isakisno", isakisno));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        

        public YurtIciGorev Get(int isakisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YurtIciGorevList", new SqlParameter("@isakisno", isakisno));
                YurtIciGorev item = null;
                while (dataReader.Read())
                {
                    item = new YurtIciGorev(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["GOREV_EMRI_NO"].ToString(),
                        dataReader["GOREVIN_KONUSU"].ToString(),
                        dataReader["PROJE"].ToString(),
                        dataReader["GIDILECEK_YER"].ToString(),
                        dataReader["BASLAMA_TARIHI"].ConDate(),
                        dataReader["BITIS_TARIHI"].ConDate(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["BUTCE_KODU_TANIMI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["ULASIM_GIDIS"].ToString(),
                        dataReader["ULASIM_GOREV_YERI"].ToString(),
                        dataReader["ULASIM_DONUS"].ToString(),
                        dataReader["KONAKLAMA_GUN"].ConInt(),
                        dataReader["KONAKLAMA_GUN_TL"].ConDouble(),
                        dataReader["KONAKLAMA_TOPLAM"].ConDouble(),
                        dataReader["KIRALAMA_GUN"].ConInt(),
                        dataReader["KIRALAMA_GUN_TL"].ConDouble(),
                        dataReader["KIRALAMA_YAKIT"].ConDouble(),
                        dataReader["KIRALAMA_TOPLAM"].ConDouble(),
                        dataReader["SEYAHAT_AVANS_GUN"].ConInt(),
                        dataReader["SEYAHAT_GUN_TL"].ConDouble(),
                        dataReader["SEYAHAT_TOPLAM"].ConDouble(),
                        dataReader["HARCIRAH_GUN"].ConInt(),
                        dataReader["HARCIRAH_GUN_TL"].ConDouble(),
                        dataReader["HARCIRAH_TOPLAM"].ConDouble(),
                        dataReader["IASE_GUN"].ConInt(),
                        dataReader["IASE_GUN_TL"].ConDouble(),
                        dataReader["IASE_TOPLAM"].ConDouble(),
                        dataReader["UCAK_BILETI"].ConDouble(),
                        dataReader["OTOBUS_BILETI"].ConDouble(),
                        dataReader["ARAC_PLAKASI"].ToString(),
                        dataReader["CIKIS_KM"].ConInt(),
                        dataReader["DONUS_KM"].ConInt(),
                        dataReader["TOPLAM_KM"].ConInt(),
                        dataReader["GENEL_TOPLAM"].ConDouble(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["KONAKLAMA_TURU"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public YurtIciGorev AracTalepGet(string isAkisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YurtIciGorevAracTalepList", new SqlParameter("@isAkisNo", isAkisNo));
                YurtIciGorev item = null;
                while (dataReader.Read())
                {
                    item = new YurtIciGorev(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["GOREV_EMRI_NO"].ToString(),
                        dataReader["GOREVIN_KONUSU"].ToString(),
                        dataReader["PROJE"].ToString(),
                        dataReader["GIDILECEK_YER"].ToString(),
                        dataReader["BASLAMA_TARIHI"].ConDate(),
                        dataReader["BITIS_TARIHI"].ConDate(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["BUTCE_KODU_TANIMI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["ULASIM_GIDIS"].ToString(),
                        dataReader["ULASIM_GOREV_YERI"].ToString(),
                        dataReader["ULASIM_DONUS"].ToString(),
                        dataReader["KONAKLAMA_GUN"].ConInt(),
                        dataReader["KONAKLAMA_GUN_TL"].ConDouble(),
                        dataReader["KONAKLAMA_TOPLAM"].ConDouble(),
                        dataReader["KIRALAMA_GUN"].ConInt(),
                        dataReader["KIRALAMA_GUN_TL"].ConDouble(),
                        dataReader["KIRALAMA_YAKIT"].ConDouble(),
                        dataReader["KIRALAMA_TOPLAM"].ConDouble(),
                        dataReader["SEYAHAT_AVANS_GUN"].ConInt(),
                        dataReader["SEYAHAT_GUN_TL"].ConDouble(),
                        dataReader["SEYAHAT_TOPLAM"].ConDouble(),
                        dataReader["HARCIRAH_GUN"].ConInt(),
                        dataReader["HARCIRAH_GUN_TL"].ConDouble(),
                        dataReader["HARCIRAH_TOPLAM"].ConDouble(),
                        dataReader["IASE_GUN"].ConInt(),
                        dataReader["IASE_GUN_TL"].ConDouble(),
                        dataReader["IASE_TOPLAM"].ConDouble(),
                        dataReader["UCAK_BILETI"].ConDouble(),
                        dataReader["OTOBUS_BILETI"].ConDouble(),
                        dataReader["ARAC_PLAKASI"].ToString(),
                        dataReader["CIKIS_KM"].ConInt(),
                        dataReader["DONUS_KM"].ConInt(),
                        dataReader["TOPLAM_KM"].ConInt(),
                        dataReader["GENEL_TOPLAM"].ConDouble(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["KONAKLAMA_TURU"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<YurtIciGorev> GetList(string durum)
        {
            try
            {
                List<YurtIciGorev> yurtIcis = new List<YurtIciGorev>();
                dataReader = sqlServices.StoreReader("YurtIciGorevList", new SqlParameter("@durum", durum));
                while (dataReader.Read())
                {
                    yurtIcis.Add(new YurtIciGorev(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["GOREV_EMRI_NO"].ToString(),
                        dataReader["GOREVIN_KONUSU"].ToString(),
                        dataReader["PROJE"].ToString(),
                        dataReader["GIDILECEK_YER"].ToString(),
                        dataReader["BASLAMA_TARIHI"].ConDate(),
                        dataReader["BITIS_TARIHI"].ConDate(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["BUTCE_KODU_TANIMI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["ULASIM_GIDIS"].ToString(),
                        dataReader["ULASIM_GOREV_YERI"].ToString(),
                        dataReader["ULASIM_DONUS"].ToString(),
                        dataReader["KONAKLAMA_GUN"].ConInt(),
                        dataReader["KONAKLAMA_GUN_TL"].ConDouble(),
                        dataReader["KONAKLAMA_TOPLAM"].ConDouble(),
                        dataReader["KIRALAMA_GUN"].ConInt(),
                        dataReader["KIRALAMA_GUN_TL"].ConDouble(),
                        dataReader["KIRALAMA_YAKIT"].ConDouble(),
                        dataReader["KIRALAMA_TOPLAM"].ConDouble(),
                        dataReader["SEYAHAT_AVANS_GUN"].ConInt(),
                        dataReader["SEYAHAT_GUN_TL"].ConDouble(),
                        dataReader["SEYAHAT_TOPLAM"].ConDouble(),
                        dataReader["HARCIRAH_GUN"].ConInt(),
                        dataReader["HARCIRAH_GUN_TL"].ConDouble(),
                        dataReader["HARCIRAH_TOPLAM"].ConDouble(),
                        dataReader["IASE_GUN"].ConInt(),
                        dataReader["IASE_GUN_TL"].ConDouble(),
                        dataReader["IASE_TOPLAM"].ConDouble(),
                        dataReader["UCAK_BILETI"].ConDouble(),
                        dataReader["OTOBUS_BILETI"].ConDouble(),
                        dataReader["ARAC_PLAKASI"].ToString(),
                        dataReader["CIKIS_KM"].ConInt(),
                        dataReader["DONUS_KM"].ConInt(),
                        dataReader["TOPLAM_KM"].ConInt(),
                        dataReader["GENEL_TOPLAM"].ConDouble(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["KONAKLAMA_TURU"].ToString()));
                }
                dataReader.Close();
                return yurtIcis;
            }
            catch (Exception ex)
            {
                return new List<YurtIciGorev>();
            }
        }
        public List<YurtIciGorev> YurtIciGorevlerim(string adSoyad)
        {
            try
            {
                List<YurtIciGorev> yurtIcis = new List<YurtIciGorev>();
                dataReader = sqlServices.StoreReader("YurtIciGorevlerim", new SqlParameter("@adSoyad", adSoyad));
                while (dataReader.Read())
                {
                    yurtIcis.Add(new YurtIciGorev(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["GOREV_EMRI_NO"].ToString(),
                        dataReader["GOREVIN_KONUSU"].ToString(),
                        dataReader["PROJE"].ToString(),
                        dataReader["GIDILECEK_YER"].ToString(),
                        dataReader["BASLAMA_TARIHI"].ConDate(),
                        dataReader["BITIS_TARIHI"].ConDate(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["BUTCE_KODU_TANIMI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["ULASIM_GIDIS"].ToString(),
                        dataReader["ULASIM_GOREV_YERI"].ToString(),
                        dataReader["ULASIM_DONUS"].ToString(),
                        dataReader["KONAKLAMA_GUN"].ConInt(),
                        dataReader["KONAKLAMA_GUN_TL"].ConDouble(),
                        dataReader["KONAKLAMA_TOPLAM"].ConDouble(),
                        dataReader["KIRALAMA_GUN"].ConInt(),
                        dataReader["KIRALAMA_GUN_TL"].ConDouble(),
                        dataReader["KIRALAMA_YAKIT"].ConDouble(),
                        dataReader["KIRALAMA_TOPLAM"].ConDouble(),
                        dataReader["SEYAHAT_AVANS_GUN"].ConInt(),
                        dataReader["SEYAHAT_GUN_TL"].ConDouble(),
                        dataReader["SEYAHAT_TOPLAM"].ConDouble(),
                        dataReader["HARCIRAH_GUN"].ConInt(),
                        dataReader["HARCIRAH_GUN_TL"].ConDouble(),
                        dataReader["HARCIRAH_TOPLAM"].ConDouble(),
                        dataReader["IASE_GUN"].ConInt(),
                        dataReader["IASE_GUN_TL"].ConDouble(),
                        dataReader["IASE_TOPLAM"].ConDouble(),
                        dataReader["UCAK_BILETI"].ConDouble(),
                        dataReader["OTOBUS_BILETI"].ConDouble(),
                        dataReader["ARAC_PLAKASI"].ToString(),
                        dataReader["CIKIS_KM"].ConInt(),
                        dataReader["DONUS_KM"].ConInt(),
                        dataReader["TOPLAM_KM"].ConInt(),
                        dataReader["GENEL_TOPLAM"].ConDouble(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["KONAKLAMA_TURU"].ToString()));
                }
                dataReader.Close();
                return yurtIcis;
            }
            catch (Exception ex)
            {
                return new List<YurtIciGorev>();
            }
        }
        public string Update(YurtIciGorev entity, int isakisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YurtIciGorevGuncelle",
                    new SqlParameter("@isakisno", isakisno),
                    new SqlParameter("@gorevemrino", entity.Gorevemrino),
                    new SqlParameter("@gorevkonusu", entity.Gorevinkonusu),
                    new SqlParameter("@proje", entity.Proje),
                    new SqlParameter("@gidilecekyer", entity.Gidilecekyer),
                    new SqlParameter("@baslamatarihi", entity.Baslamatarihi),
                    new SqlParameter("@bitistarihi", entity.Bitistarihi),
                    new SqlParameter("@toplamsure", entity.Toplamsure),
                    new SqlParameter("@butcekodu", entity.Butcekodu),
                    new SqlParameter("@siparisno", entity.Siparisno),
                    new SqlParameter("@adsoyad", entity.Adsoyad),
                    new SqlParameter("@unvani", entity.Unvani),
                    new SqlParameter("@masrafyerino", entity.Masrafyerino),
                    new SqlParameter("@masrafyeri", entity.Masrafyeri),
                    new SqlParameter("@ulasimgidis", entity.Ulasimgidis),
                    new SqlParameter("@ulasimgorevyeri", entity.Ulasimgorevyeri),
                    new SqlParameter("@ulasimdonus", entity.Ulasimdonus),
                    new SqlParameter("@konaklamagun", entity.Konaklamagun),
                    new SqlParameter("@konaklamaguntl", entity.Konaklamaguntl),
                    new SqlParameter("@konaklamatoplam", entity.Konaklamatoplam),
                    new SqlParameter("@kiralamagun", entity.Kiralamagun),
                    new SqlParameter("@kiralamayakit", entity.Kiralamayakit),
                    new SqlParameter("@kiralamaguntl", entity.Kiralamaguntl),
                    new SqlParameter("@kiralamatoplam", entity.Kiralamatoplam),
                    new SqlParameter("@seyahatavansgun", entity.Seyahatavansgun),
                    new SqlParameter("@seyahatguntl", entity.Seyahatguntl),
                    new SqlParameter("@seyahattoplam", entity.Seyahattoplam),
                    new SqlParameter("@ucakbileti", entity.Ucakbileti),
                    new SqlParameter("@otobusbileti", entity.Otobusbileti),
                    new SqlParameter("@aracplakasi", entity.Plaka),
                    new SqlParameter("@cikiskm", entity.Cikiskm),
                    new SqlParameter("@donuskm", entity.Donuskm),
                    new SqlParameter("@toplamkm", entity.Toplamkm),
                    new SqlParameter("@geneltoplam", entity.Geneltoplam),
                    new SqlParameter("@islemadimi", entity.Islemadimi),
                    new SqlParameter("@dosyayolu", entity.Dosyayolu),
                    new SqlParameter("@konaklamaTuru", entity.KonaklamaTuru),
                    new SqlParameter("@harcirahGun", entity.HarcirahGun),
                    new SqlParameter("@harcirahGunTl",entity.HarcirahGunTl),
                    new SqlParameter("@harcirahGunToplam",entity.HarcirahToplam),
                    new SqlParameter("@iaseGun",entity.IaseGun),
                    new SqlParameter("@iaseGunTl",entity.IaseGunTl),
                    new SqlParameter("@iaseToplam",entity.IaseToplam));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string YurtIciGun(YurtIciGorev entity, int isakisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YurtIciGorevGun",
                    new SqlParameter("@isakisno", isakisno),
                    new SqlParameter("@gorevemrino", entity.Gorevemrino),
                    new SqlParameter("@gorevkonusu", entity.Gorevinkonusu),
                    new SqlParameter("@proje", entity.Proje),
                    new SqlParameter("@gidilecekyer", entity.Gidilecekyer),
                    new SqlParameter("@baslamatarihi", entity.Baslamatarihi),
                    new SqlParameter("@bitistarihi", entity.Bitistarihi),
                    new SqlParameter("@toplamsure", entity.Toplamsure),
                    new SqlParameter("@butcekodu", entity.Butcekodu),
                    new SqlParameter("@siparisno", entity.Siparisno),
                    new SqlParameter("@adsoyad", entity.Adsoyad),
                    new SqlParameter("@unvani", entity.Unvani),
                    new SqlParameter("@masrafyerino", entity.Masrafyerino),
                    new SqlParameter("@masrafyeri", entity.Masrafyeri),
                    new SqlParameter("@ulasimgidis", entity.Ulasimgidis),
                    new SqlParameter("@ulasimgorevyeri", entity.Ulasimgorevyeri),
                    new SqlParameter("@ulasimdonus", entity.Ulasimdonus),
                    new SqlParameter("@konaklamagun", entity.Konaklamagun),
                    new SqlParameter("@konaklamaguntl", entity.Konaklamaguntl),
                    new SqlParameter("@konaklamatoplam", entity.Konaklamatoplam),
                    new SqlParameter("@kiralamagun", entity.Kiralamagun),
                    new SqlParameter("@kiralamayakit", entity.Kiralamayakit),
                    new SqlParameter("@kiralamaguntl", entity.Kiralamaguntl),
                    new SqlParameter("@kiralamatoplam", entity.Kiralamatoplam),
                    new SqlParameter("@seyahatavansgun", entity.Seyahatavansgun),
                    new SqlParameter("@seyahatguntl", entity.Seyahatguntl),
                    new SqlParameter("@seyahattoplam", entity.Seyahattoplam),
                    new SqlParameter("@ucakbileti", entity.Ucakbileti),
                    new SqlParameter("@otobusbileti", entity.Otobusbileti),
                    new SqlParameter("@aracplakasi", entity.Plaka),
                    new SqlParameter("@cikiskm", entity.Cikiskm),
                    new SqlParameter("@donuskm", entity.Donuskm),
                    new SqlParameter("@toplamkm", entity.Toplamkm),
                    new SqlParameter("@geneltoplam", entity.Geneltoplam),
                    new SqlParameter("@harcirahGun", entity.HarcirahGun),
                    new SqlParameter("@harcirahGunTl", entity.HarcirahGunTl),
                    new SqlParameter("@harcirahGunToplam", entity.HarcirahToplam),
                    new SqlParameter("@iaseGun", entity.IaseGun),
                    new SqlParameter("@iaseGunTl", entity.IaseGunTl),
                    new SqlParameter("@iaseToplam", entity.IaseToplam));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<YurtIciGorev> DevamDevamsizlik(string islemadimi)
        {
            try
            {
                List<YurtIciGorev> yurts = new List<YurtIciGorev>();
                dataReader = sqlServices.StoreReader("DevamYurtIcıList", new SqlParameter("@islemadimi", islemadimi));
                while (dataReader.Read())
                {
                    yurts.Add(new YurtIciGorev(
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["BASLAMA_TARIHI"].ConDate(),
                        dataReader["BITIS_TARIHI"].ConDate(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["KALAN_SURE"].ToString()));                    
                }
                dataReader.Close();
                return yurts;
            }
            catch (Exception)
            {
                return new List<YurtIciGorev>();
            }
        }
        public static YurtIciGorevDal GetInstance()
        {
            if (yurtIciGorevDal == null)
            {
                yurtIciGorevDal = new YurtIciGorevDal();
            }
            return yurtIciGorevDal;
        }
    }
}
