using Business;
using Business.Concreate.BakimOnarim;
using Business.Concreate.STS;
using DataAccess;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Office2010.Excel;
using Entity;
using Entity.BakimOnarim;
using Entity.STS;
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
using UserInterface.Ana_Sayfa;
using UserInterface.STS;

namespace UserInterface.BakımOnarım
{
    public partial class FrmDtfHazirlanacaklar : Form
    {
        IsAkisNoManager isAkisNoManager;
        ComboManager comboManager;
        AltYukleniciManager altYukleniciManager;
        AbfMalzemeManager abfMalzemeManager;
        ArizaKayitManager arizaKayitManager;

        List<AbfMalzeme> abfMalzemes;
        bool start = false;
        public object[] infos;
        string donem, comboAd = "";
        int id = 0;
        int arizaId = 0;
        public FrmDtfHazirlanacaklar()
        {
            InitializeComponent();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            altYukleniciManager = AltYukleniciManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
        }

        private void FrmOkfKontrol_Load(object sender, EventArgs e)
        {
            DataDisplay();
            IsAkisNo();
            TalebiOlusturan();
            IsKategorisi();
            AltYukleniciFirma();
            start = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDtfHazirlanacaklar"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void DataDisplay()
        {
            abfMalzemes = new List<AbfMalzeme>();
            dataBinderOto.DataSource = null;
            abfMalzemes = abfMalzemeManager.DepoyaTeslimEdilecekMalzemeList("ALT YÜKLENİCİ FİRMADA");

            dataBinderOto.DataSource = abfMalzemes.ToDataTable();
            DtgList.DataSource = dataBinderOto;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["BenzersizId"].Visible = false;
            DtgList.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            DtgList.Columns["SokulenTanim"].HeaderText = "TANIM";
            DtgList.Columns["SokulenSeriNo"].HeaderText = "SERİ NO";
            DtgList.Columns["SokulenMiktar"].HeaderText = "MİKTAR";
            DtgList.Columns["SokulenBirim"].HeaderText = "BİRİM";
            DtgList.Columns["SokulenCalismaSaati"].Visible = false;
            DtgList.Columns["SokulenRevizyon"].HeaderText = "REVİZYON";
            DtgList.Columns["CalismaDurumu"].Visible = false;
            DtgList.Columns["FizikselDurum"].Visible = false;
            DtgList.Columns["TakilanStokNo"].Visible = false;
            DtgList.Columns["TakilanTanim"].Visible = false;
            DtgList.Columns["TakilanSeriNo"].Visible = false;
            DtgList.Columns["TakilanMiktar"].Visible = false;
            DtgList.Columns["TakilanBirim"].Visible = false;
            DtgList.Columns["TakilanCalismaSaati"].Visible = false;
            DtgList.Columns["TakilanRevizyon"].Visible = false;
            DtgList.Columns["TeminDurumu"].Visible = false;
            DtgList.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgList.Columns["AbTarihSaat"].Visible = false;
            DtgList.Columns["TemineAtilamTarihi"].Visible = false;
            DtgList.Columns["MalzemeDurumu"].Visible = false;
            DtgList.Columns["MalzemeIslemAdimi"].Visible = false;
            DtgList.Columns["SokulenTeslimDurum"].HeaderText = "MALZEME TESLİM DURUMU";
            DtgList.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgList.Columns["BolgeSorumlusu"].HeaderText = "BÖLGE SORUMLUSU";
            DtgList.Columns["YapilacakIslem"].HeaderText = "YAPILACAK İŞLEM";
            DtgList.Columns["YerineMalzemeTakilma"].HeaderText = "YERİNE MALZEME TAKILDI MI?";
            DtgList.Columns["DosyaYolu"].Visible = false;

            DtgList.Columns["SokulenTeslimDurum"].DisplayIndex = 1;
            DtgList.Columns["SokulenStokNo"].DisplayIndex = 2;
            DtgList.Columns["SokulenTanim"].DisplayIndex = 3;
            DtgList.Columns["SokulenSeriNo"].DisplayIndex = 4;
            DtgList.Columns["SokulenRevizyon"].DisplayIndex = 5;
            DtgList.Columns["SokulenMiktar"].DisplayIndex = 6;
            DtgList.Columns["SokulenBirim"].DisplayIndex = 7;
            DtgList.Columns["BolgeAdi"].DisplayIndex = 8;
            DtgList.Columns["AbfNo"].DisplayIndex = 9;
            DtgList.Columns["YapilacakIslem"].DisplayIndex = 10;
            DtgList.Columns["BolgeSorumlusu"].DisplayIndex = 11;

            TxtTop.Text = DtgList.RowCount.ToString();
        }

        public void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        void TalebiOlusturan()
        {
            TalepEden.Text = infos[1].ToString();
            LblKayitTarihi.Text = DateTime.Now.ToString("dd.MM.yyyy");
            donem = FrmHelper.DonemControl(DateTime.Now);

            string[] array = donem.Split(' ');

            CmbDonemAy.Text = array[0].ToString();
            CmbDonemYil.Text = array[1].ToString();
        }
        public void IsKategorisi()
        {
            CmbIsKategorisi.DataSource = comboManager.GetList("IS_KATEGORISI");
            CmbIsKategorisi.ValueMember = "Id";
            CmbIsKategorisi.DisplayMember = "Baslik";
            CmbIsKategorisi.SelectedValue = 0;
        }
        void AltYukleniciFirma()
        {
            CmbAltYukleniciFirma.DataSource = altYukleniciManager.GetList(0);
            CmbAltYukleniciFirma.ValueMember = "Id";
            CmbAltYukleniciFirma.DisplayMember = "Firmaadi";
            CmbAltYukleniciFirma.SelectedValue = 0;
        }

        private void CmbAltYukleniciFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            if (CmbAltYukleniciFirma.SelectedIndex == -1)
            {
                LblFirmaSorumlusu.Text = "00";
                return;
            }
            id = CmbAltYukleniciFirma.SelectedValue.ConInt();
            AltYuklenici altYukleniciFirma = altYukleniciManager.Get(id);
            LblFirmaSorumlusu.Text = altYukleniciFirma.Personeladi;
        }

        private void BtnAltYukFirmaEkle_Click(object sender, EventArgs e)
        {
            FrmAltYukleniciFirma frmBolgeler = new FrmAltYukleniciFirma();
            frmBolgeler.button5.Visible = false;
            frmBolgeler.ShowDialog();
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            arizaId = DtgList.CurrentRow.Cells["BenzersizId"].Value.ConInt();
            LblBolgeAdi.Text = DtgList.CurrentRow.Cells["BolgeAdi"].Value.ToString();
            ArizaKayit arizaKayit = arizaKayitManager.GetId(arizaId);
            TxtIsinTanimi.Text = arizaKayit.BildirilenAriza;
        }

        private void BtnIsinTanimiEkle_Click(object sender, EventArgs e)
        {
            comboAd = "IS_KATEGORISI";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }
    }
}
