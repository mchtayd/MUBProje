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
    public class ArizaAyManager //: IRepository<ArizaAy>
    {
        static ArizaAyManager arizaAyManager;
        ArizaAyDal arizaAyDal;

        private ArizaAyManager()
        {
            arizaAyDal = ArizaAyDal.GetInstance();
        }

        public static ArizaAyManager GetInstance()
        {
            if (arizaAyManager == null)
            {
                arizaAyManager = new ArizaAyManager();
            }
            return arizaAyManager;
        }

        public string Add(ArizaAy entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ArizaAy Get(string yil, string sektor, string il)
        {
            try
            {
                return arizaAyDal.Get(yil, sektor, il);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ArizaAy> GetList()
        {
            throw new NotImplementedException();
        }
        public List<string> GetListArizaIlList()
        {
            try
            {
                return arizaAyDal.GetListArizaIlList();
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }
        public List<string> GetListArizaIlcelerList()
        {
            try
            {
                return arizaAyDal.GetListArizaIlcelerList();
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        public string Update(ArizaAy entity)
        {
            throw new NotImplementedException();
        }
    }
}
