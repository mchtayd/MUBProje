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
    public class AtolyeRaporManager //: IRepository<AtolyeRapor>
    {
        static AtolyeRaporManager atolyeRaporManager;
        AtolyeRaporDal atolyeRaporDal;

        private AtolyeRaporManager()
        {
            atolyeRaporDal = AtolyeRaporDal.GetInstance();
        }
        public string Add(AtolyeRapor entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AtolyeRapor Get()
        {
            try
            {
                return atolyeRaporDal.Get();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AtolyeRapor> GetList()
        {
            try
            {
                return atolyeRaporDal.GetList();
            }
            catch (Exception)
            {
                return new List<AtolyeRapor>();
            }
        }

        public string Update(AtolyeRapor entity)
        {
            throw new NotImplementedException();
        }
        public static AtolyeRaporManager GetInstance()
        {
            if (atolyeRaporManager == null)
            {
                atolyeRaporManager = new AtolyeRaporManager();
            }
            return atolyeRaporManager;
        }
    }
}
