
namespace UserInterface.Butce
{
    partial class FrmButceKayit2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmButceKayit2));
            this.LblButceTutariDonem = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblButceTutariAy = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtButceTutari = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbButceYil = new System.Windows.Forms.ComboBox();
            this.CmbButceKodu = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnBolgeEkle = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.CmbButceDonem = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtKisiAdet = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.LblButceToplamYil = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblButceToplamAy = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.CmbSiparisNo = new System.Windows.Forms.ComboBox();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.BtnTemizle = new System.Windows.Forms.Button();
            this.BtnEkle = new System.Windows.Forms.Button();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // LblButceTutariDonem
            // 
            this.LblButceTutariDonem.AutoSize = true;
            this.LblButceTutariDonem.Location = new System.Drawing.Point(197, 284);
            this.LblButceTutariDonem.Name = "LblButceTutariDonem";
            this.LblButceTutariDonem.Size = new System.Drawing.Size(21, 15);
            this.LblButceTutariDonem.TabIndex = 449;
            this.LblButceTutariDonem.Text = "00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 284);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(172, 15);
            this.label12.TabIndex = 448;
            this.label12.Text = "Toplam Bütçe Tutarı (Dönem):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(319, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 15);
            this.label8.TabIndex = 447;
            this.label8.Text = "(Bir Kişi/Adet)";
            // 
            // LblButceTutariAy
            // 
            this.LblButceTutariAy.AutoSize = true;
            this.LblButceTutariAy.Location = new System.Drawing.Point(197, 252);
            this.LblButceTutariAy.Name = "LblButceTutariAy";
            this.LblButceTutariAy.Size = new System.Drawing.Size(21, 15);
            this.LblButceTutariAy.TabIndex = 446;
            this.LblButceTutariAy.Text = "00";
            this.LblButceTutariAy.TextChanged += new System.EventHandler(this.LblButceTutariAy_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 15);
            this.label7.TabIndex = 445;
            this.label7.Text = "Toplam Bütçe Tutarı (Ay):";
            // 
            // TxtButceTutari
            // 
            this.TxtButceTutari.Location = new System.Drawing.Point(197, 217);
            this.TxtButceTutari.Name = "TxtButceTutari";
            this.TxtButceTutari.Size = new System.Drawing.Size(116, 21);
            this.TxtButceTutari.TabIndex = 444;
            this.TxtButceTutari.TextChanged += new System.EventHandler(this.TxtButceTutari_TextChanged);
            this.TxtButceTutari.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtButceTutari_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 15);
            this.label6.TabIndex = 443;
            this.label6.Text = "Bütçe Tutarı (Ay):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 441;
            this.label3.Text = "Kişi/Adet:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgList);
            this.groupBox1.Location = new System.Drawing.Point(23, 367);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1300, 267);
            this.groupBox1.TabIndex = 438;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BÜTÇE BİLGİLERİ";
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AutoGenerateContextFilters = true;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Remove});
            this.DtgList.DateWithTime = false;
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(3, 17);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.Size = new System.Drawing.Size(1294, 247);
            this.DtgList.TabIndex = 0;
            this.DtgList.TimeFilter = false;
            this.DtgList.SortStringChanged += new System.EventHandler(this.DtgList_SortStringChanged);
            this.DtgList.FilterStringChanged += new System.EventHandler(this.DtgList_FilterStringChanged);
            this.DtgList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgList_CellContentClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(134, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 15);
            this.label9.TabIndex = 437;
            this.label9.Text = "Bütçe Yıl:";
            // 
            // CmbButceYil
            // 
            this.CmbButceYil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbButceYil.FormattingEnabled = true;
            this.CmbButceYil.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.CmbButceYil.Location = new System.Drawing.Point(197, 52);
            this.CmbButceYil.Name = "CmbButceYil";
            this.CmbButceYil.Size = new System.Drawing.Size(122, 23);
            this.CmbButceYil.TabIndex = 436;
            // 
            // CmbButceKodu
            // 
            this.CmbButceKodu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbButceKodu.FormattingEnabled = true;
            this.CmbButceKodu.Items.AddRange(new object[] {
            "BM12/YERLEŞKE GİDERLERİ",
            "BM21/İAŞE",
            "BM23/ÖZEL SİGRT. GİDERLERİ",
            "BM24/PERS. İLETİŞİM GİDERLERİ",
            "BM25/PERS. MAAŞ GİDERLERİ",
            "BM26/ARAÇ TAHSİS GİDERLERİ",
            "BM45/PERSONEL MAAŞ YANSIMASI",
            "BM46/ARAÇ YAKIT GİDERLERİ"});
            this.CmbButceKodu.Location = new System.Drawing.Point(197, 115);
            this.CmbButceKodu.Name = "CmbButceKodu";
            this.CmbButceKodu.Size = new System.Drawing.Size(301, 23);
            this.CmbButceKodu.TabIndex = 435;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 434;
            this.label1.Text = "Bütçe Tanım:";
            // 
            // BtnBolgeEkle
            // 
            this.BtnBolgeEkle.AccessibleDescription = "";
            this.BtnBolgeEkle.BackColor = System.Drawing.SystemColors.Control;
            this.BtnBolgeEkle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnBolgeEkle.BackgroundImage")));
            this.BtnBolgeEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnBolgeEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBolgeEkle.Location = new System.Drawing.Point(503, 110);
            this.BtnBolgeEkle.Margin = new System.Windows.Forms.Padding(0);
            this.BtnBolgeEkle.Name = "BtnBolgeEkle";
            this.BtnBolgeEkle.Size = new System.Drawing.Size(40, 33);
            this.BtnBolgeEkle.TabIndex = 451;
            this.BtnBolgeEkle.Tag = "admin";
            this.BtnBolgeEkle.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(106, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 15);
            this.label10.TabIndex = 454;
            this.label10.Text = "Bütçe Dönem:";
            // 
            // CmbButceDonem
            // 
            this.CmbButceDonem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbButceDonem.FormattingEnabled = true;
            this.CmbButceDonem.Items.AddRange(new object[] {
            "1. YARI",
            "2. YARI"});
            this.CmbButceDonem.Location = new System.Drawing.Point(197, 84);
            this.CmbButceDonem.Name = "CmbButceDonem";
            this.CmbButceDonem.Size = new System.Drawing.Size(122, 23);
            this.CmbButceDonem.TabIndex = 453;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1497, 31);
            this.panel1.TabIndex = 455;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(124, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 439;
            this.label2.Text = "Sipariş No:";
            // 
            // TxtKisiAdet
            // 
            this.TxtKisiAdet.Location = new System.Drawing.Point(197, 183);
            this.TxtKisiAdet.Name = "TxtKisiAdet";
            this.TxtKisiAdet.Size = new System.Drawing.Size(116, 21);
            this.TxtKisiAdet.TabIndex = 456;
            this.TxtKisiAdet.TextChanged += new System.EventHandler(this.TxtKisiAdet_TextChanged);
            this.TxtKisiAdet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKisiAdet_KeyPress);
            // 
            // button3
            // 
            this.button3.AccessibleDescription = "";
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(503, 144);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 33);
            this.button3.TabIndex = 457;
            this.button3.Tag = "admin";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // LblButceToplamYil
            // 
            this.LblButceToplamYil.AutoSize = true;
            this.LblButceToplamYil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblButceToplamYil.Location = new System.Drawing.Point(1034, 642);
            this.LblButceToplamYil.Name = "LblButceToplamYil";
            this.LblButceToplamYil.Size = new System.Drawing.Size(23, 15);
            this.LblButceToplamYil.TabIndex = 461;
            this.LblButceToplamYil.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(856, 642);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 15);
            this.label5.TabIndex = 460;
            this.label5.Text = "Toplam Bütçe Tutarı (Dönem):";
            // 
            // LblButceToplamAy
            // 
            this.LblButceToplamAy.AutoSize = true;
            this.LblButceToplamAy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblButceToplamAy.Location = new System.Drawing.Point(663, 640);
            this.LblButceToplamAy.Name = "LblButceToplamAy";
            this.LblButceToplamAy.Size = new System.Drawing.Size(23, 15);
            this.LblButceToplamAy.TabIndex = 459;
            this.LblButceToplamAy.Text = "00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(514, 640);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(143, 15);
            this.label13.TabIndex = 458;
            this.label13.Text = "Toplam Bütçe Tutarı (Ay):";
            // 
            // CmbSiparisNo
            // 
            this.CmbSiparisNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSiparisNo.Enabled = false;
            this.CmbSiparisNo.FormattingEnabled = true;
            this.CmbSiparisNo.Location = new System.Drawing.Point(197, 150);
            this.CmbSiparisNo.Name = "CmbSiparisNo";
            this.CmbSiparisNo.Size = new System.Drawing.Size(301, 23);
            this.CmbSiparisNo.TabIndex = 440;
            this.CmbSiparisNo.SelectedIndexChanged += new System.EventHandler(this.CmbSiparisNo_SelectedIndexChanged);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "broom.png");
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.Image")));
            this.BtnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnKaydet.Location = new System.Drawing.Point(26, 640);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(130, 51);
            this.BtnKaydet.TabIndex = 463;
            this.BtnKaydet.Text = "     KAYDET";
            this.BtnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKaydet.UseVisualStyleBackColor = false;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // BtnTemizle
            // 
            this.BtnTemizle.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTemizle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnTemizle.ImageKey = "broom.png";
            this.BtnTemizle.ImageList = this.ımageList1;
            this.BtnTemizle.Location = new System.Drawing.Point(162, 640);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(130, 51);
            this.BtnTemizle.TabIndex = 462;
            this.BtnTemizle.Text = "   TEMİZLE";
            this.BtnTemizle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTemizle.UseVisualStyleBackColor = false;
            // 
            // BtnEkle
            // 
            this.BtnEkle.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnEkle.Image = ((System.Drawing.Image)(resources.GetObject("BtnEkle.Image")));
            this.BtnEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEkle.Location = new System.Drawing.Point(197, 319);
            this.BtnEkle.Name = "BtnEkle";
            this.BtnEkle.Size = new System.Drawing.Size(85, 33);
            this.BtnEkle.TabIndex = 464;
            this.BtnEkle.Text = "  EKLE";
            this.BtnEkle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEkle.UseVisualStyleBackColor = false;
            this.BtnEkle.Click += new System.EventHandler(this.BtnEkle_Click_1);
            // 
            // Remove
            // 
            this.Remove.HeaderText = "KALDIR";
            this.Remove.MinimumWidth = 22;
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Remove.Text = "X";
            this.Remove.ToolTipText = "X";
            this.Remove.Visible = false;
            this.Remove.Width = 75;
            // 
            // FrmButceKayit2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1497, 849);
            this.Controls.Add(this.BtnEkle);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.BtnTemizle);
            this.Controls.Add(this.LblButceToplamYil);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblButceToplamAy);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.TxtKisiAdet);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CmbButceDonem);
            this.Controls.Add(this.BtnBolgeEkle);
            this.Controls.Add(this.LblButceTutariDonem);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LblButceTutariAy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtButceTutari);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbSiparisNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CmbButceYil);
            this.Controls.Add(this.CmbButceKodu);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "FrmButceKayit2";
            this.Text = "FrmButceKayit2";
            this.Load += new System.EventHandler(this.FrmButceKayit2_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblButceTutariDonem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblButceTutariAy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtButceTutari;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CmbButceYil;
        private System.Windows.Forms.ComboBox CmbButceKodu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnBolgeEkle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CmbButceDonem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtKisiAdet;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label LblButceToplamYil;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblButceToplamAy;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.ComboBox CmbSiparisNo;
        private System.Windows.Forms.ImageList ımageList1;
        public System.Windows.Forms.Button BtnKaydet;
        public System.Windows.Forms.Button BtnTemizle;
        private System.Windows.Forms.Button BtnEkle;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
    }
}