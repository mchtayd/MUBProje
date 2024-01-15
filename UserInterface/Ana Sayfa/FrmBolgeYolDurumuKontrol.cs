using Business.Concreate.AnaSayfa;
using DataAccess.Concreate;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmBolgeYolDurumuKontrol : Form
    {
        YolDurumuGirmeyenManager yolDurumuGirmeyenManager;
        List<YolDurumuGirmeyen> yolDurumuGirmeyens;
        public FrmBolgeYolDurumuKontrol()
        {
            InitializeComponent();
            yolDurumuGirmeyenManager = YolDurumuGirmeyenManager.GetInstance();
        }

        private void FrmBolgeYolDurumuKontrol_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }
        void DataDisplay()
        {
            yolDurumuGirmeyens = new List<YolDurumuGirmeyen>();
            yolDurumuGirmeyens = yolDurumuGirmeyenManager.GetList();
            dataBinder.DataSource = yolDurumuGirmeyens.ToDataTable();
            DtgList.DataSource = dataBinder;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Personel"].HeaderText = "PERSONEL";
            DtgList.Columns["Tarih"].HeaderText = "TARİH";
            DtgList.Columns["GorulmeDurumu"].Visible = false;

            LblTop.Text = DtgList.RowCount.ToString();

        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            LblTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }
    }
}
