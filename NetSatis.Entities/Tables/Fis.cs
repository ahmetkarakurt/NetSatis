using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSatis.Entities.Interfaces;

namespace NetSatis.Entities.Tables
{
    public class Fis : IEntity
    {
        public Fis Clone()
        {    
            Fis yeniFis=new Fis();
            yeniFis.FisKodu = this.FisKodu;
            yeniFis.FisBaglantiKodu = this.FisBaglantiKodu;
            yeniFis.FisTuru = this.FisTuru;
            yeniFis.CariKodu = this.CariKodu;
            yeniFis.FaturaUnvani = this.FaturaUnvani;
            yeniFis.CepTelefonu = this.CepTelefonu;
            yeniFis.Il = this.Il;
            yeniFis.Ilce = Ilce;
            yeniFis.Semt = Semt;
            yeniFis.Adres = Adres;
            yeniFis.VergiDairesi = VergiDairesi;
            yeniFis.VergiNo = VergiNo;
            yeniFis.Tarih = Tarih;
            yeniFis.PlasiyerId = PlasiyerId;
            yeniFis.IskontoTutar = IskontoTutar;
            yeniFis.IskontoOrani = IskontoOrani;
            yeniFis.Alacak = Alacak;
            yeniFis.Borc = Borc;
            yeniFis.ToplamTutar = ToplamTutar;
            yeniFis.KasaAdi = KasaAdi;
            yeniFis.Aciklama = Aciklama;
            yeniFis.SubeId = SubeId;
            yeniFis.KasıyerID = KasıyerID;
            return yeniFis;
        }
        public int Id { get; set; }
        public string FisKodu { get; set; }
        public string FisBaglantiKodu { get; set; }
        public string FisTuru { get; set; }
        public string CariKodu { get; set; }
        public string FaturaUnvani { get; set; }
        public string CepTelefonu { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Semt { get; set; }
        public string Adres { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNo { get; set; }
        public string BelgeNo { get; set; }
        public DateTime? Tarih { get; set; }
        public int? PlasiyerId { get; set; }
        public decimal? IskontoOrani { get; set; }
        public decimal? IskontoTutar { get; set; }
        public decimal? Alacak { get; set; }
        public decimal? Borc { get; set; }
        public decimal? ToplamTutar { get; set; }
        public string KasaAdi { get; set; }
        public string Aciklama { get; set; }
        public string KasıyerID { get; set; }


        public int SubeId { get; set; }
    
        public virtual Sube Sube { get; set; }

        public virtual Cari Cari { get; set; }
        public virtual Personel Personel { get; set; }
    }
}
