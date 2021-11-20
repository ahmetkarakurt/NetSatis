using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NetSatis.Entities.Interfaces;

namespace NetSatis.Entities.Tables
{
    public class HavuzStok : IEntity
    {
        public int ID { get; set; }
        public string BARKOD { get; set; }
        public string STOK { get; set; }
       
    }
}
