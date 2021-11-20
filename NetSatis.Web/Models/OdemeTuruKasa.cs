using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetSatis.Web.Models
{
    public class OdemeTuruKasa
    {
        public string KasaAdi { get; set; }
        public string OdemeTuruAdi { get; set; }
        public string OdemeTuruKod { get; set; }
        public decimal KasaGiris { get; set; }
        public decimal KasaCikis { get; set; }
        public decimal Bakiye { get; set; }


    }
}