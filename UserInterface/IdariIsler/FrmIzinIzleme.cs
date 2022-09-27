using Business.Concreate.IdarıIsler;
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
    public partial class FrmIzinIzleme : Form
    {
        List<Izin> ızins;
        IzinManager İzinManager;
        IdariIslerLogManager logManager;
        List<Izin> izinFiltired;
        int outValue = 0, id;
        string sayfa, dosyayolu;
        public FrmIzinIzleme()
        {
            InitializeComponent();
            İzinManager = IzinManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
        }

        private void FrmIzinIzleme_Load(object sender, EventArgs e)
        {
            DtgIzinList();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageIzinIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        public void DtgIzinList()
        {
            ızins = İzinManager.GetList();
            izinFiltired = ızins;
            dataBinder.DataSource = ızins.ToDataTable();
            DtgList.DataSource = dataBinder;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Izinkategori"].HeaderText = "İZİN KATEGORİ";
            DtgList.Columns["Izinturu"].HeaderText = "İZİN TÜRÜ";
            DtgList.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgList.Columns["Masrafyerino"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["Bolum"].HeaderText = "BÖLÜMÜ";
            DtgList.Columns["Izınnedeni"].HeaderText = "İZİN NEDENİ";
            DtgList.Columns["Bastarihi"].HeaderText = "İZİN BAŞLAMA TARİHİ";
            DtgList.Columns["Bittarihi"].HeaderText = "İZİN BİTİŞ TARİHİ";
            DtgList.Columns["Izindurumu"].HeaderText = "İZİN DURUMU";
            DtgList.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgList.Columns["Toplamsure"].HeaderText = "TOPLAM SÜRE";
            DtgList.Columns["KalanSure"].Visible = false;
            DtgList.Columns["Dosyayolu"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;

            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DtgIzinList();
        }

        private void TxtAkısNo_TextChanged(object sender, EventArgs e)
        {
            int isno = 0;
            if (string.IsNullOrEmpty(TxtAkısNo.Text))
            {
                izinFiltired = ızins;
                dataBinder.DataSource = ızins.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtAkısNo.Text.Length < 3)
            {
                return;
            }
            if (!int.TryParse(TxtAkısNo.Text, out outValue))
            {
                MessageBox.Show("Rakamsal Değer Giriniz");
                return;
            }
            isno = TxtAkısNo.Text.ConInt();
            dataBinder.DataSource = izinFiltired.Where(x => x.Isakisno.ToString().Contains(isno.ToString())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            izinFiltired = ızins;
            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();
        }

        private void TxtAdSoyad_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtAdSoyad.Text;
            if (string.IsNullOrEmpty(isim))
            {
                izinFiltired = ızins;
                dataBinder.DataSource = ızins.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtAdSoyad.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = izinFiltired.Where(x => x.Adsoyad.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            izinFiltired = ızins;
            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            sayfa = DtgList.CurrentRow.Cells["Sayfa"].Value.ToString();
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            dosyayolu = DtgList.CurrentRow.Cells["Dosyayolu"].Value.ToString();
            IslemAdimlariDisplay();
            try
            {
                webBrowser1.Navigate(dosyayolu);
            }
            catch (Exception)
            {
                return;
            }
            
        }
        void IslemAdimlariDisplay()
        {
            DtgIslemAdimlari.DataSource = logManager.GetList(sayfa, id);
            DtgIslemAdimlari.Columns["Id"].Visible = false;
            DtgIslemAdimlari.Columns["Sayfa"].Visible = false;
            DtgIslemAdimlari.Columns["Benzersizid"].Visible = false;
            DtgIslemAdimlari.Columns["Islem"].HeaderText = "YAPILAN İŞLEM";
            DtgIslemAdimlari.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgIslemAdimlari.Columns["Tarih"].HeaderText = "TARİH";
            DtgIslemAdimlari.Columns["Tarih"].Width = 100;
            DtgIslemAdimlari.Columns["Islemyapan"].Width = 135;
            DtgIslemAdimlari.Columns["Islem"].Width = 400;
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                string izinsuresi = DtgList.Rows[i].Cells[13].Value.ToString();
                string[] array = izinsuresi.Split(' ');
                toplam += Convert.ToDouble(array[0].ConInt());
            }
            LblGenelTop.Text = toplam.ToString() + " Gün";
        }

    }
}
