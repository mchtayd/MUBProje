using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using DataAccess.Concreate.STS;
using Entity;
using Entity.BakimOnarim;
using Entity.IdariIsler;
using Entity.STS;
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

namespace UserInterface.STS
{
    public partial class FrmDevamEdenGuncelle : Form
    {
        SatTalebiDoldurManager satTalebiDoldurManager;
        PersonelKayitManager kayitManager;
        ButceKoduManager butceKoduManager;
        SiparisPersonelManager siparisPersonelManager;
        SatDataGridview1Manager satDataGridview1Manager;
        TeklifsizSatManager teklifsizSatManager;
        FiyatTeklifiAlManager fiyatTeklifiAlManager;
        SatinAlinacakMalManager satinAlinacakMalManager;
        SatIslemAdimlariManager satIslemAdimlariManager;
        BolgeKayitManager bolgeKayitManager;

        List<TeklifsizSat> teklifsizSats;
        List<FiyatTeklifiAl> fiyatTeklifiAls;
        List<SatinAlinacakMalzemeler> satinAlinacakMalzemelers;

        bool start;
        int index, id;
        public string siparisNo;
        public object[] infos;
        string dosyaYolu;
        public FrmDevamEdenGuncelle()
        {
            InitializeComponent();
            satTalebiDoldurManager = SatTalebiDoldurManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            butceKoduManager = ButceKoduManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            teklifsizSatManager = TeklifsizSatManager.GetInstance();
            fiyatTeklifiAlManager = FiyatTeklifiAlManager.GetInstance();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
        }

        private void FrmDevamEdenGuncelle_Load(object sender, EventArgs e)
        {
            UsBolgeleri();
            Personeller();
            ButceKoduKalemi();
            ButceGiderTuru();
            SatBilgileri();
            start = true;
        }
        public void ButceGiderTuru()
        {
            CmbButceGiderTuru.DataSource = satDataGridview1Manager.ButceGiderTuruList();
            CmbButceGiderTuru.Text = "";
        }
        void UsBolgeleri()
        {
            CmbUsBolgesi.DataSource = bolgeKayitManager.GetList();
            CmbUsBolgesi.ValueMember = "Id";
            CmbUsBolgesi.DisplayMember = "BolgeAdi";
            CmbUsBolgesi.SelectedValue = 0;
        }
        void Personeller()
        {
            CmbAdSoyad.DataSource = kayitManager.PersonelAdSoyad();
            CmbAdSoyad.ValueMember = "Id";
            CmbAdSoyad.DisplayMember = "Adsoyad";
            CmbAdSoyad.SelectedValue = -1;
        }
        void ButceKoduKalemi()
        {
            CmbButceKodu.DataSource = butceKoduManager.GetList();
            CmbButceKodu.ValueMember = "Id";
            CmbButceKodu.DisplayMember = "Butcekodu";
            CmbButceKodu.SelectedValue = 0;
        }
        void AbfFormNoList()
        {
            CmbAbfFormno.DataSource = satTalebiDoldurManager.BolgeSatList(CmbUsBolgesi.Text);
            CmbAbfFormno.ValueMember = "Id";
            CmbAbfFormno.DisplayMember = "AbfNo";
            CmbAbfFormno.SelectedValue = "";
        }

        private void CmbUsBolgesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            CmbAbfFormno.Text = "";
            AbfFormNoList();
            SatTalebiDoldur satTalebiDoldur = satTalebiDoldurManager.Get(CmbUsBolgesi.Text);
            TxtProje.Text = satTalebiDoldur.Proje;
        }

