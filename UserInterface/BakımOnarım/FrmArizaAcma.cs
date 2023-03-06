using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Gecic_Kabul_Ambar;
using UserInterface.STS;

namespace UserInterface.BakımOnarım
{
    public partial class FrmArizaAcma : Form
    {
        public bool buton = false;
        public FrmArizaAcma()
        {
            InitializeComponent();
        }

        private void FrmArizaAcma_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            /*FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageArizaAcma"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }*/
        }

        private void BtnBolgeEkle_Click(object sender, EventArgs e)
        {
            FrmBolgeler frmBolgeler = new FrmBolgeler();
            buton = true;
            frmBolgeler.buton = buton;
            frmBolgeler.ShowDialog();
        }

        private void BtnMalzemeEkle_Click(object sender, EventArgs e)
        {
            FrmMalzemeKayit frmMalzemeKayit = new FrmMalzemeKayit();
            buton = true;
            frmMalzemeKayit.buton = buton;
            frmMalzemeKayit.ShowDialog();
        }

        private void BtnPYPKayit_Click(object sender, EventArgs e)
        {
            FrmPyp frmPyp = new FrmPyp();
            frmPyp.ShowDialog();
        }
    }
}
