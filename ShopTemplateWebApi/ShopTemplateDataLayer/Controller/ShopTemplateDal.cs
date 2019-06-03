using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTemplateDataLayer.Context;
using ShopTemplateDataLayer.Entity;
using ShopTemplateDataLayer.Model;   

namespace ShopTemplateDataLayer.Controller
{
    
    
    public class ShopTemplateDal
    {
        private ShopTemplateContext db = new ShopTemplateContext();

        public List<ViewKategori> GetKategoriList()
        {
            var data = db.Kategoriler.ToList();

            List<ViewKategori> Kategoriler = new List<ViewKategori>();
            foreach (var item in data)
            {
                Kategoriler.Add(new ViewKategori() {
                     Id=item.Id,
                     Ad=item.Ad,
                });
            }
            return Kategoriler;
        }

        public List<ViewMarka> GetMarkaList()
        {
            var data = db.Markalar.ToList();
            List<ViewMarka> Markalar = new List<ViewMarka>();
            foreach (var item in data)
            {
                Markalar.Add(new ViewMarka()
                {
                    Id = item.Id,
                    Ad = item.Ad,
                });
            }
            return Markalar;

        }

        public List<ViewUrun> GetUrunList()
        {

            var data = (from u in db.Urunler
                        join m in db.Markalar
                        on u.MarkaId equals m.Id
                        join k in db.Kategoriler
                        on u.KategoriId equals k.Id
                        select new
                        {
                            Id = u.Id,
                            Ad = u.Ad,
                            Fiyat = u.Fiyat,
                            ResinYolu = u.ResimYolu,
                            Yeni = u.Yeni,
                            KategoriAd = k.Ad,
                            MarkaAd = m.Ad,
                        }).ToList();


            List<ViewUrun> Urunler = new List<ViewUrun>();
            foreach (var item in data)
            {
                Urunler.Add(new ViewUrun()
                {
                    Id = item.Id,
                    Ad = item.Ad,
                    Fiyat=item.Fiyat,
                    ResimYolu=item.ResinYolu,
                    Yeni=item.Yeni,
                    KategoriAd=item.KategoriAd,
                    MarkaAd=item.MarkaAd,

                });
            }
            return Urunler;
        }

        public ViewUrunDetay GetUrunById(int id)
        {
            var data = db.Urunler.Find(id);
            ViewUrunDetay urun = new ViewUrunDetay();
            if (data != null)
            {
                urun.Id = data.Id;
                urun.Ad = data.Ad;
                urun.Fiyat = data.Fiyat;
                urun.ResimYolu = data.ResimYolu;
                urun.Yeni = data.Yeni;
                urun.KategoriId = data.KategoriId;
                urun.MarkaId = data.MarkaId;
            }
            return urun;
        }

        public ViewUrunDetay CreateUrun(ViewUrunDetay urun)
        {
            Urun data = new Urun();
            data.Ad = urun.Ad;
            data.Fiyat = urun.Fiyat;
            data.ResimYolu = urun.ResimYolu;
            data.Yeni = urun.Yeni;
            data.KategoriId = urun.KategoriId;
            data.MarkaId = urun.MarkaId;
            db.Urunler.Add(data);
            db.SaveChanges();
            return urun;
        }

        public ViewUrunDetay UpdateUrun(ViewUrunDetay urun)
        {
            Urun data = new Urun();
            data.Id = urun.Id;
            data.Ad = urun.Ad;
            data.Fiyat = urun.Fiyat;
            data.ResimYolu = urun.ResimYolu;
            data.Yeni = urun.Yeni;
            data.KategoriId = urun.KategoriId;
            data.MarkaId = urun.MarkaId;
            db.Entry(data).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return urun;
        }

        public void DeleteUrun(int id)
        {
            db.Urunler.Remove(db.Urunler.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyUrun(int id)
        {
            return db.Urunler.Any(x => x.Id == id);
        }

    }
}
