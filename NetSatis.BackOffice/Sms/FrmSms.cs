using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.DashboardWin.Design;
using DevExpress.XtraEditors;
using NetSatis.Entities.Context;
using NetSatis.Entities.Data_Access;
using NetSatis.Entities.Tools;

namespace NetSatis.BackOffice.Sms
{
    public partial class FrmSms : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        CariDAL cariDal = new CariDAL();
        List<Entities.Tables.Cari> cariList = new List<Entities.Tables.Cari>();
        public FrmSms()
        {
            InitializeComponent();
            gridControl1.DataSource = cariDal.CariTelefonlari(context);
            gridControl2.DataSource = cariList;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(colListeCepTelefonu) != null)
            {
                cariList.Add(new Entities.Tables.Cari
                {
                    CariKodu = gridView1.GetFocusedRowCellValue(colListeCariKodu).ToString(),
                    CariAdi = gridView1.GetFocusedRowCellValue(colListeCariAdi).ToString(),
                    CepTelefonu = gridView1.GetFocusedRowCellValue(colListeCepTelefonu).ToString()
                }); gridView2.RefreshData();
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView2.DeleteSelectedRows();
        }
        private void memoEdit1_TextChanged(object sender, EventArgs e)
        {
            lblKarakterSayisi.Text = "Karakter Sayısı : " + txtMesaj.Text.Length + "\\" + (txtMesaj.Text.Length / 160 + 1);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string gonderilecekNumaralar = null;

            for (int i = 0; i < gridView2.RowCount; i++)
            {
                gonderilecekNumaralar += "<no>"+ gridView2.GetRowCellValue(i, colCepTelefonu).ToString() + "</no>";
            }
            gonderilecekNumaralar = gonderilecekNumaralar.Substring(0, gonderilecekNumaralar.Length - 1);

            string GonderilecekVeri;
            GonderilecekVeri = "<SMS>";
            GonderilecekVeri += "<oturum>";
            GonderilecekVeri += $"<kullanici>{txtKullaniciAdi.Text}</kullanici>";
            GonderilecekVeri += $"<sifre>{txtParola.Text}</sifre>";
            GonderilecekVeri += "</oturum>";
            GonderilecekVeri += "<mesaj>";
            GonderilecekVeri += "<baslik>ERHANGUVEN</baslik>";
            GonderilecekVeri += $"<metin>{txtMesaj.Text}</metin>";
            GonderilecekVeri += $"<alicilar>{gonderilecekNumaralar}</alicilar>";
            GonderilecekVeri += "</mesaj>";
            GonderilecekVeri += "< karaliste>kendi</karaliste>";
            GonderilecekVeri += $"<izin_link>{toggleLink.IsOn}</izin_link>";
            GonderilecekVeri += $"< izin_telefon>{toggleTelefon.IsOn}</izin_telefon>";
            GonderilecekVeri += "</ SMS>";

            string gonderilecekAdres;
            if (toggleSmsTuru.IsOn)
            {
                gonderilecekAdres = "http://dakiksms.com/api/tr/xml_api.php";
            }
            else
            {
                gonderilecekAdres = "http://dakiksms.com/api/xml_api.php";
            }

            MessageBox.Show(MesajGonder(gonderilecekAdres, GonderilecekVeri));

        }

        private string MesajGonder(string GonderilecekAdres, string Mesaj)
        {

            WebClient dosyaGonder = new WebClient();
            byte[] gonderilenVeri = Encoding.ASCII.GetBytes(Mesaj);
            byte[] gelenVeri = dosyaGonder.UploadData(GonderilecekAdres, "POST", gonderilenVeri);
            string cevap = Encoding.ASCII.GetString(gelenVeri);
            return cevap;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string GonderilecekVeri;
            GonderilecekVeri = "<RAPOR>";
            GonderilecekVeri += "<oturum>";
            GonderilecekVeri += $"<kullanici>{txtKullaniciAdi.Text}</kullanici>";
            GonderilecekVeri += $"<sifre>{txtParola.Text}</sifre>";
            GonderilecekVeri += "</oturum>";GonderilecekVeri += "</RAPOR>";
            char[] karakter = { '(', ')' };
            string[] GelenVeri = MesajGonder("http://www.dakiksms.com/api/xml_bakiye.php", GonderilecekVeri)
                .Split(karakter);

            MessageBox.Show(GelenVeri[3]);
        }
        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SettingsTool.AyarOku(SettingsTool.Ayarlar.SmsAyarları_Parola));
        }
        private void btnKapat_Click(object sender, EventArgs e)
        {

        }
  
    }
}