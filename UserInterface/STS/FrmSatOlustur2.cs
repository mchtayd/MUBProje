using Business;
using Business.Concreate;
using Business.Concreate.Depo;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
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
    public partial class FrmSatOlustur2 : Form
    {
        IsAkisNoManager isAkisNoManager;
        SatTalebiDoldurManager satTalebiDoldurManager;
        MalzemeKayitManager malzemeKayitManager;
        SatDataGridview1Manager satDataGridview1Manager;
        SatinAlinacakMalManager satinAlinacakMalManager;
        PersonelKayitManager kayitManager;
        SiparisPersonelManager siparisPersonelManager;
        AmbarManager ambarManager;
        CayOcagiManager cayOcagiManager;
        DestekDepoMalzemeKayitManager depoMalzemeKayitManager;
        ElAletleriManager elAletleriManager;
        IsGiysiManager isGiysiManager;
        KirtasiyeManager kirtasiyeManager;
        KKDManager kKDManager;
        TemizlikUrunleriManager temizlikUrunleriManager;
        ButceKoduManager butceKoduManager;
        TeklifsizSatManager teklifsizSatManager;
        SatIslemAdimlariManager satIslemAdimlariManager;
        SatOnayTarihiManager satOnayTarihiManager;
        KimyasalUrunlerManager kimyasalUrunlerManager;
        AracZimmetiManager aracZimmetiManager;
        SiparislerManager siparislerManager;

        List<MalzemeKayit> malzemeKayits;
        List<MalzemeKayit> malzemesFiltered;
        List<DestekDepoAmbar> destekDepoAmbars;
        List<DestekDepoCayOcagi> cayOcagis;
        List<DestekDepoElAletleri> elAletleris;
        List<DestekDepoIsGiysi> destekDepoIs;
        List<DestekDepoKirtasiye> kirtasiyes;
        List<DestekDepoKKD> kKDs;
        List<DestekDepoTemizlikUrunleri> temizlikUrunleris;
        List<DestekDepoKimyasalUrunler> kimyasalUrunlers;
        List<string> fileNames = new List<string>();
        List<DestekDepoCayOcagi> cayOcagiFiltired;
        List<DestekDepoElAletleri> elAletleriFiltired;
        List<DestekDepoIsGiysi> isgiysiFiltired;
        List<DestekDepoKirtasiye> kirtasiyeFiltired;
        List<DestekDepoKKD> kkdFiltired;
        List<DestekDepoTemizlikUrunleri> temizlikUrunleriFitired;
        List<DestekDepoKimyasalUrunler> kimyasalUrunlersFitired;
        List<DestekDepoAmbar> ambarFiltired;
        List<AracZimmeti> aracZimmetis;
        public object[] infos;
        string bilgi, isAkisNo, dosyaYolu, kaynakdosyaismi, alinandosya, siparisNo, message, malzeme, isAkisNoBasaran, dosyaYoluGun, dosyaYoluTemsili, islem, islemyapan, isleAdimi;
        int atla = 1, index;
        bool start = false, dosyaEkle = false, kaydet = false, dosyaEkleGun = false, dosyaEkleTemsili = false;
        public FrmSatOlustur2()
        {
            InitializeComponent();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            satTalebiDoldurManager = SatTalebiDoldurManager.GetInstance();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            ambarManager = AmbarManager.GetInstance();
            cayOcagiManager = CayOcagiManager.GetInstance();
            depoMalzemeKayitManager = DestekDepoMalzemeKayitManager.GetInstance();
            elAletleriManager = ElAletleriManager.GetInstance();
            isGiysiManager = IsGiysiManager.GetInstance();
            kirtasiyeManager = KirtasiyeManager.GetInstance();
            kKDManager = KKDManager.GetInstance();
            temizlikUrunleriManager = TemizlikUrunleriManager.GetInstance();
            butceKoduManager = ButceKoduManager.GetInstance();
            teklifsizSatManager = TeklifsizSatManager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
            satOnayTarihiManager = SatOnayTarihiManager.GetInstance();
            kimyasalUrunlerManager = KimyasalUrunlerManager.GetInstance();
            aracZimmetiManager = AracZimmetiManager.GetInstance();
            siparislerManager = SiparislerManager.GetInstance();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (dosyaYolu != null)
            {
                if (kaydet == false)
                {
                    Directory.Delete(dosyaYolu, true);
                }
            }
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSatOlustur2"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void FrmSatOlustur2_Load(object sender, EventArgs e)
        {
            SatDoldur();
            SatDoldur2();
            IsAkisNo();
            IsAkisNo2();
            UsBolgeleri();
            YedekParca();
            Personeller();
            ButceKoduKalemi();
            Plakalar();
            Siparisler();
            start = true;
            projeBekle = true;
        }
        public void YenilenecekVeri()
        {
            start = false;
            projeBekle = false;
            SatDoldur();
            SatDoldur2();
            IsAkisNo();
            IsAkisNo2();
            UsBolgeleri();
            YedekParca();
            ButceKoduKalemi();
            Siparisler();
            start = true;
            projeBekle = true;
        }
        void Siparisler()
        {
            CmbSiparisNoMaas.DataSource = siparislerManager.GetList();
            CmbSiparisNoMaas.ValueMember = "Id";
            CmbSiparisNoMaas.DisplayMember = "Siparisno";
            CmbSiparisNoMaas.SelectedValue = 0;
        }
        void ButceKoduKalemi()
        {
            CmbButceKodu.DataSource = butceKoduManager.GetList();
            CmbButceKodu.ValueMember = "Id";
            CmbButceKodu.DisplayMember = "Butcekodu";
            CmbButceKodu.SelectedValue = 0;
        }
        void SatDoldur()
        {
            MasYeriNo.Text = infos[4].ToString();
            LblAdSoyad.Text = infos[1].ToString();
            Bolum.Text = infos[2].ToString();
        }
        void SatDoldur2()
        {
            LblMasrafYeriNo.Text = infos[4].ToString();
            TalepEden.Text = infos[1].ToString();
            LblMasrafYeri.Text = infos[2].ToString();
        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        void IsAkisNo2()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo2.Text = isAkis.Id.ToString();
        }
        void UsBolgeleri()
        {
            Usbolgesi.DataSource = satTalebiDoldurManager.GetList();
            Usbolgesi.ValueMember = "Id";
            Usbolgesi.DisplayMember = "Usbolgesi";
            Usbolgesi.SelectedValue = "";
        }
        void AbfFormNoList()
        {
            BildirimFromNo.DataSource = satTalebiDoldurManager.BolgeSatList(Usbolgesi.Text);
            BildirimFromNo.ValueMember = "Id";
            BildirimFromNo.DisplayMember = "AbfNo";
            BildirimFromNo.SelectedValue = "";
        }
        
        void Personeller()
        {
            CmbAdSoyad.DataSource = kayitManager.PersonelAdSoyad();
            CmbAdSoyad.ValueMember = "Id";
            CmbAdSoyad.DisplayMember = "Adsoyad";
            CmbAdSoyad.SelectedValue = -1;
        }
        void YedekParca()
        {
            malzemeKayits = malzemeKayitManager.GetList();
            malzemesFiltered = malzemeKayits;
            dataBinder.DataSource = malzemeKayits.ToDataTable();
            DtgYedekParca.DataSource = dataBinder;
            TxtTop.Text = DtgYedekParca.RowCount.ToString();

            DtgYedekParca.Columns["Id"].Visible = false;
            DtgYedekParca.Columns["Stokno"].HeaderText = "STOK NO";
            DtgYedekParca.Columns["Tanim"].HeaderText = "TANIM";
            DtgYedekParca.Columns["Birim"].HeaderText = "BİRİM";
            DtgYedekParca.Columns["Tedarikcifirma"].Visible = false;
            DtgYedekParca.Columns["Malzemeonarimdurumu"].Visible = false;
            DtgYedekParca.Columns["Malzemeonarımyeri"].Visible = false;
            DtgYedekParca.Columns["Malzemeturu"].Visible = false;
            DtgYedekParca.Columns["Malzemetakipdurumu"].Visible = false;
            //DtgYedekParca.Columns["Malzemerevizyon"].Visible = false;
            //DtgYedekParca.Columns["Malzemelot"].Visible = false;
            DtgYedekParca.Columns["Malzemekul"].Visible = false;
            DtgYedekParca.Columns["Aciklama"].Visible = false;
            DtgYedekParca.Columns["Dosyayolu"].Visible = false;
            DtgYedekParca.Columns["AlternatifMalzeme"].Visible = false;
            DtgYedekParca.Columns["SistemStokNo"].Visible = false;
            DtgYedekParca.Columns["SistemTanim"].Visible = false;
            DtgYedekParca.Columns["SistemPersonel"].Visible = false;
            DtgYedekParca.Columns["KayitDurumu"].Visible = false;
            DtgYedekParca.Columns["SeriNo"].Visible = false;
            DtgYedekParca.Columns["Durum"].Visible = false;
            DtgYedekParca.Columns["Revizyon"].Visible = false;
            DtgYedekParca.Columns["Miktar"].Visible = false;
            DtgYedekParca.Columns["TalepTarihi"].Visible = false;
        }
        void DataDisplay()
        {
            DtgStokList.Columns["Id"].Visible = false;
            DtgStokList.Columns["Stokno"].HeaderText = "STOK NO";
            DtgStokList.Columns["Tanim"].HeaderText = "TANIM";
            DtgStokList.Columns["Birim"].HeaderText = "BİRİM";
        }

        private void TxtStokArama_TextChanged(object sender, EventArgs e)
        {
            string stokno = TxtStokArama.Text;
            if (string.IsNullOrEmpty(stokno))
            {
                malzemesFiltered = malzemeKayits;
                dataBinder.DataSource = malzemeKayits.ToDataTable();
                DtgYedekParca.DataSource = dataBinder;
                TxtTop.Text = DtgYedekParca.RowCount.ToString();
                return;
            }
            if (TxtStokArama.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemesFiltered.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
            DtgYedekParca.DataSource = dataBinder;
            malzemesFiltered = malzemeKayits;
            TxtTop.Text = DtgYedekParca.RowCount.ToString();

        }

        private void TxtTanimArama_TextChanged(object sender, EventArgs e)
        {
            string tanim = TxtTanimArama.Text;
            if (string.IsNullOrEmpty(tanim))
            {
                malzemesFiltered = malzemeKayits;
                dataBinder.DataSource = malzemeKayits.ToDataTable();
                DtgYedekParca.DataSource = dataBinder;
                TxtTop.Text = DtgYedekParca.RowCount.ToString();
                return;
            }
            if (TxtTanimArama.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemesFiltered.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
            DtgYedekParca.DataSource = dataBinder;
            malzemesFiltered = malzemeKayits;
            TxtTop.Text = DtgYedekParca.RowCount.ToString();
        }

        private void DtgYedekParca_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (DtgYedekParca.DataSource == null)
            {
                return;
            }
            if (stn1.Text == "")
            {
                stn1.Text = DtgYedekParca.CurrentRow.Cells[1].Value.ToString();
                t1.Text = DtgYedekParca.CurrentRow.Cells[2].Value.ToString();
                b1.Text = DtgYedekParca.CurrentRow.Cells[3].Value.ToString();
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
                stn2.Text = DtgYedekParca.CurrentRow.Cells[1].Value.ToString();
                t2.Text = DtgYedekParca.CurrentRow.Cells[2].Value.ToString();
                b2.Text = DtgYedekParca.CurrentRow.Cells[3].Value.ToString();
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
                stn3.Text = DtgYedekParca.CurrentRow.Cells[1].Value.ToString();
                t3.Text = DtgYedekParca.CurrentRow.Cells[2].Value.ToString();
                b3.Text = DtgYedekParca.CurrentRow.Cells[3].Value.ToString();
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
                stn4.Text = DtgYedekParca.CurrentRow.Cells[1].Value.ToString();
                t4.Text = DtgYedekParca.CurrentRow.Cells[2].Value.ToString();
                b4.Text = DtgYedekParca.CurrentRow.Cells[3].Value.ToString();
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
                stn5.Text = DtgYedekParca.CurrentRow.Cells[1].Value.ToString();
                t5.Text = DtgYedekParca.CurrentRow.Cells[2].Value.ToString();
                b5.Text = DtgYedekParca.CurrentRow.Cells[3].Value.ToString();
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
                stn6.Text = DtgYedekParca.CurrentRow.Cells[1].Value.ToString();
                t6.Text = DtgYedekParca.CurrentRow.Cells[2].Value.ToString();
                b6.Text = DtgYedekParca.CurrentRow.Cells[3].Value.ToString();
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
                stn7.Text = DtgYedekParca.CurrentRow.Cells[1].Value.ToString();
                t7.Text = DtgYedekParca.CurrentRow.Cells[2].Value.ToString();
                b7.Text = DtgYedekParca.CurrentRow.Cells[3].Value.ToString();
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
                stn8.Text = DtgYedekParca.CurrentRow.Cells[1].Value.ToString();
                t8.Text = DtgYedekParca.CurrentRow.Cells[2].Value.ToString();
                b8.Text = DtgYedekParca.CurrentRow.Cells[3].Value.ToString();
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
                stn9.Text = DtgYedekParca.CurrentRow.Cells[1].Value.ToString();
                t9.Text = DtgYedekParca.CurrentRow.Cells[2].Value.ToString();
                b9.Text = DtgYedekParca.CurrentRow.Cells[3].Value.ToString();
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
                stn10.Text = DtgYedekParca.CurrentRow.Cells[1].Value.ToString();
                t10.Text = DtgYedekParca.CurrentRow.Cells[2].Value.ToString();
                b10.Text = DtgYedekParca.CurrentRow.Cells[3].Value.ToString();
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
        bool projeBekle = false;
        private void Usbolgesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            BildirimFromNo.Text = "";
            AbfFormNoList();
            if (projeBekle==false)
            {
                return;
            }
            SatTalebiDoldur satTalebiDoldur = satTalebiDoldurManager.Get(Usbolgesi.Text);
            TxtProje.Text = satTalebiDoldur.Proje;
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            IsAkisNo();
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\GEÇİCİ SAT DOSYALARI\";

            isAkisNo = LblIsAkisNo.Text;

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

            //Directory.CreateDirectory(subdir + isAkisNo);
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
                fileNames.Add(alinandosya);
                webBrowser1.Navigate(dosyaYolu);
                dosyaEkle = true;
            }
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            IsAkisNo();
            IsAkisNo2();
            if (dosyaEkle == false)
            {
                MessageBox.Show("Lütfen Öncekle Dosya Ekleme İşlemini Gerçekleştiriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (CmbDonem.Text=="" || CmbDonemYil.Text=="")
                {
                    MessageBox.Show("Lütfen Öncelikle Dönem Bilgisini Eksiksiz Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Usbolgesi.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle Üs Blgesi Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (BildirimFromNo.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle Arıza Bildirim Numarasını Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string control = MalzemeControl();
                if (control != "OK")
                {
                    MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                siparisNo = Guid.NewGuid().ToString();

                string donem = CmbDonem.Text + " " + CmbDonemYil.Text;

                isleAdimi = "SAT BAŞLATMA ONAYI";
                SatDataGridview1 satDataGridview1 = new SatDataGridview1(0, LblIsAkisNo.Text.ConInt(), MasYeriNo.Text, TalepEden.Text, Bolum.Text, Usbolgesi.Text, BildirimFromNo.Text, istenenTarih.Value, Gerekce.Text, siparisNo, "", "", "", "", "",
                  string.IsNullOrEmpty(dosyaYolu) ? "" : dosyaYolu, infos[0].ConInt(), isleAdimi, donem, "ASELSAN", TxtProje.Text,"-");

                string mesaj = satDataGridview1Manager.Add(satDataGridview1);

                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MalzemeleriKaydet();
                kaydet = true;
                
            }
        }

        void MalzemeleriKaydet()
        {
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
                message = satinAlinacakMalManager.Add(item, siparisNo);
            }
            if (message == "OK")
            {
                islem = "SATIN ALMA TALEBİ OLUŞTURULDU.";
                islemyapan = infos[1].ToString();
                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, islem, islemyapan, DateTime.Now);
                satIslemAdimlariManager.Add(satIslem);
                SatBaslamaTarihiKayit();
                MessageBox.Show(isAkisNo + " Numaralı SAT Kaydınız Başarıyla Oluşturulmuştur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                projeBekle = false;
                Temizle();
                IsAkisNo();
                IsAkisNo2();
                projeBekle = true;
                FrmAnaSayfa frmAnaSayfa = new FrmAnaSayfa();
                frmAnaSayfa.ToplamSayilar();
            }
            else
            {
                MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void SatBaslamaTarihiKayit()
        {
            SatOnayTarihi satOnayTarihi = new SatOnayTarihi(siparisNo);
            satOnayTarihiManager.Add(satOnayTarihi);
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

        void Temizle()
        {
            Usbolgesi.SelectedValue = -1;
            BildirimFromNo.Text = "";
            webBrowser1.Navigate("");
            Gerekce.Clear();
            t1.Text = ""; t2.Text = ""; t3.Text = ""; t4.Text = ""; t5.Text = ""; t6.Text = ""; t7.Text = ""; t8.Text = ""; t9.Text = "";
            t10.Text = "";
            stn1.Text = ""; stn2.Text = ""; stn3.Text = ""; stn4.Text = ""; stn5.Text = ""; stn6.Text = ""; stn7.Text = "";
            stn8.Text = ""; stn9.Text = ""; stn10.Text = "";
            m1.Text = ""; m2.Text = ""; m3.Text = ""; m4.Text = ""; m5.Text = ""; m6.Text = ""; m7.Text = ""; m8.Text = ""; m9.Text = "";
            m10.Text = "";
            b1.Text = ""; b2.Text = ""; b3.Text = ""; b4.Text = ""; b5.Text = ""; b6.Text = ""; b7.Text = ""; b8.Text = ""; b9.Text = "";
            b10.Text = "";
            TxtStokArama.Clear(); TxtTanimArama.Clear(); CmbDonem.SelectedValue = "";TxtProje.Clear();
        }

        private void CmbAdSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbAdSoyad.Text);
            TxtMasrafyeriNo.Text = siparis.Masrafyerino;
            TxtMasrafYeri.Text = siparis.Masrafyeri;
            TxtGorevi.Text = siparis.Gorevi;
            CmbSiparisNo.Text = siparis.Siparis;
            TxtProjeKodu.Text = siparis.Projekodu;
        }

        private void CmbMalzemeTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            malzeme = CmbMalzemeTuru.Text;
            if (malzeme == "")
            {
                DtgStokList.DataSource = null;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "AMBAR")
            {

                destekDepoAmbars = ambarManager.GetList();
                ambarFiltired = destekDepoAmbars;
                dataBinder.DataSource = destekDepoAmbars.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (malzeme == "ÇAY OCAĞI")
            {

                cayOcagis = cayOcagiManager.GetList();
                cayOcagiFiltired = cayOcagis;
                dataBinder.DataSource = cayOcagis.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (malzeme == "EL ALETLERİ")
            {

                elAletleris = elAletleriManager.GetList();
                elAletleriFiltired = elAletleris;
                dataBinder.DataSource = elAletleris.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (malzeme == "İŞ GİYSİ")
            {

                destekDepoIs = isGiysiManager.GetList();
                isgiysiFiltired = destekDepoIs;
                dataBinder.DataSource = destekDepoIs.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (malzeme == "KIRTASİYE")
            {

                kirtasiyes = kirtasiyeManager.GetList();
                kirtasiyeFiltired = kirtasiyes;
                dataBinder.DataSource = kirtasiyes.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (malzeme == "KKD")
            {

                kKDs = kKDManager.GetList();
                kkdFiltired = kKDs;
                dataBinder.DataSource = kKDs.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (malzeme == "TEMİZLİK ÜRÜNLERİ")
            {

                temizlikUrunleris = temizlikUrunleriManager.GetList();
                temizlikUrunleriFitired = temizlikUrunleris;
                dataBinder.DataSource = temizlikUrunleris.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
            if (malzeme == "KİMYASAL ÜRÜNLER")
            {

                kimyasalUrunlers = kimyasalUrunlerManager.GetList();
                kimyasalUrunlersFitired = kimyasalUrunlers;
                dataBinder.DataSource = kimyasalUrunlers.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
                DataDisplay();
            }
        }

        private void TxtStok_TextChanged(object sender, EventArgs e)
        {
            string stokno = TxtStok.Text;
            if (malzeme == "AMBAR")
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    ambarFiltired = destekDepoAmbars;
                    dataBinder.DataSource = destekDepoAmbars.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    LblTopStokList.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStok.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = ambarFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                ambarFiltired = destekDepoAmbars;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "ÇAY OCAĞI")
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    cayOcagiFiltired = cayOcagis;
                    dataBinder.DataSource = cayOcagis.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    LblTopStokList.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStok.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = cayOcagiFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                cayOcagiFiltired = cayOcagis;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "EL ALETLERİ")
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    elAletleriFiltired = elAletleris;
                    dataBinder.DataSource = elAletleris.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    LblTopStokList.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStok.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = elAletleriFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                elAletleriFiltired = elAletleris;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "İŞ GİYSİ")
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    isgiysiFiltired = destekDepoIs;
                    dataBinder.DataSource = destekDepoIs.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    LblTopStokList.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStok.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = isgiysiFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                isgiysiFiltired = destekDepoIs;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "KIRTASİYE")
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    kirtasiyeFiltired = kirtasiyes;
                    dataBinder.DataSource = kirtasiyes.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    LblTopStokList.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStok.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = kirtasiyeFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                kirtasiyeFiltired = kirtasiyes;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "KKD")
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    kkdFiltired = kKDs;
                    dataBinder.DataSource = kKDs.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    LblTopStokList.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStok.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = kkdFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                kkdFiltired = kKDs;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "TEMİZLİK ÜRÜNLERİ")
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    temizlikUrunleriFitired = temizlikUrunleris;
                    dataBinder.DataSource = temizlikUrunleris.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    LblTopStokList.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStok.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = temizlikUrunleriFitired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                temizlikUrunleriFitired = temizlikUrunleris;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "KİMYASAL ÜRÜNLER")
            {
                if (string.IsNullOrEmpty(stokno))
                {
                    kimyasalUrunlersFitired = kimyasalUrunlers;
                    dataBinder.DataSource = kimyasalUrunlers.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    LblTopStokList.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtStok.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = kimyasalUrunlersFitired.Where(x => x.StokNo.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                kimyasalUrunlersFitired = kimyasalUrunlers;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
            }
        }

        private void TxtTanim_TextChanged(object sender, EventArgs e)
        {
            string tanim = TxtTanim.Text;
            if (malzeme == "AMBAR")
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    ambarFiltired = destekDepoAmbars;
                    dataBinder.DataSource = destekDepoAmbars.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    LblTopStokList.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanim.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = ambarFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                ambarFiltired = destekDepoAmbars;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "ÇAY OCAĞI")
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    cayOcagiFiltired = cayOcagis;
                    dataBinder.DataSource = cayOcagis.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    LblTopStokList.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanim.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = cayOcagiFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                cayOcagiFiltired = cayOcagis;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "EL ALETLERİ")
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    elAletleriFiltired = elAletleris;
                    dataBinder.DataSource = elAletleris.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    LblTopStokList.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanim.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = elAletleriFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                elAletleriFiltired = elAletleris;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "İŞ GİYSİ")
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    isgiysiFiltired = destekDepoIs;
                    dataBinder.DataSource = destekDepoIs.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    LblTopStokList.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanim.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = isgiysiFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                isgiysiFiltired = destekDepoIs;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "KIRTASİYE")
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    kirtasiyeFiltired = kirtasiyes;
                    dataBinder.DataSource = kirtasiyes.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    LblTopStokList.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanim.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = kirtasiyeFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                kirtasiyeFiltired = kirtasiyes;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "KKD")
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    kkdFiltired = kKDs;
                    dataBinder.DataSource = kKDs.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    LblTopStokList.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanim.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = kkdFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                kkdFiltired = kKDs;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "TEMİZLİK ÜRÜNLERİ")
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    temizlikUrunleriFitired = temizlikUrunleris;
                    dataBinder.DataSource = temizlikUrunleris.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    LblTopStokList.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanim.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = temizlikUrunleriFitired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                temizlikUrunleriFitired = temizlikUrunleris;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
            }
            if (malzeme == "KİMYASAL ÜRÜNLER")
            {
                if (string.IsNullOrEmpty(tanim))
                {
                    kimyasalUrunlersFitired = kimyasalUrunlers;
                    dataBinder.DataSource = kimyasalUrunlers.ToDataTable();
                    DtgStokList.DataSource = dataBinder;
                    LblTopStokList.Text = DtgStokList.RowCount.ToString();
                    return;
                }
                if (TxtTanim.Text.Length < 3)
                {
                    return;
                }
                dataBinder.DataSource = kimyasalUrunlersFitired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
                DtgStokList.DataSource = dataBinder;
                kimyasalUrunlersFitired = kimyasalUrunlers;
                LblTopStokList.Text = DtgStokList.RowCount.ToString();
            }
        }

        private void DtgStokList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (DtgStokList.DataSource == null)
            {
                return;
            }
            if (stnBasaran1.Text == "")
            {
                stnBasaran1.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                tBasaran1.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                bBasaran1.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 0;
                bilgi = MalzemeKonrolBasaran();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stnBasaran1.Text = ""; tBasaran1.Text = ""; mBasaran1.Text = ""; bBasaran1.Text = "";
                    return;
                }
                return;
            }
            if (stnBasaran2.Text == "")
            {
                stnBasaran2.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                tBasaran2.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                bBasaran2.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                bilgi = MalzemeKonrolBasaran();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stnBasaran2.Text = ""; tBasaran1.Text = ""; mBasaran2.Text = ""; bBasaran2.Text = "";
                    return;
                }
                return;
            }
            if (stnBasaran3.Text == "")
            {
                stnBasaran3.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                tBasaran3.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                bBasaran3.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 2;
                bilgi = MalzemeKonrolBasaran();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stnBasaran3.Text = ""; tBasaran3.Text = ""; mBasaran3.Text = ""; bBasaran3.Text = "";
                    return;
                }
                return;
            }
            if (stnBasaran4.Text == "")
            {
                stnBasaran4.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                tBasaran4.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                bBasaran4.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 3;
                bilgi = MalzemeKonrolBasaran();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stnBasaran4.Text = ""; tBasaran4.Text = ""; mBasaran4.Text = ""; bBasaran4.Text = "";
                    return;
                }
                return;
            }
            if (stnBasaran5.Text == "")
            {
                stnBasaran5.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                tBasaran5.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                bBasaran5.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 4;
                bilgi = MalzemeKonrolBasaran();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stnBasaran5.Text = ""; tBasaran5.Text = ""; mBasaran5.Text = ""; bBasaran5.Text = "";
                    return;
                }
                return;
            }
            if (stnBasaran6.Text == "")
            {
                stnBasaran6.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                tBasaran6.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                bBasaran6.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 5;
                bilgi = MalzemeKonrolBasaran();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stnBasaran6.Text = ""; tBasaran6.Text = ""; mBasaran6.Text = ""; bBasaran6.Text = "";
                    return;
                }
                return;
            }
            if (stnBasaran7.Text == "")
            {
                stnBasaran7.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                tBasaran7.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                bBasaran7.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 6;
                bilgi = MalzemeKonrolBasaran();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stnBasaran7.Text = ""; tBasaran7.Text = ""; mBasaran7.Text = ""; bBasaran7.Text = "";
                    return;
                }
                return;
            }
            if (stnBasaran8.Text == "")
            {
                stnBasaran8.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                tBasaran8.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                bBasaran8.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 7;
                bilgi = MalzemeKonrolBasaran();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stnBasaran8.Text = ""; tBasaran8.Text = ""; mBasaran8.Text = ""; bBasaran8.Text = "";
                    return;
                }
                return;
            }
            if (stnBasaran9.Text == "")
            {
                stnBasaran9.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                tBasaran9.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                bBasaran9.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 8;
                bilgi = MalzemeKonrolBasaran();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stnBasaran9.Text = ""; tBasaran9.Text = ""; mBasaran9.Text = ""; bBasaran9.Text = "";
                    return;
                }
                return;
            }
            if (stnBasaran10.Text == "")
            {
                stnBasaran10.Text = DtgStokList.CurrentRow.Cells[1].Value.ToString();
                tBasaran10.Text = DtgStokList.CurrentRow.Cells[2].Value.ToString();
                bBasaran10.Text = DtgStokList.CurrentRow.Cells[3].Value.ToString();
                atla = 9;
                bilgi = MalzemeKonrolBasaran();
                if (bilgi == "")
                {
                    MessageBox.Show("Lütfen Aynı Malzemeleri Tekrarlı Olarak Girmeyiniz Bunun Yerine Eklediğiniz Malzemenin Miktarını Arttırınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stnBasaran10.Text = ""; tBasaran10.Text = ""; mBasaran10.Text = ""; bBasaran10.Text = "";
                    return;
                }
                return;
            }
            MessageBox.Show("Bir Seferde Talep Edeceğiniz Malzeme Listesinde Limit Seviyeye ulaştınız.Daha Fazla Talep İçin Lütfen Yeni Bir Satın Alma İşlemi Oluşturunuz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string MalzemeKonrolBasaran()
        {
            if (atla == 0)
            {
                if (stnBasaran1.Text == stnBasaran2.Text || stnBasaran1.Text == stnBasaran3.Text || stnBasaran1.Text == stnBasaran4.Text || stnBasaran1.Text == stnBasaran5.Text || stnBasaran1.Text == stnBasaran6.Text ||
                stnBasaran1.Text == stnBasaran7.Text || stnBasaran1.Text == stnBasaran8.Text || stnBasaran1.Text == stnBasaran9.Text || stnBasaran1.Text == stnBasaran10.Text)
                {
                    return "";
                }
            }
            if (atla == 1)
            {
                if (stnBasaran2.Text == stnBasaran1.Text || stnBasaran2.Text == stnBasaran3.Text || stnBasaran2.Text == stnBasaran4.Text || stnBasaran2.Text == stnBasaran5.Text || stnBasaran2.Text == stnBasaran6.Text ||
                stnBasaran2.Text == stnBasaran7.Text || stnBasaran2.Text == stnBasaran8.Text || stnBasaran2.Text == stnBasaran9.Text || stnBasaran2.Text == stnBasaran10.Text)
                {
                    return "";
                }
            }
            if (atla == 2)
            {
                if (stnBasaran3.Text == stnBasaran1.Text || stnBasaran3.Text == stnBasaran2.Text || stnBasaran3.Text == stnBasaran4.Text || stnBasaran3.Text == stnBasaran5.Text || stnBasaran3.Text == stnBasaran6.Text ||
                stnBasaran3.Text == stnBasaran7.Text || stnBasaran3.Text == stnBasaran8.Text || stnBasaran3.Text == stnBasaran9.Text || stnBasaran3.Text == stnBasaran10.Text)
                {
                    return "";
                }
            }
            if (atla == 3)
            {
                if (stnBasaran4.Text == stnBasaran1.Text || stnBasaran4.Text == stnBasaran2.Text || stnBasaran4.Text == stnBasaran3.Text || stnBasaran4.Text == stnBasaran5.Text || stnBasaran4.Text == stnBasaran6.Text ||
                stnBasaran4.Text == stnBasaran7.Text || stnBasaran4.Text == stnBasaran8.Text || stnBasaran4.Text == stnBasaran9.Text || stnBasaran4.Text == stnBasaran10.Text)
                {
                    return "";
                }
            }
            if (atla == 4)
            {
                if (stnBasaran5.Text == stnBasaran1.Text || stnBasaran5.Text == stnBasaran2.Text || stnBasaran5.Text == stnBasaran3.Text || stnBasaran5.Text == stnBasaran4.Text ||
                    stnBasaran5.Text == stnBasaran6.Text ||
                stnBasaran5.Text == stnBasaran7.Text || stnBasaran5.Text == stnBasaran8.Text || stnBasaran5.Text == stnBasaran9.Text || stnBasaran5.Text == stnBasaran10.Text)
                {
                    return "";
                }
            }
            if (atla == 5)
            {
                if (stnBasaran6.Text == stnBasaran1.Text || stnBasaran6.Text == stnBasaran2.Text || stnBasaran6.Text == stnBasaran3.Text || stnBasaran6.Text == stnBasaran4.Text || stnBasaran6.Text == stnBasaran5.Text ||
                stnBasaran6.Text == stnBasaran7.Text || stnBasaran6.Text == stnBasaran8.Text || stnBasaran6.Text == stnBasaran9.Text || stnBasaran6.Text == stnBasaran10.Text)
                {
                    return "";
                }
            }
            if (atla == 6)
            {
                if (stnBasaran7.Text == stnBasaran1.Text || stnBasaran7.Text == stnBasaran2.Text || stnBasaran7.Text == stnBasaran3.Text || stnBasaran7.Text == stnBasaran4.Text || stnBasaran7.Text == stnBasaran5.Text ||
                stnBasaran7.Text == stnBasaran6.Text || stnBasaran7.Text == stnBasaran8.Text || stnBasaran7.Text == stnBasaran9.Text || stnBasaran7.Text == stnBasaran10.Text)
                {
                    return "";
                }
            }
            if (atla == 7)
            {
                if (stnBasaran8.Text == stnBasaran1.Text || stnBasaran8.Text == stnBasaran2.Text || stnBasaran8.Text == stnBasaran3.Text || stnBasaran8.Text == stnBasaran4.Text || stnBasaran8.Text == stnBasaran5.Text ||
                stnBasaran8.Text == stnBasaran6.Text || stnBasaran8.Text == stnBasaran7.Text || stnBasaran8.Text == stnBasaran9.Text || stnBasaran8.Text == stnBasaran10.Text)
                {
                    return "";
                }
            }
            if (atla == 8)
            {
                if (stnBasaran9.Text == stnBasaran1.Text || stnBasaran9.Text == stnBasaran2.Text || stnBasaran9.Text == stnBasaran3.Text || stnBasaran9.Text == stnBasaran4.Text || stnBasaran9.Text == stnBasaran5.Text ||
                stnBasaran9.Text == stnBasaran6.Text || stnBasaran9.Text == stnBasaran7.Text || stnBasaran9.Text == stnBasaran8.Text || stnBasaran9.Text == stnBasaran10.Text)
                {
                    return "";
                }
            }
            if (atla == 9)
            {
                if (stnBasaran10.Text == stnBasaran1.Text || stnBasaran10.Text == stnBasaran2.Text || stnBasaran10.Text == stnBasaran3.Text || stnBasaran10.Text == stnBasaran4.Text || stnBasaran10.Text == stnBasaran5.Text ||
                stnBasaran10.Text == stnBasaran6.Text || stnBasaran10.Text == stnBasaran7.Text || stnBasaran10.Text == stnBasaran8.Text || stnBasaran10.Text == stnBasaran9.Text)
                {
                    return "";
                }
            }
            return "OK";
        }

        private void SilBasaran1_Click(object sender, EventArgs e)
        {
            stnBasaran1.Text = ""; tBasaran1.Text = ""; mBasaran1.Text = ""; bBasaran1.Text = "";
            if (stnBasaran2.Text != "")
            {
                stnBasaran1.Text = stnBasaran2.Text; tBasaran1.Text = tBasaran2.Text; mBasaran1.Text = mBasaran2.Text;
                bBasaran1.Text = bBasaran2.Text;
                stnBasaran2.Text = stnBasaran3.Text; tBasaran2.Text = tBasaran3.Text; mBasaran2.Text = mBasaran3.Text;
                bBasaran2.Text = bBasaran3.Text;
                stnBasaran3.Text = stnBasaran4.Text; tBasaran3.Text = tBasaran4.Text; mBasaran3.Text = mBasaran4.Text;
                bBasaran3.Text = bBasaran4.Text;
                stnBasaran4.Text = stnBasaran5.Text; tBasaran4.Text = tBasaran5.Text; mBasaran4.Text = mBasaran5.Text;
                bBasaran4.Text = bBasaran5.Text;
                stnBasaran5.Text = stnBasaran6.Text; tBasaran5.Text = tBasaran6.Text; mBasaran5.Text = mBasaran6.Text;
                bBasaran5.Text = bBasaran6.Text;
                stnBasaran6.Text = stnBasaran7.Text; tBasaran6.Text = tBasaran7.Text; mBasaran6.Text = mBasaran7.Text;
                bBasaran6.Text = bBasaran7.Text;
                stnBasaran7.Text = stnBasaran8.Text; tBasaran7.Text = tBasaran8.Text; mBasaran7.Text = mBasaran8.Text;
                bBasaran7.Text = bBasaran8.Text;
                stnBasaran8.Text = stnBasaran9.Text; tBasaran8.Text = tBasaran9.Text; mBasaran8.Text = mBasaran9.Text;
                bBasaran8.Text = bBasaran9.Text;
                stnBasaran9.Text = stnBasaran10.Text; tBasaran9.Text = tBasaran10.Text; mBasaran9.Text = mBasaran10.Text;
                bBasaran9.Text = bBasaran10.Text;
                stnBasaran10.Text = ""; tBasaran10.Text = ""; mBasaran10.Text = ""; bBasaran10.Text = "";
            }
        }

        private void SilBasaran2_Click(object sender, EventArgs e)
        {
            stnBasaran2.Text = ""; tBasaran2.Text = ""; mBasaran2.Text = ""; bBasaran2.Text = "";
            if (stnBasaran3.Text != "")
            {
                stnBasaran2.Text = stnBasaran3.Text; tBasaran2.Text = tBasaran3.Text; mBasaran2.Text = mBasaran3.Text;
                bBasaran2.Text = bBasaran3.Text;
                stnBasaran3.Text = stnBasaran4.Text; tBasaran3.Text = tBasaran4.Text; mBasaran3.Text = mBasaran4.Text;
                bBasaran3.Text = bBasaran4.Text;
                stnBasaran4.Text = stnBasaran5.Text; tBasaran4.Text = tBasaran5.Text; mBasaran4.Text = mBasaran5.Text;
                bBasaran4.Text = bBasaran5.Text;
                stnBasaran5.Text = stnBasaran6.Text; tBasaran5.Text = tBasaran6.Text; mBasaran5.Text = mBasaran6.Text;
                bBasaran5.Text = bBasaran6.Text;
                stnBasaran6.Text = stnBasaran7.Text; tBasaran6.Text = tBasaran7.Text; mBasaran6.Text = mBasaran7.Text;
                bBasaran6.Text = bBasaran7.Text;
                stnBasaran7.Text = stnBasaran8.Text; tBasaran7.Text = tBasaran8.Text; mBasaran7.Text = mBasaran8.Text;
                bBasaran7.Text = bBasaran8.Text;
                stnBasaran8.Text = stnBasaran9.Text; tBasaran8.Text = tBasaran9.Text; mBasaran8.Text = mBasaran9.Text;
                bBasaran8.Text = bBasaran9.Text;
                stnBasaran9.Text = stnBasaran10.Text; tBasaran9.Text = tBasaran10.Text; mBasaran9.Text = mBasaran10.Text;
                bBasaran9.Text = bBasaran10.Text;
                stnBasaran10.Text = ""; tBasaran10.Text = ""; mBasaran10.Text = ""; bBasaran10.Text = "";
            }
        }

        private void SilBasaran3_Click(object sender, EventArgs e)
        {
            stnBasaran3.Text = ""; tBasaran3.Text = ""; mBasaran3.Text = ""; bBasaran3.Text = "";
            if (stnBasaran4.Text != "")
            {
                stnBasaran3.Text = stnBasaran4.Text; tBasaran3.Text = tBasaran4.Text; mBasaran3.Text = mBasaran4.Text;
                bBasaran3.Text = bBasaran4.Text;
                stnBasaran4.Text = stnBasaran5.Text; tBasaran4.Text = tBasaran5.Text; mBasaran4.Text = mBasaran5.Text;
                bBasaran4.Text = bBasaran5.Text;
                stnBasaran5.Text = stnBasaran6.Text; tBasaran5.Text = tBasaran6.Text; mBasaran5.Text = mBasaran6.Text;
                bBasaran5.Text = bBasaran6.Text;
                stnBasaran6.Text = stnBasaran7.Text; tBasaran6.Text = tBasaran7.Text; mBasaran6.Text = mBasaran7.Text;
                bBasaran6.Text = bBasaran7.Text;
                stnBasaran7.Text = stnBasaran8.Text; tBasaran7.Text = tBasaran8.Text; mBasaran7.Text = mBasaran8.Text;
                bBasaran7.Text = bBasaran8.Text;
                stnBasaran8.Text = stnBasaran9.Text; tBasaran8.Text = tBasaran9.Text; mBasaran8.Text = mBasaran9.Text;
                bBasaran8.Text = bBasaran9.Text;
                stnBasaran9.Text = stnBasaran10.Text; tBasaran9.Text = tBasaran10.Text; mBasaran9.Text = mBasaran10.Text;
                bBasaran9.Text = bBasaran10.Text;
                stnBasaran10.Text = ""; tBasaran10.Text = ""; mBasaran10.Text = ""; bBasaran10.Text = "";
            }
        }

        private void SilBasaran4_Click(object sender, EventArgs e)
        {
            stnBasaran4.Text = ""; tBasaran4.Text = ""; mBasaran4.Text = ""; bBasaran4.Text = "";
            if (stnBasaran5.Text != "")
            {
                stnBasaran4.Text = stnBasaran5.Text; tBasaran4.Text = tBasaran5.Text; mBasaran4.Text = mBasaran5.Text;
                bBasaran4.Text = bBasaran5.Text;
                stnBasaran5.Text = stnBasaran6.Text; tBasaran5.Text = tBasaran6.Text; mBasaran5.Text = mBasaran6.Text;
                bBasaran5.Text = bBasaran6.Text;
                stnBasaran6.Text = stnBasaran7.Text; tBasaran6.Text = tBasaran7.Text; mBasaran6.Text = mBasaran7.Text;
                bBasaran6.Text = bBasaran7.Text;
                stnBasaran7.Text = stnBasaran8.Text; tBasaran7.Text = tBasaran8.Text; mBasaran7.Text = mBasaran8.Text;
                bBasaran7.Text = bBasaran8.Text;
                stnBasaran8.Text = stnBasaran9.Text; tBasaran8.Text = tBasaran9.Text; mBasaran8.Text = mBasaran9.Text;
                bBasaran8.Text = bBasaran9.Text;
                stnBasaran9.Text = stnBasaran10.Text; tBasaran9.Text = tBasaran10.Text; mBasaran9.Text = mBasaran10.Text;
                bBasaran9.Text = bBasaran10.Text;
                stnBasaran10.Text = ""; tBasaran10.Text = ""; mBasaran10.Text = ""; bBasaran10.Text = "";
            }
        }


        private void TxtProje_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CmbButceKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start==false)
            {
                return;
            }
            if (CmbButceKodu.Text == "BM25/PERS. MAAŞ GİDERLERİ" || CmbButceKodu.Text == "BM22/KİRA YARDIMI" || 
                CmbButceKodu.Text == "BM21/İAŞE, İLETİŞİM GİDERLERİ" || CmbButceKodu.Text == "BM01/İŞ GİYSİSİ" || CmbButceKodu.Text == "BM23/ÖZEL SİGRT. GİDERLERİ" || CmbButceKodu.Text == "BM38/PERSONEL GİDERLERİ")
            {
                LblSiparisNo.Visible = true; CmbSiparisNoMaas.Visible = true;
                LblPersonelSayisi.Visible = true; TxtPersonelSayisi.Visible = true;
                LblPlaka.Visible = false; CmbPlaka.Visible = false;
                return;
            }
            LblSiparisNo.Visible = false; CmbSiparisNoMaas.Visible = false;
            LblPersonelSayisi.Visible = false; TxtPersonelSayisi.Visible = false;
            LblPlaka.Visible = false; CmbPlaka.Visible = false;

            if (CmbButceKodu.Text== "BM32/AKARYAKIT, NAKİT")
            {
                LblSiparisNo.Visible = true; CmbSiparisNoMaas.Visible = true;
                LblPersonelSayisi.Visible = false; TxtPersonelSayisi.Visible = false;
                LblPlaka.Visible = true; CmbPlaka.Visible = true;
                return;
            }
            LblSiparisNo.Visible = false; CmbSiparisNoMaas.Visible = false;
            LblPersonelSayisi.Visible = false; TxtPersonelSayisi.Visible = false;
            LblPlaka.Visible = false; CmbPlaka.Visible = false;
        }
        void Plakalar()
        {
            aracZimmetis = aracZimmetiManager.GetList();
            CmbPlaka.DataSource = aracZimmetis;
            CmbPlaka.ValueMember = "Id";
            CmbPlaka.DisplayMember = "Plaka";
            CmbPlaka.SelectedValue = -1;
        }

        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }

        private void SilBasaran5_Click(object sender, EventArgs e)
        {
            stnBasaran5.Text = ""; tBasaran5.Text = ""; mBasaran5.Text = ""; bBasaran5.Text = "";
            if (stnBasaran6.Text != "")
            {
                stnBasaran5.Text = stnBasaran6.Text; tBasaran5.Text = tBasaran6.Text; mBasaran5.Text = mBasaran6.Text;
                bBasaran5.Text = bBasaran6.Text;
                stnBasaran6.Text = stnBasaran7.Text; tBasaran6.Text = tBasaran7.Text; mBasaran6.Text = mBasaran7.Text;
                bBasaran6.Text = bBasaran7.Text;
                stnBasaran7.Text = stnBasaran8.Text; tBasaran7.Text = tBasaran8.Text; mBasaran7.Text = mBasaran8.Text;
                bBasaran7.Text = bBasaran8.Text;
                stnBasaran8.Text = stnBasaran9.Text; tBasaran8.Text = tBasaran9.Text; mBasaran8.Text = mBasaran9.Text;
                bBasaran8.Text = bBasaran9.Text;
                stnBasaran9.Text = stnBasaran10.Text; tBasaran9.Text = tBasaran10.Text; mBasaran9.Text = mBasaran10.Text;
                bBasaran9.Text = bBasaran10.Text;
                stnBasaran10.Text = ""; tBasaran10.Text = ""; mBasaran10.Text = ""; bBasaran10.Text = "";
            }
        }

        private void SilBasaran6_Click(object sender, EventArgs e)
        {
            stnBasaran6.Text = ""; tBasaran6.Text = ""; mBasaran6.Text = ""; bBasaran6.Text = "";
            if (stnBasaran7.Text != "")
            {
                stnBasaran6.Text = stnBasaran7.Text; tBasaran6.Text = tBasaran7.Text; mBasaran6.Text = mBasaran7.Text;
                bBasaran6.Text = bBasaran7.Text;
                stnBasaran7.Text = stnBasaran8.Text; tBasaran7.Text = tBasaran8.Text; mBasaran7.Text = mBasaran8.Text;
                bBasaran7.Text = bBasaran8.Text;
                stnBasaran8.Text = stnBasaran9.Text; tBasaran8.Text = tBasaran9.Text; mBasaran8.Text = mBasaran9.Text;
                bBasaran8.Text = bBasaran9.Text;
                stnBasaran9.Text = stnBasaran10.Text; tBasaran9.Text = tBasaran10.Text; mBasaran9.Text = mBasaran10.Text;
                bBasaran9.Text = bBasaran10.Text;
                stnBasaran10.Text = ""; tBasaran10.Text = ""; mBasaran10.Text = ""; bBasaran10.Text = "";
            }
        }
        private void SilBasaran7_Click(object sender, EventArgs e)
        {
            stnBasaran7.Text = ""; tBasaran7.Text = ""; mBasaran7.Text = ""; bBasaran7.Text = "";
            if (stnBasaran8.Text != "")
            {
                stnBasaran7.Text = stnBasaran8.Text; tBasaran7.Text = tBasaran8.Text; mBasaran7.Text = mBasaran8.Text;
                bBasaran7.Text = bBasaran8.Text;
                stnBasaran8.Text = stnBasaran9.Text; tBasaran8.Text = tBasaran9.Text; mBasaran8.Text = mBasaran9.Text;
                bBasaran8.Text = bBasaran9.Text;
                stnBasaran9.Text = stnBasaran10.Text; tBasaran9.Text = tBasaran10.Text; mBasaran9.Text = mBasaran10.Text;
                bBasaran9.Text = bBasaran10.Text;
                stnBasaran10.Text = ""; tBasaran10.Text = ""; mBasaran10.Text = ""; bBasaran10.Text = "";
            }
        }
        private void SilBasaran8_Click(object sender, EventArgs e)
        {
            stnBasaran8.Text = ""; tBasaran8.Text = ""; mBasaran8.Text = ""; bBasaran8.Text = "";
            if (stnBasaran9.Text != "")
            {
                stnBasaran8.Text = stnBasaran9.Text; tBasaran8.Text = tBasaran9.Text; mBasaran8.Text = mBasaran9.Text;
                bBasaran8.Text = bBasaran9.Text;
                stnBasaran9.Text = stnBasaran10.Text; tBasaran9.Text = tBasaran10.Text; mBasaran9.Text = mBasaran10.Text;
                bBasaran9.Text = bBasaran10.Text;
                stnBasaran10.Text = ""; tBasaran10.Text = ""; mBasaran10.Text = ""; bBasaran10.Text = "";
            }
        }
        private void SilBasaran9_Click(object sender, EventArgs e)
        {
            stnBasaran9.Text = ""; tBasaran9.Text = ""; mBasaran9.Text = ""; bBasaran9.Text = "";
            if (stnBasaran10.Text != "")
            {
                stnBasaran9.Text = stnBasaran10.Text; tBasaran9.Text = tBasaran10.Text; mBasaran9.Text = mBasaran10.Text;
                bBasaran9.Text = bBasaran10.Text;
                stnBasaran10.Text = ""; tBasaran10.Text = ""; mBasaran10.Text = ""; bBasaran10.Text = "";
            }
        }
        private void SilBasaran10_Click(object sender, EventArgs e)
        {
            stnBasaran10.Text = ""; tBasaran10.Text = ""; mBasaran10.Text = ""; bBasaran10.Text = "";
        }
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex==0)
            {
                CmbMalzemeTuru.Text = "";
                DtgStokList.DataSource = null;
                LblIsAkis.Enabled = true;
                LblMalzemeTuru.Enabled = true;
                CmbMalzemeTuru.Enabled = true;
                LblIsAkis.Enabled = true;
                TxtStok.Enabled = true;
                LblTanim.Enabled = true;
                TxtTanim.Enabled = true;
                GrbStokList.Enabled = true;
                LblGunelStokAdeti.Enabled = true;
                LblTopStokList.Enabled = true;
                LblTopStokList.Text = "0";
            }
            if (tabControl2.SelectedIndex == 1)
            {
                CmbMalzemeTuru.Text = "";
                DtgStokList.DataSource = false;
                LblMalzemeTuru.Enabled = false;
                LblIsAkis.Enabled = false;
                CmbMalzemeTuru.Enabled = false;
                LblIsAkis.Enabled = false;
                TxtStok.Enabled = false;
                LblTanim.Enabled = false;
                TxtTanim.Enabled = false;
                GrbStokList.Enabled = false;
                LblGunelStokAdeti.Enabled = false;
                LblTopStokList.Enabled = false;
                LblTopStokList.Text = "0";
            }
        }
        private void CmbFaturaFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CmbFaturaFirma.SelectedIndex;
            CmbIlgiliKisi.SelectedIndex = index;
            CmbMasYeri.SelectedIndex = index;
        }
        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            FrmButceKoduKalemi frmButceKoduKalemi = new FrmButceKoduKalemi();
            frmButceKoduKalemi.Show();
        }
        private void BtnDosyaEkleBasaran_Click(object sender, EventArgs e)
        {
            IsAkisNo2();
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\GEÇİCİ SAT DOSYALARI\";

            isAkisNoBasaran = LblIsAkisNo2.Text;

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyaYoluGun = subdir + isAkisNoBasaran;
            Directory.CreateDirectory(dosyaYoluGun);

            Directory.CreateDirectory(dosyaYoluGun);
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

            if (File.Exists(dosyaYoluGun + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYoluGun + "\\" + kaynakdosyaismi);
                fileNames.Add(alinandosya);
                webBrowser2.Navigate(dosyaYoluGun);
                dosyaEkleGun = true;
            }
        }
        private void BtnKaydetBasaran_Click(object sender, EventArgs e)
        {
            if (dosyaEkleGun == false)
            {
                MessageBox.Show("Lütfen Öncekle Dosya Ekleme İşlemini Gerçekleştiriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbDonemBasaran.Text == "" || CmbDonemBasaranYil.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Dönem Bilgisini Eksiksiz Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbAdSoyad.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Talep Eden Personel Bilgisini Giriniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (TxtGerekceBasaran.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Gerekçe Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string control = MalzemeControlBasaran();
                if (control != "OK")
                {
                    MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                siparisNo = Guid.NewGuid().ToString();
                isleAdimi = "SAT BAŞLATMA ONAYI";
                string donem = CmbDonemBasaran.Text + " " + CmbDonemBasaranYil.Text;
                SatDataGridview1 sat = new SatDataGridview1(0,LblIsAkisNo2.Text.ConInt(), LblMasrafYeriNo.Text, LblAdSoyad.Text, LblMasrafYeri.Text, "", "", DtgIstenenTarihBasaran.Value, TxtGerekceBasaran.Text, siparisNo, CmbAdSoyad.Text, CmbSiparisNo.Text, TxtGorevi.Text, TxtMasrafyeriNo.Text, TxtMasrafYeri.Text,
                  string.IsNullOrEmpty(dosyaYoluGun) ? "" : dosyaYoluGun, infos[0].ConInt(), isleAdimi, donem, "BAŞARAN", TxtProjeKodu.Text, "-");

                string mesaj = satDataGridview1Manager.Add(sat);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                MalzemeleriKaydetBasaran();

            }
        }
        string MalzemeControlBasaran()
        {
            if (stnBasaran1.Text.Trim() != "")
            {
                if (mBasaran1.Text.Trim() == "" || bBasaran1.Text.Trim() == "")
                {
                    return "Lütfen 1. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stnBasaran2.Text.Trim() != "")
            {
                if (mBasaran2.Text.Trim() == "" || bBasaran2.Text.Trim() == "")
                {
                    return "Lütfen 2. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stnBasaran3.Text.Trim() != "")
            {
                if (mBasaran3.Text.Trim() == "" || bBasaran3.Text.Trim() == "")
                {
                    return "Lütfen 3. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stnBasaran4.Text.Trim() != "")
            {
                if (mBasaran4.Text.Trim() == "" || bBasaran4.Text.Trim() == "")
                {
                    return "Lütfen 4. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stnBasaran5.Text.Trim() != "")
            {
                if (mBasaran5.Text.Trim() == "" || bBasaran5.Text.Trim() == "")
                {
                    return "Lütfen 5. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stnBasaran6.Text.Trim() != "")
            {
                if (mBasaran6.Text.Trim() == "" || bBasaran6.Text.Trim() == "")
                {
                    return "Lütfen 6. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stnBasaran7.Text.Trim() != "")
            {
                if (mBasaran7.Text.Trim() == "" || bBasaran7.Text.Trim() == "")
                {
                    return "Lütfen 7. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stnBasaran8.Text.Trim() != "")
            {
                if (mBasaran8.Text.Trim() == "" || bBasaran8.Text.Trim() == "")
                {
                    return "Lütfen 8. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stnBasaran9.Text.Trim() != "")
            {
                if (mBasaran9.Text.Trim() == "" || bBasaran9.Text.Trim() == "")
                {
                    return "Lütfen 9. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            if (stnBasaran10.Text.Trim() != "")
            {
                if (mBasaran10.Text.Trim() == "" || bBasaran10.Text.Trim() == "")
                {
                    return "Lütfen 10. Malzemenin Bilgilerini Eksiksiz Giriniz.";
                }
            }
            return "OK";
        }

        void MalzemeleriKaydetBasaran()
        {
            List<SatinAlinacakMalzemeler> list = new List<SatinAlinacakMalzemeler>();
            if (stnBasaran1.Text.Trim() != "" && tBasaran1.Text.Trim() != "" && mBasaran1.Text.Trim() != "" && bBasaran1.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stnBasaran1.Text, tBasaran1.Text, mBasaran1.Text.ConInt(), bBasaran1.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stnBasaran2.Text.Trim() != "" && tBasaran2.Text.Trim() != "" && mBasaran2.Text.Trim() != "" && bBasaran2.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stnBasaran2.Text, tBasaran2.Text, mBasaran2.Text.ConInt(), bBasaran2.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stnBasaran3.Text.Trim() != "" && tBasaran3.Text.Trim() != "" && mBasaran3.Text.Trim() != "" && bBasaran3.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stnBasaran3.Text, tBasaran3.Text, mBasaran3.Text.ConInt(), bBasaran3.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stnBasaran4.Text.Trim() != "" && tBasaran4.Text.Trim() != "" && mBasaran4.Text.Trim() != "" && bBasaran4.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stnBasaran4.Text, tBasaran4.Text, mBasaran4.Text.ConInt(), bBasaran4.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stnBasaran5.Text.Trim() != "" && tBasaran5.Text.Trim() != "" && mBasaran5.Text.Trim() != "" && bBasaran5.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stnBasaran5.Text, tBasaran5.Text, mBasaran5.Text.ConInt(), bBasaran5.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stnBasaran6.Text.Trim() != "" && tBasaran6.Text.Trim() != "" && mBasaran6.Text.Trim() != "" && bBasaran6.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stnBasaran6.Text, tBasaran6.Text, mBasaran6.Text.ConInt(), bBasaran6.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stnBasaran7.Text.Trim() != "" && tBasaran7.Text.Trim() != "" && mBasaran7.Text.Trim() != "" && bBasaran7.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stnBasaran7.Text, tBasaran7.Text, mBasaran7.Text.ConInt(), bBasaran7.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stnBasaran8.Text.Trim() != "" && tBasaran8.Text.Trim() != "" && mBasaran8.Text.Trim() != "" && bBasaran8.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stnBasaran8.Text, tBasaran8.Text, mBasaran8.Text.ConInt(), bBasaran8.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stnBasaran9.Text.Trim() != "" && tBasaran9.Text.Trim() != "" && mBasaran9.Text.Trim() != "" && bBasaran9.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stnBasaran9.Text, tBasaran9.Text, mBasaran9.Text.ConInt(), bBasaran9.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (stnBasaran10.Text.Trim() != "" && tBasaran10.Text.Trim() != "" && mBasaran10.Text.Trim() != "" && bBasaran10.Text.Trim() != "")
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(stnBasaran10.Text, tBasaran10.Text, mBasaran10.Text.ConInt(), bBasaran10.Text, siparisNo);
                list.Add(satinAlinacakMalzeme);
            }

            if (list.Count == 0)
            {
                MessageBox.Show("Eleman Bulunamadı");
                return;
            }

            foreach (SatinAlinacakMalzemeler item in list)
            {
                message = satinAlinacakMalManager.Add(item, siparisNo);
            }
            if (message == "OK")
            {
                islem = "SATIN ALMA TALEBİ OLUŞTURULDU.";
                islemyapan = infos[1].ToString();
                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, islem, islemyapan, DateTime.Now);
                satIslemAdimlariManager.Add(satIslem);

                MessageBox.Show(isAkisNoBasaran + " Numaralı SAT Kaydınız Başarıyla Oluşturulmuştur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleBasaran();
                IsAkisNo();
                IsAkisNo2();
                dosyaEkleGun = false;
            }
            else
            {
                MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void TemizleBasaran()
        {
            CmbAdSoyad.Text = ""; CmbSiparisNo.Clear(); TxtGorevi.Clear(); TxtMasrafyeriNo.Clear(); TxtMasrafYeri.Clear(); TxtStok.Clear(); TxtTanim.Clear(); CmbMalzemeTuru.Text = ""; TxtGerekceBasaran.Clear();
            stnBasaran1.Clear(); tBasaran1.Clear(); mBasaran1.Clear(); bBasaran1.Text = "";
            stnBasaran2.Clear(); tBasaran2.Clear(); mBasaran2.Clear(); bBasaran2.Text = "";
            stnBasaran3.Clear(); tBasaran3.Clear(); mBasaran3.Clear(); bBasaran3.Text = "";
            stnBasaran4.Clear(); tBasaran4.Clear(); mBasaran4.Clear(); bBasaran4.Text = "";
            stnBasaran5.Clear(); tBasaran5.Clear(); mBasaran5.Clear(); bBasaran5.Text = "";
            stnBasaran6.Clear(); tBasaran6.Clear(); mBasaran6.Clear(); bBasaran6.Text = "";
            stnBasaran7.Clear(); tBasaran7.Clear(); mBasaran7.Clear(); bBasaran7.Text = "";
            stnBasaran8.Clear(); tBasaran8.Clear(); mBasaran8.Clear(); bBasaran8.Text = "";
            stnBasaran9.Clear(); tBasaran9.Clear(); mBasaran9.Clear(); bBasaran9.Text = "";
            stnBasaran10.Clear(); tBasaran10.Clear(); mBasaran10.Clear(); bBasaran10.Text = ""; 
            DtgStokList.DataSource = null; webBrowser2.Navigate(""); CmbDonemBasaran.SelectedValue = "";
            TxtProjeKodu.Clear(); CmbDonemBasaranYil.SelectedValue = "";
        }
        private void BtnDosyaEkleT_Click(object sender, EventArgs e)
        {
            IsAkisNo2();
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\GEÇİCİ SAT DOSYALARI\";

            isAkisNoBasaran = LblIsAkisNo2.Text;

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyaYoluTemsili = subdir + isAkisNoBasaran;
            Directory.CreateDirectory(dosyaYoluTemsili);

            Directory.CreateDirectory(dosyaYoluTemsili);
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

            if (File.Exists(dosyaYoluTemsili + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYoluTemsili + "\\" + kaynakdosyaismi);
                fileNames.Add(alinandosya);
                webBrowser3.Navigate(dosyaYoluTemsili);
                dosyaEkleTemsili = true;
            }
        }
        private void BtnKaydetT_Click(object sender, EventArgs e)
        {
            if (dosyaEkleTemsili == false)
            {
                MessageBox.Show("Lütfen Öncekle Dosya Ekleme İşlemini Gerçekleştiriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbAdSoyad.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Talep Eden Personel Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtGerekceBasaran.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Gerekçe Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtTutar.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Tutar Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbButceKodu.Text == "BM32/AKARYAKIT, NAKİT")
            {
                if (CmbPlaka.Text=="")
                {
                    MessageBox.Show("Lütfen Öncelikle PLAKA Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (CmbButceKodu.Text == "BM25/PERS. MAAŞ GİDERLERİ" || CmbButceKodu.Text == "BM22/KİRA YARDIMI" ||
                CmbButceKodu.Text == "BM21/İAŞE, İLETİŞİM GİDERLERİ" ||  CmbButceKodu.Text == "BM01/İŞ GİYSİSİ" || CmbButceKodu.Text == "BM23/ÖZEL SİGRT. GİDERLERİ" || CmbButceKodu.Text == "BM38/PERSONEL GİDERLERİ")
            {
                if (CmbSiparisNoMaas.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle SİPARİŞ NO Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TxtPersonelSayisi.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle PERSONEL SAYISI Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                siparisNo = Guid.NewGuid().ToString();
                isleAdimi = "SAT ONAY";

                string donem = CmbDonemBasaran.Text + " " + CmbDonemBasaranYil.Text;
                SatDataGridview1 sat = new SatDataGridview1(0,LblIsAkisNo2.Text.ConInt(), LblMasrafYeriNo.Text, LblAdSoyad.Text, LblMasrafYeri.Text, "YOK", "YOK", DtgIstenenTarihBasaran.Value, TxtGerekceBasaran.Text, siparisNo, CmbAdSoyad.Text, CmbSiparisNo.Text, TxtGorevi.Text, TxtMasrafyeriNo.Text, TxtMasrafYeri.Text,
                  string.IsNullOrEmpty(dosyaYoluTemsili) ? "" : dosyaYoluTemsili, infos[0].ConInt(), isleAdimi, donem, "HARCAMASI YAPILAN", TxtProjeKodu.Text, TxtSatinAlinanFirma.Text);
                string mesaj = satDataGridview1Manager.Add(sat);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SatDataGridview1 satData = new SatDataGridview1(CmbButceKodu.Text, CmbSatBirim.Text, CmbHarcamaTuru.Text, CmbFaturaFirma.Text, CmbIlgiliKisi.Text, CmbMasYeri.Text, siparisNo,0, CmbBelgeTuru.Text, TxtBelgeNumarasi.Text, DtBelgeTarihi.Value, isleAdimi, donem);

                string mesaj2= satDataGridview1Manager.TemsiliAgirlama(satData);

                if (mesaj2!="OK")
                {
                    MessageBox.Show(mesaj2,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                satDataGridview1Manager.TeklifDurum(siparisNo); // ALINDI
                satDataGridview1Manager.DurumGuncelleOnay(siparisNo); // SAT BAŞLATMA ONAYI ONAYLANDI
                
                TeklifsizSat teklifsizSat = new TeklifsizSat("", "", 0, "", TxtTutar.Text.ConDouble(), siparisNo);
                string mesaj3 = teklifsizSatManager.Add(teklifsizSat);

                if (mesaj3!="OK")
                {
                    MessageBox.Show(mesaj3,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                islem = "SATIN ALMA TALEBİ OLUŞTURULDU.";
                islemyapan = infos[1].ToString();
                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, islem, islemyapan, DateTime.Now);
                satIslemAdimlariManager.Add(satIslem);

                if (CmbButceKodu.Text == "BM32 / AKARYAKIT, NAKİT")
                {
                    satDataGridview1Manager.SatButceKoduPlaka(CmbSiparisNoMaas.Text, CmbPlaka.Text, siparisNo);
                }
                if (CmbButceKodu.Text == "BM25/PERS. MAAŞ GİDERLERİ" || CmbButceKodu.Text == "BM22/KİRA YARDIMI" ||
                CmbButceKodu.Text == "BM21/İAŞE, İLETİŞİM GİDERLERİ" || CmbButceKodu.Text == "BM01/İŞ GİYSİSİ" || CmbButceKodu.Text == "BM23/ÖZEL SİGRT. GİDERLERİ" || CmbButceKodu.Text == "BM38/PERSONEL GİDERLERİ")
                {
                    satDataGridview1Manager.SatButceKoduGider(CmbSiparisNoMaas.Text, TxtPersonelSayisi.Text, siparisNo);
                }

                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                TemizleTemsili();
                IsAkisNo();
                IsAkisNo2();
            }
        }
        void TemizleTemsili()
        {
            CmbAdSoyad.Text = ""; CmbSiparisNo.Clear(); TxtGorevi.Clear(); TxtMasrafyeriNo.Clear(); TxtMasrafYeri.Clear(); TxtStok.Clear(); TxtTanim.Clear(); CmbMalzemeTuru.Text = ""; TxtGerekceBasaran.Clear();
            CmbBelgeTuru.Text = ""; TxtBelgeNumarasi.Clear(); CmbButceKodu.SelectedValue = -1; 
            CmbSatBirim.Text = ""; CmbHarcamaTuru.Text = ""; CmbFaturaFirma.Text = ""; webBrowser3.Navigate(""); TxtTutar.Clear(); CmbDonemBasaran.SelectedValue = ""; TxtProjeKodu.Clear();
        }
        private void TxtTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
    }
}
