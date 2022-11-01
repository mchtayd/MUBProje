using Business.Concreate.IdarıIsler;
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

namespace UserInterface.IdariIsler
{
    public partial class FrmTalepIzleme : Form
    {
        MalzemeTalepManager malzemeTalepManager;
        List<MalzemeTalep> malzemeTaleps;
        public FrmTalepIzleme()
        {
            InitializeComponent();
            malzemeTalepManager = MalzemeTalepManager.GetInstance();
        }

        private void FrmTalepIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageMifIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgList.Rows[i].Cells["Miktar"].Value);
            }
            TxtMiktar.Text = toplam.ToString();
        }

        void DataDisplay()
        {
            malzemeTaleps = malzemeTalepManager.GetList();
            dataBinder.DataSource = malzemeTaleps.ToDataTable();
            DtgList.DataSource = dataBinder;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["MalzemeKategorisi"].HeaderText = "MALZEME KATEGORİSİ";
            DtgList.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDİLEN PERSONEL";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["StokNo"].HeaderText = "STOK NO";
            DtgList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgList.Columns["Birim"].HeaderText = "BİRİM";
            DtgList.Columns["TalebiOlusturan"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgList.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgList.Columns["SatBilgisi"].Visible = false;
            DtgList.Columns["MasrafYeri"].HeaderText = "MASRAF YERİ NO";

            
            DtgList.Columns["Bolum"].DisplayIndex = 0;
            DtgList.Columns["MasrafYeri"].DisplayIndex = 1;
            DtgList.Columns["TalebiOlusturan"].DisplayIndex = 2;
            DtgList.Columns["MalzemeKategorisi"].DisplayIndex = 3;
            DtgList.Columns["StokNo"].DisplayIndex = 4;
            DtgList.Columns["Tanim"].DisplayIndex = 5;
            DtgList.Columns["TalepEdenPersonel"].DisplayIndex = 6;
            DtgList.Columns["Miktar"].DisplayIndex = 7;
            DtgList.Columns["Birim"].DisplayIndex = 8;
            DtgList.Columns["SatBilgisi"].DisplayIndex = 9;
            DtgList.Columns["Id"].DisplayIndex = 10;

            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();

        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        private void BtnSatOlustur_Click(object sender, EventArgs e)
        {

            //StringBuilder strB = new StringBuilder();
            //strB.AppendLine("<html><head><meta charset=utf-8><style>table{padding:10px;} th,td{padding:8px;}</style></head><body>");
            //strB.AppendLine("<html><head><meta charset=utf-8><style>h1{padding:20px; align=center}</style></head><body>");
            //strB.AppendLine(
            //"<h1>BAŞLIK</h1>" +
            //"<br><br> Aşağıda bilgileri verilen arızalar için fiyat teklifi alınmıştır.Bir sonraki ayda tarafınıza fatura edilecektir.Alım yapmak için onayınızı rica ediyorum. <br><br> İyi Çalışmalar.<br><br>");

            //strB.AppendLine("</body></html>");

            //webContent.DocumentText = strB.ToString();



        }
    }
}
