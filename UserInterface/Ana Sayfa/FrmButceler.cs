using Business.Concreate.Butce;
using DataAccess.Concreate;
using Entity.Butce;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using UserInterface.STS;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmButceler : Form
    {
        ButceManager butceManager;

        List<ButceKayit> butceKayits;
        public FrmButceler()
        {
            InitializeComponent();
            butceManager = ButceManager.GetInstance();
        }

        private void FrmButceler_Load(object sender, EventArgs e)
        {
            GrafikCiz();


            //chart1.Series["GELİR"].Points.AddXY("GELİR", 30);
            //chart1.Series["GİDER"].Points.AddXY("GİDER", 40);
            //chart1.Series["KALAN"].Points.AddXY("KALAN", 60);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageButceIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void GrafikCiz()
        {
            chart1.Titles.Add("2022 1. Dönem Bütçe Dağılımı");

            butceKayits = butceManager.GetList();

            for (int i = 0; i < butceKayits.Count(); i++)
            {
                string[] array = butceKayits[i].ButceTutariYillik.Split('?');
                Series series = chart1.Series.Add(butceKayits[i].ButceTanim);
                series.Points.AddXY(butceKayits[i].ButceTanim, array[1].ConDouble());

            }
        }
    }
}
