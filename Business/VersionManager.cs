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
    public class VersionManager //  : IRepository<VersionBilgi>
    {

        VersionDal versionDal;
        static VersionManager versionManager;

        private VersionManager()
        {
            versionDal = VersionDal.GetInstance();
        }


        public string Add(VersionBilgi entity)
        {
            try
            {
                return versionDal.Add(entity);
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

        public VersionBilgi Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<VersionBilgi> GetList()
        {
            try
            {
                return versionDal.GetList();
            }
            catch (Exception)
            {
                return new List<VersionBilgi>();
            }
        }

        public string Update(VersionBilgi entity)
        {
            throw new NotImplementedException();
        }
        public static VersionManager GetInstance()
        {
            if (versionManager == null)
            {
                versionManager = new VersionManager();
            }
            return versionManager;
        }
    }
}
