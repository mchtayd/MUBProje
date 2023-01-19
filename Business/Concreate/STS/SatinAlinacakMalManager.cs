using DataAccess;
using DataAccess.Abstract;
using DataAccess.Concreate;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class SatinAlinacakMalManager //: IRepository<SatinAlinacakMalzemeler>
    {
        static SatinAlinacakMalManager satinAlinacakMalManager;
        SatinAlinacakMalDal satinAlinacakMalDal;
        string controlText;

        private SatinAlinacakMalManager()
        {
            satinAlinacakMalDal = SatinAlinacakMalDal.GetInstance();
        }

        public string Add(SatinAlinacakMalzemeler entity, string siparisNo)
        {
            try
            {
                controlText = IsSatMalComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return satinAlinacakMalDal.Add(entity, siparisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string SatDurumRed(string siparisno)
        {
            try
            {
                return satinAlinacakMalDal.SatDurumRed(siparisno);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SatDurumOnay(string siparisno)
        {
            try
            {
                return satinAlinacakMalDal.SatDurumOnay(siparisno);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DevamEdenSatGuncelle(SatinAlinacakMalzemeler entity)
        {
            try
            {
                return satinAlinacakMalDal.DevamEdenSatGuncelle(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Delete(string siparisno)
        {
            try
            {
                return satinAlinacakMalDal.Delete(siparisno);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SatinAlinacakMalzemeler Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SatinAlinacakMalzemeler> GetList(string siparisNo = "")
        {
            try
            {
                return satinAlinacakMalDal.GetList(siparisNo);
            }
            catch
            {
                return new List<SatinAlinacakMalzemeler>();
            }
        }
        public List<SatinAlinacakMalzemeler> GetListOts(string abfNo)
        {
            try
            {
                return satinAlinacakMalDal.GetListOts(abfNo);
            }
            catch
            {
                return new List<SatinAlinacakMalzemeler>();
            }
        }

        public string Update(SatinAlinacakMalzemeler entity)
        {
            throw new NotImplementedException();
        }
        public object[] Malzemeler(string siparisNo)
        {
            try
            {
                return satinAlinacakMalDal.Malzemeler(siparisNo);
            }
            catch
            {
                return null;
            }
        }
        public static SatinAlinacakMalManager GetInstance()
        {
            if (satinAlinacakMalManager == null)
            {
                satinAlinacakMalManager = new SatinAlinacakMalManager();
            }
            return satinAlinacakMalManager;
        }

        string IsSatMalComplete(SatinAlinacakMalzemeler satinAlinacak)
        {
            if (string.IsNullOrEmpty(satinAlinacak.Stn1))
            {
                return "Lütfen Stok Numarası Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(satinAlinacak.T1))
            {
                return "Lütfen Tanım Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(satinAlinacak.M1.ToString()))
            {
                return "Lütfen Miktar Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(satinAlinacak.B1))
            {
                return "Lütfen Birim Kısmını doldurunuz.";
            }
            return "";
        }
    }
}
