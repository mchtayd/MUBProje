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
    public class PersonelKayitBOManager : IRepository<PersonelKayitBO>
    {
        static PersonelKayitBOManager personelKayitBOManager;
        PersoneKayitBODal personeKayitBODal;
        private PersonelKayitBOManager()
        {
            personeKayitBODal = PersoneKayitBODal.GetInstance();
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
                return personeKayitBODal.GetList();
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
        public static PersonelKayitBOManager GetInstance()
        {
            if (personelKayitBOManager == null)
            {
                personelKayitBOManager = new PersonelKayitBOManager();
            }
            return personelKayitBOManager;
        }
    }
}
