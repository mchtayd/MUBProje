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
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.IdariIsler
{
    public partial class FrmFazlaCalismaOnay : Form
    {
        FazlaCalismaManager fazlaCalismaManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;

        List<FazlaCalisma> fazlaCalismas = new List<FazlaCalisma>();

        int id, gun, saat, dakika;
        DateTime birOncekiTarih;
        string sure;
        public object[] infos;
        public FrmFazlaCalismaOnay()
        {
            InitializeComponent();
            fazlaCalismaManager = FazlaCalismaManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageFazlaCalismaOnay"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void FrmFazlaCalismaOnay_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }
        void DataDisplay()
        {
            fazlaCalismas = fazlaCalismaManager.GetListOnaylanacaklar();
            dataBinder.DataSource = fazlaCalismas.ToDataTable();
            DtgList.DataSource = dataBinder;
            LblTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["PersonelAd"].HeaderText = "PERSONEL ADI";
            DtgList.Columns["PersonelBolum"].HeaderText = "BÖLÜM";
            DtgList.Columns["FazlaCalismaNedeni"].HeaderText = "FAZLA ÇALIŞMA NEDENİ";
            DtgList.Columns["MesaiBasTarihi"].HeaderText = "MESAİ BAŞLANGIÇ TAİHİ";
            DtgList.Columns["MesaiBitTarihi"].HeaderText = "MESAİ BİTİŞ TARİHİ";
            DtgList.Columns["ToplamMesaiSaati"].HeaderText = "TOPLAM MESAİ SAATİ";
            DtgList.Columns["ToplamHakEdilenIzin"].HeaderText = "TOPLAM HAK EDİLEN İZİN";
            DtgList.Columns["OnayDurumu"].HeaderText = "ONAY DURUMU";
            DtgList.Columns["OnayVeren"].HeaderText = "ONAY VEREN";

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
                fazlaCalismaManager.UpdateOnay(id);
                GorevAtama();
            }

            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            id = 0;
            DataDisplay();
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
            string mesaj = fazlaCalismaManager.UpdateOnay(id);
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GorevAtamaRed();
            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            id = 0;
            DataDisplay();
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
                MessageBox.Show("Lütfen onaylanacak kaydı seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }
            string mesaj = fazlaCalismaManager.UpdateOnay(id);
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GorevAtama();
            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            id = 0;
            DataDisplay();

        }
        void GorevAtama()
        {
            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "FAZLA ÇALIŞMA");

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
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetDevamEdenler(id, "FAZLA ÇALIŞMA");

            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                if (item.IslemAdimi == "FAZLA ÇALIŞMA ONAYI")
                {
                    guncellenecekId = item.Id;
                }
            }

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(guncellenecekId, id, "FAZLA ÇALIŞMA", "FAZLA ÇALIŞMA ONAYI", sure, "00:02:00".ConOnlyTime(), infos[1].ToString());
            gorevAtamaPersonelManager.Update(gorevAtama, "FAZLA ÇALIŞMA TALEBİ ONAYLANDI");
        }
        void GorevAtamaRed()
        {
            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "FAZLA ÇALIŞMA");

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
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetDevamEdenler(id, "FAZLA ÇALIŞMA");

            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                if (item.IslemAdimi == "FAZLA ÇALIŞMA ONAYI")
                {
                    guncellenecekId = item.Id;
                }
            }

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(guncellenecekId, id, "FAZLA ÇALIŞMA", "FAZLA ÇALIŞMA ONAYI", sure, "00:02:00".ConOnlyTime(), infos[1].ToString());
            gorevAtamaPersonelManager.Update(gorevAtama, "FAZLA ÇALIŞMA TALEBİ REDDEDİLDİ");
        }


    }
}
