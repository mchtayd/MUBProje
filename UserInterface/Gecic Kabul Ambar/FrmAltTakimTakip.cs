using Business;
using Business.Concreate.BakimOnarim;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Entity;
using Entity.BakimOnarim;
using Entity.BakimOnarimAtolye;
using Entity.Gecic_Kabul_Ambar;
using Entity.IdariIsler;
using Microsoft.Office.Interop.Word;
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
using Application = System.Windows.Forms.Application;
using Color = System.Drawing.Color;

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmAltTakimTakip : Form
    {
        AbfMalzemeManager abfMalzemeManager;
        ComboManager comboManager;
        AbfMalzemeIslemKayitManager abfMalzemeIslemKayitManager;
        DepoMiktarManager depoMiktarManager;
        MalzemeManager malzemeManager;
        StokGirisCikisManager stokGirisCikisManager;
        ArizaKayitManager  arizaKayitManager;
        AtolyeMalzemeManager atolyeMalzemeManager;
        AtolyeManager atolyeManager;

        public object[] infos;
        bool start = true;
        string stokNo, tanim, seriNo, lotNo, revizyon, depoLokasyon, cekilenDepoAdi, dusulenYer, birim;
        string takipTuru, tedarikTuru = "";
        int mevcutMiktar, miktar, dusulenMiktar, cekilenMiktar;

        List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
        public FrmAltTakimTakip()
        {
            InitializeComponent();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            abfMalzemeIslemKayitManager = AbfMalzemeIslemKayitManager.GetInstance();
            depoMiktarManager = DepoMiktarManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            atolyeMalzemeManager = AtolyeMalzemeManager.GetInstance();
            atolyeManager = AtolyeManager.GetInstance();
        }

        private void FrmAltTakimTakip_Load(object sender, EventArgs e)
        {
            CmbProj();
            DataDisplay();
            DtgSaat.Value = DateTime.Now;
            start = false;
            List<string> adimlarSokulen = new List<string>();
            List<string> adimlarTakilan = new List<string>();
            List<string> adimlarList = new List<string>();
            adimlarSokulen = abfMalzemeManager.MalzemeTeslimTuru();
            adimlarTakilan = abfMalzemeManager.MalzemeTeslimTuruTakilan();
            foreach (string item in adimlarSokulen)
            {
                adimlarList.Add(item);
            }
            foreach (string item in adimlarTakilan)
            {
                adimlarList.Add(item);
            }
            CmbTeslimTuru.DataSource = adimlarList;
            CmbTeslimTuru.SelectedIndex = -1;
            BtnDisaAktar.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageTeslimTesellum"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        public void CmbProj()
        {
            CmbMalzemeIadeYeri.DataSource = comboManager.GetList("TESLIM_TURU");
            CmbMalzemeIadeYeri.ValueMember = "Id";
            CmbMalzemeIadeYeri.DisplayMember = "Baslik";
            CmbMalzemeIadeYeri.SelectedValue = -1;
        }
        public void Yenilenecekler()
        {
            start = true;
            CmbProj();
            DataDisplay();
            DtgSaat.Value = DateTime.Now;
            start = false;
            List<string> adimlarSokulen = new List<string>();
            List<string> adimlarTakilan = new List<string>();
            List<string> adimlarList = new List<string>();
            adimlarSokulen = abfMalzemeManager.MalzemeTeslimTuru();
            adimlarTakilan = abfMalzemeManager.MalzemeTeslimTuruTakilan();
            foreach (string item in adimlarSokulen)
            {
                adimlarList.Add(item);
            }
            foreach (string item in adimlarTakilan)
            {
                adimlarList.Add(item);
            }
            CmbTeslimTuru.DataSource = adimlarList;
            CmbTeslimTuru.SelectedIndex = -1;
            BtnDisaAktar.Visible = false;
        }

        void DataDisplay()
        {
            abfMalzemes = new List<AbfMalzeme>();
            dataBinder.DataSource = null;

            if (start == false)
            {
                abfMalzemes = abfMalzemeManager.DepoyaTeslimEdilecekMalzemeList(CmbTeslimTuru.Text);
            }
            else
            {
                abfMalzemes = abfMalzemeManager.DepoyaTeslimEdilecekMalzemeList("TÜMÜ");
            }
            if (CmbTeslimTuru.Text == "")
            {
                abfMalzemes = abfMalzemeManager.DepoyaTeslimEdilecekMalzemeList("TÜMÜ");
            }

            dataBinder.DataSource = abfMalzemes.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["BenzersizId"].Visible = false;
            DtgList.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            DtgList.Columns["SokulenTanim"].HeaderText = "TANIM";
            DtgList.Columns["SokulenSeriNo"].HeaderText = "SERİ NO";
            DtgList.Columns["SokulenMiktar"].HeaderText = "MİKTAR";
            DtgList.Columns["SokulenBirim"].HeaderText = "BİRİM";
            DtgList.Columns["SokulenCalismaSaati"].Visible = false;
            DtgList.Columns["SokulenRevizyon"].HeaderText = "REVİZYON";
            DtgList.Columns["CalismaDurumu"].Visible = false;
            DtgList.Columns["FizikselDurum"].Visible = false;
            DtgList.Columns["TakilanStokNo"].Visible = false;
            DtgList.Columns["TakilanTanim"].Visible = false;
            DtgList.Columns["TakilanSeriNo"].Visible = false;
            DtgList.Columns["TakilanMiktar"].Visible = false;
            DtgList.Columns["TakilanBirim"].Visible = false;
            DtgList.Columns["TakilanCalismaSaati"].Visible = false;
            DtgList.Columns["TakilanRevizyon"].Visible = false;
            DtgList.Columns["TeminDurumu"].Visible = false;
            DtgList.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgList.Columns["AbTarihSaat"].Visible = false;
            DtgList.Columns["TemineAtilamTarihi"].Visible = false;
            DtgList.Columns["MalzemeDurumu"].Visible = false;
            DtgList.Columns["MalzemeIslemAdimi"].Visible = false;
            DtgList.Columns["SokulenTeslimDurum"].HeaderText = "MALZEME TESLİM DURUMU";
            DtgList.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgList.Columns["BolgeSorumlusu"].HeaderText = "BÖLGE SORUMLUSU";
            DtgList.Columns["YapilacakIslem"].HeaderText = "YAPILACAK İŞLEM";
            DtgList.Columns["YerineMalzemeTakilma"].HeaderText = "YERİNE MALZEME TAKILDI MI?";
            DtgList.Columns["YerineMalzemeTakilma"].Visible = false;
            DtgList.Columns["DosyaYolu"].Visible = false;
            DtgList.Columns["AltYukleniciKayit"].HeaderText = "ALT YÜKLENİCİ FİRMA";

            DtgList.Columns["SokulenStokNo"].DisplayIndex = 1;
            DtgList.Columns["SokulenTanim"].DisplayIndex = 2;
            DtgList.Columns["SokulenSeriNo"].DisplayIndex = 3;
            DtgList.Columns["SokulenRevizyon"].DisplayIndex = 4;
            DtgList.Columns["SokulenMiktar"].DisplayIndex = 5;
            DtgList.Columns["SokulenBirim"].DisplayIndex = 6;
            DtgList.Columns["BolgeAdi"].DisplayIndex = 7;
            DtgList.Columns["AbfNo"].DisplayIndex = 8;
            DtgList.Columns["YapilacakIslem"].DisplayIndex = 9;
            DtgList.Columns["SokulenTeslimDurum"].DisplayIndex = 10;
            DtgList.Columns["BolgeSorumlusu"].DisplayIndex = 15;

            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }
        string tiklananStok, tiklananTanim, tiklananSeriNo, tiklananRevizyon;

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tiklananStok = DtgList.CurrentRow.Cells["SokulenStokNo"].Value.ToString();
            tiklananTanim = DtgList.CurrentRow.Cells["SokulenTanim"].Value.ToString();
            tiklananSeriNo = DtgList.CurrentRow.Cells["SokulenSeriNo"].Value.ToString();
            tiklananRevizyon = DtgList.CurrentRow.Cells["SokulenRevizyon"].Value.ToString();
            tiklananMiktar = DtgList.CurrentRow.Cells["SokulenMiktar"].Value.ConInt();
        }

        private void barkodOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tiklananStok == "")
            {
                MessageBox.Show("Lütfen bir stok seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmDepoDusum frmDepoDusum = new FrmDepoDusum();
            frmDepoDusum.stok = tiklananStok;
            frmDepoDusum.seriNo = tiklananSeriNo;
            frmDepoDusum.revizyon = tiklananRevizyon;
            frmDepoDusum.infos = infos;
            frmDepoDusum.Show();
            tiklananStok = "";
        }

        int tiklananMiktar;
        private void DtgList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tiklananStok = DtgList.CurrentRow.Cells["SokulenStokNo"].Value.ToString();
            tiklananTanim = DtgList.CurrentRow.Cells["SokulenTanim"].Value.ToString();
            tiklananSeriNo = DtgList.CurrentRow.Cells["SokulenSeriNo"].Value.ToString();
            tiklananRevizyon = DtgList.CurrentRow.Cells["SokulenRevizyon"].Value.ToString();
            tiklananMiktar = DtgList.CurrentRow.Cells["SokulenMiktar"].Value.ConInt();
            string control = Control();
            if (control != "OK")
            {
                MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgIslem.Rows.Add();
            int sonSatir = DtgIslem.RowCount - 1;

            DtgIslem.Rows[sonSatir].Cells["Id"].Value = DtgList.CurrentRow.Cells["Id"].Value.ToString();
            DtgIslem.Rows[sonSatir].Cells["StokNo"].Value = DtgList.CurrentRow.Cells["SokulenStokNo"].Value.ToString();
            DtgIslem.Rows[sonSatir].Cells["Tanim"].Value = DtgList.CurrentRow.Cells["SokulenTanim"].Value.ToString();
            DtgIslem.Rows[sonSatir].Cells["SeriNo"].Value = DtgList.CurrentRow.Cells["SokulenSeriNo"].Value.ToString();
            DtgIslem.Rows[sonSatir].Cells["Revizyon"].Value = DtgList.CurrentRow.Cells["SokulenRevizyon"].Value.ToString();
            DtgIslem.Rows[sonSatir].Cells["Miktar"].Value = DtgList.CurrentRow.Cells["SokulenMiktar"].Value.ToString();
            DtgIslem.Rows[sonSatir].Cells["Birim"].Value = DtgList.CurrentRow.Cells["SokulenBirim"].Value.ToString();
            DtgIslem.Rows[sonSatir].Cells["BolgeAdi"].Value = DtgList.CurrentRow.Cells["BolgeAdi"].Value.ToString();
            DtgIslem.Rows[sonSatir].Cells["AbfNo"].Value = DtgList.CurrentRow.Cells["AbfNo"].Value.ToString();
            DtgIslem.Rows[sonSatir].Cells["YapilacakIslem"].Value = DtgList.CurrentRow.Cells["YapilacakIslem"].Value.ToString();
            DtgIslem.Rows[sonSatir].Cells["TeslimDurum"].Value = TeslimAlmaDurum(DtgList.CurrentRow.Cells["SokulenTeslimDurum"].Value.ToString());
            DtgIslem.Rows[sonSatir].Cells["BolgeSorumlusu"].Value = DtgList.CurrentRow.Cells["BolgeSorumlusu"].Value.ToString();

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgIslem.Columns["Remove"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;

            LblTop2.Text = DtgIslem.RowCount.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ArizaKayit> arizaKayits = arizaKayitManager.GetListTumu();
            foreach (ArizaKayit arizaKayit in arizaKayits)
            {
                List<AbfMalzeme> abfMalzemes = abfMalzemeManager.GetList(arizaKayit.Id);
                foreach (AbfMalzeme abfMalzeme in abfMalzemes)
                {
                    if (abfMalzeme.SokulenStokNo!="")
                    {
                        List<AbfMalzemeIslemKayit> abfMalzemeIslemKayits = abfMalzemeIslemKayitManager.GetList(abfMalzeme.Id, "SÖKÜLEN");
                        foreach (AbfMalzemeIslemKayit abfMalzemeIslemKayit in abfMalzemeIslemKayits)
                        {
                            if (abfMalzemeIslemKayit.StokNo == "")
                            {
                                abfMalzemeIslemKayitManager.MalzemeIslemKayitUpdate(abfMalzemeIslemKayit.Id, abfMalzeme.SokulenStokNo, abfMalzeme.SokulenSeriNo, abfMalzeme.SokulenRevizyon);
                            }
                        }
                    }
                    

                }
            }
            MessageBox.Show("Bilgiler başarıyla kaydedildi!");
        }

        private void BtnDisaAktar_Click(object sender, EventArgs e)
        {

        }

        string Control()
        {
            foreach (DataGridViewRow item in DtgIslem.Rows)
            {
                if (item.Cells["StokNo"].Value.ToString() == tiklananStok && item.Cells["Tanim"].Value.ToString() == tiklananTanim && item.Cells["SeriNo"].Value.ToString() == tiklananSeriNo && item.Cells["Revizyon"].Value.ToString() == tiklananRevizyon && item.Cells["Miktar"].Value.ConInt() == tiklananMiktar)
                {
                    return "Bu malzeme zaten eklendi!";
                }

            }
            if (CmbTeslimTuru.Text == "")
            {
                return "Lütfen teslim alma türü bilgisini doldurunuz!";
            }
            if (CmbTeslimTuru.Text == "100 - GEÇİCİ KABUL/KONTROL")
            {
                if (CmbMalzemeIadeYeri.Text == "")
                {
                    return "Lütfen Malzeme Teslim Yeri bilgisini doldurunuz!";
                }
            }
            if (CmbTeslimTuru.Text == "ATÖLYE BAKIM ONARIMDA")
            {
                return "Henüz atölye işlemleri tamamlanmadığı için malzemeyi teslim alamazsınız!";
            }
            if (CmbTeslimTuru.Text == "150 - STOĞA ALINACAK MALZEME")
            {
                return "Stoğa alınacak malzemenin işlemleri Stok Giriş Çıkış ekranından yapılmalıdır.";
            }
            if (CmbTeslimTuru.Text == "250 - ALT YÜKLENİCİYE GİDECEK MALZEME")
            {
                return "Alt Yükleniciye gidecek malzemenin teslim alma işlemleri DTF Hazırlanacaklar sayfası üzerinden yapılmaktadır!";
            }
            if (CmbTeslimTuru.Text == "ALT YÜKLENİCİ FİRMADA")
            {
                return "Alt Yüklenici Firma işlemleri henüz tamamlanmadığı için malzemeyi teslim alamazsınız!";
            }
            if (CmbTeslimTuru.Text == "300 - ATÖLYEYE GİDECEK MALZEME")
            {
                return "Atölyeye gidecek malzemenin teslim alma işlemleri Atölye Kayıt sayfasından gerçekleştirilmelidir!";
            }
            return "OK";
        }
        string teslimYeri = "";
        string TeslimAlmaDurum(string teslimTuru)
        {
            if (teslimTuru == "ARA DEPO (İADE)")
            {
                return "SEVKİYAT ARACI (ARA DEPO - VAN)";
            }
            if (teslimTuru == "SEVKİYAT ARACI (ARA DEPO - VAN)")
            {
                return "100 - GEÇİCİ KABUL/KONTROL";
            }
            if (teslimTuru == "100 - GEÇİCİ KABUL/KONTROL")
            {
                return CmbMalzemeIadeYeri.Text;
            }
            if (teslimTuru == "150 - STOĞA ALINACAK MALZEME")
            {
                return teslimTuru;
            }
            if (teslimTuru == "200 - FABRİKA BAKIM ONARIMA GİDECEK MALZEME")
            {
                return "SEVKİYAT ARACI (VAN - ASELSAN)";
            }
            if (teslimTuru == "SEVKİYAT ARACI (VAN - ASELSAN)")
            {
                return "ASELSAN BAKIM ONARIMDA";
            }
            if (teslimTuru == "ASELSAN BAKIM ONARIMDA")
            {
                return "SEVKİYAT ARACI (ASELSAN - VAN)";
            }
            if (teslimTuru == "SEVKİYAT ARACI (ASELSAN - VAN)")
            {
                return "100 - GEÇİCİ KABUL/KONTROL";
            }
            if (teslimTuru == "250 - ALT YÜKLENİCİYE GİDECEK MALZEME")
            {
                return "ALT YÜKLENİCİ FİRMADA";
            }
            if (teslimTuru == "ALT YÜKLENİCİ FİRMA İŞLEMLERİ TAMAMLANDI")
            {
                return "100 - GEÇİCİ KABUL/KONTROL";
            }
            if (teslimTuru == "300 - ATÖLYEYE GİDECEK MALZEME")
            {
                return "300 - ATÖLYEYE GİDECEK MALZEME";
            }
            if (teslimTuru == "ATÖLYE İŞLEMLERİ TAMAMLANDI")
            {
                AtolyeMalzeme atolyeMalzeme = atolyeMalzemeManager.Get(tiklananStok, tiklananSeriNo, tiklananRevizyon);
                if (atolyeMalzeme.TeslimDurumu== "DEPO STOĞUNA ALINACAK" || atolyeMalzeme.TeslimDurumu == "")
                {
                    teslimYeri = "100 - GEÇİCİ KABUL/KONTROL";
                    return teslimYeri;
                }
                if(atolyeMalzeme.TeslimDurumu == "FABRİKA ONARIM")
                {
                    teslimYeri = "200 - FABRİKA BAKIM ONARIMA GİDECEK MALZEME";
                    return teslimYeri;
                }
            }
            if (teslimTuru == "350 - GÜLYAZI ARA DEPOYA GİDECEK MALZEME")
            {
                return "GÜLYAZI ARA DEPODA";
            }
            if (teslimTuru == "400 - SİVRİ ARA DEPOYA GİDECEK MALZEME")
            {
                return "SİVRİ ARA DEPODA";
            }
            if (teslimTuru == "450 - YEŞİLTAŞ ARA DEPOYA GİDECEK MALZEME")
            {
                return "YEŞİLTAŞ ARA DEPODA";
            }
            if (teslimTuru == "500 - ŞEMDİNLİ ARA DEPOYA GİDECEK MALZEME")
            {
                return "ŞEMDİNLİ ARA DEPODA";
            }
            if (teslimTuru == "550 - DERECİK ARA DEPOYA GİDECEK MALZEME")
            {
                return "DERECİK ARA DEPODA";
            }
            if (teslimTuru == "950 - TRANSFER DEPO")
            {
                return "TRANSFER DEPODA";
            }
            if (teslimTuru == "BÖLGEYE SEVKİYAT BEKLEYEN")
            {
                return "SEVKİYAT ARACI (VAN - ARA DEPO)";
            }
            if (teslimTuru == "SEVKİYAT ARACI (VAN - ARA DEPO)")
            {
                return "BÖLGE SORUMLUSU TARAFINDAN TESLİM ALINDI";
            }
            return teslimTuru;
        }

        private void DtgIslem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DtgIslem.Rows.RemoveAt(e.RowIndex);
            }
            LblTop2.Text = DtgIslem.RowCount.ToString();
        }


        void MalzemeHazirlamaControl()
        {
            DepoMiktar depoMiktar = depoMiktarManager.StokSeriLotKontrol(stokNo, "2500", seriNo, lotNo, revizyon);

            if (depoMiktar != null)
            {
                abfMalzemeManager.TeminBilgisi(depoMiktar.Id, dusulenYer + " DEPOYA GÖNDERİLDİ", infos[1].ToString(), "DEPODAN DEPOYA İADE (AMBAR)");
            }

        }
        void MalzemeHazirlamaControl2()
        {
            DepoMiktar depoMiktar = depoMiktarManager.StokSeriLotKontrol(stokNo, "2600", seriNo, lotNo, revizyon);

            if (depoMiktar != null)
            {
                abfMalzemeManager.TeminBilgisi(depoMiktar.Id, dusulenYer + " DEPOYA GÖNDERİLDİ", infos[1].ToString(), "DEPODAN DEPOYA İADE (AMBAR)");
            }

        }
        void MalzemeHazirlamaControl3()
        {
            DepoMiktar depoMiktar = depoMiktarManager.StokSeriLotKontrol(stokNo, "2700", seriNo, lotNo, revizyon);

            if (depoMiktar != null)
            {
                abfMalzemeManager.TeminBilgisi(depoMiktar.Id, dusulenYer + " DEPOYA GÖNDERİLDİ", infos[1].ToString(), "DEPODAN DEPOYA İADE (AMBAR)");
            }

        }

        //void DepoGirisBekleyenKontrol()
        //{
        //    string stokNoDusum = stokNo;

        //    abfMalzemes = abfMalzemeManager.GetListStok(stokNoDusum);

        //    foreach (AbfMalzeme item2 in abfMalzemes)
        //    {
        //        if (stokNoDusum == item2.SokulenStokNo)
        //        {
        //            if (item2.TeminDurumu != "REZERVE EDİLDİ")
        //            {
        //                if (tedarikTuru == "SATIN ALMA")
        //                {
        //                    abfMalzemeManager.TeminBilgisi(item2.Id, "STOKTA MEVCUT (SAT)", infos[1].ToString(), item2.MalzemeIslemAdimi);
        //                }
        //                else
        //                {
        //                    //abfMalzemeManager.TeminBilgisi(item2.Id, "STOKTA MEVCUT (ASELSAN)", infos[1].ToString(), item2.MalzemeIslemAdimi);
        //                }

        //            }
        //        }
        //    }
        //}

        void AnkarayaDusum()
        {
            MalzemeHazirlamaControl();
            string lokasyon = "";
            if (seriNo == "N/A")
            {
                lokasyon = LokasyonBul(stokNo, lotNo, revizyon, takipTuru);
            }
            else
            {
                lokasyon = LokasyonBul(stokNo, seriNo, revizyon, takipTuru);
            }

            DepoMiktar depoMiktar = depoMiktarManager.StokSeriLotKontrol(stokNo, "3000", seriNo, lotNo, revizyon);
            if (depoMiktar == null)
            {
                DepoMiktar depoMiktardepo = new DepoMiktar(stokNo, tanim, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), "3000", "ASELSAN UGES", "100", miktar, "MALZEME FABRİKA BAKIM ONARIM MAKSATLI ANKARAYA GÖNDERİLMİŞTİR.");
                depoMiktarManager.Add(depoMiktardepo);
            }

            dusulenMiktar = miktar;
            string rezerveDurum = "REZERVE DEĞİL";
            string depoNoDusulen2 = "3000"; // düşülen
            string depoNoCekilen2 = lokasyon; // çekilen
            string dusulenDepoLokasyon = "100"; // düşülen depo lokasyon
            string cekilenDepoLokasyon = depoLokasyon; // çekilen depo lokasyon

            DepoMiktar depo2 = depoMiktarManager.Get(stokNo, depoNoCekilen2, seriNo, lotNo, revizyon);
            if (depo2!=null)
            {
                cekilenMiktar = depo2.Miktar - miktar;
                rezerveDurum = depo2.RezerveDurumu;
            }
            else
            {
                cekilenMiktar = miktar;
            }

            mevcutMiktar = +miktar;


            DepoMiktar depoDusulen = new DepoMiktar(stokNo, depoNoDusulen2, dusulenDepoLokasyon, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), dusulenMiktar);
            depoMiktarManager.Update(depoDusulen, rezerveDurum);

            DepoMiktar depoCekilen = new DepoMiktar(stokNo, depoNoCekilen2, cekilenDepoLokasyon, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), cekilenMiktar);
            depoMiktarManager.Update(depoCekilen, rezerveDurum);


            if (cekilenMiktar == 0)
            {
                depoMiktarManager.Delete(depo2.Id);
            }


            StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs("101-DEPODAN DEPOYA İADE", stokNo, tanim, birim, DtgTeslimTarihi.Value, depoNoCekilen2, cekilenDepoAdi, cekilenDepoLokasyon, depoNoDusulen2, "ASELSAN UGES", "100", miktar, infos[1].ToString(), "MALZEME FABRİKA BAKIM ONARIM MAKSATLI ANKARAYA GÖNDERİLMİŞTİR.", seriNo, lotNo, revizyon);

            stokGirisCikisManager.Add(stokGirisCıkıs);
        }
        void AtolyeyeDusum()
        {
            MalzemeHazirlamaControl3();
            string lokasyon = "";
            if (seriNo=="N/A")
            {
                lokasyon = LokasyonBul(stokNo, lotNo, revizyon, takipTuru);
            }
            else
            {
                lokasyon = LokasyonBul(stokNo, seriNo, revizyon, takipTuru);
            }
            

            DepoMiktar depoMiktar = depoMiktarManager.StokSeriLotKontrol(stokNo, "2700", seriNo, lotNo, revizyon);
            if (depoMiktar == null)
            {
                DepoMiktar depoMiktardepo = new DepoMiktar(stokNo, tanim, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), "2700", "ATÖLYE BO", "100", miktar, "MALZEME BAKIM ONARIM MAKSATLI ATÖLYEYE GÖNDERİLMİŞTİR.");
                depoMiktarManager.Add(depoMiktardepo);
            }

            dusulenMiktar = miktar;
            string rezerveDurum = "REZERVE DEĞİL";
            string depoNoDusulen2 = "2700"; // düşülen
            string depoNoCekilen2 = lokasyon; // çekilen
            string dusulenDepoLokasyon = "100"; // düşülen depo lokasyon
            string cekilenDepoLokasyon = depoLokasyon; // çekilen depo lokasyon

            DepoMiktar depo2 = depoMiktarManager.Get(stokNo, depoNoCekilen2, seriNo, lotNo, revizyon);
            if (depo2 != null)
            {
                cekilenMiktar = depo2.Miktar - miktar;
                rezerveDurum = depo2.RezerveDurumu;
            }
            else
            {
                cekilenMiktar = miktar;
            }

            mevcutMiktar = +miktar;


            DepoMiktar depoDusulen = new DepoMiktar(stokNo, depoNoDusulen2, dusulenDepoLokasyon, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), dusulenMiktar);
            depoMiktarManager.Update(depoDusulen, rezerveDurum);

            DepoMiktar depoCekilen = new DepoMiktar(stokNo, depoNoCekilen2, cekilenDepoLokasyon, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), cekilenMiktar);
            depoMiktarManager.Update(depoCekilen, rezerveDurum);


            if (cekilenMiktar == 0)
            {
                depoMiktarManager.Delete(depo2.Id);
            }


            StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs("101-DEPODAN DEPOYA İADE", stokNo, tanim, birim, DtgTeslimTarihi.Value, depoNoCekilen2, cekilenDepoAdi, cekilenDepoLokasyon, depoNoDusulen2, "ATÖLYE BO", "100", miktar, infos[1].ToString(), "MALZEME BAKIM ONARIM MAKSATLI ATÖLYEYE GÖNDERİLMİŞTİR.", seriNo, lotNo, revizyon);

            stokGirisCikisManager.Add(stokGirisCıkıs);
        }
        void AnkaradanDepoyaDusum()
        {
            MalzemeHazirlamaControl2();
            string lokasyon = "";
            if (seriNo == "N/A")
            {
                lokasyon = LokasyonBul(stokNo, lotNo, revizyon, takipTuru);
            }
            else
            {
                lokasyon = LokasyonBul(stokNo, seriNo, revizyon, takipTuru);
            }

            DepoMiktar depoMiktar = depoMiktarManager.StokSeriLotKontrol(stokNo, "2600", seriNo, lotNo, revizyon);
            if (depoMiktar == null)
            {
                DepoMiktar depoMiktardepo = new DepoMiktar(stokNo, tanim, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), "2600", "GEÇİCİ KABUL", "100", miktar, "FABRİKA BO DAN GELEN MALZEME TESLİM ALINMIŞTIR.");
                depoMiktarManager.Add(depoMiktardepo);
            }

            dusulenMiktar = miktar;

            string depoNoDusulen2 = "2600"; // düşülen
            string depoNoCekilen2 = lokasyon; // çekilen
            string dusulenDepoLokasyon = "100"; // düşülen depo lokasyon
            string cekilenDepoLokasyon = depoLokasyon; // çekilen depo lokasyon

            DepoMiktar depo2 = depoMiktarManager.Get(stokNo, depoNoCekilen2, seriNo, lotNo, revizyon);
            cekilenMiktar = depo2.Miktar - miktar;

            mevcutMiktar = +miktar;


            DepoMiktar depoDusulen = new DepoMiktar(stokNo, depoNoDusulen2, dusulenDepoLokasyon, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), dusulenMiktar);
            depoMiktarManager.Update(depoDusulen, depo2.RezerveDurumu);

            DepoMiktar depoCekilen = new DepoMiktar(stokNo, depoNoCekilen2, cekilenDepoLokasyon, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), cekilenMiktar);
            depoMiktarManager.Update(depoCekilen, depo2.RezerveDurumu);


            if (cekilenMiktar == 0)
            {
                depoMiktarManager.Delete(depo2.Id);
            }


            StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs("101-DEPODAN DEPOYA İADE", stokNo, tanim, birim, DtgTeslimTarihi.Value, depoNoCekilen2, cekilenDepoAdi, cekilenDepoLokasyon, depoNoDusulen2, "GEÇİCİ KABUL", "100", miktar, infos[1].ToString(), "ALT YÜKLENİCİDEN GELEN MALZEME TESLİM ALINMIŞTIR.", seriNo, lotNo, revizyon);

            stokGirisCikisManager.Add(stokGirisCıkıs);
        }
        void AltYukleniciFirmadamDepoyaDusum()
        {
            MalzemeHazirlamaControl2();
            string lokasyon = "";
            if (seriNo == "N/A")
            {
                lokasyon = LokasyonBul(stokNo, lotNo, revizyon, takipTuru);
            }
            else
            {
                lokasyon = LokasyonBul(stokNo, seriNo, revizyon, takipTuru);
            }

            DepoMiktar depoMiktar = depoMiktarManager.StokSeriLotKontrol(stokNo, "2600", seriNo, lotNo, revizyon);
            if (depoMiktar == null)
            {
                DepoMiktar depoMiktardepo = new DepoMiktar(stokNo, tanim, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), "2600", "GEÇİCİ KABUL", "100", miktar, "ALT YÜKLENİCİDEN GELEN MALZEME TESLİM ALINMIŞTIR.");
                depoMiktarManager.Add(depoMiktardepo);
            }

            dusulenMiktar = miktar;

            string depoNoDusulen2 = "2600"; // düşülen
            string depoNoCekilen2 = lokasyon; // çekilen
            string dusulenDepoLokasyon = "100"; // düşülen depo lokasyon
            string cekilenDepoLokasyon = depoLokasyon; // çekilen depo lokasyon

            DepoMiktar depo2 = depoMiktarManager.Get(stokNo, depoNoCekilen2, seriNo, lotNo, revizyon);
            cekilenMiktar = depo2.Miktar - miktar;

            mevcutMiktar = +miktar;


            DepoMiktar depoDusulen = new DepoMiktar(stokNo, depoNoDusulen2, dusulenDepoLokasyon, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), dusulenMiktar);
            depoMiktarManager.Update(depoDusulen, depo2.RezerveDurumu);

            DepoMiktar depoCekilen = new DepoMiktar(stokNo, depoNoCekilen2, cekilenDepoLokasyon, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), cekilenMiktar);
            depoMiktarManager.Update(depoCekilen, depo2.RezerveDurumu);


            if (cekilenMiktar == 0)
            {
                depoMiktarManager.Delete(depo2.Id);
            }


            StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs("101-DEPODAN DEPOYA İADE", stokNo, tanim, birim, DtgTeslimTarihi.Value, depoNoCekilen2, cekilenDepoAdi, cekilenDepoLokasyon, depoNoDusulen2, "GEÇİCİ KABUL", "100", miktar, infos[1].ToString(), "ALT YÜKLENİCİDEN GELEN MALZEME TESLİM ALINMIŞTIR.", seriNo, lotNo, revizyon);

            stokGirisCikisManager.Add(stokGirisCıkıs);
        }
        void AtolyedenDepoyaDusum()
        {
            MalzemeHazirlamaControl2();
            string lokasyon = "";
            if (seriNo == "N/A")
            {
                lokasyon = LokasyonBul(stokNo, lotNo, revizyon, takipTuru);
            }
            else
            {
                lokasyon = LokasyonBul(stokNo, seriNo, revizyon, takipTuru);
            }

            DepoMiktar depoMiktar = depoMiktarManager.StokSeriLotKontrol(stokNo, "2600", seriNo, lotNo, revizyon);
            if (depoMiktar == null)
            {
                DepoMiktar depoMiktardepo = new DepoMiktar(stokNo, tanim, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), "2600", "GEÇİCİ KABUL", "100", miktar, "ATÖLYE BO DAN GELEN MALZEME TESLİM ALINMIŞTIR.");
                depoMiktarManager.Add(depoMiktardepo);
            }

            dusulenMiktar = miktar;

            string depoNoDusulen2 = "2600"; // düşülen
            string depoNoCekilen2 = lokasyon; // çekilen
            string dusulenDepoLokasyon = "100"; // düşülen depo lokasyon
            string cekilenDepoLokasyon = depoLokasyon; // çekilen depo lokasyon

            DepoMiktar depo2 = depoMiktarManager.Get(stokNo, depoNoCekilen2, seriNo, lotNo, revizyon);
            cekilenMiktar = depo2.Miktar - miktar;

            mevcutMiktar = +miktar;


            DepoMiktar depoDusulen = new DepoMiktar(stokNo, depoNoDusulen2, dusulenDepoLokasyon, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), dusulenMiktar);
            depoMiktarManager.Update(depoDusulen, depo2.RezerveDurumu);

            DepoMiktar depoCekilen = new DepoMiktar(stokNo, depoNoCekilen2, cekilenDepoLokasyon, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), cekilenMiktar);
            depoMiktarManager.Update(depoCekilen, depo2.RezerveDurumu);


            if (cekilenMiktar == 0)
            {
                depoMiktarManager.Delete(depo2.Id);
            }


            StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs("101-DEPODAN DEPOYA İADE", stokNo, tanim, birim, DtgTeslimTarihi.Value, depoNoCekilen2, cekilenDepoAdi, cekilenDepoLokasyon, depoNoDusulen2, "GEÇİCİ KABUL", "100", miktar, infos[1].ToString(), "ATÖLYE BO DAN GELEN MALZEME TESLİM ALINMIŞTIR.", seriNo, lotNo, revizyon);

            stokGirisCikisManager.Add(stokGirisCıkıs);
        }

        string LokasyonBul(string stokNo, string seriLotNo, string revizyon, string takipDurumu)
        {
            DepoMiktar depoBilgileri = null;
            depoBilgileri = depoMiktarManager.GetBarkodLokasyonBul(stokNo, seriLotNo, revizyon, takipDurumu);
            if (depoBilgileri == null)
            {
                List<StokGirisCıkıs> stokGirisCıkıs = new List<StokGirisCıkıs>();
                stokGirisCıkıs = stokGirisCikisManager.GetList(stokNo, seriLotNo);
                if (stokGirisCıkıs.Count == 0)
                {
                    return "Bu malzemenin lokasyonu bulunamadı!";
                }

                string sonDusulneDepo = stokGirisCıkıs[stokGirisCıkıs.Count - 1].DusulenDepoNo;
                if (sonDusulneDepo == "")
                {
                    return "Bu malzemenin lokasyonu bulunamadı!";
                }

                if (sonDusulneDepo.Length < 5)
                {
                    DepoMiktar depoMiktar = new DepoMiktar(stokGirisCıkıs[stokGirisCıkıs.Count - 1].Stokno, stokGirisCıkıs[stokGirisCıkıs.Count - 1].Tanim, stokGirisCıkıs[stokGirisCıkıs.Count - 1].Serino, stokGirisCıkıs[stokGirisCıkıs.Count - 1].Lotno, stokGirisCıkıs[stokGirisCıkıs.Count - 1].Revizyon, stokGirisCıkıs[stokGirisCıkıs.Count - 1].IslemTarihi, infos[1].ToString(), stokGirisCıkıs[stokGirisCıkıs.Count - 1].DusulenDepoNo, stokGirisCıkıs[stokGirisCıkıs.Count - 1].DusulenDepoAdresi, stokGirisCıkıs[stokGirisCıkıs.Count - 1].DusulenMalzemeYeri, stokGirisCıkıs[stokGirisCıkıs.Count - 1].DusulenMiktar, stokGirisCıkıs[stokGirisCıkıs.Count - 1].Aciklama);

                    depoMiktarManager.Add(depoMiktar);

                    depoBilgileri = depoMiktarManager.GetBarkodLokasyonBul(stokNo, seriLotNo, revizyon, takipDurumu);
                    if (depoBilgileri == null)
                    {
                        DepoMiktar depoMiktar1 = depoMiktarManager.Get(stokGirisCıkıs[stokGirisCıkıs.Count - 1].Stokno, stokGirisCıkıs[stokGirisCıkıs.Count - 1].DusulenDepoNo, stokGirisCıkıs[stokGirisCıkıs.Count - 1].Serino, stokGirisCıkıs[stokGirisCıkıs.Count - 1].Lotno, stokGirisCıkıs[stokGirisCıkıs.Count - 1].Revizyon);

                        if (depoMiktar1 != null)
                        {
                            depoMiktarManager.Delete(depoMiktar1.Id);
                        }

                        return "Bu malzemenin lokasyonu bulunamadı!";
                    }
                }
                else
                {
                    return "Bu malzemenin lokasyonu bulunamadı!";
                }
            }

            depoLokasyon = depoBilgileri.DepoLokasyon;
            cekilenDepoAdi = depoBilgileri.DepoAdresi;
            return depoBilgileri.DepoNo;
        }

        private void BtnTeslimAlSat_Click(object sender, EventArgs e)
        {
            if (CmbTeslimTuru.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Malzeme Teslim Alma türünü seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult de = MessageBox.Show("Bilgileri kaydetmek istediğinze emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (de != DialogResult.Yes)
            {
                return;
            }

            foreach (DataGridViewRow item in DtgIslem.Rows)
            {
                if (CmbTeslimTuru.Text == "ARA DEPO (İADE)")
                {
                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "ARA DEPO (İADE)", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (ARA DEPO - VAN)");
                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (ARA DEPO - VAN)");
                    }
                    
                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (ARA DEPO - VAN)", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt().ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }

                if (CmbTeslimTuru.Text == "SEVKİYAT ARACI (ARA DEPO - VAN)")
                {
                    stokNo = item.Cells["StokNo"].Value.ToString();
                    tanim = item.Cells["Tanim"].Value.ToString();
                    revizyon = item.Cells["Revizyon"].Value.ToString();
                    birim = item.Cells["Birim"].Value.ToString();
                    miktar = item.Cells["Miktar"].Value.ConInt();

                    Malzeme malzeme = malzemeManager.Get(stokNo);
                    if (malzeme == null)
                    {
                        MessageBox.Show("Malzeme bilgilerine ulaşılamamıştır!\nLütfen Kayıtlı Malzemeler listesini kontrol ediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (malzeme.TakipDurumu == "LOT NO")
                    {
                        seriNo = "N/A";
                        lotNo = item.Cells["SeriNo"].Value.ToString();
                    }
                    else
                    {
                        seriNo = item.Cells["SeriNo"].Value.ToString();
                        lotNo = "N/A";
                    }

                    DepoMiktar depoMiktar = depoMiktarManager.StokSeriLotKontrol(stokNo, "2500", seriNo, lotNo, revizyon);
                    if (depoMiktar == null)
                    {
                        DepoMiktar depoMiktar2 = new DepoMiktar(stokNo, tanim, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), "2500", "BAKIM ONARIM (GİDEN)", "100", miktar, "MALZEMENİN MEVCUT ARIZADAN DEPOYA DÜŞÜMÜ YAPILMIŞTIR.");
                        depoMiktarManager.Add(depoMiktar2);
                    }
                    else
                    {
                        mevcutMiktar = depoMiktar.Miktar;
                        mevcutMiktar = +miktar;

                        DepoMiktar depoDusulen = new DepoMiktar(stokNo, "2500", "100", seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), mevcutMiktar);
                        depoMiktarManager.Update(depoDusulen, depoMiktar.RezerveDurumu);
                    }

                    StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs("201-BİLDİRİMDEN DEPOYA İADE", stokNo, tanim, birim, DtgTeslimTarihi.Value, item.Cells["AbfNo"].Value.ToString(), "", "", "2500", "BAKIM ONARIM (GİDEN)", "100", miktar, infos[1].ToString(), DateTime.Now.ToString("dd.MM.yyyy") + "MALZEMENİN MEVCUT ARIZADAN DEPOYA DÜŞÜMÜ YAPILMIŞTIR.", seriNo, lotNo, revizyon);

                    stokGirisCikisManager.Add(stokGirisCıkıs);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (ARA DEPO - VAN)", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (true)
                    {

                    }
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL");

                    

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }

                if (CmbTeslimTuru.Text == "100 - GEÇİCİ KABUL/KONTROL")
                {
                    if (item.Cells["TeslimDurum"].Value.ToString() == "BÖLGEYE SEVKİYAT BEKLEYEN")
                    {
                        stokNo = item.Cells["StokNo"].Value.ToString();
                        tanim = item.Cells["Tanim"].Value.ToString();
                        revizyon = item.Cells["Revizyon"].Value.ToString();

                        Malzeme malzeme = malzemeManager.Get(stokNo);
                        if (malzeme == null)
                        {
                            MessageBox.Show("Malzeme bilgilerine ulaşılamamıştır!\nLütfen Kayıtlı Malzemeler listesini kontrol ediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (malzeme.TakipDurumu == "LOT NO")
                        {
                            seriNo = "N/A";
                            lotNo = item.Cells["SeriNo"].Value.ToString();
                        }
                        else
                        {
                            seriNo = item.Cells["SeriNo"].Value.ToString();
                            lotNo = "N/A";
                        }

                        string lokasyon = LokasyonBul(stokNo, item.Cells["SeriNo"].Value.ToString(), revizyon, malzeme.TakipDurumu);

                        if (lokasyon == "Bu malzemenin lokasyonu bulunamadı!")
                        {
                            MessageBox.Show(lokasyon, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }

                        miktar = item.Cells["Miktar"].Value.ConInt();
                        DepoMiktar depo2 = depoMiktarManager.Get(stokNo, lokasyon, seriNo, lotNo, revizyon);
                        mevcutMiktar = depo2.Miktar;
                        mevcutMiktar = mevcutMiktar - miktar;
                        int silineceId = depo2.Id;
                        string depoNoDusulen2 = item.Cells["AbfNo"].Value.ToString(); // düşülen
                        string depoNoCekilen2 = lokasyon; // çekilen

                        /*string dusulenDepoLokasyon = "";*/ // düşülen depo lokasyon
                        string cekilenDepoLokasyon = depoLokasyon; // çekilen depo lokasyon


                        if (malzeme == null)
                        {
                            MessageBox.Show("Malzeme kaydı bulunamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
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

                        StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs("102-DEPODAN BİLDİRİME ÇEKİM", stokNo, tanim, malzeme.Birim, DateTime.Now, depoNoCekilen2, cekilenDepoAdi, cekilenDepoLokasyon, depoNoDusulen2, "", "", miktar, item.Cells["BolgeSorumlusu"].Value.ToString(), "MALZEMENİN MEVCUT BİLDİRİME DEPO DÜŞÜMÜ YAPILMIŞTIR.", seriNo, lotNo, revizyon);

                        stokGirisCikisManager.Add(stokGirisCıkıs);
                    }

                    if (item.Cells["TeslimDurum"].Value.ToString() == "200 - FABRİKA BAKIM ONARIMA GİDECEK MALZEME")
                    {
                        stokNo = item.Cells["StokNo"].Value.ToString();
                        tanim = item.Cells["Tanim"].Value.ToString();
                        revizyon = item.Cells["Revizyon"].Value.ToString();
                        miktar = item.Cells["Miktar"].Value.ConInt();
                        birim = item.Cells["Birim"].Value.ToString();
                        Malzeme malzeme = malzemeManager.Get(stokNo);
                        if (malzeme != null)
                        {
                            takipTuru = malzeme.TakipDurumu;
                            tedarikTuru = malzeme.TedarikTuru;
                            if (takipTuru == "SERİ NO")
                            {
                                seriNo = item.Cells["SeriNo"].Value.ToString();
                                lotNo = "N/A";
                            }
                            else
                            {
                                seriNo = "N/A";
                                lotNo = item.Cells["SeriNo"].Value.ToString();
                            }

                            dusulenYer = "3000";
                            AnkarayaDusum();
                        }
                    }

                    if (item.Cells["TeslimDurum"].Value.ToString() == "300 - ATÖLYEYE GİDECEK MALZEME")
                    {
                        stokNo = item.Cells["StokNo"].Value.ToString();
                        tanim = item.Cells["Tanim"].Value.ToString();
                        revizyon = item.Cells["Revizyon"].Value.ToString();
                        miktar = item.Cells["Miktar"].Value.ConInt();
                        birim = item.Cells["Birim"].Value.ToString();
                        Malzeme malzeme = malzemeManager.Get(stokNo);
                        if (malzeme != null)
                        {
                            takipTuru = malzeme.TakipDurumu;
                            tedarikTuru = malzeme.TedarikTuru;
                            if (takipTuru == "SERİ NO")
                            {
                                seriNo = item.Cells["SeriNo"].Value.ToString();
                                lotNo = "N/A";
                            }
                            else
                            {
                                seriNo = "N/A";
                                lotNo = item.Cells["SeriNo"].Value.ToString();
                            }

                            dusulenYer = "2700";
                            AtolyeyeDusum();
                        }
                    }

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu == "SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), item.Cells["TeslimDurum"].Value.ToString());
                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), item.Cells["TeslimDurum"].Value.ToString());
                    }

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), item.Cells["TeslimDurum"].Value.ToString(), tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }

                if (CmbTeslimTuru.Text == "150 - STOĞA ALINACAK MALZEME")
                {
                    

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "150 - STOĞA ALINACAK MALZEME", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "150 - STOĞA ALINACAK MALZEME");
                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "150 - STOĞA ALINACAK MALZEME");
                    }

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "150 - STOĞA ALINACAK MALZEME", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }

                if (CmbTeslimTuru.Text == "200 - FABRİKA BAKIM ONARIMA GİDECEK MALZEME")
                {
                    

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "200 - FABRİKA BAKIM ONARIMA GİDECEK MALZEME", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (VAN - ASELSAN)");
                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (VAN - ASELSAN)");
                    }

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (VAN - ASELSAN)", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }

                    continue;
                }

                if (CmbTeslimTuru.Text == "SEVKİYAT ARACI (VAN - ASELSAN)")
                {
                    

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);
                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (VAN - ASELSAN)", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "ASELSAN BAKIM ONARIMDA");

                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "ASELSAN BAKIM ONARIMDA");
                    }

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "ASELSAN BAKIM ONARIMDA", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }

                if (CmbTeslimTuru.Text == "ASELSAN BAKIM ONARIMDA")
                {
                    
                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "ASELSAN BAKIM ONARIMDA", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (ASELSAN - VAN)");

                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (ASELSAN - VAN)");
                    }

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (ASELSAN - VAN)", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }


                if (CmbTeslimTuru.Text == "SEVKİYAT ARACI (ASELSAN - VAN)")
                {
                    stokNo = item.Cells["StokNo"].Value.ToString();
                    tanim = item.Cells["Tanim"].Value.ToString();
                    revizyon = item.Cells["Revizyon"].Value.ToString();
                    miktar = item.Cells["Miktar"].Value.ConInt();
                    birim = item.Cells["Birim"].Value.ToString();
                    Malzeme malzeme = malzemeManager.Get(stokNo);
                    if (malzeme != null)
                    {
                        takipTuru = malzeme.TakipDurumu;
                        tedarikTuru = malzeme.TedarikTuru;
                        if (takipTuru == "SERİ NO")
                        {
                            seriNo = item.Cells["SeriNo"].Value.ToString();
                            lotNo = "N/A";
                        }
                        else
                        {
                            seriNo = "N/A";
                            lotNo = item.Cells["SeriNo"].Value.ToString();
                        }

                        dusulenYer = "2600";
                        AnkaradanDepoyaDusum();
                    }

                    

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);
                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (ASELSAN - VAN)", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL");
                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL");
                    }

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }


                if (CmbTeslimTuru.Text == "250 - ALT YÜKLENİCİYE GİDECEK MALZEME")
                {
                    

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);
                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "250 - ALT YÜKLENİCİYE GİDECEK MALZEME", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "ALT YÜKLENİCİ FİRMADA");
                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "ALT YÜKLENİCİ FİRMADA");
                    }

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "ALT YÜKLENİCİ FİRMADA", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }

                if (CmbTeslimTuru.Text == "ALT YÜKLENİCİ FİRMA İŞLEMLERİ TAMAMLANDI")
                {
                    stokNo = item.Cells["StokNo"].Value.ToString();
                    tanim = item.Cells["Tanim"].Value.ToString();
                    revizyon = item.Cells["Revizyon"].Value.ToString();
                    miktar = item.Cells["Miktar"].Value.ConInt();
                    birim = item.Cells["Birim"].Value.ToString();
                    Malzeme malzeme = malzemeManager.Get(stokNo);
                    if (malzeme != null)
                    {
                        takipTuru = malzeme.TakipDurumu;
                        tedarikTuru = malzeme.TedarikTuru;
                        if (takipTuru == "SERİ NO")
                        {
                            seriNo = item.Cells["SeriNo"].Value.ToString();
                            lotNo = "N/A";
                        }
                        else
                        {
                            seriNo = "N/A";
                            lotNo = item.Cells["SeriNo"].Value.ToString();
                        }

                        dusulenYer = "2600";
                        AltYukleniciFirmadamDepoyaDusum();
                    }

                    

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "ALT YÜKLENİCİ FİRMA İŞLEMLERİ TAMAMLANDI", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL");
                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL");
                    }

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }

                if (CmbTeslimTuru.Text == "300 - ATÖLYEYE GİDECEK MALZEME")
                {
                    

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "300 - ATÖLYEYE GİDECEK MALZEME", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "300 - ATÖLYEYE GİDECEK MALZEME");
                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "300 - ATÖLYEYE GİDECEK MALZEME");
                    }

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "300 - ATÖLYEYE GİDECEK MALZEME", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }

                if (CmbTeslimTuru.Text == "ATÖLYE İŞLEMLERİ TAMAMLANDI")
                {

                    stokNo = item.Cells["StokNo"].Value.ToString();
                    tanim = item.Cells["Tanim"].Value.ToString();
                    revizyon = item.Cells["Revizyon"].Value.ToString();
                    miktar = item.Cells["Miktar"].Value.ConInt();
                    birim = item.Cells["Birim"].Value.ToString();
                    Malzeme malzeme = malzemeManager.Get(stokNo);
                    if (malzeme != null)
                    {
                        takipTuru = malzeme.TakipDurumu;
                        tedarikTuru = malzeme.TedarikTuru;
                        if (takipTuru == "SERİ NO")
                        {
                            seriNo = item.Cells["SeriNo"].Value.ToString();
                            lotNo = "N/A";
                        }
                        else
                        {
                            seriNo = "N/A";
                            lotNo = item.Cells["SeriNo"].Value.ToString();
                        }

                        
                        if (teslimYeri== "DEPO STOĞUNA ALINACAK")
                        {
                            dusulenYer = "2600";
                            AtolyedenDepoyaDusum();
                        }
                        else
                        {
                            AnkarayaDusum();
                        }
                    }

                    

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "ATÖLYE İŞLEMLERİ TAMAMLANDI", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), item.Cells["TeslimDurum"].Value.ToString());
                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), item.Cells["TeslimDurum"].Value.ToString());
                    }
                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), item.Cells["TeslimDurum"].Value.ToString(), tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }

                if (CmbTeslimTuru.Text == "350 - GÜLYAZI ARA DEPOYA GİDECEK MALZEME")
                {
                    

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "350 - GÜLYAZI ARA DEPOYA GİDECEK MALZEME", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "GÜLYAZI ARA DEPODA");
                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "GÜLYAZI ARA DEPODA");
                    }

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "GÜLYAZI ARA DEPODA", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }

                if (CmbTeslimTuru.Text == "400 - SİVRİ ARA DEPOYA GİDECEK MALZEME")
                {
                    

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "400 - SİVRİ ARA DEPOYA GİDECEK MALZEME", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "SİVRİ ARA DEPODA");
                    }
                    else
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "SİVRİ ARA DEPODA");
                    }
                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "SİVRİ ARA DEPODA", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }

                if (CmbTeslimTuru.Text == "450 - YEŞİLTAŞ ARA DEPOYA GİDECEK MALZEME")
                {
                    

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "450 - YEŞİLTAŞ ARA DEPOYA GİDECEK MALZEME", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "YEŞİLTAŞ ARA DEPODA");
                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "YEŞİLTAŞ ARA DEPODA");
                    }

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "YEŞİLTAŞ ARA DEPODA", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }

                if (CmbTeslimTuru.Text == "500 - ŞEMDİNLİ ARA DEPOYA GİDECEK MALZEME")
                {
                    

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "500 - ŞEMDİNLİ ARA DEPOYA GİDECEK MALZEME", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "ŞEMDİNLİ ARA DEPODA");
                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "ŞEMDİNLİ ARA DEPODA");
                    }

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "ŞEMDİNLİ ARA DEPODA", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }

                if (CmbTeslimTuru.Text == "550 - DERECİK ARA DEPOYA GİDECEK MALZEME")
                {
                    

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);
                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "550 - DERECİK ARA DEPOYA GİDECEK MALZEME", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "DERECİK ARA DEPODA");
                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "DERECİK ARA DEPODA");
                    }

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "DERECİK ARA DEPODA", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }

                if (CmbTeslimTuru.Text == "950 - TRANSFER DEPO")
                {

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "950 - TRANSFER DEPO", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "TRANSFER DEPODA");
                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "TRANSFER DEPODA");
                    }

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "TRANSFER DEPODA", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }

                if (CmbTeslimTuru.Text == "BÖLGEYE SEVKİYAT BEKLEYEN")
                {
                    

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "BÖLGEYE SEVKİYAT BEKLEYEN", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (VAN - ARA DEPO)");
                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (VAN - ARA DEPO)");
                    }

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (VAN - ARA DEPO)", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    
                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }

                if (CmbTeslimTuru.Text == "SEVKİYAT ARACI (VAN - ARA DEPO)")
                {
                    

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (VAN - ARA DEPO)", item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());

                    if (abfMalzemeIslemKayit1.MalzemeDurumu=="SÖKÜLEN")
                    {
                        abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "BÖLGE SORUMLUSU TARAFINDAN TESLİM ALINDI");
                    }
                    else
                    {
                        abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "BÖLGE SORUMLUSU TARAFINDAN TESLİM ALINDI");
                    }

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "BÖLGE SORUMLUSU TARAFINDAN TESLİM ALINDI", tarihSaat, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Revizyon"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    if (abfMalzemeIslemKayit1 != null)
                    {
                        TimeSpan gecenSure = tarihSaat - abfMalzemeIslemKayit1.Tarih;
                        if (gecenSure.TotalMinutes.ConInt() > 0)
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                        }
                        else
                        {
                            abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                        }
                    }
                    continue;
                }

            }

            LblIadeYeri.Visible = false;
            CmbMalzemeIadeYeri.Visible = false;
            BtnTeslimTuru.Visible = false;

            start = true;
            CmbTeslimTuru.SelectedIndex = -1;
            CmbMalzemeIadeYeri.SelectedIndex = -1;
            DtgList.ClearFilter();
            Yenilenecekler();
            start = false;

            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DtgIslem.Rows.Clear();
            TxtAciklama.Clear();
            LblTop2.Text = DtgIslem.RowCount.ToString();

        }

        private void CmbTeslimTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataDisplay();
            DtgIslem.Rows.Clear();
            if (CmbTeslimTuru.Text == "100 - GEÇİCİ KABUL/KONTROL")
            {
                LblIadeYeri.Visible = true;
                CmbMalzemeIadeYeri.Visible = true;
                BtnTeslimAlSat.Text = " TESLİM ET";
            }
            else
            {
                LblIadeYeri.Visible = false;
                CmbMalzemeIadeYeri.Visible = false;
                BtnTeslimAlSat.Text = " TESLİM AL";
            }

            if (CmbTeslimTuru.Text == "SEVKİYAT ARACI (ARA DEPO - VAN)" || CmbTeslimTuru.Text == "SEVKİYAT ARACI (VAN - ASELSAN)" || CmbTeslimTuru.Text == "SEVKİYAT ARACI (ASELSAN - VAN)" || CmbTeslimTuru.Text == "SEVKİYAT ARACI (VAN - ARA DEPO)")
            {
                if (infos[11].ToString() == "YÖNETİCİ" || infos[11].ToString() == "ADMİN" || infos[0].ConInt() == 39 || infos[0].ConInt() == 1148 || infos[0].ConInt() == 44|| infos[0].ConInt() == 33)
                {
                    BtnDisaAktar.Visible = true;
                }
                
            }
            else
            {
                BtnDisaAktar.Visible = false;
            }
        }

        private void BtnTeslimTuru_Click(object sender, EventArgs e)
        {
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = "TESLIM_TURU";
            frmCombo.ShowDialog();
        }
    }
}
