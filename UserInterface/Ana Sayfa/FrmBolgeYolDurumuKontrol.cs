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
        List<YolDurumuGirmeyen> loginOlmayan;
        public FrmBolgeYolDurumuKontrol()
        {
            InitializeComponent();
            yolDurumuGirmeyenManager = YolDurumuGirmeyenManager.GetInstance();
        }

        private void FrmBolgeYolDurumuKontrol_Load(object sender, EventArgs e)
        {
            DataDisplay();
            DataDisplay2();
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

        void DataDisplay2()
        {
            loginOlmayan = new List<YolDurumuGirmeyen>();
            loginOlmayan = yolDurumuGirmeyenManager.GetListLoginOlmayan();
            dataBinder2.DataSource = loginOlmayan.ToDataTable();
            DtgList2.DataSource = dataBinder2;

            DtgList2.Columns["Id"].Visible = false;
            DtgList2.Columns["Personel"].HeaderText = "PERSONEL";
            DtgList2.Columns["Tarih"].HeaderText = "TARİH";
            DtgList2.Columns["GorulmeDurumu"].Visible = false;

            LblTop2.Text = DtgList2.RowCount.ToString();

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
