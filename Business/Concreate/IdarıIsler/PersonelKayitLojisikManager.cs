using DataAccess.Abstract;
using DataAccess.Concreate.IdariIsler;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.IdarıIsler
{
    public class PersonelKayitLojisikManager : IRepository<PersonelKayitLojistik>
    {
        static PersonelKayitLojisikManager personelKayitLojisikManager;
        PersonelKayitLojistikDal personelKayitLojistikDal;
        private PersonelKayitLojisikManager()
        {
            personelKayitLojistikDal = PersonelKayitLojistikDal.GetInstance();
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
                return personelKayitLojistikDal.GetList();
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
        public static PersonelKayitLojisikManager GetInstance()
        {
            if (personelKayitLojisikManager == null)
            {
                personelKayitLojisikManager = new PersonelKayitLojisikManager();
            }
            return personelKayitLojisikManager;
        }
    }
}
