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

namespace NetSatis.FrontOffice
{
    public partial class FrmDipiskonto : DevExpress.XtraEditors.XtraForm
    {
        public FrmDipiskonto()
        {
            InitializeComponent();
        }

        public decimal KalemSayisi,kalembasiFiyatDus,Toptut;
        private void FrmDipiskonto_Load(object sender, EventArgs e)
        {
            textEdit1.Text = KalemSayisi.ToString();
        }

        private void txtKalem_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtİskontoOran.Text = (Convert.ToDecimal(txtFiyat.Text) - Convert.ToDecimal(txtKalem.Text)).ToString();
            }
            catch (Exception)
            {

             
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //   kalembasiFiyatDus = Convert.ToDecimal(txtİskontoOran.Text) / KalemSayisi;
            Toptut = (Convert.ToDecimal(txtİskontoOran.Text) / (Convert.ToDecimal(txtFiyat.Text)) * 100);
            this.Close();
            
        }

        private void txtİskontoOran_EditValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}