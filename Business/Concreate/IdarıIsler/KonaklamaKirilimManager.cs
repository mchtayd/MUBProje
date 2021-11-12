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
    public class KonaklamaKirilimManager //: IRepository<KonaklamaKirilim>
    {
        static KonaklamaKirilimManager konaklamaKirilimManager;
        KonaklamaKirilimDal konaklamaKirilimDal;
        string controlText;

        private KonaklamaKirilimManager()
        {
            konaklamaKirilimDal = KonaklamaKirilimDal.GetInstance();
        }
        public string Add(KonaklamaKirilim entity)
        {
            try
            {
                return konaklamaKirilimDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int isAkisNo)
        {
            try
            {
                return konaklamaKirilimDal.Delete(isAkisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public KonaklamaKirilim Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<KonaklamaKirilim> GetList(int isAkisNo)
        {
            try
            {
                return konaklamaKirilimDal.GetList(isAkisNo);
            }
            catch (Exception)
            {
                return new List<KonaklamaKirilim>();
            }
        }

        public string Update(KonaklamaKirilim entity)
        {
            throw new NotImplementedException();
        }
        public static KonaklamaKirilimManager GetInstance()
        {
            if (konaklamaKirilimManager == null)
            {
                konaklamaKirilimManager = new KonaklamaKirilimManager();
            }
            return konaklamaKirilimManager;
        }
    }
}
