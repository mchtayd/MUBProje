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
            try
            {
                return personelHesapDal.GetList();
            }
            catch (Exception)
            {
                return new List<PersonelHesap>();
            }
        }

        public string Update(int personelId, string durum, DateTime girisBilgisi)
        {
            try
            {
                return personelHesapDal.Update(personelId, durum, girisBilgisi);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdatePasif(int personelId, string durum, DateTime sonGorulme, int toplamSure)
        {
            try
            {
                return personelHesapDal.UpdatePasif(personelId, durum, sonGorulme, toplamSure);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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
