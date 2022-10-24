
namespace UserInterface.IdariIsler
{
    partial class FrmGiysiTalep
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.LblMasrafYeri = new System.Windows.Forms.Label();
            this.LblMasrafYeriNo = new System.Windows.Forms.Label();
            this.LblUnvani = new System.Windows.Forms.Label();
            this.LblKisiAdet = new System.Windows.Forms.Label();
            this.LblSiparisNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblAdSoyad = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.CmbMalzemeKategorisi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgList = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbTalepEdenPersonel = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtStok = new System.Windows.Forms.TextBox();
            this.BtnEkle = new System.Windows.Forms.Button();
            this.TxtMiktar = new System.Windows.Forms.TextBox();
            this.CmbTanim = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.MalzemeKategorisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TalepEdenPersonel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MalzemeTanimi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StokNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TalepEdenMiktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birimm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1285, 27);
            this.panel1.TabIndex = 319;
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
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.LblMasrafYeri);
            this.groupBox8.Controls.Add(this.LblMasrafYeriNo);
            this.groupBox8.Controls.Add(this.LblUnvani);
            this.groupBox8.Controls.Add(this.LblKisiAdet);
            this.groupBox8.Controls.Add(this.LblSiparisNo);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.LblAdSoyad);
            this.groupBox8.Controls.Add(this.label52);
            this.groupBox8.Controls.Add(this.label63);
            this.groupBox8.Controls.Add(this.label56);
            this.groupBox8.Controls.Add(this.label58);
            this.groupBox8.Controls.Add(this.label59);
            this.groupBox8.Location = new System.Drawing.Point(12, 46);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(742, 187);
            this.groupBox8.TabIndex = 320;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "TALEP EDEN PERSONEL";
            // 
            // LblMasrafYeri
            // 
            this.LblMasrafYeri.AutoSize = true;
            this.LblMasrafYeri.Location = new System.Drawing.Point(164, 135);
            this.LblMasrafYeri.Name = "LblMasrafYeri";
            this.LblMasrafYeri.Size = new System.Drawing.Size(19, 13);
            this.LblMasrafYeri.TabIndex = 24;
            this.LblMasrafYeri.Text = "00";
            // 
            // LblMasrafYeriNo
            // 
            this.LblMasrafYeriNo.AutoSize = true;
            this.LblMasrafYeriNo.Location = new System.Drawing.Point(164, 108);
            this.LblMasrafYeriNo.Name = "LblMasrafYeriNo";
            this.LblMasrafYeriNo.Size = new System.Drawing.Size(19, 13);
            this.LblMasrafYeriNo.TabIndex = 23;
            this.LblMasrafYeriNo.Text = "00";
            // 
            // LblUnvani
            // 
            this.LblUnvani.AutoSize = true;
            this.LblUnvani.Location = new System.Drawing.Point(164, 81);
            this.LblUnvani.Name = "LblUnvani";
            this.LblUnvani.Size = new System.Drawing.Size(19, 13);
            this.LblUnvani.TabIndex = 22;
            this.LblUnvani.Text = "00";
            // 
            // LblKisiAdet
            // 
            this.LblKisiAdet.AutoSize = true;
            this.LblKisiAdet.Location = new System.Drawing.Point(164, 160);
            this.LblKisiAdet.Name = "LblKisiAdet";
            this.LblKisiAdet.Size = new System.Drawing.Size(19, 13);
            this.LblKisiAdet.TabIndex = 327;
            this.LblKisiAdet.Text = "00";
            // 
            // LblSiparisNo
            // 
            this.LblSiparisNo.AutoSize = true;
            this.LblSiparisNo.Location = new System.Drawing.Point(164, 54);
            this.LblSiparisNo.Name = "LblSiparisNo";
            this.LblSiparisNo.Size = new System.Drawing.Size(19, 13);
            this.LblSiparisNo.TabIndex = 21;
            this.LblSiparisNo.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 326;
            this.label4.Text = "KİŞİ SAYISI:";
            // 
            // LblAdSoyad
            // 
            this.LblAdSoyad.AutoSize = true;
            this.LblAdSoyad.Location = new System.Drawing.Point(164, 27);
            this.LblAdSoyad.Name = "LblAdSoyad";
            this.LblAdSoyad.Size = new System.Drawing.Size(19, 13);
            this.LblAdSoyad.TabIndex = 16;
            this.LblAdSoyad.Text = "00";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(110, 81);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(51, 13);
            this.label52.TabIndex = 19;
            this.label52.Text = "ÜNVANI:";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(87, 54);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(71, 13);
            this.label63.TabIndex = 11;
            this.label63.Text = "SİPARİŞ NO:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(93, 27);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(65, 13);
            this.label56.TabIndex = 9;
            this.label56.Text = "AD SOYAD:";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(33, 135);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(125, 13);
            this.label58.TabIndex = 5;
            this.label58.Text = "MASRAF YERİ/BÖLÜM:";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(57, 108);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(101, 13);
            this.label59.TabIndex = 1;
            this.label59.Text = "MASRAF YERİ NO:";
            // 
            // CmbMalzemeKategorisi
            // 
            this.CmbMalzemeKategorisi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMalzemeKategorisi.FormattingEnabled = true;
            this.CmbMalzemeKategorisi.Location = new System.Drawing.Point(167, 29);
            this.CmbMalzemeKategorisi.Name = "CmbMalzemeKategorisi";
            this.CmbMalzemeKategorisi.Size = new System.Drawing.Size(274, 21);
            this.CmbMalzemeKategorisi.TabIndex = 319;
            this.CmbMalzemeKategorisi.SelectedIndexChanged += new System.EventHandler(this.CmbMalzemeKategorisi_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 318;
            this.label3.Text = "MALZEME KATEGORİSİ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgList);
            this.groupBox1.Location = new System.Drawing.Point(12, 508);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1056, 246);
            this.groupBox1.TabIndex = 323;
            this.groupBox1.TabStop = false;
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MalzemeKategorisi,
            this.TalepEdenPersonel,
            this.MalzemeTanimi,
            this.StokNo,
            this.TalepEdenMiktar,
            this.Birimm,
            this.Remove});
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(3, 16);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.Size = new System.Drawing.Size(1050, 227);
            this.DtgList.TabIndex = 0;
            this.DtgList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgList_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.CmbMalzemeKategorisi);
            this.groupBox2.Controls.Add(this.CmbTalepEdenPersonel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(742, 97);
            this.groupBox2.TabIndex = 328;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 334;
            this.label1.Text = "TALEP EDİLEN PERSONEL:";
            // 
            // CmbTalepEdenPersonel
            // 
            this.CmbTalepEdenPersonel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTalepEdenPersonel.FormattingEnabled = true;
            this.CmbTalepEdenPersonel.Location = new System.Drawing.Point(167, 56);
            this.CmbTalepEdenPersonel.Name = "CmbTalepEdenPersonel";
            this.CmbTalepEdenPersonel.Size = new System.Drawing.Size(274, 21);
            this.CmbTalepEdenPersonel.TabIndex = 335;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtStok);
            this.groupBox3.Controls.Add(this.BtnEkle);
            this.groupBox3.Controls.Add(this.TxtMiktar);
            this.groupBox3.Controls.Add(this.CmbTanim);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(12, 342);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(742, 160);
            this.groupBox3.TabIndex = 329;
            this.groupBox3.TabStop = false;
            // 
            // TxtStok
            // 
            this.TxtStok.Location = new System.Drawing.Point(167, 59);
            this.TxtStok.Name = "TxtStok";
            this.TxtStok.Size = new System.Drawing.Size(274, 20);
            this.TxtStok.TabIndex = 334;
            // 
            // BtnEkle
            // 
            this.BtnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnEkle.Location = new System.Drawing.Point(167, 114);
            this.BtnEkle.Name = "BtnEkle";
            this.BtnEkle.Size = new System.Drawing.Size(81, 28);
            this.BtnEkle.TabIndex = 333;
            this.BtnEkle.Text = "EKLE";
            this.BtnEkle.UseVisualStyleBackColor = true;
            this.BtnEkle.Click += new System.EventHandler(this.BtnEkle_Click);
            // 
            // TxtMiktar
            // 
            this.TxtMiktar.Location = new System.Drawing.Point(167, 85);
            this.TxtMiktar.Name = "TxtMiktar";
            this.TxtMiktar.Size = new System.Drawing.Size(105, 20);
            this.TxtMiktar.TabIndex = 328;
            // 
            // CmbTanim
            // 
            this.CmbTanim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTanim.FormattingEnabled = true;
            this.CmbTanim.Location = new System.Drawing.Point(167, 31);
            this.CmbTanim.Name = "CmbTanim";
            this.CmbTanim.Size = new System.Drawing.Size(274, 21);
            this.CmbTanim.TabIndex = 319;
            this.CmbTanim.SelectedIndexChanged += new System.EventHandler(this.CmbTanim_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 318;
            this.label7.Text = "MALZEME TANIMI:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(100, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 321;
            this.label9.Text = "STOK NO:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 13);
            this.label10.TabIndex = 324;
            this.label10.Text = "TALEP EDİLEN MİKTAR:";
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(15, 760);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(113, 36);
            this.BtnKaydet.TabIndex = 334;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // MalzemeKategorisi
            // 
            this.MalzemeKategorisi.HeaderText = "MALZEME KATEGORİSİ";
            this.MalzemeKategorisi.Name = "MalzemeKategorisi";
            this.MalzemeKategorisi.ReadOnly = true;
            this.MalzemeKategorisi.Width = 139;
            // 
            // TalepEdenPersonel
            // 
            this.TalepEdenPersonel.HeaderText = "TALEP EDİLEN PERSONEL";
            this.TalepEdenPersonel.Name = "TalepEdenPersonel";
            this.TalepEdenPersonel.ReadOnly = true;
            this.TalepEdenPersonel.Width = 154;
            // 
            // MalzemeTanimi
            // 
            this.MalzemeTanimi.HeaderText = "MALZEME TANIMI";
            this.MalzemeTanimi.Name = "MalzemeTanimi";
            this.MalzemeTanimi.ReadOnly = true;
            this.MalzemeTanimi.Width = 114;
            // 
            // StokNo
            // 
            this.StokNo.HeaderText = "STOK NO";
            this.StokNo.Name = "StokNo";
            this.StokNo.ReadOnly = true;
            this.StokNo.Width = 74;
            // 
            // TalepEdenMiktar
            // 
            this.TalepEdenMiktar.HeaderText = "TALEP EDİLEN MİKTAR";
            this.TalepEdenMiktar.Name = "TalepEdenMiktar";
            this.TalepEdenMiktar.ReadOnly = true;
            this.TalepEdenMiktar.Width = 139;
            // 
            // Birimm
            // 
            this.Birimm.HeaderText = "BİRİM";
            this.Birimm.Name = "Birimm";
            this.Birimm.ReadOnly = true;
            this.Birimm.Width = 62;
            // 
            // Remove
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Red;
            this.Remove.DefaultCellStyle = dataGridViewCellStyle1;
            this.Remove.HeaderText = "KALDIR";
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.Text = "X";
            this.Remove.ToolTipText = "X";
            this.Remove.UseColumnTextForButtonValue = true;
            this.Remove.Width = 52;
            // 
            // FrmGiysiTalep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 808);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.panel1);
            this.Name = "FrmGiysiTalep";
            this.Text = "FrmGiysiTalep";
            this.Load += new System.EventHandler(this.FrmGiysiTalep_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label LblMasrafYeri;
        private System.Windows.Forms.Label LblMasrafYeriNo;
        private System.Windows.Forms.Label LblUnvani;
        private System.Windows.Forms.Label LblSiparisNo;
        private System.Windows.Forms.Label LblAdSoyad;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.ComboBox CmbMalzemeKategorisi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DtgList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblKisiAdet;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnEkle;
        private System.Windows.Forms.TextBox TxtMiktar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbTalepEdenPersonel;
        private System.Windows.Forms.TextBox TxtStok;
        private System.Windows.Forms.ComboBox CmbTanim;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.DataGridViewTextBoxColumn MalzemeKategorisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TalepEdenPersonel;
        private System.Windows.Forms.DataGridViewTextBoxColumn MalzemeTanimi;
        private System.Windows.Forms.DataGridViewTextBoxColumn StokNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TalepEdenMiktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birimm;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
    }
}