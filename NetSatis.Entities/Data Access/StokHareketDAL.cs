using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSatis.Entities.Context;
using NetSatis.Entities.Repositories;
using NetSatis.Entities.Tables;
using NetSatis.Entities.Validations;

namespace NetSatis.Entities.Data_Access
{
    public class StokHareketDAL : EntityRepositoryBase<NetSatisContext, StokHareket, StokHareketValidator>
    {
        public object GetGenelStok(NetSatisContext context, string StokKodu)
        {
            var result = (from c in context.StokHareketleri.Where(c => c.Siparis == false && c.StokKodu == StokKodu)
                          group c by new { c.Hareket } into g
                          select new
                          {
                              Bilgi = g.Key.Hareket,
                              KayitSayisi = g.Count(),
                              Toplam = g.Sum(d => d.Miktar)
                          }).ToList();
            return result;
        }

        public object GetDepoStok(NetSatisContext context, string StokKodu)
        {
            var result = context.Depolar.GroupJoin(context.StokHareketleri.Where(c =>c.Siparis == false && c.StokKodu == StokKodu),
                c => c.Id, c => c.DepoId, (depolar, stokhareketleri) => new
                {
                    depolar.DepoKodu,
                    depolar.DepoAdi,
                    StokGiris = stokhareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Giriş").Sum(c => c.Miktar) ?? 0,
                    StokCikis = stokhareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Çıkış").Sum(c => c.Miktar) ?? 0,
                    MevcutStok = (stokhareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Giriş").Sum(c => c.Miktar) ?? 0) - (stokhareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Çıkış").Sum(c => c.Miktar) ?? 0)
                }).ToList();
            return result;
        }

        public object DepoStokListele(NetSatisContext context, int depoId)
        {
            var tablo = context.Stoklar.GroupJoin(context.StokHareketleri.Where(c => c.Siparis==false && c.DepoId == depoId), c => c.StokKodu, c => c.StokKodu,
                     (Stoklar, StokHareketleri) =>
                         new
                         {
                             Stoklar.StokAdi,
                             Stoklar.Barkod,
                             StokGiris = StokHareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Giriş").Sum(c => c.Miktar) ?? 0,
                             StokCikis = StokHareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Çıkış").Sum(c => c.Miktar) ?? 0,
                             MevcutStok = StokHareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Giriş").Sum(c => c.Miktar) -
                                          StokHareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Çıkış").Sum(c => c.Miktar) ?? 0
                         }).ToList();
            return tablo;
        }
      
        public object DepoIstatistikListele(NetSatisContext context, int depoId)
        {


            List<GenelToplam> genelToplamlar = new List<GenelToplam>()
            {
                new GenelToplam
                {
                    Bilgi = "Stok Giriş",
                    KayitSayisi = context.StokHareketleri.Where(c=> c.Siparis==false && c.DepoId==depoId && c.Hareket=="Stok Giriş").Count(),
                    Tutar = context.StokHareketleri.Where(c=>c.DepoId==depoId  && c.Hareket=="Stok Giriş").Sum(c=>c.Miktar) ?? 0
                },
                new GenelToplam
                {
                    Bilgi = "Stok Giriş",
                    KayitSayisi = context.StokHareketleri.Where(c=>c.Siparis==false &&c.DepoId==depoId  && c.Hareket=="Stok Çıkış").Count(),
                    Tutar = context.StokHareketleri.Where(c=>c.Siparis==false &&c.DepoId==depoId  && c.Hareket=="Stok Çıkış").Sum(c=>c.Miktar) ?? 0
                },
            };
            return genelToplamlar;
        }
    }
}
