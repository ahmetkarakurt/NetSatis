using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSatis.Entities.Tables;

namespace NetSatis.Entities.Mapping
{
    public class KasaHareketMap : EntityTypeConfiguration<KasaHareket>
    {
        public KasaHareketMap()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.FisKodu).HasMaxLength(12);
            this.Property(p => p.Hareket).HasMaxLength(10);
            this.Property(p => p.Tutar).HasPrecision(12, 2);
            this.Property(p => p.Aciklama).HasMaxLength(200);
            this.Property(p => p.KasıyerID).HasMaxLength(200);
            this.Property(p => p.KasaAdi).HasMaxLength(15);


            this.ToTable("KasaHareketleri");
            this.Property(p => p.Id).HasColumnName("Id");
            this.Property(p => p.FisKodu).HasColumnName("FisKodu");
            this.Property(p => p.Hareket).HasColumnName("Hareket");
            this.Property(p => p.KasaId).HasColumnName("KasaId");
            this.Property(p => p.OdemeTuruId).HasColumnName("OdemeTuruId");
            this.Property(p => p.CariKodu).HasColumnName("CariKodu");
            this.Property(p => p.Tarih).HasColumnName("Tarih");
            this.Property(p => p.Tutar).HasColumnName("Tutar");
            this.Property(p => p.Aciklama).HasColumnName("Aciklama");
            this.Property(p => p.SubeId).HasColumnName("SubeId");
            this.Property(p => p.KasıyerID).HasColumnName("KasıyerId");
            this.Property(p => p.KasaAdi).HasColumnName("KasaAdi");


            this.HasRequired(c => c.Kasa).WithMany(c => c.KasaHareket).HasForeignKey(c => c.KasaId);
            this.HasRequired(c => c.OdemeTuru).WithMany(c => c.KasaHareket).HasForeignKey(c => c.OdemeTuruId);
            this.HasOptional(c => c.Cari).WithMany(c => c.KasaHareket).HasForeignKey(c => c.CariKodu);
            this.HasRequired(c => c.Sube).WithMany(c => c.KasaHaraket).HasForeignKey(c => c.SubeId);
           
        }
    }
}
