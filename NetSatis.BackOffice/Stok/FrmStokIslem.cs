using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NetSatis.BackOffice.Tanım;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tools;

namespace NetSatis.BackOffice.Stok
{
    public partial class FrmStokIslem : XtraForm
    {
        private Entities.Tables.Stok _entity;
        private StokDAL stokDal = new StokDAL();
        private NetSatisContext context = new NetSatisContext();
        public bool saved = false;
        private CodeTool kodOlustur;
        public FrmStokIslem(Entities.Tables.Stok entity, bool kopyala = false ,bool BarkodEklemekapat=true)
        {
            InitializeComponent();
            kodOlustur = new CodeTool(this, CodeTool.Table.Stok);
            kodOlustur.BarButonOlustur();
            if (kopyala)
            {
                _entity = new Entities.Tables.Stok();        
                _entity.StokKodu = "";
                _entity.Durumu = entity.Durumu;
                _entity.Barkod = entity.Barkod;
                _entity.BarkodTuru = entity.BarkodTuru;
                _entity.StokAdi = entity.StokAdi;
                _entity.Birimi = entity.Birimi;
                _entity.UreticiKodu = entity.UreticiKodu;
                _entity.GarantiSuresi = entity.GarantiSuresi;
                _entity.MinStokMiktari = entity.MinStokMiktari;
                _entity.MaxStokMiktari = entity.MaxStokMiktari;
                _entity.Aciklama = entity.Aciklama;
                _entity.StokGrubu = entity.StokGrubu;
                _entity.StokAltGrubu = entity.StokAltGrubu;
                _entity.Marka = entity.Marka;
                _entity.Modeli = entity.Modeli;
                _entity.OzelKod1 = entity.OzelKod1;
                _entity.OzelKod2 = entity.OzelKod2;
                _entity.OzelKod3 = entity.OzelKod3;
                _entity.OzelKod4 = entity.OzelKod4;
                _entity.AlisKdv = entity.AlisKdv;
                _entity.SatisKdv = entity.SatisKdv;
                _entity.AlisFiyati1 = entity.AlisFiyati1;
                _entity.AlisFiyati2 = entity.AlisFiyati2;
                _entity.AlisFiyati3 = entity.AlisFiyati3;
                _entity.SatisFiyati1 = entity.SatisFiyati1;
                _entity.SatisFiyati2 = entity.SatisFiyati2;
                _entity.SatisFiyati3 = entity.SatisFiyati3;

               
            }
            else
            {
                _entity = entity;
            
            }

            toggleDurumu.DataBindings.Add("EditValue", _entity, "Durumu", false, DataSourceUpdateMode.OnPropertyChanged);
            txtKod.DataBindings.Add("Text", _entity, "StokKodu", false, DataSourceUpdateMode.OnPropertyChanged);
            txtBarkod.DataBindings.Add("Text", _entity, "Barkod", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbBarkodTuru.DataBindings.Add("Text", _entity, "BarkodTuru", false, DataSourceUpdateMode.OnPropertyChanged);
            txtStokAdi.DataBindings.Add("Text", _entity, "StokAdi", false, DataSourceUpdateMode.OnPropertyChanged);
            btnBirimi.DataBindings.Add("Text", _entity, "Birimi");
            txtUreticiKodu.DataBindings.Add("Text", _entity, "UreticiKodu", false, DataSourceUpdateMode.OnPropertyChanged);
            txtGarantiSuresi.DataBindings.Add("Text", _entity, "GarantiSuresi", false, DataSourceUpdateMode.OnPropertyChanged);
            calcMaxStokMiktari.DataBindings.Add("EditValue", _entity, "MaxStokMiktari", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N3");
            calcMinStokMiktari.DataBindings.Add("EditValue", _entity, "MinStokMiktari", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N3");
            txtAciklama.DataBindings.Add("Text", _entity, "Aciklama", false, DataSourceUpdateMode.OnPropertyChanged);
            btnStokGrubu.DataBindings.Add("Text", _entity, "StokGrubu", false, DataSourceUpdateMode.OnPropertyChanged);
            btnStokAltGrubu.DataBindings.Add("Text", _entity, "StokAltGrubu", false, DataSourceUpdateMode.OnPropertyChanged);
            btnMarka.DataBindings.Add("Text", _entity, "Marka", false, DataSourceUpdateMode.OnPropertyChanged);
            btnModel.DataBindings.Add("Text", _entity, "Modeli", false, DataSourceUpdateMode.OnPropertyChanged);
            btnOzelKod1.DataBindings.Add("Text", _entity, "OzelKod1", false, DataSourceUpdateMode.OnPropertyChanged);
            btnOzelKod2.DataBindings.Add("Text", _entity, "OzelKod2", false, DataSourceUpdateMode.OnPropertyChanged);
            btnOzelKod3.DataBindings.Add("Text", _entity, "OzelKod3", false, DataSourceUpdateMode.OnPropertyChanged);
            btnOzelKod4.DataBindings.Add("Text", _entity, "OzelKod4", false, DataSourceUpdateMode.OnPropertyChanged);
            calcAlisKdv.DataBindings.Add("EditValue", _entity, "AlisKdv", true, DataSourceUpdateMode.OnPropertyChanged, 0, "'%'0");
            calcSatisKdv.DataBindings.Add("EditValue", _entity, "SatisKdv", true, DataSourceUpdateMode.OnPropertyChanged, 0, "'%'0");
            calcAlisFiyati1.DataBindings.Add("EditValue", _entity, "AlisFiyati1", true, DataSourceUpdateMode.OnPropertyChanged, 0, "C2");
            calcAlisFiyati2.DataBindings.Add("EditValue", _entity, "AlisFiyati2", true, DataSourceUpdateMode.OnPropertyChanged, 0, "C2");
            calcAlisFiyati3.DataBindings.Add("EditValue", _entity, "AlisFiyati3", true, DataSourceUpdateMode.OnPropertyChanged, 0, "C2");
            calcSatisFiyati1.DataBindings.Add("EditValue", _entity, "SatisFiyati1", true, DataSourceUpdateMode.OnPropertyChanged, 0, "C2");
            calcSatisFiyati2.DataBindings.Add("EditValue", _entity, "SatisFiyati2", true, DataSourceUpdateMode.OnPropertyChanged, 0, "C2");
            calcSatisFiyati3.DataBindings.Add("EditValue", _entity, "SatisFiyati3", true, DataSourceUpdateMode.OnPropertyChanged, 0, "C2");
            tgTerazi.DataBindings.Add("EditValue",_entity, "Terazi", false, DataSourceUpdateMode.OnPropertyChanged);
            cbTeraziDurum.DataBindings.Add("Text",_entity, "TeraziDurum",false, DataSourceUpdateMode.OnPropertyChanged);
            btnbar.ReadOnly = BarkodEklemekapat;
        
        }
        private decimal Kar(decimal SatisFiyati,decimal AlisFiyati)
        {
            try
            {
                decimal kar = SatisFiyati - AlisFiyati;
                kar = (kar / AlisFiyati) * 100;
                return kar;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        private void FrmStokIslem_Load(object sender, EventArgs e)
        {
           // txtSatisKar1.Value = Kar(calcSatisFiyati1.Value, calcAlisFiyati1.Value);
           // txtSatisKar2.Value = Kar(calcSatisFiyati2.Value, calcAlisFiyati2.Value);
           // txtSatisKar3.Value = Kar(calcSatisFiyati3.Value, calcAlisFiyati3.Value);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (stokDal.AddOrUpdate(context, _entity))
            {
                kodOlustur.KodArtirma();
                stokDal.Save(context);
                saved = true;
                this.Close();
            }

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStokGrubu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0:
                    FrmTanim form = new FrmTanim(FrmTanim.TanimTuru.StokGrubu);
                    form.ShowDialog();
                    if (form.secildi)
                    {
                        btnStokGrubu.Text = form._entity.Tanimi;
                    }
                    break;
                case 1:
                    btnStokGrubu.Text = null;
                    break;
            }
        }

        private void btnStokAltGrubu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0:
                    FrmTanim form = new FrmTanim(FrmTanim.TanimTuru.StokAltGrubu);
                    form.ShowDialog();
                    if (form.secildi)
                    {
                        btnStokAltGrubu.Text = form._entity.Tanimi;
                    }
                    break;
                case 1:
                    btnStokAltGrubu.Text = null;
                    break;
            }
        }

        private void btnMarka_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0:
                    FrmTanim form = new FrmTanim(FrmTanim.TanimTuru.Marka);
                    form.ShowDialog();
                    if (form.secildi)
                    {
                        btnMarka.Text = form._entity.Tanimi;
                    }
                    break;
                case 1:
                    btnMarka.Text = null;
                    break;
            }
        }

