﻿using Business;
using DataAccess.Concreate;
using Entity;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;
using Business.Concreate.AnaSayfa;
using Entity.AnaSayfa;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmSahaIzleme : Form
    {
        ArizaIslemAdimiManager arizaIslemAdimiManager;
        ArizaBildirimTuruManager arizaBildirimTuruManager;

        List<int> veriler = new List<int>();

        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> Values { get; set; }

        public FrmSahaIzleme()
        {
            InitializeComponent();
            arizaIslemAdimiManager = ArizaIslemAdimiManager.GetInstance();
            arizaBildirimTuruManager = ArizaBildirimTuruManager.GetInstance();
        }

        private void FrmSahaIzleme_Load(object sender, EventArgs e)
        {
            TimerSaat.Start();
            DataDisplay();
            timer1.Start();
            
        }

        void DataDisplay()
        {
            ArizaIslemAdimi arizaIslemAdimi200 = arizaIslemAdimiManager.Get("200_ARIZA TESPİTİ (FI/FD) (SAHA)");
            Lbl200Sirnak.Text = arizaIslemAdimi200.Sirnak.ToString();
            Lbl200Cukurca.Text = arizaIslemAdimi200.Cukurca.ToString();
            Lbl200Yukseova.Text = arizaIslemAdimi200.Yukseova.ToString();
            Lbl200Semdinli.Text = arizaIslemAdimi200.Semdinli.ToString();
            Lbl200Derecik.Text = (arizaIslemAdimi200.Derecik + arizaIslemAdimi200.Merkez).ToString();
            Lbl200DBolgesi.Text = arizaIslemAdimi200.DBolgesi.ToString();
            Lbl200Toplam.Text = arizaIslemAdimi200.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi300 = arizaIslemAdimiManager.Get("300_ONARIM SONRASI ARIZA TESPİTİ (SAHA)");
            Lbl300Sirnak.Text = arizaIslemAdimi300.Sirnak.ToString();
            Lbl300Cukurca.Text = arizaIslemAdimi300.Cukurca.ToString();
            Lbl300Yukseova.Text = arizaIslemAdimi300.Yukseova.ToString();
            Lbl300Semdinli.Text = arizaIslemAdimi300.Semdinli.ToString();
            Lbl300Derecik.Text = (arizaIslemAdimi300.Derecik + arizaIslemAdimi300.Merkez).ToString();
            Lbl300DBolgesi.Text = arizaIslemAdimi300.DBolgesi.ToString();
            Lbl300Toplam.Text = arizaIslemAdimi300.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi400 = arizaIslemAdimiManager.Get("400_SİPARİŞ OLUŞTURMA (DTS)");
            Lbl400Sirnak.Text = arizaIslemAdimi400.Sirnak.ToString();
            Lbl400Cukurca.Text = arizaIslemAdimi400.Cukurca.ToString();
            Lbl400Yukseova.Text = arizaIslemAdimi400.Yukseova.ToString();
            Lbl400Semdinli.Text = arizaIslemAdimi400.Semdinli.ToString();
            Lbl400Derecik.Text = (arizaIslemAdimi400.Derecik + arizaIslemAdimi400.Merkez).ToString();
            Lbl400DBolgesi.Text = arizaIslemAdimi400.DBolgesi.ToString();
            Lbl400Toplam.Text = arizaIslemAdimi400.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi500 = arizaIslemAdimiManager.Get("500_ARIZA BİLDİRİMİ (ASELSAN)");
            Lbl500Sirnak.Text = arizaIslemAdimi500.Sirnak.ToString();
            Lbl500Cukurca.Text = arizaIslemAdimi500.Cukurca.ToString();
            Lbl500Yukseova.Text = arizaIslemAdimi500.Yukseova.ToString();
            Lbl500Semdinli.Text = arizaIslemAdimi500.Semdinli.ToString();
            Lbl500Derecik.Text = (arizaIslemAdimi500.Derecik + arizaIslemAdimi500.Merkez).ToString();
            Lbl500DBolgesi.Text = arizaIslemAdimi500.DBolgesi.ToString();
            Lbl500Toplam.Text = arizaIslemAdimi500.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi600 = arizaIslemAdimiManager.Get("600_BİLDİRİM ONAYI (YÖNETİCİ)");
            Lbl600Sirnak.Text = arizaIslemAdimi600.Sirnak.ToString();
            Lbl600Cukurca.Text = arizaIslemAdimi600.Cukurca.ToString();
            Lbl600Yukseova.Text = arizaIslemAdimi600.Yukseova.ToString();
            Lbl600Semdinli.Text = arizaIslemAdimi600.Semdinli.ToString();
            Lbl600Derecik.Text = (arizaIslemAdimi600.Derecik + arizaIslemAdimi600.Merkez).ToString();
            Lbl600DBolgesi.Text = arizaIslemAdimi600.DBolgesi.ToString();
            Lbl600Toplam.Text = arizaIslemAdimi600.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi700 = arizaIslemAdimiManager.Get("700_OKF HAZIRLAMA");
            Lbl700Sirnak.Text = arizaIslemAdimi700.Sirnak.ToString();
            Lbl700Cukurca.Text = arizaIslemAdimi700.Cukurca.ToString();
            Lbl700Yukseova.Text = arizaIslemAdimi700.Yukseova.ToString();
            Lbl700Semdinli.Text = arizaIslemAdimi700.Semdinli.ToString();
            Lbl700Derecik.Text = (arizaIslemAdimi700.Derecik + arizaIslemAdimi700.Merkez).ToString();
            Lbl700DBolgesi.Text = arizaIslemAdimi700.DBolgesi.ToString();
            Lbl700Toplam.Text = arizaIslemAdimi700.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi750 = arizaIslemAdimiManager.Get("750_OKF HAZIRLAMA (ASELSAN)");
            Lbl750Sirnak.Text = arizaIslemAdimi750.Sirnak.ToString();
            Lbl750Cukurca.Text = arizaIslemAdimi750.Cukurca.ToString();
            Lbl750Yukseova.Text = arizaIslemAdimi750.Yukseova.ToString();
            Lbl750Semdinli.Text = arizaIslemAdimi750.Semdinli.ToString();
            Lbl750Derecik.Text = (arizaIslemAdimi750.Derecik + arizaIslemAdimi750.Merkez).ToString();
            Lbl750DBolgesi.Text = arizaIslemAdimi750.DBolgesi.ToString();
            Lbl750Toplam.Text = arizaIslemAdimi750.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi800 = arizaIslemAdimiManager.Get("800_MÜŞTERİ ONAYI");
            Lbl800Sirnak.Text = arizaIslemAdimi800.Sirnak.ToString();
            Lbl800Cukurca.Text = arizaIslemAdimi800.Cukurca.ToString();
            Lbl800Yukseova.Text = arizaIslemAdimi800.Yukseova.ToString();
            Lbl800Semdinli.Text = arizaIslemAdimi800.Semdinli.ToString();
            Lbl800Derecik.Text = (arizaIslemAdimi800.Derecik + arizaIslemAdimi800.Merkez).ToString();
            Lbl800DBolgesi.Text = arizaIslemAdimi800.DBolgesi.ToString();
            Lbl800Toplam.Text = arizaIslemAdimi800.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi900 = arizaIslemAdimiManager.Get("900_FABRİKA BAKIM ONARIM (ASELSAN)");
            Lbl900Sirnak.Text = arizaIslemAdimi900.Sirnak.ToString();
            Lbl900Cukurca.Text = arizaIslemAdimi900.Cukurca.ToString();
            Lbl900Yukseova.Text = arizaIslemAdimi900.Yukseova.ToString();
            Lbl900Semdinli.Text = arizaIslemAdimi900.Semdinli.ToString();
            Lbl900Derecik.Text = (arizaIslemAdimi900.Derecik + arizaIslemAdimi900.Merkez).ToString();
            Lbl900DBolgesi.Text = arizaIslemAdimi900.DBolgesi.ToString();
            Lbl900Toplam.Text = arizaIslemAdimi900.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi950 = arizaIslemAdimiManager.Get("950_ATÖLYE BAKIM ONARIM (VAN)");
            Lbl950Sirnak.Text = arizaIslemAdimi950.Sirnak.ToString();
            Lbl950Cukurca.Text = arizaIslemAdimi950.Cukurca.ToString();
            Lbl950Yukseova.Text = arizaIslemAdimi950.Yukseova.ToString();
            Lbl950Semdinli.Text = arizaIslemAdimi950.Semdinli.ToString();
            Lbl950Derecik.Text = (arizaIslemAdimi950.Derecik + arizaIslemAdimi950.Merkez).ToString();
            Lbl950DBolgesi.Text = arizaIslemAdimi950.DBolgesi.ToString();
            Lbl950Toplam.Text = arizaIslemAdimi950.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1000 = arizaIslemAdimiManager.Get("1000_DEPO STOK KONTROL");
            Lbl1000Sirnak.Text = arizaIslemAdimi1000.Sirnak.ToString();
            Lbl1000Cukurca.Text = arizaIslemAdimi1000.Cukurca.ToString();
            Lbl1000Yukseova.Text = arizaIslemAdimi1000.Yukseova.ToString();
            Lbl1000Semdinli.Text = arizaIslemAdimi1000.Semdinli.ToString();
            Lbl1000Derecik.Text = (arizaIslemAdimi1000.Derecik + arizaIslemAdimi1000.Merkez).ToString();
            Lbl1000DBolgesi.Text = arizaIslemAdimi1000.DBolgesi.ToString();
            Lbl1000Toplam.Text = arizaIslemAdimi1000.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1100 = arizaIslemAdimiManager.Get("1100_MALZEME TEMİNİ (SATIN ALMA)");
            Lbl1100Sirnak.Text = arizaIslemAdimi1100.Sirnak.ToString();
            Lbl1100Cukurca.Text = arizaIslemAdimi1100.Cukurca.ToString();
            Lbl1100Yukseova.Text = arizaIslemAdimi1100.Yukseova.ToString();
            Lbl1100Semdinli.Text = arizaIslemAdimi1100.Semdinli.ToString();
            Lbl1100Derecik.Text = (arizaIslemAdimi1100.Derecik + arizaIslemAdimi1100.Merkez).ToString();
            Lbl1100DBolgesi.Text = arizaIslemAdimi1100.DBolgesi.ToString();
            Lbl1100Toplam.Text = arizaIslemAdimi1100.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1200 = arizaIslemAdimiManager.Get("1200_MALZEME TEMİNİ (ASELSAN)");
            Lbl1200Sirnak.Text = arizaIslemAdimi1200.Sirnak.ToString();
            Lbl1200Cukurca.Text = arizaIslemAdimi1200.Cukurca.ToString();
            Lbl1200Yukseova.Text = arizaIslemAdimi1200.Yukseova.ToString();
            Lbl1200Semdinli.Text = arizaIslemAdimi1200.Semdinli.ToString();
            Lbl1200Derecik.Text = (arizaIslemAdimi1200.Derecik + arizaIslemAdimi1200.Merkez).ToString();
            Lbl1200DBolgesi.Text = arizaIslemAdimi1200.DBolgesi.ToString();
            Lbl1200Toplam.Text = arizaIslemAdimi1200.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1300 = arizaIslemAdimiManager.Get("1300_MALZEME HAZIRLAMA AMBAR");
            Lbl1300Sirnak.Text = arizaIslemAdimi1300.Sirnak.ToString();
            Lbl1300Cukurca.Text = arizaIslemAdimi1300.Cukurca.ToString();
            Lbl1300Yukseova.Text = arizaIslemAdimi1300.Yukseova.ToString();
            Lbl1300Semdinli.Text = arizaIslemAdimi1300.Semdinli.ToString();
            Lbl1300Derecik.Text = (arizaIslemAdimi1300.Derecik + arizaIslemAdimi1300.Merkez).ToString();
            Lbl1300DBolgesi.Text = arizaIslemAdimi1300.DBolgesi.ToString();
            Lbl1300Toplam.Text = arizaIslemAdimi1300.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1400 = arizaIslemAdimiManager.Get("1400_SEVKİYAT (ANKARA)");
            Lbl1400ASirnak.Text = arizaIslemAdimi1400.Sirnak.ToString();
            Lbl1400ACukurca.Text = arizaIslemAdimi1400.Cukurca.ToString();
            Lbl1400AYukseova.Text = arizaIslemAdimi1400.Yukseova.ToString();
            Lbl1400ASemdinli.Text = arizaIslemAdimi1400.Semdinli.ToString();
            Lbl1400ADerecik.Text = (arizaIslemAdimi1400.Derecik + arizaIslemAdimi1400.Merkez).ToString();
            Lbl1400ADBolgesi.Text = arizaIslemAdimi1400.DBolgesi.ToString();
            Lbl1400AToplam.Text = arizaIslemAdimi1400.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1400B = arizaIslemAdimiManager.Get("1450_SEVKİYAT (BÖLGE)");
            Lbl1400BSirnak.Text = arizaIslemAdimi1400B.Sirnak.ToString();
            Lbl1400BCukurca.Text = arizaIslemAdimi1400B.Cukurca.ToString();
            Lbl1400BYukseova.Text = arizaIslemAdimi1400B.Yukseova.ToString();
            Lbl1400BSemdinli.Text = arizaIslemAdimi1400B.Semdinli.ToString();
            Lbl1400BDerecik.Text = (arizaIslemAdimi1400B.Derecik + arizaIslemAdimi1400B.Merkez).ToString();
            Lbl1400BDBolgesi.Text = arizaIslemAdimi1400B.DBolgesi.ToString();
            Lbl1400BToplam.Text = arizaIslemAdimi1400B.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1500 = arizaIslemAdimiManager.Get("1500_BAKIM ONARIM (SAHA)");
            Lbl1500Sirnak.Text = arizaIslemAdimi1500.Sirnak.ToString();
            Lbl1500Cukurca.Text = arizaIslemAdimi1500.Cukurca.ToString();
            Lbl1500Yukseova.Text = arizaIslemAdimi1500.Yukseova.ToString();
            Lbl1500Semdinli.Text = arizaIslemAdimi1500.Semdinli.ToString();
            Lbl1500Derecik.Text = (arizaIslemAdimi1500.Derecik + arizaIslemAdimi1500.Merkez).ToString();
            Lbl1500DBolgesi.Text = arizaIslemAdimi1500.DBolgesi.ToString();
            Lbl1500Toplam.Text = arizaIslemAdimi1500.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1600 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (SERVİS)");
            Lbl1600Sirnak.Text = arizaIslemAdimi1600.Sirnak.ToString();
            Lbl1600Cukurca.Text = arizaIslemAdimi1600.Cukurca.ToString();
            Lbl1600Yukseova.Text = arizaIslemAdimi1600.Yukseova.ToString();
            Lbl1600Semdinli.Text = arizaIslemAdimi1600.Semdinli.ToString();
            Lbl1600Derecik.Text = (arizaIslemAdimi1600.Derecik + arizaIslemAdimi1600.Merkez).ToString();
            Lbl1600DBolgesi.Text = arizaIslemAdimi1600.DBolgesi.ToString();
            Lbl1600Toplam.Text = arizaIslemAdimi1600.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1700 = arizaIslemAdimiManager.Get("1700_FONKSİYONEL TEST");
            Lbl1700Sirnak.Text = arizaIslemAdimi1700.Sirnak.ToString();
            Lbl1700Cukurca.Text = arizaIslemAdimi1700.Cukurca.ToString();
            Lbl1700Yukseova.Text = arizaIslemAdimi1700.Yukseova.ToString();
            Lbl1700Semdinli.Text = arizaIslemAdimi1700.Semdinli.ToString();
            Lbl1700Derecik.Text = (arizaIslemAdimi1700.Derecik + arizaIslemAdimi1700.Merkez).ToString();
            Lbl1700DBolgesi.Text = arizaIslemAdimi1700.DBolgesi.ToString();
            Lbl1700Toplam.Text = arizaIslemAdimi1700.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1800 = arizaIslemAdimiManager.Get("1800_DENETİM");
            Lbl1800Sirnak.Text = arizaIslemAdimi1800.Sirnak.ToString();
            Lbl1800Cukurca.Text = arizaIslemAdimi1800.Cukurca.ToString();
            Lbl1800Yukseova.Text = arizaIslemAdimi1800.Yukseova.ToString();
            Lbl1800Semdinli.Text = arizaIslemAdimi1800.Semdinli.ToString();
            Lbl1800Derecik.Text = (arizaIslemAdimi1800.Derecik + arizaIslemAdimi1800.Merkez).ToString();
            Lbl1800DBolgesi.Text = arizaIslemAdimi1800.DBolgesi.ToString();
            Lbl1800Toplam.Text = arizaIslemAdimi1800.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1900 = arizaIslemAdimiManager.Get("1900_MÜŞTERİ TESLİMATI");
            Lbl1900Sirnak.Text = arizaIslemAdimi1900.Sirnak.ToString();
            Lbl1900Cukurca.Text = arizaIslemAdimi1900.Cukurca.ToString();
            Lbl1900Yukseova.Text = arizaIslemAdimi1900.Yukseova.ToString();
            Lbl1900Semdinli.Text = arizaIslemAdimi1900.Semdinli.ToString();
            Lbl1900Derecik.Text = (arizaIslemAdimi1900.Derecik + arizaIslemAdimi1900.Merkez).ToString();
            Lbl1900DBolgesi.Text = arizaIslemAdimi1900.DBolgesi.ToString();
            Lbl1900Toplam.Text = arizaIslemAdimi1900.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi2000 = arizaIslemAdimiManager.Get("2000_ARIZA KAPATMA (DTS)");
            Lbl2000Sirnak.Text = arizaIslemAdimi2000.Sirnak.ToString();
            Lbl2000Cukurca.Text = arizaIslemAdimi2000.Cukurca.ToString();
            Lbl2000Yukseova.Text = arizaIslemAdimi2000.Yukseova.ToString();
            Lbl2000Semdinli.Text = arizaIslemAdimi2000.Semdinli.ToString();
            Lbl2000Derecik.Text = (arizaIslemAdimi2000.Derecik + arizaIslemAdimi2000.Merkez).ToString();
            Lbl2000DBolgesi.Text = arizaIslemAdimi2000.DBolgesi.ToString();
            Lbl2000Toplam.Text = arizaIslemAdimi2000.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi2100 = arizaIslemAdimiManager.Get("2100_ARIZA KAPATMA BİLDİRİMİ (ASELSAN)");
            Lbl2100Sirnak.Text = arizaIslemAdimi2100.Sirnak.ToString();
            Lbl2100Cukurca.Text = arizaIslemAdimi2100.Cukurca.ToString();
            Lbl2100Yukseova.Text = arizaIslemAdimi2100.Yukseova.ToString();
            Lbl2100Semdinli.Text = arizaIslemAdimi2100.Semdinli.ToString();
            Lbl2100Derecik.Text = (arizaIslemAdimi2100.Derecik + arizaIslemAdimi2100.Merkez).ToString();
            Lbl2100DBolgesi.Text = arizaIslemAdimi2100.DBolgesi.ToString();
            Lbl2100Toplam.Text = arizaIslemAdimi2100.Toplam.ToString();

            LblToplamSirnak.Text= (Lbl200Sirnak.Text.ConInt() + Lbl300Sirnak.Text.ConInt() + Lbl400Sirnak.Text.ConInt() + Lbl500Sirnak.Text.ConInt() + Lbl600Sirnak.Text.ConInt() + Lbl700Sirnak.Text.ConInt() + Lbl750Sirnak.Text.ConInt() + Lbl800Sirnak.Text.ConInt() + Lbl900Sirnak.Text.ConInt() + Lbl950Sirnak.Text.ConInt() + Lbl1000Sirnak.Text.ConInt() + Lbl1100Sirnak.Text.ConInt() + Lbl1200Sirnak.Text.ConInt() + Lbl1300Sirnak.Text.ConInt() + Lbl1400BSirnak.Text.ConInt() + Lbl1400ASirnak.Text.ConInt() + Lbl1500Sirnak.Text.ConInt() + Lbl1600Sirnak.Text.ConInt() + Lbl1700Sirnak.Text.ConInt() + Lbl1800Sirnak.Text.ConInt() + Lbl1900Sirnak.Text.ConInt() + Lbl2000Sirnak.Text.ConInt() + Lbl2100Sirnak.Text.ConInt()).ToString();

            LblToplamCukurca.Text = (Lbl200Cukurca.Text.ConInt() + Lbl300Cukurca.Text.ConInt() + Lbl400Cukurca.Text.ConInt() + Lbl500Cukurca.Text.ConInt() + Lbl600Cukurca.Text.ConInt() + Lbl700Cukurca.Text.ConInt()+ Lbl750Cukurca.Text.ConInt() + Lbl800Cukurca.Text.ConInt() + Lbl900Cukurca.Text.ConInt() + Lbl950Cukurca.Text.ConInt() + Lbl1000Cukurca.Text.ConInt() + Lbl1100Cukurca.Text.ConInt() + Lbl1200Cukurca.Text.ConInt() + Lbl1300Cukurca.Text.ConInt() + Lbl1400BCukurca.Text.ConInt() + Lbl1400ACukurca.Text.ConInt() + Lbl1500Cukurca.Text.ConInt() + Lbl1600Cukurca.Text.ConInt() + Lbl1700Cukurca.Text.ConInt() + Lbl1800Cukurca.Text.ConInt() + Lbl1900Cukurca.Text.ConInt() + Lbl2000Cukurca.Text.ConInt() + Lbl2100Cukurca.Text.ConInt()).ToString();

            LblToplamYukseova.Text = (Lbl200Yukseova.Text.ConInt() + Lbl300Yukseova.Text.ConInt() + Lbl400Yukseova.Text.ConInt() + Lbl500Yukseova.Text.ConInt() + Lbl600Yukseova.Text.ConInt() + Lbl700Yukseova.Text.ConInt() + Lbl750Yukseova.Text.ConInt() + Lbl800Yukseova.Text.ConInt() + Lbl900Yukseova.Text.ConInt() + Lbl950Yukseova.Text.ConInt() + Lbl1000Yukseova.Text.ConInt() + Lbl1100Yukseova.Text.ConInt() + Lbl1200Yukseova.Text.ConInt() + Lbl1300Yukseova.Text.ConInt() + Lbl1400BYukseova.Text.ConInt() + Lbl1400AYukseova.Text.ConInt() + Lbl1500Yukseova.Text.ConInt() + Lbl1600Yukseova.Text.ConInt() + Lbl1700Yukseova.Text.ConInt() + Lbl1800Yukseova.Text.ConInt() + Lbl1900Yukseova.Text.ConInt() + Lbl2000Yukseova.Text.ConInt() + Lbl2100Yukseova.Text.ConInt()).ToString();

            LblToplamSemdinli.Text = (Lbl200Semdinli.Text.ConInt() + Lbl300Semdinli.Text.ConInt() + Lbl400Semdinli.Text.ConInt() + Lbl500Semdinli.Text.ConInt() + Lbl600Semdinli.Text.ConInt() + Lbl700Semdinli.Text.ConInt() + Lbl750Semdinli.Text.ConInt() + Lbl800Semdinli.Text.ConInt() + Lbl900Semdinli.Text.ConInt() + Lbl950Semdinli.Text.ConInt() + Lbl1000Semdinli.Text.ConInt() + Lbl1100Semdinli.Text.ConInt() + Lbl1200Semdinli.Text.ConInt() + Lbl1300Semdinli.Text.ConInt() + Lbl1400BSemdinli.Text.ConInt() + Lbl1400ASemdinli.Text.ConInt() + Lbl1500Semdinli.Text.ConInt() + Lbl1600Semdinli.Text.ConInt() + Lbl1700Semdinli.Text.ConInt() + Lbl1800Semdinli.Text.ConInt() + Lbl1900Semdinli.Text.ConInt() + Lbl2000Semdinli.Text.ConInt() + Lbl2100Semdinli.Text.ConInt()).ToString();

            LblToplamDerecik.Text = (Lbl200Derecik.Text.ConInt() + Lbl300Derecik.Text.ConInt() + Lbl400Derecik.Text.ConInt() + Lbl500Derecik.Text.ConInt() + Lbl600Derecik.Text.ConInt() + Lbl700Derecik.Text.ConInt()+ Lbl750Derecik.Text.ConInt() + Lbl800Derecik.Text.ConInt() + Lbl900Derecik.Text.ConInt() + Lbl950Derecik.Text.ConInt() + Lbl1000Derecik.Text.ConInt() + Lbl1100Derecik.Text.ConInt() + Lbl1200Derecik.Text.ConInt() + Lbl1300Derecik.Text.ConInt() + Lbl1400BDerecik.Text.ConInt() + Lbl1400ADerecik.Text.ConInt() + Lbl1500Derecik.Text.ConInt() + Lbl1600Derecik.Text.ConInt() + Lbl1700Derecik.Text.ConInt() + Lbl1800Derecik.Text.ConInt() + Lbl1900Derecik.Text.ConInt() + Lbl2000Derecik.Text.ConInt() + Lbl2100Derecik.Text.ConInt()).ToString();

            LblToplamDBolgesi.Text = (Lbl200DBolgesi.Text.ConInt() + Lbl300DBolgesi.Text.ConInt() + Lbl400DBolgesi.Text.ConInt() + Lbl500DBolgesi.Text.ConInt() + Lbl600DBolgesi.Text.ConInt() + Lbl700DBolgesi.Text.ConInt() + Lbl750DBolgesi.Text.ConInt() + Lbl800DBolgesi.Text.ConInt() + Lbl900DBolgesi.Text.ConInt() + Lbl950DBolgesi.Text.ConInt() + Lbl1000DBolgesi.Text.ConInt() + Lbl1100DBolgesi.Text.ConInt() + Lbl1200DBolgesi.Text.ConInt() + Lbl1300DBolgesi.Text.ConInt() + Lbl1400BDBolgesi.Text.ConInt() + Lbl1400ADBolgesi.Text.ConInt() + Lbl1500DBolgesi.Text.ConInt() + Lbl1600DBolgesi.Text.ConInt() + Lbl1700DBolgesi.Text.ConInt() + Lbl1800DBolgesi.Text.ConInt() + Lbl1900DBolgesi.Text.ConInt() + Lbl2000DBolgesi.Text.ConInt() + Lbl2100DBolgesi.Text.ConInt()).ToString();

            LblGenelToplam.Text = (Lbl200Toplam.Text.ConInt() + Lbl300Toplam.Text.ConInt() + Lbl400Toplam.Text.ConInt() + Lbl500Toplam.Text.ConInt() + Lbl600Toplam.Text.ConInt() + Lbl700Toplam.Text.ConInt() + Lbl750Toplam.Text.ConInt() + Lbl800Toplam.Text.ConInt() + Lbl900Toplam.Text.ConInt() + Lbl950Toplam.Text.ConInt() + Lbl1000Toplam.Text.ConInt() + Lbl1100Toplam.Text.ConInt() + Lbl1200Toplam.Text.ConInt() + Lbl1300Toplam.Text.ConInt() + Lbl1400BToplam.Text.ConInt() + Lbl1400AToplam.Text.ConInt() + Lbl1500Toplam.Text.ConInt() + Lbl1600Toplam.Text.ConInt() + Lbl1700Toplam.Text.ConInt() + Lbl1800Toplam.Text.ConInt() + Lbl1900Toplam.Text.ConInt() + Lbl2000Toplam.Text.ConInt() + Lbl2100Toplam.Text.ConInt()).ToString();

            LblMaviTop.Text = (Lbl400Toplam.Text.ConInt() + Lbl500Toplam.Text.ConInt() + Lbl600Toplam.Text.ConInt() + Lbl900Toplam.Text.ConInt() + Lbl950Toplam.Text.ConInt() + Lbl1000Toplam.Text.ConInt() + Lbl1100Toplam.Text.ConInt() + Lbl1200Toplam.Text.ConInt() + Lbl1300Toplam.Text.ConInt() + Lbl1400AToplam.Text.ConInt() + Lbl1400BToplam.Text.ConInt() + Lbl2000Toplam.Text.ConInt() + Lbl2100Toplam.Text.ConInt()).ToString();

            LblYesilTop.Text = (Lbl200Toplam.Text.ConInt() + Lbl300Toplam.Text.ConInt() + Lbl1500Toplam.Text.ConInt() + Lbl1700Toplam.Text.ConInt() + Lbl1800Toplam.Text.ConInt() + Lbl1900Toplam.Text.ConInt()).ToString();

            LblGriTop.Text = (Lbl700Toplam.Text.ConInt() + Lbl750Toplam.Text.ConInt() + Lbl800Toplam.Text.ConInt() + Lbl1600Toplam.Text.ConInt()).ToString();

            LblTop.Text = (LblMaviTop.Text.ConInt() + LblYesilTop.Text.ConInt() + LblGriTop.Text.ConInt()).ToString();

            PastaFill();
            GrafikFill();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void TimerSaat_Tick(object sender, EventArgs e)
        {
            LblSaat.Text = DateTime.Now.ToString("HH:mm:ss");
            LblTarih.Text = DateTime.Now.ToLongDateString();
        }

        private void FrmSahaIzleme_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            TimerSaat.Stop();
            FrmAnaSayfa anaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnaSayfa"];
            anaSayfa.timerIzlemeChc.Stop();
            //FrmIzlemeAmbar frmIzlemeAmbar = (FrmIzlemeAmbar)Application.OpenForms["FrmIzlemeAmbar"];
            //if (frmIzlemeAmbar!=null)
            //{
            //    frmIzlemeAmbar.Close();
            //}
        }
        void GrafikFill()
        {
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "TOPLAM= ",
                    Values = new ChartValues<double> { Lbl200Toplam.Text.ConDouble(), Lbl300Toplam.Text.ConDouble(), Lbl400Toplam.Text.ConDouble(), Lbl500Toplam.Text.ConDouble(), Lbl600Toplam.Text.ConDouble(), Lbl700Toplam.Text.ConDouble(), Lbl750Toplam.Text.ConDouble(), Lbl800Toplam.Text.ConDouble(), Lbl900Toplam.Text.ConDouble(), Lbl950Toplam.Text.ConDouble(), Lbl1000Toplam.Text.ConDouble(), Lbl1100Toplam.Text.ConDouble(), Lbl1200Toplam.Text.ConDouble(), Lbl1300Toplam.Text.ConDouble(),Lbl1400AToplam.Text.ConDouble(),Lbl1400BToplam.Text.ConDouble(),Lbl1500Toplam.Text.ConDouble(),Lbl1600Toplam.Text.ConDouble(),Lbl1700Toplam.Text.ConDouble(),Lbl1800Toplam.Text.ConDouble(),Lbl1900Toplam.Text.ConDouble(),Lbl2000Toplam.Text.ConDouble(), Lbl2100Toplam.Text.ConDouble() },
                    DataLabels = true,
                    FontSize= 15,
                }
            };

            Axis axisX = new Axis()
            {
                Separator = new Separator() { Step = 1, IsEnabled = false },
                Labels = new List<string>()
            };

            Values = value => value.ToString("C2");

            ChrtIslemAdimlari.Series.Clear();
            ChrtIslemAdimlari.Series.Add(SeriesCollection[0]);

            ChrtIslemAdimlari.AxisX.Clear();

            axisX.Labels.Add("200");
            axisX.Labels.Add("300");
            axisX.Labels.Add("400");
            axisX.Labels.Add("500");
            axisX.Labels.Add("600");
            axisX.Labels.Add("700");
            axisX.Labels.Add("750");
            axisX.Labels.Add("800");
            axisX.Labels.Add("900");
            axisX.Labels.Add("950");
            axisX.Labels.Add("1000");
            axisX.Labels.Add("1100");
            axisX.Labels.Add("1200");
            axisX.Labels.Add("1300");
            axisX.Labels.Add("1400");
            axisX.Labels.Add("1450");
            axisX.Labels.Add("1500");
            axisX.Labels.Add("1600");
            axisX.Labels.Add("1700");
            axisX.Labels.Add("1800");
            axisX.Labels.Add("1900");
            axisX.Labels.Add("2000");
            axisX.Labels.Add("2100");

            ChrtIslemAdimlari.AxisX.Add(axisX);

            axisX.FontSize = 14;
        }

        void PastaFill()
        {
            ArizaBildirimTuru arizaBildirimTuru = arizaBildirimTuruManager.Get();

            SeriesCollection seriesCollection = new SeriesCollection();

            veriler.Add(arizaBildirimTuru.Sarf);
            veriler.Add(arizaBildirimTuru.KismiCalisan);
            veriler.Add(arizaBildirimTuru.Ekstra);
            veriler.Add(arizaBildirimTuru.Abf);
            veriler.Add(arizaBildirimTuru.SahaKabul);
            veriler.Add(arizaBildirimTuru.AcmaKapat);
            veriler.Add(arizaBildirimTuru.Diger);
            veriler.Add(arizaBildirimTuru.Entegrasyon);

            for (int i = 0; i < 8; i++)
            {
                if (i == 0)
                {
                    if (veriler[i]!=0)
                    {
                        Func<ChartPoint, string> func = x => string.Format("{0}", "SRF" + " (" + x.Y.ToString() + ")");
                        seriesCollection.Add(new PieSeries() { Title = "SARF", Values = new ChartValues<int> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 13 });
                        chart1.Series = seriesCollection;
                    }
                    
                }
                if (i == 1)
                {
                    if (veriler[i] != 0)
                    {
                        Func<ChartPoint, string> func = x => string.Format("{0}", "KÇ" + " (" + x.Y.ToString() + ")");
                        seriesCollection.Add(new PieSeries() { Title = "KISMİ ÇALIŞAN", Values = new ChartValues<int> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 13 });
                        chart1.Series = seriesCollection;
                    }
                }
                if (i == 2)
                {
                    if (veriler[i] != 0)
                    {
                        Func<ChartPoint, string> func = x => string.Format("{0}", "EKS" + " (" + x.Y.ToString() + ")");
                        seriesCollection.Add(new PieSeries() { Title = "EKSTRA", Values = new ChartValues<int> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 13 });
                        chart1.Series = seriesCollection;
                    }
                    
                }

                if (i == 3)
                {
                    if (veriler[i] != 0)
                    {
                        Func<ChartPoint, string> func = x => string.Format("{0}", "ABF" + " (" + x.Y.ToString() + ")");
                        seriesCollection.Add(new PieSeries() { Title = "ABF", Values = new ChartValues<int> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 13 });
                        chart1.Series = seriesCollection;
                    }
                }
                if (i == 4)
                {
                    if (veriler[i] != 0)
                    {
                        Func<ChartPoint, string> func = x => string.Format("{0}", "SHK" + " (" + x.Y.ToString() + ")");
                        seriesCollection.Add(new PieSeries() { Title = "SAHA KABUL", Values = new ChartValues<int> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 13 });
                        chart1.Series = seriesCollection;
                    }
                    
                }
                if (i == 5)
                {
                    if (veriler[i] != 0)
                    {
                        Func<ChartPoint, string> func = x => string.Format("{0}", "AÇK" + " (" + x.Y.ToString() + ")");
                        seriesCollection.Add(new PieSeries() { Title = "AÇMA KAPATMA", Values = new ChartValues<int> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 13 });
                        chart1.Series = seriesCollection;
                    }
                    
                }
                if (i == 6)
                {
                    if (veriler[i] != 0)
                    {
                        Func<ChartPoint, string> func = x => string.Format("{0}", "DĞR" + " (" + x.Y.ToString() + ")");
                        seriesCollection.Add(new PieSeries() { Title = "DİĞER", Values = new ChartValues<int> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 13 });
                        chart1.Series = seriesCollection;
                    }
                }

                if (i == 7)
                {
                    if (veriler[i] != 0)
                    {
                        Func<ChartPoint, string> func = x => string.Format("{0}", "ENT" + " (" + x.Y.ToString() + ")");
                        seriesCollection.Add(new PieSeries() { Title = "ENTEGRASYON", Values = new ChartValues<int> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 13 });
                        chart1.Series = seriesCollection;
                    }
                }
            }
        }

    }
}
