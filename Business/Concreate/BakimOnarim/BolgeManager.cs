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
    public class BolgeManager //: IRepository<Bolge>
    {
        static BolgeManager bolgeManager;
        BolgeDal bolgeDal;
        string controlText;

        private BolgeManager()
        {
            bolgeDal = BolgeDal.GetInstance();
        }
        public string Add(Bolge entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return bolgeDal.Add(entity);
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
                return bolgeDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Bolge Get(int id)
        {
            try
            {
                return bolgeDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Bolge> GetList()
        {
            try
            {
                return bolgeDal.GetList();
            }
            catch (Exception)
            {
                return new List<Bolge>();
            }
        }

        public string Update(Bolge entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return bolgeDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(Bolge bolge)
        {
            if (string.IsNullOrEmpty(bolge.BolgeAdi))
            {
                return "Lütfen BÖLGE ADI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolge.IlgiliPersonel))
            {
                return "Lütfen İLGİLİ PERSONEL Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolge.Telefon))
            {
                return "Lütfen TELEFON Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolge.Il))
            {
                return "Lütfen İL Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolge.Ilce))
            {
                return "Lütfen İLÇE Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolge.BirlikAdresi))
            {
                return "Lütfen BİRLİK ADRESİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolge.Proje))
            {
                return "Lütfen PROJE Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolge.PypNo))
            {
                return "Lütfen PYP NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolge.SorumluSicil))
            {
                return "Lütfen BÖLGE SORUMLUSU SİCİL NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolge.SsPersonel))
            {
                return "Lütfen SORUMLU PERSONEL ADI SOYADI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolge.SspGorev))
            {
                return "Lütfen SORUMLU PERSONEL GÖREVİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(bolge.SsRutbe))
            {
                return "Lütfen SORUMLU PERSONEL RÜTBESİ Bilgisini doldurunuz.";
            }
            return "";
        }
        public static BolgeManager GetInstance()
        {
            if (bolgeManager == null)
            {
                bolgeManager = new BolgeManager();
            }
            return bolgeManager;
        }
    }
}
