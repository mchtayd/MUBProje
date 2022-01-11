
namespace UserInterface.IdariIsler
{
    partial class FrmSehirIciGorevIzleme
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtAkısNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtAdSoyad = new System.Windows.Forms.TextBox();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgLog = new ADGV.AdvancedDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgLogTamamlanan = new ADGV.AdvancedDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TopKayit = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DtgTamamlanan = new ADGV.AdvancedDataGridView();
            this.TxtTop2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtAdSoyadTamamlanan = new System.Windows.Forms.TextBox();
            this.TxtIsAkisNoTamamlanan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataBinder2 = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yenileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgLog)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgLogTamamlanan)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTamamlanan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1557, 27);
            this.panel1.TabIndex = 319;
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
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgList.AutoGenerateContextFilters = true;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgList.DateWithTime = false;
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(0, 0);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgList.Size = new System.Drawing.Size(1547, 584);
            this.DtgList.TabIndex = 3;
            this.DtgList.TimeFilter = false;
            this.DtgList.SortStringChanged += new System.EventHandler(this.DtgList_SortStringChanged);
            this.DtgList.FilterStringChanged += new System.EventHandler(this.DtgList_FilterStringChanged);
            this.DtgList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgList_CellMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 15);
            this.label1.TabIndex = 330;
            this.label1.Text = "İŞ AKIŞ NO İLE ARAMA:";
            // 
            // TxtAkısNo
            // 
            this.TxtAkısNo.Location = new System.Drawing.Point(179, 21);
            this.TxtAkısNo.Name = "TxtAkısNo";
            this.TxtAkısNo.Size = new System.Drawing.Size(205, 20);
            this.TxtAkısNo.TabIndex = 329;
            this.TxtAkısNo.TextChanged += new System.EventHandler(this.TxtAkısNo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(423, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 15);
            this.label2.TabIndex = 328;
            this.label2.Text = "PERSONEL İSMİ İLE ARAMA:";
            // 
            // TxtAdSoyad
            // 
            this.TxtAdSoyad.Location = new System.Drawing.Point(622, 21);
            this.TxtAdSoyad.Name = "TxtAdSoyad";
            this.TxtAdSoyad.Size = new System.Drawing.Size(205, 20);
            this.TxtAdSoyad.TabIndex = 327;
            this.TxtAdSoyad.TextChanged += new System.EventHandler(this.TxtAdSoyad_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1555, 890);
            this.tabControl1.TabIndex = 331;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.TxtTop);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.TxtAdSoyad);
            this.tabPage1.Controls.Add(this.TxtAkısNo);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1547, 864);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DEVAM EDEN GÖREVLER";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgLog);
            this.groupBox1.Location = new System.Drawing.Point(6, 687);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1004, 170);
            this.groupBox1.TabIndex = 339;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İŞLEM ADIMLARI";
            // 
            // DtgLog
            // 
            this.DtgLog.AllowUserToAddRows = false;
            this.DtgLog.AllowUserToDeleteRows = false;
            this.DtgLog.AllowUserToResizeColumns = false;
            this.DtgLog.AllowUserToResizeRows = false;
            this.DtgLog.AutoGenerateContextFilters = true;
            this.DtgLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgLog.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtgLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgLog.DateWithTime = false;
            this.DtgLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgLog.Location = new System.Drawing.Point(3, 16);
            this.DtgLog.MultiSelect = false;
            this.DtgLog.Name = "DtgLog";
            this.DtgLog.ReadOnly = true;
            this.DtgLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgLog.Size = new System.Drawing.Size(998, 151);
            this.DtgLog.TabIndex = 1;
            this.DtgLog.TimeFilter = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DtgList);
            this.panel2.Location = new System.Drawing.Point(0, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1547, 584);
            this.panel2.TabIndex = 331;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.TxtTop2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.TxtAdSoyadTamamlanan);
            this.tabPage2.Controls.Add(this.TxtIsAkisNoTamamlanan);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1547, 864);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TAMAMLANAN GÖREVLER";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgLogTamamlanan);
            this.groupBox2.Location = new System.Drawing.Point(6, 687);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1004, 170);
            this.groupBox2.TabIndex = 340;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "İŞLEM ADIMLARI";
            // 
            // DtgLogTamamlanan
            // 
            this.DtgLogTamamlanan.AllowUserToAddRows = false;
            this.DtgLogTamamlanan.AllowUserToDeleteRows = false;
            this.DtgLogTamamlanan.AllowUserToResizeColumns = false;
            this.DtgLogTamamlanan.AllowUserToResizeRows = false;
            this.DtgLogTamamlanan.AutoGenerateContextFilters = true;
            this.DtgLogTamamlanan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgLogTamamlanan.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtgLogTamamlanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgLogTamamlanan.DateWithTime = false;
            this.DtgLogTamamlanan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgLogTamamlanan.Location = new System.Drawing.Point(3, 16);
            this.DtgLogTamamlanan.MultiSelect = false;
            this.DtgLogTamamlanan.Name = "DtgLogTamamlanan";
            this.DtgLogTamamlanan.ReadOnly = true;
            this.DtgLogTamamlanan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgLogTamamlanan.Size = new System.Drawing.Size(998, 151);
            this.DtgLogTamamlanan.TabIndex = 1;
            this.DtgLogTamamlanan.TimeFilter = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TopKayit);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.DtgTamamlanan);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1541, 858);
            this.panel3.TabIndex = 338;
            // 
            // TopKayit
            // 
            this.TopKayit.AutoSize = true;
            this.TopKayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TopKayit.Location = new System.Drawing.Point(103, 657);
            this.TopKayit.Name = "TopKayit";
            this.TopKayit.Size = new System.Drawing.Size(21, 15);
            this.TopKayit.TabIndex = 335;
            this.TopKayit.Text = "00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(3, 657);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 15);
            this.label7.TabIndex = 334;
            this.label7.Text = "Toplam Kayıt:";
            // 
            // DtgTamamlanan
            // 
            this.DtgTamamlanan.AllowUserToAddRows = false;
            this.DtgTamamlanan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgTamamlanan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgTamamlanan.AutoGenerateContextFilters = true;
            this.DtgTamamlanan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgTamamlanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgTamamlanan.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgTamamlanan.DateWithTime = false;
            this.DtgTamamlanan.Location = new System.Drawing.Point(0, 0);
            this.DtgTamamlanan.Name = "DtgTamamlanan";
            this.DtgTamamlanan.ReadOnly = true;
            this.DtgTamamlanan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgTamamlanan.Size = new System.Drawing.Size(1547, 638);
            this.DtgTamamlanan.TabIndex = 3;
            this.DtgTamamlanan.TimeFilter = false;
            this.DtgTamamlanan.SortStringChanged += new System.EventHandler(this.DtgTamamlanan_SortStringChanged);
            this.DtgTamamlanan.FilterStringChanged += new System.EventHandler(this.DtgTamamlanan_FilterStringChanged);
            this.DtgTamamlanan.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgTamamlanan_CellMouseClick);
            // 
            // TxtTop2
            // 
            this.TxtTop2.AutoSize = true;
            this.TxtTop2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop2.Location = new System.Drawing.Point(106, 660);
            this.TxtTop2.Name = "TxtTop2";
            this.TxtTop2.Size = new System.Drawing.Size(21, 15);
            this.TxtTop2.TabIndex = 333;
            this.TxtTop2.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(19, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 15);
            this.label4.TabIndex = 337;
            this.label4.Text = "İŞ AKIŞ NO İLE ARAMA:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(6, 660);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 332;
            this.label5.Text = "Toplam Kayıt:";
            // 
            // TxtAdSoyadTamamlanan
            // 
            this.TxtAdSoyadTamamlanan.Location = new System.Drawing.Point(625, 21);
            this.TxtAdSoyadTamamlanan.Name = "TxtAdSoyadTamamlanan";
            this.TxtAdSoyadTamamlanan.Size = new System.Drawing.Size(205, 20);
            this.TxtAdSoyadTamamlanan.TabIndex = 334;
            this.TxtAdSoyadTamamlanan.TextChanged += new System.EventHandler(this.TxtAdSoyadTamamlanan_TextChanged);
            // 
            // TxtIsAkisNoTamamlanan
            // 
            this.TxtIsAkisNoTamamlanan.Location = new System.Drawing.Point(182, 21);
            this.TxtIsAkisNoTamamlanan.Name = "TxtIsAkisNoTamamlanan";
            this.TxtIsAkisNoTamamlanan.Size = new System.Drawing.Size(205, 20);
            this.TxtIsAkisNoTamamlanan.TabIndex = 336;
            this.TxtIsAkisNoTamamlanan.TextChanged += new System.EventHandler(this.TxtIsAkisNoTamamlanan_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(426, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 15);
            this.label6.TabIndex = 335;
            this.label6.Text = "PERSONEL İSMİ İLE ARAMA:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yenileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(106, 26);
            // 
            // yenileToolStripMenuItem
            // 
            this.yenileToolStripMenuItem.Name = "yenileToolStripMenuItem";
            this.yenileToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.yenileToolStripMenuItem.Text = "Yenile";
            this.yenileToolStripMenuItem.Click += new System.EventHandler(this.yenileToolStripMenuItem_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(6, 654);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 332;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(106, 654);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 333;
            this.TxtTop.Text = "00";
            // 
            // FrmSehirIciGorevIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 924);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSehirIciGorevIzleme";
            this.Text = "FrmSehirIciGorevIzleme";
            this.Load += new System.EventHandler(this.FrmSehirIciGorevIzleme_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgLog)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgLogTamamlanan)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTamamlanan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtAkısNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtAdSoyad;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private ADGV.AdvancedDataGridView DtgTamamlanan;
        private System.Windows.Forms.Label TxtTop2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtAdSoyadTamamlanan;
        private System.Windows.Forms.TextBox TxtIsAkisNoTamamlanan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource dataBinder2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yenileToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private ADGV.AdvancedDataGridView DtgLogTamamlanan;
        private System.Windows.Forms.Label TopKayit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label31;
    }
}