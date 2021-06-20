using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMATarimsalBorsa
{
    class AlisIslemleri
    {
        /// <summary>
        /// Alış işleminin toplam maliyeti ve alınabilecek toplam ürün miktarı bilgisini önizler.
        /// </summary>
        /// <param name="aliciID">Alış işlemini yapacak kişi</param>
        /// <param name="kategoriID">Alış işlemi yapılacak ürün ID</param>
        /// <param name="istenenMiktar">Ne miktarda alış yapılmak isteniyor</param>
        /// <param name="toplamMaliyet">Tüm bu ürünleri alabilmek için toplam maliyet hesabı döndürür.</param>
        /// <param name="maksAlimMiktari">İstediği miktardan maksimum alabileceği kapasiteyi döndürür.</param>
        /// <returns>Sistemde istenen miktarda ürün olup olmadığı bilgisi döndürür.</returns>
        public static bool OnIzleme(string aliciID, uint kategoriID, int istenenMiktar, out double toplamMaliyet, out int maksAlimMiktari, out double kesilenKomisyon)
        {
            var alinabilirUrunler = Veriler.GetUcuzAktifPazarlar(kategoriID);
            toplamMaliyet = 0;
            maksAlimMiktari = 0;
            kesilenKomisyon = 0;

            foreach (var alinabilirUrun in alinabilirUrunler)
            {
                if(alinabilirUrun.saticiID != aliciID)
                {
                    int dusulecekMiktar = 0;

                    //saticidan ne kadar urun alacagimizi hesapliyoruz.
                    if (alinabilirUrun.miktar <= istenenMiktar)
                        dusulecekMiktar = alinabilirUrun.miktar;
                    else
                        dusulecekMiktar = istenenMiktar;

                    //toplam maliyet hesabı için her satıcıdan alınan miktar ve birim fiyatı çarpılıp ekleniyor.
                    toplamMaliyet += dusulecekMiktar * (alinabilirUrun.fiyat);

                    //kesilecek komisyonu hesapladık
                    kesilenKomisyon = toplamMaliyet / 100;
                    //kesilecek komisyonu toplam maliyete yansıttık
                    toplamMaliyet += kesilenKomisyon;

                    maksAlimMiktari += dusulecekMiktar;
                    istenenMiktar -= dusulecekMiktar;
                }

                //Eger sistemde istedigimiz miktarda urun varsa TRUE dondur.
                if (istenenMiktar == 0)
                    break;
            }


            //Eger sistemde istenenMiktarda urun bulunmuyorsa FALSE döndür.
            //Eger sistemde istedigimiz miktarda urun varsa TRUE dondur.
            if (istenenMiktar == 0)
                return true;
            else
                return false;
        }
      
      
        /// <summary>
        /// Alıcı ile satıcılar arasındaki alışverişi gerçekler.
        /// </summary>
        /// <param name="aliciID">Alış işlemini yapan kullanıcı adı</param>
        /// <param name="kategoriID">Alış işlemi yapılacak ürün ID si</param>
        /// <param name="istenenMiktar">Ne miktarda ürün alınacagı bilgisi</param>
        /// <returns>İstenen miktarda ürün alıp alınamadığı bilgisini döndürür.</returns>
        public static bool AlisYap(string aliciID, uint kategoriID, int istenenMiktar)
        {
            
            var tumPazarlar = Veriler.GetSatilanUrunler();
            var alinabilirUrunler = Veriler.GetUcuzAktifPazarlar(kategoriID,tumPazarlar);

            double aliciyaYansiyanToplamBedel = 0;

            foreach (var alinabilirUrun in alinabilirUrunler)
            {
                if(alinabilirUrun.saticiID != aliciID)
                {
                    int dusulecekMiktar = 0;
                    double devredilecekBakiye = 0;
                    //saticidan ne kadar urun alacagimizi hesapliyoruz.
                    if (alinabilirUrun.miktar <= istenenMiktar)
                        dusulecekMiktar = alinabilirUrun.miktar;
                    else
                        dusulecekMiktar = istenenMiktar;

                    istenenMiktar -= dusulecekMiktar;
                    devredilecekBakiye = alinabilirUrun.fiyat * dusulecekMiktar;

                    //alıcıya yansıyan toplam maliyet hesabı.
                    aliciyaYansiyanToplamBedel += devredilecekBakiye;

                    //saticinin pazarindan miktari dustuk.
                    alinabilirUrun.miktar -= dusulecekMiktar;

                    //Alıcı ile satıcı arasındaki swap işlemi gerçekleşti.
                    Satis_Swap(aliciID, alinabilirUrun.saticiID, alinabilirUrun.urun.Adi, dusulecekMiktar, alinabilirUrun.fiyat);
                }

                //Eğer bir pazardaki tüm ürünler tamamen satıldıysa, o pazarı sistemden kaldır.
                if(alinabilirUrun.miktar == 0)
                {
                    tumPazarlar.Remove(alinabilirUrun);
                }

                if (istenenMiktar == 0)
                    break;
            }

            //Degisikligi kaydettik.
            Veriler.SaveData(tumPazarlar);

            //Eger sistemde istenenMiktarda urun bulunmuyorsa FALSE döndür.
            //Eger sistemde istedigimiz miktarda urun varsa TRUE dondur.
            if (istenenMiktar == 0)
                return true;
            else
                return false;
        }



        #region Bakiye Islem Kayit Olayi
        private static void Save_yeniBakiyeIslemi(BakiyeIslemObject yeniBakiyeIslem)
        {
            var bakiyeIslemler = Veriler.GetBakiyeIslemleri();
            bakiyeIslemler.Add(yeniBakiyeIslem);
            Veriler.SaveData(bakiyeIslemler);
        }
        #endregion


        #region SATIS ve ALIS fonksiyonlari

        //Temel Islem Nesnesi Olusturma
        private static BakiyeIslemObject CreateBakiyeIslemObject(string ilgiliKullanici)
        {
            //yeni işlem oluştur.
            var yeniBakiyeIslem = new BakiyeIslemObject();

            //yeni işlem bilgileri doldur.
            yeniBakiyeIslem.ID = BenzersizIDOlusturucu.GetBakiyeIslemID();
            yeniBakiyeIslem.kullaniciAdi = ilgiliKullanici;
            yeniBakiyeIslem.islemTarihi = DateTime.Now;
            yeniBakiyeIslem.dovizKuru = "TRY";

            //Alis, Satis ve Komisyon islemleri admin onayina bagli olmadan gerçekleşir.
            yeniBakiyeIslem.incelendiMi = true;
            yeniBakiyeIslem.IslemiIsle(true);

            return yeniBakiyeIslem;
        }

        //Temel Islem Nesnesini Satis Islemi Olarak biçimlendirme
        private static BakiyeIslemObject Get_SatisIslemi(string ilgiliKullanici, string urunAdi, int urunMiktar, double birimFiyat)
        {
            var bakiyeIslemNesnesi = CreateBakiyeIslemObject(ilgiliKullanici);
            bakiyeIslemNesnesi.degisiklikMiktari = (birimFiyat * urunMiktar * +1);
            bakiyeIslemNesnesi.aciklama = BakiyeIslemStatics.stdAciklama.Satis + " - " + urunAdi + " (" + urunMiktar + "kg x " + birimFiyat + " TRY)";

            return bakiyeIslemNesnesi;
        }

        //Temel Islem Nesnesini Alis Islemi Olarak biçimlendirme
        private static BakiyeIslemObject Get_AlisIslemi(string ilgiliKullanici, string urunAdi, int urunMiktar, double birimFiyat)
        {
            var bakiyeIslemNesnesi = CreateBakiyeIslemObject(ilgiliKullanici);
            bakiyeIslemNesnesi.degisiklikMiktari = (birimFiyat * urunMiktar * -1);
            bakiyeIslemNesnesi.aciklama = BakiyeIslemStatics.stdAciklama.Alis + " - " + urunAdi + " (" + urunMiktar + "kg x " + birimFiyat + " TRY)";

            return bakiyeIslemNesnesi;
        }

        //Temel Islem Nesnesini Komisyon Kesintisi Islemi Olarak biçimlendirme
        private static BakiyeIslemObject Get_KomisyonKesintisi(string ilgiliKullanici, double kesinti)
        {
            var bakiyeIslemNesnesi = CreateBakiyeIslemObject(ilgiliKullanici);
            bakiyeIslemNesnesi.degisiklikMiktari = (kesinti * -1);
            bakiyeIslemNesnesi.aciklama = BakiyeIslemStatics.stdAciklama.Komisyon;

            return bakiyeIslemNesnesi;
        }

        //Verilerde degisiklik islemini gerçekleştirir.
        private static void Satis_Swap(string aliciID, string saticiID, string urunAdi, int urunMiktar, double birimFiyat)
        {
            Save_yeniBakiyeIslemi(Get_SatisIslemi(saticiID, urunAdi, urunMiktar, birimFiyat));
            Save_yeniBakiyeIslemi(Get_AlisIslemi(aliciID, urunAdi, urunMiktar, birimFiyat));
            KomisyonKes(aliciID, (urunMiktar * birimFiyat));
        }

        #endregion


        #region Komisyon Kesme Islemi
        private static void KomisyonKes(string alici, double toplamIslemBedeli)
        {
            //Alicinin yaptıgı islem hacminden %1lik komisyon hesaplandi
            double kesilecekKomisyon = toplamIslemBedeli / 100;

            //Alicinin komisyonu alicinin bakiyesinden cikartildi.
            Save_yeniBakiyeIslemi(Get_KomisyonKesintisi(alici, kesilecekKomisyon));

            //kesilen komisyon kasaya eklendi.
            KasaKontrol kasaController = new KasaKontrol();
            kasaController.BakiyeEkle(kesilecekKomisyon);
        }
        #endregion


    }
}
