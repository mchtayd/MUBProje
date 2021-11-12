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
    public class ReddedilenIzlemeManager
    {
        static ReddedilenIzlemeManager reddedilenIzlemeManager;
        ReddedilenIzlemeDal reddedilenIzlemeDal;
        string controlText;

        private ReddedilenIzlemeManager()
        {
            reddedilenIzlemeDal = ReddedilenIzlemeDal.GetInstance();
        }
        public string Add(ReddedilenIzleme entity)
        {
            try
            {
                controlText = IsReddedilenComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return reddedilenIzlemeDal.Add(entity);
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

        public ReddedilenIzleme Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ReddedilenIzleme> GetList(string siparisNo = "")
        {
            try
            {
                return reddedilenIzlemeDal.GetList(siparisNo);
            }
            catch
            {
                return new List<ReddedilenIzleme>();
            }
        }

        public string Update(ReddedilenIzleme entity)
        {
            throw new NotImplementedException();
        }
        public static ReddedilenIzlemeManager GetInstance()
        {
            if (reddedilenIzlemeManager == null)
            {
                reddedilenIzlemeManager = new ReddedilenIzlemeManager();
            }
            return reddedilenIzlemeManager;
        }
        string IsReddedilenComplete(ReddedilenIzleme reddedilenIzleme)
        {
            if (string.IsNullOrEmpty(reddedilenIzleme.Siparisno))
            {
                return "Siparis Numarasi Algılanamadı";
            }
            return "";
        }
    }
}
