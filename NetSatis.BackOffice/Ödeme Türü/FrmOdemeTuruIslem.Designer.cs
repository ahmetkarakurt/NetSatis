namespace NetSatis.BackOffice.Ödeme_Türü
{
    partial class FrmOdemeTuruIslem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOdemeTuruIslem));
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.GroupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.GroupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.GroupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtOdemeAdi = new DevExpress.XtraEditors.TextEdit();
            this.txtOdemeKodu = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl3)).BeginInit();
            this.GroupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl4)).BeginInit();
            this.GroupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl2)).BeginInit();
            this.GroupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOdemeAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOdemeKodu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "add.png");
            this.ımageList1.Images.SetKeyName(1, "floppy_disk.png");
            this.ımageList1.Images.SetKeyName(2, "folder_out.png");
            this.ımageList1.Images.SetKeyName(3, "scales.png");
            this.ımageList1.Images.SetKeyName(4, "GörselEkle.png");
            this.ımageList1.Images.SetKeyName(5, "GörselSil.png");
            // 
            // GroupControl3
            // 
            this.GroupControl3.Controls.Add(this.btnKapat);
            this.GroupControl3.Controls.Add(this.btnKaydet);
            this.GroupControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GroupControl3.Location = new System.Drawing.Point(0, 258);
            this.GroupControl3.Name = "GroupControl3";
            this.GroupControl3.ShowCaption = false;
            this.GroupControl3.Size = new System.Drawing.Size(412, 53);
            this.GroupControl3.TabIndex = 18;
            // 
            // btnKapat
            // 
            this.btnKapat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnKapat.ImageOptions.ImageIndex = 2;
            this.btnKapat.ImageOptions.ImageList = this.ımageList1;
            this.btnKapat.Location = new System.Drawing.Point(306, 6);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(99, 42);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.ImageOptions.ImageIndex = 1;
            this.btnKaydet.ImageOptions.ImageList = this.ımageList1;
            this.btnKaydet.Location = new System.Drawing.Point(201, 6);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(99, 42);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblBaslik.Appearance.Image")));
            this.lblBaslik.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseImage = true;
            this.lblBaslik.Appearance.Options.UseImageAlign = true;
            this.lblBaslik.Appearance.Options.UseTextOptions = true;
            this.lblBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(412, 58);
            this.lblBaslik.TabIndex = 21;
            this.lblBaslik.Text = "Ödeme Türü İşlemleri";
            // 
            // GroupControl4
            // 
            this.GroupControl4.Controls.Add(this.labelControl2);
            this.GroupControl4.Controls.Add(this.txtAciklama);
            this.GroupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupControl4.Location = new System.Drawing.Point(0, 136);
            this.GroupControl4.Name = "GroupControl4";
            this.GroupControl4.Size = new System.Drawing.Size(412, 122);
            this.GroupControl4.TabIndex = 23;
            this.GroupControl4.Text = "Diğer Bilgiler";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.labelControl2.Appearance.Options.UseBorderColor = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl2.Location = new System.Drawing.Point(6, 23);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(88, 96);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Açıklama :";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(100, 24);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtAciklama.Properties.MaxLength = 200;
            this.txtAciklama.Size = new System.Drawing.Size(305, 95);
            this.txtAciklama.TabIndex = 0;
            // 
            // GroupControl2
            // 
            this.GroupControl2.Controls.Add(this.labelControl1);
            this.GroupControl2.Controls.Add(this.labelControl9);
            this.GroupControl2.Controls.Add(this.txtOdemeAdi);
            this.GroupControl2.Controls.Add(this.txtOdemeKodu);
            this.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupControl2.Location = new System.Drawing.Point(0, 58);
            this.GroupControl2.Name = "GroupControl2";
            this.GroupControl2.Size = new System.Drawing.Size(412, 78);
            this.GroupControl2.TabIndex = 22;
            this.GroupControl2.Text = "Diğer Bilgiler";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.labelControl1.Appearance.Options.UseBorderColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl1.Location = new System.Drawing.Point(6, 48);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 22);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Ödeme Adı :";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.labelControl9.Appearance.Options.UseBorderColor = true;
            this.labelControl9.Appearance.Options.UseTextOptions = true;
            this.labelControl9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl9.Location = new System.Drawing.Point(6, 22);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(88, 22);
            this.labelControl9.TabIndex = 12;
            this.labelControl9.Text = "Ödeme Kodu :";
            // 
            // txtOdemeAdi
            // 
            this.txtOdemeAdi.Location = new System.Drawing.Point(100, 50);
            this.txtOdemeAdi.Name = "txtOdemeAdi";
            this.txtOdemeAdi.Properties.MaxLength = 30;
            this.txtOdemeAdi.Size = new System.Drawing.Size(305, 20);
            this.txtOdemeAdi.TabIndex = 1;
            // 
            // txtOdemeKodu
            // 
            this.txtOdemeKodu.Location = new System.Drawing.Point(100, 24);
            this.txtOdemeKodu.Name = "txtOdemeKodu";
            this.txtOdemeKodu.Properties.MaxLength = 10;
            this.txtOdemeKodu.Size = new System.Drawing.Size(115, 20);
            this.txtOdemeKodu.TabIndex = 0;
            // 
            // FrmOdemeTuruIslem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 311);
            this.Controls.Add(this.GroupControl4);
            this.Controls.Add(this.GroupControl2);
            this.Controls.Add(this.GroupControl3);
            this.Controls.Add(this.lblBaslik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOdemeTuruIslem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ödeme Türü İşlemleri";
            this.Load += new System.EventHandler(this.FrmOdemeTuruIslem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl3)).EndInit();
            this.GroupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl4)).EndInit();
            this.GroupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl2)).EndInit();
            this.GroupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtOdemeAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOdemeKodu.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList ımageList1;
        private DevExpress.XtraEditors.GroupControl GroupControl3;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        internal DevExpress.XtraEditors.GroupControl GroupControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        internal DevExpress.XtraEditors.MemoEdit txtAciklama;
        internal DevExpress.XtraEditors.GroupControl GroupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtOdemeAdi;
        private DevExpress.XtraEditors.TextEdit txtOdemeKodu;
    }
}