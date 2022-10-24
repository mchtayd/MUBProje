using DataAccess.Abstract;
using DataAccess.Concreate.Butce;
using Entity.Butce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Butce
{
    public class SiparislerAracManager // : IRepository<SiparislerArac>
    {
        static SiparislerAracManager siparislerAracManager;
        SiparislerAracDal siparislerAracDal;

        private SiparislerAracManager()
        {
            siparislerAracDal = SiparislerAracDal.GetInstance();
        }
        public string Add(SiparislerArac entity)
        {
            try
            {
                return siparislerAracDal.Add(entity);
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

        public SiparislerArac Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SiparislerArac> GetList(string siparis)
        {
            try
            {
                return siparislerAracDal.GetList(siparis);
            }
            catch (Exception)
            {
                return new List<SiparislerArac>();
            }
        }

        public string Update(SiparislerArac entity)
        {
            throw new NotImplementedException();
        }
        public static SiparislerAracManager GetInstance()
        {
            if (siparislerAracManager == null)
            {
                siparislerAracManager = new SiparislerAracManager();
            }
            return siparislerAracManager;
        }

    }
}
