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
    public partial class FrmBankaIslem : DevExpress.XtraEditors.XtraForm
    {
        BankaDAL bankaDAL = new BankaDAL();
        NetSatisContext context = new NetSatisContext();
        public bool Kaydedildi = false;
        private Entities.Tables.Banka _entity;
        public FrmBankaIslem(Entities.Tables.Banka entity)
        {
            InitializeComponent();
            _entity = entity;
            txtKasaKodu.DataBindings.Add("Text", _entity, "BankaKodu");
            txtKasaAdi.DataBindings.Add("Text", _entity, "BankaAdi");
            txtYetkiliKodu.DataBindings.Add("Text", _entity, "YetkiliKodu");
            txtYetkiliAdi.DataBindings.Add("Text", _entity, "YetkiliAdi");
            txtAciklama.DataBindings.Add("Text", _entity, "Aciklama");
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (bankaDAL.AddOrUpdate(context, _entity))
            {
                bankaDAL.Save(context);
                Kaydedildi = true;
                this.Close();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}