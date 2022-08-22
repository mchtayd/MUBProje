
namespace UserInterface.Ana_Sayfa
{
    partial class FrmHesapOlustur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHesapOlustur));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.BtnSee = new System.Windows.Forms.Button();
            this.TxtSifre = new System.Windows.Forms.TextBox();
            this.PctBox = new System.Windows.Forms.PictureBox();
            this.CmbPersonel = new System.Windows.Forms.ComboBox();
            this.TxtSicilNo = new System.Windows.Forms.MaskedTextBox();
            this.ChcListBoxYetkiler = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbYetkiModu = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.BtnSifirla = new System.Windows.Forms.Button();
            this.BtnTumetki = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PctBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Personel Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(45, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sicil No:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(65, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Şifre:";
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(17, 659);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(95, 39);
            this.BtnKaydet.TabIndex = 6;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // BtnSee
            // 
            this.BtnSee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSee.Image = ((System.Drawing.Image)(resources.GetObject("BtnSee.Image")));
            this.BtnSee.Location = new System.Drawing.Point(382, 81);
            this.BtnSee.Name = "BtnSee";
            this.BtnSee.Size = new System.Drawing.Size(18, 20);
            this.BtnSee.TabIndex = 15;
            this.BtnSee.UseVisualStyleBackColor = true;
            this.BtnSee.Click += new System.EventHandler(this.BtnSee_Click);
            // 
            // TxtSifre
            // 
            this.TxtSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtSifre.Location = new System.Drawing.Point(112, 80);
            this.TxtSifre.Name = "TxtSifre";
            this.TxtSifre.Size = new System.Drawing.Size(264, 21);
            this.TxtSifre.TabIndex = 14;
            this.TxtSifre.UseSystemPasswordChar = true;
            // 
            // PctBox
            // 
            this.PctBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PctBox.Location = new System.Drawing.Point(422, 12);
            this.PctBox.Name = "PctBox";
            this.PctBox.Size = new System.Drawing.Size(157, 177);
            this.PctBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PctBox.TabIndex = 119;
            this.PctBox.TabStop = false;
            // 
            // CmbPersonel
            // 
            this.CmbPersonel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CmbPersonel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPersonel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPersonel.FormattingEnabled = true;
            this.CmbPersonel.Location = new System.Drawing.Point(112, 26);
            this.CmbPersonel.Name = "CmbPersonel";
            this.CmbPersonel.Size = new System.Drawing.Size(288, 21);
            this.CmbPersonel.TabIndex = 501;
            this.CmbPersonel.SelectedIndexChanged += new System.EventHandler(this.CmbPersonel_SelectedIndexChanged);
            // 
            // TxtSicilNo
            // 
            this.TxtSicilNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtSicilNo.Location = new System.Drawing.Point(112, 53);
            this.TxtSicilNo.Mask = "0000";
            this.TxtSicilNo.Name = "TxtSicilNo";
            this.TxtSicilNo.Size = new System.Drawing.Size(100, 21);
            this.TxtSicilNo.TabIndex = 503;
            this.TxtSicilNo.Tag = "";
            // 
            // ChcListBoxYetkiler
            // 
            this.ChcListBoxYetkiler.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChcListBoxYetkiler.FormattingEnabled = true;
            this.ChcListBoxYetkiler.Location = new System.Drawing.Point(17, 145);
            this.ChcListBoxYetkiler.Name = "ChcListBoxYetkiler";
            this.ChcListBoxYetkiler.Size = new System.Drawing.Size(383, 508);
            this.ChcListBoxYetkiler.TabIndex = 504;
            this.ChcListBoxYetkiler.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ChcListBoxYetkiler_ItemCheck);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(24, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 505;
            this.label3.Text = "Yetki Modu:";
            // 
            // CmbYetkiModu
            // 
            this.CmbYetkiModu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CmbYetkiModu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbYetkiModu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYetkiModu.FormattingEnabled = true;
            this.CmbYetkiModu.Items.AddRange(new object[] {
            "ADMİN",
            "YÖNETİCİ",
            "KULLANICI"});
            this.CmbYetkiModu.Location = new System.Drawing.Point(112, 107);
            this.CmbYetkiModu.Name = "CmbYetkiModu";
            this.CmbYetkiModu.Size = new System.Drawing.Size(133, 21);
            this.CmbYetkiModu.TabIndex = 506;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioButton1.Location = new System.Drawing.Point(416, 209);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(196, 20);
            this.radioButton1.TabIndex = 509;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "DTS Hesabını Pasifleştir";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioButton2.Location = new System.Drawing.Point(416, 235);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(191, 20);
            this.radioButton2.TabIndex = 510;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "DTS Hesabını Aktifleştir";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // BtnSifirla
            // 
            this.BtnSifirla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSifirla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSifirla.Location = new System.Drawing.Point(218, 659);
            this.BtnSifirla.Name = "BtnSifirla";
            this.BtnSifirla.Size = new System.Drawing.Size(95, 39);
            this.BtnSifirla.TabIndex = 511;
            this.BtnSifirla.Text = "SIFIRLA";
            this.BtnSifirla.UseVisualStyleBackColor = true;
            this.BtnSifirla.Click += new System.EventHandler(this.BtnSifirla_Click);
            // 
            // BtnTumetki
            // 
            this.BtnTumetki.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTumetki.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTumetki.Location = new System.Drawing.Point(117, 659);
            this.BtnTumetki.Name = "BtnTumetki";
            this.BtnTumetki.Size = new System.Drawing.Size(95, 39);
            this.BtnTumetki.TabIndex = 512;
            this.BtnTumetki.Text = "TÜM YETKİ";
            this.BtnTumetki.UseVisualStyleBackColor = true;
            this.BtnTumetki.Click += new System.EventHandler(this.BtnTumetki_Click);
            // 
            // FrmHesapOlustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 715);
            this.Controls.Add(this.BtnTumetki);
            this.Controls.Add(this.BtnSifirla);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.CmbYetkiModu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChcListBoxYetkiler);
            this.Controls.Add(this.TxtSicilNo);
            this.Controls.Add(this.CmbPersonel);
            this.Controls.Add(this.PctBox);
            this.Controls.Add(this.BtnSee);
            this.Controls.Add(this.TxtSifre);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHesapOlustur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hesap Oluştur/Düzenle";
            this.Load += new System.EventHandler(this.FrmHesapOlustur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PctBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Button BtnSee;
        private System.Windows.Forms.TextBox TxtSifre;
        private System.Windows.Forms.PictureBox PctBox;
        private System.Windows.Forms.ComboBox CmbPersonel;
        private System.Windows.Forms.MaskedTextBox TxtSicilNo;
        private System.Windows.Forms.CheckedListBox ChcListBoxYetkiler;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbYetkiModu;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button BtnSifirla;
        private System.Windows.Forms.Button BtnTumetki;
    }
}