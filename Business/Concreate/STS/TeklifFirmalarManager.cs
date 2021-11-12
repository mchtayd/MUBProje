using DataAccess.Abstract;
using DataAccess.Concreate.STS;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.STS
{
    public class TeklifFirmalarManager
    {
        static TeklifFirmalarManager teklifFirmalarManager;
        TeklifFirmalarDal teklifFirmalarDal;
        string controlText;
        private TeklifFirmalarManager()
        {
            teklifFirmalarDal = TeklifFirmalarDal.GetInstance();
        }

        public string Add(TeklifFirmalar entity, string siparisNo)
        {
            try
            {
                controlText = IsTeklifFirmalarComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return teklifFirmalarDal.Add(entity, siparisNo);
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

        public TeklifFirmalar Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TeklifFirmalar> GetList(string siparisno="")
        {
            try
            {
                return teklifFirmalarDal.GetList(siparisno);
            }
            catch
            {
                return new List<TeklifFirmalar>();
            }
        }
        public List<TeklifFirmalar> TedarikciFirmalar(bool isExistAll)
        {
            try
            {
                return teklifFirmalarDal.TedarikciFirmalar(isExistAll);
            }
            catch
            {
                return new List<TeklifFirmalar>();
            }
        }

        public string Update(TeklifFirmalar entity)
        {
            throw new NotImplementedException();
        }

        string IsTeklifFirmalarComplete(TeklifFirmalar teklifFirmalar)
        {
            if (string.IsNullOrEmpty(teklifFirmalar.Fa1))
            {
                return "Lütfen Firma Bilgilerini Eksiksiz Giriniz.";
            }
            if (string.IsNullOrEmpty(teklifFirmalar.Fa2))
            {
                return "Lütfen Firma Bilgilerini Eksiksiz Giriniz.";
            }
            if (string.IsNullOrEmpty(teklifFirmalar.Fa3))
            {
                return "Lütfen Firma Bilgilerini Eksiksiz Giriniz.";
            }
            if (string.IsNullOrEmpty(teklifFirmalar.Fi1))
            {
                return "Lütfen Firma Bilgilerini Eksiksiz Giriniz.";
            }
            if (string.IsNullOrEmpty(teklifFirmalar.Fi2))
            {
                return "Lütfen Firma Bilgilerini Eksiksiz Giriniz.";
            }
            if (string.IsNullOrEmpty(teklifFirmalar.Fi3))
            {
                return "Lütfen Firma Bilgilerini Eksiksiz Giriniz.";
            }
            if (string.IsNullOrEmpty(teklifFirmalar.Fn1))
            {
                return "Lütfen Firma Bilgilerini Eksiksiz Giriniz.";
            }
            if (string.IsNullOrEmpty(teklifFirmalar.Fn2))
            {
                return "Lütfen Firma Bilgilerini Eksiksiz Giriniz.";
            }
            if (string.IsNullOrEmpty(teklifFirmalar.Fn3))
            {
                return "Lütfen Firma Bilgilerini Eksiksiz Giriniz.";
            }
            return "";
        }
        public static TeklifFirmalarManager GetInstance()
        {
            if (teklifFirmalarManager == null)
            {
                teklifFirmalarManager = new TeklifFirmalarManager();
            }
            return teklifFirmalarManager;
        }
    }
}
