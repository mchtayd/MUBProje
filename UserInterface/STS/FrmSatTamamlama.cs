using Business;
using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.Butce;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using DataAccess.Concreate.STS;
using Entity;
using Entity.IdariIsler;
using Entity.STS;
using Microsoft.Office.Interop.Word;
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
using Application = Microsoft.Office.Interop.Word.Application;
using Point = System.Drawing.Point;

namespace UserInterface.STS
{
    public partial class FrmSatTamamlama : Form
    {
        List<SatDataGridview1> satDatas;
        List<Tamamlanan> tamamlanans;
        List<FiyatTeklifiAl> fiyatTeklifiAls;
        List<TeklifsizSat> teklifsizs;
        SatDataGridview1Manager satDataGridview1Manager;
        FiyatTeklifiAlManager fiyatTeklifiAlManager;
        TeklifsizSatManager telifsizSatManager;
        TamamlananManager tamamlananManager;
        TamamlananMalzemeManager tamamlananMalzemeManager;
        SatinAlinacakMalManager satinAlinacakMalManager;
        SatIslemAdimlariManager satIslemAdimlarimanager;
        PersonelKayitManager personelKayitManager;
        SatOnayTarihiManager satOnayTarihiManager;
        ComboManager comboManager;
        SatTalebiDoldurManager satTalebiDoldurManager;
        TedarikciFirmaManager tedarikciFirmaManager;
        TeklifFirmalarManager teklifFirmalarManager;
        KasaDurumManager kasaDurumManager;
        BolgeKayitManager bolgeKayitManager;

        List<string> supplierNames;
        public object[] infos;
        string siparisNo, dosyayolu;
        int onaylananteklif, ucteklif,id, formno, satno=-1,malzemesayisi;
        double toplam, x1, x2, x3, x4, x5, x6, x7, x8, x9, x10 = 0, outValue = 0;
        string masrafyeri, talepeden, bolum, usbolgesi, abfformno, gerekce, butcekodukalemi, satbirim, harcamaturu, faturafirma, ilgilikisi, masrafyerino, firma, kaynakdosyaismi, alinandosya, tamyol, belgeTuru, satinAlinanFirma, yapilanislem, islemyapan;

        #region Keypress
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
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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
            e.Handled = true;
        }

