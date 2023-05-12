using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity;
using Entity.IdariIsler;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;
using Exception = System.Exception;
using Application = Microsoft.Office.Interop.Word.Application;
using Microsoft.Office.Interop.Word;
using DataAccess;
using System.Windows.Controls;

namespace UserInterface.IdariIsler
{
    public partial class FrmIzinIzleme : Form
    {
        List<Izin> ızins;
        IzinManager İzinManager;
        IdariIslerLogManager logManager;
        PersonelKayitManager kayitManager;
        IzinManager izinManager;
        List<Izin> izinFiltired;
        int outValue = 0, id;
        string sayfa, dosyayolu, isAkisNo, taslakYolu, izinTuru, dosya, bolum, personelAdi, toplamSure = "";
        public object[] infos;
        
        string kaynak = @"Z:\DTS\İDARİ İŞLER\WordTaslak\";
        string yol = @"C:\DTS\Taslak\";
        public FrmIzinIzleme()
        {
            InitializeComponent();
            İzinManager = IzinManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            izinManager = IzinManager.GetInstance();
        }

        private void FrmIzinIzleme_Load(object sender, EventArgs e)
        {
            DtgIzinList();
            if (infos[11].ToString() == "YÖNETİCİ" || infos[11].ToString() == "ADMİN" || infos[0].ConInt() == 1139)
            {
                contextMenuStrip1.Items[1].Enabled = true;
                contextMenuStrip1.Items[2].Enabled = true;
                contextMenuStrip1.Items[3].Enabled = true;
                BtnSorgula.Enabled = true;
                ChkTarih.Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[1].Enabled = false;
                contextMenuStrip1.Items[2].Enabled = false;
                contextMenuStrip1.Items[3].Enabled = false;
                BtnSorgula.Enabled = false;
                ChkTarih.Enabled = false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageIzinIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        public void DtgIzinList()
        {
            if (infos[11].ToString()=="YÖNETİCİ" || infos[11].ToString() == "ADMİN" || infos[0].ConInt() == 1139)
            {
                ızins = İzinManager.GetList();
            }
            else
            {
                ızins = İzinManager.GetListPersonel(infos[1].ToString());
            }
           
            izinFiltired = ızins;
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
            DtgList.Columns["Siparis"].Visible = false;

            TxtTop.Text = DtgList.RowCount.ToString();
        }
        public void DtgIzinListTarih()
        {
            ızins = İzinManager.GetListTarih(DtBasTarihi.Value, DtBitTarihi.Value);
            izinFiltired = ızins;
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

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DtgIzinList();
        }

        private void TxtAkısNo_TextChanged(object sender, EventArgs e)
        {
            int isno = 0;
            if (string.IsNullOrEmpty(TxtAkısNo.Text))
            {
                izinFiltired = ızins;
                dataBinder.DataSource = ızins.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtAkısNo.Text.Length < 3)
            {
                return;
            }
            if (!int.TryParse(TxtAkısNo.Text, out outValue))
            {
                MessageBox.Show("Rakamsal Değer Giriniz");
                return;
            }
            isno = TxtAkısNo.Text.ConInt();
            dataBinder.DataSource = izinFiltired.Where(x => x.Isakisno.ToString().Contains(isno.ToString())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            izinFiltired = ızins;
            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();
        }

        private void TxtAdSoyad_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtAdSoyad.Text;
            if (string.IsNullOrEmpty(isim))
            {
                izinFiltired = ızins;
                dataBinder.DataSource = ızins.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtAdSoyad.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = izinFiltired.Where(x => x.Adsoyad.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            izinFiltired = ızins;
            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }
        DateTime tarihBaslangic, tarihBitis;

        private void BtnSorgula_Click(object sender, EventArgs e)
        {
            DtgIzinListTarih();
        }

        private void ChkTarih_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTarih.Checked ==true)
            {
                DtBasTarihi.Enabled = true;
                DtBitTarihi.Enabled=true;
                BtnSorgula.Enabled=true;
            }
            else
            {
                DtBasTarihi.Enabled = false;
                DtBitTarihi.Enabled = false;
                BtnSorgula.Enabled = false;
                DtBasTarihi.Value= DateTime.Now;
                DtBitTarihi.Value=DateTime.Now;
                DtgIzinList();
            }
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz izni seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmIzınGuncelle frmIzınGuncelle = new FrmIzınGuncelle();
            frmIzınGuncelle.infos = infos;
            frmIzınGuncelle.id= id;
            frmIzınGuncelle.ShowDialog();
            id = 0;
        }
        DateTime haftasonuControl;
        int haftasonu = 0;

        private void BtnSureDuzelt_Click(object sender, EventArgs e)
        {
            List<Izin> ızins = new List<Izin>();
            ızins = izinManager.GetList();

            foreach (Izin item in ızins)
            {
                if (item.Izinturu != "HAFTALIK İZİN")
                {
                    TimeSpan toplamSureGun = item.Bittarihi - item.Bastarihi;
                    TimeSpan toplamSureSaat = item.Bittarihi - item.Bastarihi;

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


                    if (item.Bittarihi.Day < item.Bastarihi.Day)
                    {
                        haftasonuControl = item.Bastarihi;

                        while (item.Bittarihi.Month > haftasonuControl.Month)
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
                        haftasonuControl = item.Bastarihi;

                        while (item.Bittarihi.Day > haftasonuControl.Day)
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

                    string yeniSure = toplamSure;
                    haftasonu = 0;

                    izinManager.UpdateToplamSure(item.Id, yeniSure);
                }
                else
                {
                    TimeSpan toplamSureGun = item.Bittarihi - item.Bastarihi;
                    TimeSpan toplamSureSaat = item.Bittarihi - item.Bastarihi;

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

                    string yeniSure = toplamSure;

                    izinManager.UpdateToplamSure(item.Id, yeniSure);
                }
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Kaydı silmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                string mesaj = izinManager.Delete(id);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Kayıt Başarıyla silinmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DtgIzinList();
                DtgIslemAdimlari.DataSource = null;
                webBrowser1.Navigate("");
                id = 0;
            }
        }

        string izinNedeni, unvani;
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sayfa = DtgList.CurrentRow.Cells["Sayfa"].Value.ToString();
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            dosyayolu = DtgList.CurrentRow.Cells["Dosyayolu"].Value.ToString();
            isAkisNo = DtgList.CurrentRow.Cells["Isakisno"].Value.ToString();
            izinTuru = DtgList.CurrentRow.Cells["Izinturu"].Value.ToString();
            bolum = DtgList.CurrentRow.Cells["Bolum"].Value.ToString();
            personelAdi = DtgList.CurrentRow.Cells["Adsoyad"].Value.ToString();
            tarihBaslangic = DtgList.CurrentRow.Cells["Bastarihi"].Value.ConDate();
            tarihBitis = DtgList.CurrentRow.Cells["Bittarihi"].Value.ConDate();
            izinNedeni = DtgList.CurrentRow.Cells["Izınnedeni"].Value.ToString();
            unvani = DtgList.CurrentRow.Cells["Unvani"].Value.ToString();
            IslemAdimlariDisplay();
            try
            {
                webBrowser1.Navigate(dosyayolu);
            }
            catch (Exception)
            {
                return;
            }
            
        }

        private void formOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (id==0)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TaslakKopyala();
            CreateDirectory();
            CreateWordFile();
            CreateLog();
            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            id = 0;
        }
        void CreateLog()
        {
            string sayfa = "İZİN";
            Izin gorev = izinManager.Get(isAkisNo.ConInt());
            int benzersizid = gorev.Id;
            string islem = "İZİN KAYDI DÜZENLENDİ.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }

        void TaslakKopyala()
        {
            string root = @"C:\DTS";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(yol))
            {
                Directory.CreateDirectory(yol);
            }
            if (izinTuru == "HAFTALIK İZİN")
            {
                File.Copy(kaynak + "MP-FR-166 HAFTA SONU PERSONEL İZİN FORMU REV (00).docx", yol + "MP-FR-166 HAFTA SONU PERSONEL İZİN FORMU REV (00).docx");
                taslakYolu = yol + "MP-FR-166 HAFTA SONU PERSONEL İZİN FORMU REV (00).docx";
            }

            if (izinTuru == "MAZERET İZNİ" || izinTuru == "DOĞUM İZNİ" || izinTuru == "EVLİLİK İZNİ" || izinTuru == "ÖLÜM İZNİ" ||
               izinTuru == "GÜNLÜK İZİN")
            {
                File.Copy(kaynak + "GÜNLÜK İZİN- MGÜB.docx", yol + "GÜNLÜK İZİN- MGÜB.docx");
                taslakYolu = yol + "GÜNLÜK İZİN- MGÜB.docx";
            }

            if (izinTuru == "YILLIK İZİN")
            {
                File.Copy(kaynak + "YILLIK İZİN - MGÜB.docx", yol + "YILLIK İZİN - MGÜB.docx");
                taslakYolu = yol + "YILLIK İZİN - MGÜB.docx";
            }
        }
        void CreateDirectory()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\İZİN\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            if (!Directory.Exists(anadosya))
            {
                Directory.CreateDirectory(anadosya);
            }

            dosya = anadosya + isAkisNo + "\\";
            Directory.Delete(dosya, true);

            Directory.CreateDirectory(dosya);
        }
        void CreateWordFile()
        {

            if (izinTuru == "HAFTALIK İZİN")
            {
                PersonelKayit personelKayit = kayitManager.Get(0, personelAdi);
                PersonelKayit personelKayitSorumlu = kayitManager.Get(0, personelKayit.MasrafYeriSorumlusu);
                if (personelKayit==null)
                {
                    return;
                }
                if (personelKayitSorumlu==null)
                {
                    return;
                }
                Application wApp = new Application();
                Documents wDocs = wApp.Documents;
                object filePath = taslakYolu;
                Document wDoc = wDocs.Open(ref filePath, ReadOnly: false);
                wDoc.Activate();

                Bookmarks wBookmarks = wDoc.Bookmarks;
                wBookmarks["IsAkisNo"].Range.Text = isAkisNo;
                wBookmarks["DuzenlenmeTarihi"].Range.Text = DateTime.Now.ToString("d");
                wBookmarks["Bolum"].Range.Text = bolum;

                wBookmarks["Personel1"].Range.Text = personelAdi;
                wBookmarks["BasTarihi1"].Range.Text = tarihBaslangic.ToString("d");
                wBookmarks["BitTarihi1"].Range.Text = tarihBitis.ToString("d");
                wBookmarks["Aciklama1"].Range.Text = izinNedeni;

                wBookmarks["SorumluPersonel"].Range.Text = personelKayit.MasrafYeriSorumlusu;
                wBookmarks["SorumluTarih"].Range.Text = DateTime.Now.ToString("d");
                wBookmarks["SorumluGorevi"].Range.Text = personelKayitSorumlu.Isunvani;

                wDoc.SaveAs2(dosya + isAkisNo + ".docx");
                wDoc.Close();
                wApp.Quit(false);

            }

            if (izinTuru == "MAZERET İZNİ" || izinTuru == "DOĞUM İZNİ" || izinTuru == "EVLİLİK İZNİ" || izinTuru == "ÖLÜM İZNİ" ||
                izinTuru == "GÜNLÜK İZİN")
            {
                Application wApp = new Application();
                Documents wDocs = wApp.Documents;
                object filePath = taslakYolu;
                Document wDoc = wDocs.Open(ref filePath, ReadOnly: false);
                wDoc.Activate();

                Bookmarks wBookmarks = wDoc.Bookmarks;
                wBookmarks["AdSoyad"].Range.Text = personelAdi;
                wBookmarks["Departman"].Range.Text = "MUB " + bolum;
                wBookmarks["Unvan"].Range.Text = unvani;

                TimeSpan toplamSureGun = tarihBitis - tarihBaslangic;
                TimeSpan toplamSureSaat = tarihBitis - tarihBaslangic;

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


                wBookmarks["İzinCikisTarihi"].Range.Text = tarihBaslangic.ToString("g");
                wBookmarks["İzinDonusTarihi"].Range.Text = tarihBitis.ToString("g");
                wBookmarks["IzinSuresi"].Range.Text = toplamSure;
                wBookmarks["Aciklama"].Range.Text = izinNedeni;
                wBookmarks["PersonelAd"].Range.Text = personelAdi;
                if (izinTuru == "DOĞUM İZNİ")
                {
                    wBookmarks["Dogum"].Range.Text = "X";
                }
                if (izinTuru == "EVLİLİK İZNİ")
                {
                    wBookmarks["Evlilik"].Range.Text = "X";
                }
                if (izinTuru == "GÜNLÜK İZİN")
                {
                    wBookmarks["Gunluk"].Range.Text = "X";
                }
                if (izinTuru == "ÖLÜM İZNİ")
                {
                    wBookmarks["Olum"].Range.Text = "X";
                }
                if (izinTuru == "ÜCRETLİ İZİN")
                {
                    wBookmarks["Olum"].Range.Text = "X";
                }
                if (izinTuru == "ÜCRETLİ İZİN")
                {
                    wBookmarks["Ucretli"].Range.Text = "X";
                }
                if (izinTuru == "ÜCRETSİZ İZİN")
                {
                    wBookmarks["Ucretsiz"].Range.Text = "X";
                }

                wDoc.SaveAs2(dosya + isAkisNo + ".docx");
                wDoc.Close();
                wApp.Quit(false);
            }

            if (izinTuru == "YILLIK İZİN")
            {
                PersonelKayit personelKayit = kayitManager.Get(0, personelAdi);
                Application wApp = new Application();
                Documents wDocs = wApp.Documents;
                object filePath = taslakYolu;
                Document wDoc = wDocs.Open(ref filePath, ReadOnly: false);
                wDoc.Activate();

                Bookmarks wBookmarks = wDoc.Bookmarks;
                wBookmarks["Tarih"].Range.Text = DateTime.Now.ToString("d");
                wBookmarks["Tc"].Range.Text = personelKayit.Tc;
                wBookmarks["Bolum"].Range.Text = bolum;
                wBookmarks["Yil"].Range.Text = DateTime.Now.ToString("yyyy");
                wBookmarks["TarihBaslangic"].Range.Text = tarihBaslangic.ToString("d");
                wBookmarks["TarihBitis"].Range.Text = tarihBitis.ToString("d");
                wBookmarks["AdSoyad"].Range.Text = personelAdi;
                wBookmarks["Unvan"].Range.Text = unvani;
                wBookmarks["IseGirisTarihi"].Range.Text = personelKayit.Isegiristarihi.ToString("dd.MM") + "." + DateTime.Now.ToString("yyyy");
                wBookmarks["IzinBasTarihi"].Range.Text = tarihBaslangic.ToString("d");
                wBookmarks["IzinBitTarihi"].Range.Text = tarihBitis.ToString("d");
                DateTime isBasiTarih = tarihBitis.AddDays(1);
                string isBasiGun = isBasiTarih.ToString("dddd");
                DateTime isBasi = isBasiTarih;
                if (isBasiGun == "Cumartesi")
                {
                    isBasi = tarihBaslangic.AddDays(2);
                }
                if (isBasiGun == "Pazar")
                {
                    isBasi = tarihBaslangic.AddDays(3);
                }
                wBookmarks["IsBasiYapacagiTarih"].Range.Text = isBasi.ToString("d");
                TimeSpan timeSpan = tarihBitis - tarihBaslangic;
                wBookmarks["IzınSuresi"].Range.Text = timeSpan.Days.ToString() + " Gün";
                wBookmarks["YolIzni"].Range.Text = " ";
                wBookmarks["IzinAdres"].Range.Text = personelKayit.Dogumyeri;
                wBookmarks["Telefon"].Range.Text = personelKayit.Sirketcep;
                wBookmarks["Aciklama"].Range.Text = izinNedeni;

                wDoc.SaveAs2(dosya + isAkisNo + ".docx");
                wDoc.Close();
                wApp.Quit(false);
            }

            try
            {
                Directory.Delete(yol, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                File.Delete(taslakYolu);
            }

        }

        void IslemAdimlariDisplay()
        {
            DtgIslemAdimlari.DataSource = logManager.GetList(sayfa, id);
            DtgIslemAdimlari.Columns["Id"].Visible = false;
            DtgIslemAdimlari.Columns["Sayfa"].Visible = false;
            DtgIslemAdimlari.Columns["Benzersizid"].Visible = false;
            DtgIslemAdimlari.Columns["Islem"].HeaderText = "YAPILAN İŞLEM";
            DtgIslemAdimlari.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgIslemAdimlari.Columns["Tarih"].HeaderText = "TARİH";
            DtgIslemAdimlari.Columns["Tarih"].Width = 100;
            DtgIslemAdimlari.Columns["Islemyapan"].Width = 135;
            DtgIslemAdimlari.Columns["Islem"].Width = 400;
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                string izinsuresi = DtgList.Rows[i].Cells[13].Value.ToString();
                string[] array = izinsuresi.Split(' ');
                toplam += Convert.ToDouble(array[0].ConInt());
            }
            LblGenelTop.Text = toplam.ToString() + " Gün";
        }

    }
}
