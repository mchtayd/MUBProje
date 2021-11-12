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
    public class AmbarManager // : IRepository<DestekDepoAmbar>
    {
        static AmbarManager ambarManager;
        AmbarDal ambarDal;
        string controlText;

        private AmbarManager()
        {
            ambarDal = AmbarDal.GetInstance();
        }
        public string Add(DestekDepoAmbar entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return ambarDal.Add(entity);
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
                if (id<1)
                {
                    return "Lütfen Geçerli Bir Stok Numarası Seçiniz.";
                }
                return ambarDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DestekDepoAmbar Get(int id)
        {
            try
            {
                return ambarDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DestekDepoAmbar> GetList(int id=0)
        {
            try
            {
                return ambarDal.GetList(id);
            }
            catch (Exception)
            {
                return new List<DestekDepoAmbar>();
            }
        }

        public string Update(DestekDepoAmbar entity,int id)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return ambarDal.Update(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(DestekDepoAmbar destekDepoAmbar)
        {
            if (string.IsNullOrEmpty(destekDepoAmbar.Stokno))
            {
                return "Lütfen STOK NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(destekDepoAmbar.Tanim))
            {
                return "Lütfen TANIM Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(destekDepoAmbar.Birim))
            {
                return "Lütfen BİRİM Bilgisini doldurunuz.";
            }
            return "";
        }
        public static AmbarManager GetInstance()
        {
            if (ambarManager == null)
            {
                ambarManager = new AmbarManager();
            }
            return ambarManager;
        }
    }
}
