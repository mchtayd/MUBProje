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
        List<BolgeKayit> bolgeKayits = new List<BolgeKayit>();
        BolgeManager bolgeManager;
        BolgeKayitManager bolgeKayitManager;
        BolgeGarantiManager bolgeGarantiManager;

        int id;
        string siparisNo, dosyaYolu;
        public FrmBolgeKayitIzleme()
        {
            InitializeComponent();
            bolgeManager = BolgeManager.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            bolgeGarantiManager = BolgeGarantiManager.GetInstance();
        }

        private void FrmBolgeKayitIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
            
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
        public void DataDisplay()
        {
            bolgeKayits = bolgeKayitManager.GetList();
            dataBinder.DataSource = bolgeKayits.ToDataTable();
            DtgBolgeler.DataSource = dataBinder;
            TxtTop.Text = DtgBolgeler.RowCount.ToString();

            DtgBolgeler.Columns["Id"].Visible = false;
            DtgBolgeler.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgBolgeler.Columns["KodAdi"].HeaderText = "KOD ADI";
            DtgBolgeler.Columns["UsBolgesiStok"].HeaderText = "ÜST BÖLGESİ STOK NO";
            DtgBolgeler.Columns["KabulTarihi"].HeaderText = "KABUL TARİHİ";
            DtgBolgeler.Columns["GuvenlikYazilimi"].HeaderText = "GÜVENLİK YAZILIMI";
            DtgBolgeler.Columns["KesifGozetlemeTuru"].HeaderText = "KEŞİF GÖZETMELE TÜRÜ";
            DtgBolgeler.Columns["YasamAlani"].HeaderText = "YAŞAM ALANI";
            DtgBolgeler.Columns["Tabur"].HeaderText = "BAĞLI OLDUĞU TABUR";
            DtgBolgeler.Columns["Tugay"].HeaderText = "BAĞLI OLDUĞU TUGAY";
            DtgBolgeler.Columns["Il"].HeaderText = "İL";
            DtgBolgeler.Columns["Ilce"].HeaderText = "İLÇE";
            DtgBolgeler.Columns["BirlikAdresi"].HeaderText = "BİRLİK ADRESİ";
            DtgBolgeler.Columns["GarantiBaslama"].HeaderText = "GARANTİ BAŞLAMA TARİHİ";
            DtgBolgeler.Columns["GarantiBitis"].HeaderText = "GARANTİ BİTİŞ TARİHİ";
            DtgBolgeler.Columns["BolgeSorumlusu"].HeaderText = "SEKTÖR SORUMLUSU";
            DtgBolgeler.Columns["Depo"].HeaderText = "BAĞLI OLDUĞU DEPO";
            DtgBolgeler.Columns["SiparisNo"].Visible = false;
            DtgBolgeler.Columns["DosyaYolu"].Visible = false;
            DtgBolgeler.Columns["PypNo"].HeaderText = "PYP NO";
            DtgBolgeler.Columns["Proje"].HeaderText = "PROJE";
            DtgBolgeler.Columns["TepeSorumlusu"].HeaderText = "ÜS BÖLGESİ SORUMLUSU";
            DtgBolgeler.Columns["ProjeSistem"].HeaderText = "PROJE SİSTEM";
        }

        private void DtgBolgeler_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgBolgeler.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            id = DtgBolgeler.CurrentRow.Cells["Id"].Value.ConInt();
            siparisNo = DtgBolgeler.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosyaYolu = DtgBolgeler.CurrentRow.Cells["DosyaYolu"].Value.ToString();

            GarantiPaketleriDisplay(siparisNo);

            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }

        }

        private void DtgBolgeler_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgBolgeler.FilterString;
            TxtTop.Text = DtgBolgeler.RowCount.ToString();
        }

        private void DtgBolgeler_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgBolgeler.SortString;
        }

        void GarantiPaketleriDisplay(string siparisNo)
        {
            DtgGarantiPaketi.DataSource = bolgeGarantiManager.GetListTumu(siparisNo);

            DtgGarantiPaketi.Columns["Id"].Visible = false;
            DtgGarantiPaketi.Columns["GarantiPaketi"].HeaderText = "GARANTİ PAKETİ";
            DtgGarantiPaketi.Columns["GarantiBaslama"].HeaderText = "GARANTİ BAŞLAMA TARİHİ";
            DtgGarantiPaketi.Columns["GarantiBitis"].HeaderText = "GARANTİ BİTİŞ TARİHİ";
            DtgGarantiPaketi.Columns["ToplamSure"].HeaderText = "TOPLAM SÜRE";
            DtgGarantiPaketi.Columns["SiparisNo"].Visible = false;

        }
    }
}
