using DataAccess.Abstract;
using DataAccess.Concreate.BakimOnarimAtolye;
using Entity.BakimOnarimAtolye;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.BakimOnarimAtolye
{
    public class AtolyeManager // : IRepository<Atolye>
    {
        static AtolyeManager atolyeManager;
        AtolyeDal atolyeDal;

        private AtolyeManager()
        {
            atolyeDal = AtolyeDal.GetInstance();
        }

        public string Add(Atolye entity)
        {
            try
            {
                return atolyeDal.Add(entity);
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

        public Atolye Get(string icSiparisNo)
        {
            try
            {
                return atolyeDal.Get(icSiparisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Atolye ArizaGetir(int abfNo)
        {
            try
            {
                return atolyeDal.ArizaGetir(abfNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Atolye> GetList()
        {
            try
            {
                return atolyeDal.GetList();
            }
            catch (Exception)
            {
                return new List<Atolye>();
            }
        }
        public List<Atolye> AtolyeIcSiparis(string icSiparisNo)
        {
            try
            {
                return atolyeDal.AtolyeIcSiparis(icSiparisNo);
            }
            catch (Exception)
            {
                return new List<Atolye>();
            }
        }

        public string Update(Atolye entity)
        {
            throw new NotImplementedException();
        }
        public static AtolyeManager GetInstance()
        {
            if (atolyeManager == null)
            {
                atolyeManager = new AtolyeManager();
            }
            return atolyeManager;
        }
    }
}
