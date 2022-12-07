using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmBildirimPanel : Form
    {
        public string icerik = "";
        public FrmBildirimPanel()
        {
            InitializeComponent();
        }

        private void FrmBildirimPanel_Load(object sender, EventArgs e)
        {
            
        }

        private void FrmBildirimPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmHelper.PanelClickEdit(icerik);
        }

    }
}
