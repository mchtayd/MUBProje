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
    public class CayOcagiManager // : IRepository<DestekDepoCayOcagi>
    {
        static CayOcagiManager cayOcagiManager;
        CayOcagiDal cayOcagiDal;
        string controlText;

        private CayOcagiManager()
        {
            cayOcagiDal = CayOcagiDal.GetInstance();
        }

        public string Add(DestekDepoCayOcagi entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return cayOcagiDal.Add(entity);
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
                return cayOcagiDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DestekDepoCayOcagi Get(int id=0)
        {
            try
            {
                return cayOcagiDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DestekDepoCayOcagi GetTanim(string tanim)
        {
            try
            {
                return cayOcagiDal.GetTanim(tanim);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DestekDepoCayOcagi> GetList(int id=0)
        {
            try
            {
                return cayOcagiDal.GetList(id);
            }
            catch (Exception)
            {
                return new List<DestekDepoCayOcagi>();
            }
        }

        public string Update(DestekDepoCayOcagi entity,int id)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return cayOcagiDal.Update(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(DestekDepoCayOcagi cayOcagi)
        {
            if (string.IsNullOrEmpty(cayOcagi.Stokno))
            {
                return "Lütfen STOK NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(cayOcagi.Tanim))
            {
                return "Lütfen TANIM Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(cayOcagi.Birim))
            {
                return "Lütfen BİRİM Bilgisini doldurunuz.";
            }
            return "";
        }
        public static CayOcagiManager GetInstance()
        {
            if (cayOcagiManager == null)
            {
                cayOcagiManager = new CayOcagiManager();
            }
            return cayOcagiManager;
        }
    }
}
