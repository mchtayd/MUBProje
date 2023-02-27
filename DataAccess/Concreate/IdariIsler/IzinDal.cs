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
    public class IzinDal // : IRepository<Izin>
    {
        static IzinDal izinDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private IzinDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(Izin entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("PersonelIzinKaydet",
                    new SqlParameter("@isakisno", entity.Isakisno),
                    new SqlParameter("@izinkategori", entity.Izinkategori),
                    new SqlParameter("@izinturu", entity.Izinturu),
                    new SqlParameter("@siparisno", entity.Siparisno),
                    new SqlParameter("@adsoyad", entity.Adsoyad),
                    new SqlParameter("@masrafyerino", entity.Masrafyerino),
                    new SqlParameter("@bolum", entity.Bolum),
                    new SqlParameter("@izinnedeni", entity.Izınnedeni),
                    new SqlParameter("@bastarihi", entity.Bastarihi),
                    new SqlParameter("@bittarihi", entity.Bittarihi),
                    new SqlParameter("@unvani", entity.Unvani),
                    new SqlParameter("@toplamsure", entity.Toplamsure),
                    new SqlParameter("@dosyayolu", entity.Dosyayolu),
                    new SqlParameter("@siparis", entity.Siparis));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int isakisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("PersonelIzinSil", new SqlParameter("@isakisno",isakisno));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string IsAkisNoDuzelt(int id, int isAkisNo, string dosyaYolu)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IzinDuzenle",
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
        public string IzinOnay(int id, string onayBilgi)
        {
            try
            {
                dataReader = sqlServices.StoreReader("PersonelIzinOnay",
                    new SqlParameter("@id", id),
                    new SqlParameter("@onayDurum", onayBilgi));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Izin Get(int isakisno, string personelAd)
        {
            try
            {
                dataReader = sqlServices.StoreReader("PersonelIzinList", new SqlParameter("@isakisno", isakisno), new SqlParameter("@personelAd", personelAd));
                Izin item = null;
                while (dataReader.Read())
                {
                    item = new Izin(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["IZIN_KATEGORI"].ToString(),
                        dataReader["IZIN_TURU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["BOLUMU"].ToString(),
                        dataReader["IZIN_NEDENI"].ToString(),
                        dataReader["IZIN_BAS_TARIHI"].ConDate(),
                        dataReader["IZIN_BIT_TARIHI"].ConDate(),
                        dataReader["IZIN_DURUMU"].ToString(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["SIPARIS"].ToString(),
                        dataReader["ONAY_DURUM"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Izin> GetList(int isakisno)
        {
            try
            {
                List<Izin> izins = new List<Izin>();
                dataReader = sqlServices.StoreReader("PersonelIzinList",new SqlParameter("@isakisno",isakisno));
                while (dataReader.Read())
                {
                    izins.Add(new Izin(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["IZIN_KATEGORI"].ToString(),
                        dataReader["IZIN_TURU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["BOLUMU"].ToString(),
                        dataReader["IZIN_NEDENI"].ToString(),
                        dataReader["IZIN_BAS_TARIHI"].ConDate(),
                        dataReader["IZIN_BIT_TARIHI"].ConDate(),
                        dataReader["IZIN_DURUMU"].ToString(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["SIPARIS"].ToString(),
                        dataReader["ONAY_DURUM"].ToString()));
                }
                dataReader.Close();
                return izins;
            }
            catch (Exception)
            {
                return new List<Izin>();
            }
        }
        public List<Izin> GetListOnay()
        {
            try
            {
                List<Izin> izins = new List<Izin>();
                dataReader = sqlServices.StoreReader("PersonelIzinOnayList");
                while (dataReader.Read())
                {
                    izins.Add(new Izin(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["IZIN_KATEGORI"].ToString(),
                        dataReader["IZIN_TURU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["BOLUMU"].ToString(),
                        dataReader["IZIN_NEDENI"].ToString(),
                        dataReader["IZIN_BAS_TARIHI"].ConDate(),
                        dataReader["IZIN_BIT_TARIHI"].ConDate(),
                        dataReader["IZIN_DURUMU"].ToString(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["SIPARIS"].ToString(),
                        dataReader["ONAY_DURUM"].ToString()));
                }
                dataReader.Close();
                return izins;
            }
            catch (Exception)
            {
                return new List<Izin>();
            }
        }
        public List<Izin> GetListIzinlerim(string adSoyad)
        {
            try
            {
                List<Izin> izins = new List<Izin>();
                dataReader = sqlServices.StoreReader("IzinlerimList", new SqlParameter("@personelAd", adSoyad));
                while (dataReader.Read())
                {
                    izins.Add(new Izin(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["IZIN_KATEGORI"].ToString(),
                        dataReader["IZIN_TURU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["BOLUMU"].ToString(),
                        dataReader["IZIN_NEDENI"].ToString(),
                        dataReader["IZIN_BAS_TARIHI"].ConDate(),
                        dataReader["IZIN_BIT_TARIHI"].ConDate(),
                        dataReader["IZIN_DURUMU"].ToString(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["SIPARIS"].ToString(),
                        dataReader["ONAY_DURUM"].ToString()));
                }
                dataReader.Close();
                return izins;
            }
            catch (Exception)
            {
                return new List<Izin>();
            }
        }
        public List<Izin> DevamDevamsizlik()
        {
            try
            {
                List<Izin> izins = new List<Izin>();
                dataReader = sqlServices.StoreReader("DevamIzinList");
                while (dataReader.Read())
                {
                    izins.Add(new Izin(
                        dataReader["IZIN_TURU"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["IZIN_BAS_TARIHI"].ConDate(),
                        dataReader["IZIN_BIT_TARIHI"].ConDate(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["KALAN_SURE"].ToString()));
                }
                dataReader.Close();
                return izins;
            }
            catch (Exception)
            {
                return new List<Izin>();
            }
        }
        public string Update(Izin entity,int isakisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("PersonelIzinGuncelle",
                    new SqlParameter("@isakisno", isakisno),
                    new SqlParameter("@izinkategori", entity.Izinkategori),
                    new SqlParameter("@izinturu", entity.Izinturu),
                    new SqlParameter("@siparisno", entity.Siparisno),
                    new SqlParameter("@adsoyad", entity.Adsoyad),
                    new SqlParameter("@masrafyerino", entity.Masrafyerino),
                    new SqlParameter("@bolum", entity.Bolum),
                    new SqlParameter("@izinnedeni", entity.Izınnedeni),
                    new SqlParameter("@bastarihi", entity.Bastarihi),
                    new SqlParameter("@bittarihi", entity.Bittarihi),
                    new SqlParameter("@unvani",entity.Unvani),
                    new SqlParameter("@toplamsure",entity.Toplamsure),
                    new SqlParameter("@dosyayolu", entity.Dosyayolu));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static IzinDal GetInstance()
        {
            if (izinDal == null)
            {
                izinDal = new IzinDal();
            }
            return izinDal;
        }
    }
}
