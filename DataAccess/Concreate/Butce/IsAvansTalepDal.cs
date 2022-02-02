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
    public class IsAvansTalepDal //: IRepository<IsAvansTalep>
    {
        static IsAvansTalepDal ısAvansTalepDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private IsAvansTalepDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(IsAvansTalep entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IsAvansTalepEkle",
                    new SqlParameter("@isAkisNo",entity.IsAkisNo),
                    new SqlParameter("@tarih",entity.Tarih),
                    new SqlParameter("@adiSoyadi",entity.AdiSoyadi),
                    new SqlParameter("@siparis",entity.SiparisNo),
                    new SqlParameter("@unvani",entity.Unvani),
                    new SqlParameter("@masrafYeriNo",entity.MasrafYeriNo),
                    new SqlParameter("@masrafYeri",entity.MasrafYeri),
                    new SqlParameter("@talepNedeni",entity.TalepNedeni),
                    new SqlParameter("@miktar",entity.Miktar),
                    new SqlParameter("@aciklamalar",entity.Aciklamalar),
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

        public IsAvansTalep Get(int isAkisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IsAvansTalepListele", new SqlParameter("@isAkisNo",isAkisNo));
                IsAvansTalep item = null;
                while (dataReader.Read())
                {
                    item = new IsAvansTalep(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["TARIH"].ConTime(),
                        dataReader["ADI_SOYADI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["TALEP_NEDENI"].ToString(),
                        dataReader["MIKTAR"].ConDouble(),
                        dataReader["ACIKLAMALAR"].ToString(),
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

        public List<IsAvansTalep> GetList()
        {
            try
            {
                List<IsAvansTalep> ısAvansTaleps = new List<IsAvansTalep>();
                dataReader = sqlServices.StoreReader("IsAvansTalepListele");
                while (dataReader.Read())
                {
                    ısAvansTaleps.Add(new IsAvansTalep(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["TARIH"].ConTime(),
                        dataReader["ADI_SOYADI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["TALEP_NEDENI"].ToString(),
                        dataReader["MIKTAR"].ConDouble(),
                        dataReader["ACIKLAMALAR"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return ısAvansTaleps;

            }
            catch (Exception)
            {
                return new List<IsAvansTalep>();
            }
        }

        public string Update(IsAvansTalep entity)
        {
            throw new NotImplementedException();
        }
        public static IsAvansTalepDal GetInstance()
        {
            if (ısAvansTalepDal == null)
            {
                ısAvansTalepDal = new IsAvansTalepDal();
            }
            return ısAvansTalepDal;
        }
    }
}
