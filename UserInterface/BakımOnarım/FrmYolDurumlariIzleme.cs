using Business.Concreate.BakimOnarim;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Presentation;
using Entity.BakimOnarim;
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

namespace UserInterface.BakımOnarım
{
    public partial class FrmYolDurumlariIzleme : Form
    {
        BolgeKayitManager bolgeKayitManager;
        YolDurumManager yolDurumManager;
        public object[] infos;
        List<YolDurum> yolDurums;
        public FrmYolDurumlariIzleme()
        {
            InitializeComponent();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            yolDurumManager = YolDurumManager.GetInstance();
        }

        private void FrmYolDurumlariIzleme_Load(object sender, EventArgs e)
        {
            UsBolgeleri();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageYolDurumlariIzleme"]);
            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void UsBolgeleri()
        {
            if (infos[0].ConInt() == 25 || infos[0].ConInt() == 30 || infos[0].ConInt() == 33 || infos[0].ConInt() == 84 || infos[0].ConInt() == 39 || infos[0].ConInt() == 1140 || infos[0].ConInt() == 1139 || infos[0].ConInt() == 54 || infos[0].ConInt() == 47 || infos[0].ConInt() == 57 || infos[0].ConInt() == 65 || infos[0].ConInt() == 1121 || infos[0].ConInt() == 1148 || infos[11].ToString() == "MİSAFİR")
            {
                CmbBolgeAdi.DataSource = bolgeKayitManager.GetList();
            }
            else
            {
                CmbBolgeAdi.DataSource = bolgeKayitManager.GetList(infos[1].ToString());
            }

            CmbBolgeAdi.ValueMember = "Id";
            CmbBolgeAdi.DisplayMember = "BolgeAdi";
            CmbBolgeAdi.SelectedValue = "";
        }

        private void BtnSorgula_Click(object sender, EventArgs e)
        {
            if (CmbBolgeAdi.Text=="")
            {
                MessageBox.Show("Lütfen öncelikle bir Bölge Adı seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            yolDurums = yolDurumManager.GetList(CmbBolgeAdi.Text, DtBasTarihi.Value, DtBitTarihi.Value);
            dataBinder.DataSource = yolDurums.ToDataTable();
            DtgList.DataSource = dataBinder;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgList.Columns["Tarih"].HeaderText = "TARİH";
            DtgList.Columns["Donem"].HeaderText = "DÖNEM";
            DtgList.Columns["YolDurumu"].HeaderText = "YOL DURUMU";
            DtgList.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            DtgList.Columns["KayitYapan"].HeaderText = "KAYIT YAPAN";

            TxtTop.Text= DtgList.RowCount.ToString();
        }


        private void ChkTumBolge_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTumBolge.Checked==true)
            {
                CmbBolgeAdi.SelectedIndex = -1;

                yolDurums = yolDurumManager.GetListTum(DtBasTarihi.Value, DtBitTarihi.Value);
                dataBinder.DataSource = yolDurums.ToDataTable();
                DtgList.DataSource = dataBinder;

                DtgList.Columns["Id"].Visible = false;
                DtgList.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
                DtgList.Columns["Tarih"].HeaderText = "TARİH";
                DtgList.Columns["Donem"].HeaderText = "DÖNEM";
                DtgList.Columns["YolDurumu"].HeaderText = "YOL DURUMU";
                DtgList.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
                DtgList.Columns["KayitYapan"].HeaderText = "KAYIT YAPAN";

            }
            else
            {
                yolDurums = new List<YolDurum>();
                dataBinder.DataSource = yolDurums;
                DtgList.DataSource = dataBinder;

                DtgList.Columns["Id"].Visible = false;
                DtgList.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
                DtgList.Columns["Tarih"].HeaderText = "TARİH";
                DtgList.Columns["Donem"].HeaderText = "DÖNEM";
                DtgList.Columns["YolDurumu"].HeaderText = "YOL DURUMU";
                DtgList.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
                DtgList.Columns["KayitYapan"].HeaderText = "KAYIT YAPAN";

            }

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
