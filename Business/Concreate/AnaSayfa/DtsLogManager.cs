using DataAccess.Abstract;
using DataAccess.Concreate.AnaSayfa;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.AnaSayfa
{
    public class DtsLogManager //: IRepository<DtsLog>
    {
        static DtsLogManager dtsLogManager;
        DtsLogDal dtsLogDal;

        private DtsLogManager()
        {
            dtsLogDal = DtsLogDal.GetInstance();
        }

        public static DtsLogManager GetInstance()
        {
            if (dtsLogManager == null)
            {
                dtsLogManager = new DtsLogManager();
            }
            return dtsLogManager;
        }

        public string Add(DtsLog entity)
        {
            try
            {
                return dtsLogDal.Add(entity);
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

        public DtsLog Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<DtsLog> GetList(string personelAdi, DateTime basTarihi, DateTime bitTarihi)
        {
            try
            {
                return dtsLogDal.GetList(personelAdi, basTarihi, bitTarihi);
            }
            catch (Exception)
            {
                return new List<DtsLog>();
            }
        }
        public List<DtsLog> GetListIslem(string personelAdi, DateTime basTarihi, DateTime bitTarihi, string islem)
        {
            try
            {
                return dtsLogDal.GetListIslem(personelAdi, basTarihi, bitTarihi, islem);
            }
            catch (Exception)
            {
                return new List<DtsLog>();
            }
        }
        public List<DtsLog> GetListTumu(DateTime basTarihi, DateTime bitTarihi)
        {
            try
            {
                return dtsLogDal.GetListTumu(basTarihi, bitTarihi);
            }
            catch (Exception)
            {
                return new List<DtsLog>();
            }
        }

        public string Update(DtsLog entity)
        {
            throw new NotImplementedException();
        }
    }
}
