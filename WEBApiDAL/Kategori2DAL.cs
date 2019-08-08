using System;
using System.Linq;

namespace WEBApiDAL
{
    public class Kategori2DAL
    {
        dbATUEntities db = new dbATUEntities();
        public Kategori2DAL() {
            db.Configuration.LazyLoadingEnabled = false;
        }
        public IQueryable<Kategori_2> getButunKategori2ByKat1(Kategori_1 kategori_1)
        {
            var res = from kt in db.Kategori_2
                      where kt.UstKategori == kategori_1.KategoriNo
                      select kt;
            return res;
        }


        public Kategori_2 getKategori2ById(Kategori_2 kategori_2)
        {
            Kategori_2 res = db.Kategori_2.Find(kategori_2.KategoriNo);
            return res;
        }
        public bool Kategori2Ekle(Kategori_2 Kategori_2)
        {
            bool res = false;

            try
            {
                db.Kategori_2.Add(Kategori_2);
                db.SaveChanges();
                res = true;
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }
        public bool Kategori2Guncelle(Kategori_2 Kategori_2)
        {
            bool res = false;

            try
            {
                db.Entry(Kategori_2).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                res = true;
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }
        public bool Kategori2Sil(Kategori_2 Kategori_2)
        {
            bool res = false;

            try
            {
                db.Kategori_2.Remove(db.Kategori_2.Find(Kategori_2.KategoriNo));
                db.SaveChanges();
                res = true;
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }
    }
}