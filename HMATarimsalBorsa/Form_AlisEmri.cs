using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HMATarimsalBorsa.AlisEmriNesneleri;
namespace HMATarimsalBorsa
{
    public partial class Form_AlisEmri : Form
    {
        #region Form Create && aktif Kullanici tutucu
        Kullanici g_aktifKullanici;
        public Form_AlisEmri(Kullanici aktifKullanici)
        {
            InitializeComponent();
            this.g_aktifKullanici = aktifKullanici;
            KategoriDoldur();
        }

        #endregion

      

        #region Kategori Doldurma islemi
        /// <summary>
        /// Eklenebilir ürünlerin listesini Form ekranındaki comboBox'a doldurur.
        /// </summary>
        void KategoriDoldur()
        {
            comboBox_kategoriler.Items.Clear();
            //Ekleneblable ürünler çekildi.
            var urunler = Veriler.GetUrunTurleri();

            comboBox_kategoriler.Items.Clear();
            foreach (var urun in urunler)
            {
                comboBox_kategoriler.Items.Add(urun.Adi + " - " + urun.ID);
            }
        }

        #endregion


       
        private void button_onayla_Click(object sender, EventArgs e)
        {
            bool belirliMiktardanAl = checkBox_belirliFiyattanAl.Checked;
            double istenenBelirliFiyat = 0;
            if (this.g_seciliUrun != null && numericUpDown_miktar.Value > 0  || (belirliMiktardanAl && valid_Fiyat(out istenenBelirliFiyat)))
            {
                #region Local Degiskenler
                int istenenMiktar = (int)numericUpDown_miktar.Value; //Arzulanan alım miktarı.
                double toplamMaliyet = 0; //Alış emri gerçekleşirse alıcıya mal olacak toplam bedel.
                double kesilecekKomisyon = 0; //Alış emri gerçekleşirse gerçekleşen işlemden sistemin alıcıdan keseceği komisyon.
                int alinabilecekMaksMiktar = 0; //Alınmak istenen ürün miktarından ne kadarının alınabileceği bilgisi.
                string aliciID = this.g_aktifKullanici.KullaniciAdi;
                uint alinacakUrunID = this.g_seciliUrun.ID;


                #endregion

                //belirli miktardan al aktif değilse en ucuzudan başla almaya.
                if (belirliMiktardanAl == false)
                {

                    #region Alis icin Onizleme bilgileri cek

                    bool yeterliMi =
                        AlisIslemleri.OnIzleme(aliciID, alinacakUrunID, istenenMiktar, out toplamMaliyet, out alinabilecekMaksMiktar, out kesilecekKomisyon);

                    #endregion

                    if (alinabilecekMaksMiktar > 0)
                    {
                        #region Dialog(Maliyet ve miktar bilgisi + onay Suali) 
                        DialogResult alisOnay =
                            MessageBox.Show(
                                   (yeterliMi ? "Yeterli miktarda ürün var.\n" : "Almak istediğin miktarda ürün yok. Alabileceğin tüm miktar ve maliyet:\n") +
                                   "Satabileceğimiz toplam " + this.g_seciliUrun.Adi + " miktarı " + alinabilecekMaksMiktar + "kg\n" +
                                   "Size mâl olacak toplam bedel: " + toplamMaliyet + " TRY (" + kesilecekKomisyon + " TRY komisyon dahil.)\n",
                                   "Onaylyor musunuz?"
                                   , MessageBoxButtons.YesNo
                                   );
                        #endregion

                        if (alisOnay == DialogResult.Yes)
                        {
                            if (toplamMaliyet <= this.g_aktifKullanici.Bakiye)
                            {
                                AlisIslemleri.AlisYap(aliciID, alinacakUrunID, istenenMiktar);
                                Mesajlar.BilgiMesaji(
                                    "Alış işleminiz tamamlandı. Aldığınız ürünleri en kısa sürede sistemde belirttiğiniz adresinize getireceğiz.",
                                    "Tamamlandı.");
                                this.Close();
                            }
                            else
                            {
                                #region Yetersiz Bakiye Uyarisi
                                Mesajlar.UyariMesaji(
                                    "Üzgünüm hesabınızda almak istediğiniz ürünlerin bedelini karşılayacak kadar bakiye bulunmuyor." +
                                    "Eksik bakiye: " + (this.g_aktifKullanici.Bakiye - toplamMaliyet),
                                    "Yetersiz Bakiye!"
                                    );
                                #endregion
                            }
                        }
                    }
                    else
                    {
                        #region Urun yok uyarisi
                        Mesajlar.UyariMesaji(
                            "Üzgünüz. Çünkü size satabileceğimiz " + this.g_seciliUrun.Adi + " ürünümüz yok." +
                            "\nLütfen bizi affedin ve daha sonra tekrar deneyin.",
                            "Ah olamaz!");
                        #endregion
                    }

                }
                else
                {
                    if (valid_Fiyat(out istenenBelirliFiyat))
                    {
                        double ayrilacakButce = Math.Round((istenenMiktar * istenenBelirliFiyat), 2);
                        double maksKesilecekKomisyon = Math.Round((ayrilacakButce / 100), 2);

                        #region Dialog(Maliyet ve miktar bilgisi + onay Suali) 
                        DialogResult alisOnay =
                            MessageBox.Show(
                                   "Verdiğiniz alış emrine göre hesabınızdan " + ayrilacakButce + " + " + maksKesilecekKomisyon + " bütçe ayrılacaktır.\n" +
                                   "Alış emri tamamlandığında ayrılan bütçeden arta kalan hesabınıza geri yatacaktır.\n",
                                   "Onaylyor musunuz?"
                                   , MessageBoxButtons.YesNo
                                   );
                        #endregion

                        if (alisOnay == DialogResult.Yes)
                        {
                            if (this.g_aktifKullanici.Bakiye >= (ayrilacakButce + kesilecekKomisyon))
                            {

                                var alisEmirleri = Veriler.GetAlisEmirleri();
                               
                                #region Alis Emri Nesnesi Olusturma
                                AlisEmri yeniAlisEmri = new AlisEmri();
                                yeniAlisEmri.aliciID = this.g_aktifKullanici.KullaniciAdi;
                                yeniAlisEmri.ayrilanButce = ayrilacakButce + maksKesilecekKomisyon;
                                yeniAlisEmri.alisFiyati = istenenBelirliFiyat;
                                yeniAlisEmri.alisMiktari = istenenMiktar;
                                yeniAlisEmri.urunID = g_seciliUrun.ID;
                                yeniAlisEmri.zamanDamgasi_ms = DateTime.Now.Ticks;
                                #endregion

                                //yeni alış emri isteği eklendi, kaydedildi.
                                alisEmirleri.Add(yeniAlisEmri);
                                Veriler.SaveData(alisEmirleri);

                                //Kullanıcının bakiyesinden ayrılan bütçe düşüldü.
                                var kullanicilar = Veriler.GetKullanicilar();
                                var kullanici = Veriler.GetKullanici(this.g_aktifKullanici.KullaniciAdi, kullanicilar);
                                kullanici.Bakiye -= (ayrilacakButce + kesilecekKomisyon);
                                Veriler.SaveData(kullanicilar);

                                Mesajlar.Basarili();
                                this.Close();

                                AlisEmriKontrol.Tetikle_TumAlisEmirleri();
                            }
                            else
                            {
                                #region Yetersiz Bakiye Uyarisi
                                Mesajlar.UyariMesaji(
                                    "Üzgünüm hesabınızda almak istediğiniz ürünlerin bedelini karşılayacak kadar bakiye bulunmuyor." +
                                    "Eksik bakiye: " + (this.g_aktifKullanici.Bakiye - (ayrilacakButce + kesilecekKomisyon)),
                                    "Yetersiz Bakiye!"
                                    );
                                #endregion
                            }
                        }
                    }
                }
            }
            else
                Mesajlar.UyariMesaji("Lütfen satın almak istediğiniz ürün türünü seçiniz.", "Eksik Bilgi.");
        }




