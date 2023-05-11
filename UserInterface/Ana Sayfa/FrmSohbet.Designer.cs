namespace UserInterface.Ana_Sayfa
{
    partial class FrmSohbet
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
            this.TxtMesaj = new System.Windows.Forms.TextBox();
            this.BtnSohbetTemizle = new System.Windows.Forms.Button();
            this.BtnGonder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MesajBrowser = new System.Windows.Forms.WebBrowser();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtMesaj
            // 
            this.TxtMesaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtMesaj.Location = new System.Drawing.Point(11, 440);
            this.TxtMesaj.Name = "TxtMesaj";
            this.TxtMesaj.Size = new System.Drawing.Size(365, 22);
            this.TxtMesaj.TabIndex = 2;
            // 
            // BtnSohbetTemizle
            // 
            this.BtnSohbetTemizle.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnSohbetTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSohbetTemizle.Location = new System.Drawing.Point(263, 473);
            this.BtnSohbetTemizle.Name = "BtnSohbetTemizle";
            this.BtnSohbetTemizle.Size = new System.Drawing.Size(113, 28);
            this.BtnSohbetTemizle.TabIndex = 3;
            this.BtnSohbetTemizle.Text = "Sohbeti Temizle";
            this.BtnSohbetTemizle.UseVisualStyleBackColor = false;
            // 
            // BtnGonder
            // 
            this.BtnGonder.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnGonder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGonder.Location = new System.Drawing.Point(11, 473);
            this.BtnGonder.Name = "BtnGonder";
            this.BtnGonder.Size = new System.Drawing.Size(113, 28);
            this.BtnGonder.TabIndex = 5;
            this.BtnGonder.Text = "Gönder";
            this.BtnGonder.UseVisualStyleBackColor = false;
            this.BtnGonder.Click += new System.EventHandler(this.BtnGonder_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MesajBrowser);
            this.panel1.Location = new System.Drawing.Point(12, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 422);
            this.panel1.TabIndex = 6;
            // 
            // MesajBrowser
            // 
            this.MesajBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MesajBrowser.Location = new System.Drawing.Point(0, 0);
            this.MesajBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.MesajBrowser.Name = "MesajBrowser";
            this.MesajBrowser.Size = new System.Drawing.Size(364, 422);
            this.MesajBrowser.TabIndex = 0;
            this.MesajBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.MesajBrowser_DocumentCompleted);
            // 
            // FrmSohbet
            // 
            this.AcceptButton = this.BtnGonder;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 513);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnGonder);
            this.Controls.Add(this.BtnSohbetTemizle);
            this.Controls.Add(this.TxtMesaj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FrmSohbet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSohbet_FormClosing);
            this.Load += new System.EventHandler(this.FrmSohbet_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtMesaj;
        private System.Windows.Forms.Button BtnSohbetTemizle;
        private System.Windows.Forms.Button BtnGonder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser MesajBrowser;
    }
}