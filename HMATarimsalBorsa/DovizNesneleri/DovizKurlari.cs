using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using HMATarimsalBorsa.DovizNesneleri;
using HMATarimsalBorsa.DovizNesneleri.DovizTurleri;

namespace HMATarimsalBorsa
{

    public static class DovizKurlari
    {

        public static List<DovizAbstract> KullanilabilirKurlar = new List<DovizAbstract>()
        {
            new TurkLirasi(),
            new ABDDolari(),
            new RusRublesi(),
            new Euro()
        };


        public static DovizAbstract GetDovizObject(string kod)
        {
            if (kod == "TRY")
                return new TurkLirasi();
            else if (kod == "USD")
                return new ABDDolari();
            else if (kod == "RUB")
                return new RusRublesi();
            else if (kod == "EUR")
                return new Euro();
            else
                return new TurkLirasi();
        }

        private static XDocument GuncelKurlar()
        {
            XDocument tcmbdoviz = XDocument.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
            /*
            Merkez bankasından günlük döviz kurlarını alabiliriz.
            http://www.tcmb.gov.tr/kurlar/today.xml
            Currency : Para birimine ait bilgilerin bulunduğu alan
            Isim : Para biriminin adı
            ForexBuying: Kur alış
            ForexSelling : Kur satış 
            */

            return tcmbdoviz;
        }
        public static string getDovizAdi(string kod)
        {
            var DovizAdi =
                    (from kurlar in GuncelKurlar().Descendants("Currency")
                    where kurlar.Attribute("Kod").Value == kod
                    select kurlar.Element("Isim").Value).ToList()[0];
            return DovizAdi;
        }

        public static double getDovizAlisFiyati(string kod)
        {
            string DovizAlisFiyati =
                    (from kurlar in GuncelKurlar().Descendants("Currency")
                     where kurlar.Attribute("Kod").Value == kod
                     select kurlar.Element("ForexBuying").Value).ToList()[0].Replace('.',',');
            return double.Parse(DovizAlisFiyati);
        }

        public static double getDovizSatisFiyati(string kod)
        {
            System.Windows.Forms.MessageBox.Show(kod);
            string DovizSatisFiyati =
                    (from kurlar in GuncelKurlar().Descendants("Currency")
                     where kurlar.Attribute("Kod").Value == kod
                     select kurlar.Element("ForexSelling").Value).ToList()[0].Replace('.', ',');
            return double.Parse(DovizSatisFiyati);
        }

    }
}
