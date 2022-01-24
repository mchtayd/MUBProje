using DataAccess.Abstract;
using DataAccess.Concreate.BakimOnarimAtolye;
using Entity.BakimOnarimAtolye;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.BakimOnarimAtolye
{
    public class AtolyeAltMalzemeManager //: IRepository<AtolyeAltMalzeme>
    {
        static AtolyeAltMalzemeManager atolyeAltMalzemeManager;
        AtolyeAltMalzemeDal atolyeAltMalzemeDal;

        private AtolyeAltMalzemeManager()
        {
            atolyeAltMalzemeDal = AtolyeAltMalzemeDal.GetInstance();
        }
        public string Add(AtolyeAltMalzeme entity)
        {
            try
            {
                return atolyeAltMalzemeDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AtolyeAltMalzeme Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<AtolyeAltMalzeme> GetList(string siparisNo)
        {
            try
            {
                return atolyeAltMalzemeDal.GetList(siparisNo);
            }
            catch (Exception)
            {
                return new List<AtolyeAltMalzeme>();
            }
        }

        public string Update(AtolyeAltMalzeme entity)
        {
            try
            {
                return atolyeAltMalzemeDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static AtolyeAltMalzemeManager GetInstance()
        {
            if (atolyeAltMalzemeManager == null)
            {
                atolyeAltMalzemeManager = new AtolyeAltMalzemeManager();
            }
            return atolyeAltMalzemeManager;
        }
    }
}
