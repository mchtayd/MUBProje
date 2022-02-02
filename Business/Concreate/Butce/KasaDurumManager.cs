using DataAccess.Abstract;
using DataAccess.Concreate.Butce;
using Entity.Butce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Butce
{
    public class KasaDurumManager // : IRepository<KasaDurum>
    {
        static KasaDurumManager kasaDurumManager;
        KasaDurumDal kasaDurumDal;

        private KasaDurumManager()
        {
            kasaDurumDal = KasaDurumDal.GetInstance();
        }
        public string Add(KasaDurum entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public KasaDurum Get(int id)
        {
            try
            {
                return kasaDurumDal.Get(id);
            }
            catch (Exception EX)
            {
                return null;
            }
        }

        public List<KasaDurum> GetList()
        {
            throw new NotImplementedException();
        }

        public string UpdateGelir(double kasaGelir)
        {
            try
            {
                return kasaDurumDal.UpdateGelir(kasaGelir);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateGider(double kasaGider)
        {
            try
            {
                return kasaDurumDal.UpdateGider(kasaGider);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static KasaDurumManager GetInstance()
        {
            if (kasaDurumManager == null)
            {
                kasaDurumManager = new KasaDurumManager();
            }
            return kasaDurumManager;
        }
    }
}
