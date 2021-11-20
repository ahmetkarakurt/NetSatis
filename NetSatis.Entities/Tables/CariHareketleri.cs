using NetSatis.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSatis.Entities.Tables
{
    public class CariHareketleri : IEntity
    {

        public CariHareketleri Clone()
        {
            CariHareketleri yeniFis = new CariHareketleri();
            yeniFis.FisKodu = this.FisKodu;
            yeniFis.CariKodu = this.CariKodu;
            yeniFis.Bakiye = Bakiye;
            yeniFis.Borc = Borc;
            yeniFis.HareketTuru = HareketTuru;
            yeniFis.Tarih = Tarih;
            yeniFis.VadeTarihi = VadeTarihi;
            yeniFis.Alacak = Alacak;
            return yeniFis;



        }

        public int ID { get; set; }
        public string CariKodu { get; set; }
        public DateTime? Tarih { get; set; }
        public DateTime? VadeTarihi { get; set; }
        public string FisKodu { get; set; }
        public string Aciklama { get; set; }

        public decimal? Borc { get; set; } = 0;
        public decimal? Alacak { get; set; } = 0;
        public decimal? Bakiye { get; set; } = 0;

        public string HareketTuru { get; set; }

        public virtual Cari Cari { get; set; }



    }
}
