using NetSatis.Admin;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tools;
using NetSatis.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetSatis.Web.Controllers
{
    public class HomeController : Controller
    {


        // GET: Home

        private NetSatisContext context;
        private bool girisBasarili = false;
        SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
        KasaDAL kasaDal = new KasaDAL();
        public ActionResult Index()
        {

            connectionStringBuilder.ConnectionString = "Data Source =.; Initial Catalog = NetSatis2020; Integrated Security = True; Persist Security Info = False";
            context = new NetSatisContext(connectionStringBuilder.ConnectionString);
            DateTime alttarih = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            DateTime usttarih = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));


            ViewData["Kasa"] = context.Kasalar.GroupJoin(context.KasaHareketleri, c => c.Id, c => c.KasaId,
                (kasa, kasahareket) => new KasaDurum
                {
                  KasaAdi=kasa.KasaAdi,
                   KasaKodu=kasa.KasaKodu,
                    KasaGiris = (kasahareket.Where(c => c.KasaId == kasa.Id && c.Hareket == "Kasa Giriş" && c.Tarih> alttarih && c.Tarih<usttarih).Sum(c => c.Tutar) ?? 0),
                    KasaCikis = (kasahareket.Where(c => c.KasaId == kasa.Id && c.Hareket == "Kasa Çıkış" && c.Tarih > alttarih && c.Tarih < usttarih).Sum(c => c.Tutar) ?? 0),
                    Bakiye = (kasahareket.Where(c => c.KasaId == kasa.Id && c.Hareket == "Kasa Giriş" && c.Tarih > alttarih && c.Tarih < usttarih).Sum(c => c.Tutar) ?? 0) - 
                             (kasahareket.Where(c => c.KasaId == kasa.Id && c.Hareket == "Kasa Çıkış" && c.Tarih > alttarih && c.Tarih < usttarih).Sum(c => c.Tutar) ?? 0)
                }).ToList();

      

            ViewData["KasaPos"] = from e in context.KasaHareketleri
                             // where e.FisKodu == "BS0000000012"
                         group e by new {e.KasaAdi,e.Hareket}
                        into eg
                         select new KasaDurumPos
                         {
                           KasaAdi = eg.Key.KasaAdi,
                           Bakiye= eg.Sum(rl => rl.Tutar).ToString()

                         };


            ViewData["KasaOdemeTuru"] = context.OdemeTurleri.GroupJoin(context.KasaHareketleri, c => c.Id, c => c.OdemeTuruId,
             (odemeturu, kasahareket) => new OdemeTuru
             {
                 OdemeTuruAdi = odemeturu.OdemeTuruAdi,
                 OdemeTuruKod = odemeturu.OdemeTuruKodu,
                 KasaGiris = (kasahareket.Where(c => c.OdemeTuruId == odemeturu.Id && c.Hareket == "Kasa Giriş" && c.Tarih > alttarih && c.Tarih < usttarih).Sum(c => c.Tutar) ?? 0),
                 KasaCikis = (kasahareket.Where(c => c.OdemeTuruId == odemeturu.Id && c.Hareket == "Kasa Çıkış" && c.Tarih > alttarih && c.Tarih < usttarih).Sum(c => c.Tutar) ?? 0),
                 Bakiye = (kasahareket.Where(c => c.OdemeTuruId == odemeturu.Id && c.Hareket == "Kasa Giriş" && c.Tarih > alttarih && c.Tarih < usttarih).Sum(c => c.Tutar) ?? 0) - 
                 (kasahareket.Where(c => c.OdemeTuruId == odemeturu.Id && c.Hareket == "Kasa Çıkış" && c.Tarih > alttarih && c.Tarih < usttarih).Sum(c => c.Tutar) ?? 0)
             }).ToList();


            ViewData["Stoklar"] = context.Stoklar.OrderByDescending(c => c.StokKodu).Take(5).ToList();

            var Satilaurun = from e in context.StokHareketleri
                                            where e.Hareket == "Stok Çıkış"
                                            
                                       group e by new { e.Stok.StokAdi }
                                       
                                        into eg
                                         select new EncokSatan10
                                         {
                                             Stokadi = eg.Key.StokAdi,
                                             StokAdeti = eg.Sum(c=>c.Miktar).ToString(),
                                             SatisRakami = eg.Sum(c=>c.Miktar*c.BirimFiyati).ToString()

                                         };
            var Gun = from e in context.StokHareketleri
                             where e.Hareket == "Stok Çıkış" && e.Tarih > alttarih && e.Tarih < usttarih

                      group e by new { e.Stok.StokAdi }

                                     into eg
                             select new EncokSatan10
                             {
                                 Stokadi = eg.Key.StokAdi,
                                 StokAdeti = eg.Sum(c => c.Miktar).ToString(),
                                 SatisRakami = eg.Sum(c => c.Miktar * c.BirimFiyati).ToString()

                             };


            ViewData["CokSatilan10"] = Satilaurun.OrderByDescending(c=>c.StokAdeti).Take(2).ToList();
             ViewData["AzSatilan10"] = Satilaurun.OrderBy(c => c.StokAdeti).Take(2).ToList();
            ViewData["GunCokSatilan10"] = Gun.OrderByDescending(c => c.StokAdeti).Take(10).ToList();

            return View();

        }

        public PartialViewResult _Stoklar()
        {

            // List<ZZZ_BANK_BAKIYE> Bank = DB.ZZZ_BANK_BAKIYE.ToList();
            ViewData["Stoklar"] = context.Stoklar.OrderByDescending(c=>c.StokKodu).Take(5).ToList();
            return PartialView(ViewData);
        }


    }
}