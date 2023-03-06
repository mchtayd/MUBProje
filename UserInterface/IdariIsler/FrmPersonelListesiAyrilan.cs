using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
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

namespace UserInterface.IdariIsler
{
    public partial class FrmPersonelListesiAyrilan : Form
    {
        IstenAyrilisManager istenAyrilisManager;
        DevamEdenIzlemeManager devamEdenIzlemeManager;
        List<IstenAyrilis> istenAyrilis;
        List<IstenAyrilis> ayrilanlar;
        List<IstenAyrilis> personellerFiltered;
        public string dosyayolu = @"Z:\DTS\İDARİ İŞLER\PERSONELLER\";
        //public string dosyayolu = @"C:\STS\Personel Dosyaları\";
        public FrmPersonelListesiAyrilan()
        {
            InitializeComponent();
            devamEdenIzlemeManager = DevamEdenIzlemeManager.GetInstance();
            istenAyrilisManager = IstenAyrilisManager.GetInstance();
        }

        private void FrmPersonelListesiAyrilan_Load(object sender, EventArgs e)
        {
            Doldur();
            DataDisplay();
        }
        public void YenilecenekVeri()
        {
            Doldur();
            DataDisplay();
        }
        void Doldur()
        {
            ayrilanlar = istenAyrilisManager.GetList();
            personellerFiltered = ayrilanlar;
            dataBinder.DataSource = ayrilanlar.ToDataTable();
            DtgPersoneller.DataSource = dataBinder;

            TxtKisiSayisi.Text = DtgPersoneller.RowCount.ToString();
        }

