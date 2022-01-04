using DataAccess.Abstract;
using DataAccess.Concreate.Depo;
using Entity.Depo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Depo
{
    public class DepoKayitLokasyonManager //: IRepository<DepoKayitLokasyon>
    {
        static DepoKayitLokasyonManager depoKayitLokasyonManager;
        DepoKayitLokasyonDal depoKayitLokasyonDal;
        string controlText;

        private DepoKayitLokasyonManager()
        {
            depoKayitLokasyonDal = DepoKayitLokasyonDal.GetInstance();
        }
        public string Add(DepoKayitLokasyon entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return depoKayitLokasyonDal.Add(entity);
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
                return depoKayitLokasyonDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DepoKayitLokasyon Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<DepoKayitLokasyon> GetList()
        {
            try
            {
                return depoKayitLokasyonDal.GetList();
            }
            catch (Exception)
            {
                return new List<DepoKayitLokasyon>();
            }
        }

        public string Update(DepoKayitLokasyon entity)
        {
            try
            {
                return depoKayitLokasyonDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(DepoKayitLokasyon depoKayit)
        {
            if (string.IsNullOrEmpty(depoKayit.Lokasyon))
            {
                return "Lütfen LOKASYON Bilgisini doldurunuz.";
            }
            return "";
        }
        public static DepoKayitLokasyonManager GetInstance()
        {
            if (depoKayitLokasyonManager == null)
            {
                depoKayitLokasyonManager = new DepoKayitLokasyonManager();
            }
            return depoKayitLokasyonManager;
        }
    }
}
