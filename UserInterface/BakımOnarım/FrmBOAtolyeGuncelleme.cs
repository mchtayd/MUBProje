﻿using Business.Concreate;
using Business.Concreate.AnaSayfa;
using Business.Concreate.BakimOnarim;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity;
using Entity.AnaSayfa;
using Entity.BakimOnarim;
using Entity.BakimOnarimAtolye;
using Entity.Gecic_Kabul_Ambar;
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
using UserInterface.Ana_Sayfa;
using UserInterface.STS;

namespace UserInterface.BakımOnarım
{
    public partial class FrmBOAtolyeGuncelleme : Form
    {
        IslemAdimlariManager adimlariManager;
        PersonelKayitManager kayitManager;
        AtolyeManager atolyeManager;
        AtolyeMalzemeManager atolyeMalzemeManager;
        AtolyeAltMalzemeManager atolyeAltMalzemeManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        BildirimYetkiManager bildirimYetkiManager;
        AbfMalzemeIslemKayitManager abfMalzemeIslemKayitManager;
        AbfMalzemeManager abfMalzemeManager;
        StokGirisCikisManager stokGirisCikisManager;
        string icSiparis, abfNo;
        int id, kayitId;

        List<AtolyeMalzeme> atolyeMalzemes;
        List<AtolyeAltMalzeme> atolyeAltMalzemes;
        List<GorevAtamaPersonel> gorevAtamaPersonels;
        List<StokGirisCıkıs> stokGirisCikis;

        List<Atolye> atolyes;

        public object[] infos;
        string bulunduguIslemAdimi, sure, dosyaYolu;
        public string personelAd = "";
        DateTime birOncekiTarih;
        int gun, saat, dakika;
        public FrmBOAtolyeGuncelleme()
        {
            InitializeComponent();
            adimlariManager = IslemAdimlariManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            atolyeManager = AtolyeManager.GetInstance();
            atolyeMalzemeManager = AtolyeMalzemeManager.GetInstance();
            atolyeAltMalzemeManager = AtolyeAltMalzemeManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
            abfMalzemeIslemKayitManager = AbfMalzemeIslemKayitManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
        }

