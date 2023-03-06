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
    public class YakitDal //: IRepository<Yakit>
    {
        static YakitDal yakitDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private YakitDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Yakit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YakitBeyanEkle",
                    new SqlParameter("@isakisno",entity.Isakisno),
                    new SqlParameter("@plaka",entity.Plaka),
                    new SqlParameter("@yakitalinandonem",entity.YakitAlinanDonem),
                    new SqlParameter("@tarih",entity.Tarih),
                    new SqlParameter("@km",entity.Km),
                    new SqlParameter("@alinanlitre",entity.AlinanLitre),
                    new SqlParameter("@yakitturu",entity.YakitTuru),
                    new SqlParameter("@litrefiyati",entity.LitreFiyati),
                    new SqlParameter("@toplamfiyat",entity.ToplamFiyat),
                    new SqlParameter("@alimturu",entity.AlimTuru),
                    new SqlParameter("@personel",entity.Personel),
                    new SqlParameter("@alinanfirma",entity.AlinanFirma),
                    new SqlParameter("@belgeturu",entity.BelgeTuru),
                    new SqlParameter("@belgenumarasi",entity.BelgeNumarasi),
                    new SqlParameter("@aciklama",entity.Aciklama));
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
                dataReader = sqlServices.StoreReader("YakitBeyanSil",new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Yakit Get(int isakisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YakitBeyanList",new SqlParameter("@isakisno",isakisno));
                Yakit item = null;
                while (dataReader.Read())
                {
                    item = new Yakit(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["YAKIT_ALINAN_DONEM"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["KM"].ConInt(),
                        dataReader["ALINAN_LITRE"].ConDouble(),
                        dataReader["YAKIT_TURU"].ToString(),
                        dataReader["LITRE_FIYATI"].ConDouble(),
                        dataReader["TOPLAM_FIYAT"].ConDouble(),
                        dataReader["ALIM_TURU"].ToString(),
                        dataReader["YAKIT_ALAN_PERSONEL"].ToString(),
                        dataReader["ALINAN_FIRMA"].ToString(),
                        dataReader["BELGE_TURU"].ToString(),
                        dataReader["BELGE_NUMARASI"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["ACIKLAMA"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string IsAkisNoDuzelt(int id, int isAkisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YakitBeyaniDuzenle",
                    new SqlParameter("@id", id),
                    new SqlParameter("@isAkisNo", isAkisNo));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<Yakit> GetList(int isakisno)
        {
            try
            {
                List<Yakit> yakits = new List<Yakit>();
                dataReader = sqlServices.StoreReader("YakitBeyanList", new SqlParameter("@isakisno", isakisno));
                while (dataReader.Read())
                {
                    yakits.Add(new Yakit(dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["YAKIT_ALINAN_DONEM"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["KM"].ConInt(),
                        dataReader["ALINAN_LITRE"].ConDouble(),
                        dataReader["YAKIT_TURU"].ToString(),
                        dataReader["LITRE_FIYATI"].ConDouble(),
                        dataReader["TOPLAM_FIYAT"].ConDouble(),
                        dataReader["ALIM_TURU"].ToString(),
                        dataReader["YAKIT_ALAN_PERSONEL"].ToString(),
                        dataReader["ALINAN_FIRMA"].ToString(),
                        dataReader["BELGE_TURU"].ToString(),
                        dataReader["BELGE_NUMARASI"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["ACIKLAMA"].ToString()));
                }
                dataReader.Close();
                return yakits;
            }
            catch (Exception)
            {
                return new List<Yakit>();
            }
        }
        public List<Yakit> YakitKontrolBeyan(string donem)
        {
            try
            {
                List<Yakit> yakits = new List<Yakit>();
                dataReader = sqlServices.StoreReader("YakitKontrolBeyan",new SqlParameter("@donem",donem));
                while (dataReader.Read())
                {
                    yakits.Add(
                        new Yakit(dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["YAKIT_ALINAN_DONEM"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["KM"].ConInt(),
                        dataReader["ALINAN_LITRE"].ConDouble(),
                        dataReader["YAKIT_TURU"].ToString(),
                        dataReader["LITRE_FIYATI"].ConDouble(),
                        dataReader["TOPLAM_FIYAT"].ConDouble(),
                        dataReader["ALIM_TURU"].ToString(),
                        dataReader["YAKIT_ALAN_PERSONEL"].ToString(),
                        dataReader["ALINAN_FIRMA"].ToString(),
                        dataReader["BELGE_TURU"].ToString(),
                        dataReader["BELGE_NUMARASI"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["ACIKLAMA"].ToString()));
                }
                dataReader.Close();
                return yakits;
            }
            catch (Exception)
            {
                return new List<Yakit>();
            }
        }

        public string Update(Yakit entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YakitBeyanGuncelle",
                    new SqlParameter("@id",id),
                    new SqlParameter("@isakisno", entity.Isakisno),
                    new SqlParameter("@plaka", entity.Plaka),
                    new SqlParameter("@yakitalinandonem", entity.YakitAlinanDonem),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@km", entity.Km),
                    new SqlParameter("@alinanlitre", entity.AlinanLitre),
                    new SqlParameter("@yakitturu", entity.YakitTuru),
                    new SqlParameter("@litrefiyati", entity.LitreFiyati),
                    new SqlParameter("@toplamfiyat", entity.ToplamFiyat),
                    new SqlParameter("@alimturu", entity.AlimTuru),
                    new SqlParameter("@personel", entity.Personel),
                    new SqlParameter("@alinanfirma", entity.AlinanFirma),
                    new SqlParameter("@belgeturu", entity.BelgeTuru),
                    new SqlParameter("@belgenumarasi", entity.BelgeNumarasi),
                    new SqlParameter("@aciklama", entity.Aciklama));
                
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static YakitDal GetInstance()
        {
            if (yakitDal == null)
            {
                yakitDal = new YakitDal();
            }
            return yakitDal;
        }
    }
}
