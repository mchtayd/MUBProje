using DataAccess.Abstract;
using DataAccess.Database;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.BakimOnarim
{
    public class DtfDal // : IRepository<Dtf>
    {
        static DtfDal dtfDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private DtfDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Dtf entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DtfEkle",
                    new SqlParameter("@isAkisNo", entity.IsAkisNo),
                    new SqlParameter("@adiSoyadi", entity.AdiSoyadi),
                    new SqlParameter("@kayitTarihi", entity.KayitTarihi),
                    new SqlParameter("@donem", entity.Donem),
                    new SqlParameter("@butceKoduKalemi", entity.ButceKodu),
                    new SqlParameter("@abfNo", entity.AbfNo),
                    new SqlParameter("@usBolgesi", entity.UsBolgesi),
                    new SqlParameter("@projeKodu", entity.ProjeKodu),
                    new SqlParameter("@garantiDurumu", entity.GarantiDurumu),
                    new SqlParameter("@isKategorisi", entity.IsKategorisi),
                    new SqlParameter("@isTanimi", entity.IsTanimi),
                    new SqlParameter("@ustStokNo", entity.StokNo),
                    new SqlParameter("@ustTanim", entity.Tanim),
                    new SqlParameter("@seriNo", entity.SeriNo),
                    new SqlParameter("@onarimYeri", entity.OnarimYeri),
                    new SqlParameter("@altYukleniciFirma", entity.AltYukleniciFirma),
                    new SqlParameter("@firmaSorumlusu", entity.FirmaSorumlusu),
                    new SqlParameter("@isinVerildigiTarih", entity.IsinVerildigiTarih),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu));

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

        public Dtf Get(int isAkisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DtfList", new SqlParameter("@isAkisNo", isAkisNo));
                Dtf item = null;
                while (dataReader.Read())
                {
                    item = new Dtf(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["ADI_SOYADI"].ToString(),
                        dataReader["KAYIT_TARIHI"].ConDate(),
                        dataReader["DONEM"].ToString(),
                        dataReader["BUTCE_KODU_KALEMI"].ToString(),
                        dataReader["ABF_NO"].ToString(),
                        dataReader["US_BOLGESI"].ToString(),
                        dataReader["PROJE_KODU"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["IS_KATEGORISI"].ToString(),
                        dataReader["IS_TANIMI"].ToString(),
                        dataReader["UST_STOK_NO"].ToString(),
                        dataReader["UST_TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["ONARIM_YERI"].ToString(),
                        dataReader["ALT_YUKLENICI_FIRMA"].ToString(),
                        dataReader["FIRMA_SORUMLUSU"].ToString(),
                        dataReader["ISIN_VERILDIGI_TARIH"].ConDate(),
                        dataReader["IS_BASLAMA_TARIHI"].ConDate(),
                        dataReader["IS_BITIS_TARIHI"].ConDate(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
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

        public List<Dtf> GetList(string durum)
        {
            try
            {
                List<Dtf> dtfs = new List<Dtf>();
                dataReader = sqlServices.StoreReader("DtfList",new SqlParameter("@durum",durum));
                while (dataReader.Read())
                {
                    dtfs.Add(new Dtf(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["ADI_SOYADI"].ToString(),
                        dataReader["KAYIT_TARIHI"].ConDate(),
                        dataReader["DONEM"].ToString(),
                        dataReader["BUTCE_KODU_KALEMI"].ToString(),
                        dataReader["ABF_NO"].ToString(),
                        dataReader["US_BOLGESI"].ToString(),
                        dataReader["PROJE_KODU"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["IS_KATEGORISI"].ToString(),
                        dataReader["IS_TANIMI"].ToString(),
                        dataReader["UST_STOK_NO"].ToString(),
                        dataReader["UST_TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["ONARIM_YERI"].ToString(),
                        dataReader["ALT_YUKLENICI_FIRMA"].ToString(),
                        dataReader["FIRMA_SORUMLUSU"].ToString(),
                        dataReader["ISIN_VERILDIGI_TARIH"].ConDate(),
                        dataReader["IS_BASLAMA_TARIHI"].ConDate(),
                        dataReader["IS_BITIS_TARIHI"].ConDate(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return dtfs;
            }
            catch (Exception)
            {
                return new List<Dtf>();
            }
        }
        public string IsAkisNoDuzelt(int id, int isAkisNo, string dosyaYolu)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DtfDuzelt",
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

        public List<Dtf> DtfKayitList(int isAkisNo)
        {
            try
            {
                List<Dtf> dtfs = new List<Dtf>();
                dataReader = sqlServices.StoreReader("DtfList", new SqlParameter("@isAkisNo", isAkisNo));
                while (dataReader.Read())
                {
                    dtfs.Add(new Dtf(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["ADI_SOYADI"].ToString(),
                        dataReader["KAYIT_TARIHI"].ConDate(),
                        dataReader["DONEM"].ToString(),
                        dataReader["BUTCE_KODU_KALEMI"].ToString(),
                        dataReader["ABF_NO"].ToString(),
                        dataReader["US_BOLGESI"].ToString(),
                        dataReader["PROJE_KODU"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["IS_KATEGORISI"].ToString(),
                        dataReader["IS_TANIMI"].ToString(),
                        dataReader["UST_STOK_NO"].ToString(),
                        dataReader["UST_TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["ONARIM_YERI"].ToString(),
                        dataReader["ALT_YUKLENICI_FIRMA"].ToString(),
                        dataReader["FIRMA_SORUMLUSU"].ToString(),
                        dataReader["ISIN_VERILDIGI_TARIH"].ConDate(),
                        dataReader["IS_BASLAMA_TARIHI"].ConDate(),
                        dataReader["IS_BITIS_TARIHI"].ConDate(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return dtfs;
            }
            catch (Exception)
            {
                return new List<Dtf>();
            }
        }

        public string Update(Dtf entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DtfGuncelle",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@isAkisNo", entity.IsAkisNo),
                    new SqlParameter("@adiSoyadi", entity.AdiSoyadi),
                    new SqlParameter("@kayitTarihi", entity.KayitTarihi),
                    new SqlParameter("@donem", entity.Donem),
                    new SqlParameter("@butceKoduKalemi", entity.ButceKodu),
                    new SqlParameter("@abfNo", entity.AbfNo),
                    new SqlParameter("@usBolgesi", entity.UsBolgesi),
                    new SqlParameter("@projeKodu", entity.ProjeKodu),
                    new SqlParameter("@garantiDurumu", entity.GarantiDurumu),
                    new SqlParameter("@isKategorisi", entity.IsKategorisi),
                    new SqlParameter("@isTanimi", entity.IsTanimi),
                    new SqlParameter("@ustStokNo", entity.StokNo),
                    new SqlParameter("@ustTanim", entity.Tanim),
                    new SqlParameter("@seriNo", entity.SeriNo),
                    new SqlParameter("@onarimYeri", entity.OnarimYeri),
                    new SqlParameter("@altYukleniciFirma", entity.AltYukleniciFirma),
                    new SqlParameter("@firmaSorumlusu", entity.FirmaSorumlusu),
                    new SqlParameter("@isinVerildigiTarih", entity.IsinVerildigiTarih),
                    new SqlParameter("@isBaslamaTarihi",entity.IsBaslamaTarihi),
                    new SqlParameter("@isBitisTarihi",entity.IsBitisTarihi),
                    new SqlParameter("@yapilanIslemler",entity.YapilanIslemler));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string KontrolOnayGuncelle(Dtf entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DtfKontrolOnayGuncelle",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@isBaslamaTarihi",entity.IsBaslamaTarihi),
                    new SqlParameter("@isBitisTarihi",entity.IsBitisTarihi),
                    new SqlParameter("@yapilanIslemler",entity.YapilanIslemler));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Dtf DtfArizaBilgileri(int abfNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DtfBlgeOgren", new SqlParameter("@abfNo", abfNo));
                Dtf item = null;
                while (dataReader.Read())
                {
                    item = new Dtf(dataReader["Kimlik"].ConInt(), dataReader["BOLGE_ADI"].ToString(), dataReader["GARANTI"].ToString(), dataReader["PROJE"].ToString(), dataReader["KATEGORI"].ToString(), dataReader["TANIM"].ToString(), dataReader["SERI_NO"].ToString(),
                        dataReader["ARIZA_BULUNAN"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DtfDal GetInstance()
        {
            if (dtfDal == null)
            {
                dtfDal = new DtfDal();
            }
            return dtfDal;
        }
    }
}
