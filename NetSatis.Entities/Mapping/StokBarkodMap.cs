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
    public class StokBarkodMap: EntityTypeConfiguration<StokBarkod>
    {
        public StokBarkodMap()
        {
            this.HasKey(p => p.Barkod);
         //   this.Property(p => p.Barkod).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            
            this.Property(p => p.BarkodTipi).HasMaxLength(15);
            this.Property(p => p.Kull1).HasMaxLength(15);
            this.Property(p => p.Kull2).HasMaxLength(15);
            this.ToTable("StokBarkod");
            this.Property(p => p.Barkod).HasColumnName("Barkod");
            this.Property(p => p.StokKodu).HasColumnName("StokKodu");
            this.Property(p => p.BarkodTipi).HasColumnName("BarkodTipi");
            this.Property(p => p.Kull1).HasColumnName("Kull1");
            this.Property(p => p.Kull2).HasColumnName("Kull2");
            this.HasRequired(c => c.Stok).WithRequiredPrincipal();
            this.HasRequired(c => c.Stok).WithMany(c => c.StokBarkod).HasForeignKey(c => c.StokKodu);

        }
    }
}
