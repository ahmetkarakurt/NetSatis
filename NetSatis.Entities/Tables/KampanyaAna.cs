using NetSatis.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSatis.Entities.Tables
{
    public class  KampanyaAna:IEntity
    {
     
        public int KampanyaKod { get; set; }
        public bool Durumu { get; set; }
        public string KampanyaAdi { get; set; }
        public string KampanyaTuru { get; set; }
        public string KampanyaSure { get; set; }
        public Nullable<DateTime> BaslangicTarihi { get; set; }
        public Nullable<DateTime> BitisTarihi { get; set; }
        public decimal IndirimOrani { get; set; }
        public decimal KampanyaFiyat { get; set; }
        public string Aciklama { get; set; }
        public int SubeId { get; set; }
        public virtual Sube Sube { get; set; }
        public virtual KampanyaTuru Kampanyatur { get; set; }
    }
}
