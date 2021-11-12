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
    public class DevamEdenIzlemeManager
    {
        static DevamEdenIzlemeManager devamEdenIzlemeManager;
        DevamEdenIzlemeDal devamEdenIzlemeDal;
        string controlText;
        private DevamEdenIzlemeManager()
        {
            devamEdenIzlemeDal = DevamEdenIzlemeDal.GetInstance();
        }
        public string Add(DevamEdenIzleme entity)
        {
            try
            {
                controlText = IsDevamEdenComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return devamEdenIzlemeDal.Add(entity);
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

        public DevamEdenIzleme Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<DevamEdenIzleme> GetList(string siparisNo = "")
        {
            try
            {
                return devamEdenIzlemeDal.GetList(siparisNo);
            }
            catch
            {
                return new List<DevamEdenIzleme>();
            }
        }

        public string Update(DevamEdenIzleme entity)
        {
            throw new NotImplementedException();
        }
        public static DevamEdenIzlemeManager GetInstance()
        {
            if (devamEdenIzlemeManager == null)
            {
                devamEdenIzlemeManager = new DevamEdenIzlemeManager();
            }
            return devamEdenIzlemeManager;
        }
        string IsDevamEdenComplete(DevamEdenIzleme devamEden)
        {
            if (string.IsNullOrEmpty(devamEden.Siparisno))
            {
                return "Siparis Numarasi Algılanamadı";
            }
            return "";
        }
    }
}
