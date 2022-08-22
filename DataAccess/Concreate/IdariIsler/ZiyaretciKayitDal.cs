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
    public class ZiyaretciKayitDal // : IRepository<ZiyaretciKayit>
    {
        static ZiyaretciKayitDal ziyaretciKayitDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private ZiyaretciKayitDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(ZiyaretciKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ZiyaretciKayit",
                    new SqlParameter("@isAkisNo",entity.IsAkisNo),
                    new SqlParameter("@ziyaretciAd",entity.ZiyaretciAd),
                    new SqlParameter("@tc",entity.Tc),
                    new SqlParameter("@firmaAdi",entity.FirmaAdi),
                    new SqlParameter("@geldigiTarihSaat",entity.GeldigiTarihSaat),
                    new SqlParameter("@ziyaretNedeni",entity.ZiyaretNedeni),
                    new SqlParameter("@ziyaretEdilenAd",entity.ZiyaretEdilenAd),
                    new SqlParameter("@ziyaretEdilenUnvani",entity.ZiyaretEdilenUnvani),
                    new SqlParameter("@ziyaretEdilenMasYerNo",entity.ZiyaretEdilenMasYeriNo),
                    new SqlParameter("@ziyaretEdilenMasYer",entity.ZiyaretEdilenMasYeri),
                    new SqlParameter("@refakateciAd",entity.RefakatciAd),
                    new SqlParameter("@refakatciUnvani",entity.RefakatciUnvani),
                    new SqlParameter("@refakatciMasYeriNo",entity.RefakatciMasYeriNo),
                    new SqlParameter("@refakatciMasYeri",entity.RefakatciMasYeri));
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

        public ZiyaretciKayit Get(int isAkisNo)
        {
            dataReader = sqlServices.StoreReader("ZiyaretciList",new SqlParameter("@isAkisNo",isAkisNo));
            ZiyaretciKayit item = null;
            while (dataReader.Read())
            {
                item = new ZiyaretciKayit(dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["ZIYARETCI_AD"].ToString(),
                        dataReader["TC"].ToString(),
                        dataReader["FIRMA_ADI"].ToString(),
                        dataReader["GELDIGI_TARIH_SAAT"].ConDate(),
                        dataReader["ZIYARET_NEDENI"].ToString(),
                        dataReader["ZIYARET_EDILEN_AD"].ToString(),
                        dataReader["ZIYARET_EDILEN_UNVANI"].ToString(),
                        dataReader["ZIYARET_EDILEN_MAS_YER_NO"].ToString(),
                        dataReader["ZIYARET_EDILEN_MAS_YERI"].ToString(),
                        dataReader["REFAKATCI_AD"].ToString(),
                        dataReader["REFAKATCI_UNVANI"].ToString(),
                        dataReader["REFAKATCI_MAS_YERI_NO"].ToString(),
                        dataReader["REFAKATCI_MAS_YERI"].ToString());
            }
            dataReader.Close();
            return item;
        }
        public string IsAkisNoDuzelt(int id, int isAkisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ZiyaretciKayitDuzelt",
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

        public List<ZiyaretciKayit> GetList(int isAkisNo)
        {
            try
            {
                List<ZiyaretciKayit> ziyaretciKayits = new List<ZiyaretciKayit>();
                dataReader = sqlServices.StoreReader("ZiyaretciList", new SqlParameter("@isAkisNo", isAkisNo));
                while (dataReader.Read())
                {
                    ziyaretciKayits.Add(new ZiyaretciKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["ZIYARETCI_AD"].ToString(),
                        dataReader["TC"].ToString(),
                        dataReader["FIRMA_ADI"].ToString(),
                        dataReader["GELDIGI_TARIH_SAAT"].ConDate(),
                        dataReader["ZIYARET_NEDENI"].ToString(),
                        dataReader["ZIYARET_EDILEN_AD"].ToString(),
                        dataReader["ZIYARET_EDILEN_UNVANI"].ToString(),
                        dataReader["ZIYARET_EDILEN_MAS_YER_NO"].ToString(),
                        dataReader["ZIYARET_EDILEN_MAS_YERI"].ToString(),
                        dataReader["REFAKATCI_AD"].ToString(),
                        dataReader["REFAKATCI_UNVANI"].ToString(),
                        dataReader["REFAKATCI_MAS_YERI_NO"].ToString(),
                        dataReader["REFAKATCI_MAS_YERI"].ToString()));
                }
                dataReader.Close();
                return ziyaretciKayits;
            }
            catch (Exception)
            {
                return new List<ZiyaretciKayit>();
            }
        }

        public string Update(ZiyaretciKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ZiyaretciGuncelle",
                    new SqlParameter("@isAkisNo", entity.IsAkisNo),
                    new SqlParameter("@ziyaretciAd", entity.ZiyaretciAd),
                    new SqlParameter("@tc", entity.Tc),
                    new SqlParameter("@firmaAdi", entity.FirmaAdi),
                    new SqlParameter("@geldigiTarihSaat", entity.GeldigiTarihSaat),
                    new SqlParameter("@ziyaretNedeni", entity.ZiyaretNedeni),
                    new SqlParameter("@ziyaretEdilenAd", entity.ZiyaretEdilenAd),
                    new SqlParameter("@ziyaretEdilenUnvani", entity.ZiyaretEdilenUnvani),
                    new SqlParameter("@ziyaretEdilenMasYerNo", entity.ZiyaretEdilenMasYeriNo),
                    new SqlParameter("@ziyaretEdilenMasYer", entity.ZiyaretEdilenMasYeri),
                    new SqlParameter("@refakateciAd", entity.RefakatciAd),
                    new SqlParameter("@refakatciUnvani", entity.RefakatciUnvani),
                    new SqlParameter("@refakatciMasYeriNo", entity.RefakatciMasYeriNo),
                    new SqlParameter("@refakatciMasYeri", entity.RefakatciMasYeri));
                dataReader.Close();
                return "OK";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static ZiyaretciKayitDal GetInstance()
        {
            if (ziyaretciKayitDal == null)
            {
                ziyaretciKayitDal = new ZiyaretciKayitDal();
            }
            return ziyaretciKayitDal;
        }
    }
}
