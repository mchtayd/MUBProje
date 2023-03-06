using DataAccess.Abstract;
using DataAccess.Concreate.IdariIsler;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.STS
{
    public class SiparisPersonelManager
    {
        static SiparisPersonelManager siparisPersonelManager;
        SiparisPersonelDal siparisPersonelDal;

        private SiparisPersonelManager()
        {
            siparisPersonelDal = SiparisPersonelDal.GetInstance();
        }
        public string Add(SiparisPersonel entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SiparisPersonel Get(string siparisno="", string adsoyad="")
        {
            try
            {
                return siparisPersonelDal.Get(siparisno, adsoyad);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SiparisPersonel> GetList(string siparis="",string adsoyad="")
        {
            try
            {
                return siparisPersonelDal.GetList(siparis,adsoyad);
            }
            catch
            {
                return new List<SiparisPersonel>();
            }
        }
        public List<SiparisPersonel> MasrafYeriSorumlusu()
        {
            try
            {
                return siparisPersonelDal.MasrafYeriSorumlusu();
            }
            catch
            {
                return new List<SiparisPersonel>();
            }
        }
        public List<SiparisPersonel> IstekteBulunan(string siparis = "", string adsoyad = "")
        {
            try
            {
                return siparisPersonelDal.IstekteBulunan(siparis, adsoyad);
            }
            catch
            {
                return new List<SiparisPersonel>();
            }
        }

        public string Update(SiparisPersonel entity)
        {
            throw new NotImplementedException();
        }
        public static SiparisPersonelManager GetInstance()
        {
            if (siparisPersonelManager == null)
            {
                siparisPersonelManager = new SiparisPersonelManager();
            }
            return siparisPersonelManager;
        }
    }
}
