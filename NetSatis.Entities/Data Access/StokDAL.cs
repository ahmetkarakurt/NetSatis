﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NetSatis.Entities.Context;
using NetSatis.Entities.Repositories;
using NetSatis.Entities.Tables;
using NetSatis.Entities.Tables.OtherTables;
using NetSatis.Entities.Validations;

namespace NetSatis.Entities.Data_Access
{
    public class StokDAL:EntityRepositoryBase<NetSatisContext,Stok,StokValidator>
    {
        public object StokListele(NetSatisContext context)
        {
            var tablo = context.Stoklar.GroupJoin(context.StokHareketleri, c => c.StokKodu, c => c.StokKodu,
                     (Stoklar, StokHareketleri) =>
                         new
                         {
                             Stoklar.Durumu,
                             Stoklar.StokKodu,
                             Stoklar.StokAdi,
                             Stoklar.Barkod,
                             Stoklar.BarkodTuru,
                             Stoklar.Birimi,
                             Stoklar.StokGrubu,
                             Stoklar.StokAltGrubu,
                             Stoklar.Marka,
                             Stoklar.Modeli,
                             Stoklar.OzelKod1,
                             Stoklar.OzelKod2,
                             Stoklar.OzelKod3,
                             Stoklar.OzelKod4,
                             Stoklar.GarantiSuresi,
                             Stoklar.UreticiKodu,
                             Stoklar.AlisKdv,
                             Stoklar.SatisKdv,
                             Stoklar.AlisFiyati1,
                             Stoklar.AlisFiyati2,
                             Stoklar.AlisFiyati3,
                             Stoklar.SatisFiyati1,
                             Stoklar.SatisFiyati2,
                             Stoklar.SatisFiyati3,
                             Stoklar.MinStokMiktari,
                             Stoklar.MaxStokMiktari,
                             Stoklar.Terazi,
                             Stoklar.TeraziDurum,
                             Stoklar.Aciklama,
                             StokGiris = StokHareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Giriş").Sum(c => c.Miktar) ?? 0,
                             StokCikis = StokHareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Çıkış").Sum(c => c.Miktar) ?? 0,
                             MevcutStok = (StokHareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Giriş").Sum(c => c.Miktar)??0) -
                                          (StokHareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Çıkış").Sum(c => c.Miktar) ?? 0)
                         }).ToList();
            return tablo;
        }

        public StokBakiye StokBakiyesi(NetSatisContext context, string StokKodu)
        {
            return new StokBakiye
            {
                StokKodu = StokKodu,
                StokGiris = context.StokHareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Giriş").Sum(c => c.Miktar) ?? 0,
                StokCikis = context.StokHareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Çıkış").Sum(c => c.Miktar) ?? 0,
                MevcutStok = (context.StokHareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Giriş").Sum(c => c.Miktar) ?? 0) -
                             (context.StokHareketleri.Where(c => c.Siparis == false && c.Hareket == "Stok Çıkış").Sum(c => c.Miktar) ?? 0)
            };
        }
    }
}
