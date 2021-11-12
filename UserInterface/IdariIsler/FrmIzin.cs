using Business;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity;
using Entity.IdariIsler;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;
using Application = Microsoft.Office.Interop.Word.Application;

namespace UserInterface.IdariIsler
{
    public partial class FrmIzin : Form
    {
        SiparislerManager siparislerManager;
        SiparisPersonelManager siparisPersonelManager;
        IzinManager izinManager;
        IdariIslerLogManager logManager;
        IsAkisNoManager isAkisNoManager;
        PersonelKayitManager kayitManager;
        List<string> fileNames = new List<string>();
        List<string> fileNamesGun = new List<string>();
        bool start = true, start2 = true, start3 = true, start4 = true;
        string siparis, satno, dosya, dosyagun, kaynakdosyaismi, alinandosya;
        int sayi, index, sonucGun, sonucSaat, toplamsaat, kalansaat, kalangun;
        public object[] infos;
        public FrmIzin()
        {
            InitializeComponent();
            siparislerManager = SiparislerManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            izinManager = IzinManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageIzin"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void FrmIzin_Load(object sender, EventArgs e)
        {
            //Siparisler();
            //Siparis();
            IsAkisNo();
            Personeller1();
            Personeller2();
            start = false;
            start2 = false;
            start3 = false;
            start4 = false;
        }
        public void YenilenecekVeri()
        {
            //Siparisler();
            //Siparis();
            Personeller1();
            Personeller2();
            IsAkisNo();
        }
        void Personeller1()
        {
            CmbPersonel.DataSource = kayitManager.PersonelAdSoyad();
            CmbPersonel.ValueMember = "Id";
            CmbPersonel.DisplayMember = "Adsoyad";
            CmbPersonel.SelectedValue = -1;
        }
        void Personeller2()
        {
            CmbAd.DataSource = kayitManager.PersonelAdSoyad();
            CmbAd.ValueMember = "Id";
            CmbAd.DisplayMember = "Adsoyad";
            CmbAd.SelectedValue = -1;
        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        /*void Siparisler()
        {
            CmbSiparisler.DataSource = siparislerManager.GetList();
            CmbSiparisler.ValueMember = "Id";
            CmbSiparisler.DisplayMember = "Siparisno";
            CmbSiparisler.SelectedValue = 0;
        }
        void Siparis()
        {
            CmbSiparis.DataSource = siparislerManager.GetList();
            CmbSiparis.ValueMember = "Id";
            CmbSiparis.DisplayMember = "Siparisno";
            CmbSiparis.SelectedValue = 0;
        }
        */
        void SiparisIsimlerDoldur()
        {
            CmbPersonel.DataSource = siparisPersonelManager.GetList(siparis);
            CmbPersonel.ValueMember = "Id";
            CmbPersonel.DisplayMember = "Personel";
            CmbPersonel.SelectedValue = 0;
            start = true;
        }
        void SiparisIsimlerDoldurGuncelle()
        {
            CmbAd.DataSource = siparisPersonelManager.GetList(siparis);
            CmbAd.ValueMember = "Id";
            CmbAd.DisplayMember = "Personel";
            CmbAd.SelectedValue = 0;
            start2 = true;
        }

        private void CmbSiparisler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start)
            {
                if (start2 == true)
                {
                    return;
                }
            }
            siparis = CmbSiparisler.Text;
            SiparisIsimlerDoldur();
            TxtGorevi.Clear();
            TxtMasrafyeriNo.Clear();
            TxtBolum.Clear();
            start = true;
        }

