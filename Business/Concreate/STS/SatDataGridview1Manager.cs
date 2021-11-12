using DataAccess.Abstract;
using DataAccess.Concreate;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class SatDataGridview1Manager //: IRepository<SatDataGridview1>
    {
        static SatDataGridview1Manager satDataGridviewManager;
        SatDataGridview1Dal satDataGridview1Dal;
        string controlText;


        private SatDataGridview1Manager()
        {
            satDataGridview1Dal = SatDataGridview1Dal.GetInstance();
        }

        public string Add(SatDataGridview1 entity)
        {
            try
            {
                controlText = IsMasYerNoComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return satDataGridview1Dal.Add(entity);
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
                controlText = TemsiliAgirlamaComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return satDataGridview1Dal.TemsiliAgirlama(entity);
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
                if (id < 1)
                {
                    return "Lütfen Geçerli Bir SAT Seçiniz.";
                }
                return satDataGridview1Dal.Delete(id);
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
                return satDataGridview1Dal.YurtIciSatSil(siparisno);
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
                return satDataGridview1Dal.Get(isakisno);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SatDataGridview1> GetList(string durum, int loginId = 0)
        {
            try
            {
                return satDataGridview1Dal.GetList(durum, loginId);
            }
            catch
            {
                return new List<SatDataGridview1>();
            }
        }
        public List<SatDataGridview1> GuncelleList(int personelid)
        {
            try
            {
                return satDataGridview1Dal.GuncelleList(personelid);
            }
            catch
            {
                return new List<SatDataGridview1>();
            }
        }


        public string Update(SatDataGridview1 entity)
        {
            try
            {
                controlText = IsOnOnayComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return satDataGridview1Dal.Update(entity);
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
                return satDataGridview1Dal.SatGuncelle(entity, siparisno);
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
                return satDataGridview1Dal.RedUpdate(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SatDurumGnlMdr(string siparisno)
        {
            try
            {
                satDataGridview1Dal.SatDurumGnlMdr(siparisno);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SatRed(string siparisno,string redNedeni)
        {
            try
            {
                satDataGridview1Dal.SatRed(siparisno, redNedeni);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SatFirmaBilgisiGuncelle(string siparisno)
        {
            try
            {
                satDataGridview1Dal.SatFirmaBilgisiGuncelle(siparisno);
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
                return satDataGridview1Dal.SatGuncelle2(entity, siparisno);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        string IsMasYerNoComplete(SatDataGridview1 satDataGridview1)
        {
            if (string.IsNullOrEmpty(satDataGridview1.Gerekce))
            {
                return "Lütfen GEREKÇE Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(satDataGridview1.Donem))
            {
                return "Lütfen DÖNEM Kısmını doldurunuz.";
            }
            return "";
        }
        string TemsiliAgirlamaComplete(SatDataGridview1 satDataGridview1)
        {
            if (string.IsNullOrEmpty(satDataGridview1.BelgeNumarasi))
            {
                return "Lütfen BELGE NUMARASI Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(satDataGridview1.BelgeTuru))
            {
                return "Lütfen BELGE TÜRÜ Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(satDataGridview1.Burcekodu))
            {
                return "Lütfen BÜTÇE KODU/KALEMİ Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(satDataGridview1.Satbirim))
            {
                return "Lütfen SATIN ALMA YAPACAK BİRİM Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(satDataGridview1.Harcamaturu))
            {
                return "Lütfen HARCAMA TÜRÜ Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(satDataGridview1.Faturafirma))
            {
                return "Lütfen FATURA EDİLECEK FİRMA Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(satDataGridview1.Donem))
            {
                return "Lütfen DÖNEM Kısmını doldurunuz.";
            }
            return "";
        }
        string IsOnOnayComplete(SatDataGridview1 satDataGridview1)
        {
            if (string.IsNullOrEmpty(satDataGridview1.Burcekodu))
            {
                return "Lütfen BÜTÇE KODU/KALEMİ Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(satDataGridview1.Satbirim))
            {
                return "Lütfen SATIN ALNA YAPACAK BİRİM Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(satDataGridview1.Harcamaturu))
            {
                return "Lütfen SAT HARCAMA TÜRÜ Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(satDataGridview1.Faturafirma))
            {
                return "Lütfen FATURA EDİLECEK FİRMA Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(satDataGridview1.Faturafirma))
            {
                return "Lütfen İLGİLİ KİŞİ Kısmını doldurunuz.";
            }
            if (string.IsNullOrEmpty(satDataGridview1.Faturafirma))
            {
                return "Lütfen MASRAF YERİ NO Kısmını doldurunuz.";
            }
            return "";
        }

        public static SatDataGridview1Manager GetInstance()
        {
            if (satDataGridviewManager == null)
            {
                satDataGridviewManager = new SatDataGridview1Manager();
            }
            return satDataGridviewManager;
        }
        public void DurumGuncelleOnay(string siparisno)
        {
            try
            {
                satDataGridview1Dal.DurumGuncelleOnay(siparisno);
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
                satDataGridview1Dal.DurumGuncelleBaslamaOnay(siparisno);
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
                satDataGridview1Dal.DurumGuncelleTamamlama(siparisno);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void OnaylananTeklif(string siparisno, int onaylananteklif)
        {
            try
            {
                satDataGridview1Dal.OnaylananTeklif(siparisno, onaylananteklif);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /*public void DurumGuncelleRed(string siparisno)
        {
            try
            {
                satDataGridview1Dal.DurumGuncelleRed(siparisno);
            }
            catch (Exception)
            {

                throw;
            }
        }*/
        public void TeklifDurum(string siparisno)
        {
            try
            {
                satDataGridview1Dal.TeklifDurum(siparisno);
            }
            catch (Exception )
            {
                throw;
            }
        }
        public List<SatDataGridview1> List()
        {
            try
            {
                return satDataGridview1Dal.List();
            }
            catch
            {
                return new List<SatDataGridview1>();
            }
        }
        public List<SatDataGridview1> TekifDurumListele(string teklifdurumu, string durum, int ucteklif,string firmabilgisi)
        {
            try
            {
                return satDataGridview1Dal.TekifDurumListele(teklifdurumu, durum, ucteklif,firmabilgisi);
            }
            catch
            {
                return new List<SatDataGridview1>();
            }
        }
        public List<SatDataGridview1> SatTamamlamaListele()
        {
            try
            {
                return satDataGridview1Dal.SatTamamlamaListele();
            }
            catch
            {
                return new List<SatDataGridview1>();
            }
        }
        public List<SatDataGridview1> SatOnayListele()
        {
            try
            {
                return satDataGridview1Dal.SatOnayListele();
            }
            catch
            {
                return new List<SatDataGridview1>();
            }
        }
        public List<SatDataGridview1> SatGuncelleFaturaList()
        {
            try
            {
                return satDataGridview1Dal.SatGuncelleFaturaList();
            }
            catch
            {
                return new List<SatDataGridview1>();
            }
        }
        public List<SatDataGridview1> SatGuncelleUcTeklifList()
        {
            try
            {
                return satDataGridview1Dal.SatGuncelleUcTeklifList();
            }
            catch
            {
                return new List<SatDataGridview1>();
            }
        }
        public List<SatDataGridview1> SatGuncelleTeklifler()
        {
            try
            {
                return satDataGridview1Dal.SatGuncelleTeklifler();
            }
            catch
            {
                return new List<SatDataGridview1>();
            }
        }
        public List<SatDataGridview1> SatGuncelleTeklifsiz()
        {
            try
            {
                return satDataGridview1Dal.SatGuncelleTeklifsiz();
            }
            catch
            {
                return new List<SatDataGridview1>();
            }
        }
    }
}
