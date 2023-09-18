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
        public DepoMiktar GetEdit(int id)
        {
            try
            {
                return depoMiktarDal.GetEdit(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DepoMiktar GetBarkodLokasyonBul(string stokNo, string seriNo, string revizyon, string takipDurum)
        {
            try
            {
                return depoMiktarDal.GetBarkodLokasyonBul(stokNo, seriNo, revizyon, takipDurum);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DepoMiktar GetBarkodLokasyonBul2500(string stokNo, string seriNo, string revizyon, string takipDurum, int miktar)
        {
            try
            {
                return depoMiktarDal.GetBarkodLokasyonBul2500(stokNo, seriNo, revizyon, takipDurum, miktar);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DepoMiktar GetBarkodLokasyonBul3000(string stokNo, string seriNo, string revizyon, string takipDurum, int miktar)
        {
            try
            {
                return depoMiktarDal.GetBarkodLokasyonBul3000(stokNo, seriNo, revizyon, takipDurum, miktar);
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
        public List<DepoMiktar> GetListTumu()
        {
            try
            {
                return depoMiktarDal.GetListTumu();
            }
            catch (Exception)
            {
                return new List<DepoMiktar>();
            }
        }
        public List<DepoMiktar> StokKontrol(string stokNo)
        {
            try
            {
                return depoMiktarDal.StokKontrol(stokNo);
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

        public string Update(DepoMiktar entity, string rezerveDurum)
        {
            try
            {
                return depoMiktarDal.Update(entity, rezerveDurum);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateDepoStok(DepoMiktar entity)
        {
            try
            {
                return depoMiktarDal.UpdateDepoStok(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string DepoRezerve(DepoMiktar entity)
        {
            try
            {
                return depoMiktarDal.DepoRezerve(entity);
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
