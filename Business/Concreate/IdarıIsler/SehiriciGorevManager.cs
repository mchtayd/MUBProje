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
    public class SehiriciGorevManager // : IRepository<SehiriciGorev>
    {
        static SehiriciGorevManager sehiriciGorevManager;
        SehiriciGorevDal sehiriciGorevDal;
        string controlText;

        private SehiriciGorevManager()
        {
            sehiriciGorevDal = SehiriciGorevDal.GetInstance();
        }
        public string Add(SehiriciGorev entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return sehiriciGorevDal.Add(entity);

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
                if (id==0)
                {
                    return "Lütfen Geçerli Bir İŞ AKIŞ NO giriniz.";
                }
                return sehiriciGorevDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SehiriciGorev Get(int isakisno)
        {
            try
            {
                return sehiriciGorevDal.Get(isakisno);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SehiriciGorev> GetList(int isakisno=0)
        {
            try
            {
                return sehiriciGorevDal.GetList(isakisno);
            }
            catch (Exception)
            {
                return new List<SehiriciGorev>();
            }
        }
        public List<SehiriciGorev> PersonelOnay(int personelid, string islemadimi = "")
        {
            try
            {
                return sehiriciGorevDal.PersonelOnay(islemadimi,personelid);
            }
            catch (Exception)
            {
                return new List<SehiriciGorev>();
            }
        }
        public List<SehiriciGorev> AmirOnay(int loginid, string islemadimi = "")
        {
            try
            {
                return sehiriciGorevDal.AmirOnay(islemadimi, loginid);
            }
            catch (Exception)
            {
                return new List<SehiriciGorev>();
            }
        }
        public List<SehiriciGorev> DevamEdenler(int id=0)
        {
            try
            {
                return sehiriciGorevDal.DevamEdenler(id);
            }
            catch (Exception)
            {
                return new List<SehiriciGorev>();
            }
        }
        public List<SehiriciGorev> DevamDevamsizlik(string toplamsure)
        {
            try
            {
                return sehiriciGorevDal.DevamDevamsizlik(toplamsure);
            }
            catch (Exception)
            {
                return new List<SehiriciGorev>();
            }
        }

        public string Update(SehiriciGorev entity, int isakisno)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return sehiriciGorevDal.Update(entity,isakisno);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string GorevOnay(SehiriciGorev entity, int id)
        {
            try
            {
                return sehiriciGorevDal.GorevOnay(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string GorevTamamla(SehiriciGorev entity, int isakisno)
        {
            try
            {
                return sehiriciGorevDal.GorevTamamla(entity, isakisno);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complate(SehiriciGorev sehirici)
        {
            if (string.IsNullOrEmpty(sehirici.Gidilecekyer))
            {
                return "Lütfen GİDİLECEK YER bilgilerini Giriniz.";
            }
            if (string.IsNullOrEmpty(sehirici.Proje))
            {
                return "Lütfen PROJE Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(sehirici.Gorevinkonusu))
            {
                return "Lütfen GÖREVİN KONUSU Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(sehirici.Siparisno))
            {
                return "Lütfen SİPARİŞ NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(sehirici.Adsoyad))
            {
                return "Lütfen AD SOYAD Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(sehirici.Masrafyerno))
            {
                return "Lütfen MASRAF YERİ NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(sehirici.Masrafyeri))
            {
                return "Lütfen MASRAF YERİ/BÖLÜM Bilgisini Giriniz.";
            }
            return "";
        }
        public static SehiriciGorevManager GetInstance()
        {
            if (sehiriciGorevManager == null)
            {
                sehiriciGorevManager = new SehiriciGorevManager();
            }
            return sehiriciGorevManager;
        }
    }
}
