using Business;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity;
using Entity.IdariIsler;
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

namespace UserInterface.IdariIsler
{
    public partial class FrmZiyaretciKayit : Form
    {
        PersonelKayitManager kayitManager;
        SiparisPersonelManager siparisPersonelManager;
        ZiyaretciKayitManager ziyaretciKayitManager;
        IsAkisNoManager isAkisNoManager;
        IdariIslerLogManager idariIslerLogManager;
        public object[] infos;
        bool start = false;
        public FrmZiyaretciKayit()
        {
            InitializeComponent();
            kayitManager = PersonelKayitManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            ziyaretciKayitManager = ZiyaretciKayitManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            idariIslerLogManager = IdariIslerLogManager.GetInstance();
        }

        private void FrmZiyaretciKayit_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            Personeller1();
            Personeller2();
            start = true;
        }
        public void YenilenecekVeriler()
        {
            IsAkisNo();
            Personeller1();
            Personeller2();
            start = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageZiyaretci"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void Personeller1()
        {
            CmbZiyaretEdilenAd.DataSource = kayitManager.PersonelAdSoyad();
            CmbZiyaretEdilenAd.ValueMember = "Id";
            CmbZiyaretEdilenAd.DisplayMember = "Adsoyad";
            CmbZiyaretEdilenAd.SelectedValue = -1;
        }
        void Personeller2()
        {
            CmbRefakatciAd.DataSource = kayitManager.PersonelAdSoyad();
            CmbRefakatciAd.ValueMember = "Id";
            CmbRefakatciAd.DisplayMember = "Adsoyad";
            CmbRefakatciAd.SelectedValue = -1;
        }

        private void CmbZiyaretEdilenAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start==false)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbZiyaretEdilenAd.Text);
            TxtZiyaretEdilenUnvani.Text = siparis.Gorevi;
            TxtZiyaretEdilenMasYeriNo.Text = siparis.Masrafyerino;
            TxtZiyaretEdilenMasYeri.Text = siparis.Masrafyeri;
        }

        private void CmbRefakatciAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            //Temizle();
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbRefakatciAd.Text);
            TxtRefakatciUnvani.Text = siparis.Gorevi;
            TxtRefakatciMasYeriNo.Text = siparis.Masrafyerino;
            TxtRefakatciMasYeri.Text = siparis.Masrafyeri;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstediğinize Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                DateTime geldigiTarih = new DateTime(DtgGeldigiTarih.Value.Year, DtgGeldigiTarih.Value.Month, DtgGeldigiTarih.Value.Day, DtgGeldigiSaat.Value.Hour, DtgGeldigiSaat.Value.Minute, DtgGeldigiSaat.Value.Second);

                ZiyaretciKayit ziyaretciKayit = new ZiyaretciKayit(LblIsAkisNo.Text.ConInt(), TxtZiyaretciAd.Text, TxtZiyaretciTc.Text, TxtZiyaretciFirmaAdi.Text, geldigiTarih, TxtZiyaretNedeni.Text, CmbZiyaretEdilenAd.Text, TxtZiyaretEdilenUnvani.Text, TxtZiyaretEdilenMasYeriNo.Text, TxtZiyaretEdilenMasYeri.Text, CmbRefakatciAd.Text, TxtRefakatciUnvani.Text, TxtRefakatciMasYeriNo.Text, TxtRefakatciMasYeri.Text);

                string mesaj = ziyaretciKayitManager.Add(ziyaretciKayit);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                CreateLog();
                MessageBox.Show("Bilgiler Başarıya Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                IsAkisNo();
                Temizle();
            }
        }
        void Temizle()
        {
            TxtZiyaretciAd.Clear(); TxtZiyaretciTc.Clear(); TxtZiyaretciFirmaAdi.Clear(); TxtZiyaretNedeni.Clear(); CmbZiyaretEdilenAd.SelectedValue = ""; CmbRefakatciAd.SelectedValue = ""; TxtZiyaretEdilenUnvani.Clear();
            TxtZiyaretEdilenMasYeriNo.Clear(); TxtZiyaretEdilenMasYeri.Clear(); TxtRefakatciUnvani.Clear(); TxtRefakatciMasYeriNo.Clear(); TxtRefakatciMasYeri.Clear(); TxtIsAkisNo.Clear();
        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        void CreateLog()
        {
            string sayfa = "ZİYARETÇİ KAYIT";
            ZiyaretciKayit gorev = ziyaretciKayitManager.Get(LblIsAkisNo.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "ZİYARETÇİ KAYDI OLUŞTURULDU.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            idariIslerLogManager.Add(log);
        }
        void CreateLogGuncelle()
        {
            string sayfa = "ZİYARETÇİ KAYIT";
            ZiyaretciKayit gorev = ziyaretciKayitManager.Get(TxtIsAkisNo.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "ZİYARETÇİ KAYDI GÜNCELLENDİ.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            idariIslerLogManager.Add(log);
        }

        private void CmbIslemTuruUcak_SelectedIndexChanged(object sender, EventArgs e)
        {
            Temizle();
            int index = CmbIslemTuruUcak.SelectedIndex;
            if (index==0)
            {
                TxtIsAkisNo.Visible = false;
                BtnBul.Visible = false;
                BtnGuncelle.Visible = false;
            }
            if (index==1)
            {
                TxtIsAkisNo.Visible = true;
                BtnBul.Visible = true;
                BtnGuncelle.Visible = true;
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNo.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Geçerli Bir İş Akış Numarası Giriniz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DateTime geldigiTarih = new DateTime(DtgGeldigiTarih.Value.Year, DtgGeldigiTarih.Value.Month, DtgGeldigiTarih.Value.Day, DtgGeldigiSaat.Value.Hour, DtgGeldigiSaat.Value.Minute, DtgGeldigiSaat.Value.Second);

            ZiyaretciKayit ziyaretciKayit = new ZiyaretciKayit(TxtIsAkisNo.Text.ConInt(), TxtZiyaretciAd.Text, TxtZiyaretciTc.Text, TxtZiyaretciFirmaAdi.Text, geldigiTarih, TxtZiyaretNedeni.Text, CmbZiyaretEdilenAd.Text, TxtZiyaretEdilenUnvani.Text, TxtZiyaretEdilenMasYeriNo.Text, TxtZiyaretEdilenMasYeri.Text, CmbRefakatciAd.Text, TxtRefakatciUnvani.Text, TxtRefakatciMasYeriNo.Text, TxtRefakatciMasYeri.Text);

            string mesaj = ziyaretciKayitManager.Update(ziyaretciKayit);
            if (mesaj!="OK")
            {
                MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            CreateLogGuncelle();
            IsAkisNo();
            Temizle();
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNo.Text=="")
            {
                MessageBox.Show("Lütfen Geçerli Bir İş Akış Numarası Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ZiyaretciKayit ziyaretciKayit = ziyaretciKayitManager.Get(TxtIsAkisNo.Text.ConInt());
            if (ziyaretciKayit == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                return;
            }

            TxtZiyaretciAd.Text = ziyaretciKayit.ZiyaretciAd;
            TxtZiyaretciTc.Text = ziyaretciKayit.Tc;
            TxtZiyaretciFirmaAdi.Text = ziyaretciKayit.FirmaAdi;
            DtgGeldigiTarih.Value = ziyaretciKayit.GeldigiTarihSaat;
            DtgGeldigiSaat.Value = ziyaretciKayit.GeldigiTarihSaat;
            TxtZiyaretNedeni.Text = ziyaretciKayit.ZiyaretNedeni;
            CmbZiyaretEdilenAd.Text = ziyaretciKayit.ZiyaretEdilenAd;
            CmbRefakatciAd.Text = ziyaretciKayit.RefakatciAd;
        }
    }
}
