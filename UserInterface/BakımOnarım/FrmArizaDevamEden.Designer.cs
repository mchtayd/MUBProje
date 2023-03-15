
namespace UserInterface.BakımOnarım
{
    partial class FrmArizaDevamEden
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
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.DtgIslemKayitlari = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DtgMalzemeListesi = new ADGV.AdvancedDataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DtgDepoHareketleri = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.LblAtolyeIslemAdimiTop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblToplamIsclikAtolye = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DtgAtolyeIslemler = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgAtolye = new System.Windows.Forms.DataGridView();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblIslemAdimSureleri = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblGenelTop = new System.Windows.Forms.Label();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.ChkTumunuGor = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgIslemKayitlari)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeListesi)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepoHareketleri)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgAtolyeIslemler)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgAtolye)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1555, 27);
            this.panel1.TabIndex = 314;
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
            this.BtnCancel.TabIndex = 19;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgList);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1531, 402);
            this.groupBox1.TabIndex = 315;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AÇIK ARIZALAR";
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
            this.DtgList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgList.DateWithTime = false;
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(3, 16);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgList.Size = new System.Drawing.Size(1525, 383);
            this.DtgList.TabIndex = 2;
            this.DtgList.TimeFilter = false;
            this.DtgList.SortStringChanged += new System.EventHandler(this.DtgList_SortStringChanged);
            this.DtgList.FilterStringChanged += new System.EventHandler(this.DtgList_FilterStringChanged);
            this.DtgList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgList_CellMouseClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 503);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1528, 367);
            this.tabControl1.TabIndex = 316;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.webBrowser1);
            this.tabPage1.Controls.Add(this.DtgIslemKayitlari);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1520, 341);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "İŞLEM KAYITLARI";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(1028, 6);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(486, 329);
            this.webBrowser1.TabIndex = 4;
            // 
            // DtgIslemKayitlari
            // 
            this.DtgIslemKayitlari.AllowUserToAddRows = false;
            this.DtgIslemKayitlari.AllowUserToDeleteRows = false;
            this.DtgIslemKayitlari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgIslemKayitlari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgIslemKayitlari.Location = new System.Drawing.Point(3, 3);
            this.DtgIslemKayitlari.Name = "DtgIslemKayitlari";
            this.DtgIslemKayitlari.ReadOnly = true;
            this.DtgIslemKayitlari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgIslemKayitlari.Size = new System.Drawing.Size(1019, 335);
            this.DtgIslemKayitlari.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DtgMalzemeListesi);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1520, 341);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CİHAZ MALZEME DURUMU";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DtgMalzemeListesi
            // 
            this.DtgMalzemeListesi.AllowUserToAddRows = false;
            this.DtgMalzemeListesi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgMalzemeListesi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgMalzemeListesi.AutoGenerateContextFilters = true;
            this.DtgMalzemeListesi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgMalzemeListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgMalzemeListesi.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgMalzemeListesi.DateWithTime = false;
            this.DtgMalzemeListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgMalzemeListesi.Location = new System.Drawing.Point(3, 3);
            this.DtgMalzemeListesi.MultiSelect = false;
            this.DtgMalzemeListesi.Name = "DtgMalzemeListesi";
            this.DtgMalzemeListesi.ReadOnly = true;
            this.DtgMalzemeListesi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgMalzemeListesi.Size = new System.Drawing.Size(1514, 335);
            this.DtgMalzemeListesi.TabIndex = 3;
            this.DtgMalzemeListesi.TimeFilter = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DtgDepoHareketleri);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1520, 341);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "DEPO HAREKETLERİ";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            this.DtgDepoHareketleri.Size = new System.Drawing.Size(1514, 335);
            this.DtgDepoHareketleri.TabIndex = 345;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label2);
            this.tabPage5.Controls.Add(this.LblAtolyeIslemAdimiTop);
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Controls.Add(this.LblToplamIsclikAtolye);
            this.tabPage5.Controls.Add(this.groupBox3);
            this.tabPage5.Controls.Add(this.groupBox2);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1520, 341);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "ALT TAKIM ONARIM DURUMU";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(693, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 15);
            this.label2.TabIndex = 456;
            this.label2.Text = "Atölye Toplam İşlem Adım Süresi:";
            // 
            // LblAtolyeIslemAdimiTop
            // 
            this.LblAtolyeIslemAdimiTop.AutoSize = true;
            this.LblAtolyeIslemAdimiTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblAtolyeIslemAdimiTop.Location = new System.Drawing.Point(917, 313);
            this.LblAtolyeIslemAdimiTop.Name = "LblAtolyeIslemAdimiTop";
            this.LblAtolyeIslemAdimiTop.Size = new System.Drawing.Size(21, 15);
            this.LblAtolyeIslemAdimiTop.TabIndex = 457;
            this.LblAtolyeIslemAdimiTop.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(1101, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 15);
            this.label5.TabIndex = 454;
            this.label5.Text = "Atölye Toplam Harcanan İşçilik:";
            // 
            // LblToplamIsclikAtolye
            // 
            this.LblToplamIsclikAtolye.AutoSize = true;
            this.LblToplamIsclikAtolye.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblToplamIsclikAtolye.Location = new System.Drawing.Point(1315, 313);
            this.LblToplamIsclikAtolye.Name = "LblToplamIsclikAtolye";
            this.LblToplamIsclikAtolye.Size = new System.Drawing.Size(21, 15);
            this.LblToplamIsclikAtolye.TabIndex = 455;
            this.LblToplamIsclikAtolye.Text = "00";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DtgAtolyeIslemler);
            this.groupBox3.Location = new System.Drawing.Point(693, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(821, 304);
            this.groupBox3.TabIndex = 348;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ATÖLYE İŞLEM KAYITLARI";
            // 
            // DtgAtolyeIslemler
            // 
            this.DtgAtolyeIslemler.AllowUserToAddRows = false;
            this.DtgAtolyeIslemler.AllowUserToDeleteRows = false;
            this.DtgAtolyeIslemler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgAtolyeIslemler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgAtolyeIslemler.Location = new System.Drawing.Point(3, 16);
            this.DtgAtolyeIslemler.Name = "DtgAtolyeIslemler";
            this.DtgAtolyeIslemler.ReadOnly = true;
            this.DtgAtolyeIslemler.Size = new System.Drawing.Size(815, 285);
            this.DtgAtolyeIslemler.TabIndex = 346;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgAtolye);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(684, 329);
            this.groupBox2.TabIndex = 347;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ATÖLYE KAYITLARI";
            // 
            // DtgAtolye
            // 
            this.DtgAtolye.AllowUserToAddRows = false;
            this.DtgAtolye.AllowUserToDeleteRows = false;
            this.DtgAtolye.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgAtolye.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgAtolye.Location = new System.Drawing.Point(3, 16);
            this.DtgAtolye.Name = "DtgAtolye";
            this.DtgAtolye.ReadOnly = true;
            this.DtgAtolye.Size = new System.Drawing.Size(678, 310);
            this.DtgAtolye.TabIndex = 346;
            this.DtgAtolye.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgAtolye_CellMouseClick);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(12, 476);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 342;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(112, 476);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 343;
            this.TxtTop.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(16, 876);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 15);
            this.label1.TabIndex = 452;
            this.label1.Text = "Toplam İşlem Adım Süresi:";
            // 
            // LblIslemAdimSureleri
            // 
            this.LblIslemAdimSureleri.AutoSize = true;
            this.LblIslemAdimSureleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblIslemAdimSureleri.Location = new System.Drawing.Point(201, 876);
            this.LblIslemAdimSureleri.Name = "LblIslemAdimSureleri";
            this.LblIslemAdimSureleri.Size = new System.Drawing.Size(21, 15);
            this.LblIslemAdimSureleri.TabIndex = 453;
            this.LblIslemAdimSureleri.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(384, 876);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 15);
            this.label3.TabIndex = 450;
            this.label3.Text = "Toplam Harcanan İşçilik:";
            // 
            // LblGenelTop
            // 
            this.LblGenelTop.AutoSize = true;
            this.LblGenelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblGenelTop.Location = new System.Drawing.Point(556, 876);
            this.LblGenelTop.Name = "LblGenelTop";
            this.LblGenelTop.Size = new System.Drawing.Size(21, 15);
            this.LblGenelTop.TabIndex = 451;
            this.LblGenelTop.Text = "00";
            // 
            // ChkTumunuGor
            // 
            this.ChkTumunuGor.AutoSize = true;
            this.ChkTumunuGor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkTumunuGor.Location = new System.Drawing.Point(15, 41);
            this.ChkTumunuGor.Name = "ChkTumunuGor";
            this.ChkTumunuGor.Size = new System.Drawing.Size(121, 22);
            this.ChkTumunuGor.TabIndex = 454;
            this.ChkTumunuGor.Text = "Tümünü Gör";
            this.ChkTumunuGor.UseVisualStyleBackColor = true;
            this.ChkTumunuGor.CheckedChanged += new System.EventHandler(this.ChkTumunuGor_CheckedChanged);
            // 
            // FrmArizaDevamEden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1555, 909);
            this.Controls.Add(this.ChkTumunuGor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblIslemAdimSureleri);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblGenelTop);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmArizaDevamEden";
            this.Text = "FrmArizaDevamEden";
            this.Load += new System.EventHandler(this.FrmArizaDevamEden_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgIslemKayitlari)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeListesi)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepoHareketleri)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgAtolyeIslemler)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgAtolye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label TxtTop;
        private ADGV.AdvancedDataGridView DtgMalzemeListesi;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.DataGridView DtgIslemKayitlari;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblIslemAdimSureleri;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblGenelTop;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.DataGridView DtgDepoHareketleri;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DtgAtolyeIslemler;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DtgAtolye;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblAtolyeIslemAdimiTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblToplamIsclikAtolye;
        private System.Windows.Forms.CheckBox ChkTumunuGor;
    }
}