using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.Depo;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarim;
using Entity.BakimOnarimAtolye;
using Entity.Depo;
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
using UserInterface.BakımOnarım;
using UserInterface.STS;

namespace UserInterface.Depo
{
    public partial class FrmStokGirisCikis : Form
    {
        StokGirisCikisManager stokGirisCikisManager;
        MalzemeKayitManager malzemeKayitManager;
        DepoKayitManagercs depoKayitManagercs;
        DepoKayitLokasyonManager depoKayitLokasyonManager;
        DepoMiktarManager depoMiktarManager;
        AbfFormNoManager abfFormNoManager;
        AtolyeManager atolyeManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        MalzemeManager malzemeManager;

        List<GorevAtamaPersonel> gorevAtamaPersonels;
        List<Malzeme> malzemes;
        //List<MalzemeKayit> malzemeKayits;
        bool start = true;
        int id, mevcutMiktar, miktar, dusulenMiktar, cekilenMiktar;
        string takipdurumu, depoNoDusulen, malzemeYeri, stokNo, tanim, depoAdresi, islemTuru, seriNo, lotNo, revizyon;
        public object[] infos;

        public FrmStokGirisCikis()
        {
            InitializeComponent();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
            depoKayitManagercs = DepoKayitManagercs.GetInstance();
            depoKayitLokasyonManager = DepoKayitLokasyonManager.GetInstance();
            depoMiktarManager = DepoMiktarManager.GetInstance();
            abfFormNoManager = AbfFormNoManager.GetInstance();
            atolyeManager = AtolyeManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
        }
        private void FrmStokGirisCikis_Load(object sender, EventArgs e)
        {
            StokBilgileri();
            CmbDepo();
            CmbDepoCekilen();
            CmbDepoDusulen();
            CmbDepodanBildirime();
            CmbBildirimdenDepoya();
            start = false;

        }
        public void CmbDepo()
        {
            CmbDepoNo.DataSource = depoKayitManagercs.GetList();
            CmbDepoNo.ValueMember = "Id";
            CmbDepoNo.DisplayMember = "Depo";
            CmbDepoNo.SelectedValue = 0;
        }

