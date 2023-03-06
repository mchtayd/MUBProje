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
    public class AracTalepManager // : IRepository<AracTalep>
    {
        static AracTalepManager aracTalepManager;
        AracTalepDal aracTalepDal;
        string controlText;

        private AracTalepManager()
        {
            aracTalepDal = AracTalepDal.GetInstance();
        }
        public string Add(AracTalep entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return aracTalepDal.Add(entity);
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
                return aracTalepDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public AracTalep Get(int id)
        {
            try
            {
                return aracTalepDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AracTalep> GetList()
        {
            try
            {
                return aracTalepDal.GetList();
            }
            catch (Exception)
            {
                return new List<AracTalep>();
            }
        }
        public List<AracTalep> GetListDevam(string durum)
        {
            try
            {
                return aracTalepDal.GetListDevam(durum);
            }
            catch (Exception)
            {
                return new List<AracTalep>();
            }
        }

        public string Update(AracTalep entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return aracTalepDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string KayitKapat(DateTime donusTarihiSaati, int donusKm, int id)
        {
            try
            {

                return aracTalepDal.KayitKapat(donusTarihiSaati, donusKm, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complate(AracTalep arac)
        {
            if (string.IsNullOrEmpty(arac.GorevEmriNo))
            {
                return "Lütfen GÖREV EMRİ NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.ButceKoduTanimi))
            {
                return "Lütfen BÜTÇE KODU Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.AracTalepNedeni))
            {
                return "Lütfen ARAÇ TALEP NEDENİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.GidilecekYer))
            {
                return "Lütfen GİDİLECEK YER Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.ToplamSure))
            {
                return "Lütfen TOPLAM SÜRE Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.PersonelAd))
            {
                return "Lütfen PERSONEL ADI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.Plaka))
            {
                return "Lütfen PLAKA Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.CikisKm.ToString()))
            {
                return "Lütfen ÇIKIŞ KM Bilgisini Giriniz.";
            }
            return "";
        }
        public static AracTalepManager GetInstance()
        {
            if (aracTalepManager == null)
            {
                aracTalepManager = new AracTalepManager();
            }
            return aracTalepManager;
        }
    }
}
