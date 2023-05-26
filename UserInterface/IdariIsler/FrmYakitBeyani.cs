using Business;
using Business.Concreate.AnaSayfa;
using Business.Concreate.IdarıIsler;
using ClosedXML.Excel;
using DataAccess.Concreate;
using Entity;
using Entity.AnaSayfa;
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
    public partial class FrmYakitBeyani : Form
    {
        IsAkisNoManager isAkisNoManager;
        PersonelKayitManager kayitManager;
        YakitManager yakitManager;
        IdariIslerLogManager logManager;
        AracZimmetiManager aracZimmetiManager;
        IstenAyrilisManager ıstenAyrilisManager;
        BildirimYetkiManager bildirimYetkiManager;
        AracManager aracManager;

        //string dosyaYolu, kaynakdosyaismi, alinandosya, dosyaYoluGun;
        bool dosyaControl = false;
        public object[] infos;
        int id;
        List<string> fileNames = new List<string>();
        public FrmYakitBeyani()
        {
            InitializeComponent();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            yakitManager = YakitManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
            aracZimmetiManager = AracZimmetiManager.GetInstance();
            ıstenAyrilisManager = IstenAyrilisManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
            aracManager = AracManager.GetInstance();
        }

        private void FrmYakitBeyani_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            Personeller();
            PersonellerGun();
            Plakalar();
        }
        void Plakalar()
        {
            TxtPlaka.DataSource = aracManager.GetList();
            TxtPlaka.ValueMember = "Id";
            TxtPlaka.DisplayMember = "Plaka";
            TxtPlaka.SelectedValue = -1;
        }
        public void YenilenecekVeri()
        {
            IsAkisNo();
            Personeller();
        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        void Personeller()
        {
            CmbPersonel.DataSource = kayitManager.PersonelAdSoyad();
            CmbPersonel.ValueMember = "Id";
            CmbPersonel.DisplayMember = "Adsoyad";
            CmbPersonel.SelectedValue = "";
        }
        void PersonellerGun()
        {
            CmbPersonelGun.DataSource = kayitManager.PersonelAdSoyad();
            CmbPersonelGun.ValueMember = "Id";
            CmbPersonelGun.DisplayMember = "Adsoyad";
            CmbPersonelGun.SelectedValue = "";
        }
        void PersonellerAyrilan()
        {
            CmbPersonel.DataSource = ıstenAyrilisManager.GetList();
            CmbPersonel.ValueMember = "Id";
            CmbPersonel.DisplayMember = "Adsoyad";
            CmbPersonel.SelectedValue = "";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageYakitBeyani"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void TxtKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtLitre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtLitreFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtToplamFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
        void Hesapla()
        {
            double litre, fiyat, toplamfiyat;
            if (TxtLitre.Text == "")
            {
                litre = 0;
            }
            else
            {
                litre = TxtLitre.Text.ConDouble();
            }
            if (TxtLitreFiyati.Text == "")
            {
                fiyat = 0;
            }
            else
            {
                fiyat = TxtLitreFiyati.Text.ConDouble();
            }
            toplamfiyat = litre * fiyat;
            TxtToplamFiyat.Text = toplamfiyat.ToString();
        }

        private void TxtLitre_TextChanged(object sender, EventArgs e)
        {
            Hesapla();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            /*IXLWorkbook workbook = new XLWorkbook(@"C:\Users\MAYıldırım\Desktop\2021_YAKIT ALIM TAKİP\YAKIT ALIM TAKİP DOSYASI_2021_TAŞIT TANIMA.xlsx");
            IXLWorksheets sheets = workbook.Worksheets;
            IXLWorksheet worksheet = workbook.Worksheet("TEMMUZ");
            var rows = worksheet.Rows(2, 11);
            DateTime outDate = DateTime.Now;
            //double outDouble = 0;
            foreach (IXLRow item in rows)
            {
                Yakit yakits = new Yakit(
                    0, // İŞ AKIŞ NO
                    item.Cell("A").Value.ToString(), // PLAKA
                    item.Cell("B").Value.ToString(), // YAKIT ALINAN DÖNEM
                    item.Cell("C").Value.ConTime(), // TARİH
                    item.Cell("D").Value.ConInt(), // KM
                    item.Cell("E").Value.ConDouble(), // ALINAN LİTRE
                    item.Cell("F").Value.ToString(), // YAKIT TÜRÜ
                    item.Cell("G").Value.ConDouble(), // LİTRE FİYATI
                    item.Cell("H").Value.ConDouble(), // TOPLAM FİYAT
                    item.Cell("I").Value.ToString(), // ALIM TÜRÜ
                    item.Cell("M").Value.ToString(), // YAKIT ALAN PERSONEL
                    item.Cell("J").Value.ToString(), // ALINAN FİRMA
                    item.Cell("K").Value.ToString(), // BELGE TÜRÜ
                    item.Cell("L").Value.ToString(), // BELGE NUMARASI
                    ""); // DOSYA YOLU
                yakitManager.Add(yakits);*/
            
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IsAkisNo();
                string donem = FrmHelper.DonemControl(TxtTarih.Value);
                Yakit yakit = new Yakit(LblIsAkisNo.Text.ConInt(), TxtPlaka.Text, donem, TxtTarih.Value, TxtKm.Text.ConInt(), TxtLitre.Text.ConDouble(), CmbYakitTuru.Text, TxtLitreFiyati.Text.ConDouble(), TxtToplamFiyat.Text.ConDouble(), TxtAlimTuru.Text, CmbPersonel.Text, TxtAlinanFirma.Text, CmbBelgeTuru.Text, TxtBelgeNo.Text, TxtAciklama.Text);
                string mesaj = yakitManager.Add(yakit);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLog();
                mesaj = BildirimKayit();
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsAkisNo();
                dosyaControl = false;
                Temizle();
            }
        }
        string BildirimKayit()
        {
            string[] array = new string[8];

            array[0] = "Yakıt Beyanı"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = LblIsAkisNo.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "iş akış numaralı"; // Bildirim türü
            array[4] = TxtPlaka.Text + " plakalı araç için"; // İÇERİK
            array[5] = TxtTarih.Value.ToString("d") + " tarihine ait "+ CmbPersonel.Text + " adlı personel";
            array[6] = "tarafından alınan yakıt beyanı kaydı oluşturulmuştur!";

            BildirimYetki bildirimYetki = bildirimYetkiManager.Get(infos[1].ToString());
            if (bildirimYetki == null)
            {
                array[7] = infos[0].ToString();
            }
            else
            {
                array[7] = bildirimYetki.SorumluId + infos[0].ToString();
            }

            string mesaj = FrmHelper.BildirimGonder(array, array[7]);
            return mesaj;
        }



        void CreateLog()
        {
            string sayfa = "YAKIT";
            Yakit yakit = yakitManager.Get(LblIsAkisNo.Text.ConInt());
            int benzersizid = yakit.Id;
            string islem = "YAKIT BEYANI İŞLEMİ KAYDEDİLMİŞTİR.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogGun()
        {
            string sayfa = "YAKIT";
            Yakit yakit = yakitManager.Get(TxtIsAkisNo.Text.ConInt());
            int benzersizid = yakit.Id;
            string islem = "YAKIT BEYANI İŞLEMİ GÜNCELLENMİŞTİR.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void Temizle()
        {
            TxtPlaka.SelectedValue=""; TxtKm.Clear(); TxtLitre.Clear(); CmbYakitTuru.Text = ""; TxtLitreFiyati.Clear(); TxtToplamFiyat.Clear(); TxtAlimTuru.SelectedIndex=-1; CmbPersonel.SelectedValue = 0; TxtAlinanFirma.Clear(); CmbBelgeTuru.Text = ""; TxtBelgeNo.Clear();
            webBrowser1.Navigate("");
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İş Akış Numarası Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Yakit yakit = yakitManager.Get(TxtIsAkisNo.Text.ConInt());
            if (yakit == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGun();
                return;
            }
            id = yakit.Id;
            TxtPlakaGun.Text = yakit.Plaka;
            TxtTarihGun.Value = yakit.Tarih;
            TxtKmGun.Text = yakit.Km.ToString();
            TxtLitreGun.Text = yakit.AlinanLitre.ToString();
            CmbYakitTuruGun.Text = yakit.YakitTuru;
            TxtLitreFiyatiGun.Text = yakit.LitreFiyati.ToString();
            TxtToplamFiyatGun.Text = yakit.ToplamFiyat.ToString();
            TxtAlimTuruGun.Text = yakit.AlimTuru;
            CmbPersonelGun.Text = yakit.Personel;
            TxtAlinanFirmaGun.Text = yakit.AlinanFirma;
            CmbBelgeTuruGun.Text = yakit.BelgeTuru;
            TxtBelgeNoGun.Text = yakit.BelgeNumarasi;
            TxtAciklamaGun.Text = yakit.Aciklama;
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
                string donem = FrmHelper.DonemControl(TxtTarihGun.Value);
                Yakit yakit = new Yakit(TxtIsAkisNo.Text.ConInt(), TxtPlakaGun.Text, donem, TxtTarihGun.Value, TxtKmGun.Text.ConInt(), TxtLitreGun.Text.ConDouble(), CmbYakitTuruGun.Text, TxtLitreFiyatiGun.Text.ConDouble(),
                    TxtToplamFiyatGun.Text.ConDouble(), TxtAlimTuruGun.Text, CmbPersonelGun.Text, TxtAlinanFirmaGun.Text, CmbBelgeTuruGun.Text, TxtBelgeNoGun.Text, TxtAciklamaGun.Text);
                string mesaj = yakitManager.Update(yakit, id);
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

        private void ChkAyrilanPersonel_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAyrilanPersonel.Checked == true)
            {
                PersonellerAyrilan();
            }
            else
            {
                Personeller();
            }
        }

        void TemizleGun()
        {
            TxtIsAkisNo.Clear(); TxtPlakaGun.Clear(); TxtKmGun.Clear(); TxtLitreGun.Clear(); CmbYakitTuruGun.Text = "";
            TxtLitreFiyatiGun.Clear(); TxtToplamFiyatGun.Clear(); TxtAlimTuruGun.SelectedIndex=-1; CmbPersonelGun.Text = ""; TxtAlinanFirmaGun.Clear(); CmbBelgeTuruGun.Text = ""; TxtBelgeNoGun.Clear();
        }

        private void TxtLitreFiyati_TextChanged(object sender, EventArgs e)
        {
            Hesapla();
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            /*string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\YAKIT BEYANI\";
            string root = @"D:\DTS";
            string subdir = @"D:\DTS\İDARİ İŞLER\";
            string anadosya = @"D:\DTS\İDARİ İŞLER\YAKIT BEYANI\";
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
            }*/
        }

        private void ChkAyrilanArac_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAyrilanArac.Checked==true)
            {
                TxtPlaka.DataSource = aracManager.ProjeDisiList();
                TxtPlaka.ValueMember = "Id";
                TxtPlaka.DisplayMember = "Plaka";
                TxtPlaka.SelectedValue = -1;
            }
            else
            {
                Plakalar();
            }
        }

        private void TxtToplamFiyat_TextChanged(object sender, EventArgs e)
        {
            LitreFiyatHesapla();
        }
        void LitreFiyatHesapla()
        {
            double litreFiyat = TxtToplamFiyat.Text.ConDouble() / TxtLitre.Text.ConDouble();
            TxtLitreFiyati.Text = litreFiyat.ToString();
        }
    }
}
