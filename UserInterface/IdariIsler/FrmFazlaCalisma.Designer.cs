namespace UserInterface.IdariIsler
{
    partial class FrmFazlaCalisma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFazlaCalisma));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.LblMasrafYeri = new System.Windows.Forms.Label();
            this.LblMasrafYeriNo = new System.Windows.Forms.Label();
            this.LblUnvani = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblTarihBit = new System.Windows.Forms.DateTimePicker();
            this.LblTarihBas = new System.Windows.Forms.DateTimePicker();
            this.BtnSureHesapla = new System.Windows.Forms.Button();
            this.LblToplamIzin = new System.Windows.Forms.Label();
            this.LblToplamMesai = new System.Windows.Forms.Label();
            this.DtSaatBit = new System.Windows.Forms.DateTimePicker();
            this.DtSaatBas = new System.Windows.Forms.DateTimePicker();
            this.TxtMesaiNedeni = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.CmbTalepEdenPersonel = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 36);
            this.panel1.TabIndex = 320;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.BtnCancel.Location = new System.Drawing.Point(13, 3);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(48, 31);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.CmbTalepEdenPersonel);
            this.groupBox8.Controls.Add(this.LblMasrafYeri);
            this.groupBox8.Controls.Add(this.LblMasrafYeriNo);
            this.groupBox8.Controls.Add(this.LblUnvani);
            this.groupBox8.Controls.Add(this.label52);
            this.groupBox8.Controls.Add(this.label56);
            this.groupBox8.Controls.Add(this.label58);
            this.groupBox8.Controls.Add(this.label59);
            this.groupBox8.Location = new System.Drawing.Point(14, 43);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox8.Size = new System.Drawing.Size(866, 164);
            this.groupBox8.TabIndex = 321;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Personel Bilgileri";
            // 
            // LblMasrafYeri
            // 
            this.LblMasrafYeri.AutoSize = true;
            this.LblMasrafYeri.Location = new System.Drawing.Point(227, 127);
            this.LblMasrafYeri.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblMasrafYeri.Name = "LblMasrafYeri";
            this.LblMasrafYeri.Size = new System.Drawing.Size(21, 15);
            this.LblMasrafYeri.TabIndex = 24;
            this.LblMasrafYeri.Text = "00";
            // 
            // LblMasrafYeriNo
            // 
            this.LblMasrafYeriNo.AutoSize = true;
            this.LblMasrafYeriNo.Location = new System.Drawing.Point(227, 96);
            this.LblMasrafYeriNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblMasrafYeriNo.Name = "LblMasrafYeriNo";
            this.LblMasrafYeriNo.Size = new System.Drawing.Size(21, 15);
            this.LblMasrafYeriNo.TabIndex = 23;
            this.LblMasrafYeriNo.Text = "00";
            // 
            // LblUnvani
            // 
            this.LblUnvani.AutoSize = true;
            this.LblUnvani.Location = new System.Drawing.Point(227, 65);
            this.LblUnvani.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblUnvani.Name = "LblUnvani";
            this.LblUnvani.Size = new System.Drawing.Size(21, 15);
            this.LblUnvani.TabIndex = 22;
            this.LblUnvani.Text = "00";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(168, 65);
            this.label52.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(54, 15);
            this.label52.TabIndex = 19;
            this.label52.Text = "ÜNVANI:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(153, 33);
            this.label56.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(69, 15);
            this.label56.TabIndex = 9;
            this.label56.Text = "AD SOYAD:";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(86, 127);
            this.label58.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(136, 15);
            this.label58.TabIndex = 5;
            this.label58.Text = "MASRAF YERİ/BÖLÜM:";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(112, 96);
            this.label59.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(110, 15);
            this.label59.TabIndex = 1;
            this.label59.Text = "MASRAF YERİ NO:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblTarihBit);
            this.groupBox1.Controls.Add(this.LblTarihBas);
            this.groupBox1.Controls.Add(this.BtnSureHesapla);
            this.groupBox1.Controls.Add(this.LblToplamIzin);
            this.groupBox1.Controls.Add(this.LblToplamMesai);
            this.groupBox1.Controls.Add(this.DtSaatBit);
            this.groupBox1.Controls.Add(this.DtSaatBas);
            this.groupBox1.Controls.Add(this.TxtMesaiNedeni);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(14, 213);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(866, 206);
            this.groupBox1.TabIndex = 322;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fazla Çalışma / Mesai Bilgileri";
            // 
            // LblTarihBit
            // 
            this.LblTarihBit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.LblTarihBit.Location = new System.Drawing.Point(230, 95);
            this.LblTarihBit.Name = "LblTarihBit";
            this.LblTarihBit.Size = new System.Drawing.Size(116, 21);
            this.LblTarihBit.TabIndex = 543;
            // 
            // LblTarihBas
            // 
            this.LblTarihBas.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.LblTarihBas.Location = new System.Drawing.Point(230, 63);
            this.LblTarihBas.Name = "LblTarihBas";
            this.LblTarihBas.Size = new System.Drawing.Size(116, 21);
            this.LblTarihBas.TabIndex = 542;
            // 
            // BtnSureHesapla
            // 
            this.BtnSureHesapla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSureHesapla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSureHesapla.Location = new System.Drawing.Point(441, 63);
            this.BtnSureHesapla.Name = "BtnSureHesapla";
            this.BtnSureHesapla.Size = new System.Drawing.Size(89, 54);
            this.BtnSureHesapla.TabIndex = 539;
            this.BtnSureHesapla.Text = "Süre Hesapla";
            this.BtnSureHesapla.UseVisualStyleBackColor = true;
            this.BtnSureHesapla.Click += new System.EventHandler(this.BtnSureHesapla_Click);
            // 
            // LblToplamIzin
            // 
            this.LblToplamIzin.AutoSize = true;
            this.LblToplamIzin.Location = new System.Drawing.Point(227, 162);
            this.LblToplamIzin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblToplamIzin.Name = "LblToplamIzin";
            this.LblToplamIzin.Size = new System.Drawing.Size(21, 15);
            this.LblToplamIzin.TabIndex = 538;
            this.LblToplamIzin.Text = "00";
            // 
            // LblToplamMesai
            // 
            this.LblToplamMesai.AutoSize = true;
            this.LblToplamMesai.Location = new System.Drawing.Point(227, 128);
            this.LblToplamMesai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblToplamMesai.Name = "LblToplamMesai";
            this.LblToplamMesai.Size = new System.Drawing.Size(21, 15);
            this.LblToplamMesai.TabIndex = 537;
            this.LblToplamMesai.Text = "00";
            // 
            // DtSaatBit
            // 
            this.DtSaatBit.CustomFormat = "HH:mm";
            this.DtSaatBit.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtSaatBit.Location = new System.Drawing.Point(351, 95);
            this.DtSaatBit.Name = "DtSaatBit";
            this.DtSaatBit.ShowUpDown = true;
            this.DtSaatBit.Size = new System.Drawing.Size(84, 21);
            this.DtSaatBit.TabIndex = 536;
            this.DtSaatBit.Value = new System.DateTime(2018, 1, 12, 0, 0, 0, 0);
            // 
            // DtSaatBas
            // 
            this.DtSaatBas.CustomFormat = "HH:mm";
            this.DtSaatBas.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtSaatBas.Location = new System.Drawing.Point(351, 64);
            this.DtSaatBas.Name = "DtSaatBas";
            this.DtSaatBas.ShowUpDown = true;
            this.DtSaatBas.Size = new System.Drawing.Size(84, 21);
            this.DtSaatBas.TabIndex = 534;
            this.DtSaatBas.Value = new System.DateTime(2018, 1, 12, 0, 0, 0, 0);
            // 
            // TxtMesaiNedeni
            // 
            this.TxtMesaiNedeni.Location = new System.Drawing.Point(230, 34);
            this.TxtMesaiNedeni.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtMesaiNedeni.Name = "TxtMesaiNedeni";
            this.TxtMesaiNedeni.Size = new System.Drawing.Size(594, 21);
            this.TxtMesaiNedeni.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 162);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(206, 15);
            this.label9.TabIndex = 25;
            this.label9.Text = "TOPLAM HAK EDİLEN İZİN SÜRESİ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 66);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "MESAİ BAŞLANGIÇ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 37);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "FAZLA ÇALIŞMA NEDENİ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(83, 128);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "TOPLAM MESAİ SAATİ:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(142, 97);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "MESAİ BİTİŞ:";
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.Image")));
            this.BtnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnKaydet.Location = new System.Drawing.Point(13, 425);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(130, 51);
            this.BtnKaydet.TabIndex = 448;
            this.BtnKaydet.Text = "     KAYDET";
            this.BtnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKaydet.UseVisualStyleBackColor = false;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // CmbTalepEdenPersonel
            // 
            this.CmbTalepEdenPersonel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTalepEdenPersonel.FormattingEnabled = true;
            this.CmbTalepEdenPersonel.Location = new System.Drawing.Point(229, 30);
            this.CmbTalepEdenPersonel.Name = "CmbTalepEdenPersonel";
            this.CmbTalepEdenPersonel.Size = new System.Drawing.Size(254, 23);
            this.CmbTalepEdenPersonel.TabIndex = 25;
            this.CmbTalepEdenPersonel.SelectedIndexChanged += new System.EventHandler(this.CmbTalepEdenPersonel_SelectedIndexChanged);
            // 
            // FrmFazlaCalisma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 493);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmFazlaCalisma";
            this.Text = "FrmFazlaCalisma";
            this.Load += new System.EventHandler(this.FrmFazlaCalisma_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label LblMasrafYeri;
        private System.Windows.Forms.Label LblMasrafYeriNo;
        private System.Windows.Forms.Label LblUnvani;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtMesaiNedeni;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LblToplamIzin;
        private System.Windows.Forms.Label LblToplamMesai;
        private System.Windows.Forms.DateTimePicker DtSaatBit;
        private System.Windows.Forms.DateTimePicker DtSaatBas;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Button BtnSureHesapla;
        private System.Windows.Forms.DateTimePicker LblTarihBas;
        private System.Windows.Forms.DateTimePicker LblTarihBit;
        private System.Windows.Forms.ComboBox CmbTalepEdenPersonel;
    }
}