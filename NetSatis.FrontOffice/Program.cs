using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

namespace NetSatis.FrontOffice
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture =
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle(Entities.Tools.SettingsTool.AyarOku(Entities.Tools.SettingsTool.Ayarlar.SatisAyarlari_KullaniciTema)); 
          //  UserLookAndFeel.Default.SetSkinStyle("DevExpress Dark Style");
            Application.Run(new FrmFrontOffice());
          // Application.Run(new Rapor.AltSorgular.SatisRaporuikiTarihArasi());
        }
    }
}
