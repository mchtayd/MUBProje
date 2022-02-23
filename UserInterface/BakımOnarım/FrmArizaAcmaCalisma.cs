using Business;
using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarim;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.BakımOnarım
{
    public partial class FrmArizaAcmaCalisma : Form
    {
        ComboManager comboManager;
        SatTalebiDoldurManager satTalebiDoldurManager;
        BolgeManager bolgeManager;
        PersonelKayitManager kayitManager;
        IsAkisNoManager isAkisNoManager;
        ArizaKayitManager arizaKayitManager;
        AbfFormNoManager abfFormNoManager;
        MalzemeKayitManager malzemeKayitManager;
        bool start = true, dosyaKontrol = false, kayitKontrol = false;
        public object[] infos;
        string isAkisNo, dosyaYolu, kaynakdosyaismi, alinandosya, proje, siparisNo;
        List<string> fileNames = new List<string>();
        int abfForm, id;
        public FrmArizaAcmaCalisma()
        {
            InitializeComponent();
            comboManager = ComboManager.GetInstance();
            satTalebiDoldurManager = SatTalebiDoldurManager.GetInstance();
            bolgeManager = BolgeManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            abfFormNoManager = AbfFormNoManager.GetInstance();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
        }

        private void FrmArizaAcmaCalisma_Load(object sender, EventArgs e)
        {
            CmbProj();
            UsBolgeleri();
            Personeller();
            Personeller2();
            IsAkisNo();
            CmbStokNo();
            Kategori();
            start = false;
            LblArizaBildirimiAlan.Text = infos[1].ToString();
        }
        int AbfFormNo()
        {
            abfFormNoManager.Update();
            AbfFormNo abfFormNo = abfFormNoManager.Get();
            return abfFormNo.FormNo;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (kayitKontrol == false)
            {
                if (dosyaKontrol==true)
                {
                    Directory.Delete(dosyaYolu, true);
                }
            }

            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageArizaAc"]);
            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void CmbStokNo()
        {
            CmbParcaNo.DataSource = malzemeKayitManager.UstTakimGetList();
            CmbParcaNo.ValueMember = "Id";
            CmbParcaNo.DisplayMember = "Tanim";
            CmbParcaNo.SelectedValue = 0;
        }

        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        void Kategori()
        {
            CmbKategori.DataSource = comboManager.GetList("ABF KATEGORİ");
            CmbKategori.ValueMember = "Id";
            CmbKategori.DisplayMember = "Baslik";
            CmbKategori.SelectedValue = 0;
        }

        void Personeller()
        {
            CmbGorevAtanacakPersonel.DataSource = kayitManager.PersonelAdSoyad();
            CmbGorevAtanacakPersonel.ValueMember = "Id";
            CmbGorevAtanacakPersonel.DisplayMember = "Adsoyad";
            CmbGorevAtanacakPersonel.SelectedValue = -1;
        }
        void Personeller2()
        {
            CmbPersoneller.DataSource = kayitManager.PersonelAdSoyad();
            CmbPersoneller.ValueMember = "Id";
            CmbPersoneller.DisplayMember = "Adsoyad";
            CmbPersoneller.SelectedValue = -1;
        }
        void CmbProj()
        {
            CmbProje.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProje.ValueMember = "Id";
            CmbProje.DisplayMember = "Baslik";
            CmbProje.SelectedValue = 0;
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtAbfFormNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle ABF NO Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ArizaKayit arizaKayit = arizaKayitManager.Get(TxtAbfFormNo.Text.ConInt());
            if (arizaKayit == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz ABF Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleSiparisOlustur();
                return;
            }
            LblBolgeAdi.Text = arizaKayit.BolgeAdi;
            TxtBildirilenArizaSiparis.Text = arizaKayit.BildirilenAriza;
            TxtArizaBildirenSiparis.Text = arizaKayit.ArizaiBildirenPersonel;
            TxtArizaBildirenRutbesi.Text = arizaKayit.AbRutbesi;
            TxtArizaBildirenGorevi.Text = arizaKayit.AbGorevi;
            TxtArizaBildirenTarih.Value = arizaKayit.AbTarihSaat;
            TxtArizaBildirenSaat.Value = arizaKayit.AbTarihSaat;
        }
        void TemizleSiparisOlustur()
        {
            TxtAbfFormNo.Clear(); LblBolgeAdi.Text = "-"; TxtBildirilenArizaSiparis.Clear(); CmbGarantiDurumu.SelectedIndex = -1;
            TxtArizaBildirenSiparis.Clear(); TxtArizaBildirenRutbesi.Clear(); TxtArizaBildirenGorevi.Clear();
            TxtLojistikSorumlusu.Clear(); TxtLojistikSorRutbesi.Clear(); TxtLojistikSorGorevi.Clear();
        }

        private void BtnPersonelEkle_Click(object sender, EventArgs e)
        {

        }

        private void CmbParcaNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            id = CmbParcaNo.SelectedValue.ConInt();
            MalzemeKayit personelKayit = malzemeKayitManager.Get(id);
            if (personelKayit == null)
            {
                LbStokNo.Text = "";
                return;
            }
            LbStokNo.Text = personelKayit.Stokno;
        }

        void UsBolgeleri()
        {
            CmbBolgeAdi.DataSource = satTalebiDoldurManager.GetList();
            CmbBolgeAdi.ValueMember = "Id";
            CmbBolgeAdi.DisplayMember = "Usbolgesi";
            CmbBolgeAdi.SelectedValue = "";
        }

        private void BtnBolgeEkle_Click(object sender, EventArgs e)
        {
            FrmBolgeler frmBolgeler = new FrmBolgeler();
            frmBolgeler.ShowDialog();
        }

        private void CmbBolgeAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start==true)
            {
                return;
            }
            string bolgeAdi = CmbBolgeAdi.Text;
            Bolge bolge = bolgeManager.Get(bolgeAdi);

            proje = bolge.Proje;
            LblBolukKomutanı.Text = bolge.IlgiliPersonel;
            LblTelefon.Text = bolge.Telefon;
            LblBirlilkAdresi.Text = bolge.BirlikAdresi;
            LblIl.Text = bolge.Il;
            LblIlce.Text = bolge.Ilce;
        }

        private void CmbGarantiDurumu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = CmbGarantiDurumu.SelectedIndex;
            if (index == 0)
            {
                LblLojistik.Visible = false;
                TxtLojistikSorumlusu.Visible = false;
                TxtLojistikSorRutbesi.Visible = false;
                TxtLojistikSorGorevi.Visible = false;
                DtLojistikTarih.Visible = false;
                DtLojistikSaat.Visible = false;
            }
            if (index == 1)
            {
                LblLojistik.Visible = true;
                TxtLojistikSorumlusu.Visible = true;
                TxtLojistikSorRutbesi.Visible = true;
                TxtLojistikSorGorevi.Visible = true;
                DtLojistikTarih.Visible = true;
                DtLojistikSaat.Visible = true;
            }
            
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            IsAkisNo();
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\BAKIM ONARIM\";

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
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                siparisNo = Guid.NewGuid().ToString();

                abfForm = AbfFormNo();

                ArizaKayit arizaKayit = new ArizaKayit(LblIsAkisNo.Text.ConInt(), abfForm, proje, CmbBolgeAdi.Text, LblBolukKomutanı.Text, LblTelefon.Text, LblBirlilkAdresi.Text, LblIl.Text, LblIlce.Text, TxtBildirilenAriza.Text, TxtBirlikPersoneli.Text, TxtBirlikPerRutbesi.Text, TxtBirlikPerGorevi.Text, TxtABTelefon.Text,DateTime.Now, LblArizaBildirimiAlan.Text, CmbBildirimKanali.Text, TxtArizaAciklama.Text, CmbGorevAtanacakPersonel.Text, LblIslemAdimi.Text, dosyaYolu, siparisNo);

                string mesaj = arizaKayitManager.Add(arizaKayit);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                IsAkisNo();
                Temizle();
                kayitKontrol = true;
            }
        }
        void Temizle()
        {
            CmbProje.SelectedValue = ""; CmbBolgeAdi.SelectedValue = ""; LblBolukKomutanı.Text = "-"; LblTelefon.Text = "-";
            LblBirlilkAdresi.Text = "-"; LblIl.Text = "-"; LblIlce.Text = "-"; TxtBildirilenAriza.Clear(); TxtBirlikPersoneli.Clear();
            TxtBirlikPerRutbesi.Clear(); TxtBirlikPerGorevi.Clear(); TxtABTelefon.Clear(); CmbBildirimKanali.Text = "";
            TxtArizaAciklama.Clear(); webBrowser1.Navigate("");
            
        }

    }
}
