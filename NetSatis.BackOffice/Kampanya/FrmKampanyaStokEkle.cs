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
using NetSatis.BackOffice.Stok;
using System.Data.Entity;

namespace NetSatis.BackOffice.Tanım
{
    public partial class FrmKampanyaStokEkle : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        int Kampanya_kod;
          string KampanyaTuru;
        KampanyaUrunDAL urunEkle = new KampanyaUrunDAL();




        public FrmKampanyaStokEkle(int _Kampnya_Kod,string _KampanyaTuru)
        {
            InitializeComponent();
            Kampanya_kod = _Kampnya_Kod;
            KampanyaTuru = _KampanyaTuru;
            // gridcontIndirimler.DataSource = context.KampanyaUrun.
            //    Where(c => c.KampanyaTuru == KampanyaTuru && c.KampanyaKodId == Kampanya_kod).ToList();
            //   gridcontIndirimler.DataSource = context.KampanyaTuru.Local.Where(c => c.KampanyaTuru. == KampanyaTuru && c.KampanyaKodId == Kampanya_kod).ToBindingList();
            gridcontIndirimler.DataSource = context.KampanyaUrun.
              Where(c => c.KampanyaTuru == KampanyaTuru && c.KampanyaKodId == Kampanya_kod).ToList();

        }
        private void FrmKampanyaStokEkle_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
           
            gridcontkmpya.DataSource = context.KampanyaUrun.
               Where(c => c.KampanyaTuru == KampanyaTuru && c.KampanyaKodId == Kampanya_kod).ToList();
         
        }
        private KampanyaUrun StokEkle(Entities.Tables.Stok entity)
        {
            KampanyaUrun _entity = new KampanyaUrun();
            _entity.StokKodu = entity.StokKodu;
            _entity.Barkod = entity.Barkod;
            _entity.StokAdi = entity.StokAdi;
            _entity.SubeId = 1;//sube ıd değişecek

            return _entity;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmStokSec form = new FrmStokSec(true);
            form.ShowDialog();
            if (form.secildi)
            {
                foreach (var itemStok in form.secilen)
                {
                    KampanyaUrun _entity = new KampanyaUrun();
                    _entity = StokEkle(itemStok);
                    var count = context.KampanyaUrun.Count(c => c.StokKodu == itemStok.StokKodu);
                    if (count != 0)
                    {
                        if (MessageBox.Show("Seçili olan stoğa daha önceden eklenmiş bir Kampanya bulunmaktadır. Var olan Kampanyayı güncellemek ister misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            var secilenId = context.KampanyaUrun.SingleOrDefault(c => c.StokKodu == itemStok.StokKodu);
                            _entity.Id = secilenId.Id;
                            _entity.SubeId = 1;//sube Id değişecek
                            urunEkle.AddOrUpdate(context, _entity);
                        }
                    }
                    else
                    {
                        urunEkle.AddOrUpdate(context, _entity);
                    }
                }
            }
            gridcontIndirimler.DataSource = context.KampanyaUrun.Local.ToBindingList().
               Where(c => c.KampanyaTuru == KampanyaTuru && c.KampanyaKodId == Kampanya_kod);

            //   gridcontIndirimler.DataSource = context.KampanyaUrun.Local.ToBindingList();
            Listele();
        }

        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            foreach (var itemIndirim in context.KampanyaUrun.Local.ToList())
            {

                if (btnSuresiz.Checked)
                {
                    itemIndirim.KampanyaSure = "Süresiz";
                }
                else
                {
                    itemIndirim.BaslangicTarihi = dateBaslangic.DateTime;
                    itemIndirim.BitisTarihi = dateBitis.DateTime;
                    itemIndirim.KampanyaSure = "Tarih Arasında";
                }
                itemIndirim.Durumu = true;
                itemIndirim.Aciklama = txtAciklama.Text;
                itemIndirim.KampanyaTuru = KampanyaTuru;
                itemIndirim.KampanyaKodId = Kampanya_kod;

            }
            urunEkle.Save(context);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi listeden çıkarmak istediğinize emin misiniz?", "Uyarı",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(gridIndirimler.GetFocusedRowCellValue(colId).ToString());
               // var secilenStokKodu = gridIndirimler.GetFocusedRowCellValue(colStokKodu).ToString();              
               // var secilen = urunEkle.GetByFilter(context, c => c.StokKodu == secilenStokKodu);
                urunEkle.Delete(context, c => c.Id ==id );
                urunEkle.Save(context);
                // context.Entry(secilen).State = EntityState.Detached;
                gridcontIndirimler.DataSource = context.KampanyaUrun.
               Where(c => c.KampanyaTuru == KampanyaTuru && c.KampanyaKodId == Kampanya_kod).ToList();


            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
          //  gridcontIndirimler.DataSource = context.KampanyaUrun.
          //  Where(c => c.KampanyaTuru == KampanyaTuru && c.KampanyaKodId == Kampanya_kod).ToList();
        }
    }
}