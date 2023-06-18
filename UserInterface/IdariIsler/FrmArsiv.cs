using Business;
using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarim;
using Entity.IdariIsler;
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
using UserInterface.Ana_Sayfa;
using UserInterface.STS;

namespace UserInterface.IdariIsler
{
    public partial class FrmArsiv : Form
    {
        IsAkisNoManager isAkisNoManager;
        SatTalebiDoldurManager satTalebiDoldurManager;
        ArsivTutanakManager arsivTutanakManager;
        ComboManager comboManager;
        BolgeKayitManager bolgeKayitManager;
        List<string> fileNames = new List<string>();
        bool dosyaEkle = false;
        public FrmArsiv()
        {
            InitializeComponent();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            satTalebiDoldurManager = SatTalebiDoldurManager.GetInstance();
            arsivTutanakManager = ArsivTutanakManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
        }

        private void FrmArsiv_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            UsBolgeleri();
            DosyaTuru();
            SistemCihaz();
        }
        
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageArsiv"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        public void DosyaTuru()
        {
            CmbDosyaTuru.DataSource = comboManager.GetList("DOSYA_TURU");
            CmbDosyaTuru.ValueMember = "Id";
            CmbDosyaTuru.DisplayMember = "Baslik";
            CmbDosyaTuru.SelectedValue = 0;
        }
        public void SistemCihaz()
        {
            CmbCihaz.DataSource = comboManager.GetList("SİSTEM CİHAZ");
            CmbCihaz.ValueMember = "Id";
            CmbCihaz.DisplayMember = "Baslik";
            CmbCihaz.SelectedValue = 0;
        }
        void UsBolgeleri()
        {
            Usbolgesi.DataSource = bolgeKayitManager.GetList();
            Usbolgesi.ValueMember = "Id";
            Usbolgesi.DisplayMember = "BolgeAdi";
            Usbolgesi.SelectedValue = -1;
        }
        string dosyaYolu = "", isAkisNo = "", kaynakdosyaismi, alinandosya, comboAd;

        private void BtnSistemCihazEkle_Click(object sender, EventArgs e)
        {
            comboAd = "SİSTEM CİHAZ";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }
        int index;
        private void CmbIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CmbIslemTuru.SelectedIndex;
            if (index==0)
            {
                TxtIsAkisNo.Visible = false;
                BtnBul.Visible = false;
                BtnGuncelle.Visible = false;
            }
            if (index == 1)
            {
                TxtIsAkisNo.Visible = true;
                BtnBul.Visible = true;
                BtnGuncelle.Visible = true;
            }

        }
        int id;
        private void BtnBul_Click(object sender, EventArgs e)
        {
            ArsivTutanak arsivTutanak = arsivTutanakManager.Get(TxtIsAkisNo.Text.ConInt());
            if (arsivTutanak == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                return;
            }
            id = arsivTutanak.Id;
            CmbDosyaTuru.Text = arsivTutanak.DosyaTuru;
            Usbolgesi.Text = arsivTutanak.BolgeAdi;
            CmbCihaz.Text = arsivTutanak.SistemCihaz;
            DtDosyaTarihi.Value = arsivTutanak.DosyaTarihi;
            TtxDosyaIcerigi.Text = arsivTutanak.DosyaIcerigi;
            dosyaYolu = arsivTutanak.DosyaYolu;
            webBrowser1.Navigate(dosyaYolu);
            CmbBulLok.Text = arsivTutanak.BulunduguLok;
            CmbKlasorNo.Text = arsivTutanak.KlasorNo;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNo.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Geçerli Bir İş Akış Numarası Giriniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ArsivTutanak arsivTutanak = new ArsivTutanak(id, TxtIsAkisNo.Text.ConInt(),CmbDosyaTuru.Text, Usbolgesi.Text, CmbCihaz.Text, DtDosyaTarihi.Value, TtxDosyaIcerigi.Text, dosyaYolu, CmbBulLok.Text, CmbKlasorNo.Text);

                string mesaj = arsivTutanakManager.Update(arsivTutanak);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
            }
        }

        private void BtnDosyaTuruEkle_Click(object sender, EventArgs e)
        {
            comboAd = "DOSYA_TURU";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (dosyaEkle == false)
            {
                MessageBox.Show("Lütfen Öncelikle Dosya Ekleyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr ==DialogResult.Yes)
            {
                IsAkisNo();
                ArsivTutanak arsivTutanak = new ArsivTutanak(LblIsAkisNo.Text.ConInt(), CmbDosyaTuru.Text, Usbolgesi.Text, CmbCihaz.Text, DtDosyaTarihi.Value, TtxDosyaIcerigi.Text, dosyaYolu, CmbBulLok.Text, CmbKlasorNo.Text);

                string mesaj = arsivTutanakManager.Add(arsivTutanak);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Temizle();
                dosyaEkle = false;
            }
        }

        void Temizle()
        {
            IsAkisNo();
            CmbDosyaTuru.Text = ""; Usbolgesi.SelectedValue = ""; CmbCihaz.Text = ""; TtxDosyaIcerigi.Clear(); CmbBulLok.Text = "";
            CmbKlasorNo.Clear(); webBrowser1.Navigate("");
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            
            IsAkisNo();
            isAkisNo = LblIsAkisNo.Text;
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\ARŞİV\";
            string subdir2 = @"Z:\DTS\İDARİ İŞLER\ARŞİV\TUTANAKLAR\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(subdir2))
            {
                Directory.CreateDirectory(subdir2);
            }

            dosyaYolu = subdir + isAkisNo;
            Directory.CreateDirectory(subdir + isAkisNo);

            //Directory.CreateDirectory(subdir + isAkisNo);
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
                webBrowser1.Navigate(dosyaYolu);
                dosyaEkle = true;
            }
        }
    }
}
