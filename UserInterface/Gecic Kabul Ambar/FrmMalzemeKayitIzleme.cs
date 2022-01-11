using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using Entity.Gecic_Kabul_Ambar;
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
    public partial class FrmMalzemeKayitIzleme : Form
    {
        List<MalzemeKayit> malzemeKayits;
        List<MalzemeKayit> malzemeKayitsFiltired;
        MalzemeKayitManager kayitManager;
        public FrmMalzemeKayitIzleme()
        {
            InitializeComponent();
            kayitManager = MalzemeKayitManager.GetInstance();
        }

        private void FrmMalzemeKayitIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageKayitliMalzemeler"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void DataDisplay()
        {
            malzemeKayits = kayitManager.GetList();
            malzemeKayitsFiltired = malzemeKayits;
            dataBinder.DataSource = malzemeKayits.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Stokno"].HeaderText = "STOK NO";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["Birim"].HeaderText = "BİRİM";
            DtgList.Columns["Tedarikcifirma"].HeaderText = "TEDARİKÇİ FİRMA";
            DtgList.Columns["Malzemeonarimdurumu"].HeaderText = "MALZEME ONARIM DURUMU";
            DtgList.Columns["Malzemeonarımyeri"].HeaderText = "MALZEME ONARIM YERİ";
            DtgList.Columns["Malzemeturu"].HeaderText = "MALZEME TÜRÜ";
            DtgList.Columns["Malzemetakipdurumu"].HeaderText = "MALZEME TAKİP DURUMU";
            DtgList.Columns["Malzemerevizyon"].HeaderText = "MALZEME REVİZYON";
            //DtgList.Columns["Malzemelot"].HeaderText = "MALZEME LOT NO";
            DtgList.Columns["Malzemekul"].HeaderText = "MALZEMENİN KULLANILDIĞI ÜST TAKIM STOK NO";
            DtgList.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            DtgList.Columns["Dosyayolu"].Visible = false;
            DtgList.Columns["AlternatifMalzeme"].HeaderText = "ALTERNATİF MALZEME";
        }

        private void TxtStokNo_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtStokNo.Text;
            if (string.IsNullOrEmpty(isim))
            {
                malzemeKayitsFiltired = malzemeKayits;
                dataBinder.DataSource = malzemeKayits.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtStokNo.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemeKayitsFiltired.Where(x => x.Stokno.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            malzemeKayitsFiltired = malzemeKayits;
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
