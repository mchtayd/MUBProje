using DataAccess;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PersonelIslemleriManager : IRepository<PersonelIslemleri>
    {
        static PersonelIslemleriManager personelManager;
        PersonelIslemleriDal personelDal;
        string controlText;
        private PersonelIslemleriManager()
        {
            personelDal = PersonelIslemleriDal.GetInstance();
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
                controlText = IsSifreComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return personelDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string IsSifreComplete(PersonelIslemleri personel)
        {
            if (string.IsNullOrEmpty(personel.Sicilno))
            {
                return "Sicil Numarası Algılanamadı.";
            }
            if (string.IsNullOrEmpty(personel.Sifre))
            {
                return "Lütfen Yeni Şifreyi Giriniz.";
            }
            return "";
        }
        public static PersonelIslemleriManager GetInstance()
        {
            if (personelManager == null)
            {
                personelManager = new PersonelIslemleriManager();
            }
            return personelManager;
        }
    }
}
