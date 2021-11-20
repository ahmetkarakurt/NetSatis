using NetSatis.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSatis.Entities.Tables
{
    public class StokBarkod :IEntity
    {

        public string Barkod { get; set; }
        public string StokKodu { get; set; }
        
        public int StokId { get; set; }
        public string BarkodTipi { get; set; }
        public string Kull1 { get; set; }
        public string Kull2 { get; set; }
        public  Stok Stok { get; set; }
     
    }
}
