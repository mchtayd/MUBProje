using Business;
using Business.Concreate.BakimOnarim;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using Entity;
using Entity.BakimOnarim;
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
        

        public object[] infos;
        bool start = true;
        string stokNo, tanim, seriNo, lotNo, revizyon, depoLokasyon, cekilenDepoAdi;
        int mevcutMiktar, miktar;

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
        }

        private void FrmAltTakimTakip_Load(object sender, EventArgs e)
        {
            CmbProj();
            DataDisplay();
            DtgSaat.Value = DateTime.Now;
            start = false;
            CmbTeslimTuru.DataSource = abfMalzemeManager.MalzemeTeslimTuru();
            CmbTeslimTuru.SelectedIndex = -1;
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
            CmbProj();
            DataDisplay();
            DtgSaat.Value = DateTime.Now;
            start = false;
            CmbTeslimTuru.DataSource = abfMalzemeManager.MalzemeTeslimTuru();
            CmbTeslimTuru.SelectedIndex = -1;
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
        string tiklananStok, tiklananTanim, tiklananSeriNo, tiklananRevizyon; int tiklananMiktar;
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
            if (CmbTeslimTuru.Text== "ATÖLYE BAKIM ONARIMDA")
            {
                return "Henüz atölye işlemleri tamamlanmadığı için malzemeyi teslim alamazsınız!";
            }
            return "OK";
        }

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
            if (teslimTuru == "ALT YÜKLENİCİ FİRMADA")
            {
                return "100 - GEÇİCİ KABUL/KONTROL";
            }
            if (teslimTuru == "300 - ATÖLYEYE GİDECEK MALZEME")
            {
                return "300 - ATÖLYEYE GİDECEK MALZEME";
            }
            if (teslimTuru == "ATÖLYE İŞLEMLERİ TAMAMLANDI")
            {
                return "100 - GEÇİCİ KABUL/KONTROL";
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
        string LokasyonBul(string stokNo,string seriLotNo, string revizyon,string takipDurumu)
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
            if (de!=DialogResult.Yes)
            {
                return;
            }

            foreach (DataGridViewRow item in DtgIslem.Rows)
            {
                if (CmbTeslimTuru.Text== "ARA DEPO (İADE)")
                {
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (ARA DEPO - VAN)");
                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (ARA DEPO - VAN)", tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "ARA DEPO (İADE)");
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
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL");

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL", tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (ARA DEPO - VAN)");
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
                    if (item.Cells["TeslimDurum"].Value.ToString()== "BÖLGEYE SEVKİYAT BEKLEYEN")
                    {
                        stokNo = item.Cells["StokNo"].Value.ToString();
                        tanim = item.Cells["Tanim"].Value.ToString();
                        revizyon = item.Cells["Revizyon"].Value.ToString();

                        Malzeme malzeme = malzemeManager.Get(stokNo);
                        if (malzeme==null)
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

                        if (lokasyon== "Bu malzemenin lokasyonu bulunamadı!")
                        {
                            MessageBox.Show(lokasyon, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }

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

                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), item.Cells["TeslimDurum"].Value.ToString());

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), item.Cells["TeslimDurum"].Value.ToString(), tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL");
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
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "150 - STOĞA ALINACAK MALZEME");

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "150 - STOĞA ALINACAK MALZEME", tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "150 - STOĞA ALINACAK MALZEME");
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
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (VAN - ASELSAN)");

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (VAN - ASELSAN)", tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "200 - FABRİKA BAKIM ONARIMA GİDECEK MALZEME");
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
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "ASELSAN BAKIM ONARIMDA");

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "ASELSAN BAKIM ONARIMDA", tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (VAN - ASELSAN)");
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
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (ASELSAN - VAN)");

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (ASELSAN - VAN)", tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "ASELSAN BAKIM ONARIMDA");
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
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL");

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL", tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "SEVKİYAT ARACI (ASELSAN - VAN)");
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
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "ALT YÜKLENİCİ FİRMADA");

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "ALT YÜKLENİCİ FİRMADA", tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "250 - ALT YÜKLENİCİYE GİDECEK MALZEME");
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

                if (CmbTeslimTuru.Text == "ALT YÜKLENİCİ FİRMADA")
                {
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL");

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL", tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "ALT YÜKLENİCİ FİRMADA");
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
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "300 - ATÖLYEYE GİDECEK MALZEME");

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "300 - ATÖLYEYE GİDECEK MALZEME", tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "300 - ATÖLYEYE GİDECEK MALZEME");
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
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL");

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "100 - GEÇİCİ KABUL/KONTROL", tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "ATÖLYE İŞLEMLERİ TAMAMLANDI");
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
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "GÜLYAZI ARA DEPODA");

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "GÜLYAZI ARA DEPODA", tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "350 - GÜLYAZI ARA DEPOYA GİDECEK MALZEME");
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
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "SİVRİ ARA DEPODA");

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "SİVRİ ARA DEPODA", tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "400 - SİVRİ ARA DEPOYA GİDECEK MALZEME");
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
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "YEŞİLTAŞ ARA DEPODA");

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "YEŞİLTAŞ ARA DEPODA", tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "450 - YEŞİLTAŞ ARA DEPOYA GİDECEK MALZEME");
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
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "ŞEMDİNLİ ARA DEPODA");

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "ŞEMDİNLİ ARA DEPODA", tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "500 - ŞEMDİNLİ ARA DEPOYA GİDECEK MALZEME");
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
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "DERECİK ARA DEPODA");

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "DERECİK ARA DEPODA", tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "550 - DERECİK ARA DEPOYA GİDECEK MALZEME");
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
                    abfMalzemeManager.MalzemeTeslimBilgisiUpdate(item.Cells["Id"].Value.ConInt(), "TRANSFER DEPODA");

                    DateTime tarihSaat = new DateTime(DtgTeslimTarihi.Value.Year, DtgTeslimTarihi.Value.Month, DtgTeslimTarihi.Value.Day, DtgSaat.Value.Hour, DtgSaat.Value.Minute, DtgSaat.Value.Second);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(item.Cells["Id"].Value.ConInt(), "TRANSFER DEPODA", tarihSaat, infos[1].ToString(), 0);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                    AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(item.Cells["Id"].Value.ConInt(), "950 - TRANSFER DEPO");
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

;       }

        private void CmbTeslimTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataDisplay();
            if (CmbTeslimTuru.Text == "100 - GEÇİCİ KABUL/KONTROL")
            {
                LblIadeYeri.Visible = true;
                CmbMalzemeIadeYeri.Visible = true;

            }
            else
            {
                LblIadeYeri.Visible = false;
                CmbMalzemeIadeYeri.Visible = false;
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
