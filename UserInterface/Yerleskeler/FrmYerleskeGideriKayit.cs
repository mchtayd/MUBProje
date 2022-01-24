using Business;
using Business.Concreate;
using Business.Concreate.Yerleskeler;
using DataAccess.Concreate;
using Entity;
using Entity.Yerleskeler;
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

namespace UserInterface.Yerleskeler
{
    public partial class FrmYerleskeGideriKayit : Form
    {
        bool dosyaKontrol;
        string isAkisNo, dosyaYolu, kaynakdosyaismi, alinandosya, siparisNo, isleAdimi;
        public object[] infos;
        List<string> fileNames = new List<string>();

        KiraManager kiraManager;
        YerleskeManager yerleskeManager;
        IsAkisNoManager isAkisNoManager;
        SatDataGridview1Manager satDataGridview1Manager;
        ComboManager comboManager;
        public FrmYerleskeGideriKayit()
        {
            InitializeComponent();
            kiraManager = KiraManager.GetInstance();
            yerleskeManager = YerleskeManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            comboManager = ComboManager.GetInstance();
        }

        private void FrmYerleskeGideriKayit_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            YerleskeAdlari();
            ComboProje();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageYerleskeGideriKayit"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        public void ComboProje()
        {
            CmbProjeKodu.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProjeKodu.ValueMember = "Id";
            CmbProjeKodu.DisplayMember = "Baslik";
            CmbProjeKodu.SelectedValue = 0;
        }

        private void TxtTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }

        void YerleskeAdlari()
        {
            CmbYerleskeAdi.DataSource = kiraManager.GetList();
            CmbYerleskeAdi.ValueMember = "Id";
            CmbYerleskeAdi.DisplayMember = "YerleskeAdi";
            CmbYerleskeAdi.SelectedValue = 0;
        }


        private void CmbGiderTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbYerleskeAdi.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Yerleşke Adı Bilgisini Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            Yerleske yerleske = yerleskeManager.YerleskeBiigiCek(CmbYerleskeAdi.Text, CmbGiderTuru.Text);

            if (yerleske == null)
            {
                MessageBox.Show("Abonelik Bilgilerine Ulşılamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TxtAdres.Text = yerleske.YerleskeAdresi;
            TxtHizmetAlinanKurum.Text = yerleske.HizmetAlinanKurum;
            TxtTesisatNo.Text = yerleske.AboneTesisatNo;
        }

        private void BtnSatKaydet_Click(object sender, EventArgs e)
        {
            if (dosyaKontrol)
            {
                MessageBox.Show("Lütfen Öncelikle SAT İle İlgili Dosyayı Ekleyiniz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (CmbDonemAy.Text == "" || CmbDonemYil.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Dönem Bilgisini Eksiksiz Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Bilgileri Kaydederek SAT Oluşturmak İstiyor Musunuz?","Soru",MessageBoxButtons.OK,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string donem = CmbDonemAy.Text + " " + CmbDonemYil.Text;
                siparisNo = Guid.NewGuid().ToString();
                string gerekce = donem + " DÖNEMİNE AİT "+ CmbYerleskeAdi.Text + " " + CmbGiderTuru.Text + " FATURASIDIR.";
                isleAdimi = "SAT BAŞLATMA ONAYI";

                SatDataGridview1 satDataGridview1 = new SatDataGridview1(0, LblIsAkisNo.Text.ConInt(), infos[4].ToString(), infos[1].ToString(), infos[2].ToString(), "", "", DtgTarih.Value, gerekce, siparisNo, "", "", "", "", "",
                  string.IsNullOrEmpty(dosyaYolu) ? "" : dosyaYolu, infos[0].ConInt(), isleAdimi, donem, "BAŞARAN", CmbProjeKodu.Text, TxtHizmetAlinanKurum.Text);


            }

        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            IsAkisNo();
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\GEÇİCİ SAT DOSYALARI\";

            isAkisNo = LblIsAkisNo.Text;

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
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
                dosyaKontrol = true;
            }

        }
    }
}
