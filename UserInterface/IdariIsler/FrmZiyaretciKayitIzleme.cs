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
    public partial class FrmZiyaretciKayitIzleme : Form
    {
        ZiyaretciKayitManager ziyaretciKayitManager;
        IdariIslerLogManager logManager;
        List<ZiyaretciKayit> ziyaretciKayits = new List<ZiyaretciKayit>();
        string sayfa = "";
        int id;
        public FrmZiyaretciKayitIzleme()
        {
            InitializeComponent();
            ziyaretciKayitManager = ZiyaretciKayitManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
        }
        private void FrmZiyaretciKayitIzleme_Load(object sender, EventArgs e)
        {
            SatDataGrid1();
        }
        public void Yenilenecekler()
        {
            SatDataGrid1();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageZiyaretciIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void SatDataGrid1()
        {
            ziyaretciKayits = ziyaretciKayitManager.GetList();
            dataBinder.DataSource = ziyaretciKayits.ToDataTable();
            DtgZiyaretciList.DataSource = dataBinder;
            TxtTop.Text = DtgZiyaretciList.RowCount.ToString();
            DataDisplay();
        }
        void DataDisplay()
        {
            DtgZiyaretciList.Columns["Id"].Visible = false;
            DtgZiyaretciList.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgZiyaretciList.Columns["ZiyaretciAd"].HeaderText = "ZİYARETÇİ ADI SOYADI";
            DtgZiyaretciList.Columns["Tc"].HeaderText = "ZİYARETÇİ TC";
            DtgZiyaretciList.Columns["FirmaAdi"].HeaderText = "FİRMA ADI";
            DtgZiyaretciList.Columns["GeldigiTarihSaat"].HeaderText = "GELDİĞİ TARİH VE SAAT";
            DtgZiyaretciList.Columns["ZiyaretNedeni"].HeaderText = "ZİYARET NEDENİ";
            DtgZiyaretciList.Columns["ZiyaretEdilenAd"].HeaderText = "ZİYARET EDİLEN ADI SOYADI";
            DtgZiyaretciList.Columns["ZiyaretEdilenUnvani"].HeaderText = "ZİYARET EDİLEN ÜNVANI";
            DtgZiyaretciList.Columns["ZiyaretEdilenMasYeriNo"].HeaderText = "ZİYARET EDİLEN MASRAF YERİ NO";
            DtgZiyaretciList.Columns["ZiyaretEdilenMasYeri"].HeaderText = "ZİYARET EDİLEN MASRAF YERİ";
            DtgZiyaretciList.Columns["RefakatciAd"].HeaderText = "REFAKATCİ ADI SOYADI";
            DtgZiyaretciList.Columns["RefakatciUnvani"].HeaderText = "REFAKATCİ ÜNVANI";
            DtgZiyaretciList.Columns["RefakatciMasYeriNo"].HeaderText = "REFAKATCİ MASRAF YERİ NO";
            DtgZiyaretciList.Columns["RefakatciMasYeri"].HeaderText = "REFAKATCİ MASRAF YERİ";
        }

        private void DtgZiyaretciList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgZiyaretciList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            sayfa = "ZİYARETÇİ KAYIT";
            id = DtgZiyaretciList.CurrentRow.Cells["Id"].Value.ConInt();
            IslemAdimlariDisplay();
        }
        void IslemAdimlariDisplay()
        {
            DtgSatIslemAdimlari.DataSource = logManager.GetList(sayfa, id);
            DtgSatIslemAdimlari.Columns["Id"].Visible = false;
            DtgSatIslemAdimlari.Columns["Sayfa"].Visible = false;
            DtgSatIslemAdimlari.Columns["Benzersizid"].Visible = false;
            DtgSatIslemAdimlari.Columns["Islem"].HeaderText = "YAPILAN İŞLEM";
            DtgSatIslemAdimlari.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgSatIslemAdimlari.Columns["Tarih"].HeaderText = "TARİH";
            DtgSatIslemAdimlari.Columns["Tarih"].Width = 100;
            DtgSatIslemAdimlari.Columns["Islemyapan"].Width = 135;
            DtgSatIslemAdimlari.Columns["Islem"].Width = 400;
        }

        private void DtgZiyaretciList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgZiyaretciList.FilterString;
            TxtTop.Text = DtgZiyaretciList.RowCount.ToString();
        }

        private void DtgZiyaretciList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgZiyaretciList.SortString;
        }
    }
}
