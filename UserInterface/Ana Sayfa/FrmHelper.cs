using Business;
using Business.Concreate;
using Business.Concreate.STS;
using ClosedXML.Excel;
using DataAccess.Concreate;
using DataAccess.Concreate.STS;
using Entity;
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
using System.Windows.Forms.DataVisualization.Charting;
 
namespace UserInterface.Ana_Sayfa
{
    public partial class FrmHelper : Form
    {
        IsAkisNoManager isAkisNoManager;
        
        public FrmHelper()
        {
            InitializeComponent();
            isAkisNoManager = IsAkisNoManager.GetInstance();
        }
        private void FrmHelper_Load(object sender, EventArgs e)
        {
            // chart.Series["Series1"].Points.AddY(15);
            // chart.Series["Series1"].Points.Add(5);           

        }

        public static void ExportTable(DataGridView dg, string fileName = "", string filePath = "", int columnNumber = 0)
        {
            //string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + fileName + " ( " + DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " )";
            //string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + fileName + DateTime.Now.ToString("ddMMyyyy-HHmmss");

            IXLWorkbook wb = new XLWorkbook(XLEventTracking.Disabled);
            IXLWorksheet ws = wb.AddWorksheet("Veriler");

            int colidx = columnNumber;
            var row = ws.FirstRow();
            //row = row.RowBelow(5);//beş satır atlar
            row.Height = row.Height * 1.5;
            row.Style.Font.Bold = true;
            int number = 0;
            for (int i = 0; i < dg.Columns.Count; i++)
            {
                if (dg.Columns[i].Visible == true)
                {
                    ws.Columns().Width = 20;
                    row.Cell(++colidx).Value = dg.Columns[i].HeaderText;
                    row.Cell(colidx).Style.Fill.BackgroundColor = XLColor.FromHtml("#B0BFE6");
                    row.Cell(colidx).Style.Font.FontColor = XLColor.White;
                    row.Cell(colidx).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    row.Cell(colidx).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                    if (dg.Columns[i].HeaderText == "Birim_Fiyat")
                    {
                        number = i;
                    }
                }
            }
            row = row.RowBelow();
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                if (dg.Rows[i].Visible)
                {
                    colidx = columnNumber;
                    foreach (DataGridViewCell dgvc in dg.Rows[i].Cells)
                    {
                        if (dgvc.OwningColumn.Visible)
                        {
                            row.Cell(++colidx).Value = dgvc.Value.ToString();
                        }
                    }
                    row = row.RowBelow();
                }
            }
            // ws.Columns().AdjustToContents();
            ws.RangeUsed().Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            ws.RangeUsed().Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

            ws.Style.Protection.SetLocked(true);
            if (number > 0)
            {
                ws.Column(number + 1).Style.Protection.SetLocked(false);
            }

