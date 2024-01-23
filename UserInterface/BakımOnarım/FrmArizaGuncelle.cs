using Business;
using Business.Concreate.AnaSayfa;
using Business.Concreate.BakimOnarim;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using DataAccess.Concreate.BakimOnarim;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Vml.Office;
using Entity.AnaSayfa;
using Entity.BakimOnarim;
using Entity.Gecic_Kabul_Ambar;
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

namespace UserInterface.BakımOnarım
{
    public partial class FrmArizaGuncelle : Form
    {
        BolgeKayitManager bolgeKayitManager;
        PersonelKayitManager kayitManager;
        ComboManager comboManager;
        PypManager pypManager;
        BolgeGarantiManager bolgeGarantiManager;
        ArizaKayitManager arizaKayitManager;
        UstTakimManager ustTakimManager;
        DtsLogManager dtsLogManager;

        public int id;
        int arizaId;
        public string abfNo;
        bool start = true;
        string islemAdimiSorumlusu,dosyaYolu, siparisNo,ekipmanNo, malzemeDurum, musteri = "";
        int durum, eksikEvrak;
        public object[] infos;
        public FrmArizaGuncelle()
        {
            InitializeComponent();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            pypManager = PypManager.GetInstance();
            bolgeGarantiManager = BolgeGarantiManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            ustTakimManager = UstTakimManager.GetInstance();
            dtsLogManager = DtsLogManager.GetInstance();
        }

        private void FrmArizaGuncelle_Load(object sender, EventArgs e)
        {
            UsBolgeleri();
            Personeller();
            BildirimTuru();
            Pyp();
            HasarKodu();
            NedenKodu();
            NesneTanimi();
            CmbUstTakim();
            Kategori();
            IlgiliFirmaAK();
            IslemTuru();
            start = false;
            DataFill();
            
        }
        void UsBolgeleri()
        {
            CmbUsBolgesi.DataSource = bolgeKayitManager.GetList();
            CmbUsBolgesi.ValueMember = "Id";
            CmbUsBolgesi.DisplayMember = "BolgeAdi";
            CmbUsBolgesi.SelectedValue = "";
        }
        void IslemTuru()
        {
            CmbIslemTuru.DataSource = comboManager.GetList("ISLEM_TURU");
            CmbIslemTuru.ValueMember = "Id";
            CmbIslemTuru.DisplayMember = "Baslik";
            CmbIslemTuru.SelectedValue = 0;
        }
        void Personeller()
        {
            List<PersonelKayit> personelKayits = new List<PersonelKayit>();
            personelKayits = kayitManager.GetList();

            CmbArizaKayitYapan.DataSource = personelKayits;
            CmbArizaKayitYapan.ValueMember = "Id";
            CmbArizaKayitYapan.DisplayMember = "Adsoyad";
            CmbArizaKayitYapan.SelectedValue = -1;

            CmbTeslimEden.DataSource = personelKayits;
            CmbTeslimEden.ValueMember = "Id";
            CmbTeslimEden.DisplayMember = "Adsoyad";
            CmbTeslimEden.SelectedValue = -1;
        }
        public void BildirimTuru()
        {
            CmbBildirimTuru.DataSource = comboManager.GetList("BILDIRIM TURU");
            CmbBildirimTuru.ValueMember = "Id";
            CmbBildirimTuru.DisplayMember = "Baslik";
            CmbBildirimTuru.SelectedValue = 0;
        }
        void Pyp()
        {
            CmbPypNo.DataSource = pypManager.GetList();
            CmbPypNo.ValueMember = "Id";
            CmbPypNo.DisplayMember = "PypNo";
            CmbPypNo.SelectedValue = 0;
        }
        public void HasarKodu()
        {
            CmbHasarKodu.DataSource = comboManager.GetList("HASAR_KODU");
            CmbHasarKodu.ValueMember = "Id";
            CmbHasarKodu.DisplayMember = "Baslik";
            CmbHasarKodu.SelectedValue = 0;
        }
        public void NedenKodu()
        {
            CmbNedenKodu.DataSource = comboManager.GetList("NEDEN_KODU");
            CmbNedenKodu.ValueMember = "Id";
            CmbNedenKodu.DisplayMember = "Baslik";
            CmbNedenKodu.SelectedValue = 0;
        }
        public void NesneTanimi()
        {
            CmbNesneTanimi.DataSource = comboManager.GetList("NESNE_TANIMI");
            CmbNesneTanimi.ValueMember = "Id";
            CmbNesneTanimi.DisplayMember = "Baslik";
            CmbNesneTanimi.SelectedValue = 0;
        }
        public void CmbUstTakim()
        {
            List<UstTakim> ustTakims = new List<UstTakim>();

            ustTakims = ustTakimManager.GetList();
            CmbParcaNo.DataSource = ustTakims;
            CmbParcaNo.ValueMember = "Id";
            CmbParcaNo.DisplayMember = "Tanim";
            CmbParcaNo.SelectedValue = 0;

        }
        void IlgiliFirmaAK()
        {
            CmbIlgiliFirma.DataSource = comboManager.GetList("ONARIM_YERI");
            CmbIlgiliFirma.ValueMember = "Id";
            CmbIlgiliFirma.DisplayMember = "Baslik";
            CmbIlgiliFirma.SelectedValue = 0;
        }
        void Kategori()
        {
            CmbKategori.DataSource = comboManager.GetList("ABF KATEGORİ");
            CmbKategori.ValueMember = "Id";
            CmbKategori.DisplayMember = "Baslik";
            CmbKategori.SelectedValue = 0;
        }
        string projeTanim = "";
        private void CmbUsBolgesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }

