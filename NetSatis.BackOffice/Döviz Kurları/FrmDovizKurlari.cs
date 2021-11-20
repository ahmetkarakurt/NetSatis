using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.XtraEditors;
using NetSatis.Entities.Tables.OtherTables;
using NetSatis.Entities.Tools;

namespace NetSatis.BackOffice.Döviz_Kurları
{
    public partial class FrmDovizKurlari : DevExpress.XtraEditors.XtraForm
    {
        public FrmDovizKurlari()
        {
            InitializeComponent(); FileInfo info = new FileInfo(Application.StartupPath + "\\Kurlar.xml");
            lblUyari.Text = "Son Güncelleme Tarihi : " + info.LastWriteTime.ToString();
        }

        private void FrmDovizKurlari_Load(object sender, EventArgs e)
        {
            Guncelle(false);

        }

        private void Guncelle(bool indir = true)
        {
            if (indir)
            {
                using (WebClient kurIndir = new WebClient())
                {
                    kurIndir.DownloadFile("http://www.tcmb.gov.tr/kurlar/today.xml", Application.StartupPath + "\\Kurlar.xml");

                }
                lblUyari.Text = "Son Güncelleme Tarihi : " + DateTime.Now.ToString();
            }

            ExchangeTool doviz=new ExchangeTool();
            gridControl1.DataSource = doviz.DovizKuruCek();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Guncelle();

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}