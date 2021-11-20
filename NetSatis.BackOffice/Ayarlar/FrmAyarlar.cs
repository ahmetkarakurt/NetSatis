using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Printing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DevExpress.XtraEditors;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tools;

namespace NetSatis.BackOffice.Ayarlar
{
    public partial class FrmAyarlar : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        DepoDAL depoDal = new DepoDAL();
        KasaDAL kasaDal = new KasaDAL();
        public FrmAyarlar()
        {
            InitializeComponent();
            cmbFaturaYazici.Properties.Items.AddRange(YaziciListesi());
            cmbBilgiFisiYazici.Properties.Items.AddRange(YaziciListesi());
            lookupDepo.Properties.DataSource = depoDal.GetAll(context);
            lookupDepo.EditValue = SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_VarsayilanDepo);
            lookUpKasa.Properties.DataSource = kasaDal.GetAll(context);
            lookUpKasa.EditValue = SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_VarsayilanKasa);
            cmbFaturaAyar.SelectedIndex =
                Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_FaturaYazdirmaAyari));
            cmbFaturaYazici.Text = SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_FaturaYazici);
            cmbBilgiFisiAyar.SelectedIndex =
                Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_BilgiFisiYazdirmaAyari));
            cmbBilgiFisiYazici.Text = SettingsTool.AyarOku(SettingsTool.Ayarlar.SatisAyarlari_BilgiFisiYazici);
            toggleGuncelle.IsOn = Convert.ToBoolean(SettingsTool.AyarOku(SettingsTool.Ayarlar.GenelAyalar_GuncellemeKontrol));
            txtFirmaAdi.Text = SettingsTool.AyarOku(SettingsTool.Ayarlar.FirmaAyarlari_FirmaAdi);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SettingsTool.AyarDegistir(SettingsTool.Ayarlar.SatisAyarlari_FisKodu, calcEdit1.Value.ToString());
            SettingsTool.AyarDegistir(SettingsTool.Ayarlar.SatisAyarlari_FaturaYazici, cmbFaturaYazici.Text);
            SettingsTool.AyarDegistir(SettingsTool.Ayarlar.SatisAyarlari_BilgiFisiYazici, cmbBilgiFisiYazici.Text);
            SettingsTool.AyarDegistir(SettingsTool.Ayarlar.SatisAyarlari_FaturaYazdirmaAyari, cmbFaturaAyar.SelectedIndex.ToString());
            SettingsTool.AyarDegistir(SettingsTool.Ayarlar.SatisAyarlari_BilgiFisiYazdirmaAyari, cmbBilgiFisiAyar.SelectedIndex.ToString());
            SettingsTool.AyarDegistir(SettingsTool.Ayarlar.SatisAyarlari_VarsayilanDepo, lookupDepo.EditValue.ToString());
            SettingsTool.AyarDegistir(SettingsTool.Ayarlar.SatisAyarlari_VarsayilanKasa, lookUpKasa.EditValue.ToString());
            SettingsTool.AyarDegistir(SettingsTool.Ayarlar.GenelAyalar_GuncellemeKontrol, toggleGuncelle.IsOn.ToString());
            SettingsTool.AyarDegistir(SettingsTool.Ayarlar.FirmaAyarlari_FirmaAdi, txtFirmaAdi.Text);
            SettingsTool.Save();
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {

        }

        private List<string> YaziciListesi()
        {
            return new LocalPrintServer().GetPrintQueues().Select(c => c.Name).ToList();
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }
    }
}