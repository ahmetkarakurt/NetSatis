using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NetSatis.Update
{
    public partial class FrmGuncelleme : DevExpress.XtraEditors.XtraForm
    {
        WebClient indir = new WebClient();
        public static bool IsRunning(string ProgramAdi)
        {
            return Process.GetProcessesByName(ProgramAdi).Length > 0;
        }
        public FrmGuncelleme()
        {
            InitializeComponent();
            if (IsRunning("NetSatis.BackOffice"))
            {
                if (MessageBox.Show("Güncelleme işleminden önce açık olan uygulamanızın kapatılması gerekiyor. Onaylıyor musunuz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (var process in Process.GetProcessesByName("NetSatis.BackOffice"))
                    {
                        process.CloseMainWindow();
                        process.Kill();
                    }
                }
            }
        }

        private void btnIndir_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Application.StartupPath + "\\temp"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\temp");
            }
            indir.DownloadProgressChanged += (DownloadProgressChangedEventHandler)IndirmeDurumu;
            indir.DownloadFileCompleted += (AsyncCompletedEventHandler)IndirmeBitti;
            indir.DownloadFileAsync(new Uri("http://www.tesyazilim.com/downloads/Update.zip"), Application.StartupPath + "\\temp\\Update.zip");
        }

        private void IndirmeBitti(object sender, AsyncCompletedEventArgs e)
        {
            ZipFile.ExtractToDirectory(Application.StartupPath + "\\temp\\Update.zip", Application.StartupPath + "\\temp");
            XElement Dosyalar = XElement.Load(Application.StartupPath + "\\temp\\Liste.xml");
            foreach (var veriler in Dosyalar.Elements().ToList())
            {

                if (File.Exists(Application.StartupPath + veriler.Element("YuklenecegiKonum").Value))
                {
                    File.Delete(Application.StartupPath + veriler.Element("YuklenecegiKonum").Value);
                }
                File.Copy(Application.StartupPath + "\\temp\\" + veriler.Element("DosyaAdi").Value, Application.StartupPath + veriler.Element("YuklenecegiKonum").Value);
            }
            Directory.Delete(Application.StartupPath + "\\temp", true);
            MessageBox.Show("Güncelleme Tamamlandı.");
            this.Close();
        }
        public void IndirmeDurumu(object sender, DownloadProgressChangedEventArgs e)
        {
            progressFile.Properties.Maximum = (int)e.TotalBytesToReceive;
            progressFile.Text = Convert.ToString(e.BytesReceived);
            lblIndirilenVeri.Text = $"{(Convert.ToDecimal(e.BytesReceived) / 1024 / 1024).ToString("N2")} MB\\{(Convert.ToDecimal(e.TotalBytesToReceive) / 1024 / 1024).ToString("N2")} MB";
        }
    }
}
