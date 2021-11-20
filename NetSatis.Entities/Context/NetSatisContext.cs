using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSatis.Entities.Mapping;
using NetSatis.Entities.Migrations;
using NetSatis.Entities.Tables;
using NetSatis.Entities.Tools;

namespace NetSatis.Entities.Context
{
    public class NetSatisContext : DbContext
    {
        public enum MigrationSecenek
        {
            IslemYapma,
            YoksaYeniOlustur,
            ModeliDegistir,
            SilveYenidenOlustur,
            ModelDegistiyseSilveYenidenOlustur
        }
        public NetSatisContext() : base(ConnectionStringTool.ConnectionString() ?? "Bağlantı Yok")
        {
        //   Configuration.LazyLoadingEnabled = false;
       //    Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<NetSatisContext>(new MigrateDatabaseToLatestVersion<NetSatisContext, Configuration>());
        }

        public NetSatisContext(string connString,MigrationSecenek migration=MigrationSecenek.ModeliDegistir) :base(connString)
        {
        //    Configuration.LazyLoadingEnabled = false;
        //    Configuration.ProxyCreationEnabled = false;
            switch (migration)
            {
                case MigrationSecenek.IslemYapma:
                    Database.SetInitializer<NetSatisContext>(null);

                    break;
                case MigrationSecenek.YoksaYeniOlustur:
                    Database.SetInitializer<NetSatisContext>(new CreateDatabaseIfNotExists<NetSatisContext>());
                    break;
                case MigrationSecenek.ModelDegistiyseSilveYenidenOlustur:
                    Database.SetInitializer<NetSatisContext>(new DropCreateDatabaseIfModelChanges<NetSatisContext>());
                    break;
                case MigrationSecenek.SilveYenidenOlustur:
                    Database.SetInitializer<NetSatisContext>(new DropCreateDatabaseAlways<NetSatisContext>());
                    break;
                case MigrationSecenek.ModeliDegistir:
                    Database.SetInitializer<NetSatisContext>(new MigrateDatabaseToLatestVersion<NetSatisContext, Configuration>());
                    break;
            }
        
            
        }
        public DbSet<Stok> Stoklar { get; set; }
        public DbSet<Cari> Cariler { get; set; }
        public DbSet<Fis> Fisler { get; set; }
        public DbSet<StokHareket> StokHareketleri { get; set; }
        public DbSet<CariHareketleri> CariHareketleri { get; set; }
        public DbSet<KasaHareket> KasaHareketleri { get; set; }
        public DbSet<Depo> Depolar { get; set; }
        public DbSet<Kasa> Kasalar { get; set; }
        public DbSet<OdemeTuru> OdemeTurleri { get; set; }
        public DbSet<Tanim> Tanimlar { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<PersonelHareket> PersonelHareketleri { get; set; }
        public DbSet<Indirim> Indirimler { get; set; }
        public DbSet<HizliSatis> HizliSatislar { get; set; }
        public DbSet<HizliSatisGrup> HizliSatisGruplari { get; set; }
        public DbSet<EFAppointment> EFAppointments { get; set; }
        public DbSet<EFResource> EFResources { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<KullaniciRol> KullaniciRolleri { get; set; }
        public DbSet<Kod> Kodlar { get; set; }
        public DbSet<Ayar> Ayarlar { get; set; }
        public DbSet<StokBarkod> StokBarkod { get; set; }
        public DbSet<Sube> Subeler { get; set; }
        public DbSet<ZRaporlari> ZRaporlari { get; set; }

        public DbSet<Banka> Banka { get; set; }
        public DbSet<BankaHareket> BankaHareket { get; set; }
        public DbSet<BankaOdemeTuru> BankaOdemeTuru { get; set; }
        public DbSet<KampanyaAna> KampanyaAna { get; set; }
        public DbSet<KampanyaTuru> KampanyaTuru { get; set; }
        public DbSet<KampanyaUrun> KampanyaUrun { get; set; }
        public DbSet<HavuzStok> HavuzStok { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StokMap());
            modelBuilder.Configurations.Add(new CariMap());
            modelBuilder.Configurations.Add(new FisMap());
            modelBuilder.Configurations.Add(new StokHareketMap());
            modelBuilder.Configurations.Add(new CariHareketMap());
            modelBuilder.Configurations.Add(new KasaHareketMap());
            modelBuilder.Configurations.Add(new DepoMap());
            modelBuilder.Configurations.Add(new KasaMap());
            modelBuilder.Configurations.Add(new OdemeTuruMap());
            modelBuilder.Configurations.Add(new TanimMap());
            modelBuilder.Configurations.Add(new PersonelMap());
            modelBuilder.Configurations.Add(new PersonelHareketMap());
            modelBuilder.Configurations.Add(new IndirimMap());
            modelBuilder.Configurations.Add(new HizliSatisMap());
            modelBuilder.Configurations.Add(new HizliSatisGrupMap());
            modelBuilder.Configurations.Add(new KullaniciMap());
            modelBuilder.Configurations.Add(new KullaniciRolMap());
            modelBuilder.Configurations.Add(new KodMap());
            modelBuilder.Configurations.Add(new AyarMap());
            modelBuilder.Configurations.Add(new StokBarkodMap());
            modelBuilder.Configurations.Add(new SubeMap());
            modelBuilder.Configurations.Add(new ZRaporlariMap());
            modelBuilder.Configurations.Add(new BankaMap());
            modelBuilder.Configurations.Add(new BankaHareketMap());
            modelBuilder.Configurations.Add(new BankaOdemeTuruMap());
            modelBuilder.Configurations.Add(new KampanyaAnaMap());
            modelBuilder.Configurations.Add(new KampanyaTuruMap());
            modelBuilder.Configurations.Add(new KampanyaUrunMap());
            modelBuilder.Configurations.Add(new HavuzStokMap());
        }
    }
}
