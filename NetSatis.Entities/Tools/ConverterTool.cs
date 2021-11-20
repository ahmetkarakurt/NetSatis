using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tables;

namespace NetSatis.Entities.Tools
{
    public static class ConverterTool
    {
        private static StokHareket StokToStokHareket(NetSatisContext context,Entities.Tables.Stok entity,decimal miktar)
        {
            StokHareket stokHareket = new StokHareket();
            IndirimDaL indirimDal = new IndirimDaL();
            stokHareket.StokKodu = entity.StokKodu;
            stokHareket.IndirimOrani = indirimDal.StokIndirimi(context, entity.StokKodu);
            stokHareket.DepoId =Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_VarsayilanDepo));
            //stokHareket.BirimFiyati = txtFisTuru.Text == "Alış Faturası" ? entity.AlisFiyati1 : entity.SatisFiyati1;
            stokHareket.Miktar = miktar;
            stokHareket.Tarih = DateTime.Now;
            stokHareket.Kdv = entity.SatisKdv;
            return stokHareket;
        }

        public static decimal StringToDecimal(string ifade,string ondalikAyrac)
        {
            string ondalikKarakter = System.Globalization.CultureInfo.CurrentCulture.NumberFormat
                .CurrencyDecimalSeparator.ToString();
            return Convert.ToDecimal(ifade.Replace(ondalikAyrac, ondalikKarakter));
        }
    }
}
