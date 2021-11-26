using Business;
using Business.Concreate;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using ClosedXML.Excel;
using DataAccess.Concreate;
using DataAccess.Concreate.STS;
using Entity;
using Entity.IdariIsler;
using Entity.STS;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;
using Application = Microsoft.Office.Interop.Word.Application;

namespace UserInterface.IdariIsler
{
    public partial class FrmKonaklama : Form
    {
        SiparislerManager siparislerManager;
        SiparisPersonelManager siparisPersonelManager;
        UstAmirManager ustAmirManager;
        TedarikciFirmaManager tedarikciFirmaManager;
        KonaklamaManager konaklamaManager;
        KonaklamaGecmisManager konaklamaGecmisManager;
        OtelManager otelManager;
        IdariIslerLogManager logManager;
        IsAkisNoManager isAkisNoManager;
        PersonelKayitManager kayitManager;
        SatDataGridview1Manager satDataGridview1Manager;
        SatNoManager satNoManager;
        SatIslemAdimlariManager satIslemAdimlariManager;
        StokManager stokManager;
        TeklifsizSatManager teklifsizSatManager;

        List<UstAmirMail> ustAmirMails;
        List<Konaklama> konaklamas;
        public object[] infos;
        bool start = true, start2 = true, start3 = true, start4 = true;
        int id, idgun, onayid, sayi, satNo=0;
        string usamirbolum, usamirisim, siparis, siparisgun, onaydurum, formno, setupYolu, dosya, satno, siparisNo, gerekce, harcamaturu, faturafirma, ilgilikisi, masrafyeri, donem;
        Double miktar, toplam;
        public FrmKonaklama()
        {
            InitializeComponent();
            siparislerManager = SiparislerManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            ustAmirManager = UstAmirManager.GetInstance();
            tedarikciFirmaManager = TedarikciFirmaManager.GetInstance();
            konaklamaManager = KonaklamaManager.GetInstance();
            konaklamaGecmisManager = KonaklamaGecmisManager.GetInstance();
            otelManager = OtelManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            satNoManager = SatNoManager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
            stokManager = StokManager.GetInstance();
            teklifsizSatManager = TeklifsizSatManager.GetInstance();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageKonaklama"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void FrmKonaklama_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            Personeller1();
            Personeller2();
            //Siparisler();
            //SiparislerGun();
            CmbIlYükle();
            CmbIlYükleGuncelle();
            DataDisplayOnay();
            //TabControl.TabPages.Remove(TabControl.TabPages["tabPage3"]);
            //setupYolu = Application.ExecutablePath;
            /*if (infos[0].ConInt() != 84)
            {
                if (infos[0].ConInt() != 25)
                {
                    TabControl.TabPages.Remove(TabControl.TabPages["tabPage3"]);
                }
            }*/
            start = false;
            start2 = false;
            start3 = false;
            start4 = false;
        }
        public void YenilenecekVeri()
        {
            IsAkisNo();
            //Siparisler();
            Personeller1();
            Personeller2();
            //SiparislerGun();
            CmbIlYükle();
            CmbIlYükleGuncelle();
            DataDisplayOnay();
        }
        void Personeller1()
        {
            CmbAdSoyad.DataSource = kayitManager.PersonelAdSoyad();
            CmbAdSoyad.ValueMember = "Id";
            CmbAdSoyad.DisplayMember = "Adsoyad";
            CmbAdSoyad.SelectedValue = -1;
        }
        void Personeller2()
        {
            CmbAdSoyadGun.DataSource = kayitManager.PersonelAdSoyad();
            CmbAdSoyadGun.ValueMember = "Id";
            CmbAdSoyadGun.DisplayMember = "Adsoyad";
            CmbAdSoyadGun.SelectedValue = -1;
        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        /*void Siparisler()
        {
            CmbSiparisNo.DataSource = siparislerManager.GetList();
            CmbSiparisNo.ValueMember = "Id";
            CmbSiparisNo.DisplayMember = "Siparisno";
            CmbSiparisNo.SelectedValue = 0;
        }*/
        /*void SiparislerGun()
        {
            CmbSiparisNoGun.DataSource = siparislerManager.GetList();
            CmbSiparisNoGun.ValueMember = "Id";
            CmbSiparisNoGun.DisplayMember = "Siparisno";
            CmbSiparisNoGun.SelectedValue = 0;
        }*/
        void DataDisplayOnay()
        {
            konaklamas = konaklamaManager.OnayList("ONAYLANDI");
            dataBinder.DataSource = konaklamas.ToDataTable();
            DtgList.DataSource = dataBinder;
            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Talepturu"].HeaderText = "TALEP TÜRÜ";
            DtgList.Columns["Formno"].HeaderText = "GÖREV FORM NO";
            DtgList.Columns["Butcekodu"].HeaderText = "BÜTÇE KODU/TANIMI";
            DtgList.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgList.Columns["Gorevi"].HeaderText = "GÖREVİ";
            DtgList.Columns["Masrafyerino"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ";
            DtgList.Columns["Tc"].HeaderText = "TC KİMLİK NO";
            DtgList.Columns["Hes"].HeaderText = "HES KODU";
            DtgList.Columns["Email"].HeaderText = "E-MAIL";
            DtgList.Columns["Kisakod"].HeaderText = "ŞİRKET NO/KISA KOD";
            DtgList.Columns["Otelsehir"].HeaderText = "OTELİN BULUNDUĞU ŞEHİR";
            DtgList.Columns["Otelad"].HeaderText = "OTELİN ADI";
            DtgList.Columns["Giristarihi"].HeaderText = "GİRİŞ TARİHİ";
            DtgList.Columns["Cikistarihi"].HeaderText = "ÇIKIŞ TARİHİ";
            DtgList.Columns["Konaklamasuresi"].HeaderText = "KONAKLAMA SÜRESİ";
            DtgList.Columns["Gunukucret"].HeaderText = "GÜNLÜK KONAKLAMA TUTARI";
            DtgList.Columns["Toplamucret"].HeaderText = "TOPLAM KONAKLAMA TUTARI";
            DtgList.Columns["isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Onay"].Visible = false;
            DtgList.Columns["Dosyayolu"].Visible = false;

            TxtTop.Text = DtgList.RowCount.ToString();
        }
        private void CmbAdSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbAdSoyad.Text);
            CmbSiparisNo.Text = siparis.Siparis;
            TxtMasrafyeriNo.Text = siparis.Masrafyerino;
            TxtMasrafYeri.Text = siparis.Masrafyeri;
            id = siparis.Id;
            TxtTc.Text = siparis.Tc;
            TxtHes.Text = siparis.Hes;
            TxtMail.Text = siparis.Mail;
            TxtKisaKod.Text = siparis.Kisakod;
            TxtGorevi.Text = siparis.Gorevi;
            ustAmirMails = ustAmirManager.GetList(id);
            if (ustAmirMails.Count > 0)
            {
                usamirbolum = ustAmirMails[0].Bolum;
                usamirisim = ustAmirMails[0].Adsoyad;
            }
            start2 = false;
        }

