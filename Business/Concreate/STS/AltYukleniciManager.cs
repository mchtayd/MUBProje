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
    public class AltYukleniciManager // : IRepository<AltYuklenici>
    {
        static AltYukleniciManager yukleniciManager;
        AltYukleniciDal altYukleniciDal;
        string controlText;

        private AltYukleniciManager()
        {
            altYukleniciDal = AltYukleniciDal.GetInstance();
        }
        public string Add(AltYuklenici entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText!="")
                {
                    return controlText;
                }
                return altYukleniciDal.Add(entity);
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
                    return "Lütfen Geçerli Bir SAT Seçiniz.";
                }
               return altYukleniciDal.Delete(id);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public AltYuklenici Get(int id)
        {
            try
            {
                return altYukleniciDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AltYuklenici> GetList(int id)
        {
            try
            {
                return altYukleniciDal.GetList(id);
            }
            catch (Exception)
            {
                return new List<AltYuklenici>();
            }
        }

        public string Update(AltYuklenici entity,int id)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return altYukleniciDal.Update(entity,id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(AltYuklenici altYuklenici)
        {

            if (string.IsNullOrEmpty(altYuklenici.Firmaadi))
            {
                return "Lütfen FİRMA ADI Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(altYuklenici.Firmaadresi))
            {
                return "Lütfen FİRMA ADRESİ Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(altYuklenici.Il))
            {
                return "Lütfen İL Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(altYuklenici.Ilçe))
            {
                return "Lütfen FİRMA İLÇE Kısmını doldurunuz.";
            }

            if (string.IsNullOrEmpty(altYuklenici.Telefon))
            {
                return "Lütfen TELEFON Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(altYuklenici.Faliyatalani))
            {
                return "Lütfen FALİYET ALANI Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(altYuklenici.Faliyatalani))
            {
                return "Lütfen FALİYET ALANI Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(altYuklenici.Personeladi))
            {
                return "Lütfen PERSONEL ADI Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(altYuklenici.Personeltelefon))
            {
                return "Lütfen PERSONEL TELEFON Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(altYuklenici.Mail))
            {
                return "Lütfen MAİL Kısmını doldurunuz.";
            }
            return "";
        }
        public static AltYukleniciManager GetInstance()
        {
            if (yukleniciManager == null)
            {
                yukleniciManager = new AltYukleniciManager();
            }
            return yukleniciManager;
        }
    }
}