        private void CmbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbPersonel.Text);
            CmbSiparisler.Text = siparis.Siparis;
            TxtMasrafyeriNo.Text = siparis.Masrafyerino;
            TxtBolum.Text = siparis.Masrafyeri;
            TxtGorevi.Text = siparis.Gorevi;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            /*if (CmbDokumanTuru.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İZİN DOKÜMAN TÜRÜ Bilgisini Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            if (BtnDosyaEkle.BackColor != Color.LightGreen)
            {
                MessageBox.Show("İzin Formunun Taratılmış Halini Eklemediniz! Lütfen Dosya Ekleyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IsAkisNo();
                DateTime basTarihi = new DateTime(DtBasTarihi.Value.Year, DtBasTarihi.Value.Month, DtBasTarihi.Value.Day, DtBasSaati.Value.Hour, DtBasSaati.Value.Minute, DtBasSaati.Value.Second);
                DateTime bitTarihi = new DateTime(DtBitTarihi.Value.Year, DtBitTarihi.Value.Month, DtBitTarihi.Value.Day, DtBitSaati.Value.Hour, DtBitSaati.Value.Minute, DtBitSaati.Value.Second);

                TimeSpan SonucGun = bitTarihi - basTarihi;

                IzinSuresi();
                //CreateDirectory();
                Izin ızin = new Izin(LblIsAkisNo.Text.ConInt(), CmbIzınKategori.Text, CmbIzınTuru.Text, CmbSiparisler.Text, CmbPersonel.Text, TxtGorevi.Text, TxtMasrafyeriNo.Text, TxtBolum.Text, TxtIzinNedeni.Text, basTarihi, bitTarihi, izinsuresi, dosya);
                string mesaj = izinManager.Add(ızin);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLog();
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                BtnDosyaEkle.BackColor = Color.Transparent;
            }

        }
        void CreateDirectory()
        {
            /*string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\KONAKLAMA\";*/

