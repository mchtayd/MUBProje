
namespace UserInterface.Yerleskeler
{
    partial class FrmYerleskeKayit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmYerleskeKayit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.GrbKiralik = new System.Windows.Forms.GroupBox();
            this.TxtTelefonNo = new System.Windows.Forms.MaskedTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.BtnDosyaEkleKira = new System.Windows.Forms.Button();
            this.TxtDepozito = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TxtTutar = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.DtgKiraBasTarihi = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtIban = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtBankaSubesi = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtTC = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtIkametgah = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtAdiSoyadi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.CmbMulkiyetBilgileri = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.BtbnDosyaEkleAbonelik = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgAbonelikler = new System.Windows.Forms.DataGridView();
            this.AboneTuru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HizmetAlinanKurum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AboneTesisatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AboneTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnEkle = new System.Windows.Forms.Button();
            this.BtnAboneTuruEkle = new System.Windows.Forms.Button();
            this.DtgAboneTarihi = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtTesisatNumarasi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtHizmetAlinanKurum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbAbonelikTuru = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtYerleskeAdresi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtYerleskeAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CmbYerleskeAdi = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.GrbKiralik.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgAbonelikler)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1451, 32);
            this.panel1.TabIndex = 305;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.BtnCancel.Location = new System.Drawing.Point(14, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(43, 28);
            this.BtnCancel.TabIndex = 19;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // GrbKiralik
            // 
            this.GrbKiralik.Controls.Add(this.TxtTelefonNo);
            this.GrbKiralik.Controls.Add(this.groupBox6);
            this.GrbKiralik.Controls.Add(this.BtnDosyaEkleKira);
            this.GrbKiralik.Controls.Add(this.TxtDepozito);
            this.GrbKiralik.Controls.Add(this.label15);
            this.GrbKiralik.Controls.Add(this.TxtTutar);
            this.GrbKiralik.Controls.Add(this.label14);
            this.GrbKiralik.Controls.Add(this.DtgKiraBasTarihi);
            this.GrbKiralik.Controls.Add(this.label13);
            this.GrbKiralik.Controls.Add(this.TxtIban);
            this.GrbKiralik.Controls.Add(this.label12);
            this.GrbKiralik.Controls.Add(this.TxtBankaSubesi);
            this.GrbKiralik.Controls.Add(this.label11);
            this.GrbKiralik.Controls.Add(this.label10);
            this.GrbKiralik.Controls.Add(this.TxtTC);
            this.GrbKiralik.Controls.Add(this.label9);
            this.GrbKiralik.Controls.Add(this.TxtIkametgah);
            this.GrbKiralik.Controls.Add(this.label8);
            this.GrbKiralik.Controls.Add(this.TxtAdiSoyadi);
            this.GrbKiralik.Controls.Add(this.label7);
            this.GrbKiralik.Location = new System.Drawing.Point(649, 90);
            this.GrbKiralik.Name = "GrbKiralik";
            this.GrbKiralik.Size = new System.Drawing.Size(629, 762);
            this.GrbKiralik.TabIndex = 403;
            this.GrbKiralik.TabStop = false;
            this.GrbKiralik.Text = "KİRA BİLGİLERİ";
            // 
            // TxtTelefonNo
            // 
            this.TxtTelefonNo.Location = new System.Drawing.Point(248, 115);
            this.TxtTelefonNo.Mask = "(999) 000-0000";
            this.TxtTelefonNo.Name = "TxtTelefonNo";
            this.TxtTelefonNo.Size = new System.Drawing.Size(286, 21);
            this.TxtTelefonNo.TabIndex = 423;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.webBrowser2);
            this.groupBox6.Location = new System.Drawing.Point(11, 310);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(600, 134);
            this.groupBox6.TabIndex = 411;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "KİRA KONTRATI EKLE";
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.Location = new System.Drawing.Point(3, 17);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(23, 23);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(594, 114);
            this.webBrowser2.TabIndex = 1;
            // 
            // BtnDosyaEkleKira
            // 
            this.BtnDosyaEkleKira.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDosyaEkleKira.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnDosyaEkleKira.Location = new System.Drawing.Point(11, 450);
            this.BtnDosyaEkleKira.Name = "BtnDosyaEkleKira";
            this.BtnDosyaEkleKira.Size = new System.Drawing.Size(129, 34);
            this.BtnDosyaEkleKira.TabIndex = 410;
            this.BtnDosyaEkleKira.Text = "DOSYA EKLE";
            this.BtnDosyaEkleKira.UseVisualStyleBackColor = true;
            this.BtnDosyaEkleKira.Click += new System.EventHandler(this.BtnDosyaEkleKira_Click);
            // 
            // TxtDepozito
            // 
            this.TxtDepozito.Location = new System.Drawing.Point(248, 267);
            this.TxtDepozito.Name = "TxtDepozito";
            this.TxtDepozito.Size = new System.Drawing.Size(147, 21);
            this.TxtDepozito.TabIndex = 422;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(183, 268);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 15);
            this.label15.TabIndex = 421;
            this.label15.Text = "Depozito:";
            // 
            // TxtTutar
            // 
            this.TxtTutar.Location = new System.Drawing.Point(248, 237);
            this.TxtTutar.Name = "TxtTutar";
            this.TxtTutar.Size = new System.Drawing.Size(147, 21);
            this.TxtTutar.TabIndex = 420;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(176, 238);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 15);
            this.label14.TabIndex = 419;
            this.label14.Text = "Kira Tutarı:";
            // 
            // DtgKiraBasTarihi
            // 
            this.DtgKiraBasTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtgKiraBasTarihi.Location = new System.Drawing.Point(248, 207);
            this.DtgKiraBasTarihi.Name = "DtgKiraBasTarihi";
            this.DtgKiraBasTarihi.Size = new System.Drawing.Size(147, 21);
            this.DtgKiraBasTarihi.TabIndex = 418;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(119, 208);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 15);
            this.label13.TabIndex = 416;
            this.label13.Text = "Kira Başlangıç Tarihi:";
            // 
            // TxtIban
            // 
            this.TxtIban.Location = new System.Drawing.Point(248, 177);
            this.TxtIban.Name = "TxtIban";
            this.TxtIban.Size = new System.Drawing.Size(286, 21);
            this.TxtIban.TabIndex = 415;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(107, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 15);
            this.label12.TabIndex = 414;
            this.label12.Text = "Kiraya Verenin Iban No:";
            // 
            // TxtBankaSubesi
            // 
            this.TxtBankaSubesi.Location = new System.Drawing.Point(248, 147);
            this.TxtBankaSubesi.Name = "TxtBankaSubesi";
            this.TxtBankaSubesi.Size = new System.Drawing.Size(286, 21);
            this.TxtBankaSubesi.TabIndex = 413;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(74, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(168, 15);
            this.label11.TabIndex = 412;
            this.label11.Text = "Kiraya Verenin Banka Şubesi:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(90, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 15);
            this.label10.TabIndex = 410;
            this.label10.Text = "Kiraya Verenin Telefon No:";
            // 
            // TxtTC
            // 
            this.TxtTC.Location = new System.Drawing.Point(248, 57);
            this.TxtTC.Name = "TxtTC";
            this.TxtTC.Size = new System.Drawing.Size(286, 21);
            this.TxtTC.TabIndex = 409;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(118, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 15);
            this.label9.TabIndex = 408;
            this.label9.Text = "Kiraya Verenin Tc No:";
            // 
            // TxtIkametgah
            // 
            this.TxtIkametgah.Location = new System.Drawing.Point(248, 87);
            this.TxtIkametgah.Name = "TxtIkametgah";
            this.TxtIkametgah.Size = new System.Drawing.Size(286, 21);
            this.TxtIkametgah.TabIndex = 407;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(89, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 15);
            this.label8.TabIndex = 406;
            this.label8.Text = "Kiraya Verenin İkametgahı:";
            // 
            // TxtAdiSoyadi
            // 
            this.TxtAdiSoyadi.Location = new System.Drawing.Point(248, 27);
            this.TxtAdiSoyadi.Name = "TxtAdiSoyadi";
            this.TxtAdiSoyadi.Size = new System.Drawing.Size(286, 21);
            this.TxtAdiSoyadi.TabIndex = 405;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(93, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 15);
            this.label7.TabIndex = 404;
            this.label7.Text = "Kiraya Verenin Adı Soyadı:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.CmbMulkiyetBilgileri);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Controls.Add(this.BtbnDosyaEkleAbonelik);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.TxtYerleskeAdresi);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.TxtYerleskeAdi);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(14, 90);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(629, 762);
            this.groupBox5.TabIndex = 404;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "YERLEŞKE BİLGİLERİ";
            // 
            // CmbMulkiyetBilgileri
            // 
            this.CmbMulkiyetBilgileri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMulkiyetBilgileri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbMulkiyetBilgileri.FormattingEnabled = true;
            this.CmbMulkiyetBilgileri.Items.AddRange(new object[] {
            "KİRALIK",
            "MÜLKİYET"});
            this.CmbMulkiyetBilgileri.Location = new System.Drawing.Point(126, 51);
            this.CmbMulkiyetBilgileri.Name = "CmbMulkiyetBilgileri";
            this.CmbMulkiyetBilgileri.Size = new System.Drawing.Size(257, 23);
            this.CmbMulkiyetBilgileri.TabIndex = 411;
            this.CmbMulkiyetBilgileri.TextChanged += new System.EventHandler(this.CmbMulkiyetBilgileri_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label16.Location = new System.Drawing.Point(21, 55);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 15);
            this.label16.TabIndex = 410;
            this.label16.Text = "Mülkiyet Bilgileri:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.webBrowser1);
            this.groupBox3.Location = new System.Drawing.Point(6, 575);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(600, 134);
            this.groupBox3.TabIndex = 409;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SÖZLEŞME EKLE";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 17);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(23, 23);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(594, 114);
            this.webBrowser1.TabIndex = 0;
            // 
            // BtbnDosyaEkleAbonelik
            // 
            this.BtbnDosyaEkleAbonelik.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtbnDosyaEkleAbonelik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtbnDosyaEkleAbonelik.Location = new System.Drawing.Point(6, 715);
            this.BtbnDosyaEkleAbonelik.Name = "BtbnDosyaEkleAbonelik";
            this.BtbnDosyaEkleAbonelik.Size = new System.Drawing.Size(129, 34);
            this.BtbnDosyaEkleAbonelik.TabIndex = 408;
            this.BtbnDosyaEkleAbonelik.Text = "DOSYA EKLE";
            this.BtbnDosyaEkleAbonelik.UseVisualStyleBackColor = true;
            this.BtbnDosyaEkleAbonelik.Click += new System.EventHandler(this.BtbnDosyaEkleAbonelik_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.BtnEkle);
            this.groupBox1.Controls.Add(this.BtnAboneTuruEkle);
            this.groupBox1.Controls.Add(this.DtgAboneTarihi);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TxtTesisatNumarasi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtHizmetAlinanKurum);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CmbAbonelikTuru);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 458);
            this.groupBox1.TabIndex = 407;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ABONELİKLER";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgAbonelikler);
            this.groupBox2.Location = new System.Drawing.Point(20, 194);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 255);
            this.groupBox2.TabIndex = 399;
            this.groupBox2.TabStop = false;
            // 
            // DtgAbonelikler
            // 
            this.DtgAbonelikler.AllowUserToAddRows = false;
            this.DtgAbonelikler.AllowUserToDeleteRows = false;
            this.DtgAbonelikler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgAbonelikler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AboneTuru,
            this.HizmetAlinanKurum,
            this.AboneTesisatNo,
            this.AboneTarihi});
            this.DtgAbonelikler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgAbonelikler.Location = new System.Drawing.Point(3, 17);
            this.DtgAbonelikler.Name = "DtgAbonelikler";
            this.DtgAbonelikler.ReadOnly = true;
            this.DtgAbonelikler.Size = new System.Drawing.Size(560, 235);
            this.DtgAbonelikler.TabIndex = 0;
            // 
            // AboneTuru
            // 
            this.AboneTuru.HeaderText = "ABONE TÜRÜ";
            this.AboneTuru.Name = "AboneTuru";
            this.AboneTuru.ReadOnly = true;
            // 
            // HizmetAlinanKurum
            // 
            this.HizmetAlinanKurum.HeaderText = "HİZMET ALINAN KURUM";
            this.HizmetAlinanKurum.Name = "HizmetAlinanKurum";
            this.HizmetAlinanKurum.ReadOnly = true;
            // 
            // AboneTesisatNo
            // 
            this.AboneTesisatNo.HeaderText = "ABONE TESİSAT NO";
            this.AboneTesisatNo.Name = "AboneTesisatNo";
            this.AboneTesisatNo.ReadOnly = true;
            // 
            // AboneTarihi
            // 
            this.AboneTarihi.HeaderText = "ABONE TARİHİ";
            this.AboneTarihi.Name = "AboneTarihi";
            this.AboneTarihi.ReadOnly = true;
            // 
            // BtnEkle
            // 
            this.BtnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnEkle.Location = new System.Drawing.Point(171, 153);
            this.BtnEkle.Name = "BtnEkle";
            this.BtnEkle.Size = new System.Drawing.Size(114, 36);
            this.BtnEkle.TabIndex = 398;
            this.BtnEkle.Text = "EKLE";
            this.BtnEkle.UseVisualStyleBackColor = true;
            this.BtnEkle.Click += new System.EventHandler(this.BtnEkle_Click);
            // 
            // BtnAboneTuruEkle
            // 
            this.BtnAboneTuruEkle.AccessibleDescription = "";
            this.BtnAboneTuruEkle.BackColor = System.Drawing.SystemColors.Control;
            this.BtnAboneTuruEkle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnAboneTuruEkle.BackgroundImage")));
            this.BtnAboneTuruEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnAboneTuruEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAboneTuruEkle.Location = new System.Drawing.Point(384, 26);
            this.BtnAboneTuruEkle.Margin = new System.Windows.Forms.Padding(0);
            this.BtnAboneTuruEkle.Name = "BtnAboneTuruEkle";
            this.BtnAboneTuruEkle.Size = new System.Drawing.Size(40, 33);
            this.BtnAboneTuruEkle.TabIndex = 397;
            this.BtnAboneTuruEkle.Tag = "admin";
            this.BtnAboneTuruEkle.UseVisualStyleBackColor = false;
            this.BtnAboneTuruEkle.Click += new System.EventHandler(this.BtnAboneTuruEkle_Click);
            // 
            // DtgAboneTarihi
            // 
            this.DtgAboneTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtgAboneTarihi.Location = new System.Drawing.Point(171, 123);
            this.DtgAboneTarihi.Name = "DtgAboneTarihi";
            this.DtgAboneTarihi.Size = new System.Drawing.Size(209, 21);
            this.DtgAboneTarihi.TabIndex = 318;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(86, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 316;
            this.label6.Text = "Abone Tarihi:";
            // 
            // TxtTesisatNumarasi
            // 
            this.TxtTesisatNumarasi.Location = new System.Drawing.Point(171, 93);
            this.TxtTesisatNumarasi.Name = "TxtTesisatNumarasi";
            this.TxtTesisatNumarasi.Size = new System.Drawing.Size(209, 21);
            this.TxtTesisatNumarasi.TabIndex = 315;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(21, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 15);
            this.label5.TabIndex = 314;
            this.label5.Text = "Abone Tesisat Numarası:";
            // 
            // TxtHizmetAlinanKurum
            // 
            this.TxtHizmetAlinanKurum.Location = new System.Drawing.Point(171, 63);
            this.TxtHizmetAlinanKurum.Name = "TxtHizmetAlinanKurum";
            this.TxtHizmetAlinanKurum.Size = new System.Drawing.Size(209, 21);
            this.TxtHizmetAlinanKurum.TabIndex = 312;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(39, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 15);
            this.label4.TabIndex = 311;
            this.label4.Text = "Hizmet Alınan Kurum:";
            // 
            // CmbAbonelikTuru
            // 
            this.CmbAbonelikTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAbonelikTuru.FormattingEnabled = true;
            this.CmbAbonelikTuru.Location = new System.Drawing.Point(171, 31);
            this.CmbAbonelikTuru.Name = "CmbAbonelikTuru";
            this.CmbAbonelikTuru.Size = new System.Drawing.Size(209, 23);
            this.CmbAbonelikTuru.TabIndex = 313;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(92, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 311;
            this.label3.Text = "Abone Türü:";
            // 
            // TxtYerleskeAdresi
            // 
            this.TxtYerleskeAdresi.Location = new System.Drawing.Point(126, 80);
            this.TxtYerleskeAdresi.Name = "TxtYerleskeAdresi";
            this.TxtYerleskeAdresi.Size = new System.Drawing.Size(473, 21);
            this.TxtYerleskeAdresi.TabIndex = 406;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(26, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 405;
            this.label2.Text = "Yerleşke Adresi:";
            // 
            // TxtYerleskeAdi
            // 
            this.TxtYerleskeAdi.Location = new System.Drawing.Point(126, 24);
            this.TxtYerleskeAdi.Name = "TxtYerleskeAdi";
            this.TxtYerleskeAdi.Size = new System.Drawing.Size(257, 21);
            this.TxtYerleskeAdi.TabIndex = 404;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(43, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 403;
            this.label1.Text = "Yerleşke Adı:";
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(20, 858);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(129, 44);
            this.BtnKaydet.TabIndex = 410;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CmbYerleskeAdi
            // 
            this.CmbYerleskeAdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYerleskeAdi.FormattingEnabled = true;
            this.CmbYerleskeAdi.Location = new System.Drawing.Point(140, 50);
            this.CmbYerleskeAdi.Name = "CmbYerleskeAdi";
            this.CmbYerleskeAdi.Size = new System.Drawing.Size(257, 23);
            this.CmbYerleskeAdi.TabIndex = 401;
            this.CmbYerleskeAdi.SelectedIndexChanged += new System.EventHandler(this.CmbYerleskeAdi_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label17.Location = new System.Drawing.Point(33, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(101, 15);
            this.label17.TabIndex = 400;
            this.label17.Text = "Yerleşke Adı Seç:";
            // 
            // FrmYerleskeKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 947);
            this.Controls.Add(this.CmbYerleskeAdi);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.GrbKiralik);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "FrmYerleskeKayit";
            this.Text = "FrmYerleskeKayit";
            this.Load += new System.EventHandler(this.FrmYerleskeKayit_Load);
            this.panel1.ResumeLayout(false);
            this.GrbKiralik.ResumeLayout(false);
            this.GrbKiralik.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgAbonelikler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox GrbKiralik;
        private System.Windows.Forms.TextBox TxtIban;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtBankaSubesi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtTC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtIkametgah;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtAdiSoyadi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtbnDosyaEkleAbonelik;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DtgAbonelikler;
        private System.Windows.Forms.Button BtnEkle;
        private System.Windows.Forms.Button BtnAboneTuruEkle;
        private System.Windows.Forms.DateTimePicker DtgAboneTarihi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtTesisatNumarasi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtHizmetAlinanKurum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbAbonelikTuru;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtYerleskeAdresi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtYerleskeAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.Button BtnDosyaEkleKira;
        private System.Windows.Forms.TextBox TxtDepozito;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TxtTutar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker DtgKiraBasTarihi;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ComboBox CmbMulkiyetBilgileri;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn AboneTuru;
        private System.Windows.Forms.DataGridViewTextBoxColumn HizmetAlinanKurum;
        private System.Windows.Forms.DataGridViewTextBoxColumn AboneTesisatNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AboneTarihi;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MaskedTextBox TxtTelefonNo;
        private System.Windows.Forms.ComboBox CmbYerleskeAdi;
        private System.Windows.Forms.Label label17;
    }
}