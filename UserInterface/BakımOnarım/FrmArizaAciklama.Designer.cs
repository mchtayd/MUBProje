namespace UserInterface.BakımOnarım
{
    partial class FrmArizaAciklama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmArizaAciklama));
            this.TxtAciklama = new System.Windows.Forms.RichTextBox();
            this.BtnEkle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtAciklama
            // 
            this.TxtAciklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtAciklama.Location = new System.Drawing.Point(12, 12);
            this.TxtAciklama.Name = "TxtAciklama";
            this.TxtAciklama.Size = new System.Drawing.Size(588, 145);
            this.TxtAciklama.TabIndex = 2;
            this.TxtAciklama.Text = "";
            // 
            // BtnEkle
            // 
            this.BtnEkle.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnEkle.Image = ((System.Drawing.Image)(resources.GetObject("BtnEkle.Image")));
            this.BtnEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEkle.Location = new System.Drawing.Point(12, 163);
            this.BtnEkle.Name = "BtnEkle";
            this.BtnEkle.Size = new System.Drawing.Size(86, 41);
            this.BtnEkle.TabIndex = 343;
            this.BtnEkle.Text = "  EKLE";
            this.BtnEkle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEkle.UseVisualStyleBackColor = false;
            this.BtnEkle.Click += new System.EventHandler(this.BtnEkle_Click);
            // 
            // FrmArizaAciklama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 217);
            this.Controls.Add(this.BtnEkle);
            this.Controls.Add(this.TxtAciklama);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmArizaAciklama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Açıklama/Not Ekle";
            this.Load += new System.EventHandler(this.FrmArizaAciklama_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox TxtAciklama;
        private System.Windows.Forms.Button BtnEkle;
    }
}