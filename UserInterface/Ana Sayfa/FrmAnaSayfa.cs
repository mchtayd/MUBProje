using Business;
using Business.Concreate;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using DataAccess.Concreate.IdariIsler;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;
using UserInterface.BakımOnarım;
using UserInterface.Depo;
using UserInterface.DokumanYonetim;
using UserInterface.EgitimDok;
using UserInterface.Gecic_Kabul_Ambar;
using UserInterface.IdariIşler;
using UserInterface.IdariIsler;
using UserInterface.RAPORLAMALAR;

namespace UserInterface.STS
{
    public partial class FrmAnaSayfa : Form
    {
        SatinAlinacakMalManager satinAlinacakMalManager;
        DvNoManager dvNoManager;
        VersionManager versionManager;
        FrmWait frmWait = new FrmWait();
        public object[] infos;
        public object[] infos1;
        int control = 0;
        int atla = 0, atladal = 0, personId, authId;
        string izinIdleri;

        public FrmAnaSayfa()
        {
            InitializeComponent();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            versionManager = VersionManager.GetInstance();
            dvNoManager = DvNoManager.GetInstance();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            tabAnasayfa.Visible = false;
            FillInfos();
            //LblTarih.Text = DateTime.Now;
            LblTarih.Text = DateTime.Now.ToLongDateString();
            TimerSaat.Start();

            personId = infos[0].ConInt();
            authId = infos[5].ConInt();
            izinIdleri = infos[6].ToString();
            if (personId == 25)
            {
                VersionEkle.Visible = true;
                button3.Visible = true;
                BtnDosyaKitle.Visible = true;
            }
            Admin();
            ControlNodes(authId);
            button1.Image = imageList.Images["kucultme.png"];
            LblVersionNo.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            VersionBul();
        }
        private void FrmAnaSayfa_Shown(object sender, EventArgs e)
        {
            if (personId == 84)
            {
                FrmDevam frmDevam = new FrmDevam();
                frmDevam.FormBorderStyle = FormBorderStyle.None;
                frmDevam.TopLevel = false;
                frmDevam.AutoScroll = true;
                OpenTabPage("PageDevam", "DEVAM/DEVAMSIZLIK", frmDevam);
                frmDevam.Show();
                foreach (TabPage item in tabAnasayfa.TabPages)
                {
                    item.Controls[0].Size = new Size(tabAnasayfa.Size.Width - 100, tabAnasayfa.Size.Height - 100);
                }
            }
        }
        void Admin()
        {
            if (authId == 4 || authId == 1)
            {
                FrmAdmin.Visible = true;
            }
        }
        void ControlNodes(int authId)
        {
            treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["SatOnOnay"].Remove();
            if (authId == 4 || authId == 1)
            {
                return;
            }
            //string izin_idleri = "59;60;61";
            string[] array = izinIdleri.Split(';');
            #region Baslıklar
            if (!array.Contains("1"))
            {
                treeView2.Nodes["BAKIM ONARIM"].Remove();
                control = 1;
            }
            if (control != 1)
            {
                if (!array.Contains("2"))
                {
                    treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Remove();
                    atla = 1;
                }
                if (atla != 1)
                {
                    TreeNode treeNode = treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"];
                    if (!array.Contains("3"))
                    {
                        treeNode.Nodes["Devam Eden Arıza"].Remove();
                    }
                    if (!array.Contains("4"))
                    {
                        treeNode.Nodes["Tamamlanan Arıza"].Remove();
                    }
                    if (!array.Contains("5"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["Iscilik Izleme"].Remove();
                    }
                    if (!array.Contains("6"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["Bolge Yol Durumu"].Remove();
                    }
                    if (!array.Contains("7"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["Yerlesim Kayıtları"].Remove();
                    }
                    if (!array.Contains("8"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["OKF"].Remove();
                    }
                    if (!array.Contains("9"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["DTF"].Remove();
                    }
                    if (!array.Contains("10"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["Musteri Bildiri"].Remove();
                    }
                    if (!array.Contains("11"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["Teslimat Istekleri"].Remove();
                    }
                    if (!array.Contains("12"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["Firma Servis Formu"].Remove();
                    }
                    if (!array.Contains("13"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["Destek Iscilik"].Remove();
                    }
                }
                if (!array.Contains("14"))
                {
                    treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Remove();
                    atla = 2;
                }
                if (atla != 2)
                {
                    if (!array.Contains("15"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Veri Kayit Arıza Acma"].Remove();
                    }
                    if (!array.Contains("16"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Bildirim No Tanimlama"].Remove();
                    }
                    if (!array.Contains("17"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Veri Guncelleme"].Remove();
                    }
                    if (!array.Contains("18"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Veri Kayit Ariza Kapatma"].Remove();
                    }
                    if (!array.Contains("19"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Musteri Bilgileri"].Remove();
                    }
                    if (!array.Contains("20"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Bolge Yol Durumu"].Remove();
                    }
                    if (!array.Contains("21"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Yerlesim Kayitlari"].Remove();
                    }
                    if (!array.Contains("22"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Bildirim Onayi"].Remove();
                    }
                    if (!array.Contains("23"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Malzeme Temini"].Remove();
                    }
                    if (!array.Contains("24"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Dogrudan Temini"].Remove();
                    }
                    if (!array.Contains("25"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Servis Talepleri"].Remove();
                    }
                    if (!array.Contains("26"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["OKF Olusturma"].Remove();
                    }
                    if (!array.Contains("27"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Teslimat Eksikleri"].Remove();
                    }
                    if (!array.Contains("28"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Firma Servis Formu Kayit"].Remove();
                    }
                    if (!array.Contains("29"))
                    {
                        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Destek Iscilik"].Remove();
                    }
                }
            }
            if (!array.Contains("30"))
            {
                treeView2.Nodes["GECICI KABUL AMBAR"].Remove();
                control = 2;
            }
            if (control != 2)
            {
                if (!array.Contains("31"))
                {
                    treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI IZLEME"].Remove();
                    atla = 3;
                }
                if (atla != 3)
                {
                    if (!array.Contains("32"))
                    {
                        treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI IZLEME"].Nodes["Stok Goruntule"].Remove();
                    }
                    if (!array.Contains("33"))
                    {
                        treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI IZLEME"].Nodes["Depo Hareketleri"].Remove();
                    }
                    if (!array.Contains("34"))
                    {
                        treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI IZLEME"].Nodes["Stokta Bulunmayan Malzeme"].Remove();
                    }
                    if (!array.Contains("35"))
                    {
                        treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI IZLEME"].Nodes["KayitliMalzemeler"].Remove();
                    }
                }
                if (!array.Contains("36"))
                {
                    treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI GIRIS"].Remove();
                    atla = 4;
                }
                if (atla != 4)
                {
                    if (!array.Contains("37"))
                    {
                        treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI GIRIS"].Nodes["Stok Giris Cikis"].Remove();
                    }
                    if (!array.Contains("38"))
                    {
                        treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI GIRIS"].Nodes["Malzeme Kayit Ambar"].Remove();
                    }
                    if (!array.Contains("39"))
                    {
                        treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI GIRIS"].Nodes["Malzeme Hazirlama"].Remove();
                    }
                }
            }

            if (!array.Contains("40"))
            {
                treeView2.Nodes["SATIN ALMA"].Remove();
                control = 3;
            }
            if (control != 3)
            {
                if (!array.Contains("41"))
                {
                    treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI IZLEME"].Remove();
                    atla = 4;
                }
                if (atla != 4)
                {
                    if (!array.Contains("42"))
                    {
                        treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI IZLEME"].Nodes["devamedensat"].Remove();
                    }
                    if (!array.Contains("43"))
                    {
                        treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI IZLEME"].Nodes["Tamamlanan Sat"].Remove();
                    }
                    if (!array.Contains("44"))
                    {
                        treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI IZLEME"].Nodes["RedEdilenSat"].Remove();
                    }
                    if (!array.Contains("45"))
                    {
                        treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI IZLEME"].Nodes["Sat Yedek Parca Katalogu"].Remove();
                    }
                }
                if (!array.Contains("46"))
                {
                    treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Remove();
                    atla = 5;
                }
                if (atla != 5)
                {
                    if (!array.Contains("47"))
                    {
                        treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["satolustur"].Remove();
                    }
                    if (!array.Contains("48"))
                    {
                        treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["SatOnOnay"].Remove();
                    }
                    if (!array.Contains("49"))
                    {
                        treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["Sat Baslatma Onayi"].Remove();
                    }
                    if (!array.Contains("50"))
                    {
                        treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["TeklifAlınacakSat"].Remove();
                    }
                    if (!array.Contains("51"))
                    {
                        treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["Satın Alınacak Malzemeler"].Remove();
                    }
                    if (!array.Contains("52"))
                    {
                        treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["SatOnay"].Remove();
                    }
                    if (!array.Contains("53"))
                    {
                        treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["Sat Tamamlama"].Remove();
                    }
                    if (!array.Contains("54"))
                    {
                        treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["Sat Guncelle"].Remove();
                    }
                    if (!array.Contains("55"))
                    {
                        treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["Tedarikci Firma"].Remove();
                    }
                    if (!array.Contains("56"))
                    {
                        treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["Alt Yuklenici Firma"].Remove();
                    }
                }
            }
            if (!array.Contains("57"))
            {
                treeView2.Nodes["DOKUMAN YONETIM"].Remove();
                control = 4;
            }
            if (control != 4)
            {
                if (!array.Contains("58"))
                {
                    treeView2.Nodes["DOKUMAN YONETIM"].Nodes["DY VERI IZLEME"].Remove();
                    atla = 6;
                }
                if (atla != 6)
                {
                    if (!array.Contains("59"))
                    {
                        treeView2.Nodes["DOKUMAN YONETIM"].Nodes["DY VERI IZLEME"].Nodes["Dokuman Sorgula"].Remove();
                    }
                    if (!array.Contains("60"))
                    {
                        treeView2.Nodes["DOKUMAN YONETIM"].Nodes["DY VERI IZLEME"].Nodes["Standart Form Sorgula"].Remove();
                    }
                }
                if (!array.Contains("61"))
                {
                    treeView2.Nodes["DOKUMAN YONETIM"].Nodes["DY VERI GIRIS"].Remove();
                    atla = 7;
                }
                if (atla != 7)
                {
                    if (!array.Contains("62"))
                    {
                        treeView2.Nodes["DOKUMAN YONETIM"].Nodes["DY VERI GIRIS"].Nodes["Dokuman Ekle"].Remove();
                    }
                    if (!array.Contains("63"))
                    {
                        treeView2.Nodes["DOKUMAN YONETIM"].Nodes["DY VERI GIRIS"].Nodes["Standart Form Ekle"].Remove();
                    }
                }
            }
            if (!array.Contains("64"))
            {
                treeView2.Nodes["IDARI ISLER"].Remove();
                control = 5;
            }
            if (control != 5)
            {
                if (!array.Contains("65"))
                {
                    treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Remove();
                    atla = 8;
                }
                if (atla != 8)
                {
                    if (!array.Contains("66"))
                    {
                        treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Duran Varlık"].Remove();
                        atladal = 1;
                    }
                    if (atladal != 1)
                    {
                        if (!array.Contains("67"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Duran Varlık"].Nodes["DuranVarlikKayit"].Remove();
                        }
                        if (!array.Contains("68"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Duran Varlık"].Nodes["DuranVarlikAkarma"].Remove();
                        }
                        if (!array.Contains("69"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Duran Varlık"].Nodes["Duran Varlik Ariza Kayit"].Remove();
                        }
                        if (!array.Contains("70"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Duran Varlık"].Nodes["DV Kalibrasyon Kayit"].Remove();
                        }
                    }
                    if (!array.Contains("71"))
                    {
                        treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Personel"].Remove();
                        atladal = 2;
                    }
                    if (atladal != 2)
                    {
                        if (!array.Contains("72"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Personel"].Nodes["PersonelKayit"].Remove();
                        }
                        if (!array.Contains("73"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Personel"].Nodes["PersonelPuantaj"].Remove();
                        }
                    }
                    if (!array.Contains("74"))
                    {
                        treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Is Akislari"].Remove();
                        atladal = 3;
                    }
                    if (atladal != 3)
                    {
                        if (!array.Contains("75"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Is Akislari"].Nodes["Yurt Icı Gorev"].Remove();
                        }
                        if (!array.Contains("76"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Is Akislari"].Nodes["Sehir Icı Gorev"].Remove();
                        }
                        if (!array.Contains("77"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Is Akislari"].Nodes["Izın"].Remove();
                        }
                        if (!array.Contains("78"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Is Akislari"].Nodes["Konaklama"].Remove();
                        }
                        if (!array.Contains("79"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Is Akislari"].Nodes["Ucak Otobus Bileti"].Remove();
                        }
                        if (!array.Contains("80"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Is Akislari"].Nodes["Harcama Beyannamesi"].Remove();
                        }
                    }
                    if (!array.Contains("81"))
                    {
                        treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Resmi Yazilar"].Remove();
                        atladal = 4;
                    }
                    if (atladal != 4)
                    {
                        if (!array.Contains("82"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Resmi Yazilar"].Nodes["Evrak Kayit"].Remove();
                        }
                    }
                    if (!array.Contains("83"))
                    {
                        treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Arsiv"].Remove();
                    }
                    if (!array.Contains("84"))
                    {
                        treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Ulastırma"].Remove();
                        atladal = 5;
                    }
                    if (atladal != 5)
                    {
                        if (!array.Contains("85"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Ulastırma"].Nodes["Arac Tesis Kayit"].Remove();
                        }
                        if (!array.Contains("86"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Ulastırma"].Nodes["Arac Yakit Beyani"].Remove();
                        }
                        if (!array.Contains("87"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Ulastırma"].Nodes["Arac Periyodik Bakım"].Remove();
                        }
                        if (!array.Contains("88"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Ulastırma"].Nodes["Arac Bakim Onarim"].Remove();
                        }
                    }
                }
                if (!array.Contains("89"))
                {
                    treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Remove();
                    atla = 9;
                }
                if (atla != 9)
                {
                    if (!array.Contains("90"))
                    {
                        treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Duran Varlik Izleme"].Remove();
                        atladal = 6;
                    }
                    if (atladal != 6)
                    {
                        if (!array.Contains("91"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Duran Varlik Izleme"].Nodes["DuranVarlikTakip"].Remove();
                        }
                        if (!array.Contains("92"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Duran Varlik Izleme"].Nodes["DV Zimmet Takibi"].Remove();
                        }
                        if (!array.Contains("93"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Duran Varlik Izleme"].Nodes["DV Ariza Takibi"].Remove();
                        }
                        if (!array.Contains("94"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Duran Varlik Izleme"].Nodes["DV Kalibrasyon Takibi"].Remove();
                        }
                    }
                    if (!array.Contains("95"))
                    {
                        treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Personel Izleme"].Remove();
                        atladal = 7;
                    }
                    if (atladal != 7)
                    {
                        if (!array.Contains("96"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Personel Izleme"].Nodes["PersonelListesi"].Remove();
                        }
                        if (!array.Contains("97"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Personel Izleme"].Nodes["PersonelListesiAyrilan"].Remove();
                        }
                        if (!array.Contains("98"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Personel Izleme"].Nodes["Personel Puantaj"].Remove();
                        }
                    }
                    if (!array.Contains("99"))
                    {
                        treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Is Akislari Izleme"].Remove();
                        atladal = 8;
                    }
                    if (atladal != 8)
                    {
                        if (!array.Contains("100"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Is Akislari Izleme"].Nodes["Yurt Icı GorevIzleme"].Remove();
                        }
                        if (!array.Contains("101"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Is Akislari Izleme"].Nodes["Sehir Ici Gorev"].Remove();
                        }
                        if (!array.Contains("102"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Is Akislari Izleme"].Nodes["Izin Izleme"].Remove();
                        }
                        if (!array.Contains("103"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Is Akislari Izleme"].Nodes["Konaklama Izleme"].Remove();
                        }
                        if (!array.Contains("104"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Is Akislari Izleme"].Nodes["Ucak Otobus Izleme"].Remove();
                        }
                        if (!array.Contains("105"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Is Akislari Izleme"].Nodes["Harcama Beyan Izleme"].Remove();
                        }
                    }
                    if (!array.Contains("106"))
                    {
                        treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Gelen Giden Yazi Izleme"].Remove();
                    }
                    if (!array.Contains("107"))
                    {
                        treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Arsiv Izleme"].Remove();
                    }
                    if (!array.Contains("108"))
                    {
                        treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["UlastırmaIzleme"].Remove();
                        atladal = 9;
                    }
                    if (atladal != 9)
                    {
                        if (!array.Contains("109"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["UlastırmaIzleme"].Nodes["Arac Tahsis Izleme"].Remove();
                        }
                        if (!array.Contains("110"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["UlastırmaIzleme"].Nodes["Arac Yakıt Izleme"].Remove();
                        }
                        if (!array.Contains("111"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["UlastırmaIzleme"].Nodes["Arac Periyodik Izleme"].Remove();
                        }
                        if (!array.Contains("112"))
                        {
                            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["UlastırmaIzleme"].Nodes["Arac Bakim Onarim Izleme"].Remove();
                        }
                    }
                }
            }
            if (!array.Contains("113"))
            {
                treeView2.Nodes["EGITIM"].Remove();
                control = 6;
            }
            if (control != 6)
            {
                if (!array.Contains("114"))
                {
                    treeView2.Nodes["EGITIM"].Nodes["E VERI GIRIS"].Remove();
                    atla = 10;
                }
                if (atla != 10)
                {
                    if (!array.Contains("115"))
                    {
                        treeView2.Nodes["EGITIM"].Nodes["E VERI GIRIS"].Nodes["Egitim Veri Giris"].Remove();
                    }
                    if (!array.Contains("116"))
                    {
                        treeView2.Nodes["EGITIM"].Nodes["E VERI GIRIS"].Nodes["Egitim Planı Olustur"].Remove();
                    }
                    if (!array.Contains("117"))
                    {
                        treeView2.Nodes["EGITIM"].Nodes["E VERI GIRIS"].Nodes["Egitim Planı Guncelle"].Remove();
                    }
                }
                if (!array.Contains("118"))
                {
                    treeView2.Nodes["EGITIM"].Nodes["E VERI IZLEME"].Remove();
                    atla = 11;
                }
                if (atla != 11)
                {
                    if (!array.Contains("119"))
                    {
                        treeView2.Nodes["EGITIM"].Nodes["E VERI IZLEME"].Nodes["Egitim Izleme"].Remove();
                    }
                    if (!array.Contains("120"))
                    {
                        treeView2.Nodes["EGITIM"].Nodes["E VERI IZLEME"].Nodes["Egitim Planı Izleme"].Remove();
                    }
                }
            }
            if (!array.Contains("121"))
            {
                treeView2.Nodes["DESTEK DEPO"].Remove();
                control = 7;
            }
            if (control != 7)
            {
                if (!array.Contains("122"))
                {
                    treeView2.Nodes["DESTEK DEPO"].Nodes["DD VERI IZLEME"].Remove();
                    atla = 12;
                }
                if (atla != 12)
                {
                    if (!array.Contains("123"))
                    {
                        treeView2.Nodes["DESTEK DEPO"].Nodes["DD VERI IZLEME"].Nodes["Stok Goruntule Depo"].Remove();
                    }
                    if (!array.Contains("124"))
                    {
                        treeView2.Nodes["DESTEK DEPO"].Nodes["DD VERI IZLEME"].Nodes["Depo Hareketleri Depo"].Remove();
                    }
                    if (!array.Contains("125"))
                    {
                        treeView2.Nodes["DESTEK DEPO"].Nodes["DD VERI IZLEME"].Nodes["Stokta Bulunmayan Malz"].Remove();
                    }
                }
                if (!array.Contains("126"))
                {
                    treeView2.Nodes["DESTEK DEPO"].Nodes["DD VERI GIRIS"].Remove();
                    atla = 13;
                }
                if (atla != 13)
                {
                    if (!array.Contains("127"))
                    {
                        treeView2.Nodes["DESTEK DEPO"].Nodes["DD VERI GIRIS"].Nodes["Stok Giris"].Remove();
                    }
                    if (!array.Contains("128"))
                    {
                        treeView2.Nodes["DESTEK DEPO"].Nodes["DD VERI GIRIS"].Nodes["Malzeme Kayit"].Remove();
                    }
                    if (!array.Contains("129"))
                    {
                        treeView2.Nodes["DESTEK DEPO"].Nodes["DD VERI GIRIS"].Nodes["Malzeme Hazirlama"].Remove();
                    }
                }
            }
            if (!array.Contains("130"))
            {
                treeView2.Nodes["RAPORLAMALAR"].Remove();
                control = 8;
            }
            if (control != 8)
            {
                if (!array.Contains("131"))
                {
                    treeView2.Nodes["RAPORLAMALAR"].Nodes["R VERI IZLEME"].Remove();
                }
                if (!array.Contains("132"))
                {
                    treeView2.Nodes["RAPORLAMALAR"].Nodes["R VERI GIRIS"].Remove();
                }
            }
        }
        #endregion

        void FillInfos()
        {
            LblKullanici.Text = infos[1].ToString();
        }

        // dallar

        private void aDMİNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdmin frmAdmin = new FrmAdmin();
            frmAdmin.infos = infos;
            frmAdmin.ShowDialog();
        }

        private void şİFREDEĞİŞTİRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSifremiDegistir frmSifremiDegistir = new FrmSifremiDegistir();
            frmSifremiDegistir.infos = infos;
            frmSifremiDegistir.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width = panel1.Width + 10;
            if (panel1.Size.Width == 340)
            {
                timer1.Stop();
                button1.Image = imageList.Images["kucultme.png"];
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel1.Width = panel1.Width - 20;
            if (panel1.Size.Width == 40)
            {
                timer2.Stop();
                lblCompanyName.Visible = true;
                button1.Image = imageList.Images["buyutme.png"];
            }
        }
        void TabControlGenislet()
        {
            tabAnasayfa.Location = new Point(47, 27);
            tabAnasayfa.Size = new Size(this.Size.Width - 100, this.Size.Height - 100);
            foreach (TabPage item in tabAnasayfa.TabPages)
            {
                item.Controls[0].Size = new Size(this.Size.Width - 100, this.Size.Height - 100);
            }
        }
        void TabControlDaralt()
        {
            tabAnasayfa.Location = new Point(335, 27);
            tabAnasayfa.Size = new Size(this.Size.Width - 100, this.Size.Height - 100);
            foreach (TabPage item in tabAnasayfa.TabPages)
            {
                item.Controls[0].Size = new Size(this.Size.Width - 350, this.Size.Height - 100);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 40)
            {
                timer1.Start();
                treeView2.Visible = true;
                TabControlDaralt();
                lblCompanyName.Visible = false;
            }
            if (panel1.Width > 300)
            {
                timer2.Start();
                treeView2.Visible = false;
                TabControlGenislet();
            }
        }

        private void favorilereEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (treeView2.SelectedNode.Tag.ToString() != "Header")
            {
                string nodeName = treeView2.SelectedNode.Name;
            }*/
        }
        bool kapatBilgisi = true;
        void VersionBul()
        {
            List<VersionBilgi> versionBilgis = new List<VersionBilgi>();
            versionBilgis = versionManager.GetList();
            if (versionBilgis.Count == 0)
            {
                return;
            }
            string yeniversion = versionBilgis[0].VersionNo;
            string path = versionBilgis[0].Dosyayolu;
            string eskiversion = LblVersionNo.Text;
            if (yeniversion != eskiversion)
            {
                DialogResult dr = MessageBox.Show("Merhaba " + LblKullanici.Text + ",\nYeni Bir DTS Versionu Tespit Edilmiştir.\nVersion :" + yeniversion + " Güncellemek İster Misiniz?",
                    "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    LblVersionNo.Text = versionBilgis[0].VersionNo;
                    System.Diagnostics.Process.Start(path);
                    kapatBilgisi = false;
                    Application.Exit();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e) //BtnGit
        {
            /*string path = "C:\\Users\\MAYıldırım\\source\\repos\\MUBProje\\UserInterface\\publish\\DTS Version.application";
            //string path = "Z:\\DTS\\DTS Setup\\publish\\DTS Version.application";
            openFileDialog1.ShowDialog();
            path = openFileDialog1.FileName.ToString();
            /*System.Diagnostics.Process.Start(path);
            Application.Exit();*/
        }

        private void VersionEkle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Yeni Version Çıkarmadan Önce publis çıkarmayı ve onu servere atmayı unutmayın yaptıysanız devam edin, Devam Etmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //string path = "C:\\Users\\MAYıldırım\\source\\repos\\MUBProje\\UserInterface\\publish\\DTS Version.application";
                string path = "Z:\\DTS\\DTS Setup\\publish\\DTS.application";
                string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                VersionBilgi versionBilgi = new VersionBilgi(version, path);
                string mesaj = versionManager.Add(versionBilgi);
                if (mesaj == "OK")
                {
                    MessageBox.Show("Yeni Version Bilgisi VERİ TABANINA Yazıldı, Kullanıcılara Bilgi Gidecektir.");
                }
                else
                {
                    MessageBox.Show(mesaj);
                }
            }
        }

        private void BtnDosyaKitle_Click(object sender, EventArgs e)
        {
            //KİTLE
            //string folderPath = "C:\\Users\\MAYıldırım\\Desktop\\C# Notes\\Secret\\Locker";
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            string folderPath = folderBrowser.SelectedPath;
            if (folderPath == "")
            {
                MessageBox.Show("Klasor Seçmedin.");
                return;
            }
            string adminUserName = Environment.UserName;
            DirectorySecurity ds = Directory.GetAccessControl(folderPath);
            FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
            ds.AddAccessRule(fsa);
            Directory.SetAccessControl(folderPath, ds);
            MessageBox.Show(folderPath + "\nBaşarı");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DateTime dateTime = dataReader["BASLAMA_TARİHİ"].ConTime();
            //string gecenSure = (DateTime.Now.Subtract(dateTime)).ToString();
            //gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.')); 

            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            string folderPath = folderBrowser.SelectedPath;
            if (folderPath == "")
            {
                MessageBox.Show("Klasor Seçmedin.");
                return;
            }
            string adminUserName = Environment.UserName;
            DirectorySecurity ds = Directory.GetAccessControl(folderPath);
            FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
            bool result = ds.RemoveAccessRule(fsa);
            Directory.SetAccessControl(folderPath, ds);
            MessageBox.Show(folderPath + "\nBaşarı" + result);
        }

        private void dEVAMDEVAMSIZLIKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDevam frmDevam = new FrmDevam();
            frmDevam.FormBorderStyle = FormBorderStyle.None;
            frmDevam.TopLevel = false;
            frmDevam.AutoScroll = true;
            OpenTabPage("PageDevam", "DEVAM/DEVAMSIZLIK", frmDevam);
            frmDevam.Show();
        }

        private void TimerSaat_Tick(object sender, EventArgs e)
        {
            LblSaat.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void tabAnasayfa_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabAnasayfa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = tabAnasayfa.SelectedIndex;
            if (index == -1)
            {
                return;
            }
            else
            {
                string baslik = tabAnasayfa.SelectedTab.Text;
                if (baslik == "EVRAK KAYIT")
                {
                    var form = (FrmEvrakKayit)Application.OpenForms["FrmEvrakKayit"];
                    if (form != null)
                    {
                        form.IsAkisNo();
                    }
                }
                if (baslik == "GELEN/GİDEN RESMİ YAZI İZLEME")
                {
                    var form = (FrmEvrekKayitIzleme)Application.OpenForms["FrmEvrekKayitIzleme"];
                    if (form != null)
                    {
                        form.DataDisplay();

                    }
                }
                if (baslik == "DOKÜMAN EKLE")
                {
                    var form = (FrmDokumanEkle)Application.OpenForms["FrmDokumanEkle"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "STANDART FORM SORGULA")
                {
                    var form = (FrmStandartForm)Application.OpenForms["FrmStandartForm"];
                    if (form != null)
                    {
                        form.DtgDoldur();
                    }
                }
                if (baslik == "DOKÜMAN SORGULA")
                {
                    var form = (FrmDokumanSorgula)Application.OpenForms["FrmDokumanSorgula"];
                    if (form != null)
                    {
                        form.DtgDoldur();
                    }
                }
                if (baslik == "STANDART FORM EKLE")
                {
                    var form = (FrmStandartFormEkle)Application.OpenForms["FrmStandartFormEkle"];
                    if (form != null)
                    {
                        form.DtgDoldur();
                    }
                }
                if (baslik == "PERSONEL KAYIT")
                {
                    var form = (FrmPersonelKayit)Application.OpenForms["FrmPersonelKayit"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "PERSONEL LİSTESİ")
                {
                    var form = (FrmPersonelListesi)Application.OpenForms["FrmPersonelListesi"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "PERSONEL LİSTESİ (AYRILAN)")
                {
                    var form = (FrmPersonelListesiAyrilan)Application.OpenForms["FrmPersonelListesiAyrilan"];
                    if (form != null)
                    {
                        form.YenilecenekVeri();
                    }
                }
                if (baslik == "UÇAK/OTOBÜS BİLETİ GÖRÜNTÜLE")
                {
                    var form = (FrmUcakOtobusBiletiIzleme)Application.OpenForms["FrmUcakOtobusBiletiIzleme"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "UÇAK/OTOBÜS BİLETİ")
                {
                    var form = (FrmUcakOtobusBileti)Application.OpenForms["FrmUcakOtobusBileti"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "ŞEHİR İÇİ GÖREV")
                {
                    var form = (FrmSehirIcıGorev)Application.OpenForms["FrmSehirIcıGorev"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "YURT İÇİ GÖREV")
                {
                    var form = (FrmYurtİciGorev)Application.OpenForms["FrmYurtİciGorev"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "PERSONEL İZİN")
                {
                    var form = (FrmIzin)Application.OpenForms["FrmIzin"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "PERSONEL İZİN GÖRÜNTÜLE")
                {
                    var form = (FrmIzinIzleme)Application.OpenForms["FrmIzinIzleme"];
                    if (form != null)
                    {
                        form.DtgIzinList();
                    }
                }
                if (baslik == "KONAKLAMA")
                {
                    var form = (FrmKonaklama)Application.OpenForms["FrmKonaklama"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "KONAKLAMA GÖRÜNTÜLE")
                {
                    var form = (FrmKonaklamaIzleme)Application.OpenForms["FrmKonaklamaIzleme"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "ŞEHİR İÇİ GÖREV GÖRÜNTÜLE")
                {
                    var form = (FrmSehirIciGorevIzleme)Application.OpenForms["FrmSehirIciGorevIzleme"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "YURT İÇİ GÖREV GÖRÜNTÜLE")
                {
                    var form = (FrmYurtIciGorevIzleme)Application.OpenForms["FrmYurtIciGorevIzleme"];
                    if (form != null)
                    {
                        form.YenilecekVeriler();
                    }
                }
                if (baslik == "ARAÇ KAYDET")
                {
                    var form = (FrmAracKaydet)Application.OpenForms["FrmAracKaydet"];
                    if (form != null)
                    {
                        form.YenilecekVeriler();
                    }
                }
                if (baslik == "ARAÇ TAHSİS BİLGİLERİ")
                {
                    var form = (FrmAracTahsisBilgileri)Application.OpenForms["FrmAracTahsisBilgileri"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "DURAN VARLIK KAYIT")
                {
                    var form = (DuranVarlik)Application.OpenForms["DuranVarlik"];
                    if (form != null)
                    {
                        form.IsAkisNo();
                    }
                }
                if (baslik == "DURAN VARLIK AKTARIM")
                {
                    var form = (FrmDuranVarlikAktarim)Application.OpenForms["FrmDuranVarlikAktarim"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "DURAN VARLIK TAKİP")
                {
                    var form = (FrmDuranVarlikTakip)Application.OpenForms["FrmDuranVarlikTakip"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "ARAÇ YAKIT BEYANI")
                {
                    var form = (FrmYakitBeyani)Application.OpenForms["FrmYakitBeyani"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "ARAÇ YAKIT BEYANI GÖRÜNTÜLE")
                {
                    var form = (FrmYakitBeyaniIzleme)Application.OpenForms["FrmYakitBeyaniIzleme"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "GELEN/GİDEN RESMİ YAZI İZLEME")
                {
                    var form = (FrmEvrekKayitIzleme)Application.OpenForms["FrmEvrekKayitIzleme"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "ARAÇ BAKIM KAYIT")
                {
                    var form = (FrmAracBakimKayit)Application.OpenForms["FrmAracBakimKayit"];
                    if (form != null)
                    {
                        form.IsAkisNo();
                    }
                }
                if (baslik == "ARAÇ BAKIM ONARIM İZLEME")
                {
                    var form = (FrmAracBakimKayitIzleme)Application.OpenForms["FrmAracBakimKayitIzleme"];
                    if (form != null)
                    {
                        form.Yenilenecekler();
                    }
                }
                if (baslik == "DV ZİMMET TAKİP")
                {
                    var form = (FrmDVZimmetTakibi)Application.OpenForms["FrmDVZimmetTakibi"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "ALT YÜKLENİCİ FİRMALAR")
                {
                    var form = (FrmAltYukleniciFirma)Application.OpenForms["FrmAltYukleniciFirma"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "SAT OLUŞTUR") 
                {
                    var form = (FrmSatOlustur2)Application.OpenForms["FrmSatOlustur2"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "TEKLİF ALINACAK SAT")
                {
                    var form = (FrmTeklifAlinacakSat)Application.OpenForms["FrmTeklifAlinacakSat"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "SAT ONAY")
                {
                    var form = (FrmSatOnay)Application.OpenForms["FrmSatOnay"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "SAT BAŞLATMA ONAYI")
                {
                    var form = (FrmSatBaslatmaOnayi)Application.OpenForms["FrmSatBaslatmaOnayi"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "SAT TAMAMLAMA")
                {
                    var form = (FrmSatTamamlama)Application.OpenForms["FrmSatTamamlama"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "TEDARİKÇİ FİRMA BİLGİLERİ")
                {
                    var form = (FrmTedarikciFirmaBilgileri)Application.OpenForms["FrmTedarikciFirmaBilgileri"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "DEVAM EDEN SATLAR") 
                {
                    var form = (FrmDevamEdenSat)Application.OpenForms["FrmDevamEdenSat"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "DEVAM EDEN SATLAR")
                {
                    var form = (FrmDevamEdenSat)Application.OpenForms["FrmDevamEdenSat"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "REDDEDİLEN SATLAR")
                {
                    var form = (FrmReddedilenSatlar)Application.OpenForms["FrmReddedilenSatlar"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "TEKLİFSİZ SAT")
                {
                    var form = (FrmTeklifsizSat)Application.OpenForms["FrmTeklifsizSat"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
            }
        }

        private void oRGANİZSAYONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOrganizasyon frmOrganizasyon = new FrmOrganizasyon();
            frmOrganizasyon.ShowDialog();
        }

        private void oNAYEKRANLARIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOnayEkranlari Go = new FrmOnayEkranlari();
            Go.infos = infos;
            Go.FormBorderStyle = FormBorderStyle.None;
            Go.TopLevel = false;
            Go.AutoScroll = true;
            OpenTabPage("PageOnayEkranlari", "ONAY EKRANLARI", Go);
            Go.Show();
        }

        public void OpenTabPage(string pageName, string pageText, Control winForm)
        {
            if (tabAnasayfa.TabPages[pageName] != null)
            {
                tabAnasayfa.SelectedTab = tabAnasayfa.TabPages[pageName];
                return;
            }
            tabAnasayfa.Visible = true;
            TabPage tabPage = new TabPage(pageText);
            //tabPage.SetBounds(tabPage.Bounds.X, tabPage.Bounds.Y, 500, tabPage.Bounds.Height);
            tabPage.Size = new Size(500, 75);
            tabAnasayfa.TabPages.Add(tabPage);
            tabPage.Name = pageName;
            //tabPage.Width = 500;
            tabPage.Controls.Add(winForm);
            tabAnasayfa.SelectedTab = tabAnasayfa.TabPages[pageName];
        }



        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (treeView2.SelectedNode.Tag != null)
                {
                    if (treeView2.SelectedNode.Tag.ToString() == "Header")
                    {
                        contextTreeView.Close();
                        string nodeName = treeView2.SelectedNode.Name;
                    }
                }

                return;
            }

            #region Left_Click

            /////////////////////////////////////////////////BAKIM ONARIM//////////////////////////////////////////////////////////////////////

            if (e.Node.Name == "Veri Kayit Arıza Acma")
            {
                FrmArizaAcma Go = new FrmArizaAcma();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArizaAcma", "ABF ARIZA AÇMA", Go);
                Go.Show();
            }
            if (e.Node.Name == "Firma Servis Formu Kayit")
            {
                FrmServisFormuKayit Go = new FrmServisFormuKayit();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageServisFormuKayit", "SERVİS FORMU KAYIT", Go);
                Go.Show();
            }

            /////////////////////////////////////////////////SATIN ALMA////////////////////////////////////////////////////////////////////////
            if (e.Node.Name == "satolustur")
            {
                FrmSatOlustur2 Go = new FrmSatOlustur2();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatOlustur2", "SAT OLUŞTUR", Go);
                Go.Show();
            }
            if (e.Node.Name == "TeklifAlınacakSat")
            {
                FrmTeklifAlinacakSat Go = new FrmTeklifAlinacakSat();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageTeklifAlinacak", "TEKLİF ALINACAK SAT", Go);
                Go.Show();
            }
            if (e.Node.Name == "SatOnay")
            {
                FrmSatOnay Go = new FrmSatOnay();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatOnay", "SAT ONAY", Go);
                Go.Show();
            }
            if (e.Node.Name == "SatOnOnay")
            {
                /*FrmSatOnOnay Go = new FrmSatOnOnay();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatOnOnay", "SAT ÖN ONAY", Go);
                Go.Show();*/
            }
            if (e.Node.Name == "Sat Baslatma Onayi")
            {
                FrmSatBaslatmaOnayi Go = new FrmSatBaslatmaOnayi();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatBaslatma", "SAT BAŞLATMA ONAYI", Go);
                Go.Show();
            }
            if (e.Node.Name == "Sat Tamamlama")
            {
                FrmSatTamamlama Go = new FrmSatTamamlama();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatTamamlama", "SAT TAMAMLAMA", Go);
                Go.Show();
            }
            if (e.Node.Name == "Sat Guncelle")
            {
                FrmSATGuncelle Go = new FrmSATGuncelle();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatGuncelle", "SAT GÜNCELLE", Go);
                Go.Show();
            }
            if (e.Node.Name == "Tamamlanan Sat")
            {
                FrmTamamlananSat Go = new FrmTamamlananSat();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatTamamlanan", "TAMAMLANAN SAT", Go);
                Go.Show();
            }
            if (e.Node.Name == "Tedarikci Firma")
            {
                FrmTedarikciFirmaBilgileri Go = new FrmTedarikciFirmaBilgileri();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageTedarikciFirma", "TEDARİKÇİ FİRMA BİLGİLERİ", Go);
                Go.Show();
            }
            if (e.Node.Name == "Alt Yuklenici Firma")
            {
                FrmAltYukleniciFirma Go = new FrmAltYukleniciFirma();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAltYüklenici", "ALT YÜKLENİCİ FİRMALAR", Go);
                Go.Show();
            }
            if (e.Node.Name == "devamedensat")
            {
                object[] infos1 = satinAlinacakMalManager.Malzemeler("1");
                FrmDevamEdenSat Go = new FrmDevamEdenSat();
                Go.infos = infos;

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDevamEdenSat", "DEVAM EDEN SATLAR", Go);
                Go.Show();
            }
            if (e.Node.Name == "RedEdilenSat")
            {
                FrmReddedilenSatlar Go = new FrmReddedilenSatlar();
                Go.infos = infos;

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageReddedilen", "REDDEDİLEN SATLAR", Go);
                Go.Show();
            }
            if (e.Node.Name == "Satın Alınacak Malzemeler")
            {
                FrmTeklifsizSat Go = new FrmTeklifsizSat();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatMalzemeler", "TEKLİFSİZ SAT", Go);
                Go.Show();
            }

            /////////////////////////////////////////////////İDARİ İŞLER////////////////////////////////////////////////////////////////////

            if (e.Node.Name == "PersonelKayit")
            {
                object[] infos1 = satinAlinacakMalManager.Malzemeler("1");
                FrmPersonelKayit Go = new FrmPersonelKayit();
                Go.infos = infos;

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PagePersonelKayit", "PERSONEL KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Name == "PersonelListesi")
            {
                object[] infos1 = satinAlinacakMalManager.Malzemeler("1");
                FrmPersonelListesi Go = new FrmPersonelListesi();
                Go.infos = infos;

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PagePersonelListesi", "PERSONEL LİSTESİ", Go);
                Go.Show();
            }

            if (e.Node.Name == "PersonelListesiAyrilan")
            {
                FrmPersonelListesiAyrilan Go = new FrmPersonelListesiAyrilan();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAyrilanListesi", "PERSONEL LİSTESİ (AYRILAN)", Go);
                Go.Show();
            }
            if (e.Node.Name == "DuranVarlikKayit")
            {
                DuranVarlik Go = new DuranVarlik();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDuranVarlik", "DURAN VARLIK KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Name == "DuranVarlikAkarma")
            {
                FrmDuranVarlikAktarim Go = new FrmDuranVarlikAktarim();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDuranVarlikAktarim", "DURAN VARLIK AKTARIM", Go);
                Go.Show();
            }
            if (e.Node.Name == "DuranVarlikTakip")
            {
                FrmDuranVarlikTakip Go = new FrmDuranVarlikTakip();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDuranVarlikTakip", "DURAN VARLIK TAKİP", Go);
                Go.Show();
            }
            if (e.Node.Name == "DuranVarlikGuncelleme")
            {
                FrmDuranVarlikGuncelleme Go = new FrmDuranVarlikGuncelleme();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDuranVarlikGuncelleme", "DURAN VARLIK GÜNCELLE", Go);
                Go.Show();
            }

            if (e.Node.Name == "Ucak Otobus Bileti")
            {
                FrmUcakOtobusBileti Go = new FrmUcakOtobusBileti();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageUcakOtobus", "UÇAK/OTOBÜS BİLETİ", Go);
                Go.Show();
            }
            if (e.Node.Name == "Ucak Otobus Izleme")
            {
                FrmUcakOtobusBiletiIzleme Go = new FrmUcakOtobusBiletiIzleme();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageUcakOtobusIzleme", "UÇAK/OTOBÜS BİLETİ GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Name == "Sehir Icı Gorev")
            {
                FrmSehirIcıGorev Go = new FrmSehirIcıGorev();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSehirIcıGorev", "ŞEHİR İÇİ GÖREV", Go);
                Go.Show();
            }
            if (e.Node.Name == "Yurt Icı Gorev")
            {
                FrmYurtİciGorev Go = new FrmYurtİciGorev();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                Go.infos = infos;
                OpenTabPage("PageYurtIcıGorev", "YURT İÇİ GÖREV", Go);
                Go.Show();
            }
            if (e.Node.Name == "Izın")
            {
                FrmIzin Go = new FrmIzin();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageIzin", "PERSONEL İZİN", Go);
                Go.Show();
            }
            if (e.Node.Name == "Izin Izleme")
            {
                FrmIzinIzleme Go = new FrmIzinIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageIzinIzleme", "PERSONEL İZİN GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Name == "Konaklama")
            {
                FrmKonaklama Go = new FrmKonaklama();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageKonaklama", "KONAKLAMA", Go);
                Go.Show();
            }
            if (e.Node.Name == "Konaklama Izleme")
            {
                FrmKonaklamaIzleme Go = new FrmKonaklamaIzleme();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageKonaklamaIzleme", "KONAKLAMA GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Name == "Sehir Ici Gorev")
            {
                FrmSehirIciGorevIzleme Go = new FrmSehirIciGorevIzleme();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSehirIzleme", "ŞEHİR İÇİ GÖREV GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Name == "Yurt Icı GorevIzleme")
            {
                FrmYurtIciGorevIzleme Go = new FrmYurtIciGorevIzleme();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYurtIciGorevIzleme", "YURT İÇİ GÖREV GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Name == "Arac Tesis Kayit")
            {
                FrmAracKaydet Go = new FrmAracKaydet();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAracKaydet", "ARAÇ KAYDET", Go);
                Go.Show();
            }
            if (e.Node.Name == "Arac Tahsis Izleme")
            {
                FrmAracTahsisBilgileri Go = new FrmAracTahsisBilgileri();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAracTahsisBilgileri", "ARAÇ TAHSİS BİLGİLERİ", Go);
                Go.Show();
            }
            if (e.Node.Name == "Arac Yakit Beyani")
            {
                FrmYakitBeyani Go = new FrmYakitBeyani();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYakitBeyani", "ARAÇ YAKIT BEYANI", Go);
                Go.Show();
            }
            if (e.Node.Name == "Arac Yakıt Izleme")
            {
                FrmYakitBeyaniIzleme Go = new FrmYakitBeyaniIzleme();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYakitIzleme", "ARAÇ YAKIT BEYANI GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Name == "Evrak Kayit")
            {
                FrmEvrakKayit Go = new FrmEvrakKayit();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageEvrakKayit", "EVRAK KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Name == "Gelen Giden Yazi Izleme")
            {
                FrmEvrekKayitIzleme Go = new FrmEvrekKayitIzleme();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageEvrakKayitIzleme", "GELEN/GİDEN RESMİ YAZI İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Name == "Araç Bakım Kayıt")
            {
                FrmAracBakimKayit Go = new FrmAracBakimKayit();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageBakimKayit", "ARAÇ BAKIM KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Name == "DV Zimmet Takibi")
            {
                //frmWait.Show();
                FrmDVZimmetTakibi Go = new FrmDVZimmetTakibi();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageZimmetTakibi", "DV ZİMMET TAKİP", Go);
                Go.Show();
                //frmWait.Close();
            }
            if (e.Node.Name == "Arac Bakim Onarim Izleme")
            {
                FrmAracBakimKayitIzleme Go = new FrmAracBakimKayitIzleme();

                Go.FormBorderStyle = FormBorderStyle.None;

                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageBakimKayitIzleme", "ARAÇ BAKIM ONARIM İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Name == "Duran Varlik Ariza Kayit")
            {
                FrmDuranVarlikArizaKayit Go = new FrmDuranVarlikArizaKayit();
                Go.FormBorderStyle = FormBorderStyle.None;

                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDuranVarlikArizaKayit", "DURAN VARLIK ARIZA KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Name == "DV Kalibrasyon Kayit")
            {
                FrmDvKalibrasyonKayit Go = new FrmDvKalibrasyonKayit();
                Go.FormBorderStyle = FormBorderStyle.None;

                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDvKalibrasyonKayit", "DURAN VARLIK KALİBRASYON KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Name == "Ziyaretci Kayit")
            {
                FrmZiyaretciKayit Go = new FrmZiyaretciKayit();
                Go.FormBorderStyle = FormBorderStyle.None;

                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageZiyaretci", "ZİYARETÇİ KAYIT", Go);
                Go.Show();
            }

            /////////////////////////////////////////////////DÖKÜMAN YÖNETİM SİSTEMİ/////////////////////////////////////////////////////////

            if (e.Node.Name == "Dokuman Ekle")
            {
                FrmDokumanEkle Go = new FrmDokumanEkle();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDokumanEkle", "DOKÜMAN EKLE", Go);
                Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Name == "Standart Form Sorgula")
            {
                FrmStandartForm Go = new FrmStandartForm();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageStandartFormSorgula", "STANDART FORM SORGULA", Go);
                Go.Show();
            }
            if (e.Node.Name == "Dokuman Sorgula")
            {
                FrmDokumanSorgula Go = new FrmDokumanSorgula();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDokumanSorgula", "DOKÜMAN SORGULA", Go);
                Go.Show();
            }
            if (e.Node.Name == "Standart Form Ekle")
            {
                FrmStandartFormEkle Go = new FrmStandartFormEkle();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageFormEkle", "STANDART FORM EKLE", Go);
                Go.infos = infos;
                Go.Show();
            }

            /////////////////////////////////////////////////GEÇİCİ KABUL VE AMBAR/////////////////////////////////////////////////////////

            if (e.Node.Name == "Malzeme Kayit Ambar")
            {
                FrmMalzemeKayit Go = new FrmMalzemeKayit();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageMalzemeKayit", "MALZEME KAYIT", Go);
                //Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Name == "Stok Giris Cikis")
            {
                FrmStokGirisCikis Go = new FrmStokGirisCikis();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageStokGirisCikis", "STOK GİRİŞ/ÇIKIŞ", Go);
                //Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Name == "Stok Goruntule")
            {
                FrmStokGoruntule Go = new FrmStokGoruntule();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageStokGoruntule", "STOK GÖRÜNTÜLE", Go);
                //Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Name == "KayitliMalzemeler")
            {
                FrmMalzemeKayitIzleme Go = new FrmMalzemeKayitIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageKayitliMalzemeler", "KAYITLI MALZEMELERİ GÖRÜNTÜLE", Go);
                //Go.infos = infos;
                Go.Show();
            }

            /////////////////////////////////////////////////DESTEK DEPO///////////////////////////////////////////////////////////////////

            if (e.Node.Name == "Malzeme Kayit")
            {
                FrmMalzemeKayitDestekDepo Go = new FrmMalzemeKayitDestekDepo();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDesteDepoMalzemeKayit", "DESTEK DEPO MALZEME KAYIT", Go);
                //Go.infos = infos;
                Go.Show();
            }
            /////////////////////////////////////////////////RAPORLAMALAR/////////////////////////////////////////////////////////////
            if (e.Node.Name == "SatRaporlama")
            {
                FrmSatRaporu Go = new FrmSatRaporu();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatRaporlama", "SAT RAPORLAMA", Go);
                //Go.infos = infos;
                Go.Show();
            }


            #endregion
        }

        private void FrmAnaSayfa_SizeChanged(object sender, EventArgs e)
        {
            //Tabpage ile form penceresini boyutlandır
            /*if (treeView2.Visible)
            {
                foreach (TabPage item in tabAnasayfa.TabPages)
                {
                    item.Controls[0].Size = new Size(tabAnasayfa.Size.Width - 350, tabAnasayfa.Size.Height - 100);
                }
            }
            else
            {
                foreach (TabPage item in tabAnasayfa.TabPages)
                {
                    item.Controls[0].Size = new Size(tabAnasayfa.Size.Width - 100, tabAnasayfa.Size.Height - 100);
                }
            }*/
        }

        private void yAZDIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmDevam().Show();
        }

        private void bİLDİRİMLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNotification frmNotification = new FrmNotification();
            frmNotification.ShowDialog();
        }

        bool controlKapatma = false;
        private void FrmAnaSayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (controlKapatma == false)
            {
                if (kapatBilgisi==false)
                {
                    IslemleriSil();
                    controlKapatma = true;
                    Application.Exit();
                }
                DialogResult sonuc = MessageBox.Show("DTS Uygulamanızı Kapatmak İstiyor Musunuz?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                IslemleriSil();
                controlKapatma = true;
                Application.Exit();
            }

        }
        public void IslemleriSil()
        {
            var form = (DuranVarlik)Application.OpenForms["DuranVarlik"];
            if (form != null)
            {
                if (form.kaydet == false)
                {
                    dvNoManager.UpdateAzalt();
                    if (form.dosyaYolu != "")
                    {
                        Directory.Delete(form.dosyaYolu, true);
                    }
                }
            }
        }
    }
}

