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
    public class BankaMap : EntityTypeConfiguration<Banka>
    {
        public BankaMap()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.BankaKodu).HasMaxLength(100);
            this.Property(p => p.BankaAdi).HasMaxLength(150);
            this.Property(p => p.YetkiliKodu).HasMaxLength(100);
            this.Property(p => p.YetkiliAdi).HasMaxLength(100);
            this.Property(p => p.Aciklama).HasMaxLength(200);

            this.ToTable("Bankalar");
            this.Property(p => p.Id).HasColumnName("Id");
            this.Property(p => p.BankaKodu).HasColumnName("BankaKodu");
            this.Property(p => p.BankaAdi).HasColumnName("BankaAdi");
            this.Property(p => p.YetkiliKodu).HasColumnName("YetkiliKodu");
            this.Property(p => p.YetkiliAdi).HasColumnName("YetkiliAdi");
            this.Property(p => p.Aciklama).HasColumnName("Aciklama");
        }
    }
}
