
namespace UserInterface.Gecic_Kabul_Ambar
{
    partial class FrmMalzemeAciklama
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
            this.TxtAciklama = new System.Windows.Forms.RichTextBox();
            this.BtnTamam = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(25, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Açıklama:";
            // 
            // TxtAciklama
            // 
            this.TxtAciklama.Location = new System.Drawing.Point(91, 37);
            this.TxtAciklama.Name = "TxtAciklama";
            this.TxtAciklama.Size = new System.Drawing.Size(439, 99);
            this.TxtAciklama.TabIndex = 1;
            this.TxtAciklama.Text = "";
            // 
            // BtnTamam
            // 
            this.BtnTamam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTamam.Location = new System.Drawing.Point(91, 142);
            this.BtnTamam.Name = "BtnTamam";
            this.BtnTamam.Size = new System.Drawing.Size(88, 38);
            this.BtnTamam.TabIndex = 2;
            this.BtnTamam.Text = "TAMAM";
            this.BtnTamam.UseVisualStyleBackColor = true;
            this.BtnTamam.Click += new System.EventHandler(this.BtnTamam_Click);
            // 
            // FrmMalzemeAciklama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 192);
            this.Controls.Add(this.BtnTamam);
            this.Controls.Add(this.TxtAciklama);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMalzemeAciklama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Açıklama";
            this.Load += new System.EventHandler(this.FrmMalzemeAciklama_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox TxtAciklama;
        private System.Windows.Forms.Button BtnTamam;
    }
}