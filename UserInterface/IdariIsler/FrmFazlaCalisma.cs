using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2010.Excel;
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
        public object[] infos;
        public FrmFazlaCalisma()
        {
            InitializeComponent();
            fazlaCalismaManager = FazlaCalismaManager.GetInstance();
        }

        private void FrmFazlaCalisma_Load(object sender, EventArgs e)
        {
            Personel();
            LblTarihBas.Text = DateTime.Now.ToString("d");
            LblTarihBit.Text = DateTime.Now.ToString("d");
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
        void Personel()
        {
            LblAdSoyad.Text = infos[1].ToString();
            LblUnvani.Text = infos[10].ToString();
            LblMasrafYeriNo.Text = infos[4].ToString();
            LblMasrafYeri.Text = infos[2].ToString();
        }

        private void BtnSureHesapla_Click(object sender, EventArgs e)
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
            if (((saat * 60) + dakika) > 150)
            {
                string haftaninGunu = LblTarihBas.Value.ToString("dddd");
                if (haftaninGunu == "Cumartesi" || haftaninGunu == "Pazar")
                {
                    if (((saat * 60) + dakika) > 420)
                    {
                        MessageBox.Show("Hafta sonu mesainiz 7 saatten fazla olamaz!\nBu sebepten en fazla çalışabileceğiniz fazla çalışmanız\n7 Saattir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Hafta içi mesainiz 11 saatten fazla olamaz!\nBu sebepten en fazla çalışabileceğiniz fazla çalışmanız\n2 Saat 30 Dakikadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }

            if (saat<0)
            {
                MessageBox.Show("Lütfen mesai yapacağınız saat aralığını doğru seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dakika<0)
            {
                MessageBox.Show("Lütfen mesai yapacağınız saat aralığını doğru seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (saat!=0)
            {
                if (dakika!=0)
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
            }
            else
            {
                if (dakika!=0)
                {
                    LblToplamMesai.Text = dakika.ToString() + " Dakika";
                    toplamIzinDakika = dakika * 1.5;
                    if (toplamIzinDakika >= 60)
                    {
                        toplamIzinSaat = toplamIzinDakika / 60;
                        string[] saatSonuc = toplamIzinSaat.ToString().Split(',');

                        toplamIzinDakika = toplamIzinDakika % 60;
                        if (toplamIzinDakika==0)
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

                }
                else
                {
                    MessageBox.Show("Lütfen mesai yapacağınız saat aralığını doğru seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dr == DialogResult.Yes)
            {
                DateTime basTarihi = new DateTime(LblTarihBas.Value.Year, LblTarihBas.Value.Month, LblTarihBas.Value.Day, DtSaatBas.Value.Hour, DtSaatBas.Value.Minute, 00);
                DateTime bitTarihi = new DateTime(LblTarihBit.Value.Year, LblTarihBit.Value.Month, LblTarihBit.Value.Day, DtSaatBit.Value.Hour, DtSaatBit.Value.Minute, 00);

                FazlaCalisma fazlaCalisma = new FazlaCalisma(LblAdSoyad.Text, LblMasrafYeri.Text, TxtMesaiNedeni.Text, basTarihi, bitTarihi, LblToplamMesai.Text, LblToplamIzin.Text);
                string mesaj = fazlaCalismaManager.Add(fazlaCalisma);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtMesaiNedeni.Clear();

                LblTarihBas.Value = DateTime.Now;
                LblTarihBit.Value = DateTime.Now;
                DtSaatBas.Text = "00:00";
                DtSaatBit.Text = "00:00";
                LblToplamMesai.Text = "00";
                LblToplamIzin.Text = "00";
            }

        }
    }
}
