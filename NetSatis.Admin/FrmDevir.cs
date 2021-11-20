using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraWizard;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tables;
using NetSatis.Entities.Tables.OtherTables;
using NetSatis.Entities.Tools;
using NetSatis.Entities.Tools.LoadingTool;

namespace NetSatis.Admin
{
    public partial class FrmDevir : DevExpress.XtraEditors.XtraForm
    {
        private NetSatisContext kaynakContext;
        SqlConnectionStringBuilder connKaynak = new SqlConnectionStringBuilder();
        private NetSatisContext hedefContext;
        SqlConnectionStringBuilder connHedef = new SqlConnectionStringBuilder();
        private List<string> dbList;
        private CodeTool kodOlustur;
        private LoadingTool yuklemeFormu;
        private string seciliKaynak, seciliHedef;

        public FrmDevir()
        {
            InitializeComponent();
            yuklemeFormu = new LoadingTool(this);
            kodOlustur = new CodeTool(this, CodeTool.Table.Fis);
            connKaynak.DataSource = "(localdb)\\v11.0";
            connKaynak.InitialCatalog = "master";
            connKaynak.IntegratedSecurity = true;
            kaynakContext = new NetSatisContext(connKaynak.ConnectionString);
            dbList = kaynakContext.Database
                .SqlQuery<string>("Select name From master.dbo.sysdatabases Where name like 'NetSatis%'").ToList();
            KaynakDbYukle();
            HedefDbYukle();
        }

        private void KaynakDbYukle()
        {
            foreach (var item in dbList)
            {
                CheckButton buton = new CheckButton
                {
                    Name = item,
                    Text = item.Replace("NetSatis", ""),
                    GroupIndex = 1,
                    ImageList = ımageList1,
                    ImageToTextAlignment = ImageAlignToText.TopCenter,
                    ImageIndex = 0,
                    Height = 100,
                    Width = 100
                };
                buton.Click += KaynakSec;
                flowKaynak.Controls.Add(buton);
            }

        }

        private void KaynakSec(object sender, EventArgs e)
        {
            CheckButton buton = (CheckButton)sender;
            connKaynak.DataSource = "(localdb)\\v11.0";
            connKaynak.InitialCatalog = "NetSatis" + buton.Text;
            connKaynak.IntegratedSecurity = true;
            seciliKaynak = buton.Text;
            kaynakContext = new NetSatisContext(connKaynak.ConnectionString);
        }

        private void HedefDbYukle()
        {
            SimpleButton YeniEkle = new SimpleButton
            {
                Name = "YeniDonemEkle",
                Text = "Yeni Dönem Ekle",
                ImageList = ımageList1,
                ImageIndex = 1,
                ImageToTextAlignment = ImageAlignToText.TopCenter,
                Height = 100,
                Width = 100
            };
            YeniEkle.Click += YeniDonemEkle;
            flowHedef.Controls.Add(YeniEkle);
            foreach (var item in dbList)
            {
                CheckButton buton = new CheckButton
                {
                    Name = item,
                    Text = item.Replace("NetSatis", ""),
                    GroupIndex = 2,
                    ImageList = ımageList1,
                    ImageToTextAlignment = ImageAlignToText.TopCenter,
                    ImageIndex = 0,
                    Height = 100,
                    Width = 100
                };
                buton.Click += HedefSec;
                flowHedef.Controls.Add(buton);
            }


        }

        private void YeniDonemEkle(object sender, EventArgs e)
        {
            SimpleButton butonDonem = (SimpleButton)sender;
            FrmDonemSec form = new FrmDonemSec();
            form.ShowDialog();
            if (!String.IsNullOrEmpty(form.donem))
            {
          
                if (!dbList.Contains("NetSatis" + form.donem))
                {
                    dbList.Add("NetSatis" + form.donem);
                    CheckButton buton = new CheckButton
                    {
                        Name = "NetSatis" + form.donem,
                        Text = form.donem,
                        GroupIndex = 2,
                        ImageList = ımageList1,
                        ImageToTextAlignment = ImageAlignToText.TopCenter,
                        ImageIndex = 0,
                        Height = 100,
                        Width = 100
                    };
                    buton.Click += HedefSec;
                    flowHedef.Controls.Add(buton);
                    connHedef.DataSource = "(localdb)\\v11.0";
                    connHedef.InitialCatalog = "NetSatis" + buton.Text;connHedef.IntegratedSecurity = true;
                    hedefContext = new NetSatisContext(connHedef.ConnectionString);
                    CreateDatabaseTool dbtool=new CreateDatabaseTool(hedefContext,form);
                    dbtool.DatabaseOlustur();
                }
                else
                {
                    MessageBox.Show("Seçtiğiniz dönem zaten oluşturulmuş");
                }

            }

        }