            int id = CmbUsBolgesi.SelectedValue.ConInt();
            BolgeKayit bolge = bolgeKayitManager.Get(id);

            LblPdl.Text = bolge.Proje;
            TxtBirlikAdresi.Text = bolge.BirlikAdresi;
            LblIl.Text = bolge.Il;
            LblIlce.Text = bolge.Ilce;
            projeTanim = bolge.ProjeSistem;
            musteri = bolge.Musteri;
            BolgeGaranti bolgeGaranti = bolgeGarantiManager.Get(bolge.SiparisNo);
            if (bolgeGaranti != null)
            {
                LblPdl.Text = bolgeGaranti.GarantiPaketi;
            }
            else
            {
                LblPdl.Text = bolge.Proje;
            }
        }
        string bolgeAdi = "";
        void DataFill()
        {
            ArizaKayit arizaKayit = arizaKayitManager.Get(abfNo.ConInt());
            LblIsAkisNo.Text = arizaKayit.IsAkisNo.ToString();
            LblAbfNo.Text = arizaKayit.AbfFormNo.ToString();
            CmbUsBolgesi.Text = arizaKayit.BolgeAdi;
            bolgeAdi = arizaKayit.BolgeAdi;
            TxtBildirilenAriza.Text = arizaKayit.BildirilenAriza;
            TxtBirlikPersoneli.Text = arizaKayit.ArizaiBildirenPersonel;
            TxtBirlikPerRutbesi.Text = arizaKayit.AbRutbesi;
            TxtBirlikPerGorevi.Text = arizaKayit.AbGorevi;
            TxtABTelefon.Text = arizaKayit.AbTelefon;
            DtBildirimTarihi.Value = arizaKayit.AbTarihSaat;
            DtArizaSaat.Value = arizaKayit.AbTarihSaat;
            CmbArizaKayitYapan.Text = arizaKayit.ABAlanPersonel;
            CmbBildirimKanali.Text = arizaKayit.BildirimKanali;
            TxtArizaAciklama.Text = arizaKayit.ArizaAciklama;
            CmbGarantiDurumu.Text = arizaKayit.GarantiDurumu;
            TxtLojistikSorumlusu.Text = arizaKayit.LojistikSorumluPersonel;
            TxtLojistikSorRutbesi.Text = arizaKayit.LojRutbesi;
            TxtLojistikSorGorevi.Text = arizaKayit.LojGorevi;
            DtLojistikTarih.Value = arizaKayit.LojTarihi.ConDate();
            DtLojistikSaat.Value = arizaKayit.LojTarihi.ConDate();
            TxtTespitEdilenAriza.Text = arizaKayit.TespitEdilenAriza;
            TxtBildirimNo.Text = arizaKayit.BildirimNo;
            DtgMailTarihi.Value = arizaKayit.BildirimMailTarihi.ConDate();
            CmbBildirimTuru.Text = arizaKayit.BildirimTuru;
            CmbPypNo.Text = arizaKayit.PypNo;
            DtTeslimTarihiKapat.Value = arizaKayit.TeslimTarihi;
            DtTeslimSaati.Value = arizaKayit.TeslimTarihi;
            TxtArizaOnarimNotu.Text = arizaKayit.OnarimNotu;
            CmbSiparisTuru.Text = arizaKayit.SiparisTuru;
            LblIslemAdimi.Text = arizaKayit.IslemAdimi;
            CmbParcaNo.Text = arizaKayit.Tanim;
            TxtSeriNo.Text = arizaKayit.SeriNo;
            CmbKategori.Text = arizaKayit.Kategori;
            islemAdimiSorumlusu = arizaKayit.GorevAtanacakPersonel;
            siparisNo = arizaKayit.SiparisNo;
            durum = arizaKayit.Durum;
            eksikEvrak = arizaKayit.EksikEvrak;
            ekipmanNo = arizaKayit.EkipmanNo;
            malzemeDurum = arizaKayit.MalzemeDurum;
            string teslimEdenPersonel = arizaKayit.TeslimEdenPersonel;
            CmbIslemTuru.Text = arizaKayit.IslemTuru;
            TxtOkfBildirimNo.Text = arizaKayit.OkfBildirimNo;
            if (teslimEdenPersonel == "")
            {
                CmbTeslimEden.SelectedIndex = -1;
                TxtSicil.Clear();
            }
            else
            {
                CmbTeslimEden.Text = teslimEdenPersonel;
            }
            DtTeslimTarihi.Value = arizaKayit.TeslimTarihi;
            CmbNesneTanimi.Text = arizaKayit.NesneTanimi;
            CmbHasarKodu.Text = arizaKayit.HasarKodu;
            CmbNedenKodu.Text = arizaKayit.NedenKodu;
            dosyaYolu = arizaKayit.DosyaYolu;
            arizaId = arizaKayit.Id;
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
            
        }

        private void CmbPypNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            Pyp pyp = pypManager.Get(CmbPypNo.SelectedIndex);
            if (pyp == null)
            {
                return;
            }
            TxtSorumluPersonel.Text = pyp.SorumluPersonel;
            CmbSiparisTuru.Text= pyp.SiparisTuru;
            TxtHesaplama.Text = pyp.HesaplamaNedeni;
        }

        private void CmbTeslimEden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            if (CmbTeslimEden.SelectedIndex == -1)
            {
                return;
            }
            PersonelKayit personelKayit = kayitManager.Get(0, CmbTeslimEden.Text);
            TxtSicil.Text = personelKayit.Sicil;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Arıza kaydını silmek istediğinize emin misiniz?\nBu işlem geri alınamaz!","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                string mesaj = arizaKayitManager.Delete(arizaId);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DtsLogKayitSil();
                MessageBox.Show("Bilgiler başarıyla silinmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmArizaDevamEden frmAnaSayfa = (FrmArizaDevamEden)System.Windows.Forms.Application.OpenForms["FrmArizaDevamEden"];
                if (frmAnaSayfa!=null)
                {
                    frmAnaSayfa.Yenilenecekler();
                    this.Close();
                }
                FrmArizaKayitlariKapatilan frmArizaKayitlariKapatilan = (FrmArizaKayitlariKapatilan)System.Windows.Forms.Application.OpenForms["FrmArizaKayitlariKapatilan"];
                if (frmArizaKayitlariKapatilan != null)
                {
                    frmArizaKayitlariKapatilan.Yenilenecekler();
                    this.Close();
                }

            }
        }

        private void BtnMalzemeDuzenle_Click(object sender, EventArgs e)
        {
            FrmMalzemeDuzenle frmMalzemeDuzenle = new FrmMalzemeDuzenle();
            frmMalzemeDuzenle.benzersizId = arizaId;
            frmMalzemeDuzenle.infos = infos;
            frmMalzemeDuzenle.Show();
        }

        private void CmbParcaNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            id = CmbParcaNo.SelectedValue.ConInt();
            UstTakim ustTakim = ustTakimManager.Get(id);
            if (ustTakim == null)
            {
                LbStokNo.Text = "";

                return;
            }
            LbStokNo.Text = ustTakim.StokNo;
            CmbIlgiliFirma.Text = ustTakim.IlgiliFirma;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri güncellemek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr!=DialogResult.Yes)
            {
                return;
            }
            DateTime arizaBildirimTarihi = new DateTime(DtBildirimTarihi.Value.Year, DtBildirimTarihi.Value.Month, DtBildirimTarihi.Value.Day, DtArizaSaat.Value.Hour, DtArizaSaat.Value.Minute, DtArizaSaat.Value.Second);

            DateTime lojTarih = new DateTime(DtLojistikTarih.Value.Year, DtLojistikTarih.Value.Month, DtLojistikTarih.Value.Day, DtLojistikSaat.Value.Hour, DtLojistikSaat.Value.Minute, DtLojistikSaat.Value.Second);

            ArizaKayit arizaKayit = new ArizaKayit(arizaId, LblIsAkisNo.Text.ConInt(), LblAbfNo.Text.ConInt(), LblPdl.Text, CmbUsBolgesi.Text, "", "", TxtBirlikAdresi.Text, LblIl.Text, LblIlce.Text, TxtBildirilenAriza.Text, TxtBirlikPersoneli.Text, TxtBirlikPerRutbesi.Text, TxtBirlikPerGorevi.Text, TxtABTelefon.Text, arizaBildirimTarihi, CmbArizaKayitYapan.Text, CmbBildirimKanali.Text, TxtArizaAciklama.Text, islemAdimiSorumlusu, LblIslemAdimi.Text, dosyaYolu, CmbGarantiDurumu.Text, TxtLojistikSorumlusu.Text, TxtLojistikSorRutbesi.Text, TxtLojistikSorGorevi.Text, lojTarih.ToString("g"), TxtTespitEdilenAriza.Text, CmbArizaKayitYapan.Text, "", TxtBildirimNo.Text, "", DtgMailTarihi.Value.ToString("d"), siparisNo, LbStokNo.Text, CmbParcaNo.Text, TxtSeriNo.Text, CmbKategori.Text, CmbIlgiliFirma.Text, CmbBildirimTuru.Text, CmbPypNo.Text, TxtSorumluPersonel.Text, CmbSiparisTuru.Text, CmbIslemTuru.Text, TxtHesaplama.Text, durum, TxtArizaOnarimNotu.Text, CmbTeslimEden.Text, LblTeslimAlanPersonel.Text, DtTeslimTarihi.Value, CmbNesneTanimi.Text, CmbHasarKodu.Text, CmbNedenKodu.Text, eksikEvrak, ekipmanNo, malzemeDurum, "", TxtOkfBildirimNo.Text, projeTanim, musteri);

            string mesaj = arizaKayitManager.Update(arizaKayit);

            if (mesaj!="OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            DtsLogKayit();
            MessageBox.Show("Bilgiler başarıyla güncellenmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FrmArizaDevamEden frmAnaSayfa = (FrmArizaDevamEden)Application.OpenForms["FrmArizaDevamEden"];
            if (frmAnaSayfa!=null)
            {
                frmAnaSayfa.Yenilenecekler();
            }
            this.Close();

        }

        void DtsLogKayit()
        {
            string islem = bolgeAdi + " bölgesine ait " + LblAbfNo.Text + " ABF Numaralı arızanın bilgileri güncellenmiştir.";
            DtsLog dtsLog = new DtsLog(infos[1].ToString(), DateTime.Now, "BİLDİRİM GÜNCELLE", islem);
            dtsLogManager.Add(dtsLog);
        }
        void DtsLogKayitSil()
        {
            string islem = bolgeAdi + " bölgesine ait " + LblAbfNo.Text + " ABF Numaralı arızanın kaydı silinmiştir.";
            DtsLog dtsLog = new DtsLog(infos[1].ToString(), DateTime.Now, "BİLDİRİM GÜNCELLE", islem);
            dtsLogManager.Add(dtsLog);
        }
    }
}
