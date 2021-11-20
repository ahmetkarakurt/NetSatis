using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetSatis.Web.Models
{
    public class StokBakiye
    {
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public string Birimi { get; set; }
        public string StokGrubu { get; set; }
        public string Barkod { get; set; }
        
        public int SatisKdv { get; set; }
        public decimal StokGiris { get; set; }
        public decimal StokCikis { get; set; }
        public decimal MevcutStok { get; set; }
    }
}