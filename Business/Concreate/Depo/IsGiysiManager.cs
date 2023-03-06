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
    public class IsGiysiManager // : IRepository<DestekDepoIsGiysi>
    {
        static IsGiysiManager isGiysiManager;
        IsGiysiDal isGiysiDal;
        string controlText;

        private IsGiysiManager()
        {
            isGiysiDal = IsGiysiDal.GetInstance();
        }

        public string Add(DestekDepoIsGiysi entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return isGiysiDal.Add(entity);
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
                return isGiysiDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DestekDepoIsGiysi Get(int id)
        {
            try
            {
                return isGiysiDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DestekDepoIsGiysi GetTanim(string tanim)
        {
            try
            {
                return isGiysiDal.GetTanim(tanim);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DestekDepoIsGiysi GetStokNo(string stokNo)
        {
            try
            {
                return isGiysiDal.GetStokNo(stokNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DestekDepoIsGiysi> GetList(int id=0)
        {
            try
            {
                return isGiysiDal.GetList(id);
            }
            catch (Exception)
            {
                return new List<DestekDepoIsGiysi>();
            }
        }

        public string Update(DestekDepoIsGiysi entity,int id)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return isGiysiDal.Update(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(DestekDepoIsGiysi destekDepoIsGiysi)
        {
            if (string.IsNullOrEmpty(destekDepoIsGiysi.Stokno))
            {
                return "Lütfen STOK NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(destekDepoIsGiysi.Tanim))
            {
                return "Lütfen TANIM Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(destekDepoIsGiysi.Birim))
            {
                return "Lütfen BİRİM Bilgisini doldurunuz.";
            }
            return "";
        }
        public static IsGiysiManager GetInstance()
        {
            if (isGiysiManager == null)
            {
                isGiysiManager = new IsGiysiManager();
            }
            return isGiysiManager;
        }
    }
}