            ws.Protect("1234");
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Excel_File.xlsx";
            }
            wb.SaveAs(filePath);
            wb.Dispose();
        }

        public static List<FiyatTeklifiAl> GetRequestList(DataGridView gridView, string supplierName)//Mail Gönderilebilinir mi diye kontrol için eklendi
        {
            List<FiyatTeklifiAl> list = new List<FiyatTeklifiAl>();
            List<SatRenkliTablo> tumRenkler = SatRenkliiTabloManager.GetInstance().GetList("", "BEKLIYOR");
            int[] cellIndexs = new int[3] { 5, 6, 7 };

            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                if (gridView.Rows[i].Visible)
                {
                    if (!CanSendMail(gridView.Rows[i], tumRenkler, supplierName))
                    {
                        continue;
                    }

                    FiyatTeklifiAl item = null;
                    foreach (DataGridViewCell dgvc in gridView.Rows[i].Cells)
                    {
                        if (dgvc.OwningColumn.Visible)
                        {
                            if (dgvc.OwningColumn.HeaderText == "TANIM")
                            {
                                item = new FiyatTeklifiAl();
                                item.Tanim = dgvc.Value.ToString();
                            }
                            else if (dgvc.OwningColumn.HeaderText == "MİKTAR")
                            {
                                item.Miktar = dgvc.Value.ConInt();
                            }
                            else if (dgvc.OwningColumn.HeaderText == "BİRİM")
                            {
                                item.Birim = dgvc.Value.ToString();
                            }

                            if (item != null)
                            {
                                if (item.Tanim != null && item.Miktar != 0 && item.Birim != null)
                                {
                                    list.Add(item);
                                    item = null;
                                }
                            }
                        }
                    }
                }
            }
            return list;
        }

        public static bool CanSendMail(DataGridViewRow row, List<SatRenkliTablo> tumRenkler, string supplierName)
        {
            int[] cellIndexs = new int[3] { 5, 6, 7 };

            List<SatRenkliTablo> renkler = tumRenkler.Where(x => x.Firmaadi.ToLower().Contains(supplierName.ToLower())).ToList();
            foreach (SatRenkliTablo tabloItem in renkler)
            {
                string idler = tabloItem.Siparisid;
                if (idler != null)
                {
                    string[] array = idler.Split(';');
                    foreach (string item in array)
                    {
                        if (row.Cells[0].Value.ToString() == item)
                        {
                            foreach (int number in cellIndexs)
                            {
                                if (row.Cells[number].Value.ToString() == supplierName)
                                {
                                    return false;
                                }
                            }
                        }

                    }
                }
            }
            return true;
        }

        public static bool CanSendMailByList(FiyatTeklifiAl fiyatTeklifiAl, List<SatRenkliTablo> tumRenkler, string supplierName)
        {
            List<SatRenkliTablo> renkler = tumRenkler.Where(x => x.Firmaadi.ToLower().Contains(supplierName.ToLower())).ToList();
            foreach (SatRenkliTablo tabloItem in renkler)
            {
                string idler = tabloItem.Siparisid;
                if (idler != null)
                {
                    string[] array = idler.Split(';');
                    foreach (string item in array)
                    {
                        if (fiyatTeklifiAl.Id.ToString() == item)
                        {
                            if (fiyatTeklifiAl.Firma1 == tabloItem.Firmaadi)
                            {
                                return false;
                            }
                            if (fiyatTeklifiAl.Firma2 == tabloItem.Firmaadi)
                            {
                                return false;
                            }
                            if (fiyatTeklifiAl.Firma3 == tabloItem.Firmaadi)
                            {
                                return false;
                            }

                        }

                    }
                }
            }
            return true;
        }

        public static string GetFilteredStringValue(string filtered)
        {
            return filtered.Split('\'')[1];
        }

        public static string Html_Table_Export(DataGridView dg)
        {
            StringBuilder strB = new StringBuilder();
            //create html & table
            strB.AppendLine("<html><head><meta charset=utf-8><style>table{padding:10px;} th,td{padding:8px;}</style></head><body><center><table border='1' cellpadding='0' cellspacing='0'>");
            //Gerekçe ...
            strB.AppendLine("<tr>");
            //create table header
            for (int i = 0; i < dg.Columns.Count; i++)
            {
                if (dg.Columns[i].Visible == true)
                {
                    strB.AppendLine("<th align='center' valign='middle'>" + dg.Columns[i].HeaderText + "</th>");
                }
            }
            //create table body
            strB.AppendLine("</tr>");
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                if (dg.Rows[i].Visible)
                {
                    strB.AppendLine("<tr>");
                    foreach (DataGridViewCell dgvc in dg.Rows[i].Cells)
                    {
                        if (dgvc.OwningColumn.Visible == true) { strB.AppendLine("<td align='center' valign='middle'>" + dgvc.Value.ToString() + "</td>"); }
                    }
                    strB.AppendLine("</tr>");
                }
            }
            //table footer & end of html file
            strB.AppendLine("</table></center>");
            strB.AppendLine("</body></html>");
            return strB.ToString();
        }

        public static string Html_Log_Content(DataGridView dg, DataGridView dgForTable)
        {
            StringBuilder strB = new StringBuilder();
            //create html & table
            strB.AppendLine("<html><head><meta charset=utf-8><style>table{padding:10px;} th,td{padding:8px;}</style></head><body>");
            int index = 0;
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                if (dg.Rows[i].Visible)
                {
                    foreach (DataGridViewCell dgvc in dg.Rows[i].Cells)
                    {
                        if (dgvc.OwningColumn.Visible == true)
                        {
                            int margin = index == 0 ? 25 : index == 1 ? 16 : 75;
                            strB.AppendLine($"<p> " +
                                $"<span style='font-weight: bold; font-family: Arial'>{dgvc.OwningColumn.HeaderText}</span>" +
                                $" <span style='color: blue; font-weight:bold; margin-left: {margin}'>: {dgvc.Value}</span>" +
                                $"</p><br>");
                            index++;
                        }
                    }
                }
                index = 0;
            }


            strB.AppendLine("<center><table border='1' cellpadding='0' cellspacing='0'>");
            strB.AppendLine("<tr>");

            for (int i = 0; i < dgForTable.Columns.Count; i++)
            {
                if (dgForTable.Columns[i].Visible == true)
                {
                    strB.AppendLine("<th align='center' valign='middle'>" + dgForTable.Columns[i].HeaderText + "</th>");
                }
            }
            //create table body
            strB.AppendLine("</tr>");
            for (int i = 0; i < dgForTable.Rows.Count; i++)
            {
                if (dgForTable.Rows[i].Visible)
                {
                    strB.AppendLine("<tr>");
                    foreach (DataGridViewCell dgForTablevc in dgForTable.Rows[i].Cells)
                    {
                        if (dgForTablevc.OwningColumn.Visible == true) { strB.AppendLine("<td align='center' valign='middle'>" + dgForTablevc.Value.ToString() + "</td>"); }
                    }
                    strB.AppendLine("</tr>");
                }
            }
            //table footer & end of html file
            strB.AppendLine("</table></center>");
            strB.AppendLine("</body></html>");
            return strB.ToString();
        }

        public static DataTable GetDataTableFromExcel(string path, string sheetName)
        {
            //Save the uploaded Excel file.


            DataTable dt = new DataTable();
            //Open the Excel file using ClosedXML.
            using (XLWorkbook workBook = new XLWorkbook(path))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(sheetName);

                //Create a new DataTable.

                //Loop through the Worksheet rows.
                bool firstRow = true;

                foreach (IXLRow row in workSheet.Rows())
                {
                    if (string.IsNullOrEmpty(row.Cell("C").Value.ToString()))
                    {
                        continue;
                    }
                    //Use the first row to add columns to DataTable.
                  
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {                           
                            if (!string.IsNullOrEmpty(cell.Value.ToString()))
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }
                            else
                            {
                                break;
                            }
                        }
                        firstRow = false;
                    }
                    else
                    {
                        int i = 0;
                        DataRow toInsert = dt.NewRow();
                        foreach (IXLCell cell in row.Cells())
                        {                           
                            try
                            {
                                toInsert[i] = cell.Value.ToString();
                            }
                            catch (Exception ex)
                            {

                            }
                            i++;
                        }
                        dt.Rows.Add(toInsert);
                    }
                }
                return dt;
            }
        }
        public static string DonemControl(DateTime dateTime)
        {
            string donem = "";
            string ay;
            string yil;
            ay = dateTime.ToString("MM");
            yil = dateTime.ToString("yyyy");
            if (ay == "01")
            {
                donem = "OCAK " + yil;
            }
            if (ay == "02")
            {
                donem = "ŞUBAT " + yil;
            }
            if (ay == "03")
            {
                donem = "MART " + yil;
            }
            if (ay == "04")
            {
                donem = "NİSAN " + yil;
            }
            if (ay == "05")
            {
                donem = "MAYIS " + yil;
            }
            if (ay == "06")
            {
                donem = "HAZİRAN " + yil;
            }
            if (ay == "07")
            {
                donem = "TEMMUZ " + yil;
            }
            if (ay == "08")
            {
                donem = "AĞUSTOS " + yil;
            }
            if (ay == "09")
            {
                donem = "EYLÜL " + yil;
            }
            if (ay == "10")
            {
                donem = "EKİM " + yil;
            }
            if (ay == "11")
            {
                donem = "KASIM " + yil;
            }
            if (ay == "12")
            {
                donem = "ARALIK " + yil;
            }
            return donem;
        }
        
    }
}
