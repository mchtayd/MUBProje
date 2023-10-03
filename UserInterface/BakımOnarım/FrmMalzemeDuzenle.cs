using Business.Concreate.BakimOnarim;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using Entity.BakimOnarim;
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

namespace UserInterface.BakımOnarım
{
    public partial class FrmMalzemeDuzenle : Form
    {
        MalzemeKayitManager malzemeKayitManager;
        MalzemeManager malzemeManager;
        AbfMalzemeManager abfMalzemeManager;
        public int benzersizId;
        int deleteId;

        //List<MalzemeKayit> malzemeKayits;
        List<Malzeme> malzemes;
        List<Malzeme> malzemesFiltired;
        //List<MalzemeKayit> malzemeKayitsFiltired;
        List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
        int ilkSayi = 0;

        public FrmMalzemeDuzenle()
        {
            InitializeComponent();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
        }

        private void BtnMalzemeDuzenle_Load(object sender, EventArgs e)
        {
            MalzemeList();
            AbfMalzemeDisplay();
        }
        void MalzemeList()
        {
            malzemes = malzemeManager.GetList();
            malzemesFiltired = malzemes;
            dataBinder.DataSource = malzemes.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["StokNo"].HeaderText = "STOK NO";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["Birim"].HeaderText = "BİRİM";
            DtgList.Columns["TedarikciFirma"].HeaderText = "TEDARİKÇİ FİRMA";
            DtgList.Columns["OnarimDurumu"].HeaderText = "MALZEME ONARIM DURUMU";
            DtgList.Columns["OnarimYeri"].HeaderText = "MALZEME ONARIM YERİ";
            DtgList.Columns["TedarikTuru"].HeaderText = "TEDARİK TÜRÜ";
            DtgList.Columns["ParcaSinifi"].HeaderText = "PARÇA SINIFI";
            DtgList.Columns["AlternatifParca"].Visible = false;
            DtgList.Columns["Aciklama"].Visible = false;
            DtgList.Columns["DosyaYolu"].Visible = false;
            DtgList.Columns["SistemStokNo"].Visible = false;
            DtgList.Columns["SistemTanimi"].Visible = false;
            DtgList.Columns["SistemSorumlusu"].Visible = false;
            DtgList.Columns["IslemYapan"].Visible = false;
            DtgList.Columns["TakipDurumu"].Visible = false;
            DtgList.Columns["UstStok"].Visible = false;
            DtgList.Columns["UstTanim"].Visible = false;
            DtgList.Columns["BenzersizId"].Visible = false;
        }
        void AbfMalzemeDisplay()
        {
            abfMalzemes = abfMalzemeManager.GetList(benzersizId);
            if (abfMalzemes.Count == 0)
            {
                return;
            }
            DtgEklenecekMalzemeler.DataSource = abfMalzemes;
            ilkSayi = abfMalzemes.Count;
            MalzemeListEdit();

        }
        void MalzemeListEdit()
        {
            DtgEklenecekMalzemeler.Columns["Id"].Visible = false;
            DtgEklenecekMalzemeler.Columns["BenzersizId"].Visible = false;
            DtgEklenecekMalzemeler.Columns["SokulenStokNo"].HeaderText = "SÖKÜLEN STOK NO";
            DtgEklenecekMalzemeler.Columns["SokulenTanim"].HeaderText = "SÖKÜLEN TANIM";
            DtgEklenecekMalzemeler.Columns["SokulenSeriNo"].HeaderText = "SÖKÜLEN SERİ NO";
            DtgEklenecekMalzemeler.Columns["SokulenMiktar"].HeaderText = "SÖKÜLEN MİKTAR";
            DtgEklenecekMalzemeler.Columns["SokulenBirim"].HeaderText = "SÖKÜLEN BİRİM";
            DtgEklenecekMalzemeler.Columns["SokulenCalismaSaati"].HeaderText = "SÖKÜLEN ÇALIŞMA SAATİ";
            DtgEklenecekMalzemeler.Columns["SokulenRevizyon"].HeaderText = "SÖKÜLEN REVİZYON";
            DtgEklenecekMalzemeler.Columns["CalismaDurumu"].HeaderText = "ÇALIŞMA DURUMU";
            DtgEklenecekMalzemeler.Columns["FizikselDurum"].HeaderText = "FİZİKSEL DURUM";
            DtgEklenecekMalzemeler.Columns["YapilacakIslem"].HeaderText = "YAPILACAK İŞLEM";
            DtgEklenecekMalzemeler.Columns["TakilanStokNo"].HeaderText = "TAKILAN STOK NO";
            DtgEklenecekMalzemeler.Columns["TakilanTanim"].HeaderText = "TAKILAN TANIM";
            DtgEklenecekMalzemeler.Columns["TakilanMiktar"].HeaderText = "TAKILAN MİKTAR";
            DtgEklenecekMalzemeler.Columns["TakilanBirim"].HeaderText = "TAKILAN BİRİM";
            DtgEklenecekMalzemeler.Columns["TakilanSeriNo"].HeaderText = "TAKILAN SERİ NO";
            DtgEklenecekMalzemeler.Columns["TakilanCalismaSaati"].HeaderText = "TAKILAN ÇALIŞMA SAATİ";
            DtgEklenecekMalzemeler.Columns["TakilanRevizyon"].HeaderText = "TAKILAN REVİZYON";
            DtgEklenecekMalzemeler.Columns["TeminDurumu"].Visible = false;
            DtgEklenecekMalzemeler.Columns["AbfNo"].Visible = false;
            DtgEklenecekMalzemeler.Columns["AbTarihSaat"].Visible = false;
            DtgEklenecekMalzemeler.Columns["TemineAtilamTarihi"].Visible = false;
            DtgEklenecekMalzemeler.Columns["MalzemeDurumu"].Visible = false;
            DtgEklenecekMalzemeler.Columns["MalzemeIslemAdimi"].Visible = false;
            DtgEklenecekMalzemeler.Columns["SokulenTeslimDurum"].Visible = false;
            DtgEklenecekMalzemeler.Columns["BolgeAdi"].Visible = false;
            DtgEklenecekMalzemeler.Columns["BolgeSorumlusu"].Visible = false;
            DtgEklenecekMalzemeler.Columns["YerineMalzemeTakilma"].HeaderText = "YERİNE MALZEME TAKILDI MI?";

        }
        string stokNo, tanim, birim;
        private void DtgList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            stokNo = DtgList.CurrentRow.Cells["Stokno"].Value.ToString();
            tanim = DtgList.CurrentRow.Cells["Tanim"].Value.ToString();
            birim = DtgList.CurrentRow.Cells["Birim"].Value.ToString();
            AbfMalzeme abfMalzeme = new AbfMalzeme(0, benzersizId, stokNo, tanim, "", 1, birim, 0, "", "", "", "", "", "", "", 0, "", 0, "", "", "", "", "", "","","");