        public void CmbDepoCekilen()
        {
            CmbDepoNoCekilen.DataSource = depoKayitManagercs.GetList();
            CmbDepoNoCekilen.ValueMember = "Id";
            CmbDepoNoCekilen.DisplayMember = "Depo";
            CmbDepoNoCekilen.SelectedValue = 0;
        }
        public void CmbDepoDusulen()
        {
            CmbDepoNoDusulen.DataSource = depoKayitManagercs.GetList();
            CmbDepoNoDusulen.ValueMember = "Id";
            CmbDepoNoDusulen.DisplayMember = "Depo";
            CmbDepoNoDusulen.SelectedValue = 0;
        }
        public void CmbDepodanBildirime()
        {
            CmbDepodanBildirimeDepoNo.DataSource = depoKayitManagercs.GetList();
            CmbDepodanBildirimeDepoNo.ValueMember = "Id";
            CmbDepodanBildirimeDepoNo.DisplayMember = "Depo";
            CmbDepodanBildirimeDepoNo.SelectedValue = 0;
        }
        public void CmbBildirimdenDepoya()
        {
            CmbBildirimdenDepoyaDepoNo.DataSource = depoKayitManagercs.GetList();
            CmbBildirimdenDepoyaDepoNo.ValueMember = "Id";
            CmbBildirimdenDepoyaDepoNo.DisplayMember = "Depo";
            CmbBildirimdenDepoyaDepoNo.SelectedValue = 0;
        }
        void StokBilgileri()
        {
            malzemes = malzemeManager.GetList();
            CmbStokNo.DataSource = malzemes;
            CmbStokNo.ValueMember = "Id";
            CmbStokNo.DisplayMember = "StokNo";
            CmbStokNo.SelectedValue = 0;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageStokGirisCikis"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {

            if (CmbStokNo.Text == "")
            {
                MessageBox.Show("Öncelikle Bir Stok Numarası Giriniz.");
                return;
            }
            if (TxtMiktar.Text == "")
            {
                MessageBox.Show("Lütfen Miktar Belirtiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (takipdurumu == "LOT NO")
            {
                AdvMalzemeOnizleme.Columns["SeriLotNo"].HeaderText = "LOT NO";
                AdvMalzemeOnizleme.Columns["Remove"].Visible = false;
            }
            else
            {
                AdvMalzemeOnizleme.Columns["SeriLotNo"].HeaderText = "SERİ NO";
                AdvMalzemeOnizleme.Columns["Remove"].Visible = true;
            }

            AdvMalzemeOnizleme.Rows.Clear();
            for (int i = 0; i < TxtMiktar.Text.ConInt(); i++)
            {
                AdvMalzemeOnizleme.Rows.Add();
                int sonSatir = AdvMalzemeOnizleme.RowCount - 1;
                AdvMalzemeOnizleme.Rows[sonSatir].Cells["SiraNo"].Value = i + 1;
                AdvMalzemeOnizleme.Rows[sonSatir].Cells["SeriLotNo"].Value = "";
                AdvMalzemeOnizleme.Rows[sonSatir].Cells["Revizyon"].Value = "";
            }
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)AdvMalzemeOnizleme.Columns["Remove"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;
        }

        private void CmbStokNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start)
            {
                return;
            }
            if (CmbStokNo.Text == "")
            {
                return;
            }
            FillTools();

        }
        void FillTools()
        {
            id = CmbStokNo.SelectedValue.ConInt();
            Malzeme malzeme = malzemeManager.Get(CmbStokNo.Text);
            //StokGirisCıkıs stokGirisCıkıs = stokGirisCikisManager.StokGor(CmbStokNo.Text);
            TxtTanim.Text = malzeme.Tanim;
            CmbBirim.Text = malzeme.Birim;
            takipdurumu = malzeme.TakipDurumu;
            /*if (stokGirisCıkıs == null)
            {
                mevcutMiktar = 0;
                return;
            }
            mevcutMiktar = stokGirisCıkıs.MevcutMiktar;*/
        }
        string Control()
        {
            if (CmbIslemTuru.Text == "")
            {
                return "Lütfen Öncelikle İşlem Türü Bilgisini Seçiniz!";
            }
            if (CmbStokNo.Text == "")
            {
                return "Lütfen Öncelikle Bir Stok No Seçiniz!";
            }
            if (depoNoDusulen == "")
            {
                return "Lütfen Öncelikle Depo No Bilgisini Seçiniz!";
            }
            if (malzemeYeri == "")
            {
                return "Lütfen Öncelikle Malzeme Yeri Bilgisini Seçiniz!";
            }
            if (TxtAciklama.Text == "")
            {
                return "Lütfen Öncelikle Açıklama Bilgisini Doldurunuz!";
            }
            if (AdvMalzemeOnizleme.RowCount == 0)
            {
                return "Lütfen Öncelikle Malzeme Miktarını Belirtiniz!";
            }
            if (CmbStokNo.Text == "")
            {
                return "Lütfen Öncelikle Bir Stok No Seçiniz!";
            }
            return "";
        }
        string BilgiControl()
        {
            string lotNo = "", seriNo = "", revizyon = "";
            if (takipdurumu == "LOT NO")
            {
                lotNo = AdvMalzemeOnizleme.CurrentRow.Cells["SeriLotNo"].Value.ToString();
                seriNo = "N/A";
                revizyon = AdvMalzemeOnizleme.CurrentRow.Cells["Revizyon"].Value.ToString();
            }
            else
            {
                seriNo = AdvMalzemeOnizleme.CurrentRow.Cells["SeriLotNo"].Value.ToString();
                lotNo = "N/A";
                revizyon = AdvMalzemeOnizleme.CurrentRow.Cells["Revizyon"].Value.ToString();
            }
            DepoMiktar depoMiktar = depoMiktarManager.StokSeriLotKontrol(CmbStokNo.Text, depoNoDusulen, seriNo, lotNo, revizyon);
            if (depoMiktar == null || depoMiktar.Miktar == 0)
            {
                if (takipdurumu == "LOT NO")
                {
                    return CmbStokNo.Text + " Stok Numaralı Malzemenin Lot Bilgisi veya Revizyon Bilgisi " + depoNoDusulen + " Nolu Depo Kayıtlarındaki Bilgi İle Uyuşmadığı İçin İşlem Gerçekleştirilemez!";
                }
                else
                {
                    return CmbStokNo.Text + " Stok Numaralı Malzemenin Seri No Bilgisi " + depoNoDusulen + " Nolu Depo Kayıtlarındaki Seri No Bilgisileri İle Uyuşmadığı İçin İşlem Gerçekleştirilemez!";
                }
            }
            return "OK";

        }
        private void BtnListEkle_Click(object sender, EventArgs e)
        {
            if (CmbIslemTuru.Text == "100-YENİ DEPO GİRİŞİ")
            {
                if (TxtBirimFiyat.Text=="")
                {
                    DialogResult dr = MessageBox.Show("Malzeme İçin Birim Fiyatı Tanımlamadınız!\nYinede Devam Etmek İstiyor Musunuz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (dr==DialogResult.No)
                    {
                        return;
                    }
                }
                depoNoDusulen = CmbDepoNo.Text;
                malzemeYeri = TxtMalzemeYeri.Text;
                
            }
            if (CmbIslemTuru.Text == "101-DEPODAN DEPOYA İADE")
            {
                depoNoDusulen = CmbDepoNoCekilen.Text;
                malzemeYeri = CmbMalzemeYeriCekilen.Text;
                if (CmbDepoNoCekilen.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle Çekilen Depo Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (CmbMalzemeYeriCekilen.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle Çekilen Depo Malzeme Yeri Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string bilgiControl = BilgiControl();

                if (bilgiControl != "OK")
                {
                    MessageBox.Show(bilgiControl, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (CmbIslemTuru.Text == "102-DEPODAN BİLDİRİME ÇEKİM")
            {
                depoNoDusulen = CmbDepodanBildirimeDepoNo.Text;
                malzemeYeri = CmbDepodanBildirimeMalzemeYeri.Text;
                if (CmbDepodanBildirimeDepoNo.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle Çekilen Depo Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (CmbDepodanBildirimeMalzemeYeri.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle Çekilen Depo Malzeme Yeri Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string bilgiControl = BilgiControl();

                if (bilgiControl != "OK")
                {
                    MessageBox.Show(bilgiControl, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            /*string control = Control();

            if (control != "")
            {
                MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            DtgList.Rows.Clear();
            foreach (DataGridViewRow item in AdvMalzemeOnizleme.Rows)
            {
                if (CmbIslemTuru.Text == "101-DEPODAN DEPOYA İADE")
                {
                    if (takipdurumu == "LOT NO")
                    {
                        string control = MiktarKontrol(CmbStokNo.Text, CmbDepoNoCekilen.Text, "N/A", item.Cells["SeriLotNo"].Value.ToString(), "N/A", TxtMiktar.Text.ConInt());
                        if (control!="OK")
                        {
                            MessageBox.Show(control,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return;
                        }
                    }
                    string control2 = MiktarKontrol(CmbStokNo.Text, CmbDepoNoCekilen.Text, item.Cells["SeriLotNo"].Value.ToString(), "N/A", item.Cells["Revizyon"].Value.ToString(), TxtMiktar.Text.ConInt());
                    if (control2 != "OK")
                    {
                        MessageBox.Show(control2, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (CmbIslemTuru.Text == "102-DEPODAN BİLDİRİME ÇEKİM")
                {
                    if (takipdurumu == "LOT NO")
                    {
                        string control = MiktarKontrol(CmbStokNo.Text, CmbDepodanBildirimeDepoNo.Text, "N/A", item.Cells["SeriLotNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString(), TxtMiktar.Text.ConInt());
                        if (control != "OK")
                        {
                            MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        string control2 = MiktarKontrol(CmbStokNo.Text, CmbDepodanBildirimeDepoNo.Text, item.Cells["SeriLotNo"].Value.ToString(), "N/A", item.Cells["Revizyon"].Value.ToString(), TxtMiktar.Text.ConInt());
                        if (control2 != "OK")
                        {
                            MessageBox.Show(control2, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                }
                if (CmbIslemTuru.Text == "201-BİLDİRİMDEN DEPOYA İADE")
                {
                    if (takipdurumu == "LOT NO")
                    {
                        string control = BildirimdenDepoyaKontrol(CmbStokNo.Text, "N/A", item.Cells["SeriLotNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString(), TxtBildirimdenDepoyaFormNo.Text);
                        if (control != "OK")
                        {
                            MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        string control2 = BildirimdenDepoyaKontrol(CmbStokNo.Text, item.Cells["SeriLotNo"].Value.ToString(), "N/A", item.Cells["Revizyon"].Value.ToString(), TxtBildirimdenDepoyaFormNo.Text);
                        if (control2 != "OK")
                        {
                            MessageBox.Show(control2, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                }

                int sirano = item.Cells["SiraNo"].Value.ConInt();


                DtgList.Rows.Add();
                int sonSatir = DtgList.RowCount - 1;

                DtgList.Rows[sonSatir].Cells["Column1"].Value = sirano;
                DtgList.Rows[sonSatir].Cells["Column13"].Value = CmbIslemTuru.Text;
                DtgList.Rows[sonSatir].Cells["Column2"].Value = CmbStokNo.Text;
                DtgList.Rows[sonSatir].Cells["Column3"].Value = TxtTanim.Text;
                if (takipdurumu == "LOT NO")
                {
                    DtgList.Rows[sonSatir].Cells["Column4"].Value = TxtMiktar.Text;
                }
                else
                {
                    DtgList.Rows[sonSatir].Cells["Column4"].Value = 1;
                }
                DtgList.Rows[sonSatir].Cells["Column5"].Value = CmbBirim.Text;
                DtgList.Rows[sonSatir].Cells["Column6"].Value = DtTarih.Value;
                DtgList.Rows[sonSatir].Cells["Column14"].Value = TxtAciklama.Text;

                if (CmbIslemTuru.Text == "100-YENİ DEPO GİRİŞİ")
                {

                    DtgList.Rows[sonSatir].Cells["Column15"].Value = CmbDepoNo.Text; // DÜŞÜLEN DEPO
                    DtgList.Rows[sonSatir].Cells["Column16"].Value = CmbAdres.Text;
                    DtgList.Rows[sonSatir].Cells["Column17"].Value = TxtMalzemeYeri.Text;
                    DtgList.Rows[sonSatir].Cells["Column7"].Value = ""; // ÇEKİLEN DEPO
                    DtgList.Rows[sonSatir].Cells["Column8"].Value = "";
                    DtgList.Rows[sonSatir].Cells["Column9"].Value = "";
                    //DtgList.Rows[sonSatir].Cells["Column18"].Value = ""; // ABF FORM NO
                    DtgList.Rows[sonSatir].Cells["Column19"].Value = ""; // TALEP EDEN PERSONEL
                }

                if (CmbIslemTuru.Text == "101-DEPODAN DEPOYA İADE")
                {

                    DtgList.Rows[sonSatir].Cells["Column15"].Value = CmbDepoNoDusulen.Text; // DÜŞÜLEN DEPO
                    DtgList.Rows[sonSatir].Cells["Column16"].Value = TxtDepoAdresiDusulen.Text;
                    DtgList.Rows[sonSatir].Cells["Column17"].Value = CmbMalzemeYeriDusulen.Text;
                    DtgList.Rows[sonSatir].Cells["Column7"].Value = CmbDepoNoCekilen.Text; // ÇEKİLEN DEPO
                    DtgList.Rows[sonSatir].Cells["Column8"].Value = TxtDepoAdresiCekilen.Text;
                    DtgList.Rows[sonSatir].Cells["Column9"].Value = CmbMalzemeYeriCekilen.Text;
                    //DtgList.Rows[sonSatir].Cells["Column18"].Value = ""; // ABF FORM NO
                    DtgList.Rows[sonSatir].Cells["Column19"].Value = ""; // TALEP EDEN PERSONEL
                }

                if (CmbIslemTuru.Text == "102-DEPODAN BİLDİRİME ÇEKİM")
                {

                    DtgList.Rows[sonSatir].Cells["Column15"].Value = TxtDepodanBildirimeAbfNo.Text; ; // DÜŞÜLEN DEPO
                    DtgList.Rows[sonSatir].Cells["Column16"].Value = "";
                    DtgList.Rows[sonSatir].Cells["Column17"].Value = "";
                    DtgList.Rows[sonSatir].Cells["Column7"].Value = CmbDepodanBildirimeDepoNo.Text; // ÇEKİLEN DEPO
                    DtgList.Rows[sonSatir].Cells["Column8"].Value = TxtDepodanBildirimeDepoAdresi.Text;
                    DtgList.Rows[sonSatir].Cells["Column9"].Value = CmbDepodanBildirimeMalzemeYeri.Text;
                    //DtgList.Rows[sonSatir].Cells["Column18"].Value =  // ABF FORM NO
                    DtgList.Rows[sonSatir].Cells["Column19"].Value = LblDepodanBildirimePersonel.Text; // TALEP EDEN PERSONEL
                }

                if (CmbIslemTuru.Text == "201-BİLDİRİMDEN DEPOYA İADE")
                {

                    DtgList.Rows[sonSatir].Cells["Column15"].Value = CmbBildirimdenDepoyaDepoNo.Text; // DÜŞÜLEN DEPO
                    DtgList.Rows[sonSatir].Cells["Column16"].Value = TxtBildirimdenDepoyaDepoAdres.Text;
                    DtgList.Rows[sonSatir].Cells["Column17"].Value = CmbBildirimdenDepoyaMalzemeYeri.Text;
                    DtgList.Rows[sonSatir].Cells["Column7"].Value = TxtBildirimdenDepoyaFormNo.Text; // ÇEKİLEN DEPO
                    DtgList.Rows[sonSatir].Cells["Column8"].Value = "";
                    DtgList.Rows[sonSatir].Cells["Column9"].Value = "";
                    //DtgList.Rows[sonSatir].Cells["Column18"].Value = ; // ABF FORM NO
                    DtgList.Rows[sonSatir].Cells["Column19"].Value = LblBildirimdenDepoyaPersonel.Text; // TALEP EDEN PERSONEL
                }


                if (takipdurumu == "LOT NO")
                {
                    DtgList.Columns["Column10"].Visible = false;
                    DtgList.Rows[sonSatir].Cells["Column10"].Value = "N/A";
                    DtgList.Columns["Column12"].Visible = true;
                    DtgList.Rows[sonSatir].Cells["Column12"].Value = item.Cells["SeriLotNo"].Value.ToString();
                }
                else
                {
                    DtgList.Columns["Column12"].Visible = false;
                    DtgList.Rows[sonSatir].Cells["Column12"].Value = "N/A";
                    DtgList.Columns["Column10"].Visible = true;
                    DtgList.Rows[sonSatir].Cells["Column10"].Value = item.Cells["SeriLotNo"].Value.ToString();
                }
                DtgList.Rows[sonSatir].Cells["Column11"].Value = item.Cells["Revizyon"].Value.ToString();
            }
        }

        private void DtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string islemAdimiSorumlusu = "";
        private void TxtBildirimdenDepoyaFormNo_TextChanged(object sender, EventArgs e)
        {
            if (TxtBildirimdenDepoyaFormNo.Text.Length < 6)
            {
                return;
            }

            AbfFormNo abfFormNo = abfFormNoManager.PersonelSicil(TxtBildirimdenDepoyaFormNo.Text);

            if (abfFormNo==null)
            {
                Atolye atolye = atolyeManager.ArizaGetir(TxtBildirimdenDepoyaFormNo.Text.ConInt());
                if (atolye==null)
                {
                    LblBildirimdenDepoyaPersonel.Text = "00";
                    return;
                }
                if (gorevAtamaPersonels != null)
                {
                    gorevAtamaPersonels.Clear();
                }
                gorevAtamaPersonels = gorevAtamaPersonelManager.GetList(atolye.Id, "BAKIM ONARIM ATOLYE");
                foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
                {
                    string islemAdimi = item.IslemAdimi;
                    if (islemAdimi == "600-ARIZA TESPİTİ/ELEKTRİKSEL/FONK. KONTROL (TEKNİK SERVİS)")
                    {
                        islemAdimiSorumlusu = item.GorevAtanacakPersonel;
                    }
                }
                LblBildirimdenDepoyaPersonel.Text = islemAdimiSorumlusu;
                return;
            }
            LblBildirimdenDepoyaPersonel.Text = abfFormNo.PersonelAd;
        }

        private void TxtDepodanBildirimeAbfNo_TextChanged(object sender, EventArgs e)
        {
            if (TxtDepodanBildirimeAbfNo.Text.Length < 6)
            {
                return;
            }
            AbfFormNo abfFormNo = abfFormNoManager.PersonelSicil(TxtDepodanBildirimeAbfNo.Text);
            if (abfFormNo==null)
            {
                Atolye atolye = atolyeManager.ArizaGetir(TxtDepodanBildirimeAbfNo.Text.ConInt());
                if (atolye == null)
                {
                    LblDepodanBildirimePersonel.Text = "00";
                    return;
                }
                if (gorevAtamaPersonels!=null)
                {
                    gorevAtamaPersonels.Clear();
                }
                
                gorevAtamaPersonels = gorevAtamaPersonelManager.GetList(atolye.Id, "BAKIM ONARIM ATOLYE");
                foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
                {
                    string islemAdimi = item.IslemAdimi;
                    if (islemAdimi == "600-ARIZA TESPİTİ/ELEKTRİKSEL/FONK. KONTROL (TEKNİK SERVİS)")
                    {
                        islemAdimiSorumlusu = item.GorevAtanacakPersonel;
                    }
                }
                LblDepodanBildirimePersonel.Text = islemAdimiSorumlusu;
                return;
            }

            LblDepodanBildirimePersonel.Text = abfFormNo.PersonelAd;
        }

        bool miktarKontrol = false;
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (DtgList.RowCount == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Listeye Kayıt Ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    islemTuru = item.Cells["Column13"].Value.ToString();

                    stokNo = item.Cells["Column2"].Value.ToString();
                    tanim = item.Cells["Column3"].Value.ToString();
                    seriNo = item.Cells["Column10"].Value.ToString();
                    lotNo = item.Cells["Column12"].Value.ToString();
                    revizyon = item.Cells["Column11"].Value.ToString();

                    depoNoDusulen = item.Cells["Column15"].Value.ToString(); //  DÜŞÜLEN DEPO
                    depoAdresi = item.Cells["Column16"].Value.ToString();


                    miktar = item.Cells["Column4"].Value.ConInt();

                    DepoMiktar depo = depoMiktarManager.Get(stokNo, depoNoDusulen, seriNo, lotNo, revizyon);
                    if (depo == null)
                    {

                        mevcutMiktar = item.Cells["Column4"].Value.ConInt();
                        miktarKontrol = true;
                    }
                    else
                    {
                        mevcutMiktar = depo.Miktar;
                    }

                    if (islemTuru == "100-YENİ DEPO GİRİŞİ")
                    {

                        mevcutMiktar = +miktar;

                        DepoMiktar depoMiktar = new DepoMiktar(stokNo, tanim, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), depoNoDusulen, depoAdresi, item.Cells["Column17"].Value.ToString(), mevcutMiktar, item.Cells["Column14"].Value.ToString());
                        depoMiktarManager.Add(depoMiktar);

                        if (miktarKontrol == true)
                        {
                            mevcutMiktar = 0;
                        }

                        if (takipdurumu != "LOT NO")
                        {
                            mevcutMiktar = 0;
                        }


                        miktarKontrol = false;
                        StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs(islemTuru, stokNo, tanim, item.Cells["Column5"].Value.ToString(), item.Cells["Column6"].Value.ConDate(), item.Cells["Column7"].Value.ToString(), item.Cells["Column8"].Value.ToString(), item.Cells["Column9"].Value.ToString(), item.Cells["Column15"].Value.ToString(), item.Cells["Column16"].Value.ToString(), item.Cells["Column17"].Value.ToString(), miktar, item.Cells["Column19"].Value.ToString(), item.Cells["Column14"].Value.ToString(), item.Cells["Column10"].Value.ToString(), item.Cells["Column12"].Value.ToString(), item.Cells["Column11"].Value.ToString());

                        stokGirisCikisManager.Add(stokGirisCıkıs);

                        stokGirisCikisManager.DepoBirimFiyat(TxtBirimFiyat.Text.ConDouble(), stokNo);
                    }

                    if (islemTuru == "101-DEPODAN DEPOYA İADE")
                    {
                        DepoMiktar depoMiktar = depoMiktarManager.StokSeriLotKontrol(stokNo, CmbDepoNoDusulen.Text, seriNo, lotNo, revizyon);
                        if (depoMiktar == null)
                        {
                            DepoMiktar depoMiktar2 = new DepoMiktar(stokNo, tanim, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), depoNoDusulen, depoAdresi, item.Cells["Column17"].Value.ToString(), mevcutMiktar, item.Cells["Column14"].Value.ToString());
                            depoMiktarManager.Add(depoMiktar2);
                        }

                        dusulenMiktar = miktar;

                        string depoNoDusulen2 = item.Cells["Column15"].Value.ToString(); // düşülen
                        string depoNoCekilen2 = item.Cells["Column7"].Value.ToString(); // çekilen

                        DepoMiktar depo2 = depoMiktarManager.Get(stokNo, depoNoCekilen2, seriNo, lotNo, revizyon);
                        cekilenMiktar = depo2.Miktar - miktar;

                        DepoMiktar depoDusulen = new DepoMiktar(stokNo, depoNoDusulen2, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), dusulenMiktar);
                        depoMiktarManager.Update(depoDusulen);


                        DepoMiktar depoCekilen = new DepoMiktar(stokNo, depoNoCekilen2, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), cekilenMiktar);
                        depoMiktarManager.Update(depoCekilen);

                        if (cekilenMiktar==0)
                        {
                            depoMiktarManager.Delete(depo2.Id);
                        }
                        if (dusulenMiktar == 0)
                        {
                            depoMiktarManager.Delete(depoDusulen.Id);
                        }
                        /*DepoMiktar miktar1 = depoMiktarManager.Get(stokNo, depoNoDusulen);
                        mevcutMiktar = miktar1.Miktar;*/

                        StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs(islemTuru, stokNo, tanim, item.Cells["Column5"].Value.ToString(), item.Cells["Column6"].Value.ConDate(), item.Cells["Column7"].Value.ToString(), item.Cells["Column8"].Value.ToString(), item.Cells["Column9"].Value.ToString(), item.Cells["Column15"].Value.ToString(), item.Cells["Column16"].Value.ToString(), item.Cells["Column17"].Value.ToString(), miktar, item.Cells["Column19"].Value.ToString(), item.Cells["Column14"].Value.ToString(), item.Cells["Column10"].Value.ToString(), item.Cells["Column12"].Value.ToString(), item.Cells["Column11"].Value.ToString());

                        stokGirisCikisManager.Add(stokGirisCıkıs);

                    }

                    if (islemTuru == "102-DEPODAN BİLDİRİME ÇEKİM")
                    {
                        DepoMiktar depo2 = depoMiktarManager.Get(stokNo, item.Cells["Column7"].Value.ToString(), seriNo, lotNo, revizyon);
                        mevcutMiktar = depo2.Miktar;
                        mevcutMiktar = mevcutMiktar - miktar;
                        string depoNoCekilen = item.Cells["Column7"].Value.ToString(); // çekilen depo

                        DepoMiktar depoDusulen = new DepoMiktar(stokNo, depoNoCekilen, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), mevcutMiktar);
                        depoMiktarManager.Update(depoDusulen);

                        if (mevcutMiktar == 0)
                        {
                            depoMiktarManager.Delete(depoDusulen.Id);
                        }

                        StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs(islemTuru, stokNo, tanim, item.Cells["Column5"].Value.ToString(), item.Cells["Column6"].Value.ConDate(), item.Cells["Column7"].Value.ToString(), item.Cells["Column8"].Value.ToString(), item.Cells["Column9"].Value.ToString(), item.Cells["Column15"].Value.ToString(), "","", miktar, item.Cells["Column19"].Value.ToString(), item.Cells["Column14"].Value.ToString(), item.Cells["Column10"].Value.ToString(), item.Cells["Column12"].Value.ToString(), item.Cells["Column11"].Value.ToString());

                        stokGirisCikisManager.Add(stokGirisCıkıs);


                    }

                    if (islemTuru == "201-BİLDİRİMDEN DEPOYA İADE")
                    {
                        DepoMiktar depoMiktar = depoMiktarManager.StokSeriLotKontrol(stokNo, CmbBildirimdenDepoyaDepoNo.Text, seriNo, lotNo, revizyon);
                        if (depoMiktar == null)
                        {
                            DepoMiktar depoMiktar2 = new DepoMiktar(stokNo, tanim, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), depoNoDusulen, depoAdresi, item.Cells["Column17"].Value.ToString(), mevcutMiktar, item.Cells["Column14"].Value.ToString());
                            depoMiktarManager.Add(depoMiktar2);
                        }

                        mevcutMiktar = +miktar;
                        string depoNoDusulen2 = item.Cells["Column15"].Value.ToString(); // düşülen depo

                        DepoMiktar depoDusulen = new DepoMiktar(stokNo, depoNoDusulen2, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), mevcutMiktar);
                        depoMiktarManager.Update(depoDusulen);


                        StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs(islemTuru, stokNo, tanim, item.Cells["Column5"].Value.ToString(), item.Cells["Column6"].Value.ConDate(), item.Cells["Column7"].Value.ToString(), "", "", item.Cells["Column15"].Value.ToString(), item.Cells["Column16"].Value.ToString(), item.Cells["Column17"].Value.ToString(), miktar, item.Cells["Column19"].Value.ToString(), item.Cells["Column14"].Value.ToString(), item.Cells["Column10"].Value.ToString(), item.Cells["Column12"].Value.ToString(), item.Cells["Column11"].Value.ToString());

                        stokGirisCikisManager.Add(stokGirisCıkıs);

                    }
                }
                MessageBox.Show("Bilgileri Başarıyla Kaydedişmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                start = true;
                Temizle();
                start = false;
            }
        }
        void DepoSayimSil()
        {
            DtgSilControl.DataSource = depoMiktarManager.DepoGor();
            foreach (DataGridViewRow item in DtgSilControl.Rows)
            {
                if (true)
                {

                }
            }
        }

        private void TxtBirimFiyat_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtBirimFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BtnDepo_Click(object sender, EventArgs e)
        {

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        void Temizle()
        {
            CmbIslemTuru.SelectedValue = ""; CmbStokNo.Text = ""; TxtTanim.Clear(); TxtMiktar.Clear(); CmbBirim.Text = ""; CmbDepoNo.Text = ""; CmbAdres.Text = "";
            TxtMalzemeYeri.Text = ""; TxtAciklama.Text = ""; CmbBildirimdenDepoyaDepoNo.Text = ""; TxtBildirimdenDepoyaDepoAdres.Text = "";
            CmbBildirimdenDepoyaMalzemeYeri.Text = ""; TxtBildirimdenDepoyaFormNo.Clear(); LblBildirimdenDepoyaPersonel.Text = "00";
            CmbDepodanBildirimeDepoNo.Text = ""; TxtDepodanBildirimeDepoAdresi.Text = ""; CmbDepodanBildirimeMalzemeYeri.Text = "";
            TxtDepodanBildirimeAbfNo.Clear(); LblDepodanBildirimePersonel.Text = "00"; CmbDepoNoCekilen.Text = ""; TxtDepoAdresiCekilen.Text = "";
            CmbMalzemeYeriCekilen.Text = ""; CmbDepoNoDusulen.Text = ""; TxtDepoAdresiDusulen.Text = ""; CmbMalzemeYeriDusulen.Text = "";
            AdvMalzemeOnizleme.Rows.Clear(); DtgList.Rows.Clear();
        }

        private void BtnDepoEkle_Click(object sender, EventArgs e)
        {
            FrmDepoLokasyonKayit frmDepoLokasyonKayit = new FrmDepoLokasyonKayit();
            frmDepoLokasyonKayit.ShowDialog();
        }

        private void CmbDepoNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            id = CmbDepoNo.SelectedValue.ConInt();
            DepoKayit depoKayit = depoKayitManagercs.Get(id);
            CmbAdres.Text = depoKayit.Aciklama;

            TxtMalzemeYeri.DataSource = depoKayitLokasyonManager.GetListLokasyon(id);
            TxtMalzemeYeri.ValueMember = "Id";
            TxtMalzemeYeri.DisplayMember = "Lokasyon";
            TxtMalzemeYeri.SelectedValue = "";




            // AYNI STOK, SERİ VE LOTTA OLANLAR KONTROL EDİLECEK EĞER VARSA ARTTIRILACAK YOKSA YENİ KAYIT EKLENECEK
            // DEPO_STOK_MIKTAR TABLOSUNA!


        }

        private void TxtMiktar_TextChanged(object sender, EventArgs e)
        {

            if (CmbStokNo.Text == "")
            {
                //MessageBox.Show("Öncelikle Bir Stok Numarası Giriniz.");
                return;
            }
            if (TxtMiktar.Text == "")
            {
                //MessageBox.Show("Lütfen Miktar Belirtiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //AdvMalzemeOnizleme.DataSource = "";
                AdvMalzemeOnizleme.Rows.Clear();
                return;
            }
            
            if (takipdurumu == "LOT NO")
            {
                AdvMalzemeOnizleme.Columns["SeriLotNo"].HeaderText = "LOT NO";
                AdvMalzemeOnizleme.Columns["Remove"].Visible = false;
            }
            else
            {
                AdvMalzemeOnizleme.Columns["SeriLotNo"].HeaderText = "SERİ NO";
                AdvMalzemeOnizleme.Columns["Remove"].Visible = true;
            }

            AdvMalzemeOnizleme.Rows.Clear();
            for (int i = 0; i < TxtMiktar.Text.ConInt(); i++)
            {
                AdvMalzemeOnizleme.Rows.Add();
                int sonSatir = AdvMalzemeOnizleme.RowCount - 1;
                AdvMalzemeOnizleme.Rows[sonSatir].Cells["SiraNo"].Value = i + 1;
                AdvMalzemeOnizleme.Rows[sonSatir].Cells["SeriLotNo"].Value = "";
                AdvMalzemeOnizleme.Rows[sonSatir].Cells["Revizyon"].Value = "";

                if (takipdurumu == "LOT NO")
                {
                    break;
                }
            }
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)AdvMalzemeOnizleme.Columns["Remove"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;
        }

        private void CmbIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbIslemTuru.SelectedIndex == 0)
            {
                GrbIslemYapılacakDepo.Visible = true;
                GrbDepodanDepoya.Visible = false;
                GrbDepodanBildirime.Visible = false;
                GrbBildirimdenDepoya.Visible = false;
                LblBirimFiyat.Visible = true; TxtBirimFiyat.Visible = true;
            }
            if (CmbIslemTuru.SelectedIndex == 1)
            {
                GrbIslemYapılacakDepo.Visible = false;
                GrbDepodanDepoya.Visible = true;
                GrbDepodanBildirime.Visible = false;
                GrbBildirimdenDepoya.Visible = false;
                LblBirimFiyat.Visible = false; TxtBirimFiyat.Visible = false;
                return;
            }
            if (CmbIslemTuru.SelectedIndex == 2)
            {
                GrbDepodanDepoya.Visible = false;
                GrbIslemYapılacakDepo.Visible = false;
                GrbDepodanBildirime.Visible = true;
                GrbBildirimdenDepoya.Visible = false;
                LblBirimFiyat.Visible = false; TxtBirimFiyat.Visible = false;
                return;
            }
            if (CmbIslemTuru.SelectedIndex == 3)
            {
                GrbDepodanDepoya.Visible = false;
                GrbIslemYapılacakDepo.Visible = false;
                GrbDepodanBildirime.Visible = false;
                GrbBildirimdenDepoya.Visible = true;
                LblBirimFiyat.Visible = false; TxtBirimFiyat.Visible = false;
                return;
            }

        }

        private void CmbDepoNoCekilen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }

            if (CmbDepoNoCekilen.SelectedIndex == -1)
            {
                return;
            }

            if (CmbStokNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Stok No Bilgisi Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CmbDepoNoCekilen.SelectedIndex = -1;
                return;
            }

            if (TxtMiktar.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Miktar Bilgisi Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CmbDepoNoCekilen.SelectedIndex = -1;
                return;
            }

            id = CmbDepoNoCekilen.SelectedValue.ConInt();
            DepoKayit depoKayit = depoKayitManagercs.Get(id);
            TxtDepoAdresiCekilen.Text = depoKayit.Aciklama;

            CmbMalzemeYeriCekilen.DataSource = depoKayitLokasyonManager.GetListLokasyon(id);
            CmbMalzemeYeriCekilen.ValueMember = "Id";
            CmbMalzemeYeriCekilen.DisplayMember = "Lokasyon";
            CmbMalzemeYeriCekilen.SelectedValue = "";

            StokGirisCıkıs stokGirisCıkıs = stokGirisCikisManager.DepoRafBul(CmbStokNo.Text, CmbDepoNoCekilen.Text);
            if (stokGirisCıkıs == null)
            {
                TxtMalzemeYeri.Text = "";
            }
            else
            {
                CmbMalzemeYeriCekilen.Text = stokGirisCıkıs.DusulenMalzemeYeri;
            }
        }

        private void CmbBildirimdenDepoyaDepoNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            id = CmbBildirimdenDepoyaDepoNo.SelectedValue.ConInt();
            DepoKayit depoKayit = depoKayitManagercs.Get(id);
            TxtBildirimdenDepoyaDepoAdres.Text = depoKayit.Aciklama;

            CmbBildirimdenDepoyaMalzemeYeri.DataSource = depoKayitLokasyonManager.GetListLokasyon(id);
            CmbBildirimdenDepoyaMalzemeYeri.ValueMember = "Id";
            CmbBildirimdenDepoyaMalzemeYeri.DisplayMember = "Lokasyon";
            CmbBildirimdenDepoyaMalzemeYeri.SelectedValue = "";


        }

        private void CmbDepodanBildirimeDepoNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            if (CmbDepodanBildirimeDepoNo.SelectedIndex == -1)
            {
                return;
            }

            if (CmbStokNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Stok No Bilgisi Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CmbDepodanBildirimeDepoNo.SelectedIndex = -1;
                return;
            }
            if (TxtMiktar.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Miktar Bilgisi Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CmbDepodanBildirimeDepoNo.SelectedIndex = -1;
                return;
            }

            id = CmbDepodanBildirimeDepoNo.SelectedValue.ConInt();
            DepoKayit depoKayit = depoKayitManagercs.Get(id);
            TxtDepodanBildirimeDepoAdresi.Text = depoKayit.Aciklama;

            CmbDepodanBildirimeMalzemeYeri.DataSource = depoKayitLokasyonManager.GetListLokasyon(id);
            CmbDepodanBildirimeMalzemeYeri.ValueMember = "Id";
            CmbDepodanBildirimeMalzemeYeri.DisplayMember = "Lokasyon";
            CmbDepodanBildirimeMalzemeYeri.SelectedValue = "";

            StokGirisCıkıs stokGirisCıkıs = stokGirisCikisManager.DepoRafBul(CmbStokNo.Text, CmbDepodanBildirimeDepoNo.Text);
            if (stokGirisCıkıs == null)
            {
                CmbDepodanBildirimeMalzemeYeri.Text = "";
            }
            else
            {
                CmbDepodanBildirimeMalzemeYeri.Text = stokGirisCıkıs.DusulenMalzemeYeri;
            }
        }
        string MiktarKontrol(string stokNo, string depoNo, string seriNo, string lotNo, string revizyon, int istenenMiktar)
        {
            DepoMiktar depoMiktar = depoMiktarManager.Get(stokNo, depoNo, seriNo, lotNo, revizyon);
            if (depoMiktar == null)
            {
                return stokNo + " Stok Numarasına Göre Depo Stoğunda Kayıt Bulunamamıştır! \nDepoya Kayıt Yapmak İçin İşlem Türü Olarak '100-YENİ DEPO GİRİŞİ' Adımını İzleyebilirsiniz.";
            }
            mevcutMiktar = depoMiktar.Miktar;
            if (mevcutMiktar < istenenMiktar)
            {
                return "Depo Stoğunda Girmiş Olduğunuz Miktar Kadar Malzeme Bulunmamaktadır!\nStokta Bulunan Sayı=" + mevcutMiktar;
            }
            return "OK";
        }
        string BildirimdenDepoyaKontrol(string stokNo, string seriNo, string lotNo, string revizyon, string dusulenDepoAbf)
        {
            StokGirisCıkıs stokGirisCıkıs = stokGirisCikisManager.BildirimdenDepoya(stokNo, seriNo, lotNo, revizyon, dusulenDepoAbf);
            if (stokGirisCıkıs == null)
            {
                return stokNo + " Nolu Stok Numarası " + dusulenDepoAbf + " Bildirim Numarasına Daha Önce Düşülmemiştir!\nLütfen Düşmek İstediğiniz Malzemenin Bildirim Numarasını Tekrar Kontrol Ediniz.";
            }
            return "OK";
        }

        private void CmbDepoNoDusulen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            id = CmbDepoNoDusulen.SelectedValue.ConInt();
            DepoKayit depoKayit = depoKayitManagercs.Get(id);
            TxtDepoAdresiDusulen.Text = depoKayit.Aciklama;

            CmbMalzemeYeriDusulen.DataSource = depoKayitLokasyonManager.GetListLokasyon(id);
            CmbMalzemeYeriDusulen.ValueMember = "Id";
            CmbMalzemeYeriDusulen.DisplayMember = "Lokasyon";
            CmbMalzemeYeriDusulen.SelectedValue = "";
        }

        private void BtnMalzemeYeri_Click(object sender, EventArgs e)
        {
            FrmDepoLokasyonKayit frmDepoLokasyonKayit = new FrmDepoLokasyonKayit();
            frmDepoLokasyonKayit.ShowDialog();
        }
    }
}
