namespace NetSatis.Reports.Fatura_ve_Fiş
{
    partial class rptZraporu
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.colKasa = new DevExpress.XtraReports.UI.XRTableCell();
            this.colOdemeTuruAdi = new DevExpress.XtraReports.UI.XRTableCell();
            this.colToplamTutar = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lblFiSayisi = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSube = new DevExpress.XtraReports.UI.XRLabel();
            this.lblKasiyer = new DevExpress.XtraReports.UI.XRLabel();
            this.lblZTarihi = new DevExpress.XtraReports.UI.XRLabel();
            this.lblZNo = new DevExpress.XtraReports.UI.XRLabel();
            this.lblRaporTipi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.FirmaAdi = new DevExpress.XtraReports.Parameters.Parameter();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.lbliade = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblKasaGiris = new DevExpress.XtraReports.UI.XRLabel();
            this.lbgir = new DevExpress.XtraReports.UI.XRLabel();
            this.lbOdemeTut = new DevExpress.XtraReports.UI.XRLabel();
            this.lbOdeme = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.coltut = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 42.33333F;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrTable1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTable1.BorderWidth = 0F;
            this.xrTable1.Dpi = 254F;
            this.xrTable1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(681.3133F, 42.33333F);
            this.xrTable1.StylePriority.UseBorderDashStyle = false;
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseBorderWidth = false;
            this.xrTable1.StylePriority.UseFont = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.colKasa,
            this.colOdemeTuruAdi,
            this.colToplamTutar});
            this.xrTableRow1.Dpi = 254F;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // colKasa
            // 
            this.colKasa.CanGrow = false;
            this.colKasa.Dpi = 254F;
            this.colKasa.Name = "colKasa";
            this.colKasa.Text = "[Stok.StokAdi]";
            this.colKasa.Weight = 0.51762188910972418D;
            // 
            // colOdemeTuruAdi
            // 
            this.colOdemeTuruAdi.Dpi = 254F;
            this.colOdemeTuruAdi.Name = "colOdemeTuruAdi";
            this.colOdemeTuruAdi.StylePriority.UseTextAlignment = false;
            this.colOdemeTuruAdi.Text = "colOdemeTuruAdi";
            this.colOdemeTuruAdi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.colOdemeTuruAdi.Weight = 0.87301009313100919D;
            // 
            // colToplamTutar
            // 
            this.colToplamTutar.CanGrow = false;
            this.colToplamTutar.Dpi = 254F;
            this.colToplamTutar.Name = "colToplamTutar";
            this.colToplamTutar.StylePriority.UseTextAlignment = false;
            this.colToplamTutar.Text = "colToplamTutar";
            this.colToplamTutar.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.colToplamTutar.TextFormatString = "*{0:n}";
            this.colToplamTutar.Weight = 0.38647333820341745D;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblFiSayisi,
            this.lblSube,
            this.lblKasiyer,
            this.lblZTarihi,
            this.lblZNo,
            this.lblRaporTipi,
            this.xrLabel1});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.HeightF = 326.7076F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // lblFiSayisi
            // 
            this.lblFiSayisi.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.lblFiSayisi.BorderWidth = 0F;
            this.lblFiSayisi.Dpi = 254F;
            this.lblFiSayisi.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFiSayisi.LocationFloat = new DevExpress.Utils.PointFloat(0.003441731F, 262.0763F);
            this.lblFiSayisi.Name = "lblFiSayisi";
            this.lblFiSayisi.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblFiSayisi.SizeF = new System.Drawing.SizeF(681.31F, 40F);
            this.lblFiSayisi.StylePriority.UseBorders = false;
            this.lblFiSayisi.StylePriority.UseBorderWidth = false;
            this.lblFiSayisi.StylePriority.UseFont = false;
            this.lblFiSayisi.StylePriority.UseTextAlignment = false;
            this.lblFiSayisi.Text = "Tarih";
            this.lblFiSayisi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblSube
            // 
            this.lblSube.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.lblSube.BorderWidth = 0F;
            this.lblSube.Dpi = 254F;
            this.lblSube.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSube.LocationFloat = new DevExpress.Utils.PointFloat(0.003441731F, 222.0763F);
            this.lblSube.Name = "lblSube";
            this.lblSube.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblSube.SizeF = new System.Drawing.SizeF(681.31F, 40F);
            this.lblSube.StylePriority.UseBorders = false;
            this.lblSube.StylePriority.UseBorderWidth = false;
            this.lblSube.StylePriority.UseFont = false;
            this.lblSube.StylePriority.UseTextAlignment = false;
            this.lblSube.Text = "Tarih";
            this.lblSube.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblKasiyer
            // 
            this.lblKasiyer.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.lblKasiyer.BorderWidth = 0F;
            this.lblKasiyer.Dpi = 254F;
            this.lblKasiyer.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKasiyer.LocationFloat = new DevExpress.Utils.PointFloat(0.003441731F, 182.0763F);
            this.lblKasiyer.Name = "lblKasiyer";
            this.lblKasiyer.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblKasiyer.SizeF = new System.Drawing.SizeF(681.31F, 40F);
            this.lblKasiyer.StylePriority.UseBorders = false;
            this.lblKasiyer.StylePriority.UseBorderWidth = false;
            this.lblKasiyer.StylePriority.UseFont = false;
            this.lblKasiyer.StylePriority.UseTextAlignment = false;
            this.lblKasiyer.Text = "Tarih";
            this.lblKasiyer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblZTarihi
            // 
            this.lblZTarihi.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.lblZTarihi.BorderWidth = 0F;
            this.lblZTarihi.Dpi = 254F;
            this.lblZTarihi.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblZTarihi.LocationFloat = new DevExpress.Utils.PointFloat(0.003441731F, 142.0763F);
            this.lblZTarihi.Name = "lblZTarihi";
            this.lblZTarihi.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblZTarihi.SizeF = new System.Drawing.SizeF(681.31F, 40F);
            this.lblZTarihi.StylePriority.UseBorders = false;
            this.lblZTarihi.StylePriority.UseBorderWidth = false;
            this.lblZTarihi.StylePriority.UseFont = false;
            this.lblZTarihi.StylePriority.UseTextAlignment = false;
            this.lblZTarihi.Text = "Tarih";
            this.lblZTarihi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblZNo
            // 
            this.lblZNo.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.lblZNo.BorderWidth = 0F;
            this.lblZNo.Dpi = 254F;
            this.lblZNo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblZNo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 102.0763F);
            this.lblZNo.Name = "lblZNo";
            this.lblZNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblZNo.SizeF = new System.Drawing.SizeF(681.31F, 40F);
            this.lblZNo.StylePriority.UseBorders = false;
            this.lblZNo.StylePriority.UseBorderWidth = false;
            this.lblZNo.StylePriority.UseFont = false;
            this.lblZNo.StylePriority.UseTextAlignment = false;
            this.lblZNo.Text = "Tarih";
            this.lblZNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblRaporTipi
            // 
            this.lblRaporTipi.Dpi = 254F;
            this.lblRaporTipi.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRaporTipi.LocationFloat = new DevExpress.Utils.PointFloat(0F, 55.75151F);
            this.lblRaporTipi.Name = "lblRaporTipi";
            this.lblRaporTipi.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblRaporTipi.SizeF = new System.Drawing.SizeF(681.3133F, 35.93044F);
            this.lblRaporTipi.StylePriority.UseFont = false;
            this.lblRaporTipi.StylePriority.UseTextAlignment = false;
            this.lblRaporTipi.Text = "Z Raporu";
            this.lblRaporTipi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters.FirmaAdi]")});
            this.xrLabel1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(681.3134F, 38.76525F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "GÜVEN MARKET";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // FirmaAdi
            // 
            this.FirmaAdi.Description = "Firma Adı";
            this.FirmaAdi.Name = "FirmaAdi";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbliade,
            this.xrLabel3,
            this.lblKasaGiris,
            this.lbgir,
            this.lbOdemeTut,
            this.lbOdeme,
            this.xrLabel8,
            this.xrLabel6});
            this.ReportFooter.Dpi = 254F;
            this.ReportFooter.HeightF = 194.6577F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // lbliade
            // 
            this.lbliade.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.lbliade.BorderWidth = 0F;
            this.lbliade.Dpi = 254F;
            this.lbliade.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbliade.LocationFloat = new DevExpress.Utils.PointFloat(392.9063F, 61.25481F);
            this.lbliade.Name = "lbliade";
            this.lbliade.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbliade.SizeF = new System.Drawing.SizeF(288.4071F, 55.77417F);
            this.lbliade.StylePriority.UseBorders = false;
            this.lbliade.StylePriority.UseBorderWidth = false;
            this.lbliade.StylePriority.UseFont = false;
            this.lbliade.StylePriority.UseTextAlignment = false;
            this.lbliade.Text = "Tarih";
            this.lbliade.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel3.BorderWidth = 0F;
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 61.25481F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(366.4591F, 55.77417F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseBorderWidth = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Toplam İade :";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblKasaGiris
            // 
            this.lblKasaGiris.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.lblKasaGiris.BorderWidth = 0F;
            this.lblKasaGiris.Dpi = 254F;
            this.lblKasaGiris.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKasaGiris.LocationFloat = new DevExpress.Utils.PointFloat(0F, 5.480648F);
            this.lblKasaGiris.Name = "lblKasaGiris";
            this.lblKasaGiris.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblKasaGiris.SizeF = new System.Drawing.SizeF(366.4591F, 55.77416F);
            this.lblKasaGiris.StylePriority.UseBorders = false;
            this.lblKasaGiris.StylePriority.UseBorderWidth = false;
            this.lblKasaGiris.StylePriority.UseFont = false;
            this.lblKasaGiris.StylePriority.UseTextAlignment = false;
            this.lblKasaGiris.Text = "Toplam Satış :";
            this.lblKasaGiris.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbgir
            // 
            this.lbgir.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.lbgir.BorderWidth = 0F;
            this.lbgir.Dpi = 254F;
            this.lbgir.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbgir.LocationFloat = new DevExpress.Utils.PointFloat(392.9063F, 5.480648F);
            this.lbgir.Name = "lbgir";
            this.lbgir.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbgir.SizeF = new System.Drawing.SizeF(288.4071F, 55.77417F);
            this.lbgir.StylePriority.UseBorders = false;
            this.lbgir.StylePriority.UseBorderWidth = false;
            this.lbgir.StylePriority.UseFont = false;
            this.lbgir.StylePriority.UseTextAlignment = false;
            this.lbgir.Text = "Tarih";
            this.lbgir.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lbOdemeTut
            // 
            this.lbOdemeTut.Dpi = 254F;
            this.lbOdemeTut.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbOdemeTut.LocationFloat = new DevExpress.Utils.PointFloat(392.9063F, 136.2377F);
            this.lbOdemeTut.Name = "lbOdemeTut";
            this.lbOdemeTut.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbOdemeTut.SizeF = new System.Drawing.SizeF(288.407F, 58.42001F);
            this.lbOdemeTut.StylePriority.UseFont = false;
            this.lbOdemeTut.StylePriority.UseTextAlignment = false;
            this.lbOdemeTut.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lbOdeme
            // 
            this.lbOdeme.Dpi = 254F;
            this.lbOdeme.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbOdeme.LocationFloat = new DevExpress.Utils.PointFloat(0F, 132.3825F);
            this.lbOdeme.Name = "lbOdeme";
            this.lbOdeme.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbOdeme.SizeF = new System.Drawing.SizeF(374.5746F, 58.42004F);
            this.lbOdeme.StylePriority.UseFont = false;
            this.lbOdeme.StylePriority.UseTextAlignment = false;
            this.lbOdeme.Text = "Z Toplamı :";
            this.lbOdeme.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel8.BorderWidth = 1F;
            this.xrLabel8.Dpi = 254F;
            this.xrLabel8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 126.9019F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(744.0001F, 5.480642F);
            this.xrLabel8.StylePriority.UseBorderDashStyle = false;
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseBorderWidth = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel8.TextFormatString = "{0:dd.MM.yyyy}";
            // 
            // xrLabel6
            // 
            this.xrLabel6.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel6.BorderWidth = 1F;
            this.xrLabel6.Dpi = 254F;
            this.xrLabel6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(744.0001F, 5.480642F);
            this.xrLabel6.StylePriority.UseBorderDashStyle = false;
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseBorderWidth = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel6.TextFormatString = "{0:dd.MM.yyyy}";
            // 
            // coltut
            // 
            this.coltut.Dpi = 254F;
            this.coltut.Name = "coltut";
            this.coltut.StylePriority.UseTextAlignment = false;
            this.coltut.Text = "colMiktar";
            this.coltut.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.coltut.TextFormatString = "%{0}";
            this.coltut.Weight = 0.815412293085473D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.CanGrow = false;
            this.xrTableCell3.Dpi = 254F;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "colToplamTutar";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell3.TextFormatString = "*{0:n}";
            this.xrTableCell3.Weight = 0.38647333820341745D;
            // 
            // rptZraporu
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(40, 11, 0, 0);
            this.PageHeight = 2794;
            this.PageWidth = 795;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.FirmaAdi});
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.RollPaper = true;
            this.SnapGridSize = 25F;
            this.Version = "18.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel lblRaporTipi;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel lblZNo;
        private DevExpress.XtraReports.Parameters.Parameter FirmaAdi;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell colKasa;
        private DevExpress.XtraReports.UI.XRTableCell colOdemeTuruAdi;
        private DevExpress.XtraReports.UI.XRTableCell colToplamTutar;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel lbOdeme;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel lbOdemeTut;
        private DevExpress.XtraReports.UI.XRTableCell coltut;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRLabel lblKasiyer;
        private DevExpress.XtraReports.UI.XRLabel lblZTarihi;
        private DevExpress.XtraReports.UI.XRLabel lblSube;
        private DevExpress.XtraReports.UI.XRLabel lbliade;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel lblKasaGiris;
        private DevExpress.XtraReports.UI.XRLabel lbgir;
        private DevExpress.XtraReports.UI.XRLabel lblFiSayisi;
    }
}
