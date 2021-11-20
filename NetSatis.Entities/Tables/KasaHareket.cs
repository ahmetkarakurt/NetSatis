using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSatis.Entities.Interfaces;

namespace NetSatis.Entities.Tables
{
    public class KasaHareket : IEntity
    {
        public int Id { get; set; }
        public string FisKodu { get; set; }
        public string Hareket { get; set; }
        public int KasaId { get; set; }
        public int OdemeTuruId { get; set; }
        public string CariKodu { get; set; }
        public Nullable<DateTime> Tarih { get; set; }
        public Nullable<decimal> Tutar { get; set; }
        public string KasaAdi { get; set; }
        public string Aciklama { get; set; }
        public string KasıyerID { get; set; }
        public int SubeId { get; set; }
     
        public virtual Sube Sube { get; set; }
        public virtual Kasa Kasa { get; set; }
        public virtual OdemeTuru OdemeTuru { get; set; }
        public virtual Cari Cari { get; set; }
    }
}
