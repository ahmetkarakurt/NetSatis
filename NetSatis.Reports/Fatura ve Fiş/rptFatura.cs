using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraReports.UI;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tables;

namespace NetSatis.Reports.Fatura_ve_Fiş
{
    public partial class rptFatura : DevExpress.XtraReports.UI.XtraReport
    {
        public rptFatura(string fisKodu)
        {
            InitializeComponent();
            NetSatisContext context = new NetSatisContext();
            StokHareketDAL stokHareketDal = new StokHareketDAL();
            FisDAL fisDal=new FisDAL();

            Fis fisBilgi = fisDal.GetByFilter(context, c => c.FisKodu == fisKodu);
            ObjectDataSource stokHareketdataSource = new ObjectDataSource { DataSource = stokHareketDal.GetAll(context,c=>c.FisKodu==fisKodu) };

         
         
                lblCariAdi.Text = fisBilgi.Cari.CariAdi;
            

            lblAdres.Text = fisBilgi.Adres;
            lblFaturaTarihi.Text = fisBilgi.Tarih.ToString();
            lblIkametgah.Text = fisBilgi.Semt + "\\" + fisBilgi.Ilce + "\\" + fisBilgi.Il;

            

            this.DataSource = stokHareketdataSource;
            colStokAdi.DataBindings.Add("Text", this.DataSource, "Stok.StokAdi");
            colMiktar.DataBindings.Add("Text", this.DataSource, "Miktar");
            colBirimFiyat.DataBindings.Add("Text", this.DataSource, "BirimFiyati");

    

            CalculatedField calcIndirimTutari = new CalculatedField();
            this.CalculatedFields.Add(calcIndirimTutari);
            calcIndirimTutari.Name = "IndirimTutari";
            calcIndirimTutari.Expression = "([BirimFiyati]*[Miktar]) / 100 * [IndirimOrani]";

            CalculatedField calcKdvToplam = new CalculatedField();
            this.CalculatedFields.Add(calcKdvToplam);
            calcKdvToplam.Name = "KdvTutari";
            calcKdvToplam.Expression = "([BirimFiyati]*[Miktar]-[IndirimTutari]) / 100 * [Kdv]";

            CalculatedField calcTutar = new CalculatedField();
            this.CalculatedFields.Add(calcTutar);
            calcTutar.Name = "Tutar";
            calcTutar.Expression = "([BirimFiyati]*[Miktar])- [KdvTutari] - [IndirimTutari]";
         
            CalculatedField calKdvliTutar = new CalculatedField();
            this.CalculatedFields.Add(calKdvliTutar);
            calKdvliTutar.Name = "KdvliTutar";
            calKdvliTutar.Expression = "([BirimFiyati]*[Miktar]) - [IndirimTutari]";

            colToplamTutar.DataBindings.Add("Text", null, "Tutar");


            XRSummary sumAraToplam = new XRSummary();
            sumAraToplam.Func = SummaryFunc.Sum;
            sumAraToplam.Running = SummaryRunning.Page;
            sumAraToplam.FormatString = "{0:C2}";


            XRSummary sumKdvToplam = new XRSummary();
            sumKdvToplam.Func = SummaryFunc.Sum;
            sumKdvToplam.Running = SummaryRunning.Page;
            sumKdvToplam.FormatString = "{0:C2}";

            XRSummary sumGenelToplam = new XRSummary();
            sumGenelToplam.Func = SummaryFunc.Sum;
            sumGenelToplam.Running = SummaryRunning.Page;
            sumGenelToplam.FormatString = "{0:C2}";

            lblAraToplam.Summary = sumAraToplam;
            lblKdvToplam.Summary = sumKdvToplam;
            lblGenelToplam.Summary = sumGenelToplam;

            lblAraToplam.DataBindings.Add("Text", null, "Tutar");
            lblKdvToplam.DataBindings.Add("Text", null, "KdvTutari");
            lblGenelToplam.DataBindings.Add("Text", null, "KdvliTutar");


        }

    }
}
