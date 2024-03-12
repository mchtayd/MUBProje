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
    public class YolDurumuGirmeyenDall //: IRepository<YolDurumuGirmeyen>
    {
        static YolDurumuGirmeyenDall yolDurumuGirmeyenDall;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private YolDurumuGirmeyenDall()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static YolDurumuGirmeyenDall GetInstance()
        {
            if (yolDurumuGirmeyenDall == null)
            {
                yolDurumuGirmeyenDall = new YolDurumuGirmeyenDall();
            }
            return yolDurumuGirmeyenDall;
        }

        public string Add(YolDurumuGirmeyen entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YolDurumuGirmeyenKayit", new SqlParameter("@personelAdi", entity.Personel));
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

        public YolDurumuGirmeyen Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<YolDurumuGirmeyen> GetList()
        {
            try
            {
                List<YolDurumuGirmeyen> yolDurumuGirmeyens = new List<YolDurumuGirmeyen>();
                dataReader = sqlServices.StoreReader("YolDurumuGirmeyenList");
                while (dataReader.Read())
                {
                    yolDurumuGirmeyens.Add(new YolDurumuGirmeyen(dataReader["ID"].ConInt(), dataReader["PERSONEL"].ToString(), dataReader["GORUNME_DURUMU"].ToString(), dataReader["TARIH"].ConDate()));
                }
                dataReader.Close();
                return yolDurumuGirmeyens;
            }
            catch (Exception)
            {
                return new List<YolDurumuGirmeyen>();
            }
        }
        public List<YolDurumuGirmeyen> GetListLoginOlmayan()
        {
            try
            {
                DateTime basSaat = "00:01:00".ConOnlyTime();
                DateTime bitSaat = "23:59:59".ConOnlyTime();
                DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, basSaat.Hour, basSaat.Minute, basSaat.Second);

                List<YolDurumuGirmeyen> yolDurumuGirmeyens = new List<YolDurumuGirmeyen>();
                dataReader = sqlServices.StoreReader("LoginOlmayan", new SqlParameter("@date", dateTime));
                while (dataReader.Read())
                {
                    yolDurumuGirmeyens.Add(new YolDurumuGirmeyen(
                        dataReader["ID"].ConInt(), 
                        dataReader["AD_SOYAD"].ToString(), 
                        dataReader["DURUM"].ToString(), 
                        dataReader["SON_GORULME"].ConDate()));
                }
                dataReader.Close();
                return yolDurumuGirmeyens;
            }
            catch (Exception)
            {
                return new List<YolDurumuGirmeyen>();
            }
        }

        public string Update(YolDurumuGirmeyen entity)
        {
            throw new NotImplementedException();
        }
    }
}
