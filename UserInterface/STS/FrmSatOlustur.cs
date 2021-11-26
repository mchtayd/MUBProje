using Business.Concreate;
using Business.Concreate.Depo;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using ClosedXML.Excel;
using ClosedXML.Excel.Drawings;
using DataAccess.Concreate;
using DataAccess.Concreate.Depo;
using Entity;
using Entity.Depo;
using Entity.Gecic_Kabul_Ambar;
using Entity.IdariIsler;
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
using UserInterface.Ana_Sayfa;

namespace UserInterface.STS
{
    public partial class FrmSatOlustur : Form
    {
        SatDataGridview1Manager satDataGridview;
        SatTalebiDoldurManager satTalebiDoldurManager;
        StokNoTanimManager stokNoTanimManager;
        SatinAlinacakMalManager satinAlinacakMalManager;
        SatIslemAdimlariManager satIslemAdimlariManager;
        SiparislerManager siparislerManager;
        SiparisPersonelManager siparisPersonelManager;
        SatNoManager satNoManager;
        ButceKoduManager butceKoduManager;
        MalzemeKayitManager malzemeKayitManager;
        UstAmirManager ustAmirManager;
        AmbarManager ambarManager;
        CayOcagiManager cayOcagiManager;
        DestekDepoMalzemeKayitManager depoMalzemeKayitManager;
        ElAletleriManager elAletleriManager;
        IsGiysiManager isGiysiManager;
        KirtasiyeManager kirtasiyeManager;
        KKDManager kKDManager;
        TemizlikUrunleriManager temizlikUrunleriManager;


        List<SiparisPersonel> personels;
        List<UstAmirMail> ustAmirMails;
        List<string> fileNames = new List<string>();
        List<Product> stoknosFiltered = new List<Product>();
        List<Product> products = new List<Product>();
        List<MalzemeKayit> malzemeKayits;
        List<MalzemeKayit> malzemesFiltered;
        List<DestekDepoAmbar> ambarFiltired;

        List<DestekDepoAmbar> destekDepoAmbars = new List<DestekDepoAmbar>();
        List<DestekDepoCayOcagi> cayOcagis = new List<DestekDepoCayOcagi>();
        List<DestekDepoElAletleri> elAletleris = new List<DestekDepoElAletleri>();
        List<DestekDepoIsGiysi> destekDepoIs = new List<DestekDepoIsGiysi>();
        List<DestekDepoKirtasiye> kirtasiyes = new List<DestekDepoKirtasiye>();
        List<DestekDepoKKD> kKDs = new List<DestekDepoKKD>();
        List<DestekDepoTemizlikUrunleri> temizlikUrunleris = new List<DestekDepoTemizlikUrunleri>();

        string kaynakdosyaismi, alinandosya = "", mail, amirmail;
        string yapilanislem, masrafyerino, islemyapan;
        public string siparisNo, dosyaYolu, siparis;
        string satno = "";// DOSYAADİ
        public object[] infos;
        bool gec, canFilter = false, devam = false, cont = false;
        int sayi, dosyasil = 1, id;

        public FrmSatOlustur()
        {
            InitializeComponent();
            satTalebiDoldurManager = SatTalebiDoldurManager.GetInstance();
            stokNoTanimManager = StokNoTanimManager.GetInstance();
            satDataGridview = SatDataGridview1Manager.GetInstance();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
            satNoManager = SatNoManager.GetInstance();
            siparislerManager = SiparislerManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            butceKoduManager = ButceKoduManager.GetInstance();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
            ustAmirManager = UstAmirManager.GetInstance();
            ambarManager = AmbarManager.GetInstance();
            cayOcagiManager = CayOcagiManager.GetInstance();
            depoMalzemeKayitManager = DestekDepoMalzemeKayitManager.GetInstance();
            elAletleriManager = ElAletleriManager.GetInstance();
            isGiysiManager = IsGiysiManager.GetInstance();
            kirtasiyeManager = KirtasiyeManager.GetInstance();
            kKDManager = KKDManager.GetInstance();
            temizlikUrunleriManager = TemizlikUrunleriManager.GetInstance();
        }

        private void FrmSatOlustur_Load(object sender, EventArgs e)
        {
            gec = false;
            SatDoldur();
            ComboboxLoad();
            //DataDisplay();
            //MalListLoad();
            //Siparisler();
            SatFormNoOlustur();
            gec = true;
            //ProductsLoadProcess();
            UstAmirMail();
            MalzemeTuru();
        }
        void MalzemeTuru()
        {
            if (id==84) // RSLGNS
            {
                return;
            }
            if (id == 25) // MCHTAYD
            {
                return;
            }
            if (id== 107) // EREN
            {
                CmbMalzemeTuru.Items.RemoveAt(7);
                CmbMalzemeTuru.Items.RemoveAt(6);
                CmbMalzemeTuru.Items.RemoveAt(5);
                CmbMalzemeTuru.Items.RemoveAt(4);
                CmbMalzemeTuru.Items.RemoveAt(2);
                return;
            }
            if (id == 30) // EMEL ABLA
            {
                CmbMalzemeTuru.Items.RemoveAt(3);
                CmbMalzemeTuru.Items.RemoveAt(1);
                CmbMalzemeTuru.Items.RemoveAt(0);
                return;
            }
            if (id == 42) // GÜLŞAH HANIM
            {
                CmbMalzemeTuru.Items.RemoveAt(7);
                CmbMalzemeTuru.Items.RemoveAt(6);
                CmbMalzemeTuru.Items.RemoveAt(5);
                CmbMalzemeTuru.Items.RemoveAt(4);
                CmbMalzemeTuru.Items.RemoveAt(2);
                return;
            }
        }
        void UstAmirMail()
        {
            mail = infos[7].ToString();
            id = infos[0].ConInt();
            ustAmirMails = ustAmirManager.GetList(id);
            if (ustAmirMails.Count > 0)
            {
                amirmail = ustAmirMails[0].Oficemail; // HATA YOK
            }
        }
        void DataDisplay()
        {
            /*malzemeKayits = malzemeKayitManager.GetList();
            malzemesFiltered = malzemeKayits;
            dataBinder.DataSource = malzemeKayits.ToDataTable();
            DtgStokList.DataSource = dataBinder;*/
            if (malzeme == "YEDEK PARÇA")
            {
                DtgStokList.Columns["Id"].Visible = false;
                DtgStokList.Columns["Stokno"].HeaderText = "STOK NO";
                DtgStokList.Columns["Tanim"].HeaderText = "TANIM";
                DtgStokList.Columns["Birim"].HeaderText = "BİRİM";
                DtgStokList.Columns["Tedarikcifirma"].Visible = false;
                DtgStokList.Columns["Malzemeonarimdurumu"].Visible = false;
                DtgStokList.Columns["Malzemeonarımyeri"].Visible = false;
                DtgStokList.Columns["Malzemeturu"].Visible = false;
                DtgStokList.Columns["Malzemetakipdurumu"].Visible = false;
                DtgStokList.Columns["Malzemerevizyon"].Visible = false;
                DtgStokList.Columns["Malzemelot"].Visible = false;
                DtgStokList.Columns["Malzemekul"].Visible = false;
                DtgStokList.Columns["Aciklama"].Visible = false;
                DtgStokList.Columns["Dosyayolu"].Visible = false;
            }
            else
            {
                DtgStokList.Columns["Id"].Visible = false;
                DtgStokList.Columns["Stokno"].HeaderText = "STOK NO";
                DtgStokList.Columns["Tanim"].HeaderText = "TANIM";
                DtgStokList.Columns["Birim"].HeaderText = "BİRİM";
            }


            TxtTop.Text = DtgStokList.RowCount.ToString();
        }
        async void ProductsLoadProcess()
        {
            Task task = new Task(ProductsLoad);
            task.Start();
            LblProductsWait.Visible = true;
            TxtStokArama.Enabled = false;
            TxtTanimArama.Enabled = false;
            button1.Enabled = false;

            await task;
            LblProductsWait.Visible = false;
            TxtStokArama.Enabled = true;
            TxtTanimArama.Enabled = true;
            canFilter = true;
            button1.Enabled = true;
        }
        void SatFormNoOlustur()
        {
            satno = "";
            Random random = new Random();
            for (int i = 0; i < 9; i++)
            {
                sayi = random.Next(0, 9);
                satno = satno + sayi.ToString();
            }
            TxtFormNo.Text = satno;
        }


