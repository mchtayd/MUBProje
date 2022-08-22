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
    public class PersonelHesapManager // : IRepository<PersonelHesap>
    {
        static PersonelHesapManager personelHesapManager;
        PersonelHesapDal personelHesapDal;

        private PersonelHesapManager()
        {
            personelHesapDal = PersonelHesapDal.GetInstance();
        }

        public string Add(PersonelHesap entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PersonelHesap Get(string adSoyad)
        {
            try
            {
                return personelHesapDal.Get(adSoyad);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<PersonelHesap> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(PersonelHesap entity)
        {
            throw new NotImplementedException();
        }
        public static PersonelHesapManager GetInstance()
        {
            if (personelHesapManager == null)
            {
                personelHesapManager = new PersonelHesapManager();
            }
            return personelHesapManager;
        }
    }
}
