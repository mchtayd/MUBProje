using Business.Concreate.BakimOnarim;
using Business.Concreate.Rapor;
using ClosedXML.Excel;
using DataAccess.Concreate;
using Entity.BakimOnarim;
using Entity.Rapor;
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
    public partial class FrmArizaRaporlama : Form
    {
        List<ArizaRapor> arizaRapors;
        
        ArizaRaporManager arizaRaporManager;
        BolgeManager bolgeManager;

        string dosya, dosyaYolu, projeTanimi = "";
        public FrmArizaRaporlama()
        {
            InitializeComponent();
            arizaRaporManager = ArizaRaporManager.GetInstance();
            bolgeManager = BolgeManager.GetInstance();
        }

        private void FrmArizaRaporlama_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageArizaRapor"]);
            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        void DataDisplay()
        {
            arizaRapors = arizaRaporManager.GetList();
            dataBinder.DataSource = arizaRapors.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["BildirimTuru"].HeaderText = "BİLDİRİM TÜRÜ";
            DtgList.Columns["BildirimNo"].HeaderText = "BİLDİRİM NO";
            DtgList.Columns["ProjeNo"].HeaderText = "PROJE NO";
            DtgList.Columns["ProjeTanim"].HeaderText = "PROOJE TANIMI";
            DtgList.Columns["ArizaliMalzeme"].HeaderText = "ARIZALI MALZEME";
            DtgList.Columns["MalzemeTanim"].HeaderText = "ARIZALI MALZEME TANIM";
            DtgList.Columns["BildirimTarihi"].HeaderText = "BİLDİRİM TARİHİ";
            DtgList.Columns["MudehaleTarihi"].HeaderText = "MÜDEHALE TARİHİ";
            DtgList.Columns["KapanisTarihi"].HeaderText = "KAPANIŞ TARİHİ";
            DtgList.Columns["UstStokNo"].HeaderText = "ÜST TAKIM STOK NO";
            DtgList.Columns["UstTanim"].HeaderText = "ÜST TAKIM TANIM";
            DtgList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgList.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgList.Columns["FormNo"].Visible = false;

            DtgList.Columns["BildirimTuru"].DisplayIndex = 0;
            DtgList.Columns["BildirimNo"].DisplayIndex = 1;
            DtgList.Columns["ProjeNo"].DisplayIndex = 2;
            DtgList.Columns["ProjeTanim"].DisplayIndex = 3;
            DtgList.Columns["ArizaliMalzeme"].DisplayIndex = 4;
            DtgList.Columns["MalzemeTanim"].DisplayIndex = 5;
            DtgList.Columns["BildirimTarihi"].DisplayIndex = 6;
            DtgList.Columns["MudehaleTarihi"].DisplayIndex = 7;
            DtgList.Columns["KapanisTarihi"].DisplayIndex = 8;
            DtgList.Columns["UstStokNo"].DisplayIndex = 9;
            DtgList.Columns["UstTanim"].DisplayIndex = 10;
            DtgList.Columns["Miktar"].DisplayIndex = 11;
            DtgList.Columns["BolgeAdi"].DisplayIndex = 12;

        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            List<ArizaRapor> arizaRapors2 = new List<ArizaRapor>();
            foreach (ArizaRapor item in arizaRapors)
            {
                bool control = false;
                string bildirimNo = item.BildirimNo;
                if (bildirimNo.Length != 9)
                {
                    ArizaRapor arizaRapor = arizaRaporManager.Get(bildirimNo);
                    bildirimNo = arizaRapor.FormNo;
                }
                foreach (ArizaRapor item2 in arizaRapors2)
                {
                    if (item2.BildirimNo == bildirimNo)
                    {
                        control = true;
                    }
                    else
                    {
                        control = false;
                    }
                }

                string[] array = item.BildirimTarihi.Split(' ');
                string[] array2 = item.MudehaleTarihi.Split(' ');
                string[] array3 = item.KapanisTarihi.Split(' ');
                string bildirimTarihi = array[0].ToString();
                if (bildirimTarihi == "NULL")
                {
                    bildirimTarihi = "";
                }
                string mudehaleTarihi = array2[0].ToString();
                if (mudehaleTarihi == "NULL")
                {
                    mudehaleTarihi = "";
                }
                string kapanisTarihi = array3[0].ToString();
                if (kapanisTarihi == "NULL")
                {
                    kapanisTarihi = "";
                }

                projeTanimi = item.ProjeTanim;

                if (projeTanimi == "")
                {
                    if (item.BolgeAdi != "")
                    {
                        Bolge bolge = bolgeManager.ArizaRaporBolgeGet(item.BolgeAdi);
                        if (bolge == null)
                        {
                            projeTanimi = "";
                        }
                        else
                        {
                            projeTanimi = bolge.Proje;
                        }

                    }
                }
                string[] array4 = projeTanimi.Split('-');

                if (array4[0].ToString() == "MGUB" || array4[0].ToString() == "MGÜB")
                {
                    projeTanimi = "MUB-" + array4[1].ToString();
                    if (array4.Length > 2)
                    {
                        projeTanimi = "MUB-" + array4[1].ToString() + "-" + array4[2].ToString();
                    }
                }

                if (control==false)
                {
                    ArizaRapor arizaRapor = new ArizaRapor(item.BildirimTuru, bildirimNo, item.ProjeNo, projeTanimi, item.ArizaliMalzeme, item.MalzemeTanim, bildirimTarihi, mudehaleTarihi, kapanisTarihi, item.BolgeAdi, item.UstStokNo, item.UstTanim, item.Miktar);

                    arizaRapors2.Add(arizaRapor);
                }
                else
                {
                    ArizaRapor arizaRapor = new ArizaRapor("", "", "", "", item.ArizaliMalzeme, item.MalzemeTanim, "", "", "", "", "", "", item.Miktar);
                    arizaRapors2.Add(arizaRapor);
                }
            }
            DtgList2.DataSource = arizaRapors2;
            DtgList.Columns["FormNo"].Visible = false;
            label1.Text = DtgList2.RowCount.ToString();

            ExcelExportAselsan();

            MessageBox.Show("İşlem Başarıyla Tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void ExcelExportAselsan()
        {
            CreateDirectoryAselsan();
            IXLWorkbook workBook = new XLWorkbook();
            IXLWorksheet workSheet = workBook.AddWorksheet("RAPOR");
            IXLRow row = workSheet.Row(1);
            row.Height = row.Height * 1.5;
            row.Cells().Style.Font.Bold = true;

            row.Cell(1).Value = "Durum";
            row.Cell(2).Value = "Arıza Kayıt No";
            row.Cell(3).Value = "Proje Kodu";
            row.Cell(4).Value = "Proje Tanımı";
            row.Cell(5).Value = "Arızalı Malzeme Üst Takım Stok No";
            row.Cell(6).Value = "Arızalı Malzeme Üst Takım Tanımı";
            row.Cell(7).Value = "Arızalı Malzeme Stok No";
            row.Cell(8).Value = "Arızalı Malzeme Tanımı";
            row.Cell(9).Value = "Miktar";
            row.Cell(10).Value = "Arıza Bildirim Tarihi";
            row.Cell(11).Value = "Arıza Müdehale Tarihi";
            row.Cell(12).Value = "Arıza Kapanış Tarihi";
            row.Cell(13).Value = "Bölge Adı";
            row.RowUsed().SetAutoFilter(true);

            row = row.RowBelow();

            foreach (DataGridViewRow item in DtgList2.Rows)
            {
                row.Cell("A").Value = item.Cells["BildirimTuru"].Value;
                row.Cell("B").Value = item.Cells["BildirimNo"].Value;
                row.Cell("C").Value = item.Cells["ProjeNo"].Value;
                row.Cell("D").Value = item.Cells["ProjeTanim"].Value;
                row.Cell("E").Value = item.Cells["UstStokNo"].Value;
                row.Cell("F").Value = item.Cells["UstTanim"].Value;
                row.Cell("G").Value = item.Cells["ArizaliMalzeme"].Value;
                row.Cell("H").Value = item.Cells["MalzemeTanim"].Value;
                row.Cell("I").Value = item.Cells["Miktar"].Value;
                row.Cell("J").Value = item.Cells["BildirimTarihi"].Value;
                row.Cell("K").Value = item.Cells["MudehaleTarihi"].Value;
                row.Cell("L").Value = item.Cells["KapanisTarihi"].Value;
                row.Cell("M").Value = item.Cells["BolgeAdi"].Value;

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
            string yol = "C:\\RAPOR";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(yol))
            {
                Directory.CreateDirectory(yol);
            }
            /*if (!Directory.Exists(subdir2))
            {
                Directory.CreateDirectory(subdir2);
            }*/

            dosya = yol + "\\" + DateTime.Now.ToString("dd/MM/yyyy");

            if (!Directory.Exists(dosya))
            {
                Directory.CreateDirectory(dosya);
            }

            //dosya = subdir + DateTime.Now.ToString("dd/MM/yyyy");
            Directory.CreateDirectory(dosya);
            dosya += "\\";
        }
    }
}
