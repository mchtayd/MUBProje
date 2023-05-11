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
using UserInterface.STS;

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
            LblImes.Text = ambarVerisAselsan[0].Imes.ToString();
            LblTekjen.Text = ambarVerisAselsan[0].Tekjen.ToString();
            LblTescom.Text = ambarVerisAselsan[0].Tescom.ToString();
            LblInform.Text = ambarVerisAselsan[0].Inform.ToString();
            LblMgm.Text= ambarVerisAselsan[0].Mgm.ToString();
            LblBd.Text = ambarVerisAselsan[0].Bd.ToString();
            LblDBolgesi.Text = ambarVerisAselsan[0].DBolgesi.ToString();
            LblAtolye.Text = ambarVerisAselsan[0].Atolye.ToString();
            LblBd2.Text = ambarVerisAselsan[0].Bd.ToString();
            LblSarp.Text = ambarVerisAselsan[0].Sarp.ToString();
            LblBd3.Text = ambarVerisAselsan[0].Bd2.ToString();
            LblGeciciKullanim.Text = ambarVerisAselsan[0].GeciciKullanim.ToString();

            //LblFabrikaBO.Text = ambarVeris[0].FabrikaBO.ToString();
            LblMalzTeminAselsan.Text = ambarVeris[0].MalzemeTeminAselsan.ToString();
            LblMalzemeTeminSat.Text = ambarVeris[0].MalzemeTeminSat.ToString();
            LblMalzemeHazirlama.Text = ambarVeris[0].MalzemeHazirlama.ToString();
            LblDepoStokControl.Text = ambarVeris[0].DepoStokControl.ToString();
            LblBolgeSevkiyat.Text = ambarVeris[0].BolgeSevkiyat.ToString();
            LblSevkiyatAnkara.Text = ambarVeris[0].AnkaraSevkiyat.ToString();

            //LblGenelToplam.Text = (ambarVeris[0].GenelTop - ambarVeris[0].FabrikaBO).ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void TimerSaat_Tick(object sender, EventArgs e)
        {
            LblSaat.Text = DateTime.Now.ToString("HH:mm:ss");
            LblTarih.Text = DateTime.Now.ToLongDateString();
        }

        private void FrmIzlemeAmbar_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            TimerSaat.Stop();
            FrmAnaSayfa anaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnaSayfa"];
            anaSayfa.timerIzlemeChc.Stop();
            //FrmSahaIzleme frmSahaIzleme = (FrmSahaIzleme)Application.OpenForms["FrmSahaIzleme"];
            //if (frmSahaIzleme!=null)
            //{
            //    frmSahaIzleme.Close();
            //}
            
        }
    }
}
