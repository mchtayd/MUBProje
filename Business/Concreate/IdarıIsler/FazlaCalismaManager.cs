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
    public class FazlaCalismaManager //: IRepository<FazlaCalisma>
    {
        static FazlaCalismaManager fazlaCalismaManager;
        FazlaCalismaDal fazlaCalismaDal;

        private FazlaCalismaManager()
        {
            fazlaCalismaDal = FazlaCalismaDal.GetInstance();
        }

        public static FazlaCalismaManager GetInstance()
        {
            if (fazlaCalismaManager == null)
            {
                fazlaCalismaManager = new FazlaCalismaManager();
            }
            return fazlaCalismaManager;
        }

        public string Add(FazlaCalisma entity)
        {
            try
            {
                return fazlaCalismaDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                return fazlaCalismaDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public FazlaCalisma Get(int id)
        {
            try
            {
                return fazlaCalismaDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<FazlaCalisma> GetList()
        {
            try
            {
                return fazlaCalismaDal.GetList();
            }
            catch (Exception)
            {
                return new List<FazlaCalisma>();
            }
        }
        public List<FazlaCalisma> GetListPersonel(string personel)
        {
            try
            {
                return fazlaCalismaDal.GetListPersonel(personel);
            }
            catch (Exception)
            {
                return new List<FazlaCalisma>();
            }
        }
        public List<FazlaCalisma> GetListOnaylanacaklar()
        {
            try
            {
                return fazlaCalismaDal.GetListOnaylanacaklar();
            }
            catch (Exception)
            {
                return new List<FazlaCalisma>();
            }
        }

        public string Update(FazlaCalisma entity)
        {
            try
            {
                return fazlaCalismaDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateOnay(int id)
        {
            try
            {
                return fazlaCalismaDal.UpdateOnay(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
