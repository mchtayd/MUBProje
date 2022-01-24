using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
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

        List<AtolyeMalzeme> atolyeMalzemes;
        public FrmBOAtolyeGuncelleme()
        {
            InitializeComponent();
            adimlariManager = IslemAdimlariManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            atolyeManager = AtolyeManager.GetInstance();
            atolyeMalzemeManager = AtolyeMalzemeManager.GetInstance();
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
        List<Atolye> atolyes;
        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtIcSiparisNo.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle İç Sipariş No Bilgisini Giriniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            atolyes = atolyeManager.AtolyeIcSiparis(TxtIcSiparisNo.Text);

            foreach (Atolye item in atolyes)
            {
                siparisNo = item.SiparisNo.ToString();
            }


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
            DtgAtolye.Columns["SiparisNo"].Visible = false;


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

            
            //FillTools();
        }
        void Temizle()
        {
            Stok1.Clear(); t1.Clear(); SokulenSeri1.Clear(); TakilanSeri1.Clear(); m1.Clear(); b1.Text = ""; Sayac1.Clear(); Revizyon1.Clear(); YapilacakIslemler1.SelectedIndex = -1;

            Stok2.Clear(); t2.Clear(); SokulenSeri2.Clear(); TakilanSeri2.Clear(); m2.Clear(); b2.Text = ""; Sayac2.Clear(); Revizyon2.Clear(); YapilacakIslemler2.SelectedIndex = -1;

            Stok3.Clear(); t3.Clear(); SokulenSeri3.Clear(); TakilanSeri3.Clear(); m3.Clear(); b3.Text = ""; Sayac3.Clear(); Revizyon3.Clear(); YapilacakIslemler3.SelectedIndex = -1;

            Stok2.Clear(); t4.Clear(); SokulenSeri4.Clear(); TakilanSeri4.Clear(); m4.Clear(); b4.Text = ""; Sayac4.Clear(); Revizyon4.Clear(); YapilacakIslemler4.SelectedIndex = -1;

            Stok5.Clear(); t5.Clear(); SokulenSeri5.Clear(); TakilanSeri5.Clear(); m5.Clear(); b5.Text = ""; Sayac5.Clear(); Revizyon5.Clear(); YapilacakIslemler5.SelectedIndex = -1;

            Stok5.Clear(); t6.Clear(); SokulenSeri6.Clear(); TakilanSeri6.Clear(); m6.Clear(); b6.Text = ""; Sayac6.Clear(); Revizyon6.Clear(); YapilacakIslemler6.SelectedIndex = -1;

            Stok7.Clear(); t7.Clear(); SokulenSeri7.Clear(); TakilanSeri7.Clear(); m7.Clear(); b7.Text = ""; Sayac7.Clear(); Revizyon7.Clear(); YapilacakIslemler7.SelectedIndex = -1;

            Stok8.Clear(); t8.Clear(); SokulenSeri8.Clear(); TakilanSeri8.Clear(); m8.Clear(); b8.Text = ""; Sayac8.Clear(); Revizyon8.Clear(); YapilacakIslemler8.SelectedIndex = -1;
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
                Revizyon1.Text = item.Revizyon;
            }

            if (atolyeMalzemes.Count > 1)
            {
                AtolyeMalzeme item = atolyeMalzemes[1];
                Stok2.Text = item.StokNo;
                t2.Text = item.Tanim;
                SokulenSeri2.Text = item.SeriNo.ToString();
                m2.Text = item.Miktar.ToString();
                Revizyon2.Text = item.Revizyon;
            }

            if (atolyeMalzemes.Count > 2)
            {
                AtolyeMalzeme item = atolyeMalzemes[2];
                Stok3.Text = item.StokNo;
                t3.Text = item.Tanim;
                SokulenSeri3.Text = item.SeriNo.ToString();
                m3.Text = item.Miktar.ToString();
                Revizyon3.Text = item.Revizyon;
            }

            if (atolyeMalzemes.Count > 3)
            {
                AtolyeMalzeme item = atolyeMalzemes[3];
                Stok4.Text = item.StokNo;
                t4.Text = item.Tanim;
                SokulenSeri4.Text = item.SeriNo.ToString();
                m4.Text = item.Miktar.ToString();
                Revizyon4.Text = item.Revizyon;
            }

            if (atolyeMalzemes.Count > 4)
            {
                AtolyeMalzeme item = atolyeMalzemes[4];
                Stok5.Text = item.StokNo;
                t5.Text = item.Tanim;
                SokulenSeri5.Text = item.SeriNo.ToString();
                m5.Text = item.Miktar.ToString();
                Revizyon5.Text = item.Revizyon;
            }

            if (atolyeMalzemes.Count > 5)
            {
                AtolyeMalzeme item = atolyeMalzemes[5];
                Stok6.Text = item.StokNo;
                t6.Text = item.Tanim;
                SokulenSeri6.Text = item.SeriNo.ToString();
                m6.Text = item.Miktar.ToString();
                Revizyon6.Text = item.Revizyon;
            }

            if (atolyeMalzemes.Count > 6)
            {
                AtolyeMalzeme item = atolyeMalzemes[6];
                Stok7.Text = item.StokNo;
                t7.Text = item.Tanim;
                SokulenSeri7.Text = item.SeriNo.ToString();
                m7.Text = item.Miktar.ToString();
                Revizyon7.Text = item.Revizyon;
            }

            if (atolyeMalzemes.Count > 7)
            {
                AtolyeMalzeme item = atolyeMalzemes[7];
                Stok8.Text = item.StokNo;
                t8.Text = item.Tanim;
                SokulenSeri8.Text = item.SeriNo.ToString();
                m8.Text = item.Miktar.ToString();
                Revizyon8.Text = item.Revizyon;
            }
        }
        string MalzemeKontrol()
        {
            if (Stok1.Text != "")
            {
                if (t1.Text=="")
                {
                    return "Lütfen 1.Malzemenin Tanim Bilgisini Doldurunuz!";
                }
                if (SokulenSeri1.Text == "")
                {
                    return "Lütfen 1.Sökülen Seri No Bilgisini Doldurunuz!";
                }
                if (YapilacakIslemler1.Text=="")
                {
                    return "Lütfen 1.Yapılacak İşlem Bilgisini Doldurunuz!";
                }
                if (YapilacakIslemler1.Text== "DEĞİTİRİLECEK (ONARILACAK)")
                {
                    if (TakilanSeri1.Text=="")
                    {
                        return "Lütfen 1.Takılan Seri No Bilgisini Doldurunuz!";
                    }
                    if (TakilanSeri1.Text == "DEĞİTİRİLECEK (HURDA EDİLECEK)")
                    {
                        return "Lütfen 1.Takılan Seri No Bilgisini Doldurunuz!";
                    }
                }
                if (m1.Text=="")
                {
                    return "Lütfen 1.Miktar Bilgisini Doldurunuz!";
                }
                if (b1.Text == "")
                {
                    return "Lütfen 1.Birim Bilgisini Doldurunuz!";
                }

            }
            return "OK";
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (CmbIslemAdimi.Text== "500-ARIZA TESPİTİ/ELEKTRİKSEL KONTROL")
            {
                if (Stok1.Text=="")
                {
                    MessageBox.Show("");
                }
            }

            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

            }
        }
    }
}
