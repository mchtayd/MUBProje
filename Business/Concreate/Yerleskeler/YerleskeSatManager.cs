using DataAccess.Abstract;
using DataAccess.Concreate.Yerleskeler;
using Entity.Yerleskeler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Yerleskeler
{
    public class YerleskeSatManager //: IRepository<YerleskeSat>
    {
        static YerleskeSatManager yerleskeSatManager;
        YerleskeSatDal yerleskeSatDal;

        private YerleskeSatManager()
        {
            yerleskeSatDal = YerleskeSatDal.GetInstance();
        }

        public string Add(YerleskeSat entity)
        {
            try
            {
                return yerleskeSatDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public YerleskeSat Get(int id)
        {
            try
            {
                return yerleskeSatDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<YerleskeSat> GetList(string yerleskeAdi)
        {
            try
            {
                return yerleskeSatDal.GetList(yerleskeAdi);
            }
            catch (Exception)
            {
                return new List<YerleskeSat>();
            }
        }

        public string Update(YerleskeSat entity)
        {
            throw new NotImplementedException();
        }
        public static YerleskeSatManager GetInstance()
        {
            if (yerleskeSatManager == null)
            {
                yerleskeSatManager = new YerleskeSatManager();
            }
            return yerleskeSatManager;
        }
    }
}
