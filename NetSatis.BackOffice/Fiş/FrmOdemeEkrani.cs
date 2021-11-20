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
using NetSatis.BackOffice.Kasa;
using NetSatis.Entities.Context;
using NetSatis.Entities.Tables;
using NetSatis.Entities.Tools;

namespace NetSatis.BackOffice.Fiş
{
    public partial class FrmOdemeEkrani : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        public KasaHareket entity;
        private Nullable<decimal> gelenTutar;
        private Entities.Tables.Kasa _kasabilgi;
        private OdemeTuru _odemeTuruBilgi;
        public FrmOdemeEkrani(int odemeTuruId, Nullable<decimal> odenmesiGereken = null)
        {
            InitializeComponent();
            int kasaId = Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_VarsayilanKasa));
            _kasabilgi = context.Kasalar.SingleOrDefault(c => c.Id == kasaId);
            _odemeTuruBilgi = context.OdemeTurleri.SingleOrDefault(c => c.Id == odemeTuruId);
            txtOdemeTuru.Text = _odemeTuruBilgi.OdemeTuruAdi;
            txtKasaKodu.Text = _kasabilgi.KasaKodu;
            txtKasaAdi.Text = _kasabilgi.KasaAdi;
            if (odenmesiGereken != null)
            {
                gelenTutar = odenmesiGereken.Value;
            }
            else
            {
                txtTutar.Properties.Buttons[1].Visible = false;
            }


        }

        private void FrmOdemeEkrani_Load(object sender, EventArgs e)
        {

        }
        private void btnKasaSec_Click(object sender, EventArgs e)
        {
            FrmKasaSec form = new FrmKasaSec();
            form.ShowDialog();
            if (form.secildi)
            {
                _kasabilgi = context.Kasalar.SingleOrDefault(c => c.Id == form.entity.Id);
                txtKasaKodu.Text = form.entity.KasaKodu;
                txtKasaAdi.Text = form.entity.KasaAdi;
            }

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string message = null; int error = 0;
            if (txtKasaAdi.Text == "")
            {
                message += "Kasa bilgileri boş bırakılamaz." + System.Environment.NewLine;
                error++;
            }
            if (txtTutar.Value <= 0)
            {
                message += "Tutar 0 değerine eşit veya 0 değerinden küçük olamaz." + System.Environment.NewLine;
                error++;
            }

            if (txtTutar.Value > gelenTutar && gelenTutar != null)
            {
                message += "Eklenen tutar ödenmesi gereken tutardan daha büyük olamaz." + System.Environment.NewLine;
                error++;
            };
            if (error != 0)
            {
                MessageBox.Show(message);
                return;
            }



            entity = new KasaHareket();
            entity.OdemeTuruId = _odemeTuruBilgi.Id;
            entity.KasaId = _kasabilgi.Id;
            entity.Tutar = txtTutar.Value;
            entity.Tarih = DateTime.Now;
            entity.Aciklama = txtAciklama.Text;
            this.Close();
        }
        private void txtTutar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                txtTutar.Value = gelenTutar.Value;
            }
        }
    }
}