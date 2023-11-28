namespace UserInterface.Ana_Sayfa
{
    partial class FrmGorevUyarilari
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
            this.label31 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DtgListGorunen = new ADGV.AdvancedDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.LblGorunenTop = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DtgListUyarilan = new ADGV.AdvancedDataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.LblUyarilanTop = new System.Windows.Forms.Label();
            this.dataBinderGuncel = new System.Windows.Forms.BindingSource(this.components);
            this.dataBinderGorunen = new System.Windows.Forms.BindingSource(this.components);
            this.dataBinderUyarilan = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgListGorunen)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgListUyarilan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinderGuncel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinderGorunen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinderUyarilan)).BeginInit();
            this.SuspendLayout();
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(6, 499);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 344;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(106, 499);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 345;
            this.TxtTop.Text = "00";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(726, 552);
            this.tabControl1.TabIndex = 346;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DtgList);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.TxtTop);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(718, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Güncel Uyarılarım";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgList.AutoGenerateContextFilters = true;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgList.DateWithTime = false;
            this.DtgList.Location = new System.Drawing.Point(8, 12);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgList.Size = new System.Drawing.Size(701, 475);
            this.DtgList.TabIndex = 346;
            this.DtgList.TimeFilter = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DtgListGorunen);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.LblGorunenTop);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(718, 524);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Görüntülenen Uyarılarım";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DtgListGorunen
            // 
            this.DtgListGorunen.AllowUserToAddRows = false;
            this.DtgListGorunen.AllowUserToDeleteRows = false;
            this.DtgListGorunen.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgListGorunen.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgListGorunen.AutoGenerateContextFilters = true;
            this.DtgListGorunen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgListGorunen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgListGorunen.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgListGorunen.DateWithTime = false;
            this.DtgListGorunen.Location = new System.Drawing.Point(10, 12);
            this.DtgListGorunen.Name = "DtgListGorunen";
            this.DtgListGorunen.ReadOnly = true;
            this.DtgListGorunen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgListGorunen.Size = new System.Drawing.Size(701, 475);
            this.DtgListGorunen.TabIndex = 349;
            this.DtgListGorunen.TimeFilter = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(8, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 347;
            this.label1.Text = "Toplam Kayıt:";
            // 
            // LblGorunenTop
            // 
            this.LblGorunenTop.AutoSize = true;
            this.LblGorunenTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblGorunenTop.Location = new System.Drawing.Point(108, 499);
            this.LblGorunenTop.Name = "LblGorunenTop";
            this.LblGorunenTop.Size = new System.Drawing.Size(21, 15);
            this.LblGorunenTop.TabIndex = 348;
            this.LblGorunenTop.Text = "00";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DtgListUyarilan);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.LblUyarilanTop);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(718, 524);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Uyarılanlar";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DtgListUyarilan
            // 
            this.DtgListUyarilan.AllowUserToAddRows = false;
            this.DtgListUyarilan.AllowUserToDeleteRows = false;
            this.DtgListUyarilan.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgListUyarilan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DtgListUyarilan.AutoGenerateContextFilters = true;
            this.DtgListUyarilan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgListUyarilan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgListUyarilan.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgListUyarilan.DateWithTime = false;
            this.DtgListUyarilan.Location = new System.Drawing.Point(10, 11);
            this.DtgListUyarilan.Name = "DtgListUyarilan";
            this.DtgListUyarilan.ReadOnly = true;
            this.DtgListUyarilan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgListUyarilan.Size = new System.Drawing.Size(701, 475);
            this.DtgListUyarilan.TabIndex = 352;
            this.DtgListUyarilan.TimeFilter = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(8, 498);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 350;
            this.label3.Text = "Toplam Kayıt:";
            // 
            // LblUyarilanTop
            // 
            this.LblUyarilanTop.AutoSize = true;
            this.LblUyarilanTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblUyarilanTop.Location = new System.Drawing.Point(108, 498);
            this.LblUyarilanTop.Name = "LblUyarilanTop";
            this.LblUyarilanTop.Size = new System.Drawing.Size(21, 15);
            this.LblUyarilanTop.TabIndex = 351;
            this.LblUyarilanTop.Text = "00";
            // 
            // FrmGorevUyarilari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 558);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGorevUyarilari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Görev Uyarıları";
            this.Load += new System.EventHandler(this.FrmGorevUyarilari_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgListGorunen)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgListUyarilan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinderGuncel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinderGorunen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinderUyarilan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.TabPage tabPage2;
        private ADGV.AdvancedDataGridView DtgListGorunen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblGorunenTop;
        private System.Windows.Forms.TabPage tabPage3;
        private ADGV.AdvancedDataGridView DtgListUyarilan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblUyarilanTop;
        private System.Windows.Forms.BindingSource dataBinderGuncel;
        private System.Windows.Forms.BindingSource dataBinderGorunen;
        private System.Windows.Forms.BindingSource dataBinderUyarilan;
    }
}