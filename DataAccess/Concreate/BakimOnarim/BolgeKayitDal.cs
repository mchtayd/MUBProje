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
    public class BolgeKayitDal //: IRepository<BolgeKayit>
    {
        static BolgeKayitDal bolgeKayitDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private BolgeKayitDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public static BolgeKayitDal GetInstance()
        {
            if (bolgeKayitDal == null)
            {
                bolgeKayitDal = new BolgeKayitDal();
            }
            return bolgeKayitDal;
        }

        public string Add(BolgeKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BolgeAdd",
                    new SqlParameter("@bolgeAdi", entity.BolgeAdi),
                    new SqlParameter("@kodAdi", entity.KodAdi),
                    new SqlParameter("@usBolgesiStok", entity.UsBolgesiStok),
                    new SqlParameter("@kabulTarihi", entity.KabulTarihi),
                    new SqlParameter("@guvenlikYazilimi", entity.GuvenlikYazilimi),
                    new SqlParameter("@kesifGozetlemeTuru", entity.KesifGozetlemeTuru),
                    new SqlParameter("@yasamAlani", entity.YasamAlani),
                    new SqlParameter("@tabur", entity.Tabur),
                    new SqlParameter("@tugay", entity.Tugay),
                    new SqlParameter("@il", entity.Il),
                    new SqlParameter("@ilce", entity.Ilce),
                    new SqlParameter("@birlikAdresi", entity.BirlikAdresi),
                    new SqlParameter("@garantiBaslama", entity.GarantiBaslama),
                    new SqlParameter("@garantiBitis", entity.GarantiBitis),
                    new SqlParameter("@bolgeSorumlusu", entity.BolgeSorumlusu),
                    new SqlParameter("@depo", entity.Depo),
                    new SqlParameter("@pypNo", entity.PypNo),
                    new SqlParameter("@siparisNo", entity.SiparisNo),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@proje", entity.Proje));

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
                sqlServices.Stored("BolgeDelete", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public BolgeKayit Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BolgeGetlist", new SqlParameter("@id", id));
                BolgeKayit item = null;
                while (dataReader.Read())
                {
                    item = new BolgeKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["KOD_ADI"].ToString(),
                        dataReader["PROJE"].ToString(),
                        dataReader["US_BOLGESI_STOK"].ToString(),
                        dataReader["KABUL_TARIHI"].ConDate(),
                        dataReader["GUVENLIK_YAZILIMI"].ToString(),
                        dataReader["KESIF_GOZETLEME_TURU"].ToString(),
                        dataReader["YASAM_ALANI"].ToString(),
                        dataReader["BAGLI_OLDUGU_TABUR"].ToString(),
                        dataReader["BAGLI_OLDUGU_TUGAY"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["BIRLIK_ADRESI"].ToString(),
                        dataReader["GARANTI_BASLAMA"].ConDate(),
                        dataReader["GARANTI_BITIS"].ConDate(),
                        dataReader["BOLGE_SORUMLUSU"].ToString(),
                        dataReader["DEPO"].ToString(),
                        dataReader["PYP_NO"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
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
        public string BolgeProjeList(string bolgeAdi)
        {
            try
            {
                string proje = "";
                dataReader = sqlServices.StoreReader("BolgeProjeBilgisiList", new SqlParameter("@bolgeAdi", bolgeAdi));
                while (dataReader.Read())
                {
                    proje = dataReader["PROJE"].ToString();
                }
                dataReader.Close();
                return proje;

            }
            catch (Exception)
            {
                return "";
            }
        }
        public string BolgeGarantiDurumList(string bolgeAdi)
        {
            try
            {
                string proje = "";
                dataReader = sqlServices.StoreReader("BolgeGarantiDurumList", new SqlParameter("@bolgeAdi", bolgeAdi));
                while (dataReader.Read())
                {
                    proje = dataReader["PROJE"].ToString();
                }
                dataReader.Close();
                return proje;

            }
            catch (Exception)
            {
                return "";
            }
        }

        public List<BolgeKayit> GetList()
        {
            try
            {
                List<BolgeKayit> bolgeKayits = new List<BolgeKayit>();
                dataReader = sqlServices.StoreReader("BolgeGetlist");
                while (dataReader.Read())
                {
                    bolgeKayits.Add(new BolgeKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["KOD_ADI"].ToString(),
                        dataReader["PROJE"].ToString(),
                        dataReader["US_BOLGESI_STOK"].ToString(),
                        dataReader["KABUL_TARIHI"].ConDate(),
                        dataReader["GUVENLIK_YAZILIMI"].ToString(),
                        dataReader["KESIF_GOZETLEME_TURU"].ToString(),
                        dataReader["YASAM_ALANI"].ToString(),
                        dataReader["BAGLI_OLDUGU_TABUR"].ToString(),
                        dataReader["BAGLI_OLDUGU_TUGAY"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["BIRLIK_ADRESI"].ToString(),
                        dataReader["GARANTI_BASLAMA"].ConDate(),
                        dataReader["GARANTI_BITIS"].ConDate(),
                        dataReader["BOLGE_SORUMLUSU"].ToString(),
                        dataReader["DEPO"].ToString(),
                        dataReader["PYP_NO"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return bolgeKayits;
            }
            catch (Exception)
            {
                return new List<BolgeKayit>();
            }
        }
        public List<BolgeKayit> GetListBolgeKomutanlik(string il)
        {
            try
            {
                List<BolgeKayit> bolgeKayits = new List<BolgeKayit>();
                dataReader = sqlServices.StoreReader("BolgeKomutanlikList", new SqlParameter("@il", il));
                while (dataReader.Read())
                {
                    bolgeKayits.Add(new BolgeKayit(
                        dataReader["BAGLI_OLDUGU_TUGAY"].ToString()));
                }
                dataReader.Close();
                return bolgeKayits;
            }
            catch (Exception ex)
            {
                return new List<BolgeKayit>();
            }
        }

        public string Update(BolgeKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BolgeUpdate",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@bolgeAdi", entity.BolgeAdi),
                    new SqlParameter("@kodAdi", entity.KodAdi),
                    new SqlParameter("@usBolgesiStok", entity.UsBolgesiStok),
                    new SqlParameter("@kabulTarihi", entity.KabulTarihi),
                    new SqlParameter("@guvenlikYazilimi", entity.GuvenlikYazilimi),
                    new SqlParameter("@kesifGozetlemeTuru", entity.KesifGozetlemeTuru),
                    new SqlParameter("@yasamAlani", entity.YasamAlani),
                    new SqlParameter("@tabur", entity.Tabur),
                    new SqlParameter("@tugay", entity.Tugay),
                    new SqlParameter("@il", entity.Il),
                    new SqlParameter("@ilce", entity.Ilce),
                    new SqlParameter("@birlikAdresi", entity.BirlikAdresi),
                    new SqlParameter("@bolgeSorumlusu", entity.BolgeSorumlusu),
                    new SqlParameter("@depo", entity.Depo),
                    new SqlParameter("@pypNo", entity.PypNo),
                    new SqlParameter("@proje", entity.Proje),
                    new SqlParameter("@garantiBaslama", entity.GarantiBaslama),
                    new SqlParameter("@garantiBitis", entity.GarantiBitis));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateSiparisNo(int id, string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BolgeSiparisGuncelle",
                    new SqlParameter("@id", id),
                    new SqlParameter("@siparisNo", siparisNo));

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
