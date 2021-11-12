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
    public class IdariIslerLogManager // : IRepository<IdariIslerLog>
    {
        static IdariIslerLogManager logManager;
        IdariIslerLogDal logDal;

        private IdariIslerLogManager()
        {
            logDal = IdariIslerLogDal.GetInstance();
        }
        public string Add(IdariIslerLog entity)
        {
            try
            {
                return logDal.Add(entity);
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

        public IdariIslerLog Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<IdariIslerLog> GetList(string sayfa,int benzersizid)
        {
            try
            {
                return logDal.GetList(sayfa, benzersizid);
            }
            catch (Exception)
            {
                return new List<IdariIslerLog>();
            }
        }

        public string Update(IdariIslerLog entity)
        {
            throw new NotImplementedException();
        }
        public static IdariIslerLogManager GetInstance()
        {
            if (logManager == null)
            {
                logManager = new IdariIslerLogManager();
            }
            return logManager;
        }
    }
}
