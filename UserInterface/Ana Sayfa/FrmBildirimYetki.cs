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
    public partial class FrmBildirimYetki : Form
    {
        PersonelKayitManager personelKayitManager;
        BildirimYetkiManager bildirimYetkiManager;

        List<BildirimYetki> bildirimYetkis;

        bool start = false;
        public FrmBildirimYetki()
        {
            InitializeComponent();
            personelKayitManager = PersonelKayitManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
        }

        private void FrmBildirimYetki_Load(object sender, EventArgs e)
        {
            Personeller();
            PersonellerBildirim();
            start = true;
        }
        void Personeller()
        {
            CmbPersonel.DataSource = personelKayitManager.PersonelAdSoyad();
            CmbPersonel.ValueMember = "Id";
            CmbPersonel.DisplayMember = "Adsoyad";
            CmbPersonel.SelectedValue = -1;
        }
        void PersonellerBildirim()
        {
            CmbBildirimPersonel.DataSource = personelKayitManager.PersonelAdSoyad();
            CmbBildirimPersonel.ValueMember = "Id";
            CmbBildirimPersonel.DisplayMember = "Adsoyad";
            CmbBildirimPersonel.SelectedValue = -1;
        }
        string Kontrol()
        {
            if (CmbPersonel.Text == "")
            {
                return "Lütfen öncelikle Personel bilgisini doldurunuz!";
            }
            if (CmbBildirimPersonel.Text == "")
            {
                return "Lütfen öncelikle Bildirim Alacak Personel bilgisini doldurunuz!";
            }
            if (CmbBildirimPersonel.Text == CmbPersonel.Text)
            {
                CmbPersonel.SelectedIndex = -1;
                CmbBildirimPersonel.SelectedIndex = -1;
                return "Personel zaten kendi yaptığı işlemlerde de bildirim alacaktır! Lütfen aynı personel bilgilerini eklemeyiniz!";
            }
            foreach (DataGridViewRow item in DtgList.Rows)
            {
                if (item.Cells["PersonelBildirim"].Value.ToString() == CmbBildirimPersonel.Text)
                {
                    return "Bu personel zaten eklendi!";
                }
            }
            return "OK";
        }
        
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            string kontrol = Kontrol();
            if (kontrol!="OK")
            {
                MessageBox.Show(kontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DtgList.Rows.Add();
            int sonIndex = DtgList.RowCount - 1;
            DtgList.Rows[sonIndex].Cells["Id"].Value = CmbBildirimPersonel.SelectedValue.ToString();
            DtgList.Rows[sonIndex].Cells["PersonelBildirim"].Value = CmbBildirimPersonel.Text;

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgList.Columns["Remove"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;

            CmbBildirimPersonel.SelectedIndex = -1;

        }

        private void DtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DtgList.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (DtgList.RowCount == 0)
            {
                MessageBox.Show("Lütfen öncelikle Bildirim Alacak Personeller Listesine Personelleri ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek isteğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                string sorumluId = "";

                BildirimYetki bildirimYetki = bildirimYetkiManager.Get(CmbPersonel.Text);

                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    sorumluId += item.Cells["Id"].Value.ToString() + ";";
                }
                int personeId = CmbPersonel.SelectedValue.ConInt();

                if (bildirimYetki == null)
                {
                    BildirimYetki bildirimYetki2 = new BildirimYetki(CmbPersonel.Text, personeId, sorumluId);
                    string mesaj = bildirimYetkiManager.Add(bildirimYetki2);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    BildirimYetki bildirimYetki3 = new BildirimYetki(bildirimYetki.Id, CmbPersonel.Text, personeId, sorumluId);
                    string mesaj = bildirimYetkiManager.Update(bildirimYetki3);
                    if (mesaj!="OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CmbPersonel.SelectedIndex = -1;
                CmbBildirimPersonel.SelectedIndex = -1;
                DtgList.Rows.Clear();
            }
            
        }

        private void CmbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start==false)
            {
                return;
            }
            string sorumluPersonel = "";
            bildirimYetkis = bildirimYetkiManager.GetList(CmbPersonel.Text);
            if (bildirimYetkis==null)
            {
                return;
            }
            foreach (BildirimYetki item in bildirimYetkis)
            {
                
                string[] array = item.SorumluId.Split(';');

                for (int i = 0; i < array.Length; i++)
                {
                    PersonelKayit personelKayit = personelKayitManager.Get(array[i].ConInt());
                    if (personelKayit==null)
                    {
                        return;
                    }
                    sorumluPersonel = personelKayit.Adsoyad;
                    DtgList.Rows.Add();
                    int sonIndex = DtgList.RowCount - 1;
                    DtgList.Rows[sonIndex].Cells["Id"].Value = array[i].ConInt();
                    DtgList.Rows[sonIndex].Cells["PersonelBildirim"].Value = sorumluPersonel;
                }

            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(CmbPersonel.Text + " Kişisine ait tüm bildirim yetkilerini silmek isteğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                foreach (BildirimYetki item in bildirimYetkis)
                {
                    bildirimYetkiManager.Delete(item.Id);
                }
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbPersonel.SelectedIndex = -1;
                CmbBildirimPersonel.SelectedIndex = -1;
                DtgList.Rows.Clear();
            }

        }
    }
}
