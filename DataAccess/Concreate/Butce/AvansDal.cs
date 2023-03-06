using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Butce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Butce
{
    public class AvansDal //: IRepository<Avans>
    {
        static AvansDal avansDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AvansDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Avans entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IsAvanasKayit",
                    new SqlParameter("@isAkisNo",entity.IsAkisNo),
                    new SqlParameter("@donem",entity.Donem),
                    new SqlParameter("@istemeTarihi",entity.IstemeTarihi),
                    new SqlParameter("@havaleTarihi",entity.HavaleTarihi),
                    new SqlParameter("@gonderen",entity.Gonderen),
                    new SqlParameter("@hesapNo",entity.HesapNo),
                    new SqlParameter("@ibanNo",entity.IbanNo),
                    new SqlParameter("@hesapSahibi",entity.HesapSahibi),
                    new SqlParameter("@tutar",entity.Tutar),
                    new SqlParameter("@dosyaYolu",entity.DosyaYolu));
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
            throw new NotImplementedException();
        }

        public Avans Get(int isAkisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IsAvanasListele",new SqlParameter("@isAkisNo",isAkisNo));
                Avans item = null;
                while (dataReader.Read())
                {
                    item = new Avans(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["DONEM"].ToString(),
                        dataReader["ISTEME_TARIHI"].ConDate(),
                        dataReader["HAVALE_TARIHI"].ConDate(),
                        dataReader["GONDEREN"].ToString(),
                        dataReader["AVANSIN_YATIGI_HESAP_NO"].ToString(),
                        dataReader["IBAN_NO"].ToString(),
                        dataReader["HESAP_SAHIBI"].ToString(),
                        dataReader["TUTAR"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Avans> GetList()
        {
            try
            {
                List<Avans> avans = new List<Avans>();
                dataReader = sqlServices.StoreReader("IsAvanasListele");
                while (dataReader.Read())
                {
                    avans.Add(new Avans(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["DONEM"].ToString(),
                        dataReader["ISTEME_TARIHI"].ConDate(),
                        dataReader["HAVALE_TARIHI"].ConDate(),
                        dataReader["GONDEREN"].ToString(),
                        dataReader["AVANSIN_YATIGI_HESAP_NO"].ToString(),
                        dataReader["IBAN_NO"].ToString(),
                        dataReader["HESAP_SAHIBI"].ToString(),
                        dataReader["TUTAR"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return avans;
            }
            catch (Exception)
            {
                return new List<Avans>();
            }
        }

        public string Update(Avans entity)
        {
            throw new NotImplementedException();
        }
        public static AvansDal GetInstance()
        {
            if (avansDal == null)
            {
                avansDal = new AvansDal();
            }
            return avansDal;
        }
    }
}
