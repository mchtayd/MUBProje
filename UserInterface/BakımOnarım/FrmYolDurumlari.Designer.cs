
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmYolDurumlari));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LblDonem = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.TxtAciklama = new System.Windows.Forms.RichTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.CmbYolDurumu = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.CmbBolgeAdi = new System.Windows.Forms.ComboBox();
            this.TxtBolgeAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgList = new System.Windows.Forms.DataGridView();
            this.Idd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BolgeAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Donem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YolDurumu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.BtnEkle = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgBolgeler = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bolge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Secim = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LblTop = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblTop2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DtTarih = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgBolgeler)).BeginInit();
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
            // LblDonem
            // 
            this.LblDonem.AutoSize = true;
            this.LblDonem.Location = new System.Drawing.Point(900, 100);
            this.LblDonem.Name = "LblDonem";
            this.LblDonem.Size = new System.Drawing.Size(19, 13);
            this.LblDonem.TabIndex = 157;
            this.LblDonem.Text = "00";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(844, 100);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(50, 13);
            this.label30.TabIndex = 156;
            this.label30.Text = "DÖNEM:";
            // 
            // TxtAciklama
            // 
            this.TxtAciklama.Location = new System.Drawing.Point(900, 161);
            this.TxtAciklama.Name = "TxtAciklama";
            this.TxtAciklama.Size = new System.Drawing.Size(457, 77);
            this.TxtAciklama.TabIndex = 154;
            this.TxtAciklama.Text = "";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(831, 164);
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
            this.CmbYolDurumu.Location = new System.Drawing.Point(900, 127);
            this.CmbYolDurumu.Name = "CmbYolDurumu";
            this.CmbYolDurumu.Size = new System.Drawing.Size(139, 21);
            this.CmbYolDurumu.TabIndex = 152;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(811, 131);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(83, 13);
            this.label28.TabIndex = 151;
            this.label28.Text = "YOL DURUMU:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(851, 69);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(43, 13);
            this.label26.TabIndex = 148;
            this.label26.Text = "TARİH:";
            // 
            // CmbBolgeAdi
            // 
            this.CmbBolgeAdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBolgeAdi.FormattingEnabled = true;
            this.CmbBolgeAdi.Location = new System.Drawing.Point(1101, 769);
            this.CmbBolgeAdi.Name = "CmbBolgeAdi";
            this.CmbBolgeAdi.Size = new System.Drawing.Size(296, 21);
            this.CmbBolgeAdi.TabIndex = 325;
            this.CmbBolgeAdi.Visible = false;
            // 
            // TxtBolgeAdi
            // 
            this.TxtBolgeAdi.Location = new System.Drawing.Point(1101, 769);
            this.TxtBolgeAdi.Name = "TxtBolgeAdi";
            this.TxtBolgeAdi.Size = new System.Drawing.Size(296, 20);
            this.TxtBolgeAdi.TabIndex = 324;
            this.TxtBolgeAdi.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1010, 773);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 323;
            this.label1.Text = "ÜS BÖLGE ADI:";
            this.label1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgList);
            this.groupBox1.Location = new System.Drawing.Point(17, 365);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 358);
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
            this.Idd,
            this.BolgeAdi,
            this.Tarih,
            this.Donem,
            this.YolDurumu,
            this.Aciklama,
            this.Remove});
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(3, 16);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.Size = new System.Drawing.Size(781, 339);
            this.DtgList.TabIndex = 1;
            this.DtgList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgList_CellContentClick);
            this.DtgList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgList_CellMouseClick);
            // 
            // Idd
            // 
            this.Idd.HeaderText = "Id";
            this.Idd.Name = "Idd";
            this.Idd.ReadOnly = true;
            this.Idd.Visible = false;
            this.Idd.Width = 41;
            // 
            // BolgeAdi
            // 
            this.BolgeAdi.HeaderText = "BÖLGE ADI";
            this.BolgeAdi.Name = "BolgeAdi";
            this.BolgeAdi.ReadOnly = true;
            this.BolgeAdi.Width = 82;
            // 
            // Tarih
            // 
            this.Tarih.HeaderText = "TARİH";
            this.Tarih.Name = "Tarih";
            this.Tarih.ReadOnly = true;
            this.Tarih.Width = 65;
            // 
            // Donem
            // 
            this.Donem.HeaderText = "DÖNEM";
            this.Donem.Name = "Donem";
            this.Donem.ReadOnly = true;
            this.Donem.Width = 72;
            // 
            // YolDurumu
            // 
            this.YolDurumu.HeaderText = "YOL DURUMU";
            this.YolDurumu.Name = "YolDurumu";
            this.YolDurumu.ReadOnly = true;
            this.YolDurumu.Width = 97;
            // 
            // Aciklama
            // 
            this.Aciklama.HeaderText = "AÇIKLAMA";
            this.Aciklama.Name = "Aciklama";
            this.Aciklama.ReadOnly = true;
            this.Aciklama.Width = 85;
            // 
            // Remove
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Red;
            this.Remove.DefaultCellStyle = dataGridViewCellStyle1;
            this.Remove.HeaderText = "KALDIR";
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.Text = "X";
            this.Remove.ToolTipText = "X";
            this.Remove.UseColumnTextForButtonValue = true;
            this.Remove.Width = 52;
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.Image")));
            this.BtnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnKaydet.Location = new System.Drawing.Point(17, 753);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(130, 51);
            this.BtnKaydet.TabIndex = 339;
            this.BtnKaydet.Text = "     KAYDET";
            this.BtnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKaydet.UseVisualStyleBackColor = false;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // BtnEkle
            // 
            this.BtnEkle.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnEkle.Image = ((System.Drawing.Image)(resources.GetObject("BtnEkle.Image")));
            this.BtnEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEkle.Location = new System.Drawing.Point(900, 245);
            this.BtnEkle.Name = "BtnEkle";
            this.BtnEkle.Size = new System.Drawing.Size(76, 33);
            this.BtnEkle.TabIndex = 340;
            this.BtnEkle.Text = " EKLE";
            this.BtnEkle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEkle.UseVisualStyleBackColor = false;
            this.BtnEkle.Click += new System.EventHandler(this.BtnEkle_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgBolgeler);
            this.groupBox2.Location = new System.Drawing.Point(14, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(790, 299);
            this.groupBox2.TabIndex = 341;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BÖLGE BİLGİLERİ";
            // 
            // DtgBolgeler
            // 
            this.DtgBolgeler.AllowUserToAddRows = false;
            this.DtgBolgeler.AllowUserToOrderColumns = true;
            this.DtgBolgeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgBolgeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgBolgeler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Bolge,
            this.Secim});
            this.DtgBolgeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgBolgeler.Location = new System.Drawing.Point(3, 16);
            this.DtgBolgeler.Name = "DtgBolgeler";
            this.DtgBolgeler.Size = new System.Drawing.Size(784, 280);
            this.DtgBolgeler.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            this.Id.Width = 41;
            // 
            // Bolge
            // 
            this.Bolge.HeaderText = "BÖLGE ADI";
            this.Bolge.Name = "Bolge";
            this.Bolge.Width = 89;
            // 
            // Secim
            // 
            this.Secim.HeaderText = "SEÇİM";
            this.Secim.Name = "Secim";
            this.Secim.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Secim.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Secim.Width = 65;
            // 
            // LblTop
            // 
            this.LblTop.AutoSize = true;
            this.LblTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTop.Location = new System.Drawing.Point(117, 341);
            this.LblTop.Name = "LblTop";
            this.LblTop.Size = new System.Drawing.Size(21, 15);
            this.LblTop.TabIndex = 343;
            this.LblTop.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(17, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 342;
            this.label3.Text = "Toplam Kayıt:";
            // 
            // LblTop2
            // 
            this.LblTop2.AutoSize = true;
            this.LblTop2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTop2.Location = new System.Drawing.Point(117, 730);
            this.LblTop2.Name = "LblTop2";
            this.LblTop2.Size = new System.Drawing.Size(21, 15);
            this.LblTop2.TabIndex = 347;
            this.LblTop2.Text = "00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(17, 730);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 15);
            this.label7.TabIndex = 346;
            this.label7.Text = "Toplam Kayıt:";
            // 
            // DtTarih
            // 
            this.DtTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtTarih.Location = new System.Drawing.Point(900, 63);
            this.DtTarih.Name = "DtTarih";
            this.DtTarih.Size = new System.Drawing.Size(139, 20);
            this.DtTarih.TabIndex = 348;
            // 
            // FrmYolDurumlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1453, 820);
            this.Controls.Add(this.DtTarih);
            this.Controls.Add(this.LblTop2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LblTop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnEkle);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CmbBolgeAdi);
            this.Controls.Add(this.TxtBolgeAdi);
            this.Controls.Add(this.LblDonem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.TxtAciklama);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.CmbYolDurumu);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.panel1);
            this.Name = "FrmYolDurumlari";
            this.Text = "FrmYolDurumlari";
            this.Load += new System.EventHandler(this.FrmYolDurumlari_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgBolgeler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label LblDonem;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.RichTextBox TxtAciklama;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox CmbYolDurumu;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox CmbBolgeAdi;
        private System.Windows.Forms.TextBox TxtBolgeAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Button BtnEkle;
        private System.Windows.Forms.DataGridView DtgList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DtgBolgeler;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bolge;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Secim;
        private System.Windows.Forms.Label LblTop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblTop2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker DtTarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idd;
        private System.Windows.Forms.DataGridViewTextBoxColumn BolgeAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn Donem;
        private System.Windows.Forms.DataGridViewTextBoxColumn YolDurumu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aciklama;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
    }
}