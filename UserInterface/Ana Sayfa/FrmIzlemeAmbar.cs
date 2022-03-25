using Business;
using Entity;
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
    public partial class FrmIzlemeAmbar : Form
    {
        AmbarVeriManager ambarVeriManager;
        List<AmbarVeri> ambarVeris = new List<AmbarVeri>();
        List<AmbarVeri> ambarVerisAselsan = new List<AmbarVeri>();
        public FrmIzlemeAmbar()
        {
            InitializeComponent();
            ambarVeriManager = AmbarVeriManager.GetInstance();
        }

        private void FrmIzlemeAmbar_Load(object sender, EventArgs e)
        {
            LblTarih.Text = DateTime.Now.ToLongDateString();
            TimerSaat.Start();
            DataDisplay();
            timer1.Start();
        }
        void DataDisplay()
        {
            ambarVeris.Clear();
            ambarVerisAselsan.Clear();
            ambarVerisAselsan = ambarVeriManager.GetListAselsan();
            ambarVeris = ambarVeriManager.GetList();

            LblBakimOnarim.Text = ambarVerisAselsan[0].BakimOnarim.ToString();
            LblGeciciKabul.Text = ambarVerisAselsan[0].GeciciKabul.ToString();
            LblKaliteTest.Text = ambarVerisAselsan[0].KaliteTest.ToString();
            LblUges.Text = ambarVerisAselsan[0].Uges.ToString();
            LblMgeo.Text = ambarVerisAselsan[0].Mgeo.ToString();
            LblSst.Text = ambarVerisAselsan[0].Sst.ToString();
            LblRehis.Text = ambarVerisAselsan[0].Rehis.ToString();
            LblFabrikaBO.Text = ambarVeris[0].FabrikaBO.ToString();
            LblMalzTeminAselsan.Text = ambarVeris[0].MalzemeTeminAselsan.ToString();
            LblMalzemeTeminSat.Text = ambarVeris[0].MalzemeTeminSat.ToString();
            LblMalzemeHazirlama.Text = ambarVeris[0].MalzemeHazirlama.ToString();
            LblMalzemePaketleme.Text = ambarVeris[0].MalzemePaketleme.ToString();
            LblBolgeSevkiyat.Text = ambarVeris[0].BolgeSevkiyat.ToString();

            LblGenelToplam.Text = (ambarVeris[0].GenelTop - ambarVeris[0].FabrikaBO).ToString();

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void TimerSaat_Tick(object sender, EventArgs e)
        {
            LblSaat.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
