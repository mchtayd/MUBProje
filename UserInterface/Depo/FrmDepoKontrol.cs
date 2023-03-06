using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity.IdariIsler;
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

namespace UserInterface.Depo
{
    public partial class FrmDepoKontrol : Form
    {
        MalzemeTalepManager malzemeTalepManager;
        List<MalzemeTalep> masrafYeriSorumlulari;
        List<MalzemeTalep> malzemeTaleps;

        public FrmDepoKontrol()
        {
            InitializeComponent();
            malzemeTalepManager = MalzemeTalepManager.GetInstance();
        }

        private void FrmDepoKontrol_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        public void DataDisplay()
        {
            masrafYeriSorumlulari = malzemeTalepManager.MasrafYeriSorumlusu();

            dataBinder.DataSource = masrafYeriSorumlulari.ToDataTable();
            DtgList.DataSource = dataBinder;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["MalzemeKategorisi"].HeaderText = "MALZEME KATEGORİSİ";
            DtgList.Columns["TalepEdenPersonel"].Visible = false;
            DtgList.Columns["Tanim"].Visible = false;
            DtgList.Columns["StokNo"].Visible = false;
            DtgList.Columns["Miktar"].Visible = false;
            DtgList.Columns["Birim"].Visible = false;
            DtgList.Columns["TalebiOlusturan"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgList.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgList.Columns["SatBilgisi"].Visible = false;
            DtgList.Columns["MasrafYeri"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["IslemDurumu"].Visible = false;
            DtgList.Columns["RedGerekcesi"].Visible = false;
            DtgList.Columns["DepoDurum"].Visible = false;

            DtgList.Columns["ToplamMiktar"].HeaderText = "TOPLAM KAYIT";
            Toplamlar();

        }
        void Toplamlar()
        {
            for (int i = 0; i < DtgList.RowCount; i++)
            {

                int toplam = malzemeTalepManager.GetToplam(DtgList.Rows[i].Cells["TalebiOlusturan"].Value.ToString(), 
                    DtgList.Rows[i].Cells["MalzemeKategorisi"].Value.ToString());

                DtgList.Rows[i].Cells["ToplamMiktar"].Value = toplam;
            }

        }

        private void BtnKontrolEt_Click(object sender, EventArgs e)
        {
            
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.RowCount==0)
            {
                return;
            }

            string talebiOlusturan = DtgList.CurrentRow.Cells["TalebiOlusturan"].Value.ToString();
            string talebiKategori = DtgList.CurrentRow.Cells["MalzemeKategorisi"].Value.ToString();


            malzemeTaleps = malzemeTalepManager.GetListPersonel(talebiOlusturan, talebiKategori);

            dataBinder2.DataSource = malzemeTaleps.ToDataTable();
            DtgList2.DataSource = dataBinder2;

            DtgList2.Columns["Id"].Visible = false;
            DtgList2.Columns["MalzemeKategorisi"].HeaderText = "MALZEME KATEGORİSİ";
            DtgList2.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDİLEN PERSONEL";
            DtgList2.Columns["Tanim"].HeaderText = "TANIM";
            DtgList2.Columns["StokNo"].HeaderText = "STOK NO";
            DtgList2.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgList2.Columns["Birim"].HeaderText = "BİRİM";
            DtgList2.Columns["TalebiOlusturan"].Visible = false;
            DtgList2.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgList2.Columns["SatBilgisi"].Visible = false;
            DtgList2.Columns["MasrafYeri"].Visible = false;
            DtgList2.Columns["IslemDurumu"].HeaderText = "İŞLEM DURUMU";
            DtgList2.Columns["RedGerekcesi"].Visible = false;
            DtgList2.Columns["ToplamMiktar"].Visible = false;
            DtgList2.Columns["DepoDurum"].HeaderText = "DEPO DURUMU";


            DtgList2.Columns["Bolum"].DisplayIndex = 0;
            DtgList2.Columns["MasrafYeri"].DisplayIndex = 1;
            DtgList2.Columns["TalebiOlusturan"].DisplayIndex = 2;
            DtgList2.Columns["MalzemeKategorisi"].DisplayIndex = 3;
            DtgList2.Columns["StokNo"].DisplayIndex = 4;
            DtgList2.Columns["Tanim"].DisplayIndex = 5;
            DtgList2.Columns["TalepEdenPersonel"].DisplayIndex = 6;
            DtgList2.Columns["Miktar"].DisplayIndex = 7;
            DtgList2.Columns["Birim"].DisplayIndex = 8;
            DtgList2.Columns["SatBilgisi"].DisplayIndex = 9;
            DtgList2.Columns["Id"].DisplayIndex = 10;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDepoKontrol"]);
            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
    }
}
