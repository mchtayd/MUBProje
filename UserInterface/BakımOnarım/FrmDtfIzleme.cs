using Business.Concreate.BakimOnarim;
using DataAccess.Concreate;
using Entity.BakimOnarim;
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

namespace UserInterface.BakımOnarım
{
    public partial class FrmDtfIzleme : Form
    {
        DtfManager dtfManager;

        List<Dtf> dtfsDevamEden;
        List<Dtf> dtfsTamamlanan;

        string dosyaYolu;
        public FrmDtfIzleme()
        {
            InitializeComponent();
            dtfManager = DtfManager.GetInstance();
        }

        private void FrmDtfIzleme_Load(object sender, EventArgs e)
        {
            DataDisplayDevamEden();
            DataDisplayTamamlanan();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDTFIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void DataDisplayDevamEden()
        {
            dtfsDevamEden = dtfManager.GetList("DEVAM EDEN");
            dataBinder.DataSource = dtfsDevamEden.ToDataTable();
            DtgDevamEden.DataSource = dataBinder;
            TxtTop.Text = DtgDevamEden.RowCount.ToString();

            DtgDevamEden.Columns["Id"].Visible = false;
            DtgDevamEden.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgDevamEden.Columns["AdiSoyadi"].HeaderText = "ADI SOYADI";
            DtgDevamEden.Columns["KayitTarihi"].HeaderText = "KAYIT TARİHİ";
            DtgDevamEden.Columns["Donem"].HeaderText = "DÖNEM";
            DtgDevamEden.Columns["ButceKodu"].HeaderText = "HARCAMA KODU KALEMİ";
            DtgDevamEden.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgDevamEden.Columns["UsBolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgDevamEden.Columns["ProjeKodu"].HeaderText = "PROJE KODU";
            DtgDevamEden.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgDevamEden.Columns["IsKategorisi"].HeaderText = "İŞ KATEGORİSİ";
            DtgDevamEden.Columns["IsTanimi"].HeaderText = "İŞ TANIMI";
            DtgDevamEden.Columns["StokNo"].HeaderText = "STOK NO";
            DtgDevamEden.Columns["Tanim"].HeaderText = "TANIM";
            DtgDevamEden.Columns["OnarimYeri"].HeaderText = "ONARIM YERİ";
            DtgDevamEden.Columns["AltYukleniciFirma"].HeaderText = "ALT YÜKLENİCİ FİRMA";
            DtgDevamEden.Columns["FirmaSorumlusu"].HeaderText = "FİRMA SORUMLUSU";
            DtgDevamEden.Columns["IsinVerildigiTarih"].HeaderText = "İŞİN VERİLDİĞİ TARİH";
            DtgDevamEden.Columns["IsBaslamaTarihi"].Visible = false;
            DtgDevamEden.Columns["IsBitisTarihi"].Visible = false;
            DtgDevamEden.Columns["YapilanIslemler"].Visible = false;
            DtgDevamEden.Columns["DosyaYolu"].Visible = false;
            DtgDevamEden.Columns["SeriNo"].HeaderText = "SERİ NO";

            DtgDevamEden.Columns["SeriNo"].DisplayIndex = 14;
        }
        void DataDisplayTamamlanan()
        {
            dtfsTamamlanan = dtfManager.GetList("TAMAMLANAN");
            dataBinderTamamlanan.DataSource = dtfsTamamlanan.ToDataTable();
            DtgTamamlanan.DataSource = dataBinderTamamlanan;
            TxtTop2.Text = DtgTamamlanan.RowCount.ToString();

            DtgTamamlanan.Columns["Id"].Visible = false;
            DtgTamamlanan.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgTamamlanan.Columns["AdiSoyadi"].HeaderText = "ADI SOYADI";
            DtgTamamlanan.Columns["KayitTarihi"].HeaderText = "KAYIT TARİHİ";
            DtgTamamlanan.Columns["Donem"].HeaderText = "DÖNEM";
            DtgTamamlanan.Columns["ButceKodu"].HeaderText = "HARCAMA KODU KALEMİ";
            DtgTamamlanan.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgTamamlanan.Columns["UsBolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgTamamlanan.Columns["ProjeKodu"].HeaderText = "PROJE KODU";
            DtgTamamlanan.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgTamamlanan.Columns["IsKategorisi"].HeaderText = "İŞ KATEGORİSİ";
            DtgTamamlanan.Columns["IsTanimi"].HeaderText = "İŞ TANIMI";
            DtgTamamlanan.Columns["StokNo"].HeaderText = "STOK NO";
            DtgTamamlanan.Columns["Tanim"].HeaderText = "TANIM";
            DtgTamamlanan.Columns["OnarimYeri"].HeaderText = "ONARIM YERİ";
            DtgTamamlanan.Columns["AltYukleniciFirma"].HeaderText = "ALT YÜKLENİCİ FİRMA";
            DtgTamamlanan.Columns["FirmaSorumlusu"].HeaderText = "FİRMA SORUMLUSU";
            DtgTamamlanan.Columns["IsinVerildigiTarih"].HeaderText = "İŞİN VERİLDİĞİ TARİH";
            DtgTamamlanan.Columns["IsBaslamaTarihi"].HeaderText = "İŞE BAŞLAMA TARİHİ";
            DtgTamamlanan.Columns["IsBitisTarihi"].HeaderText = "İŞ BİTİŞ TARİHİ";
            DtgTamamlanan.Columns["YapilanIslemler"].HeaderText = "YAPILAN İŞLEMLER";
            DtgTamamlanan.Columns["DosyaYolu"].Visible = false;
            DtgTamamlanan.Columns["SeriNo"].HeaderText = "SERİ NO";

            DtgTamamlanan.Columns["SeriNo"].DisplayIndex = 14;
        }

        private void DtgDevamEden_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgDevamEden.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyaYolu = DtgDevamEden.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void DtgDevamEden_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgDevamEden.FilterString;
            TxtTop.Text = DtgDevamEden.RowCount.ToString();
        }

        private void DtgDevamEden_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgDevamEden.SortString;
        }

        private void DtgTamamlanan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgTamamlanan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyaYolu = DtgTamamlanan.CurrentRow.Cells["DosyaYolu"].Value.ToString();

            try
            {
                webBrowser2.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
