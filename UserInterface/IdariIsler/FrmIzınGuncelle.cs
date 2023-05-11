using Business.Concreate.AnaSayfa;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
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
using UserInterface.BakımOnarım;
using UserInterface.STS;

namespace UserInterface.IdariIsler
{
    public partial class FrmIzınGuncelle : Form
    {
        IzinManager izinManager;
        IdariIslerLogManager logManager;
        public int id;
        public object[] infos;
        string toplamSure;

        DateTime haftasonuControl;
        int haftasonu = 0;
        public FrmIzınGuncelle()
        {
            InitializeComponent();
            izinManager = IzinManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
        }

        private void FrmIzınGuncelle_Load(object sender, EventArgs e)
        {
            if (infos[11].ToString() == "ADMİN" || infos[11].ToString() == "YÖNETİCİ" || infos[0].ConInt() == 1139)
            {
                BtnSil.Visible = true;
            }
            else
            {
                BtnSil.Visible = false;
            }
            DataDisplay();
        }

        void DataDisplay()
        {
            Izin izin = izinManager.GetId(id);

            if (izin!=null)
            {
                LblIsAkisNo.Text = izin.Isakisno.ToString();
                LblKategori.Text = izin.Izinkategori;
                LblIzinTuru.Text = izin.Izinturu;
                LblAdSoyad.Text = izin.Adsoyad;
                LblSiparisNo.Text = izin.Siparisno;
                LblUnvani.Text = izin.Unvani;
                LblMasrafYeriNo.Text = izin.Masrafyerino;
                LblBolum.Text = izin.Bolum;
                TxtIzinNedeni.Text = izin.Izınnedeni;
                DtBasTarihi.Value = izin.Bastarihi;
                DtBasSaati.Value = izin.Bastarihi;
                DtBitTarihi.Value = izin.Bittarihi;
                DtBitSaati.Value=izin.Bittarihi;

                SureHesapla();

                try
                {
                    webBrowser1.Navigate(izin.Dosyayolu);
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
        void SureHesapla()
        {
            if (LblIzinTuru.Text != "HAFTALIK İZİN")
            {
                TimeSpan toplamSureGun = DtBitTarihi.Value - DtBasTarihi.Value;
                TimeSpan toplamSureSaat = DtBitSaati.Value - DtBasSaati.Value;

                int saat = toplamSureSaat.Hours;
                int gunSaat = toplamSureGun.Hours;
                int gun = toplamSureGun.Days;
                int dakika = toplamSureSaat.Minutes;

                if (gun == 0)
                {
                    toplamSure = saat + " Saat";
                }
                if (saat == 0)
                {
                    toplamSure = gun + " Gün";
                }
                if (saat != 0 && gun != 0)
                {
                    toplamSure = gun + " Gün " + saat + " Saat";
                }

                if (saat == 0 && gun == 0)
                {
                    if (gunSaat == 23)
                    {
                        toplamSure = "1 Gün";
                    }
                    if (dakika == 59)
                    {
                        toplamSure = "1 Saat";
                    }
                    if (gunSaat == 23 && dakika == 59)
                    {
                        toplamSure = "1 Gün 1 Saat";
                    }
                    if (toplamSure == "")
                    {
                        MessageBox.Show("Girilen tarih aralığı hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }


                if (DtBitTarihi.Value.Day < DtBasTarihi.Value.Day)
                {
                    haftasonuControl = DtBasTarihi.Value;

                    while (DtBitTarihi.Value.Month > haftasonuControl.Month)
                    {
                        string haftaninGunu = haftasonuControl.ToString("dddd");
                        if (haftaninGunu == "Cumartesi" || haftaninGunu == "Pazar")
                        {
                            haftasonu++;
                        }
                        haftasonuControl = haftasonuControl.AddDays(1);
                    }
                }
                else
                {
                    haftasonuControl = DtBasTarihi.Value;

                    while (DtBitTarihi.Value.Day > haftasonuControl.Day)
                    {
                        string haftaninGunu = haftasonuControl.ToString("dddd");
                        if (haftaninGunu == "Cumartesi" || haftaninGunu == "Pazar")
                        {
                            haftasonu++;
                        }
                        haftasonuControl = haftasonuControl.AddDays(1);
                    }
                }


                string[] sure = toplamSure.Split(' ');
                if (haftasonu != 0)
                {
                    int sureGun = sure[0].ConInt() - haftasonu;
                    toplamSure = sureGun + " Gün";
                }

                LblToplamSure.Text = toplamSure;
                haftasonu = 0;
            }
            else
            {
                TimeSpan toplamSureGun = DtBitTarihi.Value - DtBasTarihi.Value;
                TimeSpan toplamSureSaat = DtBitSaati.Value - DtBasSaati.Value;

                int saat = toplamSureSaat.Hours;
                int gunSaat = toplamSureGun.Hours;
                int gun = toplamSureGun.Days;
                int dakika = toplamSureSaat.Minutes;

                if (gun == 0)
                {
                    toplamSure = saat + " Saat";
                }
                if (saat == 0)
                {
                    toplamSure = gun + " Gün";
                }
                if (saat != 0 && gun != 0)
                {
                    toplamSure = gun + " Gün" + saat + " Saat";
                }

                if (saat == 0 && gun == 0)
                {
                    if (gunSaat == 23)
                    {
                        toplamSure = "1 Gün";
                    }
                    if (dakika == 59)
                    {
                        toplamSure = "1 Saat";
                    }
                    if (gunSaat == 23 && dakika == 59)
                    {
                        toplamSure = "1 Gün 1 Saat";
                    }
                    if (toplamSure == "")
                    {
                        MessageBox.Show("Girilen tarih aralığı hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (toplamSure == "0 Gün")
                {
                    toplamSure = "1 Gün";
                }

                LblToplamSure.Text = toplamSure;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Kaydı silmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = izinManager.Delete(id);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FrmIzinIzleme frmIzinIzleme = (FrmIzinIzleme)Application.OpenForms["FrmIzinIzleme"];
                frmIzinIzleme.DtgIzinList();
                MessageBox.Show("Bilgiler başarıyla silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri güncellemek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DateTime basTarihi = new DateTime(DtBasTarihi.Value.Year, DtBasTarihi.Value.Month, DtBasTarihi.Value.Day, DtBasSaati.Value.Hour, DtBasSaati.Value.Minute, DtBasSaati.Value.Second);
                DateTime bitTarihi = new DateTime(DtBitTarihi.Value.Year, DtBitTarihi.Value.Month, DtBitTarihi.Value.Day, DtBitSaati.Value.Hour, DtBitSaati.Value.Minute, DtBitSaati.Value.Second);
                

                Izin ızin = new Izin(id, LblAdSoyad.Text, TxtIzinNedeni.Text, basTarihi, bitTarihi, LblToplamSure.Text);

                string mesaj = izinManager.UpdateIzin(ızin);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLogGuncelle();
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmIzinIzleme frmIzinIzleme = (FrmIzinIzleme)Application.OpenForms["FrmIzinIzleme"];
                frmIzinIzleme.DtgIzinList();
                this.Close();
            }
        }
        void CreateLogGuncelle()
        {
            string sayfa = "İZİN";
            Izin gorev = izinManager.Get(LblIsAkisNo.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "İZİN BİLGİLERİ GÜNCELLENDİ.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }

        private void BtnSureHesapla_Click(object sender, EventArgs e)
        {
            SureHesapla();
        }
    }
}
