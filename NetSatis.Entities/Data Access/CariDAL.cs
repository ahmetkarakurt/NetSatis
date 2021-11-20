using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NetSatis.Entities.Context;
using NetSatis.Entities.Interfaces;
using NetSatis.Entities.Repositories;
using NetSatis.Entities.Tables;
using NetSatis.Entities.Validations;

namespace NetSatis.Entities.Data_Access
{
    public class CariDAL : EntityRepositoryBase<NetSatisContext, Cari, CariValidator>
    {
        public object CariListele(NetSatisContext context)
        {
            var result = context.Cariler.GroupJoin(context.CariHareketleri, c => c.CariKodu, c => c.CariKodu,
                (cariler, cariHareketleri) => new
                {
                  
                    cariler.Durumu,
                    cariler.CariKodu,
                    cariler.CariAdi,
                    cariler.CariTuru,
                    cariler.YetkiliKisi,
                    cariler.FaturaUnvani,
                    cariler.CepTelefonu,
                    cariler.Telefon,
                    cariler.Fax,
                    cariler.EMail,
                    cariler.Web,
                    cariler.Il,
                    cariler.Ilce,
                    cariler.Semt,
                    cariler.Adres,
                    cariler.CariGrubu,
                    cariler.CariAltGrubu,
                    cariler.OzelKod1,
                    cariler.OzelKod2,
                    cariler.OzelKod3,
                    cariler.OzelKod4,
                    cariler.VergiNo,
                    cariler.VergiDairesi,
                    cariler.IskontoOrani,
                    cariler.RiskLimiti,
                    cariler.AlisOzelFiyati,
                    cariler.SatisOzelFiyati,
                    cariler.Aciklama,
                    Alacak = cariHareketleri.Sum(c => c.Alacak) ?? 0,
                    Borc = cariHareketleri.Sum(c => c.Borc) ?? 0,
                    Bakiye =  (cariHareketleri.Sum(c => c.Borc) ?? 0) -(cariHareketleri.Sum(c => c.Alacak) ?? 0)    //cariHareketleri.Select(c => (decimal?) (c.Alacak ?? 0 - c.Borc ?? 0)).Sum() ?? 0
                }).ToList();
            return result;
        }

        public object CariFisAyrinti(NetSatisContext context, string CariKodu)
        {
            return (from fis in context.CariHareketleri.Where(c => c.CariKodu == CariKodu)
                select new{
                  //  fis.Id,
                    fis.FisKodu,
                    fis.HareketTuru,
                   // fis.BelgeNo,
                    fis.Tarih,
                    fis.VadeTarihi,
                    //fis.IskontoOrani,
                    //fis.IskontoTutar,
                    fis.Aciklama,
                    fis.Alacak,
                    fis.Borc,
                    Bakiye = context.CariHareketleri.OrderByDescending(c=>c.Tarih).ThenByDescending(c=>c.ID)
                                 .Where(c => c.CariKodu == CariKodu && c.Tarih <= fis.Tarih && c.ID <= fis.ID)
                                 .Select(c => (decimal?) (c.Alacak ?? 0 - c.Borc ?? 0))
                                 .Sum() ?? 0
                }).OrderByDescending(c => c.Tarih).ToList();
        }

        public object CariFisGenelToplam(NetSatisContext context, string CariKodu)
        {
            var result = (from c in context.CariHareketleri.Where(c => c.CariKodu == CariKodu)
                          group c by new { c.HareketTuru }
                into grp
                          select new
                          {
                              Bilgi = grp.Key.HareketTuru,
                              KayitSayisi = grp.Count(),
                              Tutar = grp.Sum(c => c.Alacak??c.Borc)
                          }).ToList();
            return result;
        }

        public object CariGenelToplam(NetSatisContext context, string CariKodu)
        {
            decimal alacak = context.CariHareketleri.Where(c => c.CariKodu == CariKodu).Sum(c => c.Alacak) ?? 0;           
            decimal borc = context.CariHareketleri.Where(c => c.CariKodu == CariKodu).Sum(c => c.Borc) ?? 0;


            List<GenelToplam> genelToplamlar = new List<GenelToplam>()
            {
                new GenelToplam
                {
                    Bilgi = "Alacak",
                    Tutar = alacak
                },
                new GenelToplam
                {
                Bilgi = "Borç",
                Tutar = borc
                },
                new GenelToplam
                {
                    Bilgi = "Bakiye",
                    Tutar = alacak-borc
                }
            };
            return genelToplamlar;
        }

        public CariBakiye CariBakiyesi(NetSatisContext context, string CariKodu)
        {
            decimal alacak = context.CariHareketleri.Where(c => c.CariKodu == CariKodu).Sum(c => c.Alacak) ?? 0;
            decimal borc = context.CariHareketleri.Where(c => c.CariKodu == CariKodu).Sum(c => c.Borc) ?? 0;
            CariBakiye entity=new CariBakiye
            {
                CariKodu = CariKodu,
                RiskLimiti=Convert.ToDecimal(context.Cariler.SingleOrDefault(c => c.CariKodu == CariKodu).RiskLimiti),
                Alacak = alacak,
                Borc = borc,
                Bakiye = alacak-borc
            };
            return entity;
        }

        public object CariTelefonlari(NetSatisContext context)
        {
            var result = (from c in context.Cariler
                select new
                {
                    c.CariKodu,
                    c.CariAdi,
                    c.CepTelefonu
                }).ToList();
            return result;
        }
    }


}
