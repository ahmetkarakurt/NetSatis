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
using NetSatis.Entities.Tools;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;

namespace NetSatis.FrontOffice.Stok
{
    public partial class FrmHavuzStok : DevExpress.XtraEditors.XtraForm
    {
        string Barkod, Stok;
        private CodeTool kodOlustur;
        private Entities.Tables.Stok _entity;
        private StokDAL stokDal = new StokDAL();
        private NetSatisContext context = new NetSatisContext();
        public FrmHavuzStok(string _Barkod,string _Stok)
        {
            InitializeComponent();
            Barkod = _Barkod;
            Stok = _Stok;
            txtBarkod.Text = Barkod;
            txtStokAdi.Text = Stok;
            kodOlustur = new CodeTool(this, CodeTool.Table.Stok);
            kodOlustur.BarButonOlustur();


            _entity = new Entities.Tables.Stok();
            _entity.StokKodu = kodOlustur.KoduTXTgetir();
            _entity.Durumu = true;
            _entity.StokAdi = Stok;
            _entity.Barkod = Barkod;




            txtKod.DataBindings.Add("Text", _entity, "StokKodu", false, DataSourceUpdateMode.OnPropertyChanged);
            txtBarkod.DataBindings.Add("Text", _entity, "Barkod", false, DataSourceUpdateMode.OnPropertyChanged);
            txtStokAdi.DataBindings.Add("Text", _entity, "StokAdi", false, DataSourceUpdateMode.OnPropertyChanged);
            btnBirimi.DataBindings.Add("Text", _entity, "Birimi");
            txtAciklama.DataBindings.Add("Text", _entity, "Aciklama", false, DataSourceUpdateMode.OnPropertyChanged);
            btnStokGrubu.DataBindings.Add("Text", _entity, "StokGrubu", false, DataSourceUpdateMode.OnPropertyChanged);
            btnStokAltGrubu.DataBindings.Add("Text", _entity, "StokAltGrubu", false, DataSourceUpdateMode.OnPropertyChanged);
            calcAlisKdv.DataBindings.Add("EditValue", _entity, "AlisKdv", true, DataSourceUpdateMode.OnPropertyChanged, 0, "'%'0");
            calcSatisKdv.DataBindings.Add("EditValue", _entity, "SatisKdv", true, DataSourceUpdateMode.OnPropertyChanged, 0, "'%'0");
            calcAlisFiyati1.DataBindings.Add("EditValue", _entity, "AlisFiyati1", true, DataSourceUpdateMode.OnPropertyChanged, 0, "C2");
            calcSatisFiyati1.DataBindings.Add("EditValue", _entity, "SatisFiyati1", true, DataSourceUpdateMode.OnPropertyChanged, 0, "C2");
            tgTerazi.DataBindings.Add("EditValue", _entity, "Terazi", false, DataSourceUpdateMode.OnPropertyChanged);
            calcAlisKdv.Focus();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            if (stokDal.AddOrUpdate(context, _entity)&&txtKod.Text!="")
            {
                stokDal.Save(context);
                kodOlustur.KodArtirma();
                this.Close();
            }

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmHavuzStok_Load(object sender, EventArgs e)
        {

        }
    }
}