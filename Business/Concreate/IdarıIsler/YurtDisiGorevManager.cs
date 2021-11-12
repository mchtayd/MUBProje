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
    public class YurtDisiGorevManager // : IRepository<YurtDisiGorev>
    {

        static YurtDisiGorevManager yurtDisiGorevManager;
        YurtDisiGorevDal yurtDisiGorevDal;

        private YurtDisiGorevManager()
        {
            yurtDisiGorevDal = YurtDisiGorevDal.GetInstance();
        }
        public string Add(YurtDisiGorev entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public YurtDisiGorev Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<YurtDisiGorev> GetList()
        {
            try
            {
                return yurtDisiGorevDal.GetList();
            }
            catch (Exception)
            {
                return new List<YurtDisiGorev>();
            }
        }

        public string Update(YurtDisiGorev entity)
        {
            throw new NotImplementedException();
        }
        public static YurtDisiGorevManager GetInstance()
        {
            if (yurtDisiGorevManager == null)
            {
                yurtDisiGorevManager = new YurtDisiGorevManager();
            }
            return yurtDisiGorevManager;
        }
    }
}
