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
    public class ZimmetAktarimDal //: IRepository<ZimmetAktarim>
    {
        static ZimmetAktarimDal zimmetAktarimDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private ZimmetAktarimDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(ZimmetAktarim entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ZimmetAktarimKayit",
                    new SqlParameter("@dvno",entity.Dvno),
                    new SqlParameter("@isakisno",entity.IsAkisNo),
                    new SqlParameter("@dvetiketno",entity.DvEtiketNo),
                    new SqlParameter("@dvtanim",entity.DvTanim),
                    new SqlParameter("@marka",entity.DvMarka),
                    new SqlParameter("@model",entity.DvModel),
                    new SqlParameter("@serino",entity.SeriNo),
                    new SqlParameter("@durumu",entity.Durumu),
                    new SqlParameter("@miktar",entity.Miktar),
                    new SqlParameter("@islemturu",entity.IslemTuru),
                    new SqlParameter("@personelad",entity.PersonelAd),
                    new SqlParameter("@sicil",entity.Sicil),
                    new SqlParameter("@masrafyerino",entity.MasYeriNo),
                    new SqlParameter("@masrafyeri",entity.MasYeri),
                    new SqlParameter("@masyerisorumlusu",entity.MasYeriSorumlusu),
                    new SqlParameter("@bolum",entity.Bolum),
                    new SqlParameter("@aktarimtarihi",entity.AktarimTarihi),
                    new SqlParameter("@depoadresi",entity.DepoAdresi),
                    new SqlParameter("@lokasyon",entity.Lokasyon),
                    new SqlParameter("@lokasyonbilgi",entity.LokasyonBilgi),
                    new SqlParameter("@gerekcesi",entity.AktarimGerekcesi),
                    new SqlParameter("@fotoyolu",entity.FotoYolu),
                    new SqlParameter("@dosyayolu",entity.DosyaYolu));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(string dvEtiketNo,string personelad)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ZimmetAktarimSil",new SqlParameter("@dvEtiketNo", dvEtiketNo),
                    new SqlParameter("@personelad", personelad));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<ZimmetAktarim> PersonelZimmeti(string adsoyad)
        {
            try
            {
                List<ZimmetAktarim> zimmetAktarims = new List<ZimmetAktarim>();
                dataReader = sqlServices.StoreReader("PersonelZimmetiGoruntule", new SqlParameter("@adsoyad",adsoyad));
                while (dataReader.Read())
                {
                    zimmetAktarims.Add(new ZimmetAktarim(
                        dataReader["DV_NO"].ConInt(),
                        dataReader["DV_ETIKET_NO"].ToString(),
                        dataReader["DV_TANIM"].ToString(),
                        dataReader["MARKA"].ToString(),
                        dataReader["MODEL"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["DURUMU"].ToString(),
                        dataReader["MIKTAR"].ToString()));
                }
                dataReader.Close();
                return zimmetAktarims;
            }
            catch (Exception)
            {
                return new List<ZimmetAktarim>();
            }
        }

        public ZimmetAktarim Get(string dvEtiketNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ZimmetAktarimList",new SqlParameter("@dvetiketno", dvEtiketNo));
                ZimmetAktarim item = null;
                while (dataReader.Read())
                {
                    item = new ZimmetAktarim(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["DV_NO"].ConInt(),
                        dataReader["DV_ETIKET_NO"].ToString(),
                        dataReader["DV_TANIM"].ToString(),
                        dataReader["MARKA"].ToString(),
                        dataReader["MODEL"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["DURUMU"].ToString(),
                        dataReader["MIKTAR"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["PERSONEL_AD_SOYAD"].ToString(),
                        dataReader["SICIL"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["MAS_YERI_SORUMLUSU"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["AKTARIM_TARIHI"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["LOKASYON"].ToString(),
                        dataReader["LOKASYON_BILGI"].ToString(),
                        dataReader["AKTARIM_GEREKCESI"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["FOTO_YOLU"].ToString(),
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
        public ZimmetAktarim AracZimmetBilgileri(string plaka)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AracZimmetBilgileri", new SqlParameter("@plaka", plaka));
                ZimmetAktarim item = null;
                while (dataReader.Read())
                {
                    item = new ZimmetAktarim(
                        dataReader["PERSONEL_AD_SOYAD"].ToString(),
                        dataReader["BOLUM"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ZimmetAktarim> GetList()
        {
            try
            {
                List<ZimmetAktarim> zimmetAktarims = new List<ZimmetAktarim>();
                dataReader = sqlServices.StoreReader("ZimmetAktarimList");
                while (dataReader.Read())
                {
                    zimmetAktarims.Add(new ZimmetAktarim(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["DV_NO"].ConInt(),
                        dataReader["DV_ETIKET_NO"].ToString(),
                        dataReader["DV_TANIM"].ToString(),
                        dataReader["MARKA"].ToString(),
                        dataReader["MODEL"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["DURUMU"].ToString(),
                        dataReader["MIKTAR"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["PERSONEL_AD_SOYAD"].ToString(),
                        dataReader["SICIL"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["MAS_YERI_SORUMLUSU"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["AKTARIM_TARIHI"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["LOKASYON"].ToString(),
                        dataReader["LOKASYON_BILGI"].ToString(),
                        dataReader["AKTARIM_GEREKCESI"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["FOTO_YOLU"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return zimmetAktarims;
            }
            catch (Exception)
            {
                return new List<ZimmetAktarim>();
            }
        }
        public List<ZimmetAktarim> ZimmetliAraclar()
        {
            try
            {
                List<ZimmetAktarim> zimmetAktarims = new List<ZimmetAktarim>();
                dataReader = sqlServices.StoreReader("ZimmetliAraclar");
                while (dataReader.Read())
                {
                    zimmetAktarims.Add(new ZimmetAktarim(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["DV_NO"].ConInt(),
                        dataReader["DV_ETIKET_NO"].ToString(),
                        dataReader["DV_TANIM"].ToString(),
                        dataReader["MARKA"].ToString(),
                        dataReader["MODEL"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["DURUMU"].ToString(),
                        dataReader["MIKTAR"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["PERSONEL_AD_SOYAD"].ToString(),
                        dataReader["SICIL"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["MAS_YERI_SORUMLUSU"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["AKTARIM_TARIHI"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["LOKASYON"].ToString(),
                        dataReader["LOKASYON_BILGI"].ToString(),
                        dataReader["AKTARIM_GEREKCESI"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["FOTO_YOLU"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return zimmetAktarims;
            }
            catch (Exception)
            {
                return new List<ZimmetAktarim>();
            }
        }

        public string Update(ZimmetAktarim entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ZimmetAktarimGuncelle",
                    new SqlParameter("@id",id),
                    new SqlParameter("@dvno", entity.Dvno),
                    new SqlParameter("@dvetiketno", entity.DvEtiketNo),
                    new SqlParameter("@dvtanim", entity.DvTanim),
                    new SqlParameter("@marka", entity.DvMarka),
                    new SqlParameter("@model", entity.DvModel),
                    new SqlParameter("@serino", entity.SeriNo),
                    new SqlParameter("@durumu", entity.Durumu),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@islemturu", entity.IslemTuru),
                    new SqlParameter("@personelad", entity.PersonelAd),
                    new SqlParameter("@sicil", entity.Sicil),
                    new SqlParameter("@masrafyerino", entity.MasYeriNo),
                    new SqlParameter("@masrafyeri", entity.MasYeri),
                    new SqlParameter("@masyerisorumlusu", entity.MasYeriSorumlusu),
                    new SqlParameter("@bolum", entity.Bolum),
                    new SqlParameter("@aktarimtarihi", entity.AktarimTarihi),
                    new SqlParameter("@depoadresi", entity.DepoAdresi),
                    new SqlParameter("@lokasyon", entity.Lokasyon),
                    new SqlParameter("@lokasyonbilgi", entity.LokasyonBilgi),
                    new SqlParameter("@gerekcesi", entity.AktarimGerekcesi),
                    new SqlParameter("@fotoyolu", entity.FotoYolu),
                    new SqlParameter("@dosyayolu", entity.DosyaYolu));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static ZimmetAktarimDal GetInstance()
        {
            if (zimmetAktarimDal == null)
            {
                zimmetAktarimDal = new ZimmetAktarimDal();
            }
            return zimmetAktarimDal;
        }
    }
}
