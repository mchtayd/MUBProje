
namespace UserInterface.IdariIsler
{
    partial class FrmZiyaretciKayit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgGeldigiSaat = new System.Windows.Forms.DateTimePicker();
            this.TxtZiyaretNedeni = new System.Windows.Forms.RichTextBox();
            this.DtgGeldigiTarih = new System.Windows.Forms.DateTimePicker();
            this.TxtZiyaretciFirmaAdi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtZiyaretciAd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CmbZiyaretEdilenAd = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.TxtZiyaretEdilenMasYeri = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtZiyaretEdilenMasYeriNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtZiyaretEdilenUnvani = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CmbRefakatciAd = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtRefakatciMasYeri = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtRefakatciMasYeriNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtRefakatciUnvani = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.TxtZiyaretciTc = new System.Windows.Forms.MaskedTextBox();
            this.BtnGuncelle = new System.Windows.Forms.Button();
            this.LblIsAkisNo = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.CmbIslemTuruUcak = new System.Windows.Forms.ComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.TxtIsAkisNo = new System.Windows.Forms.TextBox();
            this.BtnBul = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.panel1.TabIndex = 320;
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
            this.label2.Location = new System.Drawing.Point(82, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 323;
            this.label2.Text = "ADI SOYADI:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtZiyaretciTc);
            this.groupBox1.Controls.Add(this.DtgGeldigiSaat);
            this.groupBox1.Controls.Add(this.TxtZiyaretNedeni);
            this.groupBox1.Controls.Add(this.DtgGeldigiTarih);
            this.groupBox1.Controls.Add(this.TxtZiyaretciFirmaAdi);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TxtZiyaretciAd);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 260);
            this.groupBox1.TabIndex = 325;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ZİYARETÇİ BİLGİLERİ";
            // 
            // DtgGeldigiSaat
            // 
            this.DtgGeldigiSaat.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DtgGeldigiSaat.Location = new System.Drawing.Point(163, 128);
            this.DtgGeldigiSaat.Name = "DtgGeldigiSaat";
            this.DtgGeldigiSaat.Size = new System.Drawing.Size(126, 21);
            this.DtgGeldigiSaat.TabIndex = 331;
            // 
            // TxtZiyaretNedeni
            // 
            this.TxtZiyaretNedeni.Location = new System.Drawing.Point(163, 157);
            this.TxtZiyaretNedeni.Name = "TxtZiyaretNedeni";
            this.TxtZiyaretNedeni.Size = new System.Drawing.Size(772, 87);
            this.TxtZiyaretNedeni.TabIndex = 334;
            this.TxtZiyaretNedeni.Text = "";
            // 
            // DtgGeldigiTarih
            // 
            this.DtgGeldigiTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtgGeldigiTarih.Location = new System.Drawing.Point(163, 105);
            this.DtgGeldigiTarih.Name = "DtgGeldigiTarih";
            this.DtgGeldigiTarih.Size = new System.Drawing.Size(126, 21);
            this.DtgGeldigiTarih.TabIndex = 330;
            // 
            // TxtZiyaretciFirmaAdi
            // 
            this.TxtZiyaretciFirmaAdi.Location = new System.Drawing.Point(163, 79);
            this.TxtZiyaretciFirmaAdi.Name = "TxtZiyaretciFirmaAdi";
            this.TxtZiyaretciFirmaAdi.Size = new System.Drawing.Size(293, 21);
            this.TxtZiyaretciFirmaAdi.TabIndex = 330;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(111, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 328;
            this.label7.Text = "TC NO:";
            // 
            // TxtZiyaretciAd
            // 
            this.TxtZiyaretciAd.Location = new System.Drawing.Point(163, 27);
            this.TxtZiyaretciAd.Name = "TxtZiyaretciAd";
            this.TxtZiyaretciAd.Size = new System.Drawing.Size(293, 21);
            this.TxtZiyaretciAd.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 15);
            this.label6.TabIndex = 327;
            this.label6.Text = "GELDİĞİ SAAT:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 15);
            this.label5.TabIndex = 326;
            this.label5.Text = "GELDİĞİ TARİH:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 325;
            this.label3.Text = "ZİYARET NEDENİ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 324;
            this.label1.Text = "FİRMA ADI:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CmbZiyaretEdilenAd);
            this.groupBox2.Controls.Add(this.label56);
            this.groupBox2.Controls.Add(this.TxtZiyaretEdilenMasYeri);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.TxtZiyaretEdilenMasYeriNo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.TxtZiyaretEdilenUnvani);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(12, 342);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 166);
            this.groupBox2.TabIndex = 327;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ZİYARET EDİLEN PERSONEL BİLGİLERİ";
            // 
            // CmbZiyaretEdilenAd
            // 
            this.CmbZiyaretEdilenAd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbZiyaretEdilenAd.FormattingEnabled = true;
            this.CmbZiyaretEdilenAd.Location = new System.Drawing.Point(163, 26);
            this.CmbZiyaretEdilenAd.Name = "CmbZiyaretEdilenAd";
            this.CmbZiyaretEdilenAd.Size = new System.Drawing.Size(293, 23);
            this.CmbZiyaretEdilenAd.TabIndex = 36;
            this.CmbZiyaretEdilenAd.SelectedIndexChanged += new System.EventHandler(this.CmbZiyaretEdilenAd_SelectedIndexChanged);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(88, 30);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(69, 15);
            this.label56.TabIndex = 35;
            this.label56.Text = "AD SOYAD:";
            // 
            // TxtZiyaretEdilenMasYeri
            // 
            this.TxtZiyaretEdilenMasYeri.Location = new System.Drawing.Point(163, 109);
            this.TxtZiyaretEdilenMasYeri.Name = "TxtZiyaretEdilenMasYeri";
            this.TxtZiyaretEdilenMasYeri.Size = new System.Drawing.Size(293, 21);
            this.TxtZiyaretEdilenMasYeri.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 15);
            this.label8.TabIndex = 33;
            this.label8.Text = "MASRAF YERİ/BÖLÜMÜ:";
            // 
            // TxtZiyaretEdilenMasYeriNo
            // 
            this.TxtZiyaretEdilenMasYeriNo.Location = new System.Drawing.Point(163, 82);
            this.TxtZiyaretEdilenMasYeriNo.Name = "TxtZiyaretEdilenMasYeriNo";
            this.TxtZiyaretEdilenMasYeriNo.Size = new System.Drawing.Size(293, 21);
            this.TxtZiyaretEdilenMasYeriNo.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 15);
            this.label9.TabIndex = 31;
            this.label9.Text = "MASRAF YERİ NO:";
            // 
            // TxtZiyaretEdilenUnvani
            // 
            this.TxtZiyaretEdilenUnvani.Location = new System.Drawing.Point(163, 55);
            this.TxtZiyaretEdilenUnvani.Name = "TxtZiyaretEdilenUnvani";
            this.TxtZiyaretEdilenUnvani.Size = new System.Drawing.Size(293, 21);
            this.TxtZiyaretEdilenUnvani.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "ÜNVANI:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CmbRefakatciAd);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.TxtRefakatciMasYeri);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.TxtRefakatciMasYeriNo);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.TxtRefakatciUnvani);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(495, 342);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(477, 166);
            this.groupBox3.TabIndex = 328;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "REFAKATÇİ BİLGİLERİ:";
            // 
            // CmbRefakatciAd
            // 
            this.CmbRefakatciAd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRefakatciAd.FormattingEnabled = true;
            this.CmbRefakatciAd.Location = new System.Drawing.Point(159, 26);
            this.CmbRefakatciAd.Name = "CmbRefakatciAd";
            this.CmbRefakatciAd.Size = new System.Drawing.Size(293, 23);
            this.CmbRefakatciAd.TabIndex = 36;
            this.CmbRefakatciAd.SelectedIndexChanged += new System.EventHandler(this.CmbRefakatciAd_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(84, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 15);
            this.label10.TabIndex = 35;
            this.label10.Text = "AD SOYAD:";
            // 
            // TxtRefakatciMasYeri
            // 
            this.TxtRefakatciMasYeri.Location = new System.Drawing.Point(159, 109);
            this.TxtRefakatciMasYeri.Name = "TxtRefakatciMasYeri";
            this.TxtRefakatciMasYeri.Size = new System.Drawing.Size(293, 21);
            this.TxtRefakatciMasYeri.TabIndex = 34;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 15);
            this.label11.TabIndex = 33;
            this.label11.Text = "MASRAF YERİ/BÖLÜMÜ:";
            // 
            // TxtRefakatciMasYeriNo
            // 
            this.TxtRefakatciMasYeriNo.Location = new System.Drawing.Point(159, 82);
            this.TxtRefakatciMasYeriNo.Name = "TxtRefakatciMasYeriNo";
            this.TxtRefakatciMasYeriNo.Size = new System.Drawing.Size(293, 21);
            this.TxtRefakatciMasYeriNo.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(43, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 15);
            this.label12.TabIndex = 31;
            this.label12.Text = "MASRAF YERİ NO:";
            // 
            // TxtRefakatciUnvani
            // 
            this.TxtRefakatciUnvani.Location = new System.Drawing.Point(159, 55);
            this.TxtRefakatciUnvani.Name = "TxtRefakatciUnvani";
            this.TxtRefakatciUnvani.Size = new System.Drawing.Size(293, 21);
            this.TxtRefakatciUnvani.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(99, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 15);
            this.label13.TabIndex = 29;
            this.label13.Text = "ÜNVANI:";
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(12, 514);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(178, 50);
            this.BtnKaydet.TabIndex = 329;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // TxtZiyaretciTc
            // 
            this.TxtZiyaretciTc.Location = new System.Drawing.Point(163, 53);
            this.TxtZiyaretciTc.Mask = "00000000000";
            this.TxtZiyaretciTc.Name = "TxtZiyaretciTc";
            this.TxtZiyaretciTc.Size = new System.Drawing.Size(126, 21);
            this.TxtZiyaretciTc.TabIndex = 335;
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Location = new System.Drawing.Point(12, 514);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(178, 50);
            this.BtnGuncelle.TabIndex = 330;
            this.BtnGuncelle.Text = "GÜNCELLE";
            this.BtnGuncelle.UseVisualStyleBackColor = true;
            this.BtnGuncelle.Visible = false;
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // LblIsAkisNo
            // 
            this.LblIsAkisNo.AutoSize = true;
            this.LblIsAkisNo.Location = new System.Drawing.Point(174, 47);
            this.LblIsAkisNo.Name = "LblIsAkisNo";
            this.LblIsAkisNo.Size = new System.Drawing.Size(19, 13);
            this.LblIsAkisNo.TabIndex = 332;
            this.LblIsAkisNo.Text = "00";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(103, 47);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(66, 13);
            this.label61.TabIndex = 331;
            this.label61.Text = "İŞ AKIŞ NO:";
            // 
            // CmbIslemTuruUcak
            // 
            this.CmbIslemTuruUcak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIslemTuruUcak.FormattingEnabled = true;
            this.CmbIslemTuruUcak.Items.AddRange(new object[] {
            "YENİ KAYIT",
            "MEVCUT KAYIT GÜNCELLEME"});
            this.CmbIslemTuruUcak.Location = new System.Drawing.Point(520, 44);
            this.CmbIslemTuruUcak.Name = "CmbIslemTuruUcak";
            this.CmbIslemTuruUcak.Size = new System.Drawing.Size(258, 21);
            this.CmbIslemTuruUcak.TabIndex = 334;
            this.CmbIslemTuruUcak.SelectedIndexChanged += new System.EventHandler(this.CmbIslemTuruUcak_SelectedIndexChanged);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(433, 48);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(76, 13);
            this.label54.TabIndex = 333;
            this.label54.Text = "İŞLEM TÜRÜ:";
            // 
            // TxtIsAkisNo
            // 
            this.TxtIsAkisNo.Location = new System.Drawing.Point(175, 44);
            this.TxtIsAkisNo.Name = "TxtIsAkisNo";
            this.TxtIsAkisNo.Size = new System.Drawing.Size(126, 20);
            this.TxtIsAkisNo.TabIndex = 37;
            this.TxtIsAkisNo.Visible = false;
            // 
            // BtnBul
            // 
            this.BtnBul.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBul.Location = new System.Drawing.Point(307, 43);
            this.BtnBul.Name = "BtnBul";
            this.BtnBul.Size = new System.Drawing.Size(75, 23);
            this.BtnBul.TabIndex = 335;
            this.BtnBul.Text = "BUL";
            this.BtnBul.UseVisualStyleBackColor = true;
            this.BtnBul.Visible = false;
            this.BtnBul.Click += new System.EventHandler(this.BtnBul_Click);
            // 
            // FrmZiyaretciKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 924);
            this.Controls.Add(this.BtnBul);
            this.Controls.Add(this.TxtIsAkisNo);
            this.Controls.Add(this.CmbIslemTuruUcak);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.LblIsAkisNo);
            this.Controls.Add(this.label61);
            this.Controls.Add(this.BtnGuncelle);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmZiyaretciKayit";
            this.Text = "FrmZiyaretciKayit";
            this.Load += new System.EventHandler(this.FrmZiyaretciKayit_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtZiyaretciFirmaAdi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtZiyaretciAd;
        private System.Windows.Forms.ComboBox CmbZiyaretEdilenAd;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox TxtZiyaretEdilenMasYeri;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtZiyaretEdilenMasYeriNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtZiyaretEdilenUnvani;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox CmbRefakatciAd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtRefakatciMasYeri;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtRefakatciMasYeriNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtRefakatciUnvani;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker DtgGeldigiSaat;
        private System.Windows.Forms.RichTextBox TxtZiyaretNedeni;
        private System.Windows.Forms.DateTimePicker DtgGeldigiTarih;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.MaskedTextBox TxtZiyaretciTc;
        private System.Windows.Forms.Button BtnGuncelle;
        private System.Windows.Forms.Label LblIsAkisNo;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.ComboBox CmbIslemTuruUcak;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox TxtIsAkisNo;
        private System.Windows.Forms.Button BtnBul;
    }
}