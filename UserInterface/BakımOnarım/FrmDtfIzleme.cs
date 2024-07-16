using Business.Concreate.AnaSayfa;
using Business.Concreate.BakimOnarim;
using DataAccess.Concreate;
using Entity.AnaSayfa;
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
    public partial class FrmDtfIzleme : Form
    {
        DtfManager dtfManager;
        DtfMaliyetManager dtfMaliyetManager;
        DtsLogManager dtsLogManager;

        List<Dtf> dtfsDevamEden;
        List<Dtf> dtfsTamamlanan;
        List<DtfMaliyet> dtfMaliyets;

        string dosyaYolu;
        int id, kayitId;
        public object[] infos;
        public FrmDtfIzleme()
        {
            InitializeComponent();
            dtfManager = DtfManager.GetInstance();
            dtfMaliyetManager = DtfMaliyetManager.GetInstance();
            dtsLogManager = DtsLogManager.GetInstance();
        }

        private void FrmDtfIzleme_Load(object sender, EventArgs e)
        {
            if (infos[11].ToString()=="MİSAFİR")
            {
                contextMenuStrip1.Items[0].Enabled = false;
            }
            DataDisplayDevamEden();
            DataDisplayTamamlanan();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDTFIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        public void Yenilenecekler()
        {
            DataDisplayDevamEden();
            DataDisplayTamamlanan();
        }
        void DataDisplayDevamEden()
        {
            dtfsDevamEden = dtfManager.GetList("DEVAM EDEN");
            dataBinder.DataSource = dtfsDevamEden.ToDataTable();
            DtgDevamEden.DataSource = dataBinder;
            TxtTop.Text = DtgDevamEden.RowCount.ToString();

            DtgDevamEden.Columns["Id"].Visible = false;
            DtgDevamEden.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgDevamEden.Columns["AdiSoyadi"].HeaderText = "ADI SOYADI";
            DtgDevamEden.Columns["KayitTarihi"].HeaderText = "KAYIT TARİHİ";
            DtgDevamEden.Columns["Donem"].HeaderText = "DÖNEM";
            DtgDevamEden.Columns["ButceKodu"].HeaderText = "HARCAMA KODU KALEMİ";
            DtgDevamEden.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgDevamEden.Columns["UsBolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgDevamEden.Columns["ProjeKodu"].HeaderText = "PROJE KODU";
            DtgDevamEden.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgDevamEden.Columns["IsKategorisi"].HeaderText = "İŞ KATEGORİSİ";
            DtgDevamEden.Columns["IsTanimi"].HeaderText = "İŞ TANIMI";
            DtgDevamEden.Columns["StokNo"].HeaderText = "STOK NO";
            DtgDevamEden.Columns["Tanim"].HeaderText = "TANIM";
            DtgDevamEden.Columns["OnarimYeri"].HeaderText = "ONARIM YERİ";
            DtgDevamEden.Columns["AltYukleniciFirma"].HeaderText = "ALT YÜKLENİCİ FİRMA";
            DtgDevamEden.Columns["FirmaSorumlusu"].HeaderText = "FİRMA SORUMLUSU";
            DtgDevamEden.Columns["IsinVerildigiTarih"].HeaderText = "İŞİN VERİLDİĞİ TARİH";
            DtgDevamEden.Columns["IsBaslamaTarihi"].Visible = false;
            DtgDevamEden.Columns["IsBitisTarihi"].Visible = false;
            DtgDevamEden.Columns["YapilanIslemler"].Visible = false;
            DtgDevamEden.Columns["DosyaYolu"].Visible = false;
            DtgDevamEden.Columns["SeriNo"].HeaderText = "SERİ NO";

            DtgDevamEden.Columns["SeriNo"].DisplayIndex = 14;
        }
        double genelToplma;
        List<DtfMaliyet> dtfMaliyets2;

        void ToplamMaliyet()
        {
            
            int sayac = 0;

            foreach (Dtf item in dtfsTamamlanan)
            {
                dtfMaliyets2 = dtfMaliyetManager.GetList(item.Id, "DTF");
                ToplamlarList();
                dtfsTamamlanan[sayac].ToplamTutar = genelToplma;
                sayac++;
            }
        }
        void DataDisplayTamamlanan()
        {
            dtfsTamamlanan = dtfManager.GetList("TAMAMLANAN");
            ToplamMaliyet();

            dataBinderTamamlanan.DataSource = dtfsTamamlanan.ToDataTable();
            DtgTamamlanan.DataSource = dataBinderTamamlanan;
            TxtTop2.Text = DtgTamamlanan.RowCount.ToString();

            DtgTamamlanan.Columns["Id"].Visible = false;
            
            DtgTamamlanan.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgTamamlanan.Columns["AdiSoyadi"].HeaderText = "ADI SOYADI";
            DtgTamamlanan.Columns["KayitTarihi"].HeaderText = "KAYIT TARİHİ";
            DtgTamamlanan.Columns["Donem"].HeaderText = "DÖNEM";
            DtgTamamlanan.Columns["ButceKodu"].HeaderText = "HARCAMA KODU KALEMİ";
            DtgTamamlanan.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgTamamlanan.Columns["UsBolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgTamamlanan.Columns["ProjeKodu"].HeaderText = "PROJE KODU";
            DtgTamamlanan.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgTamamlanan.Columns["IsKategorisi"].HeaderText = "İŞ KATEGORİSİ";
            DtgTamamlanan.Columns["IsTanimi"].HeaderText = "İŞ TANIMI";
            DtgTamamlanan.Columns["StokNo"].HeaderText = "STOK NO";
            DtgTamamlanan.Columns["Tanim"].HeaderText = "TANIM";
            DtgTamamlanan.Columns["OnarimYeri"].HeaderText = "ONARIM YERİ";
            DtgTamamlanan.Columns["AltYukleniciFirma"].HeaderText = "ALT YÜKLENİCİ FİRMA";
            DtgTamamlanan.Columns["FirmaSorumlusu"].HeaderText = "FİRMA SORUMLUSU";
            DtgTamamlanan.Columns["IsinVerildigiTarih"].HeaderText = "İŞİN VERİLDİĞİ TARİH";
            DtgTamamlanan.Columns["IsBaslamaTarihi"].HeaderText = "İŞE BAŞLAMA TARİHİ";
            DtgTamamlanan.Columns["IsBitisTarihi"].HeaderText = "İŞ BİTİŞ TARİHİ";
            DtgTamamlanan.Columns["YapilanIslemler"].HeaderText = "YAPILAN İŞLEMLER";
            DtgTamamlanan.Columns["DosyaYolu"].Visible = false;
            DtgTamamlanan.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgTamamlanan.Columns["ToplamTutar"].HeaderText = "TOPLAM MALİYET TUTARI";
            DtgTamamlanan.Columns["SeriNo"].DisplayIndex = 14;
            DtgTamamlanan.Columns["OnarimYeri"].DisplayIndex = 15;
            DtgTamamlanan.Columns["AltYukleniciFirma"].DisplayIndex = 16;
            DtgTamamlanan.Columns["FirmaSorumlusu"].DisplayIndex = 17;
            DtgTamamlanan.Columns["IsinVerildigiTarih"].DisplayIndex = 17;
            DtgTamamlanan.Columns["IsBaslamaTarihi"].DisplayIndex = 18;
            DtgTamamlanan.Columns["IsBitisTarihi"].DisplayIndex = 19;
            DtgTamamlanan.Columns["YapilanIslemler"].DisplayIndex = 20;
            DtgTamamlanan.Columns["DosyaYolu"].DisplayIndex = 21;
            ToplamlarGenel();

        }
        string bolgeAdi, isAkisNo, abfNo = "";

        private void DtgDevamEden_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgDevamEden.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyaYolu = DtgDevamEden.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            kayitId = DtgDevamEden.CurrentRow.Cells["Id"].Value.ConInt();
            abfNo = DtgDevamEden.CurrentRow.Cells["AbfNo"].Value.ToString();
            isAkisNo = DtgDevamEden.CurrentRow.Cells["IsAkisNo"].Value.ToString();
            bolgeAdi = DtgDevamEden.CurrentRow.Cells["UsBolgesi"].Value.ToString();
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void DtgDevamEden_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgDevamEden.FilterString;
            TxtTop.Text = DtgDevamEden.RowCount.ToString();
        }

        private void DtgDevamEden_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgDevamEden.SortString;
        }

        private void DtgTamamlanan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgTamamlanan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            id = DtgTamamlanan.CurrentRow.Cells["Id"].Value.ConInt();
            dosyaYolu = DtgTamamlanan.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            kayitId = id;
            abfNo = DtgTamamlanan.CurrentRow.Cells["AbfNo"].Value.ToString();
            isAkisNo = DtgTamamlanan.CurrentRow.Cells["IsAkisNo"].Value.ToString();
            bolgeAdi = DtgTamamlanan.CurrentRow.Cells["UsBolgesi"].Value.ToString();
            FillTools();

            try
            {
                webBrowser2.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgMaliyet.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgMaliyet.Rows[i].Cells[7].Value);
            }
            LblGenelTop.Text = toplam.ToString("C2");
        }
        void ToplamlarGenel()
        {
            double toplam = 0;
            for (int i = 0; i < DtgTamamlanan.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgTamamlanan.Rows[i].Cells[23].Value);
            }
            LblGenelT.Text = toplam.ToString("C2");
        }
        void ToplamlarList()
        {
            double toplam = 0;
            for (int i = 0; i < dtfMaliyets2.Count; ++i)
            {
                toplam += dtfMaliyets2[i].ToplamTutar.ConDouble();
            }
            genelToplma = toplam;
        }


        void MaliyetDataEdit()
        {
            DtgMaliyet.Columns["Id"].Visible = false;
            DtgMaliyet.Columns["BenzersizId"].Visible = false;
            DtgMaliyet.Columns["IsTanimi"].HeaderText = "İŞ TANIMI";
            DtgMaliyet.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMaliyet.Columns["Birim"].HeaderText = "BİRİM";
            DtgMaliyet.Columns["PBirimi"].HeaderText = "PARA BİRİMİ";
            DtgMaliyet.Columns["BirimTutar"].HeaderText = "BİRİM TUTARI";
            DtgMaliyet.Columns["ToplamTutar"].HeaderText = "TOPLAM TUTAR";
            LblMaliyetTop.Text = DtgTamamlanan.RowCount.ToString();
            Toplamlar();

        }
        void FillTools()
        {
            dtfMaliyets = dtfMaliyetManager.GetList(id, "DTF");
            if (dtfMaliyets == null)
            {
                DtgMaliyet.DataSource = null;
                MaliyetDataEdit();
            }
            else
            {
                DtgMaliyet.DataSource = dtfMaliyets;
                MaliyetDataEdit();
            }

        }

        private void DtgTamamlanan_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinderTamamlanan.Filter = DtgTamamlanan.FilterString;
            TxtTop2.Text = DtgTamamlanan.RowCount.ToString();
            ToplamlarGenel();
        }

        private void DtgTamamlanan_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderTamamlanan.Sort = DtgTamamlanan.SortString;
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kayitId==0)
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Kaydı silmek istediğinize emin misiniz?\nBu işlem geri alınamaz!", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                string mesaj = dtfManager.Delete(kayitId);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                mesaj = dtfMaliyetManager.DeleteVeriler(kayitId);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    Directory.Delete(dosyaYolu);
                }
                catch (Exception)
                {
                    DataDisplayDevamEden();
                    DataDisplayTamamlanan();
                    MessageBox.Show("Bilgiler başarıyla silinmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    kayitId = 0;
                    return;
                }

                DataDisplayDevamEden();
                DataDisplayTamamlanan();
                kayitId = 0;
                DtsLogKayit();
                MessageBox.Show("Bilgiler başarıyla silinmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void DtsLogKayit()
        {
            string islem = bolgeAdi + " bölgesine ait " + abfNo + " form numaralı arızanın " + isAkisNo + " İş Akış Numaralı DTF kaydı silinmiştir.";
            DtsLog dtsLog = new DtsLog(infos[1].ToString(), DateTime.Now, "DTF KAYIT SİLME", islem);
            dtsLogManager.Add(dtsLog);
        }

    }
}
