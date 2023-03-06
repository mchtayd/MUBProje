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
    public class ButceKoduManager
    {
        static ButceKoduManager butceKoduManager;
        ButceKoduDal butceKoduDal;

        private ButceKoduManager()
        {
            butceKoduDal = ButceKoduDal.GetInstance();
        }
        public string Add(ButceKodu entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ButceKodu Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ButceKodu> GetList()
        {
            try
            {
                return butceKoduDal.GetList();
            }
            catch
            {
                return new List<ButceKodu>();
            }
        }

        public string Update(ButceKodu entity)
        {
            throw new NotImplementedException();
        }
        public static ButceKoduManager GetInstance()
        {
            if (butceKoduManager == null)
            {
                butceKoduManager = new ButceKoduManager();
            }
            return butceKoduManager;
        }
    }
}
