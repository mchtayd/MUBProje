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
    public class TekliflerManager
    {
        static TekliflerManager tekliflerManager;
        TekliflerDal tekliflerDal;
        string controlText;

        private TekliflerManager()
        {
            tekliflerDal = TekliflerDal.GetInstance();
        }
        public string Add(Teklifler entity, string siparisNo)
        {
            try
            {
                controlText = IsTekliflerComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return tekliflerDal.Add(entity, siparisNo);
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

        public Teklifler Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Teklifler> GetList(string siparisNo = "")
        {
            try
            {
                return tekliflerDal.GetList(siparisNo);
            }
            catch
            {
                return new List<Teklifler>();
            }
        }

        public string Update(Teklifler entity)
        {
            throw new NotImplementedException();
        }
        public static TekliflerManager GetInstance()
        {
            if (tekliflerManager == null)
            {
                tekliflerManager = new TekliflerManager();
            }
            return tekliflerManager;
        }
        string IsTekliflerComplete(Teklifler teklifler)
        {
            if (string.IsNullOrEmpty(teklifler.Bf1.ToString()))
            {
                return "Lütfen Birinci Fiyat Tekliflerini Giriniz.";
            }
            if (string.IsNullOrEmpty(teklifler.If2.ToString()))
            {
                return "Lütfen İkinci Fiyat Tekliflerini Giriniz.";
            }
            if (string.IsNullOrEmpty(teklifler.Uf3.ToString()))
            {
                return "Lütfen Üçüncü Fiyat Tekliflerini Giriniz.";
            }
            return "";
        }
        string IsTekliflerOnayComplete(Teklifler teklifler)
        {
            if (string.IsNullOrEmpty(teklifler.Onaylananbirim.ToString()))
            {
                return "Lütfen Onaylacak Birim Fiyatını Giriniz Giriniz.";
            }
            if (string.IsNullOrEmpty(teklifler.Onaylanantoplam.ToString()))
            {
                return "Lütfen Onaylacak Toplam Fiyatı Giriniz Giriniz.";
            }
            return "";
        }
    }
}
