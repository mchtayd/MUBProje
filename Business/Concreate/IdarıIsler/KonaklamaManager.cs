using DataAccess.Abstract;
using DataAccess.Concreate.IdariIsler;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.IdarıIsler
{
    public class KonaklamaManager // : IRepository<Konaklama>
    {
        static KonaklamaManager konaklamaManager;
        KonaklamaDal konaklamaDal;
        string controlText;

        private KonaklamaManager()
        {
            konaklamaDal = KonaklamaDal.GetInstance();
        }
        public string Add(Konaklama entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return konaklamaDal.Add(entity);
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
                return konaklamaDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string IsAkisNoDuzelt(int id,int isAkisNo,string dosyaYolu)
        {
            try
            {
                return konaklamaDal.IsAkisNoDuzelt(id, isAkisNo, dosyaYolu);
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
                return konaklamaDal.Get(isakisno);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Konaklama> GetList(int isAkisNo=0)
        {
            try
            {
                return konaklamaDal.GetList(isAkisNo);
            }
            catch (Exception)
            {
                return new List<Konaklama>();
            }
        }

        public List<Konaklama> Konaklamalarim(string adSoyad)
        {
            try
            {
                return konaklamaDal.Konaklamalarim(adSoyad);
            }
            catch (Exception)
            {
                return new List<Konaklama>();
            }
        }

        public List<Konaklama> OnayList(string onay)
        {
            try
            {
                return konaklamaDal.OnayList(onay);
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
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return konaklamaDal.Update(entity,id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string OnayGuncelle(string onay, int id)
        {
            try
            {
                return konaklamaDal.OnayGuncelle(onay, id);
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
                return konaklamaDal.SatDurumuGuncelle(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static KonaklamaManager GetInstance()
        {
            if (konaklamaManager == null)
            {
                konaklamaManager = new KonaklamaManager();
            }
            return konaklamaManager;
        }
        string Complate(Konaklama konaklama)
        {
            if (string.IsNullOrEmpty(konaklama.Talepturu))
            {
                return "Lütfen TALEP TÜRÜ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(konaklama.Formno))
            {
                return "Lütfen GÖREV FORM NO Bilgilerini Giriniz.";
            }
            if (string.IsNullOrEmpty(konaklama.Butcekodu))
            {
                return "Lütfen BÜTÇE KODU/TANIMI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(konaklama.Siparisno))
            {
                return "Lütfen SİPARİŞ NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(konaklama.Adsoyad))
            {
                return "Lütfen AD SOYAD Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(konaklama.Gorevi))
            {
                return "Lütfen GÖREVİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(konaklama.Masrafyerino))
            {
                return "Lütfen MASRAF YERİ NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(konaklama.Masrafyeri))
            {
                return "Lütfen MASRAF YERİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(konaklama.Masrafyeri))
            {
                return "Lütfen MASRAF YERİ/BÖLÜMÜ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(konaklama.Tc.ToString()))
            {
                return "Lütfen TC KİMLİK NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(konaklama.Hes))
            {
                return "Lütfen HES KODU Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(konaklama.Email))
            {
                return "Lütfen E-MAIL Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(konaklama.Kisakod))
            {
                return "Lütfen ŞİRKET NO/KISA KOD Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(konaklama.Otelsehir))
            {
                return "Lütfen OTELİN BULUNDUĞU ŞEHİR Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(konaklama.Otelad))
            {
                return "Lütfen OTELİN ADI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(konaklama.Konaklamasuresi))
            {
                return "Lütfen KONAKLAMA SÜRESİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(konaklama.Toplamucret.ToString()))
            {
                return "Lütfen GENEL TOPLAM Bilgisini Bilgisini Giriniz.";
            }
            return "";
        }
    }
}
