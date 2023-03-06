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
    public class DokumanManager
    {
        static DokumanManager dokumanManager;
        DokumanDal dokumanDal;
        string controlText;

        private DokumanManager()
        {
            dokumanDal = DokumanDal.GetInstance();
        }

        public string Add(Dokuman entity)
        {
            try
            {
                controlText = IsDokumanComplete(entity);
                if (controlText!="")
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
            try
            {
                return dokumanDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Dokuman Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Dokuman> GetList(string benzersiz = "")
        {
            try
            {
                return dokumanDal.GetList(benzersiz);
            }
            catch
            {
                return new List<Dokuman>();
            }
        }

        public string Update(Dokuman entity)
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
        public static DokumanManager GetInstance()
        {
            if (dokumanManager == null)
            {
                dokumanManager = new DokumanManager();
            }
            return dokumanManager;
        }
        string IsDokumanComplete(Dokuman dokuman)
        {
            if (string.IsNullOrEmpty(dokuman.Tur))
            {
                return "Lütfen DOKÜMAN TÜRÜ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(dokuman.Numarasi))
            {
                return "Lütfen DOKÜMAN NUMARASINI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(dokuman.Tanimi))
            {
                return "Lütfen DOKÜMAN TANIMI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(dokuman.Revizyon))
            {
                return "Lütfen DOKÜMAN REVİZYON Bilgisini Giriniz.";
            }
            return "";
        }
    }
}
