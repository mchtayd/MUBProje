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
    public class PersonelKayitIdariManager : IRepository<PersonelKayitIdari>
    {
        static PersonelKayitIdariManager personelKayitIdariManager;
        PersonelKayitIdariDal personelKayitIdariDal;
        private PersonelKayitIdariManager()
        {
            personelKayitIdariDal = PersonelKayitIdariDal.GetInstance();
        }

        public string Add(PersonelKayitIdari entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PersonelKayitIdari Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<PersonelKayitIdari> GetList()
        {
            try
            {
                return personelKayitIdariDal.GetList();
            }
            catch
            {
                return new List<PersonelKayitIdari>();
            }
        }
        public List<PersonelKayitIdari> Bolum3()
        {
            try
            {
                return personelKayitIdariDal.Bolum3();
            }
            catch
            {
                return new List<PersonelKayitIdari>();
            }
        }
        public List<PersonelKayitIdari> Bolum3Gun()
        {
            try
            {
                return personelKayitIdariDal.Bolum3Gun();
            }
            catch
            {
                return new List<PersonelKayitIdari>();
            }
        }
        public List<PersonelKayitIdari> Bolum3SahaDestek()
        {
            try
            {
                return personelKayitIdariDal.Bolum3SahaDestek();
            }
            catch
            {
                return new List<PersonelKayitIdari>();
            }
        }
        public string Update(PersonelKayitIdari entity)
        {
            throw new NotImplementedException();
        }
        public static PersonelKayitIdariManager GetInstance()
        {
            if (personelKayitIdariManager == null)
            {
                personelKayitIdariManager = new PersonelKayitIdariManager();
            }
            return personelKayitIdariManager;
        }
    }
}
