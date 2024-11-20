namespace UserInterface.IdariIsler
{
    partial class FrmZiyaretArac
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
            this.BtnBul = new System.Windows.Forms.Button();
            this.TxtIsAkisNo = new System.Windows.Forms.TextBox();
            this.CmbIslemTuruUcak = new System.Windows.Forms.ComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.LblIsAkisNo = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnBul
            // 
            this.BtnBul.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBul.Location = new System.Drawing.Point(232, 21);
            this.BtnBul.Name = "BtnBul";
            this.BtnBul.Size = new System.Drawing.Size(75, 23);
            this.BtnBul.TabIndex = 341;
            this.BtnBul.Text = "BUL";
            this.BtnBul.UseVisualStyleBackColor = true;
            this.BtnBul.Visible = false;
            // 
            // TxtIsAkisNo
            // 
            this.TxtIsAkisNo.Location = new System.Drawing.Point(100, 22);
            this.TxtIsAkisNo.Name = "TxtIsAkisNo";
            this.TxtIsAkisNo.Size = new System.Drawing.Size(126, 20);
            this.TxtIsAkisNo.TabIndex = 336;
            this.TxtIsAkisNo.Visible = false;
            // 
            // CmbIslemTuruUcak
            // 
            this.CmbIslemTuruUcak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIslemTuruUcak.FormattingEnabled = true;
            this.CmbIslemTuruUcak.Items.AddRange(new object[] {
            "YENİ KAYIT",
            "MEVCUT KAYIT GÜNCELLEME"});
            this.CmbIslemTuruUcak.Location = new System.Drawing.Point(445, 22);
            this.CmbIslemTuruUcak.Name = "CmbIslemTuruUcak";
            this.CmbIslemTuruUcak.Size = new System.Drawing.Size(258, 21);
            this.CmbIslemTuruUcak.TabIndex = 340;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(358, 26);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(76, 13);
            this.label54.TabIndex = 339;
            this.label54.Text = "İŞLEM TÜRÜ:";
            // 
            // LblIsAkisNo
            // 
            this.LblIsAkisNo.AutoSize = true;
            this.LblIsAkisNo.Location = new System.Drawing.Point(99, 25);
            this.LblIsAkisNo.Name = "LblIsAkisNo";
            this.LblIsAkisNo.Size = new System.Drawing.Size(19, 13);
            this.LblIsAkisNo.TabIndex = 338;
            this.LblIsAkisNo.Text = "00";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(28, 25);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(66, 13);
            this.label61.TabIndex = 337;
            this.label61.Text = "İŞ AKIŞ NO:";
            // 
            // FrmZiyaretArac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 765);
            this.Controls.Add(this.BtnBul);
            this.Controls.Add(this.TxtIsAkisNo);
            this.Controls.Add(this.CmbIslemTuruUcak);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.LblIsAkisNo);
            this.Controls.Add(this.label61);
            this.Name = "FrmZiyaretArac";
            this.Text = "FrmZiyaretArac";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnBul;
        private System.Windows.Forms.TextBox TxtIsAkisNo;
        private System.Windows.Forms.ComboBox CmbIslemTuruUcak;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label LblIsAkisNo;
        private System.Windows.Forms.Label label61;
    }
}