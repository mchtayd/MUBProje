using Business;
using Business.Concreate;
using Business.Concreate.AnaSayfa;
using Business.Concreate.BakimOnarim;
using Business.Concreate.Butce;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using DataAccess.Concreate.AnaSayfa;
using Entity;
using Entity.BakimOnarim;
using Entity.Butce;
using Entity.IdariIsler;
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
using UserInterface.STS;

namespace UserInterface.Ana_Sayfa
{
    
    public partial class FrmServer : Form
    {

        IsAkisNoManager isAkisNoManager;
        SehiriciGorevManager sehiriciGorevManager;
        KonaklamaManager konaklamaManager;
        IzinManager izinManager;
        UcakOtobusManager ucakOtobusManager;
        EvrakKayitManager evrakKayitManager;
        YakitManager yakitManager;
        AracBakimManager aracBakimManager;
        AracZimmetiManager aracZimmetiManager;
        SatDataGridview1Manager satDataGridview1Manager;
        TamamlananManager tamamlananManager;
        ZiyaretciKayitManager ziyaretciKayitManager;
        ArsivTutanakManager arsivTutanakManager;
        IsAvansTalepManager talepManager;
        ServisFormuManager servisFormuManager;
        GorevAtamaManager gorevAtamaManager;
        ArizaKayitManager arizaKayitManager;
        IscilikPerformansManager iscilikPerformansManager;
        DtfManager dtfManager;
        ServerAyarlarManager serverAyarlarManager;

        List<string> sqlBasliklar = new List<string>();
        List<IsAkisNo> ısAkisNos = new List<IsAkisNo>();
        List<IsAkisNo> ısAkisNos2 = new List<IsAkisNo>();

        public object[] infos;
        string dosyaYolu, onlineYenileme, bildirimAlma;
        int satNo;
        public FrmServer()
        {
            InitializeComponent();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            sehiriciGorevManager = SehiriciGorevManager.GetInstance();
            konaklamaManager = KonaklamaManager.GetInstance();
            izinManager = IzinManager.GetInstance();
            ucakOtobusManager = UcakOtobusManager.GetInstance();
            evrakKayitManager = EvrakKayitManager.GetInstance();
            yakitManager = YakitManager.GetInstance();
            aracBakimManager = AracBakimManager.GetInstance();
            aracZimmetiManager = AracZimmetiManager.GetInstance();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            tamamlananManager = TamamlananManager.GetInstance();
            ziyaretciKayitManager = ZiyaretciKayitManager.GetInstance();
            arsivTutanakManager = ArsivTutanakManager.GetInstance();
            talepManager = IsAvansTalepManager.GetInstance();
            servisFormuManager = ServisFormuManager.GetInstance();
            gorevAtamaManager = GorevAtamaManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            iscilikPerformansManager = IscilikPerformansManager.GetInstance();
            dtfManager = DtfManager.GetInstance();
            serverAyarlarManager = ServerAyarlarManager.GetInstance();

        }

        private void FrmServer_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            if (infos[11].ToString()== "KULLANICI")
            {
                tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage2"]);
            }
            AyarControl();
        }

