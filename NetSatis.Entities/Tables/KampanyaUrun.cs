using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSatis.Entities.Interfaces;

namespace NetSatis.Entities.Tables
{
    public class KampanyaUrun : IEntity
    {
        public int Id { get; set; }
        public bool Durumu { get; set; }
        public string StokKodu { get; set; }
        public string Barkod { get; set; }
        public string StokAdi { get; set; }
        public string KampanyaTuru { get; set; }

        public string KampanyaSure { get; set; }
        public Nullable<DateTime> BaslangicTarihi { get; set; }
        public Nullable<DateTime> BitisTarihi { get; set; }
        public decimal IndirimOrani { get; set; }
        public decimal KampanyaAdeti { get; set; }
        public string Aciklama { get; set; }

        public int SubeId { get; set; }
        public int KampanyaKodId { get; set; }

        public virtual Sube Sube { get; set; }
        public virtual KampanyaAna KampanyaKod { get; set; }


    }
}
