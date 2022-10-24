using Business;
using Business.Concreate.Depo;
using ClosedXML.Excel;
using DataAccess.Concreate;
using DataAccess.Concreate.Depo;
using Entity.Depo;
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

namespace UserInterface.Depo
{

    public partial class FrmMalzemeKayitDestekDepo : Form
    {
        DestekDepoMalzemeKayitManager malzemeKayitManager;
        AmbarManager ambarManager;
        CayOcagiManager cayOcagiManager;
        DestekDepoMalzemeKayitManager depoMalzemeKayitManager;
        ElAletleriManager elAletleriManager;
        IsGiysiManager isGiysiManager;
        KirtasiyeManager kirtasiyeManager;
        KKDManager kKDManager;
        TemizlikUrunleriManager temizlikUrunleriManager;
        ComboManager comboManager;
        bool start = true;
        string yeniStok = "";
        string yeniSayiTxt = "";
        string[] array2;
        int sayac;
        int yeniSayi;
        string[] array;
        string sonKayitStok;
        public FrmMalzemeKayitDestekDepo()
        {
            InitializeComponent();
            malzemeKayitManager = DestekDepoMalzemeKayitManager.GetInstance();
            ambarManager = AmbarManager.GetInstance();
            cayOcagiManager = CayOcagiManager.GetInstance();
            depoMalzemeKayitManager = DestekDepoMalzemeKayitManager.GetInstance();
            elAletleriManager = ElAletleriManager.GetInstance();
            isGiysiManager = IsGiysiManager.GetInstance();
            kirtasiyeManager = KirtasiyeManager.GetInstance();
            kKDManager = KKDManager.GetInstance();
            temizlikUrunleriManager = TemizlikUrunleriManager.GetInstance();
            comboManager = ComboManager.GetInstance();
        }

