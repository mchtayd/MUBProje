
namespace UserInterface.BakımOnarım
{
    partial class FrmYolDurumlari
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.TxtAciklama = new System.Windows.Forms.RichTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.CmbYolDurumu = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.CmbBolgeAdi = new System.Windows.Forms.ComboBox();
            this.TxtBolgeAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgList = new System.Windows.Forms.DataGridView();
            this.BolgeAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Donem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YolDurumu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnEkle = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1453, 31);
            this.panel1.TabIndex = 45;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.BtnCancel.Location = new System.Drawing.Point(14, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(41, 27);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(100, 118);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(19, 13);
            this.label31.TabIndex = 157;
            this.label31.Text = "00";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(47, 118);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(50, 13);
            this.label30.TabIndex = 156;
            this.label30.Text = "DÖNEM:";
            // 
            // TxtAciklama
            // 
            this.TxtAciklama.Location = new System.Drawing.Point(103, 179);
            this.TxtAciklama.Name = "TxtAciklama";
            this.TxtAciklama.Size = new System.Drawing.Size(457, 71);
            this.TxtAciklama.TabIndex = 154;
            this.TxtAciklama.Text = "";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(34, 182);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 153;
            this.label29.Text = "AÇIKLAMA:";
            // 
            // CmbYolDurumu
            // 
            this.CmbYolDurumu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYolDurumu.FormattingEnabled = true;
            this.CmbYolDurumu.Items.AddRange(new object[] {
            "AÇIK",
            "KAPALI",
            "KISMİ"});
            this.CmbYolDurumu.Location = new System.Drawing.Point(103, 145);
            this.CmbYolDurumu.Name = "CmbYolDurumu";
            this.CmbYolDurumu.Size = new System.Drawing.Size(139, 21);
            this.CmbYolDurumu.TabIndex = 152;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(14, 149);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(83, 13);
            this.label28.TabIndex = 151;
            this.label28.Text = "YOL DURUMU:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(103, 83);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(139, 20);
            this.dateTimePicker1.TabIndex = 149;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(54, 87);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(43, 13);
            this.label26.TabIndex = 148;
            this.label26.Text = "TARİH:";
            // 
            // CmbBolgeAdi
            // 
            this.CmbBolgeAdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBolgeAdi.FormattingEnabled = true;
            this.CmbBolgeAdi.Location = new System.Drawing.Point(103, 52);
            this.CmbBolgeAdi.Name = "CmbBolgeAdi";
            this.CmbBolgeAdi.Size = new System.Drawing.Size(296, 21);
            this.CmbBolgeAdi.TabIndex = 325;
            // 
            // TxtBolgeAdi
            // 
            this.TxtBolgeAdi.Location = new System.Drawing.Point(103, 52);
            this.TxtBolgeAdi.Name = "TxtBolgeAdi";
            this.TxtBolgeAdi.Size = new System.Drawing.Size(296, 20);
            this.TxtBolgeAdi.TabIndex = 324;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 323;
            this.label1.Text = "ÜS BÖLGE ADI:";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(106, 524);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 36);
            this.button1.TabIndex = 336;
            this.button1.Text = "KAYDET";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgList);
            this.groupBox1.Location = new System.Drawing.Point(103, 306);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1056, 212);
            this.groupBox1.TabIndex = 335;
            this.groupBox1.TabStop = false;
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BolgeAdi,
            this.Donem,
            this.Tarih,
            this.YolDurumu,
            this.Aciklama});
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(3, 16);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.Size = new System.Drawing.Size(1050, 193);
            this.DtgList.TabIndex = 0;
            // 
            // BolgeAdi
            // 
            this.BolgeAdi.HeaderText = "BÖLGE ADI";
            this.BolgeAdi.Name = "BolgeAdi";
            this.BolgeAdi.ReadOnly = true;
            this.BolgeAdi.Width = 82;
            // 
            // Donem
            // 
            this.Donem.HeaderText = "DÖNEM";
            this.Donem.Name = "Donem";
            this.Donem.ReadOnly = true;
            this.Donem.Width = 72;
            // 
            // Tarih
            // 
            this.Tarih.HeaderText = "TARİH";
            this.Tarih.Name = "Tarih";
            this.Tarih.ReadOnly = true;
            this.Tarih.Width = 65;
            // 
            // YolDurumu
            // 
            this.YolDurumu.HeaderText = "YOL DURUMU";
            this.YolDurumu.Name = "YolDurumu";
            this.YolDurumu.ReadOnly = true;
            this.YolDurumu.Width = 96;
            // 
            // Aciklama
            // 
            this.Aciklama.HeaderText = "AÇIKLAMA";
            this.Aciklama.Name = "Aciklama";
            this.Aciklama.ReadOnly = true;
            this.Aciklama.Width = 85;
            // 
            // BtnEkle
            // 
            this.BtnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnEkle.Location = new System.Drawing.Point(103, 260);
            this.BtnEkle.Name = "BtnEkle";
            this.BtnEkle.Size = new System.Drawing.Size(81, 28);
            this.BtnEkle.TabIndex = 337;
            this.BtnEkle.Text = "EKLE";
            this.BtnEkle.UseVisualStyleBackColor = true;
            // 
            // FrmYolDurumlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1453, 820);
            this.Controls.Add(this.BtnEkle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CmbBolgeAdi);
            this.Controls.Add(this.TxtBolgeAdi);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.TxtAciklama);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.CmbYolDurumu);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.panel1);
            this.Name = "FrmYolDurumlari";
            this.Text = "FrmYolDurumlari";
            this.Load += new System.EventHandler(this.FrmYolDurumlari_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.RichTextBox TxtAciklama;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox CmbYolDurumu;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox CmbBolgeAdi;
        private System.Windows.Forms.TextBox TxtBolgeAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DtgList;
        private System.Windows.Forms.Button BtnEkle;
        private System.Windows.Forms.DataGridViewTextBoxColumn BolgeAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Donem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn YolDurumu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aciklama;
    }
}