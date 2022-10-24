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
    public class MalzemeTalepManager //: IRepository<MalzemeTalep>
    {
        static MalzemeTalepManager malzemeTalepManager;
        MalzemeTalepDal malzemeTalepDal;
        //string controlText;

        private MalzemeTalepManager()
        {
            malzemeTalepDal = MalzemeTalepDal.GetInstance();
        }
        public string Add(MalzemeTalep entity)
        {
            try
            {
                return malzemeTalepDal.Add(entity);
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

        public MalzemeTalep Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<MalzemeTalep> GetList()
        {
            try
            {
                return malzemeTalepDal.GetList();
            }
            catch (Exception)
            {
                return new List<MalzemeTalep>();
            }
        }

        public string Update(MalzemeTalep entity)
        {
            throw new NotImplementedException();
        }
        public static MalzemeTalepManager GetInstance()
        {
            if (malzemeTalepManager == null)
            {
                malzemeTalepManager = new MalzemeTalepManager();
            }
            return malzemeTalepManager;
        }
    }
}
