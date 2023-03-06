using DataAccess.Abstract;
using DataAccess.Concreate.STS;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.STS
{
    public class SatIslemAdimlariManager 
    {
        static SatIslemAdimlariManager satIslemAdimlariManager;
        SatIslemAdimlariDal satIslemAdimlariDal;
        string controlText;
        private SatIslemAdimlariManager()
        {
            satIslemAdimlariDal = SatIslemAdimlariDal.GetInstance();
        }

        public string Add(SatIslemAdimlari entity)
        {
            try
            {
                controlText = IsSatIslemAdimlari(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return satIslemAdimlariDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SatIslemAdimlari Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SatIslemAdimlari> GetList(string siparisNo = "")
        {
            try
            {
                return satIslemAdimlariDal.GetList(siparisNo);
            }
            catch
            {
                return new List<SatIslemAdimlari>();
            }
        }

        public string Update(SatIslemAdimlari entity)
        {
            throw new NotImplementedException();
        }
        string IsSatIslemAdimlari(SatIslemAdimlari satIslem)
        {
            if (string.IsNullOrEmpty(satIslem.Siparisno))
            {
                return "Siparis Numarasi Algılanamadı";
            }
            return "";
        }
        public static SatIslemAdimlariManager GetInstance()
        {
            if (satIslemAdimlariManager == null)
            {
                satIslemAdimlariManager = new SatIslemAdimlariManager();
            }
            return satIslemAdimlariManager;
        }
    }
}
