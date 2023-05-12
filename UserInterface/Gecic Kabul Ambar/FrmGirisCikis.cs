using Business.Concreate;
using Business.Concreate.AnaSayfa;
using Business.Concreate.BakimOnarim;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.Depo;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using Entity;
using Entity.AnaSayfa;
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
using UserInterface.Ana_Sayfa;
using UserInterface.BakımOnarım;
using UserInterface.STS;

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmGirisCikis : Form
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
        BarkodManager barkodManager;
        ArizaKayitManager arizaKayitManager;
        BildirimYetkiManager bildirimYetkiManager;
        AbfMalzemeManager abfMalzemeManager;

        List<GorevAtamaPersonel> gorevAtamaPersonels;
        //List<Malzeme> malzemes;

        List<MalzemeKayit> malzemeKayits;
        List<AbfMalzeme> abfMalzemes;

        public object[] infos;
        bool start = true, miktarKontrol = false;
        string readedBarcode, st = "", takipdurumu, malzemeYeri = "", islemAdimiSorumlusu;
        int miktar, mevcutMiktar, dusulenMiktar, cekilenMiktar, id;

        List<Malzeme> malzemes = new List<Malzeme>();
        public FrmGirisCikis()
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
            barkodManager = BarkodManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
        }

        private void CmbIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbIslemTuru.SelectedIndex == 0 && CmbDusumTuru.SelectedIndex == 0)
            {
                GrbIslemYapılacakDepo.Visible = true;
                GrbDepodanDepoya.Visible = false;
                GrbDepodanBildirime.Visible = false;
                GrbBildirimdenDepoya.Visible = false;
                LblBirimFiyat.Visible = true; TxtBirimFiyat.Visible = true;
                return;
            }
            if (CmbIslemTuru.SelectedIndex == 1 && CmbDusumTuru.SelectedIndex == 0)
            {
                GrbIslemYapılacakDepo.Visible = false;
                GrbDepodanDepoya.Visible = true;
                GrbDepodanBildirime.Visible = false;
                GrbBildirimdenDepoya.Visible = false;
                LblBirimFiyat.Visible = false; TxtBirimFiyat.Visible = false;
                return;
            }
            if (CmbIslemTuru.SelectedIndex == 2 && CmbDusumTuru.SelectedIndex == 0)
            {
                GrbDepodanDepoya.Visible = false;
                GrbIslemYapılacakDepo.Visible = false;
                GrbDepodanBildirime.Visible = true;
                GrbBildirimdenDepoya.Visible = false;
                LblBirimFiyat.Visible = false; TxtBirimFiyat.Visible = false;
                return;
            }
            if (CmbIslemTuru.SelectedIndex == 3 && CmbDusumTuru.SelectedIndex == 0)
            {
                GrbDepodanDepoya.Visible = false;
                GrbIslemYapılacakDepo.Visible = false;
                GrbDepodanBildirime.Visible = false;
                GrbBildirimdenDepoya.Visible = true;
                LblBirimFiyat.Visible = false; TxtBirimFiyat.Visible = false;
                return;
            }
            if (CmbIslemTuru.SelectedIndex == 0 && CmbDusumTuru.SelectedIndex == 1)
            {
                GrbIslemYapılacakDepo.Visible = true;
                GrbDepodanDepoya.Visible = false;
                GrbDepodanBildirime.Visible = false;
                GrbBildirimdenDepoya.Visible = false;
                LblBirimFiyatManuel.Visible = true; TxtBirimFiyatManuel.Visible = true;
                return;
            }
            if (CmbIslemTuru.SelectedIndex == 1 && CmbDusumTuru.SelectedIndex == 1)
            {
                GrbIslemYapılacakDepo.Visible = false;
                GrbDepodanDepoya.Visible = true;
                GrbDepodanBildirime.Visible = false;
                GrbBildirimdenDepoya.Visible = false;
                LblBirimFiyatManuel.Visible = false; TxtBirimFiyatManuel.Visible = false;
                return;
            }
            if (CmbIslemTuru.SelectedIndex == 2 && CmbDusumTuru.SelectedIndex == 1)
            {
                GrbDepodanDepoya.Visible = false;
                GrbIslemYapılacakDepo.Visible = false;
                GrbDepodanBildirime.Visible = true;
                GrbBildirimdenDepoya.Visible = false;
                LblBirimFiyatManuel.Visible = false; TxtBirimFiyatManuel.Visible = false;
                return;
            }
            if (CmbIslemTuru.SelectedIndex == 3 && CmbDusumTuru.SelectedIndex == 1)
            {
                GrbDepodanDepoya.Visible = false;
                GrbIslemYapılacakDepo.Visible = false;
                GrbDepodanBildirime.Visible = false;
                GrbBildirimdenDepoya.Visible = true;
                LblBirimFiyatManuel.Visible = false; TxtBirimFiyatManuel.Visible = false;
                return;
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageGirisCikis"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void FrmGirisCikis_Load(object sender, EventArgs e)
        {
            CmbDepo();
            CmbDepoCekilen();
            CmbDepoDusulen();
            CmbDepodanBildirime();
            CmbBildirimdenDepoya();
            StokBilgileri();
            start = false;
            contextMenuStrip1.Items[0].Enabled = false;
            CmbDusumTuru.SelectedIndex = 0;
        }

        void StokBilgileri()
        {
            malzemes = malzemeManager.GetList();
            CmbStokManuel.DataSource = malzemes;
            CmbStokManuel.ValueMember = "Id";
            CmbStokManuel.DisplayMember = "StokNo";
            CmbStokManuel.SelectedValue = 0;
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

        private void CmbDepoNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            id = CmbDepoNo.SelectedValue.ConInt();
            DepoKayit depoKayit = depoKayitManagercs.Get(id);
            CmbAdres.Text = depoKayit.DepoAdi;

            TxtMalzemeYeri.DataSource = depoKayitLokasyonManager.GetListLokasyon(id);
            TxtMalzemeYeri.ValueMember = "Id";
            TxtMalzemeYeri.DisplayMember = "Lokasyon";
            TxtMalzemeYeri.SelectedValue = "";
        }

        private void CmbBildirimdenDepoyaDepoNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            id = CmbBildirimdenDepoyaDepoNo.SelectedValue.ConInt();
            DepoKayit depoKayit = depoKayitManagercs.Get(id);
            TxtBildirimdenDepoyaDepoAdres.Text = depoKayit.DepoAdi;

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
            TxtDepodanBildirimeDepoAdresi.Text = depoKayit.DepoAdi;

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
            TxtDepoAdresiCekilen.Text = depoKayit.DepoAdi;

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

        private void CmbDepoNoDusulen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            id = CmbDepoNoDusulen.SelectedValue.ConInt();
            DepoKayit depoKayit = depoKayitManagercs.Get(id);
            TxtDepoAdresiDusulen.Text = depoKayit.DepoAdi;

            CmbMalzemeYeriDusulen.DataSource = depoKayitLokasyonManager.GetListLokasyon(id);
            CmbMalzemeYeriDusulen.ValueMember = "Id";
            CmbMalzemeYeriDusulen.DisplayMember = "Lokasyon";
            CmbMalzemeYeriDusulen.SelectedValue = "";
        }

        string Control()
        {
            if (TxtAciklama.Text == "")
            {
                return "Lütfen Açıklama bilgisini doldurunuz!";
            }
            if (CmbIslemTuru.Text == "")
            {
                return "Lütfen öncelikle işlem türü seçiniz!";
            }
            if (CmbIslemTuru.Text == "100-YENİ DEPO GİRİŞİ")
            {
                if (CmbDepoNo.Text == "")
                {
                    return "Lütfen öncelikle Depo No bilgisini doldurunuz!";
                }
                if (TxtMalzemeYeri.Text == "")
                {
                    return "Lütfen öncelikle Malzeme Yeri bilgisini doldurunuz!";
                }
                if (TxtBirimFiyat.Text == "")
                {
                    return "Lütfen öncelikle Malzeme Birim Fiyatı bilgisini doldurunuz!";
                }
            }
            if (CmbIslemTuru.Text == "101-DEPODAN DEPOYA İADE")
            {
                //if (CmbDepoNoCekilen.Text == "")
                //{
                //    return "Lütfen öncelikle Çekilen Depo no bilgisini doldurunuz!";
                //}
                //if (CmbMalzemeYeriCekilen.Text == "")
                //{
                //    return "Lütfen öncelikle Çekilen Malzeme Yerini seçiniz!";
                //}
                if (CmbDepoNoDusulen.Text == "")
                {
                    return "Lütfen öncelikle Düşülen Depo No bilgisini doldurunuz!";
                }
                if (CmbMalzemeYeriDusulen.Text == "")
                {
                    return "Lütfen öncelikle Düşülen Malzeme Yeri bilgisini doldurunu!";
                }
            }
            if (CmbIslemTuru.Text == "102-DEPODAN BİLDİRİME ÇEKİM")
            {
                //if (CmbDepodanBildirimeDepoNo.Text == "")
                //{
                //    return "Lütfen öncelikle Depo No bilgisini doldurunuz!";
                //}
                //if (CmbDepodanBildirimeMalzemeYeri.Text == "")
                //{
                //    return "Lütfen öncelikle Malzeme yeri bilgisini doldurunuz! ";
                //}
                if (TxtDepodanBildirimeAbfNo.Text == "")
                {
                    return "Lütfen öncelikle Abf No bilgisini doldurunuz!";
                }
            }
            if (CmbIslemTuru.Text == "201-BİLDİRİMDEN DEPOYA İADE")
            {
                if (TxtBildirimdenDepoyaFormNo.Text == "")
                {
                    return "Lütfen öncelikle Form No bilgisini doldurunuz!";
                }
                if (CmbBildirimdenDepoyaDepoNo.Text == "")
                {
                    return "Lütfen öncelikle Depo No bilgisini doldurunuz!";
                }
                if (CmbBildirimdenDepoyaMalzemeYeri.Text == "")
                {
                    return "Lütfen Malzeme Yeri bilgisini doldurunuz!";
                }
            }
            return "OK";
        }
        string BilgiControl()
        {
            string lotNo = "", seriNo = "", revizyon = "";
            if (takipdurumu == "LOT NO")
            {
                lotNo = LblSeriLotNo.Text;
                seriNo = "N/A";
                revizyon = LblRevizyon.Text;
            }
            else
            {
                seriNo = LblSeriLotNo.Text;
                lotNo = "N/A";
                revizyon = LblRevizyon.Text;
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

            if (depoMiktar.RezerveDurumu == "REZERVE")
            {
                if (takipdurumu == "LOT NO")
                {
                    if (depoMiktar.Miktar == 1)
                    {
                        rezerveId = depoMiktar.RezerveId;
                        return "REZERVE HATASI";
                    }
                    else
                    {
                        DepoMiktar depoMiktar2 = new DepoMiktar(depoMiktar.Id, infos[1].ToString(), "REZERVE DEĞİL", 0);
                        depoMiktarManager.DepoRezerve(depoMiktar2);
                    }
                }
                else
                {
                    rezerveId = depoMiktar.RezerveId;
                    return "REZERVE HATASI";
                }
            }

            return "OK";

        }
        int rezerveId;
        string BilgiControlManuel()
        {
            string lotNo = "", seriNo = "", revizyon = "";
            if (takipdurumu == "LOT NO")
            {
                lotNo = AdvMalzemeOnizleme.CurrentRow.Cells["SeriLotNo"].Value.ToString();
                seriNo = "N/A";
                revizyon = AdvMalzemeOnizleme.CurrentRow.Cells["Rev"].Value.ToString();
            }
            else
            {
                seriNo = AdvMalzemeOnizleme.CurrentRow.Cells["SeriLotNo"].Value.ToString();
                lotNo = "N/A";
                revizyon = AdvMalzemeOnizleme.CurrentRow.Cells["Rev"].Value.ToString();
            }

            DepoMiktar depoMiktar = depoMiktarManager.StokSeriLotKontrol(CmbStokManuel.Text, depoNoDusulen, seriNo, lotNo, revizyon);
            if (depoMiktar == null || depoMiktar.Miktar == 0)
            {
                if (takipdurumu == "LOT NO")
                {
                    return CmbStokManuel.Text + " Stok Numaralı Malzemenin Lot Bilgisi veya Revizyon Bilgisi " + depoNoDusulen + " Nolu Depo Kayıtlarındaki Bilgi İle Uyuşmadığı İçin İşlem Gerçekleştirilemez!";
                }
                else
                {
                    return CmbStokManuel.Text + " Stok Numaralı Malzemenin Seri No Bilgisi " + depoNoDusulen + " Nolu Depo Kayıtlarındaki Seri No Bilgisileri İle Uyuşmadığı İçin İşlem Gerçekleştirilemez!";
                }
            }
            if (depoMiktar.RezerveDurumu == "REZERVE")
            {
                if (takipdurumu != "LOT NO")
                {

                    rezerveId = depoMiktar.RezerveId;
                    return "REZERVE HATASI";

                    //if (depoMiktar.Miktar == 1)
                    //{
                    //    rezerveId = depoMiktar.RezerveId;
                    //    return "REZERVE HATASI";
                    //}
                    //else
                    //{
                    //    DepoMiktar depoMiktar2 = new DepoMiktar(depoMiktar.Id, infos[1].ToString(), "REZERVE DEĞİL", 0);
                    //    depoMiktarManager.DepoRezerve(depoMiktar2);
                    //}
                }

            }
            return "OK";

        }

        string MiktarKontrol()
        {
            if (CmbIslemTuru.Text == "100-YENİ DEPO GİRİŞİ")
            {
                depoNoDusulen = CmbDepoNo.Text;
                malzemeYeri = TxtMalzemeYeri.Text;
            }

            if (CmbIslemTuru.Text == "101-DEPODAN DEPOYA İADE")
            {
                depoNoDusulen = depoBilgileri.DepoNo;
                malzemeYeri = depoBilgileri.DepoLokasyon;
                if (depoBilgileri == null)
                {
                    return "Malzemenin lokasyon bilgileri bulunamadı!";
                }
                string bilgiControl = BilgiControl();

                if (bilgiControl != "OK")
                {
                    if (bilgiControl == "REZERVE HATASI")
                    {
                        ArizaKayit arizaKayit = arizaKayitManager.GetId(rezerveId);
                        string abf = arizaKayit.AbfFormNo.ToString();
                        DialogResult dr = MessageBox.Show("Bu malzeme " + abf + " form numaralı arıza için Rezerve edilmiştir!\nİsterseniz Rezerve işlemini iptal ederek işleminize devam edebilirsiniz!\nRezerve İşlemini iptal etmek istiyor musunuz?", "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr != DialogResult.Yes)
                        {
                            return "İşlem iptal edildi!";
                        }

                        abfMalzemesStoklar = new List<AbfMalzeme>();
                        abfMalzemesStoklar = abfMalzemeManager.GetList(rezerveId, "REZERVE EDİLDİ");
                        foreach (AbfMalzeme item in abfMalzemesStoklar)
                        {
                            if (item.SokulenStokNo == CmbStokManuel.Text)
                            {
                                abfMalzemeManager.TeminBilgisi(item.Id, "REZERVE İPTAL EDİLDİ", infos[1].ToString(), item.MalzemeIslemAdimi);
                            }
                        }
                    }
                    else
                    {
                        return bilgiControl;
                    }
                }
            }
            if (CmbIslemTuru.Text == "102-DEPODAN BİLDİRİME ÇEKİM")
            {
                depoNoDusulen = depoBilgileri.DepoNo;
                malzemeYeri = depoBilgileri.DepoLokasyon;
                if (depoBilgileri == null)
                {
                    return "Malzemenin lokasyon bilgileri bulunamadı!";
                }
                string bilgiControl = BilgiControl();

                if (bilgiControl != "OK")
                {
                    if (bilgiControl == "REZERVE HATASI")
                    {
                        ArizaKayit arizaKayit = arizaKayitManager.GetId(rezerveId);
                        string abf = arizaKayit.AbfFormNo.ToString();

                        abfMalzemesStoklar = new List<AbfMalzeme>();

                        if (abf == TxtDepodanBildirimeAbfNo.Text)
                        {
                            abfMalzemesStoklar = abfMalzemeManager.GetList(rezerveId);
                            foreach (AbfMalzeme item in abfMalzemesStoklar)
                            {
                                if (item.SokulenStokNo == CmbStokManuel.Text)
                                {
                                    if (item.TeminDurumu != "REZERVE EDİLDİ")
                                    {
                                        return "Malzeme henüz rezerve edilmemiştir! Lütfen öncelikle Malzeme Hazırlama sayfasından, rezerve işlemerini tamamlayınız!";
                                    }
                                }
                            }
                        }

                        else
                        {
                            DialogResult dr = MessageBox.Show("Bu malzeme " + abf + " form numaralı arıza için Rezerve edilmiştir!\nİsterseniz Rezerve işlemini iptal ederek işleminize devam edebilirsiniz!\nRezerve İşlemini iptal etmek istiyor musunuz?", "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dr != DialogResult.Yes)
                            {
                                return "İşlem iptal edildi!";
                            }

                            abfMalzemesStoklar = new List<AbfMalzeme>();
                            abfMalzemesStoklar = abfMalzemeManager.GetList(rezerveId, "REZERVE EDİLDİ");
                            foreach (AbfMalzeme item in abfMalzemesStoklar)
                            {
                                if (item.SokulenStokNo == CmbStokManuel.Text)
                                {
                                    abfMalzemeManager.TeminBilgisi(item.Id, "REZERVE İPTAL EDİLDİ", infos[1].ToString(), item.MalzemeIslemAdimi);
                                }
                            }
                        }

                        
                    }
                    else
                    {
                        return bilgiControl;
                    }
                }
            }

            if (CmbIslemTuru.Text == "101-DEPODAN DEPOYA İADE")
            {
                if (takipdurumu == "LOT NO")
                {
                    string control = MiktarKontrol(CmbStokNo.Text, depoBilgileri.DepoNo, "N/A", LblSeriLotNo.Text, LblRevizyon.Text, TxtMiktar.Text.ConInt());
                    if (control != "OK")
                    {
                        return control;
                    }
                }
                else
                {
                    string control2 = MiktarKontrol(CmbStokNo.Text, depoBilgileri.DepoNo, LblSeriLotNo.Text, "N/A", LblRevizyon.Text, TxtMiktar.Text.ConInt());
                    if (control2 != "OK")
                    {
                        return control2;
                    }
                }

            }
            if (CmbIslemTuru.Text == "102-DEPODAN BİLDİRİME ÇEKİM")
            {
                if (takipdurumu == "LOT NO")
                {
                    string control = MiktarKontrol(CmbStokNo.Text, depoBilgileri.DepoNo, "N/A", LblSeriLotNo.Text, LblRevizyon.Text, TxtMiktar.Text.ConInt());
                    if (control != "OK")
                    {
                        return control;
                    }
                }
                else
                {
                    string control2 = MiktarKontrol(CmbStokNo.Text, depoBilgileri.DepoNo, LblSeriLotNo.Text, "N/A", LblRevizyon.Text, TxtMiktar.Text.ConInt());
                    if (control2 != "OK")
                    {
                        return control2;
                    }
                }
            }
            if (CmbIslemTuru.Text == "201-BİLDİRİMDEN DEPOYA İADE")
            {
                if (takipdurumu == "LOT NO")
                {
                    string control = BildirimdenDepoyaKontrol(CmbStokNo.Text, "N/A", LblSeriLotNo.Text, LblRevizyon.Text, TxtBildirimdenDepoyaFormNo.Text);
                    if (control != "OK")
                    {
                        return control;
                    }
                }
                else
                {
                    string control2 = BildirimdenDepoyaKontrol(CmbStokNo.Text, LblSeriLotNo.Text, "N/A", LblRevizyon.Text, TxtBildirimdenDepoyaFormNo.Text);
                    if (control2 != "OK")
                    {
                        return control2;
                    }

                }
            }
            return "OK";
        }
        int sayac = 0;
        private void TxtBarkod_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TmrBarcode.Stop();
                if (sayac < 4)
                {
                    sayac++;
                    return;
                }
                TmrBarcode.Start();
                /*
                sayac = 0;
                string kontrol = Control();
                if (kontrol != "OK")
                {
                    MessageBox.Show(kontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtBarkod.Clear();
                    return;
                }
                readedBarcode = TxtBarkod.Text;
                string[] array = readedBarcode.Split(' ');



                int id = array[0].ConInt();
                Barkod barkod = barkodManager.Get(id);
                if (barkod == null)
                {
                    MessageBox.Show("Bu malzemeye ait kayıt bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                /*
                string[] array = TxtBarkod.Text.Split(' ');
                string[] array2 = readedBarcode.Split('*');


                string stok = array2[0].ToString();
                if (stok != "")
                {
                    for (int j = 1; j < array2.Length; j++)
                    {

                        stok = stok + "-" + array2[j].ToString();
                        if (array2.Count() == 3 && j == 1)
                        {
                            continue;
                        }
                        string[] array3 = array[2].Split();
                        if (array3[0].ToString() == "_".ToString())
                        {
                            string[] array4 = stok.Split(' ');
                            stok = array4[0].ToString() + " " + array4[1].ToString() + " " + "+";
                            st = array4[0].ToString();
                            //10006269-5 123 _"
                            //TxtBarkod.Text = stok + "-" + array3[0].ToString();
                        }
                        TxtBarkod.Text = stok;
                    }
                }
                */

                /*
                Malzeme malzeme = malzemeManager.Get(barkod.StokNo);
                if (malzeme == null)
                {
                    CmbStokNo.Text = "";
                    LblTanim.Text = "";
                    LblBirim.Text = "";
                    LblRevizyon.Text = "";
                    LblSeriLotNo.Text = "";
                }
                else
                {
                    CmbStokNo.Text = barkod.StokNo;
                    LblTanim.Text = barkod.Tanim;
                    LblBirim.Text = malzeme.Birim;
                    LblSeriLotNo.Text = barkod.SeriNo;
                    LblRevizyon.Text = barkod.Revizyon;
                    takipdurumu = malzeme.TakipDurumu;

                }

                string miktarKontrol = MiktarKontrol();

                if (miktarKontrol != "OK")
                {
                    MessageBox.Show(miktarKontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtBarkod.Clear();
                    return;
                }

                if (CmbStokNo.Text != "00")
                {
                    //sirano++;
                    DtgList.Rows.Add();
                    int sonSatir = DtgList.RowCount - 1;

                    //DtgList.Rows[sonSatir].Cells["Column1"].Value = sirano;
                    DtgList.Rows[sonSatir].Cells["Column13"].Value = CmbIslemTuru.Text;
                    DtgList.Rows[sonSatir].Cells["Column2"].Value = CmbStokNo.Text;
                    DtgList.Rows[sonSatir].Cells["Column3"].Value = LblTanim.Text;
                    if (takipdurumu == "LOT NO")
                    {
                        DtgList.Rows[sonSatir].Cells["Column4"].Value = TxtMiktar.Text;
                    }
                    else
                    {
                        DtgList.Rows[sonSatir].Cells["Column4"].Value = 1;
                    }
                    DtgList.Rows[sonSatir].Cells["Column5"].Value = LblBirim.Text;
                    DtgList.Rows[sonSatir].Cells["Column6"].Value = DtTarih.Value;
                    DtgList.Rows[sonSatir].Cells["Column14"].Value = TxtAciklama.Text;

                    if (CmbIslemTuru.Text == "100-YENİ DEPO GİRİŞİ")
                    {
                        DtgList.Rows[sonSatir].Cells["Column18"].Value = id.ToString();
                        DtgList.Rows[sonSatir].Cells["Column15"].Value = CmbDepoNo.Text; // DÜŞÜLEN DEPO
                        DtgList.Rows[sonSatir].Cells["Column16"].Value = CmbAdres.Text;
                        DtgList.Rows[sonSatir].Cells["Column17"].Value = TxtMalzemeYeri.Text;
                        DtgList.Rows[sonSatir].Cells["Column7"].Value = ""; // ÇEKİLEN DEPO
                        DtgList.Rows[sonSatir].Cells["Column8"].Value = "";
                        DtgList.Rows[sonSatir].Cells["Column9"].Value = "";
                        //DtgList.Rows[sonSatir].Cells["Column18"].Value = ""; // ABF FORM NO
                        DtgList.Rows[sonSatir].Cells["Column19"].Value = ""; // TALEP EDEN PERSONEL
                        DtgList.Rows[sonSatir].Cells["Column1"].Value = TxtBirimFiyat.Text; // MALZEME BİRİM FİYATI
                    }

                    if (CmbIslemTuru.Text == "101-DEPODAN DEPOYA İADE")
                    {
                        DtgList.Rows[sonSatir].Cells["Column18"].Value = id.ToString();
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
                        DtgList.Rows[sonSatir].Cells["Column18"].Value = id.ToString();
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
                        DtgList.Rows[sonSatir].Cells["Column18"].Value = id.ToString();
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
                        DtgList.Rows[sonSatir].Cells["Column12"].Value = LblSeriLotNo.Text;
                    }
                    else
                    {
                        DtgList.Columns["Column12"].Visible = false;
                        DtgList.Rows[sonSatir].Cells["Column12"].Value = "N/A";
                        DtgList.Columns["Column10"].Visible = true;
                        DtgList.Rows[sonSatir].Cells["Column10"].Value = LblSeriLotNo.Text;
                    }
                    DtgList.Rows[sonSatir].Cells["Column11"].Value = LblRevizyon.Text;
                    contextMenuStrip1.Items[0].Enabled = true;
                    Temizle();

                }
                Hesapla();
                TxtBarkod.Clear();     
                */
            }

            //Hesapla();

        }
        void Hesapla()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                /*if (DtgDepoBilgileri.Rows[i].Cells[4].Value.ConInt()==0)
                {
                    toplam += Convert.ToDouble(DtgDepoBilgileri.Rows[i].Cells[13].Value);
                }*/
                toplam += Convert.ToDouble(DtgList.Rows[i].Cells["Column4"].Value);
            }
            LblToplam.Text = toplam.ToString();
        }
        void Temizle()
        {
            TxtBarkod.Clear();
            //TxtBirimFiyat.Clear();
            //CmbStokNo.Text = "00"; LblTanim.Text = "00"; LblBirim.Text = "00"; LblSeriLotNo.Text = "00"; LblRevizyon.Text = "00"; TxtBirimFiyat.Clear();
        }
        string islemTuru, stokNo, tanim, seriNo, lotNo, revizyon, depoNoDusulen, depoAdresi;

        private void TxtMiktarManuel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtMiktarManuel_TextChanged(object sender, EventArgs e)
        {
            if (CmbStokManuel.Text == "")
            {
                //MessageBox.Show("Öncelikle Bir Stok Numarası Giriniz.");
                return;
            }
            if (TxtMiktarManuel.Text == "")
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
            for (int i = 0; i < TxtMiktarManuel.Text.ConInt(); i++)
            {
                AdvMalzemeOnizleme.Rows.Add();
                int sonSatir = AdvMalzemeOnizleme.RowCount - 1;
                AdvMalzemeOnizleme.Rows[sonSatir].Cells["SiraNo"].Value = i + 1;
                AdvMalzemeOnizleme.Rows[sonSatir].Cells["SeriLotNo"].Value = "";
                AdvMalzemeOnizleme.Rows[sonSatir].Cells["Rev"].Value = "";

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
        List<AbfMalzeme> abfMalzemesStoklar;
        private void BtnListEkle_Click(object sender, EventArgs e)
        {
            if (CmbIslemTuru.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle yapılacak işlem türünü seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbIslemTuru.Text == "100-YENİ DEPO GİRİŞİ")
            {
                if (TxtBirimFiyatManuel.Text == "")
                {
                    DialogResult dr = MessageBox.Show("Malzeme İçin Birim Fiyatı Tanımlamadınız!\nYinede Devam Etmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No)
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
                string bilgiControl = BilgiControlManuel();

                if (bilgiControl != "OK")
                {
                    if (bilgiControl == "REZERVE HATASI")
                    {
                        ArizaKayit arizaKayit = arizaKayitManager.GetId(rezerveId);
                        string abf = arizaKayit.AbfFormNo.ToString();
                        DialogResult dr = MessageBox.Show("Bu malzeme " + abf + " form numaralı arıza için Rezerve edilmiştir!\nİsterseniz Rezerve işlemini iptal ederek işleminize devam edebilirsiniz!\nRezerve İşlemini iptal etmek istiyor musunuz?", "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr != DialogResult.Yes)
                        {
                            return;
                        }

                        abfMalzemesStoklar = new List<AbfMalzeme>();
                        abfMalzemesStoklar = abfMalzemeManager.GetList(rezerveId, "REZERVE EDİLDİ");
                        foreach (AbfMalzeme item in abfMalzemesStoklar)
                        {
                            if (item.SokulenStokNo == CmbStokManuel.Text)
                            {
                                abfMalzemeManager.TeminBilgisi(item.Id, "REZERVE İPTAL EDİLDİ", infos[1].ToString(), item.MalzemeIslemAdimi);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(bilgiControl, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

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
                string bilgiControl = BilgiControlManuel();

                if (bilgiControl != "OK")
                {
                    if (bilgiControl == "REZERVE HATASI")
                    {
                        ArizaKayit arizaKayit = arizaKayitManager.GetId(rezerveId);
                        string abf = arizaKayit.AbfFormNo.ToString();
                        abfMalzemesStoklar = new List<AbfMalzeme>();

                        if (abf == TxtDepodanBildirimeAbfNo.Text)
                        {
                            abfMalzemesStoklar = abfMalzemeManager.GetList(rezerveId);
                            foreach (AbfMalzeme item in abfMalzemesStoklar)
                            {
                                if (item.SokulenStokNo == CmbStokManuel.Text)
                                {
                                    if (item.TeminDurumu != "REZERVE EDİLDİ")
                                    {
                                        MessageBox.Show("Malzeme henüz rezerve edilmemiştir! Lütfen öncelikle Malzeme Hazırlama sayfasından, rezerve işlemerini tamamlayınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            DialogResult dr = MessageBox.Show("Bu malzeme " + abf + " form numaralı arıza için Rezerve edilmiştir!\nİsterseniz Rezerve işlemini iptal ederek işleminize devam edebilirsiniz!\nRezerve İşlemini iptal etmek istiyor musunuz?", "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dr != DialogResult.Yes)
                            {
                                return;
                            }

                            abfMalzemesStoklar = new List<AbfMalzeme>();
                            abfMalzemesStoklar = abfMalzemeManager.GetList(rezerveId, "REZERVE EDİLDİ");
                            foreach (AbfMalzeme item in abfMalzemesStoklar)
                            {
                                if (item.SokulenStokNo == CmbStokManuel.Text)
                                {
                                    abfMalzemeManager.TeminBilgisi(item.Id, "REZERVE İPTAL EDİLDİ", infos[1].ToString(), item.MalzemeIslemAdimi);
                                }
                            }
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show(bilgiControl, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            /*string control = Control();

            if (control != "")
            {
                MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            //DtgList.Rows.Clear();
            foreach (DataGridViewRow item in AdvMalzemeOnizleme.Rows)
            {
                if (CmbIslemTuru.Text == "101-DEPODAN DEPOYA İADE")
                {
                    if (takipdurumu == "LOT NO")
                    {
                        string control = MiktarKontrol(CmbStokManuel.Text, CmbDepoNoCekilen.Text, "N/A", item.Cells["SeriLotNo"].Value.ToString(), "N/A", TxtMiktarManuel.Text.ConInt());
                        if (control != "OK")
                        {
                            MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    string control2 = MiktarKontrol(CmbStokManuel.Text, CmbDepoNoCekilen.Text, item.Cells["SeriLotNo"].Value.ToString(), "N/A", item.Cells["Rev"].Value.ToString(), TxtMiktarManuel.Text.ConInt());
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
                        string control = MiktarKontrol(CmbStokManuel.Text, CmbDepodanBildirimeDepoNo.Text, "N/A", item.Cells["SeriLotNo"].Value.ToString(), item.Cells["Rev"].Value.ToString(), TxtMiktarManuel.Text.ConInt());
                        if (control != "OK")
                        {
                            MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        string control2 = MiktarKontrol(CmbStokManuel.Text, CmbDepodanBildirimeDepoNo.Text, item.Cells["SeriLotNo"].Value.ToString(), "N/A", item.Cells["Rev"].Value.ToString(), TxtMiktarManuel.Text.ConInt());
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
                        string control = BildirimdenDepoyaKontrol(CmbStokManuel.Text, "N/A", item.Cells["SeriLotNo"].Value.ToString(), item.Cells["Rev"].Value.ToString(), TxtBildirimdenDepoyaFormNo.Text);
                        if (control != "OK")
                        {
                            MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        string control2 = BildirimdenDepoyaKontrol(CmbStokManuel.Text, item.Cells["SeriLotNo"].Value.ToString(), "N/A", item.Cells["Rev"].Value.ToString(), TxtBildirimdenDepoyaFormNo.Text);
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
                DtgList.Rows[sonSatir].Cells["Column2"].Value = CmbStokManuel.Text;
                DtgList.Rows[sonSatir].Cells["Column3"].Value = TxtTanim.Text;

                DtgList.Rows[sonSatir].Cells["TeminTuru"].Value = teminTuru;

                if (takipdurumu == "LOT NO")
                {
                    DtgList.Rows[sonSatir].Cells["Column4"].Value = TxtMiktarManuel.Text;
                }
                else
                {
                    DtgList.Rows[sonSatir].Cells["Column4"].Value = 1;
                }
                DtgList.Rows[sonSatir].Cells["Column5"].Value = CmbBirim.Text;
                DtgList.Rows[sonSatir].Cells["Column6"].Value = DtgTarihManuel.Value;
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
                DtgList.Rows[sonSatir].Cells["Column11"].Value = item.Cells["Rev"].Value.ToString();
            }

            Hesapla();
        }

        private void AdvMalzemeOnizleme_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                AdvMalzemeOnizleme.Rows.RemoveAt(e.RowIndex);
            }
        }
        string teminTuru = "";
        private void CmbStokManuel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start)
            {
                return;
            }
            if (CmbStokManuel.Text == "")
            {
                return;
            }
            FillTools();
        }
        void FillTools()
        {
            id = CmbStokManuel.SelectedValue.ConInt();
            Malzeme malzeme = malzemeManager.Get(CmbStokManuel.Text);
            //StokGirisCıkıs stokGirisCıkıs = stokGirisCikisManager.StokGor(CmbStokNo.Text);
            TxtTanim.Text = malzeme.Tanim;
            CmbBirim.Text = malzeme.Birim;
            takipdurumu = malzeme.TakipDurumu;
            teminTuru = malzeme.TedarikTuru;
            /*if (stokGirisCıkıs == null)
            {
                mevcutMiktar = 0;
                return;
            }
            mevcutMiktar = stokGirisCıkıs.MevcutMiktar;*/

        }
        private void CmbDusumTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbDusumTuru.SelectedIndex == 0)
            {
                GrbBarkod.Visible = true;
                GrbManuelStok.Visible = false;
                CmbIslemTuru.SelectedIndex = -1;
            }
            if (CmbDusumTuru.SelectedIndex == 1)
            {
                GrbManuelStok.Visible = true;
                GrbBarkod.Visible = false;
                CmbIslemTuru.SelectedIndex = -1;
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
            DtgList.Rows.Clear();

            CmbIslemTuru.SelectedIndex = -1;
            CmbDepoNo.Text = ""; CmbAdres.Text = ""; TxtMalzemeYeri.Text = ""; TxtAciklama.Clear(); CmbDepoNoCekilen.Text = ""; CmbMalzemeYeriCekilen.Text = "";
            CmbDepoNoDusulen.Text = ""; CmbMalzemeYeriDusulen.Text = ""; CmbDepodanBildirimeDepoNo.Text = ""; CmbDepodanBildirimeMalzemeYeri.Text = "";
            TxtDepodanBildirimeAbfNo.Text = ""; TxtBildirimdenDepoyaFormNo.Text = ""; CmbBildirimdenDepoyaDepoNo.Text = "";
            CmbBildirimdenDepoyaMalzemeYeri.Text = ""; TxtBildirimdenDepoyaDepoAdres.Clear(); TxtDepodanBildirimeDepoAdresi.Clear();
            TxtDepoAdresiCekilen.Clear(); TxtDepoAdresiDusulen.Clear();
            LblToplam.Text = "0"; CmbStokManuel.SelectedIndex = -1; TxtTanim.Clear(); TxtMiktarManuel.Clear(); CmbBirim.SelectedIndex = -1;
            TxtBirimFiyatManuel.Clear(); AdvMalzemeOnizleme.Rows.Clear();
            CmbIslemTuru.SelectedIndex = -1;
            CmbDepoNo.SelectedIndex = -1;
            CmbAdres.Clear();
            TxtMalzemeYeri.SelectedIndex = -1;
            TxtAciklama.Clear();
            CmbDepodanBildirimeDepoNo.SelectedIndex = -1;
            TxtDepodanBildirimeDepoAdresi.Clear();
            CmbDepodanBildirimeMalzemeYeri.SelectedIndex = -1;
            TxtDepodanBildirimeAbfNo.Clear();
            LblDepodanBildirimePersonel.Text = "00";
            TxtBildirimdenDepoyaFormNo.Clear();
            LblBildirimdenDepoyaPersonel.Text = "00";
            CmbBildirimdenDepoyaDepoNo.SelectedIndex = -1;
            TxtBildirimdenDepoyaDepoAdres.Clear();
            CmbBildirimdenDepoyaMalzemeYeri.SelectedIndex = -1;
            CmbDepoNoCekilen.SelectedIndex = -1;
            TxtDepoAdresiCekilen.Clear();
            CmbMalzemeYeriCekilen.SelectedIndex = -1;
            CmbDepoNoDusulen.SelectedIndex = -1;
            TxtDepoAdresiDusulen.Clear();
            CmbMalzemeYeriDusulen.SelectedIndex = -1;
            CmbStokManuel.SelectedIndex = -1;
            TxtTanim.Clear();
            TxtMiktarManuel.Clear();
            CmbBirim.SelectedIndex = -1;
            TxtBirimFiyatManuel.Clear();
            AdvMalzemeOnizleme.Rows.Clear();
            DtgList.Rows.Clear();
            LblToplam.Text = "00";
        }

        private void BtnKaydet_Click_1(object sender, EventArgs e)
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
                        DepoGirisBekleyenKontrol();

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

                        stokGirisCikisManager.DepoBirimFiyat(item.Cells["Column1"].Value.ConDouble(), stokNo);
                    }

                    if (islemTuru == "101-DEPODAN DEPOYA İADE")
                    {
                        MalzemeHazirlamaControl();
                        DepoGirisBekleyenKontrol();
                        DepoMiktar depoMiktar = depoMiktarManager.StokSeriLotKontrol(stokNo, CmbDepoNoDusulen.Text, seriNo, lotNo, revizyon);
                        if (depoMiktar == null)
                        {
                            DepoMiktar depoMiktardepo = new DepoMiktar(stokNo, tanim, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), depoNoDusulen, depoAdresi, item.Cells["Column17"].Value.ToString(), mevcutMiktar, item.Cells["Column14"].Value.ToString());
                            depoMiktarManager.Add(depoMiktardepo);
                        }

                        dusulenMiktar = miktar;

                        string depoNoDusulen2 = item.Cells["Column15"].Value.ToString(); // düşülen
                        string depoNoCekilen2 = item.Cells["Column7"].Value.ToString(); // çekilen
                        string dusulenDepoLokasyon = item.Cells["Column17"].Value.ToString(); // düşülen depo lokasyon
                        string cekilenDepoLokasyon = item.Cells["Column9"].Value.ToString(); // çekilen depo lokasyon

                        DepoMiktar depo2 = depoMiktarManager.Get(stokNo, depoNoCekilen2, seriNo, lotNo, revizyon);
                        cekilenMiktar = depo2.Miktar - miktar;

                        mevcutMiktar = +miktar;

                        //DepoMiktar depoMiktar2 = new DepoMiktar(stokNo, tanim, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), depoNoDusulen, depoAdresi, item.Cells["Column17"].Value.ToString(), mevcutMiktar, item.Cells["Column14"].Value.ToString());
                        //depoMiktarManager.Add(depoMiktar2);

                        DepoMiktar depoDusulen = new DepoMiktar(stokNo, depoNoDusulen2, dusulenDepoLokasyon, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), dusulenMiktar);
                        depoMiktarManager.Update(depoDusulen, depo2.RezerveDurumu);

                        DepoMiktar depoCekilen = new DepoMiktar(stokNo, depoNoCekilen2, cekilenDepoLokasyon, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), cekilenMiktar);
                        depoMiktarManager.Update(depoCekilen, depo2.RezerveDurumu);


                        if (cekilenMiktar == 0)
                        {
                            depoMiktarManager.Delete(depo2.Id);
                        }

                        //if (dusulenMiktar == 0)
                        //{
                        //    depoMiktarManager.Delete(depoDusulen.Id);
                        //}

                        /*DepoMiktar miktar1 = depoMiktarManager.Get(stokNo, depoNoDusulen);
                        mevcutMiktar = miktar1.Miktar;*/

                        StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs(islemTuru, stokNo, tanim, item.Cells["Column5"].Value.ToString(), item.Cells["Column6"].Value.ConDate(), item.Cells["Column7"].Value.ToString(), item.Cells["Column8"].Value.ToString(), item.Cells["Column9"].Value.ToString(), item.Cells["Column15"].Value.ToString(), item.Cells["Column16"].Value.ToString(), item.Cells["Column17"].Value.ToString(), miktar, item.Cells["Column19"].Value.ToString(), item.Cells["Column14"].Value.ToString(), item.Cells["Column10"].Value.ToString(), item.Cells["Column12"].Value.ToString(), item.Cells["Column11"].Value.ToString());

                        stokGirisCikisManager.Add(stokGirisCıkıs);

                    }

                    if (islemTuru == "102-DEPODAN BİLDİRİME ÇEKİM")
                    {
                        MalzemeHazirlamaControl();
                        DepoMiktar depo2 = depoMiktarManager.Get(stokNo, item.Cells["Column7"].Value.ToString(), seriNo, lotNo, revizyon);
                        mevcutMiktar = depo2.Miktar;
                        mevcutMiktar = mevcutMiktar - miktar;
                        int silineceId = depo2.Id;
                        string depoNoDusulen2 = item.Cells["Column15"].Value.ToString(); // düşülen
                        string depoNoCekilen2 = item.Cells["Column7"].Value.ToString(); // çekilen
                        string dusulenDepoLokasyon = item.Cells["Column17"].Value.ToString(); // düşülen depo lokasyon
                        string cekilenDepoLokasyon = item.Cells["Column9"].Value.ToString(); // çekilen depo lokasyon

                        Malzeme malzeme = malzemeManager.Get(stokNo);
                        if (malzeme==null)
                        {
                            MessageBox.Show("Malzeme kaydı bulunamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (malzeme.TakipDurumu == "LOT NO")
                        {
                            DepoMiktar depoDusulen = new DepoMiktar(stokNo, depoNoCekilen2, cekilenDepoLokasyon, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), mevcutMiktar);
                            depoMiktarManager.Update(depoDusulen, "REZERVE DEĞİL");
                        }
                        else
                        {
                            DepoMiktar depoDusulen = new DepoMiktar(stokNo, depoNoCekilen2, cekilenDepoLokasyon, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), mevcutMiktar);
                            depoMiktarManager.Update(depoDusulen, depo2.RezerveDurumu);
                        }


                        if (mevcutMiktar == 0)
                        {
                            depoMiktarManager.Delete(silineceId);
                        }

                        StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs(islemTuru, stokNo, tanim, item.Cells["Column5"].Value.ToString(), item.Cells["Column6"].Value.ConDate(), item.Cells["Column7"].Value.ToString(), item.Cells["Column8"].Value.ToString(), item.Cells["Column9"].Value.ToString(), item.Cells["Column15"].Value.ToString(), "", "", miktar, item.Cells["Column19"].Value.ToString(), item.Cells["Column14"].Value.ToString(), item.Cells["Column10"].Value.ToString(), item.Cells["Column12"].Value.ToString(), item.Cells["Column11"].Value.ToString());

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
                        string dusulenDepoLokasyon = item.Cells["Column17"].Value.ToString(); // düşülen depo lokasyon

                        DepoMiktar depoDusulen = new DepoMiktar(stokNo, depoNoDusulen2, dusulenDepoLokasyon, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), mevcutMiktar);
                        depoMiktarManager.Update(depoDusulen, depoMiktar.RezerveDurumu);


                        StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs(islemTuru, stokNo, tanim, item.Cells["Column5"].Value.ToString(), item.Cells["Column6"].Value.ConDate(), item.Cells["Column7"].Value.ToString(), "", "", item.Cells["Column15"].Value.ToString(), item.Cells["Column16"].Value.ToString(), item.Cells["Column17"].Value.ToString(), miktar, item.Cells["Column19"].Value.ToString(), item.Cells["Column14"].Value.ToString(), item.Cells["Column10"].Value.ToString(), item.Cells["Column12"].Value.ToString(), item.Cells["Column11"].Value.ToString());

                        stokGirisCikisManager.Add(stokGirisCıkıs);

                    }
                }
                string mesaj = BildirimKayit();
                if (mesaj != "OK")
                {
                    if (mesaj!= "Server Ayarı Kapalı")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                MessageBox.Show("Bilgileri Başarıyla Kaydedişmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                start = true;
                LblToplam.Text = "0";
                Temizle();
                DtgList.Rows.Clear();
                start = false;
            }
        }


        private void BtnStokDuzelt_Click_1(object sender, EventArgs e)
        {

        }
        DepoMiktar depoBilgileri = null;
        private void TmrBarcode_Tick_1(object sender, EventArgs e)
        {
            string kontrol = Control();
            if (kontrol != "OK")
            {
                TmrBarcode.Stop();
                MessageBox.Show(kontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtBarkod.Clear();
                return;
            }
            readedBarcode = TxtBarkod.Text;
            string[] array = readedBarcode.Split(' ');



            int id = array[0].ConInt();
            Barkod barkod = barkodManager.Get(id);
            if (barkod == null)
            {
                TmrBarcode.Stop();
                MessageBox.Show("Bu malzemeye ait kayıt bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Malzeme malzeme = malzemeManager.Get(barkod.StokNo);
            if (malzeme == null)
            {
                CmbStokNo.Text = "";
                LblTanim.Text = "";
                LblBirim.Text = "";
                LblRevizyon.Text = "";
                LblSeriLotNo.Text = "";
            }
            else
            {
                CmbStokNo.Text = barkod.StokNo;
                LblTanim.Text = barkod.Tanim;
                LblBirim.Text = malzeme.Birim;
                LblSeriLotNo.Text = barkod.SeriNo;
                LblRevizyon.Text = barkod.Revizyon;
                takipdurumu = malzeme.TakipDurumu;
                teminTuru = malzeme.TedarikTuru;
            }
            if (CmbIslemTuru.Text == "101-DEPODAN DEPOYA İADE" || CmbIslemTuru.Text == "102-DEPODAN BİLDİRİME ÇEKİM")
            {
                depoBilgileri = depoMiktarManager.GetBarkodLokasyonBul(CmbStokNo.Text, LblSeriLotNo.Text, LblRevizyon.Text, takipdurumu);
                if (depoBilgileri == null)
                {
                    List<StokGirisCıkıs> stokGirisCıkıs = new List<StokGirisCıkıs>();
                    stokGirisCıkıs = stokGirisCikisManager.GetList(CmbStokNo.Text, LblSeriLotNo.Text);
                    if (stokGirisCıkıs.Count==0)
                    {
                        TmrBarcode.Stop();
                        MessageBox.Show("Bu malzemenin lokasyonu bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TxtBarkod.Clear();
                        return;
                    }
                    string sonDusulneDepo = stokGirisCıkıs[stokGirisCıkıs.Count - 1].DusulenDepoNo;
                    if (sonDusulneDepo=="")
                    {
                        TmrBarcode.Stop();
                        MessageBox.Show("Bu malzemenin lokasyonu bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TxtBarkod.Clear();
                        return;
                    }
                    if (sonDusulneDepo.Length<5)
                    {
                        DepoMiktar depoMiktar = new DepoMiktar(stokGirisCıkıs[stokGirisCıkıs.Count - 1].Stokno, stokGirisCıkıs[stokGirisCıkıs.Count - 1].Tanim, stokGirisCıkıs[stokGirisCıkıs.Count - 1].Serino, stokGirisCıkıs[stokGirisCıkıs.Count - 1].Lotno, stokGirisCıkıs[stokGirisCıkıs.Count - 1].Revizyon, stokGirisCıkıs[stokGirisCıkıs.Count - 1].IslemTarihi, infos[1].ToString(), stokGirisCıkıs[stokGirisCıkıs.Count - 1].DusulenDepoNo, stokGirisCıkıs[stokGirisCıkıs.Count - 1].DusulenDepoAdresi, stokGirisCıkıs[stokGirisCıkıs.Count - 1].DusulenMalzemeYeri, stokGirisCıkıs[stokGirisCıkıs.Count - 1].DusulenMiktar, stokGirisCıkıs[stokGirisCıkıs.Count - 1].Aciklama);

                        depoMiktarManager.Add(depoMiktar);

                        depoBilgileri = depoMiktarManager.GetBarkodLokasyonBul(CmbStokNo.Text, LblSeriLotNo.Text, LblRevizyon.Text, takipdurumu);
                        if (depoBilgileri==null)
                        {
                            DepoMiktar depoMiktar1 = depoMiktarManager.Get(stokGirisCıkıs[stokGirisCıkıs.Count - 1].Stokno, stokGirisCıkıs[stokGirisCıkıs.Count - 1].DusulenDepoNo, stokGirisCıkıs[stokGirisCıkıs.Count - 1].Serino, stokGirisCıkıs[stokGirisCıkıs.Count - 1].Lotno, stokGirisCıkıs[stokGirisCıkıs.Count - 1].Revizyon);

                            if (depoMiktar1!=null)
                            {
                                depoMiktarManager.Delete(depoMiktar1.Id);
                            }

                            TmrBarcode.Stop();
                            MessageBox.Show("Bu malzemenin barkod bilgileri hatalıdır!\nBarkodu değiştirdikten sonra tekrar okutunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            TxtBarkod.Clear();
                            return;
                        }
                    }
                    else
                    {
                        TmrBarcode.Stop();
                        MessageBox.Show("Bu malzemenin lokasyonu bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TxtBarkod.Clear();
                        return;
                    }
                }
            }

            string miktarKontrol = MiktarKontrol();

            if (miktarKontrol != "OK")
            {
                TmrBarcode.Stop();
                MessageBox.Show(miktarKontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtBarkod.Clear();
                return;
            }
            if (CmbStokNo.Text=="")
            {
                TmrBarcode.Stop();
                MessageBox.Show("Bu malzeme için yeniden barkod oluşturmanız gerekmektedir!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtBarkod.Clear();
                return;
            }
            string mesaj = "OK";
            if (CmbStokNo.Text != "00")
            {
                //sirano++;
                DtgList.Rows.Add();
                int sonSatir = DtgList.RowCount - 1;

                //DtgList.Rows[sonSatir].Cells["Column1"].Value = sirano;
                DtgList.Rows[sonSatir].Cells["Column13"].Value = CmbIslemTuru.Text;
                DtgList.Rows[sonSatir].Cells["Column2"].Value = CmbStokNo.Text;
                DtgList.Rows[sonSatir].Cells["Column3"].Value = LblTanim.Text;

                DtgList.Rows[sonSatir].Cells["TeminTuru"].Value = teminTuru;

                if (takipdurumu == "LOT NO")
                {
                    DtgList.Rows[sonSatir].Cells["Column4"].Value = TxtMiktar.Text;
                }
                else
                {
                    DtgList.Rows[sonSatir].Cells["Column4"].Value = 1;
                    mesaj = "Malzeme Seri Numaralıdır!";
                }
                DtgList.Rows[sonSatir].Cells["Column5"].Value = LblBirim.Text;
                DtgList.Rows[sonSatir].Cells["Column6"].Value = DtTarih.Value;
                DtgList.Rows[sonSatir].Cells["Column14"].Value = TxtAciklama.Text;

                if (CmbIslemTuru.Text == "100-YENİ DEPO GİRİŞİ")
                {
                    DtgList.Rows[sonSatir].Cells["Column18"].Value = id.ToString();
                    DtgList.Rows[sonSatir].Cells["Column15"].Value = CmbDepoNo.Text.ToUpper(); // DÜŞÜLEN DEPO
                    DtgList.Rows[sonSatir].Cells["Column16"].Value = CmbAdres.Text.ToUpper();
                    DtgList.Rows[sonSatir].Cells["Column17"].Value = TxtMalzemeYeri.Text;
                    DtgList.Rows[sonSatir].Cells["Column7"].Value = ""; // ÇEKİLEN DEPO
                    DtgList.Rows[sonSatir].Cells["Column8"].Value = "";
                    DtgList.Rows[sonSatir].Cells["Column9"].Value = "";
                    //DtgList.Rows[sonSatir].Cells["Column18"].Value = ""; // ABF FORM NO
                    DtgList.Rows[sonSatir].Cells["Column19"].Value = ""; // TALEP EDEN PERSONEL
                    DtgList.Rows[sonSatir].Cells["Column1"].Value = TxtBirimFiyat.Text; // MALZEME BİRİM FİYATI
                }

                if (CmbIslemTuru.Text == "101-DEPODAN DEPOYA İADE")
                {
                    DtgList.Rows[sonSatir].Cells["Column18"].Value = id.ToString();
                    DtgList.Rows[sonSatir].Cells["Column15"].Value = CmbDepoNoDusulen.Text.ToUpper(); // DÜŞÜLEN DEPO
                    DtgList.Rows[sonSatir].Cells["Column16"].Value = TxtDepoAdresiDusulen.Text.ToUpper();
                    DtgList.Rows[sonSatir].Cells["Column17"].Value = CmbMalzemeYeriDusulen.Text.ToUpper();
                    DtgList.Rows[sonSatir].Cells["Column7"].Value = depoBilgileri.DepoNo; // ÇEKİLEN DEPO
                    DtgList.Rows[sonSatir].Cells["Column8"].Value = depoBilgileri.DepoAdresi;
                    DtgList.Rows[sonSatir].Cells["Column9"].Value = depoBilgileri.DepoLokasyon;
                    //DtgList.Rows[sonSatir].Cells["Column18"].Value = ""; // ABF FORM NO
                    DtgList.Rows[sonSatir].Cells["Column19"].Value = ""; // TALEP EDEN PERSONEL
                }

                if (CmbIslemTuru.Text == "102-DEPODAN BİLDİRİME ÇEKİM")
                {
                    DtgList.Rows[sonSatir].Cells["Column18"].Value = id.ToString();
                    DtgList.Rows[sonSatir].Cells["Column15"].Value = TxtDepodanBildirimeAbfNo.Text; ; // DÜŞÜLEN DEPO
                    DtgList.Rows[sonSatir].Cells["Column16"].Value = "";
                    DtgList.Rows[sonSatir].Cells["Column17"].Value = "";
                    DtgList.Rows[sonSatir].Cells["Column7"].Value = depoBilgileri.DepoNo; // ÇEKİLEN DEPO
                    DtgList.Rows[sonSatir].Cells["Column8"].Value = depoBilgileri.DepoAdresi;
                    DtgList.Rows[sonSatir].Cells["Column9"].Value = depoBilgileri.DepoLokasyon;
                    //DtgList.Rows[sonSatir].Cells["Column18"].Value =  // ABF FORM NO
                    DtgList.Rows[sonSatir].Cells["Column19"].Value = LblDepodanBildirimePersonel.Text; // TALEP EDEN PERSONEL
                }

                if (CmbIslemTuru.Text == "201-BİLDİRİMDEN DEPOYA İADE")
                {
                    DtgList.Rows[sonSatir].Cells["Column18"].Value = id.ToString();
                    DtgList.Rows[sonSatir].Cells["Column15"].Value = CmbBildirimdenDepoyaDepoNo.Text.ToUpper(); // DÜŞÜLEN DEPO
                    DtgList.Rows[sonSatir].Cells["Column16"].Value = TxtBildirimdenDepoyaDepoAdres.Text.ToUpper();
                    DtgList.Rows[sonSatir].Cells["Column17"].Value = CmbBildirimdenDepoyaMalzemeYeri.Text.ToUpper();
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
                    DtgList.Rows[sonSatir].Cells["Column12"].Value = LblSeriLotNo.Text;
                }
                else
                {
                    DtgList.Columns["Column12"].Visible = false;
                    DtgList.Rows[sonSatir].Cells["Column12"].Value = "N/A";
                    DtgList.Columns["Column10"].Visible = true;
                    DtgList.Rows[sonSatir].Cells["Column10"].Value = LblSeriLotNo.Text;
                }
                DtgList.Rows[sonSatir].Cells["Column11"].Value = LblRevizyon.Text;
                contextMenuStrip1.Items[0].Enabled = true;
                Temizle();
            }
            Hesapla();

            TxtBarkod.Clear();
            TmrBarcode.Stop();

            //if (TxtMiktar.Text=="1" && mesaj!="OK")
            //{
            //    MessageBox.Show(mesaj, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}
            TxtMiktar.Text = "1";
        }




        private void BtnMalzemeYeri_Click(object sender, EventArgs e)
        {
            FrmDepoLokasyonKayit frmDepoLokasyonKayit = new FrmDepoLokasyonKayit();
            frmDepoLokasyonKayit.ShowDialog();
        }

        private void BtnDepoEkle_Click(object sender, EventArgs e)
        {
            FrmDepoLokasyonKayit frmDepoLokasyonKayit = new FrmDepoLokasyonKayit();
            frmDepoLokasyonKayit.ShowDialog();
        }

        private void TxtDepodanBildirimeAbfNo_TextChanged(object sender, EventArgs e)
        {
            int idAtolye = 0;
            if (TxtDepodanBildirimeAbfNo.Text.Length < 6)
            {
                return;
            }
            //AbfFormNo abfFormNo = abfFormNoManager.PersonelSicil(TxtDepodanBildirimeAbfNo.Text);
            ArizaKayit arizaKayit = arizaKayitManager.Get(TxtDepodanBildirimeAbfNo.Text.ConInt());
            if (arizaKayit == null)
            {
                Atolye atolyeDTS = atolyeManager.ArizaGetirDTS(TxtDepodanBildirimeAbfNo.Text.ConInt());
                Atolye atolye = null;
                if (atolyeDTS != null)
                {
                    idAtolye = atolyeDTS.Id;
                }
                else
                {
                    atolye = atolyeManager.ArizaGetir(TxtDepodanBildirimeAbfNo.Text.ConInt());
                    if (atolye == null)
                    {
                        LblDepodanBildirimePersonel.Text = "00";
                        return;
                    }
                    idAtolye = atolye.Id;
                }
                
                if (gorevAtamaPersonels != null)
                {
                    gorevAtamaPersonels.Clear();
                }

                gorevAtamaPersonels = gorevAtamaPersonelManager.GetList(idAtolye, "BAKIM ONARIM ATOLYE");
                foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
                {
                    string islemAdimi = item.IslemAdimi;
                    if (islemAdimi == "600-ARIZA TESPİTİ/ELEKTRİKSEL/FONK. KONTROL (TEKNİK SERVİS)")
                    {
                        islemAdimiSorumlusu = item.GorevAtanacakPersonel;
                    }
                }
                LblDepodanBildirimePersonel.Text = islemAdimiSorumlusu;

                if (LblDepodanBildirimePersonel.Text=="" && atolye!=null)
                {
                    LblDepodanBildirimePersonel.Text = "OTS ARIZASI";
                }
                return;
            }

            LblDepodanBildirimePersonel.Text = arizaKayit.ABAlanPersonel;
        }

        private void TxtBildirimdenDepoyaFormNo_TextChanged(object sender, EventArgs e)
        {
            int idAtolye = 0;
            if (TxtBildirimdenDepoyaFormNo.Text.Length < 6)
            {
                return;
            }

            //AbfFormNo abfFormNo = abfFormNoManager.PersonelSicil(TxtBildirimdenDepoyaFormNo.Text);
            ArizaKayit arizaKayit = arizaKayitManager.Get(TxtBildirimdenDepoyaFormNo.Text.ConInt());
            if (arizaKayit == null)
            {
                Atolye atolyeDTS = atolyeManager.ArizaGetirDTS(TxtBildirimdenDepoyaFormNo.Text.ConInt());
                if (atolyeDTS!=null)
                {
                    idAtolye = atolyeDTS.Id;
                }
                else
                {
                    Atolye atolye = atolyeManager.ArizaGetir(TxtBildirimdenDepoyaFormNo.Text.ConInt());
                    if (atolye == null)
                    {
                        LblBildirimdenDepoyaPersonel.Text = "00";
                        return;
                    }
                    idAtolye = atolye.Id;
                }
                
                if (gorevAtamaPersonels != null)
                {
                    gorevAtamaPersonels.Clear();
                }
                gorevAtamaPersonels = gorevAtamaPersonelManager.GetList(idAtolye, "BAKIM ONARIM ATOLYE");
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
            LblBildirimdenDepoyaPersonel.Text = arizaKayit.ABAlanPersonel;
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = -1;

            index = DtgList.CurrentRow.Index;
            if (index == -1)
            {
                MessageBox.Show("Lütfen öncelikle silmek istedğiniz kaydı seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgList.Rows.RemoveAt(index);

        }


        void MalzemeHazirlamaControl()
        {
            foreach (DataGridViewRow item in DtgList.Rows)
            {
                string islemTuru = item.Cells["Column13"].Value.ToString();
                string dusulenYer = item.Cells["Column15"].Value.ToString();
                string stokNoDusum = item.Cells["Column2"].Value.ToString();
                string cekilenDepo = item.Cells["Column7"].Value.ToString();
                string seri = item.Cells["Column10"].Value.ToString();
                string lot = item.Cells["Column12"].Value.ToString();
                string rev = item.Cells["Column11"].Value.ToString();

                if (islemTuru == "101-DEPODAN DEPOYA İADE")
                {
                    DepoMiktar depoMiktar = depoMiktarManager.StokSeriLotKontrol(stokNoDusum, cekilenDepo, seri, lot, rev);

                    if (depoMiktar != null)
                    {
                        abfMalzemeManager.TeminBilgisi(depoMiktar.Id, dusulenYer + " DEPOYA GÖNDERİLDİ", infos[1].ToString(), "DEPODAN DEPOYA İADE (AMBAR)");
                    }
                }

                if (islemTuru == "102-DEPODAN BİLDİRİME ÇEKİM")
                {
                    int abf = dusulenYer.ConInt();
                    ArizaKayit arizaKayit = arizaKayitManager.Get(abf);
                    if (arizaKayit==null)
                    {
                        return;
                    }
                    abfMalzemes = abfMalzemeManager.GetList(arizaKayit.Id);
                    

                    foreach (AbfMalzeme item2 in abfMalzemes)
                    {
                        if (stokNoDusum == item2.SokulenStokNo)
                        {
                            if (item2.TeminDurumu == "REZERVE EDİLDİ")
                            {
                                abfMalzemeManager.TeminBilgisi(item2.Id, "ARIZAYA GÖNDERİLDİ", infos[1].ToString(), "DEPODAN DEPOYA İADE (AMBAR)");
                            }
                        }
                    }

                }
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
            //StokGirisCıkıs stokGirisCıkıs = stokGirisCikisManager.BildirimdenDepoya(stokNo, seriNo, lotNo, revizyon, dusulenDepoAbf);
            //if (stokGirisCıkıs == null)
            //{
            //    return stokNo + " Nolu Stok Numarası " + dusulenDepoAbf + " Bildirim Numarasına Daha Önce Düşülmemiştir!\nLütfen Düşmek İstediğiniz Malzemenin Bildirim Numarasını Tekrar Kontrol Ediniz.";
            //}
            return "OK";
        }

        void DepoGirisBekleyenKontrol()
        {
            foreach (DataGridViewRow item in DtgList.Rows)
            {
                string stokNoDusum = item.Cells["Column2"].Value.ToString();
                string tedarikTuru = item.Cells["TeminTuru"].Value.ToString();

                abfMalzemes = abfMalzemeManager.GetListStok(stokNoDusum);

                foreach (AbfMalzeme item2 in abfMalzemes)
                {
                    if (stokNoDusum == item2.SokulenStokNo)
                    {
                        if (item2.TeminDurumu != "REZERVE EDİLDİ")
                        {
                            if (teminTuru== "SATIN ALMA")
                            {
                                abfMalzemeManager.TeminBilgisi(item2.Id, "STOKTA MEVCUT (SAT)", infos[1].ToString(), item2.MalzemeIslemAdimi);
                            }
                            else
                            {
                                abfMalzemeManager.TeminBilgisi(item2.Id, "STOKTA MEVCUT (ASELSAN)", infos[1].ToString(), item2.MalzemeIslemAdimi);
                            }
                            
                        }
                    }
                }
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            
        }

        string BildirimKayit()
        {
            string[] array = new string[8];

            array[0] = "Depo Stok Giriş/Çıkış"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = "adlı personel tarafından"; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "depo ya Stok Giriş/Çıkış"; // Bildirim türü
            array[4] = "işlemleri gerçekleşmiştir."; // İÇERİK
            array[5] = "";
            array[6] = "";

            BildirimYetki bildirimYetki = bildirimYetkiManager.Get(infos[1].ToString());
            if (bildirimYetki == null)
            {
                array[7] = infos[0].ToString();
            }
            else
            {
                array[7] = bildirimYetki.SorumluId + infos[0].ToString();
            }

            string mesaj = FrmHelper.BildirimGonder(array, array[7]);
            return mesaj;
        }


        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtBarkod.Text != "")
            {
                string kontrol = Control();
                if (kontrol != "OK")
                {
                    MessageBox.Show(kontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                readedBarcode = TxtBarkod.Text;
                string[] array = TxtBarkod.Text.Split(' ');
                string[] array2 = readedBarcode.Split('*');


                string stok = array2[0].ToString();
                if (stok != "")
                {
                    for (int j = 1; j < array2.Length; j++)
                    {

                        stok = stok + "-" + array2[j].ToString();
                        if (array2.Count() == 3 && j == 1)
                        {
                            continue;
                        }
                        string[] array3 = array[2].Split();
                        if (array3[0].ToString() == "_".ToString())
                        {
                            string[] array4 = stok.Split(' ');
                            stok = array4[0].ToString() + " " + array4[1].ToString() + " " + "+";
                            st = array4[0].ToString();
                            //10006269-5 123 _"
                            //TxtBarkod.Text = stok + "-" + array3[0].ToString();
                        }
                        TxtBarkod.Text = stok;
                    }
                }


                Malzeme malzeme = malzemeManager.MalzemeBul(st);
                if (malzeme == null)
                {
                    CmbStokNo.Text = "";
                    LblTanim.Text = "";
                    LblBirim.Text = "";
                    LblRevizyon.Text = "";
                    LblSeriLotNo.Text = "";
                }
                else
                {
                    CmbStokNo.Text = malzeme.StokNo;
                    LblTanim.Text = malzeme.Tanim;
                    LblBirim.Text = malzeme.Birim;
                    LblSeriLotNo.Text = array[1].ToString();
                    if (array.Count() == 2)
                    {
                        if (array[1].ToString() == '_'.ToString())
                        {
                            LblRevizyon.Text = "+";
                        }
                        else
                        {
                            LblRevizyon.Text = array[1].ToString();
                        }
                        takipdurumu = malzeme.TakipDurumu;
                    }
                    else
                    {
                        if (array[2].ToString() == '_'.ToString())
                        {
                            LblRevizyon.Text = "+";
                        }
                        else
                        {
                            LblRevizyon.Text = array[2].ToString();
                        }
                        takipdurumu = malzeme.TakipDurumu;
                    }

                }

                if (CmbStokNo.Text != "00")
                {
                    //sirano++;
                    DtgList.Rows.Add();
                    int sonSatir = DtgList.RowCount - 1;

                    //DtgList.Rows[sonSatir].Cells["Column1"].Value = sirano;
                    DtgList.Rows[sonSatir].Cells["Column13"].Value = CmbIslemTuru.Text;
                    DtgList.Rows[sonSatir].Cells["Column2"].Value = CmbStokNo.Text;
                    DtgList.Rows[sonSatir].Cells["Column3"].Value = LblTanim.Text;
                    if (takipdurumu == "LOT NO")
                    {
                        DtgList.Rows[sonSatir].Cells["Column4"].Value = TxtMiktar.Text;
                    }
                    else
                    {
                        DtgList.Rows[sonSatir].Cells["Column4"].Value = 1;
                    }
                    DtgList.Rows[sonSatir].Cells["Column5"].Value = LblBirim.Text;
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
                        DtgList.Rows[sonSatir].Cells["Column1"].Value = TxtBirimFiyat.Text; // MALZEME BİRİM FİYATI
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
                        DtgList.Rows[sonSatir].Cells["Column12"].Value = LblSeriLotNo.Text;
                    }
                    else
                    {
                        DtgList.Columns["Column12"].Visible = false;
                        DtgList.Rows[sonSatir].Cells["Column12"].Value = "N/A";
                        DtgList.Columns["Column10"].Visible = true;
                        DtgList.Rows[sonSatir].Cells["Column10"].Value = LblSeriLotNo.Text;
                    }
                    DtgList.Rows[sonSatir].Cells["Column11"].Value = LblRevizyon.Text;

                    Temizle();
                }

            }
        }

        private void BtnStokDuzelt_Click(object sender, EventArgs e)
        {
            malzemeKayits = malzemeKayitManager.GetList();
            foreach (MalzemeKayit item in malzemeKayits)
            {
                string stok = item.Stokno;
                int id = item.Id;
                string stokUp = "";
                string[] array = stok.Split(' ');

                for (int i = 0; i < array.Length; i++)
                {
                    if (stokUp == "")
                    {
                        stokUp = array[i].ToString();
                    }
                    else
                    {
                        stokUp = stokUp + "-" + array[i].ToString();
                    }

                }
                malzemeKayitManager.StokDuzelt(stokUp, id);
            }
        }
    }
}
