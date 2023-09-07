using Business.Concreate.BakimOnarim;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Presentation;
using Entity.BakimOnarim;
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
    public partial class FrmSokulenMalzeme : Form
    {
        AbfMalzemeManager abfMalzemeManager;
        AbfMalzemeIslemKayitManager abfMalzemeIslemKayitManager;
        List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
        public int benzersizId = 0;
        int id = 0;
        public object[] infos;
        string stokNo, seriNo, revizyon = "";

        public FrmSokulenMalzeme()
        {
            InitializeComponent();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            abfMalzemeIslemKayitManager = AbfMalzemeIslemKayitManager.GetInstance();
        }

        private void FrmSokulenMalzeme_Load(object sender, EventArgs e)
        {
            AbfMalzemeDisplay();
        }
        void AbfMalzemeDisplay()
        {
            abfMalzemes = abfMalzemeManager.GetList(benzersizId);
            if (abfMalzemes.Count == 0)
            {
                return;
            }
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
            DtgEklenecekMalzemeler.Columns["SokulenTeslimDurum"].Visible = false;
            DtgEklenecekMalzemeler.Columns["BolgeAdi"].Visible = false;
            DtgEklenecekMalzemeler.Columns["BolgeSorumlusu"].Visible = false;

        }
        private void DtgEklenecekMalzemeler_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgEklenecekMalzemeler.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            id = DtgEklenecekMalzemeler.CurrentRow.Cells["Id"].Value.ConInt();
            CmbCalismaDurumu.Text= DtgEklenecekMalzemeler.CurrentRow.Cells["CalismaDurumu"].Value.ToString();
            CmbFizikselDurumu.Text = DtgEklenecekMalzemeler.CurrentRow.Cells["FizikselDurum"].Value.ToString();
            CmbYapilanIslem.Text = DtgEklenecekMalzemeler.CurrentRow.Cells["YapilacakIslem"].Value.ToString();
            stokNo = DtgEklenecekMalzemeler.CurrentRow.Cells["SokulenStokNo"].Value.ToString();
            seriNo = DtgEklenecekMalzemeler.CurrentRow.Cells["SokulenSeriNo"].Value.ToString();
            revizyon = DtgEklenecekMalzemeler.CurrentRow.Cells["SokulenRevizyon"].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri güncellemek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (id == 0)
                {
                    MessageBox.Show("Lütfen öncelikle bir malzeme seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string mesaj = abfMalzemeManager.SokulenMalzemeUpdate(CmbCalismaDurumu.Text, CmbFizikselDurumu.Text, CmbYapilanIslem.Text, id);
                AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(benzersizId, "ARA DEPO (İADE)", DateTime.Now, infos[1].ToString(), 0, "SÖKÜLEN", stokNo, seriNo, revizyon);
                abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (CmbFizikselDurumu.Text == "SÖKÜLDÜ")
                {
                    AbfMalzemeIslemKayit abfMalzemeIslemKayit2 = new AbfMalzemeIslemKayit(id, "ARA DEPO (İADE)", DateTime.Now, infos[1].ToString(), 0, "SÖKÜLEN", stokNo, seriNo, revizyon);
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit2);
                }

                MessageBox.Show("Bilgiler başarıyla güncellenmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id = 0;
                CmbCalismaDurumu.SelectedIndex = -1;
                CmbFizikselDurumu.SelectedIndex = -1;
                CmbYapilanIslem.SelectedIndex = -1;
                AbfMalzemeDisplay();
            }
        }
    }
}
