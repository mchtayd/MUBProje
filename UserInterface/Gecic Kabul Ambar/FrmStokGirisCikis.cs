using Business.Concreate.Depo;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using Entity.Depo;
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
using UserInterface.BakımOnarım;
using UserInterface.STS;

namespace UserInterface.Depo
{
    public partial class FrmStokGirisCikis : Form
    {
        StokGirisCikisManager stokGirisCikisManager;
        MalzemeKayitManager malzemeKayitManager;
        DepoKayitManagercs depoKayitManagercs;
        List<MalzemeKayit> malzemeKayits;
        bool start = true;
        int id;
        string takipdurumu;

        public FrmStokGirisCikis()
        {
            InitializeComponent();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
            depoKayitManagercs = DepoKayitManagercs.GetInstance();
        }
        private void FrmStokGirisCikis_Load(object sender, EventArgs e)
        {
            StokBilgileri();
            CmbDepo();
            start = false;

        }
        public void CmbDepo()
        {
            CmbDepoNo.DataSource = depoKayitManagercs.GetList();
            CmbDepoNo.ValueMember = "Id";
            CmbDepoNo.DisplayMember = "Depo";
            CmbDepoNo.SelectedValue = 0;
        }
        void StokBilgileri()
        {
            malzemeKayits = malzemeKayitManager.GetList();
            CmbStokNo.DataSource = malzemeKayits;
            CmbStokNo.ValueMember = "Id";
            CmbStokNo.DisplayMember = "Stokno";
            CmbStokNo.SelectedValue = 0;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageStokGirisCikis"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {

            if (CmbStokNo.Text == "")
            {
                MessageBox.Show("Öncelikle Bir Stok Numarası Giriniz.");
                return;
            }
            if (TxtMiktar.Text == "")
            {
                MessageBox.Show("Lütfen Miktar Belirtiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (takipdurumu == "LOT NO")
            {
                AdvMalzemeOnizleme.Columns["SeriLotNo"].HeaderText = "LOT NO";
                AdvMalzemeOnizleme.Columns["Remove"].Visible = false;
            }
            else
            {
                AdvMalzemeOnizleme.Columns["SeriLotNo"].HeaderText = "SERİ NO";
                AdvMalzemeOnizleme.Columns["Remove"].Visible = true;
            }

            AdvMalzemeOnizleme.Rows.Clear();
            for (int i = 0; i < TxtMiktar.Text.ConInt(); i++)
            {
                AdvMalzemeOnizleme.Rows.Add();
                int sonSatir = AdvMalzemeOnizleme.RowCount - 1;
                AdvMalzemeOnizleme.Rows[sonSatir].Cells["SiraNo"].Value = i + 1;
                AdvMalzemeOnizleme.Rows[sonSatir].Cells["SeriLotNo"].Value = "";
                AdvMalzemeOnizleme.Rows[sonSatir].Cells["Revizyon"].Value = "";
            }
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)AdvMalzemeOnizleme.Columns["Remove"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;
        }

        private void AdvMalzemeOnizleme_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                AdvMalzemeOnizleme.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void CmbStokNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start)
            {
                return;
            }
            if (CmbStokNo.Text == "")
            {
                return;
            }
            FillTools();

        }
        void FillTools()
        {
            id = CmbStokNo.SelectedValue.ConInt();
            MalzemeKayit malzemeKayit = malzemeKayitManager.Get(id);
            TxtTanim.Text = malzemeKayit.Tanim;
            CmbBirim.Text = malzemeKayit.Birim;
            takipdurumu = malzemeKayit.Malzemetakipdurumu;
        }

