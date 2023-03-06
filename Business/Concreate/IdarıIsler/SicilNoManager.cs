using DataAccess.Abstract;
using DataAccess.Concreate.IdariIsler;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.IdarıIsler
{
    public class SicilNoManager : IRepository<SicilNo>
    {
        static SicilNoManager sicilNoManager;
        SicilNoDal sicilNoDal;
        string controlText;

        private SicilNoManager()
        {
            sicilNoDal = SicilNoDal.GetInstance();
        }
        public string Add(SicilNo entity)
        {
            try
            {
                controlText = IsSicilNoComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return sicilNoDal.Add(entity);
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

        public SicilNo Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SicilNo> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(SicilNo entity)
        {
            throw new NotImplementedException();
        }
        string IsSicilNoComplete(SicilNo sicilNo)
        {
            if (string.IsNullOrEmpty(sicilNo.Siparisno))
            {
                return "Siparis Numarasi Algılanamadı";
            }
            return "";
        }
        public static SicilNoManager GetInstance()
        {
            if ( sicilNoManager== null)
            {
                sicilNoManager = new SicilNoManager();
            }
            return sicilNoManager;
        }
        public object[] Deneme(string siparisno)
        {
            try
            {
                return sicilNoDal.Deneme(siparisno.Trim());
            }
            catch
            {
                return null;
            }
        }
    }
}
