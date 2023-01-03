using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
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

namespace UserInterface.Depo
{
    public partial class FrmStokGoruntule : Form
    {
        StokGirisCikisManager stokGirisCikisManager;
        //MalzemeKayitManager malzemeKayitManager;
        DepoMiktarManager depoMiktarManager;
        MalzemeManager malzemeManager;
        
        List<DepoMiktar> depoMiktars;
        string stokNo="";
        public FrmStokGoruntule()
        {
            InitializeComponent();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
            //malzemeKayitManager = MalzemeKayitManager.GetInstance();
            depoMiktarManager = DepoMiktarManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageStokGoruntule"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void FrmStokGoruntule_Load(object sender, EventArgs e)
        {
            //Display();
        }
        void Display()
        {
            /*stokGirisCıkıs = stokGirisCikisManager.GetList();
            //stokFiltired = stokGirisCıkıs;
            dataBinder.DataSource = stokGirisCıkıs.ToDataTable();
            DtgDepoBilgileri.DataSource = dataBinder;*/
            

            foreach (DataGridViewRow item in DtgDepoBilgileri.Rows)
            {
                if (item.Cells["Miktar"].Value.ConInt()==0)
                {
                    int selectedIndex = item.Index;
                    DtgDepoBilgileri.Rows.RemoveAt(selectedIndex);
                }
            }
            DtgDepoBilgileri.Columns["Secim"].Visible = false;
            DtgDepoBilgileri.Columns["Id"].Visible = false;
            DtgDepoBilgileri.Columns["StokNo"].HeaderText = "STOK NO";
            DtgDepoBilgileri.Columns["Tanim"].HeaderText = "TANIM";
            DtgDepoBilgileri.Columns["SonIslemTarihi"].HeaderText = "SON İŞLEM TARİHİ";
            DtgDepoBilgileri.Columns["SonIslemYapan"].HeaderText = "SON İŞLEM YAPAN";
            DtgDepoBilgileri.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgDepoBilgileri.Columns["DepoNo"].HeaderText = "DEPO NO";
            DtgDepoBilgileri.Columns["DepoAdresi"].HeaderText = "DEPO ADRESİ";
            DtgDepoBilgileri.Columns["DepoLokasyon"].HeaderText = "DEPO LOKASYON";
            DtgDepoBilgileri.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgDepoBilgileri.Columns["LotNo"].HeaderText = "LOT NO";
            DtgDepoBilgileri.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgDepoBilgileri.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            DtgDepoBilgileri.Columns["RezerveDurumu"].HeaderText = "REZERVE DURUMU";
            DtgDepoBilgileri.Columns["RezerveId"].HeaderText = "REZERVE EDİLEN KİMLİK";

            DtgDepoBilgileri.Columns["DepoLokasyon"].DisplayIndex = 8;
            TxtTop.Text = DtgDepoBilgileri.RowCount.ToString();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtStokNo.Text=="")
            {
                MessageBox.Show("Lütfen Stok No Bilgisini Doldurunuz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            DtgMalzemeBilgisi.DataSource = malzemeManager.MalzemeGetList(TxtStokNo.Text);

            DtgMalzemeBilgisi.Columns["Id"].Visible = false;
            DtgMalzemeBilgisi.Columns["StokNo"].HeaderText = "STOK NO";
            DtgMalzemeBilgisi.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzemeBilgisi.Columns["Birim"].Visible = false;
            DtgMalzemeBilgisi.Columns["TedarikciFirma"].Visible = false;
            DtgMalzemeBilgisi.Columns["OnarimDurumu"].HeaderText = "ONARIM DURUMU";
            DtgMalzemeBilgisi.Columns["OnarimYeri"].HeaderText = "ONARIM YERİ";
            DtgMalzemeBilgisi.Columns["ParcaSinifi"].HeaderText = "PARÇA SINIFI";
            DtgMalzemeBilgisi.Columns["TedarikTuru"].Visible = false;
            DtgMalzemeBilgisi.Columns["AlternatifParca"].Visible = false;
            DtgMalzemeBilgisi.Columns["Aciklama"].Visible = false;
            DtgMalzemeBilgisi.Columns["DosyaYolu"].Visible = false;
            DtgMalzemeBilgisi.Columns["SistemStokNo"].Visible = false;
            DtgMalzemeBilgisi.Columns["SistemTanimi"].Visible = false;
            DtgMalzemeBilgisi.Columns["SistemSorumlusu"].Visible = false;
            DtgMalzemeBilgisi.Columns["IslemYapan"].Visible = false;
            DtgMalzemeBilgisi.Columns["TakipDurumu"].Visible = false;
            DtgMalzemeBilgisi.Columns["UstStok"].Visible = false;
            DtgMalzemeBilgisi.Columns["UstTanim"].Visible = false;
            DtgMalzemeBilgisi.Columns["BenzersizId"].Visible = false;
            /*DtgMalzemeBilgisi.DataSource = malzemeManager.MalzemeGetList(TxtStokNo.Text);

            DtgMalzemeBilgisi.Columns["Id"].Visible = false;
            DtgMalzemeBilgisi.Columns["StokNo"].HeaderText = "STOK NO";
            DtgMalzemeBilgisi.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzemeBilgisi.Columns["Birim"].Visible = false;
            DtgMalzemeBilgisi.Columns["TedarikciFirma"].Visible = false;
            DtgMalzemeBilgisi.Columns["OnarimDurumu"].HeaderText = "ONARIM DURUMU";
            DtgMalzemeBilgisi.Columns["OnarimYeri"].HeaderText = "ONARIM YERİ";
            DtgMalzemeBilgisi.Columns["TedarikTuru"].Visible = false;
            DtgMalzemeBilgisi.Columns["ParcaSinifi"].HeaderText = "PARÇA SINIFI";
            DtgMalzemeBilgisi.Columns["AlternatifParca"].Visible = false;
            DtgMalzemeBilgisi.Columns["Aciklama"].Visible = false;
            DtgMalzemeBilgisi.Columns["DosyaYolu"].Visible = false;
            DtgMalzemeBilgisi.Columns["SistemSorumlusu"].Visible = false;
            DtgMalzemeBilgisi.Columns["SistemStokNo"].Visible = false;
            DtgMalzemeBilgisi.Columns["SistemTanimi"].Visible = false;
            DtgMalzemeBilgisi.Columns["IslemYapan"].Visible = false;
            DtgMalzemeBilgisi.Columns["TakipDurumu"].Visible = false;
            DtgMalzemeBilgisi.Columns["UstStok"].Visible = false;
            DtgMalzemeBilgisi.Columns["UstTanim"].Visible = false;
            DtgMalzemeBilgisi.Columns["BenzersizId"].Visible = false;*/

            double birimFiyat = stokGirisCikisManager.DepoBirimFiyat(TxtStokNo.Text);

            BirimFiyat.Text = birimFiyat.ToString("C2");
        }

        private void DtgMalzemeBilgisi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgMalzemeBilgisi.CurrentRow == null)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Stok Bilgisi Giriniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            stokNo = DtgMalzemeBilgisi.CurrentRow.Cells["Stokno"].Value.ToString();
            depoMiktars = depoMiktarManager.GetList(stokNo,"TÜM");

            dataBinder.DataSource = depoMiktars.ToDataTable();
            DtgDepoBilgileri.DataSource = dataBinder;
            //TxtTop.Text = DtgDepoBilgileri.RowCount.ToString();
            Display();
            Toplamlar();
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgDepoBilgileri.Rows.Count; ++i)
            {
                /*if (DtgDepoBilgileri.Rows[i].Cells[4].Value.ConInt()==0)
                {
                    toplam += Convert.ToDouble(DtgDepoBilgileri.Rows[i].Cells[13].Value);
                }*/
                toplam += Convert.ToDouble(DtgDepoBilgileri.Rows[i].Cells[5].Value);
            }
            LblToplamMiktar.Text = toplam.ToString();
        }
    }
}
