using Business;
using Business.Concreate;
using Business.Concreate.AnaSayfa;
using Business.Concreate.BakimOnarim;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using DataAccess.Concreate.STS;
using Entity;
using Entity.AnaSayfa;
using Entity.BakimOnarim;
using Entity.IdariIsler;
using Entity.STS;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;
using UserInterface.STS;
using Application = Microsoft.Office.Interop.Word.Application;

namespace UserInterface.IdariIsler
{
    public partial class FrmYurtİciGorev : Form
    {
        YurtIciGorevManager yurtIciGorevManager;
        SiparislerManager siparislerManager;
        ButceKoduManager butceKoduManager;
        UstAmirManager ustAmirManager;
        SiparisPersonelManager siparisPersonelManager;
        IdariIslerLogManager logManager;
        SatDataGridview1Manager satDataGridview1Manager;
        StokManager stokManager;
        SatinAlinacakMalManager satinAlinacakMalManager;
        TeklifsizSatManager teklifsizSatManager;
        SatIslemAdimlariManager satIslemAdimlariManager;
        List<UstAmirMail> ustAmirMails;
        IsAkisNoManager isAkisNoManager;
        PersonelKayitManager kayitManager;
        ComboManager comboManager;
        TedarikciFirmaManager tedarikciFirmaManager;
        BolgeKayitManager bolgeKayitManager;
        AracZimmetiManager aracZimmetiManager;
        GorevlendirmeManager gorevlendirmeManager;
        BildirimYetkiManager bildirimYetkiManager;

        string satno, siparis, usamirbolum, usamirisim, islemadimi, dosya, dosyaGun, siparisNo, masrafyerino, talepeden, bolum, projekodu, gerekce, harcamaturu, faturafirma, ilgilikisi, masrafyeri, donem, yeniad;
        int sayi, id, yurticiid, satNo;
        bool start = false, start2 = true, start3 = false, start4 = true;
        double toplam, miktar;
        public object[] infos;
        string taslakYolu = "";
        string kaynak = @"Z:\DTS\İDARİ İŞLER\WordTaslak\";
        string yol = @"C:\DTS\Taslak\";
        public FrmYurtİciGorev()
        {
            InitializeComponent();
            yurtIciGorevManager = YurtIciGorevManager.GetInstance();
            siparislerManager = SiparislerManager.GetInstance();
            butceKoduManager = ButceKoduManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            ustAmirManager = UstAmirManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            stokManager = StokManager.GetInstance();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            teklifsizSatManager = TeklifsizSatManager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            tedarikciFirmaManager = TedarikciFirmaManager.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            aracZimmetiManager = AracZimmetiManager.GetInstance();
            gorevlendirmeManager = GorevlendirmeManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageYurtIcıGorev"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }




            /*FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageYurtIcıGorev"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }*/
        }

        private void FrmYurtİciGorev_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            IsAkisNoGorevlendirme();
            Personeller1();
            Personeller2();
            ComboProje();
            ComboProje2();
            PersonellerGorevlendirme();
            CmbIlYükle();
            Plaka();
            //Siparisler();
            //Siparis();
            SatDoldur();

            //ButceKoduKalemi();
            //ButceKoduKalemi2();
            /*start = false;
            start2 = false;
            start3 = false;
            start4 = false;*/
            CmbIslemTuru.SelectedIndex = 0;
            start = true;
            start3 = true;
        }
        /*void IsAkisNo()
        {
            satno = "";
            Random random = new Random();
            for (int i = 0; i < 9; i++)
            {
                sayi = random.Next(0, 9);
                satno = satno + sayi.ToString();
            }
            LblIsAkisNo.Text = satno;
        }*/
        public void YenilecekVeri()
        {
            IsAkisNo();
            //Personeller1();
            //Personeller2();
            ComboProje();
            ComboProje2();
            //Siparisler();
            //Siparis();
            SatDoldur();
        }
        void CmbIlYükle()
        {
            CmbIl.DataSource = tedarikciFirmaManager.Iller();
            CmbIl.SelectedIndex = -1;
            CmbIlce.Text = "";
        }
        void Personeller1()
        {
            CmbAdSoyad.DataSource = kayitManager.PersonelAdSoyad();
            CmbAdSoyad.ValueMember = "Id";
            CmbAdSoyad.DisplayMember = "Adsoyad";
            CmbAdSoyad.SelectedValue = -1;
        }
        void PersonellerGorevlendirme()
        {
            CmbPersonelAdi.DataSource = kayitManager.PersonelAdSoyad();
            CmbPersonelAdi.ValueMember = "Id";
            CmbPersonelAdi.DisplayMember = "Adsoyad";
            CmbPersonelAdi.SelectedValue = -1;
        }
        void Personeller2()
        {
            CmbAdSoyadGun.DataSource = kayitManager.PersonelAdSoyad();
            CmbAdSoyadGun.ValueMember = "Id";
            CmbAdSoyadGun.DisplayMember = "Adsoyad";
            CmbAdSoyadGun.SelectedValue = -1;
        }
        void ComboProje()
        {
            CmbProje.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProje.ValueMember = "Id";
            CmbProje.DisplayMember = "Baslik";
            CmbProje.SelectedValue = 0;
        }
        void ComboProje2()
        {
            CmbProjeGun.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProjeGun.ValueMember = "Id";
            CmbProjeGun.DisplayMember = "Baslik";
            CmbProjeGun.SelectedValue = 0;
        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        void IsAkisNoGorevlendirme()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkis.Text = isAkis.Id.ToString();
        }
        /*void Siparisler()
        {
            CmbSiparisNo.DataSource = siparislerManager.GetList();
            CmbSiparisNo.ValueMember = "Id";
            CmbSiparisNo.DisplayMember = "Siparisno";
            CmbSiparisNo.SelectedValue = 0;
        }*/
        /*void Siparis()
        {
            CmbSiparsGun.DataSource = siparislerManager.GetList();
            CmbSiparsGun.ValueMember = "Id";
            CmbSiparsGun.DisplayMember = "Siparisno";
            CmbSiparsGun.SelectedValue = 0;
        }*/
        /*void ButceKoduKalemi()
        {
            CmbButceKodu.DataSource = butceKoduManager.GetList();
            CmbButceKodu.ValueMember = "Id";
            CmbButceKodu.DisplayMember = "Butcekodu";
            CmbButceKodu.SelectedValue = 0;
        }*/

