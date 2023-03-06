using Business;
using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarim;
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
using UserInterface.Ana_Sayfa;
using UserInterface.STS;

namespace UserInterface.BakımOnarım
{
    public partial class FrmDestekIscilikVeriGiris : Form
    {
        int index, index2, id;
        string comboAd = "", siparisNo = "";
        public object[] infos;
        bool start = false;
        PersonelKayitManager kayitManager;
        AracManager aracManager;
        AracZimmetiManager aracZimmetiManager;
        SiparisPersonelManager siparisPersonelManager;
        ComboManager comboManager;
        IscilikDesteIscilikManager iscilikDestekIscilikManager;
        IscilikDestekTabloManager ıscilikDestekTabloManager;
        IscilikDestekTabloAracManager desekTabloAracManager;
        IscilikIscilikManager iscilikManager;
        BakimOnarimLogManager bakimOnarimLogManager;
        IscilikPerformansManager performansManager;
        SatTalebiDoldurManager satTalebiDoldurManager;
        IsAkisNoManager isAkisNoManager;

        public FrmDestekIscilikVeriGiris()
        {
            InitializeComponent();
            kayitManager = PersonelKayitManager.GetInstance();
            aracManager = AracManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            aracZimmetiManager = AracZimmetiManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            iscilikDestekIscilikManager = IscilikDesteIscilikManager.GetInstance();
            ıscilikDestekTabloManager = IscilikDestekTabloManager.GetInstance();
            desekTabloAracManager = IscilikDestekTabloAracManager.GetInstance();
            bakimOnarimLogManager = BakimOnarimLogManager.GetInstance();
            iscilikManager = IscilikIscilikManager.GetInstance();
            performansManager = IscilikPerformansManager.GetInstance();
            satTalebiDoldurManager = SatTalebiDoldurManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageIscilikGiris"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void FrmDestekIscilikVeriGiris_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            Personeller();
            PersonellerPerformans();
            Araclar();
            DestekIscilik1();
            DestekIscilik2();
            UsBolgeleri();
            UsBolgeleri2();
            UsBolgeleri3();
            UsBolgeleri4();
            start = true;
        }
        void Personeller()
        {
            CmbPersoneller.DataSource = kayitManager.PersonelAdSoyad();
            CmbPersoneller.ValueMember = "Id";
            CmbPersoneller.DisplayMember = "Adsoyad";
            CmbPersoneller.SelectedValue = -1;
        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        void UsBolgeleri()
        {
            CmbMevcutDuragi.DataSource = satTalebiDoldurManager.GetList();
            CmbMevcutDuragi.ValueMember = "Id";
            CmbMevcutDuragi.DisplayMember = "Usbolgesi";
            CmbMevcutDuragi.SelectedValue = "";
        }
        void UsBolgeleri2()
        {
            CmbCikisDuragi.DataSource = satTalebiDoldurManager.GetList();
            CmbCikisDuragi.ValueMember = "Id";
            CmbCikisDuragi.DisplayMember = "Usbolgesi";
            CmbCikisDuragi.SelectedValue = "";
        }
        void UsBolgeleri3()
        {
            CmbIstikametDuragi.DataSource = satTalebiDoldurManager.GetList();
            CmbIstikametDuragi.ValueMember = "Id";
            CmbIstikametDuragi.DisplayMember = "Usbolgesi";
            CmbIstikametDuragi.SelectedValue = "";
        }
        void UsBolgeleri4()
        {
            CmbVarisDuragi.DataSource = satTalebiDoldurManager.GetList();
            CmbVarisDuragi.ValueMember = "Id";
            CmbVarisDuragi.DisplayMember = "Usbolgesi";
            CmbVarisDuragi.SelectedValue = "";
        }
        void PersonellerPerformans()
        {
            CmbPersonelPerformans.DataSource = kayitManager.PersonelAdSoyad();
            CmbPersonelPerformans.ValueMember = "Id";
            CmbPersonelPerformans.DisplayMember = "Adsoyad";
            CmbPersonelPerformans.SelectedValue = -1;
        }
        void Araclar()
        {
            CmbAraclar.DataSource = aracManager.GetList();
            CmbAraclar.ValueMember = "Id";
            CmbAraclar.DisplayMember = "Plaka";
            CmbAraclar.SelectedValue = -1;
        }
        void DestekIscilik1()
        {
            CmbDestekIscilik1.DataSource = comboManager.GetList("DESTEK NEDENİ");
            CmbDestekIscilik1.ValueMember = "Id";
            CmbDestekIscilik1.DisplayMember = "Baslik";
            CmbDestekIscilik1.SelectedValue = -1;
        }
        void DestekIscilik2()
        {
            CmbDestekIscilik2.DataSource = comboManager.GetList("DESTEK NEDENİ");
            CmbDestekIscilik2.ValueMember = "Id";
            CmbDestekIscilik2.DisplayMember = "Baslik";
            CmbDestekIscilik2.SelectedValue = -1;
        }

        private void CmbIscilikTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CmbIscilikTuru.SelectedIndex;
            if (index == 0) // DESTEK İŞÇİLİK
            {
                GrbDestekIscilik.Visible = true;
                GrbPerformans.Visible = false;
                GrbIscilik.Visible = false;
            }
            if (index == 1) // İŞÇİLİK
            {
                GrbDestekIscilik.Visible = false;
                GrbPerformans.Visible = false;
                GrbIscilik.Visible = true;
            }
            if (index == 2) // PERFORMANS
            {
                GrbDestekIscilik.Visible = false;
                GrbPerformans.Visible = true;
                GrbIscilik.Visible = false;
            }
        }

