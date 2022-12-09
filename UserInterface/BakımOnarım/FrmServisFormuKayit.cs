using Business;
using Business.Concreate;
using Business.Concreate.AnaSayfa;
using Business.Concreate.BakimOnarim;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity;
using Entity.AnaSayfa;
using Entity.BakimOnarim;
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

namespace UserInterface.BakımOnarım
{
    public partial class FrmServisFormuKayit : Form
    {
        IsAkisNoManager isAkisNoManager;
        SatTalebiDoldurManager satTalebiDoldurManager;
        AltYukleniciManager altYukleniciManager;
        ServisFormuManager servisFormuManager;
        SFYedekParcaManager sFYedekParcaManager;
        BildirimYetkiManager bildirimYetkiManager;

        public object[] infos;

        bool dosyaEkle = false;
        string dosyaYolu = "", siparisNo = "", isAkisNo, kaynakdosyaismi, alinandosya;
        int id;
        public FrmServisFormuKayit()
        {
            InitializeComponent();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            altYukleniciManager = AltYukleniciManager.GetInstance();
            satTalebiDoldurManager = SatTalebiDoldurManager.GetInstance();
            servisFormuManager = ServisFormuManager.GetInstance();
            sFYedekParcaManager = SFYedekParcaManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
        }

        private void FrmServisFormuKayit_Load(object sender, EventArgs e)
        {
            CmbIslemTuru.SelectedIndex = 0;
            IsAkisNo();
            UsBolgeleri();
            Firmalar();
            
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageServisFormuKayit"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        public void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }

        private void BtnFirmaEkle_Click(object sender, EventArgs e)
        {
            FrmAltYukleniciFirma frmBolgeler = new FrmAltYukleniciFirma();
            frmBolgeler.button5.Visible = false;
            frmBolgeler.ShowDialog();
        }
        void UsBolgeleri()
        {
            CmbBolgeAdi.DataSource = satTalebiDoldurManager.GetList();
            CmbBolgeAdi.ValueMember = "Id";
            CmbBolgeAdi.DisplayMember = "Usbolgesi";
            CmbBolgeAdi.SelectedValue = "";
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNo.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Geçerli Bir İş Akış No Bilgisi Giriniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            DateTime basTarihi = new DateTime(DtBaslamaTarihi.Value.Year, DtBaslamaTarihi.Value.Month, DtBaslamaTarihi.Value.Day, DtBaslamaTarihiSaati.Value.Hour, DtBaslamaTarihiSaati.Value.Minute, DtBaslamaTarihiSaati.Value.Second);
            DateTime bitisTarihi = new DateTime(DtBitisTarihi.Value.Year, DtBitisTarihi.Value.Month, DtBitisTarihi.Value.Day, DtBitisTarihiSaati.Value.Hour, DtBitisTarihiSaati.Value.Minute, DtBitisTarihiSaati.Value.Second);

            ServisFormu servisFormu = new ServisFormu(id, CmbFirma.Text, CmbBolgeAdi.Text, TxtServisFormNo.Text, CmbMudehaleTuru.Text, DtgServisTarihi.Value, TxtJenaratorCalismaSaati.Text.ConInt(), basTarihi, bitisTarihi, TxtMarka.Text, TxtModel.Text, TxtSeriNo.Text, TxtGuc.Text, TxtServisRaporu.Text, TxtServisYetkilisi.Text, TxtMusteri.Text);

            string mesaj = servisFormuManager.Update(servisFormu, id);

            if (mesaj!="OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            /*sFYedekParcaManager.Delete(siparisNo);
            int sonSayi = DtgKullanilanMalzemeler.RowCount - 1;
            int sayac = 0;
            foreach (DataGridViewRow item in DtgKullanilanMalzemeler.Rows)
            {
                if (sayac == sonSayi)
                {
                    break;
                }
                SFYedekPaca sFYedekPaca = new SFYedekPaca(item.Cells["ParcaKodu"].Value.ToString(), item.Cells["KullanilanMalzeme"].Value.ToString(), item.Cells["Adet"].Value.ToString(), siparisNo);

                sFYedekParcaManager.Add(sFYedekPaca);
            }*/
            IsAkisNo();
            MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
        }
        

        private void CmbIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbIslemTuru.SelectedIndex == 0)
            {
                TxtIsAkisNo.Visible = false;
                BtnBul.Visible = false;
                BtnGuncelle.Visible = false;
                IsAkisNo();
                Temizle();
                groupBox3.Enabled = true;
            }
            if (CmbIslemTuru.SelectedIndex == 1)
            {
                TxtIsAkisNo.Visible = true;
                BtnBul.Visible = true;
                BtnGuncelle.Visible = true;
                IsAkisNo();
                Temizle();
                groupBox3.Enabled = false;
            }
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNo.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Geçerli Bir İş Akış No Bilgisi Giriniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            ServisFormu servis = servisFormuManager.Get(TxtIsAkisNo.Text.ConInt());
            CmbFirma.Text = servis.Firma;
            CmbBolgeAdi.Text = servis.UsBolgesi;
            TxtServisFormNo.Text = servis.ServisFormNo;
            CmbMudehaleTuru.Text = servis.MudehaleTuru;
            DtgServisTarihi.Value = servis.ServisTarihi;
            TxtJenaratorCalismaSaati.Text = servis.JenaratorCalismaSaati.ToString();
            DtBaslamaTarihi.Value = servis.IsBaslamaTarihi;
            DtBaslamaTarihiSaati.Value = servis.IsBaslamaTarihi;
            DtBitisTarihi.Value = servis.IsBitisTarihi;
            DtBitisTarihiSaati.Value = servis.IsBitisTarihi;
            TxtMarka.Text = servis.Marka;
            TxtModel.Text = servis.Model;
            TxtSeriNo.Text = servis.SeriNo;
            TxtGuc.Text = servis.Guc;
            TxtServisRaporu.Text = servis.ServisRaporu;
            TxtServisYetkilisi.Text = servis.ServisYetkilisi;
            TxtMusteri.Text = servis.Musteri;
            siparisNo = servis.SiparisNo;
            id = servis.Id;
            MalzemeleriGetir();
            try
            {
                webBrowser1.Navigate(servis.DosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
            
        }
        void MalzemeleriGetir()
        {

            
            /*DtgKullanilanMalzemeler.Rows.Clear();
            List<SFYedekPaca> sFYedeks = new List<SFYedekPaca>();
            sFYedeks = sFYedekParcaManager.GetList(siparisNo);
            int sonSatir = DtgKullanilanMalzemeler.RowCount;
            

            foreach (SFYedekPaca item in sFYedeks)
            {
                DtgKullanilanMalzemeler.Rows.Add();
                sonSatir = DtgKullanilanMalzemeler.RowCount - 1;
                DtgKullanilanMalzemeler.Rows[sonSatir].Cells["ParcaKodu"].Value = item.ParcaKodu;
                DtgKullanilanMalzemeler.Rows[sonSatir].Cells["KullanilanMalzeme"].Value = item.KullanilanMalzeme;
                DtgKullanilanMalzemeler.Rows[sonSatir].Cells["Adet"].Value = item.Adet;
                
            }*/
            
            /*for (int i = 0; i < sFYedeks.Count; i++)
            {
                DtgKullanilanMalzemeler.Rows.Add();
                int sonSatir = sFYedeks.Count - 1;
                
                DtgKullanilanMalzemeler.Rows[sonSatir].Cells["ParcaKodu"].Value = sFYedeks[i].ParcaKodu;
                DtgKullanilanMalzemeler.Rows[sonSatir].Cells["KullanilanMalzeme"].Value = sFYedeks[i].KullanilanMalzeme;
                DtgKullanilanMalzemeler.Rows[sonSatir].Cells["Adet"].Value = sFYedeks[i].Adet;

            }*/

        }

        void Firmalar()
        {
            CmbFirma.DataSource = altYukleniciManager.GetList(0);
            CmbFirma.ValueMember = "Id";
            CmbFirma.DisplayMember = "Firmaadi";
            CmbFirma.SelectedValue = "";

        }
        string BildirimKayit()
        {
            string[] array = new string[8];

            array[0] = "Servis Formu Kayıt"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = LblIsAkisNo.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "iş akış numaralı"; // Bildirim türü
            array[4] = CmbBolgeAdi.Text + " Üs bölgesi için"; // İÇERİK
            array[5] = DtgServisTarihi.Value.ToString("d") + " servis tarihli";
            array[6] = "kaydı oluşturmuştur!";

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

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (dosyaEkle == false)
            {
                MessageBox.Show("Lütfen Öncelikle Servis Formunu Ekler Kısmıne Ekleyiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                siparisNo = Guid.NewGuid().ToString();

                DateTime basTarihi = new DateTime(DtBaslamaTarihi.Value.Year, DtBaslamaTarihi.Value.Month, DtBaslamaTarihi.Value.Day, DtBaslamaTarihiSaati.Value.Hour, DtBaslamaTarihiSaati.Value.Minute, DtBaslamaTarihiSaati.Value.Second);
                DateTime bitisTarihi = new DateTime(DtBitisTarihi.Value.Year, DtBitisTarihi.Value.Month, DtBitisTarihi.Value.Day, DtBitisTarihiSaati.Value.Hour, DtBitisTarihiSaati.Value.Minute, DtBitisTarihiSaati.Value.Second);

                ServisFormu servisFormu = new ServisFormu(LblIsAkisNo.Text.ConInt(), CmbFirma.Text, CmbBolgeAdi.Text, TxtServisFormNo.Text, CmbMudehaleTuru.Text, DtgServisTarihi.Value, TxtJenaratorCalismaSaati.Text.ConInt(), basTarihi, bitisTarihi, TxtMarka.Text, TxtModel.Text, TxtSeriNo.Text, TxtGuc.Text, TxtServisRaporu.Text, TxtServisYetkilisi.Text, TxtMusteri.Text, dosyaYolu, siparisNo);

                string mesaj = servisFormuManager.Add(servisFormu);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                int sonSayi = DtgKullanilanMalzemeler.RowCount - 1;
                int sayac = 0;
                foreach (DataGridViewRow item in DtgKullanilanMalzemeler.Rows)
                {
                    if (sayac== sonSayi)
                    {
                        break;
                    }
                    SFYedekPaca sFYedekPaca = new SFYedekPaca(item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString(), item.Cells[2].Value.ToString(),siparisNo);

                    sFYedekParcaManager.Add(sFYedekPaca);
                    sayac++;
                }
                IsAkisNo();
                mesaj = BildirimKayit();
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                dosyaEkle = false;
                Temizle();

            }
        }
        void Temizle()
        {
            CmbFirma.SelectedValue = ""; CmbBolgeAdi.SelectedIndex = -1; TxtServisFormNo.Clear(); CmbMudehaleTuru.SelectedIndex = -1; DtBaslamaTarihiSaati.Text = "00:00"; DtBitisTarihiSaati.Text = "00:00"; TxtJenaratorCalismaSaati.Clear(); TxtMarka.Clear(); TxtModel.Clear(); TxtSeriNo.Clear(); TxtGuc.Clear();
            TxtServisRaporu.Clear(); DtgKullanilanMalzemeler.Rows.Clear(); TxtServisYetkilisi.Clear(); TxtMusteri.Clear(); webBrowser1.Navigate("");
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            IsAkisNo();
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\BAKIM ONARIM\SERVİS FORMLARI\";

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
                webBrowser1.Navigate(dosyaYolu);
                dosyaEkle = true;
            }
        }
    }
}
