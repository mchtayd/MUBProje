using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity.STS;
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

namespace UserInterface.RAPORLAMALAR
{
    public partial class FrmSatRaporu : Form
    {
        SatRaporManager satRaporManager;
        List<SatRapor> satRapors;
        string firma, donem = "";

        public FrmSatRaporu()
        {
            InitializeComponent();
            satRaporManager = SatRaporManager.GetInstance();
        }

        private void FrmSatRaporu_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSatRaporlama"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void BtnRaporOlustur_Click(object sender, EventArgs e)
        {
            if (CmbFaturaFirma.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle FİRMA BİLGİSİ Kısmını Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbDonem.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle DÖNEM Kısmını Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            donem = CmbDonem.Text;
            DtgRaporList.DataSource = null;
            if (CmbFaturaFirma.Text == "ASELSAN")
            {
                firma = "ASELSAN";
                satRapors = satRaporManager.GetList(firma, donem);
                dataBinder.DataSource = satRapors.ToDataTable();
                DtgRaporList.DataSource = dataBinder;
                DataDisplayAselsan();
            }
            if (CmbFaturaFirma.Text == "BAŞARAN")
            {
                firma = "BAŞARAN İLERİ TEKNOLOJİ";
                satRapors = satRaporManager.GetListBasaran(firma, donem);

                dataBinder.DataSource = satRapors.ToDataTable();
                DtgRaporList.DataSource = dataBinder;
                DataDisplayBasaran();
            }

        }
        void ToplamlarAselsan()
        {
            double toplam = 0;
            for (int i = 0; i < DtgRaporList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgRaporList.Rows[i].Cells[5].Value);
            }
            ToplamTutar.Text = toplam.ToString("C2");
        }
        void ToplamlarBasaran()
        {
            double toplam = 0;
            for (int i = 0; i < DtgRaporList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgRaporList.Rows[i].Cells[5].Value);
            }
            ToplamTutar.Text = toplam.ToString("C2");
        }
        void DataDisplayAselsan()
        {
            DtgRaporList.Columns["Kategori"].HeaderText = "KATEGORİ";
            DtgRaporList.Columns["ButceKodu"].HeaderText = "BÜTÇE KODU";
            DtgRaporList.Columns["ButceKalemi"].HeaderText = "BÜTÇE KALEMİ";
            DtgRaporList.Columns["FaturaTarihi"].HeaderText = "FATURA TARİHİ";
            DtgRaporList.Columns["FaturaAlindigiYer"].HeaderText = "FATURANIN ALINDIĞI YER";
            DtgRaporList.Columns["Tutar"].HeaderText = "FATURA TUTARI";
            DtgRaporList.Columns["Proje"].HeaderText = "PROJE";
            DtgRaporList.Columns["Bolge"].HeaderText = "BÖLGE";
            DtgRaporList.Columns["BildirimNo"].HeaderText = "BİLDİRİM NO";
            DtgRaporList.Columns["Aciklamalar"].HeaderText = "AÇIKLAMALAR";
            DtgRaporList.Columns["BelgeNo"].Visible = false;
            DtgRaporList.Columns["BelgeTuru"].Visible = false;
            DtgRaporList.Columns["HarcamaYapan"].Visible = false;
            TxtTop.Text = DtgRaporList.RowCount.ToString();
            ToplamlarAselsan();
        }
        void DataDisplayBasaran()
        {
            DtgRaporList.Columns["Kategori"].Visible = false;
            DtgRaporList.Columns["ButceKodu"].HeaderText = "BÜTÇE KODU";
            DtgRaporList.Columns["ButceKalemi"].HeaderText = "BÜTÇE KALEMİ";
            DtgRaporList.Columns["FaturaTarihi"].HeaderText = "FATURA TARİHİ";
            DtgRaporList.Columns["FaturaAlindigiYer"].HeaderText = "FATURANIN ALINDIĞI YER";
            DtgRaporList.Columns["Tutar"].HeaderText = "FATURA TUTARI";
            DtgRaporList.Columns["Proje"].Visible = false;
            DtgRaporList.Columns["Bolge"].Visible = false;
            DtgRaporList.Columns["BildirimNo"].Visible = false;
            DtgRaporList.Columns["Aciklamalar"].Visible = false;
            DtgRaporList.Columns["BelgeNo"].HeaderText = "BELGE NO";
            DtgRaporList.Columns["BelgeTuru"].HeaderText = "BELGE TÜRÜ";
            DtgRaporList.Columns["HarcamaYapan"].HeaderText = "HARCAMA YAPAN";
            TxtTop.Text = DtgRaporList.RowCount.ToString();
            ToplamlarBasaran();
        }
    }
}
