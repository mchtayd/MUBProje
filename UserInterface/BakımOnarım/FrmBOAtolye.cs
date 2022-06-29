using Business;
using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarim;
using Entity.BakimOnarimAtolye;
using Entity.Gecic_Kabul_Ambar;
using Entity.IdariIsler;
using Microsoft.Office.Interop.Word;
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
using UserInterface.STS;
using Application = Microsoft.Office.Interop.Word.Application;

namespace UserInterface.BakımOnarım
{
    public partial class FrmBOAtolye : Form
    {
        AtolyeManager atolyeManager;
        AtolyeMalzemeManager atolyeMalzemeManager;
        IslemAdimlariManager islemAdimlariManager;
        PersonelKayitManager kayitManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        IscilikIscilikManager ıscilikIscilikManager;
        SiparisPersonelManager siparisPersonelManager;
        MalzemeKayitManager malzemeKayitManager;
        ComboManager comboManager;

        List<AtolyeMalzeme> atolyeMalzemes;


        List<string> IcSiparisler = new List<string>();
        List<string> SiparisNos = new List<string>();
        List<string> DosyaYollari = new List<string>();
        List<MalzemeKayit> malzemeKayits = new List<MalzemeKayit>();
        List<MalzemeKayit> malzemeKayitsFiltired = new List<MalzemeKayit>();
        List<MalzemeKayit> malzemeKayitsSecilenler = new List<MalzemeKayit>();

        public object[] infos;
        int id;
        string siparisNo = "", dosya, taslakYolu = "";
        string kaynak = @"Z:\DTS\BAKIM ONARIM ATOLYE\Taslak\";
        string yol = @"C:\DTS\Taslak\";
        bool start = true;
        public FrmBOAtolye()
        {
            InitializeComponent();
            atolyeManager = AtolyeManager.GetInstance();
            atolyeMalzemeManager = AtolyeMalzemeManager.GetInstance();
            islemAdimlariManager = IslemAdimlariManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            ıscilikIscilikManager = IscilikIscilikManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
            comboManager = ComboManager.GetInstance();
        }

