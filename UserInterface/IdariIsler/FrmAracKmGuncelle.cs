using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Presentation;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.IdariIsler
{
    public partial class FrmAracKmGuncelle : Form
    {
        AracKmManager aracKmManager;
        PersonelKayitManager personelKayitManager;
        CokluAracManager cokluAracManager;
        AracManager aracManager;
        public int id = 0;
        public string siparisNo = "";
        public string plaka = "";
        bool start = false;
        int toplam = 0;
        string donem = "";

        public FrmAracKmGuncelle()
        {
            InitializeComponent();
            aracKmManager = AracKmManager.GetInstance();
            personelKayitManager= PersonelKayitManager.GetInstance();
            cokluAracManager = CokluAracManager.GetInstance();
            aracManager = AracManager.GetInstance();
        }

        private void FrmAracKmGuncelle_Load(object sender, EventArgs e)
        {
            Personeller();
            start = true;
            DataDisplayCokluArac();
            DataDisplay();
        }
        void Personeller()
        {
            TxtAdSoyad.DataSource = personelKayitManager.PersonelAdSoyad();
            TxtAdSoyad.DisplayMember = "Adsoyad";
            TxtAdSoyad.ValueMember = "Id";
            TxtAdSoyad.SelectedIndex = -1;
        }
        void DataDisplay()
        {
            AracKm aracKm = aracKmManager.GetGuncelle(id);
            LblPlaka.Text = plaka;
            Arac arac = aracManager.Get(plaka);
            TxtSiparisNo.Text = arac.Siparisno;
            TxtAdSoyad.Text = aracKm.PersonelAd;
            TxtMulkiyetBilgileri.Text = aracKm.AracMulkiyet;
            string[] donem = aracKm.Donem.Split(' ');
            CmbDonem.Text= donem[0];
            CmbDonemYil.Text = donem[1];
            DtBaslamaTarihi.Value = aracKm.Tarih;
            DtgBitisTarihi.Value = aracKm.KmBitisTarihi;
            TxtKmBaslangic.Text = aracKm.BaslangicKm.ToString();
            TxtKmBitis.Text=aracKm.BitisKm.ToString();
            
        }
        void DataDisplayCokluArac()
        {
            DtgAracList.DataSource = cokluAracManager.GetList(siparisNo);

            DtgAracList.Columns["Id"].Visible = false;
            DtgAracList.Columns["SiparisNo"].Visible = false;
            DtgAracList.Columns["Plaka"].HeaderText = "PLAKA";
            DtgAracList.Columns["BaslangicKm"].HeaderText = "BAŞLANGIÇ KM";
            DtgAracList.Columns["BitisKm"].HeaderText = "BİTİŞ KM";
            DtgAracList.Columns["ToplamKm"].HeaderText = "TOPLAM KM";
            DtgAracList.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            DtgAracList.Columns["BaslangicTarihi"].HeaderText = "BAŞLANGIÇ TARİHİ";
            DtgAracList.Columns["BitisTarihi"].HeaderText = "BİTİŞ TARİHİ";

            Toplamlar();
        }
        void Toplamlar()
        {
            for (int i = 0; i < DtgAracList.Rows.Count; ++i)
            {
                toplam += DtgAracList.Rows[i].Cells[5].Value.ConInt();
            }
            LblToplamKm.Text = toplam.ToString();
        }

        private void TxtAdSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            if (TxtAdSoyad.SelectedIndex == -1)
            {
                return;
            }
            PersonelKayit personelKayit = personelKayitManager.Get(0, TxtAdSoyad.Text);
            if (personelKayit == null)
            {
                return;
            }
            CmbSiparisNo.Text = personelKayit.Siparis;
            TxtGorevi.Text = personelKayit.Isunvani;
            TxtMasrafyeriNo.Text = personelKayit.Masyerino;
            TxtMasrafYeri.Text = personelKayit.Masrafyeri;
            TxtMasrafYeriSorumlusu.Text = personelKayit.MasrafYeriSorumlusu;
        }

        private void TxtKmBitis_TextChanged(object sender, EventArgs e)
        {
            int toplamKm = TxtKmBitis.Text.ConInt() - TxtKmBaslangic.Text.ConInt();
            TxtToplamKm.Text = toplamKm.ToString();
        }

        private void TxtKmBaslangic_TextChanged(object sender, EventArgs e)
        {
            int toplamKm = TxtKmBitis.Text.ConInt() - TxtKmBaslangic.Text.ConInt();
            TxtToplamKm.Text = toplamKm.ToString();
        }

        private void TxtToplamKm_TextChanged(object sender, EventArgs e)
        {
            if (DtgAracList.RowCount==0)
            {
                int fark = TxtToplamKm.Text.ConInt() - LblFark.Text.ConInt();
                TxtFark.Text = fark.ToString();
            }
            else
            {
                int fark = toplam - LblFark.Text.ConInt();
                TxtFark.Text = fark.ToString();
            }
        }


        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtAdSoyad.Text == "")
            {
                MessageBox.Show("Lütfen Personel Bilgisini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri güncellemek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                donem = CmbDonem.Text + " " + CmbDonemYil.Text;
                string mesaj = "";
                if (DtgAracList.RowCount!=0)
                {
                    AracKm aracKm = new AracKm(id, LblPlaka.Text, TxtSiparisNo.Text, DtBaslamaTarihi.Value, donem, TxtKmBaslangic.Text.ConInt(), TxtAdSoyad.Text, CmbSiparisNo.Text, TxtGorevi.Text, TxtMasrafyeriNo.Text, TxtMasrafYeri.Text, TxtMasrafYeriSorumlusu.Text, TxtMulkiyetBilgileri.Text, DtgBitisTarihi.Value, TxtKmBitis.Text.ConInt(), LblToplamKm.Text.ConInt(), LblFark.Text.ConInt(), TxtFark.Text.ConInt(), siparisNo);

                    mesaj = aracKmManager.Update(aracKm);
                }
                else
                {
                    AracKm aracKm = new AracKm(id, LblPlaka.Text, TxtSiparisNo.Text, DtBaslamaTarihi.Value, donem, TxtKmBaslangic.Text.ConInt(), TxtAdSoyad.Text, CmbSiparisNo.Text, TxtGorevi.Text, TxtMasrafyeriNo.Text, TxtMasrafYeri.Text, TxtMasrafYeriSorumlusu.Text, TxtMulkiyetBilgileri.Text, DtgBitisTarihi.Value, TxtKmBitis.Text.ConInt(), TxtToplamKm.Text.ConInt(), LblFark.Text.ConInt(), TxtFark.Text.ConInt(), siparisNo);
                    mesaj = aracKmManager.Update(aracKm);
                }

                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (DtgAracList.RowCount != 0)
                {
                    foreach (DataGridViewRow item in DtgAracList.Rows)
                    {
                        CokluArac cokluArac = new CokluArac(item.Cells["Id"].Value.ConInt(), siparisNo, item.Cells["Plaka"].Value.ToString(), item.Cells["BaslangicKm"].Value.ConInt(), item.Cells["BitisKm"].Value.ConInt(), item.Cells["ToplamKm"].Value.ConInt(), item.Cells["Aciklama"].Value.ToString(), item.Cells["BaslangicTarihi"].Value.ConDate(), item.Cells["BitisTarihi"].Value.ConDate());

                        cokluAracManager.Update(cokluArac);
                    }
                    
                }

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmAracKmIzleme frmAracKmIzleme = (FrmAracKmIzleme)System.Windows.Forms.Application.OpenForms["FrmAracKmIzleme"];
                frmAracKmIzleme.DataDisplay();
                this.Close();

            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Kaydı silmek istediğinize emin misiniz?\nBu işlem geri alınamaz!","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                string mesaj = aracKmManager.Delete(id);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler başarıyla silinmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmAracKmIzleme frmAracKmIzleme = (FrmAracKmIzleme)System.Windows.Forms.Application.OpenForms["FrmAracKmIzleme"];
                frmAracKmIzleme.DataDisplay();
                this.Close();
            }
        }
    }
}
