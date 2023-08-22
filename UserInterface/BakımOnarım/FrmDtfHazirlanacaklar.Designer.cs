namespace UserInterface.BakımOnarım
{
    partial class FrmDtfHazirlanacaklar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDtfHazirlanacaklar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LblKayitTarihi = new System.Windows.Forms.DateTimePicker();
            this.CmbDonemYil = new System.Windows.Forms.ComboBox();
            this.CmbDonemAy = new System.Windows.Forms.ComboBox();
            this.label52 = new System.Windows.Forms.Label();
            this.TalepEden = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.LblIsAkisNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CmbOnarimYeri = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtIsinTanimi = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnIsinTanimiEkle = new System.Windows.Forms.Button();
            this.CmbIsKategorisi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbButceKodu = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DtgIsinVerildigiTarih = new System.Windows.Forms.DateTimePicker();
            this.BtnAltYukFirmaEkle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LblFirmaSorumlusu = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.CmbAltYukleniciFirma = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.dataBinderOto = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.LblBolgeAdi = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinderOto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1555, 27);
            this.panel1.TabIndex = 445;
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
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.DtgList);
            this.groupBox1.Location = new System.Drawing.Point(12, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1531, 409);
            this.groupBox1.TabIndex = 446;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DTF HAZIRLANACAKLAR";
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgList.AutoGenerateContextFilters = true;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgList.DateWithTime = false;
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(3, 16);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgList.Size = new System.Drawing.Size(1525, 390);
            this.DtgList.TabIndex = 4;
            this.DtgList.TimeFilter = false;
            this.DtgList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgList_CellMouseClick);
            // 
            // TxtTop
            // 
            this.TxtTop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(112, 464);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 448;
            this.TxtTop.Text = "00";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 464);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 447;
            this.label5.Text = "Toplam Kayıt:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LblBolgeAdi);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.LblKayitTarihi);
            this.groupBox3.Controls.Add(this.CmbDonemYil);
            this.groupBox3.Controls.Add(this.CmbDonemAy);
            this.groupBox3.Controls.Add(this.label52);
            this.groupBox3.Controls.Add(this.TalepEden);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.LblIsAkisNo);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label36);
            this.groupBox3.Location = new System.Drawing.Point(12, 492);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(364, 169);
            this.groupBox3.TabIndex = 449;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TALEBİ OLUŞTURAN";
            // 
            // LblKayitTarihi
            // 
            this.LblKayitTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.LblKayitTarihi.Location = new System.Drawing.Point(116, 77);
            this.LblKayitTarihi.Name = "LblKayitTarihi";
            this.LblKayitTarihi.Size = new System.Drawing.Size(104, 20);
            this.LblKayitTarihi.TabIndex = 449;
            // 
            // CmbDonemYil
            // 
            this.CmbDonemYil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDonemYil.FormattingEnabled = true;
            this.CmbDonemYil.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.CmbDonemYil.Location = new System.Drawing.Point(227, 103);
            this.CmbDonemYil.Name = "CmbDonemYil";
            this.CmbDonemYil.Size = new System.Drawing.Size(105, 21);
            this.CmbDonemYil.TabIndex = 416;
            // 
            // CmbDonemAy
            // 
            this.CmbDonemAy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDonemAy.FormattingEnabled = true;
            this.CmbDonemAy.Items.AddRange(new object[] {
            "OCAK",
            "ŞUBAT",
            "MART",
            "NİSAN",
            "MAYIS",
            "HAZİRAN",
            "TEMMUZ",
            "AĞUSTOS",
            "EYLÜL",
            "EKİM",
            "KASIM",
            "ARALIK"});
            this.CmbDonemAy.Location = new System.Drawing.Point(116, 103);
            this.CmbDonemAy.Name = "CmbDonemAy";
            this.CmbDonemAy.Size = new System.Drawing.Size(105, 21);
            this.CmbDonemAy.TabIndex = 415;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(19, 106);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(87, 13);
            this.label52.TabIndex = 414;
            this.label52.Text = "DÖNEM (Ay/Yıl):";
            // 
            // TalepEden
            // 
            this.TalepEden.AutoSize = true;
            this.TalepEden.Location = new System.Drawing.Point(112, 53);
            this.TalepEden.Name = "TalepEden";
            this.TalepEden.Size = new System.Drawing.Size(19, 13);
            this.TalepEden.TabIndex = 103;
            this.TalepEden.Text = "00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 330;
            this.label13.Text = "KAYIT TARİH:";
            // 
            // LblIsAkisNo
            // 
            this.LblIsAkisNo.AutoSize = true;
            this.LblIsAkisNo.Location = new System.Drawing.Point(113, 28);
            this.LblIsAkisNo.Name = "LblIsAkisNo";
            this.LblIsAkisNo.Size = new System.Drawing.Size(19, 13);
            this.LblIsAkisNo.TabIndex = 116;
            this.LblIsAkisNo.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "ADI SOYADI:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(40, 28);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(66, 13);
            this.label36.TabIndex = 115;
            this.label36.Text = "İŞ AKIŞ NO:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CmbOnarimYeri);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.TxtIsinTanimi);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.BtnIsinTanimiEkle);
            this.groupBox2.Controls.Add(this.CmbIsKategorisi);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.CmbButceKodu);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(12, 667);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(830, 204);
            this.groupBox2.TabIndex = 450;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ARIZA BİLGİLERİ";
            // 
            // CmbOnarimYeri
            // 
            this.CmbOnarimYeri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbOnarimYeri.FormattingEnabled = true;
            this.CmbOnarimYeri.Items.AddRange(new object[] {
            "YERİNDE ONARIM",
            "FİRMADA ONARIM-İMALAT"});
            this.CmbOnarimYeri.Location = new System.Drawing.Point(157, 165);
            this.CmbOnarimYeri.Name = "CmbOnarimYeri";
            this.CmbOnarimYeri.Size = new System.Drawing.Size(236, 21);
            this.CmbOnarimYeri.TabIndex = 452;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(70, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 451;
            this.label11.Text = "ONARIM YERİ:";
            // 
            // TxtIsinTanimi
            // 
            this.TxtIsinTanimi.Location = new System.Drawing.Point(157, 81);
            this.TxtIsinTanimi.Name = "TxtIsinTanimi";
            this.TxtIsinTanimi.Size = new System.Drawing.Size(472, 78);
            this.TxtIsinTanimi.TabIndex = 432;
            this.TxtIsinTanimi.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 431;
            this.label8.Text = "İŞİN TANIMI:";
            // 
            // BtnIsinTanimiEkle
            // 
            this.BtnIsinTanimiEkle.AccessibleDescription = "";
            this.BtnIsinTanimiEkle.BackColor = System.Drawing.SystemColors.Control;
            this.BtnIsinTanimiEkle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnIsinTanimiEkle.BackgroundImage")));
            this.BtnIsinTanimiEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnIsinTanimiEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnIsinTanimiEkle.Location = new System.Drawing.Point(396, 49);
            this.BtnIsinTanimiEkle.Margin = new System.Windows.Forms.Padding(0);
            this.BtnIsinTanimiEkle.Name = "BtnIsinTanimiEkle";
            this.BtnIsinTanimiEkle.Size = new System.Drawing.Size(34, 29);
            this.BtnIsinTanimiEkle.TabIndex = 430;
            this.BtnIsinTanimiEkle.Tag = "admin";
            this.BtnIsinTanimiEkle.UseVisualStyleBackColor = false;
            this.BtnIsinTanimiEkle.Click += new System.EventHandler(this.BtnIsinTanimiEkle_Click);
            // 
            // CmbIsKategorisi
            // 
            this.CmbIsKategorisi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIsKategorisi.FormattingEnabled = true;
            this.CmbIsKategorisi.Location = new System.Drawing.Point(157, 54);
            this.CmbIsKategorisi.Name = "CmbIsKategorisi";
            this.CmbIsKategorisi.Size = new System.Drawing.Size(236, 21);
            this.CmbIsKategorisi.TabIndex = 429;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 428;
            this.label6.Text = "İŞ KATEGORİSİ:";
            // 
            // CmbButceKodu
            // 
            this.CmbButceKodu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbButceKodu.FormattingEnabled = true;
            this.CmbButceKodu.Items.AddRange(new object[] {
            "BM07/BAKIM ONARIM",
            "BM14/EKSTRA ALIMLAR"});
            this.CmbButceKodu.Location = new System.Drawing.Point(157, 26);
            this.CmbButceKodu.Name = "CmbButceKodu";
            this.CmbButceKodu.Size = new System.Drawing.Size(236, 21);
            this.CmbButceKodu.TabIndex = 417;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 13);
            this.label9.TabIndex = 115;
            this.label9.Text = "HARCAMA KODU KALEMİ:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DtgIsinVerildigiTarih);
            this.groupBox4.Controls.Add(this.BtnAltYukFirmaEkle);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.LblFirmaSorumlusu);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.CmbAltYukleniciFirma);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(382, 491);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(460, 170);
            this.groupBox4.TabIndex = 451;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "FİRMA BİLGİLERİ";
            // 
            // DtgIsinVerildigiTarih
            // 
            this.DtgIsinVerildigiTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtgIsinVerildigiTarih.Location = new System.Drawing.Point(155, 79);
            this.DtgIsinVerildigiTarih.Name = "DtgIsinVerildigiTarih";
            this.DtgIsinVerildigiTarih.Size = new System.Drawing.Size(102, 20);
            this.DtgIsinVerildigiTarih.TabIndex = 499;
            // 
            // BtnAltYukFirmaEkle
            // 
            this.BtnAltYukFirmaEkle.AccessibleDescription = "";
            this.BtnAltYukFirmaEkle.BackColor = System.Drawing.SystemColors.Control;
            this.BtnAltYukFirmaEkle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnAltYukFirmaEkle.BackgroundImage")));
            this.BtnAltYukFirmaEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnAltYukFirmaEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAltYukFirmaEkle.Location = new System.Drawing.Point(393, 21);
            this.BtnAltYukFirmaEkle.Margin = new System.Windows.Forms.Padding(0);
            this.BtnAltYukFirmaEkle.Name = "BtnAltYukFirmaEkle";
            this.BtnAltYukFirmaEkle.Size = new System.Drawing.Size(34, 29);
            this.BtnAltYukFirmaEkle.TabIndex = 433;
            this.BtnAltYukFirmaEkle.Tag = "admin";
            this.BtnAltYukFirmaEkle.UseVisualStyleBackColor = false;
            this.BtnAltYukFirmaEkle.Click += new System.EventHandler(this.BtnAltYukFirmaEkle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 418;
            this.label2.Text = "İŞİN VERİLDİĞİ TARİH:";
            // 
            // LblFirmaSorumlusu
            // 
            this.LblFirmaSorumlusu.AutoSize = true;
            this.LblFirmaSorumlusu.Location = new System.Drawing.Point(155, 59);
            this.LblFirmaSorumlusu.Name = "LblFirmaSorumlusu";
            this.LblFirmaSorumlusu.Size = new System.Drawing.Size(19, 13);
            this.LblFirmaSorumlusu.TabIndex = 425;
            this.LblFirmaSorumlusu.Text = "00";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(34, 59);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(115, 13);
            this.label18.TabIndex = 424;
            this.label18.Text = "FİRMA SORUMLUSU:";
            // 
            // CmbAltYukleniciFirma
            // 
            this.CmbAltYukleniciFirma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAltYukleniciFirma.FormattingEnabled = true;
            this.CmbAltYukleniciFirma.Location = new System.Drawing.Point(155, 26);
            this.CmbAltYukleniciFirma.Name = "CmbAltYukleniciFirma";
            this.CmbAltYukleniciFirma.Size = new System.Drawing.Size(236, 21);
            this.CmbAltYukleniciFirma.TabIndex = 423;
            this.CmbAltYukleniciFirma.SelectedIndexChanged += new System.EventHandler(this.CmbAltYukleniciFirma_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 13);
            this.label12.TabIndex = 418;
            this.label12.Text = "ALT YÜKLENİCİ FİRMA:";
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.Image")));
            this.BtnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnKaydet.Location = new System.Drawing.Point(12, 874);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(130, 51);
            this.BtnKaydet.TabIndex = 452;
            this.BtnKaydet.Text = "     KAYDET";
            this.BtnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKaydet.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 450;
            this.label3.Text = "ÜS BÖLGESİ:";
            // 
            // LblBolgeAdi
            // 
            this.LblBolgeAdi.AutoSize = true;
            this.LblBolgeAdi.Location = new System.Drawing.Point(113, 136);
            this.LblBolgeAdi.Name = "LblBolgeAdi";
            this.LblBolgeAdi.Size = new System.Drawing.Size(19, 13);
            this.LblBolgeAdi.TabIndex = 451;
            this.LblBolgeAdi.Text = "00";
            // 
            // FrmDtfHazirlanacaklar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1555, 928);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDtfHazirlanacaklar";
            this.Text = "FrmDtfHazirlanacaklar";
            this.Load += new System.EventHandler(this.FrmOkfKontrol_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinderOto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker LblKayitTarihi;
        private System.Windows.Forms.ComboBox CmbDonemYil;
        private System.Windows.Forms.ComboBox CmbDonemAy;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label TalepEden;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label LblIsAkisNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnIsinTanimiEkle;
        private System.Windows.Forms.ComboBox CmbIsKategorisi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbButceKodu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox TxtIsinTanimi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CmbOnarimYeri;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker DtgIsinVerildigiTarih;
        private System.Windows.Forms.Button BtnAltYukFirmaEkle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblFirmaSorumlusu;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox CmbAltYukleniciFirma;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.BindingSource dataBinderOto;
        private System.Windows.Forms.Label LblBolgeAdi;
        private System.Windows.Forms.Label label3;
    }
}