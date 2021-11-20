using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NetSatis.Entities.Context;
using NetSatis.Entities.Tables;
using NetSatis.Entities.Tools;
using NetSatis.Entities.Tools.LoadingTool;

namespace NetSatis.Admin
{
    public partial class FrmKullaniciGiris : DevExpress.XtraEditors.XtraForm
    {
        private NetSatisContext context;
        private bool girisBasarili = false;
        private List<string> dbList;
      
        SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
        public FrmKullaniciGiris()
        {
            InitializeComponent();
            //KlasoreIzınVer();    
            connectionStringBuilder.ConnectionString = ConnectionStringTool.ConnectionString();
            connectionStringBuilder.InitialCatalog = "master";

            if (!ConnectionTool.CheckConnection(connectionStringBuilder.ConnectionString))
            {
                FrmBaglantiAyarlari form = new FrmBaglantiAyarlari();
                form.ShowDialog(); if (form.kaydedildi)
                {
                    connectionStringBuilder.ConnectionString = ConnectionStringTool.ConnectionString();
                    context = new NetSatisContext(connectionStringBuilder.ConnectionString);
                    DbListele();
                    DbOlustur();
                }
            }
            else
            {
                context = new NetSatisContext(connectionStringBuilder.ConnectionString);
                DbListele();
                DbOlustur();
            }

        }
        private void DbListele()
        {
            dbList = context.Database.SqlQuery<string>(
                "Select name From master.dbo.sysdatabases Where name like 'NetSatis%'").ToList();
            foreach (var item in dbList)
            {
                cmbDonem.Properties.Items.Add(item.Replace("NetSatis", ""));
            }
         
         
           // cmbSube.DataBindings
        }
        private void DbOlustur()
        {
            if (dbList.Count == 0)
            {
                FrmDonemSec form = new FrmDonemSec();
                form.ShowDialog();
                if (!String.IsNullOrEmpty(form.donem))
                {
                    connectionStringBuilder.InitialCatalog = "NetSatis" + form.donem;
                    context = new NetSatisContext(connectionStringBuilder.ConnectionString);
                    CreateDatabaseTool dbtool = new CreateDatabaseTool(context, this);
                    dbtool.DatabaseOlustur();
                    DbListele();

                }
            }
        }
        private void KlasoreIzınVer()
        {
            DirectorySecurity izin = Directory.GetAccessControl(Application.StartupPath);
            SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            izin.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.FullControl, AccessControlType.Allow));
            Directory.SetAccessControl(Application.StartupPath, izin);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbDonem.Properties.Items.Count == 0 || String.IsNullOrEmpty(cmbDonem.Text))
            {
                MessageBox.Show("Seçili bir database bulunamadı.");
                return;
            }
            else
            {
                connectionStringBuilder.InitialCatalog = "NetSatis" + cmbDonem.Text;
                ConnectionStringTool.ConnectionStringDegistir(connectionStringBuilder.ConnectionString);
                context = new NetSatisContext(connectionStringBuilder.ConnectionString);
            }

            if (context.Kullanicilar.Any(c => c.KullaniciAdi == txtKullanici.Text && c.Parola == txtParola.Text))
            {
                girisBasarili = true;
                RoleTool.KullaniciEntity =
                    context.Kullanicilar.SingleOrDefault(c => c.KullaniciAdi == txtKullanici.Text);
                RoleTool.SubeEntity = context.Subeler.SingleOrDefault(c => c.Tanimi == cmbSube.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Girdiğiniz Kullanıcı Adı veya Parola Yanlış");
                txtKullanici.Text = null;
                txtParola.Text = null;
            }
        }

        private void FrmKullaniciGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!girisBasarili)
            {
                Application.Exit();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (context.Kullanicilar.Any(c => c.KullaniciAdi == txtKullanici.Text))
            {
                FrmParolaHatirlat form = new FrmParolaHatirlat(txtKullanici.Text);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Yazdığınız kullanıcı adı kayıtlarda yok.");
            }
        }

        private void FrmKullaniciGiris_Load(object sender, EventArgs e)
        {
            try
            {
                context = new NetSatisContext();
                var sub = (from x in context.Subeler
                           select x).ToList();
                // var sub = context.Subeler.ToList();
                foreach (var item in sub)
                {
                    cmbSube.Properties.Items.Add(item.Tanimi);
                }

                
                cmbSube.Visible = Convert.ToBoolean(SettingsTool.AyarOku(SettingsTool.Ayarlar.FirmaAyarlari_SubeliSistem));

            }
            catch (Exception)
            {

                
            }


        }
    }
}