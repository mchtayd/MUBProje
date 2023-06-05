using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmSlayGorunum : Form
    {
        List<string> list = new List<string>();
        public FrmSlayGorunum()
        {
            InitializeComponent();
        }

        private void FrmSlayGorunum_Load(object sender, EventArgs e)
        {

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (Control()!="OK")
            {
                MessageBox.Show(Control(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            timer1.Start();

        }
        string Control()
        {
            if (ChkAmbar.Checked==true)
            {
                return "OK";
            }
            if (ChkAtolye.Checked == true)
            {
                return "OK";
            }
            if (ChkAcikAriza.Checked==true)
            {
                return "OK";
            }
            if (ChkAltYuk.Checked==true)
            {
                return "OK";
            }
            if (ChkBolumBazliAcik.Checked == true)
            {
                return "OK";
            }
            if (ChkBolgeBazli.Checked==true)
            {
                return "OK";
            }
            if (ChkAcikArizaSure.Checked==true)
            {
                return "OK";
            }
            if (ChkArizaSure.Checked==true)
            {
                return "OK";
            }
            return "Lütfen bir sayfa seçiniz!";
        }

        private void FrmSlayGorunum_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PnlSlayt.Visible = true;
            
            
        }

        private void ChkAmbar_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
