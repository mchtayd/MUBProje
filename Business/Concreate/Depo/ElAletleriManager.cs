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
    public class ElAletleriManager // : IRepository<DestekDepoElAletleri>
    {
        static ElAletleriManager elAletleriManager;
        ElAletleriDal elAletleriDal;
        string controlText;

        private ElAletleriManager()
        {
            elAletleriDal = ElAletleriDal.GetInstance();
        }
        public string Add(DestekDepoElAletleri entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return elAletleriDal.Add(entity);
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
                return elAletleriDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DestekDepoElAletleri Get(int id)
        {
            try
            {
                return elAletleriDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DestekDepoElAletleri GetTanim(string tanim)
        {
            try
            {
                return elAletleriDal.GetTanim(tanim);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DestekDepoElAletleri> GetList(int id=0)
        {
            try
            {
                return elAletleriDal.GetList(id);
            }
            catch (Exception)
            {
                return new List<DestekDepoElAletleri>();
            }
        }

        public string Update(DestekDepoElAletleri entity,int id)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return elAletleriDal.Update(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(DestekDepoElAletleri elAletleri)
        {
            if (string.IsNullOrEmpty(elAletleri.Stokno))
            {
                return "Lütfen STOK NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(elAletleri.Tanim))
            {
                return "Lütfen TANIM Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(elAletleri.Birim))
            {
                return "Lütfen BİRİM Bilgisini doldurunuz.";
            }
            return "";
        }
        public static ElAletleriManager GetInstance()
        {
            if (elAletleriManager == null)
            {
                elAletleriManager = new ElAletleriManager();
            }
            return elAletleriManager;
        }
    }
}
