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
        AbfMalzemeManager abfMalzemeManager;
        public int benzersizId;
        int deleteId;

        List<MalzemeKayit> malzemeKayits;
        List<MalzemeKayit> malzemeKayitsFiltired;
        List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();

        public FrmMalzemeDuzenle()
        {
            InitializeComponent();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
        }

        private void BtnMalzemeDuzenle_Load(object sender, EventArgs e)
        {
            MalzemeList();
            AbfMalzemeDisplay();
        }
        void MalzemeList()
        {
            malzemeKayits = malzemeKayitManager.GetListMalzemeKayit();
            malzemeKayitsFiltired = malzemeKayits;
            dataBinder.DataSource = malzemeKayits.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Stokno"].HeaderText = "STOK NO";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["Birim"].HeaderText = "BİRİM";
            DtgList.Columns["Tedarikcifirma"].HeaderText = "TEDARİKÇİ FİRMA";
            DtgList.Columns["Malzemeonarimdurumu"].HeaderText = "MALZEME ONARIM DURUMU";
            DtgList.Columns["Malzemeonarımyeri"].HeaderText = "MALZEME ONARIM YERİ";
            DtgList.Columns["Malzemeturu"].HeaderText = "MALZEME TÜRÜ";
            DtgList.Columns["Malzemetakipdurumu"].HeaderText = "MALZEME TAKİP DURUMU";
            DtgList.Columns["Malzemekul"].Visible = false;
            DtgList.Columns["Aciklama"].Visible = false;
            DtgList.Columns["Dosyayolu"].Visible = false;
            DtgList.Columns["AlternatifMalzeme"].Visible = false;
            DtgList.Columns["SistemStokNo"].Visible = false;
            DtgList.Columns["SistemTanim"].Visible = false;
            DtgList.Columns["SistemPersonel"].Visible = false;
            DtgList.Columns["KayitDurumu"].Visible = false;
            DtgList.Columns["SeriNo"].Visible = false;
            DtgList.Columns["Durum"].Visible = false;
            DtgList.Columns["Revizyon"].Visible = false;
            DtgList.Columns["Miktar"].Visible = false;
            DtgList.Columns["TalepTarihi"].Visible = false;
            DtgList.Columns["DataTypeValue"].Visible = false;
        }
        void AbfMalzemeDisplay()
        {
            abfMalzemes = abfMalzemeManager.GetList(benzersizId);
            DtgEklenecekMalzemeler.DataSource = abfMalzemes;
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
        }
        string stokNo, tanim, birim;
        private void DtgList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            stokNo = DtgList.CurrentRow.Cells["Stokno"].Value.ToString();
            tanim = DtgList.CurrentRow.Cells["Tanim"].Value.ToString();
            birim = DtgList.CurrentRow.Cells["Birim"].Value.ToString();
            AbfMalzeme abfMalzeme = new AbfMalzeme(benzersizId, stokNo, tanim, "", 1, birim, 0, "", "", "", "");


            abfMalzemes.Add(abfMalzeme);
            DtgEklenecekMalzemeler.DataSource = null;
            DtgEklenecekMalzemeler.DataSource = abfMalzemes;
            MalzemeListEdit();
        }

        private void BtnSiparisKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                string mesaj = abfMalzemeManager.Delete(benzersizId);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (DataGridViewRow item in DtgEklenecekMalzemeler.Rows)
                {
                    AbfMalzeme abfMalzeme = new AbfMalzeme(benzersizId, item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenTanim"].Value.ToString(), 
                        item.Cells["SokulenSeriNo"].Value.ToString(), item.Cells["SokulenMiktar"].Value.ConInt(), item.Cells["SokulenBirim"].Value.ToString(), item.Cells["SokulenCalismaSaati"].Value.ConDouble(), item.Cells["SokulenRevizyon"].Value.ToString(), item.Cells["CalismaDurumu"].Value.ToString(), item.Cells["FizikselDurum"].Value.ToString(), item.Cells["YapilacakIslem"].Value.ToString());

                    abfMalzemeManager.AddSokulen(abfMalzeme);
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
            if (dr==DialogResult.Yes)
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

        private void DtgEklenecekMalzemeler_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
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
                malzemeKayitsFiltired = malzemeKayits;
                dataBinder.DataSource = malzemeKayits.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtStokNo.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemeKayitsFiltired.Where(x => x.Stokno.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            malzemeKayitsFiltired = malzemeKayits;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void TxtTanim_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtTanim.Text;
            if (string.IsNullOrEmpty(isim))
            {
                malzemeKayitsFiltired = malzemeKayits;
                dataBinder.DataSource = malzemeKayits.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtTanim.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemeKayitsFiltired.Where(x => x.Tanim.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            malzemeKayitsFiltired = malzemeKayits;
            TxtTop.Text = DtgList.RowCount.ToString();
        }
    }
}
