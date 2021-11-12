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
    public class AracZimmetiLogDal //: IRepository<AracZimmetiLog>
    {
        static AracZimmetiLogDal aracZimmetiLogDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AracZimmetiLogDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(AracZimmetiLog entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracZimmetleriLogKayit",
                    new SqlParameter("@isAkisNo",entity.IsAkisNo),
                    new SqlParameter("@plaka",entity.Plaka),
                    new SqlParameter("@marka",entity.Marka),
                    new SqlParameter("@aktaranPersonel",entity.AktaranPersonel),
                    new SqlParameter("@aktaranMasYerNo",entity.AktaranMasYeriNo),
                    new SqlParameter("@aktaranMasYeri",entity.AktaranMasYeri),
                    new SqlParameter("@aktaranMasYerSor",entity.AktaranMasYeriSor),
                    new SqlParameter("@aktaranBolum",entity.AktaranBolum),
                    new SqlParameter("@alanPersonel",entity.AlanPersonel),
                    new SqlParameter("@alanMasYerNo",entity.AlanMasYeriNo),
                    new SqlParameter("@alanMasYeri",entity.AlanMasYeri),
                    new SqlParameter("@alanMasYerSor",entity.AlanMasYerSor),
                    new SqlParameter("@alanBolum",entity.AlanBolum),
                    new SqlParameter("@aktarimTarihi",entity.AktarimTarihi),
                    new SqlParameter("@islemYapan",entity.IslemYapan),
                    new SqlParameter("@km",entity.Km),
                    new SqlParameter("@aktarimGerekcesi",entity.AktariGerekcesi));

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

        public AracZimmetiLog Get(int isAkisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracZimmetleriLogList",new SqlParameter("@isAkisNo",isAkisNo));
                AracZimmetiLog item = null;
                while (dataReader.Read())
                {
                    item = new AracZimmetiLog(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["MARKA"].ToString(),
                        dataReader["AKTARAN_PERSONEL"].ToString(),
                        dataReader["AKTARAN_MASRAF_YERI_NO"].ToString(),
                        dataReader["AKTARAN_MASRAF_YERI"].ToString(),
                        dataReader["AKTARAN_MAS_YER_SOR"].ToString(),
                        dataReader["AKTARAN_BOLUM"].ToString(),
                        dataReader["ALAN_PERSONEL"].ToString(),
                        dataReader["ALAN_PERSONEL"].ToString(),
                        dataReader["ALAN_MASRAF_YERI"].ToString(),
                        dataReader["ALAN_MAS_YER_SOR"].ToString(),
                        dataReader["ALAN_BOLUM"].ToString(),
                        dataReader["AKTARIM_TARIHI"].ConTime(),
                        dataReader["ISLEM_YAPAN"].ToString(),
                        dataReader["KM"].ConInt(),
                        dataReader["AKRARIM_GEREKCESI"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AracZimmetiLog> GetList()
        {
            try
            {
                List<AracZimmetiLog> aracZimmetiLogs = new List<AracZimmetiLog>();
                dataReader = sqlServices.StoreReader("AracZimmetleriLogList");
                while (dataReader.Read())
                {
                    aracZimmetiLogs.Add(new AracZimmetiLog(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["MARKA"].ToString(),
                        dataReader["AKTARAN_PERSONEL"].ToString(),
                        dataReader["AKTARAN_MASRAF_YERI_NO"].ToString(),
                        dataReader["AKTARAN_MASRAF_YERI"].ToString(),
                        dataReader["AKTARAN_MAS_YER_SOR"].ToString(),
                        dataReader["AKTARAN_BOLUM"].ToString(),
                        dataReader["ALAN_PERSONEL"].ToString(),
                        dataReader["ALAN_PERSONEL"].ToString(),
                        dataReader["ALAN_MASRAF_YERI"].ToString(),
                        dataReader["ALAN_MAS_YER_SOR"].ToString(),
                        dataReader["ALAN_BOLUM"].ToString(),
                        dataReader["AKTARIM_TARIHI"].ConTime(),
                        dataReader["ISLEM_YAPAN"].ToString(),
                        dataReader["KM"].ConInt(),
                        dataReader["AKTARIM_GEREKCESI"].ToString()));
                }
                dataReader.Close();
                return aracZimmetiLogs;
            }
            catch (Exception ex)
            {
                return new List<AracZimmetiLog>();
            }
        }

        public string Update(AracZimmetiLog entity)
        {
            throw new NotImplementedException();
        }
        public static AracZimmetiLogDal GetInstance()
        {
            if (aracZimmetiLogDal == null)
            {
                aracZimmetiLogDal = new AracZimmetiLogDal();
            }
            return aracZimmetiLogDal;
        }
    }
}
