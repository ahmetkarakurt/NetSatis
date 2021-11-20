using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tables;
using NetSatis.Entities.Tools;
using NetSatis.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace NetSatis.Web.Controllers
{
    public class StokController : Controller
    {
        // GET: Stok
        private NetSatisContext context;
        SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
       
         StokDAL stokDal = new StokDAL();
        Entities.Tables.Stok _entity;
        private Table _table;

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StokEkle()
        {

            connectionStringBuilder.ConnectionString = "Data Source =.; Initial Catalog = NetSatis2020; Integrated Security = True; Persist Security Info = False";
            context = new NetSatisContext(connectionStringBuilder.ConnectionString);

   

                ViewData["StokKodu"] = "S"+DateTime.Now.ToString("yy-dd-mm-ss-MM").Replace("-", "");
            
            return View();
        }

        [HttpPost]
        public ActionResult Urn(Stok stok)
        {
            connectionStringBuilder.ConnectionString = "Data Source =.; Initial Catalog = NetSatis2020; Integrated Security = True; Persist Security Info = False";
            context = new NetSatisContext(connectionStringBuilder.ConnectionString);
            _entity = new Entities.Tables.Stok();

           
           


            if (stokDal.AddOrUpdate(context, stok))
            {
                stokDal.Save(context);
              //  kodOlustur.KodArtirma();
                
            }
            return RedirectToAction("StokEkle");

        }

        public ActionResult StokBakiye(string Stokara)
        {
            connectionStringBuilder.ConnectionString = "Data Source =.; Initial Catalog = NetSatis2020; Integrated Security = True; Persist Security Info = False";
            context = new NetSatisContext(connectionStringBuilder.ConnectionString);

            var tablo = context.Stoklar.GroupJoin(context.StokHareketleri, c => c.StokKodu, c => c.StokKodu,
                   (Stoklar, StokHareketleri) =>
                       new StokBakiye
                       {
                           
                          StokKodu= Stoklar.StokKodu,
                         StokAdi=  Stoklar.StokAdi,                        
                         SatisKdv=  Stoklar.SatisKdv,  
                          Barkod= Stoklar.Barkod,
                             StokGrubu=  Stoklar.StokGrubu,
                           StokGiris = StokHareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Giriş").Sum(c => c.Miktar) ?? 0,
                           StokCikis = StokHareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Çıkış").Sum(c => c.Miktar) ?? 0,
                           MevcutStok = (StokHareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Giriş").Sum(c => c.Miktar) ?? 0) -
                                        (StokHareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Çıkış").Sum(c => c.Miktar) ?? 0)
                       }).ToList();

            if (!string.IsNullOrEmpty(Stokara))
            {
                tablo = tablo.Where(c => c.StokKodu == Stokara || c.Barkod == Stokara || c.StokAdi.Contains(Stokara)).ToList();
            }
         

            return View(tablo);
        }

   
    
    }
}