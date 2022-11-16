
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGarantiSureleri));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbGarantiPaketi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.BtnListeyeEkle = new System.Windows.Forms.Button();
            this.BtnGarantiPaketi = new System.Windows.Forms.Button();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView1.Location = new System.Drawing.Point(20, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(622, 242);
            this.dataGridView1.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(159, 63);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 21);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(405, 63);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(121, 21);
            this.dateTimePicker2.TabIndex = 6;
            // 
            // BtnListeyeEkle
            // 
            this.BtnListeyeEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnListeyeEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnListeyeEkle.Location = new System.Drawing.Point(532, 61);
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
            this.BtnKaydet.Location = new System.Drawing.Point(20, 351);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(130, 51);
            this.BtnKaydet.TabIndex = 318;
            this.BtnKaydet.Text = "     KAYDET";
            this.BtnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKaydet.UseVisualStyleBackColor = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "GARANTİ PAKETİ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "GARANTİ BAŞLAMA TARİHİ";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "GARANTİ BİTİŞ TARİHİ";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "TOPLAM GARANTİ SÜRESİ (YIL)";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // FrmGarantiSureleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 414);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.BtnGarantiPaketi);
            this.Controls.Add(this.BtnListeyeEkle);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbGarantiPaketi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button BtnListeyeEkle;
        private System.Windows.Forms.Button BtnGarantiPaketi;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}