﻿using System;
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

namespace NetSatis.BackOffice.Depo
{
    public partial class FrmDepoSec : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context=new NetSatisContext();
        DepoDAL depoDal=new DepoDAL();
        public Entities.Tables.Depo entity=new Entities.Tables.Depo();
        private string _StokKodu;
        public bool secildi = false;
        public FrmDepoSec(string StokKodu)
        {
            InitializeComponent();
            _StokKodu = StokKodu;
        }

        private void FrmDepoSec_Load(object sender, EventArgs e)
        {
            gridcontDepolar.DataSource = depoDal.DepoBazindaStokListele(context, _StokKodu);
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            if (gridDepolar.SelectedRowsCount != 0)
            {
                string depoKodu = gridDepolar.GetFocusedRowCellValue(colDepoKodu).ToString();
                entity = context.Depolar.SingleOrDefault(c => c.DepoKodu == depoKodu);
                secildi = true;
                this.Close();
            }
        
        }
    }
}