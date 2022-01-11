using Business.Concreate.Depo;
using DataAccess.Concreate;
using Entity.Depo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UserInterface.Depo;

namespace UserInterface.BakımOnarım
{
    public partial class FrmDepoLokasyonKayit : Form
    {
        DepoKayitManagercs depoKayitManagercs;
        DepoKayitLokasyonManager depoKayitLokasyonManager;
        List<DepoKayit> depoKayits;
        List<DepoKayitLokasyon> depoKayitLokasyons;
        string depo;
        int depoId;
        public FrmDepoLokasyonKayit()
        {
            InitializeComponent();
            depoKayitManagercs = DepoKayitManagercs.GetInstance();
            depoKayitLokasyonManager = DepoKayitLokasyonManager.GetInstance();
        }

        private void FrmDepoLokasyonKayit_Load(object sender, EventArgs e)
        {
            DataDisplayDepolar();
        }
        void DataDisplayDepolar()
        {
            depoKayits = depoKayitManagercs.GetList();
            DtgDepolar.DataSource = depoKayits;
            TxtTop.Text = DtgDepolar.RowCount.ToString();

            DtgDepolar.Columns["Id"].Visible = false;
            DtgDepolar.Columns["Depo"].HeaderText = "DEPO";
            DtgDepolar.Columns["Aciklama"].HeaderText = "AÇIKLAMA";

        }

        private void DtgDepolar_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgDepolar.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            depoId = DtgDepolar.CurrentRow.Cells["Id"].Value.ConInt();
            depo = DtgDepolar.CurrentRow.Cells["Depo"].Value.ToString();
            DataDisplyaLokasyonlar();
        }
        void DataDisplyaLokasyonlar()
        {
            depoKayitLokasyons = depoKayitManagercs.GetListLokasyon(depoId);
            DtgLokasyonlar.DataSource = depoKayitLokasyons;
            TxtTop2.Text = DtgLokasyonlar.RowCount.ToString();

            DtgLokasyonlar.Columns["Id"].Visible = false;
            DtgLokasyonlar.Columns["DepoId"].Visible = false;
            DtgLokasyonlar.Columns["Lokasyon"].HeaderText = "LOKASYON";
            DtgLokasyonlar.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
        }

        private void BtnDepoEkle_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstediğinize Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                DepoKayit depoKayit = new DepoKayit(TxtDepo.Text, TxtDepoAciklama.Text);
                string mesaj = depoKayitManagercs.Add(depoKayit);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Temizle();
                DataDisplayDepolar();
                Yenile();

            }
        }
        void Yenile()
        {

            FrmBolgeler frmBolgeler = new FrmBolgeler();
            frmBolgeler.ComboDepo();

            FrmStokGirisCikis frmStokGiris = new FrmStokGirisCikis();
            frmStokGiris.CmbDepo();
            frmStokGiris.CmbDepoCekilen();
            frmStokGiris.CmbDepoDusulen();
            frmStokGiris.CmbDepodanBildirime();
            frmStokGiris.CmbBildirimdenDepoya();


        }
        void Temizle()
        {
            TxtDepo.Clear(); TxtDepoAciklama.Clear(); TxtLokasyon.Clear(); TxtLokasyonAcıklama.Clear();
        }

        private void BtnLokasyonEkle_Click(object sender, EventArgs e)
        {
            if (depoId == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Geçerli Bir Depo Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(depo + " Nolu Depoya "+ TxtLokasyon.Text + " Adlı Lokasyon Bilgisini Eklemek İstediğinize Emin Msiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {

                DepoKayitLokasyon depoKayitLokasyon = new DepoKayitLokasyon(depoId, TxtLokasyon.Text, TxtLokasyonAcıklama.Text);
                string mesaj = depoKayitLokasyonManager.Add(depoKayitLokasyon);

                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                DataDisplayDepolar();
                DtgLokasyonlar.DataSource = null;
                Temizle();
            }
        }
    }
}
