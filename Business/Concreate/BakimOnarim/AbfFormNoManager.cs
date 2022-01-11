using DataAccess.Abstract;
using DataAccess.Concreate.BakimOnarim;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.BakimOnarim
{
    public class AbfFormNoManager //: IRepository<AbfFormNo>
    {
        static AbfFormNoManager abfFormNoManager;
        AbfFormNoDal abfFormNoDal;

        private AbfFormNoManager()
        {
            abfFormNoDal = AbfFormNoDal.GetInstance();
        }
        public string Add(AbfFormNo entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AbfFormNo Get()
        {
            try
            {
                return abfFormNoDal.Get();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public AbfFormNo PersonelSicil(string abfNo)
        {
            try
            {
                return abfFormNoDal.PersonelSicil(abfNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AbfFormNo> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update()
        {
            try
            {
                return abfFormNoDal.Update();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static AbfFormNoManager GetInstance()
        {
            if (abfFormNoManager == null)
            {
                abfFormNoManager = new AbfFormNoManager();
            }
            return abfFormNoManager;
        }
    }
}
