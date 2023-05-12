using Business.Concreate.BakimOnarim;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
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

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmRezerveEt : Form
    {
        AbfMalzemeManager abfMalzemeManager;
        ArizaKayitManager arizaKayitManager;
        DepoMiktarManager depoMiktarManager;
        MalzemeManager malzemeManager;
        List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
        public object[] infos;
        public int malzemeId = 0;
        string aciklama = "";
        int id = 0;
        public FrmRezerveEt()
        {
            InitializeComponent();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            depoMiktarManager = DepoMiktarManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
        }

        private void FrmRezerveEt_Load(object sender, EventArgs e)
        {

        }

        private void TxtAbf_TextChanged(object sender, EventArgs e)
        {
            if (TxtAbf.Text.Length > 5)
            {
                ArizaKayit arizaKayit = arizaKayitManager.Get(TxtAbf.Text.ConInt());
                if (arizaKayit != null)
                {
                    id = arizaKayit.Id;
                    abfMalzemes = abfMalzemeManager.GetList(id);
                    LblSorumluPersonel.Text = arizaKayit.AcmaOnayiVeren;
                    LblBolgeAdi.Text = arizaKayit.BolgeAdi;
                }
                else
                {
                    abfMalzemes = new List<AbfMalzeme>();
                    LblSorumluPersonel.Text = "00";
                    LblBolgeAdi.Text = "00";
                    MessageBox.Show("Arıza kaydına ulaşılamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void BtnRezerve_Click(object sender, EventArgs e)
        {
            aciklama = "MALZEME MEVCUT BİLDİRİME REZERVE EDİLMİŞTİR.";
            DepoMiktar depoMiktar = new DepoMiktar(malzemeId, infos[1].ToString(), aciklama, id);
            string mesaj = depoMiktarManager.DepoRezerve(depoMiktar);
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (AbfMalzeme item in abfMalzemes)
            {
                Malzeme malzeme = malzemeManager.Get(item.SokulenStokNo);

                if (malzeme != null)
                {
                    abfMalzemeManager.TeminBilgisi(item.Id, "REZERVE EDİLDİ", infos[1].ToString(), "DEPO REZERVE İŞLEMİ YAPILDI");
                }
            }

            bool istenilenKontrol = false;
            abfMalzemes = abfMalzemeManager.GetList(id);
            foreach (AbfMalzeme item in abfMalzemes)
            {
                if (item.TeminDurumu != "REZERVE EDİLDİ")
                {
                    istenilenKontrol = true;
                    break;
                }
            }

            if (istenilenKontrol == false)
            {
                arizaKayitManager.ArizaMalzemeDurum(id, "MALZEME HAZIR");
            }
            else
            {
                arizaKayitManager.ArizaMalzemeDurum(id, "TEMİN BEKLİYOR");
            }

            MessageBox.Show("Rezerve işlemi başarıyla gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }
    }
}
