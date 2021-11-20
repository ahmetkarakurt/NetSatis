using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSatis.Entities.Context;
using NetSatis.Entities.Repositories;
using NetSatis.Entities.Tables;
using NetSatis.Entities.Validations;

namespace NetSatis.Entities.Data_Access
{
    public class BankaDAL : EntityRepositoryBase<NetSatisContext, Banka,BankaValidator>
    {
        public object BanklaListele(NetSatisContext context)
        {
            var result = context.Banka.GroupJoin(context.BankaHareket, c => c.Id, c => c.BankaId,
                (banka, bankahareket) => new
                {
                    banka.Id,
                    banka.BankaKodu,
                    banka.BankaAdi,
                    banka.YetkiliKodu,
                    banka.YetkiliAdi,
                    banka.Aciklama,
                    KasaGiris=(bankahareket.Where(c=>c.BankaId== banka.Id && c.Hareket=="Kasa Giriş").Sum(c=>c.Tutar) ?? 0),
                    KasaCikis=(bankahareket.Where(c => c.BankaId == banka.Id && c.Hareket == "Kasa Çıkış").Sum(c => c.Tutar) ?? 0),
                    Bakiye= (bankahareket.Where(c => c.BankaId == banka.Id && c.Hareket == "Kasa Giriş").Sum(c => c.Tutar) ?? 0)- (bankahareket.Where(c => c.BankaId == banka.Id && c.Hareket == "Kasa Çıkış").Sum(c => c.Tutar) ?? 0)
                }).ToList();
            return result;
        }

        public object OdemeTuruToplamListele(NetSatisContext context,int bankaId)
        {
            //var result = (from c in context.BankaHareket.Where(c => c.BankaId == bankaId)
            //    group c by new {c.OdemeTuru}
            //    into grp
            //    select new
            //    {
            //        grp.Key.OdemeTuru.OdemeTuruAdi,
            //        KasaGiris=(grp.Where(c=>c.OdemeTuruId== grp.Key.OdemeTuru.Id && c.Hareket=="Kasa Giriş").Sum(c=>c.Tutar) ?? 0),
            //        KasaCikis= (grp.Where(c => c.OdemeTuruId == grp.Key.OdemeTuru.Id && c.Hareket == "Kasa Çıkış").Sum(c => c.Tutar) ?? 0),
            //        Bakiye= (grp.Where(c => c.OdemeTuruId == grp.Key.OdemeTuru.Id && c.Hareket == "Kasa Giriş").Sum(c => c.Tutar) ?? 0)- 
            //                (grp.Where(c => c.OdemeTuruId == grp.Key.OdemeTuru.Id && c.Hareket == "Kasa Çıkış").Sum(c => c.Tutar) ?? 0)
            //    }).ToList();

            var result = (from p in context.BankaHareket.Where(c => c.BankaId == bankaId)
                         group p by p.OdemeTuru into g
                         select new
                         {
                             OdemeTuru=  g.Key,
                             KasaGiris = (g.Where(p=>p.OdemeTuru==g.Key && p.Hareket== "Kasa Giriş").Sum(p=>p.Tutar)??0),
                             KasaCikis= (g.Where(p => p.OdemeTuru == g.Key && p.Hareket == "Kasa Çıkış").Sum(p => p.Tutar) ?? 0),
                             Bakiye = (g.Where(p => p.OdemeTuru == g.Key && p.Hareket == "Kasa Giriş").Sum(p => p.Tutar) ?? 0)-
                             (g.Where(p => p.OdemeTuru == g.Key && p.Hareket == "Kasa Çıkış").Sum(p => p.Tutar) ?? 0)
                         }).ToList();


            return result;
        }

        public object GenelToplamListele(NetSatisContext context, int kasaId)
        {
            decimal KasaGiris = context.BankaHareket.Where(c => c.BankaId == kasaId && c.Hareket == "Kasa Giriş").Sum(c => c.Tutar) ?? 0;
            int KasaGirisKayitSayisi = context.BankaHareket
                .Where(c => c.BankaId == kasaId && c.Hareket == "Kasa Giriş").Count();
            decimal KasaCikis = context.BankaHareket.Where(c => c.BankaId == kasaId && c.Hareket == "Kasa Çıkış").Sum(c => c.Tutar) ?? 0;
            int KasaCikissKayitSayisi = context.BankaHareket
                .Where(c => c.BankaId == kasaId && c.Hareket == "Kasa Çıkış").Count();

            List<GenelToplam> genelToplamlar = new List<GenelToplam>()
            {
                new GenelToplam
                {
                    Bilgi = "Kasa Giriş",
                    KayitSayisi = KasaGirisKayitSayisi,
                    Tutar = KasaGiris
                },
                new GenelToplam
                {
                    Bilgi = "Kasa Çıkış",
                    KayitSayisi = KasaCikissKayitSayisi,
                    Tutar = KasaCikis
                },
                new GenelToplam
                {
                    Bilgi = "Bakiye",
                    KayitSayisi = KasaCikissKayitSayisi+KasaGirisKayitSayisi,
                    Tutar = KasaGiris-KasaCikis
                }
            };
            return genelToplamlar;
        }
    }
}
