using Business.Concreate;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarimAtolye;
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

namespace UserInterface.BakımOnarım
{
    public partial class FrmBOAtolye : Form
    {
        AtolyeManager atolyeManager;
        AtolyeMalzemeManager atolyeMalzemeManager;
        IslemAdimlariManager islemAdimlariManager;
        PersonelKayitManager kayitManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;

        List<AtolyeMalzeme> atolyeMalzemes;

        int id;
        string siparisNo = "";
        public FrmBOAtolye()
        {
            InitializeComponent();
            atolyeManager = AtolyeManager.GetInstance();
            atolyeMalzemeManager = AtolyeMalzemeManager.GetInstance();
            islemAdimlariManager = IslemAdimlariManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
        }

        private void FrmBOAtolye_Load(object sender, EventArgs e)
        {
            IslemAdimlari();
            Personeller();
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
        void IslemAdimlari()
        {
            CmbIslemAdimi.DataSource = islemAdimlariManager.GetList("BAKIM ONARIM ATOLYE");
            CmbIslemAdimi.ValueMember = "Id";
            CmbIslemAdimi.DisplayMember = "IslemaAdimi";
            CmbIslemAdimi.SelectedValue = 24;
        }
        void Personeller()
        {
            CmbGorevAtanacakPersonel.DataSource = kayitManager.PersonelAdSoyad();
            CmbGorevAtanacakPersonel.ValueMember = "Id"; 
            CmbGorevAtanacakPersonel.DisplayMember = "Adsoyad";
            CmbGorevAtanacakPersonel.SelectedValue = -1;
            CmbGorevAtanacakPersonel.Text = "MEHMET YILDIRIM";
        }

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

            LblIcSiparisNo.Text = DateTime.Now.ToString("yyyy") + "BO" + TxtAbfFormNo.Text ;

        }
        void Temizle()
        {
            TxtStokNoUst.Clear(); TxtSeriNoUst.Clear(); TxtGarantiDurumuUst.Clear(); TxtBildirimNo.Clear(); TxtScrmNo.Clear(); TxtKategori.Clear(); TxtBolgeAdi.Clear(); TxtProje.Clear(); TxtStokNo.Clear(); TxtTanim.Clear(); TxtSeriNo.Clear(); TxtRevizyon.Clear();
            TxtMiktar.Clear(); TxtDurum.Clear(); TxtBildirilenAriza.Clear(); TxtModifikasyonlar.Clear(); TxtNotlar.Clear();    CmbGorevAtanacakPersonel.SelectedValue = ""; CmbIslemAdimi.SelectedValue = "";
        }
        void DataDisplay()
        {
            atolyeMalzemes = atolyeMalzemeManager.GetList(TxtAbfFormNo.Text.ConInt());
            DtgMalzemeler.DataSource = atolyeMalzemes.ToDataTable();
            LblToplam.Text = DtgMalzemeler.RowCount.ToString();

            

            DtgMalzemeler.Columns["Id"].Visible = false;
            DtgMalzemeler.Columns["FormNo"].Visible = false;
            DtgMalzemeler.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            DtgMalzemeler.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzemeler.Columns["SokulenSeriNo"].HeaderText = "SERİ NO";
            DtgMalzemeler.Columns["Durum"].HeaderText = "DURUM";
            DtgMalzemeler.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgMalzemeler.Columns["Miktar"].HeaderText = "MİKAR";
            DtgMalzemeler.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzemeler.Columns["TalepTarihi"].HeaderText = "TALEP TARİHİ";
            DtgMalzemeler.Columns["SiparisNo"].Visible = false;
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtStokNoUst.Text=="" || DtgMalzemeler.RowCount==0)
            {
                MessageBox.Show("Lütfen Öncelikle Tüm Bilgileri Eksiksiz Doldurunuz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (CmbGorevAtanacakPersonel.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Görev Atanacak Personel Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbIslemAdimi.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İşlem Adımı Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbIslemAdimi.Text != "400-GÖZ DENETİMİ")
            {
                MessageBox.Show("Lütfen Öncelikle İşlem Adımı Bilgisini 400-GÖZ DENETİMİ Olarak Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                siparisNo = Guid.NewGuid().ToString();

                Atolye atolye = new Atolye(TxtAbfFormNo.Text.ConInt(), TxtStokNoUst.Text, TxtTanimUst.Text, TxtSeriNoUst.Text, TxtGarantiDurumuUst.Text, TxtBildirimNo.Text, TxtScrmNo.Text, TxtKategori.Text, TxtBolgeAdi.Text, TxtProje.Text, TxtBildirilenAriza.Text, LblIcSiparisNo.Text, DtgCekilmeTarihi.Value, DtgSiparisTarihi.Value, TxtModifikasyonlar.Text, TxtNotlar.Text, CmbIslemAdimi.Text, siparisNo);

                string mesaj = atolyeManager.Add(atolye);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                foreach (DataGridViewRow item in DtgMalzemeler.Rows)
                {
                    AtolyeMalzeme atolyeMalzeme = new AtolyeMalzeme(item.Cells["FormNo"].Value.ConInt(), item.Cells["StokNo"].Value.ToString(),
                        item.Cells["Tanim"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Durum"].Value.ToString(), 
                        item.Cells["Revizyon"].Value.ToString(), item.Cells["Miktar"].Value.ConDouble(), item.Cells["TalepTarihi"].Value.ConTime(),siparisNo);

                    string mesaj2 = atolyeMalzemeManager.Add(atolyeMalzeme);

                    if (mesaj2!="OK")
                    {
                        MessageBox.Show(mesaj2,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                }

                Atolye atolye1 = atolyeManager.Get(LblIcSiparisNo.Text);
                id = atolye1.Id;

                string kontrol =  GorevAtama();
                if (kontrol!="OK")
                {
                    MessageBox.Show(kontrol, "Hata", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Temizle();
                DtgMalzemeler.DataSource = null;
            }
        }
        string GorevAtama()
        {
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id,"BAKIM ONARIM ATÖLYE", CmbGorevAtanacakPersonel.Text, CmbIslemAdimi.Text,DateTime.Now);

            string kontrol = gorevAtamaPersonelManager.Add(gorevAtamaPersonel);
            if (kontrol!="OK")
            {
                return kontrol;
            }
            return "OK";
        }
    }
}
