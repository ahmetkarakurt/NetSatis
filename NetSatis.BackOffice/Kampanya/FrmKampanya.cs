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

namespace NetSatis.BackOffice.Kampanya
{
    public partial class FrmKampanya : DevExpress.XtraEditors.XtraForm
    {

        NetSatisContext context = new NetSatisContext();
        KampanyaAnaDaL KampanyaDal = new KampanyaAnaDaL();
        public FrmKampanya()
        {
            InitializeComponent();
            Listele();
        }
        private void Listele()
        {
            gridcontKampanya.DataSource = KampanyaDal.KampanyaListele(context);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmKampanyaEkle frm = new FrmKampanyaEkle();
            frm.Show();
            Listele();
        }

        private void btnStokekle_Click(object sender, EventArgs e)
        {
            int secilen = Convert.ToInt32(gridKampanya.GetFocusedRowCellValue(colKampanyaKod).ToString());
            var Kampnatur = gridKampanya.GetFocusedRowCellValue(colKampanyaTuru).ToString();
            if (Kampnatur != null)
            {
       
                Tanım.FrmKampanyaStokEkle frm = new Tanım.FrmKampanyaStokEkle(secilen, Kampnatur);
                frm.ShowDialog();
            }
          
        }

        private void btnDurum_Click(object sender, EventArgs e)
        {
            int secilenStokKodu = Convert.ToInt32(gridKampanya.GetFocusedRowCellValue(colKampanyaKod));
            var secilen = KampanyaDal.GetByFilter(context, c => c.KampanyaKod == secilenStokKodu);
            if (Convert.ToBoolean(gridKampanya.GetFocusedRowCellValue(colDurumu)))
            {
                secilen.Durumu = false;
                btnDurum.Text = "Pasif Yap";
                gridKampanya.SetFocusedRowCellValue(colDurumu, false);
                btnDurum.ImageIndex = 9;
                KampanyaDal.Save(context);
            }
            else
            {
                secilen.Durumu = true;
                btnDurum.Text = "Aktif Yap";
                gridKampanya.SetFocusedRowCellValue(colDurumu, true);
                btnDurum.ImageIndex = 8;
                KampanyaDal.Save(context);
            }
            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Listele();
        }
    }
}