using DataAccess.Abstract;
using DataAccess.Database;
using Entity.BakimOnarimAtolye;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.BakimOnarimAtolye
{
    public class AtolyeDal //: IRepository<Atolye>
    {
        static AtolyeDal atolyeDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AtolyeDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Atolye entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AtolyeKayit",
                    new SqlParameter("@abfFormNo",entity.AbfNo),
                    new SqlParameter("@stokNo",entity.SeriNoUst),
                    new SqlParameter("@tanim",entity.TanimUst),
                    new SqlParameter("@seriNo",entity.SeriNoUst),
                    new SqlParameter("@garantiDurumu",entity.GarantiDurumu),
                    new SqlParameter("@bildirimNo",entity.BildirimNo),
                    new SqlParameter("@crmNo",entity.CrmNo),
                    new SqlParameter("@kategori",entity.Kategori),
                    new SqlParameter("@bolgeAdi",entity.BolgeAdi),
                    new SqlParameter("@proje",entity.Proje),
                    new SqlParameter("@bildirilenAriza",entity.BildirilenAriza),
                    new SqlParameter("@icSiparisNo",entity.IcSiparisNo),
                    new SqlParameter("@cekilenTarih",entity.CekildigiTarih),
                    new SqlParameter("@siparisAcmaTarihi",entity.SiparisAcmaTarihi),
                    new SqlParameter("@modifikasyonlar",entity.Modifikasyonlar),
                    new SqlParameter("@notlar",entity.Notlar),
                    new SqlParameter("@islemAdimi",entity.IslemAdimi),
                    new SqlParameter("@siparisNo",entity.SiparisNo));

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

        public Atolye Get(string icSiparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AtolyeListele",new SqlParameter("@icSiparisNo",icSiparisNo));
                Atolye item = null;
                while (dataReader.Read())
                {
                    item = new Atolye(
                        dataReader["ID"].ConInt(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString(),
                        dataReader["CRM_NO"].ToString(),
                        dataReader["KATEGORI"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["PROJE"].ToString(),
                        dataReader["BILDIRILEN_ARIZA"].ToString(),
                        dataReader["IC_SIPARIS_NO"].ToString(),
                        dataReader["CEKILDIGI_TARIHI"].ConTime(),
                        dataReader["SIPARIS_ACMA_TARIHI"].ConTime(),
                        dataReader["MODIFIKASYONLAR"].ToString(),
                        dataReader["NOTLAR"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Atolye> AtolyeIcSiparis(string icSiparisNo)
        {
            try
            {
                List<Atolye> atolyes = new List<Atolye>();
                dataReader = sqlServices.StoreReader("AtolyeListele",new SqlParameter("@icSiparisNo", icSiparisNo));
                while (dataReader.Read())
                {
                    atolyes.Add(new Atolye(
                        dataReader["ID"].ConInt(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString(),
                        dataReader["CRM_NO"].ToString(),
                        dataReader["KATEGORI"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["PROJE"].ToString(),
                        dataReader["BILDIRILEN_ARIZA"].ToString(),
                        dataReader["IC_SIPARIS_NO"].ToString(),
                        dataReader["CEKILDIGI_TARIHI"].ConTime(),
                        dataReader["SIPARIS_ACMA_TARIHI"].ConTime(),
                        dataReader["MODIFIKASYONLAR"].ToString(),
                        dataReader["NOTLAR"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return atolyes;
            }
            catch (Exception)
            {
                return new List<Atolye>();
            }
        }

        public Atolye ArizaGetir(int abfNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AtolyeAbfBul", new SqlParameter("@abfNo", abfNo));
                Atolye item = null;
                while (dataReader.Read())
                {
                    item = new Atolye(
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["GARANTI"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString(),
                        dataReader["CRM_NO"].ToString(),
                        dataReader["KATEGORI"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["PROJE"].ToString(),
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

        public List<Atolye> GetList()
        {
            try
            {
                List<Atolye> atolyes = new List<Atolye>();
                dataReader = sqlServices.StoreReader("AtolyeListele");
                while (dataReader.Read())
                {
                    atolyes.Add(new Atolye(
                        dataReader["ID"].ConInt(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["GARANTI_DURUMU"].ToString(),
                        dataReader["BILDIRIM_NO"].ToString(),
                        dataReader["CRM_NO"].ToString(),
                        dataReader["KATEGORI"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["PROJE"].ToString(),
                        dataReader["BILDIRILEN_ARIZA"].ToString(),
                        dataReader["IC_SIPARIS_NO"].ToString(),
                        dataReader["CEKILDIGI_TARIHI"].ConTime(),
                        dataReader["SIPARIS_ACMA_TARIHI"].ConTime(),
                        dataReader["MODIFIKASYONLAR"].ToString(),
                        dataReader["NOTLAR"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return atolyes;
            }
            catch (Exception)
            {
                return new List<Atolye>();
            }
        }

        public string Update(Atolye entity)
        {
            throw new NotImplementedException();
        }
        public static AtolyeDal GetInstance()
        {
            if (atolyeDal == null)
            {
                atolyeDal = new AtolyeDal();
            }
            return atolyeDal;
        }
    }
}
