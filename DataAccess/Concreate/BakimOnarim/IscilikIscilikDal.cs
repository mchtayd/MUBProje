using DataAccess.Abstract;
using DataAccess.Database;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.BakimOnarim
{
    public class IscilikIscilikDal //: IRepository<IscilikIscilik>
    {
        static IscilikIscilikDal ıscilikIscilikDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private IscilikIscilikDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(IscilikIscilik entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IscilikIscilikEkle",
                    new SqlParameter("@benzersizId",entity.BenzersizId),
                    new SqlParameter("@adSoyad",entity.AdSoyad),
                    new SqlParameter("@gorevi",entity.Gorevi),
                    new SqlParameter("@bolumu",entity.Bolum),
                    new SqlParameter("@iscilikTuru",entity.IscilikTuru),
                    new SqlParameter("@abfNo",entity.AbfSiparis),
                    new SqlParameter("@tarih",entity.Tarih),
                    new SqlParameter("@iscilikSuresi", entity.IscilikSuresi));

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
                dataReader = sqlServices.StoreReader("IscilikIscilikDelete",new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IscilikIscilik Get(string adSoyad)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IscilikIscilikList",new SqlParameter("@adSoyad", adSoyad));
                IscilikIscilik item = null;
                while (dataReader.Read())
                {
                    item = new IscilikIscilik(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["GOREVI"].ToString(),
                        dataReader["BOLUMU"].ToString(),
                        dataReader["ISCILIK_TURU"].ToString(),
                        dataReader["ABF_SIPARIS"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["ISCILIK_SURESI_SAAT"].ConOnlyTime());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<IscilikIscilik> GetList(string adSoyad)
        {
            try
            {
                List<IscilikIscilik> ısciliks = new List<IscilikIscilik>();
                dataReader = sqlServices.StoreReader("IscilikIscilikList", new SqlParameter("@adSoyad", adSoyad));
                while (dataReader.Read())
                {
                    ısciliks.Add(new IscilikIscilik(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["GOREVI"].ToString(),
                        dataReader["BOLUMU"].ToString(),
                        dataReader["ISCILIK_TURU"].ToString(),
                        dataReader["ABF_NO"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["ISCILIK_SURESI_SAAT"].ConOnlyTime()));
                }
                dataReader.Close();
                return ısciliks;
            }
            catch (Exception)
            {
                return new List<IscilikIscilik>();
            }
        }

        public string Update(IscilikIscilik entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IscilikIscilikGuncelle",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@adSoyad", entity.AdSoyad),
                    new SqlParameter("@gorevi", entity.Gorevi),
                    new SqlParameter("@bolumu", entity.Bolum),
                    new SqlParameter("@iscilikTuru", entity.IscilikTuru),
                    new SqlParameter("@abfNo", entity.AbfSiparis),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@iscilikSuresi", entity.IscilikSuresi));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static IscilikIscilikDal GetInstance()
        {
            if (ıscilikIscilikDal == null)
            {
                ıscilikIscilikDal = new IscilikIscilikDal();
            }
            return ıscilikIscilikDal;
        }
    }
}