        private void CmbSiparisNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (start)
            {
                if (start2 == true)
                {
                    return;
                }
            }
            siparis = CmbSiparisNo.Text;
            SiparisIsimlerDoldur();
            TxtMasrafyeriNo.Clear();
            TxtMasrafYeri.Clear();
            TxtGorevi.Clear();
            start = true;*/
        }

        private void CmbAdSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbAdSoyad.Text);
            TxtMasrafyeriNo.Text = siparis.Masrafyerino;
            TxtMasrafYeri.Text = siparis.Masrafyeri;
            TxtGorevi.Text = siparis.Gorevi;
            CmbSiparisNo.Text = siparis.Siparis;
            id = siparis.Id;
            ustAmirMails = ustAmirManager.GetList(id);
            if (ustAmirMails.Count > 0)
            {
                usamirbolum = ustAmirMails[0].Bolum;
                usamirisim = ustAmirMails[0].Adsoyad;
            }
            start2 = false;
        }

        /*private void CmbSiparsGun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start3)
            {
                if (start4 == true)
                {
                    return;
                }
            }
            siparis = CmbSiparsGun.Text;
            SiparisIsimlerDoldurGuncelle();
            TxtMasrafyeriNoGun.Clear();
            TxtMasrafYeriGun.Clear();
            start3 = true;
        }*/
        void SiparisIsimlerDoldurGuncelle()
        {
            CmbAdSoyadGun.DataSource = siparisPersonelManager.GetList(siparis);
            CmbAdSoyadGun.ValueMember = "Id";
            CmbAdSoyadGun.DisplayMember = "Personel";
            CmbAdSoyadGun.SelectedValue = 0;
        }
        int guncelid;
        string proje = "";
        private void CmbAdSoyadGun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start3 == false)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbAdSoyadGun.Text);
            CmbSiparsGun.Text = siparis.Siparis;
            TxtGoreviGun.Text = siparis.Gorevi;
            guncelid = siparis.Id;
            TxtMasrafyeriNoGun.Text = siparis.Masrafyerino;
            TxtMasrafYeriGun.Text = siparis.Masrafyeri;
            proje = siparis.Projekodu;
            start4 = false;
        }

        private void BtnSureHesapla_Click(object sender, EventArgs e)
        {
            DateTime bTarih = DtBaslamaTarihi.Value;
            DateTime kTarih = DtBitisTarihi.Value;
            TimeSpan Sonuc = kTarih - bTarih;
            int gun = Sonuc.TotalDays.ConInt() + 1;
            TxtToplamSure.Text = gun.ToString() + " Gün";
        }

        private void BtnSureHesaplaGun_Click(object sender, EventArgs e)
        {
            DateTime bTarih = DtBaslamaTarihiGun.Value;
            DateTime kTarih = DtBitisTarihiGun.Value;
            TimeSpan Sonuc = kTarih - bTarih;
            int gun = Sonuc.TotalDays.ConInt() + 1;
            TxtToplamSureGun.Text = gun.ToString() + " Gün";
        }
        double cikiskm = 0, donuskm = 0, toplamkm = 0;
        private void KmHesaplaGun_Click(object sender, EventArgs e)
        {
            if (TxtCikisKmGun.Text == "")
            {
                donuskm = TxtDonusKmGun.Text.ConDouble();
                toplamkm = donuskm - cikiskm;
                TxtToplamKmGun.Text = toplamkm.ToString() + " KM";
                return;
            }
            if (TxtDonusKmGun.Text == "")
            {
                cikiskm = TxtCikisKmGun.Text.ConDouble();
                toplamkm = donuskm - cikiskm;
                TxtToplamKmGun.Text = toplamkm.ToString() + " KM";
                return;
            }
            if (TxtDonusKmGun.Text == "" || TxtCikisKmGun.Text == "")
            {
                cikiskm = TxtCikisKmGun.Text.ConDouble();
                donuskm = TxtDonusKmGun.Text.ConDouble();
                toplamkm = donuskm - cikiskm;
                TxtToplamKmGun.Text = toplamkm.ToString() + " KM";
                return;
            }
            cikiskm = TxtCikisKmGun.Text.ConDouble();
            donuskm = TxtDonusKmGun.Text.ConDouble();
            toplamkm = donuskm - cikiskm;
            TxtToplamKmGun.Text = toplamkm.ToString() + " KM";

            TxtGenelToplamGun.Text = GenelToplamGun();
        }
        void CreateWord()
        {
            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            object filePath = taslakYolu;
            //object filePath = "Z:\\DTS\\İDARİ İŞLER\\WordTaslak\\DTS_Yurt İçi Görev Formu.docx";// taslak yolu

            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["IsAkisNo"].Range.Text = LblIsAkisNo.Text;
            wBookmarks["GorevEmriNo"].Range.Text = TxtGorevEmriNo.Text;
            wBookmarks["GorevinKonusu"].Range.Text = TxtGorevinKonusu.Text;
            wBookmarks["GidilecekYer"].Range.Text = TxtGidilecekYer.Text;
            wBookmarks["BaslamaTarihi"].Range.Text = DtBaslamaTarihi.Value.ToString("dd/MM/yyyy");
            wBookmarks["BitisTarihi"].Range.Text = DtBitisTarihi.Value.ToString("dd/MM/yyyy");
            wBookmarks["GorevinSuresi"].Range.Text = TxtToplamSure.Text;
            wBookmarks["ButceKodu"].Range.Text = CmbButceKodu.Text;
            wBookmarks["SiparisNo"].Range.Text = CmbSiparisNo.Text;
            wBookmarks["AdSoyad"].Range.Text = CmbAdSoyad.Text;
            wBookmarks["MasrafYeriNo"].Range.Text = TxtMasrafyeriNo.Text;
            wBookmarks["MasrafYeri"].Range.Text = TxtMasrafYeri.Text;
            wBookmarks["UlasimGidis"].Range.Text = CmbUlasimGidis.Text;
            wBookmarks["UlasimDonus"].Range.Text = CmbUlasimDonus.Text;
            wBookmarks["UlasimGorevYeri"].Range.Text = CmbUlasimGorevYeri.Text;
            wBookmarks["KonaklamaGun"].Range.Text = TxtKonaklamaGun.Text;
            wBookmarks["KonaklamaGunTl"].Range.Text = TxtKonaklamGunTl.Text;
            wBookmarks["KonaklamaTT"].Range.Text = TxtKonaklamaToplam.Text;
            wBookmarks["KiralamaGun"].Range.Text = TxtKiralamaGun.Text;
            wBookmarks["KiralamaGunTl"].Range.Text = TxtKiralamaGunTl.Text;
            wBookmarks["KiralamaToplam"].Range.Text = TxtKiralamaToplam.Text;
            wBookmarks["AvansGun"].Range.Text = TxtSeyahatAvansGun.Text;
            wBookmarks["AvansGunTl"].Range.Text = TxtSeyahatAvansGunTl.Text;
            wBookmarks["AvansToplam"].Range.Text = TxtSeyahatAvansToplam.Text;
            wBookmarks["GorevHarcirahiGun"].Range.Text = TxtHarcirahGun.Text;
            wBookmarks["TxtHarcirahGunTl"].Range.Text = TxtHarcirahGunTl.Text;
            wBookmarks["TxtHarcirahToplam"].Range.Text = TxtGorevHarcirahGunTop.Text;
            wBookmarks["IaseGun"].Range.Text = TxtIaseGun.Text;
            wBookmarks["IaseGunTl"].Range.Text = TxtIaseGunTl.Text;
            wBookmarks["IaseToplam"].Range.Text = TxtIaseToplam.Text;
            wBookmarks["Ucak"].Range.Text = TxtUcak.Text;
            wBookmarks["Otobus"].Range.Text = TxtOtobus.Text;
            wBookmarks["GenelToplam"].Range.Text = TxtGenelToplam.Text;
            wBookmarks["GunlukToplam"].Range.Text = TxtGunlukToplam.Text;
            wBookmarks["Plaka"].Range.Text = TxtPlaka.Text;
            wBookmarks["CikisKm"].Range.Text = TxtCikisKm.Text;
            wBookmarks["DonusKm"].Range.Text = "0";
            wBookmarks["ToplamKm"].Range.Text = "0";
            wBookmarks["AdSoyad2"].Range.Text = CmbAdSoyad.Text;
            wBookmarks["Tarih"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
            wBookmarks["Tarih2"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
            wBookmarks["Tarih3"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
            if (usamirisim == "RESUL GÜNEŞ")
            {
                wBookmarks["UstAmir"].Range.Text = "";

                wDoc.SaveAs2(dosya + LblIsAkisNo.Text + ".docx");
                wDoc.Close();
                wApp.Quit(false);
                return;
            }
            wBookmarks["UstAmir"].Range.Text = usamirisim;
            //wDoc.SaveAs2(yol + "\\" + TxtIsAkisNoTamamla.Text + ".docx"); // farklı kaydet

            wDoc.SaveAs2(dosya + LblIsAkisNo.Text + ".docx");
            wDoc.Close();
            wApp.Quit(false);
        }
        void CreateWord2()
        {

            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            //object filePath = "C:\\Users\\MAYıldırım\\Desktop\\Formlar\\DTS_Yurt İçi Görev Formuu.docx"; // taslak yolu
            object filePath = taslakYolu;
            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["IsAkisNo"].Range.Text = TxtIsAkisNoTamamla.Text;
            wBookmarks["GorevEmriNo"].Range.Text = TxtGorevEmriNoGun.Text;
            wBookmarks["GorevinKonusu"].Range.Text = TxtGorevinKonusuGun.Text;
            wBookmarks["GidilecekYer"].Range.Text = TxtGidilecekYerGun.Text;
            wBookmarks["BaslamaTarihi"].Range.Text = DtBaslamaTarihiGun.Value.ToString("dd/MM/yyyy");
            wBookmarks["BitisTarihi"].Range.Text = DtBitisTarihiGun.Value.ToString("dd/MM/yyyy");
            wBookmarks["GorevinSuresi"].Range.Text = TxtToplamSureGun.Text;
            wBookmarks["ButceKodu"].Range.Text = CmbButceKoduGun.Text;
            wBookmarks["SiparisNo"].Range.Text = CmbSiparsGun.Text;
            wBookmarks["AdSoyad"].Range.Text = CmbAdSoyadGun.Text;
            wBookmarks["MasrafYeriNo"].Range.Text = TxtMasrafyeriNoGun.Text;
            wBookmarks["MasrafYeri"].Range.Text = TxtMasrafYeriGun.Text;
            wBookmarks["UlasimGidis"].Range.Text = CmbUlasimGidisGun.Text;
            wBookmarks["UlasimDonus"].Range.Text = CmbUlasimDonusGun.Text;
            wBookmarks["UlasimGorevYeri"].Range.Text = CmbUlasimGorevYeriGun.Text;
            wBookmarks["KonaklamaGun"].Range.Text = TxtKonaklamaGunGun.Text;
            wBookmarks["KonaklamaGunTl"].Range.Text = TxtKonaklamGunTlGun.Text;
            wBookmarks["KonaklamaTT"].Range.Text = TxtKonaklamaToplamGun.Text;
            wBookmarks["KiralamaGun"].Range.Text = TxtKiralamaGunGun.Text;
            wBookmarks["KiralamaGunTl"].Range.Text = TxtKiralamaGunTlGun.Text;
            //wBookmarks["KiralamaYakit"].Range.Text = TxtKiralamaYakitGun.Text;
            wBookmarks["KiralamaToplam"].Range.Text = TxtKiralamaToplamGun.Text;
            wBookmarks["AvansGun"].Range.Text = TxtSeyahatAvansGunGun.Text;
            wBookmarks["AvansGunTl"].Range.Text = TxtSeyahatAvansGunTlGun.Text;
            wBookmarks["AvansToplam"].Range.Text = textBTxtSeyahatAavansToplamGun.Text;
            wBookmarks["GorevHarcirahiGun"].Range.Text = TxtHarcirahGunGun.Text;
            wBookmarks["TxtHarcirahGunTl"].Range.Text = TxtHarcirahGunTlGun.Text;
            wBookmarks["TxtHarcirahToplam"].Range.Text = TxtGorevHarcirahGunTopGun.Text;
            wBookmarks["IaseGun"].Range.Text = TxtIaseGunGun.Text;
            wBookmarks["IaseGunTl"].Range.Text = TxtIaseGunTlGun.Text;
            wBookmarks["IaseToplam"].Range.Text = TxtIaseToplamGun.Text;
            wBookmarks["Ucak"].Range.Text = TxtUcakGun.Text;
            wBookmarks["Otobus"].Range.Text = TxtOtobusGun.Text;
            wBookmarks["GenelToplam"].Range.Text = TxtGenelToplamGun.Text;
            wBookmarks["GunlukToplam"].Range.Text = TxtGunlukToplamGun.Text;
            wBookmarks["Plaka"].Range.Text = TxtAracPlakasiGun.Text;
            wBookmarks["CikisKm"].Range.Text = TxtCikisKmGun.Text;
            wBookmarks["DonusKm"].Range.Text = TxtDonusKmGun.Text;
            wBookmarks["ToplamKm"].Range.Text = TxtToplamKmGun.Text;
            wBookmarks["AdSoyad2"].Range.Text = CmbAdSoyadGun.Text;
            wBookmarks["Tarih"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
            wBookmarks["Tarih2"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
            wBookmarks["Tarih3"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
            yeniad = TxtIsAkisNoTamamla.Text + "_" + TxtGorevEmriNoGun.Text;
            string tamyol = dosyaGun + yeniad + ".docx";
            if (usamirisim == "RESUL GÜNEŞ")
            {
                wBookmarks["UstAmir"].Range.Text = "";

                wDoc.SaveAs2(tamyol);
                wDoc.Close();
                wApp.Quit(false);
                Properties.Settings.Default.YurtIciYeniAd = yeniad;
                Properties.Settings.Default.YurtIciDosyaYolu = tamyol;
                return;
            }
            wBookmarks["UstAmir"].Range.Text = usamirisim;
            //wDoc.SaveAs2(yol + "\\" + TxtIsAkisNoTamamla.Text + ".docx"); // farklı kaydet
            wDoc.SaveAs2(tamyol);
            wDoc.Close();
            wApp.Quit(false);

            Properties.Settings.Default.YurtIciYeniAd = yeniad;
            Properties.Settings.Default.YurtIciDosyaYolu = tamyol;
        }
        void CreateDirectory()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\YURT İÇİ GÖREV\";

            /*string root = @"D:\DTS";
            string subdir = @"D:\DTS\İDARİ İŞLER\";
            string anadosya = @"D:\DTS\İDARİ İŞLER\YURT İÇİ GÖREV\";*/
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(anadosya))
            {
                Directory.CreateDirectory(anadosya);
            }
            dosya = anadosya + LblIsAkisNo.Text + "\\";
            Directory.CreateDirectory(dosya);
        }
        public string konaklamaTuru = "TEKLİ KONAKLAMA";
        private void BtnCokluKonaklama_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNoTamamla.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İş Akış No Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmCokluKonaklama frmCoklu = new FrmCokluKonaklama();
            frmCoklu.isAkisNo = TxtIsAkisNoTamamla.Text.ConInt();
            frmCoklu.ShowDialog();
        }
        void TaslakKopyala()
        {
            string root = @"C:\DTS";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(yol))
            {
                Directory.CreateDirectory(yol);
            }

            File.Copy(kaynak + "MP-FR-155 DTS_YURT İÇİ GÖREV FORMU REV (01)2.docx", yol + "MP-FR-155 DTS_YURT İÇİ GÖREV FORMU REV (01)2.docx");
            taslakYolu = yol + "MP-FR-155 DTS_YURT İÇİ GÖREV FORMU REV (01)2.docx";
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            #region EXCEL
            /*IXLWorkbook workbook = new XLWorkbook(@"C:\Users\MAYıldırım\Desktop\YURT İÇİ GÖREV KAYIT DOSYASI 2021.xlsx");
            IXLWorksheets sheets = workbook.Worksheets;
            IXLWorksheet worksheet = workbook.Worksheet("Sayfa1");
            var rows = worksheet.Rows(155, 160);
            DateTime outDate = DateTime.Now;
            //double outDouble = 0;
            foreach (IXLRow item in rows)
            {
                YurtIciGorev gorevs = new YurtIciGorev(
                    0,
                    item.Cell("B").Value.ToString(), // GÖREV EMRİ NO
                    item.Cell("C").Value.ToString(), // GÖREVİN KONUSU
                    item.Cell("D").Value.ToString(), // PROJE
                    item.Cell("E").Value.ToString(), // GİDİLECEK YER
                    item.Cell("G").Value.ConTime(), // BAŞLAMA TARİHİ
                    item.Cell("H").Value.ConTime(), // BİTİŞ TARİHİ
                    item.Cell("I").Value.ToString(), // TOPLAM SÜRE
                    item.Cell("F").Value.ToString(), // BÜTÇE KODU KALEMİ
                    "",                              // SİPARİŞ NO
                    item.Cell("L").Value.ToString(), // AD SOYAD
                    "",                              // ÜNVANI
                    item.Cell("J").Value.ToString(), // MASRAF YERİ NO
                    "",                              // MASRAF YERİ
                    item.Cell("V").Value.ToString(), // ULAŞIM GİDİŞ
                    item.Cell("W").Value.ToString(), // ULAŞIM GÖREV YERİ
                    item.Cell("X").Value.ToString(), // ULAŞIM DÖNÜŞ
                    item.Cell("AC").Value.ConInt(), // KONAKLAMA GÜN
                    item.Cell("AD").Value.ConDouble(), // KONAKLAMA GÜN TL
                    item.Cell("AE").Value.ConDouble(), // KONAKLAMA TOPLAM
                    item.Cell("P").Value.ConInt(), // KİRALAMA GÜN
                    item.Cell("Q").Value.ConDouble(), // KİRALAMA GÜN TL
                    item.Cell("S").Value.ConDouble(), // KİRALAMA YAKIT
                    item.Cell("P").Value.ConDouble(), // KİRALAMA TOPLAM
                    item.Cell("N").Value.ConInt(),     // SEYAHAT AVANS GÜN
                    item.Cell("O").Value.ConDouble(), // SEYAHAT AVANS GÜN TL
                    0,
                    item.Cell("U").Value.ConDouble(), // UÇAK BİLETİ
                    item.Cell("T").Value.ConDouble(), // OTOBÜS BİLETİ
                    item.Cell("Y").Value.ToString(), // PLAKA
                    item.Cell("Z").Value.ConDouble(), // ÇIKIŞ KM
                    item.Cell("AA").Value.ConDouble(),// DÖNÜŞ KM
                    item.Cell("AB").Value.ConDouble(),// TOPLAM KM
                    0, // ORTALAMA YAKIT
                    item.Cell("AF").Value.ConDouble(), // 
                    "2.ADIM:GÖREV TAMAMLANMIŞTIR",
                    "");
                yurtIciGorevManager.Add(gorevs);
            }*/
            #endregion

            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IsAkisNo();
                TaslakKopyala();
                int konaklamagun = 0, seyahatavansgun = 0, kiralamaGun = 0, harcirahGun = 0, iaseGun = 0;
                if (TxtKonaklamaGun.Text != "")
                {
                    konaklamagun = TxtKonaklamaGun.Text.ConInt();
                }
                if (TxtKiralamaGun.Text != "")
                {
                    kiralamaGun = TxtKiralamaGun.Text.ConInt();
                }
                if (TxtSeyahatAvansGun.Text != "")
                {
                    seyahatavansgun = TxtSeyahatAvansGun.Text.ConInt();
                }
                if (TxtHarcirahGun.Text != "")
                {
                    harcirahGun = TxtHarcirahGun.Text.ConInt();
                }
                if (TxtIaseGun.Text != "")
                {
                    iaseGun = TxtIaseGun.Text.ConInt();
                }
                CreateDirectory();
                islemadimi = "1.ADIM:GÖREV OLUŞTURULDU";
                YurtIciGorev yurtIciGorev = new YurtIciGorev(LblIsAkisNo.Text.ConInt(), TxtGorevEmriNo.Text, TxtGorevinKonusu.Text, CmbProje.Text, TxtGidilecekYer.Text, DtBaslamaTarihi.Value, DtBitisTarihi.Value, TxtToplamSure.Text, CmbButceKodu.Text, CmbSiparisNo.Text, CmbAdSoyad.Text, TxtGorevi.Text, TxtMasrafyeriNo.Text, TxtMasrafYeri.Text, CmbUlasimGidis.Text, CmbUlasimGorevYeri.Text, CmbUlasimDonus.Text, konaklamagun, TxtKonaklamGunTl.Text.ConDouble(), TxtKonaklamaToplam.Text.ConDouble(), kiralamaGun, TxtKiralamaGunTl.Text.ConDouble(), TxtKiralamaToplam.Text.ConDouble(), seyahatavansgun, TxtSeyahatAvansGunTl.Text.ConDouble(), TxtSeyahatAvansToplam.Text.ConDouble(), harcirahGun, TxtHarcirahGunTl.Text.ConDouble(), TxtGorevHarcirahGunTop.Text.ConDouble(), iaseGun, TxtIaseGunTl.Text.ConDouble(), TxtIaseToplam.Text.ConDouble(), TxtUcak.Text.ConDouble(), TxtOtobus.Text.ConDouble(), TxtGenelToplam.Text.ConDouble(), TxtPlaka.Text, TxtCikisKm.Text.ConDouble(), islemadimi, dosya, konaklamaTuru);
                string mesaj = yurtIciGorevManager.Add(yurtIciGorev);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLog();
                CreateWord();
                //Task.Factory.StartNew(() => MailSendMetot());
                System.Threading.Tasks.Task.Factory.StartNew(() => MailSendMetot());
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    Directory.Delete(yol, true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    File.Delete(taslakYolu);
                }
                Temizle();
            }
        }

        void SatOlustur()
        {
            DialogResult dr = MessageBox.Show("Otomatik Olarak Sat Oluşuturalacaktır, Onaylıyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                siparisNo = Guid.NewGuid().ToString();
                HarcamaControl();
                SatDataGridview1 satDataGridview1 = new SatDataGridview1(0, TxtIsAkisNoTamamla.Text.ConInt(), masrafyerino, talepeden, bolum, "YOK", "YOK", DateTime.Now, gerekce, siparisNo, CmbAdSoyadGun.Text, CmbSiparsGun.Text, TxtGoreviGun.Text, TxtMasrafyeriNoGun.Text, TxtMasrafYeriGun.Text,
                  string.IsNullOrEmpty(dosyaGun) ? "" : dosyaGun, infos[0].ConInt(), "SAT ONAY", donem, "BAŞARAN", proje, TxtFirmalar.Text, "", "");
                string mesaj = satDataGridview1Manager.Add(satDataGridview1);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SatDataGridview1 dataGridview1 = new SatDataGridview1(satNo, CmbButceKoduGun.Text, "BSRN GN.MDL.SATIN ALMA", harcamaturu, faturafirma, ilgilikisi, masrafyeri, siparisNo, 0, dosyaGun, "SAT ONAY");
                mesaj = satDataGridview1Manager.Update(dataGridview1);
                if (mesaj != " SAT Ön Onay İşlemi Başarıyla Tamamlandı.")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                satDataGridview1Manager.TeklifDurum(siparisNo, dosyaGun, "SAT ONAY BAŞARAN");
                satDataGridview1Manager.DurumGuncelleOnay(siparisNo);
                string yapilanislem = TxtIsAkisNoTamamla.Text + " Nolu Yurt İçi Görev İçin SAT Oluşturuldu.";
                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
                satIslemAdimlariManager.Add(satIslemAdimlari);
            }
        }
        void HarcamaControl()
        {
            MessageBox.Show("Lütfen Öncelikle Satın Alma Talebinin Oluşturulabilmesi İçin Eksik Olan Bilgileri Tamamlayınız!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Properties.Settings.Default.SiparisNo = siparisNo;
            Properties.Settings.Default.YurtIciDosyaYolu = dosyaGun;
            Properties.Settings.Default.YurtIciYeniAd = yeniad;
            Properties.Settings.Default.YurtIciIsAkisNo = TxtIsAkisNoTamamla.Text.ConInt();
            Properties.Settings.Default.Save();
            FrmYurtIciGorevSAT frmYurtIciGorevSAT = new FrmYurtIciGorevSAT();
            frmYurtIciGorevSAT.ShowDialog();
            gerekce = Properties.Settings.Default.Gerekce.ToString();
            harcamaturu = Properties.Settings.Default.HarcamaTuru.ToString();
            faturafirma = Properties.Settings.Default.FaturaFirma.ToString();
            ilgilikisi = Properties.Settings.Default.IlgiliKisi.ToString();
            masrafyeri = Properties.Settings.Default.MasrafYeri.ToString();
            satNo = Properties.Settings.Default.YurtIciGorevSatNo.ConInt();
            donem = Properties.Settings.Default.YurtIciGorevDonem.ToString();
            dosyaGun = Properties.Settings.Default.DosyaYolu.ToString();
            string stokno, tanim, birim;
            List<TeklifsizSat> list = new List<TeklifsizSat>();
            if (TxtKonaklamaToplamGun.Text != "0")
            {
                Stok stok = stokManager.Get("KONAKLAMA");
                stokno = stok.Stokno;
                tanim = stok.Tanim;
                birim = stok.Birim;
                miktar = TxtKonaklamaGunGun.Text.ConDouble();
                toplam = TxtKonaklamaToplamGun.Text.ConDouble();
                TeklifsizSat satinAlinacakMalzeme = new TeklifsizSat(stokno, tanim, miktar, birim, toplam, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }
            if (TxtKiralamaGunTlGun.Text != "0")
            {
                double kiralamatoplam = TxtKiralamaToplamGun.Text.ConDouble() - TxtKiralamaYakitGun.Text.ConDouble();
                Stok stok = stokManager.Get("ARAÇ KİRALAMA");
                stokno = stok.Stokno;
                tanim = stok.Tanim;
                birim = stok.Birim;
                miktar = 1;
                TeklifsizSat satinAlinacakMalzeme = new TeklifsizSat(stokno, tanim, miktar, birim, kiralamatoplam, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }
            if (TxtKiralamaYakitGun.Text != "0")
            {
                Stok stok = stokManager.Get("YAKIT");
                stokno = stok.Stokno;
                tanim = stok.Tanim;
                birim = stok.Birim;
                miktar = TxtYakitLitre.Text.ConDouble();
                toplam = TxtKiralamaYakitGun.Text.ConDouble();
                TeklifsizSat satinAlinacakMalzeme = new TeklifsizSat(stokno, tanim, miktar, birim, toplam, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }
            if (textBTxtSeyahatAavansToplamGun.Text != "0")
            {
                Stok stok = stokManager.Get("İŞ AVANS");
                stokno = stok.Stokno;
                tanim = stok.Tanim;
                birim = stok.Birim;
                miktar = TxtSeyahatAvansGunGun.Text.ConDouble();
                toplam = textBTxtSeyahatAavansToplamGun.Text.ConDouble();
                TeklifsizSat satinAlinacakMalzeme = new TeklifsizSat(stokno, tanim, miktar, birim, toplam, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }
            if (TxtUcakGun.Text != "0")
            {
                Stok stok = stokManager.Get("UÇAK BİLETİ");
                stokno = stok.Stokno;
                tanim = stok.Tanim;
                birim = stok.Birim;
                miktar = TxtUcakMiktar.Text.ConDouble();
                toplam = TxtUcakGun.Text.ConDouble();
                TeklifsizSat satinAlinacakMalzeme = new TeklifsizSat(stokno, tanim, miktar, birim,
                    toplam, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }
            if (TxtOtobusGun.Text != "0")
            {
                Stok stok = stokManager.Get("OTOBÜS BİLETİ");
                stokno = stok.Stokno;
                tanim = stok.Tanim;
                birim = stok.Birim;
                miktar = TxtOtobusMiktar.Text.ConDouble();
                toplam = TxtOtobusGun.Text.ConDouble();
                TeklifsizSat satinAlinacakMalzeme = new TeklifsizSat(stokno, tanim, miktar, birim,
                    toplam, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }
            if (TxtGorevHarcirahGunTopGun.Text != "0")
            {
                Stok stok = stokManager.Get("GÖREV HARCIRAH");
                stokno = stok.Stokno;
                tanim = stok.Tanim;
                birim = stok.Birim;
                miktar = TxtHarcirahGunGun.Text.ConDouble();
                toplam = TxtGorevHarcirahGunTopGun.Text.ConDouble();
                TeklifsizSat satinAlinacakMalzeme = new TeklifsizSat(stokno, tanim, miktar, birim,
                    toplam, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (TxtIaseToplamGun.Text != "0")
            {
                Stok stok = stokManager.Get("GOREV İAŞE");
                stokno = stok.Stokno;
                tanim = stok.Tanim;
                birim = stok.Birim;
                miktar = TxtIaseGunGun.Text.ConDouble();
                toplam = TxtIaseToplamGun.Text.ConDouble();
                TeklifsizSat satinAlinacakMalzeme = new TeklifsizSat(stokno, tanim, miktar, birim,
                    toplam, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }
            if (list.Count == 0)
            {
                MessageBox.Show("Eleman Bulunamadı");
                return;
            }

            foreach (TeklifsizSat item in list)
            {
                teklifsizSatManager.Add(item);
            }
        }
        void SatDoldur()
        {
            masrafyerino = infos[4].ToString();
            talepeden = infos[1].ToString();
            bolum = infos[2].ToString();
            projekodu = infos[3].ToString();
        }
        void CreateLog()
        {
            string sayfa = "YURT İÇİ GÖREV";
            YurtIciGorev gorev = yurtIciGorevManager.Get(LblIsAkisNo.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "YURT İÇİ GÖREV OLUŞTURULDU.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        private void TxtKonaklamGunTl_TextChanged(object sender, EventArgs e)
        {
            TxtKonaklamaToplam.Text = ToplamHesapla(TxtKonaklamaGun.Text, TxtKonaklamGunTl.Text);
            TxtGunlukToplam.Text = GunlukToplam();
        }
        private void TxtKonaklamaGun_TextChanged(object sender, EventArgs e)
        {
            TxtKonaklamaToplam.Text = ToplamHesapla(TxtKonaklamaGun.Text, TxtKonaklamGunTl.Text);
        }
        string ToplamHesapla(string gun, string tl, string yakit = "")
        {
            double g, t, toplam, y = 0;
            if (gun == "" || (tl == ""))
            {
                return "";
            }
            if (yakit != "")
            {
                g = gun.ConDouble(); t = tl.ConDouble();
                y = yakit.ConDouble();
                toplam = (g * t) + y;
                return toplam.ToString();
            }
            g = gun.ConDouble(); t = tl.ConDouble();
            toplam = g * t;
            return toplam.ToString();
        }
        string GenelToplam()
        {
            double geneltoplam = 0, konaklamatoplam = 0, arackiralamatoplam = 0, seyahatistoplam = 0, ucaktoplam = 0, otobustoplam = 0;
            if (TxtKonaklamaToplam.Text != "")
            {
                konaklamatoplam = TxtKonaklamaToplam.Text.ConDouble();
            }
            if (TxtKiralamaToplam.Text != "")
            {
                arackiralamatoplam = TxtKiralamaToplam.Text.ConDouble();
            }
            if (TxtSeyahatAvansToplam.Text != "")
            {
                seyahatistoplam = TxtSeyahatAvansToplam.Text.ConDouble();
            }
            if (TxtUcak.Text != "")
            {
                ucaktoplam = TxtUcak.Text.ConDouble();
            }
            if (TxtOtobus.Text != "")
            {
                otobustoplam = TxtOtobus.Text.ConDouble();
            }
            geneltoplam = konaklamatoplam + arackiralamatoplam + seyahatistoplam + ucaktoplam + otobustoplam;
            if (geneltoplam == 0)
            {
                return "";
            }
            return geneltoplam.ToString();
        }
        string GunlukToplam()
        {
            double geneltoplam = 0, konaklamatoplam = 0, arackiralamatoplam = 0, seyahatistoplam = 0, ucaktoplam = 0, otobustoplam = 0;
            if (TxtKonaklamGunTl.Text != "")
            {
                konaklamatoplam = TxtKonaklamGunTl.Text.ConDouble();
            }
            if (TxtKiralamaGunTl.Text != "")
            {
                arackiralamatoplam = TxtKiralamaGunTl.Text.ConDouble();
            }
            if (TxtSeyahatAvansGunTl.Text != "")
            {
                seyahatistoplam = TxtSeyahatAvansGunTl.Text.ConDouble();
            }

            geneltoplam = konaklamatoplam + arackiralamatoplam + seyahatistoplam + ucaktoplam + otobustoplam;
            if (geneltoplam == 0)
            {
                return "";
            }
            return geneltoplam.ToString();
        }
        string GenelToplamGun()
        {
            double geneltoplam = 0, konaklamatoplam = 0, arackiralamatoplam = 0, seyahatistoplam = 0, ucaktoplam = 0, otobustoplam = 0, gorevHarcirahi = 0, iase = 0;
            if (TxtKonaklamaToplamGun.Text != "")
            {
                konaklamatoplam = TxtKonaklamaToplamGun.Text.ConDouble();
            }
            if (TxtKiralamaToplamGun.Text != "")
            {
                arackiralamatoplam = TxtKiralamaToplamGun.Text.ConDouble();
            }
            if (textBTxtSeyahatAavansToplamGun.Text != "")
            {
                seyahatistoplam = textBTxtSeyahatAavansToplamGun.Text.ConDouble();
            }
            if (TxtUcakGun.Text != "")
            {
                ucaktoplam = TxtUcakGun.Text.ConDouble();
            }
            if (TxtOtobusGun.Text != "")
            {
                otobustoplam = TxtOtobusGun.Text.ConDouble();
            }
            if (TxtGorevHarcirahGunTopGun.Text != "")
            {
                gorevHarcirahi = TxtGorevHarcirahGunTopGun.Text.ConDouble();
            }
            if (TxtIaseToplamGun.Text != "")
            {
                iase = TxtIaseToplamGun.Text.ConDouble();
            }
            geneltoplam = konaklamatoplam + arackiralamatoplam + seyahatistoplam + ucaktoplam + otobustoplam + gorevHarcirahi + iase;
            if (geneltoplam == 0)
            {
                return "";
            }
            return geneltoplam.ToString();
        }

        string GunlukToplamGun()
        {
            double geneltoplam = 0, konaklamatoplam = 0, arackiralamatoplam = 0, seyahatistoplam = 0, ucaktoplam = 0, otobustoplam = 0, gorevHarcirahi = 0, iase = 0;
            if (TxtKonaklamGunTlGun.Text != "")
            {
                konaklamatoplam = TxtKonaklamGunTlGun.Text.ConDouble();
            }
            if (TxtKiralamaGunTlGun.Text != "")
            {
                arackiralamatoplam = TxtKiralamaGunTlGun.Text.ConDouble();
            }
            if (TxtSeyahatAvansGunTlGun.Text != "")
            {
                seyahatistoplam = TxtSeyahatAvansGunTlGun.Text.ConDouble();
            }

            if (TxtHarcirahGunTlGun.Text != "")
            {
                gorevHarcirahi = TxtHarcirahGunTlGun.Text.ConDouble();
            }
            if (TxtIaseGunTlGun.Text != "")
            {
                iase = TxtIaseGunTlGun.Text.ConDouble();
            }
            geneltoplam = konaklamatoplam + arackiralamatoplam + seyahatistoplam + ucaktoplam + otobustoplam + gorevHarcirahi + iase;
            if (geneltoplam == 0)
            {
                return "";
            }
            return geneltoplam.ToString();
        }

        private void TxtSeyahatAvansGunTl_TextChanged(object sender, EventArgs e)
        {
            TxtSeyahatAvansToplam.Text = ToplamHesapla(TxtSeyahatAvansGun.Text, TxtSeyahatAvansGunTl.Text);
            TxtGunlukToplam.Text = GunlukToplam();
        }

        private void TxtSeyahatAvansGun_TextChanged(object sender, EventArgs e)
        {
            TxtSeyahatAvansToplam.Text = ToplamHesapla(TxtSeyahatAvansGun.Text, TxtSeyahatAvansGunTl.Text);
        }

        private void TxtKiralamaGun_TextChanged(object sender, EventArgs e)
        {
            TxtKiralamaToplam.Text = ToplamHesapla(TxtKiralamaGun.Text, TxtKiralamaGunTl.Text);
        }

        private void TxtKiralamaGunTl_TextChanged(object sender, EventArgs e)
        {
            TxtKiralamaToplam.Text = ToplamHesapla(TxtKiralamaGun.Text, TxtKiralamaGunTl.Text);
            TxtGunlukToplam.Text = GunlukToplam();
        }

        private void TxtKonaklamaGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtKonaklamGunTl_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtKiralamaGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtKiralamaGunTl_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtKiralamaYakit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtSeyahatAvansGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtSeyahatAvansGunTl_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtUcak_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtOtobus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtGenelToplam_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtSeyahatAvansToplam_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtKiralamaToplam_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtKonaklamaToplam_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtKonaklamaToplam_TextChanged(object sender, EventArgs e)
        {
            TxtGenelToplam.Text = GenelToplam();
        }

        private void TxtKiralamaToplam_TextChanged(object sender, EventArgs e)
        {
            TxtGenelToplam.Text = GenelToplam();
        }

        private void TxtSeyahatAvansToplam_TextChanged(object sender, EventArgs e)
        {
            TxtGenelToplam.Text = GenelToplam();
        }

        private void TxtKonaklamaGunGun_TextChanged(object sender, EventArgs e)
        {
            TxtKonaklamaToplamGun.Text = ToplamHesapla(TxtKonaklamaGunGun.Text, TxtKonaklamGunTlGun.Text);
        }

        private void TxtKonaklamGunTlGun_TextChanged(object sender, EventArgs e)
        {
            TxtKonaklamaToplamGun.Text = ToplamHesapla(TxtKonaklamaGunGun.Text, TxtKonaklamGunTlGun.Text);
            TxtGunlukToplamGun.Text = GunlukToplamGun();
        }

        private void TxtKiralamaGunGun_TextChanged(object sender, EventArgs e)
        {
            TxtKiralamaToplamGun.Text = ToplamHesapla(TxtKiralamaGunGun.Text, TxtKiralamaGunTlGun.Text, TxtKiralamaYakitGun.Text);
        }

        private void TxtKiralamaGunTlGun_TextChanged(object sender, EventArgs e)
        {
            TxtKiralamaToplamGun.Text = ToplamHesapla(TxtKiralamaGunGun.Text, TxtKiralamaGunTlGun.Text, TxtKiralamaYakitGun.Text);
            TxtGunlukToplamGun.Text = GunlukToplamGun();
        }

        private void TxtKiralamaYakitGun_TextChanged(object sender, EventArgs e)
        {
            TxtKiralamaToplamGun.Text = ToplamHesapla(TxtKiralamaGunGun.Text, TxtKiralamaGunTlGun.Text, TxtKiralamaYakitGun.Text);
        }

        private void TxtSeyahatAvansGunGun_TextChanged(object sender, EventArgs e)
        {
            textBTxtSeyahatAavansToplamGun.Text = ToplamHesapla(TxtSeyahatAvansGunGun.Text, TxtSeyahatAvansGunTlGun.Text);
        }

        private void TxtSeyahatAvansGunTlGun_TextChanged(object sender, EventArgs e)
        {
            textBTxtSeyahatAavansToplamGun.Text = ToplamHesapla(TxtSeyahatAvansGunGun.Text, TxtSeyahatAvansGunTlGun.Text);
            TxtGunlukToplamGun.Text = GunlukToplamGun();
        }

        private void TxtYakitLitre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtUcakMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtOtobusMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtKonaklamGunTlGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtKiralamaGunTlGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtSeyahatAvansGunTlGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
        string siparisSat;
        private void BtnGorevSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Görevi Silmek İstediğinize Emin Misiniz? Bu İşlem Geri Alınamaz!", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = yurtIciGorevManager.Delete(TxtIsAkisNoTamamla.Text.ConInt());
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Directory.Delete(dosyaGun, true);
                CreateLogSil();

                SatDataGridview1 gorev = satDataGridview1Manager.Get(TxtIsAkisNoTamamla.Text);
                siparisSat = gorev.SiparisNo;
                if (siparisSat != "")
                {
                    string messege = satDataGridview1Manager.YurtIciSatSil(siparisSat);
                    if (messege != "OK")
                    {
                        MessageBox.Show(messege, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

                MessageBox.Show(TxtIsAkisNoTamamla.Text + " İş Akış Nolu YURT İÇİ GÖREV Başarıyla Silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
            }
        }

        private void TxtKonaklamaToplamGun_TextChanged(object sender, EventArgs e)
        {
            TxtGenelToplamGun.Text = GenelToplamGun();
        }

        private void TxtKiralamaToplamGun_TextChanged(object sender, EventArgs e)
        {
            TxtGenelToplamGun.Text = GenelToplamGun();
        }
        int index;
        private void CmbIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CmbIslemTuru.SelectedIndex.ConInt();
            if (index == 0)
            {
                BtnKaydetGun.Visible = true;
                BtnGuncelle.Visible = false;
                BtnCokluKonaklama.Visible = true;
            }
            if (index == 1)
            {
                BtnKaydetGun.Visible = false;
                BtnGuncelle.Visible = true;
                BtnCokluKonaklama.Visible = false;
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (!TxtIsAkisNoTamamla.MaskFull)
            {
                MessageBox.Show("Lütfen 9 haneli İş Akiş Numarasını Eksiksiz Girinz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Güncellemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string proje = CmbProjeGun.Text;
                YurtIciGorev yurtIci = new YurtIciGorev(TxtIsAkisNoTamamla.Text.ConInt(), TxtGorevEmriNoGun.Text, TxtGorevinKonusuGun.Text, proje, TxtGidilecekYerGun.Text, DtBaslamaTarihiGun.Value, DtBitisTarihiGun.Value, TxtToplamSureGun.Text, CmbButceKoduGun.Text, CmbSiparsGun.Text, CmbAdSoyadGun.Text, TxtGoreviGun.Text, TxtMasrafyeriNoGun.Text, TxtMasrafYeriGun.Text, CmbUlasimGidisGun.Text, CmbUlasimGorevYeriGun.Text, CmbUlasimDonusGun.Text, TxtKonaklamaGunGun.Text.ConInt(), TxtKonaklamGunTlGun.Text.ConDouble(), TxtKonaklamaToplamGun.Text.ConDouble(), TxtKiralamaGunGun.Text.ConInt(), TxtKiralamaGunTlGun.Text.ConDouble(), TxtKiralamaYakitGun.Text.ConDouble(), TxtKiralamaToplamGun.Text.ConDouble(), TxtSeyahatAvansGunGun.Text.ConInt(), TxtSeyahatAvansGunTlGun.Text.ConDouble(), textBTxtSeyahatAavansToplamGun.Text.ConDouble(), TxtHarcirahGunGun.Text.ConInt(), TxtHarcirahGunTlGun.Text.ConDouble(), TxtGorevHarcirahGunTopGun.Text.ConDouble(), TxtIaseGunGun.Text.ConInt(), TxtIaseGunTlGun.Text.ConDouble(), TxtIaseToplamGun.Text.Length.ConDouble(), TxtUcakGun.Text.ConDouble(), TxtOtobusGun.Text.ConDouble(), TxtAracPlakasiGun.Text, TxtCikisKmGun.Text.ConDouble(), TxtDonusKmGun.Text.ConDouble(), toplamkm, TxtGenelToplamGun.Text.ConDouble());

                string mesaj = yurtIciGorevManager.YurtIciGun(yurtIci, TxtIsAkisNoTamamla.Text.ConInt());

                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                TaslakKopyala();
                CreateWord2();
                CreateLogGun();
                try
                {
                    Directory.Delete(yol, true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    File.Delete(taslakYolu);
                }
                mesaj = BildirimKayitGuncelle();
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
            }
        }

        private void TxtGorevHarcirahGunTop_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtHarcirahGunTl_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtHarcirahGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtHarcirahGun_TextChanged(object sender, EventArgs e)
        {
            TxtGorevHarcirahGunTop.Text = ToplamHesapla(TxtHarcirahGun.Text, TxtHarcirahGunTl.Text);
        }

        private void TxtHarcirahGunTl_TextChanged(object sender, EventArgs e)
        {
            TxtGorevHarcirahGunTop.Text = ToplamHesapla(TxtHarcirahGun.Text, TxtSeyahatAvansGunTl.Text);
            TxtGunlukToplam.Text = GunlukToplam();
        }

        private void TxtGorevHarcirahGunTop_TextChanged(object sender, EventArgs e)
        {
            TxtGenelToplam.Text = GenelToplam();
        }

        private void TxtHarcirahGunGun_TextChanged(object sender, EventArgs e)
        {
            TxtGorevHarcirahGunTopGun.Text = ToplamHesapla(TxtHarcirahGunGun.Text, TxtHarcirahGunTlGun.Text);
        }

        private void TxtGorevHarcirahGunTopGun_TextChanged(object sender, EventArgs e)
        {
            TxtGenelToplamGun.Text = GenelToplamGun();
        }

        private void TxtHarcirahGunTlGun_TextChanged(object sender, EventArgs e)
        {
            TxtGorevHarcirahGunTopGun.Text = ToplamHesapla(TxtHarcirahGunGun.Text, TxtHarcirahGunTlGun.Text);
            TxtGunlukToplamGun.Text = GunlukToplamGun();
        }

        private void TxtIaseGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtIaseGunTl_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtIaseToplam_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtIaseGun_TextChanged(object sender, EventArgs e)
        {
            TxtIaseToplam.Text = ToplamHesapla(TxtIaseGun.Text, TxtIaseGunTl.Text);
        }

        private void TxtIaseToplam_TextChanged(object sender, EventArgs e)
        {
            TxtGenelToplam.Text = GenelToplam();
        }

        private void TxtKonaklamaGunGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtKiralamaGunGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtSeyahatAvansGunGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtHarcirahGunGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtIaseGunGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtHarcirahGunTlGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtIaseGunTlGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtKonaklamaToplamGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtKiralamaToplamGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBTxtSeyahatAavansToplamGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtGorevHarcirahGunTopGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtIaseToplamGun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtIaseGunGun_TextChanged(object sender, EventArgs e)
        {
            TxtIaseToplamGun.Text = ToplamHesapla(TxtIaseGunGun.Text, TxtIaseGunTlGun.Text);
        }

        private void TxtIaseToplamGun_TextChanged(object sender, EventArgs e)
        {
            TxtGenelToplamGun.Text = GenelToplamGun();
        }

        private void TxtIaseGunTl_TextChanged(object sender, EventArgs e)
        {
            TxtGunlukToplam.Text = GunlukToplam();
        }
        string GorevlendirmeControl()
        {
            if (CmbPersonelAdi.Text=="")
            {
                return "Lütfen Personel Adı bilgisini doldurunuz!";
            }
            if (CmbIl.Text == "")
            {
                return "Lütfen İl bilgisini doldurunuz!";
            }
            if (CmbIlce.Text == "")
            {
                return "Lütfen İlçe bilgisini doldurunuz!";
            }
            if (CmbBolgeKomutanlik.Text == "")
            {
                return "Lütfen Komutanlıklar bilgisini doldurunuz!";
            }
            if (TxtGorevlendirmeNedeni.Text == "")
            {
                return "Lütfen Görevlendirme Nedeni bilgisini doldurunuz!";
            }
            return "OK";
        }
        void CreateFileGorevlendirme()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\GÖREVLENDİRME\";

            /*string root = @"D:\DTS";
            string subdir = @"D:\DTS\İDARİ İŞLER\";
            string anadosya = @"D:\DTS\İDARİ İŞLER\YURT İÇİ GÖREV\";*/
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(anadosya))
            {
                Directory.CreateDirectory(anadosya);
            }

            dosya = anadosya + LblIsAkis.Text + "\\";
            Directory.CreateDirectory(dosya);

        }

        void TaslakKopyalaGorevlendirme()
        {
            string root = @"C:\DTS";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(yol))
            {
                Directory.CreateDirectory(yol);
            }

            File.Copy(kaynak + "MP-FR-172 GÖREVLENDİRME BELGESİ REV (00).docx", yol + "MP-FR-172 GÖREVLENDİRME BELGESİ REV (00).docx");
            taslakYolu = yol + "MP-FR-172 GÖREVLENDİRME BELGESİ REV (00).docx";
        }

        void CreateWordGorevlendirme()
        {
            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            object filePath = taslakYolu;
            

            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["Tarih"].Range.Text = DateTime.Now.ToString("d");
            wBookmarks["AdSoyad"].Range.Text = CmbPersonelAdi.Text;
            wBookmarks["Unvani"].Range.Text = LblUnvan.Text;
            wBookmarks["Tc"].Range.Text = LblTc.Text;
            wBookmarks["Il"].Range.Text = CmbIl.Text;
            wBookmarks["Ilce"].Range.Text = CmbIlce.Text;
            wBookmarks["Tugay"].Range.Text = CmbBolgeKomutanlik.Text;
            wBookmarks["Plaka"].Range.Text = CmbPlaka.Text;
            wBookmarks["GorevlendirmeNedeni"].Range.Text = TxtGorevlendirmeNedeni.Text;
            wBookmarks["BasTarihi"].Range.Text = DtBasTarihi.Value.ToString("d");
            wBookmarks["BitTarihi"].Range.Text = DtBitTarihi.Value.ToString("d");
            

            wDoc.SaveAs2(dosya + LblIsAkis.Text + ".docx");
            wDoc.Close();
            wApp.Quit(false);
        }

        private void BtnKaydett_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek isteğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                
                CreateFileGorevlendirme();
                TaslakKopyalaGorevlendirme();

                Gorevlendirme gorevlendirme = new Gorevlendirme(LblIsAkis.Text.ConInt(), CmbPersonelAdi.Text, LblUnvan.Text, LblTc.Text, CmbIl.Text, CmbIlce.Text, CmbBolgeKomutanlik.Text, CmbPlaka.Text, TxtGorevlendirmeNedeni.Text, DtBasTarihi.Value, DtBitTarihi.Value, dosya, "DEVAM EDIYOR");

                string mesaj = gorevlendirmeManager.Add(gorevlendirme);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                CreateWordGorevlendirme();

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string mesaj3 = BildirimGorevlendirme();
                if (mesaj3!="OK")
                {
                    MessageBox.Show(mesaj3, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    Directory.Delete(yol, true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    File.Delete(taslakYolu);
                }
                TemizleGorevlendirme();
                IsAkisNoGorevlendirme();
            }
            
        }
        void TemizleGorevlendirme()
        {
            CmbPersonelAdi.SelectedIndex = -1; LblUnvan.Text = "00"; LblTc.Text = "00"; CmbIl.SelectedIndex = -1; CmbIlce.SelectedIndex = -1; CmbBolgeKomutanlik.SelectedIndex = -1; CmbPlaka.Text = ""; TxtGorevlendirmeNedeni.Clear();
        }

        private void CmbPersonelAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            PersonelKayit personelKayit = kayitManager.Get(0, CmbPersonelAdi.Text);
            if (personelKayit==null)
            {
                return;
            }
            LblUnvan.Text = personelKayit.Isunvani;
            LblTc.Text = personelKayit.Tc;

            AracZimmeti aracZimmeti = aracZimmetiManager.GetAdSoyad(CmbPersonelAdi.Text);
            if (aracZimmeti==null)
            {
                CmbPlaka.Text = "";
                return;
            }
            else
            {
                CmbPlaka.Text = aracZimmeti.Plaka;
            }

        }
        void Plaka()
        {
            CmbPlaka.DataSource = aracZimmetiManager.GetList();
            CmbPlaka.ValueMember = "Id";
            CmbPlaka.DisplayMember = "Plaka";
            CmbPlaka.SelectedValue = -1;
        }
        string il;
        List<BolgeKayit> bolgeKayits;
        private void CmbIl_SelectedValueChanged(object sender, EventArgs e)
        {
            il = CmbIl.Text;
            CmbIlceYükle();

            bolgeKayits = bolgeKayitManager.GetListBolgeKomutanlik(il);
            CmbBolgeKomutanlik.DataSource = bolgeKayits;
            CmbBolgeKomutanlik.ValueMember = "Id";
            CmbBolgeKomutanlik.DisplayMember = "Tugay";
            CmbBolgeKomutanlik.SelectedValue = -1;

        }
        void CmbIlceYükle()
        {
            if (start==false)
            {
                return;
            }
            CmbIlce.DataSource = tedarikciFirmaManager.Ilceler(il);
            CmbIlce.SelectedIndex = -1;
            CmbIlce.Text = "";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IsAkisNo();
                TaslakKopyala();
                int konaklamagun = 0, seyahatavansgun = 0, kiralamaGun = 0, harcirahGun = 0, iaseGun = 0;
                if (TxtKonaklamaGun.Text != "")
                {
                    konaklamagun = TxtKonaklamaGun.Text.ConInt();
                }
                if (TxtKiralamaGun.Text != "")
                {
                    kiralamaGun = TxtKiralamaGun.Text.ConInt();
                }
                if (TxtSeyahatAvansGun.Text != "")
                {
                    seyahatavansgun = TxtSeyahatAvansGun.Text.ConInt();
                }
                if (TxtHarcirahGun.Text != "")
                {
                    harcirahGun = TxtHarcirahGun.Text.ConInt();
                }
                if (TxtIaseGun.Text != "")
                {
                    iaseGun = TxtIaseGun.Text.ConInt();
                }
                CreateDirectory();
                islemadimi = "1.ADIM:GÖREV OLUŞTURULDU";
                YurtIciGorev yurtIciGorev = new YurtIciGorev(LblIsAkisNo.Text.ConInt(), TxtGorevEmriNo.Text, TxtGorevinKonusu.Text, CmbProje.Text, TxtGidilecekYer.Text, DtBaslamaTarihi.Value, DtBitisTarihi.Value, TxtToplamSure.Text, CmbButceKodu.Text, CmbSiparisNo.Text, CmbAdSoyad.Text, TxtGorevi.Text, TxtMasrafyeriNo.Text, TxtMasrafYeri.Text, CmbUlasimGidis.Text, CmbUlasimGorevYeri.Text, CmbUlasimDonus.Text, konaklamagun, TxtKonaklamGunTl.Text.ConDouble(), TxtKonaklamaToplam.Text.ConDouble(), kiralamaGun, TxtKiralamaGunTl.Text.ConDouble(), TxtKiralamaToplam.Text.ConDouble(), seyahatavansgun, TxtSeyahatAvansGunTl.Text.ConDouble(), TxtSeyahatAvansToplam.Text.ConDouble(), harcirahGun, TxtHarcirahGunTl.Text.ConDouble(), TxtGorevHarcirahGunTop.Text.ConDouble(), iaseGun, TxtIaseGunTl.Text.ConDouble(), TxtIaseToplam.Text.ConDouble(), TxtUcak.Text.ConDouble(), TxtOtobus.Text.ConDouble(), TxtGenelToplam.Text.ConDouble(), TxtPlaka.Text, TxtCikisKm.Text.ConDouble(), islemadimi, dosya, konaklamaTuru);
                string mesaj = yurtIciGorevManager.Add(yurtIciGorev);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLog();
                CreateWord();
                //Task.Factory.StartNew(() => MailSendMetot());
                System.Threading.Tasks.Task.Factory.StartNew(() => MailSendMetot());

                

                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string mesaj2 = BildirimKayit();
                if (mesaj2 != "OK")
                {
                    MessageBox.Show(mesaj2, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    Directory.Delete(yol, true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    File.Delete(taslakYolu);
                }
                Temizle();
            }
        }
        string BildirimGorevlendirme()
        {
            string[] array = new string[8];

            array[0] = "Görevlendirme"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = LblIsAkis.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "iş akış numaralı"; // Bildirim türü
            array[4] = CmbPersonelAdi.Text + " personel için"; // İÇERİK
            array[5] = DtBasTarihi.Value.ToString("d")+" tarihinden" + DtBitTarihi.Value.ToString("d") + "tarihine kadar";
            array[6] = "Görevlendirme kaydı oluşturmuştur!";

            BildirimYetki bildirimYetki = bildirimYetkiManager.Get(infos[1].ToString());
            if (bildirimYetki == null)
            {
                array[7] = infos[0].ToString();
            }
            else
            {
                array[7] = bildirimYetki.SorumluId + infos[0].ToString();
            }

            string mesaj = FrmHelper.BildirimGonder(array, array[7]);
            return mesaj;
        }

        string BildirimKayit()
        {
            string[] array = new string[8];

            array[0] = "Yurt İçi Görev"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = LblIsAkisNo.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "iş akış numaralı"; // Bildirim türü
            array[4] = CmbAdSoyad.Text + " personel için"; // İÇERİK
            array[5] = TxtGidilecekYer.Text + "istikametine gitmek üzere";
            array[6] = "Yurt içi görev kaydı oluşturmuştur!";

            BildirimYetki bildirimYetki = bildirimYetkiManager.Get(infos[1].ToString());
            if (bildirimYetki == null)
            {
                array[7] = infos[0].ToString();
            }
            else
            {
                array[7] = bildirimYetki.SorumluId + infos[0].ToString();
            }

            string mesaj = FrmHelper.BildirimGonder(array, array[7]);
            return mesaj;
        }
        string BildirimKayitKapat()
        {
            string[] array = new string[8];

            array[0] = "Yurt İçi Görev"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = TxtIsAkisNoTamamla.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "iş akış numaralı"; // Bildirim türü
            array[4] = CmbAdSoyadGun.Text + " personel için"; // İÇERİK
            array[5] = TxtGidilecekYerGun.Text + "istikametine gitmek üzere";
            array[6] = "oluşturulan Yurt içi görev kaydı kapatmıştır!";

            BildirimYetki bildirimYetki = bildirimYetkiManager.Get(infos[1].ToString());
            if (bildirimYetki == null)
            {
                array[7] = infos[0].ToString();
            }
            else
            {
                array[7] = bildirimYetki.SorumluId + infos[0].ToString();
            }

            string mesaj = FrmHelper.BildirimGonder(array, array[7]);
            return mesaj;
        }

        string BildirimKayitGuncelle()
        {
            string[] array = new string[8];

            array[0] = "Yurt İçi Görev"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = TxtIsAkisNoTamamla.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "iş akış numaralı"; // Bildirim türü
            array[4] = CmbAdSoyadGun.Text + " personel için"; // İÇERİK
            array[5] = TxtGidilecekYerGun.Text + "istikametine gitmek üzere";
            array[6] = "oluşturulan Yurt içi görev kaydı güncelledi!";

            BildirimYetki bildirimYetki = bildirimYetkiManager.Get(infos[1].ToString());
            if (bildirimYetki == null)
            {
                array[7] = infos[0].ToString();
            }
            else
            {
                array[7] = bildirimYetki.SorumluId + infos[0].ToString();
            }

            string mesaj = FrmHelper.BildirimGonder(array, array[7]);
            return mesaj;
        }


        private void TxtIaseGunTlGun_TextChanged(object sender, EventArgs e)
        {
            TxtIaseToplamGun.Text = ToplamHesapla(TxtIaseGunGun.Text, TxtIaseGunTlGun.Text);
            TxtGunlukToplamGun.Text = GunlukToplamGun();
        }

        private void textBTxtSeyahatAvansToplamGun_TextChanged(object sender, EventArgs e)
        {
            TxtGenelToplamGun.Text = GenelToplamGun();
        }

        private void TxtUcakGun_TextChanged(object sender, EventArgs e)
        {
            TxtGenelToplamGun.Text = GenelToplamGun();
        }

        private void TxtOtobusGun_TextChanged(object sender, EventArgs e)
        {
            TxtGenelToplamGun.Text = GenelToplamGun();
        }

        private void BtnKaydetGun_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Güncellemek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                islemadimi = "2.ADIM:GÖREV TAMAMLANMIŞTIR";
                TaslakKopyala();
                YurtIciGorev yurtIciGorev = new YurtIciGorev(TxtIsAkisNoTamamla.Text.ConInt(), TxtGorevEmriNoGun.Text, TxtGorevinKonusuGun.Text, CmbProjeGun.Text, TxtGidilecekYerGun.Text, DtBaslamaTarihiGun.Value, DtBitisTarihiGun.Value, TxtToplamSureGun.Text, CmbButceKoduGun.Text, CmbSiparsGun.Text, CmbAdSoyadGun.Text, TxtGoreviGun.Text, TxtMasrafyeriNoGun.Text, TxtMasrafYeriGun.Text, CmbUlasimGidisGun.Text, CmbUlasimGorevYeriGun.Text, CmbUlasimDonusGun.Text, TxtKonaklamaGunGun.Text.ConInt(), TxtKonaklamGunTlGun.Text.ConDouble(), TxtKonaklamaToplamGun.Text.ConDouble(), TxtKiralamaGunGun.Text.ConInt(), TxtKiralamaGunTlGun.Text.ConDouble(), TxtKiralamaYakitGun.Text.ConDouble(), TxtKiralamaToplamGun.Text.ConDouble(), TxtSeyahatAvansGunGun.Text.ConInt(), TxtSeyahatAvansGunTlGun.Text.ConDouble(), textBTxtSeyahatAavansToplamGun.Text.ConDouble(),
                  TxtHarcirahGunGun.Text.ConInt(), TxtHarcirahGunTlGun.Text.ConDouble(), TxtGorevHarcirahGunTopGun.Text.ConDouble(), TxtIaseGunGun.Text.ConInt(), TxtIaseGunTlGun.Text.ConDouble(), TxtIaseToplamGun.Text.ConDouble(), TxtUcakGun.Text.ConDouble(), TxtOtobusGun.Text.ConDouble(), TxtAracPlakasiGun.Text, TxtCikisKmGun.Text.ConDouble(), TxtDonusKmGun.Text.ConDouble(), toplamkm, TxtGenelToplamGun.Text.ConDouble(), islemadimi, dosyaGun, konaklamaTuru);

                
                string mesaj = yurtIciGorevManager.Update(yurtIciGorev, TxtIsAkisNoTamamla.Text.ConInt());
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Directory.Delete(yol, true);
                    return;
                }
                DialogResult dr2 = MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir. Word Çıktısı Oluşturmak İster Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr2 == DialogResult.Yes)
                {
                    CreateWord2();
                    CreateLogWordCikti();
                }
                DialogResult dr3 = MessageBox.Show("SAT Kaydı Oluşturmak İster Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr3 == DialogResult.Yes)
                {
                    SatOlustur();
                    CreateLogSatOlustur();
                }
                CreateLogBitir();
                TxtKonaklamaGunGun.Enabled = true;
                TxtKonaklamGunTlGun.Enabled = true;
                TxtKonaklamaToplamGun.Enabled = true;
                konaklamaTuru = "TEKLİ KONAKLAMA";
                System.Threading.Tasks.Task.Factory.StartNew(() => MailSendMetotBitir());
                string mesaj2 = BildirimKayitKapat();
                if (mesaj2 != "OK")
                {
                    MessageBox.Show(mesaj2, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Directory.Delete(yol, true);
                TemizleGuncelle();
            }
        }
        void CreateLogSil()
        {
            string sayfa = "YURT İÇİ GÖREV";
            YurtIciGorev gorev = yurtIciGorevManager.Get(TxtIsAkisNoTamamla.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "YURT İÇİ GÖREV SİLİNMİŞTİR.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogBitir()
        {
            string sayfa = "YURT İÇİ GÖREV";
            YurtIciGorev gorev = yurtIciGorevManager.Get(TxtIsAkisNoTamamla.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "YURT İÇİ GÖREV GÜNCELLENMİŞ VE TAMAMLANMIŞTIR.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogGun()
        {
            string sayfa = "YURT İÇİ GÖREV";
            YurtIciGorev gorev = yurtIciGorevManager.Get(TxtIsAkisNoTamamla.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "YURT İÇİ GÖREV GÜNCELLENMİŞTİR.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogWordCikti()
        {
            string sayfa = "YURT İÇİ GÖREV";
            YurtIciGorev gorev = yurtIciGorevManager.Get(TxtIsAkisNoTamamla.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "YURT İÇİ GÖREV WORD ÇIKTISI OLUŞTURULMUŞTUR.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogSatOlustur()
        {
            string sayfa = "YURT İÇİ GÖREV";
            YurtIciGorev gorev = yurtIciGorevManager.Get(TxtIsAkisNoTamamla.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "YURT İÇİ GÖREV SAT KAYDI OLUŞTURULMUŞTUR.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        private void CmbButceKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtKonaklamaGun.Enabled = true;
            TxtKonaklamGunTl.Enabled = true;
            TxtKonaklamaToplam.Enabled = true;
            TxtKiralamaGun.Enabled = false;
            TxtKiralamaGunTl.Enabled = false;
            TxtKiralamaToplam.Enabled = false;
            TxtSeyahatAvansGun.Enabled = false;
            TxtSeyahatAvansGunTl.Enabled = false;
            TxtSeyahatAvansToplam.Enabled = false;
            TxtUcak.Enabled = false;
            TxtOtobus.Enabled = false;
        }
        void Kapat1(string secim1)
        {
            if (secim1 == "Uçak Bileti")
            {
                TxtUcak.Enabled = true;
                TxtKiralamaGun.Enabled = false;
                TxtKiralamaGunTl.Enabled = false;
                TxtKiralamaToplam.Enabled = false;
                TxtOtobus.Enabled = false;
                GrbSirketAraci.Enabled = false;
            }
            if (secim1 == "Otobüs Bileti")
            {
                TxtOtobus.Enabled = true;
                TxtUcak.Enabled = false;
                TxtKiralamaGun.Enabled = false;
                TxtKiralamaGunTl.Enabled = false;
                TxtKiralamaToplam.Enabled = false;
                GrbSirketAraci.Enabled = false;
            }
            if (secim1 == "Şirket Aracı")
            {
                GrbSirketAraci.Enabled = true;
                TxtOtobus.Enabled = false;
                TxtUcak.Enabled = false;
                TxtKiralamaGun.Enabled = false;
                TxtKiralamaGunTl.Enabled = false;
                TxtKiralamaToplam.Enabled = false;
                CmbUlasimGorevYeri.SelectedIndex = 1;
                CmbUlasimDonus.SelectedIndex = 2;
            }
            if (secim1 == "Kiralık Araç")
            {
                TxtKiralamaGun.Enabled = true; TxtKiralamaGunTl.Enabled = true;
                TxtKiralamaToplam.Enabled = true;
                TxtOtobus.Enabled = false;
                TxtUcak.Enabled = false;
                GrbSirketAraci.Enabled = false;
                CmbUlasimGorevYeri.SelectedIndex = 0;
                CmbUlasimDonus.SelectedIndex = 3;
            }
        }
        void Kapat2(string secim2)
        {
            if (secim2 == "Kiralık Araç")
            {
                TxtKiralamaGun.Enabled = true;
                TxtKiralamaGunTl.Enabled = true;
                TxtKiralamaToplam.Enabled = true;
                GrbSirketAraci.Enabled = false;
            }
            if (secim2 == "Şirket Aracı")
            {
                TxtKiralamaGun.Enabled = false;
                TxtKiralamaGunTl.Enabled = false;
                TxtKiralamaToplam.Enabled = false;
                GrbSirketAraci.Enabled = true;
            }
        }
        void Kapat3(string secim3)
        {
            if (secim3 == "Uçak Bileti")
            {
                TxtUcak.Enabled = true;
            }
            if (secim3 == "Otobüs Bileti")
            {
                TxtOtobus.Enabled = true;
            }
            if (secim3 == "Şirket Aracı")
            {
                GrbSirketAraci.Enabled = true;
            }
            if (secim3 == "Kiralık Araç")
            {
                TxtKiralamaGun.Enabled = true; TxtKiralamaGunTl.Enabled = true;
                TxtKiralamaToplam.Enabled = true;
            }
        }
        private void CmbUlasimGidis_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kapat1(CmbUlasimGidis.Text);
        }

        private void CmbUlasimGorevYeri_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kapat2(CmbUlasimGorevYeri.Text);
        }

        private void CmbUlasimDonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kapat3(CmbUlasimDonus.Text);
        }

        private void TxtUcak_TextChanged(object sender, EventArgs e)
        {
            TxtGenelToplam.Text = GenelToplam();
        }

        private void TxtOtobus_TextChanged(object sender, EventArgs e)
        {
            TxtGenelToplam.Text = GenelToplam();
        }
        void TemizleGuncelle()
        {
            TxtIsAkisNoTamamla.Clear(); TxtGorevEmriNoGun.Clear(); TxtGorevinKonusuGun.Clear(); CmbProjeGun.SelectedValue = -1;
            TxtGidilecekYerGun.Clear(); TxtToplamSureGun.Clear(); CmbButceKoduGun.Text = ""; CmbSiparsGun.Text = "";
            CmbAdSoyadGun.Text = ""; TxtMasrafyeriNoGun.Clear(); TxtMasrafYeriGun.Clear(); CmbUlasimGidisGun.Text = "";
            CmbUlasimGorevYeriGun.Text = ""; CmbUlasimDonusGun.Text = ""; TxtKonaklamaGunGun.Clear(); TxtKonaklamGunTlGun.Clear();
            TxtKonaklamaToplamGun.Clear(); TxtKiralamaGunGun.Clear(); TxtKiralamaGunTlGun.Clear(); TxtKiralamaYakitGun.Clear();
            TxtKiralamaToplamGun.Clear(); TxtSeyahatAvansGunGun.Clear(); TxtSeyahatAvansGunTlGun.Clear();
            textBTxtSeyahatAavansToplamGun.Clear(); TxtUcakGun.Clear(); TxtOtobusGun.Clear(); TxtGenelToplamGun.Clear();
            TxtAracPlakasiGun.Clear(); TxtCikisKmGun.Clear(); TxtDonusKmGun.Clear(); TxtToplamKmGun.Clear();
            TxtYakitLitre.Clear(); TxtUcakMiktar.Clear(); TxtOtobusMiktar.Clear(); TxtHarcirahGunGun.Clear(); TxtHarcirahGunTlGun.Clear();
            TxtGorevHarcirahGunTopGun.Clear(); TxtGoreviGun.Clear(); TxtFirmalar.Clear();
        }
        string isakisnogun;
        private void BtnBulT_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNoTamamla.MaskFull) // true false dondurur şu an true ise ife giricek false ise girmicek.
            {

                YurtIciGorev yurtIciGorev = yurtIciGorevManager.Get(TxtIsAkisNoTamamla.Text.ConInt());
                if (yurtIciGorev == null)
                {
                    MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TemizleGuncelle();
                    return;
                }

                CmbProjeGun.Text = yurtIciGorev.Proje;
                TxtGidilecekYerGun.Text = yurtIciGorev.Gidilecekyer;
                TxtGorevinKonusuGun.Text = yurtIciGorev.Gorevinkonusu;
                DtBaslamaTarihiGun.Value = yurtIciGorev.Baslamatarihi.ConDate();
                DtBitisTarihiGun.Value = yurtIciGorev.Bitistarihi.ConDate();
                TxtToplamSureGun.Text = yurtIciGorev.Toplamsure;
                CmbButceKoduGun.Text = yurtIciGorev.Butcekodu;
                CmbSiparsGun.Text = yurtIciGorev.Siparisno;
                CmbAdSoyadGun.Text = yurtIciGorev.Adsoyad;
                TxtMasrafyeriNoGun.Text = yurtIciGorev.Masrafyerino;
                TxtMasrafYeriGun.Text = yurtIciGorev.Masrafyeri;
                CmbUlasimGidisGun.Text = yurtIciGorev.Ulasimgidis;
                CmbUlasimGorevYeriGun.Text = yurtIciGorev.Ulasimgorevyeri;
                CmbUlasimDonusGun.Text = yurtIciGorev.Ulasimdonus;
                TxtKonaklamaGunGun.Text = yurtIciGorev.Konaklamagun.ToString();
                TxtKonaklamGunTlGun.Text = yurtIciGorev.Konaklamaguntl.ToString();
                TxtKonaklamaToplamGun.Text = yurtIciGorev.Konaklamatoplam.ToString();
                TxtKiralamaGunGun.Text = yurtIciGorev.Kiralamagun.ToString();
                TxtKiralamaGunTlGun.Text = yurtIciGorev.Kiralamaguntl.ToString();
                TxtKiralamaYakitGun.Text = yurtIciGorev.Kiralamayakit.ToString();
                TxtKiralamaToplamGun.Text = yurtIciGorev.Kiralamatoplam.ToString();
                TxtSeyahatAvansGunGun.Text = yurtIciGorev.Seyahatavansgun.ToString();
                TxtSeyahatAvansGunTlGun.Text = yurtIciGorev.Seyahatguntl.ToString();
                textBTxtSeyahatAavansToplamGun.Text = yurtIciGorev.Seyahattoplam.ToString();
                TxtUcakGun.Text = yurtIciGorev.Ucakbileti.ToString();
                TxtOtobusGun.Text = yurtIciGorev.Otobusbileti.ToString();
                TxtGenelToplamGun.Text = yurtIciGorev.Geneltoplam.ToString();
                TxtGorevEmriNoGun.Text = yurtIciGorev.Gorevemrino;
                TxtAracPlakasiGun.Text = yurtIciGorev.Plaka;
                TxtCikisKmGun.Text = yurtIciGorev.Cikiskm.ToString();
                TxtDonusKmGun.Text = yurtIciGorev.Donuskm.ToString();
                TxtToplamKmGun.Text = yurtIciGorev.Toplamkm.ToString();
                yurticiid = yurtIciGorev.Id;
                TxtGoreviGun.Text = yurtIciGorev.Unvani;
                dosyaGun = yurtIciGorev.Dosyayolu;
                TxtHarcirahGunGun.Text = yurtIciGorev.HarcirahGun.ToString();
                TxtHarcirahGunTlGun.Text = yurtIciGorev.HarcirahGunTl.ToString();
                TxtGorevHarcirahGunTopGun.Text = yurtIciGorev.HarcirahToplam.ToString();
                TxtIaseGunGun.Text = yurtIciGorev.IaseGun.ToString();
                TxtIaseGunTlGun.Text = yurtIciGorev.IaseGunTl.ToString();
                TxtIaseToplamGun.Text = yurtIciGorev.IaseToplam.ToString();
                isakisnogun = yurtIciGorev.Isakisno.ToString();
                ustAmirMails = ustAmirManager.GetList(guncelid);
                if (ustAmirMails.Count > 0)
                {
                    usamirbolum = ustAmirMails[0].Bolum;
                    usamirisim = ustAmirMails[0].Adsoyad;
                }
                return;
            }
            MessageBox.Show("Lütfen 9 haneli İş Akiş Numarasını Eksiksiz Girinz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            TemizleGuncelle();
        }

        void Temizle()
        {
            IsAkisNo(); TxtGorevEmriNo.Clear(); TxtGorevinKonusu.Clear(); CmbProje.SelectedValue = -1; TxtGidilecekYer.Clear(); TxtToplamSure.Clear(); CmbButceKoduGun.Text = "";
            CmbSiparisNo.Text = ""; CmbAdSoyad.Text = ""; TxtMasrafyeriNo.Clear(); TxtMasrafYeri.Clear(); CmbUlasimGidis.Text = ""; CmbUlasimGorevYeri.Text = "";
            CmbUlasimDonus.Text = ""; TxtKonaklamaGun.Clear(); TxtKonaklamGunTl.Clear(); TxtKonaklamaToplam.Clear(); TxtKiralamaGun.Clear(); TxtKiralamaGunTl.Clear();
            TxtKiralamaToplam.Clear(); TxtSeyahatAvansGun.Clear(); TxtSeyahatAvansGunTl.Clear(); TxtSeyahatAvansToplam.Clear(); TxtUcak.Clear();
            TxtOtobus.Clear(); TxtGenelToplam.Clear(); CmbButceKodu.Text = ""; TxtPlaka.Clear(); TxtCikisKm.Clear(); TxtGorevi.Clear();
            TxtHarcirahGun.Clear(); TxtHarcirahGunTl.Clear(); TxtGorevHarcirahGunTop.Clear();
        }

        void SiparisIsimlerDoldur()
        {
            CmbAdSoyad.DataSource = siparisPersonelManager.GetList(siparis);
            CmbAdSoyad.ValueMember = "Id";
            CmbAdSoyad.DisplayMember = "Personel";
            CmbAdSoyad.SelectedValue = 0;
        }

        /*void ButceKoduKalemi2()
        {
            CmbButceKoduGun.DataSource = butceKoduManager.GetList();
            CmbButceKoduGun.ValueMember = "Id";
            CmbButceKoduGun.DisplayMember = "Butcekodu";
            CmbButceKoduGun.SelectedValue = 0;
        }*/
        void MailSendMetot()
        {
            MailSend("YURT İÇİ GÖREV", "Merhaba; \n\n" + LblIsAkisNo.Text + " İş Akış Numaralı, Yurt İçi Görev " + infos[1].ToString() +
                " Tarafından Oluşturulmuştur." + "\n\nİyi Çalışmalar.", new List<string>() { "resulgunes@mubvan.net" });
        }
        void MailSendMetotBitir()
        {
            MailSend("YURT İÇİ GÖREV", "Merhaba; \n\n" + isakisnogun + " İş Akış Numaralı, Yurt İçi Görev " + infos[1].ToString() +
                " Tarafından Güncelle ve Bitir İşlemi Yapılmıştır." + "\n\nİyi Çalışmalar.", new List<string>() { "resulgunes@mubvan.net" });
        }
        public void MailSend(string subject, string body, List<string> receivers, List<string> attachments = null)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                //client.Host = "smtp.gmail.com";
                client.Host = "192.168.23.10";
                //client.Host = "smtp-mail.outlook.com ";
                client.EnableSsl = false;
                client.Timeout = 11000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //client.Credentials = new System.Net.NetworkCredential("mubotomasyon@gmail.com", "MCHT44aa:");
                client.Credentials = new System.Net.NetworkCredential("dts@mubvan.net", "123456");
                //client.Credentials = new System.Net.NetworkCredential("mucahitaydemir@basaranteknoloji.net", "Aydemir_123");
                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                mailMessage.From = new MailAddress("dts@mubvan.net", "DTS Bilgilendirme");
                mailMessage.SubjectEncoding = Encoding.UTF8;
                mailMessage.Subject = subject; //E-posta Konu Kısmı
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.Body = body; // E-posta'nın Gövde Metni
                foreach (string item in receivers)
                {
                    mailMessage.To.Add(item);
                }
                mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                if (attachments != null)
                {
                    if (attachments.Count > 0)
                    {
                        foreach (string filePath in attachments)
                        {
                            if (File.Exists(filePath))
                            {
                                Attachment attachment = new Attachment(filePath);
                                mailMessage.Attachments.Add(attachment);
                            }
                        }
                    }
                }
                client.Send(mailMessage);
            }
            catch (Exception)
            {
                //  MessageBox.Show(ex.Message);
            }
        }
    }
}
