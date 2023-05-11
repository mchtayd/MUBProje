using DataAccess;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ArizaIslemAdimiManager //: IRepository<ArizaIslemAdimi>
    {
        static ArizaIslemAdimiManager arizaIslemAdimiManager;
        ArizaIslemAdimiDal arizaIslemAdimiDal;

        private ArizaIslemAdimiManager()
        {
            arizaIslemAdimiDal = ArizaIslemAdimiDal.GetInstance();
        }

        public string Add(ArizaIslemAdimi entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ArizaIslemAdimi Get(string islemAdimi)
        {
            try
            {
                return arizaIslemAdimiDal.Get(islemAdimi);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ArizaIslemAdimi> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(ArizaIslemAdimi entity)
        {
            throw new NotImplementedException();
        }
        public static ArizaIslemAdimiManager GetInstance()
        {
            if (arizaIslemAdimiManager == null)
            {
                arizaIslemAdimiManager = new ArizaIslemAdimiManager();
            }
            return arizaIslemAdimiManager;
        }
    }
}
