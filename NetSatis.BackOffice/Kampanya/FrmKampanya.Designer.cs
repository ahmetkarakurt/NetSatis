namespace NetSatis.BackOffice.Kampanya
{
    partial class FrmKampanya
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKampanya));
            this.imgMenu = new System.Windows.Forms.ImageList(this.components);
            this.grpMenu = new DevExpress.XtraEditors.GroupControl();
            this.btnStokekle = new DevExpress.XtraEditors.SimpleButton();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.btnDurum = new DevExpress.XtraEditors.SimpleButton();
            this.btnAra = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.gridcontKampanya = new DevExpress.XtraGrid.GridControl();
            this.gridKampanya = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIndirimAktif = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKampanyaKod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDurumu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColKampanyaAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKampanyaTuru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKampanyaFiyat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIndirimTuru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaslangicTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryBaslangic = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colBitisTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryBitis = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colIndirimOrani = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grpMenu)).BeginInit();
            this.grpMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridcontKampanya)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKampanya)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryBaslangic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryBaslangic.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryBitis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryBitis.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // imgMenu
            // 
            this.imgMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgMenu.ImageStream")));
            this.imgMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imgMenu.Images.SetKeyName(0, "refresh.png");
            this.imgMenu.Images.SetKeyName(1, "view.png");
            this.imgMenu.Images.SetKeyName(2, "folder_out.png");
            this.imgMenu.Images.SetKeyName(3, "funnel.png");
            this.imgMenu.Images.SetKeyName(4, "funnel_delete.png");
            this.imgMenu.Images.SetKeyName(5, "düzenle.png");
            this.imgMenu.Images.SetKeyName(6, "ekle.png");
            this.imgMenu.Images.SetKeyName(7, "sil.png");
            this.imgMenu.Images.SetKeyName(8, "checkbox.png");
            this.imgMenu.Images.SetKeyName(9, "checkbox_unchecked.png");
            // 
            // grpMenu
            // 
            this.grpMenu.Controls.Add(this.btnStokekle);
            this.grpMenu.Controls.Add(this.btnKapat);
            this.grpMenu.Controls.Add(this.btnDurum);
            this.grpMenu.Controls.Add(this.btnAra);
            this.grpMenu.Controls.Add(this.btnGuncelle);
            this.grpMenu.Controls.Add(this.btnSil);
            this.grpMenu.Controls.Add(this.btnEkle);
            this.grpMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpMenu.Location = new System.Drawing.Point(0, 541);
            this.grpMenu.Name = "grpMenu";
            this.grpMenu.Size = new System.Drawing.Size(1031, 72);
            this.grpMenu.TabIndex = 9;
            this.grpMenu.Text = "Menü";
            // 
            // btnStokekle
            // 
            this.btnStokekle.ImageOptions.ImageIndex = 5;
            this.btnStokekle.ImageOptions.ImageList = this.imgMenu;
            this.btnStokekle.Location = new System.Drawing.Point(110, 24);
            this.btnStokekle.Name = "btnStokekle";
            this.btnStokekle.Size = new System.Drawing.Size(92, 43);
            this.btnStokekle.TabIndex = 1;
            this.btnStokekle.Text = "Stok Ekle";
            this.btnStokekle.Click += new System.EventHandler(this.btnStokekle_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.ImageOptions.ImageIndex = 2;
            this.btnKapat.ImageOptions.ImageList = this.imgMenu;
            this.btnKapat.Location = new System.Drawing.Point(927, 23);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(92, 43);
            this.btnKapat.TabIndex = 0;
            this.btnKapat.Text = "Kapat";
            // 
            // btnDurum
            // 
            this.btnDurum.ImageOptions.ImageIndex = 8;
            this.btnDurum.ImageOptions.ImageList = this.imgMenu;
            this.btnDurum.Location = new System.Drawing.Point(306, 24);
            this.btnDurum.Name = "btnDurum";
            this.btnDurum.Size = new System.Drawing.Size(92, 43);
            this.btnDurum.TabIndex = 0;
            this.btnDurum.Text = "Pasif Yap";
            this.btnDurum.Click += new System.EventHandler(this.btnDurum_Click);
            // 
            // btnAra
            // 
            this.btnAra.ImageOptions.ImageIndex = 1;
            this.btnAra.ImageOptions.ImageList = this.imgMenu;
            this.btnAra.Location = new System.Drawing.Point(502, 24);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(92, 43);
            this.btnAra.TabIndex = 0;
            this.btnAra.Text = "Ara";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.ImageOptions.ImageIndex = 0;
            this.btnGuncelle.ImageOptions.ImageList = this.imgMenu;
            this.btnGuncelle.Location = new System.Drawing.Point(404, 24);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(92, 43);
            this.btnGuncelle.TabIndex = 0;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.ImageOptions.ImageIndex = 7;
            this.btnSil.ImageOptions.ImageList = this.imgMenu;
            this.btnSil.Location = new System.Drawing.Point(208, 24);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(92, 43);
            this.btnSil.TabIndex = 0;
            this.btnSil.Text = "Sil";
            // 
            // btnEkle
            // 
            this.btnEkle.ImageOptions.ImageIndex = 6;
            this.btnEkle.ImageOptions.ImageList = this.imgMenu;
            this.btnEkle.Location = new System.Drawing.Point(12, 23);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(92, 43);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
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
            this.lblBaslik.Size = new System.Drawing.Size(1031, 58);
            this.lblBaslik.TabIndex = 10;
            this.lblBaslik.Text = "Kampanyalar";
            // 
            // gridcontKampanya
            // 
            this.gridcontKampanya.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridcontKampanya.Location = new System.Drawing.Point(0, 58);
            this.gridcontKampanya.MainView = this.gridKampanya;
            this.gridcontKampanya.Name = "gridcontKampanya";
            this.gridcontKampanya.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryBaslangic,
            this.repositoryBitis});
            this.gridcontKampanya.Size = new System.Drawing.Size(1031, 483);
            this.gridcontKampanya.TabIndex = 11;
            this.gridcontKampanya.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridKampanya});
            // 
            // gridKampanya
            // 
            this.gridKampanya.ActiveFilterEnabled = false;
            this.gridKampanya.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIndirimAktif,
            this.colKampanyaKod,
            this.colDurumu,
            this.ColKampanyaAdi,
            this.colKampanyaTuru,
            this.colKampanyaFiyat,
            this.colIndirimTuru,
            this.colBaslangicTarihi,
            this.colBitisTarihi,
            this.colIndirimOrani,
            this.colAciklama});
            this.gridKampanya.GridControl = this.gridcontKampanya;
            this.gridKampanya.Name = "gridKampanya";
            // 
            // colIndirimAktif
            // 
            this.colIndirimAktif.Caption = "Indirim Aktif Mi?";
            this.colIndirimAktif.FieldName = "IndirimAktif";
            this.colIndirimAktif.Name = "colIndirimAktif";
            this.colIndirimAktif.Visible = true;
            this.colIndirimAktif.VisibleIndex = 0;
            // 
            // colKampanyaKod
            // 
            this.colKampanyaKod.FieldName = "KampanyaKod";
            this.colKampanyaKod.Name = "colKampanyaKod";
            this.colKampanyaKod.OptionsColumn.AllowEdit = false;
            this.colKampanyaKod.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colDurumu
            // 
            this.colDurumu.FieldName = "Durumu";
            this.colDurumu.Name = "colDurumu";
            this.colDurumu.OptionsColumn.AllowEdit = false;
            this.colDurumu.OptionsColumn.ShowInCustomizationForm = false;
            this.colDurumu.Visible = true;
            this.colDurumu.VisibleIndex = 1;
            // 
            // ColKampanyaAdi
            // 
            this.ColKampanyaAdi.Caption = "Kampanya Adı";
            this.ColKampanyaAdi.FieldName = "KampanyaAdi";
            this.ColKampanyaAdi.Name = "ColKampanyaAdi";
            this.ColKampanyaAdi.OptionsColumn.AllowEdit = false;
            this.ColKampanyaAdi.OptionsColumn.ShowInCustomizationForm = false;
            this.ColKampanyaAdi.Visible = true;
            this.ColKampanyaAdi.VisibleIndex = 2;
            // 
            // colKampanyaTuru
            // 
            this.colKampanyaTuru.Caption = "KampanyaTuru";
            this.colKampanyaTuru.FieldName = "KampanyaTuru";
            this.colKampanyaTuru.Name = "colKampanyaTuru";
            this.colKampanyaTuru.OptionsColumn.AllowEdit = false;
            this.colKampanyaTuru.OptionsColumn.ShowInCustomizationForm = false;
            this.colKampanyaTuru.Visible = true;
            this.colKampanyaTuru.VisibleIndex = 3;
            // 
            // colKampanyaFiyat
            // 
            this.colKampanyaFiyat.Caption = "KampanyaFiyat";
            this.colKampanyaFiyat.FieldName = "KampanyaFiyat";
            this.colKampanyaFiyat.Name = "colKampanyaFiyat";
            this.colKampanyaFiyat.OptionsColumn.AllowEdit = false;
            this.colKampanyaFiyat.OptionsColumn.ShowInCustomizationForm = false;
            this.colKampanyaFiyat.Visible = true;
            this.colKampanyaFiyat.VisibleIndex = 5;
            // 
            // colIndirimTuru
            // 
            this.colIndirimTuru.Caption = "İndirim Türü";
            this.colIndirimTuru.FieldName = "IndirimTuru";
            this.colIndirimTuru.Name = "colIndirimTuru";
            this.colIndirimTuru.OptionsColumn.AllowEdit = false;
            this.colIndirimTuru.OptionsColumn.ShowInCustomizationForm = false;
            this.colIndirimTuru.Visible = true;
            this.colIndirimTuru.VisibleIndex = 4;
            // 
            // colBaslangicTarihi
            // 
            this.colBaslangicTarihi.Caption = "Başlangıç Tarihi";
            this.colBaslangicTarihi.ColumnEdit = this.repositoryBaslangic;
            this.colBaslangicTarihi.FieldName = "BaslangicTarihi";
            this.colBaslangicTarihi.Name = "colBaslangicTarihi";
            this.colBaslangicTarihi.OptionsColumn.AllowEdit = false;
            this.colBaslangicTarihi.OptionsColumn.ShowInCustomizationForm = false;
            this.colBaslangicTarihi.Visible = true;
            this.colBaslangicTarihi.VisibleIndex = 7;
            // 
            // repositoryBaslangic
            // 
            this.repositoryBaslangic.AutoHeight = false;
            this.repositoryBaslangic.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryBaslangic.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryBaslangic.Name = "repositoryBaslangic";
            this.repositoryBaslangic.NullText = "Tarih Bilgisi Yok";
            // 
            // colBitisTarihi
            // 
            this.colBitisTarihi.Caption = "Bitiş Tarihi";
            this.colBitisTarihi.ColumnEdit = this.repositoryBitis;
            this.colBitisTarihi.FieldName = "BitisTarihi";
            this.colBitisTarihi.Name = "colBitisTarihi";
            this.colBitisTarihi.OptionsColumn.AllowEdit = false;
            this.colBitisTarihi.OptionsColumn.ShowInCustomizationForm = false;
            this.colBitisTarihi.Visible = true;
            this.colBitisTarihi.VisibleIndex = 8;
            // 
            // repositoryBitis
            // 
            this.repositoryBitis.AutoHeight = false;
            this.repositoryBitis.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryBitis.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryBitis.Name = "repositoryBitis";
            this.repositoryBitis.NullText = "Tarih Bilgisi Yok";
            // 
            // colIndirimOrani
            // 
            this.colIndirimOrani.Caption = "İndirim Oranı";
            this.colIndirimOrani.FieldName = "IndirimOrani";
            this.colIndirimOrani.Name = "colIndirimOrani";
            this.colIndirimOrani.OptionsColumn.AllowEdit = false;
            this.colIndirimOrani.OptionsColumn.ShowInCustomizationForm = false;
            this.colIndirimOrani.Visible = true;
            this.colIndirimOrani.VisibleIndex = 6;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Açıklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.OptionsColumn.AllowEdit = false;
            this.colAciklama.OptionsColumn.ShowInCustomizationForm = false;
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 9;
            // 
            // FrmKampanya
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 613);
            this.Controls.Add(this.gridcontKampanya);
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.grpMenu);
            this.Name = "FrmKampanya";
            this.Text = "FrmKampanya";
            ((System.ComponentModel.ISupportInitialize)(this.grpMenu)).EndInit();
            this.grpMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridcontKampanya)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKampanya)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryBaslangic.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryBaslangic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryBitis.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryBitis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ImageList imgMenu;
        private DevExpress.XtraEditors.GroupControl grpMenu;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private DevExpress.XtraEditors.SimpleButton btnDurum;
        private DevExpress.XtraEditors.SimpleButton btnAra;
        private DevExpress.XtraEditors.SimpleButton btnGuncelle;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraGrid.GridControl gridcontKampanya;
        private DevExpress.XtraGrid.Views.Grid.GridView gridKampanya;
        private DevExpress.XtraGrid.Columns.GridColumn colIndirimAktif;
        private DevExpress.XtraGrid.Columns.GridColumn colKampanyaKod;
        private DevExpress.XtraGrid.Columns.GridColumn colDurumu;
        private DevExpress.XtraGrid.Columns.GridColumn ColKampanyaAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colKampanyaTuru;
        private DevExpress.XtraGrid.Columns.GridColumn colKampanyaFiyat;
        private DevExpress.XtraGrid.Columns.GridColumn colIndirimTuru;
        private DevExpress.XtraGrid.Columns.GridColumn colBaslangicTarihi;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryBaslangic;
        private DevExpress.XtraGrid.Columns.GridColumn colBitisTarihi;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryBitis;
        private DevExpress.XtraGrid.Columns.GridColumn colIndirimOrani;
        private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
        private DevExpress.XtraEditors.SimpleButton btnStokekle;
    }
}