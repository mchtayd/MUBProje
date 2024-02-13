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
    public partial class FrmYemekListesi : Form
    {
        public FrmYemekListesi()
        {
            InitializeComponent();
        }

        private void FrmYemekListesi_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("Z:\\DTS\\İDARİ İŞLER\\YEMEK_LIST\\YEMEK LİSTESİ.pdf");
        }
    }
}
