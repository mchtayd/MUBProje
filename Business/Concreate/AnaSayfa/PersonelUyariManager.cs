using DataAccess.Abstract;
using DataAccess.Concreate.AnaSayfa;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.AnaSayfa
{
    public class PersonelUyariManager //: IRepository<PersonelUyari>
    {
        static PersonelUyariManager personelUyariManager;
        PersonelUyariDal personelUyariDal;

        private PersonelUyariManager()
        {
            personelUyariDal = PersonelUyariDal.GetInstance();
        }

        public static PersonelUyariManager GetInstance()
        {
            if (personelUyariManager == null)
            {
                personelUyariManager = new PersonelUyariManager();
            }
            return personelUyariManager;
        }

        public string Add(PersonelUyari entity)
        {
            try
            {
                return personelUyariDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                return personelUyariDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public PersonelUyari Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<PersonelUyari> GetList(string personel)
        {
            try
            {
                return personelUyariDal.GetList(personel);
            }
            catch (Exception)
            {
                return new List<PersonelUyari>();
            }
        }
        public List<PersonelUyari> PersonelGetList(string personel, string gorulmeDurumu)
        {
            try
            {
                return personelUyariDal.PersonelGetList(personel, gorulmeDurumu);
            }
            catch (Exception)
            {
                return new List<PersonelUyari>();
            }
        }


        public string Update(int id)
        {
            try
            {
                return personelUyariDal.Update(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
