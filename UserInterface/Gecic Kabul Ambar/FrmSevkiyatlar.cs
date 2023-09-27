using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.Rapor;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Office2010.Excel;
using Entity.Gecic_Kabul_Ambar;
using Entity.Rapor;
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

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmSevkiyatlar : Form
    {
        SevkiyatManager sevkiyatManager;
        SevkiyatMalzemeManager sevkiyatMalzemeManager;
        int benzersizId = 0;

        List<Sevkiyat> sevkiyats = new List<Sevkiyat>();

        public FrmSevkiyatlar()
        {
            InitializeComponent();
            sevkiyatManager = SevkiyatManager.GetInstance();
            sevkiyatMalzemeManager = SevkiyatMalzemeManager.GetInstance();
        }

        private void FrmSevkiyatlar_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSevkiyatlar"]);

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
            sevkiyats = sevkiyatManager.GetList();
            dataBinder.DataSource = sevkiyats.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["SevkiyatTuru"].HeaderText = "SEVKİYAT TÜRÜ";
            DtgList.Columns["Tarih"].HeaderText = "TARİH";
            DtgList.Columns["Donem"].HeaderText = "DÖNEM";
            DtgList.Columns["DosyaYolu"].Visible = false;

            TxtTop.Text = DtgList.RowCount.ToString();

            DtgMalzemeList.DataSource = null;
            LblMalzemeSayisi.Text = DtgMalzemeList.RowCount.ToString();
            webBrowser1.Navigate("");
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

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            benzersizId = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            string dosyaYolu = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            DataDisplayMalzeme();
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
            
        }

        void DataDisplayMalzeme()
        {
            if (benzersizId==0)
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgMalzemeList.DataSource = sevkiyatMalzemeManager.GetList(benzersizId);

            DtgMalzemeList.Columns["Id"].Visible = false;
            DtgMalzemeList.Columns["BenzersizId"].Visible = false;
            DtgMalzemeList.Columns["StokNo"].HeaderText = "TARİH";
            DtgMalzemeList.Columns["Tanim"].HeaderText = "DÖNEM";
            DtgMalzemeList.Columns["SeriLotNo"].Visible = false;
            DtgMalzemeList.Columns["Revizyon"].HeaderText = "SEVKİYAT TÜRÜ";
            DtgMalzemeList.Columns["Miktar"].HeaderText = "TARİH";
            DtgMalzemeList.Columns["Birim"].HeaderText = "DÖNEM";
            DtgMalzemeList.Columns["Tarih"].Visible = false;

            LblMalzemeSayisi.Text = DtgMalzemeList.RowCount.ToString();
            benzersizId = 0;
        }
    }
}
