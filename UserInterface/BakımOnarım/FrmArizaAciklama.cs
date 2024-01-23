using Business.Concreate;
using Business.Concreate.AnaSayfa;
using Business.Concreate.BakimOnarim;
using DataAccess.Concreate;
using DataAccess.Concreate.BakimOnarim;
using DocumentFormat.OpenXml.Office2010.Excel;
using Entity;
using Entity.AnaSayfa;
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
    public partial class FrmArizaAciklama : Form
    {
        ArizaKayitManager arizaKayitManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        DtsLogManager dtsLogManager;
        public object[] infos;
        public int arizaId;
        int guncellenecekId, gun, saat, dakika = 0;
        string islemAimi, gorevAtanacakPersonel, sure, bolgeAdi, abfNo = "";
        DateTime birOncekiTarih;

        public FrmArizaAciklama()
        {
            InitializeComponent();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            dtsLogManager = DtsLogManager.GetInstance();
        }

        private void FrmArizaAciklama_Load(object sender, EventArgs e)
        {
            ArizaKayit arizaKayit = arizaKayitManager.GetId(arizaId);
            bolgeAdi = arizaKayit.BolgeAdi;
            abfNo = arizaKayit.AbfFormNo.ToString();
            IslemAdimlari();
        }
        void IslemAdimlari()
        {
            List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetDevamEdenler(arizaId, "BAKIM ONARIM");

            if (gorevAtamaPersonels.Count==0)
            {
                MessageBox.Show("İşlem adımları tamamlanmış bir arızaya açıklama ekleyemezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            guncellenecekId = gorevAtamaPersonels[gorevAtamaPersonels.Count - 1].Id;
            islemAimi = gorevAtamaPersonels[gorevAtamaPersonels.Count - 1].IslemAdimi;
            gorevAtanacakPersonel = gorevAtamaPersonels[gorevAtamaPersonels.Count - 1].GorevAtanacakPersonel;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (TxtAciklama.Text=="")
            {
                MessageBox.Show("Lütfen herhangi bir açıklama yazınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(arizaId, "BAKIM ONARIM");
            if (gorevAtamaPersonel == null)
            {
                MessageBox.Show("Malzeme Veri Geçmişine ulaşılamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            birOncekiTarih = gorevAtamaPersonel.Tarih;

            TimeSpan sonuc = DateTime.Now - birOncekiTarih;

            gun = sonuc.Days.ConInt();
            saat = sonuc.Hours.ConInt();
            if (sonuc.Hours < 1)
            {
                saat = 0;
            }

            dakika = sonuc.Seconds.ConInt() % 60;

            sure = 0 + " Gün " + 0 + " Saat " + 0 + " Dakika";
            //sure = gun.ToString() + " Gün " + saat.ToString() + " Saat " + dakika.ToString() + " Dakika";

            GorevAtamaPersonel gorevAtama2 = new GorevAtamaPersonel(guncellenecekId, arizaId, "BAKIM ONARIM", islemAimi, sure, "00:00:00".ConOnlyTime(), infos[1].ToString());
            string kontrol2 = gorevAtamaPersonelManager.Update(gorevAtama2, TxtAciklama.Text.ToUpper());
            if (kontrol2 != "OK")
            {
                MessageBox.Show(kontrol2, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GorevAtamaPersonel gorevAtamaPersonel2 = new GorevAtamaPersonel(arizaId, "BAKIM ONARIM", gorevAtanacakPersonel, islemAimi, DateTime.Now, "", DateTime.Now.Date);
            string kontrol = gorevAtamaPersonelManager.Add(gorevAtamaPersonel2);

            if (kontrol != "OK")
            {
                MessageBox.Show(kontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtsLogKayit();
            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        void DtsLogKayit()
        {
            string islem = bolgeAdi + " bölgesine ait " + abfNo + " ABF Numaralı arızaya açıklama eklenmiştir.";
            DtsLog dtsLog = new DtsLog(infos[1].ToString(), DateTime.Now, "BİLDİRİM AÇIKLAMA EKLE", islem);
            dtsLogManager.Add(dtsLog);
        }
    }
}
