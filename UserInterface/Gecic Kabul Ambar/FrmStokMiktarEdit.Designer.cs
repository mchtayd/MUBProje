namespace UserInterface.Gecic_Kabul_Ambar
{
    partial class FrmStokMiktarEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStokMiktarEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtMiktar = new System.Windows.Forms.TextBox();
            this.TxtMalzemeYeri = new System.Windows.Forms.ComboBox();
            this.CmbAdres = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.CmbDepoNo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnSil = new System.Windows.Forms.Button();
            this.BtnGuncelle = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtSokulenTanim = new System.Windows.Forms.TextBox();
            this.CmbStokNo = new System.Windows.Forms.ComboBox();
            this.TxtSeriNo = new System.Windows.Forms.TextBox();
            this.TxtLotNo = new System.Windows.Forms.TextBox();
            this.TxtRev = new System.Windows.Forms.TextBox();
            this.DtgTarih = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtAciklama = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.CmbRezerveDurum = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtAbf = new System.Windows.Forms.TextBox();
            this.LblAbf = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(58, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stok No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(67, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tanım:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(63, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Miktar:";
            // 
            // TxtMiktar
            // 
            this.TxtMiktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtMiktar.Location = new System.Drawing.Point(117, 183);
            this.TxtMiktar.Name = "TxtMiktar";
            this.TxtMiktar.Size = new System.Drawing.Size(107, 21);
            this.TxtMiktar.TabIndex = 9;
            this.TxtMiktar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMiktar_KeyPress);
            // 
            // TxtMalzemeYeri
            // 
            this.TxtMalzemeYeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtMalzemeYeri.FormattingEnabled = true;
            this.TxtMalzemeYeri.Location = new System.Drawing.Point(117, 266);
            this.TxtMalzemeYeri.Name = "TxtMalzemeYeri";
            this.TxtMalzemeYeri.Size = new System.Drawing.Size(224, 23);
            this.TxtMalzemeYeri.TabIndex = 147;
            // 
            // CmbAdres
            // 
            this.CmbAdres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbAdres.Location = new System.Drawing.Point(117, 239);
            this.CmbAdres.Name = "CmbAdres";
            this.CmbAdres.Size = new System.Drawing.Size(224, 21);
            this.CmbAdres.TabIndex = 146;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(30, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 15);
            this.label9.TabIndex = 144;
            this.label9.Text = "Depo Adresi:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(21, 269);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 15);
            this.label10.TabIndex = 143;
            this.label10.Text = "Malzeme Yeri:";
            // 
            // CmbDepoNo
            // 
            this.CmbDepoNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbDepoNo.FormattingEnabled = true;
            this.CmbDepoNo.Location = new System.Drawing.Point(117, 210);
            this.CmbDepoNo.Name = "CmbDepoNo";
            this.CmbDepoNo.Size = new System.Drawing.Size(224, 23);
            this.CmbDepoNo.TabIndex = 142;
            this.CmbDepoNo.SelectedIndexChanged += new System.EventHandler(this.CmbDepoNo_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(48, 212);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 15);
            this.label11.TabIndex = 141;
            this.label11.Text = "Depo No:";
            // 
            // BtnSil
            // 
            this.BtnSil.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSil.Image = ((System.Drawing.Image)(resources.GetObject("BtnSil.Image")));
            this.BtnSil.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSil.Location = new System.Drawing.Point(253, 458);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(130, 51);
            this.BtnSil.TabIndex = 513;
            this.BtnSil.Text = "   KAYIT SİL";
            this.BtnSil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSil.UseVisualStyleBackColor = false;
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Image = ((System.Drawing.Image)(resources.GetObject("BtnGuncelle.Image")));
            this.BtnGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuncelle.Location = new System.Drawing.Point(117, 458);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(130, 51);
            this.BtnGuncelle.TabIndex = 512;
            this.BtnGuncelle.Text = "  GÜNCELLE";
            this.BtnGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuncelle.UseVisualStyleBackColor = false;
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(66, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 515;
            this.label6.Text = "Lot No:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(61, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 15);
            this.label7.TabIndex = 514;
            this.label7.Text = "Seri No:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(53, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 518;
            this.label5.Text = "Revizyon:";
            // 
            // TxtSokulenTanim
            // 
            this.TxtSokulenTanim.Location = new System.Drawing.Point(117, 51);
            this.TxtSokulenTanim.Name = "TxtSokulenTanim";
            this.TxtSokulenTanim.Size = new System.Drawing.Size(302, 20);
            this.TxtSokulenTanim.TabIndex = 520;
            // 
            // CmbStokNo
            // 
            this.CmbStokNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CmbStokNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbStokNo.FormattingEnabled = true;
            this.CmbStokNo.Location = new System.Drawing.Point(117, 24);
            this.CmbStokNo.Name = "CmbStokNo";
            this.CmbStokNo.Size = new System.Drawing.Size(224, 21);
            this.CmbStokNo.TabIndex = 519;
            this.CmbStokNo.SelectedIndexChanged += new System.EventHandler(this.CmbStokNo_SelectedIndexChanged);
            this.CmbStokNo.TextChanged += new System.EventHandler(this.CmbStokNo_TextChanged);
            // 
            // TxtSeriNo
            // 
            this.TxtSeriNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtSeriNo.Location = new System.Drawing.Point(117, 76);
            this.TxtSeriNo.Name = "TxtSeriNo";
            this.TxtSeriNo.Size = new System.Drawing.Size(224, 21);
            this.TxtSeriNo.TabIndex = 521;
            // 
            // TxtLotNo
            // 
            this.TxtLotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtLotNo.Location = new System.Drawing.Point(117, 103);
            this.TxtLotNo.Name = "TxtLotNo";
            this.TxtLotNo.Size = new System.Drawing.Size(224, 21);
            this.TxtLotNo.TabIndex = 522;
            // 
            // TxtRev
            // 
            this.TxtRev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtRev.Location = new System.Drawing.Point(118, 130);
            this.TxtRev.Name = "TxtRev";
            this.TxtRev.Size = new System.Drawing.Size(224, 21);
            this.TxtRev.TabIndex = 523;
            // 
            // DtgTarih
            // 
            this.DtgTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtgTarih.Location = new System.Drawing.Point(118, 157);
            this.DtgTarih.Name = "DtgTarih";
            this.DtgTarih.Size = new System.Drawing.Size(106, 20);
            this.DtgTarih.TabIndex = 525;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(38, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 524;
            this.label4.Text = "İşlem Tarihi:";
            // 
            // TxtAciklama
            // 
            this.TxtAciklama.Location = new System.Drawing.Point(117, 295);
            this.TxtAciklama.Name = "TxtAciklama";
            this.TxtAciklama.Size = new System.Drawing.Size(302, 86);
            this.TxtAciklama.TabIndex = 527;
            this.TxtAciklama.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(51, 300);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 15);
            this.label14.TabIndex = 526;
            this.label14.Text = "Açıklama:";
            // 
            // CmbRezerveDurum
            // 
            this.CmbRezerveDurum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRezerveDurum.Enabled = false;
            this.CmbRezerveDurum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbRezerveDurum.FormattingEnabled = true;
            this.CmbRezerveDurum.Items.AddRange(new object[] {
            "REZERVE",
            "REZERVE DEĞİL"});
            this.CmbRezerveDurum.Location = new System.Drawing.Point(117, 387);
            this.CmbRezerveDurum.Name = "CmbRezerveDurum";
            this.CmbRezerveDurum.Size = new System.Drawing.Size(224, 23);
            this.CmbRezerveDurum.TabIndex = 529;
            this.CmbRezerveDurum.SelectedIndexChanged += new System.EventHandler(this.CmbRezerveDurum_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(9, 390);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 15);
            this.label8.TabIndex = 528;
            this.label8.Text = "Rezerve Durumu:";
            // 
            // TxtAbf
            // 
            this.TxtAbf.Enabled = false;
            this.TxtAbf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtAbf.Location = new System.Drawing.Point(117, 416);
            this.TxtAbf.Name = "TxtAbf";
            this.TxtAbf.Size = new System.Drawing.Size(107, 21);
            this.TxtAbf.TabIndex = 531;
            // 
            // LblAbf
            // 
            this.LblAbf.AutoSize = true;
            this.LblAbf.Enabled = false;
            this.LblAbf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblAbf.Location = new System.Drawing.Point(66, 419);
            this.LblAbf.Name = "LblAbf";
            this.LblAbf.Size = new System.Drawing.Size(46, 15);
            this.LblAbf.TabIndex = 530;
            this.LblAbf.Text = "Abf No:";
            // 
            // FrmStokMiktarEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 521);
            this.Controls.Add(this.TxtAbf);
            this.Controls.Add(this.LblAbf);
            this.Controls.Add(this.CmbRezerveDurum);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtAciklama);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.DtgTarih);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtRev);
            this.Controls.Add(this.TxtLotNo);
            this.Controls.Add(this.TxtSeriNo);
            this.Controls.Add(this.TxtSokulenTanim);
            this.Controls.Add(this.CmbStokNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnSil);
            this.Controls.Add(this.BtnGuncelle);
            this.Controls.Add(this.TxtMalzemeYeri);
            this.Controls.Add(this.CmbAdres);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CmbDepoNo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TxtMiktar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStokMiktarEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Veri Düzenle";
            this.Load += new System.EventHandler(this.FrmStokMiktarEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtMiktar;
        private System.Windows.Forms.ComboBox TxtMalzemeYeri;
        private System.Windows.Forms.TextBox CmbAdres;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CmbDepoNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BtnSil;
        private System.Windows.Forms.Button BtnGuncelle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtSokulenTanim;
        private System.Windows.Forms.ComboBox CmbStokNo;
        private System.Windows.Forms.TextBox TxtSeriNo;
        private System.Windows.Forms.TextBox TxtLotNo;
        private System.Windows.Forms.TextBox TxtRev;
        private System.Windows.Forms.DateTimePicker DtgTarih;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox TxtAciklama;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox CmbRezerveDurum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtAbf;
        private System.Windows.Forms.Label LblAbf;
    }
}