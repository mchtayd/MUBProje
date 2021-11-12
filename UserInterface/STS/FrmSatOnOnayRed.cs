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
    public partial class FrmSatOnOnayRed : Form
    {
        public FrmSatOnOnayRed()
        {
            InitializeComponent();
        }

        private void FrmSatOnOnayRed_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtRedNedeni.Text=="")
            {
                MessageBox.Show("Lütfen Red Nedeni Ksımını Doldurunuz.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            string rednedeni = TxtRedNedeni.Text;
            Properties.Settings.Default.RedNedeni = rednedeni;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
