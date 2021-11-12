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
    public class AltYukleniciDal // :IRepository<AltYuklenici>
    {
        static AltYukleniciDal yukleniciDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AltYukleniciDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(AltYuklenici entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AltYukleniciFirmaEkle",
                    new SqlParameter("@firmaadi", entity.Firmaadi),
                    new SqlParameter("@firmaadresi", entity.Firmaadi),
                    new SqlParameter("@il", entity.Il),
                    new SqlParameter("@ilce", entity.Ilçe),
                    new SqlParameter("@telefon", entity.Telefon),
                    new SqlParameter("@faliyatalani", entity.Faliyatalani),
                    new SqlParameter("@personeladi", entity.Personeladi),
                    new SqlParameter("@personeltelefon", entity.Personeltelefon),
                    new SqlParameter("@mail", entity.Mail));

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
                dataReader =  sqlServices.StoreReader("AltYukleniciFirmaSil",new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public AltYuklenici Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<AltYuklenici> GetList(int id)
        {
            try
            {
                List<AltYuklenici> altYuklenicis = new List<AltYuklenici>();
                dataReader = sqlServices.StoreReader("AltYukleniciFirmaList",new SqlParameter("id",id));
                while (dataReader.Read())
                {
                    altYuklenicis.Add(new AltYuklenici(
                    dataReader["ID"].ConInt(),
                    dataReader["FIRMA_ADI"].ToString(),
                    dataReader["FIRMA_ADRESI"].ToString(),
                    dataReader["IL"].ToString(),
                    dataReader["ILCE"].ToString(),
                    dataReader["TELEFON"].ToString(),
                    dataReader["FALIYET_ALANI"].ToString(),
                    dataReader["PERSONEL_AD"].ToString(),
                    dataReader["PERSONEL_TELEFON"].ToString(),
                    dataReader["MAIL"].ToString()));
                }
                dataReader.Close();
                return altYuklenicis;
            }
            catch (Exception ex)
            {
                return new List<AltYuklenici>();
            }
        }

        public string Update(AltYuklenici entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AltYukleniciFirmaGuncelle",
                    new SqlParameter("@id",id),
                    new SqlParameter("@firmaadi",entity.Firmaadi),
                    new SqlParameter("@firmaadresi",entity.Firmaadresi),
                    new SqlParameter("@il",entity.Il),
                    new SqlParameter("@ilce",entity.Ilçe),
                    new SqlParameter("@telefon",entity.Telefon),
                    new SqlParameter("@faliyatalani",entity.Faliyatalani),
                    new SqlParameter("@personeladi",entity.Personeladi),
                    new SqlParameter("@personeltelefon",entity.Personeltelefon),
                    new SqlParameter("@mail",entity.Mail));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public static AltYukleniciDal GetInstance()
        {
            if (yukleniciDal == null)
            {
                yukleniciDal = new AltYukleniciDal();
            }
            return yukleniciDal;
        }
    }
}
