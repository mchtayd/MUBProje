
namespace UserInterface.IdariIsler
{
    partial class FrmKonaklamaDetayi
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.DtgKonaklama = new ADGV.AdvancedDataGridView();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblGenelTop = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgKonaklama)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DtgKonaklama);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 186);
            this.panel1.TabIndex = 0;
            // 
            // DtgKonaklama
            // 
            this.DtgKonaklama.AllowUserToAddRows = false;
            this.DtgKonaklama.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgKonaklama.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgKonaklama.AutoGenerateContextFilters = true;
            this.DtgKonaklama.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgKonaklama.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgKonaklama.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgKonaklama.DateWithTime = false;
            this.DtgKonaklama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgKonaklama.Location = new System.Drawing.Point(0, 0);
            this.DtgKonaklama.MultiSelect = false;
            this.DtgKonaklama.Name = "DtgKonaklama";
            this.DtgKonaklama.ReadOnly = true;
            this.DtgKonaklama.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgKonaklama.Size = new System.Drawing.Size(507, 186);
            this.DtgKonaklama.TabIndex = 5;
            this.DtgKonaklama.TimeFilter = false;
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(112, 208);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 335;
            this.TxtTop.Text = "00";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(12, 208);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 334;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(177, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 352;
            this.label3.Text = "Genel Toplam:";
            // 
            // LblGenelTop
            // 
            this.LblGenelTop.AutoSize = true;
            this.LblGenelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblGenelTop.Location = new System.Drawing.Point(284, 208);
            this.LblGenelTop.Name = "LblGenelTop";
            this.LblGenelTop.Size = new System.Drawing.Size(34, 15);
            this.LblGenelTop.TabIndex = 353;
            this.LblGenelTop.Text = "00  ₺";
            // 
            // FrmKonaklamaDetayi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 237);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblGenelTop);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmKonaklamaDetayi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KONAKLAMA DETAYI";
            this.Load += new System.EventHandler(this.FrmKonaklamaDetayi_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgKonaklama)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ADGV.AdvancedDataGridView DtgKonaklama;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblGenelTop;
    }
}