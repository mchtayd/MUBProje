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
    public class BarkodManager // : IRepository<Barkod>
    {
        static BarkodManager barkodManager;
        BarkodDal barkodDal;

        private BarkodManager()
        {
            barkodDal = BarkodDal.GetInstance();
        }

        public string Add(Barkod entity)
        {
            try
            {
                return barkodDal.Add(entity);
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

        public Barkod Get(int id)
        {
            try
            {
                return barkodDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Barkod> GetList()
        {
            try
            {
                return barkodDal.GetList();
            }
            catch (Exception)
            {

                return new List<Barkod>();
            }
        }
        public Barkod BarkodKontrolList(string stokNo, string seriNo, string revizyon)
        {
            try
            {
                return barkodDal.BarkodKontrolList(stokNo, seriNo, revizyon);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string BarkodTekrarCikti(Barkod entity)
        {
            try
            {
                return barkodDal.BarkodTekrarCikti(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static BarkodManager GetInstance()
        {
            if (barkodManager == null)
            {
                barkodManager = new BarkodManager();
            }
            return barkodManager;
        }
    }
}
