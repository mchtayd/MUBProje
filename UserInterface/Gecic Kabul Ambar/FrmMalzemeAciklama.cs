using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmMalzemeAciklama : Form
    {
        public string aciklama;
        public FrmMalzemeAciklama()
        {
            InitializeComponent();
        }

        private void FrmMalzemeAciklama_Load(object sender, EventArgs e)
        {

        }

        private void BtnTamam_Click(object sender, EventArgs e)
        {
            if (TxtAciklama.Text=="")
            {
                MessageBox.Show("Lütfen öncelikle aciklama bilgisini yazınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmMalzemeHazirlama frmMalzemeHazirlama = (FrmMalzemeHazirlama)Application.OpenForms["FrmMalzemeHazirlama"];
            frmMalzemeHazirlama.aciklama = TxtAciklama.Text;
            this.Close();
        }
    }
}
