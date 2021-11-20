namespace NetSatis.BackOffice.Depo
{
    partial class FrmDepoIslem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDepoIslem));
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.GroupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.txtAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.GroupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.txtAdres = new DevExpress.XtraEditors.MemoEdit();
            this.GroupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtTelefon = new DevExpress.XtraEditors.TextEdit();
            this.txtSemt = new DevExpress.XtraEditors.TextEdit();
            this.txtIlce = new DevExpress.XtraEditors.TextEdit();
            this.txtIl = new DevExpress.XtraEditors.TextEdit();
            this.GrpDepoBilgi = new DevExpress.XtraEditors.GroupControl();
            this.txtDepoAdi = new DevExpress.XtraEditors.TextEdit();
            this.txtDepoKodu = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtYetkiliAdi = new DevExpress.XtraEditors.TextEdit();
            this.txtYetkiliKodu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl5)).BeginInit();
            this.GroupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl4)).BeginInit();
            this.GroupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl3)).BeginInit();
            this.GroupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSemt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlce.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrpDepoBilgi)).BeginInit();
            this.GrpDepoBilgi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepoAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepoKodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl2)).BeginInit();
            this.GroupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtYetkiliAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYetkiliKodu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKapat
            // 
            this.btnKapat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnKapat.ImageOptions.ImageIndex = 2;
            this.btnKapat.ImageOptions.ImageList = this.ımageList1;
            this.btnKapat.Location = new System.Drawing.Point(360, 6);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(99, 42);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "add.png");
            this.ımageList1.Images.SetKeyName(1, "floppy_disk.png");
            this.ımageList1.Images.SetKeyName(2, "folder_out.png");
            // 
            // btnKaydet
            // 
            this.btnKaydet.ImageOptions.ImageIndex = 1;
            this.btnKaydet.ImageOptions.ImageList = this.ımageList1;
            this.btnKaydet.Location = new System.Drawing.Point(255, 6);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(99, 42);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // GroupControl5
            // 
            this.GroupControl5.Controls.Add(this.btnKapat);
            this.GroupControl5.Controls.Add(this.btnKaydet);
            this.GroupControl5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GroupControl5.Location = new System.Drawing.Point(0, 526);
            this.GroupControl5.Name = "GroupControl5";
            this.GroupControl5.ShowCaption = false;
            this.GroupControl5.Size = new System.Drawing.Size(467, 53);
            this.GroupControl5.TabIndex = 10;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(100, 24);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtAciklama.Properties.MaxLength = 200;
            this.txtAciklama.Size = new System.Drawing.Size(359, 72);
            this.txtAciklama.TabIndex = 0;
            // 
            // GroupControl4
            // 
            this.GroupControl4.Controls.Add(this.txtAciklama);
            this.GroupControl4.Controls.Add(this.labelControl7);
            this.GroupControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupControl4.Location = new System.Drawing.Point(0, 420);
            this.GroupControl4.Name = "GroupControl4";
            this.GroupControl4.Size = new System.Drawing.Size(467, 104);
            this.GroupControl4.TabIndex = 9;
            this.GroupControl4.Text = "Diğer Bilgiler";
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(100, 128);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtAdres.Properties.MaxLength = 200;
            this.txtAdres.Size = new System.Drawing.Size(359, 72);
            this.txtAdres.TabIndex = 4;
            // 
            // GroupControl3
            // 
            this.GroupControl3.Controls.Add(this.txtAdres);
            this.GroupControl3.Controls.Add(this.labelControl8);
            this.GroupControl3.Controls.Add(this.labelControl6);
            this.GroupControl3.Controls.Add(this.labelControl5);
            this.GroupControl3.Controls.Add(this.labelControl2);
            this.GroupControl3.Controls.Add(this.labelControl4);
            this.GroupControl3.Controls.Add(this.txtTelefon);
            this.GroupControl3.Controls.Add(this.txtSemt);
            this.GroupControl3.Controls.Add(this.txtIlce);
            this.GroupControl3.Controls.Add(this.txtIl);
            this.GroupControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupControl3.Location = new System.Drawing.Point(0, 211);
            this.GroupControl3.Name = "GroupControl3";
            this.GroupControl3.Size = new System.Drawing.Size(467, 209);
            this.GroupControl3.TabIndex = 8;
            this.GroupControl3.Text = "Adres Bilgisi";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(100, 24);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Properties.Mask.EditMask = "(\\(\\d\\d\\d\\) )\\d{1,3}-\\d\\d-\\d\\d";
            this.txtTelefon.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtTelefon.Properties.MaxLength = 20;
            this.txtTelefon.Size = new System.Drawing.Size(359, 20);
            this.txtTelefon.TabIndex = 0;
            // 
            // txtSemt
            // 
            this.txtSemt.Location = new System.Drawing.Point(100, 102);
            this.txtSemt.Name = "txtSemt";
            this.txtSemt.Properties.MaxLength = 30;
            this.txtSemt.Size = new System.Drawing.Size(359, 20);
            this.txtSemt.TabIndex = 3;
            // 
            // txtIlce
            // 
            this.txtIlce.Location = new System.Drawing.Point(100, 76);
            this.txtIlce.Name = "txtIlce";
            this.txtIlce.Properties.MaxLength = 30;
            this.txtIlce.Size = new System.Drawing.Size(359, 20);
            this.txtIlce.TabIndex = 2;
            // 
            // txtIl
            // 
            this.txtIl.Location = new System.Drawing.Point(100, 50);
            this.txtIl.Name = "txtIl";
            this.txtIl.Properties.MaxLength = 30;
            this.txtIl.Size = new System.Drawing.Size(359, 20);
            this.txtIl.TabIndex = 1;
            // 
            // GrpDepoBilgi
            // 
            this.GrpDepoBilgi.Controls.Add(this.labelControl10);
            this.GrpDepoBilgi.Controls.Add(this.labelControl9);
            this.GrpDepoBilgi.Controls.Add(this.txtDepoAdi);
            this.GrpDepoBilgi.Controls.Add(this.txtDepoKodu);
            this.GrpDepoBilgi.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpDepoBilgi.Location = new System.Drawing.Point(0, 54);
            this.GrpDepoBilgi.Name = "GrpDepoBilgi";
            this.GrpDepoBilgi.Size = new System.Drawing.Size(467, 79);
            this.GrpDepoBilgi.TabIndex = 6;
            this.GrpDepoBilgi.Text = "Depo Bilgisi";
            // 
            // txtDepoAdi
            // 
            this.txtDepoAdi.Location = new System.Drawing.Point(100, 50);
            this.txtDepoAdi.Name = "txtDepoAdi";
            this.txtDepoAdi.Properties.MaxLength = 50;
            this.txtDepoAdi.Size = new System.Drawing.Size(359, 20);
            this.txtDepoAdi.TabIndex = 1;
            // 
            // txtDepoKodu
            // 
            this.txtDepoKodu.Location = new System.Drawing.Point(100, 24);
            this.txtDepoKodu.Name = "txtDepoKodu";
            this.txtDepoKodu.Properties.MaxLength = 10;
            this.txtDepoKodu.Size = new System.Drawing.Size(130, 20);
            this.txtDepoKodu.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 54);
            this.label1.TabIndex = 11;
            this.label1.Text = "Depo Kartı İşlemleri";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupControl2
            // 
            this.GroupControl2.Controls.Add(this.txtYetkiliAdi);
            this.GroupControl2.Controls.Add(this.labelControl3);
            this.GroupControl2.Controls.Add(this.labelControl1);
            this.GroupControl2.Controls.Add(this.txtYetkiliKodu);
            this.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupControl2.Location = new System.Drawing.Point(0, 133);
            this.GroupControl2.Name = "GroupControl2";
            this.GroupControl2.Size = new System.Drawing.Size(467, 78);
            this.GroupControl2.TabIndex = 7;
            this.GroupControl2.Text = "Yetkili Bilgileri";
            // 
            // txtYetkiliAdi
            // 
            this.txtYetkiliAdi.Location = new System.Drawing.Point(100, 50);
            this.txtYetkiliAdi.Name = "txtYetkiliAdi";
            this.txtYetkiliAdi.Properties.MaxLength = 50;
            this.txtYetkiliAdi.Size = new System.Drawing.Size(359, 20);
            this.txtYetkiliAdi.TabIndex = 1;
            // 
            // txtYetkiliKodu
            // 
            this.txtYetkiliKodu.Location = new System.Drawing.Point(100, 24);
            this.txtYetkiliKodu.Name = "txtYetkiliKodu";
            this.txtYetkiliKodu.Properties.MaxLength = 10;
            this.txtYetkiliKodu.Size = new System.Drawing.Size(130, 20);
            this.txtYetkiliKodu.TabIndex = 0;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.labelControl9.Appearance.Options.UseBorderColor = true;
            this.labelControl9.Appearance.Options.UseTextOptions = true;
            this.labelControl9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl9.Location = new System.Drawing.Point(6, 23);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(88, 22);
            this.labelControl9.TabIndex = 11;
            this.labelControl9.Text = "Depo Kodu :";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.labelControl10.Appearance.Options.UseBorderColor = true;
            this.labelControl10.Appearance.Options.UseTextOptions = true;
            this.labelControl10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl10.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl10.Location = new System.Drawing.Point(6, 48);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(88, 22);
            this.labelControl10.TabIndex = 11;
            this.labelControl10.Text = "Depo Adı :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.labelControl1.Appearance.Options.UseBorderColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl1.Location = new System.Drawing.Point(6, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 22);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Yetkili Kodu :";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.labelControl3.Appearance.Options.UseBorderColor = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl3.Location = new System.Drawing.Point(6, 48);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(88, 22);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Yetkili Adı :";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.labelControl4.Appearance.Options.UseBorderColor = true;
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl4.Location = new System.Drawing.Point(6, 22);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(88, 22);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Telefon :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.labelControl2.Appearance.Options.UseBorderColor = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl2.Location = new System.Drawing.Point(6, 48);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(88, 22);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "İl :";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.labelControl5.Appearance.Options.UseBorderColor = true;
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl5.Location = new System.Drawing.Point(6, 74);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(88, 22);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "İlçe :";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.labelControl6.Appearance.Options.UseBorderColor = true;
            this.labelControl6.Appearance.Options.UseTextOptions = true;
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl6.Location = new System.Drawing.Point(6, 100);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(88, 22);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "Semt :";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.labelControl8.Appearance.Options.UseBorderColor = true;
            this.labelControl8.Appearance.Options.UseTextOptions = true;
            this.labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl8.Location = new System.Drawing.Point(6, 128);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(88, 72);
            this.labelControl8.TabIndex = 11;
            this.labelControl8.Text = "Adres :";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.labelControl7.Appearance.Options.UseBorderColor = true;
            this.labelControl7.Appearance.Options.UseTextOptions = true;
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl7.Location = new System.Drawing.Point(6, 23);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(88, 72);
            this.labelControl7.TabIndex = 11;
            this.labelControl7.Text = "Açıklama :";
            // 
            // FrmDepoIslem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 579);
            this.Controls.Add(this.GroupControl5);
            this.Controls.Add(this.GroupControl4);
            this.Controls.Add(this.GroupControl3);
            this.Controls.Add(this.GroupControl2);
            this.Controls.Add(this.GrpDepoBilgi);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDepoIslem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Depo Kartı İşlemleri";
            this.Load += new System.EventHandler(this.FrmDepoIslem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl5)).EndInit();
            this.GroupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl4)).EndInit();
            this.GroupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAdres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl3)).EndInit();
            this.GroupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSemt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlce.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrpDepoBilgi)).EndInit();
            this.GrpDepoBilgi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDepoAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepoKodu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl2)).EndInit();
            this.GroupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtYetkiliAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYetkiliKodu.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private System.Windows.Forms.ImageList ımageList1;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.GroupControl GroupControl5;
        internal DevExpress.XtraEditors.MemoEdit txtAciklama;
        internal DevExpress.XtraEditors.GroupControl GroupControl4;
        internal DevExpress.XtraEditors.MemoEdit txtAdres;
        internal DevExpress.XtraEditors.GroupControl GroupControl3;
        private DevExpress.XtraEditors.TextEdit txtTelefon;
        private DevExpress.XtraEditors.TextEdit txtSemt;
        private DevExpress.XtraEditors.TextEdit txtIlce;
        private DevExpress.XtraEditors.TextEdit txtIl;
        internal DevExpress.XtraEditors.GroupControl GrpDepoBilgi;
        private DevExpress.XtraEditors.TextEdit txtDepoAdi;
        private DevExpress.XtraEditors.TextEdit txtDepoKodu;
        public System.Windows.Forms.Label label1;
        internal DevExpress.XtraEditors.GroupControl GroupControl2;
        private DevExpress.XtraEditors.TextEdit txtYetkiliAdi;
        private DevExpress.XtraEditors.TextEdit txtYetkiliKodu;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}