namespace UserInterface.BakımOnarım
{
    partial class FrmOkfIzleme
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.LblTop = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DtgMalzemeList = new System.Windows.Forms.DataGridView();
            this.StokNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanimm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PBirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirimTutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToplamTutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DtgYapilacakIslemler = new System.Windows.Forms.DataGridView();
            this.YapilacakIslemler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.LblToplamGenel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblTop2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.güncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeList)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgYapilacakIslemler)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1555, 31);
            this.panel1.TabIndex = 46;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(12, 525);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 15);
            this.label6.TabIndex = 347;
            this.label6.Text = "Toplam Kayıt:";
            // 
            // LblTop
            // 
            this.LblTop.AutoSize = true;
            this.LblTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTop.Location = new System.Drawing.Point(112, 525);
            this.LblTop.Name = "LblTop";
            this.LblTop.Size = new System.Drawing.Size(21, 15);
            this.LblTop.TabIndex = 348;
            this.LblTop.Text = "00";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.DtgList);
            this.groupBox6.Location = new System.Drawing.Point(12, 36);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1518, 477);
            this.groupBox6.TabIndex = 346;
            this.groupBox6.TabStop = false;
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AllowUserToOrderColumns = true;
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
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgList.Size = new System.Drawing.Size(1512, 458);
            this.DtgList.TabIndex = 2;
            this.DtgList.TimeFilter = false;
            this.DtgList.SortStringChanged += new System.EventHandler(this.DtgList_SortStringChanged);
            this.DtgList.FilterStringChanged += new System.EventHandler(this.DtgList_FilterStringChanged);
            this.DtgList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgList_CellMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowser1);
            this.groupBox2.Location = new System.Drawing.Point(816, 556);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(714, 316);
            this.groupBox2.TabIndex = 352;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ekler";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(708, 297);
            this.webBrowser1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 552);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(795, 324);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DtgMalzemeList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(787, 298);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MALZEME LİSTESİ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DtgMalzemeList
            // 
            this.DtgMalzemeList.AllowUserToAddRows = false;
            this.DtgMalzemeList.AllowUserToDeleteRows = false;
            this.DtgMalzemeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgMalzemeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgMalzemeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StokNo,
            this.Tanimm,
            this.Miktar,
            this.Birim,
            this.PBirim,
            this.BirimTutar,
            this.ToplamTutar});
            this.DtgMalzemeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgMalzemeList.Location = new System.Drawing.Point(3, 3);
            this.DtgMalzemeList.Name = "DtgMalzemeList";
            this.DtgMalzemeList.ReadOnly = true;
            this.DtgMalzemeList.Size = new System.Drawing.Size(781, 292);
            this.DtgMalzemeList.TabIndex = 533;
            // 
            // StokNo
            // 
            this.StokNo.HeaderText = "STOK NO";
            this.StokNo.Name = "StokNo";
            this.StokNo.ReadOnly = true;
            this.StokNo.Width = 80;
            // 
            // Tanimm
            // 
            this.Tanimm.HeaderText = "TANIM";
            this.Tanimm.Name = "Tanimm";
            this.Tanimm.ReadOnly = true;
            this.Tanimm.Width = 66;
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
            // PBirim
            // 
            this.PBirim.HeaderText = "P.BİRİM";
            this.PBirim.Name = "PBirim";
            this.PBirim.ReadOnly = true;
            this.PBirim.Width = 72;
            // 
            // BirimTutar
            // 
            this.BirimTutar.HeaderText = "BİRİM TUTAR";
            this.BirimTutar.Name = "BirimTutar";
            this.BirimTutar.ReadOnly = true;
            this.BirimTutar.Width = 102;
            // 
            // ToplamTutar
            // 
            this.ToplamTutar.HeaderText = "TOPLAM TUTAR";
            this.ToplamTutar.Name = "ToplamTutar";
            this.ToplamTutar.ReadOnly = true;
            this.ToplamTutar.Width = 106;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DtgYapilacakIslemler);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(787, 298);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "YAPILACAK İŞLEMLER";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DtgYapilacakIslemler
            // 
            this.DtgYapilacakIslemler.AllowUserToAddRows = false;
            this.DtgYapilacakIslemler.AllowUserToDeleteRows = false;
            this.DtgYapilacakIslemler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgYapilacakIslemler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgYapilacakIslemler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.YapilacakIslemler});
            this.DtgYapilacakIslemler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgYapilacakIslemler.Location = new System.Drawing.Point(3, 3);
            this.DtgYapilacakIslemler.Name = "DtgYapilacakIslemler";
            this.DtgYapilacakIslemler.ReadOnly = true;
            this.DtgYapilacakIslemler.Size = new System.Drawing.Size(781, 292);
            this.DtgYapilacakIslemler.TabIndex = 469;
            // 
            // YapilacakIslemler
            // 
            this.YapilacakIslemler.HeaderText = "YAPILACAK İŞLEMLER";
            this.YapilacakIslemler.Name = "YapilacakIslemler";
            this.YapilacakIslemler.ReadOnly = true;
            this.YapilacakIslemler.Width = 133;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(266, 525);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 353;
            this.label1.Text = "Genel Toplam:";
            // 
            // LblToplamGenel
            // 
            this.LblToplamGenel.AutoSize = true;
            this.LblToplamGenel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblToplamGenel.Location = new System.Drawing.Point(373, 525);
            this.LblToplamGenel.Name = "LblToplamGenel";
            this.LblToplamGenel.Size = new System.Drawing.Size(21, 15);
            this.LblToplamGenel.TabIndex = 354;
            this.LblToplamGenel.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(19, 879);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 355;
            this.label3.Text = "Genel Toplam:";
            // 
            // LblTop2
            // 
            this.LblTop2.AutoSize = true;
            this.LblTop2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTop2.Location = new System.Drawing.Point(126, 879);
            this.LblTop2.Name = "LblTop2";
            this.LblTop2.Size = new System.Drawing.Size(21, 15);
            this.LblTop2.TabIndex = 356;
            this.LblTop2.Text = "00";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.güncelleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 26);
            // 
            // güncelleToolStripMenuItem
            // 
            this.güncelleToolStripMenuItem.Name = "güncelleToolStripMenuItem";
            this.güncelleToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.güncelleToolStripMenuItem.Text = "Güncelle";
            this.güncelleToolStripMenuItem.Click += new System.EventHandler(this.güncelleToolStripMenuItem_Click);
            // 
            // FrmOkfIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1555, 909);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblTop2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblToplamGenel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LblTop);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.panel1);
            this.Name = "FrmOkfIzleme";
            this.Text = "FrmOkfIzleme";
            this.Load += new System.EventHandler(this.FrmOkfIzleme_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeList)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgYapilacakIslemler)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblTop;
        private System.Windows.Forms.GroupBox groupBox6;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.DataGridView DtgMalzemeList;
        private System.Windows.Forms.DataGridViewTextBoxColumn StokNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanimm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Miktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birim;
        private System.Windows.Forms.DataGridViewTextBoxColumn PBirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirimTutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToplamTutar;
        private System.Windows.Forms.DataGridView DtgYapilacakIslemler;
        private System.Windows.Forms.DataGridViewTextBoxColumn YapilacakIslemler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblToplamGenel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblTop2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem güncelleToolStripMenuItem;
    }
}