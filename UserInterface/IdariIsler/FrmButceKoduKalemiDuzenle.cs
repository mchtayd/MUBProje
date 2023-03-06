using Business;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;
using UserInterface.STS;

namespace UserInterface.IdariIsler
{
    public partial class FrmButceKoduKalemiDuzenle : Form
    {
        ButceKoduKalemiManager butceKoduManager;
        List<ButceKodu> butceKodus;
        ComboManager comboManager;

        int id;
        string butceKodu = "", comboAd, comboIdler, idler;
        public int comboId;
        public FrmButceKoduKalemiDuzenle()
        {
            InitializeComponent();
            butceKoduManager = ButceKoduKalemiManager.GetInstance();
            comboManager = ComboManager.GetInstance();
        }

        private void FrmButceKoduKalemi_Load(object sender, EventArgs e)
        {
            ButceKodlariFill();
            Firma();
            ComboSeciliControl();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageButceKoduDuzenle"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        void ComboSeciliControl()
        {
            if (comboId == 0)
            {
                return;
            }

            foreach (DataGridViewRow item in DtgList.Rows)
            {
                idler = item.Cells["ComboId"].Value.ToString();
                string[] array = idler.Split(';');

                foreach (string item2 in array)
                {
                    if (item2 == "")
                    {
                        continue;
                    }
                    if (item2.ConInt() != comboId)
                    {

                        if (array.Length <= 2)
                        {
                            item.Cells["Secim"].Value = false;
                        }
                    }
                    else
                    {
                        item.Cells["Secim"].Value = true;
                    }
                }

            }

        }


        void ButceKodlariFill()
        {
            butceKodus = butceKoduManager.GetList();
            dataBinder.DataSource = butceKodus.ToDataTable();
            DtgList.DataSource = dataBinder;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["ButceKoduKalemi"].HeaderText = "BÜTÇE KODU/KALEMİ";
            DtgList.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            DtgList.Columns["GiderKarsilayacakFirma"].HeaderText = "GİDER KARŞILAYACAK FİRMA";
            DtgList.Columns["ComboId"].Visible = false;
            DtgList.Columns["Secim"].HeaderText = "SEÇİM";
            DtgList.Columns["Baslik"].Visible = false;

            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }

            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            butceKodu = DtgList.CurrentRow.Cells["ButceKoduKalemi"].Value.ToString();

            string[] array = butceKodu.Split('/');

            TxtButceKodu.Text = array[0];
            TxtTanimi.Text = array[1];

            TxtAciklama.Text = DtgList.CurrentRow.Cells["Aciklama"].Value.ToString();
            CmbFirma.Text = DtgList.CurrentRow.Cells["GiderKarsilayacakFirma"].Value.ToString();


            comboIdler = DtgList.CurrentRow.Cells["ComboId"].Value.ToString();

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        void Temizle()
        {
            TxtButceKodu.Clear(); TxtTanimi.Clear(); TxtAciklama.Clear(); CmbFirma.SelectedIndex = -1;
            id = 0;
        }
        public void Firma()
        {
            CmbFirma.DataSource = comboManager.GetList("BUTCE_FIRMA");
            CmbFirma.ValueMember = "Id";
            CmbFirma.DisplayMember = "Baslik";
            CmbFirma.SelectedValue = 0;
        }
        string Control()
        {
            if (TxtButceKodu.Text == "")
            {
                return "Lütfen öncelikle Bütçe Kodu bilgisini doldurunuz!";
            }
            if (TxtTanimi.Text == "")
            {
                return "Lütfen öncelikle Bütçe Tanımı bilgisini doldurunuz!";
            }
            return "OK";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string mesaj = Control();
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string butceK = TxtButceKodu.Text + "/" + TxtTanimi.Text;
                ButceKodu butceKodu = new ButceKodu(butceK, TxtAciklama.Text, CmbFirma.Text);
                mesaj = butceKoduManager.Add(butceKodu);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ButceKodlariFill();
                Temizle();

            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string mesaj = butceKoduManager.Delete(id);
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ButceKodlariFill();
            Temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            List<ButceKodu> butceKodus = new List<ButceKodu>();
            DialogResult dr = MessageBox.Show("Bilgileri güncellemek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    comboIdler = "0";
                    ButceKodu butceKodu2 = new ButceKodu(item.Cells["Id"].Value.ConInt(), item.Cells["ButceKoduKalemi"].Value.ToString(), item.Cells["Aciklama"].Value.ToString(), item.Cells["GiderKarsilayacakFirma"].Value.ToString(), comboIdler.ToString(), item.Cells["Secim"].Value.ConBool());

                    string[] oncekiIdler2 = item.Cells["ComboId"].Value.ToString().Split(';');
                    bool secim = butceKodu2.Secim;
                    foreach (string item2 in oncekiIdler2)
                    {
                        if (item2 == "")
                        {
                            if (secim==true)
                            {
                                if (comboIdler == "")
                                {
                                    comboIdler = comboId.ToString() + ";";
                                }
                            }
                            continue;
                        }
                        else
                        {
                            if (secim == true)
                            {
                                if (item2 == "0")
                                {
                                    comboIdler = comboId + ";";
                                }
                                else
                                {
                                    if (item2.ConInt() == comboId)
                                    {
                                        comboIdler = item2 + ";";
                                    }
                                    else
                                    {
                                        comboIdler = item2 + ";" + comboId + ";";
                                        break;
                                    }
                                }
                            }

                            else
                            {
                                if (item2.ConInt() != comboId)
                                {
                                    comboIdler = item2 + ";";
                                }
                            }
                        }
                    }

                    ButceKodu butceKodu3 = new ButceKodu(item.Cells["Id"].Value.ConInt(), item.Cells["ButceKoduKalemi"].Value.ToString(), item.Cells["Aciklama"].Value.ToString(), item.Cells["GiderKarsilayacakFirma"].Value.ToString(), comboIdler.ToString(), item.Cells["Secim"].Value.ConBool());
                    butceKoduManager.Update(butceKodu3);

                }
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
            }
        }

        bool tumu = false;

        private void BtnTumunuSec_Click(object sender, EventArgs e)
        {
            if (tumu == false)
            {
                tumu = true;
                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    item.Cells["Secim"].Value = false;
                }
            }
            else
            {
                tumu = false;
                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    item.Cells["Secim"].Value = true;
                }
            }
        }

        void Yenile()
        {
            if (comboId == 1)
            {
                var form = (FrmHarcamasiYapilanSat)Application.OpenForms["FrmHarcamasiYapilanSat"];
                if (form != null)
                {
                    form.ButceKoduKalemi();
                }
            }
            if (comboId == 2)
            {
                var form = (FrmSatTalebi)Application.OpenForms["FrmSatTalebi"];
                if (form != null)
                {
                    form.ButceKoduKalemi2();
                }
            }
        }


        private void BtnGiderFirma_Click(object sender, EventArgs e)
        {
            comboAd = "BUTCE_FIRMA";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }
    }
}
