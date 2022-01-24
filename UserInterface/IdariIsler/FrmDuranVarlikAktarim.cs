using Business;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using ClosedXML.Excel;
using DataAccess.Concreate;
using DataAccess.Concreate.IdariIsler;
using Entity;
using Entity.IdariIsler;
using Microsoft.Office.Interop.Word;
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
using UserInterface.EgitimDok;
using UserInterface.STS;
using Application = Microsoft.Office.Interop.Word.Application;

namespace UserInterface.IdariIsler
{
    public partial class FrmDuranVarlikAktarim : Form
    {
        DVKayitManager dVKayitManager;
        PersonelKayitManager kayitManager;
        SiparisPersonelManager siparisPersonelManager;
        ZimmetAktarimManager zimmetAktarimManager;
        ZimmetVeriGecmisManager zimmetVeriGecmisManager;
        AracManager aracManager;
        IsAkisNoManager isAkisNoManager;
        AracZimmetiManager aracZimmetiManager;
        AracZimmetiLogManager aracZimmetiLogManager;
        List<ZimmetAktarim> zimmetAktarims = new List<ZimmetAktarim>();
        List<DuranVarlikSonuc> duranVarliks = new List<DuranVarlikSonuc>();
        int id, idAlacak, idAktaracak, idPD, idArac;
        string fotoYolu="", dosyaYolu = "",control1 = "", dosya;
        bool gec = false, devamet2 = false;
        public object[] infos;

        int dvNoArac, isAkisNoArac; string dvEtiketNoArac, dvTanimArac, dvMarka, dvModel, seriNo, durumu, miktar, islemTuru, fotoYoluArac, personelAd = "", dosyaYoluArac = "", masrafYeriNo = "", masrafYeri = "", masYerSorumlusu = "", perosnelBolumu = "";
        public FrmDuranVarlikAktarim()
        {
            InitializeComponent();
            dVKayitManager = DVKayitManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            zimmetAktarimManager = ZimmetAktarimManager.GetInstance();
            zimmetVeriGecmisManager = ZimmetVeriGecmisManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            aracManager = AracManager.GetInstance();
            aracZimmetiManager = AracZimmetiManager.GetInstance();
            aracZimmetiLogManager = AracZimmetiLogManager.GetInstance();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDuranVarlikAktarim"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        int index;
        private void CmbIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CmbIslemTuru.SelectedIndex;
            if (index == 0)
            {
                Grb1.Visible = true;
                Grb2.Visible = false;
                Grb3.Visible = false;
            }
            if (index == 1)
            {
                Grb1.Visible = false;
                Grb2.Visible = true;
                Grb3.Visible = false;
            }
            if (index == 2)
            {
                Grb1.Visible = false;
                Grb2.Visible = false;
                Grb3.Visible = true;
            }
            gec = true;
            Temizle();
        }

