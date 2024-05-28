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
    public partial class IzlemeGeciciKabul : Form
    {
        AmbarVeriManager ambarVeriManager;
        List<AmbarVeri> ambarVeris = new List<AmbarVeri>();

        public IzlemeGeciciKabul()
        {
            InitializeComponent();
            ambarVeriManager = AmbarVeriManager.GetInstance();
        }

        private void IzlemeGeciciKabul_Load(object sender, EventArgs e)
        {
            TimerSaat.Start();
            DataDisplay();
            timer1.Start();
            timer2.Start();
        }
        void DataDisplay()
        {
            ambarVeris.Clear();
            ambarVeris = ambarVeriManager.GetList();

            LblBakimOnarim.Text = ambarVeris[0].FabrikaBO.ToString();
            LblGeciciKabul.Text = ambarVeris[0].MalzemeTeminAselsan.ToString();
            LblKaliteTest.Text = ambarVeris[0].MalzemeTeminSat.ToString();
            LblDepoStokControl.Text = ambarVeris[0].MalzemeHazirlama.ToString();
            LblGeciciKullanim.Text = ambarVeris[0].DepoStokControl.ToString();
            LblMalzemeTeminSat.Text = ambarVeris[0].GenelTop.ToString();

            label23.Text = ambarVeris[0].BolgeSevkiyat.ToString();
            label22.Text = ambarVeris[0].Sevkiyat1.ToString();
            label21.Text = ambarVeris[0].Sevkiyat2.ToString();
            label20.Text = ambarVeris[0].AnkaraSevkiyat.ToString();

            //LblImes.Text = ambarVerisAselsan[0].Tekjen.ToString();
            //LblTekjen.Text = ambarVerisAselsan[0].Tescom.ToString();

            //LblBd.Text = ambarVerisAselsan[0].Bd.ToString();
            //LblDBolgesi.Text = ambarVerisAselsan[0].DBolgesi.ToString();
            //LblAtolye.Text = ambarVerisAselsan[0].Atolye.ToString();
            //LblBd2.Text = ambarVerisAselsan[0].Bd.ToString();
            //LblBd3.Text = ambarVerisAselsan[0].Bd2.ToString();

            //LblSarp.Text = ambarVerisAselsan[0].Sarp.ToString();

            //LblTescom.Text = ambarVerisAselsan[0].Tescom.ToString();
            //LblInform.Text = ambarVerisAselsan[0].Inform.ToString();
            //LblMgm.Text= ambarVerisAselsan[0].Mgm.ToString();



            //LblFabrikaBO.Text = ambarVeris[0].FabrikaBO.ToString();
            //LblMalzTeminAselsan.Text = ambarVeris[0].MalzemeTeminAselsan.ToString();
            
            //LblMalzemeHazirlama.Text = ambarVeris[0].MalzemeHazirlama.ToString();

            //LblBolgeSevkiyat.Text = ambarVeris[0].BolgeSevkiyat.ToString();
            //LblSevkiyatAnkara.Text = ambarVeris[0].AnkaraSevkiyat.ToString();

            //LblGenelToplam.Text = (ambarVeris[0].GenelTop - ambarVeris[0].FabrikaBO).ToString();

        }

        private void TimerSaat_Tick(object sender, EventArgs e)
        {
            LblSaat.Text = DateTime.Now.ToString("HH:mm:ss");
            LblTarih.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label24.Text = label24.Text.Substring(1) + label24.Text.Substring(0, 1);
        }
    }
}
