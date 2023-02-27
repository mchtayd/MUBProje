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
    public class YerleskeManager // : IRepository<Yerleske>
    {
        static YerleskeManager yerleskeManager;
        YerlekseDal yerlekseDal;
        string controlText;

        private YerleskeManager()
        {
            yerlekseDal = YerlekseDal.GetInstance();
        }
        public string Add(Yerleske entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return yerlekseDal.Add(entity);
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

        public Yerleske Get(string siparisNo)
        {
            try
            {
                return yerlekseDal.Get(siparisNo);

            }
            catch (Exception)
            {
                return null;
            }
        }
        public Yerleske YerleskeBiigiCek(string yerleskeAdi, string aboneTuru="")
        {
            try
            {
                return yerlekseDal.YerleskeBiigiCek(yerleskeAdi, aboneTuru);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Yerleske> GetList(string siparisNo)
        {
            try
            {
                return yerlekseDal.GetList(siparisNo);
            }
            catch (Exception)
            {
                return new List<Yerleske>();
            }
        }
        public List<Yerleske> AbonelikKontrol(string yerleskeAdi, string abonelikTuru, string hizmetAlinanKurum, string siparisNo)
        {
            try
            {
                return yerlekseDal.AbonelikKontrol(yerleskeAdi, abonelikTuru, hizmetAlinanKurum, siparisNo);
            }
            catch (Exception)
            {
                return new List<Yerleske>();
            }
        }

        public string Update(Yerleske entity)
        {
            throw new NotImplementedException();
        }
        public static YerleskeManager GetInstance()
        {
            if (yerleskeManager == null)
            {
                yerleskeManager = new YerleskeManager();
            }
            return yerleskeManager;
        }
        string Complate(Yerleske yerleske)
        {
            if (string.IsNullOrEmpty(yerleske.YerleskeAdi))
            {
                return "Lütfen Yerleşke Adı Bilgisini Doldurunuz!";
            }
            if (string.IsNullOrEmpty(yerleske.MulkiyetBilgileri))
            {
                return "Lütfen Mülkiyet Bilgisi Bilgisini Doldurunuz!";
            }
            if (string.IsNullOrEmpty(yerleske.YerleskeAdresi))
            {
                return "Lütfen Yerleşke Adresi Bilgisini Doldurunuz!";
            }
            if (string.IsNullOrEmpty(yerleske.AboneTuru))
            {
                return "Lütfen Abone Türü Bilgisini Doldurunuz!";
            }
            if (string.IsNullOrEmpty(yerleske.HizmetAlinanKurum))
            {
                return "Lütfen Hizmet Alınan Kurum Bilgisini Doldurunuz!";
            }
            if (string.IsNullOrEmpty(yerleske.AboneTesisatNo))
            {
                return "Lütfen Abone Tesisat No Bilgisini Doldurunuz!";
            }
            return "";
        }
    }
}
