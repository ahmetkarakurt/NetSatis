using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tables;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.Data.Filtering.Helpers;
using NetSatis.Entities.Tools;

namespace NetSatis.Admin
{
    public partial class FrmKullanicilar : DevExpress.XtraEditors.XtraForm
    {
        private NetSatisContext context;
        KullaniciDAL kullaniciDal = new KullaniciDAL();
        KullaniciRolDAL kullaniciRolDal = new KullaniciRolDAL();
        SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
        private string secilen; public FrmKullanicilar()
        {
            InitializeComponent();
            FrmDonem form = new FrmDonem();
            form.ShowDialog();
            connectionStringBuilder.ConnectionString =
                SettingsTool.AyarOku(SettingsTool.Ayarlar.DatabaseAyarlari_BaglantiCumlesi);
            if (!String.IsNullOrEmpty(form.secilenDonem) )
            {connectionStringBuilder.InitialCatalog = form.secilenDonem;
                SettingsTool.AyarDegistir(SettingsTool.Ayarlar.DatabaseAyarlari_BaglantiCumlesi,connectionStringBuilder.ConnectionString);;
                context = new NetSatisContext();
                Guncelle();
            }
            else
            {
                this.Dispose();
            }
     
        }
        private void Guncelle()
        {
            gridControl1.DataSource = kullaniciDal.GetAll(context);
        }
        private void FrmKullanicilar_Load(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmKullaniciIslem form = new FrmKullaniciIslem(new Kullanici());
            form.ShowDialog();
        }
        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            secilen = gridView1.GetFocusedRowCellValue(colKullaniciAdi).ToString();
            FrmKullaniciIslem form = new FrmKullaniciIslem(kullaniciDal.GetByFilter(context, c => c.KullaniciAdi == secilen));
            form.ShowDialog();
            if (form.saved)
            {
                Guncelle();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = gridView1.GetFocusedRowCellValue(colKullaniciAdi).ToString();
            kullaniciRolDal.Delete(context, c => c.KullaniciAdi == kullaniciAdi);}

        private void btnAra_Click(object sender, EventArgs e)
        {
            gridView1.OptionsView.ShowAutoFilterRow = gridView1.OptionsView.ShowAutoFilterRow != true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle();
        }
    }
}

