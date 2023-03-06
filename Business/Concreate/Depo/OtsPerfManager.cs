using DataAccess.Abstract;
using DataAccess.Concreate.Depo;
using DataAccess.Rapor;
using Entity.Rapor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Depo
{
    public class OtsPerfManager //: IRepository<OtsPerf>
    {
        static OtsPerfManager otsPerfManager;
        OtsPerfDal otsPerfDal;

        private OtsPerfManager()
        {
            otsPerfDal = OtsPerfDal.GetInstance();
        }

        public string Add(OtsPerf entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OtsPerf Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<OtsPerf> GetList(int yil)
        {
            try
            {
                if (yil == 0)
                {
                    return otsPerfDal.GetList("");
                }
                return otsPerfDal.GetList(yil.ToString());
            }
            catch
            {
                return new List<OtsPerf>();
            }
        }
        public string PersonelSicil(string sicil)
        {
            try
            {
                return otsPerfDal.PersonelSicil(sicil);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<OtsPerf> GetListAdimlar(int abfNo)
        {
            try
            {
                return otsPerfDal.GetListAdimlar(abfNo.ToString());
            }
            catch
            {
                return new List<OtsPerf>();
            }
        }
        public List<string> Yillar()
        {
            try
            {
                return otsPerfDal.Yillar();
            }
            catch
            {
                return new List<string>();
            }
        }

        public string Update(OtsPerf entity)
        {
            throw new NotImplementedException();
        }
        public static OtsPerfManager GetInstance()
        {
            if (otsPerfManager == null)
            {
                otsPerfManager = new OtsPerfManager();
            }
            return otsPerfManager;
        }
    }
}
