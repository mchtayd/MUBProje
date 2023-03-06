using DataAccess.Abstract;
using DataAccess.Concreate;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class PersonelManager //: IRepository <Personel>
    {
        static PersonelManager personelManager;
        PersonelDal personelDal;
        string controlText;

        private PersonelManager()
        {
            personelDal = PersonelDal.GetInstance();
        }
        public string Add(Personel entity)
        {
            try
            {
                controlText = IsMasYerNoComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return personelDal.Add(entity);
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
                if (id < 1)
                {
                    return "Lütfen Geçerli Bir Personel Seçiniz.";
                }
                return personelDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Personel Get(int id)
        {
            return null;
        }

        public List<Personel> GetList()
        {
            try
            {
                return personelDal.GetList();
            }
            catch
            {
                return new List<Personel>();
            }
        }

        public string Update(Personel entity)
        {
            try
            {
                if (entity.Id < 1)
                {
                    return "Lütfen Geçerli Personel Numarası Seçiniz.";
                }
                controlText = IsMasYerNoComplete(entity);
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

        string IsMasYerNoComplete(Personel personel)
        {
            if (string.IsNullOrEmpty(personel.Sicilno))
            {
                return "Lütfen Bir Sicil Numarası Giriniz.";
            }
            if (personel.Sicilno.Length > 4)
            {
                return "Lütfen en fazla 4 karakter sicil numarası giriniz.";
            }
            return "";
        }

        public static PersonelManager GetInstance()
        {
            if (personelManager == null)
            {
                personelManager = new PersonelManager();
            }
            return personelManager;
        }

        public object[] Login(string sicilno, string sifre)
        {
            try
            {
                return personelDal.Login(sicilno.Trim(),sifre.Trim());
            }
            catch
            {
                return null;
            }
        }
    }
}
