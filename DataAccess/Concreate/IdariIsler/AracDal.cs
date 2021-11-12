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
    public class AracDal // : IRepository<Arac>
    {
        static AracDal aracDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AracDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Arac entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracKaydet",
                    new SqlParameter("@plaka",entity.Plaka),
                    new SqlParameter("@ilkteciltarihi",entity.IlkTescilTarihi),
                    new SqlParameter("@teciltarihi",entity.TescilTarihi),
                    new SqlParameter("@markasi",entity.Markasi),
                    new SqlParameter("@tipi",entity.Tipi),
                    new SqlParameter("@ticariadi",entity.TicariAdi),
                    new SqlParameter("@modelyili",entity.ModelYili),
                    new SqlParameter("@aracsinifi",entity.AracSinifi),
                    new SqlParameter("@cinsi",entity.Cinsi),
                    new SqlParameter("@rengi",entity.Rengi),
                    new SqlParameter("@motorno",entity.MotorNo),
                    new SqlParameter("@saseno",entity.SaseNo),
                    new SqlParameter("@yakiycinsi",entity.YakitCinsi),
                    new SqlParameter("@mulkiyetbilgileri",entity.MulkiyetBilgileri),
                    new SqlParameter("@proje",entity.Proje),
                    new SqlParameter("@siparisno",entity.Siparisno),
                    new SqlParameter("@tasittanima",entity.TasitTanima),
                    new SqlParameter("@arventoid",entity.Arventoid),
                    new SqlParameter("@projetahsistarihi",entity.ProjeTahsisTarihi),
                    new SqlParameter("@dosyayolu",entity.DosyaYolu),
                    new SqlParameter("@aciklama",entity.Aciklama),
                    new SqlParameter("@kmGiris",entity.KmGiris));
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
                dataReader = sqlServices.StoreReader("AracSil",new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Arac Get(string plaka)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracList",new SqlParameter("@plaka",plaka));
                Arac item = null;
                while (dataReader.Read())
                {
                    item = new Arac(
                        dataReader["ID"].ConInt(),
                        dataReader["ARAC_PLAKASI"].ToString(),
                        dataReader["ILK_TECIL_TARIHI"].ConTime(),
                        dataReader["TECIL_TARIHI"].ConTime(),
                        dataReader["MARKASI"].ToString(),
                        dataReader["TIPI"].ToString(),
                        dataReader["TICARI_ADI"].ToString(),
                        dataReader["MODEL_YILI"].ToString(),
                        dataReader["ARAC_SINIFI"].ToString(),
                        dataReader["CINSI"].ToString(),
                        dataReader["RENGI"].ToString(),
                        dataReader["MOTOR_NO"].ToString(),
                        dataReader["SASE_NO"].ToString(),
                        dataReader["YAKIT_CINSI"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["KULLANILDIGI_PROJE"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["TASIT_TANIMA"].ToString(),
                        dataReader["ARVENTO_ID"].ToString(),
                        dataReader["PROJE_TAHSIS_TARIHI"].ConTime(),
                        dataReader["GIRIS_KM"].ConInt(),
                        dataReader["CIKIS_KM"].ConInt(),
                        dataReader["PROJE_CIKIS_TARIHI"].ToString(),
                        dataReader["PROJE_CIKIS_NEDENI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["ACIKLAMA"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception EX)
            {
                return null;
            }
        }

        public List<Arac> GetList()
        {
            try
            {
                List<Arac> aracs = new List<Arac>();
                dataReader = sqlServices.StoreReader("AracList");
                while (dataReader.Read())
                {
                    aracs.Add(new Arac(
                        dataReader["ID"].ConInt(),
                        dataReader["ARAC_PLAKASI"].ToString(),
                        dataReader["ILK_TECIL_TARIHI"].ConTime(),
                        dataReader["TECIL_TARIHI"].ConTime(),
                        dataReader["MARKASI"].ToString(),
                        dataReader["TIPI"].ToString(),
                        dataReader["TICARI_ADI"].ToString(),
                        dataReader["MODEL_YILI"].ToString(),
                        dataReader["ARAC_SINIFI"].ToString(),
                        dataReader["CINSI"].ToString(),
                        dataReader["RENGI"].ToString(),
                        dataReader["MOTOR_NO"].ToString(),
                        dataReader["SASE_NO"].ToString(),
                        dataReader["YAKIT_CINSI"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["KULLANILDIGI_PROJE"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["TASIT_TANIMA"].ToString(),
                        dataReader["ARVENTO_ID"].ToString(),
                        dataReader["PROJE_TAHSIS_TARIHI"].ConTime(),
                        dataReader["GIRIS_KM"].ConInt(),
                        dataReader["CIKIS_KM"].ConInt(),
                        dataReader["PROJE_CIKIS_TARIHI"].ToString(),
                        dataReader["PROJE_CIKIS_NEDENI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["ACIKLAMA"].ToString()));
                }
                dataReader.Close();
                return aracs;
            }
            catch (Exception)
            {
                return new List<Arac>();
            }
        }
        public List<Arac> ProjeDisiList()
        {
            try
            {
                List<Arac> aracs = new List<Arac>();
                dataReader = sqlServices.StoreReader("ProjeDisiArac");
                while (dataReader.Read())
                {
                    aracs.Add(new Arac(
                        dataReader["ID"].ConInt(),
                        dataReader["ARAC_PLAKASI"].ToString(),
                        dataReader["ILK_TECIL_TARIHI"].ConTime(),
                        dataReader["TECIL_TARIHI"].ConTime(),
                        dataReader["MARKASI"].ToString(),
                        dataReader["TIPI"].ToString(),
                        dataReader["TICARI_ADI"].ToString(),
                        dataReader["MODEL_YILI"].ToString(),
                        dataReader["ARAC_SINIFI"].ToString(),
                        dataReader["CINSI"].ToString(),
                        dataReader["RENGI"].ToString(),
                        dataReader["MOTOR_NO"].ToString(),
                        dataReader["SASE_NO"].ToString(),
                        dataReader["YAKIT_CINSI"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["KULLANILDIGI_PROJE"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["TASIT_TANIMA"].ToString(),
                        dataReader["ARVENTO_ID"].ToString(),
                        dataReader["PROJE_TAHSIS_TARIHI"].ConTime(),
                        dataReader["GIRIS_KM"].ConInt(),
                        dataReader["CIKIS_KM"].ConInt(),
                        dataReader["PROJE_CIKIS_TARIHI"].ToString(),
                        dataReader["PROJE_CIKIS_NEDENI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["ACIKLAMA"].ToString()));
                }
                dataReader.Close();
                return aracs;
            }
            catch (Exception)
            {
                return new List<Arac>();
            }
        }

        public string Update(Arac entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracGuncelle",
                    new SqlParameter("@id",id),
                    new SqlParameter("@plaka", entity.Plaka),
                    new SqlParameter("@ilkteciltarihi", entity.IlkTescilTarihi),
                    new SqlParameter("@teciltarihi", entity.TescilTarihi),
                    new SqlParameter("@markasi", entity.Markasi),
                    new SqlParameter("@tipi", entity.Tipi),
                    new SqlParameter("@ticariadi", entity.TicariAdi),
                    new SqlParameter("@modelyili", entity.ModelYili),
                    new SqlParameter("@aracsinifi", entity.AracSinifi),
                    new SqlParameter("@cinsi", entity.Cinsi),
                    new SqlParameter("@rengi", entity.Rengi),
                    new SqlParameter("@motorno", entity.MotorNo),
                    new SqlParameter("@saseno", entity.SaseNo),
                    new SqlParameter("@yakiycinsi", entity.YakitCinsi),
                    new SqlParameter("@mulkiyetbilgileri", entity.MulkiyetBilgileri),
                    new SqlParameter("@proje", entity.Proje),
                    new SqlParameter("@siparisno", entity.Siparisno),
                    new SqlParameter("@tasittanima", entity.TasitTanima),
                    new SqlParameter("@arventoid", entity.Arventoid),
                    new SqlParameter("@projetahsistarihi", entity.ProjeTahsisTarihi),
                    new SqlParameter("@projecikistarihi",entity.ProjeCikisTarihi),
                    new SqlParameter("@projecikisnedeni",entity.ProjeCikisNedeni),
                    new SqlParameter("@dosyayolu", entity.DosyaYolu),
                    new SqlParameter("@aciklama", entity.Aciklama),
                    new SqlParameter("@kmGiris", entity.KmGiris),
                    new SqlParameter("@kmCikis",entity.KmCikis));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Kapatma(Arac entity, int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracCikis",new SqlParameter("@id",id),
                    new SqlParameter("@projedenCikisTarihi", entity.ProjeCikisTarihi),
                    new SqlParameter("@cikisNedeni", entity.ProjeCikisNedeni),
                    new SqlParameter("@cikisKm",entity.KmCikis));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static AracDal GetInstance()
        {
            if (aracDal == null)
            {
                aracDal = new AracDal();
            }
            return aracDal;
        }
    }
}
