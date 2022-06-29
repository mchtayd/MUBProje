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
    public class KonaklamaDal //: IRepository<Konaklama>
    {
        static KonaklamaDal konaklamaDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private KonaklamaDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Konaklama entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("KonaklamaEkle",
                    new SqlParameter("@isakisno",entity.Isakisno),
                    new SqlParameter("@talepturu",entity.Talepturu),
                    new SqlParameter("@formno",entity.Formno),
                    new SqlParameter("@butcekodu",entity.Butcekodu),
                    new SqlParameter("@siparisno",entity.Siparisno),
                    new SqlParameter("@adsoyad",entity.Adsoyad),
                    new SqlParameter("@gorevi",entity.Gorevi),
                    new SqlParameter("@masrafyerino",entity.Masrafyerino),
                    new SqlParameter("@masrafyeri",entity.Masrafyeri),
                    new SqlParameter("@tc",entity.Tc),
                    new SqlParameter("@hes",entity.Hes),
                    new SqlParameter("@email",entity.Email),
                    new SqlParameter("@kisakod",entity.Kisakod),
                    new SqlParameter("@otelsehir",entity.Otelsehir),
                    new SqlParameter("@otelad",entity.Otelad),
                    new SqlParameter("@gunlukucret",entity.Gunukucret),
                    new SqlParameter("@toplamucret",entity.Toplamucret),
                    new SqlParameter("@giristarihi",entity.Giristarihi),
                    new SqlParameter("@cikistarihi",entity.Cikistarihi),
                    new SqlParameter("@konaklamasuresi",entity.Konaklamasuresi),
                    new SqlParameter("@dosyayolu",entity.Dosyayolu),
                    new SqlParameter("@satNo",entity.SatNo),
                    new SqlParameter("@donem",entity.Donem),
                    new SqlParameter("@gerekce",entity.Gerekce));
                
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
                dataReader = sqlServices.StoreReader("KonaklamaSil",new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Konaklama Get(int isakisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("KonaklamaList",new SqlParameter("@isakisno", isakisno));
                Konaklama item = null;
                while (dataReader.Read())
                {
                    item = new Konaklama(
                    dataReader["ID"].ConInt(),
                    dataReader["IS_AKIS_NO"].ConInt(),
                    dataReader["TALEP_TURU"].ToString(),
                    dataReader["GOREV_FORM_NO"].ToString(),
                    dataReader["BUTCE_KODU_TANIMI"].ToString(),
                    dataReader["SIPARIS_NO"].ToString(),
                    dataReader["AD_SOYAD"].ToString(),
                    dataReader["GOREVI"].ToString(),
                    dataReader["MASRAF_YERI_NO"].ToString(),
                    dataReader["MASRAF_YERI"].ToString(),
                    dataReader["TC"].ToString(),
                    dataReader["HES"].ToString(),
                    dataReader["E_MAIL"].ToString(),
                    dataReader["KISA_KOD"].ToString(),
                    dataReader["OTEL_SEHIR"].ToString(),
                    dataReader["OTEL_AD"].ToString(),
                    dataReader["GUNLUK_UCRET"].ConDouble(),
                    dataReader["GENEL_TOPLAM"].ConDouble(),
                    dataReader["GIRIS_TARIHI"].ConDate(),
                    dataReader["CIKIS_TARIHI"].ConDate(),
                    dataReader["KONAKLAMA_SURESI"].ToString(),
                    dataReader["ONAY"].ToString(),
                    dataReader["DOSYA_YOLU"].ToString(),
                    dataReader["SAYFA"].ToString(),
                    dataReader["SAT_NO"].ConInt(),
                    dataReader["DONEM"].ToString(),
                    dataReader["GEREKCE"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Konaklama> GetList()
        {
            try
            {
                List<Konaklama> konaklamas = new List<Konaklama>();
                dataReader = sqlServices.StoreReader("KonaklamaList");
                while (dataReader.Read())
                {
                    konaklamas.Add(new Konaklama(dataReader["ID"].ConInt(),
                    dataReader["IS_AKIS_NO"].ConInt(),
                    dataReader["TALEP_TURU"].ToString(),
                    dataReader["GOREV_FORM_NO"].ToString(),
                    dataReader["BUTCE_KODU_TANIMI"].ToString(),
                    dataReader["SIPARIS_NO"].ToString(),
                    dataReader["AD_SOYAD"].ToString(),
                    dataReader["GOREVI"].ToString(),
                    dataReader["MASRAF_YERI_NO"].ToString(),
                    dataReader["MASRAF_YERI"].ToString(),
                    dataReader["TC"].ToString(),
                    dataReader["HES"].ToString(),
                    dataReader["E_MAIL"].ToString(),
                    dataReader["KISA_KOD"].ToString(),
                    dataReader["OTEL_SEHIR"].ToString(),
                    dataReader["OTEL_AD"].ToString(),
                    dataReader["GUNLUK_UCRET"].ConDouble(),
                    dataReader["GENEL_TOPLAM"].ConDouble(),
                    dataReader["GIRIS_TARIHI"].ConDate(),
                    dataReader["CIKIS_TARIHI"].ConDate(),
                    dataReader["KONAKLAMA_SURESI"].ToString(),
                    dataReader["ONAY"].ToString(),
                    dataReader["DOSYA_YOLU"].ToString(),
                    dataReader["SAYFA"].ToString(),
                    dataReader["SAT_NO"].ConInt(),
                    dataReader["DONEM"].ToString(),
                    dataReader["GEREKCE"].ToString()));
                }
                dataReader.Close();
                return konaklamas;
            }
            catch (Exception ex)
            {
                return new List<Konaklama>();
            }
        }
        public List<Konaklama> Konaklamalarim(string adSoyad)
        {
            try
            {
                List<Konaklama> konaklamas = new List<Konaklama>();
                dataReader = sqlServices.StoreReader("KonaklamalarimList", new SqlParameter("@adSoyad", adSoyad));
                while (dataReader.Read())
                {
                    konaklamas.Add(new Konaklama(dataReader["ID"].ConInt(),
                    dataReader["IS_AKIS_NO"].ConInt(),
                    dataReader["TALEP_TURU"].ToString(),
                    dataReader["GOREV_FORM_NO"].ToString(),
                    dataReader["BUTCE_KODU_TANIMI"].ToString(),
                    dataReader["SIPARIS_NO"].ToString(),
                    dataReader["AD_SOYAD"].ToString(),
                    dataReader["GOREVI"].ToString(),
                    dataReader["MASRAF_YERI_NO"].ToString(),
                    dataReader["MASRAF_YERI"].ToString(),
                    dataReader["TC"].ToString(),
                    dataReader["HES"].ToString(),
                    dataReader["E_MAIL"].ToString(),
                    dataReader["KISA_KOD"].ToString(),
                    dataReader["OTEL_SEHIR"].ToString(),
                    dataReader["OTEL_AD"].ToString(),
                    dataReader["GUNLUK_UCRET"].ConDouble(),
                    dataReader["GENEL_TOPLAM"].ConDouble(),
                    dataReader["GIRIS_TARIHI"].ConDate(),
                    dataReader["CIKIS_TARIHI"].ConDate(),
                    dataReader["KONAKLAMA_SURESI"].ToString(),
                    dataReader["ONAY"].ToString(),
                    dataReader["DOSYA_YOLU"].ToString(),
                    dataReader["SAYFA"].ToString(),
                    dataReader["SAT_NO"].ConInt(),
                    dataReader["DONEM"].ToString(),
                    dataReader["GEREKCE"].ToString()));
                }
                dataReader.Close();
                return konaklamas;
            }
            catch (Exception ex)
            {
                return new List<Konaklama>();
            }
        }
        public List<Konaklama> OnayList(string onay)
        {
            try
            {
                List<Konaklama> konaklamas = new List<Konaklama>();
                dataReader = sqlServices.StoreReader("KonaklamaOnayList",new SqlParameter("@onay",onay));
                while (dataReader.Read())
                {
                    konaklamas.Add(new Konaklama(
                    dataReader["ID"].ConInt(),
                    dataReader["IS_AKIS_NO"].ConInt(),
                    dataReader["TALEP_TURU"].ToString(),
                    dataReader["GOREV_FORM_NO"].ToString(),
                    dataReader["BUTCE_KODU_TANIMI"].ToString(),
                    dataReader["SIPARIS_NO"].ToString(),
                    dataReader["AD_SOYAD"].ToString(),
                    dataReader["GOREVI"].ToString(),
                    dataReader["MASRAF_YERI_NO"].ToString(),
                    dataReader["MASRAF_YERI"].ToString(),
                    dataReader["TC"].ToString(),
                    dataReader["HES"].ToString(),
                    dataReader["E_MAIL"].ToString(),
                    dataReader["KISA_KOD"].ToString(),
                    dataReader["OTEL_SEHIR"].ToString(),
                    dataReader["OTEL_AD"].ToString(),
                    dataReader["GUNLUK_UCRET"].ConDouble(),
                    dataReader["GENEL_TOPLAM"].ConDouble(),
                    dataReader["GIRIS_TARIHI"].ConDate(),
                    dataReader["CIKIS_TARIHI"].ConDate(),
                    dataReader["KONAKLAMA_SURESI"].ToString(),
                    dataReader["ONAY"].ToString(),
                    dataReader["DOSYA_YOLU"].ToString(),
                    dataReader["SAYFA"].ToString(),
                    dataReader["SAT_NO"].ConInt(),
                    dataReader["DONEM"].ToString(),
                    dataReader["GEREKCE"].ToString()));
                }
                dataReader.Close();
                return konaklamas;
            }
            catch (Exception)
            {
                return new List<Konaklama>();
            }
        }

        public string Update(Konaklama entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("KonaklamaGuncelle",
                    new SqlParameter("@id",id),
                    new SqlParameter("@isakisno", entity.Isakisno),
                    new SqlParameter("@talepturu", entity.Talepturu),
                    new SqlParameter("@formno", entity.Formno),
                    new SqlParameter("@butcekodu", entity.Butcekodu),
                    new SqlParameter("@siparisno", entity.Siparisno),
                    new SqlParameter("@adsoyad", entity.Adsoyad),
                    new SqlParameter("@gorevi", entity.Gorevi),
                    new SqlParameter("@masrafyerino", entity.Masrafyerino),
                    new SqlParameter("@masrafyeri", entity.Masrafyeri),
                    new SqlParameter("@tc", entity.Tc),
                    new SqlParameter("@hes", entity.Hes),
                    new SqlParameter("@email", entity.Email),
                    new SqlParameter("@kisakod", entity.Kisakod),
                    new SqlParameter("@otelsehir", entity.Otelsehir),
                    new SqlParameter("@otelad", entity.Otelad),
                    new SqlParameter("@gunlukucret",entity.Gunukucret),
                    new SqlParameter("@toplamucret",entity.Toplamucret),
                    new SqlParameter("@giristarihi", entity.Giristarihi),
                    new SqlParameter("@cikistarihi", entity.Cikistarihi),
                    new SqlParameter("@konaklamasuresi", entity.Konaklamasuresi),
                    new SqlParameter("@dosyayolu",entity.Dosyayolu),
                    new SqlParameter("@donem",entity.Donem),
                    new SqlParameter("@gerekce",entity.Gerekce));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string OnayGuncelle(Konaklama entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("KonaklamaOnayGuncelle",
                    new SqlParameter("@id",id),
                    new SqlParameter("@onay",entity.Onay));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SatDurumuGuncelle(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("KonaklamaSatGuncelle",
                    new SqlParameter("@id", id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static KonaklamaDal GetInstance()
        {
            if (konaklamaDal == null)
            {
                konaklamaDal = new KonaklamaDal();
            }
            return konaklamaDal;
        }
    }
}