        private void FrmBOAtolyeGuncelleme_Load(object sender, EventArgs e)
        {
            IslemAdimlari();
            Personeller();
            
            CmbGorevAtanacakPersonel.Text = personelAd;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageArizaAcmaAtolyeGuncelle"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        public void IslemAdimlari()
        {
            CmbIslemAdimi.DataSource = adimlariManager.GetList("BAKIM ONARIM ATOLYE");
            CmbIslemAdimi.ValueMember = "Id";
            CmbIslemAdimi.DisplayMember = "IslemaAdimi";
            CmbIslemAdimi.SelectedValue = "";
        }
        public void Personeller()
        {
            List<PersonelKayit> personelKayits = new List<PersonelKayit>();
            List<PersonelKayit> personelKayits2 = new List<PersonelKayit>();
            personelKayits = kayitManager.PersonelBolumBazli("MUB Prj.Dir./Atölye");
            personelKayits2 = kayitManager.PersonelBolumBazli("MUB Prj.Dir./MGEO Van BO");
            foreach (PersonelKayit item in personelKayits2)
            {
                personelKayits.Add(item);
            }
            CmbGorevAtanacakPersonel.DataSource = personelKayits;
            CmbGorevAtanacakPersonel.ValueMember = "Id";
            CmbGorevAtanacakPersonel.DisplayMember = "Adsoyad";
            CmbGorevAtanacakPersonel.SelectedValue = -1;
        }

        void SureBul()
        {
            if (gun == 0)
            {
                if (saat == 0)
                {
                    if (dakika != 0)
                    {
                        sure = dakika.ToString() + " Dakika";
                        return;
                    }
                    sure = "0" + " Dakika";
                    return;
                }
                sure = saat.ToString() + " Saat " + dakika.ToString() + " Dakika";
                return;
            }
            sure = gun.ToString() + " Gün " + saat.ToString() + " Saat " + dakika.ToString() + " Dakika";
            return;
        }
        string bildirilenAriza;
        private void BtnBul_Click(object sender, EventArgs e)
        {
            BulClick();
        }
        string siparisNo;
        string stokNo, seriNo, revizyon;

        public void BulClick()
        {
            if (TxtIcSiparisNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İç Sipariş No Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgAtolye.DataSource = null;
            atolyes = atolyeManager.AtolyeIcSiparis(TxtIcSiparisNo.Text.ConInt());


            foreach (Atolye item in atolyes)
            {
                siparisNo = item.SiparisNo.ToString();
            }

            Atolye atolye1 = atolyeManager.Get(siparisNo);
            if (atolye1 == null)
            {
                return;
            }
            id = atolye1.Id;
            icSiparis = TxtIcSiparisNo.Text;
            bildirilenAriza = atolye1.BildirilenAriza;
            TxtBildirilenAriza.Text = bildirilenAriza;
            bulunduguIslemAdimi = atolye1.IslemAdimi;
            kayitId = atolye1.MalzemeId;
            abfNo = atolye1.AbfNo.ToString();
            //AtolyeMalzeme atolyeMalzeme = atolyeMalzemeManager.Get(stokNo, seriNo, revizyon);
            

            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "BAKIM ONARIM ATOLYE");
            if (gorevAtamaPersonel==null)
            {
                birOncekiTarih = DateTime.Now;
            }
            else
            {
                birOncekiTarih = gorevAtamaPersonel.Tarih;
            }
            
            LblMevcutIslemAdimi.Text = bulunduguIslemAdimi;

            TimeSpan sonuc = DateTime.Now - birOncekiTarih;

            gun = sonuc.Days.ConInt();
            saat = sonuc.Hours.ConInt();
            if (sonuc.Hours < 1)
            {
                saat = 0;
            }

            dakika = sonuc.Seconds.ConInt() % 60;

            sure = gun.ToString() + " Gün " + saat.ToString() + " Saat " + dakika.ToString() + " Dakika";

            DtgAtolye.DataSource = atolyeMalzemeManager.AtolyeMalzemeBul(siparisNo);

            DtgAtolye.Columns["Id"].HeaderText = "KİMLİK";
            DtgAtolye.Columns["FormNo"].HeaderText = "FORM NO";
            DtgAtolye.Columns["StokNo"].HeaderText = "STOK NO";
            DtgAtolye.Columns["Tanim"].HeaderText = "TANIM";
            DtgAtolye.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgAtolye.Columns["Durum"].HeaderText = "DURUM";
            DtgAtolye.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgAtolye.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgAtolye.Columns["TalepTarihi"].HeaderText = "TALEP TARİHİ";
            DtgAtolye.Columns["Sec"].Visible = false;
            DtgAtolye.Columns["SiparisNo"].Visible = false;

            IslemAdimlariSureleri();
            DepoHareketleri();

            stokNo = DtgAtolye.Rows[0].Cells["StokNo"].Value.ToString();
            seriNo = DtgAtolye.Rows[0].Cells["SeriNo"].Value.ToString();
            revizyon = DtgAtolye.Rows[0].Cells["Revizyon"].Value.ToString();

        }
        void DepoHareketleri()
        {
            stokGirisCikis = stokGirisCikisManager.AtolyeDepoHareketleri(abfNo);
            DtgDepoHareketleri.DataSource = stokGirisCikis;

            DtgDepoHareketleri.Columns["Id"].Visible = false;
            DtgDepoHareketleri.Columns["Islemturu"].HeaderText = "İŞLEM TÜRÜ";
            DtgDepoHareketleri.Columns["IslemTarihi"].HeaderText = "İŞLEM TARİHİ";
            DtgDepoHareketleri.Columns["Stokno"].HeaderText = "STOK NO";
            DtgDepoHareketleri.Columns["Tanim"].HeaderText = "TANIM";
            DtgDepoHareketleri.Columns["Serino"].HeaderText = "SERİ NO";
            DtgDepoHareketleri.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgDepoHareketleri.Columns["DusulenMiktar"].HeaderText = "DÜŞÜLEN MİKTAR";
            DtgDepoHareketleri.Columns["Birim"].HeaderText = "BİRİM";
            DtgDepoHareketleri.Columns["Lotno"].HeaderText = "LOT NO";
            DtgDepoHareketleri.Columns["CekilenDepoNo"].HeaderText = "ÇEKİLEN DEPO NO/YER";
            DtgDepoHareketleri.Columns["CekilenDepoAdresi"].HeaderText = "ÇEKİLEN DEPO ADRESİ";
            DtgDepoHareketleri.Columns["CekilenMalzemeYeri"].HeaderText = "ÇEKİLEN MALZEME YERİ";
            DtgDepoHareketleri.Columns["DusulenDepoNo"].HeaderText = "DÜŞÜLEN DEPO NO/YER";
            DtgDepoHareketleri.Columns["DusulenDepoAdresi"].HeaderText = "DÜŞÜLEN DEPO ADRESİ";
            DtgDepoHareketleri.Columns["DusulenMalzemeYeri"].HeaderText = "DÜŞÜLEN MALZEME YERİ";
            DtgDepoHareketleri.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgDepoHareketleri.Columns["Aciklama"].HeaderText = "AÇIKLAMA";


            DtgDepoHareketleri.Columns["Id"].DisplayIndex = 0;
            DtgDepoHareketleri.Columns["Islemturu"].DisplayIndex = 1;
            DtgDepoHareketleri.Columns["IslemTarihi"].DisplayIndex = 2;
            DtgDepoHareketleri.Columns["Stokno"].DisplayIndex = 3;
            DtgDepoHareketleri.Columns["Tanim"].DisplayIndex = 4;
            DtgDepoHareketleri.Columns["Serino"].DisplayIndex = 5;
            DtgDepoHareketleri.Columns["Revizyon"].DisplayIndex = 6;
            DtgDepoHareketleri.Columns["DusulenMiktar"].DisplayIndex = 7;
            DtgDepoHareketleri.Columns["Birim"].DisplayIndex = 8;
            DtgDepoHareketleri.Columns["Lotno"].DisplayIndex = 9;
            DtgDepoHareketleri.Columns["CekilenDepoNo"].DisplayIndex = 10;
            DtgDepoHareketleri.Columns["CekilenDepoAdresi"].DisplayIndex = 11;
            DtgDepoHareketleri.Columns["CekilenMalzemeYeri"].DisplayIndex = 12;
            DtgDepoHareketleri.Columns["DusulenDepoNo"].DisplayIndex = 13;
            DtgDepoHareketleri.Columns["DusulenDepoAdresi"].DisplayIndex = 14;
            DtgDepoHareketleri.Columns["DusulenMalzemeYeri"].DisplayIndex = 15;
            DtgDepoHareketleri.Columns["TalepEdenPersonel"].DisplayIndex = 16;
            DtgDepoHareketleri.Columns["Aciklama"].DisplayIndex = 17;

        }

        private void DtgAtolye_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgAtolye.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }

