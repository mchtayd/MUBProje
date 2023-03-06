namespace UserInterface.Gecic_Kabul_Ambar
{
    partial class FrmMalzemeGuncelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMalzemeGuncelle));
            this.CmbTedarikTuru = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtOnarimDurumu = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnFotoEkle = new System.Windows.Forms.Button();
            this.PctBox = new System.Windows.Forms.PictureBox();
            this.TxtTanim = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbTedarikciFirma = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.TxtAlternatifMalzeme = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtMalzemeTuru = new System.Windows.Forms.ComboBox();
            this.CmbBirim = new System.Windows.Forms.ComboBox();
            this.CmbOnarimYeri = new System.Windows.Forms.ComboBox();
            this.CmbMalzemeTakip = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtAciklama = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CmbMalKulUst = new System.Windows.Forms.ComboBox();
            this.CmbAdSoyad = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.TxtStn = new System.Windows.Forms.TextBox();
            this.CmbSistemStokNo = new System.Windows.Forms.ComboBox();
            this.BtnGuncelle = new System.Windows.Forms.Button();
            this.BtnStokAl = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.PctBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbTedarikTuru
            // 
            this.CmbTedarikTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTedarikTuru.FormattingEnabled = true;
            this.CmbTedarikTuru.Location = new System.Drawing.Point(151, 195);
            this.CmbTedarikTuru.Name = "CmbTedarikTuru";
            this.CmbTedarikTuru.Size = new System.Drawing.Size(238, 21);
            this.CmbTedarikTuru.TabIndex = 365;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(66, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 15);
            this.label10.TabIndex = 364;
            this.label10.Text = "Tedarik Türü:";
            // 
            // TxtOnarimDurumu
            // 
            this.TxtOnarimDurumu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TxtOnarimDurumu.FormattingEnabled = true;
            this.TxtOnarimDurumu.Items.AddRange(new object[] {
            "VAR",
            "YOK"});
            this.TxtOnarimDurumu.Location = new System.Drawing.Point(151, 137);
            this.TxtOnarimDurumu.Name = "TxtOnarimDurumu";
            this.TxtOnarimDurumu.Size = new System.Drawing.Size(238, 21);
            this.TxtOnarimDurumu.TabIndex = 358;
            this.TxtOnarimDurumu.SelectedIndexChanged += new System.EventHandler(this.TxtOnarimDurumu_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 344;
            this.label1.Text = "Parça Stok No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 345;
            this.label2.Text = "Tanım:";
            // 
            // BtnFotoEkle
            // 
            this.BtnFotoEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnFotoEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnFotoEkle.Location = new System.Drawing.Point(517, 166);
            this.BtnFotoEkle.Name = "BtnFotoEkle";
            this.BtnFotoEkle.Size = new System.Drawing.Size(146, 30);
            this.BtnFotoEkle.TabIndex = 355;
            this.BtnFotoEkle.Text = "FOTOĞRAF EKLE";
            this.BtnFotoEkle.UseVisualStyleBackColor = true;
            this.BtnFotoEkle.Click += new System.EventHandler(this.BtnFotoEkle_Click);
            // 
            // PctBox
            // 
            this.PctBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PctBox.Location = new System.Drawing.Point(517, 23);
            this.PctBox.Name = "PctBox";
            this.PctBox.Size = new System.Drawing.Size(146, 137);
            this.PctBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PctBox.TabIndex = 356;
            this.PctBox.TabStop = false;
            // 
            // TxtTanim
            // 
            this.TxtTanim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTanim.Location = new System.Drawing.Point(151, 52);
            this.TxtTanim.Name = "TxtTanim";
            this.TxtTanim.Size = new System.Drawing.Size(348, 21);
            this.TxtTanim.TabIndex = 347;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 15);
            this.label3.TabIndex = 348;
            this.label3.Text = "Parça Onarım Durumu:";
            // 
            // CmbTedarikciFirma
            // 
            this.CmbTedarikciFirma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTedarikciFirma.FormattingEnabled = true;
            this.CmbTedarikciFirma.Location = new System.Drawing.Point(151, 108);
            this.CmbTedarikciFirma.Name = "CmbTedarikciFirma";
            this.CmbTedarikciFirma.Size = new System.Drawing.Size(238, 21);
            this.CmbTedarikciFirma.TabIndex = 363;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(53, 284);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 15);
            this.label18.TabIndex = 362;
            this.label18.Text = "Alternatif Parça:";
            // 
            // TxtAlternatifMalzeme
            // 
            this.TxtAlternatifMalzeme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtAlternatifMalzeme.Location = new System.Drawing.Point(151, 281);
            this.TxtAlternatifMalzeme.Name = "TxtAlternatifMalzeme";
            this.TxtAlternatifMalzeme.Size = new System.Drawing.Size(238, 21);
            this.TxtAlternatifMalzeme.TabIndex = 361;
            this.TxtAlternatifMalzeme.Text = "YOK";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(106, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 349;
            this.label4.Text = "Birim:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(50, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 15);
            this.label9.TabIndex = 354;
            this.label9.Text = "Tedarikçi Firma:";
            // 
            // TxtMalzemeTuru
            // 
            this.TxtMalzemeTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TxtMalzemeTuru.FormattingEnabled = true;
            this.TxtMalzemeTuru.Location = new System.Drawing.Point(151, 224);
            this.TxtMalzemeTuru.Name = "TxtMalzemeTuru";
            this.TxtMalzemeTuru.Size = new System.Drawing.Size(238, 21);
            this.TxtMalzemeTuru.TabIndex = 360;
            // 
            // CmbBirim
            // 
            this.CmbBirim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBirim.FormattingEnabled = true;
            this.CmbBirim.Location = new System.Drawing.Point(151, 79);
            this.CmbBirim.Name = "CmbBirim";
            this.CmbBirim.Size = new System.Drawing.Size(238, 21);
            this.CmbBirim.TabIndex = 357;
            // 
            // CmbOnarimYeri
            // 
            this.CmbOnarimYeri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbOnarimYeri.FormattingEnabled = true;
            this.CmbOnarimYeri.Location = new System.Drawing.Point(151, 166);
            this.CmbOnarimYeri.Name = "CmbOnarimYeri";
            this.CmbOnarimYeri.Size = new System.Drawing.Size(238, 21);
            this.CmbOnarimYeri.TabIndex = 359;
            // 
            // CmbMalzemeTakip
            // 
            this.CmbMalzemeTakip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMalzemeTakip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbMalzemeTakip.FormattingEnabled = true;
            this.CmbMalzemeTakip.Items.AddRange(new object[] {
            "SERİ NO",
            "LOT NO"});
            this.CmbMalzemeTakip.Location = new System.Drawing.Point(151, 252);
            this.CmbMalzemeTakip.Name = "CmbMalzemeTakip";
            this.CmbMalzemeTakip.Size = new System.Drawing.Size(238, 23);
            this.CmbMalzemeTakip.TabIndex = 350;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 15);
            this.label5.TabIndex = 351;
            this.label5.Text = "Parça Onarım Yeri:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(73, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 15);
            this.label6.TabIndex = 352;
            this.label6.Text = "Parça Sınıfı:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 15);
            this.label8.TabIndex = 353;
            this.label8.Text = "Parça Takip Durumu:";
            // 
            // TxtAciklama
            // 
            this.TxtAciklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtAciklama.Location = new System.Drawing.Point(151, 401);
            this.TxtAciklama.Name = "TxtAciklama";
            this.TxtAciklama.Size = new System.Drawing.Size(826, 66);
            this.TxtAciklama.TabIndex = 366;
            this.TxtAciklama.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(85, 404);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 367;
            this.label7.Text = "Açıklama:";
            // 
            // CmbMalKulUst
            // 
            this.CmbMalKulUst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMalKulUst.FormattingEnabled = true;
            this.CmbMalKulUst.Location = new System.Drawing.Point(151, 308);
            this.CmbMalKulUst.Name = "CmbMalKulUst";
            this.CmbMalKulUst.Size = new System.Drawing.Size(238, 21);
            this.CmbMalKulUst.TabIndex = 373;
            this.CmbMalKulUst.SelectedIndexChanged += new System.EventHandler(this.CmbMalKulUst_SelectedIndexChanged);
            // 
            // CmbAdSoyad
            // 
            this.CmbAdSoyad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAdSoyad.FormattingEnabled = true;
            this.CmbAdSoyad.Location = new System.Drawing.Point(151, 364);
            this.CmbAdSoyad.Name = "CmbAdSoyad";
            this.CmbAdSoyad.Size = new System.Drawing.Size(238, 21);
            this.CmbAdSoyad.TabIndex = 372;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(34, 368);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 15);
            this.label11.TabIndex = 371;
            this.label11.Text = "Sistem Sorumlusu:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(51, 340);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 15);
            this.label16.TabIndex = 368;
            this.label16.Text = "Sistem Stok No:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(59, 311);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 15);
            this.label17.TabIndex = 369;
            this.label17.Text = "Sistem Tanım:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(151, 477);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 375;
            this.label14.Text = "EKLER:";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(151, 493);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(23, 23);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(827, 112);
            this.webBrowser1.TabIndex = 374;
            // 
            // TxtStn
            // 
            this.TxtStn.Location = new System.Drawing.Point(151, 26);
            this.TxtStn.Name = "TxtStn";
            this.TxtStn.Size = new System.Drawing.Size(238, 20);
            this.TxtStn.TabIndex = 376;
            // 
            // CmbSistemStokNo
            // 
            this.CmbSistemStokNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSistemStokNo.FormattingEnabled = true;
            this.CmbSistemStokNo.Location = new System.Drawing.Point(151, 337);
            this.CmbSistemStokNo.Name = "CmbSistemStokNo";
            this.CmbSistemStokNo.Size = new System.Drawing.Size(238, 21);
            this.CmbSistemStokNo.TabIndex = 377;
            this.CmbSistemStokNo.SelectedIndexChanged += new System.EventHandler(this.CmbSistemStokNo_SelectedIndexChanged);
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Image = ((System.Drawing.Image)(resources.GetObject("BtnGuncelle.Image")));
            this.BtnGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuncelle.Location = new System.Drawing.Point(151, 614);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(130, 51);
            this.BtnGuncelle.TabIndex = 378;
            this.BtnGuncelle.Text = "  GÜNCELLE";
            this.BtnGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuncelle.UseVisualStyleBackColor = false;
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // BtnStokAl
            // 
            this.BtnStokAl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnStokAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnStokAl.Location = new System.Drawing.Point(395, 23);
            this.BtnStokAl.Name = "BtnStokAl";
            this.BtnStokAl.Size = new System.Drawing.Size(104, 23);
            this.BtnStokAl.TabIndex = 379;
            this.BtnStokAl.Text = "Stok No Al";
            this.BtnStokAl.UseVisualStyleBackColor = true;
            this.BtnStokAl.Click += new System.EventHandler(this.BtnStokAl_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmMalzemeGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 676);
            this.Controls.Add(this.BtnStokAl);
            this.Controls.Add(this.BtnGuncelle);
            this.Controls.Add(this.CmbSistemStokNo);
            this.Controls.Add(this.TxtStn);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.CmbMalKulUst);
            this.Controls.Add(this.CmbAdSoyad);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.TxtAciklama);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CmbTedarikTuru);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtOnarimDurumu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnFotoEkle);
            this.Controls.Add(this.PctBox);
            this.Controls.Add(this.TxtTanim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbTedarikciFirma);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.TxtAlternatifMalzeme);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtMalzemeTuru);
            this.Controls.Add(this.CmbBirim);
            this.Controls.Add(this.CmbOnarimYeri);
            this.Controls.Add(this.CmbMalzemeTakip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMalzemeGuncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Güncelle";
            this.Load += new System.EventHandler(this.FrmMalzemeGuncelle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PctBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbTedarikTuru;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox TxtOnarimDurumu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnFotoEkle;
        private System.Windows.Forms.PictureBox PctBox;
        private System.Windows.Forms.TextBox TxtTanim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbTedarikciFirma;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox TxtAlternatifMalzeme;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox TxtMalzemeTuru;
        private System.Windows.Forms.ComboBox CmbBirim;
        private System.Windows.Forms.ComboBox CmbOnarimYeri;
        private System.Windows.Forms.ComboBox CmbMalzemeTakip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox TxtAciklama;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CmbMalKulUst;
        private System.Windows.Forms.ComboBox CmbAdSoyad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox TxtStn;
        private System.Windows.Forms.ComboBox CmbSistemStokNo;
        private System.Windows.Forms.Button BtnGuncelle;
        private System.Windows.Forms.Button BtnStokAl;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}