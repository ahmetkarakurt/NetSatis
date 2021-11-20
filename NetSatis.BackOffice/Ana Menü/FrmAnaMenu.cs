using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using NetSatis.Admin;
using NetSatis.BackOffice.Ajanda;
using NetSatis.BackOffice.Ana_Menü;
using NetSatis.BackOffice.Ayarlar;
using NetSatis.BackOffice.Cari;
using NetSatis.BackOffice.Depo;
using NetSatis.BackOffice.Döviz_Kurları;
using NetSatis.BackOffice.Fiyat_Değiştir;
using NetSatis.BackOffice.Fiş;
using NetSatis.BackOffice.Hızlı_Satış;
using NetSatis.BackOffice.Kasa;
using NetSatis.BackOffice.Kasa_Hareketleri;
using NetSatis.BackOffice.Kod;
using NetSatis.BackOffice.Personel;
using NetSatis.BackOffice.Raporlar;
using NetSatis.BackOffice.Sms;
using NetSatis.BackOffice.Stok;
using NetSatis.BackOffice.Stok_Hareketleri;
using NetSatis.BackOffice.Banka;
using NetSatis.BackOffice.Tanım;
using NetSatis.BackOffice.Ödeme_Türü;
using NetSatis.BackOffice.İndirim;
using NetSatis.Backup;
using NetSatis.Entities;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tables;
using NetSatis.Entities.Tools;
using NetSatis.Update;
using NetSatis.BackOffice.Kampanya;

namespace NetSatis.BackOffice
{
    public partial class FrmAnaMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmAnaMenu()
        {
            InitializeComponent();
            FrmKullaniciGiris girisForm = new FrmKullaniciGiris();
            girisForm.ShowDialog();

            try
            {
                barKullaniciAdi.Caption = $"Giriş Yapan Kullanıcı : {RoleTool.KullaniciEntity.KullaniciAdi}";
            }
            catch (Exception e)
            {
            }


            if (SettingsTool.AyarOku(SettingsTool.Ayarlar.YedeklemeAyarlari_OtomatikYedekleme) == "true" && Convert.ToDateTime(SettingsTool.AyarOku(SettingsTool.Ayarlar.YedeklemeAyarlari_SonYedekleme)).Date.AddDays(15) == DateTime.Now.Date)
            {
                NetSatisContext context = new NetSatisContext();
                string sqlCumle =
                    $"USE Netsatis;BACKUP DATABASE NetSatis TO DISK='{SettingsTool.AyarOku(SettingsTool.Ayarlar.YedeklemeAyarlari_YedeklemeKonumu) + "\\NetSatisYedek.nsy"}'";
                context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sqlCumle);
                SettingsTool.AyarDegistir(SettingsTool.Ayarlar.YedeklemeAyarlari_SonYedekleme, DateTime.Now.Date.ToString());
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FrmAnaMenuBilgi form = new FrmAnaMenuBilgi();
            form.MdiParent = this;
            form.Show();
            RoleTool.RolleriYukle(ribbonControl1);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmStok>().Any())
            {
                FrmStok form = new FrmStok();
                form.MdiParent = this;
                form.Show();
            }
    
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmCari>().Any())
            {
                FrmCari form = new FrmCari();
                form.MdiParent = this;
                form.Show();
            }
        }
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmFis>().Any())
            {
                FrmFis form = new FrmFis();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmDepo>().Any())
            {
                FrmDepo form = new FrmDepo();
                form.MdiParent = this;
                form.Show();
            }
       
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
   
            if (!Application.OpenForms.OfType<FrmKasa>().Any())
            {
                FrmKasa form = new FrmKasa();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmOdemeTuru>().Any())
            {
                FrmOdemeTuru form = new FrmOdemeTuru();
                form.MdiParent = this;
                form.Show();
            }
        
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmStokHareketleri>().Any())
            {
                FrmStokHareketleri form = new FrmStokHareketleri();
                form.MdiParent = this;
                form.Show();
            }
     
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmKasaHareketleri>().Any())
            {
                FrmKasaHareketleri form = new FrmKasaHareketleri();
                form.MdiParent = this;
                form.Show();
            }
      
        }
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmPersonel>().Any())
            {
                FrmPersonel form = new FrmPersonel();
                form.MdiParent = this;
                form.Show();
            }

        }

        private void FisIslem_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var context=new NetSatisContext())
            {
                if (context.OdemeTurleri.Any() || context.Kasalar.Any() || context.Depolar.Any())
                {
                   
                    FrmFisIslem form = new FrmFisIslem(null, e.Item.Caption);
                    form.ShowDialog();
                }else
                {
                    MessageBox.Show("Ödeme Türü, Kasa, ve Depo eklemeden fatura oluşturulamaz.");
                }
            }

        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmTopluFiyat>().Any())
            {
                FrmTopluFiyat form = new FrmTopluFiyat();
                form.MdiParent = this;
                form.Show();
            }
   
        }
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmIndirim>().Any())
            {
                FrmIndirim form = new FrmIndirim();
                form.MdiParent = this;
                form.Show();
            }
    
        }
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start($"{Application.StartupPath}\\NetSatis.FrontOffice.exe");
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmRaporListesi>().Any())
            {
                FrmRaporListesi form = new FrmRaporListesi();
                form.MdiParent = this;
                form.Show();
            }
 
        }
        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmRaporDuzenle>().Any())
            {
                FrmRaporDuzenle form = new FrmRaporDuzenle();
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
  
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmEtiketOlustur form = new FrmEtiketOlustur();
            form.ShowDialog();
        }
        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmOzgunRaporHazirla form = new FrmOzgunRaporHazirla();
            form.ShowDialog();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmAjanda>().Any())
            {
                FrmAjanda form = new FrmAjanda();
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
 

        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDovizKurlari form = new FrmDovizKurlari();
            form.ShowDialog();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSms form = new FrmSms();
            form.ShowDialog();
        }
        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmHizliSatis form = new FrmHizliSatis();
            form.ShowDialog();
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmAyarlar form = new FrmAyarlar(); form.ShowDialog();
        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmBackup form = new FrmBackup();
            form.ShowDialog();
        }
        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WebClient indir = new WebClient();
            string programVersion = Assembly.Load("NetSatis.BackOffice").GetName().Version.ToString();
            string guncelVersion = indir.DownloadString("http://www.tesyazilim.com/downloads/version.txt").Replace("\n", "");

            if (programVersion != guncelVersion)
            {
                Process.Start($"{Application.StartupPath}\\NetSatis.Update.exe");
            }
            else
            {
                MessageBox.Show("Programınız güncel.");
            }

        }

        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmKodlar form = new FrmKodlar("");
            form.ShowDialog();
        }

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void barButtonItem39_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmBanka>().Any())
            {
                FrmBanka form = new FrmBanka();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void barButtonItem40_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmBankaOdemeEkranı form = new FrmBankaOdemeEkranı();
         //   form.MdiParent = this;
            form.Show();
        }

        private void barButtonItem41_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmKampanya>().Any())
            {
                FrmKampanya frm = new FrmKampanya();
                frm.MdiParent = this;
                frm.Show();
            }
          
            
        }
    }
}