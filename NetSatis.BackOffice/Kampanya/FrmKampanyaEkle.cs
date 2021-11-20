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
 
    public partial class FrmKampanyaEkle : DevExpress.XtraEditors.XtraForm
    {
        private Entities.Tables.KampanyaAna _entity;
        private KampanyaAnaDaL KampanyaAnaDaL = new KampanyaAnaDaL();
        private NetSatisContext context = new NetSatisContext();
        public FrmKampanyaEkle()
        {
            InitializeComponent();


            var kampanyatur = context.KampanyaTuru.ToList();
            foreach (var item in kampanyatur)
            {
                cmbKampnyaTur.Properties.Items.Add(item.KampanyaTuruAdi);
               
            }
              
              
        }

        private void FrmKampanyaEkle_Load(object sender, EventArgs e)
        {
     
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            _entity = new Entities.Tables.KampanyaAna();
            _entity.KampanyaAdi = txtKampanyaAdi.Text.ToUpper();
            _entity.SubeId = 1;
            _entity.Durumu = Convert.ToBoolean(toggleDurumu.EditValue);
            var kampanya = context.KampanyaTuru.FirstOrDefault(c=>c.KampanyaTuruAdi== cmbKampnyaTur.Text);
            _entity.KampanyaTuru = kampanya.KampanyaTuruKodu;
            if (cmKampanyaSure.Text== "SÜRESİZ")
            {
             
            }
            else
            {
                _entity.BaslangicTarihi = dtBaslangic.DateTime;
                _entity.BitisTarihi = dtBitis.DateTime;
            }
            _entity.KampanyaSure = cmKampanyaSure.Text;
            _entity.IndirimOrani = txtKampnayaindirimORani.Value;
            _entity.KampanyaFiyat = txtKampanyaFiyat.Value;





            if (KampanyaAnaDaL.AddOrUpdate(context, _entity))
            {
                KampanyaAnaDaL.Save(context);
              
                this.Close();
            }
        }

        private void cmKampanyaSure_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmKampanyaSure.Text == "SÜRESİZ")
            {
                dtBaslangic.Enabled = false;
                dtBitis.Enabled = false;
            }
            else
            {
                dtBaslangic.Enabled = true;
                dtBitis.Enabled = true;
            }
        }
    }
}