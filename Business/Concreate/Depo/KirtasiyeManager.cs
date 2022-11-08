using DataAccess.Abstract;
using Entity.Depo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Depo
{
    public class KirtasiyeManager// : IRepository<DestekDepoKirtasiye>
    {
        static KirtasiyeManager kirtasiyeManager;
        KirtasiyeDal kirtasiyeDal;
        string controlText;

        private KirtasiyeManager()
        {
            kirtasiyeDal = KirtasiyeDal.GetInstance();
        }
        public string Add(DestekDepoKirtasiye entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return kirtasiyeDal.Add(entity);
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
                return kirtasiyeDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DestekDepoKirtasiye Get(int id)
        {
            try
            {
                return kirtasiyeDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DestekDepoKirtasiye GetTanim(string tanim)
        {
            try
            {
                return kirtasiyeDal.GetTanim(tanim);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DestekDepoKirtasiye GetStokNo(string stokNo)
        {
            try
            {
                return kirtasiyeDal.GetStokNo(stokNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DestekDepoKirtasiye> GetList(int id=0)
        {
            try
            {
                return kirtasiyeDal.GetList(id);
            }
            catch (Exception)
            {
                return new List<DestekDepoKirtasiye>();
            }
        }

        public string Update(DestekDepoKirtasiye entity,int id)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return kirtasiyeDal.Update(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(DestekDepoKirtasiye destekDepoKirtasiye)
        {
            if (string.IsNullOrEmpty(destekDepoKirtasiye.Stokno))
            {
                return "Lütfen STOK NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(destekDepoKirtasiye.Tanim))
            {
                return "Lütfen TANIM Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(destekDepoKirtasiye.Birim))
            {
                return "Lütfen BİRİM Bilgisini doldurunuz.";
            }
            return "";
        }
        public static KirtasiyeManager GetInstance()
        {
            if (kirtasiyeManager == null)
            {
                kirtasiyeManager = new KirtasiyeManager();
            }
            return kirtasiyeManager;
        }
    }
}
