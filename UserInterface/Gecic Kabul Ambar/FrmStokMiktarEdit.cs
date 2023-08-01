using Business.Concreate.BakimOnarim;
using Business.Concreate.Depo;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarim;
using Entity.Depo;
using Entity.Gecic_Kabul_Ambar;
using Entity.IdariIsler;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmStokMiktarEdit : Form
    {
        DepoMiktarManager depoMiktarManager;
        StokGirisCikisManager stokGirisCikisManager;
        DepoKayitManagercs depoKayitManagercs;
        DepoKayitLokasyonManager depoKayitLokasyonManager;
        ArizaKayitManager arizaKayitManager;
        MalzemeManager malzemeManager;
        List<StokGirisCıkıs> stoks;
        List<Malzeme> malzemes = new List<Malzeme>();
        public int id, ilkMiktar = 0, malzemeId = 0;
        bool start = false;
        public object[] infos;
        string rezerveDurum = "";

        public FrmStokMiktarEdit()
        {
            InitializeComponent();
            depoMiktarManager = DepoMiktarManager.GetInstance();
            depoKayitManagercs = DepoKayitManagercs.GetInstance();
            depoKayitLokasyonManager = DepoKayitLokasyonManager.GetInstance();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
        }

        private void FrmStokMiktarEdit_Load(object sender, EventArgs e)
        {
            malzemeId = id;
            CmbDepo();
            CmbStokNoSokulen();
            start = true;
            DatDisplay();
            //StokGirisCikis();
        }
        void DatDisplay()
        {
            DepoMiktar depoMiktar = depoMiktarManager.GetEdit(id);
            CmbStokNo.Text=depoMiktar.StokNo;
            ilkMiktar = depoMiktar.Miktar;
            TxtMiktar.Text = ilkMiktar.ToString();
            CmbDepoNo.Text = depoMiktar.DepoNo;
            CmbAdres.Text = depoMiktar.DepoAdresi;
            TxtMalzemeYeri.Text = depoMiktar.DepoLokasyon;
            TxtSeriNo.Text = depoMiktar.SeriNo;
            TxtLotNo.Text = depoMiktar.LotNo;
            TxtRev.Text = depoMiktar.Revizyon;
            DtgTarih.Value = depoMiktar.SonIslemTarihi;
            TxtAciklama.Text = depoMiktar.Aciklama;
            CmbRezerveDurum.Text = depoMiktar.RezerveDurumu;
            if (CmbRezerveDurum.Text == "REZERVE")
            {
                ArizaKayit arizaKayit = arizaKayitManager.GetId(depoMiktar.RezerveId);
                LblAbf.Visible = true;
                TxtAbf.Visible = true;
                if (arizaKayit!=null)
                {
                    TxtAbf.Text = arizaKayit.AbfFormNo.ToString();
                }
            }

            else { 
                LblAbf.Visible = false;
                TxtAbf.Visible = false;
                TxtAbf.Clear();
            }


        }
        public void CmbDepo()
        {
            CmbDepoNo.DataSource = depoKayitManagercs.GetList();
            CmbDepoNo.ValueMember = "Id";
            CmbDepoNo.DisplayMember = "Depo";
            CmbDepoNo.SelectedValue = 0;
        }

        private void CmbDepoNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            id = CmbDepoNo.SelectedValue.ConInt();
            DepoKayit depoKayit = depoKayitManagercs.Get(id);
            CmbAdres.Text = depoKayit.Aciklama;

            TxtMalzemeYeri.DataSource = depoKayitLokasyonManager.GetListLokasyon(id);
            TxtMalzemeYeri.ValueMember = "Id";
            TxtMalzemeYeri.DisplayMember = "Lokasyon";
            TxtMalzemeYeri.SelectedValue = "";
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tüm Bilgileri güncellemek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                DepoMiktar depoCekilen = new DepoMiktar(malzemeId, CmbStokNo.Text, TxtSokulenTanim.Text, TxtSeriNo.Text, TxtLotNo.Text, TxtRev.Text, DtgTarih.Value, infos[1].ToString(), CmbDepoNo.Text, CmbAdres.Text, TxtMalzemeYeri.Text, TxtMiktar.Text.ConInt(), TxtAciklama.Text, CmbRezerveDurum.Text, TxtAbf.Text.ConInt());
                string mesaj = depoMiktarManager.UpdateDepoStok(depoCekilen);

                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler başarıyla güncellenmiştir.\nBilgilerin yenilenmesi için sayfayı yenileyiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void CmbRezerveDurum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void CmbStokNoSokulen()
        {
            malzemes = malzemeManager.GetList();
            CmbStokNo.DataSource = malzemes;
            CmbStokNo.ValueMember = "Id";
            CmbStokNo.DisplayMember = "StokNo";
            CmbStokNo.SelectedValue = 0;
        }

        private void CmbStokNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }

            Malzeme malzemeKayit = malzemeManager.Get(CmbStokNo.Text);
            if (malzemeKayit == null)
            {
                TxtSokulenTanim.Text = "";
                return;
            }
            TxtSokulenTanim.Text = malzemeKayit.Tanim;
        }

        private void CmbStokNo_TextChanged(object sender, EventArgs e)
        {
            if (CmbStokNo.Text == "")
            {
                TxtSokulenTanim.Clear();
            }
            else
            {
                foreach (Malzeme item in malzemes)
                {
                    if (CmbStokNo.Text == item.StokNo)
                    {
                        TxtSokulenTanim.Text = item.Tanim;
                    }
                }
            }
        }

        private void TxtMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tüm Bilgileri silmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                string mesaj = depoMiktarManager.Delete(malzemeId);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler başarıyla silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
