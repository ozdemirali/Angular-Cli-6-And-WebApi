using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTemplateDataLayer.Model
{
    public class ViewUrun
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string ResimYolu { get; set; }
        public Boolean Yeni { get; set; }
        public string KategoriAd { get; set; }
        public string MarkaAd { get; set; }
    }
}