        private void BtnListEkle_Click(object sender, EventArgs e)
        {
            DtgList.Rows.Clear();
            foreach (DataGridViewRow item in AdvMalzemeOnizleme.Rows)
            {
                int sirano = item.Cells["SiraNo"].Value.ConInt();
                StokGirisCıkıs entity = new StokGirisCıkıs(CmbIslemTuru.Text, CmbStokNo.Text, TxtTanim.Text, TxtMiktar.
                    Text.ConInt(), CmbBirim.Text, DtTarih.Value, CmbDepoNo.Text, CmbAdres.Text, TxtMalzemeYeri.Text, TxtAciklama.Text);

                DtgList.Rows.Add();
                int sonSatir = DtgList.RowCount - 1;

                DtgList.Rows[sonSatir].Cells["Column1"].Value = sirano;
                DtgList.Rows[sonSatir].Cells["Column13"].Value = entity.Islemturu;
                DtgList.Rows[sonSatir].Cells["Column2"].Value = CmbStokNo.Text;
                DtgList.Rows[sonSatir].Cells["Column3"].Value = TxtTanim.Text;
                DtgList.Rows[sonSatir].Cells["Column4"].Value = TxtMiktar.Text;
                DtgList.Rows[sonSatir].Cells["Column5"].Value = CmbBirim.Text;
                DtgList.Rows[sonSatir].Cells["Column6"].Value = DtTarih.Value;
                DtgList.Rows[sonSatir].Cells["Column7"].Value = CmbDepoNo.Text;
                DtgList.Rows[sonSatir].Cells["Column8"].Value = CmbAdres.Text;
                DtgList.Rows[sonSatir].Cells["Column9"].Value = TxtMalzemeYeri.Text;
                DtgList.Rows[sonSatir].Cells["Column14"].Value = TxtAciklama.Text;
                //Ctrl K D
                if (takipdurumu == "LOT NO")
                {
                    DtgList.Columns["Column10"].Visible = false;
                    DtgList.Rows[sonSatir].Cells["Column10"].Value = "YOK";
                    DtgList.Columns["Column12"].Visible = true;
                    DtgList.Rows[sonSatir].Cells["Column12"].Value = item.Cells["SeriLotNo"].Value.ToString();
                }
                else
                {
                    DtgList.Columns["Column12"].Visible = false;
                    DtgList.Rows[sonSatir].Cells["Column12"].Value = "YOK";
                    DtgList.Columns["Column10"].Visible = true;
                    DtgList.Rows[sonSatir].Cells["Column10"].Value = item.Cells["SeriLotNo"].Value.ToString();
                }
                DtgList.Rows[sonSatir].Cells["Column11"].Value = item.Cells["Revizyon"].Value.ToString();
            }
        }

        private void DtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    StokGirisCıkıs stokGiris = new StokGirisCıkıs(CmbIslemTuru.Text, CmbStokNo.Text, TxtTanim.Text, TxtMiktar.Text.ConInt(), CmbBirim.Text, DtTarih.Value, CmbDepoNo.Text, CmbAdres.Text, TxtMalzemeYeri.Text, TxtAciklama.Text, item.Cells["Column10"].Value.ToString(), item.Cells["Column12"].Value.ToString(), item.Cells["Column11"].Value.ToString());

                    stokGirisCikisManager.Add(stokGiris);
                }
                MessageBox.Show("Bilgileri Başarıyla Kaydedişmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Temizle();
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        void Temizle()
        {
            CmbIslemTuru.SelectedValue = ""; CmbStokNo.Text = ""; TxtTanim.Clear(); TxtMiktar.Clear(); CmbBirim.Text = ""; CmbDepoNo.Text = ""; CmbAdres.Text = "";
            TxtMalzemeYeri.Text = ""; TxtAciklama.Text = ""; 
            AdvMalzemeOnizleme.Rows.Clear(); DtgList.Rows.Clear();
        }

        private void BtnDepoEkle_Click(object sender, EventArgs e)
        {
            FrmDepoLokasyonKayit frmDepoLokasyonKayit = new FrmDepoLokasyonKayit();
            frmDepoLokasyonKayit.ShowDialog();
        }

        private void CmbDepoNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start==true)
            {
                return;
            }
            id = CmbDepoNo.SelectedValue.ConInt();
            DepoKayit depoKayit = depoKayitManagercs.Get(id);
            CmbAdres.Text = depoKayit.Aciklama;
        }

        private void TxtMiktar_TextChanged(object sender, EventArgs e)
        {
            if (CmbStokNo.Text == "")
            {
                MessageBox.Show("Öncelikle Bir Stok Numarası Giriniz.");
                return;
            }
            if (TxtMiktar.Text == "")
            {
                //MessageBox.Show("Lütfen Miktar Belirtiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //AdvMalzemeOnizleme.DataSource = "";
                AdvMalzemeOnizleme.Rows.Clear();
                return;
            }
            if (takipdurumu == "LOT NO")
            {
                AdvMalzemeOnizleme.Columns["SeriLotNo"].HeaderText = "LOT NO";
                AdvMalzemeOnizleme.Columns["Remove"].Visible = false;
            }
            else
            {
                AdvMalzemeOnizleme.Columns["SeriLotNo"].HeaderText = "SERİ NO";
                AdvMalzemeOnizleme.Columns["Remove"].Visible = true;
            }

            AdvMalzemeOnizleme.Rows.Clear();
            for (int i = 0; i < TxtMiktar.Text.ConInt(); i++)
            {
                AdvMalzemeOnizleme.Rows.Add();
                int sonSatir = AdvMalzemeOnizleme.RowCount - 1;
                AdvMalzemeOnizleme.Rows[sonSatir].Cells["SiraNo"].Value = i + 1;
                AdvMalzemeOnizleme.Rows[sonSatir].Cells["SeriLotNo"].Value = "";
                AdvMalzemeOnizleme.Rows[sonSatir].Cells["Revizyon"].Value = "";
            }
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)AdvMalzemeOnizleme.Columns["Remove"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;
        }
    }
}
