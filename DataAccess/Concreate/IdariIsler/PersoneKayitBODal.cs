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
    public class PersoneKayitBODal : IRepository<PersonelKayitBO>
    {
        static PersoneKayitBODal personeKayitBODal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private PersoneKayitBODal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(PersonelKayitBO entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PersonelKayitBO Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<PersonelKayitBO> GetList()
        {
            try
            {
                List<PersonelKayitBO> personelKayits = new List<PersonelKayitBO>();
                dataReader = sqlServices.StoreReader("LojDestList");
                while (dataReader.Read())
                {
                    personelKayits.Add(new PersonelKayitBO(dataReader["ID"].ConInt(), dataReader["BOLUM_2"].ToString()));
                }
                dataReader.Close();
                return personelKayits;
            }
            catch
            {
                return new List<PersonelKayitBO>();
            }
        }

        public string Update(PersonelKayitBO entity)
        {
            throw new NotImplementedException();
        }
        public static PersoneKayitBODal GetInstance()
        {
            if (personeKayitBODal == null)
            {
                personeKayitBODal = new PersoneKayitBODal();
            }
            return personeKayitBODal;
        }
    }
}
