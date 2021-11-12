using DataAccess.Abstract;
using DataAccess.Concreate.STS;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.STS
{
    public class ReddedilenMalzemeManager //: IRepository<ReddedilenMalzeme>
    {
        static ReddedilenMalzemeManager reddedilenMalzemeManager;
        ReddedilenMalzemeDal reddedilenMalzemeDal;
        private ReddedilenMalzemeManager()
        {
            reddedilenMalzemeDal = ReddedilenMalzemeDal.GetInstance();
        }
        public string Add(ReddedilenMalzeme entity)
        {
            try
            {
                return reddedilenMalzemeDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(string siparisno)
        {
            try
            {
                return reddedilenMalzemeDal.Delete(siparisno);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ReddedilenMalzeme Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ReddedilenMalzeme> GetList(string siparisno)
        {
            try
            {
                return reddedilenMalzemeDal.GetList(siparisno);
            }
            catch (Exception ex)
            {
                return new List<ReddedilenMalzeme>();
            }
        }

        public string Update(ReddedilenMalzeme entity)
        {
            throw new NotImplementedException();
        }
        public static ReddedilenMalzemeManager GetInstance()
        {
            if (reddedilenMalzemeManager == null)
            {
                reddedilenMalzemeManager = new ReddedilenMalzemeManager();
            }
            return reddedilenMalzemeManager;
        }
    }
}
