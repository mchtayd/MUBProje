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
    public partial class FrmArsivIzleme : Form
    {
        List<ArsivTutanak> arsivTutanaks;
        List<ArsivTutanak> arsivTutanaksFiltired;
        ArsivTutanakManager arsivTutanakManager;
        public FrmArsivIzleme()
        {
            InitializeComponent();
            arsivTutanakManager = ArsivTutanakManager.GetInstance();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageArsivIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void FrmArsivIzleme_Load(object sender, EventArgs e)
        {
            DtgIzinList();
        }
        public void GuncellenecekVeri()
        {
            DtgIzinList();
        }
        public void DtgIzinList()
        {
            arsivTutanaks = arsivTutanakManager.GetList();
            arsivTutanaksFiltired = arsivTutanaks;
            dataBinder.DataSource = arsivTutanaks.ToDataTable();
            DtgArsiv.DataSource = dataBinder;

            DtgArsiv.Columns["Id"].Visible = false;
            DtgArsiv.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgArsiv.Columns["DosyaTuru"].HeaderText = "DOSYA TÜRÜ";
            DtgArsiv.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgArsiv.Columns["SistemCihaz"].HeaderText = "SİSTEM CİHAZ";
            DtgArsiv.Columns["DosyaTarihi"].HeaderText = "DOSYA TARİHİ";
            DtgArsiv.Columns["DosyaIcerigi"].HeaderText = "DOSYA İÇERİĞİ";
            DtgArsiv.Columns["DosyaYolu"].Visible = false;
            DtgArsiv.Columns["BulunduguLok"].HeaderText = "DOSYANIN BULUNDUĞU LOKASYON";
            DtgArsiv.Columns["KlasorNo"].HeaderText = "BASILI KOPYA KLASÖR NO";

            TxtTop.Text = DtgArsiv.RowCount.ToString();
        }
        string dosyaYolu;
        private void DtgArsiv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgArsiv.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyaYolu = DtgArsiv.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            webBrowser1.Navigate(dosyaYolu);
        }

        private void DtgArsiv_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgArsiv.FilterString;
            TxtTop.Text = DtgArsiv.RowCount.ToString();
        }

        private void DtgArsiv_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgArsiv.SortString;
        }
    }
}
