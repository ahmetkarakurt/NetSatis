﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSatis.Entities.Tables;

namespace NetSatis.Entities.Mapping
{
    public class StokHareketMap:EntityTypeConfiguration<StokHareket>
    {
        public StokHareketMap()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.FisKodu).HasMaxLength(12);
            this.Property(p => p.Hareket).HasMaxLength(10);
            this.Property(p => p.Miktar).HasPrecision(12, 3);
            this.Property(p => p.BirimFiyati).HasPrecision(12, 2);
            this.Property(p => p.IndirimOrani).HasPrecision(5, 2);
            this.Property(p => p.SeriNo).HasMaxLength(200);
            this.Property(p => p.Aciklama).HasMaxLength(200);
            this.Property(p => p.KasıyerID).HasMaxLength(200);
            this.Property(p => p.KasaAdi).HasMaxLength(15);

            this.ToTable("StokHareketleri");
            this.Property(p => p.Id).HasColumnName("Id");
            this.Property(p => p.FisKodu).HasColumnName("FisKodu");
            this.Property(p => p.Hareket).HasColumnName("Hareket");
            this.Property(p => p.StokKodu).HasColumnName("StokId");
            this.Property(p => p.Miktar).HasColumnName("Miktar");
            this.Property(p => p.Kdv).HasColumnName("Kdv");
            this.Property(p => p.BirimFiyati).HasColumnName("BirimFiyati");
            this.Property(p => p.IndirimOrani).HasColumnName("IndirimOrani");
            this.Property(p => p.DepoId).HasColumnName("DepoId");
            this.Property(p => p.SeriNo).HasColumnName("SeriNo");
            this.Property(p => p.Tarih).HasColumnName("Tarih");

            this.Property(p => p.Aciklama).HasColumnName("Aciklama");
            this.Property(p => p.SubeId).HasColumnName("SubeId");
            this.Property(p => p.KasıyerID).HasColumnName("KasıyerId");
            this.Property(p => p.KasaAdi).HasColumnName("KasaAdi");


            this.HasRequired(c => c.Stok).WithRequiredPrincipal();
            this.HasRequired(c => c.Stok).WithMany(c => c.StokHareket).HasForeignKey(c => c.StokKodu);
            this.HasRequired(c => c.Depo).WithMany(c => c.StokHareket).HasForeignKey(c => c.DepoId);
            this.HasRequired(c => c.Sube).WithMany(c => c.StokHareket).HasForeignKey(c => c.SubeId);
          
        }
    }
}
