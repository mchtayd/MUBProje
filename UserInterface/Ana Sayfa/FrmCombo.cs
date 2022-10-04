using Business;
using DataAccess.Concreate;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.BakımOnarım;
using UserInterface.Butce;
using UserInterface.Gecic_Kabul_Ambar;
using UserInterface.IdariIşler;
using UserInterface.IdariIsler;
using UserInterface.Yerleskeler;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmCombo : Form
    {
        ComboManager comboBoxManager;
        public string comboAd;
        string baslik;
        int id;
        public FrmCombo()
        {
            InitializeComponent();
            comboBoxManager = ComboManager.GetInstance();
        }

        private void FrmCombo_Load(object sender, EventArgs e)
        {
            IcerikCek();
        }
        void IcerikCek()
        {
            DtgIcerik.DataSource = comboBoxManager.GetList(comboAd);
            DtgIcerik.Columns["Id"].Visible = false;
            DtgIcerik.Columns["Baslik"].HeaderText = "İÇERİKLER";
            DtgIcerik.Columns["Sayfa"].Visible = false;
            DtgIcerik.Columns["ComboAd"].Visible = false;
            TxtTop.Text = DtgIcerik.RowCount.ToString();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (TxtBaslik.Text == "")
            {
                MessageBox.Show("Lütfen Eklemek İstediğiniz İçerik Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(TxtBaslik.Text + " İçeriğini Eklemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in DtgIcerik.Rows)
                {
                    if (item.Cells["Baslik"].Value.ToString() == TxtBaslik.Text)
                    {
                        MessageBox.Show("Aynı İçerik Zaten Mevcut İkinci Kez Ekleyemezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                Combo combo = new Combo(TxtBaslik.Text, comboAd, "PERSONEL_KAYIT");
                string mesaj = comboBoxManager.Add(combo);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                IcerikCek();
                TxtBaslik.Clear();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz İçeriği Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(baslik + " İçeriğini Silmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = comboBoxManager.Delete(id);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                IcerikCek();
                TxtBaslik.Clear();
            }
        }
        private void DtgIcerik_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgIcerik.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            id = DtgIcerik.CurrentRow.Cells["Id"].Value.ConInt();
            baslik = DtgIcerik.CurrentRow.Cells["Baslik"].Value.ToString();
            TxtBaslik.Text = baslik;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen Güncellemek İstediğiniz İçeriği Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(baslik + " İçeriğini Güncellemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Combo combo = new Combo(TxtBaslik.Text);
                string mesaj = comboBoxManager.Update(combo, id);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                IcerikCek();
                TxtBaslik.Clear();
            }
        }

        private void BtnTumunuSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tüm İçeriği Silmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = comboBoxManager.TumunuSil(comboAd);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                IcerikCek();
                TxtBaslik.Clear();
            }
        }

        private void FrmCombo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comboAd== "SİPARİŞLER PROJE")
            {
                var form = (FrmSiparisler)Application.OpenForms["FrmSiparisler"];
                if (form != null)
                {
                    form.ComboProje();
                }
            }
            if (comboAd == "SİPARİŞLER SAT")
            {
                var form = (FrmSiparisler)Application.OpenForms["FrmSiparisler"];
                if (form != null)
                {
                    form.ComboSat();
                }
            }
            if (comboAd == "SİPARİŞLER SAT KATEGORİ")
            {
                var form = (FrmSiparisler)Application.OpenForms["FrmSiparisler"];
                if (form != null)
                {
                    form.ComboSatKategori();
                }
            }
            if (comboAd == "MÜLKİYET BİLGİLERİ")
            {
                var form = (FrmAracKaydet)Application.OpenForms["FrmAracKaydet"];
                if (form != null)
                {
                    form.mulkiket = true;
                    form.ComboMulkiyetBilgileri();
                    form.mulkiket = false;
                }
            }
            if (comboAd == "BAKIM ONARIM YAPAN FİRMA")
            {
                var form = (FrmAracBakimKayit)Application.OpenForms["FrmAracBakimKayit"];
                if (form != null)
                {
                    form.ComboFirma();
                }
            }
            if (comboAd == "DOSYA_TURU")
            {
                var form = (FrmArsiv)Application.OpenForms["FrmArsiv"];
                if (form != null)
                {
                    form.DosyaTuru();
                }
            }
            if (comboAd == "SİSTEM CİHAZ")
            {
                var form = (FrmArsiv)Application.OpenForms["FrmArsiv"];
                if (form != null)
                {
                    form.SistemCihaz();
                }
            }
            if (comboAd == "FİRMA")
            {
                var form = (FrmYakitDokum)Application.OpenForms["FrmYakitDokum"];
                if (form != null)
                {
                    form.Firma();
                    form.FirmaTasit();
                }
            }
            if (comboAd == "FİRMA TAŞIT TANIMA")
            {
                var form = (FrmYakitDokum)Application.OpenForms["FrmYakitDokum"];
                if (form != null)
                {
                    form.Firma();
                    form.FirmaTasit();
                }
            }
            if (comboAd == "PROJE")
            {
                var form = (FrmBolgeler)Application.OpenForms["FrmBolgeler"];
                if (form != null)
                {
                    form.ComboProje();
                }
            }
            if (comboAd == "BİRİM")
            {
                var form = (FrmMalzemeKayit)Application.OpenForms["FrmMalzemeKayit"];
                if (form != null)
                {
                    form.Birim();
                }
            }
            if (comboAd == "ONARIM_YERI")
            {
                var form = (FrmMalzemeKayit)Application.OpenForms["FrmMalzemeKayit"];
                var form2 = (FrmArizaAcmaCalisma)Application.OpenForms["FrmArizaAcmaCalisma"];

                if (form != null)
                {
                    form.OnarimYeri();

                }
                if (form2 != null)
                {
                    form2.Yenilenecekler();
                }
            }
            if (comboAd == "MALZEME_TURU")
            {
                var form = (FrmMalzemeKayit)Application.OpenForms["FrmMalzemeKayit"];
                if (form != null)
                {
                    form.MalzemeTuru();
                }
            }
            if (comboAd == "ABONE_TURU")
            {
                var form = (FrmYerleskeKayit)Application.OpenForms["FrmYerleskeKayit"];
                if (form != null)
                {
                    form.AbonelikTuru();
                }
            }
            if (comboAd == "ABF KATEGORİ")
            {
                var form = (FrmArizaAcmaCalisma)Application.OpenForms["FrmArizaAcmaCalisma"];
                if (form != null)
                {
                    form.Yenilenecekler();
                }
            }
            if (comboAd == "ABF KATEGORİ")
            {
                var form = (FrmBOAtolye)Application.OpenForms["FrmBOAtolye"];
                if (form != null)
                {
                    form.Kategori();
                }
            }
            if (comboAd == "BILDIRIM TURU")
            {
                var form = (FrmArizaAcmaCalisma)Application.OpenForms["FrmArizaAcmaCalisma"];
                if (form != null)
                {
                    form.BildirimTuru();
                }
            }
            if (comboAd == "TEDARIK_TURU")
            {
                var form = (FrmMalzemeKayit)Application.OpenForms["FrmMalzemeKayit"];
                if (form != null)
                {
                    form.TedarikTuru();
                }
            }
            if (comboAd == "NESNE_TANIMI")
            {
                var form = (FrmArizaAcmaCalisma)Application.OpenForms["FrmArizaAcmaCalisma"];
                if (form != null)
                {
                    form.NesneTanimi();
                }
            }
            if (comboAd == "NEDEN_KODU")
            {
                var form = (FrmArizaAcmaCalisma)Application.OpenForms["FrmArizaAcmaCalisma"];
                if (form != null)
                {
                    form.NedenKodu();
                }
            }
            if (comboAd == "HASAR_KODU")
            {
                var form = (FrmArizaAcmaCalisma)Application.OpenForms["FrmArizaAcmaCalisma"];
                if (form != null)
                {
                    form.HasarKodu();
                }
            }
            if (comboAd == "PROJE_KODU")
            {
                var form = (FrmDTFOlustur)Application.OpenForms["FrmDTFOlustur"];
                if (form != null)
                {
                    form.ProjeKodu();
                }
            }
            if (comboAd == "IS_KATEGORISI")
            {
                var form = (FrmDTFOlustur)Application.OpenForms["FrmDTFOlustur"];
                if (form != null)
                {
                    form.IsKategorisi();
                }
            }
            if (comboAd == "ATOLYE KATEGORI")
            {
                var form = (FrmBOAtolye)Application.OpenForms["FrmBOAtolye"];
                if (form != null)
                {
                    form.AtolyeKategoriOto();
                    form.AtolyeKategorManuel();
                }
            }

        }
    }
}
