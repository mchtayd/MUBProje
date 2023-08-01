using Business.Concreate.Depo;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity.Depo;
using Entity.Gecic_Kabul_Ambar;
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

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmDepoHareketleriEdit : Form
    {
        StokGirisCikisManager stokGirisCikisManager;
        PersonelKayitManager personelKayitManager;
        MalzemeManager malzemeManager;
        DepoKayitManagercs depoKayitManagercs;
        DepoKayitLokasyonManager depoKayitLokasyonManager;

        List<Malzeme> malzemes = new List<Malzeme>();
        public int id = 0;
        bool start = true;
        int secilenId = 0;
        public object[] infos;
        string talepEdenPersonel = "";

        public FrmDepoHareketleriEdit()
        {
            InitializeComponent();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
            personelKayitManager = PersonelKayitManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
            depoKayitManagercs = DepoKayitManagercs.GetInstance();
            depoKayitLokasyonManager = DepoKayitLokasyonManager.GetInstance();
        }

        private void FrmDepoHareketleriEdit_Load(object sender, EventArgs e)
        {
            CmbStokNoSokulen();
            CmbDepoCekilen();
            CmbDepoDusulen();
            start = false;
            DataDisplay();
        }

        void DataDisplay()
        {
            StokGirisCıkıs stokGirisCikis = stokGirisCikisManager.GetId(id);
            if (stokGirisCikis!=null)
            {
                LblIslemTuru.Text = stokGirisCikis.Islemturu;
                CmbSokulenStokNo.Text = stokGirisCikis.Stokno;
                CmbSokulenBirim.Text = stokGirisCikis.Birim;
                DtgTarih.Value = stokGirisCikis.IslemTarihi;
                CmbDepoNoCekilen.Text = stokGirisCikis.CekilenDepoNo;
                TxtMalzemeYeriCekilen.Text = stokGirisCikis.CekilenMalzemeYeri;
                CmbDepoNoDusulen.Text = stokGirisCikis.DusulenDepoNo;
                CmbMalzemeYeriDusulen.Text = stokGirisCikis.DusulenMalzemeYeri;
                TxtMiktar.Text = stokGirisCikis.DusulenMiktar.ToString();
                TxtAciklama.Text = stokGirisCikis.Aciklama;
                TxtSeriNo.Text = stokGirisCikis.Serino;
                TxtLotNo.Text = stokGirisCikis.Lotno;
                TxtRevizyon.Text = stokGirisCikis.Revizyon;
                talepEdenPersonel = stokGirisCikis.TalepEdenPersonel;
            }
        }
        void CmbStokNoSokulen()
        {
            malzemes = malzemeManager.GetList();
            CmbSokulenStokNo.DataSource = malzemes;
            CmbSokulenStokNo.ValueMember = "Id";
            CmbSokulenStokNo.DisplayMember = "StokNo";
            CmbSokulenStokNo.SelectedValue = 0;
        }

        void CmbDepoCekilen()
        {
            CmbDepoNoCekilen.DataSource = depoKayitManagercs.GetList();
            CmbDepoNoCekilen.ValueMember = "Id";
            CmbDepoNoCekilen.DisplayMember = "Depo";
            CmbDepoNoCekilen.SelectedValue = 0;
        }

        void CmbDepoDusulen()
        {
            CmbDepoNoDusulen.DataSource = depoKayitManagercs.GetList();
            CmbDepoNoDusulen.ValueMember = "Id";
            CmbDepoNoDusulen.DisplayMember = "Depo";
            CmbDepoNoDusulen.SelectedValue = 0;
        }

        private void CmbSokulenStokNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }

            Malzeme malzemeKayit = malzemeManager.Get(CmbSokulenStokNo.Text);
            if (malzemeKayit == null)
            {
                TxtSokulenTanim.Text = "";
                return;
            }
            TxtSokulenTanim.Text = malzemeKayit.Tanim;
        }

        private void CmbSokulenStokNo_TextChanged(object sender, EventArgs e)
        {
            if (CmbSokulenStokNo.Text == "")
            {
                TxtSokulenTanim.Clear();
            }
            else
            {
                foreach (Malzeme item in malzemes)
                {
                    if (CmbSokulenStokNo.Text == item.StokNo)
                    {
                        TxtSokulenTanim.Text = item.Tanim;
                    }
                }
            }
        }

        private void CmbDepoNoCekilen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            secilenId = CmbDepoNoCekilen.SelectedValue.ConInt();
            DepoKayit depoKayit = depoKayitManagercs.Get(secilenId);
            CmbAdres.Text = depoKayit.DepoAdi;

            TxtMalzemeYeriCekilen.DataSource = depoKayitLokasyonManager.GetListLokasyon(secilenId);
            TxtMalzemeYeriCekilen.ValueMember = "Id";
            TxtMalzemeYeriCekilen.DisplayMember = "Lokasyon";
            TxtMalzemeYeriCekilen.SelectedValue = "";
        }

        private void CmbDepoNoDusulen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            secilenId = CmbDepoNoDusulen.SelectedValue.ConInt();
            DepoKayit depoKayit = depoKayitManagercs.Get(secilenId);
            TxtAdresDusulen.Text = depoKayit.DepoAdi;

            CmbMalzemeYeriDusulen.DataSource = depoKayitLokasyonManager.GetListLokasyon(secilenId);
            CmbMalzemeYeriDusulen.ValueMember = "Id";
            CmbMalzemeYeriDusulen.DisplayMember = "Lokasyon";
            CmbMalzemeYeriDusulen.SelectedValue = "";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri güncellemek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs(LblIslemTuru.Text, CmbSokulenStokNo.Text, TxtSokulenTanim.Text, CmbSokulenBirim.Text, DtgTarih.Value, CmbDepoNoCekilen.Text, CmbAdres.Text, TxtMalzemeYeriCekilen.Text, CmbDepoNoDusulen.Text, TxtAdresDusulen.Text, CmbMalzemeYeriDusulen.Text, TxtMiktar.Text.ConInt(), talepEdenPersonel, TxtAciklama.Text, TxtSeriNo.Text, TxtLotNo.Text, TxtRevizyon.Text);

                string mesaj = stokGirisCikisManager.Update(stokGirisCıkıs, id);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FrmDepoHareketleri frmDepoHareketleri = (FrmDepoHareketleri)Application.OpenForms["FrmDepoHareketleri"];
                frmDepoHareketleri.DataDisplay();

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri silmek istediğinize emin misiniz?\nBu işlem geri alınamaz", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = stokGirisCikisManager.DeleteId(id);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FrmDepoHareketleri frmDepoHareketleri = (FrmDepoHareketleri)Application.OpenForms["FrmDepoHareketleri"];
                frmDepoHareketleri.DataDisplay();

                MessageBox.Show("Bilgiler başarıyla silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }

        }
    }
}
