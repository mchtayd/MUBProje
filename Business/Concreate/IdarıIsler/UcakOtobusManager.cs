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
    public class UcakOtobusManager //: IRepository<UcakOtobus>
    {
        static UcakOtobusManager ucakOtobusManager;
        UcakOtobusDal ucakOtobusDal;
        string controlText;
        private UcakOtobusManager()
        {
            ucakOtobusDal = UcakOtobusDal.GetInstance();
        }
        public string Add(UcakOtobus entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return ucakOtobusDal.Add(entity);
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
                return ucakOtobusDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public UcakOtobus Get(int isakisno)
        {
            try
            {
                return ucakOtobusDal.Get(isakisno);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<UcakOtobus> GetList(int isAkisNo=0)
        {
            try
            {
                return ucakOtobusDal.GetList(isAkisNo);
            }
            catch (Exception)
            {
                return new List<UcakOtobus>();
            }
        }
        public string IsAkisNoDuzelt(int id, int isAkisNo, string dosyaYolu)
        {
            try
            {
                return ucakOtobusDal.IsAkisNoDuzelt(id, isAkisNo, dosyaYolu);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<UcakOtobus> OnayList(string islemadimi)
        {
            try
            {
                return ucakOtobusDal.OnayList(islemadimi);
            }
            catch (Exception)
            {
                return new List<UcakOtobus>();
            }
        }
        public string OnayGuncelle(UcakOtobus entity,int id)
        {
            try
            {
                return ucakOtobusDal.OnayGuncelle(entity,id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Update(UcakOtobus entity,int id)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return ucakOtobusDal.Update(entity,id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complate(UcakOtobus ucakOtobus)
        {
            if (string.IsNullOrEmpty(ucakOtobus.Talepturu))
            {
                return "Lütfen TALEP TÜRÜ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Gorevformno))
            {
                return "Lütfen GÖREV FORM NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Izinformno))
            {
                return "Lütfen İZİN FORM NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Siparisno))
            {
                return "Lütfen SİPARİŞ NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Adsoyad))
            {
                return "Lütfen ADI SOYADI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Masrafyerino))
            {
                return "Lütfen MASRAF YERİ NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Masrafyeri))
            {
                return "Lütfen BÖLÜMÜ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Tc))
            {
                return "Lütfen TC KİMLİK NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Hes))
            {
                return "Lütfen HES KODU Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Email))
            {
                return "Lütfen E-MAİL Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Kisakod))
            {
                return "Lütfen ŞİRKET NO/KISAKOD Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Gorevi))
            {
                return "Lütfen GÖREVİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Gidisfirma))
            {
                return "Lütfen GİDİŞ SEYAHAT FİRMASI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Gidistarihi.ToString()))
            {
                return "Lütfen GİDİŞ SEYAHAT TARİHİ/SAATİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Gidisnereden))
            {
                return "Lütfen GİDİŞ NEREDEN Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Gidisnereye))
            {
                return "Lütfen GİDİŞ NEREYE Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Donusfirma))
            {
                return "Lütfen DÖNÜŞ SEYAHAT FİRMA Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Donustarihi.ToString()))
            {
                return "Lütfen DÖNÜŞ TARİHİ/SAATİ Bilgilerini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Donusnereden))
            {
                return "Lütfen DÖNÜŞ NEREDEN Bilgilerini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Donusnereye))
            {
                return "Lütfen DÖNÜŞ NEREYE Bilgilerini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.Butcekodu))
            {
                return "Lütfen BÜTÇE KODU/KALEMİ Bilgilerini Giriniz.";
            }
            if (string.IsNullOrEmpty(ucakOtobus.ToplamMaliyet.ToString()))
            {
                return "Lütfen TOPLAM MALİYET Bilgilerini Giriniz.";
            }
            return "";
        }
        public static UcakOtobusManager GetInstance()
        {
            if (ucakOtobusManager == null)
            {
                ucakOtobusManager = new UcakOtobusManager();
            }
            return ucakOtobusManager;
        }
    }
}