            string root = @"D:\DTS";
            string subdir = @"D:\DTS\İDARİ İŞLER\";
            string anadosya = @"D:\DTS\İDARİ İŞLER\İZİN\";
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
        void CreateLog()
        {
            string sayfa = "İZİN";
            Izin gorev = izinManager.Get(LblIsAkisNo.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "İZİN KAYDI OLUŞTURULDU.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        object filePath;
        string izinsuresi;
        void CreateWord()
        {

            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            if (index == 0)
            {
                filePath = "C:\\Users\\MAYıldırım\\Desktop\\WordTaslak\\GÜNLÜK İZİN- MGÜB.docx"; // taslak yolu
                Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
                wDoc.Activate();

                Bookmarks wBookmarks = wDoc.Bookmarks;
                wBookmarks["AdSoyad"].Range.Text = CmbPersonel.Text;
                wBookmarks["Departman"].Range.Text = "MÜB PROJE DİREKTÖRLÜĞÜ";
                wBookmarks["Unvani"].Range.Text = TxtGorevi.Text;
                wBookmarks["CikisTarihi"].Range.Text = DtBasTarihi.Value.ToString("dd/MM/yyyy");
                wBookmarks["DonusTarihi"].Range.Text = DtBitTarihi.Value.ToString("dd/MM/yyyy");
                wBookmarks["IzinSuresi"].Range.Text = izinsuresi;
                wBookmarks["Adsoyad2"].Range.Text = CmbPersonel.Text;

                wDoc.SaveAs2(dosya + LblIsAkisNo.Text + ".docx");
                wDoc.Close();
                wApp.Quit(false);
            }
            if (index == 1)
            {
                filePath = "C:\\Users\\MAYıldırım\\Desktop\\WordTaslak\\GÜNLÜK İZİN- MGÜB.docx"; // taslak yolu
                Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
                wDoc.Activate();

                Bookmarks wBookmarks = wDoc.Bookmarks;
                wBookmarks["AdSoyad"].Range.Text = CmbPersonel.Text;
                wBookmarks["Departman"].Range.Text = "MÜB PROJE DİREKTÖRLÜĞÜ";
                wBookmarks["Unvani"].Range.Text = TxtGorevi.Text;
                wBookmarks["CikisTarihi"].Range.Text = DtBasTarihi.Value.ToString("dd/MM/yyyy");
                wBookmarks["DonusTarihi"].Range.Text = DtBitTarihi.Value.ToString("dd/MM/yyyy");
                wBookmarks["IzinSuresi"].Range.Text = izinsuresi;
                wBookmarks["Adsoyad2"].Range.Text = CmbPersonel.Text;

                wDoc.SaveAs2(dosya + LblIsAkisNo.Text + ".docx");
                wDoc.Close();
                wApp.Quit(false);
            }
            /*if (index == 2)
            {

            }*/
        }

        private void BtnDosyaEkleGun_Click(object sender, EventArgs e)
        {
            if (dosyagun == "")
            {
                MessageBox.Show("Dosya Yolu Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi = openFileDialog2.SafeFileName.ToString();
                alinandosya = openFileDialog2.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            File.Copy(alinandosya, dosyagun + "\\" + kaynakdosyaismi);
            fileNamesGun.Add(alinandosya);
            BtnDosyaEkleGun.BackColor = Color.LightGreen;
            webBrowser2.Navigate(dosyagun);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtIzinGuncelle.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Bir İş Akış Numarası Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(TxtIzinGuncelle.Text + " Nolu Personel İzin Kaydını Silmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = izinManager.Delete(TxtIzinGuncelle.Text.ConInt());
                Directory.Delete(dosyagun, true);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Silme İşlemi Başarıyla Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
            }
        }
        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\İZİN\";

            /*string root = @"D:\DTS";
            string subdir = @"D:\DTS\İDARİ İŞLER\";
            string anadosya = @"D:\DTS\İDARİ İŞLER\İZİN\";*/
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
            if (!Directory.Exists(dosya))
            {
                Directory.CreateDirectory(dosya);
            }

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
            if (File.Exists(dosya + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosya + "\\" + kaynakdosyaismi);
                fileNames.Add(alinandosya);
                BtnDosyaEkle.BackColor = Color.LightGreen;
                webBrowser1.Navigate(dosya);
            }
        }

        void IzinSuresi()
        {
            DateTime bTarih = DtBasTarihi.Value;
            DateTime kTarih = DtBitTarihi.Value;
            TimeSpan SonucGun = kTarih - bTarih;

            DateTime bSaat = DtBasSaati.Value;
            DateTime kSaat = DtBitSaati.Value;
            TimeSpan SonucSaat = kSaat - bSaat;

            sonucGun = SonucGun.TotalDays.ConInt();
            sonucSaat = SonucSaat.TotalHours.ConInt();
            if (sonucGun > 0)
            {
                toplamsaat = sonucGun * 24;
            }
            toplamsaat += sonucSaat;
            if (toplamsaat < 24)
            {
                izinsuresi = toplamsaat.ToString() + " Saat";
            }
            else
            {
                kalansaat = (toplamsaat % 24).ConInt();
                kalangun = (toplamsaat - kalansaat) / 24;
                if (kalansaat == 0)
                {
                    izinsuresi = kalangun.ToString() + " Gün";
                    return;
                }
                izinsuresi = kalangun.ToString() + " Gün, " + kalansaat.ToString() + " Saat";
            }

            /*DateTime bTarih = DtBasTarihi.Value;
            DateTime kTarih = DtBitTarihi.Value;
            TimeSpan Sonuc = kTarih - bTarih;
            int gun = Sonuc.TotalDays.ConInt();
            izinSuresi = gun.ToString() + " Gün";*/
        }
        private void BtnBul_Click(object sender, EventArgs e)
        {

            if (TxtIzinGuncelle.MaskFull) // true false dondurur şu an true ise ife giricek false ise girmicek.
            {

                Izin ızin = izinManager.Get(TxtIzinGuncelle.Text.ConInt());
                if (ızin == null)
                {
                    MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TemizleGuncelle();
                    return;
                }
                dosyagun = ızin.Dosyayolu;
                CmbKategori.Text = ızin.Izinkategori;
                CmbTuru.Text = ızin.Izinturu;
                CmbSiparis.Text = ızin.Siparisno;
                CmbAd.Text = ızin.Adsoyad;
                TxtMasrafyeri.Text = ızin.Masrafyerino;
                TxtBolumu.Text = ızin.Bolum;
                TxtNedeni.Text = ızin.Izınnedeni;
                DtTarihBaslama.Value = ızin.Bastarihi;
                DtTarihBitis.Value = ızin.Bittarihi;
                webBrowser2.Navigate(dosyagun);
                BtnDosyaEkleGun.BackColor = Color.Transparent;
                return;
            }
            MessageBox.Show("Lütfen 9 haneli İş Akiş Numarasını Eksiksiz Girinz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            TemizleGuncelle();
        }

        void Temizle()
        {
            IsAkisNo(); CmbIzınKategori.Text = ""; CmbIzınTuru.Text = ""; CmbSiparisler.Text = ""; CmbPersonel.Text = ""; TxtMasrafyeriNo.Text = "";
            TxtBolum.Text = ""; TxtIzinNedeni.Text = ""; TxtGorevi.Clear(); webBrowser1.Navigate("");
        }
        void TemizleGuncelle()
        {
            TxtIzinGuncelle.Clear(); CmbKategori.Text = ""; CmbTuru.Text = ""; CmbSiparis.Text = ""; CmbAd.Text = ""; TxtMasrafyeri.Text = ""; TxtBolumu.Text = "";
            TxtNedeni.Text = ""; TxtGoreviGun.Clear(); webBrowser2.Navigate("");
        }

        private void TxtTmizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void CmbDokumanTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CmbDokumanTuru.SelectedIndex.ConInt();
        }


        private void Sil_Click(object sender, EventArgs e)
        {
            TemizleGuncelle();
        }

        private void CmbAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start3 == true)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbAd.Text);
            CmbSiparis.Text = siparis.Siparis;
            TxtMasrafyeri.Text = siparis.Masrafyerino;
            TxtBolumu.Text = siparis.Bolum;
            TxtGoreviGun.Text = siparis.Gorevi;
        }

