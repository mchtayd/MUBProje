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
    public class EvrakKayitManager //: IRepository<EvrakKayit>
    {
        static EvrakKayitManager evrakKayitManager;
        EvrakKayitDal evrakKayitDal;
        string controlText;

        private EvrakKayitManager()
        {
            evrakKayitDal = EvrakKayitDal.GetInstance();
        }
        public string Add(EvrakKayit entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return evrakKayitDal.Add(entity);
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
                return evrakKayitDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public EvrakKayit Get(int isakisno)
        {
            try
            {
                return evrakKayitDal.Get(isakisno);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<EvrakKayit> GetList()
        {
            try
            {
                return evrakKayitDal.GetList();
            }
            catch (Exception)
            {
                return new List<EvrakKayit>();
            }
        }
        public static EvrakKayitManager GetInstance()
        {
            if (evrakKayitManager == null)
            {
                evrakKayitManager = new EvrakKayitManager();
            }
            return evrakKayitManager;
        }
        public string Update(EvrakKayit entity,int id)
        {
            try
            {
                return evrakKayitDal.Update(entity,id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complate(EvrakKayit evrak)
        {
            if (string.IsNullOrEmpty(evrak.YaziTuru))
            {
                return "Lütfen YAZI TÜRÜ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(evrak.Cinsi))
            {
                return "Lütfen CİNSİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(evrak.Sayino))
            {
                return "Lütfen SAYI NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(evrak.Tarih.ToString()))
            {
                return "Lütfen TARİH Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(evrak.Tarih.ToString()))
            {
                return "Lütfen TARİH Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(evrak.Konu))
            {
                return "Lütfen KONU Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(evrak.EkSayisi))
            {
                return "Lütfen EK SAYISI Bilgisini Giriniz.";
            }
            return "";
        }
    }
}
