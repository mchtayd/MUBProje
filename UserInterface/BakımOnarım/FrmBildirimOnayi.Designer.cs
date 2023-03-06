
namespace UserInterface.BakımOnarım
{
    partial class FrmBildirimOnayi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.TxtYapilanIslemler = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.BtnTemizle = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.CmbGorevAtanacakPersonel = new System.Windows.Forms.ComboBox();
            this.LblMevcutIslemAdimi = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.CmbCrmIslemAdimlari = new System.Windows.Forms.ComboBox();
            this.DtgMalzemeListesi = new ADGV.AdvancedDataGridView();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1555, 27);
            this.panel1.TabIndex = 313;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.BtnCancel.Location = new System.Drawing.Point(12, 4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(35, 23);
            this.BtnCancel.TabIndex = 19;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgMalzemeListesi);
            this.groupBox1.Location = new System.Drawing.Point(12, 641);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1476, 256);
            this.groupBox1.TabIndex = 335;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MALZEME DURUMLARI";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.webBrowser1);
            this.groupBox3.Location = new System.Drawing.Point(925, 457);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(610, 126);
            this.groupBox3.TabIndex = 338;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ekler";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(604, 107);
            this.webBrowser1.TabIndex = 0;
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(20, 589);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(119, 37);
            this.BtnKaydet.TabIndex = 420;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // TxtYapilanIslemler
            // 
            this.TxtYapilanIslemler.Location = new System.Drawing.Point(498, 462);
            this.TxtYapilanIslemler.Name = "TxtYapilanIslemler";
            this.TxtYapilanIslemler.Size = new System.Drawing.Size(421, 121);
            this.TxtYapilanIslemler.TabIndex = 421;
            this.TxtYapilanIslemler.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(498, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 422;
            this.label1.Text = "Açıklama:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(17, 431);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 423;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(117, 431);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 424;
            this.TxtTop.Text = "00";
            // 
            // BtnTemizle
            // 
            this.BtnTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTemizle.Location = new System.Drawing.Point(145, 589);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(119, 37);
            this.BtnTemizle.TabIndex = 425;
            this.BtnTemizle.Text = "TEMİZLE";
            this.BtnTemizle.UseVisualStyleBackColor = true;
            this.BtnTemizle.Click += new System.EventHandler(this.BtnTemizle_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgList);
            this.groupBox2.Location = new System.Drawing.Point(12, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1531, 395);
            this.groupBox2.TabIndex = 426;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BİLDİRİM ONAYI";
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgList.AutoGenerateContextFilters = true;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgList.DateWithTime = false;
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(3, 16);
            this.DtgList.MultiSelect = false;
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgList.Size = new System.Drawing.Size(1525, 376);
            this.DtgList.TabIndex = 2;
            this.DtgList.TimeFilter = false;
            this.DtgList.SortStringChanged += new System.EventHandler(this.DtgList_SortStringChanged);
            this.DtgList.FilterStringChanged += new System.EventHandler(this.DtgList_FilterStringChanged);
            this.DtgList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgList_CellMouseClick);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.CmbGorevAtanacakPersonel);
            this.groupBox12.Controls.Add(this.LblMevcutIslemAdimi);
            this.groupBox12.Controls.Add(this.label70);
            this.groupBox12.Controls.Add(this.label79);
            this.groupBox12.Controls.Add(this.label95);
            this.groupBox12.Controls.Add(this.CmbCrmIslemAdimlari);
            this.groupBox12.Location = new System.Drawing.Point(20, 457);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(472, 126);
            this.groupBox12.TabIndex = 466;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "GÖREV ATA";
            // 
            // CmbGorevAtanacakPersonel
            // 
            this.CmbGorevAtanacakPersonel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbGorevAtanacakPersonel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbGorevAtanacakPersonel.FormattingEnabled = true;
            this.CmbGorevAtanacakPersonel.Location = new System.Drawing.Point(162, 54);
            this.CmbGorevAtanacakPersonel.Name = "CmbGorevAtanacakPersonel";
            this.CmbGorevAtanacakPersonel.Size = new System.Drawing.Size(279, 23);
            this.CmbGorevAtanacakPersonel.TabIndex = 435;
            // 
            // LblMevcutIslemAdimi
            // 
            this.LblMevcutIslemAdimi.AutoSize = true;
            this.LblMevcutIslemAdimi.BackColor = System.Drawing.Color.Yellow;
            this.LblMevcutIslemAdimi.Location = new System.Drawing.Point(162, 29);
            this.LblMevcutIslemAdimi.Name = "LblMevcutIslemAdimi";
            this.LblMevcutIslemAdimi.Size = new System.Drawing.Size(19, 13);
            this.LblMevcutIslemAdimi.TabIndex = 450;
            this.LblMevcutIslemAdimi.Text = "00";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label70.Location = new System.Drawing.Point(19, 86);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(137, 15);
            this.label70.TabIndex = 433;
            this.label70.Text = "Bir Sonraki İşlem Adımı:";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(55, 29);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(101, 13);
            this.label79.TabIndex = 449;
            this.label79.Text = "Mevcut İşlem Adımı:";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label95.Location = new System.Drawing.Point(9, 57);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(147, 15);
            this.label95.TabIndex = 434;
            this.label95.Text = "Görev Atanacak Personel:";
            // 
            // CmbCrmIslemAdimlari
            // 
            this.CmbCrmIslemAdimlari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCrmIslemAdimlari.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbCrmIslemAdimlari.FormattingEnabled = true;
            this.CmbCrmIslemAdimlari.Location = new System.Drawing.Point(162, 83);
            this.CmbCrmIslemAdimlari.Name = "CmbCrmIslemAdimlari";
            this.CmbCrmIslemAdimlari.Size = new System.Drawing.Size(279, 23);
            this.CmbCrmIslemAdimlari.TabIndex = 436;
            // 
            // DtgMalzemeListesi
            // 
            this.DtgMalzemeListesi.AllowUserToAddRows = false;
            this.DtgMalzemeListesi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgMalzemeListesi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgMalzemeListesi.AutoGenerateContextFilters = true;
            this.DtgMalzemeListesi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgMalzemeListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgMalzemeListesi.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgMalzemeListesi.DateWithTime = false;
            this.DtgMalzemeListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgMalzemeListesi.Location = new System.Drawing.Point(3, 16);
            this.DtgMalzemeListesi.MultiSelect = false;
            this.DtgMalzemeListesi.Name = "DtgMalzemeListesi";
            this.DtgMalzemeListesi.ReadOnly = true;
            this.DtgMalzemeListesi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgMalzemeListesi.Size = new System.Drawing.Size(1470, 237);
            this.DtgMalzemeListesi.TabIndex = 4;
            this.DtgMalzemeListesi.TimeFilter = false;
            // 
            // FrmBildirimOnayi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1555, 909);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnTemizle);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtYapilanIslemler);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBildirimOnayi";
            this.Text = "FrmBildirimOnayi";
            this.Load += new System.EventHandler(this.FrmBildirimOnayi_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeListesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.RichTextBox TxtYapilanIslemler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Button BtnTemizle;
        private System.Windows.Forms.GroupBox groupBox2;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.ComboBox CmbGorevAtanacakPersonel;
        private System.Windows.Forms.Label LblMevcutIslemAdimi;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.ComboBox CmbCrmIslemAdimlari;
        private System.Windows.Forms.BindingSource dataBinder;
        private ADGV.AdvancedDataGridView DtgMalzemeListesi;
    }
}