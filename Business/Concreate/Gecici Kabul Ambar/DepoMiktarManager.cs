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
    public class DepoMiktarManager //: IRepository<DepoMiktar>
    {
        static DepoMiktarManager depoMiktarManager;
        DepoMiktarDal depoMiktarDal;

        private DepoMiktarManager()
        {
            depoMiktarDal = DepoMiktarDal.GetInstance();
        }
        public string Add(DepoMiktar entity)
        {
            try
            {
                return depoMiktarDal.Add(entity);
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
                return depoMiktarDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DepoMiktar Get(string stokNo,string depoNo,string seriNo,string lotNo,string revizyon)
        {
            try
            {
                return depoMiktarDal.Get(stokNo, depoNo,seriNo,lotNo,revizyon);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DepoMiktar StokSeriLotKontrol(string stokNo, string depoNo, string seriNo, string lotNo, string revizyon)
        {
            try
            {
                return depoMiktarDal.StokSeriLotKontrol(stokNo, depoNo, seriNo, lotNo, revizyon);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<DepoMiktar> GetList(string stokNo,string depoNo)
        {
            try
            {
                return depoMiktarDal.GetList(stokNo,depoNo);
            }
            catch (Exception)
            {
                return new List<DepoMiktar>();
            }
        }
        public List<DepoMiktar> DepoGor()
        {
            try
            {
                return depoMiktarDal.DepoGor();
            }
            catch (Exception)
            {
                return new List<DepoMiktar>();
            }
        }

        public string Update(DepoMiktar entity)
        {
            try
            {
                return depoMiktarDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static DepoMiktarManager GetInstance()
        {
            if (depoMiktarManager == null)
            {
                depoMiktarManager = new DepoMiktarManager();
            }
            return depoMiktarManager;
        }
    }
}
