using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.DataProcessing;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;

namespace NetSatis.BackOffice.Kod
{
    public partial class FrmKodlar : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        private Entities.Tables.Kod _entity;
        private string _tablo;
        public FrmKodlar(string tablo)
        {
            InitializeComponent();
            _tablo = tablo;
            if (_tablo == "Fis")
            {
                context.Kodlar.Where(c => c.Tablo == _tablo && c.OnEki != "FO").Load();
            }
            else
            {
                context.Kodlar.Where(c => c.Tablo == _tablo).Load();
            }

            gridcontTanim.DataSource = context.Kodlar.Local.ToBindingList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            context.Kodlar.Local.ForEach(c => c.Tablo = _tablo);
            context.SaveChanges();
            this.Close();
        }

        private void gridTanim_ShowingEditor(object sender, CancelEventArgs e)
        {
            if ((gridTanim.FocusedRowHandle == GridControl.NewItemRowHandle && gridTanim.FocusedColumn == colSil) || (gridTanim.FocusedRowHandle != GridControl.NewItemRowHandle && gridTanim.FocusedColumn != colSil))
            {
                e.Cancel = true;
            }}private void gridTanim_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            Entities.Tables.Kod row = (Entities.Tables.Kod)e.Row;

            if ((row.OnEki == "FO" && _tablo == "Fis") || context.Kodlar.Local.Any(c => c.OnEki == row.OnEki) )
            {
                MessageBox.Show("Girdiğiniz ön ek daha önce kaydedilmiş veya ön eke izin verilmiyor.");
                gridTanim.CancelUpdateCurrentRow();
            }

        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridTanim.DeleteSelectedRows();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}