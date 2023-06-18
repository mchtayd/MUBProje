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
    public class AbfMalzemeIslemKayitManager //: IRepository<AbfMalzemeIslemKayit>
    {
        static AbfMalzemeIslemKayitManager abfMalzemeIslemKayitManager;
        AbfMalzemeIslemKayitDal abfMalzemeIslemKayitDal;

        private AbfMalzemeIslemKayitManager()
        {
            abfMalzemeIslemKayitDal = AbfMalzemeIslemKayitDal.GetInstance();
        }
        public static AbfMalzemeIslemKayitManager GetInstance()
        {
            if (abfMalzemeIslemKayitManager == null)
            {
                abfMalzemeIslemKayitManager = new AbfMalzemeIslemKayitManager();
            }
            return abfMalzemeIslemKayitManager;
        }

        public string Add(AbfMalzemeIslemKayit entity)
        {
            try
            {
                return abfMalzemeIslemKayitDal.Add(entity);
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

        public AbfMalzemeIslemKayit Get(int benzersizId, string islem)
        {
            try
            {
                return abfMalzemeIslemKayitDal.Get(benzersizId, islem);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AbfMalzemeIslemKayit> GetList(int benzersizId)
        {
            try
            {
                return abfMalzemeIslemKayitDal.GetList(benzersizId);
            }
            catch (Exception)
            {
                return new List<AbfMalzemeIslemKayit>();
            }
        }

        public string Update(int id, int gecenSure)
        {
            try
            {
                return abfMalzemeIslemKayitDal.Update(id, gecenSure);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