        private void FrmDuranVarlikAktarim_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            IsAkisNoArac();
            ZimmetliAraclar();
            Grb1.Visible = false;
            Grb2.Visible = false;
            Grb3.Visible = false;
            Personeller1();
            Personeller2();
            Personeller3();
            Personeller4();
            Personeller5();
            //AddHeaderCheckBox();
            gec = true;
        }
        List<AracZimmeti> aracZimmetis = new List<AracZimmeti>();
        void ZimmetliAraclar()
        {
            aracZimmetis = aracZimmetiManager.GetList();
            dataBinder3.DataSource = aracZimmetis.ToDataTable();
            DtgZimmetLsitesi.DataSource = dataBinder3;
            TxtTop.Text = DtgZimmetLsitesi.RowCount.ToString();

            DtgZimmetLsitesi.Columns["Id"].Visible = false;
            DtgZimmetLsitesi.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgZimmetLsitesi.Columns["IsAkisNo"].DisplayIndex = 1;
            DtgZimmetLsitesi.Columns["Plaka"].HeaderText = "PLAKA";
            DtgZimmetLsitesi.Columns["Marka"].HeaderText = "MARKA";
            DtgZimmetLsitesi.Columns["Model"].HeaderText = "MODEL";
            DtgZimmetLsitesi.Columns["MotorNo"].HeaderText = "MOTOR NO";
            DtgZimmetLsitesi.Columns["SaseNo"].HeaderText = "ŞASE NO";
            DtgZimmetLsitesi.Columns["MulkiyetBilgileri"].HeaderText = "MÜLKİYET BİLGİLERİ";
            DtgZimmetLsitesi.Columns["SiparisNo"].HeaderText = "SİPARİŞ NO";
            DtgZimmetLsitesi.Columns["ProjeTahsisTarihi"].HeaderText = "PROJEYE TAHSİS TARİHİ";
            DtgZimmetLsitesi.Columns["PersonelAd"].HeaderText = "PERSONEL AD SOYAD";
            DtgZimmetLsitesi.Columns["SicilNo"].HeaderText = "SİCİL NO";
            DtgZimmetLsitesi.Columns["MasrafYeriNo"].HeaderText = "MASRAF YERİ NO";
            DtgZimmetLsitesi.Columns["MasrafYeri"].HeaderText = "MASRAF YERİ";
            DtgZimmetLsitesi.Columns["MasYerSor"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgZimmetLsitesi.Columns["Bolum"].HeaderText = "BÖLÜMÜ";
            DtgZimmetLsitesi.Columns["AktarimTarihi"].HeaderText = "AKTARIM TARİHİ";
            DtgZimmetLsitesi.Columns["Gerekce"].HeaderText = "AKTARIM GEREKÇESİ";
            DtgZimmetLsitesi.Columns["Km"].HeaderText = "KİLOMETRE";
            DtgZimmetLsitesi.Columns["DosyYolu"].Visible = false;
        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        void IsAkisNoArac()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LbIsAkisNoArac.Text = isAkis.Id.ToString();
        }
        /*System.Windows.Forms.CheckBox HeaderCheckBox = null;

        private void AddHeaderCheckBox()
        {
            HeaderCheckBox = new System.Windows.Forms.CheckBox();
            HeaderCheckBox.Size = new Size(15, 15);
            this.DtgPersonelZimmetleri.Controls.Add(HeaderCheckBox);
        }*/
        public void YenilenecekVeri()
        {
            IsAkisNo();
            ZimmetliAraclar();
            /*gec = false;
            Temizle();
            Personeller1();
            Personeller2();
            Personeller3();
            Personeller4();
            Grb1.Visible = false;
            Grb2.Visible = false;
            Grb3.Visible = false;
            CmbIslemTuru.SelectedValue = "";*/
        }
        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtDvEtiketNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle DURAN VARLIK ETİKET NO bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DuranVarlikKayit duranVarlikKayit = dVKayitManager.Get(TxtDvEtiketNo.Text);
            if (duranVarlikKayit == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                return;
            }
            id = duranVarlikKayit.Id;
            TxtDVNo.Text = duranVarlikKayit.IsAkisNo.ToString();
            TxtDVTanimi.Text = duranVarlikKayit.DvTanim;
            TxtMarka.Text = duranVarlikKayit.Marka;
            TxtModel.Text = duranVarlikKayit.Model;
            TxtSeriNo.Text = duranVarlikKayit.SeriNo;
            TxtDurumu.Text = duranVarlikKayit.Durumu;
            TxtMiktar.Text = duranVarlikKayit.Miktar;
            fotoYolu = duranVarlikKayit.FotoYolu;
            PctBox.ImageLocation = fotoYolu;
        }
        void Personeller1()
        {
            CmbAdDP.DataSource = kayitManager.PersonelAdSoyad();
            CmbAdDP.ValueMember = "Id";
            CmbAdDP.DisplayMember = "Adsoyad";
            CmbAdDP.SelectedValue = -1;
        }
        void Personeller2()
        {
            CmbAdPPAlacak.DataSource = kayitManager.PersonelAdSoyad();
            CmbAdPPAlacak.ValueMember = "Id";
            CmbAdPPAlacak.DisplayMember = "Adsoyad";
            CmbAdPPAlacak.SelectedValue = -1;
        }
        void Personeller3()
        {
            CmbAdPPAktaracak.DataSource = kayitManager.PersonelAdSoyad();
            CmbAdPPAktaracak.ValueMember = "Id";
            CmbAdPPAktaracak.DisplayMember = "Adsoyad";
            CmbAdPPAktaracak.SelectedValue = -1;
        }
        void Personeller4()
        {
            CmbAdPD.DataSource = kayitManager.PersonelAdSoyad();
            CmbAdPD.ValueMember = "Id";
            CmbAdPD.DisplayMember = "Adsoyad";
            CmbAdPD.SelectedValue = -1;
        }
        void Personeller5()
        {
            CmpPersonelArac.DataSource = kayitManager.PersonelAdSoyad();
            CmpPersonelArac.ValueMember = "Id";
            CmpPersonelArac.DisplayMember = "Adsoyad";
            CmpPersonelArac.SelectedValue = -1;
        }
        void Temizle()
        {
            while (AdvMalzemeOnizleme.Rows.Count > 0)
            {
                AdvMalzemeOnizleme.Rows.RemoveAt(0);
            }
            while (DtgList.Rows.Count > 0)
            {
                DtgList.Rows.RemoveAt(0);
            }
            TxtDvEtiketNo.Clear(); TxtDVNo.Clear(); TxtDVTanimi.Clear(); TxtMarka.Clear(); TxtModel.Clear(); TxtSeriNo.Clear(); TxtDurumu.Clear(); TxtMiktar.Clear(); PctBox.ImageLocation = ""; CmbAdPPAlacak.Text = ""; TxtSicilPPAlacak.Clear(); TxtMasrafYeriNoPPAlacak.Clear(); TxtMasrafYeriPPAlacak.Clear(); TxtMasrafYeriSorumlusuPPAlacak.Clear(); TxtBolumPPAlacak.Clear(); CmbAdPPAktaracak.Text = ""; TxtSicilPPAktaracak.Clear(); TxtMasrafYeriNoPPAktaracak.Clear(); TxtMasrafYeriPPAktaracak.Clear(); TxtMasrafYeriSorumlusuPPAktaracak.Clear(); TxtBolumPPAktaracak.Clear(); TxtAktarimGerekcesiPP.Clear(); CmbAdPD.Text = ""; TxtSicilPD.Clear(); TxtMasrafYeriNoPD.Clear(); TxtMasrafYeriPD.Clear(); TxtMasYeriSorPD.Clear(); TxtBolumPD.Clear(); CmbDepoAdresi.Text = ""; CmbLokasyon.Text = ""; CmbLokasyonBilgi.Text = ""; TxtAktarimGerekcesiPD.Clear(); CmbIslemTuru.SelectedValue = ""; CmbAdDP.Text = ""; TxtSicilDP.Clear(); TxtMasrafYeriNoDP.Clear(); TxtMasrafYeriDP.Clear(); TxtMasYeriSorDP.Clear(); TxtBolumDP.Clear(); TxtAktarimGerekcesiDP.Clear();
        }

