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
    public class IscilikIscilikManager // : IRepository<IscilikIscilik>
    {
        static IscilikIscilikManager iscilikManager;
        IscilikIscilikDal iscilikDal;
        string controlText;

        private IscilikIscilikManager()
        {
            iscilikDal = IscilikIscilikDal.GetInstance();
        }
        public string Add(IscilikIscilik entity)
        {
            try
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

        public IscilikIscilik Get(string adSoyad)
        {
            try
            {
                return iscilikDal.Get(adSoyad);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<IscilikIscilik> GetList(string adSoyad)
        {
            try
            {
                return iscilikDal.GetList(adSoyad);
            }
            catch (Exception)
            {
                return new List<IscilikIscilik>();
            }
        }

        public string Update(IscilikIscilik entity)
        {
            try
            {
                return iscilikDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(IscilikIscilik ıscilikIscilik)
        {
            if (string.IsNullOrEmpty(ıscilikIscilik.AbfSiparis))
            {
                return "Lütfen ABF NO Bilgisini doldurunuz.";
            }
            return "";
        }
        public static IscilikIscilikManager GetInstance()
        {
            if (iscilikManager == null)
            {
                iscilikManager = new IscilikIscilikManager();
            }
            return iscilikManager;
        }
    }
}
