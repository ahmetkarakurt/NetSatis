﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.DashboardCommon;
using DevExpress.XtraEditors;

namespace NetSatis.BackOffice.Raporlar
{
    public partial class FrmOzgunRaporlar : DevExpress.XtraEditors.XtraForm
    {
        public FrmOzgunRaporlar(List<object> veriListesi=null)
        {
            InitializeComponent();
            if (veriListesi != null)
            {
                foreach (var veri in veriListesi)
                {
                    DashboardObjectDataSource dataSource=new DashboardObjectDataSource();
                    dataSource.DataSource = veri;
                    dataSource.Fill();
                    dashboardDesigner1.Dashboard.DataSources.Add(dataSource);
                }
            }
        }
    }
}