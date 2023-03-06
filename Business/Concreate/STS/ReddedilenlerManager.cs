using DataAccess.Abstract;
using DataAccess.Concreate.STS;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.STS
{
    public class ReddedilenlerManager
    {
        static ReddedilenlerManager reddedilenlerManager;
        ReddedilenlerDal reddedilenlerDal;
        string controlText;
        private ReddedilenlerManager()
        {
            reddedilenlerDal = ReddedilenlerDal.GetInstance();
        }
        public string Add(Reddedilenler entity)
        {
            try
            {
                controlText = IsReddedilenlerComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return reddedilenlerDal.Add(entity);
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
                return reddedilenlerDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Reddedilenler Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reddedilenler> GetList(string durum)
        {
            try
            {
                return reddedilenlerDal.GetList(durum);
            }
            catch
            {
                return new List<Reddedilenler>();
            }
        }

        public string Update(Reddedilenler entity)
        {
            throw new NotImplementedException();
        }
        public void DurumGuncelleRed(string siparisno)
        {
            try
            {
                reddedilenlerDal.DurumGuncelleRed(siparisno);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static ReddedilenlerManager GetInstance()
        {
            if (reddedilenlerManager == null)
            {
                reddedilenlerManager = new ReddedilenlerManager();
            }
            return reddedilenlerManager;
        }
        public string SatReddedilenlerGuncelle(Reddedilenler entity, string siparisNo)
        {
            try
            {
                return reddedilenlerDal.SatReddedilenlerGuncelle(entity, siparisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string IsReddedilenlerComplete(Reddedilenler reddedilenler)
        {
            if (string.IsNullOrEmpty(reddedilenler.MasrafYeriNo))
            {
                return "Lütfen MasrafYerino Kısmını Giriniz.";
            }
            return "";
        }
    }
}
