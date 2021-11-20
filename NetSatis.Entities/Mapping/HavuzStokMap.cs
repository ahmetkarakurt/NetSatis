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
    public class HavuzStokMap : EntityTypeConfiguration<HavuzStok>
    {
        public HavuzStokMap()
        {
            this.HasKey(p => p.ID);
            this.Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.BARKOD).HasMaxLength(25);
            this.Property(p => p.STOK).HasMaxLength(50);         
            this.ToTable("HavuzStok");
            this.Property(p => p.ID).HasColumnName("ID");
            this.Property(p => p.BARKOD).HasColumnName("BARKOD");
            this.Property(p => p.STOK).HasColumnName("STOK");
           
        }
    }
}
