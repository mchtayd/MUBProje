using DataAccess.Abstract;
using DataAccess.Concreate;
using DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class PersonelKayitIdariDal : IRepository<PersonelKayitIdari>
    {
        static PersonelKayitIdariDal personelKayitIdari;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private PersonelKayitIdariDal()
        {
            sqlServices = SqlDatabase.GetInstance();
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
                List<PersonelKayitIdari> personelKayits = new List<PersonelKayitIdari>();
                dataReader = sqlServices.StoreReader("IdariIslerList");
                while (dataReader.Read())
                {
                    personelKayits.Add(new PersonelKayitIdari(
                        dataReader["ID"].ConInt(),
                        dataReader["IDARI_BOLUM_2"].ToString()));
                }
                dataReader.Close();
                return personelKayits;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<PersonelKayitIdari> Bolum3()
        {
            try
            {
                List<PersonelKayitIdari> personelKayits = new List<PersonelKayitIdari>();
                dataReader = sqlServices.StoreReader("DestHizList");
                while (dataReader.Read())
                {
                    personelKayits.Add(new PersonelKayitIdari(
                        dataReader["ID"].ConInt(),
                        dataReader["BOLUM_3"].ToString()));
                }
                dataReader.Close();
                return personelKayits;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<PersonelKayitIdari> Bolum3Gun()
        {
            try
            {
                List<PersonelKayitIdari> personelKayits = new List<PersonelKayitIdari>();
                dataReader = sqlServices.StoreReader("Bolum3");
                while (dataReader.Read())
                {
                    personelKayits.Add(new PersonelKayitIdari(
                        dataReader["ID"].ConInt(),
                        dataReader["BOLUM_3"].ToString()));
                }
                dataReader.Close();
                return personelKayits;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<PersonelKayitIdari> Bolum3SahaDestek()
        {
            try
            {
                List<PersonelKayitIdari> personelKayits = new List<PersonelKayitIdari>();
                dataReader = sqlServices.StoreReader("SahaDestekMuhList");
                while (dataReader.Read())
                {
                    personelKayits.Add(new PersonelKayitIdari(
                        dataReader["ID"].ConInt(),
                        dataReader["BOLUM_3"].ToString()));
                }
                dataReader.Close();
                return personelKayits;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Update(PersonelKayitIdari entity)
        {
            throw new NotImplementedException();
        }
        public static PersonelKayitIdariDal GetInstance()
        {
            if (personelKayitIdari == null)
            {
                personelKayitIdari = new PersonelKayitIdariDal();
            }
            return personelKayitIdari;
        }
    }
}
