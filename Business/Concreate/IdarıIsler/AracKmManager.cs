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
    public class AracKmManager //: IRepository<AracKm>
    {
        static AracKmManager aracKmManager;
        AracKmDal aracKmDal;

        private AracKmManager()
        {
            aracKmDal = AracKmDal.GetInstance();
        }
        public string Add(AracKm entity)
        {
            try
            {
                return aracKmDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                return aracKmDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public AracKm Get(string plaka)
        {
            return aracKmDal.Get(plaka);
        }
        public AracKm GetGuncelle(int id)
        {
            try
            {
                return aracKmDal.GetGuncelle(id);
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public List<AracKm> GetList()
        {
            try
            {
                return aracKmDal.GetList();
            }
            catch (Exception)
            {
                return new List<AracKm>();
            }
        }

        public string Update(AracKm entity)
        {
            try
            {
                return aracKmDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static AracKmManager GetInstance()
        {
            if (aracKmManager == null)
            {
                aracKmManager = new AracKmManager();
            }
            return aracKmManager;
        }
    }
}
