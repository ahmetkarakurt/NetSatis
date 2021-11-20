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

namespace NetSatis.BackOffice.Stok
{
    public partial class FrmStokSec : DevExpress.XtraEditors.XtraForm
    {
        StokDAL stokDal = new StokDAL();
        NetSatisContext context = new NetSatisContext();
        public List<Entities.Tables.Stok> secilen = new List<Entities.Tables.Stok>();
        public string stokkodu;
        public bool secildi = false;
        public FrmStokSec(bool cokluSecim = false)
        {
            InitializeComponent();
            if (cokluSecim)
            {
                lblUyari.Visible = true;
                gridStoklar.OptionsSelection.MultiSelect = true;
            }

        }
        int SimdiW = 1360;
        int SimdiH = 760;
        private void FrmStokSec_Load(object sender, EventArgs e)
        {
            //this.Location = new Point(0, 0);
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //Rectangle ClientCoz = new Rectangle();
            //ClientCoz = Screen.GetBounds(ClientCoz);
            //float OranW = ((float)ClientCoz.Width / (float)SimdiW);
            //float OranH = ((float)ClientCoz.Height / (float)SimdiH);
            //this.Scale(new SizeF(OranW, OranH));
            gridcontStoklar.DataSource = stokDal.StokListele(context);
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (gridStoklar.GetSelectedRows().Length!=0)
            {
                foreach (var row in gridStoklar.GetSelectedRows())
                {
                     stokkodu = gridStoklar.GetRowCellValue(row, colStokKodu).ToString();
                    secilen.Add(context.Stoklar.SingleOrDefault(c => c.StokKodu == stokkodu));
                }

                secildi = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Seçilen bir ürün bulunamadı.");
            }
        }

        private void gridStoklar_DoubleClick(object sender, EventArgs e)
        {
            if (gridStoklar.GetSelectedRows().Length != 0)
            {
                foreach (var row in gridStoklar.GetSelectedRows())
                {
                    stokkodu = gridStoklar.GetRowCellValue(row, colStokKodu).ToString();
                    secilen.Add(context.Stoklar.SingleOrDefault(c => c.StokKodu == stokkodu));
                }

                secildi = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Seçilen bir ürün bulunamadı.");
            }
        }
    }
}