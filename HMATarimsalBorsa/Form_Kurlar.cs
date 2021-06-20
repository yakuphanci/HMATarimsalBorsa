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

namespace HMATarimsalBorsa
{
    public partial class Form_Kurlar : Form
    {
        public Form_Kurlar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in DovizKurlari.KullanilabilirKurlar)
            {
                richTextBox1.AppendText(item.DovizAdi() + " (" + item.DovizKodu() + " / TRY) " + item.AlisFiyati() + " " + Environment.NewLine);
            }
        }
    }
}
