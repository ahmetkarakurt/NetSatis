namespace NetSatis.BackOffice.Hızlı_Satış
{
    partial class FrmHizliSatis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHizliSatis));
            this.btnUrunEkle = new DevExpress.XtraEditors.SimpleButton();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnUrunSil = new DevExpress.XtraEditors.SimpleButton();
            this.grpUrunMenu = new DevExpress.XtraEditors.GroupControl();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.gridUrunEkle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGrupId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarkod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridContUrunEkle = new DevExpress.XtraGrid.GridControl();
            this.PanelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnYeni = new DevExpress.XtraEditors.SimpleButton();
            this.grpGrupMenu = new DevExpress.XtraEditors.GroupControl();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.txtGrupAdi = new DevExpress.XtraEditors.TextEdit();
            this.txtAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl37 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.grpGrupBilgi = new DevExpress.XtraEditors.GroupControl();
            this.gridGrupEkle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGrupAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridContGrupEkle = new DevExpress.XtraGrid.GridControl();
            this.PanelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grpUrunMenu)).BeginInit();
            this.grpUrunMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUrunEkle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContUrunEkle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControl2)).BeginInit();
            this.PanelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpGrupMenu)).BeginInit();
            this.grpGrupMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrupAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGrupBilgi)).BeginInit();
            this.grpGrupBilgi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupEkle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContGrupEkle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControl1)).BeginInit();
            this.PanelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.ImageOptions.ImageIndex = 1;
            this.btnUrunEkle.ImageOptions.ImageList = this.ımageList1;
            this.btnUrunEkle.Location = new System.Drawing.Point(6, 26);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(84, 37);
            this.btnUrunEkle.TabIndex = 0;
            this.btnUrunEkle.Text = "Ekle";
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "folder_out.png");
            this.ımageList1.Images.SetKeyName(1, "add.png");
            this.ımageList1.Images.SetKeyName(2, "delete.png");
            this.ımageList1.Images.SetKeyName(3, "floppy_disk.png");
            this.ımageList1.Images.SetKeyName(4, "floppy_disk_delete.png");
            // 
            // btnUrunSil
            // 
            this.btnUrunSil.ImageOptions.ImageIndex = 2;
            this.btnUrunSil.ImageOptions.ImageList = this.ımageList1;
            this.btnUrunSil.Location = new System.Drawing.Point(96, 26);
            this.btnUrunSil.Name = "btnUrunSil";
            this.btnUrunSil.Size = new System.Drawing.Size(84, 37);
            this.btnUrunSil.TabIndex = 1;
            this.btnUrunSil.Text = "Sil";
            this.btnUrunSil.Click += new System.EventHandler(this.btnUrunSil_Click);
            // 
            // grpUrunMenu
            // 
            this.grpUrunMenu.Controls.Add(this.btnUrunEkle);
            this.grpUrunMenu.Controls.Add(this.btnKapat);
            this.grpUrunMenu.Controls.Add(this.btnUrunSil);
            this.grpUrunMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpUrunMenu.Location = new System.Drawing.Point(2, 610);
            this.grpUrunMenu.Name = "grpUrunMenu";
            this.grpUrunMenu.Size = new System.Drawing.Size(596, 70);
            this.grpUrunMenu.TabIndex = 0;
            this.grpUrunMenu.Text = "Hızlı Satış İşlemleri";
            // 
            // btnKapat
            // 
            this.btnKapat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnKapat.ImageOptions.ImageIndex = 0;
            this.btnKapat.ImageOptions.ImageList = this.ımageList1;
            this.btnKapat.Location = new System.Drawing.Point(507, 28);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(84, 37);
            this.btnKapat.TabIndex = 4;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // gridUrunEkle
            // 
            this.gridUrunEkle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGrupId,
            this.colBarkod,
            this.colStokAdi});
            this.gridUrunEkle.GridControl = this.gridContUrunEkle;
            this.gridUrunEkle.Name = "gridUrunEkle";
            this.gridUrunEkle.OptionsSelection.MultiSelect = true;
            this.gridUrunEkle.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridUrunEkle.OptionsView.ShowGroupPanel = false;
            // 
            // colGrupId
            // 
            this.colGrupId.Caption = "GrupID";
            this.colGrupId.FieldName = "GrupId";
            this.colGrupId.Name = "colGrupId";
            this.colGrupId.OptionsColumn.AllowEdit = false;
            // 
            // colBarkod
            // 
            this.colBarkod.Caption = "Barkodu";
            this.colBarkod.FieldName = "Barkod";
            this.colBarkod.Name = "colBarkod";
            this.colBarkod.OptionsColumn.AllowEdit = false;
            this.colBarkod.Visible = true;
            this.colBarkod.VisibleIndex = 0;
            this.colBarkod.Width = 111;
            // 
            // colStokAdi
            // 
            this.colStokAdi.Caption = "Ürün Adı";
            this.colStokAdi.FieldName = "UrunAdi";
            this.colStokAdi.Name = "colStokAdi";
            this.colStokAdi.OptionsColumn.AllowEdit = false;
            this.colStokAdi.Visible = true;
            this.colStokAdi.VisibleIndex = 1;
            this.colStokAdi.Width = 327;
            // 
            // gridContUrunEkle
            // 
            this.gridContUrunEkle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridContUrunEkle.Location = new System.Drawing.Point(2, 2);
            this.gridContUrunEkle.MainView = this.gridUrunEkle;
            this.gridContUrunEkle.Name = "gridContUrunEkle";
            this.gridContUrunEkle.Size = new System.Drawing.Size(596, 608);
            this.gridContUrunEkle.TabIndex = 1;
            this.gridContUrunEkle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridUrunEkle});
            // 
            // PanelControl2
            // 
            this.PanelControl2.Controls.Add(this.gridContUrunEkle);
            this.PanelControl2.Controls.Add(this.grpUrunMenu);
            this.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControl2.Location = new System.Drawing.Point(456, 48);
            this.PanelControl2.Name = "PanelControl2";
            this.PanelControl2.Size = new System.Drawing.Size(600, 682);
            this.PanelControl2.TabIndex = 15;
            // 
            // btnVazgec
            // 
            this.btnVazgec.Enabled = false;
            this.btnVazgec.ImageOptions.ImageIndex = 4;
            this.btnVazgec.ImageOptions.ImageList = this.ımageList1;
            this.btnVazgec.Location = new System.Drawing.Point(276, 26);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(84, 37);
            this.btnVazgec.TabIndex = 3;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Enabled = false;
            this.btnKaydet.ImageOptions.ImageIndex = 3;
            this.btnKaydet.ImageOptions.ImageList = this.ımageList1;
            this.btnKaydet.Location = new System.Drawing.Point(186, 26);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(84, 37);
            this.btnKaydet.TabIndex = 2;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnYeni
            // 
            this.btnYeni.ImageOptions.ImageIndex = 1;
            this.btnYeni.ImageOptions.ImageList = this.ımageList1;
            this.btnYeni.Location = new System.Drawing.Point(6, 26);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(84, 37);
            this.btnYeni.TabIndex = 0;
            this.btnYeni.Text = "Yeni";
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // grpGrupMenu
            // 
            this.grpGrupMenu.Controls.Add(this.btnSil);
            this.grpGrupMenu.Controls.Add(this.btnVazgec);
            this.grpGrupMenu.Controls.Add(this.btnKaydet);
            this.grpGrupMenu.Controls.Add(this.btnYeni);
            this.grpGrupMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpGrupMenu.Location = new System.Drawing.Point(2, 610);
            this.grpGrupMenu.Name = "grpGrupMenu";
            this.grpGrupMenu.Size = new System.Drawing.Size(452, 70);
            this.grpGrupMenu.TabIndex = 0;
            this.grpGrupMenu.Text = "Grup İşlemleri";
            // 
            // btnSil
            // 
            this.btnSil.ImageOptions.ImageIndex = 2;
            this.btnSil.ImageOptions.ImageList = this.ımageList1;
            this.btnSil.Location = new System.Drawing.Point(96, 26);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(84, 37);
            this.btnSil.TabIndex = 1;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // txtGrupAdi
            // 
            this.txtGrupAdi.Location = new System.Drawing.Point(100, 25);
            this.txtGrupAdi.Name = "txtGrupAdi";
            this.txtGrupAdi.Properties.MaxLength = 50;
            this.txtGrupAdi.Size = new System.Drawing.Size(348, 20);
            this.txtGrupAdi.TabIndex = 0;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(100, 51);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtAciklama.Properties.MaxLength = 200;
            this.txtAciklama.Size = new System.Drawing.Size(348, 72);
            this.txtAciklama.TabIndex = 1;
            // 
            // labelControl37
            // 
            this.labelControl37.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl37.Appearance.Options.UseBackColor = true;
            this.labelControl37.Appearance.Options.UseTextOptions = true;
            this.labelControl37.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl37.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl37.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl37.Location = new System.Drawing.Point(6, 51);
            this.labelControl37.Name = "labelControl37";
            this.labelControl37.Size = new System.Drawing.Size(88, 72);
            this.labelControl37.TabIndex = 16;
            this.labelControl37.Text = "Açıklama";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl12.Appearance.Options.UseBackColor = true;
            this.labelControl12.Appearance.Options.UseTextOptions = true;
            this.labelControl12.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl12.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl12.Location = new System.Drawing.Point(6, 25);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(88, 20);
            this.labelControl12.TabIndex = 14;
            this.labelControl12.Text = "Grup Adı";
            // 
            // grpGrupBilgi
            // 
            this.grpGrupBilgi.Controls.Add(this.txtGrupAdi);
            this.grpGrupBilgi.Controls.Add(this.txtAciklama);
            this.grpGrupBilgi.Controls.Add(this.labelControl37);
            this.grpGrupBilgi.Controls.Add(this.labelControl12);
            this.grpGrupBilgi.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGrupBilgi.Enabled = false;
            this.grpGrupBilgi.Location = new System.Drawing.Point(2, 2);
            this.grpGrupBilgi.Name = "grpGrupBilgi";
            this.grpGrupBilgi.Size = new System.Drawing.Size(452, 130);
            this.grpGrupBilgi.TabIndex = 1;
            this.grpGrupBilgi.Text = "Grup Bilgileri";
            // 
            // gridGrupEkle
            // 
            this.gridGrupEkle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGrupAdi,
            this.colAciklama,
            this.colId});
            this.gridGrupEkle.GridControl = this.gridContGrupEkle;
            this.gridGrupEkle.Name = "gridGrupEkle";
            this.gridGrupEkle.OptionsView.ShowGroupPanel = false;
            this.gridGrupEkle.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridGrupEkle_FocusedRowChanged);
            // 
            // colGrupAdi
            // 
            this.colGrupAdi.Caption = "Grup Adı";
            this.colGrupAdi.FieldName = "GrupAdi";
            this.colGrupAdi.Name = "colGrupAdi";
            this.colGrupAdi.OptionsColumn.AllowEdit = false;
            this.colGrupAdi.Visible = true;
            this.colGrupAdi.VisibleIndex = 0;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Açıklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.OptionsColumn.AllowEdit = false;
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 1;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // gridContGrupEkle
            // 
            this.gridContGrupEkle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridContGrupEkle.Location = new System.Drawing.Point(2, 132);
            this.gridContGrupEkle.MainView = this.gridGrupEkle;
            this.gridContGrupEkle.Name = "gridContGrupEkle";
            this.gridContGrupEkle.Size = new System.Drawing.Size(452, 478);
            this.gridContGrupEkle.TabIndex = 17;
            this.gridContGrupEkle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridGrupEkle});
            // 
            // PanelControl1
            // 
            this.PanelControl1.Controls.Add(this.gridContGrupEkle);
            this.PanelControl1.Controls.Add(this.grpGrupBilgi);
            this.PanelControl1.Controls.Add(this.grpGrupMenu);
            this.PanelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelControl1.Location = new System.Drawing.Point(0, 48);
            this.PanelControl1.Name = "PanelControl1";
            this.PanelControl1.Size = new System.Drawing.Size(456, 682);
            this.PanelControl1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1056, 48);
            this.label1.TabIndex = 13;
            this.label1.Text = "Hızlı Satış İşlemleri";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmHizliSatis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 730);
            this.Controls.Add(this.PanelControl2);
            this.Controls.Add(this.PanelControl1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHizliSatis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hızlı Satış Menüsü";
            this.Load += new System.EventHandler(this.FrmHizliSatis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpUrunMenu)).EndInit();
            this.grpUrunMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUrunEkle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContUrunEkle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControl2)).EndInit();
            this.PanelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpGrupMenu)).EndInit();
            this.grpGrupMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtGrupAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGrupBilgi)).EndInit();
            this.grpGrupBilgi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupEkle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContGrupEkle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControl1)).EndInit();
            this.PanelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.SimpleButton btnUrunEkle;
        private System.Windows.Forms.ImageList ımageList1;
        private DevExpress.XtraEditors.SimpleButton btnUrunSil;
        private DevExpress.XtraEditors.GroupControl grpUrunMenu;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        internal DevExpress.XtraGrid.Columns.GridColumn colStokAdi;
        internal DevExpress.XtraGrid.Columns.GridColumn colBarkod;
        internal DevExpress.XtraGrid.Columns.GridColumn colGrupId;
        internal DevExpress.XtraGrid.Views.Grid.GridView gridUrunEkle;
        internal DevExpress.XtraGrid.GridControl gridContUrunEkle;
        internal DevExpress.XtraEditors.PanelControl PanelControl2;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnYeni;
        private DevExpress.XtraEditors.GroupControl grpGrupMenu;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.TextEdit txtGrupAdi;
        internal DevExpress.XtraEditors.MemoEdit txtAciklama;
        private DevExpress.XtraEditors.LabelControl labelControl37;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        internal DevExpress.XtraEditors.GroupControl grpGrupBilgi;
        internal DevExpress.XtraGrid.Columns.GridColumn colAciklama;
        internal DevExpress.XtraGrid.Columns.GridColumn colGrupAdi;
        internal DevExpress.XtraGrid.Views.Grid.GridView gridGrupEkle;
        internal DevExpress.XtraGrid.GridControl gridContGrupEkle;
        internal DevExpress.XtraEditors.PanelControl PanelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
    }
}