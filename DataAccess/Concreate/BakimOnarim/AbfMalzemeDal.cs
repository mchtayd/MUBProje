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
    public class AbfMalzemeDal //: IRepository<AbfMalzeme>
    {
        static AbfMalzemeDal abfMalzemeDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AbfMalzemeDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string AddSokulen(AbfMalzeme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfMazlemeSokulenEkle",
                    new SqlParameter("@stokNo",entity.SokulenStokNo),
                    new SqlParameter("@tanim",entity.SokulenTanim),
                    new SqlParameter("@seriNo",entity.SokulenSeriNo),
                    new SqlParameter("@miktar",entity.SokulenMiktar),
                    new SqlParameter("@birim",entity.SokulenBirim),
                    new SqlParameter("@calismaSaati",entity.SokulenCalismaSaati),
                    new SqlParameter("@revizyonNo",entity.SokulenRevizyon),
                    new SqlParameter("@calismaDurumu",entity.CalismaDurumu),
                    new SqlParameter("@fizikselDurumu",entity.FizikselDurum),
                    new SqlParameter("@yapilacakIslem",entity.YapilacakIslem),
                    new SqlParameter("@benzersizId",entity.BenzersizId));

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
                sqlServices.Stored("AbfMazlemeSil", new SqlParameter("@benzersizId", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string DeleteTekMalzemeSil(int id)
        {
            try
            {
                sqlServices.Stored("AbfTekMalzemeSil", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public AbfMalzeme Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfMalzemeGet", new SqlParameter("@id", id));
                AbfMalzeme abfMalzeme = null;
                while (dataReader.Read())
                {
                    abfMalzeme = new AbfMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["SOKULEN_TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["SOKULEN_MIKTAR"].ConInt(),
                        dataReader["SOKULEN_BIRIM"].ToString(),
                        dataReader["SOKULEN_CALISMA_SAATI"].ConDouble(),
                        dataReader["SOKULEN_REVIZYON_NO"].ToString(),
                        dataReader["CALISMA_DURUMU"].ToString(),
                        dataReader["FIZIKSEL_DURUMU"].ToString(),
                        dataReader["YAPILACAK_ISLEM"].ToString(),
                        dataReader["TAKILAN_STOK_NO"].ToString(),
                        dataReader["TAKILAN_TANIM"].ToString(),
                        dataReader["TAKILAN_SERI_NO"].ToString(),
                        dataReader["TAKILAN_MIKTAR"].ConInt(),
                        dataReader["TAKILAN_BIRIM"].ToString(),
                        dataReader["TAKILAN_CALISMA_SAATI"].ConDouble(),
                        dataReader["TAKILAN_REVIZYON_NO"].ToString(),
                        dataReader["TEMIN_DURUMU"].ToString(),
                        dataReader["MALZEME_ISLEM_ADIMI"].ToString(),
                        dataReader["SOKULEN_TESLIM_DURUM"].ToString(),
                        dataReader["YERINE_MALZEME_TAKILMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ALYUKLENICI_KAYIT"].ToString(),
                        dataReader["TAKILAN_TESLIM_DURUM"].ToString());
                }
                dataReader.Close();
                return abfMalzeme;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public AbfMalzeme GetBul(int benzersizId, string stokNo, string seriNo, string revizyon, int miktar)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfMalzemeGetBul", new SqlParameter("@benzersizId", benzersizId), new SqlParameter("@stokNo", stokNo), new SqlParameter("@seriNo", seriNo), new SqlParameter("@revizyon", revizyon), new SqlParameter("@miktar", miktar));
                AbfMalzeme abfMalzeme = null;
                while (dataReader.Read())
                {
                    abfMalzeme = new AbfMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["SOKULEN_TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["SOKULEN_MIKTAR"].ConInt(),
                        dataReader["SOKULEN_BIRIM"].ToString(),
                        dataReader["SOKULEN_CALISMA_SAATI"].ConDouble(),
                        dataReader["SOKULEN_REVIZYON_NO"].ToString(),
                        dataReader["CALISMA_DURUMU"].ToString(),
                        dataReader["FIZIKSEL_DURUMU"].ToString(),
                        dataReader["YAPILACAK_ISLEM"].ToString(),
                        dataReader["TAKILAN_STOK_NO"].ToString(),
                        dataReader["TAKILAN_TANIM"].ToString(),
                        dataReader["TAKILAN_SERI_NO"].ToString(),
                        dataReader["TAKILAN_MIKTAR"].ConInt(),
                        dataReader["TAKILAN_BIRIM"].ToString(),
                        dataReader["TAKILAN_CALISMA_SAATI"].ConDouble(),
                        dataReader["TAKILAN_REVIZYON_NO"].ToString(),
                        dataReader["TEMIN_DURUMU"].ToString(),
                        dataReader["MALZEME_ISLEM_ADIMI"].ToString(),
                        dataReader["SOKULEN_TESLIM_DURUM"].ToString(),
                        dataReader["YERINE_MALZEME_TAKILMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ALYUKLENICI_KAYIT"].ToString(),
                        dataReader["TAKILAN_TESLIM_DURUM"].ToString());
                }
                dataReader.Close();
                return abfMalzeme;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public AbfMalzeme GetBulTakilan(int benzersizId, string tanim, string seriNo, string revizyon)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfMalzemeGetBulTakilan", new SqlParameter("@benzersizId", benzersizId), new SqlParameter("@tanim", tanim), new SqlParameter("@seriNo", seriNo), new SqlParameter("@revizyon", revizyon));
                AbfMalzeme abfMalzeme = null;
                while (dataReader.Read())
                {
                    abfMalzeme = new AbfMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["SOKULEN_TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["SOKULEN_MIKTAR"].ConInt(),
                        dataReader["SOKULEN_BIRIM"].ToString(),
                        dataReader["SOKULEN_CALISMA_SAATI"].ConDouble(),
                        dataReader["SOKULEN_REVIZYON_NO"].ToString(),
                        dataReader["CALISMA_DURUMU"].ToString(),
                        dataReader["FIZIKSEL_DURUMU"].ToString(),
                        dataReader["YAPILACAK_ISLEM"].ToString(),
                        dataReader["TAKILAN_STOK_NO"].ToString(),
                        dataReader["TAKILAN_TANIM"].ToString(),
                        dataReader["TAKILAN_SERI_NO"].ToString(),
                        dataReader["TAKILAN_MIKTAR"].ConInt(),
                        dataReader["TAKILAN_BIRIM"].ToString(),
                        dataReader["TAKILAN_CALISMA_SAATI"].ConDouble(),
                        dataReader["TAKILAN_REVIZYON_NO"].ToString(),
                        dataReader["TEMIN_DURUMU"].ToString(),
                        dataReader["MALZEME_ISLEM_ADIMI"].ToString(),
                        dataReader["SOKULEN_TESLIM_DURUM"].ToString(),
                        dataReader["YERINE_MALZEME_TAKILMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ALYUKLENICI_KAYIT"].ToString(),
                        dataReader["TAKILAN_TESLIM_DURUM"].ToString());
                }
                dataReader.Close();
                return abfMalzeme;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public AbfMalzeme GetBulStokGirisCikis(string stokNo, string seriNo, string revizyon)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfMalzemeBulStokGirisCikis", new SqlParameter("@stokNo", stokNo), new SqlParameter("@seriNo", seriNo), new SqlParameter("@revizyon", revizyon));
                AbfMalzeme abfMalzeme = null;
                while (dataReader.Read())
                {
                    abfMalzeme = new AbfMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["SOKULEN_TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["SOKULEN_MIKTAR"].ConInt(),
                        dataReader["SOKULEN_BIRIM"].ToString(),
                        dataReader["SOKULEN_CALISMA_SAATI"].ConDouble(),
                        dataReader["SOKULEN_REVIZYON_NO"].ToString(),
                        dataReader["CALISMA_DURUMU"].ToString(),
                        dataReader["FIZIKSEL_DURUMU"].ToString(),
                        dataReader["YAPILACAK_ISLEM"].ToString(),
                        dataReader["TAKILAN_STOK_NO"].ToString(),
                        dataReader["TAKILAN_TANIM"].ToString(),
                        dataReader["TAKILAN_SERI_NO"].ToString(),
                        dataReader["TAKILAN_MIKTAR"].ConInt(),
                        dataReader["TAKILAN_BIRIM"].ToString(),
                        dataReader["TAKILAN_CALISMA_SAATI"].ConDouble(),
                        dataReader["TAKILAN_REVIZYON_NO"].ToString(),
                        dataReader["TEMIN_DURUMU"].ToString(),
                        dataReader["MALZEME_ISLEM_ADIMI"].ToString(),
                        dataReader["SOKULEN_TESLIM_DURUM"].ToString(),
                        dataReader["YERINE_MALZEME_TAKILMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ALYUKLENICI_KAYIT"].ToString(),
                        dataReader["TAKILAN_TESLIM_DURUM"].ToString());
                }
                dataReader.Close();
                return abfMalzeme;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public AbfMalzeme GetBulStokGirisCikisOlmayan(string stokNo, int benzerisizId)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfMalzemeBulStokGirisCikisiOlmayan", new SqlParameter("@stokNo", stokNo), new SqlParameter("@benzersizId",benzerisizId));
                AbfMalzeme abfMalzeme = null;
                while (dataReader.Read())
                {
                    abfMalzeme = new AbfMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["SOKULEN_TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["SOKULEN_MIKTAR"].ConInt(),
                        dataReader["SOKULEN_BIRIM"].ToString(),
                        dataReader["SOKULEN_CALISMA_SAATI"].ConDouble(),
                        dataReader["SOKULEN_REVIZYON_NO"].ToString(),
                        dataReader["CALISMA_DURUMU"].ToString(),
                        dataReader["FIZIKSEL_DURUMU"].ToString(),
                        dataReader["YAPILACAK_ISLEM"].ToString(),
                        dataReader["TAKILAN_STOK_NO"].ToString(),
                        dataReader["TAKILAN_TANIM"].ToString(),
                        dataReader["TAKILAN_SERI_NO"].ToString(),
                        dataReader["TAKILAN_MIKTAR"].ConInt(),
                        dataReader["TAKILAN_BIRIM"].ToString(),
                        dataReader["TAKILAN_CALISMA_SAATI"].ConDouble(),
                        dataReader["TAKILAN_REVIZYON_NO"].ToString(),
                        dataReader["TEMIN_DURUMU"].ToString(),
                        dataReader["MALZEME_ISLEM_ADIMI"].ToString(),
                        dataReader["SOKULEN_TESLIM_DURUM"].ToString(),
                        dataReader["YERINE_MALZEME_TAKILMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ALYUKLENICI_KAYIT"].ToString(),
                        dataReader["TAKILAN_TESLIM_DURUM"].ToString());
                }
                dataReader.Close();
                return abfMalzeme;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AbfMalzeme> GetList(int benzersizId, string teminDurumu)
        {
            try
            {
                List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
                dataReader = sqlServices.StoreReader("AbfMazlemeList", new SqlParameter("@benzersizId", benzersizId), new SqlParameter("@teminDurumu", teminDurumu));
                while (dataReader.Read())
                {
                    abfMalzemes.Add(new AbfMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["SOKULEN_TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["SOKULEN_MIKTAR"].ConInt(),
                        dataReader["SOKULEN_BIRIM"].ToString(),
                        dataReader["SOKULEN_CALISMA_SAATI"].ConDouble(),
                        dataReader["SOKULEN_REVIZYON_NO"].ToString(),
                        dataReader["CALISMA_DURUMU"].ToString(),
                        dataReader["FIZIKSEL_DURUMU"].ToString(),
                        dataReader["YAPILACAK_ISLEM"].ToString(),
                        dataReader["TAKILAN_STOK_NO"].ToString(),
                        dataReader["TAKILAN_TANIM"].ToString(),
                        dataReader["TAKILAN_SERI_NO"].ToString(),
                        dataReader["TAKILAN_MIKTAR"].ConInt(),
                        dataReader["TAKILAN_BIRIM"].ToString(),
                        dataReader["TAKILAN_CALISMA_SAATI"].ConDouble(),
                        dataReader["TAKILAN_REVIZYON_NO"].ToString(),
                        dataReader["TEMIN_DURUMU"].ToString(),
                        dataReader["MALZEME_ISLEM_ADIMI"].ToString(),
                        dataReader["SOKULEN_TESLIM_DURUM"].ToString(),
                        dataReader["YERINE_MALZEME_TAKILMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ALYUKLENICI_KAYIT"].ToString(),
                        dataReader["TAKILAN_TESLIM_DURUM"].ToString()));
                }
                dataReader.Close();
                return abfMalzemes;
            }
            catch (Exception ex)
            {
                return new List<AbfMalzeme>();
            }
        }
        public List<AbfMalzeme> GetListStok(string stokNo,int benzersizId)
        {
            try
            {
                List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
                dataReader = sqlServices.StoreReader("AbfMalzemeStokList", new SqlParameter("@stokNo", stokNo), new SqlParameter("@benzersizId",benzersizId));
                while (dataReader.Read())
                {
                    abfMalzemes.Add(new AbfMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["SOKULEN_TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["SOKULEN_MIKTAR"].ConInt(),
                        dataReader["SOKULEN_BIRIM"].ToString(),
                        dataReader["SOKULEN_CALISMA_SAATI"].ConDouble(),
                        dataReader["SOKULEN_REVIZYON_NO"].ToString(),
                        dataReader["CALISMA_DURUMU"].ToString(),
                        dataReader["FIZIKSEL_DURUMU"].ToString(),
                        dataReader["YAPILACAK_ISLEM"].ToString(),
                        dataReader["TAKILAN_STOK_NO"].ToString(),
                        dataReader["TAKILAN_TANIM"].ToString(),
                        dataReader["TAKILAN_SERI_NO"].ToString(),
                        dataReader["TAKILAN_MIKTAR"].ConInt(),
                        dataReader["TAKILAN_BIRIM"].ToString(),
                        dataReader["TAKILAN_CALISMA_SAATI"].ConDouble(),
                        dataReader["TAKILAN_REVIZYON_NO"].ToString(),
                        dataReader["TEMIN_DURUMU"].ToString(),
                        dataReader["MALZEME_ISLEM_ADIMI"].ToString(),
                        dataReader["SOKULEN_TESLIM_DURUM"].ToString(),
                        dataReader["YERINE_MALZEME_TAKILMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ALYUKLENICI_KAYIT"].ToString(),
                        dataReader["TAKILAN_TESLIM_DURUM"].ToString()));
                }
                dataReader.Close();
                return abfMalzemes;
            }
            catch (Exception)
            {
                return new List<AbfMalzeme>();
            }
        }
        public List<AbfMalzeme> DepoyaTeslimEdilecekMalzemeList(string teslimDurum, string fizikselDurum)
        {
            try
            {
                List<AbfMalzeme> abfMalzemesGenel = new List<AbfMalzeme>();
                List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
                dataReader = sqlServices.StoreReader("DepoIadeEdilecekMalzeme", new SqlParameter("@teslimDurum", teslimDurum), new SqlParameter("@fizikselDurum", fizikselDurum));
                while (dataReader.Read())
                {
                    abfMalzemes.Add(new AbfMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["SOKULEN_TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["SOKULEN_MIKTAR"].ConInt(),
                        dataReader["SOKULEN_BIRIM"].ToString(),
                        dataReader["SOKULEN_REVIZYON_NO"].ToString(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["SOKULEN_TESLIM_DURUM"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["BOLGE_SORUMLUSU"].ToString(),
                        dataReader["YAPILACAK_ISLEM"].ToString(),
                        dataReader["YERINE_MALZEME_TAKILMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["FIZIKSEL_DURUMU"].ToString(),
                        dataReader["ALYUKLENICI_KAYIT"].ToString()));
                }

                dataReader.Close();
                List<AbfMalzeme> abfMalzemes2 = new List<AbfMalzeme>();
                dataReader = sqlServices.StoreReader("DepoIadeEdilecekMalzemeTakilan", new SqlParameter("@teslimDurum", teslimDurum), new SqlParameter("@fizikselDurum", fizikselDurum));
                while (dataReader.Read())
                {
                    abfMalzemes2.Add(new AbfMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["TAKILAN_STOK_NO"].ToString(),
                        dataReader["TAKILAN_TANIM"].ToString(),
                        dataReader["TAKILAN_SERI_NO"].ToString(),
                        dataReader["TAKILAN_MIKTAR"].ConInt(),
                        dataReader["TAKILAN_BIRIM"].ToString(),
                        dataReader["TAKILAN_REVIZYON_NO"].ToString(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["TAKILAN_TESLIM_DURUM"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["BOLGE_SORUMLUSU"].ToString(),
                        dataReader["YAPILACAK_ISLEM"].ToString(),
                        dataReader["YERINE_MALZEME_TAKILMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["FIZIKSEL_DURUMU"].ToString(),
                        dataReader["ALYUKLENICI_KAYIT"].ToString()));
                }
                dataReader.Close();
                foreach (AbfMalzeme item in abfMalzemes)
                {
                    abfMalzemesGenel.Add(item);
                }
                foreach (AbfMalzeme item in abfMalzemes2)
                {
                    abfMalzemesGenel.Add(item);
                }
                return abfMalzemesGenel;
            }
            catch (Exception ex)
            {
                return new List<AbfMalzeme>();
            }
        }

        public List<AbfMalzeme> DtfKayitList()
        {
            try
            {
                List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
                dataReader = sqlServices.StoreReader("DtfKayitList");
                while (dataReader.Read())
                {
                    abfMalzemes.Add(new AbfMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["SOKULEN_TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["SOKULEN_MIKTAR"].ConInt(),
                        dataReader["SOKULEN_BIRIM"].ToString(),
                        dataReader["SOKULEN_REVIZYON_NO"].ToString(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["SOKULEN_TESLIM_DURUM"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["BOLGE_SORUMLUSU"].ToString(),
                        dataReader["YAPILACAK_ISLEM"].ToString(),
                        dataReader["YERINE_MALZEME_TAKILMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["FIZIKSEL_DURUMU"].ToString(),
                        dataReader["ALYUKLENICI_KAYIT"].ToString()));
                }
                dataReader.Close();
                return abfMalzemes;
            }
            catch (Exception ex)
            {
                return new List<AbfMalzeme>();
            }
        }

        public List<string> MalzemeTeslimTuru()
        {
            try
            {
                List<string> list = new List<string>();
                dataReader = sqlServices.StoreReader("TeslimAlmaTuruMalzeme");
                while (dataReader.Read())
                {
                    list.Add(dataReader["SOKULEN_TESLIM_DURUM"].ToString());
                }
                dataReader.Close();
                return list;
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }
        public List<string> MalzemeTeslimTuruTakilan()
        {
            try
            {
                List<string> list = new List<string>();
                dataReader = sqlServices.StoreReader("TeslimAlmaTuruMalzemeTakilan");
                while (dataReader.Read())
                {
                    list.Add(dataReader["TAKILAN_TESLIM_DURUM"].ToString());
                }
                dataReader.Close();
                return list;
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        public List<AbfMalzeme> TeminGetList(string teminDurumu, int abfNo)
        {
            try
            {
                List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
                dataReader = sqlServices.StoreReader("DepoTeminGor", new SqlParameter("@teminDurumu", teminDurumu), new SqlParameter("@abfNo", abfNo));
                while (dataReader.Read())
                {
                    abfMalzemes.Add(new AbfMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["SOKULEN_TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["SOKULEN_MIKTAR"].ConInt(),
                        dataReader["SOKULEN_BIRIM"].ToString(),
                        dataReader["SOKULEN_REVIZYON_NO"].ToString(),
                        dataReader["YAPILACAK_ISLEM"].ToString(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["AB_TARIH_SAAT"].ConDate(),
                        dataReader["TEMINE_ATILMA_TARIHI"].ConDate(),
                        dataReader["TEMIN_DURUMU"].ToString(),
                        dataReader["MALZEME_ISLEM_ADIMI"].ToString()));
                }
                dataReader.Close();
                return abfMalzemes;
            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<AbfMalzeme>();
            }
        }
        public List<AbfMalzeme> DepoTeminDurumu(string teminDurumu)
        {
            try
            {
                List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
                dataReader = sqlServices.StoreReader("DepoTeminGor2", new SqlParameter("@teminDurumu", teminDurumu));
                while (dataReader.Read())
                {
                    abfMalzemes.Add(new AbfMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["SOKULEN_TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["SOKULEN_MIKTAR"].ConInt(),
                        dataReader["SOKULEN_BIRIM"].ToString(),
                        dataReader["SOKULEN_REVIZYON_NO"].ToString(),
                        dataReader["YAPILACAK_ISLEM"].ToString(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["AB_TARIH_SAAT"].ConDate(),
                        dataReader["TEMINE_ATILMA_TARIHI"].ConDate(),
                        dataReader["TEMIN_DURUMU"].ToString(),
                        dataReader["MALZEME_ISLEM_ADIMI"].ToString()));
                }
                dataReader.Close();
                return abfMalzemes;
            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<AbfMalzeme>();
            }
        }

        public List<AbfMalzeme> TeminGetList2()
        {
            try
            {
                List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
                dataReader = sqlServices.StoreReader("AbfTeminList");
                while (dataReader.Read())
                {
                    abfMalzemes.Add(new AbfMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["SOKULEN_TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["SOKULEN_MIKTAR"].ConInt(),
                        dataReader["SOKULEN_BIRIM"].ToString(),
                        dataReader["SOKULEN_REVIZYON_NO"].ToString(),
                        dataReader["YAPILACAK_ISLEM"].ToString(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["AB_TARIH_SAAT"].ConDate(),
                        dataReader["TEMINE_ATILMA_TARIHI"].ConDate(),
                        dataReader["TEMIN_DURUMU"].ToString(),
                        dataReader["MALZEME_ISLEM_ADIMI"].ToString()));
                }
                dataReader.Close();
                return abfMalzemes;
            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<AbfMalzeme>();
            }
        }
        public string AbfTeminListUpdate(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfTeminListUpdate",
                    new SqlParameter("@id", id));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateTakilan(AbfMalzeme entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfMazlemeTakilanGuncelle",
                    new SqlParameter("@id", id),
                    new SqlParameter("@stokNo", entity.TakilanStokNo),
                    new SqlParameter("@tanim", entity.TakilanTanim),
                    new SqlParameter("@seriNo", entity.TakilanSeriNo),
                    new SqlParameter("@miktar",entity.TakilanMiktar),
                    new SqlParameter("@birim",entity.TakilanBirim),
                    new SqlParameter("@calismaSaati",entity.TakilanCalismaSaati),
                    new SqlParameter("@revizyonNo",entity.TakilanRevizyon));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string MalzemeTeslimBilgisiUpdate(int id, string teslimDurum)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SokulenMalzemeTeslimDurumUpdate",
                    new SqlParameter("@id", id),
                    new SqlParameter("@teslimDurum", teslimDurum));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string TakilanMalzemeTeslimBilgisiUpdate(int id, string teslimDurum)
        {
            try
            {
                dataReader = sqlServices.StoreReader("TakilanMalzemeTeslimDurumUpdate",
                    new SqlParameter("@id", id),
                    new SqlParameter("@teslimDurum", teslimDurum));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string HurdaSaglamMiktarUpdate(int id, int miktar)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfMalzemeHurdaSaglamMalzemeMiktarUpp",
                    new SqlParameter("@id", id),
                    new SqlParameter("@miktar", miktar));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string YerineMalzemeTakilma(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfYerineMalzemeTakilma",
                    new SqlParameter("@id", id));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string TeslimTesellumDurumUpdate(int id, string tesllimDurum)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfMalzemeTeslimTesellumDurumUpdate",
                    new SqlParameter("@id", id),
                    new SqlParameter("@teslimDurum", tesllimDurum));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string AddTakilan(AbfMalzeme entity,int benzersizId)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfMazlemeTakilanEkle",
                    new SqlParameter("@benzersizId",benzersizId),
                    new SqlParameter("@stokNo", entity.TakilanStokNo),
                    new SqlParameter("@tanim", entity.TakilanTanim),
                    new SqlParameter("@seriNo", entity.TakilanSeriNo),
                    new SqlParameter("@miktar", entity.TakilanMiktar),
                    new SqlParameter("@birim", entity.TakilanBirim),
                    new SqlParameter("@calismaSaati", entity.TakilanCalismaSaati),
                    new SqlParameter("@revizyonNo", entity.TakilanRevizyon));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string TeminBilgisi(int id, string teminBilgisi, string temineGonderen, string malzemeIslemAdimi)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfMalzemeTemin",
                    new SqlParameter("@id", id),
                    new SqlParameter("@teminBilgisi", teminBilgisi),
                    new SqlParameter("@temineGonderen", temineGonderen),
                    new SqlParameter("@malzemeIslemAdimi", malzemeIslemAdimi));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string AddSokulenTakilan(AbfMalzeme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfMazlemeEkle",
                    new SqlParameter("@stokNo", entity.SokulenStokNo),
                    new SqlParameter("@tanim", entity.SokulenTanim),
                    new SqlParameter("@seriNo", entity.SokulenSeriNo),
                    new SqlParameter("@miktar", entity.SokulenMiktar),
                    new SqlParameter("@birim", entity.SokulenBirim),
                    new SqlParameter("@calismaSaati", entity.SokulenCalismaSaati),
                    new SqlParameter("@revizyonNo", entity.SokulenRevizyon),
                    new SqlParameter("@calismaDurumu", entity.CalismaDurumu),
                    new SqlParameter("@fizikselDurumu", entity.FizikselDurum),
                    new SqlParameter("@yapilacakIslem", entity.YapilacakIslem),
                    new SqlParameter("@benzersizId", entity.BenzersizId),
                    new SqlParameter("@stokNoTakilan", entity.TakilanStokNo),
                    new SqlParameter("@tanimTakilan", entity.TakilanTanim),
                    new SqlParameter("@seriNoTakilan", entity.TakilanSeriNo),
                    new SqlParameter("@miktarTakilan", entity.TakilanMiktar),
                    new SqlParameter("@birimTakilan", entity.TakilanBirim),
                    new SqlParameter("@calismaSaatiTakilan", entity.TakilanCalismaSaati),
                    new SqlParameter("@revizyonTakilan", entity.TakilanRevizyon),
                    new SqlParameter("@teminDurum", entity.TeminDurumu),
                    new SqlParameter("@teminTarih", DateTime.Now),
                    new SqlParameter("@temineGonderen", ""),
                    new SqlParameter("@malzemeIslemAdimi", entity.MalzemeIslemAdimi),
                    new SqlParameter("@sokulenTeslimDurum", entity.SokulenTeslimDurum),
                    new SqlParameter("@yerineMalzeme", entity.YerineMalzemeTakilma));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SokulenMalzemeUpdate(string calismaDurumu, string fizikselDurum,string yapilacakIslem,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfMalzemeSokulenUpdate",
                    new SqlParameter("@calismaDurumu", calismaDurumu),
                    new SqlParameter("@fizikselDurum", fizikselDurum),
                    new SqlParameter("@yapilacakIslem", yapilacakIslem),
                    new SqlParameter("@id", id));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static AbfMalzemeDal GetInstance()
        {
            if (abfMalzemeDal == null)
            {
                abfMalzemeDal = new AbfMalzemeDal();
            }
            return abfMalzemeDal;
        }
    }
}
