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
    public partial class FrmSAAAT : Form
    {
        public FrmSAAAT()
        {
            InitializeComponent();
        }

        private void FrmSAAAT_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSAAT"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void ChcStokYok_CheckedChanged(object sender, EventArgs e)
        {
            if (ChcStokYok.Checked == true)
            {
                panel2.Visible = true;
                LblStokArana.Enabled = false;
                TxtStokArama.Enabled = false;
                LblTanimArama.Enabled = false;
                TxtTanimArama.Enabled = false;
                GrbYedekParca.Enabled = false;
            }
            else
            {
                panel2.Visible = false;
                LblStokArana.Enabled = true;
                TxtStokArama.Enabled = true;
                LblTanimArama.Enabled = true;
                TxtTanimArama.Enabled = true;
                GrbYedekParca.Enabled = true;
            }
        }
    }
}
