using DataAccess.Abstract;
using DataAccess.Concreate.BakimOnarim;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.BakimOnarim
{
    public class ArizaKayitManager // : IRepository<ArizaKayit>
    {
        static ArizaKayitManager arizaKayitManager;
        ArizaKayitDal arizaKayitDal;
        string controlText;

        private ArizaKayitManager()
        {
            arizaKayitDal = ArizaKayitDal.GetInstance();
        }
        public string Add(ArizaKayit entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return arizaKayitDal.Add(entity);
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
                return arizaKayitDal.Delete(id);
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
                return arizaKayitDal.Get(abfFormNo);
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
                return arizaKayitDal.GetList();
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
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return arizaKayitDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(ArizaKayit arizaKayit)
        {
            if (string.IsNullOrEmpty(arizaKayit.Proje))
            {
                return "Lütfen PROJE Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(arizaKayit.BolgeAdi))
            {
                return "Lütfen BÖLGE ADI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(arizaKayit.BildirilenAriza))
            {
                return "Lütfen BİLDİRİLEN ARIZA Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(arizaKayit.ArizaiBildirenPersonel))
            {
                return "Lütfen ARIZA BİLDİREN BİRLİK PERSONELİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(arizaKayit.AbRutbesi))
            {
                return "Lütfen ARIZA BİLDİRİMİNDE BULUNAN PERSONELİN RÜTBESİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(arizaKayit.AbGorevi))
            {
                return "Lütfen ARIZA BİLDİRİMİNDE BULUNAN PERSONELİN GÖREVİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(arizaKayit.BildirimKanali))
            {
                return "Lütfen BİLDİRİM KANALI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(arizaKayit.ArizaAciklama))
            {
                return "Lütfen ARIZA AÇIKLAMASI Bilgisini doldurunuz.";
            }
            return "";
        }
        public static ArizaKayitManager GetInstance()
        {
            if (arizaKayitManager == null)
            {
                arizaKayitManager = new ArizaKayitManager();
            }
            return arizaKayitManager;
        }
    }
}
