using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Yerleskeler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PersonelDal// : IRepository<Personel>
    {
        static PersonelDal personelDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private PersonelDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Personel entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("PersonellerlEkle",
                    new SqlParameter("@personelId", entity.PersonelId),
                    new SqlParameter("@sicilNo", entity.SicilNo),
                    new SqlParameter("@personelAd", entity.PersonelAd),
                    new SqlParameter("@yetkiId", entity.YetkiId));

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

        public Personel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Personel> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(Personel entity)
        {
            throw new NotImplementedException();
        }
        public static PersonelDal GetInstance()
        {
            if (personelDal == null)
            {
                personelDal = new PersonelDal();
            }
            return personelDal;
        }
    }
}
