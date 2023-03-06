
namespace UserInterface.RAPORLAMALAR
{
    partial class FrmSatRaporu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.CmbRaporTuru = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgRaporList = new ADGV.AdvancedDataGridView();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnRaporOlustur = new System.Windows.Forms.Button();
            this.CmbDonem = new System.Windows.Forms.ComboBox();
            this.label52 = new System.Windows.Forms.Label();
            this.ToplamTutar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.LbFaturaEdilecekFirma = new System.Windows.Forms.Label();
            this.CmbFaturaEdilecekFirma = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbDonemYil = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgRaporList)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1635, 27);
            this.panel1.TabIndex = 320;
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
            // CmbRaporTuru
            // 
            this.CmbRaporTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRaporTuru.FormattingEnabled = true;
            this.CmbRaporTuru.Items.AddRange(new object[] {
            "BEYANNAME",
            "RAPOR"});
            this.CmbRaporTuru.Location = new System.Drawing.Point(128, 43);
            this.CmbRaporTuru.Name = "CmbRaporTuru";
            this.CmbRaporTuru.Size = new System.Drawing.Size(126, 21);
            this.CmbRaporTuru.TabIndex = 328;
            this.CmbRaporTuru.SelectedIndexChanged += new System.EventHandler(this.CmbRaporTuru_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 327;
            this.label6.Text = "RAPOR TÜRÜ:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgRaporList);
            this.groupBox1.Location = new System.Drawing.Point(0, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1623, 683);
            this.groupBox1.TabIndex = 329;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RAPOR";
            // 
            // DtgRaporList
            // 
            this.DtgRaporList.AllowUserToAddRows = false;
            this.DtgRaporList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgRaporList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgRaporList.AutoGenerateContextFilters = true;
            this.DtgRaporList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgRaporList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgRaporList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgRaporList.DateWithTime = false;
            this.DtgRaporList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgRaporList.Location = new System.Drawing.Point(3, 16);
            this.DtgRaporList.Name = "DtgRaporList";
            this.DtgRaporList.ReadOnly = true;
            this.DtgRaporList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgRaporList.Size = new System.Drawing.Size(1617, 664);
            this.DtgRaporList.TabIndex = 2;
            this.DtgRaporList.TimeFilter = false;
            this.DtgRaporList.SortStringChanged += new System.EventHandler(this.DtgRaporList_SortStringChanged);
            this.DtgRaporList.FilterStringChanged += new System.EventHandler(this.DtgRaporList_FilterStringChanged);
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(110, 833);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 331;
            this.TxtTop.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(10, 833);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 330;
            this.label5.Text = "Toplam Kayıt:";
            // 
            // BtnRaporOlustur
            // 
            this.BtnRaporOlustur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRaporOlustur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnRaporOlustur.Location = new System.Drawing.Point(12, 82);
            this.BtnRaporOlustur.Name = "BtnRaporOlustur";
            this.BtnRaporOlustur.Size = new System.Drawing.Size(157, 45);
            this.BtnRaporOlustur.TabIndex = 332;
            this.BtnRaporOlustur.Text = "RAPOR OLUŞTUR";
            this.BtnRaporOlustur.UseVisualStyleBackColor = true;
            this.BtnRaporOlustur.Click += new System.EventHandler(this.BtnRaporOlustur_Click);
            // 
            // CmbDonem
            // 
            this.CmbDonem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDonem.FormattingEnabled = true;
            this.CmbDonem.Items.AddRange(new object[] {
            "OCAK",
            "ŞUBAT",
            "MART",
            "NİSAN",
            "MAYIS",
            "HAZİRAN",
            "TEMMUZ",
            "AĞUSTOS",
            "EYLÜL",
            "EKİM",
            "KASIM",
            "ARALIK"});
            this.CmbDonem.Location = new System.Drawing.Point(381, 43);
            this.CmbDonem.Name = "CmbDonem";
            this.CmbDonem.Size = new System.Drawing.Size(126, 21);
            this.CmbDonem.TabIndex = 334;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(291, 47);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(84, 13);
            this.label52.TabIndex = 333;
            this.label52.Text = "DÖNEM(Ay/Yıl):";
            // 
            // ToplamTutar
            // 
            this.ToplamTutar.AutoSize = true;
            this.ToplamTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ToplamTutar.Location = new System.Drawing.Point(308, 833);
            this.ToplamTutar.Name = "ToplamTutar";
            this.ToplamTutar.Size = new System.Drawing.Size(21, 15);
            this.ToplamTutar.TabIndex = 336;
            this.ToplamTutar.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(206, 833);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 335;
            this.label2.Text = "Toplam Tutar:";
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(13, 862);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(157, 45);
            this.BtnKaydet.TabIndex = 337;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // LbFaturaEdilecekFirma
            // 
            this.LbFaturaEdilecekFirma.AutoSize = true;
            this.LbFaturaEdilecekFirma.Location = new System.Drawing.Point(664, 47);
            this.LbFaturaEdilecekFirma.Name = "LbFaturaEdilecekFirma";
            this.LbFaturaEdilecekFirma.Size = new System.Drawing.Size(144, 13);
            this.LbFaturaEdilecekFirma.TabIndex = 338;
            this.LbFaturaEdilecekFirma.Text = "FATURA EDİLECEK FİRMA:";
            // 
            // CmbFaturaEdilecekFirma
            // 
            this.CmbFaturaEdilecekFirma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFaturaEdilecekFirma.FormattingEnabled = true;
            this.CmbFaturaEdilecekFirma.Items.AddRange(new object[] {
            "ASELSAN AŞ. UGES ÜRÜN DES.MDL.",
            "ASELSAN AŞ. UGES İÇ GÜV.PROG.DİR.",
            "ASELSAN AŞ. UGES İÇ GÜV.PROG.MDL.",
            "BAŞARAN İLERİ TEKNOLOJİ"});
            this.CmbFaturaEdilecekFirma.Location = new System.Drawing.Point(814, 44);
            this.CmbFaturaEdilecekFirma.Name = "CmbFaturaEdilecekFirma";
            this.CmbFaturaEdilecekFirma.Size = new System.Drawing.Size(278, 21);
            this.CmbFaturaEdilecekFirma.TabIndex = 339;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ASELSAN AŞ. FATURA",
            "DİREKTÖRLÜK BEYANNAME",
            "DİREKTÖRLÜK BÜTÇE RAPORU"});
            this.comboBox1.Location = new System.Drawing.Point(230, 82);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(126, 21);
            this.comboBox1.TabIndex = 340;
            this.comboBox1.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "ASELSAN AŞ. UGES ÜRÜN DES.MDL.",
            "ASELSAN AŞ. UGES İÇ GÜV.PROG.DİR.",
            "ASELSAN AŞ. UGES İÇ GÜV.PROG.MDL."});
            this.comboBox2.Location = new System.Drawing.Point(656, 82);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(278, 21);
            this.comboBox2.TabIndex = 341;
            this.comboBox2.Visible = false;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "ASELSAN AŞ. FATURA",
            "DİREKTÖRLÜK BEYANNAME",
            "DİREKTÖRLÜK BÜTÇE RAPORU"});
            this.comboBox3.Location = new System.Drawing.Point(472, 82);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(126, 21);
            this.comboBox3.TabIndex = 342;
            this.comboBox3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(387, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 343;
            this.label1.Text = "PROJE KODU:";
            this.label1.Visible = false;
            // 
            // CmbDonemYil
            // 
            this.CmbDonemYil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDonemYil.FormattingEnabled = true;
            this.CmbDonemYil.Items.AddRange(new object[] {
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
            this.CmbDonemYil.Location = new System.Drawing.Point(513, 44);
            this.CmbDonemYil.Name = "CmbDonemYil";
            this.CmbDonemYil.Size = new System.Drawing.Size(126, 21);
            this.CmbDonemYil.TabIndex = 414;
            // 
            // FrmSatRaporu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1635, 924);
            this.Controls.Add(this.CmbDonemYil);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.CmbFaturaEdilecekFirma);
            this.Controls.Add(this.LbFaturaEdilecekFirma);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.ToplamTutar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbDonem);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.BtnRaporOlustur);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CmbRaporTuru);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSatRaporu";
            this.Text = "FrmSatRaporu";
            this.Load += new System.EventHandler(this.FrmSatRaporu_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgRaporList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.ComboBox CmbRaporTuru;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgRaporList;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnRaporOlustur;
        private System.Windows.Forms.ComboBox CmbDonem;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label ToplamTutar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Label LbFaturaEdilecekFirma;
        private System.Windows.Forms.ComboBox CmbFaturaEdilecekFirma;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbDonemYil;
    }
}