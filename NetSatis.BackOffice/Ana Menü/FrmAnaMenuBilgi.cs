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
using NetSatis.BackOffice.Stok;
using NetSatis.Entities.Tools;
using NetSatis.BackOffice.Depo;
using NetSatis.BackOffice.Cari;
using NetSatis.BackOffice.Kasa;
using NetSatis.BackOffice.Fiş;
using NetSatis.BackOffice.Ödeme_Türü;
using NetSatis.BackOffice.Raporlar;
using System.Diagnostics;
using NetSatis.BackOffice.İndirim;
using NetSatis.BackOffice.Fiyat_Değiştir;
using NetSatis.BackOffice.Hızlı_Satış;
using NetSatis.BackOffice.Sms;
using NetSatis.BackOffice.Personel;
using NetSatis.BackOffice.Ajanda;
using NetSatis.Entities.Context;
using NetSatis.BackOffice.Döviz_Kurları;
using NetSatis.BackOffice.Ayarlar;
using NetSatis.Backup;
using System.Net;
using NetSatis.BackOffice.Kod;
using System.Reflection;

namespace NetSatis.BackOffice.Ana_Menü{
    public partial class FrmAnaMenuBilgi : DevExpress.XtraEditors.XtraForm
    {
        public FrmAnaMenuBilgi(){
            InitializeComponent();
            RoleTool.RolleriYukle(TileControl1);
        }
        private void TileItem6_ItemClick(object sender, TileItemEventArgs e)
        {
            FrmStok form = new FrmStok();
            form.MdiParent = FrmAnaMenu.ActiveForm;
            form.Show();

        }

