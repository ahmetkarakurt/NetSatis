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
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Context;

namespace NetSatis.BackOffice.Banka
{
    public partial class FrmBankaSec : DevExpress.XtraEditors.XtraForm
    {
        BankaDAL bankaDal = new BankaDAL();
        NetSatisContext context = new NetSatisContext();
        public Entities.Tables.Banka entity = new Entities.Tables.Banka();
        public bool secildi = false;
        public FrmBankaSec()
        {
            InitializeComponent();
        }

        private void FrmBankaSec_Load(object sender, EventArgs e)
        {
            gridcontSecim.DataSource = bankaDal.BanklaListele(context);
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            if (gridSecim.GetSelectedRows().Length != 0)
            {
                string bankakodu = gridSecim.GetFocusedRowCellValue(colBankaKodu).ToString();
                entity = context.Banka.SingleOrDefault(c => c.BankaKodu == bankakodu);
                secildi = true;
                this.Close();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}