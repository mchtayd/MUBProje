using DataAccess.Abstract;
using DataAccess.Database;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.AnaSayfa
{
    public class PersonelUyariDal //: IRepository<PersonelUyari>
    {
        static PersonelUyariDal personelUyariDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private PersonelUyariDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static PersonelUyariDal GetInstance()
        {
            if (personelUyariDal == null)
            {
                personelUyariDal = new PersonelUyariDal();
            }
            return personelUyariDal;
        }

        public string Add(PersonelUyari entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("PersonelUyariEkle",
                    new SqlParameter("@abfNo",entity.AbfNo),
                    new SqlParameter("@uyarmaTarihi",entity.UyarmaTarihi),
                    new SqlParameter("@uyaranPersonel",entity.UyaranPersonel),
                    new SqlParameter("@uyarilanPersonel",entity.UyarilanPersonel),
                    new SqlParameter("@mesajId",entity.MesajId));
                dataReader.Close();
                return "OK";
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
                sqlServices.Stored("PersonelUyariDelete", new SqlParameter("@id", id));
                return "OK";
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

        public List<PersonelUyari> PersonelGetList(string personelAdi, string gorulmeDurumu)
        {
            try
            {
                List<PersonelUyari> personelUyaris = new List<PersonelUyari>();
                dataReader = sqlServices.StoreReader("PersonelUyariPersonelList", new SqlParameter("@personelAdi", personelAdi), new SqlParameter("@gorulmeDurumu", gorulmeDurumu));
                while (dataReader.Read())
                {
                    personelUyaris.Add(new PersonelUyari(
                        dataReader["ID"].ConInt(),
                        dataReader["ABF_NO"].ConInt(),
                        dataReader["UYARMA_TARIHI"].ConDate(),
                        dataReader["UYARAN_PERSONEL"].ToString(),
                        dataReader["UYARILAN_PERSONEL"].ToString(),
                        dataReader["MESAJ_ID"].ConInt(),
                        dataReader["GORUNME_DURUMU"].ToString(),
                        dataReader["GORULME_TARIHI"].ConDate(),
                        dataReader["UYARI_MIKTAR"].ConInt()));
                }
                dataReader.Close();
                return personelUyaris;
            }
            catch (Exception)
            {
                return new List<PersonelUyari>();
            }
        }
        public List<PersonelUyari> GetList(string personelAdi)
        {
            try
            {
                List<PersonelUyari> personelUyaris = new List<PersonelUyari>();
                dataReader = sqlServices.StoreReader("PersonelUyariList", new SqlParameter("@personelAdi", personelAdi));
                while (dataReader.Read())
                {
                    personelUyaris.Add(new PersonelUyari(
                        dataReader["ID"].ConInt(),
                        dataReader["ABF_NO"].ConInt(),
                        dataReader["UYARMA_TARIHI"].ConDate(),
                        dataReader["UYARAN_PERSONEL"].ToString(),
                        dataReader["UYARILAN_PERSONEL"].ToString(),
                        dataReader["MESAJ_ID"].ConInt(),
                        dataReader["GORUNME_DURUMU"].ToString(),
                        dataReader["GORULME_TARIHI"].ConDate(),
                        dataReader["UYARI_MIKTAR"].ConInt()));
                }
                dataReader.Close();
                return personelUyaris;
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
                dataReader = sqlServices.StoreReader("PersonelUyariGorulmeUpdate", new SqlParameter("@id", id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
