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
    public class StokGirisCikisDal //: IRepository<StokGirisCıkıs>
    {
        static StokGirisCikisDal stokGirisCikisDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private StokGirisCikisDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(StokGirisCıkıs entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("StokGirisCikisEkle",
                    new SqlParameter("@islemturu", entity.Islemturu),
                    new SqlParameter("@stokno", entity.Stokno),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@islemTarihi", entity.IslemTarihi),
                    new SqlParameter("@cekilenDepo", entity.CekilenDepoNo),
                    new SqlParameter("@cekilenDepoAdresi", entity.CekilenDepoAdresi),
                    new SqlParameter("@cekilenMalzemeYeri", entity.CekilenMalzemeYeri),
                    new SqlParameter("@dusulenDepo",entity.DusulenDepoNo),
                    new SqlParameter("@dusulenDepoAdresi",entity.DusulenDepoAdresi),
                    new SqlParameter("@dusulenMalzemeYeri",entity.DusulenMalzemeYeri),
                    new SqlParameter("@dusulenMiktar",entity.DusulenMiktar),
                    new SqlParameter("@talepEdenPersonel",entity.TalepEdenPersonel),
                    new SqlParameter("@aciklama",entity.Aciklama),
                    new SqlParameter("@serino",entity.Serino),
                    new SqlParameter("@lotno",entity.Lotno),
                    new SqlParameter("@revizyon",entity.Revizyon));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(string stokNo, string seriNo, string lotNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("StokGirisCikisSil", new SqlParameter("@stokNo", stokNo), new SqlParameter("@seriNo", seriNo), new SqlParameter("@lotNo", lotNo));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string DeleteId(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoGirisCikisDeleteId", new SqlParameter("@id", id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string DepoBirimFiyat(double birimFiyat,string stokNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoGirisCikisBirimFiyat", new SqlParameter("@stokNo", stokNo), new SqlParameter("@birimFiyat", birimFiyat));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public double DepoBirimFiyat(string stokNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoBirimFiyatBul",new SqlParameter("@stokNo",stokNo));
                double birimFiyat = 0;
                while (dataReader.Read())
                {
                    birimFiyat = dataReader["BIRIM_FIYAT"].ConDouble();
                }
                dataReader.Close();
                return birimFiyat;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public StokGirisCıkıs Get(string stokNo,string depoNo,string seriNo,string lotNo,string revizyon)
        {
            try
            {
                dataReader = sqlServices.StoreReader("StokGirisCikisList", new SqlParameter("@stokNo", stokNo),
                    new SqlParameter("@depoNo",depoNo),
                    new SqlParameter("@seriNo",seriNo),
                    new SqlParameter("@lotNo",lotNo),
                    new SqlParameter("@revizyon",revizyon));
                StokGirisCıkıs item = null;
                while (dataReader.Read())
                {
                    item = new StokGirisCıkıs(
                        dataReader["ID"].ConInt(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["ISLEM_TARIH"].ConDate(),
                        dataReader["CEKILEN_DEPO"].ToString(),
                        dataReader["CEKILEN_DEPO_ADRESI"].ToString(),
                        dataReader["CEKILEN_MALZEME_YERI"].ToString(),
                        dataReader["DUSULEN_DEPO"].ToString(),
                        dataReader["DUSULEN_DEPO_ADRESI"].ToString(),
                        dataReader["DUSULEN_MALZEME_YERI"].ToString(),
                        dataReader["DUSULEN_MIKTAR"].ConInt(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["LOT_NO"].ToString(),
                        dataReader["REVIZYON"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public StokGirisCıkıs GetId(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoGirisCikisGet", new SqlParameter("@id", id));
                StokGirisCıkıs item = null;
                while (dataReader.Read())
                {
                    item = new StokGirisCıkıs(
                        dataReader["ID"].ConInt(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["ISLEM_TARIH"].ConDate(),
                        dataReader["CEKILEN_DEPO"].ToString(),
                        dataReader["CEKILEN_DEPO_ADRESI"].ToString(),
                        dataReader["CEKILEN_MALZEME_YERI"].ToString(),
                        dataReader["DUSULEN_DEPO"].ToString(),
                        dataReader["DUSULEN_DEPO_ADRESI"].ToString(),
                        dataReader["DUSULEN_MALZEME_YERI"].ToString(),
                        dataReader["DUSULEN_MIKTAR"].ConInt(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["LOT_NO"].ToString(),
                        dataReader["REVIZYON"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public StokGirisCıkıs DepoRafBul(string stokNo,string depoNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoRafBul", new SqlParameter("@stokNo", stokNo),new SqlParameter("@depoNo",depoNo));
                StokGirisCıkıs item = null;
                while (dataReader.Read())
                {
                    item = new StokGirisCıkıs(
                        dataReader["ID"].ConInt(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["ISLEM_TARIH"].ConDate(),
                        dataReader["CEKILEN_DEPO"].ToString(),
                        dataReader["CEKILEN_DEPO_ADRESI"].ToString(),
                        dataReader["CEKILEN_MALZEME_YERI"].ToString(),
                        dataReader["DUSULEN_DEPO"].ToString(),
                        dataReader["DUSULEN_DEPO_ADRESI"].ToString(),
                        dataReader["DUSULEN_MALZEME_YERI"].ToString(),
                        dataReader["DUSULEN_MIKTAR"].ConInt(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["LOT_NO"].ToString(),
                        dataReader["REVIZYON"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public StokGirisCıkıs BildirimdenDepoya(string stokNo, string seriNo,string lotNo,string revizyon,string dusulenDepoAbf)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BildirimdenDepoyaControl", 
                    new SqlParameter("@stokNo", stokNo), 
                    new SqlParameter("@seriNo", seriNo),
                    new SqlParameter("@lotNo",lotNo),
                    new SqlParameter("@revizyon",revizyon),
                    new SqlParameter("@dusulenDepoAbf",dusulenDepoAbf));
                StokGirisCıkıs item = null;
                while (dataReader.Read())
                {
                    item = new StokGirisCıkıs(
                        dataReader["STOK_NO"].ToString(),
                        dataReader["DUSULEN_DEPO"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["LOT_NO"].ToString(),
                        dataReader["REVIZYON"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public StokGirisCıkıs StokGor(string stokNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoMevcutStokGor", new SqlParameter("@stokNo", stokNo));
                StokGirisCıkıs item = null;
                while (dataReader.Read())
                {
                    //item = new StokGirisCıkıs(dataReader["MEVCUT_MIKTAR"].ConInt());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
            
        }


        public List<StokGirisCıkıs> GetList(string stokNo,string seriNo)
        {
            try
            {
                List<StokGirisCıkıs> stokGirisCıkıs = new List<StokGirisCıkıs>();
                dataReader = sqlServices.StoreReader("StokGirisCikisList",new SqlParameter("@stokNo", stokNo),new SqlParameter("@seriNo",seriNo));
                while (dataReader.Read())
                {
                    stokGirisCıkıs.Add(new StokGirisCıkıs(
                        dataReader["ID"].ConInt(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["ISLEM_TARIH"].ConDate(),
                        dataReader["CEKILEN_DEPO"].ToString(),
                        dataReader["CEKILEN_DEPO_ADRESI"].ToString(),
                        dataReader["CEKILEN_MALZEME_YERI"].ToString(),
                        dataReader["DUSULEN_DEPO"].ToString(),
                        dataReader["DUSULEN_DEPO_ADRESI"].ToString(),
                        dataReader["DUSULEN_MALZEME_YERI"].ToString(),
                        dataReader["DUSULEN_MIKTAR"].ConInt(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["LOT_NO"].ToString(),
                        dataReader["REVIZYON"].ToString()));
                }
                dataReader.Close();
                return stokGirisCıkıs;
            }
            catch (Exception)
            {
                return new List<StokGirisCıkıs>();
            }
        }
        public List<StokGirisCıkıs> GetListEdit(string stokNo, string seriNo, string lotNo)
        {
            try
            {
                List<StokGirisCıkıs> stokGirisCıkıs = new List<StokGirisCıkıs>();
                dataReader = sqlServices.StoreReader("StokGirisCikisEditList", new SqlParameter("@stokNo", stokNo), new SqlParameter("@seriNo", seriNo), new SqlParameter("@lotNo", lotNo));
                while (dataReader.Read())
                {
                    stokGirisCıkıs.Add(new StokGirisCıkıs(
                        dataReader["ID"].ConInt(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["ISLEM_TARIH"].ConDate(),
                        dataReader["CEKILEN_DEPO"].ToString(),
                        dataReader["CEKILEN_DEPO_ADRESI"].ToString(),
                        dataReader["CEKILEN_MALZEME_YERI"].ToString(),
                        dataReader["DUSULEN_DEPO"].ToString(),
                        dataReader["DUSULEN_DEPO_ADRESI"].ToString(),
                        dataReader["DUSULEN_MALZEME_YERI"].ToString(),
                        dataReader["DUSULEN_MIKTAR"].ConInt(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["LOT_NO"].ToString(),
                        dataReader["REVIZYON"].ToString()));
                }
                dataReader.Close();
                return stokGirisCıkıs;
            }
            catch (Exception)
            {
                return new List<StokGirisCıkıs>();
            }
        }

        public List<StokGirisCıkıs> AtolyeDepoHareketleri(string abfSiparisNo)
        {
            try
            {
                List<StokGirisCıkıs> stokGirisCıkıs = new List<StokGirisCıkıs>();
                dataReader = sqlServices.StoreReader("AtolyeDepoHareketleri", new SqlParameter("@abfSiparisNo", abfSiparisNo));
                while (dataReader.Read())
                {
                    stokGirisCıkıs.Add(new StokGirisCıkıs(
                        dataReader["ID"].ConInt(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["ISLEM_TARIH"].ConDate(),
                        dataReader["CEKILEN_DEPO"].ToString(),
                        dataReader["CEKILEN_DEPO_ADRESI"].ToString(),
                        dataReader["CEKILEN_MALZEME_YERI"].ToString(),
                        dataReader["DUSULEN_DEPO"].ToString(),
                        dataReader["DUSULEN_DEPO_ADRESI"].ToString(),
                        dataReader["DUSULEN_MALZEME_YERI"].ToString(),
                        dataReader["DUSULEN_MIKTAR"].ConInt(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["LOT_NO"].ToString(),
                        dataReader["REVIZYON"].ToString()));
                }
                dataReader.Close();
                return stokGirisCıkıs;
            }
            catch (Exception)
            {
                return new List<StokGirisCıkıs>();
            }
        }

        public string Update(StokGirisCıkıs entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("StokGirisCikisGuncelle",
                   new SqlParameter("@id", id),
                   new SqlParameter("@islemturu", entity.Islemturu),
                    new SqlParameter("@stokno", entity.Stokno),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@islemTarihi", entity.IslemTarihi),
                    new SqlParameter("@cekilenDepo", entity.CekilenDepoNo),
                    new SqlParameter("@cekilenDepoAdresi", entity.CekilenDepoAdresi),
                    new SqlParameter("@cekilenMalzemeYeri", entity.CekilenMalzemeYeri),
                    new SqlParameter("@dusulenDepo", entity.DusulenDepoNo),
                    new SqlParameter("@dusulenDepoAdresi", entity.DusulenDepoAdresi),
                    new SqlParameter("@dusulenMalzemeYeri", entity.DusulenMalzemeYeri),
                    new SqlParameter("@dusulenMiktar", entity.DusulenMiktar),
                    new SqlParameter("@talepEdenPersonel", entity.TalepEdenPersonel),
                    new SqlParameter("@aciklama", entity.Aciklama),
                    new SqlParameter("@serino", entity.Serino),
                    new SqlParameter("@lotno", entity.Lotno),
                    new SqlParameter("@revizyon", entity.Revizyon));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateEdit(StokGirisCıkıs entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("StokGirisCikisEdit",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@stokNo", entity.Stokno),
                    new SqlParameter("@islemTarihi", entity.IslemTarihi),
                    new SqlParameter("@dusulenDepoNo", entity.DusulenDepoNo),
                    new SqlParameter("@depoAdres", entity.DusulenDepoAdresi),
                    new SqlParameter("@depoLokasyon", entity.DusulenMalzemeYeri),
                    new SqlParameter("@miktar", entity.DusulenMiktar),
                    new SqlParameter("@aciklama", entity.Aciklama),
                    new SqlParameter("@seriNo", entity.Serino),
                    new SqlParameter("@lotNo", entity.Lotno),
                    new SqlParameter("@revizyon", entity.Revizyon));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static StokGirisCikisDal GetInstance()
        {
            if (stokGirisCikisDal == null)
            {
                stokGirisCikisDal = new StokGirisCikisDal();
            }
            return stokGirisCikisDal;
        }
    }
}
