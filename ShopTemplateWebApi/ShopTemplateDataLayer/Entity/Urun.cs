using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTemplateDataLayer.Entity
{
    public class Urun
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string ResimYolu { get; set; }
        public Boolean Yeni { get; set; }

        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }

        public int MarkaId { get; set; }
        public Marka Marka { get; set; }
    }
}
