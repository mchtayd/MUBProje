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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;

namespace UserInterface.STS
{
    public partial class FrmDevamEdenSat : Form
    {
        SatinAlinacakMalManager satinAlinacakMalManager;
        SatDataGridview1Manager satDataGridview1Manager;
        SatNoManager satNoManager;
        SatIslemAdimlariManager satIslemAdimlariManager;
        TeklifsizSatManager teklifsizSatManager;
        FiyatTeklifiAlManager fiyatTeklifiAlManager;
        List<SatinAlinacakMalzemeler> satinAlinacakMalzemelers;
        List<FiyatTeklifiAl> fiyatTeklifiAls;
        List<SatDataGridview1> satDatas;
        List<TeklifsizSat> teklifsizSats;
        public object[] infos;
        string dosyayolu, siparisNo, belgeTuru;
        public FrmDevamEdenSat()
        {
            InitializeComponent();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
            satNoManager = SatNoManager.GetInstance();
            teklifsizSatManager = TeklifsizSatManager.GetInstance();
            fiyatTeklifiAlManager = FiyatTeklifiAlManager.GetInstance();
        }

        private void FrmDevamEdenSat_Load(object sender, EventArgs e)
        {
            DataDisplay();
            TxtTop.Text = DtgDevamEden.RowCount.ToString();
        }
        void IslemAdimlari()
        {
            DtgSatIslemAdimlari.DataSource = satIslemAdimlariManager.GetList(siparisNo);

            DtgSatIslemAdimlari.Columns["Id"].Visible = false;
            DtgSatIslemAdimlari.Columns["Siparisno"].Visible = false;
            DtgSatIslemAdimlari.Columns["Islem"].HeaderText = "İŞLEM ADIMI";
            DtgSatIslemAdimlari.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgSatIslemAdimlari.Columns["Tarih"].HeaderText = "TARİH";

            /*dtgTemp.DataSource = teklifsizSats;

            string htmlContent = FrmHelper.Html_Log_Content(DtgSatIslemAdimlari, dtgTemp);

            BrowserLog.DocumentText = htmlContent;*/
        }
        public void YenilecekVeri()
        {
            DataDisplay();
            TxtTop.Text = DtgDevamEden.RowCount.ToString();
        }
        void DataDisplay()
        {
            satDatas = satDataGridview1Manager.List();
            dataBinder.DataSource = satDatas.ToDataTable();
            DtgDevamEden.DataSource = dataBinder;

            DtgDevamEden.Columns["Id"].Visible = false;
            DtgDevamEden.Columns["Satno"].HeaderText = "SAT NO";
            DtgDevamEden.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgDevamEden.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgDevamEden.Columns["Talepeden"].HeaderText = "İSTEKTE BULUNAN";
            DtgDevamEden.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgDevamEden.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgDevamEden.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgDevamEden.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgDevamEden.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgDevamEden.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgDevamEden.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgDevamEden.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgDevamEden.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgDevamEden.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgDevamEden.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgDevamEden.Columns["Uctekilf"].Visible = false;
            DtgDevamEden.Columns["SiparisNo"].Visible = false;
            DtgDevamEden.Columns["DosyaYolu"].Visible = false;
            DtgDevamEden.Columns["PersonelId"].Visible = false;
            DtgDevamEden.Columns["FirmaBilgisi"].Visible = false;
            DtgDevamEden.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgDevamEden.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgDevamEden.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgDevamEden.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgDevamEden.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgDevamEden.Columns["BelgeTuru"].Visible = false;
            DtgDevamEden.Columns["BelgeNumarasi"].Visible = false;
            DtgDevamEden.Columns["BelgeTarihi"].Visible = false;
            DtgDevamEden.Columns["MailSiniri"].Visible = false;
            DtgDevamEden.Columns["MailDurumu"].Visible = false;
            DtgDevamEden.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgDevamEden.Columns["Donem"].HeaderText = "DÖNEM";
            DtgDevamEden.Columns["Proje"].HeaderText = "PROJE";
            DtgDevamEden.Columns["Donem"].DisplayIndex = 3;
            DtgDevamEden.Columns["SatOlusturmaTuru"].Visible = false;
            DtgDevamEden.Columns["RedNedeni"].Visible = false;
            DtgDevamEden.Columns["Durum"].Visible = false;
            DtgDevamEden.Columns["TeklifDurumu"].Visible = false;
            DtgDevamEden.Columns["SatinAlinanFirma"].Visible = false;
            DtgDevamEden.Columns["MailSiniri"].Visible = false;
            DtgDevamEden.Columns["MailDurumu"].Visible = false;
        }

