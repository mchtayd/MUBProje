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
    public class BolgeEnvanterManager //: IRepository<BolgeEnvanter>
    {
        static BolgeEnvanterManager bolgeEnvanterManager;
        BolgeEnvanterDal bolgeEnvanterDal;

        private BolgeEnvanterManager()
        {
            bolgeEnvanterDal = BolgeEnvanterDal.GetInstance();
        }
        public static BolgeEnvanterManager GetInstance()
        {
            if (bolgeEnvanterManager == null)
            {
                bolgeEnvanterManager = new BolgeEnvanterManager();
            }
            return bolgeEnvanterManager;
        }

        public string Add(BolgeEnvanter entity)
        {
            try
            {
                return bolgeEnvanterDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int bolgeId)
        {
            try
            {
                return bolgeEnvanterDal.Delete(bolgeId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public BolgeEnvanter Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<BolgeEnvanter> GetList(int bolgeId)
        {
            try
            {
                return bolgeEnvanterDal.GetList(bolgeId);
            }
            catch (Exception)
            {
                return new List<BolgeEnvanter>();
            }
        }

        public string Update(BolgeEnvanter entity)
        {
            try
            {
                return bolgeEnvanterDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