            siparisNo = DtgAtolye.CurrentRow.Cells["SiparisNo"].Value.ToString();
            TxtBildirilenAriza.Text = bildirilenAriza;
            DataDisplayAltMalzeme();
            //FillTools();
        }
        void DataDisplayAltMalzeme()
        {
            atolyeAltMalzemes = atolyeAltMalzemeManager.GetList(siparisNo);
            dataBinder2.DataSource = atolyeAltMalzemes.ToDataTable();
            DtgMalzemeler.DataSource = dataBinder2;

            DtgMalzemeler.Columns["Id"].Visible = false;
            DtgMalzemeler.Columns["StokNo"].HeaderText = "STOK NO";
            DtgMalzemeler.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzemeler.Columns["SokulenSeriNo"].HeaderText = "SÖKÜLEN SERİ NO";
            DtgMalzemeler.Columns["TakilanSeriNo"].HeaderText = "TAKILAN SERİ NO";
            DtgMalzemeler.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzemeler.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzemeler.Columns["MalzemeyeYapilanIslem"].HeaderText = "MALZEMEYE YAPILAN İŞLEM";
            DtgMalzemeler.Columns["SiparisNo"].Visible = false;
        }
        void Temizle()
        {
            Stok1.Clear(); t1.Clear(); SokulenSeri1.Clear(); TakilanSeri1.Clear(); m1.Clear(); b1.Text = ""; YapilacakIslemler1.SelectedIndex = -1;

            Stok2.Clear(); t2.Clear(); SokulenSeri2.Clear(); TakilanSeri2.Clear(); m2.Clear(); b2.Text = ""; YapilacakIslemler2.SelectedIndex = -1;

            Stok3.Clear(); t3.Clear(); SokulenSeri3.Clear(); TakilanSeri3.Clear(); m3.Clear(); b3.Text = ""; YapilacakIslemler3.SelectedIndex = -1;

            Stok2.Clear(); t4.Clear(); SokulenSeri4.Clear(); TakilanSeri4.Clear(); m4.Clear(); b4.Text = ""; YapilacakIslemler4.SelectedIndex = -1;

            Stok5.Clear(); t5.Clear(); SokulenSeri5.Clear(); TakilanSeri5.Clear(); m5.Clear(); b5.Text = ""; YapilacakIslemler5.SelectedIndex = -1;

            Stok5.Clear(); t6.Clear(); SokulenSeri6.Clear(); TakilanSeri6.Clear(); m6.Clear(); b6.Text = ""; YapilacakIslemler6.SelectedIndex = -1;

            Stok7.Clear(); t7.Clear(); SokulenSeri7.Clear(); TakilanSeri7.Clear(); m7.Clear(); b7.Text = ""; YapilacakIslemler7.SelectedIndex = -1;

            Stok8.Clear(); t8.Clear(); SokulenSeri8.Clear(); TakilanSeri8.Clear(); m8.Clear(); b8.Text = ""; YapilacakIslemler8.SelectedIndex = -1;
        }

