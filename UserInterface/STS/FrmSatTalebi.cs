using Business;
using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarim;
using Entity.IdariIsler;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ButceKodu = Entity.STS.ButceKodu;

namespace UserInterface.STS
{
    public partial class FrmSatTalebi : Form
    {
        public object[] infos;
        ButceKoduManager butceKoduManager;
        BolgeKayitManager bolgeKayitManager;
        ArizaKayitManager arizaKayitManager;
        PersonelKayitManager kayitManager;
        MalzemeTalepManager malzemeTalepManager;
        AbfMalzemeManager abfMalzemeManager;
        IsAkisNoManager isAkisNoManager;
        SatDataGridview1Manager satDataGridview1Manager;
        SatNoManager satNoManager;
        SatinAlinacakMalManager satinAlinacakMalManager;
        SatIslemAdimlariManager satIslemAdimlariManager;

        List<ButceKodu> butceKodus;
        List<ArizaKayit> arizaKayits;
        List<MalzemeTalep> malzemeTaleps;
        List<AbfMalzeme> abfMalzemes;

        bool start = false;
        string dosyaYolu, isAkisNo, kaynakdosyaismi, alinandosya, siparisNo, isleAdimi, mesaj;
        int satNo;
        public FrmSatTalebi()
        {
            InitializeComponent();
            butceKoduManager = ButceKoduManager.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            malzemeTalepManager = MalzemeTalepManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            satNoManager = SatNoManager.GetInstance();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
        }

        private void FrmSatTalebi_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            ButceKoduKalemi2();
            BolgeBilgileri();
            TarihDonem();
            Personeller();
            MifMalzemeFill();
            start = true;
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSatTalebi"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }

        void Personeller()
        {
            CmbAdSoyad.DataSource = kayitManager.PersonelAdSoyad();
            CmbAdSoyad.ValueMember = "Id";
            CmbAdSoyad.DisplayMember = "Adsoyad";
            CmbAdSoyad.SelectedValue = -1;
        }
        void Temizle()
        {
            CmbButceKodu2.SelectedIndex = -1; CmbFirma.SelectedIndex = -1; CmbHarcamaTuru.SelectedIndex = -1; TxtAciklama.Clear();
            CmbBolgeAdi.SelectedIndex = -1; BildirimFromNo.SelectedIndex = -1; CmbAdSoyad.SelectedIndex = -1;
            DtgMalzemeList.DataSource = null; DtgMalzemeList.ClearFilter();
            TxtTop.Text = DtgMalzemeList.RowCount.ToString();
            LblSiparisNo.Text = "00";
            LblMasrafYeriNo.Text = "00";
            LblMasrafYeri.Text = "00";
            LblUnvani.Text = "00";
            LblProje.Text = "00";
            LblBolgeProje.Text = "00";
            LblGarantiDurumu.Text = "00";
            LblGarantiDurumu.Text = "00";
            TarihDonem();
        }
        private void CmbFaturaFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbFaturaFirma.Text == "BAŞARAN İLERİ TEKNOLOJİ")
            {
                GrnBasaran.Visible = true;
                GrbAselsan.Visible = false;
                TxtAciklama.Enabled = true;
            }
            else
            {
                GrnBasaran.Visible = false;
                GrbAselsan.Visible = true;
                TxtAciklama.Enabled = false;
            }

