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
    public class DVKayitDal// : IRepository<DuranVarlikKayit>
    {
        static DVKayitDal kayitDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private DVKayitDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(DuranVarlikKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DuranVarlikKaydet",
                    new SqlParameter("@isakisno", entity.IsAkisNo),
                    new SqlParameter("@dvsahibi", entity.DvSahibi),
                    new SqlParameter("@butcekodu", entity.ButceKodu),
                    new SqlParameter("@dvetiketno", entity.DvEtiketNo),
                    new SqlParameter("@dvgrubu", entity.DvGrubu),
                    new SqlParameter("@dvtanimi", entity.DvTanim),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@marka", entity.Marka),
                    new SqlParameter("@model", entity.Model),
                    new SqlParameter("@serino", entity.SeriNo),
                    new SqlParameter("@kalgerek", entity.KalGerek),
                    new SqlParameter("@satno", entity.SatNo),
                    new SqlParameter("@saticifirma", entity.SaticiFirma),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@faturano", entity.FaturaNo),
                    new SqlParameter("@fiyat", entity.Fiyat),
                    new SqlParameter("@aciklama", entity.Aciklama),
                    new SqlParameter("@dosyayolu", entity.DosyaYolu),
                    new SqlParameter("@fotoyolu", entity.FotoYolu),
                    new SqlParameter("@durumu",entity.Durumu));
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
                dataReader = sqlServices.StoreReader("DuranVarlikSil",new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DuranVarlikKayit Get(string dvEtiketNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DuranVarlikList",new SqlParameter("@dvEtiketNo", dvEtiketNo));
                DuranVarlikKayit item = null;
                while (dataReader.Read())
                {
                    item = new DuranVarlikKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["DV_SAHIBI"].ToString(),
                        dataReader["BUTCE_KODU"].ToString(),
                        dataReader["DV_ETIKET_NO"].ToString(),
                        dataReader["DV_GRUBU"].ToString(),
                        dataReader["DV_TANIM"].ToString(),
                        dataReader["MIKTAR"].ToString(),
                        dataReader["MARKA"].ToString(),
                        dataReader["MODEL"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["KAL_GEREK"].ToString(),
                        dataReader["SAT_NO"].ToString(),
                        dataReader["SATICI_FIRMA"].ToString(),
                        dataReader["FATURA_TARIHI"].ToString(),
                        dataReader["FATURA_NO"].ToString(),
                        dataReader["FIYATI"].ConDouble(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["DURUMU"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["FOTO_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DuranVarlikKayit DvSonNo(string dvSahibi)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DuranVarlikSonNo",new SqlParameter("@dvSahibi",dvSahibi));
                DuranVarlikKayit item = null;
                while (dataReader.Read())
                {
                    item = new DuranVarlikKayit(
                        dataReader["IS_AKIS_NO"].ConInt());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DuranVarlikKayit> GetList()
        {
            try
            {
                List<DuranVarlikKayit> duranVarlikKayits = new List<DuranVarlikKayit>();
                dataReader = sqlServices.StoreReader("DuranVarlikList");
                while (dataReader.Read())
                {
                    duranVarlikKayits.Add(new DuranVarlikKayit(dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["DV_SAHIBI"].ToString(),
                        dataReader["BUTCE_KODU"].ToString(),
                        dataReader["DV_ETIKET_NO"].ToString(),
                        dataReader["DV_GRUBU"].ToString(),
                        dataReader["DV_TANIM"].ToString(),
                        dataReader["MIKTAR"].ToString(),
                        dataReader["MARKA"].ToString(),
                        dataReader["MODEL"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["KAL_GEREK"].ToString(),
                        dataReader["SAT_NO"].ToString(),
                        dataReader["SATICI_FIRMA"].ToString(),
                        dataReader["FATURA_TARIHI"].ToString(),
                        dataReader["FATURA_NO"].ToString(),
                        dataReader["FIYATI"].ConDouble(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["DURUMU"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["FOTO_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString()));
                }
                dataReader.Close();
                return duranVarlikKayits;
            }
            catch (Exception)
            {
                return new List<DuranVarlikKayit>();
            }
        }


        public string Update(DuranVarlikKayit entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DuranVarlikGuncelle",
                    new SqlParameter("@id", id),
                    new SqlParameter("@dvsahibi", entity.DvSahibi),
                    new SqlParameter("@butcekodu", entity.ButceKodu),
                    new SqlParameter("@dvetiketno", entity.DvEtiketNo),
                    new SqlParameter("@dvgrubu", entity.DvGrubu),
                    new SqlParameter("@dvtanimi", entity.DvTanim),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@marka", entity.Marka),
                    new SqlParameter("@model", entity.Model),
                    new SqlParameter("@serino", entity.SeriNo),
                    new SqlParameter("@kalgerek", entity.KalGerek),
                    new SqlParameter("@satno", entity.SatNo),
                    new SqlParameter("@saticifirma", entity.SaticiFirma),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@faturano", entity.FaturaNo),
                    new SqlParameter("@fiyat", entity.Fiyat),
                    new SqlParameter("@aciklama", entity.Aciklama),
                    new SqlParameter("@durumu",entity.Durumu));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static DVKayitDal GetInstance()
        {
            if (kayitDal == null)
            {
                kayitDal = new DVKayitDal();
            }
            return kayitDal;
        }
    }
}
