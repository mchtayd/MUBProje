using Business;
using Business.Concreate;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using DataAccess.Concreate.STS;
using Entity;
using Entity.IdariIsler;
using Entity.STS;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;
using UserInterface.STS;
using Application = Microsoft.Office.Interop.Word.Application;

namespace UserInterface.IdariIsler
{
    public partial class FrmAracBakimKayit : Form
    {
        IsAkisNoManager isAkisNoManager;
        AracManager aracManager;
        ZimmetAktarimManager zimmetAktarimManager;
        AracBakimManager aracBakimManager;
        PersonelKayitManager kayitManager;
        SiparisPersonelManager siparisPersonelManager;
        IdariIslerLogManager logManager;
        AracZimmetiManager aracZimmetiManager;
        SatDataGridview1Manager satDataGridview1Manager;
        SatNoManager satNoManager;
        ComboManager comboManager;
        SatIslemAdimlariManager satIslemAdimlariManager;
        TeklifsizSatManager teklifsizSatManager;
        IstenAyrilisManager ıstenAyrilisManager;
        List<string> fileNames = new List<string>();
        List<string> fileNames2 = new List<string>();
        public object[] infos;
        int id, isAkisNo, satNo, idTamamlanan;
        string dosya, dosyaYolu, kaynakdosyaismi, alinandosya, dosyaYoluGun, kaynakdosyaismiGun, alinandosyaGun, goturecekPersonel, goturecekPersonelBolum, comboAd, siparisNo, personelSiparis = "", unvani = "", masrafYeri = "", kaynakdosya, dosya2, sayfaTamamlanan;
        bool gec = false, dosyaControl = false;
        public FrmAracBakimKayit()
        {
            InitializeComponent();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            aracManager = AracManager.GetInstance();
            zimmetAktarimManager = ZimmetAktarimManager.GetInstance();
            aracBakimManager = AracBakimManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
            aracZimmetiManager = AracZimmetiManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            satNoManager = SatNoManager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
            teklifsizSatManager = TeklifsizSatManager.GetInstance();
            ıstenAyrilisManager = IstenAyrilisManager.GetInstance();
        }

