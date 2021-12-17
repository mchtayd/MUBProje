using DataAccess.Abstract;
using DataAccess.Concreate.BakimOnarim;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.BakimOnarim
{
    public class IscilikDesteIscilikManager //: IRepository<IscilikDestekIscilik>
    {
        static IscilikDesteIscilikManager iscilikManager;
        IscilikDestekIsciliklDal iscilikDal;
        string controlText;

        private IscilikDesteIscilikManager()
        {
            iscilikDal = IscilikDestekIsciliklDal.GetInstance();
        }
        public string Add(IscilikDestekIscilik entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return iscilikDal.Add(entity);
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
                return iscilikDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IscilikDestekIscilik Get(string siparisNo)
        {
            try
            {
                return iscilikDal.Get(siparisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<IscilikDestekIscilik> GetList(string adSoyad="",string plaka="")
        {
            try
            {
                return iscilikDal.GetList(adSoyad, plaka);
            }
            catch (Exception)
            {
                return new List<IscilikDestekIscilik>();
            }
        }
        public List<IscilikDestekTablo> GetListCellClickPersonel(string siparisNo)
        {
            try
            {
                return iscilikDal.GetListCellClickPersonel(siparisNo);
            }
            catch (Exception)
            {
                return new List<IscilikDestekTablo>();
            }
        }
        public List<IscilikDestekTabloArac> GetListCellClickArac(string siparisNo)
        {
            try
            {
                return iscilikDal.GetListCellClickArac(siparisNo);
            }
            catch (Exception)
            {
                return new List<IscilikDestekTabloArac>();
            }
        }

        public string Update(IscilikDestekIscilik entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return iscilikDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(IscilikDestekIscilik destekIscilik)
        {
            if (string.IsNullOrEmpty(destekIscilik.IscilikTuru))
            {
                return "Lütfen İŞÇİLİK TÜRÜ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(destekIscilik.DestekTuru))
            {
                return "Lütfen DESTEK TÜRÜ Bilgisini doldurunuz.";
            }
            
            return "";
        }
        public static IscilikDesteIscilikManager GetInstance()
        {
            if (iscilikManager == null)
            {
                iscilikManager = new IscilikDesteIscilikManager();
            }
            return iscilikManager;
        }
    }
}
