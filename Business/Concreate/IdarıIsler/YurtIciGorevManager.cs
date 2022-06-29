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
    public class YurtIciGorevManager // : IRepository<YurtIciGorev>
    {
        static YurtIciGorevManager yurtIciGorevManager;
        YurtIciGorevDal yurtIciGorevDal;
        string controlText;

        private YurtIciGorevManager()
        {
            yurtIciGorevDal = YurtIciGorevDal.GetInstance();
        }
        public string Add(YurtIciGorev entity)
        {
            try
            {
                /*controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }*/
                return yurtIciGorevDal.Add(entity);
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
                return yurtIciGorevDal.Delete(isakisno);
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
                return yurtIciGorevDal.Get(isakisno);
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
                return yurtIciGorevDal.AracTalepGet(isAkisNo);
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
                return yurtIciGorevDal.GetList(durum);
            }
            catch (Exception)
            {
                return new List<YurtIciGorev>();
            }
        }

        public List<YurtIciGorev> YurtIciGorevlerim(string adSoyad)
        {
            try
            {
                return yurtIciGorevDal.YurtIciGorevlerim(adSoyad);
            }
            catch (Exception)
            {
                return new List<YurtIciGorev>();
            }
        }

        public string Update(YurtIciGorev entity, int isakisno)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return yurtIciGorevDal.Update(entity, isakisno);
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
                return yurtIciGorevDal.YurtIciGun(entity, isakisno);
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
                return yurtIciGorevDal.DevamDevamsizlik(islemadimi);
            }
            catch (Exception)
            {
                return new List<YurtIciGorev>();
            }
        }
        string Complate(YurtIciGorev yurtIciGorev)
        {
            if (string.IsNullOrEmpty(yurtIciGorev.Gorevemrino))
            {
                return "Lütfen GÖREV EMRİ NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yurtIciGorev.Gorevinkonusu))
            {
                return "Lütfen GÖREVİN KONUSU Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yurtIciGorev.Proje))
            {
                return "Lütfen PROJE Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yurtIciGorev.Gidilecekyer))
            {
                return "Lütfen GİDİLECEK YER Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yurtIciGorev.Toplamsure))
            {
                return "Lütfen TOPLAM SÜRE Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yurtIciGorev.Butcekodu))
            {
                return "Lütfen BÜTÇE KODU/TANIMI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yurtIciGorev.Siparisno))
            {
                return "Lütfen SİPARİŞ NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yurtIciGorev.Adsoyad))
            {
                return "Lütfen AD SOYAD Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yurtIciGorev.Masrafyerino))
            {
                return "Lütfen MASRAF YERİ NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yurtIciGorev.Masrafyeri))
            {
                return "Lütfen MASRAF YERİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yurtIciGorev.Ulasimgidis))
            {
                return "Lütfen ULAŞIM GİDİŞ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yurtIciGorev.Ulasimgorevyeri))
            {
                return "Lütfen ULAŞIM GÖREV YERİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yurtIciGorev.Ulasimdonus))
            {
                return "Lütfen ULAŞIM DÖNÜŞ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yurtIciGorev.Geneltoplam.ToString()))
            {
                return "Lütfen PERSONELİN HARCAMA Bilgilerini Giriniz.";
            }
            return "";
        }
        public static YurtIciGorevManager GetInstance()
        {
            if (yurtIciGorevManager == null)
            {
                yurtIciGorevManager = new YurtIciGorevManager();
            }
            return yurtIciGorevManager;
        }
    }
}
