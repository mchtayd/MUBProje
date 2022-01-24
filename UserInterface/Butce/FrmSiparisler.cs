using Business;
using Business.Concreate.Butce;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity.Butce;
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
using UserInterface.STS;

namespace UserInterface.Butce
{
    public partial class FrmSiparisler : Form
    {
        SiparislerManager siparislerManager;
        ComboManager comboManager;
        PersonelKayitManager personelKayitManager;
        SiparislerPersonelManager siparislerPersonelManager;

        Siparisler siparisler;
        List<Siparisler> siparislers;
        int ids, TOPLAMPERSONEL, TOPLAMARAC, yoneticiarac, araziarac, personelyonetici, personel, personeldepo, kontenjan, mevcut, siparisNereyeKontenjan;
        string benzersizgelen, benzersizolustur, SİPARİSNO, yil, neredenSiparis = "", nereyeSiparis = "";
        bool start = false;
        public FrmSiparisler()
        {
            InitializeComponent();
            siparislerManager = SiparislerManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            personelKayitManager = PersonelKayitManager.GetInstance();
            siparislerPersonelManager = SiparislerPersonelManager.GetInstance();
        }

        private void FrmSiparisler_Load(object sender, EventArgs e)
        {
            ComboProje();
            ComboSat();
            ComboSatKategori();
            Toplamlar2();
            MevcutKadro();
            Toplamlar2();
            SiparisDoldurNereden();
            SiparisDoldurNereye();
            TOPA.Text = siparislerManager.ToplamArac().ToString();
            start = true;
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSiparisler"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        public void SiparisDoldurNereden()
        {
            CmbSiparisNereden.DataSource = siparislerManager.GetList();
            CmbSiparisNereden.ValueMember = "Id";
            CmbSiparisNereden.DisplayMember = "Siparisno";
            CmbSiparisNereden.SelectedValue = 0;
        }
        public void SiparisDoldurNereye()
        {
            CmbSiparisNereye.DataSource = siparislerManager.GetList();
            CmbSiparisNereye.ValueMember = "Id";
            CmbSiparisNereye.DisplayMember = "Siparisno";
            CmbSiparisNereye.SelectedValue = 0;
        }
        public void MevcutKadro()
        {
            DtgMevcutKadro.DataSource = siparislerManager.GetList();
            DataDisplay();
            KadroControl();
        }
        void KadroControl()
        {
            foreach (DataGridViewRow item in DtgMevcutKadro.Rows)
            {
                int toplamPersonel = item.Cells["Personeltoplam"].Value.ConInt();
                int personelSayisi = item.Cells["MevcutPersonel"].Value.ConInt();
                if (personelSayisi < toplamPersonel)
                {
                    item.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        void DataDisplay()
        {
            DtgMevcutKadro.Columns["Id"].Visible = false;
            DtgMevcutKadro.Columns["Personelsayisi"].Visible = false;
            DtgMevcutKadro.Columns["Benzersiz"].Visible = false;
            DtgMevcutKadro.Columns["MevcutPersonel"].HeaderText = "MEVCUT PERSONEL";
            DtgMevcutKadro.Columns["Proje"].HeaderText = "PROJE";
            DtgMevcutKadro.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgMevcutKadro.Columns["Personelyonetici"].HeaderText = "PERSONEL YÖNETİCİ";
            DtgMevcutKadro.Columns["Personel"].HeaderText = "PERSONEL";
            DtgMevcutKadro.Columns["Personeldepo"].HeaderText = "PERSONEL DEPO";
            DtgMevcutKadro.Columns["Personeltoplam"].HeaderText = "PERSONEL TOPLAM";
            DtgMevcutKadro.Columns["Yoneticiarac"].HeaderText = "YÖNETİCİ ARAÇ";
            DtgMevcutKadro.Columns["Araziarac"].HeaderText = "ARAZİ ARAÇ";
            DtgMevcutKadro.Columns["Toplamarac"].HeaderText = "TOPLAM ARAÇ";
            DtgMevcutKadro.Columns["Sat"].HeaderText = "SAT";
            DtgMevcutKadro.Columns["Donemyil"].HeaderText = "DÖNEM YIL";
            DtgMevcutKadro.Columns["Satkategori"].HeaderText = "SAT KATEGORİ";
            DtgMevcutKadro.Columns["MevcutPersonel"].DisplayIndex = 13;
            Toplamlar();
        }
        public void ComboProje()
        {
            CmbProje.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProje.ValueMember = "Id";
            CmbProje.DisplayMember = "Baslik";
            CmbProje.SelectedValue = 0;
        }
        public void ComboSat()
        {
            TxtSatt.DataSource = comboManager.GetList("SİPARİŞLER SAT");
            TxtSatt.ValueMember = "Id";
            TxtSatt.DisplayMember = "Baslik";
            TxtSatt.SelectedValue = 0;
        }
        public void ComboSatKategori()
        {
            CmbSatKategori.DataSource = comboManager.GetList("SİPARİŞLER SAT KATEGORİ");
            CmbSatKategori.ValueMember = "Id";
            CmbSatKategori.DisplayMember = "Baslik";
            CmbSatKategori.SelectedValue = 0;
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgMevcutKadro.Rows.Count; ++i)
            {
                if (DtgMevcutKadro.Rows[i].Cells[2].Value.ToString() != "N/A2021N/A10P0A")
                {
                    toplam += Convert.ToDouble(DtgMevcutKadro.Rows[i].Cells[15].Value);
                }
            }
            TxtMevcutPersonel.Text = toplam.ToString();
        }

        private void TxtPersonel_TextChanged(object sender, EventArgs e)
        {
            if (TxtPersonel.Text == "")
            {
                personel = 0;
                TxtPersonel.Text = (0).ToString();
            }
            personel = TxtPersonel.Text.ConInt();
            TxtPersonelSayisi.Text = (personelyonetici + personel + personeldepo).ToString();
            TOPLAMPERSONEL = personelyonetici + personel;
        }

        private void TxtPersonelDepo_TextChanged(object sender, EventArgs e)
        {
            if (TxtPersonelDepo.Text == "")
            {

                personeldepo = 0;
                TxtPersonelDepo.Text = (0).ToString();
            }
            personeldepo = TxtPersonelDepo.Text.ConInt();
            TxtPersonelSayisi.Text = (personelyonetici + personel + personeldepo).ToString();
            TOPLAMPERSONEL = personelyonetici + personel + personeldepo;
        }

        private void BtnSiparisGuncelle_Click(object sender, EventArgs e)
        {
            SiparisNoOlustur();
            DialogResult dr = MessageBox.Show("Yeni Sipariş Numarası GüNCELLEMEK İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                siparisler = new Siparisler(CmbProje.Text, SİPARİSNO, personelyonetici, personel, personeldepo, TOPLAMPERSONEL,
                    yoneticiarac, araziarac, TOPLAMARAC, TOPLAMPERSONEL, TxtSatt.Text, TxtDonemYil.Text, CmbSatKategori.Text, benzersizgelen);

                string messege = siparislerManager.Update(siparisler);
                MessageBox.Show(messege);
                MevcutKadro();
                Temizle();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ids == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Sipariş Kaydı Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Sipariş Numarasını Silmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                siparislerManager.Delete(ids);
                //MevcutKadro();
                Temizle();
                MevcutKadro();
            }
        }

        private void BtnGetir_Click(object sender, EventArgs e)
        {
            if (CmbSiparisNereden.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle NEREDEN Bilgisini Ekleyiniz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (CmbSiparisNereye.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle NEREYE Bilgisini Ekleyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CmbAktarilacak.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle AKTARILACAK Bilgisini Ekleyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            neredenSiparis = CmbSiparisNereden.Text;
            nereyeSiparis = CmbSiparisNereye.Text;
            if (CmbAktarilacak.Text== "PERSONEL")
            {
                DtgNereden.DataSource = personelKayitManager.PersonelSiparis(CmbSiparisNereden.Text);
                PersonellerDuzenle();
                DtgNereye.Columns.Add("PersonelAdi", "ADI SOYADI");
                DtgNereye.Columns.Add("Unvani", "ÜNVANI");
                DtgNereye.Columns.Add("MasYerSorumlusu", "MASRAF YERİ SORUMLUSU");
                DtgNereye.Columns.Add("Bolum", "BÖLÜMÜ");
            }
            if (CmbAktarilacak.Text == "ARAÇ")
            {

            }
        }
        void PersonellerDuzenle()
        {
            DtgNereden.Columns["Id"].Visible = false;
            DtgNereden.Columns["Adsoyad"].HeaderText = "ADI SOYADI";
            DtgNereden.Columns["Isunvani"].HeaderText = "ÜNVANI";
            DtgNereden.Columns["MasrafYeriSorumlusu"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgNereden.Columns["Sirketbolum"].HeaderText = "BÖLÜM";
            DtgNereden.Columns["Tc"].Visible = false;
            DtgNereden.Columns["Cocuksayisi"].Visible = false;
            DtgNereden.Columns["Maas"].Visible = false;
            DtgNereden.Columns["Iase"].Visible = false;
            DtgNereden.Columns["Kirayardimi"].Visible = false;
            DtgNereden.Columns["Diplomanotu"].Visible = false;
            DtgNereden.Columns["Heskodu"].Visible = false;
            DtgNereden.Columns["Sigortasicilno"].Visible = false;
            DtgNereden.Columns["Ikametgah"].Visible = false;
            DtgNereden.Columns["Kangrubu"].Visible = false;
            DtgNereden.Columns["Esad"].Visible = false;
            DtgNereden.Columns["Estelefon"].Visible = false;
            DtgNereden.Columns["Medenidurumu"].Visible = false;
            DtgNereden.Columns["Esisdurumu"].Visible = false;
            DtgNereden.Columns["Dogumyeri"].Visible = false;
            DtgNereden.Columns["Okul"].Visible = false;
            DtgNereden.Columns["Bolum"].Visible = false;
            DtgNereden.Columns["Siparis"].Visible = false;
            DtgNereden.Columns["Sat"].Visible = false;
            DtgNereden.Columns["Butcekodu"].Visible = false;
            DtgNereden.Columns["Butcekalemi"].Visible = false;
            DtgNereden.Columns["Sicil"].Visible = false;
            DtgNereden.Columns["Masyerino"].Visible = false;
            DtgNereden.Columns["Masrafyeri"].Visible = false;
            DtgNereden.Columns["Sirketmail"].Visible = false;
            DtgNereden.Columns["Oficemail"].Visible = false;
            DtgNereden.Columns["Sirketcep"].Visible = false;
            DtgNereden.Columns["Sirketkisakod"].Visible = false;
            DtgNereden.Columns["Dahilino"].Visible = false;
            DtgNereden.Columns["Askerlikdurumu"].Visible = false;
            DtgNereden.Columns["Askerliksinifi"].Visible = false;
            DtgNereden.Columns["Rubesi"].Visible = false;
            DtgNereden.Columns["Gorevi"].Visible = false;
            DtgNereden.Columns["Gorevyeri"].Visible = false;
            DtgNereden.Columns["Tecilsebebi"].Visible = false;
            DtgNereden.Columns["Muafnedeni"].Visible = false;
            DtgNereden.Columns["Dogumtarihi"].Visible = false;
            DtgNereden.Columns["Isegiristarihi"].Visible = false;
            DtgNereden.Columns["Askerlikbastarihi"].Visible = false;
            DtgNereden.Columns["Askerlikbittarihi"].Visible = false;
            DtgNereden.Columns["Tecilbittarihi"].Visible = false;
            DtgNereden.Columns["SiparisNo"].Visible = false;
            DtgNereden.Columns["Dosyayolu"].Visible = false;
            DtgNereden.Columns["Fotoyolu"].Visible = false;
            DtgNereden.Columns["ProjeKodu"].Visible = false;
            DtgNereden.Columns["KgbNo"].Visible = false;
            DtgNereden.Columns["KgbTarih"].Visible = false;
            LblNeredenToplam.Text = DtgNereden.RowCount.ToString();
        }
        void PersonellerDuzenlenNereye()
        {
            DtgNereye.Columns["Id"].Visible = false;
            DtgNereye.Columns["Adsoyad"].HeaderText = "ADI SOYADI";
            DtgNereye.Columns["Isunvani"].HeaderText = "ÜNVANI";
            DtgNereye.Columns["MasrafYeriSorumlusu"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgNereye.Columns["Sirketbolum"].HeaderText = "BÖLÜM";
            DtgNereye.Columns["Tc"].Visible = false;
            DtgNereye.Columns["Cocuksayisi"].Visible = false;
            DtgNereye.Columns["Maas"].Visible = false;
            DtgNereye.Columns["Iase"].Visible = false;
            DtgNereye.Columns["Kirayardimi"].Visible = false;
            DtgNereye.Columns["Diplomanotu"].Visible = false;
            DtgNereye.Columns["Heskodu"].Visible = false;
            DtgNereye.Columns["Sigortasicilno"].Visible = false;
            DtgNereye.Columns["Ikametgah"].Visible = false;
            DtgNereye.Columns["Kangrubu"].Visible = false;
            DtgNereye.Columns["Esad"].Visible = false;
            DtgNereye.Columns["Estelefon"].Visible = false;
            DtgNereye.Columns["Medenidurumu"].Visible = false;
            DtgNereye.Columns["Esisdurumu"].Visible = false;
            DtgNereye.Columns["Dogumyeri"].Visible = false;
            DtgNereye.Columns["Okul"].Visible = false;
            DtgNereye.Columns["Bolum"].Visible = false;
            DtgNereye.Columns["Siparis"].Visible = false;
            DtgNereye.Columns["Sat"].Visible = false;
            DtgNereye.Columns["Butcekodu"].Visible = false;
            DtgNereye.Columns["Butcekalemi"].Visible = false;
            DtgNereye.Columns["Sicil"].Visible = false;
            DtgNereye.Columns["Masyerino"].Visible = false;
            DtgNereye.Columns["Masrafyeri"].Visible = false;
            DtgNereye.Columns["Sirketmail"].Visible = false;
            DtgNereye.Columns["Oficemail"].Visible = false;
            DtgNereye.Columns["Sirketcep"].Visible = false;
            DtgNereye.Columns["Sirketkisakod"].Visible = false;
            DtgNereye.Columns["Dahilino"].Visible = false;
            DtgNereye.Columns["Askerlikdurumu"].Visible = false;
            DtgNereye.Columns["Askerliksinifi"].Visible = false;
            DtgNereye.Columns["Rubesi"].Visible = false;
            DtgNereye.Columns["Gorevi"].Visible = false;
            DtgNereye.Columns["Gorevyeri"].Visible = false;
            DtgNereye.Columns["Tecilsebebi"].Visible = false;
            DtgNereye.Columns["Muafnedeni"].Visible = false;
            DtgNereye.Columns["Dogumtarihi"].Visible = false;
            DtgNereye.Columns["Isegiristarihi"].Visible = false;
            DtgNereye.Columns["Askerlikbastarihi"].Visible = false;
            DtgNereye.Columns["Askerlikbittarihi"].Visible = false;
            DtgNereye.Columns["Tecilbittarihi"].Visible = false;
            DtgNereye.Columns["SiparisNo"].Visible = false;
            DtgNereye.Columns["Dosyayolu"].Visible = false;
            DtgNereye.Columns["Fotoyolu"].Visible = false;
            DtgNereye.Columns["ProjeKodu"].Visible = false;
            DtgNereye.Columns["KgbNo"].Visible = false;
            DtgNereye.Columns["KgbTarih"].Visible = false;
            LblNeredenToplam.Text = DtgNereden.RowCount.ToString();
        }

        private void BtnAktar_Click(object sender, EventArgs e)
        {
            if (DtgNereden.RowCount==0)
            {
                MessageBox.Show("Lütfen Öncelikle NEREDEN Listesine Personel Bilgilerini Ekleyiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (CmbAktarilacak.Text== "PERSONEL")
            {
                string message = KontenjanControlAktarim();

                if (message != "OK")
                {
                    MessageBox.Show(message, "Hata", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                foreach (DataGridViewRow item in DtgNereden.Rows)
                {
                    DtgNereye.Rows.Add();

                    int sonSatir = DtgNereye.RowCount - 1;
                    DtgNereye.Rows[sonSatir].Cells["PersonelAdi"].Value = item.Cells["Adsoyad"].Value;
                    DtgNereye.Rows[sonSatir].Cells["Unvani"].Value = item.Cells["Isunvani"].Value;
                    DtgNereye.Rows[sonSatir].Cells["MasYerSorumlusu"].Value = item.Cells["MasrafYeriSorumlusu"].Value;
                    DtgNereye.Rows[sonSatir].Cells["Bolum"].Value = item.Cells["Sirketbolum"].Value;
                }
                LblNereyeToplam.Text = DtgNereye.RowCount.ToString();
            }

            if (CmbAktarilacak.Text == "ARAÇ")
            {

            }


        }

        private void CmbSiparisNereden_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TemizleAktarim();
        }

        private void CmbSiparisNereye_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            string mesaj = KontenjanControlGuncelle();
            if (mesaj=="")
            {
                TemizleAktarim();
                return;
            }
            
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK,MessageBoxIcon.Error);
                CmbSiparisNereye.SelectedIndex = -1;
                TemizleAktarim();
            }
            /*if (CmbSiparisNereye.Text=="")
            {
                TemizleAktarim();
            }*/
            //TemizleAktarim();
        }

        string KontenjanControlGuncelle()
        {
            
            kontenjan = siparislerManager.KontejanKontrol(CmbSiparisNereye.Text);
            mevcut = siparislerManager.KontejanKontrolMevcut(CmbSiparisNereye.Text);
            if (kontenjan == -1)
            {
                return "";
            }
            if (kontenjan <= mevcut)
            {
                return CmbSiparisNereye.Text + " Nolu Siparişte Boş Kontenjan Olmadığı İçin Bu Siparişi Seçemezsiniz!";
            }
            return "OK";
        }

        string KontenjanControlAktarim()
        {

            kontenjan = siparislerManager.KontejanKontrol(nereyeSiparis);
            mevcut = siparislerManager.KontejanKontrolMevcut(nereyeSiparis);

            int bosKontejan = kontenjan - mevcut;
            if (kontenjan == -1)
            {
                return "";
            }
            if (LblNeredenToplam.Text.ConInt() >= bosKontejan)
            {
                return CmbSiparisNereye.Text + " Nolu Siparişte Yeteri Kadar Boş Kontejan Bulunmamaktadır!";
            }
            return "OK";
        }


        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (DtgNereye.RowCount==0)
            {
                MessageBox.Show("Lütfen Öncelikle NEREYE Listesine Kayıtlarını Aktarınız!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }



            DialogResult dr = MessageBox.Show(CmbSiparisNereden.Text + " Nolu Sipariş Numarasında ki " + LblNeredenToplam.Text + " Personelin Sipariş Numarası " + CmbSiparisNereye.Text + " Nolu Siparişe Aktarılacaktir! Onaylıyor Musunuz?", "Soru", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in DtgNereye.Rows)
                {
                    SiparislerPersonel siparislerManager = new SiparislerPersonel(item.Cells["PersonelAdi"].Value.ToString(), item.Cells["Unvani"].Value.ToString(), item.Cells["MasYerSorumlusu"].Value.ToString(), item.Cells["Bolum"].Value.ToString(), "ÇALIŞIYOR", neredenSiparis, DateTime.Now);

                    string control = siparislerPersonelManager.Add(siparislerManager);
                    if (control != "OK")
                    {
                        MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleAktarim();
            }

        }

        void TemizleAktarim()
        {
            DtgNereden.DataSource = null;
            DtgNereye.Rows.Clear();
            CmbSiparisNereden.SelectedValue = "";
            CmbSiparisNereye.SelectedValue = "";
            CmbAktarilacak.SelectedIndex = -1;
            LblNeredenToplam.Text = DtgNereden.RowCount.ToString();
            LblNereyeToplam.Text = DtgNereye.RowCount.ToString();
        }

        private void CmbDonemYil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start==false)
            {
                return;
            }
            yil = CmbDonemYil.Text;
            DtgMevcutKadro.DataSource = null;
            DtgMevcutKadro.DataSource = siparislerManager.YillikSiparisCek(yil);
            if (DtgMevcutKadro.DataSource==null)
            {
                return;
            }
            DataDisplay();
            KadroControl();

        }


        private void DtgMevcutKadro_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string benzersizlistele = DtgMevcutKadro.CurrentRow.Cells["Benzersiz"].Value.ToString();
            siparislers = siparislerManager.GetList(benzersizlistele);
            KadroControl();
            FillTols();
        }

        private void TxtAraziArac_TextChanged(object sender, EventArgs e)
        {
            if (TxtAraziArac.Text == "")
            {
                araziarac = 0;
                TxtAraziArac.Text = (0).ToString();
            }
            araziarac = TxtAraziArac.Text.ConInt();
            D.Text = (araziarac + yoneticiarac).ToString();
            TOPLAMARAC = araziarac + yoneticiarac;
        }

        private void TxtPersonelYonetici_TextChanged(object sender, EventArgs e)
        {
            if (TxtPersonelYonetici.Text == "")
            {
                personelyonetici = 0;
                TxtPersonelYonetici.Text = (0).ToString();
            }
            personelyonetici = TxtPersonelYonetici.Text.ConInt();
            TxtPersonelSayisi.Text = (personelyonetici + personel + personeldepo).ToString();
            TOPLAMPERSONEL = personelyonetici;
        }

        private void FillTols()
        {
            Temizle();

            if (siparislers == null)
            {
                return;
            }
            if (siparislers.Count == 0)
            {
                return;
            }
            if (siparislers.Count > 0)
            {
                Siparisler item = siparislers[0];
                ids = item.Id;
                string proje = "";
                proje = item.Proje;
                CmbProje.Text = proje;
                TxtSatt.Text = item.Sat;
                TxtDonemYil.Text = item.Donemyil;
                CmbSatKategori.Text = item.Satkategori;
                D.Text = item.Toplamarac.ToString();
                TxtPersonelSayisi.Text = item.Personeltoplam.ToString();
                TxtYoneticiArac.Text = item.Yoneticiarac.ToString();
                TxtAraziArac.Text = item.Araziarac.ToString();
                TxtPersonelYonetici.Text = item.Personelyonetici.ToString();
                TxtPersonel.Text = item.Personel.ToString();
                TxtPersonelDepo.Text = item.Personeldepo.ToString();
                benzersizgelen = item.Benzersiz;
            }
        }

        private void TxtYoneticiArac_TextChanged(object sender, EventArgs e)
        {
            if (TxtYoneticiArac.Text == "")
            {
                yoneticiarac = 0;
                TxtYoneticiArac.Text = (0).ToString();
            }
            yoneticiarac = TxtYoneticiArac.Text.ConInt();
            D.Text = (yoneticiarac + araziarac).ToString();
            TOPLAMARAC = yoneticiarac;
        }

        void Temizle()
        {
            TxtDonemYil.Clear(); TxtYoneticiArac.Clear(); TxtAraziArac.Clear(); TxtPersonelYonetici.Clear(); TxtPersonel.Clear(); TxtPersonelDepo.Clear();
            CmbProje.Text = ""; TxtSatt.Text = ""; CmbSatKategori.Text = ""; CmbProje.SelectedValue = ""; TxtSatt.SelectedValue = ""; CmbSatKategori.SelectedValue = "";

        }
        void Toplamlar2()
        {
            double toplamPersonel = 0;
            for (int i = 0; i < DtgMevcutKadro.Rows.Count; ++i)
            {
                if (DtgMevcutKadro.Rows[i].Cells[2].Value.ToString() != "N/A2021N/A10P0A")
                {
                    toplamPersonel += Convert.ToDouble(DtgMevcutKadro.Rows[i].Cells[12].Value);
                }
            }
            TOPP.Text = toplamPersonel.ToString();
        }

        private void BtnSiparisOlustur_Click(object sender, EventArgs e)
        {
            benzersizolustur = Guid.NewGuid().ToString();
            SiparisNoOlustur();
            siparisler = null;
            DialogResult dr = MessageBox.Show("Yeni Sipariş Numarası Oluşturmak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                siparisler = new Siparisler(CmbProje.Text, SİPARİSNO, personelyonetici, personel, personeldepo, TOPLAMPERSONEL,
                    yoneticiarac, araziarac, TOPLAMARAC, TOPLAMPERSONEL, TxtSatt.Text, TxtDonemYil.Text, CmbSatKategori.Text, benzersizolustur);

                string messege = siparislerManager.Add(siparisler);
                MessageBox.Show(messege);
                MevcutKadro();
                Temizle();
                //TOPP.Text = siparislerManager.ToplamPers().ToString();
                Toplamlar2();
                TOPA.Text = siparislerManager.ToplamArac().ToString();
            }
        }
        void SiparisNoOlustur()
        {
            SİPARİSNO = TxtSatt.Text + "-" + TxtDonemYil.Text + "-" + CmbSatKategori.Text + "-" + TOPLAMPERSONEL + "P" + TOPLAMARAC + "A";
        }
    }
}
