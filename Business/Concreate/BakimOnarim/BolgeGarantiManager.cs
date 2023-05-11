using DataAccess.Abstract;
using DataAccess.Concreate.BakimOnarim;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.BakimOnarim
{
    public class BolgeGarantiManager //: IRepository<BolgeGaranti>
    {
        static BolgeGarantiManager bolgeGarantiManager;
        BolgeGarantiDal bolgeGarantiDal;

        private BolgeGarantiManager()
        {
            bolgeGarantiDal = BolgeGarantiDal.GetInstance();
        }

        public static BolgeGarantiManager GetInstance()
        {
            if (bolgeGarantiManager == null)
            {
                bolgeGarantiManager = new BolgeGarantiManager();
            }
            return bolgeGarantiManager;
        }

        public string Add(BolgeGaranti entity)
        {
            try
            {
                return bolgeGarantiDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(string siparisNo)
        {
            try
            {
                return bolgeGarantiDal.Delete(siparisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public BolgeGaranti Get(string siparisNo)
        {
            try
            {
                return bolgeGarantiDal.Get(siparisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<BolgeGaranti> GetList(string siparisNo)
        {
            try
            {
                return bolgeGarantiDal.GetList(siparisNo);
            }
            catch (Exception)
            {
                return new List<BolgeGaranti>();
            }
        }
        public List<BolgeGaranti> GetListTumu(string siparisNo)
        {
            try
            {
                return bolgeGarantiDal.GetListTumu(siparisNo);
            }
            catch (Exception)
            {
                return new List<BolgeGaranti>();
            }
        }

        public string Update(BolgeGaranti entity)
        {
            try
            {
                return bolgeGarantiDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
