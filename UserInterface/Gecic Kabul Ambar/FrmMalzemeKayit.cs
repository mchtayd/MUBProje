using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using Entity.Gecic_Kabul_Ambar;
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

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmMalzemeKayit : Form
    {
        MalzemeKayitManager malzemeKayitManager;
        int id, kaydedildi = 0;
        string dosyayolu, fotoyolu, kaynakdosyaismi1, alinandosya1, yeniad, deneme, foto;
        bool start = true;
        List<string> fileNames = new List<string>();
        public FrmMalzemeKayit()
        {
            InitializeComponent();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageMalzemeKayit"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
            if (BtnDosyaEkle.BackColor== Color.LightGreen)
            {
                if (kaydedildi == 0)
                {
                    DialogResult dr = MessageBox.Show("Girilen Veriler Ve Eklenen Dosya Silinecek Onaylıyor Musunuz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        Directory.Delete(dosyayolu, true);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void FrmMalzemeKayit_Load(object sender, EventArgs e)
        {
            CmbStokNo();
            start = false;
        }

        void CmbStokNo()
        {
            TxtStn.DataSource = malzemeKayitManager.GetList();
            TxtStn.ValueMember = "Id";
            TxtStn.DisplayMember = "Stokno";
            TxtStn.SelectedValue = 0;
        }
        
        void Temizle()
        {
            TxtStn.Text = ""; TxtTanim.Clear(); TxtBirim.Text = ""; TxtTedarikciFirma.Clear(); TxtOnarimDurumu.Text = ""; TxtOnarimYeri.Text="";
            TxtMalzemeTuru.Text=""; CmbMalzemeTakip.Text = ""; TxtRevizyon.Clear(); TxtLot.Clear(); CmbMalKulUst.Text = ""; TxtAciklama.Clear();
            PctBox.ImageLocation = ""; webBrowser1.Navigate("");
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?","Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult== DialogResult.Yes)
            {
                MalzemeKayit malzemeKayit = new MalzemeKayit(TxtStn.Text, TxtTanim.Text, TxtBirim.Text, TxtTedarikciFirma.Text, TxtOnarimDurumu.Text,TxtOnarimYeri.Text, TxtMalzemeTuru.Text, CmbMalzemeTakip.Text, TxtRevizyon.Text, TxtLot.Text, CmbMalKulUst.Text, TxtAciklama.Text, dosyayolu, TxtAlternatifMalzeme.Text);
                string mesaj = malzemeKayitManager.Add(malzemeKayit);
                if (mesaj == "OK")
                {
                    MessageBox.Show("Bilgiler Başarıyla Kaydedidi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    kaydedildi = 1;
                    Temizle();
                    return;
                }
                else
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bilgileri Güncellemek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MalzemeKayit malzemeKayit = new MalzemeKayit(TxtStn.Text, TxtTanim.Text, TxtBirim.Text, TxtTedarikciFirma.Text, TxtOnarimDurumu.Text, TxtOnarimYeri.Text, TxtMalzemeTuru.Text, CmbMalzemeTakip.Text, TxtRevizyon.Text, TxtLot.Text, CmbMalKulUst.Text, TxtAciklama.Text, dosyayolu, TxtAlternatifMalzeme.Text);
                string mesaj = malzemeKayitManager.Update(malzemeKayit, id);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Temizle();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bilgileri Silmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string mesaj = malzemeKayitManager.Delete(id);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Directory.Delete(dosyayolu, true);
                Temizle();
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CmbStokNo();
            Temizle();
            start = false;
        }
        string kaynakdosyaismi, alinandosya;

        private void TxtStn_SelectedValueChanged(object sender, EventArgs e)
        {
            if (start)
            {
                return;
            }
            if (TxtStn.Text == "")
            {
                return;
            }
            id = TxtStn.SelectedValue.ConInt();
            MalzemeKayit personelKayit = malzemeKayitManager.Get(id);
            TxtTanim.Text = personelKayit.Tanim;
            TxtBirim.Text = personelKayit.Birim;
            TxtTedarikciFirma.Text = personelKayit.Tedarikcifirma;
            TxtOnarimDurumu.Text = personelKayit.Malzemeonarimdurumu;
            TxtOnarimYeri.Text = personelKayit.Malzemeonarımyeri;
            TxtMalzemeTuru.Text = personelKayit.Malzemeturu;
            CmbMalzemeTakip.Text = personelKayit.Malzemetakipdurumu;
            TxtRevizyon.Text = personelKayit.Malzemerevizyon;
            TxtLot.Text = personelKayit.Malzemelot;
            CmbMalKulUst.Text = personelKayit.Malzemekul;
            TxtAciklama.Text = personelKayit.Aciklama;
            dosyayolu = personelKayit.Dosyayolu;
            webBrowser1.Navigate(dosyayolu);

            deneme = "\\" + TxtStn.Text + ".jpg";
            foto = personelKayit.Dosyayolu;
            PctBox.ImageLocation = foto + deneme;

        }
        private void BtnFotoEkle_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog2.ShowDialog();
            if (dr == DialogResult.OK)
            {

            }
            fotoyolu = openFileDialog2.FileName;
            kaynakdosyaismi1 = openFileDialog2.SafeFileName.ToString();

            alinandosya1 = openFileDialog2.FileName.ToString();


            if (Path.GetExtension(fotoyolu) == ".jpg" || Path.GetExtension(fotoyolu) == ".png")
            {
                PctBox.ImageLocation = fotoyolu;
                Properties.Settings.Default.FotoYolu = fotoyolu;
                Properties.Settings.Default.Save();

                yeniad = TxtStn.Text + ".jpg";
                if (!Directory.Exists(dosyayolu + "\\" + yeniad))
                {
                    string silinecek = dosyayolu + "\\" + yeniad;
                    File.Delete(silinecek);
                }
                File.Copy(fotoyolu, dosyayolu + "\\" + yeniad);
            }
            else
            {
                MessageBox.Show("Lütfen JPEG veya PNG formatında olan bir dosyayı seçiniz.");
            }
            BtnKaydet.Enabled = true;
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\GEÇİCİ KABUL VE AMBAR\MALZEME KAYIT\";
            //string root = @"C:\STS";
            //string subdir = @"C:\STS\GEÇİCİ KABUL VE AMBAR\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyayolu = subdir + TxtStn.Text;
            Directory.CreateDirectory(dosyayolu);
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
            if (File.Exists(dosyayolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyayolu + "\\" + kaynakdosyaismi);
                fileNames.Add(alinandosya);
                BtnDosyaEkle.BackColor = Color.LightGreen;
                BtnFotoEkle.Enabled = true;
                webBrowser1.Navigate(dosyayolu);
            }
        }
    }
}