        private void CmbAdSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbAdSoyad.Text);
            TxtMasrafyeriNo.Text = siparis.Masrafyerino;
            TxtMasrafYeri.Text = siparis.Masrafyeri;
            TxtGorevi.Text = siparis.Gorevi;
            CmbSiparisNo.Text = siparis.Siparis;
        }

        private void CmbFaturaFirmaRed_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CmbFaturaFirma.SelectedIndex;
            TxtIlgiliKisi.SelectedIndex = index;
            TxtMasYerNo.SelectedIndex = index;
        }
        void SatBilgileri()
        {
            SatDataGridview1 satDataGridview1 = satDataGridview1Manager.SatGuncelleGet(siparisNo);
            LblIsAkisNo.Text = satDataGridview1.Formno.ToString();
            LblSatNo.Text = satDataGridview1.Satno.ToString();
            LblMasrafYeriNo.Text = satDataGridview1.Masrafyeri;
            LblMasrafYeri.Text = satDataGridview1.Bolum;
            LblAdSoyad.Text = satDataGridview1.Talepeden;
            CmbUsBolgesi.Text = satDataGridview1.Usbolgesi;
            id = satDataGridview1.Id;
            /*CmbAbfFormno.Text = satDataGridview1.Abfformno;
            TxtProje.Text= */
            istenenTarih.Value = satDataGridview1.Tarih;

            string donem = satDataGridview1.Donem;
            string[] array = donem.Split(' ');

            CmbDonem.Text = array[0].ToString();
            CmbDonemYil.Text = array[1].ToString();
            TxtGerekceBasaran.Text = satDataGridview1.Gerekce;
            CmbAdSoyad.Text = satDataGridview1.TalepEdenPersonel;
            CmbSiparisNo.Text = satDataGridview1.PersonelSiparis;
            TxtGorevi.Text = satDataGridview1.Unvani;
            TxtMasrafyeriNo.Text = satDataGridview1.PersonelMasYerNo;
            TxtMasrafYeri.Text = satDataGridview1.PersonelMasYeri;
            CmbButceKodu.Text = satDataGridview1.Burcekodu;
            CmbSatBirim.Text = satDataGridview1.Satbirim;
            CmbHarcamaTuru.Text = satDataGridview1.Harcamaturu;
            CmbFaturaFirma.Text = satDataGridview1.Faturafirma;
            TxtProje.Text = satDataGridview1.Proje;
            CmbAbfFormno.Text = satDataGridview1.Abfformno;
            dosyaYolu = satDataGridview1.DosyaYolu;
            CmbBelgeTuru.Text = satDataGridview1.BelgeTuru;
            TxtBelgeNumarasi.Text = satDataGridview1.BelgeNumarasi;
            DtBelgeTarihi.Value = satDataGridview1.BelgeTarihi;
            TxtSatinAlinanFirma.Text = satDataGridview1.SatinAlinanFirma;

            CmbButceGiderTuru.Text = satDataGridview1.ButceGiderTuru;
            teklifsizSats = null;
            satinAlinacakMalzemelers = null;
            fiyatTeklifiAls = null;

            teklifsizSats = teklifsizSatManager.GetList(siparisNo);

            if (teklifsizSats.Count == 0)
            {
                fiyatTeklifiAls = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);
                if (fiyatTeklifiAls.Count == 0)
                {
                    satinAlinacakMalzemelers = satinAlinacakMalManager.GetList(siparisNo);
                    DtgList.DataSource = satinAlinacakMalzemelers;
                    MalzemeEdit();
                }
                else
                {
                    DtgList.DataSource = fiyatTeklifiAls;
                    TxtSatinAlinanFirma.Text = fiyatTeklifiAls[0].Firma1.ToString();
                    TeklifliSatEdit();
                }
            }
            else
            {
                DtgList.DataSource = teklifsizSats;
                TeklifsizEdit();
            }
            try
            {
                webBrowser6.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }

        }
        void TeklifsizEdit()
        {
            if (teklifsizSats[0].Stokno=="")
            {
                DtgList.Columns["Id"].Visible = false;
                DtgList.Columns["Stokno"].Visible = false;
                DtgList.Columns["Tanim"].Visible = false;
                DtgList.Columns["Miktar"].Visible = false;
                DtgList.Columns["Birim"].Visible = false;
                DtgList.Columns["Siparisno"].Visible = false;
                DtgList.Columns["Tutar"].HeaderText = "TUTAR";
            }
            else
            {
                DtgList.Columns["Id"].Visible = false;
                DtgList.Columns["Stokno"].HeaderText = "STOK NO";
                DtgList.Columns["Tanim"].HeaderText = "TANIM";
                DtgList.Columns["Miktar"].HeaderText = "MİKTAR";
                DtgList.Columns["Birim"].HeaderText = "BİRİM";
                DtgList.Columns["Siparisno"].Visible = false;
                DtgList.Columns["Tutar"].HeaderText = "TUTAR";
            }
        }
        void TeklifliSatEdit()
        {
            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Stokno"].HeaderText = "STOK NO";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgList.Columns["Birim"].HeaderText = "BİRİM";
            DtgList.Columns["Firma1"].HeaderText = "1. FİRMA";
            DtgList.Columns["Firma2"].HeaderText = "2. FİRMA";
            DtgList.Columns["Firma3"].HeaderText = "3. FİRMA";
            DtgList.Columns["Siparisno"].Visible = false;
            DtgList.Columns["Teklifdurumu"].Visible = false;
            DtgList.Columns["Bbf"].HeaderText = "1. BİRİM FİYAT";
            DtgList.Columns["Btf"].HeaderText = "1. TOPLAM FİYAT";
            DtgList.Columns["Ibf"].HeaderText = "2. BİRİM FİYAT";
            DtgList.Columns["Itf"].HeaderText = "2. TOPLAM FİYAT";
            DtgList.Columns["Ubf"].HeaderText = "3. BİRİM FİYAT";
            DtgList.Columns["Utf"].HeaderText = "3. TOPLAM FİYAT";
            DtgList.Columns["Onaylananteklif"].Visible = false;
            DtgList.Columns["Bbf"].DisplayIndex = 6;
            DtgList.Columns["Btf"].DisplayIndex = 7;
            DtgList.Columns["Firma2"].DisplayIndex = 8;
            DtgList.Columns["Ibf"].DisplayIndex = 9;
            DtgList.Columns["Itf"].DisplayIndex = 10;
            DtgList.Columns["Firma3"].DisplayIndex = 11;
            DtgList.Columns["Ubf"].DisplayIndex = 12;
            DtgList.Columns["Utf"].DisplayIndex = 13;
        }
        void MalzemeEdit()
        {
            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Stn1"].HeaderText = "STOK NO";
            DtgList.Columns["T1"].HeaderText = "TANIM";
            DtgList.Columns["M1"].HeaderText = "MİKTAR";
            DtgList.Columns["B1"].HeaderText = "BİRİM";
            DtgList.Columns["SiparisNo"].Visible = false;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri güncellemek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string donem = CmbDonem.Text + " " + CmbDonemYil.Text;
                SatDataGridview1 satDataGridview1 = new SatDataGridview1(id, CmbUsBolgesi.Text, CmbAbfFormno.Text, CmbButceKodu.Text, CmbSatBirim.Text, CmbHarcamaTuru.Text, CmbFaturaFirma.Text, TxtIlgiliKisi.Text, TxtMasYerNo.Text, istenenTarih.Value, TxtGerekceBasaran.Text, CmbAdSoyad.Text, CmbSiparisNo.Text, TxtGorevi.Text, TxtMasrafyeriNo.Text, TxtMasrafYeri.Text, donem, CmbBelgeTuru.Text, TxtBelgeNumarasi.Text, DtBelgeTarihi.Value, TxtSatinAlinanFirma.Text, CmbButceGiderTuru.Text);

                string mesaj = satDataGridview1Manager.DevamEdenSatGuncelle(satDataGridview1);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (satinAlinacakMalzemelers != null)
                {
                    foreach (DataGridViewRow item in DtgList.Rows)
                    {
                        SatinAlinacakMalzemeler satinAlinacakMalzemeler = new SatinAlinacakMalzemeler(item.Cells["Id"].Value.ConInt(), item.Cells["Stn1"].Value.ToString(), item.Cells["T1"].Value.ToString(), item.Cells["M1"].Value.ConInt(), item.Cells["B1"].Value.ToString());

                        satinAlinacakMalManager.DevamEdenSatGuncelle(satinAlinacakMalzemeler);
                    }
                }
                if (teklifsizSats.Count != 0)
                {
                    if (teklifsizSats[0].Stokno == "")
                    {
                        foreach (DataGridViewRow item in DtgList.Rows)
                        {
                            teklifsizSatManager.DevamEdenSatHYGuncelle(item.Cells["Id"].Value.ConInt(), item.Cells["Tutar"].Value.ConDouble());
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow item in DtgList.Rows)
                        {
                            TeklifsizSat teklifsizSat = new TeklifsizSat(item.Cells["Id"].Value.ConInt(), item.Cells["Stokno"].Value.ToString(), item.Cells["Tanim"].Value.ToString(), item.Cells["Miktar"].Value.ConInt(), item.Cells["Birim"].Value.ToString(), item.Cells["Tutar"].Value.ConInt());

                            teklifsizSatManager.DevamEdenSatGuncelle(teklifsizSat);
                        }
                    }
                }
                if (fiyatTeklifiAls != null)
                {
                    foreach (DataGridViewRow item in DtgList.Rows)
                    {
                        FiyatTeklifiAl fiyatTeklifiAl = new FiyatTeklifiAl(item.Cells["Id"].Value.ConInt(), item.Cells["Stokno"].Value.ToString(), item.Cells["Tanim"].Value.ToString(), item.Cells["Miktar"].Value.ConInt(), item.Cells["Birim"].Value.ToString(), item.Cells["Firma1"].Value.ToString(), item.Cells["Bbf"].Value.ConDouble(), item.Cells["Btf"].Value.ConDouble(), item.Cells["Firma2"].Value.ToString(), item.Cells["Ibf"].Value.ConDouble(), item.Cells["Itf"].Value.ConDouble(), item.Cells["Firma3"].Value.ToString(), item.Cells["Ubf"].Value.ConDouble(), item.Cells["Utf"].Value.ConDouble());

                        fiyatTeklifiAlManager.DevamEdenFiyateklifiGuncelle(fiyatTeklifiAl);

                    }
                }

                string yapilanIslem = "SAT BİLGİLERİ GÜNCELLENMİŞTİR.";

                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, yapilanIslem, infos[1].ToString(), DateTime.Now);
                satIslemAdimlariManager.Add(satIslem);

                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmDevamEdenSat frmDevamEden = (FrmDevamEdenSat)Application.OpenForms["FrmDevamEdenSat"];
                if (frmDevamEden != null)
                {
                    frmDevamEden.YenilecekVeri();
                }
                this.Close();

            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri silmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                string mesaj = satDataGridview1Manager.Delete(id);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler başarıyla silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmDevamEdenSat frmDevamEden = (FrmDevamEdenSat)Application.OpenForms["FrmDevamEdenSat"];
                if (frmDevamEden != null)
                {
                    frmDevamEden.YenilecekVeri();
                }
                this.Close();
            }
        }

        private void FrmDevamEdenGuncelle_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmDevamEdenSat frmDevamEdenSat = new FrmDevamEdenSat();
            frmDevamEdenSat.DataDisplay();

        }

        
        
    }
}
