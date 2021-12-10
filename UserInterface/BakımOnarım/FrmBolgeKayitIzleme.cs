using Business.Concreate.BakimOnarim;
using DataAccess.Concreate;
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
    public partial class FrmBolgeKayitIzleme : Form
    {
        List<Bolge> bolges = new List<Bolge>();
        BolgeManager bolgeManager;
        public FrmBolgeKayitIzleme()
        {
            InitializeComponent();
            bolgeManager = BolgeManager.GetInstance();
        }

        private void FrmBolgeKayitIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
            TxtEkipmanSayisi.Text = DtgMalzemeler.RowCount.ToString();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageBolgeKayitIzleme"]);

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
            bolges = bolgeManager.GetList();
            dataBinder.DataSource = bolges.ToDataTable();
            DtgBolgeler.DataSource = dataBinder;
            TxtTop.Text = DtgBolgeler.RowCount.ToString();

            DtgBolgeler.Columns["Id"].Visible = false;
            DtgBolgeler.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgBolgeler.Columns["IlgiliPersonel"].HeaderText = "İLGİLİ PERSONEL";
            DtgBolgeler.Columns["BirlikAdresi"].HeaderText = "BİRLİK ADRESİ";
            DtgBolgeler.Columns["Telefon"].HeaderText = "TELEFON";
            DtgBolgeler.Columns["FaturaAdresi"].HeaderText = "FATURA ADRESİ";
            DtgBolgeler.Columns["PypNo"].HeaderText = "PYP NO";
            DtgBolgeler.Columns["SorumluSicil"].HeaderText = "BÖLGE SORUMLUSU SİCİL";
            DtgBolgeler.Columns["Il"].HeaderText = "İL";
            DtgBolgeler.Columns["Ilce"].HeaderText = "İLÇE";
            DtgBolgeler.Columns["Proje"].HeaderText = "PROJE";
            DtgBolgeler.Columns["GarantiBaslama"].HeaderText = "GARANTİ BAŞLAMA";
            DtgBolgeler.Columns["GarantiBitis"].HeaderText = "GARANTİ BİTİŞ";
            DtgBolgeler.Columns["SsPersonel"].HeaderText = "SORUMLU PERSONEL";
            DtgBolgeler.Columns["SspGorev"].HeaderText = "SORUMLU PERSONEL GÖREVİ";
            DtgBolgeler.Columns["Depo"].HeaderText = "DEPO";
            DtgBolgeler.Columns["SsRutbe"].HeaderText = "SORUMLU PERSONEL RÜTBE";
        }
    }
}
