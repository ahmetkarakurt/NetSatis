using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NetSatis.BackOffice.Cari;
using NetSatis.BackOffice.Depo;
using NetSatis.BackOffice.Kasa;
using NetSatis.BackOffice.Personel;
using NetSatis.BackOffice.Stok;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tables;
using NetSatis.Entities.Tables.OtherTables;
using NetSatis.Entities.Tools;

namespace NetSatis.BackOffice.Fiş
{

    public partial class FrmFisIslem : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();

        FisDAL fisDal = new FisDAL();
        CariHareketleriDAL CariHareketleriDAL = new CariHareketleriDAL();
        StokHareketDAL stokHareketDal = new StokHareketDAL();
        KasaHareketDAL kasaHareketDal = new KasaHareketDAL();
        PersonelHareketDAL personelHareketDal = new PersonelHareketDAL();
        CariDAL cariDal = new CariDAL();
        private string _cariKodu;
        FisAyarlari ayarlar = new FisAyarlari();
        Fis _fisentity = new Fis();
        CariHareketleri _cariHareketleri = new CariHareketleri();
        CariBakiye _entityBakiye = new CariBakiye();
        private CodeTool kodOlustur;
        public FrmFisIslem(string fisKodu = null, string fisTuru = null, string cariKodu = null, bool siparisFaturalandir = false)
        {
            InitializeComponent();

         
            kodOlustur = new CodeTool(this, CodeTool.Table.Fis);
            context.Stoklar.Load();
            context.Depolar.Load();
            context.Kasalar.Load();
            if (fisKodu != null)
            {
                _fisentity = context.Fisler.SingleOrDefault(c => c.FisKodu == fisKodu);
                if (siparisFaturalandir)
                {
                    if (_fisentity.FisTuru.Contains("Alınan"))
                    {
                        _fisentity.FisTuru = "Perakende Satış Faturası";
                    }
                    else
                    {
                        _fisentity.FisTuru = "Alış Faturası";
                    }
                }
                context.StokHareketleri.Where(c => c.FisKodu == fisKodu).Load();

                if (String.IsNullOrEmpty(_fisentity.FisKodu))
                {
                    context.KasaHareketleri.Where(c => c.FisKodu == fisKodu).Load();
                }
                else
                {
                    context.KasaHareketleri.Where(c => c.FisKodu == _fisentity.FisKodu).Load();
                }

                context.PersonelHareketleri.Where(c => c.FisKodu == fisKodu).Load();
                toggleBakiyeTuru.IsOn = context.KasaHareketleri.Count(c => c.FisKodu == fisKodu && c.Hareket == "Kasa Giriş") == 0;

                if (_fisentity.CariKodu != null)
                {
                
                    lblCariAdi.Text = _fisentity.Cari.CariAdi;
                    lblCariKodu.Text = _fisentity.Cari.CariKodu;
                    _entityBakiye = this.cariDal.CariBakiyesi(context, _fisentity.CariKodu);
                    lblAlacak.Text = _entityBakiye.Alacak.ToString("C2");
                    lblBorc.Text = _entityBakiye.Borc.ToString("C2");
                    lblBakiye.Text = _entityBakiye.Bakiye.ToString("C2");
                }
            }
            else
            {
                _fisentity.FisTuru = fisTuru;

                //_fisentity.Tarih = DateTime.Now;
            }

            if (!context.OdemeTurleri.Any())
            {
                MessageBox.Show("Ödeme Türü eklemelisiniz");
                this.Close();
            }

            txtKod.DataBindings.Add("Text", _fisentity, "FisKodu", false, DataSourceUpdateMode.OnPropertyChanged);
            txtFisTuru.DataBindings.Add("Text", _fisentity, "FisTuru", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbTarih.DataBindings.Add("EditValue", _fisentity, "Tarih", true, DataSourceUpdateMode.OnPropertyChanged, DateTime.Now);
            txtBelgeNo.DataBindings.Add("Text", _fisentity, "BelgeNo", false, DataSourceUpdateMode.OnPropertyChanged);
            txtAciklama.DataBindings.Add("Text", _fisentity, "Aciklama", false, DataSourceUpdateMode.OnPropertyChanged);

            txtFaturaUnvani.DataBindings.Add("Text", _fisentity, "FaturaUnvani", false, DataSourceUpdateMode.OnPropertyChanged);
            txtCepTelefonu.DataBindings.Add("Text", _fisentity, "CepTelefonu", false, DataSourceUpdateMode.OnPropertyChanged);
            txtIl.DataBindings.Add("Text", _fisentity, "Il", false, DataSourceUpdateMode.OnPropertyChanged);
            txtIlce.DataBindings.Add("Text", _fisentity, "Ilce", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSemt.DataBindings.Add("Text", _fisentity, "Semt", false, DataSourceUpdateMode.OnPropertyChanged);
            txtAdres.DataBindings.Add("Text", _fisentity, "Adres", false, DataSourceUpdateMode.OnPropertyChanged);
            txtVergiDairesi.DataBindings.Add("Text", _fisentity, "VergiDairesi", false, DataSourceUpdateMode.OnPropertyChanged);
            txtVergiNo.DataBindings.Add("Text", _fisentity, "VergiNo", false, DataSourceUpdateMode.OnPropertyChanged);

            if (cariKodu != null)
            {
                Entities.Tables.Cari entity = context.Cariler.FirstOrDefault(c => c.CariKodu == cariKodu);
                _entityBakiye = this.cariDal.CariBakiyesi(context, entity.CariKodu);
                _cariKodu = entity.CariKodu;
                _fisentity.CariKodu = entity.CariKodu;

                lblCariKodu.Text = entity.CariKodu;
                lblCariAdi.Text = entity.CariAdi;
                _fisentity.FaturaUnvani = entity.FaturaUnvani;
                _fisentity.VergiDairesi = entity.VergiDairesi;
                _fisentity.VergiNo = entity.VergiNo;
                _fisentity.CepTelefonu = entity.CepTelefonu;
                _fisentity.Il = entity.Il;
                _fisentity.Ilce = entity.Ilce;
                _fisentity.Semt = entity.Semt;
                _fisentity.Adres = entity.Adres;
                lblAlacak.Text = _entityBakiye.Alacak.ToString("C2");
                lblBorc.Text = _entityBakiye.Borc.ToString("C2");
                lblBakiye.Text = _entityBakiye.Bakiye.ToString("C2");

            }


            cmbAy.Month = DateTime.Now.Month;
            for (int i = DateTime.Now.Year - 2; i <= DateTime.Now.Year + 2; i++)
            {
                cmbYil.Properties.Items.Add(i);
            }
            cmbYil.Text = DateTime.Now.Year.ToString();

            gridcontStokHareket.DataSource = context.StokHareketleri.Local.ToBindingList();
            gridcontKasaHareket.DataSource = context.KasaHareketleri.Local.ToBindingList();
            gridcontPersonelHareket.DataSource = context.PersonelHareketleri.Local.ToBindingList();
            FisAyar();
            Toplamlar();
            OdenenTutarGuncelle();
            ButonlariYukle();
            kodOlustur.BarButonOlustur();
        }

        private void ButonlariYukle()
        {
            foreach (var item in context.OdemeTurleri.ToList())
            {
                var buton = new SimpleButton
                {
                    Name = item.OdemeTuruKodu,
                    Tag = item.Id,
                    Text = item.OdemeTuruAdi,
                    Height = 42,
                    Width = 125,
                    //Image = Image.FromFile("c:\fotoğraf.jpg")

                };
                buton.Click += OdemeEkle_Click;
                flowOdemeTurleri.Controls.Add(buton);
            }


            var PersonelSecimIptal = new CheckButton
            {
                Name = "Yok",
                Text = "Yok",
                GroupIndex = 1,
                Height = 42,
                Width = 125,
                Checked = _fisentity.PlasiyerId == null
            };
            PersonelSecimIptal.Click += PersonelYukle_Click;
            flowPersonel.Controls.Add(PersonelSecimIptal);
            foreach (var item in context.Personeller.ToList())
            {
                var buton = new CheckButton
                {
                    Name = item.Id.ToString(),
                    Text = item.PersonelAdi,
                    GroupIndex = 1,
                    Height = 42,
                    Width = 125,
                    Checked = item.Id == _fisentity.PlasiyerId
                };

                buton.Click += PersonelYukle_Click;
                flowPersonel.Controls.Add(buton);
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
                _fisentity.PlasiyerId = Convert.ToInt32(buton.Name);
            }


        }

        private void FisAyar()
        {

            switch (_fisentity.FisTuru)
            {
                case "Alış Faturası":
                    ayarlar.StokHareketi = "Stok Giriş";
                    ayarlar.KasaHareketi = "Kasa Çıkış";
                    ayarlar.OdemeEkrani = true;
                    ayarlar.SatisEkrani = true;
                    ayarlar.BakiyeTuru = "Alacak";
                   
                    lblBaslik.Appearance.ImageIndex = 0;
                    navPersonelIslem.Dispose();
                    break;
                case "Perakende Satış Faturası":
                    ayarlar.StokHareketi = "Stok Çıkış";
                    ayarlar.KasaHareketi = "Kasa Giriş";
                    ayarlar.OdemeEkrani = true;
                    ayarlar.SatisEkrani = true;
                    ayarlar.BakiyeTuru = "Borç";
                    lblBaslik.Appearance.ImageIndex = 1;
                    navPersonelIslem.Dispose();
                    break;
                case "Toptan Satış Faturası":
                    ayarlar.StokHareketi = "Stok Çıkış";
                    ayarlar.KasaHareketi = "Kasa Giriş";
                    ayarlar.OdemeEkrani = true;
                    ayarlar.SatisEkrani = true;
                    ayarlar.BakiyeTuru = "Borç";
                    lblBaslik.Appearance.ImageIndex = 2;
                    navPersonelIslem.Dispose();
                    break;
                case "Alış İade Faturası":
                    ayarlar.StokHareketi = "Stok Çıkış";
                    ayarlar.KasaHareketi = "Kasa Giriş";
                    ayarlar.OdemeEkrani = true;
                    ayarlar.SatisEkrani = true;
                    ayarlar.BakiyeTuru = "Borç";
                    lblBaslik.Appearance.ImageIndex = 3;
                    navPersonelIslem.Dispose();
                    break;
                case "Satış İade Faturası":
                    ayarlar.StokHareketi = "Stok Giriş";
                    ayarlar.KasaHareketi = "Kasa Çıkış";
                    ayarlar.OdemeEkrani = true;
                    ayarlar.SatisEkrani = true;
                    ayarlar.BakiyeTuru = "Alacak";
                    lblBaslik.Appearance.ImageIndex = 4;
                    navPersonelIslem.Dispose();
                    break;
                case "Sayım Fazlası Fişi":
                    ayarlar.StokHareketi = "Stok Giriş";
                    lblBaslik.Appearance.ImageIndex = 5;
                    ayarlar.OdemeEkrani = false;
                    ayarlar.SatisEkrani = true;
                    panelOdeme.Visible = false;
                    navOdemeEkrani.Dispose();
                    navCariBilgi.Dispose();
                    navPersonelIslem.Dispose();
                    break;
                case "Sayım Eksiği Fişi":
                    ayarlar.StokHareketi = "Stok Çıkış";
                    lblBaslik.Appearance.ImageIndex = 6;
                    ayarlar.OdemeEkrani = false;
                    ayarlar.SatisEkrani = true;
                    panelOdeme.Visible = false;
                    navOdemeEkrani.Dispose();
                    navCariBilgi.Dispose();
                    navPersonelIslem.Dispose();
                    break;
                case "Stok Devir Fişi":
                    ayarlar.StokHareketi = "Stok Giriş";
                    lblBaslik.Appearance.ImageIndex = 7;
                    ayarlar.OdemeEkrani = false;
                    ayarlar.SatisEkrani = true;
                    panelOdeme.Visible = false;
                    navOdemeEkrani.Dispose();
                    navCariBilgi.Dispose();
                    navPersonelIslem.Dispose();
                    break;

                case "Tahsilat Fişi":
                    ayarlar.KasaHareketi = "Kasa Giriş";
                    ayarlar.OdemeEkrani = true;
                    ayarlar.SatisEkrani = false;
                    ayarlar.BakiyeTuru = "Alacak";
                    navSatisEkrani.Dispose();
                    navPersonelIslem.Dispose();
                    panelOdeme.Visible = false;
                    panelIskonto.Visible = false;
                    panelKDV.Visible = false;
                    panelToplam.Top = 20;
                    grpToplamlar.Height = 65;
                    navigationPane2.SelectedPage = navOdemeEkrani;
                    break;
                case "Ödeme Fişi":
                    ayarlar.KasaHareketi = "Kasa Çıkış";
                    ayarlar.OdemeEkrani = true;
                    ayarlar.SatisEkrani = false;
                    ayarlar.BakiyeTuru = "Borç";
                    navSatisEkrani.Dispose();
                    navPersonelIslem.Dispose();
                    panelOdeme.Visible = false;
                    panelIskonto.Visible = false;
                    panelKDV.Visible = false;
                    panelToplam.Top = 20;
                    grpToplamlar.Height = 65;
                    navigationPane2.SelectedPage = navOdemeEkrani;
                    break;

                case "Cari Devir Fişi":
                    ayarlar.KasaHareketi = "Kasa Giriş";
                    ayarlar.OdemeEkrani = true;
                    ayarlar.SatisEkrani = false;
                    navSatisEkrani.Dispose();
                    navPersonelIslem.Dispose();
                    panelOdeme.Visible = false;
                    panelIskonto.Visible = false;
                    panelKDV.Visible = false;
                    panelToplam.Top = 20;
                    grpToplamlar.Height = 65;
                    panelCariDevir.Visible = true;
                    navigationPane2.SelectedPage = navOdemeEkrani;
                    txtKod.Width = 186;

                    break;

                case "Hakediş Fişi":
                    ayarlar.KasaHareketi = "Kasa Çıkış";
                    ayarlar.OdemeEkrani = true;
                    ayarlar.SatisEkrani = false;
                    navSatisEkrani.Dispose();
                    navCariBilgi.Dispose();
                    navPlasiyerBilgi.Dispose();
                    panelIskonto.Visible = false;
                    panelKDV.Visible = false;
                    navigationPane2.SelectedPage = navPersonelIslem;
                    break;
                case "Sipariş Fişi(Alınan)":
                    ayarlar.StokHareketi = "Stok Çıkış";
                    lblBaslik.Appearance.ImageIndex = 8;
                    ayarlar.OdemeEkrani = false;
                    ayarlar.SatisEkrani = true;
                    panelOdeme.Visible = false;
                    navOdemeEkrani.Dispose();
                    navPersonelIslem.Dispose();
                    break;
                case "Sipariş Fişi(Verilen)":
                    ayarlar.StokHareketi = "Stok Giriş";
                    lblBaslik.Appearance.ImageIndex = 9;
                    ayarlar.OdemeEkrani = false;
                    ayarlar.SatisEkrani = true;
                    panelOdeme.Visible = false;
                    navOdemeEkrani.Dispose();
                    navPersonelIslem.Dispose();
                    break;
            }
        }

        private void OdemeEkle_Click(object sender, EventArgs e)
        {
            var buton = (sender as SimpleButton);
            if (ayarlar.SatisEkrani == false && txtFisTuru.Text != "Hakediş Fişi")
            {
                FrmOdemeEkrani form = new FrmOdemeEkrani(Convert.ToInt32(buton.Tag));
                form.ShowDialog();
                if (form.entity != null)
                {
                    kasaHareketDal.AddOrUpdate(context, form.entity);
                    OdenenTutarGuncelle();
                }
            }
            else
            {
                if (txtOdenmesiGereken.Value <= 0)
                {
                    MessageBox.Show("Ödenmesi gereken tutar zaten ödenmiş durumdadır.");
                }
                else
                {
                    if (txtFisTuru.Text != "Hakediş Fişi")
                    {
                        KasaHareket entityKasaHareket = new KasaHareket
                        {
                            OdemeTuruId = Convert.ToInt32(buton.Tag),
                            KasaId = Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_VarsayilanKasa)),
                            Tarih = DateTime.Now,
                            Tutar = txtOdenmesiGereken.Value
                        };
                        kasaHareketDal.AddOrUpdate(context, entityKasaHareket);
                        OdenenTutarGuncelle();
                    }
                    else
                    {
                        for (int i = 0; i < gridPersonelHareket.RowCount; i++)
                        {
                            KasaHareket entityKasaHareket = new KasaHareket
                            {
                                //Burayı Kontrol Et. Sıkıntı Olacak.
                                CariKodu = _cariKodu,
                                OdemeTuruId = Convert.ToInt32(buton.Tag),
                                Tarih = DateTime.Now,
                                Tutar = Convert.ToDecimal(gridPersonelHareket.GetRowCellValue(i, colOdenecekTutar)),
                                Aciklama = $"{gridPersonelHareket.GetRowCellValue(i, colPersonelKodu).ToString()} - {gridPersonelHareket.GetRowCellValue(i, colPersonelAdi).ToString()} || Aylık Maaş : {Convert.ToDecimal(gridPersonelHareket.GetRowCellValue(i, colAylikMaasi)).ToString("C2")} || Prim Tutarı : {Convert.ToDecimal(gridPersonelHareket.GetRowCellValue(i, colPrimTutarı)).ToString("C2")}"
                            };
                            kasaHareketDal.AddOrUpdate(context, entityKasaHareket);
                        }
                        OdenenTutarGuncelle();
                    }


                }
            }
        }
        private void OdenenTutarGuncelle()
        {
            gridKasaHareket.UpdateSummary();
            if (ayarlar.SatisEkrani || _fisentity.FisTuru == "Hakediş Fişi")
            {
                txtOdenenTutar.Value = Convert.ToDecimal(colTutar.SummaryItem.SummaryValue);
                txtOdenmesiGereken.Value = txtToplam.Value - txtOdenenTutar.Value;
            }
            else
            {
                txtToplam.Value = Convert.ToDecimal(colTutar.SummaryItem.SummaryValue);
            }

        }
        private StokHareket StokSec(Entities.Tables.Stok entity)
        {
            StokHareket stokHareket = new StokHareket();
            IndirimDaL indirimDal = new IndirimDaL();
            stokHareket.StokKodu = entity.StokKodu;
            stokHareket.IndirimOrani = indirimDal.StokIndirimi(context, entity.StokKodu);
            stokHareket.DepoId = Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_VarsayilanDepo));
            stokHareket.BirimFiyati = new[] { "Alış Faturası", "Alış İade Faturası" }.Contains(txtFisTuru.Text) ? entity.AlisFiyati1 : entity.SatisFiyati1;
            stokHareket.Miktar = txtMiktar.Value;
            stokHareket.Tarih = DateTime.Now;
            stokHareket.Kdv = entity.SatisKdv;
            return stokHareket;
        }
        private void btnStokSec_Click(object sender, EventArgs e)
        {
            FrmStokSec form = new FrmStokSec();
            form.ShowDialog();
            if (form.secildi)
            {
                //  StokBarkod entity;
                Entities.Tables.Stok entity;
                //      Stok Stokvarmi;
                entity = context.Stoklar.Where(c => c.StokKodu == form.stokkodu).FirstOrDefault();
                stokHareketDal.AddOrUpdate(context, StokSec(entity));
               
                Toplamlar();
            }
        }

        string SecilenStok = "";
        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                SecilenStok = context.Stoklar.Where(c => c.Barkod == txtBarkod.Text ||
                c.StokKodu == txtBarkod.Text || c.StokKodu == txtBarkod.Text || c.Barkod==txtBarkod.Text).Select(x => x.StokKodu).FirstOrDefault();

                if (SecilenStok == null)
                {
                    SecilenStok = context.StokBarkod.Where(c => c.Barkod == txtBarkod.Text ||
                  c.Stok.StokKodu == txtBarkod.Text || c.Stok.StokKodu == txtBarkod.Text).Select(x => x.StokKodu).FirstOrDefault();

                }
                Entities.Tables.Stok Stokbar = context.Stoklar.Where(c => c.StokKodu == SecilenStok).FirstOrDefault();

                if (Stokbar != null)
                {
                    stokHareketDal.AddOrUpdate(context, StokSec(Stokbar));
                    Toplamlar();
                }
                else
                {
                    MessageBox.Show("Aradığınız barkod numarası ürünler arasında bulunamadı.");
                }
                txtBarkod.Text = null;
            }
            if (e.KeyCode==Keys.F5)
            {
                SatisBitir();
            }
        }
        private void btnCariTemizle_Click(object sender, EventArgs e)
        {
            _cariKodu = null;
            _fisentity.CariKodu = null;
            lblCariKodu.Text = null; lblCariAdi.Text = null;
            txtFaturaUnvani.Text = null;
            txtVergiDairesi.Text = null;
            txtVergiNo.Text = null;
            txtCepTelefonu.Text = null;
            txtIl.Text = null;
            txtIlce.Text = null;
            txtSemt.Text = null;
            txtAdres.Text = null;
            lblAlacak.Text = "Görüntülenemiyor";
            lblBorc.Text = "Görüntülenemiyor";
            lblBakiye.Text = "Görüntülenemiyor";
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
                lblCariKodu.Text = entity.CariKodu;
                lblCariAdi.Text = entity.CariAdi;
                txtFaturaUnvani.Text = entity.FaturaUnvani;
                txtVergiDairesi.Text = entity.VergiDairesi;
                txtVergiNo.Text = entity.VergiNo;
                txtCepTelefonu.Text = entity.CepTelefonu;
                txtIl.Text = entity.Il;
                txtIlce.Text = entity.Ilce;
                txtSemt.Text = entity.Semt;
                txtAdres.Text = entity.Adres;
                lblAlacak.Text = _entityBakiye.Alacak.ToString("C2");
                lblBorc.Text = _entityBakiye.Borc.ToString("C2");
                lblBakiye.Text = _entityBakiye.Bakiye.ToString("C2");
            }
        }
        private void Toplamlar()
        {
            gridStokHareket.UpdateSummary();
            gridPersonelHareket.UpdateSummary();
            txtIskontoTutar.Value = Convert.ToDecimal(colToplamTutar.SummaryItem.SummaryValue) / 100 * txtIskontoOran.Value;
            if (_fisentity.FisTuru == "Hakediş Fişi")
            {
                txtToplam.Value = Convert.ToDecimal(colOdenecekTutar.SummaryItem.SummaryValue);
            }
            else
            {
                txtToplam.Value = Convert.ToDecimal(colToplamTutar.SummaryItem.SummaryValue) - txtIskontoTutar.Value;
            }
            txtOdenmesiGereken.Value = txtToplam.Value - txtOdenenTutar.Value;
            txtKdvToplam.Value = Convert.ToDecimal(colKdvToplam.SummaryItem.SummaryValue);
            txtIndirimToplam.Value = Convert.ToDecimal(colIndirimTutar.SummaryItem.SummaryValue);

        }
        private void gridStokHareket_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Toplamlar();
        }

        private void txtIskontoOran_Validated(object sender, EventArgs e)
        {
            Toplamlar();
        }
        private void repoDepo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                FrmDepoSec form = new FrmDepoSec(gridStokHareket.GetFocusedRowCellValue(colStokKodu).ToString());
                form.ShowDialog();
                if (form.secildi)
                {
                    gridStokHareket.SetFocusedRowCellValue(colDepoId, form.entity.Id);
                    context.ChangeTracker.DetectChanges();
                    gridStokHareket.RefreshRow(gridStokHareket.FocusedRowHandle);
                }
            }
        }

        private void repoBirimFiyat_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string fiyatSecilen = gridStokHareket.GetFocusedRowCellValue(colStokKodu).ToString();
            Entities.Tables.Stok fiyatEntity = context.Stoklar.Where(c => c.StokKodu == fiyatSecilen).SingleOrDefault();
            barFiyat1.Tag = txtFisTuru.Text == "Alış Faturası" ? fiyatEntity.AlisFiyati1 ?? 0 : fiyatEntity.SatisFiyati1 ?? 0;
            barFiyat2.Tag = txtFisTuru.Text == "Alış Faturası"
                ? fiyatEntity.AlisFiyati2 ?? 0 : fiyatEntity.SatisFiyati2 ?? 0;
            barFiyat3.Tag = txtFisTuru.Text == "Alış Faturası"
                ? fiyatEntity.AlisFiyati3 ?? 0 : fiyatEntity.SatisFiyati3 ?? 0;
            barFiyat1.Caption = string.Format("{0:C2}", barFiyat1.Tag);
            barFiyat2.Caption = string.Format("{0:C2}", barFiyat2.Tag);
            barFiyat3.Caption = string.Format("{0:C2}", barFiyat3.Tag);

            radialFiyat.ShowPopup(MousePosition);


        }
        private void FiyatSec(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridStokHareket.SetFocusedRowCellValue(colBirimFiyati, Convert.ToDecimal(e.Item.Tag));
        }

        private void repoSeriNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string veri = Convert.ToString(gridStokHareket.GetFocusedRowCellValue(colSeriNo));
            FrmSeriNoGir form = new FrmSeriNoGir(veri);
            form.ShowDialog();
            gridStokHareket.SetFocusedRowCellValue(colSeriNo, form.veriSeriNo);
        }

        private void repoSil_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridStokHareket.DeleteSelectedRows();
                Toplamlar();
            }
        }

        private void repoKasa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmKasaSec form = new FrmKasaSec();
            form.ShowDialog();
            if (form.secildi)
            {
                gridKasaHareket.SetFocusedRowCellValue(colKasaId, form.entity.Id);
                context.ChangeTracker.DetectChanges();
                gridKasaHareket.RefreshRow(gridKasaHareket.FocusedRowHandle);
            }
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

        private void btnSatisBitir_Click(object sender, EventArgs e)
        {
            SatisBitir();
        }


        private void SatisBitir()
        {
            if (_fisentity.FisTuru == "Cari Devir Fişi")
            {
                if (toggleBakiyeTuru.IsOn)
                {
                    ayarlar.KasaHareketi = "Kasa Çıkış";
                }
                else
                {
                    ayarlar.KasaHareketi = "Kasa Giriş";
                }
            }




            string message = null;
            int hata = 0;
            if (gridStokHareket.RowCount == 0 && ayarlar.SatisEkrani == true)
            {
                message += "Satış Ekranında eklenmiş bir ürün bulunamadı." + System.Environment.NewLine;
                hata++;
               
            }
            if (_fisentity.CariKodu == null && ayarlar.SatisEkrani == false && txtFisTuru.Text != "Hakediş Fişi")
            {
                message += txtFisTuru.Text + " türünde cari seçimi zorunludur." + System.Environment.NewLine;
                hata++;
                navigationPane1.SelectedPage = navCariBilgi;
                txtKod.Focus();

            }

            if (gridKasaHareket.RowCount == 0 && ayarlar.SatisEkrani == false && txtFisTuru.Text != "Hakediş Fişi")
            {
                message += "Herhangi bir ödeme bulunamadı." + System.Environment.NewLine;
                hata++;
            }
            if (txtKod.Text == "")
            {
                message += "Fiş Kodu alanı boş geçilemez." + System.Environment.NewLine;
                hata++;
                navigationPane1.SelectedPage = navFisBilgi;
                btnCariSec.Focus();
            }
            if (txtOdenmesiGereken.Value != 0 && ayarlar.OdemeEkrani == true && String.IsNullOrEmpty(lblCariKodu.Text) && txtFisTuru.Text != "Hakediş Fişi")
            {
                message += "Ödenmesi gereken tutar ödenmemiş görünüyor. Ödenmeyen kısmı açık hesaba aktarabilmeniz için Cari seçmeniz gerekmektedir." + System.Environment.NewLine;
                hata++;
                   navigationPane1.SelectedPage = navCariBilgi;
                txtKod.Focus();

                   

            }

            if (hata != 0)
            {
                MessageBox.Show(message);
                return;
            }

            if (txtOdenmesiGereken.Value != 0 && ayarlar.OdemeEkrani == true)
            {
                if (MessageBox.Show($"Ödemenin {txtOdenmesiGereken.Value.ToString("C2")} tutarındaki kısmı açık hesap bakiyesi olarak kaydedilecektir. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    MessageBox.Show("İsteğiniz üzerine işlem iptal edildi.");
                    return;
                }
            }

            foreach (var stokVeri in context.StokHareketleri.Local.ToList())
            {
                stokVeri.Tarih = stokVeri.Tarih == null
                    ? Convert.ToDateTime(cmbTarih.DateTime)
                    : Convert.ToDateTime(stokVeri.Tarih);
                stokVeri.FisKodu = txtKod.Text;
                stokVeri.Hareket = ayarlar.StokHareketi;
                stokVeri.SubeId = 1;// şubeli değiştirelecek
                stokVeri.Siparis = txtFisTuru.Text.Contains("Sipariş Fişi")
                   
                    ? stokVeri.Siparis = true
                    : stokVeri.Siparis = false;
                stokVeri.Stok.AlisFiyati3 = stokVeri.BirimFiyati.Value;
            }

             foreach (var itemHareket in context.PersonelHareketleri.Local.ToList())
            {
                itemHareket.FisKodu = txtKod.Text;
            }


            if (ayarlar.BakiyeTuru == "Borç")
            {
                _fisentity.Borc = txtToplam.Value;
                _cariHareketleri.Borc = _fisentity.Borc;
            }
            else if (ayarlar.BakiyeTuru == "Alacak")
            {
                _fisentity.Alacak = txtToplam.Value;
                _cariHareketleri.Alacak = _fisentity.Alacak;
            }
            _fisentity.ToplamTutar = txtToplam.Value;
            _fisentity.IskontoOrani = txtIskontoOran.Value;
            _fisentity.IskontoTutar = txtIskontoTutar.Value;
          
            _fisentity.SubeId = 1; // şube değiştirelecek
            _fisentity.Tarih = _fisentity.Tarih ?? DateTime.Now;


            #region CariHareketKayıtı
            _cariHareketleri.CariKodu = _fisentity.CariKodu;
            _cariHareketleri.Tarih = _fisentity.Tarih;
            _cariHareketleri.VadeTarihi = _fisentity.Tarih;
            _cariHareketleri.FisKodu = _fisentity.FisKodu;
            _cariHareketleri.Aciklama = _fisentity.Aciklama;
            _cariHareketleri.HareketTuru = _fisentity.FisTuru;
            CariHareketleriDAL.AddOrUpdate(context, _cariHareketleri);


            #endregion


            fisDal.AddOrUpdate(context, _fisentity);
            // context.SaveChanges();
            if (ayarlar.OdemeEkrani)
            {
               //Fis fisOdeme = new Fis();

                //if (String.IsNullOrEmpty(_fisentity.FisBaglantiKodu))
                //{
                //    fisOdeme = _fisentity.Clone();
                //    fisOdeme.FisTuru = "Fiş Ödemesi";
                //    fisOdeme.Id = 0;
                //    fisOdeme.FisKodu = kodOlustur.YeniFisOdemeKoduOlustur();
                //    fisOdeme.FisBaglantiKodu = _fisentity.FisKodu;
                //}
                //else
                //{
                //   var fisOdeme = context.Fisler.SingleOrDefault(c => c.FisKodu == _fisentity.FisBaglantiKodu);
                //}

                //_fisentity.FisBaglantiKodu = fisOdeme.FisKodu;

                //if (ayarlar.BakiyeTuru == "Borç")
                //{
                //    fisOdeme.Alacak = txtOdenenTutar.Value;
                //    fisOdeme.Borc = 0;
                //}
                //else if (ayarlar.BakiyeTuru == "Alacak")
                //{
                //    fisOdeme.Borc = txtOdenenTutar.Value;
                //    fisOdeme.Alacak = 0;
                //}

              
                foreach (var kasaVeri in context.KasaHareketleri.Local.ToList())
                {
                  
                    kasaVeri.Tarih = kasaVeri.Tarih == null
                        ? Convert.ToDateTime(cmbTarih.DateTime)
                        : Convert.ToDateTime(kasaVeri.Tarih);
                    kasaVeri.FisKodu = _fisentity.FisKodu;
                    kasaVeri.Hareket = ayarlar.KasaHareketi;
                    if (txtFisTuru.Text != "Hakediş Fişi")
                    {
                        kasaVeri.CariKodu = _cariKodu;
                    }
                    kasaVeri.SubeId = 1;

                    #region CariÖdemeHareketi
                    CariHareketleri cariHareketleri = new CariHareketleri();
                    cariHareketleri.CariKodu = kasaVeri.CariKodu;
                    cariHareketleri.Tarih = kasaVeri.Tarih;
                    cariHareketleri.VadeTarihi = kasaVeri.Tarih;
                    cariHareketleri.FisKodu = _fisentity.FisKodu;
                    if (ayarlar.BakiyeTuru == "Borç")
                    {
                        cariHareketleri.Alacak = txtOdenenTutar.Value;
                        cariHareketleri.Borc = 0;
                    }
                    else if (ayarlar.BakiyeTuru == "Alacak")
                    {
                        cariHareketleri.Borc = txtOdenenTutar.Value;
                        cariHareketleri.Alacak = 0;
                    }
                    cariHareketleri.HareketTuru = kasaVeri.Hareket;

                    if (txtFisTuru.Text != "Tahsilat Fişi" && txtFisTuru.Text !="Ödeme Fişi" && txtFisTuru.Text != "Cari Devir Fişi")
                    {
                        CariHareketleriDAL.AddOrUpdate(context, cariHareketleri);
                    }
                   
                    #endregion


                }
                //fisOdeme.SubeId = 1;//şube koduna göre değiştirelecek
                //fisOdeme.ToplamTutar = txtOdenenTutar.Value;

                //fisDal.AddOrUpdate(context, fisOdeme);
            }
            try
            {

                



                kodOlustur.KodArtirma();
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show(" Bir Hata ile Karşılaşıldı \n"+ex.Message.ToString());
            }
            this.Close();
        }

        private void FrmFisIslem_Load(object sender, EventArgs e)
        {

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            if (gridStokHareket.RowCount != 0)
            {
                if (MessageBox.Show(
                        "Satış Ekranına eklenmiş ürünler var. Bu işlemi iptal edip formu kapatmak istediğinize emin misiniz?",
                        "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {


        }

        private void btnPersonelBul_Click(object sender, EventArgs e)
        {
            DateTime time = new DateTime(Convert.ToInt32(cmbYil.Text), cmbAy.Month, 1);
            FrmPersonelSec form = new FrmPersonelSec(time);
            form.ShowDialog();
            if (form.secildi)
            {
                foreach (var itemHareket in form.secilen.ToList())
                {
                    if (context.PersonelHareketleri.Local.Count(c => c.Donemi == time && c.PersonelKodu == itemHareket.PersonelKodu) == 0)
                    {
                        personelHareketDal.AddOrUpdate(context, itemHareket);
                    }
                }
                Toplamlar();
            }
        }

        private void cmbTarih_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                cmbTarih.DateTime = DateTime.Now;
            }
        }

        private void FrmFisIslem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (context.ChangeTracker.HasChanges())
            {
                if (MessageBox.Show("Fiş üzerinde değişiklik yaptınız. Değişiklikleri iptal edip formu kapatmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}