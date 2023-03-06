using DataAccess.Abstract;
using DataAccess.Concreate.AnaSayfa;
using Entity.AnaSayfa;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.AnaSayfa
{
    public class DuyuruManager //: IRepository<Duyuru>
    {
        static DuyuruManager duyuruManager;
        DuyuruDal duyuruDal;
        string controlText;

        private DuyuruManager()
        {
            duyuruDal = DuyuruDal.GetInstance();
        }
        public static DuyuruManager GetInstance()
        {
            if (duyuruManager == null)
            {
                duyuruManager = new DuyuruManager();
            }
            return duyuruManager;
        }

        public string Add(Duyuru entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return duyuruDal.Add(entity);
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
                return duyuruDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Duyuru Get(int id)
        {
            try
            {
                return duyuruDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Duyuru> GetList()
        {
            try
            {
                return duyuruDal.GetList();
            }
            catch (Exception)
            {
                return new List<Duyuru>();
            }
        }

        public string Update(Duyuru entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return duyuruDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        string Complete(Duyuru duyuru)
        {
            if (string.IsNullOrEmpty(duyuru.Konu))
            {
                return "Lütfen Duyuru Konusu Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(duyuru.DuyuruMesaj))
            {
                return "Lütfen Duyuru Mesajı Bilgisini doldurunuz.";
            }
            return "";
        }
    }
}
