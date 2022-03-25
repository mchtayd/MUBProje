using Business;
using Business.Concreate;
using Business.Concreate.Depo;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using ClosedXML.Excel;
using ClosedXML.Excel.Drawings;
using DataAccess.Concreate;
using DataAccess.Concreate.Depo;
using DataAccess.Concreate.STS;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.STS
{
    public partial class FrmSATGuncelle : Form
    {
        SatDataGridview1Manager satDataGridview1Manager;
        SatTalebiDoldurManager satTalebiDoldurManager;
        SiparislerManager siparislerManager;
        SiparisPersonelManager siparisPersonelManager;
        SatinAlinacakMalManager satinAlinacakMalManager;
        SatIslemAdimlariManager satIslemAdimlariManager;
        ButceKoduManager butceKoduManager;
        TeklifiAlinanManager teklifiAlinanManager;
        TeklifFirmalarManager teklifFirmalarManager;
        FiyatTeklifiAlManager fiyatTeklifiAlManager;
        TeklifsizSatManager teklifsizSatManager;
        MalzemeKayitManager malzemeKayitManager;
        ReddedilenlerManager reddedilenlerManager;
        PersonelKayitManager kayitManager;
        ReddedilenMalzemeManager reddedilenMalzemeManager;
        ComboManager comboManager;
        AmbarManager ambarManager;
        CayOcagiManager cayOcagiManager;
        DestekDepoMalzemeKayitManager depoMalzemeKayitManager;
        ElAletleriManager elAletleriManager;
        IsGiysiManager isGiysiManager;
        KirtasiyeManager kirtasiyeManager;
        KKDManager kKDManager;
        TemizlikUrunleriManager temizlikUrunleriManager;
        SatDataGridview1 dataGridview1;
        List<MalzemeKayit> malzemeKayits;
        List<MalzemeKayit> malzemesFiltered;
        List<SatDataGridview1> satDatas;
        List<SatDataGridview1> satDatas2;
        List<SatDataGridview1> satDatas3;
        List<SatDataGridview1> satDatas4;
        List<SatDataGridview1> satDatas5;
        List<SatinAlinacakMalzemeler> satinAlinacakMalzemelers;
        List<TeklifAlinan> teklifiAlinans;
        List<FiyatTeklifiAl> fiyatTeklifiAls;
        List<TeklifsizSat> teklifsizSats;
        List<TeklifsizSat> teklifsizSats2;
        List<SatDataGridview1> reddedilenler;
        List<string> supplierNames;
        List<Product> stoknosFiltered = new List<Product>();
        List<Product> tanimFiltered = new List<Product>();
        List<Product> products = new List<Product>();
        List<string> fileNames = new List<string>();
        public object[] infos;
        string islemyapan, siparis, satno, siparisNo, dosya, usbolgesi, abfformno, gerekce, kaynakdosyaismi, alinandosya, bilgi, benzersiz, dosya2, butcekodu, satbirim, harcamaturu, faturafirma, ilgilikisi, masyerino, formno, benzersiz3, dosya3, satno3, benzersiz4="", dosya4, satno4, messege, topfiyat, benzersiz5, dosya5, satno5, tamyol, mesaj, islemmm, yapilanislem;
        bool gec, canFilter = false, start = false;
        int id, atla, index, malzemesayisi = 0, islemid; int uctekilf = 1, satNo, idRed = 0, indexGuncelle;
        double geneltop1 = 0, geneltop2 = 0, geneltop3 = 0, sonuc, outValue = 0, toplam = 0;
        double x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, y1, y2, y3, y4, y5, y6, y7, y8, y9, y10, z1, z2, z3, z4, z5, z6, z7, z8, z9, z10,
            a1, a2, a3, a4, a5, a6, a7, a8, a9, a10 = 0;
        public FrmSATGuncelle()
        {
            InitializeComponent();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            satTalebiDoldurManager = SatTalebiDoldurManager.GetInstance();
            siparislerManager = SiparislerManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
            butceKoduManager = ButceKoduManager.GetInstance();
            teklifiAlinanManager = TeklifiAlinanManager.GetInstance();
            teklifFirmalarManager = TeklifFirmalarManager.GetInstance();
            fiyatTeklifiAlManager = FiyatTeklifiAlManager.GetInstance();
            teklifsizSatManager = TeklifsizSatManager.GetInstance();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
            ambarManager = AmbarManager.GetInstance();
            cayOcagiManager = CayOcagiManager.GetInstance();
            depoMalzemeKayitManager = DestekDepoMalzemeKayitManager.GetInstance();
            elAletleriManager = ElAletleriManager.GetInstance();
            isGiysiManager = IsGiysiManager.GetInstance();
            kirtasiyeManager = KirtasiyeManager.GetInstance();
            kKDManager = KKDManager.GetInstance();
            temizlikUrunleriManager = TemizlikUrunleriManager.GetInstance();
            reddedilenlerManager = ReddedilenlerManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            reddedilenMalzemeManager = ReddedilenMalzemeManager.GetInstance();
            comboManager = ComboManager.GetInstance();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSatGuncelle"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void FrmSATGuncelle_Load(object sender, EventArgs e)
        {
            gec = false;
            FillInfos();
            DataDisplay();
            UsBolgeleri();
            DataDisplayReddedilenler();
            Personeller();
            UsBolgeleriGuncelle();
            ButceKoduKalemiGuncelle();
            ProjeKodu();
            //Siparisler();
            gec = true;
            //ProductsLoadProcess();
            DataDisplayDTG();
            ButceKoduKalemi();
            DtgSatOnOnayDisplay();
            DtgTeklifAlDisplay();
            DtgSatListDisplay();
            DtgSatDisplay();
            /*if (infos[1].ToString() != "RESUL GÜNEŞ" || infos[1].ToString() != "GÜLŞAH OTACI" || infos[1].ToString() != "MÜCAHİT AYDEMİR")
            {*/
            /*tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage2"]);
            tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage7"]);*/
            //}
            TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            TxtTop.Text = DtgSatOlusturan.RowCount.ToString();
            TxtTop2.Text = DtgSatOnOnay.RowCount.ToString();
            TxtTop3.Text = DtgTeklifAl.RowCount.ToString();
            TxtTop4.Text = DtgSatList.RowCount.ToString();
            TxtTop5.Text = DtgSat.RowCount.ToString();

            start = true;
        }
        void ProjeKodu()
        {
            CmbProjeKodu.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProjeKodu.ValueMember = "Id";
            CmbProjeKodu.DisplayMember = "Baslik";
            CmbProjeKodu.SelectedValue = 0;
        }
        void UsBolgeleri()
        {
            Usbolgesi.DataSource = satTalebiDoldurManager.GetList();
            Usbolgesi.ValueMember = "Id";
            Usbolgesi.DisplayMember = "Usbolgesi";
            Usbolgesi.SelectedValue = "";
        }
        void DataDisplayDTG()
        {
            malzemeKayits = malzemeKayitManager.GetList();
            malzemesFiltered = malzemeKayits;
            dataBinder.DataSource = malzemeKayits.ToDataTable();
            DtgStokList.DataSource = dataBinder;

            DtgStokList.Columns["Id"].Visible = false;
            DtgStokList.Columns["Stokno"].HeaderText = "STOK_NO";
            DtgStokList.Columns["Tanim"].HeaderText = "TANIM";
            DtgStokList.Columns["Birim"].HeaderText = "BİRİM";
            DtgStokList.Columns["Tedarikcifirma"].Visible = false;
            DtgStokList.Columns["Malzemeonarimdurumu"].Visible = false;
            DtgStokList.Columns["Malzemeonarımyeri"].Visible = false;
            DtgStokList.Columns["Malzemeturu"].Visible = false;
            DtgStokList.Columns["Malzemetakipdurumu"].Visible = false;
            DtgStokList.Columns["Malzemerevizyon"].Visible = false;
            //DtgStokList.Columns["Malzemelot"].Visible = false;
            DtgStokList.Columns["Malzemekul"].Visible = false;
            DtgStokList.Columns["Aciklama"].Visible = false;
            DtgStokList.Columns["Dosyayolu"].Visible = false;
            DtgStokList.Columns["KayitDurumu"].Visible = false;
            DtgStokList.Columns["SeriNo"].Visible = false;
            DtgStokList.Columns["Durum"].Visible = false;
            DtgStokList.Columns["Revizyon"].Visible = false;
            DtgStokList.Columns["Miktar"].Visible = false;
            DtgStokList.Columns["TalepTarihi"].Visible = false;
            DtgStokList.Columns["SistemStokNo"].Visible = false;
            DtgStokList.Columns["SistemTanim"].Visible = false;

            TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
        }
        /*async void ProductsLoadProcess()
        {
            Task task = new Task(ProductsLoad);
            task.Start();
            BtnCancel.Enabled = false;
            BtnGuncelle1.Enabled = false;
            DosyaEkle1.Enabled = false;
            BtnSatTalebiSil.Enabled = false;
            LblProductsWait.Visible = true;
            TxtStokArama.Enabled = false;
            TxtTanimArama.Enabled = false;
            BtnGuncelle1.Enabled = false;
            tabControl2.Enabled = false;
            await task;
            BtnCancel.Enabled = true;
            BtnGuncelle1.Enabled = true;
            DosyaEkle1.Enabled = true;
            BtnSatTalebiSil.Enabled = true;
            LblProductsWait.Visible = false;
            TxtStokArama.Enabled = true;
            TxtTanimArama.Enabled = true;
            canFilter = true;
            BtnGuncelle1.Enabled = true;
            tabControl2.Enabled = true;
        }*/
        void DataDisplay()
        {
            satDatas = satDataGridview1Manager.GuncelleList(islemid);
            dataBinder1.DataSource = satDatas.ToDataTable();
            DtgSatOlusturan.DataSource = dataBinder1;

            DtgSatOlusturan.Columns["Id"].Visible = false;
            DtgSatOlusturan.Columns["PersonelId"].Visible = false;
            DtgSatOlusturan.Columns["Satno"].HeaderText = "SAT FORM NO";
            DtgSatOlusturan.Columns["Talepeden"].HeaderText = "İSTEKTE BULUNAN";
            DtgSatOlusturan.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgSatOlusturan.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgSatOlusturan.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgSatOlusturan.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgSatOlusturan.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgSatOlusturan.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgSatOlusturan.Columns["Burcekodu"].Visible = false;
            DtgSatOlusturan.Columns["Satbirim"].Visible = false;
            DtgSatOlusturan.Columns["Harcamaturu"].Visible = false;
            DtgSatOlusturan.Columns["Faturafirma"].Visible = false;
            DtgSatOlusturan.Columns["Ilgilikisi"].Visible = false;
            DtgSatOlusturan.Columns["Masyerino"].Visible = false;
            DtgSatOlusturan.Columns["SiparisNo"].Visible = false;
            DtgSatOlusturan.Columns["DosyaYolu"].Visible = false;
            DtgSatOlusturan.Columns["Uctekilf"].Visible = false;

            DtgSatOlusturan.Columns["Gerekce"].Width = 400;
            DtgSatOlusturan.Columns["Talepeden"].Width = 120;
            DtgSatOlusturan.Columns["Masrafyeri"].Width = 80;
            DtgSatOlusturan.Columns["Satno"].Width = 90;
            DtgSatOlusturan.Columns["Bolum"].Width = 160;
            DtgSatOlusturan.Columns["Tarih"].Width = 80;
        }
        void FillInfos()
        {
            islemyapan = infos[1].ToString();
            islemid = infos[0].ConInt();
        }
        /*void ComboboxLoad()
        {
            Usbolgesi.DataSource = satTalebiDoldurManager.GetList();
            Usbolgesi.ValueMember = "Id";
            Usbolgesi.DisplayMember = "Usbolgesi";
            Usbolgesi.SelectedValue = "";
        }*/
        /*void Siparisler()
        {
            CmbPersonelSiparis.DataSource = siparislerManager.GetList();
            CmbPersonelSiparis.ValueMember = "Id";
            CmbPersonelSiparis.DisplayMember = "Siparisno";
            CmbPersonelSiparis.SelectedValue = 0;
        }
        void SiparisIsimlerDoldur()
        {
            CmbPersonel.DataSource = siparisPersonelManager.GetList(siparis);
            CmbPersonel.ValueMember = "Id";
            CmbPersonel.DisplayMember = "Personel";
            CmbPersonel.SelectedValue = 0;
        }*/
        #region SilButonları
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
        #endregion
        private void TxtStokArama_TextChanged(object sender, EventArgs e)
        {
            string stokno = TxtStokArama.Text;
            if (index == 0)
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
                    TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStokArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = malzemesFiltered.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                malzemesFiltered = malzemeKayits;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            }
            if (index == 1)
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    ambarFiltired = destekDepoAmbars;
                    dataBinder.DataSource = destekDepoAmbars.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStokArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = ambarFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                ambarFiltired = destekDepoAmbars;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            }
            if (index == 2)
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    cayOcagiFiltired = cayOcagis;
                    dataBinder.DataSource = cayOcagis.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStokArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = cayOcagiFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                cayOcagiFiltired = cayOcagis;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            }
            if (index == 3)
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    elAletleriFiltired = elAletleris;
                    dataBinder.DataSource = elAletleris.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStokArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = elAletleriFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                elAletleriFiltired = elAletleris;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            }
            if (index == 4)
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    isgiysiFiltired = destekDepoIs;
                    dataBinder.DataSource = destekDepoIs.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStokArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = isgiysiFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                isgiysiFiltired = destekDepoIs;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            }
            if (index == 5)
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    kirtasiyeFiltired = kirtasiyes;
                    dataBinder.DataSource = kirtasiyes.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStokArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = kirtasiyeFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                kirtasiyeFiltired = kirtasiyes;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            }
            if (index == 6)
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    kkdFiltired = kKDs;
                    dataBinder.DataSource = kKDs.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStokArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = kkdFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                kkdFiltired = kKDs;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            }
            if (index == 7)
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    temizlikUrunleriFitired = temizlikUrunleris;
                    dataBinder.DataSource = temizlikUrunleris.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStokArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = temizlikUrunleriFitired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                temizlikUrunleriFitired = temizlikUrunleris;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            }
            #region Gizle
            /*string stokno = TxtStokArama.Text;
            if (string.IsNullOrEmpty(stokno))
            {
                malzemesFiltered = malzemeKayits;
                dataBinder.DataSource = malzemeKayits.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                return;
            }
            if (TxtStokArama.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemesFiltered.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
            DtgStokList.DataSource = dataBinder;
            malzemesFiltered = malzemeKayits;
            TxtGuncelStok.Text = DtgStokList.RowCount.ToString();*/
            /*if (!canFilter)
            {
                return;
            }
            string stokno = TxtStokArama.Text;

            if (string.IsNullOrEmpty(stokno))
            {
                stoknosFiltered = products;
                productBinder.DataSource = products.ToDataTable();
                DtgStokList.DataSource = productBinder;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                AdvDtgProductsDisplay();
                return;
            }
            if (TxtStokArama.Text.Length < 3)
            {
                return;
            }
            productBinder.DataSource = stoknosFiltered.Where(x => x.StokNo.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
            DtgStokList.DataSource = productBinder;
            TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            AdvDtgProductsDisplay();
            stoknosFiltered = products;*/
            #endregion
        }

        private void TxtTanimArama_TextChanged(object sender, EventArgs e)
        {
            string tanim = TxtTanimArama.Text;
            if (index == 0)
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    malzemesFiltered = malzemeKayits;
                    dataBinder.DataSource = malzemeKayits.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanimArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = malzemesFiltered.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                malzemesFiltered = malzemeKayits;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            }
            if (index == 1)
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    ambarFiltired = destekDepoAmbars;
                    dataBinder.DataSource = destekDepoAmbars.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanimArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = ambarFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                ambarFiltired = destekDepoAmbars;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            }
            if (index == 2)
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    cayOcagiFiltired = cayOcagis;
                    dataBinder.DataSource = cayOcagis.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanimArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = cayOcagiFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                cayOcagiFiltired = cayOcagis;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            }
            if (index == 3)
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    elAletleriFiltired = elAletleris;
                    dataBinder.DataSource = elAletleris.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanimArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = elAletleriFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                elAletleriFiltired = elAletleris;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            }
            if (index == 4)
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    isgiysiFiltired = destekDepoIs;
                    dataBinder.DataSource = destekDepoIs.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanimArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = isgiysiFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                isgiysiFiltired = destekDepoIs;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            }
            if (index == 5)
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    kirtasiyeFiltired = kirtasiyes;
                    dataBinder.DataSource = kirtasiyes.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanimArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = kirtasiyeFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                kirtasiyeFiltired = kirtasiyes;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            }
            if (index == 6)
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    kkdFiltired = kKDs;
                    dataBinder.DataSource = kKDs.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanimArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = kkdFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                kkdFiltired = kKDs;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            }
            if (index == 7)
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    temizlikUrunleriFitired = temizlikUrunleris;
                    dataBinder.DataSource = temizlikUrunleris.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanimArama.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = temizlikUrunleriFitired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                temizlikUrunleriFitired = temizlikUrunleris;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            }
            #region Gizli
            /*string tanim = TxtTanimArama.Text;
            if (string.IsNullOrEmpty(tanim))
            {
                malzemesFiltered = malzemeKayits;
                dataBinder.DataSource = malzemeKayits.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                return;
            }
            if (TxtTanimArama.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemesFiltered.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
            DtgStokList.DataSource = dataBinder;
            malzemesFiltered = malzemeKayits;
            TxtGuncelStok.Text = DtgStokList.RowCount.ToString();*/
            /*if (!canFilter)
            {
                return;
            }
            string tanim = TxtTanimArama.Text;

            if (string.IsNullOrEmpty(tanim))
            {
                tanimFiltered = products;
                productBinder.DataSource = products.ToDataTable();
                DtgStokList.DataSource = productBinder;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                AdvDtgProductsDisplay();
                return;
            }
            if (TxtTanimArama.Text.Length < 3)
            {
                return;
            }
            productBinder.DataSource = tanimFiltered.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
            DtgStokList.DataSource = productBinder;
            TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
            AdvDtgProductsDisplay();
            tanimFiltered = products;*/
            #endregion
        }

        private void BtnGuncelle1_Click(object sender, EventArgs e)
        {
            if (DtgSatOlusturan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT Kaydınızı Güncellemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                SatDataGridview1 satDataGridview1 = new SatDataGridview1(Usbolgesi.Text, BildirimFromNo.Text, Gerekce.Text);
                string mesaj1 = satDataGridview1Manager.SatGuncelle(satDataGridview1, siparisNo);
                if (mesaj1 != "OK")
                {
                    MessageBox.Show(mesaj1);
                    return;
                }
                satinAlinacakMalManager.Delete(siparisNo);
                MalzemeKaydet();
                string islem = "SAT Talebi Güncellenmiştir.";
                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, islem, islemyapan, DateTime.Now);
                satIslemAdimlariManager.Add(satIslemAdimlari);
                MessageBox.Show(satno + " Nolu SAT Kaydınız Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
            }
        }

        void MalzemeKaydet()
        {
            List<SatinAlinacakMalzemeler> list = new List<SatinAlinacakMalzemeler>();

            if (stn1.Text.Trim() != "" && t1.Text.Trim() != "" && m1.Text.Trim() != "" && b1.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn1.Text, t1.Text, m1.Text.ConInt(), b1.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn2.Text.Trim() != "" && t2.Text.Trim() != "" && m2.Text.Trim() != "" && b2.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn2.Text, t2.Text, m2.Text.ConInt(), b2.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn3.Text.Trim() != "" && t3.Text.Trim() != "" && m3.Text.Trim() != "" && b3.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn3.Text, t3.Text, m3.Text.ConInt(), b3.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn4.Text.Trim() != "" && t4.Text.Trim() != "" && m4.Text.Trim() != "" && b4.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn4.Text, t4.Text, m4.Text.ConInt(), b4.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn5.Text.Trim() != "" && t5.Text.Trim() != "" && m5.Text.Trim() != "" && b5.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn5.Text, t5.Text, m5.Text.ConInt(), b5.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn6.Text.Trim() != "" && t6.Text.Trim() != "" && m6.Text.Trim() != "" && b6.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn6.Text, t6.Text, m6.Text.ConInt(), b6.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn7.Text.Trim() != "" && t7.Text.Trim() != "" && m7.Text.Trim() != "" && b7.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn7.Text, t7.Text, m7.Text.ConInt(), b7.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn8.Text.Trim() != "" && t8.Text.Trim() != "" && m8.Text.Trim() != "" && b8.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn8.Text, t8.Text, m8.Text.ConInt(), b8.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn9.Text.Trim() != "" && t9.Text.Trim() != "" && m9.Text.Trim() != "" && b9.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn9.Text, t9.Text, m9.Text.ConInt(), b9.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stn10.Text.Trim() != "" && t10.Text.Trim() != "" && m10.Text.Trim() != "" && b10.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stn10.Text, t10.Text, m10.Text.ConInt(), b10.Text, siparisNo);
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

        private void AdvDtgProducts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void BtnSatTalebiSil_Click(object sender, EventArgs e)
        {
            if (DtgSatOlusturan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT Kaydınızı Silmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                satDataGridview1Manager.Delete(id);
                satinAlinacakMalManager.Delete(siparisNo);
                Directory.Delete(dosya, true);
                Temizle();
                DataDisplay();
                webBrowser1.Navigate("");
                TxtTop.Text = DtgSatOlusturan.RowCount.ToString();
            }
        }
        private void DosyaEkle1_Click(object sender, EventArgs e)
        {
            if (dosya == null)
            {
                MessageBox.Show("SAT Dosyası Bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (File.Exists(dosya + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosya + "\\" + kaynakdosyaismi);
                fileNames.Add(alinandosya);
            }
        }

        private void DtgSatOlusturan_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder1.Filter = DtgSatOlusturan.FilterString;
            TxtTop.Text = DtgSatOlusturan.RowCount.ToString();
        }

        private void DtgSatOlusturan_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder1.Sort = DtgSatOlusturan.SortString;
        }

        private void DtgSatOlusturan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgSatOlusturan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }

            id = DtgSatOlusturan.CurrentRow.Cells["Id"].Value.ConInt();
            satno = DtgSatOlusturan.CurrentRow.Cells["Formno"].Value.ToString();
            siparisNo = DtgSatOlusturan.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosya = DtgSatOlusturan.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            usbolgesi = DtgSatOlusturan.CurrentRow.Cells["Usbolgesi"].Value.ToString();
            abfformno = DtgSatOlusturan.CurrentRow.Cells["Abfformno"].Value.ToString();
            gerekce = DtgSatOlusturan.CurrentRow.Cells["Gerekce"].Value.ToString();

            satinAlinacakMalzemelers = satinAlinacakMalManager.GetList(siparisNo);
            FillTools();
        }

        private void CmbPersonelSiparis_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (gec == false)
            {
                return;
            }
            siparis = CmbPersonelSiparis.Text;
            
            SiparisIsimlerDoldur();*/
        }
        void SatGuncelle()
        {
            Usbolgesi.Text = usbolgesi;
            BildirimFromNo.Text = abfformno;
            Gerekce.Text = gerekce;
        }

        void FillTools()
        {
            Temizle();
            SatGuncelle();
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
                stn1.Text = item.Stn1;
                t1.Text = item.T1;
                m1.Text = item.M1.ToString();
                b1.Text = item.B1;
            }
            if (satinAlinacakMalzemelers.Count > 1)
            {
                SatinAlinacakMalzemeler item3 = satinAlinacakMalzemelers[1];
                stn2.Text = item3.Stn1;
                t2.Text = item3.T1;
                m2.Text = item3.M1.ToString();
                b2.Text = item3.B1;
            }

            if (satinAlinacakMalzemelers.Count > 2)
            {
                SatinAlinacakMalzemeler item3 = satinAlinacakMalzemelers[2];
                stn3.Text = item3.Stn1;
                t3.Text = item3.T1;
                m3.Text = item3.M1.ToString();
                b3.Text = item3.B1;
            }

            if (satinAlinacakMalzemelers.Count > 3)
            {
                SatinAlinacakMalzemeler item4 = satinAlinacakMalzemelers[3];
                stn4.Text = item4.Stn1;
                t4.Text = item4.T1;
                m4.Text = item4.M1.ToString();
                b4.Text = item4.B1;
            }

            if (satinAlinacakMalzemelers.Count > 4)
            {
                SatinAlinacakMalzemeler item5 = satinAlinacakMalzemelers[4];
                stn5.Text = item5.Stn1;
                t5.Text = item5.T1;
                m5.Text = item5.M1.ToString();
                b5.Text = item5.B1;
            }

            if (satinAlinacakMalzemelers.Count > 5)
            {


                SatinAlinacakMalzemeler item6 = satinAlinacakMalzemelers[5];
                stn6.Text = item6.Stn1;
                t6.Text = item6.T1;
                m6.Text = item6.M1.ToString();
                b6.Text = item6.B1;
            }

            if (satinAlinacakMalzemelers.Count > 6)
            {
                SatinAlinacakMalzemeler item7 = satinAlinacakMalzemelers[6];
                stn7.Text = item7.Stn1;
                t7.Text = item7.T1;
                m7.Text = item7.M1.ToString();
                b7.Text = item7.B1;
            }

            if (satinAlinacakMalzemelers.Count > 7)
            {

                SatinAlinacakMalzemeler item8 = satinAlinacakMalzemelers[7];
                stn8.Text = item8.Stn1;
                t8.Text = item8.T1;
                m8.Text = item8.M1.ToString();
                b8.Text = item8.B1;
            }

            if (satinAlinacakMalzemelers.Count > 8)
            {
                SatinAlinacakMalzemeler item9 = satinAlinacakMalzemelers[8];
                stn9.Text = item9.Stn1;
                t9.Text = item9.T1;
                m9.Text = item9.M1.ToString();
                b9.Text = item9.B1;
            }

            if (satinAlinacakMalzemelers.Count > 9)
            {
                SatinAlinacakMalzemeler item10 = satinAlinacakMalzemelers[9];
                stn10.Text = item10.Stn1;
                t10.Text = item10.T1;
                m10.Text = item10.M1.ToString();
                b10.Text = item10.B1;
            }
            WebBrowser();

        }

        private void Temizle()
        {
            stn1.Clear(); t1.Clear(); m1.Clear(); b1.Text = ""; stn2.Clear(); t2.Clear(); m2.Clear(); b2.Text = "";
            stn3.Clear(); t3.Clear(); m3.Clear(); b3.Text = ""; stn4.Clear(); t4.Clear(); m4.Clear(); b4.Text = "";
            stn5.Clear(); t5.Clear(); m5.Clear(); b5.Text = ""; stn6.Clear(); t6.Clear(); m6.Clear(); b6.Text = "";
            stn7.Clear(); t7.Clear(); m7.Clear(); b7.Text = ""; stn8.Clear(); t8.Clear(); m8.Clear(); b8.Text = "";
            stn9.Clear(); t9.Clear(); m9.Clear(); b9.Text = ""; stn10.Clear(); t10.Clear(); m10.Clear(); b10.Text = "";
            Usbolgesi.SelectedValue = 0; BildirimFromNo.Text = "";
            Gerekce.Clear(); TxtStokArama.Clear(); TxtTanimArama.Clear(); webBrowser1.Navigate("");
        }
        private void WebBrowser()
        {
            webBrowser1.Navigate(dosya);
        }
        /*void ProductsLoad()
        {

            IXLWorkbook workbook = new XLWorkbook("C:\\STS\\StokListesi.XLSX");
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

                productBinder.DataSource = products.ToDataTable();
                AdvDtgProducts.Invoke((MethodInvoker)(() => AdvDtgProducts.DataSource = productBinder));
                AdvDtgProducts.Invoke((MethodInvoker)(() => AdvDtgProductsDisplay()));
                AdvDtgProducts.Invoke((MethodInvoker)(() => TxtGuncelStok.Text = AdvDtgProducts.RowCount.ToString()));
            }
        }*/
        /*void AdvDtgProductsDisplay()
        {
            AdvDtgProducts.Columns["StokNo"].HeaderText = "Stok Numarası";
            AdvDtgProducts.Columns["Tanim"].HeaderText = "Tanım";
            AdvDtgProducts.Columns["Image"].HeaderText = "Ürün Fotoğrafı";

            /*AdvDtgProducts.Columns["StokNo"].Width = 115;
            AdvDtgProducts.Columns["Tanim"].Width = 240;
            AdvDtgProducts.Columns["Tanim"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            AdvDtgProducts.DisableFilter(AdvDtgProducts.Columns["Image"]);
        }
        */
        //////////////////////////////////////////////////////////// SAYFA 2 ////////////////////////////////////////////////////////////////////

        void ButceKoduKalemi()
        {
            CmbButceKodu.DataSource = butceKoduManager.GetList();
            CmbButceKodu.ValueMember = "Id";
            CmbButceKodu.DisplayMember = "Butcekodu";
            CmbButceKodu.SelectedValue = 0;
        }
        void DtgSatOnOnayDisplay()
        {
            satDatas2 = satDataGridview1Manager.SatGuncelleFaturaList();
            dataBinder2.DataSource = satDatas2.ToDataTable();
            DtgSatOnOnay.DataSource = dataBinder2;

            DtgSatOnOnay.Columns["Id"].Visible = false;
            DtgSatOnOnay.Columns["PersonelId"].Visible = false;
            DtgSatOnOnay.Columns["Satno"].HeaderText = "SAT NO";
            DtgSatOnOnay.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgSatOnOnay.Columns["Talepeden"].HeaderText = "İSTEKTE BULUNAN";
            DtgSatOnOnay.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgSatOnOnay.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgSatOnOnay.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgSatOnOnay.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgSatOnOnay.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgSatOnOnay.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgSatOnOnay.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgSatOnOnay.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgSatOnOnay.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgSatOnOnay.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgSatOnOnay.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgSatOnOnay.Columns["Uctekilf"].Visible = false;
            DtgSatOnOnay.Columns["SiparisNo"].Visible = false;
            DtgSatOnOnay.Columns["DosyaYolu"].Visible = false;
        }
        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            FrmButceKoduKalemi frmButceKoduKalemi = new FrmButceKoduKalemi();
            frmButceKoduKalemi.Show();
        }

        private void CmbFaturaFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CmbFaturaFirma.SelectedIndex;
            CmbIlgiliKisi.SelectedIndex = index;
            CmbMasYeri.SelectedIndex = index;
        }
        private void DtgSatOnOnay_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgSatOnOnay.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            satNo = DtgSatOnOnay.CurrentRow.Cells["Formno"].Value.ConInt();
            formno = DtgSatOnOnay.CurrentRow.Cells["satno"].Value.ToString();
            benzersiz = DtgSatOnOnay.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosya2 = DtgSatOnOnay.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            butcekodu = DtgSatOnOnay.CurrentRow.Cells["Burcekodu"].Value.ToString();
            satbirim = DtgSatOnOnay.CurrentRow.Cells["Satbirim"].Value.ToString();
            harcamaturu = DtgSatOnOnay.CurrentRow.Cells["Harcamaturu"].Value.ToString();
            faturafirma = DtgSatOnOnay.CurrentRow.Cells["Faturafirma"].Value.ToString();
            ilgilikisi = DtgSatOnOnay.CurrentRow.Cells["Ilgilikisi"].Value.ToString();
            masyerino = DtgSatOnOnay.CurrentRow.Cells["Masyerino"].Value.ToString();

            satinAlinacakMalzemelers = satinAlinacakMalManager.GetList(benzersiz);
            FillTools2();
            webBrowser2.Navigate(dosya2);
        }
        void FillTools2()
        {
            Temizle2();
            SatGuncelle2();
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
                sn1.Text = item.Stn1;
                Tanim1.Text = item.T1;
                Miktar1.Text = item.M1.ToString();
                Birim1.Text = item.B1;
            }
            if (satinAlinacakMalzemelers.Count > 1)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[1];
                sn2.Text = item.Stn1;
                Tanim2.Text = item.T1;
                Miktar2.Text = item.M1.ToString();
                Birim2.Text = item.B1;
            }
            if (satinAlinacakMalzemelers.Count > 2)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[2];
                sn3.Text = item.Stn1;
                Tanim3.Text = item.T1;
                Miktar3.Text = item.M1.ToString();
                Birim3.Text = item.B1;
            }
            if (satinAlinacakMalzemelers.Count > 3)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[3];
                sn4.Text = item.Stn1;
                Tanim4.Text = item.T1;
                Miktar4.Text = item.M1.ToString();
                Birim4.Text = item.B1;
            }
            if (satinAlinacakMalzemelers.Count > 4)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[4];
                sn5.Text = item.Stn1;
                Tanim5.Text = item.T1;
                Miktar5.Text = item.M1.ToString();
                Birim5.Text = item.B1;
            }
            if (satinAlinacakMalzemelers.Count > 5)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[5];
                sn6.Text = item.Stn1;
                Tanim6.Text = item.T1;
                Miktar6.Text = item.M1.ToString();
                Birim6.Text = item.B1;
            }
            if (satinAlinacakMalzemelers.Count > 6)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[6];
                sn7.Text = item.Stn1;
                Tanim7.Text = item.T1;
                Miktar7.Text = item.M1.ToString();
                Birim7.Text = item.B1;
            }
            if (satinAlinacakMalzemelers.Count > 7)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[7];
                sn8.Text = item.Stn1;
                Tanim8.Text = item.T1;
                Miktar8.Text = item.M1.ToString();
                Birim8.Text = item.B1;
            }
            if (satinAlinacakMalzemelers.Count > 8)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[8];
                sn9.Text = item.Stn1;
                Tanim9.Text = item.T1;
                Miktar9.Text = item.M1.ToString();
                Birim9.Text = item.B1;
            }
            if (satinAlinacakMalzemelers.Count > 9)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[9];
                sn10.Text = item.Stn1;
                Tanim10.Text = item.T1;
                Miktar10.Text = item.M1.ToString();
                Birim10.Text = item.B1;
            }

        }
        void Temizle2()
        {
            sn1.Clear(); Tanim1.Clear(); Miktar1.Clear(); Birim1.Clear(); sn2.Clear(); Tanim2.Clear(); Miktar2.Clear(); Birim2.Clear();
            sn3.Clear(); Tanim3.Clear(); Miktar3.Clear(); Birim3.Clear(); sn4.Clear(); Tanim4.Clear(); Miktar4.Clear(); Birim4.Clear();
            sn5.Clear(); Tanim5.Clear(); Miktar5.Clear(); Birim5.Clear(); sn6.Clear(); Tanim6.Clear(); Miktar6.Clear(); Birim6.Clear();
            sn7.Clear(); Tanim7.Clear(); Miktar7.Clear(); Birim7.Clear(); sn8.Clear(); Tanim8.Clear(); Miktar8.Clear(); Birim8.Clear();
            sn9.Clear(); Tanim9.Clear(); Miktar9.Clear(); Birim9.Clear(); sn10.Clear(); Tanim10.Clear(); Miktar10.Clear(); Birim10.Clear();

            CmbButceKodu.SelectedValue = ""; CmbSatBirim.Text = ""; CmbHarcamaTuru.Text = ""; CmbFaturaFirma.Text = ""; CmbIlgiliKisi.Text = ""; CmbMasYeri.Text = "";
        }
        void SatGuncelle2()
        {
            CmbButceKodu.Text = butcekodu;
            CmbSatBirim.Text = satbirim;
            CmbHarcamaTuru.Text = harcamaturu;
            CmbFaturaFirma.Text = faturafirma;
            CmbIlgiliKisi.Text = ilgilikisi;
            CmbMasYeri.Text = masyerino;
        }

        private void BtnGuncelle2_Click(object sender, EventArgs e)
        {
            if (DtgSatOnOnay.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT Kaydınızı Güncellemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string satbirim = CmbSatBirim.Text;
                if (satbirim != "BSRN GN.MDL.SATIN ALMA")
                {
                    DialogResult dialog = MessageBox.Show("Ön Onay Yetkilisi:\n\nÖn Onaya gelmiş olan bu satın alma işlemi için malzemenin teknik dökümanlarına " +
                    "uygunluğunu onaylamış, malzeme ihtiyacını teyit ve kabul etmiş olacaksınız.\n\nBu satın alma işlemi için piyasa fiyat araştırmasının " +
                    "yapılarak uygun malzeme ve uygun fiyatın araştırılması üzere en az 3 firmadan fiyat teklifinin yazılı olarak istenmesi gerekmektedir.\n\n" +
                    "Bu işlem için en az 3 firmadan fiyat teklifi alınmasını onaylıyor musunuz?", "BİLGİLENDİRME", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialog == DialogResult.No)
                    {
                        uctekilf = 0;
                        islemmm = "SAT Ön Onaylama İşlemi: ONAYLANDI Teklifsiz SAT aşamasında Beklemede.";

                        SatIslemAdimlari satIslem = new SatIslemAdimlari(benzersiz, islemmm, islemyapan, DateTime.Now);
                        satIslemAdimlariManager.Add(satIslem);
                    }
                }
                if (satbirim == "BSRN GN.MDL.SATIN ALMA")
                {
                    satDataGridview1Manager.SatFirmaBilgisiGuncelle(benzersiz);
                }
                //DosyaAdiDegistir();
                satDataGridview1Manager.DurumGuncelleOnay(benzersiz);
                if (satbirim == "BSRN GN.MDL.SATIN ALMA")
                {
                    uctekilf = 1;
                    satDataGridview1Manager.SatDurumGnlMdr(benzersiz);
                    islemmm = "SAT Ön Onaylama İşlemi: ONAYLANDI TEKLİF ALINACAK SAT/FİYAT TEKLİFLERİ aşamasında Beklemede.";

                    SatIslemAdimlari satIslem = new SatIslemAdimlari(benzersiz, islemmm, islemyapan, DateTime.Now);
                    satIslemAdimlariManager.Add(satIslem);
                }
                dataGridview1 = null;
                dataGridview1 = new SatDataGridview1(satNo, CmbButceKodu.Text, CmbSatBirim.Text, CmbHarcamaTuru.Text, CmbFaturaFirma.Text, CmbIlgiliKisi.Text, CmbMasYeri.Text, benzersiz, uctekilf, dosya2, "");
                mesaj = satDataGridview1Manager.Update(dataGridview1);

                if (mesaj != " SAT Ön Onay İşlemi Başarıyla Tamamlandı.")
                {
                    MessageBox.Show(mesaj);
                    return;
                }
                DtgSatOnOnayDisplay();
                Temizle();
                webBrowser2.Navigate("");


                /*SatDataGridview1 satDataGridview1 = new SatDataGridview1(CmbButceKodu.Text, CmbSatBirim.Text, CmbHarcamaTuru.Text, CmbFaturaFirma.Text, CmbIlgiliKisi.Text,
                    CmbMasYeri.Text);
                string control = satDataGridview1Manager.SatGuncelle2(satDataGridview1,benzersiz);
                
                if (control!="OK")
                {
                    MessageBox.Show(control);
                }
                string islem = "SAT Talebi Güncellenmiştir.";
                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(benzersiz, islem, islemyapan, DateTime.Now);
                satIslemAdimlariManager.Add(satIslemAdimlari);
                MessageBox.Show(formno + " Nolu SAT Kaydınız Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle2();
                DtgSatOnOnayDisplay();
                webBrowser2.Navigate("");*/
            }


        }
        private void DtgSatOnOnay_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Filter = DtgSatOnOnay.FilterString;
            TxtTop2.Text = DtgSatOnOnay.RowCount.ToString();
        }
        private void DtgSatOnOnay_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Sort = DtgSatOlusturan.SortString;
        }

        //////////////////////////////////////////////////////////// SAYFA 3 ////////////////////////////////////////////////////////////////

        void CmbDuzenle(params ComboBox[] cmbArray)
        {
            foreach (ComboBox item in cmbArray)
            {
                item.DataSource = supplierNames.Select(x => x).ToList();
                item.SelectedIndex = -1;
            }
        }
        void CmbClearDataSource(params ComboBox[] cmbArray)
        {
            foreach (ComboBox item in cmbArray)
            {
                item.DataSource = null;
            }
        }
        private void DtgTeklifAl_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder3.Sort = DtgTeklifAl.SortString;
        }
        private void DtgTeklifAl_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder3.Filter = DtgTeklifAl.FilterString;
            TxtTop3.Text = DtgTeklifAl.RowCount.ToString();
        }
        void TedarikciFirmaName()
        {
            List<TeklifFirmalar> supplierList = teklifFirmalarManager.TedarikciFirmalar(false);
            supplierNames = supplierList.Select(x => x.Firmaname).ToList();

            CmbClearDataSource(BF1, BF2, BF3, BF4, BF5, BF6, BF7, BF8, BF9, BF10, IF1, IF2, IF3, IF4, IF5, IF6, IF7, IF8, IF9, IF10, UF1, UF2, UF3, UF4, UF5, UF6, UF7, UF8, UF9, UF10);

            if (malzemesayisi > 0)
            {
                CmbDuzenle(BF1, IF1, UF1);
            }
            if (malzemesayisi > 1)
            {
                CmbDuzenle(BF2, IF2, UF2);
            }
            if (malzemesayisi > 2)
            {
                CmbDuzenle(BF3, IF3, UF3);
            }
            if (malzemesayisi > 3)
            {
                CmbDuzenle(BF4, IF4, UF4);
            }
            if (malzemesayisi > 4)
            {
                CmbDuzenle(BF5, IF5, UF5);
            }
            if (malzemesayisi > 5)
            {
                CmbDuzenle(BF6, IF6, UF6);
            }
            if (malzemesayisi > 6)
            {
                CmbDuzenle(BF7, IF7, UF7);
            }
            if (malzemesayisi > 7)
            {
                CmbDuzenle(BF8, IF8, UF8);
            }
            if (malzemesayisi > 8)
            {
                CmbDuzenle(BF9, IF9, UF9);
            }
            if (malzemesayisi > 9)
            {
                CmbDuzenle(BF10, IF10, UF10);
            }
        }
        void DtgTeklifAlDisplay()
        {
            satDatas3 = satDataGridview1Manager.SatGuncelleUcTeklifList();
            dataBinder3.DataSource = satDatas3.ToDataTable();
            DtgTeklifAl.DataSource = dataBinder3;

            DtgTeklifAl.Columns["Id"].Visible = false;
            DtgTeklifAl.Columns["PersonelId"].Visible = false;
            DtgTeklifAl.Columns["Satno"].HeaderText = "SAT NO";
            DtgTeklifAl.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgTeklifAl.Columns["Talepeden"].HeaderText = "İSTEKTE BULUNAN";
            DtgTeklifAl.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgTeklifAl.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgTeklifAl.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgTeklifAl.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgTeklifAl.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgTeklifAl.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgTeklifAl.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgTeklifAl.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgTeklifAl.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgTeklifAl.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgTeklifAl.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgTeklifAl.Columns["Uctekilf"].Visible = false;
            DtgTeklifAl.Columns["SiparisNo"].Visible = false;
            DtgTeklifAl.Columns["DosyaYolu"].Visible = false;

        }
        private void DtgTeklifAl_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgTeklifAl.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }

            benzersiz3 = DtgTeklifAl.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosya3 = DtgTeklifAl.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            satno3 = DtgTeklifAl.CurrentRow.Cells["Satno"].Value.ToString();

            teklifiAlinans = teklifiAlinanManager.GetList(benzersiz3);
            malzemesayisi = teklifiAlinans.Count;
            TedarikciFirmaName();
            FillTools3();
            webBrowser4.Navigate(dosya3);
        }
        void FillTools3()
        {
            Temizle3();
            if (teklifiAlinans == null)

            {
                return;
            }
            if (teklifiAlinans.Count == 0)
            {
                return;
            }
            if (teklifiAlinans.Count > 0)
            {
                TeklifAlinan item = teklifiAlinans[0];
                s1.Text = item.StokNo;
                tt1.Text = item.Tanim;
                mm1.Text = item.Miktar.ToString();
                bb1.Text = item.Birim;
                BF1.Text = item.Firma1;
                IF1.Text = item.Firma2;
                UF1.Text = item.Firma3;
            }
            if (teklifiAlinans.Count > 1)
            {
                TeklifAlinan item = teklifiAlinans[1];
                s2.Text = item.StokNo;
                tt2.Text = item.Tanim;
                mm2.Text = item.Miktar.ToString();
                bb2.Text = item.Birim;
                BF2.Text = item.Firma1;
                IF2.Text = item.Firma2;
                UF2.Text = item.Firma3;
            }
            if (teklifiAlinans.Count > 2)
            {
                TeklifAlinan item = teklifiAlinans[2];
                s3.Text = item.StokNo;
                tt3.Text = item.Tanim;
                mm3.Text = item.Miktar.ToString();
                bb3.Text = item.Birim;
                BF3.Text = item.Firma1;
                IF3.Text = item.Firma2;
                UF3.Text = item.Firma3;
            }
            if (teklifiAlinans.Count > 3)
            {
                TeklifAlinan item = teklifiAlinans[3];
                s4.Text = item.StokNo;
                tt4.Text = item.Tanim;
                mm4.Text = item.Miktar.ToString();
                bb4.Text = item.Birim;
                BF4.Text = item.Firma1;
                IF4.Text = item.Firma2;
                UF4.Text = item.Firma3;
            }
            if (teklifiAlinans.Count > 4)
            {
                TeklifAlinan item = teklifiAlinans[4];
                s5.Text = item.StokNo;
                tt5.Text = item.Tanim;
                mm5.Text = item.Miktar.ToString();
                bb5.Text = item.Birim;
                BF5.Text = item.Firma1;
                IF5.Text = item.Firma2;
                UF5.Text = item.Firma3;
            }
            if (teklifiAlinans.Count > 5)
            {
                TeklifAlinan item = teklifiAlinans[5];
                s6.Text = item.StokNo;
                tt6.Text = item.Tanim;
                mm6.Text = item.Miktar.ToString();
                bb6.Text = item.Birim;
                BF6.Text = item.Firma1;
                IF6.Text = item.Firma2;
                UF6.Text = item.Firma3;
            }
            if (teklifiAlinans.Count > 6)
            {
                TeklifAlinan item = teklifiAlinans[6];
                s7.Text = item.StokNo;
                tt7.Text = item.Tanim;
                mm7.Text = item.Miktar.ToString();
                bb7.Text = item.Birim;
                BF7.Text = item.Firma1;
                IF7.Text = item.Firma2;
                UF7.Text = item.Firma3;
            }
            if (teklifiAlinans.Count > 7)
            {
                TeklifAlinan item = teklifiAlinans[7];
                s8.Text = item.StokNo;
                tt8.Text = item.Tanim;
                mm8.Text = item.Miktar.ToString();
                bb8.Text = item.Birim;
                BF8.Text = item.Firma1;
                IF8.Text = item.Firma2;
                UF8.Text = item.Firma3;
            }
            if (teklifiAlinans.Count > 8)
            {
                TeklifAlinan item = teklifiAlinans[8];
                s9.Text = item.StokNo;
                tt9.Text = item.Tanim;
                mm9.Text = item.Miktar.ToString();
                bb9.Text = item.Birim;
                BF9.Text = item.Firma1;
                IF9.Text = item.Firma2;
                UF9.Text = item.Firma3;
            }
            if (teklifiAlinans.Count > 9)
            {
                TeklifAlinan item = teklifiAlinans[9];
                s10.Text = item.StokNo;
                tt10.Text = item.Tanim;
                mm10.Text = item.Miktar.ToString();
                bb10.Text = item.Birim;
                BF10.Text = item.Firma1;
                IF10.Text = item.Firma2;
                UF10.Text = item.Firma3;
            }

        }
        void Temizle3()
        {
            s1.Clear(); tt1.Clear(); mm1.Clear(); bb1.Clear(); BF1.Text = ""; IF1.Text = ""; UF1.Text = "";
            s2.Clear(); tt2.Clear(); mm2.Clear(); bb2.Clear(); BF2.Text = ""; IF2.Text = ""; UF2.Text = "";
            s3.Clear(); tt3.Clear(); mm3.Clear(); bb3.Clear(); BF3.Text = ""; IF3.Text = ""; UF3.Text = "";
            s4.Clear(); tt4.Clear(); mm4.Clear(); bb4.Clear(); BF4.Text = ""; IF4.Text = ""; UF4.Text = "";
            s5.Clear(); tt5.Clear(); mm5.Clear(); bb5.Clear(); BF5.Text = ""; IF5.Text = ""; UF5.Text = "";
            s6.Clear(); tt6.Clear(); mm6.Clear(); bb6.Clear(); BF6.Text = ""; IF6.Text = ""; UF6.Text = "";
            s7.Clear(); tt7.Clear(); mm7.Clear(); bb7.Clear(); BF7.Text = ""; IF7.Text = ""; UF7.Text = "";
            s8.Clear(); tt8.Clear(); mm8.Clear(); bb8.Clear(); BF8.Text = ""; IF8.Text = ""; UF8.Text = "";
            s9.Clear(); tt9.Clear(); mm9.Clear(); bb9.Clear(); BF9.Text = ""; IF9.Text = ""; UF9.Text = "";
            s10.Clear(); tt10.Clear(); mm10.Clear(); bb10.Clear(); BF10.Text = ""; IF10.Text = ""; UF10.Text = "";
            webBrowser4.Navigate("");

        }
        private string FirmaControl()
        {
            if (malzemesayisi == 0)
            {
                return messege = "Malzeme Bulunamadı.";
            }
            if (malzemesayisi > 0)
            {
                if (BF1.Text == IF1.Text || BF1.Text == UF1.Text || IF1.Text == UF1.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 1)
            {
                if (BF2.Text == IF2.Text || BF2.Text == UF2.Text || IF2.Text == UF2.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 2)
            {
                if (BF3.Text == IF3.Text || BF3.Text == UF3.Text || IF3.Text == UF3.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 3)
            {
                if (BF4.Text == IF4.Text || BF4.Text == UF4.Text || IF4.Text == UF4.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 4)
            {
                if (BF4.Text == IF4.Text || BF4.Text == UF4.Text || IF4.Text == UF4.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 5)
            {
                if (BF5.Text == IF5.Text || BF5.Text == UF5.Text || IF5.Text == UF5.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 6)
            {
                if (BF6.Text == IF6.Text || BF6.Text == UF6.Text || IF6.Text == UF6.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 7)
            {
                if (BF7.Text == IF7.Text || BF7.Text == UF7.Text || IF7.Text == UF7.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 8)
            {
                if (BF8.Text == IF8.Text || BF8.Text == UF8.Text || IF8.Text == UF8.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 9)
            {
                if (BF9.Text == IF9.Text || BF9.Text == UF9.Text || IF9.Text == UF9.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 10)
            {
                if (BF10.Text == IF10.Text || BF10.Text == UF10.Text || IF10.Text == UF10.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            return messege = "OK";
        }
        private void BtnGuncelle3_Click(object sender, EventArgs e)
        {

            if (DtgTeklifAl.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            DialogResult dr = MessageBox.Show(satno3 + " Nolu SAT Kaydınızı Güncellemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                FirmaControl();
                if (messege != "OK")
                {
                    MessageBox.Show(messege, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<TeklifAlinan> list = new List<TeklifAlinan>();

                if (s1.Text.Trim() != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(BF1.Text, IF1.Text, UF1.Text, s1.Text);
                    list.Add(teklifAlinan);
                }
                if (s2.Text.Trim() != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(BF2.Text, IF2.Text, UF2.Text, s2.Text);
                    list.Add(teklifAlinan);
                }
                if (s3.Text.Trim() != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(BF3.Text, IF3.Text, UF3.Text, s3.Text);
                    list.Add(teklifAlinan);
                }
                if (s4.Text.Trim() != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(BF4.Text, IF4.Text, UF4.Text, s4.Text);
                    list.Add(teklifAlinan);
                }
                if (s5.Text.Trim() != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(BF5.Text, IF5.Text, UF5.Text, s5.Text);
                    list.Add(teklifAlinan);
                }
                if (s6.Text.Trim() != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(BF6.Text, IF6.Text, UF6.Text, s6.Text);
                    list.Add(teklifAlinan);
                }
                if (s7.Text.Trim() != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(BF7.Text, IF7.Text, UF7.Text, s7.Text);
                    list.Add(teklifAlinan);
                }
                if (s8.Text.Trim() != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(BF8.Text, IF8.Text, UF8.Text, s8.Text);
                    list.Add(teklifAlinan);
                }
                if (s9.Text.Trim() != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(BF9.Text, IF9.Text, UF9.Text, s9.Text);
                    list.Add(teklifAlinan);
                }
                if (s10.Text.Trim() != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(BF10.Text, IF10.Text, UF10.Text, s10.Text);
                    list.Add(teklifAlinan);
                }
                if (list.Count == 0)
                {
                    MessageBox.Show("Eleman Bulunamadı");
                    return;
                }
                foreach (TeklifAlinan item in list)
                {
                    teklifiAlinanManager.FirmaGuncelle(item, benzersiz3);
                }
                string islem = "Firma Bilgileri Güncellendi.";
                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(benzersiz3, islem, islemyapan, DateTime.Now);
                satIslemAdimlariManager.Add(satIslemAdimlari);
                MessageBox.Show(satno3 + " Nolu SAT Kaydınız Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DtgTeklifAlDisplay();
                Temizle3();
            }
        }

        void DtgSatListDisplay()
        {
            satDatas4 = satDataGridview1Manager.SatGuncelleTeklifler();
            dataBinder4.DataSource = satDatas4.ToDataTable();
            DtgSatList.DataSource = dataBinder4;

            DtgSatList.Columns["Id"].Visible = false;
            DtgSatList.Columns["PersonelId"].Visible = false;
            DtgSatList.Columns["Satno"].HeaderText = "SAT NO";
            DtgSatList.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgSatList.Columns["Talepeden"].HeaderText = "İSTEKTE BULUNAN";
            DtgSatList.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgSatList.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgSatList.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgSatList.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgSatList.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgSatList.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgSatList.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgSatList.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgSatList.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgSatList.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgSatList.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgSatList.Columns["Uctekilf"].Visible = false;
            DtgSatList.Columns["SiparisNo"].Visible = false;
            DtgSatList.Columns["DosyaYolu"].Visible = false;

        }
        private void DtgSatList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder4.Filter = DtgSatList.FilterString;
            TxtTop4.Text = DtgSatList.RowCount.ToString();
        }
        private void DtgSatList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder4.Sort = DtgSatList.SortString;
        }
        int teklifdurumu = -1;
        string belgeTuru = "";
        private void DtgSatList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgSatList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }

            benzersiz4 = DtgSatList.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosya4 = DtgSatList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            satno4 = DtgSatList.CurrentRow.Cells["Satno"].Value.ToString();
            teklifdurumu = DtgSatList.CurrentRow.Cells["Uctekilf"].Value.ConInt();
            belgeTuru = DtgSatList.CurrentRow.Cells["BelgeTuru"].Value.ToString();

            string usBolgesi= DtgSatList.CurrentRow.Cells["Usbolgesi"].Value.ToString();
            SatTalebiDoldur satTalebiDoldur = satTalebiDoldurManager.Get(usBolgesi);
            if (satTalebiDoldur==null)
            {
                return;
            }
            TxtProjeG.Text = satTalebiDoldur.Proje;
            //FillToolsTeklifsiz();

            fiyatTeklifiAls = fiyatTeklifiAlManager.GetList("Gönderildi", benzersiz4);
            FillTools4();

            webBrowser5.Navigate(dosya4);

        }

        private void FillTools4()
        {
            Temizle4();

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
                sto1.Text = item.Stokno;
                ttt1.Text = item.Tanim;
                mmm1.Text = item.Miktar.ToString();
                bbb1.Text = item.Birim;
                F1_1.Text = item.Firma1;
                BBF1.Text = item.Bbf.ToString();
                BT1.Text = item.Btf.ToString();
                F2_1.Text = item.Firma2;
                IBF1.Text = item.Ibf.ToString();
                IT1.Text = item.Itf.ToString();
                F3_1.Text = item.Firma3;
                UBF1.Text = item.Ubf.ToString();
                UT1.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 1)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[1];
                sto2.Text = item.Stokno;
                ttt2.Text = item.Tanim;
                mmm2.Text = item.Miktar.ToString();
                bbb2.Text = item.Birim;
                F1_2.Text = item.Firma1;
                BBF2.Text = item.Bbf.ToString();
                BT2.Text = item.Btf.ToString();
                F2_2.Text = item.Firma2;
                IBF2.Text = item.Ibf.ToString();
                IT2.Text = item.Itf.ToString();
                F3_2.Text = item.Firma3;
                UBF2.Text = item.Ubf.ToString();
                UT2.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 2)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[2];
                sto3.Text = item.Stokno;
                ttt3.Text = item.Tanim;
                mmm3.Text = item.Miktar.ToString();
                bbb3.Text = item.Birim;
                F1_3.Text = item.Firma1;
                BBF3.Text = item.Bbf.ToString();
                BT3.Text = item.Btf.ToString();
                F2_3.Text = item.Firma2;
                IBF3.Text = item.Ibf.ToString();
                IT3.Text = item.Itf.ToString();
                F3_3.Text = item.Firma3;
                UBF3.Text = item.Ubf.ToString();
                UT3.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 3)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[3];
                sto4.Text = item.Stokno;
                ttt4.Text = item.Tanim;
                mmm4.Text = item.Miktar.ToString();
                bbb4.Text = item.Birim;
                F1_4.Text = item.Firma1;
                BBF4.Text = item.Bbf.ToString();
                BT4.Text = item.Btf.ToString();
                F2_4.Text = item.Firma2;
                IBF4.Text = item.Ibf.ToString();
                IT4.Text = item.Itf.ToString();
                F3_4.Text = item.Firma3;
                UBF4.Text = item.Ubf.ToString();
                UT4.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 4)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[4];
                sto5.Text = item.Stokno;
                ttt5.Text = item.Tanim;
                mmm5.Text = item.Miktar.ToString();
                bbb5.Text = item.Birim;
                F1_5.Text = item.Firma1;
                BBF5.Text = item.Bbf.ToString();
                BT5.Text = item.Btf.ToString();
                F2_5.Text = item.Firma2;
                IBF5.Text = item.Ibf.ToString();
                IT5.Text = item.Itf.ToString();
                F3_5.Text = item.Firma3;
                UBF5.Text = item.Ubf.ToString();
                UT5.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 5)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[5];
                sto6.Text = item.Stokno;
                ttt6.Text = item.Tanim;
                mmm6.Text = item.Miktar.ToString();
                bbb6.Text = item.Birim;
                F1_6.Text = item.Firma1;
                BBF6.Text = item.Bbf.ToString();
                BT6.Text = item.Btf.ToString();
                F2_6.Text = item.Firma2;
                IBF6.Text = item.Ibf.ToString();
                IT6.Text = item.Itf.ToString();
                F3_6.Text = item.Firma3;
                UBF6.Text = item.Ubf.ToString();
                UT6.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 6)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[6];
                sto7.Text = item.Stokno;
                ttt7.Text = item.Tanim;
                mmm7.Text = item.Miktar.ToString();
                bbb7.Text = item.Birim;
                F1_7.Text = item.Firma1;
                BBF7.Text = item.Bbf.ToString();
                BT7.Text = item.Btf.ToString();
                F2_7.Text = item.Firma2;
                IBF7.Text = item.Ibf.ToString();
                IT7.Text = item.Itf.ToString();
                F3_7.Text = item.Firma3;
                UBF7.Text = item.Ubf.ToString();
                UT7.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 7)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[7];
                sto8.Text = item.Stokno;
                ttt8.Text = item.Tanim;
                mmm8.Text = item.Miktar.ToString();
                bbb8.Text = item.Birim;
                F1_8.Text = item.Firma1;
                BBF8.Text = item.Bbf.ToString();
                BT8.Text = item.Btf.ToString();
                F2_8.Text = item.Firma2;
                IBF8.Text = item.Ibf.ToString();
                IT8.Text = item.Itf.ToString();
                F3_8.Text = item.Firma3;
                UBF8.Text = item.Ubf.ToString();
                UT8.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 8)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[8];
                sto9.Text = item.Stokno;
                ttt9.Text = item.Tanim;
                mmm9.Text = item.Miktar.ToString();
                bbb9.Text = item.Birim;
                F1_9.Text = item.Firma1;
                BBF9.Text = item.Bbf.ToString();
                BT9.Text = item.Btf.ToString();
                F2_9.Text = item.Firma2;
                IBF9.Text = item.Ibf.ToString();
                IT9.Text = item.Itf.ToString();
                F3_9.Text = item.Firma3;
                UBF9.Text = item.Ubf.ToString();
                UT9.Text = item.Utf.ToString();
            }
            if (fiyatTeklifiAls.Count > 9)
            {
                FiyatTeklifiAl item = fiyatTeklifiAls[9];
                sto10.Text = item.Stokno;
                ttt10.Text = item.Tanim;
                mmm10.Text = item.Miktar.ToString();
                bbb10.Text = item.Birim;
                F1_10.Text = item.Firma1;
                BBF10.Text = item.Bbf.ToString();
                BT10.Text = item.Btf.ToString();
                F2_10.Text = item.Firma2;
                IBF10.Text = item.Ibf.ToString();
                IT10.Text = item.Itf.ToString();
                F3_10.Text = item.Firma3;
                UBF10.Text = item.Ubf.ToString();
                UT10.Text = item.Utf.ToString();
            }
        }
        void Temizle4()
        {
            sto1.Clear(); ttt1.Clear(); mmm1.Clear(); bbb1.Clear(); F1_1.Clear(); BBF1.Clear(); BT1.Clear(); F2_1.Clear(); IBF1.Clear(); IT1.Clear(); F3_1.Clear(); UBF1.Clear(); UT1.Clear();
            sto2.Clear(); ttt2.Clear(); mmm2.Clear(); bbb2.Clear(); F1_2.Clear(); BBF2.Clear(); BT2.Clear(); F2_2.Clear(); IBF2.Clear(); IT2.Clear(); F3_2.Clear(); UBF2.Clear(); UT2.Clear();
            sto3.Clear(); ttt3.Clear(); mmm3.Clear(); bbb3.Clear(); F1_3.Clear(); BBF3.Clear(); BT3.Clear(); F2_3.Clear(); IBF3.Clear(); IT3.Clear(); F3_3.Clear(); UBF3.Clear(); UT3.Clear();
            sto4.Clear(); ttt4.Clear(); mmm4.Clear(); bbb4.Clear(); F1_4.Clear(); BBF4.Clear(); BT4.Clear(); F2_4.Clear(); IBF4.Clear(); IT4.Clear(); F3_4.Clear(); UBF4.Clear(); UT4.Clear();
            sto5.Clear(); ttt5.Clear(); mmm5.Clear(); bbb5.Clear(); F1_5.Clear(); BBF5.Clear(); BT5.Clear(); F2_5.Clear(); IBF5.Clear(); IT5.Clear(); F3_5.Clear(); UBF5.Clear(); UT5.Clear();
            sto6.Clear(); ttt6.Clear(); mmm6.Clear(); bbb6.Clear(); F1_6.Clear(); BBF6.Clear(); BT6.Clear(); F2_6.Clear(); IBF6.Clear(); IT6.Clear(); F3_6.Clear(); UBF6.Clear(); UT6.Clear();
            sto7.Clear(); ttt7.Clear(); mmm7.Clear(); bbb7.Clear(); F1_7.Clear(); BBF7.Clear(); BT7.Clear(); F2_7.Clear(); IBF7.Clear(); IT7.Clear(); F3_7.Clear(); UBF7.Clear(); UT7.Clear();
            sto8.Clear(); ttt8.Clear(); mmm8.Clear(); bbb8.Clear(); F1_8.Clear(); BBF8.Clear(); BT8.Clear(); F2_8.Clear(); IBF8.Clear(); IT8.Clear(); F3_8.Clear(); UBF8.Clear(); UT8.Clear();
            sto9.Clear(); ttt9.Clear(); mmm9.Clear(); bbb9.Clear(); F1_9.Clear(); BBF9.Clear(); BT9.Clear(); F2_9.Clear(); IBF9.Clear(); IT9.Clear(); F3_9.Clear(); UBF9.Clear(); UT9.Clear();
            sto10.Clear(); ttt10.Clear(); mmm10.Clear(); bbb10.Clear(); F1_10.Clear(); BBF10.Clear(); BT10.Clear(); F2_10.Clear(); IBF10.Clear(); IT10.Clear(); F3_10.Clear(); UBF10.Clear(); UT10.Clear();
            webBrowser5.Navigate("");
        }
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

        #region TOPLAMTUTARHESAPLA
        private void BBF1_TextChanged(object sender, EventArgs e)
        {
            BT1.Text = TopFiyatHesapla(BBF1.Text, mmm1.Text);
        }

        private void BBF2_TextChanged(object sender, EventArgs e)
        {
            BT2.Text = TopFiyatHesapla(BBF2.Text, mmm2.Text);
        }

        private void BBF3_TextChanged(object sender, EventArgs e)
        {
            BT3.Text = TopFiyatHesapla(BBF3.Text, mmm3.Text);
        }

        private void BBF4_TextChanged(object sender, EventArgs e)
        {
            BT4.Text = TopFiyatHesapla(BBF4.Text, mmm4.Text);
        }

        private void BBF5_TextChanged(object sender, EventArgs e)
        {
            BT5.Text = TopFiyatHesapla(BBF5.Text, mmm5.Text);
        }

        private void BBF6_TextChanged(object sender, EventArgs e)
        {
            BT6.Text = TopFiyatHesapla(BBF6.Text, mmm6.Text);
        }

        private void BBF7_TextChanged(object sender, EventArgs e)
        {
            BT7.Text = TopFiyatHesapla(BBF7.Text, mmm7.Text);
        }

        private void BBF8_TextChanged(object sender, EventArgs e)
        {
            BT8.Text = TopFiyatHesapla(BBF8.Text, mmm8.Text);
        }

        private void BBF9_TextChanged(object sender, EventArgs e)
        {
            BT9.Text = TopFiyatHesapla(BBF9.Text, mmm9.Text);
        }

        private void BBF10_TextChanged(object sender, EventArgs e)
        {
            BT10.Text = TopFiyatHesapla(BBF10.Text, mmm10.Text);
        }

        private void IBF1_TextChanged(object sender, EventArgs e)
        {
            IT1.Text = TopFiyatHesapla(IBF1.Text, mmm1.Text);
        }

        private void IBF2_TextChanged(object sender, EventArgs e)
        {
            IT2.Text = TopFiyatHesapla(IBF2.Text, mmm2.Text);
        }

        private void IBF3_TextChanged(object sender, EventArgs e)
        {
            IT3.Text = TopFiyatHesapla(IBF3.Text, mmm3.Text);
        }

        private void IBF4_TextChanged(object sender, EventArgs e)
        {
            IT4.Text = TopFiyatHesapla(IBF4.Text, mmm4.Text);
        }

        private void IBF5_TextChanged(object sender, EventArgs e)
        {
            IT5.Text = TopFiyatHesapla(IBF5.Text, mmm5.Text);
        }

        private void IBF6_TextChanged(object sender, EventArgs e)
        {
            IT6.Text = TopFiyatHesapla(IBF6.Text, mmm6.Text);
        }

        private void IBF7_TextChanged(object sender, EventArgs e)
        {
            IT7.Text = TopFiyatHesapla(IBF7.Text, mmm7.Text);
        }

        private void IBF8_TextChanged(object sender, EventArgs e)
        {
            IT8.Text = TopFiyatHesapla(IBF8.Text, mmm8.Text);
        }

        private void IBF9_TextChanged(object sender, EventArgs e)
        {
            IT9.Text = TopFiyatHesapla(IBF9.Text, mmm9.Text);
        }

        private void IBF10_TextChanged(object sender, EventArgs e)
        {
            IT10.Text = TopFiyatHesapla(IBF10.Text, mmm10.Text);
        }

        private void UBF1_TextChanged(object sender, EventArgs e)
        {
            UT1.Text = TopFiyatHesapla(UBF1.Text, mmm1.Text);
        }

        private void UBF2_TextChanged(object sender, EventArgs e)
        {
            UT2.Text = TopFiyatHesapla(UBF2.Text, mmm2.Text);
        }

        private void UBF3_TextChanged(object sender, EventArgs e)
        {
            UT3.Text = TopFiyatHesapla(UBF3.Text, mmm3.Text);
        }

        private void UBF4_TextChanged(object sender, EventArgs e)
        {
            UT4.Text = TopFiyatHesapla(UBF4.Text, mmm4.Text);
        }

        private void UBF5_TextChanged(object sender, EventArgs e)
        {
            UT5.Text = TopFiyatHesapla(UBF5.Text, mmm5.Text);
        }

        private void UBF6_TextChanged(object sender, EventArgs e)
        {
            UT6.Text = TopFiyatHesapla(UBF6.Text, mmm6.Text);
        }

        private void UBF7_TextChanged(object sender, EventArgs e)
        {
            UT7.Text = TopFiyatHesapla(UBF7.Text, mmm7.Text);
        }

        private void BT1_TextChanged(object sender, EventArgs e)
        {
            if (BT1.Text == "")
            {
                x1 = 0;
                GenelToplam1();
                return;
            }
            x1 = BT1.Text.ConDouble();
            GenelToplam1();
        }

        private void BT2_TextChanged(object sender, EventArgs e)
        {
            if (BT2.Text == "")
            {
                x2 = 0;
                GenelToplam1();
                return;
            }
            x2 = BT2.Text.ConDouble();
            GenelToplam1();
        }

        private void BT3_TextChanged(object sender, EventArgs e)
        {
            if (BT3.Text == "")
            {
                x3 = 0;
                GenelToplam1();
                return;
            }
            x3 = BT3.Text.ConDouble();
            GenelToplam1();
        }

        private void BT4_TextChanged(object sender, EventArgs e)
        {
            if (BT4.Text == "")
            {
                x4 = 0;
                GenelToplam1();
                return;
            }
            x4 = BT4.Text.ConDouble();
            GenelToplam1();
        }

        private void BT5_TextChanged(object sender, EventArgs e)
        {
            if (BT5.Text == "")
            {
                x5 = 0;
                GenelToplam1();
                return;
            }
            x5 = BT5.Text.ConDouble();
            GenelToplam1();
        }

        private void BT6_TextChanged(object sender, EventArgs e)
        {
            if (BT6.Text == "")
            {
                x6 = 0;
                GenelToplam1();
                return;
            }
            x6 = BT6.Text.ConDouble();
            GenelToplam1();
        }

        private void BT7_TextChanged(object sender, EventArgs e)
        {
            if (BT7.Text == "")
            {
                x7 = 0;
                GenelToplam1();
                return;
            }
            x7 = BT7.Text.ConDouble();
            GenelToplam1();
        }

        private void BT8_TextChanged(object sender, EventArgs e)
        {
            if (BT8.Text == "")
            {
                x8 = 0;
                GenelToplam1();
                return;
            }
            x8 = BT8.Text.ConDouble();
            GenelToplam1();
        }

        private void BT9_TextChanged(object sender, EventArgs e)
        {
            if (BT9.Text == "")
            {
                x9 = 0;
                GenelToplam1();
                return;
            }
            x9 = BT9.Text.ConDouble();
            GenelToplam1();
        }

        private void BT10_TextChanged(object sender, EventArgs e)
        {
            if (BT10.Text == "")
            {
                x10 = 0;
                GenelToplam1();
                return;
            }
            x10 = BT10.Text.ConDouble();
            GenelToplam1();
        }

        private void IT1_TextChanged(object sender, EventArgs e)
        {
            if (IT1.Text == "")
            {
                y1 = 0;
                GenelToplam2();
                return;
            }
            y1 = IT1.Text.ConDouble();
            GenelToplam2();
        }

        private void IT2_TextChanged(object sender, EventArgs e)
        {
            if (IT2.Text == "")
            {
                y2 = 0;
                GenelToplam2();
                return;
            }
            y2 = IT2.Text.ConDouble();
            GenelToplam2();
        }

        private void IT3_TextChanged(object sender, EventArgs e)
        {
            if (IT3.Text == "")
            {
                y3 = 0;
                GenelToplam2();
                return;
            }
            y3 = IT3.Text.ConDouble();
            GenelToplam2();
        }

        private void IT4_TextChanged(object sender, EventArgs e)
        {
            if (IT4.Text == "")
            {
                y4 = 0;
                GenelToplam2();
                return;
            }
            y4 = IT4.Text.ConDouble();
            GenelToplam2();
        }

        private void IT5_TextChanged(object sender, EventArgs e)
        {
            if (IT5.Text == "")
            {
                y5 = 0;
                GenelToplam2();
                return;
            }
            y5 = IT5.Text.ConDouble();
            GenelToplam2();
        }

        private void IT6_TextChanged(object sender, EventArgs e)
        {
            if (IT6.Text == "")
            {
                y6 = 0;
                GenelToplam2();
                return;
            }
            y6 = IT6.Text.ConDouble();
            GenelToplam2();
        }

        private void IT7_TextChanged(object sender, EventArgs e)
        {
            if (IT7.Text == "")
            {
                y7 = 0;
                GenelToplam2();
                return;
            }
            y7 = IT7.Text.ConDouble();
            GenelToplam2();
        }

        private void IT8_TextChanged(object sender, EventArgs e)
        {
            if (IT8.Text == "")
            {
                y8 = 0;
                GenelToplam2();
                return;
            }
            y8 = IT8.Text.ConDouble();
            GenelToplam2();
        }

        private void IT9_TextChanged(object sender, EventArgs e)
        {
            if (IT9.Text == "")
            {
                y9 = 0;
                GenelToplam2();
                return;
            }
            y9 = IT9.Text.ConDouble();
            GenelToplam2();
        }

        private void IT10_TextChanged(object sender, EventArgs e)
        {
            if (IT10.Text == "")
            {
                y10 = 0;
                GenelToplam2();
                return;
            }
            y10 = IT10.Text.ConDouble();
            GenelToplam2();
        }

        private void UT1_TextChanged(object sender, EventArgs e)
        {
            if (UT1.Text == "")
            {
                z1 = 0;
                GenelToplam3();
                return;
            }
            z1 = UT1.Text.ConDouble();
            GenelToplam3();
        }

        private void UT2_TextChanged(object sender, EventArgs e)
        {
            if (UT2.Text == "")
            {
                z2 = 0;
                GenelToplam3();
                return;
            }
            z2 = UT2.Text.ConDouble();
            GenelToplam3();
        }

        private void UT3_TextChanged(object sender, EventArgs e)
        {
            if (UT3.Text == "")
            {
                z3 = 0;
                GenelToplam3();
                return;
            }
            z3 = UT3.Text.ConDouble();
            GenelToplam3();
        }

        private void UT4_TextChanged(object sender, EventArgs e)
        {
            if (UT4.Text == "")
            {
                z4 = 0;
                GenelToplam3();
                return;
            }
            z4 = UT4.Text.ConDouble();
            GenelToplam3();
        }

        private void UT5_TextChanged(object sender, EventArgs e)
        {
            if (UT5.Text == "")
            {
                z5 = 0;
                GenelToplam3();
                return;
            }
            z5 = UT5.Text.ConDouble();
            GenelToplam3();
        }

        private void UT6_TextChanged(object sender, EventArgs e)
        {
            if (UT6.Text == "")
            {
                z6 = 0;
                GenelToplam3();
                return;
            }
            z6 = UT6.Text.ConDouble();
            GenelToplam3();
        }

        private void UT7_TextChanged(object sender, EventArgs e)
        {
            if (UT7.Text == "")
            {
                z7 = 0;
                GenelToplam3();
                return;
            }
            z7 = UT7.Text.ConDouble();
            GenelToplam3();
        }

        private void UT8_TextChanged(object sender, EventArgs e)
        {
            if (UT8.Text == "")
            {
                z8 = 0;
                GenelToplam3();
                return;
            }
            z8 = UT8.Text.ConDouble();
            GenelToplam3();
        }

        private void UT9_TextChanged(object sender, EventArgs e)
        {
            if (UT9.Text == "")
            {
                z9 = 0;
                GenelToplam3();
                return;
            }
            z9 = UT9.Text.ConDouble();
            GenelToplam3();
        }

        private void UT10_TextChanged(object sender, EventArgs e)
        {
            if (UT10.Text == "")
            {
                z10 = 0;
                GenelToplam3();
                return;
            }
            z10 = UT10.Text.ConDouble();
            GenelToplam3();
        }

        private void UBF8_TextChanged(object sender, EventArgs e)
        {
            UT8.Text = TopFiyatHesapla(UBF8.Text, mmm8.Text);
        }

        private void UBF9_TextChanged(object sender, EventArgs e)
        {
            UT9.Text = TopFiyatHesapla(UBF9.Text, mmm9.Text);
        }

        private void UBF10_TextChanged(object sender, EventArgs e)
        {
            UT10.Text = TopFiyatHesapla(UBF10.Text, mmm10.Text);
        }
        #endregion

        #region KEYPRESS
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

        private void DtgStokList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgStokList.FilterString;
            TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
        }

        private void DtgStokList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgStokList.SortString;
        }

        List<DestekDepoCayOcagi> cayOcagiFiltired;
        List<DestekDepoElAletleri> elAletleriFiltired;
        List<DestekDepoIsGiysi> isgiysiFiltired;
        List<DestekDepoKirtasiye> kirtasiyeFiltired;
        List<DestekDepoKKD> kkdFiltired;
        List<DestekDepoAmbar> ambarFiltired;
        List<DestekDepoTemizlikUrunleri> temizlikUrunleriFitired;
        List<DestekDepoAmbar> destekDepoAmbars = new List<DestekDepoAmbar>();
        List<DestekDepoCayOcagi> cayOcagis = new List<DestekDepoCayOcagi>();
        List<DestekDepoElAletleri> elAletleris = new List<DestekDepoElAletleri>();
        List<DestekDepoIsGiysi> destekDepoIs = new List<DestekDepoIsGiysi>();
        List<DestekDepoKirtasiye> kirtasiyes = new List<DestekDepoKirtasiye>();
        List<DestekDepoKKD> kKDs = new List<DestekDepoKKD>();
        List<DestekDepoTemizlikUrunleri> temizlikUrunleris = new List<DestekDepoTemizlikUrunleri>();
        private void CmbMalzemeTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CmbMalzemeTuru.SelectedIndex;
            StokCek();
        }

        private void Usbolgesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            BildirimFromNo.Text = "";
            AbfFormNoList();
        }

        void AbfFormNoList()
        {
            BildirimFromNo.DataSource = satTalebiDoldurManager.BolgeSatList(Usbolgesi.Text);
            BildirimFromNo.ValueMember = "Id";
            BildirimFromNo.DisplayMember = "AbfNo";
            BildirimFromNo.SelectedValue = "";
        }
        void StokCek()
        {
            if (index == 0)
            {
                malzemeKayits = malzemeKayitManager.GetList();
                malzemesFiltered = malzemeKayits;
                dataBinder.DataSource = malzemeKayits.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (index == 1)
            {

                destekDepoAmbars = ambarManager.GetList();
                ambarFiltired = destekDepoAmbars;
                dataBinder.DataSource = destekDepoAmbars.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (index == 2)
            {

                cayOcagis = cayOcagiManager.GetList();
                cayOcagiFiltired = cayOcagis;
                dataBinder.DataSource = cayOcagis.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (index == 3)
            {

                elAletleris = elAletleriManager.GetList();
                elAletleriFiltired = elAletleris;
                dataBinder.DataSource = elAletleris.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (index == 4)
            {

                destekDepoIs = isGiysiManager.GetList();
                isgiysiFiltired = destekDepoIs;
                dataBinder.DataSource = destekDepoIs.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (index == 5)
            {

                kirtasiyes = kirtasiyeManager.GetList();
                kirtasiyeFiltired = kirtasiyes;
                dataBinder.DataSource = kirtasiyes.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (index == 6)
            {

                kKDs = kKDManager.GetList();
                kkdFiltired = kKDs;
                dataBinder.DataSource = kKDs.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                TxtGuncelStok.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (index == 7)
            {

                temizlikUrunleris = temizlikUrunleriManager.GetList();
                temizlikUrunleriFitired = temizlikUrunleris;
                dataBinder.DataSource = temizlikUrunleris.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                TxtTop.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
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

        private void IBF1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }



        private void UBF2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtGerekceBasaran_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnSatiGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Güncellemek İstediğinize Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                string mesaj = satDataGridview1Manager.SatFirmaGuncelle(benzersiz5, CmbProjeKodu.Text, TxtFirma.Text);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                CmbProjeKodu.SelectedValue = ""; TxtFirma.Clear();
                DtgSatListDisplay();
            }
        }

        private void BtnMailGuncelle_Click(object sender, EventArgs e)
        {

            string mesaj = satDataGridview1Manager.SatMilDurumGuncelle(benzersiz4, TxtProjeG.Text, CmbTeklifSiniri.Text, CmbMailDurumu.Text);
            if (mesaj!="OK")
            {
                MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Başarıyla Güncellendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void UBF3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF10_KeyPress(object sender, KeyPressEventArgs e)
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

        private void IT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IT2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IT3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IT4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IT5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IT6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IT7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IT8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IT9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IT10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        void GenelToplam1()
        {
            geneltop1 = x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9 + x10;

            GT1.Text = geneltop1.ToString("0.00") + " ₺";
        }
        void GenelToplam2()
        {
            geneltop2 = y1 + y2 + y3 + y4 + y5 + y6 + y7 + y8 + y9 + y10;

            GT2.Text = geneltop2.ToString("0.00") + " ₺";
        }
        void GenelToplam3()
        {
            geneltop3 = z1 + z2 + z3 + z4 + z5 + z6 + z7 + z8 + z9 + z10;

            GT3.Text = geneltop3.ToString("0.00") + " ₺";
        }
        string kaynakdosyaismi1, alinandosya1, yeniyol1, kaynakdosyaismi2, alinandosya2, yeniyol2, kaynakdosyaismi3, alinandosya3, yeniyol3;
        private void BtnDosyaEkleRedTekli_Click_1(object sender, EventArgs e)
        {
            if (!Directory.Exists(dosya5))
            {
                MessageBox.Show("Dosya Yolu Bulunamadı.");
                return;
            }
            if (openFileDosya1.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi1 = openFileDosya1.SafeFileName.ToString();
                alinandosya1 = openFileDosya1.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string dosyaismi = kaynakdosyaismi1;
            yeniyol1 = dosya5 + "\\" + dosyaismi;

            if (File.Exists(dosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + dosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya1, yeniyol1);
            }
            webBrowser8.Navigate(dosya5);
        }
        private void BtnDosyaEkleRedTeklifsiz_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(dosya4))
            {
                MessageBox.Show("Dosya Yolu Bulunamadı.");
                return;
            }
            if (openFileDosya1.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi1 = openFileDosya1.SafeFileName.ToString();
                alinandosya1 = openFileDosya1.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string dosyaismi = kaynakdosyaismi1;
            yeniyol1 = dosya4 + "\\" + dosyaismi;

            if (File.Exists(dosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + dosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya1, yeniyol1);
            }
            webBrowser7.Navigate(dosya4);

        }

        private void BtnDosyaEkle1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(dosya4))
            {
                MessageBox.Show("Dosya Yolu Bulunamadı.");
                return;
            }
            if (openFileDosya1.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi1 = openFileDosya1.SafeFileName.ToString();
                alinandosya1 = openFileDosya1.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string dosyaismi = " 1. Teklif " + kaynakdosyaismi1;
            yeniyol1 = dosya4 + "\\" + dosyaismi;

            if (File.Exists(dosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + dosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya1, yeniyol1);
                BtnDosyaEkle1.BackColor = Color.LightGreen;
            }
            webBrowser5.Navigate(dosya4);
        }

        private void BtnDosyaEkle2_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(dosya4))
            {
                MessageBox.Show("Dosya Yolu Bulunamadı.");
                return;
            }
            if (openFileDosya2.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi2 = openFileDosya2.SafeFileName.ToString();
                alinandosya2 = openFileDosya2.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string dosyaismi = " 2. Teklif " + kaynakdosyaismi2;
            yeniyol2 = dosya4 + "\\" + dosyaismi;

            if (File.Exists(dosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + dosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya2, yeniyol2);
                BtnDosyaEkle2.BackColor = Color.LightGreen;
            }
            webBrowser5.Navigate(dosya4);
        }

        private void BtnDosyaEkle3_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(dosya4))
            {
                MessageBox.Show("Dosya Yolu Bulunamadı.");
                return;
            }
            if (openFileDosya3.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi3 = openFileDosya3.SafeFileName.ToString();
                alinandosya3 = openFileDosya3.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string dosyaismi = " 3. Teklif " + kaynakdosyaismi2;
            yeniyol3 = dosya4 + "\\" + dosyaismi;

            if (File.Exists(dosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + dosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya3, yeniyol3);
                BtnDosyaEkle3.BackColor = Color.LightGreen;
            }
            webBrowser5.Navigate(dosya4);
        }
        private void BtnGuncelleTekli_Click(object sender, EventArgs e)
        {
            if (DtgSat.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            TeklifsizSat teklifsizSat = new TeklifsizSat("", "", 0, "", LblToplam.Text.ConDouble(), benzersiz5);
            string mesaj3 = teklifsizSatManager.Update(teklifsizSat, benzersiz5);
            if (mesaj3 != "OK")
            {
                MessageBox.Show(mesaj3, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DtgSatDisplay();
            LblToplam.Clear();

        }
        private void BtnGuncelleRedTeklifsiz_Click(object sender, EventArgs e)
        {
            if (DtgSatList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            DialogResult dr = MessageBox.Show(satno4 + " Nolu SAT Kaydınızı Güncellemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                List<TeklifsizSat> list = new List<TeklifsizSat>();
                if (StnTeklifsiz1.Text != "")
                {
                    TeklifsizSat teklifsizSat = new TeklifsizSat(StnTeklifsiz1.Text, TanimTeklifsiz1.Text, MiktarTeklifsiz1.Text.ConDouble(), BirimTeklifsiz1.Text, Tutar1.Text.ConDouble(), siparisNo);
                    list.Add(teklifsizSat);
                }
                if (StnTeklifsiz2.Text != "")
                {
                    TeklifsizSat teklifsizSat = new TeklifsizSat(StnTeklifsiz2.Text, TanimTeklifsiz2.Text, MiktarTeklifsiz2.Text.ConDouble(), BirimTeklifsiz2.Text, Tutar2.Text.ConDouble(), siparisNo);
                    list.Add(teklifsizSat);
                }
                if (StnTeklifsiz3.Text != "")
                {
                    TeklifsizSat teklifsizSat = new TeklifsizSat(StnTeklifsiz3.Text, TanimTeklifsiz3.Text, MiktarTeklifsiz3.Text.ConDouble(), BirimTeklifsiz3.Text, Tutar3.Text.ConDouble(), siparisNo);
                    list.Add(teklifsizSat);
                }
                if (StnTeklifsiz4.Text != "")
                {
                    TeklifsizSat teklifsizSat = new TeklifsizSat(StnTeklifsiz4.Text, TanimTeklifsiz4.Text, MiktarTeklifsiz4.Text.ConDouble(), BirimTeklifsiz4.Text, Tutar4.Text.ConDouble(), siparisNo);
                    list.Add(teklifsizSat);
                }
                if (StnTeklifsiz5.Text != "")
                {
                    TeklifsizSat teklifsizSat = new TeklifsizSat(StnTeklifsiz5.Text, TanimTeklifsiz5.Text, MiktarTeklifsiz5.Text.ConDouble(), BirimTeklifsiz5.Text, Tutar5.Text.ConDouble(), siparisNo);
                    list.Add(teklifsizSat);
                }
                if (StnTeklifsiz6.Text != "")
                {
                    TeklifsizSat teklifsizSat = new TeklifsizSat(StnTeklifsiz6.Text, TanimTeklifsiz6.Text, MiktarTeklifsiz6.Text.ConDouble(), BirimTeklifsiz6.Text, Tutar6.Text.ConDouble(), siparisNo);
                    list.Add(teklifsizSat);
                }
                if (StnTeklifsiz7.Text != "")
                {
                    TeklifsizSat teklifsizSat = new TeklifsizSat(StnTeklifsiz7.Text, TanimTeklifsiz7.Text, MiktarTeklifsiz7.Text.ConDouble(), BirimTeklifsiz7.Text, Tutar7.Text.ConDouble(), siparisNo);
                    list.Add(teklifsizSat);
                }
                if (StnTeklifsiz8.Text != "")
                {
                    TeklifsizSat teklifsizSat = new TeklifsizSat(StnTeklifsiz8.Text, TanimTeklifsiz8.Text, MiktarTeklifsiz8.Text.ConDouble(), BirimTeklifsiz8.Text, Tutar8.Text.ConDouble(), siparisNo);
                    list.Add(teklifsizSat);
                }
                if (StnTeklifsiz9.Text != "")
                {
                    TeklifsizSat teklifsizSat = new TeklifsizSat(StnTeklifsiz9.Text, TanimTeklifsiz9.Text, MiktarTeklifsiz9.Text.ConDouble(), BirimTeklifsiz9.Text, Tutar9.Text.ConDouble(), siparisNo);
                    list.Add(teklifsizSat);
                }
                if (StnTeklifsiz10.Text != "")
                {
                    TeklifsizSat teklifsizSat = new TeklifsizSat(StnTeklifsiz10.Text, TanimTeklifsiz10.Text, MiktarTeklifsiz10.Text.ConDouble(), BirimTeklifsiz10.Text, Tutar10.Text.ConDouble(), siparisNo);
                    list.Add(teklifsizSat);
                }
                if (list.Count == 0)
                {
                    MessageBox.Show("Eleman Bulunamadı");
                    return;
                }
                foreach (TeklifsizSat item in list)
                {
                    //mesaj = teklifsizSatManager.Update(item);
                }

            }

        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (DtgSatList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            DialogResult dr = MessageBox.Show(satno4 + " Nolu SAT Kaydınızı Güncellemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                List<TeklifAlinan> list = new List<TeklifAlinan>();
                if (sto1.Text != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(sto1.Text, BBF1.Text.ConDouble(), BT1.Text.ConDouble(), IBF1.Text.ConDouble(), IT1.Text.ConDouble(), UBF1.Text.ConDouble(), UT1.Text.ConDouble(), benzersiz4);
                    list.Add(teklifAlinan);
                }
                if (sto2.Text != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(sto2.Text, BBF2.Text.ConDouble(), BT2.Text.ConDouble(), IBF2.Text.ConDouble(), IT2.Text.ConDouble(), UBF2.Text.ConDouble(), UT2.Text.ConDouble(), benzersiz4);
                    list.Add(teklifAlinan);
                }
                if (sto3.Text != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(sto3.Text, BBF3.Text.ConDouble(), BT3.Text.ConDouble(), IBF3.Text.ConDouble(), IT3.Text.ConDouble(), UBF3.Text.ConDouble(), UT3.Text.ConDouble(), benzersiz4);
                    list.Add(teklifAlinan);
                }
                if (sto4.Text != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(sto4.Text, BBF4.Text.ConDouble(), BT4.Text.ConDouble(), IBF4.Text.ConDouble(), IT4.Text.ConDouble(), UBF4.Text.ConDouble(), UT4.Text.ConDouble(), benzersiz4);
                    list.Add(teklifAlinan);
                }
                if (sto5.Text != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(sto5.Text, BBF5.Text.ConDouble(), BT5.Text.ConDouble(), IBF5.Text.ConDouble(), IT5.Text.ConDouble(), UBF5.Text.ConDouble(), UT5.Text.ConDouble(), benzersiz4);
                    list.Add(teklifAlinan);
                }
                if (sto6.Text != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(sto6.Text, BBF6.Text.ConDouble(), BT6.Text.ConDouble(), IBF6.Text.ConDouble(), IT6.Text.ConDouble(), UBF6.Text.ConDouble(), UT6.Text.ConDouble(), benzersiz4);
                    list.Add(teklifAlinan);
                }
                if (sto7.Text != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(sto7.Text, BBF7.Text.ConDouble(), BT7.Text.ConDouble(), IBF7.Text.ConDouble(), IT7.Text.ConDouble(), UBF7.Text.ConDouble(), UT7.Text.ConDouble(), benzersiz4);
                    list.Add(teklifAlinan);
                }
                if (sto8.Text != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(sto8.Text, BBF8.Text.ConDouble(), BT8.Text.ConDouble(), IBF8.Text.ConDouble(), IT8.Text.ConDouble(), UBF8.Text.ConDouble(), UT8.Text.ConDouble(), benzersiz4);
                    list.Add(teklifAlinan);
                }
                if (sto9.Text != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(sto9.Text, BBF9.Text.ConDouble(), BT9.Text.ConDouble(), IBF9.Text.ConDouble(), IT9.Text.ConDouble(), UBF9.Text.ConDouble(), UT9.Text.ConDouble(), benzersiz4);
                    list.Add(teklifAlinan);
                }
                if (sto10.Text != "")
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(sto10.Text, BBF10.Text.ConDouble(), BT10.Text.ConDouble(), IBF10.Text.ConDouble(), IT10.Text.ConDouble(), UBF10.Text.ConDouble(), UT10.Text.ConDouble(), benzersiz4);
                    list.Add(teklifAlinan);
                }
                if (list.Count == 0)
                {
                    MessageBox.Show("Eleman Bulunamadı");
                    return;
                }
                foreach (TeklifAlinan item in list)
                {
                    teklifiAlinanManager.Update(item);
                }
                string yapilanislem = "SAT FİYAT TEKLİFLERİ GÜNCELLENDİ";

                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(benzersiz4, yapilanislem, islemyapan, DateTime.Now);
                satIslemAdimlariManager.Add(satIslemAdimlari);

                MessageBox.Show("Bilgiler Başarıyla Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DtgSatListDisplay();
                Temizle4();
                TxtTop4.Text = DtgSatList.RowCount.ToString();
            }
        }

        void DtgSatDisplay()
        {
            satDatas5 = satDataGridview1Manager.SatGuncelleTeklifsiz();
            dataBinder5.DataSource = satDatas5.ToDataTable();
            DtgSat.DataSource = dataBinder5;
            TxtGenelTop.Text = "0.00 ₺";

            DtgSat.Columns["Id"].Visible = false;
            DtgSat.Columns["PersonelId"].Visible = false;
            DtgSat.Columns["Satno"].HeaderText = "SAT NO";
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

        }
        private void DtgSat_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder5.Filter = DtgSat.FilterString;
            TxtTop5.Text = DtgSat.RowCount.ToString();
        }
        private void DtgSat_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder5.Sort = DtgSat.SortString;
        }
        private void DtgSat_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgSat.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            benzersiz5 = DtgSat.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosya5 = DtgSat.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            satno5 = DtgSat.CurrentRow.Cells["Satno"].Value.ToString();
            belgeTuru = DtgSat.CurrentRow.Cells["BelgeTuru"].Value.ToString();
            teklifsizSats = teklifsizSatManager.GetList(benzersiz5);
            FillTools5();
            if (belgeTuru != "")
            {
                panel2.Visible = true;
                panel3.Visible = false;
                return;
            }
            panel2.Visible = false;
            panel3.Visible = true;

            try
            {
                webBrowser3.Navigate(dosya5);
            }
            catch (Exception)
            {
                return;
            }
            

        }
        void FillTools5()
        {
            Temizle5();
            teklifsizSats = teklifsizSatManager.GetList(benzersiz5);
            if (teklifsizSats == null)
            {
                return;
            }
            if (teklifsizSats.Count == 0)
            {
                return;
            }
            if (belgeTuru != "")
            {
                TeklifsizSat item = teklifsizSats[0];
                LblToplam.Text = item.Tutar.ToString();
                try
                {
                    webBrowser8.Navigate(dosya5);
                }
                catch (Exception)
                {
                    return;
                }
                
                return;
            }
            if (teklifsizSats.Count > 0)
            {
                TeklifsizSat item = teklifsizSats[0];
                stnn1.Text = item.Stokno;
                Tanimm1.Text = item.Tanim;
                Miktarr1.Text = item.Miktar.ToString();
                Birimm1.Text = item.Birim;
                Tutarr1.Text = item.Tutar.ToString();
            }
            if (teklifsizSats.Count > 1)
            {
                TeklifsizSat item = teklifsizSats[1];
                stnn2.Text = item.Stokno;
                Tanimm2.Text = item.Tanim;
                Miktarr2.Text = item.Miktar.ToString();
                Birimm2.Text = item.Birim;
                Tutarr2.Text = item.Tutar.ToString();
            }
            if (teklifsizSats.Count > 2)
            {
                TeklifsizSat item = teklifsizSats[2];
                stnn3.Text = item.Stokno;
                Tanimm3.Text = item.Tanim;
                Miktarr3.Text = item.Miktar.ToString();
                Birimm3.Text = item.Birim;
                Tutarr3.Text = item.Tutar.ToString();
            }
            if (teklifsizSats.Count > 3)
            {
                TeklifsizSat item = teklifsizSats[3];
                stnn4.Text = item.Stokno;
                Tanimm4.Text = item.Tanim;
                Miktarr4.Text = item.Miktar.ToString();
                Birimm4.Text = item.Birim;
                Tutarr4.Text = item.Tutar.ToString();
            }
            if (teklifsizSats.Count > 4)
            {
                TeklifsizSat item = teklifsizSats[4];
                stnn5.Text = item.Stokno;
                Tanimm5.Text = item.Tanim;
                Miktarr5.Text = item.Miktar.ToString();
                Birimm5.Text = item.Birim;
                Tutarr5.Text = item.Tutar.ToString();
            }
            if (teklifsizSats.Count > 5)
            {
                TeklifsizSat item = teklifsizSats[5];
                stnn6.Text = item.Stokno;
                Tanimm6.Text = item.Tanim;
                Miktarr6.Text = item.Miktar.ToString();
                Birimm6.Text = item.Birim;
                Tutarr6.Text = item.Tutar.ToString();
            }
            if (teklifsizSats.Count > 6)
            {
                TeklifsizSat item = teklifsizSats[6];
                stnn7.Text = item.Stokno;
                Tanimm7.Text = item.Tanim;
                Miktarr7.Text = item.Miktar.ToString();
                Birimm7.Text = item.Birim;
                Tutarr7.Text = item.Tutar.ToString();
            }
            if (teklifsizSats.Count > 7)
            {
                TeklifsizSat item = teklifsizSats[7];
                stnn8.Text = item.Stokno;
                Tanimm8.Text = item.Tanim;
                Miktarr8.Text = item.Miktar.ToString();
                Birimm8.Text = item.Birim;
                Tutarr8.Text = item.Tutar.ToString();
            }
            if (teklifsizSats.Count > 8)
            {
                TeklifsizSat item = teklifsizSats[8];
                stnn9.Text = item.Stokno;
                Tanimm9.Text = item.Tanim;
                Miktarr9.Text = item.Miktar.ToString();
                Birimm9.Text = item.Birim;
                Tutarr9.Text = item.Tutar.ToString();
            }
            if (teklifsizSats.Count > 9)
            {
                TeklifsizSat item = teklifsizSats[9];
                stnn10.Text = item.Stokno;
                Tanimm10.Text = item.Tanim;
                Miktarr10.Text = item.Miktar.ToString();
                Birimm10.Text = item.Birim;
                Tutarr10.Text = item.Tutar.ToString();
            }
        }
        void Temizle5()
        {
            stnn1.Clear(); Tanimm1.Clear(); Miktarr1.Clear(); Birimm1.Clear(); Tutarr1.Clear();
            stnn2.Clear(); Tanimm2.Clear(); Miktarr2.Clear(); Birimm2.Clear(); Tutarr2.Clear();
            stnn3.Clear(); Tanimm3.Clear(); Miktarr3.Clear(); Birimm3.Clear(); Tutarr3.Clear();
            stnn4.Clear(); Tanimm4.Clear(); Miktarr4.Clear(); Birimm4.Clear(); Tutarr4.Clear();
            stnn5.Clear(); Tanimm5.Clear(); Miktarr5.Clear(); Birimm5.Clear(); Tutarr5.Clear();
            stnn6.Clear(); Tanimm6.Clear(); Miktarr6.Clear(); Birimm6.Clear(); Tutarr6.Clear();
            stnn7.Clear(); Tanimm7.Clear(); Miktarr7.Clear(); Birimm7.Clear(); Tutarr7.Clear();
            stnn8.Clear(); Tanimm8.Clear(); Miktarr8.Clear(); Birimm8.Clear(); Tutarr8.Clear();
            stnn9.Clear(); Tanimm9.Clear(); Miktarr9.Clear(); Birimm9.Clear(); Tutarr9.Clear();
            stnn10.Clear(); Tanimm10.Clear(); Miktarr10.Clear(); Birimm10.Clear(); Tutarr10.Clear();
        }
        void Hesapla()
        {
            toplam = a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10;
            TxtGenelTop.Text = toplam.ToString("0.00") + " ₺";
        }

        #region TeklifsizTextChanged
        private void Tutarr1_TextChanged(object sender, EventArgs e)
        {
            if (Tutarr1.Text == "")
            {
                a1 = 0;
                Hesapla();
                return;
            }
            a1 = double.TryParse(Tutarr1.Text, out outValue) ? Convert.ToDouble(Tutarr1.Text) : 0;
            Hesapla();
        }

        private void Tutarr2_TextChanged(object sender, EventArgs e)
        {
            if (Tutarr2.Text == "")
            {
                a2 = 0;
                Hesapla();
                return;
            }
            a2 = double.TryParse(Tutarr2.Text, out outValue) ? Convert.ToDouble(Tutarr2.Text) : 0;
            Hesapla();
        }

        private void Tutarr3_TextChanged(object sender, EventArgs e)
        {
            if (Tutarr3.Text == "")
            {
                a3 = 0;
                Hesapla();
                return;
            }
            a3 = double.TryParse(Tutarr3.Text, out outValue) ? Convert.ToDouble(Tutarr3.Text) : 0;
            Hesapla();
        }

        private void Tutarr4_TextChanged(object sender, EventArgs e)
        {
            if (Tutarr4.Text == "")
            {
                a4 = 0;
                Hesapla();
                return;
            }
            a4 = double.TryParse(Tutarr4.Text, out outValue) ? Convert.ToDouble(Tutarr4.Text) : 0;
            Hesapla();
        }

        private void Tutarr5_TextChanged(object sender, EventArgs e)
        {
            if (Tutarr5.Text == "")
            {
                a5 = 0;
                Hesapla();
                return;
            }
            a5 = double.TryParse(Tutarr5.Text, out outValue) ? Convert.ToDouble(Tutarr5.Text) : 0;
            Hesapla();
        }

        private void Tutarr6_TextChanged(object sender, EventArgs e)
        {
            if (Tutarr6.Text == "")
            {
                a6 = 0;
                Hesapla();
                return;
            }
            a6 = double.TryParse(Tutarr6.Text, out outValue) ? Convert.ToDouble(Tutarr6.Text) : 0;
            Hesapla();
        }

        private void Tutarr7_TextChanged(object sender, EventArgs e)
        {
            if (Tutarr7.Text == "")
            {
                a7 = 0;
                Hesapla();
                return;
            }
            a7 = double.TryParse(Tutarr7.Text, out outValue) ? Convert.ToDouble(Tutarr7.Text) : 0;
            Hesapla();
        }

        private void Tutarr8_TextChanged(object sender, EventArgs e)
        {
            if (Tutarr8.Text == "")
            {
                a8 = 0;
                Hesapla();
                return;
            }
            a8 = double.TryParse(Tutarr8.Text, out outValue) ? Convert.ToDouble(Tutarr8.Text) : 0;
            Hesapla();
        }

        private void Tutarr9_TextChanged(object sender, EventArgs e)
        {
            if (Tutarr9.Text == "")
            {
                a9 = 0;
                Hesapla();
                return;
            }
            a9 = double.TryParse(Tutarr9.Text, out outValue) ? Convert.ToDouble(Tutarr9.Text) : 0;
            Hesapla();
        }

        private void Tutarr10_TextChanged(object sender, EventArgs e)
        {
            if (Tutarr10.Text == "")
            {
                a10 = 0;
                Hesapla();
                return;
            }
            a10 = double.TryParse(Tutarr10.Text, out outValue) ? Convert.ToDouble(Tutarr10.Text) : 0;
            Hesapla();
        }
        #endregion

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(dosya5))
            {
                MessageBox.Show("Dosya Yolu Bulunamadı.");
                return;
            }
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi = openFileDialog2.SafeFileName.ToString();
                alinandosya = openFileDialog2.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string dosyaismi = kaynakdosyaismi;
            tamyol = dosya5 + "\\" + dosyaismi;
            if (File.Exists(dosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + dosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, tamyol);
                BtnDosyaEkle.BackColor = Color.LightGreen;
            }
            webBrowser3.Navigate(dosya5);
        }
        private void BtnGuncelle4_Click(object sender, EventArgs e)
        {
            if (DtgSat.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            DialogResult dr = MessageBox.Show(satno5 + " Nolu SAT Kaydınızı Güncellemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                List<TeklifsizSat> list = new List<TeklifsizSat>();
                if (stnn1.Text != "")
                {
                    TeklifsizSat teklifsiz = new TeklifsizSat(stnn1.Text, Tutarr1.Text.ConDouble());
                    list.Add(teklifsiz);
                }
                if (stnn2.Text != "")
                {
                    TeklifsizSat teklifsiz = new TeklifsizSat(stnn2.Text, Tutarr2.Text.ConDouble());
                    list.Add(teklifsiz);
                }
                if (stnn3.Text != "")
                {
                    TeklifsizSat teklifsiz = new TeklifsizSat(stnn3.Text, Tutarr3.Text.ConDouble());
                    list.Add(teklifsiz);
                }
                if (stnn4.Text != "")
                {
                    TeklifsizSat teklifsiz = new TeklifsizSat(stnn4.Text, Tutarr4.Text.ConDouble());
                    list.Add(teklifsiz);
                }
                if (stnn5.Text != "")
                {
                    TeklifsizSat teklifsiz = new TeklifsizSat(stnn5.Text, Tutarr5.Text.ConDouble());
                    list.Add(teklifsiz);
                }
                if (stnn6.Text != "")
                {
                    TeklifsizSat teklifsiz = new TeklifsizSat(stnn6.Text, Tutarr6.Text.ConDouble());
                    list.Add(teklifsiz);
                }
                if (stnn7.Text != "")
                {
                    TeklifsizSat teklifsiz = new TeklifsizSat(stnn7.Text, Tutarr7.Text.ConDouble());
                    list.Add(teklifsiz);
                }
                if (stnn8.Text != "")
                {
                    TeklifsizSat teklifsiz = new TeklifsizSat(stnn8.Text, Tutarr8.Text.ConDouble());
                    list.Add(teklifsiz);
                }
                if (stnn9.Text != "")
                {
                    TeklifsizSat teklifsiz = new TeklifsizSat(stnn9.Text, Tutarr9.Text.ConDouble());
                    list.Add(teklifsiz);
                }
                if (stnn10.Text != "")
                {
                    TeklifsizSat teklifsiz = new TeklifsizSat(stnn10.Text, Tutarr10.Text.ConDouble());
                    list.Add(teklifsiz);
                }
                if (list.Count == 0)
                {
                    MessageBox.Show("Eleman Bulunamadı");
                    return;
                }
                foreach (TeklifsizSat item in list)
                {
                    mesaj = teklifsizSatManager.Update(item, benzersiz5);
                }
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj);
                }
                else
                {
                    string islem = "Tutar Bilgileri Güncellendi.";

                    SatIslemAdimlari dtgSat = new SatIslemAdimlari(benzersiz5, islem, islemyapan, DateTime.Now);
                    satIslemAdimlariManager.Add(dtgSat);
                    MessageBox.Show(satno5 + " Numaralı SAT Başarıyla Güncellenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillTools5();
                    Temizle5();
                    webBrowser3.Navigate("");
                    TxtTop5.Text = DtgSat.RowCount.ToString();

                }
            }
        }
        ///////////////////////////////////////////////////////////////// REDDEDİLEN SAT /////////////////////////////////////////////////////////////////

        private void CmbFaturaFirmaRed_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexGuncelle = CmbFaturaFirmaRed.SelectedIndex;
            TxtIlgiliKisi.SelectedIndex = indexGuncelle;
            TxtMasYerNo.SelectedIndex = indexGuncelle;
        }

        void ButceKoduKalemiGuncelle()
        {
            CmbButceKoduRed.DataSource = butceKoduManager.GetList();
            CmbButceKoduRed.ValueMember = "Id";
            CmbButceKoduRed.DisplayMember = "Butcekodu";
            CmbButceKoduRed.SelectedValue = 0;
        }
        void DataDisplayReddedilenler()
        {
            reddedilenler = satDataGridview1Manager.GetList("Reddedildi");
            dataBinder6.DataSource = reddedilenler.ToDataTable();
            DtgReddedilenSat.DataSource = dataBinder6;
            TxtReddedilenlerSayisi.Text = DtgReddedilenSat.RowCount.ToString();


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
            DtgReddedilenSat.Columns["IslemAdimi"].Visible = false;
            DtgReddedilenSat.Columns["SatOlusturmaTuru"].Visible = false;
            DtgReddedilenSat.Columns["RedNedeni"].HeaderText = "RET NEDENİ";
            DtgReddedilenSat.Columns["Donem"].DisplayIndex = 3;

        }
        private void CmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbKategori.SelectedIndex == 0)
            {
                PnlSatBilgileri.Visible = true;
            }
            if (CmbKategori.SelectedIndex == 1)
            {
                PnlSatBilgileri.Visible = false;
                //PnlSatBilgileri.Visible = true;
            }
        }
        string dosyaYoluGuncelle = "", siparisNoGuncelle = "", islemAdimi = "", satOlusturmaTuru = "", durum = "", redNedeni = "", teklifDurumu = "",
            firmaBilgisi = "", islemAdimiGuncelle = "", satOlusturmaTuruGuncelle = "",belgeTuruGuncelle="",belgeNumarasi="", redDurum ="", mailDurumu="", mailSiniri=""; int satnoGuncelle, personelIdGuncelle, personelId, ucTeklif;
        DateTime belgeTarihi;
        private void DtgReddedilenSat_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgReddedilenSat.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            idRed = DtgReddedilenSat.CurrentRow.Cells["Id"].Value.ConInt();
            LblIsAkisNo2.Text = DtgReddedilenSat.CurrentRow.Cells["Formno"].Value.ToString();
            LblMasrafYeriNo.Text = DtgReddedilenSat.CurrentRow.Cells["Masrafyeri"].Value.ToString();
            LblMasrafYeri.Text = DtgReddedilenSat.CurrentRow.Cells["Bolum"].Value.ToString();
            LblAdSoyad.Text = DtgReddedilenSat.CurrentRow.Cells["Talepeden"].Value.ToString();
            CmbUsBolgesi.Text = DtgReddedilenSat.CurrentRow.Cells["Usbolgesi"].Value.ToString();
            CmbAbfFormno.Text = DtgReddedilenSat.CurrentRow.Cells["Abfformno"].Value.ToString();
            istenenTarih.Value = DtgReddedilenSat.CurrentRow.Cells["Tarih"].Value.ConDate();
            CmbDonem.Text = DtgReddedilenSat.CurrentRow.Cells["Donem"].Value.ToString();
            CmbAdSoyad.Text = DtgReddedilenSat.CurrentRow.Cells["TalepEdenPersonel"].Value.ToString();
            TxtGerekceBasaran.Text = DtgReddedilenSat.CurrentRow.Cells["Gerekce"].Value.ToString();
            dosyaYoluGuncelle = DtgReddedilenSat.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            siparisNoGuncelle = DtgReddedilenSat.CurrentRow.Cells["SiparisNo"].Value.ToString();
            personelIdGuncelle = DtgReddedilenSat.CurrentRow.Cells["PersonelId"].Value.ConInt();
            islemAdimi = DtgReddedilenSat.CurrentRow.Cells["IslemAdimi"].Value.ToString();
            satnoGuncelle = DtgReddedilenSat.CurrentRow.Cells["Satno"].Value.ConInt();
            satOlusturmaTuru = DtgReddedilenSat.CurrentRow.Cells["SatOlusturmaTuru"].Value.ToString();
            durum = DtgReddedilenSat.CurrentRow.Cells["Durum"].Value.ToString();
            redNedeni = DtgReddedilenSat.CurrentRow.Cells["RedNedeni"].Value.ToString();
            teklifDurumu = DtgReddedilenSat.CurrentRow.Cells["TeklifDurumu"].Value.ToString();
            personelId = DtgReddedilenSat.CurrentRow.Cells["PersonelId"].Value.ConInt();
            ucTeklif = DtgReddedilenSat.CurrentRow.Cells["Uctekilf"].Value.ConInt();
            firmaBilgisi = DtgReddedilenSat.CurrentRow.Cells["FirmaBilgisi"].Value.ToString();
            satOlusturmaTuruGuncelle = DtgReddedilenSat.CurrentRow.Cells["SatOlusturmaTuru"].Value.ToString();
            belgeTuruGuncelle = DtgReddedilenSat.CurrentRow.Cells["BelgeTuru"].Value.ToString();
            belgeNumarasi = DtgReddedilenSat.CurrentRow.Cells["BelgeNumarasi"].Value.ToString();
            belgeTarihi = DtgReddedilenSat.CurrentRow.Cells["BelgeTarihi"].Value.ConDate();
            islemAdimiGuncelle = DtgReddedilenSat.CurrentRow.Cells["IslemAdimi"].Value.ToString();
            mailDurumu= DtgReddedilenSat.CurrentRow.Cells["MailDurumu"].Value.ToString();
            mailSiniri= DtgReddedilenSat.CurrentRow.Cells["MailSiniri"].Value.ToString();
            webBrowser6.Navigate(dosyaYoluGuncelle);
        }
        void Personeller()
        {
            CmbAdSoyad.DataSource = kayitManager.PersonelAdSoyad();
            CmbAdSoyad.ValueMember = "Id";
            CmbAdSoyad.DisplayMember = "Adsoyad";
            CmbAdSoyad.SelectedValue = -1;
        }
        private void CmbAdSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gec == false)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbAdSoyad.Text);
            TxtMasrafyeriNo.Text = siparis.Masrafyerino;
            TxtMasrafYeri.Text = siparis.Masrafyeri;
            TxtGorevi.Text = siparis.Gorevi;
            CmbSiparisNo.Text = siparis.Siparis;
        }
        void UsBolgeleriGuncelle()
        {
            CmbUsBolgesi.DataSource = satTalebiDoldurManager.GetList();
            CmbUsBolgesi.ValueMember = "Id";
            CmbUsBolgesi.DisplayMember = "Usbolgesi";
            CmbUsBolgesi.SelectedValue = "";
        }
        private void BtnGoz_Click(object sender, EventArgs e)
        {
            FrmButceKoduKalemi frmButceKoduKalemi = new FrmButceKoduKalemi();
            frmButceKoduKalemi.Show();
        }
        private void CmbUsBolgesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gec == false)
            {
                return;
            }
            CmbAbfFormno.Text = "";
            AbfFormNoListGuncelle();
            SatTalebiDoldur satTalebiDoldur = satTalebiDoldurManager.Get(CmbUsBolgesi.Text);
            TxtProje.Text = satTalebiDoldur.Proje;
        }
        void AbfFormNoListGuncelle()
        {
            CmbAbfFormno.DataSource = satTalebiDoldurManager.BolgeSatList(CmbUsBolgesi.Text);
            CmbAbfFormno.ValueMember = "Id";
            CmbAbfFormno.DisplayMember = "AbfNo";
            CmbAbfFormno.SelectedValue = "";
        }
        private void BtnDosyaEkleRed_Click(object sender, EventArgs e)
        {
            if (dosyaYoluGuncelle == "")
            {
                MessageBox.Show("Lütfen Öncelikle Bir Kayit Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(dosyaYoluGuncelle))
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
            tamyol = dosyaYoluGuncelle + "\\" + dosyaismi;
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
            webBrowser6.Navigate(dosyaYoluGuncelle);
        }
        private void BtnGuncelleRed_Click(object sender, EventArgs e)
        {
            if (idRed == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Güncelleme İşleminden Sonra SAT Reddedildiği İşlem Adımına Tekrar İletilecektir.Güncellemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                SatDataGridview1 satDataGridview1 = new SatDataGridview1(idRed, LblIsAkisNo2.Text.ConInt(), satnoGuncelle, LblMasrafYeriNo.Text,LblAdSoyad.Text, LblMasrafYeri.Text, CmbUsBolgesi.Text, CmbAbfFormno.Text, istenenTarih.Value, TxtGerekceBasaran.Text, siparisNoGuncelle, dosyaYoluGuncelle, CmbButceKoduRed.Text, CmbSatBirimRed.Text, CmbHarcamaTuruRed.Text, CmbFaturaFirmaRed.Text, TxtIlgiliKisi.Text, TxtMasYerNo.Text, ucTeklif, firmaBilgisi, CmbAdSoyad.Text, CmbSiparisNo.Text, TxtGorevi.Text, TxtMasrafyeriNo.Text, TxtMasrafYeri.Text, belgeTuruGuncelle,belgeNumarasi,belgeTarihi,islemAdimi, CmbDonem.Text, satOlusturmaTuruGuncelle, redNedeni,durum,teklifDurumu, TxtProje.Text, TxtFirmaGuncelle.Text, mailSiniri, mailDurumu);

                string messege = satDataGridview1Manager.RedUpdate(satDataGridview1);
                if (messege!="OK")
                {
                    MessageBox.Show(messege,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                messege = satinAlinacakMalManager.SatDurumOnay(siparisNoGuncelle); // MALZEMELERİN DURUMU GÜNCELLENDİ (ONAYLANDI)

                if (messege!="OK")
                {
                    MessageBox.Show(messege,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                if (islemAdimiGuncelle== "SAT BAŞLATMA ONAYI")
                {
                    teklifsizSatManager.SatDurumBasla(siparisNoGuncelle);
                }
                if (islemAdimiGuncelle == "SAT ONAY")
                {
                    satDataGridview1Manager.DurumGuncelleOnay(siparisNoGuncelle);
                }
                if (ucTeklif == 0)
                {
                    messege = teklifsizSatManager.SatMalzemeDurumGuncelleOnay(siparisNoGuncelle);
                }
                
                if (ucTeklif == 1)
                {
                    messege = teklifiAlinanManager.SatTekliflerDurumGuncelleOnay(siparisNoGuncelle);
                }

                if (messege != "OK")
                {
                    MessageBox.Show(messege, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                yapilanislem = "SAT REDDEDİLENLERDEN GÜNCELLENEREK REDDEDİLDİĞİ İŞLEM ADIMINA İLETİLDİ.";
                SatIslemAdimlari satIslemAdimlari2 = new SatIslemAdimlari(siparisNoGuncelle, yapilanislem, islemyapan, DateTime.Now);
                satIslemAdimlariManager.Add(satIslemAdimlari2);

                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir. SAT İşleminizi Reddedildiği İşlem Adımına İletilmiştir. ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataDisplayReddedilenler();
                TemizleReddilenler();
                FrmAnaSayfa frmAnaSayfa = new FrmAnaSayfa();
                frmAnaSayfa.ToplamSayilar();

                #region ReddedinlerEskiKod
                /*
                Reddedilenler reddedilenler2 = new Reddedilenler(LblIsAkisNo2.Text.ConInt(), satnoGuncelle, LblMasrafYeriNo.Text, LblAdSoyad.Text, LblMasrafYeri.Text, CmbUsBolgesi.Text, CmbAbfFormno.Text, istenenTarih.Value, TxtGerekceBasaran.Text, siparisNoGuncelle, dosyaYoluGuncelle, redNedeni, durum, teklifDurumu, CmbDonem.Text, personelId, CmbButceKoduRed.Text, CmbSatBirimRed.Text, CmbHarcamaTuruRed.Text, CmbFaturaFirmaRed.Text, TxtIlgiliKisi.Text, TxtMasYerNo.Text, ucTeklif, firmaBilgisi, CmbAdSoyad.Text, CmbSiparisNo.Text, TxtGorevi.Text, TxtMasrafyeriNo.Text, islemAdimiGuncelle, satOlusturmaTuruGuncelle);

                string mesaj = reddedilenlerManager.SatReddedilenlerGuncelle(reddedilenler2, siparisNoGuncelle);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir. SAT İşleminizi Reddedildiği İşlem Adımına İletmek için GÖNDER Butonunu kullanabilirsiniz. ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleReddilenler();
                */
                #endregion
            }
        }
        void TemizleReddilenler()
        {
            LblIsAkisNo2.Text = "-"; LblMasrafYeriNo.Text = "-"; LblMasrafYeri.Text = "-"; LblAdSoyad.Text = "-"; CmbUsBolgesi.SelectedValue = ""; CmbAbfFormno.SelectedValue = ""; CmbDonem.Text = ""; CmbAdSoyad.SelectedValue = -1; CmbSiparisNo.Clear(); TxtGorevi.Clear();
            TxtMasrafyeriNo.Clear(); TxtMasrafYeri.Clear(); CmbButceKoduRed.SelectedValue = ""; CmbSatBirimRed.SelectedValue = "";
            CmbHarcamaTuruRed.SelectedValue = ""; CmbFaturaFirmaRed.SelectedValue = 0;
        }
        private void BtnTeklifliSatSil_Click(object sender, EventArgs e)
        {
            /*if (benzersiz4=="")
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz SAT Kaydını Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("SAT Kaydını Silmek İsteğinize Emin Misiniz?","Soru");*/
        }
    }
}
