using DataAccess;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AmbarVeriManager //: IRepository<AmbarVeri>
    {
        static AmbarVeriManager ambarVeriManager;
        AmbarVeriDal ambarVeriDal;

        private AmbarVeriManager()
        {
            ambarVeriDal = AmbarVeriDal.GetInstance();
        }
        public string Add(AmbarVeri entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AmbarVeri Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<AmbarVeri> GetList()
        {
            try
            {
                return ambarVeriDal.GetList();
            }
            catch (Exception)
            {
                return new List<AmbarVeri>();
            }
        }

        public List<AmbarVeri> GetListAselsan()
        {
            try
            {
                return ambarVeriDal.GetListAselsan();
            }
            catch (Exception)
            {
                return new List<AmbarVeri>();
            }
        }

        public string Update(AmbarVeri entity)
        {
            throw new NotImplementedException();
        }
        public static AmbarVeriManager GetInstance()
        {
            if (ambarVeriManager == null)
            {
                ambarVeriManager = new AmbarVeriManager();
            }
            return ambarVeriManager;
        }
    }
}
