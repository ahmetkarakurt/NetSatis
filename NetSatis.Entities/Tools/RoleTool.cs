using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using NetSatis.Entities.Context;
using NetSatis.Entities.Tables;

namespace NetSatis.Entities.Tools
{
    public static class RoleTool
    {
        public static Kullanici KullaniciEntity;
        public static Sube SubeEntity;
        public static void RolleriYukle(XtraForm form)
        {
            NetSatisContext context = new NetSatisContext();
            foreach (var item in context.KullaniciRolleri.Where(c => c.KullaniciAdi == KullaniciEntity.KullaniciAdi && c.FormAdi == form.Name && c.Yetki == false).ToList())
            {
                var bulunan = form.Controls.Find(item.KontrolAdi, true).SingleOrDefault();
                if (bulunan != null)
                {
                    bulunan.Enabled = false;
                }
            }
        }
        public static void RolleriYukle(RibbonControl control)
        {
            NetSatisContext context = new NetSatisContext();
            foreach (var item in context.KullaniciRolleri.Where(c => c.KullaniciAdi == KullaniciEntity.KullaniciAdi && c.FormAdi == "FrmAnaMenu" && c.Yetki == false).ToList())
            {

                var kontroller = control.Items.SingleOrDefault(c => c.Name == item.KontrolAdi);
                if (kontroller != null)
                {
                    kontroller.Visibility = BarItemVisibility.Never;
                }

                RibbonPage bulunan = control.Pages.SingleOrDefault(c => c.Name == item.KontrolAdi);
                if (bulunan != null)
                {
                    bulunan.Visible = false;
                }

            }
        }
        public static void RolleriYukle(TileControl control)
        {
            try
            {
                NetSatisContext context = new NetSatisContext();
                foreach (var item in context.KullaniciRolleri.Where(c => c.KullaniciAdi == KullaniciEntity.KullaniciAdi && c.FormAdi == "FrmAnaMenu" && c.Yetki == false).ToList())
                {
                    control.Groups[item.KontrolAdi.ToString()].Visible = false;
                }
            }
            catch (Exception)
            {

               
            }
        }
    }
}
