using NetSatis.Entities.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSatis.Entities.Mapping
{
    public class CariHareketMap : EntityTypeConfiguration<CariHareketleri>
    {
        public CariHareketMap()
        {   //


            this.HasKey(p => p.ID);
            this.Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.Aciklama).HasMaxLength(100);
            this.Property(p => p.Alacak).HasPrecision(12, 2);
            this.Property(p => p.Borc).HasPrecision(12, 2);
            this.Property(p => p.Bakiye).HasPrecision(12, 2);
            this.Property(p => p.CariKodu).HasMaxLength(12);
            this.Property(p => p.FisKodu).HasMaxLength(12);
            this.Property(p => p.HareketTuru).HasMaxLength(40);

            this.ToTable("CariHareketleri");
            this.Property(p => p.ID).HasColumnName("ID");
            this.Property(p => p.Tarih).HasColumnName("Tarih");
            this.Property(p => p.VadeTarihi).HasColumnName("VadeTarihi");
            this.Property(p => p.CariKodu).HasColumnName("CariKodu");
            this.Property(p => p.FisKodu).HasColumnName("FisKodu");
            this.Property(p => p.HareketTuru).HasColumnName("HareketTuru");
            this.Property(p => p.Alacak).HasColumnName("Alacak");
            this.Property(p => p.Borc).HasColumnName("Borc");
            this.Property(p => p.Bakiye).HasColumnName("Bakiye");
            this.Property(p => p.Aciklama).HasColumnName("Aciklama");


            this.HasRequired(c => c.Cari).WithRequiredPrincipal();
            this.HasRequired(c => c.Cari).WithMany(c => c.CariHareketleri).HasForeignKey(c => c.CariKodu);


        }
    }
}
