namespace NetSatis.FrontOffice
{
    partial class FrmDipiskonto
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtİskontoOran = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtKalem = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFiyat = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtİskontoOran.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKalem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(91, 211);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(53, 17);
            this.labelControl3.TabIndex = 18;
            this.labelControl3.Text = "Isk Oranı";
            // 
            // txtİskontoOran
            // 
            this.txtİskontoOran.EditValue = "0";
            this.txtİskontoOran.Location = new System.Drawing.Point(169, 202);
            this.txtİskontoOran.Name = "txtİskontoOran";
            this.txtİskontoOran.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.25F);
            this.txtİskontoOran.Properties.Appearance.Options.UseFont = true;
            this.txtİskontoOran.Properties.ReadOnly = true;
            this.txtİskontoOran.Size = new System.Drawing.Size(196, 30);
            this.txtİskontoOran.TabIndex = 17;
            this.txtİskontoOran.EditValueChanged += new System.EventHandler(this.txtİskontoOran_EditValueChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(0, 21);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(190, 76);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Tamam";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(196, 21);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(181, 76);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "İptal";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(77, 175);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(67, 17);
            this.labelControl4.TabIndex = 23;
            this.labelControl4.Text = "Satış Tutarı";
            // 
            // txtKalem
            // 
            this.txtKalem.Location = new System.Drawing.Point(169, 166);
            this.txtKalem.Name = "txtKalem";
            this.txtKalem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.25F);
            this.txtKalem.Properties.Appearance.Options.UseFont = true;
            this.txtKalem.Properties.Mask.BeepOnError = true;
            this.txtKalem.Properties.Mask.EditMask = "c";
            this.txtKalem.Size = new System.Drawing.Size(196, 30);
            this.txtKalem.TabIndex = 16;
            this.txtKalem.EditValueChanged += new System.EventHandler(this.txtKalem_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(62, 139);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 17);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "Toplam Tutar";
            // 
            // txtFiyat
            // 
            this.txtFiyat.Location = new System.Drawing.Point(169, 130);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.25F);
            this.txtFiyat.Properties.Appearance.Options.UseFont = true;
            this.txtFiyat.Properties.Mask.BeepOnError = true;
            this.txtFiyat.Properties.ReadOnly = true;
            this.txtFiyat.Size = new System.Drawing.Size(196, 30);
            this.txtFiyat.TabIndex = 21;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.simpleButton2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 292);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(377, 98);
            this.groupControl1.TabIndex = 20;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl5.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.labelControl5.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
            this.labelControl5.LineStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.labelControl5.LineVisible = true;
            this.labelControl5.Location = new System.Drawing.Point(0, 0);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(259, 17);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "Seçilen Kaleme Uygulanacak İskonto Tutarı";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(169, 94);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.25F);
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.Mask.BeepOnError = true;
            this.textEdit1.Properties.Mask.EditMask = "c";
            this.textEdit1.Size = new System.Drawing.Size(196, 30);
            this.textEdit1.TabIndex = 24;
            this.textEdit1.Visible = false;
            // 
            // FrmDipiskonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 390);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtİskontoOran);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtKalem);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtFiyat);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelControl5);
            this.Name = "FrmDipiskonto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDipiskonto";
            this.Load += new System.EventHandler(this.FrmDipiskonto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtİskontoOran.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKalem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtİskontoOran;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.TextEdit txtKalem;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtFiyat;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.TextEdit textEdit1;
    }
}