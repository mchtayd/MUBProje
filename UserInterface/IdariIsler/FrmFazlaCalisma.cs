using Business.Concreate;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Drawing;
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
    public partial class FrmFazlaCalisma : Form
    {
        FazlaCalismaManager fazlaCalismaManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        PersonelKayitManager personelKayitManager;
        public object[] infos;
        int kayitId;
        bool start = false;
        public int id = 0;
        string onayDurumu, onayVeren;
        public FrmFazlaCalisma()
        {
            InitializeComponent();
            fazlaCalismaManager = FazlaCalismaManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            personelKayitManager = PersonelKayitManager.GetInstance();
        }

        private void FrmFazlaCalisma_Load(object sender, EventArgs e)
        {
            Personeller();
            if (id!=0)
            {
                DataDisplay();
                BtnKaydet.Text = "  GÜNCELLE";
            }
            else
            {
                LblTarihBas.Text = DateTime.Now.ToString("d");
                LblTarihBit.Text = DateTime.Now.ToString("d");
            }
            
            start = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageFazlaCalisma"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void DataDisplay()
        {
            FazlaCalisma fazlaCalisma = fazlaCalismaManager.Get(id);
            if (fazlaCalisma==null)
            {
                MessageBox.Show("Fazla çalışma kaydına ulaşılamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LblTarihBas.Text = DateTime.Now.ToString("d");
                LblTarihBit.Text = DateTime.Now.ToString("d");
                start = true;
                return;
            }

            CmbTalepEdenPersonel.Text = fazlaCalisma.PersonelAd;
            PersonelKayit personelKayit = personelKayitManager.Get(0, CmbTalepEdenPersonel.Text);
            if (personelKayit!=null)
            {
                LblUnvani.Text = personelKayit.Isunvani;
                LblMasrafYeriNo.Text = personelKayit.Masyerino;
                LblMasrafYeri.Text = personelKayit.Sirketbolum;
            }
            TxtMesaiNedeni.Text = fazlaCalisma.FazlaCalismaNedeni;
            LblTarihBas.Value = fazlaCalisma.MesaiBasTarihi;
            DtSaatBas.Value = fazlaCalisma.MesaiBasTarihi;
            LblTarihBit.Value = fazlaCalisma.MesaiBitTarihi;
            DtSaatBit.Value = fazlaCalisma.MesaiBitTarihi;
            onayDurumu = fazlaCalisma.OnayDurumu;
            onayVeren = fazlaCalisma.OnayVeren;
            SureClick();
        }
        void Personeller()
        {
            List<PersonelKayit> personelKayits = new List<PersonelKayit>();
            personelKayits = personelKayitManager.GetMasrafYeriSorumlusuPer(infos[1].ToString());
            PersonelKayit personelKayit = new PersonelKayit(infos[0].ConInt(), infos[1].ToString(), infos[9].ToString(), infos[4].ToString(), infos[8].ToString(), infos[7].ToString(), infos[10].ToString(), infos[2].ToString(), infos[3].ToString());
            personelKayits.Add(personelKayit);

            CmbTalepEdenPersonel.DataSource = personelKayits;
            CmbTalepEdenPersonel.ValueMember = "Id";
            CmbTalepEdenPersonel.DisplayMember = "Adsoyad";
            CmbTalepEdenPersonel.SelectedValue = -1;

            //CmbTalepEdenPersonel.DataSource = personelKayitManager.GetMasrafYeriSorumlusuPer(LblAdSoyad.Text);
            //CmbTalepEdenPersonel.ValueMember = "Id";
            //CmbTalepEdenPersonel.DisplayMember = "Adsoyad";
            //CmbTalepEdenPersonel.SelectedValue = -1;
        }
        void SureClick()
        {
            LblToplamMesai.Text = "00";
            LblToplamIzin.Text = "00";
            if (LblTarihBas.Value.ToString("d") != LblTarihBit.Value.ToString("d"))
            {

                MessageBox.Show("Lütfen başlangıç ve bitiş tarihlerini aynı giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LblTarihBas.Value = DateTime.Now;
                LblTarihBit.Value = DateTime.Now;
                return;
            }
            DateTime basTarihi = new DateTime(LblTarihBas.Value.Year, LblTarihBas.Value.Month, LblTarihBas.Value.Day, DtSaatBas.Value.Hour, DtSaatBas.Value.Minute, 00);
            DateTime bitTarihi = new DateTime(LblTarihBit.Value.Year, LblTarihBit.Value.Month, LblTarihBit.Value.Day, DtSaatBit.Value.Hour, DtSaatBit.Value.Minute, 00);

            TimeSpan toplamSure = bitTarihi - basTarihi;

            double saat = toplamSure.Hours;
            double dakika = toplamSure.Minutes;
            double toplamIzinSaat = 0;
            double toplamIzinDakika = 0;
            string haftaninGunu = LblTarihBas.Value.ToString("dddd");
            if (haftaninGunu != "Cumartesi")
            {
                if (haftaninGunu != "Pazar")
                {
                    string[] saattt = DtSaatBas.Text.ToString().Split(':');
                    if (saattt[1].ConInt() < 30 && saattt[0].ConInt() == 16)
                    {
                        MessageBox.Show("Hafta içi mesai saatleri 16.30 'a kadar devam etmektedir.\nFazla çalışmanızı 16:30 dan sonra yapabilirsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LblFazlaCalismaTuru.Text = "00";
                        LblDonem.Text = "00";
                        return;
                    }

                    LblFazlaCalismaTuru.Text = "HAFTA İÇİ";
                }
            }
            if (((saat * 60) + dakika) > 150)
            {

                if (haftaninGunu == "Cumartesi" || haftaninGunu == "Pazar")
                {
                    if (((saat * 60) + dakika) > 420)
                    {
                        MessageBox.Show("Hafta sonu mesainiz 7 saatten fazla olamaz!\nBu sebepten en fazla çalışabileceğiniz fazla çalışmanız\n7 Saattir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LblFazlaCalismaTuru.Text = "00";
                        LblDonem.Text = "00";
                        return;
                    }
                    LblFazlaCalismaTuru.Text = "HAFTA SONU";
                    //if (DtSaatBas.Text.ConInt()<9)
                    //{
                    //    MessageBox.Show("Hafta sonu mesainiz sabah 09:00 da başlamak zorundadır!\nBu sebepten lütfen haftasonu mesainizin başlangıç saatini 09:00 dan erken bir saat yapmayınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                }
                else
                {
                    MessageBox.Show("Hafta içi mesainiz 11 saatten fazla olamaz!\nBu sebepten en fazla çalışabileceğiniz fazla çalışmanız\n2 Saat 30 Dakikadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LblFazlaCalismaTuru.Text = "00";
                    LblDonem.Text = "00";
                    return;
                }

            }

            if (saat < 0)
            {
                MessageBox.Show("Lütfen mesai yapacağınız saat aralığını doğru seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LblFazlaCalismaTuru.Text = "00";
                LblDonem.Text = "00";
                return;
            }
            if (dakika < 0)
            {
                MessageBox.Show("Lütfen mesai yapacağınız saat aralığını doğru seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LblFazlaCalismaTuru.Text = "00";
                LblDonem.Text = "00";
                return;
            }
            if (saat != 0)
            {
                if (dakika != 0)
                {
                    LblToplamMesai.Text = saat.ToString() + " Saat " + dakika.ToString() + " Dakika";
                    toplamIzinDakika = dakika * 1.5;
                    toplamIzinSaat = saat * 1.5;
                    toplamIzinDakika += (toplamIzinSaat * 60);
                    toplamIzinSaat = toplamIzinDakika / 60;

                    string[] saatSonuc = toplamIzinSaat.ToString().Split(',');

                    toplamIzinDakika = toplamIzinDakika % 60;
                    LblToplamIzin.Text = saatSonuc[0] + " Saat " + toplamIzinDakika + " Dakika";

                }
                else
                {
                    LblToplamMesai.Text = saat.ToString() + " Saat";
                    LblToplamIzin.Text = (saat * 1.5).ToString() + " Saat";
                }

                LblDonem.Text = LblTarihBas.Value.ConPeriod();

            }
            else
            {
                if (dakika != 0)
                {
                    LblToplamMesai.Text = dakika.ToString() + " Dakika";
                    toplamIzinDakika = dakika * 1.5;
                    if (toplamIzinDakika >= 60)
                    {
                        toplamIzinSaat = toplamIzinDakika / 60;
                        string[] saatSonuc = toplamIzinSaat.ToString().Split(',');

                        toplamIzinDakika = toplamIzinDakika % 60;
                        if (toplamIzinDakika == 0)
                        {
                            LblToplamIzin.Text = saatSonuc[0] + " Saat";
                        }
                        else
                        {
                            LblToplamIzin.Text = saatSonuc[0] + " Saat " + toplamIzinDakika + " Dakika";
                        }

                    }
                    else
                    {
                        LblToplamIzin.Text = toplamIzinDakika + " Dakika";
                    }

                    LblDonem.Text = LblTarihBas.Value.ConPeriod();
                }
                else
                {
                    MessageBox.Show("Lütfen mesai yapacağınız saat aralığını doğru seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LblFazlaCalismaTuru.Text = "00";
                    LblDonem.Text = "00";
                }
            }
        }

        private void BtnSureHesapla_Click(object sender, EventArgs e)
        {
            SureClick();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtMesaiNedeni.Text=="")
            {
                MessageBox.Show("Lütfen Fazla Çalışma Nedeni bilgisini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (LblToplamMesai.Text=="00" || LblToplamIzin.Text=="00")
            {
                MessageBox.Show("Lütfen fazla çalışmanızın hesaplanması için mesai sürenizi belirttikten sonra Süre Hesapla butonuna tıklayınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (id!=0)
            {
                DialogResult dr = MessageBox.Show("Bilgileri güncellemek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DateTime basTarihi = new DateTime(LblTarihBas.Value.Year, LblTarihBas.Value.Month, LblTarihBas.Value.Day, DtSaatBas.Value.Hour, DtSaatBas.Value.Minute, 00);
                    DateTime bitTarihi = new DateTime(LblTarihBit.Value.Year, LblTarihBit.Value.Month, LblTarihBit.Value.Day, DtSaatBit.Value.Hour, DtSaatBit.Value.Minute, 00);

                    FazlaCalisma fazlaCalisma = new FazlaCalisma(id,CmbTalepEdenPersonel.Text, LblMasrafYeri.Text, TxtMesaiNedeni.Text, basTarihi, bitTarihi, LblToplamMesai.Text, LblToplamIzin.Text, onayDurumu,onayVeren, LblDonem.Text, LblFazlaCalismaTuru.Text);
                    string mesaj = fazlaCalismaManager.Update(fazlaCalisma);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Bilgiler başarıyla güncellenmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmFazlaCalismalarim frmFazlaCalismalarim = (FrmFazlaCalismalarim)Application.OpenForms["FrmFazlaCalismalarim"];
                    if (frmFazlaCalismalarim!=null)
                    {
                        frmFazlaCalismalarim.DataDisplay();
                    }
                    FrmFazlaCalismaIzleme frmFazlaCalismaIzleme = (FrmFazlaCalismaIzleme)Application.OpenForms["FrmFazlaCalismaIzleme"];
                    if (frmFazlaCalismaIzleme!=null)
                    {
                        frmFazlaCalismaIzleme.DataDisplay();
                    }
                    TxtMesaiNedeni.Clear();
                    LblTarihBas.Value = DateTime.Now;
                    LblTarihBit.Value = DateTime.Now;
                    DtSaatBas.Text = "00:00";
                    DtSaatBit.Text = "00:00";
                    LblToplamMesai.Text = "00";
                    LblToplamIzin.Text = "00";
                    LblFazlaCalismaTuru.Text = "00";
                    LblDonem.Text = "00";
                    this.Close();
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DateTime basTarihi = new DateTime(LblTarihBas.Value.Year, LblTarihBas.Value.Month, LblTarihBas.Value.Day, DtSaatBas.Value.Hour, DtSaatBas.Value.Minute, 00);
                    DateTime bitTarihi = new DateTime(LblTarihBit.Value.Year, LblTarihBit.Value.Month, LblTarihBit.Value.Day, DtSaatBit.Value.Hour, DtSaatBit.Value.Minute, 00);

                    FazlaCalisma fazlaCalisma = new FazlaCalisma(CmbTalepEdenPersonel.Text, LblMasrafYeri.Text, TxtMesaiNedeni.Text, basTarihi, bitTarihi, LblToplamMesai.Text, LblToplamIzin.Text, LblDonem.Text, LblFazlaCalismaTuru.Text);
                    string mesaj = fazlaCalismaManager.Add(fazlaCalisma);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    FazlaCalisma fazlaCalisma1 = fazlaCalismaManager.GetSon(infos[1].ToString());
                    kayitId = fazlaCalisma1.Id;
                    if (fazlaCalisma1 != null)
                    {
                        GorevAtama();
                    }

                    MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtMesaiNedeni.Clear();

                    LblTarihBas.Value = DateTime.Now;
                    LblTarihBit.Value = DateTime.Now;
                    DtSaatBas.Text = "00:00";
                    DtSaatBit.Text = "00:00";
                    LblToplamMesai.Text = "00";
                    LblToplamIzin.Text = "00";
                    LblFazlaCalismaTuru.Text = "00";
                    LblDonem.Text = "00";
                }
            }
            
        }

        string GorevAtama()
        {
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(kayitId, "FAZLA ÇALIŞMA", "RESUL GÜNEŞ", "FAZLA ÇALIŞMA ONAYI", DateTime.Now, "", DateTime.Now.Date);
            string kontrol = gorevAtamaPersonelManager.Add(gorevAtamaPersonel);

            if (kontrol != "OK")
            {
                return kontrol;
            }
            return "OK";
        }

        private void CmbTalepEdenPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start==false)
            {
                LblUnvani.Text = "00";
                LblMasrafYeriNo.Text = "00";
                LblMasrafYeri.Text = "00";
                return;
            }
            if (CmbTalepEdenPersonel.Text=="")
            {
                LblUnvani.Text = "00";
                LblMasrafYeriNo.Text = "00";
                LblMasrafYeri.Text = "00";
                return;
            }
            if (CmbTalepEdenPersonel.SelectedIndex==-1)
            {
                LblUnvani.Text = "00";
                LblMasrafYeriNo.Text = "00";
                LblMasrafYeri.Text = "00";
                return;
            }
            PersonelKayit personelKayit = personelKayitManager.Get(0, CmbTalepEdenPersonel.Text);
            if (personelKayit==null)
            {
                MessageBox.Show("Personel bilgilerine ulaşılamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LblUnvani.Text = personelKayit.Isunvani;
            LblMasrafYeriNo.Text = personelKayit.Masyerino;
            LblMasrafYeri.Text = personelKayit.Sirketbolum;

        }
    }
}
