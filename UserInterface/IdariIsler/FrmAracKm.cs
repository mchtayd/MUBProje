using Business.Concreate.AnaSayfa;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
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
using UserInterface.Ana_Sayfa;
using UserInterface.STS;

namespace UserInterface.IdariIsler
{
    public partial class FrmAracKm : Form
    {
        AracKmManager aracKmManager;
        AracManager aracManager;
        AracZimmetiManager aracZimmetiManager;
        SiparisPersonelManager siparisPersonelManager;
        CokluAracManager cokluAracManager;
        IstenAyrilisManager ıstenAyrilisManager;
        BildirimYetkiManager bildirimYetkiManager;

        public object[] infos;

        string siparisNo = "";
        int id;
        public FrmAracKm()
        {
            InitializeComponent();
            aracKmManager = AracKmManager.GetInstance();
            aracManager = AracManager.GetInstance();
            aracZimmetiManager = AracZimmetiManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            cokluAracManager = CokluAracManager.GetInstance();
            ıstenAyrilisManager = IstenAyrilisManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
        }

        private void FrmAracKm_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageAracKm"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        DateTime projeyeGirisTarihi;
        private void BtnBulT_Click(object sender, EventArgs e)
        {
            if (TxtPlaka.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Plaka Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Arac arac = aracManager.Get(TxtPlaka.Text); // ARAÇ BİLGİLERİ
            //ZimmetAktarim zimmetAktarim = zimmetAktarimManager.AracZimmetBilgileri("%" + TxtPlaka.Text + '%'); // DURAN VARLIK LİSTESİNDEN
            AracZimmeti aracZimmeti = aracZimmetiManager.Get(TxtPlaka.Text); // ARAÇ ZİMMET LİSTESİNDEN
            if (arac == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz Plakaya Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                return;
            }

            Temizle();
            id = arac.Id;
            TxtPlaka.Text = arac.Plaka.ToUpper();
            TxtSiparisNo.Text = arac.Siparisno;
            TxtMulkiyetBilgileri.Text = arac.MulkiyetBilgileri;
            projeyeGirisTarihi = arac.ProjeTahsisTarihi;
            if (aracZimmeti == null)
            {
                TxtAdSoyad.Text = "";
                CmbSiparisNo.Text = "";
                TxtGorevi.Text = "";
                TxtMasrafyeriNo.Text = "";
                TxtMasrafYeri.Text = "";
                TxtMasrafYeriSorumlusu.Text = "";
                TxtMulkiyetBilgileri.Text = "";
            }
            else
            {
                TxtAdSoyad.Text = aracZimmeti.PersonelAd;

                SiparisPersonel siparis = siparisPersonelManager.Get("", TxtAdSoyad.Text);
                if (siparis==null)
                {
                    DialogResult dr = MessageBox.Show("Aracın zimmetli olduğu " + TxtAdSoyad.Text + " adlı personel işten ayrılmıştır. Lütfen aracın zimmet işlemlerini tamamlayınız!\nİşleme " + TxtAdSoyad.Text + " isimli personel kaydı üzerinden devam edilecektir. Onaylıyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr==DialogResult.Yes)
                    {
                        IstenAyrilis ıstenAyrilis = ıstenAyrilisManager.Get(TxtAdSoyad.Text);
                        TxtMasrafyeriNo.Text = ıstenAyrilis.Masyerino;
                        TxtMasrafYeri.Text = ıstenAyrilis.Masrafyeri;
                        TxtGorevi.Text = ıstenAyrilis.Isunvani;
                        CmbSiparisNo.Text = ıstenAyrilis.Siparis;
                        TxtMasrafYeriSorumlusu.Text = "RESUL GÜNEŞ";
                        return;
                    }
                    else
                    {
                        Temizle();
                        return;
                    }
                }

                TxtMasrafyeriNo.Text = siparis.Masrafyerino;
                TxtMasrafYeri.Text = siparis.Masrafyeri;
                TxtGorevi.Text = siparis.Gorevi;
                CmbSiparisNo.Text = siparis.Siparis;
                TxtMasrafYeriSorumlusu.Text = siparis.MasrafYeriSorumlusu;
            }

        }
        void Temizle()
        {
            TxtPlaka.Clear(); TxtSiparisNo.Clear(); TxtKmBaslangic.Clear(); TxtAdSoyad.Clear(); CmbSiparisNo.Clear(); TxtGorevi.Clear(); TxtMasrafyeriNo.Clear(); TxtMasrafYeri.Clear(); TxtMasrafYeriSorumlusu.Clear(); TxtMulkiyetBilgileri.Clear(); TxtAciklama.Clear(); TxtKmBitis.Clear();
        }
        string donem = "";
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (RdbEvet.Checked == true && DtgAracList.RowCount==1)
            {
                MessageBox.Show("Çoklu araç kaydında lütfen iki veya daha fazla araç bilgisi ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            siparisNo = Guid.NewGuid().ToString();

            if (RdbEvet.Checked == true)
            {
                foreach (DataGridViewRow item in DtgAracList.Rows)
                {
                    CokluArac cokluArac = new CokluArac(siparisNo, item.Cells["Plaka"].Value.ToString(), item.Cells["BaslangicKm"].Value.ConInt(), item.Cells["BitisK"].Value.ConInt(), item.Cells["ToplamKm"].Value.ConInt(), item.Cells["Aciklama"].Value.ToString(), item.Cells["BaslangicTarihi"].Value.ConDate(), item.Cells["BitisTarihi"].Value.ConDate());

                    cokluAracManager.Add(cokluArac);
                }

                //TarihBul();
                if (TxtPlaka.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle Kayıtlı Bir Plaka Bilgisi Yazınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TxtSiparisNo.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle Kayıtlı Bir Plaka Bilgisi Yazarak Araç Bilgilerini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TxtAdSoyad.Text == "")
                {
                    MessageBox.Show("Lütfen Hiç Bir Personele Zimmetli Değildir. Lütfen Öncelikle Zimmet Bilgilerini Kontrol Ediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (CmbDonem.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle Dönem Ay Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (CmbDonemYil.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle Dönem Yıl Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                KmFarkBulCoklu();

                donem = CmbDonem.Text + " " + CmbDonemYil.Text;
                string mesaj = "";

                AracKm aracKm = new AracKm(TxtPlaka.Text, TxtSiparisNo.Text, DtBaslamaTarihi.Value, donem, TxtKmBaslangic.Text.ConInt(), TxtAdSoyad.Text, CmbSiparisNo.Text, TxtGorevi.Text, TxtMasrafyeriNo.Text, TxtMasrafYeri.Text, TxtMasrafYeriSorumlusu.Text, TxtMulkiyetBilgileri.Text, DtgBitisTarihi.Value, TxtKmBitis.Text.ConInt() ,LblToplamKm.Text.ConInt(), sabitKm, fark, siparisNo);

                mesaj = aracKmManager.Add(aracKm);

                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DtgAracList.Rows.Clear();
                LblToplamKm.Text = "00";
                Temizle();
            }

            else
            {
                //TarihBul();
                if (TxtPlaka.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle Kayıtlı Bir Plaka Bilgisi Yazınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TxtSiparisNo.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle Kayıtlı Bir Plaka Bilgisi Yazarak Araç Bilgilerini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TxtAdSoyad.Text == "")
                {
                    MessageBox.Show("Lütfen Hiç Bir Personele Zimmetli Değildir. Lütfen Öncelikle Zimmet Bilgilerini Kontrol Ediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (CmbDonem.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle Dönem Ay Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (CmbDonemYil.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle Dönem Yıl Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                KmFarkBul();
                string donem = CmbDonem.Text + " " + CmbDonemYil.Text;
                string mesaj = "";

                AracKm aracKm = new AracKm(TxtPlaka.Text, TxtSiparisNo.Text, DtBaslamaTarihi.Value, donem, TxtKmBaslangic.Text.ConInt(), TxtAdSoyad.Text, CmbSiparisNo.Text, TxtGorevi.Text, TxtMasrafyeriNo.Text, TxtMasrafYeri.Text, TxtMasrafYeriSorumlusu.Text, TxtMulkiyetBilgileri.Text, DtgBitisTarihi.Value, TxtKmBitis.Text.ConInt(), toplamYapilanKm, sabitKm, fark, "");

                mesaj = aracKmManager.Add(aracKm);

                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
            }

            string mesaj2 = Bildirim();
            if (mesaj2 != "OK")
            {
                MessageBox.Show(mesaj2, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string Bildirim()
        {
            string[] array = new string[8];

            array[0] = "Araç Km Kayıt"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = TxtPlaka.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "Plakalı"; // Bildirim türü
            array[4] = TxtAdSoyad.Text; // İÇERİK
            array[5] = "personeline ait aracın";
            array[6] = donem + " Dönemi Km kaydını oluşturmuştur!";

            BildirimYetki bildirimYetki = bildirimYetkiManager.Get(infos[1].ToString());
            if (bildirimYetki == null)
            {
                array[7] = infos[0].ToString();
            }
            else
            {
                array[7] = bildirimYetki.SorumluId + infos[0].ToString();
            }

            string mesaj = FrmHelper.BildirimGonder(array, array[7]);
            return mesaj;
        }

        int toplamYapilanKm = 0, sabitKm = 3500, fark = 0;

        private void TxtSiparisNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtSiparisNo_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtAdSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CmbSiparisNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtGorevi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtMasrafyeriNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtMasrafYeri_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtMasrafYeriSorumlusu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtMulkiyetBilgileri_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        string Kontrol()
        {
            if (TxtPlaka.Text=="")
            {
                return "Lütfen öncelikle Plaka bilgisini doldurunuz!";
            }
            if (TxtKmBaslangic.Text == "")
            {
                return "Lütfen öncelikle Başlangıç Km bilgisini doldurunuz!";
            }
            if (TxtKmBitis.Text == "")
            {
                return "Lütfen öncelikle Bitiş Km bilgisini doldurunuz!";
            }
            if (TxtAciklama.Text == "")
            {
                return "Lütfen öncelikle Açıklama bilgisini doldurunuz!";
            }
            return "OK";
        }
        
        private void BtnAracEkle_Click(object sender, EventArgs e)
        {
            if (DtBaslamaTarihi.Value.Day.ToString() != "1")
            {
                if (projeyeGirisTarihi.Day.ToString()=="1")
                {
                    if (DtgAracList.RowCount == 0)
                    {
                        MessageBox.Show("Öncelikle ayın ilk gününden kayıt başlatınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            string mesaj = Kontrol();

            if (mesaj!="OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int toplamKm = TxtKmBitis.Text.ConInt() - TxtKmBaslangic.Text.ConInt();
            DtgAracList.Rows.Add();
            int sonSatir = DtgAracList.RowCount - 1;
            
            DtgAracList.Rows[sonSatir].Cells["Plaka"].Value = TxtPlaka.Text;
            DtgAracList.Rows[sonSatir].Cells["BaslangicKm"].Value = TxtKmBaslangic.Text;
            DtgAracList.Rows[sonSatir].Cells["BitisK"].Value = TxtKmBitis.Text;
            DtgAracList.Rows[sonSatir].Cells["ToplamKm"].Value = toplamKm.ToString();
            DtgAracList.Rows[sonSatir].Cells["Aciklama"].Value = TxtAciklama.Text;
            DtgAracList.Rows[sonSatir].Cells["BaslangicTarihi"].Value = DtBaslamaTarihi.Value.ToString("dd.MM.yyyy");
            DtgAracList.Rows[sonSatir].Cells["BitisTarihi"].Value = DtgBitisTarihi.Value.ToString("dd.MM.yyyy");

            Toplamlar();
            //EkleTemizle();

        }
        void EkleTemizle()
        {
            TxtPlaka.Clear(); TxtSiparisNo.Clear(); CmbSiparisNo.Clear(); TxtGorevi.Clear(); TxtMasrafyeriNo.Clear(); TxtMasrafYeri.Clear();
            TxtMasrafYeriSorumlusu.Clear(); TxtMulkiyetBilgileri.Clear(); TxtAciklama.Clear(); TxtKmBaslangic.Clear(); TxtKmBitis.Clear();
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgAracList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgAracList.Rows[i].Cells[5].Value);
            }
            LblToplamKm.Text = toplam.ToString();
        }

        private void RdbEvet_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbEvet.Checked==true)
            {
                BtnAracEkle.Visible = true;
                GrbAracList.Visible = true;
                TxtAciklama.Visible = true;
                LblAciklama.Visible = true;
                LblTop.Visible = true;
                LblToplamKm.Visible = true;
                BtnKaydet.Location = new Point(527, 445);
            }
            if (RdbEvet.Checked == false)
            {
                BtnAracEkle.Visible = false;
                GrbAracList.Visible = false;
                TxtAciklama.Visible = false;
                LblAciklama.Visible = false;
                LblTop.Visible = false;
                LblToplamKm.Visible = false;
                BtnKaydet.Location = new Point(161, 544);
            }
        }


        //void TarihBul()
        //{
        //    aysonu = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1);
        //}
        void KmFarkBul()
        {

            toplamYapilanKm = TxtKmBitis.Text.ConInt() - TxtKmBaslangic.Text.ConInt();

            fark = toplamYapilanKm - sabitKm;

        }
        void KmFarkBulCoklu()
        {
            toplamYapilanKm = TxtKmBitis.Text.ConInt() - LblToplamKm.Text.ConInt();

            fark = toplamYapilanKm - sabitKm;

        }
    }
}
