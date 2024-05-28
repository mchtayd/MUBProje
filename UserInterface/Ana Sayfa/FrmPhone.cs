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
    public partial class FrmPhone : Form
    {
        public FrmPhone()
        {
            InitializeComponent();
        }

        private void FrmPhone_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("Z:\\DTS\\İDARİ İŞLER\\TELEFON REHBERİ\\DTS Telefon Rehberi.pdf");
        }
    }
}
