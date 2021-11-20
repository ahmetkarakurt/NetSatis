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
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tables;
namespace NetSatis.BackOffice.Tanım
{
    public partial class FrmStokBarkod : DevExpress.XtraEditors.XtraForm

    {
        public FrmStokBarkod(string _Stokkodu)
        {
            InitializeComponent();
         
            
            Stokkodu = _Stokkodu;
          

        }

        NetSatisContext context = new NetSatisContext();
        StokBarkodDAL StokBarkodDAL = new StokBarkodDAL();
        public StokBarkod _entity;
        string Stokkodu;

        public bool secildi = false;
        void Listele()
        {
       
            gridcontTanim.DataSource = StokBarkodDAL.GetAll(context, c => c.StokKodu== Stokkodu);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
   
            txtStokKod.Text = Stokkodu;
            txtStokID.Text = context.Stoklar.Where(c => c.StokKodu == Stokkodu).Select(c => c.StokKodu).FirstOrDefault().ToString();
            if (StokBarkodDAL.AddOrUpdate(context, _entity))
            {
                StokBarkodDAL.Save(context);
                KayitKapat();
                Listele();
            }
            txtBarkod.Text = "";

        }

        private void btnEkle_Click(object sender, EventArgs e)
        { 
         
            _entity = new StokBarkod();
           
            KayitAc();

        }
        void KayitAc()
        {
  
            btnSec.Enabled = false;
            btnEkle.Enabled = false;
            btnDuzenle.Enabled = false;
            btnSil.Enabled = false; btnKaydet.Enabled = true;
            btnVazgec.Enabled = true;
            navigationFrame1.SelectedPage = navigationPage1;
            txtBarkod.DataBindings.Add("Text", _entity, "Barkod", false, DataSourceUpdateMode.OnPropertyChanged);
            txtKul1.DataBindings.Add("Text", _entity, "Kull1", false, DataSourceUpdateMode.OnPropertyChanged);
            txtStokID.DataBindings.Add("Text", _entity, "StokId", false, DataSourceUpdateMode.OnPropertyChanged);
            txtStokKod.DataBindings.Add("Text", _entity, "Stokkodu", false, DataSourceUpdateMode.OnPropertyChanged);
            if (txtKul1.Text=="")
            {
                txtKul1.Text = "1";
            }

        }
        void KayitKapat()
        {
            btnSec.Enabled = true;
            btnEkle.Enabled = true;
            btnDuzenle.Enabled = true; btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            btnVazgec.Enabled = false;
            navigationFrame1.SelectedPage = navigationPage2;
           txtBarkod.DataBindings.Clear();
           txtStokID.DataBindings.Clear();
            txtKul1.DataBindings.Clear();
            txtStokKod.DataBindings.Clear();
        }

        private void FrmStokBarkod_Load_1(object sender, EventArgs e)
        {
            this.Text = context.Stoklar.Where(c => c.StokKodu == Stokkodu).Select(c => c.StokAdi).FirstOrDefault().ToString() + " - Barkod Ekle ";
            Listele();
         
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            KayitKapat();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string secilen =gridTanim.GetFocusedRowCellValue(colBarkod).ToString();
                StokBarkodDAL.Delete(context, c => c.Barkod == secilen);
                StokBarkodDAL.Save(context);
                Listele();
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            string secilen = gridTanim.GetFocusedRowCellValue(colBarkod).ToString();
            _entity = context.StokBarkod.Where(c => c.Barkod == secilen).SingleOrDefault();
            KayitAc();
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            KayitKapat();
        }
    }
}
