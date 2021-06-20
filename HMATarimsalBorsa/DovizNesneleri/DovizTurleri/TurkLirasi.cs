using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMATarimsalBorsa.DovizNesneleri.DovizTurleri
{
    class TurkLirasi : DovizAbstract
    {
        public override string DovizKodu()
        {
            return "TRY";
        }
        public override double AlisFiyati()
        {
            return 1;
        }
        public override double SatisFiyati()
        {
            return 1;
        }
        public override string DovizAdi()
        {
            return "Türk Lirası";
        }
    }
}
