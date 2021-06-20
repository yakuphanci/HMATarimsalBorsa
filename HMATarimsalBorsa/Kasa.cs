using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMATarimsalBorsa
{
    public class Kasa
    {
        public double Bakiye { get;  set; }
    }

    public class KasaKontrol
    {
        public double BakiyeKontrol()
        {
            var kasa = Veriler.GetKasa();
            return (kasa.Bakiye);
        }
        public void BakiyeEkle(double miktar)
        {
            var kasa = Veriler.GetKasa();
            kasa.Bakiye += miktar;
            Veriler.SaveData(kasa);
        }
        public bool BakiyeDus(double miktar)
        {
            var kasa = Veriler.GetKasa();
            if (miktar > kasa.Bakiye)
                return false;
            kasa.Bakiye += miktar;
            Veriler.SaveData(kasa);
            return true;
        }
    }
}
