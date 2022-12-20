using Business.Concreate;
using Business.Concreate.BakimOnarim;
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
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Word.Application;
using MailMessage = System.Net.Mail.MailMessage;

namespace UserInterface.STS
{
    public partial class FrmSatOnay : Form
    {
        SatinAlinacakMalManager satinAlinacakMalManager;
        SatDataGridview1Manager satDataGridview1Manager;
        SatIslemAdimlariManager satIslemAdimlarimanager;
        SatNoManager satNoManager;
        TekliflerManager tekliflerManager;
        TeklifFirmalarManager teklifFirmalarManager;
        TeklifsizSatManager teklifsizSatManager;
        ReddedilenlerManager reddedilenlerManager;
        FiyatTeklifiAlManager fiyatTeklifiAlManager;
        ReddedilenMalzemeManager reddedilenMalzemeManager;
        TamamlananManager tamamlananManager;
        TamamlananMalzemeManager tamamlananMalzemeManager;
        TeklifiAlinanManager teklifiAlinanManager;
        SatOnayTarihiManager satOnayTarihiManager;
        PersonelKayitManager personelKayitManager;
        BolgeKayitManager bolgeKayitManager;

        public object[] infos;
        public object[] infos1;
        public object[] infos2;
        List<SatinAlinacakMalzemeler> satinAlinacakMalzemelers;
        List<TeklifsizSat> teklifsizSats;
        List<FiyatTeklifiAl> fiyatTeklifiAls;
        List<SatDataGridview1> dataGridview1s;
        List<SatNo> satNos;

        string dosyayolu, rednedeni = "", onaydurum, talepeden, bolum, usbolgesi, abfno, gerekce;
        DateTime istenentarih, belgeTarihi;
        string masrafyerino, yapilanislem, islmeyapan, butcekodukalemi, satbirim, harcamaturu, belgeNumarasi, faturafirma, ilgilikisi;
        string siparisNo, masrafyeri, abfformno, kaynakdosya, hedefdosya, islemAdimi, durum, teklifDurumu, firmaBilgisi, talepEdenPersonel, personelSiparis, unvani, personelMasrafYerNo, satinAlinanFirma, mlzTeslimTarihi;
        int id, ucteklif, formno, satno, satNo, personelId;
        double toplam, toplam1, toplam2, toplam3, x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, y1, y2, y3, y4, y5, y6, y7, y8, y9, y10, z1, z2, z3, z4, z5, z6, z7, z8, z9, z10 = 0, outValue = 0, toplamlar;
        DateTime tamamlanantarih;

        private void UTop7_TextChanged(object sender, EventArgs e)
        {
            if (UTop7.Text == "")
            {
                z7 = 0;
                Hesapla4();
                return;
            }
            z7 = double.TryParse(UTop7.Text, out outValue) ? Convert.ToDouble(UTop7.Text) : 0;
            Hesapla4();
        }

        private void UTop8_TextChanged(object sender, EventArgs e)
        {
            if (UTop8.Text == "")
            {
                z8 = 0;
                Hesapla4();
                return;
            }
            z8 = double.TryParse(UTop8.Text, out outValue) ? Convert.ToDouble(UTop8.Text) : 0;
            Hesapla4();
        }

        private void UTop9_TextChanged(object sender, EventArgs e)
        {
            if (UTop9.Text == "")
            {
                z9 = 0;
                Hesapla4();
                return;
            }
            z9 = double.TryParse(UTop9.Text, out outValue) ? Convert.ToDouble(UTop9.Text) : 0;
            Hesapla4();
        }

        private void UTop10_TextChanged(object sender, EventArgs e)
        {
            if (UTop10.Text == "")
            {
                z10 = 0;
                Hesapla4();
                return;
            }
            z10 = double.TryParse(UTop10.Text, out outValue) ? Convert.ToDouble(UTop10.Text) : 0;
            Hesapla4();
        }

        private void UTop6_TextChanged(object sender, EventArgs e)
        {
            if (UTop6.Text == "")
            {
                z6 = 0;
                Hesapla4();
                return;
            }
            z6 = double.TryParse(UTop6.Text, out outValue) ? Convert.ToDouble(UTop6.Text) : 0;
            Hesapla4();
        }

        private void UTop5_TextChanged(object sender, EventArgs e)
        {
            if (UTop5.Text == "")
            {
                z5 = 0;
                Hesapla4();
                return;
            }
            z5 = double.TryParse(UTop5.Text, out outValue) ? Convert.ToDouble(UTop5.Text) : 0;
            Hesapla4();
        }

        private void UTop4_TextChanged(object sender, EventArgs e)
        {
            if (UTop4.Text == "")
            {
                z4 = 0;
                Hesapla4();
                return;
            }
            z4 = double.TryParse(UTop4.Text, out outValue) ? Convert.ToDouble(UTop4.Text) : 0;
            Hesapla4();
        }

        private void UTop3_TextChanged(object sender, EventArgs e)
        {
            if (UTop3.Text == "")
            {
                z3 = 0;
                Hesapla4();
                return;
            }
            z3 = double.TryParse(UTop3.Text, out outValue) ? Convert.ToDouble(UTop3.Text) : 0;
            Hesapla4();
        }

        private void UTop2_TextChanged(object sender, EventArgs e)
        {
            if (UTop2.Text == "")
            {
                z2 = 0;
                Hesapla4();
                return;
            }
            z2 = double.TryParse(UTop2.Text, out outValue) ? Convert.ToDouble(UTop2.Text) : 0;
            Hesapla4();
        }
        private void UTop1_TextChanged(object sender, EventArgs e)
        {
            if (UTop1.Text == "")
            {
                z1 = 0;
                Hesapla4();
                return;
            }
            z1 = double.TryParse(UTop1.Text, out outValue) ? Convert.ToDouble(UTop1.Text) : 0;
            Hesapla4();
        }

        private void ITop9_TextChanged(object sender, EventArgs e)
        {
            if (ITop9.Text == "")
            {
                y9 = 0;
                Hesapla3();
                return;
            }
            y9 = double.TryParse(ITop9.Text, out outValue) ? Convert.ToDouble(ITop9.Text) : 0;
            Hesapla3();
        }

        private void ITop10_TextChanged(object sender, EventArgs e)
        {
            if (ITop10.Text == "")
            {
                y10 = 0;
                Hesapla3();
                return;
            }
            y10 = double.TryParse(ITop10.Text, out outValue) ? Convert.ToDouble(ITop10.Text) : 0;
            Hesapla3();
        }

        private void ITop8_TextChanged(object sender, EventArgs e)
        {
            if (ITop8.Text == "")
            {
                y8 = 0;
                Hesapla3();
                return;
            }
            y8 = double.TryParse(ITop8.Text, out outValue) ? Convert.ToDouble(ITop8.Text) : 0;
            Hesapla3();
        }

        private void ITop7_TextChanged(object sender, EventArgs e)
        {
            if (ITop7.Text == "")
            {
                y7 = 0;
                Hesapla3();
                return;
            }
            y7 = double.TryParse(ITop7.Text, out outValue) ? Convert.ToDouble(ITop7.Text) : 0;
            Hesapla3();
        }

        private void ITop6_TextChanged(object sender, EventArgs e)
        {
            if (ITop6.Text == "")
            {
                y6 = 0;
                Hesapla3();
                return;
            }
            y6 = double.TryParse(ITop6.Text, out outValue) ? Convert.ToDouble(ITop6.Text) : 0;
            Hesapla3();
        }

        private void ITop5_TextChanged(object sender, EventArgs e)
        {
            if (ITop5.Text == "")
            {
                y5 = 0;
                Hesapla3();
                return;
            }
            y5 = double.TryParse(ITop5.Text, out outValue) ? Convert.ToDouble(ITop5.Text) : 0;
            Hesapla3();
        }

        private void ITop4_TextChanged(object sender, EventArgs e)
        {
            if (ITop4.Text == "")
            {
                y4 = 0;
                Hesapla3();
                return;
            }
            y4 = double.TryParse(ITop4.Text, out outValue) ? Convert.ToDouble(ITop4.Text) : 0;
            Hesapla3();
        }

        private void ITop3_TextChanged(object sender, EventArgs e)
        {
            if (ITop3.Text == "")
            {
                y3 = 0;
                Hesapla3();
                return;
            }
            y3 = double.TryParse(ITop3.Text, out outValue) ? Convert.ToDouble(ITop3.Text) : 0;
            Hesapla3();
        }

        private void ITop2_TextChanged(object sender, EventArgs e)
        {
            if (ITop2.Text == "")
            {
                y2 = 0;
                Hesapla3();
                return;
            }
            y2 = double.TryParse(ITop2.Text, out outValue) ? Convert.ToDouble(ITop2.Text) : 0;
            Hesapla3();
        }

        private void ITop1_TextChanged(object sender, EventArgs e)
        {
            if (ITop1.Text == "")
            {
                y1 = 0;
                Hesapla3();
                return;
            }
            y1 = double.TryParse(ITop1.Text, out outValue) ? Convert.ToDouble(ITop1.Text) : 0;
            Hesapla3();
        }

