using Business.Concreate.BakimOnarim;
using DataAccess.Concreate;
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
using UserInterface.STS;

namespace UserInterface.BakımOnarım
{
    public partial class FrmOkfIzleme : Form
    {
        OkfManager okfManager;
        DtfMaliyetManager dtfMaliyetManager;
        List<Okf> okfs;
        List<DtfMaliyet> dtfMaliyets;
        List<Okf> yapilacakIslemler;
        public object[] infos;
        string dosyaYolu;
        int id;
        double toplam;
        public FrmOkfIzleme()
        {
            InitializeComponent();
            okfManager = OkfManager.GetInstance();
            dtfMaliyetManager = DtfMaliyetManager.GetInstance();
        }

        private void FrmOkfIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }
        public void DataDisplay()
        {
            okfs = okfManager.GetList();
            dataBinder.DataSource = okfs.ToDataTable();
            DtgList.DataSource = dataBinder;

            LblTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["KayitYapan"].HeaderText = "KAYIT YAPAN";
            DtgList.Columns["KayitTarihi"].HeaderText = "KAYIT TARİHİ";
            DtgList.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgList.Columns["ArizaTarihi"].HeaderText = "ARIZA TARİHİ";
            DtgList.Columns["UsBolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgList.Columns["ProjeKodu"].HeaderText = "PROJE KODU";
            DtgList.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgList.Columns["UbKomutani"].HeaderText = "ÜS BÖLGESİ KOMUTANI";
            DtgList.Columns["KomutanTel"].HeaderText = "ÜS BÖLGESİ TELEFON";
            DtgList.Columns["BirlikAdresi"].HeaderText = "BİRLİK ADRESİ";
            DtgList.Columns["Il"].HeaderText = "İL";
            DtgList.Columns["Ilce"].HeaderText = "İLÇE";
            DtgList.Columns["UstStok"].HeaderText = "STOK NO";
            DtgList.Columns["UstTanim"].HeaderText = "TANIM";
            DtgList.Columns["UstSeriNo"].HeaderText = "SERİ NO";
            DtgList.Columns["BildirilenAriza"].HeaderText = "BİLDİRİLEN ARIZA";
            DtgList.Columns["ArizaDurum"].Visible = false;
            DtgList.Columns["ArizaNedeni"].HeaderText = "ARIZA NEDENİ";
            DtgList.Columns["GenelOneriler"].HeaderText = "GENEL ÖNERİLER";
            DtgList.Columns["ToplamTutar"].HeaderText = "TOPLAM TUTAR";
            DtgList.Columns["DosyaYolu"].Visible = false;
            DtgList.Columns["YapilacakIslemler"].Visible = false;
            DtgList.Columns["BildirimNo"].HeaderText = "BİLDİRİM NO";

            ToplamlarGenel();

        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyaYolu = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();

            MalzemeList(id);
            YapilacakIslemlerList(id);
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }
        void MalzemeList(int id)
        {
            DtgMalzemeList.Rows.Clear();
            dtfMaliyets = dtfMaliyetManager.GetList(id, "OKF");

            if (dtfMaliyets.Count==0)
            {
                return;
            }

            foreach (DtfMaliyet item in dtfMaliyets)
            {
                DtgMalzemeList.Rows.Add();
                int sonSatir = DtgMalzemeList.RowCount - 1;
                string[] isTanim = item.IsTanimi.Split('|');

                if (isTanim.Length==1)
                {
                    DtgMalzemeList.Rows[sonSatir].Cells["StokNo"].Value = "N/A";
                    DtgMalzemeList.Rows[sonSatir].Cells["Tanimm"].Value = isTanim[0];
                }
                else
                {
                    DtgMalzemeList.Rows[sonSatir].Cells["StokNo"].Value = isTanim[0];
                    DtgMalzemeList.Rows[sonSatir].Cells["Tanimm"].Value = isTanim[1];
                }
                DtgMalzemeList.Rows[sonSatir].Cells["Miktar"].Value = item.Miktar.ToString();
                DtgMalzemeList.Rows[sonSatir].Cells["Birim"].Value = item.Birim;
                DtgMalzemeList.Rows[sonSatir].Cells["PBirim"].Value = item.PBirimi;
                DtgMalzemeList.Rows[sonSatir].Cells["BirimTutar"].Value = item.BirimTutar;
                DtgMalzemeList.Rows[sonSatir].Cells["ToplamTutar"].Value = item.ToplamTutar;

            }
            Toplamlar();
        }

        void Toplamlar()
        {
            toplam = 0;
            for (int i = 0; i < DtgMalzemeList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgMalzemeList.Rows[i].Cells["ToplamTutar"].Value);
            }
            LblTop2.Text = toplam.ToString("C2");
        }
        void ToplamlarGenel()
        {
            toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgList.Rows[i].Cells["ToplamTutar"].Value);
            }
            LblToplamGenel.Text = toplam.ToString("C2");
        }

        void YapilacakIslemlerList(int id)
        {
            DtgYapilacakIslemler.Rows.Clear();
            yapilacakIslemler = okfManager.YapilacakIslemlerGetList(id);
            if (yapilacakIslemler.Count==0)
            {
                return;
            }
            foreach (Okf item in yapilacakIslemler)
            {
                DtgYapilacakIslemler.Rows.Add();
                int sonSatir = DtgYapilacakIslemler.RowCount - 1;
                DtgYapilacakIslemler.Rows[sonSatir].Cells["YapilacakIslemler"].Value = item.YapilacakIslemler;
            }
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            LblTop.Text=DtgList.RowCount.ToString();
            ToplamlarGenel();

        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort=DtgList.SortString;
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOkfGuncelle frmOkfGuncelle = new FrmOkfGuncelle();
            frmOkfGuncelle.id = id;
            frmOkfGuncelle.ShowDialog();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageOKFIzleme"]);

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