        void SatDoldur()
        {
            MasYeriNo.Text = infos[4].ToString();
            TalepEden.Text = infos[1].ToString();
            Bolum.Text = infos[2].ToString();
            ProjeKodu.Text = infos[3].ToString();
        }
        /*void Siparisler()
        {
            CmbPersonelSiparis.DataSource = siparislerManager.GetList();
            CmbPersonelSiparis.ValueMember = "Id";
            CmbPersonelSiparis.DisplayMember = "Siparisno";
            CmbPersonelSiparis.SelectedValue = 0;
        }*/
        /*void SiparisIsimlerDoldur()
        {
            CmbPersonel.DataSource = siparisPersonelManager.GetList(siparis);
            CmbPersonel.ValueMember = "Id";
            CmbPersonel.DisplayMember = "Personel";
            CmbPersonel.SelectedValue = 0;
            devam = true;
        }*/
        private void CmbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (devam == false)
            {
                return;
            }
            personels = siparisPersonelManager.IstekteBulunan(siparis, CmbPersonel.Text);
            if (personels.Count == 0)
            {
                return;
            }
            /*TxtBolum.Text = personels[0].Bolum;
            TxtMasrafyeri.Text = personels[0].Masrafyerino;
            TxtProje.Text = personels[0].Projekodu;*/

            //IstekteBulunanVisible();
            //devam = false;
        }
        private void TxtBolum_TextChanged(object sender, EventArgs e)
        {
            //IstekteBulunanVisible();
        }

        void ComboboxLoad()
        {
            Usbolgesi.DataSource = satTalebiDoldurManager.GetList();
            Usbolgesi.ValueMember = "Id";
            Usbolgesi.DisplayMember = "Usbolgesi";
            Usbolgesi.SelectedValue = "";

            BildirimFromNo.DataSource = satTalebiDoldurManager.GetList();
            BildirimFromNo.ValueMember = "Id";
            BildirimFromNo.DisplayMember = "Bilforno";
            BildirimFromNo.SelectedValue = "";

            cont = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSatOlustur"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void CmbPersonelSiparis_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /*if (gec == false)
            {
                return;
            }
            siparis = CmbPersonelSiparis.Text;
            SiparisIsimlerDoldur();*/
        }
        void Temizle()
        {
            //CmbPersonelSiparis.SelectedValue = 0;
            //CmbPersonel.SelectedValue = 0;
            Usbolgesi.Text = "";
            BildirimFromNo.Text = "";
            Gerekce.Clear();
            t1.Text = ""; t2.Text = ""; t3.Text = ""; t4.Text = ""; t5.Text = ""; t6.Text = ""; t7.Text = ""; t8.Text = ""; t9.Text = ""; t10.Text = "";
            stn1.Text = ""; stn2.Text = ""; stn3.Text = ""; stn4.Text = ""; stn5.Text = ""; stn6.Text = ""; stn7.Text = "";
            stn8.Text = ""; stn9.Text = ""; stn10.Text = "";
            m1.Text = ""; m2.Text = ""; m3.Text = ""; m4.Text = ""; m5.Text = ""; m6.Text = ""; m7.Text = ""; m8.Text = ""; m9.Text = ""; m10.Text = "";
            b1.Text = ""; b2.Text = ""; b3.Text = ""; b4.Text = ""; b5.Text = ""; b6.Text = ""; b7.Text = ""; b8.Text = ""; b9.Text = ""; b10.Text = "";
            TxtFormNo.Text = "";
            SatFormNoOlustur();
            DosyaEkle.BackColor = Color.Transparent;
            Kaydet.Enabled = false;
            /*TxtBolum.Text = "-";
            TxtMasrafyeri.Text = "-";
            TxtProje.Text = "-";*/
        }

        private void b1_KeyDown(object sender, KeyEventArgs e) { e.Handled = true; }

