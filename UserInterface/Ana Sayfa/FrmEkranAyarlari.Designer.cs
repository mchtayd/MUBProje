namespace UserInterface.Ana_Sayfa
{
    partial class FrmEkranAyarlari
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEkranAyarlari));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmdMod = new System.Windows.Forms.ComboBox();
            this.LblCozunurluk = new System.Windows.Forms.Label();
            this.BtnOnayla = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(36, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mod Seçimi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(40, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Çözünürlük:";
            // 
            // CmdMod
            // 
            this.CmdMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmdMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmdMod.FormattingEnabled = true;
            this.CmdMod.Items.AddRange(new object[] {
            "Normal Mod",
            "Küçük Mod"});
            this.CmdMod.Location = new System.Drawing.Point(129, 23);
            this.CmdMod.Name = "CmdMod";
            this.CmdMod.Size = new System.Drawing.Size(153, 23);
            this.CmdMod.TabIndex = 2;
            this.CmdMod.SelectedIndexChanged += new System.EventHandler(this.CmdMod_SelectedIndexChanged);
            // 
            // LblCozunurluk
            // 
            this.LblCozunurluk.AutoSize = true;
            this.LblCozunurluk.Location = new System.Drawing.Point(126, 69);
            this.LblCozunurluk.Name = "LblCozunurluk";
            this.LblCozunurluk.Size = new System.Drawing.Size(19, 13);
            this.LblCozunurluk.TabIndex = 3;
            this.LblCozunurluk.Text = "00";
            // 
            // BtnOnayla
            // 
            this.BtnOnayla.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnOnayla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOnayla.Enabled = false;
            this.BtnOnayla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnOnayla.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOnayla.ImageKey = "ok.png";
            this.BtnOnayla.ImageList = this.ımageList1;
            this.BtnOnayla.Location = new System.Drawing.Point(100, 146);
            this.BtnOnayla.Name = "BtnOnayla";
            this.BtnOnayla.Size = new System.Drawing.Size(123, 51);
            this.BtnOnayla.TabIndex = 351;
            this.BtnOnayla.Text = "  UYGULA";
            this.BtnOnayla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOnayla.UseVisualStyleBackColor = false;
            this.BtnOnayla.Click += new System.EventHandler(this.BtnOnayla_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "okey.png");
            this.ımageList1.Images.SetKeyName(1, "ok.png");
            // 
            // FrmEkranAyarlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 236);
            this.Controls.Add(this.BtnOnayla);
            this.Controls.Add(this.LblCozunurluk);
            this.Controls.Add(this.CmdMod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEkranAyarlari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ekran Ayarları";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmdMod;
        private System.Windows.Forms.Label LblCozunurluk;
        private System.Windows.Forms.Button BtnOnayla;
        private System.Windows.Forms.ImageList ımageList1;
    }
}