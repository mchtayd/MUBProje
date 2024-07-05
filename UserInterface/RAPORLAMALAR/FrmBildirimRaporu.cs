using Business.Concreate.BakimOnarim;
using ClosedXML.Excel;
using DataAccess.Concreate;
using Entity.BakimOnarim;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;
using UserInterface.STS;
using Excel = Microsoft.Office.Interop.Excel;

namespace UserInterface.RAPORLAMALAR
{
    public partial class FrmBildirimRaporu : Form
    {
        string dosyaYolu;
        BolgeKayitManager bolgeKayitManager;
        ArizaKayitManager arizaKayitManager;
        public FrmBildirimRaporu()
        {
            InitializeComponent();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageBildirimRaporu"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                dosyaYolu = openFileDialog1.FileName.ToString();

                if (Path.GetExtension(dosyaYolu) == ".xlsm" || Path.GetExtension(dosyaYolu) == ".xlsx")
                {
                    ExcelCek();
                    TxtTop.Text = DtgList.RowCount.ToString();
                }
                else
                {
                    MessageBox.Show("Lütfen Excel Formatında Bir Dosya Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        void ExcelCek()
        {
            DataTable table = FrmHelper.GetDataTableFromExcel(dosyaYolu, "SAP Document Export");

            DtgList.DataSource = null;
            DtgList.DataSource = table;
        }

        private void BtnDisaAktar_Click(object sender, EventArgs e)
        {
            if (DtgList.RowCount == 0)
            {
                MessageBox.Show("Lütfen öncelikle Excel Raporunu yükleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IXLWorkbook workBook = new XLWorkbook();
            IXLWorksheet workSheet = workBook.AddWorksheet("RAPOR");
            IXLRow row = workSheet.Row(1);
            row.Height = row.Height * 1.5;
            row.Cells().Style.Font.Bold = true;

            row.Cell(1).Value = "SIRA NO";
            row.Cell(2).Value = "BİLDİRİM NO";
            row.Cell(3).Value = "BİLDİRİM TARİHİ";
            row.Cell(4).Value = "BİLDİRİM TÜRÜ";
            row.Cell(5).Value = "BİLDİRİM KISA METNİ";
            row.Cell(6).Value = "KULLANICI STATÜSÜ TANIMI";
            row.Cell(7).Value = "MALZEME";
            row.Cell(8).Value = "MALZEME TANIMI";
            row.Cell(9).Value = "BÖLGE SORUMLUSU";

            row.Height = row.Height * 1.5;
            row.Cells().Style.Font.Bold = true;
            row.RowUsed().SetAutoFilter(true);

            row = row.RowBelow();
            int sayac = 1;

            foreach (DataGridViewRow item in DtgList.Rows)
            {
                string bolgeAdi = "";
                string[] bolge = item.Cells[3].Value.ToString().Split('-');
                bolgeAdi = bolge[0];
                BolgeKayit bolgeKayit = bolgeKayitManager.Get(0, bolgeAdi.Trim());
                if (bolgeKayit != null)
                {
                    row.Cell("A").Value = sayac.ToString();
                    row.Cell("B").Value = item.Cells[0].Value.ToString();
                    row.Cell("C").Value = item.Cells[1].Value.ToString();
                    row.Cell("D").Value = item.Cells[2].Value.ToString();
                    row.Cell("E").Value = item.Cells[3].Value.ToString();
                    row.Cell("F").Value = item.Cells[4].Value.ToString();
                    row.Cell("G").Value = item.Cells[5].Value.ToString();
                    row.Cell("H").Value = item.Cells[6].Value.ToString();
                    row.Cell("I").Value = bolgeKayit.BolgeSorumlusu;

                    row = row.RowBelow();

                    sayac++;
                }
                else
                {
                    row.Cell("A").Value = sayac.ToString();
                    row.Cell("B").Value = item.Cells[0].Value.ToString();
                    row.Cell("C").Value = item.Cells[1].Value.ToString();
                    row.Cell("D").Value = item.Cells[2].Value.ToString();
                    row.Cell("E").Value = item.Cells[3].Value.ToString();
                    row.Cell("F").Value = item.Cells[4].Value.ToString();
                    row.Cell("G").Value = item.Cells[5].Value.ToString();
                    row.Cell("H").Value = item.Cells[6].Value.ToString();
                    row.Cell("I").Value = "BÖLGE SORUMLUSU BULUNAMADI!";

                    row = row.RowBelow();

                    sayac++;
                }
            }

            workSheet.RangeUsed().Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            workSheet.RangeUsed().Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

            string file = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            file = file + "\\" + "RAPOR" + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("mm_ss") + ".xlsx";
            workBook.SaveAs(file);
            workBook.Dispose();

            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!\nDosya Yolu: " + file, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnFileAdd_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                dosyaYolu = openFileDialog1.FileName.ToString();

                if (Path.GetExtension(dosyaYolu) == ".xlsm" || Path.GetExtension(dosyaYolu) == ".xlsx")
                {
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook excelWB = excelApp.Workbooks.Open(dosyaYolu);
                    Excel._Worksheet excelWS = excelWB.Sheets[1];
                    Excel.Range excelRange = excelWS.UsedRange;

                    int rowCount = excelRange.Rows.Count;
                    int columnCount = excelRange.Columns.Count;
                    List<ArizaKayit> arizaKayits = new List<ArizaKayit>();
                    arizaKayits = arizaKayitManager.BOTamamlananGetList();
                    for (int i = 2; i <= rowCount; i++)
                    {
                        if (excelRange.Cells[i, 3] != null)
                        {
                            string bildirimNo = excelRange.Cells[i, 3].Value2.ToString();
                            if (arizaKayits.Any(x => x.BildirimNo.Equals(bildirimNo)) || arizaKayits.Any(x => x.OkfBildirimNo.Equals(bildirimNo)))
                            {
                                excelRange.Rows[i].Interior.Color = Color.Red;
                            }

                        }

                    }
                    MessageBox.Show("İşlem başarıyla tamamlanmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Marshal.ReleaseComObject(excelWS);
                    Marshal.ReleaseComObject(excelRange);
                    //excelWB.Close();
                    Marshal.ReleaseComObject(excelWB);
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }
                else
                {
                    MessageBox.Show("Lütfen Excel Formatında Bir Dosya Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }
    }
}
