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
    public partial class FrmFiyatDegistir : DevExpress.XtraEditors.XtraForm
    {
        public FrmFiyatDegistir()
        {
            InitializeComponent();
        }

       public decimal OrjFfiyat, iskOran, iskFiyat, isktopFiy = 0;
        private void FrmFiyatDegistir_Load(object sender, EventArgs e)
        {
            txtKalem.Text = txtFiyat.Text;
            OrjFfiyat =Decimal.Parse(txtFiyat.Text);
            isktopFiy = Decimal.Parse(txtFiyat.Text);


        }

        private void txtİskontoOran_EditValueChanged(object sender, EventArgs e)
        {
            iskOran = Math.Abs(ss);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (isktopFiy<=0)
            {
                MessageBox.Show("Seçili ürünü Fiyatı 0","Hatalı Stok Fiyatı",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            }
            else
            {
                this.Close();
            }

        }
        decimal ss;
        private void txtKalem_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ss = ((decimal.Parse(txtKalem.Text) / OrjFfiyat) - 1) * (-100);
                iskOran = ss;
                txtİskontoOran.Text = ss.ToString();
            }
            catch (Exception)
            {

              
            }
        }

        private void txtİskontoTutar_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
        //   hesapla();
        }

        private void txtİskontoTutar_EditValueChanged(object sender, EventArgs e)
        {
        }

       
    }
}