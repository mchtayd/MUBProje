using Business.Concreate.Yerleskeler;
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

namespace UserInterface.Yerleskeler
{
    public partial class FrmYerleskeGideriKayit : Form
    {
        KiraManager kiraManager;
        //bool start 
        public FrmYerleskeGideriKayit()
        {
            InitializeComponent();
            kiraManager = KiraManager.GetInstance();
        }

        private void FrmYerleskeGideriKayit_Load(object sender, EventArgs e)
        {
            YerleskeAdlari();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageYerleskeGideriKayit"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void YerleskeAdlari()
        {
            CmbYerleskeAdi.DataSource = kiraManager.GetList();
            CmbYerleskeAdi.ValueMember = "Id";
            CmbYerleskeAdi.DisplayMember = "YerleskeAdi";
            CmbYerleskeAdi.SelectedValue = 0;
        }

        private void CmbYerleskeAdi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