        private void Temizle()
        {
            stn1.Clear(); t1.Clear(); m1.Clear(); b1.Clear(); stn2.Clear(); t2.Clear(); m2.Clear(); b2.Clear();
            stn3.Clear(); t3.Clear(); m3.Clear(); b3.Clear(); stn4.Clear(); t4.Clear(); m4.Clear(); b4.Clear();
            stn5.Clear(); t5.Clear(); m5.Clear(); b5.Clear(); stn6.Clear(); t6.Clear(); m6.Clear(); b6.Clear();
            stn7.Clear(); t7.Clear(); m7.Clear(); b7.Clear(); stn8.Clear(); t8.Clear(); m8.Clear(); b8.Clear();
            stn9.Clear(); t9.Clear(); m9.Clear(); b9.Clear(); stn10.Clear(); t10.Clear(); m10.Clear(); b10.Clear();
        }

        private void FillTools()
        {

            Temizle();
            if (teklifsizSats == null)
            {
                return;
            }

            if (teklifsizSats.Count == 0)
            {
                return;
            }

            /*if (satOlusturmaTuru == "HARCAMASI YAPILAN")
            {
                TeklifsizSat item = teklifsizSats[0];
                TxtTutar.Text = item.Tutar.ToString();
                return;
            }*/
            if (belgeTuru != "")
            {
                TeklifsizSat item = teklifsizSats[0];
                TxtTutar.Text = item.Tutar.ToString();
                return;
            }
            if (teklifsizSats.Count > 0)
            {
                TeklifsizSat item = teklifsizSats[0];
                stn1.Text = item.Stokno;
                t1.Text = item.Tanim;
                m1.Text = item.Miktar.ToString();
                b1.Text = item.Birim;
            }

            if (teklifsizSats.Count > 1)
            {
                TeklifsizSat item = teklifsizSats[1];
                stn2.Text = item.Stokno;
                t2.Text = item.Tanim;
                m2.Text = item.Miktar.ToString();
                b2.Text = item.Birim;
            }

            if (teklifsizSats.Count > 2)
            {
                TeklifsizSat item = teklifsizSats[2];
                stn3.Text = item.Stokno;
                t3.Text = item.Tanim;
                m3.Text = item.Miktar.ToString();
                b3.Text = item.Birim;
            }

            if (teklifsizSats.Count > 3)
            {
                TeklifsizSat item = teklifsizSats[3];
                stn4.Text = item.Stokno;
                t4.Text = item.Tanim;
                m4.Text = item.Miktar.ToString();
                b4.Text = item.Birim;
            }

            if (teklifsizSats.Count > 4)
            {
                TeklifsizSat item = teklifsizSats[4];
                stn5.Text = item.Stokno;
                t5.Text = item.Tanim;
                m5.Text = item.Miktar.ToString();
                b5.Text = item.Birim;
            }

            if (teklifsizSats.Count > 5)
            {


                TeklifsizSat item = teklifsizSats[5];
                stn6.Text = item.Stokno;
                t6.Text = item.Tanim;
                m6.Text = item.Miktar.ToString();
                b6.Text = item.Birim;
            }

            if (teklifsizSats.Count > 6)
            {
                TeklifsizSat item = teklifsizSats[6];
                stn7.Text = item.Stokno;
                t7.Text = item.Tanim;
                m7.Text = item.Miktar.ToString();
                b7.Text = item.Birim;
            }

            if (teklifsizSats.Count > 7)
            {

                TeklifsizSat item = teklifsizSats[7];
                stn8.Text = item.Stokno;
                t8.Text = item.Tanim;
                m8.Text = item.Miktar.ToString();
                b8.Text = item.Birim;
            }

            if (teklifsizSats.Count > 8)
            {
                TeklifsizSat item = teklifsizSats[8];
                stn9.Text = item.Stokno;
                t9.Text = item.Tanim;
                m9.Text = item.Miktar.ToString();
                b9.Text = item.Birim;
            }

            if (teklifsizSats.Count > 9)
            {
                TeklifsizSat item = teklifsizSats[9];
                stn10.Text = item.Stokno;
                t10.Text = item.Tanim;
                m10.Text = item.Miktar.ToString();
                b10.Text = item.Birim;
            }

            //WebBrowser();
        }
        private void WebBrowser()
        {
            try
            {
                webBrowser1.Navigate(dosyayolu);
            }
            catch (Exception)
            {
                return;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDevamEdenSat"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void DtgDevamEden_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgDevamEden.FilterString;
            TxtTop.Text = DtgDevamEden.RowCount.ToString();
        }

        private void DtgDevamEden_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgDevamEden.SortString;
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplay();
            TxtTop.Text = DtgDevamEden.RowCount.ToString();
        }
        #region Keypress
        private void stn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void stn2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void stn3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void stn4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = true;
        }

