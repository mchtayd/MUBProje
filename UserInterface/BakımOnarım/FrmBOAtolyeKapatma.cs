using Business.Concreate;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarimAtolye;
using Entity.Gecic_Kabul_Ambar;
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

namespace UserInterface.BakımOnarım
{
    public partial class FrmBOAtolyeKapatma : Form
    {
        AtolyeManager atolyeManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        AtolyeMalzemeManager atolyeMalzemeManager;
        AtolyeAltMalzemeManager atolyeAltMalzemeManager;
        StokGirisCikisManager stokGirisCikisManager;

        List<Atolye> atolyes;
        List<GorevAtamaPersonel> gorevAtamaPersonels;
        List<AtolyeAltMalzeme> atolyeAltMalzemes;
        List<StokGirisCıkıs> stokGirisCikis;

        string siparisNo, bulunduguIslemAdimi, sure, kaynakdosyaismi, alinandosya, dosyaYolu;
        int id, gun, saat, dakika, abfNo, arizaDurumu;
        DateTime birOncekiTarih;
        bool dosyaKontrol = false;

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (sonIslemAdimi != "1500-SİPARİŞ KAPATMA  (AMBAR VERİ KAYIT)")
            {
                MessageBox.Show("Bu Kayıt 1500-SİPARİŞ KAPATMA  (AMBAR VERİ KAYIT) İşlem Adımında Bulunmamaktadır. Sadece Bu İşlem Adımında Kapatma Yapabilirsiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (dosyaKontrol==false)
            {
                MessageBox.Show("Lütfen Öncelikle Bakım Onarım İzleme Formunu Taratarak Ekleyiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(TxtIcSiparisNo.Text + " Nolu Kaydı Kapatmak İstediğinize Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                atolyeManager.ArizaKapat(id, 0, DateTime.Now);

                GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", bulunduguIslemAdimi, sure, "00:25:00".ConOnlyTime());
                string kontrol2 = gorevAtamaPersonelManager.Update(gorevAtama, "SİPARİŞ KAPATILMIŞTIR");
                if (kontrol2 != "OK")
                {
                    MessageBox.Show(kontrol2,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                Temizle();
                dosyaKontrol = false;
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }
        void Temizle()
        {
            TxtIcSiparisNo.Clear(); TxtStokNoUst.Clear(); TxtTanimUst.Clear(); TxtSeriNoUst.Clear(); TxtGarantiDurumuUst.Clear(); LblDurumKapali.Visible = false; 
            LblDurumAcik.Visible = false; LblIslemAdimiAcik.Visible = false; LblIslemAdimiKapali.Visible = false; TxtBildirimNo.Clear(); TxtScrmNo.Clear(); TxtKategori.Clear(); TxtBolgeAdi.Clear(); TxtProje.Clear(); DtgAtolye.DataSource = null; DtgIslemKayitlari.DataSource = null; DtgMalzemeler.DataSource = null; webBrowser1.Navigate("");
        }

        public FrmBOAtolyeKapatma()
        {
            InitializeComponent();
            atolyeManager = AtolyeManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            atolyeMalzemeManager = AtolyeMalzemeManager.GetInstance();
            atolyeAltMalzemeManager = AtolyeAltMalzemeManager.GetInstance();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
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
                dosyaKontrol = true;
                webBrowser1.Navigate(dosyaYolu);
            }
        }

        private void FrmBOAtolyeKapatma_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageAtolyeKapatma"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtIcSiparisNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İç Sipariş No Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            atolyes = atolyeManager.AtolyeIcSiparis(TxtIcSiparisNo.Text);
            if (atolyes.Count==0)
            {
                MessageBox.Show("Girmiş Oludğunuz İç Sipariş Numarasına Göre Bir Kayıt Bulunamamıştır!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            foreach (Atolye item in atolyes)
            {
                siparisNo = item.SiparisNo.ToString();
            }

            Atolye atolye = atolyeManager.Get(TxtIcSiparisNo.Text);
            if (atolye==null)
            {
                MessageBox.Show("Girmiş Oludğunuz İç Sipariş Numarasına Göre Bir Kayıt Bulunamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = atolye.Id;
            abfNo = atolye.AbfNo;
            Atolye atolye2 = atolyeManager.ArizaGetir(abfNo);

            TxtStokNoUst.Text = atolye.StokNoUst;
            TxtTanimUst.Text = atolye.TanimUst;
            TxtSeriNoUst.Text = atolye.SeriNoUst;
            TxtGarantiDurumuUst.Text = atolye.GarantiDurumu;
            TxtBildirimNo.Text = atolye.BildirimNo;
            TxtScrmNo.Text = atolye.CrmNo;
            TxtKategori.Text = atolye.Kategori;
            TxtBolgeAdi.Text = atolye.BolgeAdi;
            TxtProje.Text = atolye.Proje;
            arizaDurumu = atolye2.ArizaDurum;
            dosyaYolu = atolye.DosyaYolu;
            webBrowser1.Navigate(dosyaYolu);

            if (arizaDurumu==0)
            {
                LblDurumAcik.Visible = false;
                LblDurumKapali.Visible = true;
                LblIslemAdimiAcik.Text = atolye2.BulunduguIslemAdimi;
                LblIslemAdimiKapali.Visible = false;
                LblIslemAdimiAcik.Visible = true;
            }
            else
            {
                LblDurumAcik.Visible = true;
                LblDurumKapali.Visible = false;
                LblIslemAdimiKapali.Text = atolye2.BulunduguIslemAdimi;
                LblIslemAdimiKapali.Visible = true;
                LblIslemAdimiAcik.Visible = false;
            }

            //bulunduguIslemAdimi = atolye1.IslemAdimi;

            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "BAKIM ONARIM ATOLYE");

            bulunduguIslemAdimi = gorevAtamaPersonel.IslemAdimi;
            birOncekiTarih = gorevAtamaPersonel.Tarih;
            //LblMevcutIslemAdimi.Text = bulunduguIslemAdimi;

            TimeSpan SonucGun = DateTime.Now - birOncekiTarih;
            TimeSpan SonucSaat = DateTime.Now - birOncekiTarih;
            TimeSpan SonucDakika = DateTime.Now - birOncekiTarih;

            gun = SonucGun.TotalDays.ConInt();
            saat = SonucSaat.TotalHours.ConInt();
            if (SonucSaat.TotalHours < 1)
            {
                saat = 0;
            }
            dakika = SonucDakika.TotalMinutes.ConInt();
            SureBul();

            DtgAtolye.DataSource = atolyeMalzemeManager.AtolyeMalzemeBul(siparisNo);

            DtgAtolye.Columns["Id"].Visible = false;
            DtgAtolye.Columns["FormNo"].HeaderText = "FORM NO";
            DtgAtolye.Columns["StokNo"].HeaderText = "STOK NO";
            DtgAtolye.Columns["Tanim"].HeaderText = "TANIM";
            DtgAtolye.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgAtolye.Columns["Durum"].HeaderText = "DURUM";
            DtgAtolye.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgAtolye.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgAtolye.Columns["TalepTarihi"].HeaderText = "TALEP TARİHİ";
            DtgAtolye.Columns["SiparisNo"].Visible = false;

            IslemAdimlariSureleri();
            DataDisplayAltMalzeme();
            DepoHareketleri();
        }
        void DepoHareketleri()
        {
            stokGirisCikis = stokGirisCikisManager.AtolyeDepoHareketleri(TxtIcSiparisNo.Text);
            DtgDepoHareketleri.DataSource = stokGirisCikis;

            DtgDepoHareketleri.Columns["Id"].Visible = false;
            DtgDepoHareketleri.Columns["Islemturu"].HeaderText = "İŞLEM TÜRÜ";
            DtgDepoHareketleri.Columns["IslemTarihi"].HeaderText = "İŞLEM TARİHİ";
            DtgDepoHareketleri.Columns["Stokno"].HeaderText = "STOK NO";
            DtgDepoHareketleri.Columns["Tanim"].HeaderText = "TANIM";
            DtgDepoHareketleri.Columns["Serino"].HeaderText = "SERİ NO";
            DtgDepoHareketleri.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgDepoHareketleri.Columns["DusulenMiktar"].HeaderText = "DÜŞÜLEN MİKTAR";
            DtgDepoHareketleri.Columns["Birim"].HeaderText = "BİRİM";
            DtgDepoHareketleri.Columns["Lotno"].HeaderText = "LOT NO";
            DtgDepoHareketleri.Columns["CekilenDepoNo"].HeaderText = "ÇEKİLEN DEPO NO/YER";
            DtgDepoHareketleri.Columns["CekilenDepoAdresi"].HeaderText = "ÇEKİLEN DEPO ADRESİ";
            DtgDepoHareketleri.Columns["CekilenMalzemeYeri"].HeaderText = "ÇEKİLEN MALZEME YERİ";
            DtgDepoHareketleri.Columns["DusulenDepoNo"].HeaderText = "DÜŞÜLEN DEPO NO/YER";
            DtgDepoHareketleri.Columns["DusulenDepoAdresi"].HeaderText = "DÜŞÜLEN DEPO ADRESİ";
            DtgDepoHareketleri.Columns["DusulenMalzemeYeri"].HeaderText = "DÜŞÜLEN MALZEME YERİ";
            DtgDepoHareketleri.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgDepoHareketleri.Columns["Aciklama"].HeaderText = "AÇIKLAMA";


            DtgDepoHareketleri.Columns["Id"].DisplayIndex = 0;
            DtgDepoHareketleri.Columns["Islemturu"].DisplayIndex = 1;
            DtgDepoHareketleri.Columns["IslemTarihi"].DisplayIndex = 2;
            DtgDepoHareketleri.Columns["Stokno"].DisplayIndex = 3;
            DtgDepoHareketleri.Columns["Tanim"].DisplayIndex = 4;
            DtgDepoHareketleri.Columns["Serino"].DisplayIndex = 5;
            DtgDepoHareketleri.Columns["Revizyon"].DisplayIndex = 6;
            DtgDepoHareketleri.Columns["DusulenMiktar"].DisplayIndex = 7;
            DtgDepoHareketleri.Columns["Birim"].DisplayIndex = 8;
            DtgDepoHareketleri.Columns["Lotno"].DisplayIndex = 9;
            DtgDepoHareketleri.Columns["CekilenDepoNo"].DisplayIndex = 10;
            DtgDepoHareketleri.Columns["CekilenDepoAdresi"].DisplayIndex = 11;
            DtgDepoHareketleri.Columns["CekilenMalzemeYeri"].DisplayIndex = 12;
            DtgDepoHareketleri.Columns["DusulenDepoNo"].DisplayIndex = 13;
            DtgDepoHareketleri.Columns["DusulenDepoAdresi"].DisplayIndex = 14;
            DtgDepoHareketleri.Columns["DusulenMalzemeYeri"].DisplayIndex = 15;
            DtgDepoHareketleri.Columns["TalepEdenPersonel"].DisplayIndex = 16;
            DtgDepoHareketleri.Columns["Aciklama"].DisplayIndex = 17;

        }
        void DataDisplayAltMalzeme()
        {
            atolyeAltMalzemes = atolyeAltMalzemeManager.GetList(siparisNo);
            dataBinder2.DataSource = atolyeAltMalzemes.ToDataTable();
            DtgMalzemeler.DataSource = dataBinder2;

            DtgMalzemeler.Columns["Id"].Visible = false;
            DtgMalzemeler.Columns["StokNo"].HeaderText = "STOK NO";
            DtgMalzemeler.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzemeler.Columns["SokulenSeriNo"].HeaderText = "SÖKÜLEN SERİ NO";
            DtgMalzemeler.Columns["TakilanSeriNo"].HeaderText = "TAKILAN SERİ NO";
            DtgMalzemeler.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzemeler.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzemeler.Columns["MalzemeyeYapilanIslem"].HeaderText = "MALZEMEYE YAPILAN İŞLEM";
            DtgMalzemeler.Columns["SiparisNo"].Visible = false;
        }

        string sonIslemAdimi = "";
        void IslemAdimlariSureleri()
        {
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetList(id, "BAKIM ONARIM ATOLYE");
            DtgIslemKayitlari.DataSource = gorevAtamaPersonels;

            DtgIslemKayitlari.Columns["Id"].Visible = false;
            DtgIslemKayitlari.Columns["BenzersizId"].Visible = false;
            DtgIslemKayitlari.Columns["Departman"].Visible = false;
            DtgIslemKayitlari.Columns["GorevAtanacakPersonel"].HeaderText = "GÖREV ATANACAK ERSONEL";
            DtgIslemKayitlari.Columns["IslemAdimi"].HeaderText = "İŞLEM ADIMI";
            DtgIslemKayitlari.Columns["Tarih"].HeaderText = "TARİH";
            DtgIslemKayitlari.Columns["Sure"].HeaderText = "İŞLEM ADIMI SÜRELERİ";
            DtgIslemKayitlari.Columns["YapilanIslem"].HeaderText = "YAPILAN İŞLEM";

            int sonKayit = gorevAtamaPersonels.Count;

            sonIslemAdimi = gorevAtamaPersonels[sonKayit - 1].IslemAdimi;

        }
        void SureBul()
        {
            if (gun == 0)
            {
                if (saat == 0)
                {
                    if (dakika != 0)
                    {
                        sure = dakika.ToString() + " Dakika";
                        return;
                    }
                    sure = "0" + " Dakika";
                    return;
                }
                sure = saat.ToString() + " Saat" + dakika.ToString() + " Dakika";
                return;
            }
            sure = gun.ToString() + " Gün" + saat.ToString() + " Saat" + dakika.ToString() + " Dakika";
            return;
        }
    }
}
