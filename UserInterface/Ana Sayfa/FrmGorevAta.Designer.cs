
namespace UserInterface.Ana_Sayfa
{
    partial class FrmGorevAta
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
            this.CmbPersoneller = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtAciklama = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DtgBitis = new System.Windows.Forms.DateTimePicker();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.LblTop = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LblTop2 = new System.Windows.Forms.Label();
            this.DtgListTamamlananlar = new ADGV.AdvancedDataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dataBinder2 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtYapilanIslem = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtGorevinKonusu = new System.Windows.Forms.RichTextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.BtnDosyaEkle = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgListTamamlananlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbPersoneller
            // 
            this.CmbPersoneller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPersoneller.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbPersoneller.FormattingEnabled = true;
            this.CmbPersoneller.Location = new System.Drawing.Point(241, 563);
            this.CmbPersoneller.Name = "CmbPersoneller";
            this.CmbPersoneller.Size = new System.Drawing.Size(280, 23);
            this.CmbPersoneller.TabIndex = 428;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(88, 566);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 15);
            this.label10.TabIndex = 427;
            this.label10.Text = "Görev Atanacak Personel:";
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(241, 795);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(122, 38);
            this.BtnKaydet.TabIndex = 432;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(97, 622);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 15);
            this.label4.TabIndex = 433;
            this.label4.Text = "Atanan Görevin Konusu:";
            // 
            // TxtAciklama
            // 
            this.TxtAciklama.Location = new System.Drawing.Point(241, 619);
            this.TxtAciklama.Name = "TxtAciklama";
            this.TxtAciklama.Size = new System.Drawing.Size(693, 82);
            this.TxtAciklama.TabIndex = 434;
            this.TxtAciklama.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 592);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 15);
            this.label1.TabIndex = 435;
            this.label1.Text = "Görevin Tamamlanması İstenen Tarih:";
            // 
            // DtgBitis
            // 
            this.DtgBitis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtgBitis.Location = new System.Drawing.Point(241, 592);
            this.DtgBitis.Name = "DtgBitis";
            this.DtgBitis.Size = new System.Drawing.Size(139, 21);
            this.DtgBitis.TabIndex = 436;
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AutoGenerateContextFilters = true;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.DateWithTime = false;
            this.DtgList.Location = new System.Drawing.Point(3, 3);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgList.Size = new System.Drawing.Size(1389, 332);
            this.DtgList.TabIndex = 0;
            this.DtgList.TimeFilter = false;
            this.DtgList.SortStringChanged += new System.EventHandler(this.DtgList_SortStringChanged);
            this.DtgList.FilterStringChanged += new System.EventHandler(this.DtgList_FilterStringChanged);
            this.DtgList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgList_CellMouseClick);
            // 
            // LblTop
            // 
            this.LblTop.AutoSize = true;
            this.LblTop.Location = new System.Drawing.Point(106, 346);
            this.LblTop.Name = "LblTop";
            this.LblTop.Size = new System.Drawing.Size(21, 15);
            this.LblTop.TabIndex = 439;
            this.LblTop.Text = "00";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label17.Location = new System.Drawing.Point(6, 344);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 15);
            this.label17.TabIndex = 438;
            this.label17.Text = "Toplam Kayıt:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1406, 400);
            this.tabControl1.TabIndex = 440;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DtgList);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.LblTop);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1398, 372);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ATANAN GÖREVLER";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LblTop2);
            this.tabPage2.Controls.Add(this.DtgListTamamlananlar);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1398, 372);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TAMAMLANAN GÖREVLER";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LblTop2
            // 
            this.LblTop2.AutoSize = true;
            this.LblTop2.Location = new System.Drawing.Point(103, 344);
            this.LblTop2.Name = "LblTop2";
            this.LblTop2.Size = new System.Drawing.Size(21, 15);
            this.LblTop2.TabIndex = 441;
            this.LblTop2.Text = "00";
            // 
            // DtgListTamamlananlar
            // 
            this.DtgListTamamlananlar.AllowUserToAddRows = false;
            this.DtgListTamamlananlar.AllowUserToDeleteRows = false;
            this.DtgListTamamlananlar.AutoGenerateContextFilters = true;
            this.DtgListTamamlananlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgListTamamlananlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgListTamamlananlar.DateWithTime = false;
            this.DtgListTamamlananlar.Location = new System.Drawing.Point(3, 3);
            this.DtgListTamamlananlar.Name = "DtgListTamamlananlar";
            this.DtgListTamamlananlar.ReadOnly = true;
            this.DtgListTamamlananlar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgListTamamlananlar.Size = new System.Drawing.Size(1389, 332);
            this.DtgListTamamlananlar.TabIndex = 1;
            this.DtgListTamamlananlar.TimeFilter = false;
            this.DtgListTamamlananlar.SortStringChanged += new System.EventHandler(this.DtgListTamamlananlar_SortStringChanged);
            this.DtgListTamamlananlar.FilterStringChanged += new System.EventHandler(this.DtgListTamamlananlar_FilterStringChanged);
            this.DtgListTamamlananlar.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgListTamamlananlar_CellMouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(3, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 440;
            this.label3.Text = "Toplam Kayıt:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtYapilanIslem);
            this.groupBox2.Location = new System.Drawing.Point(719, 414);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(697, 141);
            this.groupBox2.TabIndex = 444;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "YAPILAN GÖREV";
            // 
            // TxtYapilanIslem
            // 
            this.TxtYapilanIslem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtYapilanIslem.Location = new System.Drawing.Point(3, 17);
            this.TxtYapilanIslem.Name = "TxtYapilanIslem";
            this.TxtYapilanIslem.Size = new System.Drawing.Size(691, 121);
            this.TxtYapilanIslem.TabIndex = 435;
            this.TxtYapilanIslem.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtGorevinKonusu);
            this.groupBox1.Location = new System.Drawing.Point(16, 414);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(697, 141);
            this.groupBox1.TabIndex = 443;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İSTENEN GÖREV";
            // 
            // TxtGorevinKonusu
            // 
            this.TxtGorevinKonusu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGorevinKonusu.Location = new System.Drawing.Point(3, 17);
            this.TxtGorevinKonusu.Name = "TxtGorevinKonusu";
            this.TxtGorevinKonusu.Size = new System.Drawing.Size(691, 121);
            this.TxtGorevinKonusu.TabIndex = 435;
            this.TxtGorevinKonusu.Text = "";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(241, 707);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(693, 82);
            this.webBrowser1.TabIndex = 445;
            // 
            // BtnDosyaEkle
            // 
            this.BtnDosyaEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDosyaEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnDosyaEkle.Location = new System.Drawing.Point(113, 707);
            this.BtnDosyaEkle.Name = "BtnDosyaEkle";
            this.BtnDosyaEkle.Size = new System.Drawing.Size(122, 38);
            this.BtnDosyaEkle.TabIndex = 446;
            this.BtnDosyaEkle.Text = "DOSYA EKLE";
            this.BtnDosyaEkle.UseVisualStyleBackColor = true;
            this.BtnDosyaEkle.Click += new System.EventHandler(this.BtnDosyaEkle_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmGorevAta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 869);
            this.Controls.Add(this.BtnDosyaEkle);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.DtgBitis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtAciklama);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.CmbPersoneller);
            this.Controls.Add(this.label10);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGorevAta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GÖREV ATA";
            this.Load += new System.EventHandler(this.FrmGorevAta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgListTamamlananlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbPersoneller;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox TxtAciklama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtgBitis;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.Label LblTop;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label LblTop2;
        private System.Windows.Forms.Label label3;
        private ADGV.AdvancedDataGridView DtgListTamamlananlar;
        private System.Windows.Forms.BindingSource dataBinder2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox TxtYapilanIslem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox TxtGorevinKonusu;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button BtnDosyaEkle;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}