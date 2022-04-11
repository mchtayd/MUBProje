using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarim;
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

namespace UserInterface.BakımOnarım
{
    public partial class FrmBildirimOnayi : Form
    {
        ArizaKayitManager arizaKayitManager;
        AbfMalzemeManager abfMalzemeManager;
        PersonelKayitManager personelKayitManager;
        IslemAdimlariManager islemAdimlariManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;

        List<ArizaKayit> arizaKayits;
        List<AbfMalzeme> abfMalzemes;
        int id, gun, saat, dakika;
        string dosyaYolu, abfNo, sure;
        DateTime birOncekiTarih;

        public FrmBildirimOnayi()
        {
            InitializeComponent();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            personelKayitManager = PersonelKayitManager.GetInstance();
            islemAdimlariManager = IslemAdimlariManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
        }

        private void FrmBildirimOnayi_Load(object sender, EventArgs e)
        {
            DataDisplay();
            Personeller();
            CrmIslemAdimlari();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageBildirimOnayi"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void Personeller()
        {
            CmbGorevAtanacakPersonel.DataSource = personelKayitManager.PersonelAdSoyad();
            CmbGorevAtanacakPersonel.ValueMember = "Id";
            CmbGorevAtanacakPersonel.DisplayMember = "Adsoyad";
            CmbGorevAtanacakPersonel.SelectedValue = -1;
        }
        void CrmIslemAdimlari()
        {
            CmbCrmIslemAdimlari.DataSource = islemAdimlariManager.GetList("BAKIM ONARIM");
            CmbCrmIslemAdimlari.ValueMember = "Id";
            CmbCrmIslemAdimlari.DisplayMember = "IslemaAdimi";
            CmbCrmIslemAdimlari.SelectedValue = -1;
        }
        void DataDisplay()
        {
            arizaKayits = arizaKayitManager.BildirimOnayiList();
            dataBinder.DataSource = arizaKayits.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["IsAkisNo"].Visible = false;
            DtgList.Columns["AbfFormNo"].HeaderText = "ABF FORM NO";
            DtgList.Columns["Proje"].HeaderText = "PROJE";
            DtgList.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgList.Columns["BolukKomutani"].Visible = false;
            DtgList.Columns["BirlikAdresi"].Visible = false;
            DtgList.Columns["Il"].Visible = false;
            DtgList.Columns["Ilce"].Visible = false;
            DtgList.Columns["BildirilenAriza"].Visible = false;
            DtgList.Columns["ArizaiBildirenPersonel"].Visible = false;
            DtgList.Columns["AbRutbesi"].Visible = false;
            DtgList.Columns["AbGorevi"].Visible = false;
            DtgList.Columns["AbTelefon"].Visible = false;
            DtgList.Columns["AbTarihSaat"].HeaderText = "ARIZA BİLDİRİM TARİHİ/SAATİ";
            DtgList.Columns["ABAlanPersonel"].Visible = false;
            DtgList.Columns["BildirimKanali"].Visible = false;
            DtgList.Columns["ArizaAciklama"].HeaderText = "ARIZA AÇIKLAMA";
            DtgList.Columns["GorevAtanacakPersonel"].HeaderText = "İŞLEM ADIMI SORUMLUSU";
            DtgList.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgList.Columns["DosyaYolu"].Visible = false;
            DtgList.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgList.Columns["LojistikSorumluPersonel"].Visible = false;
            DtgList.Columns["LojRutbesi"].Visible = false;
            DtgList.Columns["LojGorevi"].Visible = false;
            DtgList.Columns["LojTarihi"].Visible = false;
            DtgList.Columns["TespitEdilenAriza"].Visible = false;
            DtgList.Columns["AcmaOnayiVeren"].Visible = false;
            DtgList.Columns["CsSiparisNo"].HeaderText = "CS SİPARİŞ NO";
            DtgList.Columns["BildirimNo"].HeaderText = "BİLDİRİM NO";
            DtgList.Columns["CrmNo"].HeaderText = "CRM HİZMET NO";
            DtgList.Columns["SiparisNo"].Visible = false;
            DtgList.Columns["BildirimMailTarihi"].Visible = false;
            DtgList.Columns["TelefonNo"].Visible = false;
            DtgList.Columns["StokNo"].HeaderText = "STOK NO";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgList.Columns["Kategori"].HeaderText = "KATEGORİ";
            DtgList.Columns["IlgiliFirma"].Visible = false;
            DtgList.Columns["BildirimTuru"].HeaderText = "BİLDİRİM TÜRÜ";
            DtgList.Columns["PypNo"].Visible = false;
            DtgList.Columns["SorumluPersonel"].Visible = false;
            DtgList.Columns["IslemTuru"].Visible = false;
            DtgList.Columns["Hesaplama"].Visible = false;


            DtgList.Columns["AbfFormNo"].DisplayIndex = 0;
            DtgList.Columns["Proje"].DisplayIndex = 1;
            DtgList.Columns["BolgeAdi"].DisplayIndex = 2;
            DtgList.Columns["AbTarihSaat"].DisplayIndex = 3;
            DtgList.Columns["BildirimTuru"].DisplayIndex = 4;
            DtgList.Columns["Kategori"].DisplayIndex = 5;
            DtgList.Columns["CsSiparisNo"].DisplayIndex = 6;
            DtgList.Columns["BildirimNo"].DisplayIndex = 7;
            DtgList.Columns["CrmNo"].DisplayIndex = 8;
            DtgList.Columns["StokNo"].DisplayIndex = 9;
            DtgList.Columns["Tanim"].DisplayIndex = 10;
            DtgList.Columns["SeriNo"].DisplayIndex = 11;
            DtgList.Columns["GarantiDurumu"].DisplayIndex = 13;
            DtgList.Columns["IslemAdimi"].DisplayIndex = 14;
            DtgList.Columns["GorevAtanacakPersonel"].DisplayIndex = 15;
        }
        
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            dosyaYolu = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            abfNo = DtgList.CurrentRow.Cells["AbfFormNo"].Value.ToString();

            ArizaKayit arizaKayit = arizaKayitManager.Get(abfNo.ConInt());
            LblMevcutIslemAdimi.Text = arizaKayit.IslemAdimi;
            MalzemeListesi();
            CrmSureBul();
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string mesaj = Konrol();
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            mesaj = GorevAtama();
            if (mesaj!="OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataDisplay();
            Temizle();
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        void MalzemeListesi()
        {
            abfMalzemes = abfMalzemeManager.GetList(id);
            DtgMalzemeListesi.DataSource = abfMalzemes;

            DtgMalzemeListesi.Columns["Id"].Visible = false;
            DtgMalzemeListesi.Columns["BenzersizId"].Visible = false;
            DtgMalzemeListesi.Columns["SokulenStokNo"].HeaderText = "SÖKÜLEN STOK NO";
            DtgMalzemeListesi.Columns["SokulenTanim"].HeaderText = "SÖKÜLEN TANIM";
            DtgMalzemeListesi.Columns["SokulenSeriNo"].HeaderText = "SÖKÜLEN SERİ NO";
            DtgMalzemeListesi.Columns["SokulenMiktar"].HeaderText = "SÖKÜLEN MİKTAR";
            DtgMalzemeListesi.Columns["SokulenBirim"].HeaderText = "SÖKÜLEN BİRİM";
            DtgMalzemeListesi.Columns["SokulenCalismaSaati"].HeaderText = "SÖKÜLEN ÇALIŞMA SAATİ";
            DtgMalzemeListesi.Columns["SokulenRevizyon"].HeaderText = "SÖKÜLEN REVİZYON";
            DtgMalzemeListesi.Columns["CalismaDurumu"].HeaderText = "ÇALIŞMA DURUMU";
            DtgMalzemeListesi.Columns["FizikselDurum"].HeaderText = "FİSİZKSEL DURUM";
            DtgMalzemeListesi.Columns["YapilacakIslem"].HeaderText = "YAPILACAK İŞLEM";
            DtgMalzemeListesi.Columns["TakilanStokNo"].Visible = false;
            DtgMalzemeListesi.Columns["TakilanTanim"].Visible = false;
            DtgMalzemeListesi.Columns["TakilanSeriNo"].Visible = false;
            DtgMalzemeListesi.Columns["TakilanMiktar"].Visible = false;
            DtgMalzemeListesi.Columns["TakilanBirim"].Visible = false;
            DtgMalzemeListesi.Columns["TakilanCalismaSaati"].Visible = false;
            DtgMalzemeListesi.Columns["TakilanRevizyon"].Visible = false;

        }
        string Konrol()
        {
            if (LblMevcutIslemAdimi.Text=="00")
            {
                return "Lütfen öncelikle geçerli bir kayıt seçiniz.";
            }
            if (CmbGorevAtanacakPersonel.Text == "")
            {
                return "Lütfen görev atanacak personel bilgisini seçiniz.";
            }
            if (CmbCrmIslemAdimlari.Text == "")
            {
                return "Lütfen biş sonraki işlem adımı bilgisini seçiniz.";
            }
            return "OK";
        }
        string GorevAtama()
        {
            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(id, "BAKIM ONARIM", LblMevcutIslemAdimi.Text, sure, "00:05:00".ConOnlyTime());
            string kontrol2 = gorevAtamaPersonelManager.Update(gorevAtama, TxtYapilanIslemler.Text);
            if (kontrol2 != "OK")
            {
                return kontrol2;
            }
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "BAKIM ONARIM", CmbGorevAtanacakPersonel.Text, CmbCrmIslemAdimlari.Text, DateTime.Now, "", DateTime.Now.Date);
            string kontrol = gorevAtamaPersonelManager.Add(gorevAtamaPersonel);

            if (kontrol != "OK")
            {
                return kontrol;
            }
            arizaKayitManager.IslemAdimiGuncelle(id, CmbCrmIslemAdimlari.Text, CmbGorevAtanacakPersonel.Text);
            return "OK";
        }
        void CrmSureBul()
        {
            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "BAKIM ONARIM");

            birOncekiTarih = gorevAtamaPersonel.Tarih;

            TimeSpan sonuc = DateTime.Now - birOncekiTarih;

            gun = sonuc.Days.ConInt();
            saat = sonuc.Hours.ConInt();
            if (sonuc.Hours < 1)
            {
                saat = 0;
            }

            dakika = sonuc.Seconds.ConInt() % 60;

            sure = gun.ToString() + " Gün " + saat.ToString() + " Saat " + dakika.ToString() + " Dakika";
        }
        void Temizle()
        {
            LblMevcutIslemAdimi.Text = "00"; CmbGorevAtanacakPersonel.SelectedIndex = -1; CmbCrmIslemAdimlari.SelectedIndex = -1; DtgMalzemeListesi.DataSource = null;
        }
    }
}
