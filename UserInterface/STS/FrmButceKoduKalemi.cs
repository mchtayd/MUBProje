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
    public partial class FrmButceKoduKalemi : Form
    {
        public FrmButceKoduKalemi()
        {
            InitializeComponent();
        }

        private void FrmButceKoduKalemi_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(@"Z:\DTS\SATIN ALMA\Folder\ASL-001_MGÜB_BÜTÇE KALEMLERİ-2021.pdf");
            //webBrowser1.Navigate(@"C:\STS\ASL-001_MGÜB_BÜTÇE KALEMLERİ-2021.pdf");
        }
    }
}