        private void CmbSiparis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start3)
            {
                if (start4 == true)
                {
                    return;
                }
            }
            siparis = CmbSiparis.Text;
            SiparisIsimlerDoldurGuncelle();
            TxtGoreviGun.Clear();
            TxtMasrafyeri.Clear();
            TxtBolumu.Clear();
            start3 = true;
        }

        private void Guncelle_Click(object sender, EventArgs e)
        {
            if (TxtIzinGuncelle.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İş Akış Numarası Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Güncellemek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IzinSuresiGuncelle();
                Izin ızin = new Izin(TxtIzinGuncelle.Text.ConInt(), CmbKategori.Text, CmbTuru.Text, CmbSiparis.Text, CmbAd.Text, TxtGoreviGun.Text, TxtMasrafyeri.Text, TxtBolumu.Text, TxtNedeni.Text, DtTarihBaslama.Value, DtTarihBitis.Value, izinsuresi, dosyagun);
                string mesaj = izinManager.Update(ızin, TxtIzinGuncelle.Text.ConInt());
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLogGuncelle();
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
                BtnDosyaEkleGun.BackColor = Color.Transparent;
            }

        }
        void CreateLogGuncelle()
        {
            string sayfa = "İZİN";
            Izin gorev = izinManager.Get(TxtIzinGuncelle.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "İZİN BİLGİLERİ GÜNCELLENDİ.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void IzinSuresiGuncelle()
        {
            DateTime bTarih = DtTarihBaslama.Value;
            DateTime kTarih = DtTarihBitis.Value;
            TimeSpan SonucGun = kTarih - bTarih;

            DateTime bSaat = DtBaslamaSaati.Value;
            DateTime kSaat = DtBitisSaati.Value;
            TimeSpan SonucSaat = kSaat - bSaat;

            sonucGun = SonucGun.TotalDays.ConInt();
            sonucSaat = SonucSaat.TotalHours.ConInt();
            if (sonucGun > 0)
            {
                toplamsaat = sonucGun * 24;
            }
            toplamsaat += sonucSaat;
            if (toplamsaat < 24)
            {
                izinsuresi = toplamsaat.ToString() + " Saat";
            }
            else
            {
                kalansaat = (toplamsaat % 24).ConInt();
                kalangun = (toplamsaat - kalansaat) / 24;
                if (kalansaat == 0)
                {
                    izinsuresi = kalangun.ToString() + " Gün";
                    return;
                }
                izinsuresi = kalangun.ToString() + " Gün, " + kalansaat.ToString() + " Saat";
            }

            /*DateTime bTarih = DtTarihBaslama.Value;
            DateTime kTarih = DtTarihBitis.Value;
            TimeSpan Sonuc = kTarih - bTarih;
            int gun = Sonuc.TotalDays.ConInt();
            izinSuresiGun = gun.ToString() + " Gün";*/
        }
    }
}
