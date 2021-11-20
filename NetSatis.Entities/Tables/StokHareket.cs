using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSatis.Entities.Context;
using NetSatis.Entities.Interfaces;

namespace NetSatis.Entities.Tables
{
    public class StokHareket : IEntity
    {
        public StokHareket Clone()
        {
            StokHareket hareket = new StokHareket();
            hareket.FisKodu = FisKodu;
            hareket.Hareket = Hareket;
            hareket.StokKodu = StokKodu;
            hareket.Miktar = Miktar;
            hareket.Kdv = Kdv;
            hareket.BirimFiyati = BirimFiyati;
            hareket.IndirimOrani = IndirimOrani;
            hareket.DepoId = DepoId;
            hareket.SeriNo = SeriNo;
            hareket.KasaAdi = KasaAdi;
            hareket.Tarih = Tarih;
            hareket.Aciklama = Aciklama;
            hareket.Siparis = Siparis;

            return hareket;

        }
        public int Id { get; set; }
        public string FisKodu { get; set; }
        public string Hareket { get; set; }
        public string StokKodu { get; set; }
        public Nullable<decimal> Miktar { get; set; }
        public int Kdv { get; set; }
        public Nullable<decimal> BirimFiyati { get; set; }
        public Nullable<decimal> IndirimOrani { get; set; }
        public int DepoId { get; set; }
        public string SeriNo { get; set; }
        public Nullable<DateTime> Tarih { get; set; }
        public string KasaAdi { get; set; }

        public string Aciklama { get; set; }
        public bool Siparis { get; set; }
        public string KasıyerID { get; set; }
        public int SubeId { get; set; }
    
        public virtual Sube Sube { get; set; }

        public virtual Stok Stok { get; set; }
        public virtual Depo Depo { get; set; }

    }
}
