using Business.Concreate.BakimOnarim;
using DocumentFormat.OpenXml.Office2010.Excel;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmMalzemeVeriGecmisi : Form
    {
        AbfMalzemeIslemKayitManager abfMalzemeIslemKayitManager;
        public int benzersizId, takilanmiktar;
        public string sokulenstok, sokulentanim, sokulenbirim, sokulenmiktar, sokulenSeriNo, sokulenRevizyon, takilanstok, takilantanim, takilanbirim, takilanSeriNo, takilanRevizyon;
        public FrmMalzemeVeriGecmisi()
        {
            InitializeComponent();
            abfMalzemeIslemKayitManager = AbfMalzemeIslemKayitManager.GetInstance();
        }

        private void FrmMalzemeVeriGecmisi_Load(object sender, EventArgs e)
        {
            LblStokSokulen.Text = sokulenstok;
            LblTanimSokulen.Text = sokulentanim;
            LblMiktarSokulen.Text = sokulenbirim;
            LblBirimSokulen.Text = sokulenmiktar;
            LblSeriLotNoSokulen.Text = sokulenSeriNo;
            LblRevizyonSokulen.Text = sokulenRevizyon;

            LblStokTakilan.Text = takilanstok;
            LblTanimTakilan.Text = takilantanim;
            LblMiktarTakilan.Text = takilanmiktar.ToString();
            LblBirimTakilan.Text = takilanbirim;
            LblSeriLotNoTakilan.Text = takilanSeriNo;
            LblRevizyonTakilan.Text = takilanRevizyon;

            DtgGecmisSokulen.DataSource = abfMalzemeIslemKayitManager.GetList(benzersizId,"SÖKÜLEN");
            DtgGecmisSokulen.Columns["Id"].Visible = false;
            DtgGecmisSokulen.Columns["BenzersizId"].Visible = false;
            DtgGecmisSokulen.Columns["Islem"].HeaderText = "İŞLEM";
            DtgGecmisSokulen.Columns["Tarih"].HeaderText = "TARİH";
            DtgGecmisSokulen.Columns["IslemYapan"].HeaderText = "İŞLEM YAPAN";
            DtgGecmisSokulen.Columns["GecenSure"].HeaderText = "GEÇEN SÜRE";
            DtgGecmisSokulen.Columns["StokNo"].Visible = false;
            DtgGecmisSokulen.Columns["SeriNo"].Visible = false;
            DtgGecmisSokulen.Columns["Revizyon"].Visible = false;
            DtgGecmisSokulen.Columns["MalzemeDurumu"].Visible = false;


            LblTop.Text = DtgGecmisSokulen.RowCount.ToString();

            DtgGecmisTakilan.DataSource = abfMalzemeIslemKayitManager.GetList(benzersizId, "TAKILAN");
            DtgGecmisTakilan.Columns["Id"].Visible = false;
            DtgGecmisTakilan.Columns["BenzersizId"].Visible = false;
            DtgGecmisTakilan.Columns["Islem"].HeaderText = "İŞLEM";
            DtgGecmisTakilan.Columns["Tarih"].HeaderText = "TARİH";
            DtgGecmisTakilan.Columns["IslemYapan"].HeaderText = "İŞLEM YAPAN";
            DtgGecmisTakilan.Columns["GecenSure"].HeaderText = "GEÇEN SÜRE";
            DtgGecmisTakilan.Columns["StokNo"].Visible = false;
            DtgGecmisTakilan.Columns["SeriNo"].Visible = false;
            DtgGecmisTakilan.Columns["Revizyon"].Visible = false;
            DtgGecmisTakilan.Columns["MalzemeDurumu"].Visible = false;

            LblTakilanTop.Text = DtgGecmisTakilan.RowCount.ToString();
        }
    }
}
