using Business.Concreate.AnaSayfa;
using DataAccess.Abstract;
using DataAccess.Concreate.AnaSayfa;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class SohbetManager //: IRepository<Sohbet>
    {
        static SohbetManager logManager;
        SohbetDal sohbetDal;

        private SohbetManager()
        {
            sohbetDal = SohbetDal.GetInstance();
        }
        public static SohbetManager GetInstance()
        {
            if (logManager == null)
            {
                logManager = new SohbetManager();
            }
            return logManager;
        }

        public string Add(Sohbet entity)
        {
            try
            {
                return sohbetDal.Add(entity);
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

        public Sohbet Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Sohbet> GetList(string gonderen, string alan)
        {
            try
            {
                return sohbetDal.GetList(gonderen, alan);
            }
            catch (Exception)
            {
                return new List<Sohbet>();
            }
        }
        public List<Sohbet> GetListSohbetler(string gonderen, string alan)
        {
            try
            {
                return sohbetDal.GetListSohbetler(gonderen, alan);
            }
            catch (Exception)
            {
                return new List<Sohbet>();
            }
        }

        public string UpdateGoruldu(int id)
        {
            try
            {
                return sohbetDal.UpdateGoruldu(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
