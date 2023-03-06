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
    public class SiparislerPersonelManager //: IRepository<SiparislerPersonel>
    {
        static SiparislerPersonelManager siparislerPersonelManager;
        SiparislerPersonelDal siparislerPersonelDal;

        private SiparislerPersonelManager()
        {
            siparislerPersonelDal = SiparislerPersonelDal.GetInstance();
        }
        public string Add(SiparislerPersonel entity)
        {
            try
            {
                return siparislerPersonelDal.Add(entity);
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

        public SiparislerPersonel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SiparislerPersonel> GetList(string siparis)
        {
            try
            {
                return siparislerPersonelDal.GetList(siparis);
            }
            catch (Exception)
            {
                return new List<SiparislerPersonel>();
            }
        }

        public string Update(SiparislerPersonel entity)
        {
            throw new NotImplementedException();
        }
        public static SiparislerPersonelManager GetInstance()
        {
            if (siparislerPersonelManager == null)
            {
                siparislerPersonelManager = new SiparislerPersonelManager();
            }
            return siparislerPersonelManager;
        }
    }
}