        public void AyarControl()
        {
            ServerAyarlar serverAyarlar = serverAyarlarManager.Get(infos[1].ToString());
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            if (serverAyarlar==null)
            {
                ChkOnlineRefrec.Checked = false;
                ChkBildirim.Checked = false;
                return;
            }
            else
            {
                if (serverAyarlar.OnlineYenileme=="AKTİF")
                {
                    ChkOnlineRefrec.Checked = true;
                    frmAnaSayfa.timerOnline.Stop();
                }
                else
                {
                    ChkOnlineRefrec.Checked = false;
                    frmAnaSayfa.timerOnline.Start();
                }
                if (serverAyarlar.BildirimAlma=="AKTİF")
                {
                    ChkBildirim.Checked = true;
                    FrmHelper.serverBildirimAyar = true;
                }
                else
                {
                    ChkBildirim.Checked = false;
                    FrmHelper.serverBildirimAyar = false;
                }
            }
        }

        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }

        private void BtnAtlat_Click(object sender, EventArgs e)
        {
            isAkisNoManager.UpdateKontrolsuz();
            IsAkisNo();
        }

        private void BtnKontrolEt_Click(object sender, EventArgs e)
        {
            sqlBasliklar = isAkisNoManager.TabloBasliklari();

            for (int i = 0; i < sqlBasliklar.Count(); i++)
            {

                ısAkisNos = isAkisNoManager.GetListKontrol(sqlBasliklar[i].ToString());
                if (ısAkisNos.Count!=0)
                {
                    for (int j = 0; j < ısAkisNos.Count; j++)
                    {
                        if (ısAkisNos[j].Id!=0)
                        {
                            ısAkisNos2.Add(ısAkisNos[j]);
                        }
                    }
                }
            }
            DtgList.DataSource = ısAkisNos2;
        }

        

        void CreateDirectoryKonaklama()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\KONAKLAMA\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(anadosya))
            {
                Directory.CreateDirectory(anadosya);
            }
            dosyaYolu = anadosya + LblIsAkisNo.Text + "\\";
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
        }

        void CreateDirectoryIzin()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\İZİN\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(anadosya))
            {
                Directory.CreateDirectory(anadosya);
            }
            dosyaYolu = anadosya + LblIsAkisNo.Text + "\\";
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
        }
        void CreateDirectoryUcakOtobus()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\UÇAK OTOBÜS BİLETİ\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(anadosya))
            {
                Directory.CreateDirectory(anadosya);
            }
            dosyaYolu = anadosya + LblIsAkisNo.Text + "\\";
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
        }
        void CreateDirectoryEvrakKayit()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\EVRAK KAYIT\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(anadosya))
            {
                Directory.CreateDirectory(anadosya);
            }
            dosyaYolu = anadosya + LblIsAkisNo.Text + "\\";
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
        }
        void CreateDirectoryAracBakimKayit()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\ULAŞTIRMA\";
            string anadosya2 = @"Z:\DTS\İDARİ İŞLER\ULAŞTIRMA\ARAÇ BAKIM KAYIT\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(anadosya))
            {
                Directory.CreateDirectory(anadosya);
            }
            if (!Directory.Exists(anadosya2))
            {
                Directory.CreateDirectory(anadosya2);
            }
            dosyaYolu = anadosya2 + LblIsAkisNo.Text + "\\";
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
        }
        void CreateDirectorySatDevamEdenGecici()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\GEÇİCİ SAT DOSYALARI\";


            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyaYolu = subdir + LblIsAkisNo.Text + "\\";
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
        }
        void CreateDirectorySatDevamEden()
        {
            string root = @"Z:\DTS";
            string hedef = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            dosyaYolu = hedef + satNo + "\\";
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
        }
        void CreateDirectorySatTamamlanan()
        {
            string root = @"Z:\DTS";
            string hedef = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            dosyaYolu = hedef + satNo + "\\";
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
        }
        void CreateDirectoryArsivTutanak()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\ARŞİV\";
            string subdir2 = @"Z:\DTS\İDARİ İŞLER\ARŞİV\TUTANAKLAR\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(subdir2))
            {
                Directory.CreateDirectory(subdir2);
            }

            dosyaYolu = subdir + LblIsAkisNo.Text + "\\";
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
        }
        void CreateDirectoryAvansTalep()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\IS AVANS TALEPLERİ\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyaYolu = subdir + LblIsAkisNo.Text + "\\";
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
        }
        /*string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\ATANAN GÖREVLER\";


            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyaYolu = subdir + isAkisNo;
            Directory.CreateDirectory(subdir + isAkisNo);
         */
        void CreateDirectoryServisFormu()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\BAKIM ONARIM\SERVİS FORMLARI\";


            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyaYolu = subdir + LblIsAkisNo.Text + "\\";
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
        }
        void CreateDirectoryGorevAtama()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\ATANAN GÖREVLER\";


            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyaYolu = subdir + LblIsAkisNo.Text + "\\";
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
        }
        void CreateDirectoryArizaKayit()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\BAKIM ONARIM\ARIZA\";


            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyaYolu = subdir + LblIsAkisNo.Text;
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
        }
        void CreateDirectoryDtf()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\BAKIM ONARIM\";
            string anadosya = @"Z:\DTS\BAKIM ONARIM\DTF\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(anadosya))
            {
                Directory.CreateDirectory(anadosya);
            }
            dosyaYolu = anadosya + LblIsAkisNo.Text + "\\";
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
        }
        private void BtnTumunuDuzelt_Click(object sender, EventArgs e)
        {
            if (ısAkisNos2.Count==0)
            {
                MessageBox.Show("Çakışan İş Akış Numarası tespit edilemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Tekrar eden iş akış numaraları yerine yeni iş akış numarası verilecek ve varsa dosya yolları da düzeltilecek!\nOnaylıyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr==DialogResult.Yes)
            {
                foreach (IsAkisNo item in ısAkisNos2)
                {
                    if (item.TabloAd == "SEHIR_ICI_GOREV")
                    {
                        List<SehiriciGorev> sehiriciGorevs = new List<SehiriciGorev>();
                        sehiriciGorevs = sehiriciGorevManager.GetList(item.Id);
                        foreach (SehiriciGorev sehiriciGorev in sehiriciGorevs)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            sehiriciGorevManager.IsAkisNoDuzelt(sehiriciGorev.Id, LblIsAkisNo.Text.ConInt());
                        }
                    }
                    if (item.TabloAd == "KONAKLAMA")
                    {
                        List<Konaklama> konaklamas = new List<Konaklama>();
                        konaklamas = konaklamaManager.GetList(item.Id);
                        foreach (Konaklama konaklama in konaklamas)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            CreateDirectoryKonaklama();
                            konaklamaManager.IsAkisNoDuzelt(konaklama.Id, LblIsAkisNo.Text.ConInt(), dosyaYolu);
                        }
                    }
                    if (item.TabloAd == "PERSONEL_IZIN")
                    {
                        List<Izin> ızins = new List<Izin>();
                        ızins = izinManager.GetList(item.Id);
                        foreach (Izin izin in ızins)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            CreateDirectoryIzin();
                            izinManager.IsAkisNoDuzelt(izin.Id, LblIsAkisNo.Text.ConInt(), dosyaYolu);
                        }
                    }
                    if (item.TabloAd == "UCAK_OTOBUS")
                    {
                        List<UcakOtobus> ucakOtobus = new List<UcakOtobus>();
                        ucakOtobus = ucakOtobusManager.GetList(item.Id);
                        foreach (UcakOtobus ucak in ucakOtobus)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            CreateDirectoryUcakOtobus();
                            ucakOtobusManager.IsAkisNoDuzelt(ucak.Id, LblIsAkisNo.Text.ConInt(), dosyaYolu);
                        }
                    }
                    if (item.TabloAd == "EVRAK_KAYIT")
                    {
                        List<EvrakKayit> evrakKayits = new List<EvrakKayit>();
                        evrakKayits = evrakKayitManager.GetList(item.Id);
                        foreach (EvrakKayit evrak in evrakKayits)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            CreateDirectoryEvrakKayit();
                            evrakKayitManager.IsAkisNoDuzelt(evrak.Id, LblIsAkisNo.Text.ConInt(), dosyaYolu);
                        }
                    }
                    if (item.TabloAd == "YAKIT_BEYANI")
                    {
                        List<Yakit> yakits = new List<Yakit>();
                        yakits = yakitManager.GetList(0,item.Id);
                        foreach (Yakit yakit in yakits)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            yakitManager.IsAkisNoDuzelt(yakit.Id, LblIsAkisNo.Text.ConInt());
                        }
                    }

                    if (item.TabloAd == "ARAC_BAKIM_KAYIT")
                    {
                        List<AracBakim> aracBakims = new List<AracBakim>();
                        aracBakims = aracBakimManager.GetList(item.Id);
                        foreach (AracBakim evrak in aracBakims)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            CreateDirectoryAracBakimKayit();
                            aracBakimManager.IsAkisNoDuzelt(evrak.Id, LblIsAkisNo.Text.ConInt(), dosyaYolu);
                        }
                    }

                    if (item.TabloAd == "ARAC_ZIMMETLERI")
                    {
                        List<AracZimmeti> aracZimmetis = new List<AracZimmeti>();
                        aracZimmetis = aracZimmetiManager.AracZimmetiListele(item.Id);
                        foreach (AracZimmeti aracZimmeti in aracZimmetis)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            aracZimmetiManager.IsAkisNoDuzelt(aracZimmeti.Id, LblIsAkisNo.Text.ConInt());
                        }
                    }

                    if (item.TabloAd == "SAT_DATAGRIT1")
                    {
                        List<SatDataGridview1> satDataGridview1s = new List<SatDataGridview1>();
                        satDataGridview1s = satDataGridview1Manager.List(item.Id);
                        foreach (SatDataGridview1 satDataGridview in satDataGridview1s)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            satNo = satDataGridview.Satno.ConInt();
                            if (satNo!= 0)
                            {
                                CreateDirectorySatDevamEden();
                            }
                            else
                            {
                                CreateDirectorySatDevamEdenGecici();
                            }
                            satDataGridview1Manager.IsAkisNoDuzelt(satDataGridview.Id, LblIsAkisNo.Text.ConInt(), dosyaYolu);
                        }
                    }

                    if (item.TabloAd == "TAMAMLANAN_SATLAR")
                    {
                        List<Tamamlanan> tamamlanans = new List<Tamamlanan>();
                        tamamlanans = tamamlananManager.GetListSatTumu(item.Id);
                        foreach (Tamamlanan tamamlanan in tamamlanans)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            satNo = tamamlanan.Satno.ConInt();
                            CreateDirectorySatTamamlanan();
                            tamamlananManager.IsAkisNoDuzelt(tamamlanan.Id, LblIsAkisNo.Text.ConInt(), dosyaYolu);
                        }
                    }

                    if (item.TabloAd == "ZIYARETCI_KAYIT")
                    {
                        List<ZiyaretciKayit> ziyaretciKayits = new List<ZiyaretciKayit>();
                        ziyaretciKayits = ziyaretciKayitManager.GetList(item.Id);
                        foreach (ZiyaretciKayit ziyaretciKayit in ziyaretciKayits)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            ziyaretciKayitManager.IsAkisNoDuzelt(ziyaretciKayit.Id, LblIsAkisNo.Text.ConInt());
                        }
                    }

                    if (item.TabloAd == "ARSIV_TUTANAK")
                    {
                        List<ArsivTutanak> arsivTutanaks = new List<ArsivTutanak>();
                        arsivTutanaks = arsivTutanakManager.GetList(item.Id);
                        foreach (ArsivTutanak arsivTutanak in arsivTutanaks)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            CreateDirectoryArsivTutanak();
                            arsivTutanakManager.IsAkisNoDuzelt(arsivTutanak.Id, LblIsAkisNo.Text.ConInt(), dosyaYolu);
                        }
                    }
                    if (item.TabloAd == "IS_AVANS_TALEBI")
                    {
                        List<IsAvansTalep> avansTaleps = new List<IsAvansTalep>();
                        avansTaleps = talepManager.GetList(item.Id);
                        foreach (IsAvansTalep avansTalep in avansTaleps)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            CreateDirectoryAvansTalep();
                            talepManager.IsAkisNoDuzelt(avansTalep.Id, LblIsAkisNo.Text.ConInt(), dosyaYolu);
                        }
                    }
                    if (item.TabloAd == "SERVIS_FORMU")
                    {
                        List<ServisFormu> servisFormus = new List<ServisFormu>();
                        servisFormus = servisFormuManager.GetList(item.Id);
                        foreach (ServisFormu servisFormu in servisFormus)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            CreateDirectoryServisFormu();
                            servisFormuManager.IsAkisNoDuzelt(servisFormu.Id, LblIsAkisNo.Text.ConInt(), dosyaYolu);
                        }
                    }

                    if (item.TabloAd == "YONETICI_GOREVLERI")
                    {
                        List<GorevAtama> gorevAtamas = new List<GorevAtama>();
                        gorevAtamas = gorevAtamaManager.GorevlerList(item.Id);
                        foreach (GorevAtama gorevAtama in gorevAtamas)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            CreateDirectoryGorevAtama();
                            gorevAtamaManager.IsAkisNoDuzelt(gorevAtama.Id, LblIsAkisNo.Text.ConInt(), dosyaYolu);
                        }
                    }

                    if (item.TabloAd == "BAKIM_ONARIM")
                    {
                        List<ArizaKayit> arizaKayits = new List<ArizaKayit>();
                        arizaKayits = arizaKayitManager.ArizalarList(item.Id);
                        foreach (ArizaKayit arizaKayit in arizaKayits)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            CreateDirectoryArizaKayit();
                            arizaKayitManager.IsAkisNoDuzelt(arizaKayit.Id, LblIsAkisNo.Text.ConInt(), dosyaYolu);
                        }
                    }

                    if (item.TabloAd == "ISCILIK_PERFORMANS")
                    {
                        List<IscilikPerformans> ıscilikPerformans = new List<IscilikPerformans>();
                        ıscilikPerformans = iscilikPerformansManager.IscilikPerformansList(item.Id);
                        foreach (IscilikPerformans performans in ıscilikPerformans)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            iscilikPerformansManager.IsAkisNoDuzelt(performans.Id, LblIsAkisNo.Text.ConInt());
                        }
                    }
                    if (item.TabloAd == "DTF_KAYIT")
                    {
                        List<Dtf> dtfs = new List<Dtf>();
                        dtfs = dtfManager.DtfKayitList(item.Id);
                        foreach (Dtf dtf in dtfs)
                        {
                            isAkisNoManager.UpdateKontrolsuz();
                            IsAkisNo();
                            CreateDirectoryDtf();
                            dtfManager.IsAkisNoDuzelt(dtf.Id, LblIsAkisNo.Text.ConInt(), dosyaYolu);
                        }
                    }
                }

                MessageBox.Show("Bilgiler başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DtgList.DataSource = null;
                IsAkisNo();
            }
        }
         
        private void BtnUygula_Click(object sender, EventArgs e)
        {
            ServerAyarlar serverAyarlar = serverAyarlarManager.Get(infos[1].ToString());
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            if (ChkOnlineRefrec.Checked == true)
            {
                onlineYenileme = "AKTİF";
                frmAnaSayfa.timerOnline.Stop();
            }
            else
            {
                onlineYenileme = "PASİF";
                frmAnaSayfa.timerOnline.Start();
            }
            if (ChkBildirim.Checked == true)
            {
                bildirimAlma = "AKTİF";
                FrmHelper.serverBildirimAyar = true;
            }
            else
            {
                bildirimAlma = "PASİF";
                FrmHelper.serverBildirimAyar = false;
            }

            if (serverAyarlar==null)
            {
                ServerAyarlar serverAyarlar1 = new ServerAyarlar(infos[1].ToString(), onlineYenileme, bildirimAlma);
                serverAyarlarManager.Add(serverAyarlar1);

            }
            else
            {
                ServerAyarlar serverAyarlar1 = new ServerAyarlar(infos[1].ToString(), onlineYenileme, bildirimAlma);
                serverAyarlarManager.Update(serverAyarlar1);
            }
        }
    }
}