            Temizle();
            int index = CmbFaturaFirma.SelectedIndex;
            CmbIlgiliKisi.SelectedIndex = index;
            CmbMasYeri.SelectedIndex = index;
        }

        void ButceKoduKalemi2()
        {
            butceKodus = butceKoduManager.GetList();
            CmbButceKodu2.DataSource = butceKodus;
            CmbButceKodu2.ValueMember = "Id";
            CmbButceKodu2.DisplayMember = "Butcekodu";
            CmbButceKodu2.SelectedValue = 0;
        }

        private void BtnButceKodu_Click(object sender, EventArgs e)
        {
            FrmButceKoduKalemi frmButceKoduKalemi = new FrmButceKoduKalemi();
            frmButceKoduKalemi.Show();
        }
        void BolgeBilgileri()
        {
            CmbBolgeAdi.DataSource = bolgeKayitManager.GetList();
            CmbBolgeAdi.ValueMember = "Id";
            CmbBolgeAdi.DisplayMember = "BolgeAdi";
            CmbBolgeAdi.SelectedValue = -1;
        }

        private void CmbBolgeAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            BolgeKayit bolgeKayit = bolgeKayitManager.Get(CmbBolgeAdi.SelectedValue.ConInt());
            if (bolgeKayit == null)
            {
                return;
            }
            else
            {
                LblBolgeProje.Text = bolgeKayit.Proje;
                arizaKayits = arizaKayitManager.GetList(CmbBolgeAdi.Text);
            }
            FormNoFill();
        }

        void FormNoFill()
        {
            BildirimFromNo.DataSource = arizaKayits;
            CmbButceKodu2.ValueMember = "Id";
            CmbButceKodu2.DisplayMember = "AbfFormNo";
            CmbButceKodu2.SelectedValue = 0;
        }

        private void BildirimFromNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }

            ArizaKayit arizaKayit = arizaKayitManager.Get(BildirimFromNo.Text.ConInt());
            if (arizaKayit == null)
            {
                LblGarantiDurumu.Text = "";
                TxtAciklama.Text = "";
                return;
            }

            LblGarantiDurumu.Text = arizaKayit.GarantiDurumu;
            TxtAciklama.Text = arizaKayit.TespitEdilenAriza;

            abfMalzemes = abfMalzemeManager.GetList(arizaKayit.Id);
            AbfMalzemeFill();
        }
        void TarihDonem()
        {
            LblSatOlusturmaTarihi.Text = DateTime.Now.ToString("d");
            LblDonem.Text = DateTime.Now.ConPeriod();

            LblSatTarihi.Text = DateTime.Now.ToString("d");
            LblDonemBasaran.Text = DateTime.Now.ConPeriod();
        }

        private void CmbAdSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            PersonelKayit siparis = kayitManager.Get(0, CmbAdSoyad.Text);
            if (siparis != null)
            {
                LblSiparisNo.Text = siparis.Siparis;
                LblMasrafYeriNo.Text = siparis.Masyerino;
                LblMasrafYeri.Text = siparis.Masrafyeri;
                LblUnvani.Text = siparis.Isunvani;
                LblProje.Text = siparis.ProjeKodu;
            }
            else
            {
                LblSiparisNo.Text = "00";
                LblMasrafYeriNo.Text = "00";
                LblMasrafYeri.Text = "00";
                LblUnvani.Text = "00";
                LblProje.Text = "00";
            }
            MifMalzemeFill();
        }
        void MifMalzemeFill()
        {
            if (CmbAdSoyad.Text == "")
            {
                return;
            }
            malzemeTaleps = malzemeTalepManager.GetListSat(CmbAdSoyad.Text);
            dataBinder.DataSource = malzemeTaleps.ToDataTable();
            DtgMalzemeList.DataSource = dataBinder;

            DtgMalzemeList.Columns["Id"].Visible = false;
            DtgMalzemeList.Columns["MalzemeKategorisi"].HeaderText = "MALZEME KATEGORİSİ";
            DtgMalzemeList.Columns["TalepEdenPersonel"].Visible = false;
            DtgMalzemeList.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzemeList.Columns["StokNo"].HeaderText = "STOK NO";
            DtgMalzemeList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzemeList.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzemeList.Columns["TalebiOlusturan"].Visible = false;
            DtgMalzemeList.Columns["Bolum"].Visible = false;
            DtgMalzemeList.Columns["SatBilgisi"].Visible = false;
            DtgMalzemeList.Columns["MasrafYeri"].Visible = false;
            DtgMalzemeList.Columns["IslemDurumu"].Visible = false;
            DtgMalzemeList.Columns["RedGerekcesi"].Visible = false;
            DtgMalzemeList.Columns["ToplamMiktar"].Visible = false;
            DtgMalzemeList.Columns["DepoDurum"].Visible = false;

            TxtTop.Text = DtgMalzemeList.RowCount.ToString();
        }
        void AbfMalzemeFill()
        {
            if (abfMalzemes.Count == 0)
            {
                return;
            }
            dataBinder.DataSource = abfMalzemes.ToDataTable();
            DtgMalzemeList.DataSource = dataBinder;

            DtgMalzemeList.Columns["Id"].Visible = false;
            DtgMalzemeList.Columns["BenzersizId"].Visible = false;
            DtgMalzemeList.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            DtgMalzemeList.Columns["SokulenTanim"].HeaderText = "TANIM";
            DtgMalzemeList.Columns["SokulenMiktar"].HeaderText = "MİKTAR";
            DtgMalzemeList.Columns["SokulenBirim"].HeaderText = "BİRİM";
            DtgMalzemeList.Columns["SokulenCalismaSaati"].Visible = false;
            DtgMalzemeList.Columns["SokulenRevizyon"].Visible = false;
            DtgMalzemeList.Columns["CalismaDurumu"].Visible = false;
            DtgMalzemeList.Columns["FizikselDurum"].Visible = false;
            DtgMalzemeList.Columns["YapilacakIslem"].Visible = false;
            DtgMalzemeList.Columns["TakilanStokNo"].Visible = false;
            DtgMalzemeList.Columns["TakilanTanim"].Visible = false;
            DtgMalzemeList.Columns["TakilanSeriNo"].Visible = false;
            DtgMalzemeList.Columns["TakilanMiktar"].Visible = false;
            DtgMalzemeList.Columns["TakilanBirim"].Visible = false;
            DtgMalzemeList.Columns["TakilanCalismaSaati"].Visible = false;
            DtgMalzemeList.Columns["TakilanRevizyon"].Visible = false;

            TxtTop.Text = DtgMalzemeList.RowCount.ToString();
        }

        private void DtgMalzemeList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgMalzemeList.FilterString;
            TxtTop.Text = DtgMalzemeList.RowCount.ToString();
        }

        private void DtgMalzemeList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgMalzemeList.SortString;
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            IsAkisNo();
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            isAkisNo = LblIsAkisNo.Text;

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyaYolu = subdir + isAkisNo;
            Directory.CreateDirectory(subdir + isAkisNo);

            //Directory.CreateDirectory(subdir + isAkisNo);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi = openFileDialog1.SafeFileName.ToString();
                alinandosya = openFileDialog1.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                webBrowser1.Navigate(dosyaYolu);
            }
        }
        string SatControl()
        {
            if (CmbButceKodu2.Text=="")
            {
                return "Lütfen Bütçe Kodu bilgisini doldurunuz!";
            }
            if (CmbFaturaFirma.Text=="")
            {
                return "Lütfen Fatura Edilecek Firma bilgisini doldurunuz!";
            }
            if (CmbFirma.Text == "")
            {
                return "Lütfen Satın Alma Yapacak Firma bilgisini doldurunuz!";
            }
            if (CmbHarcamaTuru.Text == "")
            {
                return "Lütfen Harcama Türü bilgisini doldurunuz!";
            }
            if (TxtAciklama.Text == "")
            {
                return "Lütfen Açıklama bilgisini doldurunuz!";
            }
            if (DtgMalzemeList.RowCount==0)
            {
                return "Lütfen Satın Alınacak Malzeme Listesini doldurunuz!";
            }
            return "OK";
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            IsAkisNo();
            string control = SatControl();
            if (control!="OK")
            {
                MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                siparisNo = Guid.NewGuid().ToString();
                isleAdimi = "TEKLİF";
                satNo = satNoManager.Add(new SatNo(siparisNo));
                if (CmbFaturaFirma.Text != "BAŞARAN İLERİ TEKNOLOJİ")
                {
                    SatDataGridview1 satDataGridview1 = new SatDataGridview1(satNo, LblIsAkisNo.Text.ConInt(), infos[4].ToString(), infos[1].ToString(), 
                        infos[2].ToString(), CmbBolgeAdi.Text, BildirimFromNo.Text, LblSatOlusturmaTarihi.Text.ConDate(), TxtAciklama.Text, siparisNo, "", "", "", "", "",
                  string.IsNullOrEmpty(dosyaYolu) ? "" : dosyaYolu, infos[0].ConInt(), isleAdimi, LblDonem.Text, "ASELSAN", LblBolgeProje.Text, "-");

                    mesaj = satDataGridview1Manager.Add(satDataGridview1);
                    if (mesaj!="OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    mesaj = AselsanSatMalzemeKayit();
                    if (mesaj!="OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

                else
                {
                    SatDataGridview1 satDataGridview1 = new SatDataGridview1(satNo, LblIsAkisNo.Text.ConInt(), infos[4].ToString(), infos[1].ToString(),
                        infos[2].ToString(), "YOK", "0", LblSatTarihi.Text.ConDate(), TxtAciklama.Text, siparisNo, "", "", "", "", "",
                  string.IsNullOrEmpty(dosyaYolu) ? "" : dosyaYolu, infos[0].ConInt(), isleAdimi, LblDonemBasaran.Text, "BAŞARAN", "ASL-001/MUB", "-");

                    mesaj = satDataGridview1Manager.Add(satDataGridview1);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    mesaj = BasaranSatMalzemeKayit();
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (DataGridViewRow item in DtgMalzemeList.Rows)
                    {
                        malzemeTalepManager.Update(item.Cells["Id"].ConInt(), "SAT OLUŞTURULDU, TEDARİK AŞAMASINDA");
                    }

                }

                SatDataGridview1 dataGridview1 = new SatDataGridview1(satNo, CmbButceKodu2.Text, CmbFirma.Text, CmbHarcamaTuru.Text, CmbFaturaFirma.Text, CmbIlgiliKisi.Text, CmbMasYeri.Text, siparisNo, 1, dosyaYolu, isleAdimi);
                mesaj = satDataGridview1Manager.Update(dataGridview1);

                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                satDataGridview1Manager.DurumGuncelleOnay(siparisNo);

                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, "SATIN ALMA TALEBİ OLUŞTURULDU.", infos[1].ToString(), DateTime.Now);
                satIslemAdimlariManager.Add(satIslem);

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsAkisNo();
                CmbFaturaFirma.SelectedIndex = -1;
                Temizle();

            }
        }
        string AselsanSatMalzemeKayit()
        {
            string mesaj = "";
            foreach (DataGridViewRow item in DtgMalzemeList.Rows)
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenTanim"].Value.ToString(), item.Cells["SokulenMiktar"].Value.ConInt(), item.Cells["SokulenBirim"].Value.ToString(), siparisNo);

                 mesaj = satinAlinacakMalManager.Add(satinAlinacakMalzeme, siparisNo);

                if (mesaj!="OK")
                {
                    return mesaj;
                }
            }

            return "OK";
        }
        string BasaranSatMalzemeKayit()
        {
            string mesaj = "";
            foreach (DataGridViewRow item in DtgMalzemeList.Rows)
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(item.Cells["StokNo"].Value.ToString(), item.Cells["Tanim"].Value.ToString(), item.Cells["Miktar"].Value.ConInt(), item.Cells["Birim"].Value.ToString(), siparisNo);

                mesaj = satinAlinacakMalManager.Add(satinAlinacakMalzeme, siparisNo);

                if (mesaj != "OK")
                {
                    return mesaj;
                }
            }
            return "OK";
        }
    }
}
