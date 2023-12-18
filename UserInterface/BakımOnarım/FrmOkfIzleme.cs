using Business.Concreate.BakimOnarim;
using ClosedXML.Excel;
using DataAccess.Concreate;
using DataAccess.Concreate.BakimOnarim;
using Entity;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        List<Okf> okfsSSB;
        List<Okf> okfsMusteriOnayi;
        List<Okf> tamamlanan;
        List<DtfMaliyet> dtfMaliyets;
        List<Okf> yapilacakIslemler;
        public object[] infos;
        string dosyaYolu, taslakYolu;
        int id, isAkisNo;
        double toplam;
        string yol = @"C:\DTS\Taslak\";
        string kaynak = @"Z:\DTS\BAKIM ONARIM\TASLAKLAR\";
        public FrmOkfIzleme()
        {
            InitializeComponent();
            okfManager = OkfManager.GetInstance();
            dtfMaliyetManager = DtfMaliyetManager.GetInstance();
        }

        private void FrmOkfIzleme_Load(object sender, EventArgs e)
        {
            if (infos[11].ToString() == "MİSAFİR")
            {
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[1].Enabled = false;
                contextMenuStrip1.Items[2].Enabled = false;
                contextMenuStrip1.Items[3].Enabled = false;
                contextMenuStrip1.Items[4].Enabled = false;
            }
            Tamamlanan();
            MusteriOnayi();
            SSBSunulan();
            AselsanaGonderilen();
        }
        public void AselsanaGonderilen()
        {
            okfs = okfManager.GetList("ASELSANA GÖNDERİLEN");
            dataBinder.DataSource = okfs.ToDataTable();
            DtgList.DataSource = dataBinder;

            LblTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["KayitYapan"].DisplayIndex = 0;
            DtgList.Columns["IsAkisNo"].DisplayIndex = 1;
            DtgList.Columns["AbfNo"].DisplayIndex = 25;
            DtgList.Columns["Il"].DisplayIndex = 25;
            DtgList.Columns["Ilce"].DisplayIndex = 25;
            DtgList.Columns["UsBolgesi"].DisplayIndex = 25;
            DtgList.Columns["ProjeKodu"].DisplayIndex = 25;
            DtgList.Columns["UstTanim"].DisplayIndex = 25;
            DtgList.Columns["GarantiDurumu"].DisplayIndex = 25;
            DtgList.Columns["ArizaTarihi"].DisplayIndex = 25;
            DtgList.Columns["BildirilenAriza"].DisplayIndex = 25;
            DtgList.Columns["ToplamTutar"].DisplayIndex = 25;
            DtgList.Columns["UstStok"].DisplayIndex = 25;
            DtgList.Columns["UstSeriNo"].DisplayIndex = 25;
            DtgList.Columns["ArizaNedeni"].DisplayIndex = 25;
            DtgList.Columns["GenelOneriler"].DisplayIndex = 25;
            DtgList.Columns["BildirimNo"].DisplayIndex = 25;
            DtgList.Columns["KayitTarihi"].DisplayIndex = 25;
            DtgList.Columns["Id"].DisplayIndex = 25;
            DtgList.Columns["ArizaDurum"].DisplayIndex = 25;
            DtgList.Columns["DosyaYolu"].DisplayIndex = 25;
            DtgList.Columns["YapilacakIslemler"].DisplayIndex = 25;
            DtgList.Columns["UbKomutani"].DisplayIndex = 25;
            DtgList.Columns["KomutanTel"].DisplayIndex = 25;
            DtgList.Columns["BirlikAdresi"].DisplayIndex = 25;
            DtgList.Columns["OkfBildirimNo"].DisplayIndex = 25;

            DtgList.Columns["KayitYapan"].HeaderText = "KAYIT YAPAN";
            DtgList.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgList.Columns["Il"].HeaderText = "İL";
            DtgList.Columns["Ilce"].HeaderText = "İLÇE";
            DtgList.Columns["UsBolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgList.Columns["ProjeKodu"].HeaderText = "PROJE KODU";
            DtgList.Columns["UstTanim"].HeaderText = "TANIM";
            DtgList.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgList.Columns["ArizaTarihi"].HeaderText = "ARIZA TARİHİ";
            DtgList.Columns["BildirilenAriza"].HeaderText = "BİLDİRİLEN ARIZA";
            DtgList.Columns["ToplamTutar"].HeaderText = "TOPLAM TUTAR";
            DtgList.Columns["UstStok"].HeaderText = "STOK NO";
            DtgList.Columns["UstSeriNo"].HeaderText = "SERİ NO";
            DtgList.Columns["ArizaNedeni"].HeaderText = "ARIZA NEDENİ";
            DtgList.Columns["GenelOneriler"].HeaderText = "GENEL ÖNERİLER";
            DtgList.Columns["BildirimNo"].HeaderText = "BİLDİRİM NO";
            DtgList.Columns["KayitTarihi"].Visible = false;
            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["ArizaDurum"].Visible = false;
            DtgList.Columns["DosyaYolu"].Visible = false;
            DtgList.Columns["YapilacakIslemler"].Visible = false;
            DtgList.Columns["UbKomutani"].Visible = false;
            DtgList.Columns["KomutanTel"].Visible = false;
            DtgList.Columns["BirlikAdresi"].Visible = false;
            DtgList.Columns["OkfBildirimNo"].Visible = false;

            ToplamlarGenel(DtgList);

        }
        public void SSBSunulan()
        {
            okfsSSB = okfManager.GetList("SSB ONAYINA SUNULAN");
            dataBinderSSB.DataSource = okfsSSB.ToDataTable();
            DtgListSSB.DataSource = dataBinderSSB;

            DtgListSSB.Columns["KayitYapan"].DisplayIndex = 0;
            DtgListSSB.Columns["IsAkisNo"].DisplayIndex = 1;
            DtgListSSB.Columns["AbfNo"].DisplayIndex = 25;
            DtgListSSB.Columns["Il"].DisplayIndex = 25;
            DtgListSSB.Columns["Ilce"].DisplayIndex = 25;
            DtgListSSB.Columns["UsBolgesi"].DisplayIndex = 25;
            DtgListSSB.Columns["ProjeKodu"].DisplayIndex = 25;
            DtgListSSB.Columns["UstTanim"].DisplayIndex = 25;
            DtgListSSB.Columns["GarantiDurumu"].DisplayIndex = 25;
            DtgListSSB.Columns["ArizaTarihi"].DisplayIndex = 25;
            DtgListSSB.Columns["BildirilenAriza"].DisplayIndex = 25;
            DtgListSSB.Columns["ToplamTutar"].DisplayIndex = 25;
            DtgListSSB.Columns["UstStok"].DisplayIndex = 25;
            DtgListSSB.Columns["UstSeriNo"].DisplayIndex = 25;
            DtgListSSB.Columns["ArizaNedeni"].DisplayIndex = 25;
            DtgListSSB.Columns["GenelOneriler"].DisplayIndex = 25;
            DtgListSSB.Columns["BildirimNo"].DisplayIndex = 25;
            DtgListSSB.Columns["KayitTarihi"].DisplayIndex = 25;
            DtgListSSB.Columns["Id"].DisplayIndex = 25;
            DtgListSSB.Columns["ArizaDurum"].DisplayIndex = 25;
            DtgListSSB.Columns["DosyaYolu"].DisplayIndex = 25;
            DtgListSSB.Columns["YapilacakIslemler"].DisplayIndex = 25;
            DtgListSSB.Columns["UbKomutani"].DisplayIndex = 25;
            DtgListSSB.Columns["KomutanTel"].DisplayIndex = 25;
            DtgListSSB.Columns["BirlikAdresi"].DisplayIndex = 25;
            DtgListSSB.Columns["OkfBildirimNo"].DisplayIndex = 25;

            DtgListSSB.Columns["KayitYapan"].HeaderText = "KAYIT YAPAN";
            DtgListSSB.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgListSSB.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgListSSB.Columns["Il"].HeaderText = "İL";
            DtgListSSB.Columns["Ilce"].HeaderText = "İLÇE";
            DtgListSSB.Columns["UsBolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgListSSB.Columns["ProjeKodu"].HeaderText = "PROJE KODU";
            DtgListSSB.Columns["UstTanim"].HeaderText = "TANIM";
            DtgListSSB.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgListSSB.Columns["ArizaTarihi"].HeaderText = "ARIZA TARİHİ";
            DtgListSSB.Columns["BildirilenAriza"].HeaderText = "BİLDİRİLEN ARIZA";
            DtgListSSB.Columns["ToplamTutar"].HeaderText = "TOPLAM TUTAR";
            DtgListSSB.Columns["UstStok"].HeaderText = "STOK NO";
            DtgListSSB.Columns["UstSeriNo"].HeaderText = "SERİ NO";
            DtgListSSB.Columns["ArizaNedeni"].HeaderText = "ARIZA NEDENİ";
            DtgListSSB.Columns["GenelOneriler"].HeaderText = "GENEL ÖNERİLER";
            DtgListSSB.Columns["BildirimNo"].HeaderText = "BİLDİRİM NO";
            DtgListSSB.Columns["KayitTarihi"].Visible = false;
            DtgListSSB.Columns["Id"].Visible = false;
            DtgListSSB.Columns["ArizaDurum"].Visible = false;
            DtgListSSB.Columns["DosyaYolu"].Visible = false;
            DtgListSSB.Columns["YapilacakIslemler"].Visible = false;
            DtgListSSB.Columns["UbKomutani"].Visible = false;
            DtgListSSB.Columns["KomutanTel"].Visible = false;
            DtgListSSB.Columns["BirlikAdresi"].Visible = false;
            DtgListSSB.Columns["OkfBildirimNo"].Visible = false;

        }
        public void MusteriOnayi()
        {
            okfsMusteriOnayi = okfManager.GetList("MÜŞTERİ ONAYI GELEN");
            dataBinderMusteriOnayi.DataSource = okfsMusteriOnayi.ToDataTable();
            DtgListMusteriOnayi.DataSource = dataBinderMusteriOnayi;

            DtgListMusteriOnayi.Columns["Id"].Visible = false;
            DtgListMusteriOnayi.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgListMusteriOnayi.Columns["KayitYapan"].HeaderText = "KAYIT YAPAN";
            DtgListMusteriOnayi.Columns["KayitTarihi"].HeaderText = "KAYIT TARİHİ";
            DtgListMusteriOnayi.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgListMusteriOnayi.Columns["ArizaTarihi"].HeaderText = "ARIZA TARİHİ";
            DtgListMusteriOnayi.Columns["UsBolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgListMusteriOnayi.Columns["ProjeKodu"].HeaderText = "PROJE KODU";
            DtgListMusteriOnayi.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgListMusteriOnayi.Columns["UbKomutani"].Visible = false;
            DtgListMusteriOnayi.Columns["KomutanTel"].Visible = false;
            DtgListMusteriOnayi.Columns["BirlikAdresi"].Visible = false;
            DtgListMusteriOnayi.Columns["Il"].HeaderText = "İL";
            DtgListMusteriOnayi.Columns["Ilce"].HeaderText = "İLÇE";
            DtgListMusteriOnayi.Columns["UstStok"].HeaderText = "STOK NO";
            DtgListMusteriOnayi.Columns["UstTanim"].HeaderText = "TANIM";
            DtgListMusteriOnayi.Columns["UstSeriNo"].HeaderText = "SERİ NO";
            DtgListMusteriOnayi.Columns["BildirilenAriza"].HeaderText = "BİLDİRİLEN ARIZA";
            DtgListMusteriOnayi.Columns["ArizaDurum"].Visible = false;
            DtgListMusteriOnayi.Columns["ArizaNedeni"].HeaderText = "ARIZA NEDENİ";
            DtgListMusteriOnayi.Columns["GenelOneriler"].HeaderText = "GENEL ÖNERİLER";
            DtgListMusteriOnayi.Columns["ToplamTutar"].HeaderText = "TOPLAM TUTAR";
            DtgListMusteriOnayi.Columns["DosyaYolu"].Visible = false;
            DtgListMusteriOnayi.Columns["YapilacakIslemler"].Visible = false;
            DtgListMusteriOnayi.Columns["BildirimNo"].HeaderText = "BİLDİRİM NO";

            DtgListMusteriOnayi.Columns["IsAkisNo"].DisplayIndex = 0;
            DtgListMusteriOnayi.Columns["AbfNo"].DisplayIndex = 1;
            DtgListMusteriOnayi.Columns["Il"].DisplayIndex = 2;
            DtgListMusteriOnayi.Columns["Ilce"].DisplayIndex = 3;
            DtgListMusteriOnayi.Columns["UsBolgesi"].DisplayIndex = 4;
            DtgListMusteriOnayi.Columns["ProjeKodu"].DisplayIndex = 5;
            DtgListMusteriOnayi.Columns["UstTanim"].DisplayIndex = 6;
            DtgListMusteriOnayi.Columns["GarantiDurumu"].DisplayIndex = 7;
            DtgListMusteriOnayi.Columns["ArizaTarihi"].DisplayIndex = 8;
            DtgListMusteriOnayi.Columns["BildirilenAriza"].DisplayIndex = 9;
            DtgListMusteriOnayi.Columns["ToplamTutar"].DisplayIndex = 10;
            DtgListMusteriOnayi.Columns["UstStok"].DisplayIndex = 11;
            DtgListMusteriOnayi.Columns["UstSeriNo"].DisplayIndex = 12;
            DtgListMusteriOnayi.Columns["ArizaNedeni"].DisplayIndex = 13;
            DtgListMusteriOnayi.Columns["GenelOneriler"].DisplayIndex = 14;
            DtgListMusteriOnayi.Columns["KayitTarihi"].DisplayIndex = 15;
            DtgListMusteriOnayi.Columns["BildirimNo"].DisplayIndex = 17;
            DtgListMusteriOnayi.Columns["Id"].DisplayIndex = 18;
            DtgListMusteriOnayi.Columns["ArizaDurum"].DisplayIndex = 19;
            DtgListMusteriOnayi.Columns["DosyaYolu"].DisplayIndex = 20;
            DtgListMusteriOnayi.Columns["YapilacakIslemler"].DisplayIndex = 21;
            DtgListMusteriOnayi.Columns["UbKomutani"].DisplayIndex = 22;
            DtgListMusteriOnayi.Columns["KomutanTel"].DisplayIndex = 23;
            DtgListMusteriOnayi.Columns["BirlikAdresi"].DisplayIndex = 24;
            DtgListMusteriOnayi.Columns["KayitYapan"].DisplayIndex = 25;

        }

        public void Tamamlanan()
        {
            tamamlanan = okfManager.GetList("TAMAMLANAN");
            dataBinderTamamlanan.DataSource = tamamlanan.ToDataTable();
            DtgListTamamlanan.DataSource = dataBinderTamamlanan;

            DtgListTamamlanan.Columns["Id"].Visible = false;
            DtgListTamamlanan.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgListTamamlanan.Columns["KayitYapan"].HeaderText = "KAYIT YAPAN";
            DtgListTamamlanan.Columns["KayitTarihi"].HeaderText = "KAYIT TARİHİ";
            DtgListTamamlanan.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgListTamamlanan.Columns["ArizaTarihi"].HeaderText = "ARIZA TARİHİ";
            DtgListTamamlanan.Columns["UsBolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgListTamamlanan.Columns["ProjeKodu"].HeaderText = "PROJE KODU";
            DtgListTamamlanan.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgListTamamlanan.Columns["UbKomutani"].Visible = false;
            DtgListTamamlanan.Columns["KomutanTel"].Visible = false;
            DtgListTamamlanan.Columns["BirlikAdresi"].Visible = false;
            DtgListTamamlanan.Columns["Il"].HeaderText = "İL";
            DtgListTamamlanan.Columns["Ilce"].HeaderText = "İLÇE";
            DtgListTamamlanan.Columns["UstStok"].HeaderText = "STOK NO";
            DtgListTamamlanan.Columns["UstTanim"].HeaderText = "TANIM";
            DtgListTamamlanan.Columns["UstSeriNo"].HeaderText = "SERİ NO";
            DtgListTamamlanan.Columns["BildirilenAriza"].HeaderText = "BİLDİRİLEN ARIZA";
            DtgListTamamlanan.Columns["ArizaDurum"].Visible = false;
            DtgListTamamlanan.Columns["ArizaNedeni"].HeaderText = "ARIZA NEDENİ";
            DtgListTamamlanan.Columns["GenelOneriler"].HeaderText = "GENEL ÖNERİLER";
            DtgListTamamlanan.Columns["ToplamTutar"].HeaderText = "TOPLAM TUTAR";
            DtgListTamamlanan.Columns["DosyaYolu"].Visible = false;
            DtgListTamamlanan.Columns["YapilacakIslemler"].Visible = false;
            DtgListTamamlanan.Columns["BildirimNo"].HeaderText = "BİLDİRİM NO";

            DtgListTamamlanan.Columns["IsAkisNo"].DisplayIndex = 0;
            DtgListTamamlanan.Columns["AbfNo"].DisplayIndex = 1;
            DtgListTamamlanan.Columns["Il"].DisplayIndex = 2;
            DtgListTamamlanan.Columns["Ilce"].DisplayIndex = 3;
            DtgListTamamlanan.Columns["UsBolgesi"].DisplayIndex = 4;
            DtgListTamamlanan.Columns["ProjeKodu"].DisplayIndex = 5;
            DtgListTamamlanan.Columns["UstTanim"].DisplayIndex = 6;
            DtgListTamamlanan.Columns["GarantiDurumu"].DisplayIndex = 7;
            DtgListTamamlanan.Columns["ArizaTarihi"].DisplayIndex = 8;
            DtgListTamamlanan.Columns["BildirilenAriza"].DisplayIndex = 9;
            DtgListTamamlanan.Columns["ToplamTutar"].DisplayIndex = 10;
            DtgListTamamlanan.Columns["UstStok"].DisplayIndex = 11;
            DtgListTamamlanan.Columns["UstSeriNo"].DisplayIndex = 12;
            DtgListTamamlanan.Columns["ArizaNedeni"].DisplayIndex = 13;
            DtgListTamamlanan.Columns["GenelOneriler"].DisplayIndex = 14;
            DtgListTamamlanan.Columns["KayitTarihi"].DisplayIndex = 15;
            DtgListTamamlanan.Columns["BildirimNo"].DisplayIndex = 17;
            DtgListTamamlanan.Columns["Id"].DisplayIndex = 18;
            DtgListTamamlanan.Columns["ArizaDurum"].DisplayIndex = 19;
            DtgListTamamlanan.Columns["DosyaYolu"].DisplayIndex = 20;
            DtgListTamamlanan.Columns["YapilacakIslemler"].DisplayIndex = 21;
            DtgListTamamlanan.Columns["UbKomutani"].DisplayIndex = 22;
            DtgListTamamlanan.Columns["KomutanTel"].DisplayIndex = 23;
            DtgListTamamlanan.Columns["BirlikAdresi"].DisplayIndex = 24;
            DtgListTamamlanan.Columns["KayitYapan"].DisplayIndex = 25;


        }
        public void Yenilenecekler()
        {
            Tamamlanan();
            MusteriOnayi();
            SSBSunulan();
            AselsanaGonderilen();
        }
        DateTime arizaTarihi;
        string tanim,bildirilenAriza,bolgeAdi = "";
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyaYolu = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            isAkisNo = DtgList.CurrentRow.Cells["IsAkisNo"].Value.ConInt();
            arizaTarihi = DtgList.CurrentRow.Cells["ArizaTarihi"].Value.ConDate();
            tanim = DtgList.CurrentRow.Cells["UstTanim"].Value.ToString();
            bildirilenAriza = DtgList.CurrentRow.Cells["BildirilenAriza"].Value.ToString();
            bolgeAdi = DtgList.CurrentRow.Cells["UsBolgesi"].Value.ToString();
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
        void ToplamlarGenel(DataGridView dataGridView)
        {
            toplam = 0;
            for (int i = 0; i < dataGridView.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(dataGridView.Rows[i].Cells["ToplamTutar"].Value);
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
            ToplamlarGenel(DtgList);

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

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex==0)
            {
                LblTop.Text= DtgList.RowCount.ToString();
                ToplamlarGenel(DtgList);
            }
            if (tabControl2.SelectedIndex == 1)
            {
                LblTop.Text = DtgListSSB.RowCount.ToString();
                ToplamlarGenel(DtgListSSB);
            }
            if (tabControl2.SelectedIndex == 2)
            {
                LblTop.Text = DtgListMusteriOnayi.RowCount.ToString();
                ToplamlarGenel(DtgListMusteriOnayi);
            }
            if (tabControl2.SelectedIndex == 3)
            {
                LblTop.Text = DtgListTamamlanan.RowCount.ToString();
                ToplamlarGenel(DtgListTamamlanan);
            }
            DtgMalzemeList.Rows.Clear();
            DtgYapilacakIslemler.Rows.Clear();
            webBrowser1.Navigate("");
        }

        private void DtgListSSB_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgListSSB.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }

            dosyaYolu = DtgListSSB.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            id = DtgListSSB.CurrentRow.Cells["Id"].Value.ConInt();
            isAkisNo = DtgListSSB.CurrentRow.Cells["IsAkisNo"].Value.ConInt();
            arizaTarihi = DtgListSSB.CurrentRow.Cells["ArizaTarihi"].Value.ConDate();
            tanim = DtgListSSB.CurrentRow.Cells["UstTanim"].Value.ToString();
            bildirilenAriza = DtgListSSB.CurrentRow.Cells["BildirilenAriza"].Value.ToString();
            bolgeAdi = DtgListSSB.CurrentRow.Cells["UsBolgesi"].Value.ToString();

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

        private void DtgListMusteriOnayi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgListMusteriOnayi.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyaYolu = DtgListMusteriOnayi.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            id = DtgListMusteriOnayi.CurrentRow.Cells["Id"].Value.ConInt();
            isAkisNo = DtgListMusteriOnayi.CurrentRow.Cells["IsAkisNo"].Value.ConInt();
            arizaTarihi = DtgListMusteriOnayi.CurrentRow.Cells["ArizaTarihi"].Value.ConDate();
            tanim = DtgListMusteriOnayi.CurrentRow.Cells["UstTanim"].Value.ToString();
            bildirilenAriza = DtgListMusteriOnayi.CurrentRow.Cells["BildirilenAriza"].Value.ToString();
            bolgeAdi = DtgListMusteriOnayi.CurrentRow.Cells["UsBolgesi"].Value.ToString();

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

        private void DtgListTamamlanan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgListTamamlanan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyaYolu = DtgListTamamlanan.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            id = DtgListTamamlanan.CurrentRow.Cells["Id"].Value.ConInt();
            isAkisNo = DtgListTamamlanan.CurrentRow.Cells["IsAkisNo"].Value.ConInt();
            arizaTarihi = DtgListTamamlanan.CurrentRow.Cells["ArizaTarihi"].Value.ConDate();
            tanim = DtgListTamamlanan.CurrentRow.Cells["UstTanim"].Value.ToString();
            bildirilenAriza = DtgListTamamlanan.CurrentRow.Cells["BildirilenAriza"].Value.ToString();
            bolgeAdi = DtgListTamamlanan.CurrentRow.Cells["UsBolgesi"].Value.ToString();

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

        private void sSBOnayınaSunulanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(isAkisNo.ToString() + " İş Akış Numaralı kaydın durumunu SSB ONAYINA SUNULAN olarak değiştirmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = okfManager.OkfDurumUpdate(id, "SSB ONAYINA SUNULAN");
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Yenilenecekler();
                id = 0;
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void müşteriOnayıGelenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(isAkisNo.ToString() + " İş Akış Numaralı kaydın durumunu MÜŞTERİ ONAYI GELEN olarak değiştirmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = okfManager.OkfDurumUpdate(id, "MÜŞTERİ ONAYI GELEN");
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Yenilenecekler();
                id = 0;
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tamamlananToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(isAkisNo.ToString() + " İş Akış Numaralı kaydın durumunu TAMAMLANAN olarak değiştirmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = okfManager.OkfDurumUpdate(id, "TAMAMLANAN");
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Yenilenecekler();
                id = 0;
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DtgListSSB_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinderSSB.Filter = DtgListSSB.FilterString;
            LblTop.Text = DtgListSSB.RowCount.ToString();
            ToplamlarGenel(DtgListSSB);
        }

        private void DtgListSSB_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderSSB.Sort = DtgListSSB.SortString;
        }

        private void DtgListMusteriOnayi_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinderMusteriOnayi.Filter = DtgListMusteriOnayi.FilterString;
            LblTop.Text = DtgListMusteriOnayi.RowCount.ToString();
            ToplamlarGenel(DtgListMusteriOnayi);
        }

        private void DtgListMusteriOnayi_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderMusteriOnayi.Sort = DtgListMusteriOnayi.SortString;
        }

        private void DtgListTamamlanan_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinderTamamlanan.Filter = DtgListTamamlanan.FilterString;
            LblTop.Text = DtgListTamamlanan.RowCount.ToString();
            ToplamlarGenel(DtgListTamamlanan);
        }

        private void DtgListTamamlanan_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderTamamlanan.Sort = DtgListTamamlanan.SortString;
        }
        void TaslakKopyalaExcel()
        {
            string root = @"C:\DTS";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(yol))
            {
                Directory.CreateDirectory(yol);
            }

            File.Copy(kaynak + "Ek-1 OKF_üs bölge adı_iş akış no.xlsx", yol + "Ek-1 OKF_üs bölge adı_iş akış no.xlsx");

            taslakYolu = yol + "Ek-1 OKF_üs bölge adı_iş akış no.xlsx";
        }

        private void excelOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Excel dosyası oluşturmak istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr!=DialogResult.Yes)
            {
                return;
            }
            TaslakKopyalaExcel();

            string excelFilePath = Path.Combine(yol, "Ek-1 OKF_üs bölge adı_iş akış no.xlsx");
            bool exists = File.Exists(excelFilePath);
            IXLWorkbook xLWorkbook = new XLWorkbook(excelFilePath, XLEventTracking.Disabled);
            IXLWorksheet worksheet = xLWorkbook.Worksheet("Sheet2");

            var range = worksheet.RangeUsed();
            DateTime date = new DateTime(arizaTarihi.Year, arizaTarihi.Month, arizaTarihi.Day + 2, arizaTarihi.Hour, arizaTarihi.Minute, arizaTarihi.Second);
            if (date.Day.ToString("dddd") == "Pazar")
            {
                date = new DateTime(arizaTarihi.Year, arizaTarihi.Month, arizaTarihi.Day + 3, arizaTarihi.Hour, arizaTarihi.Minute, arizaTarihi.Second);
            }
            if (date.Day.ToString("dddd") == "Cumartesi")
            {
                date = new DateTime(arizaTarihi.Year, arizaTarihi.Month, arizaTarihi.Day + 4, arizaTarihi.Hour, arizaTarihi.Minute, arizaTarihi.Second);
            }
            worksheet.Cell("I4").Value = date.ToString("d");
            worksheet.Cell("J4").Value = DateTime.Now.ToString("d");
            worksheet.Cell("F7").Value = tanim;
            string messege = "MÜB Projesi kapsamında yapılan kontrollerde " + bildirilenAriza.ToLower() + "\n\nÜS bölgesinde keşif işlemleri tamamlanmış olup,yapılacak faaliyet aşağıda detaylandırılmıştır.";
            foreach (DataGridViewRow item in DtgYapilacakIslemler.Rows)
            {
                string[] message = item.Cells["YapilacakIslemler"].Value.ToString().Split(')');
                messege += "\n           -" + message[1];
            }
            worksheet.Cell("A12").Value = messege;
            worksheet.Cell("D22").Value = bolgeAdi;
            worksheet.Cell("A11").Value = bolgeAdi;

            xLWorkbook.SaveAs(dosyaYolu + "\\" + "Ek-1 OKF_" + bolgeAdi + "_" + isAkisNo + ".xlsx");
            xLWorkbook.Dispose(); // workbook nesnesini temizler

            Directory.Delete(yol, true);

            webBrowser1.Navigate(dosyaYolu);

        }

        private void aselsanaGönderilenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(isAkisNo.ToString() + " İş Akış Numaralı kaydın durumunu ASELSANA GÖNDERİLEN olarak değiştirmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = okfManager.OkfDurumUpdate(id, "ASELSANA GÖNDERİLEN");
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Yenilenecekler();
                id = 0;
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
