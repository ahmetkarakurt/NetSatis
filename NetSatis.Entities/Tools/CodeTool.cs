using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using NetSatis.Entities.Context;
using NetSatis.Entities.Tables;

namespace NetSatis.Entities.Tools
{
    public class CodeTool
    {
        BarManager manager = new BarManager();
        private PopupMenu menu;
        private XtraForm _form;
        private NetSatisContext _context = new NetSatisContext();
        private Table _table;
        public enum Table
        {
            Cari,
            Stok,
            Fis
        }
        public CodeTool(XtraForm form, Table table)
        {
            _form = form;
            _table = table;
            manager.Form = _form;
            menu = new PopupMenu(manager);
        }

        public void BarButonOlustur()
        {
            foreach (var kod in _context.Kodlar.Where(c => c.Tablo == _table.ToString()).ToList())
            {
                if (kod.Tablo == "Fis")
                {
                    if (kod.OnEki != "FO")
                    {
                        BarButtonItem item = new BarButtonItem
                        {
                            Name = "btnKod" + kod.SonDeger,
                            Tag = kod.Id,
                            Caption = KodOlustur(kod.OnEki, kod.SonDeger),
                            ImageOptions = { Image = NetSatis.Entities.Properties.Resources.code }

                        };
                       
                        item.ItemClick += Buton_Click;
                        menu.AddItem(item);
                    }

                }
                else
                {
                    BarButtonItem item = new BarButtonItem
                    {
                        Name = "btnKod" + kod.SonDeger,
                        Tag = kod.Id,
                        Caption = KodOlustur(kod.OnEki, kod.SonDeger),
                        ImageOptions = { Image = NetSatis.Entities.Properties.Resources.code }

                    };

                    item.ItemClick += Buton_Click;
                    menu.AddItem(item);
                }
            }

            BarButtonItem yeniKodEkle = new BarButtonItem
            {
                Name = "btnYeniKodEkle",
                Caption = "Yeni Kod Oluştur",
                ImageOptions = { Image = NetSatis.Entities.Properties.Resources.code_add },
                Appearance = { FontStyleDelta = FontStyle.Bold}
            };
            yeniKodEkle.ItemClick += YeniKodEkle_Click;
            menu.AddItem(yeniKodEkle).BeginGroup = true;

            BarButtonItem guncelle = new BarButtonItem
            {
                Name = "btnGuncelle",
                Caption = "Güncelle",
                ImageOptions = { Image = NetSatis.Entities.Properties.Resources.refresh },
                Appearance = { FontStyleDelta = FontStyle.Bold }
            };
            guncelle.ItemClick += Guncelle_Click;
            menu.AddItem(guncelle);

            DropDownButton buton = (DropDownButton)_form.Controls.Find("btnKod", true).SingleOrDefault();
            buton.MenuManager = manager;
            buton.DropDownControl = menu;
        }

        private void Guncelle_Click(object sender, ItemClickEventArgs e)
        {
            BarButonSil();
            BarButonOlustur();
        }

        private void BarButonSil()
        {
            menu.ItemLinks.Clear();
        }

        private void YeniKodEkle_Click(object sender, ItemClickEventArgs e)
        {
            Type tip = Assembly.Load("NetSatis.BackOffice").GetTypes().SingleOrDefault(c => c.Name == "FrmKodlar");
            XtraForm form = (XtraForm)Activator.CreateInstance(tip, _table.ToString());
            form.ShowDialog();
            BarButonSil();
            BarButonOlustur();
        }

        private void Buton_Click(object sender, ItemClickEventArgs e)
        {
            TextEdit text = (TextEdit)_form.Controls.Find("txtKod", true).SingleOrDefault();
            text.Text = e.Item.Caption;
        }

        public string KodOlustur(string kodOnEki, int kodSonDeger)
        {
            int sifirSayisi = 12 - (kodOnEki.Length + kodSonDeger.ToString().Length);
            string sifirDizisi = new string('0', sifirSayisi);
            return kodOnEki + sifirDizisi + kodSonDeger;
        }
        public string YeniFisOdemeKoduOlustur()
        {
            var kod = _context.Kodlar.SingleOrDefault(c => c.OnEki == "FO" && c.Tablo == "Fis");
            string onEki = kod.OnEki;
            string sonDeger = kod.SonDeger.ToString();
            int sifirSayisi = 12 - (onEki.Length + sonDeger.Length);
            string sifirDizisi = new string('0', sifirSayisi);
            kod.SonDeger++;
            _context.SaveChanges(); return onEki + sifirDizisi + sonDeger;
        }

        public void KodArtirma()
        {
            TextEdit text = (TextEdit)_form.Controls.Find("txtKod", true).SingleOrDefault();
            BarItemLink buton = menu.ItemLinks.SingleOrDefault(c => c.Caption == text.Text);
            if (buton != null)
            {
                int id = Convert.ToInt32(buton.Item.Tag.ToString());
                _context.Kodlar.SingleOrDefault(c => c.Id == id).SonDeger++;
                _context.SaveChanges();
            }
        }

        public string KoduTXTgetir()
        {
            foreach (var kod in _context.Kodlar.Where(c => c.Tablo == _table.ToString()).ToList())
            {
                if (kod.Tablo == "Stok")
                {
                    if (kod.OnEki != "FO")
                    {
                        return KodOlustur(kod.OnEki, kod.SonDeger);

                    }

                }
            }
            return null;
        }
    }
}
