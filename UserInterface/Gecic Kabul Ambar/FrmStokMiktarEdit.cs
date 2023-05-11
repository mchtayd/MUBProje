using Business.Concreate.Depo;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using Entity;
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
        List<StokGirisCıkıs> stoks;
        public int id, ilkMiktar = 0, malzemeId = 0;
        bool start = false;
        public object[] infos;
        public FrmStokMiktarEdit()
        {
            InitializeComponent();
            depoMiktarManager = DepoMiktarManager.GetInstance();
            depoKayitManagercs = DepoKayitManagercs.GetInstance();
            depoKayitLokasyonManager = DepoKayitLokasyonManager.GetInstance();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
        }

        private void FrmStokMiktarEdit_Load(object sender, EventArgs e)
        {
            malzemeId = id;
            CmbDepo();
            start = true;
            DatDisplay();
            StokGirisCikis();
        }
        void DatDisplay()
        {
            DepoMiktar depoMiktar = depoMiktarManager.GetEdit(id);
            LblStokNo.Text=depoMiktar.StokNo;
            LblTanim.Text = depoMiktar.Tanim;
            ilkMiktar = depoMiktar.Miktar;
            TxtMiktar.Text = ilkMiktar.ToString();
            CmbDepoNo.Text = depoMiktar.DepoNo;
            CmbAdres.Text = depoMiktar.DepoAdresi;
            TxtMalzemeYeri.Text = depoMiktar.DepoLokasyon;
            LblSeriNo.Text = depoMiktar.SeriNo;
            LblLotNo.Text = depoMiktar.LotNo;
            LblRev.Text = depoMiktar.Revizyon;
        }
        void StokGirisCikis()
        {
            stoks = new List<StokGirisCıkıs>();
            stoks = stokGirisCikisManager.GetListEdit(LblStokNo.Text, LblSeriNo.Text, LblLotNo.Text);
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
                DepoMiktar depoCekilen = new DepoMiktar(LblStokNo.Text, CmbDepoNo.Text, TxtMalzemeYeri.Text, LblSeriNo.Text, LblLotNo.Text, LblRev.Text, DateTime.Now, infos[1].ToString(), TxtMiktar.Text.ConInt());
                string mesaj = depoMiktarManager.Update(depoCekilen, depoCekilen.RezerveDurumu);

                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs(malzemeId, LblStokNo.Text, DateTime.Now, CmbDepoNo.Text, CmbAdres.Text, TxtMalzemeYeri.Text, TxtMiktar.Text.ConInt(),"DÜŞÜM BİLGİLERİ GÜNCELLENDİ.", LblSeriNo.Text, LblLotNo.Text, LblRev.Text);
                mesaj = stokGirisCikisManager.UpdateEdit(stokGirisCıkıs);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler başarıyla güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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
                string mesaj = depoMiktarManager.Delete(id);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                mesaj = stokGirisCikisManager.Delete(LblStokNo.Text, LblSeriNo.Text, LblLotNo.Text);
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
