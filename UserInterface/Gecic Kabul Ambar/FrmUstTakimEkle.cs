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

        List<MalzemeKayit> malzemeKayits;
        List<MalzemeKayit> malzemeKayitsFiltired;
        public FrmUstTakimEkle()
        {
            InitializeComponent();
            kayitManager = MalzemeKayitManager.GetInstance();
        }

        private void FrmUstTakimEkle_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }
        void DataDisplay()
        {
            malzemeKayits = kayitManager.GetListMalzemeKayit();
            malzemeKayitsFiltired = malzemeKayits;
            dataBinder.DataSource = malzemeKayits.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Stokno"].HeaderText = "STOK NO";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["Birim"].Visible = false;
            DtgList.Columns["Tedarikcifirma"].Visible = false;
            DtgList.Columns["Malzemeonarimdurumu"].Visible = false;
            DtgList.Columns["Malzemeonarımyeri"].Visible = false;
            DtgList.Columns["Malzemeturu"].Visible = false;
            DtgList.Columns["Malzemetakipdurumu"].Visible = false;
            //DtgList.Columns["Malzemerevizyon"].Visible = false;
            //DtgList.Columns["Malzemelot"].HeaderText = "MALZEME LOT NO";
            DtgList.Columns["Malzemekul"].Visible = false;
            DtgList.Columns["Aciklama"].Visible = false;
            DtgList.Columns["Dosyayolu"].Visible = false;
            DtgList.Columns["AlternatifMalzeme"].Visible = false;
            DtgList.Columns["SistemStokNo"].Visible = false;
            DtgList.Columns["SistemTanim"].Visible = false;
            DtgList.Columns["SistemPersonel"].Visible = false;
            DtgList.Columns["DataTypeValue"].Visible = false;

            DtgList.Columns["KayitDurumu"].Visible = false;
            DtgList.Columns["SeriNo"].Visible = false;
            DtgList.Columns["Durum"].Visible = false;
            DtgList.Columns["Revizyon"].Visible = false;
            DtgList.Columns["Miktar"].Visible = false;
            DtgList.Columns["TalepTarihi"].Visible = false;
            DtgList.Columns["SistemStokNo"].Visible = false;
            DtgList.Columns["SistemTanim"].Visible = false;
        }

        private void TxtStokNo_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtStokNo.Text;
            if (string.IsNullOrEmpty(isim))
            {
                malzemeKayitsFiltired = malzemeKayits;
                dataBinder.DataSource = malzemeKayits.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtStokNo.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemeKayitsFiltired.Where(x => x.Stokno.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            malzemeKayitsFiltired = malzemeKayits;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void TxtTanim_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtTanim.Text;
            if (string.IsNullOrEmpty(isim))
            {
                malzemeKayitsFiltired = malzemeKayits;
                dataBinder.DataSource = malzemeKayits.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtTanim.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemeKayitsFiltired.Where(x => x.Tanim.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            malzemeKayitsFiltired = malzemeKayits;
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
                string mesaj = kayitManager.UsTakimGuncelle(id);
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
