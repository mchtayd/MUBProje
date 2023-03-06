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
    public partial class FrmWait : Form
    {
        public FrmWait()
        {
            InitializeComponent();
        }
        public static bool isActive = false;
        private void FrmWait_Load(object sender, EventArgs e)
        {
            isActive = true;
        }

        private void FrmWait_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isActive)
            {
                e.Cancel = true;
            }
        }
    }
}
