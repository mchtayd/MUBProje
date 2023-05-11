using DataAccess.Abstract;
using DataAccess.Concreate.Gecici_Kabul_Ambar;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Gecici_Kabul_Ambar
{
    public class UstTakimManager // : IRepository<UstTakim>
    {
        static UstTakimManager ustTakimManager;
        UstTakimDal ustTakimDal;

        private UstTakimManager()
        {
            ustTakimDal = UstTakimDal.GetInstance();
        }

        public string Add(UstTakim entity)
        {
            try
            {
                return ustTakimDal.Add(entity);
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
                return ustTakimDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public UstTakim Get(int id)
        {
            try
            {
                return ustTakimDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<UstTakim> GetList()
        {
            try
            {
                return ustTakimDal.GetList();
            }
            catch (Exception)
            {
                return new List<UstTakim>();
            }
        }

        public string Update(UstTakim entity)
        {
            try
            {
                return ustTakimDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static UstTakimManager GetInstance()
        {
            if (ustTakimManager == null)
            {
                ustTakimManager = new UstTakimManager();
            }
            return ustTakimManager;
        }
    }
}
