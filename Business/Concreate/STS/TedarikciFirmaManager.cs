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
    public class TedarikciFirmaManager //: IRepository<TedarikciFirma>
    {
        static TedarikciFirmaManager tedarikciFirmaManager;
        TedarikciFirmaDal tedarikciFirmaDal;
        string controlText;
        private TedarikciFirmaManager()
        {
            tedarikciFirmaDal = TedarikciFirmaDal.GetInstance();
        }

        public string Add(TedarikciFirma entity)
        {
            try
            {
                controlText = IsTedarikciComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return tedarikciFirmaDal.Add(entity);
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
                    return "Lütfen Geçerli Bir Tedarikçi Firma Seçiniz.";
                }
                return tedarikciFirmaDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public TedarikciFirma Get(int id)
        {
            return null;
        }

        public List<TedarikciFirma> GetList(string benzersiz="")
        {
            try
            {
                return tedarikciFirmaDal.GetList(benzersiz);
            }
            catch
            {
                return new List<TedarikciFirma>();
            }
        }
        public List<string> Iller()
        {
            try
            {
                return tedarikciFirmaDal.Iller();
            }
            catch
            {
                return new List<string>();
            }
        }
        public List<string> Ilceler(string il)
        {
            try
            {
                return tedarikciFirmaDal.Ilceler(il);
            }
            catch
            {
                return new List<string>();
            }
        }

        public string Update(TedarikciFirma entity)
        {
            try
            {
                controlText = IsTedarikciComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return tedarikciFirmaDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<TedarikciFirma> SuppliersNameMail()
        {
            try
            {
                return tedarikciFirmaDal.SuppliersNameMail();
            }
            catch (Exception)
            {
                return new List<TedarikciFirma>();
            }
        }

        string IsTedarikciComplete(TedarikciFirma tedarikciFirma)
        {
            if (string.IsNullOrEmpty(tedarikciFirma.Firmaadi))
            {
                return "Lütfen FİRMA ADI Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(tedarikciFirma.Firmaadresi))
            {
                return "Lütfen FİRMA ADRESİ Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(tedarikciFirma.FirmaIl))
            {
                return "Lütfen FİRMA İL Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(tedarikciFirma.Firmailce))
            {
                return "Lütfen FİRMA İLÇE Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(tedarikciFirma.Telefon))
            {
                return "Lütfen TELEFON Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(tedarikciFirma.Faliyetalani))
            {
                return "Lütfen FALİYET ALANI kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(tedarikciFirma.Personelad))
            {
                return "Lütfen PERSONEL AD SOYAD kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(tedarikciFirma.Personeltelefon))
            {
                return "Lütfen PERSONEL TELEFON kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(tedarikciFirma.Mail))
            {
                return "Lütfen MAİL kısmını doldurunuz.";
            }
            return "";
        }
        public static TedarikciFirmaManager GetInstance()
        {
            if (tedarikciFirmaManager == null)
            {
                tedarikciFirmaManager = new TedarikciFirmaManager();
            }
            return tedarikciFirmaManager;
        }
    }
}
