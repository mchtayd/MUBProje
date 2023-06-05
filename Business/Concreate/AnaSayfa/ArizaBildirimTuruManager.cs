using DataAccess.Abstract;
using DataAccess.Concreate.AnaSayfa;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.AnaSayfa
{
    public class ArizaBildirimTuruManager //: IRepository<ArizaBildirimTuru>
    {
        static ArizaBildirimTuruManager arizaAyManager;
        ArizaBildirimTuruDal arizaBildirimTuruDal;

        private ArizaBildirimTuruManager()
        {
            arizaBildirimTuruDal = ArizaBildirimTuruDal.GetInstance();
        }

        public static ArizaBildirimTuruManager GetInstance()
        {
            if (arizaAyManager == null)
            {
                arizaAyManager = new ArizaBildirimTuruManager();
            }
            return arizaAyManager;
        }

        public string Add(ArizaBildirimTuru entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ArizaBildirimTuru Get()
        {
            try
            {
                return arizaBildirimTuruDal.Get();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ArizaBildirimTuru> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(ArizaBildirimTuru entity)
        {
            throw new NotImplementedException();
        }
    }
}
