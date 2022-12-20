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

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmDisaAktarExcel : Form
    {
        TamamlananManager tamamlananManager;

        List<Tamamlanan> tamamlanans;

        bool start = true;
        string kaynakdosyaismi, alinandosya, dosyaYolu = "";
        public FrmDisaAktarExcel()
        {
            InitializeComponent();
            tamamlananManager = TamamlananManager.GetInstance();
        }
        private void FrmDisaAktarExcel_Load(object sender, EventArgs e)
        {
            
        }

        private void CmbTablo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbTablo.Text== "TAMAMLANAN SATLAR")
            {
                Yillar();
                TamamlananSatlar();
                start = false;
            }
        }
        void Yillar()
        {
            CmbYillar.DataSource = tamamlananManager.Yillar();
            int index = CmbYillar.Items.Count.ConInt() - 1;
            CmbYillar.SelectedIndex = index;
        }
        void TamamlananSatlar()
        {
            if (ChkTumunuGoster.Checked == true)
            {
                tamamlanans = tamamlananManager.GetList(0);
            }
            if (CmbYillar.Text == "2021")
            {
                tamamlanans = tamamlananManager.GetList(1990);
            }
            else
            {
                tamamlanans = tamamlananManager.GetList(CmbYillar.Text.ConInt());
            }
            dataBinder.DataSource = tamamlanans.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();
            DataDisplay();
        }
        void DataDisplay()
        {
            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Satno"].HeaderText = "SAT_NO";
            DtgList.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Masrafyeri"].Visible = false;
            DtgList.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgList.Columns["Bolum"].Visible = false;
            DtgList.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ ADI";
            DtgList.Columns["Abfform"].HeaderText = "ABF FORM NO";
            DtgList.Columns["Istenentarih"].Visible = false;
            DtgList.Columns["Tamamlanantarih"].HeaderText = "TAMAMLANAN TARİH";
            DtgList.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgList.Columns["Butcekodukalemi"].HeaderText = "BÜTÇE KODU KALEMİ";
            DtgList.Columns["Satbirim"].HeaderText = "SAT BİRİM";
            DtgList.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgList.Columns["Belgeturu"].HeaderText = "BELGE TÜRÜ";
            DtgList.Columns["Belgenumarasi"].HeaderText = "BELGE NUMARASI";
            DtgList.Columns["Belgetarihi"].HeaderText = "BELGE TARİHİ";
            DtgList.Columns["Faturaedilecekfirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgList.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgList.Columns["Masrafyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgList.Columns["Harcanantutar"].HeaderText = "HARCANAN TUTAR";
            DtgList.Columns["Dosyayolu"].Visible = false;
            DtgList.Columns["Siparisno"].Visible = false;
            DtgList.Columns["Ucteklif"].Visible = false;
            DtgList.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgList.Columns["Donem"].DisplayIndex = 3;
            DtgList.Columns["Donem"].HeaderText = "DÖNEM";
            DtgList.Columns["Proje"].HeaderText = "BÜTÇELENECEK PROJE NO";
            DtgList.Columns["Gecensure"].HeaderText = "GEÇEN SÜRE";
            DtgList.Columns["UsProjeNo"].HeaderText = "Ü.B PRJ. NO";
            DtgList.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";


            DtgList.Columns["Gecensure"].DisplayIndex = 2;
            DtgList.Columns["UsProjeNo"].DisplayIndex = 9;
            DtgList.Columns["GarantiDurumu"].DisplayIndex = 10;

        }

        private void CmbYillar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            if (CmbYillar.SelectedIndex == -1)
            {
                return;
            }
            TamamlananSatlar();
        }

        private void ChkTumunuGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTumunuGoster.Checked == true)
            {
                CmbYillar.SelectedIndex = -1;
                TamamlananSatlar();
            }
            else
            {
                Yillar();
                TamamlananSatlar();
            }
        }

        private void BtnDisaAktar_Click(object sender, EventArgs e)
        {
            if (DtgList.RowCount==0)
            {
                MessageBox.Show("Lütfen Bir Tablo Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DosyaYeriSec();

            IXLWorkbook workBook = new XLWorkbook();
            IXLWorksheet workSheet = workBook.AddWorksheet("RAPOR");
            IXLRow row = workSheet.Row(1);
            row.Height = row.Height * 1.5;
            row.Cells().Style.Font.Bold = true;

            row.Cell(1).Value = "SAT NO";
            row.Cell(2).Value = "FORM NO";
            row.Cell(3).Value = "TALEP EDEN";
            row.Cell(4).Value = "BÖLÜM";
            row.Cell(5).Value = "ÜS BÖLGESİ";
            row.Cell(6).Value = "ABF FORM NO";
            row.Cell(7).Value = "İSTENEN TARİH";
            row.Cell(8).Value = "TAMAMLANMA TARİHİ";
            row.Cell(9).Value = "GEREKÇE";
            row.Cell(10).Value = "BÜTÇE KODU KALEMİ";
            row.Cell(11).Value = "SATIN ALMA YAPACAK BİRİM";
            row.Cell(12).Value = "HARCAMA TÜRÜ";
            row.Cell(13).Value = "BELGE TÜRÜ";
            row.Cell(14).Value = "BELGE NUMARASI";
            row.Cell(15).Value = "BELGE TARİHİ";
            row.Cell(16).Value = "FATURA EDİLECEK FİRMA";
            row.Cell(17).Value = "İLGİLİ KİŞİ";
            row.Cell(18).Value = "MASRAF YERİ NO";
            row.Cell(19).Value = "HARCANAN TUTAR";
            row.Cell(20).Value = "DÖNEM";
            row.Cell(21).Value = "PROJE";
            row.Cell(22).Value = "GEÇEN SÜRE";
            row.Cell(23).Value = "ÜS BÖLGESİ PROJE NO";
            row.Cell(24).Value = "GARANTİ DURUMU";
            row.Cell(25).Value = "HARCAMA YAPAN";
            row.Cell(26).Value = "SATIN ALINAN FİRMA";

            row.RowUsed().SetAutoFilter(true);
            row = row.RowBelow();


            foreach (DataGridViewRow item in DtgList.Rows)
            {
                row.Cell("A").Value = item.Cells["Satno"].Value;
                row.Cell("B").Value = item.Cells["Formno"].Value;
                row.Cell("C").Value = item.Cells["Talepeden"].Value;
                row.Cell("D").Value = item.Cells["Bolum"].Value;
                row.Cell("E").Value = item.Cells["Usbolgesi"].Value;
                row.Cell("F").Value = item.Cells["Abfform"].Value;
                row.Cell("G").Value = item.Cells["Istenentarih"].Value;
                row.Cell("H").Value = item.Cells["Tamamlanantarih"].Value;
                row.Cell("I").Value = item.Cells["Gerekce"].Value;
                row.Cell("J").Value = item.Cells["Butcekodukalemi"].Value;
                row.Cell("K").Value = item.Cells["Satbirim"].Value;
                row.Cell("L").Value = item.Cells["Harcamaturu"].Value;
                row.Cell("M").Value = item.Cells["Belgeturu"].Value;
                row.Cell("N").Value = item.Cells["Belgenumarasi"].Value;
                row.Cell("O").Value = item.Cells["Belgetarihi"].Value;
                row.Cell("P").Value = item.Cells["Faturaedilecekfirma"].Value;
                row.Cell("Q").Value = item.Cells["Ilgilikisi"].Value;
                row.Cell("R").Value = item.Cells["Masrafyerino"].Value;
                row.Cell("S").Value = item.Cells["Harcanantutar"].Value;
                row.Cell("T").Value = item.Cells["Donem"].Value;
                row.Cell("U").Value = item.Cells["Proje"].Value;
                row.Cell("V").Value = item.Cells["Gecensure"].Value;
                row.Cell("W").Value = item.Cells["UsProjeNo"].Value;
                row.Cell("X").Value = item.Cells["GarantiDurumu"].Value;
                row.Cell("Y").Value = item.Cells["HarcamaYapan"].Value;
                row.Cell("Z").Value = item.Cells["SatinAlinanFirma"].Value;

                row = row.RowBelow();
            }

            workSheet.RangeUsed().Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            workSheet.RangeUsed().Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

            dosyaYolu = dosyaYolu + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("mm_ss") + ".xlsx";

            workBook.SaveAs(dosyaYolu);


        }
        void DosyaYeriSec()
        {
            string root = @"Z:\DTS";
            string yol = "C:\\RAPOR";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(yol))
            {
                Directory.CreateDirectory(yol);
            }

            dosyaYolu = yol + "\\" + DateTime.Now.ToString("dd/MM/yyyy");

            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }

            //dosya = subdir + DateTime.Now.ToString("dd/MM/yyyy");
            Directory.CreateDirectory(dosyaYolu);
            dosyaYolu += "\\";
        }
    }
}
