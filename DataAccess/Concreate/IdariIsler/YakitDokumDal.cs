﻿using DataAccess.Abstract;
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
    public class YakitDokumDal  //: IRepository<YakitDokum>
    {
        static YakitDokumDal yakitDokumDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private YakitDokumDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(YakitDokum entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YakitDokumleriKayit",
                    new SqlParameter("@isAkisNo", entity.IsAkisNo),
                    new SqlParameter("@firma",entity.Firma),
                    new SqlParameter("@plaka",entity.Plaka),
                    new SqlParameter("@donem",entity.Donem),
                    new SqlParameter("@tarih",entity.Tarih),
                    new SqlParameter("@defterNo",entity.DefterNo),
                    new SqlParameter("@siraNo",entity.SiraNo),
                    new SqlParameter("@fisNo",entity.FisNo),
                    new SqlParameter("@personel",entity.Personel),
                    new SqlParameter("@aracSiparisNo",entity.AracSiparisNo),
                    new SqlParameter("@litreFiyati",entity.LitreFiyati),
                    new SqlParameter("@verilenLitre", entity.VerilenLitre),
                    new SqlParameter("@toplamTutar",entity.ToplamTutar),
                    new SqlParameter("@dosyaYolu",entity.DosyaYolu),
                    new SqlParameter("@siparisNo", entity.SiparisNo));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string AddTasitTanima(YakitDokum entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YakitTasiTanimaEkle",
                    new SqlParameter("@isAkisNo", entity.IsAkisNo),
                    new SqlParameter("@firma", entity.Firma),
                    new SqlParameter("@plaka", entity.Plaka),
                    new SqlParameter("@donem", entity.Donem),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@aracSiparisNo", entity.AracSiparisNo),
                    new SqlParameter("@tuketimLT", entity.VerilenLitre),
                    new SqlParameter("@tutar", entity.ToplamTutar),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@personelAd", entity.Personel),
                    new SqlParameter("@alimTuru", entity.AlimTuru));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string AddTasit(YakitDokum entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YakitDokumleriKayitTasit",
                    new SqlParameter("@isAkisNo", entity.IsAkisNo),
                    new SqlParameter("@firma", entity.Firma),
                    new SqlParameter("@donem", entity.Donem),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@aracSiparisNo", entity.AracSiparisNo),
                    new SqlParameter("@toplamTutar", entity.ToplamTutar),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@siparisNo", entity.SiparisNo),
                    new SqlParameter("@plaka",entity.Plaka));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string AnaAdd(YakitDokum entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YakitFirmaDokumleriAnAEkle",
                    new SqlParameter("@isAkisNo", entity.IsAkisNo),
                    new SqlParameter("@firma", entity.Firma),
                    new SqlParameter("@donem", entity.Donem),
                    new SqlParameter("@alimTuru",entity.AlimTuru),
                    new SqlParameter("@alinanLitre", entity.VerilenLitre),
                    new SqlParameter("@yakitTutari", entity.ToplamTutar),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@siparisNo",entity.SiparisNo));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<int> Yillar()
        {
            try
            {
                List<int> yillar = new List<int>();
                dataReader = sqlServices.StoreReader("YakitBeyanTarihleri");
                while (dataReader.Read())
                {
                    yillar.Add(dataReader[0].ConInt());
                }
                dataReader.Close();
                return yillar;

            }
            catch (Exception)
            {
                return new List<int>();
            }
        }
        public List<int> YillarTT()
        {
            try
            {
                List<int> yillar = new List<int>();
                dataReader = sqlServices.StoreReader("YakitBeyanTarihleriTT");
                while (dataReader.Read())
                {
                    yillar.Add(dataReader[0].ConInt());
                }
                dataReader.Close();
                return yillar;

            }
            catch (Exception)
            {
                return new List<int>();
            }
        }

        public string AnaAddTasit(YakitDokum entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YakitFirmaDokumleriAnaEkleTasit",
                    new SqlParameter("@isAkisNo", entity.IsAkisNo),
                    new SqlParameter("@firma", entity.Firma),
                    new SqlParameter("@donem", entity.Donem),
                    new SqlParameter("@alimTuru", entity.AlimTuru),
                    new SqlParameter("@yakitTutari", entity.ToplamTutar),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@siparisNo", entity.SiparisNo));

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
                dataReader = sqlServices.StoreReader("YakitDokumleriSil",new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public YakitDokum Get(string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YakitDokumleriList", new SqlParameter("@siparisNo", siparisNo));
                YakitDokum yakitDokum = null;
                while (dataReader.Read())
                {
                    yakitDokum = new YakitDokum(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["FIRMA"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["DEFTER_NO"].ToString(),
                        dataReader["SIRA_NO"].ToString(),
                        dataReader["FIS_NO"].ToString(),
                        dataReader["PERSONEL"].ToString(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["ARAC_SPARIS_NO"].ToString(),
                        dataReader["LITRE_FIYATI"].ConDouble(),
                        dataReader["VERILEN_LITRE"].ConDouble(),
                        dataReader["TOPLAM_TUTAR"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SiparisNo"].ToString(),
                        "");
                    
                }
                dataReader.Close();
                return yakitDokum;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<YakitDokum> YakitKontrolTT(string donem)
        {
            try
            {
                List<YakitDokum> yakitDokums = new List<YakitDokum>();
                dataReader = sqlServices.StoreReader("YakitKontrolTasitTanima",new SqlParameter("@donem",donem));
                while (dataReader.Read())
                {
                    yakitDokums.Add(new YakitDokum(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["FIRMA"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["TARIH_SAAT"].ConDate(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["ARAC_SIPARIS_NO"].ToString(),
                        dataReader["TUKETIM_LT"].ConDouble(),
                        dataReader["TUTAR"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ZIMMETLI_PERSONEL"].ToString()));
                }
                dataReader.Close();
                return yakitDokums;
            }
            catch (Exception)
            {
                return new List<YakitDokum>();
            }
        }
        public List<YakitDokum> YakitKontrolAnlasmali(string donem)
        {
            try
            {
                List<YakitDokum> yakitDokums = new List<YakitDokum>();
                dataReader = sqlServices.StoreReader("YakitKontrolAnlasmali", new SqlParameter("@donem", donem));
                while (dataReader.Read())
                {
                    yakitDokums.Add(new YakitDokum(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["FIRMA"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["DEFTER_NO"].ToString(),
                        dataReader["SIRA_NO"].ToString(),
                        dataReader["FIS_NO"].ToString(),
                        dataReader["PERSONEL"].ToString(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["ARAC_SPARIS_NO"].ToString(),
                        dataReader["LITRE_FIYATI"].ConDouble(),
                        dataReader["VERILEN_LITRE"].ConDouble(),
                        dataReader["TOPLAM_TUTAR"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SiparisNo"].ToString(),
                        ""));
                }
                dataReader.Close();
                return yakitDokums;
            }
            catch (Exception)
            {
                return new List<YakitDokum>();
            }
        }
        public List<YakitDokum> GetList(string siparisNo)
        {
            try
            {
                List<YakitDokum> yakitDokums = new List<YakitDokum>();
                dataReader = sqlServices.StoreReader("YakitDokumleriList",new SqlParameter("@siparisNo",siparisNo));
                while (dataReader.Read())
                {
                    yakitDokums.Add(new YakitDokum(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["FIRMA"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["DEFTER_NO"].ToString(),
                        dataReader["SIRA_NO"].ToString(),
                        dataReader["FIS_NO"].ToString(),
                        dataReader["PERSONEL"].ToString(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["ARAC_SPARIS_NO"].ToString(),
                        dataReader["LITRE_FIYATI"].ConDouble(),
                        dataReader["VERILEN_LITRE"].ConDouble(),
                        dataReader["TOPLAM_TUTAR"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SiparisNo"].ToString(),
                        ""));
                }
                dataReader.Close();
                return yakitDokums;
            }
            catch (Exception ex)
            {
                return new List<YakitDokum>();
            }
        }
        public List<YakitDokum> GetListTumu(string yil)
        {
            try
            {
                int yildanfalza;
                if (yil == "1990")
                {
                    yildanfalza = 2022;
                }
                else
                {
                    yildanfalza = yil.ConInt() + 1;
                }
                List<YakitDokum> yakitDokums = new List<YakitDokum>();
                dataReader = sqlServices.StoreReader("YakitDokumleriList", new SqlParameter("@yil", yil), new SqlParameter("@yildanFalza", yildanfalza));
                while (dataReader.Read())
                {
                    yakitDokums.Add(new YakitDokum(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["FIRMA"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["DEFTER_NO"].ToString(),
                        dataReader["SIRA_NO"].ToString(),
                        dataReader["FIS_NO"].ToString(),
                        dataReader["PERSONEL"].ToString(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["ARAC_SPARIS_NO"].ToString(),
                        dataReader["LITRE_FIYATI"].ConDouble(),
                        dataReader["VERILEN_LITRE"].ConDouble(),
                        dataReader["TOPLAM_TUTAR"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SiparisNo"].ToString(),
                        ""));
                }
                dataReader.Close();
                return yakitDokums;
            }
            catch (Exception ex)
            {
                return new List<YakitDokum>();
            }
        }

        public List<YakitDokum> GetListAna(string alimTuru)
        {
            try
            {
                List<YakitDokum> yakitDokums = new List<YakitDokum>();
                dataReader = sqlServices.StoreReader("YakitFirmaDokumleriAnAList",new SqlParameter("@alimTuru",alimTuru));
                while (dataReader.Read())
                {
                    yakitDokums.Add(new YakitDokum(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["FIRMA"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["ALINAN_LITRE"].ConDouble(),
                        dataReader["YAKIT_TUTARI"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SiparisNo"].ToString(),
                        ""));
                }
                dataReader.Close();
                return yakitDokums;
            }
            catch (Exception)
            {
                return new List<YakitDokum>();
            }
        }
        public List<YakitDokum> GetListTT(string yil, string alimTuru)
        {
            try
            {
                int yildanfalza;
                if (yil == "1990")
                {
                    yildanfalza = 2022;
                }
                else
                {
                    yildanfalza = yil.ConInt() + 1;
                }
                List<YakitDokum> yakitDokums = new List<YakitDokum>();
                dataReader = sqlServices.StoreReader("YakitTasiTanimaListe", new SqlParameter("@yil", yil), new SqlParameter("@yildanFalza", yildanfalza), new SqlParameter("@alimTuru", alimTuru));
                while (dataReader.Read())
                {
                    yakitDokums.Add(new YakitDokum(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["FIRMA"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["TARIH_SAAT"].ConDate(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["ARAC_SIPARIS_NO"].ToString(),
                        dataReader["TUKETIM_LT"].ConDouble(),
                        dataReader["TUTAR"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ZIMMETLI_PERSONEL"].ToString()));
                }
                dataReader.Close();
                return yakitDokums;
            }
            catch (Exception)
            {
                return new List<YakitDokum>();
            }
        }

        public string Update(YakitDokum entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YakitDokumleriGuncelle",
                    new SqlParameter("@isAkisNo", entity.IsAkisNo),
                    new SqlParameter("@firma", entity.Firma),
                    new SqlParameter("@donem", entity.Donem),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@defterNo", entity.DefterNo),
                    new SqlParameter("@siraNo", entity.SiraNo),
                    new SqlParameter("@fisNo", entity.FisNo),
                    new SqlParameter("@personel", entity.Personel),
                    new SqlParameter("@aracSiparisNo", entity.AracSiparisNo),
                    new SqlParameter("@litreFiyati", entity.LitreFiyati),
                    new SqlParameter("@verilenLitre", entity.VerilenLitre),
                    new SqlParameter("@toplamTutar", entity.ToplamTutar),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static YakitDokumDal GetInstance()
        {
            if (yakitDokumDal == null)
            {
                yakitDokumDal = new YakitDokumDal();
            }
            return yakitDokumDal;
        }
    }
}