        private void FillTools()
        {
            atolyeMalzemes = atolyeMalzemeManager.AtolyeMalzemeBul(siparisNo);
            Temizle();

            if (atolyeMalzemes == null)

            {
                return;
            }

            if (atolyeMalzemes.Count == 0)
            {
                return;
            }

            if (atolyeMalzemes.Count > 0)
            {
                AtolyeMalzeme item = atolyeMalzemes[0];
                Stok1.Text = item.StokNo;
                t1.Text = item.Tanim;
                SokulenSeri1.Text = item.SeriNo.ToString();
                m1.Text = item.Miktar.ToString();
            }

            if (atolyeMalzemes.Count > 1)
            {
                AtolyeMalzeme item = atolyeMalzemes[1];
                Stok2.Text = item.StokNo;
                t2.Text = item.Tanim;
                SokulenSeri2.Text = item.SeriNo.ToString();
                m2.Text = item.Miktar.ToString();
            }

            if (atolyeMalzemes.Count > 2)
            {
                AtolyeMalzeme item = atolyeMalzemes[2];
                Stok3.Text = item.StokNo;
                t3.Text = item.Tanim;
                SokulenSeri3.Text = item.SeriNo.ToString();
                m3.Text = item.Miktar.ToString();
            }

            if (atolyeMalzemes.Count > 3)
            {
                AtolyeMalzeme item = atolyeMalzemes[3];
                Stok4.Text = item.StokNo;
                t4.Text = item.Tanim;
                SokulenSeri4.Text = item.SeriNo.ToString();
                m4.Text = item.Miktar.ToString();
            }

            if (atolyeMalzemes.Count > 4)
            {
                AtolyeMalzeme item = atolyeMalzemes[4];
                Stok5.Text = item.StokNo;
                t5.Text = item.Tanim;
                SokulenSeri5.Text = item.SeriNo.ToString();
                m5.Text = item.Miktar.ToString();
            }

            if (atolyeMalzemes.Count > 5)
            {
                AtolyeMalzeme item = atolyeMalzemes[5];
                Stok6.Text = item.StokNo;
                t6.Text = item.Tanim;
                SokulenSeri6.Text = item.SeriNo.ToString();
                m6.Text = item.Miktar.ToString();
            }

            if (atolyeMalzemes.Count > 6)
            {
                AtolyeMalzeme item = atolyeMalzemes[6];
                Stok7.Text = item.StokNo;
                t7.Text = item.Tanim;
                SokulenSeri7.Text = item.SeriNo.ToString();
                m7.Text = item.Miktar.ToString();
            }

            if (atolyeMalzemes.Count > 7)
            {
                AtolyeMalzeme item = atolyeMalzemes[7];
                Stok8.Text = item.StokNo;
                t8.Text = item.Tanim;
                SokulenSeri8.Text = item.SeriNo.ToString();
                m8.Text = item.Miktar.ToString();
            }
        }
        string MalzemeKontrol()
        {
            if (CmbIslemAdimi.Text == "800-MALZEME HAZIRLAMA (AMBAR)")
            {
                if (Stok1.Text == "")
                {
                    if (t1.Text == "")
                    {
                        return "Lütfen 1.Malzemenin Tanim Bilgisini Doldurunuz!";
                    }
                    if (SokulenSeri1.Text == "")
                    {
                        return "Lütfen 1.Sökülen Seri No Bilgisini Doldurunuz!";
                    }
                    if (YapilacakIslemler1.Text == "")
                    {
                        return "Lütfen 1.Yapılacak İşlem Bilgisini Doldurunuz!";
                    }
                    if (YapilacakIslemler1.Text == "DEĞİTİRİLECEK (ONARILACAK)" || YapilacakIslemler1.Text == "DEĞİTİRİLECEK (HURDA EDİLECEK)")
                    {
                        if (TakilanSeri1.Text == "")
                        {
                            return "Lütfen 1.Takılan Seri No Bilgisini Doldurunuz!";
                        }
                        if (TakilanSeri1.Text == "DEĞİTİRİLECEK (HURDA EDİLECEK)")
                        {
                            return "Lütfen 1.Takılan Seri No Bilgisini Doldurunuz!";
                        }
                    }
                    if (m1.Text == "")
                    {
                        return "Lütfen 1.Miktar Bilgisini Doldurunuz!";
                    }
                    if (b1.Text == "")
                    {
                        return "Lütfen 1.Birim Bilgisini Doldurunuz!";
                    }
                }

                /*if (Stok2.Text == "")
                {
                    if (t2.Text == "")
                    {
                        return "Lütfen 2.Malzemenin Tanim Bilgisini Doldurunuz!";
                    }
                    if (SokulenSeri2.Text == "")
                    {
                        return "Lütfen 2.Sökülen Seri No Bilgisini Doldurunuz!";
                    }
                    if (YapilacakIslemler2.Text == "")
                    {
                        return "Lütfen 2.Yapılacak İşlem Bilgisini Doldurunuz!";
                    }
                    if (YapilacakIslemler2.Text == "DEĞİTİRİLECEK (ONARILACAK)" || YapilacakIslemler2.Text == "DEĞİTİRİLECEK (HURDA EDİLECEK)")
                    {
                        if (TakilanSeri2.Text == "")
                        {
                            return "Lütfen 2.Takılan Seri No Bilgisini Doldurunuz!";
                        }
                        if (TakilanSeri2.Text == "DEĞİTİRİLECEK (HURDA EDİLECEK)")
                        {
                            return "Lütfen 2.Takılan Seri No Bilgisini Doldurunuz!";
                        }
                    }
                    if (m2.Text == "")
                    {
                        return "Lütfen 2.Miktar Bilgisini Doldurunuz!";
                    }
                    if (b2.Text == "")
                    {
                        return "Lütfen 2.Birim Bilgisini Doldurunuz!";
                    }
                }*/

                /*if (Stok3.Text == "")
                {
                    if (t3.Text == "")
                    {
                        return "Lütfen 3.Malzemenin Tanim Bilgisini Doldurunuz!";
                    }
                    if (SokulenSeri3.Text == "")
                    {
                        return "Lütfen 3.Sökülen Seri No Bilgisini Doldurunuz!";
                    }
                    if (YapilacakIslemler3.Text == "")
                    {
                        return "Lütfen 3.Yapılacak İşlem Bilgisini Doldurunuz!";
                    }
                    if (YapilacakIslemler3.Text == "DEĞİTİRİLECEK (ONARILACAK)" || YapilacakIslemler3.Text == "DEĞİTİRİLECEK (HURDA EDİLECEK)")
                    {
                        if (TakilanSeri3.Text == "")
                        {
                            return "Lütfen 3.Takılan Seri No Bilgisini Doldurunuz!";
                        }
                        if (TakilanSeri3.Text == "DEĞİTİRİLECEK (HURDA EDİLECEK)")
                        {
                            return "Lütfen 3.Takılan Seri No Bilgisini Doldurunuz!";
                        }
                    }
                    if (m3.Text == "")
                    {
                        return "Lütfen 3.Miktar Bilgisini Doldurunuz!";
                    }
                    if (b3.Text == "")
                    {
                        return "Lütfen 3.Birim Bilgisini Doldurunuz!";
                    }
                }*/

                /*if (Stok4.Text == "")
                {
                    if (t4.Text == "")
                    {
                        return "Lütfen 4.Malzemenin Tanim Bilgisini Doldurunuz!";
                    }
                    if (SokulenSeri4.Text == "")
                    {
                        return "Lütfen 4.Sökülen Seri No Bilgisini Doldurunuz!";
                    }
                    if (YapilacakIslemler4.Text == "")
                    {
                        return "Lütfen 4.Yapılacak İşlem Bilgisini Doldurunuz!";
                    }
                    if (YapilacakIslemler4.Text == "DEĞİTİRİLECEK (ONARILACAK)" || YapilacakIslemler4.Text == "DEĞİTİRİLECEK (HURDA EDİLECEK)")
                    {
                        if (TakilanSeri4.Text == "")
                        {
                            return "Lütfen 4.Takılan Seri No Bilgisini Doldurunuz!";
                        }
                        if (TakilanSeri4.Text == "DEĞİTİRİLECEK (HURDA EDİLECEK)")
                        {
                            return "Lütfen 4.Takılan Seri No Bilgisini Doldurunuz!";
                        }
                    }
                    if (m4.Text == "")
                    {
                        return "Lütfen 4.Miktar Bilgisini Doldurunuz!";
                    }
                    if (b4.Text == "")
                    {
                        return "Lütfen 4.Birim Bilgisini Doldurunuz!";
                    }
                }*/

                /*if (Stok5.Text == "")
                {
                    if (t5.Text == "")
                    {
                        return "Lütfen 5.Malzemenin Tanim Bilgisini Doldurunuz!";
                    }
                    if (SokulenSeri5.Text == "")
                    {
                        return "Lütfen 5.Sökülen Seri No Bilgisini Doldurunuz!";
                    }
                    if (YapilacakIslemler5.Text == "")
                    {
                        return "Lütfen 5.Yapılacak İşlem Bilgisini Doldurunuz!";
                    }
                    if (YapilacakIslemler5.Text == "DEĞİTİRİLECEK (ONARILACAK)" || YapilacakIslemler5.Text == "DEĞİTİRİLECEK (HURDA EDİLECEK)")
                    {
                        if (TakilanSeri5.Text == "")
                        {
                            return "Lütfen 5.Takılan Seri No Bilgisini Doldurunuz!";
                        }
                        if (TakilanSeri5.Text == "DEĞİTİRİLECEK (HURDA EDİLECEK)")
                        {
                            return "Lütfen 5.Takılan Seri No Bilgisini Doldurunuz!";
                        }
                    }
                    if (m5.Text == "")
                    {
                        return "Lütfen 5.Miktar Bilgisini Doldurunuz!";
                    }
                    if (b5.Text == "")
                    {
                        return "Lütfen 5.Birim Bilgisini Doldurunuz!";
                    }
                }*/

                /*if (Stok6.Text == "")
                {
                    if (t6.Text == "")
                    {
                        return "Lütfen 6.Malzemenin Tanim Bilgisini Doldurunuz!";
                    }
                    if (SokulenSeri6.Text == "")
                    {
                        return "Lütfen 6.Sökülen Seri No Bilgisini Doldurunuz!";
                    }
                    if (YapilacakIslemler6.Text == "")
                    {
                        return "Lütfen 6.Yapılacak İşlem Bilgisini Doldurunuz!";
                    }
                    if (YapilacakIslemler6.Text == "DEĞİTİRİLECEK (ONARILACAK)" || YapilacakIslemler6.Text == "DEĞİTİRİLECEK (HURDA EDİLECEK)")
                    {
                        if (TakilanSeri6.Text == "")
                        {
                            return "Lütfen 6.Takılan Seri No Bilgisini Doldurunuz!";
                        }
                        if (TakilanSeri6.Text == "DEĞİTİRİLECEK (HURDA EDİLECEK)")
                        {
                            return "Lütfen 6.Takılan Seri No Bilgisini Doldurunuz!";
                        }
                    }
                    if (m6.Text == "")
                    {
                        return "Lütfen 6.Miktar Bilgisini Doldurunuz!";
                    }
                    if (b6.Text == "")
                    {
                        return "Lütfen 6.Birim Bilgisini Doldurunuz!";
                    }
                }*/

                /*if (Stok7.Text == "")
                {
                    if (t7.Text == "")
                    {
                        return "Lütfen 7.Malzemenin Tanim Bilgisini Doldurunuz!";
                    }
                    if (SokulenSeri7.Text == "")
                    {
                        return "Lütfen 7.Sökülen Seri No Bilgisini Doldurunuz!";
                    }
                    if (YapilacakIslemler7.Text == "")
                    {
                        return "Lütfen 7.Yapılacak İşlem Bilgisini Doldurunuz!";
                    }
                    if (YapilacakIslemler7.Text == "DEĞİTİRİLECEK (ONARILACAK)" || YapilacakIslemler7.Text == "DEĞİTİRİLECEK (HURDA EDİLECEK)")
                    {
                        if (TakilanSeri7.Text == "")
                        {
                            return "Lütfen 7.Takılan Seri No Bilgisini Doldurunuz!";
                        }
                        if (TakilanSeri7.Text == "DEĞİTİRİLECEK (HURDA EDİLECEK)")
                        {
                            return "Lütfen 7.Takılan Seri No Bilgisini Doldurunuz!";
                        }
                    }
                    if (m7.Text == "")
                    {
                        return "Lütfen 7.Miktar Bilgisini Doldurunuz!";
                    }
                    if (b7.Text == "")
                    {
                        return "Lütfen 7.Birim Bilgisini Doldurunuz!";
                    }
                }*/

                /*if (Stok8.Text == "")
                {
                    if (t8.Text == "")
                    {
                        return "Lütfen 8.Malzemenin Tanim Bilgisini Doldurunuz!";
                    }
                    if (SokulenSeri8.Text == "")
                    {
                        return "Lütfen 8.Sökülen Seri No Bilgisini Doldurunuz!";
                    }
                    if (YapilacakIslemler8.Text == "")
                    {
                        return "Lütfen 8.Yapılacak İşlem Bilgisini Doldurunuz!";
                    }
                    if (YapilacakIslemler8.Text == "DEĞİTİRİLECEK (ONARILACAK)" || YapilacakIslemler8.Text == "DEĞİTİRİLECEK (HURDA EDİLECEK)")
                    {
                        if (TakilanSeri8.Text == "")
                        {
                            return "Lütfen 8.Takılan Seri No Bilgisini Doldurunuz!";
                        }
                        if (TakilanSeri8.Text == "DEĞİTİRİLECEK (HURDA EDİLECEK)")
                        {
                            return "Lütfen 8.Takılan Seri No Bilgisini Doldurunuz!";
                        }
                    }
                    if (m8.Text == "")
                    {
                        return "Lütfen 8.Miktar Bilgisini Doldurunuz!";
                    }
                    if (b8.Text == "")
                    {
                        return "Lütfen 8.Birim Bilgisini Doldurunuz!";
                    }
                }*/
            }

            /*if (TxtYapilanIslemler.Text == "")
            {
                return "Lütfen YAPILAN İŞLEMLER/AÇIKLAMALAR Bölümünü Doldurunuz!";
            }*/

            if (CmbIslemAdimi.Text == "")
            {
                return "Lütfen Bir Sonraki İşlem Adımını Seçiniz!";
            }

            return "OK";
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("İşlem adımını güncellemek istediğinze emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr!=DialogResult.Yes)
            {
                return;
            }

            /*if (TxtYapilanIslemler.Text=="")
            {
                MessageBox.Show("Lütfen Yapılan İşlemler ve Açıklamalar Kısmını Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            if (CmbIslemAdimi.Text == "")
            {
                MessageBox.Show("Lütfen İşlem Adımı Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DtIscilikSaati.Text == "")
            {
                MessageBox.Show("Lütfen İşçilik Süresi Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbGorevAtanacakPersonel.Text == "")
            {
                MessageBox.Show("Görev Atanacak Personel Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string mesaj = MalzemeKontrol();

            if (CmbIslemAdimi.Text == "600-MALZEME TEMİNİ (AMBAR)")
            {
                //if (LblMevcutIslemAdimi.Text == "600-ARIZA TESPİTİ/ELEKTRİKSEL/FONK. KONTROL (TEKNİK SERVİS)")
                //{
                //    MessageBox.Show("Lütfen 800-MALZEME HAZIRLAMA (AMBAR) İşlem Adımına Görev Ataması Yapmadan Önce 600-ARIZA TESPİTİ/ELEKTRİKSEL/FONK. KONTROL (TEKNİK SERVİS) adımını Uygulayınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
            }

            if (CmbIslemAdimi.Text == "1100-TESLİMAT")
            {
                AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(kayitId, "ATÖLYE BAKIM ONARIMDA", stokNo, seriNo, revizyon, "SÖKÜLEN");
                abfMalzemeManager.MalzemeTeslimBilgisiUpdate(kayitId, "ATÖLYE İŞLEMLERİ TAMAMLANDI");
                AbfMalzemeIslemKayit abfMalzemeIslemKayit2 = new AbfMalzemeIslemKayit(kayitId, "ATÖLYE İŞLEMLERİ TAMAMLANDI", DateTime.Now, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, stokNo, seriNo, revizyon);
                abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit2);

                
                if (abfMalzemeIslemKayit1 != null)
                {
                    TimeSpan gecenSure = DateTime.Now - abfMalzemeIslemKayit1.Tarih;
                    if (gecenSure.TotalMinutes.ConInt() > 0)
                    {
                        abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                    }
                    else
                    {
                        abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                    }
                }
            }

            if (mesaj == "OK")
            {
                string messege = GorevAtama();

                if (messege != "OK")
                {
                    MessageBox.Show(messege, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                atolyeManager.IslemGuncelle(siparisNo, CmbIslemAdimi.Text);
            }

            if (mesaj != "OK")
            {

                DialogResult drr = MessageBox.Show("Bu İşlem İçin Malzeme Talep Etmediniz!\nBuna Rağmen Devam Etmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (drr == DialogResult.Yes)
                {

                    string messege = GorevAtama();
                    atolyeManager.IslemGuncelle(siparisNo, CmbIslemAdimi.Text);
                    if (messege != "OK")
                    {
                        MessageBox.Show(messege, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MalzemeKaydet();

                    

                    MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TemizleGuncelle();
                }

                else
                {
                    return;
                }


            }

            string mesaj3 = Bildirim();
            if (mesaj3 != "OK")
            {
                if (mesaj3 != "Server Ayarı Kapalı")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MalzemeKaydet();
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
            }

            //string mesaj4 = Bildirim();
            //if (mesaj4 != "OK")
            //{
            //    MessageBox.Show(mesaj3, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }
        string Bildirim()
        {
            //string infusAd = infos[1].ToString();
            //string[] array = new string[8];

            //array[0] = "Atölye Sipariş Güncelleme"; // Bildirim Başlık
            //array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            //array[2] = TxtIcSiparisNo.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            //array[3] = "Sipariş numaralı"; // Bildirim türü
            //array[4] = bulunduguIslemAdimi; // İÇERİK
            //array[5] = "işlem adımını";
            //array[6] = birSonrakiIslemAdimi + " adıma güncellenmiştir!";

            //BildirimYetki bildirimYetki = bildirimYetkiManager.Get(infos[1].ToString());
            //if (bildirimYetki == null)
            //{
            //    array[7] = infos[0].ToString();
            //}
            //else
            //{
            //    array[7] = bildirimYetki.SorumluId + infos[0].ToString();
            //}

            //string mesaj = FrmHelper.BildirimGonder(array, array[7]);
            return "OK";
        }

        void TemizleGuncelle()
        {
            TxtIcSiparisNo.Clear();
            DtgAtolye.DataSource = null;
            CmbIslemAdimi.SelectedValue = "";
            TxtYapilanIslemler.Clear();
            CmbGorevAtanacakPersonel.SelectedValue = "";
            DtgMalzemeler.DataSource = null;
            LblMevcutIslemAdimi.Text = "";
            DtIscilikSaati2.Clear();
            TxtBildirilenAriza.Clear();
            DtgAtolye.Rows.Clear();

            Stok1.Clear(); t1.Clear(); SokulenSeri1.Clear(); TakilanSeri1.Clear(); m1.Clear(); b1.Text = ""; YapilacakIslemler1.SelectedIndex = -1;

            Stok2.Clear(); t2.Clear(); SokulenSeri2.Clear(); TakilanSeri2.Clear(); m2.Clear(); b2.Text = ""; YapilacakIslemler2.SelectedIndex = -1;

            Stok3.Clear(); t3.Clear(); SokulenSeri3.Clear(); TakilanSeri3.Clear(); m3.Clear(); b3.Text = ""; YapilacakIslemler3.SelectedIndex = -1;

            Stok2.Clear(); t4.Clear(); SokulenSeri4.Clear(); TakilanSeri4.Clear(); m4.Clear(); b4.Text = ""; YapilacakIslemler4.SelectedIndex = -1;

            Stok5.Clear(); t5.Clear(); SokulenSeri5.Clear(); TakilanSeri5.Clear(); m5.Clear(); b5.Text = ""; YapilacakIslemler5.SelectedIndex = -1;

            Stok5.Clear(); t6.Clear(); SokulenSeri6.Clear(); TakilanSeri6.Clear(); m6.Clear(); b6.Text = ""; YapilacakIslemler6.SelectedIndex = -1;

            Stok7.Clear(); t7.Clear(); SokulenSeri7.Clear(); TakilanSeri7.Clear(); m7.Clear(); b7.Text = ""; YapilacakIslemler7.SelectedIndex = -1;

            Stok8.Clear(); t8.Clear(); SokulenSeri8.Clear(); TakilanSeri8.Clear(); m8.Clear(); b8.Text = ""; YapilacakIslemler8.SelectedIndex = -1;
        }

        private void DtIscilikSaati_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';

        }

        void MalzemeKaydet()
        {
            List<AtolyeAltMalzeme> atolyeAltMalzemes = new List<AtolyeAltMalzeme>();

            if (Stok1.Text != "")
            {
                AtolyeAltMalzeme atolyeAltMalzeme = new AtolyeAltMalzeme(Stok1.Text, t1.Text, SokulenSeri1.Text, TakilanSeri1.Text, m1.Text.ConDouble(), b1.Text, YapilacakIslemler1.Text, siparisNo);

                atolyeAltMalzemes.Add(atolyeAltMalzeme);
            }
            if (Stok2.Text != "")
            {
                AtolyeAltMalzeme atolyeAltMalzeme = new AtolyeAltMalzeme(Stok2.Text, t2.Text, SokulenSeri2.Text, TakilanSeri2.Text, m2.Text.ConDouble(), b2.Text, YapilacakIslemler2.Text, siparisNo);

                atolyeAltMalzemes.Add(atolyeAltMalzeme);
            }
            if (Stok3.Text != "")
            {
                AtolyeAltMalzeme atolyeAltMalzeme = new AtolyeAltMalzeme(Stok3.Text, t3.Text, SokulenSeri3.Text, TakilanSeri3.Text, m3.Text.ConDouble(), b3.Text, YapilacakIslemler3.Text, siparisNo);

                atolyeAltMalzemes.Add(atolyeAltMalzeme);
            }
            if (Stok4.Text != "")
            {
                AtolyeAltMalzeme atolyeAltMalzeme = new AtolyeAltMalzeme(Stok4.Text, t4.Text, SokulenSeri4.Text, TakilanSeri4.Text, m4.Text.ConDouble(), b4.Text, YapilacakIslemler4.Text, siparisNo);

                atolyeAltMalzemes.Add(atolyeAltMalzeme);
            }
            if (Stok5.Text != "")
            {
                AtolyeAltMalzeme atolyeAltMalzeme = new AtolyeAltMalzeme(Stok5.Text, t5.Text, SokulenSeri5.Text, TakilanSeri5.Text, m5.Text.ConDouble(), b5.Text, YapilacakIslemler5.Text, siparisNo);

                atolyeAltMalzemes.Add(atolyeAltMalzeme);
            }
            if (Stok6.Text != "")
            {
                AtolyeAltMalzeme atolyeAltMalzeme = new AtolyeAltMalzeme(Stok6.Text, t6.Text, SokulenSeri6.Text, TakilanSeri6.Text, m6.Text.ConDouble(), b6.Text, YapilacakIslemler6.Text, siparisNo);

                atolyeAltMalzemes.Add(atolyeAltMalzeme);
            }
            if (Stok7.Text != "")
            {
                AtolyeAltMalzeme atolyeAltMalzeme = new AtolyeAltMalzeme(Stok7.Text, t7.Text, SokulenSeri7.Text, TakilanSeri7.Text, m7.Text.ConDouble(), b7.Text, YapilacakIslemler7.Text, siparisNo);

                atolyeAltMalzemes.Add(atolyeAltMalzeme);
            }
            if (Stok8.Text != "")
            {
                AtolyeAltMalzeme atolyeAltMalzeme = new AtolyeAltMalzeme(Stok8.Text, t8.Text, SokulenSeri8.Text, TakilanSeri8.Text, m8.Text.ConDouble(), b8.Text, YapilacakIslemler8.Text, siparisNo);

                atolyeAltMalzemes.Add(atolyeAltMalzeme);
            }

            foreach (AtolyeAltMalzeme item in atolyeAltMalzemes)
            {
                atolyeAltMalzemeManager.Add(item);
            }
        }
        string birSonrakiIslemAdimi = "";
        string GorevAtama()
        {
            //icSiparis

            //return "OK";

            Atolye atolye3 = atolyeManager.Get(siparisNo);
            if (atolye3 == null)
            {
                return "Kayıt Bulunamadı!";
            }
            id = atolye3.Id;

            GorevAtamaPersonel gorevAtamaPersonel2 = gorevAtamaPersonelManager.Get(id, "BAKIM ONARIM ATOLYE");
            bulunduguIslemAdimi = gorevAtamaPersonel2.IslemAdimi;

            int guncellenecekId = 0;
            List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetDevamEdenler(id, "BAKIM ONARIM ATOLYE");

            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                if (item.IslemAdimi == bulunduguIslemAdimi)
                {
                    guncellenecekId = item.Id;
                }
            }

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(guncellenecekId, id, "BAKIM ONARIM ATOLYE", bulunduguIslemAdimi, sure, DtIscilikSaati.Value, infos[1].ToString());
            string kontrol2 = gorevAtamaPersonelManager.Update(gorevAtama, TxtYapilanIslemler.Text);
            if (kontrol2 != "OK")
            {
                return kontrol2;
            }

            birSonrakiIslemAdimi = CmbIslemAdimi.Text;
            string gorevAtanacakPersonel = CmbGorevAtanacakPersonel.Text;
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", gorevAtanacakPersonel, birSonrakiIslemAdimi, DateTime.Now, "", DateTime.Now.Date);
            string kontrol = gorevAtamaPersonelManager.Add(gorevAtamaPersonel);

            if (kontrol != "OK")
            {
                return kontrol;
            }
            return "OK";
        }
        void IslemAdimlariSureleri()
        {
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetList(id, "BAKIM ONARIM ATOLYE");
            DtgIslemKayitlari.DataSource = gorevAtamaPersonels;

            DtgIslemKayitlari.Columns["Id"].Visible = false;
            DtgIslemKayitlari.Columns["BenzersizId"].Visible = false;
            DtgIslemKayitlari.Columns["Departman"].Visible = false;
            DtgIslemKayitlari.Columns["GorevAtanacakPersonel"].HeaderText = "GÖREV ATANACAK ERSONEL";
            DtgIslemKayitlari.Columns["IslemAdimi"].HeaderText = "İŞLEM ADIMI";
            DtgIslemKayitlari.Columns["Tarih"].HeaderText = "TARİH";
            DtgIslemKayitlari.Columns["Sure"].HeaderText = "İŞLEM ADIMI SÜRELERİ";
            DtgIslemKayitlari.Columns["YapilanIslem"].HeaderText = "YAPILAN İŞLEM";

        }
    }
}
