using Business.Concreate.BakimOnarim;
using DataAccess.Abstract;
using DataAccess.Concreate.Depo;
using Entity.Depo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Depo
{
    public class DestekDepoElekronikManager //: IRepository<DestekDepoElekronik>
    {
        static DestekDepoElekronikManager destekDepoElekronikManager;
        DestekDepoElekronikDal depoElekronikDal;

        private DestekDepoElekronikManager()
        {
            depoElekronikDal = DestekDepoElekronikDal.GetInstance();
        }

        public static DestekDepoElekronikManager GetInstance()
        {
            if (destekDepoElekronikManager == null)
            {
                destekDepoElekronikManager = new DestekDepoElekronikManager();
            }
            return destekDepoElekronikManager;
        }

        public string Add(DestekDepoElekronik entity)
        {
            try
            {
                return depoElekronikDal.Add(entity);
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
                return depoElekronikDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DestekDepoElekronik Get(int id)
        {
            try
            {
                return depoElekronikDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DestekDepoElekronik> GetList()
        {
            try
            {
                return depoElekronikDal.GetList();
            }
            catch (Exception)
            {
                return new List<DestekDepoElekronik>();
            }
        }

        public string Update(DestekDepoElekronik entity)
        {
            try
            {
                return depoElekronikDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
