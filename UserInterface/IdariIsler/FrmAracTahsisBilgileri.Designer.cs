
namespace UserInterface.IdariIsler
{
    partial class FrmAracTahsisBilgileri
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yenileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPlaka = new System.Windows.Forms.TextBox();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgIslemAdimlari = new ADGV.AdvancedDataGridView();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DtgIslemAdimlariDis = new ADGV.AdvancedDataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtTopDis = new System.Windows.Forms.Label();
            this.DtgListDis = new ADGV.AdvancedDataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtPlakaD = new System.Windows.Forms.TextBox();
            this.dataBinder2 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgIslemAdimlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgIslemAdimlariDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgListDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).BeginInit();
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
            this.DtgList.ContextMenuStrip = this.contextMenuStrip1;
            this.DtgList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgList.DateWithTime = false;
            this.DtgList.Location = new System.Drawing.Point(6, 58);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgList.Size = new System.Drawing.Size(1540, 577);
            this.DtgList.TabIndex = 320;
            this.DtgList.TimeFilter = false;
            this.DtgList.SortStringChanged += new System.EventHandler(this.DtgList_SortStringChanged);
            this.DtgList.FilterStringChanged += new System.EventHandler(this.DtgList_FilterStringChanged);
            this.DtgList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgList_CellMouseClick);
            this.DtgList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DtgList_KeyDown);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 15);
            this.label1.TabIndex = 339;
            this.label1.Text = "ARAÇ PLAKASIYLA ARAMA:";
            // 
            // TxtPlaka
            // 
            this.TxtPlaka.Location = new System.Drawing.Point(209, 20);
            this.TxtPlaka.Name = "TxtPlaka";
            this.TxtPlaka.Size = new System.Drawing.Size(205, 20);
            this.TxtPlaka.TabIndex = 338;
            this.TxtPlaka.TextChanged += new System.EventHandler(this.TxtPlaka_TextChanged);
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(108, 648);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 341;
            this.TxtTop.Text = "00";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(8, 648);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 340;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowser1);
            this.groupBox2.Location = new System.Drawing.Point(700, 678);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(686, 170);
            this.groupBox2.TabIndex = 343;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ARAÇ DOSYASI";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(680, 151);
            this.webBrowser1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgIslemAdimlari);
            this.groupBox1.Location = new System.Drawing.Point(8, 678);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 170);
            this.groupBox1.TabIndex = 342;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İŞLEM ADIMLARI";
            // 
            // DtgIslemAdimlari
            // 
            this.DtgIslemAdimlari.AutoGenerateContextFilters = true;
            this.DtgIslemAdimlari.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtgIslemAdimlari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgIslemAdimlari.DateWithTime = false;
            this.DtgIslemAdimlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgIslemAdimlari.Location = new System.Drawing.Point(3, 16);
            this.DtgIslemAdimlari.Name = "DtgIslemAdimlari";
            this.DtgIslemAdimlari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgIslemAdimlari.Size = new System.Drawing.Size(680, 151);
            this.DtgIslemAdimlari.TabIndex = 0;
            this.DtgIslemAdimlari.TimeFilter = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1557, 883);
            this.tabControl1.TabIndex = 344;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.TxtPlaka);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.DtgList);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.TxtTop);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1549, 857);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PROJE İÇİ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.TxtTopDis);
            this.tabPage2.Controls.Add(this.DtgListDis);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.TxtPlakaD);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1549, 857);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PROJE DIŞI";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.webBrowser2);
            this.groupBox3.Location = new System.Drawing.Point(700, 678);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(686, 170);
            this.groupBox3.TabIndex = 347;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ARAÇ DOSYASI";
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.Location = new System.Drawing.Point(3, 16);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(680, 151);
            this.webBrowser2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DtgIslemAdimlariDis);
            this.groupBox4.Location = new System.Drawing.Point(8, 678);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(686, 170);
            this.groupBox4.TabIndex = 346;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "İŞLEM ADIMLARI";
            // 
            // DtgIslemAdimlariDis
            // 
            this.DtgIslemAdimlariDis.AutoGenerateContextFilters = true;
            this.DtgIslemAdimlariDis.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtgIslemAdimlariDis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgIslemAdimlariDis.DateWithTime = false;
            this.DtgIslemAdimlariDis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgIslemAdimlariDis.Location = new System.Drawing.Point(3, 16);
            this.DtgIslemAdimlariDis.Name = "DtgIslemAdimlariDis";
            this.DtgIslemAdimlariDis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgIslemAdimlariDis.Size = new System.Drawing.Size(680, 151);
            this.DtgIslemAdimlariDis.TabIndex = 0;
            this.DtgIslemAdimlariDis.TimeFilter = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(8, 648);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 344;
            this.label3.Text = "Toplam Kayıt:";
            // 
            // TxtTopDis
            // 
            this.TxtTopDis.AutoSize = true;
            this.TxtTopDis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTopDis.Location = new System.Drawing.Point(108, 648);
            this.TxtTopDis.Name = "TxtTopDis";
            this.TxtTopDis.Size = new System.Drawing.Size(21, 15);
            this.TxtTopDis.TabIndex = 345;
            this.TxtTopDis.Text = "00";
            // 
            // DtgListDis
            // 
            this.DtgListDis.AllowUserToAddRows = false;
            this.DtgListDis.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgListDis.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgListDis.AutoGenerateContextFilters = true;
            this.DtgListDis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgListDis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgListDis.ContextMenuStrip = this.contextMenuStrip1;
            this.DtgListDis.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgListDis.DateWithTime = false;
            this.DtgListDis.Location = new System.Drawing.Point(0, 64);
            this.DtgListDis.Name = "DtgListDis";
            this.DtgListDis.ReadOnly = true;
            this.DtgListDis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgListDis.Size = new System.Drawing.Size(1540, 577);
            this.DtgListDis.TabIndex = 342;
            this.DtgListDis.TimeFilter = false;
            this.DtgListDis.SortStringChanged += new System.EventHandler(this.DtgListDis_SortStringChanged);
            this.DtgListDis.FilterStringChanged += new System.EventHandler(this.DtgListDis_FilterStringChanged);
            this.DtgListDis.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgListDis_CellMouseClick);
            this.DtgListDis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DtgListDis_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(19, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 15);
            this.label2.TabIndex = 341;
            this.label2.Text = "ARAÇ PLAKASIYLA ARAMA:";
            // 
            // TxtPlakaD
            // 
            this.TxtPlakaD.Location = new System.Drawing.Point(204, 27);
            this.TxtPlakaD.Name = "TxtPlakaD";
            this.TxtPlakaD.Size = new System.Drawing.Size(205, 20);
            this.TxtPlakaD.TabIndex = 340;
            this.TxtPlakaD.TextChanged += new System.EventHandler(this.TxtPlakaD_TextChanged);
            // 
            // FrmAracTahsisBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 924);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAracTahsisBilgileri";
            this.Text = "FrmAracTahsisBilgileri";
            this.Load += new System.EventHandler(this.FrmAracTahsisBilgileri_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgIslemAdimlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgIslemAdimlariDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgListDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtPlaka;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgIslemAdimlari;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yenileToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.GroupBox groupBox4;
        private ADGV.AdvancedDataGridView DtgIslemAdimlariDis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TxtTopDis;
        private ADGV.AdvancedDataGridView DtgListDis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtPlakaD;
        private System.Windows.Forms.BindingSource dataBinder2;
    }
}