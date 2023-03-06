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
            if (infos[0].ConInt() == 25 || infos[0].ConInt() == 84)
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

        }
    }
}