        private void FrmBOAtolye_Load(object sender, EventArgs e)
        {
            IslemAdimlari();
            IslemAdimlariManuel();
            Personeller();
            PersonellerManuel();
            CmbStokNo();
            DataDisplayManuel();
            Kategori();
            ComboProje();
            IcSiparisNo();
            start = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageArizaAcmaAtolye"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void IcSiparisNo()
        {
            LblIcSiparisManuel.Text = "221RWK" + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("yy") + DateTime.Now.ToString("HH");
        }
        void ComboProje()
        {
            CmbProje.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProje.ValueMember = "Id";
            CmbProje.DisplayMember = "Baslik";
            CmbProje.SelectedValue = 0;
        }
        void CmbStokNo()
        {
            TxtTanimUs.DataSource = malzemeKayitManager.UstTakimGetList();
            TxtTanimUs.ValueMember = "Id";
            TxtTanimUs.DisplayMember = "Tanim";
            TxtTanimUs.SelectedValue = 0;
        }
        void IslemAdimlari()
        {
            CmbIslemAdimi.DataSource = islemAdimlariManager.GetList("BAKIM ONARIM ATOLYE");
            CmbIslemAdimi.ValueMember = "Id";
            CmbIslemAdimi.DisplayMember = "IslemaAdimi";
            CmbIslemAdimi.SelectedValue = -1;
        }
        void IslemAdimlariManuel()
        {
            CmbIslemAdimiManuel.DataSource = islemAdimlariManager.GetList("BAKIM ONARIM ATOLYE");
            CmbIslemAdimiManuel.ValueMember = "Id";
            CmbIslemAdimiManuel.DisplayMember = "IslemaAdimi";
            CmbIslemAdimiManuel.SelectedValue = -1;
        }
        void Personeller()
        {
            CmbGorevAtanacakPersonel.DataSource = kayitManager.PersonelAdSoyad();
            CmbGorevAtanacakPersonel.ValueMember = "Id";
            CmbGorevAtanacakPersonel.DisplayMember = "Adsoyad";
            CmbGorevAtanacakPersonel.SelectedValue = -1;
        }
        void PersonellerManuel()
        {
            CmbGorevAtanacakPersonelManuel.DataSource = kayitManager.PersonelAdSoyad();
            CmbGorevAtanacakPersonelManuel.ValueMember = "Id";
            CmbGorevAtanacakPersonelManuel.DisplayMember = "Adsoyad";
            CmbGorevAtanacakPersonelManuel.SelectedValue = -1;
        }
        void DataDisplayManuel()
        {
            malzemeKayits = malzemeKayitManager.GetList();
            malzemeKayitsFiltired = malzemeKayits;
            dataBinder.DataSource = malzemeKayits.ToDataTable();
            DtgStokList.DataSource = dataBinder;

            DtgStokList.Columns["Id"].Visible = false;
            DtgStokList.Columns["Stokno"].HeaderText = "STOK NO";
            DtgStokList.Columns["Tanim"].HeaderText = "TANIM";
            DtgStokList.Columns["Birim"].Visible = false;
            DtgStokList.Columns["Tedarikcifirma"].Visible = false;
            DtgStokList.Columns["Malzemeonarimdurumu"].Visible = false;
            DtgStokList.Columns["Malzemeonarımyeri"].Visible = false;
            DtgStokList.Columns["Malzemeturu"].Visible = false;
            DtgStokList.Columns["Malzemetakipdurumu"].Visible = false;
            //DtgStokList.Columns["Malzemerevizyon"].Visible = false;
            DtgStokList.Columns["Malzemekul"].Visible = false;
            DtgStokList.Columns["Aciklama"].Visible = false;
            DtgStokList.Columns["Dosyayolu"].Visible = false;
            DtgStokList.Columns["AlternatifMalzeme"].Visible = false;
            DtgStokList.Columns["SistemStokNo"].Visible = false;
            DtgStokList.Columns["SistemTanim"].Visible = false;
            DtgStokList.Columns["SistemPersonel"].Visible = false;
            DtgStokList.Columns["KayitDurumu"].HeaderText = "KAYIT DURUMU";
            DtgStokList.Columns["Stokno"].HeaderText = "STOK NO";
            DtgStokList.Columns["Tanim"].HeaderText = "TANIM";
            DtgStokList.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgStokList.Columns["Durum"].HeaderText = "DURUM";
            DtgStokList.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgStokList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgStokList.Columns["TalepTarihi"].HeaderText = "TALEP TARİHİ";
            DtgStokList.Columns["DataTypeValue"].Visible = false;

            DtgStokList.Columns["KayitDurumu"].DisplayIndex = 0;
            DtgStokList.Columns["Stokno"].DisplayIndex = 1;
            DtgStokList.Columns["Tanim"].DisplayIndex = 3;
            DtgStokList.Columns["SeriNo"].DisplayIndex = 4;
            DtgStokList.Columns["Durum"].DisplayIndex = 5;
            DtgStokList.Columns["Revizyon"].DisplayIndex = 6;
            DtgStokList.Columns["Miktar"].DisplayIndex = 7;
            DtgStokList.Columns["TalepTarihi"].DisplayIndex = 8;
            LblTop.Text = DtgStokList.RowCount.ToString();

            for (int i = 0; i < DtgStokList.RowCount; i++)
            {
                string tarih = DateTime.Now.ToString("dd.MM.yyyy");
                DtgStokList.Rows[i].Cells["TalepTarihi"].Value = tarih;
            }

            //DtgStokList.Rows[0].Cells["asdb"].Value = "test";

        }
        int arizaDurumu;
        string icSiparisNo = "";
        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtAbfFormNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Abf No Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Atolye atolye = atolyeManager.ArizaGetir(TxtAbfFormNo.Text.ConInt());
            if (atolye == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz Abf Numarasıya Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                return;
            }
            Temizle();
            DataDisplay();
            TxtStokNoUst.Text = atolye.StokNoUst;
            TxtTanimUst.Text = atolye.TanimUst;
            TxtSeriNoUst.Text = atolye.SeriNoUst;
            TxtGarantiDurumuUst.Text = atolye.GarantiDurumu;
            TxtBildirimNo.Text = atolye.BildirimNo;
            TxtScrmNo.Text = atolye.CrmNo;
            TxtKategori.Text = atolye.Kategori;
            TxtBolgeAdi.Text = atolye.BolgeAdi;
            TxtProje.Text = atolye.Proje;
            TxtBildirilenAriza.Text = atolye.BildirilenAriza;
            arizaDurumu = atolye.ArizaDurum;
            int adet = 1;
            if (arizaDurumu == 0)
            {
                LblDurumAcik.Visible = false;
                LblDurumKapali.Visible = true;
                LblIslemAdimiAcik.Text = atolye.BulunduguIslemAdimi;
                LblIslemAdimiKapali.Visible = false;
                LblIslemAdimiAcik.Visible = true;

                if (DtgMalzemeler.RowCount > 1)
                {


                    foreach (AtolyeMalzeme item in atolyeMalzemes)
                    {
                        LblIcSiparisNo.Text = "221RWK" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text;
                        icSiparisNo = "221RWK" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text + "/" + adet;
                        IcSiparisler.Add(icSiparisNo);

                        adet++;
                    }
                }
                else
                {
                    LblIcSiparisNo.Text = "221RWK" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text;
                }

            }
            else
            {
                LblDurumAcik.Visible = true;
                LblDurumKapali.Visible = false;
                LblIslemAdimiKapali.Text = atolye.BulunduguIslemAdimi;
                LblIslemAdimiKapali.Visible = true;
                LblIslemAdimiAcik.Visible = false;

                if (DtgMalzemeler.RowCount > 1)
                {
                    foreach (AtolyeMalzeme item in atolyeMalzemes)
                    {
                        LblIcSiparisNo.Text = "221BO" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text;
                        icSiparisNo = "221BO" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text + "/" + adet;
                        IcSiparisler.Add(icSiparisNo);
                        adet++;

                    }
                }
                else
                {
                    LblIcSiparisNo.Text = "221BO" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text;
                }

            }

        }
        void Temizle()
        {
            TxtStokNoUst.Clear(); TxtSeriNoUst.Clear(); TxtGarantiDurumuUst.Clear(); TxtBildirimNo.Clear(); TxtScrmNo.Clear(); TxtKategori.Clear(); TxtBolgeAdi.Clear(); TxtProje.Clear(); TxtStokNo.Clear(); TxtTanim.Clear(); TxtSeriNo.Clear(); TxtRevizyon.Clear();
            TxtMiktar.Clear(); TxtDurum.Clear(); TxtBildirilenAriza.Clear(); TxtModifikasyonlar.Clear(); TxtNotlar.Clear(); CmbGorevAtanacakPersonel.SelectedValue = ""; CmbIslemAdimi.SelectedValue = ""; TxtTanimUst.Clear(); LblIcSiparisNo.Text = "-"; LblDurumAcik.Visible = false; LblDurumKapali.Visible = false; LblIslemAdimiKapali.Visible = false; LblIslemAdimiAcik.Visible = false;
            LblToplam.Text = DtgMalzemeler.RowCount.ToString();
        }
        void TemizleManuel()
        {
            TxtTanimUs.Text = ""; CmbStokUst.Clear(); TxtSeriUst.Clear(); CmbGarantiDurumuUst.Text = ""; CmbKategori.SelectedIndex = -1;
            CmbProje.SelectedIndex = -1; LblIcSiparisManuel.Text = "-"; TxtModifikasyonlarManuel.Clear(); TxtNotlarManuel.Clear();
            CmbGorevAtanacakPersonelManuel.SelectedIndex = -1; CmbIslemAdimiManuel.SelectedIndex = -1;
        }
        void DataDisplay()
        {
            atolyeMalzemes = atolyeMalzemeManager.GetList(TxtAbfFormNo.Text.ConInt());
            DtgMalzemeler.DataSource = atolyeMalzemes.ToDataTable();
            LblToplam.Text = DtgMalzemeler.RowCount.ToString();


            DtgMalzemeler.Columns["Id"].Visible = false;
            DtgMalzemeler.Columns["FormNo"].Visible = false;
            DtgMalzemeler.Columns["StokNo"].HeaderText = "STOK NO";
            DtgMalzemeler.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzemeler.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgMalzemeler.Columns["Durum"].HeaderText = "DURUM";
            DtgMalzemeler.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgMalzemeler.Columns["Miktar"].HeaderText = "MİKAR";
            //DtgMalzemeler.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzemeler.Columns["TalepTarihi"].HeaderText = "TALEP TARİHİ";
            DtgMalzemeler.Columns["SiparisNo"].Visible = false;
            DtgMalzemeler.Columns["Sec"].HeaderText = "KAYIT DURUMU";
            DtgMalzemeler.Columns["Sec"].DisplayIndex = 0;

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }



