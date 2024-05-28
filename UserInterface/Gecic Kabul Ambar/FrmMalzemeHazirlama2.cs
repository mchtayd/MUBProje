using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.Depo;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity.BakimOnarim;
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

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmMalzemeHazirlama2 : Form
    {
        ArizaKayitManager arizaKayitManager;
        AbfMalzemeManager abfMalzemeManager;
        DepoMiktarManager depoMiktarManager;
        MalzemeManager malzemeManager;
        SatDataGridview1Manager satDataGridview1Manager;
        StokGirisCikisManager stokGirisCikisManager;
        FiyatTeklifiAlManager fiyatTeklifiAlManager;
        DepoKayitManagercs depoKayitManagercs;
        DepoKayitLokasyonManager depoKayitLokasyonManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        MalzemeKayitManager malzemeKayitManager;

        public object[] infos;

        List<ArizaKayit> arizaKayits;
        List<AbfMalzeme> abfMalzemes;
        List<AbfMalzeme> abfMalzemesSatinAlma;
        List<AbfMalzeme> abfMalzemesAselsan;
        List<DepoMiktar> depoMiktars;
        List<AbfMalzeme> depoMiktarsTotal;
        int id, mlzId, abfNo, mevcutMiktar, miktar, malzemeId;
        public string seciliStok, aciklama = "";

        

        string stokNo, malzemeDurumu, seriNo, revizyon, tanim, birim, lotNo;

        

        bool start, miktarKontrol = false;

        public FrmMalzemeHazirlama2()
        {
            InitializeComponent();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            depoMiktarManager = DepoMiktarManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
            fiyatTeklifiAlManager = FiyatTeklifiAlManager.GetInstance();
            depoKayitManagercs = DepoKayitManagercs.GetInstance();
            depoKayitLokasyonManager = DepoKayitLokasyonManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
        }

        private void FrmMalzemeHazirlama2_Load(object sender, EventArgs e)
        {
            abfMalzemes = abfMalzemeManager.TeminGetList2();
            dataBinder1.DataSource = abfMalzemes.ToDataTable();
            DtgArizaKayitlari.DataSource = dataBinder1;

            DtgArizaKayitlari.Columns["Id"].Visible = false;
            DtgArizaKayitlari.Columns["BenzersizId"].Visible = false;
            DtgArizaKayitlari.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            DtgArizaKayitlari.Columns["SokulenTanim"].HeaderText = "TANIM";
            DtgArizaKayitlari.Columns["SokulenSeriNo"].HeaderText = "SERİ/LOT NO";
            DtgArizaKayitlari.Columns["SokulenMiktar"].HeaderText = "MİKTAR";
            DtgArizaKayitlari.Columns["SokulenBirim"].HeaderText = "BİRİM";
            DtgArizaKayitlari.Columns["SokulenCalismaSaati"].Visible = false;
            DtgArizaKayitlari.Columns["SokulenRevizyon"].HeaderText = "REVİZYON";
            DtgArizaKayitlari.Columns["CalismaDurumu"].Visible = false;
            DtgArizaKayitlari.Columns["FizikselDurum"].Visible = false;
            DtgArizaKayitlari.Columns["YapilacakIslem"].HeaderText = "YAPILACAK İŞLEM";
            DtgArizaKayitlari.Columns["TakilanStokNo"].Visible = false;
            DtgArizaKayitlari.Columns["TakilanTanim"].Visible = false;
            DtgArizaKayitlari.Columns["TakilanSeriNo"].Visible = false;
            DtgArizaKayitlari.Columns["TakilanMiktar"].Visible = false;
            DtgArizaKayitlari.Columns["TakilanBirim"].Visible = false;
            DtgArizaKayitlari.Columns["TakilanCalismaSaati"].Visible = false;
            DtgArizaKayitlari.Columns["TakilanRevizyon"].Visible = false;
            DtgArizaKayitlari.Columns["TeminDurumu"].Visible = false;
            DtgArizaKayitlari.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgArizaKayitlari.Columns["AbTarihSaat"].HeaderText = "TALEP TARİHİ";
            DtgArizaKayitlari.Columns["TemineAtilamTarihi"].HeaderText = "TEMİNE ATILMA TARİHİ";
            DtgArizaKayitlari.Columns["MalzemeDurumu"].Visible = false;
            DtgArizaKayitlari.Columns["MalzemeIslemAdimi"].HeaderText = "İŞLEM DURUMU";
            DtgArizaKayitlari.Columns["SokulenTeslimDurum"].Visible = false;
            DtgArizaKayitlari.Columns["BolgeAdi"].Visible = false;
            DtgArizaKayitlari.Columns["BolgeSorumlusu"].Visible = false;

            TxtTop2.Text = DtgArizaKayitlari.RowCount.ToString();

            DtgArizaKayitlari.Columns["AbfNo"].DisplayIndex = 0;

            DataDisplay();
        }
        void DataDisplay()
        {
            abfMalzemesAselsan = abfMalzemeManager.DepoTeminDurumu("ASELSAN TEMİNİ BEKLİYOR");
            dataBinder2.DataSource = abfMalzemesAselsan.ToDataTable();
            DtgStoktaOlmayanAselsan.DataSource = dataBinder2;

            DtgStoktaOlmayanAselsan.Columns["Id"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["BenzersizId"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            DtgStoktaOlmayanAselsan.Columns["SokulenTanim"].HeaderText = "TANIM";
            DtgStoktaOlmayanAselsan.Columns["SokulenSeriNo"].HeaderText = "SERİ/LOT NO";
            DtgStoktaOlmayanAselsan.Columns["SokulenMiktar"].HeaderText = "MİKTAR";
            DtgStoktaOlmayanAselsan.Columns["SokulenBirim"].HeaderText = "BİRİM";
            DtgStoktaOlmayanAselsan.Columns["SokulenCalismaSaati"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["SokulenRevizyon"].HeaderText = "REVİZYON";
            DtgStoktaOlmayanAselsan.Columns["CalismaDurumu"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["FizikselDurum"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["YapilacakIslem"].HeaderText = "YAPILACAK İŞLEM";
            DtgStoktaOlmayanAselsan.Columns["TakilanStokNo"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["TakilanTanim"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["TakilanSeriNo"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["TakilanMiktar"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["TakilanBirim"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["TakilanCalismaSaati"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["TakilanRevizyon"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["TeminDurumu"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgStoktaOlmayanAselsan.Columns["AbTarihSaat"].HeaderText = "TALEP TARİHİ";
            DtgStoktaOlmayanAselsan.Columns["TemineAtilamTarihi"].HeaderText = "TEMİNE ATILMA TARİHİ";
            DtgStoktaOlmayanAselsan.Columns["MalzemeDurumu"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["MalzemeIslemAdimi"].HeaderText = "İŞLEM DURUMU";
            DtgStoktaOlmayanAselsan.Columns["SokulenTeslimDurum"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["BolgeAdi"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["BolgeSorumlusu"].Visible = false;

            LblTop3.Text = DtgStoktaOlmayanAselsan.RowCount.ToString();



            DtgStoktaOlmayanAselsan.Columns["AbfNo"].DisplayIndex = 0;

            abfMalzemesSatinAlma = abfMalzemeManager.DepoTeminDurumu("SAT BEKLİYOR");
            dataBinder3.DataSource = abfMalzemesSatinAlma.ToDataTable();
            DtgStoktaOlmayanSat.DataSource = dataBinder3;

            DtgStoktaOlmayanSat.Columns["Id"].Visible = false;
            DtgStoktaOlmayanSat.Columns["BenzersizId"].Visible = false;
            DtgStoktaOlmayanSat.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            DtgStoktaOlmayanSat.Columns["SokulenTanim"].HeaderText = "TANIM";
            DtgStoktaOlmayanSat.Columns["SokulenSeriNo"].HeaderText = "SERİ/LOT NO";
            DtgStoktaOlmayanSat.Columns["SokulenMiktar"].HeaderText = "MİKTAR";
            DtgStoktaOlmayanSat.Columns["SokulenBirim"].HeaderText = "BİRİM";
            DtgStoktaOlmayanSat.Columns["SokulenCalismaSaati"].Visible = false;
            DtgStoktaOlmayanSat.Columns["SokulenRevizyon"].HeaderText = "REVİZYON";
            DtgStoktaOlmayanSat.Columns["CalismaDurumu"].Visible = false;
            DtgStoktaOlmayanSat.Columns["FizikselDurum"].Visible = false;
            DtgStoktaOlmayanSat.Columns["YapilacakIslem"].HeaderText = "YAPILACAK İŞLEM";
            DtgStoktaOlmayanSat.Columns["TakilanStokNo"].Visible = false;
            DtgStoktaOlmayanSat.Columns["TakilanTanim"].Visible = false;
            DtgStoktaOlmayanSat.Columns["TakilanSeriNo"].Visible = false;
            DtgStoktaOlmayanSat.Columns["TakilanMiktar"].Visible = false;
            DtgStoktaOlmayanSat.Columns["TakilanBirim"].Visible = false;
            DtgStoktaOlmayanSat.Columns["TakilanCalismaSaati"].Visible = false;
            DtgStoktaOlmayanSat.Columns["TakilanRevizyon"].Visible = false;
            DtgStoktaOlmayanSat.Columns["TeminDurumu"].Visible = false;
            DtgStoktaOlmayanSat.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgStoktaOlmayanSat.Columns["AbTarihSaat"].HeaderText = "TALEP TARİHİ";
            DtgStoktaOlmayanSat.Columns["TemineAtilamTarihi"].HeaderText = "TEMİNE ATILMA TARİHİ";
            DtgStoktaOlmayanSat.Columns["MalzemeDurumu"].Visible = false;
            DtgStoktaOlmayanSat.Columns["MalzemeIslemAdimi"].HeaderText = "İŞLEM DURUMU";
            DtgStoktaOlmayanSat.Columns["SokulenTeslimDurum"].Visible = false;
            DtgStoktaOlmayanSat.Columns["BolgeAdi"].Visible = false;
            DtgStoktaOlmayanSat.Columns["BolgeSorumlusu"].Visible = false;

            LblTop2.Text = DtgStoktaOlmayanSat.RowCount.ToString();

            DtgStoktaOlmayanSat.Columns["AbfNo"].DisplayIndex = 0;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageMalzemeHazirlama2"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void BtnRezerve_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in DtgArizaKayitlari.Rows)
            {
                abfMalzemeManager.AbfTeminListUpdate(item.Cells["Id"].Value.ConInt());
            }
            MessageBox.Show("End");
        }

        private void BtnStokKontrol_Click(object sender, EventArgs e)
        {
            if (DtgArizaKayitlari.RowCount==0)
            {
                MessageBox.Show("Kontrol etmeniz gereken malzeme şu anda bulunmamaktadır!", "Hata", MessageBoxButtons.OK);
            }

            depoMiktarsTotal = new List<AbfMalzeme>();
            List<AbfMalzeme> abfMalzemes5 = new List<AbfMalzeme>();
            List<AbfMalzeme> abfMalzemes6 = new List<AbfMalzeme>();
            List<AbfMalzeme> abfMalzemes7 = new List<AbfMalzeme>();
            foreach (AbfMalzeme item in abfMalzemes)
            {
                depoMiktars = depoMiktarManager.StokKontrol(item.SokulenStokNo);

                foreach (DepoMiktar item2 in depoMiktars)
                {
                    if (item.TeminDurumu != "REZERVE EDİLDİ" && item2.RezerveDurumu== "REZERVE DEĞİL")
                    {
                        if (item.SokulenMiktar <= item2.Miktar)
                        {
                            depoMiktarsTotal.Add(item);
                            break;
                        }
                        if (item2.Miktar==0)
                        {
                            abfMalzemes7.Add(item);
                            break;
                        }
                        else
                        {
                            abfMalzemes5.Add(item);
                            break;
                        }
                    }
                    else
                    {
                        abfMalzemes6.Add(item);
                    }
                }
            }
            MessageBox.Show(depoMiktarsTotal.Count.ToString() +  " Adet malzeme bulundu!\n" + abfMalzemes5.Count.ToString() + " adet malzeme de hepsi depoda yok!\n" + abfMalzemes6.Count.ToString() + "adet malzeme de rezerve!\n" + abfMalzemes7.Count + " adet malzemenin depo stok miktarı 0");
        }
    }
}
