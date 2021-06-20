using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMATarimsalBorsa.DovizNesneleri.DovizTurleri
{
    class Euro : DovizAbstract
    {
        public override string DovizKodu()
        {
            return "EUR";
        }
    }
}
