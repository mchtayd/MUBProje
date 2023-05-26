using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.STS;
using ClosedXML.Excel;
using DataAccess.Concreate;
using Entity.Gecic_Kabul_Ambar;
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
        DepoMiktarManager depoMiktarManager;
        MalzemeManager malzemeManager;
        List<DepoMiktar> depoMiktars= new List<DepoMiktar>();
        List<Malzeme> malzemes = new List<Malzeme>();

        List<Tamamlanan> tamamlanans;

        bool start = true;
        string dosyaYolu = "";
        public FrmDisaAktarExcel()
        {
            InitializeComponent();
            tamamlananManager = TamamlananManager.GetInstance();
            depoMiktarManager = DepoMiktarManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
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
            if (CmbTablo.Text == "DEPO STOK")
            {
                ChkTumunuGoster.Checked = true;
                Depo();
                start = false;
            }
            if (CmbTablo.Text == "DEPO KAYITLI MALZEMELER")
            {
                ChkTumunuGoster.Checked = true;
                DepoKayitliMalzeme();
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

        void Depo()
        {
            depoMiktars = depoMiktarManager.GetListTumu();
            dataBinder.DataSource = depoMiktars.ToDataTable();
            DtgList.DataSource = dataBinder;
            Display();
        }
        void DepoKayitliMalzeme()
        {
            malzemes = malzemeManager.GetList();
            dataBinder.DataSource = malzemes.ToDataTable();
            DtgList.DataSource = dataBinder;
            DisplayMalzeme();
        }

        void Display()
        {

            foreach (DataGridViewRow item in DtgList.Rows)
            {
                if (item.Cells["Miktar"].Value.ConInt() == 0)
                {
                    int selectedIndex = item.Index;
                    DtgList.Rows.RemoveAt(selectedIndex);
                }
            }
            DtgList.Columns["Secim"].Visible = false;
            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["StokNo"].HeaderText = "STOK NO";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["SonIslemTarihi"].HeaderText = "SON İŞLEM TARİHİ";
            DtgList.Columns["SonIslemYapan"].HeaderText = "SON İŞLEM YAPAN";
            DtgList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgList.Columns["DepoNo"].HeaderText = "DEPO NO";
            DtgList.Columns["DepoAdresi"].HeaderText = "DEPO ADRESİ";
            DtgList.Columns["DepoLokasyon"].HeaderText = "DEPO LOKASYON";
            DtgList.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgList.Columns["LotNo"].HeaderText = "LOT NO";
            DtgList.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgList.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            DtgList.Columns["RezerveDurumu"].HeaderText = "REZERVE DURUMU";
            DtgList.Columns["RezerveId"].HeaderText = "REZERVE EDİLEN KİMLİK";

            DtgList.Columns["DepoLokasyon"].DisplayIndex = 8;
            TxtTop.Text = DtgList.RowCount.ToString();
        }
        void DisplayMalzeme()
        {
            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["UstStok"].Visible = false;
            DtgList.Columns["UstTanim"].Visible = false;
            DtgList.Columns["BenzersizId"].Visible = false;
            DtgList.Columns["StokNo"].HeaderText = "STOK NO";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["Birim"].HeaderText = "BİRİM";
            DtgList.Columns["TedarikciFirma"].HeaderText = "TEDARİKÇİ FİRMA";
            DtgList.Columns["OnarimDurumu"].HeaderText = "MALZEME ONARIM DURUMU";
            DtgList.Columns["OnarimYeri"].HeaderText = "MALZEME ONARIM YERİ";
            DtgList.Columns["TedarikTuru"].HeaderText = "TEDARİK TÜRÜ";
            DtgList.Columns["ParcaSinifi"].HeaderText = "PARÇA SINIFI";
            DtgList.Columns["TakipDurumu"].HeaderText = "MALZEME TAKİP DURUMU";
            DtgList.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            DtgList.Columns["DosyaYolu"].Visible = false;
            DtgList.Columns["IslemYapan"].Visible = false;
            DtgList.Columns["AlternatifParca"].HeaderText = "ALTERNATİF PARÇA";
            DtgList.Columns["SistemStokNo"].HeaderText = "SİSTEM STOK NO";
            DtgList.Columns["SistemTanimi"].HeaderText = "SİSTEM TANIM";
            DtgList.Columns["SistemSorumlusu"].HeaderText = "SİSTEM SORUMLUSU";
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
            if (CmbTablo.Text == "TAMAMLANAN SATLAR")
            {
                if (DtgList.RowCount == 0)
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

            if (CmbTablo.Text == "DEPO STOK")
            {
                if (DtgList.RowCount == 0)
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

                row.Cell(1).Value = "STOK NO";
                row.Cell(2).Value = "TANIM";
                row.Cell(3).Value = "SON İŞLEM TARİHİ";
                row.Cell(4).Value = "SON İŞLEM YAPAN";
                row.Cell(5).Value = "MİKTAR";
                row.Cell(6).Value = "DEPO NO";
                row.Cell(7).Value = "DEPO ADRESİ";
                row.Cell(8).Value = "DEPO LOKASYON";
                row.Cell(9).Value = "SERİ NO";
                row.Cell(10).Value = "LOT NO";
                row.Cell(11).Value = "REVİZYON";
                row.Cell(12).Value = "AÇIKLAMA";
                row.Cell(13).Value = "REZERVE DURUMU";
                row.Cell(14).Value = "REZERVE KİMLİK NO";

                row.RowUsed().SetAutoFilter(true);
                row = row.RowBelow();


                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    row.Cell("A").Value = item.Cells["StokNo"].Value.ToString().Trim();
                    row.Cell("B").Value = item.Cells["Tanim"].Value.ToString().Trim();
                    row.Cell("C").Value = item.Cells["SonIslemTarihi"].Value.ToString().Trim();
                    row.Cell("D").Value = item.Cells["SonIslemYapan"].Value.ToString().Trim();
                    row.Cell("E").Value = item.Cells["Miktar"].Value.ToString().Trim();
                    row.Cell("F").Value = item.Cells["DepoNo"].Value.ToString().Trim();
                    row.Cell("G").Value = item.Cells["DepoAdresi"].Value.ToString().Trim();
                    row.Cell("H").Value = item.Cells["DepoLokasyon"].Value.ToString().Trim();
                    row.Cell("I").Value = item.Cells["SeriNo"].Value.ToString().Trim();
                    row.Cell("J").Value = item.Cells["LotNo"].Value.ToString().Trim();
                    row.Cell("K").Value = item.Cells["Revizyon"].Value.ToString().Trim();
                    row.Cell("L").Value = item.Cells["Aciklama"].Value.ToString().Trim();
                    row.Cell("M").Value = item.Cells["RezerveDurumu"].Value.ToString().Trim();
                    row.Cell("N").Value = item.Cells["RezerveId"].Value.ToString().Trim();

                    row = row.RowBelow();
                }

                workSheet.RangeUsed().Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
                workSheet.RangeUsed().Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                dosyaYolu = dosyaYolu + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("mm_ss") + ".xlsx";

                workBook.SaveAs(dosyaYolu);
            }

            if (CmbTablo.Text == "DEPO KAYITLI MALZEMELER")
            {
                if (DtgList.RowCount == 0)
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

                row.Cell(1).Value = "STOK NO";
                row.Cell(2).Value = "TANIM";
                row.Cell(3).Value = "BİRİM";
                row.Cell(4).Value = "TEDARİKÇİ FİRMA";
                row.Cell(5).Value = "ONARIM DURUMU";
                row.Cell(6).Value = "ONARIM YERİ";
                row.Cell(7).Value = "TEDARİK TÜRÜ";
                row.Cell(8).Value = "PARÇA SINIFI";
                row.Cell(9).Value = "MALZEME TAKİP DURUMU";
                row.Cell(10).Value = "AÇIKLAMA";
                row.Cell(11).Value = "ALTERNATİF PARÇA";
                row.Cell(12).Value = "SİSTEM STOK NO";
                row.Cell(13).Value = "SİSTEM TANIM";
                row.Cell(14).Value = "SİSTEM SORUMLUSU";

                row.RowUsed().SetAutoFilter(true);
                row = row.RowBelow();


                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    row.Cell("A").Value = item.Cells["StokNo"].Value.ToString().Trim();
                    row.Cell("B").Value = item.Cells["Tanim"].Value.ToString().Trim();
                    row.Cell("C").Value = item.Cells["Birim"].Value.ToString().Trim();
                    row.Cell("D").Value = item.Cells["TedarikciFirma"].Value.ToString().Trim();
                    row.Cell("E").Value = item.Cells["OnarimDurumu"].Value.ToString().Trim();
                    row.Cell("F").Value = item.Cells["OnarimYeri"].Value.ToString().Trim();
                    row.Cell("G").Value = item.Cells["TedarikTuru"].Value.ToString().Trim();
                    row.Cell("H").Value = item.Cells["ParcaSinifi"].Value.ToString().Trim();
                    row.Cell("I").Value = item.Cells["TakipDurumu"].Value.ToString().Trim();
                    row.Cell("J").Value = item.Cells["Aciklama"].Value.ToString().Trim();
                    row.Cell("K").Value = item.Cells["AlternatifParca"].Value.ToString().Trim();
                    row.Cell("L").Value = item.Cells["SistemStokNo"].Value.ToString().Trim();
                    row.Cell("M").Value = item.Cells["SistemTanimi"].Value.ToString().Trim();
                    row.Cell("N").Value = item.Cells["SistemSorumlusu"].Value.ToString().Trim();

                    row = row.RowBelow();
                }

                workSheet.RangeUsed().Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
                workSheet.RangeUsed().Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                dosyaYolu = dosyaYolu + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("mm_ss") + ".xlsx";

                workBook.SaveAs(dosyaYolu);
            }


            MessageBox.Show("İşlem Tamamlandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
