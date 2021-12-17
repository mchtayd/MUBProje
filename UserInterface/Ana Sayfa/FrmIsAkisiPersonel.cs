using Business.Concreate.IdarıIsler;
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
    public partial class FrmIsAkisiPersonel : Form
    {
        PersonelKayitManager kayitManager;
        public FrmIsAkisiPersonel()
        {
            InitializeComponent();
            kayitManager = PersonelKayitManager.GetInstance();
        }

        private void FrmIsAkisiPersonel_Load(object sender, EventArgs e)
        {
            Personeller();
        }
        void Personeller()
        {
            CmbPersoneller.DataSource = kayitManager.PersonelAdSoyad();
            CmbPersoneller.ValueMember = "Id";
            CmbPersoneller.DisplayMember = "Adsoyad";
            CmbPersoneller.SelectedValue = -1;
        }
    }
}
