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
    public class IstenAyrilisManager
    {
        static IstenAyrilisManager istenAyrilisManager;
        IstenAyrilisDal istenAyrilisDal;
        string controlText;

        private IstenAyrilisManager()
        {
            istenAyrilisDal = IstenAyrilisDal.GetInstance();
        }

        public string Add(IstenAyrilis entity)
        {
            try
            {
                controlText = IsIstenAyrilisComplate(entity);
                if (controlText!="")
                {
                    return controlText;
                }
                return istenAyrilisDal.Add(entity);
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
                if (id < 1)
                {
                    return "Lütfen geçerli bir Personel Seçiniz.";
                }
                return istenAyrilisDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IstenAyrilis Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<IstenAyrilis> GetList(string tc = "")
        {
            try
            {
                return istenAyrilisDal.GetList(tc);
            }
            catch
            {
                return new List<IstenAyrilis>();
            }
        }

        public string Update(IstenAyrilis entity)
        {
            throw new NotImplementedException();
        }
        public static IstenAyrilisManager GetInstance()
        {
            if (istenAyrilisManager == null)
            {
                istenAyrilisManager = new IstenAyrilisManager();
            }
            return istenAyrilisManager;
        }
        string IsIstenAyrilisComplate(IstenAyrilis istenAyrilis)
        {
            if (string.IsNullOrEmpty(istenAyrilis.Adsoyad))
            {
                return "Lütfen Personelin AD SOYAD BİLGİLERİNİ Giriniz Veya Personeli Tekrar Listeden Seçiniz.";
            }
            if (string.IsNullOrEmpty(istenAyrilis.Istenayrilisaciklama))
            {
                return "Lütfen Personelin İşten Ayrılış Sebebiyle ilgili AÇIKLAMA bilgilerini giriniz.";
            }
            if (string.IsNullOrEmpty(istenAyrilis.Ayrilisnedeni))
            {
                return "Lütfen Personelin İşten Ayrılış Nedeni Bilgilerini Giriniz.";
            }
            return "";
        }
    }
}
