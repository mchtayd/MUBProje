using Business.Concreate.BakimOnarim;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity.BakimOnarim;
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

namespace UserInterface.STS
{
    public partial class FrmSatTalebi : Form
    {
        public object[] infos;
        ButceKoduManager butceKoduManager;
        BolgeKayitManager bolgeKayitManager;
        ArizaKayitManager arizaKayitManager;

        List<ButceKodu> butceKodus;
        List<ArizaKayit> arizaKayits;

        bool start = false;
        public FrmSatTalebi()
        {
            InitializeComponent();
            butceKoduManager = ButceKoduManager.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
        }

        private void FrmSatTalebi_Load(object sender, EventArgs e)
        {
            ButceKoduKalemi();
            ButceKoduKalemi2();
            BolgeBilgileri();
            TarihDonem();
            start = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSatTalebi"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void CmbFaturaFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbFaturaFirma.Text== "BAŞARAN İLERİ TEKNOLOJİ")
            {
                GrnBasaran.Visible = true;
                GrbAselsan.Visible = false;
            }
            else
            {
                GrnBasaran.Visible = false;
                GrbAselsan.Visible = true;
            }

            int index = CmbFaturaFirma.SelectedIndex;
            CmbIlgiliKisi.SelectedIndex = index;
            CmbMasYeri.SelectedIndex = index;
        }
        void ButceKoduKalemi()
        {
            butceKodus = butceKoduManager.GetList();
            CmbButceKodu.DataSource = butceKodus;
            CmbButceKodu.ValueMember = "Id";
            CmbButceKodu.DisplayMember = "Butcekodu";
            CmbButceKodu.SelectedValue = 0;
        }
        void ButceKoduKalemi2()
        {
            CmbButceKodu2.DataSource = butceKodus;
            CmbButceKodu2.ValueMember = "Id";
            CmbButceKodu2.DisplayMember = "Butcekodu";
            CmbButceKodu2.SelectedValue = 0;
        }

        private void BtnButceKodu_Click(object sender, EventArgs e)
        {
            FrmButceKoduKalemi frmButceKoduKalemi = new FrmButceKoduKalemi();
            frmButceKoduKalemi.Show();
        }
        void BolgeBilgileri()
        {
            CmbBolgeAdi.DataSource = bolgeKayitManager.GetList();
            CmbBolgeAdi.ValueMember = "Id";
            CmbBolgeAdi.DisplayMember = "BolgeAdi";
            CmbBolgeAdi.SelectedValue = -1;
        }

        private void CmbBolgeAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            BolgeKayit bolgeKayit = bolgeKayitManager.Get(CmbBolgeAdi.SelectedValue.ConInt());
            if (bolgeKayit==null)
            {
                return;
            }
            else
            {
                LblBolgeProje.Text = bolgeKayit.Proje;
                arizaKayits = arizaKayitManager.GetList(CmbBolgeAdi.Text);
            }
        }

        private void BildirimFromNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }

            ArizaKayit arizaKayit = arizaKayitManager.Get(BildirimFromNo.Text.ConInt());
            if (arizaKayit == null)
            {
                LblGarantiDurumu.Text = "";
                LblAciklama.Text = "";
                return;
            }

            LblGarantiDurumu.Text = arizaKayit.GarantiDurumu;
            LblAciklama.Text = arizaKayit.TespitEdilenAriza;

        }
        void TarihDonem()
        {
            LblSatOlusturmaTarihi.Text = DateTime.Now.ToString("d");

        }
    }
}
