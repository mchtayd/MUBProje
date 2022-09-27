
namespace UserInterface.Gecic_Kabul_Ambar
{
    partial class FrmDepoDusum
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnBarkodOlustur = new System.Windows.Forms.Button();
            this.PctBarcode = new System.Windows.Forms.PictureBox();
            this.TxtSeriNo = new System.Windows.Forms.TextBox();
            this.LblTakipDurumu = new System.Windows.Forms.Label();
            this.CmbStokNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.BtnListeyeEkle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgYedekParca = new ADGV.AdvancedDataGridView();
            this.Photo = new System.Windows.Forms.DataGridViewImageColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbTanim = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtRevizyon = new System.Windows.Forms.TextBox();
            this.BtnLotAl = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctBarcode)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgYedekParca)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 27);
            this.panel1.TabIndex = 314;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.BtnCancel.Location = new System.Drawing.Point(719, 2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(35, 23);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnBarkodOlustur
            // 
            this.BtnBarkodOlustur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBarkodOlustur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBarkodOlustur.Location = new System.Drawing.Point(65, 381);
            this.BtnBarkodOlustur.Name = "BtnBarkodOlustur";
            this.BtnBarkodOlustur.Size = new System.Drawing.Size(126, 35);
            this.BtnBarkodOlustur.TabIndex = 2;
            this.BtnBarkodOlustur.Text = "Barkod Oluştur";
            this.BtnBarkodOlustur.UseVisualStyleBackColor = true;
            this.BtnBarkodOlustur.Click += new System.EventHandler(this.BtnBarkodOlustur_Click);
            // 
            // PctBarcode
            // 
            this.PctBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PctBarcode.Location = new System.Drawing.Point(65, 36);
            this.PctBarcode.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.PctBarcode.Name = "PctBarcode";
            this.PctBarcode.Size = new System.Drawing.Size(250, 204);
            this.PctBarcode.TabIndex = 317;
            this.PctBarcode.TabStop = false;
            // 
            // TxtSeriNo
            // 
            this.TxtSeriNo.Location = new System.Drawing.Point(65, 320);
            this.TxtSeriNo.Name = "TxtSeriNo";
            this.TxtSeriNo.Size = new System.Drawing.Size(250, 20);
            this.TxtSeriNo.TabIndex = 0;
            this.TxtSeriNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtSeriNo_KeyUp);
            // 
            // LblTakipDurumu
            // 
            this.LblTakipDurumu.AutoSize = true;
            this.LblTakipDurumu.Location = new System.Drawing.Point(16, 323);
            this.LblTakipDurumu.Name = "LblTakipDurumu";
            this.LblTakipDurumu.Size = new System.Drawing.Size(45, 13);
            this.LblTakipDurumu.TabIndex = 320;
            this.LblTakipDurumu.Text = "Seri No:";
            // 
            // CmbStokNo
            // 
            this.CmbStokNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CmbStokNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbStokNo.FormattingEnabled = true;
            this.CmbStokNo.Location = new System.Drawing.Point(65, 266);
            this.CmbStokNo.Name = "CmbStokNo";
            this.CmbStokNo.Size = new System.Drawing.Size(250, 21);
            this.CmbStokNo.TabIndex = 321;
            this.CmbStokNo.SelectedIndexChanged += new System.EventHandler(this.CmbStokNo_SelectedIndexChanged);
            this.CmbStokNo.TextChanged += new System.EventHandler(this.CmbStokNo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 322;
            this.label1.Text = "Stok No:";
            // 
            // BtnPrint
            // 
            this.BtnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnPrint.Location = new System.Drawing.Point(394, 562);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(126, 35);
            this.BtnPrint.TabIndex = 323;
            this.BtnPrint.Text = "Çıktı Al";
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // BtnListeyeEkle
            // 
            this.BtnListeyeEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnListeyeEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnListeyeEkle.Location = new System.Drawing.Point(65, 422);
            this.BtnListeyeEkle.Name = "BtnListeyeEkle";
            this.BtnListeyeEkle.Size = new System.Drawing.Size(126, 35);
            this.BtnListeyeEkle.TabIndex = 325;
            this.BtnListeyeEkle.Text = "Listeye Ekle";
            this.BtnListeyeEkle.UseVisualStyleBackColor = true;
            this.BtnListeyeEkle.Click += new System.EventHandler(this.BtnListeyeEkle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgYedekParca);
            this.groupBox1.Location = new System.Drawing.Point(391, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 520);
            this.groupBox1.TabIndex = 326;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Barkod Listesi";
            // 
            // DtgYedekParca
            // 
            this.DtgYedekParca.AllowUserToAddRows = false;
            this.DtgYedekParca.AllowUserToDeleteRows = false;
            this.DtgYedekParca.AllowUserToResizeColumns = false;
            this.DtgYedekParca.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.DtgYedekParca.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DtgYedekParca.AutoGenerateContextFilters = true;
            this.DtgYedekParca.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgYedekParca.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DtgYedekParca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgYedekParca.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Photo});
            this.DtgYedekParca.DateWithTime = false;
            this.DtgYedekParca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgYedekParca.Location = new System.Drawing.Point(3, 16);
            this.DtgYedekParca.MultiSelect = false;
            this.DtgYedekParca.Name = "DtgYedekParca";
            this.DtgYedekParca.ReadOnly = true;
            this.DtgYedekParca.RowHeadersVisible = false;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DtgYedekParca.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DtgYedekParca.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DtgYedekParca.RowTemplate.Height = 220;
            this.DtgYedekParca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgYedekParca.Size = new System.Drawing.Size(359, 501);
            this.DtgYedekParca.TabIndex = 329;
            this.DtgYedekParca.TimeFilter = false;
            this.DtgYedekParca.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgYedekParca_CellMouseClick);
            // 
            // Photo
            // 
            this.Photo.HeaderText = "Barkod";
            this.Photo.MinimumWidth = 22;
            this.Photo.Name = "Photo";
            this.Photo.ReadOnly = true;
            this.Photo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 327;
            this.label3.Text = "Tanım:";
            // 
            // CmbTanim
            // 
            this.CmbTanim.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CmbTanim.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbTanim.FormattingEnabled = true;
            this.CmbTanim.Location = new System.Drawing.Point(65, 293);
            this.CmbTanim.Name = "CmbTanim";
            this.CmbTanim.Size = new System.Drawing.Size(320, 21);
            this.CmbTanim.TabIndex = 328;
            this.CmbTanim.SelectedIndexChanged += new System.EventHandler(this.CmbTanim_SelectedIndexChanged);
            this.CmbTanim.TextChanged += new System.EventHandler(this.CmbTanim_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 330;
            this.label4.Text = "Revizyon:";
            // 
            // TxtRevizyon
            // 
            this.TxtRevizyon.Location = new System.Drawing.Point(65, 346);
            this.TxtRevizyon.Name = "TxtRevizyon";
            this.TxtRevizyon.Size = new System.Drawing.Size(250, 20);
            this.TxtRevizyon.TabIndex = 329;
            // 
            // BtnLotAl
            // 
            this.BtnLotAl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLotAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnLotAl.Location = new System.Drawing.Point(321, 320);
            this.BtnLotAl.Name = "BtnLotAl";
            this.BtnLotAl.Size = new System.Drawing.Size(64, 20);
            this.BtnLotAl.TabIndex = 331;
            this.BtnLotAl.Text = "Lot Al";
            this.BtnLotAl.UseVisualStyleBackColor = true;
            this.BtnLotAl.Visible = false;
            this.BtnLotAl.Click += new System.EventHandler(this.BtnLotAl_Click);
            // 
            // FrmDepoDusum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 605);
            this.ControlBox = false;
            this.Controls.Add(this.BtnLotAl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtRevizyon);
            this.Controls.Add(this.CmbTanim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnListeyeEkle);
            this.Controls.Add(this.BtnPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbStokNo);
            this.Controls.Add(this.LblTakipDurumu);
            this.Controls.Add(this.TxtSeriNo);
            this.Controls.Add(this.PctBarcode);
            this.Controls.Add(this.BtnBarkodOlustur);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmDepoDusum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barkod Oluştur";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmDepoDusum_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PctBarcode)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgYedekParca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnBarkodOlustur;
        private System.Windows.Forms.PictureBox PctBarcode;
        private System.Windows.Forms.TextBox TxtSeriNo;
        private System.Windows.Forms.Label LblTakipDurumu;
        private System.Windows.Forms.ComboBox CmbStokNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Button BtnListeyeEkle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbTanim;
        private ADGV.AdvancedDataGridView DtgYedekParca;
        private System.Windows.Forms.DataGridViewImageColumn Photo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtRevizyon;
        private System.Windows.Forms.Button BtnLotAl;
    }
}