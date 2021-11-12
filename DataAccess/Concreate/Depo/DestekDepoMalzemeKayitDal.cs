using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Depo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate
{
    public class DestekDepoMalzemeKayitDal// : IRepository<DesteDepoMalzemeKayit>
    {

        static DestekDepoMalzemeKayitDal destekDepoMalzemeKayitDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private DestekDepoMalzemeKayitDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(DesteDepoMalzemeKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoMalzemeKaydet",
                    new SqlParameter("@stokno",entity.Stokno),
                    new SqlParameter("@tanim",entity.Tanim),
                    new SqlParameter("@birim",entity.Birim));
                dataReader.Close();
                return "OK";
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
        public static DestekDepoMalzemeKayitDal GetInstance()
        {
            if (destekDepoMalzemeKayitDal == null)
            {
                destekDepoMalzemeKayitDal = new DestekDepoMalzemeKayitDal();
            }
            return destekDepoMalzemeKayitDal;
        }
    }
}
