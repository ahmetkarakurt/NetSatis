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
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tables;
using NetSatis.Entities.Tools;
using NetSatis.Reports.Fatura_ve_Fiş;

namespace NetSatis.FrontOffice.Rapor
{
    public partial class FrmRapor : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        int Sube = 1;
             string Kasiyer = "-1";
        public FrmRapor(int _sube,String _kasiyer)
        {
            InitializeComponent();
            Sube = _sube;
            Kasiyer = _kasiyer;
        }


     
        private void FrmRapor_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
          /*  gridControl1.DataSource = null;
            gridView1.Columns.Clear();

            //  gridControl1.DataSource = kasaHareketDal.GetAll(context);
            gridControl1.DataSource = KasaHareket(context);*/
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
       /*     gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = Fisler(context);*/
        }



        public object OdemeTuruListele(NetSatisContext context)
        {
            var result = context.OdemeTurleri.GroupJoin(context.KasaHareketleri, c => c.Id, c => c.OdemeTuruId,
                (odemeturu, kasahareket) => new
                {

                    odemeturu.OdemeTuruKodu,
                    odemeturu.OdemeTuruAdi,
                    odemeturu.Aciklama,
                    KasaGiris = (kasahareket.Where(c => c.OdemeTuruId == odemeturu.Id && c.Hareket == "Kasa Giriş").Sum(c => c.Tutar) ?? 0),
                    KasaCikis = (kasahareket.Where(c => c.OdemeTuruId == odemeturu.Id && c.Hareket == "Kasa Çıkış").Sum(c => c.Tutar) ?? 0),
                    Bakiye = (kasahareket.Where(c => c.OdemeTuruId == odemeturu.Id && c.Hareket == "Kasa Giriş").Sum(c => c.Tutar) ?? 0) - 
                    (kasahareket.Where(c => c.OdemeTuruId == odemeturu.Id && c.Hareket == "Kasa Çıkış").Sum(c => c.Tutar) ?? 0)
                }).ToList();
            return result;
        }
        public object Fisler(NetSatisContext context)
        {
            var result = from e in context.Fisler
                         where e.SubeId==Sube || e.KasıyerID==Kasiyer
                         group e by new { e.FisTuru, e.Sube.Tanimi,e.KasıyerID } 
                         
                         into eg
   
                         select new 
                         { 
                             eg.Key.FisTuru, 
                             eg.Key.KasıyerID, 
                             eg.Key.Tanimi ,
                             Tutar = eg.Sum(rl => rl.ToplamTutar) 
                         };

            return result.ToList();
        }

        public object KasaHareket(NetSatisContext context)
        {
            var result = from e in context.KasaHareketleri
                        // where e.FisKodu == "BS0000000012"
                         group e by new { e.Hareket, e.Kasa.KasaAdi, e.OdemeTuru.OdemeTuruAdi,e.KasıyerID,e.Sube.Tanimi }
                         into eg
                         select new
                         {
                             eg.Key.Hareket,
                             eg.Key.KasaAdi,
                             eg.Key.OdemeTuruAdi,
                             eg.Key.KasıyerID,
                             eg.Key.Tanimi,
                             Tutar = eg.Sum(rl => rl.Tutar)
                         };

            return result.ToList();


        }
        public object ZRaporuKasaHareket(NetSatisContext context ,DateTime Tarih)
        {
            var result = from e in context.KasaHareketleri
                             where e.Tarih >= Tarih && e.Tarih <= DateTime.Now
                         group e by new { e.Hareket, e.Kasa.KasaAdi, e.OdemeTuru.OdemeTuruAdi, e.KasıyerID, e.Sube.Tanimi }
                         into eg
                         select new
                         {
                             eg.Key.Hareket,
                             eg.Key.KasaAdi,
                             eg.Key.OdemeTuruAdi,
                             eg.Key.KasıyerID,
                             eg.Key.Tanimi,
                            FisSayisi= eg.Count(),
                             Tutar = eg.Sum(rl => rl.Tutar)
                         };

            return result.ToList();
        }


       
        private void simpleButton3_Click(object sender, EventArgs e)
        {
         
            ZRaporlariDAL zRaporDal = new ZRaporlariDAL();
            var bilgi = context.ZRaporlari.Where(c => c.KasıyerID == Kasiyer && c.SubeId == Sube && c.Turu == "Z Raporu").OrderByDescending(c=>c.Tarih).FirstOrDefault();

            if (bilgi == null)
            {
             /*   gridControl1.DataSource = null;
                gridView1.Columns.Clear();
                gridControl1.DataSource = KasaHareket(context);
*/
            }
            else
            {
             /*   gridControl1.DataSource = null;
                gridView1.Columns.Clear();
                gridControl1.DataSource = ZRaporuKasaHareket(context,Convert.ToDateTime(bilgi.Tarih));
               */// MessageBox.Show(bilgi.Tarih.ToString());
            }


                    zRaporDal.AddOrUpdate(context, new ZRaporlari
                 {
                     Turu ="Z Raporu",
                     KasıyerID=Kasiyer,
                     SubeId=Sube,
                     Tarih=DateTime.Now
            
                  });
                context.SaveChanges();

            try
            {
                Yazdir(Kasiyer, Sube, "Z Raporu", Convert.ToDateTime(bilgi.Tarih), DateTime.Now, bilgi.Id);
            }
            catch (Exception)
            {

                MessageBox.Show("Rapor Almayı Tekrar Deneyiniz");
            }
        }

        private void Yazdir(string kasiyer, int sube, string Turu, DateTime Tarih, DateTime Alm_Tarihi,int ZraporID)
        {
          //  ReportsPrintTool.Belge.ZRaporu;
            ReportsPrintTool yazdirBilgiFisi = new ReportsPrintTool();
            rptZraporu Zrapor = new rptZraporu(kasiyer, sube, Turu, Tarih,Alm_Tarihi, ZraporID) ;
            yazdirBilgiFisi.RaporYazdir(Zrapor, ReportsPrintTool.Belge.ZRaporu);
            this.Close();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
       
            ZRaporlariDAL zRaporDal = new ZRaporlariDAL();
            var bilgi = context.ZRaporlari.Where(c => c.KasıyerID == Kasiyer && c.SubeId == Sube && c.Turu == "Z Raporu").OrderByDescending(c => c.Tarih).FirstOrDefault();
            Yazdir(Kasiyer, Sube, "X Raporu", Convert.ToDateTime(bilgi.Tarih), DateTime.Now, bilgi.Id);
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            AltSorgular.SatisRaporuikiTarihArasi satisRaporuikiTarihArasi = new AltSorgular.SatisRaporuikiTarihArasi();
            satisRaporuikiTarihArasi.ShowDialog();
        }
    }
}