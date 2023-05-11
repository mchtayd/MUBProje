using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Presentation;
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
using UserInterface.IdariIşler;
using UserInterface.STS;
using Color = System.Drawing.Color;

namespace UserInterface.IdariIsler
{
    public partial class FrmBolumEdit : Form
    {
        SirketBolumManager sirketBolumManager;
        string bolumAdi1, bolumAdi2 = "";
        List<SirketBolum> sirketBolumsGenel1 = new List<SirketBolum>();
        List<SirketBolum> sirketBolumsGenel2 = new List<SirketBolum>();
        List<SirketBolum> sirketBolumsGenel3 = new List<SirketBolum>();

        List<SirketBolum> sirketBolumsSil1 = new List<SirketBolum>();
        List<SirketBolum> sirketBolumsSil2 = new List<SirketBolum>();
        List<SirketBolum> sirketBolumsSil3 = new List<SirketBolum>();

        public FrmBolumEdit()
        {
            InitializeComponent();
            sirketBolumManager = SirketBolumManager.GetInstance();
        }

        private void FrmBolumEdit_Load(object sender, EventArgs e)
        {
            DataDisplayBolum1();
        }

        void DataDisplayBolum1()
        {
            sirketBolumsGenel1 = sirketBolumManager.GetListBolumNo(1);
            
            foreach (SirketBolum item in sirketBolumsGenel1)
            {
                DtgBolum1.Rows.Add();
                int sonSatir = DtgBolum1.RowCount - 1;
                DtgBolum1.Rows[sonSatir].Cells["Bolum1"].Value = item.Bolum;
                DtgBolum1.Rows[sonSatir].Cells["Id1"].Value = item.Id;

                DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgBolum1.Columns["Remove1"];
                c.FlatStyle = FlatStyle.Popup;
                c.DefaultCellStyle.ForeColor = Color.Red;
                c.DefaultCellStyle.BackColor = Color.Gainsboro;
            }

        }

        private void DtgBolum1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgBolum1.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DtgBolum1.RowCount==0)
            {
                return;
            }

            DtgBolum2.Rows.Clear();
            DtgBolum3.Rows.Clear();

            //if (bolumAdi1 != DtgBolum1.CurrentRow.Cells["Bolum1"].Value.ToString())
            //{
            //    DtgBolum2.Rows.Clear();
            //    DtgBolum3.Rows.Clear();
            //}

            bolumAdi1 = DtgBolum1.CurrentRow.Cells["Bolum1"].Value.ToString();

            sirketBolumsGenel2 = sirketBolumManager.GetList(bolumAdi1);

