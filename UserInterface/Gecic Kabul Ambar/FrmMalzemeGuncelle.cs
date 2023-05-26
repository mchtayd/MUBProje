using Business;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Presentation;
using Entity.BakimOnarim;
using Entity.Gecic_Kabul_Ambar;
using Microsoft.Win32;
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

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmMalzemeGuncelle : Form
    {
        MalzemeManager malzemeManager;
        ComboManager comboManager;
        TeklifFirmalarManager teklifFirmalarManager;
        PersonelKayitManager personelKayitManager;
        MalzemeKayitManager malzemeKayitManager;
        UstTakimManager ustTakimManager;
        public int id = 0;
        bool start = true;
        string yeniStok, dosyayolu, fotoyolu, kaynakdosyaismi1, yeniad, eskiStok, comboAd = "";
        public object[] infos;
        public FrmMalzemeGuncelle()
        {
            InitializeComponent();
            malzemeManager = MalzemeManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            teklifFirmalarManager = TeklifFirmalarManager.GetInstance();
            personelKayitManager = PersonelKayitManager.GetInstance();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
            ustTakimManager = UstTakimManager.GetInstance();
        }

        private void FrmMalzemeGuncelle_Load(object sender, EventArgs e)
        {
            Birim();
            CmbFirmalarLoad();
            OnarimYeri();
            MalzemeTuru();
            TedarikTuru();
            Personeller();
            CmbStokNoUst2();
            CmbStokNoUst();
            MalzemeFill();
            start = false;
        }
        public void Birim()
        {
            CmbBirim.DataSource = comboManager.GetList("BİRİM");
            CmbBirim.ValueMember = "Id";
            CmbBirim.DisplayMember = "Baslik";
            CmbBirim.SelectedValue = 0;
        }
        public void CmbFirmalarLoad()
        {
            CmbTedarikciFirma.DataSource = teklifFirmalarManager.TedarikciFirmalar(true);

            CmbTedarikciFirma.ValueMember = "Id";
            CmbTedarikciFirma.DisplayMember = "Firmaname";
            CmbTedarikciFirma.SelectedValue = -1;
        }
        public void OnarimYeri()
        {
            CmbOnarimYeri.DataSource = comboManager.GetList("ONARIM_YERI");
            CmbOnarimYeri.ValueMember = "Id";
            CmbOnarimYeri.DisplayMember = "Baslik";
            CmbOnarimYeri.SelectedValue = 0;
        }
        public void MalzemeTuru()
        {
            TxtMalzemeTuru.DataSource = comboManager.GetList("MALZEME_TURU");
            TxtMalzemeTuru.ValueMember = "Id";
            TxtMalzemeTuru.DisplayMember = "Baslik";
            TxtMalzemeTuru.SelectedValue = 0;
        }
        public void TedarikTuru()
        {
            CmbTedarikTuru.DataSource = comboManager.GetList("TEDARIK_TURU");
            CmbTedarikTuru.ValueMember = "Id";
            CmbTedarikTuru.DisplayMember = "Baslik";
            CmbTedarikTuru.SelectedValue = 0;
        }
        void Personeller()
        {
            CmbAdSoyad.DataSource = personelKayitManager.PersonelAdSoyad();
            CmbAdSoyad.ValueMember = "Id";
            CmbAdSoyad.DisplayMember = "Adsoyad";
            CmbAdSoyad.SelectedValue = -1;
        }
        
        public void CmbStokNoUst()
        {
            CmbMalKulUst.DataSource = ustTakimManager.GetList();
            CmbMalKulUst.ValueMember = "Id";
            CmbMalKulUst.DisplayMember = "Tanim";
            CmbMalKulUst.SelectedValue = -1;
        }
        public void CmbStokNoUst2()
        {
            CmbSistemStokNo.DataSource = ustTakimManager.GetList();
            CmbSistemStokNo.ValueMember = "Id";
            CmbSistemStokNo.DisplayMember = "StokNo";
            CmbSistemStokNo.SelectedValue = -1;
        }

        void MalzemeFill()
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçtikten sonra sağ tıklayarak Güncelleme işlemini gerçekleştirin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            Malzeme malzeme = malzemeManager.Get2(id);
            eskiStok = malzeme.StokNo;
            TxtStn.Text = eskiStok;
            TxtTanim.Text = malzeme.Tanim;
            CmbBirim.Text= malzeme.Birim;
            CmbTedarikciFirma.Text = malzeme.TedarikciFirma;
            TxtOnarimDurumu.Text = malzeme.OnarimDurumu;
            CmbOnarimYeri.Text = malzeme.OnarimYeri;
            CmbTedarikTuru.Text = malzeme.TedarikTuru;
            TxtMalzemeTuru.Text = malzeme.ParcaSinifi;
            CmbMalzemeTakip.Text = malzeme.TakipDurumu;
            TxtAlternatifMalzeme.Text = malzeme.AlternatifParca;
            CmbMalKulUst.Text = malzeme.SistemTanimi;
            CmbSistemStokNo.Text = malzeme.SistemStokNo;
            CmbAdSoyad.Text = malzeme.SistemSorumlusu;
            TxtAciklama.Text = malzeme.Aciklama;
            string dosyaYolu = malzeme.DosyaYolu;

            string fileName = "";
            
            DirectoryInfo di = new DirectoryInfo(dosyaYolu);
            
            foreach (FileInfo fi in di.GetFiles())
            {
                if (fi.Name != "." && fi.Name != ".." && fi.Name != "Thumbs.db")
                {
                    fileName = fi.Name;
                }
            }
            string foto = dosyaYolu + "\\" + fileName;

            Image image;
            image = Image.FromFile(foto);
            PctBox.Image = image;

            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void CmbMalKulUst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            id = CmbMalKulUst.SelectedValue.ConInt();
            UstTakim ustTakim = ustTakimManager.Get(id);
            if (ustTakim == null)
            {
                CmbSistemStokNo.SelectedIndex = -1;
                return;
            }
            CmbSistemStokNo.Text = ustTakim.StokNo;
        }

        private void BtnTedarilciFirmaEkle_Click(object sender, EventArgs e)
        {
            FrmTedarikciFirmaBilgileri frmTedarikciFirmaBilgileri = new FrmTedarikciFirmaBilgileri();
            frmTedarikciFirmaBilgileri.ShowDialog();
        }

        private void BtnOnarimYeriEkle_Click(object sender, EventArgs e)
        {
            comboAd = "ONARIM_YERI";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnTedarikTürüEkle_Click(object sender, EventArgs e)
        {
            comboAd = "TEDARIK_TURU";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnMalzemeTuruEkle_Click(object sender, EventArgs e)
        {
            comboAd = "MALZEME_TURU";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void bTN_Click(object sender, EventArgs e)
        {
            FrmUstTakim frmUstTakimEkle = new FrmUstTakim();
            frmUstTakimEkle.ShowDialog();
        }

        private void BtnBirimEkle_Click(object sender, EventArgs e)
        {
            comboAd = "BİRİM";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Malzeme bilgilerini güncellemek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                Malzeme malzeme = new Malzeme(TxtStn.Text, TxtTanim.Text, CmbBirim.Text, CmbTedarikciFirma.Text, TxtOnarimDurumu.Text, CmbOnarimYeri.Text, CmbTedarikTuru.Text, TxtMalzemeTuru.Text, TxtAlternatifMalzeme.Text, TxtAciklama.Text, CmbSistemStokNo.Text, CmbMalKulUst.Text, CmbAdSoyad.Text, infos[1].ToString(), CmbMalzemeTakip.Text);
                string mesaj = malzemeManager.Update(malzeme, eskiStok);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                FrmMalzemeKayitIzleme frmAnaSayfa = (FrmMalzemeKayitIzleme)Application.OpenForms["FrmMalzemeKayitIzleme"];
                frmAnaSayfa.DataDisplay();
                MessageBox.Show("Bilgiler başarıyla güncellenmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void TxtOnarimDurumu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TxtOnarimDurumu.SelectedIndex == 1)
            {
                CmbOnarimYeri.Text = "ONARIM YOK";
                CmbOnarimYeri.Enabled = false;
            }
            if (TxtOnarimDurumu.SelectedIndex == 0)
            {
                CmbOnarimYeri.SelectedIndex = -1;
                CmbOnarimYeri.Enabled = true;
            }
        }

        private void CmbSistemStokNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            id = CmbSistemStokNo.SelectedValue.ConInt();
            UstTakim ustTakim = ustTakimManager.Get(id);
            if (ustTakim == null)
            {
                CmbMalKulUst.SelectedIndex= -1;
                return;
            }
            CmbMalKulUst.Text = ustTakim.Tanim;
        }


        private void BtnStokAl_Click(object sender, EventArgs e)
        {
            Malzeme malzemeKayit = malzemeManager.MalzemeSonStok();
            string sonStok = malzemeKayit.StokNo; //UGS-0000-1167
            string[] array = sonStok.Split('-');
            string parca = array[1].ToString();
            if (parca.Length == 3)
            {
                parca = "0000";
            }
            int sayi = array[2].ConInt() + 1;

            yeniStok = array[0].ToString() + "-" + parca + "-" + sayi;

            TxtStn.Text = yeniStok;
        }

        private void BtnFotoEkle_Click(object sender, EventArgs e)
        {
            if (TxtStn.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Stok No Bilgisini Yazınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\GEÇİCİ KABUL VE AMBAR\MALZEME KAYIT\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyayolu = subdir + TxtStn.Text;

            if (!Directory.Exists(dosyayolu))
            {
                Directory.CreateDirectory(dosyayolu);
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fotoyolu = openFileDialog1.FileName.ToString();
                kaynakdosyaismi1 = openFileDialog1.SafeFileName.ToString();
            }

            if (Path.GetExtension(fotoyolu) == ".jpg" || Path.GetExtension(fotoyolu) == ".png" || Path.GetExtension(fotoyolu) == ".jpeg")
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
                MessageBox.Show("Lütfen JPEG veya PNG formatında olan bir dosyayı seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
