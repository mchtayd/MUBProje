﻿using Business;
using Business.Concreate.AnaSayfa;
using Business.Concreate.BakimOnarim;
using Business.Concreate.Depo;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity.AnaSayfa;
using Entity.BakimOnarim;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;
using UserInterface.STS;

namespace UserInterface.BakımOnarım
{
    public partial class FrmBolgeler : Form
    {
        public bool buton = false;
        string il, comboAd, dosyaYolu="", kaynakdosyaismi, alinandosya;
        public string siparisNo = "";
        int id;
        List<Bolge> bolges = new List<Bolge>();

        BolgeManager bolgeManager;
        BolgeKayitManager bolgeKayitManager;
        ComboManager comboManager;
        PypManager pypManager;
        DepoKayitManagercs depoKayitManagercs;
        TedarikciFirmaManager tedarikciFirmaManager;
        SiparisPersonelManager siparisPersonelManager;
        PersonelKayitManager personelKayitManager;
        BolgeNotManager bolgeNotManager;
        BolgeEnvanterManager bolgeEnvanterManager;
        DtsLogManager dtsLogManager;

        bool start = true;
        bool dosyaControl = false;
        int bolgeId = 0;
        bool excelControl = false;

        public object[] infos;
        public FrmBolgeler()
        {
            InitializeComponent();
            bolgeManager = BolgeManager.GetInstance();
            tedarikciFirmaManager = TedarikciFirmaManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            pypManager = PypManager.GetInstance();
            depoKayitManagercs = DepoKayitManagercs.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            personelKayitManager = PersonelKayitManager.GetInstance();
            bolgeNotManager = BolgeNotManager.GetInstance();
            bolgeEnvanterManager = BolgeEnvanterManager.GetInstance();
            dtsLogManager = DtsLogManager.GetInstance();
        }

