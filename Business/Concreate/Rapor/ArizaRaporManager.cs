using DataAccess.Abstract;
using DataAccess.Rapor;
using Entity.Rapor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Rapor
{
    public class ArizaRaporManager //: IRepository<ArizaRapor>
    {
        static ArizaRaporManager arizaRaporManager;
        ArizaRaporDal arizaRaporDal;

        private ArizaRaporManager()
        {
            arizaRaporDal = ArizaRaporDal.GetInstance();
        }

        public string Add(ArizaRapor entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ArizaRapor Get(string bildirimNo)
        {
            try
            {
                return arizaRaporDal.Get(bildirimNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ArizaRapor> GetList()
        {
            try
            {
                return arizaRaporDal.GetList();
            }
            catch (Exception)
            {

                return new List<ArizaRapor>();
            }
        }

        public string Update(ArizaRapor entity)
        {
            throw new NotImplementedException();
        }
        public static ArizaRaporManager GetInstance()
        {
            if (arizaRaporManager == null)
            {
                arizaRaporManager = new ArizaRaporManager();
            }
            return arizaRaporManager;
        }
    }
}
