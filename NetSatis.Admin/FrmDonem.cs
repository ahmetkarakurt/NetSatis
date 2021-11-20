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

namespace NetSatis.Admin
{
    public partial class FrmDonem : DevExpress.XtraEditors.XtraForm
    {
        public string secilenDonem;
        public FrmDonem()
        {
            InitializeComponent();
            DonemListele();
        }

        private void DonemListele()
        {
            List<string> dbList;
            NetSatisContext context = new NetSatisContext();
            dbList = context.Database
                .SqlQuery<string>("Select name From master.dbo.sysdatabases Where name like 'NetSatis%'").ToList();
            foreach (var item in dbList)
            {
                CheckButton buton = new CheckButton
                {
                    Name = item,
                    Text = item.Replace("NetSatis", ""),
                    GroupIndex = 1,
                    ImageList = ımageList1,
                    ImageToTextAlignment = ImageAlignToText.TopCenter,
                    ImageIndex = 0,
                    Height = 100,
                    Width = 100
                };
                buton.Click += SecilenButon;
                flowLayoutPanel1.Controls.Add(buton);

            }
        }

        private void SecilenButon(object sender, EventArgs e)
        {
            CheckButton buton = (CheckButton) sender;
            secilenDonem = "NetSatis" + buton.Text;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(secilenDonem))
            {
                MessageBox.Show("Lütfen bir dönem seçin");
            }
            else
            {
                this.Close();    
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            secilenDonem = null;
            this.Close();
        }
    }
}