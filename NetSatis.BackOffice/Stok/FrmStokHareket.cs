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

namespace NetSatis.BackOffice.Stok
{
    public partial class FrmStokHareket : DevExpress.XtraEditors.XtraForm
    {

        StokHareketDAL stokHareketDal=new StokHareketDAL();
        NetSatisContext context=new NetSatisContext();
        private string _StokKodu;
        public FrmStokHareket(string StokKodu)
        {
            InitializeComponent();
            _StokKodu = StokKodu;
            var stok = context.Stoklar.SingleOrDefault(c => c.StokKodu == _StokKodu);
            lblBaslik.Text = stok.StokKodu + " - " + stok.StokAdi + " Hareketleri";
        }

        private void FrmStokHareket_Load(object sender, EventArgs e)
        {
           Guncelle();
        }

        private void Guncelle()
        {
            gridcontStokHareket.DataSource = stokHareketDal.GetAll(context, c => c.StokKodu == _StokKodu);
            gridcontGenelStok.DataSource = stokHareketDal.GetGenelStok(context, _StokKodu);
            gridcontDepoStok.DataSource = stokHareketDal.GetDepoStok(context, _StokKodu);
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle();
        }
        private void btnAra_Click(object sender, EventArgs e)
        {
            if (gridStokHareket.OptionsView.ShowAutoFilterRow == true)
            {
                gridStokHareket.OptionsView.ShowAutoFilterRow = false;
            }
            else
            {
                gridStokHareket.OptionsView.ShowAutoFilterRow = true;
            }
            
        }
    }
}