        public FrmSatOnay()
        {
            InitializeComponent();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            satNoManager = SatNoManager.GetInstance();
            satIslemAdimlarimanager = SatIslemAdimlariManager.GetInstance();
            tekliflerManager = TekliflerManager.GetInstance();
            teklifFirmalarManager = TeklifFirmalarManager.GetInstance();
            teklifsizSatManager = TeklifsizSatManager.GetInstance();
            reddedilenlerManager = ReddedilenlerManager.GetInstance();
            fiyatTeklifiAlManager = FiyatTeklifiAlManager.GetInstance();
            reddedilenMalzemeManager = ReddedilenMalzemeManager.GetInstance();
            tamamlananManager = TamamlananManager.GetInstance();
            tamamlananMalzemeManager = TamamlananMalzemeManager.GetInstance();
            teklifiAlinanManager = TeklifiAlinanManager.GetInstance();
            satOnayTarihiManager = SatOnayTarihiManager.GetInstance();
            personelKayitManager = PersonelKayitManager.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
        }

        private void FrmSatOnay_Load(object sender, EventArgs e)
        {
            SatDataGrid1();
            TxtTop.Text = DtgOnay.RowCount.ToString();
        }
        public void YenilecekVeri()
        {
            SatDataGrid1();
            TxtTop.Text = DtgOnay.RowCount.ToString();
        }

        void FillInfos()
        {
            islmeyapan = infos[1].ToString();
        }
        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillInfos();
            SatDataGrid1();
            TxtTop.Text = DtgOnay.RowCount.ToString();
        }
        void SatDataGrid1()
        {
            dataGridview1s = satDataGridview1Manager.SatOnayListele();
            dataBinderSat.DataSource = dataGridview1s.ToDataTable();
            DtgOnay.DataSource = dataBinderSat;

            DataDisplay();
        }

        private void BTop1_TextChanged(object sender, EventArgs e)
        {
            if (BTop1.Text == "")
            {
                a1 = 0;
                Hesapla2();
                return;
            }
            a1 = double.TryParse(BTop1.Text, out outValue) ? Convert.ToDouble(BTop1.Text) : 0;
            Hesapla2();
        }
        private void BTop2_TextChanged(object sender, EventArgs e)
        {
            if (BTop2.Text == "")
            {
                a2 = 0;
                Hesapla2();
                return;
            }
            a2 = double.TryParse(BTop2.Text, out outValue) ? Convert.ToDouble(BTop2.Text) : 0;
            Hesapla2();
        }
        private void BTop3_TextChanged(object sender, EventArgs e)
        {
            if (BTop3.Text == "")
            {
                a3 = 0;
                Hesapla2();
                return;
            }
            a3 = double.TryParse(BTop3.Text, out outValue) ? Convert.ToDouble(BTop3.Text) : 0;
            Hesapla2();
        }
        private void BTop4_TextChanged(object sender, EventArgs e)
        {
            if (BTop4.Text == "")
            {
                a4 = 0;
                Hesapla2();
                return;
            }
            a4 = double.TryParse(BTop4.Text, out outValue) ? Convert.ToDouble(BTop4.Text) : 0;
            Hesapla2();
        }
        private void BTop5_TextChanged(object sender, EventArgs e)
        {
            if (BTop5.Text == "")
            {
                a5 = 0;
                Hesapla2();
                return;
            }
            a5 = double.TryParse(BTop5.Text, out outValue) ? Convert.ToDouble(BTop5.Text) : 0;
            Hesapla2();
        }
        private void BTop6_TextChanged(object sender, EventArgs e)
        {
            if (BTop6.Text == "")
            {
                a6 = 0;
                Hesapla2();
                return;
            }
            a6 = double.TryParse(BTop6.Text, out outValue) ? Convert.ToDouble(BTop6.Text) : 0;
            Hesapla2();
        }
        private void BTop7_TextChanged(object sender, EventArgs e)
        {
            if (BTop7.Text == "")
            {
                a7 = 0;
                Hesapla2();
                return;
            }
            a7 = double.TryParse(BTop7.Text, out outValue) ? Convert.ToDouble(BTop7.Text) : 0;
            Hesapla2();
        }
        private void BTop8_TextChanged(object sender, EventArgs e)
        {
            if (BTop8.Text == "")
            {
                a8 = 0;
                Hesapla2();
                return;
            }
            a8 = double.TryParse(BTop8.Text, out outValue) ? Convert.ToDouble(BTop8.Text) : 0;
            Hesapla2();
        }
        private void BTop9_TextChanged(object sender, EventArgs e)
        {
            if (BTop9.Text == "")
            {
                a9 = 0;
                Hesapla2();
                return;
            }
            a9 = double.TryParse(BTop9.Text, out outValue) ? Convert.ToDouble(BTop9.Text) : 0;
            Hesapla2();
        }
        private void BTop10_TextChanged(object sender, EventArgs e)
        {
            if (BTop10.Text == "")
            {
                a10 = 0;
                Hesapla2();
                return;
            }
            a10 = double.TryParse(BTop10.Text, out outValue) ? Convert.ToDouble(BTop10.Text) : 0;
            Hesapla2();
        }
        void DataDisplay()
        {
            DtgOnay.Columns["Id"].Visible = false;
            DtgOnay.Columns["Satno"].HeaderText = "SAT NO";
            DtgOnay.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgOnay.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgOnay.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgOnay.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgOnay.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgOnay.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgOnay.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgOnay.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgOnay.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgOnay.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgOnay.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgOnay.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgOnay.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgOnay.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgOnay.Columns["Uctekilf"].Visible = false;
            DtgOnay.Columns["SiparisNo"].Visible = false;
            DtgOnay.Columns["DosyaYolu"].Visible = false;
            DtgOnay.Columns["PersonelId"].Visible = false;
            DtgOnay.Columns["FirmaBilgisi"].Visible = false;
            DtgOnay.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgOnay.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgOnay.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgOnay.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgOnay.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgOnay.Columns["BelgeTuru"].Visible = false;
            DtgOnay.Columns["BelgeNumarasi"].Visible = false;
            DtgOnay.Columns["BelgeTarihi"].Visible = false;
            DtgOnay.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgOnay.Columns["Donem"].HeaderText = "DÖNEM";
            DtgOnay.Columns["Donem"].DisplayIndex = 3;
            DtgOnay.Columns["SatOlusturmaTuru"].Visible = false;
            DtgOnay.Columns["RedNedeni"].Visible = false;
            DtgOnay.Columns["Durum"].Visible = false;
            DtgOnay.Columns["TeklifDurumu"].Visible = false;
            DtgOnay.Columns["SatinAlinanFirma"].HeaderText = "SATIN ALINAN FİRMA";
            DtgOnay.Columns["MailSiniri"].Visible = false;
            DtgOnay.Columns["MailDurumu"].Visible = false;
            DtgOnay.Columns["MlzTeslimAldTarih"].Visible = false;
            DtgOnay.Columns["HarcamaYapan"].Visible = false;
            DtgOnay.Columns["AselsanMailGondermeDate"].HeaderText = "ASELSAN ONAY MAİLİ GÖNDERME TARİHİ";
            DtgOnay.Columns["AselsanMailAlmaDate"].HeaderText = "ASELSAN ONAY MAİLİ ALMA TARİHİ";
            DtgOnay.Columns["OdemeMailGondermeDate"].Visible = false;
            DtgOnay.Columns["OdemeMailAlmaDate"].Visible = false;
        }
        void Hesapla4()
        {
            toplam3 = z1 + z2 + z3 + z4 + z5 + z6 + z7 + z8 + z9 + z10;
            GNT3.Text = toplam3.ToString("0.00") + " ₺";
        }
        void Hesapla3()
        {
            toplam2 = y1 + y2 + y3 + y4 + y5 + y6 + y7 + y8 + y9 + y10;
            GNT2.Text = toplam2.ToString("0.00") + " ₺";
        }
        void Hesapla2()
        {
            toplam1 = a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10;
            GNT1.Text = toplam1.ToString("0.00") + " ₺";
        }
        void Hesapla()
        {
            toplam = x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9 + x10;
            TxtGenelTop.Text = toplam.ToString("C2") + " ₺";
        }

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
                x4 = 0;
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

