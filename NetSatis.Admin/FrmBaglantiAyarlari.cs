using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NetSatis.Entities.Context;
using NetSatis.Entities.Tables;
using NetSatis.Entities.Tools;

namespace NetSatis.Admin
{
    public partial class FrmBaglantiAyarlari : DevExpress.XtraEditors.XtraForm
    {
        SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
        public bool kaydedildi = false;
        public FrmBaglantiAyarlari()
        {
            InitializeComponent();
        }

        private void BaglantiCumleOlustur()
        {
            connectionStringBuilder.DataSource = txtServer.Text;
            connectionStringBuilder.InitialCatalog = "master";
            if (chkWindows.Checked)
            {
                connectionStringBuilder.IntegratedSecurity = true;
            }
            else
            {
                connectionStringBuilder.UserID = txtKullanici.Text;
                connectionStringBuilder.Password = txtParola.Text;
                connectionStringBuilder.IntegratedSecurity = false;
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            BaglantiCumleOlustur();
            connectionStringBuilder.InitialCatalog = "master";

            if (ConnectionTool.CheckConnection(connectionStringBuilder.ConnectionString))
            {
                MessageBox.Show("Bağlantı Başarılı");
            }
            else
            {
                MessageBox.Show("Bağlantı Başarısız");
            }
        }

        private void chkSqlServer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSqlServer.Checked)
            {
                txtParola.Enabled = true;
                txtKullanici.Enabled = true;
            }
            else
            {
                txtParola.Enabled = false;
                txtKullanici.Enabled = false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            BaglantiCumleOlustur();
            connectionStringBuilder.InitialCatalog = "master";

            if (ConnectionTool.CheckConnection(connectionStringBuilder.ConnectionString))
            {
                ConnectionStringTool.ConnectionStringDegistir(connectionStringBuilder.ConnectionString);kaydedildi = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Bağlantı Başarısız");
            }
        }

        private void FrmBaglantiAyarlari_Load(object sender, EventArgs e)
        {

        }

        private void FrmBaglantiAyarlari_FormClosing(object sender, FormClosingEventArgs e)
        {
             if (!kaydedildi)
            {
                
                MessageBox.Show("Uygulamada bağlantı cümlesi olmadığından kapatılacak.");
                Application.Exit();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}