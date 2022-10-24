
namespace UserInterface.Depo
{
    partial class FrmMalzemeKayitDestekDepo
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
            this.BtnStokAl = new System.Windows.Forms.Button();
            this.TxtBirim = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtTanim = new System.Windows.Forms.TextBox();
            this.CmbStokNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.BtnGuncelle = new System.Windows.Forms.Button();
            this.BtnTemizle = new System.Windows.Forms.Button();
            this.BtnSil = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbMalzemeTuru = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
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
            this.panel1.TabIndex = 304;
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
            this.BtnCancel.TabIndex = 19;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnStokAl
            // 
            this.BtnStokAl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnStokAl.Location = new System.Drawing.Point(361, 101);
            this.BtnStokAl.Name = "BtnStokAl";
            this.BtnStokAl.Size = new System.Drawing.Size(89, 26);
            this.BtnStokAl.TabIndex = 311;
            this.BtnStokAl.Text = "STOK NO AL";
            this.BtnStokAl.UseVisualStyleBackColor = true;
            this.BtnStokAl.Click += new System.EventHandler(this.BtnStokAl_Click);
            // 
            // TxtBirim
            // 
            this.TxtBirim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtBirim.Location = new System.Drawing.Point(141, 163);
            this.TxtBirim.Name = "TxtBirim";
            this.TxtBirim.Size = new System.Drawing.Size(205, 21);
            this.TxtBirim.TabIndex = 309;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 310;
            this.label4.Text = "MALZEME BİRİM:";
            // 
            // TxtTanim
            // 
            this.TxtTanim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTanim.Location = new System.Drawing.Point(141, 134);
            this.TxtTanim.Name = "TxtTanim";
            this.TxtTanim.Size = new System.Drawing.Size(362, 21);
            this.TxtTanim.TabIndex = 308;
            // 
            // CmbStokNo
            // 
            this.CmbStokNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbStokNo.FormattingEnabled = true;
            this.CmbStokNo.Location = new System.Drawing.Point(141, 103);
            this.CmbStokNo.Name = "CmbStokNo";
            this.CmbStokNo.Size = new System.Drawing.Size(205, 23);
            this.CmbStokNo.TabIndex = 306;
            this.CmbStokNo.SelectedIndexChanged += new System.EventHandler(this.CmbStokNo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 307;
            this.label2.Text = "MALZEME TANIM:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 305;
            this.label1.Text = "MALZEME STOK NO:";
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(46, 230);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(113, 53);
            this.BtnKaydet.TabIndex = 312;
            this.BtnKaydet.Text = "YENİ KAYIT";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Location = new System.Drawing.Point(177, 230);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(113, 53);
            this.BtnGuncelle.TabIndex = 313;
            this.BtnGuncelle.Text = "GÜNCELLE";
            this.BtnGuncelle.UseVisualStyleBackColor = true;
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // BtnTemizle
            // 
            this.BtnTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTemizle.Location = new System.Drawing.Point(439, 230);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(113, 53);
            this.BtnTemizle.TabIndex = 315;
            this.BtnTemizle.Text = "İÇERİĞİ TEMİZLE";
            this.BtnTemizle.UseVisualStyleBackColor = true;
            this.BtnTemizle.Click += new System.EventHandler(this.BtnTemizle_Click);
            // 
            // BtnSil
            // 
            this.BtnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSil.Location = new System.Drawing.Point(308, 230);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(113, 53);
            this.BtnSil.TabIndex = 314;
            this.BtnSil.Text = "SİL";
            this.BtnSil.UseVisualStyleBackColor = true;
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 316;
            this.label3.Text = "MALZEME TÜRÜ:";
            // 
            // CmbMalzemeTuru
            // 
            this.CmbMalzemeTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMalzemeTuru.FormattingEnabled = true;
            this.CmbMalzemeTuru.Location = new System.Drawing.Point(141, 74);
            this.CmbMalzemeTuru.Name = "CmbMalzemeTuru";
            this.CmbMalzemeTuru.Size = new System.Drawing.Size(205, 21);
            this.CmbMalzemeTuru.TabIndex = 317;
            this.CmbMalzemeTuru.SelectedIndexChanged += new System.EventHandler(this.CmbMalzemeTuru_SelectedIndexChanged);
            // 
            // FrmMalzemeKayitDestekDepo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 924);
            this.Controls.Add(this.CmbMalzemeTuru);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.BtnGuncelle);
            this.Controls.Add(this.BtnTemizle);
            this.Controls.Add(this.BtnSil);
            this.Controls.Add(this.BtnStokAl);
            this.Controls.Add(this.TxtBirim);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtTanim);
            this.Controls.Add(this.CmbStokNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMalzemeKayitDestekDepo";
            this.Text = "FrmMalzemeKayitDestekDepo";
            this.Load += new System.EventHandler(this.FrmMalzemeKayitDestekDepo_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnStokAl;
        private System.Windows.Forms.TextBox TxtBirim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtTanim;
        private System.Windows.Forms.ComboBox CmbStokNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Button BtnGuncelle;
        private System.Windows.Forms.Button BtnTemizle;
        private System.Windows.Forms.Button BtnSil;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbMalzemeTuru;
    }
}