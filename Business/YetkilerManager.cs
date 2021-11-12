using DataAccess;
using DataAccess.Abstract;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class YetkilerManager // : IRepository<Yetki>
    {
        static YetkilerManager yetkilerManager;
        YetkilerDal yetkilerDal;
        string controlText;
        private YetkilerManager()
        {
            yetkilerDal = YetkilerDal.GetInstance();
        }
        public string Add(Yetki entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Yetki Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Yetki> GetList()
        {
            try
            {
                return yetkilerDal.GetList();
            }
            catch
            {
                return new List<Yetki>();
            }
        }

        public string Update(Yetki entity,int id)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return yetkilerDal.Update(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static YetkilerManager GetInstance()
        {
            if (yetkilerManager == null)
            {
                yetkilerManager = new YetkilerManager();
            }
            return yetkilerManager;
        }
        string Complete(Yetki yetki)
        {
            if (string.IsNullOrEmpty(yetki.IzinIdleri))
            {
                return "Lütfe Personel Yetkilerini Belirtiniz.";
            }
            return "";
        }
    }
}
