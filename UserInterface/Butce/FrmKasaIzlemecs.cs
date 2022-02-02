using Business.Concreate.Butce;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity.Butce;
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
using UserInterface.STS;

namespace UserInterface.Butce
{
    public partial class FrmKasaIzlemecs : Form
    {
        AvansManager avansManager;
        KasaDurumManager kasaDurumManager;
        TamamlananManager tamamlananManager;



        string dosyaYolu = "";
        List<Avans> avans = new List<Avans>();
        List<Tamamlanan> tamamlanans;
        public FrmKasaIzlemecs()
        {
            InitializeComponent();
            avansManager = AvansManager.GetInstance();
            kasaDurumManager = KasaDurumManager.GetInstance();
            tamamlananManager = TamamlananManager.GetInstance();
        }

        private void FrmKasaIzlemecs_Load(object sender, EventArgs e)
        {
            DataDisplay();
            KasaDurum();
            TamamlananSatlar();

        }
        void KasaDurum()
        {
            KasaDurum kasaDurum =  kasaDurumManager.Get(1);
            LblGelir.Text = kasaDurum.KasaGelir.ToString("C2");
            LblGider.Text = kasaDurum.KasaGider.ToString("C2");
            LblKalan.Text = kasaDurum.KasaKalan.ToString("C2");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageKasaIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void Toplamlar2()
        {
            double toplam = 0;
            for (int i = 0; i < DtgTamamlananSatlar.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgTamamlananSatlar.Rows[i].Cells[17].Value);
            }
            LblSatTop.Text = toplam.ToString("C2");
            TxtTopKayitSat.Text = DtgTamamlananSatlar.RowCount.ToString();
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgList.Rows[i].Cells[9].Value);
            }
            LblGenelTop.Text = toplam.ToString("C2");
        }
        void DataDisplay()
        {
            avans = avansManager.GetList();
            dataBinder.DataSource = avans.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Donem"].HeaderText = "DÖNEM";
            DtgList.Columns["IstemeTarihi"].HeaderText = "İSTEME TARİHİ";
            DtgList.Columns["HavaleTarihi"].HeaderText = "HAVALE TARİHİ";
            DtgList.Columns["Gonderen"].HeaderText = "GÖNDEREN";
            DtgList.Columns["HesapNo"].HeaderText = "İŞ AVANSIN YATTIĞI HESAP NO";
            DtgList.Columns["IbanNo"].HeaderText = "IBAN NO";
            DtgList.Columns["HesapSahibi"].HeaderText = "HESAP SAHİBİ";
            DtgList.Columns["Tutar"].HeaderText = "GELEN HAVALE TUTARI";
            DtgList.Columns["DosyaYolu"].Visible = false;
            Toplamlar();

        }
        void DataDisplayTamamlananlar()
        {
            DtgTamamlananSatlar.Columns["Id"].Visible = false;
            DtgTamamlananSatlar.Columns["Satno"].HeaderText = "SAT_NO";
            DtgTamamlananSatlar.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgTamamlananSatlar.Columns["Masrafyeri"].Visible = false;
            DtgTamamlananSatlar.Columns["Talepeden"].Visible = false;
            DtgTamamlananSatlar.Columns["Bolum"].Visible = false;
            DtgTamamlananSatlar.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgTamamlananSatlar.Columns["Abfform"].HeaderText = "ABF FORM NO";
            DtgTamamlananSatlar.Columns["Istenentarih"].HeaderText = "İSTENEN TARİH";
            DtgTamamlananSatlar.Columns["Tamamlanantarih"].HeaderText = "TAMAMLANAN TARİH";
            DtgTamamlananSatlar.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgTamamlananSatlar.Columns["Butcekodukalemi"].HeaderText = "BÜTÇE KODU KALEMİ";
            DtgTamamlananSatlar.Columns["Satbirim"].Visible = false;
            DtgTamamlananSatlar.Columns["Harcamaturu"].Visible = false;
            DtgTamamlananSatlar.Columns["Belgeturu"].Visible = false;
            DtgTamamlananSatlar.Columns["Belgenumarasi"].Visible = false;
            DtgTamamlananSatlar.Columns["Belgetarihi"].Visible = false;
            DtgTamamlananSatlar.Columns["Faturaedilecekfirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgTamamlananSatlar.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgTamamlananSatlar.Columns["Masrafyerino"].Visible = false;
            DtgTamamlananSatlar.Columns["Harcanantutar"].HeaderText = "HARCANAN TUTAR";
            DtgTamamlananSatlar.Columns["Dosyayolu"].Visible = false;
            DtgTamamlananSatlar.Columns["Siparisno"].Visible = false;
            DtgTamamlananSatlar.Columns["Ucteklif"].Visible = false;
            DtgTamamlananSatlar.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgTamamlananSatlar.Columns["Donem"].DisplayIndex = 3;
            DtgTamamlananSatlar.Columns["Donem"].HeaderText = "DÖNEM";
            DtgTamamlananSatlar.Columns["Proje"].HeaderText = "PROJE";
            DtgTamamlananSatlar.Columns["SatOlusturmaTuru"].Visible = false;
            DtgTamamlananSatlar.Columns["SatinAlinanFirma"].Visible = false;
            DtgTamamlananSatlar.Columns["HarcamaYapan"].Visible = false;

        }
        void TamamlananSatlar()
        {
            tamamlanans = tamamlananManager.GetListDirektorluk();
            dataBinder2.DataSource = tamamlanans.ToDataTable();
            DtgTamamlananSatlar.DataSource = dataBinder2;
            DataDisplayTamamlananlar();
            Toplamlar2();
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }

            dosyaYolu = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            webBrowser2.Navigate(dosyaYolu);
        }
    }
}
