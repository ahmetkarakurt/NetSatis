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
using NetSatis.Entities.Tables;

namespace NetSatis.BackOffice.Personel
{
    public partial class FrmPersonelSec : DevExpress.XtraEditors.XtraForm
    {
        PersonelDAL personelDal = new PersonelDAL();
        NetSatisContext context = new NetSatisContext();
        public List<Entities.Tables.PersonelHareket> secilen = new List<Entities.Tables.PersonelHareket>();
        public bool secildi = false;
        private DateTime _donem;
        public FrmPersonelSec(DateTime donemi,bool cokluSecim = false)
        {
            InitializeComponent();
            if (cokluSecim)
            {
                lblUyari.Visible = true;
                gridPersonel.OptionsSelection.MultiSelect = true;
            }
            _donem = donemi;
            gridcontPersonel.DataSource = personelDal.TariheGorePersonelListele(context,donemi.Month,donemi.Year);
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            if (gridPersonel.GetSelectedRows().Length != 0)
            {
                foreach (var row in gridPersonel.GetSelectedRows())
                {
                    string personelKodu = gridPersonel.GetRowCellValue(row, colPersonelKodu).ToString();
                    secilen.Add(new PersonelHareket
                    {
                        PersonelKodu = gridPersonel.GetRowCellValue(row, colPersonelKodu).ToString(),
                        PersonelAdi = gridPersonel.GetRowCellValue(row, colPersonelAdi).ToString(),
                        TcKimlikNo = gridPersonel.GetRowCellValue(row, colTcKimlikNo).ToString(),
                        Unvani = gridPersonel.GetRowCellValue(row, colUnvani).ToString(),
                        Donemi = _donem,
                        AylikMaasi = Convert.ToDecimal(gridPersonel.GetRowCellValue(row, colAylikMaasi)),
                        PrimOrani = Convert.ToDecimal(gridPersonel.GetRowCellValue(row, colPrimOrani)),
                        ToplamSatis = Convert.ToDecimal(gridPersonel.GetRowCellValue(row, colToplamSatis)),
                    });
                }

                secildi = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Seçilen bir cari bulunamadı.");
            }
        }
    }
}