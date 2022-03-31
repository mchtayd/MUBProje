
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.advancedDataGridView2 = new ADGV.AdvancedDataGridView();
            this.Column35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.CmbCrmGorevAtanacakPer = new System.Windows.Forms.ComboBox();
            this.LblCrmMevcutIslemAdimi = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.CmbCrmIslemAdimlari = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.groupBox12.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.advancedDataGridView2);
            this.groupBox1.Location = new System.Drawing.Point(12, 641);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1476, 256);
            this.groupBox1.TabIndex = 335;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MALZEME DURUMLARI";
            // 
            // advancedDataGridView2
            // 
            this.advancedDataGridView2.AllowUserToAddRows = false;
            this.advancedDataGridView2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.advancedDataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.advancedDataGridView2.AutoGenerateContextFilters = true;
            this.advancedDataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.advancedDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column35,
            this.Column36,
            this.Column37,
            this.Column38,
            this.Column39,
            this.Column40,
            this.Column41,
            this.Column42,
            this.Column44,
            this.Column43,
            this.Column45});
            this.advancedDataGridView2.Cursor = System.Windows.Forms.Cursors.Default;
            this.advancedDataGridView2.DateWithTime = false;
            this.advancedDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView2.Location = new System.Drawing.Point(3, 16);
            this.advancedDataGridView2.MultiSelect = false;
            this.advancedDataGridView2.Name = "advancedDataGridView2";
            this.advancedDataGridView2.ReadOnly = true;
            this.advancedDataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridView2.Size = new System.Drawing.Size(1470, 237);
            this.advancedDataGridView2.TabIndex = 4;
            this.advancedDataGridView2.TimeFilter = false;
            // 
            // Column35
            // 
            this.Column35.HeaderText = "ID";
            this.Column35.MinimumWidth = 22;
            this.Column35.Name = "Column35";
            this.Column35.ReadOnly = true;
            this.Column35.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column35.Width = 43;
            // 
            // Column36
            // 
            this.Column36.HeaderText = "STOK NO";
            this.Column36.MinimumWidth = 22;
            this.Column36.Name = "Column36";
            this.Column36.ReadOnly = true;
            this.Column36.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column36.Width = 74;
            // 
            // Column37
            // 
            this.Column37.HeaderText = "TANIM";
            this.Column37.MinimumWidth = 22;
            this.Column37.Name = "Column37";
            this.Column37.ReadOnly = true;
            this.Column37.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column37.Width = 66;
            // 
            // Column38
            // 
            this.Column38.HeaderText = "SERİ NO (ÇIKAN)";
            this.Column38.MinimumWidth = 22;
            this.Column38.Name = "Column38";
            this.Column38.ReadOnly = true;
            this.Column38.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column38.Width = 107;
            // 
            // Column39
            // 
            this.Column39.HeaderText = "SERİ NO (GİREN)";
            this.Column39.MinimumWidth = 22;
            this.Column39.Name = "Column39";
            this.Column39.ReadOnly = true;
            this.Column39.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column39.Width = 109;
            // 
            // Column40
            // 
            this.Column40.HeaderText = "REVİZYON";
            this.Column40.MinimumWidth = 22;
            this.Column40.Name = "Column40";
            this.Column40.ReadOnly = true;
            this.Column40.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column40.Width = 87;
            // 
            // Column41
            // 
            this.Column41.HeaderText = "MİKTAR";
            this.Column41.MinimumWidth = 22;
            this.Column41.Name = "Column41";
            this.Column41.ReadOnly = true;
            this.Column41.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column41.Width = 73;
            // 
            // Column42
            // 
            this.Column42.HeaderText = "SİSTEM CİHAZ ÇALIŞMA DURUMU";
            this.Column42.MinimumWidth = 22;
            this.Column42.Name = "Column42";
            this.Column42.ReadOnly = true;
            this.Column42.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column42.Width = 145;
            // 
            // Column44
            // 
            this.Column44.HeaderText = "SİSTEM CİHAZ FİZİKSEL DURUMU";
            this.Column44.MinimumWidth = 22;
            this.Column44.Name = "Column44";
            this.Column44.ReadOnly = true;
            this.Column44.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column44.Width = 145;
            // 
            // Column43
            // 
            this.Column43.HeaderText = "MALZEMEYE YAPILACAK İŞLEM";
            this.Column43.MinimumWidth = 22;
            this.Column43.Name = "Column43";
            this.Column43.ReadOnly = true;
            this.Column43.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column43.Width = 148;
            // 
            // Column45
            // 
            this.Column45.HeaderText = "MEVCUT MALZEME DURUMU";
            this.Column45.MinimumWidth = 22;
            this.Column45.Name = "Column45";
            this.Column45.ReadOnly = true;
            this.Column45.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column45.Width = 168;
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
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(20, 589);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 37);
            this.button1.TabIndex = 420;
            this.button1.Text = "KAYDET";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(498, 462);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(421, 121);
            this.richTextBox1.TabIndex = 421;
            this.richTextBox1.Text = "";
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
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(145, 589);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 37);
            this.button2.TabIndex = 425;
            this.button2.Text = "TEMİZLE";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgList);
            this.groupBox2.Location = new System.Drawing.Point(12, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1531, 395);
            this.groupBox2.TabIndex = 426;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AÇIK ARIZALAR";
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
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.CmbCrmGorevAtanacakPer);
            this.groupBox12.Controls.Add(this.LblCrmMevcutIslemAdimi);
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
            // CmbCrmGorevAtanacakPer
            // 
            this.CmbCrmGorevAtanacakPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCrmGorevAtanacakPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbCrmGorevAtanacakPer.FormattingEnabled = true;
            this.CmbCrmGorevAtanacakPer.Location = new System.Drawing.Point(162, 54);
            this.CmbCrmGorevAtanacakPer.Name = "CmbCrmGorevAtanacakPer";
            this.CmbCrmGorevAtanacakPer.Size = new System.Drawing.Size(279, 23);
            this.CmbCrmGorevAtanacakPer.TabIndex = 435;
            // 
            // LblCrmMevcutIslemAdimi
            // 
            this.LblCrmMevcutIslemAdimi.AutoSize = true;
            this.LblCrmMevcutIslemAdimi.BackColor = System.Drawing.Color.Yellow;
            this.LblCrmMevcutIslemAdimi.Location = new System.Drawing.Point(162, 29);
            this.LblCrmMevcutIslemAdimi.Name = "LblCrmMevcutIslemAdimi";
            this.LblCrmMevcutIslemAdimi.Size = new System.Drawing.Size(19, 13);
            this.LblCrmMevcutIslemAdimi.TabIndex = 450;
            this.LblCrmMevcutIslemAdimi.Text = "00";
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
            // FrmBildirimOnayi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1555, 909);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBildirimOnayi";
            this.Text = "FrmBildirimOnayi";
            this.Load += new System.EventHandler(this.FrmBildirimOnayi_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView advancedDataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column35;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column36;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column37;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column38;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column39;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column40;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column41;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column42;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column44;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column43;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column45;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.ComboBox CmbCrmGorevAtanacakPer;
        private System.Windows.Forms.Label LblCrmMevcutIslemAdimi;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.ComboBox CmbCrmIslemAdimlari;
    }
}