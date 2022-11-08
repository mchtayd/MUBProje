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
    public class TemizlikUrunleriManager //: IRepository<DestekDepoTemizlikUrunleri>
    {
        static TemizlikUrunleriManager temizlikUrunleriManager;
        TemizlikUrunleriDal temizlikUrunleriDal;
        string controlText;

        private TemizlikUrunleriManager()
        {
            temizlikUrunleriDal = TemizlikUrunleriDal.GetInstance();
        }
        public string Add(DestekDepoTemizlikUrunleri entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return temizlikUrunleriDal.Add(entity);
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
                return temizlikUrunleriDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DestekDepoTemizlikUrunleri Get(int id)
        {
            try
            {
                return temizlikUrunleriDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DestekDepoTemizlikUrunleri GetTanim(string tanim)
        {
            try
            {
                return temizlikUrunleriDal.GetTanim(tanim);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DestekDepoTemizlikUrunleri GetStokNo(string stokNo)
        {
            try
            {
                return temizlikUrunleriDal.GetStokNo(stokNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DestekDepoTemizlikUrunleri> GetList(int id =0)
        {
            try
            {
                return temizlikUrunleriDal.GetList(id);
            }
            catch (Exception)
            {
                return new List<DestekDepoTemizlikUrunleri>();
            }
        }

        public string Update(DestekDepoTemizlikUrunleri entity,int id)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return temizlikUrunleriDal.Update(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(DestekDepoTemizlikUrunleri temizlikUrunleri)
        {
            if (string.IsNullOrEmpty(temizlikUrunleri.Stokno))
            {
                return "Lütfen STOK NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(temizlikUrunleri.Tanim))
            {
                return "Lütfen TANIM Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(temizlikUrunleri.Birim))
            {
                return "Lütfen BİRİM Bilgisini doldurunuz.";
            }
            return "";
        }
        public static TemizlikUrunleriManager GetInstance()
        {
            if (temizlikUrunleriManager == null)
            {
                temizlikUrunleriManager = new TemizlikUrunleriManager();
            }
            return temizlikUrunleriManager;
        }
    }
}
