using Business;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace UserInterface.IdariIsler
{
    public partial class FrmGecmisKayit : Form
    {
        AracManager aracManager;
        ZimmetAktarimManager zimmetAktarimManager;
        IsAkisNoManager isAkisNoManager;
        AracBakimManager aracBakimManager;
        IdariIslerLogManager logManager;
        List<string> fileNames = new List<string>();
        public object[] infos;
        int id;
        string dosya, kaynakdosyaismi, alinandosya;
        bool dosyaControl = false;
        public FrmGecmisKayit()
        {
            InitializeComponent();
            aracManager = AracManager.GetInstance();
            zimmetAktarimManager = ZimmetAktarimManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            aracBakimManager = AracBakimManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
        }
        private void FrmGecmisKayit_Load(object sender, EventArgs e)
        {
            IsAkisNo();
        }
        public void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }

        private void BtnBulT_Click(object sender, EventArgs e)
        {
            if (TxtPlaka.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Plaka Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Arac arac = aracManager.Get(TxtPlaka.Text);
            ZimmetAktarim zimmetAktarim = zimmetAktarimManager.AracZimmetBilgileri("%" + TxtPlaka.Text + '%');
            if (arac == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                return;
            }
            id = arac.Id;
            TxtPlaka.Text = arac.Plaka;
            TxtMarkasi.Text = arac.Markasi;
            TxtModel.Text = arac.ModelYili;
            TxtMotorNo.Text = arac.MotorNo;
            TxtSaseNo.Text = arac.SaseNo;
            TxtMulkiyet.Text = arac.MulkiyetBilgileri;
            TxtSiparisNo.Text = arac.Siparisno;
            DtProjeTahsisTarihi.Value = arac.ProjeTahsisTarihi;
            if (zimmetAktarim == null)
            {
                TxtKullanildigiBolum.Text = "";
                TxtZimmetliPersonel.Text = "";
                return;
            }
            TxtKullanildigiBolum.Text = zimmetAktarim.Bolum;
            TxtZimmetliPersonel.Text = zimmetAktarim.PersonelAd;
        }
        void Temizle()
        {
            TxtPlaka.Clear(); TxtMarkasi.Clear(); TxtModel.Clear(); TxtMotorNo.Clear(); TxtSaseNo.Clear(); TxtMulkiyet.Clear(); TxtSiparisNo.Clear();
            TxtKullanildigiBolum.Clear(); TxtZimmetliPersonel.Clear(); CmbBakNedeni.Text = ""; TxtKullanildigiBolum.Clear(); TxtZimmetliPersonel.Clear(); CmbBakNedeni.Text = ""; TxtBakOnarimFirma.Clear(); TxtArizaAciklamasi.Clear(); TxtSonucAciklama.Clear(); TxtTutar.Clear(); webBrowser1.Navigate("");
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            string mesaj = Control();
            if (mesaj!="")
            {
                MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (dosyaControl == false)
            {
                MessageBox.Show("Lütfen Öncelikle Bakımla İlgili Olan Evraklarınızı Taratarak Ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IsAkisNo();
            DateTime tamamlanmaTarihi = new DateTime(DtTamamlanmaTarihi.Value.Year, DtTamamlanmaTarihi.Value.Month, DtTamamlanmaTarihi.Value.Day, DtTamamlanmaSaati.Value.Hour, DtTamamlanmaSaati.Value.Minute, DtTamamlanmaSaati.Value.Second);
            DateTime talepTarihi = new DateTime(DtTalepTarihi.Value.Year, DtTalepTarihi.Value.Month, DtTalepTarihi.Value.Day, DtTalepSaati.Value.Hour, DtTalepSaati.Value.Minute, DtTalepSaati.Value.Second);

            AracBakim aracBakim = new AracBakim(LblIsAkisNo.Text.ConInt(), TxtPlaka.Text, TxtMarkasi.Text, TxtModel.Text, TxtMotorNo.Text, TxtSaseNo.Text, TxtMulkiyet.Text, TxtSiparisNo.Text, DtProjeTahsisTarihi.Value, TxtKullanildigiBolum.Text, TxtZimmetliPersonel.Text,0, CmbBakNedeni.Text, talepTarihi, TxtBakOnarimFirma.Text.ToString(), TxtArizaAciklamasi.Text, tamamlanmaTarihi, TxtSonucAciklama.Text, TxtTutar.Text.ConDouble(), dosya,"","");

            string messege =aracBakimManager.GecmisKayit(aracBakim);
            if (messege!="OK")
            {
                MessageBox.Show(messege,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            CreateLog();
            MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Temizle();
            dosyaControl = false;
            IsAkisNo();
        }
        void CreateLog()
        {
            string sayfa = "ARAÇ BAKIM KAYIT";
            AracBakim aracBakim = aracBakimManager.Get(LblIsAkisNo.Text.ConInt());
            int benzersizid = aracBakim.Id;
            string islem = "ARAÇ BAKIM KAYDI YAPILMIŞTIR.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        string Control()
        {
            if (CmbBakNedeni.Text=="")
            {
                return "Lütfen Bakım Nedeni Bilgisini Seçiniz!";
            }
            if (TxtBakOnarimFirma.Text == "")
            {
                return "Lütfen Onarım Yapan Firma Bilgisini Giriniz!";
            }
            if (TxtArizaAciklamasi.Text == "")
            {
                return "Lütfen Ariza Açıklaması Bilgisini Giriniz!";
            }
            if (TxtSonucAciklama.Text == "")
            {
                return "Lütfen Sonuç Açıklaması Bilgisini Giriniz!";
            }
            if (TxtTutar.Text == "")
            {
                return "Lütfen Tutar Bilgisini Giriniz!";
            }
            return "";
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            CreateDirectory();

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
                dosyaControl = true;
                webBrowser1.Navigate(dosya);
            }
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

        private void TxtTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
    }
}