        private void BtnPersonelEkle_Click(object sender, EventArgs e)
        {
            if (CmbPersoneller.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Bir Personel Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbPersoneller.Text);

            AdvPersonel.Rows.Add();
            int sonSatir = AdvPersonel.RowCount - 1;
            AdvPersonel.Rows[sonSatir].Cells["AdiSoyadi"].Value = CmbPersoneller.Text;
            AdvPersonel.Rows[sonSatir].Cells["Gorevi"].Value = siparis.Gorevi;
            AdvPersonel.Rows[sonSatir].Cells["Bolumu"].Value = siparis.Bolum;

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)AdvPersonel.Columns["Remove"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;
        }

        private void AdvMalzemeOnizleme_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                AdvPersonel.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void BtnAracEkle_Click(object sender, EventArgs e)
        {
            if (BtnAracEkle.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Bir Personel Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string plaka = CmbAraclar.Text;
            AracZimmeti aracZimmeti = aracZimmetiManager.Get(plaka);
            AdvArac.Rows.Add();
            int sonSatir = AdvArac.RowCount - 1;
            AdvArac.Rows[sonSatir].Cells["Plaka"].Value = plaka;

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)AdvArac.Columns["Kaldir"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;

            if (aracZimmeti == null)
            {
                AdvArac.Rows[sonSatir].Cells["Bolum"].Value = "";
                return;
            }
            AdvArac.Rows[sonSatir].Cells["Bolum"].Value = aracZimmeti.Bolum;


        }

        private void AdvArac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                AdvArac.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void BtnComboEkle1_Click(object sender, EventArgs e)
        {
            comboAd = "DESTEK NEDENİ";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnComboEkle2_Click(object sender, EventArgs e)
        {
            comboAd = "DESTEK NEDENİ";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            DateTime bTarih = DtDestekIscilikBasPersonel.Value;
            DateTime kTarih = DtDestekIscilikBitPersonel.Value;
            TimeSpan Sonuc = kTarih - bTarih;
            int gun = Sonuc.TotalDays.ConInt();
            TxtToplamSurePersonel.Text = gun.ToString() + " Gün";
        }

        private void BtnHesaplaArac_Click(object sender, EventArgs e)
        {
            DateTime bTarih = DtDestekIscilikBasArac.Value;
            DateTime kTarih = DtDestekIscilikBitArac.Value;
            TimeSpan Sonuc = kTarih - bTarih;
            int gun = Sonuc.TotalDays.ConInt();
            TxtToplamSureArac.Text = gun.ToString() + " Gün";
        }

        private void BtnKaydetDestekIscilik_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                siparisNo = Guid.NewGuid().ToString();

                if (AdvPersonel.RowCount != 0)
                {
                    if (CmbDestekIscilik1.Text == "")
                    {
                        MessageBox.Show("Lütfen Öncelikle PERSONEL DESTEK NEDENİ Bilgisini Giriniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    PersonelKaydet();
                }
                if (AdvArac.RowCount != 0)
                {
                    if (CmbDestekIscilik2.Text == "")
                    {
                        MessageBox.Show("Lütfen Öncelikle ARAÇ DESTEK NEDENİ Bilgisini Giriniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    AracKaydet();
                }

                IscilikDestekIscilik destekIscilik = new IscilikDestekIscilik(CmbIscilikTuru.Text, CmbDestekTuru.Text, CmbDestekIscilik1.Text, DtDestekIscilikBasPersonel.Value, DtDestekIscilikBitPersonel.Value, TxtToplamSurePersonel.Text, CmbDestekIscilik2.Text, DtDestekIscilikBasArac.Value, DtDestekIscilikBitArac.Value, TxtToplamSureArac.Text, siparisNo);

                string mesaj = iscilikDestekIscilikManager.Add(destekIscilik);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLogDestekIscilik();
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Temizle();
                
            }
        }
        void Temizle()
        {
            AdvPersonel.Rows.Clear();
            AdvArac.Rows.Clear();
            //AdvPersonel.DataSource = ""; AdvArac.DataSource = "";
            CmbDestekIscilik1.SelectedValue = ""; CmbDestekIscilik2.SelectedValue = ""; TxtToplamSurePersonel.Clear(); TxtToplamSureArac.Clear();
            TxtAbfNo.Clear(); TxtAbfNo.Clear(); DtIscilikSaati.Text = "00:00"; CmbPersonelPerformans.SelectedValue = ""; CmbMevcutDuragi.Text = ""; CmbCikisDuragi.Text = ""; CmbIstikametDuragi.Text = ""; DtgCikisSaati.Text = "00:00"; TxtCikisSebebi.Clear(); CmbVarisDuragi.Text = ""; TxtSonuc.Clear();TxtIsAkisNo.Clear();
            
        }
        void CreateLogDestekIscilik()
        {
            string sayfa = "DESTEK VE İŞÇİLİK";
            IscilikDestekIscilik destekIscilik = iscilikDestekIscilikManager.Get(siparisNo);
            int benzersizid = destekIscilik.Id;
            string islem = "DESTEK İŞÇİLİK KAYDI YAPILMIŞTIR.";
            string islemyapan = infos[1].ToString();
            BakimOnarimLog log = new BakimOnarimLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            bakimOnarimLogManager.Add(log);
        }
        void PersonelKaydet()
        {
            if (AdvPersonel.RowCount != 0)
            {
                foreach (DataGridViewRow item in AdvPersonel.Rows)
                {
                    IscilikDestekTablo destekTablo = new IscilikDestekTablo(
                        item.Cells["AdiSoyadi"].Value.ToString(),
                        item.Cells["Gorevi"].Value.ToString(),
                        item.Cells["Bolumu"].Value.ToString(),
                        siparisNo);
                    ıscilikDestekTabloManager.Add(destekTablo, siparisNo);

                }
            }
        }

        private void BtnKaydetIscilik_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                SiparisPersonel siparis = siparisPersonelManager.Get("", infos[1].ToString());

                IscilikIscilik ıscilikIscilik = new IscilikIscilik(0,infos[1].ToString(), siparis.Gorevi, siparis.Bolum, CmbIscilikTuru.Text, TxtAbfNo.Text, DtgTarih.Value, DtIscilikSaati.Text.ConOnlyTime());

                string mesaj = iscilikManager.Add(ıscilikIscilik);

                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Temizle();
            }
        }

        string PerformansKontrol()
        {
            string sonVarisDuragi;

            if (CmbMevcutDuragi.Text != CmbCikisDuragi.Text)
            {
                return "Hata2";
            }
            IscilikPerformans performans = performansManager.Get(CmbPersonelPerformans.Text);
            if (performans == null)
            {
                return "OK";
            }
            sonVarisDuragi = performans.VarisDurag;

            if (CmbMevcutDuragi.Text != sonVarisDuragi)
            {
                return "Hata1";
            }
            if (CmbIstikametDuragi.Text != CmbVarisDuragi.Text)
            {
                return "Hata3";
            }
            return "OK";
        }

        private void BtnKaydetPerformans_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string control = PerformansKontrol();

                DateTime cikisTarihiSaati = new DateTime(DtgCikisTarihi.Value.Year, DtgCikisTarihi.Value.Month, DtgCikisTarihi.Value.Day, DtgCikisSaati.Value.Hour, DtgCikisSaati.Value.Minute, DtgCikisSaati.Value.Second);

                DateTime varisTarihiSaati = new DateTime(DtgVarisTarihi.Value.Year, DtgVarisTarihi.Value.Month, DtgVarisTarihi.Value.Day, DtgVarisSaati.Value.Hour, DtgVarisSaati.Value.Minute, DtgVarisSaati.Value.Second);

                IscilikPerformans ıscilikPerformans = new IscilikPerformans(LblIsAkisNo.Text.ConInt(), CmbIscilikTuru.Text, CmbPersonelPerformans.Text, CmbMevcutDuragi.Text, CmbCikisDuragi.Text, CmbIstikametDuragi.Text, cikisTarihiSaati, TxtCikisSebebi.Text, CmbVarisDuragi.Text, varisTarihiSaati, TxtSonuc.Text);

                string mesaj = performansManager.Add(ıscilikPerformans);

                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                IscilikPerformans performans = performansManager.Get(CmbPersonelPerformans.Text);
                id = performans.Id;

                if (control!="OK")
                {
                    if (control== "Hata1")
                    {
                        performansManager.HataBildir(id, "SON VARIŞ DURAĞI İLE ÇIKIŞ DURAĞI UYUŞMAMAKTADIR!");
                        MessageBox.Show("Personelin Girmek İstediğiniz Mevcut Durağı İle Son Varış Durağı Uyuşmamaktadır!\nBu Durum Bildirilmiştir.", "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    }

                    if (control == "Hata2")
                    {
                        performansManager.HataBildir(id, "SON MEVCUT DURAĞI İLE ÇIKIŞ DURAĞI UYUŞMAMAKTADIR!");
                        MessageBox.Show("Personelin Mevcut Durağı İle Çıkış Durağı Uyuşmamaktadır!\nBu Durum Bildirilmiştir.", "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    }
                    if (control == "Hata3")
                    {
                        performansManager.HataBildir(id, "İSTİKAMET DURAĞI İLE VARIŞ DURAĞI UYUŞMAMAKTADIR!");
                        MessageBox.Show("Personelin İstikamet Durağı İle Varış Durağı Uyuşmamaktadır!\nBu Durum Bildirilmiştir.", "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    }
                }
                
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsAkisNo();
                Temizle();


            }
        }
        //int destekNedeniIndex;

        private void CmbDestekIscilik1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (start == false)
            {
                return;
            }*/
            
        }

        private void CmbDestekIscilik2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (start == false)
            {
                return;
            }
            destekNedeniIndex = CmbDestekIscilik2.SelectedIndex;
            CmbDestekIscilik1.SelectedIndex = destekNedeniIndex;*/
        }

        private void TxtToplamSurePersonel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CmbIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbIslemTuru.SelectedIndex==0)
            {
                TxtIsAkisNo.Visible = false;
                BtnBul.Visible = false;
                BtnGuncelle.Visible = false;
            }
            if (CmbIslemTuru.SelectedIndex == 1)
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
                MessageBox.Show("Lütfen Öncelikle İş Akış No Bilgisini Giriniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Güncellemek İstiyor Musunuz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                DateTime cikisTarihiSaati = new DateTime(DtgCikisTarihi.Value.Year, DtgCikisTarihi.Value.Month, DtgCikisTarihi.Value.Day, DtgCikisSaati.Value.Hour, DtgCikisSaati.Value.Minute, DtgCikisSaati.Value.Second);

                DateTime varisTarihiSaati = new DateTime(DtgVarisTarihi.Value.Year, DtgVarisTarihi.Value.Month, DtgVarisTarihi.Value.Day, DtgVarisSaati.Value.Hour, DtgVarisSaati.Value.Minute, DtgVarisSaati.Value.Second);


                IscilikPerformans performans = new IscilikPerformans(TxtIsAkisNo.Text.ConInt(), CmbIscilikTuru.Text, CmbPersonelPerformans.Text, CmbMevcutDuragi.Text, CmbCikisDuragi.Text, CmbIstikametDuragi.Text, cikisTarihiSaati, TxtCikisSebebi.Text, CmbVarisDuragi.Text, varisTarihiSaati, TxtSonuc.Text);

                string mesaj = performansManager.Update(performans, TxtIsAkisNo.Text.ConInt(), hata);

                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                Temizle();
                IsAkisNo();
            }
        }
        string hata = "";
        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İş Akış No Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IscilikPerformans performans = performansManager.PerformansBul(TxtIsAkisNo.Text.ConInt());
            if (performans == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                return;
            }
            CmbPersonelPerformans.Text = performans.Personel;
            CmbMevcutDuragi.Text = performans.MevcutDuragi;
            CmbCikisDuragi.Text = performans.CikisDuragi;
            CmbIstikametDuragi.Text = performans.IstikametDuragi;
            DtgCikisTarihi.Value = performans.CikisTarihiSaati;
            DtgCikisSaati.Value = performans.CikisTarihiSaati;
            TxtCikisSebebi.Text = performans.CikisSebebi;
            CmbVarisDuragi.Text = performans.VarisDurag;
            DtgVarisTarihi.Value = performans.VarisTarihiSaat;
            DtgVarisSaati.Value = performans.VarisTarihiSaat;
            TxtSonuc.Text = performans.Sonuc;
            hata = performans.Hata;
        }

        private void TxtToplamSureArac_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        void AracKaydet()
        {
            if (AdvArac.RowCount != 0)
            {
                foreach (DataGridViewRow item in AdvArac.Rows)
                {
                    IscilikDestekTabloArac destekTablo = new IscilikDestekTabloArac(
                        item.Cells["Plaka"].Value.ToString(),
                        item.Cells["Bolum"].Value.ToString(),
                        siparisNo);
                    desekTabloAracManager.Add(destekTablo);
                }
            }
        }

        private void CmbDestekTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            index2 = CmbDestekTuru.SelectedIndex;
            BtnKaydetDestekIscilik.Visible = true;

            if (index2 == 0) // PERSONEL
            {
                GrbPersonel.Visible = true;
                GrbArac.Visible = false;
                GrbArac.Location = new Point(710, 62);
            }
            if (index2 == 1) // ARAÇ
            {
                GrbArac.Visible = true;
                GrbPersonel.Visible = false;
                GrbArac.Location = new Point(19, 62);
            }
            if (index2 == 2) // PERSONEL VE ARAÇ
            {
                GrbArac.Visible = true;
                GrbPersonel.Visible = true;
                GrbArac.Location = new Point(710, 62);
            }
        }
    }
}
