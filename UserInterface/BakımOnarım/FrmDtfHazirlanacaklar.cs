using Business;
using Business.Concreate.AnaSayfa;
using Business.Concreate.BakimOnarim;
using Business.Concreate.Depo;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.STS;
using DataAccess;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Entity;
using Entity.AnaSayfa;
using Entity.BakimOnarim;
using Entity.Depo;
using Entity.Gecic_Kabul_Ambar;
using Entity.IdariIsler;
using Entity.STS;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;
using UserInterface.STS;
using Application = Microsoft.Office.Interop.Word.Application;
using Document = Microsoft.Office.Interop.Word.Document;

namespace UserInterface.BakımOnarım
{
    public partial class FrmDtfHazirlanacaklar : Form
    {
        IsAkisNoManager isAkisNoManager;
        ComboManager comboManager;
        AltYukleniciManager altYukleniciManager;
        AbfMalzemeManager abfMalzemeManager;
        ArizaKayitManager arizaKayitManager;
        DtfManager dtfManager;
        AbfMalzemeIslemKayitManager abfMalzemeIslemKayitManager;
        MalzemeManager malzemeManager;
        DepoMiktarManager depoMiktarManager;
        DepoKayitManagercs depoKayitManagercs;
        StokGirisCikisManager stokGirisCikisManager;
        DtsLogManager dtsLogManager;

        List<AbfMalzeme> abfMalzemes;
        bool start = false;
        public object[] infos;
        string donem, comboAd, taslakYolu, dosyaYolu, stokNo, abfNo, projeKodu, garantiDurumu, tanim, seriNo, revizyon, birim, takipTuru, tedarikTuru, lotNo, dusulenYer, depoLokasyon, cekilenDepoAdi = "";
        int id, malzemeId, miktar, dusulenMiktar, cekilenMiktar, mevcutMiktar = 0;
        int arizaId = 0;
        string yol = @"C:\DTS\Taslak\";
        string kaynak = @"Z:\DTS\BAKIM ONARIM\TASLAKLAR\";
        public FrmDtfHazirlanacaklar()
        {
            InitializeComponent();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            altYukleniciManager = AltYukleniciManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            dtfManager = DtfManager.GetInstance();
            abfMalzemeIslemKayitManager = AbfMalzemeIslemKayitManager.GetInstance();
            depoMiktarManager = DepoMiktarManager.GetInstance();
            depoKayitManagercs = DepoKayitManagercs.GetInstance();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
            dtsLogManager = DtsLogManager.GetInstance();
        }

        private void CmbDepoAdresi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start==false)
            {
                return;
            }

