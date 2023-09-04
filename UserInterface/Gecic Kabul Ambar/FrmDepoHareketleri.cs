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
using UserInterface.STS;

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmDepoHareketleri : Form
    {
        StokGirisCikisManager stokGirisCikisManager;
        List<StokGirisCıkıs> stokGirisCıkıs;
        int id = 0;
        public object[] infos;
        string tiklananStok, tiklananSeriNo, tiklananRevizyon;

        public FrmDepoHareketleri()
        {
            InitializeComponent();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
        }

        private void FrmDepoHareketleri_Load(object sender, EventArgs e)
        {
            if (infos[1].ToString() == "RESUL GÜNEŞ" || infos[11].ToString() == "ADMİN" || infos[0].ConInt() == 39)
            {
                contextMenuStrip1.Items[0].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[0].Enabled = false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDepoHaraketleri"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        public void DataDisplay()
        {
            if (TxtStokNo.Text!="" && TxtSeriNo.Text=="")
            {
                stokGirisCıkıs = stokGirisCikisManager.GetList(TxtStokNo.Text);
            }
            if (TxtStokNo.Text == "" && TxtSeriNo.Text != "")
            {
                stokGirisCıkıs = stokGirisCikisManager.GetList("",TxtSeriNo.Text);
            }
            if (TxtStokNo.Text != "" && TxtSeriNo.Text != "")
            {
                stokGirisCıkıs = stokGirisCikisManager.GetList(TxtStokNo.Text, TxtSeriNo.Text);
            }
            if (TxtStokNo.Text == "" && TxtSeriNo.Text == "")
            {
                stokGirisCıkıs = stokGirisCikisManager.GetList();
            }
            dataBinder.DataSource = stokGirisCıkıs.ToDataTable();
            DtgList.DataSource = dataBinder;
            DtgDuzenle();

        }
        void DtgDuzenle()
        {
            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Islemturu"].HeaderText = "İŞLEM TÜRÜ";
            DtgList.Columns["IslemTarihi"].HeaderText = "İŞLEM TARİHİ";
            DtgList.Columns["Stokno"].HeaderText = "STOK NO";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["Serino"].HeaderText = "SERİ NO";
            DtgList.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgList.Columns["DusulenMiktar"].HeaderText = "DÜŞÜLEN MİKTAR";
            DtgList.Columns["Birim"].HeaderText = "BİRİM";
            DtgList.Columns["Lotno"].HeaderText = "LOT NO";
            DtgList.Columns["CekilenDepoNo"].HeaderText = "ÇEKİLEN DEPO NO/YER";
            DtgList.Columns["CekilenDepoAdresi"].HeaderText = "ÇEKİLEN DEPO ADRESİ";
            DtgList.Columns["CekilenMalzemeYeri"].HeaderText = "ÇEKİLEN MALZEME YERİ";
            DtgList.Columns["DusulenDepoNo"].HeaderText = "DÜŞÜLEN DEPO NO/YER";
            DtgList.Columns["DusulenDepoAdresi"].HeaderText = "DÜŞÜLEN DEPO ADRESİ";
            DtgList.Columns["DusulenMalzemeYeri"].HeaderText = "DÜŞÜLEN MALZEME YERİ";
            DtgList.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgList.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            
            
            DtgList.Columns["Id"].DisplayIndex = 0;
            DtgList.Columns["Islemturu"].DisplayIndex = 1;
            DtgList.Columns["IslemTarihi"].DisplayIndex = 2;
            DtgList.Columns["Stokno"].DisplayIndex = 3;
            DtgList.Columns["Tanim"].DisplayIndex = 4;
            DtgList.Columns["Serino"].DisplayIndex = 5;
            DtgList.Columns["Revizyon"].DisplayIndex = 6;
            DtgList.Columns["DusulenMiktar"].DisplayIndex = 7;
            DtgList.Columns["Birim"].DisplayIndex = 8;
            DtgList.Columns["Lotno"].DisplayIndex = 9;
            DtgList.Columns["CekilenDepoNo"].DisplayIndex = 10;
            DtgList.Columns["CekilenDepoAdresi"].DisplayIndex = 11;
            DtgList.Columns["CekilenMalzemeYeri"].DisplayIndex = 12;
            DtgList.Columns["DusulenDepoNo"].DisplayIndex = 13;
            DtgList.Columns["DusulenDepoAdresi"].DisplayIndex = 14;
            DtgList.Columns["DusulenMalzemeYeri"].DisplayIndex = 15;
            DtgList.Columns["TalepEdenPersonel"].DisplayIndex = 16;
            DtgList.Columns["Aciklama"].DisplayIndex = 17;

            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort= DtgList.SortString;
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmDepoHareketleriEdit frmDepoHareketleriEdit = new FrmDepoHareketleriEdit();
            frmDepoHareketleriEdit.id = id;
            frmDepoHareketleriEdit.ShowDialog();
            id = 0;
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.RowCount==0)
            {
                return;
            }
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            tiklananStok = DtgList.CurrentRow.Cells["Stokno"].Value.ToString();
            tiklananSeriNo = DtgList.CurrentRow.Cells["Serino"].Value.ToString();
            tiklananRevizyon = DtgList.CurrentRow.Cells["Revizyon"].Value.ToString();
        }

        private void barkodOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tiklananStok == "")
            {
                MessageBox.Show("Lütfen bir stok seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmDepoDusum frmDepoDusum = new FrmDepoDusum();
            frmDepoDusum.stok = tiklananStok;
            frmDepoDusum.seriNo = tiklananSeriNo;
            frmDepoDusum.revizyon = tiklananRevizyon;
            frmDepoDusum.infos = infos;
            frmDepoDusum.Show();
            tiklananStok = "";
        }
    }
}
