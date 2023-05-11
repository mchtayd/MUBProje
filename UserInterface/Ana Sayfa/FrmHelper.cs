using Business;
using Business.Concreate;
using Business.Concreate.STS;
using ClosedXML.Excel;
using DataAccess.Concreate;
using DataAccess.Concreate.STS;
using Entity;
using Entity.BakimOnarim;
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
using Tulpep.NotificationWindow;
using UserInterface.STS;
using System.Media;
using Entity.AnaSayfa;
using Business.Concreate.AnaSayfa;
//WMPLib.WindowsMediaPlayer Player;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmHelper : Form
    {
        IsAkisNoManager isAkisNoManager;
        static List<Log> logs = new List<Log>();

        public FrmHelper()
        {
            InitializeComponent();
            isAkisNoManager = IsAkisNoManager.GetInstance();
        }
        private void FrmHelper_Load(object sender, EventArgs e)
        {    

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
                filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + " \\Excel_File.xlsx";
            }
            wb.SaveAs(filePath);
            wb.Dispose();
        }
        public static void ExportAbf(ArizaKayit arizaKayit, string fileName = "", string filePath = "")
        {


        }

        public static List<FiyatTeklifiAl> GetRequestList(DataGridView gridView, string supplierName) //Mail Gönderilebilinir mi diye kontrol için eklendi
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
            if (path=="")
            {
                return null;
            }
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
                            catch (Exception)
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
        static void Ses()
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

            wplayer.URL = @"Z:\DTS\info\ou\Crystal_Drop.mp3";
            wplayer.controls.play();

        }


        static string panelTitle = "", panelContent = "", panelKullanici = "", panelSorumluId = "", panelBenzersizKimlik = "";
        static List<Log> logsList = logs.ToList();

        public static void Bildirim(string title, string content, Image ımage, string kullanici, string sorumluId, string benzersizKimlik, List<Log> logs = null)
        {
            PopupNotifier popup = new PopupNotifier();

            Ses();
            panelTitle = title;
            panelContent = content;
            panelKullanici = kullanici;
            panelSorumluId = sorumluId;
            panelBenzersizKimlik = benzersizKimlik;
            popup.Image = ımage;
            //popup.Image = ımageList1.Images["okey.png"];
            popup.Size = new Size(500, 150);
            popup.BodyColor = Color.FromArgb(40, 167, 69);
            popup.TitleText = title;
            popup.TitleColor = Color.White;
            popup.TitleFont = new Font("Century Gothic", 15, FontStyle.Bold);

            popup.ContentText = content;
            popup.ContentColor = Color.White;
            popup.ContentFont = new Font("Century Gothic", 12);
            popup.Popup();

            logsList = logs;

            popup.Click += Popup_Click;

            popup.Disappear += Popup_Disappear;
        }


        public static void PanelClickEdit(string icerik)
        {
            #region EskiKod
            //List<Log> logs2 = new List<Log>();
            //logs2 = logs;

            //FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];

            //StringBuilder strB = new StringBuilder();

            //for (int i = 0; i < logs.Count; i++)
            //{
            //    string yeniIcrerik = "";
            //    string gelenicerik = logs[i].Icerik.ToString();
            //    string[] array = gelenicerik.Split('\n');

            //    for (int j = 0; j < array.Length; j++)
            //    {
            //        yeniIcrerik = yeniIcrerik + " " + array[j].ToString();
            //    }

            //    if (yeniIcrerik.Trim() == icerik.Trim())
            //    {
            //        logs2.Remove(logs2[i]);
            //        i--;
            //        if (logs.Count == 0)
            //        {
            //            break;
            //        }
            //    }
            //}

            //if (logs2.Count != 0)
            //{
            //    strB.Append("<center><h2 class='headings'>" + "DTS Bildirim" + "</h2>");
            //    strB.Append("<a href='#'>TEMİZLE</a>");

            //    for (int i = 0; i < logs2.Count; i++)
            //    {
            //        strB.Append("<table border='2' cellpadding='3'>");
            //        strB.Append("<td width='320px'><h3 class='headings'>" + logs2[i].Baslik + "</h3>" + "<a id='1' href='#'>" + logs2[i].Icerik + "</a>" + "<br>" + "(" + DateTime.Now.ToString("g") + ")" +
            //            "</td>");
            //        strB.Append("</table></center><br/>");

            //        frmAnaSayfa.webContent.DocumentText = strB.ToString();
            //    }
            //}

            //else
            //{
            //    strB.Append("<center><h2 class='headings'>" + "DTS Bildirim" + "</h2>");
            //    strB.Append("<a href='#'>TEMİZLE</a></center>");
            //    frmAnaSayfa.webContent.DocumentText = strB.ToString();

            //}
            //frmAnaSayfa.BtnBildirim.Text = logs2.Count.ToString();
            #endregion
        }

        public static void PanelEdit(List<Log> logs)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];

            StringBuilder strB = new StringBuilder();
            
            strB.Append("<center><h2 class='headings'>" + "DTS Bildirim" + "</h2>");
            strB.Append("<a href='#'>TEMİZLE</a>");
            for (int i = 0; i < logs.Count; i++)
            {
                strB.Append("<table border='2' cellpadding='3' style='background:rgb(240,255,255);'>");
                strB.Append("<td width='320px'><h3 class='headings'>" + logs[i].Baslik + "</h3>" + "<a href='#'>" + logs[i].Icerik + "</a>" + "<br>" + "(" + logs[i].Tarih.ToString("g") + ")" + "</td>");
                strB.Append("</table></center><br/>");

                frmAnaSayfa.webContent.DocumentText = strB.ToString();
            }
        }

        static bool bildirimClick = false;
        static List<string> benzersizs = new List<string>();
        private static void Popup_Disappear(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            string sayi = frmAnaSayfa.BtnBildirim.Text;

            if (sayi == "0")
            {
                logs.Clear();
            }

            //benzersiz = Guid.NewGuid().ToString();
            //benzersizs.Add(benzersiz);
            
            if (bildirimClick == false)
            {
                int yeniSayi = sayi.ConInt();
                yeniSayi++;
                frmAnaSayfa.BtnBildirim.Text = yeniSayi.ToString();
                PanelEdit(logsList);
            }
            else
            {
                bildirimClick = false;
            }

        }

        private static void Popup_Click(object sender, EventArgs e)
        {
            FrmBildirimPanel frmBildirimPanel = new FrmBildirimPanel();
            frmBildirimPanel.ShowDialog();
            bildirimClick = true;
        }

        public static string TxtBildirimEdit(string bildirim)
        {
            //string metin = "Saha Bildirim Güncelleme" + "\nMücahit AYDEMİR 220546 Form numaralı\nStine Tepe Üs Bölgesi\nDRAGONEYE B/O arızasını\n700 FABRİKA BAKIM ONARIM adıma güncellenmiştir!\n45;26;33\n\n";
            string editBildirim = "";
            string[] array = bildirim.Split(' ');

            for (int i = 0; i < array.Length; i++)
            {

                if (i==0)
                {
                    editBildirim = "Bildirim Başlık: "+ array[0].ToString();
                }
                if (i == 1)
                {
                    editBildirim += "\nBildirim Sahibi: " + array[1].ToString();
                }
                if (i == 2)
                {
                    editBildirim += "\nBildirim Sahibi: " + array[0].ToString();
                }
            }
            return "OK";
        }

        //static string dosyaYolu = @"Z:\DTS\info\ou\notification.txt";

        static string kaynak = @"Z:\DTS\info\ou\";
        static string yol = @"C:\DTS\Bildirim\";
        static string taslakYolu = "";
        static void CopyFile()
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

            taslakYolu = yol + "notification.txt";

            if (!File.Exists(taslakYolu))
            {
                File.Copy(kaynak + "notification.txt", taslakYolu);
            }
        }
        public static bool serverBildirimAyar = false;
        public static string BildirimGonder(string[] array, string bildirimYetki, string benzersizKimlik="")
        {
            return "OK";
        }

    }
}
