using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using NetSatis.Entities.Context;
using NetSatis.Entities.Tables;

namespace NetSatis.Entities.Tools
{
    public static class SettingsTool
    {
        static FileIniDataParser parser = new FileIniDataParser();
        static IniData data;
        static string dosyaAdi = "Settings.ini";
     //   static NetSatisContext context = new NetSatisContext();

        static SettingsTool()
        {
            if (System.IO.File.Exists(Application.StartupPath + "\\" + dosyaAdi) == true)
            {
                data = parser.ReadFile(dosyaAdi);
            }
            else
            {
                using (System.IO.File.Create(Application.StartupPath + "\\" + dosyaAdi))
                {

                };
                data = parser.ReadFile(dosyaAdi);
            }
        }

        public enum Ayarlar
        {
            SmsAyarları_KullanıcıAdı,
            SmsAyarları_Parola,
            SatisAyarlari_VarsayilanDepo,
            SatisAyarlari_VarsayilanKasa,
            SatisAyarlari_FaturaYazdirmaAyari,
            SatisAyarlari_BilgiFisiYazdirmaAyari,
            SatisAyarlari_FaturaYazici,
            SatisAyarlari_BilgiFisiYazici,
            SatisAyarlari_FisKodu,
            SatisAyarlari_KullaniciTema,

            SatisAyarlari_KasaAdi,
            SatisAyarlari_TeraziSistemi,
            SatisAyarlari_KasaOnEkKodu,

            YedeklemeAyarlari_YedeklemeKonumu,
            YedeklemeAyarlari_OtomatikYedekleme,
            YedeklemeAyarlari_SonYedekleme,
            GenelAyalar_GuncellemeKontrol,
            DatabaseAyarlari_BaglantiCumlesi,
            FirmaAyarlari_FirmaAdi,
            //
            FirmaAyarlari_SubeliSistem




        }

        public static void AyarDegistir(Ayarlar ayar, string value)
        {

            string[] GelenAyar = ayar.ToString().Split(Convert.ToChar("_"));
            if (data!=null)
            {
                if (data.Sections.Count(c=>c.SectionName==GelenAyar[0])==0)
                {
                    data.Sections.AddSection(GelenAyar[0]);
                    data[GelenAyar[0]].AddKey(GelenAyar[1]);
                }
                else
                {
                    data[GelenAyar[0]].AddKey(GelenAyar[1]);
                }
                data[GelenAyar[0]][GelenAyar[1]] = value;
            }
            
            
            
            /*   veri tabanı kayıt
            if (context.Ayarlar.Any(c => c.AyarAdi == ayar.ToString()))
            {
                context.Ayarlar.SingleOrDefault(c => c.AyarAdi == ayar.ToString()).Deger = value;
            }
            else
            {
                context.Ayarlar.Add(new Ayar
                {
                    AyarAdi = ayar.ToString(),
                    Deger = value
                });
            }
            */
        }



        public static string AyarOku(Ayarlar ayar)
        {/*veritabanı*/
            /* return context.Ayarlar.SingleOrDefault(c => c.AyarAdi == ayar.ToString())?.Deger;*/
            string[] GelenAyar = ayar.ToString().Split(Convert.ToChar("_"));

            return data[GelenAyar[0]][GelenAyar[1]];
        }


        public static void Save()
        {
            /*context.SaveChanges();*/

            parser.WriteFile(dosyaAdi, data);
        }

    }
}
