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
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Context;

namespace NetSatis.BackOffice.Banka
{
    public partial class FrmBankaHaraket : DevExpress.XtraEditors.XtraForm
    {  
        BankaDAL bankaDAL = new BankaDAL();
        BankaHareketDAL BankaHareketDAL = new BankaHareketDAL();
        NetSatisContext context = new NetSatisContext();
        private int _kasaId;
        public FrmBankaHaraket(int kasaId)
        {
            InitializeComponent();
            _kasaId = kasaId;
            var kasaBilgi = context.Banka.SingleOrDefault(c => c.Id == kasaId);
            lblBaslik.Text = kasaBilgi.BankaKodu + " - " + kasaBilgi.BankaAdi + " Hareketleri";
        }

        private void FrmBankaHaraket_Load(object sender, EventArgs e)
        {
            Guncelle();

        }
        public void Guncelle()
        {
            gridcontKasaHareket.DataSource = BankaHareketDAL.GetAll(context, c => c.BankaId == _kasaId);
            gridcontOdemeTuruToplam.DataSource = bankaDAL.OdemeTuruToplamListele(context, _kasaId);
            gridcontGenelToplam.DataSource = bankaDAL.GenelToplamListele(context, _kasaId);
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
            if (gridKasaHareket.OptionsView.ShowAutoFilterRow == true)
            {
                gridKasaHareket.OptionsView.ShowAutoFilterRow = false;
            }
            else
            {
                gridKasaHareket.OptionsView.ShowAutoFilterRow = true;
            }
        }
    }
}