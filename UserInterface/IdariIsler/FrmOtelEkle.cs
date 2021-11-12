using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.IdariIsler
{
    public partial class FrmOtelEkle : Form
    {
        TedarikciFirmaManager tedarikciFirmaManager;
        OtelManager otelManager;
        public FrmOtelEkle()
        {
            InitializeComponent();
            tedarikciFirmaManager = TedarikciFirmaManager.GetInstance();
            otelManager = OtelManager.GetInstance();
        }

        private void FrmOtelEkle_Load(object sender, EventArgs e)
        {
            CmbIlYükle();
        }
        void CmbIlYükle()
        {
            CmbIl.DataSource = tedarikciFirmaManager.Iller();
            CmbIl.SelectedIndex = -1;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Otel Bilgisini Kaydetmek İstediğinize Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                Otel otel = new Otel(CmbIl.Text, TxtOtelinAdi.Text);
                string mesaj = otelManager.Add(otel);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedildi.");
                CmbIl.SelectedIndex = -1;
                TxtOtelinAdi.Clear();
            }
        }
    }
}