        private void barButtonItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmCari>().Any())
            {
                FrmCari form = new FrmCari();
                form.MdiParent = FrmAnaMenu.ActiveForm;
                form.Show();
            }
          
        }

        private void barButtonItem11_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmDepo>().Any())
            {
                FrmDepo form = new FrmDepo();
                form.MdiParent = FrmAnaMenu.ActiveForm;
                form.Show();
            }
        }

        private void TileItem15_ItemClick(object sender, TileItemEventArgs e)
        {
           
            if (!Application.OpenForms.OfType<FrmKasa>().Any())
             {
                FrmKasa form = new FrmKasa();
                form.MdiParent = FrmAnaMenu.ActiveForm;
                form.Show();
              }
        }

        private void TileItem7_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmFis>().Any())
            {
                FrmFis form = new FrmFis();
                form.MdiParent = FrmAnaMenu.ActiveForm;
                form.Show();
            }
        }

        private void TileItem37_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmOdemeTuru>().Any())
            {
                FrmOdemeTuru form = new FrmOdemeTuru();
                form.MdiParent = FrmAnaMenu.ActiveForm;
                form.Show();
            }
        }

        private void TileItem17_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmRaporListesi>().Any())
            {
                FrmRaporListesi form = new FrmRaporListesi();
                form.MdiParent = FrmAnaMenu.ActiveForm;
                form.Show();
            }
        }

        private void TileItem8_ItemClick(object sender, TileItemEventArgs e)
        {
            Process.Start($"{Application.StartupPath}\\NetSatis.FrontOffice.exe");
        }

        private void TileItem18_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmRaporDuzenle>().Any())
            {
                FrmRaporDuzenle form = new FrmRaporDuzenle();
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
        }

        private void TileItem39_ItemClick(object sender, TileItemEventArgs e)
        {
            FrmEtiketOlustur form = new FrmEtiketOlustur();
            form.ShowDialog();
        }

        private void TileItem9_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmIndirim>().Any())
            {
                FrmIndirim form = new FrmIndirim();
                form.MdiParent = FrmAnaMenu.ActiveForm;
                form.Show();
            }
        }

        private void TileItem13_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmTopluFiyat>().Any())
            {
                FrmTopluFiyat form = new FrmTopluFiyat();
                form.MdiParent = FrmAnaMenu.ActiveForm;
                form.Show();
            }
        }

        private void TileItem40_ItemClick(object sender, TileItemEventArgs e)
        {
            FrmOzgunRaporHazirla form = new FrmOzgunRaporHazirla();
            form.ShowDialog();
        }

        private void TileItem21_ItemClick(object sender, TileItemEventArgs e)
        {
            FrmSms form = new FrmSms();
            form.ShowDialog();
        }

        private void TileItem14_ItemClick(object sender, TileItemEventArgs e)
        {
            FrmHizliSatis form = new FrmHizliSatis();
            form.ShowDialog();
        }

        private void TileItem10_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmPersonel>().Any())
            {
                FrmPersonel form = new FrmPersonel();
                form.MdiParent = FrmAnaMenu.ActiveForm;
                form.Show();
            }
        }

        private void TileItem22_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!Application.OpenForms.OfType<FrmAjanda>().Any())
            {
                FrmAjanda form = new FrmAjanda();
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
        }

        private void TileItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            using (var context = new NetSatisContext())
            {
                if (context.OdemeTurleri.Any() || context.Kasalar.Any() || context.Depolar.Any())
                {
                    FrmFisIslem form = new FrmFisIslem(null, e.Item.Text);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ödeme Türü, Kasa, ve Depo eklemeden fatura oluşturulamaz.");
                }
            }
        }

        private void TileItem3_ItemClick(object sender, TileItemEventArgs e)
        {
            using (var context = new NetSatisContext())
            {
                if (context.OdemeTurleri.Any() || context.Kasalar.Any() || context.Depolar.Any())
                {
                    FrmFisIslem form = new FrmFisIslem(null, e.Item.Text);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ödeme Türü, Kasa, ve Depo eklemeden fatura oluşturulamaz.");
                }
            }
        }

        private void TileItem24_ItemClick(object sender, TileItemEventArgs e)
        {
            using (var context = new NetSatisContext())
            {
                if (context.OdemeTurleri.Any() || context.Kasalar.Any() || context.Depolar.Any())
                {
                    FrmFisIslem form = new FrmFisIslem(null, e.Item.Text);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ödeme Türü, Kasa, ve Depo eklemeden fatura oluşturulamaz.");
                }
            }

        }

        private void TileItem4_ItemClick(object sender, TileItemEventArgs e)
        {
            using (var context = new NetSatisContext())
            {
                if (context.OdemeTurleri.Any() || context.Kasalar.Any() || context.Depolar.Any())
                {
                    FrmFisIslem form = new FrmFisIslem(null, e.Item.Text);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ödeme Türü, Kasa, ve Depo eklemeden fatura oluşturulamaz.");
                }
            }
        }

        private void TileItem25_ItemClick(object sender, TileItemEventArgs e)
        {
            using (var context = new NetSatisContext())
            {
                if (context.OdemeTurleri.Any() || context.Kasalar.Any() || context.Depolar.Any())
                {
                    FrmFisIslem form = new FrmFisIslem(null, e.Item.Text);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ödeme Türü, Kasa, ve Depo eklemeden fatura oluşturulamaz.");
                }
            }
        }

        private void TileItem26_ItemClick(object sender, TileItemEventArgs e)
        {
            using (var context = new NetSatisContext())
            {
                if (context.OdemeTurleri.Any() || context.Kasalar.Any() || context.Depolar.Any())
                {
                    FrmFisIslem form = new FrmFisIslem(null, e.Item.Text);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ödeme Türü, Kasa, ve Depo eklemeden fatura oluşturulamaz.");
                }
            }

        }

        private void TileItem28_ItemClick(object sender, TileItemEventArgs e)
        {
            using (var context = new NetSatisContext())
            {
                if (context.OdemeTurleri.Any() || context.Kasalar.Any() || context.Depolar.Any())
                {
                    FrmFisIslem form = new FrmFisIslem(null, e.Item.Text);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ödeme Türü, Kasa, ve Depo eklemeden fatura oluşturulamaz.");
                }
            }
        }

        private void TileItem29_ItemClick(object sender, TileItemEventArgs e)
        {
            using (var context = new NetSatisContext())
            {
                if (context.OdemeTurleri.Any() || context.Kasalar.Any() || context.Depolar.Any())
                {
                    FrmFisIslem form = new FrmFisIslem(null, e.Item.Text);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ödeme Türü, Kasa, ve Depo eklemeden fatura oluşturulamaz.");
                }
            }
        }

        private void TileItem42_ItemClick(object sender, TileItemEventArgs e)
        {
            FrmDovizKurlari form = new FrmDovizKurlari();
            form.ShowDialog();
        }

        private void TileItem19_ItemClick(object sender, TileItemEventArgs e)
        {
            FrmAyarlar form = new FrmAyarlar(); form.ShowDialog();
        }

        private void TileItem20_ItemClick(object sender, TileItemEventArgs e)
        {
            FrmBackup form = new FrmBackup();
            form.ShowDialog();
        }

        private void TileItem11_ItemClick(object sender, TileItemEventArgs e)
        {
            WebClient indir = new WebClient();
         
            string programVersion = Assembly.Load("NetSatis.BackOffice").GetName().Version.ToString();
          //  MessageBox.Show(programVersion);
            string guncelVersion = indir.DownloadString("http://ahmetkarakurt.net/yzlm/version.txt").Replace("\n", "");
          //  MessageBox.Show(guncelVersion);
            if (programVersion != guncelVersion)
            {

                MessageBox.Show("Test");
                Process.Start($"{Application.StartupPath}\\NetSatis.Update.exe");
            }
            else
            {
                MessageBox.Show("Programınız güncel.");
            }
        }

        private void TileItem34_ItemClick(object sender, TileItemEventArgs e)
        {
            FrmKodlar form = new FrmKodlar("");
            form.ShowDialog();
        }

        private void TileItem33_ItemClick(object sender, TileItemEventArgs e)
        {

        }
    }
}