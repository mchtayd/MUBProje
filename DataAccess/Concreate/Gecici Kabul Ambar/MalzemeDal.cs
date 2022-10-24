using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Gecici_Kabul_Ambar
{
    public class MalzemeDal // : IRepository<Malzeme>
    {
        static MalzemeDal malzemeDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private MalzemeDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(Malzeme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoMalzemeKayit",
                    new SqlParameter("@stokNo",entity.StokNo),
                    new SqlParameter("@tanim",entity.Tanim),
                    new SqlParameter("@birim",entity.Birim),
                    new SqlParameter("@tedarikciFirma",entity.TedarikciFirma),
                    new SqlParameter("@onarimDurumu",entity.OnarimDurumu),
                    new SqlParameter("@onarimYeri",entity.OnarimYeri),
                    new SqlParameter("@tedarikTuru",entity.TedarikTuru),
                    new SqlParameter("@parcaSinifi",entity.ParcaSinifi),
                    new SqlParameter("@alternatifParca",entity.AlternatifParca),
                    new SqlParameter("@aciklama",entity.Aciklama),
                    new SqlParameter("@dosyaYolu",entity.DosyaYolu),
                    new SqlParameter("@sistemStokNo",entity.SistemStokNo),
                    new SqlParameter("@sistemTanim",entity.SistemTanimi),
                    new SqlParameter("@sistemSorumlusu",entity.SistemSorumlusu),
                    new SqlParameter("@islemYapan",entity.IslemYapan),
                    new SqlParameter("@takipDurumu",entity.TakipDurumu));

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
                sqlServices.Stored("DepoMalzemeSil",new SqlParameter("@id",id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Malzeme Get(string stokNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoMalzemeList",new SqlParameter("@stokNo", stokNo));
                Malzeme item = null;
                while (dataReader.Read())
                {
                    item = new Malzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["TEDARIKCI_FIRMA"].ToString(),
                        dataReader["ONARIM_DURUMU"].ToString(),
                        dataReader["ONARIM_YERI"].ToString(),
                        dataReader["TEDARIK_TURU"].ToString(),
                        dataReader["PARCA_SINIFI"].ToString(),
                        dataReader["ALTRNATIF_PARCA"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SISTEM_STOK_NO"].ToString(),
                        dataReader["SISTEM_TANIM"].ToString(),
                        dataReader["SISTEM_SORUMLUSU"].ToString(),
                        dataReader["KAYIT_YAPAN"].ToString(),
                        dataReader["TAKIP_DURUMU"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Malzeme Get2(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoMalzemeList", new SqlParameter("@id", id));
                Malzeme item = null;
                while (dataReader.Read())
                {
                    item = new Malzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["TEDARIKCI_FIRMA"].ToString(),
                        dataReader["ONARIM_DURUMU"].ToString(),
                        dataReader["ONARIM_YERI"].ToString(),
                        dataReader["TEDARIK_TURU"].ToString(),
                        dataReader["PARCA_SINIFI"].ToString(),
                        dataReader["ALTRNATIF_PARCA"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SISTEM_STOK_NO"].ToString(),
                        dataReader["SISTEM_TANIM"].ToString(),
                        dataReader["SISTEM_SORUMLUSU"].ToString(),
                        dataReader["KAYIT_YAPAN"].ToString(),
                        dataReader["TAKIP_DURUMU"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Malzeme MalzemeSonStok()
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeSonStokBul");
                Malzeme item = null;
                while (dataReader.Read())
                {
                    item = new Malzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["TEDARIKCI_FIRMA"].ToString(),
                        dataReader["ONARIM_DURUMU"].ToString(),
                        dataReader["ONARIM_YERI"].ToString(),
                        dataReader["TEDARIK_TURU"].ToString(),
                        dataReader["PARCA_SINIFI"].ToString(),
                        dataReader["ALTRNATIF_PARCA"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SISTEM_STOK_NO"].ToString(),
                        dataReader["SISTEM_TANIM"].ToString(),
                        dataReader["SISTEM_SORUMLUSU"].ToString(),
                        dataReader["KAYIT_YAPAN"].ToString(),
                        dataReader["TAKIP_DURUMU"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string UstTakimEkle(Malzeme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeUstTakimEkle",
                    new SqlParameter("@ustTakimStok", entity.UstStok),
                    new SqlParameter("@ustTakimTanim", entity.UstTanim),
                    new SqlParameter("@benzersizId", entity.BenzersizId));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string MalzemeTanimDuzelt(string tanim, int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeTanimDuzelt",
                    new SqlParameter("@tanim", tanim),
                    new SqlParameter("@id", id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<Malzeme> MalzemeUstTakimList(int benzersizId)
        {
            try
            {
                List<Malzeme> malzemes = new List<Malzeme>();
                dataReader = sqlServices.StoreReader("MalzemeUstTakimList", new SqlParameter("@benzersizId",benzersizId));
                while (dataReader.Read())
                {
                    malzemes.Add(new Malzeme(
                        dataReader["UST_TAKIM_STOK"].ToString(),
                        dataReader["UST_TAKIM_TANIM"].ToString(),
                        dataReader["BENZERSIZ_ID"].ConInt()));
                }
                dataReader.Close();
                return malzemes;
            }
            catch (Exception)
            {
                return new List<Malzeme>();
            }
        }
        public List<Malzeme> GetList()
        {
            try
            {
                List<Malzeme> malzemes = new List<Malzeme>();
                dataReader = sqlServices.StoreReader("DepoMalzemeList");
                while (dataReader.Read())
                {
                    malzemes.Add(new Malzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["TEDARIKCI_FIRMA"].ToString(),
                        dataReader["ONARIM_DURUMU"].ToString(),
                        dataReader["ONARIM_YERI"].ToString(),
                        dataReader["TEDARIK_TURU"].ToString(),
                        dataReader["PARCA_SINIFI"].ToString(),
                        dataReader["ALTRNATIF_PARCA"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SISTEM_STOK_NO"].ToString(),
                        dataReader["SISTEM_TANIM"].ToString(),
                        dataReader["SISTEM_SORUMLUSU"].ToString(),
                        dataReader["KAYIT_YAPAN"].ToString(),
                        dataReader["TAKIP_DURUMU"].ToString()));
                }
                dataReader.Close();
                return malzemes;
            }
            catch (Exception ex)
            {
                return new List<Malzeme>();
            }
        }
        public Malzeme MalzemeStokKontrolOTS(string stokNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeStokKontrolOts", new SqlParameter("@stokNo", stokNo));
                Malzeme item = null;
                while (dataReader.Read())
                {
                    item = new Malzeme(
                        dataReader["Kimlik"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        "",
                        dataReader["ONARIM_DURUMU"].ToString(),
                        dataReader["ONARIM_YERI"].ToString(),
                        "",
                        dataReader["MALZEME_TURU"].ToString(),
                        "",
                        dataReader["ACIKLAMA"].ToString(),
                        "",
                        "",
                        "",
                        "",
                        "",
                        dataReader["TAKIP_DURUMU"].ToString());
                    
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Malzeme> MalzemeStokDuzeltList()
        {
            try
            {
                List<Malzeme> malzemes = new List<Malzeme>();
                dataReader = sqlServices.StoreReader("MalzemeStokDuzeltList");
                while (dataReader.Read())
                {
                    malzemes.Add(new Malzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["TEDARIKCI_FIRMA"].ToString(),
                        dataReader["ONARIM_DURUMU"].ToString(),
                        dataReader["ONARIM_YERI"].ToString(),
                        dataReader["TEDARIK_TURU"].ToString(),
                        dataReader["PARCA_SINIFI"].ToString(),
                        dataReader["ALTRNATIF_PARCA"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SISTEM_STOK_NO"].ToString(),
                        dataReader["SISTEM_TANIM"].ToString(),
                        dataReader["SISTEM_SORUMLUSU"].ToString(),
                        dataReader["KAYIT_YAPAN"].ToString(),
                        dataReader["TAKIP_DURUMU"].ToString()));
                }
                dataReader.Close();
                return malzemes;
            }
            catch (Exception ex)
            {
                return new List<Malzeme>();
            }
        }
        

        public List<Malzeme> MalzemeGetList(string stokNo)
        {
            try
            {
                List<Malzeme> malzemes = new List<Malzeme>();
                dataReader = sqlServices.StoreReader("DepoMalzemeList",new SqlParameter("@stokNo", stokNo));
                while (dataReader.Read())
                {
                    malzemes.Add(new Malzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["TEDARIKCI_FIRMA"].ToString(),
                        dataReader["ONARIM_DURUMU"].ToString(),
                        dataReader["ONARIM_YERI"].ToString(),
                        dataReader["TEDARIK_TURU"].ToString(),
                        dataReader["PARCA_SINIFI"].ToString(),
                        dataReader["ALTRNATIF_PARCA"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SISTEM_STOK_NO"].ToString(),
                        dataReader["SISTEM_TANIM"].ToString(),
                        dataReader["SISTEM_SORUMLUSU"].ToString(),
                        dataReader["KAYIT_YAPAN"].ToString(),
                        dataReader["TAKIP_DURUMU"].ToString()));
                }
                dataReader.Close();
                return malzemes;
            }
            catch (Exception ex)
            {
                return new List<Malzeme>();
            }
        }

        public string Update(Malzeme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoMalzemeGuncelle",
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@tedarikciFirma", entity.TedarikciFirma),
                    new SqlParameter("@onarimDurumu", entity.OnarimDurumu),
                    new SqlParameter("@onarimYeri", entity.OnarimYeri),
                    new SqlParameter("@tedarikTuru", entity.TedarikTuru),
                    new SqlParameter("@parcaSinifi", entity.ParcaSinifi),
                    new SqlParameter("@alternatifParca", entity.AlternatifParca),
                    new SqlParameter("@aciklama", entity.Aciklama),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@sistemStokNo", entity.SistemStokNo),
                    new SqlParameter("@sistemTanim", entity.SistemTanimi),
                    new SqlParameter("@sistemSorumlusu", entity.SistemSorumlusu),
                    new SqlParameter("@islemYapan", entity.IslemYapan));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string MalzemeStokDuzelt(string stokNo, int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeStokDuzelt",
                    new SqlParameter("@stokNo", stokNo),
                    new SqlParameter("@id", id));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static MalzemeDal GetInstance()
        {
            if (malzemeDal == null)
            {
                malzemeDal = new MalzemeDal();
            }
            return malzemeDal;
        }
    }
}