            int value = CmbDepoAdresi.SelectedValue.ConInt();
            DepoKayit depoKayit = depoKayitManagercs.Get(value);
            LblDepoNo.Text = depoKayit.Depo;
        }

        private void FrmOkfKontrol_Load(object sender, EventArgs e)
        {
            DataDisplay();
            IsAkisNo();
            TalebiOlusturan();
            IsKategorisi();
            AltYukleniciFirma();
            CmbDepoCekilen();
            start = true;
        }
        public void Yenileneceler()
        {
            start = false;
            DataDisplay();
            IsAkisNo();
            TalebiOlusturan();
            IsKategorisi();
            AltYukleniciFirma();
            start = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDtfHazirlanacaklar"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void DataDisplay()
        {
            abfMalzemes = new List<AbfMalzeme>();
            dataBinderOto.DataSource = null;
            abfMalzemes = abfMalzemeManager.DtfKayitList();

            dataBinderOto.DataSource = abfMalzemes.ToDataTable();
            DtgList.DataSource = dataBinderOto;

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
            DtgList.Columns["DosyaYolu"].Visible = false;

            DtgList.Columns["SokulenTeslimDurum"].DisplayIndex = 1;
            DtgList.Columns["SokulenStokNo"].DisplayIndex = 2;
            DtgList.Columns["SokulenTanim"].DisplayIndex = 3;
            DtgList.Columns["SokulenSeriNo"].DisplayIndex = 4;
            DtgList.Columns["SokulenRevizyon"].DisplayIndex = 5;
            DtgList.Columns["SokulenMiktar"].DisplayIndex = 6;
            DtgList.Columns["SokulenBirim"].DisplayIndex = 7;
            DtgList.Columns["BolgeAdi"].DisplayIndex = 8;
            DtgList.Columns["AbfNo"].DisplayIndex = 9;
            DtgList.Columns["YapilacakIslem"].DisplayIndex = 10;
            DtgList.Columns["BolgeSorumlusu"].DisplayIndex = 11;

            TxtTop.Text = DtgList.RowCount.ToString();
        }

        public void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        void TalebiOlusturan()
        {
            TalepEden.Text = infos[1].ToString();
            LblKayitTarihi.Text = DateTime.Now.ToString("dd.MM.yyyy");
            donem = FrmHelper.DonemControl(DateTime.Now);

            string[] array = donem.Split(' ');

            CmbDonemAy.Text = array[0].ToString();
            CmbDonemYil.Text = array[1].ToString();
        }
        public void IsKategorisi()
        {
            CmbIsKategorisi.DataSource = comboManager.GetList("IS_KATEGORISI");
            CmbIsKategorisi.ValueMember = "Id";
            CmbIsKategorisi.DisplayMember = "Baslik";
            CmbIsKategorisi.SelectedValue = 0;
        }
        void AltYukleniciFirma()
        {
            CmbAltYukleniciFirma.DataSource = altYukleniciManager.GetList(0);
            CmbAltYukleniciFirma.ValueMember = "Id";
            CmbAltYukleniciFirma.DisplayMember = "Firmaadi";
            CmbAltYukleniciFirma.SelectedValue = 0;
        }

        private void CmbAltYukleniciFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            if (CmbAltYukleniciFirma.SelectedIndex == -1)
            {
                LblFirmaSorumlusu.Text = "00";
                return;
            }
            id = CmbAltYukleniciFirma.SelectedValue.ConInt();
            AltYuklenici altYukleniciFirma = altYukleniciManager.Get(id);
            LblFirmaSorumlusu.Text = altYukleniciFirma.Personeladi;
            
        }

        private void BtnAltYukFirmaEkle_Click(object sender, EventArgs e)
        {
            FrmAltYukleniciFirma frmBolgeler = new FrmAltYukleniciFirma();
            frmBolgeler.button5.Visible = false;
            frmBolgeler.ShowDialog();
        }
        string malzeme = "";
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            arizaId = DtgList.CurrentRow.Cells["BenzersizId"].Value.ConInt();
            LblBolgeAdi.Text = DtgList.CurrentRow.Cells["BolgeAdi"].Value.ToString();
            stokNo = DtgList.CurrentRow.Cells["SokulenStokNo"].Value.ToString();
            tanim = DtgList.CurrentRow.Cells["SokulenTanim"].Value.ToString();
            seriNo = DtgList.CurrentRow.Cells["SokulenSeriNo"].Value.ToString();
            abfNo = DtgList.CurrentRow.Cells["AbfNo"].Value.ToString();
            miktar = DtgList.CurrentRow.Cells["SokulenMiktar"].Value.ConInt();
            revizyon = DtgList.CurrentRow.Cells["SokulenRevizyon"].Value.ToString();
            birim = DtgList.CurrentRow.Cells["SokulenBirim"].Value.ToString();
            ArizaKayit arizaKayit = arizaKayitManager.GetId(arizaId);
            TxtIsinTanimi.Text = arizaKayit.TespitEdilenAriza;
            projeKodu = arizaKayit.Proje;
            garantiDurumu = arizaKayit.GarantiDurumu;
            malzemeId = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            malzeme =  stokNo + " | " + tanim.Trim() + " | " + seriNo + " | " + miktar + " | " + birim;
            TxtIsinTanimi.Text += "\n\n"+ malzeme;
        }

        string Control()
        {
            if (CmbDonemAy.Text=="")
            {
                return "Lütfen dönem bilgisini doldurunuz!";
            }
            if (CmbDonemYil.Text=="")
            {
                return "Lütfen dönem yıl bilgisini doldurunuz!";
            }
            if (CmbAltYukleniciFirma.Text == "")
            {
                return "Alt Yüklenici Firma bilgisini doldurunuz!";
            }
            if (CmbDepoAdresi.Text == "")
            {
                return "Düşümü Yapılacak Depo Adresi bilgisini doldurunuz!";
            }
            if (CmbButceKodu.Text == "")
            {
                return "Bütçe Kodu bilgisini doldurunuz!";
            }
            if (CmbIsKategorisi.Text == "")
            {
                return "İş Kategorisi bilgisini doldurunuz!";
            }
            if (TxtIsinTanimi.Text == "")
            {
                return "İş Tanımı bilgisini doldurunuz!";
            }
            if (CmbOnarimYeri.Text == "")
            {
                return "Onarım Yeri bilgisini doldurunuz!";
            }
            return "OK";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (Control()!="OK")
            {
                MessageBox.Show(Control(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IsAkisNo();

                string anadosya = @"Z:\DTS\BAKIM ONARIM\DTF\";
                dosyaYolu = anadosya + LblIsAkisNo.Text + "\\";
                Dtf dtf = new Dtf(LblIsAkisNo.Text.ConInt(), TalepEden.Text, LblKayitTarihi.Value, donem, CmbButceKodu.Text, abfNo, LblBolgeAdi.Text, projeKodu, garantiDurumu, CmbIsKategorisi.Text, TxtIsinTanimi.Text.ToUpper(), stokNo, tanim, seriNo, CmbOnarimYeri.Text, CmbAltYukleniciFirma.Text, LblFirmaSorumlusu.Text, DtgIsinVerildigiTarih.Value, dosyaYolu, revizyon);

                string mesaj = dtfManager.Add(dtf);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TaslakKopyala();
                CreateWord();

                //mesaj = BildirimKayit();
                //if (mesaj != "OK")
                //{
                //    if (mesaj != "Server Ayarı Kapalı")
                //    {
                //        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                mesaj = dtfManager.DtfKayitDurum(malzemeId, CmbAltYukleniciFirma.Text);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DtsLogKayit();
                MalzemeTeslimTesellumUpdate();
                IsAkisNo();
                Temizle();

                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void DtsLogKayit()
        {
            string islem = LblBolgeAdi.Text + " bölgesine ait " + abfNo + " form numaralı arızanın " + LblIsAkisNo.Text + " İş Akış Numaralı DTF kaydı yapılmıştır.";
            DtsLog dtsLog = new DtsLog(infos[1].ToString(), DateTime.Now, "DTF KAYIT", islem);
            dtsLogManager.Add(dtsLog);
        }

        void MalzemeHazirlamaControl2()
        {
            DepoMiktar depoMiktar = depoMiktarManager.StokSeriLotKontrol(stokNo, "2600", seriNo, lotNo, revizyon);

            if (depoMiktar != null)
            {
                abfMalzemeManager.TeminBilgisi(depoMiktar.Id, dusulenYer + " DEPOYA GÖNDERİLDİ", infos[1].ToString(), "DEPODAN DEPOYA İADE (AMBAR)");
            }

        }
        public void CmbDepoCekilen()
        {
            CmbDepoAdresi.DataSource = depoKayitManagercs.GetList();
            CmbDepoAdresi.ValueMember = "Id";
            CmbDepoAdresi.DisplayMember = "DepoAdi";
            CmbDepoAdresi.SelectedValue = 0;
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

        string LokasyonBul2500(string stokNo, string seriLotNo, string revizyon, string takipDurumu, int miktar)
        {
            DepoMiktar depoBilgileri = null;
            depoBilgileri = depoMiktarManager.GetBarkodLokasyonBul2500(stokNo, seriLotNo, revizyon, takipDurumu, miktar);
            if (depoBilgileri == null)
            {
                Malzeme malzeme = malzemeManager.Get(stokNo);

                DepoMiktar depoMiktar = new DepoMiktar(stokNo, malzeme.Tanim, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), "2500", "BAKIM ONARIM (GİDEN)", "100", miktar, "MALZEMENİN MEVCUT ARIZADAN DEPOYA DÜŞÜMÜ YAPILMIŞTIR.");

                depoMiktarManager.Add(depoMiktar);


                StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs("101-DEPODAN DEPOYA İADE", stokNo, tanim, birim, DateTime.Now, abfNo, "", "", "2500", "ASELSAN UGES", "100", miktar, infos[1].ToString(), "MALZEMENİN MEVCUT ARIZADAN DEPOYA DÜŞÜMÜ YAPILMIŞTIR.", seriNo, lotNo, revizyon);

                stokGirisCikisManager.Add(stokGirisCıkıs);
            }

            depoBilgileri = depoMiktarManager.GetBarkodLokasyonBul2500(stokNo, seriLotNo, revizyon, takipDurumu, miktar);
            depoLokasyon = depoBilgileri.DepoLokasyon;
            cekilenDepoAdi = depoBilgileri.DepoAdresi;
            return depoBilgileri.DepoNo;
        }

        void DepodanAltYukleniciyeDusum()
        {
            MalzemeHazirlamaControl2();
            string lokasyon = "";
            if (seriNo == "N/A")
            {
                lokasyon = LokasyonBul2500(stokNo, lotNo, revizyon, takipTuru, miktar);
            }
            else
            {
                lokasyon = LokasyonBul2500(stokNo, seriNo, revizyon, takipTuru, miktar);
            }

            DepoMiktar depoMiktar = depoMiktarManager.StokSeriLotKontrol(stokNo, LblDepoNo.Text, seriNo, lotNo, revizyon);
            if (depoMiktar == null)
            {
                DepoMiktar depoMiktardepo = new DepoMiktar(stokNo, tanim, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), LblDepoNo.Text, CmbDepoAdresi.Text, "100", miktar, "MALZEME ALT YÜKLENİCİ FİRMAYA DEPO DÜŞÜMÜ YAPILMIŞTIR.");
                depoMiktarManager.Add(depoMiktardepo);
            }

            dusulenMiktar = miktar;

            string depoNoDusulen2 = LblDepoNo.Text; // düşülen
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


            StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs("101-DEPODAN DEPOYA İADE", stokNo, tanim, birim, DateTime.Now, depoNoCekilen2, cekilenDepoAdi, cekilenDepoLokasyon, depoNoDusulen2, CmbDepoAdresi.Text, "100", miktar, infos[1].ToString(), "MALZEME ALT YÜKLENİCİ FİRMAYA DEPO DÜŞÜMÜ YAPILMIŞTIR.", seriNo, lotNo, revizyon);

            stokGirisCikisManager.Add(stokGirisCıkıs);
        }

        void MalzemeTeslimTesellumUpdate()
        {
            Malzeme malzeme = malzemeManager.Get(stokNo);
            if (malzeme != null)
            {
                takipTuru = malzeme.TakipDurumu;
                tedarikTuru = malzeme.TedarikTuru;
                if (takipTuru == "SERİ NO")
                {
                    lotNo = "N/A";
                }
                else
                {
                    lotNo = seriNo;
                    seriNo = "N/A";
                }

                dusulenYer = LblDepoNo.Text;
                DepodanAltYukleniciyeDusum();
            }

            abfMalzemeManager.MalzemeTeslimBilgisiUpdate(malzemeId, "ALT YÜKLENİCİ FİRMADA");

            AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(malzemeId, "250 - ALT YÜKLENİCİYE GİDECEK MALZEME", stokNo, seriNo, revizyon, "SÖKÜLEN");

            AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(malzemeId, "ALT YÜKLENİCİ FİRMADA", DateTime.Now, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, stokNo, seriNo, revizyon);
            abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

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
        void CreateWord()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\BAKIM ONARIM\";
            string anadosya = @"Z:\DTS\BAKIM ONARIM\DTF\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(anadosya))
            {
                Directory.CreateDirectory(anadosya);
            }
            dosyaYolu = anadosya + LblIsAkisNo.Text + "\\";
            Directory.CreateDirectory(dosyaYolu);

            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            object filePath = taslakYolu;

            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["IsAkisNo"].Range.Text = LblIsAkisNo.Text;
            wBookmarks["AbfNo"].Range.Text = abfNo;
            wBookmarks["BolgeAdi"].Range.Text = LblBolgeAdi.Text;
            wBookmarks["ProjeKodu"].Range.Text = projeKodu;
            wBookmarks["AltYukleniciFirma"].Range.Text = CmbAltYukleniciFirma.Text;
            wBookmarks["GarantiDurumu"].Range.Text = garantiDurumu;
            wBookmarks["FirmaSorumlusu"].Range.Text = LblFirmaSorumlusu.Text;
            wBookmarks["StokNo"].Range.Text = stokNo;
            wBookmarks["Tanim"].Range.Text = tanim;
            wBookmarks["ButceKodu"].Range.Text = CmbButceKodu.Text;
            wBookmarks["SeriNo"].Range.Text = seriNo;
            if (CmbOnarimYeri.Text == "YERİNDE ONARIM")
            {
                wBookmarks["YerindeOnarim"].Range.Text = "X";
            }
            else
            {
                wBookmarks["FirmadaOnarim"].Range.Text = "X";
            }

            wBookmarks["IsinTanimi"].Range.Text = TxtIsinTanimi.Text;
            //wBookmarks["Malzeme"].Range.Text = malzeme;
            wBookmarks["TalebiOlusturan"].Range.Text = TalepEden.Text;
            wBookmarks["IsinVerildigiTarih"].Range.Text = DtgIsinVerildigiTarih.Value.ToString("dd/MM/yyyy");
            wBookmarks["Tarih"].Range.Text = DtgIsinVerildigiTarih.Value.ToString("dd/MM/yyyy");
            wBookmarks["Tarih2"].Range.Text = DtgIsinVerildigiTarih.Value.ToString("dd/MM/yyyy");

            wDoc.SaveAs2(dosyaYolu + LblIsAkisNo.Text + ".docx");
            wDoc.Close();
            wApp.Quit(false);

            try
            {
                Directory.Delete(yol, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                File.Delete(taslakYolu);
            }
        }
        void TaslakKopyala()
        {
            string root = @"C:\DTS";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(yol))
            {
                Directory.CreateDirectory(yol);
            }

            File.Copy(kaynak + "MP-FR-019 DOĞRUDAN TEMİN FORMU REV (00).docx", yol + "MP-FR-019 DOĞRUDAN TEMİN FORMU REV (00).docx");

            taslakYolu = yol + "MP-FR-019 DOĞRUDAN TEMİN FORMU REV (00).docx";
        }

        private void BtnIsinTanimiEkle_Click(object sender, EventArgs e)
        {
            comboAd = "IS_KATEGORISI";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }
        void Temizle()
        {
            CmbButceKodu.SelectedIndex = -1; CmbIsKategorisi.SelectedIndex = -1; TxtIsinTanimi.Clear(); CmbOnarimYeri.Text = ""; CmbAltYukleniciFirma.SelectedIndex = -1;
            DataDisplay();
            IsAkisNo();
            TalebiOlusturan();
            IsKategorisi();
            AltYukleniciFirma();
        }
    }
}
