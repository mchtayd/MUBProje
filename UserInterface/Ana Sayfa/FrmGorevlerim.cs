using Business.Concreate;
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
    public partial class FrmGorevlerim : Form
    {
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        List<GorevAtamaPersonel> gorevAtamaPersonels;

        string pageText1 = "", pageText3 = "";
        public object[] infos;
        public FrmGorevlerim()
        {
            InitializeComponent();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
        }

        private void advancedDataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip2.Show();
        }

        private void FrmGorevlerim_Load(object sender, EventArgs e)
        {
            DataDisplay();

            pageText1 = "AÇIK ARIZA GÖREVLERİM " + "( " + TxtTop.Text + " )";
            pageText3 = "İŞ AKIŞI GÖREVLERİM " + "( " + TxtTop3.Text + " )";

            tabPage1.Text = pageText1;
            tabPage3.Text = pageText3;
        }
        void DataDisplay()
        {
            gorevAtamaPersonels = gorevAtamaPersonelManager.AtolyeGorevlerimiGor(infos[1].ToString());
            DtgGorevlerim.DataSource = gorevAtamaPersonels;

            DtgGorevlerim.Columns["Id"].Visible = false;
            DtgGorevlerim.Columns["BenzersizId"].Visible = false;
            DtgGorevlerim.Columns["Departman"].Visible = false;
            DtgGorevlerim.Columns["GorevAtanacakPersonel"].HeaderText = "GÖREV ATANAN PERSONEL";
            DtgGorevlerim.Columns["IslemAdimi"].HeaderText = "İŞLEM ADIMI";
            DtgGorevlerim.Columns["Tarih"].HeaderText = "TARİH";
            DtgGorevlerim.Columns["Sure"].HeaderText = "İŞLEM ADIMI SÜRELERİ";
            DtgGorevlerim.Columns["YapilanIslem"].HeaderText = "YAPILAN İŞLEM";
            DtgGorevlerim.Columns["IscilikSuresi"].HeaderText = "İŞÇİLİK SÜRESİ";
            TxtTop.Text = DtgGorevlerim.RowCount.ToString();

            /*Toplamlar();
            ToplamlarIslemAdimSureleri();*/
        }

    }
}
