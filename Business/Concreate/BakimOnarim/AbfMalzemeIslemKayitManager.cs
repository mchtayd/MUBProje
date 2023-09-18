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
            try
            {
                return abfMalzemeIslemKayitDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public AbfMalzemeIslemKayit Get(int benzersizId, string islem, string stokNo, string seriNo, string revizyon)
        {
            try
            {
                return abfMalzemeIslemKayitDal.Get(benzersizId, islem, stokNo, seriNo, revizyon);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AbfMalzemeIslemKayit> GetList(int benzersizId,string malzemeDurumu)
        {
            try
            {
                return abfMalzemeIslemKayitDal.GetList(benzersizId, malzemeDurumu);
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
        public string MalzemeIslemKayitUpdate(int id, string stokNo, string seriNo, string revizyon)
        {
            try
            {
                return abfMalzemeIslemKayitDal.MalzemeIslemKayitUpdate(id, stokNo, seriNo, revizyon);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
