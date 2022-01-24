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
    public class YakitManager //: IRepository<Yakit>
    {
        static YakitManager yakitManager;
        YakitDal yakitDal;

        private YakitManager()
        {
            yakitDal = YakitDal.GetInstance();
        }
        public string Add(Yakit entity)
        {
            try
            {
                /*controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }*/
                return yakitDal.Add(entity);
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
                return yakitDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Yakit Get(int isakisno)
        {
            try
            {
                return yakitDal.Get(isakisno);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Yakit> GetList()
        {
            try
            {
                return yakitDal.GetList();
            }
            catch (Exception)
            {
                return new List<Yakit>();
            }
        }
        public List<Yakit> YakitKontrolBeyan(string donem)
        {
            try
            {
                return yakitDal.YakitKontrolBeyan(donem);
            }
            catch (Exception)
            {
                return new List<Yakit>();
            }
        }

        public string Update(Yakit entity,int id)
        {
            try
            {
                return yakitDal.Update(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complate(Yakit yakit)
        {
            if (string.IsNullOrEmpty(yakit.Plaka))
            {
                return "Lütfen ARAÇ PLAKA Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakit.YakitAlinanDonem))
            {
                return "Lütfen YAKIT ALINAN DÖNEM Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakit.Tarih.ToString()))
            {
                return "Lütfen YAKIT ALINAN TARİH Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakit.Km.ToString()))
            {
                return "Lütfen YAKIT ALINAN KİLOMETRE Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakit.YakitTuru))
            {
                return "Lütfen YAKIT TÜRÜ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakit.AlinanLitre.ToString()))
            {
                return "Lütfen ALINAN LİTRE Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakit.ToplamFiyat.ToString()))
            {
                return "Lütfen TOPLAM FİYAT Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakit.AlimTuru))
            {
                return "Lütfen ALIM TÜRÜ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakit.Personel))
            {
                return "Lütfen YAKIT ALAN PERSONEL Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakit.AlinanFirma))
            {
                return "Lütfen ALINAN FİRMA Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakit.BelgeTuru))
            {
                return "Lütfen BELGE TÜRÜ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(yakit.BelgeNumarasi))
            {
                return "Lütfen BELGE NUMARASI Bilgisini Giriniz.";
            }
            return "";
        }
        public static YakitManager GetInstance()
        {
            if (yakitManager == null)
            {
                yakitManager = new YakitManager();
            }
            return yakitManager;
        }
    }
}
