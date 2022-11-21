using DataAccess.Abstract;
using DataAccess.Concreate.BakimOnarim;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.BakimOnarim
{
    public class BolgeKayitManager //: IRepository<BolgeKayit>
    {
        static BolgeKayitManager bolgeKayitManager;
        BolgeKayitDal bolgeKayitDal;
        string controlText;

        private BolgeKayitManager()
        {
            bolgeKayitDal = BolgeKayitDal.GetInstance();
        }
        public static BolgeKayitManager GetInstance()
        {
            if (bolgeKayitManager == null)
            {
                bolgeKayitManager = new BolgeKayitManager();
            }
            return bolgeKayitManager;
        }

        public string Add(BolgeKayit entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return bolgeKayitDal.Add(entity);
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
                return bolgeKayitDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public BolgeKayit Get(int id)
        {
            try
            {
                return bolgeKayitDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<BolgeKayit> GetList()
        {
            try
            {
                return bolgeKayitDal.GetList();
            }
            catch (Exception)
            {
                return new List<BolgeKayit>();
            }
        }
        
        public string Update(BolgeKayit entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return bolgeKayitDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateSiparisNo(int id, string siparisNo)
        {
            try
            {

                return bolgeKayitDal.UpdateSiparisNo(id, siparisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(BolgeKayit bolgeKayit)
        {
            if (string.IsNullOrEmpty(bolgeKayit.BolgeAdi))
            {
                return "Lütfen BÖLGE ADI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolgeKayit.KodAdi))
            {
                return "Lütfen KOD ADI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolgeKayit.UsBolgesiStok))
            {
                return "Lütfen BÖLGE STOK NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolgeKayit.GuvenlikYazilimi))
            {
                return "Lütfen GÜVENKİK YAZILIMI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolgeKayit.KesifGozetlemeTuru))
            {
                return "Lütfen KEŞİF GÖZETLEME TÜRÜ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolgeKayit.YasamAlani))
            {
                return "Lütfen YAŞAM ALANI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolgeKayit.Tabur))
            {
                return "Lütfen BAĞLI OLDUĞU TABUR Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolgeKayit.Tugay))
            {
                return "Lütfen BAĞLI OLDUĞU TUGAY Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolgeKayit.Il))
            {
                return "Lütfen İL Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolgeKayit.Ilce))
            {
                return "Lütfen İLÇE Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolgeKayit.Ilce))
            {
                return "Lütfen İLÇE Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolgeKayit.BirlikAdresi))
            {
                return "Lütfen BİRLİK ADRESİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolgeKayit.BolgeSorumlusu))
            {
                return "Lütfen BÖLGE SORUMLUSU Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolgeKayit.Depo))
            {
                return "Lütfen DEPO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolgeKayit.PypNo))
            {
                return "Lütfen PYP NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolgeKayit.Proje))
            {
                return "Lütfen PROJE Bilgisini doldurunuz.";
            }
            return "";
        }
    }
}
