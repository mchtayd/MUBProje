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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.STS
{
    public partial class FrmReddedilenSatlar : Form
    {
        SatDataGridview1Manager satDataGridview1Manager;
        SatIslemAdimlariManager satIslemAdimlariManager;
        ReddedilenlerManager reddedilenlerManager;
        SatNoManager satNoManager;
        SatinAlinacakMalManager satinAlinacakMalManager;
        ReddedilenMalzemeManager reddedilenMalzemeManager;
        TeklifsizSatManager teklifsizSatManager;
        List<SatDataGridview1> reddedilenler;
        public object[] infos;
        //List<ReddedilenMalzeme> reddedilenMalzemes;
        List<SatinAlinacakMalzemeler> satinAlinacakMalzemelers;
        List<TeklifsizSat> teklifsizSats;
        List<SatNo> satNos;
        string dosyayolutam, siparisNo;

        string masrafyerino, talepden, bolum, usbolgesi, abfformno, gerekce, islemadimi;
        DateTime tarih;
        int id, formNo,satno;
        public FrmReddedilenSatlar()
        {
            InitializeComponent();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
            reddedilenlerManager = ReddedilenlerManager.GetInstance();
            satNoManager = SatNoManager.GetInstance();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            reddedilenMalzemeManager = ReddedilenMalzemeManager.GetInstance();
            teklifsizSatManager = TeklifsizSatManager.GetInstance();
        }

        private void FrmReddedilenSatlar_Load(object sender, EventArgs e)
        {
            DataDisplay();
            TxtTop.Text = DtgReddedilenSat.RowCount.ToString();
            int loginid = infos[0].ConInt();
            /*if (loginid == 84 || loginid==25)
            {
                BtnOnayla.Visible = true;
            }*/
        }
        public void YenilecekVeri()
        {
            DataDisplay();
            TxtTop.Text = DtgReddedilenSat.RowCount.ToString();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplay();
            TxtTop.Text = DtgReddedilenSat.RowCount.ToString();
        }

        void DataDisplay()
        {
            reddedilenler = satDataGridview1Manager.GetList("Reddedildi");
            dataBinder.DataSource = reddedilenler.ToDataTable();
            DtgReddedilenSat.DataSource = dataBinder;

            DtgReddedilenSat.Columns["Id"].Visible = false;
            DtgReddedilenSat.Columns["Satno"].HeaderText = "SAT NO";
            DtgReddedilenSat.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgReddedilenSat.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgReddedilenSat.Columns["Talepeden"].HeaderText = "TALEP EDEN PERSONEL";
            DtgReddedilenSat.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgReddedilenSat.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgReddedilenSat.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgReddedilenSat.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgReddedilenSat.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgReddedilenSat.Columns["SiparisNo"].Visible = false;
            DtgReddedilenSat.Columns["RedNedeni"].Visible = false;
            DtgReddedilenSat.Columns["DosyaYolu"].Visible = false;
            DtgReddedilenSat.Columns["PersonelId"].Visible = false;
            DtgReddedilenSat.Columns["Durum"].Visible = false;
            DtgReddedilenSat.Columns["TeklifDurumu"].Visible = false;
            DtgReddedilenSat.Columns["Donem"].HeaderText = "DÖNEM";
            DtgReddedilenSat.Columns["PersonelId"].Visible = false;
            DtgReddedilenSat.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgReddedilenSat.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPACAK BİRİM";
            DtgReddedilenSat.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgReddedilenSat.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgReddedilenSat.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgReddedilenSat.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgReddedilenSat.Columns["Uctekilf"].Visible = false;
            DtgReddedilenSat.Columns["FirmaBilgisi"].Visible = false;
            DtgReddedilenSat.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgReddedilenSat.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ";
            DtgReddedilenSat.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgReddedilenSat.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgReddedilenSat.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgReddedilenSat.Columns["BelgeTuru"].Visible = false;
            DtgReddedilenSat.Columns["BelgeNumarasi"].Visible = false;
            DtgReddedilenSat.Columns["BelgeTarihi"].Visible = false;
            DtgReddedilenSat.Columns["IslemAdimi"].HeaderText = "İŞLEM ADIMI";
            DtgReddedilenSat.Columns["SatOlusturmaTuru"].Visible = false;
            DtgReddedilenSat.Columns["RedNedeni"].HeaderText = "RET NEDENİ";
            DtgReddedilenSat.Columns["Durum"].Visible = false;
            DtgReddedilenSat.Columns["Donem"].DisplayIndex = 3;
        }
        private void FillTools()
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
                if (item.Stn1=="" && item.B1=="")
                {
                    groupBox2.Visible = false;
                    panel2.Visible = true;
                    LblToplam.Text = item.T1; // tutar bilgisi tanıma atıldı (SAT ONAYDAN GELİYOR)
                    BtnOnayla.Location = new Point(7, 507);
                    BtnSatDuzenle.Location = new Point(144, 507);
                    webBrowser1.Navigate(dosyayolutam);
                    return;
                }
                BtnOnayla.Location = new Point(15, 755);
                BtnSatDuzenle.Location = new Point(152, 755);

                groupBox2.Visible = true;
                panel2.Visible = false;
                stn1.Text = item.Stn1;
                t1.Text = item.T1;
                m1.Text = item.M1.ToString();
                b1.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 1)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[1];
                stn2.Text = item.Stn1;
                t2.Text = item.T1;
                m2.Text = item.M1.ToString();
                b2.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 2)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[2];
                stn3.Text = item.Stn1;
                t3.Text = item.T1;
                m3.Text = item.M1.ToString();
                b3.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 3)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[3];
                stn4.Text = item.Stn1;
                t4.Text = item.T1;
                m4.Text = item.M1.ToString();
                b4.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 4)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[4];
                stn5.Text = item.Stn1;
                t5.Text = item.T1;
                m5.Text = item.M1.ToString();
                b5.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 5)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[5];
                stn6.Text = item.Stn1;
                t6.Text = item.T1;
                m6.Text = item.M1.ToString();
                b6.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 6)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[6];
                stn7.Text = item.Stn1;
                t7.Text = item.T1;
                m7.Text = item.M1.ToString();
                b7.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 7)
            {

                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[7];
                stn8.Text = item.Stn1;
                t8.Text = item.T1;
                m8.Text = item.M1.ToString();
                b8.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 8)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[8];
                stn9.Text = item.Stn1;
                t9.Text = item.T1;
                m9.Text = item.M1.ToString();
                b9.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 9)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[9];
                stn10.Text = item.Stn1;
                t10.Text = item.T1;
                m10.Text = item.M1.ToString();
                b10.Text = item.B1;
            }
            WebBrowser();
        }
        private void Temizle()
        {
            stn1.Clear(); t1.Clear(); m1.Clear(); b1.Clear(); stn2.Clear(); t2.Clear(); m2.Clear(); b2.Clear();
            stn3.Clear(); t3.Clear(); m3.Clear(); b3.Clear(); stn4.Clear(); t4.Clear(); m4.Clear(); b4.Clear();
            stn5.Clear(); t5.Clear(); m5.Clear(); b5.Clear(); stn6.Clear(); t6.Clear(); m6.Clear(); b6.Clear();
            stn7.Clear(); t7.Clear(); m7.Clear(); b7.Clear(); stn8.Clear(); t8.Clear(); m8.Clear(); b8.Clear();
            stn9.Clear(); t9.Clear(); m9.Clear(); b9.Clear(); stn10.Clear(); t10.Clear(); m10.Clear(); b10.Clear(); TxtRedNedeni.Clear();
        }

        private void DtgReddedilenSat_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgReddedilenSat.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
             
            id = DtgReddedilenSat.CurrentRow.Cells["Id"].Value.ConInt();
            siparisNo = DtgReddedilenSat.CurrentRow.Cells["SiparisNo"].Value.ToString();
            formNo = DtgReddedilenSat.CurrentRow.Cells["Formno"].Value.ConInt();
            satno = DtgReddedilenSat.CurrentRow.Cells["Satno"].Value.ConInt();
            dosyayolutam = DtgReddedilenSat.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            masrafyerino = DtgReddedilenSat.CurrentRow.Cells["Masyerino"].Value.ToString();
            talepden = DtgReddedilenSat.CurrentRow.Cells["Talepeden"].Value.ToString();
            bolum = DtgReddedilenSat.CurrentRow.Cells["Bolum"].Value.ToString();
            usbolgesi = DtgReddedilenSat.CurrentRow.Cells["Usbolgesi"].Value.ToString();
            abfformno = DtgReddedilenSat.CurrentRow.Cells["Abfformno"].Value.ToString();
            tarih = DtgReddedilenSat.CurrentRow.Cells["Tarih"].Value.ConDate();
            gerekce = DtgReddedilenSat.CurrentRow.Cells["Gerekce"].Value.ToString();
            donem = DtgReddedilenSat.CurrentRow.Cells["Donem"].Value.ToString();
            islemadimi = DtgReddedilenSat.CurrentRow.Cells["Islemadimi"].Value.ToString();

            teklifsizSats = teklifsizSatManager.GetList(siparisNo);
            satinAlinacakMalzemelers = satinAlinacakMalManager.GetList(siparisNo);

            TxtRedNedeni.Text = DtgReddedilenSat.CurrentRow.Cells["Rednedeni"].Value.ToString();
            IslemAdimlari();

            satNos = satNoManager.GetList(siparisNo);
            if (teklifsizSats.Count!=0)
            {
                FillTools2();
                return;
            }
            FillTools();
        }
        void FillTools2()
        {
            if (satinAlinacakMalzemelers == null)
            {
                return;
            }
            TeklifsizSat item = teklifsizSats[0];
            groupBox2.Visible = false;
            panel2.Visible = true;
            BtnOnayla.Location = new Point(7, 507);
            BtnSatDuzenle.Location = new Point(144, 507);
            LblToplam.Text = item.Tutar.ToString(); // tutar bilgisi tanıma atıldı (SAT ONAYDAN GELİYOR)
            try
            {
                webBrowser1.Navigate(dosyayolutam);
            }
            catch (Exception)
            {

                return;
            }
            
        }
        void IslemAdimlari()
        {
            DtgSatIslemAdimlari.DataSource = satIslemAdimlariManager.GetList(siparisNo);

            DtgSatIslemAdimlari.Columns["Id"].Visible = false;
            DtgSatIslemAdimlari.Columns["Siparisno"].Visible = false;
            DtgSatIslemAdimlari.Columns["Islem"].HeaderText = "İŞLEM ADIMI";
            DtgSatIslemAdimlari.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgSatIslemAdimlari.Columns["Tarih"].HeaderText = "TARİH";
        }

        private void DtgReddedilenSat_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgReddedilenSat.SortString;
        }

        private void DtgReddedilenSat_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgReddedilenSat.FilterString;
        }
        string donem;
        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bu işlemden sonra " + formNo + " SAT FORM numaralı kayıt SAT BAŞLATMA ONAYI aşamasına iletilecektir.\nOnaylıyor musunuz?", "Soru",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                SatDataGridview1 satDataGridview1 = new SatDataGridview1(satno, formNo, masrafyerino, talepden, bolum, usbolgesi, abfformno, tarih, gerekce, siparisNo, "", "", "", "", "", dosyayolutam, infos[0].ConInt(), "", donem, "BAŞARAN", "", "", "", "", "");

                satDataGridview1Manager.Add(satDataGridview1);
                MalzemeleriEkle();
                reddedilenlerManager.Delete(id);
                reddedilenMalzemeManager.Delete(siparisNo);
                //reddedilenlerManager.DurumGuncelleRed(siparisNo);
                string yapilanislem = "SAT TEKRAR ONAYLANARAK SAT BAŞLATMA ONAYI AŞAMASINA İLETİLDİ.";
                string islemyapan = infos[1].ToString();
                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, islemyapan, DateTime.Now);
                satIslemAdimlariManager.Add(satIslemAdimlari);

                DataDisplay();
                Temizle();
                TxtTop.Text = DtgReddedilenSat.RowCount.ToString();
                webBrowser1.Navigate("");
                MessageBox.Show("İşlem Başarıyla Tamamlanmıştır.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        void MalzemeleriEkle()
        {
            List<SatinAlinacakMalzemeler> list = new List<SatinAlinacakMalzemeler>();

            if (stn1.Text != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn1.Text, t1.Text, m1.Text.ConInt(), b1.Text, masrafyerino);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn2.Text != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn2.Text, t2.Text, m2.Text.ConInt(), b2.Text, masrafyerino);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn3.Text != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn3.Text, t3.Text, m3.Text.ConInt(), b3.Text, masrafyerino);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn4.Text != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn4.Text, t4.Text, m4.Text.ConInt(), b4.Text, masrafyerino);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn5.Text != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn5.Text, t5.Text, m5.Text.ConInt(), b5.Text, masrafyerino);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn6.Text != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn6.Text, t6.Text, m6.Text.ConInt(), b6.Text, masrafyerino);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn7.Text != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn7.Text, t7.Text, m7.Text.ConInt(), b7.Text, masrafyerino);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn8.Text != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn8.Text, t8.Text, m8.Text.ConInt(), b8.Text, masrafyerino);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn9.Text != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn9.Text, t9.Text, m9.Text.ConInt(), b9.Text, masrafyerino);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn10.Text != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn10.Text, t10.Text, m10.Text.ConInt(), b10.Text, masrafyerino);
                list.Add(satinAlinacakMalzeme);
            }

            if (list.Count == 0)
            {
                MessageBox.Show("Eleman Bulunamadı");
                return;
            }

            foreach (SatinAlinacakMalzemeler item in list)
            {
                satinAlinacakMalManager.Add(item, siparisNo);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageReddedilen"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void WebBrowser()
        {
            try
            {
                webBrowser1.Navigate(dosyayolutam);
            }
            catch (Exception)
            {
                return;
            }
            
        }
        #region Kypress
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

        private void BtnOnaylaT_Click(object sender, EventArgs e)
        {

        }

        private void BtnSatDuzenle_Click(object sender, EventArgs e)
        {
            if (formNo.ToString() == "")
            {
                MessageBox.Show("Lütfen Geçerli Bir SAT Kaydı Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }


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

        private void TxtRedNedeni_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion
    }
}
