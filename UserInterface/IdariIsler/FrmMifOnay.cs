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
    public partial class FrmMifOnay : Form
    {
        MalzemeTalepManager malzemeTalepManager;
        List<MalzemeTalep> malzemeTaleps;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;

        string tanim, personel;
        public object[] infos;
        int id;
        public FrmMifOnay()
        {
            InitializeComponent();
            malzemeTalepManager = MalzemeTalepManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
        }

        private void FrmMifOnay_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageMifOnay"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        public void DataDisplay()
        {
            malzemeTaleps = malzemeTalepManager.GetListIslemDurumu("ONAY AŞAMASINDA");
            dataBinder.DataSource = malzemeTaleps.ToDataTable();
            DtgList.DataSource = dataBinder;

            DtgList.Columns["Id"].HeaderText = "ID";
            DtgList.Columns["MalzemeKategorisi"].HeaderText = "MALZEME KATEGORİSİ";
            DtgList.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDİLEN PERSONEL";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["StokNo"].HeaderText = "STOK NO";
            DtgList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgList.Columns["Birim"].HeaderText = "BİRİM";
            DtgList.Columns["TalebiOlusturan"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgList.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgList.Columns["SatBilgisi"].Visible = false;
            DtgList.Columns["MasrafYeri"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["IslemDurumu"].HeaderText = "İŞLEM DURUMU";
            DtgList.Columns["RedGerekcesi"].Visible = false;
            DtgList.Columns["ToplamMiktar"].Visible = false;
            DtgList.Columns["Secim"].Visible = false;

            DtgList.Columns["Id"].DisplayIndex = 0;
            DtgList.Columns["Bolum"].DisplayIndex = 1;
            DtgList.Columns["MasrafYeri"].DisplayIndex = 2;
            DtgList.Columns["TalebiOlusturan"].DisplayIndex = 3;
            DtgList.Columns["MalzemeKategorisi"].DisplayIndex = 4;
            DtgList.Columns["StokNo"].DisplayIndex = 5;
            DtgList.Columns["Tanim"].DisplayIndex = 6;
            DtgList.Columns["TalepEdenPersonel"].DisplayIndex = 7;
            DtgList.Columns["Miktar"].DisplayIndex = 8;
            DtgList.Columns["Birim"].DisplayIndex = 9;
            DtgList.Columns["SatBilgisi"].DisplayIndex = 10;

            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();

        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgList.Rows[i].Cells["Miktar"].Value);
            }
            TxtMiktar.Text = toplam.ToString();
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

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            tanim = DtgList.CurrentRow.Cells["Tanim"].Value.ToString();
            personel = DtgList.CurrentRow.Cells["TalepEdenPersonel"].Value.ToString();

        }
        DateTime birOncekiTarih;
        int gun, saat, dakika; string sure;
        void GorevAtama()
        {
            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "MİF");
            if (gorevAtamaPersonel==null)
            {
                return;
            }
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

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(id, "MİF", "MİF ONAYI", sure, "00:02:00".ConOnlyTime());
            gorevAtamaPersonelManager.Update(gorevAtama, "MİF ONAYLANDI");
        }
        void GorevAtamaRed()
        {
            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "MİF");

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

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(id, "MİF", "MİF ONAYI", sure, "00:02:00".ConOnlyTime());
            gorevAtamaPersonelManager.Update(gorevAtama, "MİF REDDEDİLDİ");
        }

        private void BtnGorevAta_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in DtgList.Rows)
            {
                GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(item.Cells["Id"].Value.ConInt(), "MİF", "RESUL GÜNEŞ", "MİF ONAYI", DateTime.Now, "", DateTime.Now.Date);
                gorevAtamaPersonelManager.Add(gorevAtamaPersonel);
            }

            MessageBox.Show("Tamamlandı");
        }

        private void BtnTumunuOnayla_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Görüntülenen tüm kayıtları toplu olarak onaylamak isteiğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    malzemeTalepManager.Update(item.Cells["Id"].Value.ConInt(), "ONAYLANDI, STOK KONTROL");
                    id = item.Cells["Id"].Value.ConInt();
                    GorevAtama();
                }
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id = 0;
                DataDisplay();
            }

        }

        private void BtnReddet_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle Bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(personel + " Adlı personelin " + tanim + " talebini reddetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = malzemeTalepManager.Update(id, "REDDEDİLDİ");
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                GorevAtamaRed();
                id = 0;
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataDisplay();
            }
            
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("Lütfen öncelikle Bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(personel + " Adlı personelin " + tanim + " talebini onaylamak istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                string mesaj = malzemeTalepManager.Update(id, "ONAYLANDI, STOK KONTROL");
                if (mesaj !="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                GorevAtama();
                id = 0;
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataDisplay();
            }
            
            
        }
    }
}
