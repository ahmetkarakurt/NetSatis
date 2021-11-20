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
    public class AyarMap:EntityTypeConfiguration<Ayar>
    {
        public AyarMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.AyarAdi).HasMaxLength(50);
            this.Property(c => c.Deger).HasMaxLength(200);

            this.ToTable("Ayarlar");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.AyarAdi).HasColumnName("AyarAdi");
            this.Property(c => c.Deger).HasColumnName("Deger");
        }
    }
}
