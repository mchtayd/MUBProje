using Business.Concreate;
using Business.Concreate.IdarıIsler;
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
    public partial class FrmYurtIciOnay : Form
    {
        YurtIciGorevManager yurtIciGorevManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        List<YurtIciGorev> yurtIciGorevs = new List<YurtIciGorev>();
        public object[] infos;
        int id;
        public FrmYurtIciOnay()
        {
            InitializeComponent();
            yurtIciGorevManager = YurtIciGorevManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
        }

        private void FrmYurtIciOnay_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageYurtIciOnay"]);

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
            yurtIciGorevs = yurtIciGorevManager.YurtIcıGorevPersonelOnay(infos[1].ToString());
            dataBinder.DataSource = yurtIciGorevs.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Gorevemrino"].HeaderText = "GÖREV EMRİ NO";
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
            DtgList.Columns["Donuskm"].HeaderText = "DÖNÜŞ KİLOMETRESİ";
            DtgList.Columns["Toplamkm"].HeaderText = "TOPLAM KM";
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
            DtgList.Columns["OnayDurum"].HeaderText = "ONAY DURUM";
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            yurtIciGorevManager.IslemAdimiUpdate(id, "2.ADIM:GÖREV PERSONEL TARAFINDAN ONAYLANDI");
            GorevAtamaKapat();
            GorevAtama();
            id = 0;
            DataDisplay();
            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void GorevAtamaKapat()
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
            gorevAtamaPersonelManager.Update(gorevAtama, "GÖREV ONAYLANDI");
        }

        string GorevAtama()
        {
            if (infos[1].ToString() == "ERHAN KARAKAYA" || infos[1].ToString() == "ŞENOL ELTER" || infos[1].ToString() == "EBUBEKİR KELEŞ")
            {
                GorevAtamaPersonel gorevAtamaPersonel1 = new GorevAtamaPersonel(id, "YURT İÇİ GÖREV", "ŞERİFE NUR GÜNEŞ", "YURT İÇİ GÖREV ONAYI", DateTime.Now, "", DateTime.Now.Date);
                string kontrol1 = gorevAtamaPersonelManager.Add(gorevAtamaPersonel1);

                if (kontrol1 != "OK")
                {
                    return kontrol1;
                }
                return "OK";
            }

            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "YURT İÇİ GÖREV", "RESUL GÜNEŞ", "YURT İÇİ GÖREV ONAYI", DateTime.Now, "", DateTime.Now.Date);
            string kontrol = gorevAtamaPersonelManager.Add(gorevAtamaPersonel);

            if (kontrol != "OK")
            {
                return kontrol;
            }
            return "OK";
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Kaydı silmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                yurtIciGorevManager.Delete(id);
            }
            GorevAtamaKapat();
            id = 0;
            DataDisplay();
            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
