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
using UserInterface.STS;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmGorevAta : Form
    {
        PersonelKayitManager kayitManager;
        public string gorevinTanimi, islemAdimi, sayfa;
        
        public FrmGorevAta()
        {
            InitializeComponent();
            kayitManager = PersonelKayitManager.GetInstance();
        }

        private void FrmGorevAta_Load(object sender, EventArgs e)
        {
            Personeller();
            LblGorevinTanimi.Text = gorevinTanimi;
            LblIslemAdimi.Text = islemAdimi;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Görev Atama İşlemini Tamamlamak İstediğinize Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            
            if (dr==DialogResult.Yes)
            {
                GorevAtama();

            }

        }
        void GorevAtama()
        {
            if (sayfa== "SAT BAŞLATMA ONAYI")
            {
                FrmSatBaslatmaOnayi frmSatBaslatmaOnayi = new FrmSatBaslatmaOnayi();
                frmSatBaslatmaOnayi.gorevAtama = true;
            }
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
