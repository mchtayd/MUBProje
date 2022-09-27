using Business.Concreate.BakimOnarim;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using Entity.BakimOnarim;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmMalzemeHazirlama : Form
    {
        ArizaKayitManager arizaKayitManager;
        AbfMalzemeManager abfMalzemeManager;
        DepoMiktarManager depoMiktarManager;

        List<ArizaKayit> arizaKayits;
        List<AbfMalzeme> abfMalzemes;
        List<DepoMiktar> depoMiktars;
        int id;
        public object[] infos;
        public string aciklama = "";
        public FrmMalzemeHazirlama()
        {
            InitializeComponent();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            depoMiktarManager = DepoMiktarManager.GetInstance();
        }

        private void FrmMalzemeHazirlama_Load(object sender, EventArgs e)
        {
            ArizaKayitlari();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageMalzemeHazirmala"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void ArizaKayitlari()
        {
            arizaKayits = arizaKayitManager.MalzemeHazirlamaList();
            dataBinder.DataSource = arizaKayits.ToDataTable();
            DtgArizaKayitlari.DataSource = dataBinder;
            TxtTop.Text = DtgArizaKayitlari.RowCount.ToString();

            DtgArizaKayitlari.Columns["Id"].Visible = false;
            DtgArizaKayitlari.Columns["IsAkisNo"].Visible = false;
            DtgArizaKayitlari.Columns["AbfFormNo"].HeaderText = "FORM NO";
            DtgArizaKayitlari.Columns["Proje"].Visible = false;
            DtgArizaKayitlari.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgArizaKayitlari.Columns["BolukKomutani"].Visible = false;
            DtgArizaKayitlari.Columns["BirlikAdresi"].Visible = false;
            DtgArizaKayitlari.Columns["Il"].Visible = false;
            DtgArizaKayitlari.Columns["Ilce"].Visible = false;
            DtgArizaKayitlari.Columns["BildirilenAriza"].Visible = false;
            DtgArizaKayitlari.Columns["ArizaiBildirenPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["AbRutbesi"].Visible = false;
            DtgArizaKayitlari.Columns["AbGorevi"].Visible = false;
            DtgArizaKayitlari.Columns["AbTelefon"].Visible = false;
            DtgArizaKayitlari.Columns["AbTarihSaat"].HeaderText = "TALEP TARİHİ";
            DtgArizaKayitlari.Columns["ABAlanPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["BildirimKanali"].Visible = false;
            DtgArizaKayitlari.Columns["ArizaAciklama"].Visible = false;
            DtgArizaKayitlari.Columns["GorevAtanacakPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["IslemAdimi"].Visible = false;
            DtgArizaKayitlari.Columns["DosyaYolu"].Visible = false;
            DtgArizaKayitlari.Columns["SiparisNo"].Visible = false;
            DtgArizaKayitlari.Columns["GarantiDurumu"].Visible = false;
            DtgArizaKayitlari.Columns["LojistikSorumluPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["LojRutbesi"].Visible = false;
            DtgArizaKayitlari.Columns["LojGorevi"].Visible = false;
            DtgArizaKayitlari.Columns["LojTarihi"].Visible = false;
            DtgArizaKayitlari.Columns["LojTarihi"].Visible = false;
            DtgArizaKayitlari.Columns["TespitEdilenAriza"].Visible = false;
            DtgArizaKayitlari.Columns["AcmaOnayiVeren"].HeaderText = "ARIZA AÇMA ONAYI VEREN";
            DtgArizaKayitlari.Columns["CsSiparisNo"].Visible = false;
            DtgArizaKayitlari.Columns["BildirimNo"].Visible = false;
            DtgArizaKayitlari.Columns["CrmNo"].Visible = false;
            DtgArizaKayitlari.Columns["SiparisNo"].Visible = false;
            DtgArizaKayitlari.Columns["TelefonNo"].Visible = false;
            DtgArizaKayitlari.Columns["StokNo"].Visible = false;
            DtgArizaKayitlari.Columns["Tanim"].Visible = false;
            DtgArizaKayitlari.Columns["SeriNo"].Visible = false;
            DtgArizaKayitlari.Columns["IlgiliFirma"].Visible = false;
            DtgArizaKayitlari.Columns["BildirimTuru"].Visible = false;
            DtgArizaKayitlari.Columns["PypNo"].Visible = false;
            DtgArizaKayitlari.Columns["SorumluPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["IslemTuru"].Visible = false;
            DtgArizaKayitlari.Columns["Hesaplama"].Visible = false;
            DtgArizaKayitlari.Columns["BildirimMailTarihi"].Visible = false;
            DtgArizaKayitlari.Columns["Kategori"].Visible = false;
            DtgArizaKayitlari.Columns["IlgiliFirma"].Visible = false;
            DtgArizaKayitlari.Columns["BildirimTuru"].Visible = false;
            DtgArizaKayitlari.Columns["PypNo"].Visible = false;
            DtgArizaKayitlari.Columns["SorumluPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["IslemTuru"].Visible = false;
            DtgArizaKayitlari.Columns["Hesaplama"].Visible = false;
            DtgArizaKayitlari.Columns["Durum"].Visible = false;
            DtgArizaKayitlari.Columns["OnarimNotu"].Visible = false;
            DtgArizaKayitlari.Columns["TeslimEdenPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["TeslimAlanPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["TeslimTarihi"].Visible = false;
            DtgArizaKayitlari.Columns["NesneTanimi"].Visible = false;
            DtgArizaKayitlari.Columns["HasarKodu"].Visible = false;
            DtgArizaKayitlari.Columns["NedenKodu"].Visible = false;
            DtgArizaKayitlari.Columns["EksikEvrak"].Visible = false;
            DtgArizaKayitlari.Columns["EkipmanNo"].Visible = false;
            DtgArizaKayitlari.Columns["SiparisTuru"].Visible = false;

            TxtTop2.Text = DtgArizaKayitlari.RowCount.ToString();
        }

        private void DtgArizaKayitlari_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgArizaKayitlari.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            id = DtgArizaKayitlari.CurrentRow.Cells["Id"].Value.ConInt();
            MalzemeListDisplay(id);

        }
        void MalzemeListDisplay(int id)
        {
            abfMalzemes = abfMalzemeManager.GetList(id);
            if (abfMalzemes==null)
            {
                MessageBox.Show("Arızaya ait malzeme bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MalzemeList.DataSource = abfMalzemes;
            MalzemeList.Columns["Id"].Visible = false;
            MalzemeList.Columns["BenzersizId"].Visible = false;
            MalzemeList.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            MalzemeList.Columns["SokulenTanim"].HeaderText = "TANIM";
            MalzemeList.Columns["SokulenSeriNo"].HeaderText = "SERİ NO";
            MalzemeList.Columns["SokulenMiktar"].HeaderText = "MİKTAR";
            MalzemeList.Columns["SokulenBirim"].HeaderText = "BİRİM";
            MalzemeList.Columns["SokulenCalismaSaati"].Visible = false;
            MalzemeList.Columns["SokulenRevizyon"].HeaderText = "REVİZYON";
            MalzemeList.Columns["CalismaDurumu"].Visible = false;
            MalzemeList.Columns["FizikselDurum"].Visible = false;
            MalzemeList.Columns["YapilacakIslem"].HeaderText = "MALZEMEYE YAPILACAK İŞLEM";
            MalzemeList.Columns["TakilanStokNo"].Visible = false;
            MalzemeList.Columns["TakilanTanim"].Visible = false;
            MalzemeList.Columns["TakilanSeriNo"].Visible = false;
            MalzemeList.Columns["TakilanMiktar"].Visible = false;
            MalzemeList.Columns["TakilanBirim"].Visible = false;
            MalzemeList.Columns["TakilanCalismaSaati"].Visible = false;
            MalzemeList.Columns["TakilanRevizyon"].Visible = false;

            TxtTop.Text = MalzemeList.RowCount.ToString();

        }

        private void BtnKontrol_Click(object sender, EventArgs e)
        {
            if (MalzemeList.RowCount==0)
            {
                MessageBox.Show("Malzeme listesinde herhangi bir kayıt bulunmadığı için stoklar kontrol edilemiyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            foreach (AbfMalzeme item in abfMalzemes)
            {
                depoMiktars = depoMiktarManager.StokKontrol(item.SokulenStokNo);
            }
            dataBinder2.DataSource = depoMiktars.ToDataTable();
            DtgDepoBilgileri.DataSource = dataBinder2;
            DepoMiktarDisplay();
        }
        void DepoMiktarDisplay()
        {
            DtgDepoBilgileri.Columns["Secim"].HeaderText = "SEÇİM";
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

            TxtTop3.Text = DtgDepoBilgileri.RowCount.ToString();
        }

        private void BtnRezerve_Click(object sender, EventArgs e)
        {
            if (DtgDepoBilgileri.RowCount==0)
            {
                if (MalzemeList.RowCount!=0)
                {
                    DialogResult dr = MessageBox.Show("Aranan stok/stoklar depo kayıtlarında bulunamadı.\nTedarik için ilgili birimlere aktarılacaktır.Onaylıyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        foreach (AbfMalzeme item in abfMalzemes)
                        {

                        }
                    }
                    else
                    {
                        return;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Lütfen öncelikle bir arıza kaydı seçerek STOKLARI KONTROL ET butonuna basınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                FrmMalzemeAciklama frmMalzemeAciklama = new FrmMalzemeAciklama();
                aciklama = frmMalzemeAciklama.aciklama;
                frmMalzemeAciklama.ShowDialog();
                foreach (DataGridViewRow item in DtgDepoBilgileri.Rows)
                {
                    if (item.Cells["Secim"].Value.ConBool() == true)
                    {
                        DepoMiktar depoMiktar = new DepoMiktar(item.Cells["Id"].Value.ConInt(), infos[1].ToString(), aciklama, id);
                        depoMiktarManager.DepoRezerve(depoMiktar);
                    }
                }
            }

        }
    }
}
