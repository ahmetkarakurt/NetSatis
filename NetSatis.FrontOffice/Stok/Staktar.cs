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
using System.IO;
using Newtonsoft.Json;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Context;

namespace NetSatis.FrontOffice.Stok
{
    public partial class Staktar : DevExpress.XtraEditors.XtraForm
    {
        public Staktar()
        {
            InitializeComponent();
        }
        private Entities.Tables.Stok _entity;
        private StokDAL stokDal = new StokDAL();
        private NetSatisContext context = new NetSatisContext();
        public class RootObject
        {
            public string StokKodu { get; set; }
            public string StokAdi { get; set; }
            public string Barkod { get; set; }
            public string BarkodTuru { get; set; }
            public string Birimi { get; set; }
            public string StokGrubu { get; set; }
            public string StokAltGrubu { get; set; }
            public string Marka { get; set; }
            public string Modeli { get; set; }
            public string OzelKod1 { get; set; }
            public string OzelKod2 { get; set; }
            public string OzelKod3 { get; set; }
            public string OzelKod4 { get; set; }
            public string GarantiSuresi { get; set; }
            public string UreticiKodu { get; set; }
            public int AlisKdv { get; set; }
            public int SatisKdv { get; set; }
            public decimal? AlisFiyati1 { get; set; }
            public decimal? AlisFiyati2 { get; set; }
            public decimal? AlisFiyati3 { get; set; }
            public decimal? SatisFiyati1 { get; set; }
            public decimal? SatisFiyati2 { get; set; }
            public decimal? SatisFiyati3 { get; set; }
            public decimal? MinStokMiktari { get; set; }
            public decimal? MaxStokMiktari { get; set; }
            public string Aciklama { get; set; }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            StreamReader reader = new StreamReader("ST.txt");
            string resultStoklar = reader.ReadToEnd();
            NetSatis.Entities.Tables.Stok stok = new Entities.Tables.Stok();

          //  List<NetSatis.Entities.Tables.Stok> stoks = 
            var model =JsonConvert.DeserializeObject<List<Entities.Tables.Stok>>(resultStoklar);

            // NetSatis.Entities.Tables.Stok Stoklar = JsonConvert.DeserializeObject<NetSatis.Entities.Tables.Stok>(resultStoklar);
  reader.Close();

            gridcontStoklar.DataSource = model.ToList();

            //   _entity = model.ToList();

            foreach (var item in model)
            {
                stok = new Entities.Tables.Stok { 
                StokAdi= item.StokAdi,
                Aciklama= item.Aciklama,
                AlisFiyati1=item.AlisFiyati1,
                AlisFiyati2 = item.AlisFiyati2,
                AlisFiyati3 = item.AlisFiyati3,
                AlisKdv = item.AlisKdv,
                Birimi = item.Birimi,
                SatisFiyati1 = item.SatisFiyati1,
                SatisFiyati2 = item.SatisFiyati2,
                SatisFiyati3 = item.SatisFiyati3,
                StokKodu = item.StokKodu



                };

                   if (stokDal.AddOrUpdate(context, stok))
                   {
                      
                   }

               
            }
            stokDal.Save(context);
            //  

        }

        private void Staktar_Load(object sender, EventArgs e)
        {

        }
    }
}