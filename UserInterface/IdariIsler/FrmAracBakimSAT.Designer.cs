
namespace UserInterface.IdariIsler
{
    partial class FrmAracBakimSAT
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
            this.CmbButceKoduGun = new System.Windows.Forms.ComboBox();
            this.TxtMiktar = new System.Windows.Forms.TextBox();
            this.TxtStokNo = new System.Windows.Forms.TextBox();
            this.CmbTanim = new System.Windows.Forms.ComboBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.TxtSatAciklama = new System.Windows.Forms.RichTextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.BtnTemizle = new System.Windows.Forms.Button();
            this.TxtBirim = new System.Windows.Forms.TextBox();
            this.CmbDonemYil = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.CmbDonemAy = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CmbButceKoduGun
            // 
            this.CmbButceKoduGun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbButceKoduGun.FormattingEnabled = true;
            this.CmbButceKoduGun.Items.AddRange(new object[] {
            "BM11/YAKIT, DİĞER",
            "BM18/ULAŞTIRMA"});
            this.CmbButceKoduGun.Location = new System.Drawing.Point(140, 27);
            this.CmbButceKoduGun.Name = "CmbButceKoduGun";
            this.CmbButceKoduGun.Size = new System.Drawing.Size(195, 21);
            this.CmbButceKoduGun.TabIndex = 422;
            // 
            // TxtMiktar
            // 
            this.TxtMiktar.Location = new System.Drawing.Point(140, 107);
            this.TxtMiktar.Name = "TxtMiktar";
            this.TxtMiktar.Size = new System.Drawing.Size(107, 20);
            this.TxtMiktar.TabIndex = 417;
            // 
            // TxtStokNo
            // 
            this.TxtStokNo.Location = new System.Drawing.Point(140, 81);
            this.TxtStokNo.Name = "TxtStokNo";
            this.TxtStokNo.Size = new System.Drawing.Size(195, 20);
            this.TxtStokNo.TabIndex = 416;
            // 
            // CmbTanim
            // 
            this.CmbTanim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTanim.FormattingEnabled = true;
            this.CmbTanim.Items.AddRange(new object[] {
            "YAKIT",
            "ULAŞTIRMA"});
            this.CmbTanim.Location = new System.Drawing.Point(140, 54);
            this.CmbTanim.Name = "CmbTanim";
            this.CmbTanim.Size = new System.Drawing.Size(195, 21);
            this.CmbTanim.TabIndex = 4;
            this.CmbTanim.SelectedIndexChanged += new System.EventHandler(this.CmbTanim_SelectedIndexChanged);
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(94, 137);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(40, 13);
            this.label60.TabIndex = 3;
            this.label60.Text = "BİRİM:";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(83, 111);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(51, 13);
            this.label59.TabIndex = 2;
            this.label59.Text = "MİKTAR:";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(76, 85);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(58, 13);
            this.label58.TabIndex = 1;
            this.label58.Text = "STOK NO:";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(90, 58);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(44, 13);
            this.label57.TabIndex = 0;
            this.label57.Text = "TANIM:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(12, 30);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(122, 13);
            this.label56.TabIndex = 421;
            this.label56.Text = "BÜTÇE KODU/TANIMI:";
            // 
            // TxtSatAciklama
            // 
            this.TxtSatAciklama.Location = new System.Drawing.Point(140, 162);
            this.TxtSatAciklama.Name = "TxtSatAciklama";
            this.TxtSatAciklama.Size = new System.Drawing.Size(649, 72);
            this.TxtSatAciklama.TabIndex = 417;
            this.TxtSatAciklama.Text = "";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(47, 165);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(87, 13);
            this.label54.TabIndex = 416;
            this.label54.Text = "SAT AÇIKLAMA:";
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(140, 279);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(145, 50);
            this.BtnKaydet.TabIndex = 423;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // BtnTemizle
            // 
            this.BtnTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTemizle.Location = new System.Drawing.Point(291, 279);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(145, 50);
            this.BtnTemizle.TabIndex = 424;
            this.BtnTemizle.Text = "TEMİZLE";
            this.BtnTemizle.UseVisualStyleBackColor = true;
            this.BtnTemizle.Click += new System.EventHandler(this.BtnTemizle_Click);
            // 
            // TxtBirim
            // 
            this.TxtBirim.Location = new System.Drawing.Point(140, 133);
            this.TxtBirim.Name = "TxtBirim";
            this.TxtBirim.Size = new System.Drawing.Size(107, 20);
            this.TxtBirim.TabIndex = 425;
            // 
            // CmbDonemYil
            // 
            this.CmbDonemYil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDonemYil.FormattingEnabled = true;
            this.CmbDonemYil.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.CmbDonemYil.Location = new System.Drawing.Point(251, 240);
            this.CmbDonemYil.Name = "CmbDonemYil";
            this.CmbDonemYil.Size = new System.Drawing.Size(105, 21);
            this.CmbDonemYil.TabIndex = 428;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(44, 244);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(87, 13);
            this.label35.TabIndex = 427;
            this.label35.Text = "DÖNEM (Ay/Yıl):";
            // 
            // CmbDonemAy
            // 
            this.CmbDonemAy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDonemAy.FormattingEnabled = true;
            this.CmbDonemAy.Items.AddRange(new object[] {
            "OCAK",
            "ŞUBAT",
            "MART",
            "NİSAN",
            "MAYIS",
            "HAZİRAN",
            "TEMMUZ",
            "AĞUSTOS",
            "EYLÜL",
            "EKİM",
            "KASIM",
            "ARALIK"});
            this.CmbDonemAy.Location = new System.Drawing.Point(140, 240);
            this.CmbDonemAy.Name = "CmbDonemAy";
            this.CmbDonemAy.Size = new System.Drawing.Size(105, 21);
            this.CmbDonemAy.TabIndex = 426;
            // 
            // FrmAracBakimSAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 351);
            this.Controls.Add(this.CmbDonemYil);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.CmbDonemAy);
            this.Controls.Add(this.TxtBirim);
            this.Controls.Add(this.BtnTemizle);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.CmbButceKoduGun);
            this.Controls.Add(this.TxtMiktar);
            this.Controls.Add(this.TxtStokNo);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.CmbTanim);
            this.Controls.Add(this.label60);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.TxtSatAciklama);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.label54);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAracBakimSAT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAT Kayıt Tamamla";
            this.Load += new System.EventHandler(this.FrmAracBakimSAT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbButceKoduGun;
        private System.Windows.Forms.TextBox TxtMiktar;
        private System.Windows.Forms.TextBox TxtStokNo;
        private System.Windows.Forms.ComboBox CmbTanim;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.RichTextBox TxtSatAciklama;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Button BtnTemizle;
        private System.Windows.Forms.TextBox TxtBirim;
        private System.Windows.Forms.ComboBox CmbDonemYil;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox CmbDonemAy;
    }
}