using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
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
    public partial class FrmAracKm : Form
    {
        AracKmManager aracKmManager;
        AracManager aracManager;
        AracZimmetiManager aracZimmetiManager;
        SiparisPersonelManager siparisPersonelManager;

        int id;
        public FrmAracKm()
        {
            InitializeComponent();
            aracKmManager = AracKmManager.GetInstance();
            aracManager = AracManager.GetInstance();
            aracZimmetiManager = AracZimmetiManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
        }

        private void FrmAracKm_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageAracKm"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void BtnBulT_Click(object sender, EventArgs e)
        {
            if (TxtPlaka.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Plaka Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Arac arac = aracManager.Get(TxtPlaka.Text); // ARAÇ BİLGİLERİ
            //ZimmetAktarim zimmetAktarim = zimmetAktarimManager.AracZimmetBilgileri("%" + TxtPlaka.Text + '%'); // DURAN VARLIK LİSTESİNDEN
            AracZimmeti aracZimmeti = aracZimmetiManager.Get(TxtPlaka.Text); // ARAÇ ZİMMET LİSTESİNDEN
            if (arac == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz Plakaya Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                return;
            }
            Temizle();
            id = arac.Id;
            TxtPlaka.Text = arac.Plaka;
            TxtSiparisNo.Text = arac.Siparisno;
            TxtMulkiyetBilgileri.Text = arac.MulkiyetBilgileri;
            if (aracZimmeti == null)
            {
                TxtAdSoyad.Text = "";
                CmbSiparisNo.Text = "";
                TxtGorevi.Text = "";
                TxtMasrafyeriNo.Text = "";
                TxtMasrafYeri.Text = "";
                TxtMasrafYeriSorumlusu.Text = "";
                TxtMulkiyetBilgileri.Text = "";
            }
            else
            {
                TxtAdSoyad.Text = aracZimmeti.PersonelAd;

                SiparisPersonel siparis = siparisPersonelManager.Get("", TxtAdSoyad.Text);
                TxtMasrafyeriNo.Text = siparis.Masrafyerino;
                TxtMasrafYeri.Text = siparis.Masrafyeri;
                TxtGorevi.Text = siparis.Gorevi;
                CmbSiparisNo.Text = siparis.Siparis;
                TxtMasrafYeriSorumlusu.Text = siparis.MasrafYeriSorumlusu;
            }
            
        }
        void Temizle()
        {
            TxtPlaka.Clear(); TxtSiparisNo.Clear(); CmbDonem.SelectedIndex = -1; CmbDonemYil.SelectedIndex = -1; TxtKm.Clear(); TxtAdSoyad.Clear(); CmbSiparisNo.Clear(); TxtGorevi.Clear(); TxtMasrafyeriNo.Clear(); TxtMasrafYeri.Clear(); TxtMasrafYeriSorumlusu.Clear(); TxtMulkiyetBilgileri.Clear();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TarihBul();
            if (TxtPlaka.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Kayıtlı Bir Plaka Bilgisi Yazınız!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (TxtSiparisNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Kayıtlı Bir Plaka Bilgisi Yazarak Araç Bilgilerini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtAdSoyad.Text == "")
            {
                MessageBox.Show("Lütfen Hiç Bir Personele Zimmetli Değildir. Lütfen Öncelikle Zimmet Bilgilerini Kontrol Ediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbDonem.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Dönem Ay Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbDonemYil.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Dönem Yıl Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            KmFarkBul();
            string donem = CmbDonem.Text + " " + CmbDonemYil.Text;
            AracKm aracKm = new AracKm(TxtPlaka.Text, TxtSiparisNo.Text, DtBaslamaTarihi.Value, donem, TxtKm.Text.ConInt(), TxtAdSoyad.Text, CmbSiparisNo.Text, TxtGorevi.Text, TxtMasrafyeriNo.Text, TxtMasrafYeri.Text, TxtMasrafYeriSorumlusu.Text, TxtMulkiyetBilgileri.Text, aysonu, TxtKm.Text.ConInt(), toplamYapilanKm, sabitKm, fark);

            string mesaj = aracKmManager.Add(aracKm);

            if (mesaj!="OK")
            {
                MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Temizle();

        }
        int bitisKm=0, toplamYapilanKm=0, sabitKm=3500, fark=0, mevcutKm=0;
        DateTime aysonu;

        void TarihBul()
        {
            aysonu = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1);
        }
        void KmFarkBul()
        {
            AracKm aracKm = aracKmManager.Get(TxtPlaka.Text);

            if (aracKm!=null)
            {
                mevcutKm = aracKm.BaslangicKm;
            }
            else
            {
                mevcutKm = 0;
            }

            toplamYapilanKm = TxtKm.Text.ConInt() - mevcutKm;

            fark = toplamYapilanKm - sabitKm;

        }
    }
}
