using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using Entity.Gecic_Kabul_Ambar;
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
    public partial class FrmUstTakimEkle : Form
    {
        MalzemeKayitManager kayitManager;
        MalzemeManager malzemeManager;


        List<Malzeme> malzemes;
        List<Malzeme> malzemesFiltired;

        public FrmUstTakimEkle()
        {
            InitializeComponent();
            kayitManager = MalzemeKayitManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
        }

        private void FrmUstTakimEkle_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }
        void DataDisplay()
        {
            malzemes = malzemeManager.GetList();
            malzemesFiltired = malzemes;
            dataBinder.DataSource = malzemes.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["StokNo"].HeaderText = "STOK NO";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["Birim"].Visible = false;
            DtgList.Columns["TedarikciFirma"].Visible = false;
            DtgList.Columns["OnarimDurumu"].Visible = false;
            DtgList.Columns["OnarimYeri"].Visible = false;
            DtgList.Columns["TedarikTuru"].Visible = false;
            DtgList.Columns["ParcaSinifi"].Visible = false;
            DtgList.Columns["AlternatifParca"].Visible = false;
            DtgList.Columns["Aciklama"].Visible = false;
            DtgList.Columns["DosyaYolu"].Visible = false;
            DtgList.Columns["SistemStokNo"].Visible = false;
            DtgList.Columns["SistemTanimi"].Visible = false;
            DtgList.Columns["SistemSorumlusu"].Visible = false;
            DtgList.Columns["IslemYapan"].Visible = false;
            DtgList.Columns["TakipDurumu"].Visible = false;
            DtgList.Columns["UstStok"].Visible = false;
            DtgList.Columns["UstTanim"].Visible = false;
            DtgList.Columns["BenzersizId"].Visible = false;
        }

        private void TxtStokNo_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtStokNo.Text;
            if (string.IsNullOrEmpty(isim))
            {
                malzemesFiltired = malzemes;
                dataBinder.DataSource = malzemes.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtStokNo.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemesFiltired.Where(x => x.StokNo.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            malzemesFiltired = malzemes;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void TxtTanim_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtTanim.Text;
            if (string.IsNullOrEmpty(isim))
            {
                malzemesFiltired = malzemes;
                dataBinder.DataSource = malzemes.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtTanim.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemesFiltired.Where(x => x.Tanim.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            malzemesFiltired = malzemes;
            TxtTop.Text = DtgList.RowCount.ToString();
        }
        string stok = "";
        int id;
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            stok = DtgList.CurrentRow.Cells["Stokno"].Value.ToString();
        }

        private void BtnUstEkle_Click(object sender, EventArgs e)
        {
            if (stok=="")
            {
                MessageBox.Show("Lütfen Öncelikle Geçerli Bir Malzeme Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(stok + " Stok Nolu Malzemeyi Üst Takım Olarak Kaydetmek İstediğinize Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                string mesaj = malzemeManager.MazlemeUstTakimEkle(id);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                FrmMalzemeKayit frmMalzemeKayit = new FrmMalzemeKayit();
                frmMalzemeKayit.CmbStokNoUst();
                frmMalzemeKayit.CmbStokNoUst2();
                this.Close();
            }
        }
    }
}
