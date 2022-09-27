using DataAccess.Abstract;
using DataAccess.Concreate.Gecici_Kabul_Ambar;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Gecici_Kabul_Ambar
{
    public class MalzemeManager //: IRepository<Malzeme>
    {
        static MalzemeManager malzemeManager;
        MalzemeDal malzemeDal;
        string controlText;

        private MalzemeManager()
        {
            malzemeDal = MalzemeDal.GetInstance();
        }
        public string Add(Malzeme entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return malzemeDal.Add(entity);
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
                    return "Lütfen Öncelikle Geçerli Bir Malzeme Seçiniz!";
                }
                return malzemeDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Malzeme Get(string stokNo)
        {
            try
            {
                return malzemeDal.Get(stokNo);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Malzeme Get2(int id)
        {
            try
            {
                return malzemeDal.Get2(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Malzeme MalzemeSonStok()
        {
            try
            {
                return malzemeDal.MalzemeSonStok();
            }
            catch (Exception)
            {

                return null;
            }
        }
        public string UstTakimEkle(Malzeme entity)
        {
            try
            {
                return malzemeDal.UstTakimEkle(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string MalzemeTanimDuzelt(string tanim, int id)
        {
            try
            {
                return malzemeDal.MalzemeTanimDuzelt(tanim, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Malzeme> GetList()
        {
            try
            {
                return malzemeDal.GetList();
            }
            catch (Exception)
            {

                return new List<Malzeme>();
            }
        }
        public List<Malzeme> MalzemeGetList(string stokNo)
        {
            try
            {
                return malzemeDal.MalzemeGetList(stokNo);
            }
            catch (Exception)
            {

                return new List<Malzeme>();
            }
        }
        public List<Malzeme> MalzemeUstTakimList(int benzersizId)
        {
            try
            {
                return malzemeDal.MalzemeUstTakimList(benzersizId);
            }
            catch (Exception)
            {

                return new List<Malzeme>();
            }
        }

        public string Update(Malzeme entity)
        {
            try
            {
                return malzemeDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static MalzemeManager GetInstance()
        {
            if (malzemeManager == null)
            {
                malzemeManager = new MalzemeManager();
            }
            return malzemeManager;
        }
        string Complete(Malzeme malzeme)
        {
            if (string.IsNullOrEmpty(malzeme.StokNo))
            {
                return "Lütfen MALZEME STOK NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzeme.Tanim))
            {
                return "Lütfen MALZEME TANIM Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzeme.Birim))
            {
                return "Lütfen MALZEME BİRİM Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzeme.TedarikciFirma))
            {
                return "Lütfen TEDARİKÇİ FİRMA Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzeme.OnarimDurumu))
            {
                return "Lütfen MALZEME ONARIM DURUMU Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzeme.OnarimYeri))
            {
                return "Lütfen MALZEME ONARIM YERİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzeme.TedarikTuru))
            {
                return "Lütfen TEDARİK TÜRÜ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzeme.ParcaSinifi))
            {
                return "Lütfen PARÇA SINIFI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzeme.TakipDurumu))
            {
                return "Lütfen MALZEME TAKİP DURUMU Bilgisini doldurunuz.";
            }
            return "";
        }
    }
}
