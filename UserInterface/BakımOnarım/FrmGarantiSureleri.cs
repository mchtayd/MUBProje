using Business;
using Business.Concreate.BakimOnarim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;

namespace UserInterface.BakımOnarım
{
    public partial class FrmGarantiSureleri : Form
    {
        BolgeGarantiManager bolgeGarantiManager;
        ComboManager comboManager;
        string comboAd;
        public FrmGarantiSureleri()
        {
            InitializeComponent();
            comboManager = ComboManager.GetInstance();
            bolgeGarantiManager = BolgeGarantiManager.GetInstance();
        }

        private void FrmGarantiSureleri_Load(object sender, EventArgs e)
        {
            ComboYasamAlani();
        }
        public void ComboYasamAlani()
        {
            CmbGarantiPaketi.DataSource = comboManager.GetList("GARANTI_PAKETI");
            CmbGarantiPaketi.ValueMember = "Id";
            CmbGarantiPaketi.DisplayMember = "Baslik";
            CmbGarantiPaketi.SelectedValue = 0;
        }

        private void BtnGarantiPaketi_Click(object sender, EventArgs e)
        {
            comboAd = "GARANTI_PAKETI";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnListeyeEkle_Click(object sender, EventArgs e)
        {

        }
    }
}
