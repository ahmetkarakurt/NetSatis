using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NetSatis.BackOffice.Cari;
using NetSatis.BackOffice.Fiş;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;

namespace NetSatis.BackOffice.Personel
{
    public partial class FrmPersonel : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        PersonelDAL personelDal = new PersonelDAL();
        private int _secilen;
        public FrmPersonel()
        {
            InitializeComponent();
        }

        private void Listele()
        {
            gridcontPersonel.DataSource = personelDal.PersonelListele(context);
        }
        private void FrmPlasiyer_Load(object sender, System.EventArgs e)
        {
            Listele();
        }

        private void btnGuncelle_Click(object sender, System.EventArgs e)
        {
            Listele();
        }

        private void btnAra_Click(object sender, System.EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
        }

        private void btnKapat_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrele_Click(object sender, System.EventArgs e)
        {
            filterControl1.ApplyFilter();
        }

        private void btnFiltreIptal_Click(object sender, System.EventArgs e)
        {
            filterControl1.FilterString = null;
            filterControl1.ApplyFilter();
        }

        private void btnFiltreKapat_Click(object sender, System.EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
        }
        private void btnSil_Click(object sender, System.EventArgs e)
        {
            _secilen =Convert.ToInt32(gridPersonel.GetFocusedRowCellValue(colId));
            if (MessageBox.Show("Seçili olan kaydı silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                personelDal.Delete(context, c => c.Id == _secilen);
                personelDal.Save(context);
                Listele();
            }
        }

        private void btnEkle_Click(object sender, System.EventArgs e)
        {
            FrmPersonelIslem form = new FrmPersonelIslem(new Entities.Tables.Personel());
            form.ShowDialog();
            if (form.saved)
            {
                Listele();
            }
        }

        private void btnDuzenle_Click(object sender, System.EventArgs e)
        {
            _secilen = Convert.ToInt32(gridPersonel.GetFocusedRowCellValue(colId));
            FrmPersonelIslem form = new FrmPersonelIslem(personelDal.GetByFilter(context, c => c.Id == _secilen));
            form.ShowDialog();
            if (form.saved)
            {
                Listele();
            }
        }

        private void btnCariHareket_Click(object sender, System.EventArgs e)
        {
            _secilen = Convert.ToInt32(gridPersonel.GetFocusedRowCellValue(colId));

            FrmPersonelHareket form = new FrmPersonelHareket(_secilen);
            form.ShowDialog();
        }

        private void simpleButton1_Click(object sender, System.EventArgs e)
        {
            FrmFisIslem form=new FrmFisIslem(null,"Hakediş Fişi");
            form.ShowDialog();}
    }
}