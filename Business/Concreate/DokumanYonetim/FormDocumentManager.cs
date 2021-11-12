using DataAccess.Abstract;
using DataAccess.Concreate.DokumanYonetim;
using Entity.DokumanYonetim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.DokumanYonetim
{
    public class FormDocumentManager
    {
        static FormDocumentManager dokumanManager;
        FormDocumentDal dokumanDal;
        string controlText;
        private FormDocumentManager()
        {
            dokumanDal = FormDocumentDal.GetInstance();
        }
        public string Add(FormDocument entity)
        {
            try
            {
                controlText = IsDokumanComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return dokumanDal.Add(entity);
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

        public FormDocument Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<FormDocument> GetList(string benzersiz="")
        {
            try
            {
                return dokumanDal.GetList(benzersiz);
            }
            catch
            {
                return new List<FormDocument>();
            }
        }

        public string Update(FormDocument entity)
        {
            try
            {
                controlText = IsDokumanComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return dokumanDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static FormDocumentManager GetInstance()
        {
            if (dokumanManager == null)
            {
                dokumanManager = new FormDocumentManager();
            }
            return dokumanManager;
        }
        string IsDokumanComplete(FormDocument dokuman)
        {
            if (string.IsNullOrEmpty(dokuman.Tur))
            {
                return "Lütfen FORM TÜRÜ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(dokuman.Numarasi))
            {
                return "Lütfen FORM NUMARASINI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(dokuman.Tanimi))
            {
                return "Lütfen FORM TANIMI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(dokuman.Revizyon))
            {
                return "Lütfen FORM REVİZYON Bilgisini Giriniz.";
            }
            return "";
        }
    }
}
