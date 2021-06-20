using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using HMATarimsalBorsa.RaporlamaNesneleri;

namespace HMATarimsalBorsa
{
    public partial class Form_Rapor : Form
    {
        Kullanici g_aktifKullanici;
        public Form_Rapor(Kullanici aktifKullanici)
        {
            InitializeComponent();
            this.g_aktifKullanici = aktifKullanici;
          
        }


        private void button_filtrele_Click(object sender, EventArgs e)
        {
            DateTime ilkTarih = dateTimePicker_ilkTarih.Value.Date;  // 20.06.2021 00:00
            DateTime sonTarih = dateTimePicker_sonTarih.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);  // 20.06.2021 23:59.59

            RaporOlusturucu raporOlusturucu = new RaporOlusturucu();
            DataTable dataTable = raporOlusturucu.GetDataTable(this.g_aktifKullanici.KullaniciAdi, ilkTarih, sonTarih);
            dataGridView_islemGecmisi.DataSource = dataTable;
            dataGridView_islemGecmisi.Refresh();


        }

        private void button_raporla_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ilkTarih = dateTimePicker_ilkTarih.Value;
                DateTime sonTarih = dateTimePicker_sonTarih.Value;

                RaporOlusturucu raporOlusturucu = new RaporOlusturucu();
                DataTable dataTable = raporOlusturucu.GetDataTable(this.g_aktifKullanici.KullaniciAdi, ilkTarih, sonTarih);


                raporOlusturucu.ExportDataTableToPdf(dataTable, @"Rapor.pdf", "İşlem Geçmişi", ilkTarih,sonTarih);

                Mesajlar.Basarili();
                System.Diagnostics.Process.Start(@"Rapor.pdf");
             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata Mesajı");
            }
        }
    }
}
