using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMATarimsalBorsa
{
    public partial class Form_BeklemedekiAlisEmirleri : Form
    {
        Kullanici g_aktifKullanici;
        public Form_BeklemedekiAlisEmirleri(Kullanici _aktifKullanici)
        {
            InitializeComponent();
            this.g_aktifKullanici = _aktifKullanici;
            ListeleAlisEmirleri();
        }

        public DataTable GetDataTable()
        {
            //islemlerin tutulacagi data tablosu olusturuldu
            DataTable dataTable = new DataTable();

            //Sutunlar tanımlandı
            dataTable.Columns.Add("Emir Numarası");
            dataTable.Columns.Add("Ürün");
            dataTable.Columns.Add("Alınan Miktar");
            dataTable.Columns.Add("Maks Birim Fiyatı");
            dataTable.Columns.Add("Ayrılan Bütçe");
            

            var alisEmirlerim = Veriler.GetAlisEmirleri(this.g_aktifKullanici.KullaniciAdi);

            foreach (var emir in alisEmirlerim)
            {
                dataTable.Rows.Add(
                    emir.zamanDamgasi_ms,
                    Veriler.GetUrunTuru(emir.urunID).Adi,
                    emir.alinanMiktar + " / " + emir.alisMiktari,
                    emir.alisFiyati,
                    emir.ayrilanButce
                    );
            }


            return dataTable;
        }
        void ListeleAlisEmirleri()
        {
            dataGridView_beklemedekiIslemler.Rows.Clear();
            dataGridView_beklemedekiIslemler.Columns.Clear();
            dataGridView_beklemedekiIslemler.DataSource = GetDataTable();
            dataGridView_beklemedekiIslemler.Refresh();
        }

        private void button_yenile_Click(object sender, EventArgs e)
        {
            ListeleAlisEmirleri();
        }
    }
}
