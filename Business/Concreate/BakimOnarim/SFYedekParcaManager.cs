using DataAccess.Abstract;
using DataAccess.Concreate.BakimOnarim;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.BakimOnarim
{
    public class SFYedekParcaManager //: IRepository<SFYedekPaca>
    {
        static SFYedekParcaManager sFYedekParcaManager;
        SFYedekParcaDal sFYedekParcaDal;

        private SFYedekParcaManager()
        {
            sFYedekParcaDal = SFYedekParcaDal.GetInstance();
        }
        public string Add(SFYedekPaca entity)
        {
            try
            {
                return sFYedekParcaDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(string siparisNo)
        {
            try
            {
                return sFYedekParcaDal.Delete(siparisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SFYedekPaca Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SFYedekPaca> GetList(string siparisNo)
        {
            try
            {
                return sFYedekParcaDal.GetList(siparisNo);
            }
            catch (Exception)
            {
                return new List<SFYedekPaca>();
            }
        }

        public string Update(SFYedekPaca entity)
        {
            try
            {
                return sFYedekParcaDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static SFYedekParcaManager GetInstance()
        {
            if (sFYedekParcaManager == null)
            {
                sFYedekParcaManager = new SFYedekParcaManager();
            }
            return sFYedekParcaManager;
        }
    }
}
