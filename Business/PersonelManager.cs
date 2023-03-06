using DataAccess;
using DataAccess.Abstract;
using Entity.Yerleskeler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PersonelManager //: IRepository<Personel>
    {
        static PersonelManager personelManager;
        PersonelDal personelDal;


        private PersonelManager()
        {
            personelDal = PersonelDal.GetInstance();
        }

        public string Add(Personel entity)
        {
            try
            {
                return personelDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Personel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Personel> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(Personel entity)
        {
            throw new NotImplementedException();
        }
        public static PersonelManager GetInstance()
        {
            if (personelManager == null)
            {
                personelManager = new PersonelManager();
            }
            return personelManager;
        }
    }
}
