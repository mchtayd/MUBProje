namespace UserInterface.Gecic_Kabul_Ambar
{
    partial class FrmSayimIzleme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSayimIzleme));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.CmbDepoNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbSayimYili = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblToplamMiktar = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgDepoBilgileri = new ADGV.AdvancedDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.depoHareketleriniGörToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.malzemeBilgisiDüzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barkodOluşturToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnSorgula = new System.Windows.Forms.Button();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.LblDepoAdi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.miktarDeğiştirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepoBilgileri)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1557, 27);
            this.panel1.TabIndex = 317;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.BtnCancel.Location = new System.Drawing.Point(12, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(35, 23);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // CmbDepoNo
            // 
            this.CmbDepoNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDepoNo.FormattingEnabled = true;
            this.CmbDepoNo.Location = new System.Drawing.Point(90, 44);
            this.CmbDepoNo.Name = "CmbDepoNo";
            this.CmbDepoNo.Size = new System.Drawing.Size(121, 21);
            this.CmbDepoNo.TabIndex = 345;
            this.CmbDepoNo.SelectedIndexChanged += new System.EventHandler(this.CmbDepoNo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(17, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 344;
            this.label2.Text = "Depo No:";
            // 
            // CmbSayimYili
            // 
            this.CmbSayimYili.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSayimYili.FormattingEnabled = true;
            this.CmbSayimYili.Location = new System.Drawing.Point(308, 44);
            this.CmbSayimYili.Name = "CmbSayimYili";
            this.CmbSayimYili.Size = new System.Drawing.Size(121, 21);
            this.CmbSayimYili.TabIndex = 347;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(228, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 346;
            this.label1.Text = "Sayım Yılı:";
            // 
            // LblToplamMiktar
            // 
            this.LblToplamMiktar.AutoSize = true;
            this.LblToplamMiktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblToplamMiktar.Location = new System.Drawing.Point(396, 699);
            this.LblToplamMiktar.Name = "LblToplamMiktar";
            this.LblToplamMiktar.Size = new System.Drawing.Size(27, 20);
            this.LblToplamMiktar.TabIndex = 352;
            this.LblToplamMiktar.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(264, 699);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 351;
            this.label3.Text = "Toplam Miktar:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(138, 699);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(27, 20);
            this.TxtTop.TabIndex = 350;
            this.TxtTop.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(16, 699);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 349;
            this.label4.Text = "Toplam Kayıt:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgDepoBilgileri);
            this.groupBox1.Location = new System.Drawing.Point(12, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1533, 583);
            this.groupBox1.TabIndex = 348;
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
            this.DtgDepoBilgileri.Size = new System.Drawing.Size(1527, 564);
            this.DtgDepoBilgileri.TabIndex = 0;
            this.DtgDepoBilgileri.TimeFilter = false;
            this.DtgDepoBilgileri.SortStringChanged += new System.EventHandler(this.DtgDepoBilgileri_SortStringChanged);
            this.DtgDepoBilgileri.FilterStringChanged += new System.EventHandler(this.DtgDepoBilgileri_FilterStringChanged);
            this.DtgDepoBilgileri.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgDepoBilgileri_CellMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.depoHareketleriniGörToolStripMenuItem,
            this.malzemeBilgisiDüzenleToolStripMenuItem,
            this.barkodOluşturToolStripMenuItem,
            this.miktarDeğiştirToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(212, 114);
            // 
            // depoHareketleriniGörToolStripMenuItem
            // 
            this.depoHareketleriniGörToolStripMenuItem.Name = "depoHareketleriniGörToolStripMenuItem";
            this.depoHareketleriniGörToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.depoHareketleriniGörToolStripMenuItem.Text = "Depo Hareketlerini Gör";
            // 
            // malzemeBilgisiDüzenleToolStripMenuItem
            // 
            this.malzemeBilgisiDüzenleToolStripMenuItem.Name = "malzemeBilgisiDüzenleToolStripMenuItem";
            this.malzemeBilgisiDüzenleToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.malzemeBilgisiDüzenleToolStripMenuItem.Text = "Malzeme Bilgisini Düzenle";
            this.malzemeBilgisiDüzenleToolStripMenuItem.Click += new System.EventHandler(this.malzemeBilgisiDüzenleToolStripMenuItem_Click);
            // 
            // barkodOluşturToolStripMenuItem
            // 
            this.barkodOluşturToolStripMenuItem.Name = "barkodOluşturToolStripMenuItem";
            this.barkodOluşturToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.barkodOluşturToolStripMenuItem.Text = "Barkod Oluştur";
            this.barkodOluşturToolStripMenuItem.Click += new System.EventHandler(this.barkodOluşturToolStripMenuItem_Click);
            // 
            // BtnSorgula
            // 
            this.BtnSorgula.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnSorgula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSorgula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSorgula.Image = ((System.Drawing.Image)(resources.GetObject("BtnSorgula.Image")));
            this.BtnSorgula.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSorgula.Location = new System.Drawing.Point(446, 33);
            this.BtnSorgula.Name = "BtnSorgula";
            this.BtnSorgula.Size = new System.Drawing.Size(127, 44);
            this.BtnSorgula.TabIndex = 353;
            this.BtnSorgula.Text = "   SORGULA";
            this.BtnSorgula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSorgula.UseVisualStyleBackColor = false;
            this.BtnSorgula.Click += new System.EventHandler(this.BtnSorgula_Click);
            // 
            // LblDepoAdi
            // 
            this.LblDepoAdi.AutoSize = true;
            this.LblDepoAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblDepoAdi.Location = new System.Drawing.Point(87, 77);
            this.LblDepoAdi.Name = "LblDepoAdi";
            this.LblDepoAdi.Size = new System.Drawing.Size(23, 15);
            this.LblDepoAdi.TabIndex = 354;
            this.LblDepoAdi.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(15, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 355;
            this.label5.Text = "Depo Adı:";
            // 
            // miktarDeğiştirToolStripMenuItem
            // 
            this.miktarDeğiştirToolStripMenuItem.Name = "miktarDeğiştirToolStripMenuItem";
            this.miktarDeğiştirToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.miktarDeğiştirToolStripMenuItem.Text = "Düzenle";
            this.miktarDeğiştirToolStripMenuItem.Click += new System.EventHandler(this.miktarDeğiştirToolStripMenuItem_Click);
            // 
            // FrmSayimIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 732);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblDepoAdi);
            this.Controls.Add(this.BtnSorgula);
            this.Controls.Add(this.LblToplamMiktar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CmbSayimYili);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbDepoNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSayimIzleme";
            this.Text = "FrmSayimIzleme";
            this.Load += new System.EventHandler(this.FrmSayimIzleme_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepoBilgileri)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.ComboBox CmbDepoNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbSayimYili;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblToplamMiktar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgDepoBilgileri;
        private System.Windows.Forms.Button BtnSorgula;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.Label LblDepoAdi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem depoHareketleriniGörToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem malzemeBilgisiDüzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barkodOluşturToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miktarDeğiştirToolStripMenuItem;
    }
}