
namespace UserInterface.IdariIsler
{
    partial class FrmSehitİciGorevOnay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSehitİciGorevOnay));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgSehirIciAmir = new ADGV.AdvancedDataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtTopAmir = new System.Windows.Forms.Label();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ımageList2 = new System.Windows.Forms.ImageList(this.components);
            this.BtnReddet = new System.Windows.Forms.Button();
            this.BtnTumunuOnayla = new System.Windows.Forms.Button();
            this.BtnOnayla = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgSehirIciAmir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1426, 27);
            this.panel1.TabIndex = 321;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgSehirIciAmir);
            this.groupBox2.Location = new System.Drawing.Point(12, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1400, 531);
            this.groupBox2.TabIndex = 332;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AMİR ONAY LİSTESİ";
            // 
            // DtgSehirIciAmir
            // 
            this.DtgSehirIciAmir.AllowUserToAddRows = false;
            this.DtgSehirIciAmir.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgSehirIciAmir.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgSehirIciAmir.AutoGenerateContextFilters = true;
            this.DtgSehirIciAmir.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgSehirIciAmir.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgSehirIciAmir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgSehirIciAmir.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgSehirIciAmir.DateWithTime = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtgSehirIciAmir.DefaultCellStyle = dataGridViewCellStyle3;
            this.DtgSehirIciAmir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgSehirIciAmir.Location = new System.Drawing.Point(3, 16);
            this.DtgSehirIciAmir.MultiSelect = false;
            this.DtgSehirIciAmir.Name = "DtgSehirIciAmir";
            this.DtgSehirIciAmir.ReadOnly = true;
            this.DtgSehirIciAmir.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgSehirIciAmir.Size = new System.Drawing.Size(1394, 512);
            this.DtgSehirIciAmir.TabIndex = 2;
            this.DtgSehirIciAmir.TimeFilter = false;
            this.DtgSehirIciAmir.SortStringChanged += new System.EventHandler(this.DtgSehirIciAmir_SortStringChanged);
            this.DtgSehirIciAmir.FilterStringChanged += new System.EventHandler(this.DtgSehirIciAmir_FilterStringChanged);
            this.DtgSehirIciAmir.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgSehirIciAmir_CellMouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(12, 589);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 333;
            this.label3.Text = "Toplam Kayıt:";
            // 
            // TxtTopAmir
            // 
            this.TxtTopAmir.AutoSize = true;
            this.TxtTopAmir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTopAmir.Location = new System.Drawing.Point(112, 589);
            this.TxtTopAmir.Name = "TxtTopAmir";
            this.TxtTopAmir.Size = new System.Drawing.Size(21, 15);
            this.TxtTopAmir.TabIndex = 334;
            this.TxtTopAmir.Text = "00";
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "okey.png");
            this.ımageList1.Images.SetKeyName(1, "ok.png");
            // 
            // ımageList2
            // 
            this.ımageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList2.ImageStream")));
            this.ımageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList2.Images.SetKeyName(0, "allokey.ico");
            this.ımageList2.Images.SetKeyName(1, "delete-sign.png");
            this.ımageList2.Images.SetKeyName(2, "Icojam-Blue-Bits-Database-check.ico");
            // 
            // BtnReddet
            // 
            this.BtnReddet.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnReddet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReddet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnReddet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnReddet.ImageKey = "delete-sign.png";
            this.BtnReddet.ImageList = this.ımageList2;
            this.BtnReddet.Location = new System.Drawing.Point(310, 618);
            this.BtnReddet.Name = "BtnReddet";
            this.BtnReddet.Size = new System.Drawing.Size(123, 51);
            this.BtnReddet.TabIndex = 347;
            this.BtnReddet.Text = "    REDDET";
            this.BtnReddet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReddet.UseVisualStyleBackColor = false;
            this.BtnReddet.Click += new System.EventHandler(this.BtnReddet_Click);
            // 
            // BtnTumunuOnayla
            // 
            this.BtnTumunuOnayla.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnTumunuOnayla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTumunuOnayla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTumunuOnayla.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnTumunuOnayla.ImageKey = "Icojam-Blue-Bits-Database-check.ico";
            this.BtnTumunuOnayla.ImageList = this.ımageList2;
            this.BtnTumunuOnayla.Location = new System.Drawing.Point(144, 618);
            this.BtnTumunuOnayla.Name = "BtnTumunuOnayla";
            this.BtnTumunuOnayla.Size = new System.Drawing.Size(160, 51);
            this.BtnTumunuOnayla.TabIndex = 346;
            this.BtnTumunuOnayla.Text = "TÜMÜNÜ ONAYLA";
            this.BtnTumunuOnayla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTumunuOnayla.UseVisualStyleBackColor = false;
            this.BtnTumunuOnayla.Click += new System.EventHandler(this.BtnTumunuOnayla_Click);
            // 
            // BtnOnayla
            // 
            this.BtnOnayla.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnOnayla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOnayla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnOnayla.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOnayla.ImageKey = "ok.png";
            this.BtnOnayla.ImageList = this.ımageList1;
            this.BtnOnayla.Location = new System.Drawing.Point(15, 618);
            this.BtnOnayla.Name = "BtnOnayla";
            this.BtnOnayla.Size = new System.Drawing.Size(123, 51);
            this.BtnOnayla.TabIndex = 345;
            this.BtnOnayla.Text = "  ONAYLA";
            this.BtnOnayla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOnayla.UseVisualStyleBackColor = false;
            this.BtnOnayla.Click += new System.EventHandler(this.BtnOnayla_Click);
            // 
            // FrmSehitİciGorevOnay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 806);
            this.Controls.Add(this.BtnReddet);
            this.Controls.Add(this.BtnTumunuOnayla);
            this.Controls.Add(this.BtnOnayla);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtTopAmir);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSehitİciGorevOnay";
            this.Text = "FrmSehitİciGorevOnay";
            this.Load += new System.EventHandler(this.FrmSehitİciGorevOnay_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgSehirIciAmir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private ADGV.AdvancedDataGridView DtgSehirIciAmir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TxtTopAmir;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.ImageList ımageList2;
        private System.Windows.Forms.Button BtnReddet;
        private System.Windows.Forms.Button BtnTumunuOnayla;
        private System.Windows.Forms.Button BtnOnayla;
    }
}