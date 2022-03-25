
namespace UserInterface.Ana_Sayfa
{
    partial class FrmCombo
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBaslik = new System.Windows.Forms.TextBox();
            this.BtnEkle = new System.Windows.Forms.Button();
            this.BtnGuncelle = new System.Windows.Forms.Button();
            this.BtnSil = new System.Windows.Forms.Button();
            this.BtnTumunuSil = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgIcerik = new System.Windows.Forms.DataGridView();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgIcerik)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "EKLEMEK İSTEDİĞİNİZ BİLGİ:";
            // 
            // TxtBaslik
            // 
            this.TxtBaslik.Location = new System.Drawing.Point(197, 45);
            this.TxtBaslik.Name = "TxtBaslik";
            this.TxtBaslik.Size = new System.Drawing.Size(231, 20);
            this.TxtBaslik.TabIndex = 1;
            // 
            // BtnEkle
            // 
            this.BtnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnEkle.Location = new System.Drawing.Point(318, 116);
            this.BtnEkle.Name = "BtnEkle";
            this.BtnEkle.Size = new System.Drawing.Size(110, 40);
            this.BtnEkle.TabIndex = 2;
            this.BtnEkle.Text = "EKLE";
            this.BtnEkle.UseVisualStyleBackColor = true;
            this.BtnEkle.Click += new System.EventHandler(this.BtnEkle_Click);
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Location = new System.Drawing.Point(318, 162);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(110, 40);
            this.BtnGuncelle.TabIndex = 5;
            this.BtnGuncelle.Text = "GÜNCELLE";
            this.BtnGuncelle.UseVisualStyleBackColor = true;
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // BtnSil
            // 
            this.BtnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSil.Location = new System.Drawing.Point(318, 208);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(110, 40);
            this.BtnSil.TabIndex = 6;
            this.BtnSil.Text = "SİL";
            this.BtnSil.UseVisualStyleBackColor = true;
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // BtnTumunuSil
            // 
            this.BtnTumunuSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTumunuSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTumunuSil.Location = new System.Drawing.Point(318, 254);
            this.BtnTumunuSil.Name = "BtnTumunuSil";
            this.BtnTumunuSil.Size = new System.Drawing.Size(110, 40);
            this.BtnTumunuSil.TabIndex = 7;
            this.BtnTumunuSil.Text = "TÜMÜNÜ SİL";
            this.BtnTumunuSil.UseVisualStyleBackColor = true;
            this.BtnTumunuSil.Click += new System.EventHandler(this.BtnTumunuSil_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgIcerik);
            this.groupBox1.Location = new System.Drawing.Point(40, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 263);
            this.groupBox1.TabIndex = 322;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "COMBO BOX İÇERİĞİ:";
            // 
            // DtgIcerik
            // 
            this.DtgIcerik.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgIcerik.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtgIcerik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgIcerik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgIcerik.Location = new System.Drawing.Point(3, 16);
            this.DtgIcerik.Name = "DtgIcerik";
            this.DtgIcerik.Size = new System.Drawing.Size(266, 244);
            this.DtgIcerik.TabIndex = 324;
            this.DtgIcerik.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgIcerik_CellMouseClick);
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(140, 359);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 324;
            this.TxtTop.Text = "00";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(40, 359);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 323;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // FrmCombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 388);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnTumunuSil);
            this.Controls.Add(this.BtnSil);
            this.Controls.Add(this.BtnGuncelle);
            this.Controls.Add(this.BtnEkle);
            this.Controls.Add(this.TxtBaslik);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCombo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COMBO BOX İÇERİK EKLEME";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCombo_FormClosing);
            this.Load += new System.EventHandler(this.FrmCombo_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgIcerik)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBaslik;
        private System.Windows.Forms.Button BtnEkle;
        private System.Windows.Forms.Button BtnGuncelle;
        private System.Windows.Forms.Button BtnSil;
        private System.Windows.Forms.Button BtnTumunuSil;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DtgIcerik;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label31;
    }
}