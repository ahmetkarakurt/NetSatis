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
    public class ZRaporlariMap : EntityTypeConfiguration<ZRaporlari>
    {
        public ZRaporlariMap()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.Turu).HasMaxLength(15);
            this.Property(p => p.KasaAdi).HasMaxLength(15);


            this.ToTable("ZRaporlari");
            this.Property(p => p.Id).HasColumnName("Id");
            this.Property(p => p.Turu).HasColumnName("Turu");
            this.Property(p => p.Tarih).HasColumnName("Tarih");
            this.Property(p => p.SubeId).HasColumnName("SubeId");
            this.Property(p => p.KasıyerID).HasColumnName("KasıyerId");
            this.Property(p => p.KasaAdi).HasColumnName("KasaAdi");
        }
    }
}
