using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Gecic_Kabul_Ambar;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Gecici_Kabul_Ambar
{
    public class SevkiyatDal //: IRepository<Sevkiyat>
    {
        static SevkiyatDal sevkiyatDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private SevkiyatDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static SevkiyatDal GetInstance()
        {
            if (sevkiyatDal == null)
            {
                sevkiyatDal = new SevkiyatDal();
            }
            return sevkiyatDal;
        }

        public string Add(Sevkiyat entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SevkiyatAdd", 
                    new SqlParameter("@sevkiyat_Turu",entity.SevkiyatTuru),
                    new SqlParameter("@tarih",entity.Tarih),
                    new SqlParameter("@donem",entity.Donem),
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
            try
            {
                sqlServices.Stored("SevkiyatDelete", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Sevkiyat Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SevkiyatList", new SqlParameter("@id",id));
                Sevkiyat sevkiyat = null;
                while (dataReader.Read())
                {
                    sevkiyat = new Sevkiyat(
                        dataReader["ID"].ConInt(),
                        dataReader["SEVKIYAT_TURU"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["DONEM"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString());
                }
                dataReader.Close();
                return sevkiyat;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Sevkiyat GetSonKayit()
        {
            try
            {
                dataReader = sqlServices.StoreReader("SevkiyatSonKayitGet");
                Sevkiyat sevkiyat = null;
                while (dataReader.Read())
                {
                    sevkiyat = new Sevkiyat(
                        dataReader["ID"].ConInt(),
                        dataReader["SEVKIYAT_TURU"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["DONEM"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString());
                }
                dataReader.Close();
                return sevkiyat;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Sevkiyat> GetList()
        {
            try
            {
                List<Sevkiyat> sevkiyats = new List<Sevkiyat>();
                dataReader = sqlServices.StoreReader("SevkiyatList");
                while (dataReader.Read())
                {
                    sevkiyats.Add(new Sevkiyat(
                        dataReader["ID"].ConInt(),
                        dataReader["SEVKIYAT_TURU"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["DONEM"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return sevkiyats;
            }
            catch (Exception)
            {
                return new List<Sevkiyat>();
            }
        }

        public string Update(Sevkiyat entity, int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SevkiyatUpdate",
                    new SqlParameter("@id", id),
                    new SqlParameter("@sevkiyat_Turu", entity.SevkiyatTuru),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@donem", entity.Donem),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu));

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
