
namespace UserInterface.Depo
{
    partial class FrmStokGoruntule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStokGoruntule));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgDepoBilgileri = new ADGV.AdvancedDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezerveEtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgMalzemeBilgisi = new System.Windows.Forms.DataGridView();
            this.Photo = new System.Windows.Forms.DataGridViewImageColumn();
            this.TxtStokNo = new System.Windows.Forms.TextBox();
            this.LblToplamMiktar = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblBirimFiyat = new System.Windows.Forms.Label();
            this.BirimFiyat = new System.Windows.Forms.Label();
            this.TxtBarkod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSorgula = new System.Windows.Forms.Button();
            this.BtnTumunuGor = new System.Windows.Forms.Button();
            this.barkodOluşturToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepoBilgileri)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeBilgisi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1551, 27);
            this.panel1.TabIndex = 46;
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
            this.groupBox1.Controls.Add(this.DtgDepoBilgileri);
            this.groupBox1.Location = new System.Drawing.Point(16, 324);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1533, 517);
            this.groupBox1.TabIndex = 312;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DEPO BİLGİLERİ";
            // 
            // DtgDepoBilgileri
            // 
            this.DtgDepoBilgileri.AllowUserToAddRows = false;
            this.DtgDepoBilgileri.AllowUserToDeleteRows = false;
            this.DtgDepoBilgileri.AllowUserToOrderColumns = true;
            this.DtgDepoBilgileri.AutoGenerateContextFilters = true;
            this.DtgDepoBilgileri.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgDepoBilgileri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDepoBilgileri.ContextMenuStrip = this.contextMenuStrip1;
            this.DtgDepoBilgileri.DateWithTime = false;
            this.DtgDepoBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgDepoBilgileri.Location = new System.Drawing.Point(3, 16);
            this.DtgDepoBilgileri.Name = "DtgDepoBilgileri";
            this.DtgDepoBilgileri.ReadOnly = true;
            this.DtgDepoBilgileri.Size = new System.Drawing.Size(1527, 498);
            this.DtgDepoBilgileri.TabIndex = 0;
            this.DtgDepoBilgileri.TimeFilter = false;
            this.DtgDepoBilgileri.SortStringChanged += new System.EventHandler(this.DtgDepoBilgileri_SortStringChanged);
            this.DtgDepoBilgileri.FilterStringChanged += new System.EventHandler(this.DtgDepoBilgileri_FilterStringChanged);
            this.DtgDepoBilgileri.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgDepoBilgileri_CellMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.düzenleToolStripMenuItem,
            this.rezerveEtToolStripMenuItem,
            this.barkodOluşturToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 92);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // rezerveEtToolStripMenuItem
            // 
            this.rezerveEtToolStripMenuItem.Name = "rezerveEtToolStripMenuItem";
            this.rezerveEtToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rezerveEtToolStripMenuItem.Text = "Rezerve Et";
            this.rezerveEtToolStripMenuItem.Click += new System.EventHandler(this.rezerveEtToolStripMenuItem_Click);
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(144, 854);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(27, 20);
            this.TxtTop.TabIndex = 314;
            this.TxtTop.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(22, 854);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 313;
            this.label1.Text = "Toplam Kayıt:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(60, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 319;
            this.label4.Text = "Stok No:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgMalzemeBilgisi);
            this.groupBox2.Location = new System.Drawing.Point(16, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1363, 239);
            this.groupBox2.TabIndex = 318;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MALZEME BİLGİLERİ";
            // 
            // DtgMalzemeBilgisi
            // 
            this.DtgMalzemeBilgisi.AllowUserToAddRows = false;
            this.DtgMalzemeBilgisi.AllowUserToDeleteRows = false;
            this.DtgMalzemeBilgisi.AllowUserToOrderColumns = true;
            this.DtgMalzemeBilgisi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgMalzemeBilgisi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgMalzemeBilgisi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Photo});
            this.DtgMalzemeBilgisi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgMalzemeBilgisi.Location = new System.Drawing.Point(3, 16);
            this.DtgMalzemeBilgisi.Name = "DtgMalzemeBilgisi";
            this.DtgMalzemeBilgisi.ReadOnly = true;
            this.DtgMalzemeBilgisi.RowTemplate.Height = 200;
            this.DtgMalzemeBilgisi.Size = new System.Drawing.Size(1357, 220);
            this.DtgMalzemeBilgisi.TabIndex = 321;
            this.DtgMalzemeBilgisi.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgMalzemeBilgisi_CellMouseClick);
            // 
            // Photo
            // 
            this.Photo.HeaderText = "FOTO";
            this.Photo.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Photo.Name = "Photo";
            this.Photo.ReadOnly = true;
            // 
            // TxtStokNo
            // 
            this.TxtStokNo.Location = new System.Drawing.Point(124, 47);
            this.TxtStokNo.Name = "TxtStokNo";
            this.TxtStokNo.Size = new System.Drawing.Size(182, 20);
            this.TxtStokNo.TabIndex = 320;
            // 
            // LblToplamMiktar
            // 
            this.LblToplamMiktar.AutoSize = true;
            this.LblToplamMiktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblToplamMiktar.Location = new System.Drawing.Point(402, 854);
            this.LblToplamMiktar.Name = "LblToplamMiktar";
            this.LblToplamMiktar.Size = new System.Drawing.Size(27, 20);
            this.LblToplamMiktar.TabIndex = 322;
            this.LblToplamMiktar.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(270, 854);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 321;
            this.label3.Text = "Toplam Miktar:";
            // 
            // LblBirimFiyat
            // 
            this.LblBirimFiyat.AutoSize = true;
            this.LblBirimFiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblBirimFiyat.Location = new System.Drawing.Point(1385, 300);
            this.LblBirimFiyat.Name = "LblBirimFiyat";
            this.LblBirimFiyat.Size = new System.Drawing.Size(125, 15);
            this.LblBirimFiyat.TabIndex = 323;
            this.LblBirimFiyat.Text = "Malzeme Birim Fiyatı:";
            // 
            // BirimFiyat
            // 
            this.BirimFiyat.AutoSize = true;
            this.BirimFiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BirimFiyat.Location = new System.Drawing.Point(1516, 300);
            this.BirimFiyat.Name = "BirimFiyat";
            this.BirimFiyat.Size = new System.Drawing.Size(24, 15);
            this.BirimFiyat.TabIndex = 324;
            this.BirimFiyat.Text = "₺ 0";
            // 
            // TxtBarkod
            // 
            this.TxtBarkod.Location = new System.Drawing.Point(642, 48);
            this.TxtBarkod.Name = "TxtBarkod";
            this.TxtBarkod.Size = new System.Drawing.Size(303, 20);
            this.TxtBarkod.TabIndex = 326;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(580, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 325;
            this.label2.Text = "Barkod:";
            // 
            // BtnSorgula
            // 
            this.BtnSorgula.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnSorgula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSorgula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSorgula.Image = ((System.Drawing.Image)(resources.GetObject("BtnSorgula.Image")));
            this.BtnSorgula.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSorgula.Location = new System.Drawing.Point(312, 33);
            this.BtnSorgula.Name = "BtnSorgula";
            this.BtnSorgula.Size = new System.Drawing.Size(127, 51);
            this.BtnSorgula.TabIndex = 341;
            this.BtnSorgula.Text = "   SORGULA";
            this.BtnSorgula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSorgula.UseVisualStyleBackColor = false;
            this.BtnSorgula.Click += new System.EventHandler(this.BtnSorgula_Click);
            // 
            // BtnTumunuGor
            // 
            this.BtnTumunuGor.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnTumunuGor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTumunuGor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTumunuGor.Image = ((System.Drawing.Image)(resources.GetObject("BtnTumunuGor.Image")));
            this.BtnTumunuGor.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnTumunuGor.Location = new System.Drawing.Point(445, 33);
            this.BtnTumunuGor.Name = "BtnTumunuGor";
            this.BtnTumunuGor.Size = new System.Drawing.Size(127, 51);
            this.BtnTumunuGor.TabIndex = 342;
            this.BtnTumunuGor.Text = "   TÜMÜNÜ \r\n       GÖR";
            this.BtnTumunuGor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTumunuGor.UseVisualStyleBackColor = false;
            this.BtnTumunuGor.Click += new System.EventHandler(this.BtnTumunuGor_Click);
            // 
            // barkodOluşturToolStripMenuItem
            // 
            this.barkodOluşturToolStripMenuItem.Name = "barkodOluşturToolStripMenuItem";
            this.barkodOluşturToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.barkodOluşturToolStripMenuItem.Text = "Barkod Oluştur";
            this.barkodOluşturToolStripMenuItem.Click += new System.EventHandler(this.barkodOluşturToolStripMenuItem_Click);
            // 
            // FrmStokGoruntule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 888);
            this.Controls.Add(this.BtnTumunuGor);
            this.Controls.Add(this.BtnSorgula);
            this.Controls.Add(this.TxtBarkod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BirimFiyat);
            this.Controls.Add(this.LblBirimFiyat);
            this.Controls.Add(this.LblToplamMiktar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtStokNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmStokGoruntule";
            this.Text = "FrmStokGoruntule";
            this.Load += new System.EventHandler(this.FrmStokGoruntule_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepoBilgileri)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeBilgisi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgDepoBilgileri;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtStokNo;
        private System.Windows.Forms.DataGridView DtgMalzemeBilgisi;
        private System.Windows.Forms.Label LblToplamMiktar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblBirimFiyat;
        private System.Windows.Forms.Label BirimFiyat;
        private System.Windows.Forms.TextBox TxtBarkod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewImageColumn Photo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.Button BtnSorgula;
        private System.Windows.Forms.Button BtnTumunuGor;
        private System.Windows.Forms.ToolStripMenuItem rezerveEtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barkodOluşturToolStripMenuItem;
    }
}