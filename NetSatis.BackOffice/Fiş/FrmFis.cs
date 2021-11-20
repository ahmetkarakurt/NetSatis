using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tables;
using NetSatis.Reports.Fatura_ve_Fiş;

namespace NetSatis.BackOffice.Fiş
{
    public partial class FrmFis : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        FisDAL fisDal = new FisDAL();
        KasaHareketDAL kasaHareketDal = new KasaHareketDAL();
        StokHareketDAL stokHareketDal = new StokHareketDAL();
        public FrmFis()
        {
            InitializeComponent();
            //Yeni değişiklik
        }

        private void FrmFis_Load(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
            Listele();
        }

        private void Listele()
        {
            context = new NetSatisContext();
            gridcontFisler.DataSource = fisDal.GetAll(context);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            filterControl1.ApplyFilter();
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

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (gridFisler.RowCount != 0)
            {
                Fis secilen = (Fis)gridFisler.GetFocusedRow();
                if (!String.IsNullOrEmpty(secilen.FisBaglantiKodu))
                {
                    if (MessageBox.Show(
                            $"Bu fiş ile bağlantılı olan {secilen.FisBaglantiKodu} kodlu fiş birlikte silinecektir. Emin misiniz?",
                            "Uyarı",
                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //string secilen = gridFisler.GetFocusedRowCellValue(colFisKodu).ToString();
                        fisDal.Delete(context, c => c.FisKodu == secilen.FisBaglantiKodu);
                        fisDal.Delete(context, c => c.FisKodu == secilen.FisKodu);
                        kasaHareketDal.Delete(context, c => c.FisKodu == secilen.FisKodu);
                        stokHareketDal.Delete(context, c => c.FisKodu == secilen.FisKodu);
                        fisDal.Save(context);
                        Listele();

                    }
                }
                else
                {
                    if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı",
                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //string secilen = gridFisler.GetFocusedRowCellValue(colFisKodu).ToString();
                        fisDal.Delete(context, c => c.FisKodu == secilen.FisKodu);
                        kasaHareketDal.Delete(context, c => c.FisKodu == secilen.FisKodu);
                        stokHareketDal.Delete(context, c => c.FisKodu == secilen.FisKodu);
                        fisDal.Save(context);
                        Listele();
                    }
                }
            }
            else
            {
                MessageBox.Show("Listede seçilen bir fiş bulunamadı.");
            }
        }

        private void FisIslem_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmFisIslem form = new FrmFisIslem(null, e.Item.Caption);
            MessageBox.Show(e.Item.Caption.ToString());
            form.ShowDialog();

        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (gridFisler.RowCount != 0)
            {
                Fis secilen = (Fis)gridFisler.GetFocusedRow();
                if (secilen.FisTuru == "Fiş Ödemesi")
                {
                    FrmFisIslem form = new FrmFisIslem(secilen.FisBaglantiKodu, null);
                    form.ShowDialog();
                }
                else
                {
                    FrmFisIslem form = new FrmFisIslem(secilen.FisKodu, null);
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Listede seçilen bir fiş bulunamadı.");
            }


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //ReportPrintTool tool = new ReportPrintTool(new rptFatura(gridFisler.GetFocusedRowCellValue(colFisKodu).ToString()));
            //tool.ShowPreviewDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Fis secilen = (Fis)gridFisler.GetFocusedRow();
            if (!secilen.FisTuru.Contains("Sipariş Fişi"))
            {
                MessageBox.Show("Faturalandırmak istediğiniz fiş bir sipariş fişi değil.");
            }
            else
            {
                FrmFisIslem form = new FrmFisIslem(secilen.FisKodu, null, siparisFaturalandir: true);
                form.ShowDialog();
            }
        }

       
    }
}