        private void BT2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtGenelTop_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion
        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplay();
            TxtTop.Text = DtgSatTamamlama.RowCount.ToString();
        }

        DateTime istenentarih, tamamlanantarih;

        private void BtnSatiGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Güncellemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (projeBilgisi=="")
                {
                    MessageBox.Show("Lütfen Öncelikle Proje Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string mesaj = satDataGridview1Manager.SatFirmaGuncelle(siparisNo, projeBilgisi, TxtFirma.Text);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtFirma.Clear();
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

        public FrmSatTamamlama()
        {
            InitializeComponent();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            fiyatTeklifiAlManager = FiyatTeklifiAlManager.GetInstance();
            telifsizSatManager = TeklifsizSatManager.GetInstance();
            tamamlananManager = TamamlananManager.GetInstance();
            tamamlananMalzemeManager = TamamlananMalzemeManager.GetInstance();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            satIslemAdimlarimanager = SatIslemAdimlariManager.GetInstance();
            personelKayitManager = PersonelKayitManager.GetInstance();
            satOnayTarihiManager = SatOnayTarihiManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            satTalebiDoldurManager = SatTalebiDoldurManager.GetInstance();
            tedarikciFirmaManager = TedarikciFirmaManager.GetInstance();
            teklifFirmalarManager = TeklifFirmalarManager.GetInstance();
            kasaDurumManager = KasaDurumManager.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Guncellemek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (siparisNo == "")
                {
                    MessageBox.Show("Lütfen Geçerli Bir Sat Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                if (CmbDonem.Text!="" || CmbDonemYil.Text!="")
                {
                    string yeniDonem = CmbDonem.Text + " " + CmbDonemYil.Text;
                    if (donem!= yeniDonem)
                    {
                        satDataGridview1Manager.TamamlamaDonemGuncelle(siparisNo, yeniDonem);

                    }
                }
                /*string mesaj = satDataGridview1Manager.SatFirmaGuncelle(siparisNo, projeBilgisi, TxtFirma.Text);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/
               

                MalzemeGuncelle();

                yapilanislem = "SAT FİYAT TEKLİFLERİ GÜNCELLENDİ.";
                islemyapan = infos[1].ToString();
                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, islemyapan, DateTime.Now);
                satIslemAdimlarimanager.Add(satIslemAdimlari);

                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataDisplay();
                Temizle();
            }
        }
        void TamamlananSatlar()
        {
            tamamlanans = tamamlananManager.GetList(0);
            
            dataBinder.DataSource = tamamlanans.ToDataTable();
            DtgSatTamamlama.DataSource = dataBinder;
            DataDisplay();
            Toplamlar();
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgSatTamamlama.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgSatTamamlama.Rows[i].Cells[17].Value);
            }
            TxtGenelTop.Text = toplam.ToString();
        }
        void CmbDuzenle(params ComboBox[] cmbArray)
        {
            foreach (ComboBox item in cmbArray)
            {
                item.DataSource = supplierNames.Select(x => x).ToList();
                //item.SelectedIndex = -1;
            }
        }
        void CmbClearDataSource(params ComboBox[] cmbArray)
        {
            foreach (ComboBox item in cmbArray)
            {
                item.DataSource = null;
            }
        }
        void TedarikciFirmaName()
        {
            List<TeklifFirmalar> supplierList = teklifFirmalarManager.TedarikciFirmalar(false);
            supplierNames = supplierList.Select(x => x.Firmaname).ToList();

            //CmbClearDataSource(F1_1, F1_2, F1_3, F1_4, F1_5, F1_6, F1_7, F1_8, F1_9, F1_10);

            if (malzemesayisi > 0)
            {
                CmbDuzenle(F1_1);
            }
            if (malzemesayisi > 1)
            {
                CmbDuzenle(F1_2);
            }
            if (malzemesayisi > 2)
            {
                CmbDuzenle(F1_3);
            }
            if (malzemesayisi > 3)
            {
                CmbDuzenle(F1_4);
            }
            if (malzemesayisi > 4)
            {
                CmbDuzenle(F1_5);
            }
            if (malzemesayisi > 5)
            {
                CmbDuzenle(F1_6);
            }
            if (malzemesayisi > 6)
            {
                CmbDuzenle(F1_7);
            }
            if (malzemesayisi > 7)
            {
                CmbDuzenle(F1_8);
            }
            if (malzemesayisi > 8)
            {
                CmbDuzenle(F1_9);
            }
            if (malzemesayisi > 9)
            {
                CmbDuzenle(F1_10);
            }
        }

        void MalzemeGuncelle()
        {

            if (stn1.Text != "")
            {
                FiyatTeklifiAl tamamlananMalzeme = new FiyatTeklifiAl(id1,stn1.Text, t1.Text, m1.Text.ConInt(), b1.Text, F1_1.Text, BBF1.Text.ConDouble(), BT1.Text.ConDouble());
                fiyatTeklifiAlManager.Update(tamamlananMalzeme,onaylananteklif);
            }
            if (stn2.Text != "")
            {
                FiyatTeklifiAl tamamlananMalzeme = new FiyatTeklifiAl(id2, stn2.Text, t2.Text, m2.Text.ConInt(), b2.Text, F1_2.Text, BBF2.Text.ConDouble(), BT2.Text.ConDouble());
                fiyatTeklifiAlManager.Update(tamamlananMalzeme, onaylananteklif);
            }
            if (stn3.Text != "")
            {
                FiyatTeklifiAl tamamlananMalzeme = new FiyatTeklifiAl(id3, stn3.Text, t3.Text, m3.Text.ConInt(), b3.Text, F1_3.Text, BBF3.Text.ConDouble(), BT3.Text.ConDouble());
                fiyatTeklifiAlManager.Update(tamamlananMalzeme, onaylananteklif);
            }
            if (stn4.Text != "")
            {
                FiyatTeklifiAl tamamlananMalzeme = new FiyatTeklifiAl(id4, stn4.Text, t4.Text, m4.Text.ConInt(), b4.Text, F1_4.Text, BBF4.Text.ConDouble(), BT4.Text.ConDouble());
                fiyatTeklifiAlManager.Update(tamamlananMalzeme, onaylananteklif);
            }
            if (stn5.Text != "")
            {
                FiyatTeklifiAl tamamlananMalzeme = new FiyatTeklifiAl(id5, stn5.Text, t5.Text, m5.Text.ConInt(), b5.Text, F1_5.Text, BBF5.Text.ConDouble(), BT5.Text.ConDouble());
                fiyatTeklifiAlManager.Update(tamamlananMalzeme, onaylananteklif);
            }
            if (stn6.Text != "")
            {
                FiyatTeklifiAl tamamlananMalzeme = new FiyatTeklifiAl(id6, stn6.Text, t6.Text, m6.Text.ConInt(), b6.Text, F1_6.Text, BBF6.Text.ConDouble(), BT6.Text.ConDouble());
                fiyatTeklifiAlManager.Update(tamamlananMalzeme, onaylananteklif);
            }
            if (stn7.Text != "")
            {
                FiyatTeklifiAl tamamlananMalzeme = new FiyatTeklifiAl(id7, stn7.Text, t7.Text, m7.Text.ConInt(), b7.Text, F1_7.Text, BBF7.Text.ConDouble(), BT7.Text.ConDouble());
                fiyatTeklifiAlManager.Update(tamamlananMalzeme, onaylananteklif);
            }
            if (stn8.Text != "")
            {
                FiyatTeklifiAl tamamlananMalzeme = new FiyatTeklifiAl(id8, stn8.Text, t8.Text, m8.Text.ConInt(), b8.Text, F1_8.Text, BBF8.Text.ConDouble(), BT8.Text.ConDouble());
                fiyatTeklifiAlManager.Update(tamamlananMalzeme, onaylananteklif);
            }
            if (stn9.Text != "")
            {
                FiyatTeklifiAl tamamlananMalzeme = new FiyatTeklifiAl(id9, stn9.Text, t9.Text, m9.Text.ConInt(), b9.Text, F1_9.Text, BBF9.Text.ConDouble(), BT9.Text.ConDouble());
                fiyatTeklifiAlManager.Update(tamamlananMalzeme, onaylananteklif);
            }
            if (stn10.Text != "")
            {
                FiyatTeklifiAl tamamlananMalzeme = new FiyatTeklifiAl(id10, stn10.Text, t10.Text, m10.Text.ConInt(), b10.Text, F1_10.Text, BBF10.Text.ConDouble(), BT10.Text.ConDouble());
                fiyatTeklifiAlManager.Update(tamamlananMalzeme, onaylananteklif);
            }
        }

        private void FrmSatTamamlama_Load(object sender, EventArgs e)
        {
            DataDisplay();
            ProjeKodu();
            TxtTop.Text = DtgSatTamamlama.RowCount.ToString();
        }
        public void YenilecekVeri()
        {
            DataDisplay();
            TxtTop.Text = DtgSatTamamlama.RowCount.ToString();
        }
        void DataDisplay()
        {
            satDatas = satDataGridview1Manager.SatTamamlamaListele();
            dataBinder.DataSource = satDatas.ToDataTable();
            DtgSatTamamlama.DataSource = dataBinder;

            DtgSatTamamlama.Columns["Id"].Visible = false;
            DtgSatTamamlama.Columns["Satno"].HeaderText = "SAT NO";
            DtgSatTamamlama.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgSatTamamlama.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgSatTamamlama.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgSatTamamlama.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgSatTamamlama.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgSatTamamlama.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgSatTamamlama.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgSatTamamlama.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgSatTamamlama.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgSatTamamlama.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgSatTamamlama.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgSatTamamlama.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgSatTamamlama.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgSatTamamlama.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgSatTamamlama.Columns["Uctekilf"].Visible = false;
            DtgSatTamamlama.Columns["SiparisNo"].Visible = false;
            DtgSatTamamlama.Columns["DosyaYolu"].Visible = false;
            DtgSatTamamlama.Columns["PersonelId"].Visible = false;
            DtgSatTamamlama.Columns["FirmaBilgisi"].Visible = false;
            DtgSatTamamlama.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgSatTamamlama.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgSatTamamlama.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgSatTamamlama.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgSatTamamlama.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgSatTamamlama.Columns["SatinAlinanFirma"].HeaderText = "SATIN ALINAN FİRMA";
            DtgSatTamamlama.Columns["BelgeTuru"].Visible = false;
            DtgSatTamamlama.Columns["BelgeNumarasi"].Visible = false;
            DtgSatTamamlama.Columns["BelgeTarihi"].Visible = false;

            DtgSatTamamlama.Columns["SatOlusturmaTuru"].Visible = false;
            DtgSatTamamlama.Columns["RedNedeni"].Visible = false;
            DtgSatTamamlama.Columns["Durum"].Visible = false;
            DtgSatTamamlama.Columns["TeklifDurumu"].Visible = false;
            DtgSatTamamlama.Columns["Proje"].HeaderText = "PROJE";
            DtgSatTamamlama.Columns["MailSiniri"].Visible = false;
            DtgSatTamamlama.Columns["MailDurumu"].Visible = false;

            DtgSatTamamlama.Columns["Donem"].HeaderText = "DÖNEM";
            DtgSatTamamlama.Columns["Donem"].DisplayIndex = 3;
        }

        private void BBF2_TextChanged(object sender, EventArgs e)
        {
            BT2.Text = TopFiyatHesapla(BBF2.Text, m2.Text);
        }


        private void BBF1_TextChanged(object sender, EventArgs e)
        {
            BT1.Text = TopFiyatHesapla(BBF1.Text, m1.Text);
        }


        private void m1_TextChanged(object sender, EventArgs e)
        {
            BT1.Text = TopFiyatHesapla(BBF1.Text, m1.Text);
        }

        private void m2_TextChanged(object sender, EventArgs e)
        {
            BT2.Text = TopFiyatHesapla(BBF2.Text, m2.Text);
        }

        private void m3_TextChanged(object sender, EventArgs e)
        {
            BT3.Text = TopFiyatHesapla(BBF3.Text, m3.Text);
        }

        private void m4_TextChanged(object sender, EventArgs e)
        {
            BT4.Text = TopFiyatHesapla(BBF4.Text, m4.Text);
        }

        private void m5_TextChanged(object sender, EventArgs e)
        {
            BT5.Text = TopFiyatHesapla(BBF5.Text, m5.Text);
        }

        private void m6_TextChanged(object sender, EventArgs e)
        {
            BT6.Text = TopFiyatHesapla(BBF6.Text, m6.Text);
        }

        private void m7_TextChanged(object sender, EventArgs e)
        {
            BT7.Text = TopFiyatHesapla(BBF7.Text, m7.Text);
        }

        private void m8_TextChanged(object sender, EventArgs e)
        {
            BT8.Text = TopFiyatHesapla(BBF8.Text, m8.Text);
        }

        private void m9_TextChanged(object sender, EventArgs e)
        {
            BT9.Text = TopFiyatHesapla(BBF9.Text, m9.Text);
        }

        private void m10_TextChanged(object sender, EventArgs e)
        {
            BT10.Text = TopFiyatHesapla(BBF10.Text, m10.Text);
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

        void PanelGenislet()
        {
            PnlKaydir.Location = new Point(917, 15);
            LblGenelToplam.Location = new Point(825, 330);
            TxtGenelTop.Location = new Point(924, 326);
        }
        void PanelDaralt()
        {
            PnlKaydir.Location = new Point(676, 15);
            LblGenelToplam.Location = new Point(580, 330);
            TxtGenelTop.Location = new Point(680, 326);
        }
        string donem, satOlusturmaTuru;
        private void DtgSatTamamlama_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgSatTamamlama.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            
            id = DtgSatTamamlama.CurrentRow.Cells["Id"].Value.ConInt();
            siparisNo = DtgSatTamamlama.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosyayolu = DtgSatTamamlama.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            satno = DtgSatTamamlama.CurrentRow.Cells["Satno"].Value.ConInt();
            formno= DtgSatTamamlama.CurrentRow.Cells["Formno"].Value.ConInt();
            ucteklif = DtgSatTamamlama.CurrentRow.Cells["Uctekilf"].Value.ConInt();
            masrafyeri = DtgSatTamamlama.CurrentRow.Cells["Masrafyeri"].Value.ToString();
            talepeden = DtgSatTamamlama.CurrentRow.Cells["Talepeden"].Value.ToString();
            bolum = DtgSatTamamlama.CurrentRow.Cells["Bolum"].Value.ToString();
            usbolgesi = DtgSatTamamlama.CurrentRow.Cells["Usbolgesi"].Value.ToString();
            abfformno = DtgSatTamamlama.CurrentRow.Cells["Abfformno"].Value.ToString();
            istenentarih = DtgSatTamamlama.CurrentRow.Cells["Tarih"].Value.ConDate();
            gerekce = DtgSatTamamlama.CurrentRow.Cells["Gerekce"].Value.ToString();
            butcekodukalemi = DtgSatTamamlama.CurrentRow.Cells["Burcekodu"].Value.ToString();
            satbirim = DtgSatTamamlama.CurrentRow.Cells["Satbirim"].Value.ToString();
            harcamaturu = DtgSatTamamlama.CurrentRow.Cells["Harcamaturu"].Value.ToString();
            faturafirma = DtgSatTamamlama.CurrentRow.Cells["Faturafirma"].Value.ToString();
            ilgilikisi = DtgSatTamamlama.CurrentRow.Cells["Ilgilikisi"].Value.ToString();
            masrafyerino = DtgSatTamamlama.CurrentRow.Cells["Masyerino"].Value.ToString();
            belgeTuru = DtgSatTamamlama.CurrentRow.Cells["BelgeTuru"].Value.ToString();
            donem = DtgSatTamamlama.CurrentRow.Cells["Donem"].Value.ToString();
            satOlusturmaTuru = DtgSatTamamlama.CurrentRow.Cells["SatOlusturmaTuru"].Value.ToString();
            proje = DtgSatTamamlama.CurrentRow.Cells["Proje"].Value.ToString();
            
            satinAlinanFirma = DtgSatTamamlama.CurrentRow.Cells["SatinAlinanFirma"].Value.ToString();


            TedarikciFirmaName();
            WebBrowser();

            if (ucteklif == 1)
            {
                PanelGenislet();
                PnlGizle.Visible = true;
                MalzemeList();
                FillTools();
            }
            else
            {
                PanelDaralt();
                PnlGizle.Visible = false;
                TeklifsizMalzemeList();
                TeklifsizFillTools();
            }
            if (satbirim== "PRJ.DİR.SATIN ALMA")
            {
                CmbHarcamaYapan.SelectedIndex = 0;
            }
            if (satbirim == "BSRN GN.MDL.SATIN ALMA")
            {
                CmbHarcamaYapan.SelectedIndex = 1;
            }
            
            SatTalebiDoldur satTalebiDoldur = satTalebiDoldurManager.Get(usbolgesi);

            if (satTalebiDoldur == null)
            {
                CmbProjeKodu.Visible = true;
                TxtProje.Visible = false;
                projeBilgisi = CmbProjeKodu.Text;
                return;
            }
            CmbProjeKodu.Visible = false;
            TxtProje.Visible = true;
            projeBilgisi = satTalebiDoldur.Proje;
            TxtProje.Text = projeBilgisi;
        }
        string projeBilgisi = "";
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
            if (File.Exists(tamyol))
            {
                MessageBox.Show("Belirtilen Klasörde " + dosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, tamyol);
                BtnDosyaEkle.BackColor = Color.LightGreen;
            }
        }
        void MalzemeList()
        {
            fiyatTeklifiAls = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);
            malzemesayisi = fiyatTeklifiAls.Count;
        }
        void TeklifsizMalzemeList()
        {
            teklifsizs = telifsizSatManager.GetList(siparisNo);
        }
        int id1, id2, id3, id4, id5, id6, id7, id8, id9, id10;
        void TeklifsizFillTools()
        {
            Temizle();

            if (teklifsizs == null)
            {
                return;
            }
            if (teklifsizs.Count == 0)
            {
                return;
            }
            if (belgeTuru!="")
            {
                TeklifsizSat item = teklifsizs[0];
                TxtGenelTop.Text = item.Tutar.ToString();
                return;
            }
            if (teklifsizs.Count > 0)
            {
                TeklifsizSat item = teklifsizs[0];
                id1 = item.Id;
                stn1.Text = item.Stokno;
                t1.Text = item.Tanim;
                m1.Text = item.Miktar.ToString();
                b1.Text = item.Birim;
                BT1.Text = item.Tutar.ToString();
            }
            if (teklifsizs.Count > 1)
            {
                TeklifsizSat item = teklifsizs[1];
                id2 = item.Id;
                stn2.Text = item.Stokno;
                t2.Text = item.Tanim;
                m2.Text = item.Miktar.ToString();
                b2.Text = item.Birim;
                BT2.Text = item.Tutar.ToString();
            }
            if (teklifsizs.Count > 2)
            {
                TeklifsizSat item = teklifsizs[2];
                id3 = item.Id;
                stn3.Text = item.Stokno;
                t3.Text = item.Tanim;
                m3.Text = item.Miktar.ToString();
                b3.Text = item.Birim;
                BT3.Text = item.Tutar.ToString();
            }
            if (teklifsizs.Count > 3)
            {
                TeklifsizSat item = teklifsizs[3];
                id4 = item.Id;
                stn4.Text = item.Stokno;
                t4.Text = item.Tanim;
                m4.Text = item.Miktar.ToString();
                b4.Text = item.Birim;
                BT4.Text = item.Tutar.ToString();
            }
            if (teklifsizs.Count > 4)
            {
                TeklifsizSat item = teklifsizs[4];
                id5 = item.Id;
                stn5.Text = item.Stokno;
                t5.Text = item.Tanim;
                m5.Text = item.Miktar.ToString();
                b5.Text = item.Birim;
                BT5.Text = item.Tutar.ToString();
            }
            if (teklifsizs.Count > 5)
            {
                TeklifsizSat item = teklifsizs[5];
                id6 = item.Id;
                stn6.Text = item.Stokno;
                t6.Text = item.Tanim;
                m6.Text = item.Miktar.ToString();
                b6.Text = item.Birim;
                BT6.Text = item.Tutar.ToString();
            }
            if (teklifsizs.Count > 6)
            {
                TeklifsizSat item = teklifsizs[6];
                id7 = item.Id;
                stn7.Text = item.Stokno;
                t7.Text = item.Tanim;
                m7.Text = item.Miktar.ToString();
                b7.Text = item.Birim;
                BT7.Text = item.Tutar.ToString();
            }
            if (teklifsizs.Count > 7)
            {
                TeklifsizSat item = teklifsizs[7];
                id8 = item.Id;
                stn8.Text = item.Stokno;
                t8.Text = item.Tanim;
                m8.Text = item.Miktar.ToString();
                b8.Text = item.Birim;
                BT8.Text = item.Tutar.ToString();
            }
            if (teklifsizs.Count > 8)
            {
                TeklifsizSat item = teklifsizs[8];
                id9 = item.Id;
                stn9.Text = item.Stokno;
                t9.Text = item.Tanim;
                m9.Text = item.Miktar.ToString();
                b9.Text = item.Birim;
                BT9.Text = item.Tutar.ToString();
            }
            if (teklifsizs.Count > 9)
            {
                TeklifsizSat item = teklifsizs[9];
                id10 = item.Id;
                stn10.Text = item.Stokno;
                t10.Text = item.Tanim;
                m10.Text = item.Miktar.ToString();
                b10.Text = item.Birim;
                BT10.Text = item.Tutar.ToString();
            }
        }
        private void FillTools()
        {
            Temizle();

            if (fiyatTeklifiAls == null)
            {
                return;
            }
            if (fiyatTeklifiAls.Count == 0)
            {
                return;
            }
            if (fiyatTeklifiAls.Count > 0)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[0];
                onaylananteklif = item.Onaylananteklif;
                id1 = item.Id;
                stn1.Text = item.Stokno;
                t1.Text = item.Tanim;
                m1.Text = item.Miktar.ToString();
                b1.Text = item.Birim;

                if (onaylananteklif == 1)
                {
                    F1_1.Text = item.Firma1;
                    BBF1.Text = item.Bbf.ToString();
                    BT1.Text = item.Btf.ToString();
                }
                if (onaylananteklif == 2)
                {
                    F1_1.Text = item.Firma2;
                    BBF1.Text = item.Ibf.ToString();
                    BT1.Text = item.Itf.ToString();
                }
                if (onaylananteklif == 3)
                {
                    F1_1.Text = item.Firma3;
                    BBF1.Text = item.Ubf.ToString();
                    BT1.Text = item.Utf.ToString();
                }
            }

            if (fiyatTeklifiAls.Count > 1)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[1];
                onaylananteklif = item.Onaylananteklif;
                id2 = item.Id;
                stn2.Text = item.Stokno;
                t2.Text = item.Tanim;
                m2.Text = item.Miktar.ToString();
                b2.Text = item.Birim;
                if (onaylananteklif == 1)
                {
                    F1_2.Text = item.Firma1;
                    BBF2.Text = item.Bbf.ToString();
                    BT2.Text = item.Btf.ToString();
                }
                if (onaylananteklif == 2)
                {
                    F1_2.Text = item.Firma2;
                    BBF2.Text = item.Ibf.ToString();
                    BT2.Text = item.Itf.ToString();
                }
                if (onaylananteklif == 3)
                {
                    F1_2.Text = item.Firma3;
                    BBF2.Text = item.Ubf.ToString();
                    BT2.Text = item.Utf.ToString();
                }
            }
            if (fiyatTeklifiAls.Count > 2)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[2];
                onaylananteklif = item.Onaylananteklif;
                id3 = item.Id;
                stn3.Text = item.Stokno;
                t3.Text = item.Tanim;
                m3.Text = item.Miktar.ToString();
                b3.Text = item.Birim;

                if (onaylananteklif == 1)
                {
                    F1_3.Text = item.Firma1;
                    BBF3.Text = item.Bbf.ToString();
                    BT3.Text = item.Btf.ToString();
                }
                if (onaylananteklif == 2)
                {
                    F1_3.Text = item.Firma2;
                    BBF3.Text = item.Ibf.ToString();
                    BT3.Text = item.Itf.ToString();
                }
                if (onaylananteklif == 3)
                {
                    F1_3.Text = item.Firma3;
                    BBF3.Text = item.Ubf.ToString();
                    BT3.Text = item.Utf.ToString();
                }
            }
            if (fiyatTeklifiAls.Count > 3)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[3];
                onaylananteklif = item.Onaylananteklif;
                id4 = item.Id;
                stn4.Text = item.Stokno;
                t4.Text = item.Tanim;
                m4.Text = item.Miktar.ToString();
                b4.Text = item.Birim;

                if (onaylananteklif == 1)
                {
                    F1_4.Text = item.Firma1;
                    BBF4.Text = item.Bbf.ToString();
                    BT4.Text = item.Btf.ToString();
                }
                if (onaylananteklif == 2)
                {
                    F1_4.Text = item.Firma2;
                    BBF4.Text = item.Ibf.ToString();
                    BT4.Text = item.Itf.ToString();
                }
                if (onaylananteklif == 3)
                {
                    F1_4.Text = item.Firma3;
                    BBF4.Text = item.Ubf.ToString();
                    BT4.Text = item.Utf.ToString();
                }
            }
            if (fiyatTeklifiAls.Count > 4)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[4];
                onaylananteklif = item.Onaylananteklif;
                id5 = item.Id;
                stn5.Text = item.Stokno;
                t5.Text = item.Tanim;
                m5.Text = item.Miktar.ToString();
                b5.Text = item.Birim;

                if (onaylananteklif == 1)
                {
                    F1_5.Text = item.Firma1;
                    BBF5.Text = item.Bbf.ToString();
                    BT5.Text = item.Btf.ToString();
                }
                if (onaylananteklif == 2)
                {
                    F1_5.Text = item.Firma2;
                    BBF5.Text = item.Ibf.ToString();
                    BT5.Text = item.Itf.ToString();
                }
                if (onaylananteklif == 3)
                {
                    F1_5.Text = item.Firma3;
                    BBF5.Text = item.Ubf.ToString();
                    BT5.Text = item.Utf.ToString();
                }
            }
            if (fiyatTeklifiAls.Count > 5)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[5];
                onaylananteklif = item.Onaylananteklif;
                id6 = item.Id;
                stn6.Text = item.Stokno;
                t6.Text = item.Tanim;
                m6.Text = item.Miktar.ToString();
                b6.Text = item.Birim;

                if (onaylananteklif == 1)
                {
                    F1_6.Text = item.Firma1;
                    BBF6.Text = item.Bbf.ToString();
                    BT6.Text = item.Btf.ToString();
                }
                if (onaylananteklif == 2)
                {
                    F1_6.Text = item.Firma2;
                    BBF6.Text = item.Ibf.ToString();
                    BT6.Text = item.Itf.ToString();
                }
                if (onaylananteklif == 3)
                {
                    F1_6.Text = item.Firma3;
                    BBF6.Text = item.Ubf.ToString();
                    BT6.Text = item.Utf.ToString();
                }
            }
            if (fiyatTeklifiAls.Count > 6)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[6];
                onaylananteklif = item.Onaylananteklif;
                id7 = item.Id;
                stn7.Text = item.Stokno;
                t7.Text = item.Tanim;
                m7.Text = item.Miktar.ToString();
                b7.Text = item.Birim;

                if (onaylananteklif == 1)
                {
                    F1_7.Text = item.Firma1;
                    BBF7.Text = item.Bbf.ToString();
                    BT7.Text = item.Btf.ToString();
                }
                if (onaylananteklif == 2)
                {
                    F1_7.Text = item.Firma2;
                    BBF7.Text = item.Ibf.ToString();
                    BT7.Text = item.Itf.ToString();
                }
                if (onaylananteklif == 3)
                {
                    F1_7.Text = item.Firma3;
                    BBF7.Text = item.Ubf.ToString();
                    BT7.Text = item.Utf.ToString();
                }
            }
            if (fiyatTeklifiAls.Count > 7)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[7];
                onaylananteklif = item.Onaylananteklif;
                id8 = item.Id;
                stn8.Text = item.Stokno;
                t8.Text = item.Tanim;
                m8.Text = item.Miktar.ToString();
                b8.Text = item.Birim;

                if (onaylananteklif == 1)
                {
                    F1_8.Text = item.Firma1;
                    BBF8.Text = item.Bbf.ToString();
                    BT8.Text = item.Btf.ToString();
                }
                if (onaylananteklif == 2)
                {
                    F1_8.Text = item.Firma2;
                    BBF8.Text = item.Ibf.ToString();
                    BT8.Text = item.Itf.ToString();
                }
                if (onaylananteklif == 3)
                {
                    F1_8.Text = item.Firma3;
                    BBF8.Text = item.Ubf.ToString();
                    BT8.Text = item.Utf.ToString();
                }
            }
            if (fiyatTeklifiAls.Count > 8)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[8];
                onaylananteklif = item.Onaylananteklif;
                id9 = item.Id;
                stn9.Text = item.Stokno;
                t9.Text = item.Tanim;
                m9.Text = item.Miktar.ToString();
                b9.Text = item.Birim;

                if (onaylananteklif == 1)
                {
                    F1_9.Text = item.Firma1;
                    BBF9.Text = item.Bbf.ToString();
                    BT9.Text = item.Btf.ToString();
                }
                if (onaylananteklif == 2)
                {
                    F1_9.Text = item.Firma2;
                    BBF9.Text = item.Ibf.ToString();
                    BT9.Text = item.Itf.ToString();
                }
                if (onaylananteklif == 3)
                {
                    F1_9.Text = item.Firma3;
                    BBF9.Text = item.Ubf.ToString();
                    BT9.Text = item.Utf.ToString();
                }
            }
            if (fiyatTeklifiAls.Count > 9)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[9];
                onaylananteklif = item.Onaylananteklif;
                id10 = item.Id;
                stn10.Text = item.Stokno;
                t10.Text = item.Tanim;
                m10.Text = item.Miktar.ToString();
                b10.Text = item.Birim;

                if (onaylananteklif == 1)
                {
                    F1_10.Text = item.Firma1;
                    BBF10.Text = item.Bbf.ToString();
                    BT10.Text = item.Btf.ToString();
                }
                if (onaylananteklif == 2)
                {
                    F1_10.Text = item.Firma2;
                    BBF10.Text = item.Ibf.ToString();
                    BT10.Text = item.Itf.ToString();
                }
                if (onaylananteklif == 3)
                {
                    F1_10.Text = item.Firma3;
                    BBF10.Text = item.Ubf.ToString();
                    BT10.Text = item.Utf.ToString();
                }
            }

        }
        private void DtgSatTamamlama_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgSatTamamlama.FilterString;
            TxtTop.Text = DtgSatTamamlama.RowCount.ToString();
        }

        private void DtgSatTamamlama_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgSatTamamlama.SortString;
        }

        private void WebBrowser()
        {
            if (dosyayolu==null)
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSatTamamlama"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        string FaturaBilgisiControl()
        {
            if (CmbBelgeTuru.Text=="")
            {
                return "Lütfen Belge Türünü Belirtiniz.";
            }
            if (TxtBelgeNumarasi.Text == "")
            {
                return "Lütfen Belge Numarasını Belirtiniz.";
            }
            return "OK";
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT İşlemini Tamamlamak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj=  FaturaBilgisiControl();
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                if (satno == -1)
                {
                    MessageBox.Show("Lütfen Bir SAT Seçiniz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                //if (BtnDosyaEkle.BackColor!=Color.LightGreen)
                //{
                //    MessageBox.Show("Lütfen SAT İşlemini Bitirmeden Önce Firmadan Gelen Fatura Bilgilerini Dosyaya Ekleyiniz.,","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //    return;
                //}

                tamamlanantarih = DateTime.Now;

                string usBolgesiProje = bolgeKayitManager.BolgeProjeList(usbolgesi);
                string garantiDurumu = bolgeKayitManager.BolgeGarantiDurumList(usbolgesi);
                if (usBolgesiProje=="")
                {

                }


                Tamamlanan tamamlanan = new Tamamlanan(satno.ToString(), formno, masrafyeri, talepeden, bolum, usbolgesi, abfformno, istenentarih, tamamlanantarih, gerekce, butcekodukalemi, satbirim, harcamaturu, CmbBelgeTuru.Text, TxtBelgeNumarasi.Text, DtBelgeTarihi.Value,
                    faturafirma, ilgilikisi, masrafyerino, toplam, dosyayolu, siparisNo, ucteklif, "TAMAMLANAN SATLAR", donem, satOlusturmaTuru, proje, satinAlinanFirma, CmbHarcamaYapan.Text, usBolgesiProje, garantiDurumu, "", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, "", "", "", "", "");
                string control = tamamlananManager.Add(tamamlanan);
                if (control == "OK")
                {
                    MalzemeKaydet();

                    satDataGridview1Manager.Delete(id);
                    satinAlinacakMalManager.Delete(siparisNo);
                    

                    string yapilanislem = "SAT İŞLEMİ TAMAMLANDI.";
                    string islmeyapan = infos[1].ToString();
                    SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, yapilanislem, islmeyapan, DateTime.Now);
                    satIslemAdimlarimanager.Add(satIslem);

                    if (satbirim== "PRJ.DİR.SATIN ALMA")
                    {
                        string mesaj2 = kasaDurumManager.UpdateGider(TxtGenelTop.Text.ConDouble());
                        if (mesaj2 != "OK")
                        {
                            MessageBox.Show(mesaj2, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    //CreateWord();
                    MessageBox.Show(satno + " Numaralı SAT İşlemi Başarıyla Tamamlanmıştır.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    DataDisplay();
                    Temizle();
                    BtnDosyaEkle.BackColor = Color.Transparent;
                    TxtTop.Text = DtgSatTamamlama.RowCount.ToString();
                    webBrowser1.Navigate("");
                    FrmAnaSayfa frmAnaSayfa = new FrmAnaSayfa();
                    frmAnaSayfa.ToplamSayilar();
                }
                else
                {
                    MessageBox.Show(control);
                }
            }
        }
        string projeKodu="", proje="",butcekodu="", bucekalemi="";
        void CreateWord()
        {
            PersonelKayit personelKayit = personelKayitManager.PersonelProjeKodu(talepeden);
            projeKodu = personelKayit.ProjeKodu;
            string[] array = projeKodu.Split('/');
            projeKodu = array[0];
            /*if (array[1].ToString() != "" || (array[1].ToString() != null))
            {
                proje = array[1];
            }*/
            string[] array2 = butcekodukalemi.Split('/');
            butcekodu = array2[0];
            bucekalemi = array2[1];
            SatOnayTarihi satOnayTarihi =  satOnayTarihiManager.Get(siparisNo);


            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            //object filePath = "C:\\Users\\MAYıldırım\\Desktop\\MP-FR-006 SATIN ALMA FORMU REV (00).docx"; // taslak yolu
            object filePath = "Z:\\DTS\\SATIN ALMA\\Folder\\MP-FR-006 SATIN ALMA FORMU REV (00)5.docx";
            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["IsAkisNo"].Range.Text = formno.ToString();
            wBookmarks["FormNo"].Range.Text = satno.ToString();
            wBookmarks["Bolge"].Range.Text = usbolgesi;
            wBookmarks["Bolum"].Range.Text = bolum;
            wBookmarks["IlgiliKisi"].Range.Text = talepeden;
            wBookmarks["IstekTarihi"].Range.Text = istenentarih.ToString("dd/MM/yyyy");
            wBookmarks["IstenenTarihi"].Range.Text = istenentarih.ToString("dd/MM/yyyy");
            wBookmarks["ProjeKodu"].Range.Text = projeKodu;
            wBookmarks["Proje"].Range.Text = proje;
            wBookmarks["MasrafYeriNo"].Range.Text = masrafyerino;
            wBookmarks["ButceKodu"].Range.Text = butcekodu;
            wBookmarks["ButceKalemi"].Range.Text = bucekalemi;
            wBookmarks["BildirimNo"].Range.Text = abfformno;
            wBookmarks["SatBirim"].Range.Text = satbirim;
            wBookmarks["HarcamaTuru"].Range.Text = harcamaturu;
            wBookmarks["FaturaFirma"].Range.Text = faturafirma;
            wBookmarks["Gerekce"].Range.Text = gerekce;
            wBookmarks["Tarih1"].Range.Text = satOnayTarihi.OnayTarihi.ToString("dd/MM/yyyy"); // RESUL ABİ ***
            wBookmarks["Tarih2"].Range.Text = satOnayTarihi.BaslamaTarihi.ToString("dd/MM/yyyy"); // GÜLŞAH HANIM TARİH ***
            wBookmarks["Tarih3"].Range.Text = satOnayTarihi.OlusturmaTarihi.ToString("dd/MM/yyyy"); // EREN TARİH ***

            #region MALZEMELER
            wBookmarks["Tanim1"].Range.Text = t1.Text;
            wBookmarks["Tanim2"].Range.Text = t2.Text;
            wBookmarks["Tanim3"].Range.Text = t3.Text;
            wBookmarks["Tanim4"].Range.Text = t4.Text;
            wBookmarks["Tanim5"].Range.Text = t5.Text;
            wBookmarks["Tanim6"].Range.Text = t6.Text;
            wBookmarks["Tanim7"].Range.Text = t7.Text;
            wBookmarks["Tanim8"].Range.Text = t8.Text;
            wBookmarks["Tanim9"].Range.Text = t9.Text;
            wBookmarks["Tanim10"].Range.Text = t10.Text;
            wBookmarks["Miktar1"].Range.Text = m1.Text;
            wBookmarks["Miktar2"].Range.Text = m2.Text;
            wBookmarks["Miktar3"].Range.Text = m3.Text;
            wBookmarks["Miktar4"].Range.Text = m4.Text;
            wBookmarks["Miktar5"].Range.Text = m5.Text;
            wBookmarks["Miktar6"].Range.Text = m6.Text;
            wBookmarks["Miktar7"].Range.Text = m7.Text;
            wBookmarks["Miktar8"].Range.Text = m8.Text;
            wBookmarks["Miktar9"].Range.Text = m9.Text;
            wBookmarks["Miktar10"].Range.Text = m10.Text;
            wBookmarks["Birim1"].Range.Text = b1.Text;
            wBookmarks["Birim2"].Range.Text = b2.Text;
            wBookmarks["Birim3"].Range.Text = b3.Text;
            wBookmarks["Birim4"].Range.Text = b4.Text;
            wBookmarks["Birim5"].Range.Text = b5.Text;
            wBookmarks["Birim6"].Range.Text = b6.Text;
            wBookmarks["Birim7"].Range.Text = b7.Text;
            wBookmarks["Birim8"].Range.Text = b8.Text;
            wBookmarks["Birim9"].Range.Text = b9.Text;
            wBookmarks["Birim10"].Range.Text = b10.Text;
            wBookmarks["BF1"].Range.Text = BBF1.Text;
            wBookmarks["BF2"].Range.Text = BBF2.Text;
            wBookmarks["BF3"].Range.Text = BBF3.Text;
            wBookmarks["BF4"].Range.Text = BBF4.Text;
            wBookmarks["BF5"].Range.Text = BBF5.Text;
            wBookmarks["BF6"].Range.Text = BBF6.Text;
            wBookmarks["BF7"].Range.Text = BBF7.Text;
            wBookmarks["BF8"].Range.Text = BBF8.Text;
            wBookmarks["BF9"].Range.Text = BBF9.Text;
            wBookmarks["BF10"].Range.Text = BBF10.Text;
            wBookmarks["Tutar1"].Range.Text = BT1.Text;
            wBookmarks["Tutar2"].Range.Text = BT2.Text;
            wBookmarks["Tutar3"].Range.Text = BT3.Text;
            wBookmarks["Tutar4"].Range.Text = BT4.Text;
            wBookmarks["Tutar5"].Range.Text = BT5.Text;
            wBookmarks["Tutar6"].Range.Text = BT6.Text;
            wBookmarks["Tutar7"].Range.Text = BT7.Text;
            wBookmarks["Tutar8"].Range.Text = BT8.Text;
            wBookmarks["Tutar9"].Range.Text = BT9.Text;
            wBookmarks["Tutar10"].Range.Text = BT10.Text;
            wBookmarks["GenelTop"].Range.Text = TxtGenelTop.Text;
            #endregion

            wDoc.SaveAs2(dosyayolu+ "\\" + satno + ".docx");
            wDoc.Close();
            wApp.Quit(false);
        }
        void MalzemeKaydet()
        {
            List<TamamlananMalzeme> list = new List<TamamlananMalzeme>();

            if (stn1.Text != "")
            {
                if (F1_1.Text == "")
                {
                    firma = "Teklifsiz";
                }
                else
                {
                    firma = F1_1.Text;
                }
                TamamlananMalzeme tamamlanan = new TamamlananMalzeme(stn1.Text, t1.Text, m1.Text.ConInt(), b1.Text, firma, BT1.Text.ConDouble(),
                    BT1.Text.ConDouble(), siparisNo);
                list.Add(tamamlanan);
            }
            if (stn2.Text != "")
            {
                if (F1_2.Text == "")
                {
                    firma = "Teklifsiz";
                }
                else
                {
                    firma = F1_2.Text;
                }
                TamamlananMalzeme tamamlanan = new TamamlananMalzeme(stn2.Text, t2.Text, m2.Text.ConInt(), b2.Text, firma, BT2.Text.ConDouble(),
                    BT2.Text.ConDouble(), siparisNo);
                list.Add(tamamlanan);
            }
            if (stn3.Text != "")
            {
                if (F1_3.Text == "")
                {
                    firma = "Teklifsiz";
                }
                else
                {
                    firma = F1_3.Text;
                }
                TamamlananMalzeme tamamlanan = new TamamlananMalzeme(stn3.Text, t3.Text, m3.Text.ConInt(), b3.Text, firma, BT3.Text.ConDouble(),
                    BT3.Text.ConDouble(), siparisNo);
                list.Add(tamamlanan);
            }
            if (stn4.Text != "")
            {
                if (F1_4.Text == "")
                {
                    firma = "Teklifsiz";
                }
                else
                {
                    firma = F1_4.Text;
                }
                TamamlananMalzeme tamamlanan = new TamamlananMalzeme(stn4.Text, t4.Text, m4.Text.ConInt(), b4.Text, firma, BT4.Text.ConDouble(),
                    BT4.Text.ConDouble(), siparisNo);
                list.Add(tamamlanan);
            }
            if (stn5.Text != "")
            {
                if (F1_5.Text == "")
                {
                    firma = "Teklifsiz";
                }
                else
                {
                    firma = F1_5.Text;
                }
                TamamlananMalzeme tamamlanan = new TamamlananMalzeme(stn5.Text, t5.Text, m5.Text.ConInt(), b5.Text, firma, BT5.Text.ConDouble(),
                    BT5.Text.ConDouble(), siparisNo);
                list.Add(tamamlanan);
            }
            if (stn6.Text != "")
            {
                if (F1_6.Text == "")
                {
                    firma = "Teklifsiz";
                }
                else
                {
                    firma = F1_6.Text;
                }
                TamamlananMalzeme tamamlanan = new TamamlananMalzeme(stn6.Text, t6.Text, m6.Text.ConInt(), b6.Text, firma, BT6.Text.ConDouble(),
                    BT6.Text.ConDouble(), siparisNo);
                list.Add(tamamlanan);
            }
            if (stn7.Text != "")
            {
                if (F1_7.Text == "")
                {
                    firma = "Teklifsiz";
                }
                else
                {
                    firma = F1_7.Text;
                }
                TamamlananMalzeme tamamlanan = new TamamlananMalzeme(stn7.Text, t7.Text, m7.Text.ConInt(), b7.Text, firma, BT7.Text.ConDouble(),
                    BT7.Text.ConDouble(), siparisNo);
                list.Add(tamamlanan);
            }
            if (stn8.Text != "")
            {
                if (F1_8.Text == "")
                {
                    firma = "Teklifsiz";
                }
                else
                {
                    firma = F1_8.Text;
                }
                TamamlananMalzeme tamamlanan = new TamamlananMalzeme(stn8.Text, t8.Text, m8.Text.ConInt(), b8.Text, firma, BT8.Text.ConDouble(),
                    BT8.Text.ConDouble(), siparisNo);
                list.Add(tamamlanan);
            }
            if (stn9.Text != "")
            {
                if (F1_9.Text == "")
                {
                    firma = "Teklifsiz";
                }
                else
                {
                    firma = F1_9.Text;
                }
                TamamlananMalzeme tamamlanan = new TamamlananMalzeme(stn9.Text, t9.Text, m9.Text.ConInt(), b9.Text, firma, BT9.Text.ConDouble(),
                    BT9.Text.ConDouble(), siparisNo);
                list.Add(tamamlanan);
            }
            if (stn10.Text != "")
            {
                if (F1_10.Text == "")
                {
                    firma = "Teklifsiz";
                }
                else
                {
                    firma = F1_10.Text;
                }
                TamamlananMalzeme tamamlanan = new TamamlananMalzeme(stn10.Text, t10.Text, m10.Text.ConInt(), b10.Text, firma, BT10.Text.ConDouble(),
                    BT10.Text.ConDouble(), siparisNo);
                list.Add(tamamlanan);
            }
            if (list.Count == 0)
            {
                MessageBox.Show("Eleman Bulunamadı");
                return;
            }
            foreach (TamamlananMalzeme item in list)
            {
                tamamlananMalzemeManager.Add(item);
            }

        }
        double sonuc;
        string topfiyat;
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

        void Hesapla()
        {
            toplam = x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9 + x10;
            TxtGenelTop.Text = toplam.ToString("0.00") + " ₺";
        }

        #region TextChanged
        private void BT1_TextChanged(object sender, EventArgs e)
        {
            if (BT1.Text == "")
            {
                x1 = 0;
                Hesapla();
                return;
            }
            x1 = double.TryParse(BT1.Text, out outValue) ? Convert.ToDouble(BT1.Text) : 0;
            Hesapla();
        }

        private void BT2_TextChanged(object sender, EventArgs e)
        {
            if (BT2.Text == "")
            {
                x2 = 0;
                Hesapla();
                return;
            }
            x2 = double.TryParse(BT2.Text, out outValue) ? Convert.ToDouble(BT2.Text) : 0;
            Hesapla();
        }

        private void BT3_TextChanged(object sender, EventArgs e)
        {
            if (BT3.Text == "")
            {
                x3 = 0;
                Hesapla();
                return;
            }
            x3 = double.TryParse(BT3.Text, out outValue) ? Convert.ToDouble(BT3.Text) : 0;
            Hesapla();
        }

        private void BT4_TextChanged(object sender, EventArgs e)
        {
            if (BT4.Text == "")
            {
                x4 = 0;
                Hesapla();
                return;
            }
            x4 = double.TryParse(BT4.Text, out outValue) ? Convert.ToDouble(BT4.Text) : 0;
            Hesapla();
        }

        private void BT5_TextChanged(object sender, EventArgs e)
        {
            if (BT5.Text == "")
            {
                x5 = 0;
                Hesapla();
                return;
            }
            x5 = double.TryParse(BT5.Text, out outValue) ? Convert.ToDouble(BT5.Text) : 0;
            Hesapla();
        }

        private void BT6_TextChanged(object sender, EventArgs e)
        {
            if (BT6.Text == "")
            {
                x6 = 0;
                Hesapla();
                return;
            }
            x6 = double.TryParse(BT6.Text, out outValue) ? Convert.ToDouble(BT6.Text) : 0;
            Hesapla();
        }

        private void BT7_TextChanged(object sender, EventArgs e)
        {
            if (BT7.Text == "")
            {
                x7 = 0;
                Hesapla();
                return;
            }
            x7 = double.TryParse(BT7.Text, out outValue) ? Convert.ToDouble(BT7.Text) : 0;
            Hesapla();
        }

        private void BT8_TextChanged(object sender, EventArgs e)
        {
            if (BT8.Text == "")
            {
                x8 = 0;
                Hesapla();
                return;
            }
            x8 = double.TryParse(BT8.Text, out outValue) ? Convert.ToDouble(BT8.Text) : 0;
            Hesapla();
        }

        private void BT9_TextChanged(object sender, EventArgs e)
        {
            if (BT9.Text == "")
            {
                x9 = 0;
                Hesapla();
                return;
            }
            x9 = double.TryParse(BT9.Text, out outValue) ? Convert.ToDouble(BT9.Text) : 0;
            Hesapla();
        }

        private void BT10_TextChanged(object sender, EventArgs e)
        {
            if (BT10.Text == "")
            {
                x10 = 0;
                Hesapla();
                return;
            }
            x10 = double.TryParse(BT10.Text, out outValue) ? Convert.ToDouble(BT10.Text) : 0;
            Hesapla();
        }
        #endregion

        void Temizle()
        {
            stn1.Clear(); t1.Clear(); m1.Clear(); b1.Clear(); F1_1.Text=""; BBF1.Clear(); BT1.Clear();
            stn2.Clear(); t2.Clear(); m2.Clear(); b2.Clear(); F1_2.Text = ""; BBF2.Clear(); BT2.Clear();
            stn3.Clear(); t3.Clear(); m3.Clear(); b3.Clear(); F1_3.Text = ""; BBF3.Clear(); BT3.Clear();
            stn4.Clear(); t4.Clear(); m4.Clear(); b4.Clear(); F1_4.Text = ""; BBF4.Clear(); BT4.Clear();
            stn5.Clear(); t5.Clear(); m5.Clear(); b5.Clear(); F1_5.Text = ""; BBF5.Clear(); BT5.Clear();
            stn6.Clear(); t6.Clear(); m6.Clear(); b6.Clear(); F1_6.Text = ""; BBF6.Clear(); BT6.Clear();
            stn7.Clear(); t7.Clear(); m7.Clear(); b7.Clear(); F1_7.Text = ""; BBF7.Clear(); BT7.Clear();
            stn8.Clear(); t8.Clear(); m8.Clear(); b8.Clear(); F1_8.Text = ""; BBF8.Clear(); BT8.Clear();
            stn9.Clear(); t9.Clear(); m9.Clear(); b9.Clear(); F1_9.Text = ""; BBF9.Clear(); BT9.Clear();
            stn10.Clear(); t1.Clear(); m10.Clear(); b10.Clear(); F1_10.Text = ""; BBF10.Clear(); BT10.Clear();
            CmbBelgeTuru.Text = ""; TxtBelgeNumarasi.Clear();
        }
    }
}
