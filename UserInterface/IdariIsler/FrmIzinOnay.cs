using Business.Concreate;
using Business.Concreate.AnaSayfa;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Presentation;
using Entity;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.IdariIsler
{
    public partial class FrmIzinOnay : Form
    {
        IzinManager izinManager;
        IdariIslerLogManager logManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        List<Izin> ızins;
        int id = 0, isAkisNo, gun, saat, dakika;
        public object[] infos;
        string sure = "";
        DateTime birOncekiTarih;
        public FrmIzinOnay()
        {
            InitializeComponent();
            izinManager = IzinManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
        }

        private void FrmIzinOnay_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageIzinOnay"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void DataDisplay()
        {
            ızins = izinManager.GetListOnay();
            dataBinder.DataSource = ızins.ToDataTable();
            DtgList.DataSource = dataBinder;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Izinkategori"].HeaderText = "İZİN KATEGORİ";
            DtgList.Columns["Izinturu"].HeaderText = "İZİN TÜRÜ";
            DtgList.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgList.Columns["Masrafyerino"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["Bolum"].HeaderText = "BÖLÜMÜ";
            DtgList.Columns["Izınnedeni"].HeaderText = "İZİN NEDENİ";
            DtgList.Columns["Bastarihi"].HeaderText = "İZİN BAŞLAMA TARİHİ";
            DtgList.Columns["Bittarihi"].HeaderText = "İZİN BİTİŞ TARİHİ";
            DtgList.Columns["Izindurumu"].HeaderText = "İZİN DURUMU";
            DtgList.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgList.Columns["Toplamsure"].HeaderText = "TOPLAM SÜRE";
            DtgList.Columns["KalanSure"].Visible = false;
            DtgList.Columns["Dosyayolu"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;
            DtgList.Columns["Siparis"].Visible = false;
            DtgList.Columns["OnayDurum"].HeaderText = "ONAY DURUMU";

            TxtTop.Text = DtgList.RowCount.ToString();

        }
        void CreateLog()
        {
            string sayfa = "İZİN";
            Izin gorev = izinManager.Get(isAkisNo);
            int benzersizid = gorev.Id;
            string islem = "İZİN KAYDI ONAYLANDI.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogReddet()
        {
            string sayfa = "İZİN";
            Izin gorev = izinManager.Get(isAkisNo);
            int benzersizid = gorev.Id;
            string islem = "İZİN KAYDI REDDEDİLDİ.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogTumunuOnayla()
        {
            string sayfa = "İZİN";
            Izin gorev = izinManager.Get(isAkisNo);
            int benzersizid = gorev.Id;
            string islem = "İZİN KAYDI ONAYLANDI.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }


        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }
            string mesaj = izinManager.IzinOnay(id, "ONAYLANDI");
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CreateLog();
            GorevAtama();
            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            id = 0;
            DataDisplay();
        }

        private void BtnGorevAta_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in DtgList.Rows)
            {
                if (item.Cells["OnayDurum"].Value.ToString()=="ONAYLANMADI")
                {
                    GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(item.Cells["Id"].Value.ConInt(), "İZİN", "RESUL GÜNEŞ", "İZİN ONAYI", DateTime.Now, "", DateTime.Now.Date);
                    gorevAtamaPersonelManager.Add(gorevAtamaPersonel);
                }
            }
            MessageBox.Show("Tamamlandı");

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

        void GorevAtama()
        {
            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "İZİN");

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


            int guncellenecekId = 0;
            List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetDevamEdenler(id, "İZİN");

            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                if (item.IslemAdimi == "İZİN ONAYI")
                {
                    guncellenecekId = item.Id;
                }
            }

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(guncellenecekId, id, "İZİN", "İZİN ONAYI", sure, "00:02:00".ConOnlyTime(), infos[1].ToString());
            gorevAtamaPersonelManager.Update(gorevAtama, "İZİN TALEBİ ONAYLANDI");
        }
        void GorevAtamaRed()
        {
            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "İZİN");

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

            int guncellenecekId = 0;
            List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetDevamEdenler(id, "İZİN");

            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                if (item.IslemAdimi == "İZİN ONAYI")
                {
                    guncellenecekId = item.Id;
                }
            }

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(guncellenecekId, id, "İZİN", "İZİN ONAYI", sure, "00:02:00".ConOnlyTime(), infos[1].ToString());
            gorevAtamaPersonelManager.Update(gorevAtama, "İZİN TALEBİ REDDEDİLDİ");
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            isAkisNo = DtgList.CurrentRow.Cells["Isakisno"].Value.ConInt();
        }

        private void BtnReddet_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }
            string mesaj = izinManager.IzinOnay(id, "REDDEDİLDİ");
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CreateLogReddet();
            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            id = 0;
            DataDisplay();
        }

        private void BtnTumunuOnayla_Click(object sender, EventArgs e)
        {
            if (DtgList.RowCount == 0)
            {
                MessageBox.Show("Tabloda veri bulunamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }

            foreach (DataGridViewRow item in DtgList.Rows)
            {
                id = item.Cells["Id"].Value.ConInt();
                izinManager.IzinOnay(id, "ONAYLANDI");
                isAkisNo = item.Cells["Isakisno"].Value.ConInt();
                CreateLogTumunuOnayla();
                GorevAtama();
            }

            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            id = 0;
            DataDisplay();
        }
    }
}
