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

namespace UserInterface.Depo
{
    public partial class FrmStokGoruntule : Form
    {
        StokGirisCikisManager stokGirisCikisManager;
        List<StokGirisCıkıs> stokGirisCıkıs;
        List<StokGirisCıkıs> stokFiltired;
        public FrmStokGoruntule()
        {
            InitializeComponent();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageStokGoruntule"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void FrmStokGoruntule_Load(object sender, EventArgs e)
        {
            Display();
        }
        void Display()
        {
            stokGirisCıkıs = stokGirisCikisManager.GetList();
            stokFiltired = stokGirisCıkıs;
            dataBinder.DataSource = stokGirisCıkıs.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Islemturu"].HeaderText = "İŞLEM TÜRÜ";
            DtgList.Columns["Stokno"].HeaderText = "STOK NO";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgList.Columns["Birim"].HeaderText = "BİRİM";
            DtgList.Columns["Istenentarih"].HeaderText = "İŞLEM TARİHİ";
            DtgList.Columns["Depono"].HeaderText = "DEPO NO";
            DtgList.Columns["Depoadresi"].HeaderText = "DEPO ADRESİ";
            DtgList.Columns["Malzemeyeri"].HeaderText = "MALZEME YERİ";
            DtgList.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            DtgList.Columns["Serino"].HeaderText = "SERİ NO";
            DtgList.Columns["Lotno"].HeaderText = "LOT NO";
            DtgList.Columns["Revizyon"].HeaderText = "REVİZYON";
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            stokFiltired = stokGirisCıkıs.Where(x => x.Stokno.ToLower().Contains(TxtStokArama.Text.ToLower()) && x.Serino.ToLower().Contains(TxtSeriNo.Text.ToLower())).ToList();
            DtgList.DataSource = stokFiltired;
        }
    }
}
