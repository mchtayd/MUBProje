using DataAccess.Abstract;
using DataAccess.Database;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.IdariIsler
{
    public class PersonelKayitLojistikDal : IRepository<PersonelKayitLojistik>
    {
        static PersonelKayitLojistikDal personelKayitLojistikDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private PersonelKayitLojistikDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(PersonelKayitLojistik entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PersonelKayitLojistik Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<PersonelKayitLojistik> GetList()
        {
            try
            {
                List<PersonelKayitLojistik> personelKayits = new List<PersonelKayitLojistik>();
                dataReader = sqlServices.StoreReader("SisBakimOnarimList");
                while (dataReader.Read())
                {
                    personelKayits.Add(new PersonelKayitLojistik(dataReader["ID"].ConInt(),dataReader["BOLUM_ADI"].ToString()));
                }
                dataReader.Close();
                return personelKayits;
            }
            catch
            {
                return new List<PersonelKayitLojistik>();
            }
        }

        public string Update(PersonelKayitLojistik entity)
        {
            throw new NotImplementedException();
        }
        public static PersonelKayitLojistikDal GetInstance()
        {
            if (personelKayitLojistikDal == null)
            {
                personelKayitLojistikDal = new PersonelKayitLojistikDal();
            }
            return personelKayitLojistikDal;
        }
    }
}