            abfMalzemes.Add(abfMalzeme);
            DtgEklenecekMalzemeler.DataSource = null;
            DtgEklenecekMalzemeler.DataSource = abfMalzemes;
            MalzemeListEdit();
        }

        private void BtnSiparisKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = abfMalzemeManager.Delete(benzersizId);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int index = 0;
                foreach (DataGridViewRow item in DtgEklenecekMalzemeler.Rows)
                {

                    if (ilkSayi != DtgEklenecekMalzemeler.RowCount)
                    {
                        if (index < ilkSayi)
                        {
                            AbfMalzeme abfMalzeme = new AbfMalzeme(item.Cells["Id"].Value.ConInt(), benzersizId, item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenTanim"].Value.ToString(),
                                item.Cells["SokulenSeriNo"].Value.ToString(), item.Cells["SokulenMiktar"].Value.ConInt(), item.Cells["SokulenBirim"].Value.ToString(), item.Cells["SokulenCalismaSaati"].Value.ConDouble(), item.Cells["SokulenRevizyon"].Value.ToString(), item.Cells["CalismaDurumu"].Value.ToString(), item.Cells["FizikselDurum"].Value.ToString(), item.Cells["YapilacakIslem"].Value.ToString(), item.Cells["TakilanStokNo"].Value.ToString(), item.Cells["TakilanTanim"].Value.ToString(), item.Cells["TakilanSeriNo"].Value.ToString(), item.Cells["TakilanMiktar"].Value.ConInt(), item.Cells["TakilanBirim"].Value.ToString(), item.Cells["TakilanCalismaSaati"].Value.ConDouble(), item.Cells["TakilanRevizyon"].Value.ToString(), item.Cells["TeminDurumu"].Value.ToString(), item.Cells["MalzemeIslemAdimi"].Value.ToString(), item.Cells["SokulenTeslimDurum"].Value.ToString(), item.Cells["YerineMalzemeTakilma"].Value.ToString(), item.Cells["DosyaYolu"].Value.ToString(), item.Cells["AltYukleniciKayit"].Value.ToString(), item.Cells["TakilanTeslimDurum"].Value.ToString());

                            abfMalzemeManager.AddSokulenTakilan(abfMalzeme);
                        }
                        else
                        {
                            if (ilkSayi == 0)
                            {
                                AbfMalzeme abfMalzeme = new AbfMalzeme(item.Cells["Id"].Value.ConInt(), benzersizId, item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenTanim"].Value.ToString(),
                                item.Cells["SokulenSeriNo"].Value.ToString(), item.Cells["SokulenMiktar"].Value.ConInt(), item.Cells["SokulenBirim"].Value.ToString(), item.Cells["SokulenCalismaSaati"].Value.ConDouble(), item.Cells["SokulenRevizyon"].Value.ToString(), item.Cells["CalismaDurumu"].Value.ToString(), item.Cells["FizikselDurum"].Value.ToString(), item.Cells["YapilacakIslem"].Value.ToString(), item.Cells["TakilanStokNo"].Value.ToString(), item.Cells["TakilanTanim"].Value.ToString(), item.Cells["TakilanSeriNo"].Value.ToString(), item.Cells["TakilanMiktar"].Value.ConInt(), item.Cells["TakilanBirim"].Value.ToString(), item.Cells["TakilanCalismaSaati"].Value.ConDouble(), item.Cells["TakilanRevizyon"].Value.ToString(), "KONTROL EDİLMEDİ", "", "ARA DEPO (İADE)", item.Cells["YerineMalzemeTakilma"].Value.ToString(), "", item.Cells["AltYukleniciKayit"].Value.ToString(), item.Cells["TakilanTeslimDurum"].Value.ToString());

                                abfMalzemeManager.AddSokulenTakilan(abfMalzeme);
                            }
                            else
                            {
                                if (item.Cells["SokulenStokNo"].Value == null)
                                {
                                    AbfMalzeme abfMalzeme = new AbfMalzeme(item.Cells["Id"].Value.ConInt(), benzersizId, "", "", "", 0, "", 0, "", "", "", "", item.Cells["TakilanStokNo"].Value.ToString(), item.Cells["TakilanTanim"].Value.ToString(), item.Cells["TakilanSeriNo"].Value.ToString(), item.Cells["TakilanMiktar"].Value.ConInt(), item.Cells["TakilanBirim"].Value.ToString(), item.Cells["TakilanCalismaSaati"].Value.ConDouble(), item.Cells["TakilanRevizyon"].Value.ToString(), "KONTROL EDİLMEDİ", "", "ARA DEPO (İADE)", item.Cells["YerineMalzemeTakilma"].Value.ToString(), "", item.Cells["AltYukleniciKayit"].Value.ToString(),
                                        item.Cells["TakilanTeslimDurum"].Value.ToString());

                                    abfMalzemeManager.AddSokulenTakilan(abfMalzeme);
                                }

                                if (item.Cells["TakilanStokNo"].Value == null)
                                {
                                    AbfMalzeme abfMalzeme = new AbfMalzeme(item.Cells["Id"].Value.ConInt(), benzersizId, item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenTanim"].Value.ToString(),
                                item.Cells["SokulenSeriNo"].Value.ToString(), item.Cells["SokulenMiktar"].Value.ConInt(), item.Cells["SokulenBirim"].Value.ToString(), item.Cells["SokulenCalismaSaati"].Value.ConDouble(), item.Cells["SokulenRevizyon"].Value.ToString(), item.Cells["CalismaDurumu"].Value.ToString(), item.Cells["FizikselDurum"].Value.ToString(), item.Cells["YapilacakIslem"].Value.ToString(), "", "", "", 0, "", 0, "", "KONTROL EDİLMEDİ", "", "ARA DEPO (İADE)", item.Cells["YerineMalzemeTakilma"].Value.ToString(), "", item.Cells["AltYukleniciKayit"].Value.ToString(),"");

                                    abfMalzemeManager.AddSokulenTakilan(abfMalzeme);
                                }

                                if (item.Cells["TakilanStokNo"].Value != null && item.Cells["SokulenStokNo"].Value != null)
                                {
                                    AbfMalzeme abfMalzeme = new AbfMalzeme(item.Cells["Id"].Value.ConInt(), benzersizId, item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenTanim"].Value.ToString(),
                                item.Cells["SokulenSeriNo"].Value.ToString(), item.Cells["SokulenMiktar"].Value.ConInt(), item.Cells["SokulenBirim"].Value.ToString(), item.Cells["SokulenCalismaSaati"].Value.ConDouble(), item.Cells["SokulenRevizyon"].Value.ToString(), item.Cells["CalismaDurumu"].Value.ToString(), item.Cells["FizikselDurum"].Value.ToString(), item.Cells["YapilacakIslem"].Value.ToString(), item.Cells["TakilanStokNo"].Value.ToString(), item.Cells["TakilanTanim"].Value.ToString(), item.Cells["TakilanSeriNo"].Value.ToString(), item.Cells["TakilanMiktar"].Value.ConInt(), item.Cells["TakilanBirim"].Value.ToString(), item.Cells["TakilanCalismaSaati"].Value.ConDouble(), item.Cells["TakilanRevizyon"].Value.ToString(), "KONTROL EDİLMEDİ", "", "ARA DEPO (İADE)", item.Cells["YerineMalzemeTakilma"].Value.ToString(), "", item.Cells["AltYukleniciKayit"].Value.ToString(), item.Cells["TakilanTeslimDurum"].Value.ToString());

                                    abfMalzemeManager.AddSokulenTakilan(abfMalzeme);
                                }

                            }

                        }
                        index++;
                    }
                    else
                    {
                        AbfMalzeme abfMalzeme = new AbfMalzeme(item.Cells["Id"].Value.ConInt(), benzersizId, item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenTanim"].Value.ToString(),
                                item.Cells["SokulenSeriNo"].Value.ToString(), item.Cells["SokulenMiktar"].Value.ConInt(), item.Cells["SokulenBirim"].Value.ToString(), item.Cells["SokulenCalismaSaati"].Value.ConDouble(), item.Cells["SokulenRevizyon"].Value.ToString(), item.Cells["CalismaDurumu"].Value.ToString(), item.Cells["FizikselDurum"].Value.ToString(), item.Cells["YapilacakIslem"].Value.ToString(), item.Cells["TakilanStokNo"].Value.ToString(), item.Cells["TakilanTanim"].Value.ToString(), item.Cells["TakilanSeriNo"].Value.ToString(), item.Cells["TakilanMiktar"].Value.ConInt(), item.Cells["TakilanBirim"].Value.ToString(), item.Cells["TakilanCalismaSaati"].Value.ConDouble(), item.Cells["TakilanRevizyon"].Value.ToString(), item.Cells["TeminDurumu"].Value.ToString(), item.Cells["MalzemeIslemAdimi"].Value.ToString(), item.Cells["SokulenTeslimDurum"].Value.ToString(), item.Cells["YerineMalzemeTakilma"].Value.ToString(), item.Cells["DosyaYolu"].Value.ToString(), item.Cells["AltYukleniciKayit"].Value.ToString(), item.Cells["TakilanTeslimDurum"].Value.ToString());

                        abfMalzemeManager.AddSokulenTakilan(abfMalzeme);
                    }

                }

                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmArizaAcmaCalisma frmArizaAcmaCalisma = new FrmArizaAcmaCalisma();
                frmArizaAcmaCalisma.FillTools();
                frmArizaAcmaCalisma.id = benzersizId;
                this.Close();

            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteId = DtgEklenecekMalzemeler.CurrentRow.Cells["Id"].Value.ConInt();
            if (deleteId == 0)
            {
                MessageBox.Show("Lütfen Geçerli Bir Malzeme Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Malzeme Kaydını Silmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string messega = abfMalzemeManager.DeleteTekMalzemeSil(deleteId);
                if (messega != "OK")
                {
                    MessageBox.Show("Lütfen Geçerli Bir Malzeme Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Kayıt Başarıyla Silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AbfMalzemeDisplay();

            }

        }


        private void FrmMalzemeDuzenle_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmArizaAcmaCalisma frmArizaAcmaCalisma = new FrmArizaAcmaCalisma();
            frmArizaAcmaCalisma.id = benzersizId;
            frmArizaAcmaCalisma.FillTools();
        }


        private void TxtAbfFormNo_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtStokNo.Text;
            if (string.IsNullOrEmpty(isim))
            {
                malzemesFiltired = malzemes;
                dataBinder.DataSource = malzemes.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtStokNo.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemesFiltired.Where(x => x.StokNo.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            malzemesFiltired = malzemes;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void TxtTanim_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtTanim.Text;
            if (string.IsNullOrEmpty(isim))
            {
                malzemesFiltired = malzemes;
                dataBinder.DataSource = malzemes.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtTanim.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemesFiltired.Where(x => x.Tanim.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            malzemesFiltired = malzemes;
            TxtTop.Text = DtgList.RowCount.ToString();
        }
    }
}
