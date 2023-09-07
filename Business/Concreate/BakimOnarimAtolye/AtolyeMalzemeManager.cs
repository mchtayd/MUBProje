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
    public class AtolyeMalzemeManager //: IRepository<AtolyeMalzeme>
    {
        static AtolyeMalzemeManager atolyeMalzemeManager;
        AtolyeMalzemeDal atolyeMalzemeDal;

        private AtolyeMalzemeManager()
        {
            atolyeMalzemeDal = AtolyeMalzemeDal.GetInstance();
        }
        public string Add(AtolyeMalzeme entity)
        {
            try
            {
                return atolyeMalzemeDal.Add(entity);
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

        public AtolyeMalzeme Get(string stokNo, string seriNo, string revizyon)
        {
            try
            {
                return atolyeMalzemeDal.Get(stokNo, seriNo, revizyon);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AtolyeMalzeme> GetList(int abfNo)
        {
            try
            {
                return atolyeMalzemeDal.GetList(abfNo);
            }
            catch (Exception)
            {
                return new List<AtolyeMalzeme>();
            }
        }
        public List<AtolyeMalzeme> GetListDTS(int abfNo)
        {
            try
            {
                return atolyeMalzemeDal.GetListDTS(abfNo);
            }
            catch (Exception)
            {
                return new List<AtolyeMalzeme>();
            }
        }
        public List<AtolyeMalzeme> AtolyeBakimOnarimMalzeme()
        {
            try
            {
                return atolyeMalzemeDal.AtolyeBakimOnarimMalzeme();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AtolyeMalzeme> AtolyeMalzemeBul(string siparisNo)
        {
            try
            {
                return atolyeMalzemeDal.AtolyeMalzemeBul(siparisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string Update(int id, string teslimDurumu)
        {
            try
            {
                return atolyeMalzemeDal.Update(id, teslimDurumu);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static AtolyeMalzemeManager GetInstance()
        {
            if (atolyeMalzemeManager == null)
            {
                atolyeMalzemeManager = new AtolyeMalzemeManager();
            }
            return atolyeMalzemeManager;
        }
    }
}
