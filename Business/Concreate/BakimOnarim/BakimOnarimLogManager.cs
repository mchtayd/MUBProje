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
    public class BakimOnarimLogManager // : IRepository<BakimOnarimLog>
    {
        static BakimOnarimLogManager bakimOnarimLogManager;
        BakimOnarimLogDal bakimOnarimLogDal;

        private BakimOnarimLogManager()
        {
            bakimOnarimLogDal = BakimOnarimLogDal.GetInstance();
        }
        public string Add(BakimOnarimLog entity)
        {
            try
            {
                return bakimOnarimLogDal.Add(entity);
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

        public BakimOnarimLog Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<BakimOnarimLog> GetList(string sayfa,int benzersiz)
        {
            try
            {
                return bakimOnarimLogDal.GetList(sayfa, benzersiz);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Update(BakimOnarimLog entity)
        {
            throw new NotImplementedException();
        }
        public static BakimOnarimLogManager GetInstance()
        {
            if (bakimOnarimLogManager == null)
            {
                bakimOnarimLogManager = new BakimOnarimLogManager();
            }
            return bakimOnarimLogManager;
        }
    }
}
