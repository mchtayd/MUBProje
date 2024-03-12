using Business;
using Business.Concreate;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using ClosedXML.Excel;
using DataAccess.Concreate;
using DataAccess.Concreate.STS;
using DocumentFormat.OpenXml.Wordprocessing;
using Entity;
using Entity.IdariIsler;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.STS
{
    public partial class FrmTamamlananSat : Form
    {
        TamamlananManager tamamlananManager;
        List<Tamamlanan> tamamlanans;
        List<TamamlananMalzeme> tamamlananMalzemes;
        TamamlananMalzemeManager tamamlananMalzemeManager;
        SatIslemAdimlariManager satIslemAdimlarimanager;
        SatTalebiDoldurManager satTalebiDoldurManager;
        IsAkisNoManager isAkisNoManager;
        ComboManager comboManager;
        SatNoManager satNoManager;
        PersonelKayitManager personelKayitManager;
        TeklifsizSatManager teklifsizSatManager;
        SatIslemAdimlariManager satIslemAdimlariManager;
        IstenAyrilisManager ayrilisManager;

        string siparisNo="", dosyayolu, butceKodu;
        int ucteklif;
        double geneltoplam, harcananTutar;
        bool start = true;
        public object[] infos;
        public FrmTamamlananSat()
        {
            InitializeComponent();
            tamamlananManager = TamamlananManager.GetInstance();
            tamamlananMalzemeManager = TamamlananMalzemeManager.GetInstance();
            satIslemAdimlarimanager = SatIslemAdimlariManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            satTalebiDoldurManager = SatTalebiDoldurManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            satNoManager = SatNoManager.GetInstance();
            personelKayitManager = PersonelKayitManager.GetInstance();
            teklifsizSatManager = TeklifsizSatManager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
            ayrilisManager = IstenAyrilisManager.GetInstance();
        }

        private void FrmTamamlananSat_Load(object sender, EventArgs e)
        {
            Yillar();
            TamamlananSatlar();
            ProjeKodu();
            TxtTop.Text = DtgTamamlananSatlar.RowCount.ToString();
            start = false;
        }
        void Yillar()
        {
            CmbYillar.DataSource = tamamlananManager.Yillar();
            int index = 0;
            CmbYillar.SelectedIndex = index;
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSatTamamlanan"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgTamamlananSatlar.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgTamamlananSatlar.Rows[i].Cells[17].Value);
            }
            LblGenelTop.Text = toplam.ToString("C2");
        }
        void Toplamlar2()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgList.Rows[i].Cells["ToplamFiyat"].Value);
            }
            LblGenelTopp.Text = toplam.ToString("C2");
        }
        public void TamamlananSatlar()
        {
            if (ChkTumunuGoster.Checked==true)
            {
                tamamlanans = tamamlananManager.GetList(0);
            }
            if (CmbYillar.Text=="2021")
            {
                tamamlanans = tamamlananManager.GetList(1990);
            }
            else
            {
                tamamlanans = tamamlananManager.GetList(CmbYillar.Text.ConInt());
            }
            dataBinder.DataSource = tamamlanans.ToDataTable();
            DtgTamamlananSatlar.DataSource = dataBinder;
            TxtTop.Text = DtgTamamlananSatlar.RowCount.ToString();
            DataDisplay();
            Toplamlar();
        }
        private void WebBrowser()
        {
            if (dosyayolu == null)
            {
                return;
            }
            try
            {
                webBrowser1.Navigate(dosyayolu);
            }
            catch (Exception)
            {
                return;
            }
            
        }
        void DataDisplay()
        {
            DtgTamamlananSatlar.Columns["Id"].Visible = false;
            DtgTamamlananSatlar.Columns["Satno"].HeaderText = "SAT_NO";
            DtgTamamlananSatlar.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgTamamlananSatlar.Columns["Masrafyeri"].Visible = false;
            DtgTamamlananSatlar.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgTamamlananSatlar.Columns["Bolum"].Visible = false;
            DtgTamamlananSatlar.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ ADI";
            DtgTamamlananSatlar.Columns["Abfform"].HeaderText = "ABF FORM NO";
            DtgTamamlananSatlar.Columns["Istenentarih"].HeaderText = "SAT OLUŞTURMA TARİHİ";
            DtgTamamlananSatlar.Columns["Tamamlanantarih"].HeaderText = "TAMAMLANMA TARİH";
            DtgTamamlananSatlar.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgTamamlananSatlar.Columns["Butcekodukalemi"].HeaderText = "BÜTÇE KODU KALEMİ";
            DtgTamamlananSatlar.Columns["Satbirim"].HeaderText = "SAT BİRİM";
            DtgTamamlananSatlar.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgTamamlananSatlar.Columns["Belgeturu"].HeaderText = "BELGE TÜRÜ";
            DtgTamamlananSatlar.Columns["Belgenumarasi"].HeaderText = "BELGE NUMARASI";
            DtgTamamlananSatlar.Columns["Belgetarihi"].HeaderText = "BELGE TARİHİ";
            DtgTamamlananSatlar.Columns["Faturaedilecekfirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgTamamlananSatlar.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgTamamlananSatlar.Columns["Masrafyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgTamamlananSatlar.Columns["Harcanantutar"].HeaderText = "HARCANAN TUTAR";
            DtgTamamlananSatlar.Columns["Dosyayolu"].Visible = false;
            DtgTamamlananSatlar.Columns["Siparisno"].Visible = false;
            DtgTamamlananSatlar.Columns["Ucteklif"].Visible = false;
            DtgTamamlananSatlar.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            //DtgTamamlananSatlar.Columns["Donem"].DisplayIndex = 3;
            DtgTamamlananSatlar.Columns["Donem"].HeaderText = "DÖNEM";
            DtgTamamlananSatlar.Columns["Proje"].HeaderText = "BAŞARAN PROJE NO";
            DtgTamamlananSatlar.Columns["Gecensure"].HeaderText = "GEÇEN SÜRE";
            DtgTamamlananSatlar.Columns["UsProjeNo"].HeaderText = "Ü.B PRJ. NO";
            DtgTamamlananSatlar.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgTamamlananSatlar.Columns["MlzTeslimAldTarih"].HeaderText = "MALZEMENİN TESLİM ALINDIĞI TARİH";
            DtgTamamlananSatlar.Columns["OdemeMailGondermeTarihi"].HeaderText = "ÖDEME MAIL GÖNDERME TARİHİ";
            DtgTamamlananSatlar.Columns["OdemeMailTarihi"].HeaderText = "ÖDEME MAIL GELME TARİHİ";
            DtgTamamlananSatlar.Columns["AselsanMailGondermeTarihi"].HeaderText = "ASELSAN ONAY MAIL GÖNDERME TARİHİ";
            DtgTamamlananSatlar.Columns["AselsanMailTarihi"].HeaderText = "ASELSAN ONAY MAIL ALMA TARİHİ";
            DtgTamamlananSatlar.Columns["DepoTeslimTarihi"].HeaderText = "DEPOYA TESLİM TARİHİ";
            DtgTamamlananSatlar.Columns["ButceTanimi"].HeaderText = "BÜTÇE TANIMI";
            DtgTamamlananSatlar.Columns["MaliyetTuru"].HeaderText = "MALİYET TÜRÜ";
            DtgTamamlananSatlar.Columns["FirmayaKesilenFatura"].HeaderText = "FİRMAYA KESİLEN FATURA NO";
            DtgTamamlananSatlar.Columns["KesilenFaturaTarihi"].HeaderText = "FİRMAYA KESİLEN FATURA TARİHİ";
            DtgTamamlananSatlar.Columns["ButceGiderTuru"].HeaderText = "BÜTÇE GİDER TÜRÜ";
            DtgTamamlananSatlar.Columns["SatinAlinanFirma"].HeaderText = "SATIN ALINAN FİRMA";
            DtgTamamlananSatlar.Columns["HarcamaYapan"].HeaderText = "ÖDEME YAPAN";
            DtgTamamlananSatlar.Columns["SatOlusturmaTuru"].HeaderText = "SAT OLUŞTURMA TÜRÜ";


            DtgTamamlananSatlar.Columns["Id"].DisplayIndex = 0;
            DtgTamamlananSatlar.Columns["Donem"].DisplayIndex = 1;
            DtgTamamlananSatlar.Columns["Istenentarih"].DisplayIndex = 2;
            DtgTamamlananSatlar.Columns["Tamamlanantarih"].DisplayIndex = 3;
            DtgTamamlananSatlar.Columns["Gecensure"].DisplayIndex = 4;
            DtgTamamlananSatlar.Columns["Formno"].DisplayIndex = 5;
            DtgTamamlananSatlar.Columns["Satno"].DisplayIndex = 6;
            DtgTamamlananSatlar.Columns["IslemAdimi"].DisplayIndex = 7;
            DtgTamamlananSatlar.Columns["ButceTanimi"].DisplayIndex = 8;
            DtgTamamlananSatlar.Columns["Butcekodukalemi"].DisplayIndex = 9;
            DtgTamamlananSatlar.Columns["ButceGiderTuru"].DisplayIndex = 10;
            DtgTamamlananSatlar.Columns["Proje"].DisplayIndex = 11;
            DtgTamamlananSatlar.Columns["Usbolgesi"].DisplayIndex = 12;
            DtgTamamlananSatlar.Columns["UsProjeNo"].DisplayIndex = 13;
            DtgTamamlananSatlar.Columns["Abfform"].DisplayIndex = 14;
            DtgTamamlananSatlar.Columns["GarantiDurumu"].DisplayIndex = 15;
            DtgTamamlananSatlar.Columns["SatinAlinanFirma"].DisplayIndex = 16;
            DtgTamamlananSatlar.Columns["Belgeturu"].DisplayIndex = 17;
            DtgTamamlananSatlar.Columns["Belgenumarasi"].DisplayIndex = 18;
            DtgTamamlananSatlar.Columns["Belgetarihi"].DisplayIndex = 19;
            DtgTamamlananSatlar.Columns["Harcanantutar"].DisplayIndex = 20;
            DtgTamamlananSatlar.Columns["Talepeden"].DisplayIndex = 21;
            DtgTamamlananSatlar.Columns["Satbirim"].DisplayIndex = 22;
            DtgTamamlananSatlar.Columns["HarcamaYapan"].DisplayIndex = 23;
            DtgTamamlananSatlar.Columns["OdemeMailGondermeTarihi"].DisplayIndex = 24;
            DtgTamamlananSatlar.Columns["OdemeMailTarihi"].DisplayIndex = 25;
            DtgTamamlananSatlar.Columns["Faturaedilecekfirma"].DisplayIndex = 26;
            DtgTamamlananSatlar.Columns["Ilgilikisi"].DisplayIndex = 27;
            DtgTamamlananSatlar.Columns["Masrafyerino"].DisplayIndex = 28;
            DtgTamamlananSatlar.Columns["FirmayaKesilenFatura"].DisplayIndex = 29;
            DtgTamamlananSatlar.Columns["KesilenFaturaTarihi"].DisplayIndex = 30;
            DtgTamamlananSatlar.Columns["MaliyetTuru"].DisplayIndex = 31;
            DtgTamamlananSatlar.Columns["MlzTeslimAldTarih"].DisplayIndex = 32;
            DtgTamamlananSatlar.Columns["DepoTeslimTarihi"].DisplayIndex = 33;
            DtgTamamlananSatlar.Columns["AselsanMailGondermeTarihi"].DisplayIndex = 34;
            DtgTamamlananSatlar.Columns["AselsanMailTarihi"].DisplayIndex = 35;
            DtgTamamlananSatlar.Columns["Harcamaturu"].DisplayIndex = 36;
            DtgTamamlananSatlar.Columns["Gerekce"].DisplayIndex = 37;
            DtgTamamlananSatlar.Columns["Masrafyeri"].Visible = false;
            DtgTamamlananSatlar.Columns["Bolum"].Visible = false;
            DtgTamamlananSatlar.Columns["Dosyayolu"].Visible = false;
            DtgTamamlananSatlar.Columns["Siparisno"].Visible = false;
            DtgTamamlananSatlar.Columns["Ucteklif"].Visible = false;


        }
        void PanelGenislet()
        {
            groupBox2.Visible = true;
            PnlKaydir.Location = new Point(917, 15);
            PnlTemsili.Location = new Point(747, 721);
        }
        void PanelDaralt()
        {
            groupBox2.Visible = true;
            PnlKaydir.Location = new Point(676, 15);
            PnlTemsili.Location = new Point(527, 721);
        }
        void PanelDaraltTemsili()
        {
            groupBox2.Visible = false;
            PnlTemsili.Location = new Point(6, 389);
        }
        string satOlusturmaTuru = "";
        int id = 0;
        private void DtgTamamlananSatlar_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (start)
            {
                return;
            }
            if (DtgTamamlananSatlar.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            id = DtgTamamlananSatlar.CurrentRow.Cells["Id"].Value.ConInt();
            siparisNo = DtgTamamlananSatlar.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosyayolu = DtgTamamlananSatlar.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            ucteklif = DtgTamamlananSatlar.CurrentRow.Cells["Ucteklif"].Value.ConInt();
            butceKodu = DtgTamamlananSatlar.CurrentRow.Cells["Butcekodukalemi"].Value.ToString();
            harcananTutar = DtgTamamlananSatlar.CurrentRow.Cells["Harcanantutar"].Value.ConDouble();
            satOlusturmaTuru = DtgTamamlananSatlar.CurrentRow.Cells["SatOlusturmaTuru"].Value.ToString();
            MalzemeFill(siparisNo);
            TxtGerekce.Text= DtgTamamlananSatlar.CurrentRow.Cells["Gerekce"].Value.ToString();
            //geneltoplam = DtgTamamlananSatlar.CurrentRow.Cells["Harcanantutar"].Value.ConDouble();
            geneltoplam = tamamlanans.FirstOrDefault(x => x.Siparisno == siparisNo).Harcanantutar;

            WebBrowser();
            IslemAdimlari();

            if (ucteklif == 1)
            {
                PanelGenislet();
                PnlGizle.Visible = true;
            }
            if (ucteklif == 0)
            {
                if (satOlusturmaTuru == "HARCAMASI YAPILAN")
                {
                    TxtGenelTop.Text = harcananTutar.ToString("0.00") + " ₺";
                    PanelDaraltTemsili();
                    return;
                }
                PanelDaralt();
                PnlGizle.Visible = false;
            }

            TxtGenelTop.Text = geneltoplam.ToString("0.00") + " ₺";
            FillTools();
        }
        void MalzemeFill(string siparisNo)
        {
            tamamlananMalzemes = tamamlananMalzemeManager.GetList(siparisNo);
            if (tamamlananMalzemes.Count==0)
            {
                DtgList.DataSource = teklifsizSatManager.GetList(siparisNo);
                DtgList.Columns["Id"].Visible = false;
                DtgList.Columns["Stokno"].Visible = false;
                DtgList.Columns["Tanim"].Visible = false;
                DtgList.Columns["Miktar"].Visible = false;
                DtgList.Columns["Birim"].Visible = false;
                DtgList.Columns["Siparisno"].Visible = false;
                DtgList.Columns["Tutar"].HeaderText = "TOPLAM FİYAT";
            }
            else
            {
                DtgList.DataSource = tamamlananMalzemes;
                if (satOlusturmaTuru == "HARCAMASI YAPILAN")
                {
                    DtgList.Columns["Id"].Visible = false;
                    DtgList.Columns["Stokno"].Visible = false;
                    DtgList.Columns["Tanim"].Visible = false;
                    DtgList.Columns["Miktar"].Visible = false;
                    DtgList.Columns["Birim"].Visible = false;
                    DtgList.Columns["Firma"].Visible = false;
                    DtgList.Columns["Birimfiyat"].Visible = false;
                    DtgList.Columns["Toplamfiyat"].HeaderText = "TOPLAM FİYAT";
                    DtgList.Columns["Siparisno"].Visible = false;
                }
                else
                {
                    DtgList.Columns["Id"].Visible = false;
                    DtgList.Columns["Stokno"].Visible = true;
                    DtgList.Columns["Tanim"].Visible = true;
                    DtgList.Columns["Miktar"].Visible = true;
                    DtgList.Columns["Birim"].Visible = true;
                    DtgList.Columns["Firma"].Visible = false;
                    DtgList.Columns["Birimfiyat"].Visible = true;
                    DtgList.Columns["Toplamfiyat"].HeaderText = "TOPLAM FİYAT";
                    DtgList.Columns["Siparisno"].Visible = false;

                    DtgList.Columns["Id"].Visible = false;
                    DtgList.Columns["Stokno"].HeaderText = "STOK NO";
                    DtgList.Columns["Tanim"].HeaderText = "TANIM";
                    DtgList.Columns["Miktar"].HeaderText = "MİKTAR";
                    DtgList.Columns["Birim"].HeaderText = "BİRİM";
                    DtgList.Columns["Firma"].Visible = false;
                    DtgList.Columns["Birimfiyat"].HeaderText = "BİRİM FİYAT";
                    DtgList.Columns["Toplamfiyat"].HeaderText = "TOPLAM FİYAT";
                    DtgList.Columns["Siparisno"].Visible = false;
                }

                Toplamlar2();
            }
            
        }

        void IslemAdimlari()
        {
            DtgSatIslemAdimlari.DataSource = satIslemAdimlarimanager.GetList(siparisNo);

            DtgSatIslemAdimlari.Columns["Id"].Visible = false;
            DtgSatIslemAdimlari.Columns["Siparisno"].Visible = false;
            DtgSatIslemAdimlari.Columns["Islem"].HeaderText = "İŞLEM ADIMI";
            DtgSatIslemAdimlari.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgSatIslemAdimlari.Columns["Tarih"].HeaderText = "TARİH";
            /*DtgSatIslemAdimlari.Columns["Tarih"].Width = 40;
            DtgSatIslemAdimlari.Columns["Islemyapan"].Width = 120;
            DtgSatIslemAdimlari.Columns["Islem"].Width = 320;*/
        }
        void Temizle()
        {
            stn1.Clear(); t1.Clear(); m1.Clear(); b1.Clear(); F1_1.Clear(); BBF1.Clear(); BT1.Clear();
            stn2.Clear(); t2.Clear(); m2.Clear(); b2.Clear(); F1_2.Clear(); BBF2.Clear(); BT2.Clear();
            stn3.Clear(); t3.Clear(); m3.Clear(); b3.Clear(); F1_3.Clear(); BBF3.Clear(); BT3.Clear();
            stn4.Clear(); t4.Clear(); m4.Clear(); b4.Clear(); F1_4.Clear(); BBF4.Clear(); BT4.Clear();
            stn5.Clear(); t5.Clear(); m5.Clear(); b5.Clear(); F1_5.Clear(); BBF5.Clear(); BT5.Clear();
            stn6.Clear(); t6.Clear(); m6.Clear(); b6.Clear(); F1_6.Clear(); BBF6.Clear(); BT6.Clear();
            stn7.Clear(); t7.Clear(); m7.Clear(); b7.Clear(); F1_7.Clear(); BBF7.Clear(); BT7.Clear();
            stn8.Clear(); t8.Clear(); m8.Clear(); b8.Clear(); F1_8.Clear(); BBF8.Clear(); BT8.Clear();
            stn9.Clear(); t9.Clear(); m9.Clear(); b9.Clear(); F1_9.Clear(); BBF9.Clear(); BT9.Clear();
            stn10.Clear(); t1.Clear(); m10.Clear(); b10.Clear(); F1_10.Clear(); BBF10.Clear(); BT10.Clear();
        }

        private void DtgTamamlananSatlar_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgTamamlananSatlar.FilterString;
            TxtTop.Text = DtgTamamlananSatlar.RowCount.ToString();
            Toplamlar();
        }

        private void DtgTamamlananSatlar_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgTamamlananSatlar.SortString;
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TamamlananSatlar();
            TxtTop.Text = DtgTamamlananSatlar.RowCount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int satir=0;
            IXLWorkbook workbook = new XLWorkbook(@"C:\Users\MAYıldırım\Desktop\SAT VERİ GİRİŞ DOSYASI_2021.xlsx");
            IXLWorksheet worksheet = workbook.Worksheet("Sayfa1");
            //IXLWorksheet worksheet2 = workbook.Worksheet("AĞUSTOS");
            var rows = worksheet.Rows(2, 2271);
            List<Tamamlanan> list = new List<Tamamlanan>();
            foreach (IXLRow item in rows)
            {
                if (item.Cell("C").Value.ToString().Trim() != "" && item.Cell("C").Value.ToString().Trim() == "EYLÜL")
                {
                    try
                    {
                        DateTime outDate = new DateTime(1900, 12, 31);
                        Tamamlanan tamamlanan = new Tamamlanan(
                            item.Cell("B").Value.ToString(),
                            0,
                            "",
                            item.Cell("Z").Value.ToString(),
                            "",
                            item.Cell("D").Value.ToString(),
                            item.Cell("Q").Value.ToString(),
                            item.Cell("H").Value.ConDate(),
                            item.Cell("I").Value.ConDate(),
                            item.Cell("M").Value.ToString(),
                            item.Cell("N").Value.ToString() + "/" + item.Cell("O").Value.ToString(),
                            item.Cell("R").Value.ToString(),
                            item.Cell("S").Value.ToString(),
                            item.Cell("V").Value.ToString(),
                            item.Cell("X").Value.ToString(),
                            DateTime.TryParse(item.Cell("W").Value.ToString(), out outDate) ? item.Cell("W").Value.ConDate() : outDate,
                            //item.Cell("W").Value.ConTime(), // BELGE TARİHİ
                            item.Cell("T").Value.ToString(),
                            item.Cell("G").Value.ToString(),
                            item.Cell("L").Value.ToString(),
                            item.Cell("Y").Value.ConDouble(),
                            "",
                            item.Cell("F").Value.ToString(),
                            -1,
                            "TAMAMLANAN SATLAR",
                            item.Cell("C").Value.ToString(),
                            item.Cell("T").Value.ToString(),
                            item.Cell("K").Value.ToString(),
                            item.Cell("U").Value.ToString(),
                            item.Cell("AA").Value.ToString(),
                            "",
                            "",
                            "",
                            DateTime.Now,
                            DateTime.Now,
                            DateTime.Now,
                            DateTime.Now,
                            DateTime.Now,
                            "",
                            "",
                            "",
                            "",
                            "");
                        list.Add(tamamlanan);

                        if (outDate.ToString()== "1.01.0001 00:00:00")
                        {
                            tamamlanan.Belgetarihi = "31.12.1900 00:00:00".ConDate();
                        }
                        tamamlananManager.Add(tamamlanan);
                        satir++;
                    }
                    catch (Exception ex)
                    {
                        int satirdegeri = satir;
                        string sat = item.Cell("B").Value.ToString();
                        string a = ex.Message;
                    }
                }
            }
            MessageBox.Show("Bitti");
        }

        private void stn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F1_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F1_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F1_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F1_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F1_5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F1_6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F1_7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F1_8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F1_9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F1_10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BBF1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BT2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BT3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BT4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BT5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BT6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BT7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BT8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BT9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BtnSatiGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Güncellemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = tamamlananManager.SatFirmaGuncelle(siparisNo, CmbProjeKodu.Text, TxtFirma.Text);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbProjeKodu.SelectedValue = ""; TxtFirma.Clear();
                DataDisplay();
            }
        }
        void ProjeKodu()
        {
            CmbProjeKodu.DataSource = comboManager.GetList("PROJE");
            CmbProjeKodu.ValueMember = "Id";
            CmbProjeKodu.DisplayMember = "Baslik";
            CmbProjeKodu.SelectedValue = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*DialogResult dr = MessageBox.Show("Bilgileri Guncellemek İstiyor Musunuz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                if (siparisNo=="")
                {
                    MessageBox.Show("Lütfen Geçerli Bir Sat Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                string mesaj = tamamlananManager.UpdateTutar(TxtGenelTop.Text.ConDouble(), siparisNo);
                if (mesaj!="OK")
                {
                    MessageBox.Show( mesaj,"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MalzemeGuncelle();

                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TamamlananSatlar();
                Temizle();
            }*/
        }
        void MalzemeGuncelle()
        {
            /*List<TamamlananMalzeme> tamamlanan = new List<TamamlananMalzeme>();

            if (stn1.Text!="")
            {
                TamamlananMalzeme tamamlananMalzeme = new TamamlananMalzeme(stn1.Text, BBF1.Text.ConDouble(), BT1.Text.ConDouble(), siparisNo);
                tamamlanan.Add(tamamlananMalzeme);
            }
            if (stn2.Text != "")
            {
                TamamlananMalzeme tamamlananMalzeme = new TamamlananMalzeme(stn2.Text, BBF2.Text.ConDouble(), BT2.Text.ConDouble(), siparisNo);
                tamamlanan.Add(tamamlananMalzeme);
            }
            if (stn3.Text != "")
            {
                TamamlananMalzeme tamamlananMalzeme = new TamamlananMalzeme(stn3.Text, BBF3.Text.ConDouble(), BT3.Text.ConDouble(), siparisNo);
                tamamlanan.Add(tamamlananMalzeme);
            }
            if (stn4.Text != "")
            {
                TamamlananMalzeme tamamlananMalzeme = new TamamlananMalzeme(stn4.Text, BBF4.Text.ConDouble(), BT4.Text.ConDouble(), siparisNo);
                tamamlanan.Add(tamamlananMalzeme);
            }
            if (stn5.Text != "")
            {
                TamamlananMalzeme tamamlananMalzeme = new TamamlananMalzeme(stn5.Text, BBF5.Text.ConDouble(), BT5.Text.ConDouble(), siparisNo);
                tamamlanan.Add(tamamlananMalzeme);
            }
            if (stn6.Text != "")
            {
                TamamlananMalzeme tamamlananMalzeme = new TamamlananMalzeme(stn6.Text, BBF6.Text.ConDouble(), BT6.Text.ConDouble(), siparisNo);
                tamamlanan.Add(tamamlananMalzeme);
            }
            if (stn7.Text != "")
            {
                TamamlananMalzeme tamamlananMalzeme = new TamamlananMalzeme(stn7.Text, BBF7.Text.ConDouble(), BT7.Text.ConDouble(), siparisNo);
                tamamlanan.Add(tamamlananMalzeme);
            }
            if (stn8.Text != "")
            {
                TamamlananMalzeme tamamlananMalzeme = new TamamlananMalzeme(stn8.Text, BBF8.Text.ConDouble(), BT8.Text.ConDouble(), siparisNo);
                tamamlanan.Add(tamamlananMalzeme);
            }
            if (stn9.Text != "")
            {
                TamamlananMalzeme tamamlananMalzeme = new TamamlananMalzeme(stn9.Text, BBF9.Text.ConDouble(), BT9.Text.ConDouble(), siparisNo);
                tamamlanan.Add(tamamlananMalzeme);
            }
            if (stn10.Text != "")
            {
                TamamlananMalzeme tamamlananMalzeme = new TamamlananMalzeme(stn10.Text, BBF10.Text.ConDouble(), BT10.Text.ConDouble(), siparisNo);
                tamamlanan.Add(tamamlananMalzeme);
            }
            foreach (TamamlananMalzeme item in tamamlanan)
            {
                tamamlananMalzemeManager.UpdateFiyat(item);
            }
            */
        }
        string topfiyat;
        double outValue = 0;
        double sonuc;
        string TopFiyatHesapla(string a, string b)
        {
            double x, y = 0;

            if (a == "" || b == "")
            {
                sonuc = 0;
                topfiyat = sonuc.ToString("0.00");
                return topfiyat;
            }
            x = double.TryParse(a, out outValue) ? Convert.ToDouble(a) : 0;
            y = double.TryParse(b, out outValue) ? Convert.ToDouble(b) : 0;
            sonuc = x * y;
            topfiyat = sonuc.ToString("0.00");
            return topfiyat;
        }
        double x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, geneltop;
        void GenelToplam1()
        {
            geneltop = x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9 + x10;

            TxtGenelTop.Text = geneltop.ToString("0.00") + " ₺";
        }

        private void BT1_TextChanged(object sender, EventArgs e)
        {
            if (BT1.Text == "")
            {
                x1 = 0;
                GenelToplam1();
                return;
            }
            x1 = BT1.Text.ConDouble();
            GenelToplam1();
        }

        private void BT2_TextChanged(object sender, EventArgs e)
        {
            if (BT2.Text == "")
            {
                x2 = 0;
                GenelToplam1();
                return;
            }
            x2 = BT2.Text.ConDouble();
            GenelToplam1();
        }

        private void BT3_TextChanged(object sender, EventArgs e)
        {
            if (BT3.Text == "")
            {
                x3 = 0;
                GenelToplam1();
                return;
            }
            x3 = BT3.Text.ConDouble();
            GenelToplam1();
        }

        private void BT4_TextChanged(object sender, EventArgs e)
        {
            if (BT4.Text == "")
            {
                x4 = 0;
                GenelToplam1();
                return;
            }
            x4 = BT4.Text.ConDouble();
            GenelToplam1();
        }

        private void BT5_TextChanged(object sender, EventArgs e)
        {
            if (BT5.Text == "")
            {
                x5 = 0;
                GenelToplam1();
                return;
            }
            x5 = BT5.Text.ConDouble();
            GenelToplam1();
        }

        private void BT6_TextChanged(object sender, EventArgs e)
        {
            if (BT6.Text == "")
            {
                x6 = 0;
                GenelToplam1();
                return;
            }
            x6 = BT6.Text.ConDouble();
            GenelToplam1();
        }

        private void BT7_TextChanged(object sender, EventArgs e)
        {
            if (BT7.Text == "")
            {
                x7 = 0;
                GenelToplam1();
                return;
            }
            x7 = BT7.Text.ConDouble();
            GenelToplam1();
        }

        private void BT8_TextChanged(object sender, EventArgs e)
        {
            if (BT8.Text == "")
            {
                x8 = 0;
                GenelToplam1();
                return;
            }
            x8 = BT8.Text.ConDouble();
            GenelToplam1();
        }

        private void BT9_TextChanged(object sender, EventArgs e)
        {
            if (BT9.Text == "")
            {
                x9 = 0;
                GenelToplam1();
                return;
            }
            x9 = BT9.Text.ConDouble();
            GenelToplam1();
        }

        private void BT10_TextChanged(object sender, EventArgs e)
        {
            if (BT10.Text == "")
            {
                x10 = 0;
                GenelToplam1();
                return;
            }
            x10 = BT10.Text.ConDouble();
            GenelToplam1();
        }

        private void DtgTamamlananSatlar_KeyDown(object sender, KeyEventArgs e)
        {
            if (start)
            {
                return;
            }
            if (DtgTamamlananSatlar.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }

            siparisNo = DtgTamamlananSatlar.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosyayolu = DtgTamamlananSatlar.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            ucteklif = DtgTamamlananSatlar.CurrentRow.Cells["Ucteklif"].Value.ConInt();
            butceKodu = DtgTamamlananSatlar.CurrentRow.Cells["Butcekodukalemi"].Value.ToString();
            harcananTutar = DtgTamamlananSatlar.CurrentRow.Cells["Harcanantutar"].Value.ConDouble();
            satOlusturmaTuru = DtgTamamlananSatlar.CurrentRow.Cells["SatOlusturmaTuru"].Value.ToString();
            tamamlananMalzemes = tamamlananMalzemeManager.GetList(siparisNo);
            //geneltoplam = DtgTamamlananSatlar.CurrentRow.Cells["Harcanantutar"].Value.ConDouble();
            geneltoplam = tamamlanans.FirstOrDefault(x => x.Siparisno == siparisNo).Harcanantutar;
            WebBrowser();
            IslemAdimlari();

            if (ucteklif == 1)
            {
                PanelGenislet();
                PnlGizle.Visible = true;
            }
            if (ucteklif == 0)
            {
                if (satOlusturmaTuru == "HARCAMASI YAPILAN")
                {
                    TxtGenelTop.Text = harcananTutar.ToString("0.00") + " ₺";
                    PanelDaraltTemsili();
                    return;
                }
                PanelDaralt();
                PnlGizle.Visible = false;
            }

            TxtGenelTop.Text = geneltoplam.ToString("0.00") + " ₺";
            FillTools();
        }

        private void BtnProjeDuzelt_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tüm Kayıtların Proje Bilgileri Kontrol Edilip Düzeltilecek!\nOnaylıyor Musunuz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            
            if (dr==DialogResult.Yes)
            {

                foreach (DataGridViewRow item in DtgTamamlananSatlar.Rows)
                {
                    string usBolgesi = item.Cells["Usbolgesi"].Value.ToString();
                    int isAkisNo = item.Cells["Formno"].Value.ConInt();
                    if (usBolgesi!=null)
                    {
                        if (usBolgesi != "")
                        {
                            if (usBolgesi != "YOK")
                            {
                                if (isAkisNo != 0)
                                {
                                    int id = item.Cells["Id"].Value.ConInt();
                                    SatTalebiDoldur satTalebiDoldur = satTalebiDoldurManager.Get(usBolgesi);
                                    string proje = satTalebiDoldur.Proje;

                                    tamamlananManager.ProjeDuzelt(proje, id);
                                }
                            }
                            
                        }
                        
                    }

                }
            }
        }

        private void CmbYillar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start==true)
            {
                return;
            }
            if (CmbYillar.SelectedIndex==-1)
            {
                return;
            }
            TamamlananSatlar();
        }

        private void ChkTumunuGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTumunuGoster.Checked==true)
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
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            isAkisNo = isAkis.Id.ToString();
        }
        string isAkisNo, dosyaYolu;
        int satNo;
        void DosyaOlustur()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            dosyaYolu = subdir + satNo.ToString();
            Directory.CreateDirectory(dosyaYolu);
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSatDuzelt frmSatDuzelt = new FrmSatDuzelt();
            frmSatDuzelt.infos = infos;
            frmSatDuzelt.id = id;
            frmSatDuzelt.ShowDialog();
        }

        private void BtnProjeDuzelt_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Teklifsiz Satta bulunan tamamlanmış satın yeri Tamamlanmış Sat Malzeme yerine alınacaktır!", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                List<Tamamlanan> tamamlanans = new List<Tamamlanan>();

                tamamlanans = tamamlananManager.GetList(0);
                foreach (Tamamlanan item in tamamlanans)
                {
                    List<TamamlananMalzeme> tamamlananMalzemes = new List<TamamlananMalzeme>();
                    tamamlananMalzemes = tamamlananMalzemeManager.GetList(item.Siparisno);
                    if (tamamlananMalzemes.Count==0)
                    {
                        List<TeklifsizSat> teklifsizSats = new List<TeklifsizSat>();
                        teklifsizSats = teklifsizSatManager.GetList(item.Siparisno);
                        if (teklifsizSats.Count != 0)
                        {
                            foreach (TeklifsizSat item2 in teklifsizSats)
                            {
                                TamamlananMalzeme tamamlananMalzeme = new TamamlananMalzeme(item2.Stokno, item2.Tanim, item2.Miktar.ConInt(), item2.Birim, item.SatinAlinanFirma, item2.Tutar, item2.Tutar, item2.Siparisno);

                                tamamlananMalzemeManager.Add(tamamlananMalzeme);
                            }
                        }
                        else
                        {

                        }
                        
                        
                    }
                }
            }
        }

        private void BtnDonemDuzelt_Click(object sender, EventArgs e)
        {
            string donem = "";
            List<Tamamlanan> tamamlanans = new List<Tamamlanan>();
            tamamlanans = tamamlananManager.GetList(2023);
            foreach (Tamamlanan item in tamamlanans)
            {
                if (item.Donem=="NİSAN 2023")
                {
                    donem = item.Belgetarihi.ConPeriod();

                    tamamlananManager.DonemEdit(donem, item.Id);
                }
            }
            string bitti = "";

            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in DtgTamamlananSatlar.Rows)
            {
                harcananTutar = item.Cells["Harcanantutar"].Value.ConDouble();
                siparisNo = item.Cells["SiparisNo"].Value.ToString();
                id = item.Cells["Id"].Value.ConInt();
                string satNo = item.Cells["Formno"].Value.ToString();
                string donem = item.Cells["Donem"].Value.ToString();
                tamamlananMalzemes = new List<TamamlananMalzeme>();
                List<TeklifsizSat> teklifsizSats = new List<TeklifsizSat>();
                tamamlananMalzemes = tamamlananMalzemeManager.GetList(siparisNo);
                double toplamTutar = 0;
                if (tamamlananMalzemes.Count==0)
                {
                    teklifsizSats = teklifsizSatManager.GetList(siparisNo);
                    foreach (TeklifsizSat item3 in teklifsizSats)
                    {
                        toplamTutar = Math.Round(item3.Tutar, 2);
                        if (harcananTutar != toplamTutar)
                        {
                            tamamlananManager.UpdateTutar(toplamTutar, siparisNo);
                        }
                    }
                }
                else
                {
                    foreach (TamamlananMalzeme item2 in tamamlananMalzemes)
                    {

                        toplamTutar += item2.Toplamfiyat;

                    }
                    toplamTutar = Math.Round(toplamTutar, 2);
                    if (harcananTutar != toplamTutar)
                    {
                        tamamlananManager.UpdateTutar(toplamTutar, siparisNo);
                    }
                }
                
            }


            //foreach (DataGridViewRow item in DtgTamamlananSatlar.Rows)
            //{
            //    if (item.Cells["Abfform"].Value.ToString()== "" && item.Cells["Butcekodukalemi"].Value.ToString() == "BM02/ACİL ONARIM MALZEME ALIMI")
            //    {
            //        string abfNo = tamamlananManager.AbfOgren(item.Cells["Gerekce"].Value.ToString());
            //        if (abfNo!="")
            //        {
            //            tamamlananManager.AbfNoDuzelt(item.Cells["Formno"].Value.ConInt(), abfNo);
            //        }
                    
            //    }
            //}
            //MessageBox.Show("İşlemler başarıyla gerçekleşmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void kesilenFaturaOnaylaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Firmaya Kesilen Fatura bilgisini 'ONAYLANDI' olarak değiştirmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                string mesaj = tamamlananManager.FaturaDurumUpdate(id);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                TamamlananSatlar();
                id = 0;
                MessageBox.Show("Bilgiler başarıyla güncellenmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //if (TxtGerekce.Text=="")
            //{
            //    MessageBox.Show("Lütfen güncellenecek Gerekçeyi doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (id==0)
            //{
            //    MessageBox.Show("Lütfen bir sat seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //string mesaj = tamamlananManager.SatGerekceGuncelle(id, TxtGerekce.Text);
            //if (mesaj!="OK")
            //{
            //    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //id = 0;
            //MessageBox.Show("Bilgiler başarıyla güncellenmiştir, sayfayı yenilerseniz bilgiler değişecektir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //TxtGerekce.Clear();
            #region excelOku
            int satir = 0;
            IXLWorkbook workbook = new XLWorkbook(@"C:\Users\MAYıldırım\Desktop\SAT VERİ GİRİŞ DOSYASI_2022.xlsx");
            IXLWorksheet worksheet = workbook.Worksheet("SAT DTS VERİ");
            //IXLWorksheet worksheet2 = workbook.Worksheet("AĞUSTOS");
            var rows = worksheet.Rows(2, 2132);
            List<Tamamlanan> list = new List<Tamamlanan>();
            foreach (IXLRow item in rows)
            {
                try
                {
                    string isAkis = item.Cell("E").Value.ToString();
                    DateTime dd = item.Cell("A").Value.ConDate();
                    string donem = dd.ConPeriod();
                    if (isAkis == "")
                    {
                        IsAkisNo();
                        siparisNo = Guid.NewGuid().ToString();
                        satNo = satNoManager.Add(new SatNo(siparisNo));
                        DosyaOlustur();
                        PersonelKayit personelKayit = personelKayitManager.Get(0, item.Cell("V").Value.ToString());

                        string sirketBolum, perMasYeri = "";

                        if (personelKayit != null)
                        {
                            sirketBolum = personelKayit.Sirketbolum;
                            perMasYeri = personelKayit.Masrafyeri;
                        }
                        else
                        {
                            //IstenAyrilis ayrilis = ayrilisManager.Get(item.Cell("V").Value.ToString());
                            sirketBolum = "";
                            perMasYeri = "";
                        }

                        Tamamlanan tamamlanan = new Tamamlanan(
                            satNo.ToString(),
                            isAkisNo.ConInt(),
                            perMasYeri,
                            item.Cell("V").Value.ToString(),
                            sirketBolum,
                            item.Cell("L").Value.ToString(),
                            item.Cell("M").Value.ToString(),
                            item.Cell("B").Value.ConDate(),
                            item.Cell("C").Value.ConDate(),
                            "MANUEL KAYIT.",
                            item.Cell("I").Value.ToString(),
                            item.Cell("W").Value.ToString(),
                            "",
                            item.Cell("R").Value.ToString(),
                            item.Cell("S").Value.ToString(),
                            item.Cell("T").Value.ConDate(),
                            //item.Cell("W").Value.ConTime(), // BELGE TARİHİ
                            item.Cell("Z").Value.ToString(),
                            item.Cell("AA").Value.ToString(),
                            item.Cell("AB").Value.ToString(),
                            item.Cell("U").Value.ConDouble(),
                            dosyaYolu,
                            siparisNo,
                            0,
                            item.Cell("G").Value.ToString(),
                            donem,
                            "HARCAMASI YAPILAN",
                            item.Cell("K").Value.ToString(),
                            item.Cell("Q").Value.ToString(),
                            item.Cell("X").Value.ToString(),
                            item.Cell("O").Value.ToString(),
                            item.Cell("P").Value.ToString(),
                            item.Cell("C").Value.ToString(),
                            item.Cell("C").Value.ConDate(),
                            item.Cell("C").Value.ConDate(),
                            item.Cell("C").Value.ConDate(),
                            item.Cell("C").Value.ConDate(),
                            item.Cell("C").Value.ConDate(),
                            item.Cell("H").Value.ToString(), //BÜTÇE TANIM
                            item.Cell("AE").Value.ToString(),// MALİYET TÜRÜ
                            item.Cell("AC").Value.ToString(),
                            item.Cell("AD").Value.ToString(),
                            item.Cell("J").Value.ToString());
                        list.Add(tamamlanan);


                        tamamlananManager.Add(tamamlanan);
                        satir++;

                        TeklifsizSat teklifsizSat = new TeklifsizSat("", "", 0, "", item.Cell("U").Value.ConDouble(), siparisNo);
                        teklifsizSatManager.Add(teklifsizSat);

                        SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, "MANUEL KAYIT.",
                            item.Cell("V").Value.ToString(), DateTime.Now);
                        satIslemAdimlariManager.Add(satIslem);

                    }
                    else
                    {
                        Tamamlanan tamamlanan1 = tamamlananManager.GetListYedekData(item.Cell("E").Value.ConInt());

                        if (tamamlanan1 == null)
                        {
                            MessageBox.Show("Hata");
                        }

                        DateTime outDate = new DateTime(1900, 12, 31);
                        Tamamlanan tamamlanan = new Tamamlanan(
                            item.Cell("F").Value.ToString(),
                            item.Cell("E").Value.ConInt(),
                            tamamlanan1.Masrafyeri,
                            item.Cell("V").Value.ToString(),
                            tamamlanan1.Bolum,
                            item.Cell("L").Value.ToString(),
                            item.Cell("M").Value.ToString(),
                            item.Cell("B").Value.ConDate(),
                            item.Cell("C").Value.ConDate(),
                            tamamlanan1.Gerekce,
                            item.Cell("I").Value.ToString(),
                            item.Cell("W").Value.ToString(),
                            tamamlanan1.Harcamaturu,
                            item.Cell("R").Value.ToString(),
                            item.Cell("S").Value.ToString(),
                            item.Cell("T").Value.ConDate(),
                            //item.Cell("W").Value.ConTime(), // BELGE TARİHİ
                            item.Cell("Z").Value.ToString(),
                            item.Cell("AA").Value.ToString(),
                            item.Cell("AB").Value.ToString(),
                            item.Cell("U").Value.ConDouble(),
                            tamamlanan1.Dosyayolu,
                            tamamlanan1.Siparisno,
                            tamamlanan1.Ucteklif,
                            item.Cell("G").Value.ToString(),
                            donem,
                            tamamlanan1.SatOlusturmaTuru,
                            item.Cell("K").Value.ToString(),
                            item.Cell("Q").Value.ToString(),
                            item.Cell("X").Value.ToString(),
                            item.Cell("O").Value.ToString(),
                            item.Cell("P").Value.ToString(),
                            item.Cell("C").Value.ToString(),
                            item.Cell("C").Value.ConDate(),
                            item.Cell("C").Value.ConDate(),
                            item.Cell("C").Value.ConDate(),
                            item.Cell("C").Value.ConDate(),
                            item.Cell("C").Value.ConDate(),
                            item.Cell("H").Value.ToString(),
                            item.Cell("AE").Value.ToString(),// MALİYET TÜRÜ
                            item.Cell("AC").Value.ToString(),
                            item.Cell("AD").Value.ToString(),
                            item.Cell("J").Value.ToString());
                        list.Add(tamamlanan);


                        tamamlananManager.Add(tamamlanan);
                        satir++;

                        tamamlanan1 = null;
                    }
                }
                catch (Exception ex)
                {
                    int satirdegeri = satir;
                    string sat = item.Cell("E").Value.ToString();
                    string a = ex.Message;
                }
            }
            MessageBox.Show("Bitti");

            #endregion
        }

        private void BBF1_TextChanged(object sender, EventArgs e)
        {
            BT1.Text = TopFiyatHesapla(BBF1.Text, m1.Text);
        }

        private void BBF2_TextChanged(object sender, EventArgs e)
        {
            BT2.Text = TopFiyatHesapla(BBF2.Text, m2.Text);
        }

        private void BBF3_TextChanged(object sender, EventArgs e)
        {
            BT3.Text = TopFiyatHesapla(BBF3.Text, m3.Text);
        }

        private void BBF4_TextChanged(object sender, EventArgs e)
        {
            BT4.Text = TopFiyatHesapla(BBF4.Text, m4.Text);
        }

        private void BBF5_TextChanged(object sender, EventArgs e)
        {
            BT5.Text = TopFiyatHesapla(BBF5.Text, m5.Text);
        }

        private void BBF6_TextChanged(object sender, EventArgs e)
        {
            BT6.Text = TopFiyatHesapla(BBF6.Text, m6.Text);
        }

        private void BBF7_TextChanged(object sender, EventArgs e)
        {
            BT7.Text = TopFiyatHesapla(BBF7.Text, m7.Text);
        }

        private void BBF8_TextChanged(object sender, EventArgs e)
        {
            BT8.Text = TopFiyatHesapla(BBF8.Text, m8.Text);
        }

        private void BBF9_TextChanged(object sender, EventArgs e)
        {
            BT9.Text = TopFiyatHesapla(BBF9.Text, m9.Text);
        }

        private void BBF10_TextChanged(object sender, EventArgs e)
        {
            BT10.Text = TopFiyatHesapla(BBF10.Text, m10.Text);
        }

        private void BT10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtGenelTop_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void FillTools()
        {

            Temizle();

            if (tamamlananMalzemes == null)

            {
                return;
            }
            if (tamamlananMalzemes.Count == 0)
            {
                return;
            }
            if (tamamlananMalzemes.Count > 0)
            {
                TamamlananMalzeme item = tamamlananMalzemes[0];
                stn1.Text = item.Stokno;
                t1.Text = item.Tanim;
                m1.Text = item.Miktar.ToString();
                b1.Text = item.Birim;
                F1_1.Text = item.Firma;
                BBF1.Text = item.Birimfiyat.ToString();
                BT1.Text = item.Toplamfiyat.ToString();
            }
            if (tamamlananMalzemes.Count > 1)
            {
                TamamlananMalzeme item = tamamlananMalzemes[1];
                stn2.Text = item.Stokno;
                t2.Text = item.Tanim;
                m2.Text = item.Miktar.ToString();
                b2.Text = item.Birim;
                F1_2.Text = item.Firma;
                BBF2.Text = item.Birimfiyat.ToString();
                BT2.Text = item.Toplamfiyat.ToString();
            }
            if (tamamlananMalzemes.Count > 2)
            {
                TamamlananMalzeme item = tamamlananMalzemes[2];
                stn3.Text = item.Stokno;
                t3.Text = item.Tanim;
                m3.Text = item.Miktar.ToString();
                b3.Text = item.Birim;
                F1_3.Text = item.Firma;
                BBF3.Text = item.Birimfiyat.ToString();
                BT3.Text = item.Toplamfiyat.ToString();
            }
            if (tamamlananMalzemes.Count > 3)
            {
                TamamlananMalzeme item = tamamlananMalzemes[3];
                stn4.Text = item.Stokno;
                t4.Text = item.Tanim;
                m4.Text = item.Miktar.ToString();
                b4.Text = item.Birim;
                F1_4.Text = item.Firma;
                BBF4.Text = item.Birimfiyat.ToString();
                BT4.Text = item.Toplamfiyat.ToString();
            }
            if (tamamlananMalzemes.Count > 4)
            {
                TamamlananMalzeme item = tamamlananMalzemes[4];
                stn5.Text = item.Stokno;
                t5.Text = item.Tanim;
                m5.Text = item.Miktar.ToString();
                b5.Text = item.Birim;
                F1_5.Text = item.Firma;
                BBF5.Text = item.Birimfiyat.ToString();
                BT5.Text = item.Toplamfiyat.ToString();
            }
            if (tamamlananMalzemes.Count > 5)
            {
                TamamlananMalzeme item = tamamlananMalzemes[5];
                stn6.Text = item.Stokno;
                t6.Text = item.Tanim;
                m6.Text = item.Miktar.ToString();
                b6.Text = item.Birim;
                F1_6.Text = item.Firma;
                BBF6.Text = item.Birimfiyat.ToString();
                BT6.Text = item.Toplamfiyat.ToString();
            }
            if (tamamlananMalzemes.Count > 6)
            {
                TamamlananMalzeme item = tamamlananMalzemes[6];
                stn7.Text = item.Stokno;
                t7.Text = item.Tanim;
                m7.Text = item.Miktar.ToString();
                b7.Text = item.Birim;
                F1_7.Text = item.Firma;
                BBF7.Text = item.Birimfiyat.ToString();
                BT7.Text = item.Toplamfiyat.ToString();
            }
            if (tamamlananMalzemes.Count > 7)
            {
                TamamlananMalzeme item = tamamlananMalzemes[7];
                stn8.Text = item.Stokno;
                t8.Text = item.Tanim;
                m8.Text = item.Miktar.ToString();
                b8.Text = item.Birim;
                F1_8.Text = item.Firma;
                BBF8.Text = item.Birimfiyat.ToString();
                BT8.Text = item.Toplamfiyat.ToString();
            }
            if (tamamlananMalzemes.Count > 8)
            {
                TamamlananMalzeme item = tamamlananMalzemes[8];
                stn9.Text = item.Stokno;
                t9.Text = item.Tanim;
                m9.Text = item.Miktar.ToString();
                b9.Text = item.Birim;
                F1_9.Text = item.Firma;
                BBF9.Text = item.Birimfiyat.ToString();
                BT9.Text = item.Toplamfiyat.ToString();
            }
            if (tamamlananMalzemes.Count > 9)
            {
                TamamlananMalzeme item = tamamlananMalzemes[9];
                stn10.Text = item.Stokno;
                t10.Text = item.Tanim;
                m10.Text = item.Miktar.ToString();
                b10.Text = item.Birim;
                F1_10.Text = item.Firma;
                BBF10.Text = item.Birimfiyat.ToString();
                BT10.Text = item.Toplamfiyat.ToString();
            }
        }
    }
}
