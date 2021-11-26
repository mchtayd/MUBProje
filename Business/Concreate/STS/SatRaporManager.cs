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
    public class SatRaporManager // : IRepository<SatRapor>
    {
        static SatRaporManager satRaporManager;
        SatRaporDal satRaporDal;

        private SatRaporManager()
        {
            satRaporDal = SatRaporDal.GetInstance();
        }
        public string Add(SatRapor entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SatRapor Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SatRapor> GetList(string firma,string donem)
        {
            try
            {
                return satRaporDal.GetList(firma, donem);
            }
            catch (Exception)
            {
                return new List<SatRapor>();
            }
        }
        public List<SatRapor> GetListBasaran(string firma, string donem)
        {
            try
            {
                return satRaporDal.GetListBasaran(firma, donem);
            }
            catch (Exception)
            {
                return new List<SatRapor>();
            }
        }

        public string Update(SatRapor entity)
        {
            throw new NotImplementedException();
        }
        public static SatRaporManager GetInstance()
        {
            if (satRaporManager == null)
            {
                satRaporManager = new SatRaporManager();
            }
            return satRaporManager;
        }
    }
}
