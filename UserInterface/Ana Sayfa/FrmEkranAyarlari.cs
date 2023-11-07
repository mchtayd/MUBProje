using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmEkranAyarlari : Form
    {
        public object[] infos;
        public FrmEkranAyarlari()
        {
            InitializeComponent();
        }

        private void CmdMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmdMod.Text== "Normal Mod")
            {
                LblCozunurluk.Text = "1920 X 1080";
            }
            if (CmdMod.Text == "Küçük Mod")
            {
                LblCozunurluk.Text = "1366 X 768";
            }
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            if (CmdMod.Text=="")
            {
                MessageBox.Show("Lütfen bir mod seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Ekran modu değişikliği yapmak istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                FrmSmallScreen frmSmallScreen = new FrmSmallScreen();
                frmSmallScreen.infos = infos;
                frmSmallScreen.Show();
            }
        }
    }
}
