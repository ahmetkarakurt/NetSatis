using NetSatis.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSatis.Entities.Tables
{
   public class KampanyaTuru: IEntity
    {
        public int Id { get; set; }
        public string KampanyaTuruKodu { get; set; }
        public string KampanyaTuruAdi { get; set; }
        public string Aciklama { get; set; }
        public virtual ICollection<KampanyaAna> KampanyaAna { get; set; }
    }
}
