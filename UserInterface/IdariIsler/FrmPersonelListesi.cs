using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Abstract;
using DataAccess.Concreate;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.IdariIşler
{
    public partial class FrmPersonelListesi : Form
    {
        public object[] infos3;
        PersonelKayitManager personelKayitManager;
        DevamEdenIzlemeManager devamEdenIzlemeManager;
        List<PersonelKayit> personelKayits;
        List<PersonelKayit> personellerFiltered;
        string dosyayolu = @"Z:\DTS\İDARİ İŞLER\PERSONELLER\";
        //string dosyayolu = @"C:\STS\Personel Dosyaları\";
        string dosyayolutam;
        public object[] infos;

        public FrmPersonelListesi()
        {
            InitializeComponent();
            personelKayitManager = PersonelKayitManager.GetInstance();
            devamEdenIzlemeManager = DevamEdenIzlemeManager.GetInstance();
        }

        private void FrmPersonelListesi_Load(object sender, EventArgs e)
        {
            Doldur();
            DataDisplay();
        }
        public void YenilenecekVeri()
        {
            Doldur();
            DataDisplay();
        }
        void Doldur()
        {
            personelKayits = personelKayitManager.GetList();
            personellerFiltered = personelKayits;
            dataBinder.DataSource = personelKayits.ToDataTable();
            DtgPersoneller.DataSource = dataBinder;
     
            TxtKisiSayisi.Text = DtgPersoneller.RowCount.ToString();
        }

        void DataDisplay()
        {
            DtgPersoneller.Columns["Id"].Visible = false;
            DtgPersoneller.Columns["Tc"].Visible = false;
            DtgPersoneller.Columns["Cocuksayisi"].Visible = false;
            DtgPersoneller.Columns["Maas"].Visible = false;
            DtgPersoneller.Columns["Iase"].Visible = false;
            DtgPersoneller.Columns["Kirayardimi"].Visible = false;
            DtgPersoneller.Columns["Diplomanotu"].Visible = false;
            DtgPersoneller.Columns["Heskodu"].Visible = false;
            DtgPersoneller.Columns["Sigortasicilno"].Visible = false;
            DtgPersoneller.Columns["Ikametgah"].Visible = false;
            DtgPersoneller.Columns["Kangrubu"].Visible = false;
            DtgPersoneller.Columns["Esad"].Visible = false;
            DtgPersoneller.Columns["Estelefon"].Visible = false;
            DtgPersoneller.Columns["Medenidurumu"].Visible = false;
            DtgPersoneller.Columns["Esisdurumu"].Visible = false;
            DtgPersoneller.Columns["Dogumyeri"].Visible = false;
            DtgPersoneller.Columns["Sicil"].Visible = false;
            DtgPersoneller.Columns["Masyerino"].Visible = false;
            DtgPersoneller.Columns["Masrafyeri"].Visible = false;
            DtgPersoneller.Columns["Sirketmail"].Visible = false;
            DtgPersoneller.Columns["Oficemail"].Visible = false;
            DtgPersoneller.Columns["Sirketcep"].Visible = false;
            DtgPersoneller.Columns["Sirketkisakod"].Visible = false;
            DtgPersoneller.Columns["Dahilino"].Visible = false;
            DtgPersoneller.Columns["Askerlikdurumu"].Visible = false;
            DtgPersoneller.Columns["Askerliksinifi"].Visible = false;
            DtgPersoneller.Columns["Rubesi"].Visible = false;
            DtgPersoneller.Columns["Gorevi"].Visible = false;
            DtgPersoneller.Columns["Gorevyeri"].Visible = false;
            DtgPersoneller.Columns["Tecilsebebi"].Visible = false;
            DtgPersoneller.Columns["Okul"].Visible = false;
            DtgPersoneller.Columns["Muafnedeni"].Visible = false;
            DtgPersoneller.Columns["Dogumtarihi"].Visible = false;
            DtgPersoneller.Columns["Isegiristarihi"].Visible = false;
            DtgPersoneller.Columns["Askerlikbastarihi"].Visible = false;
            DtgPersoneller.Columns["Askerlikbittarihi"].Visible = false;
            DtgPersoneller.Columns["Tecilbittarihi"].Visible = false;
            DtgPersoneller.Columns["SiparisNo"].Visible = false;
            DtgPersoneller.Columns["Bolum"].Visible = false;
            DtgPersoneller.Columns["Dosyayolu"].Visible = false;
            DtgPersoneller.Columns["Fotoyolu"].Visible = false;
            DtgPersoneller.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgPersoneller.Columns["Isunvani"].HeaderText = "ÜNVANI";
            DtgPersoneller.Columns["Sirketbolum"].HeaderText = "BÖLÜM";
            DtgPersoneller.Columns["Sicil"].HeaderText = "SİCİL NUMARASI";
            DtgPersoneller.Columns["Siparis"].HeaderText = "SİPARİŞ";
            DtgPersoneller.Columns["Butcekodu"].HeaderText = "BÜTÇE KODU";
            DtgPersoneller.Columns["Butcekalemi"].HeaderText = "BÜTÇE KALEMİ";
            DtgPersoneller.Columns["MasrafYeriSorumlusu"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgPersoneller.Columns["Sat"].HeaderText = "SAT";

        }
        private void Temizle()
        {
            TxtOkul.Clear(); TxtBolum.Clear(); TxtDipNotu.Clear(); TxtDurum.Clear(); TxtSinif.Clear(); TxtRutbesi.Clear(); TxtGorevi.Clear();
            TxtGorevYeri.Clear(); TxtTecilSebebi.Clear(); TxtMuafNedeni.Clear();
            Txtadsoyad.Clear(); MsdTc.Clear(); TxtHes.Clear(); TxtSicilno.Clear(); TxtKan.Clear(); TxtEsad.Clear(); MsdEsTelefon.Clear();
            TxtIkametgah.Clear(); TxtMedeniDurum.Clear(); TxtEsIsDurumu.Clear(); TxtCocukSayisi.Clear(); TxtDogumYeri.Clear(); TxtSiparis.Clear(); TxtSat.Clear();
            TxtButceKodu.Clear(); TxtButceKalemi.Clear(); TxtSicil.Clear(); TxtMasrafYeriNo.Clear(); TxtMasrafYeri.Clear(); MsdSırketCepNo.Clear(); MsdKisaKod.Clear();
            MsdDahiliNo.Clear(); TxtIsUnvani.Clear(); TxtSirketMail.Clear(); TxtOfficeMail.Clear();
        }
        private void FillTools()
        {
            Temizle();

            if (personelKayits == null)
            {
                return;
            }
            if (personelKayits.Count == 0)
            {
                return;
            }
            if (personelKayits.Count > 0)
            {
                PersonelKayit item = personelKayits[0];
                Txtadsoyad.Text = item.Adsoyad;
                MsdTc.Text = item.Tc;
                TxtHes.Text = item.Heskodu;
                TxtSicilno.Text = item.Sigortasicilno;
                TxtIkametgah.Text = item.Ikametgah;
                TxtKan.Text = item.Kangrubu;
                TxtEsad.Text = item.Esad;
                MsdEsTelefon.Text = item.Estelefon;
                MsdDogumTarihi.Text = item.Dogumtarihi.ToString();
                TxtMedeniDurum.Text = item.Medenidurumu;
                TxtEsIsDurumu.Text = item.Esisdurumu;
                TxtCocukSayisi.Text = item.Cocuksayisi;
                TxtDogumYeri.Text = item.Dogumyeri;
                TxtOkul.Text = item.Okul;
                TxtBolum.Text = item.Bolum;
                TxtDipNotu.Text = item.Diplomanotu;
                if (item.Askerlikdurumu == "YAPTI")
                {
                    MsdBaslamaTarihi.Text = item.Askerlikbastarihi.ToString();
                    MsdBitisTarihi.Text = item.Askerlikbittarihi.ToString();
                    MsdTecilTarihi.Text = "";
                }
                if (item.Askerlikdurumu == "MUAF")
                {
                    MsdTecilTarihi.Text = "";
                    MsdBaslamaTarihi.Text = "";
                    MsdBitisTarihi.Text = "";
                }
                if (item.Askerlikdurumu == "TECİLLİ")
                {
                    MsdTecilTarihi.Text = item.Tecilbittarihi.ToString();
                    MsdBaslamaTarihi.Text = "";
                    MsdBitisTarihi.Text = "";
                }
                TxtDurum.Text = item.Askerlikdurumu;
                TxtSinif.Text = item.Askerliksinifi;
                TxtRutbesi.Text = item.Rubesi;
                TxtGorevi.Text = item.Gorevi;
                TxtGorevYeri.Text = item.Gorevyeri;
                TxtTecilSebebi.Text = item.Tecilsebebi;
                TxtMuafNedeni.Text = item.Muafnedeni;
                TxtSiparis.Text = item.Siparis;
                TxtSat.Text = item.Sat;
                TxtButceKodu.Text = item.Butcekodu;
                TxtButceKalemi.Text = item.Butcekalemi;
                TxtSicil.Text = item.Sicil;
                TxtMasrafYeriNo.Text = item.Masyerino;
                TxtMasrafYeri.Text = item.Masrafyeri;
                MsdSırketCepNo.Text = item.Sirketcep;
                MsdKisaKod.Text = item.Sirketkisakod;
                MsdDahiliNo.Text = item.Dahilino;
                TxtIsUnvani.Text = item.Isunvani;
                MsdIseGiris.Text = item.Isegiristarihi.ToString();
                TxtSirketMail.Text = item.Sirketmail;
                TxtOfficeMail.Text = item.Oficemail;
            }

            WebBrowser();

        }
        private void DtgPersoneller_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgPersoneller.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            string siparisNo = DtgPersoneller.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosyayolu = DtgPersoneller.CurrentRow.Cells["Dosyayolu"].Value.ToString();
            personelKayits = personelKayitManager.GetList(siparisNo);
            DtgIslemAdimlari.DataSource = devamEdenIzlemeManager.GetList(siparisNo);
            Islemadimlari();
            FillTools();
        }

        void WebBrowser()
        {
            //string personelismi = personelKayits[0].Adsoyad.ToString();
            //dosyayolutam = dosyayolu + personelismi;
            try
            {
                webBrowser1.Navigate(dosyayolu);
            }
            catch (Exception)
            {
                return;
            }
            
        }
        void Islemadimlari()
        {
            DtgIslemAdimlari.Columns["Id"].Visible = false;
            DtgIslemAdimlari.Columns["Siparisno"].Visible = false;
            DtgIslemAdimlari.Columns["Islem"].HeaderText = "İŞLEM ADIMI";
            DtgIslemAdimlari.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgIslemAdimlari.Columns["Tarih"].HeaderText = "TARİH";
            DtgIslemAdimlari.Columns["Islem"].Width = 220;
            DtgIslemAdimlari.Columns["Islemyapan"].Width = 120;
        }

        #region KeySettings
        private void TxtOkul_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtBolum_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtDipNotu_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtDurum_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtSinif_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtRutbesi_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtGorevi_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtGorevYeri_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void MsdBaslamaTarihi_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void MsdBitisTarihi_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void MsdTecilTarihi_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtTecilSebebi_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtMuafNedeni_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void Txtadsoyad_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void MsdTc_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtHes_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtSicilno_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtKan_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtEsad_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void MsdEsTelefon_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void MsdDogumTarihi_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtIkametgah_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtMedeniDurum_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtEsIsDurumu_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtCocukSayisi_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtDogumYeri_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtSiparis_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtSat_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtButceKodu_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtButceKalemi_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtSicil_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtMasrafYeriNo_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtMasrafYeri_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void MsdSırketCepNo_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void MsdKisaKod_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void MsdDahiliNo_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtIsUnvani_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void MsdIseGiris_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }

        private void TxtSirketMail_KeyPress(object sender, KeyPressEventArgs e) { { e.Handled = true; } }
        #endregion

        private void DtgPersoneller_FilterStringChanged(object sender, EventArgs e)
        {
            this.dataBinder.Filter = this.DtgPersoneller.FilterString;
            TxtKisiSayisi.Text = DtgPersoneller.RowCount.ToString();
        }

        private void DtgPersoneller_SortStringChanged(object sender, EventArgs e)
        {
            this.dataBinder.Sort = this.DtgPersoneller.SortString;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PagePersonelListesi"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        
        private void TxtPersonel_TextChanged(object sender, EventArgs e)
        {
            string personel = TxtPersonel.Text;
            if (string.IsNullOrEmpty(personel))
            {
                personellerFiltered = personelKayits;
                dataBinder1.DataSource = personelKayits.ToDataTable();
                DtgPersoneller.DataSource = dataBinder1;
                TxtKisiSayisi.Text = DtgPersoneller.RowCount.ToString();
                return;
            }
            if (TxtPersonel.Text.Length < 3)
            {
                return;
            }
            /*if (TxtPersonel.Text != DtgPersoneller.RowCount.ToString())
            {
                DtgPersoneller.DataSource = personelKayitManager.GetList();
                DataDisplay();
            }*/
            dataBinder1.DataSource = personellerFiltered.Where(x => x.Adsoyad.ToLower().Contains(personel.ToLower())).ToList().ToDataTable();
            DtgPersoneller.DataSource = dataBinder1;
            personellerFiltered = personelKayits;
            TxtKisiSayisi.Text = DtgPersoneller.RowCount.ToString();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doldur();
            DataDisplay();
            TxtPersonel.Clear();
        }

        private void DtgPersoneller_KeyDown(object sender, KeyEventArgs e)
        {
            if (DtgPersoneller.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            string siparisNo = DtgPersoneller.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosyayolu = DtgPersoneller.CurrentRow.Cells["Dosyayolu"].Value.ToString();
            personelKayits = personelKayitManager.GetList(siparisNo);
            DtgIslemAdimlari.DataSource = devamEdenIzlemeManager.GetList(siparisNo);
            Islemadimlari();
            FillTools();
        }
    }
}
