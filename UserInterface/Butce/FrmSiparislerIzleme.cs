using Business.Concreate.Butce;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity.Butce;
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

namespace UserInterface.Butce
{
    public partial class FrmSiparislerIzleme : Form
    {
        SiparislerManager siparislerManager;
        PersonelKayitManager personelKayitManager;
        IstenAyrilisManager istenAyrilisManager;
        AracZimmetiManager aracZimmetiManager;
        SiparislerPersonelManager siparislerPersonelManager; 

        List<PersonelKayit> personelKayits;
        List<IstenAyrilis> istenAyrilis;
        List<AracZimmeti> aracZimmetis;
        List<PersonelKayit> personeller = new List<PersonelKayit>();
        List<SiparislerPersonel> siparislerPersonels;


        string siparisNo;
        public FrmSiparislerIzleme()
        {
            InitializeComponent();
            siparislerManager = SiparislerManager.GetInstance();
            personelKayitManager = PersonelKayitManager.GetInstance();
            istenAyrilisManager = IstenAyrilisManager.GetInstance();
            aracZimmetiManager = AracZimmetiManager.GetInstance();
            siparislerPersonelManager = SiparislerPersonelManager.GetInstance();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSiparisIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void FrmSiparislerIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }
        void DataDisplay()
        {
            DtgMevcutKadro.DataSource = siparislerManager.GetList();
            DtgMevcutKadro.Columns["Id"].Visible = false;
            DtgMevcutKadro.Columns["Personelsayisi"].Visible = false;
            DtgMevcutKadro.Columns["Benzersiz"].Visible = false;
            DtgMevcutKadro.Columns["MevcutPersonel"].HeaderText = "MEVCUT PERSONEL";
            DtgMevcutKadro.Columns["Proje"].HeaderText = "PROJE";
            DtgMevcutKadro.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgMevcutKadro.Columns["Personelyonetici"].HeaderText = "PERSONEL YÖNETİCİ";
            DtgMevcutKadro.Columns["Personel"].HeaderText = "PERSONEL";
            DtgMevcutKadro.Columns["Personeldepo"].HeaderText = "PERSONEL DEPO";
            DtgMevcutKadro.Columns["Personeltoplam"].HeaderText = "PERSONEL TOPLAM";
            DtgMevcutKadro.Columns["Yoneticiarac"].HeaderText = "YÖNETİCİ ARAÇ";
            DtgMevcutKadro.Columns["Araziarac"].HeaderText = "ARAZİ ARAÇ";
            DtgMevcutKadro.Columns["Toplamarac"].HeaderText = "TOPLAM ARAÇ";
            DtgMevcutKadro.Columns["Sat"].HeaderText = "SAT";
            DtgMevcutKadro.Columns["Donemyil"].HeaderText = "DÖNEM YIL";
            DtgMevcutKadro.Columns["Satkategori"].HeaderText = "SAT KATEGORİ";
            DtgMevcutKadro.Columns["MevcutPersonel"].DisplayIndex = 13;
            LblTop.Text = DtgMevcutKadro.RowCount.ToString();


            //Toplamlar();
        }

