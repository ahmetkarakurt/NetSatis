using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tables;
using NetSatis.Entities.Tools;
using DevExpress.XtraReports.UI;

namespace NetSatis.BackOffice.Stok
{
    public partial class FrmStok : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        StokDAL stokDal = new StokDAL();
        private string secilen;
        public static Entities.Tables.Stok entity;
        private ExportTool export;

        public FrmStok()
        {
            InitializeComponent();
            export=new ExportTool(this,gridView1,dropDownButton1);RoleTool.RolleriYukle(this);
        }

        private void FrmStok_Load(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
            GetAll();
        
        }

        private void GetAll()
        {
            context=new NetSatisContext();
            gridControl1.DataSource = stokDal.StokListele(context);
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnFiltreKapat_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
        }
        private void btnAra_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            GetAll();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string secilen =gridView1.GetFocusedRowCellValue(colStokKodu).ToString();
                stokDal.Delete(context, c => c.StokKodu == secilen);
                stokDal.Save(context);
                GetAll();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmStokIslem form = new FrmStokIslem(new Entities.Tables.Stok());
            form.ShowDialog();
            if (form.saved)
            {
                GetAll();
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            secilen = gridView1.GetFocusedRowCellValue(colStokKodu).ToString();
            FrmStokIslem form = new FrmStokIslem(stokDal.GetByFilter(context, c => c.StokKodu == secilen),false,false);
            form.ShowDialog();
            if (form.saved)
            {
                GetAll();
            }}
        
        private void btnKopyala_Click(object sender, EventArgs e)
        {
            secilen = gridView1.GetFocusedRowCellValue(colStokKodu).ToString();
            Entities.Tables.Stok stokEntity = new Entities.Tables.Stok();
            stokEntity = stokDal.GetByFilter(context, c => c.StokKodu == secilen);
            FrmStokIslem form = new FrmStokIslem(stokEntity,true,false);
            form.ShowDialog();
            if (form.saved)
            {
                GetAll();
            }
        }

        private void btnStokHareket_Click(object sender, EventArgs e)
        {
            secilen = gridView1.GetFocusedRowCellValue(colStokKodu).ToString();
            FrmStokHareket form = new FrmStokHareket(secilen);
            form.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Tanım.FrmStokBarkod form = new Tanım.FrmStokBarkod(gridView1.GetFocusedRowCellValue(colStokKodu).ToString());
            form.ShowDialog();
        }

        private void barkodYazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   MessageBox.Show(gridView1.GetFocusedRowCellValue(colStokKodu).ToString());
            List<Entities.Tables.Stok> stokEntity = new List<Entities.Tables.Stok>();
            FrmStokSec form = new FrmStokSec(true);
            form.ShowDialog();
            if (form.secildi)
            {
                foreach (var itemStok in form.secilen)
                {
                    stokEntity.Add(itemStok);
                }
            }
            gridView1.RefreshData();
            var report = new XtraReport();
            report.DataSource = stokEntity;
            report.LoadLayout(Application.StartupPath + @"\dizayn\XtraReport.repx");
            report.ShowRibbonPreview();
            //    report.PrintDialog();

        }
    }
}