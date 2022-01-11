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

        public string Delete(int id)
        {
            try
            {
                if (id < 0)
                {
                    return "Lütfen Bir Kayit Seçiniz.";
                }
                return stokGirisCikisDal.Delete(id);
            }
            catch (Exception)
            {

                throw;
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
