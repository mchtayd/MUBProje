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
    public partial class FrmAwait : Form
    {
        public FrmAwait()
        {
            InitializeComponent();
        }

        private void FrmAwait_Load(object sender, EventArgs e)
        {

        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            //if (progressBar1.Value < 100)
            //{
            //    progressBar1.Value += 1;
            //    LblYuzde.Text = progressBar1.Value.ToString() + " %";
            //}
            //else
            //{
            //    timer1.Stop();
            //    this.Close();
            //}
        }
    }
}
