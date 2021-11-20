using System.Linq;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;

namespace NetSatis.BackOffice.Personel
{
    public partial class FrmPersonelHareket : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context=new NetSatisContext();
        PersonelDAL personelDal=new PersonelDAL();
        FisDAL fisDal=new FisDAL();
        private int _personelId;
        public FrmPersonelHareket(int personelId)
        {
            InitializeComponent();
            _personelId = personelId;
            var personelBilgi = context.Personeller.SingleOrDefault(c => c.Id == personelId);
            lblBaslik.Text = personelBilgi.PersonelKodu + " - " + personelBilgi.PersonelAdi;

        }

        private void FrmPlasiyerHareket_Load(object sender, System.EventArgs e)
        {
            Listele();
        }
        private void Listele()
        {
            gridcontPersonelHareket.DataSource = fisDal.GetAll(context, c => c.PlasiyerId == _personelId);
            gridcontFisToplam.DataSource = personelDal.PersonelFisToplam(context, _personelId);
        }

        private void btnGuncelle_Click(object sender, System.EventArgs e){
            Listele();
        }

        private void btnAra_Click(object sender, System.EventArgs e)
        {
            gridPersonelHareket.OptionsView.ShowAutoFilterRow = true ? gridPersonelHareket.OptionsView.ShowAutoFilterRow==false : gridPersonelHareket.OptionsView.ShowAutoFilterRow==true;
        }

        private void btnKapat_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}