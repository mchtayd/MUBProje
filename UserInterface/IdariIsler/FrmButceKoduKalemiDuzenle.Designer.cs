
namespace UserInterface.IdariIsler
{
    partial class FrmButceKoduKalemiDuzenle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmButceKoduKalemiDuzenle));
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtButceKodu = new System.Windows.Forms.TextBox();
            this.TxtTanimi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtAciklama = new System.Windows.Forms.RichTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbFirma = new System.Windows.Forms.ComboBox();
            this.BtnGiderFirma = new System.Windows.Forms.Button();
            this.BtnGuncelle = new System.Windows.Forms.Button();
            this.BtnSil = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.BtnTemizle = new System.Windows.Forms.Button();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.PnlKayit = new System.Windows.Forms.Panel();
            this.BtnTumunuSec = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.PnlKayit.SuspendLayout();
            this.SuspendLayout();
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
            this.DtgList.Location = new System.Drawing.Point(12, 45);
            this.DtgList.MultiSelect = false;
            this.DtgList.Name = "DtgList";
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgList.Size = new System.Drawing.Size(865, 621);
            this.DtgList.TabIndex = 321;
            this.DtgList.TimeFilter = false;
            this.DtgList.SortStringChanged += new System.EventHandler(this.DtgList_SortStringChanged);
            this.DtgList.FilterStringChanged += new System.EventHandler(this.DtgList_FilterStringChanged);
            this.DtgList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgList_CellMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 322;
            this.label1.Text = "Bütçe Kodu:";
            // 
            // TxtButceKodu
            // 
            this.TxtButceKodu.Location = new System.Drawing.Point(24, 34);
            this.TxtButceKodu.Name = "TxtButceKodu";
            this.TxtButceKodu.Size = new System.Drawing.Size(93, 20);
            this.TxtButceKodu.TabIndex = 323;
            // 
            // TxtTanimi
            // 
            this.TxtTanimi.Location = new System.Drawing.Point(123, 34);
            this.TxtTanimi.Name = "TxtTanimi";
            this.TxtTanimi.Size = new System.Drawing.Size(327, 20);
            this.TxtTanimi.TabIndex = 325;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 324;
            this.label2.Text = "Bütçe Kalem:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 326;
            this.label3.Text = "Açıklama:";
            // 
            // TxtAciklama
            // 
            this.TxtAciklama.Location = new System.Drawing.Point(24, 88);
            this.TxtAciklama.Name = "TxtAciklama";
            this.TxtAciklama.Size = new System.Drawing.Size(426, 119);
            this.TxtAciklama.TabIndex = 327;
            this.TxtAciklama.Text = "";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(12, 672);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 342;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(112, 672);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 343;
            this.TxtTop.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 347;
            this.label4.Text = "Gider Karşılayacak Firma:";
            // 
            // CmbFirma
            // 
            this.CmbFirma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFirma.FormattingEnabled = true;
            this.CmbFirma.Location = new System.Drawing.Point(24, 236);
            this.CmbFirma.Name = "CmbFirma";
            this.CmbFirma.Size = new System.Drawing.Size(252, 21);
            this.CmbFirma.TabIndex = 348;
            // 
            // BtnGiderFirma
            // 
            this.BtnGiderFirma.AccessibleDescription = "";
            this.BtnGiderFirma.BackColor = System.Drawing.SystemColors.Control;
            this.BtnGiderFirma.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnGiderFirma.BackgroundImage")));
            this.BtnGiderFirma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnGiderFirma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGiderFirma.Location = new System.Drawing.Point(282, 231);
            this.BtnGiderFirma.Margin = new System.Windows.Forms.Padding(0);
            this.BtnGiderFirma.Name = "BtnGiderFirma";
            this.BtnGiderFirma.Size = new System.Drawing.Size(34, 29);
            this.BtnGiderFirma.TabIndex = 397;
            this.BtnGiderFirma.Tag = "admin";
            this.BtnGiderFirma.UseVisualStyleBackColor = false;
            this.BtnGiderFirma.Click += new System.EventHandler(this.BtnGiderFirma_Click);
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Image = ((System.Drawing.Image)(resources.GetObject("BtnGuncelle.Image")));
            this.BtnGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuncelle.Location = new System.Drawing.Point(1030, 321);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(130, 51);
            this.BtnGuncelle.TabIndex = 398;
            this.BtnGuncelle.Text = "  GÜNCELLE";
            this.BtnGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuncelle.UseVisualStyleBackColor = false;
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // BtnSil
            // 
            this.BtnSil.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSil.Image = ((System.Drawing.Image)(resources.GetObject("BtnSil.Image")));
            this.BtnSil.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSil.Location = new System.Drawing.Point(1166, 321);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(130, 51);
            this.BtnSil.TabIndex = 399;
            this.BtnSil.Text = "          SİL";
            this.BtnSil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSil.UseVisualStyleBackColor = false;
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "broom.png");
            // 
            // BtnTemizle
            // 
            this.BtnTemizle.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTemizle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnTemizle.ImageKey = "broom.png";
            this.BtnTemizle.ImageList = this.ımageList1;
            this.BtnTemizle.Location = new System.Drawing.Point(1302, 321);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(130, 51);
            this.BtnTemizle.TabIndex = 400;
            this.BtnTemizle.Text = "   TEMİZLE";
            this.BtnTemizle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTemizle.UseVisualStyleBackColor = false;
            this.BtnTemizle.Click += new System.EventHandler(this.BtnTemizle_Click);
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.Image")));
            this.BtnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnKaydet.Location = new System.Drawing.Point(894, 321);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(130, 51);
            this.BtnKaydet.TabIndex = 401;
            this.BtnKaydet.Text = "     KAYDET";
            this.BtnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKaydet.UseVisualStyleBackColor = false;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1440, 27);
            this.panel1.TabIndex = 402;
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
            // PnlKayit
            // 
            this.PnlKayit.Controls.Add(this.TxtButceKodu);
            this.PnlKayit.Controls.Add(this.label1);
            this.PnlKayit.Controls.Add(this.label2);
            this.PnlKayit.Controls.Add(this.TxtTanimi);
            this.PnlKayit.Controls.Add(this.label3);
            this.PnlKayit.Controls.Add(this.TxtAciklama);
            this.PnlKayit.Controls.Add(this.BtnGiderFirma);
            this.PnlKayit.Controls.Add(this.label4);
            this.PnlKayit.Controls.Add(this.CmbFirma);
            this.PnlKayit.Location = new System.Drawing.Point(894, 45);
            this.PnlKayit.Name = "PnlKayit";
            this.PnlKayit.Size = new System.Drawing.Size(534, 270);
            this.PnlKayit.TabIndex = 403;
            // 
            // BtnTumunuSec
            // 
            this.BtnTumunuSec.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnTumunuSec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTumunuSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTumunuSec.Location = new System.Drawing.Point(761, 672);
            this.BtnTumunuSec.Name = "BtnTumunuSec";
            this.BtnTumunuSec.Size = new System.Drawing.Size(116, 31);
            this.BtnTumunuSec.TabIndex = 404;
            this.BtnTumunuSec.Text = "Tümünü Seç";
            this.BtnTumunuSec.UseVisualStyleBackColor = false;
            this.BtnTumunuSec.Click += new System.EventHandler(this.BtnTumunuSec_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 26);
            // 
            // FrmButceKoduKalemiDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 739);
            this.Controls.Add(this.BtnTumunuSec);
            this.Controls.Add(this.PnlKayit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.BtnTemizle);
            this.Controls.Add(this.BtnSil);
            this.Controls.Add(this.BtnGuncelle);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.DtgList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmButceKoduKalemiDuzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BÜTÇE KODU/KALEMİ";
            this.Load += new System.EventHandler(this.FrmButceKoduKalemi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.PnlKayit.ResumeLayout(false);
            this.PnlKayit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtButceKodu;
        private System.Windows.Forms.TextBox TxtTanimi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox TxtAciklama;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbFirma;
        private System.Windows.Forms.Button BtnGiderFirma;
        private System.Windows.Forms.Button BtnGuncelle;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource dataBinder;
        public System.Windows.Forms.Panel PnlKayit;
        public System.Windows.Forms.Button BtnCancel;
        public System.Windows.Forms.Button BtnSil;
        public System.Windows.Forms.Button BtnTemizle;
        public System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Button BtnTumunuSec;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}