using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetSatis.Entities.Context;
using NetSatis.Entities.Tools;

namespace NetSatis.Backup
{
    public partial class FrmBackup : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context=new NetSatisContext();
        public FrmBackup()
        {
            InitializeComponent();
            txtYedekKonum.Text = SettingsTool.AyarOku(SettingsTool.Ayarlar.YedeklemeAyarlari_YedeklemeKonumu);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sqlCumle =
                $"USE Netsatis;BACKUP DATABASE NetSatis TO DISK='{txtYedekKonum.Text + "\\NetSatisYedek.nsy"}'";
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sqlCumle);
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void txtYedekKonum_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog form=new FolderBrowserDialog();
            if (form.ShowDialog()==DialogResult.OK)
            {
                txtYedekKonum.Text = form.SelectedPath;
                SettingsTool.AyarDegistir(SettingsTool.Ayarlar.YedeklemeAyarlari_YedeklemeKonumu,txtYedekKonum.Text);
                SettingsTool.Save();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog=new OpenFileDialog();
            dialog.Filter = "NetSatış Yedekleme Dosyası *.nsy|*.nsy";
            if (dialog.ShowDialog()==DialogResult.OK)
            {
                string sqlCumle =
                    $"USE master;ALTER DATABASE NetSatis SET SINGLE_USER WITH ROLLBACK IMMEDIATE;ALTER DATABASE NetSatis SET READ_ONLY;RESTORE DATABASE NetSatis FROM DISK='{dialog.FileName}' WITH REPLACE;ALTER DATABASE NetSatis SET MULTI_USER ;";
                context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sqlCumle);
            }
        }
    }
}
