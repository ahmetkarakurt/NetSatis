using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraReports.UI;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tables;
using System.Collections.Generic;
using System.Linq;

namespace NetSatis.Reports.Fatura_ve_Fiş
{
    public partial class rptZraporu : DevExpress.XtraReports.UI.XtraReport
    {
        public rptZraporu(string kasiyer,int sube,string Turu,DateTime Tarih, DateTime Alm_Tarih,int ZraporID)
        {

            InitializeComponent();
            NetSatisContext context = new NetSatisContext();

      
                var result = from e in context.KasaHareketleri
                             where e.Tarih >= Tarih && e.KasıyerID == kasiyer && e.SubeId == sube
                             group e by new { e.Hareket, e.Kasa.KasaAdi, e.OdemeTuru.OdemeTuruAdi, e.KasıyerID, e.Sube.Tanimi }
                    into eg
                             select new
                             {
                                 eg.Key.Hareket,
                                 eg.Key.KasaAdi,
                                 eg.Key.OdemeTuruAdi,
                                 eg.Key.KasıyerID,
                                 eg.Key.Tanimi,
                                 FisSayisi = eg.Count(),
                                 Tutar = eg.Sum(rl => rl.Tutar)


                                 ,/*(kasahareket.Where(c => c.OdemeTuruId == odemeturu.Id && c.Hareket == "Kasa Giriş").Sum(c => c.Tutar) ?? 0) -
                    (kasahareket.Where(c => c.OdemeTuruId == odemeturu.Id && c.Hareket == "Kasa Çıkış").Sum(c => c.Tutar) ?? 0)*/
                             };



                lbgir.Text =    result.Where(s => s.Hareket == "Kasa Giriş").Sum(s => s.Tutar).ToString() ?? "0";
                lbliade.Text =  result.Where(s => s.Hareket == "Kasa Çıkış").Sum(s => s.Tutar).ToString() ?? "0";

                                if (lbgir.Text=="")
                                {
                        lbgir.Text = "0";
                                }
                                if (lbliade.Text=="")
                                {
                        lbliade.Text = "0";
                                }
                            lbOdemeTut.Text = (Convert.ToDecimal(lbgir.Text) - Convert.ToDecimal(lbliade.Text)).ToString();

                var bilgi = context.ZRaporlari.Where(c => c.KasıyerID == kasiyer && c.SubeId == sube && c.Turu == "Z Raporu").OrderByDescending(c => c.Tarih).FirstOrDefault();



            lblZNo.Text = "Z No : " + bilgi.Id;
            lblZTarihi.Text = "Z Tarihi : " + bilgi.Tarih.ToString();
            lblKasiyer.Text = "Kasiyer No : " + bilgi.KasıyerID;
            lblSube.Text = "Şube : " + bilgi.SubeId;
            lblFiSayisi.Text = "Kesilen Fiş Sayısı : " + result.Where(s => s.Hareket == "Kasa Giriş").Count().ToString() ?? "0";



            if (Turu!= "Z Raporu")
            {
                lblZNo.Text = "Son Z No : " + bilgi.Id;
                lblZTarihi.Text = "Son Z Tarihi : " + bilgi.Tarih.ToString();
                lblRaporTipi.Text = "X Raporu";
                lbOdeme.Text = "X Toplamı :";
            }


         //   


                this.DataSource = result.ToList();

                colKasa.DataBindings.Add("Text", this.DataSource, "Hareket");
                colOdemeTuruAdi.DataBindings.Add("Text", this.DataSource, "OdemeTuruAdi");
                colToplamTutar.DataBindings.Add("Text", this.DataSource, "Tutar");









            /*      StokHareketDAL stokHareketDal = new StokHareketDAL();
                  FisDAL fisDal = new FisDAL();
                  KasaHareketDAL kasaHareketDAL = new KasaHareketDAL();

                  Fis fisBilgi = fisDal.GetByFilter(context, c => c.FisKodu == fisKodu);
                //  KasaHareket KasaD = kasaHareketDAL.GetByFilter(context, c => c.FisKodu == fisKodu);

                  ObjectDataSource stokHareketdataSource = new ObjectDataSource { 
                      DataSource = stokHareketDal.GetAll(context, c => c.FisKodu == fisKodu) 
                  };

                  var ijoin = from k in context.StokHareketleri
                              join p in context.Stoklar on k.StokId equals p.Id
                              where (k.FisKodu== fisKodu)
                              select new
                              {
                                 Miktar= k.Miktar,
                                  BirimFiyati=  k.BirimFiyati,
                                  k.Kdv,
                                  p.StokAdi,
                                  Tutar= k.BirimFiyati*k. Miktar,
                                  IndirimTutari= (k.BirimFiyati *k.Miktar) / 100 * k.IndirimOrani,
                                  KdvTutari =(k.BirimFiyati *k.Miktar - ((k.BirimFiyati * k.Miktar) / 100 * k.IndirimOrani)) / 100 * k.Kdv

                              };



                  var kasa = from k in context.KasaHareketleri
                             join p in context.OdemeTurleri on k.OdemeTuruId equals p.Id
                              where (k.FisKodu == fisKodu)
                              select new
                              {
                            k.Tutar,
                            p.OdemeTuruAdi

                              };


                  lblFisKodu.Text = "Fiş No :" + fisBilgi.FisKodu;
                  lblTarih.Text =   fisBilgi.Tarih.ToString();
                   lbOdeme.Text = kasa.Select(c=>c.OdemeTuruAdi).FirstOrDefault().ToString();
                   lbOdemeTut.Text = kasa.Select(c => c.Tutar).FirstOrDefault().ToString();


                  this.DataSource = ijoin.ToList();


                  colStokAdi.DataBindings.Add("Text", this.DataSource, "StokAdi");
                  colMiktar.DataBindings.Add("Text", this.DataSource, "Kdv");
              //    colBirimFiyat.DataBindings.Add("Text", this.DataSource, "BirimFiyati");
                  colToplamTutar.DataBindings.Add("Text", this.DataSource,  "Tutar");




                  CalculatedField calcTutar = new CalculatedField();

                  this.CalculatedFields.Add(calcTutar);
                  calcTutar.Name = "Tutar";
                  calcTutar.Expression = "[BirimFiyati]*[Miktar]";


                  CalculatedField calcIndirimTutari = new CalculatedField();
                  this.CalculatedFields.Add(calcIndirimTutari);
                  calcIndirimTutari.Name = "IndirimTutari";
                  calcIndirimTutari.Expression = "([BirimFiyati]*[Miktar]) / 100 * [IndirimOrani]";

                  CalculatedField calcKdvToplam = new CalculatedField();
                  this.CalculatedFields.Add(calcKdvToplam);
                  calcKdvToplam.Name = "KdvTutari";
                  calcKdvToplam.Expression = "([BirimFiyati]*[Miktar]-[IndirimTutari]) / 100 * [Kdv]";

                  CalculatedField calcKdvsizToplam = new CalculatedField();
                  this.CalculatedFields.Add(calcKdvsizToplam);
                  calcKdvsizToplam.Name = "AraToplam";
                  calcKdvsizToplam.Expression = "([BirimFiyati]*[Miktar])- [KdvTutari] - [IndirimTutari]";

                  CalculatedField calKdvliTutar = new CalculatedField();
                  this.CalculatedFields.Add(calKdvliTutar);
                  calKdvliTutar.Name = "KdvliTutar";
                  calKdvliTutar.Expression = "([BirimFiyati]*[Miktar]) - [IndirimTutari]";

                //  colToplamTutar.DataBindings.Add("Text", null, "Tutar");

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
                  sumGenelToplam.Running = SummaryRunning.Page;sumGenelToplam.FormatString = "{0:C2}";

                  XRSummary sumIndirimToplam = new XRSummary();
                  sumIndirimToplam.Func = SummaryFunc.Sum;
                  sumIndirimToplam.Running = SummaryRunning.Page;
                  sumIndirimToplam.FormatString = "{0:C2}";

                  lblAraToplam.Summary = sumAraToplam;
                  lblKdvToplam.Summary = sumKdvToplam;
                  lblGenelToplam.Summary = sumGenelToplam;
                  lblIndirimTutari.Summary = sumIndirimToplam;


                  lblAraToplam.DataBindings.Add("Text", null, "AraToplam");
                  lblIndirimTutari.DataBindings.Add("Text", null, "IndirimTutari");
                  lblKdvToplam.DataBindings.Add("Text", null, "KdvTutari");
                  lblGenelToplam.DataBindings.Add("Text", null, "KdvliTutar");
                 */

        }

    }
}
