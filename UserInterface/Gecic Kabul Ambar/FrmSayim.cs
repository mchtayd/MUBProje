using Business.Concreate.BakimOnarim;
using Business.Concreate.Depo;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Entity.BakimOnarim;
using Entity;
using Entity.Depo;
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
using UserInterface.STS;
using Application = System.Windows.Forms.Application;
using Color = System.Drawing.Color;

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmSayim : Form
    {
        DepoKayitManagercs depoKayitManagercs;
        DepoKayitLokasyonManager depoKayitLokasyonManager;
        DepoMiktarManager depoMiktarManager;
        BarkodManager barkodManager;
        MalzemeManager malzemeManager;
        StokGirisCikisManager stokGirisCikisManager;
        List<Malzeme> malzemes = new List<Malzeme>();
        public object[] infos;
        bool start = true, miktarKontrol = false;
        int id, sayac, miktar, mevcutMiktar = 0;
        string readedBarcode, takipdurumu, teminTuru, depoNoDusulen, malzemeYeri, islemTuru, stokNo, tanim, seriNo, lotNo, revizyon, birim, depoAdresi;



        public FrmSayim()
        {
            InitializeComponent();
            depoKayitManagercs = DepoKayitManagercs.GetInstance();
            depoKayitLokasyonManager = DepoKayitLokasyonManager.GetInstance();
            barkodManager = BarkodManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
            depoMiktarManager = DepoMiktarManager.GetInstance();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
        }

        private void CmbSokulenStokNo_TextChanged(object sender, EventArgs e)
        {
            if (CmbSokulenStokNo.Text == "")
            {
                TxtTanim.Clear();
            }
            else
            {
                foreach (Malzeme item in malzemes)
                {
                    if (CmbSokulenStokNo.Text == item.StokNo)
                    {
                        TxtTanim.Text = item.Tanim;
                    }
                }
            }
        }

        private void TxtMiktarManuel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtMiktarManuel_TextChanged(object sender, EventArgs e)
        {
            if (CmbSokulenStokNo.Text == "")
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

                if (takipdurumu == "LOT NO")
                {
                    AdvMalzemeOnizleme.Rows[sonSatir].Cells["Rev"].Value = "+";
                    break;
                }
                else
                {
                    AdvMalzemeOnizleme.Rows[sonSatir].Cells["Rev"].Value = "";
                }
            }
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)AdvMalzemeOnizleme.Columns["Remove"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;
        }

        private void AdvMalzemeOnizleme_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                AdvMalzemeOnizleme.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void BtnListEkle_Click(object sender, EventArgs e)
        {
            if (AdvMalzemeOnizleme.RowCount == 0)
            {
                MessageBox.Show("Lütfen Öncelikle malzeme listesini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TxtBirimFiyatManuel.Text == "")
            {
                TxtBirimFiyatManuel.Text = "0";
            }

            depoNoDusulen = CmbDepoNo.Text;
            malzemeYeri = TxtMalzemeYeri.Text;

            foreach (DataGridViewRow item in AdvMalzemeOnizleme.Rows)
            {
                int sirano = item.Cells["SiraNo"].Value.ConInt();


                DtgList.Rows.Add();
                int sonSatir = DtgList.RowCount - 1;

                DtgList.Rows[sonSatir].Cells["Column18"].Value = sirano;
                DtgList.Rows[sonSatir].Cells["Column1"].Value = TxtBirimFiyatManuel.Text.ConDouble();
                DtgList.Rows[sonSatir].Cells["Column13"].Value = LblIslemTuru.Text;
                DtgList.Rows[sonSatir].Cells["Column2"].Value = CmbSokulenStokNo.Text;
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

                DtgList.Rows[sonSatir].Cells["Column15"].Value = CmbDepoNo.Text; // DÜŞÜLEN DEPO
                DtgList.Rows[sonSatir].Cells["Column16"].Value = CmbAdres.Text;
                DtgList.Rows[sonSatir].Cells["Column17"].Value = TxtMalzemeYeri.Text;
                DtgList.Rows[sonSatir].Cells["Column7"].Value = ""; // ÇEKİLEN DEPO
                DtgList.Rows[sonSatir].Cells["Column8"].Value = "";
                DtgList.Rows[sonSatir].Cells["Column9"].Value = "";
                //DtgList.Rows[sonSatir].Cells["Column18"].Value = ""; // ABF FORM NO
                DtgList.Rows[sonSatir].Cells["Column19"].Value = ""; // TALEP EDEN PERSONEL

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

        private void CmbSokulenStokNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }

            Malzeme malzemeKayit = malzemeManager.Get(CmbSokulenStokNo.Text);

            if (malzemeKayit == null)
            {
                TxtTanim.Text = "";
                return;
            }
            TxtTanim.Text = malzemeKayit.Tanim;
            takipdurumu = malzemeKayit.TakipDurumu;
            if (takipdurumu == "LOT NO")
            {
                AdvMalzemeOnizleme.Columns["SeriLotNo"].HeaderText = "LOT NO";
                //AdvMalzemeOnizleme.Columns["Remove"].Visible = false;
            }
            else
            {
                AdvMalzemeOnizleme.Columns["SeriLotNo"].HeaderText = "SERİ NO";
                //AdvMalzemeOnizleme.Columns["Remove"].Visible = true;
            }
        }

        private void FrmSayim_Load(object sender, EventArgs e)
        {
            CmbDepo();
            StokBilgileri();
            LblSayimYili.Text = DateTime.Now.ToString("yyyy");
            start = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSayim"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void StokBilgileri()
        {
            malzemes = malzemeManager.GetList();
            CmbSokulenStokNo.DataSource = malzemes;
            CmbSokulenStokNo.ValueMember = "Id";
            CmbSokulenStokNo.DisplayMember = "StokNo";
            CmbSokulenStokNo.SelectedValue = 0;
        }

        public void CmbDepo()
        {
            CmbDepoNo.DataSource = depoKayitManagercs.GetList();
            CmbDepoNo.ValueMember = "Id";
            CmbDepoNo.DisplayMember = "Depo";
            CmbDepoNo.SelectedValue = 0;
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

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtBarkod.Clear();
            DtgList.Rows.Clear();
            CmbDepoNo.Text = ""; CmbAdres.Text = ""; TxtMalzemeYeri.Text = ""; TxtAciklama.Clear();

            CmbDepoNo.SelectedIndex = -1;
            CmbAdres.Clear();
            TxtMalzemeYeri.SelectedIndex = -1;
            TxtAciklama.Clear();
            DtgList.Rows.Clear();
            LblToplam.Text = "00";
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
                    birim = item.Cells["Column5"].Value.ToString();
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
                        DepoMiktar depoMiktar = new DepoMiktar(stokNo, tanim, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), depoNoDusulen, depoAdresi, item.Cells["Column17"].Value.ToString(), mevcutMiktar, item.Cells["Column14"].Value.ToString(), LblSayimYili.Text);
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
                        StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs(islemTuru, stokNo, tanim, item.Cells["Column5"].Value.ToString(), item.Cells["Column6"].Value.ConDate(), item.Cells["Column7"].Value.ToString(), item.Cells["Column8"].Value.ToString(), item.Cells["Column9"].Value.ToString(), item.Cells["Column15"].Value.ToString(), item.Cells["Column16"].Value.ToString(), item.Cells["Column17"].Value.ToString(), miktar, item.Cells["Column19"].Value.ToString(), item.Cells["Column14"].Value.ToString(), item.Cells["Column10"].Value.ToString(), item.Cells["Column12"].Value.ToString(), item.Cells["Column11"].Value.ToString(), LblSayimYili.Text);
                        stokGirisCikisManager.Add(stokGirisCıkıs);
                        stokGirisCikisManager.DepoBirimFiyat(item.Cells["Column1"].Value.ConDouble(), stokNo);
                    }
                }

                MessageBox.Show("Bilgileri Başarıyla Kaydedişmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                start = true;
                LblToplam.Text = "0";
                TxtBarkod.Clear();
                DtgList.Rows.Clear();
                start = false;
            }
        }

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
            }
        }

        private void TmrBarcode_Tick(object sender, EventArgs e)
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

            string miktarKontrol = MiktarKontrol();

            if (miktarKontrol != "OK")
            {
                TmrBarcode.Stop();
                MessageBox.Show(miktarKontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtBarkod.Clear();
                return;
            }
            if (CmbStokNo.Text == "")
            {
                TmrBarcode.Stop();
                MessageBox.Show("Bu malzeme için yeniden barkod oluşturmanız gerekmektedir!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtBarkod.Clear();
                return;
            }
            if (CmbStokNo.Text != "00")
            {
                //sirano++;
                DtgList.Rows.Add();
                int sonSatir = DtgList.RowCount - 1;

                //DtgList.Rows[sonSatir].Cells["Column1"].Value = sirano;
                DtgList.Rows[sonSatir].Cells["Column13"].Value = LblIslemTuru.Text;
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
                }

                DtgList.Rows[sonSatir].Cells["Column5"].Value = LblBirim.Text;
                DtgList.Rows[sonSatir].Cells["Column6"].Value = DtTarih.Value;
                DtgList.Rows[sonSatir].Cells["Column14"].Value = TxtAciklama.Text;

                if (LblIslemTuru.Text == "100-YENİ DEPO GİRİŞİ")
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
                TxtBarkod.Clear();
            }
            Hesapla();

            TxtBarkod.Clear();
            TmrBarcode.Stop();

            TxtMiktar.Text = "1";
        }

        string Control()
        {
            if (TxtAciklama.Text == "")
            {
                return "Lütfen Açıklama bilgisini doldurunuz!";
            }

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
            return "OK";
        }

        string MiktarKontrol()
        {
            depoNoDusulen = CmbDepoNo.Text;
            malzemeYeri = TxtMalzemeYeri.Text;
            return "OK";
        }
        void Hesapla()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgList.Rows[i].Cells["Column4"].Value);
            }
            LblToplam.Text = toplam.ToString();
        }
        private void CmbDusumTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbDusumTuru.SelectedIndex == 0)
            {
                GrbBarkod.Visible = true;
                GrbManuelStok.Visible = false;
            }
            if (CmbDusumTuru.SelectedIndex == 1)
            {
                GrbManuelStok.Visible = true;
                GrbBarkod.Visible = false;
            }
        }
        private void CmbStokManuel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            if (CmbSokulenStokNo.Text == "")
            {
                return;
            }
            FillTools();
        }

        void FillTools()
        {
            id = CmbSokulenStokNo.SelectedValue.ConInt();
            Malzeme malzeme = malzemeManager.Get(CmbSokulenStokNo.Text);
            TxtTanim.Text = malzeme.Tanim;
            CmbBirim.Text = malzeme.Birim;
            takipdurumu = malzeme.TakipDurumu;
            teminTuru = malzeme.TedarikTuru;
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
        }

        private void silToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int index = -1;

            index = DtgList.CurrentRow.Index;
            if (index == -1)
            {
                MessageBox.Show("Lütfen öncelikle silmek istedğiniz kaydı seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgList.Rows.RemoveAt(index);
            Hesapla();
        }

    }
}
