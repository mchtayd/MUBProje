using DataAccess.Abstract;
using DataAccess.Database;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PersonelIslemleriDal
    {
        static PersonelIslemleriDal personelDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private PersonelIslemleriDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(PersonelIslemleri entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PersonelIslemleri Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<PersonelIslemleri> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(PersonelIslemleri entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SifreGuncelle", new SqlParameter("@sicilno", entity.Sicilno), new SqlParameter("@sifre", entity.Sifre));
                dataReader.Close();
                return "Şifreniz Başarıyla Güncellendi.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static PersonelIslemleriDal GetInstance()
        {
            if (personelDal == null)
            {
                personelDal = new PersonelIslemleriDal();
            }
            return personelDal;
        }
    }
}
