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
    public class StokManager // : IRepository<Stok>
    {
        static StokManager stokManager;
        StokDal stokDal;

        private StokManager()
        {
            stokDal = StokDal.GetInstance();
        }
        public string Add(Stok entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Stok Get(string tanim)
        {
            try
            {
                return stokDal.Get(tanim);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Stok> GetList()
        {
            try
            {
                return stokDal.GetList();
            }
            catch (Exception)
            {
                return new List<Stok>();
            }
        }

        public string Update(Stok entity)
        {
            throw new NotImplementedException();
        }
        public static StokManager GetInstance()
        {
            if (stokManager == null)
            {
                stokManager = new StokManager();
            }
            return stokManager;
        }
    }
}
