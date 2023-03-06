using Business;
using Business.Concreate.Butce;
using DataAccess.Concreate;
using Entity;
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
using Application = Microsoft.Office.Interop.Word.Application;

namespace UserInterface.Butce
{
    public partial class FrmIsAvansTalep : Form
    {
        IsAkisNoManager isAkisNoManager;
        IsAvansTalepManager ısAvansTalepManager;


        public object[] infos;
        string isAkisNo, dosyaYolu, taslakYolu = "";
        string yol = @"C:\DTS\Taslak\";
        string kaynak = @"Z:\DTS\SATIN ALMA\Folder\";
        public FrmIsAvansTalep()
        {
            InitializeComponent();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            ısAvansTalepManager = IsAvansTalepManager.GetInstance();
        }

        private void FrmIsAvansTalep_Load(object sender, EventArgs e)
        {
            Personel();
        }
        void Personel()
        {
            LblAdSoyad.Text = infos[1].ToString();
            LblSiparisNo.Text = infos[9].ToString();
            LblUnvani.Text = infos[10].ToString();
            LblMasrafYeriNo.Text = infos[4].ToString();
            LblMasrafYeri.Text = infos[2].ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string mesaj = Control();
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            IsAkisNo();
            DosyaOlustur();
            TaslakKopyala();
            CreateWord();

            Properties.Settings.Default.TalepTarihi = DtTarih.Value.ToString("dd.MM.yyyy");
            Properties.Settings.Default.TalepEdilenTutar = TxtMiktar.Text;
            Properties.Settings.Default.TalepGerekcesi = TxtTalepNedeni.Text;
            Properties.Settings.Default.IsAkisNo = isAkisNo.ConInt();
            Properties.Settings.Default.DosyaYolu = dosyaYolu;


            MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();

        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            isAkisNo = isAkis.Id.ToString();
        }
        string Control()
        {
            if (TxtTalepNedeni.Text == "")
            {
                return "Lütfen Öncelikle Talep Nedeni Bilgisini Doldurunuz!";
            }
            if (TxtMiktar.Text == "")
            {
                return "Lütfen Öncelikle Miktar Bilgisini Doldurunuz!";
            }
            if (TxtAciklamalar.Text == "")
            {
                return "Lütfen Öncelikle Açıklamalar Bilgisini Doldurunuz!";
            }
            return "OK";
        }
        void DosyaOlustur()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\IS AVANS TALEPLERİ\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyaYolu = subdir + isAkisNo;
            Directory.CreateDirectory(dosyaYolu);
        }

        private void TxtMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        void CreateWord()
        {
            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            object filePath = taslakYolu;

            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["AdiSoyadi"].Range.Text = LblAdSoyad.Text;
            wBookmarks["Unvani"].Range.Text = LblUnvani.Text;
            wBookmarks["Bolumu"].Range.Text = LblMasrafYeri.Text;
            wBookmarks["TalepNedeni"].Range.Text = TxtTalepNedeni.Text;
            wBookmarks["TalepEdilenMiktar"].Range.Text = TxtMiktar.Text;
            wBookmarks["TalepTarihi"].Range.Text = DtTarih.Value.ToString("dd/MM/yyyy");
            wBookmarks["Aciklamalar"].Range.Text = TxtAciklamalar.Text;
            wBookmarks["AdSoyad2"].Range.Text = LblAdSoyad.Text;
            wBookmarks["Bolum2"].Range.Text = LblMasrafYeri.Text;

            wDoc.SaveAs2(dosyaYolu + isAkisNo + ".docx");
            wDoc.Close();
            wApp.Quit(false);

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
            var dosyalar = new DirectoryInfo(kaynak).GetFiles("*.docx");

            foreach (FileInfo item in dosyalar)
            {
                item.CopyTo(yol + item.Name);
            }

            taslakYolu = yol + "İŞ AVANS TALEP FORMU.docx";
        }
    }
}
