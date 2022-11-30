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
    public partial class FrmBildirimPanel : Form
    {
        public FrmBildirimPanel()
        {
            InitializeComponent();
        }

        private void FrmBildirimPanel_Load(object sender, EventArgs e)
        {
            this.Left = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            this.Height = 1000;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
