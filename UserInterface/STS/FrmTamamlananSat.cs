using Business;
using Business.Concreate;
using Business.Concreate.STS;
using ClosedXML.Excel;
using DataAccess.Concreate;
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

        ComboManager comboManager;
        string siparisNo="", dosyayolu, butceKodu;
        int ucteklif;
        double geneltoplam, harcananTutar;
        bool start = true;
        public FrmTamamlananSat()
        {
            InitializeComponent();
            tamamlananManager = TamamlananManager.GetInstance();
            tamamlananMalzemeManager = TamamlananMalzemeManager.GetInstance();
            satIslemAdimlarimanager = SatIslemAdimlariManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            satTalebiDoldurManager = SatTalebiDoldurManager.GetInstance();
        }

        private void FrmTamamlananSat_Load(object sender, EventArgs e)
        {
            TamamlananSatlar();
            ProjeKodu();
            TxtTop.Text = DtgTamamlananSatlar.RowCount.ToString();
            start = false;
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
        void TamamlananSatlar()
        {
            tamamlanans = tamamlananManager.GetList();
            dataBinder.DataSource = tamamlanans.ToDataTable();
            DtgTamamlananSatlar.DataSource = dataBinder;
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
            DtgTamamlananSatlar.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgTamamlananSatlar.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgTamamlananSatlar.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgTamamlananSatlar.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgTamamlananSatlar.Columns["Abfform"].HeaderText = "ABF FORM NO";
            DtgTamamlananSatlar.Columns["Istenentarih"].HeaderText = "İSTENEN TARİH";
            DtgTamamlananSatlar.Columns["Tamamlanantarih"].HeaderText = "TAMAMLANAN TARİH";
            DtgTamamlananSatlar.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgTamamlananSatlar.Columns["Butcekodukalemi"].HeaderText = "BÜTÇE KODU KALEMİ";
            DtgTamamlananSatlar.Columns["Satbirim"].HeaderText = "SAT BİRİM";
            DtgTamamlananSatlar.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgTamamlananSatlar.Columns["Belgeturu"].HeaderText = "BELGE TÜRÜ";
            DtgTamamlananSatlar.Columns["Belgenumarasi"].HeaderText = "BELGE NUMARASI";
            DtgTamamlananSatlar.Columns["Belgetarihi"].HeaderText = "BELGE TARİHİ";
            DtgTamamlananSatlar.Columns["Faturaedilecekfirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgTamamlananSatlar.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgTamamlananSatlar.Columns["Masrafyerino"].HeaderText = "i.K MASRAF YERİ NO";
            DtgTamamlananSatlar.Columns["Harcanantutar"].HeaderText = "HARCANAN TUTAR";
            DtgTamamlananSatlar.Columns["Dosyayolu"].Visible = false;
            DtgTamamlananSatlar.Columns["Siparisno"].Visible = false;
            DtgTamamlananSatlar.Columns["Ucteklif"].Visible = false;
            DtgTamamlananSatlar.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgTamamlananSatlar.Columns["Donem"].DisplayIndex = 3;
            DtgTamamlananSatlar.Columns["Donem"].HeaderText = "DÖNEM";
            DtgTamamlananSatlar.Columns["Proje"].HeaderText = "PROJE";

        }
        void PanelGenislet()
        {
            groupBox2.Visible = true;
            PnlKaydir.Location = new Point(917, 15);
            PnlTemsili.Location = new Point(751, 871);
        }
        void PanelDaralt()
        {
            groupBox2.Visible = true;
            PnlKaydir.Location = new Point(676, 15);
            PnlTemsili.Location = new Point(521, 867);
        }
        void PanelDaraltTemsili()
        {
            groupBox2.Visible = false;
            PnlTemsili.Location = new Point(10, 548);
        }
        string satOlusturmaTuru = "";
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
                            item.Cell("H").Value.ConTime(),
                            item.Cell("I").Value.ConTime(),
                            item.Cell("M").Value.ToString(),
                            item.Cell("N").Value.ToString() + "/" + item.Cell("O").Value.ToString(),
                            item.Cell("R").Value.ToString(),
                            item.Cell("S").Value.ToString(),
                            item.Cell("V").Value.ToString(),
                            item.Cell("X").Value.ToString(),
                            DateTime.TryParse(item.Cell("W").Value.ToString(), out outDate) ? item.Cell("W").Value.ConTime() : outDate,
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
                            item.Cell("AA").Value.ToString());
                        list.Add(tamamlanan);

                        if (outDate.ToString()== "1.01.0001 00:00:00")
                        {
                            tamamlanan.Belgetarihi = "31.12.1900 00:00:00".ConTime();
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
            CmbProjeKodu.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
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
