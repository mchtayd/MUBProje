using DataAccess.Abstract;
using DataAccess.Database;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.IdariIsler
{
    public class PersonelHesapDal //: IRepository<PersonelHesap>
    {
        static PersonelHesapDal personelHesapDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private PersonelHesapDal()
        {
            sqlServices = SqlDatabase.GetInstance();
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
                dataReader = sqlServices.StoreReader("PersonelHesaplar", new SqlParameter("@adSoyad", adSoyad));
                PersonelHesap item = null;
                while (dataReader.Read())
                {
                    item = new PersonelHesap(
                        dataReader["ID"].ConInt(),
                        dataReader["SICILNO"].ToString(),
                        dataReader["SIFRE"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["YETKI"].ConInt(),
                        dataReader["FotoYolu"].ToString(),
                        dataReader["YETKI_MODU"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
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
        public static PersonelHesapDal GetInstance()
        {
            if (personelHesapDal == null)
            {
                personelHesapDal = new PersonelHesapDal();
            }
            return personelHesapDal;
        }
    }
}
