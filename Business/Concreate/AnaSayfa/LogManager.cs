using DataAccess.Abstract;
using DataAccess.Concreate.AnaSayfa;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.AnaSayfa
{
    public class LogManager //: IRepository<Log>
    {
        static LogManager logManager;
        LogDal logDal;

        private LogManager()
        {
            logDal = LogDal.GetInstance();
        }
        public static LogManager GetInstance()
        {
            if (logManager == null)
            {
                logManager = new LogManager();
            }
            return logManager;
        }

        public string Add(Log entity)
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

        public Log Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Log> GetList(string kullaniciId)
        {
            try
            {
                return logDal.GetList(kullaniciId);
            }
            catch (Exception)
            {
                return new List<Log>();
            }
        }

        public string Update(Log entity)
        {
            throw new NotImplementedException();
        }
    }
}
