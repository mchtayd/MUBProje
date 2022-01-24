
namespace UserInterface.IdariIsler
{
    partial class FrmYurtIciGorevSAT
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
            this.CmbMasYeri = new System.Windows.Forms.ComboBox();
            this.CmbIlgiliKisi = new System.Windows.Forms.ComboBox();
            this.CmbFaturaFirma = new System.Windows.Forms.ComboBox();
            this.CmbHarcamaTuru = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Gerekce = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnTamamla = new System.Windows.Forms.Button();
            this.BtnTemizle = new System.Windows.Forms.Button();
            this.BtnDosyaEkle = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.CmbDonemYil = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.CmbDonemAy = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbMasYeri
            // 
            this.CmbMasYeri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.CmbMasYeri.FormattingEnabled = true;
            this.CmbMasYeri.Items.AddRange(new object[] {
            "",
            "2017007-1",
            "2017008-1",
            "2017008-2",
            "2017000-1"});
            this.CmbMasYeri.Location = new System.Drawing.Point(159, 124);
            this.CmbMasYeri.Name = "CmbMasYeri";
            this.CmbMasYeri.Size = new System.Drawing.Size(278, 21);
            this.CmbMasYeri.TabIndex = 20;
            this.CmbMasYeri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbMasYeri_KeyPress);
            // 
            // CmbIlgiliKisi
            // 
            this.CmbIlgiliKisi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.CmbIlgiliKisi.FormattingEnabled = true;
            this.CmbIlgiliKisi.Items.AddRange(new object[] {
            "",
            "ERKAN İPEK",
            "UĞUR DURAN",
            "GÜLİZ MARAŞ",
            "RESUL GÜNEŞ"});
            this.CmbIlgiliKisi.Location = new System.Drawing.Point(159, 89);
            this.CmbIlgiliKisi.Name = "CmbIlgiliKisi";
            this.CmbIlgiliKisi.Size = new System.Drawing.Size(278, 21);
            this.CmbIlgiliKisi.TabIndex = 19;
            this.CmbIlgiliKisi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbIlgiliKisi_KeyPress);
            // 
            // CmbFaturaFirma
            // 
            this.CmbFaturaFirma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFaturaFirma.FormattingEnabled = true;
            this.CmbFaturaFirma.Items.AddRange(new object[] {
            "",
            "ASELSAN AŞ. UGES ÜRÜN DES.MDL.",
            "ASELSAN AŞ. UGES İÇ GÜV.PROG.DİR.",
            "ASELSAN AŞ. UGES İÇ GÜV.PROG.MDL.",
            "BAŞARAN İLERİ TEKNOLOJİ"});
            this.CmbFaturaFirma.Location = new System.Drawing.Point(159, 57);
            this.CmbFaturaFirma.Name = "CmbFaturaFirma";
            this.CmbFaturaFirma.Size = new System.Drawing.Size(278, 21);
            this.CmbFaturaFirma.TabIndex = 18;
            this.CmbFaturaFirma.SelectedIndexChanged += new System.EventHandler(this.CmbFaturaFirma_SelectedIndexChanged);
            // 
            // CmbHarcamaTuru
            // 
            this.CmbHarcamaTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbHarcamaTuru.FormattingEnabled = true;
            this.CmbHarcamaTuru.Items.AddRange(new object[] {
            "",
            "NAKİT",
            "HAVALE/EFT"});
            this.CmbHarcamaTuru.Location = new System.Drawing.Point(159, 23);
            this.CmbHarcamaTuru.Name = "CmbHarcamaTuru";
            this.CmbHarcamaTuru.Size = new System.Drawing.Size(278, 21);
            this.CmbHarcamaTuru.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "MASRAF YERİ NO:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "İLGİLİ KİŞİ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "FATURA EDİLECEK FİRMA:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "SAT HARCAMA TÜRÜ:";
            // 
            // Gerekce
            // 
            this.Gerekce.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Gerekce.Location = new System.Drawing.Point(158, 196);
            this.Gerekce.Name = "Gerekce";
            this.Gerekce.Size = new System.Drawing.Size(519, 72);
            this.Gerekce.TabIndex = 101;
            this.Gerekce.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(92, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 100;
            this.label9.Text = "GEREKÇE:";
            // 
            // BtnTamamla
            // 
            this.BtnTamamla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTamamla.Location = new System.Drawing.Point(158, 287);
            this.BtnTamamla.Name = "BtnTamamla";
            this.BtnTamamla.Size = new System.Drawing.Size(155, 51);
            this.BtnTamamla.TabIndex = 102;
            this.BtnTamamla.Text = "TAMAMLA";
            this.BtnTamamla.UseVisualStyleBackColor = true;
            this.BtnTamamla.Click += new System.EventHandler(this.BtnTamamla_Click);
            // 
            // BtnTemizle
            // 
            this.BtnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTemizle.Location = new System.Drawing.Point(480, 287);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(155, 51);
            this.BtnTemizle.TabIndex = 103;
            this.BtnTemizle.Text = "TEMİZLE";
            this.BtnTemizle.UseVisualStyleBackColor = true;
            this.BtnTemizle.Click += new System.EventHandler(this.BtnTemizle_Click);
            // 
            // BtnDosyaEkle
            // 
            this.BtnDosyaEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnDosyaEkle.Location = new System.Drawing.Point(319, 287);
            this.BtnDosyaEkle.Name = "BtnDosyaEkle";
            this.BtnDosyaEkle.Size = new System.Drawing.Size(155, 51);
            this.BtnDosyaEkle.TabIndex = 104;
            this.BtnDosyaEkle.Text = "DOSYA EKLE";
            this.BtnDosyaEkle.UseVisualStyleBackColor = true;
            this.BtnDosyaEkle.Click += new System.EventHandler(this.BtnDosyaEkle_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.webBrowser1);
            this.groupBox3.Location = new System.Drawing.Point(158, 344);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(686, 170);
            this.groupBox3.TabIndex = 341;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SAT DOSYASI";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(680, 151);
            this.webBrowser1.TabIndex = 0;
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
            this.CmbDonemYil.Location = new System.Drawing.Point(269, 159);
            this.CmbDonemYil.Name = "CmbDonemYil";
            this.CmbDonemYil.Size = new System.Drawing.Size(105, 21);
            this.CmbDonemYil.TabIndex = 431;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(62, 163);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(87, 13);
            this.label35.TabIndex = 430;
            this.label35.Text = "DÖNEM (Ay/Yıl):";
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
            this.CmbDonemAy.Location = new System.Drawing.Point(158, 159);
            this.CmbDonemAy.Name = "CmbDonemAy";
            this.CmbDonemAy.Size = new System.Drawing.Size(105, 21);
            this.CmbDonemAy.TabIndex = 429;
            // 
            // FrmYurtIciGorevSAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 531);
            this.Controls.Add(this.CmbDonemYil);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.CmbDonemAy);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.BtnDosyaEkle);
            this.Controls.Add(this.BtnTemizle);
            this.Controls.Add(this.BtnTamamla);
            this.Controls.Add(this.Gerekce);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CmbMasYeri);
            this.Controls.Add(this.CmbIlgiliKisi);
            this.Controls.Add(this.CmbFaturaFirma);
            this.Controls.Add(this.CmbHarcamaTuru);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmYurtIciGorevSAT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAT Kayıt Tamamala";
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbMasYeri;
        private System.Windows.Forms.ComboBox CmbIlgiliKisi;
        private System.Windows.Forms.ComboBox CmbFaturaFirma;
        private System.Windows.Forms.ComboBox CmbHarcamaTuru;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox Gerekce;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnTamamla;
        private System.Windows.Forms.Button BtnTemizle;
        private System.Windows.Forms.Button BtnDosyaEkle;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ComboBox CmbDonemYil;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox CmbDonemAy;
    }
}