        private void CmbAdPD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gec == false)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbAdPD.Text);
            TxtSicilPD.Text = siparis.Sicil;
            TxtMasrafYeriNoPD.Text = siparis.Masrafyerino;
            TxtMasrafYeriPD.Text = siparis.Masrafyeri;
            id = siparis.Id;
            TxtBolumPD.Text = siparis.Bolum;
            TxtMasYeriSorPD.Text = siparis.MasrafYeriSorumlusu;

        }
        private void BtnListeyeEkle_Click(object sender, EventArgs e)
        {
            if (index==1 || index==2)
            {
                MessageBox.Show("Bu İşlem Sadece DEPODAN PERSONELE İşleminde Geçerlidir!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (TxtDvEtiketNo.Text == "")
            {
                MessageBox.Show("Lütfen DV ETİKET NO Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string control = Control();
            if (control != "")
            {
                MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string mesaj = ZimmetControl();
            if (mesaj != "")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            control1 = TxtDvEtiketNo.Text;
            foreach (DataGridViewRow item in DtgList.Rows)
            {
                if (item.Cells["DvEtiketNo"].Value.ToString() == control1)
                {
                    MessageBox.Show("Aynı Duran Varliğı Listeye İkinci Kez Ekleyemezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            duranVarliks.Add(new DuranVarlikSonuc(TxtDVNo.Text.ConInt(), TxtDvEtiketNo.Text, TxtDVTanimi.Text, TxtMarka.Text, TxtModel.Text, TxtSeriNo.Text, TxtDurumu.Text, TxtMiktar.Text));
            dataBinder.DataSource = duranVarliks.ToDataTable();
            DtgList.DataSource = dataBinder;
            control1 = TxtDvEtiketNo.Text;


            /*DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Dvno"].HeaderText = "DURAN VARLIK NO";
            DtgList.Columns["DvEtiketNo"].HeaderText = "DV ETİKET NO";
            DtgList.Columns["DvTanim"].HeaderText = "DV TANIM";
            DtgList.Columns["DvMarka"].HeaderText = "MARKA";
            DtgList.Columns["DvModel"].HeaderText = "MODEL";
            DtgList.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgList.Columns["Durumu"].HeaderText = "DURUMU";
            DtgList.Columns["Miktar"].HeaderText = "MİKTAR";*/
        }
        string ZimmetControl()
        {
            if (index == 0)
            {
                string adsoyad;
                ZimmetAktarim zimmet = zimmetAktarimManager.Get(TxtDvEtiketNo.Text);
                if (zimmet != null)
                {
                    adsoyad = zimmet.PersonelAd;
                    if (adsoyad != "")
                    {
                        return TxtDvEtiketNo.Text + " Etiket Numaralı Duran Varlık " + adsoyad + " Adlı Personele Zimmetlidir, İşlem Türü Olarak PERSONELDEN PERSONELE Adımlarını İzleyebilirsiniz!";
                    }
                }
            }
            if (index == 1)
            {
                string adsoyad;
                ZimmetAktarim zimmet = zimmetAktarimManager.Get(TxtDvEtiketNo.Text);
                if (zimmet.PersonelAd != CmbAdPD.Text)
                {
                    return TxtDvEtiketNo.Text + " Etiket Numaralı Zimmet " + zimmet.PersonelAd + " Adlı Personele Aittir!";
                }
                if (zimmet != null)
                {
                    adsoyad = zimmet.PersonelAd;
                    if (adsoyad == "")
                    {
                        return TxtDvEtiketNo.Text + " Etiket Numaralı Duran Varlık Herhangi Bir Personel Üzerine Zimmetli Değildir!";
                    }
                }

            }
            if (index == 2)
            {
                string adsoyad;
                ZimmetAktarim zimmet = zimmetAktarimManager.Get(TxtDvEtiketNo.Text);
                if (zimmet.PersonelAd != CmbAdPPAktaracak.Text)
                {
                    return TxtDvEtiketNo.Text + " Etiket Numaralı Zimmet " + zimmet.PersonelAd + " Adlı Personele Aittir!";
                }
                if (zimmet != null)
                {
                    adsoyad = zimmet.PersonelAd;
                    if (adsoyad == "")
                    {
                        return TxtDvEtiketNo.Text + " Etiket Numaralı Duran Varlık Herhangi Bir Personel Üzerine Zimmetli Değildir! İşlem Türü Olarak DEPODAN PERSONELE Adımlarını İzleyebilirsiniz. ";
                    }
                }
                else
                {
                    return TxtDvEtiketNo.Text + " Etiket Numaralı Duran Varlık Herhangi Bir Personel Üzerine Zimmetli Değildir! İşlem Türü Olarak DEPODAN PERSONELE Adımlarını İzleyebilirsiniz. ";
                }
            }
            return "";
        }
        void ListeyiTemizle()
        {
            while (DtgList.Rows.Count > 0)
            {
                DtgList.Rows.RemoveAt(0);
            }
            while (AdvMalzemeOnizleme.Rows.Count > 0)
            {
                AdvMalzemeOnizleme.Rows.RemoveAt(0);
            }
            control1 = "";
            duranVarliks.Clear();
        }
        private void BtnListeyiTemizle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tüm Listeyi Temizlemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ListeyiTemizle();
            }
        }
        string Control()
        {
            if (TxtDvEtiketNo.Text == "" || TxtDVNo.Text == "")
            {
                return "Lütfen Öncelikle Duran Varlık Bilgilerini Giriniz!";
            }
            if (CmbIslemTuru.Text == "")
            {
                return "Lütfen Öncelikle İşlem Türü Seçiniz!";
            }
            if (index == 0)
            {
                if (CmbAdDP.Text == "")
                {
                    return "Lütfen Öncelikle Zimmet Aktarımının Yapılacağı Personeli Seçiniz!";
                }
                if (TxtAktarimGerekcesiDP.Text == "")
                {
                    return "Lütfen Aktarım Gerekçesini Boş Geçmeyiniz!";
                }
            }
            if (index == 1)
            {
                if (CmbAdPD.Text == "")
                {
                    return "Lütfen Öncelikle Personel Bilgisini Seçiniz!";
                }
                if (CmbDepoAdresi.Text == "")
                {
                    return "Lütfen Depo Adresi Bilgisini Seçiniz!";
                }
                if (CmbLokasyon.Text == "")
                {
                    return "Lütfen Lokasyon Bilgisini Seçiniz!";
                }
                if (TxtAktarimGerekcesiPD.Text == "")
                {
                    return "Lütfen Aktarım Gerekçesi Bilgisini Giriniz!";
                }
            }
            if (index == 2)
            {
                if (CmbAdPPAlacak.Text == "")
                {
                    if (CmbAdPPAktaracak.Text == "")
                    {
                        return "Lütfen Öncelikle Zimmet Aktaracak Olan Personel Bilgisini Seçiniz!";
                    }
                    return "Lütfen Öncelikle Zimmet Alacak Olan Personel Bilgisini Seçiniz!";
                }
                if (TxtAktarimGerekcesiPP.Text == "")
                {
                    return "Lütfen Aktarım Gerekçesi Bilgisini Giriniz!";
                }
            }
            return "";
        }

        void CreateDirectory()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\DURAN VARLIK\";
            string anadosya2 = @"Z:\DTS\İDARİ İŞLER\DURAN VARLIK\ZİMMET AKTARIM\";

            /*string root = @"D:\DTS";
            string subdir = @"D:\DTS\İDARİ İŞLER\";
            string anadosya = @"D:\DTS\İDARİ İŞLER\YURT İÇİ GÖREV\";*/
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
            dosya = anadosya2 + LblIsAkisNo.Text + "\\";
            Directory.CreateDirectory(dosya);
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (DtgList.RowCount == 0)
            {
                MessageBox.Show("Listede Duran Varlik Kaydı Bulunamamıştır. Lütfen Listeye Duran Varlık Ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IsAkisNo();
                CreateDirectory();
                List<ZimmetAktarim> zimmetAktarimlar = new List<ZimmetAktarim>();
                if (index == 0) // DEPODAN PERSONELE
                {
                    foreach (DataGridViewRow item in DtgList.Rows)
                    {
                        ZimmetAktarim zimmetAktarim = new ZimmetAktarim(item.Cells["DvNo"].Value.ConInt(), LblIsAkisNo.Text.ConInt(), item.Cells["DvEtiketNo"].Value.ToString(), item.Cells["Tanim"].Value.ToString(), item.Cells["Marka"].Value.ToString(), item.Cells["Model"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Durumu"].Value.ToString(), item.Cells["Miktar"].Value.ToString(), CmbIslemTuru.Text, CmbAdDP.Text, TxtSicilDP.Text, TxtMasrafYeriNoDP.Text, TxtMasrafYeriDP.Text, TxtMasYeriSorDP.Text, TxtBolumDP.Text, DtDP.Text.ToString(), "", "", "", TxtAktarimGerekcesiDP.Text, fotoYolu, dosyaYolu);

                        string etiketno = item.Cells["DvEtiketNo"].Value.ToString();

                        zimmetAktarimManager.Add(zimmetAktarim);
                        zimmetAktarimManager.Delete(etiketno, "");

                        ZimmetVeriGecmis zimmetVeriGecmis = new ZimmetVeriGecmis(item.Cells["DvNo"].Value.ConInt(), LblIsAkisNo.Text.ConInt(), item.Cells["DvEtiketNo"].Value.ToString(), item.Cells["Tanim"].Value.ToString(), item.Cells["Marka"].Value.ToString(), item.Cells["Model"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Durumu"].Value.ToString(), item.Cells["Miktar"].Value.ToString(), CmbIslemTuru.Text, infos[1].ToString(), "", "", "", "", "", "", DtDP.Value, CmbAdDP.Text, TxtSicilDP.Text, TxtMasrafYeriNoDP.Text, TxtMasrafYeriDP.Text, TxtMasYeriSorDP.Text, TxtBolumDP.Text, TxtAktarimGerekcesiDP.Text, "", "", "", dosyaYolu);

                        zimmetVeriGecmisManager.Add(zimmetVeriGecmis);
                    }
                }
                if (index == 1) // PERSONELDEN DEPOYA
                {
                    foreach (DataGridViewRow item in DtgList.Rows)
                    {
                        ZimmetAktarim zimmetAktarim = new ZimmetAktarim(item.Cells["DvNo"].Value.ConInt(), LblIsAkisNo.Text.ConInt(), item.Cells["DvEtiketNo"].Value.ToString(), item.Cells["Tanim"].Value.ToString(), item.Cells["Marka"].Value.ToString(), item.Cells["Model"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Durumu"].Value.ToString(), item.Cells["Miktar"].Value.ToString(), CmbIslemTuru.Text, "", "", "", "", "", "", DTPD.Text.ToString(), CmbDepoAdresi.Text, CmbLokasyon.Text, CmbLokasyonBilgi.Text, TxtAktarimGerekcesiPD.Text, fotoYolu, dosyaYolu);

                        zimmetAktarimlar.Add(zimmetAktarim);

                        string etiketno = item.Cells["DvEtiketNo"].Value.ToString();
                        zimmetAktarimManager.Add(zimmetAktarim);
                        zimmetAktarimManager.Delete(etiketno, CmbAdPD.Text);

                        ZimmetVeriGecmis zimmetVeriGecmis = new ZimmetVeriGecmis(item.Cells["DvNo"].Value.ConInt(), item.Cells["DvEtiketNo"].Value.ToString(), item.Cells["Tanim"].Value.ToString(), item.Cells["Marka"].Value.ToString(), item.Cells["Model"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Durumu"].Value.ToString(), item.Cells["Miktar"].Value.ToString(), CmbIslemTuru.Text, infos[1].ToString(), CmbAdPD.Text, TxtSicilPD.Text, TxtMasrafYeriNoPD.Text, TxtMasrafYeriPD.Text, TxtMasYeriSorPD.Text, TxtBolumPD.Text, DTPD.Value, "", "", "", "", "", "", TxtAktarimGerekcesiPD.Text, CmbDepoAdresi.Text, CmbLokasyon.Text, CmbLokasyonBilgi.Text, dosyaYolu);

                        zimmetVeriGecmisManager.Add(zimmetVeriGecmis);

                        if (zimmetAktarimlar.Count > 0)
                        {
                            IXLWorkbook workbook = new XLWorkbook(@"Z:\DTS\EĞİTİM DOKÜMANTASYON\STANDART FORMLAR\MP-FR-027 DURAN VARLIK AKTARIM FORMU REV (00)\MP-FR-027 DURAN VARLIK AKTARIM FORMU REV (00).xlsx");
                            IXLWorksheet worksheet = workbook.Worksheet("MG 3033 A");
                            var range = worksheet.Range("B13", "F32");
                            range.Clear();
                            range = worksheet.Range("A13", "F32");
                            var row = range.Row(1);

                            foreach (ZimmetAktarim zimmet in zimmetAktarimlar)
                            {
                                row.Cell("B").Value = zimmet.DvEtiketNo;
                                row.Cell("C").Value = zimmet.Dvno;
                                row.Cell("D").Value = zimmet.DvTanim;
                                row.Cell("F").Value = zimmet.AktarimGerekcesi;
                                worksheet.Range(row.RowNumber(), 4, row.RowNumber(), 5).Row(1).Merge();
                                row = row.RowBelow(); //Bir Alt Satıra Geçirir
                            }
                            range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                            worksheet.Cell("E35").Value = CmbAdPD.Text; 
                            worksheet.Cell("E36").Value = TxtBolumPD.Text;
                            worksheet.Cell("E37").Value = TxtMasrafYeriNoPD.Text;
                            worksheet.Cell("E38").Value = TxtMasYeriSorPD.Text;
                            worksheet.Cell("F35").Value = infos[1].ToString(); // TESLİM ALAN
                            worksheet.Cell("F36").Value = infos[3].ToString(); // TESLİM ALAN BÖLÜM
                            worksheet.Cell("F37").Value = infos[5].ToString(); // TESLİM ALAN MASRAF YERŞ NO
                            worksheet.Cell("F38").Value = infos[8].ToString(); // TESLİM ALAN MAS YER SORUMLUSU

                            workbook.SaveAs(dosya + "\\Excel_File.xlsx");
                            //workbook.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Excel_File.xlsx");
                            workbook.Dispose();
                        }
                    }
                }
                if (index == 2) // PERSONELDEN PERSONELE
                {
                    foreach (DataGridViewRow item in DtgList.Rows)
                    {
                        ZimmetAktarim zimmetAktarim = new ZimmetAktarim(item.Cells["DvNo"].Value.ConInt(), LblIsAkisNo.Text.ConInt(), item.Cells["DvEtiketNo"].Value.ToString(), item.Cells["Tanim"].Value.ToString(), item.Cells["Marka"].Value.ToString(), item.Cells["Model"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Durumu"].Value.ToString(), item.Cells["Miktar"].Value.ToString(), CmbIslemTuru.Text, CmbAdPPAlacak.Text, TxtSicilPPAlacak.Text, TxtMasrafYeriNoPPAlacak.Text, TxtMasrafYeriPPAlacak.Text, TxtMasrafYeriSorumlusuPPAlacak.Text, TxtBolumPPAlacak.Text, DtPP.Text.ToString(), "", "", "", TxtAktarimGerekcesiPP.Text, fotoYolu, dosyaYolu);

                        zimmetAktarimlar.Add(zimmetAktarim);

                        string etiketno = item.Cells["DvEtiketNo"].Value.ToString();
                        zimmetAktarimManager.Add(zimmetAktarim); // zimmet personele eklendi
                        zimmetAktarimManager.Delete(etiketno, CmbAdPPAktaracak.Text); // zimmet personelden alındı

                        ZimmetVeriGecmis zimmetVeriGecmis = new ZimmetVeriGecmis(item.Cells["DvNo"].Value.ConInt(), item.Cells["DvEtiketNo"].Value.ToString(), item.Cells["Tanim"].Value.ToString(), item.Cells["Marka"].Value.ToString(), item.Cells["Model"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Durumu"].Value.ToString(), item.Cells["Miktar"].Value.ToString(), CmbIslemTuru.Text, infos[1].ToString(), CmbAdPPAktaracak.Text, TxtSicilPPAktaracak.Text, TxtMasrafYeriNoPPAktaracak.Text, TxtMasrafYeriPPAktaracak.Text, TxtMasrafYeriSorumlusuPPAktaracak.Text, TxtBolumPPAktaracak.Text, DtPP.Value, CmbAdPPAlacak.Text, TxtSicilPPAlacak.Text, TxtMasrafYeriNoPPAlacak.Text, TxtMasrafYeriPPAlacak.Text, TxtMasrafYeriSorumlusuPPAlacak.Text, TxtBolumPPAlacak.Text, TxtAktarimGerekcesiPP.Text, "", "", "", dosyaYolu);

                        zimmetVeriGecmisManager.Add(zimmetVeriGecmis); // zimmet veri geçmişe kaydedildi.
                    }
                    if (zimmetAktarimlar.Count > 0)
                    {
                        IXLWorkbook workbook = new XLWorkbook(@"Z:\DTS\EĞİTİM DOKÜMANTASYON\STANDART FORMLAR\MP-FR-027 DURAN VARLIK AKTARIM FORMU REV (00)\MP-FR-027 DURAN VARLIK AKTARIM FORMU REV (00).xlsx");
                        IXLWorksheet worksheet = workbook.Worksheet("MG 3033 A");
                        var range = worksheet.Range("B13", "F32");
                        range.Clear();
                        range = worksheet.Range("A13", "F32");
                        var row = range.Row(1);

                        foreach (ZimmetAktarim item in zimmetAktarimlar)
                        {
                            row.Cell("B").Value = item.DvEtiketNo;
                            row.Cell("C").Value = item.Dvno;
                            row.Cell("D").Value = item.DvTanim;
                            row.Cell("F").Value = item.AktarimGerekcesi;
                            worksheet.Range(row.RowNumber(), 4, row.RowNumber(), 5).Row(1).Merge();
                            row = row.RowBelow(); //Bir Alt Satıra Geçirir
                        }
                        range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                        worksheet.Cell("E35").Value = CmbAdPPAktaracak.Text;
                        worksheet.Cell("E36").Value = TxtBolumPPAktaracak.Text;
                        worksheet.Cell("E37").Value = TxtMasrafYeriNoPPAktaracak.Text;
                        worksheet.Cell("E38").Value = TxtMasrafYeriSorumlusuPPAktaracak.Text;
                        worksheet.Cell("F35").Value = CmbAdPPAlacak.Text; // TESLİM ALAN
                        worksheet.Cell("F36").Value = TxtBolumPPAlacak; // TESLİM ALAN BÖLÜM
                        worksheet.Cell("F37").Value = TxtMasrafYeriNoPPAlacak.Text; // TESLİM ALAN MASRAF YERİ NO
                        worksheet.Cell("F38").Value = TxtMasrafYeriSorumlusuPPAlacak.Text; // TESLİM ALAN MAS YER SORUMLUSU

                        workbook.SaveAs(dosya + "\\Excel_File.xlsx");
                        workbook.Dispose();
                    }
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                ListeyiTemizle();
                IsAkisNo();
            }

        }

        private void DtgZimmetLsitesi_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder3.Filter = DtgZimmetLsitesi.FilterString;
            TxtTop.Text = DtgZimmetLsitesi.RowCount.ToString();
        }

        private void DtgZimmetLsitesi_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder3.Sort = DtgZimmetLsitesi.SortString;
        }

        void CreateDirectoryDP()
        {
            /*string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\DURAN VARLIK AKTARIM\";*/

            string root = @"D:\DTS";
            string subdir = @"D:\DTS\İDARİ İŞLER\";
            string anadosya = @"D:\DTS\İDARİ İŞLER\DURAN VARLIK AKTARIM\";
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
            dosyaYolu = anadosya + TxtDvEtiketNo.Text + "\\";
            Directory.CreateDirectory(dosyaYolu);
        }

        private void CmbLokasyon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexLokasyon = CmbLokasyon.SelectedIndex;
            CmbLokasyonBilgi.SelectedIndex = indexLokasyon;
        }

        private void BtnZimmetGor_Click(object sender, EventArgs e)
        {
            while (AdvMalzemeOnizleme.Rows.Count > 0)
            {
                AdvMalzemeOnizleme.Rows.RemoveAt(0);
            }
            while (DtgList.Rows.Count > 0)
            {
                DtgList.Rows.RemoveAt(0);
            }
            if (CmbAdPPAktaracak.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Zimmetleri Listelenecek Personeli Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            zimmetAktarims = zimmetAktarimManager.PersonelZimmeti(CmbAdPPAktaracak.Text);
            foreach (ZimmetAktarim item in zimmetAktarims)
            {
                AdvMalzemeOnizleme.Rows.Add(item.Dvno, item.DvEtiketNo, item.DvTanim, item.DvMarka, item.DvModel, item.SeriNo, item.Durumu, item.Miktar);
            }
        }

        private void DtgPersonelZimmetleri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0) 
            {
                AdvMalzemeOnizleme
            }*/
        }

        private void AdvMalzemeOnizleme_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void BtnListeyeAktar_Click(object sender, EventArgs e)
        {
            //Sadece DtgListte gözüken başlıklar için yeni entity lazım
            if (index==0)
            {
                MessageBox.Show("Toplu Aktarım İşlemi Sadece PERSONELDEN PERSONELE Veya PERSONELDEN DEPOYA İşlemlerinde Geçerlidir!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            

            List<DuranVarlikSonuc> aktarilacaklar = new List<DuranVarlikSonuc>();
            
            

            foreach (DataGridViewRow row in AdvMalzemeOnizleme.Rows)
            {
                if (row.Cells["ChkBox"].Value.ConBool())
                {
                    if (DtgList.RowCount == 20)
                    {
                        MessageBox.Show("20 Barajı Geçildi");
                        return;
                    }
                    aktarilacaklar.Add(
                       new DuranVarlikSonuc(row.Cells["DvNoP"].Value.ConInt(), row.Cells["DvEtiketNoP"].Value.ToString(), row.Cells["DvTanimP"].Value.ToString(), row.Cells["MarkaP"].Value.ToString(), row.Cells["ModelP"].Value.ToString(),
                       row.Cells["SeriNoP"].Value.ToString(), row.Cells["DurumuP"].Value.ToString(),
                       row.Cells["MiktarP"].Value.ToString())
                       );
                }
            }
            

            for (int i = 0; i < AdvMalzemeOnizleme.RowCount; i++)
            {
                if (AdvMalzemeOnizleme.Rows[i].Cells["ChkBox"].Value.ConBool())
                {
                    AdvMalzemeOnizleme.Rows.RemoveAt(AdvMalzemeOnizleme.Rows[i].Index);
                    i--;
                }
            }

            dataBinder.DataSource = aktarilacaklar.ToDataTable();
            DtgList.DataSource = dataBinder;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IXLWorkbook workbook = new XLWorkbook(@"C:\Users\MAYıldırım\Desktop\MÜB PROJE DİREKTÖRLÜĞÜ DEMİRBAŞ & ENVANTER LİSTESİ.xlsx");
            IXLWorksheets sheets = workbook.Worksheets;
            IXLWorksheet worksheet = workbook.Worksheet("DEMİRBAŞ LİSTESİ");
            var rows = worksheet.Rows(2, 2349);
            DateTime outDate = DateTime.Now;
            //double outDouble = 0;
            foreach (IXLRow item in rows)
            {
                ZimmetAktarim yakits = new ZimmetAktarim(
                    item.Cell("A").Value.ConInt(), // İŞ AKIŞ NO
                    0,
                    item.Cell("E").Value.ToString(),
                    item.Cell("F").Value.ToString(),
                    item.Cell("H").Value.ToString(),
                    item.Cell("I").Value.ToString(),
                    item.Cell("J").Value.ToString(),
                    item.Cell("AB").Value.ToString(),
                    item.Cell("G").Value.ToString(),
                    "",
                    item.Cell("P").Value.ToString(),
                    "",
                    item.Cell("N").Value.ToString(),
                    item.Cell("O").Value.ToString(),
                    "",
                    item.Cell("M").Value.ToString(),
                    item.Cell("Q").Value.ToString(),
                    item.Cell("M").Value.ToString(),
                    "",
                    "",
                    "",
                    "",
                    ""
                    );
                zimmetAktarimManager.Add(yakits);
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            AracTemile();
        }

        private void DtgZimmetLsitesi_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgZimmetLsitesi.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            TxtPlaka.Text= DtgZimmetLsitesi.CurrentRow.Cells["Plaka"].Value.ToString();
            TxtMarkasi.Text= DtgZimmetLsitesi.CurrentRow.Cells["Marka"].Value.ToString();
            TxtModelYili.Text= DtgZimmetLsitesi.CurrentRow.Cells["Model"].Value.ToString();
            TxtMotorNo.Text= DtgZimmetLsitesi.CurrentRow.Cells["MotorNo"].Value.ToString();
            TxtSaseNo.Text= DtgZimmetLsitesi.CurrentRow.Cells["SaseNo"].Value.ToString();
            TxtMulkiyet.Text= DtgZimmetLsitesi.CurrentRow.Cells["MulkiyetBilgileri"].Value.ToString();
            TxtSiparisNo.Text= DtgZimmetLsitesi.CurrentRow.Cells["SiparisNo"].Value.ToString();
            DtProjeTahsisTarihi.Value= DtgZimmetLsitesi.CurrentRow.Cells["ProjeTahsisTarihi"].Value.ConTime();
            CmpPersonelArac.Text= DtgZimmetLsitesi.CurrentRow.Cells["PersonelAd"].Value.ToString();
            DtgAktarimTarihiArac.Value= DtgZimmetLsitesi.CurrentRow.Cells["AktarimTarihi"].Value.ConTime();
            TxkKm.Text= DtgZimmetLsitesi.CurrentRow.Cells["Km"].Value.ToString();
            TxtAktariGerekcesiArac.Text= DtgZimmetLsitesi.CurrentRow.Cells["Gerekce"].Value.ToString();
        }

        private void CmbAdPPAlacak_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (gec == false)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbAdPPAlacak.Text);
            TxtSicilPPAlacak.Text = siparis.Sicil;
            TxtMasrafYeriNoPPAlacak.Text = siparis.Masrafyerino;
            TxtMasrafYeriPPAlacak.Text = siparis.Masrafyeri;
            idAlacak = siparis.Id;
            TxtBolumPPAlacak.Text = siparis.Bolum;
            TxtMasrafYeriSorumlusuPPAlacak.Text = siparis.MasrafYeriSorumlusu;
        }

        private void BtnLogGor_Click(object sender, EventArgs e)
        {
            FrmAracZimmetiLogKayitlari frmAracZimmetiLogKayitlari = new FrmAracZimmetiLogKayitlari();
            frmAracZimmetiLogKayitlari.ShowDialog();
        }

        private void TxkKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void BtnBulArac_Click(object sender, EventArgs e)
        {
            if (TxtPlaka.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Plaka Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Arac arac = aracManager.Get(TxtPlaka.Text);
            ZimmetAktarim zimmetAktarim = zimmetAktarimManager.AracZimmetBilgileri("%" + TxtPlaka.Text + '%'); // DURNAN VARLIK ZİMMET LİSTESİ
            AracZimmeti aracZimmeti = aracZimmetiManager.Get(TxtPlaka.Text); // ARAÇ ZİMMET LİSTESİ 
            if (arac == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AracTemile();
                return;
            }
            TxtMarkasi.Text = arac.Markasi;
            TxtModelYili.Text = arac.ModelYili;
            TxtMotorNo.Text = arac.MotorNo;
            TxtSaseNo.Text = arac.SaseNo;
            TxtMulkiyet.Text = arac.MulkiyetBilgileri;
            TxtSiparisNo.Text = arac.Siparisno;
            DtProjeTahsisTarihi.Value = arac.ProjeTahsisTarihi;
            if (aracZimmeti == null)
            {
                if (zimmetAktarim == null)
                {
                    CmpPersonelArac.Text = "";
                    masrafYeriNo = "";
                    masrafYeri = "";
                    masYerSorumlusu = "";
                    perosnelBolumu = "";
                    return;
                }
                personelAd = zimmetAktarim.PersonelAd;
                masrafYeriNo = zimmetAktarim.MasYeriNo;
                masrafYeri = zimmetAktarim.MasYeri;
                masYerSorumlusu = zimmetAktarim.MasYeriSorumlusu;
                perosnelBolumu = zimmetAktarim.Bolum;
                CmpPersonelArac.Text = personelAd;
                dvNoArac = zimmetAktarim.Dvno.ConInt();
                isAkisNoArac = zimmetAktarim.IsAkisNo.ConInt();
                dvEtiketNoArac = zimmetAktarim.DvEtiketNo;
                dvTanimArac = zimmetAktarim.DvTanim;
                dvMarka = zimmetAktarim.DvMarka;
                dvModel = zimmetAktarim.DvModel;
                seriNo = zimmetAktarim.SeriNo;
                durumu = zimmetAktarim.Durumu;
                miktar = zimmetAktarim.Miktar;
                islemTuru = zimmetAktarim.IslemTuru;
                fotoYoluArac = zimmetAktarim.FotoYolu;
                dosyaYoluArac = zimmetAktarim.DosyaYolu;
                if (masrafYeriNo == null)
                {
                    masrafYeriNo = "";
                }
                if (masrafYeri == null)
                {
                    masrafYeri = "";
                }
                if (masYerSorumlusu == null)
                {
                    masYerSorumlusu = "";
                }
                if (perosnelBolumu == null)
                {
                    perosnelBolumu = "";
                }
                return;
            }
            personelAd = aracZimmeti.PersonelAd;
            CmpPersonelArac.Text = personelAd;
            masrafYeriNo = aracZimmeti.MasrafYeriNo;
            masrafYeri = aracZimmeti.MasrafYeri;
            masYerSorumlusu = aracZimmeti.MasYerSor;
            perosnelBolumu = aracZimmeti.Bolum;
            isAkisNoArac = aracZimmeti.IsAkisNo;
        }

        private void BtnKaydetArac_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IsAkisNoArac();
                AracZimmeti aracZimmeti = new AracZimmeti(LbIsAkisNoArac.Text.ConInt(), TxtPlaka.Text.ToUpper(), TxtMarkasi.Text, TxtModelYili.Text,TxtMotorNo.Text,TxtSaseNo.Text,TxtMulkiyet.Text,TxtSiparisNo.Text, DtProjeTahsisTarihi.Value, CmpPersonelArac.Text, TxtSicilNoArac.Text, TxtMasrafYeriNoArac.Text, TxtMasrafYeriArac.Text, TxtMasrafYeriSorArac.Text, TxtBolumArac.Text, DtgAktarimTarihiArac.Value, TxtAktariGerekcesiArac.Text.ToUpper(),"", TxkKm.Text.ConInt()); 

                string mesaj = aracZimmetiManager.Add(aracZimmeti);
                if (personelAd!="")
                {
                    string mesaj2 = aracZimmetiManager.Delete(isAkisNoArac, personelAd);
                    if (mesaj2 != "OK")
                    {
                        MessageBox.Show(mesaj2, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                AracZimmetiLog aracZimmetiLog = new AracZimmetiLog(LbIsAkisNoArac.Text.ConInt(), TxtPlaka.Text, TxtMarkasi.Text, personelAd, masrafYeriNo,masrafYeri,masYerSorumlusu, perosnelBolumu, CmpPersonelArac.Text, TxtMasrafYeriNoArac.Text, TxtMasrafYeriArac.Text, TxtMasrafYeriSorArac.Text, TxtBolumArac.Text, DtgAktarimTarihiArac.Value,infos[1].ToString(), TxkKm.Text.ConInt(), TxtAktariGerekcesiArac.Text.ToUpper());

                string messege = aracZimmetiLogManager.Add(aracZimmetiLog);
                if (messege!="OK")
                {
                    MessageBox.Show(messege,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                AracTemile();
                IsAkisNo();
                IsAkisNoArac();
                ZimmetliAraclar();
            }
        }
        void AracTemile()
        {
            TxtPlaka.Clear(); TxtMarkasi.Clear(); TxtModelYili.Clear(); TxtMotorNo.Clear(); TxtSaseNo.Clear(); TxtMulkiyet.Clear(); TxtSiparisNo.Clear(); CmpPersonelArac.SelectedIndex = -1; TxtSicilNoArac.Clear(); TxtMasrafYeriNoArac.Clear(); TxtMasrafYeriArac.Clear(); TxtMasrafYeriSorArac.Clear(); TxtBolumArac.Clear(); TxtAktariGerekcesiArac.Clear(); TxkKm.Clear();
        }

        private void CmpPersonelArac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gec == false)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmpPersonelArac.Text);
            TxtSicilNoArac.Text = siparis.Sicil;
            TxtMasrafYeriNoArac.Text = siparis.Masrafyerino;
            TxtMasrafYeriArac.Text = siparis.Masrafyeri;
            idArac = siparis.Id;
            TxtBolumArac.Text = siparis.Bolum;
            TxtMasrafYeriSorArac.Text = siparis.MasrafYeriSorumlusu;
        }

        private void BtnZimmetleriGor_Click(object sender, EventArgs e)
        {
            while (AdvMalzemeOnizleme.Rows.Count > 0)
            {
                AdvMalzemeOnizleme.Rows.RemoveAt(0);
            }
            while (DtgList.Rows.Count > 0)
            {
                DtgList.Rows.RemoveAt(0);
            }
            if (CmbAdPD.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Zimmetleri Listelenecek Personeli Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            zimmetAktarims = zimmetAktarimManager.PersonelZimmeti(CmbAdPD.Text);
            foreach (ZimmetAktarim item in zimmetAktarims)
            {
                AdvMalzemeOnizleme.Rows.Add(item.Dvno, item.DvEtiketNo, item.DvTanim, item.DvMarka, item.DvModel, item.SeriNo, item.Durumu, item.Miktar);
            }
        }

        void CreateWordDP()
        {
            /*Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            object filePath = "C:\\Users\\MAYıldırım\\Desktop\\Formlar\\MP-FR-026 DURAN VARLIK TESLİM FORMU REV (00).docx";
            //object filePath = "Z:\\DTS\\İDARİ İŞLER\\WordTaslak\\MP-FR-026 DURAN VARLIK TESLİM FORMU REV (00).docx";// taslak yolu

            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();
            foreach (var item in collection)
            {

            }
            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["IsAkisNo"].Range.Text = LblIsAkisNo.Text;
            wBookmarks["GorevEmriNo"].Range.Text = TxtGorevEmriNo.Text;
            wBookmarks["GorevinKonusu"].Range.Text = TxtGorevinKonusu.Text;
            wBookmarks["GidilecekYer"].Range.Text = TxtGidilecekYer.Text;
            wBookmarks["BaslamaTarihi"].Range.Text = DtBaslamaTarihi.Value.ToString("dd/MM/yyyy");
            wBookmarks["BitisTarihi"].Range.Text = DtBitisTarihi.Value.ToString("dd/MM/yyyy");
            wBookmarks["GorevinSuresi"].Range.Text = TxtToplamSure.Text;
            wBookmarks["ButceKodu"].Range.Text = CmbButceKodu.Text;
            wBookmarks["SiparisNo"].Range.Text = CmbSiparisNo.Text;
            wBookmarks["AdSoyad"].Range.Text = CmbAdSoyad.Text;
            wBookmarks["MasrafYeriNo"].Range.Text = TxtMasrafyeriNo.Text;
            wBookmarks["MasrafYeri"].Range.Text = TxtMasrafYeri.Text;
            wBookmarks["UlasimGidis"].Range.Text = CmbUlasimGidis.Text;
            wBookmarks["UlasimDonus"].Range.Text = CmbUlasimDonus.Text;
            wBookmarks["UlasimGorevYeri"].Range.Text = CmbUlasimGorevYeri.Text;
            wBookmarks["KonaklamaGun"].Range.Text = TxtKonaklamaGun.Text;
            wBookmarks["KonaklamaGunTl"].Range.Text = TxtKonaklamGunTl.Text;
            wBookmarks["KonaklamaTT"].Range.Text = TxtKonaklamaToplam.Text;
            wBookmarks["KiralamaGun"].Range.Text = TxtKiralamaGun.Text;
            wBookmarks["KiralamaGunTl"].Range.Text = TxtKiralamaGunTl.Text;
            wBookmarks["KiralamaToplam"].Range.Text = TxtKiralamaToplam.Text;
            wBookmarks["AvansGun"].Range.Text = TxtSeyahatAvansGun.Text;
            wBookmarks["AvansGunTl"].Range.Text = TxtSeyahatAvansGunTl.Text;
            wBookmarks["AvansToplam"].Range.Text = TxtSeyahatAvansToplam.Text;
            wBookmarks["Ucak"].Range.Text = TxtUcak.Text;
            wBookmarks["Otobus"].Range.Text = TxtOtobus.Text;
            wBookmarks["GenelToplam"].Range.Text = TxtGenelToplam.Text;
            wBookmarks["Plaka"].Range.Text = TxtPlaka.Text;
            wBookmarks["CikisKm"].Range.Text = TxtCikisKm.Text;
            /*wBookmarks["DonusKm"].Range.Text = TxtDonusKm.Text;
            wBookmarks["ToplamKm"].Range.Text = TxtTopKm.Text;
            wBookmarks["AdSoyad2"].Range.Text = CmbAdSoyad.Text;

            wDoc.SaveAs2(dosyaYolu + TxtDvEtiketNo.Text + ".docx");
            wDoc.Close();
            wApp.Quit(false);*/
        }
        private void comboBox29_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void kaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DtgList.Rows.RemoveAt(DtgList.SelectedRows[0].Index);
        }

        private void CmbAdDP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gec == false)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbAdDP.Text);
            TxtSicilDP.Text = siparis.Sicil;
            TxtMasrafYeriNoDP.Text = siparis.Masrafyerino;
            TxtMasrafYeriDP.Text = siparis.Masrafyeri;
            id = siparis.Id;
            TxtBolumDP.Text = siparis.Bolum;
            TxtMasYeriSorDP.Text = siparis.MasrafYeriSorumlusu;
        }

        private void CmbAdPPAlacak_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CmbAdPPAktaracak_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gec == false)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbAdPPAktaracak.Text);
            TxtSicilPPAktaracak.Text = siparis.Sicil;
            TxtMasrafYeriNoPPAktaracak.Text = siparis.Masrafyerino;
            TxtMasrafYeriPPAktaracak.Text = siparis.Masrafyeri;
            idAktaracak = siparis.Id;
            TxtBolumPPAktaracak.Text = siparis.Bolum;
            TxtMasrafYeriSorumlusuPPAktaracak.Text = siparis.MasrafYeriSorumlusu;
        }
    }
}
