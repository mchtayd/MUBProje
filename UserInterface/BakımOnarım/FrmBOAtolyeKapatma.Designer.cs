
namespace UserInterface.BakımOnarım
{
    partial class FrmBOAtolyeKapatma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBOAtolyeKapatma));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgAtolye = new System.Windows.Forms.DataGridView();
            this.label22 = new System.Windows.Forms.Label();
            this.TxtIcSiparisNo = new System.Windows.Forms.TextBox();
            this.BtnBul = new System.Windows.Forms.Button();
            this.LblDurumAcik = new System.Windows.Forms.Label();
            this.LblDurumKapali = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtBildirimNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtProje = new System.Windows.Forms.TextBox();
            this.TxtScrmNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtBolgeAdi = new System.Windows.Forms.TextBox();
            this.TxtKategori = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LblIslemAdimiKapali = new System.Windows.Forms.Label();
            this.LblIslemAdimiAcik = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtGarantiDurumuUst = new System.Windows.Forms.TextBox();
            this.TxtStokNoUst = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtSeriNoUst = new System.Windows.Forms.TextBox();
            this.TxtTanimUst = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.DtgIslemKayitlari = new System.Windows.Forms.DataGridView();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.DtgMalzemeler = new ADGV.AdvancedDataGridView();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.DtgDepoHareketleri = new System.Windows.Forms.DataGridView();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dataBinder2 = new System.Windows.Forms.BindingSource(this.components);
            this.BtnDosyaEkle = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgAtolye)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgIslemKayitlari)).BeginInit();
            this.tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeler)).BeginInit();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepoHareketleri)).BeginInit();
            this.tabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1451, 27);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgAtolye);
            this.groupBox1.Location = new System.Drawing.Point(12, 291);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1086, 106);
            this.groupBox1.TabIndex = 323;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GENEL BİLGİLER";
            // 
            // DtgAtolye
            // 
            this.DtgAtolye.AllowUserToAddRows = false;
            this.DtgAtolye.AllowUserToDeleteRows = false;
            this.DtgAtolye.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgAtolye.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgAtolye.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgAtolye.Location = new System.Drawing.Point(3, 16);
            this.DtgAtolye.Name = "DtgAtolye";
            this.DtgAtolye.ReadOnly = true;
            this.DtgAtolye.Size = new System.Drawing.Size(1080, 87);
            this.DtgAtolye.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(54, 47);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 13);
            this.label22.TabIndex = 322;
            this.label22.Text = "KİMLİK:";
            // 
            // TxtIcSiparisNo
            // 
            this.TxtIcSiparisNo.Location = new System.Drawing.Point(105, 44);
            this.TxtIcSiparisNo.Name = "TxtIcSiparisNo";
            this.TxtIcSiparisNo.Size = new System.Drawing.Size(185, 20);
            this.TxtIcSiparisNo.TabIndex = 320;
            // 
            // BtnBul
            // 
            this.BtnBul.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBul.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBul.Location = new System.Drawing.Point(296, 43);
            this.BtnBul.Name = "BtnBul";
            this.BtnBul.Size = new System.Drawing.Size(57, 20);
            this.BtnBul.TabIndex = 321;
            this.BtnBul.Text = "BUL";
            this.BtnBul.UseVisualStyleBackColor = true;
            this.BtnBul.Click += new System.EventHandler(this.BtnBul_Click);
            // 
            // LblDurumAcik
            // 
            this.LblDurumAcik.AutoSize = true;
            this.LblDurumAcik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.LblDurumAcik.ForeColor = System.Drawing.Color.Black;
            this.LblDurumAcik.Location = new System.Drawing.Point(143, 147);
            this.LblDurumAcik.Name = "LblDurumAcik";
            this.LblDurumAcik.Size = new System.Drawing.Size(31, 13);
            this.LblDurumAcik.TabIndex = 325;
            this.LblDurumAcik.Text = "AÇIK";
            this.LblDurumAcik.Visible = false;
            // 
            // LblDurumKapali
            // 
            this.LblDurumKapali.AutoSize = true;
            this.LblDurumKapali.BackColor = System.Drawing.Color.Red;
            this.LblDurumKapali.ForeColor = System.Drawing.Color.White;
            this.LblDurumKapali.Location = new System.Drawing.Point(143, 147);
            this.LblDurumKapali.Name = "LblDurumKapali";
            this.LblDurumKapali.Size = new System.Drawing.Size(44, 13);
            this.LblDurumKapali.TabIndex = 324;
            this.LblDurumKapali.Text = "KAPALI";
            this.LblDurumKapali.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtBildirimNo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.TxtProje);
            this.groupBox2.Controls.Add(this.TxtScrmNo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.TxtBolgeAdi);
            this.groupBox2.Controls.Add(this.TxtKategori);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(409, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 200);
            this.groupBox2.TabIndex = 329;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "REFERANS ARIZA BİLGİLERİ";
            // 
            // TxtBildirimNo
            // 
            this.TxtBildirimNo.Location = new System.Drawing.Point(89, 39);
            this.TxtBildirimNo.Name = "TxtBildirimNo";
            this.TxtBildirimNo.Size = new System.Drawing.Size(223, 20);
            this.TxtBildirimNo.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 58;
            this.label7.Text = "Proje:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Bildirim No:";
            // 
            // TxtProje
            // 
            this.TxtProje.Location = new System.Drawing.Point(89, 147);
            this.TxtProje.Name = "TxtProje";
            this.TxtProje.Size = new System.Drawing.Size(223, 20);
            this.TxtProje.TabIndex = 57;
            // 
            // TxtScrmNo
            // 
            this.TxtScrmNo.Location = new System.Drawing.Point(89, 66);
            this.TxtScrmNo.Name = "TxtScrmNo";
            this.TxtScrmNo.Size = new System.Drawing.Size(223, 20);
            this.TxtScrmNo.TabIndex = 51;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 56;
            this.label9.Text = "Bölge Adı:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 52;
            this.label10.Text = "Crm No:";
            // 
            // TxtBolgeAdi
            // 
            this.TxtBolgeAdi.Location = new System.Drawing.Point(89, 120);
            this.TxtBolgeAdi.Name = "TxtBolgeAdi";
            this.TxtBolgeAdi.Size = new System.Drawing.Size(223, 20);
            this.TxtBolgeAdi.TabIndex = 55;
            // 
            // TxtKategori
            // 
            this.TxtKategori.Location = new System.Drawing.Point(89, 93);
            this.TxtKategori.Name = "TxtKategori";
            this.TxtKategori.Size = new System.Drawing.Size(223, 20);
            this.TxtKategori.TabIndex = 53;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 54;
            this.label11.Text = "Kategori:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LblIslemAdimiKapali);
            this.groupBox3.Controls.Add(this.LblIslemAdimiAcik);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.LblDurumAcik);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.LblDurumKapali);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.TxtGarantiDurumuUst);
            this.groupBox3.Controls.Add(this.TxtStokNoUst);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.TxtSeriNoUst);
            this.groupBox3.Controls.Add(this.TxtTanimUst);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 85);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(391, 200);
            this.groupBox3.TabIndex = 328;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MALZEMENİN KULLANILDIĞI ÜST TAKIM BİLGİLERİ";
            // 
            // LblIslemAdimiKapali
            // 
            this.LblIslemAdimiKapali.AutoSize = true;
            this.LblIslemAdimiKapali.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.LblIslemAdimiKapali.ForeColor = System.Drawing.Color.Black;
            this.LblIslemAdimiKapali.Location = new System.Drawing.Point(143, 171);
            this.LblIslemAdimiKapali.Name = "LblIslemAdimiKapali";
            this.LblIslemAdimiKapali.Size = new System.Drawing.Size(19, 13);
            this.LblIslemAdimiKapali.TabIndex = 327;
            this.LblIslemAdimiKapali.Text = "00";
            this.LblIslemAdimiKapali.Visible = false;
            // 
            // LblIslemAdimiAcik
            // 
            this.LblIslemAdimiAcik.AutoSize = true;
            this.LblIslemAdimiAcik.BackColor = System.Drawing.Color.Red;
            this.LblIslemAdimiAcik.ForeColor = System.Drawing.Color.White;
            this.LblIslemAdimiAcik.Location = new System.Drawing.Point(143, 171);
            this.LblIslemAdimiAcik.Name = "LblIslemAdimiAcik";
            this.LblIslemAdimiAcik.Size = new System.Drawing.Size(19, 13);
            this.LblIslemAdimiAcik.TabIndex = 326;
            this.LblIslemAdimiAcik.Text = "00";
            this.LblIslemAdimiAcik.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 147);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 13);
            this.label12.TabIndex = 325;
            this.label12.Text = "Üst Takım Bildirim Durumu:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(35, 171);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(101, 13);
            this.label27.TabIndex = 58;
            this.label27.Text = "Mevcut İşlem Adımı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Stok No:";
            // 
            // TxtGarantiDurumuUst
            // 
            this.TxtGarantiDurumuUst.Location = new System.Drawing.Point(146, 120);
            this.TxtGarantiDurumuUst.Name = "TxtGarantiDurumuUst";
            this.TxtGarantiDurumuUst.Size = new System.Drawing.Size(223, 20);
            this.TxtGarantiDurumuUst.TabIndex = 57;
            // 
            // TxtStokNoUst
            // 
            this.TxtStokNoUst.Location = new System.Drawing.Point(146, 39);
            this.TxtStokNoUst.Name = "TxtStokNoUst";
            this.TxtStokNoUst.Size = new System.Drawing.Size(223, 20);
            this.TxtStokNoUst.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Garanti Durumu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Tanım:";
            // 
            // TxtSeriNoUst
            // 
            this.TxtSeriNoUst.Location = new System.Drawing.Point(146, 93);
            this.TxtSeriNoUst.Name = "TxtSeriNoUst";
            this.TxtSeriNoUst.Size = new System.Drawing.Size(223, 20);
            this.TxtSeriNoUst.TabIndex = 55;
            // 
            // TxtTanimUst
            // 
            this.TxtTanimUst.Location = new System.Drawing.Point(146, 66);
            this.TxtTanimUst.Name = "TxtTanimUst";
            this.TxtTanimUst.Size = new System.Drawing.Size(223, 20);
            this.TxtTanimUst.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Seri No:";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage8);
            this.tabControl3.Controls.Add(this.tabPage9);
            this.tabControl3.Controls.Add(this.tabPage10);
            this.tabControl3.Controls.Add(this.tabPage11);
            this.tabControl3.Location = new System.Drawing.Point(12, 412);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(1429, 249);
            this.tabControl3.TabIndex = 439;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.DtgIslemKayitlari);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1421, 223);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "İŞLEM KAYITLARI";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // DtgIslemKayitlari
            // 
            this.DtgIslemKayitlari.AllowUserToAddRows = false;
            this.DtgIslemKayitlari.AllowUserToDeleteRows = false;
            this.DtgIslemKayitlari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgIslemKayitlari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgIslemKayitlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgIslemKayitlari.Location = new System.Drawing.Point(3, 3);
            this.DtgIslemKayitlari.Name = "DtgIslemKayitlari";
            this.DtgIslemKayitlari.ReadOnly = true;
            this.DtgIslemKayitlari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgIslemKayitlari.Size = new System.Drawing.Size(1415, 217);
            this.DtgIslemKayitlari.TabIndex = 2;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.DtgMalzemeler);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(1421, 223);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "CİHAZ MALZEME DURUMU";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // DtgMalzemeler
            // 
            this.DtgMalzemeler.AllowUserToAddRows = false;
            this.DtgMalzemeler.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgMalzemeler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgMalzemeler.AutoGenerateContextFilters = true;
            this.DtgMalzemeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgMalzemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgMalzemeler.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgMalzemeler.DateWithTime = false;
            this.DtgMalzemeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgMalzemeler.Location = new System.Drawing.Point(3, 3);
            this.DtgMalzemeler.MultiSelect = false;
            this.DtgMalzemeler.Name = "DtgMalzemeler";
            this.DtgMalzemeler.ReadOnly = true;
            this.DtgMalzemeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgMalzemeler.Size = new System.Drawing.Size(1415, 217);
            this.DtgMalzemeler.TabIndex = 3;
            this.DtgMalzemeler.TimeFilter = false;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.DtgDepoHareketleri);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(1421, 223);
            this.tabPage10.TabIndex = 2;
            this.tabPage10.Text = "DEPO HAREKETLERİ";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // DtgDepoHareketleri
            // 
            this.DtgDepoHareketleri.AllowUserToAddRows = false;
            this.DtgDepoHareketleri.AllowUserToDeleteRows = false;
            this.DtgDepoHareketleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDepoHareketleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgDepoHareketleri.Location = new System.Drawing.Point(3, 3);
            this.DtgDepoHareketleri.Name = "DtgDepoHareketleri";
            this.DtgDepoHareketleri.Size = new System.Drawing.Size(1415, 217);
            this.DtgDepoHareketleri.TabIndex = 344;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.webBrowser1);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(1421, 223);
            this.tabPage11.TabIndex = 3;
            this.tabPage11.Text = "İŞLEM ADIM DURUM VE SÜRELERİ";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(2, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(784, 214);
            this.webBrowser1.TabIndex = 1;
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(16, 667);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(124, 37);
            this.BtnKaydet.TabIndex = 440;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(751, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 326;
            this.label13.Text = "ÖNEMLİ NOT:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(751, 107);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(698, 91);
            this.label14.TabIndex = 441;
            this.label14.Text = resources.GetString("label14.Text");
            // 
            // BtnDosyaEkle
            // 
            this.BtnDosyaEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDosyaEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnDosyaEkle.Location = new System.Drawing.Point(146, 667);
            this.BtnDosyaEkle.Name = "BtnDosyaEkle";
            this.BtnDosyaEkle.Size = new System.Drawing.Size(124, 37);
            this.BtnDosyaEkle.TabIndex = 442;
            this.BtnDosyaEkle.Text = "DOSYA EKLE";
            this.BtnDosyaEkle.UseVisualStyleBackColor = true;
            this.BtnDosyaEkle.Click += new System.EventHandler(this.BtnDosyaEkle_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmBOAtolyeKapatma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 745);
            this.Controls.Add(this.BtnDosyaEkle);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.tabControl3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.TxtIcSiparisNo);
            this.Controls.Add(this.BtnBul);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBOAtolyeKapatma";
            this.Text = "FrmBOAtolyeKapatma";
            this.Load += new System.EventHandler(this.FrmBOAtolyeKapatma_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgAtolye)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgIslemKayitlari)).EndInit();
            this.tabPage9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeler)).EndInit();
            this.tabPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepoHareketleri)).EndInit();
            this.tabPage11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DtgAtolye;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox TxtIcSiparisNo;
        private System.Windows.Forms.Button BtnBul;
        private System.Windows.Forms.Label LblDurumAcik;
        private System.Windows.Forms.Label LblDurumKapali;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtBildirimNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtProje;
        private System.Windows.Forms.TextBox TxtScrmNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtBolgeAdi;
        private System.Windows.Forms.TextBox TxtKategori;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtGarantiDurumuUst;
        private System.Windows.Forms.TextBox TxtStokNoUst;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtSeriNoUst;
        private System.Windows.Forms.TextBox TxtTanimUst;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.DataGridView DtgIslemKayitlari;
        private System.Windows.Forms.TabPage tabPage9;
        private ADGV.AdvancedDataGridView DtgMalzemeler;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.DataGridView DtgDepoHareketleri;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.BindingSource dataBinder2;
        private System.Windows.Forms.Label LblIslemAdimiKapali;
        private System.Windows.Forms.Label LblIslemAdimiAcik;
        private System.Windows.Forms.Button BtnDosyaEkle;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}