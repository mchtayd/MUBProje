using DataAccess.Abstract;
using DataAccess.Database;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.STS
{
    public class TedarikciFirmaDal //: IRepository<TedarikciFirma>
    {
        static TedarikciFirmaDal tedarikciFirmaDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private TedarikciFirmaDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(TedarikciFirma entity)
        {
            try
            {
                sqlServices.Stored("TedarikciFirmaEkle",
                new SqlParameter("@firmadi", entity.Firmaadi),
                new SqlParameter("@firmadresi", entity.Firmaadresi),
                new SqlParameter("@firmail", entity.FirmaIl),
                new SqlParameter("@firmailce", entity.Firmailce),
                new SqlParameter("@telefon", entity.Telefon),
                new SqlParameter("@faliyetalani", entity.Faliyetalani),
                new SqlParameter("@personelad", entity.Personelad),
                new SqlParameter("@personeltelefon", entity.Personeltelefon),
                new SqlParameter("@mail", entity.Mail),
                new SqlParameter("@benzersiz", entity.Benzersiz));

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
                sqlServices.Stored("TedarikciFirmaSil", new SqlParameter("@id", id));
                return "OK";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public TedarikciFirma Get(int id)
        {
            return null;
        }

        public List<TedarikciFirma> GetList(string benzersiz)
        {
            try
            {
                List<TedarikciFirma> firmas = new List<TedarikciFirma>();
                dataReader = sqlServices.StoreReader("TedarikciFirmaListele", new SqlParameter("@benzersiz", benzersiz));
                while (dataReader.Read())
                {
                    firmas.Add(new TedarikciFirma(
                            dataReader["ID"].ConInt(),
                            dataReader["FIRMA_AD"].ToString(),
                            dataReader["FIRMA_ADRES"].ToString(),
                            dataReader["FIRMA_IL"].ToString(),
                            dataReader["FIRMA_ILCE"].ToString(),
                            dataReader["TELEFON"].ToString(),
                            dataReader["FALIYET_ALANI"].ToString(),
                            dataReader["PERSONEL_AD"].ToString(),
                            dataReader["PERSONE_TELEFON"].ToString(),
                            dataReader["MAIL"].ToString(),
                            dataReader["Benzersiz"].ToString()));
                }
                dataReader.Close();
                return firmas;
            }
            catch (Exception ex)
            {
                return new List<TedarikciFirma>();
            }

        }
        public List<string> Iller()
        {
            try
            {
                List<string> iller = new List<string>();
                dataReader = sqlServices.StoreReader("IlleriGetir");
                while (dataReader.Read())
                {
                    iller.Add(dataReader["İLLER"].ToString().ToUpper());
                }
                dataReader.Close();
                return iller;
            }
            catch (Exception)
            {

                return new List<string>();
            }
        }
        public List<string> Ilceler(string il)
        {
            try
            {
                List<string> ilceler = new List<string>();
                dataReader = sqlServices.StoreReader("IlceleriGetir", new SqlParameter("@ilAdi", il));
                while (dataReader.Read())
                {
                    ilceler.Add(dataReader["İLÇELER"].ToString().ToUpper());
                }
                dataReader.Close();
                return ilceler;
            }
            catch (Exception ex)
            {

                return new List<string>();
            }
        }

        public string Update(TedarikciFirma entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("TedarikciFirmaGuncelle",
                    new SqlParameter("@firmadi", entity.Firmaadi),
                    new SqlParameter("@firmadresi", entity.Firmaadresi),
                    new SqlParameter("@firmail", entity.FirmaIl),
                    new SqlParameter("@firmailce", entity.Firmailce),
                    new SqlParameter("@telefon", entity.Telefon),
                    new SqlParameter("@faliyetalani", entity.Faliyetalani),
                    new SqlParameter("@personelad", entity.Personelad),
                    new SqlParameter("@personeltelefon", entity.Personeltelefon),
                    new SqlParameter("@mail", entity.Mail),
                    new SqlParameter("@benzersiz", entity.Benzersiz));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<TedarikciFirma> SuppliersNameMail()
        {
            try
            {
                List<TedarikciFirma> list = new List<TedarikciFirma>();
                dataReader = sqlServices.StoreReader("FirmaMailleriCek");
                while (dataReader.Read())
                {
                    TedarikciFirma tedarikci = new TedarikciFirma(dataReader["FIRMA_AD"].ToString(), dataReader["MAIL"].ToString());
                    list.Add(tedarikci);
                }
                dataReader.Close();
                return list;
            }
            catch (Exception ex)
            {
                return new List<TedarikciFirma>();
            }
        }
        public static TedarikciFirmaDal GetInstance()
        {
            if (tedarikciFirmaDal == null)
            {
                tedarikciFirmaDal = new TedarikciFirmaDal();
            }
            return tedarikciFirmaDal;
        }
    }
}
