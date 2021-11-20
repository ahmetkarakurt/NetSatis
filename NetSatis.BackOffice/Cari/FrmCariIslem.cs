using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using NetSatis.BackOffice.Tanım;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tables;
using NetSatis.Entities.Tools;

namespace NetSatis.BackOffice.Cari
{
    public partial class FrmCariIslem : DevExpress.XtraEditors.XtraForm
    {
        private Entities.Tables.Cari _entity;
        private CariDAL cariDal = new CariDAL();
        private NetSatisContext context = new NetSatisContext();
        public bool saved = false;
        private CodeTool kodOlustur;
        public FrmCariIslem(Entities.Tables.Cari entity, bool kopyala = false)
        {
            InitializeComponent();
            kodOlustur = new CodeTool(this, CodeTool.Table.Cari);
            kodOlustur.BarButonOlustur();
            if (kopyala)
            {
                _entity = new Entities.Tables.Cari();
                _entity.CariKodu = "-1";
                _entity.CariKodu = "";
                _entity.Durumu = entity.Durumu;
                _entity.CariTuru = entity.CariTuru;
                _entity.CariAdi = entity.CariAdi;
                _entity.YetkiliKisi = entity.YetkiliKisi;
                _entity.FaturaUnvani = entity.FaturaUnvani;
                _entity.CepTelefonu = entity.CepTelefonu;
                _entity.Telefon = entity.Telefon;
                _entity.Fax = entity.Fax;
                _entity.EMail = entity.EMail;
                _entity.Web = entity.Web;
                _entity.Il = entity.Il; _entity.Ilce = entity.Ilce;
                _entity.Semt = entity.Semt;
                _entity.Adres = entity.Adres;
                _entity.CariGrubu = entity.CariGrubu;
                _entity.CariAltGrubu = entity.CariAltGrubu;
                _entity.OzelKod1 = entity.OzelKod1;
                _entity.OzelKod2 = entity.OzelKod2;
                _entity.OzelKod3 = entity.OzelKod3;
                _entity.OzelKod4 = entity.OzelKod4;
                _entity.VergiDairesi = entity.VergiDairesi;
                _entity.VergiNo = entity.VergiNo;
                _entity.IskontoOrani = entity.IskontoOrani;
                _entity.RiskLimiti = entity.RiskLimiti;
                _entity.AlisOzelFiyati = entity.AlisOzelFiyati;
                _entity.SatisOzelFiyati = entity.SatisOzelFiyati;
                _entity.Aciklama = entity.Aciklama;
            }
            else
            {
                _entity = entity;
            }


            toggleDurumu.DataBindings.Add("EditValue", _entity, "Durumu", false, DataSourceUpdateMode.OnPropertyChanged);
            txtKod.DataBindings.Add("Text", _entity, "CariKodu", false, DataSourceUpdateMode.OnPropertyChanged);
            txtCariAdi.DataBindings.Add("Text", _entity, "CariAdi", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbCariTuru.DataBindings.Add("Text", _entity, "CariTuru");
            txtYetkiliKisi.DataBindings.Add("Text", _entity, "YetkiliKisi", false, DataSourceUpdateMode.OnPropertyChanged);
            txtFaturaUnvani.DataBindings.Add("Text", _entity, "FaturaUnvani", false, DataSourceUpdateMode.OnPropertyChanged);
            txtVergiDairesi.DataBindings.Add("Text", _entity, "VergiDairesi", false, DataSourceUpdateMode.OnPropertyChanged);
            txtVergiNo.DataBindings.Add("Text", _entity, "VergiNo", false, DataSourceUpdateMode.OnPropertyChanged);
            txtAciklama.DataBindings.Add("Text", _entity, "Aciklama", false, DataSourceUpdateMode.OnPropertyChanged);
            txtCepTelefonu.DataBindings.Add("Text", _entity, "CepTelefonu", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSabitTelefon.DataBindings.Add("Text", _entity, "Telefon", false, DataSourceUpdateMode.OnPropertyChanged);
            txtfax.DataBindings.Add("Text", _entity, "Fax", false, DataSourceUpdateMode.OnPropertyChanged);
            txtEmail.DataBindings.Add("Text", _entity, "Email", false, DataSourceUpdateMode.OnPropertyChanged);
            txtWeb.DataBindings.Add("Text", _entity, "Web", false, DataSourceUpdateMode.OnPropertyChanged);
            txtIl.DataBindings.Add("Text", _entity, "Il", false, DataSourceUpdateMode.OnPropertyChanged);
            txtIlce.DataBindings.Add("Text", _entity, "Ilce", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSemt.DataBindings.Add("Text", _entity, "Semt", false, DataSourceUpdateMode.OnPropertyChanged);
            txtAdres.DataBindings.Add("Text", _entity, "Adres", false, DataSourceUpdateMode.OnPropertyChanged);
            btnCariGrubu.DataBindings.Add("Text", _entity, "CariGrubu", false, DataSourceUpdateMode.OnPropertyChanged);
            btnCariAltGrubu.DataBindings.Add("Text", _entity, "CariAltGrubu", false, DataSourceUpdateMode.OnPropertyChanged);
            btnOzelKod1.DataBindings.Add("Text", _entity, "OzelKod1", false, DataSourceUpdateMode.OnPropertyChanged);
            btnOzelKod2.DataBindings.Add("Text", _entity, "OzelKod2", false, DataSourceUpdateMode.OnPropertyChanged);
            btnOzelKod3.DataBindings.Add("Text", _entity, "OzelKod3", false, DataSourceUpdateMode.OnPropertyChanged);
            btnOzelKod4.DataBindings.Add("Text", _entity, "OzelKod4", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbAlisOzelFiyat.DataBindings.Add("Text", _entity, "AlisOzelFiyati", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbSatisOzelFiyat.DataBindings.Add("Text", _entity, "SatisOzelFiyati", false, DataSourceUpdateMode.OnPropertyChanged);
            txtIskontoOrani.DataBindings.Add("EditValue", _entity, "IskontoOrani", true, DataSourceUpdateMode.OnPropertyChanged, 0, "'%'0");
            txtRiskLimiti.DataBindings.Add("EditValue", _entity, "RiskLimiti", true, DataSourceUpdateMode.OnPropertyChanged, 0, "C2");

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cariDal.AddOrUpdate(context, _entity))
            {
                kodOlustur.KodArtirma();
                cariDal.Save(context);
                saved = true;
                this.Close();
            }
        }
        private void btnCariGrubu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0:
                    FrmTanim form = new FrmTanim(FrmTanim.TanimTuru.CariGrubu);
                    form.ShowDialog();
                    if (form.secildi)
                    {
                        btnCariGrubu.Text = form._entity.Tanimi;
                    }
                    break;
                case 1:
                    btnCariGrubu.Text = null;
                    break;
            }
        }

        private void btnOzelKod1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0:
                    FrmTanim form = new FrmTanim(FrmTanim.TanimTuru.CariOzelKod1);
                    form.ShowDialog();
                    if (form.secildi)
                    {btnOzelKod1.Text = form._entity.Tanimi;
                    }
                    break;
                case 1:
                    btnOzelKod1.Text = null;
                    break;
            }
        }
        private void FrmCariIslem_Load(object sender, EventArgs e)
        {

    }

