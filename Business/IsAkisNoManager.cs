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
    public class IsAkisNoManager //: IRepository<IsAkisNo>
    {
        static IsAkisNoManager isAkisNoManager;
        IsAkisNoDal isAkisNoDal;

        private IsAkisNoManager()
        {
            isAkisNoDal = IsAkisNoDal.GetInstance();
        }
        public string Add(IsAkisNo entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IsAkisNo Get()
        {
            try
            {
                return isAkisNoDal.Get();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<IsAkisNo> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update()
        {
            try
            {
                return isAkisNoDal.Update();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateKontrolsuz()
        {
            try
            {
                return isAkisNoDal.UpdateKontrolsuz();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static IsAkisNoManager GetInstance()
        {
            if (isAkisNoManager == null)
            {
                isAkisNoManager = new IsAkisNoManager();
            }
            return isAkisNoManager;
        }
    }
}
