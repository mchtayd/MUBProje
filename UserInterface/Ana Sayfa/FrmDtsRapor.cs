using Business.Concreate.AnaSayfa;
using Business.Concreate.IdarıIsler;
using ClosedXML.Excel;
using DataAccess.Concreate;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmDtsRapor : Form
    {
        PersonelKayitManager kayitManager;
        DtsLogManager dtsLogManager;
        List<DtsLog> dtsLogs;
        string dosyaYolu;
        public FrmDtsRapor()
        {
            InitializeComponent();
            kayitManager = PersonelKayitManager.GetInstance();
            dtsLogManager = DtsLogManager.GetInstance();
        }

        private void FrmDtsRapor_Load(object sender, EventArgs e)
        {
            Personeller();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDtsRapor"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        void Personeller()
        {
            CmbPersonel.DataSource = kayitManager.PersonelAdSoyad();
            CmbPersonel.ValueMember = "Id";
            CmbPersonel.DisplayMember = "Adsoyad";
            CmbPersonel.SelectedValue = -1;
        }

        void DataDisplay()
        {
            DateTime dateTimeBas = new DateTime(DtBasTarihi.Value.Year, DtBasTarihi.Value.Month, DtBasTarihi.Value.Day, DtBasSaat.Value.Hour, DtBasSaat.Value.Minute, DtBasSaat.Value.Second);

            DateTime dateTimeBit = new DateTime(DtBitTarihi.Value.Year, DtBitTarihi.Value.Month, DtBitTarihi.Value.Day, DtBitSaat.Value.Hour, DtBitSaat.Value.Minute, DtBitSaat.Value.Second);

            dtsLogs = new List<DtsLog>();
            dtsLogs = dtsLogManager.GetList(CmbPersonel.Text, dateTimeBas, dateTimeBit);
            dataBinder.DataSource = dtsLogs.ToDataTable();
            DtgList.DataSource = dataBinder;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["PersonelAdi"].HeaderText = "PERSONEL ADI";
            DtgList.Columns["IslemTarihi"].HeaderText = "İŞLEM TARİHİ";
            DtgList.Columns["Sayfa"].HeaderText = "SAYFA";
            DtgList.Columns["Islem"].HeaderText = "İŞLEM";
        }

        void DataDisplayIslem()
        {
            DateTime dateTimeBas = new DateTime(DtBasTarihi.Value.Year, DtBasTarihi.Value.Month, DtBasTarihi.Value.Day, DtBasSaat.Value.Hour, DtBasSaat.Value.Minute, DtBasSaat.Value.Second);

            DateTime dateTimeBit = new DateTime(DtBitTarihi.Value.Year, DtBitTarihi.Value.Month, DtBitTarihi.Value.Day, DtBitSaat.Value.Hour, DtBitSaat.Value.Minute, DtBitSaat.Value.Second);

            dtsLogs = new List<DtsLog>();
            dtsLogs = dtsLogManager.GetListIslem(CmbPersonel.Text, dateTimeBas, dateTimeBit, TxtIslem.Text);
            dataBinder.DataSource = dtsLogs.ToDataTable();
            DtgList.DataSource = dataBinder;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["PersonelAdi"].HeaderText = "PERSONEL ADI";
            DtgList.Columns["IslemTarihi"].HeaderText = "İŞLEM TARİHİ";
            DtgList.Columns["Sayfa"].HeaderText = "SAYFA";
            DtgList.Columns["Islem"].HeaderText = "İŞLEM";
        }

        private void BtnSorgula_Click(object sender, EventArgs e)
        {
            if (CmbPersonel.Text=="")
            {
                MessageBox.Show("Lütfen bir personel seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtIslem.Text!="")
            {
                DataDisplayIslem();
            }
            else
            {
                DataDisplay();
            }
        }

        private void BtnTumunuGor_Click(object sender, EventArgs e)
        {
            DateTime dateTimeBas = new DateTime(DtBasTarihi.Value.Year, DtBasTarihi.Value.Month, DtBasTarihi.Value.Day, DtBasSaat.Value.Hour, DtBasSaat.Value.Minute, DtBasSaat.Value.Second);

            DateTime dateTimeBit = new DateTime(DtBitTarihi.Value.Year, DtBitTarihi.Value.Month, DtBitTarihi.Value.Day, DtBitSaat.Value.Hour, DtBitSaat.Value.Minute, DtBitSaat.Value.Second);

            dtsLogs = new List<DtsLog>();
            dtsLogs = dtsLogManager.GetListTumu(dateTimeBas, dateTimeBit);
            dataBinder.DataSource = dtsLogs.ToDataTable();
            DtgList.DataSource = dataBinder;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["PersonelAdi"].HeaderText = "PERSONEL ADI";
            DtgList.Columns["IslemTarihi"].HeaderText = "İŞLEM TARİHİ";
            DtgList.Columns["Sayfa"].HeaderText = "SAYFA";
            DtgList.Columns["Islem"].HeaderText = "İŞLEM";
        }

        private void BtnDisaAktar_Click(object sender, EventArgs e)
        {
            if (DtgList.RowCount == 0)
            {
                MessageBox.Show("Tabloda veri bulunmamaktadır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Tablodaki verileri Excel formatında rapor almak istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DosyaYeriSec();

                IXLWorkbook workBook = new XLWorkbook();
                IXLWorksheet workSheet = workBook.AddWorksheet("RAPOR");
                IXLRow row = workSheet.Row(1);
                row.Height = row.Height * 1.5;
                row.Cells().Style.Font.Bold = true;

                row.Cell(1).Value = "PERSONEL ADI";
                row.Cell(2).Value = "İŞLEM TARİHİ";
                row.Cell(3).Value = "SAYFA";
                row.Cell(4).Value = "İŞLEM";

                row.RowUsed().SetAutoFilter(true);
                row = row.RowBelow();

                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    row.Cell("A").Value = item.Cells["PersonelAdi"].Value;
                    row.Cell("B").Value = item.Cells["IslemTarihi"].Value;
                    row.Cell("C").Value = item.Cells["Sayfa"].Value;
                    row.Cell("D").Value = item.Cells["Islem"].Value;

                    row = row.RowBelow();
                }

                workSheet.RangeUsed().Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
                workSheet.RangeUsed().Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                dosyaYolu = dosyaYolu + DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("ss") + DateTime.Now.ToString("ff") + ".xlsx";

                workBook.SaveAs(dosyaYolu);

                MessageBox.Show(dosyaYolu + " dosyasının içerisine bu gün tarihli raporunuz oluşturulmuştur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void DosyaYeriSec()
        {
            string root = @"C:\DTS";
            string yol = @"C:\DTS\RAPOR";
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
