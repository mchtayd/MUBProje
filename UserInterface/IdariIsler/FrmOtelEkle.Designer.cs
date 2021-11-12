
namespace UserInterface.IdariIsler
{
    partial class FrmOtelEkle
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
            this.CmbIl = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.TxtOtelinAdi = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CmbIl
            // 
            this.CmbIl.FormattingEnabled = true;
            this.CmbIl.Location = new System.Drawing.Point(194, 41);
            this.CmbIl.Name = "CmbIl";
            this.CmbIl.Size = new System.Drawing.Size(258, 21);
            this.CmbIl.TabIndex = 37;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(31, 45);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(157, 13);
            this.label21.TabIndex = 36;
            this.label21.Text = "OTELİN BULUNDUĞU ŞEHİR:";
            // 
            // TxtOtelinAdi
            // 
            this.TxtOtelinAdi.Location = new System.Drawing.Point(194, 79);
            this.TxtOtelinAdi.Name = "TxtOtelinAdi";
            this.TxtOtelinAdi.Size = new System.Drawing.Size(258, 20);
            this.TxtOtelinAdi.TabIndex = 39;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(118, 83);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 13);
            this.label20.TabIndex = 38;
            this.label20.Text = "OTELİN ADI:";
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(194, 116);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(91, 31);
            this.BtnKaydet.TabIndex = 40;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // FrmOtelEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 193);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.TxtOtelinAdi);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.CmbIl);
            this.Controls.Add(this.label21);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOtelEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Otel Ekle";
            this.Load += new System.EventHandler(this.FrmOtelEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbIl;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox TxtOtelinAdi;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button BtnKaydet;
    }
}