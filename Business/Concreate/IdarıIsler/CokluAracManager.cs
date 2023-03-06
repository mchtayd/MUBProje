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
    public class CokluAracManager //: IRepository<CokluArac>
    {
        static CokluAracManager cokluAracManager;
        CokluAracDal cokluAracDal;

        private CokluAracManager()
        {
            cokluAracDal = CokluAracDal.GetInstance();
        }
        public string Add(CokluArac entity)
        {
            try
            {
                return cokluAracDal.Add(entity);
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

        public CokluArac Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CokluArac> GetList(string siparisNo)
        {
            try
            {
                return cokluAracDal.GetList(siparisNo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Update(CokluArac entity)
        {
            throw new NotImplementedException();
        }
        public static CokluAracManager GetInstance()
        {
            if (cokluAracManager == null)
            {
                cokluAracManager = new CokluAracManager();
            }
            return cokluAracManager;
        }
    }
}
