﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;

namespace NetSatis.BackOffice.Raporlar
{
    public partial class FrmOzgunRaporHazirla : DevExpress.XtraEditors.XtraForm
    {
        private List<object> veriListesi=new List<object>();
            NetSatisContext context=new NetSatisContext();
        public FrmOzgunRaporHazirla()
        {
            InitializeComponent();
        }
        private void FrmOzgunRaporHazirla_Load(object sender, EventArgs e)
        {

        }
        private void btnHazirla_Click(object sender, EventArgs e)
        {
            veriListesi.Clear();
            foreach (var itemChecked in checkedListBoxControl1.Items.Where(c=>c.CheckState==CheckState.Checked).ToList())
            {
                Type tip = Assembly.Load("NetSatis.Entities").GetTypes()
                    .SingleOrDefault(c => c.Name == itemChecked.Value.ToString());
                object veri = Activator.CreateInstance(tip);

                MethodInfo info = tip.GetMethod(itemChecked.Tag.ToString());

                try
                {
                    veriListesi.Add(info.Invoke(veri, new object[] { context }));

                }catch (Exception)
                {
                    veriListesi.Add(info.Invoke(veri, new object[] { context,null }));
                }
               
                  
            }

            FrmOzgunRaporlar form=new FrmOzgunRaporlar(veriListesi);
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }
    }
}