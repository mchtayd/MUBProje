using Business.Concreate;
using Business.Concreate.IdarıIsler;
using DocumentFormat.OpenXml.Office.CoverPageProps;
using DocumentFormat.OpenXml.Presentation;
using Entity;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmGorevGor : Form
    {
        IzinManager ızinManager;
        SatDataGridview1Manager satDataGridview1Manager;
        MalzemeTalepManager malzemeTalepManager;
        public string gorevAdi, departman = "";
        public int benzersizId = 0;
        public int isAkisNo = 0;

        List<SatDataGridview1> satDatas = new List<SatDataGridview1>();
        List<MalzemeTalep> malzemeTaleps = new List<MalzemeTalep>();

        public FrmGorevGor()
        {
            InitializeComponent();
            ızinManager = IzinManager.GetInstance();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            malzemeTalepManager = MalzemeTalepManager.GetInstance();
        }

        private void FrmGorevGor_Load(object sender, EventArgs e)
        {
            LblGorevAdi.Text= gorevAdi;
            LblDepartman.Text= departman;
            Gorev();
        }

        void Gorev()
        {
            if (LblDepartman.Text == "İZİN")
            {
                Izin ızin = ızinManager.GetId(benzersizId);
                List<Izin> ızins = new List<Izin>();
                ızins.Add(ızin);

                DtgDevamEden.DataSource = ızins;
                DtgDevamEden.Columns["Id"].Visible = false;
                DtgDevamEden.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
                DtgDevamEden.Columns["Izinkategori"].HeaderText = "İZİN KATEGORİ";
                DtgDevamEden.Columns["Izinturu"].HeaderText = "İZİN TÜRÜ";
                DtgDevamEden.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
                DtgDevamEden.Columns["Adsoyad"].HeaderText = "AD SOYAD";
                DtgDevamEden.Columns["Masrafyerino"].HeaderText = "MASRAF YERİ NO";
                DtgDevamEden.Columns["Bolum"].HeaderText = "BÖLÜMÜ";
                DtgDevamEden.Columns["Izınnedeni"].HeaderText = "İZİN NEDENİ";
                DtgDevamEden.Columns["Bastarihi"].HeaderText = "İZİN BAŞLAMA TARİHİ";
                DtgDevamEden.Columns["Bittarihi"].HeaderText = "İZİN BİTİŞ TARİHİ";
                DtgDevamEden.Columns["Izindurumu"].HeaderText = "İZİN DURUMU";
                DtgDevamEden.Columns["Unvani"].HeaderText = "ÜNVANI";
                DtgDevamEden.Columns["Toplamsure"].HeaderText = "TOPLAM SÜRE";
                DtgDevamEden.Columns["KalanSure"].Visible = false;
                DtgDevamEden.Columns["Dosyayolu"].Visible = false;
                DtgDevamEden.Columns["Sayfa"].Visible = false;
                DtgDevamEden.Columns["Siparis"].Visible = false;
                DtgDevamEden.Columns["OnayDurum"].HeaderText = "ONAY DURUMU";
                DtgDevamEden.Columns["Siparis"].Visible = false;
            }

            if (LblDepartman.Text == "SATIN ALMA")
            {
                SatDataGridview1 satDataGridview1 = satDataGridview1Manager.Get(isAkisNo.ToString());
                satDatas.Add(satDataGridview1);
                DtgDevamEden.DataSource = satDatas;

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
                DtgDevamEden.Columns["MlzTeslimAldTarih"].HeaderText = "MLZ. TESLİM ALINMA TARİHİ";
                DtgDevamEden.Columns["HarcamaYapan"].Visible = false;
                DtgDevamEden.Columns["AselsanMailGondermeDate"].HeaderText = "ASELSAN MAİL GÖNDERME TARİHİ";
                DtgDevamEden.Columns["AselsanMailAlmaDate"].HeaderText = "ASELSAN MAİL ALMA TARİHİ";
                DtgDevamEden.Columns["OdemeMailGondermeDate"].HeaderText = "ÖDEME MAİLİ GÖNDERME TARİHİ";
                DtgDevamEden.Columns["OdemeMailAlmaDate"].HeaderText = "ÖDEME MAİLİ ALMA TARİHİ";
                DtgDevamEden.Columns["DepoTeslimTarihi"].HeaderText = "DEPO TESLİM TARİHİ";
                DtgDevamEden.Columns["DepoTeslimBilgisi"].HeaderText = "DEPOYA TESLİM DURUMU";
                DtgDevamEden.Columns["ButceTanimi"].HeaderText = "BÜTÇE TANIM";
                DtgDevamEden.Columns["MaliyetTuru"].HeaderText = "MALİYET TÜRÜ";

                DtgDevamEden.Columns["IslemAdimi"].DisplayIndex = 4;
            }

            if (LblDepartman.Text == "MİF")
            {
                MalzemeTalep malzemeTalep = malzemeTalepManager.GetId(benzersizId);
                malzemeTaleps.Add(malzemeTalep);
                DtgDevamEden.DataSource = malzemeTaleps;

                DtgDevamEden.Columns["Id"].HeaderText = "ID";
                DtgDevamEden.Columns["MalzemeKategorisi"].HeaderText = "MALZEME KATEGORİSİ";
                DtgDevamEden.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDİLEN PERSONEL";
                DtgDevamEden.Columns["Tanim"].HeaderText = "TANIM";
                DtgDevamEden.Columns["StokNo"].HeaderText = "STOK NO";
                DtgDevamEden.Columns["Miktar"].HeaderText = "MİKTAR";
                DtgDevamEden.Columns["Birim"].HeaderText = "BİRİM";
                DtgDevamEden.Columns["TalebiOlusturan"].HeaderText = "MASRAF YERİ SORUMLUSU";
                DtgDevamEden.Columns["Bolum"].HeaderText = "BÖLÜM";
                DtgDevamEden.Columns["SatBilgisi"].Visible = false;
                DtgDevamEden.Columns["MasrafYeri"].HeaderText = "MASRAF YERİ NO";
                DtgDevamEden.Columns["IslemDurumu"].HeaderText = "İŞLEM DURUMU";
                DtgDevamEden.Columns["RedGerekcesi"].Visible = false;
                DtgDevamEden.Columns["ToplamMiktar"].Visible = false;
                DtgDevamEden.Columns["Secim"].Visible = false;

                DtgDevamEden.Columns["Id"].DisplayIndex = 0;
                DtgDevamEden.Columns["Bolum"].DisplayIndex = 1;
                DtgDevamEden.Columns["MasrafYeri"].DisplayIndex = 2;
                DtgDevamEden.Columns["TalebiOlusturan"].DisplayIndex = 3;
                DtgDevamEden.Columns["MalzemeKategorisi"].DisplayIndex = 4;
                DtgDevamEden.Columns["StokNo"].DisplayIndex = 5;
                DtgDevamEden.Columns["Tanim"].DisplayIndex = 6;
                DtgDevamEden.Columns["TalepEdenPersonel"].DisplayIndex = 7;
                DtgDevamEden.Columns["Miktar"].DisplayIndex = 8;
                DtgDevamEden.Columns["Birim"].DisplayIndex = 9;
                DtgDevamEden.Columns["SatBilgisi"].DisplayIndex = 10;
            }
        }
    }
}
