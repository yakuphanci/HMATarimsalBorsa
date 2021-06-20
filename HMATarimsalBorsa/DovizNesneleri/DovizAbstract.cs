using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMATarimsalBorsa.DovizNesneleri
{
    public abstract class DovizAbstract
    {
        public abstract string DovizKodu();
        public virtual string DovizAdi()
        {
            return DovizKurlari.getDovizAdi(this.DovizKodu());
        }
        public virtual double AlisFiyati()
        {
            return DovizKurlari.getDovizAlisFiyati(this.DovizKodu());
        }
        public virtual double SatisFiyati()
        {
            return DovizKurlari.getDovizSatisFiyati(this.DovizKodu());
        }
    }
}
