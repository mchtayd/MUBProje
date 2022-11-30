using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity.IdariIsler;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;
using UserInterface.STS;
using Application = Microsoft.Office.Interop.Word.Application;
using Task = System.Threading.Tasks.Task;

namespace UserInterface.IdariIsler
{
    public partial class FrmKonaklamaOnay : Form
    {
        KonaklamaManager konaklamaManager;
        IdariIslerLogManager logManager;

        List<Konaklama> konaklamas;

        int id, isakisno;
        string formno, adSoyad, dosyaKonaklama;
        public object[] infos;
        public FrmKonaklamaOnay()
        {
            InitializeComponent();
            konaklamaManager = KonaklamaManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
        }

        private void FrmKonaklamaOnay_Load(object sender, EventArgs e)
        {
            Konaklama();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageKonaklamaOnay"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void Konaklama()
        {
            konaklamas = konaklamaManager.OnayList("ONAYLANMADI");
            dataBinder.DataSource = konaklamas.ToDataTable();
            DtgKonaklama.DataSource = dataBinder;
            DtgKonaklama.Columns["Id"].Visible = false;
            DtgKonaklama.Columns["Talepturu"].HeaderText = "TALEP TÜRÜ";
            DtgKonaklama.Columns["Formno"].HeaderText = "GÖREV FORM NO";
            DtgKonaklama.Columns["Butcekodu"].HeaderText = "BÜTÇE KODU/TANIMI";
            DtgKonaklama.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgKonaklama.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgKonaklama.Columns["Gorevi"].HeaderText = "GÖREVİ";
            DtgKonaklama.Columns["Masrafyerino"].HeaderText = "MASRAF YERİ NO";
            DtgKonaklama.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ";
            DtgKonaklama.Columns["Tc"].HeaderText = "TC KİMLİK NO";
            DtgKonaklama.Columns["Hes"].HeaderText = "HES KODU";
            DtgKonaklama.Columns["Email"].HeaderText = "E-MAIL";
            DtgKonaklama.Columns["Kisakod"].HeaderText = "ŞİRKET NO/KISA KOD";
            DtgKonaklama.Columns["Otelsehir"].HeaderText = "OTELİN BULUNDUĞU ŞEHİR";
            DtgKonaklama.Columns["Otelad"].HeaderText = "OTELİN ADI";
            DtgKonaklama.Columns["Giristarihi"].HeaderText = "GİRİŞ TARİHİ";
            DtgKonaklama.Columns["Cikistarihi"].HeaderText = "ÇIKIŞ TARİHİ";
            DtgKonaklama.Columns["Konaklamasuresi"].HeaderText = "KONAKLAMA SÜRESİ";
            DtgKonaklama.Columns["Gunukucret"].HeaderText = "GÜNLÜK KONAKLAMA TUTARI";
            DtgKonaklama.Columns["Toplamucret"].HeaderText = "TOPLAM KONAKLAMA TUTARI";
            DtgKonaklama.Columns["isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgKonaklama.Columns["Onay"].Visible = false;
            DtgKonaklama.Columns["Dosyayolu"].Visible = false;

            TxtTopKonaklama.Text = DtgKonaklama.RowCount.ToString();
        }

        private void DtgKonaklama_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgKonaklama.FilterString;
            TxtTopKonaklama.Text = DtgKonaklama.RowCount.ToString();
        }

        private void DtgKonaklama_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgKonaklama.SortString;
        }

        private void DtgKonaklama_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgKonaklama.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            id = DtgKonaklama.CurrentRow.Cells["Id"].Value.ConInt();
            formno = DtgKonaklama.CurrentRow.Cells["Formno"].Value.ToString();
            isakisno = DtgKonaklama.CurrentRow.Cells["Isakisno"].Value.ConInt();
            adSoyad = DtgKonaklama.CurrentRow.Cells["Adsoyad"].Value.ToString();
            dosyaKonaklama = DtgKonaklama.CurrentRow.Cells["Dosyayolu"].Value.ToString();
        }