        private void b2_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void b3_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void b4_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void b5_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void b6_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void b7_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void b8_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void b9_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void b10_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
        string MalzemeControl()
        {
            if (stn1.Text.Trim() != "")
            {
                if (m1.Text.Trim() == "" || b1.Text.Trim() == "")
                {
                    return "Lütfen 1. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stn2.Text.Trim() != "")
            {
                if (m2.Text.Trim() == "" || b2.Text.Trim() == "")
                {
                    return "Lütfen 2. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stn3.Text.Trim() != "")
            {
                if (m3.Text.Trim() == "" || b3.Text.Trim() == "")
                {
                    return "Lütfen 3. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stn4.Text.Trim() != "")
            {
                if (m4.Text.Trim() == "" || b4.Text.Trim() == "")
                {
                    return "Lütfen 4. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stn5.Text.Trim() != "")
            {
                if (m5.Text.Trim() == "" || b5.Text.Trim() == "")
                {
                    return "Lütfen 5. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stn6.Text.Trim() != "")
            {
                if (m6.Text.Trim() == "" || b6.Text.Trim() == "")
                {
                    return "Lütfen 6. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stn7.Text.Trim() != "")
            {
                if (m7.Text.Trim() == "" || b7.Text.Trim() == "")
                {
                    return "Lütfen 7. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stn8.Text.Trim() != "")
            {
                if (m8.Text.Trim() == "" || b8.Text.Trim() == "")
                {
                    return "Lütfen 8. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stn9.Text.Trim() != "")
            {
                if (m9.Text.Trim() == "" || b9.Text.Trim() == "")
                {
                    return "Lütfen 9. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stn10.Text.Trim() != "")
            {
                if (m10.Text.Trim() == "" || b10.Text.Trim() == "")
                {
                    return "Lütfen 10. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            return "OK";
        }
        private void Kaydet_Click(object sender, EventArgs e)
        {
            siparisNo = Guid.NewGuid().ToString();
            DialogResult dr = MessageBox.Show("Satın Alma Talebinizi Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                masrafyerino = MasYeriNo.Text;
                islemyapan = TalepEden.Text;

                string control = MalzemeControl();
                if (control != "OK")
                {
                    MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (BildirimFromNo.Visible != false)
                {
                    if (BildirimFromNo.Text == "")
                    {
                        MessageBox.Show("Lütfen Bildirim Form Numarası Belirtiniz.");
                        return;
                    }
                }
                SatDataGridview1 satDataGridview1 = new SatDataGridview1(0,TxtFormNo.Text.ConInt(), MasYeriNo.Text, TalepEden.Text, Bolum.Text, Usbolgesi.Text, BildirimFromNo.Text, istenenTarih.Value, Gerekce.Text, siparisNo,"","","","","",
                  string.IsNullOrEmpty(dosyaYolu) ? "" : dosyaYolu, infos[0].ConInt(),"","","","","");

                alinandosya = "";
                yapilanislem = "Satın Alma İşlemi Oluşturuldu, SAT BAŞLATMA ONAYI Aşamasında Beklemede.";

                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, TalepEden.Text, istenenTarih.Value);
                satIslemAdimlariManager.Add(satIslemAdimlari);
                string message = satDataGridview.Add(satDataGridview1);

                //Task.Factory.StartNew(() => MailSendMetot()); // programın kasmasını engeller!
                //Task.Factory.StartNew(() => MailSendMetotPersonel());

                List<SatinAlinacakMalzemeler> list = new List<SatinAlinacakMalzemeler>();

                if (stn1.Text.Trim() != "" && t1.Text.Trim() != "" && m1.Text.Trim() != "" && b1.Text.Trim() != "")
                {
                    SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn1.Text, t1.Text, m1.Text.ConInt(), b1.Text, MasYeriNo.Text);
                    list.Add(satinAlinacakMalzeme);
                }

                if (stn2.Text.Trim() != "" && t2.Text.Trim() != "" && m2.Text.Trim() != "" && b2.Text.Trim() != "")
                {
                    SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn2.Text, t2.Text, m2.Text.ConInt(), b2.Text, MasYeriNo.Text);
                    list.Add(satinAlinacakMalzeme);
                }

                if (stn3.Text.Trim() != "" && t3.Text.Trim() != "" && m3.Text.Trim() != "" && b3.Text.Trim() != "")
                {
                    SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn3.Text, t3.Text, m3.Text.ConInt(), b3.Text, MasYeriNo.Text);
                    list.Add(satinAlinacakMalzeme);
                }

                if (stn4.Text.Trim() != "" && t4.Text.Trim() != "" && m4.Text.Trim() != "" && b4.Text.Trim() != "")
                {
                    SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn4.Text, t4.Text, m4.Text.ConInt(), b4.Text, MasYeriNo.Text);
                    list.Add(satinAlinacakMalzeme);
                }

                if (stn5.Text.Trim() != "" && t5.Text.Trim() != "" && m5.Text.Trim() != "" && b5.Text.Trim() != "")
                {
                    SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn5.Text, t5.Text, m5.Text.ConInt(), b5.Text, MasYeriNo.Text);
                    list.Add(satinAlinacakMalzeme);
                }

                if (stn6.Text.Trim() != "" && t6.Text.Trim() != "" && m6.Text.Trim() != "" && b6.Text.Trim() != "")
                {
                    SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn6.Text, t6.Text, m6.Text.ConInt(), b6.Text, MasYeriNo.Text);
                    list.Add(satinAlinacakMalzeme);
                }

                if (stn7.Text.Trim() != "" && t7.Text.Trim() != "" && m7.Text.Trim() != "" && b7.Text.Trim() != "")
                {
                    SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn7.Text, t7.Text, m7.Text.ConInt(), b7.Text, MasYeriNo.Text);
                    list.Add(satinAlinacakMalzeme);
                }

                if (stn8.Text.Trim() != "" && t8.Text.Trim() != "" && m8.Text.Trim() != "" && b8.Text.Trim() != "")
                {
                    SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn8.Text, t8.Text, m8.Text.ConInt(), b8.Text, MasYeriNo.Text);
                    list.Add(satinAlinacakMalzeme);
                }

                if (stn9.Text.Trim() != "" && t9.Text.Trim() != "" && m9.Text.Trim() != "" && b9.Text.Trim() != "")
                {
                    SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn9.Text, t9.Text, m9.Text.ConInt(), b9.Text, MasYeriNo.Text);
                    list.Add(satinAlinacakMalzeme);
                }

                if (stn10.Text.Trim() != "" && t10.Text.Trim() != "" && m10.Text.Trim() != "" && b10.Text.Trim() != "")
                {
                    SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn10.Text, t10.Text, m10.Text.ConInt(), b10.Text, MasYeriNo.Text);
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
                if (message == "OK")
                {
                    MessageBox.Show(satno + " Numaralı SAT Kaydınız Başarıyla Oluşturulmuştur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Temizle();
                    dosyasil = 0;
                }
                else
                {
                    MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DosyaEkle_Click(object sender, EventArgs e)
        {
            /*string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\GEÇİCİ SAT DOSYALARI\";*/
            string root = @"C:\STS";
            string subdir = @"C:\STS\GEÇİCİ SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            //kaynakdosya = satno;
            Directory.CreateDirectory(subdir + satno);

            Directory.CreateDirectory(subdir + TxtFormNo.Text);
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
            dosyaYolu = subdir + TxtFormNo.Text;


            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                fileNames.Add(alinandosya);
                DosyaEkle.BackColor = Color.LightGreen;
                Kaydet.Enabled = true;
            }


        }
        int atla = 1;
        private string MalzemeKonrol()
        {
            if (atla == 0)
            {
                if (stn1.Text == stn2.Text || stn1.Text == stn3.Text || stn1.Text == stn4.Text || stn1.Text == stn5.Text || stn1.Text == stn6.Text ||
                stn1.Text == stn7.Text || stn1.Text == stn8.Text || stn1.Text == stn9.Text || stn1.Text == stn10.Text)
                {
                    return "";
                }
            }
            if (atla == 1)
            {
                if (stn2.Text == stn1.Text || stn2.Text == stn3.Text || stn2.Text == stn4.Text || stn2.Text == stn5.Text || stn2.Text == stn6.Text ||
                stn2.Text == stn7.Text || stn2.Text == stn8.Text || stn2.Text == stn9.Text || stn2.Text == stn10.Text)
                {
                    return "";
                }
            }
            if (atla == 2)
            {
                if (stn3.Text == stn1.Text || stn3.Text == stn2.Text || stn3.Text == stn4.Text || stn3.Text == stn5.Text || stn3.Text == stn6.Text ||
                stn3.Text == stn7.Text || stn3.Text == stn8.Text || stn3.Text == stn9.Text || stn3.Text == stn10.Text)
                {
                    return "";
                }
            }
            if (atla == 3)
            {
                if (stn4.Text == stn1.Text || stn4.Text == stn2.Text || stn4.Text == stn3.Text || stn4.Text == stn5.Text || stn4.Text == stn6.Text ||
                stn4.Text == stn7.Text || stn4.Text == stn8.Text || stn4.Text == stn9.Text || stn4.Text == stn10.Text)
                {
                    return "";
                }
            }
            if (atla == 4)
            {
                if (stn5.Text == stn1.Text || stn5.Text == stn2.Text || stn5.Text == stn3.Text || stn5.Text == stn4.Text || stn5.Text == stn6.Text ||
                stn5.Text == stn7.Text || stn5.Text == stn8.Text || stn5.Text == stn9.Text || stn5.Text == stn10.Text)
                {
                    return "";
                }
            }
            if (atla == 5)
            {
                if (stn6.Text == stn1.Text || stn6.Text == stn2.Text || stn6.Text == stn3.Text || stn6.Text == stn4.Text || stn6.Text == stn5.Text ||
                stn6.Text == stn7.Text || stn6.Text == stn8.Text || stn6.Text == stn9.Text || stn6.Text == stn10.Text)
                {
                    return "";
                }
            }
            if (atla == 6)
            {
                if (stn7.Text == stn1.Text || stn7.Text == stn2.Text || stn7.Text == stn3.Text || stn7.Text == stn4.Text || stn7.Text == stn5.Text ||
                stn7.Text == stn6.Text || stn7.Text == stn8.Text || stn7.Text == stn9.Text || stn7.Text == stn10.Text)
                {
                    return "";
                }
            }
            if (atla == 7)
            {
                if (stn8.Text == stn1.Text || stn8.Text == stn2.Text || stn8.Text == stn3.Text || stn8.Text == stn4.Text || stn8.Text == stn5.Text ||
                stn8.Text == stn6.Text || stn8.Text == stn7.Text || stn8.Text == stn9.Text || stn8.Text == stn10.Text)
                {
                    return "";
                }
            }
            if (atla == 8)
            {
                if (stn9.Text == stn1.Text || stn9.Text == stn2.Text || stn9.Text == stn3.Text || stn9.Text == stn4.Text || stn9.Text == stn5.Text ||
                stn9.Text == stn6.Text || stn9.Text == stn7.Text || stn9.Text == stn8.Text || stn8.Text == stn10.Text)
                {
                    return "";
                }
            }
            if (atla == 9)
            {
                if (stn10.Text == stn1.Text || stn10.Text == stn2.Text || stn10.Text == stn3.Text || stn10.Text == stn4.Text || stn10.Text == stn5.Text ||
                stn10.Text == stn6.Text || stn10.Text == stn7.Text || stn10.Text == stn8.Text || stn10.Text == stn9.Text)
                {
                    return "";
                }
            }
            return "OK";
        }
        string bilgi;
        private void AdvDtgProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            #region EskiDataGrid
            /*
            if (AdvDtgProducts.DataSource == null)
            {
                return;
            }
            if (stn1.Text == "")
            {
                stn1.Text = AdvDtgProducts.CurrentRow.Cells[0].Value.ToString();
                t1.Text = AdvDtgProducts.CurrentRow.Cells[1].Value.ToString();
                atla = 0;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn1.Text = ""; t1.Text = ""; m1.Text = ""; b1.Text = "";
                    return;
                }
                return;
            }
            if (stn2.Text == "")
            {
                stn2.Text = AdvDtgProducts.CurrentRow.Cells[0].Value.ToString();
                t2.Text = AdvDtgProducts.CurrentRow.Cells[1].Value.ToString();
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn2.Text = ""; t2.Text = ""; m2.Text = ""; b2.Text = "";
                    return;
                }
                return;
            }
            if (stn3.Text == "")
            {
                stn3.Text = AdvDtgProducts.CurrentRow.Cells[0].Value.ToString();
                t3.Text = AdvDtgProducts.CurrentRow.Cells[1].Value.ToString();
                atla = 2;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn3.Text = ""; t3.Text = ""; m3.Text = ""; b3.Text = "";
                    return;
                }
                return;
            }
            if (stn4.Text == "")
            {
                stn4.Text = AdvDtgProducts.CurrentRow.Cells[0].Value.ToString();
                t4.Text = AdvDtgProducts.CurrentRow.Cells[1].Value.ToString();
                atla = 3;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn4.Text = ""; t4.Text = ""; m4.Text = ""; b4.Text = "";
                    return;
                }
                return;
            }
            if (stn5.Text == "")
            {
                stn5.Text = AdvDtgProducts.CurrentRow.Cells[0].Value.ToString();
                t5.Text = AdvDtgProducts.CurrentRow.Cells[1].Value.ToString();
                atla = 4;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn5.Text = ""; t5.Text = ""; m5.Text = ""; b5.Text = "";
                    return;
                }
                return;
            }
            if (stn6.Text == "")
            {
                stn6.Text = AdvDtgProducts.CurrentRow.Cells[0].Value.ToString();
                t6.Text = AdvDtgProducts.CurrentRow.Cells[1].Value.ToString();
                atla = 5;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn6.Text = ""; t6.Text = ""; m6.Text = ""; b6.Text = "";
                    return;
                }
                return;
            }
            if (stn7.Text == "")
            {
                stn7.Text = AdvDtgProducts.CurrentRow.Cells[0].Value.ToString();
                t7.Text = AdvDtgProducts.CurrentRow.Cells[1].Value.ToString();
                atla = 6;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn7.Text = ""; t7.Text = ""; m7.Text = ""; b7.Text = "";
                    return;
                }
                return;
            }
            if (stn8.Text == "")
            {
                stn8.Text = AdvDtgProducts.CurrentRow.Cells[0].Value.ToString();
                t8.Text = AdvDtgProducts.CurrentRow.Cells[1].Value.ToString();
                atla = 7;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn8.Text = ""; t8.Text = ""; m8.Text = ""; b8.Text = "";
                    return;
                }
                return;
            }
            if (stn9.Text == "")
            {
                stn9.Text = AdvDtgProducts.CurrentRow.Cells[0].Value.ToString();
                t9.Text = AdvDtgProducts.CurrentRow.Cells[1].Value.ToString();
                atla = 8;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn9.Text = ""; t9.Text = ""; m9.Text = ""; b9.Text = "";
                    return;
                }
                return;
            }
            if (stn10.Text == "")
            {
                stn10.Text = AdvDtgProducts.CurrentRow.Cells[0].Value.ToString();
                t10.Text = AdvDtgProducts.CurrentRow.Cells[1].Value.ToString();
                atla = 9;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn10.Text = ""; t10.Text = ""; m10.Text = ""; b10.Text = "";
                    return;
                }
                return;
            }
            MessageBox.Show("Bir Seferde Talep Edeceğiniz Malzeme Listesinde Limit Seviyeye ulaştınız.Daha Fazla Talep İçin Lütfen Yeni Bir Satın Alma İşlemi Oluşturunuz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */
            #endregion
        }

        private void Sil1_Click(object sender, EventArgs e)
        {
            stn1.Text = ""; t1.Text = ""; m1.Text = ""; b1.Text = "";
            if (stn2.Text != "")
            {
                stn1.Text = stn2.Text; t1.Text = t2.Text; m1.Text = m2.Text; b1.Text = b2.Text;
                stn2.Text = stn3.Text; t2.Text = t3.Text; m2.Text = m3.Text; b2.Text = b3.Text;
                stn3.Text = stn4.Text; t3.Text = t4.Text; m3.Text = m4.Text; b3.Text = b4.Text;
                stn4.Text = stn5.Text; t4.Text = t5.Text; m4.Text = m5.Text; b4.Text = b5.Text;
                stn5.Text = stn6.Text; t5.Text = t6.Text; m5.Text = m6.Text; b5.Text = b6.Text;
                stn6.Text = stn7.Text; t6.Text = t7.Text; m6.Text = m7.Text; b6.Text = b7.Text;
                stn7.Text = stn8.Text; t7.Text = t8.Text; m7.Text = m8.Text; b7.Text = b8.Text;
                stn8.Text = stn9.Text; t8.Text = t9.Text; m8.Text = m9.Text; b8.Text = b9.Text;
                stn9.Text = stn10.Text; t9.Text = t10.Text; m9.Text = m10.Text; b9.Text = b10.Text;
                stn10.Text = ""; t10.Text = ""; m10.Text = ""; b10.Text = "";
            }

        }

        private void Sil2_Click(object sender, EventArgs e)
        {
            stn2.Text = ""; t2.Text = ""; m2.Text = ""; b2.Text = "";
            if (stn3.Text != "")
            {
                stn2.Text = stn3.Text; t2.Text = t3.Text; m2.Text = m3.Text; b2.Text = b3.Text;
                stn3.Text = stn4.Text; t3.Text = t4.Text; m3.Text = m4.Text; b3.Text = b4.Text;
                stn4.Text = stn5.Text; t4.Text = t5.Text; m4.Text = m5.Text; b4.Text = b5.Text;
                stn5.Text = stn6.Text; t5.Text = t6.Text; m5.Text = m6.Text; b5.Text = b6.Text;
                stn6.Text = stn7.Text; t6.Text = t7.Text; m6.Text = m7.Text; b6.Text = b7.Text;
                stn7.Text = stn8.Text; t7.Text = t8.Text; m7.Text = m8.Text; b7.Text = b8.Text;
                stn8.Text = stn9.Text; t8.Text = t9.Text; m8.Text = m9.Text; b8.Text = b9.Text;
                stn9.Text = stn10.Text; t9.Text = t10.Text; m9.Text = m10.Text; b9.Text = b10.Text;
                stn10.Text = ""; t10.Text = ""; m10.Text = ""; b10.Text = "";
            }
        }

        private void Sil3_Click(object sender, EventArgs e)
        {
            stn3.Text = ""; t3.Text = ""; m3.Text = ""; b3.Text = "";
            if (stn4.Text != "")
            {
                stn3.Text = stn4.Text; t3.Text = t4.Text; m3.Text = m4.Text; b3.Text = b4.Text;
                stn4.Text = stn5.Text; t4.Text = t5.Text; m4.Text = m5.Text; b4.Text = b5.Text;
                stn5.Text = stn6.Text; t5.Text = t6.Text; m5.Text = m6.Text; b5.Text = b6.Text;
                stn6.Text = stn7.Text; t6.Text = t7.Text; m6.Text = m7.Text; b6.Text = b7.Text;
                stn7.Text = stn8.Text; t7.Text = t8.Text; m7.Text = m8.Text; b7.Text = b8.Text;
                stn8.Text = stn9.Text; t8.Text = t9.Text; m8.Text = m9.Text; b8.Text = b9.Text;
                stn9.Text = stn10.Text; t9.Text = t10.Text; m9.Text = m10.Text; b9.Text = b10.Text;
                stn10.Text = ""; t10.Text = ""; m10.Text = ""; b10.Text = "";
            }
        }

        private void Sil4_Click(object sender, EventArgs e)
        {
            stn4.Text = ""; t4.Text = ""; m4.Text = ""; b4.Text = "";
            if (stn5.Text != "")
            {
                stn4.Text = stn5.Text; t4.Text = t5.Text; m4.Text = m5.Text; b4.Text = b5.Text;
                stn5.Text = stn6.Text; t5.Text = t6.Text; m5.Text = m6.Text; b5.Text = b6.Text;
                stn6.Text = stn7.Text; t6.Text = t7.Text; m6.Text = m7.Text; b6.Text = b7.Text;
                stn7.Text = stn8.Text; t7.Text = t8.Text; m7.Text = m8.Text; b7.Text = b8.Text;
                stn8.Text = stn9.Text; t8.Text = t9.Text; m8.Text = m9.Text; b8.Text = b9.Text;
                stn9.Text = stn10.Text; t9.Text = t10.Text; m9.Text = m10.Text; b9.Text = b10.Text;
                stn10.Text = ""; t10.Text = ""; m10.Text = ""; b10.Text = "";
            }
        }

        private void Sil5_Click(object sender, EventArgs e)
        {
            stn5.Text = ""; t5.Text = ""; m5.Text = ""; b5.Text = "";
            if (stn6.Text != "")
            {
                stn5.Text = stn6.Text; t5.Text = t6.Text; m5.Text = m6.Text; b5.Text = b6.Text;
                stn6.Text = stn7.Text; t6.Text = t7.Text; m6.Text = m7.Text; b6.Text = b7.Text;
                stn7.Text = stn8.Text; t7.Text = t8.Text; m7.Text = m8.Text; b7.Text = b8.Text;
                stn8.Text = stn9.Text; t8.Text = t9.Text; m8.Text = m9.Text; b8.Text = b9.Text;
                stn9.Text = stn10.Text; t9.Text = t10.Text; m9.Text = m10.Text; b9.Text = b10.Text;
                stn10.Text = ""; t10.Text = ""; m10.Text = ""; b10.Text = "";
            }
        }

        private void Sil6_Click(object sender, EventArgs e)
        {
            stn6.Text = ""; t6.Text = ""; m6.Text = ""; b6.Text = "";
            if (stn7.Text != "")
            {
                stn6.Text = stn7.Text; t6.Text = t7.Text; m6.Text = m7.Text; b6.Text = b7.Text;
                stn7.Text = stn8.Text; t7.Text = t8.Text; m7.Text = m8.Text; b7.Text = b8.Text;
                stn8.Text = stn9.Text; t8.Text = t9.Text; m8.Text = m9.Text; b8.Text = b9.Text;
                stn9.Text = stn10.Text; t9.Text = t10.Text; m9.Text = m10.Text; b9.Text = b10.Text;
                stn10.Text = ""; t10.Text = ""; m10.Text = ""; b10.Text = "";
            }
        }

        private void Sil7_Click(object sender, EventArgs e)
        {
            stn7.Text = ""; t7.Text = ""; m7.Text = ""; b7.Text = "";
            if (stn8.Text != "")
            {
                stn7.Text = stn8.Text; t7.Text = t8.Text; m7.Text = m8.Text; b7.Text = b8.Text;
                stn8.Text = stn9.Text; t8.Text = t9.Text; m8.Text = m9.Text; b8.Text = b9.Text;
                stn9.Text = stn10.Text; t9.Text = t10.Text; m9.Text = m10.Text; b9.Text = b10.Text;
                stn10.Text = ""; t10.Text = ""; m10.Text = ""; b10.Text = "";
            }
        }

        private void Sil8_Click(object sender, EventArgs e)
        {
            stn8.Text = ""; t8.Text = ""; m8.Text = ""; b8.Text = "";
            if (stn9.Text != "")
            {
                stn8.Text = stn9.Text; t8.Text = t9.Text; m8.Text = m9.Text; b8.Text = b9.Text;
                stn9.Text = stn10.Text; t9.Text = t10.Text; m9.Text = m10.Text; b9.Text = b10.Text;
                stn10.Text = ""; t10.Text = ""; m10.Text = ""; b10.Text = "";
            }
        }

        private void Sil9_Click(object sender, EventArgs e)
        {
            stn9.Text = ""; t9.Text = ""; m9.Text = ""; b9.Text = "";
            if (stn10.Text != "")
            {
                stn9.Text = stn10.Text; t9.Text = t10.Text; m9.Text = m10.Text; b9.Text = b10.Text;
                stn10.Text = ""; t10.Text = ""; m10.Text = ""; b10.Text = "";
            }
        }

        private void Sil10_Click(object sender, EventArgs e)
        {
            stn10.Text = ""; t10.Text = ""; m10.Text = ""; b10.Text = "";
        }
        private void TxtStokArama_TextChanged(object sender, EventArgs e)
        {

            string stokno = TxtStokArama.Text;
            if (malzeme == "YEDEK PARÇA")
            {
                /*if (TxtStokArama.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle Malzeme Türü Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/
                if (string.IsNullOrEmpty(stokno))
                {
                    malzemesFiltered = malzemeKayits;
                    dataBinder.DataSource = malzemeKayits.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtTop.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStokArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = malzemesFiltered.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                malzemesFiltered = malzemeKayits;
                TxtTop.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "AMBAR")
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    ambarFiltired = destekDepoAmbars;
                    dataBinder.DataSource = destekDepoAmbars.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtTop.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStokArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = ambarFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                ambarFiltired = destekDepoAmbars;
                TxtTop.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "ÇAY OCAĞI")
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    cayOcagiFiltired = cayOcagis;
                    dataBinder.DataSource = cayOcagis.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtTop.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStokArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = cayOcagiFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                cayOcagiFiltired = cayOcagis;
                TxtTop.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "EL ALETLERİ")
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    elAletleriFiltired = elAletleris;
                    dataBinder.DataSource = elAletleris.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtTop.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStokArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = elAletleriFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                elAletleriFiltired = elAletleris;
                TxtTop.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "İŞ GİYSİ")
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    isgiysiFiltired = destekDepoIs;
                    dataBinder.DataSource = destekDepoIs.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtTop.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStokArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = isgiysiFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                isgiysiFiltired = destekDepoIs;
                TxtTop.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "KIRTASİYE")
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    kirtasiyeFiltired = kirtasiyes;
                    dataBinder.DataSource = kirtasiyes.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtTop.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStokArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = kirtasiyeFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                kirtasiyeFiltired = kirtasiyes;
                TxtTop.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "KKD")
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    kkdFiltired = kKDs;
                    dataBinder.DataSource = kKDs.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtTop.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStokArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = kkdFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                kkdFiltired = kKDs;
                TxtTop.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "TEMİZLİK ÜRÜNLERİ")
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    temizlikUrunleriFitired = temizlikUrunleris;
                    dataBinder.DataSource = temizlikUrunleris.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtTop.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStokArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = temizlikUrunleriFitired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                temizlikUrunleriFitired = temizlikUrunleris;
                TxtTop.Text = DtgStokList.RowCount.ToString();
            }


            /*if (!canFilter)
            {
                return;
            }
            string stokno = TxtStokArama.Text;

            if (string.IsNullOrEmpty(stokno))
            {
                stoknosFiltered = products;
                productBinder.DataSource = products.ToDataTable();
                AdvDtgProducts.DataSource = productBinder;
                TxtTop.Text = AdvDtgProducts.RowCount.ToString();
                AdvDtgProductsDisplay();
                return;
            }
            if (TxtStokArama.Text.Length < 3)
            {
                return;
            }
            productBinder.DataSource = stoknosFiltered.Where(x => x.StokNo.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
            AdvDtgProducts.DataSource = productBinder;
            TxtTop.Text = AdvDtgProducts.RowCount.ToString();
            AdvDtgProductsDisplay();
            stoknosFiltered = products;*/
        }
        List<Product> tanimFiltered = new List<Product>();
        private void TxtTanimArama_TextChanged(object sender, EventArgs e)
        {
            /*if (TxtTanimArama.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Malzeme Türü Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            string tanim = TxtTanimArama.Text;
            if (malzeme == "YEDEK PARÇA")
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    malzemesFiltered = malzemeKayits;
                    dataBinder.DataSource = malzemeKayits.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtTop.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanimArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = malzemesFiltered.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                malzemesFiltered = malzemeKayits;
                TxtTop.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "AMBAR")
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    ambarFiltired = destekDepoAmbars;
                    dataBinder.DataSource = destekDepoAmbars.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtTop.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanimArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = ambarFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                ambarFiltired = destekDepoAmbars;
                TxtTop.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "ÇAY OCAĞI")
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    cayOcagiFiltired = cayOcagis;
                    dataBinder.DataSource = cayOcagis.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtTop.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanimArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = cayOcagiFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                cayOcagiFiltired = cayOcagis;
                TxtTop.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "EL ALETLERİ")
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    elAletleriFiltired = elAletleris;
                    dataBinder.DataSource = elAletleris.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtTop.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanimArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = elAletleriFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                elAletleriFiltired = elAletleris;
                TxtTop.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "İŞ GİYSİ")
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    isgiysiFiltired = destekDepoIs;
                    dataBinder.DataSource = destekDepoIs.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtTop.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanimArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = isgiysiFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                isgiysiFiltired = destekDepoIs;
                TxtTop.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "KIRTASİYE")
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    kirtasiyeFiltired = kirtasiyes;
                    dataBinder.DataSource = kirtasiyes.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtTop.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanimArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = kirtasiyeFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                kirtasiyeFiltired = kirtasiyes;
                TxtTop.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "KKD")
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    kkdFiltired = kKDs;
                    dataBinder.DataSource = kKDs.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtTop.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanimArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = kkdFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                kkdFiltired = kKDs;
                TxtTop.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "TEMİZLİK ÜRÜNLERİ")
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    temizlikUrunleriFitired = temizlikUrunleris;
                    dataBinder.DataSource = temizlikUrunleris.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtTop.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanimArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = temizlikUrunleriFitired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                temizlikUrunleriFitired = temizlikUrunleris;
                TxtTop.Text = DtgStokList.RowCount.ToString();
            }


            /*if (!canFilter)
            {
                return;
            }
            string tanim = TxtTanimArama.Text;

            if (string.IsNullOrEmpty(tanim))
            {
                tanimFiltered = products;
                productBinder.DataSource = products.ToDataTable();
                AdvDtgProducts.DataSource = productBinder;
                TxtTop.Text = AdvDtgProducts.RowCount.ToString();
                AdvDtgProductsDisplay();
                return;
            }
            if (TxtTanimArama.Text.Length < 3)
            {
                return;
            }
            productBinder.DataSource = tanimFiltered.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
            AdvDtgProducts.DataSource = productBinder;
            TxtTop.Text = AdvDtgProducts.RowCount.ToString();
            AdvDtgProductsDisplay();
            tanimFiltered = products;*/
        }
        string malzeme;
        private void CmbMalzemeTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            malzeme = CmbMalzemeTuru.Text;
            int index = CmbMalzemeTuru.SelectedIndex.ConInt();
            StokCek();
        }
        List<DestekDepoCayOcagi> cayOcagiFiltired;
        List<DestekDepoElAletleri> elAletleriFiltired;
        List<DestekDepoIsGiysi> isgiysiFiltired;
        List<DestekDepoKirtasiye> kirtasiyeFiltired;
        List<DestekDepoKKD> kkdFiltired;
        List<DestekDepoTemizlikUrunleri> temizlikUrunleriFitired;
        void StokCek()
        {
            if (malzeme == "YEDEK PARÇA")
            {
                malzemeKayits = malzemeKayitManager.GetList();
                malzemesFiltered = malzemeKayits;
                dataBinder.DataSource = malzemeKayits.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                TxtTop.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (malzeme == "AMBAR")
            {

                destekDepoAmbars = ambarManager.GetList();
                ambarFiltired = destekDepoAmbars;
                dataBinder.DataSource = destekDepoAmbars.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                TxtTop.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (malzeme == "ÇAY OCAĞI")
            {

                cayOcagis = cayOcagiManager.GetList();
                cayOcagiFiltired = cayOcagis;
                dataBinder.DataSource = cayOcagis.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                TxtTop.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (malzeme == "EL ALETLERİ")
            {

                elAletleris = elAletleriManager.GetList();
                elAletleriFiltired = elAletleris;
                dataBinder.DataSource = elAletleris.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                TxtTop.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (malzeme == "İŞ GİYSİ")
            {

                destekDepoIs = isGiysiManager.GetList();
                isgiysiFiltired = destekDepoIs;
                dataBinder.DataSource = destekDepoIs.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                TxtTop.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (malzeme == "KIRTASİYE")
            {

                kirtasiyes = kirtasiyeManager.GetList();
                kirtasiyeFiltired = kirtasiyes;
                dataBinder.DataSource = kirtasiyes.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                TxtTop.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (malzeme == "KKD")
            {

                kKDs = kKDManager.GetList();
                kkdFiltired = kKDs;
                dataBinder.DataSource = kKDs.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                TxtTop.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (malzeme == "TEMİZLİK ÜRÜNLERİ")
            {

                temizlikUrunleris = temizlikUrunleriManager.GetList();
                temizlikUrunleriFitired = temizlikUrunleris;
                dataBinder.DataSource = temizlikUrunleris.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                TxtTop.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
        }

        private void DtgStokList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (DtgStokList.DataSource == null)
            {
                return;
            }
            if (stn1.Text == "")
            {
                stn1.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                t1.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                b1.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 0;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn1.Text = ""; t1.Text = ""; m1.Text = ""; b1.Text = "";
                    return;
                }
                return;
            }
            if (stn2.Text == "")
            {
                stn2.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                t2.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                b2.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn2.Text = ""; t2.Text = ""; m2.Text = ""; b2.Text = "";
                    return;
                }
                return;
            }
            if (stn3.Text == "")
            {
                stn3.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                t3.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                b3.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 2;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn3.Text = ""; t3.Text = ""; m3.Text = ""; b3.Text = "";
                    return;
                }
                return;
            }
            if (stn4.Text == "")
            {
                stn4.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                t4.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                b4.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 3;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn4.Text = ""; t4.Text = ""; m4.Text = ""; b4.Text = "";
                    return;
                }
                return;
            }
            if (stn5.Text == "")
            {
                stn5.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                t5.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                b5.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 4;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn5.Text = ""; t5.Text = ""; m5.Text = ""; b5.Text = "";
                    return;
                }
                return;
            }
            if (stn6.Text == "")
            {
                stn6.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                t6.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                b6.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 5;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn6.Text = ""; t6.Text = ""; m6.Text = ""; b6.Text = "";
                    return;
                }
                return;
            }
            if (stn7.Text == "")
            {
                stn7.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                t7.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                b7.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 6;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn7.Text = ""; t7.Text = ""; m7.Text = ""; b7.Text = "";
                    return;
                }
                return;
            }
            if (stn8.Text == "")
            {
                stn8.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                t8.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                b8.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 7;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn8.Text = ""; t8.Text = ""; m8.Text = ""; b8.Text = "";
                    return;
                }
                return;
            }
            if (stn9.Text == "")
            {
                stn9.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                t9.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                b9.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 8;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn9.Text = ""; t9.Text = ""; m9.Text = ""; b9.Text = "";
                    return;
                }
                return;
            }
            if (stn10.Text == "")
            {
                stn10.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                t10.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                b10.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 9;
                bilgi = MalzemeKonrol();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stn10.Text = ""; t10.Text = ""; m10.Text = ""; b10.Text = "";
                    return;
                }
                return;
            }
            MessageBox.Show("Bir Seferde Talep Edeceğiniz Malzeme Listesinde Limit Seviyeye ulaştınız.Daha Fazla Talep İçin Lütfen Yeni Bir Satın Alma İşlemi Oluşturunuz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DtgStokList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgStokList.FilterString;
            TxtTop.Text = DtgStokList.RowCount.ToString();
        }

        private void DtgStokList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgStokList.SortString;
        }

        private void Usbolgesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cont == false)
            {
                return;
            }
            if (Usbolgesi.Text == "YERLEŞKE HARCAMALARI")
            {
                BildirimFromNo.Visible = false;
                return;
            }
            BildirimFromNo.Visible = true;
        }

        private void FrmSatOlustur_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dosyasil == 1)
            {
                if (dosyaYolu != null)
                {
                    Directory.Delete(dosyaYolu, true);
                }
            }
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
            MailSend("SAT Oluşturma İşlemi ", "Merhaba; \n\n" + satno + " Numaralı SAT kaydı, " + islemyapan +
                " tarafından oluşturulmuştur. Sat Ön Onay Aşamasında Beklemektedir." + "\n\nİyi Çalışmalar.", new List<string>() { amirmail });
        }
        void MailSendMetotPersonel()
        {
            MailSend("SAT Oluşturma İşlemi ", "Merhaba; \n\n" + satno + "  Numaralı SAT kaydınız, oluşturulmuştur. Sat Ön Onay Aşamasında İletilmiştir." + "\n\nİyi Çalışmalar.", new List<string>() { mail });
        }

        void ProductsLoad()
        {
            //IXLWorkbook workbook = new XLWorkbook(alinandosya);
            IXLWorkbook workbook = new XLWorkbook("C:\\STS\\StokListesi.XLSX");

            //IXLWorkbook workbook = new XLWorkbook("Z:\\DTS\\SATIN_ALMA\\StokListesi.XLSX");
            bool addImage = false; // exceldeki resimlerin adreslerine göre kontrol yaparken if şartını geçerse bu değişkene göre entity değerini ekliyor

            //int count = workbook.Worksheets.Count; => 22.05.2021 - 22 Sayfa
            foreach (IXLWorksheet workSheet in workbook.Worksheets)
            {
                var range = workSheet.RangeUsed();
                IXLPictures xLPictures = workSheet.Pictures;
                List<string> pictureNames = xLPictures.Select(x => x.Name).ToList();
                Bitmap whitePicture = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), "EmptyPicture.jpg"));

                //var c = xLPictures.Picture(pictureNames[0]).Format; //jpej

                IXLPicture productPicture = null;
                int index = -1;
                foreach (IXLRangeRow item in range.Rows(3, range.RowCount()))
                {
                    if (string.IsNullOrEmpty(item.Cell("A").Value.ToString()))
                    {
                        continue;
                    }

                    if (xLPictures.Count > 0)
                    {
                        IXLAddress currentAddress = item.Cell("D").Address;
                        if (index < xLPictures.Count - 1)
                        {
                            productPicture = xLPictures.Where(x => x.TopLeftCell.Address.ToString() == currentAddress.ToString()).FirstOrDefault();
                            if (productPicture != null)
                            {
                                addImage = true;
                            }
                        }
                    }

                    Product product = new Product(
                        item.Cell("A").Value.ToString(),
                        item.Cell("B").Value.ToString(),
                        addImage ? productPicture.ImageStream.GetBuffer() : whitePicture.ImageToByteArray()
                    );
                    products.Add(product);
                    addImage = false;
                }
                //break;
            }


            // int count = products.Count; => 22.05.2021 - 1888 Ürün
            DtgProducts.Rows.Clear();
            foreach (Product item in products)
            {
                DtgProducts.Rows.Add();
                int lastRow = DtgProducts.RowCount - 1;
                DtgProducts.Rows[lastRow].Height = 150;
                DtgProducts.Rows[lastRow].Cells["StokNo"].Value = item.StokNo;
                DtgProducts.Rows[lastRow].Cells["Tanim"].Value = item.Tanim;
                Bitmap bitmap = null;
                if (item.Image != null)
                {
                    bitmap = new Bitmap(item.Image.ByteArrayToImage());
                    DtgProducts.Rows[lastRow].Cells["Image"].Value = bitmap;
                }
                else
                {
                    bitmap = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), "EmptyPicture.jpg"));
                    DtgProducts.Rows[lastRow].Cells["Image"].Value = bitmap;
                }
            }

            /*productBinder.DataSource = products.ToDataTable();
            AdvDtgProducts.Invoke((MethodInvoker)(() => AdvDtgProducts.DataSource = productBinder));
            AdvDtgProducts.Invoke((MethodInvoker)(() => AdvDtgProductsDisplay()));
            AdvDtgProducts.Invoke((MethodInvoker)(() => TxtTop.Text = AdvDtgProducts.RowCount.ToString()));*/

        }
        void AdvDtgProductsDisplay()
        {
            AdvDtgProducts.Columns["StokNo"].HeaderText = "Stok Numarası";
            AdvDtgProducts.Columns["Tanim"].HeaderText = "Tanım";
            AdvDtgProducts.Columns["Image"].HeaderText = "Ürün Fotoğrafı";


            AdvDtgProducts.Columns["StokNo"].Width = 115;
            AdvDtgProducts.Columns["Tanim"].Width = 240;
            AdvDtgProducts.Columns["Tanim"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            AdvDtgProducts.DisableFilter(AdvDtgProducts.Columns["Image"]);
        }

        private void AdvDtgProducts_FilterStringChanged(object sender, EventArgs e)
        {
            productBinder.Filter = AdvDtgProducts.FilterString;
        }

        private void AdvDtgProducts_SortStringChanged(object sender, EventArgs e)
        {
            productBinder.Sort = AdvDtgProducts.SortString;
        }
    }
}
