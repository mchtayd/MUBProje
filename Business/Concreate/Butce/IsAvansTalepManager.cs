using DataAccess.Abstract;
using DataAccess.Concreate.Butce;
using Entity.Butce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Butce
{
    public class IsAvansTalepManager // : IRepository<IsAvansTalep>
    {
        static IsAvansTalepManager ısAvansTalepManager;
        IsAvansTalepDal ısAvansTalepDal;

        private IsAvansTalepManager()
        {
            ısAvansTalepDal = IsAvansTalepDal.GetInstance();
        }
        public string Add(IsAvansTalep entity)
        {
            try
            {
                return ısAvansTalepDal.Add(entity);
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

        public IsAvansTalep Get(int isAkisNo)
        {
            try
            {
                return ısAvansTalepDal.Get(isAkisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<IsAvansTalep> GetList()
        {
            try
            {
                return ısAvansTalepDal.GetList();
            }
            catch (Exception)
            {
                return new List<IsAvansTalep>();
            }
        }

        public string Update(IsAvansTalep entity)
        {
            throw new NotImplementedException();
        }
        public static IsAvansTalepManager GetInstance()
        {
            if (ısAvansTalepManager == null)
            {
                ısAvansTalepManager = new IsAvansTalepManager();
            }
            return ısAvansTalepManager;
        }
    }
}
