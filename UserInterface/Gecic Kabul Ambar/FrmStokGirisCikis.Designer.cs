
namespace UserInterface.Depo
{
    partial class FrmStokGirisCikis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStokGirisCikis));
            this.label1 = new System.Windows.Forms.Label();
            this.CmbIslemTuru = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnPreview = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.DtTarih = new System.Windows.Forms.DateTimePicker();
            this.TxtTanim = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbBirim = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtMiktar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbStokNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtAciklama = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbDepoNo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnListEkle = new System.Windows.Forms.Button();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.BtnTemizle = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.AdvMalzemeOnizleme = new ADGV.AdvancedDataGridView();
            this.SiraNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeriLotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Revizyon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.advancedDataGridView1 = new ADGV.AdvancedDataGridView();
            this.BtnDepoEkle = new System.Windows.Forms.Button();
            this.BtnDepo = new System.Windows.Forms.Button();
            this.TxtMalzemeYeri = new System.Windows.Forms.TextBox();
            this.CmbAdres = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdvMalzemeOnizleme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "İŞLEM TÜRÜ:";
            // 
            // CmbIslemTuru
            // 
            this.CmbIslemTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIslemTuru.FormattingEnabled = true;
            this.CmbIslemTuru.Items.AddRange(new object[] {
            "100-YENİ DEPO GİRİŞİ",
            "101-DEPODAN DEPOYA İADE",
            "102-DEPODAN BİLDİRİME ÇEKİM",
            "201-BİLDİRİMDEN DEPOYA İADE"});
            this.CmbIslemTuru.Location = new System.Drawing.Point(103, 52);
            this.CmbIslemTuru.Name = "CmbIslemTuru";
            this.CmbIslemTuru.Size = new System.Drawing.Size(224, 21);
            this.CmbIslemTuru.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1551, 27);
            this.panel1.TabIndex = 45;
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
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnDepo);
            this.groupBox1.Controls.Add(this.BtnPreview);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.DtTarih);
            this.groupBox1.Controls.Add(this.TxtTanim);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.CmbBirim);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtMiktar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CmbStokNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(24, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1525, 170);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İŞLEM YAPILACAK MALZEME BİLGİSİ";
            // 
            // BtnPreview
            // 
            this.BtnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnPreview.Location = new System.Drawing.Point(425, 107);
            this.BtnPreview.Name = "BtnPreview";
            this.BtnPreview.Size = new System.Drawing.Size(123, 52);
            this.BtnPreview.TabIndex = 58;
            this.BtnPreview.Text = "ÖNİZLEME";
            this.BtnPreview.UseVisualStyleBackColor = true;
            this.BtnPreview.Visible = false;
            this.BtnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 56;
            this.label10.Text = "İŞLEM TARİHİ:";
            // 
            // DtTarih
            // 
            this.DtTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtTarih.Location = new System.Drawing.Point(120, 139);
            this.DtTarih.Name = "DtTarih";
            this.DtTarih.Size = new System.Drawing.Size(113, 20);
            this.DtTarih.TabIndex = 55;
            // 
            // TxtTanim
            // 
            this.TxtTanim.Location = new System.Drawing.Point(120, 58);
            this.TxtTanim.Name = "TxtTanim";
            this.TxtTanim.Size = new System.Drawing.Size(273, 20);
            this.TxtTanim.TabIndex = 54;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(68, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "TANIM:";
            // 
            // CmbBirim
            // 
            this.CmbBirim.FormattingEnabled = true;
            this.CmbBirim.Items.AddRange(new object[] {
            "KG",
            "ADET",
            "METRE",
            "LİTRE"});
            this.CmbBirim.Location = new System.Drawing.Point(120, 112);
            this.CmbBirim.Name = "CmbBirim";
            this.CmbBirim.Size = new System.Drawing.Size(113, 21);
            this.CmbBirim.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "BİRİM:";
            // 
            // TxtMiktar
            // 
            this.TxtMiktar.Location = new System.Drawing.Point(120, 84);
            this.TxtMiktar.Name = "TxtMiktar";
            this.TxtMiktar.Size = new System.Drawing.Size(113, 20);
            this.TxtMiktar.TabIndex = 50;
            this.TxtMiktar.TextChanged += new System.EventHandler(this.TxtMiktar_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "MİKTAR:";
            // 
            // CmbStokNo
            // 
            this.CmbStokNo.FormattingEnabled = true;
            this.CmbStokNo.Location = new System.Drawing.Point(120, 31);
            this.CmbStokNo.Name = "CmbStokNo";
            this.CmbStokNo.Size = new System.Drawing.Size(224, 21);
            this.CmbStokNo.TabIndex = 48;
            this.CmbStokNo.SelectedIndexChanged += new System.EventHandler(this.CmbStokNo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "STOK NO:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CmbAdres);
            this.groupBox2.Controls.Add(this.TxtAciklama);
            this.groupBox2.Controls.Add(this.BtnDepoEkle);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.TxtMalzemeYeri);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.CmbDepoNo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(24, 267);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1525, 146);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "İŞLEM YAPILACAK DEPO BİLGİLERİ:";
            // 
            // TxtAciklama
            // 
            this.TxtAciklama.Location = new System.Drawing.Point(493, 34);
            this.TxtAciklama.Name = "TxtAciklama";
            this.TxtAciklama.Size = new System.Drawing.Size(561, 90);
            this.TxtAciklama.TabIndex = 57;
            this.TxtAciklama.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(422, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "AÇIKLAMA:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 54;
            this.label8.Text = "DEPO ADRESİ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "MALZEME YERİ:";
            // 
            // CmbDepoNo
            // 
            this.CmbDepoNo.FormattingEnabled = true;
            this.CmbDepoNo.Location = new System.Drawing.Point(120, 31);
            this.CmbDepoNo.Name = "CmbDepoNo";
            this.CmbDepoNo.Size = new System.Drawing.Size(224, 21);
            this.CmbDepoNo.TabIndex = 48;
            this.CmbDepoNo.SelectedIndexChanged += new System.EventHandler(this.CmbDepoNo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "DEPO NO:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DtgList);
            this.groupBox3.Location = new System.Drawing.Point(13, 549);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1451, 237);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "STOK GİRİŞİ YAPILACAK LİSTE";
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AutoGenerateContextFilters = true;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column13,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column14,
            this.Column10,
            this.Column12,
            this.Column11});
            this.DtgList.DateWithTime = false;
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(3, 16);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.Size = new System.Drawing.Size(1445, 218);
            this.DtgList.TabIndex = 1;
            this.DtgList.TimeFilter = false;
            this.DtgList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgList_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "SIRA NO";
            this.Column1.MinimumWidth = 22;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "İŞLEM TÜRÜ";
            this.Column13.MinimumWidth = 22;
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "STOK NO";
            this.Column2.MinimumWidth = 22;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "TANIM";
            this.Column3.MinimumWidth = 22;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "MİKTAR";
            this.Column4.MinimumWidth = 22;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "BİRİM";
            this.Column5.MinimumWidth = 22;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "İŞLEM TARİHİ";
            this.Column6.MinimumWidth = 22;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "DEPO NO";
            this.Column7.MinimumWidth = 22;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "DEPO ADRESİ";
            this.Column8.MinimumWidth = 22;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "MALZEME YERİ";
            this.Column9.MinimumWidth = 22;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "AÇIKLAMA";
            this.Column14.MinimumWidth = 22;
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "SERİ NO";
            this.Column10.MinimumWidth = 22;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "LOT NO";
            this.Column12.MinimumWidth = 22;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "REVİZYON";
            this.Column11.MinimumWidth = 22;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // BtnListEkle
            // 
            this.BtnListEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnListEkle.Location = new System.Drawing.Point(512, 507);
            this.BtnListEkle.Name = "BtnListEkle";
            this.BtnListEkle.Size = new System.Drawing.Size(566, 36);
            this.BtnListEkle.TabIndex = 56;
            this.BtnListEkle.Text = "DEPO GİRİŞ KAYIT LİSTESİNE EKLE";
            this.BtnListEkle.UseVisualStyleBackColor = true;
            this.BtnListEkle.Click += new System.EventHandler(this.BtnListEkle_Click);
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(16, 792);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(123, 52);
            this.BtnKaydet.TabIndex = 57;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // BtnTemizle
            // 
            this.BtnTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTemizle.Location = new System.Drawing.Point(145, 792);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(123, 52);
            this.BtnTemizle.TabIndex = 58;
            this.BtnTemizle.Text = "TEMİZLE";
            this.BtnTemizle.UseVisualStyleBackColor = true;
            this.BtnTemizle.Click += new System.EventHandler(this.BtnTemizle_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.AdvMalzemeOnizleme);
            this.groupBox4.Controls.Add(this.advancedDataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(27, 419);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(450, 124);
            this.groupBox4.TabIndex = 56;
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "";
            this.groupBox4.Text = "Seri No / Lot No / Revizyon Bilgisi Girmek İçin Miktar Belirtiniz.";
            // 
            // AdvMalzemeOnizleme
            // 
            this.AdvMalzemeOnizleme.AllowUserToAddRows = false;
            this.AdvMalzemeOnizleme.AllowUserToDeleteRows = false;
            this.AdvMalzemeOnizleme.AutoGenerateContextFilters = true;
            this.AdvMalzemeOnizleme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AdvMalzemeOnizleme.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SiraNo,
            this.SeriLotNo,
            this.Revizyon,
            this.Remove});
            this.AdvMalzemeOnizleme.DateWithTime = false;
            this.AdvMalzemeOnizleme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdvMalzemeOnizleme.Location = new System.Drawing.Point(3, 16);
            this.AdvMalzemeOnizleme.Name = "AdvMalzemeOnizleme";
            this.AdvMalzemeOnizleme.Size = new System.Drawing.Size(444, 105);
            this.AdvMalzemeOnizleme.TabIndex = 1;
            this.AdvMalzemeOnizleme.TimeFilter = false;
            this.AdvMalzemeOnizleme.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AdvMalzemeOnizleme_CellContentClick);
            // 
            // SiraNo
            // 
            this.SiraNo.HeaderText = "SIRA NO";
            this.SiraNo.MinimumWidth = 22;
            this.SiraNo.Name = "SiraNo";
            this.SiraNo.ReadOnly = true;
            this.SiraNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // SeriLotNo
            // 
            this.SeriLotNo.HeaderText = "SERİ NO";
            this.SeriLotNo.MinimumWidth = 22;
            this.SeriLotNo.Name = "SeriLotNo";
            this.SeriLotNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Revizyon
            // 
            this.Revizyon.HeaderText = "REVİZYON";
            this.Revizyon.MinimumWidth = 22;
            this.Revizyon.Name = "Revizyon";
            this.Revizyon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Remove
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Red;
            this.Remove.DefaultCellStyle = dataGridViewCellStyle1;
            this.Remove.HeaderText = "KALDIR";
            this.Remove.MinimumWidth = 22;
            this.Remove.Name = "Remove";
            this.Remove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Remove.Text = "X";
            this.Remove.ToolTipText = "X";
            this.Remove.UseColumnTextForButtonValue = true;
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.AllowUserToDeleteRows = false;
            this.advancedDataGridView1.AutoGenerateContextFilters = true;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.DateWithTime = false;
            this.advancedDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView1.Location = new System.Drawing.Point(3, 16);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.ReadOnly = true;
            this.advancedDataGridView1.Size = new System.Drawing.Size(444, 105);
            this.advancedDataGridView1.TabIndex = 0;
            this.advancedDataGridView1.TimeFilter = false;
            // 
            // BtnDepoEkle
            // 
            this.BtnDepoEkle.AccessibleDescription = "";
            this.BtnDepoEkle.BackColor = System.Drawing.SystemColors.Control;
            this.BtnDepoEkle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnDepoEkle.BackgroundImage")));
            this.BtnDepoEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnDepoEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDepoEkle.Location = new System.Drawing.Point(347, 26);
            this.BtnDepoEkle.Margin = new System.Windows.Forms.Padding(0);
            this.BtnDepoEkle.Name = "BtnDepoEkle";
            this.BtnDepoEkle.Size = new System.Drawing.Size(34, 29);
            this.BtnDepoEkle.TabIndex = 136;
            this.BtnDepoEkle.Tag = "admin";
            this.BtnDepoEkle.UseVisualStyleBackColor = false;
            this.BtnDepoEkle.Click += new System.EventHandler(this.BtnDepoEkle_Click);
            // 
            // BtnDepo
            // 
            this.BtnDepo.AccessibleDescription = "";
            this.BtnDepo.BackColor = System.Drawing.SystemColors.Control;
            this.BtnDepo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnDepo.BackgroundImage")));
            this.BtnDepo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnDepo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDepo.Location = new System.Drawing.Point(347, 27);
            this.BtnDepo.Margin = new System.Windows.Forms.Padding(0);
            this.BtnDepo.Name = "BtnDepo";
            this.BtnDepo.Size = new System.Drawing.Size(34, 29);
            this.BtnDepo.TabIndex = 137;
            this.BtnDepo.Tag = "admin";
            this.BtnDepo.UseVisualStyleBackColor = false;
            // 
            // TxtMalzemeYeri
            // 
            this.TxtMalzemeYeri.Location = new System.Drawing.Point(120, 105);
            this.TxtMalzemeYeri.Name = "TxtMalzemeYeri";
            this.TxtMalzemeYeri.Size = new System.Drawing.Size(224, 20);
            this.TxtMalzemeYeri.TabIndex = 50;
            // 
            // CmbAdres
            // 
            this.CmbAdres.Location = new System.Drawing.Point(120, 69);
            this.CmbAdres.Name = "CmbAdres";
            this.CmbAdres.Size = new System.Drawing.Size(224, 20);
            this.CmbAdres.TabIndex = 138;
            // 
            // FrmStokGirisCikis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 860);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.BtnTemizle);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.BtnListEkle);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CmbIslemTuru);
            this.Controls.Add(this.label1);
            this.Name = "FrmStokGirisCikis";
            this.Text = "STOK GİRİŞ/ÇIKIŞ";
            this.Load += new System.EventHandler(this.FrmStokGirisCikis_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AdvMalzemeOnizleme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbIslemTuru;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CmbBirim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtMiktar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbStokNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbDepoNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker DtTarih;
        private System.Windows.Forms.TextBox TxtTanim;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox TxtAciklama;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnListEkle;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Button BtnTemizle;
        private System.Windows.Forms.Button BtnPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.GroupBox groupBox4;
        private ADGV.AdvancedDataGridView AdvMalzemeOnizleme;
        private ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiraNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeriLotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Revizyon;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
        private System.Windows.Forms.Button BtnDepoEkle;
        private System.Windows.Forms.Button BtnDepo;
        private System.Windows.Forms.TextBox CmbAdres;
        private System.Windows.Forms.TextBox TxtMalzemeYeri;
    }
}