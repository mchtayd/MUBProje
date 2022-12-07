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
    public class AracZimmetiManager //: IRepository<AracZimmeti>
    {
        static AracZimmetiManager aracZimmetiManager;
        AracZimmetDal aracZimmetDal;
        string controlText;

        private AracZimmetiManager()
        {
            aracZimmetDal = AracZimmetDal.GetInstance();
        }
        public string Add(AracZimmeti entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return aracZimmetDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int isAkisNo,string personelAd)
        {
            try
            {
                return aracZimmetDal.Delete(isAkisNo, personelAd);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public AracZimmeti Get(string plaka)
        {
            try
            {
                return aracZimmetDal.Get(plaka);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public AracZimmeti GetAdSoyad(string adSoyad)
        {
            try
            {
                return aracZimmetDal.GetAdSoyad(adSoyad);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<AracZimmeti> GetList()
        {
            try
            {
                return aracZimmetDal.GetList();
            }
            catch (Exception)
            {
                return new List<AracZimmeti>();
            }
        }
        public List<AracZimmeti> AracZimmetiListele(int isAkisNo = 0)
        {
            try
            {
                return aracZimmetDal.AracZimmetiListele(isAkisNo);
            }
            catch (Exception)
            {
                return new List<AracZimmeti>();
            }
        }
        public string IsAkisNoDuzelt(int id, int isAkisNo)
        {
            try
            {

                return aracZimmetDal.IsAkisNoDuzelt(id, isAkisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<AracZimmeti> SiparisArac(string siparis)
        {
            try
            {
                return aracZimmetDal.SiparisArac(siparis);
            }
            catch (Exception)
            {
                return new List<AracZimmeti>();
            }
        }

        public string Update(AracZimmeti entity)
        {
            throw new NotImplementedException();
        }
        string Complate(AracZimmeti arac)
        {
            if (string.IsNullOrEmpty(arac.Plaka))
            {
                return "Lütfen ARAÇ PLAKASI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.Km.ToString()))
            {
                return "Lütfen Kilometre Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.Gerekce))
            {
                return "Lütfen AKTARIM GEREKÇESİ Bilgisini Giriniz.";
            }
            return "";
        }
        public static AracZimmetiManager GetInstance()
        {
            if (aracZimmetiManager == null)
            {
                aracZimmetiManager = new AracZimmetiManager();
            }
            return aracZimmetiManager;
        }
    }
}
