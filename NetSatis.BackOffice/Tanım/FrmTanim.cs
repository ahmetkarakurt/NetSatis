﻿using System;
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
    public partial class FrmTanim : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        TanimDAL tanimDal = new TanimDAL();
        private TanimTuru _tanimTuru;
        public Tanim _entity;
        public bool secildi = false;
        public FrmTanim(TanimTuru tanimTuru)
        {
            InitializeComponent();
            _tanimTuru = tanimTuru;


        }
        public enum TanimTuru
        {
            CariGrubu,
            CariAltGrubu,
            CariOzelKod1,
            CariOzelKod2,
            CariOzelKod3,
            CariOzelKod4,
            PersonelUnvan,
            StokGrubu,
            StokAltGrubu,
            StokOzelKod1,
            StokOzelKod2,
            StokOzelKod3,
            StokOzelKod4,
            Marka,
            Model,Birimi
        }

        private void FrmTanim_Load(object sender, EventArgs e)
        {
            Listele();

        }

        void KayitAc()
        {
            btnSec.Enabled = false;
            btnEkle.Enabled = false;
            btnDuzenle.Enabled = false;
            btnSil.Enabled = false; btnKaydet.Enabled = true;
            btnVazgec.Enabled = true;
            navigationFrame1.SelectedPage = navigationPage1;
            txtTanim.DataBindings.Add("Text", _entity, "Tanimi");
            txtAciklama.DataBindings.Add("Text", _entity, "Aciklama");
        }
        void KayitKapat()
        {
            btnSec.Enabled = true;
            btnEkle.Enabled = true;
            btnDuzenle.Enabled = true; btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            btnVazgec.Enabled = false;
            navigationFrame1.SelectedPage = navigationPage2;
            txtTanim.DataBindings.Clear();
            txtAciklama.DataBindings.Clear();
        }
        void Listele()
        {
            gridcontTanim.DataSource = tanimDal.GetAll(context, c => c.Turu == _tanimTuru.ToString());
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {

            _entity = new Tanim();
            KayitAc();

        }
        private void btnDuzenle_Click(object sender, EventArgs e)
        {

            int secilen = Convert.ToInt32(gridTanim.GetFocusedRowCellValue(colId));
            _entity = context.Tanimlar.Where(c => c.Id == secilen).SingleOrDefault();
            KayitAc();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int secilen = Convert.ToInt32(gridTanim.GetFocusedRowCellValue(colId));
                tanimDal.Delete(context, c => c.Id == secilen);
                tanimDal.Save(context);
                Listele();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            _entity.Turu = _tanimTuru.ToString();
            
            if (tanimDal.AddOrUpdate(context, _entity))
            {
                tanimDal.Save(context);
                KayitKapat();
                Listele();
            }
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            KayitKapat();
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            if (gridTanim.RowCount == 0)
            {
                MessageBox.Show("Seçili bir kayıt bulunamadı.");
            }
            else
            {
                int secilen = Convert.ToInt32(gridTanim.GetFocusedRowCellValue(colId));
                _entity = context.Tanimlar.Where(c => c.Id == secilen).SingleOrDefault();
                secildi = true;
                this.Close();
            }

        }
    }
}