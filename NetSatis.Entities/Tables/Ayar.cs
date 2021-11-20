using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSatis.Entities.Interfaces;

namespace NetSatis.Entities.Tables
{
  public class Ayar:IEntity
    {
        public int Id { get; set; }
        public string AyarAdi { get; set; }
        public string Deger { get; set; }
    }
}
