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
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Context;

namespace NetSatis.BackOffice.Banka
{
    public partial class FrmBanka : DevExpress.XtraEditors.XtraForm
    {
        public FrmBanka()
        {
            InitializeComponent();
        }
        BankaDAL bankaDal = new BankaDAL();
        NetSatisContext context = new NetSatisContext();
        private int secilen;
        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmBankaIslem form = new FrmBankaIslem(new Entities.Tables.Banka());
            form.ShowDialog();
            if (form.Kaydedildi)
            {
                Guncelle();
            }
        }

        private void FrmBanka_Load(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
            Guncelle();
        }



        public void Guncelle()
        {
            gridcontKasalar.DataSource = bankaDal.BanklaListele(context);
        }

        private void btnFiltreKapat_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
        }

        private void btnCariHareket_Click(object sender, EventArgs e)
        {
            secilen = Convert.ToInt32(layoutView1.GetFocusedRowCellValue(colId));
            string secilenAd = layoutView1.GetFocusedRowCellValue(colKasaKodu).ToString();
            FrmBankaHaraket form = new FrmBankaHaraket(secilen);
            form.ShowDialog();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle();
        }
    }
}