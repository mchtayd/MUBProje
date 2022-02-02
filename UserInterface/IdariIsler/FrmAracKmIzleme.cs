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
    public partial class FrmAracKmIzleme : Form
    {
        AracKmManager aracKmManager;

        List<AracKm> aracKms = new List<AracKm>();
        List<AracKm> aracKmsFiltired = new List<AracKm>();
        public FrmAracKmIzleme()
        {
            InitializeComponent();
            aracKmManager = AracKmManager.GetInstance();
        }

        private void FrmAracKmIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageAracKmIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        public void Yenilenecekler()
        {
            DataDisplay();
        }
        void DataDisplay()
        {
            aracKms = aracKmManager.GetList();
            aracKmsFiltired = aracKms;
            dataBinder.DataSource = aracKms.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Plaka"].HeaderText = "PLAKA";
            DtgList.Columns["SiparisNo"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["Tarih"].HeaderText = "TARİH";
            DtgList.Columns["Donem"].HeaderText = "DÖNEM";
            DtgList.Columns["BaslangicKm"].HeaderText = "BAŞLANGIÇ KM";
            DtgList.Columns["PersonelAd"].HeaderText = "ZİMMETLİ PERSONEL ADI";
            DtgList.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgList.Columns["PersonelUnvani"].HeaderText = "PERSONEL TARİHİ";
            DtgList.Columns["PerMasYeriNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgList.Columns["PerMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgList.Columns["PersMasYerSorumlusu"].HeaderText = "PERSONEL MASRAF YERİ SORUMLUSU";
            DtgList.Columns["AracMulkiyet"].HeaderText = "ARAÇ MÜLKİYET BİLGİLERİ";
            
        }

        private void TxtPlaka_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtPlaka.Text;
            if (string.IsNullOrEmpty(isim))
            {
                aracKmsFiltired = aracKms;
                dataBinder.DataSource = aracKms.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtPlaka.Text.Length < 5)
            {
                return;
            }
            dataBinder.DataSource = aracKmsFiltired.Where(x => x.Plaka.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            aracKmsFiltired = aracKms;
            TxtTop.Text = DtgList.RowCount.ToString();
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
    }
}
