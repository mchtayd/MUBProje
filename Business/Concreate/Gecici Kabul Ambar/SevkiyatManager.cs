using Business.Concreate.Depo;
using DataAccess.Abstract;
using DataAccess.Concreate.Depo;
using DataAccess.Concreate.Gecici_Kabul_Ambar;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Gecici_Kabul_Ambar
{
    public class SevkiyatManager //: IRepository<Sevkiyat>
    {
        static SevkiyatManager sevkiyatManager;
        SevkiyatDal sevkiyatDal;

        private SevkiyatManager()
        {
            sevkiyatDal = SevkiyatDal.GetInstance();
        }
        public static SevkiyatManager GetInstance()
        {
            if (sevkiyatManager == null)
            {
                sevkiyatManager = new SevkiyatManager();
            }
            return sevkiyatManager;
        }

        public string Add(Sevkiyat entity)
        {
            try
            {
                return sevkiyatDal.Add(entity);
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
                return sevkiyatDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Sevkiyat Get(int id)
        {
            try
            {
                return sevkiyatDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Sevkiyat GetSonKayit()
        {
            try
            {
                return sevkiyatDal.GetSonKayit();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Sevkiyat> GetList()
        {
            try
            {
                return sevkiyatDal.GetList();
            }
            catch (Exception)
            {
                return new List<Sevkiyat>();
            }
        }

        public string Update(Sevkiyat entity,int id)
        {
            try
            {
                return sevkiyatDal.Update(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
