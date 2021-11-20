using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using DevExpress.DataAccess.ObjectBinding;

namespace NetSatis.Reports.Cari
{
    public partial class rptCariDurum : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCariDurum()
        {
            InitializeComponent();
            NetSatisContext context = new NetSatisContext();
            CariDAL cariDAL = new CariDAL();

            ObjectDataSource cariDataSource = new ObjectDataSource { DataSource = cariDAL.CariListele(context) };
            this.DataSource = cariDataSource;
            colAlacak.DataBindings.Add("Text",this.DataSource,"Alacak");
            colBakiye.DataBindings.Add("Text", this.DataSource, "Bakiye");
            colBorc.DataBindings.Add("Text", this.DataSource, "Borc");
            colCariAdi.DataBindings.Add("Text", this.DataSource, "CariAdi");
            colCariKodu.DataBindings.Add("Text", this.DataSource, "CariKodu");
            colCariTuru.DataBindings.Add("Text", this.DataSource, "CariTuru");
            colCepTelefonu.DataBindings.Add("Text", this.DataSource, "CepTelefonu");
            colIskontoOrani.DataBindings.Add("Text", this.DataSource, "IskontoOrani");


            XRSummary sumBakiye = new XRSummary();
            sumBakiye.Func = SummaryFunc.Sum;
            sumBakiye.Running = SummaryRunning.Page;

            XRSummary sumAlacak = new XRSummary();
            sumAlacak.Func = SummaryFunc.Sum;
            sumAlacak.Running = SummaryRunning.Page;

            XRSummary sumBorc = new XRSummary();
            sumBorc.Func = SummaryFunc.Sum;
            sumBorc.Running = SummaryRunning.Page;

      

            lbAlacak.DataBindings.Add("Text", null, "Alacak");
            lbAlacak.Summary = sumAlacak;

            lbBorc.DataBindings.Add("Text", null, "Borc");
            lbBorc.Summary = sumBorc;

            lblBakiye.DataBindings.Add("Text", null, "Bakiye");
            lblBakiye.Summary = sumBakiye;



        }

    }
}
