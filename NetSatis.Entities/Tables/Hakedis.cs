using System;
using NetSatis.Entities.Interfaces;

namespace NetSatis.Entities.Tables
{
    public class Hakedis:IEntity
    {
        public int Id { get; set; }
        public string FisKodu { get; set; }
        public string CariKodu { get; set; }
        public string CariAdi { get; set; }
        public Nullable<DateTime> BaslangicTarih { get; set; }
        public Nullable<DateTime> BitisTarih { get; set; }
        public string BankaAdi { get; set; }
        public string Subesi { get; set; }
        public string HesapNo { get; set; }
        public string Iban { get; set; }
        public decimal PrimOrani { get; set; }
        public decimal SatisTutari { get; set; }
        public string Aciklama { get; set; }
    }
}
