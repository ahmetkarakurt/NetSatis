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
using NetSatis.Entities.Tools;namespace NetSatis.BackOffice.Kasa
{
    public partial class FrmKasa : DevExpress.XtraEditors.XtraForm
    {
        KasaDAL kasaDal = new KasaDAL();
        NetSatisContext context = new NetSatisContext();
        private int secilen;

        public FrmKasa()
        {
            InitializeComponent();

        }

        public void Guncelle()
        {
            gridcontKasalar.DataSource = kasaDal.KasaListele(context);
        }

        private void btnFiltreKapat_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
        }

        private void FrmKasa_Load(object sender, EventArgs e)
        {    Guncelle();
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
        
        }
        private void btnAra_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            filterControl1.ApplyFilter();
        }

        private void btnFiltreIptal_Click(object sender, EventArgs e)
        {
            filterControl1.FilterString = null;
            filterControl1.ApplyFilter();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmKasaIslem form = new FrmKasaIslem(new Entities.Tables.Kasa());
            form.ShowDialog();
            if (form.Kaydedildi)
            {
                Guncelle();
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            secilen = Convert.ToInt32(layoutView1.GetFocusedRowCellValue(colId));
            FrmKasaIslem form = new FrmKasaIslem(kasaDal.GetByFilter(context, c => c.Id == secilen));
            form.ShowDialog();
            if (form.Kaydedildi)
            {
                Guncelle();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                secilen = Convert.ToInt32(layoutView1.GetFocusedRowCellValue(colId));
                kasaDal.Delete(context, c => c.Id == secilen);
                kasaDal.Save(context);
                Guncelle();
            }
        }

        private void btnCariHareket_Click(object sender, EventArgs e)
        {
            secilen = Convert.ToInt32(layoutView1.GetFocusedRowCellValue(colId));
            string secilenAd = layoutView1.GetFocusedRowCellValue(colKasaKodu).ToString();
            FrmKasaHareket form = new FrmKasaHareket(secilen);
            form.ShowDialog();
        }
    }
}