        private void BtnCancel_Click_1(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageBolgeler"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void FrmBolgeler_Load(object sender, EventArgs e)
        {
            BolgeBilgileri();
            BolgeBilgileriEkipman();
            DataDisplay();
            CmbIlYükle();
            ComboProje();
            ComboPypNo();
            ComboDepo();
            ComboYazilim();
            ComboKesifGozetleme();
            ComboYasamAlani();
            MasrafYeriSorumlusu();
            start = false;
            if (buton == true)
            {
                BtnCancel.Visible = false;
                return;
            }
            BtnCancel.Visible = true;
            CmbIslemTuru.SelectedIndex = 0;

            //DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            //Calendar cal = dfi.Calendar;
            //label5.Text = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek).ToString();

            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            label5.Text = weekNum.ToString();

        }
        void MasrafYeriSorumlusu()
        {
            CmbBolgeSorumlusu.DataSource = siparisPersonelManager.MasrafYeriSorumlusu();
            CmbBolgeSorumlusu.ValueMember = "Id";
            CmbBolgeSorumlusu.DisplayMember = "Personel";
            CmbBolgeSorumlusu.SelectedValue = 0;
        }
        void BolgeBilgileri()
        {
            CmbBolgeAdi.DataSource = bolgeKayitManager.GetList();
            CmbBolgeAdi.ValueMember = "Id";
            CmbBolgeAdi.DisplayMember = "BolgeAdi";
            CmbBolgeAdi.SelectedValue = -1;
        }
        void BolgeBilgileriEkipman()
        {
            CmbBolgeAdiEkipman.DataSource = bolgeKayitManager.GetList();
            CmbBolgeAdiEkipman.ValueMember = "Id";
            CmbBolgeAdiEkipman.DisplayMember = "BolgeAdi";
            CmbBolgeAdiEkipman.SelectedValue = 0;
        }

        public void ComboProje()
        {
            CmbProje.DataSource = comboManager.GetList("PROJE");
            CmbProje.ValueMember = "Id";
            CmbProje.DisplayMember = "Baslik";
            CmbProje.SelectedValue = 0;
        }
        public void ComboYazilim()
        {
            CmbYazilimBilgisi.DataSource = comboManager.GetList("YAZILIM BILGISI");
            CmbYazilimBilgisi.ValueMember = "Id";
            CmbYazilimBilgisi.DisplayMember = "Baslik";
            CmbYazilimBilgisi.SelectedValue = 0;
        }
        public void ComboKesifGozetleme()
        {
            CmbGozetlemeTuru.DataSource = comboManager.GetList("KESIF_GOZETLEME");
            CmbGozetlemeTuru.ValueMember = "Id";
            CmbGozetlemeTuru.DisplayMember = "Baslik";
            CmbGozetlemeTuru.SelectedValue = 0;
        }
        public void ComboYasamAlani()
        {
            CmbYasamAlani.DataSource = comboManager.GetList("YASAM_ALANI");
            CmbYasamAlani.ValueMember = "Id";
            CmbYasamAlani.DisplayMember = "Baslik";
            CmbYasamAlani.SelectedValue = 0;
        }
        public void ComboDepo()
        {
            CmbDepo.DataSource = depoKayitManagercs.GetList();
            CmbDepo.ValueMember = "Id";
            CmbDepo.DisplayMember = "Depo";
            CmbDepo.SelectedValue = 0;
        }
        public void ComboPypNo()
        {
            CmbPypNo.DataSource = pypManager.GetList();
            CmbPypNo.ValueMember = "Id";
            CmbPypNo.DisplayMember = "PypNo";
            CmbPypNo.SelectedValue = 0;
        }
        void DataDisplay()
        {
            bolges = bolgeManager.GetList();
            dataBinder.DataSource = bolges.ToDataTable();
            DtgBolgeler.DataSource = dataBinder;
            //TxtTop.Text = DtgBolgeler.RowCount.ToString();

            DtgBolgeler.Columns["Id"].Visible = false;
            DtgBolgeler.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgBolgeler.Columns["IlgiliPersonel"].HeaderText = "İLGİLİ PERSONEL";
            DtgBolgeler.Columns["BirlikAdresi"].HeaderText = "BİRLİK ADRESİ";
            DtgBolgeler.Columns["Telefon"].HeaderText = "TELEFON";
            DtgBolgeler.Columns["FaturaAdresi"].HeaderText = "FATURA ADRESİ";
            DtgBolgeler.Columns["PypNo"].HeaderText = "PYP NO";
            DtgBolgeler.Columns["SorumluSicil"].HeaderText = "BÖLGE SORUMLUSU SİCİL";
            DtgBolgeler.Columns["Il"].HeaderText = "İL";
            DtgBolgeler.Columns["Ilce"].HeaderText = "İLÇE";
            DtgBolgeler.Columns["Proje"].HeaderText = "PROJE";
            DtgBolgeler.Columns["GarantiBaslama"].HeaderText = "GARANTİ BAŞLAMA";
            DtgBolgeler.Columns["GarantiBitis"].HeaderText = "GARANTİ BİTİŞ";
            DtgBolgeler.Columns["SsPersonel"].HeaderText = "SORUMLU PERSONEL";
            DtgBolgeler.Columns["SspGorev"].HeaderText = "SORUMLU PERSONEL GÖREVİ";
            DtgBolgeler.Columns["Depo"].HeaderText = "DEPO";
            DtgBolgeler.Columns["SsRutbe"].HeaderText = "SORUMLU PERSONEL RÜTBE";
        }

        private void BtnPYPEkle_Click(object sender, EventArgs e)
        {
            FrmPyp frmPyp = new FrmPyp();
            frmPyp.ShowDialog();
        }
        void CmbIlYükle()
        {
            CmbIl.DataSource = tedarikciFirmaManager.Iller();
            CmbIl.SelectedIndex = -1;
            CmbIlce.Text = "";
        }

        private void CmbIl_SelectedValueChanged(object sender, EventArgs e)
        {
            il = CmbIl.Text;
            CmbIlceYükle();
        }
        void CmbIlceYükle()
        {
            if (start)
            {
                return;
            }
            CmbIlce.DataSource = tedarikciFirmaManager.Ilceler(il);
            CmbIlce.SelectedIndex = -1;
            CmbIlce.Text = "";
        }

        
        void Temizle()
        {
            TxtBolgeAdi.Clear(); TxtKodAdi.Clear(); TxtBolgeStokNo.Clear(); CmbProje.SelectedIndex = -1; CmbYazilimBilgisi.SelectedIndex = -1;
            CmbGozetlemeTuru.SelectedIndex = -1; CmbYasamAlani.SelectedIndex = -1; TxtTabur.Clear(); TxtTugay.Clear(); CmbIl.SelectedIndex = -1;
            CmbIlce.SelectedIndex = -1; TxtBirlikAdresi.Clear(); CmbPypNo.SelectedIndex = -1; CmbDepo.SelectedIndex = -1; CmbBolgeSorumlusu.SelectedIndex = -1;
            webBrowser1.Navigate(""); CmbBolgeAdi.Text = ""; CmbMusteri.SelectedIndex = -1; TxtNotlar.Clear(); CmbProjeSistem.SelectedIndex = -1;
            ComboProje(); DtgList.Rows.Clear();
        }
        

        private void DtgBolgeler_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgBolgeler.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            id = DtgBolgeler.CurrentRow.Cells["Id"].Value.ConInt();
            TxtBolgeAdi.Text=DtgBolgeler.CurrentRow.Cells["BolgeAdi"].Value.ToString();
            /*TxtIlgiliPersonel.Text= DtgBolgeler.CurrentRow.Cells["IlgiliPersonel"].Value.ToString();
            TxtTelefon.Text= DtgBolgeler.CurrentRow.Cells["Telefon"].Value.ToString();*/
            CmbIl.Text= DtgBolgeler.CurrentRow.Cells["Il"].Value.ToString();
            CmbIlce.Text= DtgBolgeler.CurrentRow.Cells["Ilce"].Value.ToString();
            TxtBirlikAdresi.Text= DtgBolgeler.CurrentRow.Cells["BirlikAdresi"].Value.ToString();
            CmbDepo.Text= DtgBolgeler.CurrentRow.Cells["Depo"].Value.ToString();
            DtGarantİBasTarihi.Value= DtgBolgeler.CurrentRow.Cells["GarantiBaslama"].Value.ConDate();
            DtGarantİBitTarihi.Value = DtgBolgeler.CurrentRow.Cells["GarantiBitis"].Value.ConDate();
            CmbProje.Text= DtgBolgeler.CurrentRow.Cells["Proje"].Value.ToString(); 
            CmbPypNo.Text= DtgBolgeler.CurrentRow.Cells["PypNo"].Value.ToString();
            //TxtBolgeSorumlusuSicil.Text= DtgBolgeler.CurrentRow.Cells["SorumluSicil"].Value.ToString();
            
            /*TxtSSPersonel.Text= DtgBolgeler.CurrentRow.Cells["SsPersonel"].Value.ToString();
            TxtSSPRutbe.Text= DtgBolgeler.CurrentRow.Cells["SsRutbe"].Value.ToString();
            TxtSSPGorevi.Text= DtgBolgeler.CurrentRow.Cells["SspGorev"].Value.ToString();*/

        }

