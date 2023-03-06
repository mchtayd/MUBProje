using DataAccess.Abstract;
using DataAccess.Concreate.IdariIsler;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.IdarıIsler
{
    public class AracZimmetiLogManager //: IRepository<AracZimmetiLog>
    {
        static AracZimmetiLogManager aracZimmetiLogManager;
        AracZimmetiLogDal aracZimmetiLogDal;

        private AracZimmetiLogManager()
        {
            aracZimmetiLogDal = AracZimmetiLogDal.GetInstance();
        }
        public string Add(AracZimmetiLog entity)
        {
            try
            {
                return aracZimmetiLogDal.Add(entity);
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

        public AracZimmetiLog Get(int isAkisNo)
        {
            try
            {
                return aracZimmetiLogDal.Get(isAkisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AracZimmetiLog> GetList()
        {
            try
            {
                return aracZimmetiLogDal.GetList();
            }
            catch (Exception)
            {
                return new List<AracZimmetiLog>();
            }
        }

        public string Update(AracZimmetiLog entity)
        {
            throw new NotImplementedException();
        }
        public static AracZimmetiLogManager GetInstance()
        {
            if (aracZimmetiLogManager == null)
            {
                aracZimmetiLogManager = new AracZimmetiLogManager();
            }
            return aracZimmetiLogManager;
        }
    }
}