        private async void BtnTumunuOnayla_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (DtgKonaklama.RowCount <= 0)
                {
                    MessageBox.Show("Listede Onaylanacak Kayıt Bulunamamıştır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult dr = MessageBox.Show("Tüm Kayıtları Onaylamak İstediğinize Emin Misiniz? Bu İşlem Biraz Zaman Alabilir!", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    FrmWait frmWait = new FrmWait();
                    this.Invoke((MethodInvoker)(() => frmWait.Show(this)));
                    var frmAnasayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
                    frmAnasayfa.Invoke((MethodInvoker)(() => frmAnasayfa.Enabled = false));

                    foreach (DataGridViewRow item in DtgKonaklama.Rows)
                    {
                        DtgKonaklama.Invoke((MethodInvoker)(() => isakisno = item.Cells["Isakisno"].Value.ConInt()));
                        DtgKonaklama.Invoke((MethodInvoker)(() => dosyaKonaklama = item.Cells["Dosyayolu"].Value.ToString()));
                        DtgKonaklama.Invoke((MethodInvoker)(() => id = item.Cells["Id"].Value.ConInt()));


                        string mesaj = konaklamaManager.OnayGuncelle("ONAYLANDI", id);
                        //string mesaj = "OK";
                        if (mesaj != "OK")
                        {
                            MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        CreateLogOnaylamaToplu();
                        CreateWordKonaklamaToplu();

                        DtgKonaklama.Invoke((MethodInvoker)(() => item.DefaultCellStyle.BackColor = Color.LightGreen));
                    }
                    FrmWait.isActive = false;
                    if (System.Windows.Forms.Application.OpenForms.OfType<FrmWait>().Count() == 1)
                    {
                        frmWait.Invoke((MethodInvoker)(() => frmWait.Close()));
                    }

                    frmAnasayfa.Invoke((MethodInvoker)(() => frmAnasayfa.Enabled = true));
                }
            });

            Konaklama();
        }
        void CreateWordKonaklamaToplu()
        {
            if (adSoyad == "")
            {
                MessageBox.Show("Lütfen Öncelikle Bir Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            //object filePath = "C:\\Users\\MAYıldırım\\Desktop\\Formlar\\DTS_Otel Rezervasyon Talep Formu.docx"; // taslak yolu
            object filePath = dosyaKonaklama + isakisno + ".docx";
            if (!File.Exists(filePath.ToString()))
            {
                // To Do : Dosya Worde aktarılamadı 
                return;
            }

            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["Onay"].Range.Text = "DTS Modülünde Konaklama Talebi Onaylandı.";
            wBookmarks["Onay"].Range.Font.Color = WdColor.wdColorRed;
            wBookmarks["OnayTarihi"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy H/mm/ss");

            wDoc.SaveAs2(dosyaKonaklama + isakisno + ".docx");
            //wDoc.SaveAs2(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\DD\\" + konaklamaIsAkisNo + ".docx");
            wDoc.Close();
            wApp.Quit(false);
        }

        void CreateLogOnaylamaToplu()
        {
            string sayfa = "KONAKLAMA";
            Konaklama gorev = konaklamaManager.Get(isakisno);
            int benzersizid = gorev.Id;
            string islem = "KONAKLAMA TALEBİ ONAYLANDI.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }

        private void BtnReddet_Click(object sender, EventArgs e)
        {

        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Konaklama Bilgisi Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(formno + " Nolu Konaklama Talebini Onaylamak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = konaklamaManager.OnayGuncelle("ONAYLANDI", id);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLogOnaylama();
                CreateWordKonaklama();
                MessageBox.Show("Onaylama İşlemi Başarıyla Gerçekleşmştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id = 0;
            }
        }
        void CreateLogOnaylama()
        {
            string sayfa = "KONAKLAMA";
            Konaklama gorev = konaklamaManager.Get(isakisno);
            int benzersizid = gorev.Id;
            string islem = "KONAKLAMA TALEBİ ONAYLANDI.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateWordKonaklama()
        {
            if (adSoyad == "")
            {
                MessageBox.Show("Lütfen Öncelikle Bir Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            //object filePath = "C:\\Users\\MAYıldırım\\Desktop\\Formlar\\DTS_Otel Rezervasyon Talep Formu.docx"; // taslak yolu
            object filePath = dosyaKonaklama + isakisno + ".docx";
            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;

            wBookmarks["Onay"].Range.Text = "DTS Modülünde Konaklama Talebi Onaylandı.";
            wBookmarks["Onay"].Range.Font.Color = WdColor.wdColorRed;
            wBookmarks["OnayTarihi"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy H/mm/ss");

            wDoc.SaveAs2(dosyaKonaklama + isakisno + ".docx");
            wDoc.Close();
            wApp.Quit(false);
        }
    }
}
