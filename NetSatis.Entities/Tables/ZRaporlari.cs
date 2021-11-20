using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSatis.Entities.Interfaces;

namespace NetSatis.Entities.Tables
{
    public class ZRaporlari : IEntity
    {
        public int Id { get; set; }
        public string Turu { get; set; }
        public Nullable<DateTime> Tarih { get; set; }
        public string KasıyerID { get; set; }
        public int SubeId { get; set; }
        public string KasaAdi { get; set; }
        public virtual Sube Sube { get; set; }

    }
}
