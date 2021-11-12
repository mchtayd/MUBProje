using DataAccess.Abstract;
using DataAccess.Concreate;
using Entity.Depo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Depo
{
    public class DestekDepoMalzemeKayitManager // : IRepository<DesteDepoMalzemeKayit>
    {
        static DestekDepoMalzemeKayitManager malzemeKayitManager;
        DestekDepoMalzemeKayitDal malzemeKayitDal;
        string controlText;

        private DestekDepoMalzemeKayitManager()
        {
            malzemeKayitDal = DestekDepoMalzemeKayitDal.GetInstance();
        }
        public string Add(DesteDepoMalzemeKayit entity)
        {
            try
            {
                return malzemeKayitDal.Add(entity);
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

        public DesteDepoMalzemeKayit Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<DesteDepoMalzemeKayit> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(DesteDepoMalzemeKayit entity)
        {
            throw new NotImplementedException();
        }
        public static DestekDepoMalzemeKayitManager GetInstance()
        {
            if (malzemeKayitManager == null)
            {
                malzemeKayitManager = new DestekDepoMalzemeKayitManager();
            }
            return malzemeKayitManager;
        }
    }
}
