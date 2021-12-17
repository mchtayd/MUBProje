
namespace UserInterface.Ana_Sayfa
{
    partial class FrmGorevAta
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
            this.CmbPersoneller = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblGorevinTanimi = new System.Windows.Forms.Label();
            this.LblIslemAdimi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtAciklama = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // CmbPersoneller
            // 
            this.CmbPersoneller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPersoneller.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbPersoneller.FormattingEnabled = true;
            this.CmbPersoneller.Location = new System.Drawing.Point(163, 19);
            this.CmbPersoneller.Name = "CmbPersoneller";
            this.CmbPersoneller.Size = new System.Drawing.Size(241, 23);
            this.CmbPersoneller.TabIndex = 428;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(8, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 15);
            this.label10.TabIndex = 427;
            this.label10.Text = "Görev Atanacak Personel:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(62, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 15);
            this.label7.TabIndex = 425;
            this.label7.Text = "Görevin Tanımı:";
            // 
            // LblGorevinTanimi
            // 
            this.LblGorevinTanimi.AutoSize = true;
            this.LblGorevinTanimi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblGorevinTanimi.Location = new System.Drawing.Point(160, 58);
            this.LblGorevinTanimi.Name = "LblGorevinTanimi";
            this.LblGorevinTanimi.Size = new System.Drawing.Size(21, 15);
            this.LblGorevinTanimi.TabIndex = 429;
            this.LblGorevinTanimi.Text = "00";
            // 
            // LblIslemAdimi
            // 
            this.LblIslemAdimi.AutoSize = true;
            this.LblIslemAdimi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblIslemAdimi.Location = new System.Drawing.Point(161, 87);
            this.LblIslemAdimi.Name = "LblIslemAdimi";
            this.LblIslemAdimi.Size = new System.Drawing.Size(21, 15);
            this.LblIslemAdimi.TabIndex = 431;
            this.LblIslemAdimi.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(81, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 430;
            this.label3.Text = "İşlem Adımı:";
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(163, 196);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(145, 50);
            this.BtnKaydet.TabIndex = 432;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(95, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 433;
            this.label4.Text = "Açıklama:";
            // 
            // TxtAciklama
            // 
            this.TxtAciklama.Location = new System.Drawing.Point(163, 118);
            this.TxtAciklama.Name = "TxtAciklama";
            this.TxtAciklama.Size = new System.Drawing.Size(472, 72);
            this.TxtAciklama.TabIndex = 434;
            this.TxtAciklama.Text = "";
            // 
            // FrmGorevAta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 263);
            this.Controls.Add(this.TxtAciklama);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.LblIslemAdimi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblGorevinTanimi);
            this.Controls.Add(this.CmbPersoneller);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGorevAta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GÖREV ATA";
            this.Load += new System.EventHandler(this.FrmGorevAta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbPersoneller;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblGorevinTanimi;
        private System.Windows.Forms.Label LblIslemAdimi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox TxtAciklama;
    }
}