using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmDeneme : Form
    {
        public FrmDeneme()
        {
            InitializeComponent();
        }

        private void FrmDeneme_Load(object sender, EventArgs e)
        {

        }


        private void LoadExcel()
        {
            // some work takes 5 sec
            Thread.Sleep(5000);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // start the waiting animation
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;

            // simply start and await the loading task
            button1.Enabled = false;
            await Task.Run(() => LoadExcel());

            // re-enable things
            button1.Enabled = true;
            progressBar1.Visible = false;
        }
    }
}
