using DataAccess.Abstract;
using DataAccess.Database;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate
{
    public class SatDataGridview1Dal
    {
        static SatDataGridview1Dal satDataGridview1Dal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private SatDataGridview1Dal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(SatDataGridview1 entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatDataGridKaydet",
                    new SqlParameter("@satno", entity.Satno),
                    new SqlParameter("@satformno",entity.Formno),
                    new SqlParameter("@masrafyeri", entity.Masrafyeri),
                    new SqlParameter("@talepeden", entity.Talepeden),
                    new SqlParameter("@bolum", entity.Bolum),
                    new SqlParameter("@usbolgesi", entity.Usbolgesi),
                    new SqlParameter("@abfformno", entity.Abfformno),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@gerekce", entity.Gerekce),
                    new SqlParameter("@siparisNo", entity.SiparisNo),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@personel_id", entity.PersonelId),
                    new SqlParameter("@talepEdenPersonel", entity.TalepEdenPersonel),
                    new SqlParameter("@personeSiparis", entity.PersonelSiparis),
                    new SqlParameter("@unvani", entity.Unvani),
                    new SqlParameter("@personelMasYerNo", entity.PersonelMasYerNo),
                    new SqlParameter("@personelMasYeri", entity.PersonelMasYeri),
                    new SqlParameter("@islemAdimi",entity.IslemAdimi),
                    new SqlParameter("@donem",entity.Donem),
                    new SqlParameter("@satOlusturmaTuru",entity.SatOlusturmaTuru),
                    new SqlParameter("@proje",entity.Proje));

                dataReader.Close();
                return "OK";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string TemsiliAgirlama(SatDataGridview1 entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTemsiliAgirlamaEkle",
                    new SqlParameter("@butceKodu", entity.Burcekodu),
                    new SqlParameter("@satBirim", entity.Satbirim),
                    new SqlParameter("@harcamaTuru", entity.Harcamaturu),
                    new SqlParameter("@faturaFirma", entity.Faturafirma),
                    new SqlParameter("@ilgiliKisi", entity.Ilgilikisi),
                    new SqlParameter("@masYeriNo", entity.Masyerino),
                    new SqlParameter("@siparisNo", entity.SiparisNo),
                    new SqlParameter("@ucTeklif", entity.Uctekilf),
                    new SqlParameter("@belgeTuru", entity.BelgeTuru),
                    new SqlParameter("@belgeNumarasi", entity.BelgeNumarasi),
                    new SqlParameter("@belgeTarihi", entity.BelgeTarihi),
                    new SqlParameter("@islemaAdimi", entity.IslemAdimi),
                    new SqlParameter("@donem",entity.Donem));

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
                dataReader = sqlServices.StoreReader("SatDataGridSil", new SqlParameter("@id", id));
                dataReader.Close();
                return "Masraf Yeri Numarası Başarıyla Silindi.";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string YurtIciSatSil(string siparisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YurtIciSatiSil", new SqlParameter("@siparisNo", siparisno));
                dataReader.Close();
                return "OK";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SatDataGridview1 Get(string isakisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YurtIciSatiSiparis", new SqlParameter("@isakisno", isakisno));
                SatDataGridview1 item = null;
                while (dataReader.Read())
                {
                    item = new SatDataGridview1(dataReader["SiparisNo"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SatDataGridview1> GetList(string durum, int loginId)
        {
            try
            {
                List<SatDataGridview1> satDatas = new List<SatDataGridview1>();
                dataReader = sqlServices.StoreReader("SatDataGridListele", new SqlParameter("@durum", durum), new SqlParameter("@loginid", loginId));
                while (dataReader.Read())
                {
                    satDatas.Add(new SatDataGridview1(
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
                        dataReader["PERSONEL_ID"].ConInt(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["PERSONEL_SIPARIS"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["PERSONEL_MAS_YER_NO"].ToString(),
                        dataReader["PERSONEL_MAS_YERI"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["SAT_OLUSTURMA_TURU"].ToString(),
                        dataReader["RED_NEDENI"].ToString(),
                        dataReader["Durum"].ToString(),
                        dataReader["TEKLIF_DURUM"].ToString(),
                        dataReader["UC_TEKLIF"].ConInt(),
                        dataReader["PROJE"].ToString()));
                }
                dataReader.Close();
                return satDatas;
            }
            catch (Exception e)
            {
                return new List<SatDataGridview1>();
            }
        }

        public List<SatDataGridview1> GuncelleList(int personelid)
        {
            try
            {
                List<SatDataGridview1> satDatas = new List<SatDataGridview1>();
                dataReader = sqlServices.StoreReader("SatGuncelleList", new SqlParameter("@personelid", personelid));
                while (dataReader.Read())
                {
                    satDatas.Add(new SatDataGridview1(
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
                        dataReader["PERSONEL_ID"].ConInt(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["PERSONEL_SIPARIS"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["PERSONEL_MAS_YER_NO"].ToString(),
                        dataReader["PERSONEL_MAS_YERI"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["SAT_OLUSTURMA_TURU"].ToString(),
                        dataReader["RED_NEDENI"].ToString(),
                        dataReader["Durum"].ToString(),
                        dataReader["TEKLIF_DURUM"].ToString(),
                        dataReader["UC_TEKLIF"].ConInt(),
                        dataReader["PROJE"].ToString()));
                }
                dataReader.Close();
                return satDatas;
            }
            catch (Exception e)
            {
                return new List<SatDataGridview1>();
            }
        }


        public string Update(SatDataGridview1 entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatDataGridGuncelle",
                    new SqlParameter("@satno", entity.Satno),
                    new SqlParameter("@butcekodukalemi", entity.Burcekodu),
                    new SqlParameter("@satbirim", entity.Satbirim),
                    new SqlParameter("@harcamaturu", entity.Harcamaturu),
                    new SqlParameter("@faturafirma", entity.Faturafirma),
                    new SqlParameter("@ilgilikisi", entity.Ilgilikisi),
                    new SqlParameter("@masrafyerino", entity.Masyerino),
                    new SqlParameter("@siparisno", entity.SiparisNo),
                    new SqlParameter("@ucteklif", entity.Uctekilf),
                    new SqlParameter("@dosyayolu", entity.DosyaYolu),
                    new SqlParameter("@islemAdimi",entity.IslemAdimi));

                dataReader.Close();
                return " SAT Ön Onay İşlemi Başarıyla Tamamlandı.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string RedUpdate(SatDataGridview1 entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatReddedilenleriGuncelle",
                    new SqlParameter("@usBolgesi", entity.Usbolgesi),
                    new SqlParameter("@abfFormNo", entity.Abfformno),
                    new SqlParameter("@istenenTarih", entity.Tarih),
                    new SqlParameter("@gerekce", entity.Gerekce),
                    new SqlParameter("@talepEdenPersonel", entity.TalepEdenPersonel),
                    new SqlParameter("@personelSiparis", entity.PersonelSiparis),
                    new SqlParameter("@unvani", entity.Unvani),
                    new SqlParameter("@personelMasYerNo", entity.PersonelMasYerNo),
                    new SqlParameter("@personelMasYeri", entity.PersonelMasYeri),
                    new SqlParameter("@siparisNo", entity.SiparisNo),
                    new SqlParameter("@butceKoduKalemi", entity.Burcekodu),
                    new SqlParameter("@satBirim",entity.Satbirim),
                    new SqlParameter("@harcamaTuru",entity.Harcamaturu),
                    new SqlParameter("@faturaFirma",entity.Faturafirma),
                    new SqlParameter("@ilgiliKisi",entity.Ilgilikisi),
                    new SqlParameter("@masrafYeriNo",entity.Masyerino),
                    new SqlParameter("@durum", entity.Durum),
                    new SqlParameter("@teklifDurum", entity.TeklifDurumu),
                    new SqlParameter("@ucTeklif",entity.Uctekilf),
                    new SqlParameter("@personelId",entity.PersonelId),
                    new SqlParameter("@donem",entity.Donem));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SatGuncelle(SatDataGridview1 entity, string siparisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatGuncelleDataGrid",
                    new SqlParameter("@usbolgesi", entity.Usbolgesi),
                    new SqlParameter("@abfformno", entity.Abfformno),
                    new SqlParameter("@gerekce", entity.Gerekce),
                    new SqlParameter("@siparisno", siparisno));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SatGuncelle2(SatDataGridview1 entity, string siparisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatGuncelleFatura",
                    new SqlParameter("@butcekodukalemi", entity.Burcekodu),
                    new SqlParameter("@satbirim", entity.Satbirim),
                    new SqlParameter("@harcamaturu", entity.Harcamaturu),
                    new SqlParameter("@faturafirma", entity.Faturafirma),
                    new SqlParameter("@ilgilikisi", entity.Ilgilikisi),
                    new SqlParameter("@masrafyerino", entity.Masyerino),
                    new SqlParameter("@siparisno", siparisno));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static SatDataGridview1Dal GetInstance()
        {
            if (satDataGridview1Dal == null)
            {
                satDataGridview1Dal = new SatDataGridview1Dal();
            }
            return satDataGridview1Dal;
        }
        public void DurumGuncelleOnay(string siparisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatDurumOnay", new SqlParameter("@siparis", siparisno));
                dataReader.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DurumGuncelleBaslamaOnay(string siparisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatDurumBaslamaOnay", new SqlParameter("@siparis", siparisno));
                dataReader.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DurumGuncelleTamamlama(string siparisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatDurumTamamlama", new SqlParameter("@siparisno", siparisno));
                dataReader.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void OnaylananTeklif(string siparisno, int onaylananTeklif)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatOnaylananTeklifGuncelle", new SqlParameter("@siparisno", siparisno), new SqlParameter("@onaylananteklif", onaylananTeklif));
                dataReader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void TeklifDurum(string siparisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTeklifDurum", new SqlParameter("@siparisno", siparisno));
                dataReader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SatRed(string siparisno,string redNedeni)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatDurumRed", 
                    new SqlParameter("@siparisno", siparisno),
                    new SqlParameter("@redNedeni", redNedeni));
                dataReader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SatDurumGnlMdr(string siparisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatDurumGnlMdr", new SqlParameter("@siparisno", siparisno));
                dataReader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SatFirmaBilgisiGuncelle(string siparisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatFirmaBilgiGuncelle", new SqlParameter("@siparisno", siparisno));
                dataReader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<SatDataGridview1> List()
        {
            try
            {
                List<SatDataGridview1> satDatas = new List<SatDataGridview1>();
                dataReader = sqlServices.StoreReader("SatDataGridDevamEden");
                while (dataReader.Read())
                {
                    satDatas.Add(new SatDataGridview1(
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
                        dataReader["BUTCE_KODU_KALEMI"].ToString(),
                        dataReader["SAT_BIRIM"].ToString(),
                        dataReader["HARCAMA_TURU"].ToString(),
                        dataReader["FATURA_EDILECEK_FIRMA"].ToString(),
                        dataReader["ILGILI_KISI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["UC_TEKLIF"].ConInt(),
                        dataReader["FIRMA_BILGISI"].ToString(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["PERSONEL_SIPARIS"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["PERSONEL_MAS_YER_NO"].ToString(),
                        dataReader["PERSONEL_MAS_YERI"].ToString(),
                        dataReader["BELGE_TURU"].ToString(),
                        dataReader["BELGE_NUMARASI"].ToString(),
                        dataReader["BELGE_TARIHI"].ConTime(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["SAT_OLUSTURMA_TURU"].ToString(),
                        dataReader["RED_NEDENI"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["TEKLIF_DURUM"].ToString(),
                        dataReader["PROJE"].ToString()));
                }
                dataReader.Close();
                return satDatas;
            }
            catch
            {
                return new List<SatDataGridview1>();
            }
        }
        public List<SatDataGridview1> TekifDurumListele(string teklifdurumu, string durum, int ucteklif, string firmabilgisi)
        {
            try
            {
                List<SatDataGridview1> satDatas = new List<SatDataGridview1>();
                dataReader = sqlServices.StoreReader("SatTeklifDurumListele", new SqlParameter("@tekilfdurum", teklifdurumu), new SqlParameter("@durum", durum), new SqlParameter("@ucteklif", ucteklif), new SqlParameter("@firmabilgisi", firmabilgisi));
                while (dataReader.Read())
                {
                    satDatas.Add(new SatDataGridview1(
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
                        dataReader["BUTCE_KODU_KALEMI"].ToString(),
                        dataReader["SAT_BIRIM"].ToString(),
                        dataReader["HARCAMA_TURU"].ToString(),
                        dataReader["FATURA_EDILECEK_FIRMA"].ToString(),
                        dataReader["ILGILI_KISI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["UC_TEKLIF"].ConInt(),
                        dataReader["FIRMA_BILGISI"].ToString(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["PERSONEL_SIPARIS"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["PERSONEL_MAS_YER_NO"].ToString(),
                        dataReader["PERSONEL_MAS_YERI"].ToString(),
                        dataReader["BELGE_TURU"].ToString(),
                        dataReader["BELGE_NUMARASI"].ToString(),
                        dataReader["BELGE_TARIHI"].ConTime(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["SAT_OLUSTURMA_TURU"].ToString(),
                        dataReader["RED_NEDENI"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["TEKLIF_DURUM"].ToString(),
                        dataReader["PROJE"].ToString()));

                }
                dataReader.Close();
                return satDatas;
            }
            catch (Exception ex)
            {
                return new List<SatDataGridview1>();
            }
        }
        public List<SatDataGridview1> SatOnayListele()
        {
            try
            {
                List<SatDataGridview1> satDatas = new List<SatDataGridview1>();
                dataReader = sqlServices.StoreReader("SatOnayListele");
                while (dataReader.Read())
                {
                    satDatas.Add(new SatDataGridview1(
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
                        dataReader["BUTCE_KODU_KALEMI"].ToString(),
                        dataReader["SAT_BIRIM"].ToString(),
                        dataReader["HARCAMA_TURU"].ToString(),
                        dataReader["FATURA_EDILECEK_FIRMA"].ToString(),
                        dataReader["ILGILI_KISI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["UC_TEKLIF"].ConInt(),
                        dataReader["FIRMA_BILGISI"].ToString(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["PERSONEL_SIPARIS"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["PERSONEL_MAS_YER_NO"].ToString(),
                        dataReader["PERSONEL_MAS_YERI"].ToString(),
                        dataReader["BELGE_TURU"].ToString(),
                        dataReader["BELGE_NUMARASI"].ToString(),
                        dataReader["BELGE_TARIHI"].ConTime(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["SAT_OLUSTURMA_TURU"].ToString(),
                        dataReader["RED_NEDENI"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["TEKLIF_DURUM"].ToString(),
                        dataReader["PROJE"].ToString()));

                }
                dataReader.Close();
                return satDatas;
            }
            catch (Exception ex)
            {
                return new List<SatDataGridview1>();
            }
        }
        public List<SatDataGridview1> SatTamamlamaListele()
        {
            try
            {
                List<SatDataGridview1> satDatas = new List<SatDataGridview1>();
                dataReader = sqlServices.StoreReader("SatTamamlamaListele");
                while (dataReader.Read())
                {
                    satDatas.Add(new SatDataGridview1(
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
                        dataReader["BUTCE_KODU_KALEMI"].ToString(),
                        dataReader["SAT_BIRIM"].ToString(),
                        dataReader["HARCAMA_TURU"].ToString(),
                        dataReader["FATURA_EDILECEK_FIRMA"].ToString(),
                        dataReader["ILGILI_KISI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["UC_TEKLIF"].ConInt(),
                        dataReader["FIRMA_BILGISI"].ToString(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["PERSONEL_SIPARIS"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["PERSONEL_MAS_YER_NO"].ToString(),
                        dataReader["PERSONEL_MAS_YERI"].ToString(),
                        dataReader["BELGE_TURU"].ToString(),
                        dataReader["BELGE_NUMARASI"].ToString(),
                        dataReader["BELGE_TARIHI"].ConTime(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["SAT_OLUSTURMA_TURU"].ToString(),
                        dataReader["RED_NEDENI"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["TEKLIF_DURUM"].ToString(),
                        dataReader["PROJE"].ToString()));

                }
                dataReader.Close();
                return satDatas;
            }
            catch (Exception ex)
            {
                return new List<SatDataGridview1>();
            }
        }
        public List<SatDataGridview1> SatGuncelleFaturaList()
        {
            try
            {
                List<SatDataGridview1> satDatas = new List<SatDataGridview1>();
                dataReader = sqlServices.StoreReader("SatGuncelleFaturaList");
                while (dataReader.Read())
                {
                    satDatas.Add(new SatDataGridview1(
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
                        dataReader["BUTCE_KODU_KALEMI"].ToString(),
                        dataReader["SAT_BIRIM"].ToString(),
                        dataReader["HARCAMA_TURU"].ToString(),
                        dataReader["FATURA_EDILECEK_FIRMA"].ToString(),
                        dataReader["ILGILI_KISI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["UC_TEKLIF"].ConInt(),
                        dataReader["FIRMA_BILGISI"].ToString(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["PERSONEL_SIPARIS"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["PERSONEL_MAS_YER_NO"].ToString(),
                        dataReader["PERSONEL_MAS_YERI"].ToString(),
                        dataReader["BELGE_TURU"].ToString(),
                        dataReader["BELGE_NUMARASI"].ToString(),
                        dataReader["BELGE_TARIHI"].ConTime(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["SAT_OLUSTURMA_TURU"].ToString(),
                        dataReader["RED_NEDENI"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["TEKLIF_DURUM"].ToString(),
                        dataReader["PROJE"].ToString()));

                }
                dataReader.Close();
                return satDatas;
            }
            catch (Exception ex)
            {
                return new List<SatDataGridview1>();
            }
        }
        public List<SatDataGridview1> SatGuncelleUcTeklifList()
        {
            try
            {
                List<SatDataGridview1> satDatas = new List<SatDataGridview1>();
                dataReader = sqlServices.StoreReader("SatGuncelleUcteklifList");
                while (dataReader.Read())
                {
                    satDatas.Add(new SatDataGridview1(
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
                        dataReader["BUTCE_KODU_KALEMI"].ToString(),
                        dataReader["SAT_BIRIM"].ToString(),
                        dataReader["HARCAMA_TURU"].ToString(),
                        dataReader["FATURA_EDILECEK_FIRMA"].ToString(),
                        dataReader["ILGILI_KISI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["UC_TEKLIF"].ConInt(),
                        dataReader["FIRMA_BILGISI"].ToString(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["PERSONEL_SIPARIS"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["PERSONEL_MAS_YER_NO"].ToString(),
                        dataReader["PERSONEL_MAS_YERI"].ToString(),
                        dataReader["BELGE_TURU"].ToString(),
                        dataReader["BELGE_NUMARASI"].ToString(),
                        dataReader["BELGE_TARIHI"].ConTime(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["SAT_OLUSTURMA_TURU"].ToString(),
                        dataReader["RED_NEDENI"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["TEKLIF_DURUM"].ToString(),
                        dataReader["PROJE"].ToString()));

                }
                dataReader.Close();
                return satDatas;
            }
            catch (Exception ex)
            {
                return new List<SatDataGridview1>();
            }
        }
        public List<SatDataGridview1> SatGuncelleTeklifler()
        {
            try
            {
                List<SatDataGridview1> satDatas = new List<SatDataGridview1>();
                dataReader = sqlServices.StoreReader("SatGuncelleTekliflerList");
                while (dataReader.Read())
                {
                    satDatas.Add(new SatDataGridview1(
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
                        dataReader["BUTCE_KODU_KALEMI"].ToString(),
                        dataReader["SAT_BIRIM"].ToString(),
                        dataReader["HARCAMA_TURU"].ToString(),
                        dataReader["FATURA_EDILECEK_FIRMA"].ToString(),
                        dataReader["ILGILI_KISI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["UC_TEKLIF"].ConInt(),
                        dataReader["FIRMA_BILGISI"].ToString(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["PERSONEL_SIPARIS"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["PERSONEL_MAS_YER_NO"].ToString(),
                        dataReader["PERSONEL_MAS_YERI"].ToString(),
                        dataReader["BELGE_TURU"].ToString(),
                        dataReader["BELGE_NUMARASI"].ToString(),
                        dataReader["BELGE_TARIHI"].ConTime(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["SAT_OLUSTURMA_TURU"].ToString(),
                        dataReader["RED_NEDENI"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["TEKLIF_DURUM"].ToString(),
                        dataReader["PROJE"].ToString()));

                }
                dataReader.Close();
                return satDatas;
            }
            catch (Exception ex)
            {
                return new List<SatDataGridview1>();
            }
        }
        public List<SatDataGridview1> SatGuncelleTeklifsiz()
        {
            try
            {
                List<SatDataGridview1> satDatas = new List<SatDataGridview1>();
                dataReader = sqlServices.StoreReader("SatGuncelleTekliflerList2");
                while (dataReader.Read())
                {
                    satDatas.Add(new SatDataGridview1(
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
                        dataReader["BUTCE_KODU_KALEMI"].ToString(),
                        dataReader["SAT_BIRIM"].ToString(),
                        dataReader["HARCAMA_TURU"].ToString(),
                        dataReader["FATURA_EDILECEK_FIRMA"].ToString(),
                        dataReader["ILGILI_KISI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["UC_TEKLIF"].ConInt(),
                        dataReader["FIRMA_BILGISI"].ToString(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["PERSONEL_SIPARIS"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["PERSONEL_MAS_YER_NO"].ToString(),
                        dataReader["PERSONEL_MAS_YERI"].ToString(),
                        dataReader["BELGE_TURU"].ToString(),
                        dataReader["BELGE_NUMARASI"].ToString(),
                        dataReader["BELGE_TARIHI"].ConTime(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["SAT_OLUSTURMA_TURU"].ToString(),
                        dataReader["RED_NEDENI"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["TEKLIF_DURUM"].ToString(),
                        dataReader["PROJE"].ToString()));

                }
                dataReader.Close();
                return satDatas;
            }
            catch (Exception ex)
            {
                return new List<SatDataGridview1>();
            }
        }
        
    }
}
