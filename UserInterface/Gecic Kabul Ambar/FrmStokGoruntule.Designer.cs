
namespace UserInterface.Depo
{
    partial class FrmStokGoruntule
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgDepoBilgileri = new ADGV.AdvancedDataGridView();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgMalzemeBilgisi = new System.Windows.Forms.DataGridView();
            this.TxtStokNo = new System.Windows.Forms.TextBox();
            this.LblToplamMiktar = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblBirimFiyat = new System.Windows.Forms.Label();
            this.BirimFiyat = new System.Windows.Forms.Label();
            this.TxtBarkod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepoBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeBilgisi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1551, 27);
            this.panel1.TabIndex = 46;
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
            this.groupBox1.Controls.Add(this.DtgDepoBilgileri);
            this.groupBox1.Location = new System.Drawing.Point(18, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1533, 642);
            this.groupBox1.TabIndex = 312;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DEPO BİLGİLERİ";
            // 
            // DtgDepoBilgileri
            // 
            this.DtgDepoBilgileri.AllowUserToAddRows = false;
            this.DtgDepoBilgileri.AllowUserToDeleteRows = false;
            this.DtgDepoBilgileri.AllowUserToOrderColumns = true;
            this.DtgDepoBilgileri.AutoGenerateContextFilters = true;
            this.DtgDepoBilgileri.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgDepoBilgileri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDepoBilgileri.DateWithTime = false;
            this.DtgDepoBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgDepoBilgileri.Location = new System.Drawing.Point(3, 16);
            this.DtgDepoBilgileri.Name = "DtgDepoBilgileri";
            this.DtgDepoBilgileri.ReadOnly = true;
            this.DtgDepoBilgileri.Size = new System.Drawing.Size(1527, 623);
            this.DtgDepoBilgileri.TabIndex = 0;
            this.DtgDepoBilgileri.TimeFilter = false;
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(144, 832);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(27, 20);
            this.TxtTop.TabIndex = 314;
            this.TxtTop.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(22, 832);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 313;
            this.label1.Text = "Toplam Kayıt:";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSearch.Location = new System.Drawing.Point(312, 39);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(95, 34);
            this.BtnSearch.TabIndex = 317;
            this.BtnSearch.Text = "SORGULA";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(60, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 319;
            this.label4.Text = "Stok No:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgMalzemeBilgisi);
            this.groupBox2.Location = new System.Drawing.Point(16, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1039, 90);
            this.groupBox2.TabIndex = 318;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MALZEME BİLGİLERİ";
            // 
            // DtgMalzemeBilgisi
            // 
            this.DtgMalzemeBilgisi.AllowUserToAddRows = false;
            this.DtgMalzemeBilgisi.AllowUserToDeleteRows = false;
            this.DtgMalzemeBilgisi.AllowUserToOrderColumns = true;
            this.DtgMalzemeBilgisi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgMalzemeBilgisi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgMalzemeBilgisi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgMalzemeBilgisi.Location = new System.Drawing.Point(3, 16);
            this.DtgMalzemeBilgisi.Name = "DtgMalzemeBilgisi";
            this.DtgMalzemeBilgisi.ReadOnly = true;
            this.DtgMalzemeBilgisi.Size = new System.Drawing.Size(1033, 71);
            this.DtgMalzemeBilgisi.TabIndex = 321;
            this.DtgMalzemeBilgisi.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgMalzemeBilgisi_CellMouseClick);
            // 
            // TxtStokNo
            // 
            this.TxtStokNo.Location = new System.Drawing.Point(124, 47);
            this.TxtStokNo.Name = "TxtStokNo";
            this.TxtStokNo.Size = new System.Drawing.Size(182, 20);
            this.TxtStokNo.TabIndex = 320;
            // 
            // LblToplamMiktar
            // 
            this.LblToplamMiktar.AutoSize = true;
            this.LblToplamMiktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblToplamMiktar.Location = new System.Drawing.Point(402, 832);
            this.LblToplamMiktar.Name = "LblToplamMiktar";
            this.LblToplamMiktar.Size = new System.Drawing.Size(27, 20);
            this.LblToplamMiktar.TabIndex = 322;
            this.LblToplamMiktar.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(270, 832);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 321;
            this.label3.Text = "Toplam Miktar:";
            // 
            // LblBirimFiyat
            // 
            this.LblBirimFiyat.AutoSize = true;
            this.LblBirimFiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblBirimFiyat.Location = new System.Drawing.Point(1061, 151);
            this.LblBirimFiyat.Name = "LblBirimFiyat";
            this.LblBirimFiyat.Size = new System.Drawing.Size(125, 15);
            this.LblBirimFiyat.TabIndex = 323;
            this.LblBirimFiyat.Text = "Malzeme Birim Fiyatı:";
            // 
            // BirimFiyat
            // 
            this.BirimFiyat.AutoSize = true;
            this.BirimFiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BirimFiyat.Location = new System.Drawing.Point(1192, 151);
            this.BirimFiyat.Name = "BirimFiyat";
            this.BirimFiyat.Size = new System.Drawing.Size(24, 15);
            this.BirimFiyat.TabIndex = 324;
            this.BirimFiyat.Text = "₺ 0";
            // 
            // TxtBarkod
            // 
            this.TxtBarkod.Location = new System.Drawing.Point(482, 47);
            this.TxtBarkod.Name = "TxtBarkod";
            this.TxtBarkod.Size = new System.Drawing.Size(303, 20);
            this.TxtBarkod.TabIndex = 326;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(420, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 325;
            this.label2.Text = "Barkod:";
            // 
            // FrmStokGoruntule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 867);
            this.Controls.Add(this.TxtBarkod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BirimFiyat);
            this.Controls.Add(this.LblBirimFiyat);
            this.Controls.Add(this.LblToplamMiktar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtStokNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmStokGoruntule";
            this.Text = "FrmStokGoruntule";
            this.Load += new System.EventHandler(this.FrmStokGoruntule_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepoBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeBilgisi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgDepoBilgileri;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtStokNo;
        private System.Windows.Forms.DataGridView DtgMalzemeBilgisi;
        private System.Windows.Forms.Label LblToplamMiktar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblBirimFiyat;
        private System.Windows.Forms.Label BirimFiyat;
        private System.Windows.Forms.TextBox TxtBarkod;
        private System.Windows.Forms.Label label2;
    }
}