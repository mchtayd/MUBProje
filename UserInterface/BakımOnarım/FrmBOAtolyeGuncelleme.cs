using Business.Concreate;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarimAtolye;
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
        int id;

        List<AtolyeMalzeme> atolyeMalzemes;
        List<AtolyeAltMalzeme> atolyeAltMalzemes;
        List<GorevAtamaPersonel> gorevAtamaPersonels;

        List<Atolye> atolyes;
        string bulunduguIslemAdimi, sure, dosyaYolu;
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
        }

        private void FrmBOAtolyeGuncelleme_Load(object sender, EventArgs e)
        {
            IslemAdimlari();
            Personeller();
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
        void IslemAdimlari()
        {
            CmbIslemAdimi.DataSource = adimlariManager.GetList("BAKIM ONARIM ATOLYE");
            CmbIslemAdimi.ValueMember = "Id";
            CmbIslemAdimi.DisplayMember = "IslemaAdimi";
            CmbIslemAdimi.SelectedValue = "";
        }
        void Personeller()
        {
            CmbGorevAtanacakPersonel.DataSource = kayitManager.PersonelAdSoyad();
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
            if (TxtIcSiparisNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İç Sipariş No Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            atolyes = atolyeManager.AtolyeIcSiparis(TxtIcSiparisNo.Text);


            foreach (Atolye item in atolyes)
            {
                siparisNo = item.SiparisNo.ToString();
            }

            Atolye atolye1 = atolyeManager.Get(TxtIcSiparisNo.Text);
            if (atolye1 == null)
            {
                return;
            }
            id = atolye1.Id;
            bildirilenAriza = atolye1.BildirilenAriza;
            TxtBildirilenAriza.Text = bildirilenAriza;
            //bulunduguIslemAdimi = atolye1.IslemAdimi;

            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "BAKIM ONARIM ATOLYE");

            bulunduguIslemAdimi = gorevAtamaPersonel.IslemAdimi;
            birOncekiTarih = gorevAtamaPersonel.Tarih;
            LblMevcutIslemAdimi.Text = bulunduguIslemAdimi;

            //TimeSpan sonuc = DateTime.Now - birOncekiTarih.AddDays(1);
            TimeSpan sonuc = DateTime.Now - birOncekiTarih;
            //TimeSpan SonucSaat = DateTime.Now - birOncekiTarih;
            //TimeSpan SonucDakika = DateTime.Now - birOncekiTarih;

            gun = sonuc.Days.ConInt();
            saat = sonuc.Hours.ConInt();
            if (sonuc.Hours < 1)
            {
                saat = 0;
            }

            dakika = sonuc.Seconds.ConInt() % 60;

            sure = gun.ToString() + " Gün " + saat.ToString() + " Saat " + dakika.ToString() + " Dakika";
            /*string day = sonuc.Days == 0 ? "" : sonuc.Days + " Gün / ";
            sure = $"{day}{sonuc.Hours} Saat {sonuc.Minutes} Dakika";
            string myValue=$"{sonuc.tot
            DateTime dateTime = "19:15:00".ConOnlyTime();*/
            //SureBul();

            DtgAtolye.DataSource = atolyeMalzemeManager.AtolyeMalzemeBul(siparisNo);

            DtgAtolye.Columns["Id"].Visible = false;
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
        }
        string siparisNo;
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

            if (CmbIslemAdimi.Text == "800-MALZEME HAZIRLAMA (AMBAR)")
            {
                if (LblMevcutIslemAdimi.Text != "600-ARIZA TESPİTİ/ELEKTRİKSEL/FONK. KONTROL (TEKNİK SERVİS)")
                {
                    MessageBox.Show("Lütfen 800-MALZEME HAZIRLAMA (AMBAR) İşlem Adımına Görev Ataması Yapmadan Önce 600-ARIZA TESPİTİ/ELEKTRİKSEL/FONK. KONTROL (TEKNİK SERVİS) adımını Uygulayınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
            else
            {
                MalzemeKaydet();
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
            }

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
        string GorevAtama()
        {

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", bulunduguIslemAdimi, sure, DtIscilikSaati.Value);
            string kontrol2 = gorevAtamaPersonelManager.Update(gorevAtama, TxtYapilanIslemler.Text);
            if (kontrol2 != "OK")
            {
                return kontrol2;
            }
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", CmbGorevAtanacakPersonel.Text, CmbIslemAdimi.Text, DateTime.Now, "", DateTime.Now.Date);
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
