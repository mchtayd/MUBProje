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
    public class YolDurumManager //: IRepository<YolDurum>
    {
        static YolDurumManager yolDurumManager;
        YolDurumDal yolDurumDal;

        private YolDurumManager()
        {
            yolDurumDal = YolDurumDal.GetInstance();
        }
        public static YolDurumManager GetInstance()
        {
            if (yolDurumManager == null)
            {
                yolDurumManager = new YolDurumManager();
            }
            return yolDurumManager;
        }

        public string Add(YolDurum entity)
        {
            try
            {
                return yolDurumDal.Add(entity);
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

        public YolDurum Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<YolDurum> GetList(string bolgeAdi, DateTime basTarihi, DateTime bitTarihi)
        {
            try
            {
                return yolDurumDal.GetList(bolgeAdi, basTarihi, bitTarihi);
            }
            catch (Exception)
            {
                return new List<YolDurum>();
            }
        }
        public List<YolDurum> GetListTum(DateTime basTarihi, DateTime bitTarihi)
        {
            try
            {
                return yolDurumDal.GetListTum(basTarihi, bitTarihi);
            }
            catch (Exception)
            {
                return new List<YolDurum>();
            }
        }

        public string Update(YolDurum entity)
        {
            try
            {
                return yolDurumDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
