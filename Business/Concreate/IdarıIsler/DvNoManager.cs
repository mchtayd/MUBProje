using DataAccess;
using DataAccess.Abstract;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.IdarıIsler
{
    public class DvNoManager //: IRepository<DvNo>
    {
        static DvNoManager dvNoManager;
        DvNoDal dvNoDal;

        private DvNoManager()
        {
            dvNoDal = DvNoDal.GetInstance();
        }
        public string Add(DvNo entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DvNo Get()
        {
            try
            {
                return dvNoDal.Get();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DvNo> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update()
        {
            try
            {
                return dvNoDal.Update();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateAzalt()
        {
            try
            {
                return dvNoDal.UpdateAzalt();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static DvNoManager GetInstance()
        {
            if (dvNoManager == null)
            {
                dvNoManager = new DvNoManager();
            }
            return dvNoManager;
        }
    }
}
