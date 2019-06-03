using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTemplateDataLayer.Entity; 

namespace ShopTemplateDataLayer.Context
{
    class ShopTemplateContext:DbContext
    {

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Urun> Urunler { get; set; }

        public ShopTemplateContext():base("shopTemplateDbConStr")
        {

        }
    }
}
