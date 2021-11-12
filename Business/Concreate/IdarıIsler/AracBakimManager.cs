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
    public class AracBakimManager //: IRepository<AracBakim>
    {
        static AracBakimManager aracBakimManager;
        AracBakimDal aracBakimDal;
        string controlText;

        private AracBakimManager()
        {
            aracBakimDal = AracBakimDal.GetInstance();
        }
        public string Add(AracBakim entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return aracBakimDal.Add(entity);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string GecmisKayit(AracBakim entity)
        {
            try
            {
                /*controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }*/
                return aracBakimDal.GecmisKayit(entity);

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
                return aracBakimDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public AracBakim Get(int isAkisNo)
        {
            try
            {
                return aracBakimDal.Get(isAkisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AracBakim> GetList(int isAkisNo=0)
        {
            try
            {
                return aracBakimDal.GetList(isAkisNo);
            }
            catch (Exception)
            {
                return new List<AracBakim>();
            }
        }
        public List<AracBakim> DevamDevamsizlik()
        {
            try
            {
                return aracBakimDal.DevamDevamsizlik();
            }
            catch (Exception)
            {
                return new List<AracBakim>();
            }
        }
        public List<AracBakim> AracBakimKayitListKapatilmis()
        {
            try
            {
                return aracBakimDal.AracBakimKayitListKapatilmis();
            }
            catch (Exception)
            {
                return new List<AracBakim>();
            }
        }

        public string Update(AracBakim entity)
        {
            try
            {
                return aracBakimDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Kapat(AracBakim entity,int isAkisNo)
        {
            try
            {
                return aracBakimDal.Kapat(entity,isAkisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complate(AracBakim arac)
        {
            if (string.IsNullOrEmpty(arac.Plaka))
            {
                return "Lütfen ARAÇ PLAKASI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.Km.ToString()))
            {
                return "Lütfen ARAÇ KİLOMETRESİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.BakimNedeni.ToString()))
            {
                return "Lütfen BAKIM NEDENİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(arac.ArizaAciklamasi))
            {
                return "Lütfen ARIZA AÇIKLAMASI Bilgisini Giriniz.";
            }
            
            return "";
        }
        public static AracBakimManager GetInstance()
        {
            if (aracBakimManager == null)
            {
                aracBakimManager = new AracBakimManager();
            }
            return aracBakimManager;
        }
    }
}
