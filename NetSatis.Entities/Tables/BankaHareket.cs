using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSatis.Entities.Interfaces;

namespace NetSatis.Entities.Tables
{
    public class BankaHareket : IEntity
    {
        public int Id { get; set; }
        public string FisKodu { get; set; }
        public string Hareket { get; set; }
        public int BankaId { get; set; }
        public string OdemeTuru { get; set; }
        public string CariKodu { get; set; }
        public Nullable<DateTime> Tarih { get; set; }
        public Nullable<decimal> Tutar { get; set; }
        public string Aciklama { get; set; }
        public virtual Banka Banka { get; set; }
     //   public virtual BankaOdemeTuru BankaOdemeTuru { get; set; }
        public virtual Cari Cari { get; set; }
    }
}