        void DataDisplay()
        {
            DtgPersoneller.Columns["Id"].Visible = false;
            DtgPersoneller.Columns["Tc"].Visible = false;
            DtgPersoneller.Columns["Cocuksayisi"].Visible = false;
            DtgPersoneller.Columns["Dipnotu"].Visible = false;
            DtgPersoneller.Columns["Hes"].Visible = false;
            DtgPersoneller.Columns["Sigortasicilno"].Visible = false;
            DtgPersoneller.Columns["Ikametgah"].Visible = false;
            DtgPersoneller.Columns["Kan"].Visible = false;
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
            DtgPersoneller.Columns["Rutbesi"].Visible = false;
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
            DtgPersoneller.Columns["Okulbolum"].Visible = false;
            DtgPersoneller.Columns["Dosyayolu"].Visible = false;
            DtgPersoneller.Columns["Ayrilisnedeni"].Visible = false;
            DtgPersoneller.Columns["Istenayrilisaciklama"].Visible = false;
            DtgPersoneller.Columns["Siparisno"].Visible = false;
            DtgPersoneller.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgPersoneller.Columns["Isunvani"].HeaderText = "ÜNVANI";
            DtgPersoneller.Columns["Sirketbolum"].HeaderText = "BÖLÜM";
            DtgPersoneller.Columns["Sicil"].HeaderText = "SİCİL NUMARASI";
            DtgPersoneller.Columns["Siparis"].HeaderText = "SİPARİŞ";
            DtgPersoneller.Columns["Butcekodu"].HeaderText = "BÜTÇE KODU";
            DtgPersoneller.Columns["Butcekalemi"].HeaderText = "BÜTÇE KALEMİ";
            DtgPersoneller.Columns["Sat"].HeaderText = "SAT";
            DtgPersoneller.Columns["Istenayrilistarihi"].HeaderText = "İŞTEN AYRILIŞ TARİHİ";
        }
        private void Temizle()
        {
            TxtOkul.Clear(); TxtBolum.Clear(); TxtDipNotu.Clear(); TxtDurum.Clear(); TxtSinif.Clear(); TxtRutbesi.Clear(); TxtGorevi.Clear();
            TxtGorevYeri.Clear(); TxtTecilSebebi.Clear(); TxtMuafNedeni.Clear(); TxtAyrilisNedeni.Clear(); TxtAyrilisAciklama.Clear();
            Txtadsoyad.Clear(); MsdTc.Clear(); TxtHes.Clear(); TxtSicilno.Clear(); TxtKan.Clear(); TxtEsad.Clear(); MsdEsTelefon.Clear();
            TxtIkametgah.Clear(); TxtMedeniDurum.Clear(); TxtEsIsDurumu.Clear(); TxtCocukSayisi.Clear(); TxtDogumYeri.Clear(); TxtSiparis.Clear(); TxtSat.Clear();
            TxtButceKodu.Clear(); TxtButceKalemi.Clear(); TxtSicil.Clear(); TxtMasrafYeriNo.Clear(); TxtMasrafYeri.Clear(); MsdSırketCepNo.Clear(); MsdKisaKod.Clear();
            MsdDahiliNo.Clear(); TxtIsUnvani.Clear(); TxtSirketMail.Clear(); TxtOfficeMail.Clear();
        }
        private void FillTools()
        {
            Temizle();

            if (istenAyrilis == null)
            {
                return;
            }
            if (istenAyrilis.Count == 0)
            {
                return;
            }
            if (istenAyrilis.Count > 0)
            {
                IstenAyrilis item = istenAyrilis[0];
                Txtadsoyad.Text = item.Adsoyad;
                MsdTc.Text = item.Tc;
                TxtHes.Text = item.Hes;
                TxtSicilno.Text = item.Sigortasicilno;
                TxtIkametgah.Text = item.Ikametgah;
                TxtKan.Text = item.Kan;
                TxtEsad.Text = item.Esad;
                MsdEsTelefon.Text = item.Estelefon;
                MsdDogumTarihi.Text = item.Dogumtarihi.ToString();
                TxtMedeniDurum.Text = item.Medenidurumu;
                TxtEsIsDurumu.Text = item.Esisdurumu;
                TxtCocukSayisi.Text = item.Cocuksayisi;
                TxtDogumYeri.Text = item.Dogumyeri;
                TxtOkul.Text = item.Okul;
                TxtBolum.Text = item.Okulbolum;
                TxtDipNotu.Text = item.Dipnotu;
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
                TxtRutbesi.Text = item.Rutbesi;
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
                MsdIseGiris.Value = item.Isegiristarihi;
                TxtSirketMail.Text = item.Sirketmail;
                TxtOfficeMail.Text = item.Oficemail;
                MsdAyrilisTarihi.Value = item.Istenayrilistarihi;
                TxtAyrilisNedeni.Text = item.Ayrilisnedeni;
                TxtAyrilisAciklama.Text = item.Istenayrilisaciklama;
            }
            WebBrowser();
        }
        void WebBrowser()
        {
            string personelismi = istenAyrilis[0].Adsoyad.ToString();
            string dosyayolutam = dosyayolu + personelismi;
            webBrowser1.Navigate(dosyayolutam);
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
        private void DtgPersoneller_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgPersoneller.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            int id = DtgPersoneller.CurrentRow.Cells["Id"].Value.ConInt();
            istenAyrilis = istenAyrilisManager.GetList(id);

            string siparisNo = DtgPersoneller.CurrentRow.Cells["SiparisNo"].Value.ToString();
            DtgIslemAdimlari.DataSource = devamEdenIzlemeManager.GetList(siparisNo);
            Islemadimlari();
            FillTools();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageAyrilanListesi"]);

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
                personellerFiltered = ayrilanlar;
                dataBinder.DataSource = ayrilanlar.ToDataTable();
                DtgPersoneller.DataSource = dataBinder;
                TxtKisiSayisi.Text = DtgPersoneller.RowCount.ToString();
                return;
            }
            if (TxtPersonel.Text.Length < 3)
            {
                TxtKisiSayisi.Text = DtgPersoneller.RowCount.ToString();
                return;
            }
            dataBinder.DataSource = personellerFiltered.Where(x => x.Adsoyad.ToLower().Contains(personel.ToLower())).ToList().ToDataTable();
            DtgPersoneller.DataSource = dataBinder;
            personellerFiltered = ayrilanlar;
            TxtKisiSayisi.Text = DtgPersoneller.RowCount.ToString();
        }

        private void DtgPersoneller_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgPersoneller.FilterString;
            TxtKisiSayisi.Text = DtgPersoneller.RowCount.ToString();
        }

        private void DtgPersoneller_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgPersoneller.SortString;
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
            int id = DtgPersoneller.CurrentRow.Cells["Id"].Value.ConInt();
            istenAyrilis = istenAyrilisManager.GetList(id);

            string siparisNo = DtgPersoneller.CurrentRow.Cells["SiparisNo"].Value.ToString();
            DtgIslemAdimlari.DataSource = devamEdenIzlemeManager.GetList(siparisNo);
            Islemadimlari();
            FillTools();
        }
    }
}
