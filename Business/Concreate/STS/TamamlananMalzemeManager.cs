using DataAccess.Abstract;
using DataAccess.Concreate.STS;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.STS
{
    public class TamamlananMalzemeManager //: IRepository<TamamlananMalzeme>
    {
        static TamamlananMalzemeManager tamamlananMalzemeManager;
        TamamlananMalzemeDal tamamlananMalzemeDal;
        private TamamlananMalzemeManager()
        {
            tamamlananMalzemeDal = TamamlananMalzemeDal.GetInstance();
        }
        public string Add(TamamlananMalzeme entity)
        {
            try
            {
                return tamamlananMalzemeDal.Add(entity);
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

        public TamamlananMalzeme Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TamamlananMalzeme> GetList(string siparisno)
        {
            try
            {
                return tamamlananMalzemeDal.GetList(siparisno);
            }
            catch
            {
                return new List<TamamlananMalzeme>();
            }
        }

        public string UpdateFiyat(TamamlananMalzeme entity)
        {
            try
            {
                return tamamlananMalzemeDal.UpdateFiyat(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Update(TamamlananMalzeme entity)
        {
            try
            {
                return tamamlananMalzemeDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static TamamlananMalzemeManager GetInstance()
        {
            if (tamamlananMalzemeManager == null)
            {
                tamamlananMalzemeManager = new TamamlananMalzemeManager();
            }
            return tamamlananMalzemeManager;
        }
    }
}
