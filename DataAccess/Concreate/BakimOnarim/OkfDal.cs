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
    public class OkfDal //: IRepository<Okf>
    {
        static OkfDal okfDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private OkfDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static OkfDal GetInstance()
        {
            if (okfDal == null)
            {
                okfDal = new OkfDal();
            }
            return okfDal;
        }

        public string Add(Okf entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("OkfAdd",
                    new SqlParameter("@isAkisNo", entity.IsAkisNo),
                    new SqlParameter("@kayitYapan", entity.KayitYapan),
                    new SqlParameter("@kayitTarihi", entity.KayitTarihi),
                    new SqlParameter("@abfNo", entity.AbfNo),
                    new SqlParameter("@arizaTarihi", entity.ArizaTarihi),
                    new SqlParameter("@usBolgesi", entity.UsBolgesi),
                    new SqlParameter("@prokeKodu", entity.ProjeKodu),
                    new SqlParameter("@garantiDurumu", entity.GarantiDurumu),
                    new SqlParameter("@ubKomutani", entity.UbKomutani),
                    new SqlParameter("@komutanTel", entity.KomutanTel),
                    new SqlParameter("@birlikAdresi", entity.BirlikAdresi),
                    new SqlParameter("@il", entity.Il),
                    new SqlParameter("@ilce", entity.Ilce),
                    new SqlParameter("@ustStok", entity.UstStok),
                    new SqlParameter("@ustTanim", entity.UstTanim),
                    new SqlParameter("@ustSeri", entity.UstSeriNo),
                    new SqlParameter("@bildirilenAriza", entity.BildirilenAriza),
                    new SqlParameter("@arizaDurum", entity.ArizaDurum),
                    new SqlParameter("@arizaNedeni", entity.ArizaNedeni),
                    new SqlParameter("@genelOneriler", entity.GenelOneriler),
                    new SqlParameter("@toplamTutar", entity.ToplamTutar),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@bildirimNo",entity.BildirimNo));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public int OkfSonId()
        {
            try
            {
                int id = -1;
                dataReader = sqlServices.StoreReader("OkfSonId");
                while (dataReader.Read())
                {
                    id = dataReader["ID"].ConInt();
                }
                dataReader.Close();
                return id;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public string YapilacakIslemlerAdd(Okf entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("OkfYapilacakIslemlerAdd",
                    new SqlParameter("@yapilacakIslemler", entity.YapilacakIslemler),
                    new SqlParameter("@benzersizId", entity.Id));

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
                sqlServices.Stored("OkfDelete", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Okf Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("OkfList", new SqlParameter("@id", id));
                Okf item = null;
                while (dataReader.Read())
                {
                    item = new Okf(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["KAYIT_YAPAN"].ToString(),
                        dataReader["KAYIT_TARIHI"].ConDate(),
                        dataReader["ABF_NO"].ToString(),
                        dataReader["ARIZA_TARIHI"].ConDate(),
                        dataReader["US_BOLGESI"].ToString(),
                        dataReader["PROJE_KODU"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["UB_KOMUTANI"].ToString(),
                        dataReader["KOMUTAN_TEL"].ToString(),
                        dataReader["BIRLIK_ADRES"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["UST_STOK"].ToString(),
                        dataReader["UST_TANIM"].ToString(),
                        dataReader["UST_SERI"].ToString(),
                        dataReader["BILDIRILEN_ARIZA"].ToString(),
                        dataReader["ARIZA_DURUM"].ToString(),
                        dataReader["ARIZA_NEDENI"].ToString(),
                        dataReader["GENEL_ONERILER"].ToString(),
                        dataReader["TOPLAM_TUTAR"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Okf> GetList()
        {
            try
            {
                List<Okf> okfs = new List<Okf>();
                dataReader = sqlServices.StoreReader("OkfList");
                while (dataReader.Read())
                {
                    okfs.Add(new Okf(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["KAYIT_YAPAN"].ToString(),
                        dataReader["KAYIT_TARIHI"].ConDate(),
                        dataReader["ABF_NO"].ToString(),
                        dataReader["ARIZA_TARIHI"].ConDate(),
                        dataReader["US_BOLGESI"].ToString(),
                        dataReader["PROJE_KODU"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["UB_KOMUTANI"].ToString(),
                        dataReader["KOMUTAN_TEL"].ToString(),
                        dataReader["BIRLIK_ADRES"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["UST_STOK"].ToString(),
                        dataReader["UST_TANIM"].ToString(),
                        dataReader["UST_SERI"].ToString(),
                        dataReader["BILDIRILEN_ARIZA"].ToString(),
                        dataReader["ARIZA_DURUM"].ToString(),
                        dataReader["ARIZA_NEDENI"].ToString(),
                        dataReader["GENEL_ONERILER"].ToString(),
                        dataReader["TOPLAM_TUTAR"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString()));
                }
                dataReader.Close();
                return okfs;
            }
            catch (Exception)
            {
                return new List<Okf>();
            }
        }

        public List<Okf> YapilacakIslemlerGetList(int benzersizId)
        {
            try
            {
                List<Okf> okfs = new List<Okf>();
                dataReader = sqlServices.StoreReader("OkfYapilacakIslemlerList", new SqlParameter("@benzersizId", benzersizId));
                while (dataReader.Read())
                {
                    okfs.Add(new Okf(
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["YAPILACAK_ISLEMLER"].ToString()));
                }

                dataReader.Close();
                return okfs;

            }
            catch (Exception)
            {
                return new List<Okf>();
            }
        }

        public string YapilacakIslemlerDelete(int benzersizId)
        {
            try
            {
                sqlServices.Stored("OkfYapilacakIslemlerDelete", new SqlParameter("@benzersizId", benzersizId));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Okf OkfArizaBilgileri(int abfNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("OkfBolgeOgren", new SqlParameter("@abfNo", abfNo));
                Okf item = null;
                while (dataReader.Read())
                {
                    item = new Okf(
                        dataReader["Kimlik"].ConInt(),
                        dataReader["BILDIRIM_TARIH"].ConDate(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["PROJE"].ToString(),
                        dataReader["BOLGE_SORUMLU"].ToString(),
                        dataReader["BOLGE_TELEFON"].ToString(),
                        dataReader["BOLGE_ADRES"].ToString(),
                        dataReader["BOLGE_IL"].ToString(),
                        dataReader["BOLGE_ILCE"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["ARIZA_BULUNAN"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string Update(Okf entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("OkfUpdate",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@kayitYapan", entity.KayitYapan),
                    new SqlParameter("@kayitTarihi", entity.KayitTarihi),
                    new SqlParameter("@abfNo", entity.AbfNo),
                    new SqlParameter("@arizaTarihi", entity.ArizaTarihi),
                    new SqlParameter("@usBolgesi", entity.UsBolgesi),
                    new SqlParameter("@prokeKodu", entity.ProjeKodu),
                    new SqlParameter("@garantiDurumu", entity.GarantiDurumu),
                    new SqlParameter("@ubKomutani", entity.UbKomutani),
                    new SqlParameter("@komutanTel", entity.KomutanTel),
                    new SqlParameter("@birlikAdresi", entity.BirlikAdresi),
                    new SqlParameter("@il", entity.Il),
                    new SqlParameter("@ilce", entity.Ilce),
                    new SqlParameter("@ustStok", entity.UstStok),
                    new SqlParameter("@ustTanim", entity.UstTanim),
                    new SqlParameter("@ustSeri", entity.UstSeriNo),
                    new SqlParameter("@bildirilenAriza", entity.BildirilenAriza),
                    new SqlParameter("@arizaDurum", entity.ArizaDurum),
                    new SqlParameter("@arizaNedeni", entity.ArizaNedeni),
                    new SqlParameter("@genelOneriler", entity.GenelOneriler),
                    new SqlParameter("@toplamTutar", entity.ToplamTutar),
                    new SqlParameter("@bildirimNo", entity.BildirimNo));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
