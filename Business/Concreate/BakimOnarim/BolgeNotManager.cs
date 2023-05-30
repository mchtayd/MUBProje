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
    public class BolgeNotManager //: IRepository<BolgeNot>
    {
        static BolgeNotManager bolgeNotManager;
        BolgeNotDal bolgeNotDal;

        private BolgeNotManager()
        {
            bolgeNotDal = BolgeNotDal.GetInstance();
        }
        public static BolgeNotManager GetInstance()
        {
            if (bolgeNotManager == null)
            {
                bolgeNotManager = new BolgeNotManager();
            }
            return bolgeNotManager;
        }

        public string Add(BolgeNot entity)
        {
            try
            {
                return bolgeNotDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int benzersizId)
        {
            try
            {
                return bolgeNotDal.Delete(benzersizId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public BolgeNot Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<BolgeNot> GetList(int benzersizId)
        {
            try
            {
                return bolgeNotDal.GetList(benzersizId);
            }
            catch (Exception)
            {
                return new List<BolgeNot>();
            }
        }

        public string Update(BolgeNot entity)
        {
            throw new NotImplementedException();
        }
    }
}
