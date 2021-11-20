using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NetSatis.Entities.Tables;

namespace NetSatis.Entities.Mapping
{
    public class KampanyaAnaMap : EntityTypeConfiguration<KampanyaAna>
    {
        public KampanyaAnaMap()
        {
            this.HasKey(p => p.KampanyaKod);
            this.Property(p => p.KampanyaKod).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.KampanyaAdi).HasMaxLength(50);
            this.Property(p => p.KampanyaTuru).HasMaxLength(15);
            this.Property(p => p.KampanyaSure).HasMaxLength(15);
            this.Property(p => p.IndirimOrani).HasPrecision(5, 2);
            this.Property(p => p.KampanyaFiyat).HasPrecision(5, 2);
            this.Property(p => p.Aciklama).HasMaxLength(200);

            this.ToTable("Kampanyalar");
            this.Property(p => p.KampanyaKod).HasColumnName("KampanyaKod");
            this.Property(p => p.Durumu).HasColumnName("Durumu");       
            this.Property(p => p.KampanyaAdi).HasColumnName("KampanyaAdi");
            this.Property(p => p.KampanyaTuru).HasColumnName("KampanyaTuru");
            this.Property(p => p.KampanyaSure).HasColumnName("KampanyaSure");
            this.Property(p => p.BaslangicTarihi).HasColumnName("BaslangicTarihi");
            this.Property(p => p.BitisTarihi).HasColumnName("BitisTarihi");
            this.Property(p => p.IndirimOrani).HasColumnName("IndirimOrani");
            this.Property(p => p.KampanyaFiyat).HasColumnName("KampanyaFiyat");
            this.Property(p => p.Aciklama).HasColumnName("Aciklama");


        }
    }
}