        private void BtnDepoEkle_Click(object sender, EventArgs e)
        {

        }

        

        private void CmbIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbIslemTuru.Text== "YENİ KAYIT")
            {
                BtnGarantiEdit.Visible = false;
                TxtBolgeAdi.Visible = true;
                CmbBolgeAdi.Visible = false;
                BtnGuncelle.Visible = false;
                BtnKaydet.Visible = true;
                DtGarantİBasTarihi.Enabled = true;
                DtGarantİBitTarihi.Enabled = true;
            }
            else
            {
                BtnGarantiEdit.Visible = true;
                TxtBolgeAdi.Visible = false;
                CmbBolgeAdi.Visible = true;
                BtnGuncelle.Visible = true;
                BtnKaydet.Visible = false;
                DtGarantİBasTarihi.Enabled = true;
                DtGarantİBitTarihi.Enabled = true;
            }
        }
        

        private void BtnYazlim_Click(object sender, EventArgs e)
        {
            comboAd = "YAZILIM BILGISI";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnGozetlemeTuru_Click(object sender, EventArgs e)
        {
            comboAd = "KESIF_GOZETLEME";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnYasamAlani_Click(object sender, EventArgs e)
        {
            comboAd = "YASAM_ALANI";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        

        private void buton_proje_Click(object sender, EventArgs e)
        {
            comboAd = "PROJE";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            if (CmbIslemTuru.Text=="")
            {
                MessageBox.Show("Lütfen İşlem Türü seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbIslemTuru.Text == "YENİ KAYIT")
            {
                if (TxtBolgeAdi.Text == "")
                {
                    MessageBox.Show("Lütfen Bölge Adı bilgisini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (CmbBolgeAdi.Text == "")
                {
                    MessageBox.Show("Lütfen Bölge Adı bilgisini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            CreateFile();
            dosyaControl = true;
        }
        string bolgeAdi = "";
        private void CmbBolgeAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start != false)
            {
                return;
            }
            if (CmbBolgeAdi.SelectedIndex==-1)
            {
                return;
            }
            id = CmbBolgeAdi.SelectedValue.ConInt();
            BolgeKayit bolgeKayit = bolgeKayitManager.Get(id);
            if (bolgeKayit == null)
            {
                MessageBox.Show("Bölge kaydına ulaşılamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bolgeAdi = CmbBolgeAdi.Text;
            TxtKodAdi.Text = bolgeKayit.KodAdi;
            TxtBolgeStokNo.Text = bolgeKayit.UsBolgesiStok;
            CmbProje.Text = bolgeKayit.Proje;
            DtgKabulTarihi.Value = bolgeKayit.KabulTarihi;
            CmbYazilimBilgisi.Text = bolgeKayit.GuvenlikYazilimi;
            CmbGozetlemeTuru.Text = bolgeKayit.KesifGozetlemeTuru;
            CmbYasamAlani.Text = bolgeKayit.YasamAlani;
            TxtTabur.Text = bolgeKayit.Tabur;
            TxtTugay.Text = bolgeKayit.Tugay;
            CmbIl.Text = bolgeKayit.Il;
            CmbIlce.Text = bolgeKayit.Ilce;
            TxtBirlikAdresi.Text = bolgeKayit.BirlikAdresi;
            DtGarantİBasTarihi.Value = bolgeKayit.GarantiBaslama;
            DtGarantİBitTarihi.Value = bolgeKayit.GarantiBitis;
            CmbPypNo.Text = bolgeKayit.PypNo;
            CmbDepo.Text = bolgeKayit.Depo;
            CmbBolgeSorumlusu.Text = bolgeKayit.BolgeSorumlusu;
            dosyaYolu = bolgeKayit.DosyaYolu;
            siparisNo = bolgeKayit.SiparisNo;
            CmbBolgePersonel.Text = bolgeKayit.TepeSorumlusu;
            CmbProjeSistem.Text = bolgeKayit.ProjeSistem;
            CmbMusteri.Text = bolgeKayit.Musteri;

            List<BolgeNot> bolgeNots = new List<BolgeNot>();
            bolgeNots = bolgeNotManager.GetList(id);

            foreach (BolgeNot item in bolgeNots)
            {
                DtgList.Rows.Add();
                int sonSatir = DtgList.RowCount - 1;
                DtgList.Rows[sonSatir].Cells["KayitYapan"].Value = item.KayitYapan;
                DtgList.Rows[sonSatir].Cells["Tarih"].Value = item.Tarih.ToString("g");
                DtgList.Rows[sonSatir].Cells["Not"].Value = item.Not;
            }


            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void BtnGarantiEdit_Click(object sender, EventArgs e)
        {
            FrmGarantiSureleri frmGarantiSureleri = new FrmGarantiSureleri();
            frmGarantiSureleri.siparisNo = siparisNo;
            frmGarantiSureleri.id = id;
            frmGarantiSureleri.infos = infos;
            frmGarantiSureleri.ShowDialog();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
            CmbProjeSistem.SelectedIndex = -1;
        }

        private void CmbBolgeSorumlusu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start==true)
            {
                return;
            }
            List<PersonelKayit> personelKayits = new List<PersonelKayit>();
            personelKayits = personelKayitManager.GetMasrafYeriSorumlusuPer(CmbBolgeSorumlusu.Text);

            PersonelKayit personelKayit = new PersonelKayit(CmbBolgeSorumlusu.SelectedIndex, CmbBolgeSorumlusu.Text);
            personelKayits.Add(personelKayit);

            CmbBolgePersonel.DataSource = personelKayits;
            CmbBolgePersonel.ValueMember = "Id";
            CmbBolgePersonel.DisplayMember = "Adsoyad";
            CmbBolgePersonel.SelectedValue = -1;
        }

        private void CmbProjeSistem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (CmbProjeSistem.SelectedIndex==-1)
            //{
            //    return;
            //}
            //if (CmbBolgeAdi.Text=="")
            //{
            //    return;
            //}

            //CmbProje.DataSource = comboManager.GetListProje(CmbProjeSistem.Text);
            //CmbProje.ValueMember = "Id";
            //CmbProje.DisplayMember = "Baslik";
            //CmbProje.SelectedValue = 0;

            //if (CmbIslemTuru.Text == "GÜNCELLE")
            //{
            //    CmbBolgeAdi.DataSource = bolgeKayitManager.GetListProje(CmbProjeSistem.Text);
            //    CmbBolgeAdi.ValueMember = "Id";
            //    CmbBolgeAdi.DisplayMember = "BolgeAdi";
            //    CmbBolgeAdi.SelectedValue = -1;
            //}
            //else
            //{
            //    BolgeBilgileri();
            //}

            //Temizle();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            DtgList.Rows.Add();
            int sonSatir = DtgList.RowCount - 1;
            DtgList.Rows[sonSatir].Cells["KayitYapan"].Value = infos[1].ToString();
            DtgList.Rows[sonSatir].Cells["Tarih"].Value = DateTime.Now.ToString("g");
            DtgList.Rows[sonSatir].Cells["Not"].Value = TxtNotlar.Text;
            TxtNotlar.Clear();

        }

        private void DtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DtgList.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void BtnExcelAl_Click(object sender, EventArgs e)
        {
            DataTable table = FrmHelper.GetDataTableFromExcel("C:\\Users\\MAYıldırım\\Desktop\\MÜB ŞİKEFTE  YERLEŞİM KAYITLARI.xlsx", "MÜB-4-5-6-7");

            

            //DataTable table = FrmHelper.GetDataTableFromExcel("C:\\Users\\MAYıldırım\\Desktop\\MÜB-4 MUHTEVİYAT LİSTESİ.xlsx", "KARLISIRT Ü.B.");

            DtgEnvanterList.DataSource = null;
            DtgEnvanterList.DataSource = table;
            excelControl = true;
        }

        private void CmbBolgeAdiEkipman_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start==true)
            {
                return;
            }
            if (CmbBolgeAdiEkipman.SelectedIndex==-1)
            {
                LblBolgeKonfig.Text = "00";
                DtgEnvanterList.DataSource = null;
                return;
            }
            BolgeKayit bolge = bolgeKayitManager.Get(CmbBolgeAdiEkipman.SelectedValue.ConInt());
            if (bolge!=null)
            {
                LblBolgeKonfig.Text = bolge.Proje;
                bolgeId = bolge.Id;
                FillData();
            }

        }

        void FillData()
        {
            DtgEnvanterList.DataSource = null;
            List<BolgeEnvanter> bolgeEnvanters = new List<BolgeEnvanter>();
            bolgeEnvanters = bolgeEnvanterManager.GetList(bolgeId);
            DtgEnvanterList.DataSource = bolgeEnvanters;

            DtgEnvanterList.Columns["Id"].Visible = false;
            DtgEnvanterList.Columns["BolgeId"].Visible = false;
            DtgEnvanterList.Columns["Kategori"].HeaderText = "KATEGORİ";
            DtgEnvanterList.Columns["Donanim"].HeaderText = "DONANIM";
            DtgEnvanterList.Columns["StokNo"].HeaderText = "STOK NO";
            DtgEnvanterList.Columns["Tanim"].HeaderText = "TANIM";
            DtgEnvanterList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgEnvanterList.Columns["Birim"].HeaderText = "BİRİM";
            DtgEnvanterList.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgEnvanterList.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgEnvanterList.Columns["Nsn"].HeaderText = "NATO STOK NO";
            DtgEnvanterList.Columns["GuncellemeTarihi"].HeaderText = "SON GÜNCELLEME TARİHİ";
            DtgEnvanterList.Columns["MubBilgisi"].Visible = false;

        }

        private void BtnEkipmanKaydet_Click(object sender, EventArgs e)
        {
            if (DtgEnvanterList.RowCount==0)
            {
                MessageBox.Show("Envanter listesinde veri bulunmamaktadır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (bolgeId==0)
            {
                MessageBox.Show("Lütfen bölge seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr!=DialogResult.Yes)
            {
                return;
            }

            bolgeEnvanterManager.Delete(bolgeId);
            if (excelControl==true)
            {
                foreach (DataGridViewRow item in DtgEnvanterList.Rows)
                {
                    BolgeEnvanter bolgeEnvanter;

                    string[] miktar = item.Cells[4].Value.ToString().Split(' ');
                    if (miktar[0] == "")
                    {
                        //bolgeEnvanter = new BolgeEnvanter(bolgeId, item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString(), item.Cells[2].Value.ToString(),
                        //        item.Cells[3].Value.ToString(), 1, "SET", item.Cells[6].Value.ToString(), item.Cells[7].Value.ToString(), item.Cells[8].Value.ToString(), DateTime.Now, LblBolgeKonfig.Text);
                        //bolgeEnvanterManager.Add(bolgeEnvanter);
                        //continue;
                    }

                    bolgeEnvanter = new BolgeEnvanter(bolgeId, item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString(), item.Cells[2].Value.ToString(),
                                item.Cells[3].Value.ToString(), miktar[0].ConInt(), miktar[1].ToString().ToUpper(), item.Cells[5].Value.ToString(), item.Cells[6].Value.ToString(), item.Cells[7].Value.ToString(), DateTime.Now, LblBolgeKonfig.Text);
                    bolgeEnvanterManager.Add(bolgeEnvanter);
                }
            }

            else
            {
                foreach (DataGridViewRow item in DtgEnvanterList.Rows)
                {
                    BolgeEnvanter bolgeEnvanter = new BolgeEnvanter(item.Cells["BolgeId"].Value.ConInt(), item.Cells["Kategori"].Value.ToString().ToUpper(), item.Cells["Donanim"].Value.ToString().ToUpper(), item.Cells["StokNo"].Value.ToString().ToUpper(),
                                item.Cells["Tanim"].Value.ToString().ToUpper(), item.Cells["Miktar"].Value.ConInt(), item.Cells["Birim"].Value.ToString().ToUpper(), item.Cells["SeriNo"].Value.ToString().ToUpper(), item.Cells["Revizyon"].Value.ToString().ToUpper(), item.Cells["Nsn"].Value.ToString().ToUpper(), DateTime.Now, LblBolgeKonfig.Text);
                    bolgeEnvanterManager.Add(bolgeEnvanter);
                }
            }

            excelControl = false;


            #region EXCEL KAYIT

            //List<BolgeKayit> bolgeKayits = new List<BolgeKayit>();

            //bolgeKayits = bolgeKayitManager.GetList();

            //foreach (BolgeKayit item2 in bolgeKayits)
            //{
            //    if (item2.Proje == "MUB-4")
            //    {
            //        foreach (DataGridViewRow item in DtgEnvanterList.Rows)
            //        {
            //            BolgeEnvanter bolgeEnvanter = new BolgeEnvanter(item2.Id, item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString(), item.Cells[2].Value.ToString(),
            //                item.Cells[3].Value.ToString(), item.Cells[4].Value.ConInt(), item.Cells[5].Value.ToString(), item.Cells[6].Value.ToString(), item.Cells[7].Value.ToString(), item.Cells[8].Value.ToString(), DateTime.Now, item2.Proje);

            //            bolgeEnvanterManager.Add(bolgeEnvanter);
            //        }
            //    }
            //}

            #endregion

            CmbBolgeAdiEkipman.SelectedIndex = -1;
            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void CreateFile()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\BAKIM ONARIM\BÖLGE\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (CmbIslemTuru.Text== "YENİ KAYIT")
            {
                dosyaYolu = subdir + TxtBolgeAdi.Text;
            }
            else
            {
                dosyaYolu = subdir + CmbBolgeAdi.Text;
            }

            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
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

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                webBrowser1.Navigate(dosyaYolu);
            }

        }

        private void BtnKabulTutanak_Click(object sender, EventArgs e)
        {
            CreateFile();
            dosyaControl = true;
        }

        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek isteğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                //if (dosyaControl==false)
                //{
                //    MessageBox.Show("Lütfen bölgeye ait olan teslim tutanağını ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                siparisNo = Guid.NewGuid().ToString();
                BolgeKayit bolgeKayit = new BolgeKayit(TxtBolgeAdi.Text, TxtKodAdi.Text, CmbProje.Text, TxtBolgeStokNo.Text, DtgKabulTarihi.Value, CmbYazilimBilgisi.Text, CmbGozetlemeTuru.Text, CmbYasamAlani.Text, TxtTabur.Text, TxtTugay.Text, CmbIl.Text, CmbIlce.Text, TxtBirlikAdresi.Text, DtGarantİBasTarihi.Value, DtGarantİBitTarihi.Value, CmbBolgeSorumlusu.Text, CmbDepo.Text, CmbPypNo.Text, siparisNo, dosyaYolu, CmbBolgePersonel.Text, CmbProjeSistem.Text, CmbMusteri.Text);

                string mesaj = bolgeKayitManager.Add(bolgeKayit);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int benzersizId = CmbBolgeAdi.SelectedValue.ConInt();
                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    BolgeNot bolgeNot = new BolgeNot(benzersizId, item.Cells["Tarih"].Value.ConDate(), item.Cells["KayitYapan"].Value.ToString(), item.Cells["Not"].Value.ToString());
                    bolgeNotManager.Add(bolgeNot);
                }
                
                dosyaControl = false;
                DtsLogKayit();
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BolgeBilgileri();
                BolgeBilgileriEkipman();
                Temizle();
                CmbProjeSistem.SelectedIndex = -1;
            }
        }
        void DtsLogKayit()
        {
            string islem = CmbBolgeAdi.Text + " bölgesinin bilgileri kaydedilmiştir.";
            DtsLog dtsLog = new DtsLog(infos[1].ToString(), DateTime.Now, "BÖLGE BİLGİLERİ KAYIT", islem);
            dtsLogManager.Add(dtsLog);
        }

        private void BtnGuncelle_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri güncellemek isteğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                if (bolgeAdi != CmbBolgeAdi.Text)
                {
                    bolgeKayitManager.UpdateBolgeAdi(bolgeAdi, CmbBolgeAdi.Text, TxtBirlikAdresi.Text);
                }

                BolgeKayit bolgeKayit = new BolgeKayit(id, CmbBolgeAdi.Text, TxtKodAdi.Text, CmbProje.Text, TxtBolgeStokNo.Text, DtgKabulTarihi.Value, CmbYazilimBilgisi.Text, CmbGozetlemeTuru.Text, CmbYasamAlani.Text, TxtTabur.Text, TxtTugay.Text, CmbIl.Text, CmbIlce.Text, TxtBirlikAdresi.Text, CmbBolgeSorumlusu.Text, CmbDepo.Text, CmbPypNo.Text, DtGarantİBasTarihi.Value, DtGarantİBitTarihi.Value, dosyaYolu, CmbBolgePersonel.Text, CmbProjeSistem.Text, CmbMusteri.Text);

                string mesaj = bolgeKayitManager.Update(bolgeKayit);

                bolgeNotManager.Delete(id);

                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    BolgeNot bolgeNot = new BolgeNot(id, item.Cells["Tarih"].Value.ConDate(), item.Cells["KayitYapan"].Value.ToString(), item.Cells["Not"].Value.ToString());
                    bolgeNotManager.Add(bolgeNot);
                }

                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DtsLogKayitGuncelle();
                BolgeBilgileri();
                MessageBox.Show("Bilgiler başarıyla güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                CmbProjeSistem.SelectedIndex = -1;
            }
        }
        void DtsLogKayitGuncelle()
        {
            string islem = CmbBolgeAdi.Text + " bölgesinin bilgileri güncellenmiştir.";
            DtsLog dtsLog = new DtsLog(infos[1].ToString(), DateTime.Now, "BÖLGE BİLGİLERİ KAYIT", islem);
            dtsLogManager.Add(dtsLog);
        }
    }
}