        private void FrmAracBakimKayit_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            ComboFirma();
            ProjeKodu();
            gec = true;
            TxtGorevi.Clear();
            if (infos[1].ToString() != "RESUL GÜNEŞ")
            {
                BtnFirmaEkle.Visible = false;
            }
        }
        void ProjeKodu()
        {
            CmbProjeKodu.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProjeKodu.ValueMember = "Id";
            CmbProjeKodu.DisplayMember = "Baslik";
            CmbProjeKodu.SelectedValue = 0;
        }
        public void ComboFirma()
        {
            TxtBakOnarimFirma.DataSource = comboManager.GetList("BAKIM ONARIM YAPAN FİRMA");
            TxtBakOnarimFirma.ValueMember = "Id";
            TxtBakOnarimFirma.DisplayMember = "Baslik";
            TxtBakOnarimFirma.SelectedValue = 0;
        }
        void Personeller()
        {
            CmbPersoneller.DataSource = kayitManager.PersonelAdSoyad();
            CmbPersoneller.ValueMember = "Id";
            CmbPersoneller.DisplayMember = "Adsoyad";
            CmbPersoneller.SelectedValue = -1;
            TxtGorevi.Clear();
        }
        void PersonellerGun()
        {
            CmbTeslimEden.DataSource = kayitManager.PersonelAdSoyad();
            CmbTeslimEden.ValueMember = "Id";
            CmbTeslimEden.DisplayMember = "Adsoyad";
            CmbTeslimEden.SelectedValue = -1;
        }
        public void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
            Personeller();
            PersonellerGun();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageBakimKayit"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void BtnBulT_Click(object sender, EventArgs e)
        {
            if (TxtPlaka.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Plaka Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Arac arac = aracManager.Get(TxtPlaka.Text); // ARAÇ BİLGİLERİ
            //ZimmetAktarim zimmetAktarim = zimmetAktarimManager.AracZimmetBilgileri("%" + TxtPlaka.Text + '%'); // DURAN VARLIK LİSTESİNDEN
            AracZimmeti aracZimmeti = aracZimmetiManager.Get(TxtPlaka.Text); // ARAÇ ZİMMET LİSTESİNDEN
            if (arac == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz Plakaya Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                return;
            }
            Temizle();
            id = arac.Id;
            TxtPlaka.Text = arac.Plaka;
            TxtMarkasi.Text = arac.Markasi;
            TxtModel.Text = arac.ModelYili;
            TxtMotorNo.Text = arac.MotorNo;
            TxtSaseNo.Text = arac.SaseNo;
            TxtMulkiyet.Text = arac.MulkiyetBilgileri;
            TxtSiparisNo.Text = arac.Siparisno;
            DtProjeTahsisTarihi.Value = arac.ProjeTahsisTarihi;
            if (aracZimmeti == null)
            {
                TxtZimmetliPersonel.Text = "";
                TxtKullanildigiBolum.Text = "";
            }
            TxtZimmetliPersonel.Text = aracZimmeti.PersonelAd;
            TxtKullanildigiBolum.Text = aracZimmeti.Bolum;

            //DtgSonKayit.DataSource = aracBakimManager.AracBakimSonKayit(TxtPlaka.Text);
            AracBakimSonKayit();

            /*if (zimmetAktarim==null)
            {
                if (aracZimmeti==null)
                {
                    TxtZimmetliPersonel.Text = "";
                    TxtKullanildigiBolum.Text = "";
                    return;
                }
                TxtZimmetliPersonel.Text = aracZimmeti.PersonelAd;
                TxtKullanildigiBolum.Text = aracZimmeti.Bolum;

                return;
            }
            TxtKullanildigiBolum.Text = zimmetAktarim.Bolum;
            TxtZimmetliPersonel.Text = zimmetAktarim.PersonelAd;*/
        }
        List<AracBakim> aracBakims = new List<AracBakim>();
        void AracBakimSonKayit()
        {
            AracBakim aracBakim = aracBakimManager.AracBakimSonKayit(TxtPlaka.Text);
            if (aracBakim==null)
            {
                MessageBox.Show("Araç Daha Önce Bakıma Gitmediği İçin Son Bakım Kaydı Getirilmemektedir!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            DtgSonKayit.Rows.Add();
            int sonSatir = DtgSonKayit.RowCount - 1;
            DtgSonKayit.Rows[sonSatir].Cells["Column1"].Value = aracBakim.IsAkisNo;
            DtgSonKayit.Rows[sonSatir].Cells["Column2"].Value = aracBakim.Plaka;
            DtgSonKayit.Rows[sonSatir].Cells["Column7"].Value = aracBakim.Km;
            DtgSonKayit.Rows[sonSatir].Cells["Column8"].Value = aracBakim.BakimNedeni;
            DtgSonKayit.Rows[sonSatir].Cells["Column9"].Value = aracBakim.TalepTarihi;
            DtgSonKayit.Rows[sonSatir].Cells["Column10"].Value = aracBakim.BakYapanFirma;
            DtgSonKayit.Rows[sonSatir].Cells["Column11"].Value = aracBakim.ArizaAciklamasi;
            DtgSonKayit.Rows[sonSatir].Cells["Column12"].Value = aracBakim.TamamlanmaTarih;
            DtgSonKayit.Rows[sonSatir].Cells["Column13"].Value = aracBakim.SonucAciklama;
            DtgSonKayit.Rows[sonSatir].Cells["Column14"].Value = aracBakim.Tutar;

            sayfaTamamlanan = aracBakim.Sayfa;
            idTamamlanan = aracBakim.Id;
            IslemAdimlariDisplayTamamlanan();
            try
            {
                webBrowser3.Navigate(aracBakim.DosyaYolu);
            }
            catch (Exception)
            {
                return;
            }

        }
        void IslemAdimlariDisplayTamamlanan()
        {
            DtgIslemAdimlariDis.DataSource = logManager.GetList(sayfaTamamlanan, idTamamlanan);
            DtgIslemAdimlariDis.Columns["Id"].Visible = false;
            DtgIslemAdimlariDis.Columns["Sayfa"].Visible = false;
            DtgIslemAdimlariDis.Columns["Benzersizid"].Visible = false;
            DtgIslemAdimlariDis.Columns["Islem"].HeaderText = "YAPILAN İŞLEM";
            DtgIslemAdimlariDis.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgIslemAdimlariDis.Columns["Tarih"].HeaderText = "TARİH";
            DtgIslemAdimlariDis.Columns["Tarih"].Width = 100;
            DtgIslemAdimlariDis.Columns["Islemyapan"].Width = 135;
            DtgIslemAdimlariDis.Columns["Islem"].Width = 400;
        }

        void Temizle()
        {
            TxtPlaka.Clear(); TxtMarkasi.Clear(); TxtModel.Clear(); TxtMotorNo.Clear(); TxtSaseNo.Clear(); TxtMulkiyet.Clear(); TxtSiparisNo.Clear();
            TxtKullanildigiBolum.Clear(); TxtZimmetliPersonel.Clear(); TxtKm.Clear(); CmbBakNedeni.Text = ""; TxtAciklama.Clear(); CmbPersoneller.SelectedValue = ""; TxtGorevi.Text = ""; CmbPersoneller.SelectedValue = -1; TxtGorevi.Clear(); TxtGorevi.Clear();
            DtgSonKayit.DataSource = null; DtgIslemAdimlariDis.DataSource = null; webBrowser3.Navigate("");
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                goturecekPersonel = CmbPersoneller.Text;
                goturecekPersonelBolum = TxtGorevi.Text;
                IsAkisNo();
                CreateDirectory();
                DateTime talepTarihi = new DateTime(DtgTalepTarihi.Value.Year, DtgTalepTarihi.Value.Month, DtgTalepTarihi.Value.Day, DtSaat.Value.Hour, DtSaat.Value.Minute, DtSaat.Value.Second);
                AracBakim aracBakim = new AracBakim(LblIsAkisNo.Text.ConInt(), TxtPlaka.Text, TxtMarkasi.Text, TxtModel.Text, TxtMotorNo.Text, TxtSaseNo.Text, TxtMulkiyet.Text, TxtSiparisNo.Text, DtProjeTahsisTarihi.Value, TxtKullanildigiBolum.Text, TxtZimmetliPersonel.Text, TxtKm.Text.ConInt(), CmbBakNedeni.Text, talepTarihi, TxtAciklama.Text, dosya, goturecekPersonel, goturecekPersonelBolum);
                string mesaj = aracBakimManager.Add(aracBakim);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Directory.Delete(dosya, true);
                    return;
                }
                CreateWord();
                CreateLog();
                MessageBox.Show("Bilgiler Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsAkisNo();
                Temizle();
            }
        }

        void CreateLog()
        {
            string sayfa = "ARAÇ BAKIM KAYIT";
            AracBakim arac = aracBakimManager.Get(LblIsAkisNo.Text.ConInt());
            int benzersizid = arac.Id;
            string islem = "ARAÇ BAKIM KAYIT İŞLEMİ GERÇEKLEŞMİŞTİR.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogKapat()
        {
            string sayfa = "ARAÇ BAKIM KAYIT";
            AracBakim arac = aracBakimManager.Get(TxtIsAkisNo.Text.ConInt());
            int benzersizid = arac.Id;
            string islem = "ARAÇ BAKIM KAYDI KAPATILMIŞTIR.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogGuncelle()
        {
            string sayfa = "ARAÇ BAKIM KAYIT";
            AracBakim arac = aracBakimManager.Get(TxtIsAkisNoGun.Text.ConInt());
            int benzersizid = arac.Id;
            string islem = "ARAÇ BAKIM KAYDI GÜNCELLENMİŞTİR.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateDirectory()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\ULAŞTIRMA\";
            string anadosya2 = @"Z:\DTS\İDARİ İŞLER\ULAŞTIRMA\ARAÇ BAKIM KAYIT\";

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
            if (!Directory.Exists(anadosya2))
            {
                Directory.CreateDirectory(anadosya2);
            }
            dosya = anadosya2 + LblIsAkisNo.Text + "\\";
            Directory.CreateDirectory(dosya);
        }
        void CreateWord()
        {
            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            //object filePath = "C:\\Users\\MAYıldırım\\Desktop\\Formlar\\DTS_Yurt İçi Görev Formu.docx";
            object filePath = "Z:\\DTS\\İDARİ İŞLER\\WordTaslak\\MP-FR-150 DTS_Araç Bakım Onarım Talep Formu REV (+)2.docx";// taslak yolu

            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["IsAkisNo"].Range.Text = LblIsAkisNo.Text;
            wBookmarks["Plaka"].Range.Text = TxtPlaka.Text;
            wBookmarks["Marka"].Range.Text = TxtMarkasi.Text;
            wBookmarks["ModelYili"].Range.Text = TxtModel.Text;
            wBookmarks["MotorNo"].Range.Text = TxtMotorNo.Text;
            wBookmarks["SaseNo"].Range.Text = TxtSaseNo.Text;
            wBookmarks["MulkiyetBilgileri"].Range.Text = TxtMulkiyet.Text;
            wBookmarks["SiparisNo"].Range.Text = TxtSiparisNo.Text;
            wBookmarks["ProjeTahsisTarihi"].Range.Text = DtProjeTahsisTarihi.Value.ToString("dd/MM/yyyy");
            wBookmarks["KullanildigiBolum"].Range.Text = TxtKullanildigiBolum.Text;
            wBookmarks["ZimmetliPersonel"].Range.Text = TxtZimmetliPersonel.Text;
            wBookmarks["TalepTarihi"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
            wBookmarks["Km"].Range.Text = TxtKm.Text;
            wBookmarks["TalepAciklama"].Range.Text = TxtAciklama.Text;
            wBookmarks["TalepNedeni"].Range.Text = CmbBakNedeni.Text;
            wBookmarks["TalepEden"].Range.Text = goturecekPersonel;
            wBookmarks["Tarih1"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
            wBookmarks["Saat1"].Range.Text = DtSaat.Value.ToString("H:mm:ss");
            wBookmarks["Tarih2"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
            wBookmarks["Saat2"].Range.Text = DtSaat.Value.ToString("H:mm:ss");
            wBookmarks["FirmayaTeslimEden"].Range.Text = goturecekPersonel;
            wBookmarks["Unvani"].Range.Text = goturecekPersonelBolum;
            wBookmarks["Tarih3"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");

            wDoc.SaveAs2(dosya + LblIsAkisNo.Text + ".docx");
            wDoc.Close();
            wApp.Quit(false);
        }

        private void CmbPersoneller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gec == false)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbPersoneller.Text);
            TxtGorevi.Text = siparis.Gorevi;
        }
        #region KeyPress
        private void TxtMarkasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void TxtModel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtMotorNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtSaseNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtMulkiyet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtSiparisNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtKullanildigiBolum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtZimmetliPersonel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void CmbBakNedeni_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void TxtPlakaKapat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtSiparisNoKapat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtKullanildigiBolumKapat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtPersonelKapat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtAracKmKapat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtBakNedeniKapat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void DtTlalepTarihiKapat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void DtTalepSaatiKapat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void TxtArizaAciklamasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BtnGecmis_Click(object sender, EventArgs e)
        {
            FrmGecmisKayit frmGecmis = new FrmGecmisKayit();
            frmGecmis.infos = infos;
            frmGecmis.ShowDialog();
        }

        private void TxtGorevi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BtnKayitSil_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNoGun.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İş Akış No Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(TxtIsAkisNoGun.Text + " İş Akış Nolu Kaydı Silmek İstediğinize Emin Misiniz? Bu İşlem Geri Alınamaz!", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                aracBakimManager.Delete(silinecekId);
                Directory.Delete(dosyaYoluGun, true);
                //logManager.Delete();

                MessageBox.Show("Bilgiler Başarıyla Silinmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
            }
        }
        void TemizleGuncelle()
        {
            TxtIsAkisNoGun.Clear(); TxtPlakaGun.Clear(); TxtMarkaGun.Clear(); TxtModelYiliGun.Clear(); TxtMotorNoGun.Clear(); TxtSaseNoGun.Clear(); TxtMulkiyetGun.Clear(); TxtSiparisNoGun.Clear(); TxtKullanildigiBolumGun.Clear(); TxtZimmetliPersonleGun.Clear(); TxtAracKm.Clear(); CmbBakNedeniGun.Text = ""; TxtAciklamaGun.Clear(); webBrowser2.Navigate(""); TxtYapanFirmaGun.Clear(); TxtSonucAciklamaGun.Clear(); TxtTutarGun.Clear();
        }
        private void TxtTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
        #endregion

        private void TxtTeslimEdenGorevi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CmbTeslimEden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gec == false)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbTeslimEden.Text);
            TxtTeslimEdenGorevi.Text = siparis.Gorevi;
        }

        private void BtnFirmaEkle_Click(object sender, EventArgs e)
        {
            comboAd = "BAKIM ONARIM YAPAN FİRMA";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi = openFileDialog1.SafeFileName.ToString();
                alinandosya = openFileDialog1.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                fileNames.Add(alinandosya);
                dosyaControl = true;
                webBrowser1.Navigate(dosyaYolu);
            }

        }
        string aciklama = "", donem = "", stokno = "", tanim = "", birim = "", butcekodu = "";
        int miktar;
        private void BtnKapat_Click(object sender, EventArgs e)
        {
            if (TxtPlakaKapat.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Geçerli Bir İş Akış Numarası Giriniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (dosyaControl == false)
            {
                MessageBox.Show("Lütfen Öncelikle Servisten Gelen Bakım Onarım Formunu Taratarak Bu Alana Ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Otomatik Olarak SAT kaydı Oluşuturulacak ve SAT Onay Ekranına İletilecektir! Lütfen Tüm Bilgileri Eksiksiz Doldurunuz. SAT Kaydı Oluşturulsun Mu?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                
                FrmAracBakimSAT frmAracBakimSAT = new FrmAracBakimSAT();
                frmAracBakimSAT.ShowDialog();
                
                aciklama = Properties.Settings.Default.Gerekce;
                donem = Properties.Settings.Default.YurtIciGorevDonem;
                stokno = Properties.Settings.Default.AracBakimSatStokNo;
                tanim = Properties.Settings.Default.AracBakimSatTanim;
                birim = Properties.Settings.Default.AracBakimSatBirim;
                miktar = Properties.Settings.Default.AracBakimSatMiktar;
                butcekodu = Properties.Settings.Default.AracBakimSatButceKodu;

                if (butcekodu == "")
                {
                    MessageBox.Show("SAT Kaydı İçin Gerekli Bilgileri Doldurmadınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime tamamlanmaTarihi = new DateTime(DtTamamlanmaTarihi.Value.Year, DtTamamlanmaTarihi.Value.Month, DtTamamlanmaTarihi.Value.Day, DtTamamlanmaSaati.Value.Hour, DtTamamlanmaSaati.Value.Minute, DtTamamlanmaSaati.Value.Second);
                AracBakim aracBakim = new AracBakim(TxtBakOnarimFirma.Text, tamamlanmaTarihi, TxtSonucAciklama.Text, TxtTutar.Text.ConDouble());

                string mesaj = aracBakimManager.Kapat(aracBakim, isAkisNo);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLogKapat();
                if (TxtTutar.Text=="" || TxtTutar.Text=="0")
                {
                    MessageBox.Show("Harcanan Tutar Bilgisi Girilmediği İçin Sat Oluşturulmayacaktır!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MalzemeKayit();
                    MessageBox.Show("SAT Kaydı Oluşturularak Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dosyaControl = false;
                    TemizleKapat();
                    return;
                }
                
                SatOlustur();
                MalzemeKayit();
                MessageBox.Show("SAT Kaydı Oluşturularak Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dosyaControl = false;
                TemizleKapat();
            }
            
        }
        void MalzemeKayit()
        {
            if (tanim=="YAKIT")
            {
                tanim = "YAKIT (ADBLUE)";
            }
            TeklifsizSat satinAlinacakMalzeme = new TeklifsizSat(stokno, tanim, miktar, birim, TxtTutar.Text.ConDouble(), siparisNo);
            teklifsizSatManager.Add(satinAlinacakMalzeme);
        }
        void SatOlustur()
        {
            siparisNo = Guid.NewGuid().ToString();
            satNo = satNoManager.Add(new SatNo(siparisNo));

            SatDosyasiOlustur();

            SiparisPersonel siparis = siparisPersonelManager.Get("", TxtPersonelKapat.Text);
            if (siparis==null)
            {
                MessageBox.Show("Bu Aracın Zimmetli Personeli İşten Ayrılmıştır! Yinede Sat Oluşuturulacaktır.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                IstenAyrilis ıstenAyrilis = ıstenAyrilisManager.Get(TxtPersonelKapat.Text);
                masrafyerino = ıstenAyrilis.Masyerino;
                personelSiparis = ıstenAyrilis.Siparis;
                unvani = ıstenAyrilis.Isunvani;
                masrafYeri = ıstenAyrilis.Masrafyeri;
            }
            else
            {
                masrafyerino = siparis.Masrafyerino;
                personelSiparis = siparis.Siparis;
                unvani = siparis.Gorevi;
                masrafYeri = siparis.Masrafyeri;
            }
           
            int isAkisNo = TxtIsAkisNo.Text.ConInt();
            SatDataGridview1 satDataGridview1 = new SatDataGridview1(0, isAkisNo, infos[4].ToString(), infos[1].ToString(), infos[2].ToString(), "YOK", "YOK", DateTime.Now, aciklama, siparisNo, TxtPersonelKapat.Text, personelSiparis, unvani, masrafyerino, masrafYeri,
                  string.IsNullOrEmpty(dosya) ? "" : dosya, infos[0].ConInt(), "SAT ONAY", donem, "BAŞARAN", CmbProjeKodu.Text, TxtBakOnarimFirma.Text);
            string mesaj = satDataGridview1Manager.Add(satDataGridview1);
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SatDataGridview1 dataGridview1 = new SatDataGridview1(satNo, butcekodu, "BSRN GN.MDL.SATIN ALMA", "HAVALE/EFT", "BAŞARAN İLERİ TEKNOLOJİ", "RESUL GÜNEŞ", "2017000-1", siparisNo, 0, dosya, "SAT ONAY");
            mesaj = satDataGridview1Manager.Update(dataGridview1);
            if (mesaj !=" SAT Ön Onay İşlemi Başarıyla Tamamlandı.")
            {
                MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            satDataGridview1Manager.TeklifDurum(siparisNo);
            satDataGridview1Manager.DurumGuncelleOnay(siparisNo);
            string yapilanislem = TxtIsAkisNo.Text + " Nolu Araç Bakım Kayıt İçin SAT Oluşturuldu.";
            SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
            satIslemAdimlariManager.Add(satIslemAdimlari);

        }
        void SatDosyasiOlustur()
        {
            string root = @"Z:\DTS";
            string hedef = @"Z:\DTS\SATIN ALMA\";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(hedef))
            {
                Directory.CreateDirectory(hedef);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosya = subdir + satNo + "\\";
            if (!Directory.Exists(dosya))
            {
                Directory.CreateDirectory(dosya);
            }
            //kaynakdosya = dosyaYolu + TxtIsAkisNo.Text;
            foreach (string item in Directory.GetFiles(dosyaYolu, "*.*", SearchOption.TopDirectoryOnly))
            {
                string[] array = item.Split('\\');
                dosya2 = array[6].ToString();
                dosya2 = dosya + dosya2;
                File.Copy(item, dosya2, true);
            }
            /*
            string tamyol = dosyaYolu + kaynakdosya;

            File.Copy(tamyol, dosya + kaynakdosya);*/

        }
        void TemizleKapat()
        {
            TxtIsAkisNo.Clear(); TxtPlakaKapat.Clear(); TxtSiparisNoKapat.Clear(); TxtKullanildigiBolumKapat.Clear(); TxtPersonelKapat.Clear(); TxtAracKmKapat.Clear(); TxtBakNedeniKapat.Clear(); TxtArizaAciklamasi.Clear(); TxtBakOnarimFirma.SelectedValue=-1; TxtSonucAciklama.Clear(); TxtTutar.Clear(); webBrowser1.Navigate("");
            CmbProjeKodu.SelectedValue = "";
        }
        string masrafyerino;
        private void BtnKayitBul_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İş Akış No Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AracBakim aracBakim = aracBakimManager.Get(TxtIsAkisNo.Text.ConInt());
            if (aracBakim == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleKapat();
                return;
            }
            
            TxtPlakaKapat.Text = aracBakim.Plaka;
            TxtSiparisNoKapat.Text = aracBakim.SiparisNo;
            TxtKullanildigiBolumKapat.Text = aracBakim.KullanildigiBolum;
            TxtPersonelKapat.Text = aracBakim.ZimmetliPersonel;
            TxtAracKmKapat.Text = aracBakim.Km.ToString();
            TxtBakNedeniKapat.Text = aracBakim.BakimNedeni;
            DtTlalepTarihiKapat.Value = aracBakim.TalepTarihi;
            DtTalepSaatiKapat.Value = aracBakim.TalepTarihi;
            TxtArizaAciklamasi.Text = aracBakim.ArizaAciklamasi;
            dosyaYolu = aracBakim.DosyaYolu;
            isAkisNo = aracBakim.IsAkisNo;
            webBrowser1.Navigate(dosyaYolu);

        }
        int silinecekId;
        private void BtnBulGun_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNoGun.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İş Akış No Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AracBakim aracBakim = aracBakimManager.Get(TxtIsAkisNoGun.Text.ConInt());
            if (aracBakim == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
                return;
            }
            silinecekId = aracBakim.Id;
            TxtPlakaGun.Text = aracBakim.Plaka;
            TxtMarkaGun.Text = aracBakim.Marka;
            TxtModelYiliGun.Text = aracBakim.ModelYili;
            TxtMotorNoGun.Text = aracBakim.MotorNo;
            TxtSaseNoGun.Text = aracBakim.SaseNo;
            TxtMulkiyetGun.Text = aracBakim.MulkiyetBilgileri;
            TxtSiparisNoGun.Text = aracBakim.SiparisNo;
            DtTahsisTarihiGun.Value = aracBakim.ProjeTahsisTarihi;
            TxtKullanildigiBolumGun.Text = aracBakim.KullanildigiBolum;
            TxtZimmetliPersonleGun.Text = aracBakim.ZimmetliPersonel;
            TxtAracKm.Text = aracBakim.Km.ToString();
            CmbBakNedeniGun.Text = aracBakim.BakimNedeni;
            DtTalepTarihiGun.Value = aracBakim.TalepTarihi;
            DtTalepSaatiGun.Value = aracBakim.TalepTarihi;
            TxtAciklamaGun.Text = aracBakim.ArizaAciklamasi;
            DtTamamlanmaTarihiGun.Value = aracBakim.TamamlanmaTarih;
            DtTamamlanmaSaatiGun.Value = aracBakim.TamamlanmaTarih;
            TxtYapanFirmaGun.Text = aracBakim.BakYapanFirma;
            TxtSonucAciklamaGun.Text = aracBakim.SonucAciklama;
            TxtTutarGun.Text = aracBakim.Tutar.ToString();
            dosyaYoluGun = aracBakim.DosyaYolu;
            webBrowser2.Navigate(dosyaYoluGun);
        }

        private void BtnDosyaEkleGun_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismiGun = openFileDialog2.SafeFileName.ToString();
                alinandosyaGun = openFileDialog2.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(dosyaYoluGun + "\\" + kaynakdosyaismiGun))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismiGun + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosyaGun, dosyaYoluGun + "\\" + kaynakdosyaismiGun);
                fileNames2.Add(alinandosyaGun);
                webBrowser2.Navigate(dosyaYoluGun);
            }
        }
        string teslimPersonel, teslimBolum;
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtPlakaGun.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Bir Kayıt Giriniz!", "Hata", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (CmbTeslimEden.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Aracı Teslim Eden Personel Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Güncellemek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                teslimPersonel = CmbTeslimEden.Text;
                teslimBolum = TxtTeslimEdenGorevi.Text;
                DateTime talepTarihi = new DateTime(DtTalepTarihiGun.Value.Year, DtTalepTarihiGun.Value.Month, DtTalepTarihiGun.Value.Day, DtTalepSaatiGun.Value.Hour, DtTalepSaatiGun.Value.Minute, DtTalepSaatiGun.Value.Second);
                DateTime tamamlanmaTarihi = new DateTime(DtTamamlanmaTarihiGun.Value.Year, DtTamamlanmaTarihiGun.Value.Month, DtTamamlanmaTarihiGun.Value.Day, DtTamamlanmaSaatiGun.Value.Hour, DtTamamlanmaSaatiGun.Value.Minute, DtTamamlanmaSaatiGun.Value.Second);

                AracBakim aracBakim = new AracBakim(TxtIsAkisNoGun.Text.ConInt(), TxtPlakaGun.Text, TxtMarkaGun.Text, TxtModelYiliGun.Text, TxtMotorNoGun.Text, TxtSaseNoGun.Text, TxtMulkiyetGun.Text, TxtSiparisNoGun.Text, DtTahsisTarihiGun.Value, TxtKullanildigiBolumGun.Text, TxtZimmetliPersonleGun.Text, TxtAracKm.Text.ConInt(), CmbBakNedeniGun.Text, talepTarihi, TxtYapanFirmaGun.Text, TxtAciklamaGun.Text, tamamlanmaTarihi, TxtSonucAciklamaGun.Text, TxtTutarGun.Text.ConDouble(), dosyaYoluGun, teslimPersonel, teslimBolum);

                string mesaj = aracBakimManager.Update(aracBakim);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLogGuncelle();
                CreateWordGuncelle();
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
            }
        }
        void CreateWordGuncelle()
        {
            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            //object filePath = "C:\\Users\\MAYıldırım\\Desktop\\Formlar\\DTS_Yurt İçi Görev Formu.docx";
            object filePath = dosyaYoluGun + TxtIsAkisNoGun.Text + ".docx";// taslak yolu

            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["IsAkisNo"].Range.Text = TxtIsAkisNoGun.Text;
            wBookmarks["Plaka"].Range.Text = TxtPlakaGun.Text;
            wBookmarks["Marka"].Range.Text = TxtMarkaGun.Text;
            wBookmarks["ModelYili"].Range.Text = TxtModelYiliGun.Text;
            wBookmarks["MotorNo"].Range.Text = TxtMotorNoGun.Text;
            wBookmarks["SaseNo"].Range.Text = TxtSaseNoGun.Text;
            wBookmarks["MulkiyetBilgileri"].Range.Text = TxtMulkiyetGun.Text;
            wBookmarks["SiparisNo"].Range.Text = TxtSiparisNoGun.Text;
            wBookmarks["ProjeTahsisTarihi"].Range.Text = DtTahsisTarihiGun.Value.ToString("dd/MM/yyyy");
            wBookmarks["KullanildigiBolum"].Range.Text = TxtKullanildigiBolumGun.Text;
            wBookmarks["ZimmetliPersonel"].Range.Text = TxtZimmetliPersonleGun.Text;
            wBookmarks["TalepNedeni"].Range.Text = CmbBakNedeniGun.Text;
            wBookmarks["TalepTarihi"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
            wBookmarks["Km"].Range.Text = TxtAracKm.Text;
            wBookmarks["TalepAciklama"].Range.Text = TxtAciklamaGun.Text;
            wBookmarks["TalepEden"].Range.Text = teslimPersonel;
            wBookmarks["Tarih1"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
            wBookmarks["Saat1"].Range.Text = DateTime.Now.ToString("H:mm:ss");
            wBookmarks["Tarih2"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
            wBookmarks["Saat2"].Range.Text = DateTime.Now.ToString("H:mm:ss");
            wBookmarks["FirmayaTeslimEden"].Range.Text = teslimPersonel;
            wBookmarks["Unvani"].Range.Text = teslimBolum;
            wBookmarks["Tarih3"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");

            wDoc.SaveAs2(dosyaYoluGun + TxtIsAkisNoGun.Text + ".docx");
            wDoc.Close();
            wApp.Quit(false);
        }
    }
}
