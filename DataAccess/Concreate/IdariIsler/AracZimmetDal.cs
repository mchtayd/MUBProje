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
    public class AracZimmetDal //: IRepository<AracZimmeti>
    {
        static AracZimmetDal aracZimmetDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AracZimmetDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(AracZimmeti entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracZimmetiKaydet",
                    new SqlParameter("@isAkisNo",entity.IsAkisNo),
                    new SqlParameter("@plaka",entity.Plaka),
                    new SqlParameter("@marka",entity.Marka),
                    new SqlParameter("@model",entity.Model),
                    new SqlParameter("@motorNo",entity.MotorNo),
                    new SqlParameter("@saseNo",entity.SaseNo),
                    new SqlParameter("@mulkiyetBilgileri",entity.MulkiyetBilgileri),
                    new SqlParameter("@siparisNo",entity.SiparisNo),
                    new SqlParameter("@projeTahsisTarihi",entity.ProjeTahsisTarihi),
                    new SqlParameter("@personelAd",entity.PersonelAd),
                    new SqlParameter("@sicilNo",entity.SicilNo),
                    new SqlParameter("@masrafYeriNo",entity.MasrafYeriNo),
                    new SqlParameter("@masrafYeri",entity.MasrafYeri),
                    new SqlParameter("@masrafYeriSorumlusu",entity.MasYerSor),
                    new SqlParameter("@bolum",entity.Bolum),
                    new SqlParameter("@aktarimTarihi",entity.AktarimTarihi),
                    new SqlParameter("@gerekce",entity.Gerekce),
                    new SqlParameter("@dosyaYolu",entity.DosyYolu),
                    new SqlParameter("@km",entity.Km));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int isAkisNo,string persoenAd)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ArazZimmetiSil",new SqlParameter("@isAkisNo",isAkisNo),new SqlParameter("@personelAdi", persoenAd));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public AracZimmeti Get(string plaka)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracZimmetiList",new SqlParameter("@plaka", plaka));
                AracZimmeti item = null;
                while (dataReader.Read())
                {
                    item = new AracZimmeti(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["MARKA"].ToString(),
                        dataReader["MODEL"].ToString(),
                        dataReader["MOTOR_NO"].ToString(),
                        dataReader["SASE_NO"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["PROJE_TAHSIS_TARIHI"].ConDate(),
                        dataReader["PERSONEL_AD"].ToString(),
                        dataReader["SICIL_NO"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["MASRAF_YER_SOR"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["AKTARIM_TARIHI"].ConDate(),
                        dataReader["GEREKCE"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["KM"].ConInt());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<AracZimmeti> GetList()
        {
            try
            {
                List<AracZimmeti> aracZimmetis = new List<AracZimmeti>();
                dataReader = sqlServices.StoreReader("AracZimmetiList");
                while (dataReader.Read())
                {
                    aracZimmetis.Add(new AracZimmeti(dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["MARKA"].ToString(),
                        dataReader["MODEL"].ToString(),
                        dataReader["MOTOR_NO"].ToString(),
                        dataReader["SASE_NO"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["PROJE_TAHSIS_TARIHI"].ConDate(),
                        dataReader["PERSONEL_AD"].ToString(),
                        dataReader["SICIL_NO"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["MASRAF_YER_SOR"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["AKTARIM_TARIHI"].ConDate(),
                        dataReader["GEREKCE"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["KM"].ConInt()));
                }
                dataReader.Close();
                return aracZimmetis;
            }
            catch (Exception)
            {
                return new List<AracZimmeti>();
            }
        }
        public List<AracZimmeti> SiparisArac(string siparis)
        {
            try
            {
                List<AracZimmeti> aracZimmetis = new List<AracZimmeti>();
                dataReader = sqlServices.StoreReader("SiparislerArac",new SqlParameter("@siparis",siparis));
                while (dataReader.Read())
                {
                    aracZimmetis.Add(new AracZimmeti(
                        dataReader["ARAC_PLAKASI"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["DURUM"].ToString()));
                }
                dataReader.Close();
                return aracZimmetis;
            }
            catch (Exception)
            {
                return new List<AracZimmeti>();
            }
        }

        public string Update(AracZimmeti entity)
        {
            throw new NotImplementedException();
        }
        public static AracZimmetDal GetInstance()
        {
            if (aracZimmetDal == null)
            {
                aracZimmetDal = new AracZimmetDal();
            }
            return aracZimmetDal;
        }
    }
}
