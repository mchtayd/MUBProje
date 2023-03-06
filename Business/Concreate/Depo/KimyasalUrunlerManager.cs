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
    public class KimyasalUrunlerManager // : IRepository<DestekDepoKimyasalUrunler>
    {
        static KimyasalUrunlerManager kimyasalUrunlerManager;
        KimyasalUrunlerDal kimyasalUrunlerDal;
        string controlText;

        private KimyasalUrunlerManager()
        {
            kimyasalUrunlerDal = KimyasalUrunlerDal.GetInstance();
        }
        public string Add(DestekDepoKimyasalUrunler entity)
        {

            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return kimyasalUrunlerDal.Add(entity);
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
                return kimyasalUrunlerDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DestekDepoKimyasalUrunler Get(int id)
        {
            try
            {
                return kimyasalUrunlerDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DestekDepoKimyasalUrunler> GetList(int id=0)
        {
            try
            {
                return kimyasalUrunlerDal.GetList(id);
            }
            catch (Exception)
            {
                return new List<DestekDepoKimyasalUrunler>();
            }
        }

        public string Update(DestekDepoKimyasalUrunler entity, int id)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return kimyasalUrunlerDal.Update(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(DestekDepoKimyasalUrunler kimyasalUrunler)
        {
            if (string.IsNullOrEmpty(kimyasalUrunler.StokNo))
            {
                return "Lütfen STOK NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(kimyasalUrunler.Tanim))
            {
                return "Lütfen TANIM Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(kimyasalUrunler.Birim))
            {
                return "Lütfen BİRİM Bilgisini doldurunuz.";
            }
            return "";
        }
        public static KimyasalUrunlerManager GetInstance()
        {
            if (kimyasalUrunlerManager == null)
            {
                kimyasalUrunlerManager = new KimyasalUrunlerManager();
            }
            return kimyasalUrunlerManager;
        }
    }
}
