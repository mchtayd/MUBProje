
namespace UserInterface.BakımOnarım
{
    partial class FrmAtolyeDataGuncelle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.DtgIslemKayitlari = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.işlemAdımınıSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.DtgMalzemeler = new ADGV.AdvancedDataGridView();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.DtgDepoHareketleri = new System.Windows.Forms.DataGridView();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtBildirilenAriza = new System.Windows.Forms.RichTextBox();
            this.BtnGuncelle = new System.Windows.Forms.Button();
            this.BtnSil = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgAtolye = new System.Windows.Forms.DataGridView();
            this.tabControl3.SuspendLayout();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgIslemKayitlari)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeler)).BeginInit();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepoHareketleri)).BeginInit();
            this.tabPage11.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgAtolye)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage8);
            this.tabControl3.Controls.Add(this.tabPage9);
            this.tabControl3.Controls.Add(this.tabPage10);
            this.tabControl3.Controls.Add(this.tabPage11);
            this.tabControl3.Controls.Add(this.tabPage1);
            this.tabControl3.Location = new System.Drawing.Point(12, 134);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(1433, 316);
            this.tabControl3.TabIndex = 439;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.DtgIslemKayitlari);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1425, 290);
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
            this.DtgIslemKayitlari.ContextMenuStrip = this.contextMenuStrip1;
            this.DtgIslemKayitlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgIslemKayitlari.Location = new System.Drawing.Point(3, 3);
            this.DtgIslemKayitlari.Name = "DtgIslemKayitlari";
            this.DtgIslemKayitlari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgIslemKayitlari.Size = new System.Drawing.Size(1419, 284);
            this.DtgIslemKayitlari.TabIndex = 2;
            this.DtgIslemKayitlari.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgIslemKayitlari_CellMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.işlemAdımınıSilToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 26);
            // 
            // işlemAdımınıSilToolStripMenuItem
            // 
            this.işlemAdımınıSilToolStripMenuItem.Name = "işlemAdımınıSilToolStripMenuItem";
            this.işlemAdımınıSilToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.işlemAdımınıSilToolStripMenuItem.Text = "İşlem Adımını Sil";
            this.işlemAdımınıSilToolStripMenuItem.Click += new System.EventHandler(this.işlemAdımınıSilToolStripMenuItem_Click);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.DtgMalzemeler);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(1425, 290);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "CİHAZ MALZEME DURUMU";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // DtgMalzemeler
            // 
            this.DtgMalzemeler.AllowUserToAddRows = false;
            this.DtgMalzemeler.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgMalzemeler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
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
            this.DtgMalzemeler.Size = new System.Drawing.Size(1419, 284);
            this.DtgMalzemeler.TabIndex = 3;
            this.DtgMalzemeler.TimeFilter = false;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.DtgDepoHareketleri);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(1425, 290);
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
            this.DtgDepoHareketleri.Size = new System.Drawing.Size(1419, 284);
            this.DtgDepoHareketleri.TabIndex = 344;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.webBrowser1);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(1425, 290);
            this.tabPage11.TabIndex = 3;
            this.tabPage11.Text = "EKLER";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(6, 6);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(784, 261);
            this.webBrowser1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1425, 290);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "ÜST TAKIMDA BİLDİRİLEN ARIZA";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtBildirilenAriza);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(670, 267);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // TxtBildirilenAriza
            // 
            this.TxtBildirilenAriza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBildirilenAriza.Location = new System.Drawing.Point(3, 16);
            this.TxtBildirilenAriza.Name = "TxtBildirilenAriza";
            this.TxtBildirilenAriza.Size = new System.Drawing.Size(664, 248);
            this.TxtBildirilenAriza.TabIndex = 0;
            this.TxtBildirilenAriza.Text = "";
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Location = new System.Drawing.Point(124, 452);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(103, 38);
            this.BtnGuncelle.TabIndex = 442;
            this.BtnGuncelle.Text = "GÜNCELLE";
            this.BtnGuncelle.UseVisualStyleBackColor = true;
            this.BtnGuncelle.Visible = false;
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // BtnSil
            // 
            this.BtnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSil.Location = new System.Drawing.Point(15, 452);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(103, 38);
            this.BtnSil.TabIndex = 443;
            this.BtnSil.Text = "SİL";
            this.BtnSil.UseVisualStyleBackColor = true;
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgAtolye);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1429, 106);
            this.groupBox1.TabIndex = 447;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GENEL BİLGİLER";
            // 
            // DtgAtolye
            // 
            this.DtgAtolye.AllowUserToAddRows = false;
            this.DtgAtolye.AllowUserToDeleteRows = false;
            this.DtgAtolye.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgAtolye.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgAtolye.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgAtolye.Location = new System.Drawing.Point(3, 16);
            this.DtgAtolye.Name = "DtgAtolye";
            this.DtgAtolye.Size = new System.Drawing.Size(1423, 87);
            this.DtgAtolye.TabIndex = 0;
            // 
            // FrmAtolyeDataGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1459, 507);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnSil);
            this.Controls.Add(this.BtnGuncelle);
            this.Controls.Add(this.tabControl3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAtolyeDataGuncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atölye Güncelle";
            this.Load += new System.EventHandler(this.FrmAtolyeDataGuncelle_Load);
            this.tabControl3.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgIslemKayitlari)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeler)).EndInit();
            this.tabPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepoHareketleri)).EndInit();
            this.tabPage11.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgAtolye)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.DataGridView DtgIslemKayitlari;
        private System.Windows.Forms.TabPage tabPage9;
        private ADGV.AdvancedDataGridView DtgMalzemeler;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.DataGridView DtgDepoHareketleri;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox TxtBildirilenAriza;
        private System.Windows.Forms.Button BtnGuncelle;
        private System.Windows.Forms.Button BtnSil;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DtgAtolye;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem işlemAdımınıSilToolStripMenuItem;
    }
}