        private void btnModel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0:
                    FrmTanim form = new FrmTanim(FrmTanim.TanimTuru.Model);
                    form.ShowDialog();
                    if (form.secildi)
                    {
                        btnModel.Text = form._entity.Tanimi;
                    }
                    break;
                case 1:
                    btnModel.Text = null;
                    break;
            }
        }

        private void btnOzelKod1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0:
                    FrmTanim form = new FrmTanim(FrmTanim.TanimTuru.StokOzelKod1);
                    form.ShowDialog();
                    if (form.secildi)
                    {
                        btnOzelKod1.Text = form._entity.Tanimi;
                    }
                    break;
                case 1:
                    btnOzelKod1.Text = null;
                    break;
            }
        }

        private void btnOzelKod2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0:
                    FrmTanim form = new FrmTanim(FrmTanim.TanimTuru.StokOzelKod2);
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
                    FrmTanim form = new FrmTanim(FrmTanim.TanimTuru.StokOzelKod3);
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
                    FrmTanim form = new FrmTanim(FrmTanim.TanimTuru.StokOzelKod4);
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

        private void btnBirimi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0:FrmTanim form = new FrmTanim(FrmTanim.TanimTuru.Birimi);
                    form.ShowDialog();
                    if (form.secildi)
                    {
                        btnBirimi.Text = form._entity.Tanimi;
                    }
                    break;
                case 1:
                    btnBirimi.Text = null;
                    break;
            }
        }

        private void btnbar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!btnbar.ReadOnly)
            {
                switch (e.Button.Index)
                {
                    case 0:
                        FrmStokBarkod form = new FrmStokBarkod(txtKod.Text);
                        form.ShowDialog();

                        break;
                    case 1:
                        btnBirimi.Text = null;
                        break;
                }
            }
            
        }

        private void tgTerazi_Toggled(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(tgTerazi.EditValue))
            {
                cbTeraziDurum.Visible = true;
                cbTeraziDurum.SelectedIndex = 0;
            }

            else
            {
                cbTeraziDurum.Visible = false;
                cbTeraziDurum.SelectedIndex = -1;
            }
           
           
        }

        private void txtSatisKar1_TextChanged(object sender, EventArgs e)
        {
            //calcSatisFiyati1.Value = (calcAlisFiyati1.Value * txtSatisKar1.Value) / 100 + calcAlisFiyati1.Value;
        }

        private void calcSatisFiyati1_TextChanged(object sender, EventArgs e)
        {

            //txtSatisKar1.Value = Kar(calcSatisFiyati1.Value, calcAlisFiyati1.Value);
        }

        private void calcSatisFiyati2_TextChanged(object sender, EventArgs e)
        {
           // txtSatisKar2.Value = Kar(calcSatisFiyati2.Value, calcAlisFiyati2.Value);
        }

        private void calcSatisFiyati3_TextChanged(object sender, EventArgs e)
        {
           // txtSatisKar3.Value = Kar(calcSatisFiyati3.Value, calcAlisFiyati3.Value);
        }

        private void txtSatisKar2_TextChanged(object sender, EventArgs e)
        {
           // calcSatisFiyati2.Value = (calcAlisFiyati2.Value * txtSatisKar2.Value) / 100 + calcAlisFiyati2.Value;
        }

        private void txtSatisKar3_TextChanged(object sender, EventArgs e)
        {
           // calcSatisFiyati3.Value = (calcAlisFiyati3.Value * txtSatisKar3.Value) / 100 + calcAlisFiyati3.Value;
        }
    }
}
