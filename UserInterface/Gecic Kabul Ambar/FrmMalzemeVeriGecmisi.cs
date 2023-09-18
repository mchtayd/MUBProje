using Business.Concreate.BakimOnarim;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Presentation;
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
        int id;
        public string sokulenstok, sokulentanim, sokulenbirim, sokulenmiktar, sokulenSeriNo, sokulenRevizyon, takilanstok, takilantanim, takilanbirim, takilanSeriNo, takilanRevizyon;
        string islem = "";
        public object[] infos;
        public FrmMalzemeVeriGecmisi()
        {
            InitializeComponent();
            abfMalzemeIslemKayitManager = AbfMalzemeIslemKayitManager.GetInstance();
        }
        void DataDisplaySokulen()
        {
            DtgGecmisSokulen.DataSource = abfMalzemeIslemKayitManager.GetList(benzersizId, "SÖKÜLEN");
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
        }
        void DataDisplayTakilan()
        {
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

        private void FrmMalzemeVeriGecmisi_Load(object sender, EventArgs e)
        {
            if (infos[0].ConInt()==25)
            {
                contextMenuStrip1.Items[0].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[0].Enabled = false;
            }
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

            DataDisplaySokulen();
            DataDisplayTakilan();


        }
        private void DtgGecmisSokulen_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgGecmisSokulen.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            id = DtgGecmisSokulen.CurrentRow.Cells["Id"].Value.ConInt();
            islem = DtgGecmisSokulen.CurrentRow.Cells["Islem"].Value.ToString();
        }

        private void DtgGecmisTakilan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgGecmisTakilan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            id = DtgGecmisTakilan.CurrentRow.Cells["Id"].Value.ConInt();
            islem = DtgGecmisTakilan.CurrentRow.Cells["Islem"].Value.ToString();
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(islem + " islem adimini silmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = abfMalzemeIslemKayitManager.Delete(id);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }

                MessageBox.Show("Bilgiler başarıyla silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataDisplaySokulen();
                DataDisplayTakilan();

            }
        }
    }
}
