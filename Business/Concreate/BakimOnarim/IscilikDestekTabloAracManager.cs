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
    public class IscilikDestekTabloAracManager // : IRepository<IscilikDestekTabloArac>
    {
        static IscilikDestekTabloAracManager aracManager;
        IscilikDestekTabloAracDal aracDal;

        private IscilikDestekTabloAracManager()
        {
            aracDal = IscilikDestekTabloAracDal.GetInstance();
        }
        public string Add(IscilikDestekTabloArac entity)
        {
            try
            {
                return aracDal.Add(entity);
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
                return aracDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IscilikDestekTabloArac Get(string siparisNo)
        {
            try
            {
                return aracDal.Get(siparisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<IscilikDestekTabloArac> GetList()
        {
            try
            {
                return aracDal.GetList();
            }
            catch (Exception)
            {
                return new List<IscilikDestekTabloArac>();
            }
        }

        public string Update(IscilikDestekTabloArac entity,int id)
        {
            try
            {
                return aracDal.Update(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static IscilikDestekTabloAracManager GetInstance()
        {
            if (aracManager == null)
            {
                aracManager = new IscilikDestekTabloAracManager();
            }
            return aracManager;
        }
    }
}
