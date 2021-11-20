using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSatis.Entities.Interfaces;

namespace NetSatis.Entities.Tables
{
    public class Sube : IEntity
    {
        public int Id { get; set; }
        public string Turu { get; set; }
        public string Tanimi { get; set; }
        public string Aciklama { get; set; }

        public virtual ICollection<StokHareket> StokHareket { get; set; }
        public virtual ICollection<KasaHareket> KasaHaraket { get; set; }
        public virtual ICollection<Fis> Fis { get; set; }

    }
}
