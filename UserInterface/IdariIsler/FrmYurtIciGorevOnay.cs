using Business.Concreate;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Office2010.Excel;
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
using System.Windows.Controls;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.IdariIsler
{
    public partial class FrmYurtIciGorevOnay : Form
    {
        public object[] infos;
        YurtIciGorevManager yurtIciGorevManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        List<YurtIciGorev> yurtIciGorevs = new List<YurtIciGorev>();
        int isAkisNo, id;
        public FrmYurtIciGorevOnay()
        {
            InitializeComponent();
            yurtIciGorevManager = YurtIciGorevManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
        }

        private void FrmYurtIciGorevOnay_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        void DataDisplay()
        {
            yurtIciGorevs = yurtIciGorevManager.YurtIcıGorevOnaylanacalar();
            dataBinder.DataSource = yurtIciGorevs.ToDataTable();
            DtgList.DataSource = dataBinder;


            LblTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Gorevemrino"].Visible = false;
            DtgList.Columns["Gorevinkonusu"].HeaderText = "GÖREVİN KONUSU";
            DtgList.Columns["Proje"].HeaderText = "PROJE";
            DtgList.Columns["Gidilecekyer"].HeaderText = "GİDİLECEK YER";
            DtgList.Columns["Baslamatarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgList.Columns["Bitistarihi"].HeaderText = "BİTİŞ TARİHİ";
            DtgList.Columns["Toplamsure"].HeaderText = "TOPLAM SÜRE";
            DtgList.Columns["Butcekodu"].HeaderText = "BÜTÇE KODU";
            DtgList.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgList.Columns["Masrafyerino"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ";
            DtgList.Columns["Ulasimgidis"].HeaderText = "ULAŞIM GİDİŞ";
            DtgList.Columns["Ulasimgorevyeri"].HeaderText = "GÖREV YERİ";
            DtgList.Columns["Ulasimdonus"].HeaderText = "ULAŞIM DÖNÜŞ";
            DtgList.Columns["Konaklamagun"].HeaderText = "KONAKLAMA GÜN";
            DtgList.Columns["Konaklamaguntl"].HeaderText = "KONAKLAMA GÜN/TL";
            DtgList.Columns["Konaklamatoplam"].HeaderText = "KONAKLAMA TOPLAM";
            DtgList.Columns["Kiralamagun"].HeaderText = "ARAÇ KİRALAMA GÜN";
            DtgList.Columns["Kiralamaguntl"].HeaderText = "ARAÇ KİRALAMA GÜN/TL";
            DtgList.Columns["Kiralamayakit"].HeaderText = "ARAÇ KİRALAMA YAKIT";
            DtgList.Columns["Kiralamatoplam"].HeaderText = "ARAÇ KİRALAMA TOPLAM";
            DtgList.Columns["Seyahatavansgun"].HeaderText = "SEYAHAT İŞ AVANSI GÜN";
            DtgList.Columns["Seyahatguntl"].HeaderText = "SEYAHAT İŞ AVANSI GÜN/TL";
            DtgList.Columns["Seyahattoplam"].HeaderText = "SEYAHAT İŞ AVANSI TOPLAM";
            DtgList.Columns["Ucakbileti"].HeaderText = "UÇAK BİLETİ";
            DtgList.Columns["Otobusbileti"].HeaderText = "OTOBÜS BİLETİ";
            DtgList.Columns["Geneltoplam"].HeaderText = "GENEL TOPLAM";
            DtgList.Columns["Plaka"].HeaderText = "PLAKA";
            DtgList.Columns["Cikiskm"].HeaderText = "ÇIKIŞ KİLOMETRESİ";
            DtgList.Columns["Donuskm"].Visible = false;
            DtgList.Columns["Toplamkm"].Visible = false;
            DtgList.Columns["Geneltoplam"].HeaderText = "GENEL TOPLAM";
            DtgList.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgList.Columns["Islemadimi"].Visible = false;
            DtgList.Columns["Dosyayolu"].Visible = false;
            DtgList.Columns["KalanSure"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;
            DtgList.Columns["KonaklamaTuru"].Visible = false;
            DtgList.Columns["HarcirahGun"].Visible = false;
            DtgList.Columns["HarcirahGunTl"].Visible = false;
            DtgList.Columns["HarcirahToplam"].Visible = false;
            DtgList.Columns["IaseGun"].Visible = false;
            DtgList.Columns["IaseGunTl"].Visible = false;
            DtgList.Columns["IaseToplam"].Visible = false;
            DtgList.Columns["OnayDurum"].Visible = false;

            DtgList.Columns["Adsoyad"].DisplayIndex = 2;
            DtgList.Columns["Masrafyerino"].DisplayIndex = 3;
            DtgList.Columns["Masrafyeri"].DisplayIndex = 4;
            DtgList.Columns["Unvani"].DisplayIndex = 5;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageYurtIciGorevOnay"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            isAkisNo = DtgList.CurrentRow.Cells["IsAkisNo"].Value.ConInt();
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            personelAd = DtgList.CurrentRow.Cells["Adsoyad"].Value.ToString();
        }
        string personelAd = "";
        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            if (isAkisNo <= 0)
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Görevi Onaylamak istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                GorevAtama();
                if (control==true)
                {
                    MessageBox.Show("Bu görev size tanımlı olmadığı için işlem gerçekleştirilemez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    GorevAtamaPersonel();
                    yurtIciGorevManager.IslemAdimiUpdate(id, "3.ADIM:GÖREV AMİR TARAFINDAN ONAYLANDI");
                    string mesaj = yurtIciGorevManager.GorevOnay(isAkisNo, "ONAYLANDI");
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                DataDisplay();
                control = false;
                isAkisNo = 0;
                MessageBox.Show("Görev başarıyla onaylanmıştır!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        string GorevAtamaPersonel()
        {
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "YURT İÇİ GÖREV", personelAd, "YURT İÇİ KAYIT KAPATMA", DateTime.Now, "", DateTime.Now.Date);
            string kontrol = gorevAtamaPersonelManager.Add(gorevAtamaPersonel);

            if (kontrol != "OK")
            {
                return kontrol;
            }
            return "OK";
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
                GorevAtama();
                if (control==true)
                {

                }
                else
                {
                    isAkisNo = item.Cells["IsAkisNo"].Value.ConInt();
                    id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
                    yurtIciGorevManager.GorevOnay(isAkisNo, "ONAYLANDI");

                    GorevAtamaPersonel();
                    yurtIciGorevManager.IslemAdimiUpdate(id, "3.ADIM:GÖREV AMİR TARAFINDAN ONAYLANDI");
                }
                control = false;
            }
            DataDisplay();
            MessageBox.Show("Görevler başarıyla onaylanmıştır!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isAkisNo = 0;
           
        }

        private void BtnReddet_Click(object sender, EventArgs e)
        {
            if (isAkisNo <= 0)
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Görevi Onaylamak istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = yurtIciGorevManager.GorevOnay(isAkisNo, "REDDEDİLDİ");
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataDisplay();
                GorevAtamaRed();
                isAkisNo = 0;
                MessageBox.Show("Görev reddedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            LblTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        void GorevAtama()
        {
            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "YURT İÇİ GÖREV", infos[1].ToString());

            if (gorevAtamaPersonel!=null)
            {
                DateTime birOncekiTarih = gorevAtamaPersonel.Tarih;

                TimeSpan sonuc = DateTime.Now - birOncekiTarih;

                int gun = sonuc.Days.ConInt();
                int saat = sonuc.Hours.ConInt();
                if (sonuc.Hours < 1)
                {
                    saat = 0;
                }

                int dakika = sonuc.Seconds.ConInt() % 60;

                string sure = gun.ToString() + " Gün " + saat.ToString() + " Saat " + dakika.ToString() + " Dakika";

                int guncellenecekId = 0;
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                gorevAtamaPersonels = gorevAtamaPersonelManager.GetDevamEdenler(id, "YURT İÇİ GÖREV");

                foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
                {
                    if (item.IslemAdimi == "YURT İÇİ GÖREV ONAYI")
                    {
                        guncellenecekId = item.Id;
                    }
                }

                GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(guncellenecekId, id, "YURT İÇİ GÖREV", "YURT İÇİ GÖREV ONAYI", sure, "00:02:00".ConOnlyTime(), infos[1].ToString());
                gorevAtamaPersonelManager.Update(gorevAtama, "GÖREV ONAYLANDI");
            }
            else
            {
                control = true;
            }
            
        }
        bool control = false;
        void GorevAtamaRed()
        {
            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "YURT İÇİ GÖREV");

            DateTime birOncekiTarih = gorevAtamaPersonel.Tarih;

            TimeSpan sonuc = DateTime.Now - birOncekiTarih;

            int gun = sonuc.Days.ConInt();
            int saat = sonuc.Hours.ConInt();
            if (sonuc.Hours < 1)
            {
                saat = 0;
            }

            int dakika = sonuc.Seconds.ConInt() % 60;

            string sure = gun.ToString() + " Gün " + saat.ToString() + " Saat " + dakika.ToString() + " Dakika";

            int guncellenecekId = 0;
            List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetDevamEdenler(id, "YURT İÇİ GÖREV");

            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                if (item.IslemAdimi == "YURT İÇİ GÖREV ONAYI")
                {
                    guncellenecekId = item.Id;
                }
            }

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(guncellenecekId, id, "YURT İÇİ GÖREV", "YURT İÇİ GÖREV ONAYI", sure, "00:02:00".ConOnlyTime(), infos[1].ToString());
            gorevAtamaPersonelManager.Update(gorevAtama, "GÖREV REDDEDİLDİ");
        }

    }
}
