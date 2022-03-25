
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmButceKoduKalemiDuzenle));
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.BtnSil = new System.Windows.Forms.Button();
            this.BtnGuncelle = new System.Windows.Forms.Button();
            this.BtnEkle = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BtnGiderFirma = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgList.AutoGenerateContextFilters = true;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgList.DateWithTime = false;
            this.DtgList.Location = new System.Drawing.Point(12, 12);
            this.DtgList.MultiSelect = false;
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgList.Size = new System.Drawing.Size(462, 421);
            this.DtgList.TabIndex = 321;
            this.DtgList.TimeFilter = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(481, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 322;
            this.label1.Text = "Bütçe Kodu:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(553, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(85, 20);
            this.textBox1.TabIndex = 323;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(728, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(264, 20);
            this.textBox2.TabIndex = 325;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(652, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 324;
            this.label2.Text = "Bütçe Kalem:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(493, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 326;
            this.label3.Text = "Açıklama:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(553, 49);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(439, 119);
            this.richTextBox1.TabIndex = 327;
            this.richTextBox1.Text = "";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(12, 443);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 342;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(112, 443);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 343;
            this.TxtTop.Text = "00";
            // 
            // BtnSil
            // 
            this.BtnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSil.Location = new System.Drawing.Point(785, 251);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(110, 40);
            this.BtnSil.TabIndex = 346;
            this.BtnSil.Text = "SİL";
            this.BtnSil.UseVisualStyleBackColor = true;
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Location = new System.Drawing.Point(669, 251);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(110, 40);
            this.BtnGuncelle.TabIndex = 345;
            this.BtnGuncelle.Text = "GÜNCELLE";
            this.BtnGuncelle.UseVisualStyleBackColor = true;
            // 
            // BtnEkle
            // 
            this.BtnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnEkle.Location = new System.Drawing.Point(553, 251);
            this.BtnEkle.Name = "BtnEkle";
            this.BtnEkle.Size = new System.Drawing.Size(110, 40);
            this.BtnEkle.TabIndex = 344;
            this.BtnEkle.Text = "EKLE";
            this.BtnEkle.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(550, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 347;
            this.label4.Text = "Gider Karşılayacak Firma:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(553, 197);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(189, 21);
            this.comboBox1.TabIndex = 348;
            // 
            // BtnGiderFirma
            // 
            this.BtnGiderFirma.AccessibleDescription = "";
            this.BtnGiderFirma.BackColor = System.Drawing.SystemColors.Control;
            this.BtnGiderFirma.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnGiderFirma.BackgroundImage")));
            this.BtnGiderFirma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnGiderFirma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGiderFirma.Location = new System.Drawing.Point(745, 192);
            this.BtnGiderFirma.Margin = new System.Windows.Forms.Padding(0);
            this.BtnGiderFirma.Name = "BtnGiderFirma";
            this.BtnGiderFirma.Size = new System.Drawing.Size(34, 29);
            this.BtnGiderFirma.TabIndex = 397;
            this.BtnGiderFirma.Tag = "admin";
            this.BtnGiderFirma.UseVisualStyleBackColor = false;
            // 
            // FrmButceKoduKalemi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 473);
            this.Controls.Add(this.BtnGiderFirma);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnSil);
            this.Controls.Add(this.BtnGuncelle);
            this.Controls.Add(this.BtnEkle);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtgList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmButceKoduKalemi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BÜTÇE KODU/KALEMİ";
            this.Load += new System.EventHandler(this.FrmButceKoduKalemi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Button BtnSil;
        private System.Windows.Forms.Button BtnGuncelle;
        private System.Windows.Forms.Button BtnEkle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BtnGiderFirma;
    }
}