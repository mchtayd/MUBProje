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
    public class PersKaytLojistikManager
    {
        static PersKaytLojistikManager persKaytLojistikManager;
        PersKaytLojistikDal persKaytLojistikDal;
        private PersKaytLojistikManager()
        {
            persKaytLojistikDal = PersKaytLojistikDal.GetInstance();
        }
        public string Add(PersKaytLojistik entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PersKaytLojistik Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<PersKaytLojistik> GetList(int indis)
        {

            try
            {
                return persKaytLojistikDal.GetList(indis);
            }
            catch
            {
                return new List<PersKaytLojistik>();
            }
        }

        public string Update(PersKaytLojistik entity)
        {
            throw new NotImplementedException();
        }
        public static PersKaytLojistikManager GetInstance()
        {
            if (persKaytLojistikManager == null)
            {
                persKaytLojistikManager = new PersKaytLojistikManager();
            }
            return persKaytLojistikManager;
        }
    }
}
