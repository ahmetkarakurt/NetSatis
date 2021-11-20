using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using NetSatis.Admin;
using NetSatis.BackOffice.Ayarlar;
using NetSatis.BackOffice.Cari;
using NetSatis.BackOffice.Fiş;
using NetSatis.BackOffice.Fiyat_Değiştir;
using NetSatis.BackOffice.Hızlı_Satış;
using NetSatis.BackOffice.Stok;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tables;
using NetSatis.Entities.Tables.OtherTables;
using NetSatis.Entities.Tools;
using NetSatis.Reports.Fatura_ve_Fiş;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NetSatis.FrontOffice
{
    public partial class FrmFrontOffice : DevExpress.XtraEditors.XtraForm
    {
        private NetSatisContext context;

        FisDAL fisDal = new FisDAL();
        StokHareketDAL stokHareketDal = new StokHareketDAL();
        KasaHareketDAL kasaHareketDal = new KasaHareketDAL();
        StHarBarkodDAL StHar = new StHarBarkodDAL();// barkod adet belirtir
        CariBakiye _entityBakiye = new CariBakiye(); 
        CariDAL cariDal = new CariDAL();
        Fis _fisentity = new Fis();
        ExchangeTool doviz = new ExchangeTool();
        private CodeTool fisKoduOlustur;
        private int odemeTuruId;
        private decimal eskiFiyat = 0;
        private bool tekParca = false;
        private int bekleyenSatisId = 0;
        private int cagirilanSatisId = -1;

        private int Sube = 1;
        private string Kasiyer ="-1";// RoleTool.KullaniciEntity.KullaniciAdi;
        private string KasaID = "";
        private bool TeraziSistemi = false;
        private string KasaSatisOnEkKodu = "BS";
        private List<BekleyenSatis> _bekleyenSatis = new List<BekleyenSatis>();
        private string _cariKodu;
        public FrmFrontOffice()
        {
            InitializeComponent();
            FrmKullaniciGiris girisForm = new FrmKullaniciGiris();
            girisForm.ShowDialog();
           context = new NetSatisContext();
            fisKoduOlustur =new CodeTool(this,CodeTool.Table.Fis);
      
            context.Stoklar.Load();
            
            context.Depolar.Load();
            context.Cariler.Load();
            gridcontStokHareket.DataSource = context.StokHareketleri.Local.ToBindingList();
            gridcontKasaHareket.DataSource = context.KasaHareketleri.Local.ToBindingList();
            gridLookUpEdit1.Properties.DataSource = doviz.DovizKuruCek();
            ButonlariYukle();
            txtIslem.Text = "SATIŞ";
            this.WindowState = FormWindowState.Maximized;
            fisKoduOlustur.BarButonOlustur();
            clcgizli.Text = "";
  
        
          

        }
        private void HizliSatis_Click(object sender, EventArgs e)
        {
            var buton = sender as SimpleButton;

            Entities.Tables.Stok entity = context.Stoklar.Where(c => c.StokKodu == buton.Name.ToString()).FirstOrDefault();


            if (entity != null)
            {
                if (StokKontrol(entity))
                {
                    var veri = context.StokHareketleri.Local.Where(c => c.StokKodu == entity.StokKodu).FirstOrDefault();
                    if (veri != null)
                    {
                        veri.Miktar += txtMiktar.Value;
                       KampanyaVarmi(Convert.ToDecimal(veri.Miktar), veri);

                    }
                    else
                    {
                        stokHareketDal.AddOrUpdate(context, StokSec(entity));
                    }
                    Toplamlar();
                }
            }

            else
            {
                MessageBox.Show("Aradığınız barkod numarası ürünler arasında bulunamadı.");
            }
            altbilgisi();



        }

        void altbilgisi()
        {
            txtMiktar.Value = 1;
            clcgizli.Text = "";      
            clcgizli.Visible = false;
        }
        private void HizliSatisMenusuEkle()
        {
            xtraTabControl1.TabPages.Clear();
            foreach (var hizliSatisGrup in context.HizliSatisGruplari.ToList())
            {
                XtraTabPage page = new XtraTabPage { Name = hizliSatisGrup.Id.ToString(), Text = hizliSatisGrup.GrupAdi, AutoScroll = true };
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Dock = DockStyle.Fill;
                page.Controls.Add(panel);
                foreach (var hizliSatis in context.HizliSatislar.Where(c => c.GrupId == hizliSatisGrup.Id).ToList())
                {
                    SimpleButton button = new SimpleButton
                    {
                        Name = hizliSatis.Barkod,

                        Text = hizliSatis.UrunAdi,
                        Height = 80,
                        Width = 120,
                        
                       




                    };
                    button.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    button.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
                    button.Appearance.Options.UseTextOptions = true;
                    button.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    button.Click += HizliSatis_Click;
                    panel.Controls.Add(button);
               
                }
                panel.AutoScroll = true;
                page.AutoScroll = true;
                xtraTabControl1.TabPages.Add(page);
         
            }
        }
        private void ButonlariYukle()
        {
            foreach (var hizliSatisGrup in context.HizliSatisGruplari.ToList())
            {
                XtraTabPage page = new XtraTabPage { 
                    Name = hizliSatisGrup.Id.ToString(),
                    Text = hizliSatisGrup.GrupAdi ,
                    AutoScroll=true,
                  //  AllowTouchScroll=true,
                  //  FireScrollEventOnMouseWheel = true,
                  //  AlwaysScrollActiveControlIntoView=true
                    

            };
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Dock = DockStyle.Fill;
                page.Controls.Add(panel);
                foreach (var hizliSatis in context.HizliSatislar.Where(c => c.GrupId == hizliSatisGrup.Id).ToList())
                {
                    SimpleButton button = new SimpleButton
                    {
                        Name = hizliSatis.Barkod,

                        Text = hizliSatis.UrunAdi,
                        Height = 80,
                        Width = 120
                    };
                    button.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    button.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
                    button.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    button.Appearance.Options.UseTextOptions = true;
                    button.Click += HizliSatis_Click;
                    panel.Controls.Add(button);
                    
                }
                panel.AutoScroll = true;
                page.AutoScroll = true;
                xtraTabControl1.TabPages.Add(page);
             
            }


            var AcikHesapButon = new SimpleButton
            {
                Name = "AcikHesap",
                Text = "Açık Hesap",
                Height = 50,
                Width = 100
            }; AcikHesapButon.Click += AcikHesap_Click;
            flowOdemeTurleri.Controls.Add(AcikHesapButon);

            foreach (var item in context.OdemeTurleri.ToList())
            {
                var buton = new SimpleButton
                {
                    Name = item.OdemeTuruKodu,
                    Tag = item.Id,
                    Text = item.OdemeTuruAdi,
                    Height = 50,
                    Width = 100
                };
                buton.Click += OdemeEkle_Click;
                flowOdemeTurleri.Controls.Add(buton);
            }

            var PersonelSecimIptal = new CheckButton
            {
                Name = "Yok",
                Text = "Yok",
                GroupIndex = 1,
                Height = 90,
                Width = flowPersonel.Width - 5,
                Checked = true
            };
            PersonelSecimIptal.Click += PersonelYukle_Click;
            flowPersonel.Controls.Add(PersonelSecimIptal);
            foreach (var item in context.Personeller.ToList())
            {
                var buton = new CheckButton
                {
                    Name = item.PersonelKodu,
                    Text = item.PersonelAdi,
                    Tag = item.Id,
                    GroupIndex = 1,
                    Height = 90,
                    Width = flowPersonel.Width - 5,
                    Checked = false
                };
                buton.Click += PersonelYukle_Click;
                flowPersonel.Controls.Add(buton);
            }
        }

        private void AcikHesap_Click(object sender, EventArgs e)
        {
            Toplamlar();
            odemeTuruId = -1;
            radialOdeme.ShowPopup(MousePosition);

        }

        private void OdemeEkle_Click(object sender, EventArgs e)
        {


            var buton = (sender as SimpleButton);
            string kasaKodu = SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_VarsayilanKasa);
            if (chkOdemeBol.Checked)
            {
                if (txtOdenmesiGereken.Value == 0)
                {
                    MessageBox.Show("Ödenmesi gereken tutar zaten ödenmiş.");
                }
                else
                {
                    FrmOdemeEkrani form = new FrmOdemeEkrani(Convert.ToInt32(buton.Tag), txtOdenmesiGereken.Value);
                    form.ShowDialog();
                    if (form.entity != null)
                    {
                        kasaHareketDal.AddOrUpdate(context, form.entity);
                        OdenenTutarGuncelle();
                    }
                }
            }
            else
            {
                odemeTuruId = Convert.ToInt32(buton.Tag);
                tekParca = true;

                // KAPATILDI ///
                radialOdeme.ShowPopup(MousePosition);
                //   FisiKaydet(ReportsPrintTool.Belge.Diger);
                //                FisiKaydet(ReportsPrintTool.Belge.BilgiFisi);

            }

        }

        public void OdemeTuslari(int OdemeID)
        {
         
         
            string kasaKodu = SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_VarsayilanKasa);
            if (chkOdemeBol.Checked)
            {
                if (txtOdenmesiGereken.Value == 0)
                {
                    MessageBox.Show("Ödenmesi gereken tutar zaten ödenmiş.");
                }
                else
                {
                    FrmOdemeEkrani form = new FrmOdemeEkrani(OdemeID, txtOdenmesiGereken.Value);
                    form.ShowDialog();
                    if (form.entity != null)
                    {
                        kasaHareketDal.AddOrUpdate(context, form.entity);
                        OdenenTutarGuncelle();
                    }
                }
            }
            else
            {
                odemeTuruId = Convert.ToInt32(OdemeID);
                tekParca = true;

                // KAPATILDI ///
                radialOdeme.ShowPopup(MousePosition);
                //                  FisiKaydet(ReportsPrintTool.Belge.Diger);
                //                  FisiKaydet(ReportsPrintTool.Belge.BilgiFisi);

            }
        }
       
        // fiş kayıt ediliyor//
        private void FisiKaydet(ReportsPrintTool.Belge belge)
        {
       
                Toplamlar();
                OdenenTutarGuncelle();
            string message = null;
            int hata = 0;
               if (tileView1.RowCount == 0)
               {
                   message += "Satış Ekranında eklenmiş bir ürün bulunamadı." + System.Environment.NewLine;
                   hata++;
               }
               if (gridKasaHareket.RowCount == 0 && chkOdemeBol.Checked && String.IsNullOrEmpty(txtCariKodu.Text))
               {
                   message += "Herhangi bir ödeme bulunamadı." + System.Environment.NewLine;
                   hata++;
               }
               if (txtKod.Text == "")
               {
                   message += "Fiş Kodu alanı boş geçilemez." + System.Environment.NewLine;
                   hata++;
               }
               if (txtOdenmesiGereken.Value != 0 && String.IsNullOrEmpty(txtCariKodu.Text) && tekParca == false)
               {
                   message += "Ödenmesi gereken tutar ödenmemiş görünüyor. Ödenmeyen kısmı açık hesaba aktarabilmeniz için Cari seçmeniz gerekmektedir." + System.Environment.NewLine;
                   hata++;
               }
            
               if (_entityBakiye.RiskLimiti != 0 && !String.IsNullOrEmpty(txtCariKodu.Text) && (_entityBakiye.Bakiye - txtOdenmesiGereken.Value) < 0 && ((_entityBakiye.Bakiye - txtOdenmesiGereken.Value) * -1) > _entityBakiye.RiskLimiti && tekParca == false)
               {
                   message += "Cari risk limiti aşılıyor. Satış yapılamaz." + System.Environment.NewLine;
                   hata++;
               }
               if (hata != 0)
               {
                   MessageBox.Show(message);
                   return;
               }
            
               if (chkOdemeBol.Checked && txtOdenmesiGereken.Value != 0)
               {
                   if (MessageBox.Show($"Ödemenin {txtOdenmesiGereken.Value.ToString("C2")} tutarındaki kısmı açık hesap bakiyesi olarak kaydedilecektir. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.No)
                   {
                       MessageBox.Show("İsteğiniz üzerine işlem iptal edildi.");
                       return;
                   }
               }

           var Kampanya= context.KampanyaAna.Where( c=>c.Durumu == true  && txtToplam.Value>=c.KampanyaFiyat && DateTime.Now >= c.BaslangicTarihi && DateTime.Now <= c.BitisTarihi).ToList();

         
            Kampanya = Kampanya.Where(c => c.KampanyaTuru == "001" || c.KampanyaTuru == "002").ToList();
            
            foreach (var item in Kampanya)
            {
               
                switch (item.KampanyaTuru)
                {
                    case "001":
                        if (MessageBox.Show($"Fişde  !- {item.KampanyaFiyat} TL -! Alışverişe  %{item.IndirimOrani} İskonto Kampanyası Bulunmuştur. Kampanyayı Uygulamak İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            for (int i = 0; i < tileView1.RowCount; i++)
                            {

                                tileView1.FocusedRowHandle = i;
                                tileView1.SetFocusedRowCellValue(colIndirimOrani, item.IndirimOrani);
                            }
                            Toplamlar();
                            MessageBox.Show($"Kampanya Uygulandıktan Sonra  !- {txtToplam.Text} TL -! ", "Uyarı", MessageBoxButtons.OK);
                        }
                        break;
                    case "002":

                        var KampanyaUrunleri = context.KampanyaUrun.Where(c => c.Durumu == true && c.KampanyaKodId==item.KampanyaKod).ToList();


                        for (int i = 0; i < tileView1.RowCount; i++)
                        {
                            tileView1.FocusedRowHandle = i;




                            foreach (var Urun in KampanyaUrunleri)
                            {
                                if (Urun.StokKodu == tileView1.GetRowCellValue(i, colStokKodu).ToString())
                                {
                                    if (MessageBox.Show($"Fişde  !- {item.KampanyaFiyat} TL -! Alışverişe {tileView1.GetRowCellValue(i, colStokAdi).ToString()} Ürününe İskonto Kampanyası Bulunmuştur. Kampanyayı Uygulamak İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        tileView1.SetFocusedRowCellValue(colIndirimOrani, Urun.IndirimOrani);
                                        Toplamlar();
                                        MessageBox.Show($"Kampanya Uygulandıktan Sonra  !- {txtToplam.Text} TL -! ", "Uyarı", MessageBoxButtons.OK);
                                    }
                                }


                            }
                            


                        }
                        //if (KampanyaUrunleri.Count>0)
                        //{
                        //    if (MessageBox.Show($"Fişde  !- {item.KampanyaFiyat} TL -! Alışverişe  Ürün İskonto Kampanyası Bulunmuştur. Kampanyayı Uygulamak İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        //    {
                        //        for (int i = 0; i < tileView1.RowCount; i++)
                        //        {

                        //            tileView1.FocusedRowHandle = i;

                        //            foreach (var Urun in KampanyaUrunleri)
                        //            {
                        //                if (Urun.StokKodu == tileView1.GetRowCellValue(i, colStokKodu).ToString())
                        //                {
                        //                    tileView1.SetFocusedRowCellValue(colIndirimOrani, Urun.IndirimOrani);
                        //                }

                        //            }
                        //        }
                        //        Toplamlar();
                        //        MessageBox.Show($"Kampanya Uygulandıktan Sonra  !- {txtToplam.Text} TL -! ", "Uyarı", MessageBoxButtons.OK);

                        //    } 
                        //}
                        break;

                }


               
              
               
                // MessageBox.Show(item.KampanyaAdi);
            }
          



            _fisentity.FisTuru = txtIslem.Text == "İADE" ? "Satış İade Faturası" : "Perakende Satış Faturası";
            foreach (var stokVeri in context.StokHareketleri.Local.ToList())
            {
               
                stokVeri.Tarih = DateTime.Now;               
                stokVeri.FisKodu = txtKod.Text;
                stokVeri.Hareket = txtIslem.Text == "İADE" ? "Stok Giriş" : "Stok Çıkış";
                
            }
            
            foreach (var kasaVeri in context.KasaHareketleri.Local.ToList())
            {
                kasaVeri.Tarih = DateTime.Now;
                kasaVeri.FisKodu = txtKod.Text;
                kasaVeri.Hareket = txtIslem.Text == "İADE" ? "Kasa Çıkış" : "Kasa Giriş";
                kasaVeri.CariKodu = _cariKodu;
                kasaVeri.KasıyerID = Kasiyer;
                kasaVeri.KasaAdi = KasaID;
                kasaVeri.SubeId = Sube;
            }
            ///*****////
            _fisentity.FisKodu = txtKod.Text;
            _fisentity.BelgeNo = txtBelgeNo.Text;
            _fisentity.Aciklama = txtAciklama.Text;
            _fisentity.FaturaUnvani = txtFaturaUnvani.Text;
            _fisentity.CepTelefonu = txtCepTelefonu.Text;
            _fisentity.Il = txtIl.Text;
            _fisentity.Ilce = txtIlce.Text;
            _fisentity.Semt = txtSemt.Text;
            _fisentity.Adres = txtAdres.Text;
            _fisentity.VergiDairesi = txtVergiDairesi.Text;
            _fisentity.VergiNo = txtVergiNo.Text;
            _fisentity.ToplamTutar = txtToplam.Value;
            _fisentity.IskontoOrani = txtIskontoOran.Value;
            _fisentity.IskontoTutar = txtIskontoTutar.Value; 
            _fisentity.Tarih = DateTime.Now;
            _fisentity.SubeId = Sube;
            _fisentity.KasıyerID = Kasiyer;
            _fisentity.KasaAdi = KasaID;
//            _fisentity.FisBaglantiKodu = fisKoduOlustur.YeniFisOdemeKoduOlustur();

            if (txtIslem.Text == "SATIŞ")
            {
                _fisentity.Borc = txtToplam.Value;

            }
            else
            {
                _fisentity.Alacak = txtToplam.Value;
                _fisentity.Borc = null;
            }

            // fisDal.AddOrUpdate(context, odemeFisi);
            fisDal.AddOrUpdate(context, _fisentity);

            //////********//////
            int kasaId = Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_VarsayilanKasa));

            if (!chkOdemeBol.Checked && odemeTuruId != -1)
            {
                kasaHareketDal.AddOrUpdate(context, new KasaHareket
                {
                    CariKodu = _cariKodu,
                    FisKodu = txtKod.Text,
                    Hareket = txtIslem.Text == "İADE" ? "Kasa Çıkış" : "Kasa Giriş",
                    KasaId = kasaId,
                    OdemeTuruId = odemeTuruId,
                    Tarih = DateTime.Now,
                    Tutar = txtToplam.Value,
                    KasıyerID = Kasiyer,
                    SubeId = Sube,
                    KasaAdi=KasaID

                });
                OdenenTutarGuncelle();
            }
            context.SaveChanges();
            chkOdemeBol.Checked = false;
           radialOdeme.HidePopup();

            switch (belge)
            {
                case ReportsPrintTool.Belge.Fatura:
                    ReportsPrintTool yazdir = new ReportsPrintTool();
                    rptFatura fatura = new rptFatura(txtKod.Text);
                    yazdir.RaporYazdir(fatura, belge); 
                    break;
                case ReportsPrintTool.Belge.BilgiFisi:
                    ReportsPrintTool yazdirBilgiFisi = new ReportsPrintTool();
                   
                    rptBilgiFisi bilgiFisi = new rptBilgiFisi(txtKod.Text);
                    yazdirBilgiFisi.RaporYazdir(bilgiFisi, belge);
                    break;
            }

            if (cagirilanSatisId != -1)
            {
                var secilen = _bekleyenSatis.SingleOrDefault(c => c.Id == cagirilanSatisId);
                _bekleyenSatis.Remove(secilen);
                flowBekleyenSatislar.Controls.Find(Convert.ToString(cagirilanSatisId), false).SingleOrDefault().Dispose();
                cagirilanSatisId = -1;
            }
            FisKodDegis();
            txtBarkod.Focus();
            FisTemizle();
          
           tekParca = false;
        

        }
        private void OdenenTutarGuncelle()
        {
            gridKasaHareket.UpdateSummary();

            txtOdenenTutar.Value = Convert.ToDecimal(colTutar.SummaryItem.SummaryValue);
            txtOdenmesiGereken.Value = txtToplam.Value - txtOdenenTutar.Value;


        }
        private void FisTemizle()
        {

            txtIskontoOran.Value = 0;
            CariTemizle();
            txtBelgeNo.Text = null;
            txtAciklama.Text = null;
            var cikarilacakKayit = context.ChangeTracker.Entries()
                .Where(c => c.Entity is KasaHareket || c.Entity is StokHareket).ToList();
            foreach (var kayit in cikarilacakKayit)
            {
                context.Entry(kayit.Entity).State = EntityState.Detached;
            }
            _fisentity = new Fis();
                  Toplamlar();
                  OdenenTutarGuncelle();
            clcgizli.Text = "";

        }
        private void CariTemizle()
        {
            txtCariKodu.Text = null;
            txtCariAdi.Text = null;
            _fisentity.CariKodu = null;
            txtFaturaUnvani.Text = null;
            txtVergiDairesi.Text = null;
            txtVergiNo.Text = null;
            txtCepTelefonu.Text = null;
            txtIl.Text = null;
            txtIlce.Text = null;
            txtSemt.Text = null;
            txtAdres.Text = null;
            lblRiskLimiti.Text = "Görüntülenemiyor";
            lblAlacak.Text = "Görüntülenemiyor";
            lblBorc.Text = "Görüntülenemiyor";
            lblBakiye.Text = "Görüntülenemiyor";
        }
        private void DovizLiTutar()
        {
            try
            {
                txtDovizTutar.Value = txtToplam.Value / Convert.ToDecimal(gridLookUpEdit1View.GetFocusedRowCellValue(colBanknoteSelling));
            }
            catch (Exception)
            {

            }
        }
        private void PersonelYukle_Click(object sender, EventArgs e)
        {

            var buton = sender as CheckButton;
            if (buton.Name == "Yok")
            {
                _fisentity.PlasiyerId = null;
            }
            else
            {
                _fisentity.PlasiyerId = Convert.ToInt32(buton.Tag);
            }

        }
        private void BekleyenSatis_Click(object sender, EventArgs e)
        {
            var buton = sender as SimpleButton;
            BekleyenSatisYukle(Convert.ToInt32(buton.Name));
        }
        private void btnBeklet_Click(object sender, EventArgs e)
        {
            SatisBeklet();
        }

        private void SatisBeklet()
        {
            if (tileView1.RowCount == 0)
            {
                MessageBox.Show("Satış bekletebilmeniz için ürün eklemeniz gerekmektedir.");
                return;
            }
            int BekleyenId;
            BekleyenSatis satis;
            if (cagirilanSatisId != -1)
            {
                BekleyenId = cagirilanSatisId;
                satis = _bekleyenSatis.SingleOrDefault(c => c.Id == BekleyenId);
                var buton = (SimpleButton)flowBekleyenSatislar.Controls.Find(Convert.ToString(BekleyenId), false).SingleOrDefault();
                buton.Text = txtCariKodu.Text + " - " + txtCariAdi.Text + "\n" + context.StokHareketleri.Local.Count +
                             " adet ürün eklendi." + "\n" + txtToplam.Value.ToString("C2");
            }
            else
            {
                BekleyenId = bekleyenSatisId;
                satis = new BekleyenSatis();
                satis.BekleyenFis = new Fis();
                satis.Id = BekleyenId;
                SimpleButton BekleyenButon = new SimpleButton
                {
                    Name = bekleyenSatisId.ToString(),
                    Text = txtCariKodu.Text + " - " + txtCariAdi.Text + "\n" + "\n" + context.StokHareketleri.Local.Count + " adet ürün eklendi." + "\n" + txtToplam.Value.ToString("C2"),
                    Height = 100,
                    Width = flowBekleyenSatislar.Width - 5
                };
                BekleyenButon.Click += BekleyenSatis_Click;
                flowBekleyenSatislar.Controls.Add(BekleyenButon);
                bekleyenSatisId++;
            }
            satis.BekleyenFis.CariKodu = _fisentity.CariKodu;
            satis.BekleyenFis.Cari = _fisentity.Cari;
            satis.BekleyenFis.Aciklama = txtAciklama.Text;
            satis.BekleyenFis.Adres = txtAdres.Text;
            satis.BekleyenFis.BelgeNo = txtBelgeNo.Text;
            satis.BekleyenFis.CepTelefonu = txtCepTelefonu.Text;
            satis.BekleyenFis.FaturaUnvani = txtFaturaUnvani.Text;
            satis.BekleyenFis.FisTuru = _fisentity.FisTuru; satis.BekleyenFis.Il = txtIl.Text;
            satis.BekleyenFis.Ilce = txtIlce.Text;
            satis.BekleyenFis.Semt = txtSemt.Text;
            satis.BekleyenFis.PlasiyerId = _fisentity.PlasiyerId;
            satis.BekleyenFis.VergiDairesi = txtVergiDairesi.Text;
            satis.BekleyenFis.VergiNo = txtVergiNo.Text;
            satis.BekleyenFis.IskontoOrani = txtIskontoOran.Value;

            satis.StokHareketi = context.StokHareketleri.Local.ToList();
            satis.KasaHareketi = context.KasaHareketleri.Local.ToList();

            CheckButton personelButonYok = (CheckButton)flowPersonel.Controls.Find("Yok", false).SingleOrDefault();
            personelButonYok.Checked = true;

            if (cagirilanSatisId == -1)
            {
                _bekleyenSatis.Add(satis);
            }

            cagirilanSatisId = -1;

            FisTemizle();
            //txtFisKodu.Text =
            //    CodeTool.KodOlustur("Fİ", SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_FisKodu));
        }
        private void BekleyenSatisYukle(int id)
        {
            if (cagirilanSatisId == -1 && tileView1.RowCount != 0)
            {
                if (MessageBox.Show("Bekleyen satışı çağırmadan önce mevcutta olan satışı beklemeye almak ister misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SatisBeklet();
                }
            }
            FisTemizle(); 
            var SatisBilgisi = _bekleyenSatis.SingleOrDefault(c => c.Id == id);

            _fisentity.CariKodu = SatisBilgisi.BekleyenFis.CariKodu;
            var cariBilgi = context.Cariler.SingleOrDefault(c => c.CariKodu == _fisentity.CariKodu);

            if (cariBilgi != null)
            {
                _entityBakiye = cariDal.CariBakiyesi(context, SatisBilgisi.BekleyenFis.CariKodu);
                lblRiskLimiti.Text = _entityBakiye.RiskLimiti.ToString("C2");
                lblAlacak.Text = _entityBakiye.Alacak.ToString("C2");
                lblBorc.Text = _entityBakiye.Borc.ToString("C2");
                lblBakiye.Text = _entityBakiye.Bakiye.ToString("C2"); txtCariKodu.Text = cariBilgi.CariKodu;
                txtCariAdi.Text = cariBilgi.CariAdi;
            }

            _fisentity.PlasiyerId = SatisBilgisi.BekleyenFis.PlasiyerId;
            var personelBilgi = context.Personeller.SingleOrDefault(c => c.Id == _fisentity.PlasiyerId);

            if (personelBilgi != null)
            {
                CheckButton personelButon = (CheckButton)flowPersonel.Controls.Find(personelBilgi.PersonelKodu, false).SingleOrDefault();
                personelButon.Checked = true;
            }
            else
            {
                CheckButton personelButonYok = (CheckButton)flowPersonel.Controls.Find("Yok", false).SingleOrDefault();
                personelButonYok.Checked = true;
            }


            //txtFisKodu.Text = CodeTool.KodOlustur("Fİ", SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_FisKodu));
            txtBelgeNo.Text = SatisBilgisi.BekleyenFis.BelgeNo;
            txtAciklama.Text = SatisBilgisi.BekleyenFis.Aciklama;
            txtFaturaUnvani.Text = SatisBilgisi.BekleyenFis.FaturaUnvani;
            txtCepTelefonu.Text = SatisBilgisi.BekleyenFis.CepTelefonu;
            txtIl.Text = SatisBilgisi.BekleyenFis.Il; txtIlce.Text = SatisBilgisi.BekleyenFis.Ilce;
            txtSemt.Text = SatisBilgisi.BekleyenFis.Semt;
            txtAdres.Text = SatisBilgisi.BekleyenFis.Adres;
            txtVergiDairesi.Text = SatisBilgisi.BekleyenFis.VergiDairesi;
            txtVergiNo.Text = SatisBilgisi.BekleyenFis.VergiNo;
            txtToplam.Value = Convert.ToDecimal(SatisBilgisi.BekleyenFis.ToplamTutar);
            txtIskontoOran.Value = Convert.ToDecimal(SatisBilgisi.BekleyenFis.IskontoOrani);
            txtIskontoTutar.Value = Convert.ToDecimal(SatisBilgisi.BekleyenFis.IskontoTutar);

            foreach (var item in SatisBilgisi.StokHareketi)
            {
                context.StokHareketleri.Local.Add(item);
            }
            foreach (var item in SatisBilgisi.KasaHareketi)
            {
                context.KasaHareketleri.Local.Add(item);
            }

            cagirilanSatisId = id;
            Toplamlar();
            OdenenTutarGuncelle();
        }
         
        private void FisKodDegis()
        {
            txtKod.Text = fisKoduOlustur.KodOlustur(KasaSatisOnEkKodu, Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_FisKodu))+1);
            txtMiktar.Text = "1";
            string FisKoduBilgisi = SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_FisKodu);
            SettingsTool.AyarDegistir(SettingsTool.Ayarlar.SatisAyarlari_FisKodu, Convert.ToString(Convert.ToInt32(FisKoduBilgisi) + 1));
            SettingsTool.Save();
            txtOdenen.Value = 0;
            txtDovizTutar.Value = 0;


        }
        int SimdiW = 1360;
        int SimdiH = 760;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            Rectangle ClientCoz = new Rectangle();
            ClientCoz = Screen.GetBounds(ClientCoz);
            float OranW = ((float)ClientCoz.Width / (float)SimdiW);
            float OranH = ((float)ClientCoz.Height / (float)SimdiH);
            this.Scale(new SizeF(OranW, OranH));
            FisKodDegis();
            // CodeTool.KodOlustur("BSD", SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_FisKodu));
            tileView1.ClearSelection();
            txtBarkod.Focus();
           context.Configuration.AutoDetectChangesEnabled = false;
              try
              {
                Kasiyer = RoleTool.KullaniciEntity.KullaniciAdi;
               
               
               }
               catch (Exception)
               {
            
                   
               }
            try
            {
            // Sube = int.Parse(RoleTool.SubeEntity.Turu);
            }
            catch (Exception)
            {

               
            }
             KasaID= SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_KasaAdi);
            // 2700329000803
            TeraziSistemi = Convert.ToBoolean(SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_TeraziSistemi));

          
            splitContainerControl1.SplitterPosition = Properties.Settings.Default.SatisPaneliGenislik;
            navigationPane1.Width = Properties.Settings.Default.SolPanelGenislik;
            // navigationPane1.Width = 35;


            /*başlangıçda fiş kodu seç*/
            if (SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_KasaOnEkKodu) != null)
            {
                KasaSatisOnEkKodu = SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_KasaOnEkKodu);
            }
            txtKod.Text = fisKoduOlustur.KodOlustur(KasaSatisOnEkKodu, Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_FisKodu)));


        }
        private void TxtOdenen_Properties_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            FrmStokSec form = new FrmStokSec();
                 form.ShowDialog();
             if (form.secildi)
             {
                Entities.Tables.Stok entity;
                 //      Stok Stokvarmi;
                 entity = context.Stoklar.Where(c => c.StokKodu == form.stokkodu).FirstOrDefault();
                 // var secmis = context.StokBarkod.Where(c => c.Stok.StokKodu == form.stokkodu);
            
                 if (StokKontrol(entity))
                 {
                     stokHareketDal.AddOrUpdate(context, StokSec(entity));
                     Toplamlar();
                 }
             }
        }

        private bool StokKontrol(Entities.Tables.Stok entity)
        {
          //  var StokGiris = context.StokHareketleri.Where(c => c.Hareket == "Stok Giriş" && c.StokId == entity.StokId).Sum(c => c.Miktar);
          // var StokCikis= context.StokHareketleri.Where(c => c.Hareket == "Stok Çıkış" && c.StokId == entity.StokId).Sum(c => c.Miktar);
          //  var MevcutStok = StokGiris - StokCikis;
          //  
          //  if (txtIslem.Text == "SATIŞ" && entity.Stok.MinStokMiktari > MevcutStok - (txtMiktar.Value + context.StokHareketleri.Local.Where(c => c.StokId == entity.StokId).Sum(c => c.Miktar)))
          //  {
          //      MessageBox.Show(
          //          "Satışını yapmak istediğiniz stok minimum düzeydedir. Satış yapabilmek için stok yükseltmelisiniz.");
          //      return false;
          //  }
          //  else
          //  {
                return true;
          //  }
        }

        private StokHareket StokSec(Entities.Tables.Stok entity)
        {
            StokHareket stokHareket = new StokHareket();
            IndirimDaL indirimDal = new IndirimDaL();
            stokHareket.StokKodu = entity.StokKodu;

            stokHareket.IndirimOrani = indirimDal.StokIndirimi(context, entity.StokKodu);
            stokHareket.DepoId = Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_VarsayilanDepo));
            stokHareket.BirimFiyati = _fisentity.FisTuru == "Alış Faturası" ? entity.AlisFiyati1 : entity.SatisFiyati1;

            stokHareket.Miktar = txtMiktar.Value;
            stokHareket.Tarih = DateTime.Now;
            stokHareket.Kdv = entity.SatisKdv;
            stokHareket.SubeId = Sube;//sube ıd
            stokHareket.KasıyerID = Kasiyer;
            stokHareket.KasaAdi = KasaID;

            //////////
            ///

            var Kampanya = context.KampanyaAna.Where(c => c.Durumu == true).ToList();

            Kampanya = Kampanya.Where(c => c.KampanyaTuru == "003" || c.KampanyaTuru == "005" || c.KampanyaTuru == "006").ToList();

            foreach (var item in Kampanya)
            {
                var KampanyaUrunleri = context.KampanyaUrun.Where(c => c.Durumu == true && c.KampanyaKodId == item.KampanyaKod).ToList();

                KampanyaUrunleri = KampanyaUrunleri.Where(c => c.StokKodu == entity.StokKodu).ToList();

                foreach (var Urun in KampanyaUrunleri)
                {
                    if (txtMiktar.Value < Urun.KampanyaAdeti)
                    {

                        stokHareket.IndirimOrani = 0;
                    }
                    else
                    {

                        stokHareket.IndirimOrani = Urun.IndirimOrani;
                    }

                    break;
                }
                // MessageBox.Show(item.KampanyaAdi);
            }

            //////////

            //
            return stokHareket;
            
        }

        private void btnCariSec_Click(object sender, EventArgs e)
        {
             FrmCariSec form = new FrmCariSec();
             form.ShowDialog();
             if (form.secildi)
             {
                 Entities.Tables.Cari entity = form.secilen.FirstOrDefault();
                 _entityBakiye = this.cariDal.CariBakiyesi(context, entity.CariKodu);
                 _cariKodu = entity.CariKodu;
             
                 _fisentity.CariKodu = entity.CariKodu;
                 txtCariKodu.Text = entity.CariKodu;
                 txtCariAdi.Text = entity.CariAdi;
                 txtFaturaUnvani.Text = entity.FaturaUnvani;
                 txtVergiDairesi.Text = entity.VergiDairesi;
                 txtVergiNo.Text = entity.VergiNo;
                 txtCepTelefonu.Text = entity.CepTelefonu;
                 txtIl.Text = entity.Il;
                 txtIlce.Text = entity.Ilce;
                 txtSemt.Text = entity.Semt;
                 txtAdres.Text = entity.Adres;
                 lblRiskLimiti.Text = _entityBakiye.RiskLimiti.ToString("C2");
                 lblAlacak.Text = _entityBakiye.Alacak.ToString("C2");
                 lblBorc.Text = _entityBakiye.Borc.ToString("C2");
                 lblBakiye.Text = _entityBakiye.Bakiye.ToString("C2");
             }
        }

        private void btnCariTemizle_Click(object sender, EventArgs e)
        {
            CariTemizle();
        }



        private void repositorySil_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı",
                       MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tileView1.DeleteSelectedRows();
                Toplamlar();
            }
        }
        private void tileviewAyar()
        {
           
            tileView1.SelectRow(-1);
            tileView1.FocusedRowHandle = -1;

        }
        private void Toplamlar(bool deger = true, int SatisNo=-1)
        {
         
            decimal ToplamTutar = 0, KdvToplam = 0, İndirimTutar = 0; 
            for (int xIndex = 0; xIndex < tileView1.DataRowCount; xIndex++)
            {
                ToplamTutar += Convert.ToDecimal(tileView1.GetRowCellValue(xIndex, "colToplamTutar"));
                KdvToplam += Convert.ToDecimal(tileView1.GetRowCellValue(xIndex, "colKdvToplam"));
                İndirimTutar += Convert.ToDecimal(tileView1.GetRowCellValue(xIndex, "colIndirimTutar"));
            }
            txtToplam.Value = ToplamTutar;
            txtIskontoTutar.Value = ToplamTutar / 100 * txtIskontoOran.Value;
            txtToplam.Value = ToplamTutar - txtIskontoTutar.Value;

            txtKdvToplam.Value = KdvToplam;

            txtIndirimToplam.Value = İndirimTutar;

            txtAraToplam.Value = txtToplam.Value - txtKdvToplam.Value;
            txtParaUstu.Value = txtOdenen.Value - txtToplam.Value;
            txtOdenmesiGereken.Value = txtToplam.Value - txtOdenenTutar.Value;





            if (deger)
            {

                tileView1.MoveNext();
                // tileView1.SelectRow(-1);
                // 
                tileView1.MoveNext();
                ////  tileView1.FocusedRowHandle = -1;
                tileView1.MoveLast();

                tileView1.MoveLastVisible();
                tileView1.FocusedRowHandle = -1;
                tileView1.FocusedRowHandle = SatisNo;
            }


            altbilgisi();
            DovizLiTutar();
            txtBarkod.Focus();

        }

        private void repositoryDepoSec_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
          // if (e.Button.Index == 0)
          // {
          //     FrmDepoSec form = new FrmDepoSec(Convert.ToInt32(tileView1.GetFocusedRowCellValue(colStokId)));
          //     form.ShowDialog();
          //     if (form.secildi)
          //     {
          //         tileView1.SetFocusedRowCellValue(colDepoId, form.entity.Id);
          //         context.ChangeTracker.DetectChanges();
          //     }
          // }
        }

        private void repositorySeriNo_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
          // string veri = Convert.ToString(tileView1.GetFocusedRowCellValue(colSeriNo));
          // FrmSeriNoGir form = new FrmSeriNoGir(veri, false);
          // form.ShowDialog();
          // tileView1.SetFocusedRowCellValue(colSeriNo, form.veriSeriNo);
        }

        private void repositoryFiyatSec_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string fiyatSecilen = tileView1.GetFocusedRowCellValue(colStokKodu).ToString();
            Entities.Tables.Stok fiyatEntity = context.Stoklar.Where(c => c.StokKodu == fiyatSecilen).SingleOrDefault();
            barFiyat1.Tag = _fisentity.FisTuru == "Alış Faturası"
                ? fiyatEntity.AlisFiyati1 ?? 0
                : fiyatEntity.SatisFiyati1 ?? 0;
            barFiyat2.Tag = _fisentity.FisTuru == "Alış Faturası"
                ? fiyatEntity.AlisFiyati2 ?? 0
                : fiyatEntity.SatisFiyati2 ?? 0;
            barFiyat3.Tag = _fisentity.FisTuru == "Alış Faturası"
                ? fiyatEntity.AlisFiyati3 ?? 0
                : fiyatEntity.SatisFiyati3 ?? 0;
            barFiyat1.Caption = string.Format("{0:C2}", barFiyat1.Tag);
            barFiyat2.Caption = string.Format("{0:C2}", barFiyat2.Tag);
            barFiyat3.Caption = string.Format("{0:C2}", barFiyat3.Tag);


            radialFiyat.ShowPopup(MousePosition);
           
        }

        private void FiyatSec(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tileView1.SetFocusedRowCellValue(colBirimFiyati, Convert.ToDecimal(e.Item.Tag));
            Toplamlar(false);
        }

        private void Satisiptal(object sender, EventArgs e)
        {
            if (tileView1.RowCount != 0)
            {
                if (MessageBox.Show("Mevcut satışı iptal etmek istediğinize emin misiniz?", "Uyarı",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _fisentity.FisKodu = null;
                    _fisentity.BelgeNo = null;
                    _fisentity.Aciklama = null;

                    /// sonradan eklendi///
                    if (cagirilanSatisId != -1)
                    {
                        var secilen = _bekleyenSatis.SingleOrDefault(c => c.Id == cagirilanSatisId);
                        _bekleyenSatis.Remove(secilen);
                        flowBekleyenSatislar.Controls.Find(Convert.ToString(cagirilanSatisId), false).SingleOrDefault().Dispose();
                        cagirilanSatisId = -1;
                    }

                    btnCariTemizle_Click(sender, e);
                    context.StokHareketleri.Local.Clear();
                    txtOdenen.Value = 0;
                    txtParaUstu.Value = 0;
                    Toplamlar();
                }
            }
            else

            {
                MessageBox.Show("Mevcutta bir işlem bulunamadı.");
            }
        }
        private void BtnIptal_Click(object sender, EventArgs e)
        {
            Satisiptal(sender,e);

        }

        private void BtnSatirSil_Click(object sender, EventArgs e)
        {
            if (tileView1.RowCount != 0)
            {
                if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tileView1.DeleteSelectedRows();
                    Toplamlar();
                }
            }
        }

        private void groupControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtFisKodu_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ChkIade_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkIade.Checked)
            {
                txtIslem.Text = "İADE";
                txtBarkod.BackColor = Color.Red;
                clcDipTop.BackColor = Color.Red;

            }
            else
            {
                txtIslem.Text = "SATIŞ";
                txtBarkod.BackColor = Color.Green;
                clcDipTop.BackColor = Color.Green;
            }
        }
        private void ParaEkle(object sender, EventArgs e)
        {
            var buton = (sender as SimpleButton);
            txtOdenen.Value += ConverterTool.StringToDecimal(buton.Tag.ToString(), ".");
            Toplamlar();
        }

        private void txtOdenen_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtOdenen.Value = 0;
        }


        private void Tusbas(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {              
                case Keys.F1:
                    OdemeTuslari(1);
                    break;
                case Keys.F2:
                    OdemeTuslari(2);
                    break;
                case Keys.F5:
                    FisiKaydet(ReportsPrintTool.Belge.Diger);
                    break;
                case Keys.F6:
                    FisiKaydet(ReportsPrintTool.Belge.BilgiFisi);
                    break;
                case Keys.F4:
                    Satisiptal(sender, e);
                    break;
                default:
                    break;
            }         
            
        }
        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
       
       {
            if (e.KeyCode == Keys.Enter && txtBarkod.Text!="")
            {

                #region enterbas
                if (TeraziSistemi)
                {
                    if (txtBarkod.Text.Substring(0, 2) == "27" || txtBarkod.Text.Substring(0, 2) == "29")
                    {
                        txtMiktar.Text = txtBarkod.Text.Substring(7, txtBarkod.Text.Length - 8);
                        txtBarkod.Text = txtBarkod.Text.Substring(0, txtBarkod.Text.Length - 6);
                        txtMiktar.Text = (Convert.ToDouble(txtMiktar.Text) / 1000).ToString();
                    }
                    if (txtBarkod.Text.Substring(0, 2) == "28")
                        {

                        txtMiktar.Text = txtBarkod.Text.Substring(7, txtBarkod.Text.Length - 8);
                        txtBarkod.Text = txtBarkod.Text.Substring(0, txtBarkod.Text.Length - 6);
                        txtMiktar.Text = (Convert.ToDouble(txtMiktar.Text)).ToString();

                    }
                }


                StHar.StokKodu = context.Stoklar.Where(c => c.Barkod == txtBarkod.Text ||
                                       c.StokKodu == txtBarkod.Text).Select(x => x.StokKodu).FirstOrDefault();

                if (StHar.StokKodu == null)
                {
                    StHar.StokKodu = context.StokBarkod.Where(c => c.Barkod == txtBarkod.Text).Select(x => x.StokKodu).FirstOrDefault();
                    txtMiktar.Value = Convert.ToDecimal(context.StokBarkod.Where(c => c.Barkod == txtBarkod.Text)
                        .Select(x => x.Kull1).FirstOrDefault());
                }


                Entities.Tables.Stok Stokbar = context.Stoklar.Where(c => c.StokKodu == StHar.StokKodu).FirstOrDefault();




                if (Stokbar != null)
                {///*2700329000803*/

                    if (StokKontrol(Stokbar))
                    {
                        var veri = context.StokHareketleri.Local.Where(c => c.StokKodu == Stokbar.StokKodu).FirstOrDefault();//stokHareketDal.GetAll(context, c => c.StokKodu == Stokbar.StokKodu);  //stokHareketDal.GetByFilter(context, c => c.StokKodu == Stokbar.StokKodu);//context.StokHareketleri.Local.ToBindingList().Where(c => c.StokKodu == Stokbar.StokKodu);
                        if (veri != null)
                        {
                            veri.Miktar += txtMiktar.Value;
                           KampanyaVarmi(Convert.ToDecimal(veri.Miktar),veri);

                        }
                        else
                        {

                            stokHareketDal.AddOrUpdate(context, StokSec(Stokbar));


                        }
                    }
                    Toplamlar();
                }
                else
                {
                    Entities.Tables.HavuzStok HvzStok = context.HavuzStok.Where(c => c.BARKOD == txtBarkod.Text).FirstOrDefault();
                    if (HvzStok != null)
                    {
                        if (MessageBox.Show($"Stokğunuz da   !- { txtBarkod.Text} Barkod Bulunamadı ! \n { HvzStok.STOK} \n Havuzdan Ürünü Çekmek İstiyormusunuz ?", "Stok Uyarısı", MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            Stok.FrmHavuzStok frm = new Stok.FrmHavuzStok(HvzStok.BARKOD, HvzStok.STOK);
                            frm.ShowDialog();
                           // StHar.StokKodu = context.Stoklar.Where(c => c.Barkod == txtBarkod.Text ||
                           //           c.StokKodu == txtBarkod.Text).Select(x => x.StokKodu).FirstOrDefault();
                           // Stokbar = context.Stoklar.Where(c => c.StokKodu == StHar.StokKodu).FirstOrDefault();
                           // stokHareketDal.AddOrUpdate(context, StokSec(Stokbar));
                        }
                    }
                    else
                    {
                        if (MessageBox.Show($"Stokğunuz da   !- { txtBarkod.Text} Barkod Bulunamadı ! \n  Eklemek İstiyormusunuz ?", "Stok Ekleme", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        {
                            Stok.FrmHavuzStok frm = new Stok.FrmHavuzStok(txtBarkod.Text,"");
                            frm.ShowDialog();
                        }
                    }


                    //
                }
                txtBarkod.Text = null;
                txtMiktar.Text = "1"; 
                #endregion
            }

            Tusbas(sender,  e);

           

        }
        public void KampanyaVarmi(decimal UrunMik,StokHareket veri)
        {
            var Kampanya = context.KampanyaAna.Where(c => c.Durumu == true).ToList();
           
            Kampanya = Kampanya.Where(c => c.KampanyaTuru == "003" || c.KampanyaTuru == "005" || c.KampanyaTuru == "006").ToList();
           
            foreach (var item in Kampanya)
            {
                var KampanyaUrunleri = context.KampanyaUrun.Where(c => c.Durumu == true && c.KampanyaKodId == item.KampanyaKod).ToList();
               
                KampanyaUrunleri = KampanyaUrunleri.Where(c => c.StokKodu == veri.StokKodu).ToList();
               
                foreach (var Urun in KampanyaUrunleri)
                {
                    if (UrunMik< Urun.KampanyaAdeti)
                    {
                       
                        veri.IndirimOrani = 0;
                    }
                    else {

                        veri.IndirimOrani = Urun.IndirimOrani;
                    }
                    
                    break;
                }
               // MessageBox.Show(item.KampanyaAdi);
            }
           
        }

        private void txtIskontoOran_Validated(object sender, EventArgs e)
        {
            Toplamlar();
        }
        private void chkOdemeBol_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOdemeBol.Checked)
            {
                navigationFrame1.SelectedPage = navOdeme;
                flowOdemeTurleri.Controls.Find("AcikHesap", false).SingleOrDefault().Enabled = false;
            }
            else
            {
                navigationFrame1.SelectedPage = navStokHareket;
                flowOdemeTurleri.Controls.Find("AcikHesap", false).SingleOrDefault().Enabled = true;
            }
        }

        private void btnIslemBitir_Click(object sender, EventArgs e)
        {
            radialOdeme.ShowPopup(MousePosition);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FisiKaydet(ReportsPrintTool.Belge.Fatura);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FisiKaydet(ReportsPrintTool.Belge.BilgiFisi);
        }

        private void gridStokHareket_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (tileView1.FocusedColumn == colMiktar)
            {
                txtMiktar.Value = 0;
                string barkod = tileView1.GetFocusedRowCellValue(colBarkod).ToString();
                if (!StokKontrol(context.Stoklar.SingleOrDefault(c => c.Barkod == barkod)))
                {
                    tileView1.SetFocusedRowCellValue(colMiktar, eskiFiyat);
                };
                txtMiktar.Value = 1;

            }
            Toplamlar();
            OdenenTutarGuncelle();
        }

        private void gridStokHareket_ShownEditor(object sender, EventArgs e)
        {
            if (tileView1.FocusedColumn == colMiktar)
            {
                eskiFiyat = (decimal)tileView1.GetFocusedRowCellValue(colMiktar);
            }
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }


        private void gridLookUpEdit1View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            DovizLiTutar();
        }

        private void repoKHSil_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridKasaHareket.DeleteSelectedRows();
                OdenenTutarGuncelle();
            }
        }

        private void repoKasa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
         //   FrmKasaSec form = new FrmKasaSec();
         //   form.ShowDialog();
         //   if (form.secildi)
         //   {
         //       gridKasaHareket.SetFocusedRowCellValue(colKasaKodu, form.entity.KasaKodu);
         //       gridKasaHareket.SetFocusedRowCellValue(colKasaAdi, form.entity.KasaAdi);
         //   }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FisiKaydet(ReportsPrintTool.Belge.Diger);
        }

        private void FrmFrontOffice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (context.ChangeTracker.HasChanges())
            {
                if (MessageBox.Show("Fiş üzerinde değişiklik yaptınız. Değişiklikleri iptal edip formu kapatmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
               
                }
            }
            Properties.Settings.Default.SolPanelGenislik = navigationPane1.Width;
            Properties.Settings.Default.SatisPaneliGenislik = splitContainerControl1.SplitterPosition;
            Properties.Settings.Default.Save();
        }

        private void tileView1_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
           

        }

        private void tileView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        
        }

        string ilk, ikinci = "";
        private void tileView1_Click(object sender, EventArgs e)
        {


        //    tileView1.GetFocusedRowCellValue(colBirimFiyati).ToString();





          // ilk = tileView1.FocusedRowHandle.ToString(); 
          // //  var a = "";
          //
          //
          // if (tileView1.FocusedRowHandle>-1)
          // {
          //
          //     tileView1.SelectRow(-1);
          //     tileView1.FocusedRowHandle = -1;
          //
          // }

            //   if (tileView1.SelectRow)
            //   {
            //
            //       a = tileView1.FocusedRowHandle;
            //
            //   }
            //   else
            //   {
            //       tileView1.SelectRow(-1);
            //       tileView1.FocusedRowHandle = -1;
            //   }
            // MessageBox.Show(a.ToString());
            // MessageBox.Show(Convert.ToDecimal(tileView1.Columns["malzemetutar"].SummaryItem.SummaryValue);
            // MessageBox.Show(tileView1.GetFocusedRowCellValue(colBirimFiyati).ToString());
            // tileView1.SetFocusedRowCellValue(colBirimFiyati, 8);
            //tileView1.GetFocusedRowCellValue(colBirimFiyati) = "8";
            // if (tileView1.GetFocusedRowCellValue(colId).ToString()=="")
            // {
            //   tileView1.SelectRow(-1);
            //   tileView1.FocusedRowHandle = -1;
            //  }
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
      

            if (tileView1.FocusedRowHandle > -1)
            {
                FrmFiyatDegistir fiyat = new FrmFiyatDegistir();
                fiyat.txtFiyat.Text = tileView1.GetFocusedRowCellValue(colBirimFiyati).ToString();
               fiyat.ShowDialog();

              
                tileView1.SetFocusedRowCellValue(colIndirimOrani, fiyat.iskOran);
                Toplamlar();
            }



        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (tileView1.FocusedRowHandle > -1)
            {
                string fiyatSecilen = tileView1.GetFocusedRowCellValue(colStokKodu).ToString();
                Entities.Tables.Stok fiyatEntity = context.Stoklar.Where(c => c.StokKodu == fiyatSecilen).SingleOrDefault();
                barFiyat1.Tag = _fisentity.FisTuru == "Alış Faturası"
                    ? fiyatEntity.AlisFiyati1 ?? 0
                    : fiyatEntity.SatisFiyati1 ?? 0;
                barFiyat2.Tag = _fisentity.FisTuru == "Alış Faturası"
                    ? fiyatEntity.AlisFiyati2 ?? 0
                    : fiyatEntity.SatisFiyati2 ?? 0;
                barFiyat3.Tag = _fisentity.FisTuru == "Alış Faturası"
                    ? fiyatEntity.AlisFiyati3 ?? 0
                    : fiyatEntity.SatisFiyati3 ?? 0;
                barFiyat1.Caption = string.Format("{0:C2}", barFiyat1.Tag);
                barFiyat2.Caption = string.Format("{0:C2}", barFiyat2.Tag);
                barFiyat3.Caption = string.Format("{0:C2}", barFiyat3.Tag);


                radialFiyat.ShowPopup(MousePosition);
               
            }
            
        }

        private void btnArti_Click(object sender, EventArgs e)
        {
            try
            {
                if (tileView1.GetFocusedRowCellValue(colBirimi).ToString() == "AD" || tileView1.GetFocusedRowCellValue(colBirimi).ToString() == null)
                {
                   // MessageBox.Show(tileView1.FocusedRowHandle.ToString());
                    int adet = int.Parse(tileView1.GetFocusedRowCellValue(colMiktar).ToString());
                    adet++;
                    tileView1.SetFocusedRowCellValue(colMiktar, adet);                
                    var veri = context.StokHareketleri.Local.Where(c => c.StokKodu == tileView1.GetFocusedRowCellValue(colStokKodu).ToString()).FirstOrDefault();
                    if (veri != null)
                    {
                     
                        KampanyaVarmi(Convert.ToDecimal(adet), veri);
                    }
                    Toplamlar(true, tileView1.FocusedRowHandle);
                }
            }
            catch (Exception)
            {

               
            }
            //tileView1.FocusedRowHandle
        }

        private void BtnEksi_Click(object sender, EventArgs e)
        {
            try
            {
                if (tileView1.GetFocusedRowCellValue(colBirimi).ToString() == "AD" || tileView1.GetFocusedRowCellValue(colBirimi).ToString() == null)
                {
                    if ( int.Parse(tileView1.GetFocusedRowCellValue(colMiktar).ToString()) >1)
                    {
                        int adet = int.Parse(tileView1.GetFocusedRowCellValue(colMiktar).ToString());
                        adet--;
                        tileView1.SetFocusedRowCellValue(colMiktar, adet);                     
                        var veri = context.StokHareketleri.Local.Where(c => c.StokKodu == tileView1.GetFocusedRowCellValue(colStokKodu).ToString()).FirstOrDefault();
                        if (veri != null)
                        {
                           
                            KampanyaVarmi(Convert.ToDecimal(adet), veri);
                        }
                        Toplamlar(true, tileView1.FocusedRowHandle);
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (tileView1.RowCount != 0)
            {
                if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tileView1.DeleteSelectedRows();
                    Toplamlar();
                }
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            SatisBeklet();
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            Satisiptal(sender, e);
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            FrmAyarlar form = new FrmAyarlar();
            form.ShowDialog();
        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
            FrmHizliSatis form = new FrmHizliSatis();
            form.ShowDialog();
            HizliSatisMenusuEkle();

        }


        private void calcEdit1_DoubleClick(object sender, EventArgs e)
        {
            if (tileView1.RowCount>0)
            {
                FrmDipiskonto fiyat = new FrmDipiskonto();
                fiyat.txtFiyat.Text = clcDipTop.Text.Replace("₺", "");
                fiyat.KalemSayisi = tileView1.RowCount;
                fiyat.ShowDialog();
                for (int i = 0; i < tileView1.RowCount; i++)
                {

                    tileView1.FocusedRowHandle = i;
                    tileView1.SetFocusedRowCellValue(colIndirimOrani, fiyat.Toptut);
                    Toplamlar();

                }

            }
            
              


        }

        private void txtToplam_EditValueChanged(object sender, EventArgs e)
        {
            clcDipTop.Value = txtToplam.Value;
        }

        private void simpleButton9_Click_1(object sender, EventArgs e)
        {
            tileView1.MoveLast();
        }

        private void btnKalvye_Click(object sender, EventArgs e)
        {
            pnKalvye.Visible= pnKalvye.Visible == true ? false : true;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            clcgizli.Text += 1;
            clcgizli.Visible = true;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            clcgizli.Text += 2;
            clcgizli.Visible = true;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            clcgizli.Text += 3;
            clcgizli.Visible = true;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            clcgizli.Text += 4;
            clcgizli.Visible = true;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            clcgizli.Text += 5;
            clcgizli.Visible = true;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            clcgizli.Text += 6;
            clcgizli.Visible = true;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            clcgizli.Text += 0;
            clcgizli.Visible = true;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            clcgizli.Text += 7;
            clcgizli.Visible = true;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            clcgizli.Text += 8;
            clcgizli.Visible = true;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            clcgizli.Text += 9;
            clcgizli.Visible = true;
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                clcgizli.Text = clcgizli.Text.Substring(0, clcgizli.Text.Length - 1);
                if (clcgizli.Text=="")
                {
                    txtMiktar.Text = "1";
                }
            }
            catch (Exception)
            {

                clcgizli.Visible = false;

            }
          
        }

        private void btntamam_Click(object sender, EventArgs e)
        {
            if (clcgizli.Text!="")
            {
               // txtMiktar.Value = Convert.ToDecimal(clcgizli.Text);
              
                try
                {
                    tileView1.SetFocusedRowCellValue(colMiktar, Convert.ToDecimal(clcgizli.Text));
                    clcgizli.Visible = false;
                   
                    clcgizli.Text = "";
                    txtMiktar.Value = 1;
                    Toplamlar();
                    var veri = context.StokHareketleri.Local.Where(c => c.StokKodu == tileView1.GetFocusedRowCellValue(colStokKodu).ToString()).FirstOrDefault();
                    if (veri != null)
                    {

                        KampanyaVarmi(Convert.ToDecimal(clcgizli.Text), veri);
                    }
                }
                catch (Exception)
                {

                  
                }
               
               
            }
            


        }



        private void btnbos_Click(object sender, EventArgs e)
        {
            clcgizli.Text = "";
            /*arıza sebebi*/
            txtMiktar.Value = 1;

            clcgizli.Visible = false;
        }

        private void clcgizli_EditValueChanged(object sender, EventArgs e)
        {
            txtMiktar.Text = clcgizli.Text;
        }

        private void simpleButton9_Click_2(object sender, EventArgs e)
        {
            Rapor.FrmRapor form = new Rapor.FrmRapor(Sube,Kasiyer);           
            form.ShowDialog();
             

        }

        private void txtOdenen_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Toplamlar();
            }
            catch (Exception)
            {

              
            }
        }

        private void simpleButton19_Click(object sender, EventArgs e)
        {
            Stok.Staktar form = new Stok.Staktar();
            form.ShowDialog();

        }

        private void simpleButton20_Click(object sender, EventArgs e)
        {
            FrmTopluFiyat form = new FrmTopluFiyat();
          
            form.Show();
        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            using (var context = new NetSatisContext())
            {
                if (context.OdemeTurleri.Any() || context.Kasalar.Any() || context.Depolar.Any())
                {

                    FrmFisIslem form = new FrmFisIslem(null, "Alış Faturası");
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ödeme Türü, Kasa, ve Depo eklemeden fatura oluşturulamaz.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          tileView1.ClearSelection();
              
            //  tileView1.TopRowIndex = -1;
        }
    }
}
