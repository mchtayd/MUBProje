namespace UserInterface.Gecic_Kabul_Ambar
{
    partial class FrmAltTakimTakip
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAltTakimTakip));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.barkodOluşturToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.TxtAciklama = new System.Windows.Forms.RichTextBox();
            this.LblTop2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgIslem = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StokNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeriNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Revizyon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AbfNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BolgeAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YapilacakIslem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeslimDurum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BolgeSorumlusu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BtnTeslimAlSat = new System.Windows.Forms.Button();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DtgTeslimTarihi = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbTeslimTuru = new System.Windows.Forms.ComboBox();
            this.CmbMalzemeIadeYeri = new System.Windows.Forms.ComboBox();
            this.LblIadeYeri = new System.Windows.Forms.Label();
            this.BtnTeslimTuru = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.DtgSaat = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnDisaAktar = new System.Windows.Forms.Button();
            this.malzemeBilgisiniDüzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgIslem)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1503, 27);
            this.panel1.TabIndex = 308;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.ForeColor = System.Drawing.Color.DarkRed;
            this.button5.Location = new System.Drawing.Point(12, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(35, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-134, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 391;
            this.label2.Text = "Açıklama:";
            // 
            // TxtTop
            // 
            this.TxtTop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(112, 362);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 382;
            this.TxtTop.Text = "00";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 362);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 381;
            this.label5.Text = "Toplam Kayıt:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.DtgList);
            this.groupBox1.Location = new System.Drawing.Point(15, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1479, 279);
            this.groupBox1.TabIndex = 380;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MALZEME TAKİP LİSTESİ";
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgList.AutoGenerateContextFilters = true;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.ContextMenuStrip = this.contextMenuStrip1;
            this.DtgList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgList.DateWithTime = false;
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(3, 16);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgList.Size = new System.Drawing.Size(1473, 260);
            this.DtgList.TabIndex = 4;
            this.DtgList.TimeFilter = false;
            this.DtgList.SortStringChanged += new System.EventHandler(this.DtgList_SortStringChanged);
            this.DtgList.FilterStringChanged += new System.EventHandler(this.DtgList_FilterStringChanged);
            this.DtgList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgList_CellMouseClick);
            this.DtgList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgList_CellMouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barkodOluşturToolStripMenuItem,
            this.malzemeBilgisiniDüzenleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(212, 70);
            // 
            // barkodOluşturToolStripMenuItem
            // 
            this.barkodOluşturToolStripMenuItem.Name = "barkodOluşturToolStripMenuItem";
            this.barkodOluşturToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.barkodOluşturToolStripMenuItem.Text = "Barkod Oluştur";
            this.barkodOluşturToolStripMenuItem.Click += new System.EventHandler(this.barkodOluşturToolStripMenuItem_Click);
            // 
            // TxtAciklama
            // 
            this.TxtAciklama.Location = new System.Drawing.Point(-75, 19);
            this.TxtAciklama.Name = "TxtAciklama";
            this.TxtAciklama.Size = new System.Drawing.Size(576, 51);
            this.TxtAciklama.TabIndex = 394;
            this.TxtAciklama.Text = "";
            // 
            // LblTop2
            // 
            this.LblTop2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblTop2.AutoSize = true;
            this.LblTop2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTop2.Location = new System.Drawing.Point(117, 667);
            this.LblTop2.Name = "LblTop2";
            this.LblTop2.Size = new System.Drawing.Size(21, 15);
            this.LblTop2.TabIndex = 401;
            this.LblTop2.Text = "00";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(17, 667);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 400;
            this.label3.Text = "Toplam Kayıt:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.DtgIslem);
            this.groupBox2.Location = new System.Drawing.Point(15, 389);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1479, 272);
            this.groupBox2.TabIndex = 399;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "İŞLEM YAPILACAK MALZEME LİSTESİ";
            // 
            // DtgIslem
            // 
            this.DtgIslem.AllowUserToAddRows = false;
            this.DtgIslem.AllowUserToDeleteRows = false;
            this.DtgIslem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgIslem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgIslem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.StokNo,
            this.Tanim,
            this.SeriNo,
            this.Revizyon,
            this.Miktar,
            this.Birim,
            this.AbfNo,
            this.BolgeAdi,
            this.YapilacakIslem,
            this.TeslimDurum,
            this.BolgeSorumlusu,
            this.Remove});
            this.DtgIslem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgIslem.Location = new System.Drawing.Point(3, 16);
            this.DtgIslem.Name = "DtgIslem";
            this.DtgIslem.ReadOnly = true;
            this.DtgIslem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgIslem.Size = new System.Drawing.Size(1473, 253);
            this.DtgIslem.TabIndex = 4;
            this.DtgIslem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgIslem_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 43;
            // 
            // StokNo
            // 
            this.StokNo.HeaderText = "STOK NO";
            this.StokNo.Name = "StokNo";
            this.StokNo.ReadOnly = true;
            this.StokNo.Width = 74;
            // 
            // Tanim
            // 
            this.Tanim.HeaderText = "TANIM";
            this.Tanim.Name = "Tanim";
            this.Tanim.ReadOnly = true;
            this.Tanim.Width = 66;
            // 
            // SeriNo
            // 
            this.SeriNo.HeaderText = "SERİ NO";
            this.SeriNo.Name = "SeriNo";
            this.SeriNo.ReadOnly = true;
            this.SeriNo.Width = 70;
            // 
            // Revizyon
            // 
            this.Revizyon.HeaderText = "REVİZYON";
            this.Revizyon.Name = "Revizyon";
            this.Revizyon.ReadOnly = true;
            this.Revizyon.Width = 87;
            // 
            // Miktar
            // 
            this.Miktar.HeaderText = "MİKTAR";
            this.Miktar.Name = "Miktar";
            this.Miktar.ReadOnly = true;
            this.Miktar.Width = 73;
            // 
            // Birim
            // 
            this.Birim.HeaderText = "BİRİM";
            this.Birim.Name = "Birim";
            this.Birim.ReadOnly = true;
            this.Birim.Width = 62;
            // 
            // AbfNo
            // 
            this.AbfNo.HeaderText = "ABF NO";
            this.AbfNo.Name = "AbfNo";
            this.AbfNo.ReadOnly = true;
            this.AbfNo.Width = 52;
            // 
            // BolgeAdi
            // 
            this.BolgeAdi.HeaderText = "BÖLGE ADI";
            this.BolgeAdi.Name = "BolgeAdi";
            this.BolgeAdi.ReadOnly = true;
            this.BolgeAdi.Width = 82;
            // 
            // YapilacakIslem
            // 
            this.YapilacakIslem.HeaderText = "YAPILACAK İŞLEM";
            this.YapilacakIslem.Name = "YapilacakIslem";
            this.YapilacakIslem.ReadOnly = true;
            this.YapilacakIslem.Width = 115;
            // 
            // TeslimDurum
            // 
            this.TeslimDurum.HeaderText = "TESLİM DURUMU";
            this.TeslimDurum.Name = "TeslimDurum";
            this.TeslimDurum.ReadOnly = true;
            this.TeslimDurum.Width = 113;
            // 
            // BolgeSorumlusu
            // 
            this.BolgeSorumlusu.HeaderText = "BÖLGE SORMLUSU";
            this.BolgeSorumlusu.Name = "BolgeSorumlusu";
            this.BolgeSorumlusu.ReadOnly = true;
            this.BolgeSorumlusu.Width = 121;
            // 
            // Remove
            // 
            this.Remove.HeaderText = "KALDIR";
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.Text = "X";
            this.Remove.ToolTipText = "X";
            this.Remove.UseColumnTextForButtonValue = true;
            this.Remove.Width = 52;
            // 
            // BtnTeslimAlSat
            // 
            this.BtnTeslimAlSat.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnTeslimAlSat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTeslimAlSat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTeslimAlSat.Image = ((System.Drawing.Image)(resources.GetObject("BtnTeslimAlSat.Image")));
            this.BtnTeslimAlSat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnTeslimAlSat.Location = new System.Drawing.Point(21, 702);
            this.BtnTeslimAlSat.Name = "BtnTeslimAlSat";
            this.BtnTeslimAlSat.Size = new System.Drawing.Size(122, 51);
            this.BtnTeslimAlSat.TabIndex = 398;
            this.BtnTeslimAlSat.Text = " TESLİM AL";
            this.BtnTeslimAlSat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTeslimAlSat.UseVisualStyleBackColor = false;
            this.BtnTeslimAlSat.Click += new System.EventHandler(this.BtnTeslimAlSat_Click);
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.Image")));
            this.BtnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnKaydet.Location = new System.Drawing.Point(506, 19);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(130, 51);
            this.BtnKaydet.TabIndex = 445;
            this.BtnKaydet.Text = "     KAYDET";
            this.BtnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKaydet.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(642, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(525, 45);
            this.label4.TabIndex = 446;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(201, 669);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 447;
            this.label6.Text = "Tarih:";
            // 
            // DtgTeslimTarihi
            // 
            this.DtgTeslimTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtgTeslimTarihi.Location = new System.Drawing.Point(242, 667);
            this.DtgTeslimTarihi.Name = "DtgTeslimTarihi";
            this.DtgTeslimTarihi.Size = new System.Drawing.Size(122, 20);
            this.DtgTeslimTarihi.TabIndex = 448;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(161, 708);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(603, 45);
            this.label7.TabIndex = 449;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(20, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 451;
            this.label1.Text = "Teslim Alma Türü:";
            // 
            // CmbTeslimTuru
            // 
            this.CmbTeslimTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTeslimTuru.FormattingEnabled = true;
            this.CmbTeslimTuru.Location = new System.Drawing.Point(149, 43);
            this.CmbTeslimTuru.Name = "CmbTeslimTuru";
            this.CmbTeslimTuru.Size = new System.Drawing.Size(322, 21);
            this.CmbTeslimTuru.TabIndex = 452;
            this.CmbTeslimTuru.SelectedIndexChanged += new System.EventHandler(this.CmbTeslimTuru_SelectedIndexChanged);
            // 
            // CmbMalzemeIadeYeri
            // 
            this.CmbMalzemeIadeYeri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMalzemeIadeYeri.FormattingEnabled = true;
            this.CmbMalzemeIadeYeri.Location = new System.Drawing.Point(639, 43);
            this.CmbMalzemeIadeYeri.Name = "CmbMalzemeIadeYeri";
            this.CmbMalzemeIadeYeri.Size = new System.Drawing.Size(322, 21);
            this.CmbMalzemeIadeYeri.TabIndex = 454;
            this.CmbMalzemeIadeYeri.Visible = false;
            // 
            // LblIadeYeri
            // 
            this.LblIadeYeri.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblIadeYeri.AutoSize = true;
            this.LblIadeYeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblIadeYeri.Location = new System.Drawing.Point(487, 44);
            this.LblIadeYeri.Name = "LblIadeYeri";
            this.LblIadeYeri.Size = new System.Drawing.Size(146, 15);
            this.LblIadeYeri.TabIndex = 453;
            this.LblIadeYeri.Text = "Malzeme Teslim Yeri:";
            this.LblIadeYeri.Visible = false;
            // 
            // BtnTeslimTuru
            // 
            this.BtnTeslimTuru.AccessibleDescription = "";
            this.BtnTeslimTuru.BackColor = System.Drawing.SystemColors.Control;
            this.BtnTeslimTuru.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnTeslimTuru.BackgroundImage")));
            this.BtnTeslimTuru.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnTeslimTuru.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTeslimTuru.Location = new System.Drawing.Point(964, 38);
            this.BtnTeslimTuru.Margin = new System.Windows.Forms.Padding(0);
            this.BtnTeslimTuru.Name = "BtnTeslimTuru";
            this.BtnTeslimTuru.Size = new System.Drawing.Size(34, 29);
            this.BtnTeslimTuru.TabIndex = 455;
            this.BtnTeslimTuru.Tag = "admin";
            this.BtnTeslimTuru.UseVisualStyleBackColor = false;
            this.BtnTeslimTuru.Visible = false;
            this.BtnTeslimTuru.Click += new System.EventHandler(this.BtnTeslimTuru_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(370, 669);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 15);
            this.label8.TabIndex = 456;
            this.label8.Text = "Saat:";
            // 
            // DtgSaat
            // 
            this.DtgSaat.CustomFormat = "HH:mm";
            this.DtgSaat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DtgSaat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtgSaat.Location = new System.Drawing.Point(411, 666);
            this.DtgSaat.Name = "DtgSaat";
            this.DtgSaat.ShowUpDown = true;
            this.DtgSaat.Size = new System.Drawing.Size(101, 21);
            this.DtgSaat.TabIndex = 457;
            this.DtgSaat.Value = new System.DateTime(2018, 1, 12, 0, 0, 0, 0);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TxtAciklama);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.BtnKaydet);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(1274, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(28, 19);
            this.panel2.TabIndex = 5;
            this.panel2.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CadetBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(876, 708);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 51);
            this.button1.TabIndex = 458;
            this.button1.Text = "DATA DÜZELT";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnDisaAktar
            // 
            this.BtnDisaAktar.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnDisaAktar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDisaAktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnDisaAktar.Image = ((System.Drawing.Image)(resources.GetObject("BtnDisaAktar.Image")));
            this.BtnDisaAktar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDisaAktar.Location = new System.Drawing.Point(477, 29);
            this.BtnDisaAktar.Name = "BtnDisaAktar";
            this.BtnDisaAktar.Size = new System.Drawing.Size(130, 51);
            this.BtnDisaAktar.TabIndex = 541;
            this.BtnDisaAktar.Text = " DIŞA AKTAR";
            this.BtnDisaAktar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDisaAktar.UseVisualStyleBackColor = false;
            this.BtnDisaAktar.Visible = false;
            this.BtnDisaAktar.Click += new System.EventHandler(this.BtnDisaAktar_Click);
            // 
            // malzemeBilgisiniDüzenleToolStripMenuItem
            // 
            this.malzemeBilgisiniDüzenleToolStripMenuItem.Name = "malzemeBilgisiniDüzenleToolStripMenuItem";
            this.malzemeBilgisiniDüzenleToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.malzemeBilgisiniDüzenleToolStripMenuItem.Text = "Malzeme Bilgisini Düzenle";
            this.malzemeBilgisiniDüzenleToolStripMenuItem.Click += new System.EventHandler(this.malzemeBilgisiniDüzenleToolStripMenuItem_Click);
            // 
            // FrmAltTakimTakip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 797);
            this.Controls.Add(this.BtnDisaAktar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DtgSaat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BtnTeslimTuru);
            this.Controls.Add(this.CmbMalzemeIadeYeri);
            this.Controls.Add(this.LblIadeYeri);
            this.Controls.Add(this.CmbTeslimTuru);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DtgTeslimTarihi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LblTop2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnTeslimAlSat);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAltTakimTakip";
            this.Text = "FrmAltTakimTakip";
            this.Load += new System.EventHandler(this.FrmAltTakimTakip_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgIslem)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.RichTextBox TxtAciklama;
        private System.Windows.Forms.Label LblTop2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnTeslimAlSat;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DtgTeslimTarihi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView DtgIslem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbTeslimTuru;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn StokNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanim;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeriNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Revizyon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Miktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birim;
        private System.Windows.Forms.DataGridViewTextBoxColumn AbfNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BolgeAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn YapilacakIslem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeslimDurum;
        private System.Windows.Forms.DataGridViewTextBoxColumn BolgeSorumlusu;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
        private System.Windows.Forms.Label LblIadeYeri;
        private System.Windows.Forms.Button BtnTeslimTuru;
        public System.Windows.Forms.ComboBox CmbMalzemeIadeYeri;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker DtgSaat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem barkodOluşturToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnDisaAktar;
        private System.Windows.Forms.ToolStripMenuItem malzemeBilgisiniDüzenleToolStripMenuItem;
    }
}