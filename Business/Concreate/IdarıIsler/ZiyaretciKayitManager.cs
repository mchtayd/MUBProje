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
    public class ZiyaretciKayitManager // : IRepository<ZiyaretciKayit>
    {
        static ZiyaretciKayitManager ziyaretciKayitManager;
        ZiyaretciKayitDal ziyaretciKayitDal;
        string controlText;

        private ZiyaretciKayitManager()
        {
            ziyaretciKayitDal = ZiyaretciKayitDal.GetInstance();
        }
        public string Add(ZiyaretciKayit entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return ziyaretciKayitDal.Add(entity);

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

        public ZiyaretciKayit Get(int isAkisNo)
        {
            try
            {
                return ziyaretciKayitDal.Get(isAkisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ZiyaretciKayit> GetList()
        {
            try
            {
                return ziyaretciKayitDal.GetList();
            }
            catch (Exception)
            {
                return new List<ZiyaretciKayit>();
            }
        }

        public string Update(ZiyaretciKayit entity)
        {
            try
            {
                return ziyaretciKayitDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complate(ZiyaretciKayit ziyaretciKayit)
        {
            if (string.IsNullOrEmpty(ziyaretciKayit.ZiyaretciAd))
            {
                return "Lütfen ZİYARETCİ ADI SOYADI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ziyaretciKayit.FirmaAdi))
            {
                return "Lütfen FİRMA ADI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ziyaretciKayit.ZiyaretNedeni))
            {
                return "Lütfen ZİYARET NEDENİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ziyaretciKayit.ZiyaretEdilenAd))
            {
                return "Lütfen ZİYARET EDİLEN PERSONEL Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ziyaretciKayit.RefakatciAd))
            {
                return "Lütfen REFAKATÇİ ADI SOYADI Bilgisini Giriniz.";
            }
            return "";
        }
        public static ZiyaretciKayitManager GetInstance()
        {
            if (ziyaretciKayitManager == null)
            {
                ziyaretciKayitManager = new ZiyaretciKayitManager();
            }
            return ziyaretciKayitManager;
        }
    }
}
