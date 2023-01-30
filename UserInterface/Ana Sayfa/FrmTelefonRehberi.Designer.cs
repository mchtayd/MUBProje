
namespace UserInterface.Ana_Sayfa
{
    partial class FrmTelefonRehberi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.CmbBolum = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.CmbAdSoyad = new System.Windows.Forms.ComboBox();
            this.Photo = new System.Windows.Forms.DataGridViewImageColumn();
            this.Sicil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonelAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unvani = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Durum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KisaKod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DahiliNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.SuspendLayout();
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label21.Location = new System.Drawing.Point(30, 30);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(135, 15);
            this.label21.TabIndex = 313;
            this.label21.Text = "PERSONEL ARAMA:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(30, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(135, 15);
            this.label15.TabIndex = 330;
            this.label15.Text = "BÖLÜM İLE ARAMA:";
            // 
            // CmbBolum
            // 
            this.CmbBolum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBolum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbBolum.FormattingEnabled = true;
            this.CmbBolum.Location = new System.Drawing.Point(171, 63);
            this.CmbBolum.Name = "CmbBolum";
            this.CmbBolum.Size = new System.Drawing.Size(338, 23);
            this.CmbBolum.TabIndex = 335;
            this.CmbBolum.SelectedIndexChanged += new System.EventHandler(this.CmbBolum_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.DtgList);
            this.groupBox6.Location = new System.Drawing.Point(12, 110);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1450, 667);
            this.groupBox6.TabIndex = 465;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Personel Listesi";
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AllowUserToResizeColumns = false;
            this.DtgList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DtgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgList.AutoGenerateContextFilters = true;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Photo,
            this.Sicil,
            this.PersonelAd,
            this.Unvani,
            this.Durum,
            this.KisaKod,
            this.Telefon,
            this.DahiliNo,
            this.Mail});
            this.DtgList.DateWithTime = false;
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(3, 16);
            this.DtgList.MultiSelect = false;
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DtgList.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DtgList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DtgList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DtgList.RowTemplate.Height = 200;
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgList.Size = new System.Drawing.Size(1444, 648);
            this.DtgList.TabIndex = 324;
            this.DtgList.TimeFilter = false;
            // 
            // CmbAdSoyad
            // 
            this.CmbAdSoyad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAdSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbAdSoyad.FormattingEnabled = true;
            this.CmbAdSoyad.Location = new System.Drawing.Point(171, 27);
            this.CmbAdSoyad.Name = "CmbAdSoyad";
            this.CmbAdSoyad.Size = new System.Drawing.Size(338, 23);
            this.CmbAdSoyad.TabIndex = 466;
            this.CmbAdSoyad.SelectedIndexChanged += new System.EventHandler(this.CmbAdSoyad_SelectedIndexChanged);
            // 
            // Photo
            // 
            this.Photo.HeaderText = "FOTO";
            this.Photo.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Photo.MinimumWidth = 22;
            this.Photo.Name = "Photo";
            this.Photo.ReadOnly = true;
            this.Photo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Sicil
            // 
            this.Sicil.HeaderText = "SİCİL";
            this.Sicil.MinimumWidth = 22;
            this.Sicil.Name = "Sicil";
            this.Sicil.ReadOnly = true;
            this.Sicil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // PersonelAd
            // 
            this.PersonelAd.HeaderText = "PERSONEL ADI";
            this.PersonelAd.MinimumWidth = 22;
            this.PersonelAd.Name = "PersonelAd";
            this.PersonelAd.ReadOnly = true;
            this.PersonelAd.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PersonelAd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Unvani
            // 
            this.Unvani.HeaderText = "ÜNVANI";
            this.Unvani.MinimumWidth = 22;
            this.Unvani.Name = "Unvani";
            this.Unvani.ReadOnly = true;
            this.Unvani.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Durum
            // 
            this.Durum.HeaderText = "DURUM";
            this.Durum.MinimumWidth = 22;
            this.Durum.Name = "Durum";
            this.Durum.ReadOnly = true;
            this.Durum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // KisaKod
            // 
            this.KisaKod.HeaderText = "KISA KOD";
            this.KisaKod.MinimumWidth = 22;
            this.KisaKod.Name = "KisaKod";
            this.KisaKod.ReadOnly = true;
            this.KisaKod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Telefon
            // 
            this.Telefon.HeaderText = "TELEFON NO";
            this.Telefon.MinimumWidth = 22;
            this.Telefon.Name = "Telefon";
            this.Telefon.ReadOnly = true;
            this.Telefon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // DahiliNo
            // 
            this.DahiliNo.HeaderText = "DAHİLİ NO";
            this.DahiliNo.MinimumWidth = 22;
            this.DahiliNo.Name = "DahiliNo";
            this.DahiliNo.ReadOnly = true;
            this.DahiliNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Mail
            // 
            this.Mail.HeaderText = "MAİL ADRESİ";
            this.Mail.MinimumWidth = 22;
            this.Mail.Name = "Mail";
            this.Mail.ReadOnly = true;
            this.Mail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // FrmTelefonRehberi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 789);
            this.Controls.Add(this.CmbAdSoyad);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.CmbBolum);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTelefonRehberi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Bilgileri";
            this.Load += new System.EventHandler(this.FrmTelefonRehberi_Load);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox CmbBolum;
        private System.Windows.Forms.GroupBox groupBox6;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.ComboBox CmbAdSoyad;
        private System.Windows.Forms.DataGridViewImageColumn Photo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sicil;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonelAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unvani;
        private System.Windows.Forms.DataGridViewTextBoxColumn Durum;
        private System.Windows.Forms.DataGridViewTextBoxColumn KisaKod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DahiliNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
    }
}