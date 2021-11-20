using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSatis.Entities.Context;
using NetSatis.Entities.Mapping;
using NetSatis.Entities.Repositories;
using NetSatis.Entities.Tables;
using NetSatis.Entities.Validations;

namespace NetSatis.Entities.Data_Access
{
    public class KampanyaAnaDaL : EntityRepositoryBase<NetSatisContext, KampanyaAna, KampanyaAnaValidator>
    {
        public object KampanyaListele(NetSatisContext context)
        {
            var result = (from c in context.KampanyaAna select c).AsEnumerable().Select(c => new
            {
               
                IndirimAktif=Aktif(c.KampanyaTuru,Convert.ToDateTime(c.BitisTarihi),c.Durumu),
                c.Durumu,
                c.KampanyaKod,
                c.KampanyaAdi,
                c.KampanyaTuru,
                c.BaslangicTarihi,
                c.BitisTarihi,
                c.IndirimOrani,
                c.KampanyaFiyat,
                c.SubeId,              
                c.Aciklama
            }).ToList();
            return result;
        }

        public decimal StokIndirimi(NetSatisContext context,string stokKodu)
        {
            decimal sonuc = 0;
            var result = (from c in context.Indirimler.Where(c=>c.StokKodu==stokKodu) select c).AsEnumerable().Select(c => new
            {
                IndirimAktif = Aktif(c.IndirimTuru, Convert.ToDateTime(c.BitisTarihi), c.Durumu),
                c.IndirimOrani,
            }).SingleOrDefault();
            if (result!=null && result.IndirimAktif==true)
            {
                sonuc = result.IndirimOrani;
            }
            return sonuc;
        }

        bool Aktif(string KampanyaTuru, DateTime BitisTarihi, bool Durum)
        {
            bool result = false;
            if (Durum)
            {
                if (KampanyaTuru == "Süresiz")
                {
                    result = true;
                }
                else
                {
                    if (DateTime.Now<=BitisTarihi)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}
