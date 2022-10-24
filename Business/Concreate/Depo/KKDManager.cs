using DataAccess.Abstract;
using Entity.Depo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Depo
{
    public class KKDManager // : IRepository<DestekDepoKKD>
    {
        static KKDManager kKDManager;
        KKDDal kKDDal;
        string controlText;

        private KKDManager()
        {
            kKDDal = KKDDal.GetInstance();
        }
        public string Add(DestekDepoKKD entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return kKDDal.Add(entity);
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
                if (id < 1)
                {
                    return "Lütfen Geçerli Bir Stok Numarası Seçiniz.";
                }
                return kKDDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DestekDepoKKD Get(int id)
        {
            try
            {
                return kKDDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DestekDepoKKD GetTanim(string tanim)
        {
            try
            {
                return kKDDal.GetTanim(tanim);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DestekDepoKKD> GetList(int id=0)
        {
            try
            {
                return kKDDal.GetList(id);
            }
            catch (Exception)
            {
                return new List<DestekDepoKKD>();
            }
        }

        public string Update(DestekDepoKKD entity,int id)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return kKDDal.Update(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(DestekDepoKKD destekDepoKKD)
        {
            if (string.IsNullOrEmpty(destekDepoKKD.Stokno))
            {
                return "Lütfen STOK NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(destekDepoKKD.Tanim))
            {
                return "Lütfen TANIM Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(destekDepoKKD.Birim))
            {
                return "Lütfen BİRİM Bilgisini doldurunuz.";
            }
            return "";
        }
        public static KKDManager GetInstance()
        {
            if (kKDManager == null)
            {
                kKDManager = new KKDManager();
            }
            return kKDManager;
        }
    }
}
