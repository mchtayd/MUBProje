using DataAccess.Abstract;
using DataAccess.Concreate.BakimOnarim;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.BakimOnarimAtolye
{
    public class IslemAdimlariManager // : IRepository<IslemAdimlari>
    {
        static IslemAdimlariManager islemadimlariManager;
        IslemAdimlariDal islemAdimlariDal;

        private IslemAdimlariManager()
        {
            islemAdimlariDal = IslemAdimlariDal.GetInstance();
        }
        public string Add(IslemAdimlari entity)
        {
            try
            {
                return islemAdimlariDal.Add(entity);
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

        public IslemAdimlari Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<IslemAdimlari> GetList(string departman)
        {
            try
            {
                return islemAdimlariDal.GetList(departman);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Update(IslemAdimlari entity)
        {
            throw new NotImplementedException();
        }
        public static IslemAdimlariManager GetInstance()
        {
            if (islemadimlariManager == null)
            {
                islemadimlariManager = new IslemAdimlariManager();
            }
            return islemadimlariManager;
        }
    }
}
