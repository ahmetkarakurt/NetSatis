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
    public class KampanyaUrunMap : EntityTypeConfiguration<KampanyaUrun>
    {
        public KampanyaUrunMap()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.StokKodu).HasMaxLength(12);
            this.Property(p => p.StokAdi).HasMaxLength(50);
            this.Property(p => p.Barkod).HasMaxLength(20);
            this.Property(p => p.KampanyaTuru).HasMaxLength(15);
            this.Property(p => p.KampanyaSure).HasMaxLength(15);
            this.Property(p => p.IndirimOrani).HasPrecision(5, 2);
            this.Property(p => p.KampanyaAdeti).HasPrecision(5, 2);
            this.Property(p => p.Aciklama).HasMaxLength(200);
            this.Property(p => p.KampanyaKodId);



            this.ToTable("KampanyaliUrunler");
            this.Property(p => p.Id).HasColumnName("Id");
            this.Property(p => p.Durumu).HasColumnName("Durumu");
            this.Property(p => p.StokKodu).HasColumnName("StokKodu");
            this.Property(p => p.StokAdi).HasColumnName("StokAdi");
            this.Property(p => p.Barkod).HasColumnName("Barkod");
            this.Property(p => p.KampanyaTuru).HasColumnName("KampanyaTuru");
            this.Property(p => p.KampanyaSure).HasColumnName("KampanyaSure");
            this.Property(p => p.BaslangicTarihi).HasColumnName("BaslangicTarihi");
            this.Property(p => p.BitisTarihi).HasColumnName("BitisTarihi");
            this.Property(p => p.IndirimOrani).HasColumnName("IndirimOrani");
            this.Property(p => p.KampanyaAdeti).HasColumnName("KampanyaAdeti");
            this.Property(p => p.Aciklama).HasColumnName("Aciklama");
            this.Property(p => p.KampanyaKodId).HasColumnName("KampanyaKodId");
            


        }
    }
}
