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

namespace NetSatis.BackOffice.Kasa
{
    public partial class FrmKasaHareket : DevExpress.XtraEditors.XtraForm
    {
        KasaDAL kasaDal=new KasaDAL();
        KasaHareketDAL kasaHareketDal=new KasaHareketDAL();
        NetSatisContext context=new NetSatisContext();
        private int _kasaId;
        public FrmKasaHareket(int kasaId)
        {
            InitializeComponent();
            _kasaId = kasaId;
            var kasaBilgi = context.Kasalar.SingleOrDefault(c => c.Id == kasaId);
            lblBaslik.Text = kasaBilgi.KasaKodu + " - " + kasaBilgi.KasaAdi + " Hareketleri";
        }

        private void FrmKasaHareket_Load(object sender, EventArgs e)
        {
            Guncelle();
        }

        public void Guncelle()
        {
            gridcontKasaHareket.DataSource = kasaHareketDal.GetAll(context, c => c.KasaId == _kasaId);
            gridcontOdemeTuruToplam.DataSource = kasaDal.OdemeTuruToplamListele(context, _kasaId);
            gridcontGenelToplam.DataSource = kasaDal.GenelToplamListele(context, _kasaId);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (gridKasaHareket.OptionsView.ShowAutoFilterRow == true)
            {
                gridKasaHareket.OptionsView.ShowAutoFilterRow = false;
            }
            else
            {
                gridKasaHareket.OptionsView.ShowAutoFilterRow = true;
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}