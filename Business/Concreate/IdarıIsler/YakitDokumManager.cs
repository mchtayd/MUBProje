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
    public class YakitDokumManager //: IRepository<YakitDokum>
    {
        static YakitDokumManager yakitDokumManager;
        YakitDokumDal yakitDokumDal;
        string controlText;

        private YakitDokumManager()
        {
            yakitDokumDal = YakitDokumDal.GetInstance();
        }
        public string Add(YakitDokum entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return yakitDokumDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message; 
            }
        }
        public string AnaAdd(YakitDokum entity)
        {
            try
            {
                return yakitDokumDal.AnaAdd(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string AddTasitTanima(YakitDokum entity)
        {
            try
            {
                return yakitDokumDal.AddTasitTanima(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string AnaAddTasit(YakitDokum entity)
        {
            try
            {
                return yakitDokumDal.AnaAddTasit(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string AddTasit(YakitDokum entity)
        {
            try
            {
                return yakitDokumDal.AddTasit(entity);
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
                return yakitDokumDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        public YakitDokum Get(string siparisNo)
        {
            try
            {
                return yakitDokumDal.Get(siparisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<YakitDokum> YakitKontrolTT(string donem)
        {
            try
            {
                return yakitDokumDal.YakitKontrolTT(donem);
            }
            catch (Exception)
            {
                return new List<YakitDokum>();
            }
        }
        public List<YakitDokum> YakitKontrolAnlasmali(string donem)
        {
            try
            {
                return yakitDokumDal.YakitKontrolAnlasmali(donem);
            }
            catch (Exception)
            {
                return new List<YakitDokum>();
            }
        }

        public List<YakitDokum> GetList(string siparisNo)
        {
            try
            {
                return yakitDokumDal.GetList(siparisNo);
            }
            catch (Exception)
            {
                return new List<YakitDokum>();
            }
        }
        
        public List<YakitDokum> GetListAna(string alimTuru)
        {
            try
            {
                return yakitDokumDal.GetListAna(alimTuru);
            }
            catch (Exception)
            {
                return new List<YakitDokum>();
            }
        }
        public List<YakitDokum> GetListTT()
        {
            try
            {
                return yakitDokumDal.GetListTT();
            }
            catch (Exception)
            {
                return new List<YakitDokum>();
            }
        }

        public string Update(YakitDokum entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return yakitDokumDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complate(YakitDokum yakitDokum)
        {
            if (string.IsNullOrEmpty(yakitDokum.Plaka))
            {
                return "Lütfen ARAÇ PLAKASI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakitDokum.Firma))
            {
                return "Lütfen FİRMA Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakitDokum.Donem))
            {
                return "Lütfen DÖNEM Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakitDokum.DefterNo))
            {
                return "Lütfen YAKIT ALIM DEFTER NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakitDokum.SiraNo))
            {
                return "Lütfen YAKIT ALIM SIRA NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakitDokum.FisNo))
            {
                return "Lütfen FİŞ NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakitDokum.Personel))
            {
                return "Lütfen PEROSNEL Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakitDokum.LitreFiyati.ToString()))
            {
                return "Lütfen LİTRE FİYATI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakitDokum.ToplamTutar.ToString()))
            {
                return "Lütfen TOPLAM FİYAT Bilgisini Giriniz.";
            }
            return "";
        }
        public static YakitDokumManager GetInstance()
        {
            if (yakitDokumManager == null)
            {
                yakitDokumManager = new YakitDokumManager();
            }
            return yakitDokumManager;
        }
    }
}
