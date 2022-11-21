
namespace UserInterface.BakımOnarım
{
    partial class FrmGarantiSureleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGarantiSureleri));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbGarantiPaketi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DtBaslamaTarihi = new System.Windows.Forms.DateTimePicker();
            this.DtBitisTarihi = new System.Windows.Forms.DateTimePicker();
            this.BtnListeyeEkle = new System.Windows.Forms.Button();
            this.BtnGarantiPaketi = new System.Windows.Forms.Button();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.DtgList = new System.Windows.Forms.DataGridView();
            this.GarantiPaketi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BasTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BitTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopSure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Garanti Paketi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Garanti Başlama Tarihi:";
            // 
            // CmbGarantiPaketi
            // 
            this.CmbGarantiPaketi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbGarantiPaketi.FormattingEnabled = true;
            this.CmbGarantiPaketi.Location = new System.Drawing.Point(159, 25);
            this.CmbGarantiPaketi.Name = "CmbGarantiPaketi";
            this.CmbGarantiPaketi.Size = new System.Drawing.Size(121, 23);
            this.CmbGarantiPaketi.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Garanti Bitiş Tarihi:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(105, 26);
            // 
            // kToolStripMenuItem
            // 
            this.kToolStripMenuItem.Name = "kToolStripMenuItem";
            this.kToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.kToolStripMenuItem.Text = "Kaldır";
            this.kToolStripMenuItem.Click += new System.EventHandler(this.kToolStripMenuItem_Click);
            // 
            // DtBaslamaTarihi
            // 
            this.DtBaslamaTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtBaslamaTarihi.Location = new System.Drawing.Point(159, 63);
            this.DtBaslamaTarihi.Name = "DtBaslamaTarihi";
            this.DtBaslamaTarihi.Size = new System.Drawing.Size(121, 21);
            this.DtBaslamaTarihi.TabIndex = 5;
            // 
            // DtBitisTarihi
            // 
            this.DtBitisTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtBitisTarihi.Location = new System.Drawing.Point(405, 63);
            this.DtBitisTarihi.Name = "DtBitisTarihi";
            this.DtBitisTarihi.Size = new System.Drawing.Size(121, 21);
            this.DtBitisTarihi.TabIndex = 6;
            // 
            // BtnListeyeEkle
            // 
            this.BtnListeyeEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnListeyeEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnListeyeEkle.Location = new System.Drawing.Point(532, 62);
            this.BtnListeyeEkle.Name = "BtnListeyeEkle";
            this.BtnListeyeEkle.Size = new System.Drawing.Size(110, 23);
            this.BtnListeyeEkle.TabIndex = 7;
            this.BtnListeyeEkle.Text = "Listeye Ekle";
            this.BtnListeyeEkle.UseVisualStyleBackColor = true;
            this.BtnListeyeEkle.Click += new System.EventHandler(this.BtnListeyeEkle_Click);
            // 
            // BtnGarantiPaketi
            // 
            this.BtnGarantiPaketi.AccessibleDescription = "";
            this.BtnGarantiPaketi.BackColor = System.Drawing.SystemColors.Control;
            this.BtnGarantiPaketi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnGarantiPaketi.BackgroundImage")));
            this.BtnGarantiPaketi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnGarantiPaketi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGarantiPaketi.Location = new System.Drawing.Point(283, 21);
            this.BtnGarantiPaketi.Margin = new System.Windows.Forms.Padding(0);
            this.BtnGarantiPaketi.Name = "BtnGarantiPaketi";
            this.BtnGarantiPaketi.Size = new System.Drawing.Size(34, 29);
            this.BtnGarantiPaketi.TabIndex = 150;
            this.BtnGarantiPaketi.Tag = "admin";
            this.BtnGarantiPaketi.UseVisualStyleBackColor = false;
            this.BtnGarantiPaketi.Click += new System.EventHandler(this.BtnGarantiPaketi_Click);
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.Image")));
            this.BtnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnKaydet.Location = new System.Drawing.Point(12, 342);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(130, 51);
            this.BtnKaydet.TabIndex = 318;
            this.BtnKaydet.Text = "     KAYDET";
            this.BtnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKaydet.UseVisualStyleBackColor = false;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GarantiPaketi,
            this.BasTarihi,
            this.BitTarihi,
            this.TopSure,
            this.Remove});
            this.DtgList.Location = new System.Drawing.Point(12, 100);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.Size = new System.Drawing.Size(645, 233);
            this.DtgList.TabIndex = 319;
            this.DtgList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgList_CellContentClick);
            // 
            // GarantiPaketi
            // 
            this.GarantiPaketi.HeaderText = "GARANTİ PAKETİ";
            this.GarantiPaketi.Name = "GarantiPaketi";
            this.GarantiPaketi.ReadOnly = true;
            this.GarantiPaketi.Width = 116;
            // 
            // BasTarihi
            // 
            this.BasTarihi.HeaderText = "GARANTİ BAŞLAMA TARİHİ";
            this.BasTarihi.Name = "BasTarihi";
            this.BasTarihi.ReadOnly = true;
            this.BasTarihi.Width = 132;
            // 
            // BitTarihi
            // 
            this.BitTarihi.HeaderText = "GARANTİ BİTİŞ TARİHİ";
            this.BitTarihi.Name = "BitTarihi";
            this.BitTarihi.ReadOnly = true;
            this.BitTarihi.Width = 108;
            // 
            // TopSure
            // 
            this.TopSure.HeaderText = "TOPLAM SÜRE";
            this.TopSure.Name = "TopSure";
            this.TopSure.ReadOnly = true;
            this.TopSure.Width = 108;
            // 
            // Remove
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red;
            this.Remove.DefaultCellStyle = dataGridViewCellStyle2;
            this.Remove.HeaderText = "KALDIR";
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.Text = "X";
            this.Remove.ToolTipText = "X";
            this.Remove.UseColumnTextForButtonValue = true;
            this.Remove.Width = 56;
            // 
            // FrmGarantiSureleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 414);
            this.Controls.Add(this.DtgList);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.BtnGarantiPaketi);
            this.Controls.Add(this.BtnListeyeEkle);
            this.Controls.Add(this.DtBitisTarihi);
            this.Controls.Add(this.DtBaslamaTarihi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbGarantiPaketi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGarantiSureleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GARANTİ SÜRELERİ";
            this.Load += new System.EventHandler(this.FrmGarantiSureleri_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbGarantiPaketi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtBaslamaTarihi;
        private System.Windows.Forms.DateTimePicker DtBitisTarihi;
        private System.Windows.Forms.Button BtnListeyeEkle;
        private System.Windows.Forms.Button BtnGarantiPaketi;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kToolStripMenuItem;
        private System.Windows.Forms.DataGridView DtgList;
        private System.Windows.Forms.DataGridViewTextBoxColumn GarantiPaketi;
        private System.Windows.Forms.DataGridViewTextBoxColumn BasTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn BitTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopSure;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
    }
}