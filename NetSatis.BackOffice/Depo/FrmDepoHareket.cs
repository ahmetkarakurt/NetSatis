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

namespace NetSatis.BackOffice.Depo
{
    public partial class FrmDepoHareket : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context=new NetSatisContext();
        StokHareketDAL stokHareketDal=new StokHareketDAL();
        private int _depoId;
        public FrmDepoHareket(int depoId)
        {
            InitializeComponent();
            _depoId = depoId;
            var depo = context.Depolar.SingleOrDefault(c => c.Id == _depoId);
            lblBaslik.Text = depo.DepoKodu + " - " + depo.DepoAdi + " Hareketleri";
        }

        private void FrmDepoHareket_Load(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void Guncelle()
        {
            gridcontHareket.DataSource = stokHareketDal.GetAll(context, c => c.DepoId == _depoId);
            gridcontDepoStok.DataSource = stokHareketDal.DepoStokListele(context, _depoId);
            gridcontIstatistik.DataSource = stokHareketDal.DepoIstatistikListele(context, _depoId);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (gridHareket.OptionsView.ShowAutoFilterRow == true)
            {
                gridHareket.OptionsView.ShowAutoFilterRow = false;
            }
            else
            {
                gridHareket.OptionsView.ShowAutoFilterRow = true;
            }
        }
    }
}