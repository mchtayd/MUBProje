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
    public class AvansManager // : IRepository<Avans>
    {
        static AvansManager avansManager;
        AvansDal avansDal;

        private AvansManager()
        {
            avansDal = AvansDal.GetInstance();
        }
        public string Add(Avans entity)
        {
            try
            {
                return avansDal.Add(entity);
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

        public Avans Get(int isAkisNo)
        {
            try
            {
                return avansDal.Get(isAkisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Avans> GetList()
        {
            try
            {
                return avansDal.GetList();
            }
            catch (Exception)
            {
                return new List<Avans>();
            }
        }

        public string Update(Avans entity)
        {
            throw new NotImplementedException();
        }
        public static AvansManager GetInstance()
        {
            if (avansManager == null)
            {
                avansManager = new AvansManager();
            }
            return avansManager;
        }
    }
}
