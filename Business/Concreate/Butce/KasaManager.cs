using DataAccess.Abstract;
using DataAccess.Concreate.Butce;
using Entity.Butce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Butce
{
    public class KasaManager //: IRepository<Kasa>
    {
        static KasaManager kasaManager;
        KasaDal kasaDal;
        string controlText;

        private KasaManager()
        {
            kasaDal = KasaDal.GetInstance();
        }

        public string Add(Kasa entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return kasaDal.Add(entity);
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
                return kasaDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Kasa Get(string hesapSahibi)
        {
            try
            {
                return kasaDal.Get(hesapSahibi);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Kasa> GetList()
        {
            try
            {
                return kasaDal.GetList();
            }
            catch (Exception)
            {
                return new List<Kasa>();
            }
        }

        public string Update(Kasa entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return kasaDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(Kasa kasa)
        {

            if (string.IsNullOrEmpty(kasa.HesapSahibi))
            {
                return "Lütfen HESAP SAHİBİ Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(kasa.MusteriNumarasi))
            {
                return "Lütfen MÜŞTERİ NUMARASI Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(kasa.DovizCinsi))
            {
                return "Lütfen DÖVÜZ CİNSİ Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(kasa.SubeAdi))
            {
                return "Lütfen ŞUBE ADI Kısmını doldurunuz.";
            }

            if (string.IsNullOrEmpty(kasa.HesapNumarasi))
            {
                return "Lütfen HESAP NUMARASI Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(kasa.Iban))
            {
                return "Lütfen IBAN Kısmını doldurunuz.";
            }
            
            return "";
        }

        public static KasaManager GetInstance()
        {
            if (kasaManager == null)
            {
                kasaManager = new KasaManager();
            }
            return kasaManager;
        }
    }
}
