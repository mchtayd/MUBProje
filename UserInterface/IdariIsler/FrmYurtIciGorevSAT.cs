using Business.Concreate;
using Entity;
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

namespace UserInterface.IdariIsler
{
    public partial class FrmYurtIciGorevSAT : Form
    {
        SatNoManager satNoManager;
        List<string> fileNames = new List<string>();
        int index, satNo;
        string gerekce, harcamaturu, faturafirma, ilgilikisi, masrafyeri, kaynakdosyaismi, alinandosya, dosya, donem, kaynakdosya;
        bool dosyaControl = false;
        public FrmYurtIciGorevSAT()
        {
            InitializeComponent();
            satNoManager = SatNoManager.GetInstance();
        }

        private void CmbFaturaFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CmbFaturaFirma.SelectedIndex;
            CmbIlgiliKisi.SelectedIndex = index;
            CmbMasYeri.SelectedIndex = index;
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string hedef = @"Z:\DTS\SATIN ALMA\";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            /*string root = @"D:\DTS";
            string hedef = @"D:\DTS\SATIN ALMA\";
            string subdir = @"D:\DTS\SATIN ALMA\SAT DOSYALARI\";*/
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
            string siparisNo = Properties.Settings.Default.SiparisNo.ToString();
            satNo = satNoManager.Add(new SatNo(siparisNo));
            //int outValue = 0;
            /*if (!int.TryParse(satNo, out outValue))
            {
                MessageBox.Show("Klasör No Bulunamadı");
                return;
            }*/
            
            dosya = subdir + satNo +"\\";
            if (!Directory.Exists(dosya))
            {
                Directory.CreateDirectory(dosya);
            }
            //dosya = subdir + satNo;

            kaynakdosya = Properties.Settings.Default.YurtIciYeniAd.ToString() + ".docx";
            string tamyol = Properties.Settings.Default.YurtIciDosyaYolu.ToString() + kaynakdosya;

            File.Copy(tamyol, dosya + kaynakdosya);

            webBrowser1.Navigate(dosya);

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
                Properties.Settings.Default.DosyaYolu = dosya;
                webBrowser1.Navigate(dosya);
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            CmbHarcamaTuru.SelectedValue = 0; CmbFaturaFirma.SelectedValue = 0; Gerekce.Clear(); CmbIlgiliKisi.Text = ""; CmbMasYeri.Text = ""; CmbDonemAy.SelectedValue = ""; CmbDonemYil.SelectedValue = "";
        }

        private void BtnTamamla_Click(object sender, EventArgs e)
        {
            if (CmbHarcamaTuru.Text=="")
            {
                MessageBox.Show("Lütfen Harcama Türü Bilgisini Giriniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (CmbFaturaFirma.Text == "")
            {
                MessageBox.Show("Lütfen Fatura Edilecek Fİrma Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbDonemAy.Text == "" || CmbDonemYil.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Dönem Bilgisini Eksiksiz Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Gerekce.Text == "")
            {
                MessageBox.Show("Lütfen Gerekçe Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dosyaControl==false)
            {
                MessageBox.Show("Lütfen Satın Alma Dosyası İçin Dosya Ekleyiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            gerekce = Gerekce.Text;
            faturafirma = CmbFaturaFirma.Text;
            harcamaturu = CmbHarcamaTuru.Text;
            ilgilikisi = CmbIlgiliKisi.Text;
            masrafyeri = CmbMasYeri.Text;
            donem = CmbDonemAy.Text+ " "+ CmbDonemYil.Text;

            Properties.Settings.Default.Gerekce = gerekce;
            Properties.Settings.Default.FaturaFirma = faturafirma;
            Properties.Settings.Default.HarcamaTuru = harcamaturu;
            Properties.Settings.Default.IlgiliKisi = ilgilikisi;
            Properties.Settings.Default.MasrafYeri = masrafyeri;
            Properties.Settings.Default.YurtIciGorevDonem = donem;
            Properties.Settings.Default.YurtIciGorevSatNo = satNo.ToString();
            Properties.Settings.Default.DosyaYolu = dosya;
            Properties.Settings.Default.Save();
            dosyaControl = false;
            this.Close();
        }

        private void CmbIlgiliKisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CmbMasYeri_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
