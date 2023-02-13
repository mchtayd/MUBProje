using DataAccess.Abstract;
using DataAccess.Concreate;
using DataAccess.Concreate.Gecici_Kabul_Ambar;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Gecici_Kabul_Ambar
{
    public class StokGirisCikisManager //  :IRepository<StokGirisCıkıs>
    {

        static StokGirisCikisManager stokGirisCikisManager;
        StokGirisCikisDal stokGirisCikisDal;
        string controlText;

        private StokGirisCikisManager()
        {
            stokGirisCikisDal = StokGirisCikisDal.GetInstance();
        }
        public string Add(StokGirisCıkıs entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return stokGirisCikisDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(string stokNo, string seriNo, string lotNo)
        {
            try
            {
                
                return stokGirisCikisDal.Delete(stokNo, seriNo, lotNo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string DepoBirimFiyat(double birimFiyat, string stokNo)
        {
            try
            {
               
                return stokGirisCikisDal.DepoBirimFiyat(birimFiyat,stokNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public double DepoBirimFiyat(string stokNo)
        {
            try
            {
                return stokGirisCikisDal.DepoBirimFiyat(stokNo);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public StokGirisCıkıs DepoRafBul(string stokNo,string depoNo)
        {
            try
            {
                return stokGirisCikisDal.DepoRafBul(stokNo, depoNo);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public StokGirisCıkıs BildirimdenDepoya(string stokNo, string seriNo,string lotNo,string revizyon,string dusulenDepoAbf)
        {
            try
            {
                return stokGirisCikisDal.BildirimdenDepoya(stokNo, seriNo, lotNo, revizyon, dusulenDepoAbf);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public StokGirisCıkıs Get(string stokNo, string depoNo, string seriNo, string lotNo, string revizyon)
        {
            try
            {
                return stokGirisCikisDal.Get(stokNo,depoNo,seriNo,lotNo,revizyon);
            }
            catch (Exception)
            {

                return null;
            }
        }
        
        public StokGirisCıkıs StokGor(string stokNo)
        {
            try
            {
                return stokGirisCikisDal.StokGor(stokNo);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<StokGirisCıkıs> GetList(string stokNo="",string seriNo="")
        {
            try
            {
                return stokGirisCikisDal.GetList(stokNo, seriNo);
            }
            catch (Exception)
            {
                return new List<StokGirisCıkıs>();
            }
        }
        public List<StokGirisCıkıs> GetListEdit(string stokNo, string seriNo, string lotNo)
        {
            try
            {
                return stokGirisCikisDal.GetListEdit(stokNo, seriNo, lotNo);
            }
            catch (Exception)
            {
                return new List<StokGirisCıkıs>();
            }
        }
        public List<StokGirisCıkıs> AtolyeDepoHareketleri(string abfSiparisNo)
        {
            try
            {
                return stokGirisCikisDal.AtolyeDepoHareketleri(abfSiparisNo);
            }
            catch (Exception)
            {
                return new List<StokGirisCıkıs>();
            }
        }

        public string Update(StokGirisCıkıs entity,int id)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return stokGirisCikisDal.Update(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateEdit(StokGirisCıkıs entity)
        {
            try
            {
                return stokGirisCikisDal.UpdateEdit(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static StokGirisCikisManager GetInstance()
        {
            if (stokGirisCikisManager == null)
            {
                stokGirisCikisManager = new StokGirisCikisManager();
            }
            return stokGirisCikisManager;
        }
        string Complete(StokGirisCıkıs stokGirisCıkıs)
        {
            /*if (string.IsNullOrEmpty(stokGirisCıkıs.Islemturu))
            {
                return "Lütfen İŞLEM TÜRÜ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(stokGirisCıkıs.Stokno))
            {
                return "Lütfen STOK NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(stokGirisCıkıs.Tanim))
            {
                return "Lütfen TANIM Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(stokGirisCıkıs.Miktar.ToString()))
            {
                return "Lütfen MİKTAR Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(stokGirisCıkıs.Birim))
            {
                return "Lütfen BİRİM Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(stokGirisCıkıs.Istenentarih.ToString()))
            {
                return "Lütfen İŞLEM TARİHİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(stokGirisCıkıs.Depono))
            {
                return "Lütfen DEPO NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(stokGirisCıkıs.Depoadresi))
            {
                return "Lütfen DEPO ADRESİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(stokGirisCıkıs.Malzemeyeri))
            {
                return "Lütfen MALZEME YERİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(stokGirisCıkıs.Aciklama))
            {
                return "Lütfen AÇIKLAMA Bilgisini doldurunuz.";
            }*/
            return "";
        }
    }
}