        private void btnCariAltGrubu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0:
                    FrmTanim form = new FrmTanim(FrmTanim.TanimTuru.CariAltGrubu);
                    form.ShowDialog();
                    if (form.secildi)
                    {
                        btnCariAltGrubu.Text = form._entity.Tanimi;
                    }
                    break;
                case 1:
                    btnCariAltGrubu.Text = null;
                    break;
            }
        }

        private void btnOzelKod2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0:
                    FrmTanim form = new FrmTanim(FrmTanim.TanimTuru.CariOzelKod2);
                    form.ShowDialog();
                    if (form.secildi)
                    {
                        btnOzelKod2.Text = form._entity.Tanimi;
                    }
                    break;
                case 1:
                    btnOzelKod2.Text = null;
                    break;
            }
        }

        private void btnOzelKod3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0:
                    FrmTanim form = new FrmTanim(FrmTanim.TanimTuru.CariOzelKod3);
                    form.ShowDialog();
                    if (form.secildi)
                    {
                        btnOzelKod3.Text = form._entity.Tanimi;
                    }
                    break;
                case 1:
                    btnOzelKod3.Text = null;
                    break;
            }
        }

        private void btnOzelKod4_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0:
                    FrmTanim form = new FrmTanim(FrmTanim.TanimTuru.CariOzelKod4);
                    form.ShowDialog();
                    if (form.secildi)
                    {
                        btnOzelKod4.Text = form._entity.Tanimi;
                    }
                    break;
                case 1:
                    btnOzelKod4.Text = null;
                    break;
            }
        }
    }
}