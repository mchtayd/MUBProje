using Business.Concreate.STS;
using ClosedXML.Excel;
using DataAccess.Concreate;
using Entity.STS;
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

namespace UserInterface.RAPORLAMALAR
{
    public partial class FrmSatRaporu : Form
    {
        SatRaporManager satRaporManager;
        SatRaporLogManager satRaporLogManager;
        public object[] infos;
        List<SatRapor> satRapors;
        string raporTuru, donem = "", dosyaYolu = "", dosya = "";

        public FrmSatRaporu()
        {
            InitializeComponent();
            satRaporManager = SatRaporManager.GetInstance();
            satRaporLogManager = SatRaporLogManager.GetInstance();
        }

        private void FrmSatRaporu_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSatRaporlama"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void BtnRaporOlustur_Click(object sender, EventArgs e)
        {
            if (CmbRaporTuru.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle FİRMA BİLGİSİ Kısmını Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbDonem.Text == "" || CmbDonemYil.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle DÖNEM Kısmını Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string donem = CmbDonem.Text + " " + CmbDonemYil.Text;
            ToplamlarAselsan();
            ToplamlarBasaran();
            //donem = CmbDonem.Text;
            DtgRaporList.DataSource = null;
            if (CmbRaporTuru.Text == "RAPOR")
            {

                raporTuru = "RAPOR";
                string faturaFirma = CmbFaturaEdilecekFirma.Text;

                satRapors = satRaporManager.Rapor(raporTuru, donem);
                dataBinder.DataSource = satRapors.ToDataTable();
                DtgRaporList.DataSource = dataBinder;
                DataDisplayAselsan();
            }
            if (CmbRaporTuru.Text == "BEYANNAME")
            {
                if (CmbFaturaEdilecekFirma.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle FATURA EDİLECEK FİRMA Bilgisini Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                raporTuru = "BEYANNAME";
                string faturaFirma = CmbFaturaEdilecekFirma.Text;
                satRapors = satRaporManager.Beyanname(raporTuru, donem, faturaFirma);

                dataBinder.DataSource = satRapors.ToDataTable();
                DtgRaporList.DataSource = dataBinder;
                DataDisplayBasaran();
            }

        }
        void ToplamlarAselsan()
        {
            double toplam = 0;
            for (int i = 0; i < DtgRaporList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgRaporList.Rows[i].Cells[5].Value);
            }
            ToplamTutar.Text = toplam.ToString("C2");
        }
        double toplam = 0;
        private int siraNo = 0;

        void ToplamlarBasaran()
        {
            toplam = 0;
            for (int i = 0; i < DtgRaporList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgRaporList.Rows[i].Cells[5].Value);
            }
            ToplamTutar.Text = toplam.ToString("C2");
        }
        void DataDisplayAselsan()
        {
            DtgRaporList.Columns["Kategori"].HeaderText = "KATEGORİ";
            DtgRaporList.Columns["ButceKodu"].HeaderText = "BÜTÇE KODU";
            DtgRaporList.Columns["ButceKalemi"].HeaderText = "BÜTÇE KALEMİ";
            DtgRaporList.Columns["FaturaTarihi"].HeaderText = "FATURA TARİHİ";
            DtgRaporList.Columns["FaturaAlindigiYer"].HeaderText = "FATURANIN ALINDIĞI YER";
            DtgRaporList.Columns["Tutar"].HeaderText = "FATURA TUTARI";
            DtgRaporList.Columns["Proje"].HeaderText = "PROJE";
            DtgRaporList.Columns["Bolge"].HeaderText = "BÖLGE";
            DtgRaporList.Columns["BildirimNo"].HeaderText = "BİLDİRİM NO";
            DtgRaporList.Columns["Aciklamalar"].HeaderText = "AÇIKLAMALAR";
            DtgRaporList.Columns["BelgeNo"].Visible = false;
            DtgRaporList.Columns["BelgeTuru"].Visible = false;
            DtgRaporList.Columns["HarcamaYapan"].Visible = false;
            TxtTop.Text = DtgRaporList.RowCount.ToString();
            ToplamlarAselsan();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (DtgRaporList.DataSource == null)
            {
                MessageBox.Show("Rapor Çıktısı Oluşturulacak Veri Bulunamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("SAT Rapor Kaydını Oluşturmak İsteğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                siraNo = 0;
                if (CmbRaporTuru.SelectedIndex == 0)
                {
                    ExcelExportBasaran();
                }
                if (CmbRaporTuru.SelectedIndex == 1)
                {
                    ExcelExportAselsan();
                }
                SatRaporLog satRaporLog = new SatRaporLog(CmbRaporTuru.Text, CmbDonem.Text, "2021", infos[1].ToString(), dosyaYolu, DateTime.Now, ToplamTutar.Text.ConDouble());
                string mesaj = satRaporLogManager.Add(satRaporLog);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void ExcelExportBasaran()
        {
            CreateDirectoryBasaran();
            string yol = "C:\\test.xlsx";
            IXLWorkbook workBook = new XLWorkbook(yol.Replace(" ", ""), XLEventTracking.Disabled);
            //IXLWorksheet worksheet = workBook.AddWorksheet("RAPOR");
            IXLWorksheet workSheet = workBook.Worksheet("Sayfa1");
            workSheet.Name = "RAPOR";

            IXLRow row = workSheet.Row(8);

            row.Cell(1).Value = "S.N";
            row.Cell(2).Value = "BÜTÇE KODU";
            row.Cell(3).Value = "BÜTÇE GİDER TÜRÜ";
            row.Cell(4).Value = "TARİH";
            row.Cell(5).Value = "BELGE NO";
            row.Cell(6).Value = "BELGE TÜRÜ";
            row.Cell(7).Value = "KİMDEN ALINDIĞI";
            row.Cell(8).Value = "TUTAR";
            row.Cell(9).Value = "HARCAMA YAPAN";
            row.Height = row.Height * 1.5;
            row.Cells().Style.Font.Bold = true;
            row.RowUsed().SetAutoFilter(true);

            row = row.RowBelow();
            double toplam = 0;
            foreach (DataGridViewRow item in DtgRaporList.Rows)
            {
                row.Cell("A").Value = ++siraNo;
                row.Cell("B").Value = item.Cells["ButceKodu"].Value;
                row.Cell("C").Value = item.Cells["ButceKalemi"].Value;
                row.Cell("D").Value = item.Cells["FaturaTarihi"].Value;
                row.Cell("E").Value = item.Cells["BelgeNo"].Value;
                row.Cell("F").Value = item.Cells["BelgeTuru"].Value;
                row.Cell("G").Value = item.Cells["FaturaAlindigiYer"].Value;
                toplam += item.Cells["Tutar"].Value.ConDouble();
                row.Cell("H").Value = item.Cells["Tutar"].Value.ConDouble().ToString("C2");
                row.Cell("I").Value = item.Cells["HarcamaYapan"].Value;

                row = row.RowBelow();
            }
            workSheet.Cell(DtgRaporList.RowCount + 9, "H").Value = "Toplam: " + toplam.ToString("C2");
            workSheet.Columns(1, 9).AdjustToContents();
            workSheet.Range(8, 1, DtgRaporList.RowCount + 8, 9).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            workSheet.Range(8, 1, DtgRaporList.RowCount + 8, 9).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            //dosya = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Excel_File.xlsx";
            //workBook.SaveAs(dosya);

            dosyaYolu = dosya;
            dosya = dosya + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("mm_ss") + ".xlsx";

            workBook.SaveAs(dosya);

        }
        void ExcelExportAselsan()
        {
            CreateDirectoryAselsan();
            IXLWorkbook workBook = new XLWorkbook();
            IXLWorksheet workSheet = workBook.AddWorksheet("RAPOR");
            IXLRow row = workSheet.Row(1);
            row.Height = row.Height * 1.5;
            row.Cells().Style.Font.Bold = true;

            row.Cell(1).Value = "S.N";
            row.Cell(2).Value = "KATEGORİ";
            row.Cell(3).Value = "BÜTÇE KODU";
            row.Cell(4).Value = "BÜTÇE KALEMİ";
            row.Cell(5).Value = "FATURA TARİHİ";
            row.Cell(6).Value = "FATURANIN ALINDIĞI YER";
            row.Cell(7).Value = "FATURA TUTARI";
            row.Cell(8).Value = "PROJE KONFİG.";
            row.Cell(9).Value = "KULLANILDIĞI YER/BÖLGE";
            row.Cell(10).Value = "BİLDİRİM NUMARASI";
            row.Cell(11).Value = "AÇIKLAMALAR";
            row.RowUsed().SetAutoFilter(true);

            row = row.RowBelow();

            foreach (DataGridViewRow item in DtgRaporList.Rows)
            {
                row.Cell("A").Value = ++siraNo;
                row.Cell("B").Value = item.Cells["Kategori"].Value;
                row.Cell("C").Value = item.Cells["ButceKodu"].Value;
                row.Cell("D").Value = item.Cells["ButceKalemi"].Value;
                row.Cell("E").Value = item.Cells["FaturaTarihi"].Value;
                row.Cell("F").Value = item.Cells["FaturaAlindigiYer"].Value;
                row.Cell("G").Value = item.Cells["Tutar"].Value;
                row.Cell("H").Value = item.Cells["Proje"].Value;
                row.Cell("I").Value = item.Cells["Bolge"].Value;
                row.Cell("J").Value = item.Cells["BildirimNo"].Value;
                row.Cell("K").Value = item.Cells["Aciklamalar"].Value;

                row = row.RowBelow();
            }

            //dosya = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Excel_File.xlsx";
            //workBook.SaveAs(dosya);
            workSheet.RangeUsed().Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            workSheet.RangeUsed().Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

            dosyaYolu = dosya;
            dosya = dosya + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("mm_ss") + ".xlsx";

            workBook.SaveAs(dosya);

        }
        void CreateDirectoryAselsan()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT RAPORLARI\";
            string subdir2 = @"Z:\DTS\SATIN ALMA\SAT RAPORLARI\ASELSAN\";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(subdir2))
            {
                Directory.CreateDirectory(subdir2);
            }

            dosya = subdir2 + DateTime.Now.ToString("dd/MM/yyyy");

            if (!Directory.Exists(dosya))
            {
                Directory.CreateDirectory(dosya);
            }

            //dosya = subdir + DateTime.Now.ToString("dd/MM/yyyy");
            Directory.CreateDirectory(dosya);
            dosya += "\\";
        }
        void CreateDirectoryBasaran()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT RAPORLARI\";
            string subdir2 = @"Z:\DTS\SATIN ALMA\SAT RAPORLARI\BAŞARAN\";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(subdir2))
            {
                Directory.CreateDirectory(subdir2);
            }

            dosya = subdir2 + DateTime.Now.ToString("dd/MM/yyyy");

            if (!Directory.Exists(dosya))
            {
                Directory.CreateDirectory(dosya);
            }

            //dosya = subdir + DateTime.Now.ToString("dd/MM/yyyy");
            Directory.CreateDirectory(dosya);
            dosya += "\\";
        }

        private void CmbRaporTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = CmbRaporTuru.SelectedIndex;
            if (index == 1)
            {
                LbFaturaEdilecekFirma.Visible = false;
                CmbFaturaEdilecekFirma.Visible = false;
            }
            if (index == 0)
            {
                LbFaturaEdilecekFirma.Visible = true;
                CmbFaturaEdilecekFirma.Visible = true;
            }
        }

