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
using NetSatis.Entities.Tables;
using NetSatis.Entities.Data_Access;
using NetSatis.BackOffice.Cari;

namespace NetSatis.BackOffice.Banka
{
    public partial class FrmBankaOdemeEkranı : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        public BankaHareket entity;
        private Nullable<decimal> gelenTutar;
        private Entities.Tables.Banka _BankaBilgi;
        private Entities.Tables.Fis CariFisi;
        string CariKodu;
        private BankaOdemeTuru _odemeTuruBilgi;
        BankaHareketDAL bankaDAL = new BankaHareketDAL();
        FisDAL fisDAL = new FisDAL();
        public FrmBankaOdemeEkranı()
        {
            InitializeComponent();



      

        }
  
       
        private void FrmBankaOdemeEkranı_Load(object sender, EventArgs e)
        {

        }

        private void btnKasaSec_Click(object sender, EventArgs e)
        {
             FrmBankaSec form = new FrmBankaSec();
            form.ShowDialog();
            if (form.secildi)
            {
                _BankaBilgi = context.Banka.SingleOrDefault(c => c.Id == form.entity.Id);
                txtKasaKodu.Text = form.entity.BankaKodu;
                txtKasaAdi.Text = form.entity.BankaAdi;
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string message = null; int error = 0;
            if (txtKasaAdi.Text == "")
            {
                message += "Banka bilgileri boş bırakılamaz." + System.Environment.NewLine;
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
            if (error==0)
            {
                entity = new BankaHareket();
                entity.OdemeTuru = txtOdemeTuru.Text;
                entity.BankaId = _BankaBilgi.Id;
                entity.Tutar = txtTutar.Value;
                entity.Tarih = DateTime.Now;
                entity.Aciklama = txtAciklama.Text;

                entity.Hareket = (cbHareket.Text == "GİDEN") ? "Kasa Çıkış" : "Kasa Giriş";
                entity.FisKodu = txtFisKodu.Text;


                if (txtCariID.Text != "")
                {

                    var a = context.Cariler.Where(c => c.CariKodu == CariKodu).FirstOrDefault();

                    CariFisi = new Fis();
                    entity.CariKodu = txtCariID.Text;
                    CariFisi.FisKodu = txtFisKodu.Text;
                    CariFisi.FisTuru = "Fiş Banka";
                    CariFisi.CariKodu = txtCariID.Text;
                    CariFisi.FaturaUnvani = a.FaturaUnvani;
                    CariFisi.CepTelefonu = a.CepTelefonu;
                    CariFisi.Il = a.Il;
                    CariFisi.Ilce = a.Ilce;
                    CariFisi.Adres = a.Adres;
                    CariFisi.VergiDairesi = a.VergiDairesi;
                    CariFisi.VergiNo = a.VergiNo;
                    CariFisi.Tarih = DateTime.Now;
                    CariFisi.SubeId = 1;
                    if (cbHareket.Text == "GİDEN")
                    {
                        CariFisi.Borc = txtTutar.Value;

                    }
                    else
                    {
                        CariFisi.Alacak = txtTutar.Value;
                    }
                    CariFisi.ToplamTutar = txtTutar.Value;
                    CariFisi.Aciklama = cbHareket.Text + " " + cbHareket.Text + " " + txtAciklama.Text;
                    if (fisDAL.AddOrUpdate(context, CariFisi))
                    {
                        fisDAL.Save(context);
                    }
                }

                if (bankaDAL.AddOrUpdate(context, entity))
                {
                    bankaDAL.Save(context);


                }
               
            }










            this.Close();
        }

        
        private void txtCariID_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmCariSec form = new FrmCariSec();
            form.ShowDialog();
            if (form.secildi)
            {
                txtCariID.Text= form.CariKodu.ToString();
                CariKodu = form.CariKodu;


            }


            var a = context.Cariler.Where(c => c.CariKodu == CariKodu).FirstOrDefault();

    



        }

        private void cbHareket_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}