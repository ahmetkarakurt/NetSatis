using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetSatis.Web.Models
{
    public class KasaDurumPos
    {
        public string KasaPosAdi { get; set; }
        public string KasaKodu { get; set; }
        public string KasaAdi { get; set; }
        public decimal KasaGiris { get; set; }
        public decimal KasaCikis { get; set; }
        public string Bakiye { get; set; }
    }
}