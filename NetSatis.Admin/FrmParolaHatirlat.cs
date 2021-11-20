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
using NetSatis.Entities.Tables;

namespace NetSatis.Admin
{
    public partial class FrmParolaHatirlat : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context=new NetSatisContext();
        KullaniciDAL kullaniciDal=new KullaniciDAL();
        private Kullanici _entity;
        public FrmParolaHatirlat(string kullaniciAdi)
        {
            InitializeComponent();
            _entity = context.Kullanicilar.SingleOrDefault(c => c.KullaniciAdi == kullaniciAdi);
            txtHatirlatma.Text = _entity.HatirlatmaSorusu;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_entity.Cevap==txtCevap.Text && txtParola.Text==txtParolaTekrar.Text)
            {
                _entity.Parola = txtParola.Text;
                kullaniciDal.AddOrUpdate(context, _entity);
                context.SaveChanges();
                MessageBox.Show("Parolanız Başarıyla Değiştirildi.");
                this.Close();
            }
        }
    }
}