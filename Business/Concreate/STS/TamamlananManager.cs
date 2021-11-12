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
    public class TamamlananManager //: IRepository<Tamamlanan>
    {
        static TamamlananManager tamamlananManager;
        TamamlananDal tamamlananDal;
        private TamamlananManager()
        {
            tamamlananDal = TamamlananDal.GetInstance();
        }

        public string Add(Tamamlanan entity)
        {
            try
            {
                return tamamlananDal.Add(entity);
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

        public Tamamlanan Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tamamlanan> GetList()
        {
            try
            {
                return tamamlananDal.GetList();
            }
            catch
            {
                return new List<Tamamlanan>();
            }
        }

        public string Update(Tamamlanan entity)
        {
            throw new NotImplementedException();
        }
        public static TamamlananManager GetInstance()
        {
            if (tamamlananManager == null)
            {
                tamamlananManager = new TamamlananManager();
            }
            return tamamlananManager;
        }
    }
}
