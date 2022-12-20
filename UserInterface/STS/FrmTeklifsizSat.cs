using Business.Concreate;
using Business.Concreate.STS;
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
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.STS
{
    public partial class FrmTeklifsizSat : Form
    {
        SatDataGridview1Manager satDataGridview1Manager;
        SatinAlinacakMalManager satinAlinacakMalManager;
        SatIslemAdimlariManager satIslemAdimlariManager;
        TeklifsizSatManager teklifsizSatManager;
        List<SatDataGridview1> satDatas;
        List<SatinAlinacakMalzemeler> satinAlinacakMalzemelers;
        TamamlananMalzemeManager tamamlananMalzemeManager;
        public object[] infos;
        string siparisNo, dosyayolu, satno, islemyapan, mesaj, kaynakdosyaismi, alinandosya, tamyol;
        int malzemesayisi = 0;
        double toplam, x1, x2, x3, x4, x5, x6, x7, x8, x9, x10 = 0, outValue = 0;
        public FrmTeklifsizSat()
        {
            InitializeComponent();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
            teklifsizSatManager = TeklifsizSatManager.GetInstance();
            tamamlananMalzemeManager = TamamlananMalzemeManager.GetInstance();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSatMalzemeler"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void FrmTeklifsizSat_Load(object sender, EventArgs e)
        {
            FillTools();
            TxtTop.Text = DtgSat.RowCount.ToString();
            islemyapan = infos[1].ToString();
        }
        public void YenilecekVeri()
        {
            FillTools();
            TxtTop.Text = DtgSat.RowCount.ToString();
            islemyapan = infos[1].ToString();
        }
        void FillTools()
        {
            int ucteklif = 0;
            satDatas = satDataGridview1Manager.TekifDurumListele("Alınmadı", "Onaylandı", ucteklif, "BELIRLENMEDI", "");
            binderSetRequest.DataSource = satDatas.ToDataTable();
            DtgSat.DataSource = binderSetRequest;
            DataDisplay();
            TxtGenelTop.Text = "0.00 ₺";
        }
        void DataDisplay()
        {
            DtgSat.Columns["Id"].Visible = false;
            DtgSat.Columns["Satno"].HeaderText = "SAT NO";
            DtgSat.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgSat.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgSat.Columns["Talepeden"].HeaderText = "İSTEKTE BULUNAN";
            DtgSat.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgSat.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgSat.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgSat.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgSat.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgSat.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgSat.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgSat.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgSat.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgSat.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgSat.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgSat.Columns["Uctekilf"].Visible = false;
            DtgSat.Columns["SiparisNo"].Visible = false;
            DtgSat.Columns["DosyaYolu"].Visible = false;
            DtgSat.Columns["PersonelId"].Visible = false;
            DtgSat.Columns["FirmaBilgisi"].Visible = false;
            DtgSat.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgSat.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgSat.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgSat.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgSat.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgSat.Columns["BelgeTuru"].Visible = false;
            DtgSat.Columns["BelgeNumarasi"].Visible = false;
            DtgSat.Columns["BelgeTarihi"].Visible = false;
            DtgSat.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
        }
        void DataGridDuzenle()
        {
            DtgSatIslemAdimlari.Columns["Id"].Visible = false;
            DtgSatIslemAdimlari.Columns["Siparisno"].Visible = false;
            DtgSatIslemAdimlari.Columns["Islem"].HeaderText = "İŞLEM ADIMI";
            DtgSatIslemAdimlari.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgSatIslemAdimlari.Columns["Tarih"].HeaderText = "TARİH";
            DtgSatIslemAdimlari.Columns["Tarih"].Width = 40;
            DtgSatIslemAdimlari.Columns["Islemyapan"].Width = 120;
            DtgSatIslemAdimlari.Columns["Islem"].Width = 400;
        }

        private void DtgSat_FilterStringChanged(object sender, EventArgs e)
        {
            binderSetRequest.Filter = DtgSat.FilterString;
            TxtTop.Text = DtgSat.RowCount.ToString();
        }

        private void DtgSat_SortStringChanged(object sender, EventArgs e)
        {
            binderSetRequest.Sort = DtgSat.SortString;
        }

        private void DtgSat_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgSat.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            siparisNo = DtgSat.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosyayolu = DtgSat.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            satno = DtgSat.CurrentRow.Cells["Satno"].Value.ToString();

            satinAlinacakMalzemelers = satinAlinacakMalManager.GetList(siparisNo);
            malzemesayisi = satinAlinacakMalzemelers.Count;

            TextBoxDoldur();
        }
        void Temizle()
        {
            s1.Clear(); tt1.Clear(); mm1.Clear(); bb1.Clear(); s2.Clear(); tt2.Clear(); mm2.Clear(); bb2.Clear();
            s3.Clear(); tt3.Clear(); mm3.Clear(); bb3.Clear(); s4.Clear(); tt4.Clear(); mm4.Clear(); bb4.Clear();
            s5.Clear(); tt5.Clear(); mm5.Clear(); bb5.Clear(); s6.Clear(); tt6.Clear(); mm6.Clear(); bb6.Clear();
            s7.Clear(); tt7.Clear(); mm7.Clear(); bb7.Clear(); s8.Clear(); tt8.Clear(); mm8.Clear(); bb8.Clear();
            s9.Clear(); tt9.Clear(); mm9.Clear(); bb9.Clear(); s10.Clear(); tt10.Clear(); mm10.Clear(); bb10.Clear();
            Tutar1.Clear(); Tutar2.Clear(); Tutar3.Clear(); Tutar4.Clear(); Tutar5.Clear(); Tutar6.Clear(); Tutar7.Clear();
            Tutar8.Clear(); Tutar9.Clear(); Tutar10.Clear();

        }
        void IslemAdimlari()
        {
            DtgSatIslemAdimlari.DataSource = satIslemAdimlariManager.GetList(siparisNo);
            DataGridDuzenle();
        }
        void TextBoxDoldur()
        {
            Temizle();
            if (satinAlinacakMalzemelers == null)

            {
                return;
            }

            if (satinAlinacakMalzemelers.Count == 0)
            {
                return;
            }

            if (satinAlinacakMalzemelers.Count > 0)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[0];
                s1.Text = item.Stn1;
                tt1.Text = item.T1;
                mm1.Text = item.M1.ToString();
                bb1.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 1)
            {
                SatinAlinacakMalzemeler item3 = satinAlinacakMalzemelers[1];
                s2.Text = item3.Stn1;
                tt2.Text = item3.T1;
                mm2.Text = item3.M1.ToString();
                bb2.Text = item3.B1;
            }

            if (satinAlinacakMalzemelers.Count > 2)
            {
                SatinAlinacakMalzemeler item3 = satinAlinacakMalzemelers[2];
                s3.Text = item3.Stn1;
                tt3.Text = item3.T1;
                mm3.Text = item3.M1.ToString();
                bb3.Text = item3.B1;
            }

            if (satinAlinacakMalzemelers.Count > 3)
            {
                SatinAlinacakMalzemeler item4 = satinAlinacakMalzemelers[3];
                s4.Text = item4.Stn1;
                tt4.Text = item4.T1;
                mm4.Text = item4.M1.ToString();
                bb4.Text = item4.B1;
            }

            if (satinAlinacakMalzemelers.Count > 4)
            {
                SatinAlinacakMalzemeler item5 = satinAlinacakMalzemelers[4];
                s5.Text = item5.Stn1;
                tt5.Text = item5.T1;
                mm5.Text = item5.M1.ToString();
                bb5.Text = item5.B1;
            }

            if (satinAlinacakMalzemelers.Count > 5)
            {


                SatinAlinacakMalzemeler item6 = satinAlinacakMalzemelers[5];
                s6.Text = item6.Stn1;
                tt6.Text = item6.T1;
                mm6.Text = item6.M1.ToString();
                bb6.Text = item6.B1;
            }

            if (satinAlinacakMalzemelers.Count > 6)
            {
                SatinAlinacakMalzemeler item7 = satinAlinacakMalzemelers[6];
                s7.Text = item7.Stn1;
                tt7.Text = item7.T1;
                mm7.Text = item7.M1.ToString();
                bb7.Text = item7.B1;
            }

            if (satinAlinacakMalzemelers.Count > 7)
            {

                SatinAlinacakMalzemeler item8 = satinAlinacakMalzemelers[7];
                s8.Text = item8.Stn1;
                tt8.Text = item8.T1;
                mm8.Text = item8.M1.ToString();
                bb8.Text = item8.B1;
            }

            if (satinAlinacakMalzemelers.Count > 8)
            {
                SatinAlinacakMalzemeler item9 = satinAlinacakMalzemelers[8];
                s9.Text = item9.Stn1;
                tt9.Text = item9.T1;
                mm9.Text = item9.M1.ToString();
                bb9.Text = item9.B1;
            }

            if (satinAlinacakMalzemelers.Count > 9)
            {
                SatinAlinacakMalzemeler item10 = satinAlinacakMalzemelers[9];
                s10.Text = item10.Stn1;
                tt10.Text = item10.T1;
                mm10.Text = item10.M1.ToString();
                bb10.Text = item10.B1;
            }
            WebBrowser();
            IslemAdimlari();
        }

        #region Keypress
        private void Tutar1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void Tutar2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void Tutar3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void Tutar4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void Tutar5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void Tutar6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void Tutar7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void Tutar8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void Tutar9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void Tutar10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
        private void s1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void s2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void s3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void s4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void s5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void s6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void s7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void s8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void s9_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void s10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt9_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void tt10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion
        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(dosyayolu))
            {
                MessageBox.Show("Dosya Yolu Bulunamadı.");
                return;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi = openFileDialog1.SafeFileName.ToString();
                alinandosya = openFileDialog1.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string dosyaismi = kaynakdosyaismi;
            tamyol = dosyayolu + "\\" + dosyaismi;
            if (File.Exists(dosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + dosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!File.Exists(tamyol))
                {
                    File.Copy(alinandosya, tamyol);
                }
                //BtnDosyaEkle.BackColor = Color.LightGreen;
            }
            WebBrowser();
        }
        #region TextChanged
        private void Tutar1_TextChanged(object sender, EventArgs e)
        {
            if (Tutar1.Text == "")
            {
                x1 = 0;
                Hesapla();
                return;
            }
            x1 = double.TryParse(Tutar1.Text, out outValue) ? Convert.ToDouble(Tutar1.Text) : 0;
            Hesapla();
        }

        private void Tutar2_TextChanged(object sender, EventArgs e)
        {
            if (Tutar2.Text == "")
            {
                x2 = 0;
                Hesapla();
                return;
            }
            x2 = double.TryParse(Tutar2.Text, out outValue) ? Convert.ToDouble(Tutar2.Text) : 0;
            Hesapla();
        }

        private void Tutar3_TextChanged(object sender, EventArgs e)
        {
            if (Tutar3.Text == "")
            {
                x3 = 0;
                Hesapla();
                return;
            }
            x3 = double.TryParse(Tutar3.Text, out outValue) ? Convert.ToDouble(Tutar3.Text) : 0;
            Hesapla();
        }

        private void Tutar4_TextChanged(object sender, EventArgs e)
        {
            if (Tutar4.Text == "")
            {
                Tutar4.Text = "0";
                Hesapla();
                return;
            }
            x4 = double.TryParse(Tutar4.Text, out outValue) ? Convert.ToDouble(Tutar4.Text) : 0;
            Hesapla();
        }
        private void Tutar5_TextChanged(object sender, EventArgs e)
        {
            if (Tutar5.Text == "")
            {
                x5 = 0;
                Hesapla();
                return;
            }
            x5 = double.TryParse(Tutar5.Text, out outValue) ? Convert.ToDouble(Tutar5.Text) : 0;
            Hesapla();
        }

        private void Tutar6_TextChanged(object sender, EventArgs e)
        {
            if (Tutar6.Text == "")
            {
                x6 = 0;
                Hesapla();
                return;
            }
            x6 = double.TryParse(Tutar6.Text, out outValue) ? Convert.ToDouble(Tutar6.Text) : 0;
            Hesapla();
        }

        private void Tutar7_TextChanged(object sender, EventArgs e)
        {
            if (Tutar7.Text == "")
            {
                x7 = 0;
                Hesapla();
                return;
            }
            x7 = double.TryParse(Tutar7.Text, out outValue) ? Convert.ToDouble(Tutar7.Text) : 0;
            Hesapla();
        }

        private void Tutar8_TextChanged(object sender, EventArgs e)
        {
            if (Tutar8.Text == "")
            {
                x8 = 0;
                Hesapla();
                return;
            }
            x8 = double.TryParse(Tutar8.Text, out outValue) ? Convert.ToDouble(Tutar8.Text) : 0;
            Hesapla();
        }

        private void Tutar9_TextChanged(object sender, EventArgs e)
        {
            if (Tutar9.Text == "")
            {
                x9 = 0;
                Hesapla();
                return;
            }
            x9 = double.TryParse(Tutar9.Text, out outValue) ? Convert.ToDouble(Tutar9.Text) : 0;
            Hesapla();
        }

        private void Tutar10_TextChanged(object sender, EventArgs e)
        {
            if (Tutar10.Text == "")
            {
                x10 = 0;
                Hesapla();
                return;
            }
            x10 = double.TryParse(Tutar10.Text, out outValue) ? Convert.ToDouble(Tutar10.Text) : 0;
            Hesapla();
        }
        #endregion

        void Hesapla()
        {
            toplam = x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9 + x10;
            TxtGenelTop.Text = toplam.ToString("0.00") + " ₺";
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Kaydetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }

            string control = TextBoxControl();
            if (control == "")
            {
                return;
            }
            /*if (BtnDosyaEkle.BackColor != Color.LightGreen)
            {
                MessageBox.Show("Lütfen Harcama Tutarlarınıza Ait Fatura Vb. Dosyanızı Ekleyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            List<TeklifsizSat> list = new List<TeklifsizSat>();
            if (s1.Text != "")
            {
                TeklifsizSat teklifsizSat = new TeklifsizSat(s1.Text, tt1.Text, mm1.Text.ConDouble(), bb1.Text, Tutar1.Text.ConDouble(), siparisNo);
                list.Add(teklifsizSat);
            }
            if (s2.Text != "")
            {
                TeklifsizSat teklifsizSat = new TeklifsizSat(s2.Text, tt2.Text, mm2.Text.ConDouble(), bb2.Text, Tutar2.Text.ConDouble(), siparisNo);
                list.Add(teklifsizSat);
            }
            if (s3.Text != "")
            {
                TeklifsizSat teklifsizSat = new TeklifsizSat(s3.Text, tt3.Text, mm3.Text.ConDouble(), bb3.Text, Tutar3.Text.ConDouble(), siparisNo);
                list.Add(teklifsizSat);
            }
            if (s4.Text != "")
            {
                TeklifsizSat teklifsizSat = new TeklifsizSat(s4.Text, tt3.Text, mm4.Text.ConDouble(), bb4.Text, Tutar4.Text.ConDouble(), siparisNo);
                list.Add(teklifsizSat);
            }
            if (s5.Text != "")
            {
                TeklifsizSat teklifsizSat = new TeklifsizSat(s5.Text, tt5.Text, mm5.Text.ConDouble(), bb5.Text, Tutar5.Text.ConDouble(), siparisNo);
                list.Add(teklifsizSat);
            }
            if (s6.Text != "")
            {
                TeklifsizSat teklifsizSat = new TeklifsizSat(s6.Text, tt6.Text, mm6.Text.ConDouble(), bb6.Text, Tutar6.Text.ConDouble(), siparisNo);
                list.Add(teklifsizSat);
            }
            if (s7.Text != "")
            {
                TeklifsizSat teklifsizSat = new TeklifsizSat(s7.Text, tt7.Text, mm7.Text.ConDouble(), bb7.Text, Tutar7.Text.ConDouble(), siparisNo);
                list.Add(teklifsizSat);
            }
            if (s8.Text != "")
            {
                TeklifsizSat teklifsizSat = new TeklifsizSat(s8.Text, tt8.Text, mm8.Text.ConDouble(), bb8.Text, Tutar8.Text.ConDouble(), siparisNo);
                list.Add(teklifsizSat);
            }
            if (s9.Text != "")
            {
                TeklifsizSat teklifsizSat = new TeklifsizSat(s9.Text, tt9.Text, mm9.Text.ConDouble(), bb9.Text, Tutar9.Text.ConDouble(), siparisNo);
                list.Add(teklifsizSat);
            }
            if (s10.Text != "")
            {
                TeklifsizSat teklifsizSat = new TeklifsizSat(s10.Text, tt10.Text, mm10.Text.ConDouble(), bb10.Text, Tutar10.Text.ConDouble(), siparisNo);
                list.Add(teklifsizSat);
            }
            if (list.Count == 0)
            {
                MessageBox.Show("Eleman Bulunamadı");
                return;
            }

            /*foreach (TamamlananMalzeme item in list)
            {
                mesaj = tamamlananMalzemeManager.Add(item);
            }*/
            foreach (TeklifsizSat item in list)
            {
                mesaj = teklifsizSatManager.Add(item);
            }

            satDataGridview1Manager.TeklifDurum(siparisNo, dosyayolu, "");

            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj);
            }
            else
            {
                string islem = "TOPLAM TUTAR BİLGİLERİ KAYDEDİLDİ.";

                SatIslemAdimlari dtgSat = new SatIslemAdimlari(siparisNo, islem, islemyapan, DateTime.Now);
                satIslemAdimlariManager.Add(dtgSat);

                MessageBox.Show(satno + " Numaralı SAT Başarıyla SAT ONAY Aşamasına İletilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillTools();
                Temizle();
                //Task.Factory.StartNew(() => MailSendMetot());
                TxtTop.Text = DtgSat.RowCount.ToString();
                webBrowser1.Navigate("");
                BtnDosyaEkle.BackColor = Color.Transparent;
            }

        }
        string TextBoxControl()
        {
            if (malzemesayisi == 0)
            {
                return "";
            }
            if (malzemesayisi > 0)
            {
                if (Tutar1.Text == "")
                {
                    MessageBox.Show("1. Malzemenin Harcanan Tutarını Girmediniz.");
                    return "";
                }
            }
            if (malzemesayisi > 1)
            {
                if (Tutar2.Text == "")
                {
                    MessageBox.Show("2. Malzemenin Harcanan Tutarını Girmediniz.");
                    return "";
                }
            }
            if (malzemesayisi > 2)
            {
                if (Tutar3.Text == "")
                {
                    MessageBox.Show("3. Malzemenin Harcanan Tutarını Girmediniz.");
                    return "";
                }
            }
            if (malzemesayisi > 3)
            {
                if (Tutar4.Text == "")
                {
                    MessageBox.Show("4. Malzemenin Harcanan Tutarını Girmediniz.");
                    return "";
                }
            }
            if (malzemesayisi > 4)
            {
                if (Tutar5.Text == "")
                {
                    MessageBox.Show("5. Malzemenin Harcanan Tutarını Girmediniz.");
                    return "";
                }
            }
            if (malzemesayisi > 5)
            {
                if (Tutar6.Text == "")
                {
                    MessageBox.Show("6. Malzemenin Harcanan Tutarını Girmediniz.");
                    return "";
                }
            }
            if (malzemesayisi > 6)
            {
                if (Tutar7.Text == "")
                {
                    MessageBox.Show("7. Malzemenin Harcanan Tutarını Girmediniz.");
                    return "";
                }
            }
            if (malzemesayisi > 7)
            {
                if (Tutar8.Text == "")
                {
                    MessageBox.Show("8. Malzemenin Harcanan Tutarını Girmediniz.");
                    return "";
                }
            }
            if (malzemesayisi > 8)
            {
                if (Tutar9.Text == "")
                {
                    MessageBox.Show("9. Malzemenin Harcanan Tutarını Girmediniz.");
                    return "";
                }
            }
            if (malzemesayisi > 9)
            {
                if (Tutar10.Text == "")
                {
                    MessageBox.Show("10. Malzemenin Harcanan Tutarını Girmediniz.");
                    return "";
                }
            }
            return "OK";
        }
        void WebBrowser()
        {
            webBrowser1.Navigate(dosyayolu);
        }
        public void MailSend(string subject, string body, List<string> receivers, List<string> attachments = null)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                //client.Host = "smtp.gmail.com";
                client.Host = "192.168.23.10";
                //client.Host = "smtp-mail.outlook.com ";
                client.EnableSsl = false;
                client.Timeout = 11000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //client.Credentials = new System.Net.NetworkCredential("mubotomasyon@gmail.com", "MCHT44aa:");
                client.Credentials = new System.Net.NetworkCredential("dts@mubvan.net", "123456");
                //client.Credentials = new System.Net.NetworkCredential("mucahitaydemir@basaranteknoloji.net", "Aydemir_123");
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("dts@mubvan.net", "DTS Bilgilendirme");
                mailMessage.SubjectEncoding = Encoding.UTF8;
                mailMessage.Subject = subject; //E-posta Konu Kısmı
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.Body = body; // E-posta'nın Gövde Metni
                foreach (string item in receivers)
                {
                    mailMessage.To.Add(item);
                }
                mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                if (attachments != null)
                {
                    if (attachments.Count > 0)
                    {
                        foreach (string filePath in attachments)
                        {
                            if (File.Exists(filePath))
                            {
                                Attachment attachment = new Attachment(filePath);
                                mailMessage.Attachments.Add(attachment);
                            }
                        }
                    }
                }
                client.Send(mailMessage);
            }
            catch (Exception)
            {
                //  MessageBox.Show(ex.Message);
            }
        }
        void MailSendMetot()
        {
            MailSend("Teklifsiz SAT İşlemi ", "Merhaba; \n\n" + satno + " Numaralı SAT Kaydı, Teklifsiz Sat Aşamasında" + islemyapan +
                " tarafından Tutarları Girilerek Kaydedilmiştir.\n\nİyi Çalışmalar.", new List<string>() { "resulgunes@mubvan.net" });
        }
    }
}