        private void HedefSec(object sender, EventArgs e)
        {
            CheckButton buton = (CheckButton)sender;
            connHedef.DataSource = "(localdb)\\v11.0";
            connHedef.InitialCatalog = "NetSatis" + buton.Text;
            connHedef.IntegratedSecurity = true;
            seciliHedef = buton.Text;
            hedefContext = new NetSatisContext(connHedef.ConnectionString);
        }

        private void toggleStokAktar_Toggled(object sender, EventArgs e)
        {
            if (toggleStokAktar.IsOn)
            {
                toggleStokHareketAktar.Enabled = true;
                toggleStokGirisCikisAktar.Enabled = true;
                toggleIndirimAktar.Enabled = true;
                toggleHizliSatisAktar.Enabled = true;
            }
            else
            {
                toggleStokHareketAktar.Enabled = false;
                toggleStokGirisCikisAktar.Enabled = false;
                toggleIndirimAktar.Enabled = false;
                toggleHizliSatisAktar.Enabled = false;
            }
        }

        private void toggleCariAktar_Toggled(object sender, EventArgs e)
        {
            if (toggleCariAktar.IsOn)
            {
                toggleCariBakiyeAktar.Enabled = true;
                toggleCariBorcAlacakAktar.Enabled = true;
            }
            else
            {
                toggleCariBakiyeAktar.Enabled = false;
                toggleCariBorcAlacakAktar.Enabled = false;
            }
        }

        private void toggleKasaAktar_Toggled(object sender, EventArgs e)
        {
            if (toggleKasaAktar.IsOn)
            {
                lookUpKasa.Enabled = true;
            }
            else
            {
                lookUpKasa.Enabled = false;
            }
        }

        private void toggleDepoAktar_Toggled(object sender, EventArgs e)
        {
            if (toggleDepoAktar.IsOn)
            {
                lookupDepo.Enabled = true;
            }
            else
            {
                lookupDepo.Enabled = false;
            }
        }

        private void toggleOdemeTuruAktar_Toggled(object sender, EventArgs e)
        {
            if (toggleOdemeTuruAktar.IsOn)
            {
                lookUpOdemeTuru.Enabled = true;
            }
            else
            {
                lookUpOdemeTuru.Enabled = false;
            }
        }

        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            DevirYap();
        }