        private void BtnSureHesaplaGun_Click(object sender, EventArgs e)
        {
            DateTime bTarih = DtGirisTarihiGun.Value;
            DateTime kTarih = DtCikisTarihiGun.Value;
            TimeSpan SonucGun = kTarih - bTarih;
            int gun = SonucGun.TotalDays.ConInt();
            TxtKonaklamaSuresiGun.Text = gun.ToString();
            double geneltop = 0, gunluk = 0;
            int gunsayisi = 0;
            if (TxtGunlukUcretGun.Text == "")
            {
                gunluk = 0;
            }
            else
            {
                gunluk = TxtGunlukUcretGun.Text.ConDouble();
            }
            gunsayisi = TxtKonaklamaSuresiGun.Text.ConInt();
            geneltop = gunluk * gunsayisi;
            TxtGenelTopGun.Text = geneltop.ToString();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Konaklama Bilgilerini Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (TxtGorevFormNo.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle Görev Form No Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                IsAkisNo();
                CreateDirectory();
                double gunlukucret = TxtGunlukUcret.Text.ConDouble();
                double toplamucret = TxtGenelTop.Text.ConDouble();
                Konaklama konaklama = new Konaklama(LblIsAkisNo.Text.ConInt(), CmbTalepTuru.Text, TxtGorevFormNo.Text, CmbButceKodu.Text, CmbSiparisNo.Text, CmbAdSoyad.Text, TxtGorevi.Text, TxtMasrafyeriNo.Text, TxtMasrafYeri.Text, TxtTc.Text, TxtHes.Text, TxtMail.Text,
                    TxtKisaKod.Text, CmbIl.Text, TxtOtelinAdi.Text, gunlukucret, toplamucret, DtGirisTarihi.Value, DtCikisTarihi.Value, TxtSure.Text, dosya,satNo);
                string mesaj = konaklamaManager.Add(konaklama);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //System.Threading.Tasks.Task.Factory.StartNew(() => MailSendMetot());
                //System.Threading.Tasks.Task.Factory.StartNew(() => BodyMailSendMetod());
                CreateWord();
                CreateLog();
                
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataDisplayOnay();
                Temizle();
                IsAkisNo();
            }
            /*IXLWorkbook workbook = new XLWorkbook(@"C:\Users\MAYıldırım\Desktop\MÜB PERSONEL KONAKLAMA LİSTESİ 2021.xlsx");
            IXLWorksheets sheets = workbook.Worksheets;
            foreach (IXLWorksheet item in sheets)
            {

            }
            IXLWorksheet worksheet = workbook.Worksheet("AĞUSTOS");
            var rows = worksheet.Rows(2, 11);
            List<Konaklama> list = new List<Konaklama>();
            DateTime outDate = DateTime.Now;
            //double outDouble = 0;
            foreach (IXLRow item in rows)
            {
                Konaklama konaklama = new Konaklama(
                    "",
                    "",
                    item.Cell("L").Value.ToString(), // BÜTÇE KODU
                    "",
                    item.Cell("B").Value.ToString(), // AD SOYAD
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    item.Cell("C").Value.ToString(), // KONAKLAMA İL
                    item.Cell("D").Value.ToString(), // OTEL ADI
                    item.Cell("E").Value.ConDouble(), // GÜNLÜK ÜCRET
                    item.Cell("F").Value.ConDouble(), // TOPLAM ÜCRET
                    item.Cell("H").Value.ConTime(), // GİRİŞ TARİHİ
                    item.Cell("I").Value.ConTime(), // ÇIKIŞ TARİHİ
                    item.Cell("G").Value.ToString(), // KONAKLAMA GÜN SAYISI
                    "");
                konaklamaManager.Add(konaklama);
                KonaklamaGecmis entity = new KonaklamaGecmis(
                    item.Cell("A").Value.ConTime(),
                    item.Cell("B").Value.ToString(),
                    item.Cell("C").Value.ToString(),
                    item.Cell("D").Value.ToString(),
                    item.Cell("E").Value.ConDouble(),
                    item.Cell("F").Value.ConDouble(),
                    item.Cell("G").Value.ConInt(),
                    item.Cell("H").Value.ConTime(),
                    item.Cell("I").Value.ConTime(),
                    item.Cell("J").Value.ToString(),
                    item.Cell("K").Value.ToString(),
                    item.Cell("L").Value.ToString(),
                    ay);
                konaklamaGecmisManager.Add(entity);
            }*/
        }
        void SatOlustur()
        {
            siparisNo = Guid.NewGuid().ToString();
            satNo = satNoManager.Add(new SatNo(siparisNo));
            Harcama();

            SatDataGridview1 satDataGridview1 = new SatDataGridview1(satNo, isakisno.ConInt(), infos[4].ToString(),infos[1].ToString(), 
                infos[2].ToString(),"","",DateTime.Now, gerekce, siparisNo, personelAd, personelSiparis, personeUnvani, personeMasYerNo, personeMasYeri, dosya,infos[0].ConInt(), "SAT ONAY", donem, "BAŞARAN", proje, TxtOtelinAdi.Text);

            string mesaj = satDataGridview1Manager.Add(satDataGridview1);
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SatDataGridview1 dataGridview1 = new SatDataGridview1(satNo, butceKodu, "BSRN GN.MDL.SATIN ALMA", harcamaturu, faturafirma, ilgilikisi, masrafyeri, siparisNo, 0, dosya, "SAT ONAY");
            mesaj = satDataGridview1Manager.Update(dataGridview1);
            if (mesaj != " SAT Ön Onay İşlemi Başarıyla Tamamlandı.")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            satDataGridview1Manager.TeklifDurum(siparisNo);
            satDataGridview1Manager.DurumGuncelleOnay(siparisNo);
            string yapilanislem = LblIsAkisNo.Text + " Nolu Konaklama Kaydı İçin SAT Oluşturuldu.";
            SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
            satIslemAdimlariManager.Add(satIslemAdimlari);
        }
        void Harcama()
        {
            MessageBox.Show("Lütfen Öncelikle Satın Alma Talebinin Oluşturulabilmesi İçin Eksik Olan Bilgileri Tamamlayınız!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Properties.Settings.Default.SiparisNo = siparisNo;
            Properties.Settings.Default.YurtIciDosyaYolu = dosya;
            Properties.Settings.Default.YurtIciYeniAd = isakisno.ToString();
            Properties.Settings.Default.YurtIciIsAkisNo = isakisno.ConInt();
            Properties.Settings.Default.Save();

            FrmYurtIciGorevSAT frmYurtIciGorevSAT = new FrmYurtIciGorevSAT();
            frmYurtIciGorevSAT.ShowDialog();

            gerekce = Properties.Settings.Default.Gerekce.ToString();
            harcamaturu = Properties.Settings.Default.HarcamaTuru.ToString();
            faturafirma = Properties.Settings.Default.FaturaFirma.ToString();
            ilgilikisi = Properties.Settings.Default.IlgiliKisi.ToString();
            masrafyeri = Properties.Settings.Default.MasrafYeri.ToString();
            donem = Properties.Settings.Default.YurtIciGorevDonem.ToString();
            dosya = Properties.Settings.Default.DosyaYolu.ToString();
            string stokno, tanim, birim;
            Stok stok = stokManager.Get("KONAKLAMA");
            stokno = stok.Stokno;
            tanim = stok.Tanim;
            birim = stok.Birim;
            /*miktar = TxtSure.Text.ConDouble();
            toplam = TxtGenelTop.Text.ConDouble();*/
            TeklifsizSat satinAlinacakMalzeme = new TeklifsizSat(stokno, tanim, miktar, birim, toplam, siparisNo);
            teklifsizSatManager.Add(satinAlinacakMalzeme);
            
        }
        string personelAd, personelSiparis, personeUnvani, personeMasYerNo, personeMasYeri, butceKodu, proje="";
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            onayid = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            onaydurum = DtgList.CurrentRow.Cells["Onay"].Value.ToString();
            formno = DtgList.CurrentRow.Cells["Formno"].Value.ToString();
            isakisno = DtgList.CurrentRow.Cells["Isakisno"].Value.ConInt();
            personelAd = DtgList.CurrentRow.Cells["Adsoyad"].Value.ToString();
            personelSiparis = DtgList.CurrentRow.Cells["Siparisno"].Value.ToString();
            personeUnvani = DtgList.CurrentRow.Cells["Gorevi"].Value.ToString();
            personeMasYerNo = DtgList.CurrentRow.Cells["Masrafyerino"].Value.ToString();
            personeMasYeri = DtgList.CurrentRow.Cells["Masrafyeri"].Value.ToString();
            butceKodu = DtgList.CurrentRow.Cells["Butcekodu"].Value.ToString();
            dosya = DtgList.CurrentRow.Cells["Dosyayolu"].Value.ToString();
            satNo= DtgList.CurrentRow.Cells["SatNo"].Value.ConInt();
            miktar = DtgList.CurrentRow.Cells["Konaklamasuresi"].Value.ConDouble();
            toplam = DtgList.CurrentRow.Cells["Toplamucret"].Value.ConDouble();

            SiparisPersonel siparis = siparisPersonelManager.Get("", personelAd);
            proje = siparis.Projekodu;
        }
        