            foreach (SirketBolum item in sirketBolumsGenel2)
            {
                DtgBolum2.Rows.Add();
                int sonSatir = DtgBolum2.RowCount - 1;
                DtgBolum2.Rows[sonSatir].Cells["Bolum2"].Value = item.Bolum;
                DtgBolum2.Rows[sonSatir].Cells["Id2"].Value = item.Id;

                DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgBolum2.Columns["Remove2"];
                c.FlatStyle = FlatStyle.Popup;
                c.DefaultCellStyle.ForeColor = Color.Red;
                c.DefaultCellStyle.BackColor = Color.Gainsboro;
            }

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (TxtBolum1.Text=="")
            {
                MessageBox.Show("Lütfen Bölüm 1 adını yazınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DtgBolum1.Rows.Add();
            int sonSatir = DtgBolum1.RowCount - 1;
            DtgBolum1.Rows[sonSatir].Cells["Bolum1"].Value = TxtBolum1.Text;

            TxtBolum1.Clear();
        }


        private void DtgBolum1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string bolum = DtgBolum1.CurrentRow.Cells["Bolum1"].Value.ToString();
                int id = DtgBolum1.CurrentRow.Cells["Id1"].Value.ConInt();


                DialogResult dr = MessageBox.Show(bolum + " Adlı bölümü silmek istediğinize emin misiniz?\nBu bölüme bağlı diğer bölümlerde silinecektir!", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr==DialogResult.Yes)
                {
                    List<SirketBolum> sirketBolumsSilinecekler1 = new List<SirketBolum>();
                    List<SirketBolum> sirketBolumsSilinecekler2 = new List<SirketBolum>();

                    sirketBolumsSilinecekler1 = sirketBolumManager.GetList(bolum);

                    foreach (SirketBolum item in sirketBolumsSilinecekler1)
                    {
                        sirketBolumsSilinecekler2 = sirketBolumManager.GetList(item.Bolum);
                    }
                    
                    foreach (SirketBolum item in sirketBolumsSilinecekler2)
                    {
                        sirketBolumManager.Delete(item.Id);
                    }

                    foreach (SirketBolum item in sirketBolumsSilinecekler1)
                    {
                        sirketBolumManager.Delete(item.Id);
                    }

                    sirketBolumManager.Delete(id);

                    DtgBolum1.Rows.RemoveAt(e.RowIndex);

                    DtgBolum2.Rows.Clear();
                    DtgBolum3.Rows.Clear();
                }

            }
        }

        private void BtnEkle2_Click(object sender, EventArgs e)
        {
            if (TxtBolum2.Text=="")
            {
                MessageBox.Show("Lütfen Bölüm 2 adını yazınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (bolumAdi1=="")
            {
                MessageBox.Show("Lütfen Bölüm 1 Listesinden bir bölümün üzerine tıklayıp daha sonra ilgili bölümün alt kategorisi olarak ekleme yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DtgBolum2.Rows.Add();
            int sonSatir = DtgBolum2.RowCount - 1;
            DtgBolum2.Rows[sonSatir].Cells["Bolum2"].Value = TxtBolum2.Text;
            TxtBolum2.Clear();

        }

        private void DtgBolum2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgBolum2.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DtgBolum2.RowCount == 0)
            {
                return;
            }

            DtgBolum3.Rows.Clear();

            //if (bolumAdi2 != DtgBolum2.CurrentRow.Cells["Bolum2"].Value.ToString())
            //{
            //    DtgBolum3.Rows.Clear();
            //}

            bolumAdi2 = DtgBolum2.CurrentRow.Cells["Bolum2"].Value.ToString();

            sirketBolumsGenel3 = sirketBolumManager.GetList(bolumAdi2);

            foreach (SirketBolum item in sirketBolumsGenel3)
            {
                DtgBolum3.Rows.Add();
                int sonSatir = DtgBolum3.RowCount - 1;
                DtgBolum3.Rows[sonSatir].Cells["Bolum3"].Value = item.Bolum;
                DtgBolum3.Rows[sonSatir].Cells["Id3"].Value = item.Id;

                DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgBolum3.Columns["Remove3"];
                c.FlatStyle = FlatStyle.Popup;
                c.DefaultCellStyle.ForeColor = Color.Red;
                c.DefaultCellStyle.BackColor = Color.Gainsboro;
            }
        }

        private void DtgBolum2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string bolum = DtgBolum2.CurrentRow.Cells["Bolum2"].Value.ToString();
                int id = DtgBolum2.CurrentRow.Cells["Id2"].Value.ConInt();

                DialogResult dr = MessageBox.Show(bolum + " Adlı bölümü silmek istediğinize emin misiniz?\nBu bölüme bağlı diğer bölümlerde silinecektir!", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                List<SirketBolum> sirketBolumsSilinecekler1 = new List<SirketBolum>();

                sirketBolumsSilinecekler1 = sirketBolumManager.GetList(bolum);

                foreach (SirketBolum item in sirketBolumsSilinecekler1)
                {
                    sirketBolumManager.Delete(item.Id);
                }

                sirketBolumManager.Delete(id);

                DtgBolum2.Rows.RemoveAt(e.RowIndex);
                DtgBolum3.Rows.Clear();
            }
        }

        private void DtgBolum3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string bolum = DtgBolum3.CurrentRow.Cells["Bolum3"].Value.ToString();
                int id = DtgBolum3.CurrentRow.Cells["Id3"].Value.ConInt();

                DialogResult dr = MessageBox.Show(bolum + " Adlı bölümü silmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr==DialogResult.Yes)
                {
                    sirketBolumManager.Delete(id);
                    DtgBolum3.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string control = Control();
            if (control!="OK")
            {
                MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr =  MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                if (sirketBolumsGenel1.Count==0)
                {
                    foreach (DataGridViewRow item in DtgBolum1.Rows)
                    {
                        SirketBolum sirketBolum = new SirketBolum(item.Cells["Bolum1"].Value.ToString(), "MÜB PROJE DİREKTÖRLÜĞÜ", 1);
                        sirketBolumManager.Add(sirketBolum);
                    }
                }

                else
                {
                    List<SirketBolum> sirketBolumsControl= new List<SirketBolum>();
                    List<SirketBolum> sirketBolums1 = new List<SirketBolum>();
                    foreach (DataGridViewRow item in DtgBolum1.Rows)
                    {
                        SirketBolum sirketBolum = new SirketBolum(item.Cells["Bolum1"].Value.ToString(), "MÜB PROJE DİREKTÖRLÜĞÜ", 1);
                        sirketBolums1.Add(sirketBolum);
                    }
                    // var Sonuc = Tablo1.Where(p => !Tablo2.Select(i=>i.AlanID).Contains(p.AlanID));

                    sirketBolumsControl = sirketBolums1.Where(x => !sirketBolumsGenel1.Select(y => y.Bolum).Contains(x.Bolum)).ToList();

                    foreach (SirketBolum item in sirketBolumsControl)
                    {
                        sirketBolumManager.Add(item);
                    }
                }

                if (sirketBolumsGenel2.Count == 0)
                {
                    foreach (DataGridViewRow item in DtgBolum2.Rows)
                    {
                        SirketBolum sirketBolum = new SirketBolum(item.Cells["Bolum2"].Value.ToString(), bolumAdi1, 2);
                        sirketBolumManager.Add(sirketBolum);
                    }
                }

                else
                {
                    List<SirketBolum> sirketBolumsControl = new List<SirketBolum>();
                    List<SirketBolum> sirketBolums1 = new List<SirketBolum>();
                    foreach (DataGridViewRow item in DtgBolum2.Rows)
                    {
                        SirketBolum sirketBolum = new SirketBolum(item.Cells["Bolum2"].Value.ToString(), bolumAdi1, 2);
                        sirketBolums1.Add(sirketBolum);
                    }
                    // var Sonuc = Tablo1.Where(p => !Tablo2.Select(i=>i.AlanID).Contains(p.AlanID));
                    sirketBolumsControl = sirketBolums1.Where(x => !sirketBolumsGenel2.Select(y => y.Bolum).Contains(x.Bolum)).ToList();
                    foreach (SirketBolum item in sirketBolumsControl)
                    {
                        sirketBolumManager.Add(item);
                    }
                }

                if (sirketBolumsGenel3.Count == 0)
                {
                    foreach (DataGridViewRow item in DtgBolum3.Rows)
                    {
                        SirketBolum sirketBolum = new SirketBolum(item.Cells["Bolum3"].Value.ToString(), bolumAdi2, 3);
                        sirketBolumManager.Add(sirketBolum);
                    }
                }
                else
                {
                    List<SirketBolum> sirketBolumsControl = new List<SirketBolum>();
                    List<SirketBolum> sirketBolums1 = new List<SirketBolum>();
                    foreach (DataGridViewRow item in DtgBolum3.Rows)
                    {
                        SirketBolum sirketBolum = new SirketBolum(item.Cells["Bolum3"].Value.ToString(), bolumAdi2, 3);
                        sirketBolums1.Add(sirketBolum);
                    }
                    // var Sonuc = Tablo1.Where(p => !Tablo2.Select(i=>i.AlanID).Contains(p.AlanID));
                    sirketBolumsControl = sirketBolums1.Where(x => !sirketBolumsGenel3.Select(y => y.Bolum).Contains(x.Bolum)).ToList();
                    foreach (SirketBolum item in sirketBolumsControl)
                    {
                        sirketBolumManager.Add(item);
                    }
                }

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Temizle();
            }

        }
        void Temizle() 
        {
            bolumAdi1 = "";
            bolumAdi2 = "";
            sirketBolumsGenel1.Clear();
            sirketBolumsGenel2.Clear();
            sirketBolumsGenel3.Clear();
            DtgBolum1.Rows.Clear();
            DtgBolum2.Rows.Clear();
            DtgBolum3.Rows.Clear();

            DataDisplayBolum1();
        }
        string Control()
        {
            return "OK";
        }

        private void FrmBolumEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmPersonelKayit frmPersonelKayit = (FrmPersonelKayit)Application.OpenForms["FrmPersonelKayit"];
            frmPersonelKayit.SirketBolumler1();

        }

        private void BtnEkle3_Click(object sender, EventArgs e)
        {
            if (TxtBolum3.Text == "")
            {
                MessageBox.Show("Lütfen Bölüm 3 adını yazınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (bolumAdi2 == "")
            {
                MessageBox.Show("Lütfen Bölüm 2 Listesinden bir bölümün üzerine tıklayıp daha sonra ilgili bölümün alt kategorisi olarak ekleme yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DtgBolum3.Rows.Add();
            int sonSatir = DtgBolum3.RowCount - 1;
            DtgBolum3.Rows[sonSatir].Cells["Bolum3"].Value = TxtBolum3.Text;
            TxtBolum3.Clear();
        }
    }
}
