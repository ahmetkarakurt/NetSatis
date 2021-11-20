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
using NetSatis.BackOffice.Fiş;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tables;

namespace NetSatis.BackOffice.Cari
{
    public partial class FrmCariHareket : DevExpress.XtraEditors.XtraForm
    {
        CariDAL cariDal=new CariDAL();
        NetSatisContext context=new NetSatisContext();
        private string _cariKodu;
        public FrmCariHareket(string CariKodu)
        {
            InitializeComponent();
            _cariKodu = CariKodu;
            var cariEntity = cariDal.GetByFilter(context, c => c.CariKodu == _cariKodu);

            lblBaslik.Text = cariEntity.CariKodu + " - " + cariEntity.CariAdi + " Hareketleri";
        }

        private void FrmCariHareket_Load(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void Guncelle()
        {
            gridcontFisToplam.DataSource=cariDal.CariFisGenelToplam(context,_cariKodu);
            gridcontBakiye.DataSource = cariDal.CariGenelToplam(context, _cariKodu);
            gridcontCariHareket.DataSource = cariDal.CariFisAyrinti(context, _cariKodu);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (gridCariHareket.OptionsView.ShowAutoFilterRow == true)
            {
                gridCariHareket.OptionsView.ShowAutoFilterRow = false;
            }
            else
            {
                gridCariHareket.OptionsView.ShowAutoFilterRow = true;
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            FrmFisIslem form=new FrmFisIslem(fisKodu: gridCariHareket.GetFocusedRowCellValue(colFisKodu).ToString());
            form.ShowDialog();
        }
    }
}