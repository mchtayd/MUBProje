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
    public class SatOnayTarihiManager //: IRepository<SatOnayTarihi>
    {
        static SatOnayTarihiManager satOnayTarihiManager;
        SatOnayTarihiDal satOnayTarihiDal;

        private SatOnayTarihiManager()
        {
            satOnayTarihiDal = SatOnayTarihiDal.GetInstance();
        }
        public string Add(SatOnayTarihi entity)
        {
            try
            {
                return satOnayTarihiDal.Add(entity);
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

        public SatOnayTarihi Get(string siparisNo)
        {
            try
            {
                return satOnayTarihiDal.Get(siparisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SatOnayTarihi> GetList()
        {
            throw new NotImplementedException();
        }

        public string UpdateBaslama(SatOnayTarihi entity)
        {
            try
            {
                return satOnayTarihiDal.UpdateBaslama(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateOnay(SatOnayTarihi entity)
        {
            try
            {
                return satOnayTarihiDal.UpdateOnay(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static SatOnayTarihiManager GetInstance()
        {
            if (satOnayTarihiManager == null)
            {
                satOnayTarihiManager = new SatOnayTarihiManager();
            }
            return satOnayTarihiManager;
        }
    }
}
