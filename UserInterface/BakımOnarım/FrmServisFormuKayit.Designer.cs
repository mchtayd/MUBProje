
namespace UserInterface.BakımOnarım
{
    partial class FrmServisFormuKayit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServisFormuKayit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbFirma = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbBolgeAdi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtServisFormNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbMudehaleTuru = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtMarka = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtSeriNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtModel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtServisRaporu = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtServisYetkilisi = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.TxtMusteri = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtJenaratorCalismaSaati = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.TxtGuc = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.BtnDosyaEkle = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.CmbIslemTuru = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.LblIsAkisNo = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.BtnGuncelle = new System.Windows.Forms.Button();
            this.BtnFirmaEkle = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DtgKullanilanMalzemeler = new System.Windows.Forms.DataGridView();
            this.ParcaKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KullanilanMalzeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgServisTarihi = new System.Windows.Forms.DateTimePicker();
            this.DtBaslamaTarihi = new System.Windows.Forms.DateTimePicker();
            this.DtBaslamaTarihiSaati = new System.Windows.Forms.DateTimePicker();
            this.DtBitisTarihiSaati = new System.Windows.Forms.DateTimePicker();
            this.DtBitisTarihi = new System.Windows.Forms.DateTimePicker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TxtIsAkisNo = new System.Windows.Forms.TextBox();
            this.BtnBul = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgKullanilanMalzemeler)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1442, 31);
            this.panel1.TabIndex = 45;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.BtnCancel.Location = new System.Drawing.Point(14, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(41, 27);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "FİRMA:";
            // 
            // CmbFirma
            // 
            this.CmbFirma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFirma.FormattingEnabled = true;
            this.CmbFirma.Location = new System.Drawing.Point(181, 75);
            this.CmbFirma.Name = "CmbFirma";
            this.CmbFirma.Size = new System.Drawing.Size(204, 21);
            this.CmbFirma.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "ÜS BÖLGESİ:";
            // 
            // CmbBolgeAdi
            // 
            this.CmbBolgeAdi.FormattingEnabled = true;
            this.CmbBolgeAdi.Location = new System.Drawing.Point(181, 102);
            this.CmbBolgeAdi.Name = "CmbBolgeAdi";
            this.CmbBolgeAdi.Size = new System.Drawing.Size(204, 21);
            this.CmbBolgeAdi.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "SERVİS FORMU NO:";
            // 
            // TxtServisFormNo
            // 
            this.TxtServisFormNo.Location = new System.Drawing.Point(181, 129);
            this.TxtServisFormNo.Name = "TxtServisFormNo";
            this.TxtServisFormNo.Size = new System.Drawing.Size(204, 20);
            this.TxtServisFormNo.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "SERVİS TARİHİ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "İŞE BAŞLAMA TARİHİ/SAATİ:";
            // 
            // CmbMudehaleTuru
            // 
            this.CmbMudehaleTuru.FormattingEnabled = true;
            this.CmbMudehaleTuru.Items.AddRange(new object[] {
            "PERİYODİK BAKIM",
            "GARANTİ İÇİ BO",
            "GARANTİ DIŞI BO"});
            this.CmbMudehaleTuru.Location = new System.Drawing.Point(181, 155);
            this.CmbMudehaleTuru.Name = "CmbMudehaleTuru";
            this.CmbMudehaleTuru.Size = new System.Drawing.Size(204, 21);
            this.CmbMudehaleTuru.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "MÜDEHALE TÜRÜ:";
            // 
            // TxtMarka
            // 
            this.TxtMarka.Location = new System.Drawing.Point(181, 287);
            this.TxtMarka.Name = "TxtMarka";
            this.TxtMarka.Size = new System.Drawing.Size(204, 20);
            this.TxtMarka.TabIndex = 61;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(127, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 60;
            this.label8.Text = "MARKA:";
            // 
            // TxtSeriNo
            // 
            this.TxtSeriNo.Location = new System.Drawing.Point(181, 339);
            this.TxtSeriNo.Name = "TxtSeriNo";
            this.TxtSeriNo.Size = new System.Drawing.Size(204, 20);
            this.TxtSeriNo.TabIndex = 63;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(121, 343);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 62;
            this.label9.Text = "SERİ NO:";
            // 
            // TxtModel
            // 
            this.TxtModel.Location = new System.Drawing.Point(181, 313);
            this.TxtModel.Name = "TxtModel";
            this.TxtModel.Size = new System.Drawing.Size(204, 20);
            this.TxtModel.TabIndex = 65;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(127, 317);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 64;
            this.label10.Text = "MODEL:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(77, 395);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 13);
            this.label11.TabIndex = 66;
            this.label11.Text = "SERVİS RAPORU:";
            // 
            // TxtServisRaporu
            // 
            this.TxtServisRaporu.Location = new System.Drawing.Point(181, 392);
            this.TxtServisRaporu.Name = "TxtServisRaporu";
            this.TxtServisRaporu.Size = new System.Drawing.Size(789, 136);
            this.TxtServisRaporu.TabIndex = 67;
            this.TxtServisRaporu.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(121, 554);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 13);
            this.label12.TabIndex = 68;
            // 
            // TxtServisYetkilisi
            // 
            this.TxtServisYetkilisi.Location = new System.Drawing.Point(181, 734);
            this.TxtServisYetkilisi.Name = "TxtServisYetkilisi";
            this.TxtServisYetkilisi.Size = new System.Drawing.Size(204, 20);
            this.TxtServisYetkilisi.TabIndex = 71;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(73, 737);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(102, 13);
            this.label19.TabIndex = 70;
            this.label19.Text = "SERVİS YETKİLİSİ:";
            // 
            // TxtMusteri
            // 
            this.TxtMusteri.Location = new System.Drawing.Point(181, 760);
            this.TxtMusteri.Name = "TxtMusteri";
            this.TxtMusteri.Size = new System.Drawing.Size(204, 20);
            this.TxtMusteri.TabIndex = 73;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(116, 763);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 13);
            this.label20.TabIndex = 72;
            this.label20.Text = "MÜŞTERİ:";
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(17, 855);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(158, 48);
            this.BtnKaydet.TabIndex = 74;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "İŞ BİTİŞ TARİHİ/SAATİ:";
            // 
            // TxtJenaratorCalismaSaati
            // 
            this.TxtJenaratorCalismaSaati.Location = new System.Drawing.Point(181, 208);
            this.TxtJenaratorCalismaSaati.Name = "TxtJenaratorCalismaSaati";
            this.TxtJenaratorCalismaSaati.Size = new System.Drawing.Size(204, 20);
            this.TxtJenaratorCalismaSaati.TabIndex = 76;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(17, 212);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(158, 13);
            this.label21.TabIndex = 75;
            this.label21.Text = "JENARATÖR ÇALIŞMA SAATİ:";
            // 
            // TxtGuc
            // 
            this.TxtGuc.Location = new System.Drawing.Point(181, 365);
            this.TxtGuc.Name = "TxtGuc";
            this.TxtGuc.Size = new System.Drawing.Size(204, 20);
            this.TxtGuc.TabIndex = 78;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(112, 369);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(63, 13);
            this.label22.TabIndex = 77;
            this.label22.Text = "GÜÇ (KVA):";
            // 
            // BtnDosyaEkle
            // 
            this.BtnDosyaEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDosyaEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnDosyaEkle.Location = new System.Drawing.Point(17, 801);
            this.BtnDosyaEkle.Name = "BtnDosyaEkle";
            this.BtnDosyaEkle.Size = new System.Drawing.Size(158, 48);
            this.BtnDosyaEkle.TabIndex = 79;
            this.BtnDosyaEkle.Text = "DOSYA EKLE";
            this.BtnDosyaEkle.UseVisualStyleBackColor = true;
            this.BtnDosyaEkle.Click += new System.EventHandler(this.BtnDosyaEkle_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowser1);
            this.groupBox2.Location = new System.Drawing.Point(181, 791);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(786, 115);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EKLER:";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(780, 96);
            this.webBrowser1.TabIndex = 0;
            // 
            // CmbIslemTuru
            // 
            this.CmbIslemTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIslemTuru.FormattingEnabled = true;
            this.CmbIslemTuru.Items.AddRange(new object[] {
            "YENİ KAYIT OLUŞTUR",
            "MEVCUT KAYIT GÜNCELLE"});
            this.CmbIslemTuru.Location = new System.Drawing.Point(533, 45);
            this.CmbIslemTuru.Name = "CmbIslemTuru";
            this.CmbIslemTuru.Size = new System.Drawing.Size(216, 21);
            this.CmbIslemTuru.TabIndex = 93;
            this.CmbIslemTuru.SelectedIndexChanged += new System.EventHandler(this.CmbIslemTuru_SelectedIndexChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(454, 49);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(76, 13);
            this.label39.TabIndex = 92;
            this.label39.Text = "İŞLEM TÜRÜ:";
            // 
            // LblIsAkisNo
            // 
            this.LblIsAkisNo.AutoSize = true;
            this.LblIsAkisNo.Location = new System.Drawing.Point(181, 48);
            this.LblIsAkisNo.Name = "LblIsAkisNo";
            this.LblIsAkisNo.Size = new System.Drawing.Size(19, 13);
            this.LblIsAkisNo.TabIndex = 95;
            this.LblIsAkisNo.Text = "00";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(108, 48);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(66, 13);
            this.label61.TabIndex = 94;
            this.label61.Text = "İŞ AKIŞ NO:";
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Location = new System.Drawing.Point(17, 855);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(158, 48);
            this.BtnGuncelle.TabIndex = 96;
            this.BtnGuncelle.Text = "GÜNCELLE";
            this.BtnGuncelle.UseVisualStyleBackColor = true;
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // BtnFirmaEkle
            // 
            this.BtnFirmaEkle.AccessibleDescription = "";
            this.BtnFirmaEkle.BackColor = System.Drawing.SystemColors.Control;
            this.BtnFirmaEkle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnFirmaEkle.BackgroundImage")));
            this.BtnFirmaEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnFirmaEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnFirmaEkle.Location = new System.Drawing.Point(388, 70);
            this.BtnFirmaEkle.Margin = new System.Windows.Forms.Padding(0);
            this.BtnFirmaEkle.Name = "BtnFirmaEkle";
            this.BtnFirmaEkle.Size = new System.Drawing.Size(34, 29);
            this.BtnFirmaEkle.TabIndex = 397;
            this.BtnFirmaEkle.Tag = "admin";
            this.BtnFirmaEkle.UseVisualStyleBackColor = false;
            this.BtnFirmaEkle.Click += new System.EventHandler(this.BtnFirmaEkle_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DtgKullanilanMalzemeler);
            this.groupBox3.Location = new System.Drawing.Point(181, 545);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(789, 183);
            this.groupBox3.TabIndex = 398;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "KULLANILAN YEDEK PARÇA";
            // 
            // DtgKullanilanMalzemeler
            // 
            this.DtgKullanilanMalzemeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgKullanilanMalzemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgKullanilanMalzemeler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParcaKodu,
            this.KullanilanMalzeme,
            this.Adet});
            this.DtgKullanilanMalzemeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgKullanilanMalzemeler.Location = new System.Drawing.Point(3, 16);
            this.DtgKullanilanMalzemeler.Name = "DtgKullanilanMalzemeler";
            this.DtgKullanilanMalzemeler.Size = new System.Drawing.Size(783, 164);
            this.DtgKullanilanMalzemeler.TabIndex = 0;
            // 
            // ParcaKodu
            // 
            this.ParcaKodu.HeaderText = "PARÇA KODU";
            this.ParcaKodu.Name = "ParcaKodu";
            // 
            // KullanilanMalzeme
            // 
            this.KullanilanMalzeme.HeaderText = "KULLANILAN MALZEME";
            this.KullanilanMalzeme.Name = "KullanilanMalzeme";
            // 
            // Adet
            // 
            this.Adet.HeaderText = "ADET";
            this.Adet.Name = "Adet";
            // 
            // DtgServisTarihi
            // 
            this.DtgServisTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtgServisTarihi.Location = new System.Drawing.Point(181, 182);
            this.DtgServisTarihi.Name = "DtgServisTarihi";
            this.DtgServisTarihi.Size = new System.Drawing.Size(204, 20);
            this.DtgServisTarihi.TabIndex = 399;
            // 
            // DtBaslamaTarihi
            // 
            this.DtBaslamaTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtBaslamaTarihi.Location = new System.Drawing.Point(181, 233);
            this.DtBaslamaTarihi.Name = "DtBaslamaTarihi";
            this.DtBaslamaTarihi.Size = new System.Drawing.Size(120, 20);
            this.DtBaslamaTarihi.TabIndex = 400;
            // 
            // DtBaslamaTarihiSaati
            // 
            this.DtBaslamaTarihiSaati.CustomFormat = "HH:mm";
            this.DtBaslamaTarihiSaati.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DtBaslamaTarihiSaati.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtBaslamaTarihiSaati.Location = new System.Drawing.Point(307, 232);
            this.DtBaslamaTarihiSaati.Name = "DtBaslamaTarihiSaati";
            this.DtBaslamaTarihiSaati.ShowUpDown = true;
            this.DtBaslamaTarihiSaati.Size = new System.Drawing.Size(78, 21);
            this.DtBaslamaTarihiSaati.TabIndex = 402;
            this.DtBaslamaTarihiSaati.Value = new System.DateTime(2018, 1, 12, 0, 0, 0, 0);
            // 
            // DtBitisTarihiSaati
            // 
            this.DtBitisTarihiSaati.CustomFormat = "HH:mm";
            this.DtBitisTarihiSaati.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DtBitisTarihiSaati.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtBitisTarihiSaati.Location = new System.Drawing.Point(307, 259);
            this.DtBitisTarihiSaati.Name = "DtBitisTarihiSaati";
            this.DtBitisTarihiSaati.ShowUpDown = true;
            this.DtBitisTarihiSaati.Size = new System.Drawing.Size(78, 21);
            this.DtBitisTarihiSaati.TabIndex = 404;
            this.DtBitisTarihiSaati.Value = new System.DateTime(2018, 1, 12, 0, 0, 0, 0);
            // 
            // DtBitisTarihi
            // 
            this.DtBitisTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtBitisTarihi.Location = new System.Drawing.Point(181, 260);
            this.DtBitisTarihi.Name = "DtBitisTarihi";
            this.DtBitisTarihi.Size = new System.Drawing.Size(120, 20);
            this.DtBitisTarihi.TabIndex = 403;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TxtIsAkisNo
            // 
            this.TxtIsAkisNo.Location = new System.Drawing.Point(180, 46);
            this.TxtIsAkisNo.Name = "TxtIsAkisNo";
            this.TxtIsAkisNo.Size = new System.Drawing.Size(204, 20);
            this.TxtIsAkisNo.TabIndex = 405;
            // 
            // BtnBul
            // 
            this.BtnBul.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBul.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBul.Location = new System.Drawing.Point(387, 43);
            this.BtnBul.Name = "BtnBul";
            this.BtnBul.Size = new System.Drawing.Size(46, 24);
            this.BtnBul.TabIndex = 406;
            this.BtnBul.Text = "Bul";
            this.BtnBul.UseVisualStyleBackColor = true;
            this.BtnBul.Click += new System.EventHandler(this.BtnBul_Click);
            // 
            // FrmServisFormuKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 926);
            this.Controls.Add(this.BtnBul);
            this.Controls.Add(this.TxtIsAkisNo);
            this.Controls.Add(this.DtBitisTarihiSaati);
            this.Controls.Add(this.DtBitisTarihi);
            this.Controls.Add(this.DtBaslamaTarihiSaati);
            this.Controls.Add(this.DtBaslamaTarihi);
            this.Controls.Add(this.DtgServisTarihi);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.BtnFirmaEkle);
            this.Controls.Add(this.BtnGuncelle);
            this.Controls.Add(this.LblIsAkisNo);
            this.Controls.Add(this.label61);
            this.Controls.Add(this.CmbIslemTuru);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnDosyaEkle);
            this.Controls.Add(this.TxtGuc);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.TxtJenaratorCalismaSaati);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.TxtMusteri);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.TxtServisYetkilisi);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TxtServisRaporu);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TxtModel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtSeriNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtMarka);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CmbMudehaleTuru);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtServisFormNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbBolgeAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbFirma);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmServisFormuKayit";
            this.Text = "FrmServisFormuKayit";
            this.Load += new System.EventHandler(this.FrmServisFormuKayit_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgKullanilanMalzemeler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbFirma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbBolgeAdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtServisFormNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbMudehaleTuru;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtMarka;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtSeriNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtModel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox TxtServisRaporu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtServisYetkilisi;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TxtMusteri;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtJenaratorCalismaSaati;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox TxtGuc;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button BtnDosyaEkle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ComboBox CmbIslemTuru;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label LblIsAkisNo;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Button BtnGuncelle;
        private System.Windows.Forms.Button BtnFirmaEkle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DtgKullanilanMalzemeler;
        private System.Windows.Forms.DateTimePicker DtgServisTarihi;
        private System.Windows.Forms.DateTimePicker DtBaslamaTarihi;
        private System.Windows.Forms.DateTimePicker DtBaslamaTarihiSaati;
        private System.Windows.Forms.DateTimePicker DtBitisTarihiSaati;
        private System.Windows.Forms.DateTimePicker DtBitisTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParcaKodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn KullanilanMalzeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adet;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox TxtIsAkisNo;
        private System.Windows.Forms.Button BtnBul;
    }
}