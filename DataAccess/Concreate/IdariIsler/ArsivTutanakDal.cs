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
    public class ArsivTutanakDal //  : IRepository<ArsivTutanak>
    {
        static ArsivTutanakDal arsivTutanakDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        

        private ArsivTutanakDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(ArsivTutanak entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ArsivTutanakEkle",
                    new SqlParameter("@isAkisNo",entity.IsAkisNo),
                    new SqlParameter("@dosyaTuru",entity.DosyaTuru),
                    new SqlParameter("@bolgeAdi",entity.BolgeAdi),
                    new SqlParameter("@sistemCihaz",entity.SistemCihaz),
                    new SqlParameter("@dosyaTarihi",entity.DosyaTarihi),
                    new SqlParameter("@dosyaIcerigi",entity.DosyaIcerigi),
                    new SqlParameter("@dosyaYolu",entity.DosyaYolu),
                    new SqlParameter("@bulunduguLok",entity.BulunduguLok),
                    new SqlParameter("@klasorNo",entity.KlasorNo));

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
                dataReader = sqlServices.StoreReader("ArsivTutanakSil",new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ArsivTutanak Get(int isAkisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ArsivTutanakList",new SqlParameter("@isAkisNo",isAkisNo));
                ArsivTutanak item = null;
                while (dataReader.Read())
                {
                    item = new ArsivTutanak(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["DOSYA_TURU"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["SISTEM_CIHAZ"].ToString(),
                        dataReader["DOSYA_TARIHI"].ConDate(),
                        dataReader["DOSYA_ICERIGI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["BULUNDUGU_LOK"].ToString(),
                        dataReader["KLASOR_NO"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string IsAkisNoDuzelt(int id, int isAkisNo, string dosyaYolu)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ArsivTutanakDuzelt",
                    new SqlParameter("@id", id),
                    new SqlParameter("@isAkisNo", isAkisNo),
                    new SqlParameter("@dosyaYolu", dosyaYolu));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<ArsivTutanak> GetList(int isAkisNo)
        {
            try
            {
                List<ArsivTutanak> arsivTutanaks = new List<ArsivTutanak>();
                dataReader = sqlServices.StoreReader("ArsivTutanakList", new SqlParameter("@isAkisNo", isAkisNo));
                while (dataReader.Read())
                {
                    arsivTutanaks.Add(new ArsivTutanak(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["DOSYA_TURU"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["SISTEM_CIHAZ"].ToString(),
                        dataReader["DOSYA_TARIHI"].ConDate(),
                        dataReader["DOSYA_ICERIGI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["BULUNDUGU_LOK"].ToString(),
                        dataReader["KLASOR_NO"].ToString()));
                }
                dataReader.Close();
                return arsivTutanaks;
            }
            catch (Exception)
            {
                return new List<ArsivTutanak>();
            }
        }

        public string Update(ArsivTutanak entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ArsivTutanakGuncelle",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@isAkisNo",entity.IsAkisNo),
                    new SqlParameter("@dosyaTuru", entity.DosyaTuru),
                    new SqlParameter("@bolgeAdi", entity.BolgeAdi),
                    new SqlParameter("@sistemCihaz", entity.SistemCihaz),
                    new SqlParameter("@dosyaTarihi", entity.DosyaTarihi),
                    new SqlParameter("@dosyaIcerigi", entity.DosyaIcerigi),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@bulunduguLok", entity.BulunduguLok),
                    new SqlParameter("@klasorNo", entity.KlasorNo));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static ArsivTutanakDal GetInstance()
        {
            if (arsivTutanakDal == null)
            {
                arsivTutanakDal = new ArsivTutanakDal();
            }
            return arsivTutanakDal;
        }
    }
}
