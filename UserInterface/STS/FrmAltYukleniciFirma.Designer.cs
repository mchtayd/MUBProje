
namespace UserInterface.STS
{
    partial class FrmAltYukleniciFirma
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtTelefon = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtAlanı = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtFirmaAdi = new System.Windows.Forms.TextBox();
            this.TxtFirmaAdres = new System.Windows.Forms.TextBox();
            this.CmbIl = new System.Windows.Forms.ComboBox();
            this.CmbIlce = new System.Windows.Forms.ComboBox();
            this.BtnTemizle = new System.Windows.Forms.Button();
            this.BtnSil = new System.Windows.Forms.Button();
            this.BtnGuncelle = new System.Windows.Forms.Button();
            this.BtnYeniKayit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtPersTel = new System.Windows.Forms.MaskedTextBox();
            this.TxtMail = new System.Windows.Forms.TextBox();
            this.TxtAdSoyad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgAltYuklenici = new ADGV.AdvancedDataGridView();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgAltYuklenici)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1557, 27);
            this.panel1.TabIndex = 304;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.ForeColor = System.Drawing.Color.DarkRed;
            this.button5.Location = new System.Drawing.Point(12, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(35, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(112, 893);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 318;
            this.TxtTop.Text = "00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(12, 893);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 15);
            this.label10.TabIndex = 317;
            this.label10.Text = "Toplam Kayıt:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtTelefon);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.TxtAlanı);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.TxtFirmaAdi);
            this.groupBox3.Controls.Add(this.TxtFirmaAdres);
            this.groupBox3.Controls.Add(this.CmbIl);
            this.groupBox3.Controls.Add(this.CmbIlce);
            this.groupBox3.Location = new System.Drawing.Point(15, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(622, 209);
            this.groupBox3.TabIndex = 316;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FİRMA BİLGİLERİ";
            // 
            // TxtTelefon
            // 
            this.TxtTelefon.Location = new System.Drawing.Point(104, 142);
            this.TxtTelefon.Mask = "(999) 000-0000";
            this.TxtTelefon.Name = "TxtTelefon";
            this.TxtTelefon.Size = new System.Drawing.Size(196, 20);
            this.TxtTelefon.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(36, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 48;
            this.label1.Text = "Firma Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(19, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 49;
            this.label2.Text = "Firma Adresi:";
            // 
            // TxtAlanı
            // 
            this.TxtAlanı.Location = new System.Drawing.Point(104, 169);
            this.TxtAlanı.Name = "TxtAlanı";
            this.TxtAlanı.Size = new System.Drawing.Size(457, 20);
            this.TxtAlanı.TabIndex = 82;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(82, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 15);
            this.label3.TabIndex = 50;
            this.label3.Text = "İl:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(23, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 81;
            this.label9.Text = "Faliyet Alanı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(69, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 15);
            this.label4.TabIndex = 51;
            this.label4.Text = "İlçe:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(47, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 52;
            this.label5.Text = "Telefon:";
            // 
            // TxtFirmaAdi
            // 
            this.TxtFirmaAdi.Location = new System.Drawing.Point(104, 28);
            this.TxtFirmaAdi.Name = "TxtFirmaAdi";
            this.TxtFirmaAdi.Size = new System.Drawing.Size(170, 20);
            this.TxtFirmaAdi.TabIndex = 54;
            // 
            // TxtFirmaAdres
            // 
            this.TxtFirmaAdres.Location = new System.Drawing.Point(104, 55);
            this.TxtFirmaAdres.Name = "TxtFirmaAdres";
            this.TxtFirmaAdres.Size = new System.Drawing.Size(457, 20);
            this.TxtFirmaAdres.TabIndex = 55;
            // 
            // CmbIl
            // 
            this.CmbIl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbIl.FormattingEnabled = true;
            this.CmbIl.Location = new System.Drawing.Point(104, 82);
            this.CmbIl.Name = "CmbIl";
            this.CmbIl.Size = new System.Drawing.Size(196, 23);
            this.CmbIl.TabIndex = 56;
            this.CmbIl.SelectedValueChanged += new System.EventHandler(this.CmbIl_SelectedValueChanged);
            // 
            // CmbIlce
            // 
            this.CmbIlce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIlce.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbIlce.FormattingEnabled = true;
            this.CmbIlce.Location = new System.Drawing.Point(104, 112);
            this.CmbIlce.Name = "CmbIlce";
            this.CmbIlce.Size = new System.Drawing.Size(196, 23);
            this.CmbIlce.TabIndex = 57;
            // 
            // BtnTemizle
            // 
            this.BtnTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTemizle.Location = new System.Drawing.Point(438, 267);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(111, 35);
            this.BtnTemizle.TabIndex = 315;
            this.BtnTemizle.Text = "TEMİZLE";
            this.BtnTemizle.UseVisualStyleBackColor = true;
            this.BtnTemizle.Click += new System.EventHandler(this.BtnTemizle_Click);
            // 
            // BtnSil
            // 
            this.BtnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSil.Location = new System.Drawing.Point(321, 267);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(111, 35);
            this.BtnSil.TabIndex = 314;
            this.BtnSil.Text = "KAYDI SİL";
            this.BtnSil.UseVisualStyleBackColor = true;
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Location = new System.Drawing.Point(204, 267);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(111, 35);
            this.BtnGuncelle.TabIndex = 313;
            this.BtnGuncelle.Text = "GÜNCELLE";
            this.BtnGuncelle.UseVisualStyleBackColor = true;
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // BtnYeniKayit
            // 
            this.BtnYeniKayit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnYeniKayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnYeniKayit.Location = new System.Drawing.Point(87, 267);
            this.BtnYeniKayit.Name = "BtnYeniKayit";
            this.BtnYeniKayit.Size = new System.Drawing.Size(111, 35);
            this.BtnYeniKayit.TabIndex = 312;
            this.BtnYeniKayit.Text = "YENİ KAYIT";
            this.BtnYeniKayit.UseVisualStyleBackColor = true;
            this.BtnYeniKayit.Click += new System.EventHandler(this.BtnYeniKayit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtPersTel);
            this.groupBox2.Controls.Add(this.TxtMail);
            this.groupBox2.Controls.Add(this.TxtAdSoyad);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(663, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 156);
            this.groupBox2.TabIndex = 311;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FİRMA İLGİLİ PERSONEL BİLGİLERİ";
            // 
            // TxtPersTel
            // 
            this.TxtPersTel.Location = new System.Drawing.Point(99, 54);
            this.TxtPersTel.Mask = "(999) 000-0000";
            this.TxtPersTel.Name = "TxtPersTel";
            this.TxtPersTel.Size = new System.Drawing.Size(170, 20);
            this.TxtPersTel.TabIndex = 305;
            // 
            // TxtMail
            // 
            this.TxtMail.Location = new System.Drawing.Point(99, 80);
            this.TxtMail.Name = "TxtMail";
            this.TxtMail.Size = new System.Drawing.Size(170, 20);
            this.TxtMail.TabIndex = 61;
            // 
            // TxtAdSoyad
            // 
            this.TxtAdSoyad.Location = new System.Drawing.Point(99, 28);
            this.TxtAdSoyad.Name = "TxtAdSoyad";
            this.TxtAdSoyad.Size = new System.Drawing.Size(170, 20);
            this.TxtAdSoyad.TabIndex = 59;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(55, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 53;
            this.label6.Text = "Mail:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(38, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 15);
            this.label7.TabIndex = 52;
            this.label7.Text = "Telefon:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(28, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 15);
            this.label8.TabIndex = 51;
            this.label8.Text = "Ad Soyad:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgAltYuklenici);
            this.groupBox1.Location = new System.Drawing.Point(12, 324);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1533, 558);
            this.groupBox1.TabIndex = 310;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ALT YÜKLENİCİİ FİRMA LİSTESİ";
            // 
            // DtgAltYuklenici
            // 
            this.DtgAltYuklenici.AllowUserToAddRows = false;
            this.DtgAltYuklenici.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgAltYuklenici.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgAltYuklenici.AutoGenerateContextFilters = true;
            this.DtgAltYuklenici.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgAltYuklenici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgAltYuklenici.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgAltYuklenici.DateWithTime = false;
            this.DtgAltYuklenici.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgAltYuklenici.Location = new System.Drawing.Point(3, 16);
            this.DtgAltYuklenici.Name = "DtgAltYuklenici";
            this.DtgAltYuklenici.ReadOnly = true;
            this.DtgAltYuklenici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgAltYuklenici.Size = new System.Drawing.Size(1527, 539);
            this.DtgAltYuklenici.TabIndex = 1;
            this.DtgAltYuklenici.TimeFilter = false;
            this.DtgAltYuklenici.SortStringChanged += new System.EventHandler(this.DtgAltYuklenici_SortStringChanged);
            this.DtgAltYuklenici.FilterStringChanged += new System.EventHandler(this.DtgAltYuklenici_FilterStringChanged);
            this.DtgAltYuklenici.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgAltYuklenici_CellMouseClick);
            // 
            // FrmAltYukleniciFirma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 924);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.BtnTemizle);
            this.Controls.Add(this.BtnSil);
            this.Controls.Add(this.BtnGuncelle);
            this.Controls.Add(this.BtnYeniKayit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAltYukleniciFirma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alt Yüklenici Firma Bilgileri";
            this.Load += new System.EventHandler(this.FrmAltYukleniciFirma_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgAltYuklenici)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.MaskedTextBox TxtTelefon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtAlanı;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtFirmaAdi;
        private System.Windows.Forms.TextBox TxtFirmaAdres;
        private System.Windows.Forms.ComboBox CmbIl;
        private System.Windows.Forms.ComboBox CmbIlce;
        private System.Windows.Forms.Button BtnTemizle;
        private System.Windows.Forms.Button BtnSil;
        private System.Windows.Forms.Button BtnGuncelle;
        private System.Windows.Forms.Button BtnYeniKayit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox TxtPersTel;
        private System.Windows.Forms.TextBox TxtMail;
        private System.Windows.Forms.TextBox TxtAdSoyad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgAltYuklenici;
        private System.Windows.Forms.BindingSource dataBinder;
        public System.Windows.Forms.Button button5;
    }
}