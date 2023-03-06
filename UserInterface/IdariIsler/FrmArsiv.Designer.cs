
namespace UserInterface.IdariIsler
{
    partial class FrmArsiv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmArsiv));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbDosyaTuru = new System.Windows.Forms.ComboBox();
            this.Usbolgesi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DtDosyaTarihi = new System.Windows.Forms.DateTimePicker();
            this.TtxDosyaIcerigi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbCihaz = new System.Windows.Forms.ComboBox();
            this.BtnDosyaEkle = new System.Windows.Forms.Button();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblIsAkisNo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.CmbBulLok = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CmbKlasorNo = new System.Windows.Forms.TextBox();
            this.BtnDosyaTuruEkle = new System.Windows.Forms.Button();
            this.BtnSistemCihazEkle = new System.Windows.Forms.Button();
            this.CmbIslemTuru = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtIsAkisNo = new System.Windows.Forms.TextBox();
            this.BtnBul = new System.Windows.Forms.Button();
            this.BtnGuncelle = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1557, 27);
            this.panel1.TabIndex = 313;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.BtnCancel.Location = new System.Drawing.Point(12, 4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(35, 23);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 319;
            this.label2.Text = "Dosya Türü:";
            // 
            // CmbDosyaTuru
            // 
            this.CmbDosyaTuru.FormattingEnabled = true;
            this.CmbDosyaTuru.Location = new System.Drawing.Point(170, 76);
            this.CmbDosyaTuru.Name = "CmbDosyaTuru";
            this.CmbDosyaTuru.Size = new System.Drawing.Size(244, 21);
            this.CmbDosyaTuru.TabIndex = 320;
            // 
            // Usbolgesi
            // 
            this.Usbolgesi.FormattingEnabled = true;
            this.Usbolgesi.Location = new System.Drawing.Point(170, 103);
            this.Usbolgesi.Name = "Usbolgesi";
            this.Usbolgesi.Size = new System.Drawing.Size(244, 21);
            this.Usbolgesi.TabIndex = 322;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 321;
            this.label3.Text = "Bölge Adı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 323;
            this.label4.Text = "Dosya Tarihi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 324;
            this.label5.Text = "Sistem Cihaz:";
            // 
            // DtDosyaTarihi
            // 
            this.DtDosyaTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtDosyaTarihi.Location = new System.Drawing.Point(170, 158);
            this.DtDosyaTarihi.Name = "DtDosyaTarihi";
            this.DtDosyaTarihi.Size = new System.Drawing.Size(169, 20);
            this.DtDosyaTarihi.TabIndex = 326;
            // 
            // TtxDosyaIcerigi
            // 
            this.TtxDosyaIcerigi.Location = new System.Drawing.Point(169, 184);
            this.TtxDosyaIcerigi.Name = "TtxDosyaIcerigi";
            this.TtxDosyaIcerigi.Size = new System.Drawing.Size(605, 20);
            this.TtxDosyaIcerigi.TabIndex = 328;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 327;
            this.label6.Text = "Dosya İçeriği:";
            // 
            // CmbCihaz
            // 
            this.CmbCihaz.FormattingEnabled = true;
            this.CmbCihaz.Location = new System.Drawing.Point(169, 130);
            this.CmbCihaz.Name = "CmbCihaz";
            this.CmbCihaz.Size = new System.Drawing.Size(244, 21);
            this.CmbCihaz.TabIndex = 329;
            // 
            // BtnDosyaEkle
            // 
            this.BtnDosyaEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDosyaEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnDosyaEkle.Location = new System.Drawing.Point(37, 215);
            this.BtnDosyaEkle.Name = "BtnDosyaEkle";
            this.BtnDosyaEkle.Size = new System.Drawing.Size(127, 45);
            this.BtnDosyaEkle.TabIndex = 330;
            this.BtnDosyaEkle.Text = "DOSYA EKLE";
            this.BtnDosyaEkle.UseVisualStyleBackColor = true;
            this.BtnDosyaEkle.Click += new System.EventHandler(this.BtnDosyaEkle_Click);
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(170, 417);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(127, 45);
            this.BtnKaydet.TabIndex = 331;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.webBrowser1);
            this.panel2.Location = new System.Drawing.Point(170, 215);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(604, 77);
            this.panel2.TabIndex = 332;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(604, 77);
            this.webBrowser1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(167, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(607, 26);
            this.label7.TabIndex = 333;
            this.label7.Text = "NOT: Eklenecek Tutanak Dosyalarının İsimlendirmesi Bölge Adı_Sistem Cihaz Bilgisi" +
    "_Tarih Olacak Şekilde\r\nAdlandırıldıktan Sonra Eklenecektir (Örn. Şiketfe_Karla_0" +
    "1011900)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(103, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 334;
            this.label8.Text = "İş Akış No:";
            // 
            // LblIsAkisNo
            // 
            this.LblIsAkisNo.AutoSize = true;
            this.LblIsAkisNo.Location = new System.Drawing.Point(167, 47);
            this.LblIsAkisNo.Name = "LblIsAkisNo";
            this.LblIsAkisNo.Size = new System.Drawing.Size(19, 13);
            this.LblIsAkisNo.TabIndex = 335;
            this.LblIsAkisNo.Text = "00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 357);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 13);
            this.label10.TabIndex = 336;
            this.label10.Text = "Dosyanın Bulunduğu Lokasyon:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(50, 384);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 13);
            this.label11.TabIndex = 337;
            this.label11.Text = "Basılı Kopya Klasör No:";
            // 
            // CmbBulLok
            // 
            this.CmbBulLok.FormattingEnabled = true;
            this.CmbBulLok.Items.AddRange(new object[] {
            "İDARİ İŞLER"});
            this.CmbBulLok.Location = new System.Drawing.Point(172, 354);
            this.CmbBulLok.Name = "CmbBulLok";
            this.CmbBulLok.Size = new System.Drawing.Size(244, 21);
            this.CmbBulLok.TabIndex = 338;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CmbKlasorNo
            // 
            this.CmbKlasorNo.Location = new System.Drawing.Point(172, 381);
            this.CmbKlasorNo.Name = "CmbKlasorNo";
            this.CmbKlasorNo.Size = new System.Drawing.Size(42, 20);
            this.CmbKlasorNo.TabIndex = 340;
            // 
            // BtnDosyaTuruEkle
            // 
            this.BtnDosyaTuruEkle.AccessibleDescription = "";
            this.BtnDosyaTuruEkle.BackColor = System.Drawing.SystemColors.Control;
            this.BtnDosyaTuruEkle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnDosyaTuruEkle.BackgroundImage")));
            this.BtnDosyaTuruEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnDosyaTuruEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDosyaTuruEkle.Location = new System.Drawing.Point(417, 72);
            this.BtnDosyaTuruEkle.Margin = new System.Windows.Forms.Padding(0);
            this.BtnDosyaTuruEkle.Name = "BtnDosyaTuruEkle";
            this.BtnDosyaTuruEkle.Size = new System.Drawing.Size(34, 29);
            this.BtnDosyaTuruEkle.TabIndex = 397;
            this.BtnDosyaTuruEkle.Tag = "admin";
            this.BtnDosyaTuruEkle.UseVisualStyleBackColor = false;
            this.BtnDosyaTuruEkle.Click += new System.EventHandler(this.BtnDosyaTuruEkle_Click);
            // 
            // BtnSistemCihazEkle
            // 
            this.BtnSistemCihazEkle.AccessibleDescription = "";
            this.BtnSistemCihazEkle.BackColor = System.Drawing.SystemColors.Control;
            this.BtnSistemCihazEkle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnSistemCihazEkle.BackgroundImage")));
            this.BtnSistemCihazEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSistemCihazEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSistemCihazEkle.Location = new System.Drawing.Point(417, 126);
            this.BtnSistemCihazEkle.Margin = new System.Windows.Forms.Padding(0);
            this.BtnSistemCihazEkle.Name = "BtnSistemCihazEkle";
            this.BtnSistemCihazEkle.Size = new System.Drawing.Size(34, 29);
            this.BtnSistemCihazEkle.TabIndex = 398;
            this.BtnSistemCihazEkle.Tag = "admin";
            this.BtnSistemCihazEkle.UseVisualStyleBackColor = false;
            this.BtnSistemCihazEkle.Click += new System.EventHandler(this.BtnSistemCihazEkle_Click);
            // 
            // CmbIslemTuru
            // 
            this.CmbIslemTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIslemTuru.FormattingEnabled = true;
            this.CmbIslemTuru.Items.AddRange(new object[] {
            "YENİ KAYIT",
            "MEVCUT KAYIT GÜNCELLE"});
            this.CmbIslemTuru.Location = new System.Drawing.Point(530, 43);
            this.CmbIslemTuru.Name = "CmbIslemTuru";
            this.CmbIslemTuru.Size = new System.Drawing.Size(244, 21);
            this.CmbIslemTuru.TabIndex = 400;
            this.CmbIslemTuru.SelectedIndexChanged += new System.EventHandler(this.CmbIslemTuru_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(469, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 399;
            this.label1.Text = "İşlem Türü:";
            // 
            // TxtIsAkisNo
            // 
            this.TxtIsAkisNo.Location = new System.Drawing.Point(170, 43);
            this.TxtIsAkisNo.Name = "TxtIsAkisNo";
            this.TxtIsAkisNo.Size = new System.Drawing.Size(162, 20);
            this.TxtIsAkisNo.TabIndex = 401;
            this.TxtIsAkisNo.Visible = false;
            // 
            // BtnBul
            // 
            this.BtnBul.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBul.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBul.Location = new System.Drawing.Point(338, 42);
            this.BtnBul.Name = "BtnBul";
            this.BtnBul.Size = new System.Drawing.Size(75, 23);
            this.BtnBul.TabIndex = 402;
            this.BtnBul.Text = "Bul";
            this.BtnBul.UseVisualStyleBackColor = true;
            this.BtnBul.Visible = false;
            this.BtnBul.Click += new System.EventHandler(this.BtnBul_Click);
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Location = new System.Drawing.Point(172, 468);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(127, 45);
            this.BtnGuncelle.TabIndex = 403;
            this.BtnGuncelle.Text = "GÜNCELLE";
            this.BtnGuncelle.UseVisualStyleBackColor = true;
            this.BtnGuncelle.Visible = false;
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // FrmArsiv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 924);
            this.Controls.Add(this.BtnGuncelle);
            this.Controls.Add(this.BtnBul);
            this.Controls.Add(this.TxtIsAkisNo);
            this.Controls.Add(this.CmbIslemTuru);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSistemCihazEkle);
            this.Controls.Add(this.BtnDosyaTuruEkle);
            this.Controls.Add(this.CmbKlasorNo);
            this.Controls.Add(this.CmbBulLok);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LblIsAkisNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.BtnDosyaEkle);
            this.Controls.Add(this.CmbCihaz);
            this.Controls.Add(this.TtxDosyaIcerigi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DtDosyaTarihi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Usbolgesi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbDosyaTuru);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmArsiv";
            this.Text = "FrmArsiv";
            this.Load += new System.EventHandler(this.FrmArsiv_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbDosyaTuru;
        private System.Windows.Forms.ComboBox Usbolgesi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DtDosyaTarihi;
        private System.Windows.Forms.TextBox TtxDosyaIcerigi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbCihaz;
        private System.Windows.Forms.Button BtnDosyaEkle;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblIsAkisNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox CmbBulLok;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox CmbKlasorNo;
        private System.Windows.Forms.Button BtnDosyaTuruEkle;
        private System.Windows.Forms.Button BtnSistemCihazEkle;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ComboBox CmbIslemTuru;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtIsAkisNo;
        private System.Windows.Forms.Button BtnBul;
        private System.Windows.Forms.Button BtnGuncelle;
    }
}