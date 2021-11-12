using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
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

namespace UserInterface.IdariIsler
{
    public partial class FrmCokluKonaklama : Form
    {
        KonaklamaKirilimManager konaklamaKirilimManager;
        public string konaklamaTuru = "ÇOKLU KONAKLAMA";
        public int konaklamaGun, guntl, geneltop;
        int outValue = 0, toplamGun, toplamGunTL;
        public int isAkisNo;
        public FrmCokluKonaklama()
        {
            InitializeComponent();
            konaklamaKirilimManager = KonaklamaKirilimManager.GetInstance();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void FrmCokluKonaklama_Load(object sender, EventArgs e)
        {
            geneltop = 0;
        }

        private void DtgIcerik_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
                {
                    if (DtgIcerik.Rows[e.RowIndex].Cells[0].Value == null || DtgIcerik.Rows[e.RowIndex].Cells[1].Value == null)
                    {
                        return;
                    }

                    if (int.TryParse(DtgIcerik.Rows[e.RowIndex].Cells[0].Value.ToString(), out outValue) &&
                        int.TryParse(DtgIcerik.Rows[e.RowIndex].Cells[1].Value.ToString(), out outValue))
                    {
                        guntl = DtgIcerik.Rows[e.RowIndex].Cells[0].Value.ConInt();
                        konaklamaGun = DtgIcerik.Rows[e.RowIndex].Cells[1].Value.ConInt();

                        int toplam = guntl * konaklamaGun;
                        DtgIcerik.Rows[e.RowIndex].Cells[2].Value = toplam;
                        toplamGun = 0;
                        toplamGunTL = 0;
                        geneltop = 0;

                        foreach (DataGridViewRow item in DtgIcerik.Rows)
                        {
                            toplamGun += item.Cells[0].Value.ConInt();
                            toplamGunTL += item.Cells[1].Value.ConInt();
                            geneltop += item.Cells[2].Value.ConInt();
                        }
                        LblKonaklamaGun.Text = toplamGun.ToString();
                        LblKonaklamaGunTl.Text = toplamGunTL.ToString();
                        LblGenelTop.Text = geneltop.ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
        void Temizle()
        {
            while (DtgIcerik.Rows.Count > 1)
            {
                DtgIcerik.Rows.RemoveAt(0);
            }
            LblKonaklamaGun.Text = "0";
            LblKonaklamaGunTl.Text = "0";
            LblGenelTop.Text = "0";
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgieri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                List<KonaklamaKirilim> konaklamaKirilims = new List<KonaklamaKirilim>();
                konaklamaKirilims = konaklamaKirilimManager.GetList(isAkisNo);
                if (konaklamaKirilims.Count>0)
                {
                    konaklamaKirilimManager.Delete(isAkisNo);
                }

                foreach (DataGridViewRow item in DtgIcerik.Rows)
                {
                    if (item.Cells["Toplam2"].Value.ConInt()==0)
                    {
                        break;
                    }
                    KonaklamaKirilim konaklama = new KonaklamaKirilim(isAkisNo, item.Cells["Gun2"].Value.ConInt(), item.Cells["GunTl2"].Value.ConInt(), item.Cells["Toplam2"].Value.ConInt());
                    konaklamaKirilimManager.Add(konaklama);

                }
                var form = (FrmYurtİciGorev)Application.OpenForms["FrmYurtİciGorev"];
                if (form != null)
                {
                    form.konaklamaTuru = konaklamaTuru;
                    form.TxtKonaklamaGunGun.Text = LblKonaklamaGun.Text;
                    form.TxtKonaklamGunTlGun.Text = LblKonaklamaGunTl.Text;
                    form.TxtKonaklamaToplamGun.Text = LblGenelTop.Text;
                    form.TxtKonaklamaGunGun.Enabled = false;
                    form.TxtKonaklamGunTlGun.Enabled = false;
                    form.TxtKonaklamaToplamGun.Enabled = false;
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir. Yurt İçi Görev İşlemlerine Devam Edebilirsiniz.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Temizle();
                this.Close();
            }

        }
    }
}
