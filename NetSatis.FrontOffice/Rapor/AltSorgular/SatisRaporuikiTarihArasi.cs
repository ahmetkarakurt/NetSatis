using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NetSatis.Entities.Context;

namespace NetSatis.FrontOffice.Rapor.AltSorgular
{
    public partial class SatisRaporuikiTarihArasi : DevExpress.XtraEditors.XtraForm
    {
        public SatisRaporuikiTarihArasi()
        {
          
            InitializeComponent();
            dtBaslangic.EditValue = DateTime.Today.AddSeconds(-1);
            dtBitis.EditValue = DateTime.Today.AddSeconds(-1).AddDays(1);
        }
        NetSatisContext context = new NetSatisContext();
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            var Kasalar = from Kasa in context.KasaHareketleri
                       where Kasa.Tarih >= dtBaslangic.DateTime && Kasa.Tarih <= dtBitis.DateTime
                          group Kasa by new { Kasa.Hareket, Kasa.Kasa.KasaAdi, Kasa.OdemeTuru.OdemeTuruAdi}
                         into eg
                         select new
                         {
                             eg.Key.Hareket,
                             eg.Key.KasaAdi,
                             eg.Key.OdemeTuruAdi,
                             FisSayisi = eg.Count(),
                             Tutar = eg.Sum(rl => rl.Tutar)
                         };
            gridControl1.DataSource = Kasalar.ToList();

            txtKasaCikis.Text = Kasalar.Where(s => s.Hareket == "Kasa Çıkış").Sum(s => s.Tutar).ToString() ?? "0";
            txtKasaGiris.Text= Kasalar.Where(s => s.Hareket == "Kasa Giriş").Sum(s => s.Tutar).ToString() ?? "0";
            lbgenelToplam.Text = " Genel Toplam : " +(Kasalar.Where(s => s.Hareket == "Kasa Giriş").Sum(s => s.Tutar) - Kasalar.Where(s => s.Hareket == "Kasa Çıkış").Sum(s => s.Tutar)).ToString()+" TL ";
        }
        
       // Kasalar.Where(s => s.Hareket == "Kasa Giriş").Sum(s => s.Tutar).ToString() ?? "0";
       // Kasalar.Where(s => s.Hareket == "Kasa Çıkış").Sum(s => s.Tutar).ToString() ?? "0";
    }
}