        void CreateLog()
        {
            string sayfa = "KONAKLAMA";
            Konaklama gorev = konaklamaManager.Get(LblIsAkisNo.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "KONAKLAMA TALEBİ KAYIT OLUŞTURULDU.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateWord()
        {
            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            //object filePath = "C:\\Users\\MAYıldırım\\Desktop\\Formlar\\DTS_Otel Rezervasyon Talep Formu.docx"; // taslak yolu
            object filePath = "Z:\\DTS\\İDARİ İŞLER\\WordTaslak\\DTS_Otel Rezervasyon Talep Formu2.docx";
            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["TalepTuru"].Range.Text= CmbTalepTuru.Text;
            wBookmarks["IsAkisNo"].Range.Text= TxtGorevFormNo.Text;
            wBookmarks["ButceKodu"].Range.Text= CmbButceKodu.Text;
            wBookmarks["SiparisNo"].Range.Text= CmbSiparisNo.Text;
            wBookmarks["AdSoyad"].Range.Text= CmbAdSoyad.Text;
            wBookmarks["Unvani"].Range.Text = TxtGorevi.Text;
            wBookmarks["MasrafYeriNo"].Range.Text = TxtMasrafyeriNo.Text;
            wBookmarks["Bolumu"].Range.Text = TxtMasrafYeri.Text;
            wBookmarks["Tc"].Range.Text= TxtTc.Text;
            wBookmarks["Hes"].Range.Text = TxtHes.Text;
            wBookmarks["Email"].Range.Text= TxtMail.Text;
            wBookmarks["SirketNo"].Range.Text= TxtKisaKod.Text;
            wBookmarks["OtelSehir"].Range.Text  = CmbIl.Text;
            wBookmarks["OtelAd"].Range.Text = TxtOtelinAdi.Text;
            wBookmarks["GirisTarihi"].Range.Text= DtGirisTarihi.Value.ToString("dd/MM/yyyy");
            wBookmarks["KonaklamaKayitBilgisi"].Range.Text =  "DTS Modülünde Konaklama Talebi Kayıt Oluşturuldu.";
            wBookmarks["Tarih1"].Range.Text =  DateTime.Now.ToString("dd/MM/yyyy H/mm/ss");
            wBookmarks["CikisTarihi"].Range.Text = DtCikisTarihi.Value.ToString("dd/MM/yyyy");
            wBookmarks["KonaklamaSuresi"].Range.Text= TxtSure.Text + " Gün";


            wDoc.SaveAs2(dosya + LblIsAkisNo.Text + ".docx");
            wDoc.Close();
            wApp.Quit(false);
        }
        void Temizle()
        {
            CmbTalepTuru.Text = ""; TxtGorevFormNo.Clear(); CmbButceKodu.Text = ""; CmbSiparisNo.Text = ""; CmbAdSoyad.Text = "";
            TxtGorevi.Clear(); TxtMasrafyeriNo.Clear(); TxtMasrafYeri.Clear(); TxtTc.Clear(); TxtHes.Clear(); TxtMail.Clear();
            TxtKisaKod.Clear(); CmbIl.Text = ""; TxtOtelinAdi.Text = ""; TxtSure.Clear(); TxtGunlukUcret.Clear(); TxtGenelTop.Clear();
            TxtGorevi.Clear();
        }
        void CreateDirectory()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\KONAKLAMA\";

            /*string root = @"D:\DTS";
            string subdir = @"D:\DTS\İDARİ İŞLER\";
            string anadosya = @"D:\DTS\İDARİ İŞLER\KONAKLAMA\";*/

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
        void CreateDirectorGuncelle()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\KONAKLAMA\";

            /*string root = @"D:\DTS";
            string subdir = @"D:\DTS\İDARİ İŞLER\";
            string anadosya = @"D:\DTS\İDARİ İŞLER\KONAKLAMA\";*/

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
            dosyaguncelle = anadosya + TxtIsAkisNo.Text + "\\";
            Directory.CreateDirectory(dosyaguncelle);
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnGorevReddet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(formno + " Nolu Konaklama Talebini Reddetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Konaklama konaklama = new Konaklama("REDDEDİLDİ");
                string mesaj = konaklamaManager.OnayGuncelle(konaklama, onayid);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Reddetme İşlemi Başarıyla Gerçekleşmştir.");
                DataDisplayOnay();
            }
        }
        int guncelleid;
        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İş Akış No Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Konaklama konaklama = konaklamaManager.Get(TxtIsAkisNo.Text.ConInt());
            if (konaklama == null)
            {
                MessageBox.Show(TxtIsAkisNo.Text + " İş Akış Nolu Bir Kayıt Bulunamamıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            guncelleid = konaklama.Id;
            TxtFormNoGun.Text = konaklama.Formno;
            CmbTalepTuruGun.Text = konaklama.Talepturu;
            CmbButceKoduGun.Text = konaklama.Butcekodu;
            CmbSiparisNoGun.Text = konaklama.Siparisno;
            CmbAdSoyadGun.Text = konaklama.Adsoyad;
            TxtGorevıGun.Text = konaklama.Gorevi;
            TxtMasrafYeriNoGun.Text = konaklama.Masrafyerino;
            TxtMasrafYeriGun.Text = konaklama.Masrafyeri;
            TxtTcGun.Text = konaklama.Tc;
            TxtHesGun.Text = konaklama.Hes;
            TxtEmailGun.Text = konaklama.Email;
            TxtKisaKodGun.Text = konaklama.Kisakod;
            CmbOtelSehirGun.Text = konaklama.Otelsehir;
            TxtOtelAdGun.Text = konaklama.Otelad;
            DtGirisTarihiGun.Value = konaklama.Giristarihi;
            DtCikisTarihiGun.Value = konaklama.Cikistarihi;
            TxtKonaklamaSuresiGun.Text = konaklama.Konaklamasuresi;
            TxtGunlukUcretGun.Text = konaklama.Gunukucret.ToString();
            TxtGenelTopGun.Text = konaklama.Toplamucret.ToString();
            dosyaguncelle = konaklama.Dosyayolu;
            satNo = konaklama.SatNo;
        }
        string dosyaguncelle;
        private void TxtGunlukUcret_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtGunlukUcret_TextChanged(object sender, EventArgs e)
        {
            if (TxtGunlukUcret.Text == "")
            {
                TxtGenelTop.Text = "0";
            }
        }

        private void TxtSure_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtGenelTop_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BtnOtelEkle_Click(object sender, EventArgs e)
        {
            TxtOtelinAdi.Text = "";
            CmbIl.Text = "";
            FrmOtelEkle frmOtelEkle = new FrmOtelEkle();
            frmOtelEkle.ShowDialog();

        }
        void OtelleriCek()
        {
            TxtOtelinAdi.DataSource = otelManager.GetList(CmbIl.Text);
            TxtOtelinAdi.ValueMember = "Id";
            TxtOtelinAdi.DisplayMember = "Oteladi";
            TxtOtelinAdi.SelectedValue = 0;
        }
        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            OtelleriCek();
            TxtOtelinAdi.Text = "";
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtFormNoGun.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Bir GÖREV FORM NUMARASI giriniz ve BUL butonuna tıklayınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Güncellemek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Konaklama konaklama = new Konaklama(TxtIsAkisNo.Text.ConInt(), CmbTalepTuruGun.Text, TxtFormNoGun.Text, CmbButceKoduGun.Text, CmbSiparisNoGun.Text, CmbAdSoyadGun.Text, TxtGorevıGun.Text, TxtMasrafYeriNoGun.Text, TxtMasrafYeriGun.Text, TxtTcGun.Text, TxtHesGun.Text, TxtEmailGun.Text, TxtKisaKodGun.Text, CmbOtelSehirGun.Text, TxtOtelAdGun.Text, TxtGunlukUcretGun.Text.ConDouble(), TxtGenelTopGun.Text.ConDouble(), DtGirisTarihiGun.Value, DtCikisTarihiGun.Value, TxtKonaklamaSuresiGun.Text, dosyaguncelle, satNo);
                string mesaj = konaklamaManager.Update(konaklama, guncelleid);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Konaklama konaklama2 = new Konaklama("ONAYLANMADI");
                string mesaj2 = konaklamaManager.OnayGuncelle(konaklama2, guncelleid);
                if (mesaj2 != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Directory.Delete(dosyaguncelle,true);
                CreateDirectorGuncelle();
                CreateWordGuncelle();
                CreateLogGuncelle();
                MessageBox.Show("Bilgiler Başarıyla Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
            }
        }
        void CreateLogGuncelle()
        {
            string sayfa = "KONAKLAMA";
            Konaklama gorev = konaklamaManager.Get(TxtIsAkisNo.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "KONAKLAMA TALEBİ GÜNCELLENDİ.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateWordGuncelle()
        {
            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            //object filePath = "C:\\Users\\MAYıldırım\\Desktop\\Formlar\\DTS_Otel Rezervasyon Talep Formu.docx"; // taslak yolu
            object filePath = "Z:\\DTS\\İDARİ İŞLER\\WordTaslak\\DTS_Otel Rezervasyon Talep Formu2.docx";

            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["TalepTuru"].Range.Text = CmbTalepTuruGun.Text;
            wBookmarks["IsAkisNo"].Range.Text = TxtFormNoGun.Text;
            wBookmarks["ButceKodu"].Range.Text = CmbButceKoduGun.Text;
            wBookmarks["SiparisNo"].Range.Text = CmbSiparisNoGun.Text;
            wBookmarks["AdSoyad"].Range.Text = CmbAdSoyadGun.Text;
            wBookmarks["Unvani"].Range.Text = TxtGorevıGun.Text;
            wBookmarks["MasrafYeriNo"].Range.Text = TxtMasrafYeriNoGun.Text;
            wBookmarks["Bolumu"].Range.Text = TxtMasrafYeriGun.Text;
            wBookmarks["Tc"].Range.Text = TxtTcGun.Text;
            wBookmarks["Hes"].Range.Text = TxtHesGun.Text;
            wBookmarks["Email"].Range.Text = TxtEmailGun.Text;
            wBookmarks["SirketNo"].Range.Text = TxtKisaKodGun.Text;
            wBookmarks["OtelSehir"].Range.Text = CmbOtelSehirGun.Text;
            wBookmarks["OtelAd"].Range.Text = TxtOtelAdGun.Text;
            wBookmarks["KonaklamaKayitBilgisi"].Range.Text = "DTS Modülünde Konaklama Talebi Kayıt Oluşturuldu.";
            wBookmarks["Tarih1"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy H/mm/ss");
            wBookmarks["GirisTarihi"].Range.Text = DtGirisTarihiGun.Value.ToString("dd/MM/yyyy");
            wBookmarks["CikisTarihi"].Range.Text = DtCikisTarihiGun.Value.ToString("dd/MM/yyyy");
            wBookmarks["KonaklamaSuresi"].Range.Text = TxtKonaklamaSuresiGun.Text + " Gün";

            wDoc.SaveAs2(dosyaguncelle + TxtIsAkisNo.Text + ".docx");
            wDoc.Close();
            wApp.Quit(false);
        }
        void TemizleGuncelle()
        {
            TxtFormNoGun.Clear(); CmbTalepTuruGun.Text = ""; CmbButceKoduGun.Text = ""; CmbSiparisNoGun.Text = ""; CmbAdSoyadGun.Text = ""; TxtGorevıGun.Clear();
            TxtMasrafYeriNoGun.Clear(); TxtMasrafYeriGun.Clear(); TxtTcGun.Clear(); TxtHesGun.Clear(); TxtEmailGun.Clear(); TxtKisaKodGun.Clear(); CmbOtelSehirGun.Text = ""; TxtOtelAdGun.Text = ""; TxtGunlukUcretGun.Clear(); TxtKonaklamaSuresiGun.Clear(); TxtGenelTopGun.Clear(); TxtGorevıGun.Clear();
        }
        private void BtnTemizleGun_Click(object sender, EventArgs e)
        {
            TemizleGuncelle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtFormNoGun.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Bir GÖREV FORM NUMARASI giriniz ve BUL butonuna tıklayınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult dr = MessageBox.Show(TxtFormNoGun.Text + " Nolu Göreve Ait Konaklama Bilgisini Silmek İstediğinize Emin Misiniz?\nBu İşlem Geri Alınamaz!", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = konaklamaManager.Delete(guncelleid);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Directory.Delete(dosyaguncelle, true);
                MessageBox.Show("Silme İşlemi Başarıyla Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
            }
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplayOnay();
        }

        private void BtnGorevOnayla_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("SAT Kaydı Oluşturmak İster Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SatOlustur();
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("İşlem İptal Edildi.","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            /*DialogResult dr = MessageBox.Show(formno + " Nolu Konaklama Talebini Onaylamak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Konaklama konaklama = new Konaklama("ONAYLANDI");
                string mesaj = konaklamaManager.OnayGuncelle(konaklama, onayid);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLogOnaylama();
                MessageBox.Show("Onaylama İşlemi Başarıyla Gerçekleşmştir.");
                DataDisplayOnay();
            }*/
        }
        void CreateLogOnaylama()
        {
            string sayfa = "KONAKLAMA";
            Konaklama gorev = konaklamaManager.Get(isakisno);
            int benzersizid = gorev.Id;
            string islem = "KONAKLAMA BİLGİSİ ONAYLANDI.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        int isakisno;
        

        private void CmbAdSoyadGun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start3 == true)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbAdSoyadGun.Text);
            CmbSiparisNoGun.Text = siparis.Siparis;
            TxtMasrafYeriNoGun.Text = siparis.Masrafyerino;
            TxtMasrafYeriGun.Text = siparis.Masrafyeri;
            idgun = siparis.Id;
            TxtTcGun.Text = siparis.Tc;
            TxtHesGun.Text = siparis.Hes;
            TxtEmailGun.Text = siparis.Mail;
            TxtKisaKodGun.Text = siparis.Kisakod;
            TxtGorevıGun.Text = siparis.Gorevi;
            ustAmirMails = ustAmirManager.GetList(idgun);
            if (ustAmirMails.Count > 0)
            {
                usamirbolum = ustAmirMails[0].Bolum;
                usamirisim = ustAmirMails[0].Adsoyad;
            }
            start4 = false;
        }

        private void BtnSureHesapla_Click(object sender, EventArgs e)
        {
            DateTime bTarih = DtGirisTarihi.Value;
            DateTime kTarih = DtCikisTarihi.Value;
            TimeSpan SonucGun = kTarih - bTarih;
            int gun = SonucGun.TotalDays.ConInt();
            TxtSure.Text = gun.ToString();
            double geneltop = 0, gunluk = 0;
            int gunsayisi = 0;
            if (TxtGunlukUcret.Text == "")
            {
                gunluk = 0;
            }
            else
            {
                gunluk = TxtGunlukUcret.Text.ConDouble();
            }
            gunsayisi = TxtSure.Text.ConInt();
            geneltop = gunluk * gunsayisi;
            TxtGenelTop.Text = geneltop.ToString();
        }

        private void CmbSiparisNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start)
            {
                if (start2 == true)
                {
                    return;
                }
            }
            siparis = CmbSiparisNo.Text;
            SiparisIsimlerDoldur();
            start = true;
            TxtMasrafyeriNo.Clear();
            TxtMasrafYeri.Clear();
            TxtTc.Clear();
            TxtHes.Clear();
            TxtMail.Clear();
            TxtKisaKod.Clear();
            TxtGorevi.Clear();
        }
        private void CmbSiparisNoGun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start3)
            {
                if (start4 == true)
                {
                    return;
                }
            }
            siparisgun = CmbSiparisNoGun.Text;
            SiparisIsimlerDoldurGun();
            start3 = true;
            TxtMasrafYeriNoGun.Clear();
            TxtMasrafYeriGun.Clear();
            TxtTcGun.Clear();
            TxtHesGun.Clear();
            TxtEmailGun.Clear();
            TxtKisaKodGun.Clear();
            TxtGorevıGun.Clear();
        }
        void SiparisIsimlerDoldur()
        {
            CmbAdSoyad.DataSource = siparisPersonelManager.GetList(siparis);
            CmbAdSoyad.ValueMember = "Id";
            CmbAdSoyad.DisplayMember = "Personel";
            CmbAdSoyad.SelectedValue = 0;
        }
        void SiparisIsimlerDoldurGun()
        {
            CmbAdSoyadGun.DataSource = siparisPersonelManager.GetList(siparisgun);
            CmbAdSoyadGun.ValueMember = "Id";
            CmbAdSoyadGun.DisplayMember = "Personel";
            CmbAdSoyadGun.SelectedValue = 0;
        }
        void CmbIlYükle()
        {
            CmbIl.DataSource = tedarikciFirmaManager.Iller();
            CmbIl.SelectedIndex = -1;
        }
        void CmbIlYükleGuncelle()
        {
            CmbOtelSehirGun.DataSource = tedarikciFirmaManager.Iller();
            CmbOtelSehirGun.SelectedIndex = -1;
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
        public void MailSendBodyHtml(string subject, string body, List<string> receivers, List<string> attachments = null)
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
                mailMessage.IsBodyHtml = true;
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

        void MailSendMetot()
        {
            MailSend("KONAKLAMA KAYIT", "Merhaba; \n\n" + TxtGorevFormNo.Text + " Nolu Görev İçin Konaklama Kaydı Oluşturulmuştur.\n\nİyi Çalışmalar.",
                new List<string>() { "emelayhan@mubvan.net" });
        }
        void BodyMailSendMetod()
        {
            MailSend("KONAKLAMA KAYIT", "Merhaba; \n\n" + TxtGorevFormNo.Text + " Nolu Görev İçin Konaklama Kaydı Oluşturularak, Onayınıza Sunulmuştur.\n\nİyi Çalışmalar.",
                new List<string>() { "resulgunes@mubvan.net" });

            /*string body = "Merhaba;<br>DTS Şehir İçi Görev Ekranınıza Bir Görevledirme Bilgisi Gelmiştir.Onaylayarak Üst Amirinizi Bilgilendirebilirsiniz.<br>İyi Çalışmalar.<br>" +
                "<a id='myLink' href=" + setupYolu + ">DTS Uygulamasını Aç</a>" +
            "<script>" +
            "  document.getElementById('myLink').style.color = 'white';" +
            "</script>";

            MailSendBodyHtml("Konaklama Kayıt", body, new List<string>() { "mehmetsenol@mubvan.net" });*/
        }
    }
}
