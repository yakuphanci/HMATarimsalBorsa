using System;
using System.Windows.Forms;

namespace HMATarimsalBorsa
{
    public partial class Form_BakiyeIslem : Form
    {
        #region Form Create && aktif kullanıcı tutucu
        Kullanici g_aktifKullanici;
        public Form_BakiyeIslem(Kullanici aktifKullanici)
        {
            InitializeComponent();
            this.g_aktifKullanici = aktifKullanici;
            kullanilabilirKurlariYukle();
        }
        #endregion


        private void kullanilabilirKurlariYukle()
        {
            comboBox_dovizKuru.Items.Clear();
            foreach (var kur in DovizKurlari.KullanilabilirKurlar)
            {
                comboBox_dovizKuru.Items.Add(kur.DovizKodu());
            }
            comboBox_dovizKuru.SelectedIndex = 0;
        }

        /// <summary>
        /// Yeni bir bakiye işlemi nesnesi oluşturur.
        /// </summary>
        /// <param name="miktar">İşlem miktarı</param>
        /// <param name="islem">Ekleme(+) ya da Çekme(-) işlemini belirten parametre.</param>
        /// <returns>Yeni oluşturulan BakiyeIslemObject türündeki bakiyeIslemi döndürür.</returns>
        BakiyeIslemObject GetNewBakiyeKontrol(double miktar, short islem, string kurKodu)
        {
            //yeni işlem oluştur.
            var yeniBakiyeIslem = new BakiyeIslemObject();
            //yeni işlem bilgileri doldur.
            yeniBakiyeIslem.ID = BenzersizIDOlusturucu.GetBakiyeIslemID();
            yeniBakiyeIslem.kullaniciAdi = this.g_aktifKullanici.KullaniciAdi;
            yeniBakiyeIslem.islemTarihi = DateTime.Now;
            yeniBakiyeIslem.aciklama = (islem == +1) ? BakiyeIslemStatics.stdAciklama.Ekleme : BakiyeIslemStatics.stdAciklama.Cekme;
            yeniBakiyeIslem.degisiklikMiktari = (miktar * islem);
            yeniBakiyeIslem.dovizKuru = kurKodu;
            return yeniBakiyeIslem;
        }


        /// <summary>
        /// yeni bakiye işlemi oluşturma gerçekleştirilir ve diğer bakiye işlemlerine ekleme yapılır.
        /// </summary>
        void Save_yeniBakiyeIslemi(double miktar, short islem, string kurKodu)
        {
            var bakiyeIslemler = Veriler.GetBakiyeIslemleri();
            var yeniBakiyeIslem = GetNewBakiyeKontrol(miktar, islem, kurKodu);

            bakiyeIslemler.Add(yeniBakiyeIslem);
            Veriler.SaveData(bakiyeIslemler);
        }

      
        #region EKLEME ve CIKARMA  fonksiyonlari
        //Bakiye ekleme işlemi.
        void BakiyeEkle(double miktar)
        {
            var kurKodu = comboBox_dovizKuru.SelectedItem.ToString();
            Save_yeniBakiyeIslemi(miktar, +1, kurKodu);
        }
       

        //Bakiyeden çekme işlemi.
        void BakiyedenCek(double miktar)
        {
            var kurKodu = comboBox_dovizKuru.SelectedItem.ToString();
            Save_yeniBakiyeIslemi(miktar, -1, kurKodu);
        }
        #endregion

       
        #region validasyon islemleri

        /// <summary>
        /// STRING türündeki veriyi DOUBLE türüne çevirmeyi dener.
        /// </summary>
        /// <param name="text">DOUBLE türüne çevrilecek string</param>
        /// <param name="dValue">DOUBLE türüne çevrilmiş verinin yazılacağı konum.</param>
        /// <returns>Çevirme başarılı bir şekilde gerçekleştirye TRUE gerçekleşmediyse FALSE olur.</returns>
        bool valid_double(string text, out double dValue)
        {
            /// virgül yerine nokta ile ayırdıysa küsüratı virgüle çeviriyoruz.
            text = text.Replace('.', ',');

            /// double türüne çevirmeye çalışıyoruz çevirebilirse TRUE döndürüyoruz.
            /// çevrilemezse FALSE döndürüyoruz.

            if (Double.TryParse(text, out dValue))
                return true;
            else
                return false;
        }


        //TextBoxdaki verinin DOUBBLE türüne çevirilebilir bir veri olup olmadığını sorgular.
        //Ve gerekli uyarıyı verir.
        bool valid_IslemClick(out double miktar)
        {
            if (!valid_double(textBox_bakiyeIslemMiktari.Text, out miktar))
            {
                Mesajlar.UyariMesaji(
                    "Geçersiz bir miktar girdiniz. Lütfen harf yazıp yazmadığınızı ve fazladan ayraç kullanmadığınıza dikkat ediniz."
                    , "Geçersiz miktar!");
                textBox_bakiyeIslemMiktari.SelectAll();
                textBox_bakiyeIslemMiktari.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        
        #region EKLEME VE ÇEKME Buton işlevler.
        private void button_esklemeIslemi_Click(object sender, EventArgs e)
        {
            double miktar;
            if(valid_IslemClick(out miktar))
            {
                BakiyeEkle(miktar);
                Mesajlar.BilgiMesaji("Bakiye ekleme talebiniz sisteme iletilmiştir.", "Talep iletildi.");
            }
        }


        private void button_cekmeIslemi_Click(object sender, EventArgs e)
        {
            double miktar;
            if (valid_IslemClick(out miktar))
            {
                BakiyedenCek(miktar);
                Mesajlar.BilgiMesaji("Bakiyeden para çekme talebiniz sisteme iletilmiştir.","Talep iletildi.");
            }
        }

        #endregion

        
        #region Onay Bekleyen Bakiye Islemleri Butonu Tıklama Olayı
        private void button_onayBekleyenIslemler_Click(object sender, EventArgs e)
        {
            Form_BekleyenBakiyeIslemleri frm_bekleyenBakiyeIslemleri = new Form_BekleyenBakiyeIslemleri(this.g_aktifKullanici);
            frm_bekleyenBakiyeIslemleri.ShowDialog();
        }
        #endregion

       
        #region Gerceklesen Bakiye Islemleri Butonu Tıklama Olayı
        private void button_islemGecmisi_Click(object sender, EventArgs e)
        {
            Form_BakiyeIslemGecmisi frm_bakiyeIslemGecmisi = new Form_BakiyeIslemGecmisi(this.g_aktifKullanici);
            frm_bakiyeIslemGecmisi.ShowDialog();
        }
        #endregion
    }
}
