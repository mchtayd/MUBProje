using Business;
using Business.Concreate.AnaSayfa;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
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
    public partial class FrmAracKaydet : Form
    {
        AracManager aracManager;
        IdariIslerLogManager logManager;
        SiparislerManager siparislerManager;
        PersonelKayitManager kayitManager;
        SiparisPersonelManager siparisPersonelManager;
        ZimmetAktarimManager zimmetAktarimManager;
        ComboManager comboManager;
        BildirimYetkiManager bildirimYetkiManager;

        List<string> fileNames = new List<string>();
        List<Combo> combos = new List<Combo>();
        public object[] infos;
        string dosyaYolu, kaynakdosyaismi, alinandosya, dosyaYoluGun, comboAd;
        int id, idC;
        public bool mulkiket=true;
        bool aracKadroArttir = false;
        public FrmAracKaydet()
        {
            InitializeComponent();
            aracManager = AracManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
            siparislerManager = SiparislerManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            zimmetAktarimManager = ZimmetAktarimManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageAracKaydet"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void FrmAracKaydet_Load(object sender, EventArgs e)
        {
            if (infos[1].ToString() != "RESUL GÜNEŞ")
            {
                BtnMulkiyetEkle.Visible = false;
            }
            Siparisler();
            SiparislerGun();
            ComboProje();
            ComboProjeGun();
            ComboMulkiyetBilgileri();
            ComboProjeCikis();
            gec = false;
            mulkiket = false;
        }
        public void ComboMulkiyetBilgileri()
        {
            CmbMulkiyetBilgileri.DataSource = comboManager.GetList("MÜLKİYET BİLGİLERİ");
            CmbMulkiyetBilgileri.ValueMember = "Id";
            CmbMulkiyetBilgileri.DisplayMember = "Baslik";
            CmbMulkiyetBilgileri.SelectedValue = 0;
        }
        
        public void ComboProje()
        {
            combos = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProje.DataSource = combos;
            CmbProje.ValueMember = "Id";
            CmbProje.DisplayMember = "Baslik";
            CmbProje.SelectedValue = 0;
        }
        public void ComboProjeGun()
        {
            CmbProjeGun.DataSource = combos;
            CmbProjeGun.ValueMember = "Id";
            CmbProjeGun.DisplayMember = "Baslik";
            CmbProjeGun.SelectedValue = 0;
        }
        public void ComboProjeCikis()
        {
            CmbProjeC.DataSource = combos;
            CmbProjeC.ValueMember = "Id";
            CmbProjeC.DisplayMember = "Baslik";
            CmbProjeC.SelectedValue = 0;
        }
        public void YenilecekVeriler()
        {
            gec = true;
            mulkiket = true;
            Siparisler();
            SiparislerGun();
            ComboProje();
            ComboProjeGun();
            ComboMulkiyetBilgileri();
            ComboProjeCikis();
            mulkiket = false;
            gec = false;
        }
        void Siparisler()
        {
            CmbSiparisNo.DataSource = siparislerManager.GetList();
            CmbSiparisNo.ValueMember = "Id";
            CmbSiparisNo.DisplayMember = "Siparisno";
            CmbSiparisNo.SelectedValue = 0;
        }
        void SiparislerGun()
        {
            CmbSiparisNoGun.DataSource = siparislerManager.GetList();
            CmbSiparisNoGun.ValueMember = "Id";
            CmbSiparisNoGun.DisplayMember = "Siparisno";
            CmbSiparisNoGun.SelectedValue = 0;
        }
        bool dosyaekle = false;
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (dosyaekle == false)
                {
                    MessageBox.Show("Lütfen Öncelikle Dosya Ekleyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TxtTasitTanima.Text == "VAR")
                {
                    if (TxtArventoId.Text == "")
                    {
                        MessageBox.Show("Lütfen ARVENTO ID Bilgisini Boş Geçmeyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                Arac arac = new Arac(TxtPlaka.Text, DtilkTecilTarihi.Value, DtTecilTarihi.Value, TxtMarkasi.Text, TxtTipi.Text, TxtTicariAdi.Text, TxtModeli.Text, TxtSinifi.Text, TxtCinsi.Text, TxtRengi.Text, TxtMotorNo.Text, TxtSaseNo.Text, CmbYakitCinsi.Text, CmbMulkiyetBilgileri.Text, CmbProje.Text, CmbSiparisNo.Text, TxtTasitTanima.Text, TxtArventoId.Text, DtProjeTahsisTarihi.Value,
                    TxtProjeyeTahsisKm.Text.ConInt(), dosyaYolu, TxAciklama.Text);
                string mesaj = aracManager.Add(arac);
                if (mesaj != "OK")
                {
                    //Directory.Delete(dosyaYolu, true);
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (aracKadroArttir==true)
                {
                    siparislerManager.AracSiparisArttir(CmbSiparisNo.Text);
                }
                aracKadroArttir = false;

                CreateLog();
                string mesaj2 = BildirimKayit();
                if (mesaj2!="OK")
                {
                    MessageBox.Show(mesaj2, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dosyaekle = false;
                Temizle();
            }
        }
        string BildirimKayit()
        {
            string[] array = new string[8];

            array[0] = "Araç Kayıt"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = TxtPlaka.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "Plakalı"; // Bildirim türü
            array[4] = TxtMarkasi.Text + TxtTicariAdi.Text + " Markalı"; // İÇERİK
            array[5] = "aracın "+ DtProjeTahsisTarihi.Value.ToString("d") + " tarihinden itibaren";
            array[6] = "projeye tahsisi yapmıştır!";

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
        string BildirimKayitKapat()
        {
            string[] array = new string[8];

            array[0] = "Araç Projeden Çıkış"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = TxtPlaka.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "Plakalı"; // Bildirim türü
            array[4] = TxtMarkasi.Text + TxtTicariAdi.Text + " Markalı"; // İÇERİK
            array[5] = "aracın " + DtProjeCikisTarihiC.Text + " tarihinden itibaren";
            array[6] = "projeden çıkışı yapmıştır!";

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

        void CreateDirectory()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\ULAŞTIRMA\";
            string anadosya2 = @"Z:\DTS\İDARİ İŞLER\ULAŞTIRMA\ARAÇ BİLGİLERİ\";
            /*string root = @"D:\DTS";
            string subdir = @"D:\DTS\İDARİ İŞLER\";
            string anadosya = @"D:\DTS\İDARİ İŞLER\İZİN\";
            string anadosya2 = @"D:\DTS\İDARİ İŞLER\ULAŞTIRMA\ARAÇ BİLGİLERİ\";*/
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
            dosyaYolu = anadosya2 + TxtPlaka.Text + "\\";
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
            }
        }
        void CreateDirectoryGun()
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
        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            dosyaekle = true;
            CreateDirectory();
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtPlakaGun.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Plaka Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Arac arac = aracManager.Get(TxtPlakaGun.Text);
            if (arac == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
                return;
            }
            TxtPlakaGun.Text.ToUpper();
            id = arac.Id;
            DtilkTecilTarihiGun.Value = arac.IlkTescilTarihi;
            DtTecilTarihiGun.Value = arac.TescilTarihi;
            TxtMarkasiGun.Text = arac.Markasi;
            TxtTipiGun.Text = arac.Tipi;
            TxtTicariAdiGun.Text = arac.TicariAdi;
            TxtModeliGun.Text = arac.ModelYili;
            TxtSinifiGun.Text = arac.AracSinifi;
            TxtCinsiGun.Text = arac.Cinsi;
            TxtRengiGun.Text = arac.Rengi;
            TxtMotorNoGun.Text = arac.MotorNo;
            TxtSaseNoGun.Text = arac.SaseNo;
            CmbYakitCinsiGun.Text = arac.YakitCinsi;
            CmbMulkiyetBilgileriGun.Text = arac.MulkiyetBilgileri;
            CmbProjeGun.Text = arac.Proje;
            CmbSiparisNoGun.Text = arac.Siparisno;
            TxtTasitTanimaGun.Text = arac.TasitTanima;
            TxtArventoIdGun.Text = arac.Arventoid;
            DtProjeTahsisTarihiGun.Value = arac.ProjeTahsisTarihi;
            TxtProjeCikisNedeni.Text = arac.ProjeCikisNedeni;
            TxtAciklamaGun.Text = arac.Aciklama;
            dosyaYoluGun = arac.DosyaYolu;
            DtProjeCikisTarihi.Text = arac.ProjeCikisTarihi;
            TxtProjeyeTahsisKmGun.Text = arac.ProjeTahsisTarihi.ToString();
            TxtProjeCikisKmGun.Text = arac.KmCikis.ToString();
            TxtProjeCikisNedeni.Text = arac.ProjeCikisNedeni;

            webBrowser2.Navigate(dosyaYoluGun);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Güncellemek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (TxtTasitTanimaGun.Text == "VAR")
                {
                    if (TxtArventoIdGun.Text == "")
                    {
                        MessageBox.Show("Lütfen ARVENTO ID Bilgisini Boş Geçmeyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                Arac arac = new Arac(TxtPlakaGun.Text, DtilkTecilTarihiGun.Value, DtTecilTarihiGun.Value, TxtMarkasiGun.Text, TxtTipiGun.Text, TxtTicariAdiGun.Text, TxtModeliGun.Text, TxtSinifiGun.Text, TxtCinsiGun.Text, TxtRengiGun.Text, TxtMotorNoGun.Text, TxtSaseNoGun.Text, CmbYakitCinsiGun.Text, CmbMulkiyetBilgileriGun.Text, CmbProjeGun.Text, CmbSiparisNoGun.Text, TxtTasitTanimaGun.Text, TxtArventoIdGun.Text, DtProjeTahsisTarihiGun.Value, TxtProjeyeTahsisKmGun.Text.ConInt(), TxtProjeCikisKmGun.Text.ConInt(), DtProjeCikisTarihi.Text.ToString(), TxtProjeCikisNedeni.Text, dosyaYoluGun, TxtAciklamaGun.Text);

                string mesaj = aracManager.Update(arac, id);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (aracKadroArttir == true)
                {
                    siparislerManager.AracSiparisArttir(CmbSiparisNoGun.Text);
                }
                aracKadroArttir = false;
                CreateLogGuncelle();
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
            }
        }

        private void BtnDosyaEkleGun_Click(object sender, EventArgs e)
        {
            CreateDirectoryGun();
        }

        void Temizle()
        {
            TxtPlaka.Clear(); TxtMarkasi.Clear(); TxtTipi.Clear(); TxtTicariAdi.Clear(); TxtModeli.Clear(); TxtSinifi.Clear();
            TxtCinsi.Clear(); TxtRengi.Clear(); TxtMotorNo.Clear(); TxtSaseNo.Clear(); CmbYakitCinsi.Text = ""; CmbMulkiyetBilgileri.Text = "";
            CmbProje.Text = ""; CmbSiparisNo.SelectedValue = 0; TxtTasitTanima.Text = ""; TxtArventoId.Clear(); webBrowser1.Navigate("");
            DtilkTecilTarihi.Value = DateTime.Now; DtTecilTarihi.Value = DateTime.Now; DtTecilTarihi.Value = DateTime.Now; DtProjeTahsisTarihi.Value = DateTime.Now; TxAciklama.Clear(); TxtProjeyeTahsisKm.Clear();

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TemizleGuncelle();
        }

        private void BtnTemizleKayit_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void DtilkTecilTarihiC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CmbSiparisNoC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        void TemizleC()
        {
            TxtPlakaC.Clear(); TxtMarkasiC.Clear(); TxtTipiC.Clear(); TxtTicariAdiC.Clear(); TxtModeliC.Clear(); TxtSinifiC.Clear();
            TxtCinsiC.Clear(); TxtRengiC.Clear(); TxtMotorNoC.Clear(); TxtSaseNoC.Clear(); CmbYakitCinsiC.Text = ""; CmbMulkiyetBilgileriC.Text = "";
            CmbProjeC.SelectedIndex = -1; CmbSiparisNoC.Text = ""; TxtTasitTanimaC.Clear(); TxtArventoIdC.Clear(); DtProjeCikisTarihiC.Clear(); TxAciklamaC.Clear(); TxtProjeCikisNedeniC.Clear(); webBrowser3.Navigate(""); TxtProjeCikisNedeniC.Clear();
        }
        private void BtnTemizleC_Click(object sender, EventArgs e)
        {
            TemizleC();
        }
        void CreateDirectoryCikis()
        {
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi = openFileDialog3.SafeFileName.ToString();
                alinandosya = openFileDialog3.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(dosyaYoluGun + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYoluGun + "\\" + kaynakdosyaismi);
                fileNames.Add(alinandosya);
                webBrowser3.Navigate(dosyaYoluC);
            }
        }
        private void BtnDosyaEkleC_Click(object sender, EventArgs e)
        {
            CreateDirectoryCikis();
        }

        private void BtnBulC_Click(object sender, EventArgs e)
        {
            if (TxtPlakaC.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Plaka Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Arac arac = aracManager.Get(TxtPlakaC.Text);
            if (arac == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
                return;
            }
            TxtPlakaC.Text.ToUpper();
            idC = arac.Id;
            DtilkTecilTarihiC.Value = arac.IlkTescilTarihi;
            DtTecilTarihiC.Value = arac.TescilTarihi;
            TxtMarkasiC.Text = arac.Markasi;
            TxtTipiC.Text = arac.Tipi;
            TxtTicariAdiC.Text = arac.TicariAdi;
            TxtModeliC.Text = arac.ModelYili;
            TxtSinifiC.Text = arac.AracSinifi;
            TxtCinsiC.Text = arac.Cinsi;
            TxtRengiGun.Text = arac.Rengi;
            TxtMotorNoC.Text = arac.MotorNo;
            TxtSaseNoC.Text = arac.SaseNo;
            CmbYakitCinsiC.Text = arac.YakitCinsi;
            CmbMulkiyetBilgileriC.Text = arac.MulkiyetBilgileri;
            CmbProjeC.Text = arac.Proje;
            CmbSiparisNoC.Text = arac.Siparisno;
            TxtTasitTanimaC.Text = arac.TasitTanima;
            TxtArventoIdC.Text = arac.Arventoid;
            DtProjeTahsisTarihiC.Value = arac.ProjeTahsisTarihi;
            TxtProjeCikisNedeniC.Text = arac.ProjeCikisNedeni;
            TxAciklamaC.Text = arac.Aciklama;
            dosyaYoluC = arac.DosyaYolu;
            TxtRengiC.Text = arac.Rengi;
            DtProjeCikisTarihiC.Text = arac.ProjeCikisTarihi;
            TxtProjeyeTahsisKmC.Text = arac.KmGiris.ToString();

            webBrowser3.Navigate(dosyaYoluC);

        }
        string dosyaYoluC;

        private void TxtGuncelleC_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Projeden Aracın Çıkışını Yapmak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Arac arac = new Arac(DtProjeCikisTarihiC.Text, TxtProjeCikisNedeniC.Text, TxtProjeCikisKm.Text.ConInt());
                if (DtProjeCikisTarihiC.Text == "  .  .")
                {
                    MessageBox.Show("Lütfen Öncelikle Aracın PROJEDEN ÇIKIŞ TARİHİ Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string mesaj = aracManager.Kapatma(arac, idC);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                siparislerManager.AracSiparisAzalt(CmbSiparisNoC.Text);
                CreateLogKapatma();
                string mesaj2 = BildirimKayitKapat();
                if (mesaj2 != "OK")
                {
                    MessageBox.Show(mesaj2, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleC();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtProjeCikisKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        int index;
        private void CmbMulkiyetBilgileri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mulkiket==true)
            {
                return;
            }
            if (TxtPlaka.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Plaka Bilgisini Giriniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                CmbMulkiyetBilgileri.SelectedIndex = -1;
                return;
            }
            index = CmbMulkiyetBilgileri.SelectedIndex;
            if (index == 0) // KİRALIK
            {
                /*CmbPersoneller.Visible = true;
                TxtPersonelBolum.Visible = true;
                LblPersonel.Visible = true;
                LblPersonelBolum.Visible = true;*/
            }
            if (index == 1) // MÜLKİYET
            {
                /*CmbPersoneller.Visible = false;
                TxtPersonelBolum.Visible = false;
                LblPersonel.Visible = false;
                LblPersonelBolum.Visible = false;*/
                
                /*ZimmetAktarim zimmetAktarim = zimmetAktarimManager.AracZimmetBilgileri("%" + TxtPlaka.Text + '%');
                if (zimmetAktarim==null)
                {
                    MessageBox.Show(TxtPlaka.Text + " Plakalı Araç Hiç Bir Personele Zimmetli Değildir. Kayıt İşlemine Devam Etmek İçin Öncelikle Aracın Duran Varlık Kaydı Yapılmalıdır!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    CmbMulkiyetBilgileri.SelectedIndex = -1;
                    return;
                }
                zimmetliPersonel = zimmetAktarim.PersonelAd;
                personelBolum = zimmetAktarim.Bolum;*/
            }
        }
        bool gec = true;string zimmetliPersonel,personelBolum;

        private void TxtPersonelBolum_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void CmbSiparisNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gec==true)
            {
                return;
            }
            Siparisler siparisler = siparislerManager.AracMevcutKadroKontrol(CmbSiparisNo.Text);
            if (siparisler==null)
            {
                return;
            }
            int mevcutAracSayisi = siparisler.MevcutArac;
            int toplamAracSayisi = siparisler.Toplamarac;

            if (toplamAracSayisi <= mevcutAracSayisi)
            {
                MessageBox.Show(CmbSiparisNo.Text + " Nolu Sipariş İçin Araç Kadrosu Doludur, Herhangi Bir Araç Kaydedemezsiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                CmbSiparisNo.SelectedValue = "";
                return;
            }
            aracKadroArttir = true;
        }

        private void CmbSiparisNoGun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gec == true)
            {
                return;
            }
            Siparisler siparisler = siparislerManager.AracMevcutKadroKontrol(CmbSiparisNoGun.Text);
            if (siparisler == null)
            {
                return;
            }
            int mevcutAracSayisi = siparisler.MevcutArac;
            int toplamAracSayisi = siparisler.Toplamarac;

            if (toplamAracSayisi <= mevcutAracSayisi)
            {
                MessageBox.Show(CmbSiparisNoGun.Text + " Nolu Sipariş İçin Araç Kadrosu Doludur, Herhangi Bir Araç Kaydedemezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CmbSiparisNoGun.SelectedValue = "";
                return;
            }
            aracKadroArttir = true;
        }

        private void BtnMulkiyetEkle_Click(object sender, EventArgs e)
        {
            comboAd = "MÜLKİYET BİLGİLERİ";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void CmbMulkiyetBilgileriGun_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CmbMulkiyetBilgileriGun.SelectedIndex;
            if (index == 0)
            {
                /*CmbPersonellerGun.Visible = true;
                TxtPersonelBolumGun.Visible = true;
                LbPersonelGun.Visible = true;
                LblPersonelBolumGun.Visible = true;*/
                CmbMulkiyetBilgileriGun.SelectedValue = "";
            }
            if (index == 1)
            {
                /*CmbPersonellerGun.Visible = false;
                TxtPersonelBolumGun.Visible = false;
                LbPersonelGun.Visible = false;
                LblPersonelBolumGun.Visible = false;*/
                CmbMulkiyetBilgileriGun.SelectedValue = "";
                ZimmetAktarim zimmetAktarim = zimmetAktarimManager.AracZimmetBilgileri("%" + TxtPlakaGun.Text + '%');
                if (zimmetAktarim == null)
                {
                    MessageBox.Show(TxtPlakaGun.Text + " Plakalı Araç Hiç Bir Personele Zimmetli Değildir. Kayıt İşlemine Devam Etmek İçin Öncelikle Aracın Duran Varlık Kaydı Yapılmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbMulkiyetBilgileriGun.SelectedIndex = -1;
                    return;
                }
                zimmetliPersonel = zimmetAktarim.PersonelAd;

            }
        }

        void TemizleGuncelle()
        {
            TxtPlakaGun.Clear(); TxtMarkasiGun.Clear(); TxtTipiGun.Clear(); TxtTicariAdiGun.Clear(); TxtModeliGun.Clear(); TxtSinifiGun.Clear();
            TxtCinsiGun.Clear(); TxtRengiGun.Clear(); TxtMotorNoGun.Clear(); TxtSaseNoGun.Clear();
            CmbYakitCinsiGun.Text = ""; CmbMulkiyetBilgileriGun.Text = ""; CmbProjeGun.Text = "";
            CmbSiparisNoGun.SelectedValue = 0; TxtTasitTanimaGun.Text = ""; TxtArventoIdGun.Clear(); TxtProjeCikisNedeni.Clear(); DtProjeCikisTarihi.Text = ""; DtilkTecilTarihiGun.Value = DateTime.Now; DtTecilTarihiGun.Value = DateTime.Now; DtProjeTahsisTarihiGun.Value = DateTime.Now; TxtAciklamaGun.Clear(); CmbYakitCinsiGun.SelectedValue = 0; CmbYakitCinsiGun.SelectedValue = 0;
            webBrowser2.Navigate(""); CmbMulkiyetBilgileriGun.SelectedIndex = -1; CmbProjeGun.SelectedIndex = -1; CmbSiparisNoGun.SelectedIndex = -1; CmbMulkiyetBilgileri.SelectedIndex = -1; CmbProje.SelectedIndex = -1; CmbSiparisNo.SelectedIndex = -1; TxtTasitTanima.SelectedIndex = -1;
        }
        void CreateLog()
        {
            string sayfa = "ARAÇ KAYIT";
            Arac arac = aracManager.Get(TxtPlaka.Text);
            int benzersizid = arac.Id;
            string islem = "ARAÇ BİLGİSİ KAYDEDİLMİŞTİR.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogGuncelle()
        {
            string sayfa = "ARAÇ KAYIT";
            Arac arac = aracManager.Get(TxtPlakaGun.Text);
            int benzersizid = arac.Id;
            string islem = "ARAÇ BİLGİSİ GÜNCELLENMİŞTİR.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogKapatma()
        {
            string sayfa = "ARAÇ KAYIT";
            Arac arac = aracManager.Get(TxtPlakaC.Text);
            int benzersizid = arac.Id;
            string islem = "ARAÇIN PROJEDEN ÇIKIŞI YAPILMIŞTIR.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
    }
}
