using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Sql;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using NetSatis.BackOffice.Stok;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tools;

namespace NetSatis.BackOffice.Cari
{
    public partial class FrmCari : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        CariDAL cariDal = new CariDAL();
        private string secilen;
        private ExportTool export;
        public FrmCari()
        {
            InitializeComponent();
            export=new ExportTool(this,gridView1,dropDownButton1);
            GetAll();
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmCariIslem form = new FrmCariIslem(new Entities.Tables.Cari());
            form.ShowDialog();
            if (form.saved)
            {
                GetAll();
            }
        }

        private void btnFiltreKapat_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
        }

        private void btnFiltreIptal_Click(object sender, EventArgs e)
        {
            filterControl1.FilterString = null;
            filterControl1.ApplyFilter();
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            filterControl1.ApplyFilter();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;


        }

        private void FrmCari_Load(object sender, EventArgs e)
        {
     
        }

        public void GetAll()
        {
            gridControl1.DataSource = cariDal.CariListele(context);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            GetAll();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("Bir kayıt seçmelisiniz.");
                return;
            }
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                secilen = gridView1.GetFocusedRowCellValue(colCariKodu).ToString();
            //    var Varmi = context.KasaHareketleri.Where(c=>c.CariKodu==secilen)
            //
            //   if (true)
            //   {
            //
            //   }

                cariDal.Delete(context, c => c.CariKodu == secilen);
                cariDal.Save(context);
                GetAll();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount==0)
            {
                MessageBox.Show("Düzenleme yapabilmek için bir kayıt seçmelisiniz.");
                return;
            }
            // secilen = (Entities.Tables.Cari) gridView1.GetFocusedRow();
            secilen = gridView1.GetFocusedRowCellValue(colCariKodu).ToString();
            FrmCariIslem form = new FrmCariIslem(cariDal.GetByFilter(context, c => c.CariKodu == secilen));
            form.ShowDialog();
            if (form.saved)
            {
                GetAll();
            }
        }
        private void btnKopyala_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("Kopyalama yapabilmek için bir kayıt seçmelisiniz.");
                return;
            }
            // secilen = (Entities.Tables.Cari)gridView1.GetFocusedRow();
            secilen = gridView1.GetFocusedRowCellValue(colCariKodu).ToString();
            Entities.Tables.Cari cariEntity = new Entities.Tables.Cari();
            cariEntity = cariDal.GetByFilter(context, c => c.CariKodu == secilen);
            FrmCariIslem form = new FrmCariIslem(cariEntity, true);
            form.ShowDialog();
            if (form.saved)
            {
                context = new NetSatisContext();
                GetAll();
            }
        }
        private void btnCariHareket_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount!=0)
            {
                // secilen = (Entities.Tables.Cari)gridView1.GetFocusedRow();
                secilen = gridView1.GetFocusedRowCellValue(colCariKodu).ToString();
                FrmCariHareket form = new FrmCariHareket(secilen);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seçili bir kayıt bulunamadı.");
            }
       
        }

        private void FrmCari_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
        }
        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        private void gridView1_Click(object sender, EventArgs e)
        {

        }
    }
}