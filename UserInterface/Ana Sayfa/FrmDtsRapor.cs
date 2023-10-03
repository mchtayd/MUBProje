using Business.Concreate.AnaSayfa;
using Business.Concreate.IdarıIsler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmDtsRapor : Form
    {
        PersonelKayitManager kayitManager;
        DtsLogManager dtsLogManager;
        public FrmDtsRapor()
        {
            InitializeComponent();
            kayitManager = PersonelKayitManager.GetInstance();
            dtsLogManager = DtsLogManager.GetInstance();
        }

        private void FrmDtsRapor_Load(object sender, EventArgs e)
        {
            DataDisplay();
            Personeller();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDtsRapor"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        void Personeller()
        {
            CmbPersonel.DataSource = kayitManager.PersonelAdSoyad();
            CmbPersonel.ValueMember = "Id";
            CmbPersonel.DisplayMember = "Adsoyad";
            CmbPersonel.SelectedValue = -1;
        }

        void DataDisplay()
        {

        }

        private void BtnSorgula_Click(object sender, EventArgs e)
        {
            
        }
    }
}