        private void DtgMevcutKadro_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgMevcutKadro.CurrentRow == null)
            {
                return;
            }
            siparisNo = DtgMevcutKadro.CurrentRow.Cells["Siparisno"].Value.ToString();
            DtgPersoneller.Rows.Clear();
            DtgAraclar.DataSource = null;
            SiparisPersoneller();
            SiparisAraclar();
        }
        void SiparisPersoneller()
        {
            siparislerPersonels = siparislerPersonelManager.GetList(siparisNo);
            if (siparislerPersonels==null)
            {
                personelKayits = personelKayitManager.SiparisPersonel(siparisNo);
                foreach (PersonelKayit item in personelKayits)
                {
                    DtgPersoneller.Rows.Add();
                    int sonSatir = DtgPersoneller.RowCount - 1;
                    DtgPersoneller.Rows[sonSatir].Cells["AdiSoyadi"].Value = item.Adsoyad;
                    DtgPersoneller.Rows[sonSatir].Cells["Unvani"].Value = item.Isunvani;
                    DtgPersoneller.Rows[sonSatir].Cells["Bolumu"].Value = item.Sirketbolum;
                    DtgPersoneller.Rows[sonSatir].Cells["Durum"].Value = "ÇALIŞAN";
                }
            }
            else
            {

                foreach (SiparislerPersonel item in siparislerPersonels)
                {

                    DtgPersoneller.Rows.Add();
                    int sonSatir = DtgPersoneller.RowCount - 1;
                    DtgPersoneller.Rows[sonSatir].Cells["AdiSoyadi"].Value = item.PersonelAdi;
                    DtgPersoneller.Rows[sonSatir].Cells["Unvani"].Value = item.Unvani;
                    DtgPersoneller.Rows[sonSatir].Cells["Bolumu"].Value = item.Bolumu;
                    DtgPersoneller.Rows[sonSatir].Cells["Durum"].Value = "ÇALIŞAN";
                }
            }

            istenAyrilis = istenAyrilisManager.SiparisPersoneller(siparisNo);
            foreach (IstenAyrilis item in istenAyrilis)
            {
                DtgPersoneller.Rows.Add();
                int sonSatir = DtgPersoneller.RowCount - 1;
                DtgPersoneller.Rows[sonSatir].Cells["AdiSoyadi"].Value = item.Adsoyad;
                DtgPersoneller.Rows[sonSatir].Cells["Unvani"].Value = item.Isunvani;
                DtgPersoneller.Rows[sonSatir].Cells["Bolumu"].Value = item.Sirketbolum;
                DtgPersoneller.Rows[sonSatir].Cells["Durum"].Value = "AYRILAN";
            }
            LblPersonelTop.Text = DtgPersoneller.RowCount.ToString();
            //personelKayits.AddRange(istenAyrilis);


        }
        void SiparisAraclar()
        {
            aracZimmetis = aracZimmetiManager.SiparisArac(siparisNo);
            binderDataArac.DataSource = aracZimmetis.ToDataTable();
            DtgAraclar.DataSource = binderDataArac;

            DtgAraclar.Columns["Id"].Visible = false;
            DtgAraclar.Columns["IsAkisNo"].Visible = false;
            DtgAraclar.Columns["Plaka"].HeaderText = "PLAKA";
            DtgAraclar.Columns["Marka"].Visible = false;
            DtgAraclar.Columns["Model"].Visible = false;
            DtgAraclar.Columns["MotorNo"].Visible = false;
            DtgAraclar.Columns["SaseNo"].Visible = false;
            DtgAraclar.Columns["MulkiyetBilgileri"].HeaderText = "MÜLKİYET BİLGİLERİ";
            DtgAraclar.Columns["SiparisNo"].Visible = false;
            DtgAraclar.Columns["ProjeTahsisTarihi"].Visible = false;
            DtgAraclar.Columns["PersonelAd"].Visible = false;
            DtgAraclar.Columns["SicilNo"].Visible = false;
            DtgAraclar.Columns["MasrafYeriNo"].Visible = false;
            DtgAraclar.Columns["MasrafYeri"].Visible = false;
            DtgAraclar.Columns["MasYerSor"].Visible = false;
            DtgAraclar.Columns["Bolum"].HeaderText = "BÖLÜMÜ";
            DtgAraclar.Columns["AktarimTarihi"].Visible = false;
            DtgAraclar.Columns["Gerekce"].Visible = false;
            DtgAraclar.Columns["DosyYolu"].Visible = false;
            DtgAraclar.Columns["Km"].Visible = false;
            DtgAraclar.Columns["Durum"].HeaderText = "MÜLKİYET BİLGİLERİ";
            LblAracTop.Text = DtgAraclar.RowCount.ToString();
        }

        private void DtgPersoneller_FilterStringChanged(object sender, EventArgs e)
        {
            binderData.Filter = DtgPersoneller.FilterString;

        }

        private void DtgPersoneller_SortStringChanged(object sender, EventArgs e)
        {
            binderData.Sort = DtgPersoneller.SortString;
        }

        private void DtgAraclar_FilterStringChanged(object sender, EventArgs e)
        {
            binderDataArac.Filter = DtgAraclar.FilterString;
            LblAracTop.Text = DtgAraclar.RowCount.ToString();
        }

        private void DtgAraclar_SortStringChanged(object sender, EventArgs e)
        {
            binderDataArac.Sort = DtgAraclar.SortString;
        }
    }
}
