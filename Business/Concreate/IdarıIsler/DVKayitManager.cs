using DataAccess.Abstract;
using DataAccess.Concreate.IdariIsler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.IdarıIsler
{
    public class DVKayitManager //: IRepository<DuranVarlikKayit>
    {
        static DVKayitManager kayitManager;
        DVKayitDal kayitDal;

        private DVKayitManager()
        {
            kayitDal = DVKayitDal.GetInstance();
        }
        public string Add(DuranVarlikKayit entity)
        {
            try
            {
                /*controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }*/
                return kayitDal.Add(entity);
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
                return kayitDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DuranVarlikKayit Get(string dvEtiketNo)
        {
            try
            {
                return kayitDal.Get(dvEtiketNo);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DuranVarlikKayit DvSonNo(string dvSahibi)
        {
            try
            {
                return kayitDal.DvSonNo(dvSahibi);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DuranVarlikKayit> GetList()
        {
            try
            {
                return kayitDal.GetList();
            }
            catch (Exception)
            {
                return new List<DuranVarlikKayit>();
            }
        }

        public string Update(DuranVarlikKayit entity,int id)
        {
            try
            {
                return kayitDal.Update(entity, id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        string Complate(DuranVarlikKayit duranVarlik)
        {
            if (string.IsNullOrEmpty(duranVarlik.DvSahibi))
            {
                return "Lütfen DV SAHİBİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(duranVarlik.ButceKodu))
            {
                return "Lütfen BÜTÇE KODU Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(duranVarlik.DvEtiketNo))
            {
                return "Lütfen DV ETİKET NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(duranVarlik.DvGrubu))
            {
                return "Lütfen DV GRUBU Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(duranVarlik.DvTanim))
            {
                return "Lütfen DV TANIMI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(duranVarlik.Miktar.ToString()))
            {
                return "Lütfen MİKTAR Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(duranVarlik.Marka))
            {
                return "Lütfen MARKA Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(duranVarlik.Model))
            {
                return "Lütfen MODEL Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(duranVarlik.SeriNo))
            {
                return "Lütfen SERİ NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(duranVarlik.KalGerek))
            {
                return "Lütfen KALİBRASYON GEREKİP GEREKMEDİĞİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(duranVarlik.SatNo))
            {
                return "Lütfen SAT NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(duranVarlik.SaticiFirma))
            {
                return "Lütfen SATICI FİRMA Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(duranVarlik.Tarih.ToString()))
            {
                return "Lütfen FATURA TARİHİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(duranVarlik.FaturaNo))
            {
                return "Lütfen FATURA NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(duranVarlik.Fiyat.ToString()))
            {
                return "Lütfen FİYAT Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(duranVarlik.Aciklama))
            {
                return "Lütfen AÇIKLAMA Bilgisini Giriniz.";
            }
            return "";
        }
        public static DVKayitManager GetInstance()
        {
            if (kayitManager == null)
            {
                kayitManager = new DVKayitManager();
            }
            return kayitManager;
        }
    }
}
