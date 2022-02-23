
namespace UserInterface.BakımOnarım
{
    partial class FrmBOAtolyeTamamlananlar
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgTamamlanan = new ADGV.AdvancedDataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.LblGenelTop = new System.Windows.Forms.Label();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.DtgIslemKayitlari = new System.Windows.Forms.DataGridView();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.DtgMalzemeler = new ADGV.AdvancedDataGridView();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.DtgDepoHareketleri = new System.Windows.Forms.DataGridView();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblIslemAdimSureleri = new System.Windows.Forms.Label();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.dataBinder2 = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.işlemAdımlarınıDuzeltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTamamlanan)).BeginInit();
            this.tabControl3.SuspendLayout();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgIslemKayitlari)).BeginInit();
            this.tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeler)).BeginInit();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepoHareketleri)).BeginInit();
            this.tabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1455, 27);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgTamamlanan);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1431, 366);
            this.groupBox1.TabIndex = 320;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TAMAMLANAN ARIZALAR";
            // 
            // DtgTamamlanan
            // 
            this.DtgTamamlanan.AllowUserToAddRows = false;
            this.DtgTamamlanan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgTamamlanan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgTamamlanan.AutoGenerateContextFilters = true;
            this.DtgTamamlanan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgTamamlanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgTamamlanan.ContextMenuStrip = this.contextMenuStrip1;
            this.DtgTamamlanan.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgTamamlanan.DateWithTime = false;
            this.DtgTamamlanan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgTamamlanan.Location = new System.Drawing.Point(3, 16);
            this.DtgTamamlanan.MultiSelect = false;
            this.DtgTamamlanan.Name = "DtgTamamlanan";
            this.DtgTamamlanan.ReadOnly = true;
            this.DtgTamamlanan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgTamamlanan.Size = new System.Drawing.Size(1425, 347);
            this.DtgTamamlanan.TabIndex = 4;
            this.DtgTamamlanan.TimeFilter = false;
            this.DtgTamamlanan.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgTamamlanan_CellMouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(431, 794);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 15);
            this.label3.TabIndex = 444;
            this.label3.Text = "Toplam Harcanan İşçilik:";
            // 
            // LblGenelTop
            // 
            this.LblGenelTop.AutoSize = true;
            this.LblGenelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblGenelTop.Location = new System.Drawing.Point(603, 794);
            this.LblGenelTop.Name = "LblGenelTop";
            this.LblGenelTop.Size = new System.Drawing.Size(21, 15);
            this.LblGenelTop.TabIndex = 445;
            this.LblGenelTop.Text = "00";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage8);
            this.tabControl3.Controls.Add(this.tabPage9);
            this.tabControl3.Controls.Add(this.tabPage10);
            this.tabControl3.Controls.Add(this.tabPage11);
            this.tabControl3.Location = new System.Drawing.Point(15, 438);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(1429, 350);
            this.tabControl3.TabIndex = 443;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.DtgIslemKayitlari);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1421, 324);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "İŞLEM KAYITLARI";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // DtgIslemKayitlari
            // 
            this.DtgIslemKayitlari.AllowUserToAddRows = false;
            this.DtgIslemKayitlari.AllowUserToDeleteRows = false;
            this.DtgIslemKayitlari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgIslemKayitlari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgIslemKayitlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgIslemKayitlari.Location = new System.Drawing.Point(3, 3);
            this.DtgIslemKayitlari.Name = "DtgIslemKayitlari";
            this.DtgIslemKayitlari.ReadOnly = true;
            this.DtgIslemKayitlari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgIslemKayitlari.Size = new System.Drawing.Size(1415, 318);
            this.DtgIslemKayitlari.TabIndex = 2;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.DtgMalzemeler);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(1421, 324);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "CİHAZ MALZEME DURUMU";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // DtgMalzemeler
            // 
            this.DtgMalzemeler.AllowUserToAddRows = false;
            this.DtgMalzemeler.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgMalzemeler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgMalzemeler.AutoGenerateContextFilters = true;
            this.DtgMalzemeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgMalzemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgMalzemeler.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgMalzemeler.DateWithTime = false;
            this.DtgMalzemeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgMalzemeler.Location = new System.Drawing.Point(3, 3);
            this.DtgMalzemeler.MultiSelect = false;
            this.DtgMalzemeler.Name = "DtgMalzemeler";
            this.DtgMalzemeler.ReadOnly = true;
            this.DtgMalzemeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgMalzemeler.Size = new System.Drawing.Size(1415, 318);
            this.DtgMalzemeler.TabIndex = 3;
            this.DtgMalzemeler.TimeFilter = false;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.DtgDepoHareketleri);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(1421, 324);
            this.tabPage10.TabIndex = 2;
            this.tabPage10.Text = "DEPO HAREKETLERİ";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // DtgDepoHareketleri
            // 
            this.DtgDepoHareketleri.AllowUserToAddRows = false;
            this.DtgDepoHareketleri.AllowUserToDeleteRows = false;
            this.DtgDepoHareketleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDepoHareketleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgDepoHareketleri.Location = new System.Drawing.Point(3, 3);
            this.DtgDepoHareketleri.Name = "DtgDepoHareketleri";
            this.DtgDepoHareketleri.ReadOnly = true;
            this.DtgDepoHareketleri.Size = new System.Drawing.Size(1415, 318);
            this.DtgDepoHareketleri.TabIndex = 344;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.webBrowser1);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(1421, 324);
            this.tabPage11.TabIndex = 3;
            this.tabPage11.Text = "EKLER";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(3, 6);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(784, 312);
            this.webBrowser1.TabIndex = 2;
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(115, 411);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 442;
            this.TxtTop.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(15, 411);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 441;
            this.label5.Text = "Toplam Kayıt:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(19, 794);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 15);
            this.label1.TabIndex = 446;
            this.label1.Text = "Toplam İşlem Adım Süresi:";
            // 
            // LblIslemAdimSureleri
            // 
            this.LblIslemAdimSureleri.AutoSize = true;
            this.LblIslemAdimSureleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblIslemAdimSureleri.Location = new System.Drawing.Point(204, 794);
            this.LblIslemAdimSureleri.Name = "LblIslemAdimSureleri";
            this.LblIslemAdimSureleri.Size = new System.Drawing.Size(21, 15);
            this.LblIslemAdimSureleri.TabIndex = 447;
            this.LblIslemAdimSureleri.Text = "00";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.işlemAdımlarınıDuzeltToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(197, 48);
            // 
            // işlemAdımlarınıDuzeltToolStripMenuItem
            // 
            this.işlemAdımlarınıDuzeltToolStripMenuItem.Name = "işlemAdımlarınıDuzeltToolStripMenuItem";
            this.işlemAdımlarınıDuzeltToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.işlemAdımlarınıDuzeltToolStripMenuItem.Text = "İşlem Adımlarını Duzelt";
            this.işlemAdımlarınıDuzeltToolStripMenuItem.Click += new System.EventHandler(this.işlemAdımlarınıDuzeltToolStripMenuItem_Click);
            // 
            // FrmBOAtolyeTamamlananlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1455, 820);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblIslemAdimSureleri);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblGenelTop);
            this.Controls.Add(this.tabControl3);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBOAtolyeTamamlananlar";
            this.Text = "FrmBOAtolyeTamamlananlar";
            this.Load += new System.EventHandler(this.FrmBOAtolyeTamamlananlar_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgTamamlanan)).EndInit();
            this.tabControl3.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgIslemKayitlari)).EndInit();
            this.tabPage9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeler)).EndInit();
            this.tabPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepoHareketleri)).EndInit();
            this.tabPage11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgTamamlanan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblGenelTop;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.DataGridView DtgIslemKayitlari;
        private System.Windows.Forms.TabPage tabPage9;
        private ADGV.AdvancedDataGridView DtgMalzemeler;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.DataGridView DtgDepoHareketleri;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblIslemAdimSureleri;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.BindingSource dataBinder2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem işlemAdımlarınıDuzeltToolStripMenuItem;
    }
}