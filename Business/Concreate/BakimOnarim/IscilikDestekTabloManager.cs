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
    public class IscilikDestekTabloManager // : IRepository<IscilikDestekTablo>
    {
        static IscilikDestekTabloManager destekTabloManager;
        IscilikDestekTabloDal destekTabloDal;
        string controlText;

        private IscilikDestekTabloManager()
        {
            destekTabloDal = IscilikDestekTabloDal.GetInstance();
        }
        public string Add(IscilikDestekTablo entity,string siparisNo)
        {
            try
            {
                return destekTabloDal.Add(entity, siparisNo);
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
                return destekTabloDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IscilikDestekTablo Get(string siparisNo)
        {
            try
            {
                return destekTabloDal.Get(siparisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<IscilikDestekTablo> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(IscilikDestekTablo entity,string siparisNo)
        {
            try
            {
                return destekTabloDal.Update(entity, siparisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static IscilikDestekTabloManager GetInstance()
        {
            if (destekTabloManager == null)
            {
                destekTabloManager = new IscilikDestekTabloManager();
            }
            return destekTabloManager;
        }
    }
}
