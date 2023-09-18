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
    public class SevkiyatMalzemeManager //: IRepository<SevkiyatMalzeme>
    {
        static SevkiyatMalzemeManager sevkiyatMalzemeManager;
        SevkiyatMalzemeDal sevkiyatMalzemeDal;
        string controlText;

        private SevkiyatMalzemeManager()
        {
            sevkiyatMalzemeDal = SevkiyatMalzemeDal.GetInstance();
        }

        public static SevkiyatMalzemeManager GetInstance()
        {
            if (sevkiyatMalzemeManager == null)
            {
                sevkiyatMalzemeManager = new SevkiyatMalzemeManager();
            }
            return sevkiyatMalzemeManager;
        }
        public string Add(SevkiyatMalzeme entity)
        {
            try
            {
                return sevkiyatMalzemeDal.Add(entity);
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
                return sevkiyatMalzemeDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SevkiyatMalzeme Get(int id)
        {
            try
            {
                return sevkiyatMalzemeDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SevkiyatMalzeme> GetList(int benzersizId)
        {
            try
            {
                return sevkiyatMalzemeDal.GetList(benzersizId);
            }
            catch (Exception)
            {
                return new List<SevkiyatMalzeme>();
            }
        }

        public string Update(SevkiyatMalzeme entity)
        {
            throw new NotImplementedException();
        }
    }
}