        void IslemAdimlari()
        {
            DtgSatIslemAdimlari.DataSource = satIslemAdimlarimanager.GetList();

            DtgSatIslemAdimlari.Columns["Id"].Visible = false;
            DtgSatIslemAdimlari.Columns["Siparisno"].Visible = false;
            DtgSatIslemAdimlari.Columns["Islem"].HeaderText = "İŞLEM ADIMI";
            DtgSatIslemAdimlari.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgSatIslemAdimlari.Columns["Tarih"].HeaderText = "TARİH";
            DtgSatIslemAdimlari.Columns["Tarih"].Width = 70;
            DtgSatIslemAdimlari.Columns["Islemyapan"].Width = 150;
            DtgSatIslemAdimlari.Columns["Islem"].Width = 420;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSatOnay"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void MalzemeList()
        {
            teklifsizSats = teklifsizSatManager.GetList(siparisNo);
            dataBinder.DataSource = teklifsizSats.ToDataTable();
            // DtgMalzemeList.DataSource = dataBinder;
        }

        void MalzemeList2()
        {
            fiyatTeklifiAls = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);
        }
        string belgeTuru, donem, satOlusturmaTuru, retNedeni;
        int teklifdurumu;
        private void DtgOnay_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgOnay.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            IslemAdimlari();
            id = DtgOnay.CurrentRow.Cells["Id"].Value.ConInt();
            siparisNo = DtgOnay.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosyayolu = DtgOnay.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            satno = DtgOnay.CurrentRow.Cells["SatNo"].Value.ConInt();
            formno = DtgOnay.CurrentRow.Cells["Formno"].Value.ConInt();
            masrafyeri = DtgOnay.CurrentRow.Cells["Masrafyeri"].Value.ToString();
            talepeden = DtgOnay.CurrentRow.Cells["Talepeden"].Value.ToString();
            bolum = DtgOnay.CurrentRow.Cells["Bolum"].Value.ToString();
            usbolgesi = DtgOnay.CurrentRow.Cells["Usbolgesi"].Value.ToString();
            abfno = DtgOnay.CurrentRow.Cells["Abfformno"].Value.ToString();
            istenentarih = DtgOnay.CurrentRow.Cells["Tarih"].Value.ConDate();
            gerekce = DtgOnay.CurrentRow.Cells["Gerekce"].Value.ToString();
            belgeTuru = DtgOnay.CurrentRow.Cells["BelgeTuru"].Value.ToString();
            masrafyerino = DtgOnay.CurrentRow.Cells["Masyerino"].Value.ToString();
            abfformno = DtgOnay.CurrentRow.Cells["Abfformno"].Value.ToString();
            butcekodukalemi = DtgOnay.CurrentRow.Cells["Burcekodu"].Value.ToString();
            satbirim = DtgOnay.CurrentRow.Cells["Satbirim"].Value.ToString();
            harcamaturu = DtgOnay.CurrentRow.Cells["Harcamaturu"].Value.ToString();
            belgeNumarasi = DtgOnay.CurrentRow.Cells["BelgeNumarasi"].Value.ToString();
            faturafirma = DtgOnay.CurrentRow.Cells["Faturafirma"].Value.ToString();
            ilgilikisi = DtgOnay.CurrentRow.Cells["Ilgilikisi"].Value.ToString();
            belgeTarihi = DtgOnay.CurrentRow.Cells["BelgeTarihi"].Value.ConDate();
            ucteklif = DtgOnay.CurrentRow.Cells["Uctekilf"].Value.ConInt();
            donem = DtgOnay.CurrentRow.Cells["Donem"].Value.ToString();
            satOlusturmaTuru = DtgOnay.CurrentRow.Cells["SatOlusturmaTuru"].Value.ToString();
            personelId = DtgOnay.CurrentRow.Cells["PersonelId"].Value.ConInt();
            firmaBilgisi = DtgOnay.CurrentRow.Cells["FirmaBilgisi"].Value.ToString();
            talepEdenPersonel = DtgOnay.CurrentRow.Cells["TalepEdenPersonel"].Value.ToString();
            personelSiparis = DtgOnay.CurrentRow.Cells["PersonelSiparis"].Value.ToString();
            unvani = DtgOnay.CurrentRow.Cells["Unvani"].Value.ToString();
            personelMasrafYerNo = DtgOnay.CurrentRow.Cells["PersonelMasYerNo"].Value.ToString();
            islemAdimi = DtgOnay.CurrentRow.Cells["IslemAdimi"].Value.ToString();
            satinAlinanFirma = DtgOnay.CurrentRow.Cells["SatinAlinanFirma"].Value.ToString();
            dosyayolu = DtgOnay.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            proje = DtgOnay.CurrentRow.Cells["Proje"].Value.ToString();
            teklifdurumu = DtgOnay.CurrentRow.Cells["Uctekilf"].Value.ConInt();
            retNedeni = DtgOnay.CurrentRow.Cells["RedNedeni"].Value.ToString();
            mlzTeslimTarihi = DtgOnay.CurrentRow.Cells["Tarih"].Value.ToString();
            string pageText3;
            TxtRetNedeni.Text = retNedeni;
            if (TxtRetNedeni.Text != "")
            {
                pageText3 = "RET GEREKÇESİ " + "( * )";


                tabPage2.Text = pageText3;

            }
            else
            {
                tabPage2.Text = "RET GEREKÇESİ";
            }

            satinAlinacakMalzemelers = satinAlinacakMalManager.GetList(siparisNo);
            satNos = satNoManager.GetList(siparisNo);
            MalzemeList();
            MalzemeList2();
            DtgSatIslemAdimlari.DataSource = satIslemAdimlarimanager.GetList(siparisNo);
            WebBrowser();

            FillTools();
            FillTools2();

            if (teklifdurumu == 0)
            {
                if (belgeTuru != "")
                {
                    panel2.Visible = false;
                    panel4.Visible = false;
                    panel5.Visible = false;
                    TxtGerekceHarcamasiYapilan.Text = DtgOnay.CurrentRow.Cells["Gerekce"].Value.ToString();
                    webBrowser5.Navigate(dosyayolu);
                    return;
                }
                if (talepeden == "MURAT DEMİRTAŞ      ")
                {
                    if (satOlusturmaTuru == "BAŞARAN")
                    {
                        panel4.Visible = false;
                        panel2.Visible = false;
                        panel5.Visible = false;
                        TxtGerekceTeklifsiz.Text = DtgOnay.CurrentRow.Cells["Gerekce"].Value.ToString();
                        webBrowser4.Navigate(dosyayolu);
                        return;
                    }
                    panel2.Visible = false;
                    panel4.Visible = false;
                    panel5.Visible = false;
                    TxtGerekceHarcamasiYapilan.Text = DtgOnay.CurrentRow.Cells["Gerekce"].Value.ToString();
                    webBrowser5.Navigate(dosyayolu);
                    return;
                }
                panel4.Visible = false;
                panel2.Visible = false;
                panel5.Visible = false;

                TxtGerekceTeklifsiz.Text = DtgOnay.CurrentRow.Cells["Gerekce"].Value.ToString();
                webBrowser4.Navigate(dosyayolu);
            }
            if (teklifdurumu == 1)
            {
                panel5.Visible = true;
                panel4.Visible = false;
                panel2.Visible = false;

                TxtGerekce.Text = DtgOnay.CurrentRow.Cells["Gerekce"].Value.ToString();
                webBrowser3.Navigate(dosyayolu);
            }

            foreach (FiyatTeklifiAl item in fiyatTeklifiAls)
            {
                toplamlar = +item.Btf;
            }