        private void DevirYap()
        {
            Kasa YeniKasa = new Kasa();
            Depo YeniDepo = new Depo();
            OdemeTuru YeniOdemeTuru = new OdemeTuru();
            //Kasa Aktarımı
            if (toggleKasaAktar.IsOn)
            {
                foreach (var item in kaynakContext.Kasalar.AsNoTracking().ToList())
                {
                    hedefContext.Kasalar.Add(item);
                }
            }
            else
            {
                YeniKasa.KasaKodu = "01";
                YeniKasa.KasaAdi = "Merkez Kasa";
                hedefContext.Kasalar.Add(YeniKasa);
            }

            //Depo Aktarımı
            if (toggleDepoAktar.IsOn)
            {
                foreach (var item in kaynakContext.Depolar.AsNoTracking().ToList())
                {
                    hedefContext.Depolar.Add(item);
                }
            }
            else
            {

                YeniDepo.DepoKodu = "01";
                YeniDepo.DepoAdi = "Merkez Depo";
                hedefContext.Depolar.Add(YeniDepo);
            }

            //Depo Aktarımı
            if (toggleOdemeTuruAktar.IsOn)
            {
                foreach (var item in kaynakContext.OdemeTurleri.AsNoTracking().ToList())
                {
                    hedefContext.OdemeTurleri.Add(item);
                }
            }
            else
            {

                YeniOdemeTuru.OdemeTuruKodu = "01";
                YeniOdemeTuru.OdemeTuruAdi = "Nakit";
                hedefContext.OdemeTurleri.Add(YeniOdemeTuru);
            }

            hedefContext.SaveChanges();
            //Tanım Aktarımı
            if (toggleTanimAktar.IsOn)
            {
                foreach (var item in kaynakContext.Tanimlar.AsNoTracking().ToList())
                {
                    hedefContext.Tanimlar.Add(item);
                }
            }

            //Kod Aktarımı
            if (toggleKodAktar.IsOn)
            {
                foreach (var item in kaynakContext.Kodlar.AsNoTracking().ToList())
                {
                    hedefContext.Kodlar.Add(item);
                }
            }

            //Ajanda Aktarımı
            if (toggleAjandaAktar.IsOn)
            {
                foreach (var item in kaynakContext.EFAppointments.AsNoTracking().ToList())
                {
                    hedefContext.EFAppointments.Add(item);
                }

                foreach (var item in kaynakContext.EFResources.AsNoTracking().ToList())
                {
                    hedefContext.EFResources.Add(item);
                }
            }

            //Kullanıcı Aktarımı
            if (toggleKullaniciAktar.IsOn)
            {
                foreach (var item in kaynakContext.Kullanicilar.AsNoTracking().ToList())
                {
                    hedefContext.Kullanicilar.Add(item);
                }

                foreach (var item in kaynakContext.KullaniciRolleri.AsNoTracking().ToList())
                {
                    hedefContext.KullaniciRolleri.Add(item);
                }
            }

            //Stok Aktarımı
            if (toggleStokAktar.IsOn)
            {
                StokDAL stokdal = new StokDAL();

                //İndirim Aktarımı
                if (toggleIndirimAktar.IsOn)
                {
                    foreach (var item in kaynakContext.Indirimler.AsNoTracking().ToList())
                    {
                        hedefContext.Indirimler.Add(item);
                    }
                }

                //Hızlı Satış Aktarımı
                if (toggleHizliSatisAktar.IsOn)
                {
                    foreach (var item in kaynakContext.HizliSatisGruplari.AsNoTracking().ToList())
                    {
                        hedefContext.HizliSatisGruplari.Add(item);
                    }

                    foreach (var item in kaynakContext.HizliSatislar.AsNoTracking().ToList())
                    {
                        hedefContext.HizliSatislar.Add(item);
                    }
                }

                foreach (var item in kaynakContext.Stoklar.AsNoTracking().ToList())
                {

                    hedefContext.Stoklar.Add(item);
                    if (toggleStokHareketAktar.IsOn && toggleStokGirisCikisAktar.IsOn)
                    {
                        StokBakiye bakiye = stokdal.StokBakiyesi(kaynakContext, item.StokKodu);
                        if (bakiye.MevcutStok != 0)
                        {
                            Fis stokDevir = new Fis();
                            stokDevir.FisTuru = "Stok Devir Fişi";
                            stokDevir.FisKodu = kodOlustur.YeniFisOdemeKoduOlustur();
                            stokDevir.Tarih = DateTime.Now;
                            stokDevir.ToplamTutar = Math.Abs(bakiye.MevcutStok) * item.AlisFiyati1;
                            hedefContext.Fisler.Add(stokDevir);
                            StokHareket hareket = new StokHareket();
                            hareket.StokKodu = item.StokKodu;
                            hareket.Hareket = bakiye.MevcutStok < 0 ? "Stok Çıkış" : "Stok Giriş";
                            hareket.Miktar = Math.Abs(bakiye.MevcutStok);
                            hareket.FisKodu = stokDevir.FisKodu;
                            hareket.BirimFiyati = item.AlisFiyati1;
                            hareket.Kdv = item.AlisKdv;
                            hareket.Tarih = DateTime.Now;
                            hareket.DepoId = toggleDepoAktar.IsOn ? Convert.ToInt32(lookupDepo.EditValue) : YeniDepo.Id;
                            hedefContext.StokHareketleri.Add(hareket);
                        }
                    }
                    else
                    {
                        StokBakiye bakiye = stokdal.StokBakiyesi(kaynakContext, item.StokKodu);
                        if (bakiye.MevcutStok != 0)
                        {
                            //Stok Giriş
                            Fis stokDevir = new Fis();
                            StokHareket hareketGiris = new StokHareket();


                            stokDevir.FisTuru = "Stok Devir Fişi";
                            stokDevir.FisKodu = kodOlustur.YeniFisOdemeKoduOlustur();
                            stokDevir.Tarih = DateTime.Now;
                            stokDevir.ToplamTutar = bakiye.StokGiris * item.AlisFiyati1;


                            hareketGiris.StokKodu = item.StokKodu;
                            hareketGiris.Hareket = "Stok Giriş";
                            hareketGiris.Miktar = bakiye.StokGiris;
                            hareketGiris.FisKodu = stokDevir.FisKodu;
                            hareketGiris.BirimFiyati = item.AlisFiyati1;
                            hareketGiris.Kdv = item.AlisKdv;
                            hareketGiris.Tarih = DateTime.Now;
                            hareketGiris.DepoId =
                                toggleDepoAktar.IsOn ? Convert.ToInt32(lookupDepo.EditValue) : YeniDepo.Id;
                            if (bakiye.StokGiris > 0)
                            {
                                hedefContext.Fisler.Add(stokDevir);
                                hedefContext.StokHareketleri.Add(hareketGiris);
                            }

                            //Stok Çıkış
                            if (bakiye.StokCikis > 0)
                            {
                                Fis stokCikisDevir = stokDevir.Clone();
                                stokCikisDevir.FisKodu = kodOlustur.YeniFisOdemeKoduOlustur();
                                stokCikisDevir.ToplamTutar = bakiye.StokCikis * item.AlisFiyati1;
                                hedefContext.Fisler.Add(stokCikisDevir);
                                StokHareket hareketCikis = hareketGiris.Clone();
                                hareketCikis.FisKodu = stokCikisDevir.FisKodu;
                                hareketCikis.Hareket = "Stok Çıkış";
                                hareketCikis.Miktar = bakiye.StokCikis;
                                hedefContext.StokHareketleri.Add(hareketCikis);
                            }


                        }
                    }
                }
            }

            //Cari Aktar
            if (toggleCariAktar.IsOn)
            {
                foreach (var item in kaynakContext.Cariler.AsNoTracking().ToList())
                {
                    hedefContext.Cariler.Add(item);
                    CariDAL cariDal = new CariDAL();
                    CariBakiye bakiye = cariDal.CariBakiyesi(kaynakContext, item.CariKodu);
                    if (toggleCariBakiyeAktar.IsOn && toggleCariBorcAlacakAktar.IsOn)
                    {

                        if (bakiye.Bakiye != 0)
                        {
                            Fis cariDevir = new Fis();
                            cariDevir.CariKodu = item.CariKodu;
                            cariDevir.FisTuru = "Cari Devir Fişi";
                            cariDevir.Tarih = DateTime.Now;
                            cariDevir.FisKodu = kodOlustur.YeniFisOdemeKoduOlustur();
                            cariDevir.ToplamTutar = Math.Abs(bakiye.Bakiye);
                            if (bakiye.Bakiye < 0)
                            {
                                cariDevir.Borc = Math.Abs(bakiye.Bakiye);
                                cariDevir.Alacak = null;
                                hedefContext.Fisler.Add(cariDevir);
                                KasaHareket kasaBorc = new KasaHareket();
                                kasaBorc.FisKodu = cariDevir.FisKodu;
                                kasaBorc.CariKodu = item.CariKodu;
                                kasaBorc.Hareket = "Kasa Çıkış";
                                kasaBorc.KasaId = toggleKasaAktar.IsOn
                                    ? Convert.ToInt32(lookUpKasa.EditValue)
                                    : YeniKasa.Id;
                                kasaBorc.OdemeTuruId = toggleOdemeTuruAktar.IsOn
                                    ? Convert.ToInt32(lookUpOdemeTuru.EditValue)
                                    : YeniOdemeTuru.Id;
                                kasaBorc.Tarih = DateTime.Now;
                                kasaBorc.Tutar = Math.Abs(bakiye.Bakiye);
                                hedefContext.KasaHareketleri.Add(kasaBorc);
                            }
                            else
                            {
                                cariDevir.Alacak = Math.Abs(bakiye.Bakiye);
                                cariDevir.Borc = null;
                                hedefContext.Fisler.Add(cariDevir);
                                KasaHareket kasaAlacak = new KasaHareket();
                                kasaAlacak.FisKodu = cariDevir.FisKodu;
                                kasaAlacak.CariKodu = item.CariKodu;
                                kasaAlacak.Hareket = "Kasa Giriş";
                                kasaAlacak.KasaId = toggleKasaAktar.IsOn
                                    ? Convert.ToInt32(lookUpKasa.EditValue)
                                    : YeniKasa.Id;
                                kasaAlacak.OdemeTuruId = toggleOdemeTuruAktar.IsOn
                                    ? Convert.ToInt32(lookUpOdemeTuru.EditValue)
                                    : YeniOdemeTuru.Id;
                                kasaAlacak.Tarih = DateTime.Now;
                                kasaAlacak.Tutar = Math.Abs(bakiye.Bakiye);
                                hedefContext.KasaHareketleri.Add(kasaAlacak);
                            }

                        }
                    }
                    else if (toggleCariBakiyeAktar.IsOn && !toggleCariBorcAlacakAktar.IsOn)
                    {
                        if (bakiye.Alacak != 0)
                        {
                            Fis alacakFis = new Fis();
                            alacakFis.CariKodu = item.CariKodu;
                            alacakFis.FisTuru = "Cari Devir Fişi";
                            alacakFis.Tarih = DateTime.Now;
                            alacakFis.FisKodu = kodOlustur.YeniFisOdemeKoduOlustur();
                            alacakFis.Borc = null;
                            alacakFis.Alacak = bakiye.Alacak;
                            alacakFis.ToplamTutar = bakiye.Alacak;
                            hedefContext.Fisler.Add(alacakFis);

                            KasaHareket kasaAlacak = new KasaHareket();
                            kasaAlacak.FisKodu = alacakFis.FisKodu;
                            kasaAlacak.CariKodu = item.CariKodu;
                            kasaAlacak.Hareket = "Kasa Giriş";
                            kasaAlacak.KasaId =
                                toggleKasaAktar.IsOn ? Convert.ToInt32(lookUpKasa.EditValue) : YeniKasa.Id;
                            kasaAlacak.OdemeTuruId = toggleOdemeTuruAktar.IsOn
                                ? Convert.ToInt32(lookUpOdemeTuru.EditValue)
                                : YeniOdemeTuru.Id;
                            kasaAlacak.Tarih = DateTime.Now;
                            kasaAlacak.Tutar = Math.Abs(bakiye.Alacak);
                            hedefContext.KasaHareketleri.Add(kasaAlacak);
                        }

                        if (bakiye.Borc != 0)
                        {
                            Fis borcFis = new Fis();
                            borcFis.CariKodu = item.CariKodu;
                            borcFis.FisTuru = "Cari Devir Fişi";
                            borcFis.Tarih = DateTime.Now;
                            borcFis.FisKodu = kodOlustur.YeniFisOdemeKoduOlustur();
                            borcFis.Borc = bakiye.Borc;
                            borcFis.Alacak = null;
                            borcFis.ToplamTutar = bakiye.Alacak;
                            hedefContext.Fisler.Add(borcFis);

                            KasaHareket kasaBorc = new KasaHareket();
                            kasaBorc.FisKodu = borcFis.FisKodu;
                            kasaBorc.CariKodu = item.CariKodu;
                            kasaBorc.Hareket = "Kasa Çıkış";
                            kasaBorc.KasaId =
                                toggleKasaAktar.IsOn ? Convert.ToInt32(lookUpKasa.EditValue) : YeniKasa.Id;
                            kasaBorc.OdemeTuruId = toggleOdemeTuruAktar.IsOn
                                ? Convert.ToInt32(lookUpOdemeTuru.EditValue)
                                : YeniOdemeTuru.Id;
                            kasaBorc.Tarih = DateTime.Now;
                            kasaBorc.Tutar = Math.Abs(bakiye.Alacak);
                            hedefContext.KasaHareketleri.Add(kasaBorc);
                        }
                    }
                }
            }

            if (togglePersonelAktar.IsOn)
            {
                foreach (var item in kaynakContext.Personeller.AsNoTracking().ToList())
                {
                    hedefContext.Personeller.Add(item);
                }
            }

            hedefContext.SaveChanges();
        }

        private void wizardControl1_SelectedPageChanging(object sender,
            DevExpress.XtraWizard.WizardPageChangingEventArgs e)
        {
            if (e.Page == wizardHedef && e.Direction == Direction.Forward)
            {
                lookupDepo.Properties.DataSource = kaynakContext.Depolar.AsNoTracking().ToList();
                lookUpKasa.Properties.DataSource = kaynakContext.Kasalar.AsNoTracking().ToList();
                lookUpOdemeTuru.Properties.DataSource = kaynakContext.OdemeTurleri.AsNoTracking().ToList();

            }if (e.Page==wizardHedef && e.Direction==Direction.Forward)
            {
                if (String.IsNullOrEmpty(seciliKaynak))
                {
                    MessageBox.Show("Lütfen bir kaynak veritabanı seçin.");
                    e.Cancel = true;
                }
            }
            if (e.Page == wizardAyar && e.Direction == Direction.Forward)
            {
                if (String.IsNullOrEmpty(seciliHedef))
                {
                    MessageBox.Show("Lütfen bir hedef veritabanı seçin.");
                    e.Cancel = true;
                }
            }
        }

    }
}