        private void FrmMalzemeKayitDestekDepo_Load(object sender, EventArgs e)
        {
            MalzemeKtegorisi();
        }
        public void MalzemeKtegorisi()
        {
            CmbMalzemeTuru.DataSource = comboManager.GetList("MALZEME_KATEGORISI");
            CmbMalzemeTuru.ValueMember = "Id";
            CmbMalzemeTuru.DisplayMember = "Baslik";
            CmbMalzemeTuru.SelectedValue = 0;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDesteDepoMalzemeKayit"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void Temizle()
        {
            CmbMalzemeTuru.Text = "";
            CmbStokNo.Text = "";
            TxtTanim.Clear();
            TxtBirim.Clear();
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (CmbMalzemeTuru.Text=="")
            {
                MessageBox.Show("Öncelikle Malzeme Türünü Belirleyiniz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(CmbStokNo.Text+" Stok Nolu Kaydı Kaydetmek İstediğinize Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (CmbMalzemeTuru.Text == "AMBAR")
                {
                    DestekDepoAmbar destekDepoAmbar = new DestekDepoAmbar(CmbStokNo.Text, TxtTanim.Text, TxtBirim.Text);
                    string mesaj = ambarManager.Add(destekDepoAmbar);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }
                if (CmbMalzemeTuru.Text == "ÇAY OCAĞI")
                {
                    DestekDepoCayOcagi destekDepoCay = new DestekDepoCayOcagi(CmbStokNo.Text, TxtTanim.Text, TxtBirim.Text);
                    string mesaj = cayOcagiManager.Add(destekDepoCay);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }
                if (CmbMalzemeTuru.Text == "EL ALETLERİ")
                {
                    DestekDepoElAletleri elAletleri = new DestekDepoElAletleri(CmbStokNo.Text, TxtTanim.Text, TxtBirim.Text);
                    string mesaj = elAletleriManager.Add(elAletleri);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }
                if (CmbMalzemeTuru.Text == "İŞ GİYSİ")
                {
                    DestekDepoIsGiysi destekDepoIsGiysi = new DestekDepoIsGiysi(CmbStokNo.Text, TxtTanim.Text, TxtBirim.Text);
                    string mesaj = isGiysiManager.Add(destekDepoIsGiysi);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }
                if (CmbMalzemeTuru.Text == "KIRTASİYE")
                {
                    DestekDepoKirtasiye destekDepoKirtasiye = new DestekDepoKirtasiye(CmbStokNo.Text, TxtTanim.Text, TxtBirim.Text);
                    string mesaj = kirtasiyeManager.Add(destekDepoKirtasiye);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }
                if (CmbMalzemeTuru.Text == "KKD")
                {
                    DestekDepoKKD KKD = new DestekDepoKKD(CmbStokNo.Text, TxtTanim.Text, TxtBirim.Text);
                    string mesaj = kKDManager.Add(KKD);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }
                if (CmbMalzemeTuru.Text == "TEMİZLİK ÜRÜNLERİ")
                {
                    DestekDepoTemizlikUrunleri temizlikUrunleri = new DestekDepoTemizlikUrunleri(CmbStokNo.Text, TxtTanim.Text, TxtBirim.Text);
                    string mesaj = temizlikUrunleriManager.Add(temizlikUrunleri);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }
                if (CmbMalzemeTuru.Text == "SARF MALZEME (DEPO)")
                {
                    //DestekDepoTemizlikUrunleri temizlikUrunleri = new DestekDepoTemizlikUrunleri(CmbStokNo.Text, TxtTanim.Text, TxtBirim.Text);
                    //string mesaj = temizlikUrunleriManager.Add(temizlikUrunleri);
                    //if (mesaj != "OK")
                    //{
                    //    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                    //MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Temizle();
                }
            }
            
            /*IXLWorkbook workbook = new XLWorkbook(@"C:\Users\MAYıldırım\Desktop\Kopya DESTEK DEPO ÜRÜN KATALOĞU.xlsx");
            IXLWorksheet worksheet = workbook.Worksheet("AMBAR");

            var rows = worksheet.Rows(2, 9);
            List<DesteDepoMalzemeKayit> list = new List<DesteDepoMalzemeKayit>();
            DateTime outDate = DateTime.Now;
            double outDouble = 0;
            foreach (IXLRow item in rows)
            {
                DesteDepoMalzemeKayit entity = new DesteDepoMalzemeKayit(
                    item.Cell("A").Value.ToString(),
                    item.Cell("B").Value.ToString(),
                    item.Cell("C").Value.ToString());
                malzemeKayitManager.Add(entity);
            }*/
        }
        int index;
        int id;
        private void CmbMalzemeTuru_SelectedIndexChanged(object sender, EventArgs e)//bilgisayarmuhendisligi.sek@mersin.edu.tr
        {
            //index = CmbMalzemeTuru.SelectedIndex;
            StokCek();
        }
        void StokCek()
        {
            if (CmbMalzemeTuru.Text == "AMBAR")
            {
                CmbStokNo.DataSource = ambarManager.GetList();
                CmbStokNo.ValueMember = "Id";
                CmbStokNo.DisplayMember = "Stokno";
                CmbStokNo.SelectedValue = 0;
                start = false;
            }
            if (CmbMalzemeTuru.Text == "ÇAY OCAĞI")
            {
                CmbStokNo.DataSource = cayOcagiManager.GetList();
                CmbStokNo.ValueMember = "Id";
                CmbStokNo.DisplayMember = "Stokno";
                CmbStokNo.SelectedValue = 0;
                start = false;
            }
            if (CmbMalzemeTuru.Text == "EL ALETLERİ")
            {
                CmbStokNo.DataSource = elAletleriManager.GetList();
                CmbStokNo.ValueMember = "Id";
                CmbStokNo.DisplayMember = "Stokno";
                CmbStokNo.SelectedValue = 0;
                start = false;
            }
            if (CmbMalzemeTuru.Text == "İŞ GİYSİ")
            {
                CmbStokNo.DataSource = isGiysiManager.GetList();
                CmbStokNo.ValueMember = "Id";
                CmbStokNo.DisplayMember = "Stokno";
                CmbStokNo.SelectedValue = 0;
                start = false;
            }
            if (CmbMalzemeTuru.Text == "KIRTASİYE")
            {
                CmbStokNo.DataSource = kirtasiyeManager.GetList();
                CmbStokNo.ValueMember = "Id";
                CmbStokNo.DisplayMember = "Stokno";
                CmbStokNo.SelectedValue = 0;
                start = false;
            }
            if (CmbMalzemeTuru.Text == "KKD")
            {
                CmbStokNo.DataSource = kKDManager.GetList();
                CmbStokNo.ValueMember = "Id";
                CmbStokNo.DisplayMember = "Stokno";
                CmbStokNo.SelectedValue = 0;
                start = false;
            }
            if (CmbMalzemeTuru.Text == "TEMİZLİK ÜRÜNLERİ")
            {
                CmbStokNo.DataSource = temizlikUrunleriManager.GetList();
                CmbStokNo.ValueMember = "Id";
                CmbStokNo.DisplayMember = "Stokno";
                CmbStokNo.SelectedValue = 0;
                start = false;
            }
            if (CmbMalzemeTuru.Text == "SARF MALZEME (DEPO)")
            {
                //CmbStokNo.DataSource = temizlikUrunleriManager.GetList();
                //CmbStokNo.ValueMember = "Id";
                //CmbStokNo.DisplayMember = "Stokno";
                //CmbStokNo.SelectedValue = 0;
                //start = false;
            }
            TxtTanim.Clear();
            TxtBirim.Clear();
        }

        private void CmbStokNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start)
            {
                return;
            }
            id = CmbStokNo.SelectedValue.ConInt();
            if (index==1)
            {
                DestekDepoAmbar ambar = ambarManager.Get(id);
                TxtTanim.Text = ambar.Tanim;
                TxtBirim.Text = ambar.Birim;
            }
            if(index == 2)
            {
                DestekDepoCayOcagi cayOcagi = cayOcagiManager.Get(id);
                TxtTanim.Text = cayOcagi.Tanim;
                TxtBirim.Text = cayOcagi.Birim;
            }
            if (index == 3)
            {
                DestekDepoElAletleri elAletleri = elAletleriManager.Get(id);
                TxtTanim.Text = elAletleri.Tanim;
                TxtBirim.Text = elAletleri.Birim;
            }
            if (index == 4)
            {
                DestekDepoIsGiysi depoIsGiysi = isGiysiManager.Get(id);
                TxtTanim.Text = depoIsGiysi.Tanim;
                TxtBirim.Text = depoIsGiysi.Birim;
            }
            if (index == 5)
            {
                DestekDepoKirtasiye kirtasiye = kirtasiyeManager.Get(id);
                TxtTanim.Text = kirtasiye.Tanim;
                TxtBirim.Text = kirtasiye.Birim;
            }
            if (index == 6)
            {
                DestekDepoKKD kkd = kKDManager.Get(id);
                TxtTanim.Text = kkd.Tanim;
                TxtBirim.Text = kkd.Birim;
            }
            if (index == 7)
            {
                DestekDepoTemizlikUrunleri temizlikUrunleri = temizlikUrunleriManager.Get(id);
                TxtTanim.Text = temizlikUrunleri.Tanim;
                TxtBirim.Text = temizlikUrunleri.Birim;
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (CmbMalzemeTuru.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Malzeme Türünü Belirleyiniz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (CmbStokNo.Text=="")
            {
                MessageBox.Show("Lütfen Bir Stok Numarası Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(CmbStokNo.Text+" Stok Nolu Malzemeyi Silmek İstediğinize Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                id = CmbStokNo.SelectedValue.ConInt();
                if (CmbMalzemeTuru.Text == "AMBAR")
                {
                    string mesaj = ambarManager.Delete(id);
                    if (mesaj!="OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show(CmbStokNo.Text + " Stok Nolu Kayıt Başarılya Silinmiştir.");
                }
                if (CmbMalzemeTuru.Text == "ÇAY OCAĞI")
                {
                    string mesaj = cayOcagiManager.Delete(id);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show(CmbStokNo.Text + " Stok Nolu Kayıt Başarılya Silinmiştir.");
                }
                if (CmbMalzemeTuru.Text == "EL ALETLERİ")
                {
                    string mesaj = elAletleriManager.Delete(id);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show(CmbStokNo.Text + " Stok Nolu Kayıt Başarılya Silinmiştir.");
                }
                if (CmbMalzemeTuru.Text == "İŞ GİYSİ")
                {
                    string mesaj = isGiysiManager.Delete(id);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show(CmbStokNo.Text + " Stok Nolu Kayıt Başarılya Silinmiştir.");
                }
                if (CmbMalzemeTuru.Text == "KIRTASİYE")
                {
                    string mesaj = kirtasiyeManager.Delete(id);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show(CmbStokNo.Text + " Stok Nolu Kayıt Başarılya Silinmiştir.");
                }
                if (CmbMalzemeTuru.Text == "KKD")
                {
                    string mesaj = kKDManager.Delete(id);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show(CmbStokNo.Text + " Stok Nolu Kayıt Başarılya Silinmiştir.");
                }
                if (CmbMalzemeTuru.Text == "TEMİZLİK ÜRÜNLERİ")
                {
                    string mesaj = temizlikUrunleriManager.Delete(id);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show(CmbStokNo.Text + " Stok Nolu Kayıt Başarılya Silinmiştir.");
                }
                Temizle();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (CmbMalzemeTuru.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Malzeme Türünü Belirleyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbStokNo.Text == "")
            {
                MessageBox.Show("Lütfen Bir Stok Numarası Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(CmbStokNo.Text + " Stok Nolu Malzemeyi Güncellemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                id = CmbStokNo.SelectedValue.ConInt();
                if (CmbMalzemeTuru.Text == "AMBAR")
                {
                    DestekDepoAmbar destekDepoAmbar = new DestekDepoAmbar(CmbStokNo.Text, TxtTanim.Text, TxtBirim.Text);
                    string mesaj = ambarManager.Update(destekDepoAmbar, id);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show(CmbStokNo.Text + " Stok Nolu Kayıt Başarılya Güncellenmiştir.");
                }
                if (CmbMalzemeTuru.Text == "ÇAY OCAĞI")
                {
                    DestekDepoCayOcagi destekDepoCay = new DestekDepoCayOcagi(CmbStokNo.Text, TxtTanim.Text, TxtBirim.Text);
                    string mesaj = cayOcagiManager.Update(destekDepoCay, id);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show(CmbStokNo.Text + " Stok Nolu Kayıt Başarılya Güncellenmiştir.");
                }
                if (CmbMalzemeTuru.Text == "EL ALETLERİ")
                {
                    DestekDepoElAletleri elAletleri = new DestekDepoElAletleri(CmbStokNo.Text, TxtTanim.Text, TxtBirim.Text);
                    string mesaj = elAletleriManager.Update(elAletleri, id);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show(CmbStokNo.Text + " Stok Nolu Kayıt Başarılya Güncellenmiştir.");
                }
                if (CmbMalzemeTuru.Text == "İŞ GİYSİ")
                {
                    DestekDepoIsGiysi destekDepoIsGiysi = new DestekDepoIsGiysi(CmbStokNo.Text, TxtTanim.Text, TxtBirim.Text);
                    string mesaj = isGiysiManager.Update(destekDepoIsGiysi, id);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show(CmbStokNo.Text + " Stok Nolu Kayıt Başarılya Güncellenmiştir.");
                }
                if (CmbMalzemeTuru.Text == "KIRTASİYE")
                {
                    DestekDepoKirtasiye destekDepoKirtasiye = new DestekDepoKirtasiye(CmbStokNo.Text, TxtTanim.Text, TxtBirim.Text);
                    string mesaj = kirtasiyeManager.Update(destekDepoKirtasiye, id);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show(CmbStokNo.Text + " Stok Nolu Kayıt Başarılya Güncellenmiştir.");
                }
                if (CmbMalzemeTuru.Text == "KKD")
                {
                    DestekDepoKKD KKD = new DestekDepoKKD(CmbStokNo.Text, TxtTanim.Text, TxtBirim.Text);
                    string mesaj = kKDManager.Update(KKD, id);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show(CmbStokNo.Text + " Stok Nolu Kayıt Başarılya Güncellenmiştir.");
                }
                if (CmbMalzemeTuru.Text == "TEMİZLİK ÜRÜNLERİ")
                {
                    DestekDepoTemizlikUrunleri temizlikUrunleri = new DestekDepoTemizlikUrunleri(CmbStokNo.Text, TxtTanim.Text, TxtBirim.Text);
                    string mesaj = temizlikUrunleriManager.Update(temizlikUrunleri, id);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show(CmbStokNo.Text + " Stok Nolu Kayıt Başarılya Güncellenmiştir.");
                }
                Temizle();
            }
        }
        string SiradakiStok(string sonKayitStok)
        {
            yeniSayiTxt = "";
            sayac = 0;
            array = null;
            array2 = null;
            yeniStok = "";
            array = sonKayitStok.Split('-');
            yeniSayi = array[2].ConInt() + 1;
            sayac = array[2].Length;
            array2 = array[2].ToString().Split('0');
            for (int i = 0; i < sayac; i++)
            {
                if (array2[i].ToString() != "")
                {
                    yeniSayiTxt += yeniSayi.ToString();
                    break;
                }
                else
                {
                    yeniSayiTxt += "0";
                }
            }
            yeniStok = array[0].ToString() + "-" + array[1].ToString() + "-" + yeniSayiTxt;
            return yeniStok;
        }
        private void BtnStokAl_Click(object sender, EventArgs e)
        {
            if (CmbMalzemeTuru.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Malzeme Türünü Belirleyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (CmbMalzemeTuru.Text == "AMBAR")
            {
                Temizle();
                List<DestekDepoAmbar> destekDepos = new List<DestekDepoAmbar>();
                destekDepos = ambarManager.GetList(); //BMPD-GKA-0008
                sonKayitStok = destekDepos[destekDepos.Count - 1].Stokno.ToString();
                CmbStokNo.Text= SiradakiStok(sonKayitStok);

            }
            if (CmbMalzemeTuru.Text == "ÇAY OCAĞI")
            {
                Temizle();
                List<DestekDepoCayOcagi> destekDepoCays = new List<DestekDepoCayOcagi>();
                destekDepoCays = cayOcagiManager.GetList();
                sonKayitStok = destekDepoCays[destekDepoCays.Count - 1].Stokno.ToString();
                CmbStokNo.Text = SiradakiStok(sonKayitStok);
            }
            if (CmbMalzemeTuru.Text == "EL ALETLERİ")
            {
                Temizle();
                List<DestekDepoElAletleri> destekDepoEls = new List<DestekDepoElAletleri>();
                destekDepoEls = elAletleriManager.GetList();
                sonKayitStok = destekDepoEls[destekDepoEls.Count - 1].Stokno.ToString();
                CmbStokNo.Text = SiradakiStok(sonKayitStok);
            }
            if (CmbMalzemeTuru.Text == "İŞ GİYSİ")
            {
                Temizle();
                List<DestekDepoIsGiysi> destekDepoIs = new List<DestekDepoIsGiysi>();
                destekDepoIs = isGiysiManager.GetList();
                sonKayitStok = destekDepoIs[destekDepoIs.Count - 1].Stokno.ToString();
                CmbStokNo.Text = SiradakiStok(sonKayitStok);
            }
            if (CmbMalzemeTuru.Text == "KIRTASİYE")
            {
                Temizle();
                List<DestekDepoKirtasiye> destekDepoKirtasiyes = new List<DestekDepoKirtasiye>();
                destekDepoKirtasiyes = kirtasiyeManager.GetList();
                sonKayitStok = destekDepoKirtasiyes[destekDepoKirtasiyes.Count - 1].Stokno.ToString();
                CmbStokNo.Text = SiradakiStok(sonKayitStok);
            }
            if (CmbMalzemeTuru.Text == "KKD")
            {
                Temizle();
                List<DestekDepoKKD> destekDepoKKDs = new List<DestekDepoKKD>();
                destekDepoKKDs = kKDManager.GetList();
                sonKayitStok = destekDepoKKDs[destekDepoKKDs.Count - 1].Stokno.ToString();
                CmbStokNo.Text = SiradakiStok(sonKayitStok);
            }
            if (CmbMalzemeTuru.Text == "TEMİZLİK ÜRÜNLERİ")
            {
                Temizle();
                List<DestekDepoTemizlikUrunleri> destekDepoTemizliks = new List<DestekDepoTemizlikUrunleri>();
                destekDepoTemizliks = temizlikUrunleriManager.GetList();
                sonKayitStok = destekDepoTemizliks[destekDepoTemizliks.Count - 1].Stokno.ToString();
                CmbStokNo.Text = SiradakiStok(sonKayitStok);
            }
            if (CmbMalzemeTuru.Text == "SARF MALZEME (DEPO)")
            {
                Temizle();
            }
        }
    }
}
