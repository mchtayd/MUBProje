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
    public class DepoKayitManagercs //: IRepository<DepoKayit>
    {
        static DepoKayitManagercs depoKayitManagercs;
        DepoKayitDal depoKayitDal;
        string controlText;

        private DepoKayitManagercs()
        {
            depoKayitDal = DepoKayitDal.GetInstance();
        }
        public string Add(DepoKayit entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return depoKayitDal.Add(entity);
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
                return depoKayitDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DepoKayit Get(int id)
        {
            try
            {
                return depoKayitDal.Get(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DepoKayit> GetList()
        {
            try
            {
                return depoKayitDal.GetList();
            }
            catch (Exception)
            {
                return new List<DepoKayit>();
            }
        }
        public List<DepoKayitLokasyon> GetListLokasyon(int depoId)
        {
            try
            {
                return depoKayitDal.GetListLokasyon(depoId);
            }
            catch (Exception)
            {
                return new List<DepoKayitLokasyon>();
            }
        }

        public string Update(DepoKayit entity)
        {
            try
            {
                return depoKayitDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(DepoKayit depoKayit)
        {
            if (string.IsNullOrEmpty(depoKayit.Depo))
            {
                return "Lütfen DEPO Bilgisini doldurunuz.";
            }
            return "";
        }
        public static DepoKayitManagercs GetInstance()
        {
            if (depoKayitManagercs == null)
            {
                depoKayitManagercs = new DepoKayitManagercs();
            }
            return depoKayitManagercs;
        }
    }
}
