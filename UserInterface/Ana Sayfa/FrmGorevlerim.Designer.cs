
namespace UserInterface.Ana_Sayfa
{
    partial class FrmGorevlerim
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgGorevlerim = new ADGV.AdvancedDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnDosyaEkle = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtIstenenGorev = new System.Windows.Forms.RichTextBox();
            this.TxtAciklama = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.TxtGenelTop = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DtgYoneticiGorevlerim = new ADGV.AdvancedDataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTop3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgIsAkisGorev = new ADGV.AdvancedDataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.görevAtaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.göreveGitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yönlendirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.durumGüncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arızaKapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgGorevlerim)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgYoneticiGorevlerim)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgIsAkisGorev)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1387, 780);
            this.tabControl1.TabIndex = 314;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.TxtTop);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1379, 754);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "AÇIK ARIZA GÖREVLERİM";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(6, 701);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 342;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(106, 701);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 343;
            this.TxtTop.Text = "00";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgGorevlerim);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(941, 682);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GÖREV LİSTESİ";
            // 
            // DtgGorevlerim
            // 
            this.DtgGorevlerim.AllowUserToAddRows = false;
            this.DtgGorevlerim.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgGorevlerim.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgGorevlerim.AutoGenerateContextFilters = true;
            this.DtgGorevlerim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgGorevlerim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgGorevlerim.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgGorevlerim.DateWithTime = false;
            this.DtgGorevlerim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgGorevlerim.Location = new System.Drawing.Point(3, 16);
            this.DtgGorevlerim.MultiSelect = false;
            this.DtgGorevlerim.Name = "DtgGorevlerim";
            this.DtgGorevlerim.ReadOnly = true;
            this.DtgGorevlerim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgGorevlerim.Size = new System.Drawing.Size(935, 663);
            this.DtgGorevlerim.TabIndex = 3;
            this.DtgGorevlerim.TimeFilter = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnDosyaEkle);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.TxtIstenenGorev);
            this.tabPage2.Controls.Add(this.TxtAciklama);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.BtnKaydet);
            this.tabPage2.Controls.Add(this.TxtGenelTop);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1379, 754);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "YÖNETİCİ GÖREVLERİM";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BtnDosyaEkle
            // 
            this.BtnDosyaEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDosyaEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnDosyaEkle.Location = new System.Drawing.Point(812, 694);
            this.BtnDosyaEkle.Name = "BtnDosyaEkle";
            this.BtnDosyaEkle.Size = new System.Drawing.Size(122, 38);
            this.BtnDosyaEkle.TabIndex = 451;
            this.BtnDosyaEkle.Text = "DOSYA EKLE";
            this.BtnDosyaEkle.UseVisualStyleBackColor = true;
            this.BtnDosyaEkle.Click += new System.EventHandler(this.BtnDosyaEkle_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.webBrowser1);
            this.groupBox4.Location = new System.Drawing.Point(812, 508);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(558, 183);
            this.groupBox4.TabIndex = 450;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ekler";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(552, 164);
            this.webBrowser1.TabIndex = 449;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(44, 516);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 447;
            this.label2.Text = "İstenen Görev:";
            // 
            // TxtIstenenGorev
            // 
            this.TxtIstenenGorev.Location = new System.Drawing.Point(135, 515);
            this.TxtIstenenGorev.Name = "TxtIstenenGorev";
            this.TxtIstenenGorev.Size = new System.Drawing.Size(671, 82);
            this.TxtIstenenGorev.TabIndex = 446;
            this.TxtIstenenGorev.Text = "";
            // 
            // TxtAciklama
            // 
            this.TxtAciklama.Location = new System.Drawing.Point(135, 609);
            this.TxtAciklama.Name = "TxtAciklama";
            this.TxtAciklama.Size = new System.Drawing.Size(671, 82);
            this.TxtAciklama.TabIndex = 445;
            this.TxtAciklama.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(7, 610);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 15);
            this.label4.TabIndex = 444;
            this.label4.Text = "Yapılan İşlem/Sonuç:";
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(135, 700);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(122, 38);
            this.BtnKaydet.TabIndex = 443;
            this.BtnKaydet.Text = "GÖREVİ BİTİR";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // TxtGenelTop
            // 
            this.TxtGenelTop.AutoSize = true;
            this.TxtGenelTop.Location = new System.Drawing.Point(108, 482);
            this.TxtGenelTop.Name = "TxtGenelTop";
            this.TxtGenelTop.Size = new System.Drawing.Size(19, 13);
            this.TxtGenelTop.TabIndex = 442;
            this.TxtGenelTop.Text = "00";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label17.Location = new System.Drawing.Point(8, 480);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 15);
            this.label17.TabIndex = 441;
            this.label17.Text = "Toplam Kayıt:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DtgYoneticiGorevlerim);
            this.groupBox3.Location = new System.Drawing.Point(6, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1367, 453);
            this.groupBox3.TabIndex = 440;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ATANAN GÖREVLER";
            // 
            // DtgYoneticiGorevlerim
            // 
            this.DtgYoneticiGorevlerim.AllowUserToAddRows = false;
            this.DtgYoneticiGorevlerim.AllowUserToDeleteRows = false;
            this.DtgYoneticiGorevlerim.AutoGenerateContextFilters = true;
            this.DtgYoneticiGorevlerim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgYoneticiGorevlerim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgYoneticiGorevlerim.DateWithTime = false;
            this.DtgYoneticiGorevlerim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgYoneticiGorevlerim.Location = new System.Drawing.Point(3, 16);
            this.DtgYoneticiGorevlerim.Name = "DtgYoneticiGorevlerim";
            this.DtgYoneticiGorevlerim.ReadOnly = true;
            this.DtgYoneticiGorevlerim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgYoneticiGorevlerim.Size = new System.Drawing.Size(1361, 434);
            this.DtgYoneticiGorevlerim.TabIndex = 0;
            this.DtgYoneticiGorevlerim.TimeFilter = false;
            this.DtgYoneticiGorevlerim.SortStringChanged += new System.EventHandler(this.DtgYoneticiGorevlerim_SortStringChanged);
            this.DtgYoneticiGorevlerim.FilterStringChanged += new System.EventHandler(this.DtgYoneticiGorevlerim_FilterStringChanged);
            this.DtgYoneticiGorevlerim.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridView1_CellMouseClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.TxtTop3);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1379, 754);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "İŞ AKIŞI GÖREVLERİM";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(13, 712);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 344;
            this.label1.Text = "Toplam Kayıt:";
            // 
            // TxtTop3
            // 
            this.TxtTop3.AutoSize = true;
            this.TxtTop3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop3.Location = new System.Drawing.Point(113, 712);
            this.TxtTop3.Name = "TxtTop3";
            this.TxtTop3.Size = new System.Drawing.Size(21, 15);
            this.TxtTop3.TabIndex = 345;
            this.TxtTop3.Text = "00";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgIsAkisGorev);
            this.groupBox2.Location = new System.Drawing.Point(13, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1097, 682);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GÖREV LİSTESİ";
            // 
            // DtgIsAkisGorev
            // 
            this.DtgIsAkisGorev.AllowUserToAddRows = false;
            this.DtgIsAkisGorev.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgIsAkisGorev.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgIsAkisGorev.AutoGenerateContextFilters = true;
            this.DtgIsAkisGorev.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgIsAkisGorev.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgIsAkisGorev.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgIsAkisGorev.DateWithTime = false;
            this.DtgIsAkisGorev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgIsAkisGorev.Location = new System.Drawing.Point(3, 16);
            this.DtgIsAkisGorev.MultiSelect = false;
            this.DtgIsAkisGorev.Name = "DtgIsAkisGorev";
            this.DtgIsAkisGorev.ReadOnly = true;
            this.DtgIsAkisGorev.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgIsAkisGorev.Size = new System.Drawing.Size(1091, 663);
            this.DtgIsAkisGorev.TabIndex = 3;
            this.DtgIsAkisGorev.TimeFilter = false;
            this.DtgIsAkisGorev.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellContentClick);
            this.DtgIsAkisGorev.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridView1_CellMouseClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.görevAtaToolStripMenuItem,
            this.göreveGitToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(130, 48);
            // 
            // görevAtaToolStripMenuItem
            // 
            this.görevAtaToolStripMenuItem.Name = "görevAtaToolStripMenuItem";
            this.görevAtaToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.görevAtaToolStripMenuItem.Text = "Görev Ata";
            // 
            // göreveGitToolStripMenuItem
            // 
            this.göreveGitToolStripMenuItem.Name = "göreveGitToolStripMenuItem";
            this.göreveGitToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.göreveGitToolStripMenuItem.Text = "Göreve Git";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yönlendirToolStripMenuItem,
            this.durumGüncelleToolStripMenuItem,
            this.arızaKapatToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 70);
            // 
            // yönlendirToolStripMenuItem
            // 
            this.yönlendirToolStripMenuItem.Name = "yönlendirToolStripMenuItem";
            this.yönlendirToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.yönlendirToolStripMenuItem.Text = "Sipariş Oluştur";
            // 
            // durumGüncelleToolStripMenuItem
            // 
            this.durumGüncelleToolStripMenuItem.Name = "durumGüncelleToolStripMenuItem";
            this.durumGüncelleToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.durumGüncelleToolStripMenuItem.Text = "Durum Güncelle";
            // 
            // arızaKapatToolStripMenuItem
            // 
            this.arızaKapatToolStripMenuItem.Name = "arızaKapatToolStripMenuItem";
            this.arızaKapatToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.arızaKapatToolStripMenuItem.Text = "Arıza Kapat";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmGorevlerim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 804);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGorevlerim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GÖREVLERİM";
            this.Load += new System.EventHandler(this.FrmGorevlerim_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgGorevlerim)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgYoneticiGorevlerim)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgIsAkisGorev)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgGorevlerim;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yönlendirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem durumGüncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arızaKapatToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox2;
        private ADGV.AdvancedDataGridView DtgIsAkisGorev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TxtTop3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem görevAtaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem göreveGitToolStripMenuItem;
        private System.Windows.Forms.Label TxtGenelTop;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox3;
        private ADGV.AdvancedDataGridView DtgYoneticiGorevlerim;
        private System.Windows.Forms.RichTextBox TxtAciklama;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox TxtIstenenGorev;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button BtnDosyaEkle;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}