        private void stn5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = true;
        }

        private void stn6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void stn7_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void stn8_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = true;
        }

        private void stn9_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void stn10_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void t1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void t2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void t3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void t4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //.Handled = true;
        }

        private void t5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //.Handled = true;
        }

        private void t6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void t7_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = true;
        }

        private void t8_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void t9_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void t10_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void m1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = true;
        }

        private void m2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void m3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void m4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void m5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = true;
        }

        private void m6_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = true;
        }

        private void m7_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  e.Handled = true;
        }

        private void m8_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void m9_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = true;
        }

        private void m10_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = true;
        }

        private void b1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void b2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void b3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void b4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void b5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void b6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void b7_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void b8_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void b9_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void TxtTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b10_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }
        #endregion
        int teklifdurumu;
        string talepeden, satOlusturmaTuru;

        private void DtgDevamEden_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (DtgDevamEden.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            siparisNo = DtgDevamEden.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosyayolu = DtgDevamEden.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            belgeTuru = DtgDevamEden.CurrentRow.Cells["BelgeTuru"].Value.ToString();
            teklifdurumu = DtgDevamEden.CurrentRow.Cells["Uctekilf"].Value.ConInt();
            talepeden = DtgDevamEden.CurrentRow.Cells["Talepeden"].Value.ToString();
            satOlusturmaTuru = DtgDevamEden.CurrentRow.Cells["SatOlusturmaTuru"].Value.ToString();

            satinAlinacakMalzemelers = satinAlinacakMalManager.GetList(siparisNo);
            teklifsizSats = teklifsizSatManager.GetList(siparisNo);
            fiyatTeklifiAls = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);

            WebBrowser();
            if (teklifsizSats.Count == 0)
            {
                FillTools2();
            }
            if (fiyatTeklifiAls.Count == 0)
            {
                FillTools();
            }

            IslemAdimlari();

            if (teklifdurumu == 0)
            {
                if (belgeTuru != "")
                {
                    panel2.Visible = false;
                    panel3.Visible = true;
                    return;
                }
                if (talepeden == "MURAT DEMİRTAŞ      " || talepeden == "EMEL AYHAN          ")
                {
                    panel2.Visible = true;
                    panel3.Visible = false;
                    return;
                }
                panel2.Visible = false;
                panel3.Visible = true;
            }
            if (teklifdurumu == 1)
            {
                panel2.Visible = true;
                panel3.Visible = false;
            }

        }
        void FillTools2()
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
                stn1.Text = item.Stokno;
                t1.Text = item.Tanim;
                m1.Text = item.Miktar.ToString();
                b1.Text = item.Birim;
            }
            if (fiyatTeklifiAls.Count > 1)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[1];
                stn2.Text = item.Stokno;
                t2.Text = item.Tanim;
                m2.Text = item.Miktar.ToString();
                b2.Text = item.Birim;
            }
            if (fiyatTeklifiAls.Count > 2)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[2];
                stn3.Text = item.Stokno;
                t3.Text = item.Tanim;
                m3.Text = item.Miktar.ToString();
                b3.Text = item.Birim;
            }
            if (fiyatTeklifiAls.Count > 3)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[3];
                stn4.Text = item.Stokno;
                t4.Text = item.Tanim;
                m4.Text = item.Miktar.ToString();
                b4.Text = item.Birim;
            }
            if (fiyatTeklifiAls.Count > 4)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[4];
                stn5.Text = item.Stokno;
                t5.Text = item.Tanim;
                m5.Text = item.Miktar.ToString();
                b5.Text = item.Birim;
            }
            if (fiyatTeklifiAls.Count > 5)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[5];
                stn6.Text = item.Stokno;
                t6.Text = item.Tanim;
                m6.Text = item.Miktar.ToString();
                b6.Text = item.Birim;
            }
            if (fiyatTeklifiAls.Count > 6)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[6];
                stn7.Text = item.Stokno;
                t7.Text = item.Tanim;
                m7.Text = item.Miktar.ToString();
                b7.Text = item.Birim;
            }
            if (fiyatTeklifiAls.Count > 7)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[7];
                stn8.Text = item.Stokno;
                t8.Text = item.Tanim;
                m8.Text = item.Miktar.ToString();
                b8.Text = item.Birim;
            }
            if (fiyatTeklifiAls.Count > 8)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[8];
                stn9.Text = item.Stokno;
                t9.Text = item.Tanim;
                m9.Text = item.Miktar.ToString();
                b9.Text = item.Birim;
            }
            if (fiyatTeklifiAls.Count > 9)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[9];
                stn10.Text = item.Stokno;
                t10.Text = item.Tanim;
                m10.Text = item.Miktar.ToString();
                b10.Text = item.Birim;
            }

        }
    }
}
