using Business.Concreate.AnaSayfa;
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
        LogManager logManager;
        public string icerik = "";
        public FrmBildirimPanel()
        {
            InitializeComponent();
            logManager = LogManager.GetInstance();
        }

        private void FrmBildirimPanel_Load(object sender, EventArgs e)
        {
            
        }

        private void FrmBildirimPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            string mesaj = logManager.Update(icerik);
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return;
            }
        }

    }
}
