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
    public class TamamlananDal // : IRepository<Tamamlanan>
    {
        static TamamlananDal tamamlananDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private TamamlananDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(Tamamlanan entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTamamlananlarEkle",
                    new SqlParameter("@formno", entity.Formno),
                    new SqlParameter("@satno", entity.Satno),
                    new SqlParameter("@masrafyeri", entity.Masrafyeri),
                    new SqlParameter("@talepeden", entity.Talepeden),
                    new SqlParameter("@bolum", entity.Bolum),
                    new SqlParameter("@usbolgesi", entity.Usbolgesi),
                    new SqlParameter("@abfformno", entity.Abfform),
                    new SqlParameter("@istenentarih", entity.Istenentarih),
                    new SqlParameter("@tamamlanantarih", entity.Tamamlanantarih),
                    new SqlParameter("@gerekce", entity.Gerekce),
                    new SqlParameter("@butcekodukalemi", entity.Butcekodukalemi),
                    new SqlParameter("@satbirim", entity.Satbirim),
                    new SqlParameter("@harcamaturu", entity.Harcamaturu),
                    new SqlParameter("@belgeturu", entity.Belgeturu),
                    new SqlParameter("@belgenumarasi", entity.Belgenumarasi),
                    new SqlParameter("@belgetarihi", entity.Belgetarihi),
                    new SqlParameter("@faturafirma", entity.Faturaedilecekfirma),
                    new SqlParameter("@ilgilikisi", entity.Ilgilikisi),
                    new SqlParameter("@masrafyerino", entity.Masrafyerino),
                    new SqlParameter("@harcanantutar", entity.Harcanantutar),
                    new SqlParameter("@dosyayolu", entity.Dosyayolu),
                    new SqlParameter("@siparisno", entity.Siparisno),
                    new SqlParameter("@ucteklif", entity.Ucteklif),
                    new SqlParameter("@islemAdimi", entity.IslemAdimi),
                    new SqlParameter("@donem", entity.Donem),
                    new SqlParameter("@satOlusturaTuru",entity.SatOlusturmaTuru),
                    new SqlParameter("@proje",entity.Proje),
                    new SqlParameter("@satinAlinanFirma",entity.SatinAlinanFirma),
                    new SqlParameter("@harcamaYapan",entity.HarcamaYapan));


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

        public Tamamlanan Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tamamlanan> GetList()
        {
            try
            {
                List<Tamamlanan> tamamlanans = new List<Tamamlanan>();
                dataReader = sqlServices.StoreReader("SatTamamlananlarListele");
                while (dataReader.Read())
                {
                    tamamlanans.Add(new Tamamlanan(
                        dataReader["ID"].ConInt(),
                        dataReader["SAT_FORM_NO"].ConInt(),
                        dataReader["SAT_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["TALEP_EDEN"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["US_BOLGESI"].ToString(),
                        dataReader["ABF_FORM_NO"].ToString(),
                        dataReader["ISTENEN_TARIH"].ConTime(),
                        dataReader["TAMAMLANAN_TARIH"].ConTime(),
                        dataReader["GEREKCE"].ToString(),
                        dataReader["BUTCE_KODU_KALEMI"].ToString(),
                        dataReader["SAT_BIRIM"].ToString(),
                        dataReader["HARCAMA_TURU"].ToString(),
                        dataReader["FATURA_EDILECEK_FIRMA"].ToString(),
                        dataReader["ILGILI_KISI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["HARCANAN_TUTAR"].ConDouble(),
                        dataReader["BELGE_TURU"].ToString(),
                        dataReader["BELGE_NUMARASI"].ToString(),
                        dataReader["BELGE_TARIHI"].ConTime(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["UC_TEKLIF"].ConInt(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["SAT_OLUSTURMA_TURU"].ToString(),
                        dataReader["PROJE"].ToString(),
                        dataReader["SATIN_ALINAN_FIRMA"].ToString(),
                        dataReader["HARCAMA_YAPAN"].ToString()));
                }
                dataReader.Close();
                return tamamlanans;

            }
            catch (Exception ex)
            {
                return new List<Tamamlanan>();
            }
        }
        public List<Tamamlanan> GetListDirektorluk()
        {
            try
            {
                List<Tamamlanan> tamamlanans = new List<Tamamlanan>();
                dataReader = sqlServices.StoreReader("SatTamamlananlarDirektorluk");
                while (dataReader.Read())
                {
                    tamamlanans.Add(new Tamamlanan(
                        dataReader["ID"].ConInt(),
                        dataReader["SAT_FORM_NO"].ConInt(),
                        dataReader["SAT_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["TALEP_EDEN"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["US_BOLGESI"].ToString(),
                        dataReader["ABF_FORM_NO"].ToString(),
                        dataReader["ISTENEN_TARIH"].ConTime(),
                        dataReader["TAMAMLANAN_TARIH"].ConTime(),
                        dataReader["GEREKCE"].ToString(),
                        dataReader["BUTCE_KODU_KALEMI"].ToString(),
                        dataReader["SAT_BIRIM"].ToString(),
                        dataReader["HARCAMA_TURU"].ToString(),
                        dataReader["FATURA_EDILECEK_FIRMA"].ToString(),
                        dataReader["ILGILI_KISI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["HARCANAN_TUTAR"].ConDouble(),
                        dataReader["BELGE_TURU"].ToString(),
                        dataReader["BELGE_NUMARASI"].ToString(),
                        dataReader["BELGE_TARIHI"].ConTime(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["UC_TEKLIF"].ConInt(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["SAT_OLUSTURMA_TURU"].ToString(),
                        dataReader["PROJE"].ToString(),
                        dataReader["SATIN_ALINAN_FIRMA"].ToString(),
                        dataReader["HARCAMA_YAPAN"].ToString()));
                }
                dataReader.Close();
                return tamamlanans;

            }
            catch (Exception ex)
            {
                return new List<Tamamlanan>();
            }
        }
        public string SatFirmaGuncelle(string siparisNo, string proje, string firma)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatFirmaBilgisiGuncelleTamamlanan",
                    new SqlParameter("@siparisNo", siparisNo),
                    new SqlParameter("@proje", proje),
                    new SqlParameter("@satFirma", firma));
                dataReader.Close();
                return "OK";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateTutar(double tutar, string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("TamamlananSatFiyatGuncelle",
                    new SqlParameter("@tutar",tutar),
                    new SqlParameter("@siparisNo",siparisNo));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string DonemDuzet(string donem, int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("TamamlananlarDonemDuzelt",
                    new SqlParameter("@donem", donem),
                    new SqlParameter("@id", id));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string ProjeDuzelt(string proje, int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("TamamlananlarProjeDuzelt",
                    new SqlParameter("@proje", proje),
                    new SqlParameter("@id", id));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static TamamlananDal GetInstance()
        {
            if (tamamlananDal == null)
            {
                tamamlananDal = new TamamlananDal();
            }
            return tamamlananDal;
        }
    }
}
