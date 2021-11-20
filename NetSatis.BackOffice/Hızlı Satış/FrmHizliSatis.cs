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
using NetSatis.BackOffice.Stok;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tables;

namespace NetSatis.BackOffice.Hızlı_Satış
{
    public partial class FrmHizliSatis : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        HizliSatisGrupDAL hizliSatisGrupDal = new HizliSatisGrupDAL();
        HizliSatisDAL hizliSatisDal = new HizliSatisDAL();
        public FrmHizliSatis()
        {
            InitializeComponent();
            context.HizliSatisGruplari.Load();
            context.HizliSatislar.Load();
            gridContGrupEkle.DataSource = context.HizliSatisGruplari.Local.ToBindingList();
            gridContUrunEkle.DataSource = context.HizliSatislar.Local.ToBindingList();

        }

        private void FrmHizliSatis_Load(object sender, EventArgs e)
        {

        }

        private void KayitAc()
        {
            grpGrupBilgi.Enabled = true;
            btnYeni.Enabled = false;
            btnSil.Enabled = false;
            btnKaydet.Enabled = true;
            btnVazgec.Enabled = true;
            gridContUrunEkle.Enabled = false;
            btnUrunEkle.Enabled = false;
            btnUrunSil.Enabled = false;
        }
        private void KayitKapat()
        {
            grpGrupBilgi.Enabled = false;
            btnYeni.Enabled = true;
            btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            btnVazgec.Enabled = false;
            gridContUrunEkle.Enabled = true;
            btnUrunEkle.Enabled = true;
            btnUrunSil.Enabled = true;
        }

        private void gridGrupEkle_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridUrunEkle.ActiveFilterString = $"GrupId='{gridGrupEkle.GetFocusedRowCellValue(colId)}'";
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            KayitAc();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            KayitKapat();
            hizliSatisGrupDal.AddOrUpdate(context, new HizliSatisGrup
            {
                GrupAdi = txtGrupAdi.Text,
                Aciklama = txtAciklama.Text,
            });
            hizliSatisGrupDal.Save(context);
            txtGrupAdi.Text = null;
            txtAciklama.Text = null;
        }
        private void btnVazgec_Click(object sender, EventArgs e)
        {
            KayitKapat();
            txtGrupAdi.Text = null;
            txtAciklama.Text = null;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan grup ile birlikte bu gruba eklenmiş tüm ürünler silinecektir.", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int grupId = (int)gridGrupEkle.GetFocusedRowCellValue(colId);
                hizliSatisDal.Delete(context, c => c.GrupId == grupId);
                gridGrupEkle.DeleteSelectedRows();
                hizliSatisDal.Save(context);
            }
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            FrmStokSec form = new FrmStokSec(true);
            form.ShowDialog();
            if (form.secildi)
            {
                foreach (var itemStok in form.secilen)
                {
                    if (context.HizliSatislar.Count(c => c.Barkod == itemStok.Barkod) == 0)
                    {
                        hizliSatisDal.AddOrUpdate(context, new HizliSatis
                        {
                            //hızlı satışa stokbarkod tablosunda çıkması içi stokkod verildi
                            Barkod = itemStok.StokKodu,
                            UrunAdi = itemStok.StokAdi,
                            GrupId = (int)gridGrupEkle.GetFocusedRowCellValue(colId)
                        });
                        hizliSatisDal.Save(context);
                    }
                }
            }}
        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan ürünleri listeden çıkarmak istediğinize emin misiniz?","Uyarı",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                     gridUrunEkle.DeleteSelectedRows();
            hizliSatisDal.Save(context);
            }
       
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}