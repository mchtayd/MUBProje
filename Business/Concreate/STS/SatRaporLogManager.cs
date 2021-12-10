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
    public class SatRaporLogManager // : IRepository<SatRaporLog>
    {
        static SatRaporLogManager satRaporLogManager;
        SatRaporLogDal satRaporLogDal;

        private SatRaporLogManager()
        {
            satRaporLogDal = SatRaporLogDal.GetInstance();
        }
        public string Add(SatRaporLog entity)
        {
            try
            {
                return satRaporLogDal.Add(entity);
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

        public SatRaporLog Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SatRaporLog> GetList()
        {
            try
            {
                return satRaporLogDal.GetList();
            }
            catch (Exception)
            {
                return new List<SatRaporLog>();
            }
            
        }

        public string Update(SatRaporLog entity)
        {
            throw new NotImplementedException();
        }
        public static SatRaporLogManager GetInstance()
        {
            if (satRaporLogManager == null)
            {
                satRaporLogManager = new SatRaporLogManager();
            }
            return satRaporLogManager;
        }
    }
}
