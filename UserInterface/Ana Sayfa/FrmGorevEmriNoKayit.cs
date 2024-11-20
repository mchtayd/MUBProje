using Business.Concreate.AnaSayfa;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity.AnaSayfa;
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

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmGorevEmriNoKayit : Form
    {
        GorevEmriNoManager gorevEmriNoManager;
        SistemUyariManager sistemUyariManager;
        GorevEmriNo gorevEmriNo = null;
        public FrmGorevEmriNoKayit()
        {
            InitializeComponent();
            gorevEmriNoManager = GorevEmriNoManager.GetInstance();
            sistemUyariManager = SistemUyariManager.GetInstance();
        }

        private void FrmGorevEmriNoKayit_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        void DataDisplay()
        {
            gorevEmriNo = gorevEmriNoManager.Get("DEVAM EDİYOR");
            if (gorevEmriNo != null)
            {
                LblGorevNo.Text = gorevEmriNo.MevcutNo.ToString();
                LblSonGorevNo.Text = gorevEmriNo.BitisNo.ToString();
                LblKalanGorevNo.Text = (gorevEmriNo.BitisNo.ConInt() - gorevEmriNo.MevcutNo.ConInt() + 1).ToString();
                LblTarih.Text = gorevEmriNo.Tarih.ToString("d");
            }
            else
            {
                gorevEmriNo = gorevEmriNoManager.Get2("BİTTİ");
                if (gorevEmriNo !=null)
                {
                    LblGorevNo.Text = gorevEmriNo.MevcutNo.ToString();
                    LblSonGorevNo.Text = gorevEmriNo.BitisNo.ToString();
                    LblKalanGorevNo.Text = (gorevEmriNo.BitisNo.ConInt() - gorevEmriNo.MevcutNo.ConInt() + 1).ToString();
                    LblTarih.Text = gorevEmriNo.Tarih.ToString("d");
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (TxtBaslangic.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Başlangıç Görev Numarasını giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtBitis.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Bitiş Görev Numarasını Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtBitis.Text.ConInt() < TxtBaslangic.Text.ConInt())
            {
                MessageBox.Show("Başlangıç Görev Numarası Bitiş Görev Numarasından büyük olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (LblSonGorevNo.Text.ConInt() == TxtBaslangic.Text.ConInt())
            {
                MessageBox.Show("Son Görev Emri No ile Yeni Görev Emri No Başlangıcı aynı olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (LblGorevNo.Text.ConInt() > TxtBaslangic.Text.ConInt())
            {
                MessageBox.Show("Mevcut Görev Numarası Yeni Görev Numarasından büyük olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                GorevEmriNo gorevEmriNo = new GorevEmriNo(TxtBaslangic.Text.ConInt(), TxtBitis.Text.ConInt());
                string mesaj = gorevEmriNoManager.Add(gorevEmriNo);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                gorevEmriNo = gorevEmriNoManager.Get("DEVAM EDİYOR");
                if (gorevEmriNo == null)
                {
                    gorevEmriNo = gorevEmriNoManager.Get("BAŞLAMADI");
                    gorevEmriNoManager.Update(gorevEmriNo.Id, "DEVAM EDİYOR");
                    //gorevEmriNoManager.UpdateMevcutNo(gorevEmriNo.Id, gorevEmriNo.BaslangicNo);
                }
                SistemGorevKapat();
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataDisplay();
            }

        }
        void SistemGorevKapat()
        {
            List<SistemUyari> sistemUyaris = new List<SistemUyari>();
            sistemUyaris = sistemUyariManager.GetListKapatilacak("Yurt İçi Görev");
            
            foreach (SistemUyari item in sistemUyaris)
            {
                sistemUyariManager.Update(item.Id);
            }

        }
    }
}
