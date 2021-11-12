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
    public class SatNoManager
    {
        static SatNoManager satNoManager;
        SatNoDal satNoDal;
        string controlText;

        private SatNoManager()
        {
            satNoDal = SatNoDal.GetInstance();
        }

        public int Add(SatNo entity)
        {
            
            try
            {
                /*controlText = IsSatNoComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }*/
                return satNoDal.Add(entity);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SatNo Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SatNo> GetList(string siparisno = "")
        {
            try
            {
                return satNoDal.GetList(siparisno);
            }
            catch
            {
                return new List<SatNo>();
            }
        }

        public string Update(SatNo entity)
        {
            throw new NotImplementedException();
        }

        string IsSatNoComplete(SatNo satNo)
        {
            if (string.IsNullOrEmpty(satNo.Siparisno))
            {
                return "Siparis Numarasi Algılanamadı";
            }
            return "";
        }

        public static SatNoManager GetInstance()
        {
            if (satNoManager == null)
            {
                satNoManager = new SatNoManager();
            }
            return satNoManager;
        }

        public object[] Deneme(string siparisno)
        {
            try
            {
                return satNoDal.Deneme(siparisno.Trim());
            }
            catch
            {
                return null;
            }
        }
    }
}
