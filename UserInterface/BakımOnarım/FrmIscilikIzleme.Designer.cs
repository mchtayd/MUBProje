
namespace UserInterface.BakımOnarım
{
    partial class FrmIscilikIzleme
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.TxtTopDestek = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgDestekIscilik = new ADGV.AdvancedDataGridView();
            this.CmbPersoneller = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgDestekIscilikPersonel = new ADGV.AdvancedDataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DtgDestekIscilikArac = new ADGV.AdvancedDataGridView();
            this.LblIscilikPersonel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.advancedDataGridView3 = new ADGV.AdvancedDataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.advancedDataGridView4 = new ADGV.AdvancedDataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.CmbPersoneller2 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dataBinderDestek = new System.Windows.Forms.BindingSource(this.components);
            this.CmbPersoneller3 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.CmbPlaka = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.BtnTemizle = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDestekIscilik)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDestekIscilikPersonel)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDestekIscilikArac)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView3)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinderDestek)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1479, 27);
            this.panel1.TabIndex = 311;
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1455, 853);
            this.tabControl1.TabIndex = 324;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BtnTemizle);
            this.tabPage1.Controls.Add(this.CmbPlaka);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.CmbPersoneller3);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.LblIscilikPersonel);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.TxtTopDestek);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1447, 827);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DESTEK İŞÇİLİK";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.CmbPersoneller);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dateTimePicker2);
            this.tabPage2.Controls.Add(this.dateTimePicker1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1447, 827);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "İŞÇİLİK";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.CmbPersoneller2);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1447, 827);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "PERFORMANS";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // TxtTopDestek
            // 
            this.TxtTopDestek.AutoSize = true;
            this.TxtTopDestek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTopDestek.Location = new System.Drawing.Point(109, 481);
            this.TxtTopDestek.Name = "TxtTopDestek";
            this.TxtTopDestek.Size = new System.Drawing.Size(21, 15);
            this.TxtTopDestek.TabIndex = 324;
            this.TxtTopDestek.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(9, 481);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 323;
            this.label5.Text = "Toplam Kayıt:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgDestekIscilik);
            this.groupBox1.Location = new System.Drawing.Point(9, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1421, 420);
            this.groupBox1.TabIndex = 322;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DESTEK İŞÇİLİK LİSTESİ";
            // 
            // DtgDestekIscilik
            // 
            this.DtgDestekIscilik.AllowUserToAddRows = false;
            this.DtgDestekIscilik.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgDestekIscilik.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DtgDestekIscilik.AutoGenerateContextFilters = true;
            this.DtgDestekIscilik.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgDestekIscilik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDestekIscilik.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgDestekIscilik.DateWithTime = false;
            this.DtgDestekIscilik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgDestekIscilik.Location = new System.Drawing.Point(3, 16);
            this.DtgDestekIscilik.MultiSelect = false;
            this.DtgDestekIscilik.Name = "DtgDestekIscilik";
            this.DtgDestekIscilik.ReadOnly = true;
            this.DtgDestekIscilik.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgDestekIscilik.Size = new System.Drawing.Size(1415, 401);
            this.DtgDestekIscilik.TabIndex = 3;
            this.DtgDestekIscilik.TimeFilter = false;
            this.DtgDestekIscilik.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgDestekIscilik_CellMouseClick);
            // 
            // CmbPersoneller
            // 
            this.CmbPersoneller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPersoneller.FormattingEnabled = true;
            this.CmbPersoneller.Location = new System.Drawing.Point(131, 20);
            this.CmbPersoneller.Name = "CmbPersoneller";
            this.CmbPersoneller.Size = new System.Drawing.Size(300, 21);
            this.CmbPersoneller.TabIndex = 320;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(131, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 43);
            this.button1.TabIndex = 325;
            this.button1.Text = "BUL";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 319;
            this.label1.Text = "PERSONEL:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(131, 74);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(130, 20);
            this.dateTimePicker2.TabIndex = 324;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(131, 48);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(130, 20);
            this.dateTimePicker1.TabIndex = 321;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 323;
            this.label3.Text = "BİTİŞ TARİHİ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 322;
            this.label2.Text = "BAŞLANGIÇ TARİHİ:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgDestekIscilikPersonel);
            this.groupBox2.Location = new System.Drawing.Point(12, 514);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(706, 276);
            this.groupBox2.TabIndex = 323;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "İŞÇİLİK TÜRÜ (PERSONEL)";
            // 
            // DtgDestekIscilikPersonel
            // 
            this.DtgDestekIscilikPersonel.AllowUserToAddRows = false;
            this.DtgDestekIscilikPersonel.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgDestekIscilikPersonel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgDestekIscilikPersonel.AutoGenerateContextFilters = true;
            this.DtgDestekIscilikPersonel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgDestekIscilikPersonel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDestekIscilikPersonel.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgDestekIscilikPersonel.DateWithTime = false;
            this.DtgDestekIscilikPersonel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgDestekIscilikPersonel.Location = new System.Drawing.Point(3, 16);
            this.DtgDestekIscilikPersonel.MultiSelect = false;
            this.DtgDestekIscilikPersonel.Name = "DtgDestekIscilikPersonel";
            this.DtgDestekIscilikPersonel.ReadOnly = true;
            this.DtgDestekIscilikPersonel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgDestekIscilikPersonel.Size = new System.Drawing.Size(700, 257);
            this.DtgDestekIscilikPersonel.TabIndex = 3;
            this.DtgDestekIscilikPersonel.TimeFilter = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DtgDestekIscilikArac);
            this.groupBox3.Location = new System.Drawing.Point(724, 514);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(706, 276);
            this.groupBox3.TabIndex = 324;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "İŞÇİLİK TÜRÜ (ARAÇ)";
            // 
            // DtgDestekIscilikArac
            // 
            this.DtgDestekIscilikArac.AllowUserToAddRows = false;
            this.DtgDestekIscilikArac.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgDestekIscilikArac.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgDestekIscilikArac.AutoGenerateContextFilters = true;
            this.DtgDestekIscilikArac.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgDestekIscilikArac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDestekIscilikArac.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgDestekIscilikArac.DateWithTime = false;
            this.DtgDestekIscilikArac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgDestekIscilikArac.Location = new System.Drawing.Point(3, 16);
            this.DtgDestekIscilikArac.MultiSelect = false;
            this.DtgDestekIscilikArac.Name = "DtgDestekIscilikArac";
            this.DtgDestekIscilikArac.ReadOnly = true;
            this.DtgDestekIscilikArac.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgDestekIscilikArac.Size = new System.Drawing.Size(700, 257);
            this.DtgDestekIscilikArac.TabIndex = 3;
            this.DtgDestekIscilikArac.TimeFilter = false;
            // 
            // LblIscilikPersonel
            // 
            this.LblIscilikPersonel.AutoSize = true;
            this.LblIscilikPersonel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblIscilikPersonel.Location = new System.Drawing.Point(112, 798);
            this.LblIscilikPersonel.Name = "LblIscilikPersonel";
            this.LblIscilikPersonel.Size = new System.Drawing.Size(21, 15);
            this.LblIscilikPersonel.TabIndex = 326;
            this.LblIscilikPersonel.Text = "00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(12, 798);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 15);
            this.label6.TabIndex = 325;
            this.label6.Text = "Toplam Kayıt:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(834, 798);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 15);
            this.label7.TabIndex = 328;
            this.label7.Text = "00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(734, 798);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 15);
            this.label8.TabIndex = 327;
            this.label8.Text = "Toplam Kayıt:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.advancedDataGridView3);
            this.groupBox4.Location = new System.Drawing.Point(6, 149);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(856, 563);
            this.groupBox4.TabIndex = 326;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "İŞÇİLİK LİSTESİ";
            // 
            // advancedDataGridView3
            // 
            this.advancedDataGridView3.AllowUserToAddRows = false;
            this.advancedDataGridView3.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.advancedDataGridView3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.advancedDataGridView3.AutoGenerateContextFilters = true;
            this.advancedDataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.advancedDataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView3.Cursor = System.Windows.Forms.Cursors.Default;
            this.advancedDataGridView3.DateWithTime = false;
            this.advancedDataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView3.Location = new System.Drawing.Point(3, 16);
            this.advancedDataGridView3.MultiSelect = false;
            this.advancedDataGridView3.Name = "advancedDataGridView3";
            this.advancedDataGridView3.ReadOnly = true;
            this.advancedDataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridView3.Size = new System.Drawing.Size(850, 544);
            this.advancedDataGridView3.TabIndex = 3;
            this.advancedDataGridView3.TimeFilter = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(106, 719);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 15);
            this.label9.TabIndex = 328;
            this.label9.Text = "00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(6, 719);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 15);
            this.label10.TabIndex = 327;
            this.label10.Text = "Toplam Kayıt:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.advancedDataGridView4);
            this.groupBox5.Location = new System.Drawing.Point(6, 60);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1435, 724);
            this.groupBox5.TabIndex = 323;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "PERFORMANS TABLOSU";
            // 
            // advancedDataGridView4
            // 
            this.advancedDataGridView4.AllowUserToAddRows = false;
            this.advancedDataGridView4.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.advancedDataGridView4.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.advancedDataGridView4.AutoGenerateContextFilters = true;
            this.advancedDataGridView4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.advancedDataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView4.Cursor = System.Windows.Forms.Cursors.Default;
            this.advancedDataGridView4.DateWithTime = false;
            this.advancedDataGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView4.Location = new System.Drawing.Point(3, 16);
            this.advancedDataGridView4.MultiSelect = false;
            this.advancedDataGridView4.Name = "advancedDataGridView4";
            this.advancedDataGridView4.ReadOnly = true;
            this.advancedDataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridView4.Size = new System.Drawing.Size(1429, 705);
            this.advancedDataGridView4.TabIndex = 3;
            this.advancedDataGridView4.TimeFilter = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(106, 799);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 15);
            this.label11.TabIndex = 330;
            this.label11.Text = "00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(6, 799);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 15);
            this.label12.TabIndex = 329;
            this.label12.Text = "Toplam Kayıt:";
            // 
            // CmbPersoneller2
            // 
            this.CmbPersoneller2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPersoneller2.FormattingEnabled = true;
            this.CmbPersoneller2.Location = new System.Drawing.Point(91, 22);
            this.CmbPersoneller2.Name = "CmbPersoneller2";
            this.CmbPersoneller2.Size = new System.Drawing.Size(300, 21);
            this.CmbPersoneller2.TabIndex = 332;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 331;
            this.label13.Text = "PERSONEL:";
            // 
            // CmbPersoneller3
            // 
            this.CmbPersoneller3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPersoneller3.FormattingEnabled = true;
            this.CmbPersoneller3.Location = new System.Drawing.Point(101, 21);
            this.CmbPersoneller3.Name = "CmbPersoneller3";
            this.CmbPersoneller3.Size = new System.Drawing.Size(300, 21);
            this.CmbPersoneller3.TabIndex = 330;
            this.CmbPersoneller3.SelectedIndexChanged += new System.EventHandler(this.CmbPersoneller3_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(27, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 329;
            this.label14.Text = "PERSONEL:";
            // 
            // CmbPlaka
            // 
            this.CmbPlaka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPlaka.FormattingEnabled = true;
            this.CmbPlaka.Location = new System.Drawing.Point(497, 21);
            this.CmbPlaka.Name = "CmbPlaka";
            this.CmbPlaka.Size = new System.Drawing.Size(156, 21);
            this.CmbPlaka.TabIndex = 332;
            this.CmbPlaka.SelectedIndexChanged += new System.EventHandler(this.CmbPlaka_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(452, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 331;
            this.label15.Text = "ARAÇ:";
            // 
            // BtnTemizle
            // 
            this.BtnTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTemizle.Location = new System.Drawing.Point(706, 20);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(89, 23);
            this.BtnTemizle.TabIndex = 333;
            this.BtnTemizle.Text = "TEMİZLE";
            this.BtnTemizle.UseVisualStyleBackColor = true;
            this.BtnTemizle.Click += new System.EventHandler(this.BtnTemizle_Click);
            // 
            // FrmIscilikIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1479, 902);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmIscilikIzleme";
            this.Text = "FrmIscilikIzleme";
            this.Load += new System.EventHandler(this.FrmIscilikIzleme_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDestekIscilik)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDestekIscilikPersonel)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDestekIscilikArac)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView3)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinderDestek)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ADGV.AdvancedDataGridView DtgDestekIscilikPersonel;
        private System.Windows.Forms.Label TxtTopDestek;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgDestekIscilik;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox CmbPersoneller;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblIscilikPersonel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private ADGV.AdvancedDataGridView DtgDestekIscilikArac;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private ADGV.AdvancedDataGridView advancedDataGridView3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox5;
        private ADGV.AdvancedDataGridView advancedDataGridView4;
        private System.Windows.Forms.ComboBox CmbPersoneller2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.BindingSource dataBinderDestek;
        private System.Windows.Forms.ComboBox CmbPlaka;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox CmbPersoneller3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button BtnTemizle;
    }
}