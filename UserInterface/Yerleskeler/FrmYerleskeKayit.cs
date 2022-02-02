using Business;
using Business.Concreate.Yerleskeler;
using DataAccess.Concreate;
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
using UserInterface.Ana_Sayfa;
using UserInterface.STS;

namespace UserInterface.Yerleskeler
{
    public partial class FrmYerleskeKayit : Form
    {
        public string comboAd;
        string dosyaAdi, dosyaYolu = "", kaynakdosyaismi, alinandosya, siparisNo, siparisNoKontrol;
        bool dosyaKontrol = false, start = false;
        List<string> fileNames = new List<string>();
        List<Yerleske> yerleskes = new List<Yerleske>();
        List<Yerleske> yerleskeControl = new List<Yerleske>();
        List<Kira> kiras = new List<Kira>();

        ComboManager comboManager;
        YerleskeManager yerleskeManager;
        KiraManager kiraManager;

        public FrmYerleskeKayit()
        {
            InitializeComponent();
            comboManager = ComboManager.GetInstance();
            yerleskeManager = YerleskeManager.GetInstance();
            kiraManager = KiraManager.GetInstance();
        }

        private void FrmYerleskeKayit_Load(object sender, EventArgs e)
        {
            AbonelikTuru();
            YerleskeAdlari();
            start = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageYerleskeler"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void YerleskeAdlari()
        {
            CmbYerleskeAdi.DataSource = kiraManager.GetList();
            CmbYerleskeAdi.ValueMember = "Id";
            CmbYerleskeAdi.DisplayMember = "YerleskeAdi";
            CmbYerleskeAdi.SelectedValue = 0;
        }

        private void CmbMulkiyetBilgileri_TextChanged(object sender, EventArgs e)
        {
            if (CmbMulkiyetBilgileri.SelectedIndex==0)
            {
                GrbKiralik.Enabled = true;
            }
            if (CmbMulkiyetBilgileri.SelectedIndex == 1)
            {
                GrbKiralik.Enabled = false;
            }
        }
        public void AbonelikTuru()
        {
            CmbAbonelikTuru.DataSource = comboManager.GetList("ABONE_TURU");
            CmbAbonelikTuru.ValueMember = "Id";
            CmbAbonelikTuru.DisplayMember = "Baslik";
            CmbAbonelikTuru.SelectedValue = 0;
        }
        string Kontrol()
        {
            if (TxtYerleskeAdi.Text=="")
            {
                return "Lütfen Öncelikle Yerleşke Adı Bilgisini Doldurunuz!";
            }
            if (CmbMulkiyetBilgileri.Text == "")
            {
                return "Lütfen Öncelikle Müşteri Bilgileri Bilgisini Doldurunuz!";
            }
            if (TxtYerleskeAdresi.Text == "")
            {
                return "Lütfen Öncelikle Yerleşke Adresi Bilgisini Doldurunuz!";
            }
            if (DtgAbonelikler.RowCount == 0)
            {
                return "Lütfen Öncelikle Abonelik Bilgilerini Doldurup Listeye Ekleyiniz!";
            }
            return "OK";
        }
        string Kontrol2()
        {
            if (TxtAdiSoyadi.Text == "")
            {
                return "Lütfen Öncelikle Kiraya Verenin Adı Soyadı Bilgisini Doldurunuz!";
            }
            if (TxtTC.Text == "")
            {
                return "Lütfen Öncelikle Kiraya Verenin Tc Bilgisini Doldurunuz!";
            }
            if (TxtIkametgah.Text == "")
            {
                return "Lütfen Öncelikle Kiraya Verenin İkametgah Bilgisini Doldurunuz!";
            }
            if (TxtTelefonNo.Text == "(   )    -")
            {
                return "Lütfen Öncelikle Kiraya Verenin İkametgah Bilgisini Doldurunuz!";
            }
            if (TxtBankaSubesi.Text == "")
            {
                return "Lütfen Öncelikle Kiraya Verenin Banka Şubesi Bilgisini Doldurunuz!";
            }
            if (TxtIban.Text == "")
            {
                return "Lütfen Öncelikle Kiraya Verenin Iban Bilgisini Doldurunuz!";
            }
            if (TxtTutar.Text == "")
            {
                return "Lütfen Öncelikle Kiraya Verenin Tutar Bilgisini Doldurunuz!";
            }
            return "OK";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (dosyaKontrol==false)
            {
                MessageBox.Show("Lütfen Öncelikle Abonelik Sözleşmesi veya Abonelikle İlgili Evraklarınızı Ekleyiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            string control = Kontrol();
            if (CmbMulkiyetBilgileri.SelectedIndex == 0)
            {
                string control2 = Kontrol2();
                if (control2!="OK")
                {
                    MessageBox.Show(control2, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (control!="OK")
            {
                MessageBox.Show(control,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (CmbYerleskeAdi.Text=="")
            {
                siparisNo = Guid.NewGuid().ToString();
            }

            else
            {
                siparisNo = siparisNoKontrol;

            }

            foreach (DataGridViewRow item in DtgAbonelikler.Rows)
            {

                yerleskeControl = yerleskeManager.AbonelikKontrol(TxtYerleskeAdi.Text, item.Cells["AboneTuru"].Value.ToString(), item.Cells["HizmetAlinanKurum"].Value.ToString(), siparisNo);

                if (yerleskeControl.Count==0)
                {
                    Yerleske yerleske = new Yerleske(TxtYerleskeAdi.Text, CmbMulkiyetBilgileri.Text, TxtYerleskeAdresi.Text, item.Cells["AboneTuru"].Value.ToString(), item.Cells["HizmetAlinanKurum"].Value.ToString(), item.Cells["AboneTesisatNo"].Value.ToString(), item.Cells["AboneTarihi"].Value.ConTime(), "DEVAM EDİYOR", dosyaYolu, siparisNo);

                    yerleskeManager.Add(yerleske);
                }
               
            }

            //kiras = kiraManager.YerleskeKontrol(TxtYerleskeAdi.Text, TxtYerleskeAdresi.Text, CmbMulkiyetBilgileri.Text, siparisNo);

            if (CmbYerleskeAdi.Text=="")
            {
                if (CmbMulkiyetBilgileri.SelectedIndex == 0)
                {
                    Kira kira = new Kira(TxtYerleskeAdi.Text, TxtYerleskeAdresi.Text, CmbMulkiyetBilgileri.Text, TxtAdiSoyadi.Text, TxtTC.Text, TxtIkametgah.Text, TxtTelefonNo.Text, TxtBankaSubesi.Text, TxtIban.Text, DtgKiraBasTarihi.Value, TxtTutar.Text.ConInt(), TxtDepozito.Text.ConInt(), dosyaYolu, siparisNo);

                    kiraManager.Add(kira);
                }
                else
                {
                    DateTime dateTime;
                    dateTime = "31.12.1990".ConTime();
                    Kira kira = new Kira(TxtYerleskeAdi.Text, TxtYerleskeAdresi.Text, CmbMulkiyetBilgileri.Text, "-", "-", "-", "-", "-", "-", dateTime, 0, 0, dosyaYolu, siparisNo);

                    kiraManager.Add(kira);
                }
                
            }
            MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            start = false;
            YerleskeAdlari();
            start = true;
            Temizle();

        }
        void Temizle()
        {
            TxtYerleskeAdi.Clear(); CmbMulkiyetBilgileri.SelectedIndex = -1; TxtYerleskeAdresi.Clear(); CmbAbonelikTuru.SelectedValue = "";
            TxtHizmetAlinanKurum.Clear(); TxtTesisatNumarasi.Clear(); TxtAdiSoyadi.Clear(); TxtTC.Clear(); TxtIkametgah.Clear(); TxtTelefonNo.Clear(); TxtBankaSubesi.Clear(); TxtIban.Clear(); TxtTutar.Clear(); TxtDepozito.Clear(); webBrowser1.Navigate(""); webBrowser2.Navigate("");
            DtgAbonelikler.Rows.Clear();
        }

        private void BtnDosyaEkleKira_Click(object sender, EventArgs e)
        {
            if (dosyaYolu=="")
            {
                MessageBox.Show("Lütfen Öncelikle Yerleşke Bilgilerini Doldurunuz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (TxtYerleskeAdi.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Yerleşke Bilgilerini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\YERLEŞKELER\";

            dosyaAdi = TxtYerleskeAdi.Text + "_" + "ABONELİKLERİ";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyaYolu = subdir + dosyaAdi;
            Directory.CreateDirectory(subdir + dosyaAdi);

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
                webBrowser2.Navigate(dosyaYolu);
                dosyaKontrol = true;

            }
        }

        private void CmbYerleskeAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start==false)
            {
                return;
            }
            int id = CmbYerleskeAdi.SelectedValue.ConInt();
            Kira kira = kiraManager.Get(id);

            TxtYerleskeAdi.Text = kira.YerleskeAdi;
            CmbMulkiyetBilgileri.Text = kira.MulkiyetBilgileri;
            TxtYerleskeAdresi.Text = kira.YerleskeAdresi;
            TxtAdiSoyadi.Text = kira.AdiSoyadi;
            TxtTC.Text = kira.Tc;
            TxtIkametgah.Text = kira.Ikametgah;
            TxtTelefonNo.Text = kira.Telefon;
            TxtBankaSubesi.Text = kira.BankaSubesi;
            TxtIban.Text = kira.IbanNo;
            DtgKiraBasTarihi.Value = kira.KiraBaslangicTarihi;
            TxtTutar.Text = kira.KiraTutar.ToString();
            TxtDepozito.Text = kira.Depozito.ToString();
            dosyaYolu = kira.DosyaYolu;
            siparisNoKontrol = kira.SiparisNo;
            webBrowser1.Navigate(dosyaYolu);
            webBrowser2.Navigate(dosyaYolu);

            yerleskes = yerleskeManager.GetList(siparisNoKontrol);

            var liste = yerleskes.Select(x => new { x.AboneTuru, x.HizmetAlinanKurum, x.AboneTesisatNo, x.AboneTarihi }).ToList();

            foreach (var item in liste)
            {
                DtgAbonelikler.Rows.Add();
                int sonSatir = DtgAbonelikler.Rows.Count - 1;
                DtgAbonelikler.Rows[sonSatir].Cells["AboneTuru"].Value = item.AboneTuru.ToString();
                DtgAbonelikler.Rows[sonSatir].Cells["HizmetAlinanKurum"].Value = item.HizmetAlinanKurum.ToString();
                DtgAbonelikler.Rows[sonSatir].Cells["AboneTesisatNo"].Value = item.AboneTesisatNo.ToString();
                DtgAbonelikler.Rows[sonSatir].Cells["AboneTarihi"].Value = item.AboneTarihi.ToString("dd.MM.yyyy");

            }
        }

        private void BtnAboneTuruEkle_Click(object sender, EventArgs e)
        {
            comboAd = "ABONE_TURU";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }
        void TemizleAbonelik()
        {
            CmbAbonelikTuru.SelectedValue = "";
            TxtHizmetAlinanKurum.Clear();
            TxtTesisatNumarasi.Clear();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (CmbAbonelikTuru.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Abonelik Türü Bilgisini Giriniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (TxtHizmetAlinanKurum.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Hizmet Alınan Kurum Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtTesisatNumarasi.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Tesisat Numarasi Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DtgAbonelikler.Rows.Add();
            int sonSatir = DtgAbonelikler.RowCount - 1;
            DtgAbonelikler.Rows[sonSatir].Cells["AboneTuru"].Value = CmbAbonelikTuru.Text;
            DtgAbonelikler.Rows[sonSatir].Cells["HizmetAlinanKurum"].Value = TxtHizmetAlinanKurum.Text;
            DtgAbonelikler.Rows[sonSatir].Cells["AboneTesisatNo"].Value = TxtTesisatNumarasi.Text;
            DtgAbonelikler.Rows[sonSatir].Cells["AboneTarihi"].Value = DtgAboneTarihi.Value.ToString("dd,MM,yyyy");

            TemizleAbonelik();
        }

        private void BtbnDosyaEkleAbonelik_Click(object sender, EventArgs e)
        {
            if (TxtYerleskeAdi.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Yerleşke Adı Bilgisini Doldurunuz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\YERLEŞKELER\";

            dosyaAdi = TxtYerleskeAdi.Text +"_"+ "ABONELİKLERİ";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyaYolu = subdir + dosyaAdi;
            Directory.CreateDirectory(subdir + dosyaAdi);

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
