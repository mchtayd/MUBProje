
namespace UserInterface.Ana_Sayfa
{
    partial class FrmServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServer));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DtgList = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnTumunuDuzelt = new System.Windows.Forms.Button();
            this.BtnAtlat = new System.Windows.Forms.Button();
            this.LblIsAkisNo = new System.Windows.Forms.Label();
            this.BtnKontrolEt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkOnlineRefrec = new System.Windows.Forms.CheckBox();
            this.ChkBildirim = new System.Windows.Forms.CheckBox();
            this.BtnUygula = new System.Windows.Forms.Button();
            this.ımageList2 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(643, 515);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BtnUygula);
            this.tabPage1.Controls.Add(this.ChkBildirim);
            this.tabPage1.Controls.Add(this.ChkOnlineRefrec);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(635, 487);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Server Ayarları";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DtgList);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.BtnTumunuDuzelt);
            this.tabPage2.Controls.Add(this.BtnAtlat);
            this.tabPage2.Controls.Add(this.LblIsAkisNo);
            this.tabPage2.Controls.Add(this.BtnKontrolEt);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(635, 487);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "İş Akış No Düzenle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Location = new System.Drawing.Point(17, 108);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.Size = new System.Drawing.Size(335, 229);
            this.DtgList.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 409);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(380, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Not: Düzeltilen iş akış noları için varsa dosya yolları da düzeltilecektir.";
            // 
            // BtnTumunuDuzelt
            // 
            this.BtnTumunuDuzelt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTumunuDuzelt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTumunuDuzelt.Location = new System.Drawing.Point(17, 355);
            this.BtnTumunuDuzelt.Name = "BtnTumunuDuzelt";
            this.BtnTumunuDuzelt.Size = new System.Drawing.Size(114, 36);
            this.BtnTumunuDuzelt.TabIndex = 6;
            this.BtnTumunuDuzelt.Text = "Tümünü Düzelt";
            this.BtnTumunuDuzelt.UseVisualStyleBackColor = true;
            this.BtnTumunuDuzelt.Click += new System.EventHandler(this.BtnTumunuDuzelt_Click);
            // 
            // BtnAtlat
            // 
            this.BtnAtlat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAtlat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnAtlat.Location = new System.Drawing.Point(137, 56);
            this.BtnAtlat.Name = "BtnAtlat";
            this.BtnAtlat.Size = new System.Drawing.Size(114, 36);
            this.BtnAtlat.TabIndex = 4;
            this.BtnAtlat.Text = "Atlat";
            this.BtnAtlat.UseVisualStyleBackColor = true;
            this.BtnAtlat.Click += new System.EventHandler(this.BtnAtlat_Click);
            // 
            // LblIsAkisNo
            // 
            this.LblIsAkisNo.AutoSize = true;
            this.LblIsAkisNo.Location = new System.Drawing.Point(137, 25);
            this.LblIsAkisNo.Name = "LblIsAkisNo";
            this.LblIsAkisNo.Size = new System.Drawing.Size(21, 15);
            this.LblIsAkisNo.TabIndex = 3;
            this.LblIsAkisNo.Text = "00";
            // 
            // BtnKontrolEt
            // 
            this.BtnKontrolEt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKontrolEt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKontrolEt.Location = new System.Drawing.Point(17, 56);
            this.BtnKontrolEt.Name = "BtnKontrolEt";
            this.BtnKontrolEt.Size = new System.Drawing.Size(114, 36);
            this.BtnKontrolEt.TabIndex = 2;
            this.BtnKontrolEt.Text = "Kontrol Et";
            this.BtnKontrolEt.UseVisualStyleBackColor = true;
            this.BtnKontrolEt.Click += new System.EventHandler(this.BtnKontrolEt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mevcut İş Akış No:";
            // 
            // ChkOnlineRefrec
            // 
            this.ChkOnlineRefrec.AutoSize = true;
            this.ChkOnlineRefrec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkOnlineRefrec.Location = new System.Drawing.Point(22, 20);
            this.ChkOnlineRefrec.Name = "ChkOnlineRefrec";
            this.ChkOnlineRefrec.Size = new System.Drawing.Size(260, 19);
            this.ChkOnlineRefrec.TabIndex = 2;
            this.ChkOnlineRefrec.Text = "Çevirimiçi Liste Yenilenmesini Kapat";
            this.ChkOnlineRefrec.UseVisualStyleBackColor = true;
            // 
            // ChkBildirim
            // 
            this.ChkBildirim.AutoSize = true;
            this.ChkBildirim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkBildirim.Location = new System.Drawing.Point(22, 56);
            this.ChkBildirim.Name = "ChkBildirim";
            this.ChkBildirim.Size = new System.Drawing.Size(186, 19);
            this.ChkBildirim.TabIndex = 3;
            this.ChkBildirim.Text = "Bildirimleri Alımını Kapat";
            this.ChkBildirim.UseVisualStyleBackColor = true;
            // 
            // BtnUygula
            // 
            this.BtnUygula.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnUygula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUygula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnUygula.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUygula.ImageKey = "ok.png";
            this.BtnUygula.ImageList = this.ımageList2;
            this.BtnUygula.Location = new System.Drawing.Point(22, 101);
            this.BtnUygula.Name = "BtnUygula";
            this.BtnUygula.Size = new System.Drawing.Size(123, 51);
            this.BtnUygula.TabIndex = 511;
            this.BtnUygula.Text = "  UYGULA";
            this.BtnUygula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUygula.UseVisualStyleBackColor = false;
            this.BtnUygula.Click += new System.EventHandler(this.BtnUygula_Click);
            // 
            // ımageList2
            // 
            this.ımageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList2.ImageStream")));
            this.ımageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList2.Images.SetKeyName(0, "okey.png");
            this.ımageList2.Images.SetKeyName(1, "ok.png");
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 539);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.Load += new System.EventHandler(this.FrmServer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label LblIsAkisNo;
        private System.Windows.Forms.Button BtnKontrolEt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnTumunuDuzelt;
        private System.Windows.Forms.Button BtnAtlat;
        private System.Windows.Forms.DataGridView DtgList;
        private System.Windows.Forms.CheckBox ChkOnlineRefrec;
        private System.Windows.Forms.CheckBox ChkBildirim;
        private System.Windows.Forms.Button BtnUygula;
        private System.Windows.Forms.ImageList ımageList2;
    }
}