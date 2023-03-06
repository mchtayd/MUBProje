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
    public class UstAmirManager // :IRepository<UstAmirMail>
    {
        static UstAmirManager ustAmirManager;
        UstAmirMailDal ustAmirMailDal;
        private UstAmirManager()
        {
            ustAmirMailDal = UstAmirMailDal.GetInstance();
        }
        public string Add(UstAmirMail entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UstAmirMail Get(string personelAd)
        {
            try
            {
                return ustAmirMailDal.Get(personelAd);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<UstAmirMail> GetList(int personelid)
        {
            try
            {
                return ustAmirMailDal.GetList(personelid);
            }
            catch (Exception)
            {
                return new List<UstAmirMail>();
            }
        }

        public string Update(UstAmirMail entity)
        {
            throw new NotImplementedException();
        }
        public static UstAmirManager GetInstance()
        {
            if (ustAmirManager == null)
            {
                ustAmirManager = new UstAmirManager();
            }
            return ustAmirManager;
        }
    }
}
