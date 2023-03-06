using Business;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity.IdariIsler;
using System;
using System.Windows.Forms;

namespace UserInterface.IdariIsler
{
    public partial class FrmAracBakimSAT : Form
    {
        StokManager stokManager;
        ComboManager comboManager;
        string gerekce = "", butcekodu = "", tanim = "", stokno = "", birim = "", donem = "";
        int miktar;
        public FrmAracBakimSAT()
        {
            InitializeComponent();
            stokManager = StokManager.GetInstance();
            comboManager = ComboManager.GetInstance();
        }

        private void FrmAracBakimSAT_Load(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (CmbButceKoduGun.Text == "")
            {
                MessageBox.Show("Lütfen BÜTÇE KODU/TANIMI Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbTanim.Text == "")
            {
                MessageBox.Show("Lütfen TANIM Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtStokNo.Text == "")
            {
                MessageBox.Show("Lütfen TANIM Bilgisini Girerek Tüm Bilgileri Eksiksiz Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbDonemAy.Text == "" || CmbDonemYil.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Dönem Bilgisini Eksiksiz Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtSatAciklama.Text == "")
            {
                MessageBox.Show("Lütfen AÇIKLAMA Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            gerekce = TxtSatAciklama.Text;
            butcekodu = CmbButceKoduGun.Text;
            tanim = CmbTanim.Text;
            stokno = TxtStokNo.Text;
            miktar = TxtMiktar.Text.ConInt();
            birim = TxtBirim.Text;
            donem = CmbDonemAy.Text + " "+ CmbDonemYil.Text;

            Properties.Settings.Default.Gerekce = gerekce;
            Properties.Settings.Default.AracBakimSatButceKodu = butcekodu;
            Properties.Settings.Default.AracBakimSatTanim = tanim;
            Properties.Settings.Default.AracBakimSatStokNo = stokno;
            Properties.Settings.Default.AracBakimSatMiktar = miktar;
            Properties.Settings.Default.AracBakimSatBirim = birim;
            Properties.Settings.Default.YurtIciGorevDonem = donem;

            Properties.Settings.Default.Save();
            this.Close();
        }

        private void CmbTanim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbTanim.Text=="")
            {
                return;
            }
            Stok stok = stokManager.Get(CmbTanim.Text);
            TxtStokNo.Text = stok.Stokno;
            TxtBirim.Text = stok.Birim;

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            CmbButceKoduGun.SelectedValue = ""; CmbTanim.SelectedValue = ""; TxtStokNo.Clear(); TxtMiktar.Clear(); TxtBirim.Clear(); TxtSatAciklama.Clear(); CmbDonemAy.SelectedValue = ""; CmbDonemYil.SelectedValue = "";
        }
    }
}
