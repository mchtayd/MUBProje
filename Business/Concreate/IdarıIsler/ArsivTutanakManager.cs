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
    public class ArsivTutanakManager  //: IRepository<ArsivTutanak>
    {
        static ArsivTutanakManager arsivTutanakManager;
        ArsivTutanakDal arsivTutanakDal;
        string controlText;

        private ArsivTutanakManager()
        {
            arsivTutanakDal = ArsivTutanakDal.GetInstance();
        }
        public string Add(ArsivTutanak entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return arsivTutanakDal.Add(entity);

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
                return arsivTutanakDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ArsivTutanak Get(int isAkisNo)
        {
            try
            {
                return arsivTutanakDal.Get(isAkisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ArsivTutanak> GetList()
        {
            try
            {
                return arsivTutanakDal.GetList();
            }
            catch (Exception)
            {
                return new List<ArsivTutanak>();
            }
        }

        public string Update(ArsivTutanak entity)
        {
            try
            {
                return arsivTutanakDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complate(ArsivTutanak arsivTutanak)
        {
            if (string.IsNullOrEmpty(arsivTutanak.DosyaTuru))
            {
                return "Lütfen DOSYA TÜRÜ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arsivTutanak.BolgeAdi))
            {
                return "Lütfen BÖLGE ADI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arsivTutanak.SistemCihaz))
            {
                return "Lütfen SİSTEM CİHAZ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arsivTutanak.DosyaIcerigi))
            {
                return "Lütfen DOSYA İÇERİĞİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arsivTutanak.BulunduguLok))
            {
                return "Lütfen BULUNDUĞU LOKASYON Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arsivTutanak.KlasorNo))
            {
                return "Lütfen KLASÖR NUMARASI Bilgisini Giriniz.";
            }
            return "";
        }
        public static ArsivTutanakManager GetInstance()
        {
            if (arsivTutanakManager == null)
            {
                arsivTutanakManager = new ArsivTutanakManager();
            }
            return arsivTutanakManager;
        }
    }
}
