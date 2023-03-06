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
    public partial class FrmDDStokGirisCikis : Form
    {
        public object[] infos;
        public FrmDDStokGirisCikis()
        {
            InitializeComponent();
        }

        private void FrmDestekDepoMlzHazirlama_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDepoMlzHazirlama"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void CmbIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbIslemTuru.Text== "100-YENİ DEPO GİRİŞİ")
            {
                GrbYeniDepoGiris.Visible = true;
                GrbDepodanDepoya.Visible = false;
                GrbDepodanPersonele.Visible = false;
                GrbpersoneldenDepoya.Visible = false;
            }
            if (CmbIslemTuru.Text == "101-DEPODAN DEPOYA İADE")
            {
                GrbYeniDepoGiris.Visible = false;
                GrbDepodanDepoya.Visible = true;
                GrbDepodanPersonele.Visible = false;
                GrbpersoneldenDepoya.Visible = false;
            }
            if (CmbIslemTuru.Text == "102-DEPODAN PERSONELE İADE")
            {
                GrbYeniDepoGiris.Visible = false;
                GrbDepodanDepoya.Visible = false;
                GrbDepodanPersonele.Visible = true;
                GrbpersoneldenDepoya.Visible = false;
            }
            if (CmbIslemTuru.Text == "201-PERSONELDE DEPOYA İADE")
            {
                GrbYeniDepoGiris.Visible = false;
                GrbDepodanDepoya.Visible = false;
                GrbDepodanPersonele.Visible = false;
                GrbpersoneldenDepoya.Visible = true;
            }
        }
    }
}
