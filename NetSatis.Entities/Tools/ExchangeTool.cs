using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using NetSatis.Entities.Tables.OtherTables;

namespace NetSatis.Entities.Tools
{
   public class ExchangeTool
    {
        public List<DovizKurlari> DovizKuruCek()
        {
            if (!File.Exists(Application.StartupPath + "\\Kurlar.xml"))
            {
                using (WebClient kurIndir = new WebClient())
                {
                    kurIndir.DownloadFile("http://www.tcmb.gov.tr/kurlar/today.xml", Application.StartupPath + "\\Kurlar.xml");
                }
            }


            XElement kurlar = XElement.Load(Application.StartupPath + "\\Kurlar.xml");

            List<DovizKurlari> listKurlar = new List<DovizKurlari>();

            string ondalikKarakter = System.Globalization.CultureInfo.CurrentCulture.NumberFormat
                .CurrencyDecimalSeparator.ToString();

            foreach (var itemElement in kurlar.Elements().Where(c => c.Attribute("CurrencyCode").Value != "XDR").ToList())
            {
                listKurlar.Add(new DovizKurlari
                {
                    CurrencyCode = itemElement.Attribute("CurrencyCode").Value,
                    Isim = itemElement.Element("Isim").Value,
                    ForexBuying = Convert.ToDecimal(itemElement.Element("ForexBuying").Value.Replace(".", ondalikKarakter)),
                    ForexSelling = Convert.ToDecimal(itemElement.Element("ForexSelling").Value.Replace(".", ondalikKarakter)),
                    BanknoteBuying = itemElement.Element("BanknoteBuying").Value == "" ? 0 : Convert.ToDecimal(itemElement.Element("BanknoteBuying").Value.Replace(".", ondalikKarakter)),
                    BanknoteSelling = itemElement.Element("BanknoteSelling").Value == "" ? 0 : Convert.ToDecimal(itemElement.Element("BanknoteSelling").Value.Replace(".", ondalikKarakter))
                });
            }

            return listKurlar;
        }
    }
}
