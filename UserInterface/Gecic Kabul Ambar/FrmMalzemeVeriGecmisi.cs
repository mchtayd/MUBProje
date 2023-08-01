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
        public int benzersizId;
        public string stok, tanim, birim, miktar;
        public FrmMalzemeVeriGecmisi()
        {
            InitializeComponent();
            abfMalzemeIslemKayitManager = AbfMalzemeIslemKayitManager.GetInstance();
        }

        private void FrmMalzemeVeriGecmisi_Load(object sender, EventArgs e)
        {
            LblStok.Text = stok;
            LblTanim.Text = tanim;
            LblMiktar.Text = miktar;
            LblBirim.Text = birim;
            DtgGecmis.DataSource = abfMalzemeIslemKayitManager.GetList(benzersizId);
            DtgGecmis.Columns["Id"].Visible = false;
            DtgGecmis.Columns["BenzersizId"].Visible = false;
            DtgGecmis.Columns["Islem"].HeaderText = "İŞLEM";
            DtgGecmis.Columns["Tarih"].HeaderText = "TARİH";
            DtgGecmis.Columns["IslemYapan"].HeaderText = "İŞLEM YAPAN";
            DtgGecmis.Columns["GecenSure"].HeaderText = "GEÇEN SÜRE";

            LblTop.Text = DtgGecmis.RowCount.ToString();
        }
    }
}
