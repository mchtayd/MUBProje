using Business;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity;
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
using UserInterface.STS;

namespace UserInterface.IdariIsler
{
    public partial class FrmEvrakKayit : Form
    {
        EvrakKayitManager kayitManager;
        IsAkisNoManager isAkisNoManager;
        IdariIslerLogManager logManager;
        string dosyaYolu, kaynakdosyaismi, alinandosya, dosyaYoluGun;
        public object[] infos;
        int id;
        bool dosyaControl = false;
        List<string> fileNames = new List<string>();
        public FrmEvrakKayit()
        {
            InitializeComponent();
            kayitManager = EvrakKayitManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
        }

        private void FrmEvrakKayit_Load(object sender, EventArgs e)
        {
            IsAkisNo();
        }
        public void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }

        private void CmbYaziTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbYaziTuru.SelectedIndex==0)
            {
                groupBox1.Enabled = true;
                TxtNeredenGeldigi.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = false;
                TxtNeredenGeldigi.Enabled = true;
                TemizleGelenGiden();
            }
        }
        void TemizleGelenGiden()
        {
            CmbGeregi.Text = ""; CmbBilgi1.Text = ""; CmbBilgi2.Text = ""; CmbBilgi3.Text = ""; CmbBilgi4.Text = ""; CmbBilgi5.Text = "";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (dosyaControl==false)
            {
                MessageBox.Show("Lütfen Öncelikle Yazıyı Ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                IsAkisNo();
                EvrakKayit evrakKayit = new EvrakKayit(LblIsAkisNo.Text.ConInt(), CmbYaziTuru.Text, CmbCinsi.Text, TxtNeredenGeldigi.Text, TxtSayiNo.Text, DtTarih.Value, TxtKonu.Text, TxtEkSayisi.Text, CmbGeregi.Text, CmbBilgi1.Text, CmbBilgi2.Text, CmbBilgi3.Text, CmbBilgi4.Text, CmbBilgi5.Text,dosyaYolu);
                string mesaj = kayitManager.Add(evrakKayit);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                CreateLog();
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                IsAkisNo();
                dosyaControl = false;
                Temizle();
            }
        }
        void CreateLog()
        {
            string sayfa = "EVRAK KAYIT";
            EvrakKayit arac = kayitManager.Get(LblIsAkisNo.Text.ConInt());
            int benzersizid = arac.Id;
            string islem = "EVRAK KAYIT İŞLEMİ";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogGun()
        {
            string sayfa = "EVRAK KAYIT";
            EvrakKayit arac = kayitManager.Get(TxtIsAkisNo.Text.ConInt());
            int benzersizid = arac.Id;
            string islem = "EVRAK GÜNCELLENMİŞTİR.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void Temizle()
        {
            CmbYaziTuru.Text = ""; CmbCinsi.Text = ""; TxtNeredenGeldigi.Clear(); TxtSayiNo.Clear(); TxtKonu.Clear(); TxtEkSayisi.Clear();
            CmbGeregi.Text = ""; CmbBilgi1.Text = ""; CmbBilgi2.Text = ""; CmbBilgi3.Text = ""; CmbBilgi4.Text = ""; CmbBilgi5.Text = "";
            webBrowser1.Navigate(""); groupBox1.Enabled = false;
        }
        void TemizleGun()
        {
            TxtIsAkisNo.Clear(); CmbYaziTuruGun.Text = ""; CmbCinsiGun.Text = ""; TxtNeredenGeldigiGun.Clear(); TxtSayiNoGun.Clear(); TxtKonuGun.Clear(); TxtEkSayisiGun.Clear();
            CmbGeregiGun.Text = ""; CmbBilgi1Gun.Text = ""; CmbBilgi2Gun.Text = ""; CmbBilgi3Gun.Text = ""; CmbBilgi4Gun.Text = ""; CmbBilgi5Gun.Text = "";
            webBrowser2.Navigate(""); groupBox4.Enabled = false;
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İş Akış Numarası Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            EvrakKayit arac = kayitManager.Get(TxtIsAkisNo.Text.ConInt());
            if (arac == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGun();
                return;
            }
            id = arac.Id;
            CmbYaziTuruGun.Text = arac.YaziTuru;
            CmbCinsiGun.Text = arac.Cinsi;
            TxtNeredenGeldigiGun.Text = arac.NeredenGeldigi;
            TxtSayiNoGun.Text = arac.Sayino;
            DtTarihGun.Value = arac.Tarih;
            TxtKonuGun.Text = arac.Konu;
            TxtEkSayisiGun.Text = arac.EkSayisi;
            CmbGeregiGun.Text = arac.Geregi;
            CmbBilgi1Gun.Text = arac.Bilgi1;
            CmbBilgi2Gun.Text = arac.Bilgi2;
            CmbBilgi3Gun.Text = arac.Bilgi3;
            CmbBilgi4Gun.Text = arac.Bilgi4;
            CmbBilgi5Gun.Text = arac.Bilgi5;
            dosyaYoluGun = arac.Dosyayolu;
            webBrowser2.Navigate(dosyaYoluGun);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İŞ AKIŞ NO Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Güncellemek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                EvrakKayit evrakKayit = new EvrakKayit(TxtIsAkisNo.Text.ConInt(), CmbYaziTuruGun.Text, CmbCinsiGun.Text, TxtNeredenGeldigiGun.Text, TxtSayiNoGun.Text, DtTarihGun.Value, TxtKonuGun.Text, TxtEkSayisiGun.Text, CmbGeregiGun.Text, CmbBilgi1Gun.Text, CmbBilgi2Gun.Text, CmbBilgi3Gun.Text, CmbBilgi4Gun.Text, CmbBilgi5Gun.Text, dosyaYoluGun);
                string mesaj = kayitManager.Update(evrakKayit,id);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLogGun();
                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGun();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void CmbYaziTuruGun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbYaziTuruGun.SelectedIndex==0)
            {
                groupBox4.Enabled = true;
                TxtNeredenGeldigi.Enabled = false;
            }
            else
            {
                groupBox4.Enabled = false;
                TxtNeredenGeldigi.Enabled = true;
            }
        }

        private void TxtEkSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void BtnDosyaEkleGun_Click(object sender, EventArgs e)
        {
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
            if (!Directory.Exists(dosyaYoluGun))
            {
                Directory.CreateDirectory(dosyaYoluGun);
            }
            if (File.Exists(dosyaYoluGun + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYoluGun + "\\" + kaynakdosyaismi);
                fileNames.Add(alinandosya);
                webBrowser2.Navigate(dosyaYoluGun);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageEvrakKayit"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        
        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\EVRAK KAYIT\";
            /*string root = @"D:\DTS";
            string subdir = @"D:\DTS\İDARİ İŞLER\";
            string anadosya = @"D:\DTS\İDARİ İŞLER\EVRAK KAYIT\";*/
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
            dosyaYolu = anadosya + LblIsAkisNo.Text + "\\";
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
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
            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                fileNames.Add(alinandosya);
                webBrowser1.Navigate(dosyaYolu);
                dosyaControl = true;
            }
        }
    }
}
