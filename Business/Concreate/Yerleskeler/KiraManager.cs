using DataAccess.Abstract;
using DataAccess.Concreate.Yerleskeler;
using Entity.Yerleskeler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Yerleskeler
{
    public class KiraManager // : IRepository<Kira>
    {
        static KiraManager kiraManager;
        KiraDal kiraDal;
        string controlText;

        private KiraManager()
        {
            kiraDal = KiraDal.GetInstance();
        }
        public string Add(Kira entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return kiraDal.Add(entity);
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

        public Kira Get(int id)
        {
            try
            {
                return kiraDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Kira> GetList()
        {
            try
            {
                return kiraDal.GetList();
            }
            catch (Exception)
            {
                return new List<Kira>();
            }
        }
        public List<Kira> YerleskeKontrol(string yerleskeAdi, string yerleskeAdresi, string mulkiyetBilgileri, string siparisNo)
        {
            try
            {
                return kiraDal.YerleskeKontrol(yerleskeAdi,yerleskeAdresi,mulkiyetBilgileri,siparisNo);
            }
            catch (Exception)
            {
                return new List<Kira>();
            }
        }
        public static KiraManager GetInstance()
        {
            if (kiraManager == null)
            {
                kiraManager = new KiraManager();
            }
            return kiraManager;
        }

        public string Update(Kira entity)
        {
            throw new NotImplementedException();
        }
        string Complate(Kira kira)
        {
            if (string.IsNullOrEmpty(kira.AdiSoyadi))
            {
                return "Lütfen Kiraya Verenin Adı Soyadı Bilgisini Doldurunuz!";
            }
            if (string.IsNullOrEmpty(kira.Tc))
            {
                return "Lütfen Kiraya Verenin Tc Bilgisi Bilgisini Doldurunuz!";
            }
            if (string.IsNullOrEmpty(kira.Ikametgah))
            {
                return "Lütfen Kiraya Verenin İkametgah Bilgisini Doldurunuz!";
            }
            if (string.IsNullOrEmpty(kira.Telefon))
            {
                return "Lütfen Kiraya Verenin Telefon Bilgisini Doldurunuz!";
            }
            if (string.IsNullOrEmpty(kira.BankaSubesi))
            {
                return "Lütfen Kiraya Verenin Banka Şubesi Bilgisini Doldurunuz!";
            }
            if (string.IsNullOrEmpty(kira.IbanNo))
            {
                return "Lütfen Kiraya Verenin IBAN No Bilgisini Bilgisini Doldurunuz!";
            }
            return "";
        }
    }
}
