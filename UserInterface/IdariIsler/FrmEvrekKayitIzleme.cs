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
    public partial class FrmEvrekKayitIzleme : Form
    {
        List<EvrakKayit> evraks;
        List<EvrakKayit> evraksFiltired;
        EvrakKayitManager evrakKayitManager;
        IdariIslerLogManager logManager;
        string dosyayolu, sayfa;
        int id, outValue = 0;
        public FrmEvrekKayitIzleme()
        {
            InitializeComponent();
            evrakKayitManager = EvrakKayitManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
        }

        private void FrmEvrekKayitIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageEvrakKayitIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        public void DataDisplay()
        {
            evraks = evrakKayitManager.GetList();
            evraksFiltired = evraks;
            dataBinder.DataSource = evraks.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["YaziTuru"].HeaderText = "YAZI TÜRÜ";
            DtgList.Columns["Cinsi"].HeaderText = "CİNSİ";
            DtgList.Columns["NeredenGeldigi"].HeaderText = "NEREDEN GELDİĞİ";
            DtgList.Columns["Sayino"].HeaderText = "SAYI NO";
            DtgList.Columns["Tarih"].HeaderText = "TARİH";
            DtgList.Columns["Konu"].HeaderText = "KONU";
            DtgList.Columns["EkSayisi"].HeaderText = "EK SAYISI";
            DtgList.Columns["Geregi"].HeaderText = "GEREĞİ";
            DtgList.Columns["Bilgi1"].HeaderText = "BİLGİ_1";
            DtgList.Columns["Bilgi2"].HeaderText = "BİLGİ_2";
            DtgList.Columns["Bilgi3"].HeaderText = "BİLGİ_3";
            DtgList.Columns["Bilgi4"].HeaderText = "BİLGİ_4";
            DtgList.Columns["Bilgi5"].HeaderText = "BİLGİ_5";
            DtgList.Columns["DosyaYolu"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyayolu = DtgList.CurrentRow.Cells["Dosyayolu"].Value.ToString();
            sayfa = DtgList.CurrentRow.Cells["Sayfa"].Value.ToString();
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            webBrowser1.Navigate(dosyayolu);
            IslemAdimlariDisplay();
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void TxtPlaka_TextChanged(object sender, EventArgs e)
        {
            int isno = 0;
            if (string.IsNullOrEmpty(TxtIsAkisNo.Text))
            {
                evraksFiltired = evraks;
                dataBinder.DataSource = evraks.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtIsAkisNo.Text.Length < 3)
            {
                return;
            }
            if (!int.TryParse(TxtIsAkisNo.Text, out outValue))
            {
                MessageBox.Show("Rakamsal Değer Giriniz");
                return;
            }
            isno = TxtIsAkisNo.Text.ConInt();
            dataBinder.DataSource = evraksFiltired.Where(x => x.IsAkisNo.ToString().Contains(isno.ToString())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            evraksFiltired = evraks;
            TxtTop.Text = DtgList.RowCount.ToString();
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
    }
}