        void EditSiparisNos()
        {
            string value, siparisNoForEdit;
            int adet = 1;
            List<bool> secList = new List<bool>();
            foreach (DataGridViewRow row in DtgMalzemeler.Rows)
            {
                secList.Add(row.Cells[10].Value.ConBool());
            }

            for (int i = 0; i < secList.Count; i++)
            {
                value = IcSiparisler[i];
                if (atolyeMalzemes.Count > 1 && secList.Where(x => x).Count() == 1)
                {
                    siparisNoForEdit = value.Substring(0, value.Length - 2);
                    IcSiparisler.Clear();
                    IcSiparisler.Add(siparisNoForEdit);
                    break;
                }
                else if (atolyeMalzemes.Count > 1 && secList.Where(x => x).Count() > 1)
                {
                    string prefix = secList[i] ? "/" + adet : "";
                    siparisNoForEdit = value.Substring(0, value.Length - 2) + prefix;
                    if (secList[i])
                    {
                        IcSiparisler[i] = siparisNoForEdit;
                        adet++;
                    }
                    else
                    {
                        IcSiparisler[i] = siparisNoForEdit;
                    }
                }
            }
            for (int i = 0; i < IcSiparisler.Count; i++)
            {
                if (!IcSiparisler[i].Contains('/'))
                {

                    if (IcSiparisler.Count == 1)
                    {
                        break;
                    }
                    IcSiparisler.Remove(IcSiparisler[i]);
                    i--;
                }
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            #region control
            if (TxtStokNoUst.Text == "" || DtgMalzemeler.RowCount == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Tüm Bilgileri Eksiksiz Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbGorevAtanacakPersonel.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Görev Atanacak Personel Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbIslemAdimi.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İşlem Adımı Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbIslemAdimi.Text != "400-BİLDİRİM ve B/O BAŞLAMA ONAYI (MÜHENDİS)")
            {
                MessageBox.Show("Lütfen Öncelikle İşlem Adımı Bilgisini 400-GÖZ DENETİMİ Olarak Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                BtnKaydet.Enabled = false;
                BtnTemizle.Enabled = false;
                BtnCancel.Enabled = false;
                BtnBul.Enabled = false;
                CreateFile();

                if (IcSiparisler.Count > 0)
                {
                    EditSiparisNos();
                    for (int i = 0; i < IcSiparisler.Count; i++)
                    {
                        siparisNo = Guid.NewGuid().ToString();


                        Atolye atolye2 = new Atolye(TxtAbfFormNo.Text.ConInt(), TxtStokNoUst.Text, TxtTanimUst.Text, TxtSeriNoUst.Text, TxtGarantiDurumuUst.Text, TxtBildirimNo.Text, TxtScrmNo.Text, TxtKategori.Text, TxtBolgeAdi.Text, TxtProje.Text, TxtBildirilenAriza.Text, IcSiparisler[i].ToString(), DtgCekilmeTarihi.Value, DtgSiparisTarihi.Value, TxtModifikasyonlar.Text, TxtNotlar.Text, CmbIslemAdimi.Text, siparisNo,
                            DosyaYollari[i].ToString());

                        atolyeManager.Add(atolye2);

                        SiparisNos.Add(siparisNo);

                    }
                }
                else
                {
                    siparisNo = Guid.NewGuid().ToString();
                    Atolye atolye = new Atolye(TxtAbfFormNo.Text.ConInt(), TxtStokNoUst.Text, TxtTanimUst.Text, TxtSeriNoUst.Text, TxtGarantiDurumuUst.Text, TxtBildirimNo.Text, TxtScrmNo.Text, TxtKategori.Text, TxtBolgeAdi.Text, TxtProje.Text, TxtBildirilenAriza.Text, LblIcSiparisNo.Text, DtgCekilmeTarihi.Value, DtgSiparisTarihi.Value, TxtModifikasyonlar.Text, TxtNotlar.Text, CmbIslemAdimi.Text, siparisNo,
                        dosya);

                    SiparisNos.Add(siparisNo);
                    atolyeManager.Add(atolye);
                }

                int sayac = 0;
                foreach (DataGridViewRow item in DtgMalzemeler.Rows)
                {
                    if (item.Cells[10].Value.ConBool())
                    {

                        AtolyeMalzeme atolyeMalzeme = new AtolyeMalzeme(item.Cells["FormNo"].Value.ConInt(), item.Cells["StokNo"].Value.ToString(),
                            item.Cells["Tanim"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Durum"].Value.ToString(),
                            item.Cells["Revizyon"].Value.ToString(), item.Cells["Miktar"].Value.ConDouble(), item.Cells["TalepTarihi"].Value.ConDate(),
                            SiparisNos[sayac].ToString());

                        atolyeMalzemeManager.Add(atolyeMalzeme);
                        sayac++;
                    }

                }

                if (IcSiparisler.Count > 0)
                {
                    for (int i = 0; i < IcSiparisler.Count; i++)
                    {
                        Atolye atolye2 = atolyeManager.Get(IcSiparisler[i].ToString());
                        id = atolye2.Id;
                        GorevAtama();
                    }
                }
                else
                {
                    Atolye atolye1 = atolyeManager.Get(LblIcSiparisNo.Text);
                    id = atolye1.Id;
                    GorevAtama();
                }
                //IscilikGir();

                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnKaydet.Enabled = true;
                BtnTemizle.Enabled = true;
                BtnCancel.Enabled = true;
                BtnBul.Enabled = true;
                Temizle();
                DtgMalzemeler.DataSource = null;
                IcSiparisler.Clear();
                SiparisNos.Clear();
                DosyaYollari.Clear();
                IcSiparisNo();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void CmbStokUst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            id = TxtTanimUs.SelectedValue.ConInt();
            MalzemeKayit malzemeKayit = malzemeKayitManager.Get(id);
            if (malzemeKayit == null)
            {
                CmbStokUst.Text = "";
                return;
            }
            CmbStokUst.Text = malzemeKayit.Stokno;
        }

        private void TxtStokManuel_TextChanged(object sender, EventArgs e)
        {
            string stokno = TxtStokManuel.Text;
            if (string.IsNullOrEmpty(stokno))
            {
                malzemeKayitsFiltired = malzemeKayits;
                dataBinder.DataSource = malzemeKayits.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                LblTop.Text = DtgStokList.RowCount.ToString();

                for (int i = 0; i < DtgStokList.RowCount; i++)
                {
                    string tarih = DateTime.Now.ToString("dd.MM.yyyy");
                    DtgStokList.Rows[i].Cells["TalepTarihi"].Value = tarih;
                }

                return;
            }
            if (TxtStokManuel.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemeKayitsFiltired.Where(x => x.Stokno.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
            DtgStokList.DataSource = dataBinder;
            malzemeKayitsFiltired = malzemeKayits;
            LblTop.Text = DtgStokList.RowCount.ToString();

            for (int i = 0; i < DtgStokList.RowCount; i++)
            {
                string tarih = DateTime.Now.ToString("dd.MM.yyyy");
                DtgStokList.Rows[i].Cells["TalepTarihi"].Value = tarih;
            }
        }

        private void TxtTanimManuel_TextChanged(object sender, EventArgs e)
        {
            string tanim = TxtTanimManuel.Text;
            if (string.IsNullOrEmpty(tanim))
            {
                malzemeKayitsFiltired = malzemeKayits;
                dataBinder.DataSource = malzemeKayits.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                LblTop.Text = DtgStokList.RowCount.ToString();

                for (int i = 0; i < DtgStokList.RowCount; i++)
                {
                    string tarih = DateTime.Now.ToString("dd.MM.yyyy");
                    DtgStokList.Rows[i].Cells["TalepTarihi"].Value = tarih;
                }

                return;
            }
            if (TxtTanimManuel.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemeKayitsFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
            DtgStokList.DataSource = dataBinder;
            malzemeKayitsFiltired = malzemeKayits;
            LblTop.Text = DtgStokList.RowCount.ToString();

            for (int i = 0; i < DtgStokList.RowCount; i++)
            {
                string tarih = DateTime.Now.ToString("dd.MM.yyyy");
                DtgStokList.Rows[i].Cells["TalepTarihi"].Value = tarih;
            }
        }
        string KontrolManuel()
        {
            if (TxtTanimUs.Text == "")
            {
                return "Lütfen Öncelikle Üst Takım Stok No Bilgisini Seçiniz!";
            }
            if (TxtSeriUst.Text == "")
            {
                return "Lütfen Öncelikle Üst Takım Seri No Bilgisini Doldurunuz!\nBilmiyorsanız N/A Seçiniz.";
            }
            if (CmbGorevAtanacakPersonelManuel.Text == "")
            {
                return "Lütfen Öncelikle Görev Atanacak Personel Bilgisini Seçiniz!";
            }
            if (CmbIslemAdimiManuel.Text == "")
            {
                return "Lütfen Öncelikle İşlem Adımı Bilgisini Seçiniz!";
            }
            string kontrol = "hata";

            foreach (DataGridViewRow item in DtgStokList.Rows)
            {
                if (item.Cells["KayitDurumu"].Value.ConBool() == true)
                {
                    kontrol = "";
                    break;
                }
                kontrol = "hata";
            }
            if (kontrol=="")
            {
                return "OK";
            }
            else
            {
                return "Lütfen Öncelikle Malzeme Listesinden Malzeme Seçiniz!";
            }
        }

        private void BtnKaydetManuel_Click(object sender, EventArgs e)
        {
            string mesaj = KontrolManuel();
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İsteğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                CreateFileManuel();
                if (IcSiparisler.Count > 0)
                {
                    //EditSiparisNos();
                    for (int i = 0; i < IcSiparisler.Count; i++)
                    {
                        siparisNo = Guid.NewGuid().ToString();

                        Atolye atolye2 = new Atolye(0, TxtTanimUs.Text, CmbStokUst.Text, TxtSeriUst.Text, CmbGarantiDurumuUst.Text, "", "", CmbKategori.Text, "", "", "", IcSiparisler[i].ToString(), DtgCekilmeTarihiManuel.Value, DtgSiparisTarihiManuel.Value, TxtModifikasyonlarManuel.Text, TxtNotlarManuel.Text, CmbIslemAdimiManuel.Text, siparisNo, DosyaYollari[i].ToString());

                        atolyeManager.Add(atolye2);

                        SiparisNos.Add(siparisNo);

                    }
                }
                else
                {
                    siparisNo = Guid.NewGuid().ToString();
                    Atolye atolye = new Atolye(0, TxtTanimUs.Text, CmbStokUst.Text, TxtSeriUst.Text, CmbGarantiDurumuUst.Text, "", "", CmbKategori.Text, "", "", "", LblIcSiparisManuel.Text, DtgCekilmeTarihiManuel.Value, DtgSiparisTarihiManuel.Value, TxtModifikasyonlarManuel.Text, TxtNotlarManuel.Text, CmbIslemAdimiManuel.Text, siparisNo, dosya);

                    SiparisNos.Add(siparisNo);
                    atolyeManager.Add(atolye);
                }

                int sayac = 0;
                foreach (MalzemeKayit item in malzemeKayitsSecilenler)
                {

                    AtolyeMalzeme atolyeMalzeme = new AtolyeMalzeme(0, item.Stokno, item.Tanim, item.SeriNo, item.Durum, item.Revizyon, item.Miktar, item.TalepTarihi.ConDate(), SiparisNos[sayac].ToString());

                    atolyeMalzemeManager.Add(atolyeMalzeme);
                    sayac++;

                }

                if (IcSiparisler.Count > 0)
                {
                    for (int i = 0; i < IcSiparisler.Count; i++)
                    {
                        Atolye atolye2 = atolyeManager.Get(IcSiparisler[i].ToString());
                        id = atolye2.Id;
                        GorevAtamaManuel();
                    }
                }
                else
                {
                    Atolye atolye1 = atolyeManager.Get(LblIcSiparisNo.Text);
                    id = atolye1.Id;
                    GorevAtamaManuel();
                }
                //IscilikGir();

                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnKaydet.Enabled = true;
                BtnTemizle.Enabled = true;
                BtnCancel.Enabled = true;
                BtnBul.Enabled = true;
                TemizleManuel();

                foreach (DataGridViewRow item in DtgStokList.Rows)
                {
                    item.Cells["KayitDurumu"].Value = false;
                }

                IcSiparisler.Clear();
                SiparisNos.Clear();
                DosyaYollari.Clear();
                IcSiparisNo();
            }
        }
        void Kategori()
        {
            CmbKategori.DataSource = comboManager.GetList("ABF KATEGORİ");
            CmbKategori.ValueMember = "Id";
            CmbKategori.DisplayMember = "Baslik";
            CmbKategori.SelectedValue = 0;
        }

        private void TxtTemizleManuel_Click(object sender, EventArgs e)
        {
            TxtTanimUs.Text = ""; CmbStokUst.Clear(); TxtSeriUst.Clear(); CmbGarantiDurumuUst.Text = ""; TxtModifikasyonlarManuel.Clear();
            TxtNotlarManuel.Clear(); CmbGorevAtanacakPersonelManuel.SelectedValue = ""; CmbIslemAdimiManuel.SelectedValue = ""; TxtStokManuel.Clear();
            TxtTanimManuel.Clear();
        }

        string GorevAtama()
        {
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", infos[1].ToString(), "100-TAKIMIN ÇEKİLMESİ (AMBAR VERİ KAYIT)", DateTime.Now, "ÇEKİM İŞLEMİ TAMAMLANMIŞTIR.", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel);


            GorevAtamaPersonel gorevAtamaPersonel2 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", infos[1].ToString(), "200-MODİFİKASYON KONTROLÜ (AMBAR VERİ KAYIT)", DateTime.Now, "UYGULANMASI GEREKEN MODİFİKASYON BULUNMAMAKTADIR.", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel2);



            GorevAtamaPersonel gorevAtamaPersonel3 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", infos[1].ToString(), "300-SİPARİŞ OLUŞTURMA (AMBAR VERİ KAYIT)", DateTime.Now, LblIcSiparisNo.Text + " NOLU SİPARİŞ OLUŞTURULMUŞTUR.", "00:25:00".ConOnlyTime());
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel3);



            GorevAtamaPersonel gorevAtamaPersonel4 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", CmbGorevAtanacakPersonel.Text, CmbIslemAdimi.Text, DateTime.Now, "", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel4);

            string sure = "0 Gün " + "0 Saat " + "0 Dakika";

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", "100-TAKIMIN ÇEKİLMESİ (AMBAR VERİ KAYIT)", sure, DateTime.Now.Date);
            gorevAtamaPersonelManager.Update(gorevAtama);
            GorevAtamaPersonel messege2 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", "200-MODİFİKASYON KONTROLÜ (AMBAR VERİ KAYIT)", sure, DateTime.Now.Date);
            gorevAtamaPersonelManager.Update(messege2);
            GorevAtamaPersonel messege3 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", "300-SİPARİŞ OLUŞTURMA (AMBAR VERİ KAYIT)", sure, "00:25:00".ConOnlyTime());
            gorevAtamaPersonelManager.Update(messege3);
            return "OK";
        }
        string GorevAtamaManuel()
        {
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", infos[1].ToString(), "100-TAKIMIN ÇEKİLMESİ (AMBAR VERİ KAYIT)", DateTime.Now, "ÇEKİM İŞLEMİ TAMAMLANMIŞTIR.", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel);


            GorevAtamaPersonel gorevAtamaPersonel2 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", infos[1].ToString(), "200-MODİFİKASYON KONTROLÜ (AMBAR VERİ KAYIT)", DateTime.Now, "UYGULANMASI GEREKEN MODİFİKASYON BULUNMAMAKTADIR.", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel2);


            GorevAtamaPersonel gorevAtamaPersonel3 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", infos[1].ToString(), "300-SİPARİŞ OLUŞTURMA (AMBAR VERİ KAYIT)", DateTime.Now, LblIcSiparisNo.Text + " NOLU SİPARİŞ OLUŞTURULMUŞTUR.", "00:25:00".ConOnlyTime());
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel3);


            GorevAtamaPersonel gorevAtamaPersonel4 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", CmbGorevAtanacakPersonelManuel.Text, CmbIslemAdimiManuel.Text, DateTime.Now, "", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel4);

            string sure = "0 Gün " + "0 Saat " + "0 Dakika";

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", "100-TAKIMIN ÇEKİLMESİ (AMBAR VERİ KAYIT)", sure, DateTime.Now.Date);
            gorevAtamaPersonelManager.Update(gorevAtama);
            GorevAtamaPersonel messege2 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", "200-MODİFİKASYON KONTROLÜ (AMBAR VERİ KAYIT)", sure, DateTime.Now.Date);
            gorevAtamaPersonelManager.Update(messege2);
            GorevAtamaPersonel messege3 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", "300-SİPARİŞ OLUŞTURMA (AMBAR VERİ KAYIT)", sure, "00:25:00".ConOnlyTime());
            gorevAtamaPersonelManager.Update(messege3);
            return "OK";
        }

        void CreateFile()
        {
            string root = @"C:\DTS";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(yol))
            {
                Directory.CreateDirectory(yol);
            }
            var dosyalar = new DirectoryInfo(kaynak).GetFiles("*.docx");

            foreach (FileInfo item in dosyalar)
            {
                item.CopyTo(yol + item.Name);
            }

            taslakYolu = yol + "MP-FR-045 BO İZLEME FORMU (TEKNİK SERVİS) REV (01).docx";

            int sayac = 0;
            foreach (DataGridViewRow item in DtgMalzemeler.Rows)
            {
                string root2 = @"Z:\DTS";
                string subdir = @"Z:\DTS\BAKIM ONARIM ATOLYE\";
                string anadosya = @"Z:\DTS\BAKIM ONARIM ATOLYE\BAKIM ONARIM FORMU\";

                if (!Directory.Exists(root2))
                {
                    Directory.CreateDirectory(root2);
                }
                if (!Directory.Exists(subdir))
                {
                    Directory.CreateDirectory(subdir);
                }
                if (!Directory.Exists(anadosya))
                {
                    Directory.CreateDirectory(anadosya);
                }
                if (IcSiparisler.Count > 0)
                {
                    dosya = anadosya + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("mm_ss") + "\\";

                }
                else
                {
                    dosya = anadosya + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("mm_ss") + "\\";
                }
                DosyaYollari.Add(dosya);
                Directory.CreateDirectory(dosya);

                Application wApp = new Application();
                Documents wDocs = wApp.Documents;
                object filePath = taslakYolu;

                Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
                wDoc.Activate();

                Bookmarks wBookmarks = wDoc.Bookmarks;
                wBookmarks["StokNo"].Range.Text = item.Cells["StokNo"].Value.ToString();
                if (arizaDurumu == 0)
                {
                    wBookmarks["Bolge"].Range.Text = "AMBAR";
                }
                else
                {
                    wBookmarks["Bolge"].Range.Text = TxtBolgeAdi.Text;
                }
                wBookmarks["Proje"].Range.Text = TxtProje.Text;
                wBookmarks["Tanim"].Range.Text = item.Cells["Tanim"].Value.ToString();
                wBookmarks["Tarih"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                if (IcSiparisler.Count > 0)
                {
                    wBookmarks["IcSiparisNo"].Range.Text = IcSiparisler[sayac].ToString();
                }
                else
                {
                    wBookmarks["IcSiparisNo"].Range.Text = LblIcSiparisNo.Text;
                }

                wBookmarks["Miktar"].Range.Text = item.Cells["Miktar"].Value.ToString();
                wBookmarks["SeriNo"].Range.Text = item.Cells["SeriNo"].Value.ToString();
                wBookmarks["Tarih1"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih2"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih3"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih4"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih5"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih6"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih7"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");

                //wDoc.SaveAs2(yol + "\\" + TxtIsAkisNoTamamla.Text + ".docx"); // farklı kaydet

                if (IcSiparisler.Count > 0)
                {
                    wDoc.SaveAs2(dosya + "B_O İzleme Formu" + ".docx");
                }
                else
                {
                    wDoc.SaveAs2(dosya + "B_O İzleme Formu" + ".docx");
                }
                wDoc.Close();
                wApp.Quit(false);

                sayac++;
            }
            try
            {
                Directory.Delete(yol, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                File.Delete(taslakYolu);
            }
        }

        void CreateFileManuel()
        {
            string root = @"C:\DTS";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(yol))
            {
                Directory.CreateDirectory(yol);
            }
            var dosyalar = new DirectoryInfo(kaynak).GetFiles("*.docx");

            foreach (FileInfo item in dosyalar)
            {
                item.CopyTo(yol + item.Name);
            }
            taslakYolu = yol + "MP-FR-045 BO İZLEME FORMU (TEKNİK SERVİS) REV (01).docx";
            int sayac = 0;

            foreach (DataGridViewRow item in DtgStokList.Rows)
            {
                if (item.Cells["KayitDurumu"].Value.ConBool() == true)
                {
                    MalzemeKayit malzemeKayit = new MalzemeKayit(item.Cells["KayitDurumu"].Value.ConBool(), item.Cells["Stokno"].Value.ToString(), item.Cells["Tanim"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Durum"].Value.ToString(), item.Cells["Revizyon"].Value.ToString(), item.Cells["Miktar"].Value.ConInt(), item.Cells["TalepTarihi"].Value.ToString());

                    malzemeKayitsSecilenler.Add(malzemeKayit);
                }
            }
            int adet = 1;

            foreach (MalzemeKayit item in malzemeKayitsSecilenler)
            {
                LblIcSiparisManuel.Text = "221RWK" + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("yy") + DateTime.Now.ToString("ff");
                icSiparisNo = LblIcSiparisManuel.Text + "/" + adet;
                IcSiparisler.Add(icSiparisNo);
                adet++;
            }

            foreach (MalzemeKayit item in malzemeKayitsSecilenler)
            {
                string root2 = @"Z:\DTS";
                string subdir = @"Z:\DTS\BAKIM ONARIM ATOLYE\";
                string anadosya = @"Z:\DTS\BAKIM ONARIM ATOLYE\BAKIM ONARIM FORMU\";

                if (!Directory.Exists(root2))
                {
                    Directory.CreateDirectory(root2);
                }
                if (!Directory.Exists(subdir))
                {
                    Directory.CreateDirectory(subdir);
                }
                if (!Directory.Exists(anadosya))
                {
                    Directory.CreateDirectory(anadosya);
                }
                if (IcSiparisler.Count > 0)
                {
                    dosya = anadosya + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("mm_ss") + "\\";

                }
                else
                {
                    dosya = anadosya + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("mm_ss") + "\\";
                }
                DosyaYollari.Add(dosya);
                Directory.CreateDirectory(dosya);

                Application wApp = new Application();
                Documents wDocs = wApp.Documents;
                object filePath = taslakYolu;

                Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
                wDoc.Activate();

                Bookmarks wBookmarks = wDoc.Bookmarks;
                wBookmarks["StokNo"].Range.Text = item.Stokno;
                if (arizaDurumu == 0)
                {
                    wBookmarks["Bolge"].Range.Text = "AMBAR";
                }
                else
                {
                    wBookmarks["Bolge"].Range.Text = "YOK";
                }
                wBookmarks["Proje"].Range.Text = CmbProje.Text;
                wBookmarks["Tanim"].Range.Text = item.Tanim;
                wBookmarks["Tarih"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                if (IcSiparisler.Count > 0)
                {
                    wBookmarks["IcSiparisNo"].Range.Text = IcSiparisler[sayac].ToString();
                }
                else
                {
                    wBookmarks["IcSiparisNo"].Range.Text = LblIcSiparisManuel.Text;
                }

                wBookmarks["Miktar"].Range.Text = item.Miktar.ToString();
                wBookmarks["SeriNo"].Range.Text = item.SeriNo;
                wBookmarks["Tarih1"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih2"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih3"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih4"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih5"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih6"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih7"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");

                //wDoc.SaveAs2(yol + "\\" + TxtIsAkisNoTamamla.Text + ".docx"); // farklı kaydet

                if (IcSiparisler.Count > 0)
                {
                    string dosyaYol = dosya + "B_O İzleme Formu" + ".docx";
                    wDoc.SaveAs2(dosyaYol);
                }
                else
                {
                    wDoc.SaveAs2(dosya + "B_O İzleme Formu" + ".docx");
                }
                wDoc.Close();
                wApp.Quit(false);

                sayac++;
            }
            try
            {
                Directory.Delete(yol, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                File.Delete(taslakYolu);
            }
        }
    }
}