        private void DtgRaporList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgRaporList.FilterString;
            TxtTop.Text = DtgRaporList.RowCount.ToString();
            ToplamlarAselsan();
            ToplamlarBasaran();
        }

        private void DtgRaporList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgRaporList.SortString;
        }

        void DataDisplayBasaran()
        {
            DtgRaporList.Columns["Kategori"].Visible = false;
            DtgRaporList.Columns["ButceKodu"].HeaderText = "BÜTÇE KODU";
            DtgRaporList.Columns["ButceKalemi"].HeaderText = "BÜTÇE KALEMİ";
            DtgRaporList.Columns["FaturaTarihi"].HeaderText = "FATURA TARİHİ";
            DtgRaporList.Columns["FaturaAlindigiYer"].HeaderText = "FATURANIN ALINDIĞI YER";
            DtgRaporList.Columns["Tutar"].HeaderText = "FATURA TUTARI";
            DtgRaporList.Columns["Proje"].Visible = false;
            DtgRaporList.Columns["Bolge"].Visible = false;
            DtgRaporList.Columns["BildirimNo"].Visible = false;
            DtgRaporList.Columns["Aciklamalar"].Visible = false;
            DtgRaporList.Columns["BelgeNo"].HeaderText = "BELGE NO";
            DtgRaporList.Columns["BelgeTuru"].HeaderText = "BELGE TÜRÜ";
            DtgRaporList.Columns["HarcamaYapan"].HeaderText = "HARCAMA YAPAN";
            TxtTop.Text = DtgRaporList.RowCount.ToString();
            ToplamlarBasaran();
        }
    }
}
