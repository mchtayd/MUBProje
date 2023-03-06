using DataAccess.Abstract;
using DataAccess.Concreate.AnaSayfa;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.AnaSayfa
{
    public class BildirimYetkiManager // : IRepository<BildirimYetki>
    {
        static BildirimYetkiManager bildirimYetkiManager;
        BildirimYetkiDal bildirimYetkiDal;

        private BildirimYetkiManager()
        {
            bildirimYetkiDal = BildirimYetkiDal.GetInstance();
        }

        public static BildirimYetkiManager GetInstance()
        {
            if (bildirimYetkiManager == null)
            {
                bildirimYetkiManager = new BildirimYetkiManager();
            }
            return bildirimYetkiManager;
        }

        public string Add(BildirimYetki entity)
        {
            try
            {
                return bildirimYetkiDal.Add(entity);
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
                return bildirimYetkiDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public BildirimYetki Get(string personelAd)
        {
            try
            {
                return bildirimYetkiDal.Get(personelAd);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<BildirimYetki> GetList(string personelAd)
        {
            try
            {
                return bildirimYetkiDal.GetList(personelAd);
            }
            catch (Exception)
            {
                return new List<BildirimYetki>();
            }
        }

        public string Update(BildirimYetki entity)
        {
            try
            {
                return bildirimYetkiDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
