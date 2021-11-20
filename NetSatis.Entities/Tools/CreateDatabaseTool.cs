using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using NetSatis.Entities.Context;
using NetSatis.Entities.Tables;

namespace NetSatis.Entities.Tools
{
   public class CreateDatabaseTool
   {
       private NetSatisContext _context;
       private XtraForm _form;
        public CreateDatabaseTool(NetSatisContext context,XtraForm form)
        {
            _context = context;
            _form = form;
        }

        public void DatabaseOlustur()
        {
            LoadingTool.LoadingTool animasyon = new LoadingTool.LoadingTool(_form);
            animasyon.AnimasyonBaslat();
            _context.Database.CreateIfNotExists();

                if (!_context.Kullanicilar.Any(c => c.KullaniciAdi == "1"))
                {
                    _context.Kullanicilar.Add(new Kullanici
                    {
                        KullaniciAdi = "1",
                        Parola = "1"
                    });

                _context.Kasalar.Add(new Kasa{KasaKodu = "001",KasaAdi="MERKEZ",YetkiliKodu="001",YetkiliAdi="MERKEZ KASA"});
                _context.OdemeTurleri.Add(new OdemeTuru { OdemeTuruAdi="NAKİT",OdemeTuruKodu="001" });
                _context.OdemeTurleri.Add(new OdemeTuru { OdemeTuruAdi = "KREDİ KARTI", OdemeTuruKodu = "002" });
                _context.Depolar.Add(new Depo {DepoKodu="001",DepoAdi="MERKEZ",YetkiliKodu="001",YetkiliAdi="MERKEZ" });
                _context.Subeler.Add(new Sube { Tanimi="MERKEZ",Turu="MERKEZ",Aciklama="MERKEZ ŞUBE"});
                _context.KampanyaTuru.Add(new KampanyaTuru { KampanyaTuruKodu = "001", KampanyaTuruAdi = "Fiş Toplamı İskonto" });
                _context.KampanyaTuru.Add(new KampanyaTuru { KampanyaTuruKodu = "002", KampanyaTuruAdi = "Fiş Toplamı Ürün İndirimi" });
                _context.KampanyaTuru.Add(new KampanyaTuru { KampanyaTuruKodu = "003", KampanyaTuruAdi = "Adetli Ürün İskonto" });
                _context.KampanyaTuru.Add(new KampanyaTuru { KampanyaTuruKodu = "004", KampanyaTuruAdi = "Fiş Toplamı Ürün İndirimi" });
                _context.KampanyaTuru.Add(new KampanyaTuru { KampanyaTuruKodu = "005", KampanyaTuruAdi = "Ürün Alana Ürün İndirimi" });
                _context.KampanyaTuru.Add(new KampanyaTuru { KampanyaTuruKodu = "006", KampanyaTuruAdi = "Ürün Alana Ürün Bedava" });



            }
                if (!_context.Kodlar.Any(c => c.Tablo == "Fis" && c.OnEki == "FO"))
                {
                    _context.Kodlar.Add(new Kod()
                    {
                        Tablo = "Fis",
                        OnEki = "FO",
                        SonDeger = 1
                    });

                }
            _context.SaveChanges();
         
            animasyon.AnimasyonBitir();
        }
    }
}
