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
            catch (Exception)
            {
                return null;
            }
        }

        public List<PersonelHesap> GetList()
        {
            try
            {
                List<PersonelHesap> personelHesaps = new List<PersonelHesap>();
                dataReader = sqlServices.StoreReader("AktifPersonellerList");
                while (dataReader.Read())
                {
                    personelHesaps.Add(new PersonelHesap(
                        dataReader["ID"].ConInt(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["GIRIS_BILGISI"].ConDate(),
                        dataReader["SON_GORULME"].ConDate(),
                        dataReader["AKTIFLIK_SURESI"].ConInt()));
                }
                dataReader.Close();
                return personelHesaps;
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
                dataReader = sqlServices.StoreReader("LoginUpdateGiris",
                    new SqlParameter("@personelId", personelId),
                    new SqlParameter("@durum", durum),
                    new SqlParameter("@girisBilgisi", girisBilgisi));

                dataReader.Close();
                return "OK";
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
                dataReader = sqlServices.StoreReader("LoginUpdateCikis",
                    new SqlParameter("@personelId", personelId),
                    new SqlParameter("@durum", durum),
                    new SqlParameter("@sonGorulme", sonGorulme),
                    new SqlParameter("@aktiflikSuresi", toplamSure));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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
