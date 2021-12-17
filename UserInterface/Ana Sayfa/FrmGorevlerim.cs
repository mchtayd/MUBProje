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
    public partial class FrmGorevlerim : Form
    {
        string pageText1 = "", pageText3 = "";
        public FrmGorevlerim()
        {
            InitializeComponent();
        }

        private void advancedDataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip2.Show();
        }

        private void FrmGorevlerim_Load(object sender, EventArgs e)
        {

            // DATAGRİD LOADING

            pageText1 = "AÇIK ARIZA GÖREVLERİM " + "( " + TxtTop.Text + " )";
            pageText3 = "İŞ AKIŞI GÖREVLERİM " + "( " + TxtTop3.Text + " )";

            tabPage1.Text = pageText1;
            tabPage3.Text = pageText3;
        }
    }
}