        #region Alınacak urun seçim işlemi

        //Combobox'tan seçilen ürün burda tutulacak.
        Urun g_seciliUrun = null;
        private void comboBox_kategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Comboboxdan seçilen türe göre urun nesnesini oluşturur.
            if (comboBox_kategoriler.SelectedIndex > -1)
            {
                this.g_seciliUrun = new Urun();
                var seciliCmbItem = comboBox_kategoriler.SelectedItem.ToString();
                var splitCmbItem = seciliCmbItem.Split(' ');
                g_seciliUrun.Adi = splitCmbItem[0];
                g_seciliUrun.ID = UInt32.Parse(splitCmbItem[2]);
            }
            else
            {
                this.g_seciliUrun = null;
            }
        }

        #endregion


        bool valid_Fiyat(out double fiyat)
        {
            if (!Double.TryParse(textBox_fiyat.Text, out fiyat))
            {
                //double türüne çevirmeye çalışıyoruz çevrilemezse uyarı veriyoruz.
                Mesajlar.UyariMesaji("Geçersiz bir fiyat girdiniz. Lütfen harf yazıp yazmadığınızı ve fazla ayraç kullanmadığınıza dikkat ediniz.", "Geçersiz fiyat!");
                textBox_fiyat.SelectAll();
                textBox_fiyat.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void checkBox_belirliFiyattanAl_CheckedChanged(object sender, EventArgs e)
        {
            textBox_fiyat.Enabled = ((CheckBox)sender).Checked;
        }

        private void textBox_fiyat_TextChanged(object sender, EventArgs e)
        {
            // virgül yerine nokta ile ayırdıysa küsüratı virgüle çeviriyoruz.
            textBox_fiyat.Text = textBox_fiyat.Text.Replace('.', ',');
            textBox_fiyat.SelectionStart = textBox_fiyat.Text.Length;
            textBox_fiyat.SelectionLength = 0;
        }
    }
}
