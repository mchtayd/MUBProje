using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity.IdariIsler;
using Entity.STS;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;
using Application = Microsoft.Office.Interop.Word.Application;
using Task = System.Threading.Tasks.Task;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmOnayEkranlari : Form
    {
        List<UcakOtobus> ucakotobus;
        List<Konaklama> konaklamas;
        List<SehiriciGorev> sehiriciGorevs;
        UcakOtobusManager ucakOtobusManager;
        KonaklamaManager konaklamaManager;
        SehiriciGorevManager sehiriciGorevManager;
        UstAmirManager ustAmirManager;
        IdariIslerLogManager logManager;
        List<UstAmirMail> ustAmirMails;
        public object[] infos;
        int onayidUcakOtobus, onayidKonaklama, onayidPersonel, isakisno, id, onayamirid, isakisnoamir, ucakOtobusIsAkisNo;
        string islemadimi, personeladsoyad, amirmail, islemadimiamir, onaydurum, formno, pageText1, pageText2, pageText3;
        public FrmOnayEkranlari()
        {
            InitializeComponent();
            ucakOtobusManager = UcakOtobusManager.GetInstance();
            konaklamaManager = KonaklamaManager.GetInstance();
            sehiriciGorevManager = SehiriciGorevManager.GetInstance();
            ustAmirManager = UstAmirManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
        }

        private void FrmOnayEkranlari_Load(object sender, EventArgs e)
        {
            UcakOtobus();
            Konaklama();
            SehirIciGorevAmir();
            SehirIciGorevPersonel();

            pageText1 = "UÇAK/OTOBÜS " + "( " + TxtTop.Text + " )";
            pageText2 = "KONAKLAMA " + "( " + TxtTopKonaklama.Text + " )";
            pageText3 = "ŞEHİR İÇİ GÖREV " + "( " + "0" + " )";
            if (TxtTopPersonel.Text != "0")
            {
                pageText3 = "ŞEHİR İÇİ GÖREV" + "( " + TxtTopPersonel.Text + " )";
            }
            if (TxtTopAmir.Text != "0")
            {
                pageText3 = "ŞEHİR İÇİ GÖREV" + "( " + TxtTopAmir.Text + " )";
            }
            tabPage1.Text = pageText1;
            tabPage2.Text = pageText2;
            tabPage3.Text = pageText3;
        }
        void Yenile()
        {
            UcakOtobus();
            Konaklama();
            SehirIciGorevAmir();
            SehirIciGorevPersonel();

            pageText1 = "UÇAK/OTOBÜS " + "( " + TxtTop.Text + " )";
            pageText2 = "KONAKLAMA " + "( " + TxtTopKonaklama.Text + " )";
            pageText3 = "ŞEHİR İÇİ GÖREV " + "( " + "0" + " )";
            if (TxtTopPersonel.Text != "0")
            {
                pageText3 = "ŞEHİR İÇİ GÖREV" + "( " + TxtTopPersonel.Text + " )";
            }
            if (TxtTopAmir.Text != "0")
            {
                pageText3 = "ŞEHİR İÇİ GÖREV" + "( " + TxtTopAmir.Text + " )";
            }
            tabPage1.Text = pageText1;
            tabPage2.Text = pageText2;
            tabPage3.Text = pageText3;
        }
        void UcakOtobus()
        {
            ucakotobus = ucakOtobusManager.OnayList("ONAY AŞAMASINDA");
            dataBinder1.DataSource = ucakotobus.ToDataTable();
            DtgList.DataSource = dataBinder1;
            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Talepturu"].HeaderText = "TALEP TÜRÜ";
            DtgList.Columns["Gorevformno"].HeaderText = "GÖREV FORM NO";
            DtgList.Columns["Izinformno"].HeaderText = "İZİN FORM NO";
            DtgList.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgList.Columns["Masrafyerino"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["Masrafyeri"].HeaderText = "BÖLÜMÜ";
            DtgList.Columns["Gorevi"].HeaderText = "GÖREVİ";
            DtgList.Columns["Tc"].HeaderText = "TC KİMLİK NO";
            DtgList.Columns["Hes"].HeaderText = "HES KODU";
            DtgList.Columns["Email"].HeaderText = "E-MAIL";
            DtgList.Columns["Kisakod"].HeaderText = "ŞİRKET NO/KISA KOD";
            DtgList.Columns["Biletturu"].HeaderText = "BİLET TÜRÜ";
            DtgList.Columns["Gidisfirma"].HeaderText = "GİDİŞ FİRMA İSMİ";
            DtgList.Columns["Gidistarihi"].HeaderText = "GİRİŞ TARİHİ/SAATİ";
            DtgList.Columns["Gidisnereden"].HeaderText = "GİDİŞ NEREDEN";
            DtgList.Columns["Gidisnereye"].HeaderText = "GİDİŞ NEREYE";
            DtgList.Columns["Donusfirma"].HeaderText = "DÖNÜŞ FİRMA İSMİ";
            DtgList.Columns["Donustarihi"].HeaderText = "DÖNÜŞ TARİHİ";
            DtgList.Columns["Donusnereden"].HeaderText = "DÖNÜŞ NEREDEN";
            DtgList.Columns["Donusnereye"].HeaderText = "DÖNÜŞ NEREYE";
            DtgList.Columns["Butcekodu"].HeaderText = "BÜTÇE KODU/KALEMİ";
            DtgList.Columns["ToplamMaliyet"].HeaderText = "TOPLAM MALİYET";
            DtgList.Columns["Islemadimi"].Visible = false;
            DtgList.Columns["Dosyayolu"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;

            TxtTop.Text = DtgList.RowCount.ToString();
        }
        void Konaklama()
        {
            konaklamas = konaklamaManager.OnayList("ONAYLANMADI");
            dataBinder2.DataSource = konaklamas.ToDataTable();
            DtgKonaklama.DataSource = dataBinder2;
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
        void SehirIciGorevAmir()
        {
            sehiriciGorevs = sehiriciGorevManager.AmirOnay(infos[0].ConInt(), "2.ADIM:GÖREV PERSONEL TARAFINDAN ONAYLANDI.");
            dataBinder3.DataSource = sehiriciGorevs.ToDataTable();
            DtgSehirIciAmir.DataSource = dataBinder3;
            DtgSehirIciAmir.Columns["Id"].Visible = false;
            DtgSehirIciAmir.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgSehirIciAmir.Columns["Proje"].HeaderText = "PROJE";
            DtgSehirIciAmir.Columns["Gidilecekyer"].HeaderText = "GİDİLECEK YER";
            DtgSehirIciAmir.Columns["Gorevinkonusu"].HeaderText = "GÖREVİN KONUSU";
            DtgSehirIciAmir.Columns["Baslamatarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgSehirIciAmir.Columns["Bitistarihi"].Visible = false;
            DtgSehirIciAmir.Columns["Toplamsure"].Visible = false;
            DtgSehirIciAmir.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgSehirIciAmir.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgSehirIciAmir.Columns["Masrafyerno"].HeaderText = "MASRAF YERİ NO";
            DtgSehirIciAmir.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ";
            DtgSehirIciAmir.Columns["Islemadimi"].HeaderText = "İŞLEM ADIMI";
            DtgSehirIciAmir.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgSehirIciAmir.Columns["Personelid"].Visible = false;
            DtgSehirIciAmir.Columns["Sayfa"].Visible = false;
            DtgSehirIciAmir.Columns["Gecensure"].Visible = false;
            TxtTopAmir.Text = DtgSehirIciAmir.RowCount.ToString();
        }
        void SehirIciGorevPersonel()
        {
            sehiriciGorevs = sehiriciGorevManager.PersonelOnay(infos[0].ConInt(), "1.ADIM: GÖREV OLUŞTURULDU.");
            dataBinder4.DataSource = sehiriciGorevs.ToDataTable();
            DtgSehirIciPersonel.DataSource = dataBinder4;
            DtgSehirIciPersonel.Columns["Id"].Visible = false;
            DtgSehirIciPersonel.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgSehirIciPersonel.Columns["Proje"].HeaderText = "PROJE";
            DtgSehirIciPersonel.Columns["Gidilecekyer"].HeaderText = "GİDİLECEK YER";
            DtgSehirIciPersonel.Columns["Gorevinkonusu"].HeaderText = "GÖREVİN KONUSU";
            DtgSehirIciPersonel.Columns["Baslamatarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgSehirIciPersonel.Columns["Bitistarihi"].Visible = false;
            DtgSehirIciPersonel.Columns["Toplamsure"].Visible = false;
            DtgSehirIciPersonel.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgSehirIciPersonel.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgSehirIciPersonel.Columns["Masrafyerno"].HeaderText = "MASRAF YERİ NO";
            DtgSehirIciPersonel.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ";
            DtgSehirIciPersonel.Columns["Islemadimi"].HeaderText = "İŞLEM ADIMI";
            DtgSehirIciPersonel.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgSehirIciPersonel.Columns["Personelid"].Visible = false;
            DtgSehirIciPersonel.Columns["Gecensure"].Visible = false;
            DtgSehirIciPersonel.Columns["Sayfa"].Visible = false;
            TxtTopPersonel.Text = DtgSehirIciPersonel.RowCount.ToString();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageOnayEkranlari"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void BtnPersonelOnay_Click(object sender, EventArgs e)
        {
            if (onayidPersonel == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Görev Kaydı Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (islemadimi != "1.ADIM: GÖREV OLUŞTURULDU.")
            {
                MessageBox.Show(isakisno + " Nolu Kayıt Zaten Tarafınızca Onaylanmıştır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Görevi Onaylamak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string sehiricigorev = "2.ADIM:GÖREV PERSONEL TARAFINDAN ONAYLANDI.";
                SehiriciGorev sehiriciGorev = new SehiriciGorev(sehiricigorev);
                sehiriciGorevManager.GorevOnay(sehiriciGorev, onayidPersonel);
                MessageBox.Show("İşlem Başarıyla Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UstAmirMail();

                Task.Factory.StartNew(() => MailSendMetotPersonelOnay());
                Task.Factory.StartNew(() => MailSendMetotAmir());

                SehirIciGorevPersonel();
                CreateLogPersonelOnay();
                Yenile();
            }
        }
        void CreateLogPersonelOnay()
        {
            string sayfa = "ŞEHİR İÇİ GÖREV";
            SehiriciGorev gorev = sehiriciGorevManager.Get(isakisno);
            int benzersizid = gorev.Id;
            string islem = "ŞEHİR İÇİ GÖREV PERSONEL TARAFINDAN ONAYLANDI.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void UstAmirMail()
        {
            UstAmirMail ustAmirMail = ustAmirManager.Get(personeladsoyad);
            id = ustAmirMail.Personelid;
            ustAmirMails = ustAmirManager.GetList(id);
            if (ustAmirMails.Count > 0)
            {
                amirmail = ustAmirMails[0].Oficemail; // HATA YOK
            }
        }

        private void BtnPersonelRed_Click(object sender, EventArgs e)
        {
            if (onayidPersonel == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Görev Kaydı Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(isakisno + " Nolu Görevi Reddetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string sehiricigorev = "GÖREV " + infos[1].ToString() + " TARAFINDAN REDDEDİLDİ";
                SehiriciGorev sehiriciGorev = new SehiriciGorev(isakisno, DateTime.Now, "0 Saat");
                sehiriciGorevManager.GorevTamamla(sehiriciGorev, isakisno);
                SehiriciGorev sehirici = new SehiriciGorev(sehiricigorev);
                sehiriciGorevManager.GorevOnay(sehirici, onayidPersonel);
                MessageBox.Show("İşlem Başarıyla Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Task.Factory.StartNew(() => MailSendMetotRet());
                SehirIciGorevPersonel();
                CreateLogPersonelRed();
                Yenile();
            }
        }
        void CreateLogPersonelRed()
        {
            string sayfa = "ŞEHİR İÇİ GÖREV";
            SehiriciGorev gorev = sehiriciGorevManager.Get(isakisno);
            int benzersizid = gorev.Id;
            string islem = "ŞEHİR İÇİ GÖREV PERSONEL TARAFINDAN REDDEDİLDİ.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }

        private void DtgSehirIciPersonel_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgSehirIciPersonel.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            onayidPersonel = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            islemadimi = DtgList.CurrentRow.Cells["Islemadimi"].Value.ToString();
            isakisno = DtgList.CurrentRow.Cells["Isakisno"].Value.ConInt();
            personeladsoyad = DtgList.CurrentRow.Cells["Adsoyad"].Value.ToString();
        }

        private void BtnAmirOnay_Click(object sender, EventArgs e)
        {
            if (onayamirid == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Görev Kaydı Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Görevi Onaylamak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string sehiricigorev = "3.ADIM:GÖREV AMİR TARAFINDAN ONAYLANDI";
                SehiriciGorev sehiriciGorev = new SehiriciGorev(sehiricigorev);
                sehiriciGorevManager.GorevOnay(sehiriciGorev, onayamirid);
                MessageBox.Show("İşlem Başarıyla Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Task.Factory.StartNew(() => MailSendMetotOnay());
                CreateLogAmirOnay();
                SehirIciGorevAmir();
                Yenile();
            }
        }

        private void BtnAmirRed_Click(object sender, EventArgs e)
        {
            if (onayamirid == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Görev Kaydı Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(isakisnoamir + " Nolu Görevi Reddetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string sehiricigorev = "GÖREV " + infos[1].ToString() + " TARAFINDAN REDDEDİLDİ";
                SehiriciGorev sehiriciGorev = new SehiriciGorev(isakisnoamir, DateTime.Now, "0 Saat");
                sehiriciGorevManager.GorevTamamla(sehiriciGorev, isakisnoamir);
                SehiriciGorev sehirici = new SehiriciGorev(sehiricigorev);
                sehiriciGorevManager.GorevOnay(sehirici, onayamirid);
                MessageBox.Show("İşlem Başarıyla Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SehirIciGorevAmir();
                CreateLogAmirRed();
                Task.Factory.StartNew(() => MailSendMetotRetAmir());
                Yenile();
            }
        }
        void CreateLogAmirRed()
        {
            string sayfa = "ŞEHİR İÇİ GÖREV";
            SehiriciGorev gorev = sehiriciGorevManager.Get(isakisnoamir);
            int benzersizid = gorev.Id;
            string islem = "ŞEHİR İÇİ GÖREV AMİR TARAFINDAN REDDEDİLDİ.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogAmirOnay()
        {
            string sayfa = "ŞEHİR İÇİ GÖREV";
            SehiriciGorev gorev = sehiriciGorevManager.Get(isakisnoamir);
            int benzersizid = gorev.Id;
            string islem = "ŞEHİR İÇİ GÖREV AMİR TARAFINDAN ONAYLANDI.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }

        private void BtnKonaklamaOnay_Click(object sender, EventArgs e)
        {
            if (onayidKonaklama == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Konaklama Bilgisi Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(formno + " Nolu Konaklama Talebini Onaylamak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Konaklama konaklama = new Konaklama("ONAYLANDI");
                string mesaj = konaklamaManager.OnayGuncelle(konaklama, onayidKonaklama);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLogOnaylama();
                CreateWordKonaklama();
                MessageBox.Show("Onaylama İşlemi Başarıyla Gerçekleşmştir.");
                Yenile();
            }
        }


        private void BtnKonaklamaRed_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(formno + " Nolu Konaklama Talebini Reddetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Konaklama konaklama = new Konaklama("REDDEDİLDİ");
                string mesaj = konaklamaManager.OnayGuncelle(konaklama, onayidKonaklama);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Reddetme İşlemi Başarıyla Gerçekleşmştir.");
                Yenile();
            }
        }
        string dosyaKonaklama, talepturu, butceKodu, siparisNo, adSoyad, gorevi, masrafYeriNo, masrafYeri, tc, hes, email, kisakod, otelSehir, otelAd, konaklamaSuresi, unvani;

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder1.Sort = DtgList.SortString;
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder1.Filter = DtgList.FilterString;
            TxtTopKonaklama.Text = DtgList.RowCount.ToString();
        }

        private void DtgKonaklama_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Sort = DtgKonaklama.SortString;
        }

        private void DtgKonaklama_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Filter = DtgKonaklama.FilterString;
            TxtTopKonaklama.Text = DtgKonaklama.RowCount.ToString();
        }

        private async void BtnTumunuOnaylaUcakOtobus_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (DtgList.RowCount <= 0)
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

                    foreach (DataGridViewRow item in DtgList.Rows)
                    {
                        DtgList.Invoke((MethodInvoker)(() => ucakOtobusIsAkisNo = item.Cells["Isakisno"].Value.ConInt()));
                        DtgList.Invoke((MethodInvoker)(() => dosyaUcak = item.Cells["Dosyayolu"].Value.ToString()));
                        DtgList.Invoke((MethodInvoker)(() => onayidUcakOtobus = item.Cells["Id"].Value.ConInt()));

                        string onay = "ONAYLANDI";
                        UcakOtobus ucakOtobus = new UcakOtobus(onay);

                        string mesaj = ucakOtobusManager.OnayGuncelle(ucakOtobus, onayidUcakOtobus);
                        //string mesaj = "OK";
                        if (mesaj != "OK")
                        {
                            MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        CreateLogOnaylamaTopluUcak();
                        CreateWordUcakToplu();

                        DtgList.Invoke((MethodInvoker)(() => item.DefaultCellStyle.BackColor = Color.LightGreen));
                    }
                    FrmWait.isActive = false;
                    if (System.Windows.Forms.Application.OpenForms.OfType<FrmWait>().Count() == 1)
                    {
                        frmWait.Invoke((MethodInvoker)(() => frmWait.Close()));
                    }

                    frmAnasayfa.Invoke((MethodInvoker)(() => frmAnasayfa.Enabled = true));
                }
            });
            Yenile();
        }
        int konaklamaIsAkisNo;
        private async void BtnTumunuOnaylaKonaklama_Click(object sender, EventArgs e)
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
                        DtgKonaklama.Invoke((MethodInvoker)(() => konaklamaIsAkisNo = item.Cells["Isakisno"].Value.ConInt()));
                        DtgKonaklama.Invoke((MethodInvoker)(() => dosyaKonaklama = item.Cells["Dosyayolu"].Value.ToString()));
                        DtgKonaklama.Invoke((MethodInvoker)(() => onayidKonaklama = item.Cells["Id"].Value.ConInt()));

                        Konaklama konaklama = new Konaklama("ONAYLANDI");
                        string mesaj = konaklamaManager.OnayGuncelle(konaklama, onayidKonaklama);
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
            Yenile();
        }

        double gunlukUcret, toplamUcret;
        DateTime gidisTarihi, cikisTarihi;
        void CreateLogOnaylamaToplu()
        {
            string sayfa = "KONAKLAMA";
            Konaklama gorev = konaklamaManager.Get(konaklamaIsAkisNo);
            int benzersizid = gorev.Id;
            string islem = "KONAKLAMA TALEBİ ONAYLANDI.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogOnaylamaTopluUcak()
        {
            string sayfa = "UÇAK OTOBÜS";
            UcakOtobus gorev = ucakOtobusManager.Get(ucakOtobusIsAkisNo);
            int benzersizid = gorev.Id;
            string islem = "BİLET TALEBİ ONAYLANDI.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
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
            object filePath = dosyaUcak + ucakOtobusIsAkisNo + ".docx";
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

            wDoc.SaveAs2(dosyaUcak + ucakOtobusIsAkisNo + ".docx");
            //wDoc.SaveAs2(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\DD\\" + konaklamaIsAkisNo + ".docx");
            wDoc.Close();
            wApp.Quit(false);
        }
        void CreateWordUcakToplu()
        {
            if (adSoyad == "")
            {
                MessageBox.Show("Lütfen Öncelikle Bir Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            //object filePath = "C:\\Users\\MAYıldırım\\Desktop\\Formlar\\DTS_Otel Rezervasyon Talep Formu.docx"; // taslak yolu
            object filePath = dosyaKonaklama + konaklamaIsAkisNo + ".docx";
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

            wDoc.SaveAs2(dosyaKonaklama + konaklamaIsAkisNo + ".docx");
            //wDoc.SaveAs2(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\DD\\" + konaklamaIsAkisNo + ".docx");
            wDoc.Close();
            wApp.Quit(false);
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
        void CreateWordUcakOtobus()
        {
            if (biletturu == "UÇAK BİLETİ")
            {
                Application wApp = new Application();
                Documents wDocs = wApp.Documents;
                //object filePath = "C:\\Users\\MAYıldırım\\Desktop\\WordTaslak\\DTS_Uçak Bileti Talep Formu.docx"; // taslak yolu
                object filePath = dosyaUcak + isakisno + ".docx";
                if (!File.Exists(filePath.ToString()))
                    return;

                Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
                wDoc.Activate();
                Bookmarks wBookmarks = wDoc.Bookmarks;
                //wBookmarks["BiletTuru"].Range.Text = "Uçak";

                wBookmarks["Onay"].Range.Text = "DTS Modülünde Bilet Talebi Onaylandı.";
                wBookmarks["OnayTarihi"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy H/mm/ss");



                wDoc.SaveAs2(dosyaUcak + isakisno + ".docx");
                wDoc.Close();
                wApp.Quit(false);


            }
            if (biletturu == "OTOBÜS BİLETİ")
            {
                Application wApp = new Application();
                Documents wDocs = wApp.Documents;
                //object filePath = "C:\\Users\\MAYıldırım\\Desktop\\Formlar\\DTS_Otobüs Bileti Talep Formu.docx"; // taslak yolu
                object filePath = dosyaUcak + isakisno + ".docx";
                Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
                wDoc.Activate();

                Bookmarks wBookmarks = wDoc.Bookmarks;
                //wBookmarks["BiletTuru"].Range.Text = "Otobüs";
                wBookmarks["Onay"].Range.Text = "DTS Modülünde Bilet Talebi Onaylandı.";
                wBookmarks["OnayTarihi"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy H/mm/ss");

                wDoc.SaveAs2(dosyaUcak + isakisno + ".docx");
                wDoc.Close();
                wApp.Quit(false);
            }
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            if (onayidUcakOtobus == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Bilet Talebi Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilet Talebini Onaylamak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string onay = "ONAYLANDI";
                UcakOtobus ucakOtobus = new UcakOtobus(onay);
                string mesaj = ucakOtobusManager.OnayGuncelle(ucakOtobus, onayidUcakOtobus);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLogOnay();
                CreateWordUcakOtobus();
                System.Threading.Tasks.Task.Factory.StartNew(() => MailSendMetotOnay());
                MessageBox.Show(isakisno + " Nolu Bilet Talebi Başarıyla Onaylanmıştır.");
                Yenile();
            }
        }
        void CreateLogOnay()
        {
            string sayfa = "UÇAK OTOBÜS";
            UcakOtobus gorev = ucakOtobusManager.Get(isakisno);
            int benzersizid = gorev.Id;
            string islem = "BİLET TALEBİ ONAYLANDI.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        string biletturu, dosyaUcak;
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            onayidUcakOtobus = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            islemadimi = DtgList.CurrentRow.Cells["Islemadimi"].Value.ToString();
            isakisno = DtgList.CurrentRow.Cells["Isakisno"].Value.ConInt();
            biletturu = DtgList.CurrentRow.Cells["Biletturu"].Value.ToString();
            dosyaUcak = DtgList.CurrentRow.Cells["Dosyayolu"].Value.ToString();
        }

        private void BtnReddet_Click(object sender, EventArgs e)
        {
            if (onayidUcakOtobus == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Görev Kaydı Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(isakisno + " Nolu Görevi Reddetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string onay = "REDDEDİLDİ";
                UcakOtobus ucakOtobus = new UcakOtobus(onay);
                string mesaj = ucakOtobusManager.OnayGuncelle(ucakOtobus, onayidUcakOtobus);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(isakisno + "Nolu Bilet Talebi Reddedilmiştir.");
                CreateLogRed();
                System.Threading.Tasks.Task.Factory.StartNew(() => MailSendMetotRed());
                Yenile();
            }
        }
        void CreateLogRed()
        {
            string sayfa = "UÇAK OTOBÜS";
            UcakOtobus gorev = ucakOtobusManager.Get(isakisno);
            int benzersizid = gorev.Id;
            string islem = "BİLET KAYDI REDDEDİLDİ.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
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

        private void DtgKonaklama_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgKonaklama.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            onayidKonaklama = DtgKonaklama.CurrentRow.Cells["Id"].Value.ConInt();

            talepturu = DtgKonaklama.CurrentRow.Cells["Talepturu"].Value.ToString();
            butceKodu = DtgKonaklama.CurrentRow.Cells["Butcekodu"].Value.ToString();
            siparisNo = DtgKonaklama.CurrentRow.Cells["Siparisno"].Value.ToString();
            adSoyad = DtgKonaklama.CurrentRow.Cells["Adsoyad"].Value.ToString();
            gorevi = DtgKonaklama.CurrentRow.Cells["Gorevi"].Value.ToString();
            masrafYeriNo = DtgKonaklama.CurrentRow.Cells["Masrafyerino"].Value.ToString();
            masrafYeri = DtgKonaklama.CurrentRow.Cells["Masrafyeri"].Value.ToString();
            tc = DtgKonaklama.CurrentRow.Cells["Tc"].Value.ToString();
            hes = DtgKonaklama.CurrentRow.Cells["Hes"].Value.ToString();
            email = DtgKonaklama.CurrentRow.Cells["Email"].Value.ToString();
            kisakod = DtgKonaklama.CurrentRow.Cells["Kisakod"].Value.ToString();
            otelSehir = DtgKonaklama.CurrentRow.Cells["Otelsehir"].Value.ToString();
            otelAd = DtgKonaklama.CurrentRow.Cells["Otelad"].Value.ToString();
            gunlukUcret = DtgKonaklama.CurrentRow.Cells["Gunukucret"].Value.ConDouble();
            toplamUcret = DtgKonaklama.CurrentRow.Cells["Toplamucret"].Value.ConDouble();
            gidisTarihi = DtgKonaklama.CurrentRow.Cells["Giristarihi"].Value.ConDate();
            cikisTarihi = DtgKonaklama.CurrentRow.Cells["Cikistarihi"].Value.ConDate();
            konaklamaSuresi = DtgKonaklama.CurrentRow.Cells["Konaklamasuresi"].Value.ToString();
            unvani = DtgKonaklama.CurrentRow.Cells["Gorevi"].Value.ToString();

            //onaydurum = DtgList.CurrentRow.Cells["Onay"].Value.ToString();
            formno = DtgKonaklama.CurrentRow.Cells["Formno"].Value.ToString();
            isakisno = DtgKonaklama.CurrentRow.Cells["Isakisno"].Value.ConInt();
            dosyaKonaklama = DtgKonaklama.CurrentRow.Cells["Dosyayolu"].Value.ToString();
        }

        private void DtgSehirIciAmir_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgSehirIciAmir.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            onayamirid = DtgSehirIciAmir.CurrentRow.Cells["Id"].Value.ConInt();
            islemadimiamir = DtgSehirIciAmir.CurrentRow.Cells["Islemadimi"].Value.ToString();
            isakisnoamir = DtgSehirIciAmir.CurrentRow.Cells["Isakisno"].Value.ConInt();
        }

        void MailSendMetotPersonelOnay()
        {
            MailSend("ŞEHİR İÇİ GÖREV", "Merhaba; \n\n" + isakisno + " İş Akış Numaralı Görev, Başarıyla Onaylanmıştır." + "\n\nİyi Çalışmalar.", new List<string>() { infos[7].ToString() });
        }
        void MailSendMetotAmir()
        {
            MailSend("ŞEHİR İÇİ GÖREV", "Merhaba; \n\n" + isakisno + " İş Akış Numaralı Görev, Onayınıza Sunulmuştur." + "\n\nİyi Çalışmalar.", new List<string>() { amirmail });
        }
        void MailSendMetotRet()
        {
            MailSend("ŞEHİR İÇİ GÖREV", "Merhaba; \n\n" + isakisno + " İş Akış Numaralı Görev Reddedilmiştir." + "\n\nİyi Çalışmalar.", new List<string>() { infos[7].ToString() });
        }
        void MailSendMetotOnay()
        {
            MailSend("ŞEHİR İÇİ GÖREV", "Merhaba; \n\n" + isakisnoamir + " İş Akış Numaralı Görev Başarıyla Onaylanmıştır." + "\n\nİyi Çalışmalar.", new List<string>() { infos[7].ToString() });
        }
        void MailSendMetotRetAmir()
        {
            MailSend("ŞEHİR İÇİ GÖREV", "Merhaba; \n\n" + isakisnoamir + " İş Akış Numaralı Görev Reddedilmiştir." + "\n\nİyi Çalışmalar.", new List<string>() { infos[7].ToString() });
        }
        void MailSendMetotRed()
        {
            MailSend("UÇAK OTOBÜS BİLETİ ONAY", "Merhaba; \n\n" + isakisno + " İş Akış Nolu Otobüs Bileti Talebi Reddedilmiştir.\n\nİyi Çalışmalar.",
                new List<string>() { "emelayhan@mubvan.net" });
        }
        public void MailSend(string subject, string body, List<string> receivers, List<string> attachments = null)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                //client.Host = "smtp.gmail.com";
                client.Host = "192.168.23.10";
                //client.Host = "smtp-mail.outlook.com ";
                client.EnableSsl = false;
                client.Timeout = 11000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //client.Credentials = new System.Net.NetworkCredential("mubotomasyon@gmail.com", "MCHT44aa:");
                client.Credentials = new System.Net.NetworkCredential("dts@mubvan.net", "123456");
                //client.Credentials = new System.Net.NetworkCredential("mucahitaydemir@basaranteknoloji.net", "Aydemir_123");
                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                mailMessage.From = new MailAddress("dts@mubvan.net", "DTS Bilgilendirme");
                mailMessage.SubjectEncoding = Encoding.UTF8;
                mailMessage.Subject = subject; //E-posta Konu Kısmı
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.Body = body; // E-posta'nın Gövde Metni
                foreach (string item in receivers)
                {
                    mailMessage.To.Add(item);
                }
                mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                if (attachments != null)
                {
                    if (attachments.Count > 0)
                    {
                        foreach (string filePath in attachments)
                        {
                            if (File.Exists(filePath))
                            {
                                Attachment attachment = new Attachment(filePath);
                                mailMessage.Attachments.Add(attachment);
                            }
                        }
                    }
                }
                client.Send(mailMessage);
            }
            catch (Exception)
            {
                //  MessageBox.Show(ex.Message);
            }

        }
    }
}
