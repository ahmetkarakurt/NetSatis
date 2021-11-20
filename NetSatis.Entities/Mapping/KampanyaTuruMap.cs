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
    public class KampanyaTuruMap : EntityTypeConfiguration<KampanyaTuru>
    {
        public KampanyaTuruMap()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.KampanyaTuruKodu).HasMaxLength(12);
            this.Property(p => p.KampanyaTuruAdi).HasMaxLength(30);
            this.Property(p => p.Aciklama).HasMaxLength(200);
           


            this.ToTable("KampanyaTurleri");
            this.Property(p => p.Id).HasColumnName("Id");
            this.Property(p => p.KampanyaTuruKodu).HasColumnName("KampanyaTuruKodu");
            this.Property(p => p.KampanyaTuruAdi).HasColumnName("OdemeTuruAdi");
            this.Property(p => p.Aciklama).HasColumnName("Aciklama");


        }
    }
}
