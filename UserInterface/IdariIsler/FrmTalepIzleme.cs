using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Office2010.Excel;
using Entity.Gecic_Kabul_Ambar;
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
        List<MalzemeTalep> malzemesOnayAsamasinda;
        List<MalzemeTalep> malzemesOnaylandi;
        List<MalzemeTalep> malzemesReddedildi;
        List<MalzemeTalep> malzemesSatOlusturuldu;
        List<MalzemeTalep> malzemesTedarikEdildi;
        List<MalzemeTalep> malzemesTeslimAlindi;

        int id;
        public FrmTalepIzleme()
        {
            InitializeComponent();
            malzemeTalepManager = MalzemeTalepManager.GetInstance();
        }

        private void FrmTalepIzleme_Load(object sender, EventArgs e)
        {
            DataDisplayOnayAsamasi();
            DataDisplayOnaylandı();
            DataDisplayReddedildi();
            DataDisplaySat();
            DataDisplayTedarikEdildi();
            DataDisplayTeslimAlindi();
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

        void ToplamlarOnaylandı()
        {
            double toplam = 0;
            for (int i = 0; i < DtgListOnaylandı.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgListOnaylandı.Rows[i].Cells["Miktar"].Value);
            }
            TxtMiktarOnaylandi.Text = toplam.ToString();
        }
        void ToplamlarReddedildi()
        {
            double toplam = 0;
            for (int i = 0; i < DtgListReddedildi.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgListReddedildi.Rows[i].Cells["Miktar"].Value);
            }
            TxtMiktarReddedildi.Text = toplam.ToString();
        }

        void ToplamlarSat()
        {
            double toplam = 0;
            for (int i = 0; i < DtgListSat.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgListSat.Rows[i].Cells["Miktar"].Value);
            }
            TxtMiktarSat.Text = toplam.ToString();
        }
        void ToplamlarTedarikEdildi()
        {
            double toplam = 0;
            for (int i = 0; i < DtgTdarikEdildi.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgTdarikEdildi.Rows[i].Cells["Miktar"].Value);
            }
            LblTedarikTop.Text = toplam.ToString();
        }
        void ToplamlarTeslimAlindi()
        {
            double toplam = 0;
            for (int i = 0; i < DtgTeslimAlindi.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgTeslimAlindi.Rows[i].Cells["Miktar"].Value);
            }
            LblTeslimAlindiTop.Text = toplam.ToString();
        }

        public void DataDisplayOnayAsamasi()
        {
            malzemesOnayAsamasinda = malzemeTalepManager.GetList("ONAY AŞAMASINDA");
            dataBinder.DataSource = malzemesOnayAsamasinda.ToDataTable();
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
            DtgList.Columns["IslemDurumu"].HeaderText = "İŞLEM DURUMU";
            DtgList.Columns["RedGerekcesi"].Visible = false;
            DtgList.Columns["Secim"].Visible = false;
            DtgList.Columns["ToplamMiktar"].Visible = false;
            DtgList.Columns["DepoDurum"].Visible = false;

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

        public void DataDisplayOnaylandı()
        {
            malzemesOnaylandi = malzemeTalepManager.GetList("ONAYLANDI, STOK KONTROL");
            dataBinderOnaylandı.DataSource = malzemesOnaylandi.ToDataTable();
            DtgListOnaylandı.DataSource = dataBinderOnaylandı;

            DtgListOnaylandı.Columns["Id"].Visible = false;
            DtgListOnaylandı.Columns["MalzemeKategorisi"].HeaderText = "MALZEME KATEGORİSİ";
            DtgListOnaylandı.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDİLEN PERSONEL";
            DtgListOnaylandı.Columns["Tanim"].HeaderText = "TANIM";
            DtgListOnaylandı.Columns["StokNo"].HeaderText = "STOK NO";
            DtgListOnaylandı.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgListOnaylandı.Columns["Birim"].HeaderText = "BİRİM";
            DtgListOnaylandı.Columns["TalebiOlusturan"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgListOnaylandı.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgListOnaylandı.Columns["SatBilgisi"].Visible = false;
            DtgListOnaylandı.Columns["MasrafYeri"].HeaderText = "MASRAF YERİ NO";
            DtgListOnaylandı.Columns["IslemDurumu"].HeaderText = "İŞLEM DURUMU";
            DtgListOnaylandı.Columns["RedGerekcesi"].Visible = false;
            DtgListOnaylandı.Columns["Secim"].Visible = false;
            DtgListOnaylandı.Columns["ToplamMiktar"].Visible = false;
            DtgListOnaylandı.Columns["DepoDurum"].Visible = false;

            DtgListOnaylandı.Columns["Bolum"].DisplayIndex = 0;
            DtgListOnaylandı.Columns["MasrafYeri"].DisplayIndex = 1;
            DtgListOnaylandı.Columns["TalebiOlusturan"].DisplayIndex = 2;
            DtgListOnaylandı.Columns["MalzemeKategorisi"].DisplayIndex = 3;
            DtgListOnaylandı.Columns["StokNo"].DisplayIndex = 4;
            DtgListOnaylandı.Columns["Tanim"].DisplayIndex = 5;
            DtgListOnaylandı.Columns["TalepEdenPersonel"].DisplayIndex = 6;
            DtgListOnaylandı.Columns["Miktar"].DisplayIndex = 7;
            DtgListOnaylandı.Columns["Birim"].DisplayIndex = 8;
            DtgListOnaylandı.Columns["SatBilgisi"].DisplayIndex = 9;
            DtgListOnaylandı.Columns["Id"].DisplayIndex = 10;

            TxtTopOnaylandı.Text = DtgListOnaylandı.RowCount.ToString();
            ToplamlarOnaylandı();
        }

        public void DataDisplayReddedildi()
        {
            malzemesReddedildi = malzemeTalepManager.GetList("REDDEDİLDİ");
            dataBinderReddedildi.DataSource = malzemesReddedildi.ToDataTable();
            DtgListReddedildi.DataSource = dataBinderReddedildi;

            DtgListReddedildi.Columns["Id"].Visible = false;
            DtgListReddedildi.Columns["MalzemeKategorisi"].HeaderText = "MALZEME KATEGORİSİ";
            DtgListReddedildi.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDİLEN PERSONEL";
            DtgListReddedildi.Columns["Tanim"].HeaderText = "TANIM";
            DtgListReddedildi.Columns["StokNo"].HeaderText = "STOK NO";
            DtgListReddedildi.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgListReddedildi.Columns["Birim"].HeaderText = "BİRİM";
            DtgListReddedildi.Columns["TalebiOlusturan"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgListReddedildi.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgListReddedildi.Columns["SatBilgisi"].Visible = false;
            DtgListReddedildi.Columns["MasrafYeri"].HeaderText = "MASRAF YERİ NO";
            DtgListReddedildi.Columns["IslemDurumu"].HeaderText = "İŞLEM DURUMU";
            DtgListReddedildi.Columns["RedGerekcesi"].Visible = false;
            DtgListReddedildi.Columns["Secim"].Visible = false;
            DtgListReddedildi.Columns["ToplamMiktar"].Visible = false;
            DtgListReddedildi.Columns["DepoDurum"].Visible = false;

            DtgListReddedildi.Columns["Bolum"].DisplayIndex = 0;
            DtgListReddedildi.Columns["MasrafYeri"].DisplayIndex = 1;
            DtgListReddedildi.Columns["TalebiOlusturan"].DisplayIndex = 2;
            DtgListReddedildi.Columns["MalzemeKategorisi"].DisplayIndex = 3;
            DtgListReddedildi.Columns["StokNo"].DisplayIndex = 4;
            DtgListReddedildi.Columns["Tanim"].DisplayIndex = 5;
            DtgListReddedildi.Columns["TalepEdenPersonel"].DisplayIndex = 6;
            DtgListReddedildi.Columns["Miktar"].DisplayIndex = 7;
            DtgListReddedildi.Columns["Birim"].DisplayIndex = 8;
            DtgListReddedildi.Columns["SatBilgisi"].DisplayIndex = 9;
            DtgListReddedildi.Columns["Id"].DisplayIndex = 10;

            TxtTopReddedildi.Text = DtgListReddedildi.RowCount.ToString();
            ToplamlarReddedildi();
        }
        public void DataDisplaySat()
        {
            malzemesSatOlusturuldu = malzemeTalepManager.GetList("SAT OLUŞTURULDU, TEDARİK AŞAMASINDA");
            dataBinderSat.DataSource = malzemesSatOlusturuldu.ToDataTable();
            DtgListSat.DataSource = dataBinderSat;

            DtgListSat.Columns["Id"].Visible = false;
            DtgListSat.Columns["MalzemeKategorisi"].HeaderText = "MALZEME KATEGORİSİ";
            DtgListSat.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDİLEN PERSONEL";
            DtgListSat.Columns["Tanim"].HeaderText = "TANIM";
            DtgListSat.Columns["StokNo"].HeaderText = "STOK NO";
            DtgListSat.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgListSat.Columns["Birim"].HeaderText = "BİRİM";
            DtgListSat.Columns["TalebiOlusturan"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgListSat.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgListSat.Columns["SatBilgisi"].Visible = false;
            DtgListSat.Columns["MasrafYeri"].HeaderText = "MASRAF YERİ NO";
            DtgListSat.Columns["IslemDurumu"].HeaderText = "İŞLEM DURUMU";
            DtgListSat.Columns["RedGerekcesi"].Visible = false;
            DtgListSat.Columns["Secim"].Visible = false;
            DtgListSat.Columns["ToplamMiktar"].Visible = false;
            DtgListSat.Columns["DepoDurum"].Visible = false;

            DtgListSat.Columns["Bolum"].DisplayIndex = 0;
            DtgListSat.Columns["MasrafYeri"].DisplayIndex = 1;
            DtgListSat.Columns["TalebiOlusturan"].DisplayIndex = 2;
            DtgListSat.Columns["MalzemeKategorisi"].DisplayIndex = 3;
            DtgListSat.Columns["StokNo"].DisplayIndex = 4;
            DtgListSat.Columns["Tanim"].DisplayIndex = 5;
            DtgListSat.Columns["TalepEdenPersonel"].DisplayIndex = 6;
            DtgListSat.Columns["Miktar"].DisplayIndex = 7;
            DtgListSat.Columns["Birim"].DisplayIndex = 8;
            DtgListSat.Columns["SatBilgisi"].DisplayIndex = 9;
            DtgListSat.Columns["Id"].DisplayIndex = 10;

            TxtTopSat.Text = DtgListSat.RowCount.ToString();
            ToplamlarSat();
        }

        public void DataDisplayTedarikEdildi()
        {
            malzemesTedarikEdildi = malzemeTalepManager.GetList("TEDARİK EDİLDİ");
            dataBinderTedarikEdildi.DataSource = malzemesTedarikEdildi.ToDataTable();
            DtgTdarikEdildi.DataSource = dataBinderTedarikEdildi;

            DtgTdarikEdildi.Columns["Id"].Visible = false;
            DtgTdarikEdildi.Columns["MalzemeKategorisi"].HeaderText = "MALZEME KATEGORİSİ";
            DtgTdarikEdildi.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDİLEN PERSONEL";
            DtgTdarikEdildi.Columns["Tanim"].HeaderText = "TANIM";
            DtgTdarikEdildi.Columns["StokNo"].HeaderText = "STOK NO";
            DtgTdarikEdildi.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgTdarikEdildi.Columns["Birim"].HeaderText = "BİRİM";
            DtgTdarikEdildi.Columns["TalebiOlusturan"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgTdarikEdildi.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgTdarikEdildi.Columns["SatBilgisi"].Visible = false;
            DtgTdarikEdildi.Columns["MasrafYeri"].HeaderText = "MASRAF YERİ NO";
            DtgTdarikEdildi.Columns["IslemDurumu"].HeaderText = "İŞLEM DURUMU";
            DtgTdarikEdildi.Columns["RedGerekcesi"].Visible = false;
            DtgTdarikEdildi.Columns["Secim"].Visible = false;
            DtgTdarikEdildi.Columns["ToplamMiktar"].Visible = false;
            DtgTdarikEdildi.Columns["DepoDurum"].Visible = false;

            DtgTdarikEdildi.Columns["Bolum"].DisplayIndex = 0;
            DtgTdarikEdildi.Columns["MasrafYeri"].DisplayIndex = 1;
            DtgTdarikEdildi.Columns["TalebiOlusturan"].DisplayIndex = 2;
            DtgTdarikEdildi.Columns["MalzemeKategorisi"].DisplayIndex = 3;
            DtgTdarikEdildi.Columns["StokNo"].DisplayIndex = 4;
            DtgTdarikEdildi.Columns["Tanim"].DisplayIndex = 5;
            DtgTdarikEdildi.Columns["TalepEdenPersonel"].DisplayIndex = 6;
            DtgTdarikEdildi.Columns["Miktar"].DisplayIndex = 7;
            DtgTdarikEdildi.Columns["Birim"].DisplayIndex = 8;
            DtgTdarikEdildi.Columns["SatBilgisi"].DisplayIndex = 9;
            DtgTdarikEdildi.Columns["Id"].DisplayIndex = 10;

            LblTedarikEdildi.Text = DtgTdarikEdildi.RowCount.ToString();
            ToplamlarTedarikEdildi();
        }
        public void DataDisplayTeslimAlindi()
        {
            malzemesTeslimAlindi = malzemeTalepManager.GetList("TESLIM ALINDI");
            dataBinderTeslimAlindi.DataSource = malzemesTeslimAlindi.ToDataTable();
            DtgTeslimAlindi.DataSource = dataBinderTeslimAlindi;

            DtgTeslimAlindi.Columns["Id"].Visible = false;
            DtgTeslimAlindi.Columns["MalzemeKategorisi"].HeaderText = "MALZEME KATEGORİSİ";
            DtgTeslimAlindi.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDİLEN PERSONEL";
            DtgTeslimAlindi.Columns["Tanim"].HeaderText = "TANIM";
            DtgTeslimAlindi.Columns["StokNo"].HeaderText = "STOK NO";
            DtgTeslimAlindi.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgTeslimAlindi.Columns["Birim"].HeaderText = "BİRİM";
            DtgTeslimAlindi.Columns["TalebiOlusturan"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgTeslimAlindi.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgTeslimAlindi.Columns["SatBilgisi"].Visible = false;
            DtgTeslimAlindi.Columns["MasrafYeri"].HeaderText = "MASRAF YERİ NO";
            DtgTeslimAlindi.Columns["IslemDurumu"].HeaderText = "İŞLEM DURUMU";
            DtgTeslimAlindi.Columns["RedGerekcesi"].Visible = false;
            DtgTeslimAlindi.Columns["Secim"].Visible = false;
            DtgTeslimAlindi.Columns["ToplamMiktar"].Visible = false;
            DtgTeslimAlindi.Columns["DepoDurum"].Visible = false;

            DtgTeslimAlindi.Columns["Bolum"].DisplayIndex = 0;
            DtgTeslimAlindi.Columns["MasrafYeri"].DisplayIndex = 1;
            DtgTeslimAlindi.Columns["TalebiOlusturan"].DisplayIndex = 2;
            DtgTeslimAlindi.Columns["MalzemeKategorisi"].DisplayIndex = 3;
            DtgTeslimAlindi.Columns["StokNo"].DisplayIndex = 4;
            DtgTeslimAlindi.Columns["Tanim"].DisplayIndex = 5;
            DtgTeslimAlindi.Columns["TalepEdenPersonel"].DisplayIndex = 6;
            DtgTeslimAlindi.Columns["Miktar"].DisplayIndex = 7;
            DtgTeslimAlindi.Columns["Birim"].DisplayIndex = 8;
            DtgTeslimAlindi.Columns["SatBilgisi"].DisplayIndex = 9;
            DtgTeslimAlindi.Columns["Id"].DisplayIndex = 10;

            LblTeslimAlindi.Text = DtgTeslimAlindi.RowCount.ToString();
            ToplamlarTeslimAlindi();
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

        private void onayAşamasındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("Lütfen öncekikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string mesaj = malzemeTalepManager.DurumUpdate(id, "ONAY AŞAMASINDA");
            if (mesaj!="OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = 0;
            DataDisplayOnayAsamasi();
            DataDisplayOnaylandı();
            DataDisplayReddedildi();
            DataDisplaySat();
            DataDisplayTedarikEdildi();
            DataDisplayTeslimAlindi();
            MessageBox.Show("Bilgiler başarıyla güncellenmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        string tabloAdi = "";
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            tabloAdi = "ONAY AŞAMASINDA";
        }

        private void onaylandıStokKontrolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncekikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string mesaj = malzemeTalepManager.DurumUpdate(id, "ONAYLANDI, STOK KONTROL");
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = 0;
            DataDisplayOnayAsamasi();
            DataDisplayOnaylandı();
            DataDisplayReddedildi();
            DataDisplaySat();
            DataDisplayTedarikEdildi();
            DataDisplayTeslimAlindi();
            MessageBox.Show("Bilgiler başarıyla güncellenmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void reddedildiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncekikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string mesaj = malzemeTalepManager.DurumUpdate(id, "REDDEDİLDİ");
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = 0;
            DataDisplayOnayAsamasi();
            DataDisplayOnaylandı();
            DataDisplayReddedildi();
            DataDisplaySat();
            DataDisplayTedarikEdildi();
            DataDisplayTeslimAlindi();
            MessageBox.Show("Bilgiler başarıyla güncellenmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void satOluşturulduTeadrikAşamasındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncekikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string mesaj = malzemeTalepManager.DurumUpdate(id, "SAT OLUŞTURULDU, TEDARİK AŞAMASINDA");
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = 0;
            DataDisplayOnayAsamasi();
            DataDisplayOnaylandı();
            DataDisplayReddedildi();
            DataDisplaySat();
            DataDisplayTedarikEdildi();
            DataDisplayTeslimAlindi();
            MessageBox.Show("Bilgiler başarıyla güncellenmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tedarikEdildiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncekikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string mesaj = malzemeTalepManager.DurumUpdate(id, "TEDARİK EDİLDİ");
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = 0;
            DataDisplayOnayAsamasi();
            DataDisplayOnaylandı();
            DataDisplayReddedildi();
            DataDisplaySat();
            DataDisplayTedarikEdildi();
            DataDisplayTeslimAlindi();
            MessageBox.Show("Bilgiler başarıyla güncellenmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void teslimAlındıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncekikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string mesaj = malzemeTalepManager.DurumUpdate(id, "TESLIM ALINDI");
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = 0;
            DataDisplayOnayAsamasi();
            DataDisplayOnaylandı();
            DataDisplayReddedildi();
            DataDisplaySat();
            DataDisplayTedarikEdildi();
            DataDisplayTeslimAlindi();
            MessageBox.Show("Bilgiler başarıyla güncellenmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DtgListOnaylandı_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinderOnaylandı.Filter = DtgListOnaylandı.FilterString;
            TxtTopOnaylandı.Text = DtgListOnaylandı.RowCount.ToString();
            ToplamlarOnaylandı();
        }

        private void DtgListOnaylandı_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderOnaylandı.Sort = DtgListOnaylandı.SortString;
        }

        private void DtgListReddedildi_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinderReddedildi.Filter = DtgListReddedildi.FilterString;
            TxtTopReddedildi.Text = DtgListReddedildi.RowCount.ToString();
            ToplamlarReddedildi();
        }

        private void DtgListReddedildi_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderReddedildi.Sort = DtgListReddedildi.SortString;
        }

        private void DtgListSat_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinderSat.Filter = DtgListSat.FilterString;
            TxtTopSat.Text = DtgListSat.RowCount.ToString();
            ToplamlarSat();
        }

        private void DtgListSat_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderSat.Sort = DtgListSat.SortString;
        }

        private void DtgTdarikEdildi_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinderTedarikEdildi.Filter = DtgTdarikEdildi.FilterString;
            LblTedarikEdildi.Text = DtgTdarikEdildi.RowCount.ToString();
            ToplamlarTedarikEdildi();
        }

        private void DtgTdarikEdildi_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderTedarikEdildi.Sort = DtgTdarikEdildi.SortString;
        }

        private void DtgTeslimAlindi_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinderTeslimAlindi.Filter = DtgTeslimAlindi.FilterString;
            LblTedarikEdildi.Text = DtgTeslimAlindi.RowCount.ToString();
            ToplamlarTeslimAlindi();
        }

        private void DtgTeslimAlindi_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderTeslimAlindi.Sort = DtgTeslimAlindi.SortString;
        }

        private void DtgListOnaylandı_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgListOnaylandı.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = DtgListOnaylandı.CurrentRow.Cells["Id"].Value.ConInt();
            tabloAdi = "ONAYLANDI";
        }

        private void DtgListReddedildi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgListReddedildi.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = DtgListReddedildi.CurrentRow.Cells["Id"].Value.ConInt();
            tabloAdi = "REDDEDİLDİ";
        }

        private void DtgListSat_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgListSat.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = DtgListSat.CurrentRow.Cells["Id"].Value.ConInt();
            tabloAdi = "SAT";
        }

        private void DtgTdarikEdildi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgTdarikEdildi.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = DtgTdarikEdildi.CurrentRow.Cells["Id"].Value.ConInt();
            tabloAdi = "TEDARİK EDİLDİ";
        }

        private void DtgTeslimAlindi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgTeslimAlindi.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = DtgTeslimAlindi.CurrentRow.Cells["Id"].Value.ConInt();
            tabloAdi = "TESLİM ALINDI";
        }
    }
}
