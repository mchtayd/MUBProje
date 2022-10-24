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
    public class AracManager // : IRepository<Arac>
    {
        static AracManager aracManager;
        AracDal aracDal;
        string controlText;

        private AracManager()
        {
            aracDal = AracDal.GetInstance();
        }

        public string Add(Arac entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return aracDal.Add(entity);
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
                return aracDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Arac Get(string plaka)
        {
            try
            {
                return aracDal.Get(plaka);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Arac> GetList()
        {
            try
            {
                return aracDal.GetList();
            }
            catch (Exception)
            {
                return new List<Arac>();
            }
        }
        public List<Arac> ProjeDisiList()
        {
            try
            {
                return aracDal.ProjeDisiList();
            }
            catch (Exception)
            {
                return new List<Arac>();
            }
        }
        

        public string Update(Arac entity,int id)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return aracDal.Update(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string SiparisGuncelle(string plaka, string siparis)
        {
            try
            {
                
                return aracDal.SiparisGuncelle(plaka, siparis);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Kapatma(Arac entity, int id)
        {
            try
            {
                controlText = ComplateCikis(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return aracDal.Kapatma(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static AracManager GetInstance()
        {
            if (aracManager == null)
            {
                aracManager = new AracManager();
            }
            return aracManager;
        }
        string Complate(Arac arac)
        {
            if (string.IsNullOrEmpty(arac.Plaka))
            {
                return "Lütfen ARAÇ PLAKASI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.IlkTescilTarihi.ToString()))
            {
                return "Lütfen İLK TESCİL TARİHİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.TescilTarihi.ToString()))
            {
                return "Lütfen İLK TESCİL TARİHİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.Markasi))
            {
                return "Lütfen ARAÇ MARKASI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.MulkiyetBilgileri))
            {
                return "Lütfen MÜLKİYET BİLGİLERİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.Tipi))
            {
                return "Lütfen ARAÇ TİPİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.TicariAdi))
            {
                return "Lütfen TİCARİ ADI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.ModelYili))
            {
                return "Lütfen MODEL YILI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.ModelYili))
            {
                return "Lütfen MODEL YILI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.AracSinifi))
            {
                return "Lütfen ARAÇ SINIFI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.Cinsi))
            {
                return "Lütfen ARAÇ CİNSİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.Rengi))
            {
                return "Lütfen ARAÇ RENGİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.MotorNo))
            {
                return "Lütfen MOTOR NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.SaseNo))
            {
                return "Lütfen ŞASE NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.YakitCinsi))
            {
                return "Lütfen YAKIT CİNSİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.Proje))
            {
                return "Lütfen KULLANILDIĞI PROJE Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.Siparisno))
            {
                return "Lütfen SİPARİŞ NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.TasitTanima))
            {
                return "Lütfen TAŞIT TANIMA Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.ProjeTahsisTarihi.ToString()))
            {
                return "Lütfen PROJE TAHSİS TARİHİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.DosyaYolu))
            {
                return "Lütfen DOSYA YOLU Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.KmGiris.ToString()))
            {
                return "Lütfen KM GİRİŞ Bilgisini Giriniz.";
            }
            return "";
        }
        string ComplateCikis(Arac arac)
        {
            if (string.IsNullOrEmpty(arac.ProjeCikisNedeni))
            {
                return "Lütfen PROJEDEN ÇIKIŞ NEDENİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.ProjeCikisTarihi))
            {
                return "Lütfen PROJEDEN ÇIKIŞ TARİHİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.KmCikis.ToString()))
            {
                return "Lütfen KM ÇIKIŞ Bilgisini Giriniz.";
            }
            return "";
        }
    }
}
