using Business.Concreate.BakimOnarim;
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
    public partial class FrmOkfIzleme : Form
    {
        OkfManager okfManager;
        DtfMaliyetManager dtfMaliyetManager;
        List<Okf> okfs;
        List<Okf> okfsSSB;
        List<Okf> okfsMusteriOnayi;
        List<Okf> tamamlanan;
        List<DtfMaliyet> dtfMaliyets;
        List<Okf> yapilacakIslemler;
        public object[] infos;
        string dosyaYolu;
        int id, isAkisNo;
        double toplam;
        public FrmOkfIzleme()
        {
            InitializeComponent();
            okfManager = OkfManager.GetInstance();
            dtfMaliyetManager = DtfMaliyetManager.GetInstance();
        }

        private void FrmOkfIzleme_Load(object sender, EventArgs e)
        {
            if (infos[11].ToString() == "MİSAFİR")
            {
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[1].Enabled = false;
                contextMenuStrip1.Items[2].Enabled = false;
                contextMenuStrip1.Items[3].Enabled = false;
                contextMenuStrip1.Items[4].Enabled = false;
            }
            Tamamlanan();
            MusteriOnayi();
            SSBSunulan();
            AselsanaGonderilen();
        }
        public void AselsanaGonderilen()
        {
            okfs = okfManager.GetList("ASELSANA GÖNDERİLEN");
            dataBinder.DataSource = okfs.ToDataTable();
            DtgList.DataSource = dataBinder;

            LblTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["KayitYapan"].HeaderText = "KAYIT YAPAN";
            DtgList.Columns["KayitTarihi"].HeaderText = "KAYIT TARİHİ";
            DtgList.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgList.Columns["ArizaTarihi"].HeaderText = "ARIZA TARİHİ";
            DtgList.Columns["UsBolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgList.Columns["ProjeKodu"].HeaderText = "PROJE KODU";
            DtgList.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgList.Columns["UbKomutani"].HeaderText = "ÜS BÖLGESİ KOMUTANI";
            DtgList.Columns["KomutanTel"].HeaderText = "ÜS BÖLGESİ TELEFON";
            DtgList.Columns["BirlikAdresi"].HeaderText = "BİRLİK ADRESİ";
            DtgList.Columns["Il"].HeaderText = "İL";
            DtgList.Columns["Ilce"].HeaderText = "İLÇE";
            DtgList.Columns["UstStok"].HeaderText = "STOK NO";
            DtgList.Columns["UstTanim"].HeaderText = "TANIM";
            DtgList.Columns["UstSeriNo"].HeaderText = "SERİ NO";
            DtgList.Columns["BildirilenAriza"].HeaderText = "BİLDİRİLEN ARIZA";
            DtgList.Columns["ArizaDurum"].Visible = false;
            DtgList.Columns["ArizaNedeni"].HeaderText = "ARIZA NEDENİ";
            DtgList.Columns["GenelOneriler"].HeaderText = "GENEL ÖNERİLER";
            DtgList.Columns["ToplamTutar"].HeaderText = "TOPLAM TUTAR";
            DtgList.Columns["DosyaYolu"].Visible = false;
            DtgList.Columns["YapilacakIslemler"].Visible = false;
            DtgList.Columns["BildirimNo"].HeaderText = "BİLDİRİM NO";

            ToplamlarGenel(DtgList);

        }
        public void SSBSunulan()
        {
            okfsSSB = okfManager.GetList("SSB ONAYINA SUNULAN");
            dataBinderSSB.DataSource = okfsSSB.ToDataTable();
            DtgListSSB.DataSource = dataBinderSSB;

            DtgListSSB.Columns["Id"].Visible = false;
            DtgListSSB.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgListSSB.Columns["KayitYapan"].HeaderText = "KAYIT YAPAN";
            DtgListSSB.Columns["KayitTarihi"].HeaderText = "KAYIT TARİHİ";
            DtgListSSB.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgListSSB.Columns["ArizaTarihi"].HeaderText = "ARIZA TARİHİ";
            DtgListSSB.Columns["UsBolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgListSSB.Columns["ProjeKodu"].HeaderText = "PROJE KODU";
            DtgListSSB.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgListSSB.Columns["UbKomutani"].HeaderText = "ÜS BÖLGESİ KOMUTANI";
            DtgListSSB.Columns["KomutanTel"].HeaderText = "ÜS BÖLGESİ TELEFON";
            DtgListSSB.Columns["BirlikAdresi"].HeaderText = "BİRLİK ADRESİ";
            DtgListSSB.Columns["Il"].HeaderText = "İL";
            DtgListSSB.Columns["Ilce"].HeaderText = "İLÇE";
            DtgListSSB.Columns["UstStok"].HeaderText = "STOK NO";
            DtgListSSB.Columns["UstTanim"].HeaderText = "TANIM";
            DtgListSSB.Columns["UstSeriNo"].HeaderText = "SERİ NO";
            DtgListSSB.Columns["BildirilenAriza"].HeaderText = "BİLDİRİLEN ARIZA";
            DtgListSSB.Columns["ArizaDurum"].Visible = false;
            DtgListSSB.Columns["ArizaNedeni"].HeaderText = "ARIZA NEDENİ";
            DtgListSSB.Columns["GenelOneriler"].HeaderText = "GENEL ÖNERİLER";
            DtgListSSB.Columns["ToplamTutar"].HeaderText = "TOPLAM TUTAR";
            DtgListSSB.Columns["DosyaYolu"].Visible = false;
            DtgListSSB.Columns["YapilacakIslemler"].Visible = false;
            DtgListSSB.Columns["BildirimNo"].HeaderText = "BİLDİRİM NO";

        }
        public void MusteriOnayi()
        {
            okfsMusteriOnayi = okfManager.GetList("MÜŞTERİ ONAYI GELEN");
            dataBinderMusteriOnayi.DataSource = okfsMusteriOnayi.ToDataTable();
            DtgListMusteriOnayi.DataSource = dataBinderMusteriOnayi;

            DtgListMusteriOnayi.Columns["Id"].Visible = false;
            DtgListMusteriOnayi.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgListMusteriOnayi.Columns["KayitYapan"].HeaderText = "KAYIT YAPAN";
            DtgListMusteriOnayi.Columns["KayitTarihi"].HeaderText = "KAYIT TARİHİ";
            DtgListMusteriOnayi.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgListMusteriOnayi.Columns["ArizaTarihi"].HeaderText = "ARIZA TARİHİ";
            DtgListMusteriOnayi.Columns["UsBolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgListMusteriOnayi.Columns["ProjeKodu"].HeaderText = "PROJE KODU";
            DtgListMusteriOnayi.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgListMusteriOnayi.Columns["UbKomutani"].HeaderText = "ÜS BÖLGESİ KOMUTANI";
            DtgListMusteriOnayi.Columns["KomutanTel"].HeaderText = "ÜS BÖLGESİ TELEFON";
            DtgListMusteriOnayi.Columns["BirlikAdresi"].HeaderText = "BİRLİK ADRESİ";
            DtgListMusteriOnayi.Columns["Il"].HeaderText = "İL";
            DtgListMusteriOnayi.Columns["Ilce"].HeaderText = "İLÇE";
            DtgListMusteriOnayi.Columns["UstStok"].HeaderText = "STOK NO";
            DtgListMusteriOnayi.Columns["UstTanim"].HeaderText = "TANIM";
            DtgListMusteriOnayi.Columns["UstSeriNo"].HeaderText = "SERİ NO";
            DtgListMusteriOnayi.Columns["BildirilenAriza"].HeaderText = "BİLDİRİLEN ARIZA";
            DtgListMusteriOnayi.Columns["ArizaDurum"].Visible = false;
            DtgListMusteriOnayi.Columns["ArizaNedeni"].HeaderText = "ARIZA NEDENİ";
            DtgListMusteriOnayi.Columns["GenelOneriler"].HeaderText = "GENEL ÖNERİLER";
            DtgListMusteriOnayi.Columns["ToplamTutar"].HeaderText = "TOPLAM TUTAR";
            DtgListMusteriOnayi.Columns["DosyaYolu"].Visible = false;
            DtgListMusteriOnayi.Columns["YapilacakIslemler"].Visible = false;
            DtgListMusteriOnayi.Columns["BildirimNo"].HeaderText = "BİLDİRİM NO";

        }

        public void Tamamlanan()
        {
            tamamlanan = okfManager.GetList("TAMAMLANAN");
            dataBinderTamamlanan.DataSource = tamamlanan.ToDataTable();
            DtgListTamamlanan.DataSource = dataBinderTamamlanan;

            DtgListTamamlanan.Columns["Id"].Visible = false;
            DtgListTamamlanan.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgListTamamlanan.Columns["KayitYapan"].HeaderText = "KAYIT YAPAN";
            DtgListTamamlanan.Columns["KayitTarihi"].HeaderText = "KAYIT TARİHİ";
            DtgListTamamlanan.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgListTamamlanan.Columns["ArizaTarihi"].HeaderText = "ARIZA TARİHİ";
            DtgListTamamlanan.Columns["UsBolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgListTamamlanan.Columns["ProjeKodu"].HeaderText = "PROJE KODU";
            DtgListTamamlanan.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgListTamamlanan.Columns["UbKomutani"].HeaderText = "ÜS BÖLGESİ KOMUTANI";
            DtgListTamamlanan.Columns["KomutanTel"].HeaderText = "ÜS BÖLGESİ TELEFON";
            DtgListTamamlanan.Columns["BirlikAdresi"].HeaderText = "BİRLİK ADRESİ";
            DtgListTamamlanan.Columns["Il"].HeaderText = "İL";
            DtgListTamamlanan.Columns["Ilce"].HeaderText = "İLÇE";
            DtgListTamamlanan.Columns["UstStok"].HeaderText = "STOK NO";
            DtgListTamamlanan.Columns["UstTanim"].HeaderText = "TANIM";
            DtgListTamamlanan.Columns["UstSeriNo"].HeaderText = "SERİ NO";
            DtgListTamamlanan.Columns["BildirilenAriza"].HeaderText = "BİLDİRİLEN ARIZA";
            DtgListTamamlanan.Columns["ArizaDurum"].Visible = false;
            DtgListTamamlanan.Columns["ArizaNedeni"].HeaderText = "ARIZA NEDENİ";
            DtgListTamamlanan.Columns["GenelOneriler"].HeaderText = "GENEL ÖNERİLER";
            DtgListTamamlanan.Columns["ToplamTutar"].HeaderText = "TOPLAM TUTAR";
            DtgListTamamlanan.Columns["DosyaYolu"].Visible = false;
            DtgListTamamlanan.Columns["YapilacakIslemler"].Visible = false;
            DtgListTamamlanan.Columns["BildirimNo"].HeaderText = "BİLDİRİM NO";

        }
        public void Yenilenecekler()
        {
            Tamamlanan();
            MusteriOnayi();
            SSBSunulan();
            AselsanaGonderilen();
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyaYolu = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            isAkisNo = DtgList.CurrentRow.Cells["IsAkisNo"].Value.ConInt();
            MalzemeList(id);
            YapilacakIslemlerList(id);
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }
        void MalzemeList(int id)
        {
            DtgMalzemeList.Rows.Clear();
            dtfMaliyets = dtfMaliyetManager.GetList(id, "OKF");

            if (dtfMaliyets.Count==0)
            {
                return;
            }

            foreach (DtfMaliyet item in dtfMaliyets)
            {
                DtgMalzemeList.Rows.Add();
                int sonSatir = DtgMalzemeList.RowCount - 1;
                string[] isTanim = item.IsTanimi.Split('|');

                if (isTanim.Length==1)
                {
                    DtgMalzemeList.Rows[sonSatir].Cells["StokNo"].Value = "N/A";
                    DtgMalzemeList.Rows[sonSatir].Cells["Tanimm"].Value = isTanim[0];
                }
                else
                {
                    DtgMalzemeList.Rows[sonSatir].Cells["StokNo"].Value = isTanim[0];
                    DtgMalzemeList.Rows[sonSatir].Cells["Tanimm"].Value = isTanim[1];
                }
                DtgMalzemeList.Rows[sonSatir].Cells["Miktar"].Value = item.Miktar.ToString();
                DtgMalzemeList.Rows[sonSatir].Cells["Birim"].Value = item.Birim;
                DtgMalzemeList.Rows[sonSatir].Cells["PBirim"].Value = item.PBirimi;
                DtgMalzemeList.Rows[sonSatir].Cells["BirimTutar"].Value = item.BirimTutar;
                DtgMalzemeList.Rows[sonSatir].Cells["ToplamTutar"].Value = item.ToplamTutar;

            }
            Toplamlar();
        }

        void Toplamlar()
        {
            toplam = 0;
            for (int i = 0; i < DtgMalzemeList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgMalzemeList.Rows[i].Cells["ToplamTutar"].Value);
            }
            LblTop2.Text = toplam.ToString("C2");
        }
        void ToplamlarGenel(DataGridView dataGridView)
        {
            toplam = 0;
            for (int i = 0; i < dataGridView.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(dataGridView.Rows[i].Cells["ToplamTutar"].Value);
            }
            LblToplamGenel.Text = toplam.ToString("C2");
        }

        void YapilacakIslemlerList(int id)
        {
            DtgYapilacakIslemler.Rows.Clear();
            yapilacakIslemler = okfManager.YapilacakIslemlerGetList(id);
            if (yapilacakIslemler.Count==0)
            {
                return;
            }
            foreach (Okf item in yapilacakIslemler)
            {
                DtgYapilacakIslemler.Rows.Add();
                int sonSatir = DtgYapilacakIslemler.RowCount - 1;
                DtgYapilacakIslemler.Rows[sonSatir].Cells["YapilacakIslemler"].Value = item.YapilacakIslemler;
            }
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            LblTop.Text=DtgList.RowCount.ToString();
            ToplamlarGenel(DtgList);

        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort=DtgList.SortString;
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOkfGuncelle frmOkfGuncelle = new FrmOkfGuncelle();
            frmOkfGuncelle.id = id;
            frmOkfGuncelle.ShowDialog();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageOKFIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex==0)
            {
                LblTop.Text= DtgList.RowCount.ToString();
                ToplamlarGenel(DtgList);
            }
            if (tabControl2.SelectedIndex == 1)
            {
                LblTop.Text = DtgListSSB.RowCount.ToString();
                ToplamlarGenel(DtgListSSB);
            }
            if (tabControl2.SelectedIndex == 2)
            {
                LblTop.Text = DtgListMusteriOnayi.RowCount.ToString();
                ToplamlarGenel(DtgListMusteriOnayi);
            }
            if (tabControl2.SelectedIndex == 3)
            {
                LblTop.Text = DtgListTamamlanan.RowCount.ToString();
                ToplamlarGenel(DtgListTamamlanan);
            }
            DtgMalzemeList.Rows.Clear();
            DtgYapilacakIslemler.Rows.Clear();
            webBrowser1.Navigate("");
        }

        private void DtgListSSB_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgListSSB.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyaYolu = DtgListSSB.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            id = DtgListSSB.CurrentRow.Cells["Id"].Value.ConInt();

            MalzemeList(id);
            YapilacakIslemlerList(id);
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void DtgListMusteriOnayi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgListMusteriOnayi.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyaYolu = DtgListMusteriOnayi.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            id = DtgListMusteriOnayi.CurrentRow.Cells["Id"].Value.ConInt();

            MalzemeList(id);
            YapilacakIslemlerList(id);
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void DtgListTamamlanan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgListTamamlanan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyaYolu = DtgListTamamlanan.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            id = DtgListTamamlanan.CurrentRow.Cells["Id"].Value.ConInt();

            MalzemeList(id);
            YapilacakIslemlerList(id);
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void sSBOnayınaSunulanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(isAkisNo.ToString() + " İş Akış Numaralı kaydın durumunu SSB ONAYINA SUNULAN olarak değiştirmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = okfManager.OkfDurumUpdate(id, "SSB ONAYINA SUNULAN");
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Yenilenecekler();
                id = 0;
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void müşteriOnayıGelenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(isAkisNo.ToString() + " İş Akış Numaralı kaydın durumunu MÜŞTERİ ONAYI GELEN olarak değiştirmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = okfManager.OkfDurumUpdate(id, "MÜŞTERİ ONAYI GELEN");
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Yenilenecekler();
                id = 0;
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tamamlananToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(isAkisNo.ToString() + " İş Akış Numaralı kaydın durumunu TAMAMLANAN olarak değiştirmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = okfManager.OkfDurumUpdate(id, "TAMAMLANAN");
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Yenilenecekler();
                id = 0;
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DtgListSSB_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinderSSB.Filter = DtgListSSB.FilterString;
            LblTop.Text = DtgListSSB.RowCount.ToString();
            ToplamlarGenel(DtgListSSB);
        }

        private void DtgListSSB_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderSSB.Sort = DtgListSSB.SortString;
        }

        private void DtgListMusteriOnayi_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinderMusteriOnayi.Filter = DtgListMusteriOnayi.FilterString;
            LblTop.Text = DtgListMusteriOnayi.RowCount.ToString();
            ToplamlarGenel(DtgListMusteriOnayi);
        }

        private void DtgListMusteriOnayi_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderMusteriOnayi.Sort = DtgListMusteriOnayi.SortString;
        }

        private void DtgListTamamlanan_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinderTamamlanan.Filter = DtgListTamamlanan.FilterString;
            LblTop.Text = DtgListTamamlanan.RowCount.ToString();
            ToplamlarGenel(DtgListTamamlanan);
        }

        private void DtgListTamamlanan_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderTamamlanan.Sort = DtgListTamamlanan.SortString;
        }

        private void aselsanaGönderilenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(isAkisNo.ToString() + " İş Akış Numaralı kaydın durumunu ASELSANA GÖNDERİLEN olarak değiştirmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = okfManager.OkfDurumUpdate(id, "ASELSANA GÖNDERİLEN");
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Yenilenecekler();
                id = 0;
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
