
namespace UserInterface.IdariIsler
{
    partial class FrmAracZimmetiLogKayitlari
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label59 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DtgLog = new ADGV.AdvancedDataGridView();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label59.Location = new System.Drawing.Point(12, 675);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(94, 15);
            this.label59.TabIndex = 420;
            this.label59.Text = "Toplam Kayıt:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(112, 675);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 421;
            this.TxtTop.Text = "00";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DtgLog);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1459, 646);
            this.groupBox4.TabIndex = 419;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ARAÇ ZİMMETLERİ VERİ GEÇMİŞ";
            // 
            // DtgLog
            // 
            this.DtgLog.AllowUserToAddRows = false;
            this.DtgLog.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgLog.AutoGenerateContextFilters = true;
            this.DtgLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgLog.DateWithTime = false;
            this.DtgLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgLog.Location = new System.Drawing.Point(3, 16);
            this.DtgLog.MultiSelect = false;
            this.DtgLog.Name = "DtgLog";
            this.DtgLog.ReadOnly = true;
            this.DtgLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgLog.Size = new System.Drawing.Size(1453, 627);
            this.DtgLog.TabIndex = 321;
            this.DtgLog.TimeFilter = false;
            this.DtgLog.SortStringChanged += new System.EventHandler(this.DtgLog_SortStringChanged);
            this.DtgLog.FilterStringChanged += new System.EventHandler(this.DtgLog_FilterStringChanged);
            // 
            // FrmAracZimmetiLogKayitlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 711);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.groupBox4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAracZimmetiLogKayitlari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Araç Zimmetleri Log Kayıtları";
            this.Load += new System.EventHandler(this.FrmAracZimmetiLogKayitlari_Load);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.GroupBox groupBox4;
        private ADGV.AdvancedDataGridView DtgLog;
        private System.Windows.Forms.BindingSource dataBinder;
    }
}