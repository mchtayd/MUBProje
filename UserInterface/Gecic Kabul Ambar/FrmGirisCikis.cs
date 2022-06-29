﻿using Business.Concreate;
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

        List<GorevAtamaPersonel> gorevAtamaPersonels;
        //List<Malzeme> malzemes;

        List<MalzemeKayit> malzemeKayits;

        public object[] infos;
        bool start = true, miktarKontrol = false;
        string readedBarcode, st = "", takipdurumu, malzemeYeri = "", islemAdimiSorumlusu;
        int miktar, mevcutMiktar, dusulenMiktar, cekilenMiktar, id;

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
            start = false;
            contextMenuStrip1.Items[0].Enabled = false;
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
            CmbAdres.Text = depoKayit.Aciklama;

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
                if (CmbDepoNoCekilen.Text == "")
                {
                    return "Lütfen öncelikle Çekilen Depo no bilgisini doldurunuz!";
                }
                if (CmbMalzemeYeriCekilen.Text == "")
                {
                    return "Lütfen öncelikle Çekilen Malzeme Yerini seçiniz!";
                }
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
                if (CmbDepodanBildirimeDepoNo.Text == "")
                {
                    return "Lütfen öncelikle Depo No bilgisini doldurunuz!";
                }
                if (CmbDepodanBildirimeMalzemeYeri.Text == "")
                {
                    return "Lütfen öncelikle Malzeme yeri bilgisini doldurunuz! ";
                }
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
                depoNoDusulen = CmbDepoNoCekilen.Text;
                malzemeYeri = CmbMalzemeYeriCekilen.Text;
                if (CmbDepoNoCekilen.Text == "")
                {
                    return "Lütfen Öncelikle Çekilen Depo Bilgisini Seçiniz!";
                }
                if (CmbMalzemeYeriCekilen.Text == "")
                {
                    return "Lütfen Öncelikle Çekilen Depo Malzeme Yeri Bilgisini Seçiniz!";
                }
                string bilgiControl = BilgiControl();

                if (bilgiControl != "OK")
                {
                    return bilgiControl;
                }
            }
            if (CmbIslemTuru.Text == "102-DEPODAN BİLDİRİME ÇEKİM")
            {
                depoNoDusulen = CmbDepodanBildirimeDepoNo.Text;
                malzemeYeri = CmbDepodanBildirimeMalzemeYeri.Text;
                if (CmbDepodanBildirimeDepoNo.Text == "")
                {
                    return "Lütfen Öncelikle Çekilen Depo Bilgisini Seçiniz!";
                }
                if (CmbDepodanBildirimeMalzemeYeri.Text == "")
                {
                    return "Lütfen Öncelikle Çekilen Depo Malzeme Yeri Bilgisini Seçiniz!";
                }
                string bilgiControl = BilgiControl();

                if (bilgiControl != "OK")
                {
                    return bilgiControl;
                }
            }

            if (CmbIslemTuru.Text == "101-DEPODAN DEPOYA İADE")
            {
                if (takipdurumu == "LOT NO")
                {
                    string control = MiktarKontrol(CmbStokNo.Text, CmbDepoNoCekilen.Text, "N/A", LblSeriLotNo.Text, "N/A", TxtMiktar.Text.ConInt());
                    if (control != "OK")
                    {
                        return control;
                    }
                }
                string control2 = MiktarKontrol(CmbStokNo.Text, CmbDepoNoCekilen.Text, LblSeriLotNo.Text, "N/A", LblRevizyon.Text, TxtMiktar.Text.ConInt());
                if (control2 != "OK")
                {
                    return control2;
                }
            }
            if (CmbIslemTuru.Text == "102-DEPODAN BİLDİRİME ÇEKİM")
            {
                if (takipdurumu == "LOT NO")
                {
                    string control = MiktarKontrol(CmbStokNo.Text, CmbDepodanBildirimeDepoNo.Text, "N/A", LblSeriLotNo.Text, LblRevizyon.Text, TxtMiktar.Text.ConInt());
                    if (control != "OK")
                    {
                        return control;
                    }
                }
                else
                {
                    string control2 = MiktarKontrol(CmbStokNo.Text, CmbDepodanBildirimeDepoNo.Text, LblSeriLotNo.Text, "N/A", LblRevizyon.Text, TxtMiktar.Text.ConInt());
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

        private void TxtBarkod_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string kontrol = Control();
                if (kontrol != "OK")
                {
                    MessageBox.Show(kontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtBarkod.Clear();
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


                MalzemeKayit malzeme = malzemeKayitManager.MalzemeBul(st);
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
                    CmbStokNo.Text = malzeme.Stokno;
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
                        takipdurumu = malzeme.Malzemetakipdurumu;
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
                        takipdurumu = malzeme.Malzemetakipdurumu;
                    }

                }

                string miktarKontrol = MiktarKontrol();

                if (miktarKontrol!="OK")
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
                    contextMenuStrip1.Items[0].Enabled = true;
                    Temizle();
                }

            }
        }
        void Temizle()
        {
            TxtBarkod.Clear();
            TxtBirimFiyat.Clear();
            //CmbStokNo.Text = "00"; LblTanim.Text = "00"; LblBirim.Text = "00"; LblSeriLotNo.Text = "00"; LblRevizyon.Text = "00"; TxtBirimFiyat.Clear();
        }
        string islemTuru, stokNo, tanim, seriNo, lotNo, revizyon, depoNoDusulen, depoAdresi;

        private void TxtDepodanBildirimeAbfNo_TextChanged(object sender, EventArgs e)
        {
            if (TxtDepodanBildirimeAbfNo.Text.Length < 6)
            {
                return;
            }
            AbfFormNo abfFormNo = abfFormNoManager.PersonelSicil(TxtDepodanBildirimeAbfNo.Text);
            if (abfFormNo == null)
            {
                Atolye atolye = atolyeManager.Get(TxtDepodanBildirimeAbfNo.Text);
                if (atolye == null)
                {
                    LblDepodanBildirimePersonel.Text = "00";
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
                LblDepodanBildirimePersonel.Text = islemAdimiSorumlusu;
                return;
            }

            LblDepodanBildirimePersonel.Text = abfFormNo.PersonelAd;
        }

        private void TxtBildirimdenDepoyaFormNo_TextChanged(object sender, EventArgs e)
        {
            if (TxtBildirimdenDepoyaFormNo.Text.Length < 6)
            {
                return;
            }

            AbfFormNo abfFormNo = abfFormNoManager.PersonelSicil(TxtBildirimdenDepoyaFormNo.Text);

            if (abfFormNo == null)
            {
                Atolye atolye = atolyeManager.Get(TxtBildirimdenDepoyaFormNo.Text);
                if (atolye == null)
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

                        stokGirisCikisManager.DepoBirimFiyat(item.Cells["Column1"].Value.ConDouble(), stokNo);
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

                        if (cekilenMiktar == 0)
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

                        DepoMiktar depoDusulen = new DepoMiktar(stokNo, depoNoDusulen2, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), mevcutMiktar);
                        depoMiktarManager.Update(depoDusulen);


                        StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs(islemTuru, stokNo, tanim, item.Cells["Column5"].Value.ToString(), item.Cells["Column6"].Value.ConDate(), item.Cells["Column7"].Value.ToString(), "", "", item.Cells["Column15"].Value.ToString(), item.Cells["Column16"].Value.ToString(), item.Cells["Column17"].Value.ToString(), miktar, item.Cells["Column19"].Value.ToString(), item.Cells["Column14"].Value.ToString(), item.Cells["Column10"].Value.ToString(), item.Cells["Column12"].Value.ToString(), item.Cells["Column11"].Value.ToString());

                        stokGirisCikisManager.Add(stokGirisCıkıs);

                    }
                }
                MessageBox.Show("Bilgileri Başarıyla Kaydedişmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                start = true;
                Temizle();
                DtgList.Rows.Clear();
                start = false;
            }
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


                MalzemeKayit malzeme = malzemeKayitManager.MalzemeBul(st);
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
                    CmbStokNo.Text = malzeme.Stokno;
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
                        takipdurumu = malzeme.Malzemetakipdurumu;
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
                        takipdurumu = malzeme.Malzemetakipdurumu;
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