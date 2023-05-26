
namespace UserInterface.Ana_Sayfa
{
    partial class FrmDisaAktarExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDisaAktarExcel));
            this.label1 = new System.Windows.Forms.Label();
            this.CmbTablo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.CmbYillar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChkTumunuGoster = new System.Windows.Forms.CheckBox();
            this.BtnDisaAktar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(49, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tablo Adı:";
            // 
            // CmbTablo
            // 
            this.CmbTablo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTablo.FormattingEnabled = true;
            this.CmbTablo.Items.AddRange(new object[] {
            "TAMAMLANAN SATLAR",
            "DEPO STOK",
            "DEPO KAYITLI MALZEMELER"});
            this.CmbTablo.Location = new System.Drawing.Point(120, 32);
            this.CmbTablo.Name = "CmbTablo";
            this.CmbTablo.Size = new System.Drawing.Size(282, 21);
            this.CmbTablo.TabIndex = 1;
            this.CmbTablo.SelectedIndexChanged += new System.EventHandler(this.CmbTablo_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgList);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1407, 594);
            this.groupBox1.TabIndex = 306;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VERİ";
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgList.AutoGenerateContextFilters = true;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgList.DateWithTime = false;
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(3, 16);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgList.Size = new System.Drawing.Size(1401, 575);
            this.DtgList.TabIndex = 1;
            this.DtgList.TimeFilter = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(185, 677);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 307;
            this.label2.Text = "Toplam Kayıt:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Location = new System.Drawing.Point(275, 677);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(19, 13);
            this.TxtTop.TabIndex = 308;
            this.TxtTop.Text = "00";
            // 
            // CmbYillar
            // 
            this.CmbYillar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYillar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbYillar.FormattingEnabled = true;
            this.CmbYillar.Location = new System.Drawing.Point(468, 30);
            this.CmbYillar.Name = "CmbYillar";
            this.CmbYillar.Size = new System.Drawing.Size(121, 23);
            this.CmbYillar.TabIndex = 538;
            this.CmbYillar.SelectedIndexChanged += new System.EventHandler(this.CmbYillar_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(431, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 537;
            this.label3.Text = "YIL:";
            // 
            // ChkTumunuGoster
            // 
            this.ChkTumunuGoster.AutoSize = true;
            this.ChkTumunuGoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkTumunuGoster.Location = new System.Drawing.Point(612, 32);
            this.ChkTumunuGoster.Name = "ChkTumunuGoster";
            this.ChkTumunuGoster.Size = new System.Drawing.Size(146, 19);
            this.ChkTumunuGoster.TabIndex = 539;
            this.ChkTumunuGoster.Text = "TÜMÜNÜ GÖSTER";
            this.ChkTumunuGoster.UseVisualStyleBackColor = true;
            this.ChkTumunuGoster.CheckedChanged += new System.EventHandler(this.ChkTumunuGoster_CheckedChanged);
            // 
            // BtnDisaAktar
            // 
            this.BtnDisaAktar.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnDisaAktar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDisaAktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnDisaAktar.Image = ((System.Drawing.Image)(resources.GetObject("BtnDisaAktar.Image")));
            this.BtnDisaAktar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDisaAktar.Location = new System.Drawing.Point(15, 673);
            this.BtnDisaAktar.Name = "BtnDisaAktar";
            this.BtnDisaAktar.Size = new System.Drawing.Size(130, 51);
            this.BtnDisaAktar.TabIndex = 540;
            this.BtnDisaAktar.Text = "  DIŞA AKTAR";
            this.BtnDisaAktar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDisaAktar.UseVisualStyleBackColor = false;
            this.BtnDisaAktar.Click += new System.EventHandler(this.BtnDisaAktar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmDisaAktarExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1431, 735);
            this.Controls.Add(this.BtnDisaAktar);
            this.Controls.Add(this.CmbYillar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChkTumunuGoster);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CmbTablo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDisaAktarExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dışa Aktar Excel";
            this.Load += new System.EventHandler(this.FrmDisaAktarExcel_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbTablo;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.ComboBox CmbYillar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ChkTumunuGoster;
        private System.Windows.Forms.Button BtnDisaAktar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}