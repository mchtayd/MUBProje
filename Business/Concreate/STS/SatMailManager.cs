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
    public class SatMailManager //: IRepository<SatMail>
    {
        static SatMailManager satMailManager;
        SatMailDal satMailDal;

        private SatMailManager()
        {
            satMailDal = SatMailDal.GetInstance();
        }
        public string Add(SatMail entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SatMail Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SatMail> GetList()
        {
            try
            {
                return satMailDal.GetList();
            }
            catch (Exception)
            {
                return new List<SatMail>();
            }
        }

        public string Update(SatMail entity)
        {
            throw new NotImplementedException();
        }
        public static SatMailManager GetInstance()
        {
            if (satMailManager == null)
            {
                satMailManager = new SatMailManager();
            }
            return satMailManager;
        }
    }
}
