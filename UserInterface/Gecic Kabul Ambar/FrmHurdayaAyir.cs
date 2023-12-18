using Business.Concreate.BakimOnarim;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Office2010.Excel;
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
using UserInterface.STS;

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmHurdayaAyir : Form
    {
        public int benzersizId, takilanmiktar;
        public string sokulenstok, sokulentanim, sokulenbirim, sokulenSeriNo, sokulenRevizyon, takilanstok, takilantanim, takilanbirim, takilanSeriNo, takilanRevizyon;

        public object[] infos;
        AbfMalzemeManager abfMalzemeManager;
        AbfMalzemeIslemKayitManager abfMalzemeIslemKayitManager;
        public FrmHurdayaAyir()
        {
            InitializeComponent();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            abfMalzemeIslemKayitManager = AbfMalzemeIslemKayitManager.GetInstance();
        }

        private void FrmHurdayaAyir_Load(object sender, EventArgs e)
        {
            LblStokSokulen.Text = sokulenstok;
            LblTanimSokulen.Text = sokulentanim;
            LblMiktarSokulen.Text = takilanmiktar.ToString();
            LblBirimSokulen.Text = sokulenbirim;
            LblSeriLotNoSokulen.Text = sokulenSeriNo;
            LblRevizyonSokulen.Text = sokulenRevizyon;

        }
        private void TxtHurdaMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void TxtHurdaMiktar_TextChanged(object sender, EventArgs e)
        {
            if (TxtHurdaMiktar.Text.ConInt() > LblMiktarSokulen.Text.ConInt())
            {
                MessageBox.Show("Hurda edilecek miktar malzeme miktarından fazla olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtHurdaMiktar.Text = "";
                return;
            }

            LblSaglamMiktar.Text = (LblMiktarSokulen.Text.ConInt() - TxtHurdaMiktar.Text.ConInt()).ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtHurdaMiktar.Text=="")
            {
                MessageBox.Show("Lütfen hurdaya atılacak miktarı belirleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtHurdaMiktar.Text.ConInt() == LblMiktarSokulen.Text.ConInt())
            {
                MessageBox.Show("Malzemenin hepsini hurdaya atmak istiyorsanız Malzeme Teslim Yerini '900 - HURDA DEPO' seçerek devam ediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("İşlemleri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                AbfMalzeme abfMalzemeSokulen = new AbfMalzeme(benzersizId, LblStokSokulen.Text, LblTanimSokulen.Text, LblSeriLotNoSokulen.Text, TxtHurdaMiktar.Text.ConInt(), LblBirimSokulen.Text, 0, LblRevizyonSokulen.Text, "GAYRİ FAAL", "SÖKÜLDÜ", "DEĞİTİRİLECEK (HURDA EDİLECEK)");

                abfMalzemeManager.AddSokulen(abfMalzemeSokulen);
                AbfMalzeme abfMalzeme = abfMalzemeManager.GetBul(benzersizId, LblStokSokulen.Text, LblSeriLotNoSokulen.Text, LblRevizyonSokulen.Text, TxtHurdaMiktar.Text.ConInt());

                AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(abfMalzeme.Id, "900 - HURDA DEPO", DateTime.Now, infos[1].ToString(), 0, "SÖKÜLEN", LblStokSokulen.Text, LblSeriLotNoSokulen.Text, LblRevizyonSokulen.Text);
                abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                abfMalzemeManager.HurdaSaglamMiktarUpdate(abfMalzeme.Id, LblSaglamMiktar.Text.ConInt());

                FrmAltTakimTakip frmAltTakimTakip = (FrmAltTakimTakip)Application.OpenForms["FrmAltTakimTakip"];
                if (frmAltTakimTakip != null)
                {
                    frmAltTakimTakip.Yenilenecekler();
                }

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