            Teklifler();

        }
        void Teklifler()
        {
            DtgMalzList.DataSource = fiyatTeklifiAls;

            DtgMalzList.Columns["Id"].Visible = false;
            DtgMalzList.Columns["Stokno"].HeaderText = "STOK NO";
            DtgMalzList.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzList.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzList.Columns["Firma1"].HeaderText = "FİRMA ADI";
            DtgMalzList.Columns["Firma2"].Visible = false;
            DtgMalzList.Columns["Firma3"].Visible = false;
            DtgMalzList.Columns["Siparisno"].Visible = false;
            DtgMalzList.Columns["Teklifdurumu"].Visible = false;
            DtgMalzList.Columns["Bbf"].HeaderText = "BİRİM FİYATI";
            DtgMalzList.Columns["Btf"].HeaderText = "TOPLAM FİYAT";
            DtgMalzList.Columns["Ibf"].Visible = false;
            DtgMalzList.Columns["Itf"].Visible = false;
            DtgMalzList.Columns["Ubf"].Visible = false;
            DtgMalzList.Columns["Utf"].Visible = false;
            DtgMalzList.Columns["Onaylananteklif"].Visible = false;

            LblTop2.Text = DtgMalzList.RowCount.ToString();
            Toplamlar();
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgMalzList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgMalzList.Rows[i].Cells["Btf"].Value);

            }
            LblGenelTop.Text = toplam.ToString("C2");
        }

        private void DtgOnay_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinderSat.Filter = DtgOnay.FilterString;
            TxtTop.Text = DtgOnay.RowCount.ToString();
        }

        private void DtgOnay_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderSat.Sort = DtgOnay.SortString;

        }
        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT işlemini Onaylamak istediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (satOlusturmaTuru == "HARCAMASI YAPILAN")
                {
                    satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Harcaması Yapılan Tamamalama", "SAT TAMAMLAMA");
                }
                else
                {
                    satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Alım Yapılacak Direktörlük", "ALIMI YAPILACAK SAT");
                }
                
                onaydurum = "Onaylandı.";
                yapilanislem = "SAT TEKLİFİ ONAYLANDI.";

                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, yapilanislem, islmeyapan, DateTime.Now);
                satIslemAdimlarimanager.Add(satIslem);
                SatOnayTarihiKayit();
                MessageBox.Show("Bilgiler Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onaydurum = "Onaylanmıştır";
                //Task.Factory.StartNew(() => MailSendMetot());
                SatDataGrid1();
                Temizle();
                TxtTop.Text = DtgOnay.RowCount.ToString();
            }
        }
        private void BtnOnay1_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT için Birinci Teklifi Onaylamak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "", "");
                satDataGridview1Manager.OnaylananTeklif(siparisNo, 1);
                onaydurum = "Onaylandı.";
                yapilanislem = "1. TEKLİF ONAYLANDI.";
                islmeyapan = infos[1].ToString();

                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, yapilanislem, islmeyapan, DateTime.Now);
                satIslemAdimlarimanager.Add(satIslem);

                SatOnayTarihiKayit();
                MessageBox.Show("Bilgiler Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onaydurum = "1. Teklif Onaylanmıştır.";
                System.Threading.Tasks.Task.Factory.StartNew(() => MailSendMetot());
                SatDataGrid1();
                TekilfleriTemizle();
                TxtTop.Text = DtgOnay.RowCount.ToString();

            }
        }
        private void BtnOnay2_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IF1.Text == "")
            {
                MessageBox.Show("Bu SAT İçin Sadece Bir Teklif Alınmıştır! Lütfen Onaylamak İçin Sadece Birinci Teklifi Onaylayınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT için İkinci Teklifi Onaylamak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo,"","");
                satDataGridview1Manager.OnaylananTeklif(siparisNo, 2);
                onaydurum = "Onaylandı.";
                yapilanislem = "2. TEKLİF ONAYLANDI.";
                islmeyapan = infos[1].ToString();
                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, yapilanislem, islmeyapan, DateTime.Now);
                satIslemAdimlarimanager.Add(satIslem);
                SatOnayTarihiKayit();
                MessageBox.Show("Bilgiler Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onaydurum = "2. Teklif Onaylanmıştır.";
                System.Threading.Tasks.Task.Factory.StartNew(() => MailSendMetot());
                SatDataGrid1();
                TekilfleriTemizle();
                TxtTop.Text = DtgOnay.RowCount.ToString();
            }
        }
        private void BtnOnay3_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (UF1.Text == "")
            {
                MessageBox.Show("Bu SAT İçin Sadece Bir Teklif Alınmıştır! Lütfen Onaylamak İçin Sadece Birinci Teklifi Onaylayınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT için Üçüncü Teklifi Onaylamak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo,"","");
                satDataGridview1Manager.OnaylananTeklif(siparisNo, 3);
                onaydurum = "Onaylandı.";
                yapilanislem = "3. TEKLİF ONAYLANDI.";
                islmeyapan = infos[1].ToString();
                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, yapilanislem, islmeyapan, DateTime.Now);
                satIslemAdimlarimanager.Add(satIslem);
                SatOnayTarihiKayit();
                MessageBox.Show("Bilgiler Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onaydurum = "3. Teklif Onaylanmıştır.";
                System.Threading.Tasks.Task.Factory.StartNew(() => MailSendMetot());
                SatDataGrid1();
                TekilfleriTemizle();
                TxtTop.Text = DtgOnay.RowCount.ToString();
            }
        }

        private void BtnReddet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT işlemini Ret Etmek istediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                FrmSatOnOnayRed frmSatOnOnayRed = new FrmSatOnOnayRed();
                frmSatOnOnayRed.ShowDialog();
                rednedeni = Properties.Settings.Default.RedNedeni.ToString();
                if (rednedeni == "" || rednedeni == "sil")
                {
                    MessageBox.Show("Lütfen Ret Nedenini Boş Geçmeyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                satDataGridview1Manager.SatRed(siparisNo, rednedeni);
                teklifsizSatManager.SatMalzemeDurumGuncelle(siparisNo);

                yapilanislem = "SAT ONAY İŞLEMİ: REDDEDİLDİ";
                islmeyapan = infos[1].ToString();
                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, yapilanislem, islmeyapan, DateTime.Now);
                satIslemAdimlarimanager.Add(satIslem);
                MessageBox.Show("Bilgiler Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SatDataGrid1();
                Temizle();
                TxtTop.Text = DtgOnay.RowCount.ToString();
                rednedeni = "";
                FrmAnaSayfa frmAnaSayfa = new FrmAnaSayfa();
                frmAnaSayfa.ToplamSayilar();
                #region RedEskiKodlar
                /*
                //teklifsizSatManager.Delete(siparisNo);
                teklifsizSatManager.TeklifsizSatDurumGuncelle(siparisNo);
                satDataGridview1Manager.Delete(id);

                //satDataGridview1Manager.DurumGuncelleRed(siparisNo);

                onaydurum = "Reddildi.";
                yapilanislem = "SAT ONAY İŞLEMİ: REDDEDİLDİ";

                Reddedilenler reddedilenler = new Reddedilenler(formno,satNo,masrafyeri,talepeden,bolum,usbolgesi,abfformno,istenentarih,gerekce,siparisNo,dosyayolu,rednedeni, "Onaylandı", "Alındı", donem,personelId,butcekodu,satbirim,harcamaturu,faturafirma,ilgilikisi,masrafyerino,ucteklif,firmaBilgisi,talepEdenPersonel,personelSiparis,unvani,personelMasrafYerNo,islemAdimi, satOlusturmaTuru);
                
                reddedilenlerManager.Add(reddedilenler);
                ReddedilenMalzemeEkle2();
                satDataGridview1Manager.Delete(id);
                satinAlinacakMalManager.Delete(siparisNo);

                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, yapilanislem, islmeyapan, DateTime.Now);
                satIslemAdimlarimanager.Add(satIslem);

                MessageBox.Show("Bilgiler Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Task.Factory.StartNew(() => MailSendMetot());
                
                SatDataGrid1();
                Temizle();
                TxtTop.Text = DtgOnay.RowCount.ToString();
                */
                #endregion
            }
        }

        private void BtnReddet2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT işlemini Ret Etmek istediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                FrmSatOnOnayRed frmSatOnOnayRed = new FrmSatOnOnayRed();
                frmSatOnOnayRed.ShowDialog();
                rednedeni = Properties.Settings.Default.RedNedeni.ToString();

                if (rednedeni == "" || rednedeni == "sil")
                {
                    MessageBox.Show("Lütfen Ret Nedenini Boş Geçmeyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                satDataGridview1Manager.SatRed(siparisNo, rednedeni);
                teklifiAlinanManager.SatTekliflerDurumGuncelle(siparisNo);

                yapilanislem = "SAT ONAY İŞLEMİ: REDDEDİLDİ.";
                islmeyapan = infos[1].ToString();
                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, yapilanislem, islmeyapan, DateTime.Now);
                satIslemAdimlarimanager.Add(satIslem);

                MessageBox.Show("Bilgiler Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SatDataGrid1();
                TekilfleriTemizle();
                TxtTop.Text = DtgOnay.RowCount.ToString();
                rednedeni = "";
                FrmAnaSayfa frmAnaSayfa = new FrmAnaSayfa();
                frmAnaSayfa.ToplamSayilar();

                #region RedEskiKodlar
                /*
                Reddedilenler reddedilenler = new Reddedilenler(formno,satNo,masrafyeri,talepeden,bolum,usbolgesi,abfformno,istenentarih,gerekce,siparisNo,dosyayolu,rednedeni, "Onaylandı", "Alındı", donem, personelId,butcekodu,satbirim,harcamaturu,faturafirma,ilgilikisi,masrafyerino,ucteklif,firmaBilgisi,talepEdenPersonel,personelSiparis,unvani, personelMasrafYerNo,islemAdimi, satOlusturmaTuru);
                reddedilenlerManager.Add(reddedilenler);
                ReddedilenMalzemeEkle();
                satDataGridview1Manager.Delete(id);
                satinAlinacakMalManager.Delete(siparisNo);
                teklifiAlinanManager.DurumGuncelleRed(siparisNo);
                //teklifiAlinanManager.Delete(siparisNo);

                onaydurum = "Reddildi.";
                yapilanislem = "SAT ONAY İŞLEMİ: REDDEDİLDİ.";

                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, yapilanislem, islmeyapan, DateTime.Now);
                satIslemAdimlarimanager.Add(satIslem);

                MessageBox.Show("Bilgiler Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Task.Factory.StartNew(() => MailSendMetot());

                SatDataGrid1();
                TekilfleriTemizle();
                TxtTop.Text = DtgOnay.RowCount.ToString();
                rednedeni = "";
                */
                #endregion
            }
        }
        void ReddedilenMalzemeEkle2()
        {
            List<ReddedilenMalzeme> list = new List<ReddedilenMalzeme>();
            if (s1.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(s1.Text, tt1.Text, mm1.Text.ConInt(), bb1.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (s2.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(s2.Text, tt2.Text, mm2.Text.ConInt(), bb2.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (s3.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(s3.Text, tt3.Text, mm3.Text.ConInt(), bb3.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (s4.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(s4.Text, tt4.Text, mm4.Text.ConInt(), bb4.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (s5.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(s5.Text, tt5.Text, mm5.Text.ConInt(), bb5.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (s6.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(s6.Text, tt6.Text, mm6.Text.ConInt(), bb6.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (s7.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(s7.Text, tt7.Text, mm7.Text.ConInt(), bb7.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (s8.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(s8.Text, tt8.Text, mm8.Text.ConInt(), bb8.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (s9.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(s9.Text, tt9.Text, mm9.Text.ConInt(), bb9.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (s10.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(s10.Text, tt10.Text, mm10.Text.ConInt(), bb10.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (list.Count == 0)
            {
                MessageBox.Show("Eleman Bulunamadı");
                return;
            }
            foreach (ReddedilenMalzeme item in list)
            {
                reddedilenMalzemeManager.Add(item);
            }

        }
        void ReddedilenMalzemeEkle()
        {
            List<ReddedilenMalzeme> list = new List<ReddedilenMalzeme>();
            if (sn1.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(sn1.Text, Tanim1.Text, Miktar1.Text.ConInt(), Birim1.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (sn2.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(sn2.Text, Tanim2.Text, Miktar2.Text.ConInt(), Birim2.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (sn3.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(sn3.Text, Tanim3.Text, Miktar3.Text.ConInt(), Birim3.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (sn4.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(sn4.Text, Tanim4.Text, Miktar4.Text.ConInt(), Birim4.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (sn5.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(sn5.Text, Tanim5.Text, Miktar5.Text.ConInt(), Birim5.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (sn6.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(sn6.Text, Tanim6.Text, Miktar6.Text.ConInt(), Birim6.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (sn7.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(sn7.Text, Tanim7.Text, Miktar7.Text.ConInt(), Birim7.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (sn8.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(sn8.Text, Tanim8.Text, Miktar8.Text.ConInt(), Birim8.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (sn9.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(sn9.Text, Tanim9.Text, Miktar9.Text.ConInt(), Birim9.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (sn10.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(sn10.Text, Tanim10.Text, Miktar10.Text.ConInt(), Birim10.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (list.Count == 0)
            {
                MessageBox.Show("Eleman Bulunamadı");
                return;
            }
            foreach (ReddedilenMalzeme item in list)
            {
                reddedilenMalzemeManager.Add(item);
            }

        }
        private void FillTools2()
        {
            TekilfleriTemizle();

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
                sn1.Text = item.Stokno;
                Tanim1.Text = item.Tanim;
                Miktar1.Text = item.Miktar.ToString();
                Birim1.Text = item.Birim;
                BF1.Text = item.Firma1;
                BBirimF1.Text = item.Bbf.ToString();
                BTop1.Text = item.Btf.ToString();
                IF1.Text = item.Firma2;
                IBirimF1.Text = item.Ibf.ToString();
                ITop1.Text = item.Itf.ToString();
                UF1.Text = item.Firma3;
                UBirimF1.Text = item.Ubf.ToString();
                UTop1.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 1)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[1];
                sn2.Text = item.Stokno;
                Tanim2.Text = item.Tanim;
                Miktar2.Text = item.Miktar.ToString();
                Birim2.Text = item.Birim;
                BF2.Text = item.Firma1;
                BBirimF2.Text = item.Bbf.ToString();
                BTop2.Text = item.Btf.ToString();
                IF2.Text = item.Firma2;
                IBirimF2.Text = item.Ibf.ToString();
                ITop2.Text = item.Itf.ToString();
                UF2.Text = item.Firma3;
                UBirimF2.Text = item.Ubf.ToString();
                UTop2.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 2)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[2];
                sn3.Text = item.Stokno;
                Tanim3.Text = item.Tanim;
                Miktar3.Text = item.Miktar.ToString();
                Birim3.Text = item.Birim;
                BF3.Text = item.Firma1;
                BBirimF3.Text = item.Bbf.ToString();
                BTop3.Text = item.Btf.ToString();
                IF3.Text = item.Firma2;
                IBirimF3.Text = item.Ibf.ToString();
                ITop3.Text = item.Itf.ToString();
                UF3.Text = item.Firma3;
                UBirimF3.Text = item.Ubf.ToString();
                UTop3.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 3)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[3];
                sn4.Text = item.Stokno;
                Tanim4.Text = item.Tanim;
                Miktar4.Text = item.Miktar.ToString();
                Birim4.Text = item.Birim;
                BF4.Text = item.Firma1;
                BBirimF4.Text = item.Bbf.ToString();
                BTop4.Text = item.Btf.ToString();
                IF4.Text = item.Firma2;
                IBirimF4.Text = item.Ibf.ToString();
                ITop4.Text = item.Itf.ToString();
                UF4.Text = item.Firma3;
                UBirimF4.Text = item.Ubf.ToString();
                UTop4.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 4)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[4];
                sn5.Text = item.Stokno;
                Tanim5.Text = item.Tanim;
                Miktar5.Text = item.Miktar.ToString();
                Birim5.Text = item.Birim;
                BF5.Text = item.Firma1;
                BBirimF5.Text = item.Bbf.ToString();
                BTop5.Text = item.Btf.ToString();
                IF5.Text = item.Firma2;
                IBirimF5.Text = item.Ibf.ToString();
                ITop5.Text = item.Itf.ToString();
                UF5.Text = item.Firma3;
                UBirimF5.Text = item.Ubf.ToString();
                UTop5.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 5)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[5];
                sn6.Text = item.Stokno;
                Tanim6.Text = item.Tanim;
                Miktar6.Text = item.Miktar.ToString();
                Birim6.Text = item.Birim;
                BF6.Text = item.Firma1;
                BBirimF6.Text = item.Bbf.ToString();
                BTop6.Text = item.Btf.ToString();
                IF6.Text = item.Firma2;
                IBirimF6.Text = item.Ibf.ToString();
                ITop6.Text = item.Itf.ToString();
                UF6.Text = item.Firma3;
                UBirimF6.Text = item.Ubf.ToString();
                UTop6.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 6)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[6];
                sn7.Text = item.Stokno;
                Tanim7.Text = item.Tanim;
                Miktar7.Text = item.Miktar.ToString();
                Birim7.Text = item.Birim;
                BF7.Text = item.Firma1;
                BBirimF7.Text = item.Bbf.ToString();
                BTop7.Text = item.Btf.ToString();
                IF7.Text = item.Firma2;
                IBirimF7.Text = item.Ibf.ToString();
                ITop7.Text = item.Itf.ToString();
                UF7.Text = item.Firma3;
                UBirimF7.Text = item.Ubf.ToString();
                UTop7.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 7)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[7];
                sn8.Text = item.Stokno;
                Tanim8.Text = item.Tanim;
                Miktar8.Text = item.Miktar.ToString();
                Birim8.Text = item.Birim;
                BF8.Text = item.Firma1;
                BBirimF8.Text = item.Bbf.ToString();
                BTop8.Text = item.Btf.ToString();
                IF8.Text = item.Firma2;
                IBirimF8.Text = item.Ibf.ToString();
                ITop8.Text = item.Itf.ToString();
                UF8.Text = item.Firma3;
                UBirimF8.Text = item.Ubf.ToString();
                UTop8.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 8)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[8];
                sn9.Text = item.Stokno;
                Tanim9.Text = item.Tanim;
                Miktar9.Text = item.Miktar.ToString();
                Birim9.Text = item.Birim;
                BF9.Text = item.Firma1;
                BBirimF9.Text = item.Bbf.ToString();
                BTop9.Text = item.Btf.ToString();
                IF9.Text = item.Firma2;
                IBirimF9.Text = item.Ibf.ToString();
                ITop9.Text = item.Itf.ToString();
                UF9.Text = item.Firma3;
                UBirimF9.Text = item.Ubf.ToString();
                UTop9.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 9)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[9];
                sn10.Text = item.Stokno;
                Tanim10.Text = item.Tanim;
                Miktar10.Text = item.Miktar.ToString();
                Birim10.Text = item.Birim;
                BF10.Text = item.Firma1;
                BBirimF10.Text = item.Bbf.ToString();
                BTop10.Text = item.Btf.ToString();
                IF10.Text = item.Firma2;
                IBirimF10.Text = item.Ibf.ToString();
                ITop10.Text = item.Itf.ToString();
                UF10.Text = item.Firma3;
                UBirimF10.Text = item.Ubf.ToString();
                UTop10.Text = item.Utf.ToString();
            }
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
                /*panel5.Visible = true;
                panel4.Visible = false;
                panel2.Visible = false;
                FillTools2();*/
                return;
            }
            if (satOlusturmaTuru == "HARCAMASI YAPILAN")
            {
                TeklifsizSat item = teklifsizSats[0];
                LblToplam.Text = item.Tutar.ToString();
                return;
            }
            if (belgeTuru != "")
            {
                TeklifsizSat item = teklifsizSats[0];
                LblToplam.Text = item.Tutar.ToString();
                return;
            }
            if (teklifsizSats.Count > 0)
            {
                TeklifsizSat item = teklifsizSats[0];
                s1.Text = item.Stokno;
                tt1.Text = item.Tanim;
                mm1.Text = item.Miktar.ToString();
                bb1.Text = item.Birim;
                Tutar1.Text = item.Tutar.ToString();
            }

            if (teklifsizSats.Count > 1)
            {
                TeklifsizSat item = teklifsizSats[1];
                s2.Text = item.Stokno;
                tt2.Text = item.Tanim;
                mm2.Text = item.Miktar.ToString();
                bb2.Text = item.Birim;
                Tutar2.Text = item.Tutar.ToString();
            }

            if (teklifsizSats.Count > 2)
            {
                TeklifsizSat item = teklifsizSats[2];
                s3.Text = item.Stokno;
                tt3.Text = item.Tanim;
                mm3.Text = item.Miktar.ToString();
                bb3.Text = item.Birim;
                Tutar3.Text = item.Tutar.ToString();
            }

            if (teklifsizSats.Count > 3)
            {
                TeklifsizSat item = teklifsizSats[3];
                s4.Text = item.Stokno;
                tt4.Text = item.Tanim;
                mm4.Text = item.Miktar.ToString();
                bb4.Text = item.Birim;
                Tutar4.Text = item.Tutar.ToString();
            }

            if (teklifsizSats.Count > 4)
            {
                TeklifsizSat item = teklifsizSats[4];
                s5.Text = item.Stokno;
                tt5.Text = item.Tanim;
                mm5.Text = item.Miktar.ToString();
                bb5.Text = item.Birim;
                Tutar5.Text = item.Tutar.ToString();
            }

            if (teklifsizSats.Count > 5)
            {


                TeklifsizSat item = teklifsizSats[5];
                s6.Text = item.Stokno;
                tt6.Text = item.Tanim;
                mm6.Text = item.Miktar.ToString();
                bb6.Text = item.Birim;
                Tutar6.Text = item.Tutar.ToString();
            }

            if (teklifsizSats.Count > 6)
            {
                TeklifsizSat item = teklifsizSats[6];
                s7.Text = item.Stokno;
                tt7.Text = item.Tanim;
                mm7.Text = item.Miktar.ToString();
                bb7.Text = item.Birim;
                Tutar7.Text = item.Tutar.ToString();
            }

            if (teklifsizSats.Count > 7)
            {

                TeklifsizSat item = teklifsizSats[7];
                s8.Text = item.Stokno;
                tt8.Text = item.Tanim;
                mm8.Text = item.Miktar.ToString();
                bb8.Text = item.Birim;
                Tutar8.Text = item.Tutar.ToString();
            }

            if (teklifsizSats.Count > 8)
            {
                TeklifsizSat item = teklifsizSats[8];
                s9.Text = item.Stokno;
                tt9.Text = item.Tanim;
                mm9.Text = item.Miktar.ToString();
                bb9.Text = item.Birim;
                Tutar9.Text = item.Tutar.ToString();
            }

            if (teklifsizSats.Count > 9)
            {
                TeklifsizSat item = teklifsizSats[9];
                s10.Text = item.Stokno;
                tt10.Text = item.Tanim;
                mm10.Text = item.Miktar.ToString();
                bb10.Text = item.Birim;
                Tutar10.Text = item.Tutar.ToString();
            }

            WebBrowser();
        }
        private void Temizle()
        {
            s1.Clear(); tt1.Clear(); mm1.Clear(); bb1.Clear(); s2.Clear(); tt2.Clear(); mm2.Clear(); bb2.Clear();
            s3.Clear(); tt3.Clear(); mm3.Clear(); bb3.Clear(); s4.Clear(); tt4.Clear(); mm4.Clear(); bb4.Clear();
            s5.Clear(); tt5.Clear(); mm5.Clear(); bb5.Clear(); s6.Clear(); tt6.Clear(); mm6.Clear(); bb6.Clear();
            s7.Clear(); tt7.Clear(); mm7.Clear(); mm7.Clear(); s8.Clear(); tt8.Clear(); mm8.Clear(); bb8.Clear();
            s9.Clear(); tt9.Clear(); mm9.Clear(); mm9.Clear(); s10.Clear(); tt10.Clear(); mm10.Clear(); bb10.Clear();

            Tutar1.Clear(); Tutar2.Clear(); Tutar3.Clear(); Tutar4.Clear(); Tutar5.Clear(); Tutar6.Clear(); Tutar7.Clear(); Tutar8.Clear(); Tutar9.Clear(); Tutar10.Clear(); webBrowser1.Navigate(""); bb7.Clear();
            Tutar4.Clear();
            TxtGerekceHarcamasiYapilan.Clear();
            TxtGerekceTeklifsiz.Clear();
            TxtGerekce.Clear();
            TxtGerekceHarcamasiYapilan.Clear(); webBrowser5.Navigate("");
            TxtGerekceTeklifsiz.Clear(); webBrowser4.Navigate(""); TxtGerekce.Clear(); webBrowser3.Navigate("");

        }
        private void TekilfleriTemizle()
        {
            sn1.Clear(); Tanim1.Clear(); Miktar1.Clear(); Birim1.Clear(); BF1.Clear(); BBirimF1.Clear(); BTop1.Clear(); IF1.Clear(); IBirimF1.Clear(); ITop1.Clear(); UF1.Clear(); UBirimF1.Clear(); UTop1.Clear();
            sn2.Clear(); Tanim2.Clear(); Miktar2.Clear(); Birim2.Clear(); BF2.Clear(); BBirimF2.Clear(); BTop2.Clear(); IF2.Clear(); IBirimF2.Clear(); ITop2.Clear(); UF2.Clear(); UBirimF2.Clear(); UTop2.Clear();
            sn3.Clear(); Tanim3.Clear(); Miktar3.Clear(); Birim3.Clear(); BF3.Clear(); BBirimF3.Clear(); BTop3.Clear(); IF3.Clear(); IBirimF3.Clear(); ITop3.Clear(); UF3.Clear(); UBirimF3.Clear(); UTop3.Clear();
            sn4.Clear(); Tanim4.Clear(); Miktar4.Clear(); Birim4.Clear(); BF4.Clear(); BBirimF4.Clear(); BTop4.Clear(); IF4.Clear(); IBirimF4.Clear(); ITop4.Clear(); UF4.Clear(); UBirimF4.Clear(); UTop4.Clear();
            sn5.Clear(); Tanim5.Clear(); Miktar5.Clear(); Birim5.Clear(); BF5.Clear(); BBirimF5.Clear(); BTop5.Clear(); IF5.Clear(); IBirimF5.Clear(); ITop5.Clear(); UF5.Clear(); UBirimF5.Clear(); UTop5.Clear();
            sn6.Clear(); Tanim6.Clear(); Miktar6.Clear(); Birim6.Clear(); BF6.Clear(); BBirimF6.Clear(); BTop6.Clear(); IF6.Clear(); IBirimF6.Clear(); ITop6.Clear(); UF6.Clear(); UBirimF6.Clear(); UTop6.Clear();
            sn7.Clear(); Tanim7.Clear(); Miktar7.Clear(); Birim7.Clear(); BF7.Clear(); BBirimF7.Clear(); BTop7.Clear(); IF7.Clear(); IBirimF7.Clear(); ITop7.Clear(); UF7.Clear(); UBirimF7.Clear(); UTop7.Clear();
            sn8.Clear(); Tanim8.Clear(); Miktar8.Clear(); Birim8.Clear(); BF8.Clear(); BBirimF8.Clear(); BTop8.Clear(); IF8.Clear(); IBirimF8.Clear(); ITop8.Clear(); UF8.Clear(); UBirimF8.Clear(); UTop8.Clear();
            sn9.Clear(); Tanim9.Clear(); Miktar9.Clear(); Birim9.Clear(); BF9.Clear(); BBirimF9.Clear(); BTop9.Clear(); IF9.Clear(); IBirimF9.Clear(); ITop9.Clear(); UF9.Clear(); UBirimF9.Clear(); UTop9.Clear();
            sn10.Clear(); Tanim10.Clear(); Miktar10.Clear(); Birim10.Clear(); BF10.Clear(); BBirimF10.Clear(); BTop10.Clear(); IF10.Clear(); IBirimF10.Clear(); ITop10.Clear(); UF10.Clear(); UBirimF10.Clear(); UTop10.Clear();

        }
        private void WebBrowser()
        {
            try
            {
                webBrowser2.Navigate(dosyayolu);
            }
            catch
            {
                return;
            }

        }
        void SatOnayTarihiKayit()
        {
            SatOnayTarihi satOnayTarihi = new SatOnayTarihi(siparisNo);
            satOnayTarihiManager.UpdateOnay(satOnayTarihi);
        }
        string harcamaYapan = "";
        private void BtnOnaylaT_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(formno + " İş Akış Nolu SAT İşlemini Onaylamak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                DosyaAdiDegistir();
                satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo,"","");

                tamamlanantarih = DateTime.Now;
                islemAdimi = "TAMAMLANAN SATLAR";
                if (satbirim == "PRJ.DİR.SATIN ALMA")
                {
                    harcamaYapan = "EBRU BAYDAŞ";
                }
                if (satbirim == "BSRN GN.MDL.SATIN ALMA")
                {
                    harcamaYapan = "TURGUT AYDIN";
                }
                toplam = LblToplam.Text.ConDouble();

                string usBolgesiProje = bolgeKayitManager.BolgeProjeList(usbolgesi);
                string garantiDurumu = bolgeKayitManager.BolgeGarantiDurumList(usbolgesi);

                if (usBolgesiProje == "")
                {

                }

                Tamamlanan tamamlanan = new Tamamlanan(satNo.ToString(), formno, masrafyeri, talepeden, bolum, usbolgesi, abfformno, istenentarih, tamamlanantarih, gerekce, butcekodukalemi, satbirim, harcamaturu, belgeTuru, belgeNumarasi, belgeTarihi,
                    faturafirma, ilgilikisi, masrafyerino, toplam, hedefdosya, siparisNo, ucteklif, islemAdimi, donem, satOlusturmaTuru, proje, satinAlinanFirma, harcamaYapan, usBolgesiProje, garantiDurumu, "");
                string control = tamamlananManager.Add(tamamlanan);

                if (control != "OK")
                {
                    MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                TamamlananMalzeme tamamlananMalzeme = new TamamlananMalzeme("", "", 0, "", "", 0,
                    LblToplam.Text.ConDouble(), siparisNo);

                tamamlananMalzemeManager.Add(tamamlananMalzeme);

                satDataGridview1Manager.Delete(id);
                satinAlinacakMalManager.Delete(siparisNo);

                yapilanislem = "SAT İŞLEMİ TAMAMLANDI.";
                string islmeyapan = infos[1].ToString();
                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, yapilanislem, islmeyapan, DateTime.Now);
                satIslemAdimlarimanager.Add(satIslem);
                SatOnayTarihiKayit();
                //CreateWord();
                MessageBox.Show("Bilgiler Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onaydurum = "Onaylanmıştır";
                //Task.Factory.StartNew(() => MailSendMetot());
                SatDataGrid1();
                Temizle();
                TxtTop.Text = DtgOnay.RowCount.ToString();
                LblToplam.Text = "0.00 ₺";
            }
        }
        string projeKodu = "", butcekodu = "", bucekalemi = "", proje = "";
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
            SatOnayTarihi satOnayTarihi = satOnayTarihiManager.Get(siparisNo);


            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            //object filePath = "C:\\Users\\MAYıldırım\\Desktop\\MP-FR-006 SATIN ALMA FORMU REV (00).docx"; // taslak yolu
            object filePath = "Z:\\DTS\\SATIN ALMA\\Folder\\MP-FR-006 SATIN ALMA FORMU REV (00)5.docx";
            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["IsAkisNo"].Range.Text = formno.ToString();
            wBookmarks["FormNo"].Range.Text = satNo.ToString();
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

            wBookmarks["Tanim1"].Range.Text = "DETAY EKTE VERİLMİŞTİR.";
            wBookmarks["Miktar1"].Range.Text = "1";
            wBookmarks["Birim1"].Range.Text = "ADET";
            wBookmarks["BF1"].Range.Text = LblToplam.Text;
            wBookmarks["Tutar1"].Range.Text = LblToplam.Text;

            wDoc.SaveAs2(hedefdosya + "\\" + satNo + ".docx");
            wDoc.Close();
            wApp.Quit(false);
        }


        void DosyaAdiDegistir()
        {
            /*string root = @"C:\STS";
            string subdir = @"C:\STS\GEÇİCİ SAT DOSYALARI\";
            string hedef = @"C:\STS\SAT DOSYALARI\";*/
            string root = @"Z:\DTS";
            string hedef = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";
            string subdir = @"Z:\DTS\SATIN ALMA\GEÇİCİ SAT DOSYALARI\";
            if (!Directory.Exists(root))
            {
                MessageBox.Show(formno + " SAT Form numarasının dosyası bulunamadı.");
                return;
            }
            if (!Directory.Exists(subdir))
            {
                MessageBox.Show(formno + " SAT Form numarasının dosyası bulunamadı.");
                return;
            }
            kaynakdosya = subdir + formno;
            if (!Directory.Exists(kaynakdosya))
            {
                if (!Directory.Exists(hedef + formno))
                {
                    hedefdosya = hedef + formno;
                    return;
                }
                MessageBox.Show(formno + " SAT Form numarasının dosyası bulunamadı.");
                return;
            }
            if (!Directory.Exists(hedef))
            {
                Directory.CreateDirectory(hedef);

            }

            satNo = satNoManager.Add(new SatNo(siparisNo));
            //int outValue = 0;
            /*if (!int.TryParse(satNo, out outValue))
            {
                MessageBox.Show("Klasör No Bulunamadı");
                return;
            }*/

            hedefdosya = hedef + satNo;
            Directory.CreateDirectory(hedefdosya);

            foreach (string item in Directory.GetFiles(kaynakdosya, "*.*", SearchOption.TopDirectoryOnly))
            {
                string newPath = item.Replace(formno.ToString(), satNo.ToString());
                newPath = newPath.Replace("GEÇİCİ SAT DOSYALARI", "SAT DOSYALARI");
                File.Copy(item, newPath, true);
            }
            Directory.Delete(kaynakdosya, true);
        }
        void MailSendMetot()
        {
            /*MailSend("SAT Onay İşlemi ", "Merhaba; \n\n" + masrafyerino + " Masraf Yeri Numaralı SAT Kaydı, Onay Onay Aşamasında " + islmeyapan +
                " tarafından " + onaydurum + "\n\nİyi Çalışmalar.", new List<string>() { "gulsahotaci@mubvan.net" });*/
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
        #region KeyPres
        private void sn1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void sn2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void sn3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void sn4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void sn5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void sn6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void sn7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void sn8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void sn9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void sn10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tanim1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tanim2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tanim3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tanim4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tanim5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tanim6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tanim7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tanim8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tanim9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tanim10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Miktar1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Miktar2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Miktar3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Miktar4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Miktar5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Miktar6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Miktar7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Miktar8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Miktar9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Miktar10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Birim1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Birim2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Birim3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Birim4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Birim5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Birim6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Birim7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Birim8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Birim9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Birim10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BF1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BF2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BF3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BF4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BF5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BF6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BF7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BF8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BF9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BF10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BBirimF1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BBirimF2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BBirimF3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BBirimF4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BBirimF5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BBirimF6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BBirimF7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BBirimF8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BBirimF9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BBirimF10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BTop1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BTop2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BTop3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BTop4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BTop5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BTop6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BTop7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BTop8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BTop9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BTop10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void sn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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

        private void s9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tt9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void BtnRed_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT işlemini Ret Etmek istediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                FrmSatOnOnayRed frmSatOnOnayRed = new FrmSatOnOnayRed();
                frmSatOnOnayRed.ShowDialog();
                rednedeni = Properties.Settings.Default.RedNedeni.ToString();
                if (rednedeni == "" || rednedeni == "sil")
                {
                    MessageBox.Show("Lütfen Ret Nedenini Boş Geçmeyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                satDataGridview1Manager.SatRed(siparisNo, rednedeni);
                teklifsizSatManager.SatMalzemeDurumGuncelle(siparisNo);

                yapilanislem = "SAT ONAY İŞLEMİ: REDDEDİLDİ";
                islmeyapan = infos[1].ToString();
                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, yapilanislem, islmeyapan, DateTime.Now);
                satIslemAdimlarimanager.Add(satIslem);
                MessageBox.Show("Bilgiler Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SatDataGrid1();
                Temizle();
                TxtTop.Text = DtgOnay.RowCount.ToString();
                rednedeni = "";
                FrmAnaSayfa frmAnaSayfa = new FrmAnaSayfa();
                frmAnaSayfa.ToplamSayilar();
            }
        }

        private void BtnOnay_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT için Teklifi Onaylamak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (satOlusturmaTuru=="HARCAMASI YAPILAN")
                {
                    string usBolgesiProje = bolgeKayitManager.BolgeProjeList(usbolgesi);
                    string garantiDurumu = bolgeKayitManager.BolgeGarantiDurumList(usbolgesi);

                    Tamamlanan tamamlanan = new Tamamlanan(satno.ToString(), formno, masrafyeri, talepeden, bolum, usbolgesi, abfformno, istenentarih, DateTime.Now, gerekce, butcekodukalemi, satbirim, harcamaturu, belgeTuru, belgeNumarasi, belgeTarihi,
                        faturafirma, ilgilikisi, masrafyerino, toplamlar, dosyayolu, siparisNo, 0, "TAMAMLANAN SATLAR", donem, satOlusturmaTuru, proje, satinAlinanFirma, harcamaYapan, usBolgesiProje, garantiDurumu, mlzTeslimTarihi);
                    string control = tamamlananManager.Add(tamamlanan);
                    if (control != "OK")
                    {
                        MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (FiyatTeklifiAl item in fiyatTeklifiAls)
                    {
                        TamamlananMalzeme tamamlananMalzeme = new TamamlananMalzeme(item.Stokno, item.Tanim, item.Miktar, item.Birim, item.Firma1, item.Bbf,
                        item.Btf, siparisNo);

                        string mesaj = tamamlananMalzemeManager.Add(tamamlananMalzeme);
                        if (mesaj != "OK")
                        {
                            MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    satDataGridview1Manager.Delete(id);
                    satinAlinacakMalManager.Delete(siparisNo);

                    yapilanislem = "SAT İŞLEMİ TAMAMLANDI.";
                    SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
                    satIslemAdimlarimanager.Add(satIslemAdimlari);


                }
                else
                {
                    if (faturafirma != "BAŞARAN İLER TEKNOLOJİ")
                    {
                        if (satbirim== "BSRN GN.MDL.SATIN ALMA")
                        {
                            satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Alım Yapılacak Müdürlük", "ALIMI BEKLEYEN SAT");
                        }
                        else
                        {
                            satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Alım Yapılacak Direktörlük", "ALIMI BEKLEYEN SAT");
                        }
                        
                    }
                    else
                    {
                        if (satbirim == "BSRN GN.MDL.SATIN ALMA")
                        {
                            satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Alım Yapılacak Müdürlük", "ALIMI BEKLEYEN SAT");
                        }
                        else
                        {
                            satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Alım Yapılacak Direktörlük", "ALIMI BEKLEYEN SAT");
                        }
                    }
                }
                

                satDataGridview1Manager.OnaylananTeklif(siparisNo, 1);
                onaydurum = "Onaylandı.";
                yapilanislem = "TEKLİF ONAYLANDI.";
                islmeyapan = infos[1].ToString();

                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, yapilanislem, islmeyapan, DateTime.Now);
                satIslemAdimlarimanager.Add(satIslem);

                MessageBox.Show("Bilgiler Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onaydurum = "Teklif Onaylanmıştır.";
                DtgMalzList.DataSource = null;
                DtgSatIslemAdimlari.DataSource = null;
                LblGenelTop.Text = "00";
                LblTop2.Text = "00";
                TxtRetNedeni.Clear();
                webBrowser2.Navigate("");
                MalzemeList();
                SatDataGrid1();
                TxtTop.Text = DtgOnay.RowCount.ToString();

            }
        }

        private void DtgOnay_KeyDown(object sender, KeyEventArgs e)
        {
            if (DtgOnay.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            IslemAdimlari();
            id = DtgOnay.CurrentRow.Cells["Id"].Value.ConInt();
            siparisNo = DtgOnay.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosyayolu = DtgOnay.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            satno = DtgOnay.CurrentRow.Cells["SatNo"].Value.ConInt();
            formno = DtgOnay.CurrentRow.Cells["Formno"].Value.ConInt();
            masrafyeri = DtgOnay.CurrentRow.Cells["Masrafyeri"].Value.ToString();
            talepeden = DtgOnay.CurrentRow.Cells["Talepeden"].Value.ToString();
            bolum = DtgOnay.CurrentRow.Cells["Bolum"].Value.ToString();
            usbolgesi = DtgOnay.CurrentRow.Cells["Usbolgesi"].Value.ToString();
            abfno = DtgOnay.CurrentRow.Cells["Abfformno"].Value.ToString();
            istenentarih = DtgOnay.CurrentRow.Cells["Tarih"].Value.ConDate();
            gerekce = DtgOnay.CurrentRow.Cells["Gerekce"].Value.ToString();
            belgeTuru = DtgOnay.CurrentRow.Cells["BelgeTuru"].Value.ToString();
            masrafyerino = DtgOnay.CurrentRow.Cells["Masyerino"].Value.ToString();
            abfformno = DtgOnay.CurrentRow.Cells["Abfformno"].Value.ToString();
            butcekodukalemi = DtgOnay.CurrentRow.Cells["Burcekodu"].Value.ToString();
            satbirim = DtgOnay.CurrentRow.Cells["Satbirim"].Value.ToString();
            harcamaturu = DtgOnay.CurrentRow.Cells["Harcamaturu"].Value.ToString();
            belgeNumarasi = DtgOnay.CurrentRow.Cells["BelgeNumarasi"].Value.ToString();
            faturafirma = DtgOnay.CurrentRow.Cells["Faturafirma"].Value.ToString();
            ilgilikisi = DtgOnay.CurrentRow.Cells["Ilgilikisi"].Value.ToString();
            belgeTarihi = DtgOnay.CurrentRow.Cells["BelgeTarihi"].Value.ConDate();
            ucteklif = DtgOnay.CurrentRow.Cells["Uctekilf"].Value.ConInt();
            donem = DtgOnay.CurrentRow.Cells["Donem"].Value.ToString();
            satOlusturmaTuru = DtgOnay.CurrentRow.Cells["SatOlusturmaTuru"].Value.ToString();
            personelId = DtgOnay.CurrentRow.Cells["PersonelId"].Value.ConInt();
            firmaBilgisi = DtgOnay.CurrentRow.Cells["FirmaBilgisi"].Value.ToString();
            talepEdenPersonel = DtgOnay.CurrentRow.Cells["TalepEdenPersonel"].Value.ToString();
            personelSiparis = DtgOnay.CurrentRow.Cells["PersonelSiparis"].Value.ToString();
            unvani = DtgOnay.CurrentRow.Cells["Unvani"].Value.ToString();
            personelMasrafYerNo = DtgOnay.CurrentRow.Cells["PersonelMasYerNo"].Value.ToString();
            islemAdimi = DtgOnay.CurrentRow.Cells["IslemAdimi"].Value.ToString();
            satinAlinanFirma = DtgOnay.CurrentRow.Cells["SatinAlinanFirma"].Value.ToString();
            dosyayolu = DtgOnay.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            proje = DtgOnay.CurrentRow.Cells["Proje"].Value.ToString();
            teklifdurumu = DtgOnay.CurrentRow.Cells["Uctekilf"].Value.ConInt();

            satinAlinacakMalzemelers = satinAlinacakMalManager.GetList(siparisNo);
            satNos = satNoManager.GetList(siparisNo);
            MalzemeList();
            MalzemeList2();
            DtgSatIslemAdimlari.DataSource = satIslemAdimlarimanager.GetList(siparisNo);
            WebBrowser();

            FillTools();
            FillTools2();

            if (teklifdurumu == 0)
            {
                if (belgeTuru != "")
                {
                    panel2.Visible = true;
                    panel4.Visible = false;
                    panel5.Visible = false;
                    TxtGerekceHarcamasiYapilan.Text = DtgOnay.CurrentRow.Cells["Gerekce"].Value.ToString();
                    webBrowser5.Navigate(dosyayolu);
                    return;
                }
                if (talepeden == "MURAT DEMİRTAŞ      ")
                {
                    if (satOlusturmaTuru == "BAŞARAN")
                    {
                        panel4.Visible = true;
                        panel2.Visible = false;
                        panel5.Visible = false;
                        TxtGerekceTeklifsiz.Text = DtgOnay.CurrentRow.Cells["Gerekce"].Value.ToString();
                        webBrowser4.Navigate(dosyayolu);
                        return;
                    }
                    panel2.Visible = true;
                    panel4.Visible = false;
                    panel5.Visible = false;
                    TxtGerekceHarcamasiYapilan.Text = DtgOnay.CurrentRow.Cells["Gerekce"].Value.ToString();
                    webBrowser5.Navigate(dosyayolu);
                    return;
                }
                panel4.Visible = true;
                panel2.Visible = false;
                panel5.Visible = false;

                TxtGerekceTeklifsiz.Text = DtgOnay.CurrentRow.Cells["Gerekce"].Value.ToString();
                webBrowser4.Navigate(dosyayolu);
            }
            if (teklifdurumu == 1)
            {
                panel5.Visible = true;
                panel4.Visible = false;
                panel2.Visible = false;

                TxtGerekce.Text = DtgOnay.CurrentRow.Cells["Gerekce"].Value.ToString();
                webBrowser3.Navigate(dosyayolu);
            }
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

        private void Tutar1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tutar2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tutar3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tutar4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BtnRedT_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(formno + " Nolu SAT işlemini Ret Etmek istediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                FrmSatOnOnayRed frmSatOnOnayRed = new FrmSatOnOnayRed();
                frmSatOnOnayRed.ShowDialog();
                rednedeni = Properties.Settings.Default.RedNedeni.ToString();
                if (rednedeni == "" || rednedeni == "sil")
                {
                    MessageBox.Show("Lütfen Ret Nedenini Boş Geçmeyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                satDataGridview1Manager.SatRed(siparisNo, rednedeni); // SAT REDDEDİLDİ BİLGİSİ GİRİLDİ
                teklifsizSatManager.SatMalzemeDurumGuncelle(siparisNo); // malzemeler reddedildi fiyatlı olan SAT_FIYAT_TEKLIFI_AL

                yapilanislem = "SAT REDDEDİLDİ.";
                string islmeyapan = infos[1].ToString();

                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, yapilanislem, islmeyapan, DateTime.Now);
                satIslemAdimlarimanager.Add(satIslem);
                MessageBox.Show("Bilgiler Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SatDataGrid1();
                LblToplam.Text = "0.00 ₺";
                TxtTop.Text = DtgOnay.RowCount.ToString();
                FrmAnaSayfa frmAnaSayfa = new FrmAnaSayfa();
                frmAnaSayfa.ToplamSayilar();

                #region RedEskiKodlar
                /*
                //teklifsizSatManager.Delete(siparisNo);
                teklifsizSatManager.TeklifsizSatDurumGuncelle(siparisNo);
                satDataGridview1Manager.Delete(id);
                //satDataGridview1Manager.DurumGuncelleRed(siparisNo);

                onaydurum = "Reddildi.";
                yapilanislem = "SAT ONAY İŞLEMİ: REDDEDİLDİ";

                Reddedilenler reddedilenler = new Reddedilenler(formno, satno, masrafyeri, talepeden, bolum, usbolgesi, abfno, istenentarih, gerekce, siparisNo, dosyayolu, rednedeni, "Onaylandı", "Alındı", donem, personelId, butcekodukalemi, satbirim, harcamaturu, faturafirma, ilgilikisi, masrafyerino,ucteklif,firmaBilgisi,talepEdenPersonel,personelSiparis,unvani,personelMasrafYerNo,islemAdimi, satOlusturmaTuru);

                string mesaj = reddedilenlerManager.Add(reddedilenler);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                ReddedilenMalzemeEkle3();
                //ReddedilenMalzemeEkle2();
                satDataGridview1Manager.Delete(id);
                satinAlinacakMalManager.Delete(siparisNo);

                yapilanislem = "SAT REDDEDİLDİ.";
                string islmeyapan = infos[1].ToString();

                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, yapilanislem, islmeyapan, DateTime.Now);
                satIslemAdimlarimanager.Add(satIslem);

                MessageBox.Show("Bilgiler Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Task.Factory.StartNew(() => MailSendMetot());

                SatDataGrid1();
                LblToplam.Text = "0.00 ₺";
                TxtTop.Text = DtgOnay.RowCount.ToString();
                */
                #endregion
            }
        }
        void ReddedilenMalzemeEkle3()
        {
            ReddedilenMalzeme reddedilen = new ReddedilenMalzeme("", LblToplam.Text, 0, "", siparisNo);
            reddedilenMalzemeManager.Add(reddedilen);
        }
        private void Tutar5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tutar6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tutar7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tutar8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tutar9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Tutar10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IF1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IF2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IF3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IF4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IF5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IF6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IF7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IF8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IF9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IF10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IBirimF1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IBirimF2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IBirimF3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IBirimF4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IBirimF5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IBirimF6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IBirimF7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IBirimF8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IBirimF9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IBirimF10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ITop1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ITop2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ITop3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ITop4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ITop5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ITop6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ITop7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ITop8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ITop9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ITop10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UF1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UF2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UF3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UF4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UF5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UF6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UF7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UF8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UF9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UF10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UBirimF1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UBirimF2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UBirimF3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UBirimF4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UBirimF5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UBirimF6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UBirimF7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UBirimF8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UBirimF9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UBirimF10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UTop1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UTop2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UTop3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UTop4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UTop5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UTop6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UTop7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UTop8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UTop9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UTop10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void GNT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void GNT2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void GNT3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion
    }
}
