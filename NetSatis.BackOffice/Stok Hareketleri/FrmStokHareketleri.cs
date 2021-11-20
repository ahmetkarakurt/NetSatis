using System;
using DevExpress.XtraEditors;
using NetSatis.BackOffice.Fiş;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;

namespace NetSatis.BackOffice.Stok_Hareketleri
{
    public partial class FrmStokHareketleri : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        StokHareketDAL stokHareketDal = new StokHareketDAL();
        public FrmStokHareketleri()
        {
            InitializeComponent();

        }

        private void Listele()
        {
            gridcontStokHareket.DataSource = stokHareketDal.GetAll(context);
        }

        private void FrmStokHareketleri_Load(object sender, System.EventArgs e)
        {
            Listele();
        }

        private void btnGuncelle_Click(object sender, System.EventArgs e)
        {
            Listele();
        }

        private void btnAra_Click(object sender, System.EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
        }

        private void btnKapat_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnFiltreKapat_Click(object sender, System.EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
        }

        private void btnFiltrele_Click(object sender, System.EventArgs e)
        {
            filterControl1.ApplyFilter();
        }

        private void btnFiltreIptal_Click(object sender, System.EventArgs e)
        {
            filterControl1.FilterString = null;
            filterControl1.ApplyFilter();
        }

        private void repoSeriNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string veri = Convert.ToString(gridStokHareket.GetFocusedRowCellValue(colSeriNo));
            FrmSeriNoGir form = new FrmSeriNoGir(veri);
    
            form.ShowDialog();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmFisIslem form=new FrmFisIslem(gridStokHareket.GetFocusedRowCellValue(colFisKodu).ToString());
            form.ShowDialog();
        }
    }
}