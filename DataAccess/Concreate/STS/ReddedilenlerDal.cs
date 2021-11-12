using DataAccess.Abstract;
using DataAccess.Database;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.STS
{
    public class ReddedilenlerDal
    {
        static ReddedilenlerDal reddedilenlerDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private ReddedilenlerDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(Reddedilenler entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatReddedilenlerEkle",
                    new SqlParameter("@satno", entity.SatNo),
                    new SqlParameter("@formno",entity.SatFormNo),
                    new SqlParameter("@masrafyeri", entity.MasrafYeri), 
                    new SqlParameter("@talepeden", entity.TalepEden), 
                    new SqlParameter("@bolum", entity.Bolum),
                    new SqlParameter("@usbolgesi", entity.UsBolgesi),
                    new SqlParameter("@abfformno", entity.AbfFormNo),
                    new SqlParameter("@tarih", entity.IstenenTarih), 
                    new SqlParameter("@gerekce", entity.Gerekce), 
                    new SqlParameter("@siparisNo", entity.SiparisNo),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@rednedeni", entity.RedNedeni),
                    new SqlParameter("@durum",entity.Durum),
                    new SqlParameter("@donem",entity.Donem),
                    new SqlParameter("@personelid",entity.PersonelId),
                    new SqlParameter("@butceKodu",entity.ButceKodu),
                    new SqlParameter("@satBirim",entity.SatBirim),
                    new SqlParameter("@harcamaTuru",entity.HarcamaTuru),
                    new SqlParameter("@faturaFirma",entity.FaturaFirma),
                    new SqlParameter("@ilgiliKisi",entity.IlgiliKisi),
                    new SqlParameter("@masrafYeriNo",entity.PersonelMasYeriNo),
                    new SqlParameter("@ucTeklif",entity.UcTeklif),
                    new SqlParameter("@firmaBilgisi",entity.FirmaBilgisi),
                    new SqlParameter("@talepEdenPersonel",entity.TalepEdenPersonel),
                    new SqlParameter("@personelSiparis",entity.PersonelSiparis),
                    new SqlParameter("@unvani",entity.Unvani),
                    new SqlParameter("@personelMasYeriNo",entity.PersonelMasYeriNo),
                    new SqlParameter("@islemAdimi",entity.IslemAdimi),
                    new SqlParameter("@satOlusturmaTuru",entity.SatOlusturmaTuru));
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
                sqlServices.Stored("SatReddedilenlerSil", new SqlParameter("@id", id));
                return "";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Reddedilenler Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reddedilenler> GetList(string durum)
        {
            try
            {
                List<Reddedilenler> reddedilenlers = new List<Reddedilenler>();
                dataReader = sqlServices.StoreReader("SatReddedilenlerGoster", new SqlParameter("@durum", durum));
                while (dataReader.Read())
                {
                    reddedilenlers.Add(new Reddedilenler(
                        dataReader["ID"].ConInt(),
                        dataReader["SAT_FORM_NO"].ConInt(),
                        dataReader["SAT_NO"].ConInt(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["TALEP_EDEN"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["US_BOLGESI"].ToString(),
                        dataReader["ABF_FORM_NO"].ToString(),
                        dataReader["ISTENEN_TARIH"].ConTime(),
                        dataReader["GEREKCE"].ToString(),
                        dataReader["SiparisNo"].ToString(),
                        dataReader["DosyaYolu"].ToString(),
                        dataReader["RED_NEDENI"].ToString(),
                        dataReader["Durum"].ToString(),
                        dataReader["TEKLIF_DURUMU"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["PERSONEL_ID"].ConInt(),
                        dataReader["BUTCE_KODU"].ToString(),
                        dataReader["SAT_BIRIM"].ToString(),
                        dataReader["HARCAMA_TURU"].ToString(),
                        dataReader["FATURA_FIRMA"].ToString(),
                        dataReader["ILGILI_KISI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["UC_TEKLIF"].ConInt(),
                        dataReader["FIRMA_BILGISI"].ToString(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["PERSONEL_SIPARIS"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["PERSONEL_MAS_YER_NO"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["SAT_OLUSTURMA_TURU"].ToString()));
                }
                dataReader.Close();
                return reddedilenlers;
            }
            catch (Exception e)
            {
                return new List<Reddedilenler>();
            }
        }
        
        public string Update(Reddedilenler entity)
        {
            throw new NotImplementedException();
        }
        public void DurumGuncelleRed(string siparisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatDurumOnOnay", new SqlParameter("@siparis", siparisno));
                dataReader.Close();
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public string SatReddedilenlerGuncelle(Reddedilenler entity, string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatReddedilenllerGuncelle",
                    new SqlParameter("@satFormNo", entity.SatFormNo),
                    new SqlParameter("@satNo", entity.SatNo),
                    new SqlParameter("@masrafYeri", entity.MasrafYeri),
                    new SqlParameter("@talepEden", entity.TalepEden),
                    new SqlParameter("@bolum", entity.Bolum),
                    new SqlParameter("@usBolgesi", entity.UsBolgesi),
                    new SqlParameter("@abfFormNo", entity.AbfFormNo),
                    new SqlParameter("@istenenTarih", entity.IstenenTarih),
                    new SqlParameter("@gerekce", entity.Gerekce),
                    new SqlParameter("@siparisNo", siparisNo),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@donem", entity.Donem),
                    new SqlParameter("@personelId", entity.PersonelId),
                    new SqlParameter("@butceKodu", entity.ButceKodu),
                    new SqlParameter("@satBirim", entity.SatBirim),
                    new SqlParameter("@harcamaTuru", entity.HarcamaTuru),
                    new SqlParameter("@faturaFirma", entity.FaturaFirma),
                    new SqlParameter("@ilgiliKisi", entity.IlgiliKisi),
                    new SqlParameter("@masYeriNo", entity.MasrafYeriNo),
                    new SqlParameter("@ucTeklif", entity.UcTeklif),
                    new SqlParameter("@talepEdenPersonel", entity.TalepEdenPersonel),
                    new SqlParameter("@personelSiparis", entity.PersonelSiparis),
                    new SqlParameter("@unvani", entity.Unvani),
                    new SqlParameter("@personelMasYeriNo", entity.PersonelMasYeriNo),
                    new SqlParameter("@islemAdimi", entity.IslemAdimi),
                    new SqlParameter("@durum",entity.Durum),
                    new SqlParameter("@teklifDurumu",entity.TeklifDurumu),
                    new SqlParameter("@firmaBilgisi",entity.FirmaBilgisi),
                    new SqlParameter("@satOlusturmaTuru",entity.SatOlusturmaTuru));

                dataReader.Close();
                return "OK";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static ReddedilenlerDal GetInstance()
        {
            if (reddedilenlerDal == null)
            {
                reddedilenlerDal = new ReddedilenlerDal();
            }
            return reddedilenlerDal;
        }
    }
}
